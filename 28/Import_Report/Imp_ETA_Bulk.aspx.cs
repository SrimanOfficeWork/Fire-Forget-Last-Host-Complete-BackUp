using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using BussinessObject;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
using Microsoft.ApplicationBlocks.Data;
using System.Globalization;
using System.Text.RegularExpressions;


public partial class Imp_ETA_Bulk : ThemeClass
{
    AppSession aps = new AppSession();
    public string SELECT_BRANCH, Jobno;
    UserBO ObjUBO = new UserBO();
    DataSet ds = new DataSet();
    General_ETA ETA = new General_ETA();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        SELECT_BRANCH = Connection.Get_Company_Type();

        if (Request.QueryString["JOBNO"] != "" && Request.QueryString["JOBNO"] != null)
            Jobno = Request.QueryString["JOBNO"].ToString();
        else
            Jobno = "";

        hdn_jobno.Value = Jobno;
        lbljobno.Text = Jobno;
        hdn_YN.Value = "Y - Yes, N - No";

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["Day_cnt"] != "" && Request.QueryString["Day_cnt"] != null)
                ddl_ETA_Filter.SelectedValue = Request.QueryString["Day_cnt"].ToString();

            Load_Jobno(Jobno);
            Load_ETA();
        }
    }

    private void Load_Jobno(string Jobno)
    {
        CheckList chklist = new CheckList();
        chklist.JOBNo = "";
        chklist.Ename = "select_jobno";
        chklist.Workingperiod = SELECT_BRANCH;

        ddl_Jobno.DataSource = chklist.RetrieveAll_General_Details();
        ddl_Jobno.DataValueField = "JOBNO";
        ddl_Jobno.DataTextField = "JOBNO";
        ddl_Jobno.DataBind();

        ListItem li = new ListItem(string.Empty, string.Empty);
        ddl_Jobno.Items.Insert(0, li);
    }

    protected void gv_Inv_Item_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
    }

    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }

    public void Alert_msg(string msg)
    {
        string safeMsg = HttpUtility.JavaScriptStringEncode(msg ?? "");
        string prompt = "<script>$(document).ready(function(){{jAlert('" + safeMsg + "', 'ETA - Tracking', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    private DataTable Get_Updated_Gridview_Data()
    {
        DataTable dt_new = new DataTable();

        dt_new.Columns.Add("JOBID");
        dt_new.Columns.Add("JOBNO");
        dt_new.Columns.Add("ETA");
        dt_new.Columns.Add("REMARKS");
        dt_new.Columns.Add("BRANCHCODE");
        dt_new.Columns.Add("USERID");
        dt_new.Columns.Add("VESSEL_NAME");
        dt_new.Columns.Add("IGM_VOYAGE");

        int chked_cnt = 0;

        // Reset before checking the rows.
        ViewState["Mandatory_Missing"] = "3";

        for (int i = 0; i < gvdetails.Rows.Count; i++)
        {
            GridViewRow row = gvdetails.Rows[i];

            CheckBox chk_All =
                (CheckBox)row.FindControl("chk_All");

            TextBox txtETA =
                (TextBox)row.FindControl("txtETA");

            TextBox txt_Remarks =
                (TextBox)row.FindControl("txt_Remarks");

            TextBox txt_VesselName =
                (TextBox)row.FindControl("txt_VesselName");

            TextBox txt_Voyage =
                (TextBox)row.FindControl("txt_Voyage");

            if (chk_All == null ||
                txtETA == null ||
                txt_Remarks == null ||
                txt_VesselName == null ||
                txt_Voyage == null)
            {
                continue;
            }

            if (!chk_All.Checked)
                continue;

            DataRow nr = dt_new.NewRow();

            nr["JOBID"] = GetGridCellText(row, 2);
            nr["JOBNO"] = GetGridCellText(row, 3);
            nr["ETA"] = txtETA.Text;
            nr["REMARKS"] = txt_Remarks.Text;
            nr["BRANCHCODE"] = Connection.Current_Branch();
            nr["VESSEL_NAME"] = txt_VesselName.Text;
            nr["IGM_VOYAGE"] = txt_Voyage.Text;

            dt_new.Rows.Add(nr);
            chked_cnt++;
        }

        if (chked_cnt > 0)
            ViewState["Mandatory_Missing"] = "1";

        return dt_new;
    }

    private string GetGridCellText(GridViewRow row, int cellIndex)
    {
        if (row == null ||
            cellIndex < 0 ||
            cellIndex >= row.Cells.Count)
        {
            return "";
        }

        return HttpUtility.HtmlDecode(
            row.Cells[cellIndex].Text ?? "")
            .Replace("&nbsp;", "")
            .Trim();
    }

    private void Action_Save_Update_Delete(string Action_flg)
    {
        string Status = "0";
        DataSet dss = new DataSet();
        DataTable dt_grid = Get_Updated_Gridview_Data();

        string mandatory = Convert.ToString(ViewState["Mandatory_Missing"]);

        if (mandatory == "1")
            Status = "1";
        else if (Action_flg == "btn_Save" && dt_grid.Rows.Count > 0)
            Status = "1";
        else if (mandatory == "2")
            Alert_msg("Mandatory Value Missing!..");
        else if (mandatory == "3")
            Alert_msg("Select Grid CheckBox");

        if (Status == "1" && dt_grid.Rows.Count > 0)
        {
            ObjUBO.JOBNO = Jobno;
            ObjUBO.Xml_A = Common_CS.ConvertDataTableToXML(dt_grid);
            ObjUBO.Ename = "btn_Save";
            dss = ETA.RetrieveAll_ETA_Details(ObjUBO);

            if (ETA.result == 1)
            {
                MP_JOB.Hide();
                Alert_msg(ddl_flg.SelectedItem.Text + "d Successfully");
            }
            else if (ETA.result == 2 || ETA.result == 3 || ETA.result == 4)
            {
                if (ETA.result == 2) lbl_heading.Text = "Alert !! - Record Already Exists!";
                if (ETA.result == 3) lbl_heading.Text = "Alert !! - Invalid Record - Found!";
                if (ETA.result == 4) lbl_heading.Text = "Alert !! - Duplicate Record Found!";
                MP_JOB.Show();
            }
            else
            {
                Alert_msg("Not Saved");
            }
        }
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        Action_Save_Update_Delete("btn_Save");
    }

    protected void ddl_flg_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_ETA();
    }

    private void Load_ETA()
    {
        ObjUBO.JOBNO = ddl_Jobno.SelectedItem != null ? ddl_Jobno.SelectedItem.Text : "";
        ObjUBO.IMPORTER_NAME = txt_ImporterName.Text;
        ObjUBO.TRANSPORT_MODE = "";
        ObjUBO.Ename = "General_ETA_Grid_Bind";
        ObjUBO.From_date = txtFrom_Date.Text;
        ObjUBO.Todate = txtTo_Date.Text;
        ObjUBO.ETA = ddl_ETA_Filter.SelectedValue;
        ObjUBO.action = ddl_flg.SelectedItem.Text;
        ObjUBO.FILING_STATUS = ddl_FilingStatus.SelectedValue;
        ObjUBO.VESSEL_NAME = txtVesselName.Text;

        ds = ETA.RetrieveAll_ETA_Details(ObjUBO);

        if (ds != null && ds.Tables.Count > 0)
        {
            gvdetails.DataSource = ds.Tables[0];
            gvdetails.DataBind();
            ViewState["CurrentTable"] = ds.Tables[0];

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ddl_flg.SelectedValue == "S")
                {
                    if (gvdetails.FooterRow != null) gvdetails.FooterRow.Visible = true;
                }
                else
                {
                    if (gvdetails.FooterRow != null) gvdetails.FooterRow.Visible = false;
                }
                lbl_Cnt.Text = Convert.ToString(ds.Tables[0].Rows.Count);
            }
            else
            {
                lbl_Cnt.Text = "0";
            }
        }
    }

    protected void btn_Load_Data_Click(object sender, EventArgs e)
    {
        Load_ETA();
    }

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow && e.Row.RowType != DataControlRowType.Header)
            return;

        if (ddl_flg.SelectedValue == "V" && e.Row.Cells.Count > 1)
            e.Row.Cells[1].Visible = false;

        if (e.Row.Cells.Count > 3)
        {
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Visible = false;
        }

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.Cells.Count > 8)
        {
            string impName = HttpUtility.HtmlDecode(e.Row.Cells[8].Text ?? "");
            if (impName.Length > 18)
                e.Row.Cells[8].Text = impName.Substring(0, 18) + "..";
            e.Row.Cells[8].ToolTip = impName;
        }
    }

    protected void btn_Refresh_Click(object sender, EventArgs e)
    {
        Transaction transact = new Transaction();
        transact.ResetFields(Page.Controls);
        btn_Load_Data_Click(sender, e);
    }

    protected void gv_RITC_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }

    protected void gv_RITC_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
    }

    protected void btnok_Click(object sender, EventArgs e)
    {
        MP_JOB.Hide();
    }

    protected void gvdetails_RowCommand(object sender,GridViewCommandEventArgs e)
    {
        if (e.CommandName != "ViewVessel")
            return;

        int rowIndex;

        if (!int.TryParse(
            Convert.ToString(e.CommandArgument),
            out rowIndex))
        {
            Alert_msg("Invalid vessel row.");
            return;
        }

        if (rowIndex < 0 || rowIndex >= gvdetails.Rows.Count)
        {
            Alert_msg("Import ETA row not found.");
            return;
        }

        GridViewRow mainRow = gvdetails.Rows[rowIndex];

        TextBox txtVesselName =
            mainRow.FindControl("txt_VesselName") as TextBox;

        string vesselName =
            txtVesselName != null
                ? txtVesselName.Text.Trim()
                : "";

        string port = "";

        try
        {
            if (gvdetails.DataKeys[rowIndex] != null)
            {
                object value =
                    gvdetails.DataKeys[rowIndex]["CUSTOMS_HOUSE"];

                if (value != null && value != DBNull.Value)
                {
                    port =
                        Convert.ToString(value)
                        .Trim()
                        .ToUpperInvariant();
                }
            }
        }
        catch
        {
            port = "";
        }

        if (port != "INMAA1" &&
            port != "INENR1" &&
            port != "INKAT1")
        {
            Alert_msg(
                "Berthing schedule is available only for " +
                "Chennai (INMAA1), Ennore (INENR1), and " +
                "Kattupalli (INKAT1).");

            return;
        }

        ViewState["SelectedVesselGridRow"] = rowIndex;
        ViewState["SelectedVesselName"] = vesselName;
        ViewState["SelectedVesselPort"] = port;

        // ============================================================
        // CHENNAI
        // ============================================================
        if (port == "INMAA1")
        {
            hdn_ChennaiSelectedIndex.Value = "-1";
            hdn_ChennaiVesselName.Value = "";
            hdn_ChennaiETA.Value = "";
            hdn_ChennaiRevisedETA.Value = "";

            DataTable dt =
                Execute_Berthing_Schedule_SP(
                    port,
                    vesselName);

            gvChennaiSchedule.DataSource = dt;
            gvChennaiSchedule.DataBind();

            lbl_ChennaiScheduleHeading.Text =
                "Chennai Vessel Schedule - " +
                (string.IsNullOrWhiteSpace(vesselName)
                    ? "All Vessels"
                    : vesselName);

            MP_ChennaiSchedule.Show();

            if (dt.Rows.Count == 0)
            {
                Alert_msg(
                    string.IsNullOrWhiteSpace(vesselName)
                        ? "No vessel schedule records found."
                        : "No berthing schedule found for vessel '" +
                          vesselName + "'.");
            }

            return;
        }

        // ============================================================
        // ENNORE
        // ============================================================
        if (port == "INENR1")
        {
            hdn_EnnoreSelectedIndex.Value = "-1";
            hdn_EnnoreVesselName.Value = "";
            hdn_EnnoreETA.Value = "";

            DataTable dt =
                Execute_Berthing_Schedule_SP(
                    port,
                    vesselName);

            gvEnnoreSchedule.DataSource = dt;
            gvEnnoreSchedule.DataBind();

            lbl_EnnoreScheduleHeading.Text =
                "Ennore Vessel Schedule - " +
                (string.IsNullOrWhiteSpace(vesselName)
                    ? "All Vessels"
                    : vesselName);

            MP_EnnoreSchedule.Show();

            if (dt.Rows.Count == 0)
            {
                Alert_msg(
                    string.IsNullOrWhiteSpace(vesselName)
                        ? "No Ennore vessel schedule records found."
                        : "No Ennore schedule found for vessel '" +
                          vesselName + "'.");
            }

            return;
        }

        // ============================================================
        // KATTUPALLI
        // ============================================================
        if (port == "INKAT1")
        {
            hdn_KattupalliSelectedIndex.Value = "-1";
            hdn_KattupalliVesselName.Value = "";
            hdn_KattupalliETA.Value = "";

            DataTable dt =
                Execute_Berthing_Schedule_SP(
                    port,
                    vesselName);

            gvKattupalliSchedule.DataSource = dt;
            gvKattupalliSchedule.DataBind();

            lbl_KattupalliScheduleHeading.Text =
                "Kattupalli Vessel Schedule - " +
                (string.IsNullOrWhiteSpace(vesselName)
                    ? "All Vessels"
                    : vesselName);

            MP_KattupalliSchedule.Show();

            if (dt.Rows.Count == 0)
            {
                Alert_msg(
                    string.IsNullOrWhiteSpace(vesselName)
                        ? "No Kattupalli vessel schedule records found."
                        : "No Kattupalli schedule found for vessel '" +
                          vesselName + "'.");
            }
        }
    }

    private DataTable Execute_Berthing_Schedule_SP(string portCode, string vesselName)
    {
        DataTable dt = new DataTable();

        try
        {
            SqlParameter[] param =
            {
                new SqlParameter(
                    "@PortCode",
                    SqlDbType.VarChar,
                    20)
                {
                    Value = portCode
                },

                new SqlParameter(
                    "@VesselName",
                    SqlDbType.VarChar,
                    200)
                {
                    Value =
                        string.IsNullOrWhiteSpace(vesselName)
                            ? (object)DBNull.Value
                            : vesselName.Trim()
                }
            };

            DataSet ds =
                SqlHelper.ExecuteDataset(
                    ConfigurationManager.AppSettings["con"],
                    CommandType.StoredProcedure,
                    "BERTHING_SCHEDULE_SP",
                    param);

            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0].Copy();
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(
                "BERTHING_SCHEDULE_SP ERROR: " +
                ex.ToString());

            Alert_msg(
                "Error loading vessel schedule: " +
                ex.Message);
        }

        return dt;
    }


    private void Assign_Vessel_ETA_To_MainGrid(string vesselName,string eta,string revisedEta, AjaxControlToolkit.ModalPopupExtender popup)
    {
        vesselName = SafeString(vesselName);
        eta = SafeString(eta);
        revisedEta = SafeString(revisedEta);

        if (string.IsNullOrWhiteSpace(vesselName))
        {
            Alert_msg("Please select one vessel schedule.");
            popup.Show();
            return;
        }

        // Revised ETA has priority.
        // If Revised ETA is empty, use ETA.
        string chosenDate =
            !string.IsNullOrWhiteSpace(revisedEta)
                ? revisedEta
                : eta;

        // DP World values such as:
        // 1800 HRS
        // 1800 HRS 2300 HRS
        // are not ETA dates.
        if (Contains_HRS_Value(chosenDate))
        {
            chosenDate = eta;
        }

        if (string.IsNullOrWhiteSpace(chosenDate))
        {
            Alert_msg(
                "Selected vessel schedule does not contain ETA.");

            popup.Show();
            return;
        }

        if (ViewState["SelectedVesselGridRow"] == null)
        {
            Alert_msg("Import ETA row not found.");
            popup.Show();
            return;
        }

        int mainRowIndex =
            Convert.ToInt32(
                ViewState["SelectedVesselGridRow"]);

        // Recreate the main Import ETA GridView on postback.
        Load_ETA();

        if (mainRowIndex < 0 ||
            mainRowIndex >= gvdetails.Rows.Count)
        {
            Alert_msg(
                "Import ETA row not found after loading data.");

            popup.Show();
            return;
        }

        GridViewRow mainRow =
            gvdetails.Rows[mainRowIndex];

        TextBox txtMainVesselName =
            mainRow.FindControl("txt_VesselName")
            as TextBox;

        TextBox txtMainETA =
            mainRow.FindControl("txtETA")
            as TextBox;

        if (txtMainVesselName == null)
        {
            Alert_msg("Vessel Name textbox was not found.");
            popup.Show();
            return;
        }

        if (txtMainETA == null)
        {
            Alert_msg("ETA textbox was not found.");
            popup.Show();
            return;
        }

        txtMainVesselName.Text = vesselName;
        txtMainETA.Text = Convert_To_ddMMyyyy(chosenDate);

        popup.Hide();

        Alert_msg(
            "Vessel Name and ETA assigned successfully.");
    }


    private bool Contains_HRS_Value(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return false;

        return value.IndexOf(
            "HRS",
            StringComparison.OrdinalIgnoreCase) >= 0;
    }

    protected void btn_ChennaiScheduleUpdate_Click(object sender,EventArgs e)
    {
        Assign_Vessel_ETA_To_MainGrid(
            hdn_ChennaiVesselName.Value,
            hdn_ChennaiETA.Value,
            hdn_ChennaiRevisedETA.Value,
            MP_ChennaiSchedule);
    }


    protected void btn_ChennaiScheduleClose_Click(object sender,EventArgs e)
    {
        MP_ChennaiSchedule.Hide();
    }

    protected void btn_EnnoreScheduleUpdate_Click(object sender,EventArgs e)
    {
        // Ennore ETA = AtaEtaDate + AtaEtaTime.
        Assign_Vessel_ETA_To_MainGrid(
            hdn_EnnoreVesselName.Value,
            hdn_EnnoreETA.Value,
            "",
            MP_EnnoreSchedule);
    }


    protected void btn_EnnoreScheduleClose_Click(
        object sender,
        EventArgs e)
    {
        MP_EnnoreSchedule.Hide();
    }


    // ================================================================
    // KATTUPALLI UPDATE
    // ================================================================

    protected void btn_KattupalliScheduleUpdate_Click(
        object sender,
        EventArgs e)
    {
        Assign_Vessel_ETA_To_MainGrid(
            hdn_KattupalliVesselName.Value,
            hdn_KattupalliETA.Value,
            "",
            MP_KattupalliSchedule);
    }


    protected void btn_KattupalliScheduleClose_Click(
        object sender,
        EventArgs e)
    {
        MP_KattupalliSchedule.Hide();
    }


    private string SafeString(object value)
    {
        if (value == null ||
            value == DBNull.Value)
            return "";

        return HttpUtility.HtmlDecode(
            Convert.ToString(value))
            .Replace("&nbsp;", "")
            .Trim();
    }


    private string Convert_To_ddMMyyyy(string rawDate)
    {
        if (string.IsNullOrWhiteSpace(rawDate))
            return "";

        string s = HttpUtility.HtmlDecode(rawDate)
            .Replace("&nbsp;", " ")
            .Trim();

        // Normalize multiple spaces
        s = Regex.Replace(s, @"\s+", " ");

        // Remove " - " between month and year
        // Tue 01 Sep - 2026 14:00
        // -> Tue 01 Sep 2026 14:00
        s = Regex.Replace(s, @"\s*-\s*", " ");

        // Fix broken time:
        // "1 4:00" -> "14:00"
        // "2 3:00" -> "23:00"
        // "0 8:00" -> "08:00"
        s = Regex.Replace(s, @"\b(\d)\s+(\d):(\d{2})\b", "$1$2:$3");

        DateTime dt;

        string[] formats =
    {
        "ddd dd MMM yyyy HH:mm",
        "ddd d MMM yyyy HH:mm",

        "ddd dd MMM yyyy",
        "ddd d MMM yyyy",

        "dd MMM yyyy HH:mm",
        "d MMM yyyy HH:mm",

        "dd MMM yyyy",
        "d MMM yyyy",

        "dd-MM-yyyy HH:mm",
        "dd-MM-yyyy",

        "dd/MM/yyyy HH:mm",
        "dd/MM/yyyy",

        "yyyy-MM-dd HH:mm:ss",
        "yyyy-MM-dd HH:mm",
        "yyyy-MM-dd",

        "MM/dd/yyyy HH:mm:ss",
        "MM/dd/yyyy"
    };

        if (DateTime.TryParseExact(
            s,
            formats,
            CultureInfo.InvariantCulture,
            DateTimeStyles.AllowWhiteSpaces,
            out dt))
        {
            return dt.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        if (DateTime.TryParse(
            s,
            CultureInfo.InvariantCulture,
            DateTimeStyles.AllowWhiteSpaces,
            out dt))
        {
            return dt.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        return s;
    }
}
