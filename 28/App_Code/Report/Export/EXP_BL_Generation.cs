using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using Microsoft.ApplicationBlocks.Data;

public class EXP_BL_Generation
{
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    public int result,UpdateId;
    private string _Ename, _flag;

    #region BL_Generation

    private string _BL_ID;
    private string _JOBNO ;
    private string _EXPORTER_NAME ;
    private string _ADDRESS1 ;
    private string _ADDRESS2;
    private string _ADDRESS3 ;
    private string _ADDRESS4 ;
    private string _ADDRESS5 ;

    private string _CONSIGNEE_NAME ;
    private string _CONSIGNEE_ADD1 ;
    private string _CONSIGNEE_ADD2 ;
    private string _CONSIGNEE_ADD3 ;
    private string _CONSIGNEE_ADD4 ;

    private string _BUYER_NAME ;
    private string _BUYER_ADDRESS ;
    private string _BUYER_ADDRESS1 ;
    private string _BUYER_ADDRESS2 ;
    private string _BUYER_ADDRESS3 ;
    private string _BUYER_ADDRESS4 ;

    private string _BL_NUMBER ;
    private string _SHIP_REF_NO; 
    private string _PLACE_OF_RECEIPT ;
    private string _OCEAN_VESSEL  ;
    private string _PORT_OF_LOADING; 
    private string _FREIGHT_PAYABLE ;
    private string _PLACE_DATE ;
    private string _DATE_OF_RECEIPT ;
    private string _PLACE_OF_DELIVERY; 
    private string _PORT_DISCHARGE ;
    private string _NO_OF_ORGINAL_BL; 
    private string _AGENTS_NAEE_REFNO; 
    private string _FREIGHT_AMT ;

    private string _USERID ;
    private string _LOGIN_DATE;
    private string _STATUS;
    private string _BRANCHCODE ;
    private string _WORKINGPERIOD;

    public string _NOTIFY_1_1;
    public string _NOTIFY_1_2;
    public string _NOTIFY_1_3;
    public string _NOTIFY_1_4;
    public string _NOTIFY_1_5;
    public string _INVOICE_NO;
    public string _SB_NO;

    public string _FREIGHT_PRE_COL;
    public string _IEC_NO;
    public string _HSS_CODE_NO;
    public string _LC_NO;
    public string _TOTALVOLUME;
    public string _ORDER_NO;

    private string _xmlData;

    private string _UPD_ID;

    private string _CONTAINER_Y_N, _PENDING_Y_N, _JOB_DATE, _TOT_VOL_UNIT, _COMMODITY, _TOT_PKGS_UNIT;

    private string _FROM_DATE, _TO_DATE;

    private string _FILE_REF_NO, _VOYAGE;
    private string _CURRENCY, _EX_RATE,_NO_OF_CONTAINERS;
    private string _PERCENTAGE, _TOTAL_BILLAMT, _SHIPMENT_TYPE;
    private string _DBN_NO, _DBN_DATE, _DBN_SLNO, _DB_YES_NO, _RPT_TYPE, _HSN_CODE, _FREIGHT_CHARGES, _PKGS_WORDS;

    public string _TAX_LEDGER_1, _LEDGER_1_TAX, _LEDGER_1_TAX_AMT, _TAX_LEDGER_2, _LEDGER_2_TAX, _LEDGER_2_TAX_AMT, _TAX_LEDGER_3, _LEDGER_3_TAX, _LEDGER_3_TAX_AMT, _GRAND_TOTAL;
    
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

   
    public string BL_ID { get { return _BL_ID; } set { _BL_ID = value; } }
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
    public string TOT_VOL_UNIT { get { return _TOT_VOL_UNIT; } set { _TOT_VOL_UNIT = value; } }
    public string COMMODITY { get { return _COMMODITY; } set { _COMMODITY = value; } }
    public string TOT_PKGS_UNIT { get { return _TOT_PKGS_UNIT; } set { _TOT_PKGS_UNIT = value; } }

    public string FROM_DATE { get { return _FROM_DATE; } set { _FROM_DATE = value; } }
    public string TO_DATE { get { return _TO_DATE; } set { _TO_DATE = value; } }
    public string FILE_REF_NO { get { return _FILE_REF_NO; } set { _FILE_REF_NO = value; } }
    public string VOYAGE { get { return _VOYAGE; } set { _VOYAGE = value; } }

    public string CURRENCY { get { return _CURRENCY; } set { _CURRENCY = value; } }
    public string EX_RATE { get { return _EX_RATE; } set { _EX_RATE = value; } }
    public string NO_OF_CONTAINERS { get { return _NO_OF_CONTAINERS; } set { _NO_OF_CONTAINERS = value; } }
    public string PERCENTAGE { get { return _PERCENTAGE; } set { _PERCENTAGE = value; } }
    public string TOTAL_BILLAMT { get { return _TOTAL_BILLAMT; } set { _TOTAL_BILLAMT = value; } }
    public string SHIPMENT_TYPE { get { return _SHIPMENT_TYPE; } set { _SHIPMENT_TYPE = value; } }
    public string DBN_NO { get { return _DBN_NO; } set { _DBN_NO = value; } }
    public string DBN_DATE { get { return _DBN_DATE; } set { _DBN_DATE = value; } }
    public string DBN_SLNO { get { return _DBN_SLNO; } set { _DBN_SLNO = value; } }
    public string DB_YES_NO { get { return _DB_YES_NO; } set { _DB_YES_NO = value; } }
    public string RPT_TYPE { get { return _RPT_TYPE; } set { _RPT_TYPE = value; } }
    public string HSN_CODE { get { return _HSN_CODE; } set { _HSN_CODE = value; } }
    public string FREIGHT_CHARGES { get { return _FREIGHT_CHARGES; } set { _FREIGHT_CHARGES = value; } }
    public string PKGS_WORDS { get { return _PKGS_WORDS; } set { _PKGS_WORDS = value; } }

    #endregion BL_Generation

    #region BL-gen_Container

    private string _CONTAINER_NO,_SEAL_NO,_SEAL_DATE,_FCL_LCL,_TYPE,_TOTAL_PKGS,_GROSS_WEIGHT;

    public string CONTAINER_NO { get { return _CONTAINER_NO; } set { _CONTAINER_NO = value; } }
    public string SEAL_NO { get { return _SEAL_NO; } set { _SEAL_NO = value; } }
    public string SEAL_DATE { get { return _SEAL_DATE; } set { _SEAL_DATE = value; } }
    public string FCL_LCL { get { return _FCL_LCL; } set { _FCL_LCL = value; } }
    public string TYPE { get { return _TYPE; } set { _TYPE = value; } }
    public string TOTAL_PKGS { get { return _TOTAL_PKGS; } set { _TOTAL_PKGS = value; } }
    public string GROSS_WEIGHT { get { return _GROSS_WEIGHT; } set { _GROSS_WEIGHT = value; } }

    #endregion BL-gen_Container

    #region BL_Gen_Annexure

    private string _MARKS_NOS, _GOODS_DESCRIPTION, _REPORT_TYPE, _BL_ANX_ID;

    public string MARKS_NOS { get { return _MARKS_NOS; } set { _MARKS_NOS = value; } }
    public string GOODS_DESCRIPTION { get { return _GOODS_DESCRIPTION; } set { _GOODS_DESCRIPTION = value; } }
    public string REPORT_TYPE { get { return _REPORT_TYPE; } set { _REPORT_TYPE = value; } }
    public string BL_ANX_ID { get { return _BL_ANX_ID; } set { _BL_ANX_ID = value; } }



    #endregion

    public string Ename { get { return _Ename; } set { _Ename = value; } }
    public string flag { get { return _flag; } set { _flag = value; } }

    public string xmlData { get { return _xmlData; } set { _xmlData = value; } }
    public string UPD_ID { get { return _UPD_ID; } set { _UPD_ID = value; } }

    public String Xml_D;

    public void xml()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[95];

            param[0] = new SqlParameter("@JOBNO", JOBNO);
            param[1] = new SqlParameter("@EXPORTER_NAME", EXPORTER_NAME);
            param[2] = new SqlParameter("@ADDRESS1", ADDRESS1);
            param[3] = new SqlParameter("@ADDRESS2", ADDRESS2);
            param[4] = new SqlParameter("@ADDRESS3", ADDRESS3);
            param[5] = new SqlParameter("@ADDRESS4", ADDRESS4);
            param[6] = new SqlParameter("@ADDRESS5", ADDRESS5);

            param[7] = new SqlParameter("@CONSIGNEE_NAME", CONSIGNEE_NAME);
            param[8] = new SqlParameter("@CONSIGNEE_ADD1", CONSIGNEE_ADD1);
            param[9] = new SqlParameter("@CONSIGNEE_ADD2", CONSIGNEE_ADD2);
            param[10] = new SqlParameter("@CONSIGNEE_ADD3", CONSIGNEE_ADD3);
            param[11] = new SqlParameter("@CONSIGNEE_ADD4", CONSIGNEE_ADD4);

            param[12] = new SqlParameter("@BUYER_NAME", BUYER_NAME);
            param[13] = new SqlParameter("@BUYER_ADDRESS", BUYER_ADDRESS);
            param[14] = new SqlParameter("@BUYER_ADDRESS1", BUYER_ADDRESS1);
            param[15] = new SqlParameter("@BUYER_ADDRESS2", BUYER_ADDRESS2);
            param[16] = new SqlParameter("@BUYER_ADDRESS3", BUYER_ADDRESS3);
            param[17] = new SqlParameter("@BUYER_ADDRESS4", BUYER_ADDRESS4);

            param[18] = new SqlParameter("@BL_NUMBER", BL_NUMBER);
            param[19] = new SqlParameter("@SHIP_REF_NO", SHIP_REF_NO);
            param[20] = new SqlParameter("@PLACE_OF_RECEIPT", PLACE_OF_RECEIPT);
            param[21] = new SqlParameter("@OCEAN_VESSEL", OCEAN_VESSEL);
            param[22] = new SqlParameter("@PORT_OF_LOADING", PORT_OF_LOADING);
            param[23] = new SqlParameter("@FREIGHT_PAYABLE", FREIGHT_PAYABLE);

            param[24] = new SqlParameter("@PLACE_DATE", PLACE_DATE);
            param[25] = new SqlParameter("@DATE_OF_RECEIPT", DATE_OF_RECEIPT);
            param[26] = new SqlParameter("@PLACE_OF_DELIVERY", PLACE_OF_DELIVERY);
            param[27] = new SqlParameter("@PORT_DISCHARGE", PORT_DISCHARGE);
            param[28] = new SqlParameter("@NO_OF_ORGINAL_BL", NO_OF_ORGINAL_BL);
            param[29] = new SqlParameter("@AGENTS_NAEE_REFNO", AGENTS_NAEE_REFNO);
            param[30] = new SqlParameter("@FREIGHT_AMT", FREIGHT_AMT);

            param[31] = new SqlParameter("@USERID", USERID);
            param[32] = new SqlParameter("@STATUS", STATUS);
            param[33] = new SqlParameter("@BRANCHCODE", BRANCHCODE);
            param[34] = new SqlParameter("@WORKINGPERIOD", WORKINGPERIOD);

            param[41] = new SqlParameter("@NOTIFY_1_1", NOTIFY_1_1);
            param[42] = new SqlParameter("@NOTIFY_1_2", NOTIFY_1_2);
            param[43] = new SqlParameter("@NOTIFY_1_3", NOTIFY_1_3);
            param[44] = new SqlParameter("@NOTIFY_1_4", NOTIFY_1_4);
            param[45] = new SqlParameter("@NOTIFY_1_5", NOTIFY_1_5);
            param[46] = new SqlParameter("@INVOICE_NO", INVOICE_NO);
            param[47] = new SqlParameter("@SB_NO", SB_NO);
            param[48] = new SqlParameter("@FREIGHT_PRE_COL", FREIGHT_PRE_COL);

            param[51] = new SqlParameter("@IEC_NO", IEC_NO);
            param[52] = new SqlParameter("@HSS_CODE_NO", HSS_CODE_NO);
            param[53] = new SqlParameter("@LC_NO", LC_NO);
            param[54] = new SqlParameter("@TOTALVOLUME", TOTALVOLUME);
            param[55] = new SqlParameter("@ORDER_NO", ORDER_NO);
            param[56] = new SqlParameter("@CONTAINER_Y_N", CONTAINER_Y_N);
            param[57] = new SqlParameter("@PENDING_Y_N", PENDING_Y_N);
            //param[58] = new SqlParameter("@JOB_DATE", JOB_DATE);
            param[58] = new SqlParameter("@JOB_DATE", DateTime.Parse(JOB_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[59] = new SqlParameter("@TOT_VOL_UNIT", TOT_VOL_UNIT);
            param[60] = new SqlParameter("@COMMODITY", COMMODITY);
            param[61] = new SqlParameter("@TOT_PKGS_UNIT", TOT_PKGS_UNIT);
            param[62] = new SqlParameter("@FILE_REF_NO", FILE_REF_NO);
            param[63] = new SqlParameter("@VOYAGE", VOYAGE);
            param[64] = new SqlParameter("@CURRENCY", CURRENCY);
            param[65] = new SqlParameter("@EX_RATE", EX_RATE);
            param[66] = new SqlParameter("@NO_OF_CONTAINERS", NO_OF_CONTAINERS);
            param[67] = new SqlParameter("@PERCENTAGE", PERCENTAGE);
            param[68] = new SqlParameter("@TOTAL_BILLAMT", TOTAL_BILLAMT);
            param[69] = new SqlParameter("@SHIPMENT_TYPE", SHIPMENT_TYPE);
            param[70] = new SqlParameter("@DBN_NO", DBN_NO);
            //param[71] = new SqlParameter("@DBN_DATE", DBN_DATE);
            param[71] = new SqlParameter("@DBN_DATE", DateTime.Parse(DBN_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[72] = new SqlParameter("@DBN_SLNO", DBN_SLNO);
            param[73] = new SqlParameter("@DB_YES_NO", DB_YES_NO);
            param[74] = new SqlParameter("@RPT_TYPE", RPT_TYPE);

            param[75] = new SqlParameter("@TAX_LEDGER_1", TAX_LEDGER_1);
            param[76] = new SqlParameter("@LEDGER_1_TAX", LEDGER_1_TAX);
            param[77] = new SqlParameter("@LEDGER_1_TAX_AMT", LEDGER_1_TAX_AMT);
            param[78] = new SqlParameter("@TAX_LEDGER_2", TAX_LEDGER_2);
            param[79] = new SqlParameter("@LEDGER_2_TAX", LEDGER_2_TAX);
            param[80] = new SqlParameter("@LEDGER_2_TAX_AMT", LEDGER_2_TAX_AMT);
            param[81] = new SqlParameter("@TAX_LEDGER_3", TAX_LEDGER_3);
            param[82] = new SqlParameter("@LEDGER_3_TAX", LEDGER_3_TAX);
            param[83] = new SqlParameter("@LEDGER_3_TAX_AMT", LEDGER_3_TAX_AMT);
            param[84] = new SqlParameter("@GRAND_TOTAL", GRAND_TOTAL);
            param[85] = new SqlParameter("@HSN_CODE", HSN_CODE);

            param[86] = new SqlParameter("@FREIGHT_CHARGES", FREIGHT_CHARGES);
            param[87] = new SqlParameter("@PKGS_WORDS", PKGS_WORDS);
           
            param[35] = new SqlParameter("@xmlString", Xml_D);
            param[40] = new SqlParameter("@UPD_ID", UPD_ID);

            param[36] = new SqlParameter("@flag", flag);

            param[37] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[37].Direction = ParameterDirection.Output;

            param[38] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[38].Direction = ParameterDirection.Output;

            param[39] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[39].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXP_BL_GENERATION_INS_UPD", param);
            result = Convert.ToInt32(param[37].Value.ToString());

            if (flag == "S")
            {
                 UpdateId = Convert.ToInt32(param[39].Value.ToString());
            }

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }

    public DataSet BL_Select_All()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[6] = new SqlParameter("@BL_ID", BL_ID);
            param[0] = new SqlParameter("@JOBNO", JOBNO);
            param[7] = new SqlParameter("@ExporterName", EXPORTER_NAME);
            param[1] = new SqlParameter("@Ename", Ename);
            param[2] = new SqlParameter("@Working_Period", WORKINGPERIOD);

            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;

            if (Ename == "delete")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXP_BL_GENERATION_SELECT", param);
                result = Convert.ToInt32(param[3].Value.ToString());
            }
            else if (Ename == "Select_All_Details" || Ename == "Check_JobNo" || Ename=="select_BL_Details_Grid" || Ename=="select_BL_MasterDetails_Grid" || Ename=="Get_Except_JobNo" || Ename=="select_BL_Details_Grid" || Ename=="Get_Except_FileRefNo" || Ename=="GET_JOBNO_from_FILE_REF_NO" || Ename=="Get_DbNo_ID" || Ename=="Total_BillAmt_Num_to_Words")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXP_BL_GENERATION_SELECT", param);
                result = Convert.ToInt32(param[3].Value.ToString());
                string err = param[4].Value.ToString();
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                    }
                    else
                    {
                        ds.Tables.Add(dt);
                    }
                }
                else
                {
                    ds.Tables.Add(dt);
                }
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet BL_Rpt()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@jobno", JOBNO);
            param[1] = new SqlParameter("@Branch_Code", BRANCHCODE);

            param[2] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[2].Direction = ParameterDirection.Output;
            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXPORT_BL_GENERATION_RPT", param);
            result = Convert.ToInt32(param[2].Value.ToString());

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public DataSet BL_Container_Insert_Update()
    {
        SqlParameter[] pmtr = new SqlParameter[25];

        pmtr[0] = new SqlParameter("@JOBNO", JOBNO);
        pmtr[1] = new SqlParameter("@UPD_ID", UPD_ID);
        pmtr[2] = new SqlParameter("@BRANCHCODE", BRANCHCODE);
        pmtr[3] = new SqlParameter("@WORKINGPERIOD", WORKINGPERIOD);

        pmtr[4] = new SqlParameter("@xmlString", Xml_D);

        pmtr[5] = new SqlParameter("@flag", flag);

        pmtr[6] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
        pmtr[6].Direction = ParameterDirection.Output;

        pmtr[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
        pmtr[7].Direction = ParameterDirection.Output;

        pmtr[8] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
        pmtr[8].Direction = ParameterDirection.Output;

        SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXP_BL_GENERATION_CONTAINER_INS_UPD", pmtr);
        //result = Convert.ToInt32(pmtr[6].Value.ToString());

        return ds;

    }

    public DataSet BL_Annexure_Insert_Update()
    {
        SqlParameter[] pmtr = new SqlParameter[25];

        string Login_Datetime = LOGIN_DATE.Substring(0, 10);

        pmtr[0] = new SqlParameter("@JOBNO", JOBNO);
        pmtr[9] = new SqlParameter("@MARKS_NOS", MARKS_NOS);
        pmtr[10] = new SqlParameter("@GOODS_DESCRIPTION", GOODS_DESCRIPTION);
        pmtr[13] = new SqlParameter("@REPORT_TYPE", REPORT_TYPE);
        pmtr[11] = new SqlParameter("@USERID", USERID);
        pmtr[12] = new SqlParameter("@STATUS", STATUS);
        pmtr[2] = new SqlParameter("@BRANCHCODE", BRANCHCODE);
        pmtr[3] = new SqlParameter("@WORKINGPERIOD", WORKINGPERIOD);
        pmtr[14] = new SqlParameter("@LOGIN_DATE", DateTime.Parse(LOGIN_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
        pmtr[5] = new SqlParameter("@flag", flag);
        pmtr[6] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
        pmtr[6].Direction = ParameterDirection.Output;
        pmtr[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
        pmtr[7].Direction = ParameterDirection.Output;
        pmtr[8] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
        pmtr[8].Direction = ParameterDirection.Output;

        SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXP_BL_GENERATION_ANNEXURE_INS_UPD", pmtr);
        //result = Convert.ToInt32(pmtr[6].Value.ToString());

        return ds;
    }

    public DataSet BL_Container_Select_All()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@JOBNO", JOBNO);
            param[1] = new SqlParameter("@flag", Ename);
            param[2] = new SqlParameter("@BRANCHCODE", BRANCHCODE);

            param[5] = new SqlParameter("@WORKINGPERIOD", WORKINGPERIOD);
            param[6] = new SqlParameter("@REPORT_TYPE", REPORT_TYPE);

            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;

            if (Ename == "Delete_All" || Ename=="Annexure_Delete_Only"|| Ename=="Certificate_Of_Origin_Delete_All")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXP_BL_GENERATION_CONTAINER_SELECT", param);
                result = Convert.ToInt32(param[3].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXP_BL_GENERATION_CONTAINER_SELECT", param);
                result = Convert.ToInt32(param[3].Value.ToString());
                string err = param[4].Value.ToString();
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                    }
                    else
                    {
                        ds.Tables.Add(dt);
                    }
                }
                else
                {
                    ds.Tables.Add(dt);
                }
            }
        }

        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet BL_NORMAL_SEARCH()
    {
        try
        {
            FROM_DATE = FROM_DATE == null ? string.Empty : FROM_DATE;
            TO_DATE = TO_DATE == null ? string.Empty : TO_DATE;
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (FROM_DATE != string.Empty && FROM_DATE != null)
            {
                arr = FROM_DATE.Split('/');
                FROM_DATE = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (TO_DATE != string.Empty && TO_DATE != null)
            {
                arr2 = TO_DATE.Split('/');
                TO_DATE = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", JOBNO);
            param[1] = new SqlParameter("@ExporterName", EXPORTER_NAME);
            param[2] = new SqlParameter("@from_date", FROM_DATE);
            param[3] = new SqlParameter("@to_date", TO_DATE);
            param[4] = new SqlParameter("@Working_Period", BRANCHCODE);
            param[8] = new SqlParameter("@Branch", BRANCHCODE);
            param[5] = new SqlParameter("@Ename", Ename);

            param[9] = new SqlParameter("@Report_Type", REPORT_TYPE);
            
            param[6] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXP_BL_GENERATION_NORMAL_SEARCH", param);
            //result = Convert.ToInt32(param[6].Value.ToString());

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }


    public DataSet BL_ANNEXURE_GENERAL_SEARCH()
    {
        try
        {
            FROM_DATE = FROM_DATE == null ? string.Empty : FROM_DATE;
            TO_DATE = TO_DATE == null ? string.Empty : TO_DATE;
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (FROM_DATE != string.Empty && FROM_DATE != null)
            {
                arr = FROM_DATE.Split('/');
                FROM_DATE = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (TO_DATE != string.Empty && TO_DATE != null)
            {
                arr2 = TO_DATE.Split('/');
                TO_DATE = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", JOBNO);
            param[1] = new SqlParameter("@TYPE", REPORT_TYPE);
            param[2] = new SqlParameter("@from_date", FROM_DATE);
            param[3] = new SqlParameter("@to_date", TO_DATE);
            param[4] = new SqlParameter("@Working_Period", BRANCHCODE);
            param[8] = new SqlParameter("@Branch", BRANCHCODE);
            param[5] = new SqlParameter("@Ename", Ename);


            param[6] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXP_BL_GENERATION_ANNEXURE_SEARCH", param);
            //result = Convert.ToInt32(param[6].Value.ToString());

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public DataSet BL_Select_All_Annexure_Check()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[6] = new SqlParameter("@BL_ANX_ID", BL_ID);
            param[0] = new SqlParameter("@JOBNO", JOBNO);
            param[1] = new SqlParameter("@flag", Ename);
            param[2] = new SqlParameter("@BRANCHCODE", BRANCHCODE);
            param[5] = new SqlParameter("@WORKINGPERIOD", WORKINGPERIOD);

            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;
          
             ds=SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXP_BL_GEN_JobNo_Check", param);
             result = Convert.ToInt32(param[3].Value.ToString());           
          
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

}