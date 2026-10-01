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
/// <summary>
/// Summary description for Certificate_Of_Origin
/// </summary>
public class Certificate_Of_Origin
{
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
    public int result, UPDATE_ID = 0;

    # region Private Attributes


    private string _CER_ORG_ID;
    private string _JOBNO;
    private string _FILE_REF_NO;
    private string _TO_ORDER;
    private string _EXPORTER_NAME;
    private string _BRANCH_NO;
    private string _IEC_NO;
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
    private string _CONSIGNEE_ADD5;

    private string _NOTIFY_NAME;
    private string _NOTIFY_ADD1;
    private string _NOTIFY_ADD2;
    private string _NOTIFY_ADD3;
    private string _NOTIFY_ADD4;
    private string _NOTIFY_ADD5;

    private string _PRE_CARRIAGE_BY;
    private string _PLACE_OF_RECEIPT;
    private string _VESSEL_FLIGHT_NO;
    private string _PORT_OF_LOADING;
    private string _PORT_OF_DISCHARGE;
    private string _FINAL_DEST;
    private string _MARK_NOS_CONTAINER_NO;
    private string _NO_KIND_OF_PACKAGES;
    private string _DESCRIPTION_GOODS;
    private string _ORIGIN_CRITERIA;

    private string _GROSS_WEIGHT;

    private string _MEASUREMENT;
    private string _NO_DATE_OF_INVOICE;
    private string _IMPORTING_COUNTRY;
    private string _REMARKS;
    private string _AUTHORISED_SIGNATORY;
    private string _SIGNATURE_DATE;

    private string _flag;
    private string _USER_ID;
    private string _BRANCH_CODE;
    private string _YEAR;
    private string _WORKING_PERIOD;
    private string _BRANCH_COMMON;

    private string _Ename;

    private string _startRowIndex;

    private string _maximumRows;
    private string _totalRows;

    private string _FROM_DATE, _TO_DATE;

    #endregion

    # region Public Attributes

    public string CER_ORG_ID { get { return _CER_ORG_ID; } set { _CER_ORG_ID = value; } }
    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string FILE_REF_NO { get { return _FILE_REF_NO; } set { _FILE_REF_NO = value; } }
    public string TO_ORDER { get { return _TO_ORDER; } set { _TO_ORDER = value; } }

    public string EXPORTER_NAME { get { return _EXPORTER_NAME; } set { _EXPORTER_NAME = value; } }
    public string BRANCH_NO { get { return _BRANCH_NO; } set { _BRANCH_NO = value; } }
    public string IEC_NO { get { return _IEC_NO; } set { _IEC_NO = value; } }
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
    public string CONSIGNEE_ADD5 { get { return _CONSIGNEE_ADD5; } set { _CONSIGNEE_ADD5 = value; } }

    public string NOTIFY_NAME { get { return _NOTIFY_NAME; } set { _NOTIFY_NAME = value; } }
    public string NOTIFY_ADD1 { get { return _NOTIFY_ADD1; } set { _NOTIFY_ADD1 = value; } }
    public string NOTIFY_ADD2 { get { return _NOTIFY_ADD2; } set { _NOTIFY_ADD2 = value; } }
    public string NOTIFY_ADD3 { get { return _NOTIFY_ADD3; } set { _NOTIFY_ADD3 = value; } }
    public string NOTIFY_ADD4 { get { return _NOTIFY_ADD4; } set { _NOTIFY_ADD4 = value; } }
    public string NOTIFY_ADD5 { get { return _NOTIFY_ADD5; } set { _NOTIFY_ADD5 = value; } }

    public string PRE_CARRIAGE_BY { get { return _PRE_CARRIAGE_BY; } set { _PRE_CARRIAGE_BY = value; } }
    public string PLACE_OF_RECEIPT { get { return _PLACE_OF_RECEIPT; } set { _PLACE_OF_RECEIPT = value; } }
    public string VESSEL_FLIGHT_NO { get { return _VESSEL_FLIGHT_NO; } set { _VESSEL_FLIGHT_NO = value; } }
    public string PORT_OF_LOADING { get { return _PORT_OF_LOADING; } set { _PORT_OF_LOADING = value; } }
    public string PORT_OF_DISCHARGE { get { return _PORT_OF_DISCHARGE; } set { _PORT_OF_DISCHARGE = value; } }
    public string FINAL_DEST { get { return _FINAL_DEST; } set { _FINAL_DEST = value; } }
    public string MARK_NOS_CONTAINER_NO { get { return _MARK_NOS_CONTAINER_NO; } set { _MARK_NOS_CONTAINER_NO = value; } }
    public string NO_KIND_OF_PACKAGES { get { return _NO_KIND_OF_PACKAGES; } set { _NO_KIND_OF_PACKAGES = value; } }
    public string DESCRIPTION_GOODS { get { return _DESCRIPTION_GOODS; } set { _DESCRIPTION_GOODS = value; } }
    public string ORIGIN_CRITERIA { get { return _ORIGIN_CRITERIA; } set { _ORIGIN_CRITERIA = value; } }
    public string GROSS_WEIGHT { get { return _GROSS_WEIGHT; } set { _GROSS_WEIGHT = value; } }

    public string MEASUREMENT { get { return _MEASUREMENT; } set { _MEASUREMENT = value; } }

    public string NO_DATE_OF_INVOICE { get { return _NO_DATE_OF_INVOICE; } set { _NO_DATE_OF_INVOICE = value; } }
    public string IMPORTING_COUNTRY { get { return _IMPORTING_COUNTRY; } set { _IMPORTING_COUNTRY = value; } }
    public string REMARKS { get { return _REMARKS; } set { _REMARKS = value; } }
    public string AUTHORISED_SIGNATORY { get { return _AUTHORISED_SIGNATORY; } set { _AUTHORISED_SIGNATORY = value; } }
    public string SIGNATURE_DATE { get { return _SIGNATURE_DATE; } set { _SIGNATURE_DATE = value; } }
   
    public string flag { get { return _flag; } set { _flag = value; } }
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }


    public string BRANCH_COMMON { get { return _BRANCH_COMMON; } set { _BRANCH_COMMON = value; } }

    
    public string Ename { get { return _Ename; } set { _Ename = value; } }

    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string totalRows { get { return _totalRows; } set { _totalRows = value; } }

    public string FROM_DATE { get { return _FROM_DATE; } set { _FROM_DATE = value; } }
    public string TO_DATE { get { return _TO_DATE; } set { _TO_DATE = value; } }

    #endregion

    #region Insert & Update

    public int Certificate_Of_Origin_details_insertupdate()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[50];

            // param[0] = new SqlParameter("@JOBID", JOBID);

            param[1] = new SqlParameter("@JOBNO", JOBNO);

            param[2] = new SqlParameter("@FILE_REF_NO", FILE_REF_NO);

            param[47] = new SqlParameter("@TO_ORDER", TO_ORDER);

            param[3] = new SqlParameter("@EXPORTER_NAME", EXPORTER_NAME);

            param[4] = new SqlParameter("@BRANCH_NO", BRANCH_NO);

            param[5] = new SqlParameter("@IEC_NO", IEC_NO);

            param[6] = new SqlParameter("@ADDRESS1", ADDRESS1);

            param[7] = new SqlParameter("@ADDRESS2", ADDRESS2);

            param[8] = new SqlParameter("@ADDRESS3", ADDRESS3);

            param[9] = new SqlParameter("@ADDRESS4", ADDRESS4);

            param[10] = new SqlParameter("@ADDRESS5", ADDRESS5);

            param[11] = new SqlParameter("@CONSIGNEE_NAME", CONSIGNEE_NAME);

            param[12] = new SqlParameter("@CONSIGNEE_ADD1", CONSIGNEE_ADD1);

            param[13] = new SqlParameter("@CONSIGNEE_ADD2", CONSIGNEE_ADD2);

            param[14] = new SqlParameter("@CONSIGNEE_ADD3", CONSIGNEE_ADD3);

            param[15] = new SqlParameter("@CONSIGNEE_ADD4", CONSIGNEE_ADD4);

            param[16] = new SqlParameter("@CONSIGNEE_ADD5", CONSIGNEE_ADD5);

            param[17] = new SqlParameter("@NOTIFY_NAME", NOTIFY_NAME);

            param[18] = new SqlParameter("@NOTIFY_ADD1", NOTIFY_ADD1);

            param[19] = new SqlParameter("@NOTIFY_ADD2", NOTIFY_ADD2);

            param[20] = new SqlParameter("@NOTIFY_ADD3", NOTIFY_ADD3);

            param[21] = new SqlParameter("@NOTIFY_ADD4", NOTIFY_ADD4);

            param[22] = new SqlParameter("@NOTIFY_ADD5", NOTIFY_ADD5);

            param[23] = new SqlParameter("@PRE_CARRIAGE_BY", PRE_CARRIAGE_BY);

            param[24] = new SqlParameter("@PLACE_OF_RECEIPT", PLACE_OF_RECEIPT);

            param[25] = new SqlParameter("@VESSEL_FLIGHT_NO", VESSEL_FLIGHT_NO);

            param[26] = new SqlParameter("@PORT_OF_LOADING", PORT_OF_LOADING);

            param[27] = new SqlParameter("@PORT_OF_DISCHARGE", PORT_OF_DISCHARGE);

            param[28] = new SqlParameter("@FINAL_DEST", FINAL_DEST);

            param[29] = new SqlParameter("@MARK_NOS_CONTAINER_NO", MARK_NOS_CONTAINER_NO);

            param[30] = new SqlParameter("@NO_KIND_OF_PACKAGES", NO_KIND_OF_PACKAGES);

            param[31] = new SqlParameter("@DESCRIPTION_GOODS", DESCRIPTION_GOODS);

            param[32] = new SqlParameter("@ORIGIN_CRITERIA", ORIGIN_CRITERIA);

            param[33] = new SqlParameter("@GROSS_WEIGHT", GROSS_WEIGHT);

            param[34] = new SqlParameter("@MEASUREMENT", MEASUREMENT);

            param[35] = new SqlParameter("@NO_DATE_OF_INVOICE", NO_DATE_OF_INVOICE);

            param[36] = new SqlParameter("@IMPORTING_COUNTRY", IMPORTING_COUNTRY);

            param[37] = new SqlParameter("@REMARKS", REMARKS);

            param[38] = new SqlParameter("@AUTHORISED_SIGNATORY", AUTHORISED_SIGNATORY);

            param[39] = new SqlParameter("@SIGNATURE_DATE", SIGNATURE_DATE);                 

            param[40] = new SqlParameter("@USERID", USER_ID);

            param[41] = new SqlParameter("@BRANCHCODE", BRANCH_CODE);

            param[48] = new SqlParameter("@YEAR", YEAR);

            param[42] = new SqlParameter("@WORKINGPERIOD", WORKING_PERIOD);

            param[49] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);

            param[43] = new SqlParameter("@Mflag", flag);

            param[44] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[44].Direction = ParameterDirection.Output;

            param[45] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);

            param[45].Direction = ParameterDirection.Output;
            param[46] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[46].Direction = ParameterDirection.Output;


            SqlHelper.ExecuteNonQuery(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXPORT_CERTIFICATE_OF_ORGIN_DETAILS_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[44].Value.ToString());
            string err = param[45].Value.ToString();
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[46].Value.ToString());

        }
        catch (Exception ex)
        {

            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return result;
    }

    #endregion


    public DataSet COO_NORMAL_SEARCH()
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
            param[4] = new SqlParameter("@Working_Period", BRANCH_CODE);
            param[8] = new SqlParameter("@Branch", BRANCH_CODE);
            param[5] = new SqlParameter("@Ename", Ename);


            param[6] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXP_CERTIFICATE_OF_ORIGIN_NORMAL_SEARCH", param);
            result = Convert.ToInt32(param[6].Value.ToString());

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }
}