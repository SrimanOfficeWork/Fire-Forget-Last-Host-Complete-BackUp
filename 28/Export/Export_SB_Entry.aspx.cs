using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using BussinessObject;

public partial class Export_General : ThemeClass
{
    AppSession aps = new AppSession();
    User_Creation user_Create = new User_Creation();
    Transaction trans = new Transaction();
    Export_General_New Export = new Export_General_New();
    SB_Entry SB = new SB_Entry();

    DataSet dtuser = new DataSet();
    
    public int i;
    
    public string currentuser,SELECT_BRANCH;
   
    Date_Time dt = new Date_Time();
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public int Screen_Id;
  
    public string JOB_LOCK, JOB_RELEASE, JOB_USER;

    
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Connection.Current_User_Upper();
        SELECT_BRANCH=Connection.Get_Company_Type();

        if (!IsPostBack)
        {
            CalendarExtender2.EndDate = DateTime.Today;
            //----------------SETTING SCREEN PERMISSION---------------//
            //Screen_Id = 11;
            //Page_Rights(Screen_Id);
            //----------------SETTING SCREEN PERMISSION---------------//
            Button_Visible();
            txtJobDate.Text = dt.Today_Date();
            txtJobNo.Attributes.Add("readonly", "readonly");
            txtJobDate.Attributes.Add("readonly", "readonly");
            txtCustomsHouse.Attributes.Add("readonly", "readonly");
            ddlTransportMode.Enabled = false;
            ddlSBType.Enabled = false;
            if (!string.IsNullOrEmpty(Request["Page"]))
            {
                string s = Request["Page"].ToString();
                if (Request["Page"] == "New")
                {
                    hdn_Jobno.Value = "";
                    Session.Remove("TRANSPORT_MODE");
                    Session.Remove("IMPORT_JOBNO");
                    Session.Remove("IMPORT_JOBDATE");
                    Session.Remove("FILING_STATUS");
                }
            }
            else
            {
                Joblock();
                Edit_GeneralDetails();
                hdfTransport_mode.Value = ddlTransportMode.SelectedValue.ToString();
            }
            if (Connection.COMPANYID() == "522" || Connection.COMPANYID() == "523" || Connection.COMPANYID() == "10")
            {
                Exp_Amt.Visible = true;
            }
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
            //---------------SAVE BUTTON------------------//
            if (PAGE_WRITE == "True")
            {
                btnSave.Enabled = true;
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
   
    private void Joblock()
    {
        if (Request.QueryString["JOBID"] != "" && Request.QueryString["JOBID"] != null)
        {
            DataSet ds2 = new DataSet();
            Export.JOBID = Request.QueryString["JOBID"].ToString();
            Export.JOBNO = "";
            Export.EXPORTER_NAME = "";
            Export.TRANSPORT_MODE = "";
            Export.CUSTOMS_HOUSE = "";
            Export.Ename = "SB_Entry";
            Export.WORKING_PERIOD = SELECT_BRANCH;
            ds2 = Export.RetrieveAll_General_Details();

            if (ds2.Tables[0].Rows.Count > 0)
            {
                JOB_LOCK = ds2.Tables[0].Rows[0]["JOB_STATUS"].ToString();
                JOB_RELEASE = ds2.Tables[0].Rows[0]["JOB_RELEASE"].ToString();
                JOB_USER = ds2.Tables[0].Rows[0]["USERID"].ToString();

                Session.Remove("JOB_LOCK");
                Session.Remove("JOB_RELEASE");
                Session.Remove("JOB_USER");

                Session["JOB_LOCK"] = JOB_LOCK;
                Session["JOB_RELEASE"] = JOB_RELEASE;
                Session["JOB_USER"] = JOB_USER;
            }
        }
    }
    public void Edit_GeneralDetails()
    {
        if (Request.QueryString["JOBID"] != "" && Request.QueryString["JOBID"] != null)
        {
            int i = 0;
            HiddenField1.Value = Request.QueryString["JOBID"].ToString();
            gridbind();

            if (SB.result == 1)
            {
                if (dtuser.Tables[0].Rows.Count > 0)
                {
                    txtJobNo.Text = dtuser.Tables[0].Rows[0]["JOBNO"].ToString();
                    txtJobDate.Text = dtuser.Tables[0].Rows[0]["JOBDATE"].ToString();
                    string mode = dtuser.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString();
                    txtCustomsHouse.Text = dtuser.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
                    ddlTransportMode.Items.Clear();
                    ddlTransportMode.Items.Add("Air");
                    ddlTransportMode.Items.Add("Sea");
                    ddlTransportMode.Items.Add("Land");
                    ddlTransportMode.Items.Remove(mode);
                    ddlTransportMode.Items.Insert(0, mode);
                    hdfTransport_mode.Value = mode;
                    string SB_type = dtuser.Tables[0].Rows[0]["SB_TYPE"].ToString();

                    ddlSBType.Items.Clear();
                    ddlSBType.Items.Add("Free Duty");
                    ddlSBType.Items.Add("License");
                    ddlSBType.Items.Add("Dutiable");
                    ddlSBType.Items.Add("Ex-Bond");
                    ddlSBType.Items.Add("Drawback");
                    ddlSBType.Items.Remove(SB_type);

                    ddlSBType.Items.Insert(0, SB_type);
                    if (dtuser.Tables[1].Rows.Count > 0)
                    {
                        txtPMV_Value.Text = dtuser.Tables[1].Rows[0]["PMV_VALUE"].ToString();
                        txtFOB_Value.Text = dtuser.Tables[1].Rows[0]["FOB_VALUE"].ToString();
                        txtDrawBack_Value.Text = dtuser.Tables[1].Rows[0]["DRAWBACK_VALUE"].ToString();
                    }
                   
                    ViewState["UPDATED_ID"] = null;
                    ViewState["UPDATED_ID"] = Request.QueryString["JOBID"].ToString();
                }
            }
            else
            {
                if (dtuser.Tables[0].Rows.Count > 0)
                {
                    txtJobNo.Text = dtuser.Tables[0].Rows[0]["JOBNO"].ToString();
                    btnUpdate.CssClass = "save";
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;

                    hdn_SB_ID.Value = dtuser.Tables[0].Rows[0]["SB_ID"].ToString();
                    txtJobDate.Text = dtuser.Tables[0].Rows[0]["JOBDATE"].ToString();
                    string mode = dtuser.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString();
                    txtCustomsHouse.Text = dtuser.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
                    ddlTransportMode.Items.Clear();
                    ddlTransportMode.Items.Add("Air");
                    ddlTransportMode.Items.Add("Sea");
                    ddlTransportMode.Items.Add("Land");
                    ddlTransportMode.Items.Remove(mode);
                    ddlTransportMode.Items.Insert(0, mode);
                    hdfTransport_mode.Value = mode;
                  
                    txtSB_no.Text = dtuser.Tables[0].Rows[0]["SB_NO"].ToString();
                    txtSB_Date.Text = dtuser.Tables[0].Rows[0]["SB_DATE"].ToString().Replace("01/01/1900","");
                    txtPMV_Value.Text = dtuser.Tables[0].Rows[0]["SB_PMV_VALUE"].ToString();
                    txtFOB_Value.Text = dtuser.Tables[0].Rows[0]["SB_FOB_VALUE"].ToString();
                    txtDrawBack_Value.Text = dtuser.Tables[0].Rows[0]["SB_DRAWBACK_VALUE"].ToString();
                    string SB_type = dtuser.Tables[0].Rows[0]["SB_TYPE"].ToString();
                    txt_Expense_Amt.Text = dtuser.Tables[0].Rows[0]["EXPENSE_AMT"].ToString();
                    
                    ddlSBType.Items.Clear();
                    ddlSBType.Items.Add("Free Duty");
                    ddlSBType.Items.Add("License");
                    ddlSBType.Items.Add("Dutiable");
                    ddlSBType.Items.Add("Ex-Bond");
                    ddlSBType.Items.Add("Drawback");
                    ddlSBType.Items.Remove(SB_type);
                    ddlSBType.Items.Insert(0, SB_type);
                    ViewState["UPDATED_ID"] = null;
                    ViewState["UPDATED_ID"] = Request.QueryString["JOBID"].ToString();
                }
            }
        }
    }
    public void Button_Visible()
    {
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnSave.Visible = true;
    }
    public DataSet gridbind()
    {
        SB.Ename = "select_Details";
        SB.WORKING_PERIOD = SELECT_BRANCH;
        SB.JOBID = HiddenField1.Value;
        dtuser = SB.RetrieveAll_SB_Entry_Details();
        return dtuser;
    }

    public int Export_SB_Entry_Insert_Update(string a1, string a2, string a3)
    {
       SB.SB_ID = a1;
       SB.SB_JOBNO = txtJobNo.Text;
       SB.SB_NO = txtSB_no.Text;
       SB.SB_DATE = txtSB_Date.Text;
       SB.SB_PMV_VALUE = txtPMV_Value.Text;
       SB.SB_FOB_VALUE = txtFOB_Value.Text;
       SB.SB_DRAWBACK_VALUE = txtDrawBack_Value.Text;
       SB.EXPENSE_AMT = txt_Expense_Amt.Text;
       
       SB.USER_ID = currentuser;
       SB.BRANCH_CODE = Connection.Current_Branch();
       SB.flag = a2;
       SB.YEAR = a3;
       SB.WORKING_PERIOD = Connection.WorkingPeriod();
       SB.BRANCH_COMMON = SELECT_BRANCH;
       i=SB.SB_Entry_Details_insertupdate();
        return i;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtJobNo.Text != "" && txtJobDate.Text != "")
        {
            try
            {
                string a1 = "";
                string a2 = "S";
                string a3 = "";
                i = Export_SB_Entry_Insert_Update(a1, a2, a3);
                HiddenField1.Value = Convert.ToString(SB.UPDATE_ID);

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
                        btnSave.Focus();
                    }

                    if (Connection.Ryal() != string.Empty)
                    {
                        Ryal_Service("S");
                    }

                    //-----------------------FOR USER RIGHTS--------------------------------//
                    ViewState["UPDATED_ID"] = null;
                    Alert_msg("Saved Successfully", "btnSave");
                }
                else if (i == 2)
                {
                    Alert_msg("Already exixts!", "btnSave");
                }
                else
                {
                    Alert_msg("Not Saved", "btnNew");
                }
            }
            catch (Exception ex)
            {
                Err_Msg(ex.Message);
            }
        }
        else
        {
            hdn_Jobno.Value = "";
            Alert_msg("Enter All Mandatory Field", "btnSave");
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (txtJobNo.Text != "" && txtJobDate.Text != "")
        {
            try
            {
                string a1 = HiddenField1.Value;
                string a2 = "U";
                string a3 = "";
                i = Export_SB_Entry_Insert_Update(a1, a2, a3);
                if (i == 1)
                {
                    
                    if (ViewState["UPDATED_ID"] != null)
                    {
                        Alert_msg("Updated Successfully", "btnUpdate");
                    }
                    else
                    {
                        Alert_msg("Saved Successfully", "btnUpdate");
                    }

                    if (Connection.Ryal() != string.Empty)
                    {
                        Ryal_Service("U");
                    }

                }
                else if (i == 2)
                {
                    Alert_msg("Already exists..!", "btnUpdate");
                }
                else
                {
                    Alert_msg("SB_Entry Not Saved", "btnUpdate");
                }
                
            }
            catch (Exception ex)
            {
                Err_Msg(ex.Message);
            }
        }
        else
        {
            hdn_Jobno.Value = "";
            Alert_msg("Enter All Mandatory Field");
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            Export.JOBNO = txtJobNo.Text;
            Export.EXPORTER_NAME = "0";
            Export.TRANSPORT_MODE = "0";
            Export.CUSTOMS_HOUSE = "0";
            Export.Ename = "delete_SB_ENTRY";
            Export.WORKING_PERIOD = SELECT_BRANCH;
            Export.RetrieveAll_General_Details();

            int ii = 0;
            ii = Export.result;

            if (ii > 0)
            {
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnSave.Visible = true;
                string prompt = "<script>$(document).ready(function(){{jAlert('Job Deleted', 'GENERAL', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            }
            else
            {
                Alert_msg("Job Not Deleted");
            }
        }
        catch (Exception ex)
        {
            Err_Msg(ex.Message);
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Transaction trans = new Transaction();
        trans.ResetFields(Page.Controls);
        Button_Visible();
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'SB_ENTRY', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'SB_ENTRY', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    private void Err_Msg(string Error)
    {
        Connection.Error_Msg(Error);
    }

    private void Ryal_Service(string flg)
    {
        DataSet dsRyal = new DataSet();
        Ryal_CS RI = new Ryal_CS();
        Global_variables ObjUBO = new Global_variables();

        ObjUBO.A1 = txtJobNo.Text;
        ObjUBO.A2 = "";
        ObjUBO.A3 = "E";
        ObjUBO.A4 = "Get_RyalRefno";
        dsRyal = RI.Ryal_Royal_Job_Update(ObjUBO);

        if ((flg == "S" || flg == "U") && dsRyal.Tables.Count > 0)
        {
            if (dsRyal.Tables[0].Rows.Count > 0)
            {
                if (Connection.COMPANYID() == "2814" || Connection.COMPANYID() == "3082" || Connection.COMPANYID() == "3153" || Connection.COMPANYID() == "3253")
                {

                    Connection.Ebms_BEno_Sbno_Return(1, dsRyal.Tables[0].Rows[0]["REF_NO"].ToString(), ObjUBO.A1, txtSB_no.Text, txtSB_Date.Text); ; ////*********IS LIVE IMPLEMENTATION********

                }
                else
                {
                    Connection.Ryal_BEno_Return(1, dsRyal.Tables[0].Rows[0]["RYAL_REF_NO"].ToString(), ObjUBO.A1, txtSB_no.Text, txtSB_Date.Text); ////*********IS LIVE IMPLEMENTATION********
                    //Connection.Ryal_BEno_Return(0, dsRyal.Tables[0].Rows[0]["RYAL_REF_NO"].ToString(), ObjUBO.A1, txtSB_no.Text, txtSB_Date.Text);    //*********IS TEST IMPLEMENTATION********
                }
            }
        }
    }
}