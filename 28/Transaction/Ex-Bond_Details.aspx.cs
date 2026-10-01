using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Import_Ex_Bond : ThemeClass
{
    DataSet dtuser = new DataSet();
    DataSet ds = new DataSet();
    Transaction Transact = new Transaction();
    BE_Entry BE = new BE_Entry();
    WareHouseReportDetails wh = new WareHouseReportDetails();
    AppSession aps = new AppSession();
    Annexure_C_Air ANNEX_C_Air = new Annexure_C_Air();
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
    public string Nature_Cargo;
    public string EXPORT_JOBNO;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public string SELECT_TYPE, SELECT_BRANCH, BE_TYPE;
    public int Screen_Id;
    public string JOB_LOCK, JOB_RELEASE;
    User_Creation user_Create = new User_Creation();
    string Gridview_jobno="",Str_New_update="";
    public string COMPANY_IDD;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        Screen_Id = 7;
        Page_Rights(Screen_Id);
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

        if (Session["BE_TYPE"] != null && Session["BE_TYPE"] != "")
        {
            Hdn_BE_TYPE.Value = Session["BE_TYPE"].ToString();
        }
        
        COMPANY_IDD = Connection.COMPANYID();
        
        SELECT_BRANCH = Connection.Get_Company_Type();
        HDBranch.Value = SELECT_BRANCH;
        txtExbond_BENo.Focus();

        if (!IsPostBack)
        {        
            Load_Wrk("", "Load_Wrk_Db");
            Edit_GeneralDetails();
            gridbind_Warehouse();
            Load_Wh_Job_Details();// // Added by pandiyan on 27-06-2025 for warehouse details taken from the to exbond jobs
        }

        txt_Jobno.Attributes.Add("onblur", "javascript:CallServerside_Report_NotifyName('" + txt_Jobno.ClientID + "', '" + SELECT_BRANCH + "')");

        if (Session["JOB_LOCK"] != null && Session["JOB_LOCK"] != "")
        {
            JOB_LOCK = Session["JOB_LOCK"].ToString();

            if (Convert.ToInt32(JOB_LOCK) == 1)
            {
                btnUpdate.Enabled = false;
                btnSave.Enabled = false;
                btnDelete.Visible = false;
                               
                btnSave.ToolTip = "This Job is Locked by Admin";
                btnUpdate.ToolTip = "This Job is Locked by Admin";
               
            }
        }

        if (Session["USER_JOB_LOCK"].ToString() == "Yes")
        {
            if (currentuser.ToUpper() !=Convert.ToString(Session["JOB_USER"].ToString().ToUpper()))
            {
                if (Session["JOB_RELEASE"] != null && Session["JOB_RELEASE"] != "")
                {
                    JOB_RELEASE = Session["JOB_RELEASE"].ToString();

                    if (JOB_RELEASE == "No")
                    {

                        btnUpdate.Enabled = false;
                        btn_warehose.Enabled = false;
                        btn_exbond.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Visible = false;

                        MP_U.Show();
                        lblUser_Msg.Text = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";

                        btnUpdate.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                        btn_warehose.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                        btn_exbond.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                        btnSave.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                    }
                }
            }
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
            btnDelete.Visible = false;
        }
        else
        {
            //---------------SAVE BUTTON------------------//
            if (PAGE_WRITE == "True")
            {
                btnSave.Enabled = true;
                btnDelete.Visible = false;
            }
            else
            {
                btnSave.Enabled = false;
                btnSave.ToolTip = "You don't have permission to access";
            }
            //---------------UPDATE BUTTON------------------//

            if (PAGE_MODIFY == "True")
                btnUpdate.Enabled = true;
               
            else
            {
                btnUpdate.Enabled = false;
                btnDelete.Visible = false;
                btnUpdate.ToolTip = "You don't have permission to access";

            }
            //---------------DELETE BUTTON------------------//

            if (PAGE_DELETE == "True")
            {
                btnDelete.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
                btnDelete.ToolTip = "You don't have permission to access";
            }
        }
    }
    private string Database_Name()
    {
        DataSet ds = new DataSet();
        DataSet dss = new DataSet();
        string DB_Name = string.Empty;
        if (Session["COMPANY_DETAILS_DS"] != null)
        {
            ds = (DataSet)Session["COMPANY_DETAILS_DS"];

            DataTable ds3 = new DataTable();
            ds3 = ds.Tables[2];
            DataView view1 = ds3.DefaultView;
            string a = Session["Wkp"].ToString();
            view1.RowFilter = "WORKING_PERIOD = '" + a + "'";
            DataTable table1 = view1.ToTable();
            //-----------------------------------------------------------------//
            string str = table1.Rows[0]["SERVER_NAME"].ToString();
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };
            string b = string.Empty;

            arr = str.Split(';');
            b = arr[1].ToString();
            arr2 = b.Split('=');
            DB_Name = arr2[1].ToString();
        }
        return DB_Name;
    }
    public void Load_Wh_Job_Details() 
    {
        if(Session["WAREHOUSE_JOBNO"]!=null && Session["WAREHOUSE_JOBNO"]!="")
        {
            Transact.WAREHOUSE_JOBNO = Session["WAREHOUSE_JOBNO"].ToString();
            Transact.BRANCH_CODE = currentbranch;
            Transact.Current_Working_Period = Working_Period;
            Transact.JOBNO = Session["Job_PS"].ToString();
            if (Session["Wkp"] != null && Session["Wkp"] != "")
            {
                if (Session["Wkp"] != Working_Period)
                {
                    Transact.Ename = "Old_Wkp_Wh_Job_Details";
                    Transact.DB_NAME = Database_Name();
                    Transact.WORKING_PERIOD = Session["Wkp"].ToString();
                }
            }
            else
            {
                Transact.Ename = "Wh_Job_Details";
            }
            ds = Transact.RetrieveAll_Wh_Job_Details();

            if (ds.Tables[0].Rows.Count > 0)
            {
                string beNo = ds.Tables[0].Rows[0]["BE_NO"].ToString();
                string beDate = ds.Tables[0].Rows[0]["BE_DATE"].ToString();

                txtExbond_BENo.Text = beNo;
                txtExbond_BEDate.Text = beDate;

                // store original values
                hdn_BE_No.Value = beNo;
                hdn_BE_Date.Value = beDate;
                txtExbond_Warehouse_Customs.Text = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
                txtExbond_Warehouse_Code.Text = ds.Tables[0].Rows[0]["WAREHOUSE_CODE"].ToString();
                txtExbond_NoofPackages.Text = ds.Tables[0].Rows[0]["IGM_NOOFPACKAGE"].ToString();
                txtExbond_NoofPackages_Code.Text = ds.Tables[0].Rows[0]["IGM_PACKAGETYPE"].ToString();
                txtExbond_Gross_Weight.Text = ds.Tables[0].Rows[0]["IGM_GROSSWEIGHT"].ToString();
                txtExbond_Gross_Weight_Code.Text = ds.Tables[0].Rows[0]["IGM_TYPEOFWEIGHT"].ToString();
            }
        }

        //Session.Remove("WAREHOUSE_JOBNO");
    
    }
    public void Get_Remaining_NoPKgs()
    {
        if (Session["EXBND_JOBID"] != "" && Session["EXBND_JOBID"] != null)
        {
            hdn_EXBND_JOBID.Value = "";
            hdn_EXBND_JOBID.Value = Session["EXBND_JOBID"].ToString();
        }
        BE.BE_ID = hdn_EXBND_JOBID.Value;
        BE.Ename = "Get_Warehouse_JOBNO_from_Exbond";
        BE.WORKING_PERIOD = SELECT_BRANCH;
        ds = BE.RetrieveAll_BE_Entry_Details();

        if (ds.Tables[1].Rows.Count > 0)
        {
            txtExbond_NoofPackages.Text = ds.Tables[1].Rows[0]["EXBOND_NOOFPACKAGE"].ToString();
            txtExbond_Gross_Weight.Text = ds.Tables[1].Rows[0]["EXBOND_GROSS_WEIGHT"].ToString();

            txtExbond_NoofPackages_Code.Text = ds.Tables[1].Rows[0]["IGM_PACKAGETYPE"].ToString();
            txtExbond_Gross_Weight_Code.Text = ds.Tables[1].Rows[0]["IGM_TYPEOFWEIGHT"].ToString();

        }
    }

    public void gridbind_Warehouse()
    {
        BE.Ename = "select_Warehouse";
        BE.WORKING_PERIOD = SELECT_BRANCH;
        gv_Details.DataSource = BE.RetrieveAll_BE_Entry_Details();
        gv_Details.DataBind();
    }

    public DataSet gridbind()
    {
        Transact.JOBID = hdn_EXBND_JOBID.Value;
        Transact.JOBNO = "";
        Transact.IMPORTER_NAME = "";
        Transact.TRANSPORT_MODE = "";
        Transact.CUSTOMS_HOUSE = "";
        Transact.Ename = "Exbond_select_Id";
        Transact.WORKING_PERIOD = SELECT_BRANCH;
        dtuser = Transact.RetrieveAll_General_Details();
        return dtuser;
    }

    public void Edit_GeneralDetails()
    {
        //chkDirect_Exbonding.Enabled = false;

        if (Session["EXBND_JOBID"] != "" && Session["EXBND_JOBID"] != null)
        {
            hdn_EXBND_JOBID.Value = "";
            hdn_EXBND_JOBID.Value = Session["EXBND_JOBID"].ToString();

            gridbind();
            if (dtuser.Tables[0].Rows.Count > 0)
            {
                if (dtuser.Tables[0].Rows[0]["EXBOND_NOOFPACKAGE"].ToString() != "")
                {
                    txtExbond_BENo.Text = dtuser.Tables[0].Rows[0]["EXBOND_INBOND_BE_NO"].ToString();
                    txtExbond_BEDate.Text = dtuser.Tables[0].Rows[0]["EXBOND_INBOND_BE_DATE"].ToString();
                    txtExbond_BondNo.Text = dtuser.Tables[0].Rows[0]["EXBOND_BOND_NO"].ToString();
                    txtExbond_BondDate.Text = dtuser.Tables[0].Rows[0]["EXBOND_BOND_DATE"].ToString();
                    txtExbond_Warehouse_Customs.Text = dtuser.Tables[0].Rows[0]["EXBOND_WAREHOUSE_CUSTOMS"].ToString();
                    txtExbond_Warehouse_Code.Text = dtuser.Tables[0].Rows[0]["EXBOND_WAREHOUSE_CUSTOMS_CODE"].ToString();
                    txtExbond_NoofPackages.Text = dtuser.Tables[0].Rows[0]["EXBOND_NOOFPACKAGE"].ToString();
                    txtExbond_NoofPackages_Code.Text = dtuser.Tables[0].Rows[0]["EXBOND_NOOFPACKAGE_UNITCODE"].ToString();
                    txtExbond_Gross_Weight.Text = dtuser.Tables[0].Rows[0]["EXBOND_GROSS_WEIGHT"].ToString();
                    txtExbond_Gross_Weight_Code.Text = dtuser.Tables[0].Rows[0]["EXBOND_GROSS_WEIGHT_UNITCODE"].ToString();
                    hdn_Direct_Exbonding.Value = dtuser.Tables[0].Rows[0]["EXBOND_DIRECT_EXBONDING"].ToString();
                    if (hdn_Direct_Exbonding.Value == "Y")
                    {
                        chkDirect_Exbonding.Checked = true;
                        Session["EXBOND_DIRECT_EXBONDING"] = "Y";
                    }
                    Session["IMPORT_JOBNO"] = dtuser.Tables[0].Rows[0]["JOBNO"].ToString();
                    Str_New_update = "EX_BOND_UPDATE";
                    Hdn_No_pkgs.Value = txtExbond_NoofPackages.Text;

                    txtAddl_Load_HSS.Text = dtuser.Tables[0].Rows[0]["EXBOND_ADDL_LOAD_HSS"].ToString();
                    txtMisc_Load_Rate.Text = dtuser.Tables[0].Rows[0]["EXBOND_MISC_LOAD_RATE"].ToString();
                    btnDelete.Visible = true;
                }
                else
                {
                    if (COMPANY_IDD == "268" || COMPANY_IDD == "10")
                    {
                        Get_Remaining_NoPKgs();
                    }
                    btnDelete.Visible = false;
                }

                if (dtuser.Tables[0].Rows[0]["WAREHOUSE_NAME"].ToString() == "Yes")
                {

                    chkDirect_Exbonding.Checked = false;
                    chkDirect_Exbonding.Enabled = false;
                    btn_warehose.Style.Add("display", "Block");
                    btn_exbond.Style.Add("display", "none");
                }

                else if (dtuser.Tables[0].Rows[0]["WAREHOUSE_NAME"].ToString() == "No" || dtuser.Tables[0].Rows[0]["WAREHOUSE_NAME"].ToString() == "")
                {

                    //chkDirect_Exbonding.Checked = true;
                    btn_warehose.Style.Add("display", "none");
                    btn_exbond.Style.Add("display", "Block");
                }
                if (txtExbond_BEDate.Text == "01/01/1900")
                {
                    txtExbond_BEDate.Text = "";
                }
                if (txtExbond_BondDate.Text == "01/01/1900")
                {
                    txtExbond_BondDate.Text = "";
                }
            }

            if (txtExbond_NoofPackages.Text != "")
            {
                btnUpdate.CssClass = "updates";
                hdn_find_exists_jobno.Value = "1";
            }
            else
            {
                hdn_find_exists_jobno.Value = "";
                btnUpdate.CssClass = "save";
            }
            btnUpdate.Visible = true;
            //btnDelete.Visible = true;
            btnSave.Visible = false;

        }
        else
        {
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
        }
    }

    public int insert_update(string jobno, string flag)
    {

        Transact.JOBID = "";
        Transact.JOBNO = jobno;
        Transact.JOBDATE = "01/01/1900";
        Transact.BE_TYPE = "Ex-Bond";
        Transact.BRANCH_NO = "0";
        Transact.HIGH_SEA_IEC = "0";
        Transact.HIGH_SEA_BRANCH_SL_NO = "0";
        string Exbond_BEDate = "", Exbond_BondDate = "";
        if (txtExbond_BEDate.Text != "")
        {
            Exbond_BEDate = txtExbond_BEDate.Text;
        }
        else
        {
            Exbond_BEDate = "01/01/1900";
        }
        if (txtExbond_BondDate.Text != "")
        {
            Exbond_BondDate = txtExbond_BondDate.Text;
        }
        else
        {
            Exbond_BondDate = "01/01/1900";
        }

        Transact.EXBOND_INBOND_BE_NO = txtExbond_BENo.Text;
        Transact.EXBOND_INBOND_BE_DATE = Exbond_BEDate;
        Transact.EXBOND_BOND_NO = txtExbond_BondNo.Text;
        Transact.EXBOND_BOND_DATE = Exbond_BondDate;
        Transact.EXBOND_WAREHOUSE_CUSTOMS = txtExbond_Warehouse_Customs.Text;
        Transact.EXBOND_WAREHOUSE_CUSTOMS_CODE = txtExbond_Warehouse_Code.Text;
        Transact.EXBOND_NOOFPACKAGE = txtExbond_NoofPackages.Text;
        Transact.EXBOND_NOOFPACKAGE_UNITCODE = txtExbond_NoofPackages_Code.Text;
        Transact.EXBOND_GROSS_WEIGHT = txtExbond_Gross_Weight.Text;
        Transact.EXBOND_GROSS_WEIGHT_UNITCODE = txtExbond_Gross_Weight_Code.Text;

        if (chkDirect_Exbonding.Checked == true)
        {
            hdn_Direct_Exbonding.Value = "Y";
            Session["EXBOND_DIRECT_EXBONDING"] = "Y";
        }
        else
        {
            hdn_Direct_Exbonding.Value = "";
            Session["EXBOND_DIRECT_EXBONDING"] = "";
        }
        Transact.EXBOND_DIRECT_EXBONDING = hdn_Direct_Exbonding.Value;
        Transact.EXBOND_ADDL_LOAD_HSS = txtAddl_Load_HSS.Text;
        Transact.EXBOND_MISC_LOAD_RATE = txtMisc_Load_Rate.Text;
        Transact.USER_ID = currentuser;

        if (Session["Job_PS"] != null  && Session["Job_PS"] !=string.Empty )
        {
            Transact.JOBNO_PS = Session["Job_PS"].ToString();
        }
        else
        {
            Transact.JOBNO_PS = string.Empty;
        }

        Transact.flag = flag;
        Transact.BRANCH_CODE = currentbranch;
        Transact.WORKING_PERIOD = Working_Period;
        Transact.BRANCH_COMMON = SELECT_BRANCH;
        i = Transact.General_details_insertupdate();
        return i;
    }
    protected void gv_Details_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["BE_ID"] = Convert.ToString(this.gv_Details.SelectedDataKey.Value);
        if (ViewState["BE_ID"] != "" && ViewState["BE_ID"] != null)
        {
            txtExbond_BENo.Text = gv_Details.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            txtExbond_BEDate.Text = gv_Details.SelectedRow.Cells[2].Text.Replace("01/01/1900", "");
            txtExbond_BondNo.Text = gv_Details.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            txtExbond_BondDate.Text = gv_Details.SelectedRow.Cells[4].Text.Replace("01/01/1900", "");
            txtExbond_Warehouse_Customs.Text = gv_Details.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            txtExbond_Warehouse_Code.Text = gv_Details.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
            Gridview_jobno = "WAREHOUSE_JOBNO";
        }
    }
    protected void gv_Details_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_Details.PageIndex = e.NewPageIndex;
    }
    protected void gv_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_Details, "Select$" + e.Row.RowIndex.ToString()));
        }
    }
    protected void gv_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'EX-BOND', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'EX-BOND', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
                string f = "EX_BOND_UPDATE";
                i = insert_update(hdn_EXBND_JOBID.Value, f);

                if (i == 1)
                {
                    txtExbond_BENo.Focus();
                    btnDelete.Visible = true;
                    if (hdn_find_exists_jobno.Value != "")
                    {
                        Alert_msg("Updated Successfully", "btnUpdate");
                    }
                    else
                        Alert_msg("Saved Successfully", "btnUpdate");
                }
                else if (i ==5)
                {
                    Alert_msg("Invalid WareHouse Code", "txtExbond_Warehouse_Code");
                }
                else
                {
                    Alert_msg("Ex-Bond Not Saved", "btnUpdate");
                }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataSet ds_job = new DataSet();
        Transact.JOBNO = txt_Jobno.Text;
        Transact.JOBID = txt_Beno.Text;
        Transact.BRANCH_CODE = SELECT_BRANCH;
        Transact.WORKING_PERIOD = SELECT_BRANCH;

        if (txt_Jobno.Text != "" || txt_Beno.Text != "")
        {
            if (txt_Jobno.Text != "" && txt_Beno.Text != "")
            {
                Transact.Ename = "Select_JobNo_Beno_Exbond";
            }
            else if (txt_Jobno.Text != "")
            {
                Transact.Ename = "Select_JobNo_Exbond";
            }
            else if (txt_Beno.Text != "")
            {
                Transact.Ename = "Select_BeNo_Exbond";
            }

            if (ddlWorkingPeriod.SelectedValue.ToString() == Connection.WorkingPeriod())
            {
                ds_job = Transact.RetrieveAll_General_Details();
            }
            else
            {
                DataSet dsr=new DataSet();
                dsr = wh.Get_Login_Details(ddlWorkingPeriod.SelectedValue.ToString(), "DB_Con_String");
                if (dsr.Tables[0].Rows.Count > 0)
                {
                    ds_job = Transact.RetrieveAll_General_Details(dsr.Tables[0].Rows[0][0].ToString());
                }
                
            }

            gv_Details.DataSource = ds_job;
            gv_Details.DataBind();

        }
        else
        {
            gridbind_Warehouse();
        }          
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            Transact.JOBNO = hdn_EXBND_JOBID.Value;
            Transact.IMPORTER_NAME = "0";
            Transact.TRANSPORT_MODE = "0";
            Transact.CUSTOMS_HOUSE = "0";
            Transact.Ename = "Delete_Exbond_Details";
            Transact.WORKING_PERIOD = SELECT_BRANCH;
            Transact.RetrieveAll_General_Details();

            int ii = 0;
            ii = Transact.result;

            if (ii > 0)
            {
                //Elogix_Service("D");
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnSave.Visible = true;

                string prompt = "<script>$(document).ready(function(){{jAlert('Exbond Details Deleted', 'EX-BOND', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);

                Clear();
            }
            else
            {
                Alert_msg("Exbond Entry not Deleted");
            }
            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
   

    private void Clear()
    {
        txtExbond_BENo.Text = "";
        txtExbond_BEDate.Text = "";
        txtExbond_BondNo.Text = "";
        txtExbond_BondDate.Text = "";
        txtExbond_Warehouse_Customs.Text = "";
        txtExbond_Warehouse_Code.Text = "";
        txtExbond_NoofPackages.Text = "";
        txtExbond_NoofPackages_Code.Text = "";
        txtExbond_Gross_Weight.Text = "";
        txtExbond_Gross_Weight_Code.Text = "";
        txtAddl_Load_HSS.Text = "";
        txtMisc_Load_Rate.Text = "";
    }
    protected void ddlWorkingPeriod_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet s = new DataSet();
        DataSet ss = new DataSet();
        DataTable dt = new DataTable();
        if (ddlWorkingPeriod.SelectedValue.ToString() != string.Empty)
        {
            s = wh.Get_Login_Details(ddlWorkingPeriod.SelectedValue.ToString(), "DB_Con_String");

            if (s.Tables[0].Rows.Count > 0)
            {
                BE.Ename = "select_Warehouse";
                BE.WORKING_PERIOD = SELECT_BRANCH;
                ss = BE.RetrieveAll_BE_Entry_Details(s.Tables[0].Rows[0][0].ToString());
                if (ss.Tables[0].Rows.Count > 0)
                {
                    gv_Details.DataSource = ss.Tables[0];
                    gv_Details.DataBind();
                }
                else
                {
                    gv_Details.DataSource = dt;
                    gv_Details.DataBind();
                }
            }
            else
            {
                gv_Details.DataSource = dt;
                gv_Details.DataBind();
            }

        }
        else {
            gv_Details.DataSource = dt;
            gv_Details.DataBind();
        }
        
    }
    private void Load_Wrk(string Wrk,string Flag)
    {
        DataSet ds = new DataSet();
        ddlWorkingPeriod.Items.Clear();
        ds=wh.Get_Login_Details(Wrk, Flag);

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlWorkingPeriod.DataSource = ds.Tables[0];
            ddlWorkingPeriod.DataTextField = "WORKING_PERIOD";
            ddlWorkingPeriod.DataValueField = "WORKING_PERIOD";
            ddlWorkingPeriod.DataBind();
        }
        ddlWorkingPeriod.SelectedValue = Connection.WorkingPeriod();
    }

}