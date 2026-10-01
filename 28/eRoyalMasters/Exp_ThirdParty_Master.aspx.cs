
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

public partial class eRoyalMasters_EXP_THIRDPARTY_Master : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    eroyalmaster erm = new eroyalmaster();
    DataSet dtuser = new DataSet();
    public int i;
    public string AUTO_ID;

    SqlConnection con;
    SqlCommand cmd;
    Manipulation mo = new Manipulation();
    AppSession aps = new AppSession();
    public string BUYER_ID = "";
    ErrorLogs er = new ErrorLogs();
    DropDownList ddl = new DropDownList();
    string SP_QUERY;

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;

    public int Screen_Id;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
       
        txtName.Focus();

        if (!IsPostBack)
        {
            //----------------SETTING SCREEN PERMISSION---------------//
            Screen_Id = 5;
            Page_Rights(Screen_Id);
            //txtCustomsHouse.Attributes.Add("readonly", "readonly");

            //txtIECNo.Attributes.Add("readonly", "readonly");
            //txtAddress1.Attributes.Add("readonly", "readonly");
            //----------------SETTING SCREEN PERMISSION---------------//
            ///auto search

           
            //txtCountryName.Attributes.Add("onblur", "javascript:CallMe('" + txtCountryName.ClientID + "', '" + txtCountryCode.ClientID + "')");
            ///auto search
            EditSupDetails();
           
            
        }

     

    }
    public void Page_Rights(int i)
    {
        try
        {
            user_Create.RetrieveAll_User_Screen_Rights_Details(i);
            PAGE_WRITE = user_Create.PAGE_WRITE;
            PAGE_READ = user_Create.PAGE_READ;
            PAGE_MODIFY = user_Create.PAGE_MODIFY;
            PAGE_DELETE = user_Create.PAGE_DELETE;

            //---------------READ ONLY------------------//

            if (PAGE_READ == "False")
            {
                btnSave.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnNew.Enabled = false;
                btnNew.ToolTip = "You don't have permission to access";
                btnSave.ToolTip = "You don't have permission to access";
                btnUpdate.ToolTip = "You don't have permission to access";
                btnDelete.ToolTip = "You don't have permission to access";
            }
            else
            {


                //}
                //btnNew.Enabled = true;
                //---------------SAVE BUTTON------------------//
                if (PAGE_WRITE == "True")
                {
                    btnSave.Enabled = true;
                    btnNew.Enabled = true;

                }
                else
                {
                    btnSave.Enabled = false;
                    btnSave.ToolTip = "You don't have permission to access";
                    btnNew.Enabled = false;

                }
                //---------------UPDATE BUTTON------------------//

                if (PAGE_MODIFY == "True")
                    btnUpdate.Enabled = true;
                else
                {
                    btnUpdate.Enabled = false;
                    btnUpdate.ToolTip = "You don't have permission to access";

                }
                //---------------DELETE BUTTON------------------//

                if (PAGE_DELETE == "True")
                    btnDelete.Enabled = true;
                else
                {
                    btnDelete.Enabled = false;
                    btnDelete.ToolTip = "You don't have permission to access";

                }
            }
        }
        catch (Exception ex) 
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
       
    }
    public void EditSupDetails()
    {
        try
        {
            if (Request.QueryString["THIRDPARTY_ID"] != "" && Request.QueryString["THIRDPARTY_ID"] != null)
            {
                int i = 0;
                BUYER_ID = Request.QueryString["THIRDPARTY_ID"];

                erm.Ebuyerid = BUYER_ID;
                erm.Ebuyer_name = "0";
                erm.Ename = "select_conwithcode";
                erm.EWorking_Period = Working_Period;

                dtuser = erm.RetrieveAll_Exp_ThirdParty_MASTER();
                if (dtuser.Tables[0].Rows.Count > 0)
                {

                    txtName.Text = dtuser.Tables[0].Rows[0]["THIRDPARTY_NAME"].ToString();
                    txtAdd1.Text = dtuser.Tables[0].Rows[0]["THIRDPARTY_ADD1"].ToString();
                    txtAdd2.Text = dtuser.Tables[0].Rows[0]["THIRDPARTY_ADD2"].ToString();
                    txtCity.Text = dtuser.Tables[0].Rows[0]["THIRDPARTY_CITY"].ToString();
                    txtctydivision.Text = dtuser.Tables[0].Rows[0]["THIRDPARTY_COUNTRY_SUBDIVISION"].ToString();
                    txtCountryCode.Text = dtuser.Tables[0].Rows[0]["THIRDPARTY_COUNTRY_CODE"].ToString();
                    txttermsplace.Text = dtuser.Tables[0].Rows[0]["TERMS_PLACE"].ToString();
                    txtpartypin.Text = dtuser.Tables[0].Rows[0]["THIRDPARTY_PIN"].ToString();
                    txtaeocode.Text = dtuser.Tables[0].Rows[0]["AEO_CODE"].ToString();
                    txtaeocountry.Text = dtuser.Tables[0].Rows[0]["AEO_COUNTRY"].ToString();
                    txtaeorole.Text = dtuser.Tables[0].Rows[0]["AEO_ROLE"].ToString();

                    hdn_Update_BUYER_Name.Value = txtName.Text;
                    //FOR UPDATED SUCCESSFULLY
                    ViewState["UPDATED_ID"] = null;
                    ViewState["UPDATED_ID"] = Request.QueryString["THIRDPARTY_ID"].ToString();
                    //FOR UPDATED SUCCESSFULLY
                }
                HiddenField1.Value = Request.QueryString["THIRDPARTY_ID"].ToString();

                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = true;
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

    public int insert_update(string a1, string a2)
    {
        try
        {
            erm.THIRDPARTY_ID = a1;
            erm.THIRDPARTY_NAME = txtName.Text;
            erm.THIRDPARTY_ADD1 = txtAdd1.Text;
            erm.THIRDPARTY_ADD2 = txtAdd2.Text;
            erm.THIRDPARTY_CITY = txtCity.Text;
            erm.THIRDPARTY_COUNTRY_SUBDIVISION = txtctydivision.Text;
            erm.THIRDPARTY_COUNTRY_CODE = txtCountryCode.Text;
            erm.TERMS_PLACE = txttermsplace.Text;
            erm.THIRDPARTY_PIN = txtpartypin.Text;
            erm.AEO_CODE = txtaeocode.Text;
            erm.AEO_COUNTRY = txtaeocountry.Text;
            erm.AEO_ROLE = txtaeorole.Text;
            erm.USER_ID = currentuser;
            erm.BRANCH_CODE = currentbranch;
            erm.flag = a2;

            erm.EWorking_Period = Working_Period;

            i = erm.ThirdParty_Master_Insert_update();
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
        if (txtName.Text != "" && txtAdd1.Text != "")
        {
            try
            {
                string a1 = "";
                string a2 = "S";
                string a3 = "";
                i = insert_update(a1, a2);
                HiddenField1.Value = Convert.ToString(erm.UPDATE_ID);
              
                if (i == 1)
                {
                    //-----------------------FOR USER RIGHTS--------------------------------//
                    user_Create.RetrieveAll_User_Screen_Rights_Details(Screen_Id);

                    PAGE_MODIFY = user_Create.PAGE_MODIFY;


                    //---------------SAVE ONLY------------------//

                    if (PAGE_MODIFY == "False")
                    {
                        btnNew_Click(sender, e);

                    }
                    else
                    {
                        btnUpdate.CssClass = "save";
                        btnUpdate.Visible = true;
                        btnSave.Visible = false;
                        hdn_Update_BUYER_Name.Value = txtName.Text;

                    }
                    //-----------------------FOR USER RIGHTS--------------------------------//

                    ViewState["UPDATED_ID"] = null;
                    Alert_msg("Saved Successfully", "btnSave");
                }
                else if (i == 2)
                {

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Consignor already exixts!')</script>", false);
                    //btnSave.Focus();
                    Alert_msg("ThirdParty already exixts!", "btnSave");
                }
                else
                {
                    Alert_msg("ThirdParty Not Saved", "btnNew");
                }
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('BUYER Not Saved')</script>", false);
            }
            catch (Exception ex)
            {
                er.makeLog(ex.Message);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
            }
        }
        else
        {
            Alert_msg("Enter All Mandatory Field", "btnNew");

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Enter All Mandatory Field')</script>", false);
        }
    }

    public void Clear()
    {
        try
        {
            txtName.Text = "";
            txtAdd1.Text = "";
            txtAdd2.Text = "";
            txtCity.Text = "";
            txtctydivision.Text = "";
            txtCountryCode.Text = "";
            txttermsplace.Text = "";
            txtpartypin.Text = "";
            txtaeocode.Text = "";
            txtaeocountry.Text = "";
            txtaeorole.Text = "";
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
            Session["SUP_ID"] = "";
            mo.ResetFields(Page.Controls);
            txtName.Focus();
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnNew.Visible = true;
            btnSave.Visible = true;
            hdn_Update_BUYER_Name.Value = "";
            ViewState["UPDATED_ID"] = null;
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
            i = insert_update(a1, a2);
            if (i ==1)
            {
                hdn_Update_BUYER_Name.Value = txtName.Text;
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
                
               // btnUpdate.Focus();
                
            }
            else if (i == 2)
            {
                Alert_msg("ThirdParty already exixts!", "btnUpdate");

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Consignor already exixts!')</script>", false);
                //btnUpdate.Focus();
            }
            else
            {
                Alert_msg("ThirdParty Not Saved", "btnUpdate");

               // ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('BUYER Not Saved')</script>", false);
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            erm.Ebuyerid = HiddenField1.Value;
            erm.Ebuyer_name = "0";
            erm.Ename = "delete";
            erm.EWorking_Period = Working_Period;
            erm.RetrieveAll_Exp_ThirdParty_MASTER();
            int i = erm.result;
            if (i > 0)
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('THIRDPARTY Deleted', 'THIRDPARTY MASTER', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('BUYER Deleted')</script>", false);

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "RefreshParent", "<script language='javascript'>RefreshParent()</script>", false);
            }
            else
            {
                Alert_msg("ThirdParty Not Deleted");

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('BUYER Not Deleted')</script>", false);
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
    }

    protected void txtName_TextChanged(object sender, EventArgs e)
    {
        if (hdn_Update_BUYER_Name.Value != txtName.Text)
        {
            try
            {
                erm.Ebuyerid = "0";
                erm.Ebuyer_name = txtName.Text;
                erm.Ename = "Check_THIRDPARTY_NAME";
                erm.EWorking_Period = Working_Period;
                dtuser = erm.RetrieveAll_Exp_ThirdParty_MASTER();
                if (dtuser.Tables[0].Rows.Count > 0)
                {

                    Alert_msg("ThirdParty already exists!", "txtAdd1");

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Consignor already exists!')</script>", false);
                }
            }
            catch (Exception ex)
            {
                er.makeLog(ex.Message);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
            }

        }
        txtAdd1.Focus();
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'THIRDPARTY MASTER', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'THIRDPARTY MASTER', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    ///auto search
    [System.Web.Services.WebMethod]
    public static string GetCountry_code(string custid)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            string name = "COUNTRY_MASTER_CODE";
            string rows = "COUNTRY_CODE";
            custid = Auto.Country_Master_FromClientSide_Calling(custid, name, rows);
            if (Auto.Ename != "1")
            {
                custid = "";
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
      
        return custid;
    }
    ///auto search

}