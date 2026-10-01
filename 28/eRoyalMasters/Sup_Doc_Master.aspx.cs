using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.IO;
using System.Text;
using System.Data.SqlClient;

public partial class eRoyalMasters_Client_Master : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    AppSession aps = new AppSession();

    Supporting_Document SD = new Supporting_Document();
    Global_variables ObjUBO = new Global_variables();
    ErrorLogs er = new ErrorLogs();
    public int i = 0;

    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE;
    public int Screen_Id;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();

            hdn_COMAPNYID.Value = Connection.COMPANYID();
            if (!IsPostBack)
            {
                Icegate_Id();
                //----------------SETTING SCREEN PERMISSION---------------//
                Screen_Id = 1;
                Page_Rights(Screen_Id);
                //----------------SETTING SCREEN PERMISSION---------------//

                txt_Doc_Type_Code.Attributes.Add("onblur", "javascript:CallServerside_Doc_Type_Code('" + txt_Doc_Type_Code.ClientID + "', '" + txt_Doc_Type_Code.ClientID + "')");


                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnNew.Visible = true;
                btnSave.Visible = true;
                Edit_ClientDetails();
            }
            if (Rd_Imp_Exp.SelectedValue == "E")
            {

                Issu_ben_party.Text = "Beneficiary Party Details :-";

            }
            else
            {
                Issu_ben_party.Text = " Issuing Party Details :-";

            }


            if (Rd_Imp_Exp.SelectedValue == "E")
            {

                Ben_issu_party.Text = "Issuing Party Details :-";

            }
            else
            {
                Ben_issu_party.Text = " Beneficiary Party Details :-";

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
    public void Edit_ClientDetails()
    {
        try
        {
            if (Request.QueryString["ID"] != "" && Request.QueryString["ID"] != null && Request.QueryString["IMP_EXP"] != "" && Request.QueryString["IMP_EXP"] != null)
            {
                DataSet ds = new DataSet();
                ObjUBO.A1 = Request.QueryString["ID"].ToString();
                ObjUBO.A2 = Request.QueryString["IMP_EXP"].ToString();
                ObjUBO.A4 = "Sup_Doc_Updated_Data";
                ds = SD.Select_Sup(ObjUBO);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    HDupdate_id.Value = ds.Tables[0].Rows[0]["ID"].ToString();
                    Rd_Imp_Exp.SelectedValue = ds.Tables[0].Rows[0]["IMP_EXP"].ToString();
                    txt_Icegate_id.Text = ds.Tables[0].Rows[0]["ICEGATE_ID"].ToString();
                    ddl_Job_Type.SelectedValue = ds.Tables[0].Rows[0]["DOC_APPLICABLE_FOR"].ToString();
                    txt_Img_Ref_No.Text = ds.Tables[0].Rows[0]["IMAGE_REF_NO"].ToString();
                    txt_Doc_Upload_Date.Text = ds.Tables[0].Rows[0]["DOC_UPLOAD_DATE_TIME"].ToString();
                    // txt_Doc_Type_Code.Text = ds.Tables[0].Rows[0]["DOC_TYPE"].ToString();

                    if (ds.Tables[0].Rows[0]["DOC_TYPE"].ToString() != "")
                    {
                        DataSet dss = new DataSet();
                        adminmaster Am = new adminmaster();
                        Am.SCHEME_IMPORT_CODE = ds.Tables[0].Rows[0]["DOC_TYPE"].ToString();
                        Am.name = "Select_SUPPORTING_DOCS_NAME";
                        dss = Am.IMP_Single_Window();

                        if (dss.Tables[0].Rows.Count > 0)
                        {
                            txt_Doc_Type_Code.Text = dss.Tables[0].Rows[0]["DOC_NAME"].ToString();
                        }
                        else
                        {
                            txt_Doc_Type_Code.Text = string.Empty;
                        }
                    }
                    txt_File_Type.Text = ds.Tables[0].Rows[0]["FILE_TYPE"].ToString();
                    txt_Icegate_File_Name.Text = ds.Tables[0].Rows[0]["ICEGATE_FILE_NAME"].ToString();
                    txt_Issued_At.Text = ds.Tables[0].Rows[0]["ISSUED_AT"].ToString();
                    txt_Doc_Name.Text = ds.Tables[0].Rows[0]["DOC_NAME"].ToString();
                    txt_Issued_On.Text = ds.Tables[0].Rows[0]["ISSUED_ON"].ToString();
                    txt_Ref_No.Text = ds.Tables[0].Rows[0]["REFERENCE_NO"].ToString();
                    txt_Expiry_Date.Text = ds.Tables[0].Rows[0]["EXPIRY_DATE"].ToString();
                    txt_Iss_Name.Text = ds.Tables[0].Rows[0]["ISSUING_PARTY_NAME"].ToString();
                    txt_Iss_Code.Text = ds.Tables[0].Rows[0]["ISSUING_PARTY_CODE"].ToString();
                    txt_Iss_Add_1.Text = ds.Tables[0].Rows[0]["ISSUING_PARTY_ADD_1"].ToString();
                    txt_Iss_Add_2.Text = ds.Tables[0].Rows[0]["ISSUING_PARTY_ADD_2"].ToString();
                    txt_Iss_City.Text = ds.Tables[0].Rows[0]["ISSUING_PARTY_CITY"].ToString();
                    txt_Iss_Pin_Code.Text = ds.Tables[0].Rows[0]["ISSUING_PARTY_PIN_CODE"].ToString();
                    txt_Ben_Name.Text = ds.Tables[0].Rows[0]["BENEFICIARY_PARTY_NAME"].ToString();
                    txt_Ben_Code.Text = ds.Tables[0].Rows[0]["BENEFICIARY_PARTY_CODE"].ToString();
                    txt_Ben_Add_1.Text = ds.Tables[0].Rows[0]["BENEFICIARY_PARTY_ADD_1"].ToString();
                    txt_Ben_Add_2.Text = ds.Tables[0].Rows[0]["BENEFICIARY_PARTY_ADD_2"].ToString();
                    txt_Ben_City.Text = ds.Tables[0].Rows[0]["BENEFICIARY_PARTY_CITY"].ToString();
                    txt_Ben_Pin_Code.Text = ds.Tables[0].Rows[0]["BENEFICIARY_PARTY_PIN_CODE"].ToString();
                    if (ds.Tables[0].Rows[0]["AUTO_SAVE"].ToString() == "T")
                    {
                        chk_autosave.Checked = true;
                    }
                    else
                    {
                        chk_autosave.Checked = false;
                    }
                    ddl_SelectType.SelectedValue = ds.Tables[0].Rows[0]["SELECT_LEVEL"].ToString();

                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;

                    btnSave.Visible = false;
                    ViewState["UPDATED_ID"] = null;
                    ViewState["UPDATED_ID"] = Request.QueryString["IMP_EXP"].ToString();
                }
            }
            else
            {
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                txt_File_Type.Text = "PDF";
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Rd_Imp_Exp.SelectedValue.ToString() != "")
            {
                i = Insert_Update("S");
                HDupdate_id.Value = Convert.ToString(SD.UPDATE_ID);
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
                    }
                    //-----------------------FOR USER RIGHTS--------------------------------//

                    ViewState["UPDATED_ID"] = null;
                    Alert_msg("Saved Successfully", "btnSave");
                }
                else if (i == 2)
                {
                    Alert_msg("already exists", "btnNew");
                }
            }
            else
            {
                Alert_msg("Select Import or Export !");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }

    }
    public int Insert_Update(string flag)
    {
        try
        {
            ObjUBO.A1 = HDupdate_id.Value.ToString();
            ObjUBO.A2 = Rd_Imp_Exp.SelectedValue.ToString();
            ObjUBO.A3 = txt_Icegate_id.Text;
            ObjUBO.A4 = ddl_Job_Type.SelectedValue.ToString();
            ObjUBO.A5 = txt_Img_Ref_No.Text;
            ObjUBO.A6 = txt_Doc_Upload_Date.Text;
            //ObjUBO.A7 = txt_Doc_Type_Code.Text;
            if (txt_Doc_Type_Code.Text.Contains("_"))
            {
                string[] doc_typeCode = txt_Doc_Type_Code.Text.Split('_');
                ObjUBO.A7 = doc_typeCode[1].Trim();
            }
            ObjUBO.A8 = txt_File_Type.Text;
            ObjUBO.A9 = txt_Icegate_File_Name.Text;
            ObjUBO.A10 = txt_Issued_At.Text;
            ObjUBO.A11 = txt_Doc_Name.Text;
            ObjUBO.A12 = txt_Issued_On.Text == null ? string.Empty : txt_Issued_On.Text;
            ObjUBO.A13 = txt_Ref_No.Text;
            ObjUBO.A14 = txt_Expiry_Date.Text == null ? string.Empty : txt_Expiry_Date.Text;
            ObjUBO.A15 = txt_Iss_Name.Text;
            ObjUBO.A16 = txt_Iss_Code.Text;
            ObjUBO.A17 = txt_Iss_Add_1.Text;
            ObjUBO.A18 = txt_Iss_Add_2.Text;
            ObjUBO.A19 = txt_Iss_City.Text;
            ObjUBO.A20 = txt_Iss_Pin_Code.Text;
            ObjUBO.A21 = txt_Ben_Name.Text;
            ObjUBO.A22 = txt_Ben_Code.Text;
            ObjUBO.A23 = txt_Ben_Add_1.Text;
            ObjUBO.A24 = txt_Ben_Add_2.Text;
            ObjUBO.A25 = txt_Ben_City.Text;
            ObjUBO.A26 = txt_Ben_Pin_Code.Text;
            ObjUBO.A27 = flag;
            ObjUBO.A28 = chk_autosave.Checked == true ? "T" : "F";
            ObjUBO.A29 = ddl_SelectType.SelectedValue;

            SD.Sup_Doc_Ins_Upd(ObjUBO);
            i = SD.result;
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
            i = Insert_Update("D");
            if (i == 1)
            {
                Alert_msg("Deleted Successfully.", "btnDelete");
            }
            else
            {
                Alert_msg("Client Not Deleted", "btnDelete");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            i = Insert_Update("U");
            if (i == 1)
            {
                if (ViewState["UPDATED_ID"] != null)
                {
                    Alert_msg("Updated Successfully", "btnNew");
                }
                else
                {
                    Alert_msg("Saved Successfully", "btnNew");
                }
            }
            else if (i == 2)
            {
                Alert_msg("Party Already Exists!", "btnNew");
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
    }


    private void Icegate_Id()
    {
        try
        {
            string C_ID = Connection.COMPANYID();
            //Get_Icegate_Id

            ddl_Icegate_Id.Items.Clear();
            ddl_Icegate_Id.Items.Add(new ListItem("Other", ""));

            if (C_ID == "10")
            {
                ddl_Icegate_Id.Items.Add(new ListItem("Test1", "123"));
                ddl_Icegate_Id.Items.Add(new ListItem("Test2", "456"));
                ddl_Icegate_Id.Items.Add(new ListItem("Test3", "789"));
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
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnNew.Visible = true;
            btnSave.Visible = true;
            ViewState["UPDATED_ID"] = null;
            Clear();
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
            txt_Icegate_id.Text = string.Empty;
            //ddl_Job_Type.SelectedValue.ToString();
            txt_Img_Ref_No.Text = string.Empty;
            txt_Doc_Upload_Date.Text = string.Empty;
            txt_Doc_Type_Code.Text = string.Empty;
            txt_File_Type.Text = "PDF";
            txt_Icegate_File_Name.Text = string.Empty;
            txt_Issued_At.Text = string.Empty;
            txt_Doc_Name.Text = string.Empty;
            txt_Issued_On.Text = string.Empty;
            txt_Ref_No.Text = string.Empty;
            txt_Expiry_Date.Text = string.Empty;
            txt_Iss_Name.Text = string.Empty;
            txt_Iss_Code.Text = string.Empty;
            txt_Iss_Add_1.Text = string.Empty;
            txt_Iss_Add_2.Text = string.Empty;
            txt_Iss_City.Text = string.Empty;
            txt_Iss_Pin_Code.Text = string.Empty;
            txt_Ben_Name.Text = string.Empty;
            txt_Ben_Code.Text = string.Empty;
            txt_Ben_Add_1.Text = string.Empty;
            txt_Ben_Add_2.Text = string.Empty;
            txt_Ben_City.Text = string.Empty;
            txt_Ben_Pin_Code.Text = string.Empty;
            chk_autosave.Checked = false;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
        
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Supporting Doucument Master', function (r) {}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Supporting Doucument Master', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void ddl_Icegate_Id_SelectedIndexChanged(object sender, EventArgs e)
    {
        txt_Icegate_id.Text = ddl_Icegate_Id.SelectedValue.ToString();
    }
    protected void Rd_Imp_Exp_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (Rd_Imp_Exp.SelectedValue == "E")
            {

                Issu_ben_party.Text = "Beneficiary Party Details :-";

            }
            else
            {
                Issu_ben_party.Text = " Issuing Party Details :-";

            }

            if (Rd_Imp_Exp.SelectedValue == "E")
            {

                Ben_issu_party.Text = "Issuing Party Details :-";

            }
            else
            {
                Ben_issu_party.Text = " Beneficiary Party Details :-";

            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }

    }

    [System.Web.Services.WebMethod]
    public static string Doc_Type_Code(string custid)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            adminmaster ADM = new adminmaster();

            ADM.SCHEME_NOTN = custid;
            ADM.SCHEME_IMPORT_CODE = custid;
            ADM.name = "Select_SUPPORTING_DOCS_NAME_Check";
            ds = ADM.IMP_Single_Window();

            if (ds.Tables[0].Rows.Count > 0)
            {
                custid = "True" + "~~" + ds.Tables[0].Rows[0]["DOC_LEVEL"].ToString();
            }
            else
            {
                custid = "False";
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return custid;
    }
}