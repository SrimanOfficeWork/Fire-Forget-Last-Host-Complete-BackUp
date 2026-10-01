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
using System.IO;
using BussinessObject;


public partial class Port_Master_UserWise : ThemeClass
{
    Non_stand_Cur_master nonstd = new Non_stand_Cur_master();
    SqlConnection con;
    SqlCommand cmd;
    DataSet dtuser = new DataSet();
    DataSet ds = new DataSet();
    Manipulation mo = new Manipulation();
    AppSession aps = new AppSession();
    public string NON_STD_ID = "";
    ErrorLogs er = new ErrorLogs();
    UserBO objUBO = new UserBO();
    eroyalmaster erm = new eroyalmaster();
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    string SP_QUERY;

    public int i;
    public string currentuser, AUTO_ID;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
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
                Edit_Userwise_port_details();
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
        
    }
   
    public void Edit_Userwise_port_details()
    {
        try
        {
            if (Request.QueryString["PORT_ID"] != "" && Request.QueryString["PORT_ID"] != null)
            {
                objUBO.PORT_ID = Request.QueryString["PORT_ID"].ToString();
                HiddenField1.Value = Request.QueryString["PORT_ID"].ToString();
                objUBO.PORT_CODE = "";
                objUBO.PORT_NAME = "";
                objUBO.BRANCH_CODE = currentbranch;
                objUBO.flag = "select_conwith_PORT_ID";

                dtuser = erm.PORT_MASTER_USERWISE_Insert_update(objUBO);

                if (dtuser.Tables[0].Rows.Count > 0)
                {
                    txtPort_Code.Text = dtuser.Tables[0].Rows[0]["PORT_CODE"].ToString();
                    txtPort_name.Text = dtuser.Tables[0].Rows[0]["PORT_NAME"].ToString();
                    txtRemarks.Text = dtuser.Tables[0].Rows[0]["REMARKS"].ToString();

                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                    btnNew.Visible = true;
                    btnSave.Visible = false;
                    ViewState["UPDATED_ID"] = null;
                    ViewState["UPDATED_ID"] = Request.QueryString["PORT_ID"].ToString();
                    //FOR UPDATED SUCCESSFULLY
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('No Port Found')</script>", false);
                }
            }
            else
            {
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnNew.Visible = true;
                btnSave.Visible = true;

            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
        
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            mo.ResetFields(Page.Controls);
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnNew.Visible = true;
            btnSave.Visible = true;
            ViewState["UPDATED_ID"] = null;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
    }

    public int insert_update(string a1, string a2, string a3)
    {
        int i = 0;
        try
        {
            if (HiddenField1.Value != "")
                objUBO.PORT_ID = HiddenField1.Value;
            else
                objUBO.PORT_ID = "";

            objUBO.PORT_CODE = txtPort_Code.Text;
            objUBO.PORT_NAME = txtPort_name.Text;
            objUBO.ITEM_REMARKS = txtRemarks.Text;
            objUBO.USER_ID = currentuser;
            objUBO.BRANCH_CODE = currentbranch;
            objUBO.flag = a2;
            objUBO.WORKING_PERIOD = Working_Period;
            ds = erm.PORT_MASTER_USERWISE_Insert_update(objUBO);
            //i = erm.PORT_MASTER_USERWISE_Insert_update(objUBO);
             i = erm.result;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
        
        
        return i;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        HiddenField1.Value = "";
        if (txtPort_Code.Text != "" && txtPort_name.Text != "" )
        {
            if (txtPort_Code.Text.Length == 3 || txtPort_Code.Text.Length == 5)
            {
                try
                {
                    string a1 = "";
                    string a2 = "S";
                    string a3 = "";
                    i = insert_update(a1, a2, a3);
                    HiddenField1.Value = Convert.ToString(nonstd.UPDATE_ID);

                    if (i == 1)
                    {
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);

                        btnUpdate.CssClass = "save";
                        btnUpdate.Visible = true;
                        btnSave.Visible = false;
                        ViewState["UPDATED_ID"] = null;

                        btnSave.Focus();
                        //hdn_Update_Exchange.Value = txtEx_Cur_Code.Text;
                        Alert_msg("Saved Successfully", "btnSave");

                    }
                    else if (i == 2)
                    {
                        Alert_msg("PORT Code already exixts!", "btnSave");
                    }
                    else
                    {
                        Alert_msg("PORT Not Saved", "btnNew");
                    }
                }
                catch (Exception ex)
                {
                    er.makeLog(ex.Message);
                }
            }
            else
            {
                Alert_msg("Port Code Should be 3-Digit (or)  5-Digit");
            }
        }
        else
        {
            Alert_msg("Enter All Mandatory Field");
        }
    }


    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            if (HiddenField1.Value != "")
                objUBO.PORT_ID = HiddenField1.Value;
            else
                objUBO.PORT_ID = "";
            //objUBO.PORT_CODE = "";
            //objUBO.PORT_NAME = "";
            //objUBO.ITEM_REMARKS = txtRemarks.Text;
            //objUBO.USER_ID = currentuser;
            objUBO.BRANCH_CODE = currentbranch;
            objUBO.flag = "Delete";
            objUBO.WORKING_PERIOD = Working_Period;
            ds = erm.PORT_MASTER_USERWISE_Insert_update(objUBO);
            int ii = erm.result;

            if (ii > 0)
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('Port Code Deleted', 'USER WISE-PORT MASTER', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            }
            else
            {
                Alert_msg("Port Not Deleted");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string a1 = HiddenField1.Value;
            string a2 = "U";
            string a3 = "";
            i = insert_update(a1, a2, a3);
            if (i == 1)
            {
                //hdn_Update_Exchange.Value = txtEx_Cur_Code.Text;
                if (ViewState["UPDATED_ID"] != null)
                {
                    Alert_msg("Updated Successfully", "btnUpdate");
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Updated Successfully')</script>", false);
                }
                else
                {
                    Alert_msg("Saved Successfully", "btnUpdate");
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);
                }
                //btnUpdate.Focus();
            }
            else if (i == 2)
            {
                Alert_msg("Port Code already exixts!", "btnUpdate");
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Currency Code already exixts!')</script>", false);
                //btnSave.Focus();
            }
            else
            {
                Alert_msg("Port Not Saved", "btnUpdate");
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Exchange Not Saved')</script>", false);
                //btnUpdate.Focus();
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'USER WISE-PORT MASTER', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'USER WISE-PORT MASTER', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
}