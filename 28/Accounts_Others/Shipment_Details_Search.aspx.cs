using System;
using System.Data;
using System.Web.UI.WebControls;
using BussinessObject;
using System.Web.UI;
using System.Linq;
using System.Collections.Generic;

public partial class Accounts_Others_Default : ThemeClass
{
    AppSession aps = new AppSession();
    Payment_Request PR = new Payment_Request();
    Global_variables ObjUBO = new Global_variables();
    DataTable dt = new DataTable();
    public string Working_Period, COMPANY_ID;
    DataSet ds = new DataSet();
    Cha_Accounts Chrg = new Cha_Accounts();
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
            btnSearch_Click(sender, e);

        }
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
        ObjUBO.A3 = txtJobno.Text;
        ObjUBO.A5 = txtsearch.Text;
        ObjUBO.A7 = "Load_Grid_Data";
        dss = PR.Shipment_Details_Search(ObjUBO);

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

    //protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    string rowID = String.Empty;
    //    var row = e.Row;
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        string ID = this.gvdetails.DataKeys[e.Row.RowIndex]["SHIPMENT_NO"].ToString();
    //        e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
    //        rowID = e.Row.RowIndex.ToString();
    //        e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
    //        e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + ID + "')");
    //        var des3 = row.Cells[3].Text.Replace("&amp;", "&");
    //        var des4 = row.Cells[4].Text.Replace("&amp;", "&");
    //        var des5 = row.Cells[5].Text.Replace("&amp;", "&");
    //        if (des3.Length > 100)
    //        {
    //            row.Cells[3].Text = des3.Substring(0, 100) + "...";
    //            row.Cells[3].ToolTip = des3;
    //        }
    //        if (des4.Length > 100)
    //        {
    //            row.Cells[4].Text = des4.Substring(0, 100) + "...";
    //            row.Cells[4].ToolTip = des4;
    //        }
    //        if (des5.Length > 100)
    //        {
    //            row.Cells[5].Text = des5.Substring(0, 100) + "...";
    //            row.Cells[5].ToolTip = des5;
    //        }
    //        e.Row.Font.Bold = true;
    //    }
    //}

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow) return;

        object invObj = DataBinder.Eval(e.Row.DataItem, "Invoice_No");
        object payObj = DataBinder.Eval(e.Row.DataItem, "PAY_REFERENCE_NO");
        string invoiceNo = (invObj != null) ? invObj.ToString() : string.Empty;
        string payRefNo = (payObj != null) ? payObj.ToString() : string.Empty;
        bool canEdit = string.IsNullOrWhiteSpace(invoiceNo)
                        && string.IsNullOrWhiteSpace(payRefNo);

        LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
        if (lnkEdit != null)
            lnkEdit.Visible = canEdit;

        if ((e.Row.RowState & DataControlRowState.Edit) > 0)
        {
            ListBox ddl = (ListBox)e.Row.FindControl("ddlJobNoPS");
            DropDownList ddlType = (DropDownList)e.Row.FindControl("ddlShipmentType");
            if (ddl == null || ddlType == null) return;

            string shipmentType = ddlType.SelectedValue;
            ddl.DataSource = GetJobNoList(shipmentType);
            ddl.DataTextField = "JOBNO_PS";
            ddl.DataValueField = "JOBNO_PS";
            ddl.DataBind();

            // Pre-select saved values
            object jobObj = DataBinder.Eval(e.Row.DataItem, "JOBNO_PS");
            string saved = (jobObj != null) ? jobObj.ToString() : string.Empty;

            if (!string.IsNullOrEmpty(saved))
            {
                List<string> savedList = new List<string>();
                foreach (string part in saved.Split(','))
                {
                    string t = part.Trim();
                    if (!string.IsNullOrEmpty(t))
                        savedList.Add(t);
                }

                foreach (ListItem item in ddl.Items)
                {
                    if (savedList.Contains(item.Value.Trim()))
                        item.Selected = true;
                }
            }

            ddl.Enabled = canEdit;

            // ✅ Pass the exact ClientID to initMultiSelect
            // 150ms delay ensures DOM is fully parsed before Select2 runs
            string clientId = ddl.ClientID;
            string script = string.Format(
                "setTimeout(function(){{ initMultiSelect('{0}'); }}, 150);",
                clientId
            );

            ScriptManager.RegisterStartupScript(
                this,
                this.GetType(),
                "select2_" + clientId,
                script,
                true
            );
        }
    }
    private DataTable GetJobNoList(string shipmentType)
    {
        DataTable dtLocal = new DataTable();
        DataSet dsLocal = new DataSet();

        ObjUBO.A8 = "LOAD_JOBNO";
        ObjUBO.A5 = shipmentType;

        dsLocal = Chrg.Bill_To_Shipment_Search(ObjUBO);

        if ( dsLocal.Tables[0].Rows.Count > 0)
        {
            dtLocal = dsLocal.Tables[0];
        }

        return dtLocal;
    }
    protected void gvdetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = gvdetails.Rows[e.RowIndex];

        string invoiceNo = row.Cells[5].Text; // adjust index if needed
        string payRefNo = row.Cells[6].Text;

        // 🔴 BUSINESS RULE CHECK
        if (!string.IsNullOrWhiteSpace(invoiceNo) ||
            !string.IsNullOrWhiteSpace(payRefNo))
        {
            e.Cancel = true;
            return;
        }

        ListBox ddl = (ListBox)row.FindControl("ddlJobNoPS");

        var selectedValues = ddl.Items.Cast<ListItem>()
                                .Where(i => i.Selected)
                                .Select(i => i.Value);

        string jobno_ps = string.Join(",", selectedValues);

        string shipmentNo = gvdetails.DataKeys[e.RowIndex].Value.ToString();

        // ✅ CALL YOUR SP HERE
        ObjUBO.A1 = shipmentNo;
        ObjUBO.A2 = jobno_ps;
        ObjUBO.A7 = "UPDATE_SHIP_NO_JOBNO";

        Chrg.Bill_To_Shipment_Search(ObjUBO);

        gvdetails.EditIndex = -1;
        btnSearch_Click(null, null);
    }

    protected void gvdetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvdetails.EditIndex = e.NewEditIndex;
        btnSearch_Click(null, null); // rebind
    }

    protected void gvdetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvdetails.EditIndex = -1;
        btnSearch_Click(null, null);
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




}