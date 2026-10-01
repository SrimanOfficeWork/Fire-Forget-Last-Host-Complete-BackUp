using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class SDF_Appendix7 : ThemeClass
{
    public int currentPageNumber, i;
    public double totalRows;
    public const int PAGESIZE = 0;
    public int pageno = 0;
    SqlConnection con;
    User_Creation user_Create = new User_Creation();
    DataTable dt = new DataTable();
    DataSet dtuser = new DataSet();
    DataSet dss = new DataSet();
    DataSet ds = new DataSet();
    
    SDF_FORMAT SDF = new SDF_FORMAT();
    NForm NForm = new NForm();
    AppSession aps = new AppSession();
    Date_Time date = new Date_Time();
    //SqlDataReader dr = new SqlDataReader();
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, Name_Search, userid, user_database, branch_cd, compantname, F = "";
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public string SELECT_TYPE, SELECT_BRANCH;
    public int Screen_Id;
    ErrorLogs er = new ErrorLogs();
    Date_Time dta = new Date_Time();
    public string FORM_ID = "";

    public string CHAAddr1, CHAAddr2, CHAAddr3;
    public string ImpAdd1;
    public string TextBoxName1, TextBoxName2, TextBoxName3, TextBoxName4;
    public string assbl, duty;
    public int assblval = 0, dutyval = 0;
    public double assblval1, dutyval1, summ;
    public string cal_assbl, cal_duty;
    public double val_assbl, val_duty, calculate;
    string equal = "=";
    //public Date_Time current_date;
    string current_date = DateTime.Now.ToString("dd/mm/yyyy");



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

        CHAAddr1 = HttpContext.Current.Session["CHA_NAME"].ToString();
        CHAAddr2 = HttpContext.Current.Session["CHA_ADDRESS"].ToString();
        CHAAddr3 = HttpContext.Current.Session["CHA_ADDRESS1"].ToString();

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
            Load_SDF_JobNo();
            ddlJobNo.Focus();             
            
        }

        btnSend.Visible = false;
        btnSave.Visible = false;
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
    }

  

    public void Load_SDF_JobNo()
    {
        SDF.SDF_JOBNO = "";
        //SDF.Ename = "Get_SDF";
        SDF.Ename = "Load_Jobno";
        SDF.SDF_TYPE = "";
        SDF.SDF_BRANCHCODE = SELECT_BRANCH;

        ds = SDF.RetrieveAll_General_Details();

        ddlJobNo.DataSource = ds.Tables[0];
        ddlJobNo.DataValueField = "JOBNO";
        ddlJobNo.DataTextField = "JOBNO";
        ddlJobNo.DataBind();
        ddlJobNo.Items.Remove("0");
        ddlJobNo.Items.Insert(0, "Select");
    
    }

   

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Insert_Update();
            Alert_msg("Saved SuccessFully");
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnSend.Visible = true;
            btnDelete.Visible = true;

        }
        catch (SqlException ex)
        {
            er.makeLog(ex.Message);
        }

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            Insert_Update();
            Alert_msg("Updated SuccessFully");
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnSend.Visible = true;
            btnDelete.Visible = true;
        }
        catch (SqlException ex)
        {
            er.makeLog(ex.Message);
        }

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        SDF.SDF_JOBNO = ddlJobNo.SelectedItem.Text;
        SDF.SDF_BRANCHCODE = SELECT_BRANCH;
        SDF.SDF_TYPE = "APPENDIX_7";
        SDF.Ename = "Delete";

        SDF.Retrive_SDF_Appendix();
        i = SDF.result;

        if (i > 0)
        {
            string prompt = "<script>$(document).ready(function(){{jAlert('SDF APPENDIX VII Deleted', 'SDF APPENDIX-VII', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
        }
        else
        {
            Alert_msg("SDF APPENDIX-VII Not Deleted");
        }
        Clear();
        Load_SDF_JobNo();
    }   

    public int Insert_Update()
    {
        try
        {
            Hdn_ddlJobNo.Value = ddlJobNo.SelectedItem.Text;
            SDF.ID = Hdn_ddlJobNo.Value;
            SDF.SDF_JOBNO = Hdn_ddlJobNo.Value;
            SDF.SDF_SBNO = txt_SBNo.Text;
            SDF.SDF_SBDATE = txt_SBDate.Text;
            SDF.SDF_EXPORTERNAME= txt_NameOfExporter.Text;
            SDF.SDF_FOR = txt_For.Text;
            SDF.EXPORTER_NAME = txt_Exporter.Text;
            SDF.EX_ADDRESS1 = txt_Address1.Text;
            SDF.EX_ADDRESS2 = txt_Address2.Text;
            SDF.EX_ADDRESS3 = txt_Address3.Text;
            SDF.EX_ADDRESS4 = txt_Address4.Text;
            //SDF.SDF_CAUTIONDATE = txt_Date.Text;
         
       
            SDF.SDF_TYPE = "APPENDIX_7";

            SDF.SDF_BRANCHCODE = currentbranch;
            SDF.SDF_YEAR = "YEAR";
            SDF.SDF_USERID = currentuser;
            SDF.SDF_LOGINDATE = LoginDate;

            SDF.Ename = "S";
            SDF.SDF_WORKINGPERIOD = Working_Period;
            SDF.SDF_BRANCH_COMMON = SELECT_BRANCH;

            i = SDF.SDF_Insert_Update();
           
        }
        catch (SqlException ex)
        {
            er.makeLog(ex.Message);
        }
        return i;
    }

    protected void btn_print_Click(object sender, EventArgs e)
    {
        string ec = "<script>$(document).ready(function(){{return PrintGridData();}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", ec, false);
    }

    protected void ddlJobno_SelectedIndexChanged(object sender, EventArgs e)
    {
        Clear();
        SDF.SDF_JOBNO = ddlJobNo.SelectedItem.Text;
        SDF.SDF_TYPE = "APPENDIX_7";
        Session["SDF_TYPE"] = SDF.SDF_TYPE;
        SDF.SDF_WORKINGPERIOD = Working_Period;
        SDF.SDF_BRANCHCODE = SELECT_BRANCH;
        SDF.Ename = "Get_SDF";

        ds = SDF.Retrive_SDF_Appendix();

        int ii = SDF.result;

        if (ii == 1)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                txt_SBNo.Text = ds.Tables[0].Rows[0]["SB_NO"].ToString();
                txt_SBDate.Text = ds.Tables[0].Rows[0]["SB_DATE"].ToString();

                txt_NameOfExporter.Text = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                txt_For.Text = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                txt_Exporter.Text = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                txt_Address1.Text = ds.Tables[0].Rows[0]["ADDRESS1"].ToString();
                txt_Address2.Text = ds.Tables[0].Rows[0]["ADDRESS2"].ToString();
                txt_Address3.Text = ds.Tables[0].Rows[0]["ADDRESS3"].ToString();
                txt_Address4.Text = ds.Tables[0].Rows[0]["ADDRESS4"].ToString();

            }

            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnSend.Visible = false;
            btnDelete.Visible = false;
        }
        if(ii==2)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                txt_SBNo.Text = ds.Tables[0].Rows[0]["SDF_SBNO"].ToString();
                txt_SBDate.Text = ds.Tables[0].Rows[0]["SDF_SBDATE"].ToString();
                txt_NameOfExporter.Text = ds.Tables[0].Rows[0]["SDF_EXPORTERNAME"].ToString();
                txt_For.Text = ds.Tables[0].Rows[0]["SDF_FOR"].ToString();
                txt_Exporter.Text = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                txt_Address1.Text = ds.Tables[0].Rows[0]["EX_ADDRESS1"].ToString();
                txt_Address2.Text = ds.Tables[0].Rows[0]["EX_ADDRESS2"].ToString();
                txt_Address3.Text = ds.Tables[0].Rows[0]["EX_ADDRESS3"].ToString();
                txt_Address4.Text = ds.Tables[0].Rows[0]["EX_ADDRESS4"].ToString();
                //txt_Date.Text = ds.Tables[0].Rows[0]["SDF_CAUTIONDATE"].ToString();
             
         
            }
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnSend.Visible = true;
            btnDelete.Visible = true;
        }
       
    }

    public void Clear()
    {
        txt_SBNo.Text="";
        txt_SBDate.Text="";
        txt_NameOfExporter.Text="";    
        //txt_Date.Text = "";
        txt_For.Text="";
        txt_Exporter.Text="";
        txt_Address1.Text="";
        txt_Address2.Text="";
        txt_Address3.Text="";
        txt_Address4.Text="";
       
      

    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'SDF APPENDIX VII', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'SDF APPENDIX VII', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
 
}