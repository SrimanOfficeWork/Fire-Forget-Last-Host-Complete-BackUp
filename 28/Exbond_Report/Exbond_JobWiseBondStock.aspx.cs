using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using Microsoft.Reporting.WebForms;
using System.Windows.Forms;
using System.Text;
using System.Configuration;
using System.Drawing.Printing;

public partial class Exbond_Report_Exbond_JobWiseBondStock : System.Web.UI.Page
{
    public string Working_Period;
    public string SELECT_TYPE, SELECT_BRANCH;
    public string currentbranch;

    Date_Time dt = new Date_Time();
    Transaction Transact = new Transaction();
    AppSession aps = new AppSession();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentbranch = Session["currentbranch"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
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
            }
        }
        else
        {
            SELECT_BRANCH = "";
        }

        if (!IsPostBack)
        {

            WareHouse_JobNo_Load();

        }

        //txtDate.Text = dt.Today_Date();


    }

    public void WareHouse_JobNo_Load()
    {
        Transact.JOBNO = "";

        Transact.Ename = "select_Warehouse_JobNo";
        Transact.WORKING_PERIOD = SELECT_BRANCH;

        // dtuser = Transact.RetrieveAll_General_Details();

        ddlWarehouse_JobNo.DataSource = Transact.RetrieveAll_Warehouse_Job_Details();
        ddlWarehouse_JobNo.DataValueField = "JOBNO";
        ddlWarehouse_JobNo.DataTextField = "JOBNO";
        ddlWarehouse_JobNo.DataBind();
        ddlWarehouse_JobNo.Items.Remove("0");
        ddlWarehouse_JobNo.Items.Insert(0, "Select");
        // return dtuser;

    }


  
    protected void BtnPrint_Click(object sender, EventArgs e)
    {
        //MessageBox.Show("hh");
    }
}