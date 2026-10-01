using System.Text.Json;
using FireForget.Contracts;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace FireForget.Worker.Services
{
    /// <summary>
    /// Consumes callbacks queued by FireForget.Api, works out which customer server they belong to (ERI ID),
    /// and writes READY / FAILED plus the raw JSON into that server's queue table.
    /// </summary>
    public sealed class CallbackConsumer : BackgroundService
    {
        private const string RetryHeader = "x-retry";

        private readonly RabbitOptions _rabbit;
        private readonly WorkerOptions _worker;
        private readonly RouteResolver _routes;
        private readonly QueueRepository _repo;
        private readonly ILogger<CallbackConsumer> _logger;

        public CallbackConsumer(IOptions<RabbitOptions> rabbit, IOptions<WorkerOptions> worker,
            RouteResolver routes, QueueRepository repo, ILogger<CallbackConsumer> logger)
        {
            _rabbit = rabbit.Value;
            _worker = worker.Value;
            _routes = routes;
            _repo = repo;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken ct)
        {
            while (!ct.IsCancellationRequested)
            {
                try
                {
                    await RunAsync(ct);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "RabbitMQ consumer stopped - reconnecting in 5s");
                    try { await Task.Delay(TimeSpan.FromSeconds(5), ct); } catch (OperationCanceledException) { break; }
                }
            }
        }

        private async Task RunAsync(CancellationToken ct)
        {
            var factory = new ConnectionFactory
            {
                HostName = _rabbit.Host,
                UserName = _rabbit.UserName,
                Password = _rabbit.Password,
                DispatchConsumersAsync = true,
                AutomaticRecoveryEnabled = false // we reconnect ourselves in ExecuteAsync
            };

            using var conn = factory.CreateConnection("dv-worker");
            using var ch = conn.CreateModel();

            ch.QueueDeclare(_rabbit.CallbackQueue, durable: true, exclusive: false, autoDelete: false);
            ch.QueueDeclare(_rabbit.DeadQueue, durable: true, exclusive: false, autoDelete: false);
            ch.BasicQos(0, _rabbit.Prefetch, false);

            var consumer = new AsyncEventingBasicConsumer(ch);
            consumer.Received += async (_, ea) => await HandleAsync(ch, ea, ct);
            ch.BasicConsume(_rabbit.CallbackQueue, autoAck: false, consumer: consumer);
            _logger.LogInformation("Listening on {Queue}", _rabbit.CallbackQueue);

            var lost = new TaskCompletionSource();
            conn.ConnectionShutdown += (_, _) => lost.TrySetResult();
            await Task.WhenAny(lost.Task, Task.Delay(Timeout.Infinite, ct));

            ct.ThrowIfCancellationRequested();
            throw new InvalidOperationException("RabbitMQ connection lost");
        }

        private async Task HandleAsync(IModel ch, BasicDeliverEventArgs ea, CancellationToken ct)
        {
            CallbackMessage? msg = null;
            try { msg = JsonSerializer.Deserialize<CallbackMessage>(ea.Body.Span); } catch { }

            if (msg == null || string.IsNullOrWhiteSpace(msg.ProcessId))
            {
                SendToDead(ch, ea, "Message could not be read");
                ch.BasicAck(ea.DeliveryTag, false);
                return;
            }

            try
            {
                await ProcessAsync(msg, ct);
                ch.BasicAck(ea.DeliveryTag, false);
            }
            catch (OperationCanceledException)
            {
                // Shutting down: leave it unacked so RabbitMQ redelivers it
                ch.BasicNack(ea.DeliveryTag, false, requeue: true);
            }
            catch (Exception ex)
            {
                var retry = GetRetry(ea.BasicProperties);
                if (retry >= _worker.MaxRetries)
                {
                    _logger.LogError(ex, "Giving up ProcessId={Pid} EriId={Eri} after {Retry} retries -> dead queue",
                        msg.ProcessId, msg.EriId, retry);
                    SendToDead(ch, ea, ex.Message);
                }
                else
                {
                    var delay = TimeSpan.FromSeconds(_worker.RetryBaseSeconds * Math.Pow(2, retry));
                    _logger.LogWarning("Retry {N}/{Max} in {Delay}s ProcessId={Pid}: {Msg}",
                        retry + 1, _worker.MaxRetries, delay.TotalSeconds, msg.ProcessId, ex.Message);
                    try { await Task.Delay(delay, ct); } catch (OperationCanceledException) { }
                    Republish(ch, ea, retry + 1);
                }
                ch.BasicAck(ea.DeliveryTag, false);
            }
        }

        private async Task ProcessAsync(CallbackMessage msg, CancellationToken ct)
        {
            if (!ProcessIdCodec.TryParse(msg.ProcessId, out var parts) || parts == null)
                throw new InvalidOperationException($"ProcessId '{msg.ProcessId}' is not in the expected format");

            var target = await _routes.ResolveAsync(parts, ct)
                ?? throw new InvalidOperationException(
                    $"No company database found for server '{parts.Server}', ERI '{parts.EriId}', period '{parts.WorkingPeriod}'");

            var (status, reason) = CallbackClassifier.Classify(msg.StatusHint, msg.Payload);

            var outcome = await _repo.SaveResponseAsync(target, msg.ProcessId, status, msg.Payload, ct);

            switch (outcome)
            {
                case SaveOutcome.Saved:
                    _logger.LogInformation("Saved {Status} ProcessId={Pid} Eri={Eri} Server={Server}{Reason}",
                        status, msg.ProcessId, parts.EriId, parts.Server, reason == null ? "" : " (" + reason + ")");
                    break;
                case SaveOutcome.DuplicateIgnored:
                    _logger.LogInformation("Duplicate callback ignored ProcessId={Pid}", msg.ProcessId);
                    break;
                default:
                    // Queue row not there yet (callback beat the insert): retry, then dead-letter
                    throw new InvalidOperationException(
                        $"Queue row for ProcessId '{msg.ProcessId}' not found in the company database");
            }
        }

        private static int GetRetry(IBasicProperties props)
            => props.Headers != null && props.Headers.TryGetValue(RetryHeader, out var o) && o is int i ? i : 0;

        private void Republish(IModel ch, BasicDeliverEventArgs ea, int retry)
        {
            var props = ch.CreateBasicProperties();
            props.Persistent = true;
            props.CorrelationId = ea.BasicProperties.CorrelationId;
            props.ContentType = ea.BasicProperties.ContentType;
            props.Headers = new Dictionary<string, object> { [RetryHeader] = retry };
            ch.BasicPublish("", _rabbit.CallbackQueue, props, ea.Body.ToArray());
        }

        private void SendToDead(IModel ch, BasicDeliverEventArgs ea, string reason)
        {
            var props = ch.CreateBasicProperties();
            props.Persistent = true;
            props.CorrelationId = ea.BasicProperties.CorrelationId;
            props.Headers = new Dictionary<string, object> { ["x-dead-reason"] = reason ?? "unknown" };
            ch.BasicPublish("", _rabbit.DeadQueue, props, ea.Body.ToArray());
        }
    }
}
