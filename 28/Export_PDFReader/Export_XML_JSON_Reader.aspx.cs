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
using System.Globalization;
using ClosedXML.Excel;
using System.Threading;

public partial class Export_XML_JSON_Reader : ThemeClass
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
    DataTable dt_Temp_Inv = new DataTable();

    DataSet ds_IEC = new DataSet();
    DataSet ds_draw = new DataSet();
    DataSet GetLocalAPIData = new DataSet();
    DataSet ds_API = new DataSet();
    DataSet ds_except = new DataSet();

    public String Xml_Inv;

    public int MAX_ID = 0; int rowIndex = 0; int INVOICE_SLNO = 0;
    public string GENERAL_EXPORT_JOBNO = "";
    public string currentuser;
    public string currentbranch;
    public string Working_Period;
    public string COMPANY_IDD, comp_ConnectionStr, LoginDate, SB_TYPE, JOBNO;

    bool IsValid = true;
    bool IsValidInv = true;

    decimal TotalNetWeight_Mul_INV = 0;

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
        if (!IsPostBack)
        {
            Bind_Clients();
            AUTO_JOBNO();
            txtjobPS.Text = hdn_JOBNO_PS.Value;
            GENERAL_EXPORT_JOBNO = hdn_JOBNO_PS.Value;
        }

        con = new SqlConnection(HttpContext.Current.Session["currentcomp_db"].ToString());
        if (currentuser == "RTS" || currentuser == "s" || currentuser == "k" || currentuser == "Aji")
        {
            ImageButton10.Visible = true;
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
                ddl_ExporterName.DataValueField = "EXPORTER_NAME";
                ddl_ExporterName.DataBind();
            }
        }
        catch (Exception ex)
        {
            ddl_ExporterName.DataBind();
        }

        if (txtBuyer.Text == "")
        {
            txtBuyer.Text = "SAME AS CONSIGNEE";
        }

        Get_SchemeCode();
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

    public void Tbl_Columns()
    {

        //--------Dt_gen------------
        Dt_gen.Columns.Add("EXPORTER_NAME");
        Dt_gen.Columns.Add("BRANCH_NO");
        Dt_gen.Columns.Add("CONSIGNEE_NAME");
        Dt_gen.Columns.Add("CONSIGNEE_ADD1");
        Dt_gen.Columns.Add("CONSIGNEE_ADD2");
        Dt_gen.Columns.Add("CONSIGNEE_ADD3");
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
        Dt_Item.Columns.Add("ITEM_EXPORTER_NAME");
        Dt_Item.Columns.Add("BR_SLNO");

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

            if (ddl_SchemeCode != null && ds_schemeCode != null)
            {
                ddl_SchemeCode.DataSource = ds_schemeCode.Tables[0];
                ddl_SchemeCode.DataTextField = "SCHEME_CODE";
                ddl_SchemeCode.DataValueField = "SCHEME_CODE";
                ddl_SchemeCode.DataBind();

                string selectedSchemeCode = DataBinder.Eval(e.Row.DataItem, "SCHEME_CODE").ToString();
                ddl_SchemeCode.SelectedValue = selectedSchemeCode;
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
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Export XML Upload', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Export XML Upload', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void btnPrevData_Click(object sender, EventArgs e)
    {
        string strFolderPath = "";
        string strImagePath = "";

        try
        {

            string savePath = Server.MapPath("~/Submission/ExportPDFReader/");
            if (Directory.Exists(savePath) == false)
            {
                Directory.CreateDirectory(savePath);
            }

            if (Request.Files.Count > 0 && Request.Files.Count <= 5)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFile uploadedFile = Request.Files[i]; // Access file by index

                    if (uploadedFile != null && uploadedFile.ContentLength > 0)
                    {
                        strFolderPath = Path.Combine(Request.PhysicalApplicationPath, savePath);
                        strImagePath = Path.Combine(strFolderPath, uploadedFile.FileName.ToString());
                        uploadedFile.SaveAs(strImagePath);
                    }

                    Gen_AI_PDF API = new Gen_AI_PDF();
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

                    using (FileStream stream = new FileStream(strImagePath, FileMode.Open, FileAccess.Read))
                    {
                        ds_API.ReadXml(stream);
                    }

                    if (ds_API.Tables[0].Rows.Count > 0 && ds_API.Tables[2].Rows.Count > 0 && ds_API.Tables[4].Rows.Count > 0)
                    {
                        txtExporterName.Text = ds_API.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                        string consigneeName = ds_API.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
                        string buyerName = ds_API.Tables[2].Rows[0]["BUYER_NAME"].ToString();

                        if (consigneeName.Length > 35)
                        {
                            string substring = consigneeName.Substring(0, 35);
                            txtConsigneeName.Text = substring;
                            string buyerSubstring = buyerName.Length > 35 ? buyerName.Substring(0, 35) : buyerName;
                            txtBuyer.Text = buyerSubstring;
                        }
                        else
                        {
                            txtConsigneeName.Text = consigneeName.Replace("Consignee ", "");
                            txtBuyer.Text = buyerName;
                        }

                        if (txtBuyer.Text == "" || txtBuyer.Text == string.Empty || txtBuyer.Text == null)
                        {
                            txtBuyer.Text = "SAME AS CONSIGNEE";
                        }

                        txtNotifyParty.Text = "";
                        txtCountry.Text = ds_API.Tables[0].Rows[0]["COUNTRY_FINAL_DESTINATION"].ToString();
                        txtPort.Text = ds_API.Tables[0].Rows[0]["PORT_OF_DISCHARGE_CODE"].ToString();
                        ddlAdCode.DataSource = ds_API.Tables[0];
                        ddlAdCode.DataTextField = "ADCODE";
                        ddlAdCode.DataValueField = "ADCODE";
                        ddlAdCode.DataBind();
                        txtAccessoryDesc.Text = ds_API.Tables[4].Rows[0]["ACCESSORY_DESC"].ToString();

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

                        ViewState["FREIGHT_CHARGES"] = ds_API.Tables[2].Rows[0]["FREIGHT_CHARGES"].ToString().Replace(",", "");
                        ViewState["INSURANCE_CHARGES"] = ds_API.Tables[2].Rows[0]["INSURANCE_CHARGES"].ToString().Replace(",", "");
                        ViewState["COMMISSION_CHARGES"] = ds_API.Tables[2].Rows[0]["COMMISSION_CHARGES"].ToString().Replace(",", "");
                        ViewState["OTHER_DED_CHARGES"] = ds_API.Tables[2].Rows[0]["OTHER_DEDUCTION_CHARGES"].ToString().Replace(",", "");
                        ViewState["FOB_CHARGES"] = "";

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
                        }

                        for (int ak = 0; ak <= ds_API.Tables[2].Rows.Count - 1; ak++)
                        {
                            INVOICE_SLNO = Convert.ToInt32(ds_API.Tables[2].Rows[ak]["INVOICE_SLNO"].ToString());
                            txtInvoiceNo.Text = ds_API.Tables[2].Rows[ak]["INVOICE_NO"].ToString();
                            txtInvoiceDate.Text = ds_API.Tables[2].Rows[ak]["INVOICE_DATE"].ToString();
                            txtCurrency.Text = Get_Valid_Curr_Name(ds_API.Tables[2].Rows[ak]["INVOICE_CURRENCY"].ToString());
                            string TERMS1 = ds_API.Tables[2].Rows[ak]["TERMS"].ToString().Contains("FOB") ? "FOB" : ds_API.Tables[2].Rows[0]["TERMS"].ToString();
                            txtTerms.Text = "FOB";
                            string InvoiceValue = "";

                            dt_Temp_Inv.Rows.Add(INVOICE_SLNO, txtInvoiceNo.Text, txtInvoiceDate.Text, txtCurrency.Text, txtTerms.Text, InvoiceValue, ViewState["FREIGHT_CHARGES"], ViewState["OTHER_DED_CHARGES"]);

                            ViewState["dt_Invoice"] = dt_Temp_Inv;
                        }

                        string ItemSlNo = "", Item_Desc = "", Item_UnitPrice = "0", QtyCode = "", HSNCode = "", GetAmount = "0", GetQuantity = "0", DBK_UNIT = "", DBK_SL_NO = "", InfoQty = "", Schemecode = "";
                        decimal CALC_InvoiceValue = 0;
                        for (int cc = 0; cc <= ds_API.Tables[4].Rows.Count - 1; cc++)
                        {
                            INVOICE_SLNO = Convert.ToInt32(ds_API.Tables[4].Rows[cc]["INVOICE_SLNO"].ToString());
                            ItemSlNo = ds_API.Tables[4].Rows[cc]["ITEM_SLNO"].ToString();
                            Item_Desc = ds_API.Tables[4].Rows[cc]["ITEM_DESCRIPTION"].ToString();
                            HSNCode = ds_API.Tables[4].Rows[cc]["RITCNO"].ToString();
                            string Check_Item_UnitPrice = ds_API.Tables[4].Rows[cc]["UNIT_PRICE"].ToString().Replace(",", "");

                            if (Check_Item_UnitPrice != "" && Check_Item_UnitPrice != null && Check_Item_UnitPrice != string.Empty)
                            {
                                Item_UnitPrice = Math.Round(Convert.ToDecimal(Check_Item_UnitPrice), 5).ToString("N5").Replace(",", "");
                            }
                            else
                            {
                                Item_UnitPrice = "0";
                            }

                            QtyCode = ds_API.Tables[4].Rows[cc]["ITEM_QTY_CODE"].ToString();
                            GetQuantity = ds_API.Tables[4].Rows[cc]["ITEM_QTY"].ToString().TrimEnd().Replace(",", "").Trim();
                            if (GetQuantity == "")
                            {
                                GetQuantity = "0";
                            }
                            if (Item_UnitPrice != "" && GetQuantity != "")
                            {
                                decimal DEC_AMOUNT = Convert.ToDecimal(GetQuantity) * Convert.ToDecimal(Item_UnitPrice);
                                GetAmount = DEC_AMOUNT.ToString("N5").Replace(",", "");
                                CALC_InvoiceValue = CALC_InvoiceValue + DEC_AMOUNT;
                                if (dt_Temp_Inv.Rows.Count > 0)
                                {
                                    if (cc < ds_API.Tables[4].Rows.Count - 1)
                                    {
                                        int INVOICE_SLNO_NEXT = Convert.ToInt32(ds_API.Tables[4].Rows[cc + 1]["INVOICE_SLNO"].ToString());
                                        if (INVOICE_SLNO != INVOICE_SLNO_NEXT)
                                        {
                                            dt_Temp_Inv.Rows[INVOICE_SLNO - 1]["InvoiceValue"] = CALC_InvoiceValue.ToString();
                                            CALC_InvoiceValue = 0;
                                        }
                                    }
                                    if (cc == ds_API.Tables[4].Rows.Count - 1)
                                    {
                                        dt_Temp_Inv.Rows[INVOICE_SLNO - 1]["InvoiceValue"] = CALC_InvoiceValue.ToString();
                                        CALC_InvoiceValue = 0;
                                    }
                                }
                            }
                            DBK_SL_NO = ds_API.Tables[4].Rows[cc]["DRAWBACK_SLNO"].ToString().TrimEnd();
                            DBK_UNIT = ds_API.Tables[4].Rows[cc]["INFO_UQC"].ToString().TrimEnd();
                            InfoQty = ds_API.Tables[4].Rows[cc]["INFO_MSR"].ToString().TrimEnd().Trim();
                            Schemecode = ds_API.Tables[4].Rows[cc]["ITEM_SCHEME_CODE"].ToString().TrimEnd();
                            if (Schemecode == "")
                            {
                                Schemecode = "00-FREE SHIPPING BILL";
                            }
                            string RewardPoints = ds_API.Tables[4].Rows[cc]["REWARD_POINTS"].ToString().TrimEnd();
                            if (RewardPoints == "")
                            {
                                RewardPoints = "Y";
                            }
                            string EnduseItem = ds_API.Tables[4].Rows[cc]["END_USE_OF_ITEM"].ToString().TrimEnd();
                            string PTA_FTA = ds_API.Tables[4].Rows[cc]["EXPORT_UNDER_PTA_FTA"].ToString().TrimEnd();
                            string IGST_Payment = ds_API.Tables[4].Rows[cc]["IGST_PAYMENT_STATUS"].ToString().TrimEnd();
                            if (IGST_Payment == "")
                            {
                                IGST_Payment = "NA";
                            }
                            string Rodtep_YN = ds_API.Tables[4].Rows[cc]["RODTEP"].ToString().TrimEnd().Replace("NO", "N").Replace("YES", "Y");
                            if (Rodtep_YN == "")
                            {
                                Rodtep_YN = "";
                            }
                            // ✅ FIXED: Use current loop index [cc]
                            string IGST_RATE = ds_API.Tables[4].Rows[cc]["IGST_RATE"].ToString();
                            string ACCESSORY_DESC = ds_API.Tables[4].Rows[cc]["ACCESSORY_DESC"].ToString();

                            dt_gvew.Rows.Add(INVOICE_SLNO, ItemSlNo, Item_Desc.Trim(), GetQuantity, Get_Valid_Qty_Code(QtyCode), Item_UnitPrice, Get_Valid_Curr_Name(txtCurrency.Text.Trim()),
                                GetAmount, InfoQty, "", Schemecode, "N", RewardPoints, Rodtep_YN, "N", EnduseItem, PTA_FTA, IGST_Payment, ACCESSORY_DESC, "", IGST_RATE.Trim(), DBK_SL_NO, DBK_UNIT, HSNCode);


                        }

                        //lbl_loading.Text = "File converted successfully..Click Upload";
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
                            string Get_SchemeCode = dt_gvew.Rows[cd]["SCHEME_CODE"].ToString();

                            ListItem item = ddl_SchemeCode.Items.FindByValue(Get_SchemeCode);
                            if (item == null)
                            {
                                foreach (ListItem li in ddl_SchemeCode.Items)
                                {
                                    if (li.Value.StartsWith(Get_SchemeCode + "-") || li.Text.StartsWith(Get_SchemeCode + "-"))
                                    {
                                        item = li;
                                        break;
                                    }
                                }
                            }
                            if (item != null)
                            {
                                ddl_SchemeCode.ClearSelection();
                                item.Selected = true;
                            }
                        }

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
                                  "Update PDF_AI_COUNT_DETAILS set PDF_UPLOAD_COUNT=('" + PDF_UPLOAD_COUNT + "'+1),PDF_REMARKS= PDF_REMARKS + '1',PDF_USER_ID='" + currentuser + "',PDF_DATE_TIME=GetDate()," +
                            "PDF_STATUS='S',PDF_BRANCH_CODE='" + currentbranch + "',PDF_WORKING_PERIOD='" + Working_Period + "' where PDF_ID=" + PDF_ID + "", con);
                            int result = Ucmd.ExecuteNonQuery();
                        }
                        else
                        {

                            SqlCommand cmd =
                                new SqlCommand(
                                    "insert into PDF_AI_COUNT_DETAILS(PDF_JOB_NO,PDF_EXP_IMP_NAME,PDF_MODE,PDF_UPLOAD_COUNT,PDF_REMARKS,PDF_USER_ID,PDF_DATE_TIME,PDF_STATUS,PDF_BRANCH_CODE,PDF_WORKING_PERIOD) values('" + txtjobPS.Text + "','" +
                                    exp_name + "','EXM','1','1','" + currentuser + "',GetDate(),'S','" + currentbranch + "','" + Working_Period + "')", con);
                            int result = cmd.ExecuteNonQuery();
                        }
                        con.Close();
                    }
                    else
                    {
                        lbl_loading.Text = "Error";
                    }

                    if (gv_ItemPDF.Rows.Count > 0)
                    {
                        ViewState["GridViewData"] = dt_gvew;
                        ViewState["dt_Item"] = dt_gvew;
                        ddl_Select_ItemRITC_SelectedIndexChanged(sender, e);
                    }
                    lblmsg.Text = "";
                }
            }
            else
            {
                if (Request.Files.Count > 5)
                {
                    Alert_msg("Maximum 5 files allowed..!");
                }
                else
                {
                    Alert_msg("Please Upload File :)");
                }
            }
        }
        catch (Exception ex)
        {
            log.makeLog("Message ==> " + ex.Message);
            lblmsg.Text = " Message ==> " + ex.Message + " InnerException ==> " + ex.InnerException + " StackTrace ==>" + ex.StackTrace;
        }
    }

    public bool BindgridViewData()
    {
        if (txtPort.Text != "")
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
        }
        else
        {
            Alert_msg("Port Of Discharge should not be Empty..!");
            IsValid = false;
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
            IsValid = BindgridViewData();
            if (IsValid == true)
            {
                dt_INVOICE = (DataTable)ViewState["dt_Invoice"];
                dt_ITEM = (DataTable)ViewState["dt_Item"];

                string AUTHORIZED_ECONOMIC_OPERATOR_CODE = "", A_E_O_COUNTRY = "", AUTHORIZED_ECONOMIC_OPERATOR = "", ADCODE = "", IGST_PAYMENT = "", IGST_RATE = "", marksnos = "", CONTRCT_NO = "", TYPE_OF_EXPORTER = "";
                string PAYMENT_METHOD = "NA", PERIOD_PAYMENT = "", COMMON_JOBNO_PS = "";
                string STATE_OF_ORIGIN = "", GetInvoiceValue = "", curr = "", TERMS = "", BUYER = "", InvNo = "", invdt = "", InvValue = "", FREIGHT_CHGS = "";
                string DISTRICT_OF_ORIGIN = "", FOB_CHARGES = "", COMMISSION_CHARGES = "", FREIGHT_CHARGES = "", INSURANCE_CHARGES = "", TotalNetWeight = "";

                string[] contract = dss_Insert.Tables[2].Rows[0]["CONTRACT_NO"].ToString().TrimStart().Split(' ', '\t');
                CONTRCT_NO = contract[0];

                PERIOD_PAYMENT = dss_Insert.Tables[2].Rows[0]["PERIOD_PAYMENT"].ToString();
                string[] trms = dss_Insert.Tables[2].Rows[0]["PAYMENT_METHOD"].ToString().Replace("PAYMENT", "").Replace("TRADE CARD", "TRADE").Split(' ', '\t');

                if (trms.Count() > 1)
                {
                    if (trms[0].Contains("TT"))
                    {
                        PAYMENT_METHOD = "NA";
                    }
                    else if (trms[0].Contains("D/A"))
                    {
                        PAYMENT_METHOD = "DA";
                    }
                    else
                    {
                        PAYMENT_METHOD = trms[0].Trim();
                    }
                }
                else
                {
                    PAYMENT_METHOD = dss_Insert.Tables[2].Rows[0]["PAYMENT_METHOD"].ToString();
                    if (PAYMENT_METHOD == "Direct" || PAYMENT_METHOD == "DDP")
                    {
                        PAYMENT_METHOD = "DP";
                    }
                    if (PAYMENT_METHOD == "Advance" || PAYMENT_METHOD == "DAP")
                    {
                        PAYMENT_METHOD = "DA";
                    }
                }

                string state_dist = string.Empty;

                string iec = string.Empty;
                string expName = string.Empty;

                if (ViewState["IEC"] != null)
                    iec = ViewState["IEC"].ToString();

                if (ViewState["exp_name"] != null)
                    expName = ViewState["exp_name"].ToString();

                if (!string.IsNullOrEmpty(iec) && !string.IsNullOrEmpty(expName))
                {
                    state_dist = Get_Valid_State_Name(iec, expName);
                }
                else
                {
                    log.makeLog("ViewState missing - IEC: '" + iec + "', ExpName: '" + expName + "'");
                }

                if (state_dist != "")
                {
                    string[] ss = state_dist.Split('~');

                    STATE_OF_ORIGIN = ss[0];
                    DISTRICT_OF_ORIGIN = ss[1];
                    marksnos = ss[2];
                }
                string state_export = "";

                if (!string.IsNullOrEmpty(STATE_OF_ORIGIN) && STATE_OF_ORIGIN.Contains('-'))
                {
                    string[] sss = STATE_OF_ORIGIN.Split('-');
                    if (sss.Length > 1)
                        state_export = sss[1];
                    else
                        state_export = STATE_OF_ORIGIN;
                }
                else
                {
                    state_export = STATE_OF_ORIGIN;
                }

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
                Final_Port_name = Port_name;
                if (ddlAdCode.SelectedItem != null && !string.IsNullOrEmpty(ddlAdCode.SelectedItem.Text))
                {
                    ADCODE = ddlAdCode.SelectedItem.Text;
                }

                TYPE_OF_EXPORTER = ddlType_Exp.SelectedValue;

                string CONSIGNEE_ADD1 = dss_Insert.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString();
                string CONSIGNEE_ADD2 = dss_Insert.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString();
                string CONSIGNEE_ADD3 = dss_Insert.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString();

                Dt_gen.Rows.Add(ViewState["exp_name"].ToString().Trim(), ViewState["branch_slno"].ToString().Trim(), txtConsigneeName.Text, CONSIGNEE_ADD1, CONSIGNEE_ADD2, CONSIGNEE_ADD3, "", hdfTransport_mode.Value, Session["CUSTOMHOUSE_CODE"].ToString(),
                                 Country_name, Port_name, Country_name, Final_Port_name, state_export, marksnos, ADCODE, TYPE_OF_EXPORTER);

                BUYER = dss_Insert.Tables[2].Rows[0]["WHETHER_BUYER_CONSIGNEE_SAME"].ToString();
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
                GetInvoiceValue = "";

                if (dt_INVOICE.Rows.Count == 1)
                {
                    curr = Get_Valid_Curr_Name(txtCurrency.Text.Trim());
                    invdt = Get_Valid_Date(txtInvoiceDate.Text.Trim());
                    InvNo = "";
                    if (dss_Insert.Tables[2].Rows[0]["INVOICE_NO"].ToString().Contains("+"))
                    {
                        InvNo = ViewState["fileNamewithoutextn"].ToString();
                    }
                    else
                    {
                        InvNo = dss_Insert.Tables[2].Rows[0]["INVOICE_NO"].ToString();
                    }
                    TERMS = "FOB";
                    GetInvoiceValue = dt_INVOICE.Rows[0]["InvoiceValue"].ToString().Trim();

                    Dt_Invoice.Rows.Add("1", InvNo, invdt.Trim(), PAYMENT_METHOD, PERIOD_PAYMENT, GetInvoiceValue, curr, Get_ExchangeRate(curr), CONTRCT_NO,
                   TERMS, BUYER, txtBuyer.Text, AUTHORIZED_ECONOMIC_OPERATOR_CODE, A_E_O_COUNTRY, AUTHORIZED_ECONOMIC_OPERATOR, FOB_CHARGES, FREIGHT_CHARGES, INSURANCE_CHARGES, COMMISSION_CHARGES, "");
                }
                else
                {
                    for (int h = 0; h <= dt_INVOICE.Rows.Count - 1; h++)
                    {
                        InvNo = dt_INVOICE.Rows[h]["InvoiceNo"].ToString();
                        invdt = Get_Valid_Date(dt_INVOICE.Rows[h]["InvoiceDate"].ToString().Trim());
                        curr = Get_Valid_Curr_Name(dt_INVOICE.Rows[h]["Currency"].ToString().Trim());
                        TERMS = dt_INVOICE.Rows[h]["Terms"].ToString().Trim().Replace("FCA", "FOB").Replace("FOC", "FOB");
                        InvValue = dt_INVOICE.Rows[h]["InvoiceValue"].ToString().Trim();
                        FREIGHT_CHGS = dt_INVOICE.Rows[h]["FREIGHT_CHARGES"].ToString().Trim();
                        string OTHER_DED_CHARGES = dt_INVOICE.Rows[h]["OTHER_DED_CHARGES"].ToString().Trim();

                        Dt_Invoice.Rows.Add((h + 1), InvNo, invdt.Trim(), PAYMENT_METHOD, PERIOD_PAYMENT, InvValue, curr, Get_ExchangeRate(curr), CONTRCT_NO,
                            TERMS, BUYER, txtBuyer.Text, AUTHORIZED_ECONOMIC_OPERATOR_CODE, A_E_O_COUNTRY, AUTHORIZED_ECONOMIC_OPERATOR, FOB_CHARGES, FREIGHT_CHGS, INSURANCE_CHARGES, COMMISSION_CHARGES, OTHER_DED_CHARGES);
                    }
                }


                //--------Dt_anx------------
                string ANNEX_SEA_SEAL_TYPE = "Warehouse";
                string ANNEX_SEA_FAC_STUFFED = "N";
                string ANNEX_SEA_SAMPLE_ACCOM = "N";
                string ANNEX_SEA_NATURE_OF_CARGO = "C";
                string ANNEX_SEA_NO_CONTAINERS = "0";
                string ANNEX_SEA_UNIT_MEASUREMENT = "KGS";
                string ANNEX_SEA_PKG_UNIT_CODE = "";

                string ANNEX_AIR_NATURE_OF_CARGO = "P";
                string ANNEX_AIR_GR_UNIT_CODE = "";

                string TotalGrossWeight = "";
                string TotalCarton = "0";
                TotalNetWeight = "";


                if (dss_Insert.Tables.Count > 0 && dss_Insert.Tables[0].Rows.Count > 0)
                {
                    DataRow headerRow = dss_Insert.Tables[0].Rows[0];

                    TotalNetWeight = headerRow["TOTAL_NET_WEIGHT"].ToString().ToLower().Replace("kgs", "").Replace(",", "").Trim();
                    TotalGrossWeight = headerRow["TOTAL_GROSS_WEIGHT"].ToString().ToLower().Replace("kgs", "").Replace(",", "").Trim();

                    string headerCarton = headerRow["TOTAL_CARTON"].ToString().Trim();
                    if (!string.IsNullOrEmpty(headerCarton))
                        TotalCarton = headerCarton;
                }

                if (hdfTransport_mode.Value == "Air")
                {
                    Dt_anx_Air.Rows.Add(ANNEX_AIR_NATURE_OF_CARGO, marksnos, TotalCarton, TotalGrossWeight, TotalNetWeight, ANNEX_AIR_GR_UNIT_CODE);
                }
                else
                {
                    Dt_anx.Rows.Add(ANNEX_SEA_FAC_STUFFED, ANNEX_SEA_SAMPLE_ACCOM, ANNEX_SEA_NATURE_OF_CARGO, marksnos, TotalCarton, ANNEX_SEA_NO_CONTAINERS, ANNEX_SEA_UNIT_MEASUREMENT,
                        ANNEX_SEA_SEAL_TYPE, TotalGrossWeight, TotalNetWeight, ANNEX_SEA_PKG_UNIT_CODE);
                }

                string UNDER_PTA_FTA = "", Item_Qty = "0", Item_UnitPrice = "0", Itemdesc = "", Item_Amount = "", Item_SlNo, InfoQty, Qty_Cd = "", Item_Desc_Customized = "",
                    SCHEME_CODE = "", STR_YES_NO = "", REWARD_YES_NO = "", RODTEP = "", CESS_YN = "", END_USE_OF_ITEM = "", ITEM_ACCESSORIES_DESC = "", DBK_SL_NO = "", DBK_UNIT = "", RITCNO = "", SQC = "", dbk_decl = "", TAXABLE_VALUE = "", IGST_AMT = "", Inv_SlNo = "", ITEM_EXPORTER_NAME = "", BR_SLNO = "";

                string DRAWBACK_SLNO = "", DRAWBACK_DESCRIPTION = "", DRAWBACK_RATE = "", DRAWBACK_VALUE_CAP = "", DRAWBACK_UNIT = "", DRAWBACK_NOOFUNITS = "", STATE_LEVEL_ADV_RATE = "", STATE_LEVEL_ADV_AMT = "", CENTRAL_LEVEL_ADV_RATE = "", CENTRAL_LEVEL_ADV_AMT = "";

                if (txt_Third_Party_Details.Text.Trim().Contains("--"))
                {
                    string[] Tpd = txt_Third_Party_Details.Text.Trim().Replace("--", "^").Split('^');
                    BR_SLNO = Tpd[0];
                    ITEM_EXPORTER_NAME = Tpd[1];
                }
                for (int i = 0; i <= dt_ITEM.Rows.Count - 1; i++)
                {

                    //----common ----
                    Inv_SlNo = dt_ITEM.Rows[i]["INVOICE_SLNO"].ToString().TrimEnd();
                    Item_SlNo = dt_ITEM.Rows[i]["ITEM_SLNO"].ToString().TrimEnd();

                    string GetQTY = dt_ITEM.Rows[i]["ITEM_QTY"].ToString().TrimEnd().Replace(",", "");
                    if (GetQTY != "" && GetQTY != string.Empty)
                    {
                        Item_Qty = GetQTY;
                    }
                    else
                    {
                        Item_Qty = "0";
                    }
                    Qty_Cd = dt_ITEM.Rows[i]["ITEM_QTY_CODE"].ToString().TrimEnd().ToUpper();
                    Item_UnitPrice = dt_ITEM.Rows[i]["ITEM_UNITPRICE"].ToString().TrimEnd();
                    Itemdesc = dt_ITEM.Rows[i]["ITEM_DESC"].ToString().TrimEnd();

                    string GetAmount = dt_ITEM.Rows[i]["ITEM_AMOUNT"].ToString().TrimEnd().Replace(",", "");
                    Item_Amount = GetAmount;
                    InfoQty = dt_ITEM.Rows[i]["INFO_QTY"].ToString().TrimEnd().Replace("N/A", "");
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
                            dbk_decl = dbk_decl.Length > 100 ? dbk_decl.Substring(0, 100) : dbk_decl;
                        }
                    }

                    InfoQty = dt_ITEM.Rows[i]["INFO_QTY"].ToString().TrimEnd().Replace(",", ""); ;
                    TAXABLE_VALUE = "";
                    IGST_AMT = "";

                    Auto.Ename = "Get_CTH_Info_Uqc";
                    Auto.Enamesearch = RITCNO;
                    Auto.Notn_No_Search = RITCNO;
                    DataSet SQC_ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
                    if (SQC_ds.Tables[0].Rows.Count > 0)
                    {
                        SQC = SQC_ds.Tables[0].Rows[0][0].ToString();
                    }

                    //#Item
                    Dt_Item.Rows.Add(Inv_SlNo, InvNo, Item_SlNo, Itemdesc, Item_Qty, Qty_Cd, Item_UnitPrice, Item_Amount, STATE_OF_ORIGIN, DISTRICT_OF_ORIGIN, UNDER_PTA_FTA, InfoQty, IGST_PAYMENT, IGST_RATE, Item_Desc_Customized,
                        SCHEME_CODE, STR_YES_NO, REWARD_YES_NO, RODTEP, CESS_YN, END_USE_OF_ITEM, ITEM_ACCESSORIES_DESC, dbk_decl, DBK_SL_NO, DBK_UNIT, RITCNO, SQC, TAXABLE_VALUE, IGST_AMT, ITEM_EXPORTER_NAME, BR_SLNO);


                    if (DBK_SL_NO != "" && DBK_SL_NO != null && DBK_SL_NO != string.Empty)
                    {
                        Auto.Ename = "DRAWBACK_MASTER_ALL_Excel_Upload";
                        Auto.Enamesearch = DBK_SL_NO;
                        Auto.Notn_No_Search = "";
                        ds_draw = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

                        if (ds_draw.Tables[0].Rows.Count > 0)
                        {
                            for (int a = 0; a <= ds_draw.Tables[0].Rows.Count - 1; a++)
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

                exp_pdf.EXPORTER_NAME = ViewState["exp_name"].ToString().Trim();
                exp_pdf.BRANCH_NO = ViewState["branch_slno"].ToString();
                exp_pdf.JOBNO = GENERAL_EXPORT_JOBNO;
                exp_pdf.JOBNO_PS = COMMON_JOBNO_PS;
                exp_pdf.COMAPANY_ID = COMPANY_IDD;
                exp_pdf.USER_ID = currentuser;
                exp_pdf.WORKINGPERIOD = Working_Period;
                exp_pdf.Branch_Code = currentbranch;
                exp_pdf.flag = "Insert_Desc";
                dss_Insert = exp_pdf.Exp_XML_JSON_Upload_New_XML_AI(Dt_gen, Dt_Item, Dt_DBK, Dt_Invoice, Dt_anx, Dt_anx_Air);

                if (exp_pdf.result == 1)
                {
                    Session["JOBIDexcel"] = dss_Insert.Tables[0].Rows[0][0].ToString();

                    //Alert_msg("XML File Uploaded Successfully..!");
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
                              "Update PDF_AI_COUNT_DETAILS set PDF_SAVE_COUNT=(" + PDF_SAVE_COUNT + "+1),PDF_USER_ID='" + currentuser + "',PDF_DATE_TIME=GetDate()," +
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
        if (curr == "US$" || curr == "US $" || curr == "USDN")
        {
            curr = "USD";
        }

        return curr;
    }

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
        else if (curr == "PIECE(S)" || curr == "PCS." || curr == "PC" || curr == "pcs" || curr == "Pcs")
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
        else if (curr == "MTRS." || curr == "MTRS" || curr == "MTR." || curr.Contains("MTR"))
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
        else if (curr == "PR")
        {
            curr = "PRS";
        }
        else if (curr == "nos" || curr == "ECH" || curr == "Nos")
        {
            curr = "NOS";
        }
        return curr;
    }

    private string Get_Valid_Date(string Dt)
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

    private string Get_Valid_Date1(string Dt)
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

        return "Invalid Date";
    }

    /*public string Get_Valid_State_Name(string IEC, string ExporterName)
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
    }*/

    public string Get_Valid_State_Name(string IEC, string ExporterName)
    {
        string result = "";
        DataSet ds_state = new DataSet();
        DataSet ds_con = new DataSet();

        try
        {
            erm.PDF_PORTNAME = ExporterName;
            erm.PORT_NAME = IEC;
            erm.PORT_CODE = ViewState["branch_slno"] != null ?
                            ViewState["branch_slno"].ToString() : string.Empty;
            erm.COUNTRY_CODE = "";
            erm.Ename = "select_Client_Master_Details";

            ds_state = erm.PDF_PORT_MASTER_Insert_update_Search();

            if (ds_state == null || ds_state.Tables.Count == 0
                || ds_state.Tables[0].Rows.Count == 0)
                return result;

            Auto_Search Auto = new Auto_Search();
            Auto.Ename = "Select_State_District_Itemdetails";
            Auto.Enamesearch = ds_state.Tables[0].Rows[0]["IMP_EXP_ADD4"].ToString();
            Auto.Notn_No_Search = ds_state.Tables[0].Rows[0]["DISTRICT"].ToString();
            ds_con = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

            if (ds_con != null && ds_con.Tables.Count > 1 && ds_con.Tables[0].Rows.Count > 0 && ds_con.Tables[1].Rows.Count > 0)
            {
                result = ds_con.Tables[0].Rows[0]["STATE_NAME"].ToString() + "~" + ds_con.Tables[1].Rows[0]["DISTRICT_NAME"].ToString() + "~" + ds_state.Tables[0].Rows[0]["MARKS_NO"].ToString();
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return result;
    }

    
    protected void btn_bulk_Update_All_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable GridViewData = (DataTable)ViewState["GridViewData"];

            if (gv_ItemPDF.Rows.Count > 0 && GridViewData != null)
            {
                for (int i = 0; i < gv_ItemPDF.Rows.Count; i++)
                {
                    TextBox txtInvSlNo = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtInvSlNo");
                    TextBox txtItemSlNo = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtItemSlNo");
                    string invSlNo = txtInvSlNo != null ? txtInvSlNo.Text : "";
                    string itemSlNo = txtItemSlNo != null ? txtItemSlNo.Text : "";

                    if (ddlSchemeCode.SelectedItem.Text != "")
                    {
                        DropDownList ddl_SchemeCode = (DropDownList)gv_ItemPDF.Rows[i].FindControl("ddl_SchemeCode");
                        if (ddl_SchemeCode != null)
                            ddl_SchemeCode.SelectedValue = ddlSchemeCode.SelectedValue;
                    }
                    
                    if (txtRITCNo.Text != "")
                    {
                        TextBox txt_RITCNo = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_RITCNo");
                        if (txt_RITCNo != null)
                            txt_RITCNo.Text = txtRITCNo.Text;
                    }

                   if (ddl_STR_YN.SelectedItem.Text != "")
                    {
                        DropDownList ddl_STRYN = (DropDownList)gv_ItemPDF.Rows[i].FindControl("ddl_STRYN");
                        if (ddl_STRYN != null)
                            ddl_STRYN.SelectedValue = ddl_STR_YN.SelectedValue;
                    }

                    if (ddlRewardPoints.SelectedValue != "")
                    {
                        DropDownList ddl_Reward_Points = (DropDownList)gv_ItemPDF.Rows[i].FindControl("ddl_Reward_Points");
                        if (ddl_Reward_Points != null)
                            ddl_Reward_Points.SelectedValue = ddlRewardPoints.SelectedValue;
                    }
                   
                    if (ddl_Rodtep_YN.SelectedItem.Text != "")
                    {
                        DropDownList ddl_RodtepYN = (DropDownList)gv_ItemPDF.Rows[i].FindControl("ddl_RodtepYN");
                        if (ddl_RodtepYN != null)
                            ddl_RodtepYN.SelectedValue = ddl_Rodtep_YN.SelectedValue;
                    }
                    
                    if (ddl_Cess_YN.SelectedItem.Text != "")
                    {
                        DropDownList ddl_CessYN = (DropDownList)gv_ItemPDF.Rows[i].FindControl("ddl_CessYN");
                        if (ddl_CessYN != null)
                            ddl_CessYN.SelectedValue = ddl_Cess_YN.SelectedValue;
                    }
                                        
                    if (txtEnduseItem.Text != "")
                    {
                        TextBox txtEndUseOfItems = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtEndUseOfItems");
                        if (txtEndUseOfItems != null)
                            txtEndUseOfItems.Text = txtEnduseItem.Text;
                    }
                    
                    if (txt_PTA_FTA.Text != "")
                    {
                        TextBox txtUnderPTA = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtUnderPTA");
                        if (txtUnderPTA != null)
                            txtUnderPTA.Text = txt_PTA_FTA.Text;
                    }
                   
                    TextBox txtIGSTRate = (TextBox)gv_ItemPDF.Rows[i].FindControl("txt_IGSTRate");
                    DropDownList ddl_IGSTPayment = (DropDownList)gv_ItemPDF.Rows[i].FindControl("ddl_IGSTPayment");

                    if (ddl_IGSTPayment != null)
                    {
                        if (ddl_IGST_Payment.SelectedValue != "")
                        {
                            ddl_IGSTPayment.SelectedValue = ddl_IGST_Payment.SelectedValue;

                            if (txtIGSTRate != null)
                            {
                                string currentPaymentStatus = ddl_IGSTPayment.SelectedValue;
                                if (currentPaymentStatus != "P")
                                {
                                    txtIGSTRate.Text = "";
                                    txtIGSTRate.Enabled = false;
                                }
                                else
                                {
                                    txtIGSTRate.Enabled = true;
                                    if (txt_IGST_Rate.Text.Trim() != "")
                                        txtIGSTRate.Text = txt_IGST_Rate.Text;
                                }
                            }
                        }                        
                    }

                    if (txt_Drawback_SLNo.Text != "")
                    {
                        TextBox txtDrawbackSLNo = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtDrawback_SLNo");
                        if (txtDrawbackSLNo != null)
                            txtDrawbackSLNo.Text = txt_Drawback_SLNo.Text;
                    }

                    if (txt_DBK_Unit.Text != "")
                    {
                        TextBox txtDBKUnit = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtDBK_Unit");
                        if (txtDBKUnit != null)
                            txtDBKUnit.Text = txt_DBK_Unit.Text;
                    }
                   
                    foreach (DataRow dr in GridViewData.Rows)
                    {
                        if (dr["INVOICE_SLNO"].ToString() == invSlNo &&
                            dr["ITEM_SLNO"].ToString() == itemSlNo)
                        {
                            if (ddlSchemeCode.SelectedItem.Text != "")
                                dr["SCHEME_CODE"] = ddlSchemeCode.SelectedValue;
                            if (txtRITCNo.Text != "")
                                dr["RITCNO"] = txtRITCNo.Text;
                            if (ddl_STR_YN.SelectedItem.Text != "")
                                dr["STR_YES_NO"] = ddl_STR_YN.SelectedValue;
                            if (ddlRewardPoints.SelectedValue != "")
                                dr["REWARD_YES_NO"] = ddlRewardPoints.SelectedValue;
                            if (ddl_Rodtep_YN.SelectedItem.Text != "")
                                dr["RODTEP"] = ddl_Rodtep_YN.SelectedValue;
                            if (ddl_Cess_YN.SelectedItem.Text != "")
                                dr["CESS_YN"] = ddl_Cess_YN.SelectedValue;
                            if (txtEnduseItem.Text != "")
                                dr["END_USE_OF_ITEM"] = txtEnduseItem.Text;
                            if (txt_PTA_FTA.Text != "")
                                dr["UNDER_PTA_FTA"] = txt_PTA_FTA.Text;
                            
                            if (ddl_IGST_Payment.SelectedValue != "")
                            {
                                string payStatus = ddl_IGSTPayment != null
                                    ? ddl_IGSTPayment.SelectedValue
                                    : dr["IGST_PAYMENT"].ToString();
                                dr["IGST_PAYMENT"] = payStatus;
                                dr["IGST_RATE"] = (payStatus != "P") ? ""
                                               : (txt_IGST_Rate.Text.Trim() != ""
                                                  ? txt_IGST_Rate.Text
                                                  : dr["IGST_RATE"].ToString());
                            }

                            if (txt_Drawback_SLNo.Text != "")
                                dr["DBK_SL_NO"] = txt_Drawback_SLNo.Text;
                            if (txt_DBK_Unit.Text != "")
                                dr["DBK_UNIT"] = txt_DBK_Unit.Text;
                            break;
                        }
                    }
                }
                
                ViewState["GridViewData"] = GridViewData;
                ViewState["dt_Item"] = GridViewData;
                
                gv_ItemPDF.DataSource = GridViewData;
                gv_ItemPDF.DataBind();
                UpdatePanel1.Update();                

                ddlSchemeCode.SelectedIndex = 0;
                txtRITCNo.Text = "";
                ddl_STR_YN.SelectedValue = "No";
                ddlRewardPoints.SelectedIndex = 0;
                ddl_Rodtep_YN.SelectedValue = "Yes";
                ddl_Cess_YN.SelectedValue = "No";
                txtEnduseItem.Text = "";
                txt_PTA_FTA.Text = "";
                ddl_IGST_Payment.SelectedIndex = 0;
                txt_IGST_Rate.Text = "";
                txt_Drawback_SLNo.Text = "";
                txt_DBK_Unit.Text = "";

            }

        }
        catch (Exception ex)
        {
            log.makeLog("Message ==> " + ex.Message);
            lblmsg.Text = "Message ==> " + ex.Message + " InnerException ==> " + ex.InnerException;
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
                    ViewState["dt_Item"] = GridViewData; 
                }
            }
            else
            {
                Alert_msg("Please Select Item...!");
            }

            ddlSchemeCode.SelectedIndex = 0;
            txtRITCNo.Text = "";
            ddl_STR_YN.SelectedValue = "No";
            ddlRewardPoints.SelectedIndex = 0;
            ddl_Rodtep_YN.SelectedValue = "Yes";
            ddl_Cess_YN.SelectedValue = "No";
            txtEnduseItem.Text = "";
            txt_PTA_FTA.Text = "";
            ddl_IGST_Payment.SelectedIndex = 0;
            txt_IGST_Rate.Text = "";
            txt_Drawback_SLNo.Text = "";
            txt_DBK_Unit.Text = "";
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
            txtTerms.Enabled = false;
            txtCurrency.Enabled = false;
            txtCountry.Enabled = false;
            txtPort.Enabled = false;
            btn_Inv_Save.Visible = true;
        }
        else
        {
            txtInvoiceNo.Enabled = true;
            txtInvoiceDate.Enabled = true;
            txtTerms.Enabled = true;
            txtCurrency.Enabled = true;
            txtCountry.Enabled = true;
            txtPort.Enabled = true;
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

    protected void btn_Inv_Save_Click(object sender, EventArgs e)
    {
        INV_BindgridViewData();
    }
}