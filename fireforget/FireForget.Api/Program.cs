using System.Data;
using System.Security.Cryptography;
using System.Text;
using Dapper;
using FireForget.Contracts;
using FireForget.Api;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using NLog;
using NLog.Web;

// Logs before the host is built, so a startup failure is still written to the log file.
var appLogger = LogManager.Setup()
    .LoadConfigurationFromAppSettings()
    .GetCurrentClassLogger();

try
{
    appLogger.Info("FireForget callback API starting up...");
    var builder = WebApplication.CreateBuilder(args);

    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    builder.Services.Configure<CallbackOptions>(builder.Configuration.GetSection("Callback"));
    builder.Services.Configure<RabbitOptions>(builder.Configuration.GetSection("RabbitMq"));
    builder.Services.AddSingleton<CallbackPublisher>();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title = "FireForget Callback API",
            Version = "v1",
            Description = "Receives the extraction result a vendor (e.g. Docker Vision) posts back for a queued job."
        });
        c.AddSecurityDefinition("ApiKey", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
        {
            Name = "X-Api-Key",
            Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
            In = Microsoft.OpenApi.Models.ParameterLocation.Header,
            Description = "The Callback:ApiKey value from appsettings.json"
        });
        c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
        {
            { new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                { Reference = new Microsoft.OpenApi.Models.OpenApiReference { Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme, Id = "ApiKey" } },
              Array.Empty<string>() }
        });
    });

    builder.WebHost.ConfigureKestrel(o =>
        o.Limits.MaxRequestBodySize = builder.Configuration.GetValue("Callback:MaxBodyBytes", 20_000_000L));

    var app = builder.Build();

    // Any unhandled exception in a request is logged with its stack trace, and the caller gets a plain 500.
    app.UseExceptionHandler(errorApp => errorApp.Run(async context =>
    {
        var error = context.Features.Get<IExceptionHandlerFeature>()?.Error;
        appLogger.Error(error, "Unhandled error on {Method} {Path}", context.Request.Method, context.Request.Path);
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await context.Response.WriteAsJsonAsync(new { Message = "Unexpected server error. See the FireForget log for details." });
    }));

    // Swagger is for local testing only. Production builds do not expose it.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "FireForget Callback API v1");
            c.RoutePrefix = "swagger";
        });

        // Open Swagger ourselves once Kestrel has actually finished starting, instead of relying on
        // launchSettings.json's launchBrowser (which some setups fire a moment too early, before the
        // listener is ready, and show "Unable to connect" on the very first load).
        app.Lifetime.ApplicationStarted.Register(() =>
        {
            try
            {
                var addresses = app.Services.GetRequiredService<Microsoft.AspNetCore.Hosting.Server.IServer>()
                    .Features.Get<Microsoft.AspNetCore.Hosting.Server.Features.IServerAddressesFeature>()?.Addresses;
                var baseUrl = addresses?.FirstOrDefault();
                if (string.IsNullOrEmpty(baseUrl)) return;

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = baseUrl.TrimEnd('/') + "/swagger",
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                // Best-effort only: a failed auto-open must never take the app down.
                appLogger.Warn(ex, "Could not open Swagger in the browser");
            }
        });
    }

    app.MapGet("/", () => "FireForget callback API is up and running.");

    // A vendor posts the extraction JSON here when a job finishes: POST /api/v1/callback/{vendor} (e.g. docker-vision).
    // Required: X-Api-Key header and ProcessId (header or query string). The ProcessId carries server, ERI ID and
    // working period (see ProcessIdCodec), so nothing else has to come back from the vendor.
    // Optional: EriId (must match the one inside ProcessId), JobType, PdfClientName, Status.
    app.MapPost("/api/v1/callback/{vendor}", async (
        string vendor,
        HttpRequest req,
        IOptions<CallbackOptions> options,
        CallbackPublisher publisher,
        ILogger<Program> logger) =>
    {
        var cfg = options.Value;

        if (string.IsNullOrEmpty(cfg.ApiKey))
        {
            logger.LogError("Callback:ApiKey is not configured - rejecting all callbacks");
            return Results.StatusCode(StatusCodes.Status503ServiceUnavailable);
        }

        var supplied = req.Headers["X-Api-Key"].ToString();
        if (!KeysMatch(supplied, cfg.ApiKey))
        {
            logger.LogWarning("Callback rejected: bad API key from {Ip}", req.HttpContext.Connection.RemoteIpAddress);
            return Results.Unauthorized();
        }

        var processId = Get(req, "ProcessId");
        if (!ProcessIdCodec.TryParse(processId, out var parts) || parts == null)
            return Results.BadRequest(new { Message = "ProcessId is missing or not in the expected format" });

        var eriId = parts.EriId;
        var suppliedEri = Get(req, "EriId");
        if (!string.IsNullOrWhiteSpace(suppliedEri) && !string.Equals(suppliedEri.Trim(), eriId, StringComparison.OrdinalIgnoreCase))
        {
            logger.LogWarning("Callback rejected: EriId header {Eri} does not match ProcessId {Pid}", suppliedEri, processId);
            return Results.BadRequest(new { Message = "EriId does not match ProcessId" });
        }

        string body;
        using (var reader = new StreamReader(req.Body, Encoding.UTF8))
            body = await reader.ReadToEndAsync();

        var msg = new CallbackMessage
        {
            Vendor = vendor.Trim(),
            ProcessId = processId!.Trim(),
            EriId = eriId,
            JobType = Get(req, "JobType"),
            PdfClientName = Get(req, "PdfClientName"),
            StatusHint = Get(req, "Status"),
            Payload = body,
            ReceivedUtc = DateTime.UtcNow
        };

        try
        {
            publisher.Publish(msg);
        }
        catch (Exception ex)
        {
            // 503 lets the vendor know it should try again; the data is not stored anywhere else.
            logger.LogError(ex, "Could not queue callback ProcessId={Pid} EriId={Eri}", msg.ProcessId, msg.EriId);
            return Results.StatusCode(StatusCodes.Status503ServiceUnavailable);
        }

        logger.LogInformation("Callback queued ProcessId={Pid} EriId={Eri} JobType={Job} Bytes={Bytes}",
            msg.ProcessId, msg.EriId, msg.JobType, body.Length);

        return Results.Accepted(value: new { msg.ProcessId, msg.EriId, Message = "Callback received and queued" });
    })
    .Accepts<string>("application/json") // body is read manually from req.Body; this just gives Swagger a body box
    .WithName("PostVendorCallback")
    .WithSummary("A vendor posts its extraction result for a queued job")
    .WithDescription("ProcessId (header or query string) is required and must match a job queued by PDF_AI_QUEUE_INSERT_UPDATE_SELECT (INSERT). " +
        "The raw body is stored as-is and classified READY/FAILED, then saved to the matching PDF_AI_QUEUE row by FireForget.Worker.")
    .Produces(StatusCodes.Status202Accepted)
    .Produces(StatusCodes.Status400BadRequest)
    .Produces(StatusCodes.Status401Unauthorized)
    .Produces(StatusCodes.Status503ServiceUnavailable)
    .WithOpenApi(op =>
    {
        op.Parameters.Add(new Microsoft.OpenApi.Models.OpenApiParameter
        {
            Name = "ProcessId", In = Microsoft.OpenApi.Models.ParameterLocation.Query, Required = true,
            Description = "server~eriId~workingPeriod~guid — generated by DockerVisionQueueClient.BuildProcessId when the job was submitted",
            Schema = new Microsoft.OpenApi.Models.OpenApiSchema { Type = "string" }
        });
        op.Parameters.Add(new Microsoft.OpenApi.Models.OpenApiParameter
        {
            Name = "EriId", In = Microsoft.OpenApi.Models.ParameterLocation.Query, Required = false,
            Description = "Optional — if sent, must match the ERI ID already encoded inside ProcessId",
            Schema = new Microsoft.OpenApi.Models.OpenApiSchema { Type = "string" }
        });
        op.Parameters.Add(new Microsoft.OpenApi.Models.OpenApiParameter
        {
            Name = "Status", In = Microsoft.OpenApi.Models.ParameterLocation.Query, Required = false,
            Description = "Optional vendor-reported status, e.g. Success / Failed",
            Schema = new Microsoft.OpenApi.Models.OpenApiSchema { Type = "string" }
        });
        return op;
    });

    // ── Docker Vision async callback (GUID ProcessId) ─────────────────────────────────────────────
    // Cochin POSTs form-data to this fixed URL. The routing and job key are form fields, not part of the URL:
    //   ServerName = key under Routing:Servers (admin DB connection), e.g. Live / Info / Pro / Local
    //   CompanyID  = ERI ID (COMPANY_ID in PDF_AI_QUEUE)
    //   ProcessId  = GUID that 4.0 generated and stored in PDF_AI_QUEUE.PROCESS_ID
    //   JSON       = a file part named JsonResponse, or a text field named JsonResponse / JsonData / Result
    app.MapPost("/api/v1/callback/docker-vision/", async (
        HttpRequest req, IConfiguration cfg, ILogger<Program> logger) =>
    {
        var apiKey = cfg["Callback:ApiKey"];
        if (string.IsNullOrEmpty(apiKey)) return Results.StatusCode(StatusCodes.Status503ServiceUnavailable);
        if (!KeysMatch(req.Headers["X-Api-Key"].ToString(), apiKey)) return Results.Unauthorized();

        if (!req.HasFormContentType) return Results.BadRequest(new { Message = "Callback must be sent as form-data" });
        var form = await req.ReadFormAsync();

        var serverName = form["ServerName"].ToString().Trim();
        var eri = form["CompanyID"].ToString().Trim();
        var processId = form["ProcessId"].ToString().Trim();

        var missing = new List<string>();
        foreach (var required in new[] { "ServerName", "CompanyID", "ProcessId", "JobNo", "FileName", "UserID",
            "BranchCode", "WorkingPeriod", "JobType", "PdfClientName" })
        {
            if (string.IsNullOrWhiteSpace(form[required].ToString())) missing.Add(required);
        }
        if (missing.Count > 0)
            return Results.BadRequest(new { Message = "Required form-data fields missing: " + string.Join(", ", missing) });

        if (!Guid.TryParse(processId, out _)) return Results.BadRequest(new { Message = "ProcessId must be a GUID" });

        var adminConn = cfg["Routing:Servers:" + serverName];
        if (string.IsNullOrEmpty(adminConn)) return Results.NotFound(new { Message = "Unknown server name: " + serverName });

        // The JSON is a file part named JsonResponse (or any file part), or a text field named JsonResponse / JsonData / Result.
        string body;
        var file = form.Files["JsonResponse"] ?? form.Files.FirstOrDefault();
        if (file != null)
        {
            using var fr = new StreamReader(file.OpenReadStream(), Encoding.UTF8);
            body = await fr.ReadToEndAsync();
        }
        else
        {
            body = form["JsonResponse"].ToString();
            if (string.IsNullOrWhiteSpace(body)) body = form["JsonData"].ToString();
            if (string.IsNullOrWhiteSpace(body)) body = form["Result"].ToString();
        }

        // 0) The JSON must belong to the company in the form: Header[0].CompanyID == CompanyID (case-insensitive).
        //    A result for another company is rejected and nothing is stored.
        string? jsonCompany = null;
        try
        {
            var root = System.Text.Json.Nodes.JsonNode.Parse(body);
            var first = root is System.Text.Json.Nodes.JsonArray arr ? arr.FirstOrDefault() : root;
            jsonCompany = first?["Header"] is System.Text.Json.Nodes.JsonArray hdr && hdr.Count > 0
                ? hdr[0]?["CompanyID"]?.GetValue<string>()
                : first?["Header"]?["CompanyID"]?.GetValue<string>();
        }
        catch { /* not JSON → handled below */ }

        if (string.IsNullOrWhiteSpace(jsonCompany))
            return Results.BadRequest(new { Message = "Response JSON has no Header CompanyID" });
        if (!string.Equals(jsonCompany.Trim(), eri, StringComparison.OrdinalIgnoreCase))
        {
            logger.LogWarning("Rejected callback ProcessId={Pid}: JSON CompanyID {Json} does not match CompanyID {Eri}", processId, jsonCompany, eri);
            return Results.UnprocessableEntity(new { Message = "CompanyID in the JSON (" + jsonCompany + ") does not match CompanyID " + eri });
        }

        // 1) ERI → company database (latest working period row in the admin DB)
        string? companyConn = null;
        await using (var admin = new SqlConnection(adminConn))
        {
            var target = await admin.QueryFirstOrDefaultAsync<CompanyDatabase>(
                "SELECT TOP 1 SERVER_NAME AS DataSource, DATABASE_NAME AS InitialCatalog, LOGIN_NAME AS UserID, PWD AS Password " +
                "FROM dbo.DATABASE_DETAILS WHERE COMPANY_LICENSE = @lic ORDER BY DATABASE_ID DESC",
                new { lic = eri });

            if (target != null)
            {
                companyConn = new SqlConnectionStringBuilder
                {
                    DataSource = target.DataSource,
                    InitialCatalog = target.InitialCatalog,
                    UserID = target.UserID,
                    Password = target.Password,
                    TrustServerCertificate = true,
                    ConnectTimeout = 15
                }.ConnectionString;
            }
        }
        if (companyConn == null) return Results.NotFound(new { Message = "No company database for CompanyID " + eri });

        // 2) classify READY / FAILED from the body (same rules as the worker)
        var (status, reason) = CallbackClassifier.Classify(Get(req, "Status"), body);

        // 3) store through the EXISTING procedure flags
        await using (var company = new SqlConnection(companyConn))
        {
            // GET_BY_PROCESS_ID: row must exist; ignore a repeat of a real response
            var current = await company.QueryFirstOrDefaultAsync<QueueRow>(
                "dbo.PDF_AI_QUEUE_INSERT_UPDATE_SELECT",
                new { MFLAG = "GET_BY_PROCESS_ID", PROCESS_ID = processId },
                commandType: CommandType.StoredProcedure);

            if (current == null) return Results.NotFound(new { Message = "No queue row for ProcessId " + processId });
            if (!string.IsNullOrWhiteSpace(current.JSON_RESPONSE) && (current.STATUS == "READY" || current.STATUS == "FAILED"))
            {
                logger.LogInformation("Duplicate callback ignored ProcessId={Pid} ERI={Eri}", processId, eri);
                return Results.Ok(new { processId, Message = "Duplicate callback ignored" });
            }

            // UPDATE_STATUS: the procedure reports SUCCESS or an error text through @ErrorMsg
            var update = new DynamicParameters();
            update.Add("@MFLAG", "UPDATE_STATUS");
            update.Add("@PROCESS_ID", processId);
            update.Add("@STATUS", status);
            update.Add("@JSON_RESPONSE", string.IsNullOrWhiteSpace(body) ? "{\"Status\":\"Failed\",\"Reason\":\"Empty body\"}" : body, DbType.String, size: -1);
            update.Add("@ErrorMsg", dbType: DbType.String, direction: ParameterDirection.Output, size: 1000);
            await company.ExecuteAsync("dbo.PDF_AI_QUEUE_INSERT_UPDATE_SELECT", update, commandType: CommandType.StoredProcedure);

            var updateResult = update.Get<string>("@ErrorMsg");
            if (updateResult != "SUCCESS")
            {
                logger.LogError("UPDATE_STATUS did not succeed ProcessId={Pid} ERI={Eri} Error={Err}", processId, eri, updateResult);
                return Results.StatusCode(StatusCodes.Status500InternalServerError);
            }

            // Submit fields that come back in the callback form-data and have a PDF_AI_QUEUE column.
            // The procedure has no parameters for them, so they are written on the same row here.
            // Empty fields are left unchanged. Column names come from the fixed dictionary below, never from the request.
            var columns = new Dictionary<string, string>
            {
                ["JOB_NO"] = form["JobNo"].ToString().Trim(),
                ["FILE_NAME"] = form["FileName"].ToString().Trim(),
                ["COMPANY_ID"] = form["CompanyID"].ToString().Trim(),
                ["USER_ID"] = form["UserID"].ToString().Trim(),
                ["BRANCH_CODE"] = form["BranchCode"].ToString().Trim(),
                ["WORKING_PERIOD"] = form["WorkingPeriod"].ToString().Trim(),
                ["JOB_TYPE"] = form["JobType"].ToString().Trim(),
                ["PDF_CLIENT_NAME"] = form["PdfClientName"].ToString().Trim()
            };
            var setParts = new List<string>();
            var fields = new DynamicParameters();
            foreach (var col in columns)
            {
                if (string.IsNullOrEmpty(col.Value)) continue;
                setParts.Add(col.Key + " = @" + col.Key);
                fields.Add("@" + col.Key, col.Value, DbType.String);
            }
            if (setParts.Count > 0)
            {
                fields.Add("@pid", processId, DbType.String);
                await company.ExecuteAsync(
                    "UPDATE PDF_AI_QUEUE SET " + string.Join(", ", setParts) +
                    ", UPDATED_DATE = GETDATE() WHERE PROCESS_ID = @pid", fields);
            }

            logger.LogInformation("Stored {Status} ProcessId={Pid} ERI={Eri} ServerName={Server} Fields={Fields}{Reason}",
                status, processId, eri, serverName, setParts.Count, reason == null ? "" : " (" + reason + ")");
        }

        return Results.Accepted(value: new { processId, status, Message = "Result stored" });
    });

    appLogger.Info("FireForget callback API started successfully");
    app.Run();
}
catch (Exception ex)
{
    appLogger.Error(ex, "Application stopped because of an exception");
    throw;
}
finally
{
    LogManager.Shutdown();
}

static string? Get(HttpRequest req, string name)
{
    var h = req.Headers[name].ToString();
    if (!string.IsNullOrWhiteSpace(h)) return h;
    var q = req.Query[name].ToString();
    return string.IsNullOrWhiteSpace(q) ? null : q;
}

static bool KeysMatch(string supplied, string expected)
{
    var a = Encoding.UTF8.GetBytes(supplied ?? string.Empty);
    var b = Encoding.UTF8.GetBytes(expected);
    return a.Length == b.Length && CryptographicOperations.FixedTimeEquals(a, b);
}

// Row shapes for Dapper. Property names match the SQL column names.
// Where a name differs (DataSource etc.), the SELECT aliases the column to match.
public sealed class CompanyDatabase
{
    public string DataSource { get; set; } = "";
    public string InitialCatalog { get; set; } = "";
    public string UserID { get; set; } = "";
    public string Password { get; set; } = "";
}

public sealed class QueueRow
{
    public string? STATUS { get; set; }
    public string? JSON_RESPONSE { get; set; }
}
