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
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;


public partial class Export_PDF_Reader_New_AI : ThemeClass
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
    DataSet ds_get_data = new DataSet();

    DataTable Dt_gen = new DataTable();
    DataTable Dt_Invoice = new DataTable();
    DataTable Dt_Item = new DataTable();
    DataTable Dt_DBK = new DataTable();
    DataTable Dt_anx = new DataTable();
    DataTable Dt_anx_Air = new DataTable();
    DataTable dt_gvew = new DataTable();
    DataTable dt_Temp_Inv = new DataTable();
    DataTable dt_Temp_Con = new DataTable();

    DataSet ds_IEC = new DataSet();

    DataSet ds_draw = new DataSet();
    DataSet GetLocalAPIData = new DataSet();
    DataSet ds_API = new DataSet();
    DataSet ds_except = new DataSet();
    DataSet ds_Annex_dt = new DataSet();
    Page_Count_Details ds_Page = new Page_Count_Details();

    public String Xml_Inv;
    public string HSCodeJson = "[]";
    public int MAX_ID = 0; int rowIndex = 0; int INVOICE_SLNO = 0; int Container_No = 0;
    public string GENERAL_EXPORT_JOBNO = "";
    public string currentuser;
    public string currentbranch;
    public string Working_Period;
    public string COMPANY_IDD, comp_ConnectionStr, LoginDate, SB_TYPE, JOBNO, Upload_Count, Upload_page_Count, Upload_Error_Count;
    public string DBK_SL_NO_Brakes = "", DBK_UNIT_Brakes = "", HSNCode_Brakes="";
    bool IsValid = true;
    bool IsValidInv = true;

    public string RODTEP { get; set; }

    decimal TotalNetWeight_Mul_INV = 0; decimal TotalGrossWeight_Mul_INV = 0; decimal TotalCarton_Mul_INV = 0;

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

        if (COMPANY_IDD == "816" || COMPANY_IDD == "1509")
        {
            lbl_Third_Party_Details.Visible = true;
            txt_Third_Party_Details.Visible = true;
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
                ddl_ExporterName.DataValueField = "EXPORTER_NAME";
                ddl_ExporterName.Items.Add("");
                ddl_ExporterName.DataBind();
                //ddl_ExporterName.Items.Insert(0, new ListItem("", ""));
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
        Dropdownterms();
    }

    public void Dropdownterms()
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
        Dt_gen.Columns.Add("CONSIGNEE_ADD1");
        Dt_gen.Columns.Add("CONSIGNEE_ADD2");
        Dt_gen.Columns.Add("CONSIGNEE_ADD3");
        Dt_gen.Columns.Add("CONSIGNEE_ADD4");
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
        Dt_anx_Air.Columns.Add("ANNEX_AIR_UNIT_CODE");

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
        Dt_Invoice.Columns.Add("PACKMISC_CHARGES");
        Dt_Invoice.Columns.Add("THIRDPARTY_NAME");
        Dt_Invoice.Columns.Add("THIRDPARTY_ADD1");
        Dt_Invoice.Columns.Add("THIRDPARTY_ADD2");
        Dt_Invoice.Columns.Add("THIRDPARTY_CITY");

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

            if (Connection.COMPANYID() == "517" || COMPANY_IDD == "2118" || COMPANY_IDD == "293" || COMPANY_IDD == "3352")
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
            else if (Connection.COMPANYID() == "1509")
            {
                TextBox txtItemQty = e.Row.FindControl("txtItemQty") as TextBox;
                TextBox txtQtyCode = e.Row.FindControl("txtQtyCode") as TextBox;

                txtItemQty.Enabled = true;
                txtQtyCode.Enabled = true;
            }



            if (ViewState["exp_name"].ToString() != "BRAKES INDIA PRIVATE LIMITED")
            {

                List<string> hsList = new List<string>();

                if (ds_get_data != null && ds_get_data.Tables.Count > 0 && ds_get_data.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds_get_data.Tables[0].Rows.Count; i++)
                    {
                        string HSNCode = ds_get_data.Tables[0].Rows[0]["RITC_NO"].ToString();
                        if (!string.IsNullOrEmpty(HSNCode))
                        {
                            hsList.Add(HSNCode);
                        }
                    }
                }
                HSCodeJson = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(hsList);
                TextBox txt_CTH_box = e.Row.FindControl("txt_RITCNo") as TextBox;
                if (txt_CTH_box != null)
                {
                    string rowCthList = "[]";
                    try
                    {
                        DataRowView drv = e.Row.DataItem as DataRowView;
                        if (drv != null
                            && drv.Row.Table.Columns.Contains("CTH_List")
                            && drv["CTH_List"] != DBNull.Value
                            && !string.IsNullOrEmpty(drv["CTH_List"].ToString()))
                        {
                            rowCthList = drv["CTH_List"].ToString();
                        }
                    }
                    catch { rowCthList = "[]"; }
                    // Set as data attribute so JavaScript can read it
                    txt_CTH_box.Attributes["data-cth-list"] = rowCthList;

                    // Count how many CTH values this row has
                    var cthArr = new System.Web.Script.Serialization.JavaScriptSerializer()
                                     .Deserialize<List<string>>(rowCthList);
                    int cthCount = cthArr != null ? cthArr.Count : 0;

                    // Set mode: "single", "multi", "empty"
                    if (cthCount == 1)
                        txt_CTH_box.Attributes["data-cth-mode"] = "single";
                    else if (cthCount > 1)
                        txt_CTH_box.Attributes["data-cth-mode"] = "multi";
                    else
                        txt_CTH_box.Attributes["data-cth-mode"] = "empty";
                }
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
        ViewState["exp_name_con"] = "";

        try
        {
            string savePath = Server.MapPath("~/Submission/ExportPDFReader/");
            if (Directory.Exists(savePath) == false)
            {
                Directory.CreateDirectory(savePath);
            }

            int FileSetLimit = 5;
            if (COMPANY_IDD == "2118" || COMPANY_IDD == "293")
            {
                FileSetLimit = 15;
            }
            else if (COMPANY_IDD == "829")
            {
                FileSetLimit = 30;
            }
            else if (COMPANY_IDD == "6002")
            {
                FileSetLimit = 40;
            }
            if (Request.Files.Count > 0 && Request.Files.Count <= FileSetLimit)
            {
                int FileUploadCount = Request.Files.Count;
                ViewState["FileUploadCount"] = FileUploadCount;

                Upload_Count = "1";
                Upload_page_Count = "1";
                Upload_Error_Count = "1";

                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFile uploadedFile = Request.Files[i]; // Access file by index

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

                    string API_Output = "";
                    Gen_AI_PDF API = new Gen_AI_PDF();
                    string exp_name = "", branch_slno = "", EXP_PdfClientName = "";
                    if (ddl_ExporterName.SelectedValue.Contains("--"))
                    {
                        string[] sp = ddl_ExporterName.SelectedValue.Replace("--", "^").Split('^');
                        branch_slno = sp[0];
                        exp_name = sp[1];

                        ViewState["branch_slno"] = branch_slno;
                        ViewState["exp_name"] = exp_name;
                        Session["exp_name"] = exp_name;
                        Session["AI_branch_slno"] = branch_slno;

                        EXP_PdfClientName = Get_PdfClientName(exp_name, branch_slno);
                        Session["EXP_PdfClientName"] = EXP_PdfClientName;
                    }

                    if ((COMPANY_IDD == "1" || COMPANY_IDD == "816" || COMPANY_IDD == "2099"))//&& exp_name != "INDOFIL INDUSTRIES LIMITED"
                    {
                        string FilenameWithOutExtension = Path.GetFileNameWithoutExtension(uploadedFile.FileName);
                        ds_API = API.Get_AccessToken_Invoice(GetLocalAPIData, Server.MapPath("~/Submission/ExportPDFReader/Local_Test/" + FilenameWithOutExtension + ".txt"));
                    }
                    else
                    {
                        API_Output = API.Get_AccessToken_Invoice_Upload(strImagePath, txtjobPS.Text);
                        int pdfId = PageCount_log(PdfStatus.PREVIEW_INITIATED, hd_PageCount.Value);
                        ViewState["Pdf_Id"] = pdfId.ToString();
                        ds_API = JsonConvert.DeserializeObject<DataSet>(API_Output);
                    }
                    if (ds_API.Tables[0].Rows.Count > 0 && ds_API.Tables[1].Rows.Count > 0)
                    {
                        if (ds_API.Tables[0].Rows[0]["Status"].ToString() == "Success" || ds_API.Tables[0].Rows[0]["Status"].ToString() == "success")
                        {
                            if (exp_name == "JCB INDIA LIMITED NEW")
                            {
                                exp_name = "JCB INDIA LIMITED";
                                ViewState["exp_name"] = exp_name;
                            }

                            txtExporterName.Text = ds_API.Tables[0].Rows[0]["ExporterName"].ToString();
                            string consigneeName = ds_API.Tables[0].Rows[0]["ConsigneeName"].ToString();
                            string buyerName = ds_API.Tables[0].Rows[0]["BuyerName"].ToString().Replace("”", "''").Replace("“", "''");

                            if (consigneeName.Length > 100)
                            {
                                string substring = consigneeName.Substring(0, 100);
                                txtConsigneeName.Text = substring;
                            }
                            else
                            {
                                txtConsigneeName.Text = consigneeName.Replace("Consignee ", "");
                            }

                            if (!string.IsNullOrEmpty(txtBuyer.Text.Trim()))
                            {
                                if (buyerName.Length > 35)
                                {
                                    string buyerSubstring = buyerName.Length > 35 ? buyerName.Substring(0, 35) : buyerName;
                                    txtBuyer.Text = buyerSubstring;
                                }
                                else
                                {
                                    txtBuyer.Text = buyerName;
                                }
                            }
                            else
                            {
                                txtBuyer.Text = "SAME AS CONSIGNEE";
                            }

                            txtNotifyParty.Text = ds_API.Tables[0].Rows[0]["NotifyPartyName"].ToString();
                            txtCountry.Text = ds_API.Tables[0].Rows[0]["CountryOfDischarge"].ToString();
                            txtPort.Text = ds_API.Tables[0].Rows[0]["PortOfDischarge"].ToString();

                            string Country_name = Get_Valid_Country_Name(txtCountry.Text.Trim());
                            string Port_name = "";
                            if (Country_name.Contains('-'))
                            {
                                string[] county_code = Country_name.Split('-');
                                Country_name = county_code[0];
                                Port_name = Get_Valid_Port_Name_Code(txtPort.Text.Trim(), county_code[1]);
                                if (Port_name.Contains('-'))
                                {
                                    txtPort.Text = Port_name;
                                }
                            }

                            string IEC_Value = ds_API.Tables[0].Rows[0]["IEC"].ToString();
                            if (COMPANY_IDD != "829")
                            {
                                ViewState["IEC"] = IEC_Value;
                            }
                            else
                            {
                                ViewState["IEC"] = "";
                            }
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

                            ViewState["FREIGHT_CHARGES"] = ds_API.Tables[0].Rows[0]["Freight"].ToString().Replace(",", "").Replace(" ", "");
                            ViewState["INSURANCE_CHARGES"] = ds_API.Tables[0].Rows[0]["Insurance"].ToString().Replace(",", "").Replace(" ", "");
                            ViewState["COMMISSION_CHARGES"] = ds_API.Tables[0].Rows[0]["Commission"].ToString().Replace(",", "").Replace(" ", "");
                            ViewState["FOB_CHARGES"] = ds_API.Tables[0].Rows[0]["Discount"].ToString().Replace(",", "");
                            ViewState["PACKMISC_CHARGES"] = ds_API.Tables[0].Rows[0]["Packingcharges"].ToString().Replace(",", "");
                            ViewState["OTHER_DED_CHARGES"] = ds_API.Tables[0].Rows[0]["OtherDed"].ToString().Replace(",", "");


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
                                dt_gvew.Columns.Add("CTH_List", typeof(string));


                                dt_Temp_Con.Columns.Add("ANNEX_SEA_CON_CONTAINERNO");
                                dt_Temp_Con.Columns.Add("ANNEX_SEA_CON_SIZE");
                                dt_Temp_Con.Columns.Add("ANNEX_SEA_CON_EXCISE_SEALNO");
                                dt_Temp_Con.Columns.Add("ANNEX_SEA_CON_SEAL_DATE");
                                dt_Temp_Con.Columns.Add("ANNEX_SEA_CON_TYPE");
                                dt_Temp_Con.Columns.Add("ANNEX_SEA_CON_SEALTYPE_INDICATOR");
                            }

                            for (int ak = 0; ak <= ds_API.Tables[0].Rows.Count - 1; ak++)
                            {
                                txtInvoiceNo.Text = ds_API.Tables[0].Rows[0]["InvoiceNo"].ToString();
                                txtInvoiceDate.Text = ds_API.Tables[0].Rows[0]["InvoiceDate"].ToString();
                                txtCurrency.Text = Get_Valid_Curr_Name(ds_API.Tables[0].Rows[0]["Currency"].ToString());
                                string TERMS1 = ds_API.Tables[0].Rows[0]["Terms"].ToString().Contains("FOB") ? "FOB" : ds_API.Tables[0].Rows[0]["Terms"].ToString();
                                try
                                {
                                    string terms = TERMS1.Replace("C&F", "CF").Replace("CFR", "CF").Replace("C & F", "CF").Replace("FOC", "FOB").Replace("FCA", "FOB").Replace("DAP", "CIF").Replace("CI&F", "CIF").Replace("C&I", "CI").Replace("DDP", "CIF").Replace("EXW", "FOB").Replace("EX WORKS", "FOB");
                                    ddlTerms.Text = terms;
                                }
                                catch
                                {
                                    ddlTerms.Text = "FOB";
                                }

                                string InvoiceValue = ds_API.Tables[0].Rows[0]["InvoiceValue"].ToString().Replace(",", "");

                                dt_Temp_Inv.Rows.Add(INVOICE_SLNO, txtInvoiceNo.Text, txtInvoiceDate.Text, txtCurrency.Text, ddlTerms.Text, InvoiceValue, ViewState["FREIGHT_CHARGES"], ViewState["INSURANCE_CHARGES"], ViewState["OTHER_DED_CHARGES"]);

                                ViewState["dt_Invoice"] = dt_Temp_Inv;
                            }

                            if (ds_API.Tables.Count > 2 && ds_API.Tables[2].Rows.Count > 0)
                            {
                                for (int ka = 0; ka <= ds_API.Tables[2].Rows.Count - 1; ka++)
                                {
                                    string Containerslno = ds_API.Tables[2].Rows[ka]["Containerslno"].ToString();
                                    string ContainerNo = ds_API.Tables[2].Rows[ka]["ContainerNo"].ToString().Replace("-", "").Replace(" ", "");
                                    string ContainerSealDate = ds_API.Tables[2].Rows[ka]["ContainerSealDate"].ToString();
                                    string ANNEX_SEA_CON_TYPE = "";
                                    string ANNEX_SEA_CON_SEALTYPE_INDICATOR = "";

                                    if (!string.IsNullOrWhiteSpace(Containerslno))
                                    {
                                        ds_Annex_dt = Get_Default_Annexure_Details(exp_name, branch_slno);
                                        if (ds_Annex_dt != null && ds_Annex_dt.Tables.Count > 0 && ds_Annex_dt.Tables[0].Rows.Count > 0)
                                        {
                                            ANNEX_SEA_CON_TYPE = ds_Annex_dt.Tables[0].Rows[0]["ANNEX_SEA_CON_TYPE"].ToString();
                                            ANNEX_SEA_CON_SEALTYPE_INDICATOR = ds_Annex_dt.Tables[0].Rows[0]["ANNEX_SEA_CON_SEALTYPE_INDICATOR"].ToString();
                                        }
                                    }
                                    if (ContainerSealDate != "" && ContainerSealDate != null)
                                    {
                                        //if (COMPANY_IDD == "2118")
                                        //{
                                        //    ContainerSealDate = Get_Valid_Date1(ds_API.Tables[2].Rows[ka]["ContainerSealDate"].ToString());
                                        //}
                                        //else
                                        //{
                                        //    ContainerSealDate = Get_Valid_Date(ds_API.Tables[2].Rows[ka]["ContainerSealDate"].ToString());
                                        //}
                                        ContainerSealDate = Get_Valid_Date(ds_API.Tables[2].Rows[ka]["ContainerSealDate"].ToString());
                                    }
                                    string ContainerSealNo = ds_API.Tables[2].Rows[ka]["ContainerSealNo"].ToString().Replace("¡", "i").Replace(" ", "");
                                    string ContainerSize = ds_API.Tables[2].Rows[ka]["ContainerSize"].ToString().Replace("1", "").Replace("x", "").Replace("'", "").Replace(" ", "").Replace("1x 40'", "40").Replace("20'", "20");
                                    if (!string.IsNullOrEmpty(ContainerSize) && COMPANY_IDD == "816") ANNEX_SEA_CON_TYPE = ContainerSize == "40" ? "HC" : ContainerSize == "20" ? "GP" : ANNEX_SEA_CON_TYPE;
                                    if (!string.IsNullOrWhiteSpace(ContainerNo) && !string.IsNullOrWhiteSpace(Containerslno))
                                    {
                                        dt_Temp_Con.Rows.Add(ContainerNo, ContainerSize, ContainerSealNo, ContainerSealDate, ANNEX_SEA_CON_TYPE, ANNEX_SEA_CON_SEALTYPE_INDICATOR);
                                    }
                                    ViewState["dt_ContainerDetails"] = dt_Temp_Con;
                                }
                            }

                            string Item_Desc = "", Item_UnitPrice = "", QtyCode = "", HSNCode = "", GetAmount = "", GetQuantity = "",
                                  DBK_UNIT = "", DBK_SL_NO = "", IGST_RATE = "", IGSTPayStatus = "NA", EndUseOfItems = "", UnderPTA = "", SchemeCode = "00-FREE SHIPPING BILL", NetWeight = "", Info_Msr = "", ItemQTYCode = "", ExtraItemDesc = "";

                            for (int cc = 0; cc <= ds_API.Tables[1].Rows.Count - 1; cc++)
                            {
                                Item_Desc = ds_API.Tables[1].Rows[cc]["ItemDesc"].ToString();
                                HSNCode = ds_API.Tables[1].Rows[cc]["HSNCode"].ToString();
                                if (HSNCode.Length > 8)
                                {
                                    string substring = HSNCode.Substring(0, 8);
                                    HSNCode = substring;
                                }
                                Item_UnitPrice = ds_API.Tables[1].Rows[cc]["Rate"].ToString().Replace(",", "");
                                Info_Msr = ds_API.Tables[1].Rows[cc]["InfoQty"].ToString().Replace(",", "");//New
                                NetWeight = ds_API.Tables[1].Rows[cc]["NetWeight"].ToString().Replace(",", "");//New
                                QtyCode = ds_API.Tables[0].Rows[0]["QtyCode"].ToString();//New
                                ItemQTYCode = ds_API.Tables[1].Rows[cc]["ItemQTYCode"].ToString();//New
                                ExtraItemDesc = ds_API.Tables[1].Rows[cc]["ExtraItemDesc"].ToString();//New

                                if (!string.IsNullOrEmpty(ItemQTYCode.Trim()))
                                {
                                    QtyCode = ItemQTYCode;
                                }

                                if (string.IsNullOrEmpty(QtyCode.Trim()))
                                {
                                    QtyCode = "NOS";
                                }

                                if (COMPANY_IDD == "816")
                                {
                                    if (ExtraItemDesc.Contains("SET"))
                                    {
                                        QtyCode = "SET";
                                    }
                                    else if (ExtraItemDesc.Contains("FITTED"))
                                    {
                                        QtyCode = "PCS";
                                    }
                                    else if (ExtraItemDesc.Contains("PILLOW COVER"))
                                    {
                                        QtyCode = "PRS";
                                    }
                                }
                                else if (COMPANY_IDD == "2118")
                                {
                                    if (exp_name.ToUpper() == "JCB INDIA LIMITED")
                                    {
                                        Item_Desc = ExtraItemDesc + " - " + Item_Desc;
                                        EndUseOfItems = "GNX200";
                                        UnderPTA = "NCPTI";
                                    }
                                    else
                                    {
                                        Item_Desc = ExtraItemDesc + " " + Item_Desc;
                                    }
                                }
                                else if (COMPANY_IDD == "579" || COMPANY_IDD == "3305" || exp_name == "MJ EXPORTS" || exp_name == "MAGELLAN AEROSPACE (BANGALORE) PRIVATE LIMITED" || exp_name == "MALLOW INTERNATIONAL" || exp_name == "LEO PRIMECOMP PVT LTD.")
                                {
                                    Item_Desc = ExtraItemDesc + " " + Item_Desc;
                                }
                                else if (exp_name == "EATON INDUSTRIAL PRODUCTS PRIVATE LIMITED-EATON" || exp_name == "EATON INDUSTRIAL PRODUCTS PRIVATE LIMITED" || exp_name == "RAKON INDIA PRIVATE LIMITED")
                                {
                                    Item_Desc = Item_Desc + " " + ExtraItemDesc;
                                    Info_Msr = ds_API.Tables[0].Rows[0]["TotalNetWeight"].ToString();
                                }
                                else if (exp_name == "TEXPORT SYNDICATE PRIVATE LIMITED")
                                {
                                    string Get_SchemeCode = ds_API.Tables[0].Rows[0]["SchemeCode"].ToString();
                                    if (string.IsNullOrEmpty(Get_SchemeCode))
                                    {
                                        SchemeCode = "00-FREE SHIPPING BILL";
                                    }
                                    else
                                    {
                                        SchemeCode = Get_SchemeCode;
                                    }
                                }
                                else if (exp_name == "STRIDES PHARMA SCIENCE LIMITED")
                                {
                                    EndUseOfItems = "DCH400";
                                    SchemeCode = "21-EOU/EPZ/SEZ/EHTP/STP";
                                    IGSTPayStatus = "LUT";
                                    UnderPTA = "NCPTI";
                                    QtyCode = "KGS";
                                }

                               
                                // Maintain the below condition - LIZMA
                                if (Item_Desc.ToString() == "HANGER COST" || Item_Desc.ToString() == "GOODS ARE PACKED WITH HANGER")
                                {
                                    Item_Desc = "HANGER";
                                    if (ds_API.Tables[1].Rows[cc]["InfoUnitPrice"].ToString() != "")
                                    {
                                        Item_UnitPrice = ds_API.Tables[1].Rows[cc]["InfoUnitPrice"].ToString();
                                    }
                                }
                                else if (Item_Desc.ToString().Contains("WITH HANGER"))
                                {
                                    string splitword = "WITH HANGER";
                                    Item_Desc = Item_Desc.ToString().Substring(0, Item_Desc.ToString().IndexOf(splitword));
                                }
                                else
                                {
                                }

                                //#Item QTY/UNIT/AMT
                                GetAmount = SafeNumber(ds_API.Tables[1].Rows[cc]["Amount"]);
                                GetQuantity = SafeNumber(ds_API.Tables[1].Rows[cc]["Quantity"]);

                                if (COMPANY_IDD == "1509")
                                {
                                    QtyCode = "KGS";
                                    if (GetAmount != "" && GetQuantity != "")
                                    {
                                        decimal Cal_Item_UnitPrice = Convert.ToDecimal(GetAmount) / Convert.ToDecimal(GetQuantity);
                                        Item_UnitPrice = Cal_Item_UnitPrice.ToString("N5").Replace(",", "");
                                    }
                                }

                              
                                else if (COMPANY_IDD == "470")
                                {
                                    Item_Desc = Item_Desc + " " + ExtraItemDesc + " (DTLS AS PER INV,PL)";
                                    decimal Get_Item_UnitPrice = Convert.ToDecimal(GetAmount) / Convert.ToDecimal(GetQuantity);
                                    Item_UnitPrice = Get_Item_UnitPrice.ToString("N5").Replace(",", "");
                                }
                                else if (exp_name == "BAETTR INDIA PRIVATE LIMITED")
                                {
                                    Item_Desc = Item_Desc + " - " + ExtraItemDesc;
                                }
                                else if (COMPANY_IDD == "139")
                                {
                                    decimal Get_Item_UnitPrice = Convert.ToDecimal(GetAmount) / Convert.ToDecimal(GetQuantity);
                                    Item_UnitPrice = Get_Item_UnitPrice.ToString("N5").Replace(",", "");
                                    EndUseOfItems = "GNX200";
                                    SchemeCode = "21-EOU/EPZ/SEZ/EHTP/STP";
                                    IGSTPayStatus = "LUT";
                                }
                                else if (exp_name == "MOTHER INDIA FORMING PRIVATE LIMITED")
                                {
                                    EndUseOfItems = "GNX200";
                                    SchemeCode = "43-DRAWBACK AND ZERO DUTY EPCG";
                                    IGSTPayStatus = "LUT";
                                    UnderPTA = "NCPTA";
                                }
                                
                                //DBK SL & UNIT
                                if (COMPANY_IDD == "816" || COMPANY_IDD == "579" || COMPANY_IDD == "286" || COMPANY_IDD == "3267" || COMPANY_IDD == "1058")
                                {
                                    DBK_SL_NO = ds_API.Tables[1].Rows[cc]["DBK_SL_NO"].ToString().TrimEnd();
                                    if (DBK_SL_NO != "" && DBK_SL_NO != null && DBK_SL_NO != string.Empty)
                                    {
                                        if (DBK_SL_NO.Contains("B"))
                                        {
                                            DBK_SL_NO = DBK_SL_NO;
                                        }
                                        else
                                        {
                                            DBK_SL_NO = DBK_SL_NO + "B";
                                        }

                                        if (COMPANY_IDD == "816")
                                        {
                                            DBK_UNIT = "KGS";
                                        }
                                        else
                                        {
                                            DBK_UNIT = Get_Valid_Qty_Code(QtyCode);
                                        }
                                    }
                                    else
                                    {
                                        DBK_SL_NO = "";
                                        DBK_UNIT = "";
                                    }
                                }

                                // Paramount
                                if (exp_name == "BRAKES INDIA PRIVATE LIMITED")
                                {
                                    Item_Desc = ExtraItemDesc + " " + Item_Desc;
                                    QtyCode = "NOS";
                                    GetQuantity = string.IsNullOrWhiteSpace(GetQuantity) ? "0" : GetQuantity;
                                    Item_UnitPrice = string.IsNullOrWhiteSpace(Item_UnitPrice) ? "0" : Item_UnitPrice;
                                    GetAmount = string.IsNullOrWhiteSpace(GetAmount) ? "0" : GetAmount;
                                    ddlTerms.Text = "FOB";
                                    IGST_RATE = ds_API.Tables[1].Rows[cc]["IGSTRate"].ToString().TrimEnd();
                                    if (IGST_RATE != "" && IGST_RATE != null && IGST_RATE != string.Empty)
                                    {
                                        IGSTPayStatus = "P";
                                    }
                                    EndUseOfItems = "GNX200";
                                    UnderPTA = "NCPTA";
                                    Bind_DrawBack_Unit_HsCode(HSNCode, out DBK_SL_NO, out DBK_UNIT);

                                     DBK_SL_NO_Brakes = DBK_SL_NO;
                                     DBK_UNIT_Brakes=DBK_UNIT;
                                     HSNCode_Brakes = HSNCode;
                                }
                                else if (exp_name == "DENSO KIRLOSKAR INDUSTRIES PVT LTD.,")
                                {
                                    Item_Desc = Item_Desc + " PART NO: " + ExtraItemDesc;
                                    Bind_DrawBack_Unit_HsCode(HSNCode, out DBK_SL_NO, out DBK_UNIT);

                                    if (exp_name == "DENSO KIRLOSKAR INDUSTRIES PVT LTD.,")
                                    {
                                        decimal TotalNetWeight_Each_INV = 0, Cal_Netwt = 0;

                                        if (ds_API.Tables[0].Rows[0]["TotalNetWeight"].ToString() != null && ds_API.Tables[0].Rows[0]["TotalNetWeight"].ToString() != string.Empty && ds_API.Tables[0].Rows[0]["TotalNetWeight"].ToString() != "" &&
                                            ds_API.Tables[1].Rows[0]["NetWeight"].ToString() != null && ds_API.Tables[1].Rows[0]["NetWeight"].ToString() != string.Empty && ds_API.Tables[1].Rows[0]["NetWeight"].ToString() != "")
                                        {
                                            decimal.TryParse(ds_API.Tables[0].Rows[0]["TotalNetWeight"].ToString(), out TotalNetWeight_Each_INV);
                                            decimal.TryParse(ds_API.Tables[1].Rows[0]["NetWeight"].ToString(), out Cal_Netwt);
                                        }

                                        decimal Net_Cal = (TotalNetWeight_Each_INV / Cal_Netwt) * Convert.ToDecimal(GetQuantity);
                                        Info_Msr = Net_Cal.ToString("N2");
                                    }
                                }

                                //IGST
                                if (COMPANY_IDD == "2118")
                                {
                                    IGST_RATE = ds_API.Tables[1].Rows[cc]["IGSTRate"].ToString().Replace("%", "").TrimEnd();
                                    if (IGST_RATE != "" && IGST_RATE != null && IGST_RATE != string.Empty)
                                    {
                                        IGSTPayStatus = "P";
                                    }
                                    Item_UnitPrice = string.IsNullOrWhiteSpace(Item_UnitPrice) ? "0" : Item_UnitPrice.Replace("$", "");
                                    GetAmount = string.IsNullOrWhiteSpace(GetAmount) ? "0" : GetAmount.Replace("$", "");
                                }

                                DataSet ds_get_data = new DataSet();
                                erm.Eproduct_imp_ceth = exp_name;
                                erm.Eproduct_imp_description = Item_Desc;
                                if (COMPANY_IDD == "816")
                                {
                                    erm.Eproduct_imp_cth = HSNCode;
                                    erm.Eproduct_imp_ritc = DBK_SL_NO;
                                    erm.Ename = "Get_Master_Data_HS_DBK";
                                }
                                else
                                {
                                    erm.Ename = "Get_Master_Data";
                                }
                                erm.EWorking_Period = Working_Period;
                                ds_get_data = erm.RetrieveAll_Export_PDF_Settings_MASTER();
                                List<string> cthListFromDS = new List<string>();
                                for (int ci = 0; ci < ds_get_data.Tables[0].Rows.Count; ci++)
                                {
                                    //string ritc = ds_get_data.Tables[0].Rows[ci]["PRODUCT_RITC"].ToString().Trim();
                                    string ritc = ds_get_data.Tables[0].Rows[ci]["RITC_NO"].ToString().Trim();
                                    if (!string.IsNullOrEmpty(ritc) && !cthListFromDS.Contains(ritc))
                                    {
                                        cthListFromDS.Add(ritc);
                                    }
                                }
                                string CTH_List_Json = new System.Web.Script.Serialization.JavaScriptSerializer()
                                                           .Serialize(cthListFromDS);

                             

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
                                    IGST_RATE = ds_get_data.Tables[0].Rows[0]["IGST_RATE"].ToString();
                                   
                                    if (HSNCode == "" && HSNCode == string.Empty || COMPANY_IDD != "829")
                                    {
                                        HSNCode = ds_get_data.Tables[0].Rows[0]["RITC_NO"].ToString();
                                    }


                                    if (cthListFromDS.Count == 1)
                                    {
                                        // Single CTH → auto-fill directly
                                        HSNCode = cthListFromDS[0];
                                    }
                                    else if (cthListFromDS.Count > 1)
                                    {
                                        HSNCode = cthListFromDS[0]; // default to first, user picks via autocomplete
                                    }
                                    if (COMPANY_IDD == "816")
                                    {
                                        Item_Desc = ds_get_data.Tables[0].Rows[0]["ITEM_DESC"].ToString();
                                        Item_Desc = Item_Desc + " " + ExtraItemDesc;
                                    }
                                    if (NetWeight != "" && NetWeight != null && string.IsNullOrEmpty(Info_Msr))
                                    {
                                        Info_Msr = NetWeight.ToString().Replace(",", "");
                                    }
                                    if (exp_name == "BRAKES INDIA PRIVATE LIMITED")
                                    {
                                        DBK_SL_NO = DBK_SL_NO_Brakes;
                                        DBK_UNIT=DBK_UNIT_Brakes ;
                                        HSNCode=HSNCode_Brakes;
                                    }
                                    else
                                    {
                                        DBK_SL_NO = ds_get_data.Tables[0].Rows[0]["DBK_SL_NO"].ToString();
                                        DBK_UNIT = ds_get_data.Tables[0].Rows[0]["DBK_UNIT"].ToString();
                                    }

                                    dt_gvew.Rows.Add(INVOICE_SLNO, ds_API.Tables[1].Rows[cc]["ItemSlNo"].ToString(), Item_Desc.Trim(), GetQuantity, Get_Valid_Qty_Code(QtyCode), Item_UnitPrice
                                     , Get_Valid_Curr_Name(ds_API.Tables[0].Rows[0]["Currency"].ToString()), GetAmount, Info_Msr, ds_API.Tables[1].Rows[cc]["InfoUnitPrice"].ToString(),
                                     SchemeCode, STR, RewardsPts, RODTEP, CessDetails, EndUseOfItems, UnderPTA, IGSTPayStatus, ITEM_ACCESSORIES_DESC, DRAWBACK_DESC, IGST_RATE, DBK_SL_NO, DBK_UNIT, HSNCode, CTH_List_Json);
                                }
                                else
                                {
                                    if (COMPANY_IDD == "816")
                                    {
                                        Item_Desc = Item_Desc + " " + ExtraItemDesc;
                                    }
                                    if (NetWeight != "" && NetWeight != null && string.IsNullOrEmpty(Info_Msr))
                                    {
                                        Info_Msr = NetWeight.ToString().Replace(",", "");
                                    }
                                    if (COMPANY_IDD == "6002")
                                    {
                                        RODTEP = "Y";
                                        EndUseOfItems = "GNX200";
                                        IGSTPayStatus = "LUT";
                                        UnderPTA = "NCPTI";
                                    }
                                    else
                                     
                                        {
                                            RODTEP = "N";
       
                                        }

                                    dt_gvew.Rows.Add(INVOICE_SLNO, ds_API.Tables[1].Rows[cc]["ItemSlNo"].ToString(), Item_Desc.Trim(), GetQuantity, Get_Valid_Qty_Code(QtyCode), Item_UnitPrice
                                    , Get_Valid_Curr_Name(ds_API.Tables[0].Rows[0]["Currency"].ToString()), GetAmount, Info_Msr, ds_API.Tables[1].Rows[cc]["InfoUnitPrice"].ToString(),
                                    SchemeCode, "N", "Y", RODTEP, "N", EndUseOfItems, UnderPTA, IGSTPayStatus, "", "", IGST_RATE, DBK_SL_NO, DBK_UNIT, HSNCode);
                                 }
                                HSNCode = ""; Item_Desc = ""; Info_Msr = ""; QtyCode = ""; DBK_SL_NO = "";
                            }

                            if (COMPANY_IDD == "2118" || COMPANY_IDD == "1586" || COMPANY_IDD == "829")
                            {
                                decimal TotalNetWeight_Each_INV = 0;
                                if (ds_API.Tables[0].Rows[0]["TotalNetWeight"].ToString() != null && ds_API.Tables[0].Rows[0]["TotalNetWeight"].ToString() != string.Empty && ds_API.Tables[0].Rows[0]["TotalNetWeight"].ToString() != "")
                                {
                                    decimal.TryParse(ds_API.Tables[0].Rows[0]["TotalNetWeight"].ToString(), out TotalNetWeight_Each_INV);
                                }
                                TotalNetWeight_Mul_INV = TotalNetWeight_Mul_INV + TotalNetWeight_Each_INV;
                                ViewState["TotalNetWeight"] = TotalNetWeight_Mul_INV;

                                decimal TotalGrossWeight_Each_INV = 0;
                                if (ds_API.Tables[0].Rows[0]["TotalGrossWeight"].ToString() != null && ds_API.Tables[0].Rows[0]["TotalGrossWeight"].ToString() != string.Empty && ds_API.Tables[0].Rows[0]["TotalGrossWeight"].ToString() != "")
                                {
                                    decimal.TryParse(ds_API.Tables[0].Rows[0]["TotalGrossWeight"].ToString(), out TotalGrossWeight_Each_INV);
                                }
                                TotalGrossWeight_Mul_INV = TotalGrossWeight_Mul_INV + TotalGrossWeight_Each_INV;
                                ViewState["TotalGrossWeight"] = TotalGrossWeight_Mul_INV;

                                if (COMPANY_IDD == "2118" || COMPANY_IDD == "829")
                                {
                                    decimal TotalCarton_Each_INV = 0;
                                    if (ds_API.Tables[0].Rows[0]["TotalCarton"].ToString() != null && ds_API.Tables[0].Rows[0]["TotalCarton"].ToString() != string.Empty && ds_API.Tables[0].Rows[0]["TotalCarton"].ToString() != "")
                                    {
                                        decimal.TryParse(ds_API.Tables[0].Rows[0]["TotalCarton"].ToString(), out TotalCarton_Each_INV);
                                    }
                                    TotalCarton_Mul_INV = TotalCarton_Mul_INV + TotalCarton_Each_INV;
                                    ViewState["TotalCarton"] = TotalCarton_Mul_INV;
                                }
                            }

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

                            if (gv_ItemPDF.HeaderRow != null)
                            {
                                gv_ItemPDF.UseAccessibleHeader = true;
                                gv_ItemPDF.HeaderRow.TableSection = TableRowSection.TableHeader;
                            }

                            hd_PageCount.Value = string.IsNullOrEmpty(hd_PageCount.Value) ? "0" : hd_PageCount.Value;

                            Upload_Count = "0";
                            PageCount_log(PdfStatus.PREVIEW_SUCCESS, hd_PageCount.Value);
                            Upload_page_Count = "0";
                            //con.Open();
                            //SqlCommand Scmd =
                            //    new SqlCommand(
                            //        "select * from PDF_AI_COUNT_DETAILS where PDF_JOB_NO = '" + txtjobPS.Text + "' and PDF_EXP_IMP_NAME='" + exp_name + "' and PDF_BRANCH_CODE ='" + currentbranch + "'", con);
                            //SqlDataAdapter sda = new SqlDataAdapter(Scmd);
                            //DataSet Sds = new DataSet();
                            //sda.Fill(Sds);
                            //con.Close();
                            //con.Open();
                            //if (Sds.Tables[0].Rows.Count > 0)
                            //{
                            //    string PDF_ID = Sds.Tables[0].Rows[0]["PDF_ID"].ToString();
                            //    string PDF_UPLOAD_COUNT = Sds.Tables[0].Rows[0]["PDF_UPLOAD_COUNT"].ToString();
                            //    SqlCommand Ucmd =
                            //      new SqlCommand(
                            //          "Update PDF_AI_COUNT_DETAILS set PDF_UPLOAD_COUNT=(" + PDF_UPLOAD_COUNT + "+1),PDF_REMARKS= PDF_REMARKS + " + hd_PageCount.Value + ",PDF_USER_ID='" + currentuser + "',PDF_DATE_TIME=GetDate()," +
                            //    "PDF_STATUS='S',PDF_BRANCH_CODE='" + currentbranch + "',PDF_WORKING_PERIOD='" + Working_Period + "' where PDF_ID=" + PDF_ID + "", con);
                            //    int result = Ucmd.ExecuteNonQuery();
                            //}
                            //else
                            //{

                            //    SqlCommand cmd =
                            //        new SqlCommand(
                            //            "insert into PDF_AI_COUNT_DETAILS(PDF_JOB_NO,PDF_EXP_IMP_NAME,PDF_MODE,PDF_UPLOAD_COUNT,PDF_REMARKS,PDF_USER_ID,PDF_DATE_TIME,PDF_STATUS,PDF_BRANCH_CODE,PDF_WORKING_PERIOD) values('" + txtjobPS.Text + "','" +
                            //            exp_name + "','EXP','1','" + hd_PageCount.Value + "','" + currentuser + "',GetDate(),'S','" + currentbranch + "','" + Working_Period + "')", con);
                            //    int result = cmd.ExecuteNonQuery();

                            //}
                            //con.Close();
                        }
                        else
                        {
                            PageCount_log(PdfStatus.PREVIEW_FAILED, hd_PageCount.Value);
                            Upload_Error_Count = "0";
                            lbl_loading.Text = "Error";
                        }
                    }

                    if (exp_name == "BRAKES INDIA PRIVATE LIMITED")
                    {
                        Bind_AdCode_Con();
                    }
                    else
                    {
                        Get_AdCode();
                    }

                    if (gv_ItemPDF.Rows.Count > 0)
                    {
                        ViewState["GridViewData"] = dt_gvew;
                        ddl_Select_ItemRITC_SelectedIndexChanged(sender, e);
                    }
                    lblmsg.Text = "";
                }
            }
            else
            {
                if (Request.Files.Count > FileSetLimit)
                {
                    Alert_msg("Please Upload a File Minimum " + FileSetLimit + "..!");
                }
                else
                {
                    Alert_msg("Please Upload File..!");
                }
            }
        }
        catch (Exception ex)
        {
            PageCount_log(PdfStatus.PREVIEW_FAILED, hd_PageCount.Value);
            Upload_Error_Count = "0";
            log.makeLog("Message ==> " + ex.Message);
            lblmsg.Text = " Message ==> " + ex.Message + " InnerException ==> " + ex.InnerException + " StackTrace ==>" + ex.StackTrace;
        }
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
                        TextBox txtItemQty = (TextBox)row.FindControl("txtItemQty");
                        TextBox txtQtyCode = (TextBox)row.FindControl("txtQtyCode");
                        TextBox txtItemUnitPrice = (TextBox)row.FindControl("txtItemUnitPrice");
                        TextBox txtItemAmt = (TextBox)row.FindControl("txtItemAmt");
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
                        TextBox txtRitc_No = (TextBox)row.FindControl("txt_RITCNo");

                        if (txtItemDesc.Text.Trim() != "" && txtItemQty.Text.Trim() != "" && txtQtyCode.Text.Trim() != "" && txtQtyCode.Text.Trim().Length == 3 && txtItemUnitPrice.Text.Trim() != ""
                            && txtItemAmt.Text.Trim() != "" && ddl_SchemeCode != null && ddl_STRYN != null && ddl_Reward_Points != null && ddl_RodtepYN != null
                            && ddl_CessYN != null && txtEndUseOfItems.Text.Trim() != "" && txtUnderPTA.Text.Trim() != "" && txtRitc_No.Text.Trim() != "" && txtRitc_No.Text.Trim().Length == 8 && ddl_IGSTPayment != null)
                        {
                            string itemDesc = txtItemDesc.Text;
                            string itemQty = txtItemQty.Text;
                            string qtyCode = txtQtyCode.Text;
                            string itemUnitPrice = txtItemUnitPrice.Text;
                            string itemAmt = txtItemAmt.Text;
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
                            string ritcNo = txtRitc_No.Text;

                            if (row.RowIndex < dt_gvew.Rows.Count)
                            {
                                dt_gvew.Rows[row.RowIndex]["ITEM_DESC"] = itemDesc;
                                dt_gvew.Rows[row.RowIndex]["ITEM_QTY"] = itemQty;
                                dt_gvew.Rows[row.RowIndex]["ITEM_QTY_CODE"] = qtyCode;
                                dt_gvew.Rows[row.RowIndex]["ITEM_UNITPRICE"] = itemUnitPrice;
                                dt_gvew.Rows[row.RowIndex]["ITEM_AMOUNT"] = itemAmt;
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
                                dt_gvew.Rows[row.RowIndex]["RITCNO"] = ritcNo;
                            }
                        }
                        else
                        {
                            string Mandatory_Fields = "";
                            if (txtItemDesc.Text.Trim() == "")
                            {
                                Mandatory_Fields = "Item Desc";
                            }
                            else if (txtItemQty.Text.Trim() == "")
                            {
                                Mandatory_Fields = "Quantity";
                            }
                            else if (txtQtyCode.Text.Trim() == "")
                            {
                                Mandatory_Fields = "Item QTY Code";
                            }
                            else if (txtEndUseOfItems.Text.Trim() == "")
                            {
                                Mandatory_Fields = "End Use";
                            }
                            else if (txtItemUnitPrice.Text.Trim() == "")
                            {
                                Mandatory_Fields = "Unit Price";
                            }
                            else if (txtItemAmt.Text.Trim() == "")
                            {
                                Mandatory_Fields = "Amount";
                            }
                            else if (txtRitc_No.Text.Trim() == "")
                            {
                                Mandatory_Fields = "RITCNo";
                            }

                            Alert_msg("Please Enter the " + " " + Mandatory_Fields + " Fields..!");
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
            string Get_exp_name = ViewState["exp_name"].ToString().Trim();
            string Get_branch_slno = ViewState["branch_slno"].ToString().Trim();

            Tbl_Columns();
            DataSet dss_Insert = new DataSet();
            dss_Insert = (DataSet)ViewState["ds_xl_Output"];
            DataTable dt_INVOICE = new DataTable();
            DataTable dt_ITEM = new DataTable();
            DataTable dt_ContainerDetails = new DataTable();
            IsValid = BindgridViewData();
            if (IsValid == true)
            {
                PageCount_log(PdfStatus.UPLOAD_INITIATED, hd_PageCount.Value);
                dt_INVOICE = (DataTable)ViewState["dt_Invoice"];
                dt_ITEM = (DataTable)ViewState["dt_Item"];

                string AUTHORIZED_ECONOMIC_OPERATOR_CODE = "", A_E_O_COUNTRY = "", AUTHORIZED_ECONOMIC_OPERATOR = "", ADCODE = "", IGST_PAYMENT = "", IGST_RATE = "", marksnos = "", CONTRCT_NO = "", TYPE_OF_EXPORTER = "";
                string PAYMENT_METHOD = "NA", PERIOD_PAYMENT = "", COMMON_JOBNO_PS = "", ConsigneeAdd1 = "", ConsigneeAdd2 = "", ConsigneeAdd3 = "", ConsigneeAdd4 = "";
                string STATE_OF_ORIGIN = "", GetInvoiceValue = "", curr = "", TERMS = "", BUYER = "", InvNo = "", invdt = "", InvValue = "", FREIGHT_CHGS = "";
                string DISTRICT_OF_ORIGIN = "", FOB_CHARGES = "", COMMISSION_CHARGES = "", FREIGHT_CHARGES = "", INSURANCE_CHARGES = "", TotalNetWeight = "", TotalGrossWeight = "", PACKMISC_CHARGES = "";
                string THIRDPARTY_NAME = "", THIRDPARTY_ADD1 = "", THIRDPARTY_ADD2 = "", THIRDPARTY_CITY = "";

                //***General Details***//
                string state_dist = "";
                try
                {
                    state_dist = Get_Valid_State_Name(ViewState["IEC"].ToString(), ViewState["exp_name"].ToString());
                }
                catch (Exception ex)
                {
                    state_dist = "";
                }

                if (state_dist != "")
                {
                    string[] ss = state_dist.Split('~');

                    STATE_OF_ORIGIN = ss[0];
                    DISTRICT_OF_ORIGIN = ss[1];
                    marksnos = ss[2];

                    if (COMPANY_IDD == "517")
                    {
                        if (marksnos != "")
                        {
                            marksnos = "CTN NO:" + dss_Insert.Tables[0].Rows[0]["CartonNo"].ToString().Trim().Replace("CTN NO:", "").Replace(" ", "") + "-" + dss_Insert.Tables[0].Rows[0]["TotalCarton"].ToString().Trim() + " ORDER NO:" + dss_Insert.Tables[0].Rows[0]["OrderNo"].ToString().Trim() + " KIMBALL NO:" + dss_Insert.Tables[0].Rows[0]["KimballNo"].ToString().Trim() + " " + marksnos;
                        }
                        else
                        {
                            marksnos = "WE INTEND TO CLAIM REWARDS UNDER MERCHANDISE EXPORTS FROM INDIA SCHEME";
                        }
                    }

                }
                string state_export = "";

                if (COMPANY_IDD == "517")
                {
                    state_export = "TAMIL NADU";
                }
                else
                {
                    string[] sss = STATE_OF_ORIGIN.Split('-');
                    try
                    {
                        state_export = sss[1];
                    }
                    catch (Exception ex)
                    {
                        state_export = "";
                    }
                }

                string Country_name = Get_Valid_Country_Name(txtCountry.Text.Trim());
                //string Port_name = "", Final_Port_name = "";

                //if (Country_name.Contains('-'))
                //{
                //    string[] county_code = Country_name.Split('-');
                //    Country_name = county_code[0];
                //    Port_name = Get_Valid_Port_Name_Code(txtPort.Text.Trim(), county_code[1]);
                //}
                //else
                //{
                //    Port_name = txtPort.Text;
                //}
                //Final_Port_name = Port_name;
                if (ddlAdCode.SelectedItem != null && !string.IsNullOrEmpty(ddlAdCode.SelectedItem.Text))
                {
                    ADCODE = ddlAdCode.SelectedItem.Text;
                }
                string GE_CUSTOMHOUSE_CODE = "";
                if (COMPANY_IDD == "2118")
                {
                    hdfTransport_mode.Value = "Land";
                    if ((Get_branch_slno == "35" || Get_branch_slno == "24") && Get_exp_name == "JOHN DEERE INDIA PRIVATE LIMITED")
                    {
                        GE_CUSTOMHOUSE_CODE = "INDIG6";
                    }
                    else
                    {
                        GE_CUSTOMHOUSE_CODE = "INTLG6";
                    }
                }
                else if (COMPANY_IDD == "829")
                {
                    hdfTransport_mode.Value = "Land";
                    GE_CUSTOMHOUSE_CODE = "INSBK6";
                }
                else
                {
                    GE_CUSTOMHOUSE_CODE = Session["CUSTOMHOUSE_CODE"].ToString();
                }

                if (COMPANY_IDD == "1509" || Get_exp_name == "DENSO KIRLOSKAR INDUSTRIES PVT LTD.,")
                {
                    ConsigneeAdd1 = dss_Insert.Tables[0].Rows[0]["ConsigneeAdd1"].ToString();
                    ConsigneeAdd2 = dss_Insert.Tables[0].Rows[0]["ConsigneeAdd2"].ToString();
                    ConsigneeAdd3 = dss_Insert.Tables[0].Rows[0]["ConsigneeAdd3"].ToString();
                    ConsigneeAdd4 = dss_Insert.Tables[0].Rows[0]["ConsigneeAdd4"].ToString();
                }

                TYPE_OF_EXPORTER = ddlType_Exp.SelectedValue;
                Dt_gen.Rows.Add(Get_exp_name, Get_branch_slno, txtConsigneeName.Text, "", ConsigneeAdd1, ConsigneeAdd2, ConsigneeAdd3, ConsigneeAdd4,
                    hdfTransport_mode.Value, GE_CUSTOMHOUSE_CODE, Country_name, txtPort.Text.Trim(), Country_name, txtPort.Text.Trim(), state_export, marksnos, ADCODE, TYPE_OF_EXPORTER);

                //***Invoice Details***//
                BUYER = "N";
                if (txtBuyer.Text == "")
                {
                    txtBuyer.Text = "SAME AS CONSIGNEE";
                }
                if (txtBuyer.Text == "SAME AS CONSIGNEE")
                {
                    BUYER = "Y";
                }

                string contract = dss_Insert.Tables[0].Rows[0]["BuyerOrderNo"].ToString().TrimStart().Replace(" ", "");
                CONTRCT_NO = contract;
                PERIOD_PAYMENT = dss_Insert.Tables[0].Rows[0]["PaymentPeriod"].ToString();

                string[] trms = dss_Insert.Tables[0].Rows[0]["TermsOfPayment"].ToString().Replace("PAYMENT", "").Replace("TRADE CARD", "TRADE").Split(' ', '\t');

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
                    PAYMENT_METHOD = dss_Insert.Tables[0].Rows[0]["TermsOfPayment"].ToString().Replace("TT", "DP");
                    if (PAYMENT_METHOD == "Direct" || PAYMENT_METHOD == "DDP")
                    {
                        PAYMENT_METHOD = "DP";
                    }
                    if (PAYMENT_METHOD == "Advance" || PAYMENT_METHOD == "DAP" || PAYMENT_METHOD == "D/A")
                    {
                        PAYMENT_METHOD = "DA";
                    }
                }

                if (COMPANY_IDD == "816")
                {
                    PAYMENT_METHOD = "DA";
                    PERIOD_PAYMENT = "";
                }

                if (COMPANY_IDD == "579" || COMPANY_IDD == "2118" || Get_exp_name == "DENSO KIRLOSKAR INDUSTRIES PVT LTD.,")
                {
                    PAYMENT_METHOD = "DA";
                }
                else if (COMPANY_IDD == "1509" || COMPANY_IDD == "139" || Get_exp_name == "BAETTR INDIA PRIVATE LIMITED")
                {
                    PAYMENT_METHOD = "DP";
                }
                else if (COMPANY_IDD == "829")
                {
                    PAYMENT_METHOD = "NA";
                }

                FOB_CHARGES = ViewState["FOB_CHARGES"].ToString();
                FREIGHT_CHARGES = ViewState["FREIGHT_CHARGES"].ToString();
                INSURANCE_CHARGES = ViewState["INSURANCE_CHARGES"].ToString();
                COMMISSION_CHARGES = ViewState["COMMISSION_CHARGES"].ToString();
                PACKMISC_CHARGES = ViewState["PACKMISC_CHARGES"].ToString();
                GetInvoiceValue = dss_Insert.Tables[0].Rows[0]["InvoiceValue"].ToString().Replace(",", "");

                if (COMPANY_IDD == "1509")
                {
                    THIRDPARTY_NAME = RemoveWordsWithSpecialChars(dss_Insert.Tables[0].Rows[0]["NotifyPartyName"].ToString().Replace(",", ""));
                    THIRDPARTY_ADD1 = RemoveWordsWithSpecialChars(dss_Insert.Tables[0].Rows[0]["NotifyAddress1"].ToString().Replace(",", ""));
                    THIRDPARTY_ADD2 = RemoveWordsWithSpecialChars(dss_Insert.Tables[0].Rows[0]["NotifyAddress2"].ToString().Replace(",", ""));
                    THIRDPARTY_CITY = RemoveWordsWithSpecialChars(dss_Insert.Tables[0].Rows[0]["NotifyAddress3"].ToString().Replace(",", ""));
                }

                if (dt_INVOICE.Rows.Count == 1)
                {
                    curr = Get_Valid_Curr_Name(txtCurrency.Text.Trim());
                    invdt = Get_Valid_Date1(txtInvoiceDate.Text.Trim());
                    InvNo = "";
                    if (dss_Insert.Tables[0].Rows[0]["InvoiceNo"].ToString().Contains("+"))
                    {
                        InvNo = ViewState["fileNamewithoutextn"].ToString();
                    }
                    else
                    {
                        InvNo = dss_Insert.Tables[0].Rows[0]["InvoiceNo"].ToString();
                    }
                    TERMS = ddlTerms.Text.Contains("FOB") ? "FOB" : ddlTerms.Text.Trim().Replace("FCA", "FOB").Replace("FOC", "FOB");

                    Dt_Invoice.Rows.Add("1", InvNo, invdt.Trim(), PAYMENT_METHOD, PERIOD_PAYMENT, GetInvoiceValue, curr, Get_ExchangeRate(curr), CONTRCT_NO,
                   TERMS, BUYER, txtBuyer.Text, AUTHORIZED_ECONOMIC_OPERATOR_CODE, A_E_O_COUNTRY, AUTHORIZED_ECONOMIC_OPERATOR, FOB_CHARGES, FREIGHT_CHARGES, INSURANCE_CHARGES, COMMISSION_CHARGES, "", PACKMISC_CHARGES, THIRDPARTY_NAME, THIRDPARTY_ADD1, THIRDPARTY_ADD2, THIRDPARTY_CITY);
                }
                else
                {
                    for (int h = 0; h <= dt_INVOICE.Rows.Count - 1; h++)
                    {
                        InvNo = dt_INVOICE.Rows[h]["InvoiceNo"].ToString();
                        invdt = Get_Valid_Date1(dt_INVOICE.Rows[h]["InvoiceDate"].ToString().Trim());
                        curr = Get_Valid_Curr_Name(dt_INVOICE.Rows[h]["Currency"].ToString().Trim());
                        TERMS = dt_INVOICE.Rows[h]["Terms"].ToString().Trim().Replace("FCA", "FOB").Replace("FOC", "FOB");
                        InvValue = dt_INVOICE.Rows[h]["InvoiceValue"].ToString().Trim();
                        FREIGHT_CHGS = dt_INVOICE.Rows[h]["FREIGHT_CHARGES"].ToString().Trim();
                        INSURANCE_CHARGES = dt_INVOICE.Rows[h]["INSURANCE_CHARGES"].ToString().Trim();
                        string OTHER_DED_CHARGES = dt_INVOICE.Rows[h]["OTHER_DED_CHARGES"].ToString().Trim();

                        Dt_Invoice.Rows.Add((h + 1), InvNo, invdt.Trim(), PAYMENT_METHOD, PERIOD_PAYMENT, InvValue, curr, Get_ExchangeRate(curr), CONTRCT_NO,
                            TERMS, BUYER, txtBuyer.Text, AUTHORIZED_ECONOMIC_OPERATOR_CODE, A_E_O_COUNTRY, AUTHORIZED_ECONOMIC_OPERATOR, FOB_CHARGES, FREIGHT_CHGS, INSURANCE_CHARGES, COMMISSION_CHARGES, OTHER_DED_CHARGES, PACKMISC_CHARGES);
                    }
                }
                //--------Dt_ContainerDetails   Start------------
                if (ViewState["dt_ContainerDetails"] != null)
                {
                    dt_ContainerDetails = (DataTable)ViewState["dt_ContainerDetails"];
                }
                //--------Dt_ContainerDetails   End------------

                //--------Dt_anx------------

                string ANNEX_SEA_SEAL_TYPE = "";
                string ANNEX_SEA_FAC_STUFFED = "N";
                string ANNEX_SEA_SAMPLE_ACCOM = "N";
                string ANNEX_SEA_NATURE_OF_CARGO = "C";
                string ANNEX_SEA_NO_CONTAINERS = "0";
                string ANNEX_SEA_UNIT_MEASUREMENT = "KGS";
                if (COMPANY_IDD != "1039")
                {
                    ANNEX_SEA_SEAL_TYPE = "Warehouse";
                }
                if (dt_ContainerDetails != null && dt_ContainerDetails.Rows.Count > 0)
                {
                    ANNEX_SEA_NO_CONTAINERS = dt_ContainerDetails.Rows.Count.ToString();
                }
                string ANNEX_SEA_PKG_UNIT_CODE = "";
                string ANNEX_SEA_TOTAL_PACKAGES = "";

                string ANNEX_AIR_NATURE_OF_CARGO = "P";
                string ANNEX_AIR_GR_UNIT_CODE = "";
                string ANNEX_AIR_TOTAL_PACKAGES = "";
                string ANNEX_AIR_UNIT_CODE = "";

                if (dss_Insert.Tables[0].Rows[0]["CartonNo"].ToString() != "")
                {
                    ANNEX_SEA_TOTAL_PACKAGES = dss_Insert.Tables[0].Rows[0]["TotalCarton"].ToString();
                }
                // Default Annexure setting Start
                ds_Annex_dt = Get_Default_Annexure_Details(Get_exp_name, Get_branch_slno);
                if (ds_Annex_dt != null && ds_Annex_dt.Tables.Count > 0 && ds_Annex_dt.Tables[0].Rows.Count > 0)
                {
                    if (hdfTransport_mode.Value == "Air")
                    {
                        ANNEX_AIR_UNIT_CODE = GetValueOrDefault(ds_Annex_dt.Tables[0].Rows[0]["ANNEX_AIR_UNIT_CODE"], ANNEX_AIR_UNIT_CODE);
                        ANNEX_AIR_GR_UNIT_CODE = GetValueOrDefault(ds_Annex_dt.Tables[0].Rows[0]["ANNEX_AIR_GR_UNIT_CODE"], ANNEX_AIR_GR_UNIT_CODE);
                    }
                    else
                    {
                        ANNEX_SEA_SEAL_TYPE = GetValueOrDefault(ds_Annex_dt.Tables[0].Rows[0]["ANNEX_SEA_SEAL_TYPE"], ANNEX_SEA_SEAL_TYPE);
                        ANNEX_SEA_FAC_STUFFED = GetValueOrDefault(ds_Annex_dt.Tables[0].Rows[0]["ANNEX_SEA_FAC_STUFFED"], ANNEX_SEA_FAC_STUFFED);
                        ANNEX_SEA_SAMPLE_ACCOM = GetValueOrDefault(ds_Annex_dt.Tables[0].Rows[0]["ANNEX_SEA_SAMPLE_ACCOM"], ANNEX_SEA_SAMPLE_ACCOM);
                        ANNEX_SEA_NATURE_OF_CARGO = GetValueOrDefault(ds_Annex_dt.Tables[0].Rows[0]["ANNEX_SEA_NATURE_OF_CARGO"], ANNEX_SEA_NATURE_OF_CARGO);
                        ANNEX_SEA_PKG_UNIT_CODE = GetValueOrDefault(ds_Annex_dt.Tables[0].Rows[0]["ANNEX_SEA_PKG_UNIT_CODE"], ANNEX_SEA_PKG_UNIT_CODE);
                        ANNEX_SEA_UNIT_MEASUREMENT = GetValueOrDefault(ds_Annex_dt.Tables[0].Rows[0]["ANNEX_SEA_UNIT_MEASUREMENT"], ANNEX_SEA_PKG_UNIT_CODE);
                    }
                }
                // Default Annexure setting End
                if (COMPANY_IDD == "517")
                {
                    ANNEX_SEA_PKG_UNIT_CODE = "CTN";
                }
                if (COMPANY_IDD == "816")
                {
                    ANNEX_SEA_PKG_UNIT_CODE = "CTN";
                    ANNEX_SEA_SEAL_TYPE = "Self";
                    ANNEX_SEA_NO_CONTAINERS = "1";
                    ANNEX_SEA_FAC_STUFFED = "Y";

                    TotalNetWeight = dss_Insert.Tables[0].Rows[0]["TotalNetWeight"].ToString().ToLower().Replace("kgs", "").Replace(",", "");
                    TotalGrossWeight = dss_Insert.Tables[0].Rows[0]["TotalGrossWeight"].ToString().ToLower().Replace("kgs", "").Replace(",", "");
                }
                else if (COMPANY_IDD == "2118")
                {
                    TotalNetWeight = ViewState["TotalNetWeight"].ToString().Replace(",", "");
                    TotalGrossWeight = ViewState["TotalGrossWeight"].ToString().Replace(",", "");
                    if ((Get_branch_slno == "35" || Get_branch_slno == "24") && Get_exp_name == "JOHN DEERE INDIA PRIVATE LIMITED")
                    {
                        ANNEX_SEA_NATURE_OF_CARGO = "P";
                        ANNEX_SEA_SEAL_TYPE = "";
                        ANNEX_SEA_NO_CONTAINERS = "1";
                        ANNEX_SEA_PKG_UNIT_CODE = "PKG";
                    }
                    else if (Get_exp_name == "JCB INDIA LIMITED")
                    {
                        ANNEX_SEA_SEAL_TYPE = "Self";
                        ANNEX_SEA_FAC_STUFFED = "Y";
                        ANNEX_SEA_NO_CONTAINERS = ViewState["FileUploadCount"].ToString();
                        ANNEX_SEA_PKG_UNIT_CODE = "PLT";
                        ANNEX_SEA_TOTAL_PACKAGES = ViewState["TotalCarton"].ToString();
                    }
                }
                else if (COMPANY_IDD == "579")
                {
                    ANNEX_SEA_NO_CONTAINERS = "1";
                    ANNEX_SEA_FAC_STUFFED = "Y";
                    ANNEX_SEA_SEAL_TYPE = "Self";
                    TotalNetWeight = dss_Insert.Tables[0].Rows[0]["TotalNetWeight"].ToString().ToLower().Replace("kgs", "").Replace(",", "");
                    TotalGrossWeight = dss_Insert.Tables[0].Rows[0]["TotalGrossWeight"].ToString().ToLower().Replace("kgs", "").Replace(",", "");
                }
                else if (COMPANY_IDD == "293")
                {
                    ANNEX_SEA_NO_CONTAINERS = "1";
                    ANNEX_SEA_FAC_STUFFED = "Y";
                    ANNEX_SEA_SEAL_TYPE = "Self";
                    ANNEX_SEA_PKG_UNIT_CODE = "PKG";
                    TotalNetWeight = dss_Insert.Tables[0].Rows[0]["TotalNetWeight"].ToString().ToLower().Replace("kgs", "").Replace(",", "");
                    TotalGrossWeight = dss_Insert.Tables[0].Rows[0]["TotalGrossWeight"].ToString().ToLower().Replace("kgs", "").Replace(",", "");

                    if (Get_exp_name == "DENSO KIRLOSKAR INDUSTRIES PVT LTD.,")
                    {
                        ANNEX_SEA_PKG_UNIT_CODE = "";
                    }
                }
                else if (COMPANY_IDD == "2237")
                {
                    ANNEX_SEA_NATURE_OF_CARGO = "P";
                    ANNEX_SEA_SEAL_TYPE = "Warehouse";
                    ANNEX_SEA_PKG_UNIT_CODE = "CLS";
                    ANNEX_SEA_UNIT_MEASUREMENT = "MTS";
                    TotalNetWeight = dss_Insert.Tables[0].Rows[0]["TotalNetWeight"].ToString().ToLower().Replace("kgs", "").Replace(",", "");
                    TotalGrossWeight = dss_Insert.Tables[0].Rows[0]["TotalGrossWeight"].ToString().ToLower().Replace("kgs", "").Replace(",", "");
                }
                else if (COMPANY_IDD == "829")
                {
                    ANNEX_SEA_NATURE_OF_CARGO = "P";
                    ANNEX_SEA_PKG_UNIT_CODE = "PKG";
                    ANNEX_SEA_NO_CONTAINERS = "";
                    ANNEX_SEA_TOTAL_PACKAGES = ViewState["TotalCarton"].ToString();
                    TotalNetWeight = ViewState["TotalNetWeight"].ToString().Replace(",", "");
                    TotalGrossWeight = ViewState["TotalGrossWeight"].ToString().Replace(",", "");
                }
                else if (COMPANY_IDD == "470")
                {
                    ANNEX_SEA_PKG_UNIT_CODE = "PKG";
                    ANNEX_SEA_NO_CONTAINERS = "1";
                    ANNEX_SEA_FAC_STUFFED = "Y";
                    TotalNetWeight = dss_Insert.Tables[0].Rows[0]["TotalNetWeight"].ToString().ToLower().Replace("kgs", "").Replace(",", "");
                    TotalGrossWeight = dss_Insert.Tables[0].Rows[0]["TotalGrossWeight"].ToString().ToLower().Replace("kgs", "").Replace(",", "");
                }
                else if (COMPANY_IDD == "1509")
                {
                    ANNEX_SEA_PKG_UNIT_CODE = "UNT";
                    ANNEX_SEA_NO_CONTAINERS = "1";
                    TotalNetWeight = dss_Insert.Tables[0].Rows[0]["TotalNetWeight"].ToString().ToLower().Replace("kgs", "").Replace(",", "");
                    TotalGrossWeight = dss_Insert.Tables[0].Rows[0]["TotalGrossWeight"].ToString().ToLower().Replace("kgs", "").Replace(",", "");
                }
                else if (COMPANY_IDD == "286")
                {
                    ANNEX_SEA_PKG_UNIT_CODE = "PKG";
                    ANNEX_SEA_FAC_STUFFED = "N";
                    ANNEX_SEA_NO_CONTAINERS = "1";
                    TotalNetWeight = dss_Insert.Tables[0].Rows[0]["TotalNetWeight"].ToString().ToLower().Replace("kgs", "").Replace(",", "");
                    TotalGrossWeight = dss_Insert.Tables[0].Rows[0]["TotalGrossWeight"].ToString().ToLower().Replace("kgs", "").Replace(",", "");
                }
                else if (COMPANY_IDD == "139")
                {
                    ANNEX_SEA_PKG_UNIT_CODE = "PKG";
                    ANNEX_SEA_NO_CONTAINERS = "";
                    TotalNetWeight = dss_Insert.Tables[0].Rows[0]["TotalNetWeight"].ToString().ToLower().Replace("kgs", "").Replace(",", "");
                    TotalGrossWeight = dss_Insert.Tables[0].Rows[0]["TotalGrossWeight"].ToString().ToLower().Replace("kgs", "").Replace(",", "");
                }
                else if (Get_exp_name == "BAETTR INDIA PRIVATE LIMITED")
                {
                    ANNEX_SEA_SEAL_TYPE = "Self";
                    ANNEX_SEA_FAC_STUFFED = "Y";
                    ANNEX_SEA_PKG_UNIT_CODE = "PKG";
                    ANNEX_SEA_NO_CONTAINERS = "";

                    TotalNetWeight = dss_Insert.Tables[0].Rows[0]["TotalNetWeight"].ToString().ToLower().Replace("kgs", "").Replace(",", "");
                    TotalGrossWeight = dss_Insert.Tables[0].Rows[0]["TotalGrossWeight"].ToString().ToLower().Replace("kgs", "").Replace(",", "");

                }

                else
                {
                    TotalNetWeight = dss_Insert.Tables[0].Rows[0]["TotalNetWeight"].ToString().ToLower().Replace("kgs", "").Replace(",", "");
                    TotalGrossWeight = dss_Insert.Tables[0].Rows[0]["TotalGrossWeight"].ToString().ToLower().Replace("kgs", "").Replace(",", "");
                }

                if (hdfTransport_mode.Value == "Air")
                {
                    Dt_anx_Air.Rows.Add(ANNEX_AIR_NATURE_OF_CARGO, marksnos, dss_Insert.Tables[0].Rows[0]["TotalCarton"].ToString(),
                    TotalGrossWeight, TotalNetWeight, Get_Valid_Qty_Code(dss_Insert.Tables[0].Rows[0]["QtyCode"].ToString()), ANNEX_AIR_UNIT_CODE);
                }
                else
                {
                    Dt_anx.Rows.Add(ANNEX_SEA_FAC_STUFFED, ANNEX_SEA_SAMPLE_ACCOM, ANNEX_SEA_NATURE_OF_CARGO, marksnos, ANNEX_SEA_TOTAL_PACKAGES, ANNEX_SEA_NO_CONTAINERS, ANNEX_SEA_UNIT_MEASUREMENT
                   , ANNEX_SEA_SEAL_TYPE, TotalGrossWeight, TotalNetWeight, ANNEX_SEA_PKG_UNIT_CODE);
                }

                //***Item Details***//
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
                        }
                    }


                    if (Get_exp_name == "MAF CLOTHING PRIVATE LIMITED")
                    {
                        if (Itemdesc == "HANGER")
                        {
                            Qty_Cd = "KGS";
                            Item_Desc_Customized = "HANGER (" + Item_Qty + " PCS" + ")";
                            if (InfoQty != "")
                            {
                                Item_Qty = InfoQty;

                                double Spl_Calc = 0.00;
                                Spl_Calc = Convert.ToDouble(Item_Amount) / Convert.ToDouble(InfoQty);
                                Item_UnitPrice = Convert.ToString((Math.Round(Convert.ToDecimal(Spl_Calc), 5, MidpointRounding.AwayFromZero)).ToString());
                            }
                        }
                        else
                        {
                            Qty_Cd = "NOS";
                        }
                    }

                    Auto.Ename = "Get_CTH_Info_Uqc";
                    Auto.Enamesearch = RITCNO;
                    Auto.Notn_No_Search = RITCNO;
                    DataSet SQC_ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
                    if (SQC_ds.Tables[0].Rows.Count > 0)//Info UQC
                    {
                        SQC = SQC_ds.Tables[0].Rows[0][0].ToString();
                    }

                    if (Get_exp_name == "BRAKES INDIA PRIVATE LIMITED")
                    {
                        if (dss_Insert.Tables[1].Rows.Count == dt_ITEM.Rows.Count)
                        {
                            IGST_AMT = dss_Insert.Tables[1].Rows[i]["IGSTAmount"].ToString().TrimEnd().Replace(",", "");

                            if (IGST_AMT != "" && IGST_AMT != "0" && IGST_AMT != null && IGST_RATE != "" && IGST_RATE != null)
                            {
                                decimal Cal_TAXABLE_VALUE = (Convert.ToDecimal(IGST_AMT) / Convert.ToDecimal(IGST_RATE)) * 100;
                                TAXABLE_VALUE = Cal_TAXABLE_VALUE.ToString().Replace(",", "");
                            }
                        }
                    }
                    else if (COMPANY_IDD == "2118")
                    {
                        if (dss_Insert.Tables[1].Rows.Count == dt_ITEM.Rows.Count)
                        {
                            IGST_AMT = dss_Insert.Tables[1].Rows[i]["IGSTAmount"].ToString().TrimEnd().Replace(",", "");
                            TAXABLE_VALUE = dss_Insert.Tables[1].Rows[i]["TaxableAmount"].ToString().TrimEnd().Replace(",", "");
                        }
                    }

                    if (COMPANY_IDD == "470")//Info MSR
                    {
                        decimal Cal_Info_MSR = Convert.ToDecimal(InfoQty) / Convert.ToDecimal(Item_Qty);
                        InfoQty = Cal_Info_MSR.ToString("N5").Replace(",", "");
                    }

                    //Common - Info MSR
                    if (Qty_Cd == SQC || ((Qty_Cd == "NOS" || Qty_Cd == "SET" || Qty_Cd == "PCS") && (SQC == "NOS" || SQC == "SET" || SQC == "PCS")))
                    {
                        InfoQty = Item_Qty;
                    }


                    //#Item
                    Dt_Item.Rows.Add(Inv_SlNo, InvNo, Item_SlNo, Itemdesc, Item_Qty, Qty_Cd, Item_UnitPrice, Item_Amount, STATE_OF_ORIGIN, DISTRICT_OF_ORIGIN, UNDER_PTA_FTA, InfoQty, IGST_PAYMENT, IGST_RATE, Item_Desc_Customized,
                        SCHEME_CODE, STR_YES_NO, REWARD_YES_NO, RODTEP, CESS_YN, END_USE_OF_ITEM, ITEM_ACCESSORIES_DESC, dbk_decl, DBK_SL_NO, DBK_UNIT, RITCNO, SQC, TAXABLE_VALUE, IGST_AMT, ITEM_EXPORTER_NAME, BR_SLNO);

                    //***Drawback Details***//
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

                                Dt_DBK.Rows.Add(DBK_SL_NO, dbk_decl, DRAWBACK_RATE, DRAWBACK_VALUE_CAP, DRAWBACK_UNIT, DRAWBACK_NOOFUNITS, STATE_LEVEL_ADV_RATE, STATE_LEVEL_ADV_AMT, CENTRAL_LEVEL_ADV_RATE, CENTRAL_LEVEL_ADV_AMT);
                            }
                        }
                    }
                    DBK_SL_NO = ""; dbk_decl = "";
                }

                exp_pdf.EXPORTER_NAME = ViewState["exp_name"].ToString().Trim();
                exp_pdf.BRANCH_NO = ViewState["branch_slno"].ToString();
                exp_pdf.JOBNO = GENERAL_EXPORT_JOBNO;

                if (COMPANY_IDD == "100")
                {
                    COMMON_JOBNO_PS = txtjobPS.Text;
                }
                exp_pdf.JOBNO_PS = COMMON_JOBNO_PS;
                exp_pdf.COMAPANY_ID = COMPANY_IDD;
                exp_pdf.USER_ID = currentuser;
                exp_pdf.WORKINGPERIOD = Working_Period;
                exp_pdf.Branch_Code = currentbranch;
                exp_pdf.flag = "Insert_Desc";
                dss_Insert = exp_pdf.Exp_PDF_Upload_New_XML_AI(Dt_gen, Dt_Item, Dt_DBK, Dt_Invoice, Dt_anx, Dt_anx_Air, dt_ContainerDetails);

                if (exp_pdf.result == 1)
                {
                    Session["JOBIDexcel"] = dss_Insert.Tables[0].Rows[0][0].ToString();
                    lbl_loading.Text = "<span style='color: green; font-weight: bold;'>✅ Job Created Successfully...</span>";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popupChecklist", "showChecklistPopup();", true);

                    PageCount_log(PdfStatus.UPLOAD_SUCCESS, hd_PageCount.Value);
                    //con.Open();
                    //SqlCommand PScmd =
                    //    new SqlCommand(
                    //        "select * from PDF_AI_COUNT_DETAILS where PDF_JOB_NO = '" + txtjobPS.Text + "' and PDF_EXP_IMP_NAME='" + ViewState["exp_name"].ToString().Trim() + "' and PDF_BRANCH_CODE ='" + currentbranch + "'", con);
                    //SqlDataAdapter Psda = new SqlDataAdapter(PScmd);
                    //DataSet PSds = new DataSet();
                    //Psda.Fill(PSds);
                    //con.Close();
                    //con.Open();
                    //if (PSds.Tables[0].Rows.Count > 0)
                    //{
                    //    string PDF_ID = PSds.Tables[0].Rows[0]["PDF_ID"].ToString();
                    //    string PDF_SAVE_COUNT = PSds.Tables[0].Rows[0]["PDF_SAVE_COUNT"].ToString();
                    //    SqlCommand PUcmd =
                    //      new SqlCommand(
                    //          "Update PDF_AI_COUNT_DETAILS set PDF_SAVE_COUNT=('" + PDF_SAVE_COUNT + "'+1),PDF_USER_ID='" + currentuser + "',PDF_DATE_TIME=GetDate()," +
                    //    "PDF_STATUS='S',PDF_BRANCH_CODE='" + currentbranch + "',PDF_WORKING_PERIOD='" + Working_Period + "' where PDF_ID=" + PDF_ID + "", con);
                    //    int result = PUcmd.ExecuteNonQuery();
                    //    con.Close();
                    //}
                }
                else
                {
                    PageCount_log(PdfStatus.UPLOAD_FAILED, hd_PageCount.Value);
                    lbl_loading.Text = "Job error..";
                    Alert_msg("error..!");
                }
            }
        }
        catch (Exception ex)
        {
            PageCount_log(PdfStatus.UPLOAD_FAILED, hd_PageCount.Value);
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

        if (ds_con != null && ds_con.Tables.Count > 0 && ds_con.Tables[0].Rows.Count > 0)
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

        if (ds_con != null && ds_con.Tables.Count > 0 && ds_con.Tables[0].Rows.Count > 0)
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

                        if (sp[0] == PORT_FINAL_DEST.ToUpper())
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
        if (curr == "EURO" || curr == "Euro")
        {
            curr = "EUR";
        }
        if (curr == "US$" || curr == "US $" || curr == "USDN" || curr == "US" || curr == "US Dollar" || curr == "US DOLLAR")
        {
            curr = "USD";
        }
        if (curr == "Rs" || curr == "Rs.")
        {
            curr = "INR";
        }

        return curr;
    }

    private string Get_Valid_Qty_Code(string curr)
    {
        if (curr == "SETS" || curr == "Set")
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
        else if (curr == "PR" || curr == "PAIRS")
        {
            curr = "PRS";
        }
        else if (curr == "nos" || curr == "ECH" || curr == "Nos" || curr == "Nos." || curr == "In Nos." || curr == "In Nos" || curr == "EA" || curr == "SLABS" || curr == "NO" || curr == "IN Nos" || curr == "(nos)" || curr == "(In Nos.)" || curr == "Ea")
        {
            curr = "NOS";
        }
        else if (curr == "MT")
        {
            curr = "MTS";
        }
        else if (curr == "KG" || curr == "kgs")
        {
            curr = "KGS";
        }
        else if (curr == "£")
        {
            curr = "GBP";
        }
        return curr;
    }

    private string Get_Valid_Date1(string Dt)
    {
        Dt = Dt.Replace(".", "/").Replace("-", "/");
        string[] dd = Dt.Split('/');

        if (dd[0].Length != 2)
        {
            dd[0] = "0" + dd[0];
        }
        if (dd[1].Length != 2)
        {
            dd[1] = dd[1].Replace("Jan", "1").Replace("Feb", "2").Replace("Mar", "3").Replace("Apr", "4").Replace("May", "5").Replace("MAY", "5").Replace("Jun", "6").Replace("JUN", "6").Replace("July", "7").Replace("Oct", "10");
            dd[1] = "0" + dd[1];
        }
        if (dd[2].Length != 4)
        {
            dd[2] = "20" + dd[2];
        }

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
        "dd/MM/yyyy", "dd/MMM/yyyy", "MM/dd/yyyy", "MMM/dd/yyyy",
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
            //return parsedDate.ToString("MM/dd/yyyy");
            return parsedDate.ToString("dd/MM/yyyy");

        }

        // Try general parsing as fallback
        if (DateTime.TryParse(Dt, CultureInfo.InvariantCulture,
                              DateTimeStyles.AllowWhiteSpaces, out parsedDate))
        {
            //return parsedDate.ToString("MM/dd/yyyy");
            return parsedDate.ToString("dd/MM/yyyy");

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
                        if (txtDescription.Text != "")
                        {
                            TextBox txtItemDesc = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtItemDesc");
                            txtItemDesc.Text = txtDescription.Text;
                        }
                        if (txt_QtyCode.Text != "")
                        {
                            TextBox txtQtyCode = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtQtyCode");
                            txtQtyCode.Text = txt_QtyCode.Text;
                        }
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

            if (COMPANY_IDD != "2118")
            {
                txtDescription.Text = "";
                txt_QtyCode.Text = "";
                ddlSchemeCode.SelectedIndex = -1;
                txtRITCNo.Text = "";
                txtEnduseItem.Text = "";
                txt_PTA_FTA.Text = "";
                ddl_IGST_Payment.SelectedIndex = -1;
                txt_IGST_Rate.Text = "";
                txt_Drawback_SLNo.Text = "";
                txt_DBK_Unit.Text = "";
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
                                TextBox txtItemQty = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtItemQty");
                                TextBox txtQtyCode = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtQtyCode");
                                TextBox txtItemUnitPrice = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtItemUnitPrice");
                                TextBox txtItemAmt = (TextBox)gv_ItemPDF.Rows[i].FindControl("txtItemAmt");

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
                                GridViewData.Rows[j]["ITEM_QTY"] = txtItemQty.Text;
                                GridViewData.Rows[j]["ITEM_QTY_CODE"] = txtQtyCode.Text;
                                GridViewData.Rows[j]["ITEM_UNITPRICE"] = txtItemUnitPrice.Text;
                                GridViewData.Rows[j]["ITEM_AMOUNT"] = txtItemAmt.Text;
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
        if (dt_GridViewData != null && dt_GridViewData.Rows.Count > 0)
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
                //var uniqueRows = dt_GridViewData.AsEnumerable()
                //       .GroupBy(row => row["RITCNO"])
                //       .Select(group => group.First())
                //       .CopyToDataTable();

                var uniqueRows = dt_GridViewData.AsEnumerable()
                       .GroupBy(row => new { Invoice = row["INVOICE_SLNO"], Ritc = row["RITCNO"] })
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
                        //var uniqueRows = filteredTable.AsEnumerable()
                        //       .GroupBy(row => row["RITCNO"])
                        //       .Select(group => group.First())
                        //       .CopyToDataTable();

                        var uniqueRows = dt_GridViewData.AsEnumerable()
                      .GroupBy(row => new { Invoice = row["INVOICE_SLNO"], Ritc = row["RITCNO"] })
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
            //txtCountry.Enabled = false;
            //txtPort.Enabled = false;
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

    protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
    {
        con.Open();
        SqlCommand Exlcmd = new SqlCommand("select PDF_JOB_NO as 'JOB NO',PDF_EXP_IMP_NAME as 'EXP IMP NAME',PDF_MODE as MODE,PDF_UPLOAD_COUNT as 'UPLOAD COUNT',PDF_SAVE_COUNT as 'SAVE COUNT',PDF_REMARKS as 'PAGE COUNT',PDF_USER_ID as 'USER',PDF_DATE_TIME as 'DATE TIME',PDF_BRANCH_CODE as 'BRANCH CODE',PDF_WORKING_PERIOD as 'WORKING PERIOD' from PDF_AI_COUNT_DETAILS where PDF_MODE = 'EXP'", con);
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

    protected void txtConsigneeName_TextChanged(object sender, EventArgs e)
    {
        Bind_AdCode_Con();
    }

    public void Bind_AdCode_Con()
    {
        if (ViewState["exp_name"] != null && ViewState["exp_name"].ToString() == "BRAKES INDIA PRIVATE LIMITED")
        {
            DataTable ds_ADCODE = new DataTable();
            ds_ADCODE.Columns.Add("CONSIGNEE");
            ds_ADCODE.Columns.Add("ADCODE_IEC_ADCODE");

            ds_ADCODE.Rows.Add("ZF AUTOMOTIVE CZECH SRO", "0009999");
            ds_ADCODE.Rows.Add("SCHENKER LOGISTICS AB", "6470039");
            ds_ADCODE.Rows.Add("ZF ACTIVE SAFETY FRANCE", "0009999");
            ds_ADCODE.Rows.Add("DSV", "6470039");
            ds_ADCODE.Rows.Add("SONIMA AB", "6470039");
            ds_ADCODE.Rows.Add("D.M.BOWMAN UNC", "6470039");
            ds_ADCODE.Rows.Add("LARKIN EXPRESS LOGISTICS,LLC", "0510004");
            ds_ADCODE.Rows.Add("FRENOS Y MECANISMOS S DE REL DE CV", "0009999");
            ds_ADCODE.Rows.Add("ZF Active Safety GmbH", "0009999");
            ds_ADCODE.Rows.Add("ZF Automotive UK Limited", "0009999");
            ds_ADCODE.Rows.Add("Meritor HVBS (UK) Ltd.,", "0009999");
            ds_ADCODE.Rows.Add("BMTS TECHNOLOGY GMBH & CO.KG", "0009999");

            string consigneeName = txtConsigneeName.Text.Trim();
            var matchingRows = ds_ADCODE.AsEnumerable()
                .Where(row => string.Equals(row["CONSIGNEE"].ToString().Trim(), consigneeName, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (matchingRows.Any())
            {
                DataTable filteredTable = ds_ADCODE.Clone(); // Create structure
                filteredTable.ImportRow(matchingRows[0]);    // Add the first matched row

                ddlAdCode.DataSource = filteredTable;
                ddlAdCode.DataTextField = "ADCODE_IEC_ADCODE";
                ddlAdCode.DataTextField = "ADCODE_IEC_ADCODE";
                ddlAdCode.DataBind();
            }
            else
            {
                ddlAdCode.Items.Clear();
            }
        }
    }

    public void Bind_DrawBack_Unit_HsCode(string Get_HS_CODE, out string dbkCode, out string sqc)
    {
        dbkCode = string.Empty;
        sqc = string.Empty;

        if (ViewState["exp_name"].ToString() == "BRAKES INDIA PRIVATE LIMITED")
        {
            DataTable ds_Draw_Unit_Hs = new DataTable();
            ds_Draw_Unit_Hs.Columns.Add("HS_CODE");
            ds_Draw_Unit_Hs.Columns.Add("DBK_CODE");
            ds_Draw_Unit_Hs.Columns.Add("SQC");

            ds_Draw_Unit_Hs.Rows.Add("73259910", "732599B", "NOS");
            ds_Draw_Unit_Hs.Rows.Add("87089900", "870899B", "NOS");
            ds_Draw_Unit_Hs.Rows.Add("87083000", "870803B", "NOS");
            ds_Draw_Unit_Hs.Rows.Add("84099990", "840999B", "NOS");
            ds_Draw_Unit_Hs.Rows.Add("84833000", "8483B",   "NOS");
            ds_Draw_Unit_Hs.Rows.Add("84149090", "841499B", "NOS");

            string Filter_HS_CODE = Get_HS_CODE.Trim();
            var matchingRow = ds_Draw_Unit_Hs.AsEnumerable()
                .FirstOrDefault(row => string.Equals(row["HS_CODE"].ToString().Trim(), Filter_HS_CODE, StringComparison.OrdinalIgnoreCase));

            if (matchingRow != null)
            {
                dbkCode = matchingRow["DBK_CODE"].ToString();
                sqc = matchingRow["SQC"].ToString();
            }
        }
        else if (ViewState["exp_name"].ToString() == "DENSO KIRLOSKAR INDUSTRIES PVT LTD.,")
        {
            DataTable ds_Draw_Unit_Hs = new DataTable();
            ds_Draw_Unit_Hs.Columns.Add("HS_CODE");
            ds_Draw_Unit_Hs.Columns.Add("DBK_CODE");
            ds_Draw_Unit_Hs.Columns.Add("SQC");

            ds_Draw_Unit_Hs.Rows.Add("76082000", "7608B", "PCS");
            ds_Draw_Unit_Hs.Rows.Add("39269099", "392699B", "PCS");
            ds_Draw_Unit_Hs.Rows.Add("84159000", "8415B", "PCS");
            ds_Draw_Unit_Hs.Rows.Add("83025000", "830299B", "PCS");
            ds_Draw_Unit_Hs.Rows.Add("87089900", "870899B", "PCS");
            ds_Draw_Unit_Hs.Rows.Add("73269099", "732699B", "PCS");

            string Filter_HS_CODE = Get_HS_CODE.Trim();
            var matchingRow = ds_Draw_Unit_Hs.AsEnumerable()
                .FirstOrDefault(row => string.Equals(row["HS_CODE"].ToString().Trim(), Filter_HS_CODE, StringComparison.OrdinalIgnoreCase));

            if (matchingRow != null)
            {
                dbkCode = matchingRow["DBK_CODE"].ToString();
                sqc = matchingRow["SQC"].ToString();
            }
        }
    }

    private static string RemoveWordsWithSpecialChars(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return input;

        // Split into words safely (compatible with older .NET)
        var words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        // Remove words containing any non-alphanumeric or non-hyphen characters
        var cleanWords = words.Where(w => !Regex.IsMatch(w, @"[^a-zA-Z0-9\-]")).ToList();

        return string.Join(" ", cleanWords);
    }

    public string Get_PdfClientName(string exp_name, string Branch_no)
    {
        String Return_Pdf_client_name = "";
        DataSet ds_pdf = new DataSet();
        erm.EExp_cli_mas_id = "0";
        erm.Ename = "FETCH_PDF_CLIENT_NAME";
        erm.EExp_client_iec_name = exp_name;
        erm.EXP_CLIENT_BRANCH_SLNO = Branch_no;
        erm.EWorking_Period = Working_Period;

        ds_pdf = erm.RetrieveAll_Exp_Client_Master();

        if (ds_pdf.Tables[0].Rows.Count > 0)
        {
            Return_Pdf_client_name = ds_pdf.Tables[0].Rows[0]["EXP_PDF_CLIENT_NAME"].ToString();
        }

        else
        {
            Return_Pdf_client_name = "";
        }

        return Return_Pdf_client_name;
    }
    public string SafeNumber(object value)
    {
        string val = value == null ? "" : value.ToString().Trim().Replace(",", "");

        if (string.IsNullOrWhiteSpace(val) || val.Equals("N/A", StringComparison.OrdinalIgnoreCase) ||
            val.Equals("NULL", StringComparison.OrdinalIgnoreCase))
            return "0";

        return val;
    }
    public DataSet Get_Default_Annexure_Details(string Exporter, string Branch)
    {
        DataSet das = new DataSet();
        erm.Ename = "FETCH_MASTER_DATA";
        erm.Exp_Imp_Name = Exporter;
        erm.IMP_CLIENT_BRANCH_SLNO = Branch;
        das = erm.OCR_ANNEXURE_DEFAULT_MASTER();
        return das;
    }
    public string GetValueOrDefault(object dbValue, string defaultVal)
    {
        string val = dbValue == DBNull.Value ? "" : dbValue.ToString();
        return string.IsNullOrEmpty(val) ? defaultVal : val;
    }
    public int PageCount_log(string Status, string pagecounts)
    {
        try
        {
            int PDF_ID = 0;
            int pdf_id = 0;
            if (ViewState["Pdf_Id"] != null)
            {
                int.TryParse(ViewState["Pdf_Id"].ToString(), out pdf_id);
            }

            string exp_name = ViewState["exp_name"] != null ? ViewState["exp_name"].ToString().Trim() : "";
            ds_Page.PDF_JOB_NO = JOB_NUMBER();
            ds_Page.PDF_ID = pdf_id.ToString();
            ds_Page.Ename = "";
            ds_Page.PDF_EXP_IMP_NAME = exp_name;
            ds_Page.PDF_MODE = "EXP";
            ds_Page.PDF_USER_ID = currentuser;
            ds_Page.PDF_STATUS = Status;
            ds_Page.PDF_UPLOAD_COUNT = Upload_Count;
            ds_Page.PDF_BRANCH_CODE = currentbranch;
            ds_Page.PDF_WORKING_PERIOD = Working_Period;
            ds_Page.PAGE_COUNT = string.IsNullOrEmpty(pagecounts) ? "0" : pagecounts;
            ds_Page.PDF_SAVE_COUNT = (Status == PdfStatus.UPLOAD_SUCCESS) ? "1" : "0";
            ds_Page.PDF_SUCCESS_UPLOAD_COUNT = (Status == PdfStatus.PREVIEW_SUCCESS) ? Upload_page_Count : "0";
            ds_Page.PDF_ERROR_UPLOAD_COUNT = (Status == PdfStatus.PREVIEW_FAILED) ? Upload_Error_Count : "0";

            PDF_ID = ds_Page.OCR_PDF_COUNT_UPDATE_INSERT();

            return PDF_ID;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return 0;
        }
    }
    public static class PdfStatus
    {
        public const string PREVIEW_INITIATED = "PREVIEW INITIATED";
        public const string PREVIEW_SUCCESS = "PREVIEW SUCCESS";
        public const string PREVIEW_FAILED = "PREVIEW FAILED";
        public const string UPLOAD_INITIATED = "UPLOAD INITIATED";
        public const string UPLOAD_SUCCESS = "UPLOAD SUCCESS";
        public const string UPLOAD_FAILED = "UPLOAD FAILED";
    }
    public string JOB_NUMBER()
    {
        string JOBNOS = "";
        Export.BRANCH_CODE = Connection.Get_Company_Type();
        Export.WORKING_PERIOD = Connection.WorkingPeriod();
        JOBNOS = Convert.ToString(Export.Retrieve_JobNO());

        return JOBNOS;
    }

}