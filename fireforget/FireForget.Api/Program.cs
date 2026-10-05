using System.Security.Cryptography;
using System.Text;
using FireForget.Contracts;
using FireForget.Api;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

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

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "FireForget Callback API v1");
    c.RoutePrefix = "swagger"; // UI at /swagger, same port as the callback endpoint
});

app.MapGet("/", () => "FireForget callback API is up and running. See /swagger for the test UI.");

if (app.Environment.IsDevelopment())
{
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
        catch { /* best-effort only — a failed auto-open must never take the app down */ }
    });
}

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
    using (var admin = new Microsoft.Data.SqlClient.SqlConnection(adminConn))
    {
        await admin.OpenAsync();
        using var cmd = new Microsoft.Data.SqlClient.SqlCommand(
            "SELECT TOP 1 SERVER_NAME, DATABASE_NAME, LOGIN_NAME, PWD FROM dbo.DATABASE_DETAILS " +
            "WHERE COMPANY_LICENSE = @lic ORDER BY DATABASE_ID DESC", admin);
        cmd.Parameters.AddWithValue("@lic", eri);
        using var rd = await cmd.ExecuteReaderAsync();
        if (await rd.ReadAsync())
        {
            companyConn = new Microsoft.Data.SqlClient.SqlConnectionStringBuilder
            {
                DataSource = rd.GetString(0),
                InitialCatalog = rd.GetString(1),
                UserID = rd.GetString(2),
                Password = rd.GetString(3),
                TrustServerCertificate = true,
                ConnectTimeout = 15
            }.ConnectionString;
        }
    }
    if (companyConn == null) return Results.NotFound(new { Message = "No company database for CompanyID " + eri });

    // 2) classify READY / FAILED from the body (same rules as the worker)
    var (status, reason) = CallbackClassifier.Classify(Get(req, "Status"), body);

    // 3) store through the EXISTING procedure flags
    using (var company = new Microsoft.Data.SqlClient.SqlConnection(companyConn))
    {
        await company.OpenAsync();

        // GET_BY_PROCESS_ID: row must exist; ignore a repeat of a real response
        string? currentStatus = null; string? currentJson = null; bool found = false;
        using (var get = new Microsoft.Data.SqlClient.SqlCommand("dbo.PDF_AI_QUEUE_INSERT_UPDATE_SELECT", company) { CommandType = System.Data.CommandType.StoredProcedure })
        {
            get.Parameters.AddWithValue("@MFLAG", "GET_BY_PROCESS_ID");
            get.Parameters.AddWithValue("@PROCESS_ID", processId);
            using var rd = await get.ExecuteReaderAsync();
            if (await rd.ReadAsync()) { found = true; currentStatus = rd["STATUS"] as string; currentJson = rd["JSON_RESPONSE"] as string; }
        }
        if (!found) return Results.NotFound(new { Message = "No queue row for ProcessId " + processId });
        if (!string.IsNullOrWhiteSpace(currentJson) && (currentStatus == "READY" || currentStatus == "FAILED"))
            return Results.Ok(new { processId, Message = "Duplicate callback ignored" });

        using (var upd = new Microsoft.Data.SqlClient.SqlCommand("dbo.PDF_AI_QUEUE_INSERT_UPDATE_SELECT", company) { CommandType = System.Data.CommandType.StoredProcedure })
        {
            upd.Parameters.AddWithValue("@MFLAG", "UPDATE_STATUS");
            upd.Parameters.AddWithValue("@PROCESS_ID", processId);
            upd.Parameters.AddWithValue("@STATUS", status);
            upd.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@JSON_RESPONSE", System.Data.SqlDbType.NVarChar, -1) { Value = string.IsNullOrWhiteSpace(body) ? "{\"Status\":\"Failed\",\"Reason\":\"Empty body\"}" : body });
            var err = new Microsoft.Data.SqlClient.SqlParameter("@ErrorMsg", System.Data.SqlDbType.NVarChar, 1000) { Direction = System.Data.ParameterDirection.Output };
            upd.Parameters.Add(err);
            await upd.ExecuteNonQueryAsync();
            if ((err.Value as string) != "SUCCESS") return Results.StatusCode(StatusCodes.Status500InternalServerError);
        }

        // Submit fields that come back in the callback form-data and have a PDF_AI_QUEUE column.
        // The procedure has no parameters for them, so they are written on the same row here.
        // Empty fields are left unchanged.
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
        using var fieldCmd = new Microsoft.Data.SqlClient.SqlCommand { Connection = company };
        foreach (var col in columns)
        {
            if (string.IsNullOrEmpty(col.Value)) continue;
            setParts.Add(col.Key + " = @" + col.Key);
            fieldCmd.Parameters.AddWithValue("@" + col.Key, col.Value);
        }
        if (setParts.Count > 0)
        {
            fieldCmd.CommandText = "UPDATE PDF_AI_QUEUE SET " + string.Join(", ", setParts) +
                ", UPDATED_DATE = GETDATE() WHERE PROCESS_ID = @pid";
            fieldCmd.Parameters.AddWithValue("@pid", processId);
            await fieldCmd.ExecuteNonQueryAsync();
        }

        logger.LogInformation("Stored {Status} ProcessId={Pid} ERI={Eri} Server={Server}{Reason}", status, processId, eri, serverName, reason == null ? "" : " (" + reason + ")");
    }

    return Results.Accepted(value: new { processId, status, Message = "Result stored" });
});

app.Run();

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
