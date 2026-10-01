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
using System.Configuration;
using System.Web.Script.Serialization;
using System.Collections.Specialized;
using System.Net;
using Newtonsoft.Json.Linq;
//using System.Net.Http.Headers;
using System.Globalization;
using ClosedXML.Excel;
using iTextSharp.text.pdf;
using System.Collections;
using ClosedXML.Excel;



public partial class Import_Excel_Reader : ThemeClass
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

    DataSet ds_ExcelDt = new DataSet();
    DataSet ds_IEC = new DataSet();
    DataSet ds_draw = new DataSet();
    DataSet GetLocalAPIData = new DataSet();
    DataSet ds_API = new DataSet();
    DataSet ds_OrderDetails = null;

    public String Xml_Inv;

    public int MAX_ID = 0; int i = 0; int rowIndex = 0; int result = 0; int INVOICE_SLNO = 0; decimal Sum_of_Quantity_Rate = 0;

    public string GENERAL_IMPORT_JOBNO = "", TRANSPORT_MODE = "";
    public string currentuser;
    public int totalItemSlNo = 1;
    public string currentbranch;
    public string Working_Period;
    public string COMPANY_IDD, comp_ConnectionStr, LoginDate, SELECT_BRANCH, SB_TYPE, JOBNO;
    public string a1 = "", a2 = "", a3 = "", a4 = "", a5 = "", a6 = "";
    string PdfClientName = "";
    string ds_lkupDetails = string.Empty;
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
        catch (Exception ex)
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
            if (COMPANY_IDD == "576" || COMPANY_IDD == "584")
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
            string savePath = Server.MapPath("~/Submission/ImportExcelReader/");
            if (Directory.Exists(savePath) == false)
            {
                Directory.CreateDirectory(savePath);
            }
            if (Request.Files.Count > 0 && Request.Files.Count <= 5)
            {
                int FileUploadCount = Request.Files.Count;
                ViewState["FileUploadCount"] = FileUploadCount;

                for (int j = 0; j < Request.Files.Count; j++)
                {
                    HttpPostedFile uploadedFile = Request.Files[j]; // Access file by index

                    if (uploadedFile != null && uploadedFile.ContentLength > 0)
                    {
                        strFolderPath = Path.Combine(Request.PhysicalApplicationPath, savePath);
                        strImagePath = Path.Combine(strFolderPath, uploadedFile.FileName.ToString());
                        uploadedFile.SaveAs(strImagePath);

                        if (Path.GetExtension(strImagePath).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
                        {
                            int pageCount = 0;
                        }
                    }

                    using (var workbook = new XLWorkbook(strImagePath))
                    {
                        ds_ExcelDt.Tables.Clear();

                        foreach (var worksheet in workbook.Worksheets)
                        {
                            if (worksheet.Name.Equals("Macro1", StringComparison.OrdinalIgnoreCase))
                                continue;

                            if (worksheet.Visibility == XLWorksheetVisibility.Hidden || worksheet.IsEmpty())
                                continue;

                            DataTable sheetData = new DataTable();
                            sheetData.TableName = worksheet.Name;
                            int maxColumns = 0;

                            foreach (var row in worksheet.RowsUsed())
                            {
                                var lastCell = row.LastCellUsed();
                                if (lastCell != null)
                                    maxColumns = Math.Max(maxColumns, lastCell.Address.ColumnNumber);
                            }

                            for (int i = 1; i <= maxColumns; i++)
                            {
                                sheetData.Columns.Add("Column" + i);
                            }

                            foreach (var row in worksheet.RowsUsed())
                            {
                                DataRow dr = sheetData.NewRow();

                                for (int i = 1; i <= maxColumns; i++)
                                {
                                    var cell = row.Cell(i);
                                    string cellText = string.Empty;

                                    try
                                    {
                                        cellText = cell.IsEmpty() ? "" : cell.Value.ToString();                                       
                                        cellText = Regex.Replace(cellText, @"[\u2460-\u24FF]", "");
                                        // cellText = Regex.Replace(cellText, @"[^\u0000-\u007F]", "");
                                        cellText = cellText.Trim();
                                    }
                                    catch
                                    {
                                        cellText = "";
                                    }

                                    dr[i - 1] = cellText;
                                }
                                bool allEmpty = true;

                                foreach (var item in dr.ItemArray)
                                {
                                    if (!string.IsNullOrWhiteSpace(item.ToString()))
                                    {
                                        allEmpty = false;
                                        break;
                                    }
                                }
                                if (!allEmpty)
                                    sheetData.Rows.Add(dr);
                            }
                            ds_ExcelDt.Tables.Add(sheetData);
                        }
                    }

                    string imp_name = "", branch_slno = "", Info_Uqc = "", Info_Msr = "", IEC = "", AIDC_CessRate = "", AIDC_CessNoti = "", AIDC_CessSlno = "", IGST_Noti = "",
                        IGST_SlNo = "", IGST_Rate = "", IGST_LEVY_COMPENSATION_CESS_NOTN = "", IGST_LEVY_COMPENSATION_CESS_SLNO = "", IGST_LEVY_COMPENSATION_CESS_RATE = "", PurchaseOrderNo = "", PurchaseOrderDate = "", MANUFACTURER = "", Condition_Desc = "", PRODUCT_END_USE = "";
                    if (ddl_ImporterName.SelectedValue.Contains("--"))
                    {
                        string[] sp = ddl_ImporterName.SelectedValue.Replace("--", "^").Split('^');
                        branch_slno = sp[0];
                        imp_name = sp[1];

                        ViewState["branch_slno"] = branch_slno;
                        ViewState["imp_name"] = imp_name;
                        Session["imp_name"] = imp_name;
                    }
                    if (ds_ExcelDt != null)
                    {
                        ds_API = getCustInvDetls_Excel_Datatable(imp_name, strImagePath, ds_ExcelDt);
                    }

                    if (ds_API.Tables[0].Rows.Count > 0 && ds_API.Tables[1].Rows.Count > 0)
                        if (ds_API.Tables[0].Rows.Count > 0 && ds_API.Tables[1].Rows.Count > 0 && ds_API.Tables[2].Rows.Count > 0)
                        {
                            txtSupplier.Text = ds_API.Tables[1].Rows[0]["SupplierName"].ToString().Replace("Ä", "A");
                            hd_Supplier.Value = txtSupplier.Text;
                            txtCountryOfOrigin.Text = ds_API.Tables[0].Rows[0]["CountryOfOrigin"].ToString();
                            if (!string.IsNullOrWhiteSpace(txtCountryOfOrigin.Text))
                            {
                                Auto_Search Auto = new Auto_Search();
                                Auto.Ename = "COUNTRY_MASTER";
                                Auto.Enamesearch = txtCountryOfOrigin.Text;

                                DataSet ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

                                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                {
                                    txtCountryOfOrigin.Text = ds.Tables[0].Rows[0]["COUNTRY_NAME"].ToString();

                                    txtCountryOfOrigin.Text = txtCountryOfOrigin.Text.Contains('-')
                                        ? txtCountryOfOrigin.Text.Split('-')[0].Trim()
                                        : txtCountryOfOrigin.Text;
                                }
                            }
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
                                Dt_Item.Columns.Add("MANUFACTURER");
                                Dt_Item.Columns.Add("END_USE_OF_ITEM");
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
                                    ddlTerms.Text = TERMS1.Replace("FCA", "FOB").Replace("CIP", "CIF").Replace("CPT", "CF").Replace("C. I. F", "CIF").Replace("C & F", "CIF").Replace("CFR", "CF").Replace("DAP", "CIF");
                                }
                                catch
                                {
                                    ddlTerms.Text = "FOB";
                                }
                                if (ds_API.Tables[1].Rows[ak]["InvoiceValue"].ToString() != "" && ds_API.Tables[1].Rows[ak]["InvoiceValue"].ToString() != null)
                                {
                                    if (imp_name == "Atlas Copco (India) Private limited")
                                    {
                                        txtInvValue.Text = ds_API.Tables[1].Rows[ak]["InvoiceValue"].ToString().Replace(".", "").Replace(",", ".").Replace("'", "");
                                    }
                                    else
                                    {
                                        txtInvValue.Text = ds_API.Tables[1].Rows[ak]["InvoiceValue"].ToString().Replace(",", "").Replace("¥", "").Replace("'", "");
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

                            if (COMPANY_IDD == "876" || COMPANY_IDD == "427" || COMPANY_IDD == "1108" || COMPANY_IDD == "10")
                            {
                                string MBLNo = "";
                                string MBLDate = "";
                                if (MBLDate != "" && MBLDate != null)
                                {
                                    MBLDate = Get_Valid_Date(ds_API.Tables[3].Rows[0]["MBLDate"].ToString());
                                }
                                string HBLNo = "";
                                string HBLDate = "";
                                if (HBLDate != "" && HBLDate != null)
                                {
                                    HBLDate = Get_Valid_Date(ds_API.Tables[3].Rows[0]["HBLDate"].ToString());
                                }
                                string IGM_NOOFPACKAGE = ds_API.Tables[0].Rows[0]["TotalCarton"].ToString().Replace(",", "");
                                string IGM_GROSSWEIGHT = ds_API.Tables[0].Rows[0]["TotalGrossWeight"].ToString().Replace(",", "");

                                dt_Temp_IGM.Rows.Add(MBLNo, MBLDate, HBLNo, HBLDate, IGM_NOOFPACKAGE, IGM_GROSSWEIGHT);
                                ViewState["dt_IGMDetails"] = dt_Temp_IGM;


                                for (int ka = 0; ka <= 1 - 1; ka++)
                                {
                                    string Containerslno = "";
                                    string ContainerNo = "";
                                    string ContainerSealNo = "";
                                    string ContainerSize = "";
                                    if ((ContainerNo != "" || ContainerNo != "") && Containerslno != "")
                                    {
                                        dt_Temp_Con.Rows.Add(ContainerNo, ContainerSealNo, ContainerSize);
                                    }

                                    ViewState["dt_ContainerDetails"] = dt_Temp_Con;
                                }
                            }

                            totalItemSlNo = ds_API.Tables[2].Rows.Count;


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
                                string ExtraItemDesc = ds_API.Tables[2].Rows[i]["ExtraItemDesc"].ToString();
                                string Quantity = ds_API.Tables[2].Rows[i]["Quantity"].ToString().Replace(" ", "");
                                string Rate = ds_API.Tables[2].Rows[i]["Rate"].ToString().Replace(" ", "");
                                string Amount = ds_API.Tables[2].Rows[i]["Amount"].ToString().Replace(" ", "").Replace("'", "");
                                string PartNo = ds_API.Tables[2].Rows[i]["PartNo"].ToString();
                                string PONumber = ds_API.Tables[2].Rows[i]["PONumber"].ToString();
                                string NetWeight = ds_API.Tables[2].Rows[i]["ItemNETWEIGHT"].ToString().Replace(" ", "");
                                MANUFACTURER = txtSupplier.Text.ToUpper().Trim();
                                string HSCode = ds_API.Tables[2].Rows[i]["ItemHSCODE"].ToString().Replace(".", "").Replace(" ", "").Replace("null", "").Trim();
                                if (HSCode.Length > 8)
                                {
                                    string substring = HSCode.Substring(0, 8);
                                    HSCode = substring;
                                }
                                var rawCountry = ds_API.Tables[2].Rows[i]["ItemCountry"];
                                string ItemCountry = rawCountry == DBNull.Value ? string.Empty : rawCountry.ToString().Replace("null", "").Trim();

                                if (!string.IsNullOrWhiteSpace(ItemCountry))
                                {
                                    Auto_Search Auto = new Auto_Search();
                                    Auto.Ename = (ItemCountry.Length == 2) ? "Get_CountryName" : "COUNTRY_MASTER";
                                    Auto.Enamesearch = ItemCountry;

                                    DataSet ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

                                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                    {
                                        ItemCountry = ds.Tables[0].Rows[0]["COUNTRY_NAME"].ToString();

                                        ItemCountry = ItemCountry.Contains('-')
                                            ? ItemCountry.Split('-')[0].Trim()
                                            : ItemCountry;
                                    }
                                }





                                QTYCode = ds_API.Tables[1].Rows[0]["QtyCode"].ToString();


                                if (string.IsNullOrEmpty(QTYCode))
                                {
                                    QTYCode = "NOS";
                                }

                                if (COMPANY_IDD == "427")
                                {
                                    //decimal Calc_Quantity = Convert.ToDecimal(Amount.Replace(",", "").Replace(" ", "")) * Convert.ToDecimal(Quantity.Replace(",", "").Replace(" ", ""));
                                    //Quantity = Calc_Quantity.ToString("N6").Replace(",", "");

                                    decimal Calc_Amount = Convert.ToDecimal(Rate.Replace(",", "").Replace(" ", "")) * Convert.ToDecimal(Quantity.Replace(",", "").Replace(" ", ""));
                                    Amount = Calc_Amount.ToString("N6").Replace(",", "");
                                }
                                //else if (COMPANY_IDD == "207")
                                //{
                                //    PartNumber = PartNo;
                                //}
                                if (COMPANY_IDD == "207")
                                {
                                    ItemDesc = ItemDesc + " - PART NO. " + PartNo;
                                }

                                DataSet ds_get_data = new DataSet();
                                erm.Eproduct_imp_ceth = imp_name;
                                erm.Eproduct_imp_description = ItemDesc;
                                erm.EWorking_Period = Working_Period;
                                erm.Ename = "Get_Master_Data_Excel";
                                ds_get_data = erm.RetrieveAll_Import_PDF_Settings_MASTER();

                                if (ds_get_data.Tables[0].Rows.Count > 0)
                                {

                                    string Basic_Noti = ds_get_data.Tables[0].Rows[0]["PRODUCT_BCD_NOTN"].ToString();
                                    string Basic_Slno = ds_get_data.Tables[0].Rows[0]["PRODUCT_BCD_SLNO"].ToString();
                                    string Basic_Rate = ds_get_data.Tables[0].Rows[0]["PRODUCT_BCD_RATE"].ToString();
                                    string itemCountyof_orgin = ds_get_data.Tables[0].Rows[0]["PRODUCT_COUNTRY_ORIGIN"].ToString();
                                    string SW_Noti = ds_get_data.Tables[0].Rows[0]["SOCIAL_WELFARE_NOTN"].ToString();
                                    string SW_Slno = ds_get_data.Tables[0].Rows[0]["SOCIAL_WELFARE_NOTN_SLNO"].ToString();
                                    string SW_Rate = ds_get_data.Tables[0].Rows[0]["SOCIAL_WELFARE_RATE"].ToString();
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

                                    Info_Uqc = Get_Valid_Qty_Code(QTYCode);
                                    if (NetWeight != "" && NetWeight != null)
                                    {
                                        Info_Msr = NetWeight.ToString().Replace(",", "");
                                    }

                                    if (itemCountyof_orgin == "" || itemCountyof_orgin == string.Empty || itemCountyof_orgin == null)
                                    {
                                        itemCountyof_orgin = ItemCountry;
                                    }
                                    PRODUCT_END_USE = ds_get_data.Tables[0].Rows[0]["PRODUCT_END_USE"].ToString();
                                    //if (COMPANY_IDD == "207")
                                    //{
                                    //    ItemDesc = ItemDesc + " - PART NO. " + PartNumber;
                                    //}

                                    if (!string.IsNullOrEmpty(HSCode) && (string.IsNullOrEmpty(AIDC_CessRate) || string.IsNullOrEmpty(IGST_Rate)))
                                    {
                                        try
                                        {
                                            if (string.IsNullOrEmpty(AIDC_CessRate))
                                            {
                                                DataSet ds_AIDC = new DataSet();
                                                adm.AIDC_RITC_NO = HSCode;
                                                adm.Ename = "ITEM_RITC";
                                                ds_AIDC = adm.Get_AIDC_CESS_SELECT();
                                                if (ds_AIDC.Tables[0].Rows.Count > 0)
                                                {
                                                    AIDC_CessRate = ds_AIDC.Tables[0].Rows[0]["AIDC_NOTN_RATE"].ToString();
                                                }
                                                else
                                                {
                                                    AIDC_CessRate = "0.00";
                                                }
                                            }
                                            if (!string.IsNullOrEmpty(IGST_Noti) && !string.IsNullOrEmpty(IGST_SlNo))
                                            {
                                                Auto_Search Auto = new Auto_Search();
                                                DataSet ds = new DataSet();
                                                Auto.Ename = "NOTIFICATION_EXCISE_MASTER_CETH_NOTN_SLNO_IGST_1E";
                                                Auto.Enamesearch = IGST_SlNo;
                                                Auto.Notn_No_Search = IGST_Noti;

                                                ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
                                                if (ds.Tables[0].Rows.Count > 0)
                                                {
                                                    IGST_Rate = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_RATE"].ToString();
                                                }
                                                if (!string.IsNullOrEmpty(IGST_LEVY_COMPENSATION_CESS_NOTN) && !string.IsNullOrEmpty(IGST_LEVY_COMPENSATION_CESS_SLNO))
                                                {
                                                    IGST_LEVY_COMPENSATION_CESS_RATE = "0.00";
                                                }
                                            }
                                            if (!string.IsNullOrEmpty(Basic_Slno) && !string.IsNullOrEmpty(Basic_Noti))
                                            {
                                                Auto_Search Auto = new Auto_Search();
                                                DataSet ds = new DataSet();
                                                Auto.Ename = "NOTIFICATIONCUSTOM_MASTER_ALL_CTH_NOTN_SLNO";
                                                Auto.Enamesearch = Basic_Slno;
                                                Auto.Notn_No_Search = Basic_Noti;

                                                ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
                                                if (ds.Tables[0].Rows.Count > 0)
                                                {
                                                    Basic_Rate = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_RATE"].ToString();
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {

                                        }

                                    }





                                    Dt_Item.Rows.Add(ItemInvoiceSlNo, ItemSlNo, ItemDesc.Trim(), Quantity.Replace(",", ""), Rate.Replace(",", ""), Amount.Replace(",", ""),
                                        Get_Valid_Qty_Code(QTYCode), HSCode, "00 - DUTIABLE", "", "", Basic_Noti, Basic_Slno, Basic_Rate, Info_Msr, Info_Uqc, MANUFACTURER, PRODUCT_END_USE, itemCountyof_orgin,
                                        SW_Noti, SW_Slno, SW_Rate, AIDC_CessNoti, AIDC_CessSlno, AIDC_CessRate, IGST_Noti, IGST_SlNo, IGST_Rate, PartNo, IGST_LEVY_COMPENSATION_CESS_NOTN, IGST_LEVY_COMPENSATION_CESS_SLNO, IGST_LEVY_COMPENSATION_CESS_RATE);
                                }
                                else
                                {
                                    Info_Uqc = Get_Valid_Qty_Code(QTYCode);
                                    if (NetWeight != "" && NetWeight != null)
                                    {
                                        Info_Msr = NetWeight.ToString().Replace(",", "");
                                    }

                                    if (HSCode != "" && HSCode != string.Empty)
                                    {
                                        try
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

                                            DataSet ds_IGST = new DataSet();
                                            //Auto.Ename = "Get_IGST_NOTN_SLNO_RITC";
                                            Auto.Ename = "Get_IGST_NOTN_SLNO_RITC_V2";
                                            Auto.Enamesearch = HSCode;
                                            Auto.Notn_No_Search = HSCode;

                                            //ds_IGST = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
                                            ds_IGST = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH_PART_II();
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
                                        catch (Exception ex)
                                        {
                                        }
                                    }
                                    //if (COMPANY_IDD == "207")
                                    //{
                                    //    ItemDesc = ItemDesc + " - PART NO. " + PartNumber;
                                    //}

                                    Dt_Item.Rows.Add(ItemInvoiceSlNo, ItemSlNo, ItemDesc, Quantity.Replace(",", ""), Rate.Replace(",", ""), Amount.Replace(",", ""),
                                        Get_Valid_Qty_Code(QTYCode), HSCode, "00 - DUTIABLE", "", "", "", "", "", Info_Msr, Info_Uqc, MANUFACTURER, PRODUCT_END_USE, ItemCountry,
                                        "", "", "", AIDC_CessNoti, AIDC_CessSlno, AIDC_CessRate, IGST_Noti, IGST_SlNo, IGST_Rate, PartNo, IGST_LEVY_COMPENSATION_CESS_NOTN, IGST_LEVY_COMPENSATION_CESS_SLNO, IGST_LEVY_COMPENSATION_CESS_RATE);
                                }
                                HSCode = ""; AIDC_CessNoti = ""; AIDC_CessSlno = ""; AIDC_CessRate = ""; IGST_Noti = ""; IGST_SlNo = ""; IGST_Rate = ""; IGST_LEVY_COMPENSATION_CESS_NOTN = ""; IGST_LEVY_COMPENSATION_CESS_SLNO = ""; IGST_LEVY_COMPENSATION_CESS_RATE = ""; MANUFACTURER = ""; Info_Msr = ""; QTYCode = ""; PRODUCT_END_USE = "";
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

                    //int totalItemSlNoo=0;
                    gv_ItemPDF.DataBind();
                    //totalItemSlNumber = ds_API.Tables[2].Rows.Count;

                    totalItemSlNo = (totalItemSlNo <= 20) ? 1 : (totalItemSlNo / 20) + ((totalItemSlNo % 20 >= 1) ? 1 : 0);
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
                              "Update PDF_AI_COUNT_DETAILS set PDF_UPLOAD_COUNT=('" + PDF_UPLOAD_COUNT + "'+1),PDF_REMARKS= PDF_REMARKS + " + totalItemSlNo + ",PDF_USER_ID='" + currentuser + "',PDF_DATE_TIME=GetDate()," +
                        "PDF_STATUS='S',PDF_BRANCH_CODE='" + currentbranch + "',PDF_WORKING_PERIOD='" + Working_Period + "' where PDF_ID=" + PDF_ID + "", con);
                        int result = Ucmd.ExecuteNonQuery();
                    }
                    else
                    {

                        SqlCommand cmd =
                            new SqlCommand(
                                "insert into PDF_AI_COUNT_DETAILS(PDF_JOB_NO,PDF_EXP_IMP_NAME,PDF_MODE,PDF_UPLOAD_COUNT,PDF_REMARKS,PDF_USER_ID,PDF_DATE_TIME,PDF_STATUS,PDF_BRANCH_CODE,PDF_WORKING_PERIOD) values('" + txtjobPS.Text + "','" +
                                imp_name + "','EXI','1','" + totalItemSlNo + "','" + currentuser + "',GetDate(),'S','" + currentbranch + "','" + Working_Period + "')", con);
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



    public DataSet getCustInvDetls_Excel_Datatable(string custname, string filePath, DataSet ds)
    {
        DataSet datasetinvoice = new DataSet();
        try
        {
            string InvType = "S";
            PDFReader clsReadPDF = new PDFReader();

            System.Data.DataTable htable = new System.Data.DataTable();
            System.Data.DataTable dtable = new System.Data.DataTable();
            System.Data.DataTable Atable = new System.Data.DataTable();
            System.Data.DataTable invtable = new System.Data.DataTable();

            getlkupval(custname, InvType);

            if (ds_OrderDetails != null && ds_lkupDetails != string.Empty)
            {
                if (ds_OrderDetails.Tables.Count > 0)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    Dictionary<string, object> dict = serializer.Deserialize<Dictionary<string, object>>(ds_lkupDetails);

                    System.Data.DataTable dthearder = ds_OrderDetails.Tables["Header"];
                    if (dthearder.Columns.Count > 0)
                    {
                        htable = readHeaderPDFval(custname, "Header", dict, ds, InvType);
                        datasetinvoice.Tables.Add(htable);
                    }
                    System.Data.DataTable dtinvoice = ds_OrderDetails.Tables["InvoiceDetails"];
                    if (dtinvoice.Columns.Count > 0)
                    {
                        invtable = readinvoDetailPDFval(custname, "InvoiceDetails", dict, ds, InvType);
                        datasetinvoice.Tables.Add(invtable);
                    }

                    System.Data.DataTable dtdetail = ds_OrderDetails.Tables["Details"];
                    if (dtdetail.Columns.Count > 0)
                    {
                        dtable = readDetailPDFval(custname, "Details", dict, ds, InvType);
                        datasetinvoice.Tables.Add(dtable);
                    }




                    ds_OrderDetails.AcceptChanges();
                }
            }
            else
            {
            }
        }
        catch (Exception ex)
        {
            datasetinvoice = null;
        }
        finally
        {

        }
        return datasetinvoice;
    }

    public DataTable readinvoDetailPDFval(string custname, string dataTo, Dictionary<string, object> dictheader, DataSet ds, string InvType)
    {
        DataTable dtInvoice = new DataTable();

        if (ds == null || ds.Tables.Count == 0)
            return dtInvoice;

        ArrayList dictheaders = (ArrayList)dictheader[dataTo];
        Dictionary<string, object> KeyMapping =
            (Dictionary<string, object>)dictheaders[0];

        // Create columns
        foreach (var kv in KeyMapping)
            dtInvoice.Columns.Add(kv.Key);

        int invoiceSlNo = 1;

        // 🔥 SINGLE invoice row 
        DataRow singleInvoiceRow = null;
        if (COMPANY_IDD == "876" || COMPANY_IDD == "427" || COMPANY_IDD == "207")
        {
            singleInvoiceRow = dtInvoice.NewRow();
            singleInvoiceRow["InvoiceSlNo"] = invoiceSlNo;
        }

        foreach (DataTable sheet in ds.Tables)
        {
            // ---------------- SINGLE INVOICE ----------------
            if (COMPANY_IDD == "876" || COMPANY_IDD == "427" || COMPANY_IDD == "207")
            {
                foreach (var kv in KeyMapping)
                {
                    string key = kv.Key;

                    if (key.Equals("InvoiceSlNo", StringComparison.OrdinalIgnoreCase))
                        continue;

                    // ✅ Skip if already filled
                    if (!string.IsNullOrWhiteSpace(Convert.ToString(singleInvoiceRow[key])))
                        continue;

                    ArrayList mappingArr = (ArrayList)KeyMapping[key];
                    Dictionary<string, object> mapping =
                        (Dictionary<string, object>)mappingArr[0];

                    string searchColumn = mapping["column"].ToString();
                    string pos = mapping["Position"].ToString();
                    string colPos = mapping["Col_Pos"].ToString();
                    string split = mapping.ContainsKey("split") ? mapping["split"].ToString() : "";
                    string reverse = mapping.ContainsKey("Reverse") ? mapping["Reverse"].ToString() : "";
                    string valueIndex = mapping.ContainsKey("Value")
                    ? mapping["Value"].ToString()
                    : "0";

                    string extractedValue =
                        GetValueFromSheet(sheet, searchColumn, pos, colPos, split, reverse, valueIndex);

                    if (!string.IsNullOrWhiteSpace(extractedValue))
                        singleInvoiceRow[key] = extractedValue;
                }
            }
            // ---------------- MULTIPLE INVOICE ----------------
            else
            {
                DataRow newRow = dtInvoice.NewRow();

                foreach (var kv in KeyMapping)
                {
                    string key = kv.Key;

                    if (key.Equals("InvoiceSlNo", StringComparison.OrdinalIgnoreCase))
                    {
                        newRow[key] = invoiceSlNo;
                        continue;
                    }

                    ArrayList mappingArr = (ArrayList)KeyMapping[key];
                    Dictionary<string, object> mapping =
                        (Dictionary<string, object>)mappingArr[0];

                    string searchColumn = mapping["column"].ToString();
                    string pos = mapping["Position"].ToString();
                    string colPos = mapping["Col_Pos"].ToString();
                    string split = mapping.ContainsKey("split") ? mapping["split"].ToString() : "";
                    string reverse = mapping.ContainsKey("Reverse") ? mapping["Reverse"].ToString() : "";
                    string valueIndex = mapping.ContainsKey("Value")
                    ? mapping["Value"].ToString()
                    : "0";

                    newRow[key] =
                        GetValueFromSheet(sheet, searchColumn, pos, colPos, split, reverse, valueIndex);
                }

                dtInvoice.Rows.Add(newRow);
                invoiceSlNo++;
            }
        }

        // 🔥 Add single invoice row ONCE
        if (COMPANY_IDD == "876" || COMPANY_IDD == "427" || COMPANY_IDD == "207")
            dtInvoice.Rows.Add(singleInvoiceRow);

        return dtInvoice;
    }


    private string GetValueFromSheet(DataTable sheet, string searchColumn, string pos, string colPos, string split, string reverse, string valueIndex)
    {
        if (string.IsNullOrWhiteSpace(searchColumn))
            return "";
        int rp = Convert.ToInt32(pos);
        int cp = Convert.ToInt32(colPos);

        for (int r = 0; r < sheet.Rows.Count; r++)
        {
            for (int c = 0; c < sheet.Columns.Count; c++)
            {
                string cell = sheet.Rows[r][c].ToString().Trim();

                if (cell.Equals(searchColumn, StringComparison.OrdinalIgnoreCase))
                {
                    int r2 = reverse == "Y" ? r - rp : r + rp;
                    //int r2 = r + rp;
                    int c2 = reverse == "Y" ? cp - c : c + cp;

                    if (r2 < 0 || c2 < 0 ||
                        r2 >= sheet.Rows.Count ||
                        c2 >= sheet.Columns.Count)
                        return "";

                    string value = sheet.Rows[r2][c2].ToString().Trim();

                    // 🔥 SPLIT LOGIC
                    if (!string.IsNullOrEmpty(split) && value.Contains(split))
                    {

                        //string[] parts = value.Split(new string[] { split },
                        //                              StringSplitOptions.None);

                        //// Value index from JSON
                        //int index = 0;
                        //if (int.TryParse("1", out index) && index < parts.Length)
                        //    return parts[index].Trim();

                        string[] parts;


                        if (split == " ")
                        {
                            parts = value.Split(
                                new[] { ' ' },
                                StringSplitOptions.RemoveEmptyEntries);
                        }
                        else
                        {
                            parts = value.Split(
                                new string[] { split },
                                StringSplitOptions.None);
                        }

                        int index = 0;
                        if (int.TryParse(valueIndex, out index) &&
                            index >= 0 && index < parts.Length)
                        {
                            return parts[index].Trim();
                        }
                    }

                    return value;
                }
            }
        }

        return "";
    }




    public DataTable readDetailPDFval(string custname, string dataTo, Dictionary<string, object> dictheader, DataSet ds, string InvType)
    {
        // ----------- PART 1: Extract Item Table (dtItems) ----------
        DataTable dtItems = new DataTable();
        bool columnsCreated = false;

        int invoiceSlNo = 1;   // For each sheet
        int tblIndex = 0;

        foreach (DataTable sheet in ds.Tables)
        {
            // 🔴 COMPANY_IDD = 10 → only process DataTable[1]
            if (COMPANY_IDD == "207" && tblIndex != 1)
            {
                tblIndex++;
                continue;
            }

            if (sheet.Rows.Count == 0)
            {
                tblIndex++;
                continue;
            }

            // ---------- STEP 1 : Read "start" from JSON ----------
            string startHeaderName = "";
            try
            {
                ArrayList dictDetails = (ArrayList)dictheader[dataTo];
                Dictionary<string, object> detailsMap = (Dictionary<string, object>)dictDetails[0];

                ArrayList rangeArr = (ArrayList)detailsMap["range"];
                Dictionary<string, object> rangeObj = (Dictionary<string, object>)rangeArr[0];

                startHeaderName = rangeObj["start"].ToString().Trim();
            }
            catch { }

            // ---------- STEP 2 : Find Header Row ----------
            int headerRowIndex = -1;

            for (int r = 0; r < sheet.Rows.Count; r++)
            {
                for (int c = 0; c < sheet.Columns.Count; c++)
                {
                    string cell = "";
                    try { cell = sheet.Rows[r][c].ToString().Trim(); }
                    catch { }

                    if (cell != "" &&
                        cell.Equals(startHeaderName, StringComparison.OrdinalIgnoreCase))
                    {
                        headerRowIndex = r;
                        break;
                    }
                }
                if (headerRowIndex != -1)
                    break;
            }

            if (headerRowIndex == -1)
                continue;

            // ---------- STEP 3 : Find START column index ----------
            int startColIndex = -1;

            for (int c = 0; c < sheet.Columns.Count; c++)
            {
                string headerCell = "";
                try { headerCell = sheet.Rows[headerRowIndex][c].ToString().Trim(); }
                catch { }

                if (headerCell.Equals(startHeaderName, StringComparison.OrdinalIgnoreCase))
                {
                    startColIndex = c;
                    break;
                }
            }

            if (startColIndex == -1)
                continue;

            // ---------- STEP 4 : Create columns only once ----------
            if (!columnsCreated)
            {
                for (int c = startColIndex; c < sheet.Columns.Count; c++)
                {
                    string colName = "";
                    try { colName = sheet.Rows[headerRowIndex][c].ToString().Trim(); }
                    catch { }

                    if (colName == "") colName = "Col" + c;

                    if (!dtItems.Columns.Contains(colName))
                        dtItems.Columns.Add(colName);
                }

                dtItems.Columns.Add("InvoiceSlNo");
                dtItems.Columns.Add("ItemSlNo");

                columnsCreated = true;
            }

            // ---------- STEP 5 : Extract item rows ----------
            int itemSlNo = 1;

            for (int r = headerRowIndex + 1; r < sheet.Rows.Count; r++)
            {
                int emptyCount = 0;
                bool stop = false;

                // 🔥 Check empty cells ONLY from startColIndex
                for (int c = startColIndex; c < sheet.Columns.Count; c++)
                {
                    string cellVal = "";
                    try { cellVal = sheet.Rows[r][c].ToString().Trim(); }
                    catch { }

                    if (string.IsNullOrWhiteSpace(cellVal))
                    {
                        emptyCount++;

                        // 🔴 Stop immediately when 3 consecutive empty cells appear
                        if (emptyCount >= 3)
                        {
                            stop = true;
                            break;
                        }
                    }
                    else
                    {
                        emptyCount = 0; // reset when value found
                    }
                }

                // 🔴 Break item-row loop
                if (stop)
                    break;

                // ---------- Create item row ----------
                DataRow newRow = dtItems.NewRow();
                int targetIndex = 0;

                for (int c = startColIndex; c < sheet.Columns.Count; c++)
                {
                    string val = "";
                    try { val = sheet.Rows[r][c].ToString().Trim(); }
                    catch { }

                    newRow[targetIndex++] = val;
                }

                newRow["InvoiceSlNo"] = invoiceSlNo;
                newRow["ItemSlNo"] = itemSlNo++;

                dtItems.Rows.Add(newRow);
            }

            invoiceSlNo++;
            tblIndex++;
        }
        if (COMPANY_IDD == "876" || COMPANY_IDD == "427")
        {
            if (ds.Tables.Count > 1)
            {
                DataTable dtPacking = ds.Tables[1];
                if (dtPacking.Rows.Count > 0)
                {
                    int nwColIndex = -1;
                    int headerRowIndexPacking = -1;

                    // Step 1: Find the row which contains the "N.W(KG)" header anywhere
                    for (int r = 0; r < dtPacking.Rows.Count; r++)
                    {
                        for (int c = 0; c < dtPacking.Columns.Count; c++)
                        {
                            if (dtPacking.Rows[r][c] != null)
                            {
                                string cellValues = dtPacking.Rows[r][c].ToString().Trim();

                                if (cellValues.Contains("N.W") || cellValues.Contains("NT.WT"))
                                {

                                    headerRowIndexPacking = r;
                                    nwColIndex = c;
                                    break;
                                }
                            }
                            //if (dtPacking.Rows[r][c] != null && dtPacking.Rows[r][c].ToString().Trim().Contains("N.W"))
                            //{
                            //    headerRowIndexPacking = r;
                            //    nwColIndex = c;
                            //    break;
                            //}
                        }
                        if (nwColIndex != -1) break; // header found
                    }

                    if (nwColIndex != -1 && headerRowIndexPacking != -1)
                    {
                        // Add column to dtItems if not exists
                        if (!dtItems.Columns.Contains("N.W(KG)"))
                            dtItems.Columns.Add("N.W(KG)");

                        // Step 2: Copy remaining N.W(KG) values row by row
                        int count = Math.Min(dtItems.Rows.Count, dtPacking.Rows.Count - headerRowIndexPacking - 1);
                        for (int i = 0; i < count; i++)
                        {
                            object nwValue = dtPacking.Rows[headerRowIndexPacking + 1 + i][nwColIndex];
                            dtItems.Rows[i]["N.W(KG)"] = nwValue != null ? nwValue.ToString().Trim() : "";
                        }
                    }
                }
            }
        }


        // ---------------- PART 2: APPLY JSON MAPPING ----------------
        try
        {
            ArrayList dictDetails = (ArrayList)dictheader[dataTo];
            Dictionary<string, object> detailsMap = (Dictionary<string, object>)dictDetails[0];

            DataTable dtMapped = new DataTable();

            // Create mapped columns
            foreach (var keyObj in detailsMap.Keys)
            {
                string key = keyObj.ToString();
                if (key.Equals("range", StringComparison.OrdinalIgnoreCase))
                    continue;

                ArrayList mappingArray = (ArrayList)detailsMap[key];
                if (mappingArray.Count == 0) continue;

                if (!dtMapped.Columns.Contains(key))
                    dtMapped.Columns.Add(key);
            }

            // Row creation
            for (int i = 0; i < dtItems.Rows.Count; i++)
            {
                DataRow newRow = dtMapped.NewRow();

                foreach (var keyObj in detailsMap.Keys)
                {
                    string key = keyObj.ToString();
                    if (key.Equals("range", StringComparison.OrdinalIgnoreCase))
                        continue;

                    ArrayList mappingArray = (ArrayList)detailsMap[key];
                    if (mappingArray.Count == 0) continue;

                    Dictionary<string, object> mapVal = (Dictionary<string, object>)mappingArray[0];
                    string assignName = mapVal.ContainsKey("assign") ? mapVal["assign"].ToString().Trim() : "";

                    // 🔥 FIX: If assign is empty → skip matching
                    if (string.IsNullOrWhiteSpace(assignName))
                    {
                        newRow[key] = "";
                        continue;
                    }

                    string matchedCol = null;

                    // Column matching
                    foreach (DataColumn col in dtItems.Columns)
                    {
                        string colName = col.ColumnName.Trim().ToLower();
                        string assignLower = assignName.ToLower();

                        if (colName.Equals(assignLower) ||
                            colName.Contains(assignLower))
                        {
                            matchedCol = col.ColumnName;
                            break;
                        }
                    }

                    if (!string.IsNullOrEmpty(matchedCol))
                        newRow[key] = dtItems.Rows[i][matchedCol];
                    else
                        newRow[key] = "";
                }

                dtMapped.Rows.Add(newRow);
            }

            return dtMapped;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Mapping error: " + ex.Message);
            return dtItems; // fallback
        }
    }


    public void getlkupval(string customer, string InvType)
    {
        string strcon = Connection.GetConnection();
        SqlConnection conn = new SqlConnection(strcon);
        string selectquery = "select des from IMPORT_PDF_LKUP with(nolock) where del_flg=0 and Importer_Name='" + customer + "' and Invo_Type='" + InvType + "'";
        var cmd = new SqlCommand(selectquery, conn);
        conn.Open();

        var reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                ds_OrderDetails = JsonConvert.DeserializeObject<DataSet>(reader.GetValue(0).ToString());
                ds_lkupDetails = reader.GetValue(0).ToString();
            }
        }
        else
        {
            ds_OrderDetails = null;
            ds_lkupDetails = string.Empty;
        }
    }

    public System.Data.DataTable readHeaderPDFval(string custname, string dataTo, Dictionary<string, object> dictheader, DataSet ds_output, string InvType)
    {
        string cellValue = string.Empty;
        string rowlValue = string.Empty;

        int _sPos = 0, col_pos = 0;


        string same_invNo = "N";
        int row_start = 5;


        System.Data.DataTable dttable = new System.Data.DataTable();
        dttable.Rows.Add();
        ArrayList dictheaders = (ArrayList)dictheader[dataTo];
        Dictionary<string, object> KeyMaping = (Dictionary<string, object>)dictheaders[0];
        for (int keycount = 0; keycount < KeyMaping.Count; keycount++)
        {
            List<KeyValuePair<string, object>> list = new List<KeyValuePair<string, object>>(KeyMaping);
            string key = list[keycount].Key;

            dttable.Columns.Add(key);
            ArrayList headermaping = (ArrayList)KeyMaping[key];
            Dictionary<string, object> headermapingval = (Dictionary<string, object>)headermaping[0];
            string _column = headermapingval["column"].ToString();
            string _split = headermapingval["split"].ToString();
            string _sVal = headermapingval["Value"].ToString();
            string _Reverse = headermapingval["Reverse"].ToString();

            if (headermapingval["Position"].ToString() != "")
            {
                _sPos = Convert.ToInt32(headermapingval["Position"].ToString());
            }

            try
            {
                if (headermapingval["Col_Pos"].ToString() != "")
                {
                    col_pos = Convert.ToInt32(headermapingval["Col_Pos"].ToString());
                }
            }
            catch (Exception)
            {
                col_pos = 0;
            }

            try
            {
                if (headermapingval["same_invNo"].ToString() != "")
                {
                    same_invNo = headermapingval["same_invNo"].ToString();
                }
            }
            catch (Exception)
            {
                same_invNo = "N";
            }


            //-------------- 1st sheet------------------
            try
            {
                DataSet dt = ds_output;

                cellValue = string.Empty;
                int rw_cnt = dt.Tables[0].Rows.Count;
                int col_cnt = dt.Tables[0].Columns.Count;
                string cell = "";
                string cell2 = "";
                string cell3 = "";



                if (key == "InvoiceNo" || key == "ImporterName" || key == "SupplierName" || key == "InvoiceDate" || key == "TermsofPayment" || key == "PortOfOrigin" || key == "Qtycode" || key == "Currency" || key == "Terms" || key == "InvoiceValue" || key == "Schemecode" || key == "ADcode" || key == "IEC" || key == "client" || key == "Freight" || key == "Insurance")
                {

                    for (int row = 0; row <= rw_cnt; row++)
                    {
                        for (int col = 0; col <= col_cnt - 1; col++)
                        {
                            cell = dt.Tables[0].Rows[row][col].ToString();
                            string celldetValue = string.Empty;
                            try
                            {
                                celldetValue = cell;
                            }
                            catch (Exception) { celldetValue = string.Empty; }

                            if (_column == celldetValue && _split == string.Empty && _Reverse != "Y")
                            {
                                cell2 = dt.Tables[0].Rows[row + _sPos][col + col_pos].ToString();
                                string celldetValue2 = cell2;
                                cellValue = celldetValue2;

                                col = col_cnt;
                                row = rw_cnt;


                            }
                            else if (_column == celldetValue && _split != string.Empty && _Reverse != "Y")
                            {
                                cell2 = dt.Tables[0].Rows[row + _sPos][col + col_pos].ToString();
                                string celldetValue2 = cell2;
                                cellValue = celldetValue2;

                                col = col_cnt;
                                row = rw_cnt;


                            }
                            else if (celldetValue.Contains(_column.ToString()) && _split == string.Empty && _Reverse == "Y")
                            {


                                //cell2 = dt.Tables[0].Rows[row - _sPos][col - col_pos].ToString();
                                cell2 = dt.Tables[0].Rows[row - _sPos][col + col_pos].ToString();

                                string celldetValue2 = cell2;
                                cellValue = celldetValue2;
                                col = col_cnt;
                                row = rw_cnt;
                            }
                            else if (celldetValue.Contains(_column.ToString()) && _split != string.Empty && _Reverse == "Y")
                            {
                                cell2 = dt.Tables[0].Rows[row + _sPos][col + col_pos].ToString();

                                string celldetValue2 = cell2.Replace("\r", " ")
                                                            .Replace("\n", " ").Replace("_x000D_", " ")
                                                            .Trim();

                                string[] words = celldetValue2.Split(new char[] { ' ' },
                                                    StringSplitOptions.RemoveEmptyEntries);

                                string result = "";

                                if (!string.IsNullOrEmpty(_sVal))
                                {
                                    string[] indexes = _sVal.Split(',');

                                    foreach (string idx in indexes)
                                    {
                                        int i;

                                        if (int.TryParse(idx, out i))
                                        {
                                            if (i >= 0 && i < words.Length)
                                            {
                                                result += words[i] + " ";
                                            }
                                        }
                                    }
                                }

                                cellValue = result.Trim();
                                col = col_cnt;
                                row = rw_cnt;

                            }


                            else if (celldetValue.Contains(_column.ToString()) && _split != string.Empty)
                            {
                                cell2 = dt.Tables[1].Rows[row + _sPos][col + col_pos].ToString();
                                string celldetValue2 = cell2;
                                cellValue = celldetValue2;


                                string[] _columnvals = cellValue.Split(' ');
                                int _Val = Convert.ToInt32(headermapingval["Value"]);
                                int tep = _Val;
                                cell2 = _columnvals[tep];
                                cellValue = cell2;

                                col = col_cnt;
                                row = rw_cnt;



                            }
                        }
                    }
                }
                else if (dt.Tables.Count > 1 && dt.Tables[1] != null && (key == "TotalGrossWeight" || key == "TotalNetWeight" || key == "TotalCarton"))
                {
                    cellValue = string.Empty;
                    rowlValue = string.Empty;
                    int rw_cnt_Tb2 = dt.Tables[1].Rows.Count;
                    int col_cnt_Tb2 = dt.Tables[1].Columns.Count;

                    for (int row_Tb2 = row_start; row_Tb2 <= rw_cnt_Tb2; row_Tb2++)
                    {
                        for (int col_Tb2 = 0; col_Tb2 <= col_cnt_Tb2 - 1; col_Tb2++)
                        {
                            if (col_Tb2 == 18)
                            {
                                col_Tb2 = col_cnt_Tb2 - 1;
                            }
                            try
                            {
                                cell = dt.Tables[1].Rows[row_Tb2][col_Tb2].ToString();
                                string celldetValue = string.Empty;
                                try
                                {
                                    celldetValue = cell;
                                }
                                catch (Exception) { celldetValue = string.Empty; }
                                if (celldetValue.Contains(_column.ToString()) && _split == string.Empty)
                                {
                                    string cellc = "";
                                    cellc = dt.Tables[1].Rows[row_Tb2][col_Tb2 + col_pos].ToString();
                                    cellValue = cellc;

                                    col_Tb2 = col_cnt_Tb2;
                                    row_Tb2 = rw_cnt_Tb2;
                                }
                                else if (celldetValue.Contains(_column.ToString()) && _split != string.Empty)
                                {
                                    cell2 = dt.Tables[1].Rows[row_Tb2 + _sPos][col_Tb2 + col_pos].ToString();
                                    string celldetValue2 = cell2;
                                    cellValue = celldetValue2;

                                    string[] _columnvals = cellValue.Split(' ');
                                    int _Val = Convert.ToInt32(headermapingval["Value"]);
                                    int tep = _Val;
                                    cell2 = _columnvals[tep];
                                    cellValue = cell2.Replace("Packages：", "").Replace(":", "").Replace(" KGS", "").Replace(" ", "").Trim();

                                    col_Tb2 = col_cnt;
                                    row_Tb2 = rw_cnt;
                                }
                            }
                            catch (Exception) { }
                        }
                    }
                }


                dttable.Rows[0][key] = cellValue;
                dttable.AcceptChanges();
            }
            catch (Exception) { }
        }
        return dttable;
        //#headerend
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
                        TextBox txtQtyCode = (TextBox)row.FindControl("txtQtyCode");
                        DropDownList ddl_SchemeCode = (DropDownList)row.FindControl("ddl_SchemeCode");
                        DropDownList ddl_Scheme_NOTN = (DropDownList)row.FindControl("ddl_Scheme_NOTN");
                        DropDownList ddl_Scheme_NOTN_SL = (DropDownList)row.FindControl("ddl_Scheme_NOTN_SL");
                        TextBox txtCTH = (TextBox)row.FindControl("txt_CTH");
                        TextBox txtBasicNoti = (TextBox)row.FindControl("txtBasicNoti");
                        TextBox txtBasicSlno = (TextBox)row.FindControl("txtBasicSlno");
                        TextBox txt_Basic_Rate = (TextBox)row.FindControl("txt_Basic_Rate");
                        TextBox txt_Manufacturer = (TextBox)row.FindControl("txt_Manufacturer");
                        TextBox txtEndUseOfItems = (TextBox)row.FindControl("txtEndUseOfItems");
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

                        if (txtItemDesc.Text.Trim() != "" && txtCTH.Text.Trim() != "" && txt_AIDCCessNoti.Text.Trim() != "" && txt_AIDCCessSlno.Text.Trim() != "" && txtitemCountyoforgin.Text.Trim() != ""
                            && txt_AIDCCessRate.Text.Trim() != "" && txt_IGSTNoti.Text.Trim() != "" && txt_IGSTSlNo.Text.Trim() != "" && txt_IGSTRate.Text.Trim() != "" && txt_Manufacturer.Text.Trim() != "" && txtEndUseOfItems.Text.Trim() != "")
                        {
                            string itemDesc = txtItemDesc.Text;
                            string qtyCode = txtQtyCode.Text;
                            string schemeCode = ddl_SchemeCode.SelectedValue;
                            string Scheme_NOTN = ddl_Scheme_NOTN.SelectedValue;
                            string Scheme_NOTN_SL = ddl_Scheme_NOTN_SL.SelectedValue;
                            string CTH = txtCTH.Text;
                            string BasicNoti = txtBasicNoti.Text;
                            string BasicSlno = txtBasicSlno.Text;
                            string BasicRate = txt_Basic_Rate.Text;
                            string Manufacturer = txt_Manufacturer.Text;
                            string EndUseOfItems = "";
                            if (txtEndUseOfItems.Text.Trim() != "")
                            {
                                EndUseOfItems = txtEndUseOfItems.Text.Split('-')[0];
                            }
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
                                Dt_Item.Rows[row.RowIndex]["QTYCode"] = qtyCode;
                                Dt_Item.Rows[row.RowIndex]["SchemeCode"] = schemeCode;
                                Dt_Item.Rows[row.RowIndex]["Scheme_NOTN"] = Scheme_NOTN;
                                Dt_Item.Rows[row.RowIndex]["Scheme_NOTN_SL"] = Scheme_NOTN_SL;
                                Dt_Item.Rows[row.RowIndex]["HSCode"] = CTH;
                                Dt_Item.Rows[row.RowIndex]["Basic_Noti"] = BasicNoti;
                                Dt_Item.Rows[row.RowIndex]["Basic_Slno"] = BasicSlno;
                                Dt_Item.Rows[row.RowIndex]["Basic_Rate"] = BasicRate;
                                Dt_Item.Rows[row.RowIndex]["MANUFACTURER"] = Manufacturer;
                                Dt_Item.Rows[row.RowIndex]["END_USE_OF_ITEM"] = EndUseOfItems;
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
                            else if (txt_Manufacturer.Text.Trim() == "")
                            {
                                Mandatory_Fields = "Manufacturer";
                            }
                            else if (txtEndUseOfItems.Text.Trim() == "")
                            {
                                Mandatory_Fields = "End Use";
                            }
                            else if (txtitemCountyoforgin.Text.Trim() == "")
                            {
                                Mandatory_Fields = "Item Country";
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
        //PdfClientName = ViewState["PdfClientName"].ToString().Trim();

        //General
        Transact.JOBID = jobid;
        Transact.JOBNO = Session["JOBNO"].ToString();
        Transact.JOBDATE = DateTime.Now.ToString("dd/MM/yyyy");
        Transact.IMPORTER_NAME = Importer;

        Transact.COUNTRY_ORIGIN = txtCountryOfOrigin.Text;
        Transact.PORT_ORIGIN = txtPortOfOrigin.Text;

        Transact.PORT_SHIPMENT = txtPortOfOrigin.Text;
        Transact.COUNTRY_SHIPMENT = txtCountryOfOrigin.Text;
        Transact.CUSTOMS_HOUSE = Session["CUSTOMHOUSE_CODE"].ToString();

        Transact.EXBOND_INBOND_BE_DATE = "01/01/1900";
        Transact.EXBOND_BOND_DATE = "01/01/1900";
        Transact.BE_TYPE = "Home";
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
            string InvoiceValueRemoveComa = invoiceValue.Replace(",", "").Replace(" ", "");
            Transact.INVOICE_VALUE = InvoiceValueRemoveComa;
            Transact.OTHER_PURCHASE_ORDER = "";
            Transact.OTHER_PURCHASE_ORDER_DATE = "01/01/1900";


            InsertInvoiceDetails();
        }
        else
        {
            for (int h = 0; h <= dt_INVOICE.Rows.Count - 1; h++)
            {
                //Transact.INV_SLNO = dt_INVOICE.Rows[h]["INVOICE_SLNO"].ToString();
                Transact.INVOICE_NO = dt_INVOICE.Rows[h]["InvoiceNo"].ToString();
                Transact.INVOICE_DATE = Get_Valid_Date(dt_INVOICE.Rows[h]["InvoiceDate"].ToString().Trim());
                Transact.INVOICE_CURRENCY = Get_Valid_Curr_Name(txtCurrency.Text.Trim().ToUpper());
                Transact.TERMS = dt_INVOICE.Rows[h]["Terms"].ToString().Trim();
                Transact.INVOICE_VALUE = dt_INVOICE.Rows[h]["InvoiceValue"].ToString().Trim().Replace(",", "");
                Transact.OTHER_PURCHASE_ORDER = "";
                Transact.OTHER_PURCHASE_ORDER_DATE = "01/01/1900";


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
                Transact.ITEM_QTY = dtItem.Rows[j]["Quantity"].ToString().Replace(" ", "");
                Transact.ITEM_QTY_CODE = dtItem.Rows[j]["QtyCode"].ToString();

                string MaterialRate = dtItem.Rows[j]["Rate"].ToString();
                string MaterialRateRemoveCama = MaterialRate.Replace(",", "").Replace(" ", "");
                Transact.ITEM_UNIT_PRICE = MaterialRateRemoveCama;
                Transact.ITEM_UNIT_CODE = txtCurrency.Text.ToUpper().Trim();

                string MaterialAmount = dtItem.Rows[j]["Amount"].ToString();
                string MaterialAmountRemoveCama = MaterialAmount.Replace(",", "").Replace(" ", "");
                Transact.ITEM_TOTAL_AMOUNT = MaterialAmountRemoveCama;
                GetPartNo = dtItem.Rows[j]["PartNo"].ToString();
                //GetPoNo = dtItem.Rows[j]["PONumber"].ToString();
                //GetNetWeight = dtItem.Rows[j]["NetWeight"].ToString();

                Transact.ITEM_AMOUNT_CODE = txtCurrency.Text.ToUpper().Trim();
                Transact.PREVIOUS_BE_DATE = "01/01/1900";
                Transact.flag = "S";
                Transact.YEAR = "";
                Transact.USER_ID = currentuser;
                Transact.BRANCH_CODE = currentbranch;
                Transact.WORKING_PERIOD = Working_Period;
                Transact.JOBNO = Session["JOBNO"].ToString();
                Transact.BRANCH_COMMON = SELECT_BRANCH;


                Transact.ITEM_DESCRIPTION = ITEM_DESCRIPTION.Replace("СЕ", "CE");
                Transact.GENEARL_DESCRIPTION = ITEM_DESCRIPTION.Replace("СЕ", "CE");
                Transact.CTH_NO = dtItem.Rows[j]["HSCode"].ToString();

                Auto.Ename = "Get_CTH_Info_Uqc";
                Auto.Enamesearch = Transact.CTH_NO;
                Auto.Notn_No_Search = Transact.CTH_NO;
                DataSet ds_MSR_UQC = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

                if (ds_MSR_UQC.Tables[0].Rows.Count > 0)
                {
                    Transact.Info_Uqc = ds_MSR_UQC.Tables[0].Rows[0][0].ToString();
                    string Chk_Qty_Code = Get_Valid_Qty_Code(Transact.ITEM_QTY_CODE);
                    if ((Transact.Info_Uqc == "KGS" || ((Chk_Qty_Code == "NOS" || Chk_Qty_Code == "PCS" || Chk_Qty_Code == "SET") && (Transact.Info_Uqc == "MTR" || Transact.Info_Uqc == "KGS"))))
                    {
                        string Chk_Info_Msr = dtItem.Rows[j]["info_MSR"].ToString();
                        if (Chk_Info_Msr != "" && Chk_Info_Msr != null)
                        {
                            Transact.Info_Msr = Chk_Info_Msr;
                        }
                        else
                        {
                            Transact.Info_Msr = "";
                        }
                    }
                    else
                    {
                        Transact.Info_Msr = Transact.ITEM_QTY.ToString().Replace(",", "");
                    }
                }
                else
                {
                    Transact.Info_Msr = dtItem.Rows[j]["info_MSR"].ToString();
                    Transact.Info_Uqc = dtItem.Rows[j]["info_UQC"].ToString();
                }

                Transact.MANUFACTURER = txtSupplier.Text.Trim();
                Transact.BRAND = "NA";
                Transact.MODEL = "NA";

                Transact.END_USE_OF_ITEM = dtItem.Rows[j]["END_USE_OF_ITEM"].ToString();
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
                Transact.RSP_APPLICABLE = "N";
                if (Transact.IGST_LEVY_NOTN != "")
                {
                    Transact.IGST_LEVY_COMPENSATION_CESS_NOTN = "001/2017";
                    Transact.IGST_LEVY_COMPENSATION_CESS_SLNO = "56";
                    Transact.IGST_LEVY_COMPENSATION_CESS_RATE = "0.00";
                }
                DataSet dss = Transact.Item_Details_insertupdate();
            }
        }


        if (COMPANY_IDD == "876" || COMPANY_IDD == "427" || COMPANY_IDD == "1108" || COMPANY_IDD == "10")
        {
            DataTable dt_IGMDetails = (ViewState["dt_IGMDetails"]) as DataTable;
            if (dt_IGMDetails.Rows.Count > 0)
            {
                for (int aj = 0; aj <= dt_IGMDetails.Rows.Count - 1; aj++)
                {
                    Transact.IGM_MAWB_MBL = dt_IGMDetails.Rows[aj]["IGM_MAWB_MBL"].ToString().Replace(" ", "");
                    Transact.IGM_MAWB_MBLDATE = string.IsNullOrEmpty(dt_IGMDetails.Rows[aj]["IGM_MAWB_MBLDATE"].ToString()) ? "01/01/1900" : dt_IGMDetails.Rows[aj]["IGM_MAWB_MBLDATE"].ToString();
                    Transact.IGM_HAWB_HBLNO = dt_IGMDetails.Rows[aj]["IGM_HAWB_HBLNO"].ToString().Replace(" ", "");
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

        Auto.Ename = "EXCHANGE_MASTER_RATE_IMPORTWISE";
        Auto.Enamesearch = txtCurrency.Text.ToUpper().Trim();
        ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
        if (ds.Tables[0].Rows.Count > 0)
        {
            string INVOICE_EXRATE = ds.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();
            Transact.INVOICE_EXRATE = INVOICE_EXRATE;
            Transact.MIS_EXRATE = INVOICE_EXRATE;
            Transact.MIS_AGENCY_EXRATE = INVOICE_EXRATE;
            Transact.MIS_DISCOUNT_EXRATE = INVOICE_EXRATE;
            Transact.MIS_FREIGHT_EXRATE = INVOICE_EXRATE;
            Transact.MIS_INSURANCE_EXRATE = INVOICE_EXRATE;

            //CHARGES


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
        else if (curr == "US$")
        {
            curr = "USD";
        }

        return curr;
    }

    private string Get_Valid_Qty_Code(string curr)
    {
        if (curr != "" && curr != string.Empty && curr != null)
        {
            if (curr == "SETS" || curr.Contains("SET") || curr == "SET(S)")
            {
                curr = "SET";
            }
            else if (curr == "PIECE(S)" || curr == "PCE" || curr == "PC" || curr == "pcs")
            {
                curr = "PCS";
            }
            else if (curr.Contains("PC/PK") || curr.Contains("PCS/PK") || curr.Contains("PCS/PACK"))
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
            else if (curr == "PAIR")
            {
                curr = "PRS";
            }
        }

        return curr;
    }



    private string Get_Valid_Date(string Dt)
    {
        Dt = Dt.Replace(".", "/").Replace("-", "/").Replace(",", "/").Replace(" ", "/");
        string[] dd = Dt.Split('/');

        if (dd[0].Length == 3)
        {
            string ExchangeMonth = dd[0];
            string ExchangeDate = dd[1];

            dd[1] = ExchangeMonth;
            dd[0] = ExchangeDate;
        }
        else if (dd[0].Length == 4)
        {
            string YearExchange = dd[0];
            string DateExchange = dd[2];

            dd[2] = YearExchange;
            dd[0] = DateExchange;
        }
        if (dd[0].Length != 2)
        {
            dd[0] = "0" + dd[0];
        }
        if (dd[1].Length != 2)
        {
            dd[1] = dd[1].Replace("JAN", "1").Replace("FEB", "2").Replace("MAR", "3").Replace("Mar", "3").Replace("APR", "4").Replace("June", "6").Replace("JUNE", "6");
            dd[1] = "0" + dd[1];
        }
        if (dd[2].Length != 4)
        {
            dd[2] = "20" + dd[2];
        }

        return Dt = dd[0] + "/" + dd[1] + "/" + dd[2];
    }

    //protected void btn_bulk_Update_All_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (ListBox_ItemSlno.SelectedItem != null && ListBox_ItemSlno.SelectedItem.Text != null)
    //        {
    //            int rowIndex = gv_ItemPDF.Rows.Count;
    //            DataTable GridViewData = (DataTable)ViewState["GridViewData"];
    //            if (gv_ItemPDF.Rows.Count > 0)
    //            {
    //                DropDownList ddl_SchemeCode = null, ddl_Scheme_NOTN = null; string[] schemeParts = null;
    //                for (int i = 0; i < gv_ItemPDF.Rows.Count; i++)
    //                {
    //                    if (txtDescription.Text != "")
    //                    {
    //                        TextBox txtItemDesc = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtItemDesc");
    //                        txtItemDesc.Text = txtDescription.Text;
    //                    }
    //                    if (ddlSchemeCode != null && ddlSchemeCode.SelectedItem != null && ddlSchemeCode.SelectedItem.Text != "")
    //                    {
    //                        ddl_SchemeCode = (DropDownList)gv_ItemPDF.Rows[i].FindControl("ddl_SchemeCode");
    //                        ddl_SchemeCode.SelectedValue = ddlSchemeCode.SelectedValue;
    //                    }
    //                    if (ddlScheme_NOTN != null && ddlScheme_NOTN.SelectedItem != null && ddlScheme_NOTN.SelectedItem.Text != "")
    //                    {
    //                        ddl_Scheme_NOTN = (DropDownList)gv_ItemPDF.Rows[i].FindControl("ddl_Scheme_NOTN");
    //                        string selectedValue = ddl_SchemeCode.SelectedValue.ToString();
    //                        schemeParts = selectedValue.Split(new string[] { "-" }, StringSplitOptions.None);

    //                        ddl_Scheme_NOTN.Items.Clear();

    //                        if (schemeParts[0].Trim() != "00")
    //                        {
    //                            adm.SCHEME_IMPORT_CODE = schemeParts[0].ToString();
    //                            adm.SCHEME_NOTN = "0";
    //                            adm.name = "SCHEME_NOTN";
    //                            ddl_Scheme_NOTN.DataSource = adm.RetrieveAll_Scheme_Import();
    //                            ddl_Scheme_NOTN.DataTextField = "SCHEME_NOTN";
    //                            ddl_Scheme_NOTN.DataValueField = "SCHEME_NOTN";
    //                            ddl_Scheme_NOTN.Items.Add(" ");
    //                            ddl_Scheme_NOTN.DataBind();
    //                            scheme_notn_slno();
    //                        }
    //                        else
    //                        {
    //                            ddl_Scheme_NOTN.Items.Clear();
    //                        }

    //                        ddl_Scheme_NOTN.SelectedValue = ddlScheme_NOTN.SelectedValue;
    //                    }
    //                    if (ddlScheme_NOTN_SL != null && ddlScheme_NOTN_SL.SelectedItem != null && ddlScheme_NOTN_SL.SelectedItem.Text != "")
    //                    {
    //                        DropDownList ddl_Scheme_NOTN_SL = (DropDownList)gv_ItemPDF.Rows[i].FindControl("ddl_Scheme_NOTN_SL");
    //                        ddl_Scheme_NOTN_SL.Items.Clear();
    //                        adm.SCHEME_IMPORT_CODE = schemeParts[0].ToString();
    //                        adm.SCHEME_NOTN = ddl_Scheme_NOTN.SelectedValue;
    //                        adm.name = "SCHEME_NOTN_SLNO";
    //                        ddl_Scheme_NOTN_SL.DataSource = adm.RetrieveAll_Scheme_Import();
    //                        ddl_Scheme_NOTN_SL.DataTextField = "SCHEME_NOTN_SLNO";
    //                        ddl_Scheme_NOTN_SL.DataValueField = "SCHEME_NOTN_SLNO";
    //                        ddl_Scheme_NOTN_SL.Items.Add(" ");
    //                        ddl_Scheme_NOTN_SL.DataBind();

    //                        ddl_Scheme_NOTN_SL.SelectedValue = ddlScheme_NOTN_SL.SelectedValue;
    //                    }
    //                    //if (ddlSchemeCode.SelectedItem.Text != "")
    //                    //{
    //                    //    DropDownList ddlScheme_Code = (DropDownList)gv_ItemPDF.Rows[i].FindControl("ddl_SchemeCode");
    //                    //    ddlScheme_Code.SelectedValue = ddlSchemeCode.SelectedValue;
    //                    //}
    //                    if (txtCTH.Text != "")
    //                    {
    //                        TextBox txt_CTH = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_CTH");
    //                        txt_CTH.Text = txtCTH.Text;
    //                    }
    //                    if (txtBasicNotn.Text != "")
    //                    {
    //                        TextBox txtBasicNoti = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtBasicNoti");
    //                        txtBasicNoti.Text = txtBasicNotn.Text;
    //                    }
    //                    if (txtBasicSLNO.Text != "")
    //                    {
    //                        TextBox txtBasicSlno = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtBasicSlno");
    //                        txtBasicSlno.Text = txtBasicSLNO.Text;
    //                    }
    //                    if (txtBasicRate.Text != "")
    //                    {
    //                        TextBox txt_Basic_Rate = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_Basic_Rate");
    //                        txt_Basic_Rate.Text = txtBasicRate.Text;
    //                    }
    //                    if (txtManufacturer.Text != "")
    //                    {
    //                        TextBox txt_Manufacturer = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_Manufacturer");
    //                        txt_Manufacturer.Text = txtManufacturer.Text;
    //                    }
    //                    if (txtEnduseItem.Text != "")
    //                    {
    //                        TextBox txtEndUseOfItems = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtEndUseOfItems");
    //                        txtEndUseOfItems.Text = txtEnduseItem.Text;
    //                    }
    //                    if (txtitemCountyof_orgin.Text != "")
    //                    {
    //                        TextBox txtitemCountyoforgin = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtitemCountyoforgin");
    //                        txtitemCountyoforgin.Text = txtitemCountyof_orgin.Text;
    //                    }
    //                    if (txtSW_Noti.Text != "")
    //                    {
    //                        TextBox txt_SW_Noti = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_SW_Noti");
    //                        txt_SW_Noti.Text = txtSW_Noti.Text;
    //                    }
    //                    if (txtSW_Slno.Text != "")
    //                    {
    //                        TextBox txt_SW_Slno = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_SW_Slno");
    //                        txt_SW_Slno.Text = txtSW_Slno.Text;
    //                    }
    //                    if (txt_SW_Rate.Text != "")
    //                    {
    //                        TextBox txtSW_Rate = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtSW_Rate");
    //                        txtSW_Rate.Text = txt_SW_Rate.Text;
    //                    }
    //                    if (txt_AIDC_CessNoti.Text != "")
    //                    {
    //                        TextBox txt_AIDCCessNoti = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_AIDCCessNoti");
    //                        txt_AIDCCessNoti.Text = txt_AIDC_CessNoti.Text;
    //                    }
    //                    if (txt_AIDC_CessSlno.Text != "")
    //                    {
    //                        TextBox txt_AIDCCessSlno = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_AIDCCessSlno");
    //                        txt_AIDCCessSlno.Text = txt_AIDC_CessSlno.Text;
    //                    }
    //                    if (txt_AIDC_CessRate.Text != "")
    //                    {
    //                        TextBox txt_AIDCCessRate = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_AIDCCessRate");
    //                        txt_AIDCCessRate.Text = txt_AIDC_CessRate.Text;
    //                    }
    //                    if (txt_IGST_Noti.Text != "")
    //                    {
    //                        TextBox txt_IGSTNoti = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_IGSTNoti");
    //                        txt_IGSTNoti.Text = txt_IGST_Noti.Text;
    //                    }
    //                    if (txt_IGST_SlNo.Text != "")
    //                    {
    //                        TextBox txt_IGSTSlNo = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_IGSTSlNo");
    //                        txt_IGSTSlNo.Text = txt_IGST_SlNo.Text;
    //                    }
    //                    if (txt_IGST_Rate.Text != "")
    //                    {
    //                        TextBox txt_IGSTRate = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_IGSTRate");
    //                        txt_IGSTRate.Text = txt_IGST_Rate.Text;
    //                    }
    //                    rowIndex++;
    //                }
    //            }
    //            txtDescription.Text = "";
    //            txtCTH.Text = "";
    //            txtBasicNotn.Text = "";
    //            txtBasicSLNO.Text = "";
    //            txtBasicRate.Text = "";
    //            txtManufacturer.Text = "";
    //            txtEnduseItem.Text = "";
    //            txtitemCountyof_orgin.Text = "";
    //            txtSW_Noti.Text = "";
    //            txtSW_Slno.Text = "";
    //            txt_SW_Rate.Text = "";
    //            txt_AIDC_CessNoti.Text = "";
    //            txt_AIDC_CessSlno.Text = "";
    //            txt_AIDC_CessRate.Text = "";
    //            txt_IGST_Noti.Text = "";
    //            txt_IGST_SlNo.Text = "";
    //            txt_IGST_Rate.Text = "";

    //            Alert_msg("Applied to all records successfully!");

    //        }
    //        else
    //        {
    //            Alert_msg("Please Select Inv & Item...!");
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        log.makeLog("Message ==> " + ex.Message);
    //        lblmsg.Text = " Message ==> " + ex.Message + " InnerException ==> " + ex.InnerException + " StackTrace ==>" + ex.StackTrace;
    //    }
    //}

    protected void btn_bulk_Update_All_Click(object sender, EventArgs e)
    {
        try
        {
            if (ListBox_ItemSlno.SelectedItem != null && ListBox_ItemSlno.SelectedItem.Text != null)
            {
                DataTable GridViewData = (DataTable)ViewState["GridViewData"];

                if (gv_ItemPDF.Rows.Count > 0 && GridViewData != null)
                {
                    DropDownList ddl_SchemeCode = null, ddl_Scheme_NOTN = null;
                    string[] schemeParts = null;

                    for (int i = 0; i < gv_ItemPDF.Rows.Count; i++)
                    {
                        // ── Get key fields to match back to GridViewData ──────────
                        TextBox txtInvSlNo = (TextBox)gv_ItemPDF.Rows[i].Cells[0].FindControl("txtInvSlNo");
                        TextBox txtItemSlNo = (TextBox)gv_ItemPDF.Rows[i].Cells[0].FindControl("txtItemSlNo");
                        string Inv_slno = txtInvSlNo != null ? txtInvSlNo.Text : "";
                        string slno = txtItemSlNo != null ? txtItemSlNo.Text : "";

                        // ── Apply bulk values to GridView row controls ────────────
                        if (txtDescription.Text != "")
                        {
                            TextBox txtItemDesc = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtItemDesc");
                            if (txtItemDesc != null) txtItemDesc.Text = txtDescription.Text;
                        }
                        if (ddlSchemeCode != null && ddlSchemeCode.SelectedItem != null && ddlSchemeCode.SelectedItem.Text != "")
                        {
                            ddl_SchemeCode = (DropDownList)gv_ItemPDF.Rows[i].FindControl("ddl_SchemeCode");
                            if (ddl_SchemeCode != null) ddl_SchemeCode.SelectedValue = ddlSchemeCode.SelectedValue;
                        }
                        if (ddlScheme_NOTN != null && ddlScheme_NOTN.SelectedItem != null && ddlScheme_NOTN.SelectedItem.Text != "")
                        {
                            ddl_Scheme_NOTN = (DropDownList)gv_ItemPDF.Rows[i].FindControl("ddl_Scheme_NOTN");
                            string selectedValue = ddl_SchemeCode != null ? ddl_SchemeCode.SelectedValue : "";
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
                            }
                            ddl_Scheme_NOTN.SelectedValue = ddlScheme_NOTN.SelectedValue;
                        }
                        if (ddlScheme_NOTN_SL != null && ddlScheme_NOTN_SL.SelectedItem != null && ddlScheme_NOTN_SL.SelectedItem.Text != "")
                        {
                            DropDownList ddl_Scheme_NOTN_SL = (DropDownList)gv_ItemPDF.Rows[i].FindControl("ddl_Scheme_NOTN_SL");
                            if (ddl_Scheme_NOTN_SL != null && schemeParts != null)
                            {
                                ddl_Scheme_NOTN_SL.Items.Clear();
                                adm.SCHEME_IMPORT_CODE = schemeParts[0].ToString();
                                adm.SCHEME_NOTN = ddl_Scheme_NOTN != null ? ddl_Scheme_NOTN.SelectedValue : "";
                                adm.name = "SCHEME_NOTN_SLNO";
                                ddl_Scheme_NOTN_SL.DataSource = adm.RetrieveAll_Scheme_Import();
                                ddl_Scheme_NOTN_SL.DataTextField = "SCHEME_NOTN_SLNO";
                                ddl_Scheme_NOTN_SL.DataValueField = "SCHEME_NOTN_SLNO";
                                ddl_Scheme_NOTN_SL.Items.Add(" ");
                                ddl_Scheme_NOTN_SL.DataBind();
                                ddl_Scheme_NOTN_SL.SelectedValue = ddlScheme_NOTN_SL.SelectedValue;
                            }
                        }
                        if (txtCTH.Text != "")
                        {
                            TextBox txt_CTH = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_CTH");
                            if (txt_CTH != null) txt_CTH.Text = txtCTH.Text;
                        }
                        if (txtBasicNotn.Text != "")
                        {
                            TextBox txtBasicNoti = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtBasicNoti");
                            if (txtBasicNoti != null) txtBasicNoti.Text = txtBasicNotn.Text;
                        }
                        if (txtBasicSLNO.Text != "")
                        {
                            TextBox txtBasicSlno = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtBasicSlno");
                            if (txtBasicSlno != null) txtBasicSlno.Text = txtBasicSLNO.Text;
                        }
                        if (txtBasicRate.Text != "")
                        {
                            TextBox txt_Basic_Rate = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_Basic_Rate");
                            if (txt_Basic_Rate != null) txt_Basic_Rate.Text = txtBasicRate.Text;
                        }
                        if (txtManufacturer.Text != "")
                        {
                            TextBox txt_Manufacturer = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_Manufacturer");
                            if (txt_Manufacturer != null) txt_Manufacturer.Text = txtManufacturer.Text;
                        }
                        if (txtEnduseItem.Text != "")
                        {
                            TextBox txtEndUseOfItems = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtEndUseOfItems");
                            if (txtEndUseOfItems != null) txtEndUseOfItems.Text = txtEnduseItem.Text;
                        }
                        if (txtitemCountyof_orgin.Text != "")
                        {
                            TextBox txtitemCountyoforgin = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtitemCountyoforgin");
                            if (txtitemCountyoforgin != null) txtitemCountyoforgin.Text = txtitemCountyof_orgin.Text;
                        }
                        if (txtSW_Noti.Text != "")
                        {
                            TextBox txt_SW_Noti = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_SW_Noti");
                            if (txt_SW_Noti != null) txt_SW_Noti.Text = txtSW_Noti.Text;
                        }
                        if (txtSW_Slno.Text != "")
                        {
                            TextBox txt_SW_Slno = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_SW_Slno");
                            if (txt_SW_Slno != null) txt_SW_Slno.Text = txtSW_Slno.Text;
                        }
                        if (txt_SW_Rate.Text != "")
                        {
                            TextBox txtSW_Rate = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtSW_Rate");
                            if (txtSW_Rate != null) txtSW_Rate.Text = txt_SW_Rate.Text;
                        }
                        if (txt_AIDC_CessNoti.Text != "")
                        {
                            TextBox txt_AIDCCessNoti = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_AIDCCessNoti");
                            if (txt_AIDCCessNoti != null) txt_AIDCCessNoti.Text = txt_AIDC_CessNoti.Text;
                        }
                        if (txt_AIDC_CessSlno.Text != "")
                        {
                            TextBox txt_AIDCCessSlno = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_AIDCCessSlno");
                            if (txt_AIDCCessSlno != null) txt_AIDCCessSlno.Text = txt_AIDC_CessSlno.Text;
                        }
                        if (txt_AIDC_CessRate.Text != "")
                        {
                            TextBox txt_AIDCCessRate = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_AIDCCessRate");
                            if (txt_AIDCCessRate != null) txt_AIDCCessRate.Text = txt_AIDC_CessRate.Text;
                        }
                        if (txt_IGST_Noti.Text != "")
                        {
                            TextBox txt_IGSTNoti = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_IGSTNoti");
                            if (txt_IGSTNoti != null) txt_IGSTNoti.Text = txt_IGST_Noti.Text;
                        }
                        if (txt_IGST_SlNo.Text != "")
                        {
                            TextBox txt_IGSTSlNo = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_IGSTSlNo");
                            if (txt_IGSTSlNo != null) txt_IGSTSlNo.Text = txt_IGST_SlNo.Text;
                        }
                        if (txt_IGST_Rate.Text != "")
                        {
                            TextBox txt_IGSTRate = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_IGSTRate");
                            if (txt_IGSTRate != null) txt_IGSTRate.Text = txt_IGST_Rate.Text;
                        }

                        // ✅ KEY FIX: Write updated grid row values back into GridViewData DataTable
                        for (int j = 0; j < GridViewData.Rows.Count; j++)
                        {
                            if (GridViewData.Rows[j]["InvoiceSlNo"].ToString() == Inv_slno &&
                                GridViewData.Rows[j]["ItemSlNo"].ToString() == slno)
                            {
                                if (txtDescription.Text != "") GridViewData.Rows[j]["ITEM_DESC"] = txtDescription.Text;
                                if (txtCTH.Text != "") GridViewData.Rows[j]["HSCode"] = txtCTH.Text;
                                if (txtBasicNotn.Text != "") GridViewData.Rows[j]["Basic_Noti"] = txtBasicNotn.Text;
                                if (txtBasicSLNO.Text != "") GridViewData.Rows[j]["Basic_Slno"] = txtBasicSLNO.Text;
                                if (txtBasicRate.Text != "") GridViewData.Rows[j]["Basic_Rate"] = txtBasicRate.Text;
                                if (txtManufacturer.Text != "") GridViewData.Rows[j]["MANUFACTURER"] = txtManufacturer.Text;
                                if (txtEnduseItem.Text != "") GridViewData.Rows[j]["END_USE_OF_ITEM"] = txtEnduseItem.Text;
                                if (txtitemCountyof_orgin.Text != "") GridViewData.Rows[j]["itemCountyof_orgin"] = txtitemCountyof_orgin.Text;
                                if (txtSW_Noti.Text != "") GridViewData.Rows[j]["SW_Noti"] = txtSW_Noti.Text;
                                if (txtSW_Slno.Text != "") GridViewData.Rows[j]["SW_Slno"] = txtSW_Slno.Text;
                                if (txt_SW_Rate.Text != "") GridViewData.Rows[j]["SW_Rate"] = txt_SW_Rate.Text;
                                if (txt_AIDC_CessNoti.Text != "") GridViewData.Rows[j]["AIDC_CessNoti"] = txt_AIDC_CessNoti.Text;
                                if (txt_AIDC_CessSlno.Text != "") GridViewData.Rows[j]["AIDC_CessSlno"] = txt_AIDC_CessSlno.Text;
                                if (txt_AIDC_CessRate.Text != "") GridViewData.Rows[j]["AIDC_CessRate"] = txt_AIDC_CessRate.Text;
                                if (txt_IGST_Noti.Text != "") GridViewData.Rows[j]["IGST_Noti"] = txt_IGST_Noti.Text;
                                if (txt_IGST_SlNo.Text != "") GridViewData.Rows[j]["IGST_SlNo"] = txt_IGST_SlNo.Text;
                                if (txt_IGST_Rate.Text != "") GridViewData.Rows[j]["IGST_Rate"] = txt_IGST_Rate.Text;
                                break;
                            }
                        }
                    }

                    // ✅ KEY FIX: Persist updated DataTable back to both ViewStates
                    ViewState["GridViewData"] = GridViewData;
                    ViewState["ItemDetails"] = GridViewData;
                }

                // Clear bulk input fields
                txtDescription.Text = ""; txtCTH.Text = ""; txtBasicNotn.Text = "";
                txtBasicSLNO.Text = ""; txtBasicRate.Text = ""; txtManufacturer.Text = "";
                txtEnduseItem.Text = ""; txtitemCountyof_orgin.Text = "";
                txtSW_Noti.Text = ""; txtSW_Slno.Text = ""; txt_SW_Rate.Text = "";
                txt_AIDC_CessNoti.Text = ""; txt_AIDC_CessSlno.Text = ""; txt_AIDC_CessRate.Text = "";
                txt_IGST_Noti.Text = ""; txt_IGST_SlNo.Text = ""; txt_IGST_Rate.Text = "";

                Alert_msg("Applied to all records successfully!");
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
            DataTable GridViewData = (DataTable)ViewState["GridViewData"];

            //if (ddl_Select_ItemRITC.SelectedValue == "2")
            //{
            //    var emptyRows = GridViewData.AsEnumerable()
            //        .Where(x => string.IsNullOrWhiteSpace(x["HSCode"].ToString()))
            //        .ToList();

            //    if (emptyRows.Count > 0)
            //    {
            //        // CLEAR ITEM LIST ONLY
            //        ListBox_ItemSlno.Items.Clear();

            //        // FIRST DESELECT ALL INVOICES
            //        foreach (ListItem inv in ListBox_INVSlno.Items)
            //        {
            //            inv.Selected = false;
            //        }

            //        // GET DISTINCT EMPTY CTH INVOICES
            //        var invoiceNos = emptyRows
            //            .Select(x => x["InvoiceSlNo"].ToString())
            //            .Distinct()
            //            .ToList();

            //        // SELECT MATCHING INVOICES
            //        foreach (ListItem inv in ListBox_INVSlno.Items)
            //        {
            //            if (invoiceNos.Contains(inv.Value))
            //            {
            //                inv.Selected = true;
            //            }
            //        }

            //        // ADD + SELECT ITEMS
            //        foreach (DataRow row in emptyRows)
            //        {
            //            string invNo = row["InvoiceSlNo"].ToString();
            //            string itemNo = row["ItemSlNo"].ToString();

            //            string txt = invNo + "~" + itemNo;

            //            ListItem item = new ListItem(txt, txt);
            //            item.Selected = true;

            //            ListBox_ItemSlno.Items.Add(item);
            //        }

            //        // BIND GRID
            //        DataTable dt = emptyRows.CopyToDataTable();

            //        gv_ItemPDF.DataSource = dt;
            //        gv_ItemPDF.DataBind();
            //    }
            //    else
            //    {
            //        foreach (ListItem inv in ListBox_INVSlno.Items)
            //        {
            //            inv.Selected = false;
            //        }

            //        ListBox_ItemSlno.Items.Clear();

            //        gv_ItemPDF.DataSource = null;
            //        gv_ItemPDF.DataBind();

            //        Alert_msg("No items with Empty CTH found!");
            //    }

            //    return;
            //}
            if (ddl_Select_ItemRITC.SelectedValue == "2")
            {
                if (GridViewData == null || GridViewData.Rows.Count == 0)
                {
                    Alert_msg("No data available!");
                    return;
                }

                var emptyRows = GridViewData.AsEnumerable()
                    .Where(x => string.IsNullOrWhiteSpace(x["HSCode"].ToString()))
                    .ToList();

                if (emptyRows.Count > 0)
                {
                    // ✅ DO NOT clear/re-populate ListBox_ItemSlno here
                    // The items were already populated by Select_ItemRITC()
                    // Just read what the user has manually selected

                    var selectedItems = ListBox_ItemSlno.Items.Cast<ListItem>()
                        .Where(x => x.Selected)
                        .ToList();

                    if (selectedItems.Count > 0)
                    {
                        // ✅ Use HashSet for .NET Framework 4.x compatibility
                        var selectedKeys = new HashSet<string>(selectedItems.Select(x => x.Value));

                        var filteredRows = emptyRows.Where(r =>
                        {
                            string key = r["InvoiceSlNo"].ToString() + "~" + r["ItemSlNo"].ToString();
                            return selectedKeys.Contains(key);
                        }).ToList();

                        if (filteredRows.Count > 0)
                        {
                            gv_ItemPDF.DataSource = filteredRows.CopyToDataTable();
                            gv_ItemPDF.DataBind();
                        }
                        else
                        {
                            gv_ItemPDF.DataSource = new DataTable();
                            gv_ItemPDF.DataBind();
                            Alert_msg("No matching rows found!");
                        }
                    }
                    else
                    {
                        // User clicked Apply Filter without selecting any item
                        Alert_msg("Please select at least one item from the list!");
                        gv_ItemPDF.DataSource = new DataTable();
                        gv_ItemPDF.DataBind();
                    }
                }
                else
                {
                    foreach (ListItem inv in ListBox_INVSlno.Items)
                        inv.Selected = false;
                    ListBox_ItemSlno.Items.Clear();
                    gv_ItemPDF.DataSource = new DataTable();
                    gv_ItemPDF.DataBind();
                    Alert_msg("No items with Empty CTH found!");
                }

                return;
            }


            if (ListBox_INVSlno.SelectedItem != null && ListBox_INVSlno.SelectedItem.Text != null && ListBox_ItemSlno.SelectedItem != null && ListBox_ItemSlno.SelectedItem.Text != null)
            {

                if (GridViewData != null && GridViewData.Rows.Count > 0)
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

                    ViewState["GridViewData"] = GridViewData;
                    ViewState["ItemDetails"] = GridViewData;
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
            else if (ddl_Select_ItemRITC.SelectedValue == "2") // ✅ Empty CTH
            {
                var emptyCTHRows = dt_GridViewData.AsEnumerable()
                    .Where(row => string.IsNullOrWhiteSpace(row["HSCode"].ToString()))
                    .ToList();

                ListBox_ItemSlno.Items.Clear();

                if (emptyCTHRows.Count > 0)
                {
                    // ✅ Collect unique invoice numbers from empty CTH rows
                    var emptyInvNos = emptyCTHRows
                        .Select(r => r["InvoiceSlNo"].ToString())
                        .Distinct()
                        .ToList();

                    // ✅ Select matching invoice numbers in ListBox_INVSlno
                    foreach (ListItem invItem in ListBox_INVSlno.Items)
                    {
                        invItem.Selected = emptyInvNos.Contains(invItem.Value);
                    }

                    // ✅ Add ALL empty CTH items to ListBox_ItemSlno and SELECT them all
                    foreach (DataRow row in emptyCTHRows.Select(r => r))
                    {
                        string invoiceSlno = row["InvoiceSlNo"].ToString();
                        string itemSlno = row["ItemSlNo"].ToString();
                        string itemText = invoiceSlno + "~" + itemSlno;

                        ListBox_ItemSlno.Items.Add(new ListItem(itemText, itemText) { Selected = true });
                    }

                    // ✅ Bind filtered rows to GridView
                    DataTable emptyCTHTable = emptyCTHRows.CopyToDataTable();
                    gv_ItemPDF.DataSource = emptyCTHTable;
                    gv_ItemPDF.DataBind();
                }
                else
                {
                    // Deselect all invoices
                    foreach (ListItem invItem in ListBox_INVSlno.Items)
                        invItem.Selected = false;

                    gv_ItemPDF.DataSource = new DataTable();
                    gv_ItemPDF.DataBind();
                    Alert_msg("No items with empty CTH found!");
                }
            }

            //else if (ddl_Select_ItemRITC.SelectedValue == "2")
            //{
            //    var emptyCTHRows = dt_GridViewData.AsEnumerable()
            //        .Where(row => string.IsNullOrWhiteSpace(row["HSCode"].ToString()))
            //        .ToList();

            //    ListBox_ItemSlno.Items.Clear();

            //    if (emptyCTHRows.Count > 0)
            //    {
            //        // ✅ Select the invoice numbers that have empty CTH items
            //        var emptyInvNos = emptyCTHRows
            //            .Select(r => r["InvoiceSlNo"].ToString())
            //            .Distinct()
            //            .ToList();

            //        foreach (ListItem invItem in ListBox_INVSlno.Items)
            //        {
            //            invItem.Selected = emptyInvNos.Contains(invItem.Value);
            //        }

            //        // ✅ Populate items but DO NOT pre-select — let user pick
            //        foreach (DataRow row in emptyCTHRows.Select(r => r))
            //        {
            //            string invoiceSlno = row["InvoiceSlNo"].ToString();
            //            string itemSlno = row["ItemSlNo"].ToString();
            //            string itemText = invoiceSlno + "~" + itemSlno;

            //            // ❌ Removed: Selected = true  — user selects manually
            //            ListBox_ItemSlno.Items.Add(new ListItem(itemText, itemText));
            //        }

            //        // ✅ Do NOT auto-bind grid — wait for user to select and click Apply Filter
            //        gv_ItemPDF.DataSource = new DataTable();
            //        gv_ItemPDF.DataBind();
            //    }
            //    else
            //    {
            //        foreach (ListItem invItem in ListBox_INVSlno.Items)
            //            invItem.Selected = false;

            //        gv_ItemPDF.DataSource = new DataTable();
            //        gv_ItemPDF.DataBind();
            //        Alert_msg("No items with empty CTH found!");
            //    }
            //}

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
        SqlCommand Exlcmd = new SqlCommand("select PDF_JOB_NO as 'JOB NO',PDF_EXP_IMP_NAME as 'EXP IMP NAME',PDF_MODE as MODE,PDF_UPLOAD_COUNT as 'UPLOAD COUNT',PDF_SAVE_COUNT as 'SAVE COUNT',PDF_REMARKS as 'PAGE COUNT',PDF_USER_ID as 'USER',PDF_DATE_TIME as 'DATE TIME',PDF_BRANCH_CODE as 'BRANCH CODE',PDF_WORKING_PERIOD as 'WORKING PERIOD' from PDF_AI_COUNT_DETAILS where PDF_MODE = 'EXI'", con);
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