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

        SELECT_BRANCH = Connection.Get_Company_Type();

        if (!IsPostBack)
        {
            Get_Checked();
        }
    }
    protected void btn_Change_Click(object sender, EventArgs e)
    {
        
        //user.DEFAULT_ID = "1";
        //Default.YesNo = rdoDefault_Date.SelectedItem.Text;

        int schem_cnt = 10;
        string select_schme = "";

        for (int i = 1; i <= schem_cnt; i++)
        {
            if (i == 1)
            {
                //if (chk_DEEC_CIF.Checked == true || chk_DEEC_DUTY.Checked == true || chk_DEEC_QTY.Checked == true)
                //{
                    Default.SCHEME = "DEEC";
                    Default.DUTY_BASED = chk_DEEC_DUTY.Checked == true ? "Y" : "N";
                    Default.CIF_BASED = chk_DEEC_CIF.Checked == true ? "Y" : "N";
                    Default.QTY_BASED = chk_DEEC_QTY.Checked == true ? "Y" : "N";
                    select_schme = "Y";
                //}
            }

            if (i == 2)
            {
                Default.SCHEME = "EPCG";
                Default.DUTY_BASED = chk_EPCG_DUTY.Checked == true ? "Y" : "N";
                Default.CIF_BASED = chk_EPCG_CIF.Checked == true ? "Y" : "N";
                Default.QTY_BASED = chk_EPCG_QTY.Checked == true ? "Y" : "N";
                select_schme = "Y";
            }

            if (i == 3)
            {
                Default.SCHEME = "MEIS";
                Default.DUTY_BASED = chk_MEIS_DUTY.Checked == true ? "Y" : "N";
                Default.CIF_BASED = chk_MEIS_CIF.Checked == true ? "Y" : "N";
                Default.QTY_BASED = chk_MEIS_QTY.Checked == true ? "Y" : "N";
                select_schme = "Y";
            }

            if (i == 4)
            {
                Default.SCHEME = "SEIS";
                Default.DUTY_BASED = chk_SEIS_DUTY.Checked == true ? "Y" : "N";
                Default.CIF_BASED = chk_SEIS_CIF.Checked == true ? "Y" : "N";
                Default.QTY_BASED = chk_SEIS_QTY.Checked == true ? "Y" : "N";
                select_schme = "Y";
            }

            if (i == 5)
            {
                Default.SCHEME = "SHIS";
                Default.DUTY_BASED = chk_SHIS_DUTY.Checked == true ? "Y" : "N";
                Default.CIF_BASED = chk_SHIS_CIF.Checked == true ? "Y" : "N";
                Default.QTY_BASED = chk_SHIS_QTY.Checked == true ? "Y" : "N";
                select_schme = "Y";
            }

            if (i == 6)
            {
                Default.SCHEME = "FPS";
                Default.DUTY_BASED = chk_FPS_DUTY.Checked == true ? "Y" : "N";
                Default.CIF_BASED = chk_FPS_CIF.Checked == true ? "Y" : "N";
                Default.QTY_BASED = chk_FPS_QTY.Checked == true ? "Y" : "N";
                select_schme = "Y";
            }

            if (i == 7)
            {
                Default.SCHEME = "FMS";
                Default.DUTY_BASED = chk_FMS_DUTY.Checked == true ? "Y" : "N";
                Default.CIF_BASED = chk_FMS_CIF.Checked == true ? "Y" : "N";
                Default.QTY_BASED = chk_FMS_QTY.Checked == true ? "Y" : "N";
                select_schme = "Y";
            }

            if (i == 8)
            {
                Default.SCHEME = "ROSCTL";
                Default.DUTY_BASED = chk_ROSCTL_DUTY.Checked == true ? "Y" : "N";
                Default.CIF_BASED = chk_ROSCTL_CIF.Checked == true ? "Y" : "N";
                Default.QTY_BASED = chk_ROSCTL_QTY.Checked == true ? "Y" : "N";
                select_schme = "Y";
            }

            if (i == 9)
            {
                Default.SCHEME = "DFIA";
                Default.DUTY_BASED = chk_DFIA_DUTY.Checked == true ? "Y" : "N";
                Default.CIF_BASED = chk_DFIA_CIF.Checked == true ? "Y" : "N";
                Default.QTY_BASED = chk_DFIA_QTY.Checked == true ? "Y" : "N";
                select_schme = "Y";
            }

            if (i == 10)
            {
                Default.SCHEME = "Restricted Items";
                Default.DUTY_BASED = chk_14_DUTY.Checked == true ? "Y" : "N";
                Default.CIF_BASED = chk_14_CIF.Checked == true ? "Y" : "N";
                Default.QTY_BASED = chk_14_QTY.Checked == true ? "Y" : "N";
                select_schme = "Y";
            }

            Default.USER_ID = currentuser;
            Default.BRANCH_CODE = currentbranch;
            Default.YEAR = "";
            Default.WORKING_PERIOD = Working_Period;
            Default.BRANCH_COMMON = SELECT_BRANCH;
            Default.flag = "S";

            if (select_schme == "Y")
            {
                ds = Default.Import_License_Default_Settings_Insert_Update();
            }
        }

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

        ds = Default.Import_License_Default_Settings_Insert_Update();

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                if (ds.Tables[0].Rows[i]["SCHEME"].ToString() == "DEEC")
                {
                    chk_DEEC_DUTY.Checked = ds.Tables[0].Rows[i]["DUTY_BASED"].ToString() == "Y" ? true : false;
                    chk_DEEC_CIF.Checked = ds.Tables[0].Rows[i]["CIF_BASED"].ToString() == "Y" ? true : false;
                    chk_DEEC_QTY.Checked = ds.Tables[0].Rows[i]["QTY_BASED"].ToString() == "Y" ? true : false;
                }

                if (ds.Tables[0].Rows[i]["SCHEME"].ToString() == "EPCG")
                {
                    chk_EPCG_DUTY.Checked = ds.Tables[0].Rows[i]["DUTY_BASED"].ToString() == "Y" ? true : false;
                    chk_EPCG_CIF.Checked = ds.Tables[0].Rows[i]["CIF_BASED"].ToString() == "Y" ? true : false;
                    chk_EPCG_QTY.Checked = ds.Tables[0].Rows[i]["QTY_BASED"].ToString() == "Y" ? true : false;
                }

                if (ds.Tables[0].Rows[i]["SCHEME"].ToString() == "MEIS")
                {
                    chk_MEIS_DUTY.Checked = ds.Tables[0].Rows[i]["DUTY_BASED"].ToString() == "Y" ? true : false;
                    chk_MEIS_CIF.Checked = ds.Tables[0].Rows[i]["CIF_BASED"].ToString() == "Y" ? true : false;
                    chk_MEIS_QTY.Checked = ds.Tables[0].Rows[i]["QTY_BASED"].ToString() == "Y" ? true : false;
                }

                if (ds.Tables[0].Rows[i]["SCHEME"].ToString() == "SEIS")
                {
                    chk_SEIS_DUTY.Checked = ds.Tables[0].Rows[i]["DUTY_BASED"].ToString() == "Y" ? true : false;
                    chk_SEIS_CIF.Checked = ds.Tables[0].Rows[i]["CIF_BASED"].ToString() == "Y" ? true : false;
                    chk_SEIS_QTY.Checked = ds.Tables[0].Rows[i]["QTY_BASED"].ToString() == "Y" ? true : false;
                }

                if (ds.Tables[0].Rows[i]["SCHEME"].ToString() == "SHIS")
                {
                    chk_SHIS_DUTY.Checked = ds.Tables[0].Rows[i]["DUTY_BASED"].ToString() == "Y" ? true : false;
                    chk_SHIS_CIF.Checked = ds.Tables[0].Rows[i]["CIF_BASED"].ToString() == "Y" ? true : false;
                    chk_SHIS_QTY.Checked = ds.Tables[0].Rows[i]["QTY_BASED"].ToString() == "Y" ? true : false;
                }

                if (ds.Tables[0].Rows[i]["SCHEME"].ToString() == "FPS")
                {
                    chk_FPS_DUTY.Checked = ds.Tables[0].Rows[i]["DUTY_BASED"].ToString() == "Y" ? true : false;
                    chk_FPS_CIF.Checked = ds.Tables[0].Rows[i]["CIF_BASED"].ToString() == "Y" ? true : false;
                    chk_FPS_QTY.Checked = ds.Tables[0].Rows[i]["QTY_BASED"].ToString() == "Y" ? true : false;
                }

                if (ds.Tables[0].Rows[i]["SCHEME"].ToString() == "FMS")
                {
                    chk_FMS_DUTY.Checked = ds.Tables[0].Rows[i]["DUTY_BASED"].ToString() == "Y" ? true : false;
                    chk_FMS_CIF.Checked = ds.Tables[0].Rows[i]["CIF_BASED"].ToString() == "Y" ? true : false;
                    chk_FMS_QTY.Checked = ds.Tables[0].Rows[i]["QTY_BASED"].ToString() == "Y" ? true : false;
                }

                if (ds.Tables[0].Rows[i]["SCHEME"].ToString() == "ROSCTL")
                {
                    chk_ROSCTL_DUTY.Checked = ds.Tables[0].Rows[i]["DUTY_BASED"].ToString() == "Y" ? true : false;
                    chk_ROSCTL_CIF.Checked = ds.Tables[0].Rows[i]["CIF_BASED"].ToString() == "Y" ? true : false;
                    chk_ROSCTL_QTY.Checked = ds.Tables[0].Rows[i]["QTY_BASED"].ToString() == "Y" ? true : false;
                }

                if (ds.Tables[0].Rows[i]["SCHEME"].ToString() == "DFIA")
                {
                    chk_DFIA_DUTY.Checked = ds.Tables[0].Rows[i]["DUTY_BASED"].ToString() == "Y" ? true : false;
                    chk_DFIA_CIF.Checked = ds.Tables[0].Rows[i]["CIF_BASED"].ToString() == "Y" ? true : false;
                    chk_DFIA_QTY.Checked = ds.Tables[0].Rows[i]["QTY_BASED"].ToString() == "Y" ? true : false;
                }
            }
        }

    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'License Settings', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
}