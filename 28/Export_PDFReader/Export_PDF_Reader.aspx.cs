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

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Text.RegularExpressions;
using System.Collections.Generic;




public partial class Export_PDF_Reader : ThemeClass
{
    AppSession aps = new AppSession();
    UserBO ObjUBO = new UserBO();
    Export_General_New Export = new Export_General_New();
    UserBO objUBO = new UserBO();
    AdminMasterDetails admin = new AdminMasterDetails();
    Jobwise_xl_Upload xl = new Jobwise_xl_Upload();
    Export_PDF_Upload exp_pdf = new Export_PDF_Upload();
    Auto_Search Auto = new Auto_Search();

    DataTable Dt_gen = new DataTable();
    DataTable Dt_Invoice = new DataTable();
    DataTable Dt_Item = new DataTable();
    DataTable Dt_DBK = new DataTable();
    DataTable Dt_anx = new DataTable();

    DataSet ds_IEC = new DataSet();
    DataSet ds_draw = new DataSet();

    public String Xml_Inv;

    public int MAX_ID = 0;

    public string GENERAL_EXPORT_JOBNO = "", JOBID = "", LoginDate = "", JOBNO = "", CUSTOMS_HOUSE = "", SB_TYPE = "", STATE_OF_EXPORT = "", TRANSPORT_MODE = "", COUNTRY_FINAL_DEST = "", PORT_FINAL_DEST = "", COUNTRY_DISCHARGE = "", PORT_DISCHARGE = "", MARKS_NO = "", CONSIGNEE_BRANCHSLNO = "",
                    ANNEX_SEA_PACK_TO = "", ANNEX_SEA_GROSS_WEIGHT = "", ANNEX_SEA_NET_WEIGHT = "", ANNEX_SEA_PKG_UNIT_CODE = "", ANNEX_SEA_FAC_STUFFED = "", ANNEX_SEA_SAMPLE_ACCOM = "", ANNEX_SEA_NATURE_OF_CARGO = "", ANNEX_SEA_TOTAL_PACKAGES = "", 
                    ANNEX_SEA_NO_CONTAINERS = "", ANNEX_SEA_UNIT_MEASUREMENT = "", ANNEX_SEA_SEAL_TYPE="",
                    INVOICE_SLNO = "", INVOICE_NO = "", INVOICE_DATE = "", PAYMENT_METHOD = "", PERIOD_PAYMENT = "", INVOICE_VALUE = "", INVOICE_CURRENCY = "", EXCHANGE_RATE = "",
                    CONTRACT_NO = "", TERMS = "", BUYER = "", BUYER_NAME = "",
                    ITEM_ID = "", ITEM_SLNO = "", ITEM_DESCRIPTION = "", RITCNO = "", ITEM_QTY = "", ITEM_QTY_CODE = "", ITEM_UNIT_PRICE = "", GSTN_ID = "", UNDER_PTA_FTA = "", INFO_MSR = "", DISTRICT_CODE="";

  

    public string currentuser;
    public string currentbranch;
    public string Working_Period;
    public string COMPANY_IDD, comp_ConnectionStr;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        //TRANSPORT_MODE = Session["Transport_Mode_Port"].ToString();

        SB_TYPE = Session["EXPORT_SBTYPE"].ToString();
        COMPANY_IDD = Session["COMPANY_ID"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();

       

        if (Session["Jobno_Excel"] != null || Session["Jobno_Excel"] != null)
        {
            GENERAL_EXPORT_JOBNO = Session["Jobno_Excel"].ToString();
        }
        txtjobPS.Text = GENERAL_EXPORT_JOBNO;
        hdfTransport_mode.Value = Session["hdfTransport_mode"].ToString();
        Hdn_STANDARD_TYPE.Value = "STD";
        btnupload.Visible = false;

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
                e.Row.Cells[3].ForeColor = System.Drawing.Color.Red;
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
        if (Connection.COMPANYID() == "1" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "517")//LIZMA
        {
            if (ddl_ExporterName.SelectedValue.Contains("--"))
            {
                string[] sp = ddl_ExporterName.SelectedValue.Replace("--", "^").Split('^');

                string Branch_no = sp[0];

                if (sp[1] == "S.P.APPARELS LTD") //EXPORTER NAME
                {
                    LIZMA_PDF_SP_APPARELS();
                }
                else if (sp[1] == "KPR SUGAR AND APPARELS LIMITED")
                {
                    LIZMA_PDF_KPR_SUGAR();
                }
                else
                {
                    Alert_msg("No Records - Check ExporterName");
                }
            }
        }
    }
            
    

   
    protected void btnupload_Click(object sender, EventArgs e)
    {
        try
        {
            
            DataSet dss_Insert = new DataSet();

            Dt_gen = (DataTable)ViewState["Dt_gen"];

            Dt_Invoice = (DataTable)ViewState["Dt_Invoice"];

            DataTable Dt_draw = new DataTable();
            Dt_draw = (DataTable)ViewState["Dt_draw"];

            DataTable dt_itm = new DataTable();
            dt_itm = (DataTable)ViewState["Dt_Item"];

             DataTable dt_annex = new DataTable();
            dt_annex = (DataTable)ViewState["Dt_anx"];

            exp_pdf.EXPORTER_NAME = ViewState["exp_name"].ToString();
            exp_pdf.BRANCH_NO = ViewState["branch_slno"].ToString();
            exp_pdf.JOBNO = GENERAL_EXPORT_JOBNO;
            exp_pdf.USER_ID = currentuser;
            exp_pdf.WORKINGPERIOD = Working_Period;
            exp_pdf.Branch_Code = currentbranch;
            exp_pdf.flag = "Insert_Desc";
            dss_Insert = exp_pdf.Exp_PDF_Upload_New_XML(Dt_gen, dt_itm, Dt_draw, Dt_Invoice, dt_annex);

            if (exp_pdf.result == 1)
            {
                Alert_msg("PDF Uploaded Successfully..!");
            }
            else
            {
                Alert_msg("error..!");
            }

         
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }


  

    public void LIZMA_PDF_SP_APPARELS()
    {

        DataTable dt = new DataTable();
        gv_ItemPDF.DataSource = dt;
        gv_ItemPDF.DataBind();


         string newFile = "";
        string savePath = Server.MapPath("~/Submission/ExportPDFReader/");
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


            newFile = savePath + FilePDF.FileName.ToString();
            FilePDF.SaveAs(newFile);

            Document doc = new Document();

            PdfReader reader = new PdfReader(newFile);
            string[] lines;
            StringBuilder texts = new StringBuilder();

            for (int i = 1; i <= reader.NumberOfPages; i++)
            {
                texts.Append(PdfTextExtractor.GetTextFromPage(reader, i));
            }

            string All_text = texts.ToString();
            lines = All_text.Split('\n');



            //string[] lines = resultString.Split('^');


            string PAN = "", Other_Ref = "", Buyer_order_No = "", Buyer_order_Date = "";
            int Item_start = 0;
            string toBeSearched = "";
            string Total = "";
            string[] tot;

            DataTable dt_lines = new DataTable();
            dt_lines.Columns.Add("Id");
            dt_lines.Columns.Add("String_collection");

            DataRow row = dt.NewRow();



            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains("Inv No.& Date"))
                {
                    string[] Inv_dt = lines[i].Split(' ', '\t');
                    int len = Inv_dt.Length - 1;
                    INVOICE_DATE = Inv_dt[len].ToString();

                    string[] InvDT = INVOICE_DATE.Split('/', '\t');
                    INVOICE_DATE = InvDT[1] + "/" + InvDT[0] + "/" + InvDT[2];

                    i = i + 1;
                    string[] Invno = lines[i].Split(' ', '\t');
                    INVOICE_NO = Invno[3].ToString();
                }

                if (lines[i].Contains("Buyer's Order No.&Date"))
                {
                    i = i + 1;
                    if (lines[i].Contains("Dt."))
                    {
                        string[] buyer = lines[i].Split(' ', '\t');
                        //Buyer_order_No = buyer[3].ToString();
                        CONTRACT_NO = buyer[3].ToString();
                        Buyer_order_Date = buyer[4].ToString().Replace("Dt.", "").Replace(";", "");
                    }
                    else
                    {
                        i = i + 1;
                        string[] buyer = lines[i].Split(' ', '\t');
                        //Buyer_order_No = buyer[3].ToString();
                        CONTRACT_NO = buyer[3].ToString();
                        Buyer_order_Date = buyer[4].ToString().Replace("Dt.", "").Replace(";", "");
                    }
                }

                if (lines[i].Contains("Other Reference(s)"))
                {
                    i = i + 1;
                    string[] buyer = lines[i].Split(' ', '\t');
                    STATE_OF_EXPORT = buyer[6].ToString();
                    Other_Ref = buyer[7].ToString();

                    if (STATE_OF_EXPORT == "33")
                    {
                        STATE_OF_EXPORT = "TAMIL NADU";
                    }

                    //MARKS_NO += " KIMBALL NO:" + Other_Ref;
                }

                if (lines[i].Contains("GSTIN:"))
                {
                    string[] gstin = lines[i].Split(' ', '\t');
                    GSTN_ID = gstin[0].ToString().Replace("GSTIN:", "").Trim();
                    PAN = gstin[1].ToString().Replace("PAN:", "").Trim();
                }

                if (lines[i].Contains("Buyer(if other than Consignee)"))
                {
                    i = i + 1;
                    // BUYER_NAME = lines[i].Replace("Consignee", "").Replace("Consignee ", ""); from pdf

                    if (txtBuyer.Text == "")
                    {
                        BUYER = "Y";
                        txtBuyer.Text = "SAME AS CONSIGNEE";
                    }
                }

                //if (lines[i].Contains("Country Of Final Destination"))
                //{
                //    i = i + 1;
                //    toBeSearched = "INDIA ";
                //    string code = lines[i].Substring(lines[i].IndexOf("INDIA ") + toBeSearched.Length);
                //    // COUNTRY_FINAL_DEST = code;
                //}

                if (lines[i].Contains("DAYS FROM BL DATE"))
                {
                    //i = i + 1;
                    if (lines[i].Contains("TT "))
                    {
                        PAYMENT_METHOD = "NA";
                    }
                    else
                    {
                        PAYMENT_METHOD = "";
                    }

                    toBeSearched = "TT ";
                    string code = lines[i].Substring(lines[i].IndexOf("TT ") + toBeSearched.Length);
                    string[] buyer = code.Split(' ', '\t');
                    PERIOD_PAYMENT = buyer[0];
                }

                if (lines[i].Contains("Vessel/Flight"))
                {
                    i = i + 1;
                    string[] buyer = lines[i].Split(' ', '\t');
                    TRANSPORT_MODE = buyer[0];
                }

                if (lines[i].Contains("Port Of Discharge"))
                {
                    i = i + 1;
                    if (lines[i].Contains("FREE ON BOARD/INDIA"))
                    {
                        i = i + 1;
                    }
                    

                    if (lines[i].Contains("UNITED KINGDOM"))
                    {
                        COUNTRY_FINAL_DEST = "UNITED KINGDOM";
                        PORT_FINAL_DEST = "FELIXSTOWE-GBFXT";
                    }
                    else if (lines[i].Contains("IRELAND"))
                    {
                        COUNTRY_FINAL_DEST = "IRELAND";
                        PORT_FINAL_DEST = "DUBLIN-IEDUB";
                    }
                    else if (lines[i].Contains("SPAIN"))
                    {
                        COUNTRY_FINAL_DEST = "SPAIN";
                        PORT_FINAL_DEST = "VALENCIA-ESVLC";
                    }
                    else if (lines[i].Contains("CZECH REPUBLIC"))
                    {
                        COUNTRY_FINAL_DEST = "CZECH REPUBLIC";
                        PORT_FINAL_DEST = "ROTTERDAM-NLRTM";
                    }
                    else if (lines[i].Contains("GERMANY"))
                    {
                        COUNTRY_FINAL_DEST = "GERMANY";
                        PORT_FINAL_DEST = "ROTTERDAM-NLRTM";
                    }
                    else if (lines[i].Contains("NETHERLAND"))
                    {
                        COUNTRY_FINAL_DEST = "NETHERLANDS";
                        PORT_FINAL_DEST = "ROTTERDAM-NLRTM";
                    }
                    else if (lines[i].Contains("UNITED STATES") || lines[i].Contains("USA"))
                    {
                        COUNTRY_FINAL_DEST = "UNITED STATES";
                        PORT_FINAL_DEST = "NEW YORK-USNYC";
                    }

                    COUNTRY_DISCHARGE = COUNTRY_FINAL_DEST;
                    PORT_DISCHARGE = PORT_FINAL_DEST;
                }

                if (lines[i].Contains("Container No."))
                {
                    toBeSearched = "Pkgs.";
                    string code = lines[i].Replace("CAT","").Substring(lines[i].IndexOf("Pkgs.") + toBeSearched.Length).Replace(" In", "").Replace("In", "").Trim();
                    string[] item = code.Split(' ', '\t');
                    //ITEM_QTY_CODE = item[0];
                    ITEM_QTY_CODE = "NOS"; // by Default for Lizma
                    //Unit_Code = item[1];
                    TERMS = item[2];
                    INVOICE_CURRENCY = item[3];


                    //----------- Get Exchange Rate from Admin Master-------------

                    Auto.Ename = "EXCHANGE_MASTER_RATE_EXPORTWISE";
                    Auto.Enamesearch = INVOICE_CURRENCY;
                    Auto.Notn_No_Search = "";
                    ds_draw = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

                    if (ds_draw.Tables[0].Rows.Count > 0)
                    {
                        EXCHANGE_RATE = ds_draw.Tables[0].Rows[0]["EXCHANGE_RATE_EXPORT"].ToString();
                    }
                    //----------- Get Exchange Rate from Admin Master-------------
                }

                if (lines[i].Contains("STYLE NO:"))
                {
                    toBeSearched = "-";
                    string code = lines[i].Substring(lines[i].IndexOf("-") + toBeSearched.Length);
                    string[] pkgs = code.Split(' ', '\t');
                    ANNEX_SEA_PACK_TO = pkgs[0];

                    MARKS_NO = "CTN NO:" + "1-" + ANNEX_SEA_PACK_TO + " ORDER NO:" + CONTRACT_NO + " KIMBALL NO:" + Other_Ref + " SUPPLY MEANT FOR EXPORT ON PAYMENT OF IGST " + "WE INTEND TO CLAIM REWARDS UNDER ROSCTL";
                    Item_start = i;
                }

                if (lines[i].Contains("Amount Chargeable"))
                {
                    if (lines[i].Contains("Total "))
                    {
                        toBeSearched = "Total ";
                        Total = lines[i].Substring(lines[i].IndexOf("Total ") + toBeSearched.Length);
                        tot = Total.Trim().Split(' ', '\t');
                        INVOICE_VALUE = tot[0];
                    }
                    else if (lines[i + 1].Contains("Total "))
                    {
                        toBeSearched = "Total ";
                        Total = lines[i + 1].Substring(lines[i + 1].IndexOf("Total ") + toBeSearched.Length);
                        tot = Total.Trim().Split(' ', '\t');
                        INVOICE_VALUE = tot[0];

                    }
                    else if (lines[i - 1].Contains("Total "))
                    {
                        toBeSearched = "Total ";
                        Total = lines[i - 1].Substring(lines[i - 1].IndexOf("Total ") + toBeSearched.Length);
                        tot = Total.Trim().Split(' ', '\t');
                        INVOICE_VALUE = tot[0];
                    }

                }


                if (lines[i].Contains("District of Origin Code :"))
                {
                    toBeSearched = "District of Origin Code :";
                    Total = lines[i].Substring(lines[i].IndexOf("District of Origin Code :") + toBeSearched.Length);
                    tot = Total.Split(' ', '\t');
                    DISTRICT_CODE = tot[0];

                }

                if (lines[i].Contains("Agreement Code :"))
                {
                    toBeSearched = "Agreement Code :";
                    Total = lines[i].Substring(lines[i].IndexOf("Agreement Code :") + toBeSearched.Length);
                    tot = Total.Split(' ', '\t');
                    UNDER_PTA_FTA = tot[0];

                    i = i + 40;
                }

                if (lines[i].Contains("TOTAL GROSS WT :"))
                {
                    toBeSearched = "TOTAL GROSS WT : ";
                    Total = lines[i].Substring(lines[i].IndexOf("TOTAL GROSS WT : ") + toBeSearched.Length);
                    int ccnt = Total.Length - 3;
                    ANNEX_SEA_GROSS_WEIGHT = Total.Substring(0, ccnt);

                    i = i + 1;

                    toBeSearched = "TOTAL NET WT       : ";
                    Total = lines[i].Substring(lines[i].IndexOf("TOTAL NET WT       : ") + toBeSearched.Length);
                    ccnt = Total.Length - 3;
                    ANNEX_SEA_NET_WEIGHT = Total.Substring(0, ccnt);
                }

                if (lines[i].Contains("TOTAL CARTON"))
                {
                    toBeSearched = "TOTAL CARTON     : ";
                    Total = lines[i].Substring(lines[i].IndexOf("TOTAL CARTON     : ") + toBeSearched.Length);
                    tot = Total.Split(' ', '\t');

                    ANNEX_SEA_PACK_TO = tot[0];
                    ANNEX_SEA_PKG_UNIT_CODE = tot[1].Substring(0, 3).Trim();
                }

            }


            // txtBuyer.Text = BUYER_NAME;

            BUYER_NAME = txtBuyer.Text;
            if (txtBuyer.Text == "SAME AS CONSIGNEE")
            {
                BUYER = "Y";
            }
            else
            {
                BUYER = "N";
            }




            //-------------INVOICE--------------

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

            Dt_Invoice.Rows.Add("1", INVOICE_NO, INVOICE_DATE, PAYMENT_METHOD, PERIOD_PAYMENT, INVOICE_VALUE, INVOICE_CURRENCY, EXCHANGE_RATE, CONTRACT_NO, TERMS, BUYER, BUYER_NAME);



            //--------------------------- Read ITEM DESCRIPTION, ITEM QTY, UNIT PRICE -----------------------------------------
            DataTable dt_itm = new DataTable();
            dt_itm.Columns.Add("INVOICE_SLNO");
            dt_itm.Columns.Add("INVOICE_NO");
            dt_itm.Columns.Add("ITEM_SLNO");
            dt_itm.Columns.Add("ITEM_DESC");
            dt_itm.Columns.Add("ITEM_QTY");
            dt_itm.Columns.Add("ITEM_QTY_CODE");
            dt_itm.Columns.Add("ITEM_UNITPRICE");
            dt_itm.Columns.Add("ITEM_AMOUNT");
            dt_itm.Columns.Add("STATE_OF_ORIGIN");
            dt_itm.Columns.Add("DISTRICT_OF_ORIGIN");
            dt_itm.Columns.Add("UNDER_PTA_FTA");
            dt_itm.Columns.Add("INFO_MSR");



            //-------------ERI00517--DEFAULT--------
            string STATE_OF_ORIGIN = "33-TAMIL NADU";
            string DISTRICT_OF_ORIGIN = "634-TIRUPPUR";


            //var hscode_cnt = resultString.ToLowerInvariant().Split(new string[] { "HS CODE :".ToLowerInvariant() }, StringSplitOptions.None).Count() - 1;

            string desc = "", qty = "", unit = "", item_amt = "";
            int itm_slno = 0;
            //for (int cc = 0; cc <= hscode_cnt; cc++)
            //{

            int first_line = 1;
            int tt = 0;
            int pos = 0;
            string dot = "";
            string line_3 = "";


            //#item loop
            for (int i = Item_start; i < lines.Length; i++)
            {


                if (first_line == 1)
                {
                    if (lines[i].Contains("KIM "))
                    {
                        //---- Find QTY,UNIT, ITEM_AMOUNT from Next and Previous lines

                        pos = lines[i].Length - 5;
                        dot = lines[i].Substring(pos, 1);
                        if (dot == ".")
                        {
                            toBeSearched = "KIM ";
                            Total = lines[i].Substring(lines[i].IndexOf("KIM ") + toBeSearched.Length);
                            tot = Total.Split(' ', '\t');

                            tt = tot.Length;

                            for (int kk = 0; kk <= tot.Length - 5; kk++)
                            {
                                desc += tot[kk].ToString() + " ";
                            }

                            Total = lines[i];
                            tot = Total.Split(' ', '\t');
                            tt = tot.Length;

                            qty = tot[tot.Length - 3].ToString();
                            unit = tot[tot.Length - 2].ToString();
                            item_amt = tot[tot.Length - 1].ToString();

                        }
                        else
                        {
                            toBeSearched = "KIM ";
                            Total = lines[i].Substring(lines[i].IndexOf("KIM ") + toBeSearched.Length);
                            tot = Total.Split(' ', '\t');

                            tt = tot.Length;

                            for (int kk = 0; kk <= tot.Length - 1; kk++)
                            {
                                desc += tot[kk].ToString() + " ";
                            }



                            pos = lines[i - 1].Length - 5;
                            dot = lines[i - 1].Substring(pos, 1);
                            if (dot == ".")
                            {
                                Total = lines[i - 1];
                                tot = Total.Split(' ', '\t');
                                tt = tot.Length;

                                qty = tot[tot.Length - 3].ToString();
                                unit = tot[tot.Length - 2].ToString();
                                item_amt = tot[tot.Length - 1].ToString();
                            }
                            else
                            {
                            }
                        }

                        first_line = 2;
                    }
                }
                else
                {
                    if (first_line == 2)
                    {
                        if (!(lines[i].Contains("HS CODE :")))
                        {
                            if (lines[i].Contains(" NO:"))
                            {
                                tot = lines[i].TrimStart().Split(' ', '\t');
                                if (tot[0].Contains("."))
                                {
                                    toBeSearched = ".";
                                }
                                else if (tot[0].Contains("-"))
                                {
                                    toBeSearched = "-";
                                }
                                else
                                {

                                }
                                Total = lines[i].Substring(lines[i].IndexOf(toBeSearched) + toBeSearched.Length);

                                if (Total != "")
                                {
                                    tot = Total.Split(' ', '\t');
                                    tt = tot.Length;

                                    if (tt > 1)
                                    {
                                        line_3 = "Yes";
                                        lines[i] = Total;
                                    }
                                }
                            }

                            if (!(lines[i].Contains(" NO:")) || line_3!="")
                            {
                                

                                Total = "";
                                if (lines[i].Contains("BALL STYLE "))
                                {
                                    toBeSearched = "BALL STYLE ";
                                    Total = lines[i].Substring(lines[i].IndexOf("BALL STYLE ") + toBeSearched.Length);
                                }
                                else if (lines[i].Contains("HANGER VALUE"))
                                {
                                    Total = lines[i].Replace("HANGER VALUE", "HANGER");
                                }
                                else
                                {
                                    Total = lines[i];
                                }
                                //tot = Total.Split(' ', '\t');
                                //tt = tot.Length;


                                pos = lines[i].Length - 5;
                                dot = lines[i].Substring(pos, 1);
                                if (dot == ".")
                                {
                                    Total = lines[i];
                                    tot = Total.Split(' ', '\t');
                                    tt = tot.Length;

                                    if (tt > 4)
                                    {
                                        for (int kk = 0; kk <= tot.Length - 5; kk++)
                                        {
                                            if (tot[0].Contains(".") && tot[kk].Contains("."))
                                            {

                                            }
                                            else
                                            {
                                                desc += tot[kk].ToString().Replace("VALUE", "") + " ";
                                            }
                                        }
                                    }

                                    qty = tot[tot.Length - 3].ToString();
                                    unit = tot[tot.Length - 2].ToString();
                                    item_amt = tot[tot.Length - 1].ToString();
                                }
                                else
                                {
                                    tot = Total.Split(' ', '\t');
                                    tt = tot.Length;

                                    if (lines[i].Contains("KGS)") || lines[i].Contains("NOS)")) // CAT Value not shows in Invoice
                                    {
                                        if (tt > 3)
                                        {
                                            for (int kk = 0; kk <= tot.Length - 4; kk++)
                                            {
                                                if (tot[0].Contains(".") && tot[kk].Contains("."))
                                                {

                                                }
                                                else
                                                {
                                                    desc += tot[kk].ToString().Replace("VALUE", "") + " ";
                                                }
                                            }

                                            INFO_MSR = tot[tot.Length - 3].ToString().Replace("(", "").Replace(")", "").Trim();//INFO_MSR

                                            if (desc.TrimEnd() == "HANGER")
                                            {
                                                qty = INFO_MSR;
                                                unit = get_5Digit(tot[tot.Length - 1].ToString().Replace("(", "").Replace(")", "").Trim());//5 digit after point
                                                ITEM_QTY_CODE = "KGS";
                                            }

                                        }
                                        else//(56.345 KGS) (47.958115) - like this
                                        {
                                            INFO_MSR = tot[tot.Length - 3].ToString().Replace("(", "").Replace(")", "").Trim();//INFO_MSR

                                            if (desc.TrimEnd() == "HANGER")
                                            {
                                                qty = INFO_MSR;
                                                unit = get_5Digit(tot[tot.Length - 1].ToString().Replace("(", "").Replace(")", "").Trim());
                                                ITEM_QTY_CODE = "KGS";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        for (int kk = 0; kk <= tot.Length - 1; kk++)
                                        {
                                            if (tot[0].Contains(".") && tot[kk].Contains("."))
                                            {

                                            }
                                            else
                                            {
                                                desc += tot[kk].ToString().Replace("VALUE", "") + " ";
                                            }
                                        }
                                    }

                                    if (desc.TrimEnd() != "")
                                    {
                                        if (lines[i + 1].Contains("HS CODE :") && (!lines[i + 1].Contains("KGS)") || !lines[i + 1].Contains("NOS)")))
                                        {
                                            dt_itm.Rows.Add("1", INVOICE_NO, itm_slno = itm_slno + 1, desc.TrimEnd(), qty, ITEM_QTY_CODE, unit, item_amt, STATE_OF_ORIGIN, DISTRICT_OF_ORIGIN, UNDER_PTA_FTA, INFO_MSR);
                                            desc = "";
                                        }
                                    }
                                }



                            }
                            first_line = 2;
                        }
                        else// contains HS CODE: first_line = 2;
                        {
                            if (lines[i].Contains("BALL STYLE "))
                            {
                                toBeSearched = "BALL STYLE ";
                                Total = lines[i].Substring(lines[i].IndexOf("BALL STYLE ") + toBeSearched.Length);
                            }
                            else if (lines[i].Contains("HANGER VALUE"))
                            {
                                Total = lines[i].Replace("HANGER VALUE", "HANGER");
                            }
                            else
                            {
                                Total = lines[i];
                            }

                            if (Total.Contains("HS CODE :"))
                            {
                                toBeSearched = "HS CODE :";
                                Total = lines[i].Substring(lines[i].IndexOf("HS CODE :") + toBeSearched.Length + 2);


                                tot = Total.Split(' ', '\t');
                                tt = tot.Length;

                                if (lines[i].Contains("KGS)") || lines[i].Contains("NOS)")) // CAT Value not shows in Invoice
                                {
                                    for (int k = 0; k <= tot.Length - 5; k++)
                                    {
                                        if (tot[0].Contains(".") && tot[k].Contains("."))
                                        {

                                        }
                                        else
                                        {
                                            desc += tot[k].ToString().Replace("VALUE", "") + " ";
                                        }
                                    }

                                    if (tt > 3)// INFO_MSR
                                    {
                                        INFO_MSR = tot[tot.Length - 3].ToString().Replace("(", "").Replace(")", "").Trim();//INFO_MSR
                                        
                                        if (desc.TrimEnd() == "HANGER")
                                        {
                                            qty = INFO_MSR;
                                            unit = get_5Digit(tot[tot.Length - 1].ToString().Replace("(", "").Replace(")", "").Trim());// get 5 digit after the point
                                            ITEM_QTY_CODE = "KGS";
                                        }

                                    }
                                    else//(56.345 KGS) (47.958115) - like this
                                    {
                                        INFO_MSR = tot[tot.Length - 3].ToString().Replace("(", "").Replace(")", "").Trim();//INFO_MSR

                                        if (desc.TrimEnd() == "HANGER")
                                        {
                                            qty = INFO_MSR;
                                            unit = get_5Digit(tot[tot.Length - 1].ToString().Replace("(", "").Replace(")", "").Trim());
                                            ITEM_QTY_CODE = "KGS";
                                        }
                                    }
                                }
                                else
                                {
                                }



                                //if (tt > 4)
                                //{
                                //    pos = lines[i].Length - 5;
                                //    dot = lines[i].Substring(pos, 1);
                                //    if (dot == ".")
                                //    {
                                //        Total = lines[i];
                                //        tot = Total.Split(' ', '\t');
                                //        tt = tot.Length;

                                //        qty = tot[tot.Length - 3].ToString();
                                //        unit = tot[tot.Length - 2].ToString();
                                //        item_amt = tot[tot.Length - 1].ToString();
                                //    }

                                //    tot = lines[i].TrimStart().Split(' ', '\t');
                                //    tt = tot.Length;

                                //    for (int kk = 0; kk <= tot.Length - 4; kk++)
                                //    {
                                //        if (tot[0].Contains(".") && tot[kk].Contains("."))
                                //        {

                                //        }
                                //        else
                                //        { 
                                //            desc += tot[kk].ToString() + " ";
                                //        }
                                //    }
                                //}
                                //else// INFO_MSR
                                //{
                                //}
                            }




                            if (desc.TrimEnd() != "")
                            {
                                dt_itm.Rows.Add("1", INVOICE_NO, itm_slno = itm_slno + 1, desc.TrimEnd(), qty, ITEM_QTY_CODE, unit, item_amt, STATE_OF_ORIGIN, DISTRICT_OF_ORIGIN, UNDER_PTA_FTA, INFO_MSR);
                            }
                            //Item Desc - Finish with HS Code
                            first_line = 2;
                            desc = "";
                        }
                    }

                    if (lines[i].Contains("BOND #") || lines[i].Contains("Amount Chargeable") || lines[i].Contains("TOTAL HANGERS USED:"))
                    {
                        break;
                    }
                }
                if (lines[i].Contains("BOND #") || lines[i].Contains("Amount Chargeable") || lines[i].Contains("TOTAL HANGERS USED:"))
                {
                    break;
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
            ds_except = exp_pdf.Exp_PDF_Upload_New_XML(Dt_gen, dt_itm, dt_dbk, Dt_Invoice, Dt_anx);

            if (ds_except.Tables[0].Rows.Count > 0)
            {
                hdn_missed_Desc.Value = "1";
                gv_ItemPDF.DataSource = ds_except.Tables[0];
                gv_ItemPDF.DataBind();
                btnupload.Visible = false;
            }
            else
            {
                // get DBK SLno List from PDF

                exp_pdf.flag = "Get_DBK_slno_List";
                ds_except = exp_pdf.Exp_PDF_Upload_New_XML(Dt_gen, dt_itm, dt_dbk, Dt_Invoice, Dt_anx);
                hdn_missed_Desc.Value = "0";
                btnupload.Visible = true;

                if (ds_except.Tables[0].Rows.Count > 0)
                {
                    Auto.Ename = "DRAWBACK_MASTER_ALL_Excel_Upload";
                    Auto.Enamesearch = ds_except.Tables[0].Rows[0]["Dbkslno"].ToString();
                    Auto.Notn_No_Search = "";
                    ds_draw = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
                }



                //-----------EXPORT_GENERAL_DETAILS---------------------------------

                JOBID = Convert.ToString(Get_general_MAXID("Gen_MAX_ID"));
                Session["JOBIDexcel"] = JOBID;
                AUTO_JOBNO();


                SB_TYPE = "Free Duty";
                CUSTOMS_HOUSE = Session["CUSTOMHOUSE_CODE"].ToString();


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
                Dt_gen.Columns.Add("JOB_PREFIX");
                Dt_gen.Columns.Add("JOB_SUFFIX");
                Dt_gen.Columns.Add("JOBNO_PS");


                //Dt_gen.Rows.Add(exp_name, branch_slno, txtConsigneeName.Text, CONSIGNEE_BRANCHSLNO, hdfTransport_mode.Value, CUSTOMS_HOUSE, COUNTRY_DISCHARGE, PORT_DISCHARGE, COUNTRY_FINAL_DEST, PORT_FINAL_DEST, STATE_OF_EXPORT, MARKS_NO, hdprefix.Value, hdsuffix.Value, hdn_JOBNO_PS.Value);
                Dt_gen.Rows.Add(exp_name, branch_slno, txtConsigneeName.Text, CONSIGNEE_BRANCHSLNO, hdfTransport_mode.Value, CUSTOMS_HOUSE, COUNTRY_DISCHARGE, PORT_DISCHARGE, COUNTRY_FINAL_DEST, PORT_FINAL_DEST, STATE_OF_EXPORT, MARKS_NO, hdprefix.Value, hdsuffix.Value, hdn_JOBNO_digit.Value);



                //-----------EXPORT_ANNEXURE_C_SEA---------------------------------

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



                ANNEX_SEA_FAC_STUFFED = "N";
                ANNEX_SEA_SAMPLE_ACCOM = "N";
                ANNEX_SEA_NATURE_OF_CARGO = "C";
                ANNEX_SEA_TOTAL_PACKAGES = ANNEX_SEA_PACK_TO;
                ANNEX_SEA_NO_CONTAINERS = "0";
                ANNEX_SEA_UNIT_MEASUREMENT = "KGS";
                ANNEX_SEA_SEAL_TYPE = "Warehouse";


                Dt_anx.Rows.Add(ANNEX_SEA_FAC_STUFFED, ANNEX_SEA_SAMPLE_ACCOM, ANNEX_SEA_NATURE_OF_CARGO, MARKS_NO, ANNEX_SEA_TOTAL_PACKAGES, ANNEX_SEA_NO_CONTAINERS, ANNEX_SEA_UNIT_MEASUREMENT, ANNEX_SEA_SEAL_TYPE, ANNEX_SEA_GROSS_WEIGHT, ANNEX_SEA_NET_WEIGHT, ANNEX_SEA_PKG_UNIT_CODE);



                ViewState["Dt_gen"] = Dt_gen;
                ViewState["Dt_Invoice"] = Dt_Invoice;
                ViewState["Dt_Item"] = dt_itm;
                ViewState["Dt_draw"] = ds_draw.Tables[0];
                ViewState["Dt_anx"] = Dt_anx;


                gv_ItemPDF.DataSource = dt_itm;
                gv_ItemPDF.DataBind();

                //--#PDF
            }


        }//end if (FilePDF.HasFile)
    }

    public void LIZMA_PDF_KPR_SUGAR()
    {

        DataTable dt = new DataTable();
        gv_ItemPDF.DataSource = dt;
        gv_ItemPDF.DataBind();


        string newFile = "";
        string savePath = Server.MapPath("~/Submission/ExportPDFReader/");
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


            newFile = savePath + FilePDF.FileName.ToString();
            FilePDF.SaveAs(newFile);

            Document doc = new Document();

            PdfReader reader = new PdfReader(newFile);
            string[] lines;
            StringBuilder texts = new StringBuilder();

            for (int i = 1; i <= reader.NumberOfPages; i++)
            {
                texts.Append(PdfTextExtractor.GetTextFromPage(reader, i));
            }

            string All_text = texts.ToString();
            lines = All_text.Split('\n');



            //string[] lines = resultString.Split('^');


            string PAN = "", Other_Ref = "", Buyer_order_No = "", Buyer_order_Date = "";
            int Item_start = 0;
            string toBeSearched = "";
            string Total = "";
            string[] tot;

            DataTable dt_lines = new DataTable();
            dt_lines.Columns.Add("Id");
            dt_lines.Columns.Add("String_collection");

            DataRow row = dt.NewRow();



            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains("KPR SUGAR AND APPARELS LIMITED"))
                {
                    i = i + 1;
                    string[] Inv_dt = lines[i].Split(' ', '\t');

                    INVOICE_NO = Inv_dt[0].ToString();

                    int len = Inv_dt.Length - 1;
                    INVOICE_DATE = Inv_dt[len].ToString();

                    string[] InvDT = INVOICE_DATE.Split('/', '\t');
                    INVOICE_DATE = InvDT[0] + "/" + InvDT[1] + "/20" + InvDT[2];

                }

                if (lines[i].Contains("Buyer's Order No."))
                {
                    i = i + 2;
                    CONTRACT_NO = lines[i];

                    //Buyer_order_Date = buyer[4].ToString().Replace("Dt.", "").Replace(";", "");
                }

                if (lines[i].Contains("Other Reference(s)"))
                {
                    i = i + 1;

                    Other_Ref = lines[i].Replace("KIMBALL NO: ", "");
                   
                }

                if (lines[i].Contains("GSTIN : "))
                {
                    GSTN_ID = lines[i].Replace("GSTIN : ", "");
                    
                    //PAN = gstin[1].ToString().Replace("PAN:", "").Trim();
                }

                if (lines[i].Contains("Buyer(if other than Consignee)"))
                {
                    i = i + 1;
                    // BUYER_NAME = lines[i].Replace("Consignee", "").Replace("Consignee ", ""); from pdf

                    if (txtBuyer.Text == "")
                    {
                        BUYER = "Y";
                        txtBuyer.Text = "SAME AS CONSIGNEE";
                    }
                }

                if (lines[i].Contains("Country of Final Destination"))
                {
                    i = i + 1;
                    //toBeSearched = "INDIA ";
                    //string code = lines[i].Substring(lines[i].IndexOf("INDIA ") + toBeSearched.Length);
                    //COUNTRY_FINAL_DEST = code;
                }

                if (lines[i].Contains("DAYS FROM BL DATE"))
                {
                    //i = i + 1;
                    if (lines[i].Contains("TT "))
                    {
                        PAYMENT_METHOD = "NA";
                    }
                    else
                    {
                        PAYMENT_METHOD = "";
                    }

                    toBeSearched = "TT ";
                    string code = lines[i].Substring(lines[i].IndexOf("TT ") + toBeSearched.Length);
                    string[] buyer = code.Split(' ', '\t');
                    PERIOD_PAYMENT = buyer[0];
                }

                if (lines[i].Contains("Vessel/Flight"))
                {
                    i = i + 1;
                    string[] buyer = lines[i].Split(' ', '\t');
                    TRANSPORT_MODE = buyer[0];
                }

                if (lines[i].Contains("Port Of Discharge"))
                {
                    i = i + 1;

                    if (lines[i].Contains("UNITED KINGDOM"))
                    {
                        COUNTRY_FINAL_DEST = "UNITED KINGDOM";
                        PORT_FINAL_DEST = "FELIXSTOWE-GBFXT";
                    }
                    else if (lines[i].Contains("IRELAND"))
                    {
                        COUNTRY_FINAL_DEST = "IRELAND";
                        PORT_FINAL_DEST = "DUBLIN-IEDUB";
                    }
                    else if (lines[i].Contains("SPAIN"))
                    {
                        COUNTRY_FINAL_DEST = "SPAIN";
                        PORT_FINAL_DEST = "VALENCIA-ESVLC";
                    }
                    else if (lines[i].Contains("CZECH REPUBLIC"))
                    {
                        COUNTRY_FINAL_DEST = "CZECH REPUBLIC";
                        PORT_FINAL_DEST = "ROTTERDAM-NLRTM";
                    }
                    else if (lines[i].Contains("GERMANY"))
                    {
                        COUNTRY_FINAL_DEST = "GERMANY";
                        PORT_FINAL_DEST = "ROTTERDAM-NLRTM";
                    }
                    else if (lines[i].Contains("NETHERLAND"))
                    {
                        COUNTRY_FINAL_DEST = "NETHERLANDS";
                        PORT_FINAL_DEST = "ROTTERDAM-NLRTM";
                    }
                    else if (lines[i].Contains("UNITED STATES") || lines[i].Contains("USA"))
                    {
                        COUNTRY_FINAL_DEST = "UNITED STATES";
                        PORT_FINAL_DEST = "NEW YORK-USNYC";
                    }

                    COUNTRY_DISCHARGE = COUNTRY_FINAL_DEST;
                    PORT_DISCHARGE = PORT_FINAL_DEST;
                }

                if (lines[i].Contains("Container No."))
                {
                    toBeSearched = "Pkgs.";
                    string code = lines[i].Replace("CAT", "").Substring(lines[i].IndexOf("Pkgs.") + toBeSearched.Length).Replace(" In", "").Replace("In", "").Trim();
                    string[] item = code.Split(' ', '\t');
                    //ITEM_QTY_CODE = item[0];
                    ITEM_QTY_CODE = "NOS"; // by Default for Lizma
                    //Unit_Code = item[1];
                    TERMS = item[2];
                    INVOICE_CURRENCY = item[3];


                    //----------- Get Exchange Rate from Admin Master-------------

                    Auto.Ename = "EXCHANGE_MASTER_RATE_EXPORTWISE";
                    Auto.Enamesearch = INVOICE_CURRENCY;
                    Auto.Notn_No_Search = "";
                    ds_draw = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

                    if (ds_draw.Tables[0].Rows.Count > 0)
                    {
                        EXCHANGE_RATE = ds_draw.Tables[0].Rows[0]["EXCHANGE_RATE_EXPORT"].ToString();
                    }
                    //----------- Get Exchange Rate from Admin Master-------------
                }

                if (lines[i].Contains("STYLE NO:"))
                {
                    toBeSearched = "-";
                    string code = lines[i].Substring(lines[i].IndexOf("-") + toBeSearched.Length);
                    string[] pkgs = code.Split(' ', '\t');
                    ANNEX_SEA_PACK_TO = pkgs[0];

                    MARKS_NO = "CTN NO:" + "1-" + ANNEX_SEA_PACK_TO + " ORDER NO:" + CONTRACT_NO + " KIMBALL NO:" + Other_Ref + " SUPPLY MEANT FOR EXPORT ON PAYMENT OF IGST " + "WE INTEND TO CLAIM REWARDS UNDER ROSCTL";
                    Item_start = i;
                }

                if (lines[i].Contains("Amount Chargeable"))
                {
                    toBeSearched = "Total ";
                    Total = lines[i].Substring(lines[i].IndexOf("Total ") + toBeSearched.Length);
                    tot = Total.Trim().Split(' ', '\t');
                    INVOICE_VALUE = tot[0];
                }


                if (lines[i].Contains("District of Origin Code :"))
                {
                    toBeSearched = "District of Origin Code :";
                    Total = lines[i].Substring(lines[i].IndexOf("District of Origin Code :") + toBeSearched.Length);
                    tot = Total.Split(' ', '\t');
                    DISTRICT_CODE = tot[0];

                }

                if (lines[i].Contains("Agreement Code :"))
                {
                    toBeSearched = "Agreement Code :";
                    Total = lines[i].Substring(lines[i].IndexOf("Agreement Code :") + toBeSearched.Length);
                    tot = Total.Split(' ', '\t');
                    UNDER_PTA_FTA = tot[0];

                    i = i + 40;
                }

                if (lines[i].Contains("TOTAL GROSS WT :"))
                {
                    toBeSearched = "TOTAL GROSS WT : ";
                    Total = lines[i].Substring(lines[i].IndexOf("TOTAL GROSS WT : ") + toBeSearched.Length);
                    int ccnt = Total.Length - 3;
                    ANNEX_SEA_GROSS_WEIGHT = Total.Substring(0, ccnt);

                    i = i + 1;

                    toBeSearched = "TOTAL NET WT       : ";
                    Total = lines[i].Substring(lines[i].IndexOf("TOTAL NET WT       : ") + toBeSearched.Length);
                    ccnt = Total.Length - 3;
                    ANNEX_SEA_NET_WEIGHT = Total.Substring(0, ccnt);
                }

                if (lines[i].Contains("TOTAL CARTON"))
                {
                    toBeSearched = "TOTAL CARTON     : ";
                    Total = lines[i].Substring(lines[i].IndexOf("TOTAL CARTON     : ") + toBeSearched.Length);
                    tot = Total.Split(' ', '\t');

                    ANNEX_SEA_PACK_TO = tot[0];
                    ANNEX_SEA_PKG_UNIT_CODE = tot[1].Substring(0, 3).Trim();
                }

            }


            // txtBuyer.Text = BUYER_NAME;

            BUYER_NAME = txtBuyer.Text;
            if (txtBuyer.Text == "SAME AS CONSIGNEE")
            {
                BUYER = "Y";
            }
            else
            {
                BUYER = "N";
            }




            //-------------INVOICE--------------

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

            Dt_Invoice.Rows.Add("1", INVOICE_NO, INVOICE_DATE, PAYMENT_METHOD, PERIOD_PAYMENT, INVOICE_VALUE, INVOICE_CURRENCY, EXCHANGE_RATE, CONTRACT_NO, TERMS, BUYER, BUYER_NAME);



            //--------------------------- Read ITEM DESCRIPTION, ITEM QTY, UNIT PRICE -----------------------------------------
            DataTable dt_itm = new DataTable();
            dt_itm.Columns.Add("INVOICE_SLNO");
            dt_itm.Columns.Add("INVOICE_NO");
            dt_itm.Columns.Add("ITEM_SLNO");
            dt_itm.Columns.Add("ITEM_DESC");
            dt_itm.Columns.Add("ITEM_QTY");
            dt_itm.Columns.Add("ITEM_QTY_CODE");
            dt_itm.Columns.Add("ITEM_UNITPRICE");
            dt_itm.Columns.Add("ITEM_AMOUNT");
            dt_itm.Columns.Add("STATE_OF_ORIGIN");
            dt_itm.Columns.Add("DISTRICT_OF_ORIGIN");
            dt_itm.Columns.Add("UNDER_PTA_FTA");
            dt_itm.Columns.Add("INFO_MSR");



            //-------------ERI00517--DEFAULT--------
            string STATE_OF_ORIGIN = "33-TAMIL NADU";
            string DISTRICT_OF_ORIGIN = "634-TIRUPPUR";


            //var hscode_cnt = resultString.ToLowerInvariant().Split(new string[] { "HS CODE :".ToLowerInvariant() }, StringSplitOptions.None).Count() - 1;

            string desc = "", qty = "", unit = "", item_amt = "";
            int itm_slno = 0;
            //for (int cc = 0; cc <= hscode_cnt; cc++)
            //{

            int first_line = 1;
            int tt = 0;
            int pos = 0;
            string dot = "";

            //#item loop
            for (int i = Item_start; i < lines.Length; i++)
            {


                if (first_line == 1)
                {
                    if (lines[i].Contains("KIM "))
                    {
                        //---- Find QTY,UNIT, ITEM_AMOUNT from Next and Previous lines

                        pos = lines[i].Length - 5;
                        dot = lines[i].Substring(pos, 1);
                        if (dot == ".")
                        {
                            toBeSearched = "KIM ";
                            Total = lines[i].Substring(lines[i].IndexOf("KIM ") + toBeSearched.Length);
                            tot = Total.Split(' ', '\t');

                            tt = tot.Length;

                            for (int kk = 0; kk <= tot.Length - 5; kk++)
                            {
                                desc += tot[kk].ToString() + " ";
                            }

                            Total = lines[i];
                            tot = Total.Split(' ', '\t');
                            tt = tot.Length;

                            qty = tot[tot.Length - 3].ToString();
                            unit = tot[tot.Length - 2].ToString();
                            item_amt = tot[tot.Length - 1].ToString();

                        }
                        else
                        {
                            toBeSearched = "KIM ";
                            Total = lines[i].Substring(lines[i].IndexOf("KIM ") + toBeSearched.Length);
                            tot = Total.Split(' ', '\t');

                            tt = tot.Length;

                            for (int kk = 0; kk <= tot.Length - 1; kk++)
                            {
                                desc += tot[kk].ToString() + " ";
                            }



                            pos = lines[i - 1].Length - 5;
                            dot = lines[i - 1].Substring(pos, 1);
                            if (dot == ".")
                            {
                                Total = lines[i - 1];
                                tot = Total.Split(' ', '\t');
                                tt = tot.Length;

                                qty = tot[tot.Length - 3].ToString();
                                unit = tot[tot.Length - 2].ToString();
                                item_amt = tot[tot.Length - 1].ToString();
                            }
                            else
                            {
                            }
                        }

                        first_line = 2;
                    }
                }
                else
                {
                    if (first_line == 2)
                    {
                        if (!(lines[i].Contains("HS CODE :")))
                        {
                            if (!(lines[i].Contains(" NO:")))
                            {
                                Total = "";
                                if (lines[i].Contains("BALL STYLE "))
                                {
                                    toBeSearched = "BALL STYLE ";
                                    Total = lines[i].Substring(lines[i].IndexOf("BALL STYLE ") + toBeSearched.Length);
                                }
                                else
                                {
                                    Total = lines[i];
                                }
                                //tot = Total.Split(' ', '\t');
                                //tt = tot.Length;


                                pos = lines[i].Length - 5;
                                dot = lines[i].Substring(pos, 1);
                                if (dot == ".")
                                {
                                    Total = lines[i];
                                    tot = Total.Split(' ', '\t');
                                    tt = tot.Length;

                                    if (tt > 4)
                                    {
                                        for (int kk = 0; kk <= tot.Length - 5; kk++)
                                        {
                                            if (tot[0].Contains(".") && tot[kk].Contains("."))
                                            {

                                            }
                                            else
                                            {
                                                desc += tot[kk].ToString() + " ";
                                            }
                                        }
                                    }

                                    qty = tot[tot.Length - 3].ToString();
                                    unit = tot[tot.Length - 2].ToString();
                                    item_amt = tot[tot.Length - 1].ToString();
                                }
                                else
                                {
                                    tot = Total.Split(' ', '\t');
                                    tt = tot.Length;

                                    if (lines[i].Contains("KGS)")) // CAT Value not shows in Invoice
                                    {
                                        if (tt > 3)
                                        {
                                            for (int kk = 0; kk <= tot.Length - 4; kk++)
                                            {
                                                if (tot[0].Contains(".") && tot[kk].Contains("."))
                                                {

                                                }
                                                else
                                                {
                                                    desc += tot[kk].ToString() + " ";
                                                }
                                            }

                                            INFO_MSR = tot[tot.Length - 3].ToString().Replace("(", "").Replace(")", "").Trim();//INFO_MSR

                                            if (desc.TrimEnd() == "HANGER")
                                            {
                                                qty = INFO_MSR;
                                            }

                                        }
                                    }
                                    else
                                    {
                                        for (int kk = 0; kk <= tot.Length - 1; kk++)
                                        {
                                            if (tot[0].Contains(".") && tot[kk].Contains("."))
                                            {

                                            }
                                            else
                                            {
                                                desc += tot[kk].ToString() + " ";
                                            }
                                        }
                                    }

                                    if (desc.TrimEnd() != "")
                                    {
                                        if (lines[i + 1].Contains("HS CODE :"))
                                        {
                                            dt_itm.Rows.Add("1", INVOICE_NO, itm_slno = itm_slno + 1, desc.TrimEnd(), qty, ITEM_QTY_CODE, unit, item_amt, STATE_OF_ORIGIN, DISTRICT_OF_ORIGIN, UNDER_PTA_FTA, INFO_MSR);
                                            desc = "";
                                        }
                                    }
                                }



                            }
                            first_line = 2;
                        }
                        else// contains HS CODE: first_line = 2;
                        {
                            if (lines[i].Contains("BALL STYLE "))
                            {
                                toBeSearched = "BALL STYLE ";
                                Total = lines[i].Substring(lines[i].IndexOf("BALL STYLE ") + toBeSearched.Length);
                            }
                            else
                            {
                                Total = lines[i];
                            }

                            if (Total.Contains("HS CODE :"))
                            {
                                toBeSearched = "HS CODE :";
                                Total = lines[i].Substring(lines[i].IndexOf("HS CODE :") + toBeSearched.Length + 2);


                                tot = Total.Split(' ', '\t');
                                tt = tot.Length;

                                if (lines[i].Contains("KGS)") || lines[i].Contains("NOS)")) // CAT Value not shows in Invoice
                                {
                                    for (int k = 0; k <= tot.Length - 5; k++)
                                    {
                                        if (tot[0].Contains(".") && tot[k].Contains("."))
                                        {

                                        }
                                        else
                                        {
                                            desc += tot[k].ToString() + " ";
                                        }
                                    }

                                    if (tt > 3)// INFO_MSR
                                    {
                                        INFO_MSR = tot[tot.Length - 3].ToString().Replace("(", "").Replace(")", "").Trim();//INFO_MSR

                                        if (desc.TrimEnd() == "HANGER")
                                        {
                                            qty = INFO_MSR;
                                        }

                                    }
                                }
                                else
                                {
                                }



                                //if (tt > 4)
                                //{
                                //    pos = lines[i].Length - 5;
                                //    dot = lines[i].Substring(pos, 1);
                                //    if (dot == ".")
                                //    {
                                //        Total = lines[i];
                                //        tot = Total.Split(' ', '\t');
                                //        tt = tot.Length;

                                //        qty = tot[tot.Length - 3].ToString();
                                //        unit = tot[tot.Length - 2].ToString();
                                //        item_amt = tot[tot.Length - 1].ToString();
                                //    }

                                //    tot = lines[i].TrimStart().Split(' ', '\t');
                                //    tt = tot.Length;

                                //    for (int kk = 0; kk <= tot.Length - 4; kk++)
                                //    {
                                //        if (tot[0].Contains(".") && tot[kk].Contains("."))
                                //        {

                                //        }
                                //        else
                                //        { 
                                //            desc += tot[kk].ToString() + " ";
                                //        }
                                //    }
                                //}
                                //else// INFO_MSR
                                //{
                                //}
                            }




                            if (desc.TrimEnd() != "")
                            {
                                dt_itm.Rows.Add("1", INVOICE_NO, itm_slno = itm_slno + 1, desc.TrimEnd(), qty, ITEM_QTY_CODE, unit, item_amt, STATE_OF_ORIGIN, DISTRICT_OF_ORIGIN, UNDER_PTA_FTA, INFO_MSR);
                            }
                            //Item Desc - Finish with HS Code
                            first_line = 2;
                            desc = "";
                        }
                    }

                    if (lines[i].Contains("BOND #") || lines[i].Contains("Amount Chargeable") || lines[i].Contains("TOTAL HANGERS USED:"))
                    {
                        break;
                    }
                }
                if (lines[i].Contains("BOND #") || lines[i].Contains("Amount Chargeable") || lines[i].Contains("TOTAL HANGERS USED:"))
                {
                    break;
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
            ds_except = exp_pdf.Exp_PDF_Upload_New_XML(Dt_gen, dt_itm, dt_dbk, Dt_Invoice, Dt_anx);

            if (ds_except.Tables[0].Rows.Count > 0)
            {
                hdn_missed_Desc.Value = "1";
                gv_ItemPDF.DataSource = ds_except.Tables[0];
                gv_ItemPDF.DataBind();
                btnupload.Visible = false;
            }
            else
            {
                // get DBK SLno List from PDF

                exp_pdf.flag = "Get_DBK_slno_List";
                ds_except = exp_pdf.Exp_PDF_Upload_New_XML(Dt_gen, dt_itm, dt_dbk, Dt_Invoice, Dt_anx);
                hdn_missed_Desc.Value = "0";
                btnupload.Visible = true;

                if (ds_except.Tables[0].Rows.Count > 0)
                {
                    Auto.Ename = "DRAWBACK_MASTER_ALL_Excel_Upload";
                    Auto.Enamesearch = ds_except.Tables[0].Rows[0]["Dbkslno"].ToString();
                    Auto.Notn_No_Search = "";
                    ds_draw = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
                }



                //-----------EXPORT_GENERAL_DETAILS---------------------------------

                JOBID = Convert.ToString(Get_general_MAXID("Gen_MAX_ID"));
                Session["JOBIDexcel"] = JOBID;
                AUTO_JOBNO();


                SB_TYPE = "Free Duty";
                CUSTOMS_HOUSE = Session["CUSTOMHOUSE_CODE"].ToString();


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
                Dt_gen.Columns.Add("JOB_PREFIX");
                Dt_gen.Columns.Add("JOB_SUFFIX");
                Dt_gen.Columns.Add("JOBNO_PS");


                //Dt_gen.Rows.Add(exp_name, branch_slno, txtConsigneeName.Text, CONSIGNEE_BRANCHSLNO, hdfTransport_mode.Value, CUSTOMS_HOUSE, COUNTRY_DISCHARGE, PORT_DISCHARGE, COUNTRY_FINAL_DEST, PORT_FINAL_DEST, STATE_OF_EXPORT, MARKS_NO, hdprefix.Value, hdsuffix.Value, hdn_JOBNO_PS.Value);
                Dt_gen.Rows.Add(exp_name, branch_slno, txtConsigneeName.Text, CONSIGNEE_BRANCHSLNO, hdfTransport_mode.Value, CUSTOMS_HOUSE, COUNTRY_DISCHARGE, PORT_DISCHARGE, COUNTRY_FINAL_DEST, PORT_FINAL_DEST, STATE_OF_EXPORT, MARKS_NO, hdprefix.Value, hdsuffix.Value, hdn_JOBNO_digit.Value);



                //-----------EXPORT_ANNEXURE_C_SEA---------------------------------

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



                ANNEX_SEA_FAC_STUFFED = "N";
                ANNEX_SEA_SAMPLE_ACCOM = "N";
                ANNEX_SEA_NATURE_OF_CARGO = "C";
                ANNEX_SEA_TOTAL_PACKAGES = ANNEX_SEA_PACK_TO;
                ANNEX_SEA_NO_CONTAINERS = "0";
                ANNEX_SEA_UNIT_MEASUREMENT = "KGS";
                ANNEX_SEA_SEAL_TYPE = "Warehouse";


                Dt_anx.Rows.Add(ANNEX_SEA_FAC_STUFFED, ANNEX_SEA_SAMPLE_ACCOM, ANNEX_SEA_NATURE_OF_CARGO, MARKS_NO, ANNEX_SEA_TOTAL_PACKAGES, ANNEX_SEA_NO_CONTAINERS, ANNEX_SEA_UNIT_MEASUREMENT, ANNEX_SEA_SEAL_TYPE, ANNEX_SEA_GROSS_WEIGHT, ANNEX_SEA_NET_WEIGHT, ANNEX_SEA_PKG_UNIT_CODE);



                ViewState["Dt_gen"] = Dt_gen;
                ViewState["Dt_Invoice"] = Dt_Invoice;
                ViewState["Dt_Item"] = dt_itm;
                ViewState["Dt_draw"] = ds_draw.Tables[0];
                ViewState["Dt_anx"] = Dt_anx;


                gv_ItemPDF.DataSource = dt_itm;
                gv_ItemPDF.DataBind();

                //--#PDF
            }


        }//end if (FilePDF.HasFile)
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
        if(val.Contains("."))
        {
            string digit="";
            string[] splt = val.Split('.');
            if (splt[1].Length > 5)
            {
                int tot=splt[1].Length-5;
                digit = splt[1].Substring(0, splt[1].Length - tot);
                val = splt[0] + "." + digit;
            }
        }
        
        return val;
    }
        
  
}