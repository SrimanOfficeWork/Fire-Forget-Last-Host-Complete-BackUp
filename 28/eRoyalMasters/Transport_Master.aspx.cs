using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using System.Data.SqlClient;

public partial class eRoyalMasters_Suppliermaster : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    eroyalmaster erm = new eroyalmaster();
    Manipulation mo = new Manipulation();
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    DataSet dtuser = new DataSet();
   
    
    public string TRANS_ID = "";

    public int i ,Screen_Id;
    public string Working_Period;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();
            Working_Period = Connection.WorkingPeriod();
            txt_transport_name.Focus();
            if (!IsPostBack)
            {
                Screen_Id = 2;
                Page_Rights(Screen_Id);
                Rd_Vachile_Type.Attributes.Add("onblur", "javascript:CallMe('" + Rd_Vachile_Type.ClientID + "', '" + Rd_Vachile_Type.ClientID + "')");
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
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
        
    }
    //public void EditSupDetails()
    //{
    //    if (Request.QueryString["TRANS_ID"] != "" && Request.QueryString["TRANS_ID"] != null)
    //    {
    //        int i = 0;
    //        TRANS_ID = Request.QueryString["TRANS_ID"];
    //        erm.Esupid = TRANS_ID;
    //        erm.Esup_name = "0";
    //        erm.Ename = "select_conwithcode";
    //        erm.EWorking_Period = Working_Period;
    //        dtuser = erm.RetrieveAll_Transport_MASTER();
    //        if (dtuser.Tables[0].Rows.Count > 0)
    //        {
    //            txt_transport_name.Text = dtuser.Tables[0].Rows[0]["Transport_Name"].ToString();
    //            txt_transport_Id.Text = dtuser.Tables[0].Rows[0]["Transport_Id"].ToString();
    //            Rd_Tr_Mode.Text = dtuser.Tables[0].Rows[0]["Mode"].ToString();
    //            txt_transport_doc_no.Text = dtuser.Tables[0].Rows[0]["Transport_Doc_No"].ToString();
    //            txt_Vechile_No.Text = dtuser.Tables[0].Rows[0]["Vechile_No"].ToString();
    //            Rd_Vechile_Type.Text = dtuser.Tables[0].Rows[0]["Vechile_Type"].ToString();
    //            txt_tr_Date.Text = dtuser.Tables[0].Rows[0]["Transport_Date"].ToString();
    //            txt_User_GSTN_Id.Text = dtuser.Tables[0].Rows[0]["User_GSTN_Id"].ToString();                
    //            hdn_Update_TransName.Value = txt_transport_name.Text;
    //        }
    //        HiddenField1.Value = Request.QueryString["TRANS_ID"].ToString();

    //        ViewState["UPDATED_ID"] = null;
    //        ViewState["UPDATED_ID"] = Request.QueryString["TRANS_ID"].ToString();

    //        btnDelete.Visible = true;
    //        btnUpdate.Visible = true;
    //        btnNew.Visible = true;
    //        btnSave.Visible = false;
    //    }
    //    else
    //    {
    //        btnDelete.Visible = false;
    //        btnUpdate.Visible = false;
    //        btnNew.Visible = true;
    //        btnSave.Visible = true;
    //    }
    //}
    public void EditSupDetails()
    {
        try
        {
            if (Request.QueryString["TRANS_ID"] != "" && Request.QueryString["TRANS_ID"] != null)
            {
                int i = 0;
                TRANS_ID = Request.QueryString["TRANS_ID"].ToString();

                erm.Etransid = TRANS_ID;
                erm.Etrans_name = "0";
                erm.Ename = "select_conwithcode";
                erm.EWorking_Period = Working_Period;

                dtuser = erm.RetrieveAll_Transport_MASTER();
                if (dtuser.Tables[0].Rows.Count > 0)
                {

                    txt_transport_name.Text = dtuser.Tables[0].Rows[0]["Transport_Name"].ToString();
                    txt_transport_Id.Text = dtuser.Tables[0].Rows[0]["Transport_Id"].ToString();
                    Rd_Tr_Mode.Text = dtuser.Tables[0].Rows[0]["Mode"].ToString();
                    txt_transport_doc_no.Text = dtuser.Tables[0].Rows[0]["Transport_Doc_No"].ToString();
                    txt_Vachile_No.Text = dtuser.Tables[0].Rows[0]["Vachile_No"].ToString();
                    Rd_Vachile_Type.Text = dtuser.Tables[0].Rows[0]["Vachile_Type"].ToString();
                    txt_tr_Date.Text = dtuser.Tables[0].Rows[0]["Transport_Date"].ToString();
                    txt_User_GSTN_Id.Text = dtuser.Tables[0].Rows[0]["User_GSTN_Id"].ToString();
                    hdn_Update_TransName.Value = txt_transport_name.Text;
                    //FOR UPDATED SUCCESSFULLY
                    ViewState["UPDATED_ID"] = null;
                    ViewState["UPDATED_ID"] = Request.QueryString["TRANS_ID"].ToString();
                    //FOR UPDATED SUCCESSFULLY
                }
                HiddenField1.Value = Request.QueryString["TRANS_ID"].ToString();

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
    public void Clear()
    {
        mo.ResetFields(Page.Controls);
    }

    public int insert_update(string a1, string a2, string a3)
    {
        try
        {
            erm.TRANS_ID = a1;
            erm.TRANSPORT_NAME = txt_transport_name.Text;
            erm.TRANSPORT_ID = txt_transport_Id.Text;
            erm.MODE = Rd_Tr_Mode.Text;
            erm.TRANSPORT_DOC_NO = txt_transport_doc_no.Text;
            erm.VACHILE_NO = txt_Vachile_No.Text;
            erm.TRANSPORT_DATE = txt_tr_Date.Text;
            erm.VACHILE_TYPE = Rd_Vachile_Type.Text;
            erm.USER_GSTN_ID = txt_User_GSTN_Id.Text;
            //erm.SUP_REMARKS = txtRemarks.Text;

            erm.USER_ID = Connection.Current_User();
            erm.BRANCH_CODE = Connection.Current_Branch();
            erm.flag = a2;
            erm.YEAR = a3;
            erm.EWorking_Period = Working_Period;

            i = erm.Transport_Master_Insert_update();
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
            if (txt_transport_name.Text != "" && Rd_Tr_Mode.Text != "")
            {
                try
                {
                    i = insert_update("", "S", "");
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
                            hdn_Update_TransName.Value = txt_transport_name.Text;
                        }
                        //-----------------------FOR USER RIGHTS--------------------------------//
                        Load_Elogix_Service("S");
                        ViewState["UPDATED_ID"] = null;
                        Alert_msg("Saved Successfully", "btnSave");

                    }
                    else if (i == 2)
                    {
                        Alert_msg("Transport already Saved!", "btnSave");
                    }
                    else
                    {
                        Alert_msg("Transport Not Saved", "btnNew");
                    }
                }
                catch (Exception ex)
                {
                    Connection.Error_Msg(ex.Message);
                }
            }
            else
            {
                Alert_msg("Enter All Mandatory Field");
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
            Session["TRANS_ID"] = "";
            mo.ResetFields(Page.Controls);
            txt_transport_name.Focus();
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnNew.Visible = true;
            btnSave.Visible = true;
            hdn_Update_TransName.Value = "";
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
            i = insert_update(HiddenField1.Value, "U", "");
            if (i == 1)
            {
                hdn_Update_TransName.Value = txt_transport_name.Text;
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
                Alert_msg("Transport already Saved!", "btnUpdate");
            }
            else
            {
                Alert_msg("Transport Not Saved", "btnUpdate");
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
            erm.Etransid = HiddenField1.Value;
            erm.Etrans_name = "0";
            erm.Ename = "delete";
            erm.EWorking_Period = Working_Period;
            erm.RetrieveAll_Transport_MASTER();
            int ii = 0;
            ii = erm.result;

            if (ii > 0)
            {
                ViewState["UPDATED_ID"] = null;
                string prompt = "<script>$(document).ready(function(){{jAlert('Transport Deleted', 'TRANSPORT MASTER', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            }
            else
            {
                Alert_msg("Transport Not Deleted");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
    }
    
         
    //protected void btnNew_Click(object sender, EventArgs e)
    //{
    //    Session["TRANS_ID"] = "";

    //    Clear();
    //    txt_transport_name.Focus();
    //    btnDelete.Visible = false;
    //    btnUpdate.Visible = false;
    //    btnNew.Visible = true;
    //    btnSave.Visible = true;
    //    txt_transport_name.Enabled = true;
    //    hdn_Update_TransName.Value = "";
    //    ViewState["UPDATED_ID"] = null;
       
    //}

    protected void txtName_TextChanged(object sender, EventArgs e)
    {
        if (hdn_Update_TransName.Value != txt_transport_name.Text)
        {
            try
        {
            erm.Etransid = "0";
            erm.Etrans_name = txt_transport_name.Text;

            erm.Ename = "Check_TRANSPORT_NAME";
            erm.EWorking_Period = Working_Period;

            dtuser = erm.RetrieveAll_Transport_MASTER();
            if (dtuser.Tables[0].Rows.Count > 0)
            {
                Alert_msg("Transport already exists!", "txt_transport_name");
            }
            else
            {

            }
        }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
            }
        }
        Rd_Tr_Mode.Focus();
       
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'TRANSPORT MASTER', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'TRANSPORT MASTER', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
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
            /*
            string E_Logix_Company_Id = Connection.E_Logix_Company_Id();
            if (E_Logix_Company_Id != string.Empty)
            {
                IMPL.ELOGIX_CS obj = new IMPL.ELOGIX_CS();
                obj.Consignee_Master(txtName.Text,txtAdd1.Text,txtAdd2.Text,txtAdd3.Text,txtCountryCode.Text,"S",E_Logix_Company_Id,E_Flag,Connection.Current_User());
            }
            */
            string E_Logix_Company_Id_Chennai = Connection.e_lOGIX_CHENNAI();
            string E_Logix_Company_Id_Mumbai = Connection.e_lOGIX_MUMBAI();

            if (E_Logix_Company_Id_Chennai != string.Empty)
            {
                //IMPL.ELOGIX_CS obj = new IMPL.ELOGIX_CS();

                IMPL_CHENNAI.ELogiX obj = new IMPL_CHENNAI.ELogiX();
                obj.Supplier_Master(
                    txt_transport_name.Text
                   , Rd_Tr_Mode.Text
                   , txt_transport_doc_no.Text
                   , txt_Vachile_No.Text
                   , txt_tr_Date.Text
                   ,"S"
                   ,Connection.Company_License()
                   , E_Flag
                   , Connection.Current_User()
                   );

            }
            else if (E_Logix_Company_Id_Mumbai != string.Empty)
            {
                IMPL_MUMBAI.ELOGIX_CS obj = new IMPL_MUMBAI.ELOGIX_CS();
                obj.Consignee_Master(txt_transport_name.Text, Rd_Tr_Mode.Text, txt_transport_doc_no.Text, txt_Vachile_No.Text, txt_tr_Date.Text, "S", E_Logix_Company_Id_Mumbai, E_Flag, Connection.Current_User());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
}