using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using GeneraReport;
using Microsoft.Reporting.WebForms;

public partial class Import_Statement_Import_Job_Register : ThemeClass
{
    //Date_Time dt = new Date_Time();
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
    DataTable dt = new DataTable();
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    AppSession aps = new AppSession();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        //currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        //comp_ConnectionStr = Session["currentcomp_db"].ToString();

        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
       // iframe1.Attributes["src"] = "Import_Job_RegisterNew.aspx?JobNo=" + txtJobNo.Text + "&Importer=" + txtImporterName.Text + "&Supplier=" + txtSupplierName.Text + "&FromDate=" + txtFrom_Date.Text + "&ToDate=" + txtTo_Date.Text + "";
      
        iframe1.Visible = false;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        iframe1.Visible = true;

        iframe1.Attributes["src"] = "Export_Job_RegisterNew.aspx?JobNo=" + txtJobNo.Text + "&Exporter=" + txtImporterName.Text + "&Consignee=" + txtSupplierName.Text + "&InvoiceNo=" + txtInoviceNo.Text + "&FromDate=" + txtFrom_Date.Text + "&ToDate=" + txtTo_Date.Text + "&JobDate=" + txtjobdate.Text + "&Trans_mode=" + ddlTransportMode.SelectedValue.ToString().Replace("Select", "") + "";
        //Response.Redirect("Import_Job_RegisterNew.aspx?JobNo='" + txtJobNo.Text + "'&Importer='" + txtImporterName.Text + "'&Supplier='" + txtSupplierName.Text + "'&FromDate='" + txtFrom_Date.Text + "'&ToDate='" + txtTo_Date.Text + "''");
    }
    
}
