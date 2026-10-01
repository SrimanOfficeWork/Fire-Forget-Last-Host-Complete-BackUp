using System.Text.RegularExpressions;

namespace FireForget.Contracts
{
    public record ProcessIdParts(string Server, string EriId, string WorkingPeriod, string Token);

    /// <summary>
    /// The process id carries its own routing: "server~eriId~workingPeriod~token".
    ///  - server        : key of the server list in the worker config (which admin database to ask)
    ///  - eriId         : company license (ERI ID)
    ///  - workingPeriod : working period with spaces removed, e.g. 01-Apr-2025-31-Mar-2026
    ///  - token         : random part so the id is unique
    /// The vendor only has to send the process id back; the worker can then find the right company database.
    /// The legacy .NET 4.0 pages must build the id with exactly the same format.
    /// </summary>
    public static class ProcessIdCodec
    {
        public const char Separator = '~';
        private static readonly Regex ServerPattern = new(@"^[A-Za-z0-9_.\-]+$", RegexOptions.Compiled);

        public static string Create(string server, string eriId, string workingPeriod)
        {
            var srv = (server ?? "").Trim();
            var eri = (eriId ?? "").Trim();
            var wp = Compact(workingPeriod);

            if (!ServerPattern.IsMatch(srv)) throw new ArgumentException("Invalid server name", nameof(server));
            if (eri.Length == 0 || eri.Contains(Separator)) throw new ArgumentException("Invalid ERI ID", nameof(eriId));
            if (wp.Length == 0 || wp.Contains(Separator)) throw new ArgumentException("Invalid working period", nameof(workingPeriod));

            return string.Join(Separator, srv, eri, wp, Guid.NewGuid().ToString("N"));
        }

        public static bool TryParse(string? processId, out ProcessIdParts? parts)
        {
            parts = null;
            if (string.IsNullOrWhiteSpace(processId)) return false;

            var p = processId.Trim().Split(Separator);
            if (p.Length != 4 || p.Any(string.IsNullOrWhiteSpace)) return false;
            if (!ServerPattern.IsMatch(p[0])) return false;

            parts = new ProcessIdParts(p[0], p[1], p[2], p[3]);
            return true;
        }

        /// <summary>Removes all whitespace so "01-Apr-2025 - 31-Mar-2026" and "01-Apr-2025-31-Mar-2026" compare equal.</summary>
        public static string Compact(string? workingPeriod)
            => Regex.Replace(workingPeriod ?? "", @"\s+", "");
    }
}
