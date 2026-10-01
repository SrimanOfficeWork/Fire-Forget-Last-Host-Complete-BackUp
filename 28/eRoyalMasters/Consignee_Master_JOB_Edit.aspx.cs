using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


public partial class ListPopups_Consignee_Details_ListPopup_JOB : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    eroyalmaster erm = new eroyalmaster();
    Manipulation mo = new Manipulation();
    AppSession aps = new AppSession();

    DataSet dtuser = new DataSet();
    public int i;
    public string CONSIGNEE_ID = "", Working_Period;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public int Screen_Id;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        Working_Period = Session["WorkingPeriod"].ToString();
        txtName.Focus();

        if (!String.IsNullOrEmpty(Request.QueryString["Name"] as string))
        {
            Get_Consignee_ID_JobSearch();
        }

        //if (!String.IsNullOrEmpty(Request.QueryString["type"] as string))
        //{
        //    if (Request.QueryString["type"].ToString() == "Job")
        //    {
        //        // Session["CONSIGNEE_Master_Job_edit"] = "CONSIGNEE_Master_Job_edit";
        //        Get_Consignee_ID_JobSearch();
        //    }
        //}
        //else
        //{
        //    if (!String.IsNullOrEmpty(Request.QueryString["CONSIGNEE_ID"] as string))
        //    {
        //        hdn_id.Value = Request.QueryString["CONSIGNEE_ID"].ToString();
        //    }
        //}

        if (!IsPostBack)
        {
            //----------------SETTING SCREEN PERMISSION---------------//
            Screen_Id = 3;
            Page_Rights(Screen_Id);
            //----------------SETTING SCREEN PERMISSION---------------//
            txtCountryName.Attributes.Add("onblur", "javascript:CallMe('" + txtCountryName.ClientID + "', '" + txtCountryCode.ClientID + "')");
            EditSupDetails();
        }
    }

    public void Page_Rights(int i)
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

    public void EditSupDetails()
    {
        //if (Request.QueryString["CONSIGNEE_ID"] != "" && Request.QueryString["CONSIGNEE_ID"] != null)
        if (hdn_id.Value != "")
        {
            int i = 0;
            erm.Econsigneeid = hdn_id.Value;
            erm.Econsignee_name = "0";
            erm.Ename = "select_conwithcode";
            erm.EWorking_Period = Working_Period;

            dtuser = erm.RetrieveAll_Consignee_MASTER();
            if (dtuser.Tables[0].Rows.Count > 0)
            {

                txtName.Text = dtuser.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
                txtAdd1.Text = dtuser.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString();
                txtAdd2.Text = dtuser.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString();
                txtAdd3.Text = dtuser.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString();
                txtCountryName.Text = dtuser.Tables[0].Rows[0]["CONSIGNEE_COUNTRY_NAME"].ToString();
                txtCountryCode.Text = dtuser.Tables[0].Rows[0]["CONSIGNEE_COUNTRY_CODE"].ToString();
                txtPincode.Text = dtuser.Tables[0].Rows[0]["CONSIGNEE_PIN_CODE"].ToString();
                txtRemarks.Text = dtuser.Tables[0].Rows[0]["CONSIGNEE_REMARKS"].ToString();

                txtAdd4.Text = dtuser.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString();
                txtBranchSlNo.Text = dtuser.Tables[0].Rows[0]["CONSIGNEE_BRANCHSLNO"].ToString();


                hdn_Update_Consignee_Name.Value = txtName.Text;
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = hdn_id.Value;
            }
            HiddenField1.Value = hdn_id.Value;

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

    public int insert_update(string a1, string a2, string a3)
    {
        erm.CONSIGNEE_ID = a1;
        erm.CONSIGNEE_NAME = txtName.Text;
        erm.CONSIGNEE_ADD1 = txtAdd1.Text;
        erm.CONSIGNEE_ADD2 = txtAdd2.Text;
        erm.CONSIGNEE_ADD3 = txtAdd3.Text;
        erm.CONSIGNEE_COUNTRY_CODE = txtCountryCode.Text;
        erm.CONSIGNEE_COUNTRY_NAME = txtCountryName.Text;
        erm.CONSIGNEE_PIN_CODE = txtPincode.Text;
        erm.CONSIGNEE_REMARKS = txtRemarks.Text;

        erm.CONSIGNEE_ADD4 = txtAdd4.Text;
        erm.CONSIGNEE_BRANCHSLNO = txtBranchSlNo.Text;

        erm.USER_ID = Connection.Current_User();
        erm.BRANCH_CODE = Connection.Current_Branch();
        erm.flag = a2;
        erm.YEAR = a3;
        erm.EWorking_Period = Working_Period;

        i = erm.Consignee_Master_Insert_update();
        return i;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtName.Text != "" && txtAdd1.Text != "")
        {
            try
            {
                i = insert_update("", "S", "");
                HiddenField1.Value = Convert.ToString(erm.UPDATE_ID);
                Session["CONSIGNEE_Master_Job_edit"] = HiddenField1.Value;

                if (i == 1)
                {
                    //-----------------------FOR USER RIGHTS--------------------------------//
                    user_Create.RetrieveAll_User_Screen_Rights_Details(Screen_Id);
                    PAGE_MODIFY = user_Create.PAGE_MODIFY;
                    //---------------SAVE ONLY------------------//
                    Load_Elogix_Service("S");
                    if (PAGE_MODIFY == "False")
                    {
                        btnNew_Click(sender, e);
                    }
                    else
                    {
                        btnUpdate.CssClass = "save";
                        btnUpdate.Visible = true;
                        btnSave.Visible = false;
                        hdn_Update_Consignee_Name.Value = txtName.Text;
                    }
                    //-----------------------FOR USER RIGHTS--------------------------------//

                    ViewState["UPDATED_ID"] = null;
                    Alert_msg("Saved Successfully", "btnSave");

                }
                else if (i == 2)
                {
                    Alert_msg("Consignor already exixts!", "btnSave");
                }
                else
                {
                    Alert_msg("Consignee Not Saved", "btnNew");

                }
            }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
            }
        }
        else
        {
            Alert_msg("Enter All Mandatory Field", "btnNew");
        }
    }

    public void Clear()
    {
        txtName.Text = "";
        txtAdd1.Text = "";
        txtAdd2.Text = "";
        txtAdd3.Text = "";
        txtCountryName.Text = "";
        txtCountryCode.Text = "";
        txtPincode.Text = "";
        txtRemarks.Text = "";
        txtBranchSlNo.Text = "";
        txtAdd4.Text = "";
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
       // Session["SUP_ID"] = "";
        Session["CONS_NEW"] = "New";

        mo.ResetFields(Page.Controls);
        txtName.Focus();
        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnNew.Visible = true;
        btnSave.Visible = true;
        hdn_Update_Consignee_Name.Value = "";
        ViewState["UPDATED_ID"] = null;
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            i = insert_update(HiddenField1.Value, "U", "");
            Session["CONSIGNEE_Master_Job_edit"] = HiddenField1.Value;

            if (i == 1)
            {
                hdn_Update_Consignee_Name.Value = txtName.Text;
                Load_Elogix_Service("U");
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
                Alert_msg("Consignor already exixts!", "btnUpdate");
            }
            else
            {
                Alert_msg("Consignee Not Saved", "btnUpdate");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            erm.Econsigneeid = HiddenField1.Value;
            erm.Econsignee_name = "0";
            erm.Ename = "delete";
            erm.EWorking_Period = Working_Period;

            erm.RetrieveAll_Consignee_MASTER();
            int i = erm.result;
            if (i > 0)
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('Consignee Deleted', 'CONSIGNEE MASTER', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            }
            else
            {
                Alert_msg("Consignee Not Deleted");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void txtName_TextChanged(object sender, EventArgs e)
    {
        if (hdn_Update_Consignee_Name.Value != txtName.Text)
        {
            try
            {
                erm.Econsigneeid = txtBranchSlNo.Text;
                erm.Econsignee_name = txtName.Text;
                erm.Ename = "Check_Consignee_Name";
                erm.EWorking_Period = Working_Period;

                dtuser = erm.RetrieveAll_Consignee_MASTER();
                if (dtuser.Tables[0].Rows.Count > 0)
                {
                    if (txtBranchSlNo.Text != "")
                    {
                        Alert_msg("Consignor Branch SlNo already exists!", "txtBranchSlNo");
                    }
                    else
                    {
                        Alert_msg("Consignor already exists!", "txtBranchSlNo");
                    }
                }
                else
                {
                    if (txtBranchSlNo.Text != "")
                    {
                        txtAdd1.Focus();
                    }
                    else
                    {
                        txtBranchSlNo.Focus();
                    }

                }
            }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
            }

        }
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'CONSIGNEE MASTER', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'CONSIGNEE MASTER', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    ///auto search
    [System.Web.Services.WebMethod]
    public static string GetCountry_code(string custid)
    {
        Auto_Search Auto = new Auto_Search();
        string name = "COUNTRY_MASTER_CODE";
        string rows = "COUNTRY_CODE";
        custid = Auto.Country_Master_FromClientSide_Calling(custid, name, rows);
        if (Auto.Ename != "1")
        {
            custid = "";
        }
        return custid;
    }
    ///auto search

    private void Load_Elogix_Service(string E_Flag)
    {
        try
        {
            string E_Logix_Company_Id_Chennai = Connection.e_lOGIX_CHENNAI();
            string E_Logix_Company_Id_Mumbai = Connection.e_lOGIX_MUMBAI();

            if (E_Logix_Company_Id_Chennai != string.Empty)
            {
                IMPL_CHENNAI.ELogiX obj = new IMPL_CHENNAI.ELogiX();
                obj.Consignee_Master(
                       txtName.Text
                    , txtAdd1.Text
                    , txtAdd2.Text
                    , txtAdd3.Text
                    , txtCountryCode.Text
                    , "C"
                    , Connection.Company_License()
                    , E_Flag
                    , Connection.Current_User());
            }
            else if (E_Logix_Company_Id_Mumbai != string.Empty)
            {
                IMPL_MUMBAI.ELOGIX_CS obj = new IMPL_MUMBAI.ELOGIX_CS();
                obj.Consignee_Master(txtName.Text, txtAdd1.Text, txtAdd2.Text, txtAdd3.Text, txtCountryCode.Text, "C", E_Logix_Company_Id_Mumbai, E_Flag, Connection.Current_User());
            }
            //-----------------------------------
            /* string E_Logix_Company_Id = Connection.E_Logix_Company_Id();
             if (E_Logix_Company_Id != string.Empty)
             {
                 IMPL.ELOGIX_CS obj = new IMPL.ELOGIX_CS();
                 obj.Consignee_Master(txtName.Text, txtAdd1.Text, txtAdd2.Text, txtAdd3.Text, txtCountryCode.Text, "C", E_Logix_Company_Id, E_Flag, Connection.Current_User());
             }
             */
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void Get_Consignee_ID_JobSearch()
    {
        if (String.IsNullOrEmpty(Session["CONS_NEW"] as string))
        {
            CONSIGNEE_ID = Request.QueryString["CONSIGNEE_ID"];
            erm.Econsigneeid = Request.QueryString["Slno"];
            erm.Econsignee_name = Request.QueryString["Name"];
            erm.Ename = "Get_Consignee_ID";
            erm.EWorking_Period = Working_Period;

            dtuser = erm.RetrieveAll_Consignee_MASTER();
            if (dtuser.Tables[0].Rows.Count > 0)
            {
                hdn_id.Value = dtuser.Tables[0].Rows[0]["CONSIGNEE_ID"].ToString();
                HiddenField1.Value = hdn_id.Value;
                Session["CONSIGNEE_Master_Job_edit"] = hdn_id.Value;
            }
        }
    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        DataSet dt_cons = new DataSet();
        //erm.Esupid = Request.QueryString["Slno"];
        erm.Econsigneeid = Session["CONSIGNEE_Master_Job_edit"].ToString();
        erm.Econsignee_name = Request.QueryString["Name"];
        erm.Ename = "select_conwithcode";
        erm.EWorking_Period = Working_Period;
        dt_cons = erm.RetrieveAll_Consignee_MASTER();

        if (dt_cons.Tables[0].Rows.Count > 0)
        {
            Session.Remove("CONS_NEW");
            string script =
                        "window.opener.document.getElementById('txtConsigneeName').value='" + dt_cons.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString() + "';" +
                        "window.opener.document.getElementById('txtConsigneeAddress').value='" + dt_cons.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString() + "';" +
                        "window.opener.document.getElementById('txtConsigneeAddress1').value='" + dt_cons.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString() + "';" +
                        "window.opener.document.getElementById('txtConsigneeAddress2').value='" + dt_cons.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString() + "';" +
                        "window.opener.document.getElementById('txtConsigneeAddress3').value='" + dt_cons.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString() + "';" +
                        "window.opener.document.getElementById('txtConsigneeAddress4').value='" + dt_cons.Tables[0].Rows[0]["CONSIGNEE_COUNTRY_NAME"].ToString() + "';" +
                        "window.opener.document.getElementById('txtConsignee_BranchSlNo').value='" + dt_cons.Tables[0].Rows[0]["CONSIGNEE_BRANCHSLNO"].ToString() + "';" +

                        "window.close();";

            ClientScript.RegisterStartupScript(this.GetType(), "SetValueAndClose", script, true);

        }

    }
}