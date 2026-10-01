using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Supportingdoc : ThemeClass
{
    Transaction Transact = new Transaction();
    EXP_Supportingdoc Sup_Doc = new EXP_Supportingdoc();
    User_Creation user_Create = new User_Creation();
    AppSession aps = new AppSession();
    UserBO ObjUBO = new UserBO();
    ErrorLogs er = new ErrorLogs();
    Export_General_New Export = new Export_General_New();
    public int i;

    public string EXPORT_JOBNO, SW_ID, currentuser, SELECT_BRANCH;
    public string INVOICE_SLNO = "", ITEM_SLNO = "", INVOICE_NO = "",S_BULK="";
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
   
    public int Screen_Id;
    public string JOB_LOCK, JOB_RELEASE;
    public string New_Record = "", ICEGATE_ID = "";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();

            currentuser = Connection.Current_User();
            EXPORT_JOBNO = Session["EXPORT_JOBNO"].ToString();
            SELECT_BRANCH = Connection.Get_Company_Type();
            //ICEGATE_ID = HttpContext.Current.Session["ICEGATE_ID"].ToString();
            hdn_COMAPNYID.Value = Connection.COMPANYID();
            hdn_ICEGATE_ID_List.Value = Connection.Get_User_ICEGATE_ID_DropdownList("Load_EXP_ICEGATE_ID_dropdown");

            if (Session["Q_Item_slno"] != null)
            {
                hdn_Normal_Bulk.Value = "B";
                //INVOICE_SLNO = Session["Invoice_SLNO"].ToString();
                ITEM_SLNO = Session["Q_Item_slno"].ToString();
                INVOICE_NO = Session["Inv_NO"].ToString();

                INVOICE_SLNO = Session["Q_Item_slno"].ToString();

                if (!IsPostBack)
                {
                    txt_Doc_Type_Code.Attributes.Add("onblur", "javascript:CallServerside_Doc_Type_Code('" + txt_Doc_Type_Code.ClientID + "', '" + txt_Doc_Type_Code.ClientID + "')");
                    //----------------SETTING SCREEN PERMISSION---------------//
                    Screen_Id = 12;
                    Page_Rights(Screen_Id);
                    //----------------SETTING SCREEN PERMISSION---------------//
                    Gridbind_SW_STMT();

                    btnDelete.Visible = false;
                    btnUpdate.Visible = false;
                    btnSave.Visible = true;
                    btn_save_new.Visible = true;
                    btnNew.Visible = true;

                    if (user_Create.IMP_EXP_MASTER_yn == "False")
                    {
                        txt_Doc_Ben_Party_Name.Enabled = false;
                        txt_Doc_Iss_Party_Name.Enabled = false;
                    }
                }
            }
            else
            {
                if (Session["Item_SLNo"] != null)
                {
                    if (Session["TRANSPORT_MODE"] != null)
                    {
                        hdfTransport_mode.Value = Session["TRANSPORT_MODE"].ToString();
                    }
                    INVOICE_SLNO = Session["Inv_SL_No"].ToString();
                    ITEM_SLNO = Session["Item_SLNo"].ToString();
                    INVOICE_NO = Session["Inv_NO"].ToString();
                    S_BULK = "Single";
                    if (!IsPostBack)
                    {

                        txt_Doc_Type_Code.Attributes.Add("onblur", "javascript:CallServerside_Doc_Type_Code('" + txt_Doc_Type_Code.ClientID + "', '" + txt_Doc_Type_Code.ClientID + "')");
                        //----------------SETTING SCREEN PERMISSION---------------//
                        Screen_Id = 12;
                        Page_Rights(Screen_Id);
                        //----------------SETTING SCREEN PERMISSION---------------//
                        New_Record = "New";
                        Gridbind_SW_STMT();

                        btnDelete.Visible = false;
                        btnUpdate.Visible = false;
                        btnSave.Visible = true;
                        btn_save_new.Visible = true;
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
                    btn_save_new.Enabled = false;

                    btnNew.ToolTip = "This Job is Locked by Admin";
                    btnSave.ToolTip = "This Job is Locked by Admin";
                    btn_save_new.ToolTip = "This Job is Locked by Admin";
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
                            btn_save_new.Enabled = false;

                            MP_U.Show();

                            lblUser_Msg.Text = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btnUpdate.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btnDelete.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btnNew.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btnSave.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btn_save_new.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
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
         
    public void Page_Rights(int i)
    {
        try
        {
            //user_Create.RetrieveAll_User_Screen_Rights_Details(i);//hide on 27-08-2026
            user_Create.RetrieveAll_User_Screen_Rights_Details_USERWISE_IEC_settings(i);
            PAGE_WRITE = user_Create.PAGE_WRITE;
            PAGE_READ = user_Create.PAGE_READ;
            PAGE_MODIFY = user_Create.PAGE_MODIFY;
            PAGE_DELETE = user_Create.PAGE_DELETE;
            hdn_Grid_Disable.Value = "";

            //---------------READ ONLY------------------//

            if (PAGE_READ == "False")
            {
                btnSave.Enabled = false;
                btn_save_new.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnNew.Enabled = false;
                btnNew.ToolTip = "You don't have permission to access";
                btnSave.ToolTip = "You don't have permission to access";
                btn_save_new.ToolTip = "You don't have permission to access";
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
                    btn_save_new.Enabled = true;
                    btnNew.Enabled = true;
                }
                else
                {
                    btnSave.Enabled = false;
                    btnSave.ToolTip = "You don't have permission to access";
                    btn_save_new.Enabled = false;
                    btn_save_new.ToolTip = "You don't have permission to access";
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

    public void Gridbind_SW_STMT()
    {
        try
        {
            DataSet dss = new DataSet();
            ObjUBO.JOBNO = EXPORT_JOBNO;
            ObjUBO.INVOICE_SLNO = INVOICE_SLNO;
            ObjUBO.ITEM_SLNO = ITEM_SLNO;
            ObjUBO.BRANCH_COMMON = SELECT_BRANCH;
            if (hdn_Normal_Bulk.Value.ToString() == "Bulk")
            {
                ObjUBO.Ename = "SUP_DOC_Bulk_Select";
            }
            else
            {
                ObjUBO.Ename = "SUP_DOC_Select";
            }
            dss = Sup_Doc.SingleWindow_Select(ObjUBO);

            if (!string.IsNullOrEmpty(Session["SB_NO"].ToString()))
            {
                div_AmendmentType.Visible = true;
            }

            if (dss.Tables[0].Rows.Count > 0)
            {
                gv_ReImport.DataSource = dss;
                gv_ReImport.DataBind();
            }
            else
            {
                DataTable dt = new DataTable();
                gv_ReImport.DataSource = dt;//add empty row
                gv_ReImport.DataBind();
            }

            if (dss.Tables[1].Rows.Count > 0)
            {
                txt_Doc_Iss_Party_Name.Text = dss.Tables[1].Rows[0]["EXPORTER_NAME"].ToString().Replace("&amp;", "&").Replace("amp;", "&").Replace("&#39;", "'").Trim();
                txt_Doc_Iss_Party_Add.Text = dss.Tables[1].Rows[0]["ADDRESS1"].ToString().Replace("&amp;", "&").Replace("amp;", "&").Replace("&#39;", "'").Trim();
                txt_Doc_Iss_Party_Add2.Text = dss.Tables[1].Rows[0]["ADDRESS2"].ToString().Replace("&amp;", "&").Replace("amp;", "&").Replace("&#39;", "'").Trim();
                txt_Doc_Iss_Party_City.Text = dss.Tables[1].Rows[0]["ADDRESS3"].ToString() + "," + dss.Tables[1].Rows[0]["ADDRESS4"].ToString();
                txt_Doc_Iss_Party_Pin.Text = dss.Tables[1].Rows[0]["ADDRESS5"].ToString();
                if (Connection.COMPANYID() == "747")
                {
                    txt_Doc_Ben_Party_Name.Text = txt_Doc_Iss_Party_Name.Text;
                    txt_Ben_party_Add1.Text = txt_Doc_Iss_Party_Add.Text;
                    txt_Ben_party_Add2.Text = txt_Doc_Iss_Party_Add2.Text;
                    txt_Ben_Party_City.Text = txt_Doc_Iss_Party_City.Text;
                    txt_Ben_Party_Pin.Text = txt_Doc_Iss_Party_Pin.Text;

                }
                else
                {
                    txt_Doc_Ben_Party_Name.Text = dss.Tables[1].Rows[0]["CONSIGNEE_NAME"].ToString().Replace("&amp;", "&").Replace("amp;", "&").Replace("&#39;", "'").Trim();
                    txt_Ben_party_Add1.Text = dss.Tables[1].Rows[0]["CONSIGNEE_ADD1"].ToString().Replace("&amp;", "&").Replace("amp;", "&").Replace("&#39;", "'").Trim();
                    txt_Ben_party_Add2.Text = dss.Tables[1].Rows[0]["CONSIGNEE_ADD2"].ToString().Replace("&amp;", "&").Replace("amp;", "&").Replace("&#39;", "'").Trim();
                    txt_Ben_Party_City.Text = dss.Tables[1].Rows[0]["CONSIGNEE_ADD3"].ToString() + "," + dss.Tables[1].Rows[0]["CONSIGNEE_ADD4"].ToString();
                    txt_Ben_Party_Pin.Text = dss.Tables[1].Rows[0]["CONSIGNEE_ADD5"].ToString();
                }

                txt_File_type.Text = "PDF";

                if (New_Record == "New")
                {
                    //txt_IcegateID.Text = Connection.Get_EXP_Icegate_Id("");
                    txt_IcegateID.Text = Connection.Get_EXP_ICEGATE_ID_New();
                    txt_Sr_No.Text = Convert.ToString(gv_ReImport.Rows.Count + 1);
                    txt_Uniq_Doc_No.Focus();
                }
               
                if (dss.Tables.Count > 4 && dss.Tables[4].Rows.Count > 0) //Added by shanthini on 16-07-2026
                {
                    string sezIcegateId = dss.Tables[4].Rows[0]["SEZ_ICEGATE_ID"].ToString().Trim();
                    string SB_TYPE = dss.Tables[4].Rows[0]["SB_TYPE"].ToString().Trim();

                    if (SB_TYPE == "SEZ" && sezIcegateId != "")
                    {
                        hdn_SEZ_ICEGATE_ID.Value = sezIcegateId;
                        txt_IcegateID.Text = sezIcegateId;
                    }
                    else
                    {
                        hdn_SEZ_ICEGATE_ID.Value = "";   
                    }
                }
                else
                {
                    hdn_SEZ_ICEGATE_ID.Value = "";  
                }
            }
            if (dss.Tables[2].Rows.Count > 0)
            {
                hdn_invno.Value = dss.Tables[2].Rows[0]["INVOICE_NO"].ToString();
                hdn_invdate.Value = dss.Tables[2].Rows[0]["INVOICE_DATE"].ToString();
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
               
    }

    public void SW_Supportingdoc_insert_update(string SW_ID, string flag)
    {
        try
        {
            ObjUBO.SW_STMT_ID = SW_ID;
            ObjUBO.JOBNO = EXPORT_JOBNO;
            ObjUBO.INVOICE_SLNO = INVOICE_SLNO;
            ObjUBO.ITEM_SLNO = ITEM_SLNO;
            ObjUBO.SLNO = txt_Sr_No.Text;
            ObjUBO.Unique_Document_No = txt_Uniq_Doc_No.Text;
            ObjUBO.Doc_Issuing_Party_Code = txt_Doc_Iss_Party_Code.Text;
            if (txt_Doc_Type_Code.Text.Contains("_"))
            {
                string[] doc_typeCode = txt_Doc_Type_Code.Text.Split('_');
                ObjUBO.Doc_Type_Code = doc_typeCode[1].Trim();
            }

            ObjUBO.DOC_ISSUING_PARTY_NAME = txt_Doc_Iss_Party_Name.Text;
            ObjUBO.Doc_Issuing_Party_Name_Add1 = txt_Doc_Iss_Party_Add.Text;
            ObjUBO.Doc_Issuing_Party_Name_Add2 = txt_Doc_Iss_Party_Add2.Text;
            ObjUBO.Doc_Issuing_Party_Name_City = txt_Doc_Iss_Party_City.Text;
            ObjUBO.Doc_Issuing_Party_Name_Pin = txt_Doc_Iss_Party_Pin.Text;
            ObjUBO.Doc_Reference_No = txt_Doc_Iss_Party_Ref_No.Text;
            ObjUBO.Place_of_Issue = txt_Place_of_Issue.Text;
            ObjUBO.Doc_Issue_Date = txt_Doc_Iss_Date.Text == string.Empty ? null : txt_Doc_Iss_Date.Text;

            ObjUBO.Doc_Expiry_Date = txt_Doc_Expiry_Date.Text == string.Empty ? null : txt_Doc_Expiry_Date.Text;
            ObjUBO.Doc_Beneficiary_Party_Code = txt_Ben_party_Code.Text;

            ObjUBO.BENEFICIARY_PARTY_NAME = txt_Doc_Ben_Party_Name.Text;

            ObjUBO.Doc_Beneficiary_Party_Name_Add1 = txt_Ben_party_Add1.Text;
            ObjUBO.Doc_Beneficiary_Party_Name_Add2 = txt_Ben_party_Add2.Text;
            ObjUBO.Doc_Beneficiary_Party_Name_City = txt_Ben_Party_City.Text;
            ObjUBO.Doc_Beneficiary_Party_Name_Pin = txt_Ben_Party_Pin.Text;
            ObjUBO.File_Type = txt_File_type.Text;
            ObjUBO.ICEGATE_ID = txt_IcegateID.Text;
            ObjUBO.ICEGATE_DOC_FILE_NAME = txt_IcegateFilename.Text;

            ObjUBO.AMENDMENT_TYPE = ddl_AmendmentType.SelectedValue;
            ObjUBO.AMENDMENT_STATUS = "";
            ObjUBO.SELECT_TYPE = ddl_SelectType.SelectedValue;

            ObjUBO.flag = flag;
            ObjUBO.I_U_TYPE = "";
            ObjUBO.Ename = hdn_Normal_Bulk.Value.ToString();

            hdn_txt_Doc_Iss_Party_Ref_No.Value = txt_Doc_Iss_Party_Ref_No.Text;
            //ViewState["txt_Place_of_Issue"] = txt_Place_of_Issue.Text;
            hdn_txt_Place_of_Issue.Value = txt_Place_of_Issue.Text;
            hdn_txt_Doc_Iss_Date.Value = txt_Doc_Iss_Date.Text;

            Sup_Doc.SW_Supportingdoc_Details_Insert_Update(ObjUBO);

            i = Sup_Doc.result;
            Export.Exp_Job_Logs_All_Details(EXPORT_JOBNO, INVOICE_SLNO, ITEM_SLNO, "Sup Docs", flag, "Insert");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        
    }

    protected void btn_save_new_Click(object sender, EventArgs e)
    {
        try
        {
            btnSave_Click(sender, e);
            if (i == 1)
            {
                btnNew_Click(sender, e);
                txt_Uniq_Doc_No.Focus();
            }
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
            if (txt_Uniq_Doc_No.Text != "")
            {
                if (txt_Doc_Type_Code.Text != "")
                {
                    SW_Supportingdoc_insert_update("", "S");
                    hdn_update_STMT.Value = Convert.ToString(Sup_Doc.UPDATE_ID);

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
                            btnSave.Focus();
                            
                        }
                        //-----------------------FOR USER RIGHTS--------------------------------//
                        ViewState["UPDATED_ID"] = null;
                        Alert_msg("Supporting_Docs Saved Successfully", "btnSave");

                        New_Record = "";
                        Gridbind_SW_STMT();

                        txt_Uniq_Doc_No.Text = string.Empty;
                        txt_Doc_Type_Code.Text = string.Empty;
                        txt_Uniq_Doc_No.Focus();
                    }
                    else if(i == 2)
                    {
                        Alert_msg("IRN Number Already Exists", "btnSave");
                    }
                    else
                    {
                        Alert_msg("Supporting_Docs Not Saved", "btnSave");
                    }
                }
                else
                {
                    Alert_msg("Doc.Type Code Mandatory");
                    txt_Doc_Type_Code.Focus();
                }
            }
            else
            {
                Alert_msg("IRN No - Mandatory");
                txt_Uniq_Doc_No.Focus();
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
            ViewState["SW_STMT_ID"] = Convert.ToString(this.gv_ReImport.SelectedDataKey.Value);

            if (ViewState["SW_STMT_ID"] != "" && ViewState["SW_STMT_ID"] != null)
            {
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = ViewState["SW_STMT_ID"].ToString();
                hdn_update_STMT.Value = ViewState["SW_STMT_ID"].ToString();

                btnUpdate.CssClass = "updates";
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                btn_save_new.Visible = false;
                btnNew.Visible = true;

                txt_Sr_No.Text = gv_ReImport.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
                txt_Uniq_Doc_No.Text = gv_ReImport.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
                string Doc_TypeCode = gv_ReImport.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");

                if (Doc_TypeCode != "")
                {
                    DataSet dss = new DataSet();
                    adminmaster Am = new adminmaster();
                    Am.SCHEME_IMPORT_CODE = Doc_TypeCode;
                    Am.name = "Select_SUPPORTING_DOCS_NAME";
                    dss = Am.IMP_Single_Window();

                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        txt_Doc_Type_Code.Text = dss.Tables[0].Rows[0]["DOC_NAME"].ToString();
                    }
                }

                txt_Doc_Iss_Party_Code.Text = gv_ReImport.SelectedRow.Cells[4].Text.Replace("&nbsp;", "").Replace("&#39;", "'");
                txt_Doc_Iss_Party_Add.Text = gv_ReImport.SelectedRow.Cells[5].Text.Replace("&nbsp;", "").Replace("&amp;", "&").Replace("amp;", "&").Replace("&#39;", "'").Trim();
                txt_Doc_Iss_Party_Add2.Text = gv_ReImport.SelectedRow.Cells[6].Text.Replace("&nbsp;", "").Replace("&amp;", "&").Replace("amp;", "&").Replace("&#39;", "'").Trim();
                txt_Doc_Iss_Party_City.Text = gv_ReImport.SelectedRow.Cells[7].Text.Replace("&nbsp;", "").Replace("&amp;", "&").Replace("amp;", "&").Replace("&#39;", "'").Trim();
                txt_Doc_Iss_Party_Pin.Text = gv_ReImport.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
                txt_Doc_Iss_Party_Ref_No.Text = gv_ReImport.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");
                txt_Place_of_Issue.Text = gv_ReImport.SelectedRow.Cells[10].Text.Replace("&nbsp;", "").Replace("&amp;", "&").Replace("amp;", "&").Replace("&#39;", "'").Trim();
                txt_Doc_Iss_Date.Text = gv_ReImport.SelectedRow.Cells[11].Text.Replace("&nbsp;", "").Replace("01/01/1900", "");
                txt_Doc_Expiry_Date.Text = gv_ReImport.SelectedRow.Cells[12].Text.Replace("&nbsp;", "").Replace("01/01/1900", "");
                txt_Ben_party_Code.Text = gv_ReImport.SelectedRow.Cells[13].Text.Replace("&nbsp;", "");
                txt_Ben_party_Add1.Text = gv_ReImport.SelectedRow.Cells[14].Text.Replace("&nbsp;", "").Replace("&amp;", "&").Replace("amp;", "&").Replace("&#39;", "'").Trim();
                txt_Ben_party_Add2.Text = gv_ReImport.SelectedRow.Cells[15].Text.Replace("&nbsp;", "").Replace("&amp;", "&").Replace("amp;", "&").Replace("&#39;", "'").Trim();
                txt_Ben_Party_City.Text = gv_ReImport.SelectedRow.Cells[16].Text.Replace("&nbsp;", "").Replace("&amp;", "&").Replace("amp;", "&").Replace("&#39;", "'").Trim();
                txt_Ben_Party_Pin.Text = gv_ReImport.SelectedRow.Cells[17].Text.Replace("&nbsp;", "");
                txt_File_type.Text = gv_ReImport.SelectedRow.Cells[18].Text.Replace("&nbsp;", "");
                txt_Doc_Iss_Party_Name.Text = gv_ReImport.SelectedRow.Cells[19].Text.Replace("&nbsp;", "").Replace("&amp;", "&").Replace("amp;", "&").Replace("&#39;", "'").Trim();
                txt_Doc_Ben_Party_Name.Text = gv_ReImport.SelectedRow.Cells[20].Text.Replace("&nbsp;", "").Replace("&amp;", "&").Replace("amp;", "&").Replace("&#39;", "'").Trim();
                txt_IcegateID.Text = gv_ReImport.SelectedRow.Cells[21].Text.Replace("&nbsp;", "");
                txt_IcegateFilename.Text = gv_ReImport.SelectedRow.Cells[22].Text.Replace("&nbsp;", "");
                ddl_AmendmentType.Text = gv_ReImport.SelectedRow.Cells[23].Text.Replace("&nbsp;", "");
                ddl_SelectType.Text = gv_ReImport.SelectedRow.Cells[24].Text.Replace("&nbsp;", "");


            }
            else
            {
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                btn_save_new.Visible = true;
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
            if (txt_Uniq_Doc_No.Text != "")
            {
                if (txt_Doc_Type_Code.Text != "")
                {
                    SW_ID = hdn_update_STMT.Value;
                    SW_Supportingdoc_insert_update(SW_ID, "U");

                    if (i == 1)
                    {
                        if (ViewState["UPDATED_ID"] != null)
                        {
                            Alert_msg("Supporting_Docs Updated Successfully", "btnUpdate");
                        }
                       
                        else
                        {
                            Alert_msg("Supporting_Docs Saved Successfully", "btnUpdate");
                        }
                        Gridbind_SW_STMT();

                        txt_Uniq_Doc_No.Text = string.Empty;
                        txt_Doc_Type_Code.Text = string.Empty;

                    }
                    else if (i == 2)
                    {
                        if (ViewState["UPDATED_ID"] != null)
                        {
                            Alert_msg("IRN No already Exists", "btnUpdate");
                        }
                    }
                    else
                    {
                        Alert_msg("Supporting_Docs Not Saved", "btnUpdate");

                    }
                }
                else
                {
                    Alert_msg("Doc.Type Code Mandatory");
                    txt_Doc_Type_Code.Focus();
                }
            }
            else
            {
                Alert_msg("IRN No - Mandatory");
                txt_Uniq_Doc_No.Focus();
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
            ObjUBO.DELETE_ID = ViewState["SW_STMT_ID"].ToString();
            SW_Supportingdoc_insert_update(ObjUBO.DELETE_ID, "D");

            int ii = 0;
            ii = Sup_Doc.result;

            if (ii > 0)
            {
                btnNew_Click(sender, e);
                Alert_msg("SW Statement Deleted");
                Export.Exp_Job_Logs_All_Details(EXPORT_JOBNO, INVOICE_SLNO, ITEM_SLNO, "Sup Docs", "D", "Insert");
            }
            else
            {
                Alert_msg("SW Statement Not Deleted");
            }
            Gridbind_SW_STMT();
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
            Transact.ResetFields(Page.Controls);

            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btn_save_new.Visible = true;
            btnNew.Visible = true;
            btnUpdate.CssClass = "updates";

            ViewState["UPDATED_ID"] = null;
            hdn_update_STMT.Value = "";

            txt_File_type.Text = "PDF";
            New_Record = "New";
            Gridbind_SW_STMT();
            //ddl_SelectType.Focus();
            txt_Uniq_Doc_No.Focus();

            if (hdn_COMAPNYID.Value.ToString() == "5" || hdn_COMAPNYID.Value.ToString() == "747")
            {
                txt_Doc_Iss_Party_Ref_No.Text = hdn_txt_Doc_Iss_Party_Ref_No.Value.ToString();
                //txt_Place_of_Issue.Text = ViewState["txt_Place_of_Issue"].ToString();
                txt_Place_of_Issue.Text = hdn_txt_Place_of_Issue.Value;
                txt_Doc_Iss_Date.Text = hdn_txt_Doc_Iss_Date.Value.ToString();
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
              
    }


    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Supporting Docs', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Supporting Docs', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    [System.Web.Services.WebMethod]
    public static string GetSingleWindow_statement_bind(string custid, string custid1)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            adminmaster ADM = new adminmaster();

            ADM.SCHEME_NOTN = custid1;
            ADM.SCHEME_IMPORT_CODE = custid;
            ADM.name = "Select_Statement_Text";
            ds = ADM.IMP_Single_Window();
            if (ds.Tables[0].Rows.Count > 0)
            {
                string STATEMENT_DESC = ds.Tables[0].Rows[0]["STATEMENT_DESC"].ToString();
                custid = STATEMENT_DESC;
            }
            else
            {
                custid = string.Empty;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
        return custid;
    }

    [System.Web.Services.WebMethod]
    public static string Doc_Type_Code(string custid)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            adminmaster ADM = new adminmaster();

            ADM.SCHEME_NOTN = custid;
            ADM.SCHEME_IMPORT_CODE = custid;
            ADM.name = "Select_SUPPORTING_DOCS_NAME_Check";
            ds = ADM.IMP_Single_Window();

            if (ds.Tables[0].Rows.Count > 0)
            {
                custid = "True" + "~~" + ds.Tables[0].Rows[0]["DOC_LEVEL"].ToString();
            }
            else
            {
                custid = "False";
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
      
        return custid;
    }


}
