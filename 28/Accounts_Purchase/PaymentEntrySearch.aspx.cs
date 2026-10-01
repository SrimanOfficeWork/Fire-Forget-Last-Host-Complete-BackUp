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

public partial class PaymentEntrySearch : ThemeClass
{
    AppSession aps = new AppSession();
    User_Creation user_Create = new User_Creation();

    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };


    PaymentEntry_cs PE = new PaymentEntry_cs();
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
            load_Vendor_Name();
            Load_Grid_Data();
        }
    }
    private void load_Vendor_Name()
    {
        ObjUBO.A15 = "Ven_Name_Select";
        ds = PE.Payment_Entry_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlVendorname.DataSource = ds.Tables[0];
            ddlVendorname.DataTextField = "VEN_NAME";
            ddlVendorname.DataValueField = "VEN_NAME";
            ddlVendorname.DataBind();
        }
        ddlVendorname.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlVendorname.SelectedIndex = 0;
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
        DataSet ds = new DataSet();
        ObjUBO.A4 = txt_Payment_No.Text;
        ObjUBO.A3 = ddlVendorname.SelectedValue.ToString();

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
        ObjUBO.A5 = "Load_Grid_Data";
        ds = PE.Payment_Entry_Search(ObjUBO);
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
            string values = this.gvdetails.DataKeys[e.Row.RowIndex]["P_ID"].ToString();
            string PaymentVoucherNo = this.gvdetails.DataKeys[e.Row.RowIndex]["PAYMENT_NO"].ToString();
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("ondblclick", "open_Payment_Upd('" + values + "','" + PaymentVoucherNo + "')");
            rowID = e.Row.RowIndex.ToString();
            e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
            e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + values + "','" + PaymentVoucherNo + "')");
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