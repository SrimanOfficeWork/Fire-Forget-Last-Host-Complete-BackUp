using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Export_Export_Drawback : ThemeClass
{
    DataSet dtuser = new DataSet();

    AppSession aps = new AppSession();
    Export_Drawback Draw = new Export_Drawback();
    Export_Item Item = new Export_Item();
    Transaction Transact = new Transaction();
    DataSet dss_prod = new DataSet();
    Auto_Search Auto = new Auto_Search();
    DataSet ds_DBK = new DataSet();
    adminmaster Admin_mas = new adminmaster();
    DataSet Ds_dbk_new = new DataSet();
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
    public string EXPORT_JOBNO, INV_SLN0, ITEM_SLNO, SCHEME_CODE, RITC_NO, ITEM_DESC, UNIT_CODE;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public int Screen_Id;
    public string JOB_LOCK, JOB_RELEASE, Audit_YN = "";
    User_Creation user_Create = new User_Creation();
    Export_General_New Export = new Export_General_New();
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        hdn_companyID.Value = Connection.COMPANYID();

        SELECT_BRANCH = Connection.Get_Company_Type();

        if (Connection.Audit_Logs(Connection.COMPANYID()) == "Y")
        {
            Audit_YN = "Y";
        }
        //----------------------------------------------------------------------
        if (!IsPostBack)
        {

            if (Session["Scheme_Code"].ToString() == "60-DRAWBACK AND ROSL" || Session["Scheme_Code"].ToString() == "60-DRAWBACK AND ROSCTL" || Session["Scheme_Code"].ToString() == "61-EPCG, DRAWBACK AND ROSL" || Session["Scheme_Code"].ToString() == "61-EPCG, DRAWBACK AND ROSCTL" || Session["Scheme_Code"].ToString() == "64-DRAWBACK, SPL AA ( 4.04A) AND ROSL" || Session["Scheme_Code"].ToString() == "64-DRAWBACK, SPL AA ( 4.04A) AND ROSCTL" || Session["Scheme_Code"].ToString() == "65-EPCG, DRAWBACK, SPL AA(4.04A) AND ROSL" || Session["Scheme_Code"].ToString() == "65-EPCG, DRAWBACK, SPL AA(4.04A) AND ROSCTL" || Session["Scheme_Code"].ToString() == "62-DRAWBACK AND SPL AA" || Session["Scheme_Code"].ToString() == "63-EPCG,DRAWBACK AND SPL AA")
            {
                ROSL.Visible = true;
                Hdn_ROSL.Value = Session["Scheme_Code"].ToString();

            }
            else
            {
                Hdn_ROSL.Value = string.Empty;
            }

        }

        //----------------------------------------------------------------------

        if (Session["EXPORT_JOBNO"] != null)
        {
            EXPORT_JOBNO = Session["EXPORT_JOBNO"].ToString();

            if (Session["Inv_SL_No"] != null)
            {
                INV_SLN0 = Session["Inv_SL_No"].ToString();
                ITEM_SLNO = Session["Item_SLNo"].ToString();
                SCHEME_CODE = Session["Scheme_Code"].ToString();
                UNIT_CODE = Session["Unit_Code"].ToString();
                hdn_UnitCode.Value = UNIT_CODE;

                if (!IsPostBack)
                {
                    txtDrawback_Unit.Text = Session["Unit_Code"].ToString();
                }
                RITC_NO = Session["EXP_RITCNO"].ToString();
                ITEM_DESC = Session["EXP_DESC"].ToString();

                Hdn_RITC_4_digit.Value = RITC_NO.Substring(0, 4);
            }
            else
            {
                Response.Write("<script>window.open('Item_Details.aspx','_parent');</script>");
            }

            if (!IsPostBack)
            {
                //----------------SETTING SCREEN PERMISSION---------------//
                Screen_Id = 12;
                Page_Rights(Screen_Id);
                //----------------SETTING SCREEN PERMISSION---------------//

                if (!string.IsNullOrEmpty(Request["Qty"]))
                {
                    txtDrawback_Qty.Text = Request["Qty"].ToString();
                    hdn_item_qty.Value = Request["Qty"].ToString();

                    //if (Connection.COMPANYID() == "10")
                    //{
                    //    txtDrawback_Qty.Text = Request["Qty"].ToString();
                    //}
                }

                txtDrawback_SLNo.Focus();
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnSave.Visible = true;
                Edit_Drawback_Details();
            }
            ///------------------------------------------------auto search-----------------------------------------------------------------
            //DRAWBACK
            //txtDrawback_SLNo.Attributes.Add("onblur", "javascript:CallServerside_Drawback('" + txtDrawback_SLNo.ClientID + "', '" + txtDrawback_Rate.ClientID + "')");
            txtDrawback_SLNo.Attributes.Add("onblur", "javascript:CallServerside_Drawback('" + txtDrawback_SLNo.ClientID + "', '" + UNIT_CODE + "', '" + txtDrawback_Qty.Text + "')");

            //DRAWBACK

            //if (Connection.COMPANYID() == "10")
            //{
            //    txtDrawback_Qty.Text = Request["Qty"].ToString();
            //}

            ///------------------------------------------------auto search-----------------------------------------------------------------
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
    public DataSet Get_Item_SLNO()
    {
        Draw.JOBNO = EXPORT_JOBNO;
        Draw.INVOICE_SLNO = //session value from item details
        Draw.ITEM_SLNO = //session value from item details
        Draw.SCHEME_CODE = //session value from item details

        Draw.Ename = "select";
        Draw.WORKING_PERIOD = SELECT_BRANCH;
        dtuser = Draw.RetrieveAll_Drawback_Details();
        return dtuser;
    }

    public DataSet BindValue()
    {
        Draw.JOBNO = EXPORT_JOBNO;
        Draw.INVOICE_SLNO = INV_SLN0;
        Draw.ITEM_SLNO = ITEM_SLNO;
        Draw.SCHEME_CODE = SCHEME_CODE;
        Draw.RITC_NO = RITC_NO;
        Draw.ITEM_DESCRIPTION = ITEM_DESC;

        Draw.Ename = "select_DBK_srno";
        Draw.WORKING_PERIOD = SELECT_BRANCH;
        dtuser = Draw.RetrieveAll_Drawback_Details();
        return dtuser;

    }

    public void Edit_Drawback_Details()
    {
        if (Session["EXPORT_JOBNO"] != null)
        {
            BindValue();
            if (Draw.result == 1)
            {
                //if (dtuser.Tables[0].Rows.Count > 0)
                //{
                //Check_RITC_Desc_ProductExportMaster();

                Draw.RITC_NO = RITC_NO;
                Draw.ITEM_DESCRIPTION = ITEM_DESC;

                Draw.Ename = "Check_RITC_Desc_ProductExportMaster";
                Draw.WORKING_PERIOD = SELECT_BRANCH;
                dss_prod = Draw.RetrieveAll_Drawback_Details();

                int ii = Draw.result;

                if (ii == 1)
                {
                    if (dss_prod.Tables[0].Rows.Count > 0)
                    {
                        string DBKSlNo = dss_prod.Tables[0].Rows[0]["DBK_SL_NO"].ToString();

                        Auto.Ename = "DRAWBACK_MASTER_ALL";
                        Auto.Enamesearch = DBKSlNo;

                        ds_DBK = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
                        if (ds_DBK.Tables[0].Rows.Count > 0)
                        {
                            txtDrawback_SLNo.Text = ds_DBK.Tables[0].Rows[0]["DRAWBACK_SLNO"].ToString();
                            //txtDrawback_Qty.Text = ds_DBK.Tables[0].Rows[0]["DRAWBACK_QTY"].ToString();

                            txtDrawback_No_Of_Unit.Text = ds_DBK.Tables[0].Rows[0]["DRAWBACK_NOOFUNITS"].ToString();
                            txtDrawback_Rate.Text = ds_DBK.Tables[0].Rows[0]["DRAWBACK_RATE"].ToString();
                            txtDrawback_Desc.Text = ds_DBK.Tables[0].Rows[0]["DRAWBACK_DESCRIPTION"].ToString();
                            txtDrawback_Cap.Text = ds_DBK.Tables[0].Rows[0]["DRAWBACK_VALUE_CAP"].ToString();

                            if (txtDrawback_Cap.Text != "0.00" && txtDrawback_Cap.Text != "")
                            {
                                if (ds_DBK.Tables[0].Rows[0]["DRAWBACK_UNIT"].ToString() != UNIT_CODE)
                                {
                                    txtDrawback_Qty.Text = "";
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(Request["Qty"]))
                                    {
                                        txtDrawback_Qty.Text = Request["Qty"].ToString();
                                    }
                                }
                            }
                            else
                            {
                                txtDrawback_Cap.Text = ds_DBK.Tables[0].Rows[0]["DRAWBACK_VALUE_CAP"].ToString();
                            }

                            if (ds_DBK.Tables[0].Rows[0]["DRAWBACK_UNIT"].ToString() != "")
                            {
                                txtDrawback_Unit.Text = ds_DBK.Tables[0].Rows[0]["DRAWBACK_UNIT"].ToString();
                                UNIT_CODE = txtDrawback_Unit.Text;
                            }
                            else
                            {
                                txtDrawback_Unit.Text = UNIT_CODE;
                            }
                        }
                        else
                        {
                        }
                        //}
                    }
                    else if (Connection.COMPANYID() == "10" || Connection.COMPANYID() == "480" || Connection.COMPANYID() == "572" || Connection.COMPANYID() == "1011" || Connection.COMPANYID() == "1019" || Connection.COMPANYID() == "1176" || Connection.COMPANYID() == "1572" || Connection.COMPANYID() == "2059")
                    {

                        Draw.RITC_NO = RITC_NO;
                        Draw.ITEM_DESCRIPTION = "";
                        Draw.Ename = "Dbk_auto_bind";
                        Draw.WORKING_PERIOD = SELECT_BRANCH;
                        dss_prod = Draw.Export_Drawback_Slno_Auto_Bind_Insert_Update();

                        if (dss_prod.Tables[0].Rows.Count > 0)
                        {
                            txtDrawback_SLNo.Text = dss_prod.Tables[0].Rows[0]["DBK_SLNO"].ToString();
                        }

                        else
                        {
                            txtDrawback_SLNo.Text = Hdn_RITC_4_digit.Value;
                        }
                    }

                    else
                    {
                        txtDrawback_SLNo.Text = Hdn_RITC_4_digit.Value;
                    }




                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnSave.Visible = true;
                    btnNew.Visible = false;
                    //Session.Remove("Unit_Code");
                }
                else if (hdn_companyID.Value == "1" || hdn_companyID.Value == "10" || hdn_companyID.Value == "480" || hdn_companyID.Value == "572" || hdn_companyID.Value == "1011" || hdn_companyID.Value == "1019" || hdn_companyID.Value == "1176" || hdn_companyID.Value == "1572" || hdn_companyID.Value == "2059" || hdn_companyID.Value == "3267")
                {
                    //Admin_mas.Edrawback_slno = Hdn_RITC_4_digit.Value;
                    //Admin_mas.Edrawback_description = "";
                    //Admin_mas.Ename = "select_con";
                    //Admin_mas.startRowIndex = "";
                    //Admin_mas.maximumRows = "";

                    //Ds_dbk_new = Admin_mas.RetrieveAll_Drawback_master();
                    //if (Ds_dbk_new.Tables[0].Rows.Count > 0)
                    //{

                    Draw.RITC_NO = RITC_NO;
                    Draw.ITEM_DESCRIPTION = "";
                    Draw.Ename = "Dbk_auto_bind";
                    Draw.BRANCH_CODE = currentbranch;
                    dss_prod = Draw.Export_Drawback_Slno_Auto_Bind_Insert_Update();

                    if (dss_prod.Tables[0].Rows.Count > 0)
                    {
                        txtDrawback_SLNo.Text = dss_prod.Tables[0].Rows[0]["DBK_SLNO"].ToString();
                    }
                    else
                    {
                        txtDrawback_SLNo.Text = Hdn_RITC_4_digit.Value;
                    }
                }
                else
                {
                    txtDrawback_SLNo.Text = Hdn_RITC_4_digit.Value;
                }
            }
            else if (Draw.result == 2)
            {
                if (dtuser.Tables[0].Rows.Count > 0)
                {
                    if (dtuser.Tables[0].Rows[0]["DRAWBACK_SLNO"].ToString().Length >= 4)
                    {
                        if (dtuser.Tables[0].Rows[0]["DRAWBACK_SLNO"].ToString().Substring(0, 4) == Hdn_RITC_4_digit.Value)
                        {
                            txtDrawback_SLNo.Text = dtuser.Tables[0].Rows[0]["DRAWBACK_SLNO"].ToString();
                        }
                        else
                        {
                            //txtDrawback_SLNo.Text = Hdn_RITC_4_digit.Value;
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Show_Mismatch_RITC()", true);
                        }

                        hdn_Draw_ID.Value = dtuser.Tables[0].Rows[0]["DRAWBACK_ID"].ToString();
                        txtDrawback_SLNo.Text = dtuser.Tables[0].Rows[0]["DRAWBACK_SLNO"].ToString();
                        txtDrawback_Qty.Text = dtuser.Tables[0].Rows[0]["DRAWBACK_QTY"].ToString();
                        txtDrawback_Unit.Text = dtuser.Tables[0].Rows[0]["DRAWBACK_UNIT"].ToString();
                        UNIT_CODE = txtDrawback_Unit.Text;
                        txtDrawback_No_Of_Unit.Text = dtuser.Tables[0].Rows[0]["DRAWBACK_NOOFUNITS"].ToString();
                        txtDrawback_Rate.Text = dtuser.Tables[0].Rows[0]["DRAWBACK_RATE"].ToString();
                        txtDrawback_Cap.Text = dtuser.Tables[0].Rows[0]["DRAWBACK_CAPS"].ToString();
                        txtDrawback_Desc.Text = dtuser.Tables[0].Rows[0]["DRAWBACK_DESC"].ToString();

                        txtstate_level_adv_Rate.Text = dtuser.Tables[0].Rows[0]["STATE_LEVEL_ADV_RATE"].ToString();
                        txtstate_level_adv_Amt.Text = dtuser.Tables[0].Rows[0]["STATE_LEVEL_ADV_AMT"].ToString();

                        txtCentral_level_adv_Rate.Text = dtuser.Tables[0].Rows[0]["CENTRAL_LEVEL_ADV_RATE"].ToString();
                        txtCentral_level_adv_Amt.Text = dtuser.Tables[0].Rows[0]["CENTRAL_LEVEL_ADV_AMT"].ToString();

                        if (!string.IsNullOrEmpty(Session["SB_NO"].ToString()))
                        {
                            div_AmendmentType.Visible = true;
                            ddl_AmendmentType.SelectedValue = dtuser.Tables[0].Rows[0]["AMENDMENT_TYPE"].ToString();
                        }

                        btnUpdate.Visible = true;
                        btnDelete.Visible = true;
                        btnSave.Visible = false;
                        btnNew.Visible = false;

                    }

                    // ----Audit Modified Data -----------------------------------
                    if (Audit_YN == "Y")
                    {
                        Tbl_Filed_Modified_History(dtuser.Tables[1]);
                    }
                }
            }
        }
    }

    public DataSet Check_RITC_Desc_ProductExportMaster()
    {

        Draw.RITC_NO = RITC_NO;
        Draw.ITEM_DESCRIPTION = ITEM_DESC;

        Draw.Ename = "Check_RITC_Desc_ProductExportMaster";
        Draw.WORKING_PERIOD = SELECT_BRANCH;
        dss_prod = Draw.RetrieveAll_Drawback_Details();

        int ii = Draw.result;

        if (ii == 1)
        {
            if (dss_prod.Tables[0].Rows.Count > 0)
            {
                string DBKSlNo = dss_prod.Tables[0].Rows[0]["DBK_SL_NO"].ToString();

                Auto.Ename = "DRAWBACK_MASTER_ALL";
                Auto.Enamesearch = DBKSlNo;

                ds_DBK = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
                if (ds_DBK.Tables[0].Rows.Count > 0)
                {

                }
            }
        }
        return ds_DBK;
    }

    public int Export_Drawback_Insert_Update(string Flag)
    {
        //Export.JOBID = jobid;
        if (txtDrawback_SLNo.Text.Length >= 4)
        {
            Draw.DRAWBACK_ID = "0";
            Draw.JOBNO = EXPORT_JOBNO;
            Draw.INVOICE_SLNO = INV_SLN0;
            Draw.ITEM_SLNO = ITEM_SLNO;
            Draw.SCHEME_CODE = SCHEME_CODE;
            Draw.DRAWBACK_SLNO = txtDrawback_SLNo.Text.ToUpper();
            Draw.DRAWBACK_QTY = txtDrawback_Qty.Text;
            Draw.DRAWBACK_UNIT = txtDrawback_Unit.Text;
            Draw.DRAWBACK_NOOFUNITS = txtDrawback_No_Of_Unit.Text;
            Draw.DRAWBACK_RATE = txtDrawback_Rate.Text;
            Draw.DRAWBACK_CAPS = txtDrawback_Cap.Text;
            Draw.DRAWBACK_DESC = txtDrawback_Desc.Text;

            Draw.AMENDMENT_TYPE = ddl_AmendmentType.SelectedValue;
            Draw.AMENDMENT_STATUS = "";

            Draw.USER_ID = currentuser;
            Draw.YEAR = "";
            Draw.flag = Flag;
            Draw.BRANCH_CODE = currentbranch;
            Draw.WORKING_PERIOD = Working_Period;
            Draw.BRANCH_COMMON = SELECT_BRANCH;

            if (Session["Scheme_Code"].ToString() == "60-DRAWBACK AND ROSL" || Session["Scheme_Code"].ToString() == "60-DRAWBACK AND ROSCTL" || Session["Scheme_Code"].ToString() == "61-EPCG, DRAWBACK AND ROSL" || Session["Scheme_Code"].ToString() == "61-EPCG, DRAWBACK AND ROSCTL" || Session["Scheme_Code"].ToString() == "64-DRAWBACK, SPL AA ( 4.04A) AND ROSL" || Session["Scheme_Code"].ToString() == "64-DRAWBACK, SPL AA ( 4.04A) AND ROSCTL" || Session["Scheme_Code"].ToString() == "65-EPCG, DRAWBACK, SPL AA(4.04A) AND ROSL" || Session["Scheme_Code"].ToString() == "65-EPCG, DRAWBACK, SPL AA(4.04A) AND ROSCTL" || Session["Scheme_Code"].ToString() == "62-DRAWBACK AND SPL AA" || Session["Scheme_Code"].ToString() == "63-EPCG,DRAWBACK AND SPL AA")
            {
                Draw.STATE_LEVEL_ADV_RATE = txtstate_level_adv_Rate.Text;
                Draw.STATE_LEVEL_ADV_AMT = txtstate_level_adv_Amt.Text;

                Draw.CENTRAL_LEVEL_ADV_RATE = txtCentral_level_adv_Rate.Text;
                Draw.CENTRAL_LEVEL_ADV_AMT = txtCentral_level_adv_Amt.Text;
            }
            else
            {
                Draw.STATE_LEVEL_ADV_RATE = string.Empty;
                Draw.STATE_LEVEL_ADV_AMT = string.Empty;

                Draw.CENTRAL_LEVEL_ADV_RATE = string.Empty;
                Draw.CENTRAL_LEVEL_ADV_AMT = string.Empty;
            }
            Draw.JOBNO_PS = Session["JOBNO_PS"].ToString();

            i = Draw.Export_Drawback_Insert_Update();
            Export.Exp_Job_Logs_All_Details(EXPORT_JOBNO, INV_SLN0, ITEM_SLNO, "Drawback", Flag, "Insert");
        }
        return i;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string Qty_Same_Diff = hdn_Same_Diff.Value;

        if (Qty_Same_Diff == "Same")
        {
            if (txtDrawback_SLNo.Text != "" && txtDrawback_Qty.Text != "" && txtDrawback_Unit.Text != "" && txtDrawback_Rate.Text != "" && txtDrawback_Desc.Text != "")
            {
                try
                {
                    //string ID = "";
                    string F = "S";
                    i = Export_Drawback_Insert_Update(F);
                    if (i == 1)
                    {
                        btnUpdate.Visible = true;
                        btnDelete.Visible = true;
                        btnSave.Visible = false;
                        btnNew.Visible = false;
                        if (Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00010" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00146" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00004" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00183" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00164" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00165" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00563" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00747" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01051" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01103" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01136" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01137")
                        {
                            if (Session["Drawback_DEEC"] != null)
                            {
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "Drawback_DEEC();", true);
                                Session_Clear();
                            }
                            else if (Session["drawback_jobbing_EPCG"] != null)
                            {
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "Drawback_jobbing();", true);
                                Session_Clear();
                            }
                            else if (Session["Drawback_jobbing"] != null)
                            {
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "Drawback_jobbing();", true);
                                Session_Clear();
                            }
                            else if (Session["Drawback_EPCG"] != null)
                            {
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "Drawback_EPCG();", true);
                                Session_Clear();
                            }
                            else if (Session["drawback_EPCG_DEEC"] != null)
                            {
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "Drawback_EPCG();", true);
                                Session_Clear();
                            }
                            else if (Session["drawback_EPCG_DFIA"] != null)
                            {
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "Drawback_EPCG();", true);
                                Session_Clear();
                            }
                            else
                            {
                                Alert_msg("Drawback Saved Successfully!");
                            }
                        }
                        else
                        {
                            Alert_msg("Drawback Saved Successfully!");
                        }

                        if (hdn_companyID.Value == "10" || hdn_companyID.Value == "480" || hdn_companyID.Value == "572" || hdn_companyID.Value == "1011" || hdn_companyID.Value == "1019" || hdn_companyID.Value == "1176" || hdn_companyID.Value == "1572" || hdn_companyID.Value == "2059" || hdn_companyID.Value == "3267")
                        {
                            DBk_ins();
                        }

                        if (txtDrawback_SLNo.Text.Substring(0, 4) == Hdn_RITC_4_digit.Value)
                        {
                            //txtDrawback_SLNo.Text = dtuser.Tables[0].Rows[0]["DRAWBACK_SLNO"].ToString();
                        }
                        else
                        {
                            //txtDrawback_SLNo.Text = Hdn_RITC_4_digit.Value;
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Show_Mismatch_RITC()", true);
                        }

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
                        Alert_msg("DrawBack Not Saved", "btnSave");
                    }
                }
                catch (Exception ex)
                {
                    er.makeLog(ex.Message);
                }
            }
            else
            {
                Alert_msg("Enter All Mandatory Field", "btnSave");
            }
        }
    }

    private void Session_Clear()
    {
        Session.Remove("Drawback_DEEC");
        Session.Remove("Drawback_EPCG");
        Session.Remove("Drawback_jobbing");
        Session.Remove("drawback_EPCG_DEEC");
        Session.Remove("drawback_jobbing_EPCG");
        Session.Remove("drawback_EPCG_DFIA");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string Qty_Same_Diff = hdn_Same_Diff.Value;

        if (Qty_Same_Diff == "Same")
        {
            if (txtDrawback_SLNo.Text != "" && txtDrawback_Qty.Text != "" && txtDrawback_Unit.Text != "" && txtDrawback_Rate.Text != "" && txtDrawback_Desc.Text != "")
            {
                try
                {
                    string F = "U";
                    i = Export_Drawback_Insert_Update(F);
                    if (i == 1)
                    {

                        btnUpdate.Visible = true;
                        btnDelete.Visible = true;
                        btnSave.Visible = false;
                        btnNew.Visible = false;

                        // ----Audit Modified Data -----------------------------------
                        if (Audit_YN == "Y")
                        {
                            Audit_Modified_DataTableComparer();
                        }
                        //------------------------------------------------------------

                        Alert_msg("DrawBack Updated Successfully", "btnUpdate");

                        if (hdn_companyID.Value == "10" || hdn_companyID.Value == "480" || hdn_companyID.Value == "572" || hdn_companyID.Value == "1011" || hdn_companyID.Value == "1019" || hdn_companyID.Value == "1176" || hdn_companyID.Value == "1572" || hdn_companyID.Value == "2059" || hdn_companyID.Value == "3267")
                        {
                            DBk_ins();
                        }

                        if (txtDrawback_SLNo.Text.Substring(0, 4) == Hdn_RITC_4_digit.Value)
                        {
                            //txtDrawback_SLNo.Text = dtuser.Tables[0].Rows[0]["DRAWBACK_SLNO"].ToString();
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Show_Mismatch_RITC()", true);
                        }

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
                        Alert_msg("DrawBack Not Saved", "btnUpdate");
                    }
                }
                catch (Exception ex)
                {
                    er.makeLog(ex.Message);
                }
            }
            else
            {
                Alert_msg("Enter All Mandatory Field", "btnUpdate");
            }
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            Draw.JOBNO = EXPORT_JOBNO;
            Draw.INVOICE_SLNO = INV_SLN0;
            Draw.ITEM_SLNO = ITEM_SLNO;
            Draw.SCHEME_CODE = SCHEME_CODE;

            Draw.Ename = "delete";
            Draw.WORKING_PERIOD = SELECT_BRANCH;
            dtuser = Draw.RetrieveAll_Drawback_Details();
            i = Draw.result;

            if (i == 1)
            {
                btnNew_Click(sender, e);
                Alert_msg("DrawBack Deleted");
                Export.Exp_Job_Logs_All_Details(EXPORT_JOBNO, INV_SLN0, ITEM_SLNO, "Drawback", "D", "Insert");
            }
            else
            {
                Alert_msg("DrawBack Not Deleted");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        Transact.ResetFields(Page.Controls);
        txtDrawback_SLNo.Focus();
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnSave.Visible = true;
        btnNew.Visible = true;
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'DRAWBACK', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'DRAWBACK', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    [System.Web.Services.WebMethod]
    public static string Get_Drawback_Master(string custid, string dbk_unit, string dbk_Qty, string Hdn_ROSL, string Comp_ID)
    {
        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();
        Auto.Ename = "DRAWBACK_MASTER_ALL";
        Auto.Enamesearch = custid;
        Auto.Notn_No_Search = Hdn_ROSL;

        ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
        if (ds.Tables[0].Rows.Count > 0)
        {

            string Address1 = ds.Tables[0].Rows[0]["DRAWBACK_UNIT"].ToString();
            string Address2 = ds.Tables[0].Rows[0]["DRAWBACK_NOOFUNITS"].ToString();
            string Address4 = ds.Tables[0].Rows[0]["DRAWBACK_RATE"].ToString();
            string Address5 = ds.Tables[0].Rows[0]["DRAWBACK_VALUE_CAP"].ToString();

            if (Address1 == "")
            {
                Address1 = dbk_unit;
            }

            if (Address5 != "0.00" && Address5 != "")
            {
                if (Comp_ID != "10" && Comp_ID != "1572" && Comp_ID != "1623") // Ringo Cargo - Item Qty same as Dbk Qty - don't clear the mismatched Unitcode - done by Chithra on 04-11-2022
                {
                    if (dbk_unit != Address1)
                    {
                        dbk_Qty = "";

                    }
                    else
                    {
                        dbk_Qty = dbk_Qty;
                    }
                }
            }


            string Address6 = ds.Tables[0].Rows[0]["DRAWBACK_DESCRIPTION"].ToString();

            //string ROSL_Rate = string.Empty, ROSL_Amt = string.Empty;


            if (ds.Tables[1].Rows.Count > 0)
            {
                custid = Address1 + "~~" + Address2 + "~~" + Address4 + "~~" + Address5 + "~~" + Address6 + "~~" + dbk_Qty + "~~" + ds.Tables[1].Rows[0]["ROSL_RATE"].ToString() + "~~" + ds.Tables[1].Rows[0]["ROSL_AMT"].ToString() + "~~" + ds.Tables[1].Rows[1]["ROSL_RATE"].ToString() + "~~" + ds.Tables[1].Rows[1]["ROSL_AMT"].ToString();
            }
            else
            {
                custid = Address1 + "~~" + Address2 + "~~" + Address4 + "~~" + Address5 + "~~" + Address6 + "~~" + dbk_Qty + "~~" + "0" + "~~" + "0" + "~~" + "0" + "~~" + "0";
            }
            //custid = Address1 + "~~" + Address2 + "~~" + Address4 + "~~" + Address5 + "~~" + Address6 + "~~" + dbk_Qty;
        }
        return custid;
    }

    private void DBk_ins()
    {
        DataSet ds = new DataSet();
        Draw.RITC_NO = RITC_NO;
        Draw.DRAWBACK_SLNO = txtDrawback_SLNo.Text;
        Draw.flag = "";
        Draw.Ename = "Dbk_auto_Insert_Update";
        Draw.BRANCH_CODE = SELECT_BRANCH;

        ds = Draw.Export_Drawback_Slno_Auto_Bind_Insert_Update();

    }

    #region Export Audit Logs

    private void Tbl_Filed_Modified_History(DataTable dt_Curr_tbl_struct)
    {
        try
        {
            ViewState["dt_Prev_Table"] = dt_Curr_tbl_struct;
            DataTable_Mapping_Controls(dt_Curr_tbl_struct);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void Audit_Modified_DataTableComparer()
    {
        try
        {
            DataTable dt_Prev = (DataTable)ViewState["dt_Prev_Table"];
            DataTable dt_m2 = dt_Prev.Clone();
            DataTable dt_modified = DataTable_Mapping_Controls(dt_m2);
            DataTableComparer Dt_Change = new DataTableComparer();
            Dt_Change.GetMismatchedRowsFast_EXP(dt_Prev, dt_modified, "DRAWBACK_ID", "Drawback", EXPORT_JOBNO, INV_SLN0, ITEM_SLNO, currentuser, currentbranch);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private DataTable DataTable_Mapping_Controls(DataTable dt_mapping)
    {
        try
        {
            if (dt_mapping.Rows.Count > 0)
            {
                dt_mapping.Rows.Clear();
            }
            DataRow dr = dt_mapping.NewRow();

            dr["DRAWBACK_ID"] = hdn_Draw_ID.Value;        // Hidden field if available
            dr["JOBNO"] = EXPORT_JOBNO;
            dr["INVOICE_SLNO"] = INV_SLN0;
            dr["ITEM_SLNO"] = ITEM_SLNO;
            dr["DRAWBACK_SLNO"] = txtDrawback_SLNo.Text;
            dr["DRAWBACK_QTY"] = txtDrawback_Qty.Text;
            dr["DRAWBACK_UNIT"] = txtDrawback_Unit.Text;
            dr["DRAWBACK_NOOFUNITS"] = txtDrawback_No_Of_Unit.Text;
            dr["DRAWBACK_RATE"] = txtDrawback_Rate.Text;
            dr["DRAWBACK_CAPS"] = txtDrawback_Cap.Text;
            dr["DRAWBACK_DESC"] = txtDrawback_Desc.Text;
            dr["STATE_LEVEL_ADV_RATE"] = txtstate_level_adv_Rate.Text;
            dr["STATE_LEVEL_ADV_AMT"] = txtstate_level_adv_Amt.Text;
            dr["CENTRAL_LEVEL_ADV_RATE"] = txtCentral_level_adv_Rate.Text;
            dr["CENTRAL_LEVEL_ADV_AMT"] = txtCentral_level_adv_Amt.Text;
            dr["AMENDMENT_TYPE"] = ddl_AmendmentType.SelectedValue;

            dt_mapping.Rows.Add(dr);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return dt_mapping;
    }

    #endregion
}
