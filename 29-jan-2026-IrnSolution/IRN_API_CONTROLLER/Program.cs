using System.Text.Json;
using Contracts;
using IRN.Api.Controllers;
using IRN_API_CONTROLLER;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using NLog;
using NLog.Web;
using RabbitMQ.Client;

var logger = LogManager.Setup()
    .LoadConfigurationFromAppSettings()
    .GetCurrentClassLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Register services
    builder.Services.AddSingleton<StatusStore>();
    builder.Services.AddSingleton<RabbitPublisher>();
    builder.Services.AddMemoryCache();
    builder.Services.AddScoped<SettingsService>();
    // Use NLog instead of default logging
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    builder.Services.AddControllers();

    var app = builder.Build();

    app.MapControllers(); // enable controllers

    app.Run();

}
catch (Exception ex)
{
    logger.Error(ex, "Application stopped due to an exception");
    throw;
}
finally
{
    LogManager.Shutdown();
}

namespace IRN.Api.Controllers
{
    // ---------------- JobsController ----------------
    [ApiController]
    [Route("api/v2/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly RabbitPublisher _publisher;
        private readonly StatusStore _store;
        private readonly ILogger<JobsController> _logger;
        private readonly IConfiguration _config;
        private readonly SettingsService _settings;

        public JobsController(SettingsService settings, IConfiguration config, RabbitPublisher publisher, StatusStore store, ILogger<JobsController> logger)
        {
            _config = config;
            _publisher = publisher;
            _store = store;
            _logger = logger;
            _settings = settings;
        }

        // POST: /api/v2/jobs
        [HttpPost("CreateJob_v1")]
        public async Task<IActionResult> CreateJob_v1([FromBody] UploadRequest req)
        {
            try
            {
                if (req == null)
                    return BadRequest("Request body cannot be null");

                // Check server maintenance
                var (maintenanceFlag, message) = await _settings.GetServerSettingsAsync();
                if (maintenanceFlag == "Y")
                {
                    _logger.LogWarning("Request blocked due to maintenance. JobNo={JobNo}, CorrelationId={Cid}, CompanyId={CompanyId}, Message={Message}",
                                       req.JobNo, req.CorrelationId, req.CompanyId, message);

                    return StatusCode(StatusCodes.Status200OK, new
                    {
                        CorrelationId = req.CorrelationId,
                        JobNo = req.JobNo,
                        CompanyId = req.CompanyId,
                        Message = "Request blocked due to maintenance"
                    });
                }

                // Validate input fields
                if (string.IsNullOrWhiteSpace(req.CorrelationId))
                    return BadRequest("CorrelationId is required");

                if (string.IsNullOrWhiteSpace(req.JobNo))
                    return BadRequest("JobNo is required");

                if (string.IsNullOrWhiteSpace(req.CompanyId))
                    return BadRequest("CompanyId is required");

                // Save initial state
                var initial = new UploadResult
                {
                    CorrelationId = req.CorrelationId,
                    Success = false,
                    Error = "Queued",
                    Outcomes = new()
                };
                _store.Set(req.CorrelationId, initial);
                // Publish to RabbitMQ
                await _publisher.PublishRequestAsync(req);
                _logger.LogInformation("Job queued successfully: {@Request}", req);                

                // Return Accepted response
                return Accepted($"/api/v2/jobs/{req.CorrelationId}", new
                {
                    CorrelationId = req.CorrelationId,
                    JobNo = req.JobNo,
                    CompanyId = req.CompanyId,
                    Message = "IRN request submitted successfully"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"Error while processing job request. {@Request} ",req);

                // return generic 500 response
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    CorrelationId = req?.CorrelationId,
                    JobNo = req?.JobNo,
                    CompanyId = req?.CompanyId,
                    Message = "An unexpected error occurred. Please try again later."
                });
            }
        }


        [HttpPost("CreateJob")]
        public async Task<IActionResult> CreateJob([FromBody] UploadRequest req)
        {
            try
            {
                if (req == null)
                    return BadRequest("Request body cannot be null");

                // Validate input
                if (string.IsNullOrWhiteSpace(req.CorrelationId))
                    return BadRequest("CorrelationId is required");
                if (string.IsNullOrWhiteSpace(req.TransId))
                    return BadRequest("JobNo is required");
                if (string.IsNullOrWhiteSpace(req.CompanyId))
                    return BadRequest("CompanyId is required");

                // --- Maintenance check ---
                var (maintenanceFlag, message) = await _settings.GetServerSettingsAsync();
                maintenanceFlag = "N";
                if (maintenanceFlag == "Y")
                {
                    _logger.LogWarning("Request blocked due to maintenance. TransId={TransId}, CorrelationId={Cid}, CompanyId={CompanyId}, Message={Message}",
                                       req.JobNo, req.CorrelationId, req.CompanyId, message);

                    return StatusCode(StatusCodes.Status200OK, new
                    {
                        CorrelationId = req.CorrelationId,                        
                        Message = "Request blocked due to maintenance"
                    });
                }

                // --- Step 1: Create folder structure ---
                var rootFolder = Path.Combine("D:\\IRN_DOC\\UploadedFiles");
                var jobFolder = Path.Combine(rootFolder, req.CorrelationId);

                if (!Directory.Exists(jobFolder))
                    Directory.CreateDirectory(jobFolder);

                // --- Step 2: Save files and nullify base64 ---
                if (req.Files != null && req.Files.Count > 0)
                {
                    foreach (var file in req.Files)
                    {
                        if (string.IsNullOrWhiteSpace(file.FileName) || string.IsNullOrWhiteSpace(file.FileContent))
                            continue;

                        var filePath = Path.Combine(jobFolder, file.FileName);

                        try
                        {
                            var fileBytes = Convert.FromBase64String(file.FileContent);
                            await System.IO.File.WriteAllBytesAsync(filePath, fileBytes);
                            _logger.LogInformation("Saved file {FileName} for CorrelationId={Cid}", file.FileName, req.CorrelationId);
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex, "Error saving file {FileName} for CorrelationId={Cid}", file.FileName, req.CorrelationId);
                        }

                        // Nullify base64 to keep request lightweight
                        file.FileContent = null;
                    }
                }

                // --- Step 3: Update request with folder path ---
                req = req with { FolderPath = jobFolder };

                // --- Step 4: Cache initial job state ---
                var initial = new UploadResult
                {
                    CorrelationId = req.CorrelationId,
                    Success = false,
                    Error = "Queued",
                    Outcomes = new()
                };
                _store.Set(req.CorrelationId, initial);

                // --- Step 5: Publish same req (with FolderPath) to RabbitMQ ---
                await _publisher.PublishRequestAsync(req);
                _logger.LogInformation("Job queued successfully for CorrelationId={Cid}, Folder={Folder}", req.CorrelationId, jobFolder);

                // --- Step 6: Return Accepted response ---
                return Accepted($"/api/v2/jobs/{req.CorrelationId}", new
                {
                    CorrelationId = req.CorrelationId,
                    JobNo = req.JobNo,
                    CompanyId = req.CompanyId,
                    Message = "Files saved and IRN request queued successfully"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing job request. CorrelationId={Cid}", req?.CorrelationId);
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    CorrelationId = req?.CorrelationId,
                    Message = "An unexpected error occurred. Please try again later."
                });
            }
        }


        [HttpGet("{cid}")]
        public IActionResult GetJob(string cid)
        {
            if (string.IsNullOrWhiteSpace(cid))
                return BadRequest("Correlation ID cannot be empty");

            if (_store.TryGet(cid, out var res))
            {
                _logger.LogInformation("Returning status for job {Cid}", cid);
                return Ok(res);
            }
            else
            {
                _logger.LogWarning("No job found for CorrelationId={Cid}", cid);
                return NotFound(new
                {
                    CorrelationId = cid,
                    Message = "No job found for the provided Correlation ID"
                });
            }
        }

        [HttpGet("test")]
        public IActionResult TestJobApi()
        {
            _logger.LogInformation("Test endpoint called");
            return Ok("JobsController is working fine(API Controller)");
        }
    }

    // ---------------- HealthController ----------------
    [ApiController]
    [Route("/")]
    public class HealthController : ControllerBase
    {
        private readonly ILogger<HealthController> _logger;

        public HealthController(ILogger<HealthController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Health check requested");
            return Ok("IRN API is up and running....(API Controller)");
        }
    }
    public sealed class StatusStore
    {
        private readonly IMemoryCache _cache;
        private readonly ILogger<StatusStore> _logger;
        private readonly TimeSpan _defaultExpiry;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cache">IMemoryCache instance</param>
        /// <param name="logger">Logger instance</param>
        /// <param name="fallbackMinutes">Default fallback expiration in minutes for abandoned jobs</param>
        public StatusStore(IMemoryCache cache, ILogger<StatusStore> logger, int fallbackMinutes = 20)
        {
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _defaultExpiry = TimeSpan.FromMinutes(fallbackMinutes);
        }

        /// <summary>
        /// Adds or updates a pending IRN request in the cache
        /// </summary>
        public void Set(string correlationId, UploadResult result, TimeSpan? expiry = null)
        {
            if (string.IsNullOrWhiteSpace(correlationId))
                throw new ArgumentNullException(nameof(correlationId));
            if (result == null)
                throw new ArgumentNullException(nameof(result));

            var options = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expiry ?? _defaultExpiry
            };

            _cache.Set(correlationId, result, options);
            _logger.LogInformation("Job {Cid} added/updated in cache with expiry {Expiry} minutes", correlationId, (expiry ?? _defaultExpiry).TotalMinutes);
        }
        /// <summary>
        /// Tries to get a pending IRN request from cache
        /// </summary>
        public bool TryGet(string correlationId, out UploadResult result, bool removeAfterRead = false)
        {
            var found = _cache.TryGetValue(correlationId, out result);
            if (found && removeAfterRead)
                _cache.Remove(correlationId);
            return found;
        }
        /// <summary>
        /// Explicitly removes a job from cache after IRN generation completes
        /// </summary>
        public void Remove(string correlationId)
        {
            if (string.IsNullOrWhiteSpace(correlationId))
                return;

            _cache.Remove(correlationId);
            _logger.LogInformation("Job {Cid} removed from cache", correlationId);
        }
    }

    public sealed class RabbitPublisher : IDisposable
    {
        private readonly IConnection _conn;
        private readonly string _requestQueue;
        private readonly ILogger<RabbitPublisher> _logger;

        public RabbitPublisher(IConfiguration cfg, ILogger<RabbitPublisher> logger)
        {
            _logger = logger;
            var host = cfg.GetValue<string>("RabbitMq:Host") ?? "localhost";
            _requestQueue = cfg.GetValue<string>("RabbitMq:RequestQueue") ?? "icegate.irn.requests";

            var factory = new ConnectionFactory { HostName = host };
            _conn = factory.CreateConnection();

            // Declare queue once on startup
            using var ch = _conn.CreateModel();
            ch.QueueDeclare(_requestQueue, durable: true, exclusive: false, autoDelete: false);
            _logger.LogInformation("Connected to RabbitMQ at {Host}, queue {Queue}", host, _requestQueue);
        }

        public Task PublishRequestAsync(UploadRequest req)
        {
            try
            {
                using var ch = _conn.CreateModel(); // per-request channel
                var body = JsonSerializer.SerializeToUtf8Bytes(req);
                var props = ch.CreateBasicProperties();
                props.Persistent = true;
                props.CorrelationId = req.CorrelationId;

                ch.BasicPublish(exchange: "", routingKey: _requestQueue,
                                 basicProperties: props, body: body);

                _logger.LogInformation("Published job request {Cid} to queue {Queue}", req.CorrelationId, _requestQueue);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error publishing job {Cid}", req.CorrelationId);
                throw;
            }
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            try { _conn?.Close(); } catch { }
            _logger.LogInformation("RabbitMQ connection closed");
        }
    }
}
