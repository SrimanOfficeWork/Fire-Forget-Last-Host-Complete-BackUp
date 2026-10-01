using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.IO;

using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

public class Export_BL_Multiple
{

    public int result = 0, UPDATE_ID = 0;
    DataSet ds = new DataSet();
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);


    private string _Jobno;
    private string _Exp_name;
    private string _Branch;
    private string _Flag;


    private string _Shipper_name;
    private string _Ref_name;
    private string _Job;
    private string _from_date;
    private string _todate;
    private string _Item_Id;

    private string _R_Id;

    private string _Mode;
    private string _BL_Id;

    private string _Mark_No;
    private string _Desc;

    private string _FILE_REF_NO;

    private string _TOT_VOL_UNIT;
    private string _VOYAGE;
    private string _TOT_PKGS_UNIT;
    private string _COMMODITY;
    private string _CURRENCY;
    private string _EX_RATE;
    private string _NO_OF_CONTAINERS;
    private string _PERCENTAGE;
    private string _TOTAL_BILLAMT;
    private string _SHIPMENT_TYPE;
    private string _DBN_NO;
    private string _DBN_DATE;
    private string _DB_YES_NO;
    private string _REPORT_TYPE;
    private string _Type;
    public string _TAX_LEDGER_1, _LEDGER_1_TAX, _LEDGER_1_TAX_AMT, _TAX_LEDGER_2, _LEDGER_2_TAX, _LEDGER_2_TAX_AMT, _TAX_LEDGER_3, _LEDGER_3_TAX, _LEDGER_3_TAX_AMT, _GRAND_TOTAL;

    public string Jobno { get { return _Jobno; } set { _Jobno = value; } }
    public string Exp_name { get { return _Exp_name; } set { _Exp_name = value; } }
    public string Branch { get { return _Branch; } set { _Branch = value; } }
    public string Flag { get { return _Flag; } set { _Flag = value; } }

  
    public string Shipper_name { get { return _Shipper_name; } set { _Shipper_name = value; } }
    public string Ref_name { get { return _Ref_name; } set { _Ref_name = value; } }
    public string Job { get { return _Job; } set { _Job = value; } }
    public string from_date { get { return _from_date; } set { _from_date = value; } }
    public string todate { get { return _todate; } set { _todate = value; } }
    public string Item_Id { get { return _Item_Id; } set { _Item_Id = value; } }

    public string R_Id { get { return _R_Id; } set { _R_Id = value; } }

    public string Mode { get { return _Mode; } set { _Mode = value; } }

    public string BL_Id { get { return _BL_Id; } set { _BL_Id = value; } }

    public string Mark_No { get { return _Mark_No; } set { _Mark_No = value; } }
    public string Desc { get { return _Desc; } set { _Desc = value; } }

    public string FILE_REF_NO { get { return _FILE_REF_NO; } set { _FILE_REF_NO = value; } }

    public string TOT_VOL_UNIT { get { return _TOT_VOL_UNIT; } set { _TOT_VOL_UNIT = value; } }
    public string VOYAGE { get { return _VOYAGE; } set { _VOYAGE = value; } }
    public string TOT_PKGS_UNIT { get { return _TOT_PKGS_UNIT; } set { _TOT_PKGS_UNIT = value; } }
    public string COMMODITY { get { return _COMMODITY; } set { _COMMODITY = value; } }
    public string CURRENCY { get { return _CURRENCY; } set { _CURRENCY = value; } }
    public string EX_RATE { get { return _EX_RATE; } set { _EX_RATE = value; } }
    public string NO_OF_CONTAINERS { get { return _NO_OF_CONTAINERS; } set { _NO_OF_CONTAINERS = value; } }
    public string PERCENTAGE { get { return _PERCENTAGE; } set { _PERCENTAGE = value; } }
    public string TOTAL_BILLAMT { get { return _TOTAL_BILLAMT; } set { _TOTAL_BILLAMT = value; } }
    public string SHIPMENT_TYPE { get { return _SHIPMENT_TYPE; } set { _SHIPMENT_TYPE = value; } }
    public string DBN_NO { get { return _DBN_NO; } set { _DBN_NO = value; } }
    public string DBN_DATE { get { return _DBN_DATE; } set { _DBN_DATE = value; } }
    public string DB_YES_NO { get { return _DB_YES_NO; } set { _DB_YES_NO = value; } }
    public string REPORT_TYPE { get { return _REPORT_TYPE; } set { _REPORT_TYPE = value; } }

    public string Type { get { return _Type; } set { _Type = value; } }

    public string TAX_LEDGER_1 { get { return _TAX_LEDGER_1; } set { _TAX_LEDGER_1 = value; } }
    public string LEDGER_1_TAX { get { return _LEDGER_1_TAX; } set { _LEDGER_1_TAX = value; } }
    public string LEDGER_1_TAX_AMT { get { return _LEDGER_1_TAX_AMT; } set { _LEDGER_1_TAX_AMT = value; } }
    public string TAX_LEDGER_2 { get { return _TAX_LEDGER_2; } set { _TAX_LEDGER_2 = value; } }
    public string LEDGER_2_TAX { get { return _LEDGER_2_TAX; } set { _LEDGER_2_TAX = value; } }
    public string LEDGER_2_TAX_AMT { get { return _LEDGER_2_TAX_AMT; } set { _LEDGER_2_TAX_AMT = value; } }
    public string TAX_LEDGER_3 { get { return _TAX_LEDGER_3; } set { _TAX_LEDGER_3 = value; } }
    public string LEDGER_3_TAX { get { return _LEDGER_3_TAX; } set { _LEDGER_3_TAX = value; } }
    public string LEDGER_3_TAX_AMT { get { return _LEDGER_3_TAX_AMT; } set { _LEDGER_3_TAX_AMT = value; } }
    public string GRAND_TOTAL { get { return _GRAND_TOTAL; } set { _GRAND_TOTAL = value; } }
    
    //----------------------Insert & Update-----------Start---------------------
    #region BL_Generation

    private string _R_ID;
    private string _M_EXP_NAME;
    private string _REF_NAME;

    private string _JOBNO;
    private string _EXPORTER_NAME;
    private string _ADDRESS1;
    private string _ADDRESS2;
    private string _ADDRESS3;
    private string _ADDRESS4;
    private string _ADDRESS5;

    private string _CONSIGNEE_NAME;
    private string _CONSIGNEE_ADD1;
    private string _CONSIGNEE_ADD2;
    private string _CONSIGNEE_ADD3;
    private string _CONSIGNEE_ADD4;

    private string _BUYER_NAME;
    private string _BUYER_ADDRESS;
    private string _BUYER_ADDRESS1;
    private string _BUYER_ADDRESS2;
    private string _BUYER_ADDRESS3;
    private string _BUYER_ADDRESS4;

    private string _BL_NUMBER;
    private string _SHIP_REF_NO;
    private string _PLACE_OF_RECEIPT;
    private string _OCEAN_VESSEL;
    private string _PORT_OF_LOADING;
    private string _FREIGHT_PAYABLE;
    private string _PLACE_DATE;
    private string _DATE_OF_RECEIPT;
    private string _PLACE_OF_DELIVERY;
    private string _PORT_DISCHARGE;
    private string _NO_OF_ORGINAL_BL;
    private string _AGENTS_NAEE_REFNO;
    private string _FREIGHT_AMT;

    private string _USERID;
    private string _LOGIN_DATE;
    private string _STATUS;
    private string _BRANCHCODE;
    private string _WORKINGPERIOD;

    public string _NOTIFY_1_1;
    public string _NOTIFY_1_2;
    public string _NOTIFY_1_3;
    public string _NOTIFY_1_4;
    public string _NOTIFY_1_5;
    public string _INVOICE_NO;
    public string _SB_NO;
    public string _HSN_CODE;
  

    public string _FREIGHT_PRE_COL;
    public string _IEC_NO;
    public string _HSS_CODE_NO;
    public string _LC_NO;
    public string _TOTALVOLUME;
    public string _ORDER_NO;

    private string _xmlData;
    private string _XML_Con_data;


    private string _UPD_ID;

    private string _CONTAINER_Y_N, _PENDING_Y_N, _JOB_DATE;

    public string R_ID { get { return _R_ID; } set { _R_ID = value; } }
    public string REF_NAME { get { return _REF_NAME; } set { _REF_NAME = value; } }
    public string M_EXP_NAME { get { return _M_EXP_NAME; } set { _M_EXP_NAME = value; } }
    public string HSN_CODE { get { return _HSN_CODE; } set { _HSN_CODE = value; } }

    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string EXPORTER_NAME { get { return _EXPORTER_NAME; } set { _EXPORTER_NAME = value; } }
    public string ADDRESS1 { get { return _ADDRESS1; } set { _ADDRESS1 = value; } }
    public string ADDRESS2 { get { return _ADDRESS2; } set { _ADDRESS2 = value; } }
    public string ADDRESS3 { get { return _ADDRESS3; } set { _ADDRESS3 = value; } }
    public string ADDRESS4 { get { return _ADDRESS4; } set { _ADDRESS4 = value; } }
    public string ADDRESS5 { get { return _ADDRESS5; } set { _ADDRESS5 = value; } }

    public string CONSIGNEE_NAME { get { return _CONSIGNEE_NAME; } set { _CONSIGNEE_NAME = value; } }
    public string CONSIGNEE_ADD1 { get { return _CONSIGNEE_ADD1; } set { _CONSIGNEE_ADD1 = value; } }
    public string CONSIGNEE_ADD2 { get { return _CONSIGNEE_ADD2; } set { _CONSIGNEE_ADD2 = value; } }
    public string CONSIGNEE_ADD3 { get { return _CONSIGNEE_ADD3; } set { _CONSIGNEE_ADD3 = value; } }
    public string CONSIGNEE_ADD4 { get { return _CONSIGNEE_ADD4; } set { _CONSIGNEE_ADD4 = value; } }

    public string BUYER_NAME { get { return _BUYER_NAME; } set { _BUYER_NAME = value; } }
    public string BUYER_ADDRESS { get { return _BUYER_ADDRESS; } set { _BUYER_ADDRESS = value; } }
    public string BUYER_ADDRESS1 { get { return _BUYER_ADDRESS1; } set { _BUYER_ADDRESS1 = value; } }
    public string BUYER_ADDRESS2 { get { return _BUYER_ADDRESS2; } set { _BUYER_ADDRESS2 = value; } }
    public string BUYER_ADDRESS3 { get { return _BUYER_ADDRESS3; } set { _BUYER_ADDRESS3 = value; } }
    public string BUYER_ADDRESS4 { get { return _BUYER_ADDRESS4; } set { _BUYER_ADDRESS4 = value; } }

    public string BL_NUMBER { get { return _BL_NUMBER; } set { _BL_NUMBER = value; } }
    public string SHIP_REF_NO { get { return _SHIP_REF_NO; } set { _SHIP_REF_NO = value; } }
    public string PLACE_OF_RECEIPT { get { return _PLACE_OF_RECEIPT; } set { _PLACE_OF_RECEIPT = value; } }
    public string OCEAN_VESSEL { get { return _OCEAN_VESSEL; } set { _OCEAN_VESSEL = value; } }
    public string PORT_OF_LOADING { get { return _PORT_OF_LOADING; } set { _PORT_OF_LOADING = value; } }
    public string FREIGHT_PAYABLE { get { return _FREIGHT_PAYABLE; } set { _FREIGHT_PAYABLE = value; } }
    public string PLACE_DATE { get { return _PLACE_DATE; } set { _PLACE_DATE = value; } }
    public string DATE_OF_RECEIPT { get { return _DATE_OF_RECEIPT; } set { _DATE_OF_RECEIPT = value; } }
    public string PLACE_OF_DELIVERY { get { return _PLACE_OF_DELIVERY; } set { _PLACE_OF_DELIVERY = value; } }
    public string PORT_DISCHARGE { get { return _PORT_DISCHARGE; } set { _PORT_DISCHARGE = value; } }
    public string NO_OF_ORGINAL_BL { get { return _NO_OF_ORGINAL_BL; } set { _NO_OF_ORGINAL_BL = value; } }
    public string AGENTS_NAEE_REFNO { get { return _AGENTS_NAEE_REFNO; } set { _AGENTS_NAEE_REFNO = value; } }
    public string FREIGHT_AMT { get { return _FREIGHT_AMT; } set { _FREIGHT_AMT = value; } }

    public string USERID { get { return _USERID; } set { _USERID = value; } }
    public string LOGIN_DATE { get { return _LOGIN_DATE; } set { _LOGIN_DATE = value; } }
    public string STATUS { get { return _STATUS; } set { _STATUS = value; } }
    public string BRANCHCODE { get { return _BRANCHCODE; } set { _BRANCHCODE = value; } }
    public string WORKINGPERIOD { get { return _WORKINGPERIOD; } set { _WORKINGPERIOD = value; } }

    public string NOTIFY_1_1 { get { return _NOTIFY_1_1; } set { _NOTIFY_1_1 = value; } }
    public string NOTIFY_1_2 { get { return _NOTIFY_1_2; } set { _NOTIFY_1_2 = value; } }
    public string NOTIFY_1_3 { get { return _NOTIFY_1_3; } set { _NOTIFY_1_3 = value; } }
    public string NOTIFY_1_4 { get { return _NOTIFY_1_4; } set { _NOTIFY_1_4 = value; } }
    public string NOTIFY_1_5 { get { return _NOTIFY_1_5; } set { _NOTIFY_1_5 = value; } }

    public string INVOICE_NO { get { return _INVOICE_NO; } set { _INVOICE_NO = value; } }
    public string SB_NO { get { return _SB_NO; } set { _SB_NO = value; } }
    public string FREIGHT_PRE_COL { get { return _FREIGHT_PRE_COL; } set { _FREIGHT_PRE_COL = value; } }


    public string IEC_NO { get { return _IEC_NO; } set { _IEC_NO = value; } }
    public string HSS_CODE_NO { get { return _HSS_CODE_NO; } set { _HSS_CODE_NO = value; } }
    public string LC_NO { get { return _LC_NO; } set { _LC_NO = value; } }
    public string TOTALVOLUME { get { return _TOTALVOLUME; } set { _TOTALVOLUME = value; } }
    public string ORDER_NO { get { return _ORDER_NO; } set { _ORDER_NO = value; } }
    public string CONTAINER_Y_N { get { return _CONTAINER_Y_N; } set { _CONTAINER_Y_N = value; } }
    public string PENDING_Y_N { get { return _PENDING_Y_N; } set { _PENDING_Y_N = value; } }
    public string JOB_DATE { get { return _JOB_DATE; } set { _JOB_DATE = value; } }



    #endregion BL_Generation

    #region BL-gen_Container

    private string _CONTAINER_NO, _SEAL_NO, _SEAL_DATE, _FCL_LCL, _TYPE, _TOTAL_PKGS, _GROSS_WEIGHT;

    public string CONTAINER_NO { get { return _CONTAINER_NO; } set { _CONTAINER_NO = value; } }
    public string SEAL_NO { get { return _SEAL_NO; } set { _SEAL_NO = value; } }
    public string SEAL_DATE { get { return _SEAL_DATE; } set { _SEAL_DATE = value; } }
    public string FCL_LCL { get { return _FCL_LCL; } set { _FCL_LCL = value; } }
    public string TYPE { get { return _TYPE; } set { _TYPE = value; } }
    public string TOTAL_PKGS { get { return _TOTAL_PKGS; } set { _TOTAL_PKGS = value; } }
    public string GROSS_WEIGHT { get { return _GROSS_WEIGHT; } set { _GROSS_WEIGHT = value; } }

    #endregion BL-gen_Container
    //----------------------Insert & Update-----------End---------------------


    public string xmlData { get { return _xmlData; } set { _xmlData = value; } }
    public string XML_Con_data { get { return _XML_Con_data; } set { _XML_Con_data = value; } }

    
    public string UPD_ID { get { return _UPD_ID; } set { _UPD_ID = value; } }

    public String Xml_D;


    public DataSet Exp_Name()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@Item_Id", Item_Id);
            param[1] = new SqlParameter("@Exp_name", Exp_name);
            param[2] = new SqlParameter("@Branch", Branch);
            param[3] = new SqlParameter("@Flag", Flag);
            param[4] = new SqlParameter("@Mode", Mode);
            param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;

            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXP_BL_MULTIPLE_SELECT", param);
            result = Convert.ToInt32(param[5].Value.ToString());

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet New_item_load()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@R_Id", R_Id);
            param[1] = new SqlParameter("@Jobno", Jobno);
            param[2] = new SqlParameter("@Exp_name", Exp_name);
            param[3] = new SqlParameter("@Branch", Branch);
            param[4] = new SqlParameter("@Flag", Flag);
            param[5] = new SqlParameter("@Mode", Mode);

            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;

            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXPORT_MULTIPLE_SAVE_SELECT", param);
            result = Convert.ToInt32(param[6].Value.ToString());

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public void Multiple_BL_xml_INS_UPD()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[100];

           // param[0] = new SqlParameter("@U_Id", U_Id);
            param[0] = new SqlParameter("@R_ID", R_ID);
            param[1] = new SqlParameter("@M_EXP_NAME", M_EXP_NAME);
            param[2] = new SqlParameter("@REF_NAME", REF_NAME);
            param[3] = new SqlParameter("@JOBNO", JOBNO);
            param[4] = new SqlParameter("@EXPORTER_NAME", EXPORTER_NAME);
            param[5] = new SqlParameter("@ADDRESS1", ADDRESS1);
            param[6] = new SqlParameter("@ADDRESS2", ADDRESS2);
            param[7] = new SqlParameter("@ADDRESS3", ADDRESS3);
            param[8] = new SqlParameter("@ADDRESS4", ADDRESS4);
            param[9] = new SqlParameter("@ADDRESS5", ADDRESS5);

            param[10] = new SqlParameter("@CONSIGNEE_NAME", CONSIGNEE_NAME);
            param[11] = new SqlParameter("@CONSIGNEE_ADD1", CONSIGNEE_ADD1);
            param[12] = new SqlParameter("@CONSIGNEE_ADD2", CONSIGNEE_ADD2);
            param[13] = new SqlParameter("@CONSIGNEE_ADD3", CONSIGNEE_ADD3);
            param[14] = new SqlParameter("@CONSIGNEE_ADD4", CONSIGNEE_ADD4);

            param[15] = new SqlParameter("@BUYER_NAME", BUYER_NAME);
            param[16] = new SqlParameter("@BUYER_ADDRESS", BUYER_ADDRESS);
            param[17] = new SqlParameter("@BUYER_ADDRESS1", BUYER_ADDRESS1);
            param[18] = new SqlParameter("@BUYER_ADDRESS2", BUYER_ADDRESS2);
            param[19] = new SqlParameter("@BUYER_ADDRESS3", BUYER_ADDRESS3);
            param[20] = new SqlParameter("@BUYER_ADDRESS4", BUYER_ADDRESS4);

            param[21] = new SqlParameter("@NOTIFY_1_1", NOTIFY_1_1);
            param[22] = new SqlParameter("@NOTIFY_1_2", NOTIFY_1_2);
            param[23] = new SqlParameter("@NOTIFY_1_3", NOTIFY_1_3);
            param[24] = new SqlParameter("@NOTIFY_1_4", NOTIFY_1_4);
            param[25] = new SqlParameter("@NOTIFY_1_5", NOTIFY_1_5);

            param[26] = new SqlParameter("@BL_NUMBER", BL_NUMBER);
            param[27] = new SqlParameter("@SHIP_REF_NO", SHIP_REF_NO);

            if (JOB_DATE == "" || JOB_DATE==null)
            {
                JOB_DATE = "01/01/1900";
            }

            param[28] = new SqlParameter("@JOB_DATE", DateTime.Parse(JOB_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[29] = new SqlParameter("@PLACE_OF_RECEIPT", PLACE_OF_RECEIPT);
            param[30] = new SqlParameter("@DATE_OF_RECEIPT", DATE_OF_RECEIPT);
            param[31] = new SqlParameter("@OCEAN_VESSEL", OCEAN_VESSEL);
            param[32] = new SqlParameter("@PLACE_OF_DELIVERY", PLACE_OF_DELIVERY);
            param[33] = new SqlParameter("@PORT_OF_LOADING", PORT_OF_LOADING);
            param[34] = new SqlParameter("@PORT_DISCHARGE", PORT_DISCHARGE);
            param[35] = new SqlParameter("@FREIGHT_AMT", FREIGHT_AMT);
            param[36] = new SqlParameter("@FREIGHT_PAYABLE", FREIGHT_PAYABLE);
            param[37] = new SqlParameter("@NO_OF_ORGINAL_BL", NO_OF_ORGINAL_BL);

            param[38] = new SqlParameter("@AGENTS_NAEE_REFNO", AGENTS_NAEE_REFNO);
            param[39] = new SqlParameter("@PLACE_DATE", PLACE_DATE);
            param[40] = new SqlParameter("@INVOICE_NO", INVOICE_NO);
            param[41] = new SqlParameter("@HSS_CODE_NO", HSS_CODE_NO);
            param[42] = new SqlParameter("@SB_NO", SB_NO);
            param[43] = new SqlParameter("@IEC_NO", IEC_NO);
            param[44] = new SqlParameter("@LC_NO", LC_NO);
            param[45] = new SqlParameter("@ORDER_NO", ORDER_NO);

            param[46] = new SqlParameter("@TOTALVOLUME", TOTALVOLUME);
            param[47] = new SqlParameter("@CONTAINER_Y_N", CONTAINER_Y_N);
            param[48] = new SqlParameter("@PENDING_Y_N", PENDING_Y_N);
            param[49] = new SqlParameter("@FREIGHT_PRE_COL", FREIGHT_PRE_COL);

            param[50] = new SqlParameter("@USERID", USERID);
            param[51] = new SqlParameter("@flag", Flag);
            param[52] = new SqlParameter("@BRANCHCODE", BRANCHCODE);
            param[53] = new SqlParameter("@WORKINGPERIOD", WORKINGPERIOD);

            param[54] = new SqlParameter("@Branch", Branch);

            param[55] = new SqlParameter("@xmlString", Xml_D);
            param[56] = new SqlParameter("@XML_Con_data", XML_Con_data);

            param[57] = new SqlParameter("@UPD_ID", UPD_ID);
            param[58] = new SqlParameter("@Mode", Mode);

            param[59] = new SqlParameter("@Mark_No", Mark_No);
            param[60] = new SqlParameter("@Desc", Desc);
            param[61] = new SqlParameter("@FILE_REF_NO", FILE_REF_NO);

            param[62] = new SqlParameter("@TOT_VOL_UNIT", TOT_VOL_UNIT);
            param[63] = new SqlParameter("@VOYAGE", VOYAGE);
            param[64] = new SqlParameter("@TOT_PKGS_UNIT", TOT_PKGS_UNIT);
            param[65] = new SqlParameter("@COMMODITY", COMMODITY);
            param[66] = new SqlParameter("@CURRENCY", CURRENCY);
            param[67] = new SqlParameter("@EX_RATE", EX_RATE);
            param[68] = new SqlParameter("@NO_OF_CONTAINERS", NO_OF_CONTAINERS);
            param[69] = new SqlParameter("@PERCENTAGE", PERCENTAGE);
            param[70] = new SqlParameter("@TOTAL_BILLAMT", TOTAL_BILLAMT);
            param[71] = new SqlParameter("@SHIPMENT_TYPE", SHIPMENT_TYPE);
            param[72] = new SqlParameter("@DBN_NO", DBN_NO);

            string[] arr = new string[] { };
           
            if (DBN_DATE != string.Empty && DBN_DATE != null)
            {
                arr = DBN_DATE.Split('/');
                DBN_DATE = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
          

            param[73] = new SqlParameter("@DBN_DATE", DBN_DATE);
            param[74] = new SqlParameter("@DB_YES_NO", DB_YES_NO);
            param[75] = new SqlParameter("@REPORT_TYPE", REPORT_TYPE);

            param[79] = new SqlParameter("@TAX_LEDGER_1", TAX_LEDGER_1);
            param[80] = new SqlParameter("@LEDGER_1_TAX", LEDGER_1_TAX);
            param[81] = new SqlParameter("@LEDGER_1_TAX_AMT", LEDGER_1_TAX_AMT);
            param[82] = new SqlParameter("@TAX_LEDGER_2", TAX_LEDGER_2);
            param[83] = new SqlParameter("@LEDGER_2_TAX", LEDGER_2_TAX);
            param[84] = new SqlParameter("@LEDGER_2_TAX_AMT", LEDGER_2_TAX_AMT);
            param[85] = new SqlParameter("@TAX_LEDGER_3", TAX_LEDGER_3);
            param[86] = new SqlParameter("@LEDGER_3_TAX", LEDGER_3_TAX);
            param[87] = new SqlParameter("@LEDGER_3_TAX_AMT", LEDGER_3_TAX_AMT);
            param[88] = new SqlParameter("@GRAND_TOTAL", GRAND_TOTAL);
            param[89] = new SqlParameter("@HSN_CODE", HSN_CODE);


            param[76] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[76].Direction = ParameterDirection.Output;

            param[77] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[77].Direction = ParameterDirection.Output;


            param[78] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[78].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXP_MULTIPLE_BL_GENERATION_INS_UPD", param);
            result = Convert.ToInt32(param[76].Value.ToString());

            if (Flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[78].Value.ToString());
            }

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }




    public DataSet Multiple_BL_Search()
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };
            if (from_date != string.Empty && from_date != null)
            {
                arr = from_date.Split('/');
                from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (todate != string.Empty && todate != null)
            {
                arr2 = todate.Split('/');
                todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@jobno", Job);
            param[1] = new SqlParameter("@Shipper_name", Shipper_name);
            param[2] = new SqlParameter("@Ref_name", Ref_name);
            param[3] = new SqlParameter("@from_date", from_date);
            param[4] = new SqlParameter("@to_date", todate);
            param[5] = new SqlParameter("@Branch",Branch);
            param[6] = new SqlParameter("@Type", Type);

            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXPORT_MULTIPLE_BL_SEARCH", param);
        
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet EXPORT_MULTIPLE_BL_PENDING_JOB_SELECT()
    {
        try
        {
           
            SqlParameter[] param = new SqlParameter[15];
            /*
            param[0] = new SqlParameter("@Exp_name", Exp_name);
            param[1] = new SqlParameter("@Mode", Mode);
            param[2] = new SqlParameter("@Flag", Flag);
            param[3] = new SqlParameter("@Branch", Branch);

            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;
            */

            param[0] = new SqlParameter("@Exp_name", Exp_name);
            param[1] = new SqlParameter("@Mode", Mode);
            param[2] = new SqlParameter("@R_Id", R_Id);
            param[3] = new SqlParameter("@UPD_ID", UPD_ID);
            param[4] = new SqlParameter("@Flag", Flag);
            param[5] = new SqlParameter("@Branch", Branch);

            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXPORT_MULTIPLE_BL_PENDING_JOB_SELECT", param);
            
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet EXPORT_MULTIPLE_BL_PENDING_JOBS()
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };
            if (from_date != string.Empty && from_date != null)
            {
                arr = from_date.Split('/');
                from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (todate != string.Empty && todate != null)
            {
                arr2 = todate.Split('/');
                todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@Shipper_name", Exp_name);
            param[1] = new SqlParameter("@Ref_name", Ref_name);
            param[2] = new SqlParameter("@from_date", from_date);
            param[3] = new SqlParameter("@to_date", todate);
            param[4] = new SqlParameter("@Tr_mode", Mode);
            param[5] = new SqlParameter("@Branch", Branch);
            param[6] = new SqlParameter("@BL_Id", BL_Id);

            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXPORT_MULTIPLE_BL_PENDING_JOBS", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

   public void Open_Multiple_BL__XLs_Report(string EXP_name_, string Ref_Name_, string Fromdate_, string Todate_, string Tr_mode_, string Branch_, string Type_, string Excel_jobno_)
    {
        HttpResponse Response = HttpContext.Current.Response;

        Exp_name = EXP_name_.TrimEnd();
        Ref_name = Ref_Name_.TrimEnd();

        from_date = Fromdate_.TrimEnd();
        todate = Todate_.TrimEnd();

        Mode = Tr_mode_;
        Branch = Branch_.TrimEnd();
        BL_Id = Excel_jobno_;

        DataSet dss = EXPORT_MULTIPLE_BL_PENDING_JOBS();
        DataTable dt = dss.Tables[0];
        if (Type_ == "excel")
        {

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Export_Multiple_BL_Pending_Jobs.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                GridView gv = new GridView();

                gv.HeaderStyle.BackColor = System.Drawing.Color.RoyalBlue;
                gv.HeaderStyle.ForeColor = System.Drawing.Color.White;

                gv.AllowPaging = false;
                gv.DataSource = dt;
                gv.DataBind();


                foreach (TableCell cell in gv.HeaderRow.Cells)
                {
                    cell.BackColor = gv.HeaderStyle.BackColor;
                }
                gv.RenderControl(hw);
                
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }

        }

    }

   public void Open_Multiple_BL__XLs_Mail_Report(string EXP_name_, string Ref_Name_, string Fromdate_, string Todate_, string Tr_mode_, string Branch_, string Type_, string Excel_jobno_)
   {

       string Grid_Excel = HttpContext.Current.Server.MapPath("~/Submission/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + HttpContext.Current.Session["currentbranch"].ToString() + "/" + HttpContext.Current.Session["currentuser"].ToString() + "/" + "Grid_Excel" + "/");

       if (Directory.Exists(Grid_Excel) == false)
       {
           Directory.CreateDirectory(Grid_Excel);
       }


       HttpResponse Response = HttpContext.Current.Response;

       Exp_name = EXP_name_.TrimEnd();
       Ref_name = Ref_Name_.TrimEnd();

       from_date = Fromdate_.TrimEnd();
       todate = Todate_.TrimEnd();

       Mode = Tr_mode_;
       Branch = Branch_.TrimEnd();
       BL_Id = Excel_jobno_;

       DataSet dss = EXPORT_MULTIPLE_BL_PENDING_JOBS();
       DataTable dt = dss.Tables[0];
      
       if (Type_ == "excel")
       {
           Response.Clear();
           Response.Buffer = true;
           using (StringWriter sw = new StringWriter())
           {
               HtmlTextWriter hw = new HtmlTextWriter(sw);

               //To Export all pages
               GridView gv = new GridView();

               gv.HeaderStyle.BackColor = System.Drawing.Color.RoyalBlue;
               gv.HeaderStyle.ForeColor = System.Drawing.Color.White;

               gv.AllowPaging = false;
               gv.DataSource = dt;
               gv.DataBind();


               foreach (TableCell cell in gv.HeaderRow.Cells)
               {
                   cell.BackColor = gv.HeaderStyle.BackColor;
               }
               gv.RenderControl(hw);



               string str = "Export_Multiple_BL_Pendingjobs.xls";
               HttpContext.Current.Session.Remove(Grid_Excel);
               if (File.Exists(Grid_Excel + str))
               {
                   DirectoryInfo dir = new DirectoryInfo(Grid_Excel);
                   foreach (FileInfo fi in dir.GetFiles())
                   {
                       fi.Delete();
                   }
                   str = "Export_Multiple_BL_Pendingjobs.xls";

                   StreamWriter myWriter = new StreamWriter((Grid_Excel + "\\" + str + ""), true, System.Text.Encoding.Unicode);
                   myWriter.Write(sw.ToString());
                   myWriter.Flush();
                   myWriter.Close();

                   HttpContext.Current.Session["EXP_MBL_Pending_Jobs"] = Grid_Excel + str;
               }
               else
               {
                   StreamWriter myWriter = new StreamWriter((Grid_Excel + "\\" + str + ""), true, System.Text.Encoding.Unicode);
                   myWriter.Write(sw.ToString());
                   myWriter.Flush();
                   myWriter.Close();

                   HttpContext.Current.Session["EXP_MBL_Pending_Jobs"] = Grid_Excel + str;
               }
           }
       }
   }

   public void Export_to_Pdf()
   {
       HttpResponse Response = HttpContext.Current.Response;

       Response.ContentType = "application/pdf"; 
       Response.AddHeader("content-disposition", "attachment;filename=DotnetGeekBlog.pdf");
       Response.Cache.SetCacheability(HttpCacheability.NoCache);
       string str = "<h4 title='Header' align='Center'> Writing To PDF Using ASP.NET</h1> <br><table align='Center'><tr><td style='width:100px;color:green'> <b>iTextSharp</b></td><td style='width:100px;color:red'>dotnetgeekblog</td></tr></table>";
       StringReader sr = new StringReader(str);
       Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0.0f);
       HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
       PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
       pdfDoc.Open();
       htmlparser.Parse(sr);
       pdfDoc.Close();
       Response.Write(pdfDoc);
       Response.End();
   }
   
   public void Open_Add_Annexure_Report(string Exp_Name_, string Tr_mode_, string Ref_Id_, string Job_Id_, string Branch_)
   {
       HttpResponse Response = HttpContext.Current.Response;

       Exp_name = Exp_Name_;
       Mode = Tr_mode_;
       R_Id = Ref_Id_;
       UPD_ID = Job_Id_;
       Flag = "Add_Annexure_Select";
       Branch = Branch_;

       DataSet dds = new DataSet();
       dds = EXPORT_MULTIPLE_BL_PENDING_JOB_SELECT();
       DataTable dt = new DataTable();

       dt = dds.Tables[0];
       string Type;
       Type = "Pdf";

       if (Type == "Pdf")
       {
           if (dt.Rows.Count > 0)
           {
               Response.Cache.SetCacheability(HttpCacheability.NoCache);
               using (StringWriter sw = new StringWriter())
               {
                   using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                   {
                       GridView gv = new GridView();
                       gv.AllowPaging = false;
                       gv.DataSource = dt;
                       gv.DataBind();

                       //-----------------------------------------
                       gv.HeaderRow.Style.Add("font-weight", "bold");
                       gv.HeaderRow.Style.Add("font-size", "10PX");
                       gv.HeaderRow.Style.Add("text-align", "center");

                       gv.BorderColor = System.Drawing.Color.White;
                       //------------------------------------------


                       gv.HeaderRow.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                       gv.HeaderRow.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");

                       /*
                       gv.HeaderRow.Cells[0].BorderColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF ");
                       gv.HeaderRow.Cells[1].BorderColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF ");

                       gv.Rows[0].Cells[0].BorderColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF ");
                       gv.Rows[0].Cells[1].BorderColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF ");
                       */



                       gv.RenderControl(hw);
                       StringReader sr = new StringReader(sw.ToString());
                       Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0.0f);
                       HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                       PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                       pdfDoc.Open();

                       //string str = "<h4 title='Header' align='Center'> BILL OF LADING - ANNEXURE</h4> <br><table align='Center'><tr><td style='width:100px;color:green'> <b>iTextSharp</b></td><td style='width:100px;color:red'>dotnetgeekblog</td></tr></table>";
                       string str = "<h4 title='Header' align='Center' ><B> MULTIPLE BILL OF LADING - ANNEXURE</B></h4> <br>";
                       StringReader srr = new StringReader(str);

                       htmlparser.Parse(srr);
                       htmlparser.Parse(sr);

                       pdfDoc.Close();

                       Response.ContentType = "application/pdf";
                       Response.AddHeader("content-disposition", "attachment;filename=Add_Annexure.pdf");
                       Response.Cache.SetCacheability(HttpCacheability.NoCache);
                       Response.Write(pdfDoc);
                       Response.End();

                   }
               }
           }

       }

   } 

     
}