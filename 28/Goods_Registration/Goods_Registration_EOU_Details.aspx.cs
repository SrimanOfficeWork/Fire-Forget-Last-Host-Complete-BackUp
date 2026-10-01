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
    Goods_Reg_EOU Goods_EOU = new Goods_Reg_EOU();
    public string Trans_ID = "";
    ErrorLogs er = new ErrorLogs();
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
    User_Creation user_Create = new User_Creation();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();


        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

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

        if (Session["EXPORT_JOBNO"] != null)
        {
            EXPORT_JOBNO = Session["EXPORT_JOBNO"].ToString();

            if (!IsPostBack)
            {
                //----------------SETTING SCREEN PERMISSION---------------//
                Screen_Id = 11;
                Page_Rights(Screen_Id);
                //----------------SETTING SCREEN PERMISSION---------------//

              
                Edit_Annexure_Details();
            }
           
        }
        else
        {
          
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
    public DataSet BindValue()
    {

        Goods_EOU.GOODS_EOU_ID= "";
        Goods_EOU.GOODS_EOU_JOBNO = EXPORT_JOBNO;

        Goods_EOU.Ename = "select";
        Goods_EOU.WORKING_PERIOD = SELECT_BRANCH;
        dtuser = Goods_EOU.RetrieveAll_Annexure_Details();
        return dtuser;

    }

    public void Edit_Annexure_Details()
    {
        if (Session["EXPORT_JOBNO"] != null)
        {
            BindValue();
            if (dtuser.Tables[0].Rows.Count > 0)
            {
                Date_Time rep = new Date_Time();
                //txtExporterName.Text = dtuser.Tables[0].Rows[0]["ANNEX_EXPORTERNAME"].ToString();

                //txtIECNo.Text = dtuser.Tables[0].Rows[0]["ANNEX_IECCODE"].ToString();
                //txtBranchSLNo.Text = dtuser.Tables[0].Rows[0]["ANNEX_BR_SLNO"].ToString();
                txtExaminationDate.Text = dtuser.Tables[0].Rows[0]["GOODS_EOU_EXAM_DATE"].ToString();
                txtExam_Officer.Text = dtuser.Tables[0].Rows[0]["GOODS_EOU_EXAM_OFFICER"].ToString();
                txtExam_Design.Text = dtuser.Tables[0].Rows[0]["GOODS_EOU_EXAM_DESIGN"].ToString();
                txtSuperv_Officer.Text = dtuser.Tables[0].Rows[0]["GOODS_EOU_SUPER_NAME"].ToString();
                txtSuperv_Design.Text = dtuser.Tables[0].Rows[0]["GOODS_EOU_SUPER_DESIGN"].ToString();
                txtCommissionRate.Text = dtuser.Tables[0].Rows[0]["GOODS_EOU_COMMISSION_RATE"].ToString();

                txtDivision.Text = dtuser.Tables[0].Rows[0]["GOODS_EOU_DIVISION"].ToString();

                txtRange.Text = dtuser.Tables[0].Rows[0]["GOODS_EOU_RANGE"].ToString();

                string Ver_Exam_Off = dtuser.Tables[0].Rows[0]["GOODS_EOU_DECLARED_VALUE_VERI"].ToString();

                if (Ver_Exam_Off == "Y")
                {
                    chkVerifiedOfficer.Checked = true;
                }
                else
                {
                    chkVerifiedOfficer.Checked = false;
                }



                string Sample_Drawn = dtuser.Tables[0].Rows[0]["GOODS_EOU_DRAWN"].ToString();

                if (Sample_Drawn == "Y")
                {
                    chkSampleDrawn.Checked = true;
                }
                else
                {
                    chkSampleDrawn.Checked = false;
                }


                txtSealNo.Text = dtuser.Tables[0].Rows[0]["GOODS_EOU_SEAL_NO"].ToString();
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = false;

            }
            else
           
                Button_Visible();
        }
        else
            Button_Visible();
    }
    public void Button_Visible()
    {
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnSave.Visible = true;
        btnNew.Visible = true;
        
    }

    public int Export_Annexure_Insert_Update(string Flag)
    {
        //Export.JOBID = jobid;
        ///Goods_EOU.ANNEX_EXPORTERNAME = //txtExporterName.Text;

        Goods_EOU.GOODS_EOU_JOBNO = EXPORT_JOBNO;
        //Goods_EOU.ANNEX_IECCODE = txtIECNo.Text;
       // Export.TRANSPORT_MODE = ddlTransportMode.SelectedValue.ToString();
        //Goods_EOU.ANNEX_BR_SLNO = txtBranchSLNo.Text;
        Goods_EOU.GOODS_EOU_EXAM_DATE = txtExaminationDate.Text;
        Goods_EOU.GOODS_EOU_EXAM_OFFICER = txtExam_Officer.Text;
        Goods_EOU.GOODS_EOU_EXAM_DESIGN = txtExam_Design.Text;
        Goods_EOU.GOODS_EOU_SUPER_NAME = txtSuperv_Officer.Text;
        Goods_EOU.GOODS_EOU_SUPER_DESIGN = txtSuperv_Design.Text;
        Goods_EOU.GOODS_EOU_COMMISSION_RATE = txtCommissionRate.Text;
        Goods_EOU.GOODS_EOU_DIVISION = txtDivision.Text;
        Goods_EOU.GOODS_EOU_RANGE = txtRange.Text;
        string VERIFY_EXAM_OFF;

        if (chkVerifiedOfficer.Checked == true)
        {
            VERIFY_EXAM_OFF = "Y";
        }
        else
        {
            VERIFY_EXAM_OFF = "N";
        }

        Goods_EOU.GOODS_EOU_DECLARED_VALUE_VERI = VERIFY_EXAM_OFF;

        string SAMPLE_DRAWN;

        if (chkSampleDrawn.Checked == true)
        {
            SAMPLE_DRAWN = "Y";
        }
        else
        {
            SAMPLE_DRAWN = "N";
        }

        Goods_EOU.GOODS_EOU_DRAWN = SAMPLE_DRAWN;
        Goods_EOU.GOODS_EOU_SEAL_NO = txtSealNo.Text;
       
        Goods_EOU.USER_ID = currentuser;

        Goods_EOU.flag = Flag;
        Goods_EOU.BRANCH_CODE = currentbranch;
        Goods_EOU.WORKING_PERIOD = Working_Period;
        Goods_EOU.BRANCH_COMMON = SELECT_BRANCH;
        i = Goods_EOU.Goods_Reg_EOU_details_insertupdate();
        return i;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtExaminationDate.Text != "" && txtExam_Officer.Text != "" && txtExam_Design.Text != "" && txtSuperv_Officer.Text != "" && txtSuperv_Design.Text != "" && txtCommissionRate.Text != "" && txtDivision.Text != "" && txtRange.Text != "" && txtSealNo.Text !="")
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
                    //txtIECNo.Focus();
                    // btnSave.Enabled = false;

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);
                    Alert_msg("Saved Successfully", "btnSave");

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
                    Alert_msg("Not Saved", "btnSave");

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
        if ( txtExaminationDate.Text != "" && txtExam_Officer.Text != "" && txtExam_Design.Text != "" && txtSuperv_Officer.Text != "" && txtSuperv_Design.Text != "" && txtCommissionRate.Text != "" && txtDivision.Text != "" && txtRange.Text != "" && txtSealNo.Text != "")
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
                    //txtIECNo.Focus();
                    // btnSave.Enabled = false;

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Updated Successfully')</script>", false);
                    Alert_msg("Updated Successfully", "btnUpdate");

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
                    Alert_msg("Not Saved", "btnUpdate");

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
            Goods_EOU.GOODS_EOU_ID = "";
            Goods_EOU.GOODS_EOU_JOBNO = EXPORT_JOBNO;

            Goods_EOU.Ename = "delete";
            Goods_EOU.WORKING_PERIOD = SELECT_BRANCH;
            dtuser = Goods_EOU.RetrieveAll_Annexure_Details();
            i = Goods_EOU.result;

            if (i == 1)
            {


                btnNew_Click(sender, e);
                Alert_msg("Deleted");

            }
           
            else
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Deleted')</script>", false);
                Alert_msg("Not Deleted");

            }


        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Transaction trans = new Transaction();
        trans.ResetFields(Page.Controls);
        //txtExporterName.Focus();
        Button_Visible();
        //Get_ExporterName_SessionValue();
    }
   
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GOODS_REG_EOU', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GOODS_REG_EOU', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    
}