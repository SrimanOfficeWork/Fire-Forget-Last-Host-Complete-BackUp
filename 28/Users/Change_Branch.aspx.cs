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


public partial class Change_Branch : ThemeClass
{
     
    DataTable dt = new DataTable();    
    DataSet ds = new DataSet();    
    AppSession aps = new AppSession();    
    Company_Master Comp = new Company_Master();
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, Name_Search;
    public double Import_Rate_From, Export_Rate_From;
    public double Import_Rate_To, Export_Rate_To;

    public double Import_Rate, Export_Rate;
   
    public string AUTO_I, COMPANY_ID, USER_CREATION_ID, BRANCH, BRANCH_ID, flag;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
       

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

        if (!IsPostBack)
        {
           
            //-----------------------load branch------------------------//
            LoadGroup();             
            //-----------------------load branch------------------------//
        }
    }

    public void LoadGroup()
    {      
       
        DataSet dsGrp = new DataSet();  
        Comp.COMPANY_ID = "";
        Comp.flag = "Select-Group";
        dsGrp = Comp.RetrieveAll_Groups();
        ddlGrpname.Items.Clear();
        if (dsGrp.Tables.Count > 0)
        {
            ddlGrpname.DataSource = dsGrp.Tables[0];
            ddlGrpname.DataTextField = "GROUP_NAME";
            ddlGrpname.DataValueField = "GROUP_ID";
            ddlGrpname.DataBind();

            if (Session["GroupID"].ToString() != "" && Session["GroupID"].ToString() != null)
            {
                ddlGrpname.SelectedValue = Session["GroupID"].ToString();
            }
            Load_Company_Branch(ddlGrpname.SelectedValue.ToString());
        }
    }

    public void Load_Company_Branch(string groupid)
    {
        DataSet dsGrp = new DataSet();
        Comp.COMPANY_ID = groupid;
        Comp.BRANCH = "";

        DataSet ds1 = (DataSet)HttpContext.Current.Session["COMPANY_DETAILS_DS"];

        Comp.flag = "Select-Group";
        dsGrp = Comp.RetrieveAll_Groups();
        if (dsGrp.Tables.Count > 1)
        {
            ddlSelect_Branch.DataSource = dsGrp.Tables[1];
            ddlSelect_Branch.DataTextField = "BRANCH_TRANSPORT_MODE";
            ddlSelect_Branch.DataValueField = "BRANCHCODE";
            ddlSelect_Branch.DataBind();
        }      
   
    }

    protected void ddlGrpname_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_Company_Branch(ddlGrpname.SelectedValue.ToString());       
    }

    protected void btn_Change_Branch_Click(object sender, EventArgs e)
    {
        Login login = new Login();

        //login.flag = "Update_ISLogin_Status";
        login.flag = "Check_Branch_Permission_User";
        login.startdt = "01/01/1900";
        login.expdt = "01/01/1900";

        login.usrid = Session["currentuser"].ToString();
        login.passwd = Session["currentpassword"].ToString();
        login.COMPANY_ID = Session["COMPANY_ID"].ToString();

        login.BRANCH = ddlSelect_Branch.Text;//-- 18/06/2020 - by Chithra for Branch permission issue

        //Session.Remove("currentbranch");
        //Session.Remove("currentbranch_code");
        //Session["currentbranch"] = login.BRANCH = ddlSelect_Branch.Text;
        //Session["currentbranch_code"] = ddlSelect_Branch.SelectedItem.ToString();

        ds = login.Check_User_Login_Details();

        if (ds.Tables[0].Rows.Count > 0)
        {
            lbl_msg.Text = "";
            login.flag = "Update_ISLogin_Status";
            ds = login.Check_User_Login_Details();

            Session.Remove("USER_DETAILS_DS");
            Session["USER_DETAILS_DS"] = ds;

            Session.Remove("GroupName");
            Session.Remove("GroupID");
            Session["GroupID"] = ddlGrpname.SelectedValue.ToString();
            Session["GroupName"] = ddlGrpname.SelectedItem.ToString();

            aps.makeSession(login.usrid.Trim(), login.passwd.Trim(), ddlSelect_Branch.Text, ddlSelect_Branch.SelectedItem.ToString(), Session["CLIENT_NAME"].ToString(), Session["currentcomp_db"].ToString(), login.COMPANY_ID, Session["JOB_TYPE"].ToString(), Session["SELECT_TYPE"].ToString());

            string prompt = "<script>parent.showBranchChangeSuccess();</script>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
        }
        else
        {
            lbl_msg.Text = "You don't have permission to access this Branch";
        }
    }
   
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Currency Converter', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Currency Converter', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
  
}