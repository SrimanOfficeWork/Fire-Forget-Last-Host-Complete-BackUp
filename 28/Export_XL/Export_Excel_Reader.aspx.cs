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
using System.Collections;
using System.Globalization;
using ClosedXML.Excel;

public partial class Export_Excel_Reader : ThemeClass
{
    AppSession aps = new AppSession();
    UserBO ObjUBO = new UserBO();
    Export_General_New Export = new Export_General_New();
    UserBO objUBO = new UserBO();
    AdminMasterDetails admin = new AdminMasterDetails();
    Jobwise_xl_Upload xl = new Jobwise_xl_Upload();
    Export_PDF_Upload exp_pdf = new Export_PDF_Upload();
    Auto_Search Auto = new Auto_Search();
    ErrorLogs log = new ErrorLogs();
    eroyalmaster erm = new eroyalmaster();
    adminmaster adm = new adminmaster();

    DataTable Dt_gen = new DataTable();
    DataTable Dt_Invoice = new DataTable();
    DataTable Dt_Item = new DataTable();
    DataTable Dt_DBK = new DataTable();
    DataTable Dt_anx = new DataTable();
    DataTable Dt_anx_Air = new DataTable();
    DataTable dt_gvew = new DataTable();
    DataTable dataTable = new DataTable();
    DataTable dt_Temp_Con = new DataTable();
    DataTable dt_AR_4_Ds = new DataTable();
    DataTable dt_Temp_Inv = new DataTable();

    DataSet ds_ExcelDt = new DataSet();
    DataSet ds_IEC = new DataSet();
    DataSet ds_draw = new DataSet();
    DataSet GetLocalAPIData = new DataSet();
    DataSet ds_API = new DataSet();
    DataSet ds_except = new DataSet();
    DataSet ds_OrderDetails = null;

    public String Xml_Inv;

    public int MAX_ID = 0; int rowIndex = 0; int INVOICE_SLNO = 0;
    public string GENERAL_EXPORT_JOBNO = "";
    public int totalItemSlNo = 1;
    public string currentuser;
    public string currentbranch;
    public string Working_Period;
    public string COMPANY_IDD, comp_ConnectionStr, LoginDate, SB_TYPE, JOBNO;    
    string ds_lkupDetails = string.Empty;

    bool IsValid = true;
    bool IsValidInv = true;

    private SqlConnection con;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

        SB_TYPE = "Free Duty";
        COMPANY_IDD = Session["COMPANY_ID"].ToString();
        hdn_companyID.Value = COMPANY_IDD;
        comp_ConnectionStr = Session["currentcomp_db"].ToString();

        ListBox_ItemSlno.EnableViewState = true;
        string TRANS_MODE = Session["CUSTOMHOUSE_TRANSPORT_MODE"].ToString();
        if (TRANS_MODE == "A")
        {
            hdfTransport_mode.Value = "Air";
        }
        else if (TRANS_MODE == "S")
        {
            hdfTransport_mode.Value = "Sea";
        }
        else if (TRANS_MODE == "L")
        {
            hdfTransport_mode.Value = "Land";
        }

        Hdn_STANDARD_TYPE.Value = "STD";
        //btnupload.Visible = true;
        if (!IsPostBack)
        {
            Bind_Clients();
            AUTO_JOBNO();
            txtjobPS.Text = hdn_JOBNO_PS.Value;
            GENERAL_EXPORT_JOBNO = hdn_JOBNO_PS.Value;
        }

        con = new SqlConnection(HttpContext.Current.Session["currentcomp_db"].ToString());

        if (COMPANY_IDD == "10")
        {
            lbl_Port_Final_Desc.Visible = true;
            txtPortFinalDes.Visible = true;
        }
        if (currentuser == "RTS" || currentuser == "s" || currentuser == "k" || currentuser == "Aji")
        {
            ImageButton8.Visible = true;
        }
    }

    public void Bind_Clients()
    {
        DataSet ds_client = new DataSet();

        erm.EExp_cli_mas_id = "0";
        erm.EExp_client_iec_name = "ALL";
        erm.EXP_CLIENT_BRANCH_SLNO = "0";
        erm.Ename = "Bind_Exporter_List";
        erm.EWorking_Period = Working_Period;
        erm.startRowIndex = "0";
        erm.maximumRows = "0";
        ds_client = erm.RetrieveAll_Exp_Client_Master();

        try
        {
            if (ds_client.Tables[0].Rows.Count > 0)
            {
                ddl_ExporterName.DataSource = ds_client.Tables[0];
                ddl_ExporterName.DataTextField = "EXPORTER_NAME";
                ddl_ExporterName.DataTextField = "EXPORTER_NAME";
                ddl_ExporterName.DataBind();
            }
        }
        catch(Exception ex)
        {
            ddl_ExporterName.DataBind();
        }

        if (txtBuyer.Text == "")
        {
            txtBuyer.Text = "SAME AS CONSIGNEE";
        }

        Get_SchemeCode();
        ddlterms();
    }

    public void ddlterms()
    {
        ddlTerms.Items.Add("FOB");
        ddlTerms.Items.Add("CI");
        ddlTerms.Items.Add("CF");
        ddlTerms.Items.Add("CIF");
    }

    public void Get_SchemeCode()
    {
        DataSet ds_sh = new DataSet();
        adm.name = "SCHEME_EXPORT_CODE";
        Session["dss"] = adm.RetrieveAll_Scheme_Export();
        ds_sh = (DataSet)Session["dss"];
        ddlSchemeCode.DataSource = ds_sh;
        ddlSchemeCode.DataTextField = "SCHEME_CODE";
        ddlSchemeCode.DataValueField = "SCHEME_CODE";
        ddlSchemeCode.Items.Add("");      
        ddlSchemeCode.DataBind();
        ddlSchemeCode.Items.Insert(0, new ListItem("", ""));

    }

    public void Get_AdCode()
    {
        DataSet ds = new DataSet();
        Auto.Ename = "Get_ADCODE";
        Auto.Enamesearch = ViewState["exp_name"].ToString();
        Auto.NSearch = ViewState["IEC"].ToString();
        ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlAdCode.DataSource = ds.Tables[0];
            ddlAdCode.DataTextField = "ADCODE_IEC_ADCODE";
            ddlAdCode.DataTextField = "ADCODE_IEC_ADCODE";
            ddlAdCode.DataBind();
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
        Dt_gen.Columns.Add("TYPE_OF_EXPORTER");

        //--------Dt_anx------------SEA
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

        //AIR
        Dt_anx_Air.Columns.Add("ANNEX_AIR_NATURE_OF_CARGO");
        Dt_anx_Air.Columns.Add("ANNEX_AIR_MARKS_NOS");
        Dt_anx_Air.Columns.Add("ANNEX_AIR_TOTAL_PACKAGES");
        Dt_anx_Air.Columns.Add("ANNEX_AIR_GROSS_WEIGHT");
        Dt_anx_Air.Columns.Add("ANNEX_AIR_NET_WEIGHT");
        Dt_anx_Air.Columns.Add("ANNEX_AIR_GR_UNIT_CODE");


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
        Dt_Invoice.Columns.Add("FOB_CHARGES");
        Dt_Invoice.Columns.Add("FREIGHT_CHARGES");
        Dt_Invoice.Columns.Add("INSURANCE_CHARGES");
        Dt_Invoice.Columns.Add("COMMISSION_CHARGES");
        Dt_Invoice.Columns.Add("OTHER_DED_CHARGES");

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
        Dt_Item.Columns.Add("ITEM_DESC_CUSTOMIZED");
        Dt_Item.Columns.Add("SCHEME_CODE");
        Dt_Item.Columns.Add("STR_YES_NO");
        Dt_Item.Columns.Add("REWARD_YES_NO");
        Dt_Item.Columns.Add("RODTEP");
        Dt_Item.Columns.Add("CESS_YN");
        Dt_Item.Columns.Add("END_USE_OF_ITEM");
        Dt_Item.Columns.Add("ITEM_ACCESSORIES_DESC");
        Dt_Item.Columns.Add("DRAWBACK_DESC");
        Dt_Item.Columns.Add("DBK_SL_NO");
        Dt_Item.Columns.Add("DBK_UNIT");
        Dt_Item.Columns.Add("RITCNO");
        Dt_Item.Columns.Add("SQC");
        Dt_Item.Columns.Add("TAXABLE_VALUE");
        Dt_Item.Columns.Add("IGST_AMT");

        Dt_DBK.Columns.Add("DRAWBACK_SLNO");
        Dt_DBK.Columns.Add("DRAWBACK_DESCRIPTION");
        Dt_DBK.Columns.Add("DRAWBACK_RATE");
        Dt_DBK.Columns.Add("DRAWBACK_VALUE_CAP");
        Dt_DBK.Columns.Add("DRAWBACK_UNIT");
        Dt_DBK.Columns.Add("DRAWBACK_NOOFUNITS");
        Dt_DBK.Columns.Add("STATE_LEVEL_ADV_RATE");
        Dt_DBK.Columns.Add("STATE_LEVEL_ADV_AMT");
        Dt_DBK.Columns.Add("CENTRAL_LEVEL_ADV_RATE");
        Dt_DBK.Columns.Add("CENTRAL_LEVEL_ADV_AMT");    
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
            //DataTable GridViewMasterDataBind = (DataTable)ViewState["MasterDataChecking"];
            //if (GridViewMasterDataBind != null)
            //{
            //    TextBox txtItemDesc = e.Row.FindControl("txtItemDesc") as TextBox;
            //    if (txtItemDesc != null)
            //    {
            //        string GetItemDescriptionInDS = txtItemDesc.Text;
            //        if (rowIndex < GridViewMasterDataBind.Rows.Count)
            //        {
            //            string GetItemDescriptionInGV = GridViewMasterDataBind.Rows[rowIndex]["ITEM_DESC"].ToString();
            //            if (GetItemDescriptionInDS == GetItemDescriptionInGV)
            //            {
            //                txtItemDesc.BorderColor = System.Drawing.Color.Red;
            //                txtItemDesc.BackColor = System.Drawing.Color.MediumTurquoise;
            //                rowIndex++;
            //            }
            //        }
            //    }
            //}

            DataSet ds_schemeCode = (DataSet)Session["dss"];
            DropDownList ddl_SchemeCode = e.Row.FindControl("ddl_SchemeCode") as DropDownList;

            if (ddl_SchemeCode != null && ds_schemeCode != null)
            {
                ddl_SchemeCode.DataSource = ds_schemeCode.Tables[0]; 
                ddl_SchemeCode.DataTextField = "SCHEME_CODE"; 
                ddl_SchemeCode.DataValueField = "SCHEME_CODE";
                ddl_SchemeCode.DataBind(); 

                string selectedSchemeCode = DataBinder.Eval(e.Row.DataItem, "SCHEME_CODE").ToString();
                ddl_SchemeCode.SelectedValue = selectedSchemeCode;
            }

            if (Connection.COMPANYID() == "517")
            {
                TextBox txtItemQty = e.Row.FindControl("txtItemQty") as TextBox;
                TextBox txtQtyCode = e.Row.FindControl("txtQtyCode") as TextBox;
                TextBox txtItemUnitPrice = e.Row.FindControl("txtItemUnitPrice") as TextBox;
                TextBox txtItemAmt = e.Row.FindControl("txtItemAmt") as TextBox;
                TextBox txt_IGSTRate = e.Row.FindControl("txt_IGSTRate") as TextBox;

                txtItemQty.Enabled = true;
                txtQtyCode.Enabled = true;
                txtItemUnitPrice.Enabled = true;
                txtItemAmt.Enabled = true;
                txt_IGSTRate.Enabled = true;
            }
        }
    }

    private void BindSchemeCodes(DropDownList ddl)
    {
        ddl.DataSource = dt_gvew;
        ddl.DataTextField = "SCHEME_CODE";
        ddl.DataValueField = "SCHEME_CODE";
        ddl.Items.Add("");
        ddl.DataBind();
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Export PDF Upload', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Export PDF Upload', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void btnPrevData_Click(object sender, EventArgs e)
    {
        string strFolderPath = "";
        string strImagePath = "";

        try
        {
            string savePath = Server.MapPath("~/Submission/ExportExcelReader/");
            if (Directory.Exists(savePath) == false)
            {
                Directory.CreateDirectory(savePath);
            }

            int FileSetLimit = 5;
            if (COMPANY_IDD == "1586")
            {
                FileSetLimit = 15;
            }
            if (Request.Files.Count > 0 && Request.Files.Count <= FileSetLimit)
            {
                int FileUploadCount = Request.Files.Count;
                ViewState["FileUploadCount"] = FileUploadCount;

                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFile uploadedFile = Request.Files[i]; // Access file by index

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

                    string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strImagePath + ";Extended Properties='Excel 12.0 Xml;HDR=YES';";

                    using (OleDbConnection connection = new OleDbConnection(connectionString))
                    {
                        connection.Open();
                        DataTable schemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                        if (schemaTable == null || schemaTable.Rows.Count == 0)
                            throw new Exception("No sheets found in Excel file.");
                        ds_ExcelDt.Tables.Clear();
                        foreach (DataRow row in schemaTable.Rows)
                        {
                            string sheetName = row["TABLE_NAME"].ToString();

                            // Skip named ranges or hidden/system tables
                            if (!sheetName.EndsWith("$") && !sheetName.EndsWith("$'"))
                                continue;

                            DataTable sheetData = new DataTable();
                            string query = "SELECT * FROM [" + sheetName + "]";
                            using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
                            {
                                adapter.Fill(sheetData);
                                sheetData.TableName = sheetName.TrimEnd('$').Trim('\'');                                
                                ds_ExcelDt.Tables.Add(sheetData);
                            }
                        }
                    }

                    string exp_name = "", branch_slno = "";
                    if (ddl_ExporterName.SelectedValue.Contains("--"))
                    {
                        string[] sp = ddl_ExporterName.SelectedValue.Replace("--", "^").Split('^');
                        branch_slno = sp[0];
                        exp_name = sp[1];

                        ViewState["branch_slno"] = branch_slno;
                        ViewState["exp_name"] = exp_name;
                        Session["exp_name"] = exp_name;
                    }
                    if (ds_ExcelDt != null)
                    {
                        ds_API = getCustInvDetls_Excel_Datatable(exp_name, strImagePath, ds_ExcelDt);
                        if (ds_API.Tables.Count > 0 && ds_API.Tables[0].Rows.Count > 0 && ds_API.Tables[1].Rows.Count > 0)
                        {
                            txtExporterName.Text = exp_name;

                            string consigneeName = ds_API.Tables[0].Rows[0]["ConsigneeName"].ToString().Replace("Consignee ", "");
                            if (consigneeName.Length > 35)
                            {
                                string substring = consigneeName.Substring(0, 35);
                                txtConsigneeName.Text = substring;
                            }
                            else
                            {
                                txtConsigneeName.Text = consigneeName.Replace("Consignee ", "");
                            }

                            string buyerName = ds_API.Tables[0].Rows[0]["BuyerName"].ToString();
                            if (buyerName.Length > 35)
                            {
                                string buyerSubstring = buyerName.Length > 35 ? buyerName.Substring(0, 35) : buyerName;
                                txtBuyer.Text = buyerSubstring;
                            }
                            else
                            {
                                if (buyerName != "")
                                {
                                    txtBuyer.Text = buyerName;
                                }
                                else
                                {
                                    txtBuyer.Text = "SAME AS CONSIGNEE";
                                }
                            }

                            txtNotifyParty.Text = "";
                            txtInvoiceNo.Text = ds_API.Tables[0].Rows[0]["invNo"].ToString();
                            txtInvoiceDate.Text = ds_API.Tables[0].Rows[0]["invDate"].ToString();
                            txtCurrency.Text = Get_Valid_Curr_Name(ds_API.Tables[0].Rows[0]["Currency"].ToString());
                            txtCountry.Text = ds_API.Tables[0].Rows[0]["cntyDec"].ToString();
                            txtPort.Text = ds_API.Tables[0].Rows[0]["prtOfDschrg"].ToString();
                            txtPortFinalDes.Text = ds_API.Tables[0].Rows[0]["prtOfDschrg"].ToString();
                            string TERMS1 = ds_API.Tables[0].Rows[0]["Terms"].ToString().Contains("FOB") ? "FOB" : ds_API.Tables[0].Rows[0]["Terms"].ToString();
                            if (COMPANY_IDD == "1586")
                            {
                                ddlTerms.Text = "FOB";
                            }
                            else
                            {
                                ddlTerms.Text = TERMS1;
                            }
                            ViewState["IEC"] = ds_API.Tables[0].Rows[0]["IEC"].ToString();
                            if (ViewState["IEC"].ToString() == null || ViewState["IEC"].ToString() == string.Empty || ViewState["IEC"].ToString() == "" ||
                                    ViewState["IEC"].ToString() == "null")
                            {
                                Auto_Search Auto = new Auto_Search();
                                DataSet ds = new DataSet();
                                Auto.Ename = "Import_Details_Bind";
                                Auto.Enamesearch = exp_name;
                                Auto.NSearch = branch_slno;
                                ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    string IEC_NO = ds.Tables[0].Rows[0]["IMP_EXP_IECNO"].ToString();
                                    string BRANCH_NO = ds.Tables[0].Rows[0]["IMP_EXP_BRSLNO"].ToString();
                                    ViewState["IEC"] = IEC_NO;
                                }
                            }
                            ViewState["FOB_CHARGES"] = "";
                            ViewState["FREIGHT_CHARGES"] = "";
                            ViewState["INSURANCE_CHARGES"] = "";
                            ViewState["COMMISSION_CHARGES"] = "";
                        }

                        DataTable dt_dbk = new DataTable();

                        INVOICE_SLNO = 1 + INVOICE_SLNO;
                        if (INVOICE_SLNO == 1)
                        {
                            dt_Temp_Inv.Columns.Add("INVOICE_SLNO");
                            dt_Temp_Inv.Columns.Add("InvoiceNo");
                            dt_Temp_Inv.Columns.Add("InvoiceDate");
                            dt_Temp_Inv.Columns.Add("Currency");
                            dt_Temp_Inv.Columns.Add("Terms");
                            dt_Temp_Inv.Columns.Add("InvoiceValue");
                            dt_Temp_Inv.Columns.Add("FREIGHT_CHARGES");
                            dt_Temp_Inv.Columns.Add("INSURANCE_CHARGES");
                            dt_Temp_Inv.Columns.Add("OTHER_DED_CHARGES");

                            dt_gvew.Columns.Add("INVOICE_SLNO");
                            dt_gvew.Columns.Add("ITEM_SLNO");
                            dt_gvew.Columns.Add("ITEM_DESC");
                            dt_gvew.Columns.Add("ITEM_QTY");
                            dt_gvew.Columns.Add("ITEM_QTY_CODE");
                            dt_gvew.Columns.Add("ITEM_UNITPRICE");
                            dt_gvew.Columns.Add("ITEM_UNITCODE");
                            dt_gvew.Columns.Add("ITEM_AMOUNT");
                            dt_gvew.Columns.Add("INFO_QTY");
                            dt_gvew.Columns.Add("INFO_UNITPRICE");
                            dt_gvew.Columns.Add("SCHEME_CODE");
                            dt_gvew.Columns.Add("STR_YES_NO");
                            dt_gvew.Columns.Add("REWARD_YES_NO");
                            dt_gvew.Columns.Add("RODTEP");
                            dt_gvew.Columns.Add("CESS_YN");
                            dt_gvew.Columns.Add("END_USE_OF_ITEM");
                            dt_gvew.Columns.Add("UNDER_PTA_FTA");
                            dt_gvew.Columns.Add("IGST_PAYMENT");
                            dt_gvew.Columns.Add("ITEM_ACCESSORIES_DESC");
                            dt_gvew.Columns.Add("DRAWBACK_DESC");
                            dt_gvew.Columns.Add("IGST_RATE");
                            dt_gvew.Columns.Add("DBK_SL_NO");
                            dt_gvew.Columns.Add("DBK_UNIT");
                            dt_gvew.Columns.Add("RITCNO");

                            dt_AR_4_Ds.Columns.Add("AR4_INVOICE_NO", typeof(string));
                            dt_AR_4_Ds.Columns.Add("AR4_INVOICE_SLNO", typeof(int));
                            dt_AR_4_Ds.Columns.Add("AR4_RUN_ID", typeof(int));
                            dt_AR_4_Ds.Columns.Add("AR4_ITEM_NO", typeof(int));
                            dt_AR_4_Ds.Columns.Add("AR4_NO", typeof(string));
                            dt_AR_4_Ds.Columns.Add("AR4_DATE", typeof(string));
                            dt_AR_4_Ds.Columns.Add("AR4_COMMISSION_RATE", typeof(string));
                            dt_AR_4_Ds.Columns.Add("AR4_DIVISION", typeof(string));
                        }

                        for (int ak = 0; ak <= ds_API.Tables[0].Rows.Count - 1; ak++)
                        {
                            txtInvoiceNo.Text = ds_API.Tables[0].Rows[0]["invNo"].ToString();
                            txtInvoiceDate.Text = ds_API.Tables[0].Rows[0]["invDate"].ToString();
                            txtCurrency.Text = Get_Valid_Curr_Name(ds_API.Tables[0].Rows[0]["Currency"].ToString());

                            string InvoiceValue = ds_API.Tables[0].Rows[0]["inv_val"].ToString().Replace(",", "").Replace("$", "");

                            dt_Temp_Inv.Rows.Add(INVOICE_SLNO, txtInvoiceNo.Text, txtInvoiceDate.Text, txtCurrency.Text, ddlTerms.Text, InvoiceValue, ViewState["FREIGHT_CHARGES"], ViewState["INSURANCE_CHARGES"], ViewState["OTHER_DED_CHARGES"]);

                            ViewState["dt_Invoice"] = dt_Temp_Inv;
                        }


                        foreach (DataColumn col in ds_API.Tables[1].Columns)
                        {
                            //if (col.ColumnName.Contains("Kind"))
                            //{
                            //    ds_API.Tables[1].Columns[col.ColumnName].ColumnName = "NO_KIND_PKGS";
                            //}
                            if (col.ColumnName.Contains("Description of Goods") || col.ColumnName.Contains("Merchandise Description") || col.ColumnName.Contains("ITEM DESCRIPTION"))
                            {
                                ds_API.Tables[1].Columns[col.ColumnName].ColumnName = "ITEM_DESC";
                            }
                            if (col.ColumnName.Contains("QTY") || col.ColumnName == "Qty" || col.ColumnName == "Shipped Qty" || col.ColumnName.Contains("Quantity") || col.ColumnName.Contains("QUANTITY"))
                            {
                                ds_API.Tables[1].Columns[col.ColumnName].ColumnName = "ITEM_QTY";
                            }
                            if ((col.ColumnName.Contains("Rate") || col.ColumnName.Contains("RATE") || col.ColumnName.Contains("UNIT") || col.ColumnName.Contains("PRICE") || col.ColumnName.Contains("Unit Price")) && !col.ColumnName.Contains("Info_Unitprice"))
                            {
                                ds_API.Tables[1].Columns[col.ColumnName].ColumnName = "ITEM_UNITPRICE";
                            }
                            if (col.ColumnName.Contains("AMOUNT") || col.ColumnName.Contains("Amount") || col.ColumnName.Contains("Eextended Amount"))
                            {
                                ds_API.Tables[1].Columns[col.ColumnName].ColumnName = "ITEM_AMOUNT";
                            }
                            if (col.ColumnName.Contains("Info_Qty"))
                            {
                                ds_API.Tables[1].Columns[col.ColumnName].ColumnName = "INFO_QTY";
                            }
                            if (col.ColumnName.Trim() == "Unit" || col.ColumnName.Trim() == "Qtycode")
                            {
                                ds_API.Tables[1].Columns[col.ColumnName].ColumnName = "ITEM_QTY_CODE";
                            }

                        }

                        string Item_Desc = "", Item_UnitPrice = "", Quantity = "", QtyCode = "", HSNCode = "", SchemeCode = "", INFO_QTY = "", AI_Page_Count = "2", EndUseOfItems = "", UnderPTA = "", IGSTPayStatus = "NA";
                        for (int cc = 0; cc <= ds_API.Tables[1].Rows.Count - 1; cc++)
                        {
                            if (COMPANY_IDD == "816")
                            {
                                Item_Desc = "INDUSTRIAL MATERIAL-" + ds_API.Tables[1].Rows[cc]["ITEM_DESC"].ToString().Replace("×", "x").Replace("–", "-");
                                AI_Page_Count = "1";
                            }
                            else
                            {
                                Item_Desc = ds_API.Tables[1].Rows[cc]["ITEM_DESC"].ToString();
                            }
                            Item_UnitPrice = ds_API.Tables[1].Rows[cc]["ITEM_UNITPRICE"].ToString().Replace(",", "").Replace("$", "");
                            Quantity = ds_API.Tables[1].Rows[cc]["ITEM_QTY"].ToString().Replace(",", "").Replace("$", "");
                            if (COMPANY_IDD == "816" || COMPANY_IDD == "3335" || COMPANY_IDD == "10")
                            {
                                QtyCode = ds_API.Tables[1].Rows[cc]["ITEM_QTY_CODE"].ToString();//Qtycode
                            }
                            else
                            {
                                QtyCode = ds_API.Tables[0].Rows[0]["Qtycode"].ToString();//Qtycode
                            }
                            SchemeCode = ds_API.Tables[0].Rows[0]["Schemecode"].ToString();
                            HSNCode = ds_API.Tables[1].Rows[cc]["HSNCode"].ToString();
                            if (HSNCode.Length > 8)
                            {
                                HSNCode = HSNCode.Substring(0, 8);
                            }
                            INFO_QTY = ds_API.Tables[1].Rows[cc]["INFO_QTY"].ToString();
                            if (exp_name.ToUpper() == "MOD ART")
                            {
                                try
                                {
                                    string[] Split_Qty_QtyCode = Quantity.Split(' ');
                                    if (Split_Qty_QtyCode != null)
                                    {
                                        Quantity = Split_Qty_QtyCode[0];
                                        QtyCode = Split_Qty_QtyCode[1];
                                    }
                                }
                                catch (Exception ex)
                                {
                                }
                            }

                            //#Item
                            string GetAmount = ds_API.Tables[1].Rows[cc]["ITEM_AMOUNT"].ToString().TrimEnd().Replace(",", "").Replace("$", "");

                            if (COMPANY_IDD == "816")
                            {
                                if (Quantity != "" && Quantity != null && GetAmount != "" && GetAmount != null)
                                {
                                    decimal Cal_Rate = Convert.ToDecimal(GetAmount) / Convert.ToDecimal(Quantity);
                                    Item_UnitPrice = Cal_Rate.ToString("N5").Replace(",", "");
                                }
                            }

                            DataSet ds_get_data = new DataSet();
                            erm.Eproduct_imp_ceth = exp_name;
                            erm.Eproduct_imp_description = Item_Desc;
                            //erm.Ename = "Get_Master_Data";
                            erm.Ename = "Get_Excel_Data";
                            erm.EWorking_Period = Working_Period;
                            ds_get_data = erm.RetrieveAll_Export_PDF_Settings_MASTER();

                            if (ds_get_data.Tables[0].Rows.Count > 0)
                            {
                                SchemeCode = ds_get_data.Tables[0].Rows[0]["SCHEME_CODE"].ToString();
                                string STR = ds_get_data.Tables[0].Rows[0]["STR_YES_NO"].ToString();
                                string RewardsPts = ds_get_data.Tables[0].Rows[0]["REWARD_YES_NO"].ToString();
                                string RODTEP = ds_get_data.Tables[0].Rows[0]["RODTEP"].ToString();
                                string CessDetails = ds_get_data.Tables[0].Rows[0]["CESS_YN"].ToString();
                                EndUseOfItems = ds_get_data.Tables[0].Rows[0]["END_USE_OF_ITEM"].ToString();
                                UnderPTA = ds_get_data.Tables[0].Rows[0]["UNDER_PTA_FTA"].ToString();
                                IGSTPayStatus = ds_get_data.Tables[0].Rows[0]["IGST_PAYMENT"].ToString();
                                string ITEM_ACCESSORIES_DESC = ds_get_data.Tables[0].Rows[0]["ITEM_ACCESSORIES_DESC"].ToString();
                                string DRAWBACK_DESC = ds_get_data.Tables[0].Rows[0]["DBK_DECLARATION"].ToString();
                                string IGST_RATE = ds_get_data.Tables[0].Rows[0]["IGST_RATE"].ToString();
                                string DBK_SL_NO = ds_get_data.Tables[0].Rows[0]["DBK_SL_NO"].ToString();
                                string DBK_UNIT = ds_get_data.Tables[0].Rows[0]["DBK_UNIT"].ToString();
                                if (HSNCode == "" && HSNCode == string.Empty)
                                {
                                    HSNCode = ds_get_data.Tables[0].Rows[0]["RITC_NO"].ToString();
                                }

                                dt_gvew.Rows.Add(INVOICE_SLNO, cc + 1, Item_Desc.Trim(), Quantity, Get_Valid_Qty_Code(QtyCode), Item_UnitPrice,
                                    Get_Valid_Curr_Name(txtCurrency.Text.Trim()), GetAmount, INFO_QTY, "", SchemeCode, STR, RewardsPts, RODTEP, CessDetails, EndUseOfItems,
                                    UnderPTA, IGSTPayStatus, ITEM_ACCESSORIES_DESC, DRAWBACK_DESC, IGST_RATE, DBK_SL_NO, DBK_UNIT, HSNCode);
                            }
                            else
                            {
                                if (SchemeCode == "" || SchemeCode == string.Empty || SchemeCode == null)
                                {
                                    SchemeCode = "00-FREE SHIPPING BILL";
                                }
                                if (COMPANY_IDD == "1586")
                                {
                                    SchemeCode = "19-DRAWBACK (DBK)";
                                    EndUseOfItems = "GNX100";
                                    UnderPTA = "NCPTI";
                                    IGSTPayStatus = "LUT";
                                }
                                dt_gvew.Rows.Add(INVOICE_SLNO, cc + 1, Item_Desc.Trim(), Quantity, Get_Valid_Qty_Code(QtyCode), Item_UnitPrice,
                                    Get_Valid_Curr_Name(txtCurrency.Text.Trim()), GetAmount, INFO_QTY, "", SchemeCode, "N", "Y", "N", "N", EndUseOfItems,
                                    UnderPTA, IGSTPayStatus, "", "", "", "", "", HSNCode);
                            }
                            HSNCode = "";
                            SchemeCode = "";
                        }

                        if (exp_name.ToUpper() == "GROWMECH INDUSTRIES PRIVATE LIMITED")
                        {
                            for (int ka = 0; ka <= ds_API.Tables[2].Rows.Count - 1; ka++)
                            {
                                string AR4_NO = ds_API.Tables[2].Rows[ka]["AR4_NO"].ToString().Replace("INV NO:", "").Trim();
                                string AR4_DATE = ds_API.Tables[2].Rows[ka]["AR4_DATE"].ToString().Trim();
                                if (AR4_DATE != "" && AR4_DATE != null)
                                {
                                    AR4_DATE = Get_Valid_Date1(ds_API.Tables[2].Rows[ka]["AR4_DATE"].ToString()).Trim();
                                }
                                string AR4_COMMISSION_RATE = ds_API.Tables[2].Rows[ka]["AR4_COMMISSION_RATE"].ToString().Replace("GSTIN/UIN :", "").Trim();
                                string AR4_DIVISION = ds_API.Tables[2].Rows[ka]["AR4_DIVISION"].ToString().Replace("SUPPLIER :", "").Trim();
                                //AR4_DIVISION = AR4_DIVISION.Length > 20 ? AR4_DIVISION.Substring(0, 20) : AR4_DIVISION;

                                dt_AR_4_Ds.Rows.Add(txtInvoiceNo.Text, 1, ka + 1, ka + 1, AR4_NO, AR4_DATE, AR4_COMMISSION_RATE, AR4_DIVISION);
                            }
                            ViewState["dt_AR_4_Details"] = dt_AR_4_Ds;
                        }

                        exp_pdf.EXPORTER_NAME = exp_name;
                        exp_pdf.BRANCH_NO = branch_slno;
                        exp_pdf.JOBNO = JOBNO;
                        exp_pdf.flag = "Select_Except_desc_from_Master";
                        exp_pdf.USER_ID = currentuser;
                        exp_pdf.WORKINGPERIOD = Working_Period;
                        exp_pdf.Branch_Code = currentbranch;
                        //DataSet MasterDataChecking = exp_pdf.Exp_PDF_Upload_New_XML_AI(Dt_gen, dt_gvew, dt_dbk, Dt_Invoice, Dt_anx, Dt_anx_Air);
                        //if (MasterDataChecking.Tables[0].Rows.Count > 0)
                        //{
                        //    hdn_missed_Desc.Value = "1";
                        //    ViewState["MasterDataChecking"] = MasterDataChecking.Tables[0];
                        //}
                        //lbl_loading.Text = "File converted successfully..Click Upload";
                        totalItemSlNo = (totalItemSlNo <= 20) ? 1 : (totalItemSlNo / 20) + ((totalItemSlNo % 20 >= 1) ? 1 : 0);
                        lbl_loading.Text = "<span style='color: green; font-weight: bold;'>✅ File converted successfully... Click Upload.</span>";
                        hdn_missed_Desc.Value = "0";
                        btnupload.Visible = true;

                        ViewState["dt_Item"] = dt_gvew;
                        ViewState["ds_xl_Output"] = ds_API;

                        gv_ItemPDF.DataSource = dt_gvew;
                        gv_ItemPDF.DataBind();
                        for (int cd = 0; cd < dt_gvew.Rows.Count; cd++)
                        {
                            DropDownList ddl_SchemeCode = (DropDownList)gv_ItemPDF.Rows[cd].FindControl("ddl_SchemeCode");
                            string schemeCode = dt_gvew.Rows[cd]["SCHEME_CODE"].ToString();
                            foreach (ListItem item in ddl_SchemeCode.Items)
                            {
                                if (item.Value.Split('-')[0] == schemeCode)
                                {
                                    ddl_SchemeCode.SelectedValue = item.Value;
                                    break;
                                }
                            }
                        }
                        Get_AdCode();
                        if (gv_ItemPDF.Rows.Count > 0)
                        {
                            ViewState["GridViewData"] = dt_gvew;
                            ddl_Select_ItemRITC_SelectedIndexChanged(sender, e);
                        }
                        lblmsg.Text = "";

                        con.Open();
                        SqlCommand Scmd =
                            new SqlCommand(
                                "select * from PDF_AI_COUNT_DETAILS where PDF_JOB_NO = '" + txtjobPS.Text + "' and PDF_EXP_IMP_NAME='" + exp_name + "' and PDF_BRANCH_CODE ='" + currentbranch + "'", con);
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
                                  "Update PDF_AI_COUNT_DETAILS set PDF_UPLOAD_COUNT=(" + PDF_UPLOAD_COUNT + "+1),PDF_REMARKS= PDF_REMARKS + " + AI_Page_Count + ",PDF_USER_ID='" + currentuser + "',PDF_DATE_TIME=GetDate()," +
                            "PDF_STATUS='S',PDF_BRANCH_CODE='" + currentbranch + "',PDF_WORKING_PERIOD='" + Working_Period + "' where PDF_ID=" + PDF_ID + "", con);
                            int result = Ucmd.ExecuteNonQuery();
                        }
                        else
                        {

                            SqlCommand cmd =
                                new SqlCommand(
                                    "insert into PDF_AI_COUNT_DETAILS(PDF_JOB_NO,PDF_EXP_IMP_NAME,PDF_MODE,PDF_UPLOAD_COUNT,PDF_REMARKS,PDF_USER_ID,PDF_DATE_TIME,PDF_STATUS,PDF_BRANCH_CODE,PDF_WORKING_PERIOD) values('" + txtjobPS.Text + "','" +
                                    exp_name + "','EXE','1','" + AI_Page_Count + "','" + currentuser + "',GetDate(),'S','" + currentbranch + "','" + Working_Period + "')", con);
                            int result = cmd.ExecuteNonQuery();

                        }
                        con.Close();
                    }
                }
            }
            else
            {
                Alert_msg("Please Upload File..!");
            }
        }
        catch (Exception ex)
        {
            log.makeLog("Message ==> " + ex.Message);
            lblmsg.Text = " Message ==> " + ex.Message + " InnerException ==> " + ex.InnerException + " StackTrace ==>" + ex.StackTrace;
        }
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
                    System.Data.DataTable dtdetail = ds_OrderDetails.Tables["Details"];
                    if (dtdetail.Columns.Count > 0)
                    {
                        dtable = readDetailPDFval(custname, "Details", dict, ds, InvType);
                        datasetinvoice.Tables.Add(dtable);
                    }

                    if (custname == "GROWMECH INDUSTRIES PRIVATE LIMITED")
                    {
                        System.Data.DataTable dt_AR_4_detail = ds_OrderDetails.Tables["AR_4_Details"];
                        if (dt_AR_4_detail.Columns.Count > 0)
                        {
                            Atable = readAR4DetailPDFval(custname, "AR_4_Details", dict, ds, InvType);
                            datasetinvoice.Tables.Add(Atable);
                        }
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

    public void getlkupval(string customer, string InvType)
    {
        string strcon = Connection.GetConnection();
        SqlConnection conn = new SqlConnection(strcon);
        string selectquery = "select des from EXPORT_PDF_LKUP with(nolock) where del_flg=0 and Exporter_Name='" + customer + "' and Invo_Type='" + InvType + "'";
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
        int Invval_col = 0;
        int _sPos = 0, col_pos = 0;
        string searchend = "";
        string splitword = "";
        bool searchend_bool = false;
        string inv_splt = "", same_invNo = "N", page_count = "1";
        int row_start = 35;


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

            if (key == "invNo" || key == "invDate" || key == "byerOdrNo" || key == "ohrRef" || key == "IEC")
            {
                try
                {
                    searchend = headermapingval["Search_end"].ToString();

                }
                catch (Exception)
                {
                    searchend = string.Empty;
                }
            }

            if (key == "ohrRef")
            {
                splitword = headermapingval["Split_word"].ToString();
            }
            else
            {
                splitword = "";
            }

            if (key == "inv_val" || key == "Tot_grosswt" || key == "Tot_netwt")
            {
                try
                {
                    row_start = Convert.ToInt32(headermapingval["row_start"].ToString());
                }
                catch (Exception)
                {
                    row_start = 35;
                }
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

                if (key == "AEOcode")
                {
                }

                if (key == "invNo" || key == "invDate" || key == "byerOdrNo" || key == "ohrRef" || key == "trmsOfPyt" || key == "cntyDec" || key == "prtOfDschrg" || key == "ctnno" || key == "Qtycode" || key == "Currency" || key == "Terms" || key == "inv_val" || key == "ConsigneeName" || key == "ConsigneeAdd1" || key == "ConsigneeAdd2" || key == "ConsigneeAdd3" || key == "ConsigneeAdd4" || key == "BuyerName" || key == "Schemecode" || key == "AEOcode" || key == "ADcode" || key == "IGST_Payment_Status" || key == "IGST_Rate" || key == "byerOdr_Dt" || key == "IEC" || (key == "Tot_Carton" && custname != "MOD ART") || (COMPANY_IDD != "1586" && COMPANY_IDD != "100" && (key == "Tot_grosswt" || key == "Tot_netwt")))
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

                            if (_column == celldetValue && _split == string.Empty)
                            {
                                cell2 = dt.Tables[0].Rows[row + _sPos][col + col_pos].ToString();
                                string celldetValue2 = cell2;
                                cellValue = celldetValue2;

                                col = col_cnt;
                                row = rw_cnt;


                            }
                            else if (celldetValue.Contains(_column.ToString()) && _split != string.Empty)
                            {
                                if (key == "trmsOfPyt" || key == "Qtycode" || key == "Currency" || key == "Terms" || key == "Schemecode" || key == "AEOcode" || key == "ADcode" || key == "IGST_Payment_Status" || key == "IGST_Rate" || key == "BuyerName" || key == "byerOdr_Dt" || key == "ConsigneeName")
                                {

                                    cell2 = dt.Tables[0].Rows[row + _sPos][col + col_pos].ToString();
                                    string[] _delimiter = _split.Split('-');
                                    string[] _valof = cell2.ToString().Split(_delimiter, StringSplitOptions.RemoveEmptyEntries);
                                    cellValue = _valof[int.Parse(_sVal)];

                                    if (key == "Qtycode")// Convert Valid QtyCode
                                    {
                                        cellValue = Get_Valid_Qty_Code(cellValue);
                                    }

                                    else if (key == "trmsOfPyt")
                                    {
                                        if (cellValue.Contains("TT"))
                                        {
                                            string[] _terms = cell2.ToString().Split(' ');
                                            cellValue = _terms[0] + " " + _terms[1];
                                        }
                                        else
                                        {
                                            cell3 = dt.Tables[0].Rows[row + _sPos + 1][col].ToString();

                                            if (cell3 != "")
                                            {
                                                string[] _terms = cell3.ToString().Split(' ');
                                                cellValue = _terms[2];
                                            }
                                            else
                                            {
                                                cell2 = dt.Tables[0].Rows[row + _sPos][col + col_pos + 1].ToString();
                                                cellValue = cell2;

                                            }
                                        }

                                    }

                                    else if (key == "Terms")
                                    {
                                        Invval_col = col;
                                    }
                                }
                                else if (key == "invNo" || key == "invDate" || key == "byerOdrNo" || key == "ohrRef" || key == "IEC")
                                {
                                    if (key == "ohrRef")
                                    {
                                        inv_splt = "";
                                    }

                                    //same_invNo = "Y";
                                    if (same_invNo == "Y")
                                    {
                                        if (InvType == "S")
                                        {
                                            searchend_bool = false;
                                            for (int k = 0; k <= 5; k++)
                                            {

                                                cell3 = dt.Tables[0].Rows[row + _sPos][col + col_pos].ToString();
                                                cellValue = cell3.Replace("Inv No.& Date", "");

                                                if (cellValue.Contains(searchend))
                                                {
                                                    searchend_bool = true;
                                                }

                                                if (searchend_bool != true)
                                                {
                                                    inv_splt += cellValue.Trim().Replace("\n", " ") + " ";
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                                _sPos = _sPos + 1;
                                            }
                                        }
                                        else// 'M-Multiple"
                                        {
                                            cell3 = dt.Tables[0].Rows[row + _sPos][col + col_pos].ToString();
                                            cellValue = cell3.Replace("Inv No.& Date", "");

                                            inv_splt += cellValue.Trim().Replace("\n", " ") + " ";
                                        }
                                    }
                                    else
                                    {
                                        inv_splt = "";
                                        inv_splt = dt.Tables[0].Rows[row + _sPos][col + col_pos].ToString();
                                    }

                                    cellValue = inv_splt;

                                }
                                else if (key == "inv_val" || key == "Tot_Carton" || key == "Tot_grosswt" || key == "Tot_netwt")
                                {
                                    try
                                    {
                                        string cellc = "";
                                        cellc = dt.Tables[0].Rows[row + _sPos][col + col_pos].ToString();
                                        cellValue = cellc;
                                    }
                                    catch (Exception) { }
                                }
                                else if (key == "ctnno")
                                {
                                    string ctnno1 = dt.Tables[0].Rows[row + _sPos][col + col_pos].ToString();
                                    cellValue = "1";
                                }
                                else
                                {
                                    string[] celldetValue2 = celldetValue.Split(':');
                                    cellValue = celldetValue2[1];
                                }

                                col = col_cnt;
                                row = rw_cnt;
                            }
                        }
                    }
                }
                else if (dt.Tables.Count > 1 && dt.Tables[1] != null && (key == "Tot_grosswt" || key == "Tot_netwt" || (key == "Tot_Carton" && custname == "MOD ART")))
                {
                    cellValue = string.Empty;
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
                                if (celldetValue.Contains(_column.ToString()))
                                {
                                    string cellc = "";
                                    cellc = dt.Tables[1].Rows[row_Tb2][col_Tb2 + col_pos].ToString();
                                    cellValue = cellc;

                                    col_Tb2 = col_cnt_Tb2;
                                    row_Tb2 = rw_cnt_Tb2;
                                }
                            }
                            catch (Exception) { }                            
                        }
                    }                   
                }

                //***  Direct Values  ***//
                string[] _columnvals = _column.Split('-');
                foreach (string _getcolumnval in _columnvals)
                {
                    if (_getcolumnval.ToString() != "")
                    {
                        if (key == "trmsOfPyt" || key == "cntyDec" || key == "prtOfDschrg" || key == "taxVal" || key == "igstper" || key == "Qtycode" || key == "Currency" || key == "Terms" || key == "inv_val" || key == "ConsigneeName" || key == "Schemecode" || (key == "invNo" && custname == "MOD ART"))
                        {
                            cellValue = cellValue.ToString();
                        }
                        else if (key == "client")
                        {
                            cellValue = _columnvals[0];
                        }
                        else if (key == "invNo" || key == "invDate" || key == "byerOdrNo" || key == "ohrRef" || key == "ConsigneeName" || key == "IEC" || key == "Tot_grosswt" || key == "Tot_netwt" || key == "Tot_Carton")
                        {

                            string code = cellValue.Substring(cellValue.IndexOf(splitword) + splitword.Length);

                            string[] _terms = cellValue.Split(' ');
                            if ((COMPANY_IDD == "816") && key == "invDate")
                            {
                                cellValue = _terms[int.Parse(_sVal)] + "/" + _terms[int.Parse(_sVal) + 1] + "/" + _terms[int.Parse(_sVal) + 2];
                            }
                            else
                            {
                                if (custname == "TYAGI HANDICRAFTS" && key == "invDate")
                                {
                                    try
                                    {
                                        cellValue = _terms[int.Parse(_sVal)];
                                    }
                                    catch (Exception ex)
                                    {
                                        cellValue = _terms[int.Parse(_sVal) - 1].Replace("Dtd:", "");
                                    }
                                }
                                else
                                {
                                    cellValue = _terms[int.Parse(_sVal)];
                                }
                            }
                        }
                        else if (key == "ctnno")
                        {
                            cellValue = "1";
                        }
                        else if (_split == string.Empty)
                        {
                        }
                        else
                        {
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

    public System.Data.DataTable readDetailPDFval(string custname, string dataTo, Dictionary<string, object> dictheader, DataSet dt, string InvType)
    {
        string additioancol = string.Empty;
        string additioansplit = string.Empty;
        string additioanval = string.Empty;
        string itemcol = string.Empty;
        string itemsplit = string.Empty;
        string itemval = string.Empty;
        string itemfilter = string.Empty;
        bool itemfilterbol = false;
        string[] additioansplit_multi = null;
        string[] itemfilter_multi = null;

        string infoqty_itemfilter = string.Empty;
        bool infoqty_itemfilterbol = false;

        string infoqty = string.Empty;
        string infoqtysplt = string.Empty;
        string infoqtyval = string.Empty;

        string infounit = string.Empty;
        string infounitsplt = string.Empty;
        string infounitval = string.Empty;
        string hangers = string.Empty;
        string SP_hanger_pos = string.Empty;
        string hanger_party = string.Empty;

        string[] str_rangeStart = null;
        string[] str_rangeEnd = null;
        int int_rangeStart = 0;
        int int_rangeEnd = 0;
        string int_hsdcount = string.Empty;
        int range_Amount = 0, range_rate = 0, range_qty = 0, cl_ety = 0, range_Infoqty = 0, range_infounit = 0, range_MarksNos = 0, range_NoOfPkgs = 0, range_HSNCode = 1, range_Desc = 0, range_qty_code = 0;


        string MarksNos = string.Empty;
        string NoOfPkgs = string.Empty;
        string HSNCode = string.Empty;
        string Quantity = string.Empty;
        string Rate = string.Empty;
        string Amount = string.Empty;
        string ItemDesc = string.Empty;
        string ItemQtyCode = string.Empty;

        System.Data.DataTable dttable = new System.Data.DataTable();
        ArrayList dictheaders = (ArrayList)dictheader[dataTo];
        Dictionary<string, object> KeyMaping = (Dictionary<string, object>)dictheaders[0];
        for (int keycount = 0; keycount < KeyMaping.Count; keycount++)
        {
            List<KeyValuePair<string, object>> list = new List<KeyValuePair<string, object>>(KeyMaping);
            string key = list[keycount].Key;
            if (key == "infoqty")
            { }
            ArrayList detailmaping = (ArrayList)KeyMaping[key];
            Dictionary<string, object> detailmapingval = (Dictionary<string, object>)detailmaping[0];
            if (key == "range")
            {
                str_rangeStart = detailmapingval["start"].ToString().Split('_');
                str_rangeEnd = detailmapingval["end"].ToString().Split(',');
            }
            else if (key == "addcolm")
            {
                additioancol = detailmapingval["columnm"].ToString();
                additioansplit = detailmapingval["split"].ToString();
                additioanval = detailmapingval["Value"].ToString();

                additioansplit_multi = detailmapingval["split"].ToString().Split(',');//ck
            }
            else if (key == "decOfGds")
            {
                itemcol = detailmapingval["column"].ToString();
                itemsplit = detailmapingval["split"].ToString();
                itemval = detailmapingval["Value"].ToString();
                try
                {
                    itemfilter = detailmapingval["filteritem"].ToString();
                    itemfilter_multi = detailmapingval["filteritem"].ToString().Split(',');//ck
                }
                catch (Exception)
                {
                    itemfilter = string.Empty;
                }

                try
                {
                    infoqty_itemfilter = detailmapingval["infoqtyfilteritem"].ToString();
                }
                catch (Exception)
                {
                    infoqty_itemfilter = string.Empty;
                }

                try
                {
                    hangers = detailmapingval["hanger_pos"].ToString();
                }
                catch (Exception)
                {
                    hangers = string.Empty;
                }

                try
                {
                    hanger_party = detailmapingval["hanger_party"].ToString();
                }
                catch (Exception)
                {
                    hanger_party = string.Empty;
                }
            }
            else if (key == "infoqty")
            {
                infoqty = detailmapingval["column"].ToString();
                infoqtysplt = detailmapingval["split"].ToString();
                infoqtyval = detailmapingval["Value"].ToString();
            }
            else if (key == "infounitprice")
            {
                infounit = detailmapingval["column"].ToString();
                infounitsplt = detailmapingval["split"].ToString();
                infounitval = detailmapingval["Value"].ToString();
            }

            else if (key == "MarksNos")
            {
                MarksNos = detailmapingval["column"].ToString();
            }
            else if (key == "NoOfPkgs")
            {
                NoOfPkgs = detailmapingval["column"].ToString();
            }
            else if (key == "HSNCode")
            {
                HSNCode = detailmapingval["column"].ToString();
            }
            else if (key == "Quantity")
            {
                Quantity = detailmapingval["column"].ToString();
            }
            else if (key == "Rate")
            {
                Rate = detailmapingval["column"].ToString();
            }
            else if (key == "Amount")
            {
                Amount = detailmapingval["column"].ToString();
            }
            else if (key == "ItemDesc")
            {
                ItemDesc = detailmapingval["column"].ToString();
            }
            else if (key == "ItemQtyCode")
            {
                ItemQtyCode = detailmapingval["column"].ToString();
            }
        }

        string cellValueqty = "", cellValuerate = "", cellValueitotal = "", cellValueitemdec1 = "", cellValueitemdec2 = "", cellValueinfoqty = "", cellValueinfounit = "",
               cellValueMarksNos = "", cellValueNoOfpkgs = "", cellValueHSNCode = "", Common_Item_Desc = "", Common_Item = "", cellValueqty_code = "";

        int rw_cnt = dt.Tables[0].Rows.Count;
        int col_count = dt.Tables[0].Columns.Count - 1;
        int hanger_pos = 0;
        int col_start = 0, col_reval = 0;

        string cell = "";
        string qty = "", rate = "", itotal = "", itemdec1 = "", itemdec2 = "", infoqty1 = "", infounitprice = "", hsn = "", qty_code = "";

        string[] Itm_col_splt = new string[2];

        if (ItemDesc == string.Empty)
        {
            Itm_col_splt = itemcol.Split(',');
        }


        try
        {
            for (int row = 18; row <= rw_cnt - 1; row++)
            {
                DataRow dataRow = dttable.NewRow();
                bool rowstatus = false;
                itemfilterbol = false;
                infoqty_itemfilterbol = false;

                cellValueqty = "";
                cellValuerate = "";
                cellValueitotal = "";
                cellValueitemdec1 = "";
                cellValueitemdec2 = "";
                cellValueinfoqty = "";
                cellValueinfounit = "";
                cellValueqty_code = "";

                int cc = 0;

                //#col loop
                for (int col = 0; col <= col_count; col++)//-3 for except Info_qty, Unit price
                {
                    cell = dt.Tables[0].Rows[row][col].ToString();
                    string celldetValue = cell;


                    foreach (var x in str_rangeEnd)
                    {
                        if (celldetValue.Contains(x))
                        {
                            int_rangeEnd = row;
                            col = col_count;
                        }
                    }

                    if (str_rangeStart.Contains(celldetValue.ToString()))
                    {
                        int_rangeStart = row;
                        col_start = col;
                    }
                    if (row == int_rangeStart)
                    {
                        cc = col;

                        if (col_start > 0)
                        {
                            if (col_reval == 0)
                            {
                                string cellemty = dt.Tables[0].Rows[row][col_start - col].ToString();
                                dttable.Columns.Add(cellemty);
                                col_reval = 1;
                            }
                        }

                        if (celldetValue.ToString() == String.Empty)
                        {
                            cl_ety = col;

                            string cellemty = dt.Tables[0].Rows[row][col].ToString();
                            celldetValue = cellemty;
                        }


                        if (cell.Contains(MarksNos))
                        {
                            range_MarksNos = col;
                        }
                        if (cell.Contains(NoOfPkgs))
                        {
                            range_NoOfPkgs = col;
                        }
                        if (cell.Contains(HSNCode) && HSNCode != "")
                        {
                            range_HSNCode = col;
                        }

                        if (cell.Contains(Amount))
                        {
                            range_Amount = col;
                        }
                        if (cell.Contains(Rate))
                        {
                            range_rate = col;
                        }
                        if (cell.Contains(Quantity))
                        {
                            range_qty = col;
                        }
                        if (cell.Contains(ItemDesc))
                        {
                            if (ItemDesc != "")
                            {
                                range_Desc = col;
                            }
                        }
                        if (cell.Contains(ItemQtyCode))
                        {
                            range_qty_code = col;
                        }


                        dttable.Columns.Add(celldetValue);
                        if (dttable.Columns.Count == 2)
                        {
                            if (dttable.Columns[1].ToString() != string.Empty)
                            {
                                if (custname == "TYAGI HANDICRAFTS")
                                {
                                    dttable.Columns["HSN CODE"].ColumnName = "HSNCode";
                                }
                                else
                                {
                                    dttable.Columns["Column1"].ColumnName = "HSNCode";
                                }
                            }
                        }
                        else if (dttable.Columns.Count == 8 && COMPANY_IDD == "3335")
                        {
                            if (dttable.Columns[7].ToString() != string.Empty)
                            {
                                dttable.Columns["Column4"].ColumnName = "Qtycode";
                                range_qty_code = range_qty_code + 1;
                            }
                        }

                        if (col_count == cc)
                        {
                            col_count = col_count + 1;
                            dttable.Columns.Add("Info_Qty");
                            range_Infoqty = dt.Tables[0].Columns.Count + 1;

                            col_count = col_count + 2;
                            dttable.Columns.Add("Info_Unitprice");
                            range_infounit = dt.Tables[0].Columns.Count + 2;

                            if (InvType == "S")
                            {
                                col_count = col_count - 3;
                            }
                            else
                            {
                                col_count = col_count - 3;
                                col = col_count + 1;
                            }
                        }
                    }
                    else
                    {
                        if (row != int_rangeStart && int_rangeStart != 0)
                        {
                            if (str_rangeEnd.Contains(celldetValue.ToString()))
                            {
                                int_rangeEnd = row;
                                col = col_count;
                            }

                            foreach (var x in str_rangeEnd)
                            {
                                if (celldetValue.Contains(x))
                                {
                                    int_rangeEnd = row;
                                    col = col_count;
                                }
                            }

                            //#start
                            if (col == col_start)// its range based data - no need to loop every columns
                            {

                                qty = ""; rate = ""; itotal = ""; itemdec1 = ""; itemdec2 = ""; infoqty1 = ""; infounitprice = ""; hsn = ""; NoOfPkgs = ""; qty_code = "";

                                hsn = dt.Tables[0].Rows[row][range_HSNCode].ToString();

                                bool chk_HSN_Numeric = false;
                                Regex rg = new Regex("[^0-9]");
                                chk_HSN_Numeric = rg.IsMatch(hsn) == true ? false : true;

                                bool chk_Desc_Numeric = false;
                                itemdec1 = dt.Tables[0].Rows[row][Convert.ToInt32(Itm_col_splt[0])].ToString();
                                chk_Desc_Numeric = rg.IsMatch(itemdec1) == true ? false : true;

                                if (chk_HSN_Numeric == true && chk_Desc_Numeric == false && col_count == range_Amount && dt.Tables[0].Rows[row][range_qty].ToString() == "")
                                {

                                    qty = dt.Tables[0].Rows[row][range_qty - 1].ToString();//check previous cells
                                    cellValueqty = qty;

                                    rate = dt.Tables[0].Rows[row][range_rate].ToString();
                                    cellValuerate = rate;


                                    itotal = dt.Tables[0].Rows[row][range_Amount].ToString();
                                    cellValueitotal = itotal;


                                    itemdec1 = dt.Tables[0].Rows[row][Convert.ToInt32(Itm_col_splt[0])].ToString();
                                    cellValueitemdec1 = itemdec1;

                                }
                                else
                                {
                                    qty = dt.Tables[0].Rows[row][range_qty].ToString();
                                    cellValueqty = qty;

                                    rate = dt.Tables[0].Rows[row][range_rate].ToString();

                                    if (!string.IsNullOrWhiteSpace(rate))
                                    {
                                        decimal numericRate;
                                        if (decimal.TryParse(rate, out numericRate))
                                        {
                                            cellValuerate = Math.Round(numericRate, 5).ToString("N5").Replace(",", "");
                                        }
                                    }

                                    itotal = dt.Tables[0].Rows[row][range_Amount].ToString();
                                    cellValueitotal = itotal;

                                    if (COMPANY_IDD == "1586")
                                    {
                                        cellValuerate = rate;
                                        if (custname == "TYAGI HANDICRAFTS")
                                        {
                                            cellValueitemdec1 = dt.Tables[0].Rows[row][range_Desc].ToString();
                                            hsn = dt.Tables[0].Rows[row][range_HSNCode].ToString();
                                        }
                                        else
                                        {
                                            if (custname == "MOD ART")
                                            {
                                                itemdec1 = dt.Tables[0].Rows[row][range_Desc].ToString().Trim();
                                                if (itemdec1 == "DESCRIPTION")
                                                {
                                                    Common_Item = dt.Tables[0].Rows[row - 2][range_Desc - 1].ToString();
                                                }
                                                Itm_col_splt[0] = (range_Desc - 1).ToString();
                                            }
                                            else
                                            {
                                                itemdec1 = dt.Tables[0].Rows[row][range_Desc - 4].ToString();
                                                Common_Item = dt.Tables[0].Rows[row][range_Desc - 1].ToString();
                                            }

                                            if (Common_Item != "")
                                            {
                                                Common_Item_Desc = Common_Item;
                                            }
                                            if (itemdec1 != "")
                                            {
                                                cellValueitemdec1 = Common_Item_Desc + " " + itemdec1;
                                            }
                                            hsn = dt.Tables[0].Rows[row][range_HSNCode + 7].ToString();
                                        }
                                    }
                                    else if (COMPANY_IDD == "3335")
                                    {
                                        cellValueitemdec1 = dt.Tables[0].Rows[row][range_Desc - 1].ToString();
                                        hsn = dt.Tables[0].Rows[row][range_HSNCode + 1].ToString();                                       
                                    }
                                    else
                                    {
                                        cellValueitemdec1 = dt.Tables[0].Rows[row][range_Desc].ToString();
                                        hsn = dt.Tables[0].Rows[row][range_HSNCode + 1].ToString();
                                    }
                                    cellValueHSNCode = hsn;

                                    qty_code = dt.Tables[0].Rows[row][range_qty_code].ToString();
                                    cellValueqty_code = qty_code;
                                }

                                if (itemdec1 == "ORDER NO:")
                                {
                                    string chk_near_ItemDesc = dt.Tables[0].Rows[row][Convert.ToInt32(Itm_col_splt[0]) + 1].ToString();

                                    if (chk_near_ItemDesc != "STYLE NO:")
                                    {
                                        Itm_col_splt[1] = Convert.ToString(Convert.ToInt32(Itm_col_splt[0]) + 1);
                                    }
                                }

                                if (Itm_col_splt[1] != null)
                                {
                                    itemdec2 = dt.Tables[0].Rows[row][Convert.ToInt32(Itm_col_splt[1])].ToString();
                                    cellValueitemdec2 = itemdec2;

                                }
                                if (COMPANY_IDD != "3335")
                                {
                                    infoqty1 = dt.Tables[0].Rows[row + 1][range_qty].ToString();
                                    cellValueinfoqty = infoqty1.Replace("(", "").Replace(")", "").Replace("NOS", "").Replace("KGS", "").Replace(" ", "").Trim();

                                    infounitprice = dt.Tables[0].Rows[row + 1][range_rate].ToString();
                                    cellValueinfounit = Convert_Digit(infounitprice.Replace("-", "").Replace("(", "").Replace(")", "").Trim(), 5);
                                }

                                if ((cellValueitemdec1.Contains(infoqty_itemfilter) || cellValueitemdec2.Contains(infoqty_itemfilter)) && (cellValueitemdec1 != string.Empty || cellValueitemdec2 != string.Empty) && infoqty_itemfilter != string.Empty)
                                {
                                    infoqty_itemfilterbol = true;
                                }

                                if (infoqty_itemfilterbol == true)
                                {
                                    rowstatus = true;

                                    if (cellValueitemdec1 != string.Empty)
                                    {
                                        string[] spt_infoqty = cellValueitemdec1.Split('\n');
                                        cellValueinfoqty = spt_infoqty[0].Replace("NET WT :", "").Replace("(", "").Replace(")", "").Replace("NOS", "").Replace("KGS", "").Replace(" ", "");

                                        if (spt_infoqty.Count() > 1)
                                        {
                                            cellValueitemdec1 = spt_infoqty[1];
                                        }
                                    }

                                    if (cellValueitemdec2 != string.Empty)
                                    {
                                        string[] spt_infoqty = cellValueitemdec2.Split('\n');
                                        cellValueinfoqty = spt_infoqty[0].Replace("NET WT :", "").Replace("(", "").Replace(")", "").Replace("NOS", "").Replace("KGS", "").Replace(" ", "");

                                        if (spt_infoqty.Count() > 1)
                                        {
                                            cellValueitemdec2 = spt_infoqty[1];
                                        }
                                    }
                                }

                                //check Item desc has a Ending words..
                                foreach (var x in str_rangeEnd)
                                {
                                    if (cellValueitemdec1.Contains(x))
                                    {
                                        int_rangeEnd = row;
                                        col = col_count;
                                    }
                                }

                                foreach (var x in additioansplit_multi)
                                {
                                    if (cellValueitemdec1.Contains(x))
                                    {
                                        if (x != "")
                                        {
                                            col = col_count;
                                        }
                                    }
                                }
                                if (row == int_rangeEnd)
                                {
                                    row = rw_cnt;
                                }
                            }

                            if (itemfilterbol == true)
                            {
                                itemdec1 = dt.Tables[0].Rows[row][hanger_pos].ToString();
                                cellValueitemdec1 = itemdec1;
                            }

                            dataRow[range_qty] = cellValueqty;
                            dataRow[range_rate] = cellValuerate;
                            dataRow[range_Amount] = cellValueitotal;
                            dataRow[range_HSNCode] = cellValueHSNCode;
                            dataRow[range_qty_code] = cellValueqty_code;


                            if ((cellValueitemdec1 != string.Empty || cellValueitemdec2 != string.Empty) && (cellValueitotal != string.Empty))
                            {

                                rowstatus = true;
                                string seconditemval = string.Empty;
                                bool nextline = false;
                                int n_infoqty_row = 0;
                                bool chk_infoqty_itemfilter = false;

                                if (celldetValue != "" && (celldetValue == cellValueitemdec1 || celldetValue == cellValueitemdec2))
                                {

                                    if (InvType == "S")
                                    {
                                        for (int hsdint = 1; hsdint < 5; hsdint++)
                                        {
                                            string cellhsd = dt.Tables[0].Rows[row + hsdint][col].ToString();
                                            string cellHSDValue = string.Empty;

                                            try
                                            {
                                                cellHSDValue = cellhsd;
                                            }
                                            catch (Exception) { cellHSDValue = string.Empty; }

                                            string cellhsd1 = "";
                                            foreach (var x in additioansplit_multi)
                                            {
                                                if (cellhsd.Contains(x))
                                                {
                                                    if (x != "")
                                                    {
                                                        n_infoqty_row = hsdint;
                                                        chk_infoqty_itemfilter = true;
                                                        nextline = false;
                                                        hsdint = 5;
                                                        break;
                                                    }
                                                }
                                                else
                                                {
                                                    nextline = true;
                                                }


                                                //check previous cols also..
                                                cellhsd1 = dt.Tables[0].Rows[row + hsdint][col - 1].ToString();

                                                if (cellhsd1.Contains(x))
                                                {
                                                    if (x != "")
                                                    {
                                                        string cellhsd2 = dt.Tables[0].Rows[row + hsdint][col].ToString();
                                                        hsdint = 5;
                                                        break;
                                                    }
                                                }
                                            }

                                            if (nextline == true)// add Next lines here/..
                                            {

                                                if (Itm_col_splt[1] != null)
                                                {
                                                    cellhsd = cellValueitemdec2 + " " + cellhsd;
                                                }
                                                seconditemval += " " + cellhsd;
                                            }

                                        }//end for loop hsdint
                                    }
                                    else
                                    {
                                        for (int hsdint = 1; hsdint < 5; hsdint++)
                                        {

                                            string cellhsd = dt.Tables[0].Rows[row + hsdint][col].ToString();
                                            string cellHSDValue = string.Empty;

                                            try
                                            {
                                                cellHSDValue = cellhsd;
                                            }
                                            catch (Exception) { cellHSDValue = string.Empty; }




                                            string cellhsd1 = "";
                                            foreach (var x in additioansplit_multi)
                                            {
                                                if (cellhsd.Contains(x))
                                                {
                                                    if (x != "")
                                                    {
                                                        nextline = false;
                                                        hsdint = 5;
                                                        break;
                                                    }
                                                }
                                                else
                                                {
                                                    nextline = true;
                                                }
                                            }

                                            if (nextline == true)// add Next lines here/..
                                            {
                                                string Nxt_itm_Amt = dt.Tables[0].Rows[row + hsdint][range_Amount].ToString();
                                                if (Nxt_itm_Amt == "")
                                                {
                                                    seconditemval += " " + cellhsd;
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }

                                        }
                                    }
                                }

                                if (chk_infoqty_itemfilter == true)
                                {
                                    for (int hsdint = 1; hsdint < 4; hsdint++)
                                    {
                                        infoqty_itemfilterbol = false;
                                        string cellhsd = dt.Tables[0].Rows[row + hsdint][col].ToString();
                                        if ((cellhsd.Contains(infoqty_itemfilter) && cellhsd != string.Empty && infoqty_itemfilter != string.Empty))
                                        {
                                            infoqty_itemfilterbol = true;
                                        }

                                        if (infoqty_itemfilterbol == true)
                                        {
                                            rowstatus = true;

                                            if (cellhsd != string.Empty)
                                            {
                                                string splitword = "NET WT :";
                                                string[] spt_infoqty = cellValueitemdec1.Split('\n');
                                                cellValueinfoqty = spt_infoqty[0].Substring(spt_infoqty[0].IndexOf("NET WT :") + splitword.Length).Replace("NET WT :", "").Replace("(", "").Replace(")", "").Replace("NOS", "").Replace("KGS", "").Replace(" ", "");

                                                if (spt_infoqty.Count() > 1)
                                                {
                                                    cellValueitemdec1 = spt_infoqty[1];
                                                }
                                            }
                                        }
                                    }
                                }

                                if (infoqty_itemfilterbol == true && col == Convert.ToInt32(Itm_col_splt[0]) && cellValueitemdec1 != "")
                                {
                                    dataRow[Convert.ToInt32(Itm_col_splt[0])] = cellValueitemdec1.Replace("&#xA;", "") + seconditemval.Replace("&#xA;", "");
                                }
                                else if (infoqty_itemfilterbol == true && col == Convert.ToInt32(Itm_col_splt[1]) && cellValueitemdec2 != "")
                                {
                                    dataRow[Convert.ToInt32(Itm_col_splt[1])] = cellValueitemdec1.Replace("&#xA;", "") + seconditemval.Replace("&#xA;", "");
                                }
                                else
                                {
                                    if (col == range_NoOfPkgs && Convert.ToString(range_NoOfPkgs) != "")
                                    {
                                        dataRow[(range_NoOfPkgs)] = cellValueNoOfpkgs;//05-07-23 - for Mismatched entries
                                    }
                                    if (Convert.ToString(range_HSNCode) != "")
                                    {
                                        dataRow[(range_HSNCode)] = cellValueHSNCode;//05-07-23 - for Mismatched entries
                                    }
                                    if (col == Convert.ToInt32(Itm_col_splt[0]))
                                    {
                                        dataRow[(range_Desc)] = cellValueitemdec1;//05-07-23 - for Mismatched entries
                                    }
                                    else if (col == range_qty)
                                    {
                                        dataRow[(range_qty)] = cellValueqty;//05-07-23 - for Mismatched entries
                                    }
                                    else if (col == range_rate)
                                    {
                                        dataRow[(range_rate)] = cellValuerate;//05-07-23 - for Mismatched entries
                                    }
                                    else if (col == range_Amount)
                                    {
                                        dataRow[(range_Amount)] = cellValueitotal;//05-07-23 - for Mismatched entries
                                        col = col_count + 2;
                                    }
                                    else if (col == range_qty_code)
                                    {
                                        dataRow[(range_qty_code)] = cellValueqty_code;//05-07-23 - for Mismatched entries
                                    }
                                    else
                                    {
                                        dataRow[(col + 1) - 1] = celldetValue.Replace("\n", "") + seconditemval.Replace("\n", "");
                                    }
                                }


                                dataRow[range_Infoqty - 1] = cellValueinfoqty;
                                dataRow[range_infounit - 1] = cellValueinfounit;
                            }
                        }
                        else
                        {
                        }

                        if (row == int_rangeEnd)
                        {
                            row = rw_cnt;
                        }
                    }

                    if (row > int_rangeStart && int_rangeEnd == 0 && rowstatus == true)
                    {
                        if (dataRow.ItemArray[range_qty].ToString() != "" && dataRow.ItemArray[range_Amount].ToString() != "")
                        {
                            dttable.Rows.Add(dataRow);
                            break;
                        }
                    }
                }
            }
        }
        catch (Exception)
        {
        }


        //Packing List Details
        if (COMPANY_IDD == "1586" || COMPANY_IDD == "816")
        {
            try
            {
                int Set_Row = 0; int row_PKL = 0; int row_Strat = 0;
                string str_Start = ""; string str_End = "";
                if (COMPANY_IDD == "1586")
                {
                    if (custname == "MOD ART")
                    {
                        Set_Row = 1; row_Strat = 15;
                        str_Start = "  Net Wt."; str_End = "Signature & Date";
                    }
                    else
                    {
                        Set_Row = 1; row_Strat = 20;
                        str_Start = "REMARKS"; str_End = "TOTAL PCS:";
                    }
                }
                else
                {
                    str_Start = "Net Wt."; str_End = str_rangeEnd[0]; row_Strat = 80;
                }

                DataTable PKLdttable = new DataTable();
                PKLdttable.Columns.Add("NETWT");
                int rw_cnt_TB2 = dt.Tables[Set_Row].Rows.Count;
                int col_count_TB2 = dt.Tables[Set_Row].Columns.Count - 1;
                string NetWt_Value = ""; int_rangeStart = 0; int_rangeEnd = 0;
                bool Start_Col = false; bool Packing_List = false;


                for (row_PKL = row_Strat; row_PKL <= rw_cnt_TB2 - 1; row_PKL++)
                {
                    for (int Col_PKL = 0; Col_PKL <= col_count_TB2; Col_PKL++)
                    {
                        if (Col_PKL == 20)
                        {
                            Col_PKL = col_count_TB2 - 1;
                        }

                        cell = dt.Tables[Set_Row].Rows[row_PKL][Col_PKL].ToString();
                        string celldetValue = cell;
                        try
                        {
                            celldetValue = cell;
                        }
                        catch (Exception) { celldetValue = string.Empty; }

                        if (COMPANY_IDD == "816")
                        {
                            if (cell.Contains("PAKING LIST"))
                            {
                                Packing_List = true;
                            }
                        }
                        else
                        {
                            Packing_List = true;
                        }

                        if (celldetValue == str_Start)
                        {
                            int_rangeStart = row_PKL;
                            col_start = Col_PKL;
                            Start_Col = true;
                        }
                        if (celldetValue.Contains(str_End))
                        {
                            if (Packing_List == true)
                            {
                                int_rangeEnd = row_PKL;
                                col_start = Col_PKL;
                            }
                        }

                        if (int_rangeStart <= row_PKL && Col_PKL == col_start && Start_Col == true)
                        {
                            string cellc = "";
                            cellc = dt.Tables[Set_Row].Rows[row_PKL][Col_PKL].ToString().Replace(",","");
                            NetWt_Value = cellc;

                            //if (COMPANY_IDD == "1586")
                            //{
                                Regex regex = new Regex(@"\b\d+(\.\d+)?\b");
                                foreach (Match match in regex.Matches(NetWt_Value))
                                {
                                    if (PKLdttable.Rows.Count != dttable.Rows.Count)
                                    {
                                        PKLdttable.Rows.Add(NetWt_Value);
                                    }
                                }
                            //}
                            //else
                            //{
                            //    string Get_Original_Values = dt.Tables[Set_Row].Rows[row_PKL][Col_PKL - 1].ToString();
                            //    if (Get_Original_Values != "")
                            //    {
                            //        PKLdttable.Rows.Add(NetWt_Value);
                            //    }
                            //}
                            Col_PKL = col_count_TB2;
                        }
                        if (row_PKL == int_rangeEnd)
                        {                           
                            Col_PKL = col_count_TB2;
                            row_PKL = rw_cnt_TB2;
                        }                       
                    }
                }
                //if (COMPANY_IDD == "816" || COMPANY_IDD == "10")
                //{
                //    Regex numberPattern = new Regex(@"^\d{1,3}(,\d{3})*(\.\d+)?$"); // matches values like 20,400.00

                //    for (int i = PKLdttable.Rows.Count - 1; i >= 0; i--)
                //    {
                //        string rowValue = PKLdttable.Rows[i][0].ToString().Trim();

                //        // Remove rows that do not match the numeric pattern
                //        if (!numberPattern.IsMatch(rowValue))
                //        {
                //            PKLdttable.Rows.RemoveAt(i);
                //        }
                //    }
                //}
                if (PKLdttable.Rows.Count == dttable.Rows.Count)
                {
                    for (int CbNt = 0; CbNt <= PKLdttable.Rows.Count - 1; CbNt++)
                    {
                        dttable.Rows[CbNt]["Info_Qty"] = PKLdttable.Rows[CbNt]["NETWT"].ToString();
                    }
                }
            }
            catch (Exception)
            {
            }           
        }

        dttable.AcceptChanges();
        return dttable;
        //#detailend
    }

    public System.Data.DataTable readAR4DetailPDFval(string custname, string dataTo, Dictionary<string, object> dictheader, DataSet dt, string InvType)
    {
        string[] str_rangeStart = null;
        string[] str_rangeEnd = null;
        int int_rangeStart = 0;
        int int_rangeEnd = 0;
        int range_AR4_NO = 0, range_AR4_DATE = 0, range_AR4_COMMISSION_RATE = 0, range_AR4_DIVISION = 0;

        string AR4_NO = string.Empty;
        string AR4_DATE = string.Empty;
        string AR4_COMMISSION_RATE = string.Empty;
        string AR4_DIVISION = string.Empty;

        System.Data.DataTable dttable = new System.Data.DataTable();
        ArrayList dictheaders = (ArrayList)dictheader[dataTo];
        Dictionary<string, object> KeyMaping = (Dictionary<string, object>)dictheaders[0];
        for (int keycount = 0; keycount < KeyMaping.Count; keycount++)
        {
            List<KeyValuePair<string, object>> list = new List<KeyValuePair<string, object>>(KeyMaping);
            string key = list[keycount].Key;

            ArrayList detailmaping = (ArrayList)KeyMaping[key];
            Dictionary<string, object> detailmapingval = (Dictionary<string, object>)detailmaping[0];
            if (key == "range")
            {
                str_rangeStart = detailmapingval["start"].ToString().Split('_');
                str_rangeEnd = detailmapingval["end"].ToString().Split(',');
            }

            else if (key == "AR4_NO")
            {
                AR4_NO = detailmapingval["column"].ToString();
            }
            else if (key == "AR4_DATE")
            {
                AR4_DATE = detailmapingval["column"].ToString();
            }
            else if (key == "AR4_COMMISSION_RATE")
            {
                AR4_COMMISSION_RATE = detailmapingval["column"].ToString();
            }
            else if (key == "AR4_DIVISION")
            {
                AR4_DIVISION = detailmapingval["column"].ToString();
            }
        }

        dttable.Columns.Add("AR4_NO");
        dttable.Columns.Add("AR4_DATE");
        dttable.Columns.Add("AR4_COMMISSION_RATE");
        dttable.Columns.Add("AR4_DIVISION");

        string cellValue_AR4_NO = "", cellValue_AR4_DATE = "", cellValue_AR4_COMMISSION_RATE = "", cellValue_AR4_DIVISION = "", Validation = "";

        int rw_cnt = dt.Tables[0].Rows.Count;
        int col_count = dt.Tables[0].Columns.Count - 1;
        int col_start = 0;

        string cell = "";

        string[] Itm_col_splt = new string[2];


        try
        {
            for (int row = 20; row <= rw_cnt - 1; row++)
            {
                DataRow dataRow = dttable.NewRow();
                bool rowstatus = false;

                cellValue_AR4_NO = "";
                cellValue_AR4_DATE = "";
                cellValue_AR4_COMMISSION_RATE = "";
                cellValue_AR4_DIVISION = "";

                int cc = 0;

                //#col loop
                for (int col = 0; col <= col_count; col++)//-3 for except Info_qty, Unit price
                {
                    cell = dt.Tables[0].Rows[row][col].ToString();
                    string celldetValue = cell;


                    foreach (var x in str_rangeEnd)
                    {
                        if (celldetValue.Contains(x))
                        {
                            int_rangeEnd = row;
                            col = col_count;
                        }
                    }

                    if (str_rangeStart.Contains(celldetValue.ToString()))
                    {
                        int_rangeStart = row;
                        col_start = col;
                    }
                    if (row == int_rangeStart)
                    {
                        cc = col;

                        if (cell.Contains(AR4_NO))
                        {
                            range_AR4_NO = col;
                        }
                        if (cell.Contains(AR4_DATE))
                        {
                            range_AR4_DATE = col;
                        }
                        if (cell.Contains(AR4_COMMISSION_RATE))
                        {
                            range_AR4_COMMISSION_RATE = col;
                        }
                        if (cell.Contains(AR4_DIVISION))
                        {
                            range_AR4_DIVISION = col;
                        }                 
                    }
                    else
                    {
                        if (row != int_rangeStart && int_rangeStart != 0)
                        {
                            if (str_rangeEnd.Contains(celldetValue.ToString()))
                            {
                                int_rangeEnd = row;
                                col = col_count;
                            }

                            foreach (var x in str_rangeEnd)
                            {
                                if (celldetValue.Contains(x))
                                {
                                    int_rangeEnd = row;
                                    col = col_count;
                                }
                            }

                            //#start
                            if (col == col_start)// its range based data - no need to loop every columns
                            {
                                string AR4_NO_V = "", AR4_DATE_V = "", AR4_COMMISSION_RATE_V = "", AR4_DIVISION_V = "";

                                AR4_NO_V = dt.Tables[0].Rows[row + 3][range_AR4_NO].ToString();
                                if (AR4_NO_V.Contains("INV NO"))
                                {
                                    string[] Get_AR4_NO_V = AR4_NO_V.ToString().Split(new string[] { "/ Date" }, StringSplitOptions.None);
                                    AR4_NO_V = Get_AR4_NO_V[0];
                                }
                                cellValue_AR4_NO = AR4_NO_V;

                                AR4_DATE_V = dt.Tables[0].Rows[row + 3][range_AR4_DATE].ToString();
                                if (AR4_DATE_V.Contains("Date"))
                                {
                                    string[] Get_AR4_DATE_V = AR4_DATE_V.ToString().Split(':');
                                    AR4_DATE_V = Get_AR4_DATE_V[2];
                                }
                                cellValue_AR4_DATE = AR4_DATE_V.Replace("-","");

                                AR4_COMMISSION_RATE_V = dt.Tables[0].Rows[row + 2][range_AR4_COMMISSION_RATE].ToString();
                                cellValue_AR4_COMMISSION_RATE = AR4_COMMISSION_RATE_V;

                                AR4_DIVISION_V = dt.Tables[0].Rows[row + 1][range_AR4_DIVISION].ToString();
                                if (AR4_DIVISION_V.Contains("SUPPLIER"))
                                {
                                    cellValue_AR4_DIVISION = AR4_DIVISION_V;
                                }

                                dataRow[range_AR4_NO] = cellValue_AR4_NO;
                                dataRow[range_AR4_DATE] = cellValue_AR4_DATE;
                                dataRow[range_AR4_COMMISSION_RATE] = AR4_COMMISSION_RATE_V;
                                dataRow[range_AR4_DIVISION] = cellValue_AR4_DIVISION;

                                Validation = "";
                                Validation = dt.Tables[0].Rows[row][range_AR4_DIVISION + 2].ToString();

                                if ((cellValue_AR4_DIVISION != string.Empty))
                                {
                                    rowstatus = true;
                                    if (col == range_AR4_NO)
                                    {
                                        dataRow[(0)] = cellValue_AR4_NO;
                                    }
                                    if (col == range_AR4_DATE)
                                    {
                                        dataRow[(1)] = cellValue_AR4_DATE;
                                    }
                                    if (col == range_AR4_COMMISSION_RATE)
                                    {
                                        dataRow[(2)] = AR4_COMMISSION_RATE_V;
                                        col = col_count ;
                                    }
                                    if (col == range_AR4_DIVISION)
                                    {
                                        dataRow[(3)] = cellValue_AR4_DIVISION;
                                        col = col_count;
                                    }
                                }

                                if (row == int_rangeEnd)
                                {
                                    row = rw_cnt;
                                }
                            }

                            if (row > int_rangeStart && int_rangeEnd == 0 && rowstatus == true)
                            {
                                if (Validation != "")
                                {
                                    dttable.Rows.Add(dataRow);
                                    break;                                    
                                }
                            }
                        }
                    }
                }
            }
        }
        catch (Exception)
        {
        }

        dttable.AcceptChanges();
        return dttable;
        //#AR_4_detailend
    }

    public bool BindgridViewData()
    {
        if (ViewState["dt_Item"] != null)
        {
            dt_gvew = (DataTable)ViewState["dt_Item"];
            if (dt_gvew.Rows.Count > 0)
            {
                foreach (GridViewRow row in gv_ItemPDF.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        TextBox txtItemDesc = (TextBox)row.FindControl("txtItemDesc");
                        DropDownList ddl_SchemeCode = (DropDownList)row.FindControl("ddl_SchemeCode");
                        DropDownList ddl_STRYN = (DropDownList)row.FindControl("ddl_STRYN");
                        DropDownList ddl_Reward_Points = (DropDownList)row.FindControl("ddl_Reward_Points");
                        DropDownList ddl_RodtepYN = (DropDownList)row.FindControl("ddl_RodtepYN");
                        DropDownList ddl_CessYN = (DropDownList)row.FindControl("ddl_CessYN");
                        TextBox txtEndUseOfItems = (TextBox)row.FindControl("txtEndUseOfItems");
                        TextBox txtUnderPTA = (TextBox)row.FindControl("txtUnderPTA");
                        DropDownList ddl_IGSTPayment = (DropDownList)row.FindControl("ddl_IGSTPayment");
                        TextBox txtDrawback_SLNo = (TextBox)row.FindControl("txtDrawback_SLNo");
                        TextBox txtDBK_Unit = (TextBox)row.FindControl("txtDBK_Unit");

                        if (txtItemDesc.Text.Trim() != "" && ddl_SchemeCode != null && ddl_STRYN != null &&
                        ddl_Reward_Points != null && ddl_RodtepYN != null && ddl_CessYN != null && txtEndUseOfItems.Text.Trim() != "" &&
                        txtUnderPTA.Text.Trim() != "" && ddl_IGSTPayment != null)
                        {
                            string itemDesc = txtItemDesc.Text;
                            string schemeCode = ddl_SchemeCode.SelectedValue;
                            string strYN = ddl_STRYN.SelectedValue;
                            string rewardPoints = ddl_Reward_Points.SelectedValue;
                            string rodtepYN = ddl_RodtepYN.SelectedValue;
                            string cessYN = ddl_CessYN.SelectedValue;
                            string endUseOfItems = "";
                            if (txtEndUseOfItems.Text.Trim() != "")
                            {
                                endUseOfItems = txtEndUseOfItems.Text.Split('-')[0];
                            }
                            string underPTA = txtUnderPTA.Text;
                            string igstPayment = ddl_IGSTPayment.SelectedValue;
                            string drawbackSlNo = txtDrawback_SLNo.Text;
                            string dbkUnit = txtDBK_Unit.Text;

                            if (row.RowIndex < dt_gvew.Rows.Count)
                            {
                                dt_gvew.Rows[row.RowIndex]["ITEM_DESC"] = itemDesc;
                                dt_gvew.Rows[row.RowIndex]["SCHEME_CODE"] = schemeCode;
                                dt_gvew.Rows[row.RowIndex]["STR_YES_NO"] = strYN;
                                dt_gvew.Rows[row.RowIndex]["REWARD_YES_NO"] = rewardPoints;
                                dt_gvew.Rows[row.RowIndex]["RODTEP"] = rodtepYN;
                                dt_gvew.Rows[row.RowIndex]["CESS_YN"] = cessYN;
                                dt_gvew.Rows[row.RowIndex]["END_USE_OF_ITEM"] = endUseOfItems;
                                dt_gvew.Rows[row.RowIndex]["UNDER_PTA_FTA"] = underPTA;
                                dt_gvew.Rows[row.RowIndex]["IGST_PAYMENT"] = igstPayment;
                                dt_gvew.Rows[row.RowIndex]["DBK_SL_NO"] = drawbackSlNo;
                                dt_gvew.Rows[row.RowIndex]["DBK_UNIT"] = dbkUnit;
                            }
                        }
                        else
                        {
                            Alert_msg("Please Enter All Mandatory Fields..!", txtEndUseOfItems.Text);
                            IsValid = false;
                            break;
                        }
                    }
                }
                ViewState["dt_Item"] = dt_gvew;
            }
            else
            {
                dt_gvew = new DataTable();
                ViewState["dt_Item"] = dt_gvew;
            }
        }
        else
        {
            dt_gvew = new DataTable();
            ViewState["dt_Item"] = dt_gvew;
        }

        return IsValid;
    }

    protected void btnupload_Click(object sender, EventArgs e)
    {
        try
        {
            Tbl_Columns();
            DataSet dss_Insert = new DataSet();
            dss_Insert = (DataSet)ViewState["ds_xl_Output"];
            DataTable dt_INVOICE = new DataTable();
            DataTable dt_ITEM = new DataTable();
            DataTable dt_AR_4_Details = new DataTable();
            IsValid = BindgridViewData();
            if (IsValid == true)
            {
                dt_INVOICE = (DataTable)ViewState["dt_Invoice"];
                dt_ITEM = (DataTable)ViewState["dt_Item"];

                string AUTHORIZED_ECONOMIC_OPERATOR_CODE = "", A_E_O_COUNTRY = "", AUTHORIZED_ECONOMIC_OPERATOR = "", ADCODE = "", IGST_PAYMENT = "", IGST_RATE = "", marksnos = "", CONTRCT_NO = "", TYPE_OF_EXPORTER = "", invdt = "";
                string PAYMENT_METHOD = "NA", PERIOD_PAYMENT = "", InvValue = "", FREIGHT_CHGS = "", curr = "", TERMS = "", InvNo = "";
                string STATE_OF_ORIGIN = "";
                string DISTRICT_OF_ORIGIN = "", FOB_CHARGES = "", COMMISSION_CHARGES = "", FREIGHT_CHARGES = "", INSURANCE_CHARGES = "";

                //if (ViewState["exp_name"].ToString() != "Silver Crest Clothing Pvt Ltd")
                //{
                //    string[] contract = dss_Insert.Tables[0].Rows[0]["byerOdrNo"].ToString().TrimStart().Split(' ', '\t');
                //    CONTRCT_NO = contract[0];
                //}

                if (COMPANY_IDD == "1586")
                {
                    PERIOD_PAYMENT = "";
                    PAYMENT_METHOD = "DP";
                }
                else if (COMPANY_IDD == "816")
                {
                    PERIOD_PAYMENT = "";
                    PAYMENT_METHOD = "AP";
                }
                else
                {
                    PERIOD_PAYMENT = dss_Insert.Tables[0].Rows[0]["trmsOfPyt"].ToString();
                    PAYMENT_METHOD = "NA";
                }               

                string state_dist = "";
                state_dist = Get_Valid_State_Name(ViewState["IEC"].ToString(), ViewState["exp_name"].ToString());

                if (state_dist != "")
                {
                    string[] ss = state_dist.Split('~');

                    STATE_OF_ORIGIN = ss[0];
                    DISTRICT_OF_ORIGIN = ss[1];
                    marksnos = ss[2];

                    marksnos = "CTN NO:" + dss_Insert.Tables[0].Rows[0]["ctnno"].ToString().Trim().Replace("CTN NO:", "").Replace(" ", "") + "-" + dss_Insert.Tables[0].Rows[0]["Tot_Carton"].ToString().Trim() + marksnos;
                    //marksnos = "WE INTEND TO CLAIM REWARDS UNDER MERCHANDISE EXPORTS FROM INDIA SCHEME";
                }
                string state_export = "";
                string[] sss = STATE_OF_ORIGIN.Split('-');
                state_export = sss[1];

                string Country_name = Get_Valid_Country_Name(txtCountry.Text.Trim());
                string Port_name = "", Final_Port_name = "";

                if (Country_name.Contains('-'))
                {
                    string[] county_code = Country_name.Split('-');
                    Country_name = county_code[0];
                    Port_name = Get_Valid_Port_Name_Code(txtPort.Text.Trim(), county_code[1]);
                }
                else
                {
                    Port_name = txtPort.Text;
                }

                Final_Port_name = txtPort.Text;
                if (ddlAdCode.SelectedItem != null && !string.IsNullOrEmpty(ddlAdCode.SelectedItem.Text))
                {
                    ADCODE = ddlAdCode.SelectedItem.Text;
                }
                string GE_CUSTOMHOUSE_CODE = "";
                if (COMPANY_IDD == "1586")
                {
                    GE_CUSTOMHOUSE_CODE = "INSTT6";
                }
                else
                {
                    GE_CUSTOMHOUSE_CODE = Session["CUSTOMHOUSE_CODE"].ToString();
                }

                TYPE_OF_EXPORTER = ddlType_Exp.SelectedValue;
                Dt_gen.Rows.Add(ViewState["exp_name"].ToString().Trim(), ViewState["branch_slno"].ToString().Trim(), txtConsigneeName.Text, "", hdfTransport_mode.Value, GE_CUSTOMHOUSE_CODE,
                                 Country_name, Port_name, Country_name, Final_Port_name, state_export, marksnos, ADCODE, TYPE_OF_EXPORTER);

                string BUYER = "N";
                if (txtBuyer.Text == "")
                {
                    txtBuyer.Text = "SAME AS CONSIGNEE";
                }
                if (txtBuyer.Text == "SAME AS CONSIGNEE")
                {
                    BUYER = "Y";
                }

                

                FOB_CHARGES = ViewState["FOB_CHARGES"].ToString();
                FREIGHT_CHARGES = ViewState["FREIGHT_CHARGES"].ToString();
                INSURANCE_CHARGES = ViewState["INSURANCE_CHARGES"].ToString();
                COMMISSION_CHARGES = ViewState["COMMISSION_CHARGES"].ToString();
                string GetInvoiceValue = dss_Insert.Tables[0].Rows[0]["inv_val"].ToString().Replace(",", "").Replace("$", "");

                if (dt_INVOICE.Rows.Count == 1)
                {
                    curr = Get_Valid_Curr_Name(dss_Insert.Tables[0].Rows[0]["Currency"].ToString().Trim());
                    if (COMPANY_IDD == "816")
                    {
                        invdt = Get_Valid_Date(txtInvoiceDate.Text.Trim());
                    }
                    else
                    {
                        invdt = Get_Valid_Date1(txtInvoiceDate.Text.Trim());
                    }
                    
                    if (dss_Insert.Tables[0].Rows[0]["invNo"].ToString().Contains("+"))
                    {
                        InvNo = ViewState["fileNamewithoutextn"].ToString();
                    }
                    else
                    {
                        InvNo = dss_Insert.Tables[0].Rows[0]["invNo"].ToString();
                    }

                    TERMS = ddlTerms.Text.Contains("FOB") ? "FOB" : ddlTerms.Text.Trim();

                    Dt_Invoice.Rows.Add("1", InvNo, invdt.Trim(), PAYMENT_METHOD, PERIOD_PAYMENT, GetInvoiceValue, curr, Get_ExchangeRate(curr), CONTRCT_NO,
                   TERMS, BUYER, txtBuyer.Text, AUTHORIZED_ECONOMIC_OPERATOR_CODE, A_E_O_COUNTRY, AUTHORIZED_ECONOMIC_OPERATOR, FOB_CHARGES, FREIGHT_CHARGES, INSURANCE_CHARGES, COMMISSION_CHARGES, "");
                }
                else
                {
                    for (int h = 0; h <= dt_INVOICE.Rows.Count - 1; h++)
                    {
                        InvNo = dt_INVOICE.Rows[h]["InvoiceNo"].ToString();
                        if (COMPANY_IDD == "816")
                        {
                            invdt = Get_Valid_Date(dt_INVOICE.Rows[h]["InvoiceDate"].ToString().Trim());
                        }
                        else
                        {
                            invdt = Get_Valid_Date1(dt_INVOICE.Rows[h]["InvoiceDate"].ToString().Trim());
                        }
                        curr = Get_Valid_Curr_Name(dt_INVOICE.Rows[h]["Currency"].ToString().Trim());
                        TERMS = dt_INVOICE.Rows[h]["Terms"].ToString().Trim().Replace("FCA", "FOB").Replace("FOC", "FOB");
                        InvValue = dt_INVOICE.Rows[h]["InvoiceValue"].ToString().Trim();
                        FREIGHT_CHGS = dt_INVOICE.Rows[h]["FREIGHT_CHARGES"].ToString().Trim();
                        INSURANCE_CHARGES = dt_INVOICE.Rows[h]["INSURANCE_CHARGES"].ToString().Trim();
                        string OTHER_DED_CHARGES = dt_INVOICE.Rows[h]["OTHER_DED_CHARGES"].ToString().Trim();

                        Dt_Invoice.Rows.Add((h + 1), InvNo, invdt.Trim(), PAYMENT_METHOD, PERIOD_PAYMENT, InvValue, curr, Get_ExchangeRate(curr), CONTRCT_NO,
                            TERMS, BUYER, txtBuyer.Text, AUTHORIZED_ECONOMIC_OPERATOR_CODE, A_E_O_COUNTRY, AUTHORIZED_ECONOMIC_OPERATOR, FOB_CHARGES, FREIGHT_CHGS, INSURANCE_CHARGES, COMMISSION_CHARGES, OTHER_DED_CHARGES);
                    }
                }
                //Dt_Invoice.Rows.Add("1", InvNo, invdt.Trim(), PAYMENT_METHOD, PERIOD_PAYMENT,
                //            GetInvoiceValue, curr, Get_ExchangeRate(curr), CONTRCT_NO, TERMS, BUYER, txtBuyer.Text, AUTHORIZED_ECONOMIC_OPERATOR_CODE, A_E_O_COUNTRY, AUTHORIZED_ECONOMIC_OPERATOR, FOB_CHARGES, FREIGHT_CHARGES, INSURANCE_CHARGES, COMMISSION_CHARGES);

                //--------Dt_anx------------

                string ANNEX_SEA_SEAL_TYPE = "";
                string ANNEX_SEA_FAC_STUFFED = "N";
                string ANNEX_SEA_SAMPLE_ACCOM = "N";
                string ANNEX_SEA_NATURE_OF_CARGO = "C";
                string ANNEX_SEA_NO_CONTAINERS = "";
                string ANNEX_SEA_UNIT_MEASUREMENT = "KGS";
                string ANNEX_SEA_PKG_UNIT_CODE = "";
                string ANNEX_SEA_TOTAL_PACKAGES = "";

                string ANNEX_AIR_NATURE_OF_CARGO = "P";
                string ANNEX_AIR_GR_UNIT_CODE = "";
                string ANNEX_AIR_TOTAL_PACKAGES = "";

                if (dss_Insert.Tables[0].Rows[0]["ctnno"].ToString() != "")
                {
                    ANNEX_SEA_TOTAL_PACKAGES = dss_Insert.Tables[0].Rows[0]["Tot_Carton"].ToString();
                }

                if (Connection.COMPANYID() == "1586")
                {
                    ANNEX_SEA_PKG_UNIT_CODE = "CTN";
                }
                else if (Connection.COMPANYID() == "816")
                {
                    ANNEX_SEA_SEAL_TYPE="Warehouse";
                    ANNEX_SEA_PKG_UNIT_CODE = "PKG";
                }

                if (hdfTransport_mode.Value == "Air")
                {
                    Dt_anx_Air.Rows.Add(ANNEX_AIR_NATURE_OF_CARGO, marksnos, dss_Insert.Tables[0].Rows[0]["Tot_Carton"].ToString(),
                    dss_Insert.Tables[0].Rows[0]["Tot_grosswt"].ToString().ToLower().Replace("kgs", "").Replace(",", ""),
                    dss_Insert.Tables[0].Rows[0]["Tot_netwt"].ToString().ToLower().Replace("kgs", "").Replace(",", ""), dss_Insert.Tables[0].Rows[0]["Qtycode"].ToString());
                }
                else
                {
                    Dt_anx.Rows.Add(ANNEX_SEA_FAC_STUFFED, ANNEX_SEA_SAMPLE_ACCOM, ANNEX_SEA_NATURE_OF_CARGO, marksnos, ANNEX_SEA_TOTAL_PACKAGES, ANNEX_SEA_NO_CONTAINERS, ANNEX_SEA_UNIT_MEASUREMENT
                   , ANNEX_SEA_SEAL_TYPE, dss_Insert.Tables[0].Rows[0]["Tot_grosswt"].ToString().ToLower().Replace("kgs", "").Replace(",", ""), dss_Insert.Tables[0].Rows[0]["Tot_netwt"].ToString().ToLower().Replace("kgs", "").Replace(",", ""), ANNEX_SEA_PKG_UNIT_CODE);
                }

                string UNDER_PTA_FTA = "", Item_Qty = "0", Item_UnitPrice = "0", Itemdesc = "", Item_Amount = "", Item_SlNo, InfoQty, Qty_Cd = "", Item_Desc_Customized = "",
                    SCHEME_CODE = "", STR_YES_NO = "", REWARD_YES_NO = "", RODTEP = "", CESS_YN = "", END_USE_OF_ITEM = "", ITEM_ACCESSORIES_DESC = "", DBK_SL_NO = "", DBK_UNIT = "", RITCNO = "", SQC = "", dbk_decl = "", TAXABLE_VALUE = "", IGST_AMT = "", Inv_SlNo = "";

                string DRAWBACK_SLNO = "", DRAWBACK_DESCRIPTION = "", DRAWBACK_RATE = "", DRAWBACK_VALUE_CAP = "", DRAWBACK_UNIT = "", DRAWBACK_NOOFUNITS = "", STATE_LEVEL_ADV_RATE = "", STATE_LEVEL_ADV_AMT = "", CENTRAL_LEVEL_ADV_RATE = "", CENTRAL_LEVEL_ADV_AMT = "";

                bool Chk_Qty_code = true;
                for (int i = 0; i <= dt_ITEM.Rows.Count - 1; i++)
                {

                    //----common ----
                    Inv_SlNo = dt_ITEM.Rows[i]["INVOICE_SLNO"].ToString().TrimEnd();
                    Item_SlNo = dt_ITEM.Rows[i]["ITEM_SLNO"].ToString().TrimEnd();

                    string GetQTY = dt_ITEM.Rows[i]["ITEM_QTY"].ToString().TrimEnd().TrimEnd().Replace(",", "");
                    if (GetQTY != "" && GetQTY != string.Empty)
                    {
                        Item_Qty = GetQTY;
                    }
                    else
                    {
                        Item_Qty = "0";
                    }
                    Qty_Cd = dt_ITEM.Rows[i]["ITEM_QTY_CODE"].ToString().TrimEnd().ToUpper();
                    if (Qty_Cd != "" && Qty_Cd.Length > 3)
                    {
                        if (COMPANY_IDD == "816")
                        {
                            Qty_Cd = "NOS";
                        }
                        else
                        {
                            Alert_msg("Qty Code must be 3 characters..!");
                            Chk_Qty_code = false;
                            break;
                        }
                    }
                    Item_UnitPrice = dt_ITEM.Rows[i]["ITEM_UNITPRICE"].ToString().TrimEnd();
                    Itemdesc = dt_ITEM.Rows[i]["ITEM_DESC"].ToString().TrimEnd();

                    string GetAmount = dt_ITEM.Rows[i]["ITEM_AMOUNT"].ToString().TrimEnd().Replace(",", "");
                    Item_Amount = GetAmount;
                    InfoQty = dt_ITEM.Rows[i]["INFO_QTY"].ToString().TrimEnd().Replace("N/A", "").Replace(",", "");
                    Item_Desc_Customized = Itemdesc;

                    DropDownList SCHEME_CODE_GD = (DropDownList)gv_ItemPDF.Rows[i].FindControl("ddl_SchemeCode");
                    SCHEME_CODE = SCHEME_CODE_GD.SelectedValue;
                    DropDownList ddl_STRYN_GD = (DropDownList)gv_ItemPDF.Rows[i].FindControl("ddl_STRYN");
                    STR_YES_NO = ddl_STRYN_GD.SelectedValue;
                    DropDownList ddl_Reward_Points_GD = (DropDownList)gv_ItemPDF.Rows[i].FindControl("ddl_Reward_Points");
                    REWARD_YES_NO = ddl_Reward_Points_GD.SelectedValue;
                    DropDownList ddl_RodtepYN_GD = (DropDownList)gv_ItemPDF.Rows[i].FindControl("ddl_RodtepYN");
                    RODTEP = ddl_RodtepYN_GD.SelectedValue;
                    DropDownList ddl_CessYN_GD = (DropDownList)gv_ItemPDF.Rows[i].FindControl("ddl_CessYN");
                    CESS_YN = ddl_CessYN_GD.SelectedValue;
                    TextBox txtEndUseOfItems_GD = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtEndUseOfItems");
                    if (txtEndUseOfItems_GD.Text.Trim() != "")
                    {
                        END_USE_OF_ITEM = txtEndUseOfItems_GD.Text.Split('-')[0];
                    }
                    TextBox txtUnderPTA_GD = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtUnderPTA");
                    UNDER_PTA_FTA = txtUnderPTA_GD.Text;
                    DropDownList ddl_IGSTPayment_GD = (DropDownList)gv_ItemPDF.Rows[i].FindControl("ddl_IGSTPayment");
                    IGST_PAYMENT = ddl_IGSTPayment_GD.SelectedValue;

                    ITEM_ACCESSORIES_DESC = txtAccessoryDesc.Text.TrimEnd();

                    TextBox txt_IGST_Rate_GD = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_IGSTRate");
                    IGST_RATE = txt_IGST_Rate_GD.Text;
                    TextBox txtDrawback_SLNo_GD = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtDrawback_SLNo");
                    DBK_SL_NO = txtDrawback_SLNo_GD.Text;
                    TextBox txt_DBK_Unit_GD = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtDBK_Unit");
                    DBK_UNIT = txt_DBK_Unit_GD.Text;
                    TextBox txtRITCNo_GD = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_RITCNo");
                    RITCNO = txtRITCNo_GD.Text;

                    if (DBK_SL_NO != "" && DBK_SL_NO != null)
                    {
                        Auto.Ename = "DRAWBACK_MASTER_ALL";
                        Auto.Enamesearch = DBK_SL_NO;
                        Auto.Notn_No_Search = "";
                        DataSet ds_draw_DD = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
                        if (ds_draw_DD.Tables[0].Rows.Count > 0)
                        {
                            dbk_decl = ds_draw_DD.Tables[0].Rows[0]["DRAWBACK_DESCRIPTION"].ToString();
                        }
                    }

                    if (COMPANY_IDD == "1586" || COMPANY_IDD == "816")
                    {
                        Auto.Ename = "Get_CTH_Info_Uqc";
                        Auto.Enamesearch = RITCNO;
                        Auto.Notn_No_Search = RITCNO;
                        DataSet SQC_ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
                        if (SQC_ds.Tables[0].Rows.Count > 0)
                        {
                            SQC = SQC_ds.Tables[0].Rows[0][0].ToString();
                        }

                        if (COMPANY_IDD == "816" || COMPANY_IDD == "1586")
                        {

                            if (Qty_Cd == SQC)
                            {
                                InfoQty = Item_Qty;
                            }
                        }
                    }

                    //#Item
                    Dt_Item.Rows.Add(Inv_SlNo, InvNo, Item_SlNo, Itemdesc, Item_Qty, Qty_Cd, Item_UnitPrice, Item_Amount, STATE_OF_ORIGIN, DISTRICT_OF_ORIGIN, UNDER_PTA_FTA, InfoQty, IGST_PAYMENT, IGST_RATE, Item_Desc_Customized,
                        SCHEME_CODE, STR_YES_NO, REWARD_YES_NO, RODTEP, CESS_YN, END_USE_OF_ITEM, ITEM_ACCESSORIES_DESC, dbk_decl, DBK_SL_NO, DBK_UNIT, RITCNO, SQC, TAXABLE_VALUE, IGST_AMT);

                    if (DBK_SL_NO != "" && DBK_SL_NO != null && DBK_SL_NO != string.Empty)
                    {
                        Auto.Ename = "DRAWBACK_MASTER_ALL_Excel_Upload";
                        Auto.Enamesearch = DBK_SL_NO;
                        Auto.Notn_No_Search = "";
                        ds_draw = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

                        if (ds_draw.Tables[0].Rows.Count > 0)
                        {
                            for (int a = 0; a <= ds_draw.Tables[0].Rows.Count-1; a++)
                            {
                                DRAWBACK_RATE = ds_draw.Tables[0].Rows[a]["DRAWBACK_RATE"].ToString();
                                DRAWBACK_VALUE_CAP = ds_draw.Tables[0].Rows[a]["DRAWBACK_VALUE_CAP"].ToString();
                                DRAWBACK_UNIT = ds_draw.Tables[0].Rows[a]["DRAWBACK_UNIT"].ToString();
                                DRAWBACK_NOOFUNITS = ds_draw.Tables[0].Rows[a]["DRAWBACK_NOOFUNITS"].ToString();
                                STATE_LEVEL_ADV_RATE = ds_draw.Tables[0].Rows[a]["STATE_LEVEL_ADV_RATE"].ToString();
                                STATE_LEVEL_ADV_AMT = ds_draw.Tables[0].Rows[a]["STATE_LEVEL_ADV_AMT"].ToString();
                                CENTRAL_LEVEL_ADV_RATE = ds_draw.Tables[0].Rows[a]["CENTRAL_LEVEL_ADV_RATE"].ToString();
                                CENTRAL_LEVEL_ADV_AMT = ds_draw.Tables[0].Rows[a]["CENTRAL_LEVEL_ADV_AMT"].ToString();

                                Dt_DBK.Rows.Add(DBK_SL_NO, "", DRAWBACK_RATE, DRAWBACK_VALUE_CAP, DRAWBACK_UNIT, DRAWBACK_NOOFUNITS, STATE_LEVEL_ADV_RATE, STATE_LEVEL_ADV_AMT, CENTRAL_LEVEL_ADV_RATE, CENTRAL_LEVEL_ADV_AMT);                              
                            }
                        }
                    }
                    DBK_SL_NO = ""; dbk_decl = "";
                }

                //--------Dt_AR_4_Details   Start------------
                if (ViewState["exp_name"].ToString().ToUpper() == "GROWMECH INDUSTRIES PRIVATE LIMITED")
                {
                    dt_AR_4_Details = (DataTable)ViewState["dt_AR_4_Details"];
                }
                //--------Dt_AR_4_Details   End------------

                exp_pdf.EXPORTER_NAME = ViewState["exp_name"].ToString().Trim();
                exp_pdf.BRANCH_NO = ViewState["branch_slno"].ToString();
                exp_pdf.JOBNO = GENERAL_EXPORT_JOBNO;
                exp_pdf.COMAPANY_ID = COMPANY_IDD;
                exp_pdf.USER_ID = currentuser;
                exp_pdf.WORKINGPERIOD = Working_Period;
                exp_pdf.Branch_Code = currentbranch;
                exp_pdf.flag = "Insert_Desc";
                if (Chk_Qty_code == true)
                {
                    dss_Insert = exp_pdf.Exp_Excel_Upload_New_XML_AI(Dt_gen, Dt_Item, Dt_DBK, Dt_Invoice, Dt_anx, Dt_anx_Air, dt_Temp_Con, dt_AR_4_Details);
                }

                if (exp_pdf.result == 1)
                {
                    Session["JOBIDexcel"] = dss_Insert.Tables[0].Rows[0][0].ToString();

                    //Alert_msg("PDF Uploaded Successfully..!");
                    //lbl_loading.Text = "Job Created Successfully..";
                    lbl_loading.Text = "<span style='color: green; font-weight: bold;'>✅ Job Created Successfully...</span>";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popupChecklist", "showChecklistPopup();", true);

                    con.Open();
                    SqlCommand PScmd =
                        new SqlCommand(
                            "select * from PDF_AI_COUNT_DETAILS where PDF_JOB_NO = '" + txtjobPS.Text + "' and PDF_EXP_IMP_NAME='" + ViewState["exp_name"].ToString().Trim() + "' and PDF_BRANCH_CODE ='" + currentbranch + "'", con);
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
                }
                else
                {
                    lbl_loading.Text = "Job error..";
                    Alert_msg("error..!");
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public void AUTO_JOBNO()
    {
        Export.BRANCH_CODE = Connection.Get_Company_Type();
        Export.WORKING_PERIOD = Connection.WorkingPeriod();
        JOBNO = Convert.ToString(Export.Retrieve_JobNO());
        JobNo_Prefix_Sufix();
    }

    public void JobNo_Prefix_Sufix()
    {
        Admin_job_Prefix_Suffix JPS = new Admin_job_Prefix_Suffix();
        DataSet dats = new DataSet();
        JPS.Branch = Connection.Get_Company_Type();
        JPS.Ename = "Exp_gen_select";
        JPS.Tr_mode = Session["CUSTOMHOUSE_TRANSPORT_MODE"].ToString();
        dats = JPS.Job_prefix_Suffix_Select();
        int Jno = 0;

        if (JOBNO != string.Empty)
        {
            Jno = Convert.ToInt32(JOBNO);
            if (Jno < 1000)
            {
                if (Jno > 100)
                {
                    JOBNO = "00" + JOBNO;
                    hdn_JOBNO_digit.Value = "00";
                }
                else if (Jno > 10)
                {
                    JOBNO = "000" + JOBNO;
                    hdn_JOBNO_digit.Value = "000";

                }
                else
                {
                    JOBNO = "0000" + JOBNO;
                    hdn_JOBNO_digit.Value = "000";

                }
            }
        }
        if (Session["COMPANY_LICENSE"] != null)
        {

            if (dats.Tables[0].Rows.Count > 0)
            {
                if (dats.Tables[0].Rows[0][0].ToString() == string.Empty && dats.Tables[0].Rows[0][1].ToString() != string.Empty)
                {
                    hdn_JOBNO_PS.Value = JOBNO + "/" + ((dats.Tables[0].Rows[0][1].ToString()).TrimStart()).TrimEnd();
                    hdprefix.Value = string.Empty;
                    hdsuffix.Value = ((dats.Tables[0].Rows[0][1].ToString()).TrimStart()).TrimEnd();
                }
                else if (dats.Tables[0].Rows[0][0].ToString() != string.Empty && dats.Tables[0].Rows[0][1].ToString() == string.Empty)
                {
                    if (Connection.COMPANYID() == "1163" || Connection.COMPANYID() == "1164" || Connection.COMPANYID() == "1165" || Connection.COMPANYID() == "1166")
                    {
                        hdn_JOBNO_PS.Value = ((dats.Tables[0].Rows[0][0].ToString() + "/" + JOBNO).TrimEnd()).TrimStart();
                    }
                    else
                    {
                        hdn_JOBNO_PS.Value = ((dats.Tables[0].Rows[0][0].ToString() + "/" + JOBNO).TrimEnd()).TrimStart();
                    }
                    hdprefix.Value = ((dats.Tables[0].Rows[0][0].ToString()).TrimEnd()).TrimStart();
                    hdsuffix.Value = string.Empty;
                }
                else if (dats.Tables[0].Rows[0][0].ToString() != string.Empty && dats.Tables[0].Rows[0][1].ToString() != string.Empty)
                {
                    if (Connection.COMPANYID() == "1163" || Connection.COMPANYID() == "1164" || Connection.COMPANYID() == "1165" || Connection.COMPANYID() == "1166")
                    {
                        hdn_JOBNO_PS.Value = ((dats.Tables[0].Rows[0][0].ToString() + "/" + JOBNO + "/" + dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                    }
                    else
                    {
                        hdn_JOBNO_PS.Value = ((dats.Tables[0].Rows[0][0].ToString() + "/" + JOBNO + "/" + dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                    }

                    hdprefix.Value = ((dats.Tables[0].Rows[0][0].ToString()).TrimEnd()).TrimStart();
                    hdsuffix.Value = ((dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                }
                else if (dats.Tables[0].Rows[0][0].ToString() == string.Empty && dats.Tables[0].Rows[0][1].ToString() == string.Empty)
                {
                    hdn_JOBNO_PS.Value = JOBNO;
                    hdprefix.Value = string.Empty;
                    hdsuffix.Value = string.Empty;
                }
            }
            else
            {
                hdn_JOBNO_PS.Value = JOBNO;
                hdprefix.Value = string.Empty;
                hdsuffix.Value = string.Empty;
            }
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

        txtBuyer.Text = "";
        txtConsigneeName.Text = "";
        txtNotifyParty.Text = "";
        txtInvoiceNo.Text = "";
        txtInvoiceDate.Text = "";
        ddlTerms.SelectedIndex = -1;
        txtCurrency.Text = "";
        txtCountry.Text = "";
        txtPort.Text = "";

        DataTable dt = new DataTable();
        gv_ItemPDF.DataSource = dt;
        gv_ItemPDF.DataBind();
    }

    public void Chk_Invoice_No()
    {

    }

    private string get_5Digit(string val)
    {
        if (val.Contains("."))
        {
            string digit = "";
            string[] splt = val.Split('.');
            if (splt[1].Length > 5)
            {
                int tot = splt[1].Length - 5;
                digit = splt[1].Substring(0, splt[1].Length - tot);
                val = splt[0] + "." + digit;
            }
        }

        return val;
    }

    public string Get_ExchangeRate(string Inv_Curr)
    {

        Auto.Ename = "EXCHANGE_MASTER_RATE_EXPORTWISE";
        Auto.Enamesearch = Inv_Curr;
        Auto.Notn_No_Search = "";
        ds_draw = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

        if (ds_draw.Tables[0].Rows.Count > 0)
        {
            Inv_Curr = ds_draw.Tables[0].Rows[0]["EXCHANGE_RATE_EXPORT"].ToString();
        }

        return Inv_Curr;
    }

    public string Get_Valid_Country_Name(string COUNTRY_FINAL_DEST)
    {
        eroyalmaster erm = new eroyalmaster();
        DataSet ds_con = new DataSet();

        erm.PDF_COUNTRY_NAME = COUNTRY_FINAL_DEST;
        erm.COUNTRY_NAME = "";
        erm.COUNTRY_CODE = "";
        erm.Ename = "select_CountryName_Job";

        ds_con = erm.PDF_COUNTRY_MASTER_Insert_update_Search();

        if (ds_con.Tables[0].Rows.Count > 0)
        {
            COUNTRY_FINAL_DEST = ds_con.Tables[0].Rows[0]["COUNTRY_NAME"].ToString();
        }
        else
        {
            Auto_Search Auto = new Auto_Search();
            Auto.Ename = "COUNTRY_MASTER";
            Auto.Enamesearch = COUNTRY_FINAL_DEST;
            Auto.Notn_No_Search = "";
            ds_con = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

            if (ds_con.Tables[0].Rows.Count > 0)
            {
                COUNTRY_FINAL_DEST = ds_con.Tables[0].Rows[0]["COUNTRY_NAME"].ToString();
            }
        }

        return COUNTRY_FINAL_DEST;
    }

    public string Get_Valid_Port_Name_Code(string PORT_FINAL_DEST, string COUNTRY_CODE)
    {
        eroyalmaster erm = new eroyalmaster();
        DataSet ds_con = new DataSet();

        erm.PDF_PORTNAME = PORT_FINAL_DEST;
        erm.PORT_NAME = "";
        erm.PORT_CODE = "";
        erm.COUNTRY_CODE = COUNTRY_CODE;
        erm.Ename = "select_PortName_Job";

        ds_con = erm.PDF_PORT_MASTER_Insert_update_Search();

        if (ds_con.Tables[0].Rows.Count > 0)
        {
            PORT_FINAL_DEST = ds_con.Tables[0].Rows[0]["PORT_NAME"].ToString();
        }
        else
        {
            Auto_Search Auto = new Auto_Search();
            Auto.Ename = "PORT_MASTER_SEA_LAND";
            Auto.Enamesearch = PORT_FINAL_DEST;
            Auto.Notn_No_Search = "";
            ds_con = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds_con.Tables[0].Rows.Count > 0)
            {
                if (ds_con.Tables[0].Rows.Count == 1)
                {
                    PORT_FINAL_DEST = ds_con.Tables[0].Rows[0]["PORT_NAME"].ToString();
                }
                else
                {
                    for (int i = 0; i <= ds_con.Tables[0].Rows.Count - 1; i++)
                    {
                        string[] sp = ds_con.Tables[0].Rows[i]["PORT_NAME"].ToString().Split('-');

                        if (sp[1].Substring(0, 2) == COUNTRY_CODE && sp[0] == PORT_FINAL_DEST)
                        {
                            PORT_FINAL_DEST = ds_con.Tables[0].Rows[i]["PORT_NAME"].ToString();
                            break;
                        }
                    }
                }
            }
        }

        return PORT_FINAL_DEST;
    }

    private string Get_Valid_Curr_Name(string curr)
    {
        if (curr == "EURO")
        {
            curr = "EUR";
        }
        else if (curr == "US$" || curr == "FOB/USD" || curr == "US" || curr == "US $")
        {
            curr = "USD";
        }

        return curr;
    }

    private string Get_Valid_Qty_Code(string curr)
    {
        if (curr == "SETS" || curr.Contains("SET") || curr == "SET(S)" || curr == "Sets")
        {
            curr = "SET";
        }
        else if (curr == "PIECE(S)" || curr == "Pcs." || curr == "Pcs")
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
        else if (curr == "MTRS." || curr == "MTRS" || curr == "MTR." || curr == "METER" || curr.Contains("MTR"))
        {
            curr = "MTR";
        }
        else if (curr == "KM" || curr.Contains("KM"))
        {
            curr = "KME";
        }
        else if (curr == "FT" || curr == "FT." || curr.Contains("FT"))
        {
            curr = "FTS";
        }
        else if (curr == "PAIR")
        {
            curr = "PRS";
        }
        else if (curr == "EA")
        {
            curr = "NOS";
        }
        else if (curr == "KG")
        {
            curr = "KGS";
        }
        return curr;


    }

    private string Get_Valid_Date1(string Dt)
    {
        Dt = Dt.Replace(".", "/").Replace("-", "/").Trim();
        string[] dd = Dt.Split('/');

        //if (dd[0].Length != 2)
        //{
        //    dd[0] = "0" + dd[0];
        //}
        //if (dd[1].Length != 2)
        //{
        //    dd[1] = "0" + dd[1];
        //}
        //if (dd[2].Length != 4)
        //{
        //    dd[2] = "20" + dd[2];
        //}

        return Dt = dd[1] + "/" + dd[0] + "/" + dd[2];
    }

    private string Get_Valid_Date(string Dt)
    {
        if (string.IsNullOrWhiteSpace(Dt))
            return "Invalid Date";

        Dt = Dt.Trim();

        // Normalize common separators
        Dt = Dt.Replace(".", "/")
               .Replace("-", "/")
               .Replace(",", "/")
               .Replace("  ", " ");


        // List of common formats
        string[] formats = new[]
      {
        "MMM/dd/yyyy", "dd/MMM/yyyy", "MM/dd/yyyy", "dd/MM/yyyy",
        "yyyy/MM/dd", "yyyyMMdd", "dd/MM/yy", "dd/MMM/yy",
        "MMM.d/yyyy", "MMM.d/yyyy", "dd-MMM-yy", "MMM dd yyyy",
        "MMM dd, yyyy", "dd MMM yyyy", "dd MMM, yyyy", "dd.MM.yyyy",
        "dd-MM-yyyy", "yyyy-MM-dd", "MMMM d yyyy", "MMMM d, yyyy",
        "dd/MMM/yyyy", "MMM.d.yyyy", "d/MM/yyyy", "d/M/yyyy",
        "M/d/yyyy", "MM/dd/yy", "dd MMM yy", "MMM dd yy"
      };

        DateTime parsedDate;
        string[] ddd = Dt.Split('/');
        if (ddd[1].Length == 2)
        {
            return Dt = ddd[1] + "/" + ddd[0] + "/" + ddd[2];
        }
        else
        {

            // Try exact matching first
            if (DateTime.TryParseExact(Dt, formats, CultureInfo.InvariantCulture,
                                       DateTimeStyles.AllowWhiteSpaces, out parsedDate))
            {
                return parsedDate.ToString("MM/dd/yyyy");
            }

            // Try general parsing as fallback
            if (DateTime.TryParse(Dt, CultureInfo.InvariantCulture,
                                  DateTimeStyles.AllowWhiteSpaces, out parsedDate))
            {
                return parsedDate.ToString("MM/dd/yyyy");
            }
        }

        return "Invalid Date";
    }

    public string Get_Valid_State_Name(string IEC, string ExporterName)
    {
        string result = "";
        DataSet ds_state = new DataSet();
        DataSet ds_con = new DataSet();


        erm.PDF_PORTNAME = ExporterName;
        erm.PORT_NAME = IEC;
        erm.PORT_CODE = ViewState["branch_slno"].ToString();
        erm.COUNTRY_CODE = "";
        erm.Ename = "select_Client_Master_Details";

        ds_state = erm.PDF_PORT_MASTER_Insert_update_Search();

        Auto_Search Auto = new Auto_Search();
        Auto.Ename = "Select_State_District_Itemdetails";
        Auto.Enamesearch = ds_state.Tables[0].Rows[0]["IMP_EXP_ADD4"].ToString();
        Auto.Notn_No_Search = ds_state.Tables[0].Rows[0]["DISTRICT"].ToString();
        ds_con = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

        if (ds_con.Tables[0].Rows.Count > 0)
        {
            result = ds_con.Tables[0].Rows[0]["STATE_NAME"].ToString() + "~" + ds_con.Tables[1].Rows[0]["DISTRICT_NAME"].ToString() + "~" + ds_state.Tables[0].Rows[0]["MARKS_NO"].ToString();
        }


        return result;
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
                    for (int i = 0; i < gv_ItemPDF.Rows.Count; i++)
                    {

                        if (ddlSchemeCode.SelectedItem.Text != "")
                        {
                            DropDownList ddl_SchemeCode = (DropDownList)gv_ItemPDF.Rows[i].FindControl("ddl_SchemeCode");
                            ddl_SchemeCode.SelectedValue = ddlSchemeCode.SelectedValue;
                        }
                        if (txtRITCNo.Text != "")
                        {
                            TextBox txt_RITCNo = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_RITCNo");
                            txt_RITCNo.Text = txtRITCNo.Text;
                        }
                        if (ddl_STR_YN.SelectedItem.Text != "")
                        {
                            DropDownList ddl_STRYN = (DropDownList)gv_ItemPDF.Rows[i].FindControl("ddl_STRYN");
                            ddl_STRYN.SelectedValue = ddl_STR_YN.SelectedValue;
                        }
                        if (ddlRewardPoints.SelectedValue != "")
                        {
                            DropDownList ddl_Reward_Points = (DropDownList)gv_ItemPDF.Rows[i].FindControl("ddl_Reward_Points");
                            ddl_Reward_Points.SelectedValue = ddlRewardPoints.SelectedValue;
                        }
                        if (ddl_Rodtep_YN.SelectedItem.Text != "")
                        {
                            DropDownList ddl_RodtepYN = (DropDownList)gv_ItemPDF.Rows[i].FindControl("ddl_RodtepYN");
                            ddl_RodtepYN.SelectedValue = ddl_Rodtep_YN.SelectedValue;
                        }
                        if (ddl_Cess_YN.SelectedItem.Text != "")
                        {
                            DropDownList ddl_CessYN = (DropDownList)gv_ItemPDF.Rows[i].FindControl("ddl_CessYN");
                            ddl_CessYN.SelectedValue = ddl_Cess_YN.SelectedValue;
                        }
                        if (txtEnduseItem.Text != "")
                        {
                            TextBox txtEndUseOfItems = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtEndUseOfItems");
                            txtEndUseOfItems.Text = txtEnduseItem.Text;
                        }
                        if (txt_PTA_FTA.Text != "")
                        {
                            TextBox txtUnderPTA = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtUnderPTA");
                            txtUnderPTA.Text = txt_PTA_FTA.Text;
                        }
                        if (ddl_IGST_Payment.SelectedItem.Text != "")
                        {
                            DropDownList ddl_IGSTPayment = (DropDownList)gv_ItemPDF.Rows[i].FindControl("ddl_IGSTPayment");
                            ddl_IGSTPayment.SelectedValue = ddl_IGST_Payment.SelectedValue;
                        }
                        if (txt_IGST_Rate.Text != "")
                        {
                            TextBox txtIGSTRate = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_IGSTRate");
                            txtIGSTRate.Text = txt_IGST_Rate.Text;
                        }
                        if (txt_Drawback_SLNo.Text != "")
                        {
                            TextBox txtDrawbackSLNo = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtDrawback_SLNo");
                            txtDrawbackSLNo.Text = txt_Drawback_SLNo.Text;
                        }
                        if (txt_DBK_Unit.Text != "")
                        {
                            TextBox txtDBKUnit = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtDBK_Unit");
                            txtDBKUnit.Text = txt_DBK_Unit.Text;
                        }

                        rowIndex++;
                    }
                }
            }
            else
            {
                Alert_msg("Please Select Item...!");
            }
        }
        catch (Exception ex)
        {
            log.makeLog("Message ==> " + ex.Message);
            lblmsg.Text = " Message ==> " + ex.Message + " InnerException ==> " + ex.InnerException + " StackTrace ==>" + ex.StackTrace;
        }
    }

    protected void ddl_IGST_Payment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_IGST_Payment.SelectedValue == "P")
        {
            txt_IGST_Rate.Enabled = true;
        }
        else
        {
            txt_IGST_Rate.Enabled = false;
            txt_IGST_Rate.Text = "";
        }
    }

    protected void ddl_IGSTPayment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_IGST_Payment.SelectedValue == "P")
        {
            txt_IGST_Rate.Enabled = true;
        }
        else
        {
            txt_IGST_Rate.Enabled = false;
            txt_IGST_Rate.Text = "";
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
                            if (GridViewData.Rows[j]["INVOICE_SLNO"].ToString() == Inv_slno.ToString() &&
                                GridViewData.Rows[j]["ITEM_SLNO"].ToString() == slno.ToString())
                            {
                                TextBox txtEndUseOfItems = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtEndUseOfItems");
                                TextBox txtUnderPTA = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtUnderPTA");
                                TextBox txt_IGSTRate = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_IGSTRate");
                                TextBox txtDrawback_SLNo = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtDrawback_SLNo");
                                TextBox txtDBK_Unit = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtDBK_Unit");
                                DropDownList ddl_SchemeCode = (DropDownList)gv_ItemPDF.Rows[i].FindControl("ddl_SchemeCode");
                                TextBox txt_RITCNo = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_RITCNo");
                                TextBox txtItemDesc = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtItemDesc");
                                DropDownList ddl_STRYN = (DropDownList)gv_ItemPDF.Rows[i].FindControl("ddl_STRYN");
                                DropDownList ddl_Reward_Points = (DropDownList)gv_ItemPDF.Rows[i].FindControl("ddl_Reward_Points");
                                DropDownList ddl_RodtepYN = (DropDownList)gv_ItemPDF.Rows[i].FindControl("ddl_RodtepYN");
                                DropDownList ddl_CessYN = (DropDownList)gv_ItemPDF.Rows[i].FindControl("ddl_CessYN");
                                DropDownList ddl_IGSTPayment = (DropDownList)gv_ItemPDF.Rows[i].FindControl("ddl_IGSTPayment");

                                GridViewData.Rows[j]["END_USE_OF_ITEM"] = txtEndUseOfItems.Text;
                                GridViewData.Rows[j]["UNDER_PTA_FTA"] = txtUnderPTA.Text;
                                GridViewData.Rows[j]["IGST_RATE"] = txt_IGSTRate.Text;
                                GridViewData.Rows[j]["DBK_SL_NO"] = txtDrawback_SLNo.Text;
                                GridViewData.Rows[j]["DBK_UNIT"] = txtDBK_Unit.Text;
                                GridViewData.Rows[j]["SCHEME_CODE"] = ddl_SchemeCode.SelectedValue;
                                GridViewData.Rows[j]["RITCNO"] = txt_RITCNo.Text;
                                GridViewData.Rows[j]["ITEM_DESC"] = txtItemDesc.Text;
                                GridViewData.Rows[j]["STR_YES_NO"] = ddl_STRYN.SelectedValue;
                                GridViewData.Rows[j]["REWARD_YES_NO"] = ddl_Reward_Points.SelectedValue;
                                GridViewData.Rows[j]["RODTEP"] = ddl_RodtepYN.SelectedValue;
                                GridViewData.Rows[j]["CESS_YN"] = ddl_CessYN.SelectedValue;
                                GridViewData.Rows[j]["IGST_PAYMENT"] = ddl_IGSTPayment.SelectedValue;
                                break;
                            }
                        }
                    }

                    DataTable filteredTable = FilterDataTableBySerialNumbers(GridViewData);

                    gv_ItemPDF.DataSource = filteredTable;
                    gv_ItemPDF.DataBind();

                    ViewState["GridViewData"] = GridViewData;
                }
            }
            else
            {
                Alert_msg("Please Select Item...!");
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

                    InvoiceserialNumbers = Convert.ToInt32(row["INVOICE_SLNO"]);
                    if (ddl_Select_ItemRITC.SelectedValue == "0")
                    {
                        serialNo = Convert.ToInt32(row["ITEM_SLNO"]);
                    }
                    else if (ddl_Select_ItemRITC.SelectedValue == "1")
                    {
                        serialNo = Convert.ToInt32(row["RITCNO"]);
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
        DataTable dt_GridViewData = (DataTable)ViewState["GridViewData"];
        if (dt_GridViewData.Rows.Count > 0)
        {
            var distinctValues = dt_GridViewData.AsEnumerable().Select(row => row["INVOICE_SLNO"].ToString()).Distinct().ToList();

            DataTable distinctDt = dt_GridViewData.Clone();
            foreach (var value in distinctValues)
            {
                distinctDt.Rows.Add(value);
            }
            ListBox_INVSlno.DataSource = distinctDt;
            ListBox_INVSlno.DataTextField = "INVOICE_SLNO";
            ListBox_INVSlno.DataValueField = "INVOICE_SLNO";
            ListBox_INVSlno.DataBind();

            if (ddl_Select_ItemRITC.SelectedValue == "0")
            {

                ListBox_ItemSlno.Items.Clear();
                foreach (DataRow row in dt_GridViewData.Rows)
                {
                    string invoiceSlno = row["INVOICE_SLNO"].ToString(); // Assuming INVOICE_SLNO is a string
                    string itemSlno = row["ITEM_SLNO"].ToString(); // Assuming ITEM_SLNO is a string

                    string itemText = invoiceSlno + "~" + itemSlno;
                    string itemValue = invoiceSlno + "~" + itemSlno;

                    // Add item to ListBox_Item
                    ListBox_ItemSlno.Items.Add(new ListItem(itemText, itemValue));
                }
            }
            else if (ddl_Select_ItemRITC.SelectedValue == "1")
            {
                var uniqueRows = dt_GridViewData.AsEnumerable()
                       .GroupBy(row => row["RITCNO"])
                       .Select(group => group.First())
                       .CopyToDataTable();

                ListBox_ItemSlno.Items.Clear();
                foreach (DataRow row in uniqueRows.Rows)
                {
                    string invoiceSlno = row["INVOICE_SLNO"].ToString(); // Assuming INVOICE_SLNO is a string
                    string itemSlno = row["RITCNO"].ToString(); // Assuming ITEM_SLNO is a string

                    string itemText = invoiceSlno + "~" + itemSlno;
                    string itemValue = invoiceSlno + "~" + itemSlno;

                    // Add item to ListBox_Item
                    ListBox_ItemSlno.Items.Add(new ListItem(itemText, itemValue));
                }
            }
        }
    }

    public string Convert_Digit(string val, int digit)
    {
        if (val.Contains("."))
        {
            string[] sp = val.Split('.');
            if (sp[1].Length > digit)
            {
                sp[1] = sp[1].Substring(0, digit);
            }

            val = sp[0] + "." + sp[1];
        }

        return val;
    }

    protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
    {
        con.Open();
        SqlCommand Exlcmd = new SqlCommand("select PDF_JOB_NO as 'JOB NO',PDF_EXP_IMP_NAME as 'EXP IMP NAME',PDF_MODE as MODE,PDF_UPLOAD_COUNT as 'UPLOAD COUNT',PDF_SAVE_COUNT as 'SAVE COUNT',PDF_REMARKS as 'PAGE COUNT',PDF_USER_ID as 'USER',PDF_DATE_TIME as 'DATE TIME',PDF_BRANCH_CODE as 'BRANCH CODE',PDF_WORKING_PERIOD as 'WORKING PERIOD' from PDF_AI_COUNT_DETAILS where PDF_MODE = 'EXE'", con);
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
                    Response.AddHeader("content-disposition", "attachment;filename=EXCEL_AI_CountDetails" + "_" + DateTime.Now + ".xlsx");
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
                            string invoiceSlno = row["INVOICE_SLNO"].ToString(); // Assuming INVOICE_SLNO is a string
                            string itemSlno = row["ITEM_SLNO"].ToString(); // Assuming ITEM_SLNO is a string

                            string itemText = invoiceSlno + "~" + itemSlno;
                            string itemValue = invoiceSlno + "~" + itemSlno;

                            // Add item to ListBox_Item
                            ListBox_ItemSlno.Items.Add(new ListItem(itemText, itemValue));
                        }
                    }
                    else if (ddl_Select_ItemRITC.SelectedValue == "1")
                    {
                        var uniqueRows = filteredTable.AsEnumerable()
                               .GroupBy(row => row["RITCNO"])
                               .Select(group => group.First())
                               .CopyToDataTable();

                        ListBox_ItemSlno.Items.Clear();
                        foreach (DataRow row in uniqueRows.Rows)
                        {
                            string invoiceSlno = row["INVOICE_SLNO"].ToString(); // Assuming INVOICE_SLNO is a string
                            string itemSlno = row["RITCNO"].ToString(); // Assuming ITEM_SLNO is a string

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
                serialNo = Convert.ToInt32(row["INVOICE_SLNO"]);

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
            txtInvoiceNo.Enabled = false;
            txtInvoiceDate.Enabled = false;
            ddlTerms.Enabled = false;
            txtCurrency.Enabled = false;
            txtCountry.Enabled = false;
            txtPort.Enabled = false;
            btn_Inv_Save.Visible = true;
        }
        else
        {
            txtInvoiceNo.Enabled = true;
            txtInvoiceDate.Enabled = true;
            ddlTerms.Enabled = true;
            txtCurrency.Enabled = true;
            txtCountry.Enabled = true;
            txtPort.Enabled = true;
            btn_Inv_Save.Visible = false;
        }
    }

    protected void btn_Inv_Save_Click(object sender, EventArgs e)
    {
        INV_BindgridViewData();
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
                dt_gvew = new DataTable();
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
}