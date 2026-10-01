using Microsoft.Extensions.Options;

namespace FireForget.Worker.Services
{
    /// <summary>
    /// Docker Vision keeps nothing, so a callback that never arrives would leave a job IN PROGRESS forever.
    /// Every few minutes this marks stale Docker Vision jobs FAILED in every OCR-enabled company database.
    /// </summary>
    public sealed class TimeoutSweeper : BackgroundService
    {
        private readonly WorkerOptions _opt;
        private readonly RouteResolver _routes;
        private readonly QueueRepository _repo;
        private readonly ILogger<TimeoutSweeper> _logger;

        public TimeoutSweeper(IOptions<WorkerOptions> opt, RouteResolver routes, QueueRepository repo,
            ILogger<TimeoutSweeper> logger)
        {
            _opt = opt.Value;
            _routes = routes;
            _repo = repo;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken ct)
        {
            if (!_opt.TimeoutEnabled)
            {
                _logger.LogInformation("Timeout sweeper disabled");
                return;
            }

            while (!ct.IsCancellationRequested)
            {
                try
                {
                    foreach (var target in await _routes.GetSweepTargetsAsync(ct))
                    {
                        try
                        {
                            var n = await _repo.TimeoutStaleAsync(target, _opt.TimeoutMinutes, ct);
                            if (n > 0)
                                _logger.LogWarning("Marked {N} Docker Vision job(s) FAILED for {Eri} on {Server} (no callback in {Min} min)",
                                    n, target.EriId, target.Server, _opt.TimeoutMinutes);
                        }
                        catch (Exception ex) when (ex is not OperationCanceledException)
                        {
                            _logger.LogError(ex, "Timeout sweep failed for {Eri} on {Server}", target.EriId, target.Server);
                        }
                    }
                }
                catch (OperationCanceledException) { break; }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Timeout sweep could not list companies");
                }

                try { await Task.Delay(TimeSpan.FromMinutes(_opt.SweepEveryMinutes), ct); }
                catch (OperationCanceledException) { break; }
            }
        }
    }
}
