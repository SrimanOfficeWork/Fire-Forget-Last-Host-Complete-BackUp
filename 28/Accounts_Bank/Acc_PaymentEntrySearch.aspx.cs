using System;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.Web.UI;

public partial class Acc_PaymentEntrySearch : ThemeClass
{
    AppSession aps = new AppSession();
    User_Creation user_Create = new User_Creation();

    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };

    Payment_Entry_Debitors RE = new Payment_Entry_Debitors();
    Payment_Entry_Cash_Withdrawal PCW = new Payment_Entry_Cash_Withdrawal();

    Global_variables ObjUBO = new Global_variables();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    private DataSet GridData
    {
        get
        {
            return ViewState["GridData"] as DataSet;
        }
        set { ViewState["GridData"] = value; }
    }
    private string SortExpression
    {
        get { return ViewState["SortExpression"] as string ?? string.Empty; }
        set { ViewState["SortExpression"] = value; }
    }
    private string SortDirection
    {
        get { return ViewState["SortDirection"] as string ?? string.Empty; }
        set { ViewState["SortDirection"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        if (!IsPostBack)
        {
            HDBranch.Value = Connection.Get_Company_Type();
            Load_Month();
            load_Party_Name();
            Load_Grid_Data();
        }
    }
    private void load_Party_Name()
    {
        ObjUBO.A40 = "Bank_Payment_Search_Partyname_select";
        ds = RE.BP_Payment_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlPartyname.DataSource = ds.Tables[0];
            ddlPartyname.DataTextField = "Ledger";
            ddlPartyname.DataValueField = "Ledger_val";
            ddlPartyname.DataBind();
        }
        ddlPartyname.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlPartyname.SelectedIndex = 0;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            Load_Grid_Data();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void Load_Grid_Data()
    {
        try
        {

            ObjUBO.A3 = txt_Payment_No.Text;
            ObjUBO.A5 = ddlPartyname.SelectedValue.ToString();

            if (txtFdate.Text != string.Empty || txtTodate.Text != string.Empty)
            {
                ObjUBO.A1 = txtFdate.Text;
                ObjUBO.A2 = txtTodate.Text;
            }
            else
            {
                if (ddlMonth.SelectedItem.Text != string.Empty)
                {
                    arr_Month = ddlMonth.SelectedValue.ToString().Split('-');
                    ObjUBO.A1 = arr_Month[0];
                    ObjUBO.A2 = arr_Month[1];
                }
                else
                {
                    ObjUBO.A1 = txtFdate.Text;
                    ObjUBO.A2 = txtTodate.Text;
                }
            }
            ObjUBO.A4 = ddl_Payment.SelectedValue;
            ObjUBO.A40 = "Load_Grid_Data";

            GridData = PCW.Acc_Gst_Payment_Grid_Search(ObjUBO);
            if (GridData.Tables[0].Rows.Count > 0)
            {
                gvdetails.DataSource = GridData.Tables[0];
            }
            else
            {
                gvdetails.DataSource = dt;
            }
            gvdetails.DataBind();

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.CssClass = "header";
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                LinkButton SortLink = null;
                foreach (Control LinkBtn in e.Row.Cells[i].Controls)
                {
                    if (LinkBtn is LinkButton)
                    {
                        SortLink = (LinkButton)LinkBtn;
                    }
                }
                if (SortLink != null && !string.IsNullOrEmpty(SortLink.CommandArgument))
                {
                    string Icon = "▲▼";
                    if (SortExpression == SortLink.CommandArgument)
                    {
                        Icon = SortDirection == "ASC" ? "▲" : "▼";
                    }
                    SortLink.Text += "<span class='sort-icon'>" + Icon + "</span>";
                }
            }
        }
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string jobno = string.Empty;
        string rowID = String.Empty;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string values, ReceiptNo;
            string Payment_Type = this.gvdetails.DataKeys[e.Row.RowIndex]["PAYMENT_TYPE"].ToString();
            if (ddl_Payment.SelectedValue == "Payment_Creditors" || (ddl_Payment.SelectedValue == "All" && Payment_Type == "PE"))
            {
                values = this.gvdetails.DataKeys[e.Row.RowIndex]["R_ID"].ToString();
                ReceiptNo = this.gvdetails.DataKeys[e.Row.RowIndex]["PAYMENT_NO"].ToString();
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                e.Row.Attributes.Add("ondblclick", "open_PaymentEntry_Deb_Upd('" + values + "','" + ReceiptNo + "')");
                rowID = e.Row.RowIndex.ToString();
                e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
                e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + values + "','" + ReceiptNo + "')");

            }
            else if (ddl_Payment.SelectedValue == "Other_Payment")
            {
                values = this.gvdetails.DataKeys[e.Row.RowIndex]["R_ID"].ToString();
                ReceiptNo = this.gvdetails.DataKeys[e.Row.RowIndex]["PAYMENT_NO"].ToString();
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                e.Row.Attributes.Add("ondblclick", "open_Payment_Entry_Others_Upd('" + values + "','" + ReceiptNo + "')");
                rowID = e.Row.RowIndex.ToString();
                e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
                e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + values + "','" + ReceiptNo + "')");
            }
            else if (ddl_Payment.SelectedValue == "Other_Payment_New" || (ddl_Payment.SelectedValue == "All" && Payment_Type == "E_OP"))
            {
                values = this.gvdetails.DataKeys[e.Row.RowIndex]["R_ID"].ToString();
                ReceiptNo = this.gvdetails.DataKeys[e.Row.RowIndex]["R_ID"].ToString();
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                e.Row.Attributes.Add("ondblclick", "open_OtherPayment_entry_Update_v1('" + values + "','" + ReceiptNo + "')");
                rowID = e.Row.RowIndex.ToString();
                e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
                e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + values + "','" + ReceiptNo + "')");
            }
            else if (ddl_Payment.SelectedValue == "Cash_Withdrawal")
            {
                values = this.gvdetails.DataKeys[e.Row.RowIndex]["R_ID"].ToString();
                ReceiptNo = this.gvdetails.DataKeys[e.Row.RowIndex]["PAYMENT_NO"].ToString();
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                e.Row.Attributes.Add("ondblclick", "open_Payment_Entry_Cash_withdrawal_Upd('" + values + "','" + ReceiptNo + "')");
                rowID = e.Row.RowIndex.ToString();
                e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
                e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + values + "','" + ReceiptNo + "')");
            }
            else if (ddl_Payment.SelectedValue == "Cash_Withdrawal_New" || (ddl_Payment.SelectedValue == "All" && Payment_Type == "CW"))
            {
                values = this.gvdetails.DataKeys[e.Row.RowIndex]["R_ID"].ToString();
                ReceiptNo = this.gvdetails.DataKeys[e.Row.RowIndex]["R_ID"].ToString();
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                e.Row.Attributes.Add("ondblclick", "open_CashWithdrawal_Update_v1('" + values + "','" + ReceiptNo + "')");
                rowID = e.Row.RowIndex.ToString();
                e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
                e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + values + "','" + ReceiptNo + "')");
            }
        }
    }
    private void Load_Month()
    {
        DataSet ds = new DataSet();
        ds = Common_CS.Load_Month();

        ddlMonth.DataSource = ds.Tables[0];
        ddlMonth.DataTextField = "TheMonth";
        ddlMonth.DataValueField = "TheMonth_No";
        ddlMonth.DataBind();

        ddlMonth.Items.Insert(ddlMonth.Items.Count, new ListItem(String.Empty, String.Empty));
        //ddlMonth.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
        ddlMonth.SelectedValue = "";
    }

    protected void gvdetails_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (GridData == null)
        {
            return;
        }
        if (e.SortExpression == SortExpression)
        {
            SortDirection = (SortDirection == "ASC") ? "DESC" : "ASC";
        }
        else
        {
            SortDirection = "ASC";
        }
        SortExpression = e.SortExpression;
        GridData.Tables[0].DefaultView.Sort = e.SortExpression + " " + SortDirection;
        gvdetails.DataSource = GridData.Tables[0].DefaultView;
        gvdetails.DataBind();
    }
}