using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Cash_Payment_Search : ThemeClass
{
    AppSession aps = new AppSession();
    Cash_Payment_Entry_cs CP = new Cash_Payment_Entry_cs();

    Global_variables ObjUBO = new Global_variables();

    DataTable dt = new DataTable();
    DataSet ds = new DataSet();

    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();       
        hdrowindex.Value = String.Empty;
        hdBill_invno.Value = String.Empty;

        if (!IsPostBack)
        {
            //load_Paymentno();
            Load_Month();
            btnSearch_Click(sender, e);
        }
    }
 
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Load_Grid();
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
            string values = this.gvdetails.DataKeys[e.Row.RowIndex]["CP_ID"].ToString();
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("ondblclick", "open_Cash_PaymentEntry_Upd('" + values + "')");       
            rowID = e.Row.RowIndex.ToString();
            e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
            e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + values + "')");

            e.Row.Font.Bold = true;
        }
    }
    
    private void Load_Month()
    {
        DataSet ds = new DataSet();
        ds = Common_CS.Load_Month();
        ddlmonth.DataSource = ds.Tables[0];
        ddlmonth.DataTextField = "TheMonth";
        ddlmonth.DataValueField = "TheMonth_No";
        ddlmonth.DataBind();
        ddlmonth.Items.Insert(ddlmonth.Items.Count, new ListItem(String.Empty, String.Empty));
        ddlmonth.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
    }
    private void Load_Grid()
    {
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
        ObjUBO.A3 = txt_Payment_No.Text;
        ObjUBO.A40 = "Grid_Search";
        ds = CP.Cash_Payment_Search(ObjUBO);
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
    /*
    private void load_Paymentno()
    {
        ddl_Paymentno.Items.Clear();
        DataSet ds = new DataSet();
        ObjUBO.A40 = "Cp_No_Search_Select";
        ds = CP.Cash_Payment_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl_Paymentno.DataSource = ds.Tables[0];
            ddl_Paymentno.DataTextField = "CP_NO";
            ddl_Paymentno.DataValueField = "CP_NO";
            ddl_Paymentno.DataBind();
        }
        ddl_Paymentno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddl_Paymentno.SelectedIndex = 0;
    }
    */
    
}