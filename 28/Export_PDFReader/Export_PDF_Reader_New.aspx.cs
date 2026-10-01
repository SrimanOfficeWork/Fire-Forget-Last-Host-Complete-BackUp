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
using System.Configuration;
using System.Web.Script.Serialization;
using System.Collections;
using System.Text.RegularExpressions;




public partial class Export_PDF_Reader_New : ThemeClass
{
    AppSession aps = new AppSession();
    UserBO ObjUBO = new UserBO();
    Export_General_New Export = new Export_General_New();
    UserBO objUBO = new UserBO();
    AdminMasterDetails admin = new AdminMasterDetails();
    Jobwise_xl_Upload xl = new Jobwise_xl_Upload();
    Export_PDF_Upload exp_pdf = new Export_PDF_Upload();
    eroyalmaster erm = new eroyalmaster();
    Auto_Search Auto = new Auto_Search();
    ErrorLogs log = new ErrorLogs();

    DataTable Dt_gen = new DataTable();
    DataTable Dt_Invoice = new DataTable();
    DataTable Dt_Item = new DataTable();
    DataTable Dt_DBK = new DataTable();
    DataTable Dt_anx = new DataTable();

    DataSet ds_IEC = new DataSet();
    DataSet ds_draw = new DataSet();

    public String Xml_Inv;

    public int MAX_ID = 0;

    public string GENERAL_EXPORT_JOBNO = "";
    public string currentuser;
    public string currentbranch;
    public string Working_Period;
    public string COMPANY_IDD, comp_ConnectionStr, LoginDate, SB_TYPE, JOBNO, TRANSPORT_MODE;

    //**************************************//
    DataSet ds_OrderDetails = null;
    string ds_lkupDetails = string.Empty;
    //**************************************//


    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        //TRANSPORT_MODE = Session["Transport_Mode_Port"].ToString();

        //SB_TYPE = Session["EXPORT_SBTYPE"].ToString();
        COMPANY_IDD = Session["COMPANY_ID"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();



        // Initialize the export Job No once and keep the same value across postbacks.
        // If the calling page already supplied Jobno_Excel, use that value.
        // Otherwise generate the next export Job No using the existing AUTO_JOBNO() logic.
        if (!IsPostBack)
        {
            string sessionJobNo = Session["Jobno_Excel"] != null
                ? Session["Jobno_Excel"].ToString().Trim()
                : string.Empty;

            if (!string.IsNullOrWhiteSpace(sessionJobNo))
            {
                GENERAL_EXPORT_JOBNO = sessionJobNo;
            }
            else
            {
                AUTO_JOBNO();
                GENERAL_EXPORT_JOBNO = !string.IsNullOrWhiteSpace(hdn_JOBNO_PS.Value)
                    ? hdn_JOBNO_PS.Value.Trim()
                    : JOBNO;
            }

            ViewState["GENERAL_EXPORT_JOBNO"] = GENERAL_EXPORT_JOBNO;
        }
        else
        {
            GENERAL_EXPORT_JOBNO = Convert.ToString(ViewState["GENERAL_EXPORT_JOBNO"]);
        }

        txtjobPS.Text = GENERAL_EXPORT_JOBNO;
        //hdfTransport_mode.Value = Session["hdfTransport_mode"].ToString();
        string TRANS_MODE = Session["CUSTOMHOUSE_TRANSPORT_MODE"].ToString();
        if (TRANS_MODE == "A") TRANSPORT_MODE = "Air";
        else if (TRANS_MODE == "S") TRANSPORT_MODE = "Sea";
        else if (TRANS_MODE == "L") TRANSPORT_MODE = "Land";

        hdfTransport_mode.Value = TRANSPORT_MODE;
        Hdn_STANDARD_TYPE.Value = "STD";
        btnupload.Visible = true;
        Tbl_Columns();
        if (!IsPostBack)
        {
            Bind_Clients();

        }

    }

    public void Bind_Clients()
    {
        DataSet ds_client = new DataSet();
        exp_pdf.JOBNO = JOBNO;
        exp_pdf.flag = "Bind_Exporter_List";
        exp_pdf.USER_ID = currentuser;
        exp_pdf.WORKINGPERIOD = Working_Period;
        exp_pdf.Branch_Code = currentbranch;
        ds_client = exp_pdf.Exp_PDF_Upload_New_XML(Dt_gen, Dt_Item, Dt_DBK, Dt_Invoice, Dt_anx);

        if (ds_client.Tables[0].Rows.Count > 0)
        {
            ddl_ExporterName.DataSource = ds_client.Tables[0];
            ddl_ExporterName.DataTextField = "EXPORTER_NAME";
            ddl_ExporterName.DataTextField = "EXPORTER_NAME";
            ddl_ExporterName.DataBind();
        }

        if (txtBuyer.Text == "")
        {
            txtBuyer.Text = "SAME AS CONSIGNEE";
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
        //Dt_gen.Columns.Add("JOB_PREFIX");
        //Dt_gen.Columns.Add("JOB_SUFFIX");
        //Dt_gen.Columns.Add("JOBNO_PS");


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
        try
        {
            DataSet ds_gv_Output = new DataSet();

            //decimal myDecimalValue = Decimal.Parse("2.2910230267e+011", System.Globalization.NumberStyles.Float);
            //string sss = Convert.ToString(myDecimalValue);


            string exp_name = "", branch_slno = "";
            if (ddl_ExporterName.SelectedValue.Contains("--"))
            {
                string[] sp = ddl_ExporterName.SelectedValue.Replace("--", "^").Split('^');
                branch_slno = sp[0];
                exp_name = sp[1];

                ViewState["branch_slno"] = branch_slno;
                ViewState["exp_name"] = exp_name;

            }

            ds_gv_Output = PDF_Convert_xlsx_to_Datatable(exp_name, branch_slno);

            //if (ViewState["exp_name"] != null && ViewState["exp_name"].ToString() == "KPR SUGAR AND APPARELS LIMITED~PRIMARK TIENDAS SLU")
            //{
            //    ViewState["exp_name"] = "KPR SUGAR AND APPARELS LIMITED";
            //} 
            
            txtConsigneeName.Text = ds_gv_Output.Tables[0].Rows[0]["ConsigneeName"].ToString().Replace("Consignee ", "");

            if (ds_gv_Output.Tables[0].Rows[0]["BuyerName"].ToString() != "")
            {
                txtBuyer.Text = ds_gv_Output.Tables[0].Rows[0]["BuyerName"].ToString();
            }
            else
            {
                txtBuyer.Text = "SAME AS CONSIGNEE";
            }

            DataTable dt_gvew = new DataTable();
            dt_gvew.Columns.Add("ITEM_SLNO");
            dt_gvew.Columns.Add("ITEM_DESC");
            dt_gvew.Columns.Add("ITEM_QTY");
            dt_gvew.Columns.Add("ITEM_QTY_CODE");
            dt_gvew.Columns.Add("ITEM_UNITPRICE");
            dt_gvew.Columns.Add("ITEM_UNITCODE");
            dt_gvew.Columns.Add("ITEM_AMOUNT");

            foreach (DataColumn col in ds_gv_Output.Tables[1].Columns)
            {
                if (col.ColumnName.Contains("Kind"))
                {
                    ds_gv_Output.Tables[1].Columns[col.ColumnName].ColumnName = "NO_KIND_PKGS";
                }
                if (col.ColumnName.Contains("Description") || col.ColumnName.Contains("Goods"))
                {
                    ds_gv_Output.Tables[1].Columns[col.ColumnName].ColumnName = "ITEM_DESC";
                }
                if (exp_name == "MAF CLOTHING PRIVATE LIMITED" && col.ColumnName.Contains("Total"))
                {
                    ds_gv_Output.Tables[1].Columns[col.ColumnName].ColumnName = "ITEM_QTY";
                }
                else if (col.ColumnName.Contains("Quantity"))
                {
                    ds_gv_Output.Tables[1].Columns[col.ColumnName].ColumnName = "ITEM_QTY";
                }
                if ((col.ColumnName.Contains("Rate") || col.ColumnName.Contains("Unit") || col.ColumnName.Contains("Price")) && !col.ColumnName.Contains("Info_Unitprice"))
                {
                    ds_gv_Output.Tables[1].Columns[col.ColumnName].ColumnName = "ITEM_UNITPRICE";
                }
                if (exp_name == "MAF CLOTHING PRIVATE LIMITED" && col.ColumnName.Contains("Invoice"))
                {
                    ds_gv_Output.Tables[1].Columns[col.ColumnName].ColumnName = "ITEM_AMOUNT";
                }
                else if (col.ColumnName.Contains("Total") || col.ColumnName.Contains("Amount"))
                {
                    ds_gv_Output.Tables[1].Columns[col.ColumnName].ColumnName = "ITEM_AMOUNT";
                }

            }
            //log.makeLog("col.ColumnName.Contains");

            string desc = "", hanger_qty = "";

            for (int cc = 0; cc <= ds_gv_Output.Tables[1].Rows.Count - 1; cc++)
            {

                if (ds_gv_Output.Tables[0].Rows[0]["client"].ToString() == "6_SHAHI")
                {
                    desc = ds_gv_Output.Tables[1].Rows[cc]["ITEM_DESC"].ToString() != string.Empty ? ds_gv_Output.Tables[1].Rows[cc]["ITEM_DESC"].ToString() : ds_gv_Output.Tables[1].Rows[cc]["NO_KIND_PKGS"].ToString();

                    int x = desc.IndexOf(" (DBK SL#");

                    if (x > 0)
                    {
                        desc = desc.Substring(0, x);
                    }
                }
                else
                {
                    if (exp_name == "MAF CLOTHING PRIVATE LIMITED")
                    {
                        if (ds_gv_Output.Tables[1].Rows[cc]["ITEM_DESC"].ToString() == "HANGER COST" || ds_gv_Output.Tables[1].Rows[cc]["ITEM_DESC"].ToString() == "GOODS ARE PACKED WITH HANGER")
                        {
                            desc = "HANGER";
                            //if (ds_gv_Output.Tables[1].Rows[cc]["InfoUnitPrice"].ToString() != "")
                            //{
                            //    Item_UnitPrice = ds_gv_Output.Tables[1].Rows[cc]["InfoUnitPrice"].ToString();
                            //}
                        }
                        else if (ds_gv_Output.Tables[1].Rows[cc]["ITEM_DESC"].ToString().Contains("WITH HANGER"))
                        {
                            string splitword = "WITH HANGER";
                            desc = ds_gv_Output.Tables[1].Rows[cc]["ITEM_DESC"].ToString().Substring(0, ds_gv_Output.Tables[1].Rows[cc]["ITEM_DESC"].ToString().IndexOf(splitword));
                        }
                        else
                        {
                            desc = ds_gv_Output.Tables[1].Rows[cc]["ITEM_DESC"].ToString();
                        }
                    }
                    else
                    {
                        desc = ds_gv_Output.Tables[1].Rows[cc]["NO_KIND_PKGS"].ToString() != string.Empty ? ds_gv_Output.Tables[1].Rows[cc]["NO_KIND_PKGS"].ToString() : ds_gv_Output.Tables[1].Rows[cc]["ITEM_DESC"].ToString();
                    }
                }

                //hanger_qty = ds_gv_Output.Tables[1].Rows[cc]["ITEM_DESC"].ToString().Contains("HANGER") ? "KGS" : ds_gv_Output.Tables[0].Rows[0]["Qtycode"].ToString();

                //Get Qty Code from Item Details Method - Tables[1]
                hanger_qty = ds_gv_Output.Tables[1].Rows[cc]["ITEM_DESC"].ToString().Contains("HANGER") ? "KGS" : ds_gv_Output.Tables[1].Rows[0]["ITEM_QTY"].ToString();

                //string ItemQty = ds_gv_Output.Tables[1].Rows[0]["ITEM_QTY"].ToString();


                if (hanger_qty.Contains(" "))
                {
                    string[] hq = hanger_qty.Split(' ');
                    hanger_qty = hq[1];
                }
                else
                {
                    hanger_qty = ds_gv_Output.Tables[0].Rows[0]["Qtycode"].ToString();
                }

                if (ViewState["exp_name"] != null && ViewState["exp_name"].ToString().Contains("~"))
                {
                    string exporter_name = ViewState["exp_name"].ToString();
                    ViewState["exp_name"] = exporter_name.Split('~')[0].Trim();
                    exp_name = ViewState["exp_name"].ToString();
                } 


                dt_gvew.Rows.Add(cc + 1, desc, ds_gv_Output.Tables[1].Rows[cc]["ITEM_QTY"].ToString().Replace("(", "").Replace(")", "").Replace("NOS", "").Replace("KGS", "").Replace(" ", ""), Get_Valid_Qty_Code(hanger_qty)
                    , ds_gv_Output.Tables[1].Rows[cc]["ITEM_UNITPRICE"].ToString().Replace("-", "") == "" ? ds_gv_Output.Tables[1].Rows[cc][ds_gv_Output.Tables[1].Columns.IndexOf("ITEM_UNITPRICE") + 1].ToString() : ds_gv_Output.Tables[1].Rows[cc]["ITEM_UNITPRICE"].ToString().Replace("-", "")//IndexOf("ITEM_UNITPRICE") + 1 for Hanger desc
                    , ds_gv_Output.Tables[0].Rows[0]["Currency"].ToString(), ds_gv_Output.Tables[1].Rows[cc]["ITEM_AMOUNT"].ToString());
            }


            DataTable dt_dbk = new DataTable();
            dt_dbk.Columns.Add("DBK_SLno");

            DataSet ds_except = new DataSet();
            exp_pdf.EXPORTER_NAME = exp_name;
            exp_pdf.BRANCH_NO = branch_slno;
            exp_pdf.JOBNO = JOBNO;
            exp_pdf.flag = "Select_Except_desc_from_Master";
            exp_pdf.USER_ID = currentuser;
            exp_pdf.WORKINGPERIOD = Working_Period;
            exp_pdf.Branch_Code = currentbranch;
            ds_except = exp_pdf.Exp_PDF_Upload_New_XML(Dt_gen, dt_gvew, dt_dbk, Dt_Invoice, Dt_anx);

            if (ds_except.Tables[0].Rows.Count > 0)
            {
                lbl_loading.Text = "Records not available in Master";
                hdn_missed_Desc.Value = "1";
                gv_ItemPDF.DataSource = ds_except.Tables[0];
                gv_ItemPDF.DataBind();
                btnupload.Visible = false;
                //btnupload.Visible = true;
            }
            else
            {
                // get DBK SLno List from PDF
                lbl_loading.Text = "File converted successfully..Click Upload";
                exp_pdf.flag = "Get_DBK_slno_List";
                ds_except = exp_pdf.Exp_PDF_Upload_New_XML(Dt_gen, dt_gvew, dt_dbk, Dt_Invoice, Dt_anx);
                hdn_missed_Desc.Value = "0";
                btnupload.Visible = true;

                if (ds_except.Tables[0].Rows.Count > 0)
                {
                    Auto.Ename = "DRAWBACK_MASTER_ALL_Excel_Upload";
                    Auto.Enamesearch = ds_except.Tables[0].Rows[0]["Dbkslno"].ToString();
                    Auto.Notn_No_Search = "";
                    ds_draw = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
                }

                ViewState["Dt_draw"] = ds_draw.Tables[0];


                gv_ItemPDF.DataSource = dt_gvew;
                gv_ItemPDF.DataBind();
            }

            ViewState["ds_xl_Output"] = ds_gv_Output;


            /* -- Its for bulk pdf file read  from folder
            FileInfo[] Files = d.GetFiles("*.pdf"); //Getting Text files 
            foreach (FileInfo file in Files)
            {
                // Load PDF document
                Document pdfDocument = new Document(newFile);
                ExcelSaveOptions options = new ExcelSaveOptions();
                //string fNamewithoutex = Path.GetFileNameWithoutExtension(file.NamenewFile);
                string fNamewithoutex = Path.GetFileNameWithoutExtension(newFile);
                // Save output file
                //pdfDocument.Save("F:/Babu/Pdfreader/pdfconvert/Output/" + fNamewithoutex + ".xls", options);
                pdfDocument.Save(savePath + fNamewithoutex + ".xls", options);
            }

            */

            //lblmsg.Text = "File converted successfully..";
            //}
        }
        catch (Exception ex)
        {
            log.makeLog("Message ==> " + ex.Message);
            lblmsg.Text = " Message ==> " + ex.Message + " InnerException ==> " + ex.InnerException + " StackTrace ==>" + ex.StackTrace;
        }
    }

    public string Get_Valid_State_Name()
    {
        string result = string.Empty;
        try
        {
           
            DataSet ds_con = new DataSet();


            erm.PDF_PORTNAME = ViewState["exp_name"].ToString();
            erm.PORT_NAME = "";
            erm.PORT_CODE = ViewState["branch_slno"].ToString();
            erm.COUNTRY_CODE = "";
            erm.Ename = "select_Client_Marks_Nos_Details";

            ds_con = erm.PDF_PORT_MASTER_Insert_update_Search();


            if (ds_con.Tables[0].Rows.Count > 0)
            {
                result = ds_con.Tables[0].Rows[0]["MARKS_NO"].ToString();
            }
            
        }
        catch (Exception ex)
        {
        }
        return result;
    }
    protected void btnupload_Click(object sender, EventArgs e)
    {
        try
        {

            DataSet dss_Insert = new DataSet();
            dss_Insert = (DataSet)ViewState["ds_xl_Output"];

            string AUTHORIZED_ECONOMIC_OPERATOR_CODE = "", A_E_O_COUNTRY = "", AUTHORIZED_ECONOMIC_OPERATOR = "", ADCODE = "", IGST_PAYMENT = "", IGST_RATE = "", marksnos = "", CONTRCT_NO = "";
            string PAYMENT_METHOD = "NA", PERIOD_PAYMENT = "";
            string STATE_OF_ORIGIN = "";
            string DISTRICT_OF_ORIGIN = "";

            string[] contract = dss_Insert.Tables[0].Rows[0]["byerOdrNo"].ToString().TrimStart().Split(' ', '\t');
            CONTRCT_NO = contract[0];


            string[] trms = dss_Insert.Tables[0].Rows[0]["trmsOfPyt"].ToString().Replace("PAYMENT", "").Replace("TRADE CARD", "TRADE").Split(' ', '\t');

            if (trms.Count() > 1)
            {
                PERIOD_PAYMENT = trms[1];

                if (trms[0].Contains("TT"))
                {
                    PAYMENT_METHOD = "NA";
                }
            }

            if (dss_Insert.Tables[0].Rows[0]["client"].ToString() == "6_SHAHI")
            {
                //AUTHORIZED_ECONOMIC_OPERATOR_CODE = dss_Insert.Tables[0].Rows[0]["AEOcode"].ToString().Trim();
                //A_E_O_COUNTRY = "IN";
                //AUTHORIZED_ECONOMIC_OPERATOR = "T3";

                AUTHORIZED_ECONOMIC_OPERATOR_CODE = "";
                A_E_O_COUNTRY = "";
                AUTHORIZED_ECONOMIC_OPERATOR = "";
                ADCODE = dss_Insert.Tables[0].Rows[0]["ADcode"].ToString().Trim();
                IGST_PAYMENT = dss_Insert.Tables[0].Rows[0]["IGST_Payment_Status"].ToString().Trim();
                IGST_RATE = dss_Insert.Tables[0].Rows[0]["IGST_Rate"].ToString().Trim();
                CONTRCT_NO = "CINo:" + CONTRCT_NO + " Dt:" + dss_Insert.Tables[0].Rows[0]["byerOdr_Dt"].ToString();
                PAYMENT_METHOD = "DP";
                STATE_OF_ORIGIN = "29-KARNATAKA";
                DISTRICT_OF_ORIGIN = "525-BENGALURU URBAN";

                if (trms[0].Contains("TRADE"))
                {
                    PAYMENT_METHOD = "LC";
                }

                if (IGST_PAYMENT != "")
                {
                    IGST_PAYMENT = "P";
                    marksnos = "AEO CODE:" + dss_Insert.Tables[0].Rows[0]["AEOcode"].ToString().Trim() + "/IN/T3" + AUTHORIZED_ECONOMIC_OPERATOR + ".WE INTEND TO CLAIM REWARDS UNDER ROSCTL/RODTEP.";
                }
                else
                {
                    IGST_PAYMENT = "LUT";
                    //marksnos = "(LUT ARN NO: AD2903230047646 DT: 06-03-2023)" + "AEO CODE:" + AUTHORIZED_ECONOMIC_OPERATOR_CODE + "/" + A_E_O_COUNTRY + "/" + AUTHORIZED_ECONOMIC_OPERATOR + ".WE INTEND TO CLAIM REWARDS UNDER ROSCTL/RODTEP.";
                    marksnos = "(LUT ARN NO: AD2903230047646 DT: 06-03-2023)" + "AEO CODE:" + dss_Insert.Tables[0].Rows[0]["AEOcode"].ToString().Trim() + "/IN/T3" + AUTHORIZED_ECONOMIC_OPERATOR + ".WE INTEND TO CLAIM REWARDS UNDER ROSCTL/RODTEP.";
                }

            }
            //|| dss_Insert.Tables[0].Rows[0]["client"].ToString() == "3_KPR"
            else if (dss_Insert.Tables[0].Rows[0]["client"].ToString() == "0_SP_APPARELS" )
            {
                string master_marksnos = Get_Valid_State_Name();
                STATE_OF_ORIGIN = "33-TAMIL NADU";
                DISTRICT_OF_ORIGIN = "634-TIRUPPUR";
                marksnos = "CTN NO:" + dss_Insert.Tables[0].Rows[0]["ctnno"].ToString().Trim().Replace("CTN NO:", "").Replace("CTN No :", "") + " ORDER NO:" + CONTRCT_NO.Trim() + " KIMBALL NO:"
                    + dss_Insert.Tables[0].Rows[0]["ohrRef"].ToString().Trim() +" "+ master_marksnos;
            }
            else if ("KPR SUGAR AND APPARELS LIMITED" == ViewState["exp_name"].ToString())
            {
                //string master_marksnos = Get_Valid_State_Name();
                STATE_OF_ORIGIN = "33-TAMIL NADU";
                DISTRICT_OF_ORIGIN = "634-TIRUPPUR";
                //marksnos = "CTN NO:" + dss_Insert.Tables[0].Rows[0]["ctnno"].ToString().Trim().Replace("CTN NO:", "").Replace("CTN No :", "") + " ORDER NO:" + CONTRCT_NO.Trim() + " KIMBALL NO:" + dss_Insert.Tables[0].Rows[0]["ohrRef"].ToString().Trim() + " SUPPLY MEANT FOR EXPORT ON PAYMENT OF IGST \" \" "+ "WE INTEND TO CLAIM REWARDS UNDER ROSCTL";
                marksnos = "LUT. NO:ARN NO:AD330326079525Y DATE:25/03/2026 SUPPLY MEANT FOR EXPORT UNDERTAKING WITHOUT PAYMENT OF INTEGRATED TAX \"WE INTEND TO CLAIM REWARDS UNDER ROSCTL.\"";
            }

            else if ("MAF CLOTHING PRIVATE LIMITED" == ViewState["exp_name"].ToString())
            {
                string[] trms1 = dss_Insert.Tables[0].Rows[0]["trmsOfPyt"].ToString().Replace("PAYMENT", "").Replace("TRADE CARD", "TRADE").Split(' ', '\t');

                if (trms1.Count() > 1)
                {
                    if (trms1[0].Contains("TT"))
                    {
                        PAYMENT_METHOD = "NA";
                    }
                    else if (trms1[0].Contains("D/A"))
                    {
                        PAYMENT_METHOD = "DA";
                    }
                    else
                    {
                        PAYMENT_METHOD = trms1[0].Trim();
                    }
                }
                else
                {
                    PAYMENT_METHOD = dss_Insert.Tables[0].Rows[0]["trmsOfPyt"].ToString();
                }
                marksnos = "CTN NO:" + dss_Insert.Tables[0].Rows[0]["ctnno"].ToString().Trim().Replace("CTN NO:", "").Replace(" ", "").Replace("TO", "-") + " ORDER NO:" + CONTRCT_NO.Trim() + " KIMBALL NO:" + dss_Insert.Tables[0].Rows[0]["ohrRef"].ToString().Trim() + "";
            }
            else
            {
                marksnos = "WE INTEND TO CLAIM REWARDS UNDER MERCHANDISE EXPORTS FROM INDIA SCHEME";
            }


            string state_export = "TAMIL NADU";

            string Country_name = Get_Valid_Country_Name(dss_Insert.Tables[0].Rows[0]["cntyDec"].ToString().Trim());
            string Port_name = "";

            if (Country_name.Contains('-'))
            {
                string[] county_code = Country_name.Split('-');
                Country_name = county_code[0];
                Port_name = Get_Valid_Port_Name_Code(dss_Insert.Tables[0].Rows[0]["prtOfDschrg"].ToString().Trim(), county_code[1]);
            }
            else
            {
                Port_name = dss_Insert.Tables[0].Rows[0]["prtOfDschrg"].ToString().Trim();
            }

            /*
                string prtOfDschrg = Get_Valid_Country_Portcode(dss_Insert.Tables[0].Rows[0]["cntyDec"].ToString().Trim(), dss_Insert.Tables[0].Rows[0]["prtOfDschrg"].ToString().Trim());
                string[] county_port = prtOfDschrg.Split('^');
            */

            Dt_gen.Rows.Add(ViewState["exp_name"].ToString(), ViewState["branch_slno"].ToString(), txtConsigneeName.Text, "", hdfTransport_mode.Value, Session["CUSTOMHOUSE_CODE"].ToString(),
                             Country_name, Port_name, Country_name, Port_name, state_export, marksnos, ADCODE);


            string BUYER = "N";
            if (txtBuyer.Text == "SAME AS CONSIGNEE")
            {
                BUYER = "Y";
            }

            /*
            string[] trms = dss_Insert.Tables[0].Rows[0]["trmsOfPyt"].ToString().Replace("PAYMENT","").Split(' ', '\t');
            if (trms.Count() > 1)
            {
                PERIOD_PAYMENT = trms[1];

                if (trms[0].Contains("TT"))
                {
                    PAYMENT_METHOD = "NA";
                }
            }
            */

            string curr = Get_Valid_Curr_Name(dss_Insert.Tables[0].Rows[0]["Currency"].ToString().Trim());
            string invdt = Get_Valid_Date(dss_Insert.Tables[0].Rows[0]["invDate"].ToString().Trim().Replace(".", "/").Replace("-", "/"));
            string InvNo = "";
            if (dss_Insert.Tables[0].Rows[0]["invNo"].ToString().Contains("+"))
            {
                InvNo = ViewState["fileNamewithoutextn"].ToString();
            }
            else
            {
                InvNo = dss_Insert.Tables[0].Rows[0]["invNo"].ToString();
            }

            Dt_Invoice.Rows.Add("1", InvNo, invdt.Trim(), PAYMENT_METHOD, PERIOD_PAYMENT,
                        dss_Insert.Tables[0].Rows[0]["inv_val"].ToString().Replace(",",""), curr, Get_ExchangeRate(curr), CONTRCT_NO, dss_Insert.Tables[0].Rows[0]["Terms"].ToString(), BUYER, txtBuyer.Text, AUTHORIZED_ECONOMIC_OPERATOR_CODE, A_E_O_COUNTRY, AUTHORIZED_ECONOMIC_OPERATOR);

            //--------Dt_anx------------



            string ANNEX_SEA_FAC_STUFFED = "N";
            string ANNEX_SEA_SAMPLE_ACCOM = "N";
            string ANNEX_SEA_NATURE_OF_CARGO = "C";
            string ANNEX_SEA_NO_CONTAINERS = "0";
            string ANNEX_SEA_UNIT_MEASUREMENT = "KGS";
            string ANNEX_SEA_SEAL_TYPE = "Warehouse";
            string ANNEX_SEA_PKG_UNIT_CODE = "";
            string ANNEX_SEA_TOTAL_PACKAGES = "";

            if (dss_Insert.Tables[0].Rows[0]["ctnno"].ToString() != "")
            {
                string[] pkgs = dss_Insert.Tables[0].Rows[0]["ctnno"].ToString().Split('-', '\t');
                if (pkgs.Count() > 1)
                {
                    ANNEX_SEA_TOTAL_PACKAGES = pkgs[1];
                }
            }

            if (dss_Insert.Tables[0].Rows[0]["client"].ToString() == "3_KPR")
            {
                ANNEX_SEA_PKG_UNIT_CODE = "CTN";
            }
            else if (dss_Insert.Tables[0].Rows[0]["client"].ToString() == "0_SP_APPARELS")
            {
                string[] pkgunicode = dss_Insert.Tables[0].Rows[0]["Tot_Carton"].ToString().Split(' ', '\t');

                if (pkgunicode.Count() > 1)
                {
                    if (pkgunicode[1].Length > 3)
                    {
                        ANNEX_SEA_PKG_UNIT_CODE = pkgunicode[1].Substring(0, 3);
                    }
                    else
                    {
                        ANNEX_SEA_PKG_UNIT_CODE = pkgunicode[1];
                    }
                }
            }
            else
            {
            }

            Dt_anx.Rows.Add(ANNEX_SEA_FAC_STUFFED, ANNEX_SEA_SAMPLE_ACCOM, ANNEX_SEA_NATURE_OF_CARGO, marksnos, ANNEX_SEA_TOTAL_PACKAGES, ANNEX_SEA_NO_CONTAINERS, ANNEX_SEA_UNIT_MEASUREMENT
                , ANNEX_SEA_SEAL_TYPE, dss_Insert.Tables[0].Rows[0]["Tot_grosswt"].ToString().ToLower().Replace("kgs", ""), dss_Insert.Tables[0].Rows[0]["Tot_netwt"].ToString().ToLower().Replace("kgs", ""), ANNEX_SEA_PKG_UNIT_CODE);



            ////--------Dt_Item------------


            string UNDER_PTA_FTA = "", hanger_qty = "", Item_Qty = "0", Item_UnitPrice = "0", itemdesc = "";

            for (int i = 0; i <= dss_Insert.Tables[1].Rows.Count - 1; i++)
            {

                //----common ----
                Item_Qty = dss_Insert.Tables[1].Rows[i]["ITEM_QTY"].ToString().TrimEnd() == "" ? "0" : dss_Insert.Tables[1].Rows[i]["ITEM_QTY"].ToString().TrimEnd();
                Item_UnitPrice = dss_Insert.Tables[1].Rows[i]["ITEM_UNITPRICE"].ToString().TrimEnd() == "" ? "0" : dss_Insert.Tables[1].Rows[i]["ITEM_UNITPRICE"].ToString().TrimEnd();
                //----common ----

                if (dss_Insert.Tables[0].Rows[0]["client"].ToString() == "6_SHAHI")
                {
                    itemdesc = dss_Insert.Tables[1].Rows[i]["ITEM_DESC"].ToString() != string.Empty ? dss_Insert.Tables[1].Rows[i]["ITEM_DESC"].ToString() : dss_Insert.Tables[1].Rows[i]["NO_KIND_PKGS"].ToString();

                    int x = itemdesc.IndexOf(" (DBK SL# ");
                    if (x > 0)
                    {
                        itemdesc = itemdesc.Substring(0, x);
                    }


                    //hanger_qty = Get_Valid_Qty_Code(dss_Insert.Tables[0].Rows[0]["Qtycode"].ToString());//07-07-2023
                    if (Item_Qty.Contains(" "))
                    {
                        string[] splt1 = Item_Qty.Split(' ');
                        Item_Qty = splt1[0];
                        hanger_qty = splt1[1];
                    }
                }
                else if (dss_Insert.Tables[0].Rows[0]["client"].ToString() == "0_SP_APPARELS")
                {
                    itemdesc = dss_Insert.Tables[1].Rows[i]["NO_KIND_PKGS"].ToString() != string.Empty ? dss_Insert.Tables[1].Rows[i]["NO_KIND_PKGS"].ToString() : dss_Insert.Tables[1].Rows[i]["ITEM_DESC"].ToString();
                    hanger_qty = itemdesc.Contains("HANGER") ? "KGS" : "NOS";

                    if (dss_Insert.Tables[0].Rows[0]["cntyDec"].ToString() == "UNITED STATES" || dss_Insert.Tables[0].Rows[0]["cntyDec"].ToString() == "USA")
                    {
                        UNDER_PTA_FTA = "NCPTI-Preferential Trade Benefit not claimed at Importing Country";
                    }
                    else
                    {
                        UNDER_PTA_FTA = "GSTP-GLOBAL SYSTEM OF TRADE PREFENCES (GSTP)";
                    }

                    if (itemdesc.Contains("HANGER"))
                    {
                        Item_Qty = dss_Insert.Tables[1].Rows[i]["Info_Qty"].ToString().TrimEnd() == "" ? "0" : dss_Insert.Tables[1].Rows[i]["Info_Qty"].ToString().TrimEnd();
                        Item_UnitPrice = dss_Insert.Tables[1].Rows[i]["Info_Unitprice"].ToString().TrimEnd() == "" ? "0" : dss_Insert.Tables[1].Rows[i]["Info_Unitprice"].ToString().TrimEnd();
                    }
                }
                else if (dss_Insert.Tables[0].Rows[0]["client"].ToString() == "3_KPR")
                {
                    itemdesc = dss_Insert.Tables[1].Rows[i]["NO_KIND_PKGS"].ToString() != string.Empty ? dss_Insert.Tables[1].Rows[i]["NO_KIND_PKGS"].ToString() : dss_Insert.Tables[1].Rows[i]["ITEM_DESC"].ToString();
                    //hanger_qty = dss_Insert.Tables[1].Rows[i]["ITEM_DESC"].ToString().Contains("HANGER") ? "KGS" : dss_Insert.Tables[1].Rows[i]["ITEM_DESC"].ToString().Contains("PYJAMA") ? "NOS" : Get_Valid_Qty_Code(dss_Insert.Tables[0].Rows[0]["Qtycode"].ToString().Replace("PCS", "NOS"));
                    hanger_qty = itemdesc.Contains("HANGER") ? "KGS" : itemdesc.Contains("PYJAMA") ? "NOS" : Get_Valid_Qty_Code(dss_Insert.Tables[0].Rows[0]["Qtycode"].ToString().Replace("PCS", "NOS"));
                    UNDER_PTA_FTA = "GSTP-GLOBAL SYSTEM OF TRADE PREFENCES (GSTP)";

                    if (itemdesc.Contains("HANGER"))
                    {
                        Item_Qty = dss_Insert.Tables[1].Rows[i]["Info_Qty"].ToString().TrimEnd().Replace("Kgs", "") == "" ? "0" : dss_Insert.Tables[1].Rows[i]["Info_Qty"].ToString().TrimEnd().Replace("Kgs", "");
                        Item_UnitPrice = dss_Insert.Tables[1].Rows[i]["Info_Unitprice"].ToString().TrimEnd() == "" ? "0" : dss_Insert.Tables[1].Rows[i]["Info_Unitprice"].ToString().TrimEnd();
                    }
                }
                else if ("MAF CLOTHING PRIVATE LIMITED" == ViewState["exp_name"].ToString())
                {
                    itemdesc = dss_Insert.Tables[1].Rows[i]["ITEM_DESC"].ToString();
                    if (dss_Insert.Tables[1].Rows[i]["ITEM_DESC"].ToString() == "HANGER COST" || dss_Insert.Tables[1].Rows[i]["ITEM_DESC"].ToString() == "GOODS ARE PACKED WITH HANGER")
                    {
                        itemdesc = "HANGER";
                    }
                    else if (dss_Insert.Tables[1].Rows[i]["ITEM_DESC"].ToString().Contains("WITH HANGER"))
                    {
                        string splitword = "WITH HANGER";
                        itemdesc = dss_Insert.Tables[1].Rows[i]["ITEM_DESC"].ToString().Substring(0, dss_Insert.Tables[1].Rows[i]["ITEM_DESC"].ToString().IndexOf(splitword));
                    }
                    string ITEM_AMOUNT = dss_Insert.Tables[1].Rows[i]["ITEM_AMOUNT"].ToString().TrimEnd();
                    string Info_Qty = dss_Insert.Tables[1].Rows[i]["Info_Qty"].ToString().TrimEnd();
                    if (itemdesc == "HANGER")
                    {
                        hanger_qty = "KGS";
                        //itemdesc = "HANGER (" + Item_Qty + " PCS" + ")";
                        itemdesc = "HANGER";
                        if (Info_Qty != "")
                        {
                            Item_Qty = Info_Qty;

                            double Spl_Calc = 0.00;
                            Spl_Calc = Convert.ToDouble(ITEM_AMOUNT) / Convert.ToDouble(Info_Qty);
                            Item_UnitPrice = Convert.ToString((Math.Round(Convert.ToDecimal(Spl_Calc), 5, MidpointRounding.AwayFromZero)).ToString());
                        }
                    }
                    else
                    {
                        hanger_qty = "NOS";
                        dss_Insert.Tables[1].Rows[i]["Info_Qty"] = "";
                    }
                }
                else
                {
                    itemdesc = dss_Insert.Tables[1].Rows[i]["ITEM_DESC"].ToString() != string.Empty ? dss_Insert.Tables[1].Rows[i]["ITEM_DESC"].ToString() : dss_Insert.Tables[1].Rows[i]["NO_KIND_PKGS"].ToString();
                    hanger_qty = Get_Valid_Qty_Code(dss_Insert.Tables[0].Rows[0]["Qtycode"].ToString());
                }

                Dt_Item.Rows.Add("1", InvNo, i + 1, itemdesc.TrimEnd(), Item_Qty, hanger_qty, Item_UnitPrice, dss_Insert.Tables[1].Rows[i]["ITEM_AMOUNT"].ToString().TrimEnd(), STATE_OF_ORIGIN, DISTRICT_OF_ORIGIN, UNDER_PTA_FTA, dss_Insert.Tables[1].Rows[i]["Info_Qty"].ToString().TrimEnd(), IGST_PAYMENT, IGST_RATE);
            }

            DataTable Dt_draw = new DataTable();
            Dt_draw = (DataTable)ViewState["Dt_draw"];

            exp_pdf.EXPORTER_NAME = ViewState["exp_name"].ToString();
            exp_pdf.BRANCH_NO = ViewState["branch_slno"].ToString();
            exp_pdf.JOBNO = GENERAL_EXPORT_JOBNO;
            exp_pdf.USER_ID = currentuser;
            exp_pdf.WORKINGPERIOD = Working_Period;
            exp_pdf.Branch_Code = currentbranch;
            exp_pdf.flag = "Insert_Desc";
            dss_Insert = exp_pdf.Exp_PDF_Upload_New_XML(Dt_gen, Dt_Item, Dt_draw, Dt_Invoice, Dt_anx);

            if (exp_pdf.result == 1)
            {
                Session["JOBIDexcel"] = dss_Insert.Tables[0].Rows[0][0].ToString();

                // FIX 3: Set label text AND fire a jAlert popup so the user sees a clear success message.
                lbl_loading.Text = "Job Uploaded Successfully..!";
                Alert_msg("Job has been created successfully!");
            }
            else
            {
                lbl_loading.Text = "Job error..";
                Alert_msg("error..!");
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
        //txtJobNo.Text = Convert.ToString(Export.Retrieve_JobNO());
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
        //string JobNo = string.Empty;
        ////JobNo = txtJobNo.Text;
        //JobNo = JOBNO;

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
            if (Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00247")
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
                        hdn_JOBNO_PS.Value = ((dats.Tables[0].Rows[0][0].ToString() + JOBNO.TrimEnd()).TrimStart());
                        //hdn_JOBNO_PS.Value = ((dats.Tables[0].Rows[0][0].ToString() + JobNo).TrimEnd()).TrimStart();
                        hdprefix.Value = ((dats.Tables[0].Rows[0][0].ToString()).TrimEnd()).TrimStart();
                        hdsuffix.Value = string.Empty;
                    }
                    else if (dats.Tables[0].Rows[0][0].ToString() != string.Empty && dats.Tables[0].Rows[0][1].ToString() != string.Empty)
                    {
                        hdn_JOBNO_PS.Value = ((dats.Tables[0].Rows[0][0].ToString() + JOBNO + "/" + dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                        //hdn_JOBNO_PS.Value = ((dats.Tables[0].Rows[0][0].ToString() + JobNo + "/" + dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
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
            else
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
                        //hdn_JOBNO_PS.Value = ((dats.Tables[0].Rows[0][0].ToString() + "/" + txtJobNo.Text).TrimEnd()).TrimStart();
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
                        // hdn_JOBNO_PS.Value = ((dats.Tables[0].Rows[0][0].ToString() + "/" + txtJobNo.Text + "/" + dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
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


    private static string EXP_ConvertDataTableToXML(DataTable dtData)
    {
        DataSet dsData = new DataSet();
        StringBuilder sbSQL;
        StringWriter swSQL;
        string XMLformat;
        try
        {
            sbSQL = new StringBuilder();
            swSQL = new StringWriter(sbSQL);
            dsData.Merge(dtData, true, MissingSchemaAction.AddWithKey);
            dsData.Tables[0].TableName = "SampleDataTable";
            foreach (DataColumn col in dsData.Tables[0].Columns)
            {
                col.ColumnMapping = MappingType.Attribute;
            }
            dsData.WriteXml(swSQL, XmlWriteMode.WriteSchema);
            XMLformat = sbSQL.ToString();
            return XMLformat;
        }
        catch (Exception sysException)
        {
            throw sysException;
        }
    }

    protected void btn_Refresh_Click(object sender, ImageClickEventArgs e)
    {
        //txtCommNarration.Text = "";
        Page_Load(sender, e);

        txtBuyer.Text = "";
        txtConsigneeName.Text = "";

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

    public string Get_Valid_Country_Portcode(string COUNTRY_FINAL_DEST, string PORT_FINAL_DEST)
    {

        if (COUNTRY_FINAL_DEST == "UNITED KINGDOM" && (PORT_FINAL_DEST == "FELIXSTOWE" || PORT_FINAL_DEST == "FELIXSTOWE/TILBURY"))
        {
            COUNTRY_FINAL_DEST = "UNITED KINGDOM";
            PORT_FINAL_DEST = "FELIXSTOWE-GBFXT";
        }
        else if (COUNTRY_FINAL_DEST == "IRELAND" && PORT_FINAL_DEST == "DUBLIN")
        {
            COUNTRY_FINAL_DEST = "IRELAND";
            PORT_FINAL_DEST = "DUBLIN-IEDUB";
        }
        else if (COUNTRY_FINAL_DEST == "SPAIN" && PORT_FINAL_DEST == "VALENCIA")
        {
            COUNTRY_FINAL_DEST = "SPAIN";
            PORT_FINAL_DEST = "VALENCIA-ESVLC";
        }
        else if (COUNTRY_FINAL_DEST == "CZECH REPUBLIC" && PORT_FINAL_DEST == "ROTTERDAM")
        {
            COUNTRY_FINAL_DEST = "CZECH REPUBLIC";
            PORT_FINAL_DEST = "ROTTERDAM-NLRTM";
        }
        else if (COUNTRY_FINAL_DEST == "GERMANY" && PORT_FINAL_DEST == "ROTTERDAM")
        {
            COUNTRY_FINAL_DEST = "GERMANY";
            PORT_FINAL_DEST = "ROTTERDAM-NLRTM";
        }
        else if ((COUNTRY_FINAL_DEST == "NETHERLANDS" || COUNTRY_FINAL_DEST == "NETHERLAND" || COUNTRY_FINAL_DEST == "THE NETHERLANDS") && PORT_FINAL_DEST == "ROTTERDAM")
        {
            COUNTRY_FINAL_DEST = "NETHERLANDS";
            PORT_FINAL_DEST = "ROTTERDAM-NLRTM";
        }
        else if ((COUNTRY_FINAL_DEST == "UNITED STATES" || COUNTRY_FINAL_DEST == "USA") && (PORT_FINAL_DEST == "NEW YORK" || PORT_FINAL_DEST == "NEWYORK"))
        {
            COUNTRY_FINAL_DEST = "UNITED STATES";
            PORT_FINAL_DEST = "NEW YORK-USNYC";
        }
        else
        {
        }

        return COUNTRY_FINAL_DEST + "^" + PORT_FINAL_DEST;
    }

    private string Get_Valid_Curr_Name(string curr)
    {
        if (curr == "EURO")
        {
            curr = "EUR";
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
        else if (curr == "PIECE(S)" || curr == "pcs" || curr == "Pcs")
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

    private string Get_Valid_Date(string Dt)
    {
        string[] dd = Dt.Split('/');

        if (dd[0].Length != 2)
        {
            dd[0] = "0" + dd[0];
        }
        if (dd[1].Length != 2)
        {
            dd[1] = "0" + dd[1];
        }
        if (dd[2].Length != 4)
        {
            dd[2] = "20" + dd[2];
        }

        return Dt = dd[1] + "/" + dd[0] + "/" + dd[2];
    }


    public DataSet PDF_Convert_xlsx_to_Datatable(string Client_Name, string Brslno)
    {

        //  PDF_Datatable pdf_new = new PDF_Datatable();



        DataSet ds_gv_Output = new DataSet();
        DataSet ds_output = new DataSet();

        string savePath = Server.MapPath("~/Submission/ExportPDFReader/");
        if (Directory.Exists(savePath) == false)
        {
            Directory.CreateDirectory(savePath);
        }

        string savePath_PDFtoExcel = Server.MapPath("~/Submission/ExportPDFReader/Output/");
        if (Directory.Exists(savePath_PDFtoExcel) == false)
        {
            Directory.CreateDirectory(savePath_PDFtoExcel);
        }

        if (FilePDF.HasFile)
        {
            foreach (FileInfo fileInformation in new DirectoryInfo(savePath).GetFiles())
            {
                File.Delete(fileInformation.FullName);
            }

            string strFolderPath;
            string strImagePath;
            //try
            //{
            strFolderPath = Path.Combine(Request.PhysicalApplicationPath, savePath);
            strImagePath = Path.Combine(strFolderPath, FilePDF.FileName.ToString());

            //pdf_new.ImportPDF(strImagePath);

            FilePDF.SaveAs(strImagePath);

            string fNamewithoutex = Path.GetFileNameWithoutExtension(strImagePath);
            PDFReader reader = new PDFReader();
            Document pdfDocument = new Document(strImagePath);
            ViewState["fileNamewithoutextn"] = fNamewithoutex;

            //if (File.Exists(savePath + "Output/" + fNamewithoutex + ".xlsx"))
            //{
            //    foreach (FileInfo fileInformation in new DirectoryInfo(savePath).GetFiles())
            //    {
            //        File.Delete(savePath + "Output/" + fNamewithoutex + ".xlsx");
            //    }
            //}
            //else
            //{
            //    ExcelSaveOptions options = new ExcelSaveOptions();
            //    fNamewithoutex = Path.GetFileNameWithoutExtension(strImagePath);
            //    // Save output file
            //    // pdfDocument.Save(savePath + "Output/" + fNamewithoutex + ".xls", options);

            //    strFolderPath = Path.Combine(Request.PhysicalApplicationPath, savePath + "Output/" + fNamewithoutex + ".xlsx");
            //    strImagePath = Path.Combine(strFolderPath);
            //    pdfDocument.Save(strImagePath, options);

            //}


            foreach (FileInfo fileInformation in new DirectoryInfo(savePath_PDFtoExcel).GetFiles())
            {
                File.Delete(fileInformation.FullName);
            }

            ExcelSaveOptions options = new ExcelSaveOptions();
            fNamewithoutex = Path.GetFileNameWithoutExtension(strImagePath);
            // Save output file
            // pdfDocument.Save(savePath + "Output/" + fNamewithoutex + ".xls", options);

            strFolderPath = Path.Combine(Request.PhysicalApplicationPath, savePath + "Output/" + fNamewithoutex + ".xlsx");
            strImagePath = Path.Combine(strFolderPath);
            pdfDocument.Save(strImagePath, options);


            lblmsg.Visible = true;
            // lblmsg.Text = "File loading....";
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


            if (dtSchema.Rows.Count == 1)
            {
                String firstSheetName = dtSchema.Rows[0].Field<string>("TABLE_NAME");
                string query = string.Format("SELECT * FROM [{0}]", firstSheetName);
                OleDbCommand cmd = new OleDbCommand(query, conn);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(dtt);
                ds_output.Tables.Add(dtt);

                da.Dispose();
                conn.Close();
                conn.Dispose();
            }
            else if (dtSchema.Rows.Count > 1)
            {
                string query = "";
                DataTable dtt2 = new DataTable();
                int sheet_cnt = 2;
                for (int k = 0; k <= dtSchema.Rows.Count - 1; k++)
                {
                    if (k == 0)
                    {
                        query = "SELECT * FROM [Sheet1$]";
                        OleDbCommand cmd = new OleDbCommand(query, conn);
                        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                        da.Fill(dtt);
                        ds_output.Tables.Add(dtt);
                        da.Dispose();
                    }
                    else
                    {

                        //query = "SELECT * FROM [Sheet2$]";
                        query = "SELECT * FROM [Sheet" + sheet_cnt + "$]";
                        OleDbCommand cmd = new OleDbCommand(query, conn);
                        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                        da.Fill(dtt2);
                        ds_output.Tables.Add(dtt2);
                        da.Dispose();

                        k = dtSchema.Rows.Count; // no need to convert all sheets - bcz of reduce the unwanted loading time

                        //dtt2.Dispose();
                        //dtt2.Clear();
                        //dtt2.AcceptChanges();
                        //sheet_cnt = sheet_cnt + 1;
                    }
                }

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
                ds_output.Tables.Add(dtt);

                da.Dispose();
                conn.Close();
                conn.Dispose();
            }

            //ds_gv_Output = reader.getCustInvDetls_Excel_Datatable(Client_Name, _filepath, ds_output);
            ds_gv_Output = getCustInvDetls_Excel_Datatable(Client_Name, _filepath, ds_output);

            //finally Delete the Converted .xlsx file
            //if (File.Exists(savePath + "Output/" + fNamewithoutex + ".xlsx"))
            //{
            //    foreach (FileInfo fileInformation in new DirectoryInfo(savePath).GetFiles())
            //    {
            //        File.Delete(savePath + "Output/" + fNamewithoutex + ".xlsx");
            //    }
            //}

        }

        return ds_gv_Output;
    }


    /*
    public void ExportToPdf(DataTable dt, string strFilePath)
    {
        iTextSharp.text.Document document = new iTextSharp.text.Document();
        PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(strFilePath, FileMode.Create));
        document.Open();
        iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 5);

        PdfPTable table = new PdfPTable(dt.Columns.Count);
        PdfPRow row = null;
        float[] widths = new float[dt.Columns.Count];
        for (int i = 0; i < dt.Columns.Count; i++)
            widths[i] = 4f;

        table.SetWidths(widths);

        table.WidthPercentage = 100;
        int iCol = 0;
        string colname = "";
        PdfPCell cell = new PdfPCell(new Phrase("Products"));

        cell.Colspan = dt.Columns.Count;

        foreach (DataColumn c in dt.Columns)
        {
            table.AddCell(new Phrase(c.ColumnName, font5));
        }

        foreach (DataRow r in dt.Rows)
        {
            if (dt.Rows.Count > 0)
            {
                for (int h = 0; h < dt.Columns.Count; h++)
                {
                    table.AddCell(new Phrase(r[h].ToString(), font5));
                }
            }
        }
        document.Add(table);
        document.Close();
    }

    */

    public void getlkupval(string customer, string InvType)
    {
        //string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["dbcon"].ToString();

        string strcon = Connection.GetConnection();
        SqlConnection conn = new SqlConnection(strcon);
        //string selectquery = "select des from EXPORT_PDF_LKUP with(nolock) where del_flg=0 and Exporter_Name='" + customer + "'";
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

    public DataSet getCustInvDetls_Excel_Datatable(string custname, string filePath, DataSet ds)
    {
        DataSet datasetinvoice = new DataSet();
        try
        {
            string InvType = "S";
            PDFReader clsReadPDF = new PDFReader();

            System.Data.DataTable htable = new System.Data.DataTable();
            System.Data.DataTable dtable = new System.Data.DataTable();

            if (custname == "Shahi Exports Pvt. Ltd." && ds.Tables.Count > 1)
            {
                InvType = "M";
            }


            getlkupval(custname, InvType);

            if (ds_OrderDetails != null && ds_lkupDetails != string.Empty)
            {
                if (ds_OrderDetails.Tables.Count > 0)
                {
                    //Application excel = new Application();
                    //Workbook workbook = excel.Workbooks.Open(filePath);

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
                        dtable = readDetailPDFval(custname, "Details", dict, ds.Tables[0], InvType);
                        datasetinvoice.Tables.Add(dtable);
                    }

                    ds_OrderDetails.AcceptChanges();
                    // Close the workbook and release resources
                    //workbook.Save();
                    //workbook.Close(true);
                    //excel.Quit();
                    //System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                    //System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
                    //System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName("Excel");
                    //foreach (System.Diagnostics.Process p in process)
                    //{
                    //    if (!string.IsNullOrEmpty(p.ProcessName) && p.MainWindowTitle == "")
                    //    {
                    //        try
                    //        {
                    //            p.Kill();
                    //        }
                    //        catch { }
                    //    }
                    //}
                }
                //lblmsg.Text = "Data fetch successfully..";
            }
            else
            {
                // lblmsg.Text = "Mapping not available, please contact support team";
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
        string Get_Client_Name_Br = "", Client_Name_Br = "";
        string exp_names = ViewState["exp_name"].ToString();

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

            if (dttable.Rows.Count > 0)
            {
                Get_Client_Name_Br = dttable.Rows[0][0].ToString();
                if (Get_Client_Name_Br.Contains("MAF"))
                {
                    Client_Name_Br = Get_Client_Name_Br == "1_MAF_CLOTHING" ? "1_MAF_CLOTHING" : "3_MAF_CLOTHING";
                }
                else
                {
                    Client_Name_Br = Get_Client_Name_Br;
                }
            }

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

            if (key == "invNo" || key == "invDate" || key == "byerOdrNo" || key == "ohrRef"
                || (key == "Terms" && (Client_Name_Br == "1_MAF_CLOTHING")) || (key == "BuyerName" && (Client_Name_Br == "1_MAF_CLOTHING")))
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

            if (key == "inv_val" || ((key == "Tot_Carton" || key == "Tot_netwt" || key == "Tot_grosswt") && (Client_Name_Br == "1_MAF_CLOTHING")))
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


            //if (key == "range")
            //{
            //    str_rangeStart = detailmapingval["start"].ToString().Split(',');
            //    str_rangeEnd = detailmapingval["end"].ToString().Split(',');
            //}


            if (ds_output.Tables.Count > 2)
            {
                InvType = "S";
            }


            //-------------- 2nd sheet------------------
            if (key == "Tot_grosswt" || key == "Tot_netwt" || key == "Tot_Carton" || (key == "inv_val" && InvType == "M") || key == "Schemecode")
            {

                if (ds_output.Tables.Count > 1)
                {
                    string cell = "";

                    for (int row = row_start; row <= ds_output.Tables[1].Rows.Count; row++)
                    {
                        cell = ds_output.Tables[1].Rows[row][0].ToString();

                        if (cell.Contains(_column) || cell.Contains(_column) || (Client_Name_Br == "0_SP_APPARELS" && key == "Tot_Carton" && _column.Split(',').Any(c => cell.Contains(c.Trim()))))
                        {
                            try
                            {
                                cellValue = ds_output.Tables[1].Rows[row][col_pos].ToString();

                                if (_split != string.Empty)
                                {
                                    string[] _delimiter = _split.Split('-');
                                    string[] _valof = cellValue.ToString().Split(_delimiter, StringSplitOptions.RemoveEmptyEntries);
                                    cellValue = _valof[int.Parse(_sVal)];
                                }

                                dttable.Rows[0][key] = cellValue;
                                dttable.AcceptChanges();
                                row = ds_output.Tables[1].Rows.Count;
                            }
                            catch (Exception) { }
                        }
                    }
                }
            }



            //-------------- 1st sheet------------------
            try
            {
                DataTable dt = ds_output.Tables[0];

                cellValue = string.Empty;
                int rw_cnt = dt.Rows.Count;
                int col_cnt = dt.Columns.Count;
                string cell = "";
                string cell2 = "";
                string cell3 = "";

                if (key == "AEOcode")
                {
                }

                if (key == "invNo" || key == "invDate" || key == "byerOdrNo" || key == "ohrRef" || key == "trmsOfPyt" || key == "cntyDec" || key == "prtOfDschrg" || key == "ctnno" || key == "Qtycode" || key == "Currency" || key == "Terms" || key == "inv_val" || key == "ConsigneeName" || key == "ConsigneeAdd1" || key == "ConsigneeAdd2" || key == "ConsigneeAdd3" || key == "ConsigneeAdd4" || key == "BuyerName" || key == "Schemecode" || key == "AEOcode" || key == "ADcode" || key == "IGST_Payment_Status" || key == "IGST_Rate" || key == "byerOdr_Dt" || (key == "Tot_grosswt" && (exp_names == "KPR SUGAR AND APPARELS LIMITED~PRIMARK TIENDAS SLU")) || (key == "Tot_netwt" && (exp_names == "KPR SUGAR AND APPARELS LIMITED~PRIMARK TIENDAS SLU")) || (key == "Tot_Carton" && (exp_names == "KPR SUGAR AND APPARELS LIMITED~PRIMARK TIENDAS SLU")))
                {

                    for (int row = 0; row <= rw_cnt; row++)
                    {

                        //if (key != "invDate1" && key != "byerOdrNo")
                        //if( same_invNo=="N")
                        // {
                        for (int col = 0; col <= col_cnt - 1; col++)
                        {
                            //Microsoft.Office.Interop.Excel.Range cell = (Microsoft.Office.Interop.Excel.Range)usedRange.Cells[row, col];

                            cell = dt.Rows[row][col].ToString();

                            //cell = dt.Rows[row][col + col_pos].ToString();
                            string celldetValue = string.Empty;
                            try
                            {
                                celldetValue = cell;
                            }
                            catch (Exception) { celldetValue = string.Empty; }

                            if ((_column == celldetValue && _split == string.Empty) || (key == "cntyDec" && Client_Name_Br == "1_MAF_CLOTHING" && celldetValue == "Placeof Delivery" && _split == string.Empty))
                            {
                                cell2 = dt.Rows[row + _sPos][col + col_pos].ToString();
                                string celldetValue2 = cell2;
                                cellValue = celldetValue2;

                                col = col_cnt;
                                row = rw_cnt;


                            }
                            else if (celldetValue.Contains(_column.ToString()) && _split != string.Empty)
                            {
                                if (key == "trmsOfPyt" || key == "Qtycode" || key == "Currency" || (key == "Terms" && (Client_Name_Br != "1_MAF_CLOTHING")) || key == "Schemecode" || key == "AEOcode" || key == "ADcode" || key == "IGST_Payment_Status" || key == "IGST_Rate" || (key == "BuyerName" && (Client_Name_Br != "1_MAF_CLOTHING")) || key == "byerOdr_Dt" || key == "ConsigneeName" || (key == "prtOfDschrg" && (exp_names == "KPR SUGAR AND APPARELS LIMITED~PRIMARK TIENDAS SLU")) || (key == "cntyDec" && (exp_names == "KPR SUGAR AND APPARELS LIMITED~PRIMARK TIENDAS SLU")))
                                {

                                    cell2 = dt.Rows[row + _sPos][col + col_pos].ToString();
                                    string[] _delimiter = _split.Split('-');
                                    string[] _valof = cell2.ToString().Split(_delimiter, StringSplitOptions.RemoveEmptyEntries);
                                    if ((((key == "Qtycode" && (Client_Name_Br == "1_MAF_CLOTHING")) || (key == "Currency" && (Client_Name_Br == "1_MAF_CLOTHING"))) && cell2 == "")
                                        || (key == "ConsigneeName" && (Client_Name_Br == "1_MAF_CLOTHING")) && (dt.Rows[row][col + col_pos].ToString()).Contains("\n"))
                                    {
                                        cell2 = dt.Rows[row][col + col_pos].ToString();
                                        string[] _valof_Maf = cell2.ToString().Split(_delimiter, StringSplitOptions.RemoveEmptyEntries);
                                        cellValue = _valof_Maf[int.Parse(_sVal) + 1];
                                    }
                                    else if (key == "ConsigneeName" && Client_Name_Br == "1_MAF_CLOTHING" && cell2 == "")
                                    {
                                        cell2 = dt.Rows[row + _sPos + 1][col + col_pos].ToString();
                                        string[] _valof_Maf = cell2.ToString().Split(_delimiter, StringSplitOptions.RemoveEmptyEntries);
                                        cellValue = _valof_Maf[int.Parse(_sVal)];
                                    }
                                    else
                                    {
                                        cellValue = _valof[int.Parse(_sVal)];
                                    }

                                    if (key == "Qtycode")// Convert Valid QtyCode
                                    {
                                        cellValue = Convert_Valid_UnitCode(cellValue);
                                    }

                                    else if (key == "trmsOfPyt" && exp_names != "KPR SUGAR AND APPARELS LIMITED~PRIMARK TIENDAS SLU")
                                    {
                                        if (cellValue.Contains("TT"))
                                        {
                                            string[] _terms = cell2.ToString().Split(' ');
                                            cellValue = _terms[0] + " " + _terms[1];
                                        }
                                        else
                                        {
                                            cell3 = dt.Rows[row + _sPos + 1][col].ToString();

                                            if (cell3 != "")
                                            {
                                                string[] _terms = cell3.ToString().Split(' ');
                                                //cellValue = _terms[0] + " " + _terms[1];
                                                if (cell3.Contains("PAYMENT "))
                                                {
                                                    if (cell3.Contains("\n"))
                                                    {
                                                        cellValue = _terms[4] + " " + _terms[5];
                                                    }
                                                    else
                                                    {
                                                        cellValue = _terms[2] + " " + _terms[3];
                                                    }
                                                }
                                                else
                                                {
                                                    cellValue = _terms[0] + " " + _terms[1];
                                                }
                                            }
                                            else
                                            {
                                                cell2 = dt.Rows[row + _sPos][col + col_pos + 1].ToString();
                                                cellValue = cell2;

                                            }
                                        }

                                    }

                                    else if (key == "Terms")
                                    {
                                        Invval_col = col;
                                    }
                                }
                                else if (key == "invNo" || key == "invDate" || key == "byerOdrNo" || key == "ohrRef"
                                    || (key == "Terms" && (Client_Name_Br == "1_MAF_CLOTHING")) || (key == "BuyerName" && (Client_Name_Br == "1_MAF_CLOTHING")))
                                {
                                    if (key == "ohrRef")
                                    {
                                        inv_splt = "";
                                    }
                                    if ((Client_Name_Br == "1_MAF_CLOTHING"))
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

                                                cell3 = dt.Rows[row + _sPos][col + col_pos].ToString();
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
                                            cell3 = dt.Rows[row + _sPos][col + col_pos].ToString();
                                            cellValue = cell3.Replace("Inv No.& Date", "");

                                            inv_splt += cellValue.Trim().Replace("\n", " ") + " ";
                                        }
                                    }
                                    else if (key == "ohrRef" && (Client_Name_Br == "1_MAF_CLOTHING"))
                                    {
                                        inv_splt = dt.Rows[row + _sPos][col + col_pos].ToString();
                                        if (inv_splt == "")
                                        {
                                            inv_splt = dt.Rows[row + _sPos][col + col_pos - 1].ToString().Replace(":", "").Trim();
                                        }
                                    }
                                    else
                                    {
                                        inv_splt = "";
                                        inv_splt = dt.Rows[row + _sPos][col + col_pos].ToString();
                                    }

                                    cellValue = inv_splt;
                                    if (Client_Name_Br == "0_SP_APPARELS" && key == "invDate")
                                    {
                                        string NewFormatDateTime = dt.Rows[row][col + 1].ToString();//Conditon Based on new format given by Customer Lizma Mani // Inv Dt on another col // 07.04.2025
                                        if (NewFormatDateTime != "")
                                        {
                                            cellValue = NewFormatDateTime;
                                        }
                                    }
                                }
                                else if (key == "inv_val")
                                {
                                    try
                                    {
                                        string cellc = dt.Rows[row][Invval_col].ToString();
                                        cellValue = cellc;

                                    }
                                    catch (Exception) { }
                                }
                                else if (key == "ctnno")
                                {
                                    string ctnno1 = dt.Rows[row + _sPos][col + col_pos].ToString();
                                    if ((key == "ctnno" && (Client_Name_Br == "1_MAF_CLOTHING")))
                                    {
                                        if (ctnno1 == string.Empty)
                                        {
                                            string Maf_ctnno1 = dt.Rows[row][col + col_pos].ToString();
                                            string[] celldetValue2_Maf = Maf_ctnno1.Split('\n');
                                            ctnno1 = celldetValue2_Maf[1];
                                        }
                                    }
                                    else
                                    {
                                        if (ctnno1 == string.Empty)
                                        {
                                            ctnno1 = dt.Rows[row + _sPos][col - 1].ToString();
                                            string[] celldetValue2 = ctnno1.Split(' ');
                                            ctnno1 = celldetValue2[1];
                                        }
                                    }
                                    cellValue = ctnno1;
                                }
                                else if (key == "Tot_grosswt" || (key == "prtOfDschrg" && (exp_names == "KPR SUGAR AND APPARELS LIMITED~PRIMARK TIENDAS SLU")) || (key == "cntyDec" && (exp_names == "KPR SUGAR AND APPARELS LIMITED~PRIMARK TIENDAS SLU")))
                                {
                                    cell2 = dt.Rows[row + _sPos][col + col_pos].ToString();
                                    cellValue = cell2;
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

                        // }//if same inv_no
                        //else
                        //{
                        //    cellValue = inv_splt;// same as key == "invNo"-no need to split again

                        //    row = rw_cnt;
                        //}
                    }
                }



                if (key != "Tot_grosswt" && key != "Tot_netwt" && key != "Tot_Carton")
                {
                    string[] _columnvals = _column.Split('-');
                    foreach (string _getcolumnval in _columnvals)
                    {
                        if (_getcolumnval.ToString() != "")
                        {
                            if (key == "trmsOfPyt" || key == "cntyDec" || key == "prtOfDschrg" || key == "ctnno" || key == "taxVal" || key == "igstper" || key == "Qtycode" || key == "Currency" || (key == "Terms" && (Client_Name_Br != "1_MAF_CLOTHING")) || key == "inv_val" || key == "ConsigneeName")
                            {
                                cellValue = cellValue.ToString();
                            }
                            else if (key == "client")
                            {
                                cellValue = _columnvals[0];
                            }
                            else if (key == "invNo" || key == "invDate" || key == "byerOdrNo" || key == "ohrRef" || key == "ConsigneeName"
                                || (key == "Terms" && (Client_Name_Br == "1_MAF_CLOTHING")) || (key == "BuyerName" && (Client_Name_Br == "1_MAF_CLOTHING")))
                            {

                                string code = cellValue.Substring(cellValue.IndexOf(splitword) + splitword.Length);

                                string[] _terms = cellValue.Split(' ');
                                cellValue = _terms[int.Parse(_sVal)];
                                if (key == "invNo" && Client_Name_Br == "0_SP_APPARELS" && cellValue == "Buyer's")
                                {
                                    cellValue = _terms[int.Parse(_sVal) - 1];
                                }
                                if (key == "invDate" && Client_Name_Br == "3_KPR" && cellValue == "Buyer's")
                                {
                                    cellValue = _terms[int.Parse(_sVal) - 1];
                                }
                                if ((key == "invDate" && (Client_Name_Br == "1_MAF_CLOTHING")) && cellValue == ":")
                                {
                                    cellValue = _terms[int.Parse(_sVal) + 1];
                                }
                                if ((key == "byerOdrNo" && (Client_Name_Br == "1_MAF_CLOTHING")) && _terms[int.Parse(_sVal) + 1] != "")
                                {
                                    cellValue = _terms[int.Parse(_sVal) + 1];
                                }
                                if ((key == "Terms" && (Client_Name_Br == "1_MAF_CLOTHING")) && cellValue == "")
                                {
                                    if (cell3.Contains("\n"))
                                    {
                                        string[] _terms_Maf = cell3.Split(' ');
                                        cellValue = _terms_Maf[0];
                                    }
                                    else
                                    {
                                        cellValue = _terms[int.Parse(_sVal) + 1];
                                    }
                                }
                                if (key == "BuyerName" && (Client_Name_Br == "1_MAF_CLOTHING"))
                                {
                                    cellValue = _terms[int.Parse(_sVal)] + " " + _terms[int.Parse(_sVal) + 1];
                                }
                                if (key == "ohrRef" && (exp_names == "KPR SUGAR AND APPARELS LIMITED~PRIMARK TIENDAS SLU"))
                                {
                                    cellValue = cellValue.Replace("NO:", "").Replace(".", "");
                                }
                            }
                            else if (_split == string.Empty)
                            {
                                // cellValue += _getcolumnval == "" ? "" : worksheet.Range[_getcolumnval].Value.ToString();
                            }
                            else
                            {
                                /*
                                string collval = worksheet.Range[_getcolumnval].Value.ToString();
                                string[] _delimiter = _split.Split('-');
                                string[] _valof = collval.Split(_delimiter, StringSplitOptions.RemoveEmptyEntries);
                                if (_valof.Length > 1 || key == "hscd")
                                {
                                    try
                                    {
                                        string[] _sVals = _sVal.Split(',');
                                        if (_sVals.Length > 1)
                                        {
                                            for (int k = 0; k < _sVals.Length; k++)
                                            {
                                                //cellValue += _getcolumnval == "" ? "" : _valof[int.Parse(_sVals[k])];//ck
                                                cellValue += _getcolumnval == "" ? "" : _valof[int.Parse(_sVals[k])] + " ";
                                            }
                                        }
                                        else
                                        {
                                            try
                                            {
                                                //cellValue += _getcolumnval == "" ? "" : _valof[int.Parse(_sVal)];//ck
                                                cellValue += _getcolumnval == "" ? "" : _valof[int.Parse(_sVal)] + " ";
                                            }
                                            catch (Exception) { }
                                        }
                                    }
                                    catch (Exception) { }
                                }
                                else
                                {
                                    cellValue += _getcolumnval == "" ? "" : worksheet.Range[_getcolumnval].Value.ToString() + " ";
                                }
                                */
                            }
                        }
                    }

                    if (key == "invDate")
                        //cellValue = Regex.Match(cellValue, @"\d{1,2}/\d{1,2}/\d{2,4}").Value;
                        cellValue = Regex.Match(cellValue, @"\d{1,2}[./]\d{1,2}[./]\d{2,4}").Value;

                    dttable.Rows[0][key] = cellValue;
                    dttable.AcceptChanges();
                }
                else
                {
                    if (exp_names == "KPR SUGAR AND APPARELS LIMITED~PRIMARK TIENDAS SLU")
                    {
                        string[] _terms = cellValue.Split(' ');
                        cellValue = _terms[int.Parse(_sVal)];
                        dttable.Rows[0][key] = cellValue;
                        dttable.AcceptChanges();
                    }

                }
            }
            catch (Exception) { }
        }
        return dttable;
        //#headerend
    }

    public System.Data.DataTable readDetailPDFval(string custname, string dataTo, Dictionary<string, object> dictheader, DataTable dt, string InvType)
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
        int range_Amount = 0, range_rate = 0, range_qty = 0, cl_ety = 0, range_Infoqty = 0, range_infounit = 0, range_MarksNos = 0, range_NoOfPkgs = 0, range_HSNCode = 0;


        string MarksNos = string.Empty;
        string NoOfPkgs = string.Empty;
        string HSNCode = string.Empty;
        string Quantity = string.Empty;
        string Rate = string.Empty;
        string Amount = string.Empty;
        string ItemDesc = string.Empty;

        string exp_names = ViewState["exp_name"].ToString();



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
                str_rangeStart = detailmapingval["start"].ToString().Split(',');
                str_rangeEnd = detailmapingval["end"].ToString().Split(',');
            }
            else if (key == "addcolm")
            {
                additioancol = detailmapingval["columnm"].ToString();
                additioansplit = detailmapingval["split"].ToString();
                additioanval = detailmapingval["Value"].ToString();
                //int_hsdcount = detailmapingval["noofrows"].ToString();

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

                //------ SHAHI--HANGERS---
                try
                {
                    hangers = detailmapingval["hanger_pos"].ToString();
                }
                catch (Exception)
                {
                    hangers = string.Empty;
                }

                //------ SP APPARELS--HANGERS---
                //try
                //{
                //    SP_hanger_pos = detailmapingval["SP_hanger_pos"].ToString();
                //}
                //catch (Exception)
                //{
                //    SP_hanger_pos = string.Empty;
                //}


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
                //int_hsdcount = detailmapingval["noofrows"].ToString();
            }
            else if (key == "infounitprice")
            {
                infounit = detailmapingval["column"].ToString();
                infounitsplt = detailmapingval["split"].ToString();
                infounitval = detailmapingval["Value"].ToString();
                //int_hsdcount = detailmapingval["noofrows"].ToString();
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

        }


        string cellValueqty = "", cellValuerate = "", cellValueitotal = "", cellValueitemdec1 = "", cellValueitemdec2 = "", cellValueinfoqty = "", cellValueinfounit = "",
               cellValueMarksNos = "", cellValueNoOfpkgs = "", cellValueHSNCode = "";

        int rw_cnt = dt.Rows.Count;
        int col_count = dt.Columns.Count - 1;
        //int col_count = dt.Columns.Count;
        int hanger_pos = 0;
        int col_start = 0, col_reval = 0;

        string cell = "";
        //string cell2 = "";
        //string cell3 = "";
        string qty = "", rate = "", itotal = "", itemdec1 = "", itemdec2 = "", infoqty1 = "", infounitprice = "", hsn = "";

        string[] Itm_col_splt = new string[2];

        if (ItemDesc == string.Empty)
        {
            Itm_col_splt = itemcol.Split(',');
        }


        try
        {
            for (int row = 10; row <= rw_cnt - 1; row++)
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


                int cc = 0;

                //#col loop
                for (int col = 0; col <= col_count; col++)//-3 for except Info_qty, Unit price
                {
                    if (row == 26)
                    {

                    }
                    if (col == 11)
                    {
                    }
                    //if(col<=dt.Columns.Count-1)
                    //{
                    cell = dt.Rows[row][col].ToString();
                    string celldetValue = cell;


                    foreach (var x in str_rangeEnd)
                    {
                        if (celldetValue.Contains(x))
                        {
                            int_rangeEnd = row;
                            col = col_count;
                        }
                    }

                    itemfilterbol = false;
                    foreach (var x in itemfilter_multi)
                    {
                        if (celldetValue != "")
                        {
                            if (celldetValue.Contains(x))
                            {
                                itemfilterbol = true;
                                hanger_pos = col;
                            }
                        }
                    }


                    if (hanger_party != string.Empty && hanger_party == "MAF_hanger")
                    {
                        if (str_rangeStart.Contains(celldetValue.ToString()) || celldetValue.Contains("Marks & Nos\nContainer No") || celldetValue.Contains("Marks & Nos "))
                        {
                            int_rangeStart = row;
                            col_start = col;
                        }
                    }
                    else
                    {
                        if (str_rangeStart.Contains(celldetValue.ToString().TrimEnd()))
                        {
                            int_rangeStart = row;
                            col_start = col;
                        }
                    }
                    if (row == int_rangeStart)
                    {
                        // cc = cc + 1;
                        cc = col;

                        /* 09-05-23
                        //if (dttable.Columns.Count == 0 && additioancol != string.Empty)
                        //{
                        //    dttable.Columns.Add(additioancol);
                        //}
                         * */

                        if (col_start > 0)
                        {
                            if (col_reval == 0)
                            {
                                string cellemty = dt.Rows[row][col_start - col].ToString();
                                //celldetValue = cellemty;
                                dttable.Columns.Add(cellemty);
                                col_reval = 1;
                            }
                        }

                        if (celldetValue.ToString() == String.Empty)
                        {
                            cl_ety = col;

                            string cellemty = dt.Rows[row][col].ToString();
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

                        //if (cell == Amount)
                        if (cell.Contains(Amount))
                        {
                            range_Amount = col;

                            //if (range_Amount != col_count)
                            //{
                            //    string chk_col_cnt = dt.Rows[row][col + 1].ToString();

                            //    if (chk_col_cnt == string.Empty)
                            //    {
                            //        col_count = col_count + 1;
                            //        cc = cc + 2;
                            //    }
                            //}

                        }
                        if (cell == Rate || (hanger_party == "MAF_hanger" && cell.Contains(Rate)))
                        {
                            range_rate = col;
                        }
                        if (cell.Trim() == Quantity || (hanger_party == "MAF_hanger" && cell.Trim().Contains(Quantity)))
                        {
                            range_qty = col;
                        }
                        if (hanger_party == "MAF_hanger")
                        {
                            if (cell.Contains(ItemDesc) && col == 1)
                            {
                                celldetValue = "";
                            }
                            else if (cell.Contains(ItemDesc) && (col == 2 || col == 3))
                            {
                                if (ItemDesc != "")
                                {
                                    Itm_col_splt[0] = Convert.ToString(col);
                                }
                            }
                            else if (cell.Contains(ItemDesc) || (col == 2 && dt.Rows[row][1].ToString().Contains(ItemDesc)))
                            {
                                if (ItemDesc != "")
                                {
                                    Itm_col_splt[0] = Convert.ToString(col);
                                    celldetValue = ItemDesc;
                                }
                            }
                        }
                        else
                        {
                            if (cell.Contains(ItemDesc))
                            {
                                if (ItemDesc != "")
                                {
                                    // range_Amount = col;
                                    Itm_col_splt[0] = Convert.ToString(col);
                                }
                            }
                        }


                        dttable.Columns.Add(celldetValue);


                        //if (col_count + 1 == cc)
                        if (col_count == cc)
                        {
                            col_count = col_count + 1;
                            dttable.Columns.Add("Info_Qty");
                            //range_Infoqty = col + 1;
                            range_Infoqty = dt.Columns.Count + 1;

                            col_count = col_count + 2;
                            dttable.Columns.Add("Info_Unitprice");
                            range_infounit = dt.Columns.Count + 2;

                            if (InvType == "S")
                            {
                                col_count = col_count - 3;
                            }
                            else
                            {
                                // col_count = dt.Columns.Count-1;
                                col_count = col_count - 3;
                                col = col_count + 1;//09-05=23
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
                                qty = ""; rate = ""; itotal = ""; itemdec1 = ""; itemdec2 = ""; infoqty1 = ""; infounitprice = ""; hsn = ""; NoOfPkgs = "";

                                hsn = dt.Rows[row][range_HSNCode].ToString();

                                bool chk_HSN_Numeric = false;
                                Regex rg = new Regex("[^0-9]");
                                chk_HSN_Numeric = rg.IsMatch(hsn) == true ? false : true;

                                bool chk_Desc_Numeric = false;
                                itemdec1 = dt.Rows[row][Convert.ToInt32(Itm_col_splt[0])].ToString();
                                chk_Desc_Numeric = rg.IsMatch(itemdec1) == true ? false : true;

                                int diff = 0;
                                if (chk_HSN_Numeric == false && chk_Desc_Numeric == true && col_count > range_Amount)
                                {

                                    diff = col_count - range_Amount;

                                    cellValueHSNCode = itemdec1;// HSN CODE

                                    NoOfPkgs = dt.Rows[row][range_NoOfPkgs].ToString();
                                    cellValueNoOfpkgs = NoOfPkgs;
                                    if (NoOfPkgs == "")
                                    {
                                        NoOfPkgs = dt.Rows[row][range_NoOfPkgs + diff].ToString();
                                        cellValueNoOfpkgs = NoOfPkgs;

                                        if (NoOfPkgs == "")
                                        {
                                            NoOfPkgs = dt.Rows[row][range_NoOfPkgs + diff + 1].ToString();
                                            cellValueNoOfpkgs = NoOfPkgs;

                                            if (NoOfPkgs == "")
                                            {
                                                NoOfPkgs = dt.Rows[row][range_NoOfPkgs + diff + 2].ToString();
                                                cellValueNoOfpkgs = NoOfPkgs;

                                            }
                                        }
                                    }

                                    qty = dt.Rows[row][range_qty + diff].ToString();
                                    cellValueqty = qty;

                                    rate = dt.Rows[row][range_rate + diff].ToString();
                                    cellValuerate = rate;

                                    itotal = dt.Rows[row][range_Amount + diff].ToString();
                                    cellValueitotal = itotal;


                                    itemdec1 = dt.Rows[row][Convert.ToInt32(Itm_col_splt[0]) + diff].ToString();
                                    cellValueitemdec1 = itemdec1;

                                    if (itemdec1 == "")
                                    {
                                        itemdec1 = dt.Rows[row][Convert.ToInt32(Itm_col_splt[0]) + diff + 1].ToString();
                                        cellValueitemdec1 = itemdec1;

                                        if (itemdec1 == "")
                                        {
                                            itemdec1 = dt.Rows[row][Convert.ToInt32(Itm_col_splt[0]) + diff + 2].ToString();
                                            cellValueitemdec1 = itemdec1;

                                            if (itemdec1 == "")
                                            {
                                                itemdec1 = dt.Rows[row][Convert.ToInt32(Itm_col_splt[0]) + diff + 3].ToString();
                                                cellValueitemdec1 = itemdec1;

                                                if (itemdec1 == "")
                                                {
                                                    itemdec1 = dt.Rows[row][Convert.ToInt32(Itm_col_splt[0]) + diff + 4].ToString();
                                                    cellValueitemdec1 = itemdec1;
                                                }
                                            }
                                        }
                                    }
                                }
                                else if (chk_HSN_Numeric == true && chk_Desc_Numeric == false && col_count == range_Amount && dt.Rows[row][range_qty].ToString() == "")
                                {

                                    qty = dt.Rows[row][range_qty - 1].ToString();//check previous cells
                                    cellValueqty = qty;

                                    rate = dt.Rows[row][range_rate].ToString();
                                    cellValuerate = rate;


                                    itotal = dt.Rows[row][range_Amount].ToString();
                                    cellValueitotal = itotal;


                                    itemdec1 = dt.Rows[row][Convert.ToInt32(Itm_col_splt[0])].ToString();
                                    cellValueitemdec1 = itemdec1;

                                }
                                else
                                {
                                    qty = dt.Rows[row][range_qty].ToString();
                                    cellValueqty = qty;

                                    rate = dt.Rows[row][range_rate].ToString();
                                    cellValuerate = rate;


                                    itotal = dt.Rows[row][range_Amount].ToString();
                                    cellValueitotal = itotal;


                                    itemdec1 = dt.Rows[row][Convert.ToInt32(Itm_col_splt[0])].ToString();
                                    string[] itemdec1_validate = itemdec1.Split('\n');
                                    if (itemdec1_validate != null)
                                    {
                                        cellValueitemdec1 = itemdec1_validate[0];
                                    }
                                    else
                                    {
                                        cellValueitemdec1 = itemdec1;
                                    }
                                    if (exp_names == "KPR SUGAR AND APPARELS LIMITED~PRIMARK TIENDAS SLU")
                                    {
                                        qty = dt.Rows[row][range_qty].ToString().Replace(",", "");
                                        cellValueqty = qty;

                                        rate = dt.Rows[row][range_rate - 1].ToString().Replace(",", "");
                                        cellValuerate = rate;


                                        itotal = dt.Rows[row][range_Amount - 1].ToString().Replace(",", "");
                                        cellValueitotal = itotal;
                                    }
                                }



                                if (itemdec1 == "ORDER NO:")
                                {
                                    string chk_near_ItemDesc = dt.Rows[row][Convert.ToInt32(Itm_col_splt[0]) + 1].ToString();

                                    if (chk_near_ItemDesc != "STYLE NO:")
                                    {
                                        Itm_col_splt[1] = Convert.ToString(Convert.ToInt32(Itm_col_splt[0]) + 1);
                                    }
                                }

                                if (Itm_col_splt[1] != null)
                                {
                                    itemdec2 = dt.Rows[row][Convert.ToInt32(Itm_col_splt[1])].ToString();
                                    cellValueitemdec2 = itemdec2;

                                }

                                infoqty1 = dt.Rows[row + 1][range_qty].ToString();
                                cellValueinfoqty = infoqty1.Replace("(", "").Replace(")", "").Replace("NOS", "").Replace("KGS", "").Replace(" ", "").Trim();



                                infounitprice = dt.Rows[row + 1][range_rate].ToString();
                                cellValueinfounit = Convert_Digit(infounitprice.Replace("-", "").Replace("(", "").Replace(")", "").Trim(), 5);

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

                                //if (cellValueqty == string.Empty && cellValuerate == string.Empty && cellValueitotal == string.Empty && cellValueitemdec1 == string.Empty && cellValueitemdec2 == string.Empty && cellValueinfoqty == string.Empty)
                                //{
                                //    col = col_count;
                                //}

                                if (row == int_rangeEnd)
                                {
                                    row = rw_cnt;
                                }
                            }

                            if (itemfilterbol == true)
                            {
                                itemdec1 = dt.Rows[row][hanger_pos].ToString();
                                cellValueitemdec1 = itemdec1;
                            }


                            #region Hanger

                            if (itemfilterbol == true)
                            {
                                rowstatus = true;

                                string cellH = dt.Rows[row + 1][col].ToString();
                                string celldetValueH = cellH;

                                //if (itemfilter.Contains(celldetValue.ToString()) && celldetValue != string.Empty)
                                if (celldetValue != string.Empty)
                                {
                                    //dataRow[(col + 1) - 1] = celldetValue.Replace(" VALUE", "");
                                    // dataRow[(col + 1) - 1] = "HANGER";
                                    dataRow[(Convert.ToInt32(Itm_col_splt[0]))] = "HANGER";
                                    //itemdec1 = dt.Rows[row][Convert.ToInt32(Itm_col_splt[0])].ToString();
                                }
                                else
                                {
                                    dataRow[(col + 1) - 1] = celldetValueH;
                                }

                                /* 09-05-23
                                //dataRow[(col_count + 2)] = cellValueinfoqty;
                                //dataRow[(col_count + 3)] = cellValueinfounit;
                                 * */

                                dataRow[range_Infoqty - 1] = cellValueinfoqty;
                                dataRow[range_infounit - 1] = cellValueinfounit;
                                dataRow[range_Amount] = cellValueitotal;

                                if (hanger_party != string.Empty && hanger_party == "SP_hanger")
                                {
                                    //dataRow[range_qty + 1] = cellValueinfoqty;
                                    //dataRow[range_rate + 1] = cellValueinfounit;
                                    //dataRow[range_Amount + 1] = cellValueitotal;

                                    dataRow[range_qty] = cellValueinfoqty;
                                    dataRow[range_rate] = cellValueinfounit;
                                    dataRow[range_Amount] = cellValueitotal;
                                }
                                else if (hanger_party != string.Empty && hanger_party == "KPR_hanger")
                                {
                                    if (cellValueinfoqty == "")
                                    {
                                        infoqty1 = dt.Rows[row + 2][range_qty].ToString();
                                        if (infoqty1 == "")
                                        {
                                            infoqty1 = dt.Rows[row + 2][range_qty - 1].ToString();//check 1 col previously
                                        }
                                        cellValueinfoqty = infoqty1;

                                    }

                                    cellValueinfoqty = cellValueinfoqty.Replace("(", "").Replace(")", "").Replace("NOS", "").Replace("KGS", "").Replace(" ", "").Replace("HangerWeight", "").Replace("Kgs", "").Trim();
                                    dataRow[range_qty + 1] = cellValueinfoqty;
                                    //dataRow[range_rate + 1] = cellValuerate;
                                    dataRow[range_Amount + 1] = cellValueitotal;

                                    double Unitrate = 0.00;
                                    Unitrate = Convert.ToDouble(cellValueitotal) / Convert.ToDouble(cellValueinfoqty);
                                    cellValueinfounit = Convert_Digit(Convert.ToString(Unitrate), 5);

                                    cellValuerate = cellValueinfounit;
                                    dataRow[range_rate + 1] = cellValueinfounit;

                                }
                                else if (hanger_party != string.Empty && hanger_party == "Shahi_hanger")
                                {
                                    //dataRow[range_qty + 1] = cellValueqty;
                                    //dataRow[range_rate + 1] = cellValuerate;
                                    //dataRow[range_Amount + 1] = cellValueitotal;

                                    dataRow[range_qty] = cellValueqty;
                                    dataRow[range_rate] = cellValuerate;
                                    dataRow[range_Amount] = cellValueitotal;

                                    dataRow[range_Infoqty - 1] = "";
                                    dataRow[range_infounit - 1] = "";
                                }
                                else
                                {
                                    //dataRow[range_qty + 1] = cellValueqty;
                                    //dataRow[range_rate + 1] = cellValuerate;
                                    //dataRow[range_Amount + 1] = cellValueitotal;

                                    dataRow[range_qty] = cellValueqty;
                                    dataRow[range_rate] = cellValuerate;
                                    dataRow[range_Amount] = cellValueitotal;
                                }


                                /* 09-05-23
                                if (celldetValueH.ToString().Contains(additioansplit))
                                {
                                    string _strval = celldetValueH.ToString();
                                    dataRow[0] = Regex.Replace(_strval, additioansplit, "");

                                }
                                 * */
                            }

                            #endregion Hanger


                            //if ((cellValueitemdec1 != string.Empty || cellValueitemdec2 != string.Empty)  && cellValueqty != string.Empty && cellValuerate != string.Empty && (cellValueitotal != string.Empty))

                            //if ((cellValueitemdec1 != string.Empty || cellValueitemdec2 != string.Empty) && (cellValueitemdec1.Length >= 20 || cellValueitemdec2.Length >= 20) && cellValueqty != string.Empty && cellValuerate != string.Empty && (cellValueitotal != string.Empty))
                            if ((cellValueitemdec1 != string.Empty || cellValueitemdec2 != string.Empty) && (cellValueitemdec1.Length >= 20 || cellValueitemdec2.Length >= 20) && (cellValueitotal != string.Empty))
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

                                            string cellhsd = dt.Rows[row + hsdint][col].ToString();
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
                                                cellhsd1 = dt.Rows[row + hsdint][col - 1].ToString();

                                                if (cellhsd1.Contains(x))
                                                {
                                                    if (x != "")
                                                    {
                                                        string cellhsd2 = dt.Rows[row + hsdint][col].ToString();

                                                        //dataRow[0] = cellhsd2;

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

                                            string cellhsd = dt.Rows[row + hsdint][col].ToString();
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
                                                string Nxt_itm_Amt = dt.Rows[row + hsdint][range_Amount].ToString();
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
                                        string cellhsd = dt.Rows[row + hsdint][col].ToString();
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
                                                //cellValueinfoqty = spt_infoqty[0].Replace("NET WT :", "").Replace("(", "").Replace(")", "").Replace("NOS", "").Replace("KGS", "").Replace(" ", "");
                                                if (cellhsd.Contains("NET"))
                                                {
                                                    spt_infoqty = cellhsd.Split('\n');
                                                    cellValueinfoqty = spt_infoqty[0].Substring(spt_infoqty[0].IndexOf("NET WT :") + splitword.Length).Replace("NET WT :", "").Replace("(", "").Replace(")", "").Replace("NOS", "").Replace("KGS", "").Replace(" ", "").Replace("Kgs", "");
                                                }
                                                else
                                                {
                                                    cellValueinfoqty = spt_infoqty[0].Substring(spt_infoqty[0].IndexOf("NET WT :") + splitword.Length).Replace("NET WT :", "").Replace("(", "").Replace(")", "").Replace("NOS", "").Replace("KGS", "").Replace(" ", "");
                                                }

                                                if (spt_infoqty.Count() > 1)
                                                {
                                                    cellValueitemdec1 = spt_infoqty[1];
                                                }
                                            }

                                            //if (cellValueitemdec2 != string.Empty)
                                            //{
                                            //    string[] spt_infoqty = cellValueitemdec2.Split('\n');
                                            //    cellValueinfoqty = spt_infoqty[0].Replace("NET WT :", "").Replace("(", "").Replace(")", "").Replace("NOS", "").Replace("KGS", "").Replace(" ", "");

                                            //    if (spt_infoqty.Count() > 1)
                                            //    {
                                            //        cellValueitemdec2 = spt_infoqty[1];
                                            //    }
                                            //}
                                        }
                                    }
                                }


                                //if (infoqty_itemfilterbol == true && col == 2)
                                //if (infoqty_itemfilterbol == true && col == 1)
                                if (infoqty_itemfilterbol == true && col == Convert.ToInt32(Itm_col_splt[0]) && cellValueitemdec1 != "")
                                {
                                    //dataRow[(col + 1) - 1] = cellValueitemdec1 + seconditemval;
                                    //dataRow[(col + 2) - 1] = cellValueitemdec1 + seconditemval;
                                    dataRow[Convert.ToInt32(Itm_col_splt[0])] = cellValueitemdec1.Replace("&#xA;", "") + seconditemval.Replace("&#xA;", "");
                                }
                                //else if (infoqty_itemfilterbol == true && col == 3)
                                //else if (infoqty_itemfilterbol == true && col == 2)
                                else if (infoqty_itemfilterbol == true && col == Convert.ToInt32(Itm_col_splt[1]) && cellValueitemdec2 != "")
                                {
                                    //dataRow[(col + 1) - 1] = cellValueitemdec2 + seconditemval;
                                    // dataRow[(col + 2) - 1] = cellValueitemdec2 + seconditemval;
                                    dataRow[Convert.ToInt32(Itm_col_splt[1])] = cellValueitemdec1.Replace("&#xA;", "") + seconditemval.Replace("&#xA;", "");
                                }
                                else
                                {
                                    //dataRow[(col + 1) - 1] = celldetValue + seconditemval;

                                    if (col == range_NoOfPkgs && Convert.ToString(range_NoOfPkgs) != "")
                                    {
                                        dataRow[(range_NoOfPkgs)] = cellValueNoOfpkgs;//05-07-23 - for Mismatched entries
                                    }
                                    //Changes for Lisma Mani 04/jan/2025 07:20 PM
                                    //else if (col == range_HSNCode && Convert.ToString(range_HSNCode) != "")
                                    //{
                                    //    dataRow[(range_HSNCode)] = cellValueHSNCode;//05-07-23 - for Mismatched entries
                                    //}
                                    if (col == range_HSNCode && Convert.ToString(range_HSNCode) != "")
                                    {
                                        dataRow[(range_HSNCode)] = cellValueHSNCode;//05-07-23 - for Mismatched entries
                                    }
                                    else if (col == Convert.ToInt32(Itm_col_splt[0]))
                                    {
                                        dataRow[Convert.ToInt32(Itm_col_splt[0])] = cellValueitemdec1.Replace("\n", "").Replace("&#xA;", "") + seconditemval.Replace("\n", "").Replace("&#xA;", "");//05-07-23 - for Mismatched entries
                                    }
                                    else if (col == range_qty)
                                    {
                                        //dataRow[(range_qty)] = celldetValue + seconditemval;
                                        dataRow[(range_qty)] = cellValueqty;//05-07-23 - for Mismatched entries
                                    }
                                    else if (col == range_rate)
                                    {
                                        //dataRow[(range_rate)] = celldetValue + seconditemval;
                                        dataRow[(range_rate)] = cellValuerate;//05-07-23 - for Mismatched entries
                                    }
                                    else if (col == range_Amount)
                                    {
                                        //dataRow[(range_Amount)] = celldetValue + seconditemval;
                                        dataRow[(range_Amount)] = cellValueitotal;//05-07-23 - for Mismatched entries
                                        col = col_count + 2;
                                    }
                                    else
                                    {
                                        // Don't assign Qty/Rate/Amount here (this causes duplicate like 46004600)
                                        if (col != range_qty && col != range_rate && col != range_Amount)
                                        {
                                            dataRow[col] = celldetValue.Replace("\n", "") + seconditemval.Replace("\n", "");
                                        }
                                    }
                                }
                                if (!string.IsNullOrEmpty(cellValueqty))
                                {
                                    cellValueqty = Regex.Replace(cellValueqty, @"\s+", "").Trim();
                                    cellValueqty = Regex.Replace(cellValueqty, @"^(.+)\1$", "$1");
                                }

                                if (!string.IsNullOrEmpty(cellValuerate))
                                {
                                    cellValuerate = Regex.Replace(cellValuerate, @"\s+", "").Trim();
                                    cellValuerate = Regex.Replace(cellValuerate, @"^(.+)\1$", "$1");
                                }

                                if (!string.IsNullOrEmpty(cellValueitotal))
                                {
                                    cellValueitotal = Regex.Replace(cellValueitotal, @"\s+", "").Trim();
                                    cellValueitotal = Regex.Replace(cellValueitotal, @"^(.+)\1$", "$1");
                                }

                                // -------- ASSIGN FINAL VALUES --------
                                dataRow[range_qty] = cellValueqty;
                                dataRow[range_rate] = cellValuerate;
                                dataRow[range_Amount] = cellValueitotal;

                                dataRow[range_Infoqty - 1] = cellValueinfoqty;
                                dataRow[range_infounit - 1] = cellValueinfounit;
                                //dataRow[(col_count + 1)-1] = cellValueinfoqty;
                                //dataRow[(col_count + 2)-1] = cellValueinfounit;

                                /* 09-05-23
                                dataRow[(col_count + 2)] = cellValueinfoqty;
                                dataRow[(col_count + 3)] = cellValueinfounit;
                                */

                                if (hanger_party != string.Empty && hanger_party == "MAF_hanger" && (col == Convert.ToInt32(Itm_col_splt[0])))
                                {
                                    if (cellValueitemdec1.Contains("HANGER"))
                                    {
                                        string HANGER_ITEM_DESCRIPTION = dt.Rows[row + 1][col].ToString();
                                        string[] INFOQTYUNIT = HANGER_ITEM_DESCRIPTION.Split(' ');

                                        cellValueqty = INFOQTYUNIT[5];
                                        cellValuerate = INFOQTYUNIT[12] != string.Empty ? INFOQTYUNIT[12] : INFOQTYUNIT[13];

                                        cellValueinfoqty = INFOQTYUNIT[5];
                                        cellValueinfounit = INFOQTYUNIT[12] != string.Empty ? INFOQTYUNIT[12] : INFOQTYUNIT[13];
                                    }
                                    else
                                    {
                                        cellValueinfoqty = cellValueqty;
                                        cellValueinfounit = cellValuerate;
                                    }
                                }
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
                    //}//if col_count check
                }

                if (row > int_rangeStart && int_rangeEnd == 0 && rowstatus == true)
                {
                    //if (dataRow.ItemArray[range_Amount + 1].ToString() != "")
                    if (dataRow.ItemArray[range_Amount].ToString() != "")
                    {
                        dttable.Rows.Add(dataRow);
                    }
                }
            }
        }
        catch (Exception)
        {
        }
        dttable.AcceptChanges();
        return dttable;
        //#detailend
    }

    public string Convert_Valid_UnitCode(string unit)
    {
        if (unit == "PIECE(S)")
        {
            unit = "PCS";
        }
        else if (unit == "PACK(S)")
        {
            unit = "PAC";
        }
        return unit;
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

}