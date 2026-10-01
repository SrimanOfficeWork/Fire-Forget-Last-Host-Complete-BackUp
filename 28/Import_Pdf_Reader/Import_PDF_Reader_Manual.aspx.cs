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

using System;
using System.Data;
using System.IO;
using System.Web;


using ClosedXML.Excel;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

//using iTextSharp.text.pdf;
//using iTextSharp.text.pdf.parser;

//using PdfSharp.Pdf;
//using OfficeOpenXml;

//using Aspose.Cells;


public partial class Import_PDF_Reader : ThemeClass
{
    AppSession aps = new AppSession();
    UserBO ObjUBO = new UserBO();
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

    public string GENERAL_IMPORT_JOBNO = "", TRANSPORT_MODE = "";
    public string currentuser;
    public string currentbranch;
    public string Working_Period;
    public string COMPANY_IDD, comp_ConnectionStr, LoginDate, SELECT_BRANCH, SB_TYPE, JOBNO;

    public int MAX_ID = 0; int i = 0;

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



        if (Session["Jobno_Excel"] != null || Session["Jobno_Excel"] != null)
        {
            GENERAL_IMPORT_JOBNO = Session["Jobno_Excel"].ToString();
        }
        txtjobPS.Text = GENERAL_IMPORT_JOBNO;
        Hdn_STANDARD_TYPE.Value = "STD";
        //btnupload.Visible = true;
        if (!IsPostBack)
        {
            Bind_Clients();

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

    public void Tbl_Columns()
    {

        //--------Dt_gen------------
        Dt_gen.Columns.Add("EXPORTER_NAME");
        Dt_gen.Columns.Add("BRANCH_NO");
        Dt_gen.Columns.Add("CONSIGNEE_NAME");
        Dt_gen.Columns.Add("CONSIGNEE_BRANCHSLNO");
        Dt_gen.Columns.Add("TRANSPORT_MODE");
        Dt_gen.Columns.Add("CUSTOMS_HOUSE");
        Dt_gen.Columns.Add("COUNTRY_DISCHARGE");
        Dt_gen.Columns.Add("PORT_DISCHARGE");
        Dt_gen.Columns.Add("COUNTRY_FINAL_DEST");
        Dt_gen.Columns.Add("PORT_FINAL_DEST");
        Dt_gen.Columns.Add("STATE_OF_EXPORT");
        Dt_gen.Columns.Add("MARKS_NO");
        Dt_gen.Columns.Add("ADCODE");

        //--------Dt_anx------------
        Dt_anx.Columns.Add("ANNEX_SEA_FAC_STUFFED");
        Dt_anx.Columns.Add("ANNEX_SEA_SAMPLE_ACCOM");
        Dt_anx.Columns.Add("ANNEX_SEA_NATURE_OF_CARGO");
        Dt_anx.Columns.Add("ANNEX_SEA_MARKS_NOS");
        Dt_anx.Columns.Add("ANNEX_SEA_TOTAL_PACKAGES");
        Dt_anx.Columns.Add("ANNEX_SEA_NO_CONTAINERS");
        Dt_anx.Columns.Add("ANNEX_SEA_UNIT_MEASUREMENT");
        Dt_anx.Columns.Add("ANNEX_SEA_SEAL_TYPE");
        Dt_anx.Columns.Add("ANNEX_SEA_GROSS_WEIGHT");
        Dt_anx.Columns.Add("ANNEX_SEA_NET_WEIGHT");
        Dt_anx.Columns.Add("ANNEX_SEA_PKG_UNIT_CODE");

        //--------Dt_Invoice------------
        Dt_Invoice.Columns.Add("INVOICE_SLNO");
        Dt_Invoice.Columns.Add("INVOICE_NO");
        Dt_Invoice.Columns.Add("INVOICE_DATE");
        Dt_Invoice.Columns.Add("PAYMENT_METHOD");
        Dt_Invoice.Columns.Add("PERIOD_PAYMENT");
        Dt_Invoice.Columns.Add("INVOICE_VALUE");
        Dt_Invoice.Columns.Add("INVOICE_CURRENCY");
        Dt_Invoice.Columns.Add("EXCHANGE_RATE");
        Dt_Invoice.Columns.Add("CONTRACT_NO");
        Dt_Invoice.Columns.Add("TERMS");
        Dt_Invoice.Columns.Add("BUYER");
        Dt_Invoice.Columns.Add("BUYER_NAME");
        Dt_Invoice.Columns.Add("AUTHORIZED_ECONOMIC_OPERATOR_CODE");
        Dt_Invoice.Columns.Add("A_E_O_COUNTRY");
        Dt_Invoice.Columns.Add("AUTHORIZED_ECONOMIC_OPERATOR");

        //--------Dt_Item------------
        Dt_Item.Columns.Add("INVOICE_SLNO");
        Dt_Item.Columns.Add("INVOICE_NO");
        Dt_Item.Columns.Add("ITEM_SLNO");
        Dt_Item.Columns.Add("ITEM_DESC");
        Dt_Item.Columns.Add("ITEM_QTY");
        Dt_Item.Columns.Add("ITEM_QTY_CODE");
        Dt_Item.Columns.Add("ITEM_UNITPRICE");
        Dt_Item.Columns.Add("ITEM_AMOUNT");
        Dt_Item.Columns.Add("STATE_OF_ORIGIN");
        Dt_Item.Columns.Add("DISTRICT_OF_ORIGIN");
        Dt_Item.Columns.Add("UNDER_PTA_FTA");
        Dt_Item.Columns.Add("INFO_MSR");
        Dt_Item.Columns.Add("IGST_PAYMENT");
        Dt_Item.Columns.Add("IGST_RATE");

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
            DataSet ds_gv_Output = new DataSet();

            string Imp_name = "", branch_slno = "";
            if (ddl_ImporterName.SelectedValue.Contains("--"))
            {
                string[] sp = ddl_ImporterName.SelectedValue.Replace("--", "^").Split('^');
                branch_slno = sp[0];
                Imp_name = sp[1];

                ViewState["branch_slno"] = branch_slno;
                ViewState["Imp_name"] = Imp_name;

            }

            ds_gv_Output = PDF_Convert_xlsx_to_Datatable(Imp_name, branch_slno);
            ViewState["ds_Header_Output"] = ds_gv_Output;

            if (ds_gv_Output.Tables[0].Rows.Count > 0 && ds_gv_Output.Tables[1].Rows.Count > 0)
            {
                txtSupplier.Text = ds_gv_Output.Tables[0].Rows[0]["SupplierName"].ToString();
                hd_Supplier.Value = txtSupplier.Text;
                txtInvNo.Text = ds_gv_Output.Tables[0].Rows[0]["invNo"].ToString();
                hd_InvNo.Value = txtInvNo.Text;
                txtInvDate.Text = ds_gv_Output.Tables[0].Rows[0]["invDate"].ToString();
                hd_InvDate.Value = txtInvDate.Text;
                
                txtPortOfOrigin.Text = ds_gv_Output.Tables[0].Rows[0]["prtOfDschrg"].ToString();
               
                txtCurrency.Text = ds_gv_Output.Tables[0].Rows[0]["Currency"].ToString();
                hd_Currency.Value = txtCurrency.Text;
                if (Imp_name == "COGNEX SENSORS INDIA PRIVATE LIMITED")
                {
                    txtTerms.Text = "CIF" ;
                    txtQTYCode.Text = "NOS" ;
                    txtCountryOfOrigin.Text = ds_gv_Output.Tables[1].Rows[0]["COUNTRY_OF_ORIGIN"].ToString();
                }
                else{
                    txtCountryOfOrigin.Text = ds_gv_Output.Tables[0].Rows[0]["cntyDec"].ToString();
                txtTerms.Text = ds_gv_Output.Tables[0].Rows[0]["Terms"].ToString();
                txtQTYCode.Text = ds_gv_Output.Tables[0].Rows[0]["Qtycode"].ToString();
                }                
                hd_Terms.Value = txtTerms.Text;
                txtInvValue.Text = ds_gv_Output.Tables[0].Rows[0]["inv_val"].ToString().Replace(",", "");
                hd_InvValue.Value = txtInvValue.Text;

                hd_ImporterName.Value = ds_gv_Output.Tables[0].Rows[0]["ImporterName"].ToString();
                hd_ImporterAdd1.Value = ds_gv_Output.Tables[0].Rows[0]["ImporterAdd1"].ToString();
                hd_ImporterAdd2.Value = ds_gv_Output.Tables[0].Rows[0]["ImporterAdd2"].ToString();
                hd_ImporterAdd3.Value = ds_gv_Output.Tables[0].Rows[0]["ImporterAdd3"].ToString();
                hd_ImporterAdd4.Value = ds_gv_Output.Tables[0].Rows[0]["ImporterAdd4"].ToString();

                lblCount.Text = ds_gv_Output.Tables[1].Rows.Count.ToString();
            }

            DataTable dt_gvew = new DataTable();
            dt_gvew.Columns.Add("ITEM_SLNO");
            dt_gvew.Columns.Add("ITEM_DESC");
            dt_gvew.Columns.Add("ITEM_QTY");
            dt_gvew.Columns.Add("ITEM_QTY_CODE");
            dt_gvew.Columns.Add("ITEM_UNITPRICE");
            dt_gvew.Columns.Add("ITEM_UNITCODE");
            dt_gvew.Columns.Add("ITEM_AMOUNT");
            dt_gvew.Columns.Add("HSN_CODE");
            dt_gvew.Columns.Add("COUNTRY_OF_ORIGIN");

            foreach (DataColumn col in ds_gv_Output.Tables[1].Columns)
            {
                if (col.ColumnName.Contains("Item"))
                {
                    ds_gv_Output.Tables[1].Columns[col.ColumnName].ColumnName = "ITEM_DESC";
                }
                if (col.ColumnName.Contains("Quantity") || col.ColumnName.Contains("QtyUOM"))
                {
                    ds_gv_Output.Tables[1].Columns[col.ColumnName].ColumnName = "ITEM_QTY";
                }
                if ((col.ColumnName.Contains("Rate") || col.ColumnName.Contains("UnitPrice")) && !col.ColumnName.Contains("Info_Unitprice"))
                {
                    ds_gv_Output.Tables[1].Columns[col.ColumnName].ColumnName = "ITEM_UNITPRICE";
                }
                if (col.ColumnName.Contains("TotalPrice") || col.ColumnName.Contains("AMOUNT"))
                {
                    ds_gv_Output.Tables[1].Columns[col.ColumnName].ColumnName = "ITEM_AMOUNT";
                }

            }

            string desc = "", hanger_qty = "";

            for (int cc = 0; cc <= ds_gv_Output.Tables[1].Rows.Count - 1; cc++)
            {
                 desc = ds_gv_Output.Tables[1].Rows[cc]["ITEM_DESC"].ToString();    

                //Get Qty Code from Item Details Method - Tables[1]
                hanger_qty = ds_gv_Output.Tables[1].Rows[cc]["ITEM_DESC"].ToString().Contains("HANGER") ? "KGS" : ds_gv_Output.Tables[1].Rows[0]["ITEM_QTY"].ToString();


                if (hanger_qty.Contains(" "))
                {
                    string[] hq = hanger_qty.Split(' ');
                    hanger_qty = hq[1];
                }
                else
                {
                    hanger_qty = ds_gv_Output.Tables[0].Rows[0]["Qtycode"].ToString();
                }


                dt_gvew.Rows.Add(cc + 1, desc.Replace("\n", " ").Replace("\r", " "), ds_gv_Output.Tables[1].Rows[cc]["ITEM_QTY"].ToString().Replace("(", "").Replace(")", "").Replace("NOS", "").Replace("KGS", "").Replace(" ", ""), Get_Valid_Qty_Code(hanger_qty)
                    , ds_gv_Output.Tables[1].Rows[cc]["ITEM_UNITPRICE"].ToString().Replace("-", "") == "" ? ds_gv_Output.Tables[1].Rows[cc][ds_gv_Output.Tables[1].Columns.IndexOf("ITEM_UNITPRICE") + 1].ToString() : ds_gv_Output.Tables[1].Rows[cc]["ITEM_UNITPRICE"].ToString().Replace("-", "")
                    , ds_gv_Output.Tables[0].Rows[0]["Currency"].ToString(), ds_gv_Output.Tables[1].Rows[cc]["ITEM_AMOUNT"].ToString().Replace(",", ""), ds_gv_Output.Tables[1].Rows[cc]["HSN_CODE"].ToString(), ds_gv_Output.Tables[1].Rows[cc]["COUNTRY_OF_ORIGIN"].ToString());
            }

            DataTable dt_dbk = new DataTable();
            imp_pdf.IMPORTER_NAME = Imp_name;
            imp_pdf.BRANCH_NO = branch_slno;
            imp_pdf.JOBNO = JOBNO;
            imp_pdf.flag = "Select_Except_desc_from_Master";
            imp_pdf.USER_ID = currentuser;
            imp_pdf.WORKINGPERIOD = Working_Period;
            imp_pdf.Branch_Code = currentbranch;
            DataSet dsCheckMasterData = imp_pdf.Imp_PDF_Upload_New_XML(Dt_gen, dt_gvew, dt_dbk, Dt_Invoice, Dt_anx);

            if (dsCheckMasterData.Tables[0].Rows.Count > 0)
            {
                lbl_loading.Text = "Records not available in Master";
                hdn_missed_Desc.Value = "1";
                gv_ItemPDF.DataSource = dsCheckMasterData.Tables[0];
                gv_ItemPDF.DataBind();
                btnupload.Visible = false;
            }
            else
            {
                lbl_loading.Text = "File converted successfully..Click Upload";
                hdn_missed_Desc.Value = "0";

                gv_ItemPDF.DataSource = dt_gvew;
                gv_ItemPDF.DataBind();
                btnupload.Visible = true;
                ViewState["HeaderItemDetails"] = dt_gvew;
            }
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
            Connection.Error_Msg(ex.Message);
        }
    }
    public DataSet PDF_Convert_xlsx_to_Datatable(string Client_Name, string Brslno)
    {

        DataSet ds_gv_Output = new DataSet();
        DataSet ds_output = new DataSet();

        string savePath = Server.MapPath("~/Submission/ImportPDFReader/");
        if (Directory.Exists(savePath) == false)
        {
            Directory.CreateDirectory(savePath);
        }

        if (FilePDF.HasFile)
        {
            foreach (FileInfo fileInformation in new DirectoryInfo(savePath).GetFiles())
            {
                File.Delete(fileInformation.FullName);
            }

            //Imp_PDFReader reader = new Imp_PDFReader();
            //string strFolderPath;
            //string strImagePath;

            //strFolderPath = Path.Combine(Request.PhysicalApplicationPath, savePath);
            //strImagePath = Path.Combine(strFolderPath, FilePDF.FileName.ToString());

            //FilePDF.SaveAs(strImagePath);
            //ConvertPdfToExcel(strImagePath, strImagePath);
            //ConvertPdfToExcel(strImagePath, strFolderPath);

            string strFolderPath;
            string strImagePath;

            strFolderPath = Path.Combine(Request.PhysicalApplicationPath, savePath);
            strImagePath = Path.Combine(strFolderPath, FilePDF.FileName.ToString());

            FilePDF.SaveAs(strImagePath);

            string fNamewithoutex = Path.GetFileNameWithoutExtension(strImagePath);
            Imp_PDFReader reader = new Imp_PDFReader();
            Document pdfDocument = new Document(strImagePath);
            ViewState["fileNamewithoutextn"] = fNamewithoutex;

            if (File.Exists(savePath + "Output/" + fNamewithoutex + ".xlsx"))
            {
            }
            else
            {
                ExcelSaveOptions options = new ExcelSaveOptions();
                fNamewithoutex = Path.GetFileNameWithoutExtension(strImagePath);

                strFolderPath = Path.Combine(Request.PhysicalApplicationPath, savePath + "Output/" + fNamewithoutex + ".xlsx");
                string savePath1 = Server.MapPath("~/Submission/ImportPDFReader/Output/");
                if (Directory.Exists(savePath1) == false)
                {
                    Directory.CreateDirectory(savePath1);
                }
                strImagePath = Path.Combine(strFolderPath);
                pdfDocument.Save(strImagePath, options);
            }


            lblmsg.Visible = true;
            DirectoryInfo d = new DirectoryInfo(strImagePath); //Assuming Test is your Folder

            //Read the Output Excel File
            lblmsg.Visible = true;
            string _custval = string.Empty;
            string _filepath = string.Empty;

            _filepath = savePath + "Output\\" + fNamewithoutex + ".xlsx";

            string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + _filepath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";


            OleDbConnection conn = new OleDbConnection(connString);
            DataTable dtt = new DataTable();
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            DataTable dtSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

            string query = "";
            if (dtSchema.Rows.Count == 1)
            {
                // Only one sheet
                string firstSheetName = dtSchema.Rows[0].Field<string>("TABLE_NAME");
                query = string.Format("SELECT * FROM [{0}]", firstSheetName);
                OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
                da.Fill(ds_output, "Sheet1");
                da.Dispose();
            }
            else if (dtSchema.Rows.Count > 1)
            {
                // Multiple sheets
                int sheet_cnt = 1;
                foreach (DataRow sheetRow in dtSchema.Rows)
                {
                    string sheetName = sheetRow.Field<string>("TABLE_NAME");
                    query = string.Format("SELECT * FROM [{0}]", sheetName);
                    OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
                    DataTable dtS12 = new DataTable("Sheet" + sheet_cnt);
                    da.Fill(dtS12);
                    ds_output.Tables.Add(dtS12);
                    da.Dispose();
                    sheet_cnt++;
                }
            }

            ds_gv_Output = reader.getCustInvDetls_Excel_Datatable(Client_Name, _filepath, ds_output);
        }
        return ds_gv_Output;
    }
    //public DataSet PDF_Convert_xlsx_to_Datatable(string Client_Name, string Brslno)
    //{

    //    DataSet ds_gv_Output = new DataSet();
    //    DataSet ds_output = new DataSet();

    //    string savePath = Server.MapPath("~/Submission/ImportPDFReader/");
    //    if (Directory.Exists(savePath) == false)
    //    {
    //        Directory.CreateDirectory(savePath);
    //    }

    //    if (FilePDF.HasFile)
    //    {
    //        foreach (FileInfo fileInformation in new DirectoryInfo(savePath).GetFiles())
    //        {
    //            File.Delete(fileInformation.FullName);
    //        }

    //        // //Imp_PDFReader reader = new Imp_PDFReader();
    //        // //string strFolderPath;
    //        // //string strImagePath;

    //        // //strFolderPath = Path.Combine(Request.PhysicalApplicationPath, savePath);
    //        // //strImagePath = Path.Combine(strFolderPath, FilePDF.FileName.ToString());

    //        // //FilePDF.SaveAs(strImagePath);
    //        // //ConvertPdfToExcel(strImagePath, strImagePath);
    //        // //ConvertPdfToExcel(strImagePath, strFolderPath);

    //        string strFolderPath;
    //        string strImagePath;

    //        strFolderPath = Path.Combine(Request.PhysicalApplicationPath, savePath);
    //        strImagePath = Path.Combine(strFolderPath, FilePDF.FileName.ToString());

    //        FilePDF.SaveAs(strImagePath);

    //        string fNamewithoutex = Path.GetFileNameWithoutExtension(strImagePath);
    //        Imp_PDFReader reader = new Imp_PDFReader();
    //        Document pdfDocument = new Document(strImagePath);
    //        ViewState["fileNamewithoutextn"] = fNamewithoutex;

    //        if (File.Exists(savePath + "Output/" + fNamewithoutex + ".xlsx"))
    //        {
    //        }
    //        else
    //        {
    //            //ExcelSaveOptions options = new ExcelSaveOptions();
    //            //fNamewithoutex = Path.GetFileNameWithoutExtension(strImagePath);

    //            //strFolderPath = Path.Combine(Request.PhysicalApplicationPath, savePath + "Output/" + fNamewithoutex + ".xlsx");
    //            //string savePath1 = Server.MapPath("~/Submission/ImportPDFReader/Output/");
    //            //if (Directory.Exists(savePath1) == false)
    //            //{
    //            //    Directory.CreateDirectory(savePath1);
    //            //}
    //            //strImagePath = Path.Combine(strFolderPath);
    //            //pdfDocument.Save(strImagePath, options);

    //            // Extract text from PDF
    //            //string pdfText = ExtractTextFromPdf(pdfPath);

    //            // Create Excel file
    //            ExcelSaveOptions options = new ExcelSaveOptions();
    //            {
    //                //var sheet = excel.Workbook.Worksheets.Add("Sheet1");
    //                var strategy = new SimpleTextExtractionStrategy();
                    
    //                // Process PDF text to rows and columns
    //                string[] lines = pdfText.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
    //                int row = 1;
    //                foreach (var line in lines)
    //                {
    //                    string[] columns = line.Split('\t'); // Assuming tab-separated
    //                    for (int col = 0; col < columns.Length; col++)
    //                    {
    //                        sheet.Cells[row, col + 1].Value = columns[col];
    //                    }
    //                    row++;
    //                }

    //                // Save Excel
    //                FileInfo excelFile = new FileInfo(strFolderPath);
    //                excel.SaveAs(excelFile);
    //            }
    //        }


    //        lblmsg.Visible = true;
    //        DirectoryInfo d = new DirectoryInfo(strImagePath); //Assuming Test is your Folder

    //        // //Read the Output Excel File
    //        lblmsg.Visible = true;
    //        string _custval = string.Empty;
    //        string _filepath = string.Empty;

    //        _filepath = savePath + "Output\\" + fNamewithoutex + ".xlsx";

    //        string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + _filepath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";


    //        OleDbConnection conn = new OleDbConnection(connString);
    //        DataTable dtt = new DataTable();
    //        if (conn.State == ConnectionState.Closed)
    //            conn.Open();
    //        DataTable dtSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

    //        string query = "";
    //        if (dtSchema.Rows.Count == 1)
    //        {
    //            // // Only one sheet
    //            string firstSheetName = dtSchema.Rows[0].Field<string>("TABLE_NAME");
    //            query = string.Format("SELECT * FROM [{0}]", firstSheetName);
    //            OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
    //            da.Fill(ds_output, "Sheet1");
    //            da.Dispose();
    //        }
    //        else if (dtSchema.Rows.Count > 1)
    //        {
    //            //// Multiple sheets
    //            int sheet_cnt = 1;
    //            foreach (DataRow sheetRow in dtSchema.Rows)
    //            {
    //                string sheetName = sheetRow.Field<string>("TABLE_NAME");
    //                query = string.Format("SELECT * FROM [{0}]", sheetName);
    //                OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
    //                DataTable dtS12 = new DataTable("Sheet" + sheet_cnt);
    //                da.Fill(dtS12);
    //                ds_output.Tables.Add(dtS12);
    //                da.Dispose();
    //                sheet_cnt++;
    //            }
    //        }

    //        ds_gv_Output = reader.getCustInvDetls_Excel_Datatable(Client_Name, _filepath, ds_output);
    //    }
    //    return ds_gv_Output;
    //}

    //public DataSet PDF_Convert_xlsx_to_Datatable(string Client_Name, string Brslno)
    //{

    //    DataSet ds_gv_Output = new DataSet();
    //    DataSet ds_output = new DataSet();

    //    string savePath = Server.MapPath("~/Submission/ImportPDFReader/");
    //    if (Directory.Exists(savePath) == false)
    //    {
    //        Directory.CreateDirectory(savePath);
    //    }

    //    if (FilePDF.HasFile)
    //    {
    //        foreach (FileInfo fileInformation in new DirectoryInfo(savePath).GetFiles())
    //        {
    //            File.Delete(fileInformation.FullName);
    //        }

    //        //Imp_PDFReader reader = new Imp_PDFReader();
    //        //string strFolderPath;
    //        //string strImagePath;

    //        //strFolderPath = Path.Combine(Request.PhysicalApplicationPath, savePath);
    //        //strImagePath = Path.Combine(strFolderPath, FilePDF.FileName.ToString());

    //        //FilePDF.SaveAs(strImagePath);
    //        //ConvertPdfToExcel(strImagePath, strImagePath);
    //        //ConvertPdfToExcel(strImagePath, strFolderPath);

    //        string strFolderPath;
    //        string strImagePath;

    //        strFolderPath = Path.Combine(Request.PhysicalApplicationPath, savePath);
    //        strImagePath = Path.Combine(strFolderPath, FilePDF.FileName.ToString());

    //        FilePDF.SaveAs(strImagePath);

    //        string fNamewithoutex = Path.GetFileNameWithoutExtension(strImagePath);
    //        Imp_PDFReader reader = new Imp_PDFReader();
    //        Document pdfDocument = new Document(strImagePath);
    //        ViewState["fileNamewithoutextn"] = fNamewithoutex;

    //        if (File.Exists(savePath + "Output/" + fNamewithoutex + ".xlsx"))
    //        {
    //        }
    //        else
    //        {
    //            //ExcelSaveOptions options = new ExcelSaveOptions();
    //            //fNamewithoutex = Path.GetFileNameWithoutExtension(strImagePath);

    //            //strFolderPath = Path.Combine(Request.PhysicalApplicationPath, savePath + "Output/" + fNamewithoutex + ".xlsx");
    //            //string savePath1 = Server.MapPath("~/Submission/ImportPDFReader/Output/");
    //            //if (Directory.Exists(savePath1) == false)
    //            //{
    //            //    Directory.CreateDirectory(savePath1);
    //            //}
    //            //strImagePath = Path.Combine(strFolderPath);
    //            //pdfDocument.Save(strImagePath, options); 
    //            string ExcelSaveOptions = Path.GetFileNameWithoutExtension(ExcelSaveOptions);
    //            string outputExcelPath = Path.Combine("~/Submission/ImportPDFReader/Output/", "{ExcelSaveOptions}.xlsx");
    //            ExcelSaveOptions options = new ExcelSaveOptions
    //            {
    //                Format = ExcelSaveOptions.ExcelFormat.XLSX,
    //                MinimizeTheNumberOfWorksheets = true // Combine all PDF pages into a single sheet
    //            };

    //            pdfDocument.Save(outputExcelPath, options);
    //            Console.WriteLine("PDF successfully converted to Excel: {outputExcelPath}");
    //         }


    //        lblmsg.Visible = true;
    //        DirectoryInfo d = new DirectoryInfo(strImagePath); //Assuming Test is your Folder

    //        //Read the Output Excel File
    //        lblmsg.Visible = true;
    //        string _custval = string.Empty;
    //        string _filepath = string.Empty;

    //        _filepath = savePath + "Output\\" + fNamewithoutex + ".xlsx";

    //        string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + _filepath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";


    //        OleDbConnection conn = new OleDbConnection(connString);
    //        DataTable dtt = new DataTable();
    //        if (conn.State == ConnectionState.Closed)
    //            conn.Open();
    //        DataTable dtSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

    //        string query = "";
    //        if (dtSchema.Rows.Count == 1)
    //        {
    //            // Only one sheet
    //            string firstSheetName = dtSchema.Rows[0].Field<string>("TABLE_NAME");
    //            query = string.Format("SELECT * FROM [{0}]", firstSheetName);
    //            OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
    //            da.Fill(ds_output, "Sheet1");
    //            da.Dispose();
    //        }
    //        else if (dtSchema.Rows.Count > 1)
    //        {
    //            // Multiple sheets
    //            int sheet_cnt = 1;
    //            foreach (DataRow sheetRow in dtSchema.Rows)
    //            {
    //                string sheetName = sheetRow.Field<string>("TABLE_NAME");
    //                query = string.Format("SELECT * FROM [{0}]", sheetName);
    //                OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
    //                DataTable dtS12 = new DataTable("Sheet" + sheet_cnt);
    //                da.Fill(dtS12);
    //                ds_output.Tables.Add(dtS12);
    //                da.Dispose();
    //                sheet_cnt++;
    //            }
    //        }

    //        ds_gv_Output = reader.getCustInvDetls_Excel_Datatable(Client_Name, _filepath, ds_output);         
    //    }
    //    return ds_gv_Output;
    //}

    private string Get_Valid_Qty_Code(string curr)
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
        else if (curr == "PIECE(S)")
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

        return curr;
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
        Transact.JOBDATE = DateTime.Now.ToString("dd/MM/yyyy");

        DataSet dtHeader = (ViewState["ds_Header_Output"]) as DataSet;
        if (dtHeader.Tables[0].Rows.Count > 0 && dtHeader.Tables[1].Rows.Count > 0)
        {
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

            Transact.USER_ID = currentuser;
            Transact.flag = flag;
            Transact.BRANCH_CODE = currentbranch;
            Transact.WORKING_PERIOD = Working_Period;
            //Transact.JOBNO_PS = txtjobPS.Text;
            JobNo_Prefix_Sufix(txtjobPS.Text);
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

                if (hd_Terms.Value == "FOB")
                {
                    Transact.MIS_FREIGHT_RATE = "20.0000";
                    Transact.MIS_INSURANCE_RATE = "1.1250";
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
            DataTable dtItem = (ViewState["HeaderItemDetails"]) as DataTable;
            string SELECT_BRANCH = Connection.Get_Company_Type();
            string GetPartNo = "", GetPoNo = "", GetNetWeight = "";
            if (dtItem.Rows.Count > 0)
            {
                for (int j = 0; j <= dtItem.Rows.Count - 1; j++)
                {
                    string ITEM_DESCRIPTION = dtItem.Rows[j]["ITEM_DESC"].ToString();
                    Transact.ITEM_QTY = dtItem.Rows[j]["ITEM_QTY"].ToString();
                    Transact.ITEM_QTY_CODE = txtQTYCode.Text;

                    string MaterialRate = dtItem.Rows[j]["ITEM_UNITPRICE"].ToString();
                    string MaterialRateRemoveCama = MaterialRate.Replace(",", "");
                    Transact.ITEM_UNIT_PRICE = MaterialRateRemoveCama;
                    Transact.ITEM_UNIT_CODE = hd_Currency.Value.ToUpper();

                    string MaterialAmount = dtItem.Rows[j]["ITEM_AMOUNT"].ToString();
                    string MaterialAmountRemoveCama = MaterialAmount.Replace(",", "");
                    Transact.ITEM_TOTAL_AMOUNT = MaterialAmountRemoveCama;

                    Transact.ITEM_AMOUNT_CODE = hd_Currency.Value.ToUpper();
                    Transact.COUNTRY_OF_ORIGIN = dtItem.Rows[j]["COUNTRY_OF_ORIGIN"].ToString();
                    Transact.PREVIOUS_BE_DATE = "01/01/1900";
                    Transact.flag = "S";
                    Transact.YEAR = "";
                    Transact.USER_ID = currentuser;
                    Transact.BRANCH_CODE = currentbranch;
                    Transact.WORKING_PERIOD = Working_Period;
                    Transact.INV_SLNO = "1";
                    //Transact.JOBNO = txtjobPS.Text;
                    Transact.BRANCH_COMMON = SELECT_BRANCH;

                    eroyalmaster erm = new eroyalmaster();
                    erm.IMPORTER_NAME = Importer;
                    erm.IEC_NO = Transact.IEC_NO;
                    erm.ADCODE = Transact.ADCODE;
                    erm.BRANCH_NO = Transact.BRANCH_NO;
                    //erm.PARTNO = GetPartNo;
                    erm.Eproduct_imp_description = ITEM_DESCRIPTION.Replace("\n", " ").Replace("\r", " ");
                    erm.Ename = "Select_Common_Whole_Data";

                    DataSet dsGetPDFData = erm.RetrieveAll_Product_import_PDF_MASTER();

                    //Masters

                    if (dsGetPDFData.Tables[0].Rows.Count > 0)
                    {
                        Transact.ITEM_DESCRIPTION =ITEM_DESCRIPTION;
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
                        if (Transact.COUNTRY_OF_ORIGIN == "" && Transact.COUNTRY_OF_ORIGIN == string.Empty)
                        {
                            Transact.COUNTRY_OF_ORIGIN = dsGetPDFData.Tables[0].Rows[0]["PRODUCT_COUNTRY_ORIGIN"].ToString();
                        }
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
        catch (Exception ex)
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