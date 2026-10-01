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
            Bind_dd_JOB_TYPE();
            ddlBind();
            iframe1.Visible = false;

        }
    }
    public void ddlBind()
    {
        mail.flag = "BIND_USERNAME";
        mail.FROM_DATE = "";
        mail.TO_DATE = "";
        ddl_UserList.Items.Clear();
        ddl_UserList.DataSource = mail.GetMail();
        ddl_UserList.DataTextField = "USER_NAME";
        ddl_UserList.DataValueField = "USER_NAME";
        ddl_UserList.DataBind();
        ddl_UserList.Items.Insert(0, "All");
    }
    public void Bind_dd_JOB_TYPE()
    {
        ddl_jobtype.Items.Clear();
        if (Session["JOB_TYPE"].ToString() == "Both")
        {
            //ddl_jobtype.Items.Add(Session["JOB_TYPE"].ToString());
            ddl_jobtype.Items.Add("Import");
            ddl_jobtype.Items.Add("Export");


        }
        if (Session["JOB_TYPE"].ToString() == "Import")
        {
            ddl_jobtype.Items.Add(Session["JOB_TYPE"].ToString());
           
        }
        if (Session["JOB_TYPE"].ToString() == "Export")
        {
            ddl_jobtype.Items.Add(Session["JOB_TYPE"].ToString());
           
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        iframe1.Visible = true;

        iframe1.Attributes["src"] = "User_wise_Report_IFrame.aspx?JobType=" + ddl_jobtype.SelectedValue.ToString() + "&User=" + ddl_UserList.SelectedValue.ToString() + "&JobNo=" + txtJobNo.Text + "&FromDate=" + txtFrom_Date.Text + "&ToDate=" + txtTo_Date.Text + "&JobDate=" + txtjobdate.Text + "";
        //Response.Redirect("Import_Job_RegisterNew.aspx?JobNo='" + txtJobNo.Text + "'&Importer='" + txtImporterName.Text + "'&Supplier='" + txtSupplierName.Text + "'&FromDate='" + txtFrom_Date.Text + "'&ToDate='" + txtTo_Date.Text + "''");
    }
    
}
