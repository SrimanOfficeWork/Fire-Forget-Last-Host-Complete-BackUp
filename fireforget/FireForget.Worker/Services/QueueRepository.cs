using System.Data;
using Microsoft.Data.SqlClient;

namespace FireForget.Worker.Services
{
    public enum SaveOutcome
    {
        Saved,
        NotFound,
        DuplicateIgnored
    }

    /// <summary>
    /// Talks to PDF_AI_QUEUE through the EXISTING stored procedure PDF_AI_QUEUE_INSERT_UPDATE_SELECT:
    /// GET_BY_PROCESS_ID and UPDATE_STATUS are existing flags; DOCKER_VISION_TIMEOUT is the one new flag.
    /// </summary>
    public sealed class QueueRepository
    {
        private const string Proc = "dbo.PDF_AI_QUEUE_INSERT_UPDATE_SELECT";
        private const string TimeoutMarker = "\"Source\":\"Timeout\"";

        public async Task<SaveOutcome> SaveResponseAsync(CompanyTarget target, string processId, string status,
            string payload, CancellationToken ct)
        {
            await using var conn = new SqlConnection(target.ConnectionString);
            await conn.OpenAsync(ct);

            // 1) Does the row exist, and did we already store a real response?
            string? currentStatus = null;
            string? currentJson = null;
            bool found;
            await using (var get = NewCommand(conn, "GET_BY_PROCESS_ID"))
            {
                get.Parameters.AddWithValue("@PROCESS_ID", processId);
                await using var rd = await get.ExecuteReaderAsync(ct);
                found = await rd.ReadAsync(ct);
                if (found)
                {
                    currentStatus = rd["STATUS"] as string;
                    currentJson = rd["JSON_RESPONSE"] as string;
                }
            }

            if (!found) return SaveOutcome.NotFound;

            var hasRealResponse = !string.IsNullOrWhiteSpace(currentJson)
                                  && !currentJson.Replace(" ", "").Contains(TimeoutMarker);
            if (hasRealResponse && (currentStatus == "READY" || currentStatus == "FAILED"))
                return SaveOutcome.DuplicateIgnored;

            // The procedure ignores an empty JSON, so a failure with no body still stores something readable
            if (string.IsNullOrWhiteSpace(payload))
                payload = "{\"Status\":\"Failed\",\"Reason\":\"Empty response body received from the vendor\"}";

            // 2) Store status + JSON (a row the timeout marked FAILED is overwritten by a late real response)
            await using var upd = NewCommand(conn, "UPDATE_STATUS");
            upd.Parameters.AddWithValue("@PROCESS_ID", processId);
            upd.Parameters.AddWithValue("@STATUS", status);
            upd.Parameters.Add(new SqlParameter("@JSON_RESPONSE", SqlDbType.NVarChar, -1) { Value = payload });
            await upd.ExecuteNonQueryAsync(ct);
            EnsureSuccess(upd);
            return SaveOutcome.Saved;
        }

        /// <summary>Marks Docker Vision jobs that are still IN PROGRESS after the given minutes as FAILED.</summary>
        public async Task<int> TimeoutStaleAsync(CompanyTarget target, int minutes, CancellationToken ct)
        {
            await using var conn = new SqlConnection(target.ConnectionString);
            await conn.OpenAsync(ct);
            await using var cmd = NewCommand(conn, "DOCKER_VISION_TIMEOUT");
            cmd.Parameters.AddWithValue("@TIMEOUT_MINUTES", minutes);
            var total = new SqlParameter("@totalRows", SqlDbType.Int) { Direction = ParameterDirection.Output };
            cmd.Parameters.Add(total);
            await cmd.ExecuteNonQueryAsync(ct);
            EnsureSuccess(cmd);
            return total.Value is int n ? n : 0;
        }

        private static SqlCommand NewCommand(SqlConnection conn, string flag)
        {
            var cmd = new SqlCommand(Proc, conn) { CommandType = CommandType.StoredProcedure, CommandTimeout = 60 };
            cmd.Parameters.AddWithValue("@MFLAG", flag);
            cmd.Parameters.Add(new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000) { Direction = ParameterDirection.Output });
            return cmd;
        }

        private static void EnsureSuccess(SqlCommand cmd)
        {
            var msg = cmd.Parameters["@ErrorMsg"].Value as string;
            if (!string.IsNullOrEmpty(msg) && msg != "SUCCESS")
                throw new InvalidOperationException("PDF_AI_QUEUE procedure reported: " + msg);
        }
    }
}
