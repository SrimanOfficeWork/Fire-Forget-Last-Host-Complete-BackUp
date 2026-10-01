using System.Security.Cryptography;
using System.Text;
using FireForget.Contracts;
using FireForget.Api;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<CallbackOptions>(builder.Configuration.GetSection("Callback"));
builder.Services.Configure<RabbitOptions>(builder.Configuration.GetSection("RabbitMq"));
builder.Services.AddSingleton<CallbackPublisher>();

builder.WebHost.ConfigureKestrel(o =>
    o.Limits.MaxRequestBodySize = builder.Configuration.GetValue("Callback:MaxBodyBytes", 20_000_000L));

var app = builder.Build();

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
