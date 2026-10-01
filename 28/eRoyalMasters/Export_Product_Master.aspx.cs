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


public partial class eRoyalMasters_EXPORT_Product : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    eroyalmaster erm = new eroyalmaster();
    SqlConnection con;
    SqlCommand cmd;
    DataSet dtuser = new DataSet();
    public int i;
    Manipulation mo = new Manipulation();
    AppSession aps = new AppSession();
    public string ADCODE_ID = "", AUTO_ID, PRODUCT_EXPORT_ID = "", RITC_NO;
    public string SUP_ID = "";
    ErrorLogs er = new ErrorLogs();
    DropDownList ddl = new DropDownList();
    Product_Export_Master product = new Product_Export_Master();
    DataSet dss = new DataSet();
    DataSet ds_str = new DataSet();
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
        try
        {
            aps.checkSession();
            con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);

            currentuser = Session["currentuser"].ToString();
            currentbranch = Session["currentbranch"].ToString();
            currentcomp_name = Session["currentcomp_name"].ToString();
            comp_ConnectionStr = Session["currentcomp_db"].ToString();
            Working_Period = Session["WorkingPeriod"].ToString();
            LoginDate = Session["LoginDate"].ToString();


            if (!IsPostBack)
            {
                //----------------SETTING SCREEN PERMISSION---------------//
                Screen_Id = 28;
                Page_Rights(Screen_Id);
                //----------------SETTING SCREEN PERMISSION---------------//
                ///auto search

                //txtCountryName.Attributes.Add("onkeyup", "javascript:CallMe('" + txtCountryName.ClientID + "', '" + txtCountryCode.ClientID + "')");
                //txtDrawback_SLNo.Attributes.Add("onblur", "javascript:CallServerside_Drawback('" + txtDrawback_SLNo.ClientID + "')");

                txtRITCNo.Attributes.Add("onkeyup", "javascript:CallServerside_RITC('" + txtRITCNo.ClientID + "', '" + txtDesc.ClientID + "')");

                //txtDesc.Text =HttpContext.Current.Session["RITC_ITEMDESC"].ToString();

                Edit_Export_Product_Details();
                Get_STR_Code();
            }
            if (IsPostBack)
            {
                Session["EXP_RITCNO"] = txtRITCNo.Text;
                Get_STR_Code();
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
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
    public void Edit_Export_Product_Details()
    {
        try
        {
            if (Request.QueryString["PRODUCT_EXPORT_ID"] != "" && Request.QueryString["PRODUCT_EXPORT_ID"] != null)
            {
                int i = 0;
                PRODUCT_EXPORT_ID = Request.QueryString["PRODUCT_EXPORT_ID"];
                product.PRODUCT_EXPORT_ID = PRODUCT_EXPORT_ID;
                product.flag = "Select_bind_id";

                dtuser = product.Retrive_Export_ProductMaster();

                if (dtuser.Tables[0].Rows.Count > 0)
                {
                    txtDesc.Text = dtuser.Tables[0].Rows[0]["PRODUCT_DESCRIPTION"].ToString();
                    txtRITCNo.Text = dtuser.Tables[0].Rows[0]["PRODUCT_RITC"].ToString();
                    Session["EXP_RITCNO"] = txtRITCNo.Text;
                    Hdn_RITC_4_digit.Value = txtRITCNo.Text.Substring(0, 4);

                    if (dtuser.Tables[0].Rows[0]["REWARD_YES_NO"].ToString() == "Y")
                    {
                        ddlRewardYesNo.Text = "Yes";
                    }
                    else
                    {
                        ddlRewardYesNo.Text = "No";
                    }

                    if (dtuser.Tables[0].Rows[0]["STR_YES_NO"].ToString() == "Y")
                    {
                        ddlSTRYesNo.Text = "Yes";
                    }
                    else
                    {
                        ddlSTRYesNo.Text = "No";
                    }

                    txtSTRCode.Text = dtuser.Tables[0].Rows[0]["STR_CODE"].ToString();
                    Get_STR.Value = dtuser.Tables[0].Rows[0]["STR_CODE"].ToString();
                    txtDrawback_SLNo.Text = dtuser.Tables[0].Rows[0]["DBK_SL_NO"].ToString();
                    txtPARTNo.Text = dtuser.Tables[0].Rows[0]["PART_NO"].ToString();
                }

                HiddenField1.Value = Request.QueryString["PRODUCT_EXPORT_ID"].ToString();

                //FOR UPDATED SUCCESSFULLY
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = Request.QueryString["PRODUCT_EXPORT_ID"].ToString();
                //FOR UPDATED SUCCESSFULLY

                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnNew.Visible = true;
                btnSave.Visible = false;
                // txtName.Enabled = false;
            }
            else
            {
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnNew.Visible = true;
                btnSave.Visible = true;
                //txtName.Enabled = true;

                //Session["EXP_RITCNO"] = txtRITCNo.Text;
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
        mo.ResetFields(Page.Controls);
    }

    public int insert_update(string a1, string a2, string a3)
    {
        int i = 0;
        try
        {
            product.PRODUCT_EXPORT_ID = HiddenField1.Value;
            product.PRODUCT_DESCRIPTION = txtDesc.Text.Trim();
            product.PRODUCT_RITC = txtRITCNo.Text;
            product.REWARD_YES_NO = ddlRewardYesNo.SelectedItem.Text;
            product.STR_YES_NO = ddlSTRYesNo.SelectedItem.Text;
            product.STR_CODE = txtSTRCode.Text;
            product.DBK_SL_NO = txtDrawback_SLNo.Text;
            product.PARTNO = txtPARTNo.Text;
            product.flag = a2;

            i = product.Product_Export_Insert_Update();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

        return i;

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtDesc.Text != "" && txtRITCNo.Text != "")
        {
            if ((ddlSTRYesNo.SelectedItem.Text == "Yes" && txtSTRCode.Text != "") || (ddlSTRYesNo.SelectedItem.Text == "No" && txtSTRCode.Text == ""))
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
                            btnSave.Focus();
                            //hdn_Update_SupName.Value = txtName.Text;
                        }
                        //-----------------------FOR USER RIGHTS--------------------------------//              

                        ViewState["UPDATED_ID"] = null;
                        Alert_msg("Saved Successfully", "btnSave");

                    }
                    else if (i == 2)
                    {
                        Alert_msg("Product already exixts!", "btnSave");

                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Supplier already exixts!')</script>", false);
                        //btnSave.Focus();
                    }
                    else
                    {
                        Alert_msg("Product Not Saved", "btnNew");

                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Supplier Not Saved')</script>", false);
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
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            product.PRODUCT_EXPORT_ID = HiddenField1.Value;
            product.flag = "delete";

            dss = product.Retrive_Export_ProductMaster();
            int ii = product.result;

            if (ii > 0)
            {
                ViewState["UPDATED_ID"] = null;
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Supplier Deleted')</script>", false);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "RefreshParent", "<script language='javascript'>RefreshParent()</script>", false);


                string prompt = "<script>$(document).ready(function(){{jAlert('Product Deleted', 'PRODUCT MASTER', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);

            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Supplier Not Deleted')</script>", false);
                Alert_msg("Product Not Deleted");
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
        if ((ddlSTRYesNo.SelectedItem.Text == "Yes" && txtSTRCode.Text != "") || (ddlSTRYesNo.SelectedItem.Text == "No" && txtSTRCode.Text == ""))
        {
            try
            {
                string a1 = HiddenField1.Value;
                string a2 = "U";
                string a3 = "";
                i = insert_update(a1, a2, a3);
                if (i == 1)
                {
                    //hdn_Update_SupName.Value = txtDesc.Text;
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
                    Alert_msg("Product already exixts!", "btnUpdate");

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Supplier already exixts!')</script>", false);
                    //btnUpdate.Focus();
                }
                else
                {
                    Alert_msg("Product Not Saved", "btnUpdate");

                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Supplier Not Saved')</script>", false);
                    //btnUpdate.Focus();
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
        }
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            Session["SUP_ID"] = "";

            Clear();
            txtDesc.Focus();
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnNew.Visible = true;
            btnSave.Visible = true;
            txtDesc.Enabled = true;
            hdn_Update_SupName.Value = "";
            ViewState["UPDATED_ID"] = null;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
       
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'PRODUCT MASTER', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'PRODUCT MASTER', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Get_STR_Code()
    {
        try
        {
            adminmaster Admin_mas = new adminmaster();

            if (txtRITCNo.Text.Length == 8)
            {

                Admin_mas.STR_ID = "0";
                Admin_mas.STR_SRNO = txtRITCNo.Text.Substring(0, 2);
                Admin_mas.Ename = "select_value";

                ds_str = Admin_mas.RetrieveAll_STR_master();

                if (ds_str.Tables[0].Rows.Count > 0)
                {
                    //txtSTRCode.Text = ds_str.Tables[0].Rows[0]["STR_SRNO"].ToString();
                    Get_STR.Value = ds_str.Tables[0].Rows[0]["STR_SRNO"].ToString();
                }
                else
                {
                    Admin_mas.STR_SRNO = txtRITCNo.Text.Substring(0, 4);
                    Admin_mas.Ename = "select_value";
                    ds_str = Admin_mas.RetrieveAll_STR_master();
                    //txtSTRCode.Text = ds_str.Tables[0].Rows[0]["STR_SRNO"].ToString();
                    Get_STR.Value = ds_str.Tables[0].Rows[0]["STR_SRNO"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
        
    }

    //*********** AUTO SEARCH RITC NO & DESCRIPTION******************

    [System.Web.Services.WebMethod]
    public static string GetRITC_code_desc(string mail)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();

            if (mail.Length == 8)
            {
                Auto.Enamesearch = mail;
                Auto.NSearch = "";
                Auto.Ename = "RITC_CODE_MASTER_BIND_ALL";

                ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    string RITC = ds.Tables[0].Rows[0]["RITC_CODE"].ToString();
                    string DESC = ds.Tables[0].Rows[0]["RITC_ITEMDESC"].ToString();

                    mail = RITC + "~~" + DESC;
                }

                //string str = get(mail);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
        return mail;
    }

}