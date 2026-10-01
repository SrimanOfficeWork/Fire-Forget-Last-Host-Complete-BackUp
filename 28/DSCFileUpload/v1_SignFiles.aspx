<%@ Page Language="C#" %>
<%@ Import Namespace="System.Configuration" %>
<%@ Import Namespace="System.Security.Cryptography" %>
<%@ Import Namespace="System.Text" %>
<script runat="server">
    // ==== Configuration ====================================================
    // Works immediately with these defaults -- no Web.config changes required to copy
    // this one file in and try it. If you'd rather not edit this file again later, these
    // same keys can be set in the ERP's Web.config <appSettings> instead and will
    // override the defaults below automatically.
    //
    // IcegateJwtSecret must exactly match Api:JwtSecret in Icegate.Agent's own
    // appsettings.json -- these two have to be kept in sync manually.
    private const string DefaultAgentBaseUrl = "http://127.0.0.1:9095";
    private const string DefaultInstallUrl = "https://dscapp.eroyalimpex.co.in/Icegate.Agent.UI.application";
    private const string DefaultJwtSecret = "E0g6ya670OG-BEf26gt-vz3XHpUQnfsTCRMmDO6mP6QO48c2C-FHWEl8t31nZcmJ";
    private const string DefaultJwtIssuer = "eroyalimpex-erp";
    private const string DefaultJwtAudience = "icegate-agent";
    private const int DefaultJwtValidityMinutes = 15;

    protected string AgentBaseUrl;
    protected string InstallUrl;
    protected string BearerToken;

    protected void Page_Load(object sender, EventArgs e)
    {
        AgentBaseUrl = ConfigurationManager.AppSettings["IcegateAgentBaseUrl"];
        if (string.IsNullOrEmpty(AgentBaseUrl))
        {
            AgentBaseUrl = DefaultAgentBaseUrl;
        }

        InstallUrl = ConfigurationManager.AppSettings["IcegateInstallUrl"];
        if (string.IsNullOrEmpty(InstallUrl))
        {
            InstallUrl = DefaultInstallUrl;
        }

        string secret = ConfigurationManager.AppSettings["IcegateJwtSecret"];
        if (string.IsNullOrEmpty(secret))
        {
            secret = DefaultJwtSecret;
        }

        string issuer = ConfigurationManager.AppSettings["IcegateJwtIssuer"];
        if (string.IsNullOrEmpty(issuer))
        {
            issuer = DefaultJwtIssuer;
        }

        string audience = ConfigurationManager.AppSettings["IcegateJwtAudience"];
        if (string.IsNullOrEmpty(audience))
        {
            audience = DefaultJwtAudience;
        }

        int validityMinutes = DefaultJwtValidityMinutes;
        string validityRaw = ConfigurationManager.AppSettings["IcegateJwtValidityMinutes"];
        int parsedValidity;
        if (!string.IsNullOrEmpty(validityRaw) && int.TryParse(validityRaw, out parsedValidity) && parsedValidity > 0)
        {
            validityMinutes = parsedValidity;
        }

        BearerToken = GenerateJwt(secret, issuer, audience, TimeSpan.FromMinutes(validityMinutes));
    }

    // ==== Hand-rolled HS256 JWT =============================================
    // Same algorithm already independently verified via a Python round-trip earlier in
    // this build (base64url header/payload, HMACSHA256 signature over "header.payload").
    // No NuGet dependency by design -- this build has repeatedly hit real problems
    // guessing at NuGet package versions with no way to verify them from the environment
    // this was written in, and HS256 is simple enough not to need a library.
    private static string GenerateJwt(string secret, string issuer, string audience, TimeSpan validFor)
    {
        string header = "{\"alg\":\"HS256\",\"typ\":\"JWT\"}";

        long exp = ToUnixTimeSeconds(DateTime.UtcNow.Add(validFor));
        string payload = string.Format(
            "{{\"iss\":\"{0}\",\"aud\":\"{1}\",\"exp\":{2}}}",
            EscapeJsonString(issuer), EscapeJsonString(audience), exp);

        string headerEncoded = Base64UrlEncode(Encoding.UTF8.GetBytes(header));
        string payloadEncoded = Base64UrlEncode(Encoding.UTF8.GetBytes(payload));
        string signingInput = headerEncoded + "." + payloadEncoded;

        byte[] signatureBytes;
        using (HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret)))
        {
            signatureBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(signingInput));
        }
        string signatureEncoded = Base64UrlEncode(signatureBytes);

        return signingInput + "." + signatureEncoded;
    }

    private static string Base64UrlEncode(byte[] input)
    {
        string base64 = Convert.ToBase64String(input);
        return base64.Replace('+', '-').Replace('/', '_').TrimEnd('=');
    }

    // DateTimeOffset.ToUnixTimeSeconds() was only added in .NET Framework 4.6 -- computed
    // manually here since this targets .NET Framework 4.0.
    private static long ToUnixTimeSeconds(DateTime utcDateTime)
    {
        DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        return (long)(utcDateTime - epoch).TotalSeconds;
    }

    private static string EscapeJsonString(string value)
    {
        if (value == null)
        {
            return string.Empty;
        }
        return value.Replace("\\", "\\\\").Replace("\"", "\\\"");
    }
</script>
<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="UTF-8">
<title>Simulated ERP — Sign Files</title>
<style>
  body {
    font-family: Arial, Tahoma, "Segoe UI", sans-serif;
    font-size: 12px;
    color: #333333;
    background: #ffffff;
    margin: 12px;
  }
  h1 {
    font-size: 16px;
    font-weight: bold;
    color: #333333;
    margin: 0 0 12px;
    padding-bottom: 6px;
    border-bottom: 2px solid #dddddd;
  }
  label {
    display: block;
    font-size: 12px;
    font-weight: bold;
    color: #444444;
    margin: 10px 0 3px;
  }
  input[type=text], select {
    width: 100%;
    padding: 4px 6px;
    box-sizing: border-box;
    font-family: Arial, Tahoma, sans-serif;
    font-size: 12px;
    border: 1px solid #cccccc;
    background: #ffffff;
  }
  input[type=file] {
    display: block;
    margin-top: 4px;
    font-size: 12px;
  }
  button {
    margin-top: 10px;
    padding: 5px 14px;
    font-size: 12px;
    cursor: pointer;
    background: #f5f5f5;
    color: #333333;
    border: 1px solid #adadad;
    border-radius: 3px;
  }
  button:hover:not(:disabled) { background: #e6e6e6; }
  button:disabled { background: #f5f5f5; color: #aaaaaa; cursor: default; }
  button.primary { background: #dbe9f7; border-color: #94b8dd; font-weight: bold; }
  button.primary:hover:not(:disabled) { background: #c9defa; }
  button.small { padding: 3px 8px; font-size: 11px; margin: 0; }
  #fileList { margin-top: 8px; border: 1px solid #dddddd; display: none; }
  #fileList .row { display: flex; align-items: center; justify-content: space-between; padding: 5px 8px; font-size: 12px; border-bottom: 1px solid #eeeeee; background: #ffffff; }
  #fileList .row:nth-child(even) { background: #fdf6e6; }
  #fileList .row:last-child { border-bottom: none; }
  #fileList .fname { overflow: hidden; text-overflow: ellipsis; white-space: nowrap; margin-right: 10px; }
  #fileList .fsize { color: #777777; font-size: 11px; margin-right: 10px; white-space: nowrap; }
  #fileList .remove { background: none; border: none; color: #c62828; font-size: 15px; cursor: pointer; padding: 0 4px; margin: 0; }
  #fileCount { font-size: 12px; color: #555555; margin-top: 6px; }
  .actionsRow { display: flex; gap: 8px; align-items: center; }
  .certRow { display: flex; gap: 8px; align-items: flex-start; margin-top: 3px; }
  .certRow select { flex: 1; }
  #certStatus { font-size: 11px; color: #777777; margin-top: 3px; }
  table { width: 100%; border-collapse: collapse; margin-top: 16px; font-size: 12px; border: 1px solid #dddddd; }
  th { text-align: left; padding: 6px 8px; background: #f0f0f0; color: #333333; font-weight: bold; border: 1px solid #dddddd; }
  td { text-align: left; padding: 5px 8px; border: 1px solid #dddddd; }
  tbody tr:nth-child(even) { background: #fdf6e6; }
  .ok { color: #1e7e34; font-weight: bold; }
  .fail { color: #c62828; font-weight: bold; }
  .warn { color: #b26a00; }
  #status { margin-top: 14px; font-size: 12px; white-space: pre-wrap; }
  #rawError { margin-top: 6px; font-size: 11px; color: #c62828; white-space: pre-wrap; }
</style>
</head>
<body>

<h1>Sign Files</h1>

<input type="hidden" id="baseUrl" value="<%= AgentBaseUrl %>">
<input type="hidden" id="installUrl" value="<%= InstallUrl %>">
<input type="hidden" id="token" value="<%= BearerToken %>">

<label for="fileInput">Files to sign (choose one or more — you can click "Choose Files" again to add more)</label>
<input type="file" id="fileInput" multiple accept=".sb,.be,.txt,.json,.pdf">

<div id="fileList"></div>
<div id="fileCount"></div>

<label for="certSelect">Signing certificate</label>
<div class="certRow">
  <select id="certSelect">
    <option value="">Auto (server default / config)</option>
  </select>
  <button id="refreshCertsButton" class="small" style="margin-top:0">Refresh</button>
</div>
<div id="certStatus"></div>

<div class="actionsRow">
  <button id="signButton" class="primary" disabled>Sign Files</button>
  <button id="clearButton" style="display:none">Clear all</button>
</div>

<div id="status"></div>
<div id="rawError"></div>
<table id="resultsTable" style="display:none">
  <thead>
    <tr><th>File</th><th>Signed</th><th>Message</th><th>ERP Callback</th></tr>
  </thead>
  <tbody id="resultsBody"></tbody>
</table>

<script>
const fileInput = document.getElementById('fileInput');
const certSelect = document.getElementById('certSelect');
const refreshCertsButton = document.getElementById('refreshCertsButton');
const certStatus = document.getElementById('certStatus');
const fileListEl = document.getElementById('fileList');
const fileCountEl = document.getElementById('fileCount');
const signButton = document.getElementById('signButton');
const clearButton = document.getElementById('clearButton');
const statusEl = document.getElementById('status');
const rawErrorEl = document.getElementById('rawError');
const resultsTable = document.getElementById('resultsTable');
const resultsBody = document.getElementById('resultsBody');

// Native FileList objects are read-only, so a mutable array is the only way to support
// removing a single file after it's been picked, or accumulating files across multiple
// "Choose Files" clicks instead of each pick replacing the last.
let selectedFiles = [];

fileInput.addEventListener('change', () => {
  for (const file of fileInput.files) {
    const alreadyAdded = selectedFiles.some(f => f.name === file.name && f.size === file.size);
    if (!alreadyAdded) {
      selectedFiles.push(file);
    }
  }
  fileInput.value = ''; // reset so picking the exact same file again still fires 'change'
  renderFileList();
});

clearButton.addEventListener('click', () => {
  selectedFiles = [];
  renderFileList();
});

function renderFileList() {
  fileListEl.innerHTML = '';

  if (selectedFiles.length === 0) {
    fileListEl.style.display = 'none';
    fileCountEl.textContent = 'No files selected yet.';
    signButton.disabled = true;
    clearButton.style.display = 'none';
    return;
  }

  fileListEl.style.display = 'block';
  clearButton.style.display = 'inline-block';
  signButton.disabled = false;

  selectedFiles.forEach((file, index) => {
    const row = document.createElement('div');
    row.className = 'row';
    row.innerHTML = `
      <span class="fname">${escapeHtml(file.name)}</span>
      <span class="fsize">${formatSize(file.size)}</span>
      <button class="remove" data-index="${index}" title="Remove this file">&times;</button>
    `;
    fileListEl.appendChild(row);
  });

  fileListEl.querySelectorAll('.remove').forEach(btn => {
    btn.addEventListener('click', () => {
      const idx = parseInt(btn.getAttribute('data-index'), 10);
      selectedFiles.splice(idx, 1);
      renderFileList();
    });
  });

  const totalBytes = selectedFiles.reduce((sum, f) => sum + f.size, 0);
  fileCountEl.textContent = `${selectedFiles.length} file(s) selected, ${formatSize(totalBytes)} total.`;
}

function formatSize(bytes) {
  if (bytes < 1024) return `${bytes} B`;
  if (bytes < 1024 * 1024) return `${(bytes / 1024).toFixed(1)} KB`;
  return `${(bytes / (1024 * 1024)).toFixed(1)} MB`;
}

renderFileList(); // initial empty state

async function loadCertificates() {
  const baseUrl = document.getElementById('baseUrl').value.trim();
  const token = document.getElementById('token').value.trim();

  certStatus.textContent = 'Loading certificates...';
  refreshCertsButton.disabled = true;

  try {
    const response = await fetch(`${baseUrl}/api/certificates`, {
      headers: { 'Authorization': `Bearer ${token}` }
    });

    if (!response.ok) {
      certStatus.textContent = `Could not load certificates (HTTP ${response.status}). "Auto" will still work if exactly one cert is available on the Agent's machine.`;
      return;
    }

    const data = await response.json();

    // Keep the current selection if it's still in the refreshed list.
    const previousValue = certSelect.value;
    certSelect.innerHTML = '<option value="">Auto (server default / config)</option>';

    // Show valid certificates, plus ones expired within the last 7 days (marked clearly
    // so nobody picks an expired one without realizing) -- anything expired longer than
    // that is hidden. The Agent's /api/certificates returns every certificate regardless
    // of expiry now; this page decides what's actually worth showing.
    const sevenDaysAgo = new Date();
    sevenDaysAgo.setDate(sevenDaysAgo.getDate() - 7);

    for (const c of data.certificates) {
      const notAfter = new Date(c.notAfter);
      if (notAfter < sevenDaysAgo) {
        continue;
      }

      const option = document.createElement('option');
      option.value = c.thumbprint;
      const expiry = notAfter.toISOString().substring(0, 10);
      const isExpired = notAfter < new Date();
      option.textContent = extractCommonName(c.subject) + ' (expires ' + expiry + ')' + (isExpired ? ' [EXPIRED]' : '');
      certSelect.appendChild(option);
    }

    // Count actually-displayed certificates, not the raw API response, which also
    // includes certificates expired more than 7 days ago that were filtered out above.
    // "Auto" itself doesn't count as a real certificate choice.
    const displayedCount = certSelect.options.length - 1;

    if (displayedCount === 1) {
      // Exactly one certificate found: nothing for the operator to actually choose, so
      // don't make them choose it. Rebuild the dropdown down to just that one option,
      // select it, and lock it -- explicitly naming the certificate in the submitted
      // request (rather than leaving it on "Auto" and relying on the Agent's own
      // auto-select-if-exactly-one fallback) so client and server agree on exactly which
      // certificate is being used, not just implicitly.
      const theOnlyOption = certSelect.options[1];
      certSelect.innerHTML = '';
      certSelect.appendChild(theOnlyOption);
      certSelect.value = theOnlyOption.value;
      certSelect.disabled = true;
      certStatus.textContent = 'Using certificate: ' + theOnlyOption.textContent + ' (only one available).';
    } else if (displayedCount > 1) {
      // Genuine ambiguity -- more than one certificate (e.g. more than one DSC dongle
      // present), so the operator has to actually pick. Keep "Auto" plus every option,
      // enabled, and preserve whatever was previously selected if it's still valid.
      certSelect.disabled = false;
      if ([...certSelect.options].some(o => o.value === previousValue)) {
        certSelect.value = previousValue;
      }
      certStatus.textContent = `${displayedCount} certificate(s) available.`;
    } else {
      certSelect.disabled = false;
      certStatus.textContent = 'No certificates found -- is the DSC token plugged in and unlocked?';
    }
  } catch (err) {
    certStatus.textContent = `Could not reach the Agent to list certificates (${err.message}). "Auto" will still work if the Agent can resolve one on its own.`;
  } finally {
    refreshCertsButton.disabled = false;
  }
}

refreshCertsButton.addEventListener('click', loadCertificates);

// Runs once on page load, before loadCertificates(). In the common case (Agent already
// running, which GET /api/health confirms almost instantly) this adds a negligible delay
// and then calls loadCertificates() exactly as before -- nothing about that function
// itself changes. It only does extra work in the less common case where the Agent isn't
// responding yet.
async function ensureAgentAvailable() {
  const baseUrl = document.getElementById('baseUrl').value.trim();
  const installUrl = document.getElementById('installUrl').value.trim();

  async function isAgentHealthy() {
    try {
      const response = await fetch(`${baseUrl}/api/health`, { cache: 'no-store' });
      return response.ok;
    } catch (err) {
      return false;
    }
  }

  if (await isAgentHealthy()) {
    loadCertificates();
    return;
  }

  certStatus.textContent = 'Icegate Agent is not responding -- attempting to reconnect...';

  // Not responding -- attempt to relaunch an already-installed-but-not-running Agent via
  // its icegate:// protocol handler. If the Agent has never been installed at all, nothing
  // is registered for this scheme and this does nothing observable; there is no reliable
  // cross-browser way to detect "protocol not registered" from script, so this
  // deliberately does not try to distinguish that case up front -- the same timeout-then-
  // retry below correctly handles both outcomes either way.
  try {
    window.location.href = 'icegate://launch';
  } catch (err) {
    // Some browsers throw synchronously for an unrecognized scheme -- ignored
    // deliberately, since the retry below is what actually determines the outcome.
  }

  setTimeout(async () => {
    if (await isAgentHealthy()) {
      loadCertificates();
    } else {
      certStatus.textContent = '';
      certSelect.innerHTML = '<option value="">Auto (server default / config)</option>';
      certSelect.disabled = false;
      statusEl.innerHTML =
        'Icegate Agent is not running. <a href="' + installUrl + '" target="_blank" rel="noopener">' +
        'Click here to install it</a>, then reload this page.';
    }
  }, 2000);
}

ensureAgentAvailable(); // attempt on page load, using the pre-filled base URL / token

signButton.addEventListener('click', async () => {
  const baseUrl = document.getElementById('baseUrl').value.trim();
  const token = document.getElementById('token').value.trim();

  statusEl.textContent = '';
  rawErrorEl.textContent = '';
  resultsTable.style.display = 'none';
  resultsBody.innerHTML = '';

  if (selectedFiles.length === 0) {
    statusEl.textContent = 'Select at least one file first.';
    return;
  }

  const formData = new FormData();
  for (const file of selectedFiles) {
    formData.append('files', file, file.name);
  }
  if (certSelect.value) {
    formData.append('certificateThumbprint', certSelect.value);
  }

  signButton.disabled = true;
  statusEl.textContent = `Sending ${selectedFiles.length} file(s) to ${baseUrl}/api/sign ... (this page's own origin is ${window.location.origin} -- make sure that's in the Agent's Api:AllowedOrigins)`;

  try {
    const response = await fetch(`${baseUrl}/api/sign`, {
      method: 'POST',
      headers: {
        'Authorization': `Bearer ${token}`
      },
      body: formData
    });

    if (!response.ok) {
      const text = await response.text();
      statusEl.textContent = `Request failed: HTTP ${response.status}`;
      rawErrorEl.textContent = text;
      return;
    }

    const data = await response.json();
    statusEl.textContent = `Done. ${data.results.length} result(s):`;

    resultsTable.style.display = 'table';
    for (const r of data.results) {
      const row = document.createElement('tr');

      const signedClass = r.success ? 'ok' : 'fail';
      const signedText = r.success ? 'Yes' : 'No';

      let callbackText = '—';
      let callbackClass = '';
      if (r.success) {
        callbackText = r.callbackDelivered ? 'Delivered' : `Failed (saved to fallback)`;
        callbackClass = r.callbackDelivered ? 'ok' : 'warn';
      }

      row.innerHTML = `
        <td>${escapeHtml(r.originalFileName)}</td>
        <td class="${signedClass}">${signedText}</td>
        <td>${escapeHtml(r.message || '')}</td>
        <td class="${callbackClass}">${callbackText}</td>
      `;
      resultsBody.appendChild(row);
    }

    // Clear the selection after a successful submission -- signed files shouldn't
    // linger in the picker as if they're still waiting to be sent.
    selectedFiles = [];
    renderFileList();
  } catch (err) {
    statusEl.textContent = `Request failed before getting a response (page origin: ${window.location.origin}). This usually means CORS blocked it, or the Agent isn't running.`;
    rawErrorEl.textContent = `${err.name}: ${err.message}\n\nOpen the browser DevTools Console (F12) for the actual CORS error -- browsers hide the real reason from JavaScript for security reasons, this message alone won't show it.\n\nAlso try opening ${document.getElementById('baseUrl').value.trim()}/api/health directly in a new tab -- if that fails too, the Agent isn't reachable at all and this isn't a CORS issue.`;
  } finally {
    signButton.disabled = selectedFiles.length === 0;
  }
});

function escapeHtml(str) {
  const div = document.createElement('div');
  div.textContent = str;
  return div.innerHTML;
}

// X.509 Subject strings look like "CN=KANDASAMY SUBRAMANIYAN, SERIALNUMBER=..., S=Tamil
// Nadu, PostalCode=600056, Phone=...". Pulls out just the CN= value -- the actual human
// name -- for a compact dropdown instead of the full, cluttered subject string. Falls
// back to the whole subject if no CN= segment is found, rather than showing nothing.
function extractCommonName(subject) {
  const parts = subject.split(/,\s*/);
  for (const part of parts) {
    if (part.indexOf('CN=') === 0) {
      return part.substring(3);
    }
  }
  return subject;
}
</script>

</body>
</html>
