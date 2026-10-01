using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class IMP_PDF_CLIENT_MASTER : System.Web.UI.Page
{
    User_Creation user_Create = new User_Creation();
    eroyalmaster erm = new eroyalmaster();
    Manipulation mo = new Manipulation();
    AppSession aps = new AppSession();

    DataSet dtuser = new DataSet();
    ErrorLogs er = new ErrorLogs();
    public int i, Screen_Id;
    public string IMP_CLIENT_ID = "", Working_Period;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id, COMPANY_ID;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();
            COMPANY_ID = Connection.Company_License();
            Working_Period = Session["WorkingPeriod"].ToString();
            txtIec_Name.Focus();

            if (!IsPostBack)
            {
                //----------------SETTING SCREEN PERMISSION---------------//
                Screen_Id = 5;
                Page_Rights(Screen_Id);
                //----------------SETTING SCREEN PERMISSION---------------//
                EditSupDetails();
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
                btnSave.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnNew.Enabled = false;
                btnNew.ToolTip = "You don't have permission to access";
                btnSave.ToolTip = "true";
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
                    btnSave.Enabled = true;
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
            if (Request.QueryString["IMP_CLIENT_ID"] != "" && Request.QueryString["IMP_CLIENT_ID"] != null)
            {
                int i = 0;
                IMP_CLIENT_ID = Request.QueryString["IMP_CLIENT_ID"];

                erm.IMP_CLIENT_ID = IMP_CLIENT_ID;
                erm.IMP_CLIENT_IEC_NAME = "0";
                erm.Ename = "imp_select_conwithcode";
                erm.EWorking_Period = Working_Period;

                dtuser = erm.RetrieveAll_IMP_Client_Master();
                if (dtuser.Tables[0].Rows.Count > 0)
                {

                    txtIec_Name.Text = dtuser.Tables[0].Rows[0]["IMP_CLIENT_IEC_NAME"].ToString();
                    txt_BranchSlNo.Text = dtuser.Tables[0].Rows[0]["IMP_CLIENT_BRANCH_SLNO"].ToString();
                    txtIec_Code.Text = dtuser.Tables[0].Rows[0]["IMP_CLIENT_IEC_CODE"].ToString();
                    txtPdf_ClientName.Text = dtuser.Tables[0].Rows[0]["IMP_PDF_CLIENT_NAME"].ToString();
                    txtRemarks.Text = dtuser.Tables[0].Rows[0]["IMP_CLIENT_REMARKS"].ToString();
                    Company_ID.Text = COMPANY_ID;
                    hdn_Update_Iec_Name.Value = txtIec_Name.Text;
                    //FOR UPDATED SUCCESSFULLY
                    ViewState["UPDATED_ID"] = null;
                    ViewState["UPDATED_ID"] = Request.QueryString["IMP_CLIENT_ID"].ToString();
                    //FOR UPDATED SUCCESSFULLY
                }
                HiddenField1.Value = Request.QueryString["IMP_CLIENT_ID"].ToString();


                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = false;
            }
            else
            {
                Company_ID.Text = COMPANY_ID;
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnNew.Visible = false;
                btnSave.Visible = true;
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
            erm.IMP_CLIENT_ID = a1;
            erm.IMP_CLIENT_IEC_NAME = txtIec_Name.Text;
            erm.IMP_CLIENT_BRANCH_SLNO = txt_BranchSlNo.Text;
            erm.IMP_CLIENT_IEC_CODE = txtIec_Code.Text;
            erm.IMP_CLIENT_REMARKS = txtRemarks.Text;
            //erm.BUYER_COUNTRY_CODE = txtCountryCode.Text;
            erm.IMP_PDF_CLIENT_NAME = txtPdf_ClientName.Text.Trim();
            erm.IMP_PDF_COMPANY_ID = COMPANY_ID;

            erm.USER_ID = Connection.Current_User();
            erm.BRANCH_CODE = Connection.Current_Branch();
            erm.flag = a2;
            erm.YEAR = a3;
            erm.EWorking_Period = Working_Period;

            i = erm.IMP_CLIENT_MASTER_Insert_update();
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
        try
        {
            if (txtIec_Name.Text.Trim() == "" || txt_BranchSlNo.Text.Trim() == "")
            {
                Alert_msg("Enter All Mandatory Field", "btnNew");
                return;
            }

            try
            {
                string originalBranchInput = txt_BranchSlNo.Text.Trim();

                string[] branches = originalBranchInput.Split('~');

                int successCount = 0;
                int alreadyExistCount = 0;
                int failCount = 0;

                foreach (string b in branches)
                {
                    string branchNo = b.Trim();

                    if (string.IsNullOrEmpty(branchNo))
                        continue;
                    txt_BranchSlNo.Text = branchNo;

                    i = insert_update("", "IMP S", "");
                    HiddenField1.Value = Convert.ToString(erm.UPDATE_ID);

                    if (i == 1)
                    {
                        successCount++;
                    }
                    else if (i == 2)
                    {
                        alreadyExistCount++;
                    }
                    else
                    {
                        failCount++;
                    }
                }

                txt_BranchSlNo.Text = originalBranchInput;

                // if at least one branch saved
                if (successCount > 0)
                {
                    //-----------------------FOR USER RIGHTS--------------------------------//
                    user_Create.RetrieveAll_User_Screen_Rights_Details(Screen_Id);
                    PAGE_MODIFY = user_Create.PAGE_MODIFY;

                    Load_Elogix_Service("S");

                    if (PAGE_MODIFY == "False")
                    {
                        btnNew_Click(sender, e);
                    }
                    else
                    {
                        btnUpdate.Visible = true;
                        btnSave.Visible = false;
                        btnDelete.Visible = true;
                        btnNew.Visible = true;
                        hdn_Update_Iec_Name.Value = txtIec_Name.Text;
                    }
                    //-----------------------FOR USER RIGHTS--------------------------------//

                    ViewState["UPDATED_ID"] = null;

                    if (alreadyExistCount > 0)
                    {
                        Alert_msg("Saved Successfully. Some Branch Already Exists!", "btnSave");
                    }
                    else
                    {
                        Alert_msg("Saved Successfully", "btnSave");
                    }
                }
                else if (alreadyExistCount > 0)
                {
                    Alert_msg("Client Name or Branch or PDF client Already Exists!", "btnSave");
                }
                else
                {
                    Alert_msg("IMP Client Not Saved", "btnSave");
                }
            }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
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
            Session["SUP_ID"] = "";
            mo.ResetFields(Page.Controls);
            txtIec_Name.Focus();
            Company_ID.Text = COMPANY_ID;
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnNew.Visible = true;
            btnSave.Visible = true;
            hdn_Update_Iec_Name.Value = "";
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
            i = insert_update(HiddenField1.Value, "IMP U", "");
            if (i == 1)
            {
                hdn_Update_Iec_Name.Value = txtIec_Name.Text;
                Load_Elogix_Service("U");
                if (ViewState["UPDATED_ID"] != null)
                {
                    Alert_msg("Updated Successfully", "btnUpdate");
                    btnNew.Visible = true;
                }
                else
                {
                    Alert_msg("Saved Successfully", "btnUpdate");
                    btnNew.Visible = true;
                }

            }
            else if (i == 2)
            {
                Alert_msg("Client Name and Branch Already Exixts!", "btnUpdate");
            }
            else
            {
                Alert_msg("IMP Client Not Saved", "btnUpdate");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            //erm.EExp_cli_mas_id = HiddenField1.Value;
            //erm.EExp_client_iec_name = "0";
            //erm.Ename = "delete";
            //erm.EWorking_Period = Working_Period;

            i = insert_update(HiddenField1.Value, "delete", "");
            //erm.RetrieveAll_IMP_Client_Master();
            //int i = erm.result;
            if (i > 0)
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('IMP CLIENT Deleted', 'IMP CLIENT MASTER', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            }
            else
            {
                Alert_msg("IMP Client Not Deleted");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
    }

    protected void txtIec_Name_TextChanged(object sender, EventArgs e)
    {
        if (hdn_Update_Iec_Name.Value != txtIec_Name.Text)
        {
            try
            {
                erm.IMP_CLIENT_ID = "0";
                erm.IMP_CLIENT_IEC_NAME = txtIec_Name.Text;
                erm.IMP_CLIENT_BRANCH_SLNO = txt_BranchSlNo.Text;
                erm.Ename = "Check_IMP_CLIENT_IEC_NAME";
                erm.EWorking_Period = Working_Period;


                dtuser = erm.RetrieveAll_IMP_Client_Master();
                if (dtuser.Tables[0].Rows.Count > 0)
                {
                    Alert_msg("Client Name and Branch Already Exists!", "txt_BranchSlNo");
                }
            }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
            }

        }
        txt_BranchSlNo.Focus();
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'IMP CLIENT MASTER', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'IMP CLIENT MASTER', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
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
                      txtIec_Name.Text
                     , txt_BranchSlNo.Text
                    , txtIec_Code.Text
                    , txtRemarks.Text
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
                obj.Consignee_Master(txtIec_Name.Text, txt_BranchSlNo.Text, txtIec_Code.Text, txtRemarks.Text, txtCountryCode.Text, "B", E_Logix_Company_Id_Mumbai, E_Flag, Connection.Current_User());
            }
            /*
            string E_Logix_Company_Id = Connection.E_Logix_Company_Id();
            if (E_Logix_Company_Id != string.Empty)
            {
                IMPL.ELOGIX_CS obj = new IMPL.ELOGIX_CS();
                obj.Consignee_Master(txtIec_Name.Text, txtAdd1.Text, txtAdd2.Text, txtAdd3.Text, txtCountryCode.Text, "B", E_Logix_Company_Id, E_Flag, Connection.Current_User());
            }
             */
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
}