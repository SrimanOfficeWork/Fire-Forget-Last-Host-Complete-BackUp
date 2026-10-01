using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

public partial class Combined_Job : ThemeClass
{
    // Session keys
    const string SESS_SELECTED_JOBS = "UNIFIED_SELECTED_JOBS"; 
    const string SESS_DRAFT = "UNIFIED_DRAFT";

    public string currentuser, currentbranch, currentcomp_name, comp_ConnectionStr;
    public string Working_Period, LoginDate, SELECT_BRANCH;

    Export_General_New GenJob = new Export_General_New();
    Export_Unified_Job UJob = new Export_Unified_Job();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            AppSession aps = new AppSession();
            aps.checkSession_Subfolder();

            currentuser = Session["currentuser"].ToString();
            currentbranch = Session["currentbranch"].ToString();
            currentcomp_name = Session["currentcomp_name"].ToString();
            comp_ConnectionStr = Session["currentcomp_db"].ToString();
            Working_Period = Session["WorkingPeriod"].ToString();
            LoginDate = Session["LoginDate"].ToString();
            SELECT_BRANCH = Connection.Get_Company_Type();

            if (!IsPostBack)
            {
                Session[SESS_SELECTED_JOBS] = new List<string>();
                LoadExporters();
                RefreshJobNoChecklist();
                ClearPreview();
                UpdateFooterVisibility();
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }

    #region --- Lookups ---

    private void LoadExporters()
    {
        try
        {
            ddlExporter.Items.Clear();
            ddlExporter.Items.Add(new ListItem("", ""));

            string connStr = HttpContext.Current.Session["currentcomp_db"].ToString();

            string sql = @"SELECT DISTINCT EXPORTER_NAME
                    FROM EXPORT_GENERAL_DETAILS
                    WHERE BRANCHCODE IN (
                        SELECT BRANCHCODE FROM TBL_GROUPMASTER
                        WHERE GROUP_ID = (
                            CASE WHEN @BRANCH_CODE <> ''
                                 THEN (SELECT GROUP_ID FROM TBL_GROUPMASTER WHERE BRANCHCODE = @BRANCH_CODE)
                                 ELSE 1 END
                        )
                    )
                      AND EXPORTER_NAME IS NOT NULL
                      AND LTRIM(RTRIM(EXPORTER_NAME)) <> ''
                    ORDER BY EXPORTER_NAME";

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@BRANCH_CODE", SELECT_BRANCH);

            DataSet ds = SqlHelper.ExecuteDataset(connStr, CommandType.Text, sql, param);

            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string name = dr["EXPORTER_NAME"].ToString();
                    ddlExporter.Items.Add(new ListItem(name, name));
                }
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }

    private void RefreshJobNoChecklist()
    {
        chkJobNoList.Items.Clear();

        string exporterName = ddlExporter.SelectedValue;
        string trMode = ddlTrMode.SelectedValue;

        // Job No list only loads once BOTH Exporter and Tr.Mode are chosen
        if (string.IsNullOrEmpty(exporterName) || string.IsNullOrEmpty(trMode))
        {
            litJobNoSummary.Text = string.IsNullOrEmpty(exporterName)
                ? "Select Exporter & Tr.Mode"
                : "Select Tr.Mode";
            return;
        }

        UJob.BRANCH_CODE = SELECT_BRANCH;
        DataTable dtJobs = UJob.RetrieveAll_JobNo_ForSelection(exporterName, trMode, SELECT_BRANCH, Working_Period);

        List<string> selected = GetSelectedJobs();

        if (dtJobs != null)
        {
            foreach (DataRow dr in dtJobs.Rows)
            {
                string jobno = dr.Table.Columns.Contains("JOBNO") ? dr["JOBNO"].ToString() : "";
                string jobnoPs = dr.Table.Columns.Contains("JOBNO_PS") ? dr["JOBNO_PS"].ToString() : jobno;

                if (string.IsNullOrEmpty(jobno)) continue;

                ListItem li = new ListItem(jobnoPs, jobno);
                li.Selected = selected.Contains(jobno);
                chkJobNoList.Items.Add(li);
            }
        }

        UpdateJobNoSummaryLabel();
    }

    #endregion

    #region --- Selection tracking (order matters: first selected job = Top 1) ---

    private List<string> GetSelectedJobs()
    {
        if (Session[SESS_SELECTED_JOBS] == null)
            Session[SESS_SELECTED_JOBS] = new List<string>();
        return (List<string>)Session[SESS_SELECTED_JOBS];
    }

    private void UpdateJobNoSummaryLabel()
    {
        List<string> selected = GetSelectedJobs();
        litJobNoSummary.Text = selected.Count == 0
            ? "Select Job No"
            : (selected.Count == 1 ? selected[0] : selected.Count + " Jobs Selected");
    }

 
    private void UpdateFooterVisibility()
    {
        List<string> selected = GetSelectedJobs();
        btnGenerate.Visible = selected.Count >= 2;
    }

    #endregion

    #region --- Header control events ---

    protected void ddlExporter_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session[SESS_SELECTED_JOBS] = new List<string>();
        RefreshJobNoChecklist();
        ClearPreview();
        UpdateFooterVisibility();
    }

    protected void ddlTrMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session[SESS_SELECTED_JOBS] = new List<string>();
        RefreshJobNoChecklist();
        ClearPreview();
        UpdateFooterVisibility();
    }

    protected void chkJobNoList_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<string> selected = GetSelectedJobs();

        List<string> stillChecked = new List<string>();
        foreach (ListItem li in chkJobNoList.Items)
        {
            if (li.Selected) stillChecked.Add(li.Value);
        }

        // Remove any that were unchecked
        selected.RemoveAll(j => !stillChecked.Contains(j));

        // Append any newly checked jobs (preserve checklist order for the new ones)
        foreach (string j in stillChecked)
        {
            if (!selected.Contains(j)) selected.Add(j);
        }

        Session[SESS_SELECTED_JOBS] = selected;
        UpdateJobNoSummaryLabel();
        RefreshPreview();
        UpdateFooterVisibility();
    }

    protected void PageTrigger_CheckedChanged(object sender, EventArgs e)
    {
        RefreshPreview();
    }

    #endregion

    #region --- Preview ---

    private void ClearPreview()
    {
        litExporterName.Text = "-";
        litIec.Text = "-";
        litPortDischarge.Text = "-";
        litMode.Text = "-";
        litTotalPkg.Text = "0";
        litGrossWt.Text = "0";
        litNetWt.Text = "0";
        litContainers.Text = "0";
        litSummaryNote.Text = "";
        litInvoiceRows.Text = "<tr class=\"empty-row\"><td colspan=\"8\" style=\"text-align:center;\">No invoice records found</td></tr>";
        litItemRows.Text = "<tr class=\"empty-row\"><td colspan=\"9\" style=\"text-align:center;\">No item records found</td></tr>";
        lblInvoicePageInfo.Text = "Total: 0 rows";
        lblItemPageInfo.Text = "Total: 0 rows";
    }

    private void RefreshPreview()
    {
        List<string> selected = GetSelectedJobs();

        if (selected.Count == 0)
        {
            ClearPreview();
            return;
        }

        UJob.JobNoList = Export_Unified_Job.BuildJobNoListTable(selected);
        UJob.BRANCH_CODE = SELECT_BRANCH;

        DataSet dsPrev = UJob.RetrieveAll_UnifiedJob_Preview();

        if (dsPrev == null || dsPrev.Tables.Count < 3)
        {
            ClearPreview();
            return;
        }

        // --- Summary (General / Annexure C) ---
        if (chkGeneral.Checked || chkAnnexure.Checked)
        {
            if (dsPrev.Tables[0].Rows.Count > 0)
            {
                DataRow s = dsPrev.Tables[0].Rows[0];
                if (chkGeneral.Checked)
                {
                    litExporterName.Text = Safe(s, "EXPORTER_NAME");
                    litIec.Text = Safe(s, "IEC_NO");
                    litPortDischarge.Text = Safe(s, "PORT_DISCHARGE");
                    litMode.Text = Safe(s, "TRANSPORT_MODE");
                }
                if (chkAnnexure.Checked)
                {
                    litTotalPkg.Text = Safe(s, "TotalPackages", "0");
                    litGrossWt.Text = Safe(s, "GrossWeight", "0");
                    litNetWt.Text = Safe(s, "NetWeight", "0");
                    litContainers.Text = Safe(s, "Containers", "0");
                }
            }
        }
        else
        {
            litExporterName.Text = "-"; litIec.Text = "-"; litPortDischarge.Text = "-"; litMode.Text = "-";
            litTotalPkg.Text = "0"; litGrossWt.Text = "0"; litNetWt.Text = "0"; litContainers.Text = "0";
        }

        litSummaryNote.Text = selected.Count > 1
            ? "Merging " + selected.Count + " jobs. General details taken from <b>" + selected[0] + "</b> (first selected). Package / Weight / Container totals are summed across all selected jobs."
            : "";

        // --- Invoices ---
        StringBuilder invHtml = new StringBuilder();
        int invCount = 0;
        if (chkInvoices.Checked && dsPrev.Tables[1].Rows.Count > 0)
        {
            foreach (DataRow r in dsPrev.Tables[1].Rows)
            {
                invCount++;
                invHtml.Append("<tr>");
                invHtml.Append("<td class=\"sel-col\"><input type=\"checkbox\" checked disabled /></td>");
                invHtml.Append("<td>" + HttpUtility.HtmlEncode(Safe(r, "NEW_INVOICE_SLNO")) + "</td>");
                invHtml.Append("<td class=\"src-col\">" + HttpUtility.HtmlEncode(Safe(r, "SRC_JOB")) + "</td>");
                invHtml.Append("<td>" + HttpUtility.HtmlEncode(Safe(r, "INVOICE_NO")) + "</td>");
                invHtml.Append("<td>" + HttpUtility.HtmlEncode(Safe(r, "INVOICE_DATE")) + "</td>");
                invHtml.Append("<td>" + HttpUtility.HtmlEncode(Safe(r, "TERMS")) + "</td>");
                invHtml.Append("<td>" + HttpUtility.HtmlEncode(Safe(r, "INVOICE_VALUE")) + "</td>");
                invHtml.Append("<td>" + HttpUtility.HtmlEncode(Safe(r, "INVOICE_CURRENCY")) + "</td>");
                invHtml.Append("</tr>");
            }
        }
        litInvoiceRows.Text = invCount > 0 ? invHtml.ToString()
            : "<tr class=\"empty-row\"><td colspan=\"8\" style=\"text-align:center;\">No invoice records found</td></tr>";
        lblInvoicePageInfo.Text = "Total: " + invCount + " rows";

        // --- Items ---
        StringBuilder itemHtml = new StringBuilder();
        int itemCount = 0;
        if (chkItems.Checked && dsPrev.Tables[2].Rows.Count > 0)
        {
            foreach (DataRow r in dsPrev.Tables[2].Rows)
            {
                itemCount++;
                itemHtml.Append("<tr>");
                itemHtml.Append("<td class=\"sel-col\"><input type=\"checkbox\" checked disabled /></td>");
                itemHtml.Append("<td>" + HttpUtility.HtmlEncode(Safe(r, "OLD_ITEM_SLNO")) + "</td>");
                itemHtml.Append("<td class=\"src-col\">" + HttpUtility.HtmlEncode(Safe(r, "SRC_JOB")) + "</td>");
                itemHtml.Append("<td>" + HttpUtility.HtmlEncode(Safe(r, "ITEM_DESCRIPTION")) + "</td>");
                itemHtml.Append("<td>" + HttpUtility.HtmlEncode(Safe(r, "ITEM_QTY")) + "</td>");
                itemHtml.Append("<td>" + HttpUtility.HtmlEncode(Safe(r, "ITEM_UNIT_PRICE")) + "</td>");
                itemHtml.Append("<td>" + HttpUtility.HtmlEncode(Safe(r, "ITEM_AMOUNT")) + "</td>");
                itemHtml.Append("<td>" + HttpUtility.HtmlEncode(Safe(r, "RITCNO")) + "</td>");
                itemHtml.Append("<td>" + HttpUtility.HtmlEncode(Safe(r, "ITEM_SCHEME_CODE")) + "</td>");
                itemHtml.Append("</tr>");
            }
        }
        litItemRows.Text = itemCount > 0 ? itemHtml.ToString()
            : "<tr class=\"empty-row\"><td colspan=\"9\" style=\"text-align:center;\">No item records found</td></tr>";
        lblItemPageInfo.Text = "Total: " + itemCount + " rows";
    }

    private static string Safe(DataRow r, string col, string dflt = "-")
    {
        if (!r.Table.Columns.Contains(col) || r[col] == null || r[col] == DBNull.Value) return dflt;
        return r[col].ToString();
    }

    #endregion

    #region --- Footer buttons ---

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Session[SESS_SELECTED_JOBS] = new List<string>();
        Session[SESS_DRAFT] = null;

        ddlExporter.SelectedIndex = 0;
        ddlTrMode.SelectedIndex = 0;
        chkJobNoList.Items.Clear();

        chkGeneral.Checked = true;
        chkAnnexure.Checked = true;
        chkInvoices.Checked = true;
        chkItems.Checked = true;
        chkAnnexureC1.Checked = false;
        chkLicense.Checked = false;
        chkSupDoc.Checked = false;

        UpdateJobNoSummaryLabel();
        ClearPreview();
        UpdateFooterVisibility();
    }

    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        List<string> selected = GetSelectedJobs();

        if (selected.Count < 2)
        {
            ShowMessage("Please select at least 2 Job Nos to generate a Unified Job.");
            return;
        }

        if (!(chkGeneral.Checked || chkAnnexure.Checked || chkInvoices.Checked || chkItems.Checked
              || chkAnnexureC1.Checked || chkLicense.Checked || chkSupDoc.Checked))
        {
            ShowMessage("Please select at least one page to include in the Unified Job.");
            return;
        }

        try
        {
            // 1. Auto-generate the new job number the same way Job Duplicate does
            GenJob.BRANCH_CODE = SELECT_BRANCH;
            GenJob.WORKING_PERIOD = Working_Period;
            string newJobNoSeed = Convert.ToString(GenJob.Retrieve_JobNO());

            Admin_job_Prefix_Suffix JPS = new Admin_job_Prefix_Suffix();
            JPS.Branch = SELECT_BRANCH;
            JPS.Tr_mode = Connection.Get_Tr_Mode();
            JPS.BranchType = Session["SELECT_TYPE"] != null ? Session["SELECT_TYPE"].ToString() : "";
            JPS.Ename = "Exp_gen_select";
            DataSet dats = JPS.Job_prefix_Suffix_Select_Areawise();

            string jobPrefix = "", jobSuffix = "";
            if (dats != null && dats.Tables.Count > 0 && dats.Tables[0].Rows.Count > 0)
            {
                jobPrefix = dats.Tables[0].Rows[0][0].ToString();
                jobSuffix = dats.Tables[0].Rows[0][1].ToString();
            }

            // 2. Build the ordered job list (first item = "first selected job" per spec)
            UJob.JobNoList = Export_Unified_Job.BuildJobNoListTable(selected);

            UJob.CURRENT_JOBNO = newJobNoSeed;
            UJob.BRANCH_CODE = SELECT_BRANCH;
            UJob.WORKING_PERIOD = Working_Period;
            UJob.USER_ID = currentuser;
            UJob.DBS_Name = comp_ConnectionStr;
            UJob.Company_License = Session["COMPANY_LICENSE"] != null ? Session["COMPANY_LICENSE"].ToString() : "";
            UJob.Current_Branch = currentbranch;
            UJob.JOB_PREFIX = jobPrefix;
            UJob.JOB_SUFFIX = jobSuffix;
            UJob.Current_Working_Period = Working_Period;
            UJob.Ename = "Unified_Job";

            UJob.Inc_General = chkGeneral.Checked;
            UJob.Inc_AnnexureC = chkAnnexure.Checked;
            UJob.Inc_Invoices = chkInvoices.Checked;
            UJob.Inc_Items = chkItems.Checked;
            UJob.Inc_AnnexureC1 = chkAnnexureC1.Checked;
            UJob.Inc_License = chkLicense.Checked;
            UJob.Inc_SupDoc = chkSupDoc.Checked;

            int status = UJob.Generate_Unified_Job();

            if (status == 1)
            {
                ShowMessage("Combined Job Created Successfully: " + newJobNoSeed);
            }
            else if (status == 2)
            {
                ShowMessage("Job No " + newJobNoSeed + " already exists. Please try again.");
            }
            else
            {
                ShowMessage("Unable to generate the Unified Job. Please check the error log.");
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            ShowMessage("An error occurred while generating the Unified Job.");
        }
    }

    protected void btnhide_Click(object sender, EventArgs e)
    {
        MP_U.Hide();
    }

    private void ShowMessage(string msg)
    {
        lblUser_Msg.Text = msg;
        MP_U.Show();
    }

    #endregion
}