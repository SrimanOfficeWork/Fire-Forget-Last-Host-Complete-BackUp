namespace FireForget.Worker
{
    public class RabbitOptions
    {
        public string Host { get; set; } = "localhost";
        public string UserName { get; set; } = "guest";
        public string Password { get; set; } = "guest";
        public string CallbackQueue { get; set; } = "fireforget.callbacks";
        public string DeadQueue { get; set; } = "fireforget.callbacks.dead";
        public ushort Prefetch { get; set; } = 10;
    }

    public class WorkerOptions
    {
        /// <summary>How many times a callback is retried (row not inserted yet, DB down...) before going to the dead queue.</summary>
        public int MaxRetries { get; set; } = 6;
        public int RetryBaseSeconds { get; set; } = 5;

        public bool TimeoutEnabled { get; set; } = true;
        /// <summary>IN PROGRESS jobs older than this are marked FAILED. A late callback can still turn them READY.</summary>
        public int TimeoutMinutes { get; set; } = 60;
        public int SweepEveryMinutes { get; set; } = 5;
    }

    public class RouteOptions
    {
        /// <summary>
        /// Server key (the first part of the ProcessId) to the connection string of that server's ADMIN database
        /// (the one holding DATABASE_DETAILS and ADMIN_PREMIUM_SERVICES).
        /// </summary>
        public Dictionary<string, string> Servers { get; set; } = new();
        public int CacheMinutes { get; set; } = 5;
    }
}
