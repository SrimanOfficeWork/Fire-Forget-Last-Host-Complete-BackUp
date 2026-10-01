using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Export_Annexure_C1Details : ThemeClass
{
    DataSet dtuser = new DataSet();

    AppSession aps = new AppSession();
    //Export_General_New Export = new Export_General_New();
    Annexure ANNEX = new Annexure();
    public string Trans_ID = "";
    ErrorLogs er = new ErrorLogs();
    Default_Settings Default = new Default_Settings();

    DataSet ds = new DataSet();
    public int i;
    public string AUTO_ID;

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    public string EXPORT_JOBNO;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public int Screen_Id;
    public string JOB_LOCK, JOB_RELEASE;
    User_Creation user_Create = new User_Creation();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();

            currentuser = Session["currentuser"].ToString();
            currentbranch = Session["currentbranch"].ToString();
            currentcomp_name = Session["currentcomp_name"].ToString();
            comp_ConnectionStr = Session["currentcomp_db"].ToString();
            Working_Period = Session["WorkingPeriod"].ToString();
            LoginDate = Session["LoginDate"].ToString();

            // commented for areawise implementation on 05-mar-2020
            /*
            if (Session["SELECT_TYPE"] != null)
            {
                SELECT_TYPE = Session["SELECT_TYPE"].ToString();

                if (SELECT_TYPE == "Branchwise Job")
                {
                    SELECT_BRANCH = currentbranch;
                }
                else
                {
                    SELECT_BRANCH = "";
                }
            }
            else
            {
                SELECT_BRANCH = "";
            }
              * */
            SELECT_BRANCH = Connection.Get_Company_Type();
            if (Session["EXPORT_JOBNO"] != null)
            {
                EXPORT_JOBNO = Session["EXPORT_JOBNO"].ToString();

                if (!IsPostBack)
                {
                    //----------------SETTING SCREEN PERMISSION---------------//
                    Screen_Id = 12;
                    Page_Rights(Screen_Id);
                    //----------------SETTING SCREEN PERMISSION---------------//

                    txtIECNo.Attributes.Add("readonly", "readonly");
                    txtAddress1.Attributes.Add("readonly", "readonly");
                    txtAddress2.Attributes.Add("readonly", "readonly");
                    txtAddress3.Attributes.Add("readonly", "readonly");
                    txtAddress4.Attributes.Add("readonly", "readonly");
                    txtExporterName.Focus();
                    Get_Client_Default_Settings();
                    Edit_Annexure_Details();
                }
                //auto search

                //txtIec_Code.Attributes.Add("onkeyup", "javascript:CallServerside_Importer('" + txtIec_Code.ClientID + "', '" + txtIec_Name.ClientID + "')");
                //txtExporterName.Attributes.Add("onblur", "javascript:CallServerside_Importer('" + txtExporterName.ClientID + "', '" + txtIECNo.ClientID + "')");

                txtExporterName.Attributes.Add("onblur", "javascript:CallServerside_Importer_2('" + txtExporterName.ClientID + "', '" + hd_Brslno.ClientID + "')");


                //txtIECNo.Attributes.Add("onblur", "javascript:CallServerside_Importer('" + txtIECNo.ClientID + "', '" + txtBranchSLNo.ClientID + "')");
                txtBranchSLNo.Attributes.Add("onblur", "javascript:CallServerside_Importer_Branch('" + txtBranchSLNo.ClientID + "', '" + txtIECNo.ClientID + "')");
                //auto search
            }
            else
            {
                //Response.Write("<script>window.open('General.aspx','_parent');</script>");
                Response.Write("<script>window.parent.document.getElementById('General').click();</script>");

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
            Connection.Error_Msg(ex.Message);
        }
        
    }
    public DataSet BindValue()
    {
        try
        {
            ANNEX.ANNEX_ID = "";
            ANNEX.ANNEX_JOBNO = EXPORT_JOBNO;

            ANNEX.Ename = "select";
            ANNEX.WORKING_PERIOD = SELECT_BRANCH;
            dtuser = ANNEX.RetrieveAll_Annexure_Details();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
      
        return dtuser;

    }

    public void Edit_Annexure_Details()
    {
        try
        {
            if (Session["EXPORT_JOBNO"] != null)
            {
                BindValue();
                if (dtuser.Tables[0].Rows.Count > 0)
                {

                    txtExporterName.Text = dtuser.Tables[0].Rows[0]["ANNEX_EXPORTERNAME"].ToString();

                    txtIECNo.Text = dtuser.Tables[0].Rows[0]["ANNEX_IECCODE"].ToString();
                    txtBranchSLNo.Text = dtuser.Tables[0].Rows[0]["ANNEX_BR_SLNO"].ToString();

                    hd_Brslno.Value = dtuser.Tables[0].Rows[0]["ANNEX_BR_SLNO"].ToString();
                    hdfTransport_mode.Value = Session["hdfTransport_mode"].ToString();

                    txtAddress1.Text = dtuser.Tables[0].Rows[0]["ANNEX_ADDRESS1"].ToString();
                    txtAddress2.Text = dtuser.Tables[0].Rows[0]["ANNEX_ADDRESS2"].ToString();
                    txtAddress3.Text = dtuser.Tables[0].Rows[0]["ANNEX_ADDRESS3"].ToString();
                    txtAddress4.Text = dtuser.Tables[0].Rows[0]["ANNEX_ADDRESS4"].ToString();


                    txtExaminationDate.Text = dtuser.Tables[0].Rows[0]["ANNEX_EXAM_DATE"].ToString();
                    txtExam_Officer.Text = dtuser.Tables[0].Rows[0]["ANNEX_EXAM_OFFICER"].ToString();
                    txtExam_Design.Text = dtuser.Tables[0].Rows[0]["ANNEX_EXAM_DESIGN"].ToString();
                    txtSuperv_Officer.Text = dtuser.Tables[0].Rows[0]["ANNEX_SUPER_NAME"].ToString();
                    txtSuperv_Design.Text = dtuser.Tables[0].Rows[0]["ANNEX_SUPER_DESIGN"].ToString();
                    txtCommissionRate.Text = dtuser.Tables[0].Rows[0]["ANNEX_COMMISSION_RATE"].ToString();

                    txtDivision.Text = dtuser.Tables[0].Rows[0]["ANNEX_DIVISION"].ToString();

                    txtRange.Text = dtuser.Tables[0].Rows[0]["ANNEX_RANGE"].ToString();

                    string Ver_Exam_Off = dtuser.Tables[0].Rows[0]["ANNEX_VERIFIED_EXAM_OFFICER"].ToString();

                    if (Ver_Exam_Off == "Y")
                    {
                        chkVerifiedOfficer.Checked = true;
                    }
                    else
                    {
                        chkVerifiedOfficer.Checked = false;
                    }



                    string Sample_Drawn = dtuser.Tables[0].Rows[0]["ANNEX_SAMPLE_DRAWN"].ToString();

                    if (Sample_Drawn == "Y")
                    {
                        chkSampleDrawn.Checked = true;
                    }
                    else
                    {
                        chkSampleDrawn.Checked = false;
                    }


                    txtSealNo.Text = dtuser.Tables[0].Rows[0]["ANNEX_SEAL_NO"].ToString();
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnSave.Visible = false;
                    btnNew.Visible = false;

                }
                else
                {
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnSave.Visible = true;
                    btnNew.Visible = true;

                    //Get_ExporterName_SessionValue();
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }

    public int Export_Annexure_Insert_Update(string Flag)
    {
        try
        {
            //Export.JOBID = jobid;
            ANNEX.ANNEX_EXPORTERNAME = txtExporterName.Text;

            ANNEX.ANNEX_JOBNO = EXPORT_JOBNO;
            ANNEX.ANNEX_IECCODE = txtIECNo.Text;
            // Export.TRANSPORT_MODE = ddlTransportMode.SelectedValue.ToString();
            ANNEX.ANNEX_BR_SLNO = txtBranchSLNo.Text;
            ANNEX.ANNEX_ADDRESS1 = txtAddress1.Text;
            ANNEX.ANNEX_ADDRESS2 = txtAddress2.Text;
            ANNEX.ANNEX_ADDRESS3 = txtAddress3.Text;
            ANNEX.ANNEX_ADDRESS4 = txtAddress4.Text;
            ANNEX.ANNEX_EXAM_DATE = txtExaminationDate.Text;
            ANNEX.ANNEX_EXAM_OFFICER = txtExam_Officer.Text;
            ANNEX.ANNEX_EXAM_DESIGN = txtExam_Design.Text;
            ANNEX.ANNEX_SUPER_NAME = txtSuperv_Officer.Text;
            ANNEX.ANNEX_SUPER_DESIGN = txtSuperv_Design.Text;
            ANNEX.ANNEX_COMMISSION_RATE = txtCommissionRate.Text;
            ANNEX.ANNEX_DIVISION = txtDivision.Text;
            ANNEX.ANNEX_RANGE = txtRange.Text;
            string VERIFY_EXAM_OFF;

            if (chkVerifiedOfficer.Checked == true)
            {
                VERIFY_EXAM_OFF = "Y";
            }
            else
            {
                VERIFY_EXAM_OFF = "N";
            }

            ANNEX.ANNEX_VERIFIED_EXAM_OFFICER = VERIFY_EXAM_OFF;

            string SAMPLE_DRAWN;

            if (chkSampleDrawn.Checked == true)
            {
                SAMPLE_DRAWN = "Y";
            }
            else
            {
                SAMPLE_DRAWN = "N";
            }

            ANNEX.ANNEX_SAMPLE_DRAWN = SAMPLE_DRAWN;
            ANNEX.ANNEX_SEAL_NO = txtSealNo.Text;

            ANNEX.USER_ID = currentuser;

            ANNEX.flag = Flag;
            ANNEX.BRANCH_CODE = currentbranch;
            ANNEX.WORKING_PERIOD = Working_Period;
            ANNEX.BRANCH_COMMON = SELECT_BRANCH;

            i = ANNEX.Annexure_details_insertupdate();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
        return i;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtIECNo.Text != "" && txtBranchSLNo.Text != "" && txtExaminationDate.Text != "" && txtExam_Officer.Text != "" && txtExam_Design.Text != "" && txtSuperv_Officer.Text != "" && txtSuperv_Design.Text != "" && txtCommissionRate.Text != "" && txtDivision.Text != "" && txtRange.Text != "" && txtSealNo.Text !="")
        {
            try
            {
                //string ID = "";
                string F = "S";
                i = Export_Annexure_Insert_Update(F);
                if (i == 1)
                {

                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnSave.Visible = false;
                    btnNew.Visible = false;
                    //trans.ResetFields(Page.Controls);
                    txtIECNo.Focus();
                    // btnSave.Enabled = false;

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);
                    Alert_msg("Annexure_C1 Saved Successfully", "btnSave");

                }
                else if (i == 2)
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Not Save, Job No Already Exist')</script>", false);
                    Alert_msg("Job No Already Exist!", "btnSave");

                }
                else
                {
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnSave.Visible = true;
                    btnNew.Visible = true;
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);
                    Alert_msg("Annexure_C1 Not Saved", "btnSave");

                }


            }
            catch (Exception ex)
            {
                er.makeLog(ex.Message);
            }
        }
        else
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Enter All Mandatory Field')</script>", false);
            Alert_msg("Enter All Mandatory Field", "btnSave");


        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (txtIECNo.Text != "" && txtBranchSLNo.Text != "" && txtExaminationDate.Text != "" && txtExam_Officer.Text != "" && txtExam_Design.Text != "" && txtSuperv_Officer.Text != "" && txtSuperv_Design.Text != "" && txtCommissionRate.Text != "" && txtDivision.Text != "" && txtRange.Text != "" && txtSealNo.Text != "")
        {
            try
            {
                //string ID = "";
                string F = "U";
                i = Export_Annexure_Insert_Update(F);
                if (i == 1)
                {

                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnSave.Visible = false;
                    btnNew.Visible = false;
                    //trans.ResetFields(Page.Controls);
                    txtIECNo.Focus();
                    // btnSave.Enabled = false;

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Updated Successfully')</script>", false);
                    Alert_msg("Annexure_C1 Updated Successfully", "btnUpdate");

                }
                else if (i == 2)
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Not Save, Job No Already Exist')</script>", false);
                    Alert_msg("Job No Already Exist!", "btnUpdate");

                }
                else
                {
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnSave.Visible = false;
                    btnNew.Visible = false;
                   // ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);
                    Alert_msg("Annexure_C1 Not Saved", "btnUpdate");

                }


            }
            catch (Exception ex)
            {
                er.makeLog(ex.Message);
            }
        }
        else
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Enter All Mandatory Field')</script>", false);
            Alert_msg("Enter All Mandatory Field", "btnUpdate");


        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            //string ID = "";
            ANNEX.ANNEX_ID = "";
            ANNEX.ANNEX_JOBNO = EXPORT_JOBNO;

            ANNEX.Ename = "delete";
            ANNEX.WORKING_PERIOD = SELECT_BRANCH;
            dtuser = ANNEX.RetrieveAll_Annexure_Details();
            i = ANNEX.result;

            if (i == 1)
            {


                btnNew_Click(sender, e);
                Alert_msg("Annexure_C1 Deleted");

            }
           
            else
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Deleted')</script>", false);
                Alert_msg("Annexure_C1 Not Deleted");

            }


        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            Transaction trans = new Transaction();
            trans.ResetFields(Page.Controls);
            txtExporterName.Focus();
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
            btnNew.Visible = true;
            //Get_ExporterName_SessionValue();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
      
    }
    public void Get_ExporterName_SessionValue()
    {
        try
        {
            txtExporterName.Text = Session["EXPORTER_NAME"].ToString();
            txtIECNo.Text = Session["EXPORTER_IECNO"].ToString();
            txtBranchSLNo.Text = Session["EXPORTER_BRANCHSLNO"].ToString();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
       
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Annexure_C1', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Annexure_C1', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    [System.Web.Services.WebMethod]
    public static string GetImporter(string custid)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            // custid = Auto.Country_Master_FromClientSide_Calling(custid);
            Auto.Ename = "IMP_EXP_MASTER_IMPORTER_SEARCH_ADCODE";
            Auto.Enamesearch = custid;
            ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {

                string Address1 = ds.Tables[0].Rows[0]["IMP_EXP_ADD1"].ToString();
                string Address2 = ds.Tables[0].Rows[0]["IMP_EXP_ADD2"].ToString();
                string Address3 = ds.Tables[0].Rows[0]["IMP_EXP_ADD3"].ToString();
                string Address4 = ds.Tables[0].Rows[0]["IMP_EXP_ADD4"].ToString();
                string Address5 = ds.Tables[0].Rows[0]["IMP_EXP_PIN_CODE"].ToString();
                string IECNo = ds.Tables[0].Rows[0]["IMP_EXP_IECNO"].ToString();
                string BranchNo = ds.Tables[0].Rows[0]["IMP_EXP_BRSLNO"].ToString();

                custid = Address1 + "~~" + Address2 + "~~" + Address3 + "~~" + Address4 + "~~" + Address5 + "~~" + IECNo + "~~" + BranchNo;
            }

            //if (Auto.Ename != "1")
            //{
            //custid = "";
            // }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
        return custid;
    }

    [System.Web.Services.WebMethod]
    public static string GetImporter_2(string custid, string custid_2)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();

            string STD_Type = "";

            if (HttpContext.Current.Session["STANDARD_TYPE"] != null)
            {
                STD_Type = HttpContext.Current.Session["STANDARD_TYPE"].ToString();

                if (STD_Type == "Non_STD")
                {
                    STD_Type = STD_Type;
                }
                else
                {
                    STD_Type = "";
                }
            }


            Auto.Ename = "IMP_EXP_MASTER_IMPORTER_SEARCH_Slno";
            Auto.Enamesearch = custid;
            Auto.NSearch = custid_2;
            Auto.STANDARD_TYPE = STD_Type;

            ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH_STD_Type();
            if (ds.Tables[0].Rows.Count > 0)
            {

                string Address1 = ds.Tables[0].Rows[0]["IMP_EXP_ADD1"].ToString();
                string Address2 = ds.Tables[0].Rows[0]["IMP_EXP_ADD2"].ToString();
                string Address3 = ds.Tables[0].Rows[0]["IMP_EXP_ADD3"].ToString();
                string Address4 = ds.Tables[0].Rows[0]["IMP_EXP_ADD4"].ToString();
                string Address5 = ds.Tables[0].Rows[0]["IMP_EXP_PIN_CODE"].ToString();
                string IECNo = ds.Tables[0].Rows[0]["IMP_EXP_IECNO"].ToString();
                string BranchNo = ds.Tables[0].Rows[0]["IMP_EXP_BRSLNO"].ToString();
                string IMP_EXP_TYPE = ds.Tables[0].Rows[0]["IMP_EXP_TYPE"].ToString();
                custid = Address1 + "~~" + Address2 + "~~" + Address3 + "~~" + Address4 + "~~" + Address5 + "~~" + IECNo + "~~" + BranchNo + "~~" + IMP_EXP_TYPE;
            }

            //if (Auto.Ename != "1")
            //{
            //custid = "";
            // }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
        return custid;
    }

    //********************************************* IMPORTER BRANCHWISE SERIAL NO SEARCH BACKUP *******************************

    //[System.Web.Services.WebMethod]
    //public static string GetImporter_Branchwise(string custid, string custid1)
    //{
    //    Auto_Search Auto = new Auto_Search();
    //    DataSet ds = new DataSet();
    //    // custid = Auto.Country_Master_FromClientSide_Calling(custid);
    //    Auto.Ename = "IMP_EXP_MASTER_IMPORTER_BRANCH_WISE_ADCODE";
    //    Auto.Enamesearch = custid;
    //    Auto.NSearch = custid1;
    //    ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {

            
    //        string Address1 = ds.Tables[0].Rows[0]["IMP_EXP_ADD1"].ToString();
    //        string Address2 = ds.Tables[0].Rows[0]["IMP_EXP_ADD2"].ToString();
    //        string Address3 = ds.Tables[0].Rows[0]["IMP_EXP_ADD3"].ToString();
    //        string Address4 = ds.Tables[0].Rows[0]["IMP_EXP_ADD4"].ToString();
    //        string Address5 = ds.Tables[0].Rows[0]["IMP_EXP_PIN_CODE"].ToString();
    //        string IECNo = ds.Tables[0].Rows[0]["IMP_EXP_IECNO"].ToString();
    //        string BranchNo = ds.Tables[0].Rows[0]["IMP_EXP_BRSLNO"].ToString();
           
    //        custid = Address1 + "~~" + Address2 + "~~" + Address3 + "~~" + Address4 + "~~" + Address5 + "~~" + IECNo + "~~" + BranchNo;

    //    }

    //    return custid;
    //}

    //********************************************* IMPORTER BRANCHWISE SERIAL NO SEARCH BACKUP *******************************


    [System.Web.Services.WebMethod]
    public static string GetImporter_Branchwise(string custid, string custid1)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            // custid = Auto.Country_Master_FromClientSide_Calling(custid);

            string STD_Type = "";

            if (HttpContext.Current.Session["STANDARD_TYPE"] != null)
            {
                STD_Type = HttpContext.Current.Session["STANDARD_TYPE"].ToString();

                if (STD_Type == "Non_STD")
                {
                    STD_Type = STD_Type;
                }
                else
                {
                    STD_Type = "";
                }
            }


            Auto.Ename = "IMP_EXP_MASTER_IMPORTER_BRANCH_WISE";
            Auto.Enamesearch = custid;
            Auto.NSearch = custid1;
            Auto.STANDARD_TYPE = STD_Type;

            ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH_STD_Type();
            if (ds.Tables[0].Rows.Count > 0)
            {
                string Address1 = ds.Tables[0].Rows[0]["IMP_EXP_ADD1"].ToString();
                string Address2 = ds.Tables[0].Rows[0]["IMP_EXP_ADD2"].ToString();
                string Address3 = ds.Tables[0].Rows[0]["IMP_EXP_ADD3"].ToString();
                string Address4 = ds.Tables[0].Rows[0]["IMP_EXP_ADD4"].ToString();
                string Address5 = ds.Tables[0].Rows[0]["IMP_EXP_PIN_CODE"].ToString();
                string IECNo = ds.Tables[0].Rows[0]["IMP_EXP_IECNO"].ToString();
                string BranchNo = ds.Tables[0].Rows[0]["IMP_EXP_BRSLNO"].ToString();
                string IMP_EXP_TYPE = ds.Tables[0].Rows[0]["IMP_EXP_TYPE"].ToString();

                custid = Address1 + "~~" + Address2 + "~~" + Address3 + "~~" + Address4 + "~~" + Address5 + "~~" + IECNo + "~~" + BranchNo + "~~" + IMP_EXP_TYPE;
            }

            //if (Auto.Ename != "1")
            //{
            //custid = "";
            // }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
        return custid;
    }


    public void Get_Client_Default_Settings()
    {
        try
        {
            Default.STANDARD_TYPE = "";
            Default.USER_ID = currentuser;
            Default.BRANCH_CODE = currentbranch;
            Default.YEAR = "";
            Default.WORKING_PERIOD = Working_Period;
            Default.BRANCH_COMMON = SELECT_BRANCH;
            Default.flag = "Get_Details";

            ds = Default.Client_DefaultSettings_Insert_Update();

            if (ds.Tables[0].Rows.Count > 0)
            {
                ViewState["STANDARD_TYPE"] = ds.Tables[0].Rows[0]["STANDARD_TYPE"].ToString();
                Hdn_STANDARD_TYPE.Value = ViewState["STANDARD_TYPE"].ToString();
                Session["STANDARD_TYPE"] = Hdn_STANDARD_TYPE.Value;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }

}