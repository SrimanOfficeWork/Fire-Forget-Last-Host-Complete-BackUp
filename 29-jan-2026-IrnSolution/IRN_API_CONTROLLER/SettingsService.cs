using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Caching.Memory;

namespace IRN_API_CONTROLLER
{
    public class SettingsService
    {
        private readonly IMemoryCache _cache;
        private readonly IConfiguration _config;
        private readonly ILogger<SettingsService> _logger;

        public SettingsService(IMemoryCache cache, IConfiguration config, ILogger<SettingsService> logger)
        {
            _cache = cache;
            _config = config;
            _logger = logger;
        }

        public async Task<(string Flag, string Message)> GetServerSettingsAsync()
        {
            try
            {
                if (!_cache.TryGetValue("ServerSettings", out (string Flag, string Message) settings))
                {
                    // Read refresh interval from appsettings.json (default to 10)
                    var refreshMinutes = int.TryParse(_config["ServerSettings:RefreshIntervalMinutes"], out var mins) ? mins : 10;
                    var refreshInterval = TimeSpan.FromMinutes(refreshMinutes);

                    // Fetch from database
                    settings = await FetchFromDbAsync();

                    // Cache it for the interval
                    _cache.Set("ServerSettings", settings, refreshInterval);

                    _logger.LogInformation("Server settings loaded from DB (Flag={Flag}, Message={Message}, CacheMinutes={Minutes})",
                                           settings.Flag, settings.Message, refreshMinutes);
                }
                else
                {
                    _logger.LogDebug("Server settings served from cache (Flag={Flag}, Message={Message})", settings.Flag, settings.Message);
                }

                return settings;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching server settings");
                // Return default safe value to avoid breaking the API
                return ("Y", "Error occurred - GetServerSettingsAsync");
            }
        }

        private async Task<(string Flag, string Message)> FetchFromDbAsync()
        {
            try
            {
                var connString = _config.GetConnectionString("DefaultConnection");
                const string sql = @"
                    SELECT maintenanceflag AS Flag, Message 
                    FROM [SERVER_SETTINGS] 
                    WHERE ModuleName='IRN'";

                _logger.LogInformation("Connected to DB to get the Maintenance settings in : {connection}", connString);

                await using var conn = new SqlConnection(connString);
                var row = await conn.QueryFirstOrDefaultAsync<(string Flag, string Message)>(sql);

                
                return row == default ? ("N", "Server running normally") : row;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching server settings from DB");

                // Return default safe value
                return ("Y", "Error occurred - FetchFromDbAsync");
            }
        }
    }
}
