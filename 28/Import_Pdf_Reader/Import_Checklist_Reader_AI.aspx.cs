using System;
using System.IO;
using System.Data;
using System.Text;
using System.Data.OleDb;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using BussinessObject;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Aspose.Pdf;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Net;
using Newtonsoft.Json.Linq;
//using System.Net.Http.Headers;
using System.Globalization;
using ClosedXML.Excel;
using iTextSharp.text.pdf;

public partial class Import_Checklist_Reader_AI : ThemeClass
{
    AppSession aps = new AppSession();
    UserBO ObjUBO = new UserBO();
    UserBO objUBO = new UserBO();
    AdminMasterDetails admin = new AdminMasterDetails();
    Jobwise_xl_Upload xl = new Jobwise_xl_Upload();
    Import_PDF_Upload imp_pdf = new Import_PDF_Upload();
    Auto_Search Auto = new Auto_Search();
    ErrorLogs log = new ErrorLogs();
    Transaction Transact = new Transaction();
    adminmaster adm = new adminmaster();
    eroyalmaster erm = new eroyalmaster();


    DataTable Dt_gen = new DataTable();
    DataTable Dt_Invoice = new DataTable();
    DataTable Dt_Item = new DataTable();
    DataTable Dt_DBK = new DataTable();
    DataTable Dt_anx = new DataTable();
    DataTable dt_Temp_Inv = new DataTable();
    DataTable dt_Temp_IGM = new DataTable();
    DataTable dt_Temp_Con = new DataTable();
    DataTable dt_Temp_Bond = new DataTable();

    DataSet ds_IEC = new DataSet();
    DataSet ds_draw = new DataSet();
    DataSet GetLocalAPIData = new DataSet();
    DataSet ds_API = new DataSet();

    public String Xml_Inv;

    public int MAX_ID = 0; int i = 0; int rowIndex = 0; int result = 0; int INVOICE_SLNO = 0; decimal Sum_of_Quantity_Rate = 0;

    public string GENERAL_IMPORT_JOBNO = "", TRANSPORT_MODE = "";
    public string currentuser;
    public string currentbranch;
    public string Working_Period;
    public string COMPANY_IDD, comp_ConnectionStr, LoginDate, SELECT_BRANCH, SB_TYPE, JOBNO;
    public string a1 = "", a2 = "", a3 = "", a4 = "", a5 = "", a6 = "";
    string PdfClientName = "";
    bool IsValid = true;
    bool IsValid_PortOO = true;
    bool IsValidInv = true;

    private SqlConnection con;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        SELECT_BRANCH = Connection.Get_Company_Type();
        COMPANY_IDD = Session["COMPANY_ID"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();

        Hdn_STANDARD_TYPE.Value = "STD";
        if (!IsPostBack)
        {
            Bind_Clients();
            AUTO_JOBNO();
        }

        string TRANS_MODE = Session["CUSTOMHOUSE_TRANSPORT_MODE"].ToString();

        if (TRANS_MODE == "A")
        {
            TRANSPORT_MODE = "Air";
        }
        else if (TRANS_MODE == "S")
        {
            TRANSPORT_MODE = "Sea";
        }
        else if (TRANS_MODE == "L")
        {
            TRANSPORT_MODE = "Land";
        }
        hd_TransportMode.Value = TRANSPORT_MODE;
        con = new SqlConnection(HttpContext.Current.Session["currentcomp_db"].ToString());

        Call_Server_Side_Method();

        if (currentuser == "RTS" || currentuser == "s" || currentuser == "k" || currentuser == "Aji")
        {
            ExcelDwnl.Visible = true;
        }
    }

    public void Bind_Clients()
    {
        DataSet ds_client = new DataSet();
        imp_pdf.JOBNO = JOBNO;
        imp_pdf.flag = "Bind_Importer_List";
        imp_pdf.USER_ID = currentuser;
        imp_pdf.WORKINGPERIOD = Working_Period;
        imp_pdf.Branch_Code = currentbranch;
        ds_client = imp_pdf.Imp_PDF_Upload_New_XML(Dt_gen, Dt_Item, Dt_DBK, Dt_Invoice, Dt_anx);

        try
        {
            if (ds_client.Tables[0].Rows.Count > 0)
            {
                ddl_ImporterName.DataSource = ds_client.Tables[0];
                ddl_ImporterName.DataTextField = "IMPORTER_NAME";
                ddl_ImporterName.DataTextField = "IMPORTER_NAME";
                ddl_ImporterName.DataBind();
            }
        }
        catch (Exception ex)
        {
            ddl_ImporterName.DataBind();
        }
        scheme_NOTN();
        Get_SchemeCode();
        ddlterms();
    }

    public void Get_SchemeCode()
    {
        DataSet ds_sh = new DataSet();
        adm.name = "SCHEME_IMPORT_CODE";
        Session["dss"] = adm.RetrieveAll_Scheme_Import();
        ds_sh = (DataSet)Session["dss"];
        ddlSchemeCode.DataSource = ds_sh;
        ddlSchemeCode.DataTextField = "SCHEME_CODE";
        ddlSchemeCode.DataValueField = "SCHEME_CODE";
        ddlSchemeCode.Items.Add("");
        ddlSchemeCode.DataBind();
        ddlSchemeCode.Items.Insert(0, new ListItem("", ""));
        ddlSchemeCode.Items.Insert(1, "00 - DUTIABLE");
    }

    public void Get_AdCode()
    {
        try
        {
            DataSet ds = new DataSet();
            Auto.Ename = "Get_ADCODE";
            Auto.Enamesearch = ViewState["imp_name"].ToString();
            Auto.NSearch = ViewState["IEC"].ToString();
            ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtAdcode.Text = ds.Tables[0].Rows[0]["IMPORT_ADCODE1"].ToString();
            }
        }
        catch(Exception ex)
        {
        }
    }

    public void ddlterms()
    {
        ddlTerms.Items.Add("FOB");
        ddlTerms.Items.Add("CI");
        ddlTerms.Items.Add("CF");
        ddlTerms.Items.Add("CIF");
    }

    protected void gv_ItemPDF_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }

    protected void gv_ItemPDF_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataTable GridViewMasterDataBind = (DataTable)ViewState["MasterDataChecking"];
            if (GridViewMasterDataBind != null)
            {
                TextBox txtItemDesc = e.Row.FindControl("txtItemDesc") as TextBox;
                if (txtItemDesc != null)
                {
                    string GetItemDescriptionInDS = txtItemDesc.Text;
                    if (rowIndex < GridViewMasterDataBind.Rows.Count)
                    {
                        string GetItemDescriptionInGV = GridViewMasterDataBind.Rows[rowIndex]["ITEM_DESC"].ToString();
                        if (GetItemDescriptionInDS == GetItemDescriptionInGV)
                        {
                            txtItemDesc.BorderColor = System.Drawing.Color.Red;
                            txtItemDesc.BackColor = System.Drawing.Color.MediumTurquoise;
                            rowIndex++;
                        }
                    }
                }
            }

            DataSet ds_schemeCode = (DataSet)Session["dss"];
            DropDownList ddl_SchemeCode = e.Row.FindControl("ddl_SchemeCode") as DropDownList;
            DropDownList ddl_Scheme_NOTN = e.Row.FindControl("ddl_Scheme_NOTN") as DropDownList;
            DropDownList ddl_Scheme_NOTN_SL = e.Row.FindControl("ddl_Scheme_NOTN_SL") as DropDownList;

            if (ddl_SchemeCode != null && ds_schemeCode != null)
            {
                ddl_SchemeCode.DataSource = ds_schemeCode.Tables[0];
                ddl_SchemeCode.DataTextField = "SCHEME_CODE";
                ddl_SchemeCode.DataValueField = "SCHEME_CODE";
                ddl_SchemeCode.DataBind();
                ddl_SchemeCode.Items.Insert(0, "00 - DUTIABLE");//SchemeCode

                
                string selectedSchemeCode = DataBinder.Eval(e.Row.DataItem, "SchemeCode").ToString();
                ddl_SchemeCode.SelectedValue = selectedSchemeCode;


                string str = ddl_SchemeCode.SelectedValue.ToString();
                string[] s1 = str.Split(new string[] { "-" }, StringSplitOptions.None);

                ddl_Scheme_NOTN.Items.Clear();
                ddl_Scheme_NOTN_SL.Items.Clear();

                if (s1[0].Trim().ToString() != "00")
                {
                    adm.SCHEME_IMPORT_CODE = s1[0].ToString();
                    adm.SCHEME_NOTN = "0";
                    adm.name = "SCHEME_NOTN";
                    ddl_Scheme_NOTN.DataSource = adm.RetrieveAll_Scheme_Import();
                    ddl_Scheme_NOTN.DataTextField = "SCHEME_NOTN";
                    ddl_Scheme_NOTN.DataValueField = "SCHEME_NOTN";
                    ddl_Scheme_NOTN.Items.Add(" ");
                    ddl_Scheme_NOTN.DataBind();
                    scheme_notn_slno();

                }
                else
                {
                    ddl_Scheme_NOTN.Items.Clear();
                    ddl_Scheme_NOTN_SL.Items.Clear();
                }
                ddl_Scheme_NOTN_SL.Items.Clear();

                adm.SCHEME_IMPORT_CODE = s1[0].ToString();
                adm.SCHEME_NOTN = ddl_Scheme_NOTN.SelectedValue;
                adm.name = "SCHEME_NOTN_SLNO";
                ddl_Scheme_NOTN_SL.DataSource = adm.RetrieveAll_Scheme_Import();
                ddl_Scheme_NOTN_SL.DataTextField = "SCHEME_NOTN_SLNO";
                ddl_Scheme_NOTN_SL.DataValueField = "SCHEME_NOTN_SLNO";
                ddl_Scheme_NOTN_SL.Items.Add(" ");
                ddl_Scheme_NOTN_SL.DataBind();
            }
        }
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Import PDF Upload', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Import PDF Upload', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg1(string msg)
    {
        // Create the script for the modal
        string script = @"
    <script>
        $(document).ready(function() {
            $('#modalMessage').text('" + msg + @"');  // Set the message
            $('#myModal').modal('show');             // Show the modal

            // Auto-close after 5 seconds
            setTimeout(function() {
                $('#myModal').modal('hide');
            }, 5000); // 5000 ms = 5 seconds
        });
    </script>";

        // Register the startup script to show the modal
        ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal", script, false);
    }

    public void Call_Server_Side_Method()
    {
        txtImporterName.Attributes.Add("onblur", "javascript:CallServerside_Importer_ChkBind('" + txtImporterName.ClientID + "')");
        txtCTH.Attributes.Add("onblur", "javascript:Call_CTH_Rate('" + txtCTH.ClientID + "', '" + txtBasicSLNO.ClientID + "')");

        //--------------------------------------------------NOTN-----------------------------------------------------------------------------------------------------
        //--------------------------------------------------NOTNSL---------------------------------------------------------------------------------------------------
        //BASIC_DUTY_CTH
        txtBasicSLNO.Attributes.Add("onBlur", "javascript:CallServerside_Basic_Duty_Cth_Notn_Slno('" + txtBasicSLNO.ClientID + "', '" + txtBasicNotn.ClientID + "')");
        //BASIC_DUTY_CTH

        //Social_Welfare_Cth
        txtSW_Slno.Attributes.Add("onblur", "javascript:CallServerside_Social_Welfare_Notn_Slno('" + txtSW_Slno.ClientID + "', '" + txtSW_Noti.ClientID + "')");
        //Social_Welfare_Cth    

        //------------------------------------------------auto search-----------------------------------------------------------------
        txtitemCountyof_orgin.Attributes.Add("onblur", "javascript:Call_CountryOrigin('" + txtitemCountyof_orgin.ClientID + "')");
        txtitemCountyof_orgin.Attributes.Add("onkeyup", "javascript:Call_CountryOrigin('" + txtitemCountyof_orgin.ClientID + "')");
        txtPortOfOrigin.Attributes.Add("onblur", "javascript:CallServerside_Port_of_orgin('" + txtPortOfOrigin.ClientID + "', '" + txtPortOfOrigin.ClientID + "')");
        txtPortOfOrigin.Attributes.Add("onfocus", "javascript:CallServerside_Port_of_orgin('" + txtPortOfOrigin.ClientID + "', '" + txtPortOfOrigin.ClientID + "')");

        txt_AIDC_CessSlno.Attributes.Add("onblur", "javascript:Call_AIDC_Master('" + txt_AIDC_CessSlno.ClientID + "', '" + txt_AIDC_CessNoti.ClientID + "')");
        //IGST
        txt_IGST_SlNo.Attributes.Add("onblur", "javascript:CallServerside_txt_IGST_LEVY_SLNO('" + txt_IGST_SlNo.ClientID + "', '" + txt_IGST_Noti.ClientID + "')");
    }

    protected void btnPrevData_Click(object sender, EventArgs e)
    {
        try
        {
            int FileUploadLimit = 0;
            if (COMPANY_IDD == "10")
            {
                FileUploadLimit = 10;
            }
            else
            {
                FileUploadLimit = 5;
            }

            if (Request.Files.Count > 0 && Request.Files.Count <= FileUploadLimit)
            {
                Get_Upload_File();               
                lblmsg.Text = "";
            }
            else
            {
                if (Request.Files.Count > FileUploadLimit)
                {
                    Alert_msg("Please Upload a File Minimum " + FileUploadLimit + "..!");
                }
                else
                {
                    Alert_msg("Please Upload File..!");
                }
            }
        }
        catch (Exception ex)
        {
            log.makeLog("Message ==> " + ex.Message);
            lblmsg.Text = " Message ==> " + ex.Message + " InnerException ==> " + ex.InnerException + " StackTrace ==>" + ex.StackTrace;
        }
        Get_AdCode();
    }

    public string Get_Upload_File()
    {
        string response = ""; string strFolderPath = ""; string strImagePath = ""; string QTYCode = ""; string API_Output = "";

        try
        {
            string savePath = Server.MapPath("~/Submission/ImportPDFReader/");
            if (Directory.Exists(savePath) == false)
            {
                Directory.CreateDirectory(savePath);
            }
            if (Request.Files.Count > 0 && Request.Files.Count <= 5)
            {
                int FileUploadCount = Request.Files.Count;
                ViewState["FileUploadCount"] = FileUploadCount;

                for (int ai = 0; ai < Request.Files.Count; ai++)
                {
                    HttpPostedFile uploadedFile = Request.Files[ai]; // Access file by index

                    if (uploadedFile != null && uploadedFile.ContentLength > 0)
                    {
                        strFolderPath = Path.Combine(Request.PhysicalApplicationPath, savePath);
                        strImagePath = Path.Combine(strFolderPath, uploadedFile.FileName.ToString());
                        uploadedFile.SaveAs(strImagePath);

                        if (Path.GetExtension(strImagePath).Equals(".pdf", StringComparison.OrdinalIgnoreCase))
                        {
                            int pageCount = 0;
                            PdfReader reader = new PdfReader(strImagePath);
                            pageCount = reader.NumberOfPages;
                            hd_PageCount.Value = pageCount.ToString();
                        }
                    }

                    string imp_name = "", branch_slno = "", Info_Uqc = "", Info_Msr = "", IEC = "", AIDC_CessRate = "", AIDC_CessNoti = "", AIDC_CessSlno = "", IGST_Noti = "",
                        IGST_SlNo = "", IGST_Rate = "", IGST_LEVY_COMPENSATION_CESS_NOTN = "", IGST_LEVY_COMPENSATION_CESS_SLNO = "", IGST_LEVY_COMPENSATION_CESS_RATE = "", PurchaseOrderNo = "", PurchaseOrderDate = "",
                        Basic_Noti = "", Basic_Slno = "", Basic_Rate = "", SW_Noti = "", SW_Slno = "", SW_Rate = "";
                    if (ddl_ImporterName.SelectedValue.Contains("--"))
                    {
                        string[] sp = ddl_ImporterName.SelectedValue.Replace("--", "^").Split('^');
                        branch_slno = sp[0];
                        imp_name = sp[1];

                        ViewState["branch_slno"] = branch_slno;
                        ViewState["imp_name"] = imp_name;
                    }
                    if (COMPANY_IDD == "100" || COMPANY_IDD == "10")
                    {
                        string FilenameWithOutExtension = Path.GetFileNameWithoutExtension(uploadedFile.FileName);
                        ds_API = Get_AccessToken_Invoice(GetLocalAPIData, Server.MapPath("~/Submission/ImportChecklistReader/Local_Test/" + FilenameWithOutExtension + ".txt"));
                    }
                    else
                    {
                        API_Output = UploadPdfWithParameters(strImagePath);
                        ds_API = JsonConvert.DeserializeObject<DataSet>(API_Output);
                    }
                    if (ds_API.Tables[0].Rows.Count > 0 && ds_API.Tables[1].Rows.Count > 0 && ds_API.Tables[2].Rows.Count > 0)
                    {
                        txtSupplier.Text = ds_API.Tables[1].Rows[0]["SupplierName"].ToString();
                        hd_Supplier.Value = ds_API.Tables[1].Rows[0]["SupplierName"].ToString();
                        txtCountryOfOrigin.Text = ds_API.Tables[0].Rows[0]["CountryOfOrigin"].ToString();
                        txtPortOfOrigin.Text = ds_API.Tables[0].Rows[0]["PortOfOrigin"].ToString();
                        QTYCode = ds_API.Tables[1].Rows[0]["QtyCode"].ToString();
                        txtImporterName.Text = ds_API.Tables[0].Rows[0]["ImporterName"].ToString();
                        hd_ImporterName.Value = ds_API.Tables[0].Rows[0]["ImporterName"].ToString();
                        hd_ImporterAdd1.Value = ds_API.Tables[0].Rows[0]["ImporterAdd1"].ToString();
                        hd_ImporterAdd2.Value = ds_API.Tables[0].Rows[0]["ImporterAdd2"].ToString();
                        hd_ImporterAdd3.Value = ds_API.Tables[0].Rows[0]["ImporterAdd3"].ToString();
                        hd_ImporterAdd4.Value = ds_API.Tables[0].Rows[0]["ImporterAdd4"].ToString();

                        hd_Freight.Value = ds_API.Tables[0].Rows[0]["Freight"].ToString();
                        hd_Insurance.Value = ds_API.Tables[0].Rows[0]["Insurance"].ToString();
                        hd_MiscCharge.Value = ds_API.Tables[0].Rows[0]["MiscCharge"].ToString();

                        IEC = ds_API.Tables[0].Rows[0]["IEC"].ToString();
                        if (IEC == "" || IEC == string.Empty || IEC == null)
                        {
                            Auto_Search Auto = new Auto_Search();
                            DataSet ds = new DataSet();
                            Auto.Ename = "Import_Details_Bind";
                            Auto.Enamesearch = imp_name;
                            Auto.NSearch = branch_slno;
                            ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                string IEC_NO = ds.Tables[0].Rows[0]["IMP_EXP_IECNO"].ToString();
                                string BRANCH_NO = ds.Tables[0].Rows[0]["IMP_EXP_BRSLNO"].ToString();
                                ViewState["IEC"] = IEC_NO;
                            }
                        }
                        else
                        {
                            ViewState["IEC"] = IEC;
                        }

                        INVOICE_SLNO = 1 + INVOICE_SLNO;
                        if (INVOICE_SLNO == 1)
                        {
                            dt_Temp_Inv.Columns.Add("INVOICE_SLNO");
                            dt_Temp_Inv.Columns.Add("InvoiceNo");
                            dt_Temp_Inv.Columns.Add("InvoiceDate");
                            dt_Temp_Inv.Columns.Add("Currency");
                            dt_Temp_Inv.Columns.Add("Terms");
                            dt_Temp_Inv.Columns.Add("InvoiceValue");
                            dt_Temp_Inv.Columns.Add("PurchaseOrderNo");
                            dt_Temp_Inv.Columns.Add("PurchaseOrderDate");

                            Dt_Item.Columns.Add("InvoiceSlNo");
                            Dt_Item.Columns.Add("ItemSlNo");
                            Dt_Item.Columns.Add("ITEM_DESC");
                            Dt_Item.Columns.Add("Quantity");
                            Dt_Item.Columns.Add("Rate");
                            Dt_Item.Columns.Add("Amount");
                            Dt_Item.Columns.Add("QTYCode");
                            Dt_Item.Columns.Add("HSCode");
                            Dt_Item.Columns.Add("SchemeCode");
                            Dt_Item.Columns.Add("Scheme_NOTN");
                            Dt_Item.Columns.Add("Scheme_NOTN_SL");
                            Dt_Item.Columns.Add("Basic_Noti");
                            Dt_Item.Columns.Add("Basic_Slno");
                            Dt_Item.Columns.Add("Basic_Rate");
                            Dt_Item.Columns.Add("info_MSR");
                            Dt_Item.Columns.Add("info_UQC");
                            Dt_Item.Columns.Add("itemCountyof_orgin");
                            Dt_Item.Columns.Add("SW_Noti");
                            Dt_Item.Columns.Add("SW_Slno");
                            Dt_Item.Columns.Add("SW_Rate");
                            Dt_Item.Columns.Add("AIDC_CessNoti");
                            Dt_Item.Columns.Add("AIDC_CessSlno");
                            Dt_Item.Columns.Add("AIDC_CessRate");
                            Dt_Item.Columns.Add("IGST_Noti");
                            Dt_Item.Columns.Add("IGST_SlNo");
                            Dt_Item.Columns.Add("IGST_Rate");
                            Dt_Item.Columns.Add("PartNo");
                            Dt_Item.Columns.Add("IGST_LEVY_COMPENSATION_CESS_NOTN");
                            Dt_Item.Columns.Add("IGST_LEVY_COMPENSATION_CESS_SLNO");
                            Dt_Item.Columns.Add("IGST_LEVY_COMPENSATION_CESS_RATE");

                            dt_Temp_IGM.Columns.Add("IGM_MAWB_MBL");
                            dt_Temp_IGM.Columns.Add("IGM_MAWB_MBLDATE");
                            dt_Temp_IGM.Columns.Add("IGM_HAWB_HBLNO");
                            dt_Temp_IGM.Columns.Add("IGM_HAWB_HBLDATE");
                            dt_Temp_IGM.Columns.Add("IGM_NOOFPACKAGE");
                            dt_Temp_IGM.Columns.Add("IGM_GROSSWEIGHT");

                            dt_Temp_Con.Columns.Add("CONTAINER_NO");
                            dt_Temp_Con.Columns.Add("SEAL_NO");
                            dt_Temp_Con.Columns.Add("TYPE");

                            dt_Temp_Bond.Columns.Add("BOND_NO");
                            dt_Temp_Bond.Columns.Add("BOND_TYPE");
                            dt_Temp_Bond.Columns.Add("BOND_LOCATION");
                        }

                        for (int ak = 0; ak <= ds_API.Tables[1].Rows.Count - 1; ak++)
                        {
                            string InvoiceSlNo = "1";
                            if (Request.Files.Count == 1)
                            {
                                InvoiceSlNo = ds_API.Tables[1].Rows[ak]["InvoiceSlNo"].ToString();
                            }
                            else
                            {
                                InvoiceSlNo = INVOICE_SLNO.ToString();
                            }
                            txtInvNo.Text = ds_API.Tables[1].Rows[ak]["InvoiceNo"].ToString();
                            txtInvDate.Text = ds_API.Tables[1].Rows[ak]["InvoiceDate"].ToString();
                            txtCurrency.Text = Get_Valid_Curr_Name(ds_API.Tables[1].Rows[ak]["Currency"].ToString());
                            string TERMS1 = ds_API.Tables[1].Rows[ak]["Terms"].ToString();
                            try
                            {
                                ddlTerms.Text = TERMS1.Replace("FCA", "FOB").Replace("CIP", "CIF").Replace("CPT", "CF").Replace("C. I. F", "CIF").Replace("CFR", "CF");
                            }
                            catch
                            {
                                ddlTerms.Text = "FOB";
                            }
                            if (ds_API.Tables[1].Rows[ak]["InvoiceValue"].ToString() != "" && ds_API.Tables[1].Rows[ak]["InvoiceValue"].ToString() != null)
                            {
                                if (PdfClientName == "VEGA")
                                {
                                    txtInvValue.Text = ds_API.Tables[1].Rows[ak]["InvoiceValue"].ToString().Replace(".", "").Replace(",", ".");
                                }
                                else
                                {
                                    txtInvValue.Text = ds_API.Tables[1].Rows[ak]["InvoiceValue"].ToString().Replace(",", "").Replace("¥", "");
                                }
                            }
                            else
                            {
                                txtInvValue.Text = "0";
                            }

                            if (PdfClientName == "ALFA LAVAL")
                            {
                                PurchaseOrderNo = ds_API.Tables[1].Rows[ak]["PurchaseOrderNo"].ToString();
                                PurchaseOrderDate = ds_API.Tables[1].Rows[ak]["PurchaseOrderDate"].ToString();
                            }

                            dt_Temp_Inv.Rows.Add(InvoiceSlNo, txtInvNo.Text.Trim(), txtInvDate.Text, txtCurrency.Text, ddlTerms.Text, txtInvValue.Text, PurchaseOrderNo, PurchaseOrderDate);

                            ViewState["dt_Invoice"] = dt_Temp_Inv;
                        }

                        if (COMPANY_IDD == "341" || COMPANY_IDD == "1" || COMPANY_IDD == "10")
                        {
                            string MBLNo = ds_API.Tables[3].Rows[0]["MBLNo"].ToString().Replace("-", "");
                            string MBLDate = ds_API.Tables[3].Rows[0]["MBLDate"].ToString();
                            if (MBLDate != "" && MBLDate != null)
                            {
                                MBLDate = Get_Valid_Date(ds_API.Tables[3].Rows[0]["MBLDate"].ToString());
                            }
                            string HBLNo = ds_API.Tables[3].Rows[0]["HBLNo"].ToString().Replace("-", "");
                            string HBLDate = ds_API.Tables[3].Rows[0]["HBLDate"].ToString();
                            if (HBLDate != "" && HBLDate != null)
                            {
                                HBLDate = Get_Valid_Date(ds_API.Tables[3].Rows[0]["HBLDate"].ToString());
                            }
                            string IGM_NOOFPACKAGE = ds_API.Tables[0].Rows[0]["TotalCarton"].ToString().Replace(",", "");
                            string IGM_GROSSWEIGHT = ds_API.Tables[0].Rows[0]["TotalGrossWeight"].ToString().Replace(",", "");

                            dt_Temp_IGM.Rows.Add(MBLNo, MBLDate, HBLNo, HBLDate, IGM_NOOFPACKAGE, IGM_GROSSWEIGHT);
                            ViewState["dt_IGMDetails"] = dt_Temp_IGM;


                            for (int ka = 0; ka <= ds_API.Tables[3].Rows.Count - 1; ka++)
                            {
                                string Containerslno = ds_API.Tables[3].Rows[ka]["Containerslno"].ToString();
                                string ContainerNo = ds_API.Tables[3].Rows[ka]["ContainerNo"].ToString().Replace("-", "");
                                string ContainerSealNo = ds_API.Tables[3].Rows[ka]["ContainerSealNo"].ToString().Replace("¡", "i");
                                string ContainerSize = ds_API.Tables[3].Rows[ka]["ContainerSize"].ToString().Replace("'HQ", "HC");
                                if ((ContainerNo != "" || ContainerNo != "") && Containerslno != "")
                                {
                                    dt_Temp_Con.Rows.Add(ContainerNo, ContainerSealNo, ContainerSize);
                                }

                                ViewState["dt_ContainerDetails"] = dt_Temp_Con;
                            }

                            for (int Bo = 0; Bo <= ds_API.Tables[4].Rows.Count - 1; Bo++)
                            {
                                string Bondslno = ds_API.Tables[4].Rows[Bo]["Bondslno"].ToString();
                                string BondNo = ds_API.Tables[4].Rows[Bo]["BondNo"].ToString();
                                string BondType = ds_API.Tables[4].Rows[Bo]["BondType"].ToString();
                                string BondLocation = ds_API.Tables[4].Rows[Bo]["BondLocation"].ToString();

                                dt_Temp_Bond.Rows.Add(BondNo, BondType, BondLocation);
                                ViewState["dt_BondDetails"] = dt_Temp_Bond;
                            }
                        }

                        int totalItemSlNo = ds_API.Tables[2].Rows.Count;

                        for (int i = 0; i <= totalItemSlNo - 1; i++)
                        {
                            string ItemInvoiceSlNo = "1";
                            if (Request.Files.Count == 1)
                            {
                                ItemInvoiceSlNo = ds_API.Tables[2].Rows[i]["InvoiceSlNo"].ToString();
                            }
                            else
                            {
                                ItemInvoiceSlNo = INVOICE_SLNO.ToString();
                            }
                            string ItemSlNo = ds_API.Tables[2].Rows[i]["ItemSlNo"].ToString();
                            string ItemDesc = ds_API.Tables[2].Rows[i]["ItemDesc"].ToString();
                            string Quantity = ds_API.Tables[2].Rows[i]["Quantity"].ToString();
                            string Rate = ds_API.Tables[2].Rows[i]["Rate"].ToString();
                            string Amount = ds_API.Tables[2].Rows[i]["Amount"].ToString();
                            string PartNo = ds_API.Tables[2].Rows[i]["PartNo"].ToString();
                            string PONumber = ds_API.Tables[2].Rows[i]["PONumber"].ToString();
                            string NetWeight = ds_API.Tables[2].Rows[i]["ItemNETWEIGHT"].ToString();
                            string HSCode = ds_API.Tables[2].Rows[i]["ItemHSCODE"].ToString().Replace(".", "").Replace(" ", "").Replace("null", "").Trim();
                            if (HSCode.Length > 8)
                            {
                                string substring = HSCode.Substring(0, 8);
                                HSCode = substring;
                            }
                            Basic_Noti = ds_API.Tables[2].Rows[i]["BCDNotn"].ToString();
                            Basic_Slno = ds_API.Tables[2].Rows[i]["BCDSlno"].ToString();
                            Basic_Rate = ds_API.Tables[2].Rows[i]["BCDRate"].ToString().Replace("%", "");
                            SW_Noti = ds_API.Tables[2].Rows[i]["SwNotn"].ToString();
                            SW_Slno = ds_API.Tables[2].Rows[i]["SwSlno"].ToString();
                            SW_Rate = ds_API.Tables[2].Rows[i]["SwRate"].ToString().Replace("%", "");
                            AIDC_CessNoti = ds_API.Tables[2].Rows[i]["AIDCNotn"].ToString();
                            AIDC_CessSlno = ds_API.Tables[2].Rows[i]["AIDCSlno"].ToString();
                            AIDC_CessRate = ds_API.Tables[2].Rows[i]["AIDCRate"].ToString().Replace("%", "");
                            IGST_Noti = ds_API.Tables[2].Rows[i]["IGSTNotn"].ToString();
                            IGST_SlNo = ds_API.Tables[2].Rows[i]["IGSTSlno"].ToString();
                            IGST_Rate = ds_API.Tables[2].Rows[i]["IGSTRate"].ToString().Replace("%", "");
                            IGST_LEVY_COMPENSATION_CESS_NOTN = ds_API.Tables[2].Rows[i]["IGSTCPNotn"].ToString();
                            IGST_LEVY_COMPENSATION_CESS_SLNO = ds_API.Tables[2].Rows[i]["IGSTCPSlno"].ToString();
                            IGST_LEVY_COMPENSATION_CESS_RATE = ds_API.Tables[2].Rows[i]["IGSTCPRate"].ToString().Replace("%", "");

                            //string ItemCountry = ds_API.Tables[2].Rows[i]["ItemCountry"].ToString().Replace("null", "");
                            string ItemCountry = ds_API.Tables[0].Rows[0]["CountryOfOrigin"].ToString();

                            if (ItemCountry != "" && ItemCountry != null && ItemCountry != string.Empty)
                            {
                                if (ItemCountry.Trim().Length == 2)
                                {
                                    DataSet ds = new DataSet();
                                    Auto_Search Auto = new Auto_Search();
                                    Auto.Ename = "Get_CountryName";
                                    Auto.Enamesearch = ItemCountry;
                                    ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        ItemCountry = ds.Tables[0].Rows[0]["COUNTRY_NAME"].ToString();
                                    }
                                }
                            }

                            if (PdfClientName == "VEGA")
                            {
                                Quantity = ds_API.Tables[2].Rows[i]["Quantity"].ToString().Replace(".", "").Replace(",", ".");
                                Rate = ds_API.Tables[2].Rows[i]["Rate"].ToString().Replace(".", "").Replace(",", ".");
                                Amount = ds_API.Tables[2].Rows[i]["Amount"].ToString().Replace(".", "").Replace(",", ".");
                            }
                            else if (PdfClientName == "FOXCONN")
                            {
                                decimal Calc_Amount = Convert.ToDecimal(Quantity.Replace(",", "")) * Convert.ToDecimal(Rate.Replace(",", ""));
                                Amount = Calc_Amount.ToString("N6").Replace(",", "");                                
                            }                            

                            DataSet ds_get_data = new DataSet();
                            erm.Eproduct_imp_ceth = imp_name;
                            erm.Eproduct_imp_description = ItemDesc;
                            erm.Ename = "Get_Master_Data";
                            erm.EWorking_Period = Working_Period;
                            ds_get_data = erm.RetrieveAll_Import_PDF_Settings_MASTER();

                            if (ds_get_data.Tables[0].Rows.Count > 0)
                            {

                                Basic_Noti = ds_get_data.Tables[0].Rows[0]["PRODUCT_BCD_NOTN"].ToString();
                                Basic_Slno = ds_get_data.Tables[0].Rows[0]["PRODUCT_BCD_SLNO"].ToString();
                                Basic_Rate = ds_get_data.Tables[0].Rows[0]["PRODUCT_BCD_RATE"].ToString();
                                string itemCountyof_orgin = ds_get_data.Tables[0].Rows[0]["PRODUCT_COUNTRY_ORIGIN"].ToString();
                                SW_Noti = ds_get_data.Tables[0].Rows[0]["SOCIAL_WELFARE_NOTN"].ToString();
                                SW_Slno = ds_get_data.Tables[0].Rows[0]["SOCIAL_WELFARE_NOTN_SLNO"].ToString();
                                SW_Rate = ds_get_data.Tables[0].Rows[0]["SOCIAL_WELFARE_RATE"].ToString();
                                AIDC_CessNoti = ds_get_data.Tables[0].Rows[0]["AIDC_NOTN"].ToString();
                                AIDC_CessSlno = ds_get_data.Tables[0].Rows[0]["AIDC_NOTN_SLNO"].ToString();
                                AIDC_CessRate = ds_get_data.Tables[0].Rows[0]["AIDC_RATE"].ToString();
                                IGST_Noti = ds_get_data.Tables[0].Rows[0]["IGST_LEVY_NOTN"].ToString();
                                IGST_SlNo = ds_get_data.Tables[0].Rows[0]["IGST_LEVY_SLNO"].ToString();
                                IGST_Rate = ds_get_data.Tables[0].Rows[0]["IGST_LEVY_RATE"].ToString();                               
                                PartNo = ds_get_data.Tables[0].Rows[0]["PART_NO"].ToString();
                                IGST_LEVY_COMPENSATION_CESS_NOTN = ds_get_data.Tables[0].Rows[0]["IGST_LEVY_COMPENSATION_CESS_NOTN"].ToString();
                                IGST_LEVY_COMPENSATION_CESS_SLNO = ds_get_data.Tables[0].Rows[0]["IGST_LEVY_COMPENSATION_CESS_SLNO"].ToString();
                                IGST_LEVY_COMPENSATION_CESS_RATE = ds_get_data.Tables[0].Rows[0]["IGST_LEVY_COMPENSATION_CESS_RATE"].ToString();
                                string Master_HSCode = ds_get_data.Tables[0].Rows[0]["PRODUCT_RITC"].ToString();
                                if (Master_HSCode != "" && Master_HSCode != string.Empty)
                                {
                                    HSCode = Master_HSCode;
                                }
                                Auto.Ename = "Get_CTH_Info_Uqc";
                                Auto.Enamesearch = HSCode;
                                Auto.Notn_No_Search = HSCode;
                                DataSet ds_MSR_UQC = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

                                if (ds_MSR_UQC.Tables[0].Rows.Count > 0)
                                {
                                    Info_Uqc = ds_MSR_UQC.Tables[0].Rows[0][0].ToString();
                                    string Chk_Qty_Code = Get_Valid_Qty_Code(QTYCode);
                                    if ((Info_Uqc == "KGS" || ((Chk_Qty_Code == "NOS" || Chk_Qty_Code == "PCS" || Chk_Qty_Code == "SET") && Info_Uqc == "MTR")) && (NetWeight != "" && NetWeight != null))
                                    {
                                        Info_Msr = NetWeight.ToString().Replace(",", "");
                                    }
                                    else
                                    {
                                        Info_Msr = Quantity.ToString().Replace(",", "");
                                    }
                                }
                                else
                                {
                                    Info_Msr = Quantity.ToString().Replace(",", "");
                                    Info_Uqc = Get_Valid_Qty_Code(QTYCode);
                                }
                                if (PdfClientName == "JAAZ" && (NetWeight != "" && NetWeight != null))
                                {
                                    Info_Msr = NetWeight.ToString().Replace(",", "");
                                }
                                if (itemCountyof_orgin == "" || itemCountyof_orgin == string.Empty || itemCountyof_orgin == null)
                                {
                                    itemCountyof_orgin = ItemCountry;
                                }
                                Dt_Item.Rows.Add(ItemInvoiceSlNo, ItemSlNo, ItemDesc.Trim(), Quantity.Replace(",", ""), Rate.Replace(",", ""), Amount.Replace(",", ""),
                                    Get_Valid_Qty_Code(QTYCode), HSCode, "00 - DUTIABLE", "", "", Basic_Noti, Basic_Slno, Basic_Rate, Info_Msr, Info_Uqc, itemCountyof_orgin,
                                    SW_Noti, SW_Slno, SW_Rate, AIDC_CessNoti, AIDC_CessSlno, AIDC_CessRate, IGST_Noti, IGST_SlNo, IGST_Rate, PartNo, IGST_LEVY_COMPENSATION_CESS_NOTN, IGST_LEVY_COMPENSATION_CESS_SLNO, IGST_LEVY_COMPENSATION_CESS_RATE);
                            }
                            else
                            {
                                if (HSCode != "" && HSCode != string.Empty)
                                {
                                    try
                                    {
                                        Auto.Ename = "Get_CTH_Info_Uqc";
                                        Auto.Enamesearch = HSCode;
                                        Auto.Notn_No_Search = HSCode;
                                        DataSet ds_MSR_UQC = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

                                        if (ds_MSR_UQC.Tables[0].Rows.Count > 0)
                                        {
                                            Info_Uqc = ds_MSR_UQC.Tables[0].Rows[0][0].ToString();
                                            if (Info_Uqc == "KGS" && (NetWeight != "" && NetWeight != null))
                                            {
                                                Info_Msr = NetWeight.ToString().Replace(",", "");
                                            }
                                            else
                                            {
                                                Info_Msr = Quantity.ToString().Replace(",", "");
                                            }
                                        }
                                        else
                                        {
                                            Info_Msr = Quantity.ToString().Replace(",", "");
                                            Info_Uqc = Get_Valid_Qty_Code(QTYCode);
                                        }

                                        if (AIDC_CessNoti == "" || AIDC_CessSlno == "" || AIDC_CessRate == "")
                                        {
                                            DataSet ds_AIDC = new DataSet();
                                            adm.AIDC_RITC_NO = HSCode;
                                            adm.Ename = "ITEM_RITC";
                                            ds_AIDC = adm.Get_AIDC_CESS_SELECT();
                                            if (ds_AIDC.Tables[0].Rows.Count > 0)
                                            {
                                                AIDC_CessNoti = ds_AIDC.Tables[0].Rows[0]["AIDC_NOTN_NO"].ToString();
                                                AIDC_CessSlno = ds_AIDC.Tables[0].Rows[0]["AIDC_NOTN_SLNO"].ToString();
                                                AIDC_CessRate = ds_AIDC.Tables[0].Rows[0]["AIDC_NOTN_RATE"].ToString();
                                            }
                                            else
                                            {
                                                AIDC_CessNoti = "011/2021";
                                                AIDC_CessSlno = "17";
                                                AIDC_CessRate = "0.00";
                                            }
                                        }

                                        if (IGST_Noti == "" || IGST_SlNo == "" || IGST_Rate == "")
                                        {
                                            DataSet ds_IGST = new DataSet();
                                            Auto.Ename = "Get_IGST_NOTN_SLNO_RITC";
                                            Auto.Enamesearch = HSCode;
                                            Auto.Notn_No_Search = HSCode;

                                            ds_IGST = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
                                            if (ds_IGST.Tables[1].Rows.Count > 0)//default Flag entry enabled for all sugg.by Subbu sir
                                            {
                                                IGST_Noti = ds_IGST.Tables[1].Rows[0]["LEVY_1NOTIFICATION"].ToString();
                                                IGST_SlNo = ds_IGST.Tables[1].Rows[0]["LEVY_1NOTIFICATION_SLNO"].ToString();
                                                IGST_Rate = ds_IGST.Tables[1].Rows[0]["LEVY_1NOTIFICATION_RATE"].ToString();

                                                if (IGST_Noti != "")
                                                {
                                                    IGST_LEVY_COMPENSATION_CESS_NOTN = "001/2017";
                                                    IGST_LEVY_COMPENSATION_CESS_SLNO = "56";
                                                    IGST_LEVY_COMPENSATION_CESS_RATE = "0.00";
                                                }
                                            }
                                        }
                                    }
                                    catch(Exception ex)
                                    {
                                    }
                                }
                                else
                                {
                                    Info_Msr = Quantity.ToString().Replace(",", "");
                                    Info_Uqc = Get_Valid_Qty_Code(QTYCode);
                                }
                                if (PdfClientName == "JAAZ" && (NetWeight != "" && NetWeight != null))
                                {
                                    Info_Msr = NetWeight.ToString().Replace(",", "");
                                }

                                Dt_Item.Rows.Add(ItemInvoiceSlNo, ItemSlNo, ItemDesc, Quantity.Replace(",", ""), Rate.Replace(",", ""), Amount.Replace(",", ""),
                                    Get_Valid_Qty_Code(QTYCode), HSCode, "00 - DUTIABLE", "", "", Basic_Noti, Basic_Slno, Basic_Rate, Info_Msr, Info_Uqc, ItemCountry,
                                    SW_Noti, SW_Slno, SW_Rate, AIDC_CessNoti, AIDC_CessSlno, AIDC_CessRate, IGST_Noti, IGST_SlNo, IGST_Rate, PartNo, IGST_LEVY_COMPENSATION_CESS_NOTN, IGST_LEVY_COMPENSATION_CESS_SLNO, IGST_LEVY_COMPENSATION_CESS_RATE);
                            }
                            HSCode = ""; Basic_Noti = ""; Basic_Slno = ""; Basic_Rate = ""; SW_Noti = ""; SW_Slno = ""; SW_Rate = "";AIDC_CessNoti = ""; 
                            AIDC_CessSlno = ""; AIDC_CessRate = ""; IGST_Noti = ""; IGST_SlNo = ""; IGST_Rate = ""; IGST_LEVY_COMPENSATION_CESS_NOTN = ""; IGST_LEVY_COMPENSATION_CESS_SLNO = ""; IGST_LEVY_COMPENSATION_CESS_RATE = "";
                        }
                    }
                    DataSet ds_except = new DataSet();
                    imp_pdf.IMPORTER_NAME = imp_name;
                    imp_pdf.BRANCH_NO = branch_slno;
                    imp_pdf.JOBNO = JOBNO;
                    imp_pdf.flag = "Select_Except_desc_from_Master";
                    imp_pdf.USER_ID = currentuser;
                    imp_pdf.WORKINGPERIOD = Working_Period;
                    imp_pdf.Branch_Code = currentbranch;

                    ViewState["ItemDetails"] = Dt_Item;
                    gv_ItemPDF.DataSource = Dt_Item;
                    gv_ItemPDF.DataBind();

                    lbl_loading.Text = "<span style='color: green; font-weight: bold;'>✅ File converted successfully... Click Upload.</span>";
                    btnupload.Visible = true;

                    if (gv_ItemPDF.Rows.Count > 0)
                    {
                        hdn_missed_Desc.Value = "0";
                        ViewState["GridViewData"] = Dt_Item;
                        ListBox_ItemSlno.DataSource = Dt_Item;
                        ListBox_ItemSlno.DataTextField = "ItemSlNo";
                        ListBox_ItemSlno.DataValueField = "ItemSlNo";
                        ListBox_ItemSlno.DataBind();
                    }

                    if (gv_ItemPDF.Rows.Count > 0)
                    {
                        ViewState["GridViewData"] = Dt_Item;
                        Select_ItemRITC();
                        Get_AdCode();
                    }
                    lblmsg.Text = "";

                    if (gv_ItemPDF.HeaderRow != null)
                    {
                        gv_ItemPDF.UseAccessibleHeader = true;
                        gv_ItemPDF.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }

                    con.Open();
                    SqlCommand Scmd =
                        new SqlCommand(
                            "select * from PDF_AI_COUNT_DETAILS where PDF_JOB_NO = '" + txtjobPS.Text + "' and PDF_EXP_IMP_NAME='" + imp_name + "' and PDF_BRANCH_CODE ='" + currentbranch + "'", con);
                    SqlDataAdapter sda = new SqlDataAdapter(Scmd);
                    DataSet Sds = new DataSet();
                    sda.Fill(Sds);
                    con.Close();
                    con.Open();
                    if (Sds.Tables[0].Rows.Count > 0)
                    {
                        string PDF_ID = Sds.Tables[0].Rows[0]["PDF_ID"].ToString();
                        string PDF_UPLOAD_COUNT = Sds.Tables[0].Rows[0]["PDF_UPLOAD_COUNT"].ToString();
                        SqlCommand Ucmd =
                          new SqlCommand(
                              "Update PDF_AI_COUNT_DETAILS set PDF_UPLOAD_COUNT=('" + PDF_UPLOAD_COUNT + "'+1),PDF_REMARKS= PDF_REMARKS + " + hd_PageCount.Value + ",PDF_USER_ID='" + currentuser + "',PDF_DATE_TIME=GetDate()," +
                        "PDF_STATUS='S',PDF_BRANCH_CODE='" + currentbranch + "',PDF_WORKING_PERIOD='" + Working_Period + "' where PDF_ID=" + PDF_ID + "", con);
                        int result = Ucmd.ExecuteNonQuery();
                    }
                    else
                    {

                        SqlCommand cmd =
                            new SqlCommand(
                                "insert into PDF_AI_COUNT_DETAILS(PDF_JOB_NO,PDF_EXP_IMP_NAME,PDF_MODE,PDF_UPLOAD_COUNT,PDF_REMARKS,PDF_USER_ID,PDF_DATE_TIME,PDF_STATUS,PDF_BRANCH_CODE,PDF_WORKING_PERIOD) values('" + txtjobPS.Text + "','" +
                                imp_name + "','ICH','1'," + hd_PageCount.Value + ",'" + currentuser + "',GetDate(),'S','" + currentbranch + "','" + Working_Period + "')", con);
                        int result = cmd.ExecuteNonQuery();

                    }
                    con.Close();
                }
            }
        }
        catch (WebException webEx)
        {
            if (webEx.Response != null)
            {
                using (var errorResponse = (HttpWebResponse)webEx.Response)
                {
                    using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                    {
                        string errorResponseContent = reader.ReadToEnd();
                        Console.WriteLine("Error Response Content: " + errorResponseContent);
                    }
                }
            }
            Console.WriteLine("WebException: " + webEx.Message);
        }
        catch (Exception ex)
        {
            // Handle any other exceptions
            Console.WriteLine("Error occurred: " + ex.Message);
        }

        return response;
    }

    public string UploadPdfWithParameters(string FilePath)
    {
        string result = "";
        string imp_name = ViewState["imp_name"].ToString().Trim();
        if (imp_name == "RELIANCE CONSUMER PRODUCTS LTD")
        {
            PdfClientName = imp_name;
        }
        else if (imp_name == "LG ELECTRONICS INDIA LTD.")
        {
            PdfClientName = imp_name.Split(' ')[0] + " " + imp_name.Split(' ')[1];
        }
        else
        {
            PdfClientName = imp_name.Split(' ')[0];            
        }

        string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
        byte[] boundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
        byte[] trailer = Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://asia-south1-serene-essence-419307.cloudfunctions.net/royal-invoice");
        request.Headers.Add("ApiKey", "12345");
        request.Method = "POST";
        request.ContentType = "multipart/form-data; boundary=" + boundary;
        request.KeepAlive = true;
        request.AllowWriteStreamBuffering = false;
        request.SendChunked = true;
        request.Timeout = 10 * 60 * 1000;         // 10 minutes
        request.ReadWriteTimeout = 10 * 60 * 1000;

        Stream requestStream = request.GetRequestStream();

        NameValueCollection formFields = new NameValueCollection
       {
        { "CompanyID", Connection.Company_License() },
        { "UserID", Connection.Current_User() },
        { "BranchCode", Connection.Current_Branch() },
        { "JobNo", txtjobPS.Text.Trim() },
        { "JobType", "che-imp" },
        { "WorkingPeriod", Connection.WorkingPeriod() },
        { "PageCount", "0" },
        { "PdfCount", "0" },
        { "JobStatus", "N" },
        { "FileName", "1" },
        { "InvoiceStartTime", DateTime.Now.ToString() },
        { "PdfClientName", PdfClientName }
       };

        // Write form fields
        foreach (string key in formFields)
        {
            requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
            string fieldData = "Content-Disposition: form-data; name=\"" + key + "\"\r\n\r\n" + formFields[key];
            byte[] fieldBytes = Encoding.UTF8.GetBytes(fieldData);
            requestStream.Write(fieldBytes, 0, fieldBytes.Length);
        }

        // Write file content
        requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
        string header = "Content-Disposition: form-data; name=\"File\"; filename=\"" + Path.GetFileName(FilePath) + "\"\r\n" +
                        "Content-Type: application/pdf\r\n\r\n";
        byte[] headerBytes = Encoding.UTF8.GetBytes(header);
        requestStream.Write(headerBytes, 0, headerBytes.Length);

        using (FileStream fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
        {
            byte[] buffer = new byte[4096];
            int bytesRead;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                requestStream.Write(buffer, 0, bytesRead);
            }
        }

        // Write trailer
        requestStream.Write(trailer, 0, trailer.Length);
        requestStream.Close();

        // Get response
        using (WebResponse response = request.GetResponse())
        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
        {
            result = reader.ReadToEnd();
            Console.WriteLine("Response: " + result);
            //return result;
        }
        return result;
    }
    public bool BindgridViewData()
    {
        if (ViewState["ItemDetails"] != null)
        {
            Dt_Item = (DataTable)ViewState["ItemDetails"];
            if (Dt_Item.Rows.Count > 0)
            {
                foreach (GridViewRow row in gv_ItemPDF.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        TextBox txtItemDesc = (TextBox)row.FindControl("txtItemDesc");
                        DropDownList ddl_SchemeCode = (DropDownList)row.FindControl("ddl_SchemeCode");
                        DropDownList ddl_Scheme_NOTN = (DropDownList)row.FindControl("ddl_Scheme_NOTN");
                        DropDownList ddl_Scheme_NOTN_SL = (DropDownList)row.FindControl("ddl_Scheme_NOTN_SL");
                        TextBox txtCTH = (TextBox)row.FindControl("txt_CTH");
                        TextBox txtBasicNoti = (TextBox)row.FindControl("txtBasicNoti");
                        TextBox txtBasicSlno = (TextBox)row.FindControl("txtBasicSlno");
                        TextBox txt_Basic_Rate = (TextBox)row.FindControl("txt_Basic_Rate");
                        TextBox txtinfoMSR = (TextBox)row.FindControl("txtinfoMSR");
                        TextBox txtinfoUQC = (TextBox)row.FindControl("txtinfo_UQC");
                        TextBox txtitemCountyoforgin = (TextBox)row.FindControl("txtitemCountyoforgin");
                        TextBox txtSW_Noti = (TextBox)row.FindControl("txt_SW_Noti");
                        TextBox txtSW_Slno = (TextBox)row.FindControl("txt_SW_Slno");
                        TextBox txtSW_Rate = (TextBox)row.FindControl("txtSW_Rate");
                        TextBox txt_AIDCCessNoti = (TextBox)row.FindControl("txt_AIDCCessNoti");
                        TextBox txt_AIDCCessSlno = (TextBox)row.FindControl("txt_AIDCCessSlno");
                        TextBox txt_AIDCCessRate = (TextBox)row.FindControl("txt_AIDCCessRate");
                        TextBox txt_IGSTNoti = (TextBox)row.FindControl("txt_IGSTNoti");
                        TextBox txt_IGSTSlNo = (TextBox)row.FindControl("txt_IGSTSlNo");
                        TextBox txt_IGSTRate = (TextBox)row.FindControl("txt_IGSTRate");

                        if (txtItemDesc.Text.Trim() != "" && txtCTH.Text.Trim() != "" && txt_AIDCCessNoti.Text.Trim() != "" && txt_AIDCCessSlno.Text.Trim() != ""
                            && txt_AIDCCessRate.Text.Trim() != "" && txt_IGSTNoti.Text.Trim() != "" && txt_IGSTSlNo.Text.Trim() != "" && txt_IGSTRate.Text.Trim() != "")
                        {
                            string itemDesc = txtItemDesc.Text;
                            string schemeCode = ddl_SchemeCode.SelectedValue;
                            string Scheme_NOTN = ddl_Scheme_NOTN.SelectedValue;
                            string Scheme_NOTN_SL = ddl_Scheme_NOTN_SL.SelectedValue;
                            string CTH = txtCTH.Text;
                            string BasicNoti = txtBasicNoti.Text;
                            string BasicSlno = txtBasicSlno.Text;
                            string BasicRate = txt_Basic_Rate.Text;
                            string infoMSR = txtinfoMSR.Text;
                            string infoUQC = txtinfoUQC.Text;
                            string itemCountyoforgin = txtitemCountyoforgin.Text;
                            string SW_Noti = txtSW_Noti.Text;
                            string SW_Slno = txtSW_Slno.Text;
                            string SW_Rate = txtSW_Rate.Text;
                            string AIDCCessNoti = txt_AIDCCessNoti.Text;
                            string AIDCCessSlno = txt_AIDCCessSlno.Text;
                            string AIDCCessRate = txt_AIDCCessRate.Text;
                            string IGSTNoti = txt_IGSTNoti.Text;
                            string IGSTSlNo = txt_IGSTSlNo.Text;
                            string IGSTRate = txt_IGSTRate.Text;

                            if (row.RowIndex < Dt_Item.Rows.Count)
                            {
                                Dt_Item.Rows[row.RowIndex]["ITEM_DESC"] = itemDesc;
                                Dt_Item.Rows[row.RowIndex]["SchemeCode"] = schemeCode;
                                Dt_Item.Rows[row.RowIndex]["Scheme_NOTN"] = Scheme_NOTN;
                                Dt_Item.Rows[row.RowIndex]["Scheme_NOTN_SL"] = Scheme_NOTN_SL;
                                Dt_Item.Rows[row.RowIndex]["HSCode"] = CTH;
                                Dt_Item.Rows[row.RowIndex]["Basic_Noti"] = BasicNoti;
                                Dt_Item.Rows[row.RowIndex]["Basic_Slno"] = BasicSlno;
                                Dt_Item.Rows[row.RowIndex]["Basic_Rate"] = BasicRate;
                                Dt_Item.Rows[row.RowIndex]["info_MSR"] = infoMSR;
                                Dt_Item.Rows[row.RowIndex]["info_UQC"] = infoUQC;
                                Dt_Item.Rows[row.RowIndex]["itemCountyof_orgin"] = itemCountyoforgin;
                                Dt_Item.Rows[row.RowIndex]["SW_Noti"] = SW_Noti;
                                Dt_Item.Rows[row.RowIndex]["SW_Slno"] = SW_Slno;
                                Dt_Item.Rows[row.RowIndex]["SW_Rate"] = SW_Rate;
                                Dt_Item.Rows[row.RowIndex]["AIDC_CessNoti"] = AIDCCessNoti;
                                Dt_Item.Rows[row.RowIndex]["AIDC_CessSlno"] = AIDCCessSlno;
                                Dt_Item.Rows[row.RowIndex]["AIDC_CessRate"] = AIDCCessRate;
                                Dt_Item.Rows[row.RowIndex]["IGST_Noti"] = IGSTNoti;
                                Dt_Item.Rows[row.RowIndex]["IGST_SlNo"] = IGSTSlNo;
                                Dt_Item.Rows[row.RowIndex]["IGST_Rate"] = IGSTRate;
                            }
                        }
                        else
                        {
                            string Mandatory_Fields = "";
                            if (txtItemDesc.Text.Trim() == "")
                            {
                                Mandatory_Fields = "Item Desc";
                            }
                            else if (txtCTH.Text.Trim() == "")
                            {
                                Mandatory_Fields = "CTH";
                            }
                            else if (txt_AIDCCessNoti.Text.Trim() == "")
                            {
                                Mandatory_Fields = "AIDC Notn";
                            }
                            else if (txt_AIDCCessSlno.Text.Trim() == "")
                            {
                                Mandatory_Fields = "AIDC SlNo";
                            }
                            else if (txt_AIDCCessRate.Text.Trim() == "")
                            {
                                Mandatory_Fields = "AIDC Rate";
                            }
                            else if (txt_IGSTNoti.Text.Trim() == "")
                            {
                                Mandatory_Fields = "IGST Notn";
                            }
                            else if (txt_IGSTSlNo.Text.Trim() == "")
                            {
                                Mandatory_Fields = "IGST Sl.No";
                            }
                            else if (txt_IGSTRate.Text.Trim() == "")
                            {
                                Mandatory_Fields = "IGST Rate";
                            }
                            Alert_msg("Please Enter the " + " " + Mandatory_Fields + " Fields..!");
                            IsValid = false;
                            break;
                        }
                    }
                }
                ViewState["ItemDetails"] = Dt_Item;
            }
            else
            {
                Dt_Item = new DataTable();
                ViewState["ItemDetails"] = Dt_Item;
            }
        }
        else
        {
            Dt_Item = new DataTable();
            ViewState["ItemDetails"] = Dt_Item;
        }

        return IsValid;
    }

    protected void btnupload_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtjobPS.Text != "" && txtjobPS.Text != string.Empty)
            {
                string id = "";
                string f = "S";
                hd_PortOfDischarge_Status.Value = Ser_Port_of_orgin(txtPortOfOrigin.Text, hd_TransportMode.Value);
                if (hd_PortOfDischarge_Status.Value == "Yes")
                {
                    BindgridViewData();
                    if (IsValid == true)
                    {
                        i = insert_update(id, f);
                        if (i == 1)
                        {
                            AUTO_JOBNO();
                            lbl_loading.Text = "<span style='color: green; font-weight: bold;'>✅ Job Created Successfully...</span>";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "popupChecklist", "showChecklistPopup();", true);
                        }
                    }
                    else
                    {
                        Alert_msg("Something went Wrong", "btnSave");
                    }
                }
                else
                {
                    Alert_msg("Invalid Port Of Discharge", "btnSave");
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public int insert_update(string jobid, string flag)
    {
        AUTO_JOBNO();
        string ImporterNameBranch = ddl_ImporterName.SelectedItem.Text;
        int index = ImporterNameBranch.IndexOf("--");
        string Branch = ImporterNameBranch.Substring(0, index);
        string Importer = ImporterNameBranch.Substring(index + 2);

        string imp_name = ViewState["imp_name"].ToString().Trim();
        {
            Importer = imp_name;
        }
        //General
        Transact.JOBID = jobid;
        Transact.JOBNO = Session["JOBNO"].ToString();
        Transact.JOBDATE = DateTime.Now.ToString("dd/MM/yyyy");
        Transact.IMPORTER_NAME = Importer;
        Transact.ADDRESS1 = hd_ImporterName.Value;
        Transact.ADDRESS2 = hd_ImporterAdd1.Value;
        Transact.ADDRESS3 = hd_ImporterAdd2.Value;
        Transact.ADDRESS4 = hd_ImporterAdd3.Value;
        Transact.ADDRESS5 = hd_ImporterAdd4.Value;

        Transact.COUNTRY_ORIGIN = txtCountryOfOrigin.Text;
        Transact.PORT_ORIGIN = txtPortOfOrigin.Text;

        Transact.PORT_SHIPMENT = txtPortOfOrigin.Text;
        Transact.COUNTRY_SHIPMENT = txtCountryOfOrigin.Text;
        Transact.CUSTOMS_HOUSE = Session["CUSTOMHOUSE_CODE"].ToString();

        Transact.EXBOND_INBOND_BE_DATE = "01/01/1900";
        Transact.EXBOND_BOND_DATE = "01/01/1900";
        Transact.BE_TYPE = "Warehouse";
        Transact.FILING_STATUS = "Normal";
        Transact.TRANSPORT_MODE = TRANSPORT_MODE;
        Transact.CUSTOMS_HOUSE_NAME = currentbranch;
        Transact.SECTION46 = "N";
        Transact.FIRSTCHECK = "N";
        Transact.GREEN_CHANNEL = "N";
        Transact.KACHHA_BE = "N";
        Transact.SECTION48 = "N";
        Transact.HIGH_SEA_SALE = "N";

        Transact.USER_ID = currentuser;
        Transact.flag = flag;
        Transact.BRANCH_CODE = currentbranch;
        Transact.WORKING_PERIOD = Working_Period;
        Transact.JOBNO_PS = Session["JOBNO_PS"].ToString();

        Transact.JOB_PREFIX = hdprefix.Value.ToString();
        Transact.JOB_SUFFIX = hdsuffix.Value.ToString();
        Transact.PAYMENT_METHOD_CODE = "T";

        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();
        Auto.Ename = "Import_Details_Bind";
        Auto.Enamesearch = Importer;
        Auto.NSearch = Branch;
        ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
        if (ds.Tables[0].Rows.Count > 0)
        {
            Transact.IEC_NO = ds.Tables[0].Rows[0]["IMP_EXP_IECNO"].ToString();
            Transact.BRANCH_NO = ds.Tables[0].Rows[0]["IMP_EXP_BRSLNO"].ToString();
            Transact.COMMERCIAL_DETAILS_STATUS = ds.Tables[0].Rows[0]["M_COMMERCIAL_DETAILS_STATUS"].ToString();
            Transact.COMMERCIAL_TAX_STATENAME = ds.Tables[0].Rows[0]["M_COMMERCIAL_TAX_STATENAME"].ToString();
            Transact.COMMERCIAL_TAX_STATECODE = ds.Tables[0].Rows[0]["M_COMMERCIAL_TAX_STATECODE"].ToString();
            Transact.COMMERCIAL_TAX_TYPE = ds.Tables[0].Rows[0]["M_COMMERCIAL_TAX_TYPE"].ToString();
            Transact.COMMERCIAL_TAX_REGISTRATION_NO = ds.Tables[0].Rows[0]["M_COMMERCIAL_TAX_REGISTRATION_NO"].ToString();
            Transact.IMP_EXP_TYPE = ds.Tables[0].Rows[0]["IMP_EXP_TYPE"].ToString();

            DataSet ds_Imp_Add = new DataSet();
            Auto.Ename = "IMP_EXP_MASTER_IMPORTER_BRANCH_WISE";
            Auto.Enamesearch = Transact.BRANCH_NO;
            Auto.NSearch = Transact.IEC_NO;
            ds_Imp_Add = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds_Imp_Add.Tables[0].Rows.Count > 0)
            {
                Transact.ADDRESS1 = ds_Imp_Add.Tables[0].Rows[0]["IMP_EXP_ADD1"].ToString();
                Transact.ADDRESS2 = ds_Imp_Add.Tables[0].Rows[0]["IMP_EXP_ADD2"].ToString();
                Transact.ADDRESS3 = ds_Imp_Add.Tables[0].Rows[0]["IMP_EXP_ADD3"].ToString();
                Transact.ADDRESS4 = ds_Imp_Add.Tables[0].Rows[0]["IMP_EXP_ADD4"].ToString();
            }
        }

        ds.Clear();
        Auto.Ename = "Get_ADCODE";
        Auto.Enamesearch = Importer;
        Auto.NSearch = Transact.IEC_NO;
        ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
        if (ds.Tables[0].Rows.Count > 0)
        {
            string ADCODE = ds.Tables[0].Rows[0]["IMPORT_ADCODE"].ToString();
            Transact.ADCODE = ADCODE.Trim();
        }

        i = Transact.General_details_insertupdate();

        ds.Clear();
        GetJobId();

        //Invoice
        DataTable dt_INVOICE = new DataTable();
        dt_INVOICE = (DataTable)ViewState["dt_Invoice"];
        if (dt_INVOICE.Rows.Count == 1)
        {
            //Transact.INV_SLNO = "1";
            Transact.INVOICE_NO = txtInvNo.Text.Trim();
            if (txtInvDate.Text.Trim() != "")
            {
                Transact.INVOICE_DATE = Get_Valid_Date(txtInvDate.Text.Trim().Replace(" ", ""));
            }
            else
            {
                Transact.INVOICE_DATE = "01/01/1900";
            }
            Transact.TERMS = ddlTerms.SelectedItem.Text;
            Transact.INVOICE_CURRENCY = Get_Valid_Curr_Name(txtCurrency.Text.ToUpper().Trim());
            string invoiceValue = txtInvValue.Text.Trim();
            string InvoiceValueRemoveComa = invoiceValue.Replace(",", "");
            Transact.INVOICE_VALUE = InvoiceValueRemoveComa;
            if (Importer == "ALFA LAVAL INDIA PRIVATE LIMITED")
            {
                Transact.OTHER_PURCHASE_ORDER = dt_INVOICE.Rows[0]["PurchaseOrderNo"].ToString().Trim();
                string Val_PurchaseOrderDate = dt_INVOICE.Rows[0]["PurchaseOrderDate"].ToString().Trim();
                if (Val_PurchaseOrderDate != null && Val_PurchaseOrderDate != "" && Val_PurchaseOrderDate != string.Empty)
                {
                    Transact.OTHER_PURCHASE_ORDER_DATE = Get_Valid_Date(Val_PurchaseOrderDate.ToString().Trim());
                }
                else
                {
                    Transact.OTHER_PURCHASE_ORDER_DATE = "01/01/1900";
                }
            }
            else
            {
                Transact.OTHER_PURCHASE_ORDER = "";
                Transact.OTHER_PURCHASE_ORDER_DATE = "01/01/1900";
            }

            InsertInvoiceDetails();
        }
        else
        {
            for (int h = 0; h <= dt_INVOICE.Rows.Count - 1; h++)
            {
                Transact.INVOICE_NO = dt_INVOICE.Rows[h]["InvoiceNo"].ToString();
                Transact.INVOICE_DATE = Get_Valid_Date(dt_INVOICE.Rows[h]["InvoiceDate"].ToString().Trim());
                Transact.INVOICE_CURRENCY = Get_Valid_Curr_Name(dt_INVOICE.Rows[h]["Currency"].ToString().Trim());
                Transact.TERMS = dt_INVOICE.Rows[h]["Terms"].ToString().Trim();
                Transact.INVOICE_VALUE = dt_INVOICE.Rows[h]["InvoiceValue"].ToString().Trim().Replace(",", "");
                if (Importer == "ALFA LAVAL INDIA PRIVATE LIMITED")
                {
                    Transact.OTHER_PURCHASE_ORDER = dt_INVOICE.Rows[h]["PurchaseOrderNo"].ToString().Trim();
                    string Val_PurchaseOrderDate = dt_INVOICE.Rows[h]["PurchaseOrderDate"].ToString().Trim();
                    if (Val_PurchaseOrderDate != null && Val_PurchaseOrderDate != "" && Val_PurchaseOrderDate != string.Empty)
                    {
                        Transact.OTHER_PURCHASE_ORDER_DATE = Get_Valid_Date(Val_PurchaseOrderDate.ToString().Trim());
                    }
                    else
                    {
                        Transact.OTHER_PURCHASE_ORDER_DATE = "01/01/1900";
                    }
                }
                else
                {
                    Transact.OTHER_PURCHASE_ORDER = "";
                    Transact.OTHER_PURCHASE_ORDER_DATE = "01/01/1900";
                }

                InsertInvoiceDetails();
            }
        }

        i = Transact.result;

        //Product
        DataTable dtItem = (ViewState["ItemDetails"]) as DataTable;
        string SELECT_BRANCH = Connection.Get_Company_Type();
        string GetPartNo = "", GetPoNo = "", GetNetWeight = "";
        if (dtItem.Rows.Count > 0)
        {
            for (int j = 0; j <= dtItem.Rows.Count - 1; j++)
            {
                Transact.INV_SLNO = dtItem.Rows[j]["InvoiceSlNo"].ToString();
                string ITEM_DESCRIPTION = dtItem.Rows[j]["ITEM_DESC"].ToString();
                Transact.ITEM_QTY = dtItem.Rows[j]["Quantity"].ToString();
                Transact.ITEM_QTY_CODE = dtItem.Rows[j]["QtyCode"].ToString();

                string MaterialRate = dtItem.Rows[j]["Rate"].ToString();
                string MaterialRateRemoveCama = MaterialRate.Replace(",", "");
                Transact.ITEM_UNIT_PRICE = MaterialRateRemoveCama;
                Transact.ITEM_UNIT_CODE = txtCurrency.Text.ToUpper().Trim();

                string MaterialAmount = dtItem.Rows[j]["Amount"].ToString();
                string MaterialAmountRemoveCama = MaterialAmount.Replace(",", "");
                Transact.ITEM_TOTAL_AMOUNT = MaterialAmountRemoveCama;
                GetPartNo = dtItem.Rows[j]["PartNo"].ToString();

                Transact.ITEM_AMOUNT_CODE = txtCurrency.Text.ToUpper().Trim();
                Transact.PREVIOUS_BE_DATE = "01/01/1900";
                Transact.flag = "S";
                Transact.YEAR = "";
                Transact.USER_ID = currentuser;
                Transact.BRANCH_CODE = currentbranch;
                Transact.WORKING_PERIOD = Working_Period;
                Transact.JOBNO = Session["JOBNO"].ToString();
                Transact.BRANCH_COMMON = SELECT_BRANCH;

                eroyalmaster erm = new eroyalmaster();
                erm.IMPORTER_NAME = Importer;
                erm.IEC_NO = Transact.IEC_NO;
                erm.ADCODE = Transact.ADCODE;
                erm.BRANCH_NO = Transact.BRANCH_NO;
                erm.PARTNO = GetPartNo;
                erm.Eproduct_imp_description = ITEM_DESCRIPTION;
                erm.Ename = "Select_Common_Whole_Data";
                DataSet dsGetPDFData = erm.RetrieveAll_Product_import_PDF_MASTER();

                //Masters

                if (dsGetPDFData.Tables[0].Rows.Count > 0)
                {
                    string POTYPE = dsGetPDFData.Tables[0].Rows[0]["PO_TYPE"].ToString();
                    Transact.ITEM_DESCRIPTION = ITEM_DESCRIPTION;
                    string PRODUCT_RITC = dtItem.Rows[j]["HSCode"].ToString();
                    Transact.Info_Uqc = dtItem.Rows[j]["info_UQC"].ToString();
                    Transact.Info_Msr = dtItem.Rows[j]["info_MSR"].ToString();

                    // GENERAL  //
                    Transact.CTH_NO = dtItem.Rows[j]["HSCode"].ToString();
                    Transact.GENEARL_DESCRIPTION = ITEM_DESCRIPTION;
                    Transact.MANUFACTURER = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_MANUFACTURER"].ToString();
                    Transact.BRAND = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_BRAND"].ToString();
                    Transact.MODEL = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_MODEL"].ToString();
                    Transact.END_USE_OF_ITEM = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_END_USE"].ToString();
                    string Item_COUNTRY_OF_ORIGIN = dtItem.Rows[j]["itemCountyof_orgin"].ToString();
                    if (Item_COUNTRY_OF_ORIGIN != "" && Item_COUNTRY_OF_ORIGIN != string.Empty)
                    {
                        Transact.COUNTRY_OF_ORIGIN = Item_COUNTRY_OF_ORIGIN.Split('-')[0];
                    }
                    else
                    {
                        Transact.COUNTRY_OF_ORIGIN = "";
                    }
                    Transact.ACCESSORIES = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_ACCESSORIES"].ToString();
                    // CTH  //
                    Transact.SCHEME_CODE = dtItem.Rows[j]["SchemeCode"].ToString();
                    Transact.SCHEME_NOTN = dtItem.Rows[j]["Scheme_NOTN"].ToString();
                    Transact.SCHEME_NOTN_SLNO = dtItem.Rows[j]["Scheme_NOTN_SL"].ToString();
                    Transact.PRODUCT_RITC = dtItem.Rows[j]["HSCode"].ToString();
                    Transact.PRODUCT_CTH = dtItem.Rows[j]["HSCode"].ToString();

                    string FTA_YES_NO = dsGetPDFData.Tables[0].Rows[0]["FTA_YES_NO"].ToString();
                    if (FTA_YES_NO == "NO")
                    {
                        Transact.PRODUCT_BCD_SLNO = "";
                        Transact.PRODUCT_BCD_NOTN = "";
                    }
                    else
                    {
                        Transact.PRODUCT_BCD_NOTN = dtItem.Rows[j]["Basic_Noti"].ToString();
                        Transact.PRODUCT_BCD_SLNO = dtItem.Rows[j]["Basic_Slno"].ToString();
                    }

                    Transact.PRODUCT_BCD_RATE = dtItem.Rows[j]["Basic_Rate"].ToString();
                    Transact.PRODUCT_BCD_SPL = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_BCD_SPL"].ToString();
                    Transact.PRODUCT_BCD_UNIT = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_BCD_UNIT"].ToString();
                    Transact.PRODUCT_BCD_SPL_TYPE = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_BCD_SPL_TYPE"].ToString();
                    Transact.PRODUCT_ADDL_DUTY_NOTN = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_ADDL_DUTY_NOTN"].ToString();
                    Transact.PRODUCT_ADDL_DUTY_NOTN_SL = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_ADDL_DUTY_NOTN_SL"].ToString();
                    Transact.PRODUCT_ADDL_DUTY_RATE = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_ADDL_DUTY_RATE"].ToString();
                    Transact.PRODUCT_EDU_CESS_NOTN = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_EDU_CESS_NOTN"].ToString();
                    Transact.PRODUCT_EDU_CESS_NOTN_SL = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_EDU_CESS_NOTN_SL"].ToString();
                    Transact.PRODUCT_EDU_CESS_RATE = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_EDU_CESS_RATE"].ToString();
                    Transact.PRODUCT_SEC_EDU_CESS_NOTN = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_SEC_EDU_CESS_NOTN"].ToString();
                    Transact.PRODUCT_SEC_EDU_CESS_NOTN_SL = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_SEC_EDU_CESS_NOTN_SL"].ToString();
                    Transact.PRODUCT_SEC_EDU_CESS_RATE = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_SEC_EDU_CESS_RATE"].ToString();
                    Transact.SOCIAL_WELFARE_NOTN = dtItem.Rows[j]["SW_Noti"].ToString();
                    Transact.SOCIAL_WELFARE_NOTN_SLNO = dtItem.Rows[j]["SW_Slno"].ToString();
                    Transact.SOCIAL_WELFARE_RATE = dtItem.Rows[j]["SW_Rate"].ToString();
                    Transact.PRODUCT_NCD_NOTN = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_NCD_NOTN"].ToString();
                    Transact.PRODUCT_NCD_SLNO = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_NCD_SLNO"].ToString();
                    Transact.PRODUCT_NCD_RATE = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_NCD_RATE"].ToString();
                    Transact.PRODUCT_NCD_SPL = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_NCD_SPL"].ToString();
                    Transact.PRODUCT_NCD_UNIT = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_NCD_UNIT"].ToString();
                    Transact.PRODUCT_NCD_SPL_TYPE = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_NCD_SPL_TYPE"].ToString();
                    Transact.PRODUCT_AGGREGATE_DUTY_NOTN = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_AGGREGATE_DUTY_NOTN"].ToString();
                    Transact.PRODUCT_AGGREGATE_DUTY_NOTN_SL = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_AGGREGATE_DUTY_NOTN_SL"].ToString();
                    Transact.PRODUCT_AGGREGATE_DUTY_NOTN_RATE = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_AGGREGATE_DUTY_NOTN_RATE"].ToString();
                    Transact.PRODUCT_SAFEGUARD_NOTN = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_SAFEGUARD_NOTN"].ToString();
                    Transact.PRODUCT_SAFEGUARD_SLNO = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_SAFEGUARD_SLNO"].ToString();
                    Transact.PRODUCT_SAFEGUARD_RATE = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_SAFEGUARD_RATE"].ToString();
                    Transact.PRODUCT_SAFEGUARD_SPL = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_SAFEGUARD_SPL"].ToString();
                    Transact.PRODUCT_SAFEGUARD_UNIT = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_SAFEGUARD_UNIT"].ToString();
                    Transact.PRODUCT_SAFEGUARD_SPL_TYPE = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_SAFEGUARD_SPL_TYPE"].ToString();
                    Transact.PRODUCT_SAPTA_NOTN = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_SAPTA_NOTN"].ToString();
                    Transact.PRODUCT_SAPTA_SLNO = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_SAPTA_SLNO"].ToString();
                    Transact.PRODUCT_SAPTA_RATE = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_SAPTA_RATE"].ToString();
                    Transact.PRODUCT_TARIFF_NOTN = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_TARIFF_NOTN"].ToString();
                    Transact.PRODUCT_TARIFF_SLNO = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_TARIFF_SLNO"].ToString();
                    Transact.PRODUCT_TARIFF_QTY = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_TARIFF_QTY"].ToString();
                    Transact.PRODUCT_TARIFF_AMOUNT = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_TARIFF_AMOUNT"].ToString();
                    Transact.PRODUCT_TARIFF_AMOUNT_UNIT = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_TARIFF_AMOUNT_UNIT"].ToString();
                    Transact.AIDC_NOTN = dtItem.Rows[j]["AIDC_CessNoti"].ToString();
                    Transact.AIDC_NOTN_SLNO = dtItem.Rows[j]["AIDC_CessSlno"].ToString();
                    Transact.AIDC_RATE = dtItem.Rows[j]["AIDC_CessRate"].ToString();

                    // CETH //
                    Transact.PRODUCT_CETH = dtItem.Rows[j]["HSCode"].ToString();
                    Transact.PRODUCT_ADDL5_SIA_NOTN = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_ADDL5_SIA_NOTN"].ToString();
                    Transact.PRODUCT_ADDL5_SIA_NOTN_SL = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_ADDL5_SIA_NOTN_SL"].ToString();
                    Transact.PRODUCT_ADDL5_SIA_RATE = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_ADDL5_SIA_RATE"].ToString();
                    Transact.PRODUCT_ADDL_GSI_NOTN = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_ADDL_GSI_NOTN"].ToString();
                    Transact.PRODUCT_ADDL_GSI_SLNO = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_ADDL_GSI_SLNO"].ToString();
                    Transact.PRODUCT_ADDL_GSI_RATE = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_ADDL_GSI_RATE"].ToString();
                    Transact.PRODUCT_ADDL_GSI_SPL = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_ADDL_GSI_SPL"].ToString();
                    Transact.PRODUCT_ADDL_GSI_UNIT = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_ADDL_GSI_UNIT"].ToString();
                    Transact.PRODUCT_ADDL_GSI_SPL_TYPE = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_ADDL_GSI_SPL_TYPE"].ToString();
                    Transact.PRODUCT_ADDL_SHEII_NOTN = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_ADDL_SHEII_NOTN"].ToString();
                    Transact.PRODUCT_ADDL_SHEII_SLNO = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_ADDL_SHEII_SLNO"].ToString();
                    Transact.PRODUCT_ADDL_SHEII_RATE = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_ADDL_SHEII_RATE"].ToString();
                    Transact.PRODUCT_ADDL_SHEII_SPL = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_ADDL_SHEII_SPL"].ToString();
                    Transact.PRODUCT_ADDL_SHEII_UNIT = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_ADDL_SHEII_UNIT"].ToString();
                    Transact.PRODUCT_ADDL_SHEII_TYPE = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_ADDL_SHEII_TYPE"].ToString();
                    Transact.PRODUCT_ADDL_TTA_NOTN = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_ADDL_TTA_NOTN"].ToString();
                    Transact.PRODUCT_ADDL_TTA_SLNO = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_ADDL_TTA_SLNO"].ToString();
                    Transact.PRODUCT_ADDL_TTA_RATE = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_ADDL_TTA_RATE"].ToString();
                    Transact.PRODUCT_ADDL_TTA_SPL = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_ADDL_TTA_SPL"].ToString();
                    Transact.PRODUCT_ADDL_TTA_UNIT = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_ADDL_TTA_UNIT"].ToString();
                    Transact.PRODUCT_ADDL_TTA_TYPE = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_ADDL_TTA_TYPE"].ToString();
                    Transact.PRODUCT_ADDL_HEALTH_CESS_NOTN = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_NOTN"].ToString();
                    Transact.PRODUCT_ADDL_HEALTH_CESS_SLNO = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_SLNO"].ToString();
                    Transact.PRODUCT_ADDL_HEALTH_CESS_RATE = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_RATE"].ToString();
                    Transact.PRODUCT_ADDL_HEALTH_CESS_SPL = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_SPL"].ToString();
                    Transact.PRODUCT_ADDL_HEALTH_CESS_UNIT = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_UNIT"].ToString();
                    Transact.PRODUCT_ADDL_HEALTH_CESS_TYPE = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_TYPE"].ToString();
                    Transact.PRODUCT_CESS_NOTN = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_CESS_NOTN"].ToString();
                    Transact.PRODUCT_CESS_SLNO = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_CESS_SLNO"].ToString();
                    Transact.PRODUCT_CESS_RATE = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_CESS_RATE"].ToString();
                    Transact.PRODUCT_CESS_SPL = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_CESS_SPL"].ToString();
                    Transact.PRODUCT_CESS_UNIT = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_CESS_UNIT"].ToString();
                    Transact.PRODUCT_CESS_TYPE = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_CESS_TYPE"].ToString();
                    Transact.PRODUCT_OTHER_DUTY_NOTN = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_OTHER_DUTY_NOTN"].ToString();
                    Transact.PRODUCT_OTHER_DUTY_SLNO = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_OTHER_DUTY_SLNO"].ToString();
                    Transact.PRODUCT_OTHER_DUTY_RATE = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_OTHER_DUTY_RATE"].ToString();
                    Transact.PRODUCT_OTHER_DUTY_SPL = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_OTHER_DUTY_SPL"].ToString();
                    Transact.PRODUCT_OTHER_DUTY_UNIT = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_OTHER_DUTY_UNIT"].ToString();
                    Transact.PRODUCT_OTHER_DUTY_TYPE = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_OTHER_DUTY_TYPE"].ToString();
                    Transact.INFRA_CESS_NOTN = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_CTH_INFRA_CESS_NOTN"].ToString();
                    Transact.INFRA_CESS_NOTN_SL = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_CTH_INFRA_CESS_NOTN_SLNO"].ToString();
                    Transact.INFRA_CESS_NOTN_RATE = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_CTH_INFRA_CESS_RATE"].ToString();

                    // IGST //
                    Transact.IGST_LEVY_NOTN = dtItem.Rows[j]["IGST_Noti"].ToString();
                    Transact.IGST_LEVY_SLNO = dtItem.Rows[j]["IGST_SlNo"].ToString();
                    Transact.IGST_LEVY_RATE = dtItem.Rows[j]["IGST_Rate"].ToString();
                    Transact.IGST_LEVY_SPL = dsGetPDFData.Tables[0].Rows[0]["IGST_LEVY_SPL"].ToString();
                    Transact.IGST_LEVY_UNIT = dsGetPDFData.Tables[0].Rows[0]["IGST_LEVY_UNIT"].ToString();
                    Transact.IGST_LEVY_SPL_TYPE = dsGetPDFData.Tables[0].Rows[0]["IGST_LEVY_SPL_TYPE"].ToString();
                    Transact.IGST_LEVY_EXCEPTION_NOTN = dsGetPDFData.Tables[0].Rows[0]["IGST_LEVY_EXCEPTION_NOTN"].ToString();
                    Transact.IGST_LEVY_EXCEPTION_SLNO = dsGetPDFData.Tables[0].Rows[0]["IGST_LEVY_EXCEPTION_SLNO"].ToString();
                    Transact.IGST_LEVY_EXCEPTION_RATE = dsGetPDFData.Tables[0].Rows[0]["IGST_LEVY_EXCEPTION_RATE"].ToString();
                    Transact.IGST_LEVY_COMPENSATION_CESS_NOTN = dtItem.Rows[j]["IGST_LEVY_COMPENSATION_CESS_NOTN"].ToString();
                    Transact.IGST_LEVY_COMPENSATION_CESS_SLNO = dtItem.Rows[j]["IGST_LEVY_COMPENSATION_CESS_SLNO"].ToString();
                    Transact.IGST_LEVY_COMPENSATION_CESS_RATE = dtItem.Rows[j]["IGST_LEVY_COMPENSATION_CESS_RATE"].ToString();
                    Transact.IGST_LEVY_COMPENSATION_CESS_SPL = dsGetPDFData.Tables[0].Rows[0]["IGST_LEVY_COMPENSATION_CESS_SPL"].ToString();
                    Transact.IGST_LEVY_COMPENSATION_CESS_UNIT = dsGetPDFData.Tables[0].Rows[0]["IGST_LEVY_COMPENSATION_CESS_UNIT"].ToString();
                    Transact.IGST_LEVY_COMPENSATION_CESS_SPL_TYPE = dsGetPDFData.Tables[0].Rows[0]["IGST_LEVY_COMPENSATION_CESS_SPL_TYPE"].ToString();
                    Transact.IGST_LEVY_EXCEPTION_CC_NOTN = dsGetPDFData.Tables[0].Rows[0]["IGST_LEVY_EXCEPTION_CC_NOTN"].ToString();
                    Transact.IGST_LEVY_EXCEPTION_CC_SLNO = dsGetPDFData.Tables[0].Rows[0]["IGST_LEVY_EXCEPTION_CC_SLNO"].ToString();
                    Transact.IGST_LEVY_EXCEPTION_CC_RATE = dsGetPDFData.Tables[0].Rows[0]["IGST_LEVY_EXCEPTION_CC_RATE"].ToString();
                    Transact.LEVY_EXCEMPTION_NOTN_TYPE = dsGetPDFData.Tables[0].Rows[0]["LEVY_EXCEMPTION_NOTN_TYPE"].ToString();
                    Transact.LEVY_EXCEPTION_CC_NOTN_TYPE = dsGetPDFData.Tables[0].Rows[0]["LEVY_EXCEPTION_CC_NOTN_TYPE"].ToString();

                    // OTHER DUTY //

                    Transact.ANTI_DUMPING_NOTN = dsGetPDFData.Tables[0].Rows[0]["ANTI_DUMPING_NOTN"].ToString();
                    Transact.ANTI_DUMPING_NOTN_SLNO = dsGetPDFData.Tables[0].Rows[0]["ANTI_DUMPING_NOTN_SLNO"].ToString();
                    Transact.CTH_SLNO = dsGetPDFData.Tables[0].Rows[0]["CTH_SLNO"].ToString();
                    Transact.CTH_SUPPLIER_SLNO = dsGetPDFData.Tables[0].Rows[0]["CTH_SUPPLIER_SLNO"].ToString();
                    Transact.CTH_QTY = dsGetPDFData.Tables[0].Rows[0]["CTH_QTY"].ToString();
                    Transact.CENTRAL_EXCISE_FALG = dsGetPDFData.Tables[0].Rows[0]["CENTRAL_EXCISE_FLAG"].ToString();
                    Transact.MANUFACTURER_PRODUCER = dsGetPDFData.Tables[0].Rows[0]["MANUFACTURER_PRODUCER"].ToString();
                    Transact.M_P_GROWER_CODE = dsGetPDFData.Tables[0].Rows[0]["M_P_GROWER_CODE"].ToString();
                    Transact.M_P_GROWER_ADD1 = dsGetPDFData.Tables[0].Rows[0]["M_P_GROWER_ADD1"].ToString();
                    Transact.M_P_GROWER_ADD2 = dsGetPDFData.Tables[0].Rows[0]["M_P_GROWER_ADD2"].ToString();
                    Transact.M_P_GROWER_CITY = dsGetPDFData.Tables[0].Rows[0]["M_P_GROWER_CITY"].ToString();
                    Transact.M_P_GROWER_COUNTRY_SUBDIV = dsGetPDFData.Tables[0].Rows[0]["M_P_GROWER_COUNTRY_SUBDIV"].ToString();
                    Transact.M_P_GROWER_PIN = dsGetPDFData.Tables[0].Rows[0]["M_P_GROWER_PIN"].ToString();
                    Transact.M_P_GROWER_COUNTRY = dsGetPDFData.Tables[0].Rows[0]["M_P_GROWER_COUNTRY"].ToString();
                    Transact.SOURCE_COUNTRY = dsGetPDFData.Tables[0].Rows[0]["SOURCE_COUNTRY"].ToString();
                    Transact.TRANSIT_COUNTRY = dsGetPDFData.Tables[0].Rows[0]["TRANSIT_COUNTRY"].ToString();
                    Transact.ACCESSORY_STATUS = dsGetPDFData.Tables[0].Rows[0]["ACCESSORY_STATUS"].ToString();

                    // ***END*** //                    
                }
                else
                {
                    Transact.ITEM_DESCRIPTION = ITEM_DESCRIPTION.Replace("СЕ", "CE");
                    Transact.GENEARL_DESCRIPTION = ITEM_DESCRIPTION.Replace("СЕ", "CE");
                    Transact.Info_Uqc = dtItem.Rows[j]["info_UQC"].ToString();
                    Transact.Info_Msr = dtItem.Rows[j]["info_MSR"].ToString();
                    Transact.CTH_NO = dtItem.Rows[j]["HSCode"].ToString();
                    Transact.MANUFACTURER = txtSupplier.Text.Trim();
                    Transact.BRAND = "NA";
                    Transact.MODEL = "NA";
                    Transact.END_USE_OF_ITEM = "";                        
                    string Item_COUNTRY_OF_ORIGIN = dtItem.Rows[j]["itemCountyof_orgin"].ToString();
                    if (Item_COUNTRY_OF_ORIGIN != "" && Item_COUNTRY_OF_ORIGIN != string.Empty)
                    {
                        Transact.COUNTRY_OF_ORIGIN = Item_COUNTRY_OF_ORIGIN.Split('-')[0];
                    }
                    else
                    {
                        Transact.COUNTRY_OF_ORIGIN = "";
                    }
                    Transact.SCHEME_CODE = dtItem.Rows[j]["SchemeCode"].ToString();
                    Transact.SCHEME_NOTN = dtItem.Rows[j]["Scheme_NOTN"].ToString();
                    Transact.SCHEME_NOTN_SLNO = dtItem.Rows[j]["Scheme_NOTN_SL"].ToString();
                    Transact.PRODUCT_RITC = dtItem.Rows[j]["HSCode"].ToString();
                    Transact.PRODUCT_CTH = dtItem.Rows[j]["HSCode"].ToString();
                    Transact.PRODUCT_BCD_NOTN = dtItem.Rows[j]["Basic_Noti"].ToString();
                    Transact.PRODUCT_BCD_SLNO = dtItem.Rows[j]["Basic_Slno"].ToString();
                    Transact.PRODUCT_BCD_RATE = dtItem.Rows[j]["Basic_Rate"].ToString();
                    Transact.SOCIAL_WELFARE_NOTN = dtItem.Rows[j]["SW_Noti"].ToString();
                    Transact.SOCIAL_WELFARE_NOTN_SLNO = dtItem.Rows[j]["SW_Slno"].ToString();
                    Transact.SOCIAL_WELFARE_RATE = dtItem.Rows[j]["SW_Rate"].ToString();
                    Transact.AIDC_NOTN = dtItem.Rows[j]["AIDC_CessNoti"].ToString();
                    Transact.AIDC_NOTN_SLNO = dtItem.Rows[j]["AIDC_CessSlno"].ToString();
                    Transact.AIDC_RATE = dtItem.Rows[j]["AIDC_CessRate"].ToString();
                    Transact.PRODUCT_CETH = dtItem.Rows[j]["HSCode"].ToString();
                    Transact.IGST_LEVY_NOTN = dtItem.Rows[j]["IGST_Noti"].ToString();
                    Transact.IGST_LEVY_SLNO = dtItem.Rows[j]["IGST_SlNo"].ToString();
                    Transact.IGST_LEVY_RATE = dtItem.Rows[j]["IGST_Rate"].ToString();
                    if (Transact.IGST_LEVY_NOTN != "")
                    {
                        Transact.IGST_LEVY_COMPENSATION_CESS_NOTN = "001/2017";
                        Transact.IGST_LEVY_COMPENSATION_CESS_SLNO = "56";
                        Transact.IGST_LEVY_COMPENSATION_CESS_RATE = "0.00";
                    }
                }
                DataSet dss = Transact.Item_Details_insertupdate();
            }
        }

        //IGM Details
        if (COMPANY_IDD == "341" || COMPANY_IDD == "1" || COMPANY_IDD == "10")
        {
            DataTable dt_IGMDetails = (ViewState["dt_IGMDetails"]) as DataTable;
            if (dt_IGMDetails.Rows.Count > 0)
            {
                for (int aj = 0; aj <= dt_IGMDetails.Rows.Count - 1; aj++)
                {
                    Transact.IGM_MAWB_MBL = dt_IGMDetails.Rows[aj]["IGM_MAWB_MBL"].ToString().Replace(" ","");
                    Transact.IGM_MAWB_MBLDATE = string.IsNullOrEmpty(dt_IGMDetails.Rows[aj]["IGM_MAWB_MBLDATE"].ToString()) ? "01/01/1900" : dt_IGMDetails.Rows[aj]["IGM_MAWB_MBLDATE"].ToString();
                    Transact.IGM_HAWB_HBLNO = dt_IGMDetails.Rows[aj]["IGM_HAWB_HBLNO"].ToString().Replace(" ","");
                    Transact.IGM_HAWB_HBLDATE = string.IsNullOrEmpty(dt_IGMDetails.Rows[aj]["IGM_HAWB_HBLDATE"].ToString()) ? "01/01/1900" : dt_IGMDetails.Rows[aj]["IGM_HAWB_HBLDATE"].ToString();
                    Transact.IGM_NOOFPACKAGE = dt_IGMDetails.Rows[aj]["IGM_NOOFPACKAGE"].ToString();
                    Transact.IGM_GROSSWEIGHT = dt_IGMDetails.Rows[aj]["IGM_GROSSWEIGHT"].ToString();
                    Transact.IGM_JOBDATE = "01/01/1900";
                    Transact.IGM_FLIGHT_VESSELDATE = "01/01/1900";
                    Transact.IGM_DATE = "01/01/1900";
                    Transact.IGM_GATEWAY_IGM_DATE = "01/01/1900";
                    Transact.USER_ID = currentuser;
                    Transact.flag = flag;
                    Transact.BRANCH_CODE = currentbranch;
                    Transact.WORKING_PERIOD = Working_Period;
                    Transact.JOBNO_PS = Session["JOBNO_PS"].ToString();
                    Transact.IGM_JOBNO = Session["JOBNO"].ToString();
                    Transact.IGM_TRANSPORTMODE = TRANSPORT_MODE;
                    Transact.IGM_PACKAGETYPE = "PKG";
                    Transact.IGM_TYPEOFWEIGHT = "KGS";
                    DataSet dss_IGM = Transact.IGM_Details_insertupdate();
                }
            }

            DataTable dt_ContainerDetails = (ViewState["dt_ContainerDetails"]) as DataTable;
            if (dt_ContainerDetails.Rows.Count > 0)
            {
                for (int kav = 0; kav <= dt_ContainerDetails.Rows.Count - 1; kav++)
                {
                    Transact.CONTAINER_NO = dt_ContainerDetails.Rows[kav]["CONTAINER_NO"].ToString().Replace(" ", "");
                    Transact.SEAL_NO = dt_ContainerDetails.Rows[kav]["SEAL_NO"].ToString();
                    Transact.TYPE = dt_ContainerDetails.Rows[kav]["TYPE"].ToString();
                    Transact.CONTAINER_IGM_DATE = "01/01/1900";
                    Transact.USER_ID = currentuser;
                    Transact.flag = flag;
                    Transact.BRANCH_CODE = currentbranch;
                    Transact.WORKING_PERIOD = Working_Period;
                    Transact.JOBNO_PS = Session["JOBNO_PS"].ToString();
                    Transact.IGM_JOBNO = Session["JOBNO"].ToString();
                    Transact.CONTAINER_IGM_SLNO = "1";
                    Transact.FCL_OR_LCL = "F";
                    Transact.TRUCK_NO = "NA";
                    DataSet dss_Con = Transact.CONTAINER_Details_insertupdate();
                }
            }

            DataTable dt_BondDetails = (ViewState["dt_BondDetails"]) as DataTable;
            if (dt_BondDetails.Rows.Count > 0)
            {
                for (int IGM_Bond = 0; IGM_Bond <= dt_BondDetails.Rows.Count - 1; IGM_Bond++)
                {
                    Transact.BOND_NO = dt_BondDetails.Rows[IGM_Bond]["BOND_NO"].ToString().Replace(" ", "");
                    Transact.BOND_TYPE = dt_BondDetails.Rows[IGM_Bond]["BOND_TYPE"].ToString();
                    Transact.BOND_LOCATION = dt_BondDetails.Rows[IGM_Bond]["BOND_LOCATION"].ToString();
                    Transact.USER_ID = currentuser;
                    Transact.flag = flag;
                    Transact.BRANCH_CODE = currentbranch;
                    Transact.WORKING_PERIOD = Working_Period;
                    Transact.JOBNO = Session["JOBNO"].ToString();
                    DataSet dss_Bon = Transact.BOND_Details_insertupdate();
                }
            }
        }

        con.Open();
        SqlCommand PScmd =
            new SqlCommand(
                "select * from PDF_AI_COUNT_DETAILS where PDF_JOB_NO = '" + txtjobPS.Text + "' and PDF_EXP_IMP_NAME='" + Importer.Trim() + "' and PDF_BRANCH_CODE ='" + currentbranch + "'", con);
        SqlDataAdapter Psda = new SqlDataAdapter(PScmd);
        DataSet PSds = new DataSet();
        Psda.Fill(PSds);
        con.Close();
        con.Open();
        if (PSds.Tables[0].Rows.Count > 0)
        {
            string PDF_ID = PSds.Tables[0].Rows[0]["PDF_ID"].ToString();
            string PDF_SAVE_COUNT = PSds.Tables[0].Rows[0]["PDF_SAVE_COUNT"].ToString();
            SqlCommand PUcmd =
              new SqlCommand(
                  "Update PDF_AI_COUNT_DETAILS set PDF_SAVE_COUNT=('" + PDF_SAVE_COUNT + "'+1),PDF_USER_ID='" + currentuser + "',PDF_DATE_TIME=GetDate()," +
            "PDF_STATUS='S',PDF_BRANCH_CODE='" + currentbranch + "',PDF_WORKING_PERIOD='" + Working_Period + "' where PDF_ID=" + PDF_ID + "", con);
            int result = PUcmd.ExecuteNonQuery();
            con.Close();
        }

        return i;
    }

    public void InsertInvoiceDetails()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        Transact.MIS_CURRENCY = txtCurrency.Text.ToUpper().Trim();
        Transact.MIS_AGENCY_CURRENCY = txtCurrency.Text.ToUpper().Trim();
        Transact.MIS_DISCOUNT_CURRENCY = txtCurrency.Text.ToUpper().Trim();
        Transact.MIS_FREIGHT_CURRENCY = txtCurrency.Text.ToUpper().Trim();
        Transact.MIS_INSURANCE_CURRENCY = txtCurrency.Text.ToUpper().Trim();

        Auto.Ename = "EXCHANGE_MASTER_RATE_EXPORTWISE";
        Auto.Enamesearch = txtCurrency.Text.ToUpper().Trim();
        ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
        if (ds.Tables[0].Rows.Count > 0)
        {
            string INVOICE_EXRATE = ds.Tables[0].Rows[0]["EXCHANGE_RATE_EXPORT"].ToString();
            Transact.INVOICE_EXRATE = INVOICE_EXRATE;
            Transact.MIS_EXRATE = INVOICE_EXRATE;
            Transact.MIS_AGENCY_EXRATE = INVOICE_EXRATE;
            Transact.MIS_DISCOUNT_EXRATE = INVOICE_EXRATE;
            Transact.MIS_FREIGHT_EXRATE = INVOICE_EXRATE;
            Transact.MIS_INSURANCE_EXRATE = INVOICE_EXRATE;

           //CHARGES
            if (COMPANY_IDD == "3198")
            {
                Transact.MIS_FREIGHT_CHARGES = string.IsNullOrEmpty(hd_Freight.Value) ? "" : hd_Freight.Value.Replace(",", "");
                Transact.MIS_INSURANCE_CHARGES = string.IsNullOrEmpty(hd_Insurance.Value) ? "" : hd_Insurance.Value.Replace(",", "");
                Transact.MIS_CHARGES = string.IsNullOrEmpty(hd_MiscCharge.Value) ? "" : hd_MiscCharge.Value.Replace(",", "");
            }
            else
            {

                if (ddlTerms.SelectedItem.Text == "FOB")
                {
                    Transact.MIS_FREIGHT_RATE = "20.0000";
                    Transact.MIS_INSURANCE_RATE = "1.1250";
                }
                else if (ddlTerms.SelectedItem.Text == "CI")
                {
                    Transact.MIS_FREIGHT_RATE = "20.0000";
                }
                else if (ddlTerms.SelectedItem.Text == "CF")
                {
                    Transact.MIS_INSURANCE_RATE = "1.1250";
                }
            }
        }

        Transact.SUPPLIER_NAME = txtSupplier.Text.Trim();
        Auto.Ename = "SUPPLIER_MASTER_SEARCH";
        Auto.Enamesearch = txtSupplier.Text.Trim();
        ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
        if (ds.Tables[0].Rows.Count > 0)
        {
            Transact.SUPPLIER_ADDRESS = ds.Tables[0].Rows[0]["SUP_ADD1"].ToString();
            Transact.SUPPLIER_ADDRESS1 = ds.Tables[0].Rows[0]["SUP_ADD2"].ToString();
            Transact.SUPPLIER_ADDRESS2 = ds.Tables[0].Rows[0]["SUP_ADD3"].ToString();
            Transact.SUPPLIER_COUNTRY_NAME = ds.Tables[0].Rows[0]["SUP_COUNTRY_NAME"].ToString();
        }

        adminmaster Admin_mas = new adminmaster();
        string imp_name = ViewState["imp_name"].ToString().Trim();
        Admin_mas.EImpName = imp_name;
        Admin_mas.ESupName = txtSupplier.Text.Trim();
        Admin_mas.Ename = "GET_SVB_DETAILS";
        ds = Admin_mas.SVB_Relation_Master();
        if (ds.Tables[0].Rows.Count > 0)
        {
            Transact.SVB_RELATION = ds.Tables[0].Rows[0]["SVB_RELATION"].ToString();
            Transact.SVB_REF_NO = ds.Tables[0].Rows[0]["SVB_REF_NO"].ToString();
            Transact.SVB_REF_DATE = ds.Tables[0].Rows[0]["SVB_REF_DATE"].ToString();
            Transact.SVB_CUSTOM_HOUSE = ds.Tables[0].Rows[0]["SVB_CUSTOM_HOUSE"].ToString();
            Transact.SVB_LOADING_ON = ds.Tables[0].Rows[0]["SVB_LOADING_ON"].ToString();
            Transact.SVB_ASSESABLE_RATE = ds.Tables[0].Rows[0]["SVB_ASSESABLE_RATE"].ToString();
            Transact.SVB_DUTY_RATE = ds.Tables[0].Rows[0]["SVB_DUTY_RATE"].ToString();
            Transact.SVB_ASSESABLE_STATUS = ds.Tables[0].Rows[0]["SVB_ASSESABLE_STATUS"].ToString();
            Transact.SVB_DUTY_STATUS = ds.Tables[0].Rows[0]["SVB_DUTY_STATUS"].ToString();
        }

        Transact.OTHER_NATURE_OF_TRANSACTION = "S Sale";
        Transact.OTHER_TERMS_OF_PAYMENT = "OTH Others";
        Transact.OTHER_VALUATION_METHOD = "Rule 4 - Transaction Value";

        //Transact.OTHER_PURCHASE_ORDER_DATE = "01/01/1900";
        Transact.OTHER_CONTRACT_DATE = "01/01/1900";
        Transact.OTHER_LOC_DATE = "01/01/1900";
        Transact.NON_STD_CERTIFICATE_DATE = "01/01/1900";
        Transact.SHIP_DATE = "01/01/1900";
        Transact.SVB_REF_DATE = "01/01/1900";
        Transact.flag = "S";
        Transact.USER_ID = currentuser;
        Transact.BRANCH_CODE = currentbranch;
        Transact.BRANCH_COMMON = currentbranch;
        Transact.WORKING_PERIOD = Working_Period;

        Transact.Invoice_Details_insertupdate();
    }

    public DataSet GetJobId()
    {
        DataSet ds = new DataSet();
        try
        {
            Transact.JOBNO = Session["JOBNO"].ToString();
            Transact.Ename = "GetJobId";
            Transact.IMPORTER_NAME = "";
            Transact.TRANSPORT_MODE = "";
            Transact.CUSTOMS_HOUSE = "";
            Transact.WORKING_PERIOD = SELECT_BRANCH;
            ds = Transact.RetrieveAll_General_Details();
            if (ds.Tables[0].Rows.Count > 0)
            {
                string JOBID = ds.Tables[0].Rows[0]["JOBID"].ToString();
                Session["JOBIDexcel"] = JOBID;
            }
        }
        catch (Exception ex)
        {
            Session["JOBIDexcel"] = "";
        }
        return ds;
    }

    public void AUTO_JOBNO()
    {
        JOBNO = Convert.ToString(Retrieve_JobNO());
        Session["JOBNO"] = JOBNO;
        JobNo_Prefix_Sufix(JOBNO);
    }

    public void JobNo_Prefix_Sufix(string JOBNO)
    {
        Admin_job_Prefix_Suffix JPS = new Admin_job_Prefix_Suffix();
        DataSet dats = new DataSet();
        JPS.Branch = SELECT_BRANCH;
        JPS.Tr_mode = TRANSPORT_MODE;
        JPS.Ename = "Imp_gen_select";
        JPS.BranchType = Session["SELECT_TYPE"].ToString();

        dats = JPS.Job_prefix_Suffix_Select_Areawise();

        int Jno = 0;
        string JobNo = string.Empty;
        JobNo = JOBNO;

        if (JobNo != string.Empty)
        {
            Jno = Convert.ToInt32(JobNo);
            if (Jno < 1000)
            {
                if (Jno > 100)
                {
                    JobNo = "00" + JOBNO;
                }
                else if (Jno > 10)
                {
                    JobNo = "000" + JOBNO;
                }
                else
                {
                    JobNo = "0000" + JOBNO;
                }
            }
        }

        if (Session["COMPANY_LICENSE"] != null)
        {
            if (Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00247")
            {
                if (dats.Tables[0].Rows.Count > 0)
                {
                    if (dats.Tables[0].Rows[0][0].ToString() == string.Empty && dats.Tables[0].Rows[0][1].ToString() != string.Empty)
                    {
                        txtjobPS.Text = JOBNO + "/" + ((dats.Tables[0].Rows[0][1].ToString()).TrimStart()).TrimEnd();
                        hdprefix.Value = string.Empty;
                        hdsuffix.Value = ((dats.Tables[0].Rows[0][1].ToString()).TrimStart()).TrimEnd();
                    }
                    else if (dats.Tables[0].Rows[0][0].ToString() != string.Empty && dats.Tables[0].Rows[0][1].ToString() == string.Empty)
                    {
                        txtjobPS.Text = ((dats.Tables[0].Rows[0][0].ToString() + JOBNO).TrimEnd()).TrimStart();
                        hdprefix.Value = ((dats.Tables[0].Rows[0][0].ToString()).TrimEnd()).TrimStart();
                        hdsuffix.Value = string.Empty;
                    }
                    else if (dats.Tables[0].Rows[0][0].ToString() != string.Empty && dats.Tables[0].Rows[0][1].ToString() != string.Empty)
                    {
                        txtjobPS.Text = ((dats.Tables[0].Rows[0][0].ToString() + JOBNO + "/" + dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                        hdprefix.Value = ((dats.Tables[0].Rows[0][0].ToString()).TrimEnd()).TrimStart();
                        hdsuffix.Value = ((dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                    }
                    else if (dats.Tables[0].Rows[0][0].ToString() == string.Empty && dats.Tables[0].Rows[0][1].ToString() == string.Empty)
                    {
                        txtjobPS.Text = JOBNO;
                        hdprefix.Value = string.Empty;
                        hdsuffix.Value = string.Empty;
                    }
                }
                else
                {
                    txtjobPS.Text = JOBNO;
                    hdprefix.Value = string.Empty;
                    hdsuffix.Value = string.Empty;
                }
            }
            else
            {
                if (dats.Tables[0].Rows.Count > 0)
                {
                    if (dats.Tables[0].Rows[0][0].ToString() == string.Empty && dats.Tables[0].Rows[0][1].ToString() != string.Empty)
                    {
                        txtjobPS.Text = JOBNO + "/" + ((dats.Tables[0].Rows[0][1].ToString()).TrimStart()).TrimEnd();
                        hdprefix.Value = string.Empty;
                        hdsuffix.Value = ((dats.Tables[0].Rows[0][1].ToString()).TrimStart()).TrimEnd();
                    }
                    else if (dats.Tables[0].Rows[0][0].ToString() != string.Empty && dats.Tables[0].Rows[0][1].ToString() == string.Empty)
                    {
                        if (Connection.COMPANYID() == "1163" || Connection.COMPANYID() == "1164" || Connection.COMPANYID() == "1165" || Connection.COMPANYID() == "1166")
                        {
                            txtjobPS.Text = ((dats.Tables[0].Rows[0][0].ToString() + "/" + JobNo).TrimEnd()).TrimStart();
                        }
                        else
                        {
                            txtjobPS.Text = ((dats.Tables[0].Rows[0][0].ToString() + "/" + JOBNO).TrimEnd()).TrimStart();
                        }

                        hdprefix.Value = ((dats.Tables[0].Rows[0][0].ToString()).TrimEnd()).TrimStart();
                        hdsuffix.Value = string.Empty;
                    }
                    else if (dats.Tables[0].Rows[0][0].ToString() != string.Empty && dats.Tables[0].Rows[0][1].ToString() != string.Empty)
                    {
                        if (Connection.COMPANYID() == "1163" || Connection.COMPANYID() == "1164" || Connection.COMPANYID() == "1165" || Connection.COMPANYID() == "1166")
                        {
                            txtjobPS.Text = ((dats.Tables[0].Rows[0][0].ToString() + "/" + JobNo + "/" + dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                        }
                        else
                        {
                            txtjobPS.Text = ((dats.Tables[0].Rows[0][0].ToString() + "/" + JOBNO + "/" + dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                        }
                        hdprefix.Value = ((dats.Tables[0].Rows[0][0].ToString()).TrimEnd()).TrimStart();
                        hdsuffix.Value = ((dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                    }
                    else if (dats.Tables[0].Rows[0][0].ToString() == string.Empty && dats.Tables[0].Rows[0][1].ToString() == string.Empty)
                    {
                        txtjobPS.Text = JOBNO;
                        hdprefix.Value = string.Empty;
                        hdsuffix.Value = string.Empty;
                    }
                }
                else
                {
                    txtjobPS.Text = JOBNO;
                    hdprefix.Value = string.Empty;
                    hdsuffix.Value = string.Empty;
                }
            }
            Session["JOBNO_PS"] = txtjobPS.Text;
        }
    }

    public int Get_general_MAXID(string Flag)
    {
        objUBO.IEC_NO = "";
        objUBO.BRANCH_NO = "";
        objUBO.Ename = Flag;
        objUBO.WORKING_PERIOD = Connection.Get_Company_Type();
        ds_IEC = xl.Bind_Export_General_IEC_No(objUBO);
        if (ds_IEC.Tables[0].Rows.Count > 0)
        {
            MAX_ID = Convert.ToInt32(ds_IEC.Tables[0].Rows[0]["MAXID"].ToString());
        }

        return MAX_ID;
    }

    protected void btn_Refresh_Click(object sender, ImageClickEventArgs e)
    {
        Page_Load(sender, e);
        txtInvNo.Text = "";
        txtInvDate.Text = "";
        txtCurrency.Text = "";
        txtCountryOfOrigin.Text = "";
        txtPortOfOrigin.Text = "";

        DataTable dt = new DataTable();
        gv_ItemPDF.DataSource = dt;
        gv_ItemPDF.DataBind();
    }

    private string Get_Valid_Curr_Name(string curr)
    {
        if (curr == "EURO")
        {
            curr = "EUR";
        }
        else if (curr == "US")
        {
            curr = "USD";
        }

        return curr;
    }

    private string Get_Valid_Qty_Code(string curr)
    {
        if (curr != "" && curr != string.Empty && curr != null)
        {
            if (curr == "SETS")
            {
                curr = "SET";
            }
            else if (curr.Contains("SET"))
            {
                curr = "SET";
            }
            else if (curr == "SET(S)")
            {
                curr = "SET";
            }
            else if (curr == "PIECE(S)" || curr == "PCE" || curr == "PC" || curr == "pcs")
            {
                curr = "PCS";
            }
            else if (curr.Contains("PC/PK"))
            {
                curr = "PAK";
            }
            else if (curr.Contains("PCS/PK"))
            {
                curr = "PAK";
            }
            else if (curr.Contains("PCS/PACK"))
            {
                curr = "PAK";
            }
            else if (curr == "PACK(S)")
            {
                curr = "PAC";
            }
            else if (curr == "MTRS." || curr == "MTRS")
            {
                curr = "MTR";
            }
            else if (curr == "EA")
            {
                curr = "NOS";
            }
            else if (curr == "YRD")
            {
                curr = "YDS";
            }
            else if (curr == "KG")
            {
                curr = "KGS";
            }
        }

        return curr;
    }

    //private string Get_Valid_Date(string Dt)
    //{
    //    Dt = Dt.Replace(".", "/").Replace("-", "/").Replace(",", "/").Replace(" ", "/");
    //    string[] dd = Dt.Split('/');

    //    if (dd[0].Length == 3)
    //    {
    //        string ExchangeMonth = dd[0];
    //        string ExchangeDate = dd[1];

    //        dd[1] = ExchangeMonth;
    //        dd[0] = ExchangeDate;
    //    }
    //    else if (dd[0].Length == 4)
    //    {
    //        string YearExchange = dd[0];
    //        string DateExchange = dd[2];

    //        dd[2] = YearExchange;
    //        dd[0] = DateExchange;
    //    }
    //    if (dd[0].Length != 2)
    //    {
    //        dd[0] = "0" + dd[0];
    //    }
    //    if (dd[1].Length != 2)
    //    {
    //        dd[1] = dd[1].Replace("JAN", "1").Replace("FEB", "2").Replace("MAR", "3").Replace("Mar", "3").Replace("APR", "4").Replace("June", "6").Replace("JUNE", "6");
    //        dd[1] = "0" + dd[1];
    //    }
    //    if (dd[2].Length != 4)
    //    {
    //        dd[2] = "20" + dd[2];
    //    }

    //    return Dt = dd[0] + "/" + dd[1] + "/" + dd[2];   
    //}

    private string Get_Valid_Date(string Dt)
    {
        if (string.IsNullOrWhiteSpace(Dt))
            return "Invalid Date";

        Dt = Dt.Trim();

        // Remove ordinal suffixes (st, nd, rd, th)
        Dt = Regex.Replace(Dt, @"\b(\d+)(st|nd|rd|th)\b", "$1", RegexOptions.IgnoreCase);

        // Replace common separators with slash for normalization
        Dt = Dt.Replace(".", "/").Replace("-", "/").Replace(",", "/").Replace("  ", " ").Replace("nd", "").Replace("st", "").Replace("rd", "").Replace("th", "");

        // Common possible formats
        string[] formats = new[]
    {
        "MMM/dd/yyyy", "dd/MMM/yyyy", "MM/dd/yyyy", "dd/MM/yyyy",
        "yyyy/MM/dd", "yyyyMMdd", "dd/MM/yy", "dd/MMM/yy",
        "MMM.d/yyyy", "MMM.d,yyyy", "dd-MMM-yy", "dd/MM/yyyy",
        "MMM dd yyyy", "MMM dd, yyyy", "dd MMM yyyy", "dd MMM, yyyy",
        "dd/MM/yyyy", "dd.MM.yyyy", "dd-MM-yyyy", "yyyy-MM-dd",
        "MMMM d yyyy", "MMMM d, yyyy", "dd/MMM/yyyy", "MMM.d.yyyy",
        "d/MM/yyyy", "d/M/yyyy","MMM d yyyy", "MMM d, yyyy","MMM d,yyyy"
    };

        DateTime parsedDate;
        if (DateTime.TryParseExact(Dt, formats, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, out parsedDate))
        {
            return parsedDate.ToString("dd/MM/yyyy");
        }
        else if (DateTime.TryParse(Dt, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, out parsedDate))
        {
            return parsedDate.ToString("dd/MM/yyyy");
        }
        else
        {
            return "Invalid Date";
        }
    }

    protected void btn_bulk_Update_All_Click(object sender, EventArgs e)
    {
        try
        {
            if (ListBox_ItemSlno.SelectedItem != null && ListBox_ItemSlno.SelectedItem.Text != null)
            {
                int rowIndex = gv_ItemPDF.Rows.Count;
                DataTable GridViewData = (DataTable)ViewState["GridViewData"];
                if (gv_ItemPDF.Rows.Count > 0)
                {
                    DropDownList ddl_SchemeCode = null, ddl_Scheme_NOTN = null; string[] schemeParts = null;
                    for (int i = 0; i < gv_ItemPDF.Rows.Count; i++)
                    {
                        if (txtDescription.Text != "")
                        {
                            TextBox txtItemDesc = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtItemDesc");
                            txtItemDesc.Text = txtDescription.Text;
                        }
                        if (ddlSchemeCode != null && ddlSchemeCode.SelectedItem != null && ddlSchemeCode.SelectedItem.Text != "")
                        {
                            ddl_SchemeCode = (DropDownList)gv_ItemPDF.Rows[i].FindControl("ddl_SchemeCode");
                            ddl_SchemeCode.SelectedValue = ddlSchemeCode.SelectedValue;
                        }
                        if (ddlScheme_NOTN != null && ddlScheme_NOTN.SelectedItem != null && ddlScheme_NOTN.SelectedItem.Text != "")
                        {
                            ddl_Scheme_NOTN = (DropDownList)gv_ItemPDF.Rows[i].FindControl("ddl_Scheme_NOTN");
                            string selectedValue = ddl_SchemeCode.SelectedValue.ToString();
                            schemeParts = selectedValue.Split(new string[] { "-" }, StringSplitOptions.None);

                            ddl_Scheme_NOTN.Items.Clear();

                            if (schemeParts[0].Trim() != "00")
                            {
                                adm.SCHEME_IMPORT_CODE = schemeParts[0].ToString();
                                adm.SCHEME_NOTN = "0";
                                adm.name = "SCHEME_NOTN";
                                ddl_Scheme_NOTN.DataSource = adm.RetrieveAll_Scheme_Import();
                                ddl_Scheme_NOTN.DataTextField = "SCHEME_NOTN";
                                ddl_Scheme_NOTN.DataValueField = "SCHEME_NOTN";
                                ddl_Scheme_NOTN.Items.Add(" ");
                                ddl_Scheme_NOTN.DataBind();
                                scheme_notn_slno();
                            }
                            else
                            {
                                ddl_Scheme_NOTN.Items.Clear();
                            }

                            ddl_Scheme_NOTN.SelectedValue = ddlScheme_NOTN.SelectedValue;
                        }
                        if (ddlScheme_NOTN_SL != null && ddlScheme_NOTN_SL.SelectedItem != null && ddlScheme_NOTN_SL.SelectedItem.Text != "")
                        {
                            DropDownList ddl_Scheme_NOTN_SL = (DropDownList)gv_ItemPDF.Rows[i].FindControl("ddl_Scheme_NOTN_SL");
                            ddl_Scheme_NOTN_SL.Items.Clear();
                            adm.SCHEME_IMPORT_CODE = schemeParts[0].ToString();
                            adm.SCHEME_NOTN = ddl_Scheme_NOTN.SelectedValue;
                            adm.name = "SCHEME_NOTN_SLNO";
                            ddl_Scheme_NOTN_SL.DataSource = adm.RetrieveAll_Scheme_Import();
                            ddl_Scheme_NOTN_SL.DataTextField = "SCHEME_NOTN_SLNO";
                            ddl_Scheme_NOTN_SL.DataValueField = "SCHEME_NOTN_SLNO";
                            ddl_Scheme_NOTN_SL.Items.Add(" ");
                            ddl_Scheme_NOTN_SL.DataBind();

                            ddl_Scheme_NOTN_SL.SelectedValue = ddlScheme_NOTN_SL.SelectedValue;
                        }
                        //if (ddlSchemeCode.SelectedItem.Text != "")
                        //{
                        //    DropDownList ddlScheme_Code = (DropDownList)gv_ItemPDF.Rows[i].FindControl("ddl_SchemeCode");
                        //    ddlScheme_Code.SelectedValue = ddlSchemeCode.SelectedValue;
                        //}
                        if (txtCTH.Text != "")
                        {
                            TextBox txt_CTH = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_CTH");
                            txt_CTH.Text = txtCTH.Text;
                        }
                        if (txtBasicNotn.Text != "")
                        {
                            TextBox txtBasicNoti = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtBasicNoti");
                            txtBasicNoti.Text = txtBasicNotn.Text;
                        }
                        if (txtBasicSLNO.Text != "")
                        {
                            TextBox txtBasicSlno = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtBasicSlno");
                            txtBasicSlno.Text = txtBasicSLNO.Text;
                        }
                        if (txtBasicRate.Text != "")
                        {
                            TextBox txt_Basic_Rate = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_Basic_Rate");
                            txt_Basic_Rate.Text = txtBasicRate.Text;
                        }
                        if (txtinfo_MSR.Text != "")
                        {
                            TextBox txtinfoMSR = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtinfoMSR");
                            txtinfoMSR.Text = txtinfo_MSR.Text;
                        }
                        if (txt_info_UQC.Text != "")
                        {
                            TextBox txtinfoUQC = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtinfo_UQC");
                            txtinfoUQC.Text = txt_info_UQC.Text;
                        }
                        if (txtitemCountyof_orgin.Text != "")
                        {
                            TextBox txtitemCountyoforgin = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtitemCountyoforgin");
                            txtitemCountyoforgin.Text = txtitemCountyof_orgin.Text;
                        }
                        if (txtSW_Noti.Text != "")
                        {
                            TextBox txt_SW_Noti = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_SW_Noti");
                            txt_SW_Noti.Text = txtSW_Noti.Text;
                        }
                        if (txtSW_Slno.Text != "")
                        {
                            TextBox txt_SW_Slno = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_SW_Slno");
                            txt_SW_Slno.Text = txtSW_Slno.Text;
                        }
                        if (txt_SW_Rate.Text != "")
                        {
                            TextBox txtSW_Rate = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtSW_Rate");
                            txtSW_Rate.Text = txt_SW_Rate.Text;
                        }
                        if (txt_AIDC_CessNoti.Text != "")
                        {
                            TextBox txt_AIDCCessNoti = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_AIDCCessNoti");
                            txt_AIDCCessNoti.Text = txt_AIDC_CessNoti.Text;
                        }
                        if (txt_AIDC_CessSlno.Text != "")
                        {
                            TextBox txt_AIDCCessSlno = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_AIDCCessSlno");
                            txt_AIDCCessSlno.Text = txt_AIDC_CessSlno.Text;
                        }
                        if (txt_AIDC_CessRate.Text != "")
                        {
                            TextBox txt_AIDCCessRate = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_AIDCCessRate");
                            txt_AIDCCessRate.Text = txt_AIDC_CessRate.Text;
                        }
                        if (txt_IGST_Noti.Text != "")
                        {
                            TextBox txt_IGSTNoti = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_IGSTNoti");
                            txt_IGSTNoti.Text = txt_IGST_Noti.Text;
                        }
                        if (txt_IGST_SlNo.Text != "")
                        {
                            TextBox txt_IGSTSlNo = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_IGSTSlNo");
                            txt_IGSTSlNo.Text = txt_IGST_SlNo.Text;
                        }
                        if (txt_IGST_Rate.Text != "")
                        {
                            TextBox txt_IGSTRate = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_IGSTRate");
                            txt_IGSTRate.Text = txt_IGST_Rate.Text;
                        }
                        rowIndex++;
                    }
                }
            }
            else
            {
                Alert_msg("Please Select Inv & Item...!");
            }
        }
        catch (Exception ex)
        {
            log.makeLog("Message ==> " + ex.Message);
            lblmsg.Text = " Message ==> " + ex.Message + " InnerException ==> " + ex.InnerException + " StackTrace ==>" + ex.StackTrace;
        }
    }

    protected void btnLoad_Click(object sender, EventArgs e)
    {
        try
        {
            if (ListBox_INVSlno.SelectedItem != null && ListBox_INVSlno.SelectedItem.Text != null && ListBox_ItemSlno.SelectedItem != null && ListBox_ItemSlno.SelectedItem.Text != null)
            {
                DataTable GridViewData = (DataTable)ViewState["GridViewData"];

                if (GridViewData.Rows.Count > 0)
                {
                    for (int i = 0; i < gv_ItemPDF.Rows.Count; i++)
                    {
                        TextBox txtInvSlNo = (TextBox)gv_ItemPDF.Rows[i].Cells[0].FindControl("txtInvSlNo");
                        string Inv_slno = txtInvSlNo.Text;
                        TextBox txtItemSlNo = (TextBox)gv_ItemPDF.Rows[i].Cells[0].FindControl("txtItemSlNo");
                        string slno = txtItemSlNo.Text;

                        for (int j = 0; j < GridViewData.Rows.Count; j++)
                        {
                            if (GridViewData.Rows[j]["InvoiceSlNo"].ToString() == Inv_slno.ToString() && 
                                GridViewData.Rows[j]["ItemSlNo"].ToString() == slno.ToString())
                            {
                                TextBox txtItemDesc = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtItemDesc");
                                DropDownList ddl_SchemeCode = (DropDownList)gv_ItemPDF.Rows[i].FindControl("ddl_SchemeCode");
                                DropDownList ddl_Scheme_NOTN = (DropDownList)gv_ItemPDF.Rows[i].FindControl("ddl_Scheme_NOTN");
                                DropDownList ddl_Scheme_NOTN_SL = (DropDownList)gv_ItemPDF.Rows[i].FindControl("ddl_Scheme_NOTN_SL");
                                TextBox txtCTH = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_CTH");
                                TextBox txtBasicNoti = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtBasicNoti");
                                TextBox txtBasicSlno = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtBasicSlno");
                                TextBox txt_Basic_Rate = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_Basic_Rate");
                                TextBox txtinfoMSR = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtinfoMSR");
                                TextBox txtinfoUQC = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtinfo_UQC");
                                TextBox txtitemCountyoforgin = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtitemCountyoforgin");
                                TextBox txtSW_Noti = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_SW_Noti");
                                TextBox txtSW_Slno = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_SW_Slno");
                                TextBox txtSW_Rate = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtSW_Rate");
                                TextBox txt_AIDCCessNoti = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_AIDCCessNoti");
                                TextBox txt_AIDCCessSlno = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_AIDCCessSlno");
                                TextBox txt_AIDCCessRate = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_AIDCCessRate");
                                TextBox txt_IGSTNoti = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_IGSTNoti");
                                TextBox txt_IGSTSlNo = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_IGSTSlNo");
                                TextBox txt_IGSTRate = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_IGSTRate");

                                GridViewData.Rows[j]["ITEM_DESC"] = txtItemDesc.Text;
                                GridViewData.Rows[j]["SchemeCode"] = ddl_SchemeCode.SelectedValue;
                                GridViewData.Rows[j]["Scheme_NOTN"] = ddl_Scheme_NOTN.SelectedValue;
                                GridViewData.Rows[j]["Scheme_NOTN_SL"] = ddl_Scheme_NOTN_SL.SelectedValue;
                                GridViewData.Rows[j]["HSCode"] = txtCTH.Text;
                                GridViewData.Rows[j]["Basic_Noti"] = txtBasicNoti.Text;
                                GridViewData.Rows[j]["Basic_Slno"] = txtBasicSlno.Text;
                                GridViewData.Rows[j]["Basic_Rate"] = txt_Basic_Rate.Text;
                                GridViewData.Rows[j]["info_MSR"] = txtinfoMSR.Text;
                                GridViewData.Rows[j]["info_UQC"] = txtinfoUQC.Text;
                                GridViewData.Rows[j]["itemCountyof_orgin"] = txtitemCountyoforgin.Text;
                                GridViewData.Rows[j]["SW_Noti"] = txtSW_Noti.Text;
                                GridViewData.Rows[j]["SW_Slno"] = txtSW_Slno.Text;
                                GridViewData.Rows[j]["SW_Rate"] = txtSW_Rate.Text;
                                GridViewData.Rows[j]["AIDC_CessNoti"] = txt_AIDCCessNoti.Text;
                                GridViewData.Rows[j]["AIDC_CessSlno"] = txt_AIDCCessSlno.Text;
                                GridViewData.Rows[j]["AIDC_CessRate"] = txt_AIDCCessRate.Text;
                                GridViewData.Rows[j]["IGST_Noti"] = txt_IGSTNoti.Text;
                                GridViewData.Rows[j]["IGST_SlNo"] = txt_IGSTSlNo.Text;
                                GridViewData.Rows[j]["IGST_Rate"] = txt_IGSTRate.Text;
                                break;
                            }
                        }
                    }
                    DataTable filteredTable = FilterDataTableBySerialNumbers(GridViewData);

                    gv_ItemPDF.DataSource = filteredTable;
                    gv_ItemPDF.DataBind();

                    //ViewState["GridViewData"] = GridViewData;
                }
            }
            else
            {
                Alert_msg("Please Select Inv & Item...!");
            }
        }
        catch (Exception ex)
        {
            log.makeLog("Message ==> " + ex.Message);
            lblmsg.Text = " Message ==> " + ex.Message + " InnerException ==> " + ex.InnerException + " StackTrace ==>" + ex.StackTrace;
        }
    }

    private DataTable FilterDataTableBySerialNumbers(DataTable dt)
    {
        DataTable filteredTable = dt.Clone();
        int index = 0; int InvoiceserialNumbers = 0, serialNo = 0, selectedINVSerialNumbers = 0, selectedSerialNumbers = 0;
        foreach (DataRow row in dt.Rows)
        {
            foreach (ListItem item in ListBox_ItemSlno.Items)
            {
                if (item.Selected)
                {
                    string[] Split_Inv_item = item.Text.Trim().Split('~');
                    selectedINVSerialNumbers = (Convert.ToInt32(Split_Inv_item[0]));
                    selectedSerialNumbers = (Convert.ToInt32(Split_Inv_item[1]));

                    InvoiceserialNumbers = Convert.ToInt32(row["InvoiceSlNo"]);
                    if (ddl_Select_ItemRITC.SelectedValue == "0")
                    {
                        serialNo = Convert.ToInt32(row["ItemSlNo"]);
                    }
                    else if (ddl_Select_ItemRITC.SelectedValue == "1")
                    {
                        serialNo = Convert.ToInt32(row["HSCode"]);
                    }
                    if ((selectedINVSerialNumbers == InvoiceserialNumbers) && (selectedSerialNumbers == serialNo))
                    {
                        filteredTable.ImportRow(row);
                    }
                }
            }
            index++;
        }
        return filteredTable;
    }

    protected void ddl_Select_ItemRITC_SelectedIndexChanged(object sender, EventArgs e)
    {
        Select_ItemRITC();
    }

    public void Select_ItemRITC()
    {
        DataTable dt_GridViewData = (DataTable)ViewState["GridViewData"];
        if (dt_GridViewData.Rows.Count > 0)
        {
            var distinctValues = dt_GridViewData.AsEnumerable().Select(row => row["InvoiceSlNo"].ToString()).Distinct().ToList();

            DataTable distinctDt = dt_GridViewData.Clone();
            foreach (var value in distinctValues)
            {
                distinctDt.Rows.Add(value);
            }
            ListBox_INVSlno.DataSource = distinctDt;
            ListBox_INVSlno.DataTextField = "InvoiceSlNo";
            ListBox_INVSlno.DataValueField = "InvoiceSlNo";
            ListBox_INVSlno.DataBind();

            if (ddl_Select_ItemRITC.SelectedValue == "0")
            {

                ListBox_ItemSlno.Items.Clear();
                foreach (DataRow row in dt_GridViewData.Rows)
                {
                    string invoiceSlno = row["InvoiceSlNo"].ToString(); // Assuming INVOICE_SLNO is a string
                    string itemSlno = row["ItemSlNo"].ToString(); // Assuming ITEM_SLNO is a string

                    string itemText = invoiceSlno + "~" + itemSlno;
                    string itemValue = invoiceSlno + "~" + itemSlno;

                    // Add item to ListBox_Item
                    ListBox_ItemSlno.Items.Add(new ListItem(itemText, itemValue));
                }
            }
            else if (ddl_Select_ItemRITC.SelectedValue == "1")
            {
                //var uniqueRows = dt_GridViewData.AsEnumerable()
                //       .GroupBy(row => row["HSCode"])
                //       .Select(group => group.First())
                //       .CopyToDataTable();

                var uniqueRows = dt_GridViewData.AsEnumerable()
                       .GroupBy(row => new { Invoice = row["InvoiceSlNo"], Ritc = row["HSCode"] })
                       .Select(group => group.First())
                       .CopyToDataTable();

                ListBox_ItemSlno.Items.Clear();
                foreach (DataRow row in uniqueRows.Rows)
                {
                    string invoiceSlno = row["InvoiceSlNo"].ToString(); // Assuming INVOICE_SLNO is a string
                    string itemSlno = row["HSCode"].ToString(); // Assuming ITEM_SLNO is a string

                    string itemText = invoiceSlno + "~" + itemSlno;
                    string itemValue = invoiceSlno + "~" + itemSlno;

                    // Add item to ListBox_Item
                    ListBox_ItemSlno.Items.Add(new ListItem(itemText, itemValue));
                }
            }
        }
    }

    public DataSet Get_AccessToken_Invoice(DataSet GetLocalAPIData, string LocalFile)
    {
        string StoreData = File.ReadAllText(LocalFile);
        JObject jsonData = JObject.Parse(StoreData);
        DataSet ds = new DataSet();

        DataTable headerTable = JsonConvert.DeserializeObject<DataTable>(jsonData["Header"].ToString());
        headerTable.TableName = "Header";
        ds.Tables.Add(headerTable);

        DataTable InvoiceDetails = JsonConvert.DeserializeObject<DataTable>(jsonData["InvoiceDetails"].ToString());
        InvoiceDetails.TableName = "InvoiceDetails";
        ds.Tables.Add(InvoiceDetails);

        DataTable itemsTable = JsonConvert.DeserializeObject<DataTable>(jsonData["ItemsDetails"].ToString());
        itemsTable.TableName = "ItemsDetails";
        ds.Tables.Add(itemsTable);

        DataTable ContainerTable = JsonConvert.DeserializeObject<DataTable>(jsonData["ItemsIGMContainerDetails"].ToString());
        ContainerTable.TableName = "ItemsIGMContainerDetails";
        ds.Tables.Add(ContainerTable);

        DataTable BondTable = JsonConvert.DeserializeObject<DataTable>(jsonData["ItemsIGMSBondDetails"].ToString());
        BondTable.TableName = "ItemsIGMSBondDetails";
        ds.Tables.Add(BondTable);

        return ds;
    }

    protected void ddlSchemeCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            scheme_NOTN();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>CTH_tab();</script>", false);
        }
    }

    protected void ddlScheme_NOTN_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            ddlScheme_NOTN_SL.Enabled = true;
            scheme_notn_slno();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>CTH_tab();</script>", false);
        }
    }

    public void scheme_NOTN()
    {
        string str = ddlSchemeCode.SelectedValue.ToString();
        string[] s1 = str.Split(new string[] { "-" }, StringSplitOptions.None);

        ddlScheme_NOTN.Items.Clear();
        ddlScheme_NOTN_SL.Items.Clear();

        if (s1[0].Trim().ToString() != "00")
        {
            adm.SCHEME_IMPORT_CODE = s1[0].ToString();
            adm.SCHEME_NOTN = "0";
            adm.name = "SCHEME_NOTN";
            ddlScheme_NOTN.DataSource = adm.RetrieveAll_Scheme_Import();
            ddlScheme_NOTN.DataTextField = "SCHEME_NOTN";
            ddlScheme_NOTN.DataValueField = "SCHEME_NOTN";
            ddlScheme_NOTN.Items.Add(" ");
            ddlScheme_NOTN.DataBind();
            scheme_notn_slno();

        }
        else
        {
            ddlScheme_NOTN.Items.Clear();
            ddlScheme_NOTN_SL.Items.Clear();
        }
    }

    public void scheme_notn_slno()
    {
        string str = ddlSchemeCode.SelectedValue;
        string[] s1 = str.Split(new string[] { "-" }, StringSplitOptions.None);
        ddlScheme_NOTN_SL.Items.Clear();

        adm.SCHEME_IMPORT_CODE = s1[0].ToString();
        adm.SCHEME_NOTN = ddlScheme_NOTN.SelectedValue;
        adm.name = "SCHEME_NOTN_SLNO";
        ddlScheme_NOTN_SL.DataSource = adm.RetrieveAll_Scheme_Import();
        ddlScheme_NOTN_SL.DataTextField = "SCHEME_NOTN_SLNO";
        ddlScheme_NOTN_SL.DataValueField = "SCHEME_NOTN_SLNO";
        ddlScheme_NOTN_SL.Items.Add(" ");
        ddlScheme_NOTN_SL.DataBind();
    }

    protected void ddl_SchemeCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Find the row that triggered the change
        DropDownList ddl_SchemeCode = sender as DropDownList;
        GridViewRow row = (GridViewRow)ddl_SchemeCode.NamingContainer;

        DropDownList ddl_Scheme_NOTN = row.FindControl("ddl_Scheme_NOTN") as DropDownList;
        DropDownList ddl_Scheme_NOTN_SL = row.FindControl("ddl_Scheme_NOTN_SL") as DropDownList;

        string selectedValue = ddl_SchemeCode.SelectedValue.ToString();
        string[] schemeParts = selectedValue.Split(new string[] { "-" }, StringSplitOptions.None);

        // Clear previous selections
        ddl_Scheme_NOTN.Items.Clear();
        ddl_Scheme_NOTN_SL.Items.Clear();

        if (schemeParts[0].Trim() != "00")
        {
            // Refresh Scheme Noti and Scheme Sl.No based on Scheme Code
            adm.SCHEME_IMPORT_CODE = schemeParts[0].ToString();
            adm.SCHEME_NOTN = "0";
            adm.name = "SCHEME_NOTN";
            ddl_Scheme_NOTN.DataSource = adm.RetrieveAll_Scheme_Import();
            ddl_Scheme_NOTN.DataTextField = "SCHEME_NOTN";
            ddl_Scheme_NOTN.DataValueField = "SCHEME_NOTN";
            ddl_Scheme_NOTN.Items.Add(" ");
            ddl_Scheme_NOTN.DataBind();
            scheme_notn_slno();
        }
        else
        {
            ddl_Scheme_NOTN.Items.Clear();
            ddl_Scheme_NOTN_SL.Items.Clear();
        }

        // Refresh Scheme Sl.No
        ddl_Scheme_NOTN_SL.Items.Clear();
        adm.SCHEME_IMPORT_CODE = schemeParts[0].ToString();
        adm.SCHEME_NOTN = ddl_Scheme_NOTN.SelectedValue;
        adm.name = "SCHEME_NOTN_SLNO";
        ddl_Scheme_NOTN_SL.DataSource = adm.RetrieveAll_Scheme_Import();
        ddl_Scheme_NOTN_SL.DataTextField = "SCHEME_NOTN_SLNO";
        ddl_Scheme_NOTN_SL.DataValueField = "SCHEME_NOTN_SLNO";
        ddl_Scheme_NOTN_SL.Items.Add(" ");
        ddl_Scheme_NOTN_SL.DataBind();
    }

    public int Retrieve_JobNO()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[50];
            param[4] = new SqlParameter("@BRANCH_CODE", Connection.Get_Company_Type());
            param[1] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[2] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[2].Direction = ParameterDirection.Output;
            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3].Direction = ParameterDirection.Output;

            Connection.Get_Dataset("SP_IMPORT_GENERAL_DETAILS_AUTOID", param);
            result = Convert.ToInt32(param[2].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        finally
        {

        }
        return result;
    }

    protected void ListBox_INVSlno_SelectedIndexChanged(object sender, EventArgs e)
    {
        Filter_INV_Item();
    }

    public void Filter_INV_Item()
    {
        DataTable dt_GridViewData = (DataTable)ViewState["GridViewData"];
        if (dt_GridViewData.Rows.Count > 0)
        {
            if (ListBox_INVSlno.SelectedItem != null && ListBox_INVSlno.SelectedItem.Text != null)
            {
                List<int> selectedSerialNumbers = new List<int>();

                foreach (ListItem INV in ListBox_INVSlno.Items)
                {
                    if (INV.Selected)
                    {
                        selectedSerialNumbers.Add(Convert.ToInt32(INV.Text));
                    }
                }
                if (dt_GridViewData.Rows.Count > 0)
                {
                    DataTable filteredTable = FilterDataTableBySerialNumbers_INV(dt_GridViewData, selectedSerialNumbers);
                    ListBox_ItemSlno.Items.Clear();

                    if (ddl_Select_ItemRITC.SelectedValue == "0")
                    {

                        ListBox_ItemSlno.Items.Clear();
                        foreach (DataRow row in filteredTable.Rows)
                        {
                            string invoiceSlno = row["InvoiceSlNo"].ToString(); // Assuming INVOICE_SLNO is a string
                            string itemSlno = row["ItemSlNo"].ToString(); // Assuming ITEM_SLNO is a string

                            string itemText = invoiceSlno + "~" + itemSlno;
                            string itemValue = invoiceSlno + "~" + itemSlno;

                            // Add item to ListBox_Item
                            ListBox_ItemSlno.Items.Add(new ListItem(itemText, itemValue));
                        }
                    }
                    else if (ddl_Select_ItemRITC.SelectedValue == "1")
                    {
                        //var uniqueRows = filteredTable.AsEnumerable()
                        //       .GroupBy(row => row["HSCode"])
                        //       .Select(group => group.First())
                        //       .CopyToDataTable();

                        var uniqueRows = filteredTable.AsEnumerable()
                              .GroupBy(row => new { Invoice = row["InvoiceSlNo"], Ritc = row["HSCode"] })
                              .Select(group => group.First())
                              .CopyToDataTable();

                        ListBox_ItemSlno.Items.Clear();
                        foreach (DataRow row in uniqueRows.Rows)
                        {
                            string invoiceSlno = row["InvoiceSlNo"].ToString(); // Assuming INVOICE_SLNO is a string
                            string itemSlno = row["HSCode"].ToString(); // Assuming ITEM_SLNO is a string

                            string itemText = invoiceSlno + "~" + itemSlno;
                            string itemValue = invoiceSlno + "~" + itemSlno;

                            // Add item to ListBox_Item
                            ListBox_ItemSlno.Items.Add(new ListItem(itemText, itemValue));
                        }
                    }
                }
            }
        }
    }

    private DataTable FilterDataTableBySerialNumbers_INV(DataTable dt, List<int> serialNumbers)
    {
        DataTable filteredTable = dt.Clone();
        int index = 0; int serialNo = 1;
        foreach (DataRow row in dt.Rows)
        {
            if (dt.Rows.Count > 0 && serialNumbers.Count > 0)
            {
                serialNo = Convert.ToInt32(row["InvoiceSlNo"]);

                if (serialNumbers.Contains(serialNo))
                {
                    filteredTable.ImportRow(row);
                }
                index++;
            }
        }
        return filteredTable;
    }

    protected void Rd_SInv_MInv_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Rd_SInv_MInv.SelectedValue == "M")
        {
            DataTable Dt_Temp_Invoice = new DataTable();
            Dt_Temp_Invoice = (DataTable)ViewState["dt_Invoice"];
            gd_TEMP_INV.DataSource = Dt_Temp_Invoice;
            gd_TEMP_INV.DataBind();

            ViewState["dt_Invoice"] = Dt_Temp_Invoice;
            MP_INV_DETAILS.Show();
            txtInvNo.Enabled = false;
            txtInvDate.Enabled = false;
            ddlTerms.Enabled = false;
            txtCurrency.Enabled = false;
            btn_Inv_Save.Visible = true;
        }
        else
        {
            txtInvNo.Enabled = true;
            txtInvDate.Enabled = true;
            ddlTerms.Enabled = true;
            txtCurrency.Enabled = true;
            btn_Inv_Save.Visible = false;
        }
    }

    public bool INV_BindgridViewData()
    {
        if (ViewState["dt_Invoice"] != null)
        {
            DataTable dt_Current_Inv = (DataTable)ViewState["dt_Invoice"];
            if (gd_TEMP_INV.Rows.Count > 0)
            {
                foreach (GridViewRow row in gd_TEMP_INV.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        TextBox txt_Temp_InvoiceNo = (TextBox)row.FindControl("txt_Temp_InvoiceNo");
                        TextBox txt_Temp_InvoiceDate = (TextBox)row.FindControl("txt_Temp_InvoiceDate");
                        TextBox txt_Temp_Currency = (TextBox)row.FindControl("txt_Temp_Currency");
                        TextBox txt_Temp_Terms = (TextBox)row.FindControl("txt_Temp_Terms");

                        if (txt_Temp_InvoiceNo.Text.Trim() != "" && txt_Temp_InvoiceDate.Text.Trim() != "" &&
                            txt_Temp_Currency.Text.Trim() != "" && txt_Temp_Terms.Text.Trim() != "")
                        {
                            string Temp_InvoiceNo = txt_Temp_InvoiceNo.Text;
                            string Temp_InvoiceDate = txt_Temp_InvoiceDate.Text;
                            string Temp_Currency = txt_Temp_Currency.Text;
                            string Temp_Terms = txt_Temp_Terms.Text;

                            if (row.RowIndex < dt_Current_Inv.Rows.Count)
                            {
                                dt_Current_Inv.Rows[row.RowIndex]["InvoiceNo"] = Temp_InvoiceNo;
                                dt_Current_Inv.Rows[row.RowIndex]["InvoiceDate"] = Temp_InvoiceDate;
                                dt_Current_Inv.Rows[row.RowIndex]["Currency"] = Temp_Currency;
                                dt_Current_Inv.Rows[row.RowIndex]["Terms"] = Temp_Terms;
                            }
                        }
                        else
                        {
                            Alert_msg("Please Enter All Mandatory Fields..!");
                            IsValidInv = false;
                            break;
                        }
                    }
                }
                ViewState["dt_Invoice"] = dt_Current_Inv;
            }
            else
            {
                Dt_Item = new DataTable();
                ViewState["dt_Invoice"] = dt_Current_Inv;
            }
        }
        else
        {
            dt_Temp_Inv = new DataTable();
            ViewState["dt_Invoice"] = dt_Temp_Inv;
        }

        return IsValidInv;
    }

    protected void btn_Inv_Save_Click(object sender, EventArgs e)
    {
        INV_BindgridViewData();
    }

    [System.Web.Services.WebMethod]
    public static string Get_Notn_Custom_Master_CTH_NOTN_SLNO(string Notn_no_sl, string Notn_no)
    {
        string Address1 = "";
        if (Notn_no != "" && Notn_no != "019/2006")
        {

            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            Auto.Ename = "NOTIFICATIONCUSTOM_MASTER_ALL_CTH_NOTN_SLNO";
            Auto.Enamesearch = Notn_no_sl;
            Auto.Notn_No_Search = Notn_no;

            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {
                Address1 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_RATE"].ToString();
            }
        }
        Notn_no_sl = Address1;

        return Notn_no_sl;
    }

    [System.Web.Services.WebMethod]
    public static string Get_Notn_Custom_Master_CTH_NOTN_SLNO_with_Type(string Notn_no_sl, string Notn_no, string Notn_Type)//search with Type
    {
        string Address1 = "", IsValidNotn = "";
        if (Notn_no != "" && Notn_no != "019/2006")
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            Auto.Ename = "NOTIFICATIONCUSTOM_MASTER_ALL_CTH_NOTN_SLNO_with_Type";//1st check with "SWS" Type
            Auto.Enamesearch = Notn_no_sl;
            Auto.Notn_No_Search = Notn_no;
            Auto.Notn_Type = Notn_Type;

            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {
                IsValidNotn = "Y";
            }
            else
            {
                Auto.Ename = "NOTIFICATIONCUSTOM_MASTER_ALL_CTH_NOTN_SLNO";//2nd check with "C"
                ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    IsValidNotn = "Y";
                }
            }

            if (IsValidNotn == "Y")
            {
                Address1 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_RATE"].ToString();
            }
        }
        Notn_no_sl = Address1;
        return Notn_no_sl;
    }

    [System.Web.Services.WebMethod]
    public static string Get_AIDC_Master(string custid, string CTH_No, string AIDC_Notn)
    {
        adminmaster Admin_mas = new adminmaster();
        DataSet ds = new DataSet();
        Admin_mas.AIDC_RITC_NO = CTH_No;
        Admin_mas.AIDC_NOTN_NO = AIDC_Notn;
        Admin_mas.AIDC_NOTN_SLNO = custid;

        Admin_mas.Ename = "ITEM_AIDC_NOTN_RATE";
        ds = Admin_mas.Get_AIDC_CESS_SELECT();
        if (ds.Tables[0].Rows.Count > 0)
        {
            custid = ds.Tables[0].Rows[0]["AIDC_NOTN_RATE"].ToString();
        }
        else
        {
            custid = "";
        }
        return custid;
    }

    [System.Web.Services.WebMethod]
    public static string Get_AIDC_Notn(string custid)
    {
        string AIDC_RATE = string.Empty;

        adminmaster Admin_mas = new adminmaster();
        DataSet ds = new DataSet();
        Admin_mas.AIDC_RITC_NO = custid;
        Admin_mas.Ename = "ITEM_RITC";
        ds = Admin_mas.Get_AIDC_CESS_SELECT();
        if (ds.Tables[0].Rows.Count > 0)
        {
            AIDC_RATE = ds.Tables[0].Rows[0]["AIDC_NOTN_RATE"].ToString();
            custid = AIDC_RATE;
        }
        else
        {
            /* hide on 14-02-2023 - below Notn should go for all the clients sugg.by Subbu sir 
            if (Connection.COMPANYID() == "1" || Connection.COMPANYID() == "436" || Connection.COMPANYID() == "662" || Connection.COMPANYID() == "1240" || Connection.COMPANYID() == "1512" || Connection.COMPANYID() == "1534" || Connection.COMPANYID() == "1550" || Connection.COMPANYID() == "1578" || Connection.COMPANYID() == "1620" || Connection.COMPANYID() == "1648" || Connection.COMPANYID() == "1665")
            {
                AIDC_NOTN = "011/2021";
                AIDC_NOTN_SLNO = "17";
                AIDC_RATE = "0.00";
                custid = AIDC_NOTN + "~~" + AIDC_NOTN_SLNO + "~~" + AIDC_RATE;
            }
            else
            {
                custid = "";
            }
             * */
            AIDC_RATE = "0.00";
            custid = AIDC_RATE;
        }
        return custid;
    }

    [System.Web.Services.WebMethod]
    public static string Get_Notn_Excise_Master_txt_IGST_LEVY_SLNO_1E(string Notn_no_sl, string Notn_no)
    {
        string Address1 = "";

        if (Notn_no != "")
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            Auto.Ename = "NOTIFICATION_EXCISE_MASTER_CETH_NOTN_SLNO_IGST_1E";
            Auto.Enamesearch = Notn_no_sl;
            Auto.Notn_No_Search = Notn_no;

            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {
                Address1 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_RATE"].ToString();
            }
        }
        Notn_no_sl = Address1;
        return Notn_no_sl;
    }

    //[System.Web.Services.WebMethod]
    public static string Ser_Port_of_orgin(string custid, string custid_2)
    {
        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();

        Auto.Enamesearch = custid;
        if (custid_2 == "Air")
        {
            Auto.Notn_No_Search = "3";
        }
        else if (custid_2 == "Sea" || custid_2 == "Land")
        {
            Auto.Notn_No_Search = "5";
        }

        Auto.Ename = "IMP_EXP_Port_of_orgin_Chk";
        ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

        if (ds.Tables[0].Rows.Count > 0)
        {
            custid = "Yes";
        }
        else
        {
            string flag = "";
            if (custid_2 == "Air")
            {
                flag = "PORT_MASTER_USER_WISE_LIST_AIR_general";
            }
            else
            {
                flag = "PORT_MASTER_USER_WISE_LIST_SEA_LAND_general";
            }
            Auto.Ename = flag;
            Auto.Enamesearch = custid;
            Auto.NSearch = "";

            ds.Clear();
            ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {
                custid = "Yes";
            }
            else
            {
                custid = "No";

                if (custid_2 == "Land")//for SEZ
                {
                    Auto.Notn_No_Search = "6";
                    Auto.Ename = "IMP_EXP_Port_of_orgin_Chk";
                    ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        custid = "Yes";
                    }
                    else
                    {
                        custid = "No";
                    }
                }
            }
        }

        return custid;
    }

    protected void ExcelDwnl_Click(object sender, ImageClickEventArgs e)
    {
        con.Open();
        SqlCommand Exlcmd = new SqlCommand("select PDF_JOB_NO as 'JOB NO',PDF_EXP_IMP_NAME as 'EXP IMP NAME',PDF_MODE as MODE,PDF_UPLOAD_COUNT as 'UPLOAD COUNT',PDF_SAVE_COUNT as 'SAVE COUNT',PDF_REMARKS as 'PAGE COUNT',PDF_USER_ID as 'USER',PDF_DATE_TIME as 'DATE TIME',PDF_BRANCH_CODE as 'BRANCH CODE',PDF_WORKING_PERIOD as 'WORKING PERIOD' from PDF_AI_COUNT_DETAILS where PDF_MODE = 'ICH'", con);
        SqlDataAdapter Exlsda = new SqlDataAdapter(Exlcmd);
        DataSet ExlSds = new DataSet();
        Exlsda.Fill(ExlSds);
        con.Close();

        if (ExlSds.Tables[0].Rows.Count > 0)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {
                foreach (DataTable dt in ExlSds.Tables)
                {
                    wb.Worksheets.Add(dt, "AI_JOB_STATUS");
                }

                using (MemoryStream ms = new MemoryStream())
                {
                    wb.SaveAs(ms);
                    ms.Position = 0;

                    // Send file to browser
                    Response.Clear();
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=PDF_AI_CountDetails" + "_" + DateTime.Now + ".xlsx");
                    Response.BinaryWrite(ms.ToArray());
                    Response.End();
                }
            }
        }
        else
        {
            Alert_msg("No AI JOB Record...!");
        }
    }

    [System.Web.Services.WebMethod]
    public static object GetAIDCDetails(string ritcNo)
    {
        var adm = new adminmaster();
        adm.AIDC_RITC_NO = ritcNo;
        adm.Ename = "ITEM_RITC";

        var ds = adm.Get_AIDC_CESS_SELECT();
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            return new
            {
                AIDC_NOTN_NO = ds.Tables[0].Rows[0]["AIDC_NOTN_NO"].ToString(),
                AIDC_NOTN_SLNO = ds.Tables[0].Rows[0]["AIDC_NOTN_SLNO"].ToString(),
                AIDC_NOTN_RATE = ds.Tables[0].Rows[0]["AIDC_NOTN_RATE"].ToString()
            };
        }
        else
        {
            return null; // frontend will handle default values
        }
    }

    [System.Web.Services.WebMethod]
    public static object GetIGSTDetails(string ritcNo)
    {
        Auto_Search Auto = new Auto_Search();
        Auto.Ename = "Get_IGST_NOTN_SLNO_RITC_V2";
        Auto.Enamesearch = ritcNo;
        Auto.Notn_No_Search = ritcNo;

        var ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH_PART_II();
        if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
        {
            return new
            {
                LEVY_1NOTIFICATION = ds.Tables[1].Rows[0]["LEVY_1NOTIFICATION"].ToString(),
                LEVY_1NOTIFICATION_SLNO = ds.Tables[1].Rows[0]["LEVY_1NOTIFICATION_SLNO"].ToString(),
                LEVY_1NOTIFICATION_RATE = ds.Tables[1].Rows[0]["LEVY_1NOTIFICATION_RATE"].ToString()
            };
        }
        return null;
    }
}