using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.Text;
using System.IO;

public partial class Item_SingleWindow_Master : ThemeClass
{
    DataSet dss = new DataSet();
   
    DataTable dt = new DataTable();
    AppSession aps = new AppSession();
    User_Creation user_Create = new User_Creation();

    SW_INFO_TYPE SW = new SW_INFO_TYPE();
    UserBO ObjUBO = new UserBO();
    Transaction Transact = new Transaction();

    eroyalmaster erm = new eroyalmaster();

    public string currentuser, SELECT_BRANCH;

    public string IMPORT_JOBNO, SW_ID, FLAG;
    public string INVOICE_SLNO = "", ITEM_SLNO = "", INVOICE_NO = "", RITC_NO = "", BE_TYPE = "", COMPANY_ID;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE;
    
    public int Screen_Id;
    public string JOB_LOCK, JOB_RELEASE;
    public int i;
    public string Description, PART_NO;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        currentuser = Connection.Current_User();
        SELECT_BRANCH = Connection.Get_Company_Type();
        COMPANY_ID = Connection.COMPANYID();
        hdn_Jobno.Value = IMPORT_JOBNO;
       // RITC_NO = Session["CTH_No"].ToString();
       // Description = Session["Description"].ToString();

        RITC_NO = (Session["CTH_No"] == null) ? string.Empty : Session["CTH_No"].ToString();
        Description = (Session["Description"] == null) ? string.Empty : Session["Description"].ToString();
        PART_NO = (Session["PARTNO"] == null) ? string.Empty : Session["PARTNO"].ToString();

        if (Session["CTH_No"] != null || Session["CTH_No"] == null)
        {
            hdn_Normal_Bulk.Value = "B";


            //RITC_NO = Session["CTH_No"].ToString();

            popupwindow_closebut_right_new.Visible = true;

            lbl_info_MSR.Visible = false;
            txt_RegDate.Visible = false;
            lbl_info_UQC.Visible = false;
            ddl_validity.Visible = false;
            txt_Info_Msr.Visible = false;
            txt_Info_Uqc.Visible = false;


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
                ddl_info_type.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddl_info_type.SelectedIndex = 0;

                if (Session["BE_TYPE"] != null)
                {
                    if (BE_TYPE == "SEZ FTA-Z" || BE_TYPE == "SEZ DTA-T" || BE_TYPE == "SEZ DTA-M" || BE_TYPE == "Jobbing" || BE_TYPE == "Repair & Return" || BE_TYPE == "Exhibition" || BE_TYPE == "Destruction" || BE_TYPE == "Movement of Goods" || BE_TYPE == "Stock Item")
                    {
                        ddldept.Items.Add("SEZ");
                        ddl_info_type.Items.Add(new ListItem("DTY - SEZ", "DTY"));
                        if (BE_TYPE == "SEZ FTA-Z")
                        {
                            ddl_info_type.Items.Add(new ListItem("AP - SEZ", "SEZ"));
                        }
                        hdn_dept_code.Value = hdn_dept_code.Value == string.Empty ? "SEZ" : hdn_dept_code.Value + ",SEZ";
                    }
                }

                //-----------------------Start-------------------------------------------------------
                Screen_Id = 7;
                Page_Rights(Screen_Id);
                //----------------SETTING SCREEN PERMISSION---------------//

                Gridbind_SW_INFO_TYPE();

                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btn_save_new.Visible = true;
                btnSave.Visible = true;
                btnNew.Visible = true;
                //btn_item_delete.Visible = false;
                //-----------------------End----------------------------------------------------------
            }
        }

        if (Session["JOB_LOCK"] != null && Session["JOB_LOCK"] != "")
        {
            JOB_LOCK = Session["JOB_LOCK"].ToString();

            if (Convert.ToInt32(JOB_LOCK) == 1)
            {
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btn_save_new.Visible = false;
                btnNew.Enabled = false;
                btnSave.Enabled = false;
                //btn_item_delete.Enabled = false;

                btnNew.ToolTip = "This Job is Locked by Admin";
                btnSave.ToolTip = "This Job is Locked by Admin";
                btnUpdate.ToolTip = "This Job is Locked by Admin";
                btnDelete.ToolTip = "This Job is Locked by Admin";
                //btn_item_delete.ToolTip = "This Job is Locked by Admin";
                btn_save_new.ToolTip = "This Job is Locked by Admin";
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
                        btn_save_new.Visible = false;
                        btnNew.Enabled = false;
                        btnSave.Enabled = false;
                       // btn_item_delete.Enabled = false;

                        MP_U.Show();

                        lblUser_Msg.Text = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                        btnUpdate.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                        btnDelete.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                        btnNew.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                        btnSave.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                        //btn_item_delete.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                        btn_save_new.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";

                    }
                }
            }
        }
    }

    private void FTA()
    {
        DataSet dss = new DataSet();
        DataSet d_s = new DataSet();
        adminmaster Am = new adminmaster();
        Am.name = "FTA_notn";
        dss = Am.IMP_Single_Window();
        if (dss.Tables[0].Rows.Count > 0)
        {
            ObjUBO.JOBNO = IMPORT_JOBNO;
            ObjUBO.INVOICE_SLNO = INVOICE_SLNO;
            ObjUBO.ITEM_SLNO = ITEM_SLNO;
            ObjUBO.Xml_A = ConvertDataTableToXML(dss.Tables[0]);

            ObjUBO.BRANCH_COMMON = SELECT_BRANCH;
            ObjUBO.Ename = "IMP_FTA_Select";
            d_s = SW.SingleWindow_Select(ObjUBO);
            if (d_s.Tables[0].Rows.Count > 0)
            {
                ddldept.Items.Add(new ListItem("FTA", "FTA"));
                ddl_info_type.Items.Add(new ListItem("ORC", "ORC"));
            }
        }

    }

    private static string ConvertDataTableToXML(DataTable dtData)
    {
        DataSet dsData = new DataSet();
        StringBuilder sbSQL;
        StringWriter swSQL;
        string XMLformat;
        try
        {
            sbSQL = new StringBuilder();
            swSQL = new StringWriter(sbSQL);
            dsData.Merge(dtData, true, MissingSchemaAction.AddWithKey);
            dsData.Tables[0].TableName = "SampleDataTable";
            foreach (DataColumn col in dsData.Tables[0].Columns)
            {
                col.ColumnMapping = MappingType.Attribute;
            }
            dsData.WriteXml(swSQL, XmlWriteMode.WriteSchema);
            XMLformat = sbSQL.ToString();
            return XMLformat;
        }
        catch (Exception sysException)
        {
            throw sysException;
        }
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
            btnUpdate.Enabled = false;
            btn_save_new.Visible = false;
            btnDelete.Enabled = false;
           // btn_item_delete.Enabled = false;
            btnNew.Enabled = false;
            btnNew.ToolTip = "You don't have permission to access";
            btnSave.ToolTip = "You don't have permission to access";
            btnUpdate.ToolTip = "You don't have permission to access";
            btnDelete.ToolTip = "You don't have permission to access";
         //   btn_item_delete.ToolTip = "You don't have permission to access";
            btn_save_new.ToolTip = "You don't have permission to access";

            hdn_Grid_Disable.Value = "1";
        }
        else
        {
            //---------------SAVE BUTTON------------------//
            if (PAGE_WRITE == "True")
            {
                btnSave.Enabled = true;
                btnNew.Enabled = true;
                btn_save_new.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
                btnSave.ToolTip = "You don't have permission to access";
                btnNew.Enabled = false;

                btn_save_new.Enabled = false;
                btn_save_new.ToolTip = "You don't have permission to access";
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
              //  btn_item_delete.Enabled = true;

                hdn_Grid_Disable.Value = "";
            }
            else
            {
                btnDelete.Enabled = false;
                btnDelete.ToolTip = "You don't have permission to access";
              //  btn_item_delete.ToolTip = "You don't have permission to access";
                hdn_Grid_Disable.Value = "1";
            }
        }
        if (hdn_Grid_Disable.Value == "1")
            gv_ReImport.ToolTip = "You don't have permission to access";
    }


    public void Gridbind_SW_INFO_TYPE()
    {
            ObjUBO.Ename = "Normal_Select";
            ObjUBO.PRODUCT_RITC = RITC_NO;
            ObjUBO.PART_NO = PART_NO;
       
            dss = erm.SingleWindow_INFOTYPE_Select(ObjUBO);

        if (dss.Tables[0].Rows.Count > 0)
        {
            gv_ReImport.DataSource = dss.Tables[0];
            gv_ReImport.DataBind();
        }
        else
        {
            gv_ReImport.DataSource = dt;
            gv_ReImport.DataBind();
        }
    }

    private string FTA_UQC_Val()
    {
        string val = string.Empty;

        txt_Info_Uqc_FTA.Visible = false;
        lbl_info_UQC_FTA.Text = "";
        if (ddldept.SelectedValue.ToString() == "FTA")
        {
            if (ddl_Info_Qualifier.SelectedValue.ToString() == "COWO" || ddl_Info_Qualifier.SelectedValue.ToString() == "CONWO")
            {
                if (ddl_Info_Code.SelectedValue.ToString() == "COOG" || ddl_Info_Code.SelectedValue.ToString() == "COOP")
                {
                    val = txt_Info_Uqc_FTA.SelectedValue.ToString();
                }
                else
                {
                    val = txt_Info_Uqc.SelectedValue.ToString();
                }
            }
            else
            {
                val = txt_Info_Uqc.SelectedValue.ToString();
            }
        }
        else
        {
            val = txt_Info_Uqc.SelectedValue.ToString();
        }

        return val;
    }
   
    public void SW_INFO_TYPE_insert_update(string SW_ID, string flag)
    {
         ObjUBO.SW_ID=SW_ID;
         ObjUBO.PRODUCT_DESCRIPTION =Session["Description"].ToString();
         ObjUBO.PRODUCT_RITC = Session["CTH_No"].ToString() ;
         ObjUBO.PART_NO = Session["PARTNO"].ToString();
         ObjUBO.INFO_TYPE= ddl_info_type.SelectedValue.ToString();
         ObjUBO.INFO_QUALIFIER=ddl_Info_Qualifier.SelectedValue.ToString(); 
         ObjUBO.INFO_CODE=ddl_Info_Code.SelectedValue.ToString(); 
         ObjUBO.INFO_TEXT=txt_Info_Text.Text;
         ObjUBO.INFO_MSR=txt_Info_Msr.Text;
         ObjUBO.INFO_UQC = FTA_UQC_Val();
         ObjUBO.DEPARTMENT=ddldept.SelectedValue.ToString();
         ObjUBO.I_U_TYPE = hdn_Normal_Bulk.Value.ToString();

         if (ddl_Info_Code.SelectedValue == "SIUNAPL")
         {
             ObjUBO.REGN_DATE = txt_RegDate.Text;
             ObjUBO.REGN_VALIDITY = ddl_validity.SelectedValue.ToString();
         }
         else
         {
             ObjUBO.REGN_DATE = "";
             ObjUBO.REGN_VALIDITY = "";
         }

         ObjUBO.flag = flag;
         ObjUBO.Ename = hdn_Normal_Bulk.Value.ToString();
         erm.SW_INFOTYPE_Details_Insert_Update(ObjUBO);
         i = erm.result;
    }

    private string FTA_Validate()
    { 
        string Val="";
        if (ddldept.SelectedValue.ToString() == "FTA" || ddl_info_type.SelectedValue.ToString() == "ORC")
        {
            if (ddldept.SelectedValue.ToString() == "FTA" && ddl_info_type.SelectedValue.ToString() == "ORC")
            {

                if (ddl_Info_Qualifier.SelectedValue.ToString() == "COO")
                {
                    if (txt_Info_Text.Text != string.Empty && ddl_Info_Code.SelectedValue.ToString() != string.Empty)
                    {
                        Val = "1";
                    }
                }
                else if (ddl_Info_Qualifier.SelectedValue.ToString() == "ACM")
                {
                    Val = "1";
                }
                else if (ddl_Info_Qualifier.SelectedValue.ToString() == "RIS" || ddl_Info_Qualifier.SelectedValue.ToString() == "DC" || ddl_Info_Qualifier.SelectedValue.ToString() == "COWO" || ddl_Info_Qualifier.SelectedValue.ToString() == "CONWO")
                {
                    Val = "1";
                }
                else
                {
                    if (ddl_Info_Code.SelectedValue.ToString() == "COOG" || ddl_Info_Code.SelectedValue.ToString() == "COOP")
                    {
                        if (txt_Info_Text.Text != string.Empty)
                        {
                            Val = "1";
                        }
                    }
                    else if (ddl_Info_Code.SelectedValue.ToString() == "COWO")
                    {
                        Val = "1";
                    }

                }
            }
            else {
                ddl_info_type.Focus();
            }

        }
        else if (ddldept.SelectedValue.ToString() == "CCDC")
        {
            Val = "1";
        }
        else
        {
            Val = "1";
        }
       return Val;
    }


    private string FTA_COO_Validate()
    {
        string Val = "", str = "", str_a = "", str_dd = "", str_mm = "", chk_1 = "", chk_2 = "", ValidateYN = "", MsgType="";
        int len = 0;

        if (ddldept.SelectedValue.ToString() == "FTA" && ddl_info_type.SelectedValue.ToString() == "ORC" && ddl_Info_Qualifier.SelectedValue.ToString() == "COO" && ddl_Info_Code.SelectedValue == "KR")
        {
            ValidateYN = "Y";
            MsgType = "COO Number";
        }
        else if (ddldept.SelectedValue.ToString() == "FTA" && ddl_info_type.SelectedValue.ToString() == "ORC" && ddl_Info_Qualifier.SelectedValue.ToString() == "COO")
        {
            ValidateYN = "Y";
            MsgType = "COO Number";
        }
        else if (ddldept.SelectedValue.ToString() == "CCDC")
        {
            ValidateYN = "Y";
            MsgType = "CCDC Number";

        }
        else
        {
            ValidateYN = "";
        }


        //if (ddldept.SelectedValue.ToString() == "FTA" && ddl_info_type.SelectedValue.ToString() == "ORC" && ddl_Info_Qualifier.SelectedValue.ToString() == "COO")
        if (ValidateYN == "Y")
        {
            if (txt_Info_Text.Text != string.Empty)
            {
                len = txt_Info_Text.Text.Length;
                str = txt_Info_Text.Text;

                if (len > 10)
                {
                    //if (ddl_Info_Code.SelectedValue == "KR")
                    //{
                        var count = str.Count(x => x == '|');

                        if (count == 2)
                        {
                            int indexTo = str.LastIndexOf('|');

                            chk_1 = str.Substring(0, indexTo);
                            chk_2 = str.Substring(indexTo + 1, ((str.Length - indexTo) - 1));

                            if (Common_CS.IsNumeric(chk_2) == true)
                            {
                                Val = "";
                                str = chk_1;
                            }
                            else
                            {
                                Val = "Info Text - Item Slno Wrong";
                            }
                        }
                        else if (count == 1)
                        {
                            Val = "";
                            str = txt_Info_Text.Text;
                        }
                        else
                        {
                            Val = "Info Text Format Wrong - " + MsgType + "|DDMMYYYY|Itemslno";
                        }
                    //}



                    if (Val == "")
                    {
                        str = str.Substring(str.Length - 9);
                        str_a = str.Substring(0, 1);
                        if (Common_CS.IsNumeric(str.Substring(str.Length - 8)) == true)
                        {

                            if (str_a == "|")
                            {
                                //if (Common_CS.IsNumeric(str.Substring(str.Length - 8)) == true)
                                // {

                                //if (str.Substring(str.Length - 4) == "2020") // hide by Chithra on 02-01-2020 for current year not accept issue & dont need to update every year
                                if (Convert.ToInt32(str.Substring(str.Length - 4)) <= Convert.ToInt32(DateTime.Now.Year.ToString()))
                                {
                                    str_dd = str.Substring(str.Length - 8);
                                    str_dd = str_dd.Substring(0, 2);

                                    if (Convert.ToInt32(str_dd) < 32)
                                    {
                                        str_mm = str.Substring(str.Length - 6);
                                        str_mm = str_mm.Substring(0, 2);
                                        if (Convert.ToInt32(str_mm) < 13)
                                        {
                                            Val = "1";
                                        }
                                        else
                                        {
                                            Val = "Info Text Month Invalid!";
                                        }
                                    }
                                    else
                                    {
                                        Val = "Info Text Date Invalid!";
                                    }
                                }
                                else
                                {
                                    Val = "Info Text Year Invalid!";
                                }
                                /*  }
                                  else
                                  {
                                      Val = "Info Text Date Invalid!";
                                  }*/
                            }
                            else
                            {
                                Val = "Info Text Missing | Check it!";
                            }
                        }
                        else
                        {
                            Val = "Invalid Date format.";
                        }
                    }
                }
                else
                {
                    Val = "Info Text Format Wrong";
                }

            }
            else
            {
                Val = "Enter Ur Info Text !";
            }
        }
        else
        {
            Val = "1";
        }

        return Val;
    }



    protected void btnSave_Click(object sender, EventArgs e)
    {
        string FTA_COO = string.Empty;
        try
        {
            if (ddl_info_type.SelectedItem.Text != "" && ddl_Info_Qualifier.SelectedItem.Text != "")
            {
                SW_ID = "";
                FLAG = "S";
              
                 if (FTA_Validate() == "1")
                 {
                     FTA_COO = FTA_COO_Validate();
                     if (FTA_COO == "1")
                     {
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
                                 btn_save_new.Visible = false;
                                 //btnSave.Focus();
                             }
                             //-----------------------FOR USER RIGHTS--------------------------------//

                             ViewState["UPDATED_ID"] = null;
                             Alert_msg("SW InfoType Saved Successfully", "btnNew");

                             Gridbind_SW_INFO_TYPE();
                             Load_FTA_UQC();
                         }
                         else
                         {
                             Alert_msg("SW InfoType Not Saved", "btnNew");
                         }
                     }
                     else
                     {
                         //Alert_msg("Enter Ur Infotext Correct Format !", "txt_Info_Text"); 
                         Alert_msg(FTA_COO, "txt_Info_Text"); 
                     }
                    }
                    else
                    {
                        if (ddl_Info_Qualifier.SelectedValue.ToString() == "COO")
                        {
                            if (ddl_Info_Code.SelectedValue.ToString() == string.Empty)
                            {
                                Alert_msg("Select Ur Info Code", "ddl_Info_Code");
                            }
                            else
                            {
                                Alert_msg("Enter Ur Info Text", "txt_Info_Text");
                            }
                        }
                        else
                        {
                            Alert_msg("Enter Ur FTA - Mandatory Details !");
                        }
                    }
            }
            else
            {
                Alert_msg("SW InfoType - Mandatory");
            }
        }
        catch (Exception ex)
        {
           Connection.Error_Msg(ex.Message);
        }     
    }
    
    protected void gv_ReImport_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["SW_INFO_TYPE_ID"] = Convert.ToString(this.gv_ReImport.SelectedDataKey.Value);

        if (ViewState["SW_INFO_TYPE_ID"] != "" && ViewState["SW_INFO_TYPE_ID"] != null)
        {
            //FOR UPDATED SUCCESSFULLY
            ViewState["UPDATED_ID"] = null;
            ViewState["UPDATED_ID"] = ViewState["SW_INFO_TYPE_ID"].ToString();
            hdn_update_Reimport.Value = ViewState["SW_INFO_TYPE_ID"].ToString();
            
            //FOR UPDATED SUCCESSFULLY
            btnUpdate.CssClass = "updates";
            btnDelete.Visible = true;
          //  btn_item_delete.Visible = true;

            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btn_save_new.Visible = false;
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
                    //Am.SCHEME_IMPORT_CODE = ddl_info_type.SelectedValue.ToString();
                    Am.SCHEME_IMPORT_CODE = gv_ReImport.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
                    Am.name = "Select_Info_Qualifier_PEC";
                    //Am.name = "Select_Info_Qualifier_PEC_testing";
                    
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
                else if (ddl_info_type.SelectedValue.ToString() == "ORC")
                {
                    ddl_Info_Qualifier.Items.Clear();
                    ddl_Info_Code.Items.Clear();

                    if (gv_ReImport.SelectedRow.Cells[3].Text.Replace("&nbsp;", "") == "COO")
                    {
                        load_Country();
                    }
                        /* Remove List */
                    else if (gv_ReImport.SelectedRow.Cells[3].Text.Replace("&nbsp;", "") == "ORG")
                    {
                    ddl_Info_Code.Items.Add(new ListItem("COWO - Wholly Obtained", "COWO"));
                    ddl_Info_Code.Items.Add(new ListItem("COOG - Others (General Rule)", "COOG"));
                    ddl_Info_Code.Items.Add(new ListItem("COOP - Others (Product Specific Rule)", "COOP"));
                    }
                    
                    else if (gv_ReImport.SelectedRow.Cells[3].Text.Replace("&nbsp;", "") == "ACM")
                    {
                        ddl_Info_Code.Items.Add(new ListItem("Yes", "Y"));
                        ddl_Info_Code.Items.Add(new ListItem("No", "N"));
                       txt_Info_Text.Enabled = false;
                    }
                    /*Newsr*/
                    else if (gv_ReImport.SelectedRow.Cells[3].Text.Replace("&nbsp;", "") == "RIS" || gv_ReImport.SelectedRow.Cells[3].Text.Replace("&nbsp;", "") == "DC")
                    {
                        ddl_Info_Code.Items.Add(new ListItem("Yes", "Y"));
                        ddl_Info_Code.Items.Add(new ListItem("No", "N"));
                        txt_Info_Text.Enabled = false;
                    }
                    else if (gv_ReImport.SelectedRow.Cells[3].Text.Replace("&nbsp;", "") == "COWO" )
                    {
                        ddl_Info_Code.Items.Add(new ListItem("", ""));
                        /*ddl_Info_Code.Items.Add(new ListItem("COOG - Others (General Rule)", "COOG"));
                        ddl_Info_Code.Items.Add(new ListItem("COOP - Others (Product Specific Rule)", "COOP"));
                         */ 
                        txt_Info_Uqc_FTA.SelectedValue = gv_ReImport.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
                        ddl_Info_Code.Enabled = false;
                        txt_Info_Text.Enabled = false;
                    }
                    else if (gv_ReImport.SelectedRow.Cells[3].Text.Replace("&nbsp;", "") == "CONWO")
                    {
                        ddl_Info_Code.Enabled = true;   
                        ddl_Info_Code.Items.Add(new ListItem("COOG - Others (General Rule)", "COOG"));
                        ddl_Info_Code.Items.Add(new ListItem("COOP - Others (Product Specific Rule)", "COOP"));
                        txt_Info_Uqc_FTA.SelectedValue = gv_ReImport.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
                    }
                    /*Newer*/

                    ddl_Info_Qualifier.Items.Add(new ListItem(string.Empty, string.Empty));
                    ddl_Info_Qualifier.Items.Add(new ListItem("COO-Certificate of Origin Particulars", "COO"));
                    ddl_Info_Qualifier.Items.Add(new ListItem("ORG-Origin Criteria", "ORG"));//OLD Removed
                    ddl_Info_Qualifier.Items.Add(new ListItem("ACM-Accumulation/Cumulation", "ACM"));

                    /*Newsr*/
                    ddl_Info_Qualifier.Items.Add(new ListItem("RIS-Retroactive Issuance", "RIS"));
                    ddl_Info_Qualifier.Items.Add(new ListItem("DC-Direct Consignment", "DC"));
                    ddl_Info_Qualifier.Items.Add(new ListItem("COWO-Wholly Obtained", "COWO"));
                    ddl_Info_Qualifier.Items.Add(new ListItem("CONWO-Not Wholly Obtained ", "CONWO"));
                    /*Newer*/
                    ddl_Info_Qualifier.SelectedValue = gv_ReImport.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
                    ddl_Info_Code.SelectedValue = gv_ReImport.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
                    txt_Info_Text.Text = gv_ReImport.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");

                    Load_FTA_UQC();
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

                txt_Info_Text.Text = gv_ReImport.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
                txt_Info_Msr.Text = gv_ReImport.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");

                if (gv_ReImport.SelectedRow.Cells[7].Text.Replace("&nbsp;", "") == "KGS" || gv_ReImport.SelectedRow.Cells[7].Text.Replace("&nbsp;", "") == "NOS")
                {
                    txt_Info_Uqc.SelectedValue = gv_ReImport.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
                }
                
                txt_RegDate.Text = gv_ReImport.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");

                if (gv_ReImport.SelectedRow.Cells[9].Text.Replace("&nbsp;", "") != "")
                {
                    ddl_validity.SelectedValue = Convert.ToString(Convert.ToDouble(gv_ReImport.SelectedRow.Cells[9].Text) - 1);
                }
                else
                {
                    ddl_validity.SelectedValue = gv_ReImport.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");
                }

            ///    ddl_AmendmentType.SelectedValue = gv_ReImport.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");
                
                Entry_Validation();
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
            btn_save_new.Visible = true;
          //  btn_item_delete.Visible = false;
        }
    }
    protected void gv_ReImport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (hdn_Grid_Disable.Value == "1")
            {
                e.Row.Enabled = false;
            }
            else
            {
                if (e.Row.Cells[8].Text == "01/01/1900")
                {
                    e.Row.Cells[8].Text = "";
                }
               
               // if (e.Row.Cells[4].Text == "SIUNAPL")
                if (e.Row.Cells[1].Text == "SIMS")
                {

                    e.Row.Cells[8].Visible = true;
                    e.Row.Cells[9].Visible = true;
                    e.Row.Cells[6].Visible = false;
                    e.Row.Cells[7].Visible = false;

                    gv_ReImport.Columns[8].Visible = true;
                    gv_ReImport.Columns[9].Visible = true;
                    gv_ReImport.Columns[6].Visible = false;
                    gv_ReImport.Columns[7].Visible = false;

                    if (e.Row.Cells[9].Text.Replace("&nbsp;","") != "")
                    {
                        e.Row.Cells[9].Text = Convert.ToString(Convert.ToDouble(e.Row.Cells[9].Text) + 1);
                    }

                }
                else
                {
                    gv_ReImport.Columns[6].Visible = true;
                    gv_ReImport.Columns[7].Visible = true;

                    /*hide on 12-10-2022
                    gv_ReImport.Columns[8].Visible = false;
                    gv_ReImport.Columns[9].Visible = false;
                    */
                    gv_ReImport.Columns[8].Visible = true;
                    gv_ReImport.Columns[9].Visible = true;

                    //e.Row.Cells[8].Visible = false;
                    //e.Row.Cells[9].Visible = false;
                    //e.Row.Cells[6].Visible = true;
                    //e.Row.Cells[7].Visible = true; 
                }

                e.Row.Enabled = true;
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_ReImport, "Select$" + e.Row.RowIndex.ToString()));
            }
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string FTA_COO = string.Empty;
        try
        {
            if (ddl_info_type.SelectedItem.Text != "" && ddl_Info_Qualifier.SelectedItem.Text != "")
            {
                SW_ID = hdn_update_Reimport.Value;
                FLAG = "U";
                if (FTA_Validate() == "1")
                 {
                     FTA_COO = FTA_COO_Validate();
                     if (FTA_COO == "1")
                     {
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
                             Load_FTA_UQC();
                         }
                         else
                         {
                             Alert_msg("SW InfoType Not Saved", "btnUpdate");
                         }
                     }
                     else
                     {
                         //Alert_msg("Enter Ur Infotext Correct Format !", "txt_Info_Text"); 
                         Alert_msg(FTA_COO, "txt_Info_Text"); 
                     }
                 }
                else
                {
                    if (ddl_Info_Qualifier.SelectedValue.ToString() == "COO")
                    {
                        if (ddl_Info_Code.SelectedValue.ToString() == string.Empty)
                        {
                            Alert_msg("Select Ur Info Code", "ddl_Info_Code");
                        }
                        else
                        {
                            Alert_msg("Enter Ur Info Text", "txt_Info_Text");
                        }
                    }
                    else
                    {
                        Alert_msg("Enter Ur FTA - Mandatory Details !");
                    }

                }
            }
            else
            {
                Alert_msg("SW InfoType - Mandatory");
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
            ObjUBO.JOBNO = IMPORT_JOBNO;
            ObjUBO.INVOICE_SLNO = INVOICE_SLNO;
            ObjUBO.ITEM_SLNO = ITEM_SLNO;
            ObjUBO.SW_ID = ViewState["SW_INFO_TYPE_ID"].ToString();
            ObjUBO.flag = "D";
            ObjUBO.Ename = hdn_Normal_Bulk.Value.ToString();
            erm.SW_INFOTYPE_Details_Insert_Update(ObjUBO);

            int ii = 0;
            ii = erm.result;

            if (ii > 0)
            {
                btnNew_Click(sender, e);
                Alert_msg("SW InfoType Deleted");
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
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
         ddl_info_type.Focus();
         ddl_info_type.SelectedIndex =-1;
         txt_Info_Uqc_FTA.SelectedIndex = -1;

         txt_Info_Text.Text = string.Empty;
         txt_Info_Msr.Text = string.Empty;
         txt_Info_Uqc.Text = string.Empty;
         txt_RegDate.Text = string.Empty;

         txt_Info_Text.Enabled = true;

        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnSave.Visible = true;
        btnNew.Visible = true;
        btn_save_new.Visible = true;
        btnUpdate.CssClass = "updates";

        ViewState["UPDATED_ID"] = null;
        hdn_update_Reimport.Value = "";

        ddl_Info_Qualifier.Items.Clear();
        ddl_Info_Code.Items.Clear();

        Gridbind_SW_INFO_TYPE();
        
        txt_RITCNO.Text = ViewState["txt_RITCNO"].ToString();

    }

    protected void btn_save_new_Click(object sender, EventArgs e)
    {
        btnSave_Click(sender, e);
        if (i == 1)
        {
            btnNew_Click(sender, e);
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
              
                if (ddldept.SelectedValue.ToString() == "PQIS")
                {
                    txt_Info_Text.Text = string.Empty;
                    txt_Info_Msr.Text = string.Empty;
                    txt_Info_Uqc.Text = string.Empty;

                    ddl_Info_Qualifier.SelectedValue = "PQ0012016";
                    ddl_Info_Qualifier_SelectedIndexChanged(sender, e);

                    ddl_Info_Code.Enabled = true;
                    txt_Info_Text.Enabled = false;
                    txt_Info_Msr.Enabled = false;
                    txt_Info_Uqc.Enabled = false;

                }
                else if (ddldept.SelectedValue.ToString() == "CDRUG")
                {
                    txt_Info_Text.Text = string.Empty;
                    txt_Info_Msr.Text = string.Empty;
                    txt_Info_Uqc.Text = string.Empty;

                    ddl_Info_Qualifier.SelectedValue = "DC0012016";
                    ddl_Info_Qualifier_SelectedIndexChanged(sender, e);

                    ddl_Info_Code.Enabled = true;
                    txt_Info_Text.Enabled = false;
                    txt_Info_Msr.Enabled = false;
                    txt_Info_Uqc.Enabled = false;

                    txt_Info_Text.Enabled = false;
                    txt_Info_Msr.Enabled = false;
                    txt_Info_Uqc.Enabled = false;
                }
                 
            }
            //-------------------------------------------------------------
            else if (ddl_info_type.SelectedValue.ToString() == "ORC")
            {
                ddl_Info_Qualifier.Items.Clear();
                ddl_Info_Qualifier.Items.Add(new ListItem("COO-Certificate of Origin Particulars", "COO"));
                //ddl_Info_Qualifier.Items.Add(new ListItem("ORG-Origin Criteria", "ORG"));
                ddl_Info_Qualifier.Items.Add(new ListItem("ACM-Accumulation/Cumulation", "ACM"));

                ddl_Info_Qualifier.Items.Add(new ListItem("RIS-Retroactive Issuance", "RIS"));
                ddl_Info_Qualifier.Items.Add(new ListItem("DC-Direct Consignment", "DC"));

                ddl_Info_Qualifier.Items.Add(new ListItem("COWO - Wholly Obtained", "COWO"));
                ddl_Info_Qualifier.Items.Add(new ListItem("CONWO - Not Wholly Obtained)", "CONWO"));

                ddl_Info_Qualifier.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddl_Info_Qualifier.SelectedIndex = 0;

            }
            else
            {
                ddl_Info_Code.Items.Clear();
                ddl_Info_Code.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddl_Info_Code.SelectedIndex = 0;

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

                }
                else
                {
                    ddl_Info_Qualifier.Items.Clear();
                    ddl_Info_Qualifier.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                    ddl_Info_Qualifier.SelectedIndex = 0;
                    txt_Info_Text.Text = string.Empty;
                }
            }
            Entry_Validation_1();
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

            //------------------------
            ddl_Info_Code.Enabled = true;
            txt_Info_Text.Enabled = true;
            txt_Info_Msr.Enabled = true;
            txt_Info_Uqc.Enabled = true;
            //------------------------
        }
        Load_FTA_UQC();
    }
    protected void ddl_Info_Qualifier_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_Info_Qualifier.SelectedItem.Text != string.Empty)
        {
            string ddl_infotype = ddl_info_type.SelectedItem.Text;

            if (ddldept.SelectedValue.ToString() == "FTA")
            {
                ddl_Info_Code.Items.Clear();
                if (ddl_Info_Qualifier.SelectedValue.ToString() == "COO")
                { 
                   //Load country
                    load_Country();
                }
                    /*
                else if (ddl_Info_Qualifier.SelectedValue.ToString() == "ORG")
                {
                      
                    ddl_Info_Code.Items.Add(new ListItem("COWO - Wholly Obtained", "COWO"));
                    ddl_Info_Code.Items.Add(new ListItem("COOG - Others (General Rule)", "COOG"));
                    ddl_Info_Code.Items.Add(new ListItem("COOP - Others (Product Specific Rule)", "COOP"));
                }
                */

                else if (ddl_Info_Qualifier.SelectedValue.ToString() == "ACM")
                {
                    ddl_Info_Code.Items.Add(new ListItem("Yes", "Y"));
                    ddl_Info_Code.Items.Add(new ListItem("No", "N"));
                    txt_Info_Text.Enabled = false;
                }
                else if (ddl_Info_Qualifier.SelectedValue.ToString() == "RIS" || ddl_Info_Qualifier.SelectedValue.ToString() == "DC")
                {
                    ddl_Info_Code.Items.Add(new ListItem("Yes", "Y"));
                    ddl_Info_Code.Items.Add(new ListItem("No", "N"));
                    txt_Info_Text.Text = string.Empty;
                    txt_Info_Text.Enabled = false;
                }
                else if (ddl_Info_Qualifier.SelectedValue.ToString() == "COWO" )
                {
                    ddl_Info_Code.Items.Add(new ListItem("", ""));
                    /*
                    ddl_Info_Code.Items.Add(new ListItem("COOG - Others (General Rule)", "COOG"));
                    ddl_Info_Code.Items.Add(new ListItem("COOP - Others (Product Specific Rule)", "COOP"));
                    */

                    txt_Info_Text.Enabled = false;
                    ddl_Info_Code.Enabled = false;
                }
                else if (ddl_Info_Qualifier.SelectedValue.ToString() == "CONWO")
                {
                    ddl_Info_Code.Items.Add(new ListItem("COOG - Others (General Rule)", "COOG"));
                    ddl_Info_Code.Items.Add(new ListItem("COOP - Others (Product Specific Rule)", "COOP"));
                    txt_Info_Text.Enabled = true;
                }
            }
            else if (ddldept.SelectedValue.ToString() == "SEZ" && ddl_info_type.SelectedValue.ToString() == "SEZ")
            {
                //--------------- IMP_EXP_MASTER-----
                Auto_Search Auto = new Auto_Search();
                DataSet ds1 = new DataSet();
                //DataTable dtClient = new DataTable();
                Auto.Enamesearch = Session["IMPORTER_NAME"].ToString();
                Auto.NSearch = Session["BRANCH_NO"].ToString();

                Auto.Ename = "IMP_EXP_MASTER_SEZ_Select";
                ds1 = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();

                if (ds1.Tables[0].Rows.Count > 0)
                {
                    ddl_Info_Code.DataSource = ds1.Tables[0];
                    ddl_Info_Code.DataTextField = ds1.Tables[0].Columns["SEZ_AP_ID"].ToString();
                    ddl_Info_Code.DataValueField = ds1.Tables[0].Columns["SEZ_AP_ID"].ToString();
                    ddl_Info_Code.DataBind();
                   

                    txt_Info_Text.Text = ds1.Tables[0].Rows[0]["SEZ_AP_NAME"].ToString();
                }
            }
            else
            {
                DataSet ds_s = new DataSet();
                adminmaster Am = new adminmaster();
                Am.SCHEME_NOTN = "";
                Am.SCHEME_IMPORT_CODE = ddl_Info_Qualifier.SelectedValue.ToString(); //DC0012016

                if (ddl_infotype != "PEC - PGA Exception category")
                {
                    Am.name = "Select_Info_Code";
                }
                else
                {
                    Am.name = "Select_Info_Qualifier_PEC_Category_Search";
                }

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
                //-----------------------------------------------
                Entry_Validation();
                //-----------------------------------------------
          
        }
        else
        {
            ddl_Info_Code.Items.Clear();
            ddl_Info_Code.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddl_Info_Code.SelectedIndex = 0;
            txt_Info_Text.Text = string.Empty;

            ddl_Info_Code.Enabled = true;
            txt_Info_Text.Enabled = true;
            txt_Info_Msr.Enabled = true;
            txt_Info_Uqc.Enabled = true;
        }
        Load_FTA_UQC();
    }

    private void load_Country()
    {
        DataSet dss = new DataSet();
        adminmaster Am = new adminmaster();
        Am.name = "Load_Country";
        dss = Am.IMP_Single_Window();
        if (dss.Tables[0].Rows.Count > 0)
        {
            ddl_Info_Code.DataTextField = dss.Tables[0].Columns["Country_Name"].ToString();
            ddl_Info_Code.DataValueField = dss.Tables[0].Columns["COUNTRY_CODE"].ToString();
            ddl_Info_Code.DataSource = dss.Tables[0];
            ddl_Info_Code.DataBind();
            ddl_Info_Code.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddl_Info_Code.SelectedIndex = 0;
        }
    }
    protected void ddl_Info_Code_SelectedIndexChanged(object sender, EventArgs e)
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

    private void Entry_Validation()
    {
        string Dept = string.Empty
             ,Info_type = string.Empty
             ,Info_Qualifier= string.Empty
             , Info_Code = string.Empty; 

        Dept = ddldept.SelectedValue.ToString();
        Info_type = ddl_info_type.SelectedValue.ToString();
        Info_Qualifier = ddl_Info_Qualifier.SelectedValue.ToString();
        Info_Code = ddl_Info_Code.SelectedValue.ToString();


        txt_Info_Msr.Visible = false;
        txt_Info_Uqc.Visible = false;
        lbl_info_MSR.Visible = false;
        lbl_info_UQC.Visible = false;
        //txt_Info_Text.MaxLength = 2000;

        if (Dept == "AQCS")
        {
            if (Info_type == "PNM" && Info_Qualifier == "COM")
            {
                txt_Info_Msr.Text = string.Empty;
                txt_Info_Uqc.Text = string.Empty;

                ddl_Info_Code.Enabled = false;
                txt_Info_Text.Enabled = true;             
            }
            else
            {
                ddl_Info_Code.Enabled = false;
                txt_Info_Text.Enabled = false;
            }
        }
        else if (Dept == "FSSAI")
        {
            if (Info_type == "CHR" && Info_Qualifier == "STC")
            {
                txt_Info_Msr.Text = string.Empty;
                txt_Info_Uqc.Text = string.Empty;
                txt_Info_Text.Text = string.Empty;

                ddl_Info_Code.Enabled = true;
                txt_Info_Text.Enabled = false;

            }
            else if (Info_type == "CTG" && Info_Qualifier == "FSP")
            {
                txt_Info_Msr.Text = string.Empty;
                txt_Info_Uqc.Text = string.Empty;
                txt_Info_Text.Text = string.Empty;

                ddl_Info_Code.Enabled = true;
                txt_Info_Text.Enabled = false;

            }
            else if (Info_type == "CTG" && Info_Qualifier == "GRA")
            {
                txt_Info_Msr.Text = string.Empty;
                txt_Info_Uqc.Text = string.Empty;
                txt_Info_Text.Text = string.Empty;

                ddl_Info_Code.Enabled = true;
                txt_Info_Text.Enabled = false;
              
            }
            else if (Info_type == "IDT" && Info_Qualifier == "GIT") // Added by pandiyan on 18-06-2025 sugg by bala & shaziya
            {
                txt_Info_Msr.Text = string.Empty;
                txt_Info_Uqc.Text = string.Empty;
                txt_Info_Text.Text = string.Empty;

                ddl_Info_Code.Enabled = false;
                txt_Info_Text.Enabled = true;

            }
            else
            {
                ddl_Info_Code.Enabled = false;
                txt_Info_Text.Enabled = false;

            }
        }
        else if (Dept == "PQIS")
        {
            if (Info_type == "CHR" && Info_Qualifier=="PLV")
            {
                txt_Info_Msr.Text = string.Empty;
                txt_Info_Uqc.Text = string.Empty;

                ddl_Info_Code.Enabled = false;
                txt_Info_Text.Enabled = true;

            }
            else if (Info_type == "CTG" && Info_Qualifier == "PLP")
            {

                txt_Info_Text.Text = string.Empty;
                txt_Info_Msr.Text = string.Empty;
                txt_Info_Uqc.Text = string.Empty;

                ddl_Info_Code.Enabled = true;
                txt_Info_Text.Enabled = false;
  
            }
            else if (Info_type == "CTG" && Info_Qualifier == "PLC")
            {
                txt_Info_Text.Text = string.Empty;

                txt_Info_Msr.Visible = true;
                txt_Info_Uqc.Visible = true;
                lbl_info_MSR.Visible = true;
                lbl_info_UQC.Visible = true;

                ddl_Info_Code.Enabled = true;
                txt_Info_Text.Enabled = false;
                txt_Info_Msr.Enabled = true;
                txt_Info_Uqc.Enabled = true;
               
            }
            else if (Info_type == "PNM" && Info_Qualifier == "PCN")
            {
                txt_Info_Text.Text = string.Empty;
                txt_Info_Msr.Text = string.Empty;
                txt_Info_Uqc.Text = string.Empty;

                ddl_Info_Code.Enabled = true;
                txt_Info_Text.Enabled = false;
            }
            else if (Info_type == "PNM" && Info_Qualifier == "SCI")
            {
                txt_Info_Msr.Text = string.Empty;
                txt_Info_Uqc.Text = string.Empty;

                ddl_Info_Code.Enabled = false;
                txt_Info_Text.Enabled = true;
            }
            else if (Info_type == "PNM" && Info_Qualifier == "SCI")
            {
                txt_Info_Msr.Text = string.Empty;
                txt_Info_Uqc.Text = string.Empty;

                ddl_Info_Code.Enabled = true;
                txt_Info_Text.Enabled = false;
            }
            else if (Info_type == "PNM" && Info_Qualifier == "PID")
            {
                txt_Info_Msr.Text = string.Empty;
                txt_Info_Uqc.Text = string.Empty;

                ddl_Info_Code.Enabled = true;
                txt_Info_Text.Enabled = false;
            }
            else if (Info_type == "PEC" )
            {
                if (Info_Qualifier == "PQ0012016" || Info_Qualifier == "DC0012016")
                {
                    txt_Info_Text.Text = string.Empty;
                    txt_Info_Msr.Text = string.Empty;
                    txt_Info_Uqc.Text = string.Empty;

                    ddl_Info_Code.Enabled = true;
                    txt_Info_Text.Enabled = false;
                }
                else
                {
                    txt_Info_Text.Text = string.Empty;
                    txt_Info_Msr.Text = string.Empty;
                    txt_Info_Uqc.Text = string.Empty;

                    ddl_Info_Code.Enabled = false;
                    txt_Info_Text.Enabled = false;
                }
            }
            else
            {
                ddl_Info_Code.Enabled = false;
                txt_Info_Text.Enabled = false;
            }
        }
        else if (Dept == "WCCB")
        {
            if (Info_type == "PNM" && Info_Qualifier == "COM")
            {
                txt_Info_Msr.Text = string.Empty;
                txt_Info_Uqc.Text = string.Empty;

                ddl_Info_Code.Enabled = false;
                txt_Info_Text.Enabled = true;
            }
            else if (Info_type == "PNM" && Info_Qualifier == "SCI")
            {
                txt_Info_Msr.Text = string.Empty;
                txt_Info_Uqc.Text = string.Empty;

                ddl_Info_Code.Enabled = false;
                txt_Info_Text.Enabled = true;
            }
            else if (Info_type == "PNM" && Info_Qualifier == "PID")
            {
                txt_Info_Msr.Text = string.Empty;
                txt_Info_Uqc.Text = string.Empty;

                ddl_Info_Code.Enabled = true;
                txt_Info_Text.Enabled = false;
            }
            else
            {
                txt_Info_Text.Text = string.Empty;
                txt_Info_Msr.Text = string.Empty;
                txt_Info_Uqc.Text = string.Empty;

                ddl_Info_Code.Enabled = false;
                txt_Info_Text.Enabled = false;
            }
        }
        else if (Dept == "CDRUG")
        {
            if (Info_type == "CTG" && Info_Qualifier == "DRC")
            {
                txt_Info_Text.Text = string.Empty;
                txt_Info_Msr.Text = string.Empty;
                txt_Info_Uqc.Text = string.Empty;

                ddl_Info_Code.Enabled = true;
                txt_Info_Text.Enabled = false;
            }
            else if (Info_type == "CTG" && Info_Qualifier == "GRA")
            {
                txt_Info_Text.Text = string.Empty;
                txt_Info_Msr.Text = string.Empty;
                txt_Info_Uqc.Text = string.Empty;

                ddl_Info_Code.Enabled = true;
                txt_Info_Text.Enabled = false;
            }
            else if (Info_type == "PEC")
            {
                if (Info_Qualifier == "DC0012016" || Info_Qualifier == "PQ0012016")
                {
                    txt_Info_Text.Text = string.Empty;
                    txt_Info_Msr.Text = string.Empty;
                    txt_Info_Uqc.Text = string.Empty;

                    ddl_Info_Code.Enabled = true;
                    txt_Info_Text.Enabled = false;
                }
                else
                {
                    txt_Info_Text.Text = string.Empty;
                    txt_Info_Msr.Text = string.Empty;
                    txt_Info_Uqc.Text = string.Empty;

                    ddl_Info_Code.Enabled = false;
                    txt_Info_Text.Enabled = false;
                }
            }
            else
            {
                ddl_Info_Code.Enabled = false;
                txt_Info_Text.Enabled = false;

            }

        }
        else if (Dept == "SIMS")
        {
           
            lbl_info_MSR.Visible = false;
            lbl_info_UQC.Visible = false;
            txt_RegDate.Visible = false;
            ddl_validity.Visible = false;
            txt_Info_Text.Attributes.Add("placeholder", "<MOSSIMS><DDMMYY><CertNo>");
            //txt_Info_Text.MaxLength = 19;

        }
        else if (Dept == "FTA")
        {
             ddl_info_type.Enabled = true;
             ddl_Info_Qualifier.Enabled = true;
             ddl_Info_Code.Enabled = true;
             txt_Info_Text.Enabled = true;

             if (ddl_Info_Qualifier.SelectedValue.ToString() == "ACM")
             {
                 txt_Info_Text.Enabled = false;
             }
             else if (ddl_Info_Qualifier.SelectedValue.ToString() == "RIS" || ddl_Info_Qualifier.SelectedValue.ToString() == "DC")
             {
                 txt_Info_Text.Enabled = false;
             }
             else if (ddl_info_type.SelectedValue.ToString() == "ORC")
             {
                 if (ddl_Info_Qualifier.SelectedValue.ToString() == "COWO")
                 {
                     txt_Info_Text.Text = string.Empty;
                     txt_Info_Text.Enabled = false;
                     ddl_Info_Code.Enabled = false;
                 }
                 else
                 {
                     ddl_Info_Code.Enabled = true;
                     txt_Info_Text.Enabled = true;
                 }
             }
        }
        else if (Dept == "SEZ")
        {
            if (ddl_info_type.SelectedItem.Text == "DTY - SEZ")
            {
                lbl_info_MSR.Visible = true;
                txt_Info_Msr.Visible = true;
                txt_Info_Uqc.Visible = true;

                txt_Info_Msr.Enabled = true;
                txt_Info_Uqc.Enabled = false;
                lbl_info_MSR.Text = "Info MSR";
            }
        }
    }


    private void Entry_Validation_1()
    {
        string Dept = string.Empty, Info_type = string.Empty;
                
        Dept = ddldept.SelectedValue.ToString();
        Info_type = ddl_info_type.SelectedValue.ToString();

        if (Dept == "AQCS")
        {
            if (Info_type == "PNM")
            {
                txt_Info_Msr.Text = string.Empty;
                txt_Info_Uqc.Text = string.Empty;

                ddl_Info_Code.Enabled = false;
                txt_Info_Text.Enabled = true;
                txt_Info_Msr.Enabled = false;
                txt_Info_Uqc.Enabled = false;
            }
            else
            {
                ddl_Info_Code.Enabled = false;
                txt_Info_Text.Enabled = false;
                txt_Info_Msr.Enabled = false;
                txt_Info_Uqc.Enabled = false;
            }
        }
        else if (Dept == "FSSAI")
        {
            if (Info_type == "CHR")
            {
                txt_Info_Msr.Text = string.Empty;
                txt_Info_Uqc.Text = string.Empty;
                txt_Info_Text.Text = string.Empty;

                ddl_Info_Code.Enabled = true;
                txt_Info_Text.Enabled = false;
                txt_Info_Msr.Enabled = false;
                txt_Info_Uqc.Enabled = false;
            }
            else if (Info_type == "CTG")
            {
                txt_Info_Msr.Text = string.Empty;
                txt_Info_Uqc.Text = string.Empty;
                txt_Info_Text.Text = string.Empty;

                ddl_Info_Code.Enabled = true;
                txt_Info_Text.Enabled = false;
                txt_Info_Msr.Enabled = false;
                txt_Info_Uqc.Enabled = false;
            }
            else
            {
                ddl_Info_Code.Enabled = false;
                txt_Info_Text.Enabled = false;
                txt_Info_Msr.Enabled = false;
                txt_Info_Uqc.Enabled = false;
            }
        }
        else if (Dept == "PQIS")
        {
            if (Info_type == "CHR")
            {
                txt_Info_Msr.Text = string.Empty;
                txt_Info_Uqc.Text = string.Empty;

                ddl_Info_Code.Enabled = false;
                txt_Info_Text.Enabled = true;
                txt_Info_Msr.Enabled = false;
                txt_Info_Uqc.Enabled = false;
            }
            else if (Info_type == "CTG")
            {

                txt_Info_Text.Text = string.Empty;
                txt_Info_Msr.Text = string.Empty;
                txt_Info_Uqc.Text = string.Empty;

                ddl_Info_Code.Enabled = true;
                txt_Info_Text.Enabled = false;
                txt_Info_Msr.Enabled = false;
                txt_Info_Uqc.Enabled = false;
            }
            else if (Info_type == "CTG")
            {
                txt_Info_Text.Text = string.Empty;

                ddl_Info_Code.Enabled = true;
                txt_Info_Text.Enabled = false;
                txt_Info_Msr.Enabled = true;
                txt_Info_Uqc.Enabled = true;
            }
            else if (Info_type == "PNM" )
            {
                txt_Info_Text.Text = string.Empty;
                txt_Info_Msr.Text = string.Empty;
                txt_Info_Uqc.Text = string.Empty;

                ddl_Info_Code.Enabled = true;
                txt_Info_Text.Enabled = false;
                txt_Info_Msr.Enabled = false;
                txt_Info_Uqc.Enabled = false;
            }
            else if (Info_type == "PNM" )
            {
                txt_Info_Msr.Text = string.Empty;
                txt_Info_Uqc.Text = string.Empty;

                ddl_Info_Code.Enabled = false;
                txt_Info_Text.Enabled = true;
                txt_Info_Msr.Enabled = false;
                txt_Info_Uqc.Enabled = false;
            }
            else if (Info_type == "PNM" )
            {
                txt_Info_Msr.Text = string.Empty;
                txt_Info_Uqc.Text = string.Empty;

                ddl_Info_Code.Enabled = true;
                txt_Info_Text.Enabled = false;
                txt_Info_Msr.Enabled = false;
                txt_Info_Uqc.Enabled = false;
            }
            else if (Info_type == "PEC")
            {
                ddl_Info_Code.Enabled = true;
                txt_Info_Text.Enabled = false;
                txt_Info_Msr.Enabled = false;
                txt_Info_Uqc.Enabled = false;
            }
            else
            {
                ddl_Info_Code.Enabled = false;
                txt_Info_Text.Enabled = false;
                txt_Info_Msr.Enabled = false;
                txt_Info_Uqc.Enabled = false;
            }
        }
        else if (Dept == "WCCB")
        {
            if (Info_type == "PNM" )
            {
                txt_Info_Msr.Text = string.Empty;
                txt_Info_Uqc.Text = string.Empty;

                ddl_Info_Code.Enabled = false;
                txt_Info_Text.Enabled = true;
                txt_Info_Msr.Enabled = false;
                txt_Info_Uqc.Enabled = false;
            }
            else if (Info_type == "PNM")
            {
                txt_Info_Msr.Text = string.Empty;
                txt_Info_Uqc.Text = string.Empty;

                ddl_Info_Code.Enabled = false;
                txt_Info_Text.Enabled = true;
                txt_Info_Msr.Enabled = false;
                txt_Info_Uqc.Enabled = false;
            }
            else
            {
                txt_Info_Text.Text = string.Empty;
                txt_Info_Msr.Text = string.Empty;
                txt_Info_Uqc.Text = string.Empty;

                ddl_Info_Code.Enabled = false;
                txt_Info_Text.Enabled = false;
                txt_Info_Msr.Enabled = false;
                txt_Info_Uqc.Enabled = false;
            }
        }
        else if (Dept == "CDRUG")
        {
            if (Info_type == "CTG" )
            {
                txt_Info_Text.Text = string.Empty;
                txt_Info_Msr.Text = string.Empty;
                txt_Info_Uqc.Text = string.Empty;

                ddl_Info_Code.Enabled = true;
                txt_Info_Text.Enabled = false;
                txt_Info_Msr.Enabled = false;
                txt_Info_Uqc.Enabled = false;
            }
            else if (Info_type == "PEC")
            {
                ddl_Info_Code.Enabled = true;
                txt_Info_Text.Enabled = false;
                txt_Info_Msr.Enabled = false;
                txt_Info_Uqc.Enabled = false;
            }
            else
            {
                ddl_Info_Code.Enabled = false;
                txt_Info_Text.Enabled = false;
                txt_Info_Msr.Enabled = false;
                txt_Info_Uqc.Enabled = false;
            }

        }
        else if (Dept == "FTA")
        {
            /*
            if (Info_type == "ORC" & ddl_Info_Qualifier.SelectedValue.ToString()=="ACM")
            {
                txt_Info_Text.Enabled = false;
            }
            */
        }
      
    }

    protected void ddl_Info_Code_SelectedIndexChanged1(object sender, EventArgs e)
    {
        Entry_Validation();
    }
    private void Load_FTA_UQC()
    {
        txt_Info_Uqc_FTA.Visible = false;
        lbl_info_UQC_FTA.Text = "";
        if (ddldept.SelectedValue.ToString() == "FTA")
        {
            if (ddl_Info_Qualifier.SelectedValue.ToString() == "COWO" || ddl_Info_Qualifier.SelectedValue.ToString() == "CONWO")
            {
                if (ddl_Info_Code.SelectedValue.ToString() == "COOG" || ddl_Info_Code.SelectedValue.ToString() == "COOP")
                {
                    txt_Info_Uqc_FTA.Visible = true;
                    lbl_info_UQC_FTA.Text = "Info. UQC";
                }
            }
        }
    }
}