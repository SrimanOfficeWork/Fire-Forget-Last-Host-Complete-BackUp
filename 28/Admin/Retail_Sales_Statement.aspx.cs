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
using System.Windows.Forms;
using System.Data.SqlClient.SqlGen;
using System.Net;
using System.Net.Mail;

public partial class Import_Retail_Sales_Statement_Retail_Sales_Statement : System.Web.UI.Page
{
    Company_Master COMPANY = new Company_Master();
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
    //DataTable dt = new DataTable();
    ErrorLogs err = new ErrorLogs();
    DataTable dt = new DataTable();
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    AppSession aps = new AppSession();
    Internal_Mail mail = new Internal_Mail();
    User_Creation USER = new User_Creation();
    Retail_Stmts Retail1 = new Retail_Stmts();
    //SqlConnection con = new SqlConnection();
    public string getpath;
    public int ii = 1;


    string COMPANY_LICENSE;
    string SERVER_NAME, DATABASE_NAME, LOGIN_NAME, PWD, WORKING_PERIOD;
    DataSet dtuser = new DataSet();

    

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        Session["COMP_LICENSE"] = COMPANY_LICENSE;
       
            currentuser = Session["currentuser"].ToString();
            //currentbranch = Session["currentbranch"].ToString();
            currentcomp_name = Session["currentcomp_name"].ToString();
            //comp_ConnectionStr = Session["currentcomp_db"].ToString();

            Working_Period = Session["WorkingPeriod"].ToString();
            LoginDate = Session["LoginDate"].ToString();

            btnexcel.Visible = false;
            btnpdf.Visible = false;
            btnprint.Visible = false;
            btnMail.Visible = false;

            if (!IsPostBack)
            {
                ddl_ClientNameBind();
               
                //ddlSelect_Branch_Bind();
                btnSearch_Click(sender, e);
          
            }
        //}
    }

    public void ddl_ClientNameBind()
    {

        Retail1.Ename = "All_Retail_ClientName_With_CompanyLicense";
        ddlCutomerName.DataSource = Retail1.RetrieveAll_Company_Details();
        ddlCutomerName.DataValueField = "COMPANY_LICENSE";
        ddlCutomerName.DataTextField = "COMPANY_LICENSE";
        ddlCutomerName.DataBind();
        ddlCutomerName.Items.Remove("0");
        ddlCutomerName.Items.Insert(0, "Select");      
        Session["server"] = ds;
       
    }

    public void ddlSelect_Branch_Bind()
    {
        if (ddlCutomerName.SelectedItem.Text == "Select")
        {

        }
        else
        {

            string ccc = ddlCutomerName.Text;
            string[] parts = ccc.Split(new string[] { "-" }, StringSplitOptions.None);
            string ss = parts[0];
            ViewState["com_license"] = ss;

            string[] p1 = ss.Split(new string[] { "ERI" }, StringSplitOptions.None);
            string p2 = p1[1];

            int id = Convert.ToInt32(p2);
            string getid = Convert.ToString(id);

            Retail1.COMPANY_LICENSE = ss;
            Retail1.COMPANY_ID = getid;
            Retail1.Ename = "Retail_Select_BranchName";
            ddlSelect_Branch.DataSource = Retail1.RetrieveAll_Company_Details();
            ddlSelect_Branch.DataValueField = "BRANCH";
            ddlSelect_Branch.DataTextField = "BRANCH";
            ddlSelect_Branch.DataBind();
            ddlSelect_Branch.Items.Remove("0");
            ddlSelect_Branch.Items.Insert(0, "All");
            Session["server"] = ds;

         
        }
    }

    public void Database_Bind()
    {
        if (ddlCutomerName.SelectedItem.Text == "Select")
        {
            lbltotaltext.Visible = false;
            lblClient_Name.Visible = false;
        }
        else
        {

            string ccc = ddlCutomerName.Text;
            string msg = "Server=";
            string mm = "database=";
            string uid = "uid=";
            string pwd1 = "pwd=";
            string coma = ";";

            Session["ddlCutomerName"] = ddlCutomerName.Text;
            string xxx = Session["ddlCutomerName"].ToString();
            DataTable dt = new DataTable();
            DataColumn dc1 = new DataColumn("SNO", typeof(System.Int32));
            dt.Columns.Add(dc1);

            string[] parts = ccc.Split(new string[] { "-" }, StringSplitOptions.None);
            string ss = parts[0];
            ViewState["com_license"] = ss;

            //COMPANY.Ename = "Database_Check_Servername";
            //COMPANY.COMPANY_LICENSE = ss;
            //dtuser = COMPANY.Retail_RetrieveAll_Database_Details();

            Retail1.Ename = "Database_Check_Servername";
            Retail1.COMPANY_LICENSE = ss;
            dtuser = Retail1.Retail_RetrieveAll_Database_Details();



            if (dtuser.Tables[0].Rows.Count > 0)
            {
                COMPANY_LICENSE = dtuser.Tables[0].Rows[0]["COMPANY_LICENSE"].ToString();
                SERVER_NAME = dtuser.Tables[0].Rows[0]["SERVER_NAME"].ToString();
                DATABASE_NAME = dtuser.Tables[0].Rows[0]["DATABASE_NAME"].ToString();
                LOGIN_NAME = dtuser.Tables[0].Rows[0]["LOGIN_NAME"].ToString();
                PWD = dtuser.Tables[0].Rows[0]["PWD"].ToString();
                WORKING_PERIOD = dtuser.Tables[0].Rows[0]["WORKING_PERIOD"].ToString();


                getpath = msg + SERVER_NAME + coma + mm + DATABASE_NAME + coma + uid + LOGIN_NAME + coma + pwd1 + PWD + coma;
                ViewState["getpath"] = getpath;
                Session["getpath_Retail"] = getpath;
                string xx = ViewState["getpath"].ToString();

                //Session["currentcomp_db"] = getpath;
                SqlConnection con = new SqlConnection(getpath);

                DataSet dsss = new DataSet();
                DataSet dsExport = new DataSet();
                string con_string = getpath;


                using (var conn = new SqlConnection(con_string))
                using (var command = new SqlCommand("SP_RETAIL_SALES_STMTS", conn)
                {

                    CommandType = CommandType.StoredProcedure
                })
                {

                    Retail1.Job_type = ddlSelect_JobType.SelectedItem.Text;
                    Retail1.Tr_mode = ddlTransportMode.SelectedItem.Text;
                    Retail1.Fromdate = txtFrom_Date.Text;
                    Retail1.To_date = txtTo_Date.Text;
                    Retail1.Branch = ddlSelect_Branch.SelectedItem.Text;

                    dc1.AutoIncrement = true;
                    ds = Retail1.Retail_Statement();


                    GridViewImport.Visible = true;
                    GridViewImport.DataSource = ds;
                    GridViewImport.DataBind();

                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lbltotaltext.Visible = true;
                    lblClient_Name.Visible = true;
                    lblClient_Name.Text = Convert.ToString(ds.Tables[0].Rows.Count);

                }
                else
                {
                   
                    lbltotaltext.Visible = false;
                    lblClient_Name.Visible = false;
                    Empty_GridBind();
                   
                }

            }
        }

        
    }

    public void Empty_GridBind()
    {
        if (ddlSelect_JobType.SelectedItem.Text == "Import")
        {

            GridViewImport.HeaderRow.Cells[0].Text = "SNO";
            GridViewImport.HeaderRow.Cells[1].Text = "JOBNO";
            GridViewImport.HeaderRow.Cells[2].Text = "JOBDATE";
            GridViewImport.HeaderRow.Cells[3].Text = "MODE";
            GridViewImport.HeaderRow.Cells[4].Text = "BRANCHCODE";
            GridViewImport.HeaderRow.Cells[5].Text = "IMPORTER_NAME";
            GridViewImport.HeaderRow.Cells[6].Text = "SUPPLIER_NAME";
            GridViewImport.HeaderRow.Cells[7].Text = "INVOICE_NO";
            GridViewImport.HeaderRow.Cells[8].Text = "INVOICE_DATE";


        }
        else
        {
            GridViewImport.HeaderRow.Cells[0].Text = "SNO";
            GridViewImport.HeaderRow.Cells[1].Text = "JOBNO";
            GridViewImport.HeaderRow.Cells[2].Text = "JOBDATE";
            GridViewImport.HeaderRow.Cells[3].Text = "MODE";
            GridViewImport.HeaderRow.Cells[4].Text = "BRANCHCODE";
            GridViewImport.HeaderRow.Cells[5].Text = "EXPORTER_NAME";
            GridViewImport.HeaderRow.Cells[6].Text = "CONSIGNEE_NAME";
            GridViewImport.HeaderRow.Cells[7].Text = "INVOICE_NO";
            GridViewImport.HeaderRow.Cells[8].Text = "INVOICE_DATE";
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (ddlCutomerName.SelectedItem.Text == "Select")
        {
            lbltotaltext.Visible = false;
            lblClient_Name.Visible = false;
            //Alert_msg("Select ClientName");
            //lbltotaltext.Text = "No Records";
            //GridViewImport.Visible = false;
            btnexcel.Visible = false;
            btnpdf.Visible = false;
            btnprint.Visible = false;
            btnMail.Visible = false;

        }
        else
        {
            lbltotaltext.Visible = true;
            lblClient_Name.Visible = true;
            GridViewImport.Visible = true;
            btnexcel.Visible = true;
            btnpdf.Visible = true;
            btnprint.Visible = true;
            btnMail.Visible = true;
            //ddlSelect_Branch_Bind();
            Database_Bind();
            //GridBind_SearchAll();
        }
      
    }


    private void GridBind_SearchAll()
    {
        Database_Bind();
      
    }
    protected void ddlCutomerName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCutomerName.SelectedItem.Text == "Select")
        {
            lbltotaltext.Visible = false;
            lblClient_Name.Visible = false;
            Alert_msg("Select ClientName");
            lbltotaltext.Text = "No Records";
            GridViewImport.Visible = false;
            btnexcel.Visible = false;
            btnpdf.Visible = false;
            btnprint.Visible = false;
            btnMail.Visible = false;
           
            
        }
        else
        {
            lbltotaltext.Visible = true;
            lblClient_Name.Visible = true;
            GridViewImport.Visible = true;
            btnexcel.Visible = true;
            btnpdf.Visible = true;
            btnprint.Visible = true;
            btnMail.Visible = true;
            ddlSelect_Branch_Bind();
            GridBind_SearchAll();
        }
                
    }

    protected void GridViewImport_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (ddlSelect_JobType.SelectedItem.Text == "Import")
            {

                GridViewImport.HeaderRow.Cells[0].Text = "SNO";
                GridViewImport.HeaderRow.Cells[1].Text = "JOBNO";
                GridViewImport.HeaderRow.Cells[2].Text = "JOBDATE";
                GridViewImport.HeaderRow.Cells[3].Text = "MODE";
                GridViewImport.HeaderRow.Cells[4].Text = "BRANCHCODE";
                GridViewImport.HeaderRow.Cells[5].Text = "IMPORTER_NAME";
                GridViewImport.HeaderRow.Cells[6].Text = "SUPPLIER_NAME";
                GridViewImport.HeaderRow.Cells[7].Text = "INVOICE_NO";
                GridViewImport.HeaderRow.Cells[8].Text = "INVOICE_DATE";


            }
            else
            {
                GridViewImport.HeaderRow.Cells[0].Text = "SNO";
                GridViewImport.HeaderRow.Cells[1].Text = "JOBNO";
                GridViewImport.HeaderRow.Cells[2].Text = "JOBDATE";
                GridViewImport.HeaderRow.Cells[3].Text = "MODE";
                GridViewImport.HeaderRow.Cells[4].Text = "BRANCHCODE";
                GridViewImport.HeaderRow.Cells[5].Text = "EXPORTER_NAME";
                GridViewImport.HeaderRow.Cells[6].Text = "CONSIGNEE_NAME";
                GridViewImport.HeaderRow.Cells[7].Text = "INVOICE_NO";
                GridViewImport.HeaderRow.Cells[8].Text = "INVOICE_DATE";
            }
            e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
            e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Left;
            e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Left;
            e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Left;

           


            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            //e.Row.Attributes["onmouseout"] = "this.style.background='white'";
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.GridViewImport, "Select$" + e.Row.RowIndex.ToString()));

        }

    }

    protected void GridViewImport_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //Add CSS class on header row.
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        //Add CSS class on normal row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        //Add CSS class on alternate row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";

       
      
    }

    protected void GridViewImport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewImport.PageIndex = e.NewPageIndex;
        //Gridbind_INVOICE();
        //gv_Invoice.DataBind();
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Retail Sales List', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

   
}