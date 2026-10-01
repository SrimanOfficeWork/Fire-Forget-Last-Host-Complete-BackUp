using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessObject;
using System.Data;
public partial class Accounts_Others_Approval_Request_Search_Entry : ThemeClass
{
    AppSession aps = new AppSession();
    Payment_Request PR = new Payment_Request();
    Global_variables ObjUBO = new Global_variables();
    DataTable dt = new DataTable();
    public string Working_Period, COMPANY_ID;
    DataSet ds = new DataSet();

    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };

    string Start_date = string.Empty, End_date = string.Empty, From_month = string.Empty, To_month = string.Empty, msg = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        Working_Period = Connection.WorkingPeriod();
        COMPANY_ID = Session["COMPANY_ID"].ToString();
        if (!IsPostBack)
        {
            Load_Month();
            Load_Group_Name();
            btnSearch_Click(sender, e);
            load_Request_To();
        }
    }

    private void load_Request_To()
    {
        DataSet ds = new DataSet();
        if (COMPANY_ID == "ERI00480")
        {
            ObjUBO.A32 = "Load_User_EmpName";
            ds = PR.Approval_Request_Ins_Upd(ObjUBO);
            if (ds.Tables[1].Rows.Count > 0)
            {
                ddlsender.DataSource = ds.Tables[0];
                ddlsender.DataTextField = "REQUEST_TO";
                ddlsender.DataValueField = "REQUEST_TO";
                ddlsender.DataBind();
            }
            ddlsender.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlsender.SelectedIndex = 0;
        }
        else
        {

        }
    }


    private void Load_Group_Name()
    {
        ddl_Branch.Items.Clear();
        if (Session["ClientGrpMst"] != null)
        {
            DataSet ds = (DataSet)Session["ClientGrpMst"];
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl_Branch.DataSource = ds.Tables[0];
                ddl_Branch.DataTextField = "GROUP_NAME";
                ddl_Branch.DataValueField = "GROUP_ID";
                ddl_Branch.DataBind();
            }
        }
        ddl_Branch.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddl_Branch.SelectedIndex = 0;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataSet dss = new DataSet();
        if (txtfromdate.Text != string.Empty || txttodate.Text != string.Empty)
        {
            ObjUBO.A1 = txtfromdate.Text;
            ObjUBO.A2 = txttodate.Text;
        }
        else
        {
            if (ddlmonth.SelectedItem.Text != string.Empty)
            {
                arr_Month = ddlmonth.SelectedValue.ToString().Split('-');
                ObjUBO.A1 = arr_Month[0];
                ObjUBO.A2 = arr_Month[1];
            }
            else
            {
                ObjUBO.A1 = txtfromdate.Text;
                ObjUBO.A2 = txttodate.Text;
            }
        }
        ObjUBO.A3 = ddlsender.SelectedValue;
        ObjUBO.A4 = ddlstatus.SelectedValue;
        ObjUBO.A5 = txtsearch.Text;
        ObjUBO.A6 = ddl_Branch.SelectedValue;
        ObjUBO.A7 = "Load_Grid_Data";
        ObjUBO.A8 = ddlImp.SelectedValue;
        dss = PR.Approval_Request_Search(ObjUBO);

        if (dss.Tables[0].Rows.Count > 0)
        {
            gvdetails.DataSource = dss.Tables[0];
        }
        else
        {
            gvdetails.DataSource = dt;
        }
        gvdetails.DataBind();
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

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string rowID = String.Empty;
        var row = e.Row;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string ID = this.gvdetails.DataKeys[e.Row.RowIndex]["REFERENCE_NO"].ToString();
            string IMP_EXP = this.gvdetails.DataKeys[e.Row.RowIndex]["IMP_EXP"].ToString();

            CheckBox chk = e.Row.FindControl("D_CHECK") as CheckBox;

            if (chk != null)
            {
                chk.InputAttributes["data-reference"] = ID;
                chk.InputAttributes["data-impexp"] = IMP_EXP;
            }

            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";

            rowID = e.Row.RowIndex.ToString();

            e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);

            e.Row.Attributes.Add(
                "onclick",
                "ChangeRowColor('" + rowID + "','" + ID + "')"
            );

            var des0 = row.Cells[1].Text.Replace("&amp;", "&");

            if (des0.Length > 10)
            {
                row.Cells[1].Text = des0.Substring(0, 10) + "...";
                row.Cells[1].ToolTip = des0;
            }

            e.Row.Font.Bold = true;
        }
    }
    protected void gvdetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (string.IsNullOrEmpty(e.CommandName))
            return;

        int rowIndex;
        if (!int.TryParse(Convert.ToString(e.CommandArgument), out rowIndex))
            return;

        GridViewRow row = gvdetails.Rows[rowIndex];

        string referenceNo = Convert.ToString(gvdetails.DataKeys[rowIndex]["REFERENCE_NO"]);
        string I_E = Convert.ToString(gvdetails.DataKeys[rowIndex]["IMP_EXP"]);

        TextBox txtRemarks = row.FindControl("txtRemarks") as TextBox;
        string remarks = txtRemarks != null ? txtRemarks.Text.Trim() : "";

        string status = "";

        if (e.CommandName == "APPROVE")
            status = "APPROVED";
        else if (e.CommandName == "REJECT")
            status = "REJECTED";
        else if (e.CommandName == "RETURN")
            status = "RETURNED";

        UpdateApprovalStatus(referenceNo, status, remarks, I_E);
    }

    private void UpdateApprovalStatus(string referenceNo, string status, string remarks, string IMP_EXP)
    {
        ObjUBO.A1 = referenceNo;
        // ObjUBO.A2 = id;
        ObjUBO.A3 = remarks;
        ObjUBO.A4 = status;
        ObjUBO.A5 = IMP_EXP;
        ObjUBO.A32 = "U";
        ds = PR.Approval_Request_Ins_Upd(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            msg = ds.Tables[0].Rows[0]["Msg"].ToString();
            if (!string.IsNullOrEmpty(msg))            {
                msg = msg.Replace("'", "\\'");
                string script = "if (!sessionStorage.getItem('approvalAlertShown')) { sessionStorage.setItem('approvalAlertShown', '1'); jAlert('" + msg + "', 'Approval Request'); }";

                ScriptManager.RegisterStartupScript(
                    this,
                    this.GetType(),
                    Guid.NewGuid().ToString(),
                    script,
                    true
                );
            }
            //btnSearch_Click(this, null);
        }
    }

    public void Load_Month()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        ds = Common_CS.Load_Month();

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlmonth.DataSource = ds.Tables[0];
            ddlmonth.DataTextField = "TheMonth";
            ddlmonth.DataValueField = "TheMonth_No";
            ddlmonth.DataBind();

            ddlmonth.Items.Insert(ddlmonth.Items.Count, new ListItem(String.Empty, String.Empty));
            ddlmonth.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
        }
    }

    protected void btnApproveSelected_Click(object sender, EventArgs e)
    {
        string selectedReferences = hdSelectedReferences.Value;
        if (string.IsNullOrEmpty(selectedReferences))
        {   
            return;
        }

        string[] entries = selectedReferences.Split(',');
        foreach (string entry in entries)
        {
            string item = entry.Trim();
            if (string.IsNullOrEmpty(item))
                continue;
                        
            string[] parts = item.Split('|');
            string refNo = parts[0].Trim();
            string impExp = parts.Length > 1 ? parts[1].Trim() : hd_Imp_Exp.Value;

            if (string.IsNullOrEmpty(refNo))
                continue;

            UpdateApprovalStatus(refNo, "APPROVED", "", impExp);
        }

        hdSelectedReferences.Value = string.Empty;
        btnSearch_Click(sender, e);
    }


    protected void btnRejectSelected_Click(object sender, EventArgs e)
    {
        string selectedReferences = hdSelectedReferences.Value;
        if (string.IsNullOrEmpty(selectedReferences))
        {
            // No checkbox selected
            return;
        }

        string[] entries = selectedReferences.Split(',');
        foreach (string entry in entries)
        {
            string item = entry.Trim();
            if (string.IsNullOrEmpty(item))
                continue;

            string[] parts = item.Split('|');
            string refNo = parts[0].Trim();
            string impExp = parts.Length > 1 ? parts[1].Trim() : hd_Imp_Exp.Value;

            if (string.IsNullOrEmpty(refNo))
                continue;

            UpdateApprovalStatus(refNo, "REJECTED", "", impExp);
        }

        hdSelectedReferences.Value = string.Empty;
        btnSearch_Click(sender, e);
    }
}