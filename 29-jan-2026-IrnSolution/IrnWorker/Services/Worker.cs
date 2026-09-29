using System.Text.Json;
using Contracts;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace IrnWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _cfg;
        //private readonly RpaUploader _rpa;
        private IConnection? _conn;
        private IModel? _ch;
        private string _reqQueue = "";
        private string _resQueue = "";
        private readonly IServiceProvider _serviceProvider;
        public Worker(ILogger<Worker> logger, IConfiguration cfg, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _cfg = cfg;
            _serviceProvider = serviceProvider;

        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            var factory = new ConnectionFactory
            {
                HostName =_cfg.GetValue("RabbitMq:Host", "localhost")
            };
            _conn = factory.CreateConnection();
            _ch = _conn.CreateModel();
            _reqQueue = _cfg.GetValue("RabbitMq:RequestQueue","icegate.irn.requests");
            _resQueue = _cfg.GetValue("RabbitMq:ResponseQueue","icegate.irn.results");
            _ch.QueueDeclare(_reqQueue, durable: true, exclusive: false, autoDelete: false, arguments: null);
            _ch.QueueDeclare(_resQueue, durable: true, exclusive: false, autoDelete: false, arguments: null);
            //_ch.BasicQos(0, prefetchCount: 3, global: false);
            int maxJobs = _cfg.GetValue("RabbitMq:ParallelJobCount", 5);
            _ch.BasicQos(0, prefetchCount: (ushort)maxJobs, global: false);
            _logger.LogInformation("Worker started, listening on queue {q}",_reqQueue);
            return base.StartAsync(cancellationToken);
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_ch);
            consumer.Received += async (sender, ea) =>
            {
                var body = ea.Body.ToArray();
                try
                {
                    using var scope = _serviceProvider.CreateScope();

                    var rpa = scope.ServiceProvider.GetRequiredService<RpaUploader>();
                    var req = JsonSerializer.Deserialize<UploadRequest>(body);
                    if (req == null)
                    {
                        _logger.LogError("Invalid request payload");
                        _ch.BasicNack(ea.DeliveryTag, false, requeue: false);
                        return;
                    }                    
                    //_logger.LogInformation("Processing {CorrelationId} {JobNo} {CompanyLicense} with {count} files", req.CorrelationId, req.JobNo, req.CompanyId, req.Files.Count);
                    UploadResult result = new()
                    {
                        CorrelationId =req.CorrelationId,
                        Success = false
                    };
                    try
                    {
                        var outcomes = await rpa.ProcessUploadAsync(req,stoppingToken);
                        result = new UploadResult{CorrelationId =req.CorrelationId,Success = true,Outcomes = outcomes};
                    }
                    catch (Exception ex)
                    {
                        result = new UploadResult
                        {
                            CorrelationId =req.CorrelationId,Success = false,Error = ex.Message,Outcomes = new()
                        };
                        _logger.LogError(ex, "Processing failed for  {CorrelationId} {JobNo} {CompanyLicense}", req.CorrelationId, req.JobNo, req.CompanyId);
                    }
                    var resBytes = JsonSerializer.SerializeToUtf8Bytes(result);
                    var props = _ch.CreateBasicProperties();
                    props.Persistent = true;
                    props.CorrelationId = req.CorrelationId;
                    _ch.BasicPublish("", _resQueue, props, resBytes);
                    _ch.BasicAck(ea.DeliveryTag, multiple: false);
                    _logger.LogInformation("Done {CorrelationId} {JobNo} {CompanyLicense}", req.CorrelationId, req.JobNo, req.CompanyId);
                    _logger.LogInformation("-------------------------------------------------------------------------------------------");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Unhandled error while processing delivery");
                    _ch.BasicNack(ea.DeliveryTag, false, requeue: false);
                }
            };
            _ch.BasicConsume(queue: _reqQueue, autoAck: false, consumer: consumer);
            return Task.CompletedTask;
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            try { _ch?.Close(); } catch { }
            try { _conn?.Close(); } catch { }
            return base.StopAsync(cancellationToken);
        }
    }
}
