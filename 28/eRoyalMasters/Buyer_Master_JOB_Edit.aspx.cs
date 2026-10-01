using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class ListPopups_Buyer_Details_ListPopup_JOB : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    eroyalmaster erm = new eroyalmaster();
    Manipulation mo = new Manipulation();
    AppSession aps = new AppSession();
    DataSet dtuser = new DataSet();

    public int i, Screen_Id;
    public string BUYER_ID = "", Working_Period;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        Working_Period = Session["WorkingPeriod"].ToString();
        txtName.Focus();

        if (!String.IsNullOrEmpty(Request.QueryString["Name"] as string))
        {
            Get_Buyer_ID_JobSearch();
        }

        if (!IsPostBack)
        {
            //----------------SETTING SCREEN PERMISSION---------------//
            Screen_Id = 5;
            Page_Rights(Screen_Id);
            //----------------SETTING SCREEN PERMISSION---------------//
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
        //if (Request.QueryString["BUYER_ID"] != "" && Request.QueryString["BUYER_ID"] != null)
        if (hdn_id.Value != "")
        {
            int i = 0;
            erm.Ebuyerid = hdn_id.Value;
            erm.Ebuyer_name = "0";
            erm.Ename = "select_conwithcode";
            erm.EWorking_Period = Working_Period;

            dtuser = erm.RetrieveAll_Buyer_MASTER();
            if (dtuser.Tables[0].Rows.Count > 0)
            {

                txtName.Text = dtuser.Tables[0].Rows[0]["BUYER_NAME"].ToString();
                txtAdd1.Text = dtuser.Tables[0].Rows[0]["BUYER_ADD1"].ToString();
                txtAdd2.Text = dtuser.Tables[0].Rows[0]["BUYER_ADD2"].ToString();
                txtAdd3.Text = dtuser.Tables[0].Rows[0]["BUYER_ADD3"].ToString();
                txtCountryName.Text = dtuser.Tables[0].Rows[0]["BUYER_COUNTRY_NAME"].ToString();
                txtCountryCode.Text = dtuser.Tables[0].Rows[0]["BUYER_COUNTRY_CODE"].ToString();
                txtPincode.Text = dtuser.Tables[0].Rows[0]["BUYER_PIN_CODE"].ToString();
                txtRemarks.Text = dtuser.Tables[0].Rows[0]["BUYER_REMARKS"].ToString();
                hdn_Update_BUYER_Name.Value = txtName.Text;
                //FOR UPDATED SUCCESSFULLY
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = hdn_id.Value;
                //FOR UPDATED SUCCESSFULLY
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
        erm.BUYER_ID = a1;
        erm.BUYER_NAME = txtName.Text;
        erm.BUYER_ADD1 = txtAdd1.Text;
        erm.BUYER_ADD2 = txtAdd2.Text;
        erm.BUYER_ADD3 = txtAdd3.Text;
        erm.BUYER_COUNTRY_CODE = txtCountryCode.Text;
        erm.BUYER_COUNTRY_NAME = txtCountryName.Text;
        erm.BUYER_PIN_CODE = txtPincode.Text;
        erm.BUYER_REMARKS = txtRemarks.Text;

        erm.USER_ID = Connection.Current_User();
        erm.BRANCH_CODE = Connection.Current_Branch();
        erm.flag = a2;
        erm.YEAR = a3;
        erm.EWorking_Period = Working_Period;

        i = erm.Buyer_Master_Insert_update();
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
                Session["Buyer_Master_Job_edit"] = HiddenField1.Value;
                if (i == 1)
                {
                    //-----------------------FOR USER RIGHTS--------------------------------//
                    user_Create.RetrieveAll_User_Screen_Rights_Details(Screen_Id);
                    PAGE_MODIFY = user_Create.PAGE_MODIFY;
                    Load_Elogix_Service("S");
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
                    Alert_msg("Consignor already exixts!", "btnSave");
                }
                else
                {
                    Alert_msg("BUYER Not Saved", "btnNew");
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

    protected void btnNew_Click(object sender, EventArgs e)
    {
        Session["BUYER_NEW"] = "New";

        mo.ResetFields(Page.Controls);
        txtName.Focus();
        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnNew.Visible = true;
        btnSave.Visible = true;
        hdn_Update_BUYER_Name.Value = "";
        ViewState["UPDATED_ID"] = null;
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            i = insert_update(HiddenField1.Value, "U", "");
            Session["Buyer_Master_Job_edit"] = HiddenField1.Value;

            if (i == 1)
            {
                hdn_Update_BUYER_Name.Value = txtName.Text;
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
                Alert_msg("BUYER Not Saved", "btnUpdate");
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
            erm.Ebuyerid = HiddenField1.Value;
            erm.Ebuyer_name = "0";
            erm.Ename = "delete";
            erm.EWorking_Period = Working_Period;


            erm.RetrieveAll_Buyer_MASTER();
            int i = erm.result;
            if (i > 0)
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('BUYER Deleted', 'BUYER MASTER', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            }
            else
            {
                Alert_msg("BUYER Not Deleted");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
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
                erm.Ename = "Check_BUYER_Name";
                erm.EWorking_Period = Working_Period;
                dtuser = erm.RetrieveAll_Buyer_MASTER();
                if (dtuser.Tables[0].Rows.Count > 0)
                {
                    Alert_msg("Buyer already exists!", "txtAdd1");
                }
            }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
            }

        }
        txtAdd1.Focus();
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'BUYER MASTER', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'BUYER MASTER', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

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

    private void Load_Elogix_Service(string E_Flag)
    {
        try
        {
            string E_Logix_Company_Id_Chennai = Connection.e_lOGIX_CHENNAI();
            string E_Logix_Company_Id_Mumbai = Connection.e_lOGIX_MUMBAI();

            if (E_Logix_Company_Id_Chennai != string.Empty)
            {
                IMPL_CHENNAI.ELogiX obj = new IMPL_CHENNAI.ELogiX();
                obj.Buyer_Master(
                      txtName.Text
                     , txtAdd1.Text
                    , txtAdd2.Text
                    , txtAdd3.Text
                    , txtCountryCode.Text
                    , "B"
                    , Connection.Company_License()
                    , E_Flag
                    , Connection.Current_User()
                    );
            }
            else if (E_Logix_Company_Id_Mumbai != string.Empty)
            {
                IMPL_MUMBAI.ELOGIX_CS obj = new IMPL_MUMBAI.ELOGIX_CS();
                obj.Consignee_Master(txtName.Text, txtAdd1.Text, txtAdd2.Text, txtAdd3.Text, txtCountryCode.Text, "B", E_Logix_Company_Id_Mumbai, E_Flag, Connection.Current_User());
            }
            /*
            string E_Logix_Company_Id = Connection.E_Logix_Company_Id();
            if (E_Logix_Company_Id != string.Empty)
            {
                IMPL.ELOGIX_CS obj = new IMPL.ELOGIX_CS();
                obj.Consignee_Master(txtName.Text, txtAdd1.Text, txtAdd2.Text, txtAdd3.Text, txtCountryCode.Text, "B", E_Logix_Company_Id, E_Flag, Connection.Current_User());
            }
             */
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }


    private void Get_Buyer_ID_JobSearch()
    {
        if (String.IsNullOrEmpty(Session["BUYER_NEW"] as string))
        {
            erm.Ebuyerid = "0";
            erm.Ebuyer_name = Request.QueryString["Name"];
            erm.Ename = "Get_BUYER_ID";
            erm.EWorking_Period = Working_Period;
            dtuser = erm.RetrieveAll_Buyer_MASTER();

            if (dtuser.Tables[0].Rows.Count > 0)
            {
                hdn_id.Value = dtuser.Tables[0].Rows[0]["BUYER_ID"].ToString();
                HiddenField1.Value = hdn_id.Value;
                Session["Buyer_Master_Job_edit"] = hdn_id.Value;
            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        DataSet dt_sup = new DataSet();
        //erm.Esupid = Request.QueryString["Slno"];
        erm.Ebuyerid = Session["Buyer_Master_Job_edit"].ToString();
        erm.Ebuyer_name = Request.QueryString["Name"];
        erm.Ename = "select_conwithcode";
        erm.EWorking_Period = Working_Period;
        dt_sup = erm.RetrieveAll_Buyer_MASTER();

        if (dt_sup.Tables[0].Rows.Count > 0)
        {
            string Buyername = dt_sup.Tables[0].Rows[0]["BUYER_NAME"].ToString();
            string BuyerAdd1 = dt_sup.Tables[0].Rows[0]["BUYER_ADD1"].ToString();
            string BuyerAdd2 = dt_sup.Tables[0].Rows[0]["BUYER_ADD2"].ToString();
            string BuyerAdd3 = dt_sup.Tables[0].Rows[0]["BUYER_ADD3"].ToString();
            string BuyerCountry = dt_sup.Tables[0].Rows[0]["BUYER_COUNTRY_NAME"].ToString();
           

            //ClientScript.RegisterStartupScript(this.GetType(), "closeWindow", "window.close();", true); // Close Window Ref
            Session.Remove("BUYER_NEW");
            string script =
                        "window.opener.document.getElementById('txtBuyerName').value='" + Buyername + "';" +
                        "window.opener.document.getElementById('txtAddress').value='" + BuyerAdd1 + "';" +
                        "window.opener.document.getElementById('txtAddress1').value='" + BuyerAdd2 + "';" +
                        "window.opener.document.getElementById('txtAddress2').value='" + BuyerAdd3 + "';" +
                        "window.opener.document.getElementById('txtAddress3').value='" + BuyerCountry + "';" +
                        "window.close();";

            ClientScript.RegisterStartupScript(this.GetType(), "SetValueAndClose", script, true);

        }

    }
}