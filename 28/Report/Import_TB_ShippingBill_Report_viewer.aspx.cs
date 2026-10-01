using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Data.SqlClient;

using System.IO;
using Microsoft.ApplicationBlocks.Data;
using System.ComponentModel;
using System.Drawing.Printing;

using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Web.UI.WebControls.WebParts;
//using ReportViewerLib;
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Reporting.WebForms;
using AjaxControlToolkit;
using Microsoft.ReportingServices.Rendering;
using Microsoft.ReportingServices.Library;




public partial class Import_TB_ShippingBill_Report_viewer : System.Web.UI.Page
{

    # region Private Attributes

    private string _ID, _JOBNO, _Sb_TYPE, _INVOICE_NO, _ShippingBill_No_Date, _Exporters_Reference;
    private string _ExporterName, _ExporterAdd1, _ExporterAdd2, _ExporterAdd3, _ExporterAdd4, _ExporterAdd5;
    private string _ConsigneeName, _ConsigneeAdd1, _ConsigneeAdd2, _ConsigneeAdd3, _ConsigneeAdd4, _ConsigneeAdd5;
    private string _CustomHouseAgent, _AgentLICNo, _PrecarriageBy, _VesselFlightNo, _Port_Of_Discharge;
    private string _AR4_No_Date, _Q_CertNo_Date, _ExportTradeControl, _Place_Receipt_ByCarrier, _RotationNo, _Port_Of_Loading, _Country_Destination, _ImpEx_CodeNo_BIN, _RBI_CodeNo;
    private string _RB_DefferedCredit, _RB_Joint_Ventures, _RB_Rupees_Credit, _RB_Exporter_Others, _RB_OutRightSales, _RB_Consignment, _RB_Ship_Others, _RB_CIF, _RB_CFR, _RB_FOB, _RB_NatureOfOthers, _ExchangeRate_US, _Invoice_Currency;
    private string _Net_Weight, _GrossWeight, _FOB_In_Words, _CIF_FOB_Currency, _CIF_FOB_Amount, _Currency, _Amount;
    private string _FOBValue_Currency, _FOBValue_Amount, _Freight_Currency, _Freight_Amount, _Insurance_Currency, _Insurance_Amount;
    private string _Commission_Currency, _Commission_Amount, _Discount_Currency, _Discount_Amount, _Otherdeduction_Currency, _Otherdeduction_Amount;
    private string _GR_No, _Gi_BondNo, _Declaration_Clause, _public_Notice, _public_Date, _Remarks, _DBK_Tarrif, _DBK_AssblValue, _DutyPercentage, _DutyAmount, _DutyForgon;
    private string _InvoiceAmount1, _RBIApprovalNo;

    private string _BRANCH_CODE;
    private string _YEAR;
    private string _WORKING_PERIOD;
    private string _BRANCH_COMMON, _LOGINDATE;

    private string _Ename, _flag, _USER_ID;
    public string Assbl_Value;
    #endregion

    # region Public Attributes

    public string ID { get { return _ID; } set { _ID = value; } }
    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string Sb_TYPE { get { return _Sb_TYPE; } set { _Sb_TYPE = value; } }
    public string INVOICE_NO { get { return _INVOICE_NO; } set { _INVOICE_NO = value; } }
    public string ShippingBill_No_Date { get { return _ShippingBill_No_Date; } set { _ShippingBill_No_Date = value; } }
    public string Exporters_Reference { get { return _Exporters_Reference; } set { _Exporters_Reference = value; } }


    public string ExporterName { get { return _ExporterName; } set { _ExporterName = value; } }
    public string ExporterAdd1 { get { return _ExporterAdd1; } set { _ExporterAdd1 = value; } }
    public string ExporterAdd2 { get { return _ExporterAdd2; } set { _ExporterAdd2 = value; } }
    public string ExporterAdd3 { get { return _ExporterAdd3; } set { _ExporterAdd3 = value; } }
    public string ExporterAdd4 { get { return _ExporterAdd4; } set { _ExporterAdd4 = value; } }
    public string ExporterAdd5 { get { return _ExporterAdd5; } set { _ExporterAdd5 = value; } }


    public string ConsigneeName { get { return _ConsigneeName; } set { _ConsigneeName = value; } }
    public string ConsigneeAdd1 { get { return _ConsigneeAdd1; } set { _ConsigneeAdd1 = value; } }
    public string ConsigneeAdd2 { get { return _ConsigneeAdd2; } set { _ConsigneeAdd2 = value; } }
    public string ConsigneeAdd3 { get { return _ConsigneeAdd3; } set { _ConsigneeAdd3 = value; } }
    public string ConsigneeAdd4 { get { return _ConsigneeAdd4; } set { _ConsigneeAdd4 = value; } }
    public string ConsigneeAdd5 { get { return _ConsigneeAdd5; } set { _ConsigneeAdd5 = value; } }

    public string CustomHouseAgent { get { return _CustomHouseAgent; } set { _CustomHouseAgent = value; } }
    public string AgentLICNo { get { return _AgentLICNo; } set { _AgentLICNo = value; } }
    public string PrecarriageBy { get { return _PrecarriageBy; } set { _PrecarriageBy = value; } }
    public string VesselFlightNo { get { return _VesselFlightNo; } set { _VesselFlightNo = value; } }
    public string Port_Of_Discharge { get { return _Port_Of_Discharge; } set { _Port_Of_Discharge = value; } }

    public string AR4_No_Date { get { return _AR4_No_Date; } set { _AR4_No_Date = value; } }
    public string Q_CertNo_Date { get { return _Q_CertNo_Date; } set { _Q_CertNo_Date = value; } }
    public string ExportTradeControl { get { return _ExportTradeControl; } set { _ExportTradeControl = value; } }
    public string Place_Receipt_ByCarrier { get { return _Place_Receipt_ByCarrier; } set { _Place_Receipt_ByCarrier = value; } }
    public string RotationNo { get { return _RotationNo; } set { _RotationNo = value; } }
    public string Port_Of_Loading { get { return _Port_Of_Loading; } set { _Port_Of_Loading = value; } }
    public string Country_Destination { get { return _Country_Destination; } set { _Country_Destination = value; } }
    public string ImpEx_CodeNo_BIN { get { return _ImpEx_CodeNo_BIN; } set { _ImpEx_CodeNo_BIN = value; } }
    public string RBI_CodeNo { get { return _RBI_CodeNo; } set { _RBI_CodeNo = value; } }

    public string RB_DefferedCredit { get { return _RB_DefferedCredit; } set { _RB_DefferedCredit = value; } }
    public string RB_Joint_Ventures { get { return _RB_Joint_Ventures; } set { _RB_Joint_Ventures = value; } }
    public string RB_Rupees_Credit { get { return _RB_Rupees_Credit; } set { _RB_Rupees_Credit = value; } }
    public string RB_Exporter_Others { get { return _RB_Exporter_Others; } set { _RB_Exporter_Others = value; } }
    public string RB_OutRightSales { get { return _RB_OutRightSales; } set { _RB_OutRightSales = value; } }
    public string RB_Consignment { get { return _RB_Consignment; } set { _RB_Consignment = value; } }
    public string RB_Ship_Others { get { return _RB_Ship_Others; } set { _RB_Ship_Others = value; } }
    public string RB_CIF { get { return _RB_CIF; } set { _RB_CIF = value; } }
    public string RB_CFR { get { return _RB_CFR; } set { _RB_CFR = value; } }
    public string RB_FOB { get { return _RB_FOB; } set { _RB_FOB = value; } }
    public string RB_NatureOfOthers { get { return _RB_NatureOfOthers; } set { _RB_NatureOfOthers = value; } }
    public string ExchangeRate_US { get { return _ExchangeRate_US; } set { _ExchangeRate_US = value; } }
    public string Invoice_Currency { get { return _Invoice_Currency; } set { _Invoice_Currency = value; } }

    public string Net_Weight { get { return _Net_Weight; } set { _Net_Weight = value; } }
    public string GrossWeight { get { return _GrossWeight; } set { _GrossWeight = value; } }
    public string FOB_In_Words { get { return _FOB_In_Words; } set { _FOB_In_Words = value; } }
    public string CIF_FOB_Currency { get { return _CIF_FOB_Currency; } set { _CIF_FOB_Currency = value; } }
    public string CIF_FOB_Amount { get { return _CIF_FOB_Amount; } set { _CIF_FOB_Amount = value; } }
    public string Currency { get { return _Currency; } set { _Currency = value; } }
    public string Amount { get { return _Amount; } set { _Amount = value; } }

    public string FOBValue_Currency { get { return _FOBValue_Currency; } set { _FOBValue_Currency = value; } }
    public string FOBValue_Amount { get { return _FOBValue_Amount; } set { _FOBValue_Amount = value; } }
    public string Freight_Currency { get { return _Freight_Currency; } set { _Freight_Currency = value; } }
    public string Freight_Amount { get { return _Freight_Amount; } set { _Freight_Amount = value; } }
    public string Insurance_Currency { get { return _Insurance_Currency; } set { _Insurance_Currency = value; } }
    public string Insurance_Amount { get { return _Insurance_Amount; } set { _Insurance_Amount = value; } }

    public string Commission_Currency { get { return _Commission_Currency; } set { _Commission_Currency = value; } }
    public string Commission_Amount { get { return _Commission_Amount; } set { _Commission_Amount = value; } }
    public string Discount_Currency { get { return _Discount_Currency; } set { _Discount_Currency = value; } }
    public string Discount_Amount { get { return _Discount_Amount; } set { _Discount_Amount = value; } }
    public string Otherdeduction_Currency { get { return _Otherdeduction_Currency; } set { _Otherdeduction_Currency = value; } }
    public string Otherdeduction_Amount { get { return _Otherdeduction_Amount; } set { _Otherdeduction_Amount = value; } }

    public string GR_No { get { return _GR_No; } set { _GR_No = value; } }
    public string Gi_BondNo { get { return _Gi_BondNo; } set { _Gi_BondNo = value; } }
    public string Declaration_Clause { get { return _Declaration_Clause; } set { _Declaration_Clause = value; } }
    public string public_Notice { get { return _public_Notice; } set { _public_Notice = value; } }
    public string public_Date { get { return _public_Date; } set { _public_Date = value; } }
    public string Remarks { get { return _Remarks; } set { _Remarks = value; } }
    public string DBK_Tarrif { get { return _DBK_Tarrif; } set { _DBK_Tarrif = value; } }
    public string DBK_AssblValue { get { return _DBK_AssblValue; } set { _DBK_AssblValue = value; } }
    public string DutyPercentage { get { return _DutyPercentage; } set { _DutyPercentage = value; } }
    public string DutyAmount { get { return _DutyAmount; } set { _DutyAmount = value; } }
    public string DutyForgon { get { return _DutyForgon; } set { _DutyForgon = value; } }
    public string InvoiceAmount1 { get { return _InvoiceAmount1; } set { _InvoiceAmount1 = value; } }
    public string RBIApprovalNo { get { return _RBIApprovalNo; } set { _RBIApprovalNo = value; } }

    public string flag { get { return _flag; } set { _flag = value; } }
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }
    public string BRANCH_COMMON { get { return _BRANCH_COMMON; } set { _BRANCH_COMMON = value; } }
    public string LOGINDATE { get { return _LOGINDATE; } set { _LOGINDATE = value; } }


    #endregion


    #region SB_Grid_Attributes

    public string _ITEM_SLNO, _MARKS_NO, _ITEM_DESCRIPTION, _ITEM_QTY, _ITEM_QTY_CODE, _FOB_VALUE, _RITCNO;

    public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }
    public string MARKS_NO { get { return _MARKS_NO; } set { _MARKS_NO = value; } }
    public string ITEM_DESCRIPTION { get { return _ITEM_DESCRIPTION; } set { _ITEM_DESCRIPTION = value; } }
    public string RITCNO { get { return _RITCNO; } set { _RITCNO = value; } }
    public string ITEM_QTY { get { return _ITEM_QTY; } set { _ITEM_QTY = value; } }
    public string ITEM_QTY_CODE { get { return _ITEM_QTY_CODE; } set { _ITEM_QTY_CODE = value; } }
    public string FOB_VALUE { get { return _FOB_VALUE; } set { _FOB_VALUE = value; } }

    #endregion SB_Grid_Attributes

    #region Grid_Data

    public string _MarksNos, _Description, _Quantity, _No_Of_Package;

    public string MarksNos { get { return _MarksNos; } set { _MarksNos = value; } }
    //public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }
    public string Description { get { return _Description; } set { _Description = value; } }
    public string Quantity { get { return _Quantity; } set { _Quantity = value; } }
    //public string GrossWeight { get { return _GrossWeight; } set { _GrossWeight = value; } }
    public string No_Of_Package { get { return _No_Of_Package; } set { _No_Of_Package = value; } }

    #endregion 

    public string TICK_MARK = ((char)0x221A).ToString();
    public string working_period, Check_RB_DefferedCredit, check_RB_OutRightSales,Check_NatureOfContract;

    AppSession aps = new AppSession();
    Transaction Transact = new Transaction();
    adminmaster adm = new adminmaster();
    Exp_ShipingBill_Dutyfree_Dbk TB_ShipBill = new Exp_ShipingBill_Dutyfree_Dbk();

    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
    DataSet ds2 = new DataSet();

    
    public int ii;
   
    public string currentuser, ddlJobNo;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate,SB_Type;
    public string SELECT_TYPE, SELECT_BRANCH;


    public string part1, part2, part3, Vessel1, Vessel2, Vessel3, WP_End, Vessel_YEAR_END, YEAR_END, SplitBranch, Bond_YEAR_END;
    
    CheckList CHKLIST = new CheckList();
    Date_Time dt = new Date_Time();   
    DataTable dtt = new DataTable();

    List<Exp_ShipingBill_Dutyfree_Dbk> Exp_ShipingBill_Dutyfree_Dbk = new List<Exp_ShipingBill_Dutyfree_Dbk>();

   
   
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = HttpContext.Current.Session["currentcomp_db"].ToString();
        working_period = HttpContext.Current.Session["WorkingPeriod"].ToString();
        LoginDate = HttpContext.Current.Session["LoginDate"].ToString();
     
            // commented for areawise implementation on 05-mar-2020
        /*
        if (Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = Session["SELECT_TYPE"].ToString();

            if (SELECT_TYPE == "Branchwise Job")
            {
                SELECT_BRANCH = currentbranch;
            }
            else
            {
                SELECT_BRANCH = "";
            }
        }
        else
        {
            SELECT_BRANCH = "";
        }
          * */
        SELECT_BRANCH = Connection.Get_Company_Type();
 
        if (!IsPostBack)
        {
     
        
            btn_print.Visible = true;
            //btn_print2.Visible = false;
            //btnSend.Visible = false;
            //Load_N_Trans_Details();

            //Load_TransPermit_Details();
        }
        Load_TransPermit_Details();
    }

    

    public void Get_DS()
    {
        try
        {

            TB_ShipBill.JOBNO = ddlJobNo;
            TB_ShipBill.BRANCH_CODE = currentbranch;
            TB_ShipBill.BRANCH_COMMON = SELECT_BRANCH;
            TB_ShipBill.WORKING_PERIOD = working_period;
            //ManualSB.Sb_TYPE = SB_Type;
            TB_ShipBill.flag = "Get_TB_SHIPPINGBILL_LIST";

            ds = TB_ShipBill.Retreive_TB_ShippingBill();

            if (ds.Tables[0].Rows.Count > 0)
            {

             
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();

            er.makeLog
                (ex.Message);
        }

  }

    public void Get_DS_Grid(DataTable dtt)
    {
       
         try
        {
            //SB_Type = Request.QueryString["Type"].ToString();
            //ddlJobNo = Request.QueryString["jobno"].ToString();

            TB_ShipBill.JOBNO = ddlJobNo;
            TB_ShipBill.BRANCH_CODE = currentbranch;
            TB_ShipBill.BRANCH_COMMON = SELECT_BRANCH;
            TB_ShipBill.WORKING_PERIOD = working_period;
            //ManualSB.Sb_TYPE = SB_Type;
            TB_ShipBill.flag = "Get_TB_SHIPPINGBILL_GRID";

            ds1 = TB_ShipBill.Retreive_TB_ShippingBill();

            string a1 = ds1.Tables[0].Rows[0]["MARKS_NO"].ToString();
            string a2 = ds1.Tables[0].Rows[1]["MARKS_NO"].ToString();


            string itemqty = ds1.Tables[0].Rows[0]["ITEM_QTY"].ToString();

            string[] splt_itemQty = itemqty.Split('-');
            string ITEM_QTY1 = splt_itemQty[0];

            dtt = ds1.Tables[0];
            if (dtt.Rows.Count > ii)
            {

            if (ds1.Tables[0].Rows.Count > ii)
            {
                int i = 0;

                while (dtt.Rows.Count > i)
                {

                    DataRow drw = dtt.Rows[ii];

                    Exp_ShipingBill_Dutyfree_Dbk.Add(new Exp_ShipingBill_Dutyfree_Dbk()
                    {
                        MARKS_NO = MARKS_NO,
                        ITEM_DESCRIPTION = ITEM_DESCRIPTION,
                        RITCNO = RITCNO,
                        ITEM_QTY = ITEM_QTY1,
                        ITEM_QTY_CODE = ITEM_QTY_CODE,
                        FOB_VALUE = FOB_VALUE

                    });
                    i++;
                }
            }

            }
           
        }
         catch (Exception ex)
         {
             ErrorLogs er = new ErrorLogs();

             er.makeLog
                 (ex.Message);
         }

    }

   

    public void Load_TransPermit_Details()
    {    
        try
        {
            string Btn_Type = string.Empty;

            if (Request.QueryString["jobno"] == "" || Request.QueryString["jobno"] == null)
            {

            }
            else
            {
                ddlJobNo = Request.QueryString["jobno"].ToString();


                    Get_DS();
                    Get_DS_Grid(dtt);
                 
                    List<ReportParameter> paramList = new List<ReportParameter>();
                    this.ReportViewer1.LocalReport.SetParameters(paramList);
                    ReportViewer1.LocalReport.DataSources.Clear();

                    ReportDataSource dataSS = new ReportDataSource("Import_TB_ShippingBill_DataSet", TB_ShipBill.Load_Import_TB_ShipplingBill(ds.Tables[0]));
                    ReportViewer1.LocalReport.DataSources.Add(dataSS);

                    ReportDataSource datasource = new ReportDataSource("Import_TB_ShipBill_Grid_DataSet", TB_ShipBill.Load_TB_ShipplingBill_Grid(ds1.Tables[0]));
                    ReportViewer1.LocalReport.DataSources.Add(datasource);

                   

                    Check_RB_DefferedCredit = ds.Tables[0].Rows[0]["RB_DefferedCredit"].ToString();

                    if (Check_RB_DefferedCredit != "")
                    {
                        if (Check_RB_DefferedCredit == "RupeesCredit")
                        {
                            ReportParameter p3 = new ReportParameter("RupeesCredit", TICK_MARK);
                            //ReportParameter p3 = new ReportParameter("RupeesCredit", TICK_MARK + ds.Tables[0].Rows[0]["RB_DefferedCredit"].ToString());
                            ReportParameter[] px = { p3 };
                            ReportViewer1.LocalReport.SetParameters(px);

                        }

                        if (Check_RB_DefferedCredit == "Deferred Credit")
                        {
                            ReportParameter p3 = new ReportParameter("DeferredCredit", TICK_MARK);
                            ReportParameter[] px = { p3 };
                            ReportViewer1.LocalReport.SetParameters(px);
                        }
                        if (Check_RB_DefferedCredit == "JointVentures")
                        {
                            ReportParameter p3 = new ReportParameter("JointVentures", TICK_MARK);
                            ReportParameter[] px = { p3 };
                            ReportViewer1.LocalReport.SetParameters(px);
                        }
                        if (Check_RB_DefferedCredit == "Others")
                        {
                            ReportParameter p3 = new ReportParameter("Others1", TICK_MARK);
                            ReportParameter[] px = { p3 };
                            ReportViewer1.LocalReport.SetParameters(px);
                        }
                    }

                    check_RB_OutRightSales = ds.Tables[0].Rows[0]["RB_OutRightSales"].ToString();

                    if (check_RB_OutRightSales != "")
                    {
                        if (check_RB_OutRightSales == "OutRight Sales")
                        {
                            ReportParameter p3 = new ReportParameter("OutRight_Sales", TICK_MARK);
                            ReportParameter[] px = { p3 };
                            ReportViewer1.LocalReport.SetParameters(px);
                        }
                        if (check_RB_OutRightSales == "ConsignmentExport")
                        {
                            ReportParameter p3 = new ReportParameter("ConsignmentExport", TICK_MARK);
                            ReportParameter[] px = { p3 };
                            ReportViewer1.LocalReport.SetParameters(px);
                        }
                        if (check_RB_OutRightSales == "Others")
                        {
                            ReportParameter p3 = new ReportParameter("Others2", TICK_MARK);
                            ReportParameter[] px = { p3 };
                            ReportViewer1.LocalReport.SetParameters(px);
                        }

                    }

                    Check_NatureOfContract = ds.Tables[0].Rows[0]["RB_CIF"].ToString();

                    if (Check_NatureOfContract != "")
                    {
                        if (Check_NatureOfContract == "CIF")
                        {
                            ReportParameter p3 = new ReportParameter("CIF", TICK_MARK);
                            ReportParameter[] px = { p3 };
                            ReportViewer1.LocalReport.SetParameters(px);
                        }
                        if (Check_NatureOfContract == "CFR")
                        {
                            ReportParameter p3 = new ReportParameter("CFR", TICK_MARK);
                            ReportParameter[] px = { p3 };
                            ReportViewer1.LocalReport.SetParameters(px);
                        }
                        if (Check_NatureOfContract == "FOB")
                        {
                            ReportParameter p3 = new ReportParameter("FOB", TICK_MARK);
                            ReportParameter[] px = { p3 };
                            ReportViewer1.LocalReport.SetParameters(px);
                        }
                        if (Check_NatureOfContract == "Others")
                        {
                            ReportParameter p3 = new ReportParameter("Others3", TICK_MARK);
                            ReportParameter[] px = { p3 };
                            ReportViewer1.LocalReport.SetParameters(px);
                        }

                    }
                    string CHA_NAME = HttpContext.Current.Session["CHA_NAME"].ToString();
                    string cha_add1 = HttpContext.Current.Session["CHA_ADDRESS"].ToString();
                    string cha_add2 = HttpContext.Current.Session["CHA_ADDRESS1"].ToString();
                    string cha_add3 = HttpContext.Current.Session["CHA_ADDRESS2"].ToString();
                     Assbl_Value = ds1.Tables[0].Rows[2]["FOB_VALUE"].ToString();

                    ReportParameter param4 = new ReportParameter("CHA_NAME", HttpContext.Current.Session["CHA_NAME"].ToString());
                    ReportParameter param5 = new ReportParameter("cha_add1", HttpContext.Current.Session["CHA_ADDRESS"].ToString());
                    ReportParameter param6 = new ReportParameter("cha_add2", HttpContext.Current.Session["CHA_ADDRESS1"].ToString());
                    ReportParameter param7 = new ReportParameter("cha_add3", HttpContext.Current.Session["CHA_ADDRESS2"].ToString());
                    ReportParameter param8 = new ReportParameter("Assbl_Value", Assbl_Value);




                    ReportParameter[] p = { param4, param5, param6, param7, param8 };
                    ReportViewer1.LocalReport.SetParameters(p);

                    //  --------------------------------------To Print------------------------------------------------------------------------------------//
                    Warning[] warnings;
                    string[] streamIds;
                    string mimeType = string.Empty;
                    string encoding = string.Empty;
                    string extension = string.Empty;
                    string fileName = "a";
                    byte[] bytes = ReportViewer1.LocalReport.Render("pdf", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                    Session.Remove("report");
                    Session["report"] = bytes;
                    //--------------------------------------To Print------------------------------------------------------------------------------------//             

            }
        }

        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();

            er.makeLog
                (ex.Message);
        }
    }

    public void Load_N_Trans_Details()
    {
        ReportDataSource dataSS = new ReportDataSource("TB_ShippingBill_DataSet", TB_ShipBill.Load_Import_TB_ShipplingBill(ds.Tables[0]));       
        ReportViewer1.LocalReport.DataSources.Add(dataSS);       
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'MANUAL SB', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'MANUAL SB', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void ddlJob_No_SelectedIndexChanged(object sender, EventArgs e)
    {     
            Load_TransPermit_Details();
    }

  
}




