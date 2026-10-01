using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

public partial class Export_Export_License_Details : ThemeClass
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    Export_Licence Export_license = new Export_Licence();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    DataSet dss = new DataSet();
    Transaction Transact = new Transaction();
    Export_General_New Exp_Gen = new Export_General_New();
    DataSet ds_license = new DataSet();

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    public int i;
    public string EXPORT_JOBNO, INV_SLN0, ITEM_SLNO, SCHEME_CODE, Unit_Code, Unit_Qty, LICENSE_ID, LICENSE_IMP_EXP_ID, License_Date, FLAG, YEAR, NM, DDlNM, SCHEME, COMPANY_ID;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public int Screen_Id;
    public string JOB_LOCK, JOB_RELEASE, MASTER_CONN = "", Audit_YN = "";
    public int License_id_Max, License_id_IMP_EXP_Max;
    User_Creation user_Create = new User_Creation();
    AdminMasterDetails admin = new AdminMasterDetails();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        COMPANY_ID = Session["COMPANY_ID"].ToString();

        SELECT_BRANCH = Connection.Get_Company_Type();
        //txtImport_Item_Sl_No.Enabled = false;
        txtLicenseNo.Focus();

        if (Connection.Audit_Logs(Connection.COMPANYID()) == "Y")
        {
            Audit_YN = "Y";
        }

        if (Session["EXPORT_JOBNO"] != null)
        {

            EXPORT_JOBNO = Session["EXPORT_JOBNO"].ToString();

            if (Session["Inv_SL_No"] != null)
            {
                INV_SLN0 = Session["Inv_SL_No"].ToString();
                ITEM_SLNO = Session["Item_SLNo"].ToString();
                SCHEME_CODE = Session["Scheme_Code"].ToString();
                Unit_Code = Session["Unit_Code"].ToString();
                Unit_Qty = Session["Unit_Qty"].ToString();
                lblQtyCode.Text = Unit_Code;

                //if (Session["Scheme"] != null)
                //{
                //    SCHEME = Session["Scheme"].ToString();
                //}

                if (!string.IsNullOrEmpty(Request["Scheme"]))
                {
                    SCHEME = Request.QueryString["Scheme"].ToString();
                }
                //For License Master
                if (!string.IsNullOrEmpty(Request["License_Scheme"]))
                {
                    hdn_License_Scheme.Value = Request.QueryString["License_Scheme"].ToString();
                    if (!string.IsNullOrEmpty(hdn_license_istrue.Value))
                    {
                        if (!IsPostBack)
                        {
                            txtImport_Item_Sl_No.Text = hdn_Import_Slno.Value;
                        }
                        if (hdn_update_License.Value == "")
                        {

                            txtDescription.Text = hdn_desc.Value;
                            txtImport_Qty.Text = hdn_Import_qty.Value;
                            txtImport_Unit.Text = hdn_Import_unit.Value;
                        }

                        string a = "";
                        if (hdn_NM_type.Value == "N")
                        {
                            a = "Indigenous";
                        }
                        else if (hdn_NM_type.Value == "M")
                        {
                            a = "Imported";
                        }

                        ddlNM.Items.Add("Indigenous");
                        ddlNM.Items.Add("Imported");

                        ddlNM.Items.Remove(a);
                        ddlNM.Items.Insert(0, a);
                    }
                }
            }
            else
            {
                Response.Write("<script>window.open('Item_Details.aspx','_parent');</script>");
            }
            if (!IsPostBack)
            {
                //auto search
                //txtLicenseNo.Attributes.Add("onblur", "javascript:CallServerside_License('" + txtLicenseNo.ClientID + "', '" + hdn_License_Scheme.ClientID + "')");

                //auto search
                //----------------SETTING SCREEN PERMISSION---------------//
                Screen_Id = 12;
                Page_Rights(Screen_Id);
                //----------------SETTING SCREEN PERMISSION---------------//

                txtExport_Qty.Text = Unit_Qty;

                if (txtExport_Item_Sl_No.Text == "" && txtExport_Item_Sl_No.Text != "1")
                {
                    txtExport_Item_Sl_No.Text = "1";
                }
                if (txtImport_Item_Sl_No.Text == "" && txtImport_Item_Sl_No.Text != "1")
                {
                    txtImport_Item_Sl_No.Text = "1";
                }
                Gridbind_License();
                //Gridbind_License_Imp_Exp();
                ddlNM.Items.Clear();
                ddlNM.Items.Add("Indigenous");
                ddlNM.Items.Add("Imported");
                btnLicense_Save.Visible = true;
                btnLicense_Update.Visible = false;
                btnLicense_Delete.Visible = false;
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
            }
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

                btnLicense_Delete.Enabled = false;
                btnLicense_New.Enabled = false;
                btnLicense_Save.Enabled = false;
                btnLicense_Update.Enabled = false;

                btnLicense_Delete.ToolTip = "This Job is Locked by Admin";
                btnLicense_New.ToolTip = "This Job is Locked by Admin";
                btnLicense_Save.ToolTip = "This Job is Locked by Admin";
                btnLicense_Update.ToolTip = "This Job is Locked by Admin";
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

                        btnLicense_Delete.Enabled = false;
                        btnLicense_New.Enabled = false;
                        btnLicense_Save.Enabled = false;
                        btnLicense_Update.Enabled = false;

                        MP_U.Show();

                        lblUser_Msg.Text = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";

                        btnUpdate.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                        btnDelete.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                        btnNew.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                        btnSave.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";

                        btnLicense_Delete.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                        btnLicense_New.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                        btnLicense_Save.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                        btnLicense_Update.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";

                    }
                }
            }
        }

        if (txtRegn_Sl_No.Text == "")
        {
            txtRegn_Sl_No.Text = Convert.ToInt32(gv_License.Rows.Count + 1).ToString();
        }
        txtRegn_Sl_No.Attributes.Add("readonly", "readonly");

    }

    public void Page_Rights(int i)
    {
        user_Create.RetrieveAll_User_Screen_Rights_Details(i);
        PAGE_WRITE = user_Create.PAGE_WRITE;
        PAGE_READ = user_Create.PAGE_READ;
        PAGE_MODIFY = user_Create.PAGE_MODIFY;
        PAGE_DELETE = user_Create.PAGE_DELETE;
        hdn_Grid_Disable.Value = "";

        //---------------READ ONLY------------------//

        if (PAGE_READ == "False")
        {
            btnSave.Enabled = false;
            btnSaveNew.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnNew.Enabled = false;

            btnLicense_Save.Enabled = false;
            btnLicense_Update.Enabled = false;
            btnLicense_Delete.Enabled = false;
            btnLicense_New.Enabled = false;

            btnNew.ToolTip = "You don't have permission to access";
            btnSave.ToolTip = "You don't have permission to access";
            btnUpdate.ToolTip = "You don't have permission to access";
            btnDelete.ToolTip = "You don't have permission to access";


            btnLicense_Save.ToolTip = "You don't have permission to access";
            btnLicense_Update.ToolTip = "You don't have permission to access";
            btnLicense_Delete.ToolTip = "You don't have permission to access";
            btnLicense_New.ToolTip = "You don't have permission to access";

            hdn_Grid_Disable.Value = "1";
        }
        else
        {
            //}
            //btnNew.Enabled = true;
            //---------------SAVE BUTTON------------------//
            if (PAGE_WRITE == "True")
            {
                btnSave.Enabled = true;
                btnSaveNew.Enabled = true;
                btnLicense_Save.Enabled = true;
                btnNew.Enabled = true;
                btnLicense_New.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
                btnSaveNew.Enabled = false;
                btnLicense_Save.Enabled = false;
                btnSave.ToolTip = "You don't have permission to access";
                btnLicense_Save.ToolTip = "You don't have permission to access";
                btnNew.Enabled = false;
                btnLicense_New.Enabled = false;
            }
            //---------------UPDATE BUTTON------------------//

            if (PAGE_MODIFY == "True")
            {
                btnUpdate.Enabled = true;
                btnLicense_Update.Enabled = true;
                hdn_Grid_Disable.Value = "";
            }
            else
            {
                btnUpdate.Enabled = false;
                btnLicense_Update.Enabled = false;
                btnUpdate.ToolTip = "You don't have permission to access";
                btnLicense_Update.ToolTip = "You don't have permission to access";
                //hdn_Grid_Disable.Value = "1";
            }
            //---------------DELETE BUTTON------------------//

            if (PAGE_DELETE == "True")
            {
                btnDelete.Enabled = true;
                btnLicense_Delete.Enabled = true;
                hdn_Grid_Disable.Value = "";
            }
            else
            {

                btnDelete.Enabled = false;
                btnLicense_Delete.Enabled = false;
                btnDelete.ToolTip = "You don't have permission to access";
                btnLicense_Delete.ToolTip = "You don't have permission to access";
                //hdn_Grid_Disable.Value = "1";
            }
        }
        //if (hdn_Grid_Disable.Value == "1")
        //    gv_License.ToolTip = "You don't have permission to access";
    }
    public void Gridbind_License()
    {

        Export_license.LICENSE_ID = "0";
        Export_license.JOB_NO = EXPORT_JOBNO;
        Export_license.INV_SL_NO = INV_SLN0;
        Export_license.ITEM_SL_NO = ITEM_SLNO;
        Export_license.SCHEME_CODE = SCHEME_CODE;
        Export_license.SCHEME = SCHEME;
        Export_license.WORKING_PERIOD = SELECT_BRANCH;

        Export_license.Ename = "select_con";
        ds = Export_license.Export_License_Details_Select();

        // ----Audit Modified Data -----------------------------------
        if (Audit_YN == "Y")
        {
            DataTable dt_main = ds.Tables[0].Clone();
            ViewState["dt_Main"] = dt_main;
        }

        Grid__License_Empty();
    }

    public void Gridbind_License_Imp_Exp()
    {
        //Export_license.LICENSE_IMP_EXP_ID = "0";
        Export_license.LICENSE_IMP_EXP_ID = ViewState["LICENSE_ID"].ToString();

        Export_license.JOB_NO = EXPORT_JOBNO;
        Export_license.LICENSE_NO = hdn_License_no.Value;

        //Export_license.ITEM_SL_NO = ITEM_SLNO;
        //Export_license.SCHEME_CODE = SCHEME_CODE;

        Export_license.WORKING_PERIOD = SELECT_BRANCH;

        Export_license.Ename = "select_con";
        dss = Export_license.Export_License_Imp_Exp_Details_Select();

        // ----Audit Modified Data -----------------------------------
        if (Audit_YN == "Y")
        {
            DataTable dt_IMP_EXP = dss.Tables[0].Clone();
            ViewState["dt_IMP_EXP"] = dt_IMP_EXP;
        }

        Grid__License_Imp_Exp_Empty();
    }

    public void Grid__License_Empty()
    {
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                gv_License.DataSource = ds;
                gv_License.DataBind();
            }
            else
            {
                gv_License.DataSource = dt;//add empty row
                gv_License.DataBind();
            }
        }
        else
        {
            gv_License.DataSource = dt;//add empty row
            gv_License.DataBind();
        }
    }

    public void Grid__License_Imp_Exp_Empty()
    {
        if (dss.Tables.Count > 0)
        {
            if (dss.Tables[0].Rows.Count > 0)
            {
                gv_License_Imp_Exp.DataSource = dss;
                gv_License_Imp_Exp.DataBind();
            }
            else
            {
                if (hdn_Import_Slno.Value.Length > 0)
                {
                    txtImport_Item_Sl_No.Text = hdn_Import_Slno.Value;
                }

                gv_License_Imp_Exp.DataSource = dt;//add empty row
                gv_License_Imp_Exp.DataBind();
            }
        }
        else
        {
            gv_License_Imp_Exp.DataSource = dt;//add empty row
            gv_License_Imp_Exp.DataBind();
        }
    }


    public void License_Imp_Exp_Details_insert_update(string License_Imp_Exp_ID, string flag, string year)
    {
        //---------------------SCHEME CODE TO SAVE IN LICENSE DETAILS----------------------------------------//
        //string SCHEME = "";
        //if (Session["SCHEME_CODE"] != null)
        //{
        //    SCHEME = Session["SCHEME_CODE"].ToString();
        //}
        //else
        //{
        //    SCHEME = "";
        //}
        //---------------------SCHEME CODE TO SAVE IN LICENSE DETAILS----------------------------------------//

        Export_license.LICENSE_IMP_EXP_ID = License_Imp_Exp_ID;
        Export_license.JOB_NO = EXPORT_JOBNO;

        Export_license.INV_SL_NO = INV_SLN0;
        Export_license.ITEM_SL_NO = ITEM_SLNO;
        Export_license.SCHEME = SCHEME;

        Export_license.LICENSE_R_SL_NO = hdn_reg_sl_no.Value;
        Export_license.LICENSE_NO = hdn_License_no.Value;
        Export_license.LICENSE_E_SL_NO = txtExport_Item_Sl_No.Text;
        Export_license.LICENSE_EXP_QTY = txtExport_Qty.Text;
        Export_license.LICENSE_EXP_UNIT = lblQtyCode.Text;
        Export_license.LICENSE_IMP_ITEM_SL_NO = txtImport_Item_Sl_No.Text;
        Export_license.LICENSE_IMP_DESC = txtDescription.Text;
        Export_license.LICENSE_IMP_QTY = txtImport_Qty.Text;
        Export_license.LICENSE_IMP_UNIT = txtImport_Unit.Text;


        if (ddlNM.SelectedValue == "Indigenous")
        {
            NM = "N";
        }
        else if (ddlNM.SelectedValue == "Imported")
        {
            NM = "M";
        }

        Export_license.LICENSE_IMP_TYPE = NM;

        Export_license.AMENDMENT_TYPE = ddl_AmendmentType.SelectedValue;
        Export_license.AMENDMENT_STATUS = "";


        Export_license.USER_ID = currentuser;
        Export_license.BRANCH_CODE = currentbranch;
        Export_license.AFlag = flag;
        Export_license.YEAR = year;
        Export_license.WORKING_PERIOD = Working_Period;
        Export_license.BRANCH_COMMON = SELECT_BRANCH;

        //dss = Export_license.Export_License_Imp_Exp_Details_Insert_Update();
        //Grid__License_Imp_Exp_Empty();
        gv_License_Imp_Exp.DataSource = Export_license.Export_License_Imp_Exp_Details_Insert_Update();
        gv_License_Imp_Exp.DataBind();
        i = Export_license.result;
        Exp_Gen.Exp_Job_Logs_All_Details(EXPORT_JOBNO, INV_SLN0, ITEM_SLNO, "License_Imp_Exp", flag, "Insert");
        if (hdn_NM_type.Value != "")
        {
            ddlNM.Items.Clear();

            ddlNM.Items.Add("Indigenous");
            ddlNM.Items.Add("Imported");

            string a = "";
            if (hdn_NM_type.Value == "N")
            {
                a = "Indigenous";
            }
            else if (hdn_NM_type.Value == "M")
            {
                a = "Imported";
            }
            ddlNM.Items.Remove(a);
            ddlNM.Items.Insert(0, a);
        }
    }

    public void License_Details_insert_update(string License_ID, string License_Date, string flag, string year)
    {

        //---------------------SCHEME CODE TO SAVE IN LICENSE DETAILS----------------------------------------//
        //string SCHEME = "";

        DataTable dt_imp_exp_lic = new DataTable();
        DataTable selectedTable = new DataTable();

        dt_imp_exp_lic.Columns.Add("LICENSE_IMP_EXP_ID");
        dt_imp_exp_lic.Columns.Add("LICENSE_ID");
        dt_imp_exp_lic.Columns.Add("JOB_NO");
        dt_imp_exp_lic.Columns.Add("LICENSE_REG_SLNO");
        dt_imp_exp_lic.Columns.Add("LICENSE_NO");
        dt_imp_exp_lic.Columns.Add("LICENSE_E_SL_NO");
        dt_imp_exp_lic.Columns.Add("LICENSE_EXP_QTY");
        dt_imp_exp_lic.Columns.Add("LICENSE_EXP_UNIT");
        dt_imp_exp_lic.Columns.Add("LICENSE_IMP_ITEM_SL_NO");
        dt_imp_exp_lic.Columns.Add("LICENSE_IMP_DESC");
        dt_imp_exp_lic.Columns.Add("LICENSE_IMP_QTY");
        dt_imp_exp_lic.Columns.Add("LICENSE_IMP_UNIT");
        dt_imp_exp_lic.Columns.Add("LICENSE_IMP_TYPE");
        dt_imp_exp_lic.Columns.Add("USER_ID");
        //dt_imp_exp_lic.Columns.Add("DATE_TIME", typeof(DateTime));
        dt_imp_exp_lic.Columns.Add("DATE_TIME");
        dt_imp_exp_lic.Columns.Add("STATUS");
        dt_imp_exp_lic.Columns.Add("BRANCH_CODE");
        dt_imp_exp_lic.Columns.Add("YEAR");
        dt_imp_exp_lic.Columns.Add("WORKING_PERIOD");
        dt_imp_exp_lic.Columns.Add("INV_SL_NO");
        dt_imp_exp_lic.Columns.Add("ITEM_SL_NO");
        dt_imp_exp_lic.Columns.Add("SCHEME");
        dt_imp_exp_lic.Columns.Add("MODIFIEDBY");
        dt_imp_exp_lic.Columns.Add("MODIFIEDON");
        dt_imp_exp_lic.Columns.Add("AMENDMENT_TYPE");
        dt_imp_exp_lic.Columns.Add("AMENDMENT_STATUS");

        if (Session["SCHEME_CODE"] != null)
        {
            SCHEME_CODE = Session["SCHEME_CODE"].ToString();
        }
        else
        {
            SCHEME_CODE = "";
        }
        //---------------------SCHEME CODE TO SAVE IN LICENSE DETAILS----------------------------------------//

        Export_license.LICENSE_ID = License_ID;
        Export_license.JOB_NO = EXPORT_JOBNO;
        Export_license.INV_SL_NO = INV_SLN0;
        Export_license.ITEM_SL_NO = ITEM_SLNO;
        Export_license.SCHEME_CODE = SCHEME_CODE;
        Export_license.SCHEME = SCHEME;
        Export_license.LICENSE_R_SL_NO = txtRegn_Sl_No.Text;
        Export_license.LICENSE_NO = txtLicenseNo.Text;
        Export_license.LICENSE_DATE = License_Date;

        Export_license.USER_ID = currentuser;
        Export_license.BRANCH_CODE = currentbranch;
        Export_license.AFlag = flag;
        Export_license.YEAR = year;
        Export_license.WORKING_PERIOD = Working_Period;

        Export_license.BRANCH_COMMON = SELECT_BRANCH;
        Export_license.JOBNO_PS = Session["JOBNO_PS"].ToString();
        //dss = Export_license.Export_License_Details_Insert_Update();
        //Grid__License_Empty();

        ds_license = Export_license.Export_License_Details_Insert_Update();

        gv_License.DataSource = ds_license;
        gv_License.DataBind();
        i = Export_license.result;

        if (ds_license.Tables[0].Rows.Count > 0)
        {
            selectedTable = ds_license.Tables[0].AsEnumerable()
                                    .Where(r => r.Field<string>("LICENSE_NO") == txtLicenseNo.Text && r.Field<string>("SCHEME") == SCHEME)
                                    .CopyToDataTable();
        }

        if (selectedTable.Rows.Count > 0)
        {
            Export_license.LICENSE_IMP_EXP_ID = selectedTable.Rows[0]["LICENSE_ID"].ToString();
            Export_license.JOB_NO = EXPORT_JOBNO;
            Export_license.LICENSE_NO = selectedTable.Rows[0]["LICENSE_NO"].ToString();

            Export_license.WORKING_PERIOD = SCHEME;

            Export_license.Ename = "Select_License_Details_IMP_EXP";
            DataSet ds_IMP_EXP = Export_license.Export_License_Imp_Exp_Details_Select();

            string loging_date = Convert.ToDateTime(LoginDate).ToShortDateString();
            string login_date1 = string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(loging_date));

            int count = ds_IMP_EXP.Tables[0].Rows.Count;

            Get_LICENSE_IMP_EXP_MaxID();

            if (count > 0)
            {
                for (int ii = 0; ii <= count - 1; ii++)
                {
                    //Check_IMP_EXP_Available(txtLicenseNo.Text, EXPORT_JOBNO, License_ID);

                    Export_license.LICENSE_IMP_EXP_ID = selectedTable.Rows[0]["LICENSE_ID"].ToString();
                    Export_license.JOB_NO = EXPORT_JOBNO;

                    Export_license.INV_SL_NO = selectedTable.Rows[0]["INV_SL_NO"].ToString();
                    Export_license.ITEM_SL_NO = selectedTable.Rows[0]["ITEM_SL_NO"].ToString();
                    Export_license.SCHEME = selectedTable.Rows[0]["SCHEME"].ToString();

                    //Export_license.LICENSE_R_SL_NO = hdn_reg_sl_no.Value;
                    Export_license.LICENSE_NO = selectedTable.Rows[0]["LICENSE_NO"].ToString();
                    //Export_license.LICENSE_E_SL_NO = txtExport_Item_Sl_No.Text;

                    if (ds_IMP_EXP.Tables[0].Rows[ii]["LICENSE_EXP_ITEM_SLNO"].ToString() != "")
                    {
                        Export_license.LICENSE_E_SL_NO = ds_IMP_EXP.Tables[0].Rows[ii]["LICENSE_EXP_ITEM_SLNO"].ToString();
                    }
                    else
                    {
                        Export_license.LICENSE_E_SL_NO = txtExport_Item_Sl_No.Text;
                    }

                    //Export_license.LICENSE_EXP_QTY = txtExport_Qty.Text;
                    //Export_license.LICENSE_EXP_UNIT = lblQtyCode.Text;
                    Export_license.LICENSE_IMP_ITEM_SL_NO = ds_IMP_EXP.Tables[0].Rows[ii]["LICENSE_ITEM_SL_NO"].ToString();
                    //Export_license.LICENSE_IMP_DESC = txtDescription.Text;
                    //Export_license.LICENSE_IMP_QTY = txtImport_Qty.Text;
                    //Export_license.LICENSE_IMP_UNIT = txtImport_Unit.Text;

                    string Lic_Imp_Qty = "";
                    if (Connection.COMPANYID() == "1" || Connection.COMPANYID() == "4" || Connection.COMPANYID() == "5" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "2099" || Connection.COMPANYID() == "3181" || Connection.COMPANYID() == "3200" || Connection.COMPANYID() == "4004" || Connection.COMPANYID() == "4005")
                    {
                        string TotExp_Qty = ds_IMP_EXP.Tables[0].Rows[ii]["LICENSE_EXP_QTY"].ToString();
                        string TotImp_Qty = ds_IMP_EXP.Tables[0].Rows[ii]["LICENSE_QTY"].ToString();

                        if (TotExp_Qty != "" && TotImp_Qty != "" && txtExport_Qty.Text != "")
                        {
                            double Imp_Qty1 = Convert.ToDouble(TotImp_Qty) / Convert.ToDouble(TotExp_Qty) * Convert.ToDouble(txtExport_Qty.Text);
                            Lic_Imp_Qty = Convert.ToString(Math.Round(Convert.ToDouble(Imp_Qty1), 1).ToString("0.00"));
                        }
                    }
                    else
                    {
                        Lic_Imp_Qty = ds_IMP_EXP.Tables[0].Rows[ii]["LICENSE_QTY"].ToString();
                    }

                    Export_license.LICENSE_IMP_QTY = Lic_Imp_Qty;
                    //if (ddlNM.SelectedValue == "Indigenous")
                    //{
                    //    NM = "N";
                    //}
                    //else if (ddlNM.SelectedValue == "Imported")
                    //{
                    //    NM = "M";
                    //}

                    //Export_license.LICENSE_IMP_TYPE = NM;

                    Export_license.USER_ID = currentuser;
                    Export_license.BRANCH_CODE = currentbranch;
                    Export_license.AFlag = "Check_LICENSE_IMP_EXP_DETAILS";
                    Export_license.YEAR = year;
                    Export_license.WORKING_PERIOD = Working_Period;
                    Export_license.BRANCH_COMMON = SELECT_BRANCH;
                    dss = Export_license.Export_License_Imp_Exp_Details_Insert_Update();

                    if (dss.Tables[0].Rows.Count == 0)
                    {
                        dt_imp_exp_lic.Rows.Add(License_id_IMP_EXP_Max, selectedTable.Rows[0]["LICENSE_ID"].ToString(), EXPORT_JOBNO, selectedTable.Rows[0]["LICENSE_R_SL_NO"].ToString(), selectedTable.Rows[0]["LICENSE_NO"].ToString(), Export_license.LICENSE_E_SL_NO, txtExport_Qty.Text, lblQtyCode.Text, ds_IMP_EXP.Tables[0].Rows[ii]["LICENSE_ITEM_SL_NO"].ToString()
                                  , ds_IMP_EXP.Tables[0].Rows[ii]["LICENSE_ITEM_DESCRIPTION"].ToString(), Lic_Imp_Qty, ds_IMP_EXP.Tables[0].Rows[ii]["LICENSE_UNIT"].ToString(), ds_IMP_EXP.Tables[0].Rows[ii]["LICENSE_TYPE"].ToString(), currentuser, login_date1, "S", currentbranch, " ", Working_Period
                                  , selectedTable.Rows[0]["INV_SL_NO"].ToString(), selectedTable.Rows[0]["ITEM_SL_NO"].ToString(), selectedTable.Rows[0]["SCHEME"].ToString(), " ", login_date1);

                        License_id_IMP_EXP_Max++;
                    }
                }
                if (dt_imp_exp_lic.Rows.Count > 0)
                {
                    MASTER_CONN = HttpContext.Current.Session["currentcomp_db"].ToString();
                    admin.SqlBulk_Upload_Product("EXPORT_LICENSE_IMP_EXP_DETAILS", dt_imp_exp_lic, MASTER_CONN);
                }
            }
        }

        if (hdn_NM_type.Value != "")
        {

            ddlNM.Items.Clear();

            ddlNM.Items.Add("Indigenous");
            ddlNM.Items.Add("Imported");

            string a = "";
            if (hdn_NM_type.Value == "N")
            {
                a = "Indigenous";
            }
            else if (hdn_NM_type.Value == "M")
            {
                a = "Imported";
            }

            ddlNM.Items.Remove(a);
            ddlNM.Items.Insert(0, a);
        }
    }

    public void Get_LICENSE_IMP_EXP_MaxID()
    {
        License_id_Max = 0;
        License_id_IMP_EXP_Max = 0;
        Export_license.LICENSE_NO = "0";
        Export_license.Ename = "GET_EXPORT_LICENSE_ID_MAX";

        ds = Export_license.Export_License_Master_Select();
        License_id_Max = Convert.ToInt32(ds.Tables[0].Rows[0]["LICENSE_ID"].ToString());
        License_id_IMP_EXP_Max = Convert.ToInt32(ds.Tables[1].Rows[0]["LICENSE_IMP_EXP_ID"].ToString());
    }

    public void Check_IMP_EXP_Available(string LICENSE_NO, string JOBNO, string LICENSE_ID)
    {
        Export_license.LICENSE_IMP_EXP_ID = LICENSE_ID;
        Export_license.JOB_NO = JOBNO;
        Export_license.LICENSE_NO = LICENSE_NO;
        Export_license.WORKING_PERIOD = SCHEME;
        Export_license.Ename = "Select_License_IMP_EXP_Details_Check";
        DataSet ds_IMP_EXP = Export_license.Export_License_Imp_Exp_Details_Select();
    }

    protected void btnLicense_Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(Request["Scheme"]))
            {
                LICENSE_ID = "";

                if (txtDate.Text == "")
                {
                    License_Date = "01/01/1900";
                }
                else
                {
                    License_Date = txtDate.Text;
                }
                FLAG = "S";
                YEAR = "";

                License_Details_insert_update(LICENSE_ID, License_Date, FLAG, YEAR);
                hdn_update_License.Value = Convert.ToString(Export_license.UPDATE_ID);
                hdn_License_no.Value = txtLicenseNo.Text;
                hdn_reg_sl_no.Value = txtRegn_Sl_No.Text;

                if (i == 1)
                {
                    if (COMPANY_ID == "10" || COMPANY_ID == "1096")//Magmar
                    {

                    }
                    Exp_Gen.Exp_Job_Logs_All_Details(EXPORT_JOBNO, INV_SLN0, ITEM_SLNO, "License_Imp_Exp", FLAG, "Insert");
                    Panel1.Enabled = true;
                    lblQtyCode.Visible = true;
                    txtExport_Qty.Text = Unit_Qty;

                    if (txtExport_Item_Sl_No.Text == "" && txtExport_Item_Sl_No.Text != "1")
                    {
                        txtExport_Item_Sl_No.Text = "1";
                    }
                    if (txtImport_Item_Sl_No.Text == "" && txtImport_Item_Sl_No.Text != "1")
                    {
                        txtImport_Item_Sl_No.Text = "1";
                    }

                    ViewState["LICENSE_ID"] = Export_license.UPDATE_ID.ToString();

                    Gridbind_License_Imp_Exp();

                    //mo.ResetFields(Page.Controls);

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);
                    //Gridbind_License();
                    btnLicense_Update.CssClass = "save";
                    btnLicense_Update.Visible = true;
                    btnLicense_Save.Visible = false;

                    btnLicense_Save.Focus();

                    ViewState["UPDATED_ID"] = null;
                    Alert_msg("License Saved Successfully", "btnLicense_Save");

                }
                else if (i == 2)
                {
                    Alert_msg("License No Already Exist", "btnLicense_Save");
                }
                else
                {
                    Panel1.Enabled = false;
                    lblQtyCode.Visible = false;
                    Alert_msg("License Not Saved", "btnLicense_Save");
                }
            }
            else
            {
                Alert_msg("Invalid SchemeCode");
            }
        }

        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    protected void gv_License_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_License.PageIndex = e.NewPageIndex;
        Gridbind_License();
    }
    protected void gv_License_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //Add CSS class on header row.
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        //Add CSS class on normal row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        //Add CSS class on alternate row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    protected void gv_License_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //  if Read Permiision given true for gridview enabled or Disabled----------//
            if (hdn_Grid_Disable.Value == "1")
            {
                e.Row.Enabled = false;
            }
            else
            {
                e.Row.Enabled = true;

                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                //e.Row.Attributes["onmouseout"] = "this.style.background='white'";
                e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_License, "Select$" + e.Row.RowIndex.ToString()));
            }
            //  if Read Permiision given true for gridview enabled or Disabled----------//

            string MINDATE = "01/01/1900";

            if (e.Row.Cells[3].Text == MINDATE)
            {
                if (Convert.ToDateTime(e.Row.Cells[3].Text) <= Convert.ToDateTime(MINDATE))
                    e.Row.Cells[3].Text = string.Empty;
            }

        }
    }
    protected void gv_License_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["LICENSE_ID"] = Convert.ToString(this.gv_License.SelectedDataKey.Value);

        if (ViewState["LICENSE_ID"] != "" && ViewState["LICENSE_ID"] != null)
        {
            //FOR UPDATED SUCCESSFULLY
            ViewState["UPDATED_ID"] = null;
            ViewState["UPDATED_ID"] = ViewState["LICENSE_ID"].ToString();
            hdn_update_License.Value = ViewState["LICENSE_ID"].ToString();

            //FOR UPDATED SUCCESSFULLY
            btnLicense_Update.CssClass = "updates";
            btnLicense_Delete.Visible = true;
            btnLicense_Update.Visible = true;
            btnLicense_Save.Visible = false;

            txtRegn_Sl_No.Text = gv_License.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            txtLicenseNo.Text = gv_License.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            txtDate.Text = gv_License.SelectedRow.Cells[3].Text.Replace("01/01/1900", "");

            Panel1.Enabled = true;
            lblQtyCode.Visible = true;

            hdn_reg_sl_no.Value = gv_License.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            hdn_License_no.Value = gv_License.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");

            // ----Audit Modified Data -----------------------------------
            if (Audit_YN == "Y")
            {
                DataTable_Mapping_Controls_Main((DataTable)ViewState["dt_Main"]);
            }

            Gridbind_License_Imp_Exp();
            btnNew_Click(sender, e);
        }
        else
        {
            Panel1.Enabled = false;
            lblQtyCode.Visible = false;
            btnLicense_Delete.Visible = false;
            btnLicense_Update.Visible = false;
            btnLicense_Save.Visible = true;
        }
    }

    protected void btnLicense_Update_Click(object sender, EventArgs e)
    {
        try
        {
            //LICENSE_ID = ViewState["LICENSE_ID"].ToString();
            LICENSE_ID = hdn_update_License.Value;

            if (txtDate.Text == "")
            {
                License_Date = "01/01/1900";
            }
            else
            {
                License_Date = txtDate.Text;
            }
            FLAG = "U";
            YEAR = "";

            License_Details_insert_update(LICENSE_ID, License_Date, FLAG, YEAR);
            hdn_License_no.Value = txtLicenseNo.Text;
            hdn_reg_sl_no.Value = txtRegn_Sl_No.Text;

            if (i == 1)
            {

                //Common Logs
                Exp_Gen.Exp_Job_Logs_All_Details(EXPORT_JOBNO, INV_SLN0, ITEM_SLNO, "License", FLAG, "Insert");

                // ----Audit Modified Data -----------------------------------
                if (Audit_YN == "Y")
                {
                    Audit_Modified_DataTableComparer("LICENSE_ID", (DataTable)ViewState["dt_Main"], "License");
                }

                if (ViewState["UPDATED_ID"] != null)
                {
                    Alert_msg("License Updated Successfully", "btnLicense_Update");
                }
                else
                {
                    Alert_msg("License Saved Successfully", "btnLicense_Update");
                }
            }
            else
            {
                Alert_msg("License Not Saved", "btnLicense_Update");
            }
        }

        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    protected void btnLicense_Delete_Click(object sender, EventArgs e)
    {
        try
        {

            Export_license.JOB_NO = EXPORT_JOBNO;

            Export_license.INV_SL_NO = INV_SLN0;
            Export_license.ITEM_SL_NO = ITEM_SLNO;
            Export_license.LICENSE_ID = ViewState["LICENSE_ID"].ToString();
            Export_license.WORKING_PERIOD = SELECT_BRANCH;
            Export_license.Ename = "delete";
            //dss = Export_license.Export_License_Details_Select();
            gv_License.DataSource = Export_license.Export_License_Details_Select();
            gv_License.DataBind();
            int ii = 0;
            ii = Export_license.result;

            if (ii > 0)
            {
                if (COMPANY_ID == "10" || COMPANY_ID == "1096")//Magmar
                {

                }
                btnLicense_New_Click(sender, e);
                Alert_msg("License Deleted");
                Exp_Gen.Exp_Job_Logs_All_Details(EXPORT_JOBNO, INV_SLN0, ITEM_SLNO, "License_Imp_Exp", "D", "Insert");
            }
            else
            {
                Alert_msg("License Not Deleted");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

        Gridbind_License();
        Gridbind_License_Imp_Exp();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(Request["Scheme"]))
            {
                //save License details Id
                LICENSE_IMP_EXP_ID = hdn_update_License.Value;
                FLAG = "S";
                YEAR = "";

                License_Imp_Exp_Details_insert_update(LICENSE_IMP_EXP_ID, FLAG, YEAR);
                // hdn_update_License_Imp_Exp.Value = Convert.ToString(Transact.UPDATE_ID);
                hdn_update_License_Imp_Exp.Value = Convert.ToString(Export_license.UPDATE_ID);

                if (i == 1)
                {
                    if (COMPANY_ID == "10" || COMPANY_ID == "1096")//Magmar
                    {

                    }
                    Exp_Gen.Exp_Job_Logs_All_Details(EXPORT_JOBNO, INV_SLN0, ITEM_SLNO, "License_Imp_Exp", FLAG, "Insert");
                    btnNew.Visible = true;
                    btnSave.Visible = true;      // hide Save
                    btnSaveNew.Visible = true;   // hide Save & New
                    btnUpdate.Visible = false;     // show Update
                    btnUpdate.CssClass = "updates";
                    btnDelete.Visible = false;     // show Delete

                    btnSave.Focus();

                    ViewState["UPDATED_ID_Imp_Exp"] = null;
                    Alert_msg("License Imp_Exp Saved Successfully", "btnSave");
                }
                else if (i == 2)
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Not Saved, Invoice No Already Exist')</script>", false);
                    Alert_msg("License Imp_Exp Already Exist...", "btnSave");
                }
                else
                {
                    Alert_msg("License Imp_Exp Not Saved", "btnSave");
                }
            }
            else
            {
                Alert_msg("Invalid SchemeCode");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    protected void btnSaveNew_Click(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(Request["Scheme"]))
            {
                LICENSE_IMP_EXP_ID = hdn_update_License.Value;
                FLAG = "S";
                YEAR = "";

                License_Imp_Exp_Details_insert_update(LICENSE_IMP_EXP_ID, FLAG, YEAR);
                hdn_update_License_Imp_Exp.Value = Convert.ToString(Export_license.UPDATE_ID);

                if (i == 1)
                {
                    Exp_Gen.Exp_Job_Logs_All_Details(EXPORT_JOBNO, INV_SLN0, ITEM_SLNO, "License_Imp_Exp", FLAG, "Insert");
                    Alert_msg("License Imp_Exp Saved Successfully", "btnSaveNew");
                    btnNew.Visible = true;
                    btnSave.Visible = true;         // show Save
                    btnSaveNew.Visible = true;      // show Save & New
                    btnUpdate.Visible = false;      // hide Update
                    btnDelete.Visible = false;      // hide Delete
                    // Trigger New after save
                    btnNew_Click(sender, e);
                }
                else if (i == 2)
                {
                    Alert_msg("License Imp_Exp Already Exist...", "btnSaveNew");
                }
                else
                {
                    Alert_msg("License Imp_Exp Not Saved", "btnSaveNew");
                }
            }
            else
            {
                Alert_msg("Invalid SchemeCode");
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
            //LICENSE_IMP_EXP_ID = ViewState["LICENSE_IMP_EXP_ID"].ToString();
            LICENSE_IMP_EXP_ID = hdn_update_License_Imp_Exp.Value;

            FLAG = "U";
            YEAR = "";

            License_Imp_Exp_Details_insert_update(LICENSE_IMP_EXP_ID, FLAG, YEAR);

            if (i == 1)
            {
                Exp_Gen.Exp_Job_Logs_All_Details(EXPORT_JOBNO, INV_SLN0, ITEM_SLNO, "License_Imp_Exp", FLAG, "Insert");

                // ----Audit Modified Data -----------------------------------
                if (Audit_YN == "Y")
                {
                    Audit_Modified_DataTableComparer("LICENSE_IMP_EXP_ID", (DataTable)ViewState["dt_IMP_EXP"], "License_Imp_Exp");
                }

                if (COMPANY_ID == "10" || COMPANY_ID == "1096")//Magmar
                {

                }
                Exp_Gen.Exp_Job_Logs_All_Details(EXPORT_JOBNO, INV_SLN0, ITEM_SLNO, "License_Imp_Exp", FLAG, "Insert");
                if (ViewState["UPDATED_ID_Imp_Exp"] != null)
                {
                    Alert_msg("License Imp_Exp Updated Successfully", "btnUpdate");
                }
                else
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>event.preventDefault();alert('Saved Successfully')</script>", false);
                    Alert_msg("License Imp_Exp Saved Successfully", "btnUpdate");
                }

            }
            //else if (i == 2)
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Not Saved, Invoice No Already Exist')</script>", false);
            //}
            else
            {
                Alert_msg("License Imp_Exp Not Saved", "btnUpdate");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            Export_license.JOB_NO = EXPORT_JOBNO;
            Export_license.LICENSE_IMP_EXP_ID = ViewState["LICENSE_IMP_EXP_ID"].ToString();
            Export_license.WORKING_PERIOD = SELECT_BRANCH;
            Export_license.LICENSE_NO = hdn_License_no.Value;
            Export_license.Ename = "delete";
            //dss = Export_license.Export_License_Imp_Exp_Details_Select();
            //Grid__License_Imp_Exp_Empty();
            gv_License_Imp_Exp.DataSource = Export_license.Export_License_Imp_Exp_Details_Select();
            gv_License_Imp_Exp.DataBind();
            int ii = 0;
            ii = Export_license.result;

            if (ii == 1)
            {
                if (COMPANY_ID == "10" || COMPANY_ID == "1096")//Magmar
                {

                }

                btnNew_Click(sender, e);
                Alert_msg("License Imp_Exp Deleted");
                Exp_Gen.Exp_Job_Logs_All_Details(EXPORT_JOBNO, INV_SLN0, ITEM_SLNO, "License_Imp_Exp", "D", "Insert");
                lblQtyCode.Visible = false;
                if (gv_License_Imp_Exp.Rows.Count == 0)
                    Panel1.Enabled = false;
            }
            else
            {
                Panel1.Enabled = true;
                lblQtyCode.Visible = true;
                Alert_msg("License Imp_Exp Not Deleted");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    protected void gv_License_Imp_Exp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_License_Imp_Exp.PageIndex = e.NewPageIndex;
        Gridbind_License_Imp_Exp();
    }
    protected void gv_License_Imp_Exp_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //Add CSS class on header row.
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        //Add CSS class on normal row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        //Add CSS class on alternate row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    protected void gv_License_Imp_Exp_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //string MINDATE = "01/01/1900";
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            //e.Row.Attributes["onmouseout"] = "this.style.background='white'";
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_License_Imp_Exp, "Select$" + e.Row.RowIndex.ToString()));
        }
    }
    protected void gv_License_Imp_Exp_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["LICENSE_IMP_EXP_ID"] = Convert.ToString(this.gv_License_Imp_Exp.SelectedDataKey.Value);

        if (ViewState["LICENSE_IMP_EXP_ID"] != "" && ViewState["LICENSE_IMP_EXP_ID"] != null)
        {
            //FOR UPDATED SUCCESSFULLY
            ViewState["UPDATED_ID_Imp_Exp"] = null;
            ViewState["UPDATED_ID_Imp_Exp"] = ViewState["LICENSE_IMP_EXP_ID"].ToString();
            hdn_update_License_Imp_Exp.Value = ViewState["LICENSE_IMP_EXP_ID"].ToString();

            //FOR UPDATED SUCCESSFULLY
            btnUpdate.CssClass = "updates";

            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnNew.Visible = true;
            btnSaveNew.Visible = false;
            Date_Time rep = new Date_Time();

            if (!string.IsNullOrEmpty(Session["SB_NO"].ToString()))
            {
                div_AmendmentType.Visible = true;
                ddl_AmendmentType.SelectedValue = gv_License_Imp_Exp.SelectedRow.Cells[11].Text.Replace("&nbsp;", "");
            }


            txtExport_Item_Sl_No.Text = gv_License_Imp_Exp.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");

            txtExport_Qty.Text = gv_License_Imp_Exp.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");

            lblQtyCode.Text = gv_License_Imp_Exp.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");

            txtImport_Item_Sl_No.Text = gv_License_Imp_Exp.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");

            //txtDescription.Text = rep.Replace(gv_License_Imp_Exp.SelectedRow.Cells[7].Text);

            //txtImport_Qty.Text = gv_License_Imp_Exp.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");

            //txtImport_Unit.Text = gv_License_Imp_Exp.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");

            //NM = gv_License_Imp_Exp.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");

            txtDescription.Text = rep.Replace(gv_License_Imp_Exp.SelectedRow.Cells[10].Text);

            txtImport_Qty.Text = gv_License_Imp_Exp.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");

            txtImport_Unit.Text = gv_License_Imp_Exp.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");


            NM = gv_License_Imp_Exp.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");

            ddlNM.Items.Clear();

            if (NM == "N")
            {
                DDlNM = "Indigenous";
            }
            else if (NM == "M")
            {
                DDlNM = "Imported";
            }

            ddlNM.Items.Add("Indigenous");
            ddlNM.Items.Add("Imported");

            ddlNM.Items.Remove(DDlNM);
            ddlNM.Items.Insert(0, DDlNM);

            // ----Audit Modified Data -----------------------------------
            if (Audit_YN == "Y")
            {
                DataTable_Mapping_Controls((DataTable)ViewState["dt_IMP_EXP"]);
            }

        }
        else
        {
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnNew.Visible = false;
        }
    }

    protected void btnLicense_New_Click(object sender, EventArgs e)
    {
        Transact.ResetFields(Page.Controls);
        btnLicense_Delete.Visible = false;
        btnLicense_Update.Visible = false;
        btnLicense_Save.Visible = true;
        btnLicense_Update.CssClass = "updates";

        ViewState["UPDATED_ID"] = null;
        hdn_update_License.Value = "";
        Panel1.Enabled = false;
        lblQtyCode.Visible = false;
        txtExport_Qty.Text = Unit_Qty;

        if (txtExport_Item_Sl_No.Text == "" && txtExport_Item_Sl_No.Text != "1")
        {
            txtExport_Item_Sl_No.Text = "1";
        }
        if (txtImport_Item_Sl_No.Text == "" && txtImport_Item_Sl_No.Text != "1")
        {
            txtImport_Item_Sl_No.Text = "1";
        }

        if (txtRegn_Sl_No.Text == "")
        {
            txtRegn_Sl_No.Text = Convert.ToInt32(gv_License.Rows.Count + 1).ToString();
        }

        btnNew_Click(sender, e);
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        string Exp_qty = "", Exp_slno = "";
        Exp_slno = txtExport_Item_Sl_No.Text;
        Exp_qty = txtExport_Qty.Text;
        //Transact.ResetFields(Page.Controls);
        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnSave.Visible = true;
        btnNew.Visible = true;
        btnSaveNew.Visible = true;
        btnUpdate.CssClass = "updates";

        ViewState["UPDATED_ID_Imp_Exp"] = null;
        hdn_update_License_Imp_Exp.Value = "";
        txtExport_Item_Sl_No.Text = Exp_slno;
        txtExport_Qty.Text = Exp_qty;

        txtImport_Qty.Text = "";
        txtDescription.Text = "";

        if (txtExport_Item_Sl_No.Text == "" && txtExport_Item_Sl_No.Text != "1")
        {
            txtExport_Item_Sl_No.Text = "1";
        }
        if (txtImport_Item_Sl_No.Text == "" && txtImport_Item_Sl_No.Text != "1")
        {
            txtImport_Item_Sl_No.Text = "1";
        }


        if (hdn_update_License.Value != "")
        {
            if (gv_License_Imp_Exp.Rows.Count > 0)
            {
                int i = gv_License_Imp_Exp.Rows.Count;
                i = i + 1;
                txtImport_Item_Sl_No.Text = Convert.ToString(i);
            }
        }
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'LICENSE', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'LICENSE', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    [System.Web.Services.WebMethod]
    public static string GetLicenseNo(string custid, string custid1)
    {

        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();
        // custid = Auto.Country_Master_FromClientSide_Calling(custid);
        Auto.Ename = "LICENSE_MASTER_SEARCH";
        Auto.Enamesearch = custid;
        Auto.NSearch = custid1;
        ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
        if (ds.Tables[0].Rows.Count > 0)
        {
            string Address1 = ds.Tables[0].Rows[0]["LICENSE_NO"].ToString();
            string Address2 = ds.Tables[0].Rows[0]["LICENSE_DATE"].ToString();
            string Address3 = ds.Tables[0].Rows[0]["LICENSE_R_SL_NO"].ToString();
            string Address4 = ds.Tables[0].Rows[0]["LICENSE_ITEM_SL_NO"].ToString();
            string Address5 = ds.Tables[0].Rows[0]["LICENSE_ITEM_DESCRIPTION"].ToString();
            string Address6 = ds.Tables[0].Rows[0]["LICENSE_QTY"].ToString();
            string Address7 = ds.Tables[0].Rows[0]["LICENSE_UNIT"].ToString();

            string Address8 = ds.Tables[0].Rows[0]["LICENSE_TYPE"].ToString();

            custid = Address1 + "~~" + Address2 + "~~" + Address3 + "~~" + Address4 + "~~" + Address5 + "~~" + Address6 + "~~" + Address7 + "~~" + Address8;
        }

        return custid;
    }

    protected void btn_ExpQty_all_Click(object sender, EventArgs e)
    {
        License_Imp_Exp_Details_insert_update(LICENSE_IMP_EXP_ID, "Update_ExpQty_All", YEAR);

    }


    #region Export Audit Logs

    private void Audit_Modified_DataTableComparer(string LIC_ID, DataTable dt_Prev_table, string loadGrid)
    {
        try
        {
            DataTable dt_Prev = dt_Prev_table;
            DataTable dt_m2 = dt_Prev.Clone();
            DataTable dt_modified = new DataTable();
            if (loadGrid == "License")
            {
                dt_modified = DataTable_Mapping_Controls_Main(dt_m2);
            }
            else
            {
                dt_modified = DataTable_Mapping_Controls(dt_m2);
            }
            DataTableComparer Dt_Change = new DataTableComparer();
            Dt_Change.GetMismatchedRowsFast_EXP(dt_Prev, dt_modified, LIC_ID, loadGrid, EXPORT_JOBNO, INV_SLN0, ITEM_SLNO, currentuser, currentbranch);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private DataTable DataTable_Mapping_Controls_Main(DataTable dt_mapping)
    {
        try
        {
            if (dt_mapping.Rows.Count > 0)
            {
                dt_mapping.Rows.Clear();
            }
            DataRow dr = dt_mapping.NewRow();

            dr["LICENSE_ID"] = ViewState["LICENSE_ID"].ToString();
            dr["JOB_NO"] = EXPORT_JOBNO;
            dr["INV_SL_NO"] = INV_SLN0;
            dr["ITEM_SL_NO"] = ITEM_SLNO;
            dr["SCHEME_CODE"] = SCHEME_CODE;
            dr["SCHEME"] = SCHEME;
            dr["LICENSE_R_SL_NO"] = hdn_reg_sl_no.Value;
            dr["LICENSE_NO"] = txtLicenseNo.Text;
            dr["LICENSE_DATE"] = txtDate.Text;

            dt_mapping.Rows.Add(dr);
            ViewState["dt_Main"] = dt_mapping;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return dt_mapping;
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

            dr["LICENSE_IMP_EXP_ID"] = hdn_update_License_Imp_Exp.Value;
            dr["LICENSE_ID"] = hdn_update_License.Value;
            dr["JOB_NO"] = EXPORT_JOBNO;
            dr["LICENSE_REG_SLNO"] = hdn_reg_sl_no.Value;
            dr["LICENSE_NO"] = txtLicenseNo.Text;

            dr["LICENSE_E_SL_NO"] = txtExport_Item_Sl_No.Text;
            dr["LICENSE_EXP_QTY"] = txtExport_Qty.Text;
            dr["LICENSE_EXP_UNIT"] = lblQtyCode.Text;

            dr["LICENSE_IMP_ITEM_SL_NO"] = txtImport_Item_Sl_No.Text;
            dr["LICENSE_IMP_DESC"] = txtDescription.Text;
            dr["LICENSE_IMP_QTY"] = txtImport_Qty.Text;
            dr["LICENSE_IMP_UNIT"] = txtImport_Unit.Text;
            dr["LICENSE_IMP_TYPE"] = ddlNM.SelectedValue;

            dr["INV_SL_NO"] = INV_SLN0;
            dr["ITEM_SL_NO"] = ITEM_SLNO;
            dr["SCHEME"] = SCHEME;
            dr["AMENDMENT_TYPE"] = ddl_AmendmentType.SelectedValue;

            dt_mapping.Rows.Add(dr);
            ViewState["dt_IMP_EXP"] = dt_mapping;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return dt_mapping;
    }

    #endregion

}