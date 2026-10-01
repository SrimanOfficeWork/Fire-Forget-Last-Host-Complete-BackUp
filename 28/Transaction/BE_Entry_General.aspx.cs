using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI;
using BussinessObject;

public partial class Export_General : ThemeClass
{
    DataSet dtuser = new DataSet();
    AppSession aps = new AppSession();
    BE_Entry BE = new BE_Entry(); 

    
    public int i;

    Date_Time dt = new Date_Time();
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id, COMPANY_ID = "";
    public string JOB_LOCK, JOB_RELEASE, JOB_USER;
    public int Screen_Id;
    User_Creation user_Create = new User_Creation();

    

    protected void Page_Load(object sender, EventArgs e)
    {
        txtCustomsHouse.Focus();
        aps.checkSession();
        COMPANY_ID = Session["COMPANY_ID"].ToString();
        txtJobDate.Text = dt.Today_Date();

        txtJobDate.Focus();

        if (COMPANY_ID == "10" || COMPANY_ID == "151")
        {
            fieldset_Fairmacs.Visible = true;
        }

        if (!IsPostBack)
        {
            CalendarExtender2.EndDate = DateTime.Today;
            //----------------SETTING SCREEN PERMISSION---------------//
            Screen_Id =11;
            Page_Rights(Screen_Id);
            //----------------SETTING SCREEN PERMISSION---------------//
            Button_Visible();
            txtJobDate.Text = dt.Today_Date();
            txtJobNo.Attributes.Add("readonly", "readonly");
            txtJobDate.Attributes.Add("readonly", "readonly");
            txtCustomsHouse.Attributes.Add("readonly", "readonly");
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
                Joblock_chk();
                Edit_GeneralDetails();
                hdfTransport_mode.Value = ddlTransportMode.SelectedValue.ToString();
            }
            if(Connection.COMPANYID()=="522" || Connection.COMPANYID()=="523")
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
                btnSave.Enabled = false;

                btnSave.ToolTip = "This Job is Locked by Admin";
                btnUpdate.ToolTip = "This Job is Locked by Admin";
                btnDelete.ToolTip = "This Job is Locked by Admin";
            }
        }

        if (Session["USER_JOB_LOCK"].ToString() == "Yes")
        {
            if (Connection.Current_User().ToUpper() != Session["JOB_USER"].ToString().ToUpper())
            {
                if (Session["JOB_RELEASE"] != null && Session["JOB_RELEASE"] != "")
                {
                    JOB_RELEASE = Session["JOB_RELEASE"].ToString();

                    if (JOB_RELEASE == "No")
                    {

                        btnUpdate.Enabled = false;
                        btnDelete.Enabled = false;
                        btnSave.Enabled = false;

                        MP_U.Show();

                        lblUser_Msg.Text = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";

                        btnUpdate.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                        btnDelete.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                        btnSave.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";

                    }
                }
            }
        }   
    }

    private void Joblock_chk()
    {
        if (Request.QueryString["JOBID"] != "" && Request.QueryString["JOBID"] != null)
        {
            DataSet ds2 = new DataSet();
            Transaction Transact = new Transaction();
            Transact.JOBID = "";
            Transact.JOBNO = Request.QueryString["JOBID"].ToString();
            Transact.IMPORTER_NAME = "";
            Transact.TRANSPORT_MODE = "";
            Transact.CUSTOMS_HOUSE = "";
            Transact.Ename = "select_Id_Submission";
            Transact.WORKING_PERIOD = Connection.Get_Company_Type();

            ds2 = Transact.RetrieveAll_General_Details();

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

    

    public void Edit_GeneralDetails()
    {
        if (Request.QueryString["JOBID"] != "" && Request.QueryString["JOBID"] != null)
        {

            HiddenField1.Value = Request.QueryString["JOBID"].ToString();
            gridbind();

            if (BE.result == 1)
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

                    txtNo_Packages.Text = dtuser.Tables[0].Rows[0]["IGM_NOOFPACKAGE"].ToString();
                    hdn_PackType.Value = dtuser.Tables[0].Rows[0]["IGM_PACKAGETYPE"].ToString();

                    txtWeight.Text = dtuser.Tables[0].Rows[0]["IGM_GROSSWEIGHT"].ToString();
                    hdn_WeightType.Value = dtuser.Tables[0].Rows[0]["IGM_TYPEOFWEIGHT"].ToString();
                    if (dtuser.Tables[1].Rows.Count > 0)
                    {
                        txtAssessableValue.Text = dtuser.Tables[1].Rows[0]["ASSESSABLE_VALUE"].ToString();
                        txtDutyValue.Text = dtuser.Tables[1].Rows[0]["DUTY_VALUE"].ToString();

                    }
                    string BE_type = dtuser.Tables[0].Rows[0]["BE_TYPE"].ToString();


                    ddlBEType.Items.Clear();
                    ddlBEType.Items.Add("Home");
                    ddlBEType.Items.Add("Warehouse");
                    ddlBEType.Items.Add("Ex-Bond");
                    ddlBEType.Items.Remove(BE_type);

                    ddlBEType.Items.Insert(0, BE_type);

                    if (BE_type == "Home")
                    {
                        warehouse1.Style.Add("display", "none");
                    }
                    else if (BE_type == "Warehouse")
                    {
                        warehouse1.Style.Add("display", "block");
                    }
                    else if (BE_type == "Ex-Bond")
                    {
                        warehouse1.Style.Add("display", "none");
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
                    btnDelete.Visible = true;

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

                    txtNo_Packages.Text = dtuser.Tables[0].Rows[0]["BE_NO_OF_PACKAGES"].ToString();
                    hdn_PackType.Value = dtuser.Tables[0].Rows[0]["BE_PACKAGE_CODE"].ToString();

                    txtWeight.Text = dtuser.Tables[0].Rows[0]["BE_WEIGHT"].ToString();
                    hdn_WeightType.Value = dtuser.Tables[0].Rows[0]["BE_UNIT_CODE"].ToString();                  
                    
                    txtBE_No.Text = dtuser.Tables[0].Rows[0]["BE_NO"].ToString();
                    txtBE_Date.Text= dtuser.Tables[0].Rows[0]["BE_DATE"].ToString();

                    txtAssessableValue.Text = dtuser.Tables[0].Rows[0]["BE_ASSESSABLE_VALUE"].ToString();
                    txtDutyValue.Text = dtuser.Tables[0].Rows[0]["BE_DUTY"].ToString();
                    
                    txtINBond_No.Text = dtuser.Tables[0].Rows[0]["BE_INBOND_NO"].ToString();
                    txtINBond_Date.Text = dtuser.Tables[0].Rows[0]["BE_INBOND_DATE"].ToString().Replace("01/01/1900","");

                    txtWareHouse_Customs.Text = dtuser.Tables[0].Rows[0]["BE_WAREHOUSE_CUSTOMS"].ToString();
                    txtWareHouse_Customs_Code.Text= dtuser.Tables[0].Rows[0]["BE_WAREHOUSE_CUSTOMS_CODE"].ToString();                   

                    string BE_type = dtuser.Tables[0].Rows[0]["BE_TYPE"].ToString();
                    txt_Expense_Amt.Text = dtuser.Tables[0].Rows[0]["EXPENSE_AMT"].ToString();

                    txtTR_No.Text = dtuser.Tables[0].Rows[0]["TR_NO"].ToString();
                    txtLateFees.Text = dtuser.Tables[0].Rows[0]["LATE_FEES"].ToString();
                    txtInterest.Text = dtuser.Tables[0].Rows[0]["INTEREST"].ToString();      


                    ddlBEType.Items.Clear();
                    ddlBEType.Items.Add("Home");
                    ddlBEType.Items.Add("Warehouse");
                     ddlBEType.Items.Add("Ex-Bond");
                    ddlBEType.Items.Remove(BE_type);

                    ddlBEType.Items.Insert(0, BE_type);

                    if (BE_type == "Home")
                    {
                        warehouse1.Style.Add("display", "none");
                    }
                    else if (BE_type == "Warehouse")
                    {
                        warehouse1.Style.Add("display", "block");
                    }
                    else if (BE_type == "Ex-Bond")
                    {
                        warehouse1.Style.Add("display", "none");
                    }
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
        BE.BE_ID = HiddenField1.Value;
        BE.Ename = "select_Details";
        BE.WORKING_PERIOD = Connection.Get_Company_Type();
        dtuser = BE.RetrieveAll_BE_Entry_Details();
        return dtuser;
    }

    public int insert_update(string a1, string a2, string a3)
    {
        BE.BE_ID = a1;
        BE.BE_JOBNO = txtJobNo.Text;
        BE.BE_NO_OF_PACKAGES = txtNo_Packages.Text;
        BE.BE_PACKAGE_CODE = hdn_PackType.Value;
        BE.BE_WEIGHT = txtWeight.Text;
        BE.BE_UNIT_CODE = hdn_WeightType.Value;
        BE.BE_TRANSPORT_MODE = ddlTransportMode.SelectedValue;
        BE.BE_TYPE = ddlBEType.SelectedValue;
        BE.BE_NO = txtBE_No.Text;
        BE.BE_DATE = txtBE_Date.Text;

        BE.BE_ASSESSABLE_VALUE = txtAssessableValue.Text;
        BE.BE_DUTY = txtDutyValue.Text;

        if (ddlBEType.SelectedValue == "Warehouse")
        {
            BE.BE_INBOND_NO = txtINBond_No.Text;
            BE.BE_INBOND_DATE = txtINBond_Date.Text == string.Empty ? "01/01/1900" : txtINBond_Date.Text;

            BE.BE_WAREHOUSE_CUSTOMS = txtWareHouse_Customs.Text;
            BE.BE_WAREHOUSE_CUSTOMS_CODE = txtWareHouse_Customs_Code.Text;
        }
        else
        {
            BE.BE_INBOND_NO = "";
            BE.BE_INBOND_DATE = "01/01/1900";

            BE.BE_WAREHOUSE_CUSTOMS = "";
            BE.BE_WAREHOUSE_CUSTOMS_CODE = "";
        }
        BE.Expense_Amt = txt_Expense_Amt.Text;
        BE.TR_NO = txtTR_No.Text;
        BE.LATE_FEES = txtLateFees.Text;
        BE.INTEREST = txtInterest.Text;

        BE.USER_ID = Connection.Current_User();
        BE.BRANCH_CODE = Connection.Current_Branch();
        BE.flag = a2;
        BE.YEAR = a3;
        BE.WORKING_PERIOD = Connection.WorkingPeriod();
        BE.BRANCH_COMMON = Connection.Get_Company_Type(); 
       
        i = BE.BE_Entry_Details_insertupdate();
        return i;
    }
   
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            string a1 = "";
            string a2 = "S";
            string a3 = "";
            i = insert_update(a1, a2,a3);
            HiddenField1.Value = Convert.ToString(BE.UPDATE_ID);

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
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string a1 = HiddenField1.Value;
            string a2 = "U";
            string a3 = "";
            i = insert_update(a1, a2, a3);
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
                Alert_msg("Already exixts!", "btnSave");
            }
            else
            {
                Alert_msg("BE_Entry Not Saved", "btnUpdate");
            }
        }
        catch (Exception ex)
        {
            Err_Msg(ex.Message);
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            BE.BE_ID = HiddenField1.Value;
            BE.Ename = "delete";
            BE.WORKING_PERIOD = Connection.Get_Company_Type();

            dtuser = BE.RetrieveAll_BE_Entry_Details();
            int ii = BE.result;

            if (ii == 1)
            {
                Alert_msg("Deleted Successfully");
            }
            else
            {
                Alert_msg("Not Deleted");
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
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'BE_ENTRY', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'BE_ENTRY', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
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
        ObjUBO.A3 = "I";
        ObjUBO.A4 = "Get_RyalRefno";
        dsRyal = RI.Ryal_Royal_Job_Update(ObjUBO);


        if ((flg == "S" || flg == "U") && dsRyal.Tables.Count > 0)
        {
            if (dsRyal.Tables[0].Rows.Count > 0)
            {
                if (Connection.COMPANYID() == "2814" || Connection.COMPANYID() == "3082" || Connection.COMPANYID() == "3153" || Connection.COMPANYID() == "3253")
                {
                    Connection.Ebms_BEno_Sbno_Return(1, dsRyal.Tables[0].Rows[0]["REF_NO"].ToString(), ObjUBO.A1, txtBE_No.Text, txtBE_Date.Text); ////*********IS LIVE IMPLEMENTATION********

                }
                else
                {
                    Connection.Ryal_BEno_Return(1, dsRyal.Tables[0].Rows[0]["RYAL_REF_NO"].ToString(), ObjUBO.A1, txtBE_No.Text, txtBE_Date.Text); ////*********IS LIVE IMPLEMENTATION********
                    //Connection.Ryal_BEno_Return(0, dsRyal.Tables[0].Rows[0]["RYAL_REF_NO"].ToString(), ObjUBO.A1, txtBE_No.Text, txtBE_Date.Text);    //*********IS TEST IMPLEMENTATION********

                }
            }
        }
    }
}


