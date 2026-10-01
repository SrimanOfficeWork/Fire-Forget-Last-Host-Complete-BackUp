using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using Microsoft.Reporting.WebForms;
using Microsoft.ReportingServices.Rendering;
using Microsoft.ReportingServices.Library;

public partial class GST_Imp_Invoice_Job_Search : ThemeClass
{
    AppSession aps = new AppSession();
    //GST_Imp_Invoice BI = new GST_Imp_Invoice();
    Account_Statement AS = new Account_Statement();
    Billing_UserBO ObjUBO = new Billing_UserBO();

    public string Working_Period;

    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };

    string Start_date = string.Empty , End_date = string.Empty, From_month = string.Empty, To_month = string.Empty;


    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        Working_Period = Session["WorkingPeriod"].ToString();
        
        if (!IsPostBack)
        {
            //Load_Month();
            load_Imp_name();
            //load_ledger_name();
            load_job_no();
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
    
    
    private void Load_Grid()
    {
        DataSet ds1 = new DataSet();
        if (txtfromdate.Text != string.Empty || txttodate.Text != string.Empty)
        {
            ObjUBO.from_date = txtfromdate.Text;
            ObjUBO.todate = txttodate.Text;
        }
        Session["Click_Y_N"] = "Y";
        iframe1.Visible = true;
        //iframe1.Attributes["src"] = "Expense_Based_Rpt.aspx?Imp_Exp_Name=" + (ddl_Imp_Exp_Category.SelectedValue.ToString()) + "&from_date=" + ObjUBO.from_date + "&todate=" + ObjUBO.todate + "&Rpt_type=" + ddl_Rpt_type.SelectedValue.ToString() + "&Tr_Mode=" + (ddl_Tr_Mode_Category.SelectedValue.ToString()) + "&Party_Name=" + (ddlImp_name.SelectedValue.ToString()) + "";

        string partyName = ddlImp_name.SelectedItem.Text; // Get the full party name from the dropdown
        Session["Expense_Party_Name"] = ddlImp_name.SelectedItem.Text;

        // Construct the URL with the full party name
        iframe1.Attributes["src"] = "Payment_Outstanding_Based_Rpt.aspx?Imp_Exp_Name=" + (ddl_Imp_Exp_Category.SelectedValue.ToString()) + "&from_date=" + ObjUBO.from_date + "&todate=" + ObjUBO.todate + "&Party_Name=" + partyName + "&Job_Number=" + (ddlJob_No.SelectedValue.ToString()) + "";


    }

    private void load_Imp_name()
    {
        ddlImp_name.Items.Clear();
        //ddlCharge_name.Items.Clear();

        DataSet ds = new DataSet();
        ObjUBO.Expense_Party_Name = "";
        ObjUBO.Expense_Select_Flag = "Payment_Vendor_Name";

        //ds = BI.Select_IMP_INV(ObjUBO);
        ds = AS.Expense_Select_Dropdown_Rpt(ObjUBO);

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlImp_name.DataSource = ds.Tables[0];
            ddlImp_name.DataTextField = "VENDOR_NAME";
            ddlImp_name.DataValueField = "VENDOR_NAME";
            ddlImp_name.DataBind();
        }
        //ddlImp_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        //ddlImp_name.SelectedIndex = 0;

        ddlImp_name.Items.Insert(0, new ListItem("All", "All"));
        ddlImp_name.SelectedIndex = 0;

    }

    private void load_job_no()
    {
        ddlJob_No.Items.Clear();
        
        DataSet ds1 = new DataSet();
        ObjUBO.Expense_Party_Name = "";
        ObjUBO.Expense_Select_Flag = "Payment_Job_Name";

        ds1 = AS.Expense_Select_Dropdown_Rpt(ObjUBO);

        if (ds1.Tables[0].Rows.Count > 0)
        {
            ddlJob_No.DataSource = ds1.Tables[0];
            ddlJob_No.DataTextField = "JOBNO";
            ddlJob_No.DataValueField = "JOBNO";
            ddlJob_No.DataBind();
        }

        ddlJob_No.Items.Insert(0, new ListItem("All", "All"));
        ddlJob_No.SelectedIndex = 0;

    }
  
}