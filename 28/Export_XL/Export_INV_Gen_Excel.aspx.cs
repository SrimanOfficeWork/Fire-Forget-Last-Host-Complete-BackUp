using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Web.Services;
using System.Data.OleDb;
using System.Collections;
using System.Data;
using System.Data.SqlClient;


public partial class Export_INV_Gen_Excel : ThemeClass
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();

    public int i;
    public string currentuser;
    public string currentbranch;
    public string Working_Period;

    public string SELECT_TYPE, SELECT_BRANCH, COMPANY_ID;
    public string EXPORT_JOBNO, EXPORT_JOBDATE;

    public string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);

    public string errorFolder = "", logline = "", logFileName = "", error = "";
    public string folderName = "/Submission";

    public string scheme;
    string[] scheme_name = new string[2];

    int sl = 0;
    int sl_E = 0;

    int ii = 0;
    int D_E = 0;

    public int License_id_Max = 0;
    public int License_id_IMP_EXP_Max = 0;

    public string[] lic_no;
    public int licno_Count;
    public decimal item_amt;
    string selectSQL;

    DataSet ds_TPD = new DataSet();
    DataSet ds_draw = new DataSet();
    DataSet ds_license = new DataSet();

    Auto_Search Auto = new Auto_Search();
    Export_Licence License = new Export_Licence();
    Export_XL_Upload EXU = new Export_XL_Upload();

    DataSet ds = new DataSet();
    DataSet dsXML = new DataSet();
    DataTable dt = new DataTable();
    SqlCommand cmd = new SqlCommand();
    AdminMasterDetails adm = new AdminMasterDetails();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        COMPANY_ID = Session["COMPANY_ID"].ToString();
        if (Session["EXPORT_JOBNO"] != null)
        {
            EXPORT_JOBNO = Session["EXPORT_JOBNO"].ToString();
            EXPORT_JOBDATE = Session["EXPORT_JOBDATE"].ToString();
        }
        if (!IsPostBack)
        {
            txtBuyerName.Text = "SAME AS CONSIGNEE";
        }

        SELECT_BRANCH = Connection.Get_Company_Type();
        errorFolder = Server.MapPath("~/Submission/" + COMPANY_ID + "/" + currentbranch + "/" + currentuser + "/" + "Export_Excel");
        if (!Page.IsPostBack)
        {

        }
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Export Excel Upload', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Export Excel Upload', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void gv_Item_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
        }
    }

    protected void gv_Item_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {

        //------------------------------------------EXCEL upload- by Antony --------------------------------------------------------------------------------------------------
        GridViewRow row = e.Row;
        // Intitialize TableCell list
        List<TableCell> columns = new List<TableCell>();

        foreach (DataControlField column in gv_Item_Details.Columns)
        {
            TableCell cell = row.Cells[0];
            row.Cells.Remove(cell);
            columns.Add(cell);
        }

        row.Cells.AddRange(columns.ToArray());
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        int aa = e.Row.Cells.Count;

        if (ViewState["err_Validate"] == "Y")
        {
            if (e.Row.Cells.Count >= 1)
            {

                //row.Cells.AddRange(columns.ToArray());
                //if (e.Row.RowType == DataControlRowType.Header)
                //    e.Row.CssClass = "header";


                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[2].ForeColor = System.Drawing.Color.Red;

                if (ViewState["Admin_err"] == "Y")
                {
                    e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
                    e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Left;
                    e.Row.Cells[4].ForeColor = System.Drawing.Color.Red;
                    e.Row.Cells[3].Font.Size = 8;
                    e.Row.Cells[5].Visible = false;
                }
                else
                {
                    e.Row.Cells[0].ForeColor = System.Drawing.Color.Red;
                    if (error != "")
                    {
                        e.Row.Cells[3].Visible = false;
                    }
                }
            }

            //--------------------------------------------------------------------------------------------------------------------------------------------

            //if (e.Row.RowType == DataControlRowType.Header)
            //    e.Row.CssClass = "header";
        }
    }

    protected void btn_upload_Click(object sender, EventArgs e)
    {
        try
        {
            if (File.Exists(errorFolder + logFileName))
            {
                DirectoryInfo dir = new DirectoryInfo(errorFolder);
                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }
                Get_ExcelFile();
            }
            else
            {
                DirectoryInfo dir = new DirectoryInfo(errorFolder);

                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }

                Get_ExcelFile();
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }


    private void Check_Duplicate_Invoice_Before_Upload()
    {
        try
        {
            ds = (DataSet)ViewState["ds_Excel_upload"];
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                Alert_msg("No Excel data found to upload.");
                return;
            }

            DataView view = new DataView(ds.Tables[0]);
            DataTable dtInvoices = view.ToTable(true, "INVOICE_NO");

            string currentJob = Session["EXPORT_JOBNO"].ToString().Trim();
            StringBuilder duplicateMsg = new StringBuilder();

            foreach (DataRow r in dtInvoices.Rows)
            {
                string invNo = r["INVOICE_NO"].ToString().Trim();
                if (invNo == "") continue;

                string result = Get_Duplicate_InvoiceNo(invNo, "");

                if (result != null && result.IndexOf("~~") != -1)
                {
                    string jobnos = result.Split(new string[] { "~~" }, StringSplitOptions.None)[0];

                    string otherJobs = "";
                    foreach (string j in jobnos.Split(','))
                    {
                        if (j.Trim() != "" && j.Trim() != currentJob)
                            otherJobs += (otherJobs == "" ? "" : ",") + j.Trim();
                    }

                    if (otherJobs != "")
                        duplicateMsg.Append("Invoice No : " + invNo + " - JobNumber : " + otherJobs + "\\n");
                }
            }

            if (duplicateMsg.Length > 0)
            {
                string msg = "Invoice No Already Exists!\\n" + duplicateMsg.ToString() +
                             "\\nDo you want to Proceed further?";
                msg = msg.Replace("'", "\\'");

                string script = "if(confirm('" + msg + "'))" +
                    "{ document.getElementById('" + btn_ConfirmUpload.ClientID + "').click(); }";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "DupInvConfirm", script, true);
            }
            else
            {
                Excel_Upload_load();
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }

    protected void btn_ConfirmUpload_Click(object sender, EventArgs e)
    {
        try
        {
            Excel_Upload_load();
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }

    [System.Web.Services.WebMethod]
    public static string Get_Duplicate_InvoiceNo(string custid, string Jobno)
    {
        string InvoiceNo = "";
        try
        {
            if (custid != "")
            {
                Auto_Search Auto = new Auto_Search();
                DataSet ds = new DataSet();

                Auto.Ename = "EXPORT_DUPLICATE_INVOICENO";
                Auto.Enamesearch = custid;
                ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["INVOICE_NO"].ToString() != "")
                    {
                        if (ds.Tables[0].Rows[0]["INVOICE_NO"].ToString() != Jobno)
                        {
                            InvoiceNo = ds.Tables[0].Rows[0]["INVOICE_NO"].ToString() + "~~";
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return InvoiceNo;
    }




    protected void btnupload_Click(object sender, EventArgs e)
    {
        if (gv_Item_Details.Rows.Count > 0)
        {
            DataSet d = new DataSet();
            EXU.JOBNO = Session["EXPORT_JOBNO"].ToString();
            EXU.Ename = "Excel_Aval";
            EXU.Branch_Code = SELECT_BRANCH;
            d = EXU.Select_Exp_INV();

            if (d.Tables[0].Rows.Count > 0)
            {
                MP_U.Show();
            }
            else
            {
                Excel_Upload_load();
            }
        }
        else
        {
            Alert_msg("Upload Ur Excel file.");
        }
    }

    protected void btnyes_Click(object sender, EventArgs e)
    {
        DataSet d = new DataSet();
        EXU.JOBNO = Session["EXPORT_JOBNO"].ToString();
        EXU.Ename = "Delete_Excel";
        EXU.Branch_Code = SELECT_BRANCH;
        d = EXU.Select_Exp_INV();

        if (d.Tables[0].Rows.Count > 0)
        {
            Alert_msg("Not deleted ur Old Invoice");
        }
        else
        {
            //Alert_msg("deleted ur Old Invoice Successfully");
            MP_U.Hide();
            Excel_Upload_load();
        }
    }

    public void Get_ExcelFile()
    {
        DataSet ds = new DataSet();
        DataSet ds_validate = new DataSet();
        DataSet ds_Admin_err = new DataSet();

        string connString = "";
        string strFileType = Path.GetExtension(fileuploadExcel.FileName).ToLower();
        string path = errorFolder + "\\" + fileuploadExcel.FileName;

        string strGID;
        string picExtension;
        string fileName2;

        if (fileuploadExcel.HasFile)
        {
            picExtension = fnGetPictureExtn(fileuploadExcel.FileName);
            fileName2 = fileuploadExcel.FileName;
            addtoGallery1(fileName2, errorFolder, "NORMAL");
        }

        if (strFileType.Trim() == ".xls")
        {
            connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
        }
        else if (strFileType.Trim() == ".xlsx")
        {
            connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;IMEX=1;HDR=NO;TypeGuessRows=0;ImportMixedTypes=Text\"";
        }


        //-----------------------------------------------------------------Diana--------------------------------------------------------------//
        else if (strFileType.Trim() == ".xlsm")
        {
            connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;IMEX=1;HDR=NO;TypeGuessRows=0;ImportMixedTypes=Text\"";
        }

        OleDbConnection conn = new OleDbConnection(connString);
        DataTable dtt = new DataTable();
        if (conn.State == ConnectionState.Closed)
            conn.Open();
        DataTable dtSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

        if (dtSchema.Rows.Count == 1)
        {
            String firstSheetName = dtSchema.Rows[0].Field<string>("TABLE_NAME");
            string query = string.Format("SELECT * FROM [{0}]", firstSheetName);
            OleDbCommand cmd = new OleDbCommand(query, conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dtt);
            //------ this concept implmtd by Antony on 23/07/2020 for AlphaNumeric not Capturing in Datatable------------------------------
            DataRow firstRow = dtt.Rows[0];
            for (int i = 0; i < dtt.Columns.Count; i++)
            {
                if (!string.IsNullOrWhiteSpace(firstRow[i].ToString())) // handle empty cell
                    dtt.Columns[i].ColumnName = firstRow[i].ToString().Trim();
            }
            dtt.Rows.RemoveAt(0);
            //-----------------------------------------------------------------------------------------------------------------------------

            da.Dispose();
            conn.Close();
            conn.Dispose();
        }
       
        else
        {
            string query = "SELECT * FROM [Sheet1$]";
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            OleDbCommand cmd = new OleDbCommand(query, conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dtt);

            //------ this concept implmtd by Antony on 23/07/2020 for AlphaNumeric not Capturing in Datatable------------------------------
            DataRow firstRow = dtt.Rows[0];
            for (int i = 0; i < dtt.Columns.Count; i++)
            {
                if (!string.IsNullOrWhiteSpace(firstRow[i].ToString())) // handle empty cell
                    dtt.Columns[i].ColumnName = firstRow[i].ToString().Trim();
            }
            dtt.Rows.RemoveAt(0);
            //-----------------------------------------------------------------------------------------------------------------------------

            da.Dispose();
            conn.Close();
            conn.Dispose();
        }
        if (dtt.Columns.Contains("GST_INVOICE_NO") && !dtt.Columns.Contains("INVOICE_NO")) // Added by shanthini on 19-08-2026
        {
            dtt.Columns["GST_INVOICE_NO"].ColumnName = "INVOICE_NO";
        }

        DataTable filteredRows = dtt.Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is System.DBNull)).CopyToDataTable();
        DataSet dss = new DataSet();
        dss.Tables.Add(filteredRows);
        if (dss.Tables[0].Rows.Count > 0)
        {
            ViewState["ds_Excel_upload"] = dss;
        }

        //-----------  Trim All rows and Columns in Datatable--------------------
        var updatedRows = filteredRows.AsEnumerable().Select(row =>
        {
            // Create a new row with trimmed values
            var updatedRow = filteredRows.NewRow();

            // Trim each column in the row if it's a string
            updatedRow.ItemArray = row.ItemArray.Select(item =>
            {
                // If the item is a string, trim it
                return item is string ? ((string)item).Trim() : item;
            }).ToArray();

            return updatedRow;
        }).ToList();

        // Replace the old rows with the updated ones

        for (int i = 0; i < filteredRows.Rows.Count; i++)
        {
            filteredRows.Rows[i].ItemArray = updatedRows[i].ItemArray;
        }
        
        Dictionary<string, decimal> invoiceTotalINR = new Dictionary<string, decimal>();
        foreach (DataRow row in filteredRows.Rows)
        {
            string invSlno = row["INVOICE_SLNO"].ToString().Trim();
            decimal qty = 0, unitPrice = 0, exRate = 0;

            decimal.TryParse(row["ITEM_QTY"].ToString().Trim(), out qty);
            decimal.TryParse(row["UNIT_PRICE"].ToString().Trim(), out unitPrice);
            decimal.TryParse(row["EXCHANGE_RATE"].ToString().Trim(), out exRate);

            if (!invoiceTotalINR.ContainsKey(invSlno))
                invoiceTotalINR[invSlno] = 0;

            decimal fcRounded = Math.Round(qty * unitPrice, 2,MidpointRounding.AwayFromZero);

            invoiceTotalINR[invSlno] += fcRounded * exRate; // accumulate INR total
        }

        foreach (DataRow row in filteredRows.Rows)
        {
            string IGST_PAYMENT_STATUS = row["IGST_PAYMENT_STATUS"].ToString().Trim().ToUpper();
            string Terms = row["TERMS"].ToString().Trim().ToUpper();
            string invSlno = row["INVOICE_SLNO"].ToString().Trim();
            
            decimal TaxableValue = 0, IgstAmount = 0;

            decimal ItemQty = 0, UnitPrice = 0, ExchangeRate = 0, IgstRate = 0;
            decimal DiscountCharges = 0, InsuranceCharges = 0, FreightCharges = 0, PackingCharges = 0;
            decimal.TryParse(row["ITEM_QTY"].ToString().Trim(), out ItemQty);
            decimal.TryParse(row["UNIT_PRICE"].ToString().Trim(), out UnitPrice);
            decimal.TryParse(row["EXCHANGE_RATE"].ToString().Trim(), out ExchangeRate);
            decimal.TryParse(row["IGST_RATE"].ToString().Trim(), out IgstRate);
            decimal.TryParse(row["FOB_CHARGES"].ToString().Trim(), out DiscountCharges);
            decimal.TryParse(row["INSURANCE_CHARGES"].ToString().Trim(), out  InsuranceCharges);
            decimal.TryParse(row["FREIGHT_CHARGES"].ToString().Trim(), out FreightCharges);
            decimal.TryParse(row["PACKMISC_CHARGES"].ToString().Trim(), out PackingCharges);
            decimal.TryParse(row["TAXABLE_VALUE"].ToString(), out TaxableValue);
            decimal.TryParse(row["IGST_AMOUNT"].ToString(), out IgstAmount);

            decimal TotalInvINR = invoiceTotalINR.ContainsKey(invSlno)
                         ? invoiceTotalINR[invSlno] : 0;
            decimal ind_inv_INR = ItemQty * UnitPrice * ExchangeRate;

            decimal Insurance_INR = InsuranceCharges * ExchangeRate;
            decimal Freight_INR = FreightCharges * ExchangeRate;
            decimal packingCharges_INR = PackingCharges * ExchangeRate;
            decimal DiscINR = DiscountCharges * ExchangeRate;

            decimal ind_disc_amt = TotalInvINR > 0
                             ? (DiscINR * ind_inv_INR) / TotalInvINR
                             : 0;
            decimal Inv_ins_Amount = TotalInvINR > 0 ? (Insurance_INR * ind_inv_INR) / TotalInvINR : 0;
            decimal Inv_Fri_Amount = TotalInvINR > 0 ? (Freight_INR * ind_inv_INR) / TotalInvINR : 0;
            decimal Inv_Packing_Amount = TotalInvINR > 0 ? (packingCharges_INR * ind_inv_INR) / TotalInvINR : 0;

            decimal calc_invVal = Math.Round(ItemQty * UnitPrice, 2,MidpointRounding.AwayFromZero);
            decimal calc_INR = calc_invVal * ExchangeRate;

            if (IGST_PAYMENT_STATUS == "P" && Terms == "FOB"&& TaxableValue==1&&IgstAmount==1)
            {
                TaxableValue = Math.Round(calc_INR - ind_disc_amt + Inv_Packing_Amount, 2,MidpointRounding.AwayFromZero);
                IgstAmount = Math.Round(TaxableValue * IgstRate / 100, 2);
                row["TAXABLE_VALUE"] = TaxableValue;
                row["IGST_AMOUNT"] = IgstAmount;
            }
            else if (IGST_PAYMENT_STATUS == "P" && Terms == "CIF" && TaxableValue == 1 && IgstAmount == 1)
            {
                TaxableValue = Math.Round(calc_INR - ind_disc_amt - Inv_ins_Amount - Inv_Fri_Amount + Inv_Packing_Amount, 2,MidpointRounding.AwayFromZero);
                IgstAmount =Math.Round(TaxableValue * IgstRate / 100,2);

                row["TAXABLE_VALUE"] = TaxableValue;
                row["IGST_AMOUNT"] = IgstAmount;
            }
            else if (IGST_PAYMENT_STATUS == "P" && Terms == "CI" && TaxableValue == 1 && IgstAmount == 1)
            {
             
                TaxableValue = Math.Round(calc_INR - ind_disc_amt - Inv_ins_Amount + Inv_Packing_Amount, 2,MidpointRounding.AwayFromZero);
                IgstAmount = Math.Round(TaxableValue * IgstRate / 100, 2);
                row["TAXABLE_VALUE"] = TaxableValue;
                row["IGST_AMOUNT"] = IgstAmount;
            }
            else if (IGST_PAYMENT_STATUS == "P" && Terms == "CF" && TaxableValue == 1 && IgstAmount == 1)
            {
                TaxableValue = Math.Round(calc_INR - Inv_Fri_Amount - ind_disc_amt + Inv_Packing_Amount, 2,MidpointRounding.AwayFromZero);
                IgstAmount = Math.Round(TaxableValue * IgstRate / 100, 2);
                row["TAXABLE_VALUE"] = TaxableValue;
                row["IGST_AMOUNT"] = IgstAmount;
            }
            else
            {
            }
        }
        //----------------------------------------------------------------------------
        // [NEW] STAGE 0: Invoice Consistency Validation
        DataSet ds_Invoice_Consistency_err = ValidateInvoiceConsistency(filteredRows);

        if (ds_Invoice_Consistency_err.Tables[0].Rows.Count > 0)
        {
            ViewState["Admin_err"] = "Y";
            ViewState["err_Validate"] = "Y";
            error = "errormsg";
            gv_Item_Details.DataSource = ds_Invoice_Consistency_err.Tables[0];
            gv_Item_Details.DataBind();
            btnupload.Visible = false;
            return;
        }
        //END STAGE 0



        //------Admin Master Validation-----------------------------------------------

        System.Data.DataView view = new System.Data.DataView(dss.Tables[0]);

        System.Data.DataTable selected_Invoice = view.ToTable("Selected", true, "INVOICE_SLNO", "ITEM_SLNO", "INVOICE_CURRENCY", "FREIGHT_CURRENCY", "INSURANCE_CURRENCY", "COMMISSION_CURRENCY", "FOB_CURRENCY", "PACKMISC_CURRENCY", "OTHER_DEDUCTION_CURRENCY", "INSURANCE_CHARGES");
        System.Data.DataTable selected_Item = view.ToTable("Selected", true, "INVOICE_SLNO", "ITEM_SLNO", "ITEM_SCHEME_CODE", "RITCNO", "ITEM_QTY_CODE", "STR_CODE", "END_USE_OF_ITEM", "MANUFACTURE_COUNTRY", "TRANSIT_COUNTRY", "SOURCE_STATE");
        System.Data.DataTable selected_Drawback = view.ToTable("Selected", true, "INVOICE_SLNO", "ITEM_SLNO", "DRAWBACK_SLNO", "DRAWBACK_UNIT", "DRAWBACK_QTY");
        System.Data.DataTable selected_SW_Info = view.ToTable("Selected", true, "INVOICE_SLNO", "ITEM_SLNO", "RITCNO", "INFO_UQC", "STATE_OF_ORIGIN", "DISTRICT_OF_ORIGIN", "EXPORT_UNDER_PTA_FTA");
        System.Data.DataTable selected_SchemeDrawback = view.ToTable("Selected", true, "INVOICE_SLNO", "ITEM_SLNO", "ITEM_SCHEME_CODE", "DRAWBACK_SLNO", "DRAWBACK_UNIT", "DRAWBACK_QTY");

        String xml_Data_Invoice = Common_CS.ConvertDataTableToXML(selected_Invoice);
        String xml_Data_Item = Common_CS.ConvertDataTableToXML(selected_Item);
        String xml_Data_Drawback = Common_CS.ConvertDataTableToXML(selected_Drawback);
        String xml_Data_SW_Info = Common_CS.ConvertDataTableToXML(selected_SW_Info);
        String xml_Data_SchemeDrawback = Common_CS.ConvertDataTableToXML(selected_SchemeDrawback);


        EXP_Validation Exp_Valid = new EXP_Validation();
        Exp_Valid.Xml_A = xml_Data_Invoice;
        Exp_Valid.Xml_B = xml_Data_Item;
        Exp_Valid.Xml_C = xml_Data_Drawback;
        Exp_Valid.Xml_D = xml_Data_SW_Info;
        Exp_Valid.Xml_E = xml_Data_SchemeDrawback;

        Exp_Valid.Flag = "Admin_Master_Validate_All";
        ds_Admin_err = Exp_Valid.RetrieveAll_Export_Admin_Master_Validation();

        if (ds_Admin_err.Tables[0].Rows.Count > 0)
        {
            ViewState["Admin_err"] = "Y";
            ViewState["err_Validate"] = "Y";
            error = "errormsg";
            gv_Item_Details.DataSource = ds_Admin_err.Tables[0];
            gv_Item_Details.DataBind();
            btnupload.Visible = false;
        }
        else
        {
            //-------------------- Bulk Insert for Validate ----------

            System.Data.DataTable selected = view.ToTable("Selected", true, "INVOICE_SLNO", "INVOICE_NO", "INVOICE_DATE", "INVOICE_CURRENCY", "EXCHANGE_RATE", "PAYMENT_METHOD", "PERIOD_PAYMENT", "CONTRACT_NO", "TERMS", "FREIGHT_CHARGES", "FREIGHT_CURRENCY", "INSURANCE_RATE", "INSURANCE_CHARGES", "INSURANCE_CURRENCY", "COMMISSION_RATE", "COMMISSION_CHARGES", "COMMISSION_CURRENCY", "FOB_RATE", "FOB_CHARGES", "FOB_CURRENCY", "PACKMISC_RATE", "PACKMISC_CHARGES", "PACKMISC_CURRENCY", "OTHER_DEDUCTION_RATE", "OTHER_DEDUCTION_CHARGES", "OTHER_DEDUCTION_CURRENCY", "WHEATHER_UNIT_PRICE", "ITEM_SCHEME_CODE", "RITCNO", "ITEM_SLNO", "ITEM_DESCRIPTION", "ITEM_QTY", "UNIT_PRICE", "ITEM_QTY_CODE", "ACCESSORY_DESC", "DRAWBACK_SLNO", "DRAWBACK_QTY", "DRAWBACK_UNIT", "REWARD_POINTS", "STR_CODE", "LICENSE_NO", "THIRD_PARTY_IEC_NO", "BR_SL_NO", "END_USE_OF_ITEM", "IGST_PAYMENT_STATUS", "TAXABLE_VALUE", "IGST_RATE", "IGST_AMOUNT", "MANUFCR_PRODUCER_CODE", "MANUFCR_PRODUCER_GROWER_CODE", "ADDRESS1", "ADDRESS2", "CITY", "SUB_DIVISION", "PIN_CODE", "MANUFACTURE_COUNTRY", "SOURCE_STATE", "TRANSIT_COUNTRY", "ACCE_STATUS", "HAWB_NO", "TOTAL_PKGS", "DRAWBACK_DECLARATION_CODES", "PMV_VALUE", "INFO_MSR", "INFO_UQC", "STATE_OF_ORIGIN", "DISTRICT_OF_ORIGIN", "EXPORT_UNDER_PTA_FTA", "GST_COMPENSATION_CESS_AMT", "RODTEP", "ITEM_PER");

            //Delete table - TBL_EXPORT_EXCEL_FORMAT
            Delete_Temp_table();

            //-------Insert Bulk Data to Table
            adm.SqlBulk_Upload_Product("TBL_EXPORT_EXCEL_FORMAT", selected, Connection.GetConnection());

            ds_validate = EXU.Bulk_Excel_Validation("Export_Validation");

            if (ds_validate.Tables[0].Rows.Count > 0)
            {
                ViewState["Admin_err"] = "N";
                ViewState["err_Validate"] = "Y";
                error = "errormsg";
                gv_Item_Details.DataSource = ds_validate.Tables[0];
                gv_Item_Details.DataBind();
                btnupload.Visible = false;
            }
            else
            {
                ViewState["Admin_err"] = "N";
                ViewState["err_Validate"] = "N";
                btnupload.Visible = true;


                if (ds_validate.Tables[1].Rows.Count > 0)
                {
                    gv_Item_Details.DataSource = ds_validate.Tables[1];
                    gv_Item_Details.DataBind();
                }
            }
        }
    }

    public void GET_LICENSE_ID()
    {
        DataSet ds = new DataSet();
        Export_Licence Export_license = new Export_Licence();
        Export_license.LICENSE_NO = "0";
        Export_license.Ename = "GET_EXPORT_LICENSE_ID_MAX";
        ds = Export_license.Export_License_Master_Select();
        License_id_Max = Convert.ToInt32(ds.Tables[0].Rows[0]["LICENSE_ID"].ToString());
        License_id_IMP_EXP_Max = Convert.ToInt32(ds.Tables[1].Rows[0]["LICENSE_IMP_EXP_ID"].ToString());
    }


    public void Excel_Upload_load()
    {
        try
        {
            GET_LICENSE_ID();
            DataTable dt1 = new DataTable();
            //if (txtBuyerName.Text == "")
            //{
            //    txtBuyerName.Text = "SAME AS CONSIGNEE";
            //}

            ds = (DataSet)ViewState["ds_Excel_upload"];

            int //a = 0, 
                b = 0, c = 0, d = 0, e = 0;
            ds.Tables[0].Rows.Add();
            DataSet dss1 = new DataSet();


            if (ds.Tables[0].Rows.Count > 0)
            {
                DataView view = new DataView(ds.Tables[0]);
                DataTable distinctValues = view.ToTable(true, "INVOICE_SLNO", "INVOICE_NO", "INVOICE_DATE", "INVOICE_CURRENCY", "EXCHANGE_RATE", "PAYMENT_METHOD", "PERIOD_PAYMENT", "CONTRACT_NO", "TERMS", "FREIGHT_CHARGES", "FREIGHT_CURRENCY", "INSURANCE_RATE", "INSURANCE_CHARGES", "INSURANCE_CURRENCY", "COMMISSION_RATE", "COMMISSION_CHARGES", "COMMISSION_CURRENCY", "FOB_RATE", "FOB_CHARGES", "FOB_CURRENCY", "PACKMISC_RATE", "PACKMISC_CHARGES", "PACKMISC_CURRENCY", "OTHER_DEDUCTION_RATE", "OTHER_DEDUCTION_CHARGES", "OTHER_DEDUCTION_CURRENCY", "WHEATHER_UNIT_PRICE", "ITEM_SCHEME_CODE", "RITCNO", "ITEM_SLNO", "ITEM_DESCRIPTION", "ITEM_QTY", "UNIT_PRICE", "ITEM_QTY_CODE", "ACCESSORY_DESC", "DRAWBACK_SLNO", "DRAWBACK_QTY", "DRAWBACK_UNIT", "REWARD_POINTS", "STR_CODE", "LICENSE_NO", "THIRD_PARTY_IEC_NO", "BR_SL_NO", "END_USE_OF_ITEM", "IGST_PAYMENT_STATUS", "TAXABLE_VALUE", "IGST_RATE", "IGST_AMOUNT", "MANUFCR_PRODUCER_CODE", "MANUFCR_PRODUCER_GROWER_CODE", "ADDRESS1", "ADDRESS2", "CITY", "SUB_DIVISION", "PIN_CODE", "MANUFACTURE_COUNTRY", "SOURCE_STATE", "TRANSIT_COUNTRY", "ACCE_STATUS", "HAWB_NO", "TOTAL_PKGS", "DRAWBACK_DECLARATION_CODES", "PMV_VALUE", "INFO_MSR", "INFO_UQC", "STATE_OF_ORIGIN", "DISTRICT_OF_ORIGIN", "EXPORT_UNDER_PTA_FTA", "GST_COMPENSATION_CESS_AMT", "RODTEP", "ITEM_PER");

                var rowsToUpdate = distinctValues.AsEnumerable().Where(r => r.Field<string>("INVOICE_DATE") != "");

                foreach (var row in rowsToUpdate)
                {
                    if (row[2].ToString() != "")
                    {
                        string inv_date = Convert.ToDateTime(row[2].ToString()).ToShortDateString();
                        string inv_date1 = string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(inv_date));

                        row.SetField("INVOICE_DATE", Convert.ToDateTime(inv_date).ToString(@"MM/dd/yyyy"));
                    }
                }

                dss1.Tables.Add(distinctValues);

                string Dbkslno = "";
                DataTable dbk_distinct = view.ToTable(true, "DRAWBACK_SLNO");

                for (int x = 0; x <= dbk_distinct.Rows.Count - 1; x++)
                {
                    if (dbk_distinct.Rows[x][0].ToString() != "")
                    {
                        Dbkslno += dbk_distinct.Rows[x][0].ToString() + ",";
                    }
                }

                Auto.Ename = "DRAWBACK_MASTER_ALL_Excel_Upload";
                Auto.Enamesearch = Dbkslno;
                Auto.Notn_No_Search = "";
                ds_draw = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();



                if (gv_Item_Details.Rows.Count != 0)
                {
                    for (int k = 0; k < gv_Item_Details.HeaderRow.Cells.Count; k++)
                    {
                        dt1.Columns.Add(gv_Item_Details.HeaderRow.Cells[k].Text);
                    }

                    foreach (GridViewRow row in gv_Item_Details.Rows)
                    {
                        DataRow dr1 = dt1.NewRow();
                        for (int j = 0; j < row.Cells.Count; j++)
                        {
                            if (j != 6)
                            {
                                dr1[gv_Item_Details.HeaderRow.Cells[j].Text] = row.Cells[j].Text;
                            }
                            else
                            {
                                TextBox txt_BuyerName = row.FindControl("txtBuyerName1") as TextBox;
                                if (txt_BuyerName.Text != "")
                                {
                                    dr1[gv_Item_Details.HeaderRow.Cells[j].Text] = txt_BuyerName.Text;
                                }
                                else
                                {
                                    dr1[gv_Item_Details.HeaderRow.Cells[j].Text] = txtBuyerName.Text;
                                }
                            }

                        }
                        dt1.Rows.Add(dr1);
                    }
                }
            }

            // dt = dsXML.Tables["InvoiceDetails"];

            EXU.JOBNO = EXPORT_JOBNO;
            EXU.USER_ID = currentuser;
            EXU.Branch_Code = currentbranch;
            EXU.WORKING_PERIOD = Working_Period;


            EXPORT_JOBDATE = Convert.ToDateTime(Convert.ToDateTime(EXPORT_JOBDATE).ToShortDateString()).ToString(@"MM/dd/yyyy");
            EXU.Bulk_Item_Excel_Upload_New_XML(dss1.Tables[0], dt1, ds_draw.Tables[0], EXPORT_JOBDATE, "BULK_ITEM_UPLOAD");

            //After Validate - Delete table - TBL_EXPORT_EXCEL_FORMAT
            Delete_Temp_table();


            int i = EXU.result;

            if (EXU.result == 1)
            {
                Alert_msg("Excel Uploaded Successfully.");
            }
            else
            {
                Alert_msg("Excel Upload occured some problem");
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }


    public string fnGetPictureExtn(string pictureName)
    {
        try
        {
            if (pictureName.ToUpper().EndsWith(".JPG"))
                return ".JPG";
            else if (pictureName.ToUpper().EndsWith(".JPEG"))
                return ".JPEG";
            else if (pictureName.ToUpper().EndsWith(".GIF"))
                return ".GIF";
            else if (pictureName.ToUpper().EndsWith(".DOC"))
                return ".DOC";
            else if (pictureName.ToUpper().EndsWith(".XLS"))
                return ".XLS";
            else if (pictureName.ToUpper().EndsWith(".PDF"))
                return ".PDF";
            else if (pictureName.ToUpper().EndsWith(".PNG"))
                return ".PNG";
            else if (pictureName.ToUpper().EndsWith(".CDR"))
                return ".CDR";
            else if (pictureName.ToUpper().EndsWith(".PSD"))
                return ".PSD";
            else if (pictureName.ToUpper().EndsWith(".TXT"))
                return ".TXT";
            else if (pictureName.ToUpper().EndsWith(".XLSX"))
                return ".XLSX";
            else
            {
            }
        }
        catch
        {
        }
        finally
        {
        }
        return "";
    }

    public void addtoGallery1(string picName, string folderName, string Excel_Name)
    {
        string strFolderPath;
        string strImagePath;
        try
        {
            strFolderPath = Path.Combine(Request.PhysicalApplicationPath, folderName);
            strImagePath = Path.Combine(strFolderPath, picName);

            if (Excel_Name == "INDEV")
            {
                //fileuploadExcel1.SaveAs(strImagePath);
            }
            else
            {
                fileuploadExcel.SaveAs(strImagePath);
            }

        }
        catch
        {
        }
        finally
        {
        }
    }

    private void Delete_Temp_table()
    {
        selectSQL = "delete from TBL_EXPORT_EXCEL_FORMAT";
        SqlCommand cmd1 = new SqlCommand(selectSQL, adm.Sql_openConnection(Connection.GetConnection()));
        SqlDataReader reader = cmd1.ExecuteReader();
        reader.Close();
    }


    //------------------------------------------------------------------- 

    private static readonly string[] INVOICE_HEADER_COLUMNS = new string[]
    {
        "INVOICE_SLNO", "INVOICE_NO", "INVOICE_DATE", "INVOICE_CURRENCY",
        "EXCHANGE_RATE", "PAYMENT_METHOD", "PERIOD_PAYMENT", "CONTRACT_NO",
        "TERMS", "FREIGHT_CHARGES", "FREIGHT_CURRENCY", "INSURANCE_RATE",
        "INSURANCE_CHARGES", "INSURANCE_CURRENCY", "COMMISSION_RATE",
        "COMMISSION_CHARGES", "COMMISSION_CURRENCY", "FOB_RATE", "FOB_CHARGES",
        "FOB_CURRENCY", "PACKMISC_RATE", "PACKMISC_CHARGES", "PACKMISC_CURRENCY",
        "OTHER_DEDUCTION_RATE", "OTHER_DEDUCTION_CHARGES", "OTHER_DEDUCTION_CURRENCY",
        "WHEATHER_UNIT_PRICE"        
    };


    private DataSet ValidateInvoiceConsistency(DataTable filteredRows)
    {
        DataSet dsErrors = new DataSet();
        DataTable dtErrors = new DataTable("InvoiceConsistencyErrors");
        dtErrors.Columns.Add("ROW_NO", typeof(string));
        dtErrors.Columns.Add("INVOICE_SLNO", typeof(string));
        dtErrors.Columns.Add("INVOICE_NO", typeof(string));
        dtErrors.Columns.Add("COLUMN_NAME", typeof(string));
        dtErrors.Columns.Add("EXPECTED_VALUE", typeof(string));
        dtErrors.Columns.Add("FOUND_VALUE", typeof(string));
        dtErrors.Columns.Add("ERROR_TYPE", typeof(string));
        dsErrors.Tables.Add(dtErrors);

        List<string> columnsToValidate = new List<string>();
        foreach (string col in INVOICE_HEADER_COLUMNS)
        {
            if (filteredRows.Columns.Contains(col))
                columnsToValidate.Add(col);
        }

        if (!filteredRows.Columns.Contains("INVOICE_NO") ||
            !filteredRows.Columns.Contains("INVOICE_SLNO"))
        {
            DataRow missingCol = dtErrors.NewRow();
            missingCol["ROW_NO"] = "N/A";
            missingCol["INVOICE_SLNO"] = "N/A";
            missingCol["INVOICE_NO"] = "N/A";
            missingCol["COLUMN_NAME"] = "INVOICE_NO / INVOICE_SLNO";
            missingCol["EXPECTED_VALUE"] = "Column must exist";
            missingCol["FOUND_VALUE"] = "Column not found in Excel";
            missingCol["ERROR_TYPE"] = "Missing Required Column";
            dtErrors.Rows.Add(missingCol);
            return dsErrors;
        }


        Dictionary<string, string[]> invoiceSnapshot = new Dictionary<string, string[]>();
        Dictionary<string, int> invoiceFirstRowNum = new Dictionary<string, int>();


        Dictionary<string, string> serialToInvoiceMap = new Dictionary<string, string>();


        int excelRowOffset = 2;

        for (int i = 0; i < filteredRows.Rows.Count; i++)
        {
            DataRow row = filteredRows.Rows[i];
            int excelRow = i + excelRowOffset;

            string invoiceNo = (row["INVOICE_NO"] == DBNull.Value) ? "" : row["INVOICE_NO"].ToString().Trim();
            string invoiceSlNo = (row["INVOICE_SLNO"] == DBNull.Value) ? "" : row["INVOICE_SLNO"].ToString().Trim();


            if (string.IsNullOrEmpty(invoiceNo) && string.IsNullOrEmpty(invoiceSlNo))
                continue;


            if (!string.IsNullOrEmpty(invoiceSlNo))
            {
                if (!serialToInvoiceMap.ContainsKey(invoiceSlNo))
                {

                    serialToInvoiceMap[invoiceSlNo] = invoiceNo;
                }
                else
                {

                    if (serialToInvoiceMap[invoiceSlNo] != invoiceNo)
                    {
                        DataRow errRow = dtErrors.NewRow();
                        errRow["ROW_NO"] = excelRow.ToString();
                        errRow["INVOICE_SLNO"] = invoiceSlNo;
                        errRow["INVOICE_NO"] = invoiceNo;
                        errRow["COLUMN_NAME"] = "INVOICE_SLNO / INVOICE_NO";
                        errRow["EXPECTED_VALUE"] = "INVOICE_NO = " + serialToInvoiceMap[invoiceSlNo] + " (first seen mapping)";
                        errRow["FOUND_VALUE"] = "INVOICE_NO = " + invoiceNo;
                        errRow["ERROR_TYPE"] = "Invoice Serial vs Invoice No Mismatch";
                        dtErrors.Rows.Add(errRow);
                    }
                }
            }


            if (string.IsNullOrEmpty(invoiceNo))
                continue;

            if (!invoiceSnapshot.ContainsKey(invoiceNo))
            {

                string[] snapshot = new string[columnsToValidate.Count];
                for (int c = 0; c < columnsToValidate.Count; c++)
                {
                    string colName = columnsToValidate[c];
                    snapshot[c] = filteredRows.Columns.Contains(colName)
                        ? (row[colName] == DBNull.Value ? "" : row[colName].ToString().Trim())
                        : "";
                }
                invoiceSnapshot[invoiceNo] = snapshot;
                invoiceFirstRowNum[invoiceNo] = excelRow;
            }
            else
            {

                string[] snapshot = invoiceSnapshot[invoiceNo];
                int firstSeenAt = invoiceFirstRowNum[invoiceNo];

                for (int c = 0; c < columnsToValidate.Count; c++)
                {
                    string colName = columnsToValidate[c];
                    string currentValue = filteredRows.Columns.Contains(colName)
                        ? (row[colName] == DBNull.Value ? "" : row[colName].ToString().Trim())
                        : "";
                    string expectedValue = snapshot[c];

                    if (currentValue != expectedValue)
                    {
                        DataRow errRow = dtErrors.NewRow();
                        errRow["ROW_NO"] = excelRow.ToString();
                        errRow["INVOICE_SLNO"] = invoiceSlNo;
                        errRow["INVOICE_NO"] = invoiceNo;
                        errRow["COLUMN_NAME"] = colName;
                        //errRow["EXPECTED_VALUE"] = expectedValue + " (Row " + firstSeenAt + ")";
                        errRow["EXPECTED_VALUE"] = expectedValue;
                        errRow["FOUND_VALUE"] = currentValue;
                        errRow["ERROR_TYPE"] = "Column Consistency Mismatch";
                        dtErrors.Rows.Add(errRow);
                    }
                }
            }
        }

        return dsErrors;
    }
}