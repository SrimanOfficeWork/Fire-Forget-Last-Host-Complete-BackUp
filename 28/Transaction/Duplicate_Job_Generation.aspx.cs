using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using Microsoft.ApplicationBlocks.Data;

public partial class Transaction_Duplicate_Job_Generation : ThemeClass
{
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public int Screen_Id;
    User_Creation user_Create = new User_Creation();
    public string working_period;


    private string _Workingperiod;
    DataSet ds = new DataSet();
    public int i;

    SqlCommand cmd;
    SqlConnection con;
    SqlDataAdapter da;
    SqlDataReader dr;
    public string  DB_CONN, COMP_WORKING_PERIOD;
    public string DB_NAME;

    public string Workingperiod
    {
        get { return _Workingperiod; }
        set { _Workingperiod = value; }
    }

    public int currentrow = 0, Selected_Row = 0, Cell_Row = 0, ColumnIndex = 0;

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;

    public string JOB_LOCK, JOB_RELEASE, JOB_USER;

    Date_Time dt = new Date_Time();
    AppSession aps = new AppSession();
    Transaction Transact = new Transaction();
    CheckList chklist = new CheckList();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession_Subfolder();
            currentuser = Session["currentuser"].ToString();
            currentbranch = Session["currentbranch"].ToString();
            currentcomp_name = Session["currentcomp_name"].ToString();
            comp_ConnectionStr = Session["currentcomp_db"].ToString();

            Working_Period = Session["WorkingPeriod"].ToString();
            LoginDate = Session["LoginDate"].ToString();
            
            SELECT_BRANCH = Connection.Get_Company_Type();

            //mainmastopusernametxt.InnerText = "Welcome Mr." + currentuser;
            con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);

            if (!IsPostBack)
            {
                //----------------SETTING SCREEN PERMISSION---------------//
                Screen_Id = 9;
                Page_Rights(Screen_Id);
                //----------------SETTING SCREEN PERMISSION---------------//

                txtCurrent_Job.Attributes.Add("readonly", "readonly");
                LoadFinancialYear();

                ddlWorkingPeriod.Items.Remove(Working_Period);
                ddlWorkingPeriod.Items.Insert(0, Working_Period);

                AUTO_JOBNO();
                Load_JobNo();
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog (ex.Message);
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
            btnSearch.Enabled = false;
            btnSearch.ToolTip = "You don't have permission to access";
        }
        else
        {
            btnSearch.Enabled = true;
        }
    }

    #region FinancialYear

    public void LoadFinancialYear()
    {
        try
        {
            string com_id = Connection.Company_License();
            con.Open();
            ddlWorkingPeriod.Items.Clear();
            cmd = new SqlCommand("SELECT WORKING_PERIOD FROM DATABASE_DETAILS WHERE COMPANY_LICENSE = @CompanyLicense ORDER BY WORKING_PERIOD DESC", con);
            cmd.Parameters.AddWithValue("@CompanyLicense", com_id);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                
                ddlWorkingPeriod.Items.Add(dr["WORKING_PERIOD"].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
           
        }
        finally
        {
            con.Close();
        }
    }
 
    #endregion

    public void AUTO_JOBNO()
    {
        Transact.BRANCH_CODE = SELECT_BRANCH;
        Transact.WORKING_PERIOD = Working_Period;
        txtCurrent_Job.Text = Convert.ToString(Transact.RetrieveID());

        Admin_job_Prefix_Suffix JPS = new Admin_job_Prefix_Suffix();
        DataSet dats = new DataSet();
        JPS.Branch = SELECT_BRANCH;
        JPS.Tr_mode = Connection.Get_Tr_Mode();
        JPS.Ename = "Imp_gen_select";
        JPS.BranchType = Session["SELECT_TYPE"].ToString();
        //dats = JPS.Job_prefix_Suffix_Select();
        dats = JPS.Job_prefix_Suffix_Select_Areawise();
        if (dats.Tables[0].Rows.Count > 0)
        {
            txtjob_Prefix.Text = dats.Tables[0].Rows[0][0].ToString();
            txtjob_Suffix.Text = dats.Tables[0].Rows[0][1].ToString();
        }
        else
        {
            txtjob_Prefix.Text = string.Empty;
            txtjob_Suffix.Text = string.Empty;
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        
        if (ddlJobNo.SelectedItem.ToString() != "Select")
        {
            string Wk_per = string.Empty;
            Wk_per = ddlWorkingPeriod.SelectedItem.ToString();

            if (Wk_per == Working_Period)
            {

                DataSet ds2 = new DataSet();
                
                Transact.JOBID = "";
                Transact.JOBNO = ddlJobNo.SelectedValue.ToString();
                Transact.IMPORTER_NAME = "";
                Transact.TRANSPORT_MODE = "";
                Transact.CUSTOMS_HOUSE = "";
                Transact.Ename = "select_Id_Submission";
                Transact.WORKING_PERIOD = SELECT_BRANCH;

                ds2 = Transact.RetrieveAll_General_Details();

                JOB_LOCK = ds2.Tables[0].Rows[0]["JOB_STATUS"].ToString();
                JOB_RELEASE = ds2.Tables[0].Rows[0]["JOB_RELEASE"].ToString();
                JOB_USER = ds2.Tables[0].Rows[0]["USERID"].ToString();

                Session["JOB_LOCK"] = JOB_LOCK;
                Session["JOB_RELEASE"] = JOB_RELEASE;
                Session["JOB_USER"] = JOB_USER;



                if (Session["USER_JOB_LOCK"].ToString() == "Yes")
                {
                    if (Session["JOB_USER"] != null && Session["JOB_USER"] != "")
                    {
                        if (currentuser.ToUpper() != Session["JOB_USER"].ToString().ToUpper())
                        {
                            if (Session["JOB_RELEASE"] != null && Session["JOB_RELEASE"] != "")
                            {
                                JOB_RELEASE = Session["JOB_RELEASE"].ToString();

                                if (JOB_RELEASE == "No")
                                {
                                    btnSearch.Enabled = false;

                                    MP_U.Show();
                                    lblUser_Msg.Text = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " can't modify";
                                    //btnSearch.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                                }
                                else if (JOB_RELEASE == "Yes")
                                {
                                    jobdup("Same");
                                }

                            }
                            else
                            {
                                jobdup("Same");
                            }
                        }
                        else
                        {
                            jobdup("Same");
                        }

                    }
                    else
                    {
                        //hold
                    }

                }
                else
                {
                    jobdup("Same");
                }

            }
            else
            {
                jobdup("Diff");
            }
        }

    }


    private void jobdup(string a1)
    {

        Transact.OLD_JOBNO = ddlJobNo.SelectedValue.ToString();
        Transact.JOBNO = txtCurrent_Job.Text;
        Transact.BRANCH_CODE = "";
        Transact.USER_ID = currentuser;

        Transact.WORKING_PERIOD = SELECT_BRANCH;
        Transact.DBS_Name = HD_DB_Name.Value.ToString();
        Transact.Current_Working_Period = Working_Period;
        Transact.DB_Type = a1;
        Transact.JOB_PREFIX = txtjob_Prefix.Text;
        Transact.JOB_SUFFIX = txtjob_Suffix.Text;
        Transact.Ename = "Duplicate_Job";
        i = Transact.Generate_Duplicate_Job();
        Alert_msg("Duplicate Job Created");
        //AUTO_JOBNO();
    }


    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'JOB DUPLICATE', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'JOB DUPLICATE', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Load_JobNo()
    {
        if (Session["COMPANY_DETAILS_DS"] != null)
        {
            ds = (DataSet)Session["COMPANY_DETAILS_DS"];

            DataTable ds3 = new DataTable();
            ds3 = ds.Tables[2];
            DataView view1 = ds3.DefaultView;
            string a = ddlWorkingPeriod.SelectedValue.ToString();
            view1.RowFilter = "WORKING_PERIOD = '" + a + "'";
            DataTable table1 = view1.ToTable();
            //-----------------------------------------------------------------//
            COMP_WORKING_PERIOD = table1.Rows[0]["WORKING_PERIOD"].ToString();

            if (ddlWorkingPeriod.SelectedValue == COMP_WORKING_PERIOD)
            {
                DB_CONN = table1.Rows[0]["SERVER_NAME"].ToString();

                chklist.JOBNo = "";
                chklist.Ename = "select_jobno";
                chklist.Workingperiod = SELECT_BRANCH;
                ddlJobNo.DataSource = chklist.RetrieveAll_General_Details(DB_CONN);
                ddlJobNo.DataValueField = "JOBNO";
                ddlJobNo.DataTextField = "JOBNO_PS";
                ddlJobNo.DataBind();
                ddlJobNo.Items.Remove("0");
                ddlJobNo.Items.Insert(0, "Select");

                string[] s3,s4 = new string[] { };
             
                s3 = DB_CONN.Split(new string[] { ";" }, StringSplitOptions.None);
                a = s3[1].ToString();
                s4 = a.Split(new string[] { "=" }, StringSplitOptions.None);
                DB_NAME = s4[1].ToString();

                HD_DB_Name.Value = DB_NAME;

             }
        }
        
    }


    protected void ddlWorkingPeriod_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_JobNo();
        Admin_job_Prefix_Suffix JPS = new Admin_job_Prefix_Suffix();
        DataSet dats = new DataSet();
        JPS.Branch = SELECT_BRANCH;
        JPS.Tr_mode = Connection.Get_Tr_Mode();
        JPS.Ename = "Imp_gen_select";
        //dats = JPS.Job_prefix_Suffix_Select();
        dats = JPS.Job_prefix_Suffix_Select_Areawise();
        if (dats.Tables[0].Rows.Count > 0)
        {
            txtjob_Prefix.Text = dats.Tables[0].Rows[0][0].ToString();
            txtjob_Suffix.Text = dats.Tables[0].Rows[0][1].ToString();
        }
        else
        {
            txtjob_Prefix.Text = string.Empty;
            txtjob_Suffix.Text = string.Empty;
        }
    }
    protected void btnhide_Click(object sender, EventArgs e)
    {
        MP_U.Hide();
        btnSearch.Enabled = true;
    }
}