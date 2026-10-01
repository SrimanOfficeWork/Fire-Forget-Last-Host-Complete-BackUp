// ============================================================
// SsoLaunch.cs
//
// Builds the launch URL for the "AI extraction" menu item (OCR menu) that
// opens eRoyal InvoiceAI in a new browser tab, silently signed in as the
// currently logged-in Impex user, in their currently active branch.
//
// Every value is read fresh at click time via the existing Connection.*
// session helpers, so a user working under a different branch than usual,
// or a different user under the same ERI ID, always gets their OWN correct
// branch/working period/company on the token -- nothing is cached or
// assumed from a prior click.
//
// Counterpart on the eRoyal InvoiceAI side:
//   InvoiceExtraction.Infrastructure/Services/SsoTokenService.cs (same
//   AES-256-CBC + HMAC-SHA256 encrypt-then-MAC scheme)
//   InvoiceExtraction.API/Controllers/AuthController.cs -- POST /api/auth/sso
//
// Config (web.config <appSettings>):
//   AiExtraction_SsoSharedSecret -- must match Sso:SharedSecret on the
//     eRoyal InvoiceAI side exactly. Coordinate the real value with that
//     team out of band -- do not commit it to source control as-is.
//   AiExtraction_LaunchUrl -- e.g. https://invoiceai.eroyal.co.in/sso
//   AiExtraction_ServerName -- ask the eRoyal InvoiceAI team for the exact
//     value; it must be either the Key of this deployment's entry in their
//     own AdminServers config, or any substring unique to that entry's
//     ConnectionString (e.g. the bare server IP/host). Required -- do not
//     rely on "con" being parseable; confirmed broken on at least one live
//     site (2026-07-30).
//
// IMPORTANT -- CompanyCode/EriId mapping: eRoyal InvoiceAI resolves which
// client a login belongs to by looking up AI_Extraction_Companies.CompanyCode
// against the CompanyCode this class sends (Connection.Company_License(),
// e.g. "ERI00247" -- the same value this codebase already branches on in
// Billing/GST_Billing_Paramount.cs etc). For SSO to work for a given client,
// that client must already have an AI_Extraction_Companies row on the
// eRoyal InvoiceAI side whose CompanyCode is set to their real ERI ID --
// this is a one-time onboarding step per client, not automatic.//openAiExtraction process ei 
// ============================================================

using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

public static class SsoLaunch
{
    // Reads a session value without the NullReferenceException that
    // Connection.cs's equivalent helpers throw (e.g. Company_License(),
    // Current_Branch()) when the key isn't populated yet -- they all do a
    // raw HttpContext.Current.Session["x"].ToString() with no null check,
    // and that raw NRE is what was reaching the "AI extraction" click as
    // "Object reference not set to an instance of an object."
    private static string SafeSession(string key)
    {
        var val = HttpContext.Current.Session[key];
        return val == null ? null : val.ToString();
    }

    // Builds the full "{LaunchUrl}?token=..." redirect target for the
    // currently logged-in Impex session/branch. Call from the menu item's
    // server-side click handler, then open it via
    // ClientScript.RegisterStartupScript(... "window.open(url,'_blank');" ...).
    public static string BuildLaunchUrl()
    {
        var companyLicense = SafeSession("COMPANY_LICENSE");
        var currentUser = SafeSession("currentuser");
        // Default.aspx.cs stashes the plaintext password here right after a
        // successful login (Session["currentpassword"] = txtPassword.Text.Trim())
        // -- read fresh at click time, same as everything else here.
        var currentPassword = SafeSession("currentpassword");
        var currentBranch = SafeSession("currentbranch");
        var workingPeriod = SafeSession("WorkingPeriod");

        var missing = new System.Collections.Generic.List<string>();
        if (string.IsNullOrEmpty(companyLicense)) missing.Add("company");
        if (string.IsNullOrEmpty(currentUser)) missing.Add("user");
        if (string.IsNullOrEmpty(currentPassword)) missing.Add("password");
        if (string.IsNullOrEmpty(currentBranch)) missing.Add("branch");
        if (string.IsNullOrEmpty(workingPeriod)) missing.Add("working period");
        if (missing.Count > 0)
            throw new InvalidOperationException(
                "Could not determine your current " + string.Join(", ", missing) +
                " -- please select a company/branch and try again.");

        // This deployment's own admin DB server -- eRoyal InvoiceAI matches
        // this directly against its own configured admin servers instead of
        // broadcasting to all of them. Prefer the explicit, single-purpose
        // AiExtraction_ServerName appSetting over parsing "con" -- confirmed
        // live on invoiceaiservice.eroyalimpex.co.in (2026-07-30) that
        // ExtractServerHost(con) can come back empty on some deployments
        // (that site's "con" value didn't contain a "Server="/"Data Source="
        // segment this parser recognized), which silently broke SSO with no
        // way to fix it from eRoyal InvoiceAI's side. Falls back to parsing
        // "con" only for older deployments that haven't added the new
        // setting yet.
        var adminServerHost = ConfigurationManager.AppSettings["AiExtraction_ServerName"];
        if (string.IsNullOrEmpty(adminServerHost))
            adminServerHost = ExtractServerHost(ConfigurationManager.AppSettings["con"]);

        var payload = new
        {
            ServerName = adminServerHost,
            EriId = companyLicense, // ERI ID and CompanyCode are the same value in this system
            Username = currentUser,
            Password = currentPassword,
            Branch = currentBranch,
            WorkingPeriod = workingPeriod,
            IssuedAtUnix = ToUnixSeconds(DateTime.UtcNow),
        };

        var json = new JavaScriptSerializer().Serialize(payload);
        var token = Encrypt(json);

        var launchUrl = ConfigurationManager.AppSettings["AiExtraction_LaunchUrl"];
        if (launchUrl == null)
            throw new InvalidOperationException("AiExtraction_LaunchUrl not configured");

        return launchUrl + "?token=" + HttpUtility.UrlEncode(token);
    }

    // Pulls the "Server=X" (or "Data Source=X") segment out of an ADO.NET
    // connection string, e.g. "Server=103.171.180.25;database=ImpexLogin;
    // uid=sa;pwd=SA,123;" -> "103.171.180.25".
    private static string ExtractServerHost(string connectionString)
    {
        if (string.IsNullOrEmpty(connectionString)) return "";
        foreach (var part in connectionString.Split(';'))
        {
            var kv = part.Split(new[] { '=' }, 2);
            if (kv.Length == 2)
            {
                var key = kv[0].Trim();
                if (string.Equals(key, "Server", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(key, "Data Source", StringComparison.OrdinalIgnoreCase))
                    return kv[1].Trim();
            }
        }
        return "";
    }

    // ── AES-256-CBC encrypt-then-HMAC-SHA256, matching
    // InvoiceExtraction.Infrastructure/Services/SsoTokenService.cs exactly ──
    private static string Encrypt(string json)
    {
        var key = GetKey();
        var plainBytes = Encoding.UTF8.GetBytes(json);

        byte[] iv, cipherBytes;
        using (var aes = Aes.Create())
        {
            aes.Key = key;
            aes.GenerateIV();
            iv = aes.IV;
            using (var encryptor = aes.CreateEncryptor())
                cipherBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
        }

        var ivAndCipher = new byte[iv.Length + cipherBytes.Length];
        Buffer.BlockCopy(iv, 0, ivAndCipher, 0, iv.Length);
        Buffer.BlockCopy(cipherBytes, 0, ivAndCipher, iv.Length, cipherBytes.Length);

        byte[] mac;
        using (var hmac = new HMACSHA256(key))
            mac = hmac.ComputeHash(ivAndCipher);

        var full = new byte[ivAndCipher.Length + mac.Length];
        Buffer.BlockCopy(ivAndCipher, 0, full, 0, ivAndCipher.Length);
        Buffer.BlockCopy(mac, 0, full, ivAndCipher.Length, mac.Length);

        return Base64UrlEncode(full);
    }

    private static byte[] GetKey()
    {
        var secret = ConfigurationManager.AppSettings["AiExtraction_SsoSharedSecret"];
        if (secret == null)
            throw new InvalidOperationException("AiExtraction_SsoSharedSecret not configured");

        using (var sha256 = SHA256.Create())
            return sha256.ComputeHash(Encoding.UTF8.GetBytes(secret));
    }

    private static long ToUnixSeconds(DateTime utc)
    {
        return (long)(utc - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
    }

    private static string Base64UrlEncode(byte[] data)
    {
        return Convert.ToBase64String(data).TrimEnd('=').Replace('+', '-').Replace('/', '_');
    }
}