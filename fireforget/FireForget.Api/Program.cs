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
