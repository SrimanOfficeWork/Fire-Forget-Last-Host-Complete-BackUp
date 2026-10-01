using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Export_Annexure_C_Sea : ThemeClass
{
    DataSet dtuser = new DataSet();
    User_Creation user_Create = new User_Creation();

    AppSession aps = new AppSession();
    Annexure_C_Sea ANNEX_C_Sea = new Annexure_C_Sea();
    ErrorLogs er = new ErrorLogs();

    public int i,Screen_Id;

    public string currentuser, SELECT_BRANCH, EXPORT_JOBNO, Nature_Cargo, ddlNature_Cargo;
    
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public string JOB_LOCK, JOB_RELEASE;


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();

            currentuser = Connection.Current_User();
            SELECT_BRANCH = Connection.Get_Company_Type();

            NatureCargo();
            if (Session["EXPORT_JOBNO"] != null)
            {
                EXPORT_JOBNO = Session["EXPORT_JOBNO"].ToString();

                if (!IsPostBack)
                {
                    //----------------SETTING SCREEN PERMISSION---------------//
                    Screen_Id = 12;
                    Page_Rights(Screen_Id);
                    //----------------SETTING SCREEN PERMISSION---------------//

                    if (Session["COMPANY_ID"].ToString() == "239" || Session["COMPANY_ID"].ToString() == "1136" || Session["COMPANY_ID"].ToString() == "4")
                    {
                        ddlSample_Accompanied.Items.Remove("N");
                        ddlSample_Accompanied.Items.Insert(0, "N");
                    }

                    if (Session["COMPANY_ID"].ToString() == "100" || Session["COMPANY_ID"].ToString() == "1103" || Session["COMPANY_ID"].ToString() == "1136" || Session["COMPANY_ID"].ToString() == "1159" || Session["COMPANY_ID"].ToString() == "1572" || Session["COMPANY_ID"].ToString() == "2020") 
                    {
                        ddlFactory_Stuffed.Items.Remove("N");
                        ddlFactory_Stuffed.Items.Insert(0, "N");
                        txtUnit_Of_Measurement.Text = "KGS";
                    }

                    if (Session["COMPANY_ID"].ToString() == "6002") // Added by shanthini id 6002 on 03-06-2026
                    {
                        txtUnit_Of_Measurement.Text = "KGS";
                    }

                    if (Session["COMPANY_ID"].ToString() == "6002")
                    {
                        txtUnit_Code.Text = "PLT";
                    }

                    if (Session["COMPANY_ID"].ToString() == "10" || Session["COMPANY_ID"].ToString() == "1572") 
                    {
                        ddlSeal_Type.Items.Remove("Warehouse");
                        ddlSeal_Type.Items.Insert(0, "Warehouse");
                    }

                    if (Session["COMPANY_ID"].ToString() == "6002") // Added by shanthini id 6002 on 03-06-2026
                    {
                        ddlSeal_Type.Items.Remove("Warehouse");
                        ddlSeal_Type.Items.Insert(0, "Warehouse");
                    }
              
                    else if (ddlFactory_Stuffed.SelectedItem.Text == "Y")
                    {
                        ddlSeal_Type.Items.Remove("Self");
                        ddlSeal_Type.Items.Insert(0, "Self");
                    }
                    else
                    {
                        ddlSeal_Type.Items.Remove("Warehouse");
                        ddlSeal_Type.Items.Insert(0, "Warehouse");
                    }

                    Edit_Annexure_C_Sea_Details();
                }
            }
            else
            {
                Response.Write("<script>window.open('General.aspx','_parent');</script>");
            }


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

    public void NatureCargo()
    {
        try
        {
            if (Session["COMPANY_ID"].ToString() == "2501" || Session["COMPANY_ID"].ToString() == "2526" || Session["COMPANY_ID"].ToString() == "2537") // Added condition by pandiyan
            {
                ddlNatureOfCargo.Items.Add("P Packaged");
                ddlNatureOfCargo.Items.Add("C Containerized");
                ddlNatureOfCargo.Items.Add("CP Containerized");
                ddlNatureOfCargo.Items.Add("LB Liquid and Bulk");
                ddlNatureOfCargo.Items.Add("DB Dry Bulk");
            }
            else
            {
                ddlNatureOfCargo.Items.Add("C Containerized");
                ddlNatureOfCargo.Items.Add("P Packaged");
                ddlNatureOfCargo.Items.Add("CP Containerized");
                ddlNatureOfCargo.Items.Add("LB Liquid and Bulk");
                ddlNatureOfCargo.Items.Add("DB Dry Bulk");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
       
    }

    public void Edit_Annexure_C_Sea_Details()
    {
        try
        {
            if (Session["EXPORT_JOBNO"] != null)
            {
                BindValue();

                if (ANNEX_C_Sea.result == 1)
                {
                    if (dtuser.Tables[0].Rows.Count > 0)
                    {
                        txtMarks_Numbers.Text = dtuser.Tables[0].Rows[0]["MARKS_NO"].ToString();

                        btnUpdate.Visible = false;
                        btnDelete.Visible = false;
                        btnSave.Visible = true;
                        btnNew.Visible = true;
                    }
                }
                else
                {
                    if (dtuser.Tables[0].Rows.Count > 0)
                    {
                        string Factory_Stuffed = dtuser.Tables[0].Rows[0]["ANNEX_SEA_FAC_STUFFED"].ToString();
                        string Sample_Accompanied = dtuser.Tables[0].Rows[0]["ANNEX_SEA_SAMPLE_ACCOM"].ToString();
                        string Seal_Type = dtuser.Tables[0].Rows[0]["ANNEX_SEA_SEAL_TYPE"].ToString();

                        ddlFactory_Stuffed.Items.Remove(Factory_Stuffed);
                        ddlFactory_Stuffed.Items.Insert(0, Factory_Stuffed);
                        ddlFactory_Stuffed.SelectedIndex = -1;

                        ddlSample_Accompanied.Items.Remove(Sample_Accompanied);
                        ddlSample_Accompanied.Items.Insert(0, Sample_Accompanied);
                        ddlSample_Accompanied.SelectedIndex = -1;

                        ddlSeal_Type.Items.Remove(Seal_Type);
                        ddlSeal_Type.Items.Insert(0, Seal_Type);
                        ddlSeal_Type.SelectedIndex = -1;

                        Nature_Cargo = dtuser.Tables[0].Rows[0]["ANNEX_SEA_NATURE_OF_CARGO"].ToString();

                        ddlNatureOfCargo.Items.Clear();

                        if (Nature_Cargo == "C")
                        {
                            ddlNature_Cargo = "C Containerized";
                        }
                        else if (Nature_Cargo == "P")
                        {
                            ddlNature_Cargo = "P Packaged";
                        }
                        else if (Nature_Cargo == "CP")
                        {
                            ddlNature_Cargo = "CP Containerized";
                        }
                        else if (Nature_Cargo == "LB")
                        {
                            ddlNature_Cargo = "LB Liquid and Bulk";
                        }
                        else if (Nature_Cargo == "DB")
                        {
                            ddlNature_Cargo = "DB Dry Bulk";
                        }

                        NatureCargo();
                        ddlNatureOfCargo.Items.Remove(ddlNature_Cargo);
                        ddlNatureOfCargo.Items.Insert(0, ddlNature_Cargo);

                        txtMarks_Numbers.Text = dtuser.Tables[0].Rows[0]["ANNEX_SEA_MARKS_NOS"].ToString();
                        txtTotal_No_Packages.Text = dtuser.Tables[0].Rows[0]["ANNEX_SEA_TOTAL_PACKAGES"].ToString();
                        if (txtTotal_No_Packages.Text != "")
                        {
                            Package_Id.Style.Add("display", "Block");
                        }
                        else
                        {
                            Package_Id.Style.Add("display", "none");
                        }
                        txtNo_Of_Loose_Packets.Text = dtuser.Tables[0].Rows[0]["ANNEX_SEA_LOOSE_PACKETS"].ToString();

                        txtNo_Of_Containers.Text = dtuser.Tables[0].Rows[0]["ANNEX_SEA_NO_CONTAINERS"].ToString();
                        if (txtNo_Of_Containers.Text != "" && txtNo_Of_Containers.Text != "0")
                        {
                            Container_Id.Style.Add("display", "Block");
                        }
                        else
                        {
                            Container_Id.Style.Add("display", "none");
                        }
                        txtGross_Weight.Text = dtuser.Tables[0].Rows[0]["ANNEX_SEA_GROSS_WEIGHT"].ToString();
                        txtNet_Weight.Text = dtuser.Tables[0].Rows[0]["ANNEX_SEA_NET_WEIGHT"].ToString();

                        txtUnit_Of_Measurement.Text = dtuser.Tables[0].Rows[0]["ANNEX_SEA_UNIT_MEASUREMENT"].ToString();

                        txtRotationNo.Text = dtuser.Tables[0].Rows[0]["ANNEX_SEA_ROTATION_NO"].ToString();

                        txtRotationDate.Text = dtuser.Tables[0].Rows[0]["ANNEX_SEA_ROTATION_DATE"].ToString().Replace("01/01/1900", "");


                        txtFOBValue.Text = dtuser.Tables[0].Rows[0]["ANNEX_SEA_FOB_VALUE"].ToString();

                        txtFactoryAddress.Text = dtuser.Tables[0].Rows[0]["ANNEX_SEA_FACTORY_ADD"].ToString();
                        txtVoyageNo.Text = dtuser.Tables[0].Rows[0]["ANNEX_SEA_VOYAGENO"].ToString();
                        txtVesselNo.Text = dtuser.Tables[0].Rows[0]["ANNEX_SEA_VESSELNO"].ToString();
                        txtVesselDate.Text = dtuser.Tables[0].Rows[0]["ANNEX_SEA_VESSEL_DATE"].ToString();
                        txtUnit_Code.Text = dtuser.Tables[0].Rows[0]["ANNEX_SEA_PKG_UNIT_CODE"].ToString();


                        btnUpdate.Visible = true;
                        btnDelete.Visible = true;
                        btnSave.Visible = false;
                        btnNew.Visible = false;
                    }
                    else
                    {
                        Button_Visible();
                       
                    }
                }
            }
            else
            {
                Button_Visible();
                
            }
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
            Container_Id.Style.Add("display", "none");
            Package_Id.Style.Add("display", "none");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        
    }
    public void Package_Div_Visible()
    {
        try
        {
            string s = txtTotal_No_Packages.Text;
            string s1 = txtNo_Of_Containers.Text;

            if (txtTotal_No_Packages.Text != "")
            {
                s = s.Substring(0, 1);
                if (s != "0")
                    Package_Id.Style.Add("display", "Block");
            }
            else
            {
                Package_Id.Style.Add("display", "none");
            }
            if (txtNo_Of_Containers.Text != "" && txtNo_Of_Containers.Text != "0")
            {
                s1 = s1.Substring(0, 1);
                if (s1 != "0")

                    Container_Id.Style.Add("display", "Block");
            }
            else
            {
                Container_Id.Style.Add("display", "none");
            }
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
            ANNEX_C_Sea.ANNEX_SEA_ID = "";
            ANNEX_C_Sea.ANNEX_SEA_JOBNO = EXPORT_JOBNO;

            ANNEX_C_Sea.Ename = "select";
            ANNEX_C_Sea.WORKING_PERIOD = SELECT_BRANCH;
            dtuser = ANNEX_C_Sea.RetrieveAll_Annexure_C_Sea_Details();
            int result = ANNEX_C_Sea.result;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        
        return dtuser;
    }

    public int Export_Annexure_C_Sea_Insert_Update(string Flag)
    {
        try
        {
            ANNEX_C_Sea.ANNEX_SEA_JOBNO = EXPORT_JOBNO;
            ANNEX_C_Sea.ANNEX_SEA_FAC_STUFFED = ddlFactory_Stuffed.SelectedValue.ToString();
            ANNEX_C_Sea.ANNEX_SEA_SAMPLE_ACCOM = ddlSample_Accompanied.SelectedValue.ToString();

            if (ddlNatureOfCargo.SelectedValue == "C Containerized")
            {
                Nature_Cargo = "C";
            }
            if (ddlNatureOfCargo.SelectedValue == "P Packaged")
            {
                Nature_Cargo = "P";
            }
            if (ddlNatureOfCargo.SelectedValue == "CP Containerized")
            {
                Nature_Cargo = "CP";
            }
            if (ddlNatureOfCargo.SelectedValue == "LB Liquid and Bulk")
            {
                Nature_Cargo = "LB";
            }
            if (ddlNatureOfCargo.SelectedValue == "DB Dry Bulk")
            {
                Nature_Cargo = "DB";
            }

            ANNEX_C_Sea.ANNEX_SEA_NATURE_OF_CARGO = Nature_Cargo;
            ANNEX_C_Sea.ANNEX_SEA_MARKS_NOS = txtMarks_Numbers.Text;
            ANNEX_C_Sea.ANNEX_SEA_TOTAL_PACKAGES = txtTotal_No_Packages.Text;
            ANNEX_C_Sea.ANNEX_SEA_LOOSE_PACKETS = txtNo_Of_Loose_Packets.Text;
            ANNEX_C_Sea.ANNEX_SEA_NO_CONTAINERS = txtNo_Of_Containers.Text;
            ANNEX_C_Sea.ANNEX_SEA_GROSS_WEIGHT = txtGross_Weight.Text;
            ANNEX_C_Sea.ANNEX_SEA_NET_WEIGHT = txtNet_Weight.Text;
            ANNEX_C_Sea.ANNEX_SEA_UNIT_MEASUREMENT = txtUnit_Of_Measurement.Text;
            ANNEX_C_Sea.ANNEX_SEA_ROTATION_NO = txtRotationNo.Text;
            string dt = "";
            if (txtRotationDate.Text != "")
            {
                dt = txtRotationDate.Text;
            }
            else
            {
                dt = "01/01/1900";

            }
            ANNEX_C_Sea.ANNEX_SEA_ROTATION_DATE = dt;

            ANNEX_C_Sea.ANNEX_SEA_FOB_VALUE = txtFOBValue.Text;

            ANNEX_C_Sea.USER_ID = currentuser;
            ANNEX_C_Sea.flag = Flag;
            ANNEX_C_Sea.BRANCH_CODE = Connection.Current_Branch();
            ANNEX_C_Sea.WORKING_PERIOD = Connection.WorkingPeriod();
            ANNEX_C_Sea.BRANCH_COMMON = SELECT_BRANCH;
            ANNEX_C_Sea.ANNEX_SEA_SEAL_TYPE = ddlSeal_Type.SelectedValue.ToString();

            ANNEX_C_Sea.ANNEX_SEA_FACTORY_ADD = txtFactoryAddress.Text;
            ANNEX_C_Sea.ANNEX_SEA_VOYAGENO = txtVoyageNo.Text;
            ANNEX_C_Sea.ANNEX_SEA_VESSELNO = txtVesselNo.Text;
            ANNEX_C_Sea.ANNEX_SEA_VESSEL_DATE = txtVesselDate.Text;
            ANNEX_C_Sea.ANNEX_SEA_PKG_UNIT_CODE = txtUnit_Code.Text;
            ANNEX_C_Sea.JOBNO_PS = Session["JOBNO_PS"].ToString();

            i = ANNEX_C_Sea.Annexure_C_Sea_details_insertupdate();
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

            i = Export_Annexure_C_Sea_Insert_Update(F);
            if (i == 1)
            {
               
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = false;
                ddlFactory_Stuffed.Focus();
                Package_Div_Visible();

                Alert_msg("Annexure_C_Sea Saved Successfully", "btnSave");
                Session["Nature_Cargo"] = Nature_Cargo; // added by pandiyan 
                Elogix_Service();

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
                Alert_msg("Annexure_C_Sea Not Saved", "btnSave");
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
            i = Export_Annexure_C_Sea_Insert_Update(F);
            if (i == 1)
            {
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = false;
                ddlFactory_Stuffed.Focus();
                Package_Div_Visible();

                Alert_msg("Annexure_C_Sea Updated Successfully", "btnUpdate");
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
                Alert_msg("Annexure_C_Sea Not Saved", "btnUpdate");
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
            ANNEX_C_Sea.ANNEX_SEA_ID = "";
            ANNEX_C_Sea.ANNEX_SEA_JOBNO = EXPORT_JOBNO;

            ANNEX_C_Sea.Ename = "delete";
            ANNEX_C_Sea.WORKING_PERIOD = SELECT_BRANCH;
            dtuser = ANNEX_C_Sea.RetrieveAll_Annexure_C_Sea_Details();
            i = ANNEX_C_Sea.result;

            if (i == 1)
            {
                btnNew_Click(sender, e);
                Package_Div_Visible();

                Alert_msg("Annexure_C_Sea Deleted");
                Elogix_Service();
            }
            else
            {
                Alert_msg("Annexure_C_Sea Not Deleted");
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
            ddlFactory_Stuffed.Focus();
            ddlNatureOfCargo.Items.Clear();
            NatureCargo();

            Button_Visible();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
      
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'ANNEXURE_C_SEA', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'ANNEXURE_C_SEA', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
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