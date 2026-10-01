using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Import_Undertaking_Form : ThemeClass
{
  
    SqlConnection con;
    User_Creation user_Create = new User_Creation();
    DataTable dt = new DataTable();
    DataSet dtuser = new DataSet();
    DataSet dss = new DataSet();
    DataSet ds = new DataSet();
    CheckList chklist = new CheckList();
    NForm NForm = new NForm();
    Undertaking_Form UF = new Undertaking_Form();
    AppSession aps = new AppSession();
    Date_Time date = new Date_Time();
    //SqlDataReader dr = new SqlDataReader();
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public string SELECT_TYPE, SELECT_BRANCH;
    public int Screen_Id;
    ErrorLogs er = new ErrorLogs();
    Date_Time dta = new Date_Time();
   
    public string  CHANO,CHANAME,CHAAddr1, CHAAddr2, CHAAddr3,CHAAddr4,CHAAddr5;
   
    string current_date = DateTime.Now.ToString("dd/mm/yyyy");
    public int i;


    protected void Page_Load(object sender, EventArgs e)
    {

        aps.checkSession();
        con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

        CHANO = HttpContext.Current.Session["CHA_NO"].ToString();
        CHANAME = HttpContext.Current.Session["CHA_NAME"].ToString();
        CHAAddr1 = HttpContext.Current.Session["CHA_ADDRESS"].ToString();
        CHAAddr2 = HttpContext.Current.Session["CHA_ADDRESS1"].ToString();
        CHAAddr3 = HttpContext.Current.Session["CHA_ADDRESS2"].ToString();
        CHAAddr4 = HttpContext.Current.Session["CHA_ADDRESS3"].ToString();
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

        if (!IsPostBack)
        {

            Load_NF_JobNo();
  
            //btnSend.Visible = false;
            //btnSend22.Visible = false;
            btnDelete.Visible = false;
            btn_Report.Visible = false;
            
        }
        
    }

  

    public void Load_NF_JobNo()
    {
             

        CheckList chklist = new CheckList();
        chklist.JOBNo = "";
        chklist.Ename = "select_jobno";
        chklist.Workingperiod = SELECT_BRANCH;
        ddlJobNo.DataSource = chklist.RetrieveAll_General_Details();
        ddlJobNo.DataValueField = "JOBNO";
        ddlJobNo.DataTextField = "JOBNO";
        ddlJobNo.DataBind();
        ddlJobNo.Items.Remove("0");
        ddlJobNo.Items.Insert(0, "Select");

        HiddenField1.Value = ddlJobNo.SelectedValue.ToString();

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
      
    }

    public int insert_update()
    {
        //UF.ID = "";
        UF.JOBNO = ddlJobNo.SelectedItem.Text;
        UF.IMPORTERNAME1 = txt_ImporterName1.Text;
        UF.IMPORTERADD1 = txt_ImporterAdd1.Text;
        UF.IMPORTERADD2 = txt_ImporterAdd2.Text;
        UF.IMPORTERADD3 = txt_ImporterAdd3.Text;
        UF.IMPORTERADD4 = txt_ImporterAdd4.Text;
        UF.IMPORTERADD5 = txt_ImporterAdd5.Text;
        UF.IEC_CODE = txt_IEC_CodeNo.Text;
        UF.NOTENO = txt_NoteNo.Text;
        UF.NOTEDATE = txt_Note_Date.Text;
        UF.CHA_NAME = txt_CHAName.Text;
        UF.CHA_NO = txt_CHANo.Text;
        UF.CHA_ADD1 = txt_CHA_Add1.Text;
        UF.CHA_ADD2 = txt_CHA_Add2.Text;
        UF.CHA_ADD3 = txt_CHA_Add3.Text;
        UF.CHA_ADD4 = txt_CHA_Add4.Text;
        UF.CHA_ADD5 = txt_CHA_Add5.Text;
        UF.IMPORTERNAME2 = txt_ImporterName2.Text;
        UF.CONSIGNMENT_NOTENO = txt_Consignment_NoteNo.Text;
        UF.CONSIGNMENT_NOTE_DATE = txt_Consignment_NoteDate.Text;
        UF.IMPORTERNAME_UNDERTAKING = txt_Importer_Undertaking.Text;
        UF.IMPORTER_FOR = txt_Importer_FOR.Text;
        UF.WITNESS1 = txt_Witness1.Text;
        UF.WITNESS2 = txt_Witness2.Text;
        UF.flag = "S";
        UF.BRANCHCODE = currentbranch;
        UF.YEAR = current_date;
        UF.WORKINGPERIOD = Working_Period;
        UF.USERID = currentuser;
        UF.LOGINDATE = current_date;
        UF.BRANCH_COMMON = SELECT_BRANCH;


        i = UF.Undertaking_Insert_Update();

        return i;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            insert_update();

            if (i == 1)
            {
                Alert_msg("Saved Successfully", "btnSave");

                   
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                    btn_Report.Visible = true;
                    btnDelete.Visible = true;
               
            }           
            else
            {
                Alert_msg("Not Saved", "btnNew");

            }

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            insert_update();
            if (i == 2)
            {
                
                    Alert_msg("Updated Successfully", "btnUpdate");   
            }
              
            else
            {
                Alert_msg("Not Updated", "btnUpdate");

            }
        }

            
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try{

            UF.JOBNO = ddlJobNo.SelectedItem.Text;
            UF.flag = "Delete";
            UF.BRANCHCODE = currentbranch;
            UF.WORKINGPERIOD = Working_Period;
            UF.BRANCH_COMMON = SELECT_BRANCH;

            ds = UF.Retreive_Undertaking();
            int i1 = UF.result;

            if (i1 > 0)
            {

                string prompt = "<script>$(document).ready(function(){{jAlert('UNDERTAKING FORM Deleted', 'UNDERTAKING FORM', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
     
            }

        
            else
            {
                Alert_msg("N-FORM Not Deleted");

            }
        }
            
        
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    protected void btn_print_Click(object sender, EventArgs e)
    {


        string ec = "<script>$(document).ready(function(){{return PrintGridData();}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", ec, false);

    }

   
    protected void ddlJobno_SelectedIndexChanged(object sender, EventArgs e)
    {
        Clear();
        string jobno;
        jobno = ddlJobNo.SelectedValue.ToString();
        DataTable dt1 = new DataTable();
        try
        {

            if (ddlJobNo.SelectedItem.Text != "Select")
            {



                UF.JOBNO = jobno;
                UF.flag = "Get_UNDERTAKING";
                UF.BRANCHCODE = currentbranch;
                UF.WORKINGPERIOD = Working_Period;
                UF.BRANCH_COMMON = SELECT_BRANCH;

                ds = UF.Retreive_Undertaking();
                int i1 = UF.result;

                if (i1 == 1)
                {

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txt_ImporterName1.Text = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                        txt_ImporterAdd1.Text = ds.Tables[0].Rows[0]["ADDRESS1"].ToString();
                        txt_ImporterAdd2.Text = ds.Tables[0].Rows[0]["ADDRESS2"].ToString();
                        txt_ImporterAdd3.Text = ds.Tables[0].Rows[0]["ADDRESS3"].ToString();
                        txt_ImporterAdd4.Text = ds.Tables[0].Rows[0]["ADDRESS4"].ToString();
                        txt_ImporterAdd5.Text = ds.Tables[0].Rows[0]["ADDRESS5"].ToString();
                        txt_IEC_CodeNo.Text = ds.Tables[0].Rows[0]["IEC_NO"].ToString();
                        txt_ImporterName2.Text = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                        txt_Importer_Undertaking.Text = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                        txt_Importer_FOR.Text = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();

                        txt_CHAName.Text = CHANAME;
                        txt_CHANo.Text = CHANO;
                        txt_CHA_Add1.Text = CHAAddr1;
                        txt_CHA_Add2.Text = CHAAddr2;
                        txt_CHA_Add3.Text = CHAAddr3;
                        txt_CHA_Add4.Text = CHAAddr4;
                        txt_CHA_Add5.Text = "";


                        btnDelete.Visible = false;
                        btnUpdate.Visible = false;
                        btnSave.Visible = true;
                        btn_Report.Visible = false;
                    }
                }
                else if (i1 == 2)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txt_ImporterName1.Text = ds.Tables[0].Rows[0]["IMPORTERNAME1"].ToString();
                        txt_ImporterAdd1.Text = ds.Tables[0].Rows[0]["IMPORTERADD1"].ToString();
                        txt_ImporterAdd2.Text = ds.Tables[0].Rows[0]["IMPORTERADD2"].ToString();
                        txt_ImporterAdd3.Text = ds.Tables[0].Rows[0]["IMPORTERADD3"].ToString();
                        txt_ImporterAdd4.Text = ds.Tables[0].Rows[0]["IMPORTERADD4"].ToString();
                        txt_ImporterAdd5.Text = ds.Tables[0].Rows[0]["IMPORTERADD5"].ToString();
                        txt_IEC_CodeNo.Text = ds.Tables[0].Rows[0]["IEC_CODE"].ToString();
                        txt_NoteNo.Text = ds.Tables[0].Rows[0]["NOTENO"].ToString();
                        txt_Note_Date.Text = ds.Tables[0].Rows[0]["NOTEDATE"].ToString();
                        txt_CHANo.Text = ds.Tables[0].Rows[0]["CHA_NO"].ToString();
                        txt_CHAName.Text = ds.Tables[0].Rows[0]["CHA_NAME"].ToString();
                        txt_CHA_Add1.Text = ds.Tables[0].Rows[0]["CHA_ADD1"].ToString();
                        txt_CHA_Add2.Text = ds.Tables[0].Rows[0]["CHA_ADD2"].ToString();
                        txt_CHA_Add3.Text = ds.Tables[0].Rows[0]["CHA_ADD3"].ToString();
                        txt_CHA_Add4.Text = ds.Tables[0].Rows[0]["CHA_ADD4"].ToString();
                        txt_CHA_Add5.Text = ds.Tables[0].Rows[0]["CHA_ADD5"].ToString();
                        txt_ImporterName2.Text = ds.Tables[0].Rows[0]["IMPORTERNAME1"].ToString();
                        txt_Consignment_NoteNo.Text = ds.Tables[0].Rows[0]["CONSIGNMENT_NOTENO"].ToString();
                        txt_Consignment_NoteDate.Text = ds.Tables[0].Rows[0]["CONSIGNMENT_NOTE_DATE"].ToString();
                        txt_Importer_Undertaking.Text = ds.Tables[0].Rows[0]["IMPORTERNAME1"].ToString();
                        txt_Importer_FOR.Text = ds.Tables[0].Rows[0]["IMPORTERNAME1"].ToString();
                        txt_Witness1.Text = ds.Tables[0].Rows[0]["WITNESS1"].ToString();
                        txt_Witness2.Text = ds.Tables[0].Rows[0]["WITNESS2"].ToString();

                        btnDelete.Visible = true;
                        btnUpdate.Visible = true;
                        btnSave.Visible = false;
                        btn_Report.Visible = true;

                    }
                }

            }
            else
            {
                Clear();
            }
        }
       

        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    public void Clear()
    {
        txt_ImporterName1.Text="";
        txt_ImporterAdd1.Text="";
        txt_ImporterAdd2.Text="";
        txt_ImporterAdd3.Text="";
        txt_ImporterAdd4.Text="";
        txt_ImporterAdd5.Text="";
        txt_IEC_CodeNo.Text="";
        txt_NoteNo.Text="";
        txt_Note_Date.Text="";
        txt_CHAName.Text="";
        txt_CHANo.Text="";
        txt_CHA_Add1.Text="";
        txt_CHA_Add2.Text="";
        txt_CHA_Add3.Text="";
        txt_CHA_Add4.Text="";
        txt_CHA_Add5.Text="";
        txt_ImporterName2.Text="";
        txt_Consignment_NoteNo.Text="";
        txt_Consignment_NoteDate.Text="";
        txt_Importer_Undertaking.Text="";
        txt_Importer_FOR.Text="";
        txt_Witness1.Text="";
        txt_Witness2.Text = "";

    }


    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'UNDERTAKING FORM', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'UNDERTAKING FORM', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

   
}