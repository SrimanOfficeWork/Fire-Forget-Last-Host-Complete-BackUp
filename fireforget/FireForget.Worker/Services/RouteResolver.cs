using FireForget.Contracts;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace FireForget.Worker.Services
{
    /// <summary>A company database that owns a PDF_AI_QUEUE table.</summary>
    public record CompanyTarget(string Server, string EriId, string WorkingPeriod, string ConnectionString);

    /// <summary>
    /// Finds the company database for a callback using the existing admin database:
    /// server key (from the ProcessId) -> admin connection string (worker config) -> DATABASE_DETAILS row
    /// for that company license and working period.
    /// </summary>
    public sealed class RouteResolver
    {
        private readonly RouteOptions _opt;
        private readonly IMemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
        private readonly ILogger<RouteResolver> _logger;

        public RouteResolver(IOptions<RouteOptions> opt, ILogger<RouteResolver> logger)
        {
            _opt = opt.Value;
            _logger = logger;
        }

        public async Task<CompanyTarget?> ResolveAsync(ProcessIdParts p, CancellationToken ct)
        {
            var key = $"{p.Server}|{p.EriId}|{p.WorkingPeriod}".ToUpperInvariant();
            if (_cache.TryGetValue(key, out CompanyTarget? cached)) return cached;

            var adminConn = FindAdminConnection(p.Server);
            if (adminConn == null)
            {
                _logger.LogError("Server '{Server}' is not in the worker's Routing:Servers list", p.Server);
                return null;
            }

            await using var conn = new SqlConnection(adminConn);
            await conn.OpenAsync(ct);
            await using var cmd = new SqlCommand(@"
                SELECT TOP 1 SERVER_NAME, DATABASE_NAME, LOGIN_NAME, PWD, WORKING_PERIOD
                FROM dbo.DATABASE_DETAILS
                WHERE COMPANY_LICENSE = @lic AND REPLACE(WORKING_PERIOD, ' ', '') = @wp
                ORDER BY DATABASE_ID DESC", conn);
            cmd.Parameters.AddWithValue("@lic", p.EriId);
            cmd.Parameters.AddWithValue("@wp", p.WorkingPeriod);

            await using var rd = await cmd.ExecuteReaderAsync(ct);
            if (!await rd.ReadAsync(ct))
            {
                _logger.LogWarning("No DATABASE_DETAILS row for {Eri} / {Wp} on {Server}", p.EriId, p.WorkingPeriod, p.Server);
                return null;
            }

            var target = new CompanyTarget(p.Server, p.EriId, p.WorkingPeriod,
                BuildConnectionString(rd.GetString(0), rd.GetString(1), rd.GetString(2), rd.GetString(3)));

            _cache.Set(key, target, TimeSpan.FromMinutes(_opt.CacheMinutes));
            return target;
        }

        /// <summary>Latest company database of every OCR-enabled company on every configured server (for the timeout sweep).</summary>
        public async Task<IReadOnlyList<CompanyTarget>> GetSweepTargetsAsync(CancellationToken ct)
        {
            var list = new List<CompanyTarget>();
            foreach (var (server, adminConn) in _opt.Servers)
            {
                try
                {
                    await using var conn = new SqlConnection(adminConn);
                    await conn.OpenAsync(ct);
                    await using var cmd = new SqlCommand(@"
                        SELECT d.COMPANY_LICENSE, d.SERVER_NAME, d.DATABASE_NAME, d.LOGIN_NAME, d.PWD, d.WORKING_PERIOD
                        FROM (SELECT *, ROW_NUMBER() OVER (PARTITION BY COMPANY_LICENSE ORDER BY WORKING_PERIOD DESC) AS rn
                              FROM dbo.DATABASE_DETAILS) d
                        WHERE d.rn = 1
                          AND EXISTS (SELECT 1 FROM dbo.ADMIN_PREMIUM_SERVICES s
                                      WHERE s.COMPANY_LICENSE = d.COMPANY_LICENSE AND s.FEATURES = 'OCR')", conn);
                    await using var rd = await cmd.ExecuteReaderAsync(ct);
                    while (await rd.ReadAsync(ct))
                    {
                        list.Add(new CompanyTarget(server, rd.GetString(0),
                            ProcessIdCodec.Compact(rd.GetString(5)),
                            BuildConnectionString(rd.GetString(1), rd.GetString(2), rd.GetString(3), rd.GetString(4))));
                    }
                }
                catch (Exception ex) when (ex is not OperationCanceledException)
                {
                    _logger.LogError(ex, "Could not list companies on server {Server}", server);
                }
            }
            return list;
        }

        private string? FindAdminConnection(string server)
        {
            foreach (var kv in _opt.Servers)
                if (string.Equals(kv.Key, server, StringComparison.OrdinalIgnoreCase)) return kv.Value;
            return null;
        }

        private static string BuildConnectionString(string host, string database, string user, string password)
            => new SqlConnectionStringBuilder
            {
                DataSource = host,
                InitialCatalog = database,
                UserID = user,
                Password = password,
                TrustServerCertificate = true,
                ConnectTimeout = 15
            }.ConnectionString;
    }
}
