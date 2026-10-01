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


public partial class eRoyalMasters_Adcode_Master : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    eroyalmaster erm = new eroyalmaster();
    SqlConnection con;
    SqlCommand cmd;
    DataSet dtuser = new DataSet();
    Manipulation mo = new Manipulation();
    AppSession aps = new AppSession();
    public string ADCODE_ID = "";
    ErrorLogs er = new ErrorLogs();
    DropDownList ddl = new DropDownList();
    string SP_QUERY;

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public int i, Update_Id;
    public string AUTO_ID;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;

    public int Screen_Id;
    public string click_SaveNew = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();

            txtLicense_No.Focus();
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
                Screen_Id = 6;
                Page_Rights(Screen_Id);
                //----------------SETTING SCREEN PERMISSION---------------//
                //auto search

                //txtLicense_No.Attributes.Add("onkeyup", "javascript:Call_Client_Name('" + txtLicense_No.ClientID + "', '" + txtIec_Name.ClientID + "')");
                //txtLicense_No.Attributes.Add("onblur", "javascript:Call_Client_Name('" + txtLicense_No.ClientID + "', '" + txtIec_Name.ClientID + "')");
                //auto search
                ddl_bind();
                EditSupDetails();
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
       
    }

    public void ddl_bind()
    {
        try
        {
            ddlLicense_type.Items.Clear();
            ddlLicense_type.Items.Add("DEEC");
            ddlLicense_type.Items.Add("EPCG");
            ddlLicense_type.Items.Add("DFIA");
            ddlNM_type.Items.Clear();
            ddlNM_type.Items.Add("Indigenous");
            ddlNM_type.Items.Add("Imported");
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
                btnSaveNew.Enabled = false;
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
                    btnSaveNew.Enabled = true;
                }
                else
                {
                    btnSave.Enabled = false;
                    btnSave.ToolTip = "You don't have permission to access";
                    btnNew.Enabled = false;
                    btnSaveNew.Enabled = false;
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
            if (Request.QueryString["LICENSE_ID"] != "" && Request.QueryString["LICENSE_ID"] != null)
            {

                txtLicense_No.Enabled = false;
                ADCODE_ID = Request.QueryString["LICENSE_ID"];

                erm.LICENSE_ID = ADCODE_ID;
                erm.LICENSE_NO = "0";
                erm.Ename = "select_conwithcode";
                erm.EWorking_Period = Working_Period;

                dtuser = erm.RetrieveAll_License_MASTER();
                if (dtuser.Tables[0].Rows.Count > 0)
                {

                    txtLicense_No.Text = dtuser.Tables[0].Rows[0]["LICENSE_NO"].ToString();
                    txtLicense_date.Text = dtuser.Tables[0].Rows[0]["LICENSE_DATE"].ToString();
                    txtReg_No.Text = dtuser.Tables[0].Rows[0]["LICENSE_R_SL_NO"].ToString();
                    txtReg_date.Text = dtuser.Tables[0].Rows[0]["LICENSE_REG_DATE"].ToString();
                    string Category_mode = dtuser.Tables[0].Rows[0]["LICENSE_REG_TYPE"].ToString();
                    ddlLicense_type.Items.Clear();
                    ddlLicense_type.Items.Add("DEEC");
                    ddlLicense_type.Items.Add("EPCG");
                    ddlLicense_type.Items.Add("DFIA");

                    ddlLicense_type.Items.Remove(Category_mode);
                    ddlLicense_type.Items.Insert(0, Category_mode);
                    txtItem_Slno.Text = dtuser.Tables[0].Rows[0]["LICENSE_ITEM_SL_NO"].ToString();
                    txtDescription.Text = dtuser.Tables[0].Rows[0]["LICENSE_ITEM_DESCRIPTION"].ToString();
                    txtTotImportQty.Text = dtuser.Tables[0].Rows[0]["LICENSE_QTY"].ToString();
                    txtUnit.Text = dtuser.Tables[0].Rows[0]["LICENSE_UNIT"].ToString();
                    txt_Exp_Item_Slno.Text = dtuser.Tables[0].Rows[0]["LICENSE_EXP_ITEM_SLNO"].ToString();
                    txtLicense_Expireddate.Text = dtuser.Tables[0].Rows[0]["LIC_EXPIRED_DATE"].ToString();
                    txtTotExportQty.Text = dtuser.Tables[0].Rows[0]["LICENSE_EXP_QTY"].ToString();
                    txtExpUnit.Text = dtuser.Tables[0].Rows[0]["LICENSE_EXP_UNIT"].ToString();

                    string NM_type = dtuser.Tables[0].Rows[0]["LICENSE_TYPE"].ToString();
                    ddlNM_type.Items.Clear();

                    if (NM_type == "N")
                        NM_type = "Indigenous";
                    else if (NM_type == "M")
                    {
                        NM_type = "Imported";
                    }
                    ddlNM_type.Items.Add("Indigenous");
                    ddlNM_type.Items.Add("Imported");
                    ddlNM_type.Items.Remove(NM_type);
                    ddlNM_type.Items.Insert(0, NM_type);
                    hdn_Update_Adcode.Value = txtLicense_No.Text;
                    //FOR UPDATED SUCCESSFULLY
                    ViewState["UPDATED_ID"] = null;
                    ViewState["UPDATED_ID"] = Request.QueryString["LICENSE_ID"].ToString();
                    //FOR UPDATED SUCCESSFULLY

                    Get_Remaining_Qty_Details(txtLicense_No.Text, Category_mode, txt_Exp_Item_Slno.Text, txtItem_Slno.Text);
                }
                HiddenField1.Value = Request.QueryString["LICENSE_ID"].ToString();
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                btnSaveNew.Visible = false;
            }
            else
            {
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                btnSaveNew.Visible = true;
            }  
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
        
    }

    private void Get_Remaining_Qty_Details(string LicenseNo, string Scheme, string Exp_ItemSlno, string Imp_ItemSlno)
    {
        try
        {
            DataSet dt_Rem = new DataSet();
            erm.LICENSE_NO = LicenseNo;
            erm.LICENSE_REG_TYPE = Scheme;
            erm.LICENSE_R_SL_NO = Exp_ItemSlno;
            erm.LICENSE_ITEM_SL_NO = Imp_ItemSlno;

            erm.Ename = "Get_Imp_Exp_Remaining_Qty";
            erm.EWorking_Period = Working_Period;

            dt_Rem = erm.RetrieveAll_License_MASTER();
            if (dt_Rem.Tables[0].Rows.Count > 0)
            {
                txt_Remaining_ExportQty.Text = dt_Rem.Tables[0].Rows[0]["Remaning_Exp_Qty"].ToString();
                txt_Remaining_ImportQty.Text = dt_Rem.Tables[0].Rows[0]["Remaning_Imp_Qty"].ToString();
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
        Transaction trans = new Transaction();
        trans.ResetFields(Page.Controls);
    }

    protected void btnSave_Click(object sender, EventArgs e)
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
                if (click_SaveNew == "SaveNew_Click")
                {
                    txtItem_Slno.Focus();
                }
                else
                {
                    btnUpdate.CssClass = "save";
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                    txtLicense_No.Enabled = false;
                    Alert_msg("Saved Successfully", "btnSave");
                }

                ViewState["UPDATED_ID"] = null;
            }
            else if (i == 2)
            {
                Alert_msg("License No already exixts!", "btnSave");
            }
            else
            {
                Alert_msg("License Not Saved", "btnNew");
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
                hdn_Update_Adcode.Value = txtLicense_No.Text;
                if (ViewState["UPDATED_ID"] != null)
                {
                    Alert_msg("Updated Successfully", "btnUpdate");
                }
                else
                {
                    Alert_msg("Saved Successfully", "btnUpdate");
                }

            }
            else if (i == 2)
            {
                Alert_msg("Item S.No already exixts!", "btnUpdate");
            }
            else
            {
                Alert_msg("Item S.No Not Saved", "btnUpdate");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
    }

    public int insert_update(string a1, string a2, string a3)
    {
        try
        {
            erm.LICENSE_ID = a1;
            erm.LICENSE_NO = txtLicense_No.Text;
            erm.LICENSE_DATE = txtLicense_date.Text;
            erm.LICENSE_R_SL_NO = txtReg_No.Text;

            erm.LICENSE_REG_DATE = "01/01/1900";
            erm.LICENSE_REG_TYPE = ddlLicense_type.SelectedValue.ToString();
            erm.LICENSE_ITEM_SL_NO = txtItem_Slno.Text;
            erm.LICENSE_ITEM_DESCRIPTION = txtDescription.Text;
            erm.LICENSE_QTY = txtTotImportQty.Text;
            erm.LICENSE_UNIT = txtUnit.Text;
            string nmtype = "";
            if (ddlNM_type.SelectedValue.ToString() == "Indigenous")
                nmtype = "N";
            else if (ddlNM_type.SelectedValue.ToString() == "Imported")
            {   
                nmtype = "M";
            }
            erm.LICENSE_TYPE = nmtype;
            erm.LICENSE_EXP_ITEM_SLNO = txt_Exp_Item_Slno.Text;
            erm.LIC_EXPIRED_DATE = txtLicense_Expireddate.Text == "" ? "01/01/1900" : txtLicense_Expireddate.Text;
            erm.LICENSE_EXP_QTY = txtTotExportQty.Text;
            erm.LICENSE_EXP_UNIT = txtExpUnit.Text;

            erm.USER_ID = currentuser;
            erm.BRANCH_CODE = currentbranch;
            erm.flag = a2;
            erm.YEAR = a3;
            erm.EWorking_Period = Working_Period;

            i = erm.License_Master_Insert_update();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
        
        return i;
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            erm.LICENSE_ID = HiddenField1.Value;
            erm.LICENSE_NO = "0";
            erm.Ename = "delete";
            erm.EWorking_Period = Working_Period;

            erm.RetrieveAll_License_MASTER();
            int ii = 0;
            ii = erm.result;

            if (ii > 0)
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('License Deleted', 'LICENSE MASTER', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            }
            else
            {
                Alert_msg("License Not Deleted");
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
            Session["LICENSE_ID"] = "";

            Clear();
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnNew.Visible = true;
            btnSave.Visible = true;
            btnSaveNew.Visible = true;
            hdn_Update_Adcode.Value = "";
            ViewState["UPDATED_ID"] = null;
            txtLicense_No.Enabled = true;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
        
    }

    protected void btnSaveNew_Click(object sender, EventArgs e)
    {
        try
        {
            click_SaveNew = "SaveNew_Click";
            btnSave_Click(sender, e);
            txtItem_Slno.Text = "";
            txtDescription.Text = "";
            txtTotImportQty.Text = "";
            txtUnit.Text = "";
            txtTotExportQty.Text = "";
            txtExpUnit.Text = "";

            txtItem_Slno.Focus();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
       
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'LICENSE MASTER', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'LICENSE MASTER', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    ///auto search
    [System.Web.Services.WebMethod]
    public static string GetClient_Name(string custid)
    {
        try
        {
            if (custid.Length == 10)
            {
                Auto_Search Auto = new Auto_Search();
                DataSet ds = new DataSet();
                Auto.Ename = "IMP_EXP_MASTER_IMPORTER_IECCODE_WISE";
                Auto.Enamesearch = custid;
                ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    custid = ds.Tables[0].Rows[0]["IMP_EXP_NAME"].ToString();
                }
                else
                {
                    custid = "";
                }
            }
            else
            {
                custid = "";
            }
        }
        catch (Exception Ex)
        {
            Connection.Error_Msg(Ex.Message);
        }
        
        return custid;
    }
    ///auto search
}