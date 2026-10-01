using System.Text.Json;
using FireForget.Contracts;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace FireForget.Api
{
    public class CallbackOptions
    {
        public string ApiKey { get; set; } = string.Empty;
        public long MaxBodyBytes { get; set; } = 20_000_000;
    }

    public class RabbitOptions
    {
        public string Host { get; set; } = "localhost";
        public string UserName { get; set; } = "guest";
        public string Password { get; set; } = "guest";
        public string CallbackQueue { get; set; } = "fireforget.callbacks";
    }

    /// <summary>Publishes each callback to a durable queue with publisher confirms, so a 202 means RabbitMQ has it.</summary>
    public sealed class CallbackPublisher : IDisposable
    {
        private readonly RabbitOptions _opt;
        private readonly ILogger<CallbackPublisher> _logger;
        private readonly object _lock = new();
        private IConnection? _conn;

        public CallbackPublisher(IOptions<RabbitOptions> opt, ILogger<CallbackPublisher> logger)
        {
            _opt = opt.Value;
            _logger = logger;
        }

        private IConnection GetConnection()
        {
            lock (_lock)
            {
                if (_conn is { IsOpen: true }) return _conn;
                _conn?.Dispose();

                var factory = new ConnectionFactory
                {
                    HostName = _opt.Host,
                    UserName = _opt.UserName,
                    Password = _opt.Password,
                    AutomaticRecoveryEnabled = true
                };
                _conn = factory.CreateConnection("dv-callback-api");
                _logger.LogInformation("Connected to RabbitMQ at {Host}", _opt.Host);
                return _conn;
            }
        }

        public void Publish(CallbackMessage msg)
        {
            var conn = GetConnection();
            using var ch = conn.CreateModel();
            ch.QueueDeclare(_opt.CallbackQueue, durable: true, exclusive: false, autoDelete: false);
            ch.ConfirmSelect();

            var props = ch.CreateBasicProperties();
            props.Persistent = true;
            props.CorrelationId = msg.ProcessId;
            props.ContentType = "application/json";

            var body = JsonSerializer.SerializeToUtf8Bytes(msg);
            ch.BasicPublish(exchange: "", routingKey: _opt.CallbackQueue, basicProperties: props, body: body);
            ch.WaitForConfirmsOrDie(TimeSpan.FromSeconds(5));
        }

        public void Dispose()
        {
            try { _conn?.Close(); } catch { }
        }
    }
}
