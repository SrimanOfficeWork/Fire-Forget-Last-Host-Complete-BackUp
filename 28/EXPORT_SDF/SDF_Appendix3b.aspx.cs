using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class SDF_Appendix3b : ThemeClass
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
        

        if (!IsPostBack)
        {
            //Load_SDF_JobNo();
            Load_JobNo();
                           
            
        }

        //btn_print.Visible = false;
        //btnSave.Visible = false;
        //btnUpdate.Visible = false;
        //btnDelete.Visible = false;
    }



    public void Load_JobNo()
    {

        DataSet ds = new DataSet();
        CheckList chklist = new CheckList();
        chklist.JOBNo = "";
        chklist.Ename = "select_jobno";
        chklist.Workingperiod = Working_Period;
        chklist.Workingperiod = SELECT_BRANCH;

        ddlJobNo.DataSource = chklist.RetrieveAll_General_Details();
        ddlJobNo.DataValueField = "JOBNO";
        ddlJobNo.DataTextField = "JOBNO";
        ddlJobNo.DataBind();
        ddlJobNo.Items.Remove("0");
        ddlJobNo.Items.Insert(0, "Select");

    }

   


    protected void ddlJobno_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void c2_Previous_Click(object sender, EventArgs e)
    {
        Response.Redirect("SDF_Appendix3.aspx");
    }
    protected void c2_Next_Click(object sender, EventArgs e)
    {
        //Response.Redirect("SDF_Appendix3c.aspx");
    }
}