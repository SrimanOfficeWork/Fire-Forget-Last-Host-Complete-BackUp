using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.IO;

/// <summary>
/// Summary description for Exp_ShipingBill_Dutyfree_Dbk
/// </summary>
public class Exp_ShipingBill_Dutyfree_Dbk
{

    SqlDataAdapter da;
    SqlDataReader dr;
     DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    DataTable dtt = new DataTable();

    ErrorLogs er = new ErrorLogs();
    public DataTable inv_grid = new DataTable();
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    SqlCommand cmd;
    int A1, A2;
    //SqlConnection con = new SqlConnection();
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);
    public int result, UPDATE_ID = 0;


    # region Private Attributes

    public string _ID, _JOBNO, _Sb_TYPE, _INVOICE_NO, _ShippingBill_No_Date, _Exporters_Reference;
    public string _ExporterName, _ExporterAdd1, _ExporterAdd2, _ExporterAdd3, _ExporterAdd4, _ExporterAdd5;
    public string _ConsigneeName, _ConsigneeAdd1, _ConsigneeAdd2, _ConsigneeAdd3, _ConsigneeAdd4, _ConsigneeAdd5;
    public string _CustomHouseAgent, _AgentLICNo, _PrecarriageBy, _VesselFlightNo, _Port_Of_Discharge;
    public string _AR4_No_Date, _Q_CertNo_Date, _ExportTradeControl, _Place_Receipt_ByCarrier, _RotationNo, _Port_Of_Loading, _Country_Destination, _ImpEx_CodeNo_BIN, _RBI_CodeNo;
    public string _RB_DefferedCredit, _RB_Joint_Ventures, _RB_Rupees_Credit, _RB_Exporter_Others, _RB_OutRightSales, _RB_Consignment, _RB_Ship_Others, _RB_CIF, _RB_CFR, _RB_FOB, _RB_NatureOfOthers, _ExchangeRate_US, _Invoice_Currency;
    public string _Net_Weight, _GrossWeight, _FOB_In_Words, _CIF_FOB_Currency, _CIF_FOB_Amount, _Currency, _Amount;
    public string _FOBValue_Currency, _FOBValue_Amount, _Freight_Currency, _Freight_Amount, _Insurance_Currency, _Insurance_Amount;
    public string _Commission_Currency, _Commission_Amount, _Discount_Currency, _Discount_Amount, _Otherdeduction_Currency, _Otherdeduction_Amount;
    public string _GR_No, _Gi_BondNo, _Declaration_Clause, _public_Notice, _public_Date, _Remarks, _DBK_Tarrif, _DBK_AssblValue, _DutyPercentage, _DutyAmount, _DutyForgon;
    public string _InvoiceAmount1, _RBIApprovalNo;


    public string _OriginOfGoods, _BillOfEntryNo, _BillOfEntryDate, _BondNo, _Bond_Date,  _NoOfPkgs, _VesselName, _RotationNoLCD, _WarehouseName;
    public string _TBNo, _TBDate, _IGMNo, _IGMDate;


    public string _BRANCH_CODE;
    public string _YEAR;
    public string _WORKING_PERIOD;
    public string _BRANCH_COMMON, _LOGINDATE;

    public string _Ename, _flag, _USER_ID;
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



    public string GR_No { get { return _GR_No; } set { _GR_No = value; } }
    public string OriginOfGoods { get { return _OriginOfGoods; } set { _OriginOfGoods = value; } }
    public string BillOfEntryNo { get { return _BillOfEntryNo; } set { _BillOfEntryNo = value; } }
    public string BillOfEntryDate { get { return _BillOfEntryDate; } set { _BillOfEntryDate = value; } }
    public string BondNo { get { return _BondNo; } set { _BondNo = value; } }
    public string Bond_Date { get { return _Bond_Date; } set { _Bond_Date = value; } }
    public string NoOfPkgs { get { return _NoOfPkgs; } set { _NoOfPkgs = value; } }
    public string VesselName { get { return _VesselName; } set { _VesselName = value; } }
    public string RotationNoLCD { get { return _RotationNoLCD; } set { _RotationNoLCD = value; } }
    public string WarehouseName { get { return _WarehouseName; } set { _WarehouseName = value; } }


    public string TBNo { get { return _TBNo; } set { _TBNo = value; } }
    public string TBDate { get { return _TBDate; } set { _TBDate = value; } }
    public string IGMNo { get { return _IGMNo; } set { _IGMNo = value; } }
    public string IGMDate { get { return _IGMDate; } set { _IGMDate = value; } }
   

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

    public Exp_ShipingBill_Dutyfree_Dbk()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int SB_DBK_DutyFree_Insert_Update()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[100];

            //param[0] = new SqlParameter("@ID", ID);
            param[1] = new SqlParameter("@JOBNO", JOBNO);
            param[2] = new SqlParameter("@Sb_TYPE", Sb_TYPE);
            param[3] = new SqlParameter("@INVOICE_NO", INVOICE_NO);
            param[4] = new SqlParameter("@ShippingBill_No_Date", ShippingBill_No_Date);
            param[5] = new SqlParameter("@Exporters_Reference", Exporters_Reference);
            param[6] = new SqlParameter("@ExporterName", ExporterName);
            param[7] = new SqlParameter("@ExporterAdd1", ExporterAdd1);
            param[8] = new SqlParameter("@ExporterAdd2", ExporterAdd2);
            param[9] = new SqlParameter("@ExporterAdd3", ExporterAdd3);
            param[10] = new SqlParameter("@ExporterAdd4", ExporterAdd4);
            param[11] = new SqlParameter("@ExporterAdd5", ExporterAdd5);
            param[12] = new SqlParameter("@ConsigneeName", ConsigneeName);
            param[13] = new SqlParameter("@ConsigneeAdd1", ConsigneeAdd1);
            param[14] = new SqlParameter("@ConsigneeAdd2", ConsigneeAdd2);
            param[15] = new SqlParameter("@ConsigneeAdd3", ConsigneeAdd3);
            param[16] = new SqlParameter("@ConsigneeAdd4", ConsigneeAdd4);
            param[17] = new SqlParameter("@ConsigneeAdd5", ConsigneeAdd5);
            param[18] = new SqlParameter("@CustomHouseAgent", CustomHouseAgent);
            param[19] = new SqlParameter("@AgentLICNo", AgentLICNo);
            param[20] = new SqlParameter("@PrecarriageBy", PrecarriageBy);
            param[21] = new SqlParameter("@VesselFlightNo", VesselFlightNo);
            param[22] = new SqlParameter("@Port_Of_Discharge", Port_Of_Discharge);
            param[23] = new SqlParameter("@AR4_No_Date", AR4_No_Date);
            param[24] = new SqlParameter("@Q_CertNo_Date", Q_CertNo_Date);
            param[25] = new SqlParameter("@ExportTradeControl", ExportTradeControl);
            param[26] = new SqlParameter("@Place_Receipt_ByCarrier", Place_Receipt_ByCarrier);
            param[27] = new SqlParameter("@RotationNo", RotationNo);
            param[28] = new SqlParameter("@Port_Of_Loading", Port_Of_Loading);
            param[29] = new SqlParameter("@Country_Destination", Country_Destination);
            param[30] = new SqlParameter("@ImpEx_CodeNo_BIN", ImpEx_CodeNo_BIN);
            param[31] = new SqlParameter("@RBI_CodeNo", RBI_CodeNo);
            param[32] = new SqlParameter("@RB_DefferedCredit", RB_DefferedCredit);
            param[33] = new SqlParameter("@RB_Joint_Ventures", RB_Joint_Ventures);
            param[34] = new SqlParameter("@RB_Rupees_Credit", RB_Rupees_Credit);
            param[35] = new SqlParameter("@RB_Exporter_Others", RB_Exporter_Others);
            param[36] = new SqlParameter("@RB_OutRightSales", RB_OutRightSales);
            param[37] = new SqlParameter("@RB_Consignment", RB_Consignment);
            param[38] = new SqlParameter("@RB_Ship_Others", RB_Ship_Others);
            param[39] = new SqlParameter("@RB_CIF", RB_CIF);
            param[40] = new SqlParameter("@RB_CFR", RB_Consignment);
            param[41] = new SqlParameter("@RB_FOB", RB_Ship_Others);
            //param[40] = new SqlParameter("@RB_CFR", InvoiceAmount1);
            //param[41] = new SqlParameter("@RB_FOB", RBIApprovalNo);
            //param[40] = new SqlParameter("@RB_CFR", RB_CFR);
            //param[41] = new SqlParameter("@RB_FOB", RB_FOB);
            param[42] = new SqlParameter("@RB_NatureOfOthers", RB_NatureOfOthers);
            param[43] = new SqlParameter("@ExchangeRate_US", ExchangeRate_US);
            param[44] = new SqlParameter("@Invoice_Currency", Invoice_Currency);
            param[45] = new SqlParameter("@Net_Weight", Net_Weight);
            param[46] = new SqlParameter("@GrossWeight", GrossWeight);
            param[47] = new SqlParameter("@FOB_In_Words", FOB_In_Words);
            param[48] = new SqlParameter("@CIF_FOB_Currency", CIF_FOB_Currency);
            param[49] = new SqlParameter("@CIF_FOB_Amount", CIF_FOB_Amount);
            param[50] = new SqlParameter("@Currency", Currency);
            param[51] = new SqlParameter("@Amount", Amount);
            param[52] = new SqlParameter("@FOBValue_Currency", FOBValue_Currency);
            param[53] = new SqlParameter("@FOBValue_Amount", FOBValue_Amount);
            param[54] = new SqlParameter("@Freight_Currency", Freight_Currency);
            param[55] = new SqlParameter("@Freight_Amount", Freight_Amount);
            param[56] = new SqlParameter("@Insurance_Currency", Insurance_Currency);
            param[57] = new SqlParameter("@Insurance_Amount", Insurance_Amount);
            param[58] = new SqlParameter("@Commission_Currency", Commission_Currency);
            param[59] = new SqlParameter("@Commission_Amount", Commission_Amount);
            param[60] = new SqlParameter("@Discount_Currency", Discount_Currency);
            param[61] = new SqlParameter("@Discount_Amount", Discount_Amount);
            param[62] = new SqlParameter("@Otherdeduction_Currency", Otherdeduction_Currency);
            param[63] = new SqlParameter("@Otherdeduction_Amount", Otherdeduction_Amount);
            param[64] = new SqlParameter("@GR_No", GR_No);
            param[65] = new SqlParameter("@Gi_BondNo", Gi_BondNo);
            param[66] = new SqlParameter("@Declaration_Clause", Declaration_Clause);
            param[67] = new SqlParameter("@public_Notice", public_Notice);
            param[68] = new SqlParameter("@public_Date", public_Date);
            param[69] = new SqlParameter("@Remarks", Remarks);
            param[70] = new SqlParameter("@DBK_Tarrif", DBK_Tarrif);
            param[71] = new SqlParameter("@DBK_AssblValue", DBK_AssblValue);
            param[72] = new SqlParameter("@DutyPercentage", DutyPercentage);
            param[73] = new SqlParameter("@DutyAmount", DutyAmount);
            param[74] = new SqlParameter("@DutyForgon", DutyForgon);
            param[75] = new SqlParameter("@BranchCode", BRANCH_CODE);
            param[76] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
            param[77] = new SqlParameter("@WORKINGPERIOD", WORKING_PERIOD);
            param[78] = new SqlParameter("@YEAR", YEAR);
            param[79] = new SqlParameter("@USER_ID", USER_ID);
            param[80] = new SqlParameter("@LOGINDATE", LOGINDATE);
            param[81] = new SqlParameter("@Mflag", flag);
            param[82] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[82].Direction = ParameterDirection.Output;
            param[83] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[83].Direction = ParameterDirection.Output;
         
            SqlHelper.ExecuteNonQuery(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "Sp_Manual_SB_Duty_DBK", param);

            result = Convert.ToInt32(param[82].Value.ToString());
        }
        catch (Exception ex)
        {

            er.makeLog(ex.Message);
        }

        return result;
    }

    public int SB_Duty_Dbk_Grid_Insert_Update()
    {
        SqlParameter[] param = new SqlParameter[25];

        param[18] = new SqlParameter("@ID", ID);
        param[1] = new SqlParameter("@JOBNO", JOBNO);
        param[2] = new SqlParameter("@SB_TYPE", Sb_TYPE);
        param[3] = new SqlParameter("@MARKS_NO", MARKS_NO);
        param[4] = new SqlParameter("@ITEM_DESCRIPTION", ITEM_DESCRIPTION);
        param[5] = new SqlParameter("@RITCNO",RITCNO );
        param[6] = new SqlParameter("@ITEM_QTY", ITEM_QTY);
        param[7] = new SqlParameter("@ITEM_QTY_CODE", ITEM_QTY_CODE);
        param[8] = new SqlParameter("@FOB_VALUE", FOB_VALUE);
        param[9] = new SqlParameter("@BRANCHCODE", BRANCH_CODE);
        param[10] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
        param[11] = new SqlParameter("@YEAR", YEAR);
        param[12] = new SqlParameter("@USERID", USER_ID);
        param[13] = new SqlParameter("@LOGINDATE", LOGINDATE);
        param[14] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
        param[15] = new SqlParameter("@Mflag", flag);
        param[16] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
        param[16].Direction = ParameterDirection.Output;
        param[17] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
        param[17].Direction = ParameterDirection.Output;

        SqlHelper.ExecuteNonQuery(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "Sp_Manual_SB_Duty_DBK_Grid_INSERT_UPDATE", param);

        //SqlHelper.ExecuteNonQuery(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "Sp_Manual_SB_Duty_DBK_Grid", param);
        result = Convert.ToInt32(param[16].Value.ToString());

        return result;
    }

    public DataSet Retreive_SB_Duty_DBK()
    {
        SqlParameter[] param = new SqlParameter[15];

        param[0]=new SqlParameter("@JOBNO",JOBNO);
        param[1] = new SqlParameter("@Working_Period", WORKING_PERIOD);
        param[2]=new SqlParameter("@Branch",BRANCH_CODE);
        param[3] = new SqlParameter("@name", flag);
        param[4] = new SqlParameter("@BRANCHCOMMON", BRANCH_COMMON);
        param[7] = new SqlParameter("@Type", Sb_TYPE);
        param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
        param[5].Direction = ParameterDirection.Output;
        param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
        param[6].Direction = ParameterDirection.Output;

        ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "Sp_Manual_SB_Duty_DBK_BIND_ALL", param);
        //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "Sp_Manual_SB_Duty_DBK_BIND_ALL_Check", param);

        result = Convert.ToInt32(param[5].Value.ToString());

        return ds;
    }

    public List<Exp_ShipingBill_Dutyfree_Dbk> Load_ManualShipplingBill(DataTable dt)
    {
        List<Exp_ShipingBill_Dutyfree_Dbk> list = new List<Exp_ShipingBill_Dutyfree_Dbk>();

        int i = 0;

        //while (dt.Rows.Count > i)
        //{
        DataRow row = dt.Rows[i];

        list.Add(new Exp_ShipingBill_Dutyfree_Dbk()
        {
            JOBNO = row["JOBNO"].ToString(),
            Sb_TYPE = row["Sb_TYPE"].ToString(),
            INVOICE_NO = row["INVOICE_NO"].ToString(),
            ShippingBill_No_Date = row["ShippingBill_No_Date"].ToString(),
            Exporters_Reference = row["Exporters_Reference"].ToString(),
            ExporterName = row["ExporterName"].ToString(),
            ExporterAdd1 = row["ExporterAdd1"].ToString(),
            ExporterAdd2 = row["ExporterAdd2"].ToString(),
            ExporterAdd3 = row["ExporterAdd3"].ToString(),
            ExporterAdd4 = row["ExporterAdd4"].ToString(),
            ExporterAdd5 = row["ExporterAdd5"].ToString(),
            ConsigneeName = row["ConsigneeName"].ToString(),
            ConsigneeAdd1 = row["ConsigneeAdd1"].ToString(),
            ConsigneeAdd2 = row["ConsigneeAdd2"].ToString(),
            ConsigneeAdd3 = row["ConsigneeAdd3"].ToString(),
            ConsigneeAdd4 = row["ConsigneeAdd4"].ToString(),
            ConsigneeAdd5 = row["ConsigneeAdd5"].ToString(),
            CustomHouseAgent = row["CustomHouseAgent"].ToString(),
            AgentLICNo = row["AgentLICNo"].ToString(),
            PrecarriageBy = row["PrecarriageBy"].ToString(),
            VesselFlightNo = row["VesselFlightNo"].ToString(),
            Port_Of_Discharge = row["Port_Of_Discharge"].ToString(),
            AR4_No_Date = row["AR4_No_Date"].ToString(),
            Q_CertNo_Date = row["Q_CertNo_Date"].ToString(),
            ExportTradeControl = row["ExportTradeControl"].ToString(),
            Place_Receipt_ByCarrier = row["Place_Receipt_ByCarrier"].ToString(),
            RotationNo = row["RotationNo"].ToString(),
            Port_Of_Loading = row["Port_Of_Loading"].ToString(),
            Country_Destination = row["Country_Destination"].ToString(),
            ImpEx_CodeNo_BIN = row["ImpEx_CodeNo_BIN"].ToString(),
            RBI_CodeNo = row["RBI_CodeNo"].ToString(),
            RB_DefferedCredit = row["RB_DefferedCredit"].ToString(),
            RB_Joint_Ventures = row["RB_Joint_Ventures"].ToString(),
            RB_Rupees_Credit = row["RB_Rupees_Credit"].ToString(),
            RB_Exporter_Others = row["RB_Exporter_Others"].ToString(),
            RB_OutRightSales = row["RB_OutRightSales"].ToString(),
            RB_Consignment = row["RB_Consignment"].ToString(),
            RB_Ship_Others = row["RB_Ship_Others"].ToString(),
            RB_CIF = row["RB_CIF"].ToString(),
            RB_CFR = row["RB_CFR"].ToString(),
            RB_FOB = row["RB_FOB"].ToString(),
            RB_NatureOfOthers = row["RB_NatureOfOthers"].ToString(),
            ExchangeRate_US = row["ExchangeRate_US"].ToString(),
            Invoice_Currency = row["Invoice_Currency"].ToString(),
            Net_Weight = row["Net_Weight"].ToString(),
            GrossWeight = row["GrossWeight"].ToString(),
            FOB_In_Words = row["FOB_In_Words"].ToString(),
            CIF_FOB_Currency = row["CIF_FOB_Currency"].ToString(),
            CIF_FOB_Amount = row["CIF_FOB_Amount"].ToString(),
            Currency = row["Currency"].ToString(),
            Amount = row["Amount"].ToString(),
            FOBValue_Currency = row["FOBValue_Currency"].ToString(),
            FOBValue_Amount = row["FOBValue_Amount"].ToString(),
            Freight_Currency = row["Freight_Currency"].ToString(),
            Freight_Amount = row["Freight_Amount"].ToString(),
            Insurance_Currency = row["Insurance_Currency"].ToString(),
            Insurance_Amount = row["Insurance_Amount"].ToString(),
            Commission_Currency = row["Commission_Currency"].ToString(),
            Commission_Amount = row["Commission_Amount"].ToString(),
            Discount_Currency = row["Discount_Currency"].ToString(),
            Discount_Amount = row["Discount_Amount"].ToString(),
            Otherdeduction_Currency = row["Otherdeduction_Currency"].ToString(),
            Otherdeduction_Amount = row["Otherdeduction_Amount"].ToString(),
            GR_No = row["GR_No"].ToString(),
            Gi_BondNo = row["Gi_BondNo"].ToString(),
            Declaration_Clause = row["Declaration_Clause"].ToString(),
            public_Notice = row["public_Notice"].ToString(),
            public_Date = row["public_Date"].ToString(),
            Remarks = row["Remarks"].ToString(),
            DBK_Tarrif = row["DBK_Tarrif"].ToString(),
            DBK_AssblValue = row["DBK_AssblValue"].ToString(),
            DutyPercentage = row["DutyPercentage"].ToString(),
            DutyAmount = row["DutyAmount"].ToString(),
            DutyForgon = row["DutyForgon"].ToString()
           

        });
        i++;
        //}

        return list;
    }

    public List<Exp_ShipingBill_Dutyfree_Dbk> Load_ManualShipplingBill_Grid(DataTable dtt)
    {
        List<Exp_ShipingBill_Dutyfree_Dbk> listGrid = new List<Exp_ShipingBill_Dutyfree_Dbk>();

        int i = 0;

        while (dtt.Rows.Count > i)
        {
            DataRow row = dtt.Rows[i];

            listGrid.Add(new Exp_ShipingBill_Dutyfree_Dbk()
            {
                JOBNO = row["JOBNO"].ToString(),
                MARKS_NO = row["MARKS_NO"].ToString(),
                ITEM_DESCRIPTION = row["ITEM_DESCRIPTION"].ToString(),
                RITCNO = row["RITCNO"].ToString(),
                ITEM_QTY = row["ITEM_QTY"].ToString(),
                ITEM_QTY_CODE = row["ITEM_QTY_CODE"].ToString(),
                FOB_VALUE = row["FOB_VALUE"].ToString()         
           });

        i++;       
      }
        return listGrid;
    }


    public int Import_TB_ShippingBill_Insert_Update()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[100];

            //param[0] = new SqlParameter("@ID", ID);
            param[1] = new SqlParameter("@JOBNO", JOBNO);
            //param[2] = new SqlParameter("@Sb_TYPE", Sb_TYPE);
            param[3] = new SqlParameter("@INVOICE_NO", INVOICE_NO);
            param[4] = new SqlParameter("@ShippingBill_No_Date", ShippingBill_No_Date);
            param[5] = new SqlParameter("@Exporters_Reference", Exporters_Reference);
            param[6] = new SqlParameter("@ExporterName", ExporterName);
            param[7] = new SqlParameter("@ExporterAdd1", ExporterAdd1);
            param[8] = new SqlParameter("@ExporterAdd2", ExporterAdd2);
            param[9] = new SqlParameter("@ExporterAdd3", ExporterAdd3);
            param[10] = new SqlParameter("@ExporterAdd4", ExporterAdd4);
            param[11] = new SqlParameter("@ExporterAdd5", ExporterAdd5);
            param[12] = new SqlParameter("@ConsigneeName", ConsigneeName);
            param[13] = new SqlParameter("@ConsigneeAdd1", ConsigneeAdd1);
            param[14] = new SqlParameter("@ConsigneeAdd2", ConsigneeAdd2);
            param[15] = new SqlParameter("@ConsigneeAdd3", ConsigneeAdd3);
            param[16] = new SqlParameter("@ConsigneeAdd4", ConsigneeAdd4);
            param[17] = new SqlParameter("@ConsigneeAdd5", ConsigneeAdd5);
            param[18] = new SqlParameter("@CustomHouseAgent", CustomHouseAgent);
            param[19] = new SqlParameter("@AgentLICNo", AgentLICNo);
            param[20] = new SqlParameter("@PrecarriageBy", PrecarriageBy);
            param[21] = new SqlParameter("@VesselFlightNo", VesselFlightNo);
            param[22] = new SqlParameter("@Port_Of_Discharge", Port_Of_Discharge);
            param[23] = new SqlParameter("@AR4_No_Date", AR4_No_Date);
            param[24] = new SqlParameter("@Q_CertNo_Date", Q_CertNo_Date);
            param[84] = new SqlParameter("@TBNo",TBNo);
            param[85] = new SqlParameter("@TBDate", TBDate);
            param[86] = new SqlParameter("@IGMNo", IGMNo);
            param[87] = new SqlParameter("@IGMDate", IGMDate);
            param[25] = new SqlParameter("@ExportTradeControl", ExportTradeControl);
            param[26] = new SqlParameter("@Place_Receipt_ByCarrier", Place_Receipt_ByCarrier);
            param[27] = new SqlParameter("@RotationNo", RotationNo);
            param[28] = new SqlParameter("@Port_Of_Loading", Port_Of_Loading);
            param[29] = new SqlParameter("@Country_Destination", Country_Destination);
            param[30] = new SqlParameter("@ImpEx_CodeNo_BIN", ImpEx_CodeNo_BIN);
            param[31] = new SqlParameter("@OriginOfGoods", OriginOfGoods);
            param[32] = new SqlParameter("@RB_DefferedCredit", RB_DefferedCredit);
            //param[33] = new SqlParameter("@RB_Joint_Ventures", RB_Joint_Ventures);
            //param[34] = new SqlParameter("@RB_Rupees_Credit", RB_Rupees_Credit);
            param[35] = new SqlParameter("@RB_Exporter_Others", RB_Exporter_Others);
            param[36] = new SqlParameter("@RB_OutRightSales", RB_OutRightSales);
            //param[37] = new SqlParameter("@RB_Consignment", RB_Consignment);
            param[38] = new SqlParameter("@RB_Ship_Others", RB_Ship_Others);
            param[39] = new SqlParameter("@RB_CIF", RB_CIF);
            //param[40] = new SqlParameter("@RB_CFR", RB_Consignment);
            //param[41] = new SqlParameter("@RB_FOB", RB_Ship_Others);
            //param[40] = new SqlParameter("@RB_CFR", InvoiceAmount1);
            //param[41] = new SqlParameter("@RB_FOB", RBIApprovalNo);
            //param[40] = new SqlParameter("@RB_CFR", RB_CFR);
            //param[41] = new SqlParameter("@RB_FOB", RB_FOB);
            param[42] = new SqlParameter("@RB_NatureOfOthers", RB_NatureOfOthers);
            param[43] = new SqlParameter("@ExchangeRate_US", ExchangeRate_US);
            param[44] = new SqlParameter("@Invoice_Currency", Invoice_Currency);
            param[45] = new SqlParameter("@Net_Weight", Net_Weight);
            param[46] = new SqlParameter("@GrossWeight", GrossWeight);
            param[47] = new SqlParameter("@FOB_In_Words", FOB_In_Words);
            param[48] = new SqlParameter("@CIF_FOB_Currency", CIF_FOB_Currency);
            param[49] = new SqlParameter("@CIF_FOB_Amount", CIF_FOB_Amount);
            param[50] = new SqlParameter("@Currency", Currency);
            param[51] = new SqlParameter("@Amount", Amount);
            param[52] = new SqlParameter("@FOBValue_Currency", FOBValue_Currency);
            param[53] = new SqlParameter("@FOBValue_Amount", FOBValue_Amount);
            param[54] = new SqlParameter("@Freight_Currency", Freight_Currency);
            param[55] = new SqlParameter("@Freight_Amount", Freight_Amount);
            param[56] = new SqlParameter("@Insurance_Currency", Insurance_Currency);
            param[57] = new SqlParameter("@Insurance_Amount", Insurance_Amount);
            param[58] = new SqlParameter("@Commission_Currency", Commission_Currency);
            param[59] = new SqlParameter("@Commission_Amount", Commission_Amount);
            param[60] = new SqlParameter("@Discount_Currency", Discount_Currency);
            param[61] = new SqlParameter("@Discount_Amount", Discount_Amount);
            param[62] = new SqlParameter("@Otherdeduction_Currency", Otherdeduction_Currency);
            param[63] = new SqlParameter("@Otherdeduction_Amount", Otherdeduction_Amount);
            param[64] = new SqlParameter("@BillOfEntryNo", BillOfEntryNo);
            param[65] = new SqlParameter("@BillOfEntryDate", BillOfEntryDate);
            param[66] = new SqlParameter("@BondNo", BondNo);
            param[67] = new SqlParameter("@Bond_Date", Bond_Date);
            param[68] = new SqlParameter("@GR_No", GR_No);
            param[69] = new SqlParameter("@NoOfPkgs", NoOfPkgs);
            param[70] = new SqlParameter("@VesselName", VesselName);
            param[71] = new SqlParameter("@RotationNoLCD", RotationNoLCD);
            param[72] = new SqlParameter("@WarehouseName", WarehouseName);
            //param[73] = new SqlParameter("@DutyAmount", DutyAmount);
            //param[74] = new SqlParameter("@DutyForgon", DutyForgon);
            param[75] = new SqlParameter("@BranchCode", BRANCH_CODE);
            param[76] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
            param[77] = new SqlParameter("@WORKINGPERIOD", WORKING_PERIOD);
            param[78] = new SqlParameter("@YEAR", YEAR);
            param[79] = new SqlParameter("@USER_ID", USER_ID);
            param[80] = new SqlParameter("@LOGINDATE", LOGINDATE);
            param[81] = new SqlParameter("@Mflag", flag);
            param[82] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[82].Direction = ParameterDirection.Output;
            param[83] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[83].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "Sp_Import_TB_ShippingBill_Insert_Update", param);

            result = Convert.ToInt32(param[82].Value.ToString());
        }
        catch (Exception ex)
        {

            er.makeLog(ex.Message);
        }

        return result;
    }

    public int Import_TB_ShippingBill_Grid_Insert_Update()
    {
        SqlParameter[] param = new SqlParameter[25];

        param[18] = new SqlParameter("@ID", ID);
        param[1] = new SqlParameter("@JOBNO", JOBNO);
        param[3] = new SqlParameter("@MARKS_NO", MARKS_NO);
        param[4] = new SqlParameter("@ITEM_DESCRIPTION", ITEM_DESCRIPTION);
        //param[5] = new SqlParameter("@RITCNO", RITCNO);
        param[6] = new SqlParameter("@ITEM_QTY", ITEM_QTY);
        param[7] = new SqlParameter("@ITEM_QTY_CODE", ITEM_QTY_CODE);
        param[8] = new SqlParameter("@FOB_VALUE", FOB_VALUE);
        param[9] = new SqlParameter("@BRANCHCODE", BRANCH_CODE);
        param[10] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
        param[11] = new SqlParameter("@YEAR", YEAR);
        param[12] = new SqlParameter("@USERID", USER_ID);
        param[13] = new SqlParameter("@LOGINDATE", LOGINDATE);
        param[14] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
        param[15] = new SqlParameter("@Mflag", flag);
        param[16] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
        param[16].Direction = ParameterDirection.Output;
        param[17] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
        param[17].Direction = ParameterDirection.Output;

        SqlHelper.ExecuteNonQuery(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "Sp_Import_TB_SBill_Grid_INSERT_UPDATE", param);
        result = Convert.ToInt32(param[16].Value.ToString());

        return result;
    }

    public DataSet Retreive_TB_ShippingBill()
    {
        SqlParameter[] param = new SqlParameter[15];

        param[0] = new SqlParameter("@JOBNO", JOBNO);
        param[1] = new SqlParameter("@Working_Period", WORKING_PERIOD);
        param[2] = new SqlParameter("@Branch", BRANCH_CODE);
        param[3] = new SqlParameter("@name", flag);
        param[4] = new SqlParameter("@BRANCHCOMMON", BRANCH_COMMON);
        param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
        param[5].Direction = ParameterDirection.Output;
        param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
        param[6].Direction = ParameterDirection.Output;

        ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "Sp_Import_TB_ShippingBill_BIND_ALL", param);

        result = Convert.ToInt32(param[5].Value.ToString());

        return ds;
    }

    public List<Exp_ShipingBill_Dutyfree_Dbk> Load_Import_TB_ShipplingBill(DataTable dt)
    {
        List<Exp_ShipingBill_Dutyfree_Dbk> list = new List<Exp_ShipingBill_Dutyfree_Dbk>();

        int i = 0;

        //while (dt.Rows.Count > i)
        //{
        DataRow row = dt.Rows[i];

        list.Add(new Exp_ShipingBill_Dutyfree_Dbk()
        {
            JOBNO = row["JOBNO"].ToString(),
            //Sb_TYPE = row["Sb_TYPE"].ToString(),
            INVOICE_NO = row["INVOICE_NO"].ToString(),
            ShippingBill_No_Date = row["ShippingBill_No_Date"].ToString(),
            Exporters_Reference = row["Exporters_Reference"].ToString(),
            ExporterName = row["ExporterName"].ToString(),
            ExporterAdd1 = row["ExporterAdd1"].ToString(),
            ExporterAdd2 = row["ExporterAdd2"].ToString(),
            ExporterAdd3 = row["ExporterAdd3"].ToString(),
            ExporterAdd4 = row["ExporterAdd4"].ToString(),
            ExporterAdd5 = row["ExporterAdd5"].ToString(),
            ConsigneeName = row["ConsigneeName"].ToString(),
            ConsigneeAdd1 = row["ConsigneeAdd1"].ToString(),
            ConsigneeAdd2 = row["ConsigneeAdd2"].ToString(),
            ConsigneeAdd3 = row["ConsigneeAdd3"].ToString(),
            ConsigneeAdd4 = row["ConsigneeAdd4"].ToString(),
            ConsigneeAdd5 = row["ConsigneeAdd5"].ToString(),
            CustomHouseAgent = row["CustomHouseAgent"].ToString(),
            AgentLICNo = row["AgentLICNo"].ToString(),
            PrecarriageBy = row["PrecarriageBy"].ToString(),
            VesselFlightNo = row["VesselFlightNo"].ToString(),
            Port_Of_Discharge = row["Port_Of_Discharge"].ToString(),
            AR4_No_Date = row["AR4_No_Date"].ToString(),
            Q_CertNo_Date = row["Q_CertNo_Date"].ToString(),
            ExportTradeControl = row["ExportTradeControl"].ToString(),
            Place_Receipt_ByCarrier = row["Place_Receipt_ByCarrier"].ToString(),
            RotationNo = row["RotationNo"].ToString(),
            Port_Of_Loading = row["Port_Of_Loading"].ToString(),
            Country_Destination = row["Country_Destination"].ToString(),
            ImpEx_CodeNo_BIN = row["ImpEx_CodeNo_BIN"].ToString(),
            RBI_CodeNo = row["OriginOfGoods"].ToString(),
            RB_DefferedCredit = row["RB_DefferedCredit"].ToString(),
            //RB_Joint_Ventures = row["RB_Joint_Ventures"].ToString(),
            //RB_Rupees_Credit = row["RB_Rupees_Credit"].ToString(),
            RB_Exporter_Others = row["RB_Exporter_Others"].ToString(),
            RB_OutRightSales = row["RB_OutRightSales"].ToString(),
            //RB_Consignment = row["RB_Consignment"].ToString(),
            RB_Ship_Others = row["RB_Ship_Others"].ToString(),
            RB_CIF = row["RB_CIF"].ToString(),
            //RB_CFR = row["RB_CFR"].ToString(),
            //RB_FOB = row["RB_FOB"].ToString(),
            RB_NatureOfOthers = row["RB_NatureOfOthers"].ToString(),
            ExchangeRate_US = row["ExchangeRate_US"].ToString(),
            Invoice_Currency = row["Invoice_Currency"].ToString(),
            Net_Weight = row["Net_Weight"].ToString(),
            GrossWeight = row["GrossWeight"].ToString(),
            FOB_In_Words = row["FOB_In_Words"].ToString(),
            CIF_FOB_Currency = row["CIF_FOB_Currency"].ToString(),
            CIF_FOB_Amount = row["CIF_FOB_Amount"].ToString(),
            Currency = row["Currency"].ToString(),
            Amount = row["Amount"].ToString(),
            FOBValue_Currency = row["FOBValue_Currency"].ToString(),
            FOBValue_Amount = row["FOBValue_Amount"].ToString(),
            Freight_Currency = row["Freight_Currency"].ToString(),
            Freight_Amount = row["Freight_Amount"].ToString(),
            Insurance_Currency = row["Insurance_Currency"].ToString(),
            Insurance_Amount = row["Insurance_Amount"].ToString(),
            Commission_Currency = row["Commission_Currency"].ToString(),
            Commission_Amount = row["Commission_Amount"].ToString(),
            Discount_Currency = row["Discount_Currency"].ToString(),
            Discount_Amount = row["Discount_Amount"].ToString(),
            Otherdeduction_Currency = row["Otherdeduction_Currency"].ToString(),
            Otherdeduction_Amount = row["Otherdeduction_Amount"].ToString(),

            BillOfEntryNo = row["BillOfEntryNo"].ToString(),
            BillOfEntryDate = row["BillOfEntryDate"].ToString(),
            BondNo = row["BondNo"].ToString(),          
            Bond_Date = row["Bond_Date"].ToString(),
            GR_No = row["GR_No"].ToString(),
            NoOfPkgs = row["NoOfPkgs"].ToString(),
            VesselName = row["VesselName"].ToString(),
            RotationNoLCD = row["RotationNoLCD"].ToString(),
            WarehouseName = row["WarehouseName"].ToString()
     


        });
        i++;
        //}

        return list;
    }

    public List<Exp_ShipingBill_Dutyfree_Dbk> Load_TB_ShipplingBill_Grid(DataTable dtt)
    {
        List<Exp_ShipingBill_Dutyfree_Dbk> listGrid = new List<Exp_ShipingBill_Dutyfree_Dbk>();

        int i = 0;

        while (dtt.Rows.Count > i)
        {
            DataRow row = dtt.Rows[i];

            listGrid.Add(new Exp_ShipingBill_Dutyfree_Dbk()
            {
                JOBNO = row["JOBNO"].ToString(),
                MARKS_NO = row["MARKS_NO"].ToString(),
                ITEM_DESCRIPTION = row["ITEM_DESCRIPTION"].ToString(),
                RITCNO = row["RITCNO"].ToString(),
                ITEM_QTY = row["ITEM_QTY"].ToString(),
                ITEM_QTY_CODE = row["ITEM_QTY_CODE"].ToString(),
                FOB_VALUE = row["FOB_VALUE"].ToString()
            });

            i++;
        }
        return listGrid;
    }


}