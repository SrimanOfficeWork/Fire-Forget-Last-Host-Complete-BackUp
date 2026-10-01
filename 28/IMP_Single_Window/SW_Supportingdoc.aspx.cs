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
    SW_Support_Docs Sup_Doc = new SW_Support_Docs();
    User_Creation user_Create = new User_Creation();
    AppSession aps = new AppSession();
    UserBO ObjUBO = new UserBO();
    ErrorLogs er = new ErrorLogs();

    public int i;

    public string IMPORT_JOBNO, SW_ID, currentuser, SELECT_BRANCH;
    public string INVOICE_SLNO = "", ITEM_SLNO = "", INVOICE_NO = "", S_BULK = "", ICEGATE_ID = "", COMPANY_ID, Audit_YN = "";
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;

    public int Screen_Id;
    public string JOB_LOCK, JOB_RELEASE;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();

            currentuser = Connection.Current_User();
            IMPORT_JOBNO = Connection.IMP_Jobno();
            SELECT_BRANCH = Connection.Get_Company_Type();
            //ICEGATE_ID= Connection.Get_Icegate_Id();
            ICEGATE_ID = Connection.Get_IMP_ICEGATE_ID_New();
            COMPANY_ID = Connection.COMPANYID();
            hdn_COMAPNYID.Value = Connection.COMPANYID();

            if (Connection.Audit_Logs(COMPANY_ID) == "Y")
            {
                Audit_YN = "Y";
            }

            if (!IsPostBack)
            {
                txt_Image_RefNO.Attributes.Add("onblur", "javascript:CallServerside_Image_RefNO('" + txt_Image_RefNO.ClientID + "', '" + txt_Doc_Type_Code.ClientID + "')");
                txt_Doc_Type_Code.Attributes.Add("onblur", "javascript:CallServerside_Doc_Type_Code('" + txt_Doc_Type_Code.ClientID + "', '" + txt_Doc_Type_Code.ClientID + "')");
                txtErr_Desc.Attributes.Add("readonly", "readonly");
                txtErr_Desc.Style.Add("background-color", "#F0F0F0");

                Screen_Id = 7;
                Page_Rights(Screen_Id);

                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                btnNew.Visible = true;

                if (user_Create.IMP_EXP_MASTER_yn == "False")
                {
                    txt_Ben_party_Name.Enabled = false;
                    txt_Doc_Iss_Party_Name.Enabled = false;
                }
            }

            /********************************************************************************/
            if (Session["ITEM_SLNO"] != null)
            {
                ITEM_SLNO = Session["ITEM_SLNO"].ToString();
                INVOICE_NO = Session["Invoice_NO"].ToString();

                if (Session["Q_Item_slno"] != null)
                {
                    hdn_Normal_Bulk.Value = "B";
                    INVOICE_SLNO = Session["Q_Item_slno"].ToString();
                    Get_INVOICE_NO_frm_JOB(INVOICE_SLNO);
                }
                else
                {
                    if (Session["TRANSPORT_MODE"] != null)
                    {
                        hdfTransport_mode.Value = Session["TRANSPORT_MODE"].ToString();
                    }
                    S_BULK = "Single";
                    INVOICE_SLNO = Session["Invoice_SLNO"].ToString();


                    if (!string.IsNullOrEmpty(Session["BE_No"].ToString()))
                    {
                        div_AmendmentType.Visible = true;
                    }

                    /* Merge
                    Get_INVOICE_NO_frm_JOB(INVOICE_SLNO);
                    if (!IsPostBack)
                    {
                        Bind_General_Supplier_New();
                        Gridbind_SW_STMT();
                    }
                    */

                    if (!IsPostBack)
                    {
                        Check_Sup_Doc_Auto_Insert();
                        Load_Sup_Doc();
                        hdn_ICEGATE_ID_List.Value = Connection.Get_User_ICEGATE_ID_DropdownList("Load_IMP_ICEGATE_ID_dropdown");
                    }
                }
            }
            else
            {
                Response.Write("<script>window.parent.document.getElementById('ItemMain').click();</script>");
            }
            /********************************************************************************/
            Page_Control();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    private void Check_Sup_Doc_Auto_Insert()
    {
        try
        {
             DataSet dss = new DataSet();
            ObjUBO.JOBNO = IMPORT_JOBNO;
            ObjUBO.BENEFICIARY_PARTY_NAME = Connection.Get_Importer_Name();
            ObjUBO.BRANCH_COMMON = SELECT_BRANCH;
            ObjUBO.Ename = "SupDocs_AutoInsert";
            dss = Sup_Doc.Sup_Docs_Client_based_AutoInsert(ObjUBO);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void Load_Sup_Doc()
    {
        try
        {
            DataSet dss = new DataSet();
            ObjUBO.JOBNO = IMPORT_JOBNO;
            ObjUBO.INVOICE_SLNO = INVOICE_SLNO;
            ObjUBO.ITEM_SLNO = ITEM_SLNO;
            ObjUBO.BRANCH_COMMON = SELECT_BRANCH;
            ObjUBO.Ename = "IMP_SUP_DOC_IGM_INV_DETAILS_SELECT";
            dss = Sup_Doc.SingleWindow_Select(ObjUBO);

            if (dss.Tables[0].Rows.Count > 0)
            {
                hdn_invno.Value = dss.Tables[0].Rows[0]["INVOICE_NO"].ToString();
                hdn_invdate.Value = dss.Tables[0].Rows[0]["INVOICE_DATE"].ToString();
                hdn_Jobno.Value = IMPORT_JOBNO;
                hdn_InvSlno.Value = INVOICE_SLNO;
                hdn_ItemSlno.Value = ITEM_SLNO;

                //txt_Ben_party_Name.Text = Connection.Get_Importer_Name().Replace("&amp;", "&").Trim();
                txt_Ben_party_Name.Text = dss.Tables[0].Rows[0]["IMPORTER_NAME"].ToString().Replace("&amp;", "&").Replace("'", "`").Replace("&#39;", "`").Trim();
                txt_Doc_Iss_Party_Name.Text = dss.Tables[0].Rows[0]["SUPPLIER_NAME"].ToString().Replace("&amp;", "&").Trim();

                if (Connection.COMPANYID() == "1" || Connection.COMPANYID() == "1240")
                {
                    txt_Ben_party_Add1.Text = dss.Tables[0].Rows[0]["ADDRESS1"].ToString().Replace("&amp;", "&").Trim();
                    txt_Ben_party_Add2.Text = dss.Tables[0].Rows[0]["ADDRESS2"].ToString().Replace("&amp;", "&").Trim();
                    txt_Ben_Party_City.Text = dss.Tables[0].Rows[0]["ADDRESS4"].ToString().Replace("&amp;", "&").Trim();
                    txt_Ben_Party_Pin.Text = dss.Tables[0].Rows[0]["ADDRESS5"].ToString().Replace("&amp;", "&").Trim();
                    
                    txt_Doc_Iss_Party_Add1.Text = dss.Tables[0].Rows[0]["SUPPLIER_ADDRESS"].ToString().Replace("&amp;", "&").Trim();
                    txt_Doc_Iss_Party_Add2.Text = dss.Tables[0].Rows[0]["SUPPLIER_ADDRESS1"].ToString().Replace("&amp;", "&").Trim();
                    txt_Doc_Iss_Party_City.Text = dss.Tables[0].Rows[0]["SUPPLIER_COUNTRY_NAME"].ToString().Replace("&amp;", "&").Trim();
                    txt_Doc_Iss_Party_Pin.Text = dss.Tables[0].Rows[0]["SUPPLIER_COUNTRY_PINCODE"].ToString().Replace("&amp;", "&").Trim();

                    txt_Place_of_Issue.Text = Session["ITEM_COUNTRY_OF_ORIGIN"].ToString();
                }

                if (Connection.COMPANYID() == "10" || Connection.COMPANYID() == "2145")
                {
                    txt_Place_of_Issue.Text = Session["ITEM_COUNTRY_OF_ORIGIN"].ToString();
                }



                txt_File_type.Text = "PDF";
                //txt_IcegateID.Text = ICEGATE_ID;--25-10-2022
            }

            if (dss.Tables[1].Rows.Count > 0)
            {
                hdn_mbl_no.Value = dss.Tables[1].Rows[0]["IGM_MAWB_MBL"].ToString();
                hdn_mbldate.Value = dss.Tables[1].Rows[0]["IGM_MAWB_MBLDATE"].ToString().Replace("01/01/1900", "");
                hdn_hblno.Value = dss.Tables[1].Rows[0]["IGM_HAWB_HBLNO"].ToString();
                hdn_hbldate.Value = dss.Tables[1].Rows[0]["IGM_HAWB_HBLDATE"].ToString().Replace("01/01/1900", "");
            }
            if (dss.Tables[2].Rows.Count > 0)
            {
                gv_ReImport.DataSource = dss.Tables[2];
                gv_ReImport.DataBind();
            }
            else
            {
                datatable();
            }

            if (txt_IcegateID.Text == "")
            {
                txt_IcegateID.Text = ICEGATE_ID;
            }

            if (dss.Tables.Count > 4 && dss.Tables[4].Rows.Count > 0) // Added by shanthini on 16-07-2026
            {
                string sezIcegateId = dss.Tables[4].Rows[0]["SEZ_ICEGATE_ID"].ToString().Trim();

                bool isSezType = false;
                if (Session["BE_TYPE"] != null)
                {
                    string BE_TYPE = Session["BE_TYPE"].ToString();
                    isSezType = (BE_TYPE == "SEZ FTA-Z" || BE_TYPE == "SEZ DTA-T" || BE_TYPE == "SEZ DTA-M"
                        || BE_TYPE == "Jobbing" || BE_TYPE == "Repair & Return" || BE_TYPE == "Exhibition"
                        || BE_TYPE == "Destruction" || BE_TYPE == "Movement of Goods" || BE_TYPE == "Stock Item");
                }

                if (isSezType && sezIcegateId != "")
                {
                    hdn_SEZ_ICEGATE_ID.Value = sezIcegateId;
                    txt_IcegateID.Text = sezIcegateId;
                }
                else
                {
                    hdn_SEZ_ICEGATE_ID.Value = "";   
                }
            }

            // ----Audit Modified Data -----------------------------------
            if (Audit_YN == "Y")
            {
                Tbl_Filed_Modified_History(dss.Tables[3]);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public void Get_INVOICE_NO_frm_JOB(string INV_SLNO)
    {
        if (INV_SLNO != null)
        {
            try
            {
                DataSet dss = new DataSet();
                ObjUBO.JOBNO = IMPORT_JOBNO;
                ObjUBO.INVOICE_SLNO = INVOICE_SLNO;
                ObjUBO.ITEM_SLNO = ITEM_SLNO;
                ObjUBO.BRANCH_COMMON = SELECT_BRANCH;
                ObjUBO.Ename = "IMP_SUP_DOC_IGM_INVOICE_DETAILS_SELECT";
                dss = Sup_Doc.SingleWindow_Select(ObjUBO);

                if (dss.Tables[0].Rows.Count > 0)
                {
                    hdn_invno.Value = dss.Tables[0].Rows[0]["INVOICE_NO"].ToString();
                    hdn_invdate.Value = dss.Tables[0].Rows[0]["INVOICE_DATE"].ToString();
                }
                if (dss.Tables[1].Rows.Count > 0)
                {
                    hdn_mbl_no.Value = dss.Tables[1].Rows[0]["IGM_MAWB_MBL"].ToString();
                    hdn_mbldate.Value = dss.Tables[1].Rows[0]["IGM_MAWB_MBLDATE"].ToString().Replace("01/01/1900", "");
                    hdn_hblno.Value = dss.Tables[1].Rows[0]["IGM_HAWB_HBLNO"].ToString();
                    hdn_hbldate.Value = dss.Tables[1].Rows[0]["IGM_HAWB_HBLDATE"].ToString().Replace("01/01/1900", "");
                }

                if (txt_IcegateID.Text == "")
                {
                    txt_IcegateID.Text = ICEGATE_ID;
                }
            }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
            }
        }
    }
    public void Bind_General_Supplier_New()
    {
        try
        {
            DataSet dss = new DataSet();
            ObjUBO.JOBNO = IMPORT_JOBNO;
            ObjUBO.INVOICE_SLNO = INVOICE_SLNO;
            ObjUBO.ITEM_SLNO = "";
            ObjUBO.BRANCH_COMMON = SELECT_BRANCH;

            if (hdn_Normal_Bulk.Value.ToString() == "Bulk")
            {
                ObjUBO.Ename = "SUP_DOC_Bulk_Select";
            }
            else
            {
                ObjUBO.Ename = "IMP_SUPPORTING_DOCUMENTS_Select";
            }
            dss = Sup_Doc.SingleWindow_Select(ObjUBO);

            if (dss.Tables[0].Rows.Count > 0)
            {
                txt_Ben_party_Name.Text = dss.Tables[0].Rows[0]["IMPORTER_NAME"].ToString().Replace("&nbsp;", "").Replace("&amp;", "&").Replace("'", "`").Trim();
                txt_Doc_Iss_Party_Name.Text = dss.Tables[0].Rows[0]["SUPPLIER_NAME"].ToString().Replace("&amp;", "&").Replace("&nbsp;", "").Trim();


                if (Connection.COMPANYID() == "1" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "1240")
                {
                    txt_Ben_party_Add1.Text = dss.Tables[0].Rows[0]["ADDRESS1"].ToString().Replace("&amp;", "&").Replace("&nbsp;", "").Trim();
                    txt_Ben_party_Add2.Text = dss.Tables[0].Rows[0]["ADDRESS2"].ToString().Replace("&amp;", "&").Replace("&nbsp;", "").Trim();
                    txt_Ben_Party_City.Text = dss.Tables[0].Rows[0]["ADDRESS4"].ToString().Replace("&amp;", "&").Replace("&nbsp;", "").Trim();
                    txt_Ben_Party_Pin.Text = dss.Tables[0].Rows[0]["ADDRESS5"].ToString().Replace("&amp;", "&").Replace("&nbsp;", "").Trim();

                    txt_Doc_Iss_Party_Add1.Text = dss.Tables[0].Rows[0]["SUPPLIER_ADDRESS"].ToString().Replace("&amp;", "&").Replace("&nbsp;", "").Trim();
                    txt_Doc_Iss_Party_Add2.Text = dss.Tables[0].Rows[0]["SUPPLIER_ADDRESS1"].ToString().Replace("&amp;", "&").Replace("&nbsp;", "").Trim();
                    txt_Doc_Iss_Party_City.Text = dss.Tables[0].Rows[0]["SUPPLIER_COUNTRY_NAME"].ToString().Replace("&amp;", "&").Replace("&nbsp;", "").Trim();
                    txt_Doc_Iss_Party_Pin.Text = dss.Tables[0].Rows[0]["SUPPLIER_COUNTRY_PINCODE"].ToString().Replace("&amp;", "&").Replace("&nbsp;", "").Trim();

                }

                if (Connection.COMPANYID() == "1" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "1240" || Connection.COMPANYID() == "2145")
                {
                    txt_Place_of_Issue.Text = Session["ITEM_COUNTRY_OF_ORIGIN"].ToString();
                }


                txt_File_type.Text = "PDF";
                txt_IcegateID.Text = ICEGATE_ID;

                if (dss.Tables.Count > 1 && dss.Tables[1].Rows.Count > 0)
                {
                    string sezIcegateId = dss.Tables[1].Rows[0]["SEZ_ICEGATE_ID"].ToString().Trim();

                    bool isSezType = false;
                    if (Session["BE_TYPE"] != null)
                    {
                        string BE_TYPE = Session["BE_TYPE"].ToString();
                        isSezType = (BE_TYPE == "SEZ FTA-Z" || BE_TYPE == "SEZ DTA-T" || BE_TYPE == "SEZ DTA-M"
                            || BE_TYPE == "Jobbing" || BE_TYPE == "Repair & Return" || BE_TYPE == "Exhibition"
                            || BE_TYPE == "Destruction" || BE_TYPE == "Movement of Goods" || BE_TYPE == "Stock Item");
                    }

                    if (isSezType && sezIcegateId != "")
                    {
                        hdn_SEZ_ICEGATE_ID.Value = sezIcegateId;
                        txt_IcegateID.Text = sezIcegateId;
                    }
                    else
                    {
                        hdn_SEZ_ICEGATE_ID.Value = "";  
                    }
                }
            }

            datatable();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public void Gridbind_SW_STMT()
    {
        try
        {
            DataSet dss = new DataSet();
            ObjUBO.JOBNO = IMPORT_JOBNO;
            ObjUBO.INVOICE_SLNO = INVOICE_SLNO;
            ObjUBO.ITEM_SLNO = ITEM_SLNO;
            ObjUBO.BRANCH_COMMON = SELECT_BRANCH;
            if (hdn_Normal_Bulk.Value.ToString() == "Bulk")
            {
                ObjUBO.Ename = "SUP_DOC_Bulk_Select";
            }
            else
            {
                ObjUBO.Ename = "IMP_SUPPORTING_DOCUMENTS_Select";
            }
            dss = Sup_Doc.SingleWindow_Select(ObjUBO);

            if (dss.Tables[0].Rows.Count > 0)
            {
                if (Sup_Doc.result != 1)
                {
                    txt_Ben_party_Name.Text = dss.Tables[0].Rows[0]["IMPORTER_NAME"].ToString().Replace("&amp;", "&").Replace("&#39;", "`").Trim();
                    txt_Doc_Iss_Party_Name.Text = dss.Tables[0].Rows[0]["SUPPLIER_NAME"].ToString().Replace("&amp;", "&").Replace("&#39;", "`").Trim();
                    txt_File_type.Text = "PDF";
                    txt_IcegateID.Text = ICEGATE_ID;

                     if (dss.Tables.Count > 1 && dss.Tables[1].Rows.Count > 0)
                     {
                        string sezIcegateId = dss.Tables[1].Rows[0]["SEZ_ICEGATE_ID"].ToString().Trim();

                        bool isSezType = false;
                        if (Session["BE_TYPE"] != null)
                        {
                            string BE_TYPE = Session["BE_TYPE"].ToString();
                            isSezType = (BE_TYPE == "SEZ FTA-Z" || BE_TYPE == "SEZ DTA-T" || BE_TYPE == "SEZ DTA-M"
                                || BE_TYPE == "Jobbing" || BE_TYPE == "Repair & Return" || BE_TYPE == "Exhibition"
                                || BE_TYPE == "Destruction" || BE_TYPE == "Movement of Goods" || BE_TYPE == "Stock Item");
                        }

                      
                        if (isSezType && sezIcegateId != "")
                        {
                            hdn_SEZ_ICEGATE_ID.Value = sezIcegateId;
                            txt_IcegateID.Text = sezIcegateId;
                        }
                        else
                        {
                            hdn_SEZ_ICEGATE_ID.Value = "";   
                        }
                    }
                
           

                    datatable();
                }
                else
                {
                    gv_ReImport.DataSource = dss;
                    gv_ReImport.DataBind();
                }

              
            }
            else
            {
                datatable();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void datatable()
    {
        try
        {
            DataTable dt = new DataTable();
            gv_ReImport.DataSource = dt;//add empty row
            gv_ReImport.DataBind();
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
            ObjUBO.SW_ID = SW_ID;
            ObjUBO.JOBNO = IMPORT_JOBNO;
            ObjUBO.INVOICE_SLNO = INVOICE_SLNO;
            ObjUBO.ITEM_SLNO = ITEM_SLNO;
            ObjUBO.DECLARATION_TYPE = "E";
            ObjUBO.IMAGE_REF_NUMBER = txt_Image_RefNO.Text;

            if (txt_Doc_Type_Code.Text.Contains("_"))
            {
                string[] doc_typeCode = txt_Doc_Type_Code.Text.Split('_');
                ObjUBO.Doc_Type_Code = doc_typeCode[1].Trim();
            }

            ObjUBO.Doc_Issuing_Party_Code = txt_Doc_Iss_Party_Code.Text.Trim();
            ObjUBO.DOC_ISSUING_PARTY_NAME = txt_Doc_Iss_Party_Name.Text.Trim();
            ObjUBO.Doc_Issuing_Party_Name_Add1 = txt_Doc_Iss_Party_Add1.Text.Trim();
            ObjUBO.Doc_Issuing_Party_Name_Add2 = txt_Doc_Iss_Party_Add2.Text.Trim();
            ObjUBO.Doc_Issuing_Party_Name_City = txt_Doc_Iss_Party_City.Text.Trim();
            ObjUBO.Doc_Issuing_Party_Name_Pin = txt_Doc_Iss_Party_Pin.Text.Trim();
            ObjUBO.Doc_Reference_No = txt_Doc_Iss_Party_Ref_No.Text.Trim();
            ObjUBO.Place_of_Issue = txt_Place_of_Issue.Text.Trim();
            ObjUBO.Doc_Issue_Date = txt_Doc_Iss_Date.Text == string.Empty ? null : txt_Doc_Iss_Date.Text;

            ObjUBO.Doc_Expiry_Date = txt_Doc_Expiry_Date.Text == string.Empty ? null : txt_Doc_Expiry_Date.Text;
            ObjUBO.Doc_Beneficiary_Party_Code = txt_Ben_party_Code.Text;
            ObjUBO.BENEFICIARY_PARTY_NAME = txt_Ben_party_Name.Text;

            ObjUBO.Doc_Beneficiary_Party_Name_Add1 = txt_Ben_party_Add1.Text.Trim();
            ObjUBO.Doc_Beneficiary_Party_Name_Add2 = txt_Ben_party_Add2.Text.Trim();
            ObjUBO.Doc_Beneficiary_Party_Name_City = txt_Ben_Party_City.Text.Trim();
            ObjUBO.Doc_Beneficiary_Party_Name_Pin = txt_Ben_Party_Pin.Text.Trim();
            ObjUBO.File_Type = txt_File_type.Text;
            ObjUBO.ICEGATE_ID = txt_IcegateID.Text;
            ObjUBO.AMENDMENT_TYPE = ddl_AmendmentType.SelectedValue;
            ObjUBO.AMENDMENT_STATUS = "";
            ObjUBO.ICEGATE_DOC_FILE_NAME = txt_IcegateFileName.Text;

            ObjUBO.flag = flag;
            ObjUBO.I_U_TYPE = "";
            ObjUBO.Ename = hdn_Normal_Bulk.Value.ToString();
            ObjUBO.SELECT_TYPE = ddl_SelectType.SelectedValue;
            Sup_Doc.IMP_SW_Supportingdoc_Details_Insert_Update(ObjUBO);
            i = Sup_Doc.result;

            Transact.Imp_Job_Logs_All_Details(Connection.IMP_Jobno(), INVOICE_SLNO, ITEM_SLNO, "Sup Docs", flag, "Insert");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    protected void gv_ReImport_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ViewState["SW_ID"] = Convert.ToString(this.gv_ReImport.SelectedDataKey.Value);
            if (ViewState["SW_ID"] != "" && ViewState["SW_ID"] != null)
            {
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = ViewState["SW_ID"].ToString();
                hdn_update_STMT.Value = ViewState["SW_ID"].ToString();

                btnUpdate.CssClass = "updates";
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                btn_save_new.Visible = false;
                btnNew.Visible = true;

                txt_Image_RefNO.Text = gv_ReImport.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
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

                txt_Doc_Iss_Party_Code.Text = gv_ReImport.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
                txt_Doc_Iss_Party_Name.Text = gv_ReImport.SelectedRow.Cells[5].Text.Replace("&nbsp;", "").Replace("&amp;", "&").Replace("&#39;", "`");

                txt_Doc_Iss_Party_Add1.Text = gv_ReImport.SelectedRow.Cells[6].Text.Replace("&nbsp;", "").Replace("&amp;", "&");
                txt_Doc_Iss_Party_Add2.Text = gv_ReImport.SelectedRow.Cells[7].Text.Replace("&nbsp;", "").Replace("&amp;", "&");
                txt_Doc_Iss_Party_City.Text = gv_ReImport.SelectedRow.Cells[8].Text.Replace("&nbsp;", "").Replace("&amp;", "&");
                txt_Doc_Iss_Party_Pin.Text = gv_ReImport.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");
                txt_Doc_Iss_Party_Ref_No.Text = gv_ReImport.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");
                txt_Place_of_Issue.Text = gv_ReImport.SelectedRow.Cells[11].Text.Replace("&nbsp;", "");
                txt_Doc_Iss_Date.Text = gv_ReImport.SelectedRow.Cells[12].Text.Replace("&nbsp;", "").Replace("01/01/1900", "").Replace("01/01/1900 00:00:00", "");

                txt_Doc_Expiry_Date.Text = gv_ReImport.SelectedRow.Cells[13].Text.Replace("&nbsp;", "").Replace("01/01/1900", "").Replace("01/01/1900 00:00:00", "");
                txt_Ben_party_Code.Text = gv_ReImport.SelectedRow.Cells[14].Text.Replace("&nbsp;", "");
                txt_Ben_party_Name.Text = gv_ReImport.SelectedRow.Cells[15].Text.Replace("&nbsp;", "").Replace("&amp;", "&").Replace("&#39;", "`");
                txt_Ben_party_Add1.Text = gv_ReImport.SelectedRow.Cells[16].Text.Replace("&nbsp;", "").Replace("&amp;", "&");
                txt_Ben_party_Add2.Text = gv_ReImport.SelectedRow.Cells[17].Text.Replace("&nbsp;", "").Replace("&amp;", "&");
                txt_Ben_Party_City.Text = gv_ReImport.SelectedRow.Cells[18].Text.Replace("&nbsp;", "").Replace("&amp;", "&");
                txt_Ben_Party_Pin.Text = gv_ReImport.SelectedRow.Cells[19].Text.Replace("&nbsp;", "");
                txt_File_type.Text = gv_ReImport.SelectedRow.Cells[20].Text.Replace("&nbsp;", "");
                ddl_SelectType.Text = gv_ReImport.SelectedRow.Cells[21].Text.Replace("&nbsp;", "");
                txt_IcegateID.Text = gv_ReImport.SelectedRow.Cells[22].Text.Replace("&nbsp;", "");

                if (!string.IsNullOrEmpty(Session["BE_No"].ToString()))
                {
                    div_AmendmentType.Visible = true;
                    ddl_AmendmentType.SelectedValue = gv_ReImport.SelectedRow.Cells[24].Text.Replace("&nbsp;", "");
                }
                txt_IcegateFileName.Text = gv_ReImport.SelectedRow.Cells[23].Text.Replace("&nbsp;", ""); // shifted 24 to 23 /23 to 24 by George Bush on 10-06-26

                // ----Audit Modified Data -----------------------------------
                if (Audit_YN == "Y")
                {
                    DataTable_Mapping_Controls((DataTable)ViewState["dt_Prev_Table"], "Y");
                }
                //------------------------------------------------------------
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
            if (txt_Image_RefNO.Text != "")
            {
                if (txt_Doc_Type_Code.Text != "")
                {
                    if (txtErr_Desc.Text == string.Empty)
                    {
                        SW_ID = hdn_update_STMT.Value;
                        SW_Supportingdoc_insert_update(SW_ID, "U");

                        if (i == 1)
                        {
                            if (ViewState["UPDATED_ID"] != null)
                            {

                                // ----Audit Modified Data -----------------------------------
                                if (Audit_YN == "Y")
                                {
                                    Audit_Modified_DataTableComparer();
                                }
                                //------------------------------------------------------------
						

                                Alert_msg("Sup.doc. Updated Successfully", "btnUpdate");
                            }
                            else
                            {
                                Alert_msg("Sup.doc. Saved Successfully", "btnUpdate");
                            }


                            Gridbind_SW_STMT();
                            txt_Image_RefNO.Text = string.Empty;
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
                            Alert_msg("Sup.doc. Not Saved", "btnUpdate");

                        }
                    }
                    else
                    {
                        Alert_msg("Not Updated Check ur Error !");
                    }
                }
                else
                {
                    Alert_msg("Doc. Type Code - Mandatory");
                }
            }
            else
            {
                Alert_msg("Image Ref.No - Mandatory");
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
            ObjUBO.SW_ID = ViewState["SW_ID"].ToString();
            ObjUBO.JOBNO = IMPORT_JOBNO;
            ObjUBO.INVOICE_SLNO = INVOICE_SLNO;
            ObjUBO.ITEM_SLNO = ITEM_SLNO;

            SW_Supportingdoc_insert_update(ObjUBO.SW_ID, "D");

            int ii = 0;
            ii = Sup_Doc.result;

            if (ii > 0)
            {
                btnNew_Click(sender, e);
                Alert_msg("Sup.doc. Deleted");

            }
            else
            {
                Alert_msg("Sup.doc. Not Deleted");
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

            string ddl_SelectType_val = "";
            ddl_SelectType_val = ddl_SelectType.SelectedValue.ToString();
            Transact.ResetFields(Page.Controls);

            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btn_save_new.Visible = true;
            btnNew.Visible = true;
            btnUpdate.CssClass = "updates";

            ViewState["UPDATED_ID"] = null;
            hdn_update_STMT.Value = "";

            Bind_General_Supplier_New();
            Gridbind_SW_STMT();
            ddl_SelectType.Focus();

            if (hdn_COMAPNYID.Value.ToString() == "5" || hdn_COMAPNYID.Value.ToString() == "747")
            {
                ddl_SelectType.SelectedValue = ddl_SelectType_val;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
        
        
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Sup.doc.', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Sup.doc.', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_Image_RefNO.Text != "")
            {
                if (txt_Doc_Type_Code.Text != "")
                {
                    if (txtErr_Desc.Text == string.Empty)
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
                        Alert_msg("Sup.doc. Saved Successfully", "btnSave");
                        Gridbind_SW_STMT();
                        txt_Image_RefNO.Text = string.Empty;
                        txt_Doc_Type_Code.Text = string.Empty;
                    }
                    else if (i == 2)
                    {
                        Alert_msg("IRN Number already exists", "btnSave");
                    }
                    else
                    {
                        Alert_msg("Sup.doc. Not Saved", "btnSave");

                    }
                }
                else
                {
                 Alert_msg("Not Saved Check ur Error !");
                 }


                }
                else
                {
                    Alert_msg("Doc. Type Code - Mandatory");
                }
            }
            else
            {
                Alert_msg("Image Ref No - Mandatory");
            }
        }

        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
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
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }
    [System.Web.Services.WebMethod]
    public static string Image_RefNO(string custid, string IMG_ID) 
    {
        try
        {
            string Img_ref_no = (custid.Trim()).Length.ToString();
            if (Img_ref_no == "16")
            {
                SW_Support_Docs Sup_Doc = new SW_Support_Docs();
                UserBO ObjUBO = new UserBO();
                DataSet ds = new DataSet();
                ObjUBO.JOBNO = Connection.IMP_Jobno();
                ObjUBO.INVOICE_SLNO = "";
                ObjUBO.ITEM_SLNO = IMG_ID;
                ObjUBO.DELETE_ID = custid;
                ObjUBO.Ename = "SUP_DOC_IMG_Ref_No";
                ds = Sup_Doc.SingleWindow_Select(ObjUBO);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    custid = "2";
                }
                else
                {
                    custid = "0";
                }
            }
            else
            {
                custid = "1";
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

    private void Page_Control()
    {
        try
        {
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
                    btn_save_new.Enabled = false;
                    btnSave.ToolTip = "You don't have permission to access";
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

    protected void gv_ReImport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gv_ReImport.PageIndex = e.NewPageIndex;
            this.Gridbind_SW_STMT();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }


    protected void btn_Bulk_IRN_Copy_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_Image_RefNO.Text != "")
            {
                DataSet dss = new DataSet();
                ObjUBO.JOBNO = IMPORT_JOBNO;
                ObjUBO.INVOICE_SLNO = INVOICE_SLNO;
                ObjUBO.ITEM_SLNO = ITEM_SLNO;
                ObjUBO.IMAGE_REF_NUMBER = txt_Image_RefNO.Text;
                ObjUBO.BRANCH_COMMON = SELECT_BRANCH;
                ObjUBO.Ename = "FTA_Copy";
                dss = Sup_Doc.SW_SUP_DOCS_FTA_COO_ITEMS_COPY(ObjUBO);

                if (Sup_Doc.result == 1)
                {
                    Alert_msg("Copied Successfully");
                    Gridbind_SW_STMT();
                }
            }
            else
            {
                Alert_msg("IRN No- Should be Mandatory");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }



    protected void btn_Bulk_IRN_Delete_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_Image_RefNO.Text != "")
            {
                DataSet dss = new DataSet();
                ObjUBO.JOBNO = IMPORT_JOBNO;
                ObjUBO.INVOICE_SLNO = INVOICE_SLNO;
                ObjUBO.ITEM_SLNO = ddl_SelectType.SelectedValue;
                ObjUBO.IMAGE_REF_NUMBER = txt_Image_RefNO.Text;
                ObjUBO.BRANCH_COMMON = SELECT_BRANCH;
                ObjUBO.Ename = "FTA_Delete";
                dss = Sup_Doc.SW_SUP_DOCS_FTA_COO_ITEMS_COPY(ObjUBO);

                if (Sup_Doc.result == 1)
                {
                    Alert_msg("Deleted Successfully");
                    Gridbind_SW_STMT();
                }
            }
            else
            {
                Alert_msg("IRN No- Should be Mandatory");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    protected void btn_Bulk_RITC_Copy_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_Image_RefNO.Text != "")
            {
                DataSet dss = new DataSet();
                ObjUBO.JOBNO = IMPORT_JOBNO;
                ObjUBO.INVOICE_SLNO = INVOICE_SLNO;
                ObjUBO.ITEM_SLNO = ITEM_SLNO;
                ObjUBO.IMAGE_REF_NUMBER = txt_Image_RefNO.Text;
                ObjUBO.BRANCH_COMMON = SELECT_BRANCH;
                ObjUBO.Ename = "RITC_Bulk_Copy";
                dss = Sup_Doc.SW_SUP_DOCS_FTA_COO_ITEMS_COPY(ObjUBO);

                if (Sup_Doc.result == 1)
                {
                    Alert_msg("Copied Successfully");
                    Gridbind_SW_STMT();
                }
            }
            else
            {
                Alert_msg("IRN No- Should be Mandatory");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    protected void btn_Bulk_RITC_Delete_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_Image_RefNO.Text != "")
            {
                DataSet dss = new DataSet();
                ObjUBO.JOBNO = IMPORT_JOBNO;
                ObjUBO.INVOICE_SLNO = INVOICE_SLNO;
                ObjUBO.ITEM_SLNO = ddl_SelectType.SelectedValue;
                ObjUBO.IMAGE_REF_NUMBER = txt_Image_RefNO.Text;
                ObjUBO.BRANCH_COMMON = SELECT_BRANCH;
                ObjUBO.Ename = "RITC_Bulk_Delete";
                dss = Sup_Doc.SW_SUP_DOCS_FTA_COO_ITEMS_COPY(ObjUBO);

                if (Sup_Doc.result == 1)
                {
                    Alert_msg("Deleted Successfully");
                    Gridbind_SW_STMT();
                }
            }
            else
            {
                Alert_msg("IRN No- Should be Mandatory");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }


    private void Tbl_Filed_Modified_History(DataTable dt_Curr_tbl_struct)
    {
        ViewState["dt_Prev_Table"] = dt_Curr_tbl_struct;
    }

    private void Audit_Modified_DataTableComparer()
    {
        try
        {
            DataTable dt_Prev = (DataTable)ViewState["dt_Prev_Table"];
            DataTable dt_m2 = dt_Prev.Clone();
            DataTable dt_modified = DataTable_Mapping_Controls(dt_m2, "N");
            DataTableComparer Dt_Change = new DataTableComparer();
            Dt_Change.GetMismatchedRowsFast(dt_Prev, dt_modified, "SW_ID", "Sup Docs", IMPORT_JOBNO, INVOICE_SLNO, ITEM_SLNO, currentuser, Connection.Current_Branch());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private DataTable DataTable_Mapping_Controls(DataTable dt_mapping, string SelectMode)
    {
        try
        {
            if (dt_mapping.Rows.Count > 0)
            {
                dt_mapping.Rows.Clear();
            }

            DataRow dr = dt_mapping.NewRow();
            dr["SW_ID"] = hdn_update_STMT.Value;
            dr["INVOICE_SLNO"] = INVOICE_SLNO;
            dr["ITEM_SLNO"] = ITEM_SLNO;
            dr["SELECT_TYPE"] = ddl_SelectType.SelectedValue;
            dr["DECLARATION_TYPE"] = "";
            dr["IMAGE_REF_NUMBER"] = txt_Image_RefNO.Text;
            dr["DOC_TYPE_CODE"] = txt_Doc_Type_Code.Text;
            dr["DOC_ISSUING_PARTY_CODE"] = txt_Doc_Iss_Party_Code.Text;
            dr["DOC_ISSUING_PARTY_NAME"] = txt_Doc_Iss_Party_Name.Text;
            dr["DOC_ISSUING_PARTY_NAME_ADD1"] = txt_Doc_Iss_Party_Add1.Text;
            dr["DOC_ISSUING_PARTY_NAME_ADD2"] = txt_Doc_Iss_Party_Add2.Text;
            dr["DOC_ISSUING_PARTY_CITY"] = txt_Doc_Iss_Party_City.Text;
            dr["DOC_ISSUING_PARTY_PIN"] = txt_Doc_Iss_Party_Pin.Text;
            dr["DOC_REF_NUMBER"] = txt_Doc_Iss_Party_Ref_No.Text;
            dr["PLACE_OF_ISSUE"] = txt_Place_of_Issue.Text;
            dr["DOC_ISSUE_DATE"] = txt_Doc_Iss_Date.Text;
            dr["DOC_EXPIRY_DATE"] = txt_Doc_Expiry_Date.Text;
            dr["BENEFICIARY_PARTY_CODE"] = txt_Ben_party_Code.Text;
            dr["BENEFICIARY_PARTY_NAME"] = txt_Ben_party_Name.Text;
            dr["BENEFICIARY_PARTY_ADDRESS1"] = txt_Ben_party_Add1.Text;
            dr["BENEFICIARY_PARTY_ADDRESS2"] = txt_Ben_party_Add2.Text;
            dr["BENEFICIARY_PARTY_CITY"] = txt_Ben_Party_City.Text;
            dr["BENEFICIARY_PARTY_PIN"] = txt_Ben_Party_Pin.Text;
            dr["FILE_TYPE"] = txt_File_type.Text;
            dr["ICEGATE_ID"] = txt_IcegateID.Text;
            dr["ICEGATE_DOC_FILE_NAME"] = txt_IcegateFileName.Text;
            dr["AMENDMENT_TYPE"] = ddl_AmendmentType.SelectedValue;

            dt_mapping.Rows.Add(dr);

            if (SelectMode == "Y")
            {
                ViewState["dt_Prev_Table"] = dt_mapping;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return dt_mapping;
    }
}
