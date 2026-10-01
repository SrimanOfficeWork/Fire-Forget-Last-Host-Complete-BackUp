using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.Text;
using System.IO;
using System.Globalization;

public partial class ReceiptEntrySearch : ThemeClass
{
    AppSession aps = new AppSession();
    User_Creation user_Create = new User_Creation();

    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };

    ReceiptEntry_cs RE = new ReceiptEntry_cs();
    Global_variables ObjUBO = new Global_variables();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();

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
        ObjUBO.A40 = "Bank_Rec_Search_Partyname_select";
        ds = RE.BR_Receipt_Select(ObjUBO);
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
            DataSet ds = new DataSet();
            ObjUBO.A3 = txt_Receipt_No.Text;
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
            ObjUBO.A4 = ddl_Receipt.SelectedValue;
            ObjUBO.A40 = "Load_Grid_Data";
           
            ds = RE.Acc_Gst_Recipit_Grid_Search(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvdetails.DataSource = ds.Tables[0];
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
            e.Row.CssClass = "header";
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
            if (ddl_Receipt.SelectedValue == "Receipt_Debtors")
            {
                values = this.gvdetails.DataKeys[e.Row.RowIndex]["R_ID"].ToString();
                ReceiptNo = this.gvdetails.DataKeys[e.Row.RowIndex]["RECEIPT_NO"].ToString();
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                e.Row.Attributes.Add("ondblclick", "open_Receipt_Entry_RC_N_Upd('" + values + "','" + ReceiptNo + "')");
                rowID = e.Row.RowIndex.ToString();
                e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
                e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + values + "','" + ReceiptNo + "')");

            }
            else if (ddl_Receipt.SelectedValue == "Other_Receipts")
            {
                values = this.gvdetails.DataKeys[e.Row.RowIndex]["R_ID"].ToString();
                ReceiptNo = this.gvdetails.DataKeys[e.Row.RowIndex]["RECEIPT_NO"].ToString();
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                e.Row.Attributes.Add("ondblclick", "open_Receipt_Entry_Others_Upd('" + values + "','" + ReceiptNo + "')");
                rowID = e.Row.RowIndex.ToString();
                e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
                e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + values + "','" + ReceiptNo + "')");

            }
            else
            {
                values = this.gvdetails.DataKeys[e.Row.RowIndex]["R_ID"].ToString();
                ReceiptNo = this.gvdetails.DataKeys[e.Row.RowIndex]["RECEIPT_NO"].ToString();
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                e.Row.Attributes.Add("ondblclick", "open_Receipt_Entry_Cash_Dep_Upd('" + values + "','" + ReceiptNo + "')");
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
        ddlMonth.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
    }
   
}