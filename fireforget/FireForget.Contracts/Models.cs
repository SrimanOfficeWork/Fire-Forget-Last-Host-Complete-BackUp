using System.Text.Json;

namespace FireForget.Contracts
{
    public static class CallbackStatus
    {
        public const string InProgress = "IN PROGRESS";
        public const string Ready = "READY";
        public const string Failed = "FAILED";
    }

    /// <summary>Message put on RabbitMQ by the callback API and consumed by the worker.</summary>
    public record CallbackMessage
    {
        /// <summary>Vendor taken from the callback URL, e.g. docker-vision.</summary>
        public string Vendor { get; init; } = string.Empty;
        public string ProcessId { get; init; } = string.Empty;
        public string EriId { get; init; } = string.Empty;
        public string? JobType { get; init; }
        public string? PdfClientName { get; init; }
        /// <summary>Optional status the vendor may send in a header (e.g. "Success" / "Failed").</summary>
        public string? StatusHint { get; init; }
        /// <summary>Raw body exactly as the vendor posted it. Some vendors keep nothing, so this is the only copy.</summary>
        public string Payload { get; init; } = string.Empty;
        public DateTime ReceivedUtc { get; init; } = DateTime.UtcNow;
    }

    /// <summary>Decides READY / FAILED from what the vendor posted.</summary>
    public static class CallbackClassifier
    {
        public static (string Status, string? Reason) Classify(string? statusHint, string? payload)
        {
            if (LooksFailed(statusHint))
                return (CallbackStatus.Failed, "Status header reported: " + statusHint);

            if (string.IsNullOrWhiteSpace(payload))
                return (CallbackStatus.Failed, "Empty response body");

            try
            {
                using var doc = JsonDocument.Parse(payload);
                var root = doc.RootElement;

                // Array of invoices: look at the first element
                if (root.ValueKind == JsonValueKind.Array)
                {
                    if (root.GetArrayLength() == 0) return (CallbackStatus.Failed, "Empty JSON array");
                    root = root[0];
                }

                if (root.ValueKind != JsonValueKind.Object)
                    return (CallbackStatus.Failed, "Response is not a JSON object");

                var top = ReadStatus(root);
                if (LooksFailed(top)) return (CallbackStatus.Failed, "Response Status: " + top);

                if (TryGetProperty(root, "Header", out var header))
                {
                    var h = header.ValueKind == JsonValueKind.Array && header.GetArrayLength() > 0 ? header[0] : header;
                    if (h.ValueKind == JsonValueKind.Object)
                    {
                        var hs = ReadStatus(h);
                        if (LooksFailed(hs)) return (CallbackStatus.Failed, "Header Status: " + hs);
                    }
                }

                return (CallbackStatus.Ready, null);
            }
            catch (JsonException ex)
            {
                return (CallbackStatus.Failed, "Invalid JSON: " + ex.Message);
            }
        }

        private static string? ReadStatus(JsonElement obj)
            => TryGetProperty(obj, "Status", out var s) && s.ValueKind == JsonValueKind.String ? s.GetString() : null;

        private static bool TryGetProperty(JsonElement obj, string name, out JsonElement value)
        {
            foreach (var p in obj.EnumerateObject())
            {
                if (string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase))
                {
                    value = p.Value;
                    return true;
                }
            }
            value = default;
            return false;
        }

        private static bool LooksFailed(string? s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;
            s = s.Trim().ToLowerInvariant();
            return s.Contains("fail") || s.Contains("error");
        }
    }
}
