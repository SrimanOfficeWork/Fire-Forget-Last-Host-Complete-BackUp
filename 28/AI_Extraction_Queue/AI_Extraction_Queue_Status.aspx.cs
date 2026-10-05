using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using BussinessObject;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public partial class AI_Extraction_Queue_Status : ThemeClass
{
    AppSession aps = new AppSession();
    AI_Queue QueueBO = new AI_Queue();
    Global_variables ObjUBO = new Global_variables();

    private const string EROYAL_STATUS_URL = "https://portal-eroyal.pmdgtech.com/designer/api/datatable/getDataByField/dt_eroyaldb";
    private const string EROYAL_API_KEY = "ATIVSTAGMSNVEHEQAUPMS1CE";
    private const string ROYAL_STATUS_URL = "";

    // ── Current job type from toggle: '' = Both, 'IMP' = Import, 'EXP' = Export
    private string CurrentJobType
    {
        get { return hdnJobType.Value ?? ""; }
        set { hdnJobType.Value = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        string Job_type = Request.QueryString["Job_type"];
        if (!IsPostBack)
        {
            DateTime today = DateTime.Today;
            CalendarExtender1.EndDate = today;
            CalendarExtender2.EndDate = today;
            CurrentJobType = string.IsNullOrEmpty(Job_type) ? "IMP" : Job_type; // default = Import on first load
            LoadSummaryCounts();
            GridBind(1);
        }
    }

    // ── Job Type Toggle postback ──────────────────────────────────────
    protected void btnJobTypeToggle_Click(object sender, EventArgs e)
    {
        // hdnJobType is already updated by JS before postback
        LoadSummaryCounts();
        GridBind(1);
    }

    // ── Auto Refresh ──────────────────────────────────────────────────
    protected void btnAutoRefresh_Click(object sender, EventArgs e)
    {
        AutoCheckAllInProgressRows();
        LoadSummaryCounts();
        GridBind(int.Parse(lblCurrentPage.Text));
    }

    // ── Auto check all IN PROGRESS rows ──────────────────────────────
    private void AutoCheckAllInProgressRows()
    {
        try
        {
            Global_variables ProgressObj = new Global_variables();
            ProgressObj.A1 = "";
            ProgressObj.A3 = "";
            ProgressObj.A6 = "IN PROGRESS";
            ProgressObj.A8 = "";
            ProgressObj.A9 = "";
            ProgressObj.A10 = CurrentJobType; // job type filter
            ProgressObj.A11 = "1";
            ProgressObj.A12 = "99999";

            DataSet ds = QueueBO.Queue_Grid_Data(ProgressObj);
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return;

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string processId = row["PROCESS_ID"].ToString();
                string vendorType = row["VENDOR_TYPE"].ToString();
                if (string.IsNullOrEmpty(processId)) continue;

                string newStatus = CheckJobStatus(processId, vendorType);

                if (newStatus == "FAILED")
                {
                    Global_variables U = new Global_variables();
                    U.A4 = processId; U.A6 = "FAILED"; U.A7 = "";
                    QueueBO.Queue_Update_Status(U);
                }
                else if (newStatus == "READY" && vendorType != "EROYAL" && !DockerVision_Queue.IsDockerVision(vendorType))
                {
                    Global_variables U = new Global_variables();
                    U.A4 = processId; U.A6 = "READY"; U.A7 = "";
                    QueueBO.Queue_Update_Status(U);
                }
            }
        }
        catch { }
    }

    // ── Search ────────────────────────────────────────────────────────
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        LoadSummaryCounts();
        GridBind(1);
    }

    // ── Clear ─────────────────────────────────────────────────────────
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtJobNo.Text = "";
        txtFromDate.Text = "";
        txtToDate.Text = "";
        ddlVendor.SelectedIndex = 0;
        ddlStatus.SelectedIndex = 0;
        LoadSummaryCounts();
        GridBind(1);
    }

    // ── Delete Selected (ImageButton) ─────────────────────────────────
    protected void imgDeleteSelected_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            System.Collections.Generic.List<string> selectedIds =
                new System.Collections.Generic.List<string>();

            foreach (GridViewRow row in gvQueue.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chk = row.FindControl("chkSelect") as CheckBox;
                    if (chk != null && chk.Checked)
                        selectedIds.Add(gvQueue.DataKeys[row.RowIndex]["QUEUE_ID"].ToString());
                }
            }

            if (selectedIds.Count == 0)
            { Alert_msg("Please select at least one record to delete."); return; }

            Global_variables DelObj = new Global_variables();
            DelObj.A1 = string.Join(",", selectedIds);
            QueueBO.Queue_Delete_Multiple(DelObj);

            Alert_msg(selectedIds.Count + " record(s) deleted successfully.");
            LoadSummaryCounts();
            GridBind(1);
        }
        catch (Exception ex) { Alert_msg("Error deleting: " + ex.Message); }
    }

    // ── Load Summary Counts ───────────────────────────────────────────
    public void LoadSummaryCounts()
    {
        try
        {
            string jt = CurrentJobType;
            lblTotalCount.Text = QueueBO.Queue_Count_Only("", jt).ToString();
            lblProgressCount.Text = QueueBO.Queue_Count_Only("IN PROGRESS", jt).ToString();
            lblReadyCount.Text = QueueBO.Queue_Count_Only("READY", jt).ToString();
            lblFailedCount.Text = QueueBO.Queue_Count_Only("FAILED", jt).ToString();
        }
        catch
        {
            lblTotalCount.Text = lblProgressCount.Text = lblReadyCount.Text = lblFailedCount.Text = "0";
        }
    }

    // ── Grid Bind ─────────────────────────────────────────────────────
    public void GridBind(int pageNumber)
    {
        try
        {
            ObjUBO.A1 = txtJobNo.Text.Trim();
            ObjUBO.A3 = ddlVendor.SelectedValue;  // hidden but still passed
            ObjUBO.A6 = ddlStatus.SelectedValue;
            ObjUBO.A8 = txtFromDate.Text.Trim();
            ObjUBO.A9 = txtToDate.Text.Trim();
            ObjUBO.A10 = CurrentJobType;            // IMP / EXP / ''
            ObjUBO.A11 = pageNumber.ToString();
            ObjUBO.A12 = gvQueue.PageSize.ToString();

            DataSet ds = QueueBO.Queue_Grid_Data(ObjUBO);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvQueue.DataSource = ds.Tables[0];
                gvQueue.DataBind();
                Grid_Total(pageNumber, QueueBO.result);
            }
            else
            {
                gvQueue.DataSource = new DataTable();
                gvQueue.DataBind();
                Div_Pagination.Visible = false;
            }
        }
        catch (Exception ex) { Alert_msg("Error loading queue: " + ex.Message); }
    }

    // ── Row Data Bound ────────────────────────────────────────────────
    protected void gvQueue_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string status = gvQueue.DataKeys[e.Row.RowIndex]["STATUS"].ToString();
            string vendorType = gvQueue.DataKeys[e.Row.RowIndex]["VENDOR_TYPE"].ToString();

            Label lblVendor = e.Row.FindControl("lblVendor") as Label;
            if (lblVendor != null)
                lblVendor.Text = vendorType == "EROYAL"
                    ? "<span class='badge-eroyal'>Eroyal</span>"
                    : "<span class='badge-royal'>Royal</span>";

            Label lblStatus = e.Row.FindControl("lblStatus") as Label;
            if (lblStatus != null)
            {
                if (status == "IN PROGRESS")
                    lblStatus.Text = "<span class='badge badge-progress'>In Progress</span>";
                else if (status == "READY")
                    lblStatus.Text = "<span class='badge badge-ready'>Ready</span>";
                else if (status == "FAILED")
                    lblStatus.Text = "<span class='badge badge-failed'>Failed</span>";
            }
            Label lblJobStatus = e.Row.FindControl("lblJobStatus") as Label;
            if (lblJobStatus != null)
            {
                string jobNo = DataBinder.Eval(e.Row.DataItem, "JOB_NO") + "";
                bool isTempJobNo = string.IsNullOrEmpty(jobNo) || jobNo.StartsWith("TEMP");
                // ↑ adjust the condition to match YOUR temp job no pattern

                if (isTempJobNo)
                    lblJobStatus.Text = "<span class='badge badge-progress' >Draft</span>";
                else
                    lblJobStatus.Text = "<span class='badge badge-ready'>Job Saved</span>";
            }

            // ── Show/hide action icons AND labels based on status ─────────
            ImageButton imgCheckStatus = e.Row.FindControl("imgCheckStatus") as ImageButton;
            ImageButton imgView = e.Row.FindControl("imgView") as ImageButton;
            Label lblStatusIconLabel = e.Row.FindControl("lblStatusIconLabel") as Label;
            Label lblViewIconLabel = e.Row.FindControl("lblViewIconLabel") as Label;

            if (imgCheckStatus != null && imgView != null)
            {
                bool isInProgress = (status == "IN PROGRESS");
                bool isReady = (status == "READY");

                imgCheckStatus.Visible = isInProgress;
                imgView.Visible = isReady;

                if (lblStatusIconLabel != null) lblStatusIconLabel.Visible = isInProgress;
                if (lblViewIconLabel != null) lblViewIconLabel.Visible = isReady;
            }

            string fileName = DataBinder.Eval(e.Row.DataItem, "FILE_NAME") + "";
            if (!string.IsNullOrEmpty(fileName) && fileName.Length > 25)
            { e.Row.Cells[3].ToolTip = fileName; e.Row.Cells[3].Text = fileName.Substring(0, 23) + "..."; }

            string importerName = DataBinder.Eval(e.Row.DataItem, "IMPORTER_NAME") + "";
            if (!string.IsNullOrEmpty(importerName) && importerName.Length > 25)
            { e.Row.Cells[4].ToolTip = importerName; e.Row.Cells[4].Text = importerName.Substring(0, 23) + "..."; }
        }
    }

    protected void gvQueue_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }

    // ── Row Command ───────────────────────────────────────────────────
    protected void gvQueue_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            // CommandArgument = PROCESS_ID~VENDOR_TYPE~SL_NO~IMPORTER_NAME~JOB_TYPE
            string[] args = e.CommandArgument.ToString().Split('~');
            string processId = args.Length > 0 ? args[0] : "";
            string vendorType = args.Length > 1 ? args[1] : "";
            string slno = args.Length > 2 ? args[2] : "";
            string impName = args.Length > 3 ? args[3] : "";
            string jobType = args.Length > 4 && !string.IsNullOrEmpty(args[4]) ? args[4]
                 : CurrentJobType == "EXP" ? "EXP" : "IMP";

            if (e.CommandName == "CheckStatus")
            {
                string newStatus = CheckJobStatus(processId, vendorType);

                Global_variables U = new Global_variables();
                U.A4 = processId; U.A6 = newStatus; U.A7 = "";
                QueueBO.Queue_Update_Status(U);

                if (newStatus == "READY") Alert_msg("Extraction complete! Status updated to READY.");
                else if (newStatus == "FAILED") Alert_msg("Extraction failed. Please re-upload.");
                else Alert_msg("Job is still In Progress. Please check again shortly.");

                LoadSummaryCounts();
                GridBind(int.Parse(lblCurrentPage.Text));
            }
            else if (e.CommandName == "ViewResult")
            {
                // Route to correct screen — case-insensitive comparison
                string Imp_Exp = (jobType.ToUpper() == "EXP")
                    ? "../Export_PDFReader/Export_PDF_Reader_New_AI.aspx?pid="
                    : "../Import_Pdf_Reader/Import_PDF_Reader_AI.aspx?pid=";

                string url = Imp_Exp
                             + Server.UrlEncode(processId)
                             + "&vendor=" + vendorType
                             + "&Imp_exp_name=" + Server.UrlEncode(impName)
                             + "&slno=" + slno;

                // Register on Page — openViewScreen opens a new independent popup
                ScriptManager.RegisterStartupScript(
                    this,
                    this.GetType(),
                    "openview_" + processId.Replace("-", ""),
                    "openViewScreen('" + url.Replace("'", "\\'") + "');",
                    true);
            }
        }
        catch (Exception ex) { Alert_msg("Error: " + ex.Message); }
    }

    // ── Check Job Status ──────────────────────────────────────────────
    private string CheckJobStatus(string processId, string vendorType)
    {
        try
        {
            if (DockerVision_Queue.IsDockerVision(vendorType))
                return CheckStatus_DockerVision(processId);

            return vendorType == "EROYAL"
                ? CheckStatus_Eroyal(processId)
                : CheckStatus_Royal(processId);
        }
        catch { return "FAILED"; }
    }

    // ── Eroyal Status Check ───────────────────────────────────────────
    private string CheckStatus_Eroyal(string processId)
    {
        try
        {
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            string body = "{\"field\":\"processInstanceId\",\"value\":\""
                          + processId + "\",\"matchType\":\"exact\"}";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(EROYAL_STATUS_URL);
            request.Method = "POST"; request.ContentType = "application/json";
            request.Headers.Add("x-api-key", EROYAL_API_KEY);
            request.Timeout = 30000;

            byte[] bodyBytes = Encoding.UTF8.GetBytes(body);
            request.ContentLength = bodyBytes.Length;
            using (Stream s = request.GetRequestStream()) s.Write(bodyBytes, 0, bodyBytes.Length);

            using (WebResponse response = request.GetResponse())
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string result = reader.ReadToEnd();
                JObject json = JObject.Parse(result);
                int count = (int)json["count"];
                if (count == 0) return "IN PROGRESS";

                JObject doc = (JObject)json["documents"][0];
                string apiStatus = doc["Status"] != null ? doc["Status"].ToString() : "";
                bool ocrReady = doc["ocrReady"] != null && (bool)doc["ocrReady"];

                if (apiStatus == "Extraction_InProgress") return "IN PROGRESS";

                if (apiStatus == "Completed" && ocrReady)
                {
                    string ocrResult = doc["ocrResult"] != null ? doc["ocrResult"].ToString() : "";
                    if (!string.IsNullOrEmpty(ocrResult))
                    {
                        Global_variables U = new Global_variables();
                        U.A4 = processId; U.A6 = "READY"; U.A7 = ocrResult;
                        QueueBO.Queue_Update_Status(U);
                    }
                    return "READY";
                }
                return "FAILED";
            }
        }
        catch { return "FAILED"; }
    }

    // ── Docker Vision Status Check (JSON stored in OCR_AI_Extraction_Responses) ──
    private string CheckStatus_DockerVision(string processId)
    {
        try
        {
            string json;
            string status = DockerVision_Queue.Get_Status(processId, out json);
            if (status == "READY")
            {
                Global_variables U = new Global_variables();
                U.A4 = processId; U.A6 = "READY"; U.A7 = json;
                QueueBO.Queue_Update_Status(U);
            }
            return status;
        }
        catch { return "FAILED"; }
    }

    // ── Royal Status Check ────────────────────────────────────────────
    private string CheckStatus_Royal(string processId)
    {
        try
        {
            if (string.IsNullOrEmpty(ROYAL_STATUS_URL)) return "IN PROGRESS";
            return "IN PROGRESS";
        }
        catch { return "FAILED"; }
    }

    // ── Pagination ────────────────────────────────────────────────────
    public void Grid_Total(int currentPageNumber, double totalRows)
    {
        int totalPages = (int)Math.Ceiling(totalRows / gvQueue.PageSize);
        lblCurrentPage.Text = currentPageNumber.ToString();
        lblTotalPages.Text = totalRows.ToString();
        lblTotalPagesDisplay.Text = totalPages.ToString();
        lblTotalRecords.Text = ((int)totalRows).ToString();
        Div_Pagination.Visible = totalRows > 0;
        btnPrev.Visible = currentPageNumber > 1;
        btnFirst.Visible = currentPageNumber > 1;
        btnNext.Visible = currentPageNumber < totalPages;
        btnLast.Visible = currentPageNumber < totalPages;
        Add_Pageno(totalPages);
    }

    public void Add_Pageno(int totalPages)
    {
        ddlSelectPageno.Items.Clear();
        for (int i = 1; i <= totalPages; i++)
            ddlSelectPageno.Items.Add(i.ToString());
        if (ddlSelectPageno.Items.Count > 0)
        {
            int current = int.Parse(lblCurrentPage.Text);
            if (current <= ddlSelectPageno.Items.Count)
                ddlSelectPageno.SelectedIndex = current - 1;
        }
    }

    protected void ddlSelectPageno_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(ddlSelectPageno.SelectedValue))
            GridBind(int.Parse(ddlSelectPageno.SelectedValue));
    }

    protected void ChangePage(object sender, CommandEventArgs e)
    {
        int currentPage = int.Parse(lblCurrentPage.Text);
        int totalPages = (int)Math.Ceiling(double.Parse(lblTotalPages.Text) / gvQueue.PageSize);
        int newPage = currentPage;
        switch (e.CommandName)
        {
            case "First": newPage = 1; break;
            case "Previous": newPage = currentPage > 1 ? currentPage - 1 : 1; break;
            case "Next": newPage = currentPage < totalPages ? currentPage + 1 : totalPages; break;
            case "Last": newPage = totalPages; break;
        }
        GridBind(newPage);
    }

    // ── Alert ─────────────────────────────────────────────────────────
    public void Alert_msg(string msg)
    {
        msg = msg.Replace("'", "\\'");
        string script = "<script>$(document).ready(function(){jAlert('" + msg + "','PDF AI Queue',function(r){});});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", script, false);
    }
}