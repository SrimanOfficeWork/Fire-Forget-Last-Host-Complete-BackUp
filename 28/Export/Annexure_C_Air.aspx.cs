using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Export_Annexure_C_Air : ThemeClass
{
    DataSet dtuser = new DataSet();
    AppSession aps = new AppSession();
    Annexure_C_Air ANNEX_C_Air = new Annexure_C_Air();
    ErrorLogs er = new ErrorLogs();
    
    public int i;

    public string currentuser,SELECT_BRANCH ,EXPORT_JOBNO,Nature_Cargo;
   
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public int Screen_Id;
    public string JOB_LOCK, JOB_RELEASE;
    User_Creation user_Create = new User_Creation();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();

            currentuser = Connection.Current_User();
            SELECT_BRANCH = Connection.Get_Company_Type();

            txtSealNo.Focus();
            if (Session["EXPORT_JOBNO"] != null)
            {
                EXPORT_JOBNO = Session["EXPORT_JOBNO"].ToString();

                if (!IsPostBack)
                {
                    //----------------SETTING SCREEN PERMISSION---------------//
                    Screen_Id = 12;
                    Page_Rights(Screen_Id);
                    //----------------SETTING SCREEN PERMISSION---------------//

                    Edit_Annexure_C_Air_Details();
                }
            }
            else
            {
                Response.Write("<script>window.open('General.aspx','_parent');</script>");
            }
            ddlNatureOfCargo.Items.Clear();
            ddlNatureOfCargo.Items.Add("P Packaged");


            if (Session["JOB_LOCK"] != null && Session["JOB_LOCK"] != "")
            {
                JOB_LOCK = Session["JOB_LOCK"].ToString();

                if (Convert.ToInt32(JOB_LOCK) == 1)
                {
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    btnNew.Enabled = false;
                    btnSave.Enabled = false;

                    btnNew.ToolTip = "This Job is Locked by Admin";
                    btnSave.ToolTip = "This Job is Locked by Admin";
                    btnUpdate.ToolTip = "This Job is Locked by Admin";
                    btnDelete.ToolTip = "This Job is Locked by Admin";
                }
            }

            if (Session["USER_JOB_LOCK"].ToString() == "Yes")
            {
                if (currentuser.ToUpper() != Session["JOB_USER"].ToString().ToUpper())
                {
                    if (Session["JOB_RELEASE"] != null && Session["JOB_RELEASE"] != "")
                    {
                        JOB_RELEASE = Session["JOB_RELEASE"].ToString();

                        if (JOB_RELEASE == "No")
                        {

                            btnUpdate.Enabled = false;
                            btnDelete.Enabled = false;
                            btnNew.Enabled = false;
                            btnSave.Enabled = false;

                            MP_U.Show();

                            lblUser_Msg.Text = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";

                            btnUpdate.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btnDelete.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btnNew.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btnSave.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";

                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
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
        }
      
    }

    public void Edit_Annexure_C_Air_Details()
    {
        try
        {
            if (Session["EXPORT_JOBNO"] != null)
            {
                BindValue();

                if (ANNEX_C_Air.result == 1)
                {
                    txtMarks_Numbers.Text = dtuser.Tables[0].Rows[0]["MARKS_NO"].ToString();

                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnSave.Visible = true;
                    btnNew.Visible = true;
                }
                else
                {
                    if (dtuser.Tables[0].Rows.Count > 0)
                    {
                        txtSealNo.Text = dtuser.Tables[0].Rows[0]["ANNEX_AIR_SEALNO"].ToString();
                        txtSealAgency.Text = dtuser.Tables[0].Rows[0]["ANNEX_AIR_SEAL_AGENCY"].ToString();
                        Nature_Cargo = dtuser.Tables[0].Rows[0]["ANNEX_AIR_NATURE_OF_CARGO"].ToString();
                        if (Nature_Cargo == "P")
                        {
                            ddlNatureOfCargo.Items.Add("P Packaged");
                        }

                        txtMarks_Numbers.Text = dtuser.Tables[0].Rows[0]["ANNEX_AIR_MARKS_NOS"].ToString();
                        txtTotal_No_Packages.Text = dtuser.Tables[0].Rows[0]["ANNEX_AIR_TOTAL_PACKAGES"].ToString();
                        txtUnit_Code.Text = dtuser.Tables[0].Rows[0]["ANNEX_AIR_UNIT_CODE"].ToString();
                        txtFreight_Amount.Text = dtuser.Tables[0].Rows[0]["ANNEX_AIR_FREIGHT_AMT"].ToString();
                        txtInsurance_Amount.Text = dtuser.Tables[0].Rows[0]["ANNEX_AIR_INSURANCE_AMT"].ToString();
                        txtGross_Weight.Text = dtuser.Tables[0].Rows[0]["ANNEX_AIR_GROSS_WEIGHT"].ToString();

                        txtUnitCode.Text = dtuser.Tables[0].Rows[0]["ANNEX_AIR_GR_UNIT_CODE"].ToString();

                        txtNet_Weight.Text = dtuser.Tables[0].Rows[0]["ANNEX_AIR_NET_WEIGHT"].ToString();

                        txtMawb_No.Text = dtuser.Tables[0].Rows[0]["ANNEX_AIR_MAWB_NO"].ToString();

                        txtHawb_No.Text = dtuser.Tables[0].Rows[0]["ANNEX_AIR_HAWB_NO"].ToString();
                        txtPackages_Against_MAWB.Text = dtuser.Tables[0].Rows[0]["ANNEX_AIR_TOTAL_PACKAGES_MAWB"].ToString();
                        txtRotationNo.Text = dtuser.Tables[0].Rows[0]["ANNEX_AIR_ROTATION_NO"].ToString();
                        txtRotationDate.Text = dtuser.Tables[0].Rows[0]["ANNEX_AIR_ROTATION_DATE"].ToString().Replace("01/01/1900", "");
                        txtFOBValue.Text = dtuser.Tables[0].Rows[0]["ANNEX_AIR_FOB_VALUE"].ToString();

                        txtMawb_Date.Text = dtuser.Tables[0].Rows[0]["ANNEX_AIR_MAWB_DATE"].ToString();
                        txtHawb_Date.Text = dtuser.Tables[0].Rows[0]["ANNEX_AIR_HAWB_DATE"].ToString();

                        btnUpdate.Visible = true;
                        btnDelete.Visible = true;
                        btnSave.Visible = false;
                        btnNew.Visible = false;

                        if (txtTotal_No_Packages.Text != "")
                        {
                            Package_Id.Style.Add("display", "Block");
                        }
                    }

                    else
                        Button_Visible();
                }
            }
            else
                Button_Visible();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        
       
    }

    public void Button_Visible()
    {
        try
        {
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
            btnNew.Visible = true;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        
    }

    public DataSet BindValue()
    {
        try
        {
            ANNEX_C_Air.ANNEX_AIR_ID = "";
            ANNEX_C_Air.ANNEX_AIR_JOBNO = EXPORT_JOBNO;

            ANNEX_C_Air.Ename = "select";
            ANNEX_C_Air.WORKING_PERIOD = SELECT_BRANCH;
            dtuser = ANNEX_C_Air.RetrieveAll_Annexure_C_Air_Details();

            int result = ANNEX_C_Air.result;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

      
        return dtuser;

    }

    public int Export_Annexure_C_Air_Insert_Update(string Flag)
    {
        try
        {
            //Export.JOBID = jobid;
            ANNEX_C_Air.ANNEX_AIR_JOBNO = EXPORT_JOBNO;
            ANNEX_C_Air.ANNEX_AIR_SEALNO = txtSealNo.Text;
            ANNEX_C_Air.ANNEX_AIR_SEAL_AGENCY = txtSealAgency.Text;

            if (ddlNatureOfCargo.SelectedValue == "P Packaged")
            {
                Nature_Cargo = "P";
            }

            ANNEX_C_Air.ANNEX_AIR_NATURE_OF_CARGO = Nature_Cargo;
            ANNEX_C_Air.ANNEX_AIR_MARKS_NOS = txtMarks_Numbers.Text;
            ANNEX_C_Air.ANNEX_AIR_TOTAL_PACKAGES = txtTotal_No_Packages.Text;
            ANNEX_C_Air.ANNEX_AIR_UNIT_CODE = txtUnit_Code.Text;
            ANNEX_C_Air.ANNEX_AIR_FREIGHT_AMT = txtFreight_Amount.Text;
            ANNEX_C_Air.ANNEX_AIR_INSURANCE_AMT = txtInsurance_Amount.Text;
            ANNEX_C_Air.ANNEX_AIR_GROSS_WEIGHT = txtGross_Weight.Text;
            ANNEX_C_Air.ANNEX_AIR_GR_UNIT_CODE = txtUnitCode.Text;
            ANNEX_C_Air.ANNEX_AIR_NET_WEIGHT = txtNet_Weight.Text;
            ANNEX_C_Air.ANNEX_AIR_MAWB_NO = txtMawb_No.Text;
            ANNEX_C_Air.ANNEX_AIR_HAWB_NO = txtHawb_No.Text;
            ANNEX_C_Air.ANNEX_AIR_TOTAL_PACKAGES_MAWB = txtPackages_Against_MAWB.Text;
            ANNEX_C_Air.ANNEX_AIR_ROTATION_NO = txtRotationNo.Text;
            string dt = "";
            if (txtRotationDate.Text != "")
            {
                dt = txtRotationDate.Text;
            }
            else
            {
                dt = "01/01/1900";

            }
            ANNEX_C_Air.ANNEX_AIR_ROTATION_DATE = dt;
            ANNEX_C_Air.ANNEX_AIR_FOB_VALUE = txtFOBValue.Text;
            ANNEX_C_Air.ANNEX_AIR_MAWB_DATE = txtMawb_Date.Text;
            ANNEX_C_Air.ANNEX_AIR_HAWB_DATE = txtHawb_Date.Text;


            ANNEX_C_Air.USER_ID = currentuser;
            ANNEX_C_Air.flag = Flag;
            ANNEX_C_Air.BRANCH_CODE = Connection.Current_Branch();
            ANNEX_C_Air.WORKING_PERIOD = Connection.WorkingPeriod();
            ANNEX_C_Air.BRANCH_COMMON = SELECT_BRANCH;
            ANNEX_C_Air.JOBNO_PS = Session["JOBNO_PS"].ToString();


            i = ANNEX_C_Air.Annexure_C_Air_details_insertupdate();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        
        return i;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        try
        {
            string F = "S";
            i = Export_Annexure_C_Air_Insert_Update(F);
             if (i == 1)
                {

                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnSave.Visible = false;
                    btnNew.Visible = false;
                    txtSealNo.Focus();
                    Package_Id.Style.Add("display", "Block");
                    Alert_msg("Annexure_C_Air Saved Successfully", "btnSave");

                    string E_Logix_Company_Id = Connection.E_Logix_Company_Id();
                    if (E_Logix_Company_Id != string.Empty)
                    {
                        E_LOGIX ES = new E_LOGIX();
                        UserBO ObjUBO = new UserBO();
                        ObjUBO.JOBNO = EXPORT_JOBNO;
                        ObjUBO.File_Type = "E";
                        ObjUBO.Ename = "U";
                        ObjUBO.flag = "Update_Elogix_Data";
                        ES.Select_IMP_EXP(ObjUBO);
                    }

                }
                else if (i == 2)
                {
                    Alert_msg("Job No Already Exist!", "btnSave");
                }
           
            else
            {
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnSave.Visible = true;
                btnNew.Visible = true;
                Alert_msg("Annexure_C_Air Not Saved", "btnSave");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string F = "U";
            i = Export_Annexure_C_Air_Insert_Update(F);
            if (i == 1)
            {
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = false;
                txtSealNo.Focus();
                Package_Id.Style.Add("display", "Block");
                Alert_msg("Annexure_C_Air Updated Successfully", "btnUpdate");

                Elogix_Service();
            }
            else if (i == 2)
            {
                Alert_msg("Job No Already Exist!", "btnUpdate");

            }
            else
            {
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = false;
                Alert_msg("Annexure_C_Air Not Saved", "btnUpdate");
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
            //string ID = "";
            ANNEX_C_Air.ANNEX_AIR_ID = "";
            ANNEX_C_Air.ANNEX_AIR_JOBNO = EXPORT_JOBNO;

            ANNEX_C_Air.Ename = "delete";
            ANNEX_C_Air.WORKING_PERIOD = SELECT_BRANCH;
            dtuser = ANNEX_C_Air.RetrieveAll_Annexure_C_Air_Details();
            i = ANNEX_C_Air.result;

            if (i == 1)
            {
                btnNew_Click(sender, e);
                Alert_msg("Annexure_C_Air Deleted");
                Elogix_Service();
            }
            else
            {
                Alert_msg("Annexure_C_Air Not Deleted");

            }


        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            Transaction trans = new Transaction();
            trans.ResetFields(Page.Controls);
            txtSealNo.Focus();
            Button_Visible();
            ddlNatureOfCargo.Items.Clear();
            ddlNatureOfCargo.Items.Add("P Packaged");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
       

    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'ANNEXURE_C_AIR', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'ANNEXURE_C_AIR', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    private void Elogix_Service()
    {
        try
        {
            E_LOGIX ES = new E_LOGIX();
            ES.E_logic_Update(Session["EXPORT_JOBNO"].ToString(), "E", "U");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
     
    }
}