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

public partial class Admin_Sales_Statement : ThemeClass
{
    //Date_Time dt = new Date_Time();
    Company_Master Comp = new Company_Master();
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
    Internal_Mail mail = new Internal_Mail();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        //currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        //comp_ConnectionStr = Session["currentcomp_db"].ToString();

        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        if (!IsPostBack)
        {
            ddl_Client_Database_Bind();
          
            iframe1.Visible = false;

        }
    }

    public void ddl_Client_Database_Bind()
    {

        Comp.Ename = "All_ClientName_With_CompanyLicense";
      
        ds = Comp.RetrieveAll_Company_Details();
        ViewState["ds"] = ds.Tables[0];

        ViewState["ds1"] = ds.Tables[1];
        ddlCutomerID.DataSource = ds.Tables[0];
        ddlCutomerID.DataTextField = "COMPANY_LICENSE";
        ddlCutomerID.DataValueField = "COMPANY_LICENSE";
        ddlCutomerID.DataBind();
        ddlCutomerID.Items.Insert(0, "Select");
        //-------------------------load working period--------------------//

        if (ddlCutomerID.SelectedValue == "Select")
        {
            lblClient_Name.Text = "";
        }
        else
        {
            lblClient_Name.Text = ds.Tables[0].Rows[0]["CLIENT_NAME"].ToString();
        }

        Session["server"] = ds;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (ddlCutomerID.SelectedValue != "Select")
        {
            iframe1.Visible = true;

            iframe1.Attributes["src"] = "Sales_Statement_IFrame.aspx?CustomerID=" + ddlCutomerID.SelectedValue.ToString() + "&JobType=" + ddlSelect_JobType.SelectedValue.ToString() + "&FromDate=" + txtFrom_Date.Text + "&ToDate=" + txtTo_Date.Text + "&Branch=" + ddlSelect_Branch.SelectedValue.ToString() + "&Client=" + lblClient_Name.Text + "";
            //Response.Redirect("Import_Job_RegisterNew.aspx?JobNo='" + txtJobNo.Text + "'&Importer='" + txtImporterName.Text + "'&Supplier='" + txtSupplierName.Text + "'&FromDate='" + txtFrom_Date.Text + "'&ToDate='" + txtTo_Date.Text + "''");
        }
    }
    protected void ddlCutomerID_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        if (ddlCutomerID.SelectedValue != "Select")
        {

            DataTable dv = new DataTable();
            dv = (DataTable)ViewState["ds"];
            DataView view1 = dv.DefaultView;
            view1.RowFilter = "COMPANY_LICENSE = '" + ddlCutomerID.SelectedValue.ToString() + "'";
            DataTable table1 = view1.ToTable();
            lblClient_Name.Text = table1.Rows[0]["CLIENT_NAME"].ToString();


            DataTable dv1 = new DataTable();
            dv1 = (DataTable)ViewState["ds1"];
            DataView view2 = dv1.DefaultView;
            view2.RowFilter = "COMPANY_LICENSE = '" + ddlCutomerID.SelectedValue.ToString() + "'";
            DataTable table2 = view2.ToTable();

            Session["server"] = table2.Rows[0]["SERVER_NAME"].ToString();
            //string ser = table2.Rows[0]["SERVER_NAME"].ToString();
        }
    }
}