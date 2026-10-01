using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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
using BussinessObject;

/// <summary>
/// Summary description for Delivery_Challan
/// </summary>
public class Delivery_Challan
{
    Date_Time dt_time = new Date_Time();
    SqlDataAdapter da;
    SqlDataReader dr;
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    ErrorLogs er = new ErrorLogs();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    SqlCommand cmd;
    int A1, A2;
    //SqlConnection con = new SqlConnection();
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);
    public int result, UPDATE_ID = 0, UpdateId = 0;

    # region Private Attributes


    private string _DC_ID;
    private string _JOBNO;
    private string _FILE_REF_NO;
    private string _CLIENT_NAME;
    private string _CHA_NAME;
    private string _CHA_NO;
    private string _CHA_ADDRESS;
    private string _CHA_ADDRESS1;
    private string _CHA_ADDRESS2;
    private string _CHA_ADDRESS3;
    private string _CHA_ADDRESS4;
    private string _IMPORTER_NAME;

    private string _ADDRESS1;
    private string _ADDRESS2;
    private string _ADDRESS3;
    private string _ADDRESS4;
    private string _ADDRESS5;
    private string _DATE;

    private string _BODY_CONTENTS;
    private string _MARKSNOS;

    private string _GROSSWEIGHT;
    private string _BE_NO_DATE;
    private string _MAWB_HAWB_NO, _NO_OF_PACKAGE;

    private string _DELIVERY_AT;
    private string _DELI_ADDRESS1;
    private string _DELI_ADDRESS2;
    private string _DELI_ADDRESS3;
    private string _DELI_ADDRESS4;
    private string _DELI_ADDRESS5;
    private string _DUTY_NO;
    private string _DUTY_DATE;
    private string _BE_NO;
    private string _BE_DATE;
    private string _LR_NO;
    private string _LR_DATE;
    private string _FROM;
    private string _TO;
    private string _VEHICLE_NO;
    private string _DRIVER_NAME;

    private string _DESC_GOODS;
    private string _MAWB_NO;
    private string _HAWB_NO;
    private string _MAWB_DATE;
    private string _HAWB_DATE;
    private string _TRANSPORT_MODE;
    private string _VESSEL;
    private string _ASSESABLE_VALUE;
    private string _CUSTOMS_DUTY;
    private string _HSN_CODE;
    private string _CONTAINER_NO;
    private string _CONTAINER_SIZE;
    private string _TRUCK_NO;
    private string _REASON;
    private string _GOODS_VALUE;
    private string _TRANSPORTER;
    private string _BILL_REMARKS;
    private string _DC_NO_PS;
    private string _INVOICE_NO;
    private string _INVOICE_DATE;
    private string _FCL_OR_LCL;
   // private string _ANNEX_SEA_CON_SIZE;
    private string _SEAL_NO;
    private string _FROM_USER;
    private string _TO_USER;
    private string _TRANSPORTER_NAME;
    private string _TRANSPORTER_ID;
    private string _REMARKS;
    
    private string _DC_NO;
    private string _SUPPLIER_NAME;
    private string _SUPPLIER_ADDRESS;
    private string _CONTACT_PERSON_NAME;
    private string _CONTACT_PERSON_NUMBER;


    private string _flag;
    private string _USER_ID;
    private string _BRANCH_CODE;
    private string _YEAR;
    private string _WORKING_PERIOD, _IMAGE_FILE;
    private string _BRANCH_COMMON;

    private string _Ename;

    private string _startRowIndex;

    private string _maximumRows;
    private string _totalRows;

    private string _BE_TYPE, _DC_DATE, _ASSESSABLE_VALUE, _DUTY_VALUE, _TRANSPORTER_ADDRESS, _TRANSP_GSTIN, _TRANSP_STATE, _PICKUP_LOCATION, _DROP_LOCATION, _EWAYBILL_NO, _EWAYBILL_DATE, _DRIVER_MOBNO;

    #endregion

    # region Public Attributes

    public string DC_ID { get { return _DC_ID; } set { _DC_ID = value; } }
    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string FILE_REF_NO { get { return _FILE_REF_NO; } set { _FILE_REF_NO = value; } }

    public string CLIENT_NAME { get { return _CLIENT_NAME; } set { _CLIENT_NAME = value; } }
    public string CHA_NAME { get { return _CHA_NAME; } set { _CHA_NAME = value; } }
    public string CHA_NO { get { return _CHA_NO; } set { _CHA_NO = value; } }
    public string CHA_ADDRESS { get { return _CHA_ADDRESS; } set { _CHA_ADDRESS = value; } }
    public string CHA_ADDRESS1 { get { return _CHA_ADDRESS1; } set { _CHA_ADDRESS1 = value; } }
    public string CHA_ADDRESS2 { get { return _CHA_ADDRESS2; } set { _CHA_ADDRESS2 = value; } }
    public string CHA_ADDRESS3 { get { return _CHA_ADDRESS3; } set { _CHA_ADDRESS3 = value; } }
    public string CHA_ADDRESS4 { get { return _CHA_ADDRESS4; } set { _CHA_ADDRESS4 = value; } }

    public string IMPORTER_NAME { get { return _IMPORTER_NAME; } set { _IMPORTER_NAME = value; } }
    public string ADDRESS1 { get { return _ADDRESS1; } set { _ADDRESS1 = value; } }
    public string ADDRESS2 { get { return _ADDRESS2; } set { _ADDRESS2 = value; } }
    public string ADDRESS3 { get { return _ADDRESS3; } set { _ADDRESS3 = value; } }
    public string ADDRESS4 { get { return _ADDRESS4; } set { _ADDRESS4 = value; } }
    public string ADDRESS5 { get { return _ADDRESS5; } set { _ADDRESS5 = value; } }

    public string DATE { get { return _DATE; } set { _DATE = value; } }
    public string BODY_CONTENTS { get { return _BODY_CONTENTS; } set { _BODY_CONTENTS = value; } }
    public string MARKSNOS { get { return _MARKSNOS; } set { _MARKSNOS = value; } }
    public string NO_OF_PACKAGE { get { return _NO_OF_PACKAGE; } set { _NO_OF_PACKAGE = value; } }
    public string GROSSWEIGHT { get { return _GROSSWEIGHT; } set { _GROSSWEIGHT = value; } }
    public string BE_NO_DATE { get { return _BE_NO_DATE; } set { _BE_NO_DATE = value; } }

    public string DELIVERY_AT { get { return _DELIVERY_AT; } set { _DELIVERY_AT = value; } }
    public string DELI_ADDRESS1 { get { return _DELI_ADDRESS1; } set { _DELI_ADDRESS1 = value; } }
    public string DELI_ADDRESS2 { get { return _DELI_ADDRESS2; } set { _DELI_ADDRESS2 = value; } }
    public string DELI_ADDRESS3 { get { return _DELI_ADDRESS3; } set { _DELI_ADDRESS3 = value; } }
    public string DELI_ADDRESS4 { get { return _DELI_ADDRESS4; } set { _DELI_ADDRESS4 = value; } }
    public string DELI_ADDRESS5 { get { return _DELI_ADDRESS5; } set { _DELI_ADDRESS5 = value; } }
    public string DUTY_NO { get { return _DUTY_NO; } set { _DUTY_NO = value; } }
    public string DUTY_DATE { get { return _DUTY_DATE; } set { _DUTY_DATE = value; } }
    public string LR_NO { get { return _LR_NO; } set { _LR_NO = value; } }
    public string LR_DATE { get { return _LR_DATE; } set { _LR_DATE = value; } }
    public string FROM { get { return _FROM; } set { _FROM = value; } }
    public string TO { get { return _TO; } set { _TO = value; } }
    public string VEHICLE_NO { get { return _VEHICLE_NO; } set { _VEHICLE_NO = value; } }
    public string DRIVER_NAME { get { return _DRIVER_NAME; } set { _DRIVER_NAME = value; } }
    public string BE_NO { get { return _BE_NO; } set { _BE_NO = value; } }
    public string BE_DATE { get { return _BE_DATE; } set { _BE_DATE = value; } }

    public string MAWB_HAWB_NO { get { return _MAWB_HAWB_NO; } set { _MAWB_HAWB_NO = value; } }
    public string DESC_GOODS { get { return _DESC_GOODS; } set { _DESC_GOODS = value; } }

    public string VESSEL { get { return _VESSEL; } set { _VESSEL = value; } }
    public string ASSESABLE_VALUE { get { return _ASSESABLE_VALUE; } set { _ASSESABLE_VALUE = value; } }
    public string CUSTOMS_DUTY { get { return _CUSTOMS_DUTY; } set { _CUSTOMS_DUTY = value; } }
    public string HSN_CODE { get { return _HSN_CODE; } set { _HSN_CODE = value; } }
    public string CONTAINER_NO { get { return _CONTAINER_NO; } set { _CONTAINER_NO = value; } }
    public string CONTAINER_SIZE { get { return _CONTAINER_SIZE; } set { _CONTAINER_SIZE = value; } }
    public string TRUCK_NO { get { return _TRUCK_NO; } set { _TRUCK_NO = value; } }
    public string REASON { get { return _REASON; } set { _REASON = value; } }
    public string GOODS_VALUE { get { return _GOODS_VALUE; } set { _GOODS_VALUE = value; } }
    public string TRANSPORTER { get { return _TRANSPORTER; } set { _TRANSPORTER = value; } }
    public string BILL_REMARKS { get { return _BILL_REMARKS; } set { _BILL_REMARKS = value; } }
    public string DC_NO_PS { get { return _DC_NO_PS; } set { _DC_NO_PS = value; } }
    public string INVOICE_NO { get { return _INVOICE_NO; } set { _INVOICE_NO = value; } }
    public string INVOICE_DATE { get { return _INVOICE_DATE; } set { _INVOICE_DATE = value; } }
    public string FCL_OR_LCL { get { return _FCL_OR_LCL; } set { _FCL_OR_LCL = value; } }
    //public string ANNEX_SEA_CON_SIZE { get { return _ANNEX_SEA_CON_SIZE; } set { _ANNEX_SEA_CON_SIZE = value; } }
    public string SEAL_NO { get { return _SEAL_NO; } set { _SEAL_NO = value; } }


    public string flag { get { return _flag; } set { _flag = value; } }
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }

    public string BRANCH_COMMON { get { return _BRANCH_COMMON; } set { _BRANCH_COMMON = value; } }

    public string IMAGE_FILE { get { return _IMAGE_FILE; } set { _IMAGE_FILE = value; } }
    //public string MAWB_NO { get { return _MAWB_NO; } set { _MAWB_NO = value; } }
    public string HAWB_NO { get { return _HAWB_NO; } set { _HAWB_NO = value; } }
    public string MAWB_DATE { get { return _MAWB_DATE; } set { _MAWB_DATE = value; } }
    public string HAWB_DATE { get { return _HAWB_DATE; } set { _HAWB_DATE = value; } }
    public string TRANSPORT_MODE { get { return _TRANSPORT_MODE; } set { _TRANSPORT_MODE = value; } }
    public string FROM_USER { get { return _FROM_USER; } set { _FROM_USER = value; } }
    public string TO_USER { get { return _TO_USER; } set { _TO_USER = value; } }
    public string TRANSPORTER_NAME { get { return _TRANSPORTER_NAME; } set { _TRANSPORTER_NAME = value; } }
    public string TRANSPORTER_ID { get { return _TRANSPORTER_ID; } set { _TRANSPORTER_ID = value; } }
    public string REMARKS { get { return _REMARKS; } set { _REMARKS = value; } }

    public string DC_NO { get { return _DC_NO; } set { _DC_NO = value; } }
    public string SUPPLIER_NAME { get { return _SUPPLIER_NAME; } set { _SUPPLIER_NAME = value; } }
    public string SUPPLIER_ADDRESS { get { return _SUPPLIER_ADDRESS; } set { _SUPPLIER_ADDRESS = value; } }
    public string CONTACT_PERSON_NAME { get { return _CONTACT_PERSON_NAME; } set { _CONTACT_PERSON_NAME = value; } }
    public string CONTACT_PERSON_NUMBER { get { return _CONTACT_PERSON_NUMBER; } set { _CONTACT_PERSON_NUMBER = value; } }

    public string Ename { get { return _Ename; } set { _Ename = value; } }

    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string totalRows { get { return _totalRows; } set { _totalRows = value; } }

    public string TRANSP_GSTIN { get { return _TRANSP_GSTIN; } set { _TRANSP_GSTIN = value; } }
    public string TRANSP_STATE { get { return _TRANSP_STATE; } set { _TRANSP_STATE = value; } }
    public string BE_TYPE { get { return _BE_TYPE; } set { _BE_TYPE = value; } }
    public string DC_DATE { get { return _DC_DATE; } set { _DC_DATE = value; } }
    public string ASSESSABLE_VALUE { get { return _ASSESSABLE_VALUE; } set { _ASSESSABLE_VALUE = value; } }
    public string DUTY_VALUE { get { return _DUTY_VALUE; } set { _DUTY_VALUE = value; } }
    public string TRANSPORTER_ADDRESS { get { return _TRANSPORTER_ADDRESS; } set { _TRANSPORTER_ADDRESS = value; } }
    public string PICKUP_LOCATION { get { return _PICKUP_LOCATION; } set { _PICKUP_LOCATION = value; } }
    public string DROP_LOCATION { get { return _DROP_LOCATION; } set { _DROP_LOCATION = value; } }
    public string EWAYBILL_NO { get { return _EWAYBILL_NO; } set { _EWAYBILL_NO = value; } }
    public string EWAYBILL_DATE { get { return _EWAYBILL_DATE; } set { _EWAYBILL_DATE = value; } }
    public string DRIVER_MOBNO { get { return _DRIVER_MOBNO; } set { _DRIVER_MOBNO = value; } }

    #endregion

    #region Insert & Update

    public DataSet Delivery_Challan_insertupdate()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[60];

            // param[0] = new SqlParameter("@JOBID", JOBID);

            param[1] = new SqlParameter("@JOBNO", JOBNO);

            param[2] = new SqlParameter("@FILE_REF_NO", FILE_REF_NO);

            param[3] = new SqlParameter("@CLIENT_NAME", CLIENT_NAME);

            param[4] = new SqlParameter("@CHA_NAME", CHA_NAME);

            param[5] = new SqlParameter("@CHA_NO", CHA_NO);

            param[6] = new SqlParameter("@CHA_ADDRESS", CHA_ADDRESS);

            param[7] = new SqlParameter("@CHA_ADDRESS1", CHA_ADDRESS1);

            param[8] = new SqlParameter("@CHA_ADDRESS2", CHA_ADDRESS2);

            param[9] = new SqlParameter("@CHA_ADDRESS3", CHA_ADDRESS3);

            param[10] = new SqlParameter("@CHA_ADDRESS4", CHA_ADDRESS4);

            param[11] = new SqlParameter("@IMPORTER_NAME", IMPORTER_NAME);

            param[12] = new SqlParameter("@ADDRESS1", ADDRESS1);

            param[13] = new SqlParameter("@ADDRESS2", ADDRESS2);

            param[14] = new SqlParameter("@ADDRESS3", ADDRESS3);

            param[15] = new SqlParameter("@ADDRESS4", ADDRESS4);

            param[16] = new SqlParameter("@ADDRESS5", ADDRESS5);

            param[17] = new SqlParameter("@DATE", DateTime.Parse(DATE == string.Empty ? "01/01/1900" : DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            param[18] = new SqlParameter("@BODY_CONTENTS", BODY_CONTENTS);

            param[19] = new SqlParameter("@MARKSNOS", MARKSNOS);

            param[20] = new SqlParameter("@NO_OF_PACKAGE", NO_OF_PACKAGE);

            param[21] = new SqlParameter("@GROSSWEIGHT", GROSSWEIGHT);

            param[22] = new SqlParameter("@BE_NO_DATE", BE_NO_DATE);

            param[23] = new SqlParameter("@MAWB_HAWB_NO", MAWB_HAWB_NO);

            param[24] = new SqlParameter("@DESC_GOODS", DESC_GOODS);

            param[25] = new SqlParameter("@USERID", USER_ID);

            param[26] = new SqlParameter("@BRANCHCODE", BRANCH_CODE);

            param[27] = new SqlParameter("@WORKINGPERIOD", WORKING_PERIOD);

            param[34] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);

            param[28] = new SqlParameter("@Mflag", flag);

            param[29] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[29].Direction = ParameterDirection.Output;

            param[30] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[30].Direction = ParameterDirection.Output;
            param[31] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[31].Direction = ParameterDirection.Output;
            param[32] = new SqlParameter("@YEAR", YEAR);
            param[33] = new SqlParameter("@IMAGE_FILE", IMAGE_FILE);
            param[35] = new SqlParameter("@HAWB_NO", HAWB_NO);
            param[36] = new SqlParameter("@MAWB_DATE", DateTime.Parse(MAWB_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[37] = new SqlParameter("@HAWB_DATE", DateTime.Parse(HAWB_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[38] = new SqlParameter("@TRANSPORT_MODE", TRANSPORT_MODE);
            param[39] = new SqlParameter("@INVOICE_NO", INVOICE_NO);
            param[40] = new SqlParameter("@INVOICE_DATE", DateTime.Parse(INVOICE_DATE == string.Empty ? "01/01/1900" : INVOICE_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[41] = new SqlParameter("@CONTAINER_NO", CONTAINER_NO);
            param[42] = new SqlParameter("@FCL_OR_LCL", FCL_OR_LCL);
            param[43] = new SqlParameter("@SEAL_NO", SEAL_NO);
            param[44] = new SqlParameter("@FROM_USER", FROM_USER);
            param[45] = new SqlParameter("@TO_USER", TO_USER);
            param[46] = new SqlParameter("@TRANSPORTER_NAME", TRANSPORTER_NAME);
            param[47] = new SqlParameter("@TRANSPORTER_ID", TRANSPORTER_ID);
            param[48] = new SqlParameter("@REMARKS", REMARKS);
            param[49] = new SqlParameter("@DC_NO", DC_NO);
            param[50] = new SqlParameter("@SUPPLIER_NAME", SUPPLIER_NAME);
            param[51] = new SqlParameter("@SUPPLIER_ADDRESS", SUPPLIER_ADDRESS);
            param[52] = new SqlParameter("@CONTACT_PERSON_NAME", CONTACT_PERSON_NAME);
            param[53] = new SqlParameter("@CONTACT_PERSON_NUMBER", CONTACT_PERSON_NUMBER);
            param[54] = new SqlParameter("@VEHICLE_NO", VEHICLE_NO);


            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "DELIVERY_CHALLAN_DETAILS_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[29].Value.ToString());
            string err = param[30].Value.ToString();
            if (flag == "S")
             UPDATE_ID = Convert.ToInt32(param[31].Value.ToString());

        }
        catch (Exception ex)
        {

            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    #endregion

    public List<Delivery_Challan> Load_Report(string jobno, string wp, string img_path)
    {
        List<Delivery_Challan> list = new List<Delivery_Challan>();
        list.Clear();
        DataSet ds = new DataSet();

        JOBNO = jobno;
        flag = "Job_Search";
        DATE = "01/01/1900";
        BRANCH_COMMON = wp;
        WORKING_PERIOD = wp;
        ds.Clear();
        ds = Delivery_Challan_insertupdate();
        if (result == 2)
        {
            IMAGE_FILE = img_path + ds.Tables[0].Rows[0]["IMAGE_FILE"].ToString();
            list.Add(new Delivery_Challan()
                {

                    CHA_NAME = ds.Tables[0].Rows[0]["CHA_NAME"].ToString(),
                    CHA_ADDRESS = ds.Tables[0].Rows[0]["CHA_ADDRESS"].ToString(),
                    IMPORTER_NAME = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString(),
                    ADDRESS1 = ds.Tables[0].Rows[0]["ADDRESS1"].ToString(),
                    FILE_REF_NO = jobno,
                    DATE = ds.Tables[0].Rows[0]["DATE"].ToString(),
                    BODY_CONTENTS = ds.Tables[0].Rows[0]["BODY_CONTENTS"].ToString(),
                    MARKSNOS = ds.Tables[0].Rows[0]["MARKSNOS"].ToString(),
                    NO_OF_PACKAGE = ds.Tables[0].Rows[0]["NO_OF_PACKAGE"].ToString(),
                    GROSSWEIGHT = ds.Tables[0].Rows[0]["GROSSWEIGHT"].ToString(),
                    BE_NO_DATE = ds.Tables[0].Rows[0]["BE_NO_DATE"].ToString(),
                    MAWB_HAWB_NO = ds.Tables[0].Rows[0]["MAWB_NO"].ToString(),
                    DESC_GOODS = ds.Tables[0].Rows[0]["DESC_GOODS"].ToString(),
                    IMAGE_FILE = IMAGE_FILE,
                    HAWB_NO = ds.Tables[0].Rows[0]["HAWB_NO"].ToString(),
                    MAWB_DATE = ds.Tables[0].Rows[0]["MAWB_DATE"].ToString(),
                    HAWB_DATE = ds.Tables[0].Rows[0]["HAWB_DATE"].ToString(),
                    TRANSPORT_MODE = ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString()

                });

        }
        return list;
    }

    public void Delivery_Challan_Insert_Update()
    {
        SqlParameter[] param = new SqlParameter[40];

        param[0] = new SqlParameter("@ID", DC_ID);
        param[1] = new SqlParameter("@JOBNO", JOBNO);
        param[2] = new SqlParameter("@DC_NO", FILE_REF_NO);
        param[3] = new SqlParameter("@DC_DATE", DateTime.Parse(DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
        param[4] = new SqlParameter("@VESSEL", VESSEL);
        param[5] = new SqlParameter("@TRANSPORTER_NAME", CHA_NAME);
        param[6] = new SqlParameter("@TRANSPORTER_ADD1", CHA_ADDRESS1);
        param[7] = new SqlParameter("@TRANSPORTER_ADD2", CHA_ADDRESS2);
        param[8] = new SqlParameter("@TRANSPORTER_ADD3", CHA_ADDRESS3);
        param[9] = new SqlParameter("@TRANSPORTER_ADD4", CHA_ADDRESS4);

        param[10] = new SqlParameter("@IMPORTER_NAME", IMPORTER_NAME);
        param[11] = new SqlParameter("@IMPORTER_ADD1", ADDRESS1);
        param[12] = new SqlParameter("@IMPORTER_ADD2", ADDRESS2);
        param[13] = new SqlParameter("@IMPORTER_ADD3", ADDRESS3);
        param[14] = new SqlParameter("@IMPORTER_ADD4", ADDRESS4);

        param[15] = new SqlParameter("@BE_NO", BE_NO_DATE);
        param[16] = new SqlParameter("@ASSESABLE_VALUE", ASSESABLE_VALUE);
        param[17] = new SqlParameter("@CUSTOMS_DUTY", CUSTOMS_DUTY);

        param[18] = new SqlParameter("@DESCRIPTION", DESC_GOODS);
        param[19] = new SqlParameter("@HSN_CODE", HSN_CODE);
        param[20] = new SqlParameter("@CONTAINER_NO", CONTAINER_NO);
        param[21] = new SqlParameter("@CONTAINER_SIZE", CONTAINER_SIZE);
        param[22] = new SqlParameter("@TRUCK_NO", TRUCK_NO);
        param[23] = new SqlParameter("@REASON", REASON);
        param[24] = new SqlParameter("@GOODS_VALUE", GOODS_VALUE);
        param[25] = new SqlParameter("@TRANSPORTER", TRANSPORTER);
        param[26] = new SqlParameter("@BILL_REMARKS", BILL_REMARKS);
        param[35] = new SqlParameter("@DC_NO_PS", DC_NO_PS);

        param[27] = new SqlParameter("@USERID", Connection.Current_User());
        param[28] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
        param[29] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
        param[30] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());

        param[31] = new SqlParameter("@Mflag", flag);
        param[32] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
        param[32].Direction = ParameterDirection.Output;

        param[33] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
        param[33].Direction = ParameterDirection.Output;

        param[34] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
        param[34].Direction = ParameterDirection.Output;

        Connection.Get_Dataset("IMP_DELIVERY_CHALLAN_DETAILS_INSERT_UPDATE", param);
        result = Convert.ToInt32(param[32].Value.ToString());

        if (flag == "S")
        {
            UpdateId = Convert.ToInt32(param[34].Value.ToString());
        }
    }


    public DataSet Imp_DeliveryChallan_Select(UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[18];

            param[0] = new SqlParameter("@Item_Id", objUserBL.ITEM_ID);
            param[1] = new SqlParameter("@Jobno", objUserBL.JOBNO);
            param[2] = new SqlParameter("@DOC_Refno", objUserBL.File_Refno);
            param[3] = new SqlParameter("@Imp_name", objUserBL.Imp_Name);
            param[6] = new SqlParameter("@From_date", objUserBL.From_date);
            param[7] = new SqlParameter("@Todate", objUserBL.Todate);
            param[4] = new SqlParameter("@Branch_common", Connection.Get_Company_Type());
            param[5] = new SqlParameter("@Flag", objUserBL.flag);

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            param[15] = new SqlParameter("@Mstatus", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("IMP_DEIVERY_CHALLAN_SELECT", param);

            if (objUserBL.flag == "D")
            {
                result = Convert.ToInt32(param[15].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Delivery_Challan_insertupdate_Ksquare()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[50];

            // param[0] = new SqlParameter("@JOBID", JOBID);

            param[1] = new SqlParameter("@DC_ID", DC_ID);

            param[2] = new SqlParameter("@JOBNO", JOBNO);

            param[3] = new SqlParameter("@FILE_REF_NO", FILE_REF_NO);

            param[4] = new SqlParameter("@IMPORTER_NAME", IMPORTER_NAME);

            param[5] = new SqlParameter("@ADDRESS1", ADDRESS1);

            param[6] = new SqlParameter("@ADDRESS2", ADDRESS2);

            param[7] = new SqlParameter("@ADDRESS3", ADDRESS3);

            param[8] = new SqlParameter("@ADDRESS4", ADDRESS4);

            param[9] = new SqlParameter("@ADDRESS5", ADDRESS5);

            param[10] = new SqlParameter("@DELIVERY_AT", DELIVERY_AT);

            param[11] = new SqlParameter("@DELI_ADDRESS1", DELI_ADDRESS1);

            param[12] = new SqlParameter("@DELI_ADDRESS2", DELI_ADDRESS2);

            param[13] = new SqlParameter("@DELI_ADDRESS3", DELI_ADDRESS3);

            param[14] = new SqlParameter("@DELI_ADDRESS4", DELI_ADDRESS4);

            param[15] = new SqlParameter("@DELI_ADDRESS5", DELI_ADDRESS5);

            param[16] = new SqlParameter("@DATE", DATE);

            param[17] = new SqlParameter("@MARKSNOS", MARKSNOS);

            param[18] = new SqlParameter("@NO_OF_PACKAGE", NO_OF_PACKAGE);

            param[19] = new SqlParameter("@GROSSWEIGHT", GROSSWEIGHT);

            param[20] = new SqlParameter("@BE_NO", BE_NO);

            param[21] = new SqlParameter("@BE_DATE", BE_DATE);

            param[22] = new SqlParameter("@DUTY_NO", DUTY_NO);

            param[23] = new SqlParameter("@DUTY_DATE", DUTY_DATE);

            param[24] = new SqlParameter("@LR_NO", LR_NO);
            param[25] = new SqlParameter("@LR_DATE", LR_DATE);
            param[26] = new SqlParameter("@DESC_GOODS", DESC_GOODS);
            param[27] = new SqlParameter("@FROM", FROM);
            param[28] = new SqlParameter("@TO", TO);
            param[29] = new SqlParameter("@VEHICLE_NO", VEHICLE_NO);
            param[30] = new SqlParameter("@DRIVER_NAME", DRIVER_NAME);


            param[32] = new SqlParameter("@USER_ID", USER_ID);

            param[33] = new SqlParameter("@BRANCHCODE", BRANCH_CODE);

            param[34] = new SqlParameter("@WORKINGPERIOD", WORKING_PERIOD);

            param[35] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);

            param[36] = new SqlParameter("@Mflag", flag);

            param[37] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[37].Direction = ParameterDirection.Output;

            param[38] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);

            param[38].Direction = ParameterDirection.Output;
            param[39] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[39].Direction = ParameterDirection.Output;
            param[40] = new SqlParameter("@YEAR", YEAR);



            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "DELIVERY_CHALLAN_DETAILS_INSERT_UPDATE_KSQUARE", param);

            result = Convert.ToInt32(param[37].Value.ToString());
            //string err = param[30].Value.ToString();
            //if (flag == "S")
            //    UPDATE_ID = Convert.ToInt32(param[39].Value.ToString());

        }
        catch (Exception ex)
        {

            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public DataSet Sudharsan_Cargo_Delivery_Challan_insertupdate()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[70];
            param[1] = new SqlParameter("@JOBNO", JOBNO);
            param[2] = new SqlParameter("@FILE_REF_NO", FILE_REF_NO);
            param[3] = new SqlParameter("@BE_TYPE", BE_TYPE);
            param[4] = new SqlParameter("@DC_NO", DC_NO);
            param[5] = new SqlParameter("@DC_DATE", DateTime.Parse(DC_DATE == string.Empty ? "01/01/1900" : DC_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[6] = new SqlParameter("@CLIENT_NAME", CLIENT_NAME);
            param[7] = new SqlParameter("@CHA_NAME", CHA_NAME);
            param[8] = new SqlParameter("@CHA_NO", CHA_NO);
            param[9] = new SqlParameter("@CHA_ADDRESS", CHA_ADDRESS);
            param[10] = new SqlParameter("@CHA_ADDRESS1", CHA_ADDRESS1);
            param[11] = new SqlParameter("@CHA_ADDRESS2", CHA_ADDRESS2);
            param[12] = new SqlParameter("@CHA_ADDRESS3", CHA_ADDRESS3);
            param[13] = new SqlParameter("@CHA_ADDRESS4", CHA_ADDRESS4);
            param[14] = new SqlParameter("@IMPORTER_NAME", IMPORTER_NAME);
            param[15] = new SqlParameter("@ADDRESS1", ADDRESS1);
            param[16] = new SqlParameter("@ADDRESS2", ADDRESS2);
            param[17] = new SqlParameter("@ADDRESS3", ADDRESS3);
            param[18] = new SqlParameter("@ADDRESS4", ADDRESS4);
            param[19] = new SqlParameter("@ADDRESS5", ADDRESS5);
            param[20] = new SqlParameter("@DATE", DateTime.Parse(DATE == string.Empty ? "01/01/1900" : DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[21] = new SqlParameter("@MARKSNOS", MARKSNOS);
            param[22] = new SqlParameter("@NO_OF_PACKAGE", NO_OF_PACKAGE);
            param[23] = new SqlParameter("@GROSSWEIGHT", GROSSWEIGHT);
            param[24] = new SqlParameter("@BE_NO_DATE", BE_NO_DATE);
            param[25] = new SqlParameter("@MAWB_HAWB_NO", MAWB_HAWB_NO);
            param[26] = new SqlParameter("@DESC_GOODS", DESC_GOODS);
            param[27] = new SqlParameter("@ASSESSABLE_VALUE", ASSESSABLE_VALUE);
            param[28] = new SqlParameter("@DUTY_VALUE", DUTY_VALUE);
            param[29] = new SqlParameter("@USER_ID", USER_ID);
            param[30] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[31] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            //param[32] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
            param[33] = new SqlParameter("@Mflag", flag);
            param[34] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[34].Direction = ParameterDirection.Output;
            param[35] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[35].Direction = ParameterDirection.Output;
            param[36] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[36].Direction = ParameterDirection.Output;
            param[37] = new SqlParameter("@YEAR", YEAR);
            param[38] = new SqlParameter("@IMAGE_FILE", IMAGE_FILE);
            param[39] = new SqlParameter("@HAWB_NO", HAWB_NO);
            param[40] = new SqlParameter("@MAWB_DATE", MAWB_DATE);// DateTime.Parse(MAWB_DATE == string.Empty ? "01/01/1900" : MAWB_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[41] = new SqlParameter("@HAWB_DATE", HAWB_DATE);// DateTime.Parse(HAWB_DATE == string.Empty ? "01/01/1900" : HAWB_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[42] = new SqlParameter("@TRANSPORT_MODE", TRANSPORT_MODE);
            param[43] = new SqlParameter("@FROM_USER", FROM_USER);
            param[44] = new SqlParameter("@TO_USER", TO_USER);
            param[45] = new SqlParameter("@TRANSPORTER_NAME", TRANSPORTER_NAME);
            param[46] = new SqlParameter("@TRANSPORTER_ADDRESS", TRANSPORTER_ADDRESS);
            param[47] = new SqlParameter("@TRANSPORTER_ID", TRANSPORTER_ID);
            param[48] = new SqlParameter("@REMARKS", REMARKS);
            param[49] = new SqlParameter("@SUPPLIER_NAME", SUPPLIER_NAME);
            param[50] = new SqlParameter("@SUPPLIER_ADDRESS", SUPPLIER_ADDRESS);
            param[51] = new SqlParameter("@VEHICLE_NO", VEHICLE_NO);
            param[52] = new SqlParameter("@PICKUP_LOCATION", PICKUP_LOCATION);
            param[53] = new SqlParameter("@DROP_LOCATION", DROP_LOCATION);
            param[54] = new SqlParameter("@LR_NO", LR_NO);
            param[55] = new SqlParameter("@LR_DATE", DateTime.Parse(LR_DATE == string.Empty ? "01/01/1900" : LR_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[56] = new SqlParameter("@EWAYBILL_NO", EWAYBILL_NO);
            param[57] = new SqlParameter("@EWAYBILL_DATE", DateTime.Parse(EWAYBILL_DATE == string.Empty ? "01/01/1900" : EWAYBILL_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[58] = new SqlParameter("@DRIVER_NAME", DRIVER_NAME);
            param[59] = new SqlParameter("@DRIVER_MOBNO", DRIVER_MOBNO);
            param[60] = new SqlParameter("@TRANSP_GSTIN", TRANSP_GSTIN);
            param[61] = new SqlParameter("@TRANSP_STATE", TRANSP_STATE);

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SUDHARSAN_CARGO_DELIVERY_CHALLAN_DETAILS_INSERT_UPDATE_OLD", param);

            result = Convert.ToInt32(param[34].Value.ToString());
            string err = param[35].Value.ToString();
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[36].Value.ToString());

        }
        catch (Exception ex)
        {

            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }
    public List<Delivery_Challan> Load_Report_Sudharsan_Cargo(string jobno, string wp)
    {
        List<Delivery_Challan> list = new List<Delivery_Challan>();
        list.Clear();
        DataSet ds = new DataSet();

        JOBNO = jobno;
        flag = "Job_Search";
        DC_DATE = "01/01/1900";
        DATE = "01/01/1900";
        MAWB_DATE = "01/01/1900";
        HAWB_DATE = "01/01/1900";
        LR_DATE = "01/01/1900";
        EWAYBILL_DATE = "01/01/1900";
        BRANCH_CODE = wp;
        BRANCH_COMMON = wp;
        WORKING_PERIOD = wp;
        ds.Clear();
        ds = Sudharsan_Cargo_Delivery_Challan_insertupdate();

        if (result == 2)
        {
            //IMAGE_FILE = img_path1 + ds.Tables[0].Rows[0]["IMAGE_FILE"].ToString(); 42
            list.Add(new Delivery_Challan()
            {
                CLIENT_NAME = "",
                JOBNO = ds.Tables[1].Rows[0]["JOB_PREFIX"].ToString() + "/" + ds.Tables[0].Rows[0]["JOBNO"].ToString() +"/" + ds.Tables[1].Rows[0]["JOB_SUFFIX"].ToString(),    
                CHA_NO = ds.Tables[0].Rows[0]["CHA_NO"].ToString(),
                CHA_NAME = ds.Tables[0].Rows[0]["CHA_NAME"].ToString(),
                CHA_ADDRESS = ds.Tables[0].Rows[0]["CHA_ADDRESS"].ToString(),
                CHA_ADDRESS2 = ds.Tables[0].Rows[0]["CHA_ADDRESS2"].ToString(),
                IMPORTER_NAME = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString(),
                ADDRESS1 = ds.Tables[0].Rows[0]["ADDRESS1"].ToString(),
                ADDRESS2 = ds.Tables[0].Rows[0]["ADDRESS2"].ToString(),
                FILE_REF_NO = ds.Tables[0].Rows[0]["FILE_REF_NO"].ToString(),
                DATE = ds.Tables[0].Rows[0]["DATE"].ToString(),
                BE_TYPE = ds.Tables[0].Rows[0]["BE_TYPE"].ToString(),
                MARKSNOS = ds.Tables[0].Rows[0]["MARKSNOS"].ToString(),
                NO_OF_PACKAGE = ds.Tables[0].Rows[0]["NO_OF_PACKAGE"].ToString(),
                GROSSWEIGHT = ds.Tables[0].Rows[0]["GROSSWEIGHT"].ToString(),
                BE_NO_DATE = ds.Tables[0].Rows[0]["BE_NO_DATE"].ToString(),
                MAWB_HAWB_NO = ds.Tables[0].Rows[0]["MAWB_HAWB_NO"].ToString(),
                DESC_GOODS = ds.Tables[0].Rows[0]["DESC_GOODS"].ToString(),
                ASSESSABLE_VALUE = ds.Tables[0].Rows[0]["ASSESSABLE_VALUE"].ToString(),
                DUTY_VALUE = ds.Tables[0].Rows[0]["DUTY_VALUE"].ToString(),
                //IMAGE_FILE = IMAGE_FILE,
                HAWB_NO = ds.Tables[0].Rows[0]["HAWB_NO"].ToString(),
                MAWB_DATE = ds.Tables[0].Rows[0]["MAWB_DATE"].ToString(),
                HAWB_DATE = ds.Tables[0].Rows[0]["HAWB_DATE"].ToString(),
                TRANSPORT_MODE = ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString(),
                PICKUP_LOCATION = ds.Tables[0].Rows[0]["PICKUP_LOCATION"].ToString(),
                DROP_LOCATION = ds.Tables[0].Rows[0]["DROP_LOCATION"].ToString(),
                LR_NO = ds.Tables[0].Rows[0]["LR_NO"].ToString(),
                LR_DATE = ds.Tables[0].Rows[0]["LR_DATE"].ToString(),
                EWAYBILL_NO = ds.Tables[0].Rows[0]["EWAYBILL_NO"].ToString(),
                EWAYBILL_DATE = ds.Tables[0].Rows[0]["EWAYBILL_DATE"].ToString(),
                TRANSPORTER_NAME = ds.Tables[0].Rows[0]["TRANSPORTER_NAME"].ToString(),
                TRANSPORTER_ID = ds.Tables[0].Rows[0]["TRANSPORTER_ID"].ToString(),
                TRANSPORTER_ADDRESS = ds.Tables[0].Rows[0]["TRANSPORTER_ADDRESS"].ToString(),
                TRANSP_STATE = ds.Tables[0].Rows[0]["TRANSP_STATE"].ToString(),
                TRANSP_GSTIN = ds.Tables[0].Rows[0]["TRANSP_GSTIN"].ToString(),
                DC_DATE = ds.Tables[0].Rows[0]["DC_DATE"].ToString(),
                DC_NO = ds.Tables[0].Rows[0]["DC_NO"].ToString(),
                SUPPLIER_NAME = "",
                SUPPLIER_ADDRESS = "",
                DRIVER_NAME = ds.Tables[0].Rows[0]["DRIVER_NAME"].ToString(),
                DRIVER_MOBNO = ds.Tables[0].Rows[0]["DRIVER_MOBNO"].ToString(),
                VEHICLE_NO = ds.Tables[0].Rows[0]["VEHICLE_NO"].ToString(),
                REMARKS = ds.Tables[0].Rows[0]["REMARKS"].ToString()

            });

        }
        return list;
    }

    public List<Delivery_Challan> Load_Report_KSquare(string jobno, string wp)
    {
        List<Delivery_Challan> list = new List<Delivery_Challan>();

        list.Clear();

        DataSet ds = new DataSet();

        DC_ID = jobno;
        flag = "Job_Search_rpt";
        DATE = "01/01/1900";
        BRANCH_COMMON = wp;
        WORKING_PERIOD = wp;
        ds.Clear();
        ds = Delivery_Challan_insertupdate_Ksquare();
        if (result == 1)
        {
            //IMAGE_FILE = img_path + ds.Tables[0].Rows[0]["IMAGE_FILE"].ToString();
            list.Add(new Delivery_Challan()
            {


                IMPORTER_NAME = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString(),
                ADDRESS1 = ds.Tables[0].Rows[0]["ADDRESS1"].ToString(),
                DELIVERY_AT = ds.Tables[0].Rows[0]["DELIVERY_AT"].ToString(),
                DELI_ADDRESS1 = ds.Tables[0].Rows[0]["DELI_ADDRESS1"].ToString(),
                DC_ID = ds.Tables[0].Rows[0]["DC_ID"].ToString(),
                DATE = ds.Tables[0].Rows[0]["DATE"].ToString(),
                FILE_REF_NO = ds.Tables[0].Rows[0]["FILE_REF_NO"].ToString(),
                BE_NO = ds.Tables[0].Rows[0]["BE_NO"].ToString(),
                BE_DATE = ds.Tables[0].Rows[0]["BE_DATE"].ToString(),
                DUTY_NO = ds.Tables[0].Rows[0]["DUTY_NO"].ToString(),
                DUTY_DATE = ds.Tables[0].Rows[0]["DUTY_DATE"].ToString(),
                LR_NO = ds.Tables[0].Rows[0]["LR_NO"].ToString(),
                LR_DATE = ds.Tables[0].Rows[0]["LR_DATE"].ToString(),
                MARKSNOS = ds.Tables[0].Rows[0]["MARKSNOS"].ToString(),
                DESC_GOODS = ds.Tables[0].Rows[0]["DESC_GOODS"].ToString(),
                GROSSWEIGHT = ds.Tables[0].Rows[0]["GROSSWEIGHT"].ToString(),
                NO_OF_PACKAGE = ds.Tables[0].Rows[0]["NO_OF_PACKAGE"].ToString(),
                FROM = ds.Tables[0].Rows[0]["FROM"].ToString(),
                TO = ds.Tables[0].Rows[0]["TO"].ToString(),
                DRIVER_NAME = ds.Tables[0].Rows[0]["DRIVER_NAME"].ToString(),
                VEHICLE_NO = ds.Tables[0].Rows[0]["VEHICLE_NO"].ToString(),

            });

        }
        return list;
    }
    public List<Delivery_Challan> Load_Report_new(string jobno, string wp, string img_path)    
    {
        List<Delivery_Challan> list = new List<Delivery_Challan>();
        list.Clear();
        DataSet ds = new DataSet();

        JOBNO = jobno;
        flag = "Job_Search";
        DATE = "01/01/1900";
        MAWB_DATE = "01/01/1900";
        HAWB_DATE = "01/01/1900";
        INVOICE_DATE = "01/01/1900";
        BRANCH_CODE = wp;
        BRANCH_COMMON = wp;
        WORKING_PERIOD = wp;
        ds.Clear();
        ds = Delivery_Challan_insertupdate();

        if (result == 2)
        {
            IMAGE_FILE = img_path + ds.Tables[0].Rows[0]["IMAGE_FILE"].ToString();
            //IMAGE_FILE = img_path1 + ds.Tables[0].Rows[0]["IMAGE_FILE"].ToString();
            list.Add(new Delivery_Challan()
            {
                 CHA_NAME = ds.Tables[0].Rows[0]["CHA_NAME"].ToString(),
                CHA_ADDRESS = ds.Tables[0].Rows[0]["CHA_ADDRESS"].ToString(),
                CHA_ADDRESS2 = ds.Tables[0].Rows[0]["CHA_ADDRESS2"].ToString(),
                IMPORTER_NAME = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString(),
                ADDRESS1 = ds.Tables[0].Rows[0]["ADDRESS1"].ToString(),
                ADDRESS2 = ds.Tables[0].Rows[0]["ADDRESS2"].ToString(),
                 FILE_REF_NO = ds.Tables[0].Rows[0]["FILE_REF_NO"].ToString(),
                DATE = ds.Tables[0].Rows[0]["DATE"].ToString(),
                BODY_CONTENTS = ds.Tables[0].Rows[0]["BODY_CONTENTS"].ToString(),
                MARKSNOS = ds.Tables[0].Rows[0]["MARKSNOS"].ToString(),
                NO_OF_PACKAGE = ds.Tables[0].Rows[0]["NO_OF_PACKAGE"].ToString(),
                GROSSWEIGHT = ds.Tables[0].Rows[0]["GROSSWEIGHT"].ToString(),
                BE_NO_DATE = ds.Tables[0].Rows[0]["BE_NO_DATE"].ToString(),
                 MAWB_HAWB_NO = ds.Tables[0].Rows[0]["MAWB_HAWB_NO"].ToString(),
                DESC_GOODS = ds.Tables[0].Rows[0]["DESC_GOODS"].ToString(),
                IMAGE_FILE = IMAGE_FILE,
                HAWB_NO = ds.Tables[0].Rows[0]["HAWB_NO"].ToString(),
                 MAWB_DATE = ds.Tables[0].Rows[0]["MAWB_DATE"].ToString(),
                 HAWB_DATE = ds.Tables[0].Rows[0]["HAWB_DATE"].ToString(),
                TRANSPORT_MODE = ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString(),
                 INVOICE_NO = ds.Tables[0].Rows[0]["INVOICE_NO"].ToString(),
                 INVOICE_DATE = ds.Tables[0].Rows[0]["INVOICE_DATE"].ToString(),
                 CONTAINER_NO = ds.Tables[0].Rows[0]["CONTAINER_NO"].ToString(),
                 FCL_OR_LCL = ds.Tables[0].Rows[0]["FCL_OR_LCL"].ToString(),
                 SEAL_NO = ds.Tables[0].Rows[0]["SEAL_NO"].ToString(),
                 FROM_USER = ds.Tables[0].Rows[0]["FROM_USER"].ToString(),
                 TO_USER = ds.Tables[0].Rows[0]["TO_USER"].ToString(),
                 TRANSPORTER_NAME = ds.Tables[0].Rows[0]["TRANSPORTER_NAME"].ToString(),
                 TRANSPORTER_ID = ds.Tables[0].Rows[0]["TRANSPORTER_ID"].ToString(),
                 REMARKS = ds.Tables[0].Rows[0]["REMARKS"].ToString(),
                 DC_NO = ds.Tables[0].Rows[0]["DC_NO"].ToString(),
                 SUPPLIER_NAME = ds.Tables[0].Rows[0]["SUPPLIER_NAME"].ToString(),
                 SUPPLIER_ADDRESS = ds.Tables[0].Rows[0]["SUPPLIER_ADDRESS"].ToString(),
                 CONTACT_PERSON_NAME = ds.Tables[0].Rows[0]["CONTACT_PERSON_NAME"].ToString(),
                 CONTACT_PERSON_NUMBER = ds.Tables[0].Rows[0]["CONTACT_PERSON_NUMBER"].ToString(),
                 VEHICLE_NO = ds.Tables[0].Rows[0]["VEHICLE_NO"].ToString()

            });

        }
        return list;
    }
    public List<Delivery_Challan> Load_Report_new_pl_Global(string jobno, string wp, string img_path)
    {
        List<Delivery_Challan> list = new List<Delivery_Challan>();
        list.Clear();
        DataSet ds = new DataSet();

        JOBNO = jobno;
        flag = "Job_Search";
        DATE = "01/01/1900";
        MAWB_DATE = "01/01/1900";
        HAWB_DATE = "01/01/1900";
        INVOICE_DATE = "01/01/1900";
        BRANCH_CODE = wp;
        BRANCH_COMMON = wp;
        WORKING_PERIOD = wp;
        ds.Clear();
        ds = Delivery_Challan_insertupdate();

        if (result == 2)
        {
            IMAGE_FILE = img_path + ds.Tables[0].Rows[0]["IMAGE_FILE"].ToString();
            //IMAGE_FILE = img_path1 + ds.Tables[0].Rows[0]["IMAGE_FILE"].ToString();
            list.Add(new Delivery_Challan()
            {
                CHA_NAME = ds.Tables[0].Rows[0]["CHA_NAME"].ToString(),
                CHA_ADDRESS = ds.Tables[0].Rows[0]["CHA_ADDRESS"].ToString(),
                CHA_ADDRESS2 = ds.Tables[0].Rows[0]["CHA_ADDRESS2"].ToString(),
                IMPORTER_NAME = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString(),
                ADDRESS1 = ds.Tables[0].Rows[0]["ADDRESS1"].ToString(),
                ADDRESS2 = ds.Tables[0].Rows[0]["ADDRESS2"].ToString(),
                FILE_REF_NO = ds.Tables[0].Rows[0]["FILE_REF_NO"].ToString(),
                DATE = ds.Tables[0].Rows[0]["DATE"].ToString(),
                BODY_CONTENTS = ds.Tables[0].Rows[0]["BODY_CONTENTS"].ToString(),
                MARKSNOS = ds.Tables[0].Rows[0]["MARKSNOS"].ToString(),
                NO_OF_PACKAGE = ds.Tables[0].Rows[0]["NO_OF_PACKAGE"].ToString(),
                GROSSWEIGHT = ds.Tables[0].Rows[0]["GROSSWEIGHT"].ToString(),
                BE_NO_DATE = ds.Tables[0].Rows[0]["BE_NO_DATE"].ToString(),
                MAWB_HAWB_NO = ds.Tables[0].Rows[0]["MAWB_HAWB_NO"].ToString(),
                DESC_GOODS = ds.Tables[0].Rows[0]["DESC_GOODS"].ToString(),
                IMAGE_FILE = IMAGE_FILE,
                HAWB_NO = ds.Tables[0].Rows[0]["HAWB_NO"].ToString(),
                MAWB_DATE = ds.Tables[0].Rows[0]["MAWB_DATE"].ToString(),
                HAWB_DATE = ds.Tables[0].Rows[0]["HAWB_DATE"].ToString(),
                TRANSPORT_MODE = ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString(),
                INVOICE_NO = ds.Tables[0].Rows[0]["INVOICE_NO"].ToString(),
                INVOICE_DATE = ds.Tables[0].Rows[0]["INVOICE_DATE"].ToString(),
                CONTAINER_NO = ds.Tables[0].Rows[0]["CONTAINER_NO"].ToString(),
                FCL_OR_LCL = ds.Tables[0].Rows[0]["FCL_OR_LCL"].ToString(),
                SEAL_NO = ds.Tables[0].Rows[0]["SEAL_NO"].ToString(),
                FROM_USER = ds.Tables[0].Rows[0]["FROM_USER"].ToString(),
                TO_USER = ds.Tables[0].Rows[0]["TO_USER"].ToString(),
                TRANSPORTER_NAME = ds.Tables[0].Rows[0]["TRANSPORTER_NAME"].ToString(),
                TRANSPORTER_ID = ds.Tables[0].Rows[0]["TRANSPORTER_ID"].ToString(),
                REMARKS = ds.Tables[0].Rows[0]["REMARKS"].ToString(),
                DC_NO = ds.Tables[0].Rows[0]["DC_NO"].ToString(),
                SUPPLIER_NAME = ds.Tables[0].Rows[0]["SUPPLIER_NAME"].ToString(),
                SUPPLIER_ADDRESS = ds.Tables[0].Rows[0]["SUPPLIER_ADDRESS"].ToString(),
                CONTACT_PERSON_NAME = ds.Tables[0].Rows[0]["CONTACT_PERSON_NAME"].ToString(),
                CONTACT_PERSON_NUMBER = ds.Tables[0].Rows[0]["CONTACT_PERSON_NUMBER"].ToString(),
                VEHICLE_NO = ds.Tables[0].Rows[0]["VEHICLE_NO"].ToString(),
                JOBNO = ds.Tables[0].Rows[0]["JOBNO"].ToString()

            });

        }
        return list;
    }
    public List<Delivery_Challan> Load_Report_DC_Common(string jobno, string wp, string img_path)
    {
        List<Delivery_Challan> list = new List<Delivery_Challan>();
        list.Clear();
        DataSet ds = new DataSet();

        JOBNO = jobno;
        flag = "Job_Search";
        DATE = "01/01/1900";
        MAWB_DATE = "01/01/1900";
        HAWB_DATE = "01/01/1900";
        INVOICE_DATE = "01/01/1900";
        BRANCH_CODE = wp;
        BRANCH_COMMON = wp;
        WORKING_PERIOD = wp;
        ds.Clear();
        ds = Delivery_Challan_insertupdate();

        if (result == 2)
        {
            IMAGE_FILE = img_path + ds.Tables[0].Rows[0]["IMAGE_FILE"].ToString();
            //IMAGE_FILE = img_path1 + ds.Tables[0].Rows[0]["IMAGE_FILE"].ToString();
            list.Add(new Delivery_Challan()
            {
                CHA_NAME = ds.Tables[0].Rows[0]["CHA_NAME"].ToString(),
                CHA_ADDRESS = ds.Tables[0].Rows[0]["CHA_ADDRESS"].ToString(),
                CHA_ADDRESS2 = ds.Tables[0].Rows[0]["CHA_ADDRESS2"].ToString(),
                IMPORTER_NAME = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString(),
                ADDRESS1 = ds.Tables[0].Rows[0]["ADDRESS1"].ToString(),
                ADDRESS2 = ds.Tables[0].Rows[0]["ADDRESS2"].ToString(),
                FILE_REF_NO = ds.Tables[0].Rows[0]["FILE_REF_NO"].ToString(),
                DATE = ds.Tables[0].Rows[0]["DATE"].ToString(),
                BODY_CONTENTS = ds.Tables[0].Rows[0]["BODY_CONTENTS"].ToString(),
                MARKSNOS = ds.Tables[0].Rows[0]["MARKSNOS"].ToString(),
                NO_OF_PACKAGE = ds.Tables[0].Rows[0]["NO_OF_PACKAGE"].ToString(),
                GROSSWEIGHT = ds.Tables[0].Rows[0]["GROSSWEIGHT"].ToString(),
                BE_NO_DATE = ds.Tables[0].Rows[0]["BE_NO_DATE"].ToString(),
                MAWB_HAWB_NO = ds.Tables[0].Rows[0]["MAWB_HAWB_NO"].ToString(),
                DESC_GOODS = ds.Tables[0].Rows[0]["DESC_GOODS"].ToString(),
                IMAGE_FILE = IMAGE_FILE,
                HAWB_NO = ds.Tables[0].Rows[0]["HAWB_NO"].ToString(),
                MAWB_DATE = ds.Tables[0].Rows[0]["MAWB_DATE"].ToString(),
                HAWB_DATE = ds.Tables[0].Rows[0]["HAWB_DATE"].ToString(),
                TRANSPORT_MODE = ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString(),
                INVOICE_NO = ds.Tables[0].Rows[0]["INVOICE_NO"].ToString(),
                INVOICE_DATE = ds.Tables[0].Rows[0]["INVOICE_DATE"].ToString(),
                CONTAINER_NO = ds.Tables[0].Rows[0]["CONTAINER_NO"].ToString(),
                FCL_OR_LCL = ds.Tables[0].Rows[0]["FCL_OR_LCL"].ToString(),
                SEAL_NO = ds.Tables[0].Rows[0]["SEAL_NO"].ToString(),
                FROM_USER = ds.Tables[0].Rows[0]["FROM_USER"].ToString(),
                TO_USER = ds.Tables[0].Rows[0]["TO_USER"].ToString(),
                TRANSPORTER_NAME = ds.Tables[0].Rows[0]["TRANSPORTER_NAME"].ToString(),
                TRANSPORTER_ID = ds.Tables[0].Rows[0]["TRANSPORTER_ID"].ToString(),
                REMARKS = ds.Tables[0].Rows[0]["REMARKS"].ToString(),
                DC_NO = ds.Tables[0].Rows[0]["DC_NO"].ToString(),
                SUPPLIER_NAME = ds.Tables[0].Rows[0]["SUPPLIER_NAME"].ToString(),
                SUPPLIER_ADDRESS = ds.Tables[0].Rows[0]["SUPPLIER_ADDRESS"].ToString(),
                CONTACT_PERSON_NAME = ds.Tables[0].Rows[0]["CONTACT_PERSON_NAME"].ToString(),
                CONTACT_PERSON_NUMBER = ds.Tables[0].Rows[0]["CONTACT_PERSON_NUMBER"].ToString(),
                VEHICLE_NO = ds.Tables[0].Rows[0]["VEHICLE_NO"].ToString()

            });

        }
        return list;
    }

}