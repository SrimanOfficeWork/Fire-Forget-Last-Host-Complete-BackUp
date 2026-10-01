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


public partial class Non_standard_currecy_master : ThemeClass
{
    Non_stand_Cur_master nonstd = new Non_stand_Cur_master();
    SqlConnection con;
    SqlCommand cmd;
    DataSet dtuser = new DataSet();
    Manipulation mo = new Manipulation();
    AppSession aps = new AppSession();
    public string NON_STD_ID = "";
    ErrorLogs er = new ErrorLogs();
    DropDownList ddl = new DropDownList();
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    string SP_QUERY;
    string datestring;
    public int i;
    public string currentuser, AUTO_ID;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public DateTime NON_STD_Date_Imp, NON_STD_Date_Exp, NON_STD_cert_Date;


    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

        ddl.Items.Clear();

        if (!IsPostBack)
        {
            load_date();

            //ddlExchange.Items.Clear();


            //ddlExchange.Items.Add("Y");
            //ddlExchange.Items.Add("N");
            Edit_ExchangeDetails();

        }

    }
    public void load_date()
    {
        try
        {
            DateTime dat = System.DateTime.Now;
            datestring = string.Format("{0:dd/MM/yyyy}", dat);

            txtEx_Effect_dt_Imp.Text = datestring;
            txtEx_Effect_dt_Exp.Text = datestring;
            txtEx_Certificate_Date.Text = datestring;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
        
    }
    public void Edit_ExchangeDetails()
    {
        try
        {
            if (Request.QueryString["NON_STD_ID"] != "" && Request.QueryString["NON_STD_ID"] != null)
            {
                int i = 0;
                NON_STD_ID = Request.QueryString["NON_STD_ID"];


                nonstd.NON_STD_ID = NON_STD_ID;
                nonstd.NON_STD_EFFECT_DT_IMP = "01/01/1900";
                nonstd.NON_STD_EFFECT_DT_EXP = "01/01/1900";
                nonstd.NON_STD_CERTIFICATE_NO = "0";
                nonstd.NON_STD_CERTIFICATE_DATE = "01/01/1900";
                nonstd.Ename = "select_conwithcode";
                nonstd.EWorking_Period = Working_Period;


                dtuser = nonstd.RetrieveAll_NON_STD_master();

                if (dtuser.Tables[0].Rows.Count > 0)
                {
                    //DateTime EFFECT_DT_IMP = Convert.ToDateTime(dtuser.Tables[0].Rows[0]["NON_STD_EFFECT_DT_IMP"].ToString());


                    //txtEx_Effect_dt_Imp.Text = string.Format("{0:dd/MM/yyyy}", EFFECT_DT_IMP);

                    //DateTime EFFECT_DT_EXP = Convert.ToDateTime(dtuser.Tables[0].Rows[0]["NON_STD_EFFECT_DT_EXP"].ToString());

                    //txtEx_Effect_dt_Exp.Text = string.Format("{0:dd/MM/yyyy}", EFFECT_DT_EXP);

                    //txtEx_Certificate_no.Text = dtuser.Tables[0].Rows[0]["NON_STD_CERTIFICATE_NO"].ToString();

                    //DateTime NON_STD_CERTIFICATE_DATE = Convert.ToDateTime(dtuser.Tables[0].Rows[0]["NON_STD_CERTIFICATE_DATE"].ToString());


                    //txtEx_Certificate_Date.Text = string.Format("{0:dd/MM/yyyy}", NON_STD_CERTIFICATE_DATE);
                    txtEx_Effect_dt_Imp.Text = dtuser.Tables[0].Rows[0]["NON_STD_EFFECT_DT_IMP"].ToString();
                    txtEx_Effect_dt_Exp.Text = dtuser.Tables[0].Rows[0]["NON_STD_EFFECT_DT_EXP"].ToString();
                    txtEx_Certificate_no.Text = dtuser.Tables[0].Rows[0]["NON_STD_CERTIFICATE_NO"].ToString();
                    txtEx_Cur_Code.Text = dtuser.Tables[0].Rows[0]["NON_STD_CUR_CODE"].ToString();
                    txtEx_name.Text = dtuser.Tables[0].Rows[0]["NON_STD_NAME"].ToString();
                    txtEx_BankName.Text = dtuser.Tables[0].Rows[0]["NON_STD_BANKNAME"].ToString();
                    txtEx_Rt_Imp.Text = dtuser.Tables[0].Rows[0]["NON_STD_RATE_IMPORT"].ToString();
                    txtEx_Rt_Exp.Text = dtuser.Tables[0].Rows[0]["NON_STD_RATE_EXPORT"].ToString();
                    //string NON_STD_Y_N = dtuser.Tables[0].Rows[0]["NON_STD_S_OR_N"].ToString();
                    //// ddlExchange.Items.Add(dtuser.Tables[0].Rows[0]["NON_STD_S_OR_N"].ToString());
                    //ddlExchange.Items.Clear();
                    //ddlExchange.Items.Add("Y");
                    //ddlExchange.Items.Add("N");

                    //ddlExchange.Items.Remove(NON_STD_Y_N);

                    //ddlExchange.Items.Insert(0, NON_STD_Y_N);
                    HiddenField1.Value = Request.QueryString["NON_STD_ID"].ToString();
                    //Edit_ExchangeDetails();
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                    btnNew.Visible = true;
                    btnSave.Visible = false;
                    hdn_Update_Exchange.Value = txtEx_Cur_Code.Text;
                    //FOR UPDATED SUCCESSFULLY
                    ViewState["UPDATED_ID"] = null;
                    ViewState["UPDATED_ID"] = Request.QueryString["NON_STD_ID"].ToString();
                    //FOR UPDATED SUCCESSFULLY
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('No Exchange Found')</script>", false);
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

    public void Clear()
    {
        try
        {
            txtEx_Effect_dt_Imp.Text = datestring;
            txtEx_Effect_dt_Exp.Text = datestring;
            txtEx_Certificate_Date.Text = datestring;
            txtEx_Certificate_no.Text = "";
            txtEx_Cur_Code.Text = "";
            txtEx_name.Text = "";
            txtEx_BankName.Text = "";
            txtEx_Rt_Exp.Text = "";
            txtEx_Rt_Imp.Text = "";
            //ddlExchange.SelectedIndex = 0;
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
            load_date();
            txtEx_Effect_dt_Imp.Focus();
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnNew.Visible = true;
            btnSave.Visible = true;
            //ddlExchange.Items.Clear();
            //ddlExchange.Items.Add("Y");
            //ddlExchange.Items.Add("N");
            hdn_Update_Exchange.Value = "";
            ViewState["UPDATED_ID"] = null;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
        //Clear();
    }

    public int insert_update(string a1, string a2, string a3)
    {
        try
        {
            //NON_STD_Date_Imp = DateTime.Parse(txtEx_Effect_dt_Imp.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

            //NON_STD_Date_Exp = DateTime.Parse(txtEx_Effect_dt_Exp.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

            //NON_STD_cert_Date = DateTime.Parse(txtEx_Certificate_Date.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            if (HiddenField1.Value != "")
                nonstd.NON_STD_ID = HiddenField1.Value;
            else
                nonstd.NON_STD_ID = "";
            nonstd.NON_STD_NAME = txtEx_name.Text;
            nonstd.NON_STD_CERTIFICATE_NO = txtEx_Certificate_no.Text;
            nonstd.NON_STD_CERTIFICATE_DATE = txtEx_Certificate_Date.Text;
            nonstd.NON_STD_BANKNAME = txtEx_BankName.Text;
            nonstd.NON_STD_RATE_EXPORT = txtEx_Rt_Exp.Text;
            nonstd.NON_STD_RATE_IMPORT = txtEx_Rt_Imp.Text;
            //nonstd.NON_STD_S_OR_N = ddlExchange.SelectedValue.ToString();
            nonstd.NON_STD_CUR_CODE = txtEx_Cur_Code.Text;
            nonstd.NON_STD_EFFECT_DT_IMP = txtEx_Effect_dt_Imp.Text;
            nonstd.NON_STD_EFFECT_DT_EXP = txtEx_Effect_dt_Exp.Text;

            nonstd.USER_ID = currentuser;
            nonstd.BRANCH_CODE = currentbranch;
            nonstd.flag = a2;
            nonstd.YEAR = a3;
            nonstd.EWorking_Period = Working_Period;

            i = nonstd.NON_STD_Master_Insert_update();
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
        if (txtEx_Effect_dt_Imp.Text != "" && txtEx_Effect_dt_Exp.Text != "" && txtEx_Certificate_Date.Text != "" && txtEx_Certificate_no.Text != "" && txtEx_Cur_Code.Text != "" && txtEx_name.Text != "" && txtEx_BankName.Text != "" && txtEx_Rt_Imp.Text != "" && txtEx_Rt_Exp.Text != "")
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
                    hdn_Update_Exchange.Value = txtEx_Cur_Code.Text;
                    Alert_msg("Saved Successfully", "btnSave");

                }
                else if (i == 2)
                {
                    Alert_msg("Currency Code already exixts!", "btnSave");

                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Currency Code already exixts!')</script>", false);
                    //btnSave.Focus();
                }
                else
                {
                    Alert_msg("Exchange Not Saved", "btnNew");

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Exchange Not Saved')</script>", false);
                    //btnSave.Focus();

                }

            }
            catch (Exception ex)
            {
                er.makeLog(ex.Message);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
            }
        }
        else
        {
            Alert_msg("Enter All Mandatory Field");

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Enter All Mandatory Field')</script>", false);


        }
    }



    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {

            nonstd.NON_STD_ID = HiddenField1.Value;
            nonstd.NON_STD_EFFECT_DT_IMP = "0";
            nonstd.NON_STD_EFFECT_DT_EXP = "0";
            nonstd.NON_STD_CERTIFICATE_NO = "0";
            nonstd.NON_STD_CERTIFICATE_DATE = "0";
            nonstd.Ename = "delete";
            nonstd.EWorking_Period = Working_Period;

            nonstd.RetrieveAll_NON_STD_master();
            int ii = 0;
            ii = nonstd.result;

            if (ii > 0)
            {
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Exchange Deleted')</script>", false);
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "RefreshParent", "<script language='javascript'>RefreshParent()</script>", false);
                string prompt = "<script>$(document).ready(function(){{jAlert('Exchange Deleted', 'EXCHANGE MASTER', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);


            }


            else
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Exchange Not Deleted')</script>", false);
                Alert_msg("Exchange Not Deleted");


            }

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
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
                hdn_Update_Exchange.Value = txtEx_Cur_Code.Text;
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
                Alert_msg("Currency Code already exixts!", "btnUpdate");

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Currency Code already exixts!')</script>", false);
                //btnSave.Focus();
            }
            else
            {
                Alert_msg("Exchange Not Saved", "btnUpdate");

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Exchange Not Saved')</script>", false);
                //btnUpdate.Focus();
            }


        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
    }
    protected void txtEx_Cur_Code_TextChanged(object sender, EventArgs e)
    {
        if (hdn_Update_Exchange.Value != txtEx_Cur_Code.Text)
        {
            try
            {
                //here using ENON_STD_CERTIFICATE_NO Instead of Exchange CurrencyCode
                nonstd.NON_STD_ID = "0";
               
                nonstd.NON_STD_EFFECT_DT_IMP = "0";
                nonstd.NON_STD_EFFECT_DT_EXP = "0";
                nonstd.NON_STD_CERTIFICATE_NO = "0";
                nonstd.NON_STD_CERTIFICATE_DATE = "0";
                nonstd.Ename = "Check_Exchange";
                nonstd.EWorking_Period = Working_Period;

                dtuser = nonstd.RetrieveAll_NON_STD_master();
                if (dtuser.Tables[0].Rows.Count > 0)
                {

                    Alert_msg("Currency Code already exists!", "txtEx_name");

                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Currency Code already exists!')</script>", false);

                }
            }
            catch (Exception ex)
            {
                er.makeLog(ex.Message);
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
            }
        }
        txtEx_name.Focus();
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'NON CURRENCY MASTER', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'NON CURRENCY MASTER', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
}