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

public partial class Acc_PurchaseBillSearch : ThemeClass
{
    AppSession aps = new AppSession();
    User_Creation user_Create = new User_Creation();

    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };

    Acc_PurchaseBill_Entry_cs PC = new Acc_PurchaseBill_Entry_cs();
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
            Load_Grid_Data();
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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Load_Grid_Data();
    }
    private void Load_Grid_Data()
    {
        DataSet ds = new DataSet();

        // Voucher Date Range
        if (txtFdate.Text != string.Empty || txtTodate.Text != string.Empty)
        {
            ObjUBO.A1 = txtFdate.Text;     // Voucher From Date
            ObjUBO.A2 = txtTodate.Text;   // Voucher To Date
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

        // Search Criteria
        ObjUBO.A3 = txt_Organisation.Text.Trim();             // Organisation
        ObjUBO.A4 = txt_TransNo.Text.Trim();                  // Transaction No
        ObjUBO.A5 = ddl_Location.SelectedValue;               // Location
        ObjUBO.A6 = txt_Ven_Inv_No.Text.Trim();               // Vendor Invoice No
        ObjUBO.A7 = txt_Narration.Text.Trim();                // Narration
        ObjUBO.A8 = ddl_Status.SelectedValue;                 // Status
        ObjUBO.A9 = ddl_disputeStatus.SelectedValue;          // Dispute Status
        ObjUBO.A10 = ddlMonth.SelectedValue;                  // Month

        // Action
        ObjUBO.A11 = "Load_Grid_Data";
        ds = PC.Purchase_Entry_Select(ObjUBO);
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

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string rowID = String.Empty;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string PC_ID = this.gvdetails.DataKeys[e.Row.RowIndex]["PC_ID"].ToString();
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("ondblclick", "open_Purchase_Entry_Update('" + PC_ID + "')");
            rowID = e.Row.RowIndex.ToString();
            e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
            e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + PC_ID + "')");
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
}