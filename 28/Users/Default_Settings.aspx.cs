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
            Get_Checked();
        }
    }
    protected void btn_Change_Click(object sender, EventArgs e)
    {
        
        //user.DEFAULT_ID = "1";
        Default.YesNo = rdoDefault_Date.SelectedItem.Text;
        Default.USER_ID = currentuser;
        Default.BRANCH_CODE = currentbranch;
        Default.YEAR = "";
        Default.WORKING_PERIOD = Working_Period;
        Default.BRANCH_COMMON = SELECT_BRANCH;
        Default.flag = "S";

        ds = Default.User_DefaultSettings_Insert_Update();
         

        int id = Default.result;

        if (id == 1)
        {
            Alert_msg("Saved Successfully");
        }
        else
        {
                     
            Alert_msg("Updated Successfully");
        }
 
    }

    public void Get_Checked()
    {

        //user.DEFAULT_ID = "1";
        Default.YesNo = "";
        Default.USER_ID = currentuser;
        Default.BRANCH_CODE = currentbranch;
        Default.YEAR = "";
        Default.WORKING_PERIOD = Working_Period;
        Default.BRANCH_COMMON = SELECT_BRANCH;
        Default.flag = "Get_Details";

        ds = Default.User_DefaultSettings_Insert_Update();

        if (ds.Tables[0].Rows.Count > 0)
        {
            rdoDefault_Date.SelectedValue = ds.Tables[0].Rows[0]["MANUFAC_NAME_FROM_SUP"].ToString();
        }

    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Default Settings', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
}