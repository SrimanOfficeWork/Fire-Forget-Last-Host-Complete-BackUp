using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Item_SingleWindow_Entry_2016 : ThemeClass
{
    //DataSet dss = new DataSet();
   
    DataTable dt = new DataTable();
    AppSession aps = new AppSession();
    User_Creation user_Create = new User_Creation();
    Export_General_New Export = new Export_General_New();
    EXP_SW_INFO_TYPE SW = new EXP_SW_INFO_TYPE();
    UserBO ObjUBO = new UserBO();
    ErrorLogs er = new ErrorLogs();

    public string currentuser, SELECT_BRANCH;

    public string EXPORT_JOBNO, SW_ID, FLAG;
    public string INVOICE_SLNO = "", ITEM_SLNO = "", INVOICE_NO = "" ,RITC_NO="";
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE;
    
    public int Screen_Id;
    public string JOB_LOCK, JOB_RELEASE;
    public int i;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();

            currentuser = Connection.Current_User();
            EXPORT_JOBNO = Session["EXPORT_JOBNO"].ToString();
            SELECT_BRANCH = Connection.Get_Company_Type();

            hdn_grid_scroll_retain.Value = "false";

            if (Request.QueryString["Item_slno"] != null)
            {
                hdn_Normal_Bulk.Value = "B";

                INVOICE_SLNO = Request.QueryString["Item_slno"].ToString();

                ITEM_SLNO = Request.QueryString["Item_slno"].ToString();
                RITC_NO = Request.QueryString["RITC_No"].ToString();
                Session["Q_Item_slno"] = Request.QueryString["Item_slno"].ToString();

                popupwindow_closebut_right_new.Visible = true;

                if (!IsPostBack)
                {
                    txt_RITCNO.Text = RITC_NO;
                    ViewState["txt_RITCNO"] = RITC_NO;

                    DataSet dss = new DataSet();
                    adminmaster Am = new adminmaster();
                    Am.SCHEME_IMPORT_CODE = RITC_NO;
                    Am.name = "Select_Info_Department";
                    dss = Am.IMP_Single_Window();

                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        lbl_avl_det.Text = dss.Tables[0].Rows[0]["Department"].ToString();
                        ddl_info_type.Items.Clear();

                        if (dss.Tables[1].Rows.Count > 0)
                        {
                            ddl_info_type.DataTextField = dss.Tables[1].Columns["Info_type_desc"].ToString();
                            ddl_info_type.DataValueField = dss.Tables[1].Columns["Info_type"].ToString();
                            ddl_info_type.DataSource = dss.Tables[1];
                            ddl_info_type.DataBind();
                        }
                        hdn_dept_code.Value = dss.Tables[2].Rows[0]["Department_Code"].ToString();

                        string[] arr = new string[] { };
                        arr = dss.Tables[2].Rows[0]["Department_Code"].ToString().Split(',');

                        var ee = from s in arr select s;
                        int c = ee.Count();
                        ddldept.Items.Clear();
                        for (int z = 0; z < ee.Count(); z++)
                        {
                            ddldept.Items.Add(new ListItem(arr[z], arr[z]));
                        }
                    }
                    else
                    {
                        lbl_avl_det.Text = "Not Applicable.";
                    }

                    ddl_info_type.Items.Add(new ListItem("PEC - PGA Exception category", "PEC"));
                    ddl_info_type.Items.Add(new ListItem("CHR - GST Allowed", "CHR"));
                    ddl_info_type.Items.Add(new ListItem("DIR - Directory", "DIR"));


                    if (Session["EXPORT_SBTYPE"] != null)
                    {
                        if (Session["EXPORT_SBTYPE"].ToString() == "SEZ")
                        {
                            ddldept.Items.Add("SEZ");
                            ddl_info_type.Items.Add(new ListItem("OTH - DTA Procurement", "OTH"));
                            //ddl_info_type.Items.Add(new ListItem("DIR - EX-BOND Shipping Bill", "DIR"));//hide on 27-01-2026

                            hdn_dept_code.Value = hdn_dept_code.Value == string.Empty ? "SEZ" : hdn_dept_code.Value + ",SEZ";
                        }
                    }

                    ddl_info_type.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                    ddl_info_type.SelectedIndex = 0;

                    //-----------------------Start-------------------------------------------------------
                    Screen_Id = 7;
                    Page_Rights(Screen_Id);
                    //----------------SETTING SCREEN PERMISSION---------------//

                    Gridbind_SW_INFO_TYPE();

                    btnDelete.Visible = false;
                    btnUpdate.Visible = false;
                    btnSave.Visible = true;
                    btnNew.Visible = true;
                    //-----------------------End----------------------------------------------------------
                }
            }
            else
            {
                hdn_Normal_Bulk.Value = "N";

                Session.Remove("Q_Item_slno");

                if (Session["ITEM_SLNO"] != null)
                {
                    if (Session["TRANSPORT_MODE"] != null)
                    {
                        hdfTransport_mode.Value = Session["TRANSPORT_MODE"].ToString();
                    }
                    INVOICE_SLNO = Session["Inv_SL_No"].ToString();
                    ITEM_SLNO = Session["Item_SLNo"].ToString();
                    INVOICE_NO = Session["Inv_NO"].ToString();


                    if (!IsPostBack)
                    {
                        load_RITC_NO();
                        //----------------SETTING SCREEN PERMISSION---------------//
                        Screen_Id = 7;
                        Page_Rights(Screen_Id);
                        //----------------SETTING SCREEN PERMISSION---------------//

                        Gridbind_SW_INFO_TYPE();

                        btnDelete.Visible = false;
                        btnUpdate.Visible = false;
                        btnSave.Visible = true;
                        btnNew.Visible = true;
                    }
                }
                else
                {
                    Response.Write("<script>window.parent.document.getElementById('ItemMain').click();</script>");
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
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        
    }

    private void load_RITC_NO()
    {
        try
        {
            DataSet ds = new DataSet();
            int CHR_Row_Count = 0;
            ObjUBO.JOBNO = EXPORT_JOBNO;
            ObjUBO.INVOICE_SLNO = INVOICE_SLNO;
            ObjUBO.ITEM_SLNO = ITEM_SLNO;
            ObjUBO.BRANCH_COMMON = SELECT_BRANCH;

            if (hdn_Normal_Bulk.Value == "B")
            {
                ObjUBO.Ename = "SW_Info_CTH_NO_Bulk";
            }
            else
            {
                ObjUBO.Ename = "SW_Info_CTH_NO";
            }

            ds = SW.SingleWindow_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txt_RITCNO.Text = ds.Tables[0].Rows[0]["CTH_NO"].ToString();
                ViewState["txt_RITCNO"] = ds.Tables[0].Rows[0]["CTH_NO"].ToString();

                DataSet dss = new DataSet();
                adminmaster Am = new adminmaster();
                Am.SCHEME_IMPORT_CODE = ds.Tables[0].Rows[0]["CTH_NO"].ToString();
                Am.name = "Select_Info_Department";
                dss = Am.IMP_Single_Window();
                if (dss.Tables[0].Rows.Count > 0)
                {
                    lbl_avl_det.Text = dss.Tables[0].Rows[0]["Department"].ToString();

                    ddl_info_type.Items.Clear();

                    if (dss.Tables[1].Rows.Count > 0)
                    {
                        //to Select Rows from Datatable(dtt) only "Y" values
                        var query = from t in dss.Tables[1].AsEnumerable()
                                    where t.Field<string>("Info_type").Equals("CHR")
                                    select t;

                        CHR_Row_Count = query.Count();

                        if (CHR_Row_Count == 0)
                        {
                            dss.Tables[1].Rows.Add("CHR", "CHR - Item Characteristics");
                            CHR_Row_Count = 1;
                        }

                        ddl_info_type.DataTextField = dss.Tables[1].Columns["Info_type_desc"].ToString();
                        ddl_info_type.DataValueField = dss.Tables[1].Columns["Info_type"].ToString();
                        ddl_info_type.DataSource = dss.Tables[1];
                        ddl_info_type.DataBind();
                    }
                    hdn_dept_code.Value = dss.Tables[2].Rows[0]["Department_Code"].ToString();
                }
                else
                {
                    lbl_avl_det.Text = "Not Applicable.";
                }
                if (dss.Tables[2].Rows.Count > 0)
                {
                    string[] arr = new string[] { };
                    arr = dss.Tables[2].Rows[0][0].ToString().Split(',');

                    var e = from s in arr select s;
                    int c = e.Count();
                    ddldept.Items.Clear();
                    for (int z = 0; z < e.Count(); z++)
                    {
                        ddldept.Items.Add(new ListItem(arr[z], arr[z]));
                    }
                }
            }
            else
            {
                txt_RITCNO.Text = string.Empty;
            }



            ddl_info_type.Items.Add(new ListItem("PEC - PGA Exception category", "PEC"));

            if (CHR_Row_Count == 0)
                ddl_info_type.Items.Add(new ListItem("CHR - Item Characteristics", "CHR"));
            ddl_info_type.Items.Add(new ListItem("DIR - Directory", "DIR"));


            CHR_Row_Count = 0;
            if (Session["EXPORT_SBTYPE"] != null)
            {
                if (Session["EXPORT_SBTYPE"].ToString() != "SEZ" && Session["IMP_EXP_TYPE"].ToString() == "HAND CARRIAGE" && Session["TRANSPORT_MODE"].ToString() == "Air") //HAND Condition done by pandiyan on 05-06-2025 for new implementation 
                {
                    ddldept.Items.Add("HAND");
                    ddl_info_type.Items.Add(new ListItem("DIR", "DIR"));
                    hdn_dept_code.Value = hdn_dept_code.Value == string.Empty ? "HAND" : hdn_dept_code.Value + ",HAND";
                }
                else if (Session["EXPORT_SBTYPE"].ToString() == "SEZ")
                {
                    ddldept.Items.Add("SEZ");
                    ddl_info_type.Items.Add(new ListItem("OTH - DTA Procurement", "OTH"));
                    //ddl_info_type.Items.Add(new ListItem("DIR - EX-BOND Shipping Bill", "DIR"));//hide on 27-01-2026
                    hdn_dept_code.Value = hdn_dept_code.Value == string.Empty ? "SEZ" : hdn_dept_code.Value + ",SEZ";
                    CHR_Row_Count = 1;
                }
            }

            ddl_info_type.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddl_info_type.SelectedIndex = 0;


            //--------------EX-BOND Shipping Bill - New Implementation on 21-09-2023 -- by Chithra
            if (ds.Tables[1].Rows.Count > 0)
            {
                ddldept.Items.Add(new ListItem("EX-BOND", "EX-BOND"));
                //if (CHR_Row_Count == 0)//hide on 27-01-2026
                //{
                //ddl_info_type.Items.Add(new ListItem("DIR - EX-BOND Shipping Bill", "DIR"));
                //ddl_info_type.Items.Insert(1, new ListItem(String.Empty, String.Empty));
                //ddl_info_type.SelectedIndex = 1;
                //}
            }
            //------------------------------------------------------------------------------------
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        
    }
   
    public void Page_Rights(int i)
    {
        try
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
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnNew.Enabled = false;
                btnNew.ToolTip = "You don't have permission to access";
                btnSave.ToolTip = "You don't have permission to access";
                btnUpdate.ToolTip = "You don't have permission to access";
                btnDelete.ToolTip = "You don't have permission to access";
                hdn_Grid_Disable.Value = "1";
            }
            else
            {
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
                {
                    btnUpdate.Enabled = true;
                    hdn_Grid_Disable.Value = "";
                }
                else
                {
                    btnUpdate.Enabled = false;
                    btnUpdate.ToolTip = "You don't have permission to access";
                    hdn_Grid_Disable.Value = "1";
                }
                //---------------DELETE BUTTON------------------//

                if (PAGE_DELETE == "True")
                {
                    btnDelete.Enabled = true;
                    hdn_Grid_Disable.Value = "";
                }
                else
                {
                    btnDelete.Enabled = false;
                    btnDelete.ToolTip = "You don't have permission to access";
                    hdn_Grid_Disable.Value = "1";
                }
            }
            if (hdn_Grid_Disable.Value == "1")
                gv_ReImport.ToolTip = "You don't have permission to access";
  
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public void Gridbind_SW_INFO_TYPE()
    {
        try
        {
            DataSet dss = new DataSet();
            ObjUBO.JOBNO = EXPORT_JOBNO;

            ObjUBO.INVOICE_SLNO = INVOICE_SLNO;
            ObjUBO.ITEM_SLNO = ITEM_SLNO;
            ObjUBO.BRANCH_COMMON = SELECT_BRANCH;

            if (hdn_Normal_Bulk.Value == "B")
            {
                ObjUBO.Ename = "Bulk_select";
            }
            else
            {
                ObjUBO.Ename = "Normal_Select";
            }
            dss = SW.SingleWindow_Select(ObjUBO);

            if (dss.Tables[0].Rows.Count > 0)
            {
                gv_ReImport.DataSource = dss;
                gv_ReImport.DataBind();
            }
            else
            {
                gv_ReImport.DataSource = dt;
                gv_ReImport.DataBind();
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
       
    }
   
    public void SW_INFO_TYPE_insert_update(string SW_ID, string flag)
    {
        try
        {
            ObjUBO.SW_ID = SW_ID;
            ObjUBO.JOBNO = EXPORT_JOBNO;
            ObjUBO.INVOICE_SLNO = INVOICE_SLNO;
            ObjUBO.ITEM_SLNO = ITEM_SLNO;
            ObjUBO.INFO_TYPE = ddl_info_type.SelectedValue.ToString();
            ObjUBO.INFO_QUALIFIER = ddl_Info_Qualifier.SelectedValue.ToString();
            if (ddl_info_type.SelectedValue == "DIR" && (ddl_Info_Qualifier.SelectedValue == "PNR" || ddl_Info_Qualifier.SelectedValue == "ETICKET" || ddl_Info_Qualifier.SelectedValue == "PASSPORT"))
            {
                ObjUBO.INFO_CODE = txt_Info_Code_Custom.Text;
            }
            else
            {
                ObjUBO.INFO_CODE = ddl_Info_Code.SelectedValue.ToString();
            }

            ObjUBO.INFO_TEXT = txt_Info_Text.Text;
            ObjUBO.INFO_MSR = txt_Info_Msr.Text;
            ObjUBO.INFO_UQC = txt_Info_Uqc.Text;
            ObjUBO.DEPARTMENT = ddldept.SelectedValue.ToString();
            ObjUBO.I_U_TYPE = hdn_Normal_Bulk.Value.ToString();

            ObjUBO.flag = flag;
            ObjUBO.Ename = hdn_Normal_Bulk.Value.ToString();
            ObjUBO.JOBID = txt_Sr_No.Text;

            SW.SW_INFOTYPE_Details_Insert_Update(ObjUBO);
            i = SW.result;

            hdn_grid_scroll_retain.Value = "true";
            Export.Exp_Job_Logs_All_Details(EXPORT_JOBNO, INVOICE_SLNO, ITEM_SLNO, "SW info Type", flag, "Insert");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
         
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            SW_ID = "";
            FLAG = "S";

            SW_INFO_TYPE_insert_update(SW_ID, FLAG);
            hdn_update_Reimport.Value = Convert.ToString(SW.UPDATE_ID);

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
                //-----------------------FOR USER RIGHTS--------------------------------//

                ViewState["UPDATED_ID"] = null;
                Alert_msg("SW InfoType Saved Successfully", "btnSave");

                Gridbind_SW_INFO_TYPE();
            }
            else
            {
                Alert_msg("SW InfoType Not Saved", "btnSave");
            }

        }

        catch (Exception ex)
        {
           Connection.Error_Msg(ex.Message);
        }
    }

    protected void gv_ReImport_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ViewState["SW_INFO_TYPE_ID"] = Convert.ToString(this.gv_ReImport.SelectedDataKey.Value);

            if (ViewState["SW_INFO_TYPE_ID"] != "" && ViewState["SW_INFO_TYPE_ID"] != null)
            {
                //FOR UPDATED SUCCESSFULLY
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = ViewState["SW_INFO_TYPE_ID"].ToString();
                hdn_update_Reimport.Value = ViewState["SW_INFO_TYPE_ID"].ToString();

                hdn_grid_scroll_retain.Value = "true";

                //FOR UPDATED SUCCESSFULLY
                btnUpdate.CssClass = "updates";
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = true;

                try
                {
                    ddldept.SelectedValue = gv_ReImport.SelectedRow.Cells[1].Text;
                    ddl_info_type.SelectedValue = gv_ReImport.SelectedRow.Cells[2].Text;

                    if (ddl_info_type.SelectedValue.ToString() == "PEC")
                    {
                        DataSet ds_ss = new DataSet();
                        adminmaster Am = new adminmaster();
                        Am.SCHEME_NOTN = "";
                        Am.SCHEME_IMPORT_CODE = ddl_info_type.SelectedValue.ToString();
                        Am.name = "Select_Info_Qualifier_PEC";
                        ds_ss = Am.IMP_Single_Window();

                        if (ds_ss.Tables[0].Rows.Count > 0)
                        {
                            ddl_Info_Qualifier.DataTextField = ds_ss.Tables[0].Columns["QF_Code"].ToString();
                            ddl_Info_Qualifier.DataValueField = ds_ss.Tables[0].Columns["QF_Code"].ToString();
                            ddl_Info_Qualifier.DataSource = ds_ss.Tables[0];
                            ddl_Info_Qualifier.DataBind();

                            ddl_Info_Qualifier.SelectedValue = gv_ReImport.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
                        }

                        if (ds_ss.Tables[1].Rows.Count > 0)
                        {
                            ddl_Info_Code.DataTextField = ds_ss.Tables[1].Columns["INFO_Code_desc"].ToString();
                            ddl_Info_Code.DataValueField = ds_ss.Tables[1].Columns["INFO_Code"].ToString();
                            ddl_Info_Code.DataSource = ds_ss.Tables[1];
                            ddl_Info_Code.DataBind();
                            ddl_Info_Code.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                            ddl_Info_Code.SelectedIndex = 0;

                            ddl_Info_Code.SelectedValue = gv_ReImport.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
                        }

                    }
                    else if (ddl_info_type.SelectedValue.ToString() == "DIR" && Session["IMP_EXP_TYPE"].ToString() == "HAND CARRIAGE")
                    {


                        DataSet ds_ss = new DataSet();
                        adminmaster Am = new adminmaster();
                        Am.SCHEME_NOTN = "";
                        Am.SCHEME_IMPORT_CODE = ddl_info_type.SelectedValue.ToString();
                        Am.name = "Select_Info_Qualifier_HAND";
                        ds_ss = Am.IMP_Single_Window();

                        if (ds_ss.Tables[0].Rows.Count > 0)
                        {
                            ddl_Info_Qualifier.DataTextField = ds_ss.Tables[0].Columns["QF_Code"].ToString();
                            ddl_Info_Qualifier.DataValueField = ds_ss.Tables[0].Columns["QF_Code"].ToString();
                            ddl_Info_Qualifier.DataSource = ds_ss.Tables[0];
                            ddl_Info_Qualifier.DataBind();

                            ddl_Info_Qualifier.SelectedValue = gv_ReImport.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
                        }

                    }
                    else if (ddl_info_type.SelectedValue.ToString() == "DIR")//EXBOND-SB
                    {

                        DataSet ds_ss = new DataSet();
                        adminmaster Am = new adminmaster();
                        Am.SCHEME_NOTN = "";
                        Am.SCHEME_IMPORT_CODE = ddl_info_type.SelectedValue.ToString();
                        Am.name = "Select_Info_Qualifier_DIR";
                        ds_ss = Am.IMP_Single_Window();

                        if (ds_ss.Tables[0].Rows.Count > 0)
                        {
                            ddl_Info_Qualifier.DataTextField = ds_ss.Tables[0].Columns["QF_Code"].ToString();
                            ddl_Info_Qualifier.DataValueField = ds_ss.Tables[0].Columns["QF_Code"].ToString();
                            ddl_Info_Qualifier.DataSource = ds_ss.Tables[0];
                            ddl_Info_Qualifier.DataBind();

                            ddl_Info_Qualifier.SelectedIndex = -1;
                        }

                        //--------------- WareHouse Master - User Wise ----08-07-2024-----
                        Auto_Search Auto = new Auto_Search();
                        DataSet ds = new DataSet();
                        DataTable dtWareHouse = new DataTable();
                        Auto.Ename = "WAREHOUSE_MASTER_USERWISE_SEARCH_SW";
                        ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();

                        dtWareHouse = ds_ss.Tables[1].Copy(); // Copy the Temp table
                        dtWareHouse.Merge(ds.Tables[0], true);// Merge the 2nd Table

                        if (dtWareHouse.Rows.Count > 0)
                        {
                            ddl_Info_Code.DataTextField = dtWareHouse.Columns["INFO_Code_desc"].ToString();
                            ddl_Info_Code.DataValueField = dtWareHouse.Columns["INFO_Code"].ToString();
                            ddl_Info_Code.DataSource = dtWareHouse;
                            ddl_Info_Code.DataBind();
                            ddl_Info_Code.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                            ddl_Info_Code.SelectedIndex = 0;

                            ddl_Info_Code.SelectedValue = gv_ReImport.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
                        }
                    }
                    else
                    {
                        ddl_Info_Qualifier.Items.Clear();
                        ddl_Info_Code.Items.Clear();

                        DataSet ds_s = new DataSet();
                        adminmaster Am = new adminmaster();
                        Am.SCHEME_NOTN = hdn_dept_code.Value.ToString();
                        Am.SCHEME_IMPORT_CODE = ddl_info_type.SelectedValue.ToString();
                        Am.name = "Select_Info_Qualifier";
                        ds_s = Am.IMP_Single_Window();


                        if (ds_s.Tables[0].Rows.Count > 0)
                        {
                            ddl_Info_Qualifier.DataTextField = ds_s.Tables[0].Columns["IFO_QFR_CODE_desc"].ToString();
                            ddl_Info_Qualifier.DataValueField = ds_s.Tables[0].Columns["IFO_QFR_CODE"].ToString();
                            ddl_Info_Qualifier.DataSource = ds_s.Tables[0];
                            ddl_Info_Qualifier.DataBind();
                            ddl_Info_Qualifier.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                            ddl_Info_Qualifier.SelectedIndex = 0;

                            ddl_Info_Qualifier.SelectedValue = gv_ReImport.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");

                        }
                        else
                        {
                            ddl_Info_Qualifier.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                            ddl_Info_Qualifier.SelectedIndex = 0;
                            txt_Info_Text.Text = string.Empty;
                        }

                        if (ddl_Info_Qualifier.SelectedItem.Text != string.Empty)
                        {
                            DataSet ds_ss = new DataSet();

                            Am.SCHEME_NOTN = "";
                            Am.SCHEME_IMPORT_CODE = ddl_Info_Qualifier.SelectedValue.ToString(); //DC0012016
                            Am.name = "Select_Info_Code";
                            ds_ss = Am.IMP_Single_Window();

                            if (ds_ss.Tables[0].Rows.Count > 0)
                            {

                                ddl_Info_Code.DataTextField = ds_ss.Tables[0].Columns["info_desc"].ToString();
                                ddl_Info_Code.DataValueField = ds_ss.Tables[0].Columns["IFO_CODE"].ToString();
                                ddl_Info_Code.DataSource = ds_ss.Tables[0];
                                ddl_Info_Code.DataBind();
                                ddl_Info_Code.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                                ddl_Info_Code.SelectedIndex = 0;
                                ddl_Info_Code.SelectedValue = gv_ReImport.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
                            }
                            else
                            {
                                ddl_Info_Code.Items.Clear();
                                ddl_Info_Code.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                                ddl_Info_Code.SelectedIndex = 0;

                                txt_Info_Text.Text = string.Empty;
                            }
                        }
                        else
                        {
                            ddl_Info_Code.Items.Clear();
                            ddl_Info_Code.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                            ddl_Info_Code.SelectedIndex = 0;
                            txt_Info_Text.Text = string.Empty;
                        }

                    }
                    if (ddl_info_type.SelectedValue == "DIR" && (ddl_Info_Qualifier.SelectedValue == "PNR" || ddl_Info_Qualifier.SelectedValue == "ETICKET" || ddl_Info_Qualifier.SelectedValue == "PASSPORT"))
                    {
                        ddl_Info_Code_Import.Style["display"] = "none";
                        txt_Info_Code_Custom_Import.Style["display"] = "block";
                        txt_Info_Code_Custom.Text = gv_ReImport.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
                    }

                    txt_Info_Text.Text = gv_ReImport.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
                    txt_Info_Msr.Text = gv_ReImport.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
                    txt_Info_Uqc.Text = gv_ReImport.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
                    txt_Sr_No.Text = gv_ReImport.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
                }
                catch (Exception ex)
                {
                    ddl_info_type.SelectedIndex = -1;
                    ddl_Info_Qualifier.SelectedIndex = -1;
                    ddl_Info_Code.SelectedIndex = -1;
                }

            }
            else
            {
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                btnNew.Visible = true;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        
    }

    protected void gv_ReImport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (hdn_Grid_Disable.Value == "1")
                {
                    e.Row.Enabled = false;
                }
                else
                {
                    e.Row.Enabled = true;
                    e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                    e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_ReImport, "Select$" + e.Row.RowIndex.ToString()));
                }
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
            SW_ID = hdn_update_Reimport.Value;
            FLAG = "U";
            SW_INFO_TYPE_insert_update(SW_ID, FLAG);

            if (i == 1)
            {
                if (ViewState["UPDATED_ID"] != null)
                {
                    Alert_msg("SW InfoType Updated Successfully", "btnUpdate");
                }
                else
                {
                    Alert_msg("SW InfoType Saved Successfully", "btnUpdate");
                }

                Gridbind_SW_INFO_TYPE();
            }
            else
            {
                Alert_msg("SW InfoType Not Saved", "btnUpdate");
            }
        }

        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            ObjUBO.JOBNO = EXPORT_JOBNO;
            ObjUBO.INVOICE_SLNO = INVOICE_SLNO;
            ObjUBO.ITEM_SLNO = ITEM_SLNO;
            ObjUBO.SW_ID = ViewState["SW_INFO_TYPE_ID"].ToString();
            ObjUBO.flag = "D";
            ObjUBO.Ename = hdn_Normal_Bulk.Value.ToString();
            SW.SW_INFOTYPE_Details_Insert_Update(ObjUBO);

            int ii = 0;
            ii = SW.result;

            if (ii > 0)
            {
                btnNew_Click(sender, e);
                Alert_msg("SW InfoType Deleted");
                Export.Exp_Job_Logs_All_Details(EXPORT_JOBNO, INVOICE_SLNO, ITEM_SLNO, "SW Info Type", "D", "Insert");
            }
            else
            {
                Alert_msg("SW InfoType Not Deleted");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void gv_ReImport_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.CssClass = "header";
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
                e.Row.CssClass = "normal";
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
                e.Row.CssClass = "alternate";
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
      
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            ddl_info_type.Focus();
            ddl_info_type.SelectedIndex = -1;
            txt_Info_Text.Text = string.Empty;
            txt_Info_Msr.Text = string.Empty;
            txt_Info_Uqc.Text = string.Empty;
            txt_Sr_No.Text = string.Empty;
            txt_Info_Code_Custom.Text = string.Empty;

            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnNew.Visible = true;
            btnUpdate.CssClass = "updates";

            ViewState["UPDATED_ID"] = null;
            hdn_update_Reimport.Value = "";

            ddl_Info_Qualifier.Items.Clear();
            ddl_Info_Code.Items.Clear();

            Gridbind_SW_INFO_TYPE();

            txt_RITCNO.Text = ViewState["txt_RITCNO"].ToString();

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'SW InfoType', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'SW InfoType', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }


    protected void ddl_info_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddl_info_type.SelectedItem.Text != string.Empty)
            {
                if (ddl_info_type.SelectedValue.ToString() == "PEC")
                {

                    DataSet ds_ss = new DataSet();
                    adminmaster Am = new adminmaster();
                    Am.SCHEME_NOTN = "";
                    Am.SCHEME_IMPORT_CODE = ddl_info_type.SelectedValue.ToString();
                    Am.name = "Select_Info_Qualifier_PEC";
                    ds_ss = Am.IMP_Single_Window();

                    if (ds_ss.Tables[0].Rows.Count > 0)
                    {
                        ddl_Info_Qualifier.DataTextField = ds_ss.Tables[0].Columns["QF_Code"].ToString();
                        ddl_Info_Qualifier.DataValueField = ds_ss.Tables[0].Columns["QF_Code"].ToString();
                        ddl_Info_Qualifier.DataSource = ds_ss.Tables[0];
                        ddl_Info_Qualifier.DataBind();

                        ddl_Info_Qualifier.SelectedIndex = -1;
                    }

                    if (ds_ss.Tables[1].Rows.Count > 0)
                    {
                        ddl_Info_Code.DataTextField = ds_ss.Tables[1].Columns["INFO_Code_desc"].ToString();
                        ddl_Info_Code.DataValueField = ds_ss.Tables[1].Columns["INFO_Code"].ToString();
                        ddl_Info_Code.DataSource = ds_ss.Tables[1];
                        ddl_Info_Code.DataBind();
                        ddl_Info_Code.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                        ddl_Info_Code.SelectedIndex = 0;
                    }
                }
                else if (ddl_info_type.SelectedValue.ToString() == "OTH" && Session["EXPORT_SBTYPE"].ToString() == "SEZ" && Session["NFEI_TYPE"].ToString() == "09-DTA SB")// Added by pandiyan on 12-06-2026
                {
                    ddl_Info_Qualifier.Items.Clear();
                    ddl_Info_Code.Items.Clear();

                    ddl_Info_Qualifier.Items.Add(
                        new ListItem("DTA - Domestic Tariff Area", "DTA"));

                    ddl_Info_Code.Items.Add(
                        new ListItem("DTASBY - DTA procurement(with benifit)", "DTASBY"));

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "BindInfoText", "BindControls();", true);
                }
                else if (ddl_info_type.SelectedValue.ToString() == "DIR" && hdn_dept_code.Value.Split(',').Contains("HAND"))// Added by pandiyan on 06-06-2025
                {
                    DataSet ds_ss = new DataSet();
                    adminmaster Am = new adminmaster();
                    Am.SCHEME_NOTN = "";
                    Am.SCHEME_IMPORT_CODE = ddl_info_type.SelectedValue.ToString();
                    Am.name = "Select_Info_Qualifier_HAND";
                    ds_ss = Am.IMP_Single_Window();

                    if (ds_ss.Tables[0].Rows.Count > 0)
                    {
                        ddl_Info_Qualifier.DataTextField = ds_ss.Tables[0].Columns["QF_Code"].ToString();
                        ddl_Info_Qualifier.DataValueField = ds_ss.Tables[0].Columns["QF_Code"].ToString();
                        ddl_Info_Qualifier.DataSource = ds_ss.Tables[0];
                        ddl_Info_Qualifier.DataBind();

                    }
                }
                else if (ddl_info_type.SelectedValue.ToString() == "DIR")//EXBOND-SB
                {

                    DataSet ds_ss = new DataSet();
                    adminmaster Am = new adminmaster();
                    Am.SCHEME_NOTN = "";
                    Am.SCHEME_IMPORT_CODE = ddl_info_type.SelectedValue.ToString();
                    Am.name = "Select_Info_Qualifier_DIR";
                    ds_ss = Am.IMP_Single_Window();

                    if (ds_ss.Tables[0].Rows.Count > 0)
                    {
                        ddl_Info_Qualifier.DataTextField = ds_ss.Tables[0].Columns["QF_Code"].ToString();
                        ddl_Info_Qualifier.DataValueField = ds_ss.Tables[0].Columns["QF_Code"].ToString();
                        ddl_Info_Qualifier.DataSource = ds_ss.Tables[0];
                        ddl_Info_Qualifier.DataBind();

                        ddl_Info_Qualifier.SelectedIndex = -1;
                    }

                    //--------------- WareHouse Master - User Wise ----08-07-2024-----
                    Auto_Search Auto = new Auto_Search();
                    DataSet ds = new DataSet();
                    DataTable dtWareHouse = new DataTable();
                    Auto.Ename = "WAREHOUSE_MASTER_USERWISE_SEARCH_SW";
                    ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();

                    dtWareHouse = ds_ss.Tables[1].Copy(); // Copy the Temp table

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dtWareHouse.Merge(ds.Tables[0], true);// Merge the 2nd Table
                    }

                    if (dtWareHouse.Rows.Count > 0)
                    {
                        ddl_Info_Code.DataTextField = dtWareHouse.Columns["INFO_Code_desc"].ToString();
                        ddl_Info_Code.DataValueField = dtWareHouse.Columns["INFO_Code"].ToString();
                        ddl_Info_Code.DataSource = dtWareHouse;
                        ddl_Info_Code.DataBind();
                        ddl_Info_Code.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                        ddl_Info_Code.SelectedIndex = 0;
                    }

                }

                else
                {

                    DataSet ds_s = new DataSet();
                    adminmaster Am = new adminmaster();
                    Am.SCHEME_NOTN = hdn_dept_code.Value.ToString();
                    Am.SCHEME_IMPORT_CODE = ddl_info_type.SelectedValue.ToString();
                    Am.name = "Select_Info_Qualifier";
                    ds_s = Am.IMP_Single_Window();


                    if (ds_s.Tables[0].Rows.Count > 0)
                    {
                        if (ddl_info_type.SelectedValue.ToString() == "CHR")
                            ds_s.Tables[0].Rows.Add("GSTALLOWED - GST Allowed", "GSTALLOWED");
                        ddl_Info_Qualifier.DataTextField = ds_s.Tables[0].Columns["IFO_QFR_CODE_desc"].ToString();
                        ddl_Info_Qualifier.DataValueField = ds_s.Tables[0].Columns["IFO_QFR_CODE"].ToString();
                        ddl_Info_Qualifier.DataSource = ds_s.Tables[0];
                        ddl_Info_Qualifier.DataBind();
                        ddl_Info_Qualifier.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                        ddl_Info_Qualifier.SelectedIndex = 0;

                    }
                    else if (ddl_info_type.SelectedValue.ToString() == "CHR")
                    {
                        DataTable dt_gst = new DataTable();
                        dt_gst.Columns.Add("IFO_QFR_CODE_desc");
                        dt_gst.Columns.Add("IFO_QFR_CODE");

                        dt_gst.Rows.Add("GSTALLOWED - GST Allowed", "GSTALLOWED");

                        ddl_Info_Qualifier.DataSource = dt_gst;
                        ddl_Info_Qualifier.DataTextField = dt_gst.Columns["IFO_QFR_CODE_desc"].ToString();
                        ddl_Info_Qualifier.DataValueField = dt_gst.Columns["IFO_QFR_CODE"].ToString();
                        ddl_Info_Qualifier.DataBind();

                        ddl_Info_Qualifier.SelectedIndex = -1;
                    }
                    else
                    {
                        ddl_Info_Qualifier.Items.Clear();
                        ddl_Info_Qualifier.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                        ddl_Info_Qualifier.SelectedIndex = 0;
                        txt_Info_Text.Text = string.Empty;
                    }
                }

            }
            else
            {
                ddl_Info_Qualifier.Items.Clear();
                ddl_Info_Code.Items.Clear();
                ddl_Info_Qualifier.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddl_Info_Qualifier.SelectedIndex = 0;
                ddl_Info_Code.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddl_Info_Code.SelectedIndex = 0;
                txt_Info_Text.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        
    }
    protected void ddl_Info_Qualifier_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddl_Info_Qualifier.SelectedItem.Text != string.Empty)
            {
                if (ddl_Info_Qualifier.SelectedValue.ToString() != "SUC")
                {
                    DataSet ds_s = new DataSet();
                    adminmaster Am = new adminmaster();
                    Am.SCHEME_NOTN = "";
                    Am.SCHEME_IMPORT_CODE = ddl_Info_Qualifier.SelectedValue.ToString(); //DC0012016
                    Am.name = "Select_Info_Code";
                    ds_s = Am.IMP_Single_Window();

                    if (ds_s.Tables[0].Rows.Count > 0)
                    {

                        ddl_Info_Code.DataTextField = ds_s.Tables[0].Columns["info_desc"].ToString();
                        ddl_Info_Code.DataValueField = ds_s.Tables[0].Columns["IFO_CODE"].ToString();
                        ddl_Info_Code.DataSource = ds_s.Tables[0];
                        ddl_Info_Code.DataBind();
                        ddl_Info_Code.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                        ddl_Info_Code.SelectedIndex = 0;

                    }
                    else
                    {
                        ddl_Info_Code.Items.Clear();
                        ddl_Info_Code.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                        ddl_Info_Code.SelectedIndex = 0;

                        txt_Info_Text.Text = string.Empty;
                    }
                }
            }
            else
            {
                ddl_Info_Code.Items.Clear();
                ddl_Info_Code.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddl_Info_Code.SelectedIndex = 0;
                txt_Info_Text.Text = string.Empty;
            }
            if (ddl_info_type.SelectedValue == "DIR" && (ddl_Info_Qualifier.SelectedValue == "PNR" || ddl_Info_Qualifier.SelectedValue == "ETICKET" || ddl_Info_Qualifier.SelectedValue == "PASSPORT"))
            {
                ddl_Info_Code_Import.Style["display"] = "none";
                txt_Info_Code_Custom_Import.Style["display"] = "block";
            }
            else
            {
                ddl_Info_Code_Import.Style["display"] = "block";
                txt_Info_Code_Custom_Import.Style["display"] = "none";
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        
    }
    protected void ddl_Info_Code_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddl_Info_Code.SelectedItem.Text != string.Empty)
            {
                if (ddl_info_type.SelectedValue.ToString() == "PEC")
                {
                    DataSet dss = new DataSet();
                    adminmaster Am = new adminmaster();
                    Am.SCHEME_NOTN = "";
                    Am.SCHEME_IMPORT_CODE = ddl_Info_Code.SelectedValue.ToString();
                    Am.name = "Select_Info_Text_PEC";
                    dss = Am.IMP_Single_Window();
                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        txt_Info_Text.Text = dss.Tables[0].Rows[0]["INFO_CODE_DESC"].ToString();
                    }
                    else
                    {
                        txt_Info_Text.Text = string.Empty;
                    }
                }
                else
                {
                    DataSet ds_s = new DataSet();
                    adminmaster Am = new adminmaster();
                    Am.SCHEME_NOTN = "";
                    Am.SCHEME_IMPORT_CODE = ddl_Info_Code.SelectedValue.ToString();
                    Am.name = "Select_Info_Text";
                    ds_s = Am.IMP_Single_Window();
                    if (ds_s.Tables[0].Rows.Count > 0)
                    {
                        txt_Info_Text.Text = ds_s.Tables[0].Rows[0]["INFO_CODE_DESC"].ToString();
                    }
                    else
                    {
                        txt_Info_Text.Text = string.Empty;
                    }
                }
            }
            else
            {
                txt_Info_Text.Text = string.Empty;
            }

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
     }
}