using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Drawing;
using System.Windows.Forms;


public partial class Export_BL_Generation_Annexure : ThemeClass
{

    public string JobNo;
    public int ii;

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH, Select_Freight;

    EXP_BL_Generation Exp_BL = new EXP_BL_Generation();
    ErrorLogs er = new ErrorLogs();
    DataSet dsData = new DataSet();
    DataSet ds = new DataSet();
    AppSession aps = new AppSession();

    int i;

    EXP_BL_Generation BL_Gen = new EXP_BL_Generation();

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
            try
            {
                if (Request.QueryString["jobno"] == "" || Request.QueryString["jobno"] == null)
                {

                }
                else
                {
                    Page_Container_Load();
                    JobNo = Request.QueryString["jobno"].ToString();
                    hdnfld_Jobno.Value = Request.QueryString["jobno"].ToString();
                }
            }
            catch (Exception ex)
            {
                ErrorLogs er = new ErrorLogs();

                er.makeLog
                    (ex.Message);
            }
      
        }
    }

    public void Page_Container_Load()
    {
        if (Request.QueryString["jobno"] == "" || Request.QueryString["jobno"] == null ||  Request.QueryString["jobno"] == "Select")
        {
            Alert_msg("Select JobNo");
        }
        else
        {

            Exp_BL.JOBNO = Request.QueryString["jobno"].ToString();
            Exp_BL.Ename = "Select_BL_Annexure";
            Exp_BL.BRANCHCODE = SELECT_BRANCH;
            Exp_BL.WORKINGPERIOD = Working_Period;

            ds = Exp_BL.BL_Container_Select_All();

            if (ds.Tables[0].Rows.Count != 0)
            {
                txt_Marks_Nos.Text = ds.Tables[0].Rows[0]["MARKS_NOS"].ToString();
                txt_Description.Text = ds.Tables[0].Rows[0]["GOODS_DESCRIPTION"].ToString();

                
            }
            else
            {
                
            }
        }
    }


    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'BL_Container Details', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'BL_Container Details', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public int Annex_Insert_Update(string a1, string a2)
    {
        BL_Gen.JOBNO = Request.QueryString["jobno"].ToString();
        BL_Gen.MARKS_NOS = txt_Marks_Nos.Text;
        BL_Gen.GOODS_DESCRIPTION = txt_Description.Text;
       
        BL_Gen.flag = a2;

        BL_Gen.USERID = currentuser;
        BL_Gen.STATUS = a2;
        BL_Gen.BRANCHCODE = SELECT_BRANCH;
        BL_Gen.WORKINGPERIOD = Working_Period;

        BL_Gen.BL_Annexure_Insert_Update();
        i = BL_Gen.result;

        return i;
    }

    protected void ButtonSave_Click(object sender, EventArgs e)
    {
        i = Annex_Insert_Update("N", "S");

        Alert_msg("Saved Successfully", "btnSave");
 
    }

    public void multi()
    {
    
    }
   
}