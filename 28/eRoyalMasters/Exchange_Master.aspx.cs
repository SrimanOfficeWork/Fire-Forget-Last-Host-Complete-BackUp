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


public partial class eRoyalMasters_Exchange_Master : ThemeClass
{
    eroyalmaster erm = new eroyalmaster();
    SqlConnection con;
    SqlCommand cmd;
    DataSet dtuser = new DataSet();
    Manipulation mo = new Manipulation();
    AppSession aps = new AppSession();
    public string EXCHANGE_ID = "";
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
    public DateTime Exchange_Date_From, Exchange_Date_To, Exchange_NONT_Date;


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



            DateTime dat = System.DateTime.Now;
            datestring = string.Format("{0:dd/MM/yyyy}", dat);

            txtExchange_Date_From.Text = datestring;
            txtExchange_Date_To.Text = datestring;
            txtExchange_NONT_Date.Text = datestring;


            ddlExchange.Items.Clear();




            ddlExchange.Items.Add("Y");
            ddlExchange.Items.Add("N");
            Edit_ExchangeDetails();

        }

    }

    public void Edit_ExchangeDetails()
    {
        if (Request.QueryString["EXCHANGE_ID"] != "" && Request.QueryString["EXCHANGE_ID"] != null)
        {
            int i = 0;
            EXCHANGE_ID = Request.QueryString["EXCHANGE_ID"];


            erm.Eexchange_id = EXCHANGE_ID;
            erm.Eexchange_effect_dt_from = "01/01/1900";
            erm.Eexchange_effect_dt_to = "01/01/1900";
            erm.Eexchange_nont_no = "0";
            erm.Eexchange_notn_date = "01/01/1900";
            erm.Ename = "select_conwithcode";
            erm.EWorking_Period = Working_Period;


            dtuser = erm.RetrieveAll_Exchange_master();

            if (dtuser.Tables[0].Rows.Count > 0)
            {
                DateTime EFFECT_DT_FROM = Convert.ToDateTime(dtuser.Tables[0].Rows[0]["EXCHANGE_EFFECT_DT_FROM"].ToString());


                txtExchange_Date_From.Text = string.Format("{0:dd/MM/yyyy}", EFFECT_DT_FROM);

                DateTime EFFECT_DT_TO = Convert.ToDateTime(dtuser.Tables[0].Rows[0]["EXCHANGE_EFFECT_DT_TO"].ToString());

                txtExchange_Date_To.Text = string.Format("{0:dd/MM/yyyy}", EFFECT_DT_TO);

                txtExchange_NONT_NO.Text = dtuser.Tables[0].Rows[0]["EXCHANGE_NONT_NO"].ToString();

                DateTime EXCHANGE_NOTN_DATE = Convert.ToDateTime(dtuser.Tables[0].Rows[0]["EXCHANGE_NOTN_DATE"].ToString());


                txtExchange_NONT_Date.Text = string.Format("{0:dd/MM/yyyy}", EXCHANGE_NOTN_DATE);

                txtExchange_Cur_Code.Text = dtuser.Tables[0].Rows[0]["EXCHANGE_CUR_CODE"].ToString();
                txtExchange_Name.Text = dtuser.Tables[0].Rows[0]["EXCHANGE_NAME"].ToString();
                txtExchange_Per_Unit.Text = dtuser.Tables[0].Rows[0]["EXCHANGE_PER_UNIT"].ToString();
                txtExchange_Rate_Import.Text = dtuser.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();
                txtExchange_Rate_Export.Text = dtuser.Tables[0].Rows[0]["EXCHANGE_RATE_EXPORT"].ToString();
                string EXCHANGE_Y_N = dtuser.Tables[0].Rows[0]["EXCHANGE_S_OR_N"].ToString();
               // ddlExchange.Items.Add(dtuser.Tables[0].Rows[0]["EXCHANGE_S_OR_N"].ToString());
                ddlExchange.Items.Clear();
                ddlExchange.Items.Add("Y");
                ddlExchange.Items.Add("N");

                ddlExchange.Items.Remove(EXCHANGE_Y_N);

                ddlExchange.Items.Insert(0, EXCHANGE_Y_N);
                HiddenField1.Value = Request.QueryString["EXCHANGE_ID"].ToString();
                //Edit_ExchangeDetails();
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnNew.Visible = true;
                btnSave.Visible = false;
                hdn_Update_Exchange.Value = txtExchange_Cur_Code.Text;
                //FOR UPDATED SUCCESSFULLY
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = Request.QueryString["EXCHANGE_ID"].ToString();
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

    public void Clear()
    {
        txtExchange_Date_From.Text = datestring;
        txtExchange_Date_To.Text = datestring;
        txtExchange_NONT_Date.Text = datestring;
        txtExchange_NONT_NO.Text = "";
        txtExchange_Cur_Code.Text = "";
        txtExchange_Name.Text = "";
        txtExchange_Per_Unit.Text = "";
        txtExchange_Rate_Import.Text = "";
        txtExchange_Rate_Export.Text = "";
        ddlExchange.SelectedIndex = 0;

        

    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        //Clear();
        mo.ResetFields(Page.Controls);
        txtExchange_Date_From.Text = datestring;
        txtExchange_Date_To.Text = datestring;
        txtExchange_NONT_Date.Text = datestring;
        txtExchange_Date_From.Focus();
        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnNew.Visible = true;
        btnSave.Visible = true;
        ddlExchange.Items.Clear();
        ddlExchange.Items.Add("Y");
        ddlExchange.Items.Add("N");
        hdn_Update_Exchange.Value = "";
        ViewState["UPDATED_ID"] = null;
        
    }

    public int insert_update(string a1, string a2, string a3)
    {
        Exchange_Date_From = DateTime.Parse(txtExchange_Date_From.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

        Exchange_Date_To = DateTime.Parse(txtExchange_Date_To.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

        Exchange_NONT_Date = DateTime.Parse(txtExchange_NONT_Date.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
        if (HiddenField1.Value != "")
            erm.EXCHANGE_ID = HiddenField1.Value;
        else
            erm.EXCHANGE_ID = "";
        erm.EXCHANGE_NAME = txtExchange_Name.Text;
        erm.EXCHANGE_NONT_NO = txtExchange_NONT_NO.Text;
        erm.EXCHANGE_NOTN_DATE = Convert.ToString(Exchange_NONT_Date);
        erm.EXCHANGE_PER_UNIT = txtExchange_Per_Unit.Text;
        erm.EXCHANGE_RATE_EXPORT = txtExchange_Rate_Import.Text;
        erm.EXCHANGE_RATE_IMPORT = txtExchange_Rate_Export.Text;
        erm.EXCHANGE_S_OR_N = ddlExchange.SelectedValue.ToString();
        erm.EXCHANGE_CUR_CODE = txtExchange_Cur_Code.Text;
        erm.EXCHANGE_EFFECT_DT_FROM = Convert.ToString(Exchange_Date_From);
        erm.EXCHANGE_EFFECT_DT_TO = Convert.ToString(Exchange_Date_To);

        erm.USER_ID = currentuser;
        erm.BRANCH_CODE = currentbranch;
        erm.flag = a2;
        erm.YEAR = a3;
        erm.EWorking_Period = Working_Period;

        i = erm.Exchange_Master_Insert_update();
        return i;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtExchange_Date_From.Text != "" && txtExchange_Date_To.Text != "" && txtExchange_NONT_Date.Text != "" && txtExchange_NONT_NO.Text != "" && txtExchange_Cur_Code.Text != "" && txtExchange_Name.Text != "" && txtExchange_Per_Unit.Text != "" && txtExchange_Rate_Import.Text != "" && txtExchange_Rate_Export.Text != "")
        {
            try
            {
                string a1 = "";
                string a2 = "S";
                string a3 = "";
                i = insert_update(a1, a2, a3);
                HiddenField1.Value = Convert.ToString(erm.UPDATE_ID);
              
                if (i == 1)
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);

                    btnUpdate.CssClass = "save";
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                    ViewState["UPDATED_ID"] = null;

                    btnSave.Focus();
                    hdn_Update_Exchange.Value = txtExchange_Cur_Code.Text;
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

            erm.Eexchange_id = HiddenField1.Value; 
            erm.Eexchange_effect_dt_from = "0";
            erm.Eexchange_effect_dt_to = "0";
            erm.Eexchange_nont_no = "0";
            erm.Eexchange_notn_date = "0";
            erm.Ename = "delete";
            erm.EWorking_Period = Working_Period;

            erm.RetrieveAll_Exchange_master();
            int ii = 0;
            ii = erm.result;

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
                hdn_Update_Exchange.Value = txtExchange_Cur_Code.Text;
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
        }
    }
    protected void txtExchange_Cur_Code_TextChanged(object sender, EventArgs e)
    {
        if (hdn_Update_Exchange.Value != txtExchange_Cur_Code.Text)
        {
            try
            {
                //here using Eexchange_nont_no Instead of Exchange CurrencyCode
                erm.Eexchange_id = "0";
                erm.Eexchange_effect_dt_from = "0";
                erm.Eexchange_effect_dt_to = "0";
                erm.Eexchange_nont_no = txtExchange_Cur_Code.Text;
                erm.Eexchange_notn_date = "0";
                erm.Ename = "Check_Exchange";
                erm.EWorking_Period = Working_Period;

                dtuser=erm.RetrieveAll_Exchange_master();
                if (dtuser.Tables[0].Rows.Count > 0)
                {

                    Alert_msg("Currency Code already exists!", "txtExchange_Name");

                   // ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Currency Code already exists!')</script>", false);

                }




            }
            catch (Exception ex)
            {
                er.makeLog(ex.Message);
            }
        }
        txtExchange_Name.Focus();
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'EXCHANGE MASTER', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'EXCHANGE MASTER', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
}