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
using System.Linq;
using System.Data.OleDb;

using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using System.Collections.Specialized;
using System.Net;

using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Globalization;
using Microsoft.ApplicationBlocks.Data;


public partial class Import_Pdf_Reader_Import_PDFReader : System.Web.UI.Page
{
    AppSession aps = new AppSession();
    UserBO ObjUBO = new UserBO();
    //Export_General_New Export = new Export_General_New();
    UserBO objUBO = new UserBO();
    AdminMasterDetails admin = new AdminMasterDetails();
    Jobwise_xl_Upload xl = new Jobwise_xl_Upload();
    Import_PDF_Upload imp_pdf = new Import_PDF_Upload();
    Auto_Search Auto = new Auto_Search();
    ErrorLogs log = new ErrorLogs();
    Transaction Transact = new Transaction();

    DataTable Dt_gen = new DataTable();
    DataTable Dt_Invoice = new DataTable();
    DataTable Dt_Item = new DataTable();
    DataTable Dt_DBK = new DataTable();
    DataTable Dt_anx = new DataTable();

    DataSet ds_IEC = new DataSet();
    DataSet ds_draw = new DataSet();

    public String Xml_Inv;

    public int MAX_ID = 0; int i = 0;

    public string GENERAL_IMPORT_JOBNO = "", TRANSPORT_MODE = "";
    public string currentuser;
    public string currentbranch;
    public string Working_Period;
    public string COMPANY_IDD, comp_ConnectionStr, LoginDate,SELECT_BRANCH, SB_TYPE, JOBNO;
    public string a1 = "", a2 = "", a3 = "", a4 = "", a5 = "", a6 = "";

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
        //btnupload.Visible = true;

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

        // Initialize the import Job No once and keep the same value across postbacks.
        // If the calling page already supplied Jobno_Excel, use it; otherwise generate
        // the next Job No (same approach as the Export PDF reader).
        if (!IsPostBack)
        {
            Bind_Clients();

            string sessionJobNo = Session["Jobno_Excel"] != null
                ? Session["Jobno_Excel"].ToString().Trim()
                : string.Empty;

            if (!string.IsNullOrWhiteSpace(sessionJobNo))
            {
                GENERAL_IMPORT_JOBNO = sessionJobNo;
            }
            else
            {
                AUTO_JOBNO();
                GENERAL_IMPORT_JOBNO = txtjobPS.Text.Trim();
            }

            ViewState["GENERAL_IMPORT_JOBNO"] = GENERAL_IMPORT_JOBNO;
        }
        else
        {
            GENERAL_IMPORT_JOBNO = Convert.ToString(ViewState["GENERAL_IMPORT_JOBNO"]);
        }

        txtjobPS.Text = GENERAL_IMPORT_JOBNO;
    }

    public void AUTO_JOBNO()
    {
        JOBNO = Convert.ToString(Retrieve_JobNO());
        Session["JOBNO"] = JOBNO;
        txtjobPS.Text = JOBNO;
        JobNo_Prefix_Sufix(JOBNO);
    }

    public int Retrieve_JobNO()
    {
        int jobNo = 0;
        try
        {
            SqlParameter[] param = new SqlParameter[50];
            param[1] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[4] = new SqlParameter("@BRANCH_CODE", Connection.Get_Company_Type());
            param[2] = new SqlParameter("@MStatus", SqlDbType.Int, 1) { Direction = ParameterDirection.Output };
            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000) { Direction = ParameterDirection.Output };

            SqlHelper.ExecuteNonQuery(HttpContext.Current.Session["currentcomp_db"].ToString(),
                CommandType.StoredProcedure, "GENERAL_DETAILS_SP_AUTOID", param);

            jobNo = Convert.ToInt32(param[2].Value.ToString());
        }
        catch (Exception ex) { Connection.Error_Msg(ex.Message); }
        return jobNo;
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

        if (ds_client.Tables[0].Rows.Count > 0)
        {
            ddl_ImporterName.DataSource = ds_client.Tables[0];
            ddl_ImporterName.DataTextField = "IMPORTER_NAME";
            ddl_ImporterName.DataTextField = "IMPORTER_NAME";
            ddl_ImporterName.DataBind();
        }

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
            if (hdn_missed_Desc.Value == "1")
            {
                e.Row.Cells[1].ForeColor = System.Drawing.Color.Red;
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

    protected void btn_Refresh_Click(object sender, ImageClickEventArgs e)
    {
        Page_Load(sender, e);
    }

    protected void btnPrevData_Click(object sender, EventArgs e)
    {
        try
        {
            Get_Upload_File();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void btnupload_Click(object sender, EventArgs e)
    {
        try
        {
            Save_Upload_File();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public string Get_Upload_File()
    {
        string response = "";

        try
        {
            if (FilePDF.HasFile)
            {
                // Save the uploaded file to a temporary location or memory stream
                string FilePath = Server.MapPath("~/Submission/ImportPDFReader//") + FilePDF.FileName;
                FilePDF.SaveAs(FilePath);
                // Create a new MemoryStream to hold the multipart/form-data content
                using (MemoryStream formDataStream = new MemoryStream())
                {
                    // Create a StreamWriter to write to the form data stream
                    using (StreamWriter writer = new StreamWriter(formDataStream))
                    {
                        // Start the multipart/form-data header
                        writer.Write("--boundary\r\n");

                        // Add the file part
                        writer.Write("Content-Disposition: form-data;  name=\"File\"; filename=\"" + Path.GetFileName(FilePath) + "\"\r\n");
                        writer.Write("Content-Type: application/pdf\r\n\r\n");
                        writer.Flush();

                        // Write the file content
                        byte[] fileBytes = File.ReadAllBytes(FilePath);
                        formDataStream.Write(fileBytes, 0, fileBytes.Length);

                        DateTime dttime = DateTime.Now;

                        // Add additional parameters
                        NameValueCollection additionalParameters = new NameValueCollection
                    {
                        { "CompanyID",  Connection.Company_License() },
                        { "UserID", Connection.Current_User() },
                        { "BranchCode", Connection.Current_Branch() },
                        { "JobNo", txtjobPS.Text },
                        { "JobType", "IMP" },
                        { "WorkingPeriod", Connection.WorkingPeriod() },
                        { "PageCount", "0" },
                        { "PdfCount", "0" },
                        { "JobStatus", "N" },
                        { "FileName", "1" },
                        { "InvoiceStartTime", dttime.ToString() }
                    };

                        foreach (string key in additionalParameters)
                        {
                            // Add each additional parameter as a separate part
                            writer.Write("\r\n--boundary\r\n");
                            writer.Write("Content-Disposition: form-data; name=\"" + key + "\"\r\n\r\n");
                            writer.Write(additionalParameters[key]);
                        }

                        // End the multipart/form-data footer
                        writer.Write("\r\n--boundary--\r\n");
                    }

                    // Set the Content-Type header to multipart/form-data with the specified boundary
                    using (WebClient client = new WebClient())
                    {
                        client.Headers[HttpRequestHeader.ContentType] = "multipart/form-data; boundary=boundary";

                        client.Headers.Add("ApiKey", "12345");

                        // Send the POST request and receive the response
                        byte[] responseBytes = client.UploadData("http://ec2-3-87-226-16.compute-1.amazonaws.com:9000/ocr_service", "POST", formDataStream.ToArray());

                        // Handle the response as needed
                        response = Encoding.UTF8.GetString(responseBytes);

                        // Handle the response here
                        Console.WriteLine("Response: " + response);

                        ResponseData responseData = JsonConvert.DeserializeObject<ResponseData>(response);
                        txtSupplier.Text = responseData.Header[0].SupplierName;
                        hd_Supplier.Value = responseData.Header[0].SupplierName;
                        txtInvNo.Text = responseData.Header[0].InvoiceNo;
                        hd_InvNo.Value = responseData.Header[0].InvoiceNo;
                        txtInvDate.Text = responseData.Header[0].InvoiceDate;
                        hd_InvDate.Value = responseData.Header[0].InvoiceDate;
                        txtCountryOfOrigin.Text = responseData.Header[0].CountryOfOrigin;
                        txtPortOfOrigin.Text = responseData.Header[0].PortOfOrgin;
                        txtQTYCode.Text = responseData.Header[0].QtyCode;
                        txtCurrency.Text = responseData.Header[0].Currency;
                        hd_Currency.Value = responseData.Header[0].Currency;
                        txtTerms.Text = responseData.Header[0].Terms;
                        hd_Terms.Value = responseData.Header[0].Terms;
                        txtInvValue.Text = responseData.Header[0].InvoiceValue;
                        hd_InvValue.Value = responseData.Header[0].InvoiceValue;
                        //hd_CustomsHouse.Value = responseData.Header[0].CustomHouse;
                        hd_ImporterName.Value = responseData.Header[0].ImporterName;
                        hd_ImporterAdd1.Value = responseData.Header[0].ImporterAdd1;
                        hd_ImporterAdd2.Value = responseData.Header[0].ImporterAdd2;
                        hd_ImporterAdd3.Value = responseData.Header[0].ImporterAdd3;
                        hd_ImporterAdd4.Value = responseData.Header[0].ImporterAdd4;

                        Dt_Item.Columns.Add("ItemSlNo");
                        Dt_Item.Columns.Add("ItemDesc");
                        Dt_Item.Columns.Add("Quantity");
                        Dt_Item.Columns.Add("Rate");
                        Dt_Item.Columns.Add("Amount");
                        Dt_Item.Columns.Add("PartNo");
                        Dt_Item.Columns.Add("PONumber");
                        Dt_Item.Columns.Add("NetWeight");
                        Dt_Item.Columns.Add("HSCode");

                        int totalItemSlNo = responseData.ItemsDetails.Count;

                        for (int i = 0; i <= totalItemSlNo - 1; i++)
                        {
                            string ItemSlNo = responseData.ItemsDetails[i].ItemSlNo;
                            string ItemDesc = responseData.ItemsDetails[i].ItemDesc;
                            string Quantity = responseData.ItemsDetails[i].Quantity;
                            string Rate = responseData.ItemsDetails[i].Rate;
                            string Amount = responseData.ItemsDetails[i].Amount;
                            string PartNo = responseData.ItemsDetails[i].PartNo;
                            string PONumber = responseData.ItemsDetails[i].PONumber;
                            string NetWeight = responseData.ItemsDetails[i].NetWeight;
                            string HSCode = responseData.ItemsDetails[i].HSCode;

                            Dt_Item.Rows.Add(ItemSlNo, ItemDesc, Quantity, Rate, Amount, PartNo, PONumber, NetWeight, HSCode);
                        }
                        lblCount.Text = totalItemSlNo.ToString();

                        ViewState["ItemDetails"] = Dt_Item;
                        gv_ItemPDF.DataSource = Dt_Item;
                        gv_ItemPDF.DataBind();

                        lbl_loading.Text = "File Converted Successfully..Click Save";
                        btnupload.Visible = true;
                    }
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

    public void Save_Upload_File()
    {
        try
        {
            if (txtjobPS.Text != "" && txtjobPS.Text != string.Empty)
            {
                string id = "";
                string f = "S";
                i = insert_update(id, f);

                Alert_msg("Saved Successfully", "btnSave");
                lbl_loading.Text = "JOB Created Successfully";
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine("Error occurred: " + ex.Message);
        }
    }

    public void Alert_msg_Save(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GENERAL', function (r) {Import_session();document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public class Header
    {
        public string CompanyID { get; set; }
        public string UserID { get; set; }
        public string BranchCode { get; set; }
        public string JobNo { get; set; }
        public string SupplierName { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public string CountryOfOrigin { get; set; }
        public string PortOfOrgin { get; set; }
        public string QtyCode { get; set; }
        public string Currency { get; set; }
        public string Terms { get; set; }
        public string InvoiceValue { get; set; }
        public string CustomHouse { get; set; }
        public string ImporterName { get; set; }
        public string ImporterAdd1 { get; set; }
        public string ImporterAdd2 { get; set; }
        public string ImporterAdd3 { get; set; }
        public string ImporterAdd4 { get; set; }
    }

    public class ItemsDetails
    {
        public string ItemSlNo { get; set; }
        public string ItemDesc { get; set; }
        public string Quantity { get; set; }
        public string Rate { get; set; }
        public string Amount { get; set; }
        public string PartNo { get; set; }
        public string PONumber { get; set; }
        public string NetWeight { get; set; }
        public string HSCode { get; set; }
    }

    public class ResponseData
    {
        public List<Header> Header { get; set; }
        public List<ItemsDetails> ItemsDetails { get; set; }
    }

    public int insert_update(string jobid, string flag)
    {

        string ImporterNameBranch = ddl_ImporterName.SelectedItem.Text;
        int index = ImporterNameBranch.IndexOf("--");
        string Branch = ImporterNameBranch.Substring(0, index);
        string Importer = ImporterNameBranch.Substring(index + 2);

        //General
        Transact.JOBID = jobid;
        Transact.JOBNO = txtjobPS.Text;
        //DateTime TodayDate = DateTime.ParseExact(DateTime.Now.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
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

        //Transact.IMP_EXP_TYPE = ddl_ImporterName.SelectedItem.Text;
        Transact.USER_ID = currentuser;
        Transact.flag = flag;
        Transact.BRANCH_CODE = currentbranch;
        Transact.WORKING_PERIOD = Working_Period;
        JobNo_Prefix_Sufix(txtjobPS.Text);
        Transact.JOBNO_PS = Session["JOBNO_PS"].ToString();

        Transact.JOB_PREFIX = hdprefix.Value.ToString();
        Transact.JOB_SUFFIX = hdsuffix.Value.ToString();
        Transact.PAYMENT_METHOD_CODE = "T";

        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();
        Auto.Ename = "Import_Details_Bind";
        Auto.Enamesearch = Importer;
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
        }

        ds.Clear();
        Auto.Ename = "Get_ADCODE";
        Auto.Enamesearch = Importer;
        Auto.NSearch = Transact.IEC_NO;
        ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
        if (ds.Tables[0].Rows.Count > 0)
        {
            Transact.ADCODE = ds.Tables[0].Rows[0]["IMPORT_ADCODE"].ToString();
        } 

        i = Transact.General_details_insertupdate();

        ds.Clear();
        GetJobId();       

        //Invoice
        Transact.INVOICE_NO = hd_InvNo.Value.ToUpper();
        if (hd_InvDate.Value != "")
        {
            Transact.INVOICE_DATE = hd_InvDate.Value;
        }
        else
        {
            Transact.INVOICE_DATE = "01/01/1900";
        }
        Transact.TERMS = hd_Terms.Value;
        Transact.INVOICE_CURRENCY = hd_Currency.Value.ToUpper();
        Transact.MIS_CURRENCY = hd_Currency.Value.ToUpper();
        Transact.MIS_AGENCY_CURRENCY = hd_Currency.Value.ToUpper();
        Transact.MIS_DISCOUNT_CURRENCY = hd_Currency.Value.ToUpper();
        Transact.MIS_FREIGHT_CURRENCY = hd_Currency.Value.ToUpper();
        Transact.MIS_INSURANCE_CURRENCY = hd_Currency.Value.ToUpper();

        string invoiceValue = hd_InvValue.Value;
        string InvoiceValueRemoveComa = invoiceValue.Replace(",", "");
        Transact.INVOICE_VALUE = InvoiceValueRemoveComa;

        Auto.Ename = "EXCHANGE_MASTER_RATE_EXPORTWISE";
        Auto.Enamesearch = hd_Currency.Value.ToUpper();
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

            if (hd_Terms.Value =="FOB")
            {
                Transact.MIS_FREIGHT_RATE ="20.0000";
                Transact.MIS_INSURANCE_RATE ="1.1250";
            }
            else if (hd_Terms.Value == "CI")
            {
                Transact.MIS_FREIGHT_RATE = "20.0000";
            }
            else if (hd_Terms.Value == "CF")
            {
                Transact.MIS_INSURANCE_RATE = "1.1250";
            }
        }

        Transact.SUPPLIER_NAME = hd_Supplier.Value;
        Auto.Ename = "SUPPLIER_MASTER_SEARCH";
        Auto.Enamesearch = hd_Supplier.Value;
        ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
        if (ds.Tables[0].Rows.Count > 0)
        {
            Transact.SUPPLIER_ADDRESS = ds.Tables[0].Rows[0]["SUP_ADD1"].ToString();
            Transact.SUPPLIER_ADDRESS1 = ds.Tables[0].Rows[0]["SUP_ADD2"].ToString();
            Transact.SUPPLIER_ADDRESS2 = ds.Tables[0].Rows[0]["SUP_ADD3"].ToString();
        }

        adminmaster Admin_mas = new adminmaster();
        Admin_mas.EImpName = Importer;
        Admin_mas.ESupName = hd_Supplier.Value;
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

        Transact.OTHER_PURCHASE_ORDER_DATE = "01/01/1900";
        Transact.OTHER_CONTRACT_DATE = "01/01/1900";
        Transact.OTHER_LOC_DATE = "01/01/1900";
        Transact.NON_STD_CERTIFICATE_DATE = "01/01/1900";
        Transact.SHIP_DATE = "01/01/1900";
        Transact.SVB_REF_DATE = "01/01/1900";
        Transact.flag = "S";
        Transact.USER_ID = currentuser;
        Transact.BRANCH_CODE = currentbranch;
        Transact.WORKING_PERIOD = Working_Period;
        Transact.Invoice_Details_insertupdate();

        i = Transact.result;

        //Product
        DataTable dtItem = (ViewState["ItemDetails"]) as DataTable;
        string SELECT_BRANCH = Connection.Get_Company_Type();
        string GetPartNo = "", GetPoNo="", GetNetWeight="";
        if (dtItem.Rows.Count > 0)
        {
            for (int j = 0; j <= dtItem.Rows.Count - 1; j++)
            {
                string ITEM_DESCRIPTION = dtItem.Rows[j]["ItemDesc"].ToString();
                Transact.ITEM_QTY = dtItem.Rows[j]["Quantity"].ToString();
                Transact.ITEM_QTY_CODE = txtQTYCode.Text;

                string MaterialRate = dtItem.Rows[j]["Rate"].ToString();
                string MaterialRateRemoveCama = MaterialRate.Replace(",", "");
                Transact.ITEM_UNIT_PRICE = MaterialRateRemoveCama;
                Transact.ITEM_UNIT_CODE = hd_Currency.Value.ToUpper();

                string MaterialAmount = dtItem.Rows[j]["Amount"].ToString();
                string MaterialAmountRemoveCama = MaterialAmount.Replace(",", "");
                Transact.ITEM_TOTAL_AMOUNT = MaterialAmountRemoveCama;
                GetPartNo = dtItem.Rows[j]["PartNo"].ToString();
                GetPoNo = dtItem.Rows[j]["PONumber"].ToString();
                GetNetWeight = dtItem.Rows[j]["NetWeight"].ToString();

                Transact.ITEM_AMOUNT_CODE = hd_Currency.Value.ToUpper();
                Transact.PREVIOUS_BE_DATE = "01/01/1900";
                Transact.flag = "S";
                Transact.YEAR = "";
                Transact.USER_ID = currentuser;
                Transact.BRANCH_CODE = currentbranch;
                Transact.WORKING_PERIOD = Working_Period;
                Transact.INV_SLNO = "1";
                Transact.JOBNO = Transact.JOBNO;
                Transact.BRANCH_COMMON = SELECT_BRANCH;

                eroyalmaster erm = new eroyalmaster();
                erm.IMPORTER_NAME = Importer;
                erm.IEC_NO = Transact.IEC_NO;
                erm.ADCODE = Transact.ADCODE;
                erm.BRANCH_NO = Transact.BRANCH_NO;
                erm.PARTNO = GetPartNo;
                erm.Eproduct_imp_description = ITEM_DESCRIPTION;
                erm.Ename = "Select_Whole_Data";
                DataSet dsGetPDFData = erm.RetrieveAll_Product_import_PDF_MASTER();

                //Masters

                if (dsGetPDFData.Tables[0].Rows.Count > 0)
                {
                    string POTYPE = dsGetPDFData.Tables[0].Rows[0]["PO_TYPE"].ToString();
                    Transact.ITEM_DESCRIPTION = (GetPartNo + " " + ITEM_DESCRIPTION + " For Manufacturing Of " + POTYPE).ToString();
                    string PRODUCT_RITC = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_RITC"].ToString();

                    ds.Clear();
                    Auto.Ename = "Get_CTH_Info_Uqc";
                    Auto.Enamesearch = PRODUCT_RITC;
                    Auto.Notn_No_Search = PRODUCT_RITC;
                    ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Transact.Info_Uqc = ds.Tables[0].Rows[0][0].ToString();
                        if (Transact.Info_Uqc == "KGS")
                        {
                            Transact.Info_Msr = GetNetWeight;
                        }
                        else
                        {
                            Transact.Info_Msr = Transact.ITEM_QTY;
                        }
                    }

                    // GENERAL  //
                    Transact.CTH_NO = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_CTH"].ToString();
                    Transact.GENEARL_DESCRIPTION = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_GENERAL_DESC"].ToString();
                    Transact.MANUFACTURER = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_MANUFACTURER"].ToString();
                    Transact.BRAND = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_BRAND"].ToString();
                    Transact.MODEL = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_MODEL"].ToString();
                    Transact.END_USE_OF_ITEM = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_END_USE"].ToString();
                    Transact.COUNTRY_OF_ORIGIN = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_COUNTRY_ORIGIN"].ToString();
                    Transact.ACCESSORIES = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_ACCESSORIES"].ToString();
                    // CTH  //
                    Transact.SCHEME_CODE = "00 - DUTIABLE";
                    Transact.PRODUCT_RITC = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_RITC"].ToString();
                    Transact.PRODUCT_CTH = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_CTH"].ToString();

                    string FTA_YES_NO = dsGetPDFData.Tables[0].Rows[0]["FTA_YES_NO"].ToString();
                    if (FTA_YES_NO == "NO")
                    {
                        Transact.PRODUCT_BCD_SLNO = "";
                        Transact.PRODUCT_BCD_NOTN = "";
                    }
                    else
                    {
                        Transact.PRODUCT_BCD_NOTN = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_BCD_NOTN"].ToString();
                        Transact.PRODUCT_BCD_SLNO = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_BCD_SLNO"].ToString();
                    }

                    Transact.PRODUCT_BCD_RATE = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_BCD_RATE"].ToString();
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
                    Transact.SOCIAL_WELFARE_NOTN = dsGetPDFData.Tables[0].Rows[0]["SOCIAL_WELFARE_NOTN"].ToString();
                    Transact.SOCIAL_WELFARE_NOTN_SLNO = dsGetPDFData.Tables[0].Rows[0]["SOCIAL_WELFARE_NOTN_SLNO"].ToString();
                    Transact.SOCIAL_WELFARE_RATE = dsGetPDFData.Tables[0].Rows[0]["SOCIAL_WELFARE_RATE"].ToString();
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
                    Transact.AIDC_NOTN = dsGetPDFData.Tables[0].Rows[0]["AIDC_NOTN"].ToString();
                    Transact.AIDC_NOTN_SLNO = dsGetPDFData.Tables[0].Rows[0]["AIDC_NOTN_SLNO"].ToString();
                    Transact.AIDC_RATE = dsGetPDFData.Tables[0].Rows[0]["AIDC_RATE"].ToString();
                    //Transact.ADD_EX_RATE = txt_ADD_ExRate.Text.Trim();

                    // CETH //
                    Transact.PRODUCT_CETH = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_CETH"].ToString();
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
                    Transact.IGST_LEVY_NOTN = dsGetPDFData.Tables[0].Rows[0]["IGST_LEVY_NOTN"].ToString();
                    Transact.IGST_LEVY_SLNO = dsGetPDFData.Tables[0].Rows[0]["IGST_LEVY_SLNO"].ToString();
                    Transact.IGST_LEVY_RATE = dsGetPDFData.Tables[0].Rows[0]["IGST_LEVY_RATE"].ToString();
                    Transact.IGST_LEVY_SPL = dsGetPDFData.Tables[0].Rows[0]["IGST_LEVY_SPL"].ToString();
                    Transact.IGST_LEVY_UNIT = dsGetPDFData.Tables[0].Rows[0]["IGST_LEVY_UNIT"].ToString();
                    Transact.IGST_LEVY_SPL_TYPE = dsGetPDFData.Tables[0].Rows[0]["IGST_LEVY_SPL_TYPE"].ToString();
                    Transact.IGST_LEVY_EXCEPTION_NOTN = dsGetPDFData.Tables[0].Rows[0]["IGST_LEVY_EXCEPTION_NOTN"].ToString();
                    Transact.IGST_LEVY_EXCEPTION_SLNO = dsGetPDFData.Tables[0].Rows[0]["IGST_LEVY_EXCEPTION_SLNO"].ToString();
                    Transact.IGST_LEVY_EXCEPTION_RATE = dsGetPDFData.Tables[0].Rows[0]["IGST_LEVY_EXCEPTION_RATE"].ToString();
                    Transact.IGST_LEVY_COMPENSATION_CESS_NOTN = dsGetPDFData.Tables[0].Rows[0]["IGST_LEVY_COMPENSATION_CESS_NOTN"].ToString();
                    Transact.IGST_LEVY_COMPENSATION_CESS_SLNO = dsGetPDFData.Tables[0].Rows[0]["IGST_LEVY_COMPENSATION_CESS_SLNO"].ToString();
                    Transact.IGST_LEVY_COMPENSATION_CESS_RATE = dsGetPDFData.Tables[0].Rows[0]["IGST_LEVY_COMPENSATION_CESS_RATE"].ToString();
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

                    DataSet dss = Transact.Item_Details_insertupdate();
                }
            }
        }

        return i;
    }

    public DataSet GetJobId()
    {
        DataSet ds = new DataSet();
        try
        {
            Transact.JOBNO = Transact.JOBNO;
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
        catch(Exception ex)
        {
            Session["JOBIDexcel"] = "";
        }
        return ds;

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
                        // txtjobPS.Text = ((dats.Tables[0].Rows[0][0].ToString() + "/" + txtJobNo.Text).TrimEnd()).TrimStart();
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
                        //txtjobPS.Text = ((dats.Tables[0].Rows[0][0].ToString() + "/" + txtJobNo.Text + "/" + dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();

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
}