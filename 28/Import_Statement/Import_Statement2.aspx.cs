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

public partial class Import_Statement2 : ThemeClass
{
    //Date_Time dt = new Date_Time();
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
    DataTable dt = new DataTable();
    DailyStatusRpt DSR1 = new DailyStatusRpt();
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string Company_ID;
    public string LoginDate;
    AppSession aps = new AppSession();
    public string SELECT_TYPE, SELECT_BRANCH;
   
    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    aps.checkSession();
    //    currentuser = Session["currentuser"].ToString();
    //    //currentbranch = Session["currentbranch"].ToString();
    //    currentcomp_name = Session["currentcomp_name"].ToString();
    //    //comp_ConnectionStr = Session["currentcomp_db"].ToString();
    //    Company_ID = Session["COMPANY_ID"].ToString();

    //    Working_Period = Session["WorkingPeriod"].ToString();
    //    LoginDate = Session["LoginDate"].ToString();
    //   // iframe1.Attributes["src"] = "Import_Job_RegisterNew.aspx?JobNo=" + txtJobNo.Text + "&Importer=" + txtImporterName.Text + "&Supplier=" + txtSupplierName.Text + "&FromDate=" + txtFrom_Date.Text + "&ToDate=" + txtTo_Date.Text + "";
      
    //    iframe1.Visible = false;

    //    Bind_ClientMasterName();
    //    Bind_Branches();
    //}

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Company_ID = Session["COMPANY_ID"].ToString();


        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

        if (Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = Session["SELECT_TYPE"].ToString();

            if (SELECT_TYPE == "Branchwise Job")
            {
                SELECT_BRANCH = currentbranch;
            }
            else
            {
                SELECT_BRANCH = "";
                if (!IsPostBack)
                {
                    Bind_ClientMasterName();
                    Bind_Branches();
                }
            }
        }
        else
        {
            SELECT_BRANCH = "";
        }


        if (!IsPostBack)
        {
            Bind_ClientMasterName();
            Bind_Branches();
            //Data_Bind();
        }

    }

    public void Bind_ClientMasterName()
    {

        DSR1.Ename = "Bind_IMP_EXP_Name";
        ds = DSR1.DS_Report();

        ddlCutomerName.DataSource = ds.Tables[0];
        ddlCutomerName.DataTextField = "IMP_EXP_NAME";
        ddlCutomerName.DataValueField = "IMP_EXP_NAME";
        ddlCutomerName.DataBind();
        ddlCutomerName.Items.Remove("0");
        ddlCutomerName.Items.Insert(0, "All");

    }

    public void Bind_Branches()
    {
        string id = Company_ID;

        DSR1.companyId = id;
        DSR1.Ename = "Bind_Branches";
        ds = DSR1.DS_Report();

        ddlBranchCode.DataSource = ds.Tables[0];
        ddlBranchCode.DataTextField = "BRANCH";
        ddlBranchCode.DataValueField = "BRANCH";
        ddlBranchCode.DataBind();

        if (SELECT_BRANCH == currentbranch)
        {
            ddlBranchCode.Text = currentbranch;

        }
        else
        {
            ddlBranchCode.Items.Remove("0");
            ddlBranchCode.Items.Insert(0, "All");
        }

    }

    //protected void ddlCutomerName_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    //Data_Bind();
    //}

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        iframe1.Visible = true;

        iframe1.Attributes["src"] = "Import_Statement_ReportViewer.aspx?Importer=" + ddlCutomerName.SelectedItem.Text + "&Trans_mode=" + ddlTransport_Mode.SelectedValue.ToString().Replace("Select", "") + "&FromDate=" + txtFrom_Date.Text + "&ToDate=" + txtTo_Date.Text + "&JobDate=" + txtjobdate.Text + "&Branch=" + ddlBranchCode.SelectedValue.ToString().Replace("Select", "") + "";

        //iframe1.Attributes["src"] = "Import_Statement_ReportViewer.aspx?JobNo=" + txtJobNo.Text + "&Importer=" + ddlCutomerName.SelectedItem.Text + "&Supplier=" + txtSupplierName.Text + "&FromDate=" + txtFrom_Date.Text + "&ToDate=" + txtTo_Date.Text + "&JobDate=" + txtjobdate.Text + "&Trans_mode=" + ddlBranchCode.SelectedValue.ToString().Replace("Select", "") + "";
        //Response.Redirect("Import_Job_RegisterNew.aspx?JobNo='" + txtJobNo.Text + "'&Importer='" + txtImporterName.Text + "'&Supplier='" + txtSupplierName.Text + "'&FromDate='" + txtFrom_Date.Text + "'&ToDate='" + txtTo_Date.Text + "''");
    }

    protected void ddlBranchCode_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
