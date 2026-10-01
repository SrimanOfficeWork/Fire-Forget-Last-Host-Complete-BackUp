using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Web;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class Users_Default_Settings : System.Web.UI.Page
{
    AppSession aps = new AppSession();
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string JOB_LOCK;
    public string SELECT_TYPE, SELECT_BRANCH;
    public string Checked,EC;
    DataSet ds = new DataSet();
    Default_Settings Default = new Default_Settings();


    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

        // commented for areawise implementation on 05-mar-2020
        /*
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
          * */
        SELECT_BRANCH = Connection.Get_Company_Type();

        if (!IsPostBack)
        {
            Check_Avail();
        }
    }
    protected void btn_Change_Click(object sender, EventArgs e)
    {
        Default.BRANCH_CODE = currentbranch;

        Default.WORKING_PERIOD = Working_Period;
        //Default.BRANCH_COMMON = SELECT_BRANCH;
        Default.flag = "SELECT";

        ds = Default.User_PurchaseSettings_Insert_Update();
        if (ds.Tables[1].Rows.Count > 0)
        {
            //if (Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()) > 0)
            //{
                //Default.flag = "UPDATE"; 
                Alert_msg("Cannot Change Settings");
            //}
        }
        else
        {

            Default.PREFIX = txtPrefix.Text;
            if (chkMonth.Checked == true)
            { Default.PMONTH = "YES"; }
            else { Default.PMONTH = "NO"; }
            if (chkYear.Checked == true) { Default.PYEAR = "YES"; } else { Default.PYEAR = "NO"; }
            Default.SUFFIX = txtSuffix.Text;
            if (chksMonth.Checked == true) { Default.SMONTH = "YES"; } else { Default.SMONTH = "NO"; }
            if (chksYear.Checked == true) { Default.SYEAR = "YES"; } else { Default.SYEAR = "NO"; }
            Default.BRANCH_CODE = currentbranch;
            Default.YEAR = DateTime.Now.Year.ToString();
            Default.WORKING_PERIOD = Working_Period;
            Default.Start_id = txtStartid.Text;
            //Default.BRANCH_COMMON = SELECT_BRANCH;
            Default.flag = "SAVE";

            ds = Default.User_PurchaseSettings_Insert_Update();


            int id = Default.result;

            if (id == 1)
            {
                Alert_msg("Saved Successfully");
            }
            //Default.flag = "SAVE";
        }
        
 
    }

    public void Check_Avail()
    {

       
        Default.BRANCH_CODE = currentbranch;
        
        Default.WORKING_PERIOD = Working_Period;
        //Default.BRANCH_COMMON = SELECT_BRANCH;
        Default.flag = "SELECT";

        ds = Default.User_PurchaseSettings_Insert_Update();
        if (ds.Tables[1].Rows.Count > 0)
        {

            ////if (Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()) > 0)
            ////{
            ////    btn_Save.Enabled = false;
            ////}
            ////else { btn_Save.Enabled = true; }
            txtPrefix.Text = ds.Tables[1].Rows[0]["PREFIX"].ToString();
            txtSuffix.Text = ds.Tables[1].Rows[0]["SUFFIX"].ToString();
            if (ds.Tables[1].Rows[0]["PMONTH"].ToString() == "YES") { chkMonth.Checked = true; } else { chkMonth.Checked = false; }
            if (ds.Tables[1].Rows[0]["PYEAR"].ToString() == "YES") { chkYear.Checked = true; } else { chkYear.Checked = false; }
            if (ds.Tables[1].Rows[0]["SMONTH"].ToString() == "YES") { chksMonth.Checked = true; } else { chksMonth.Checked = false; }
            if (ds.Tables[1].Rows[0]["SYEAR"].ToString() == "YES") { chksYear.Checked = true; } else { chksYear.Checked = false; }
            txtStartid.Text = ds.Tables[1].Rows[0]["LAST_ID"].ToString();


        }
        else { btn_Save.Enabled = true; }
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Default Settings', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
}