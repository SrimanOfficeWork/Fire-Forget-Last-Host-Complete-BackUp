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
/// Summary description for Import_General
/// </summary>
public class Import_General
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
    public int result;
    public string err;


    # region Common Attributes

    private string _flag;
    private string _USER_ID;
    private string _BRANCH_CODE;
    private string _YEAR;
    private string _WORKING_PERIOD;
    private string _JOBNO;

    private string _startRowIndex;
    private string _maximumRows;
    private string _totalRows;
    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string totalRows { get { return _totalRows; } set { _totalRows = value; } }

    #endregion


    #region Private Attributes

    private string _JOBID;
    private string _Ename;

    private string _JOBDATE;
    private string _TRANSPORT_MODE;
    private string _BE_TYPE;
    private string _CUSTOMS_HOUSE;
    private string _IMPORTER_NAME;
    private string _ADDRESS1;
    private string _ADDRESS2;
    private string _ADDRESS3;
    private string _ADDRESS4;
    private string _ADDRESS5;
    private string _IEC_NO;
    private string _BRANCH_NO;
    private string _COUNTRY_ORIGIN;
    private string _PORT_ORIGIN;

    private string _PORT_SHIPMENT;
    private string _COUNTRY_SHIPMENT;
    private string _FILING_STATUS;
    private string _SECTION46;
    private string _SECTION46_DESC;
    private string _FIRSTCHECK;
    private string _FIRSTCHECK_DESC;
    private string _GREEN_CHANNEL;
    private string _GREEN_CHANNEL_DESC;
    private string _KACHHA_BE;
    private string _KACHHA_BE_DESC;
    private string _SECTION48;
    private string _SECTION48_DESC;
    private string _HIGH_SEA_SALE;
    private string _HIGH_SEA_SALE_NAME;
    private string _HIGH_SEA_IEC;
    private string _HIGH_SEA_BRANCH_SL_NO;
    private string _HSS_ADD1;
    private string _HSS_ADD2;
    private string _HSS_ADD3;
    private string _HSS_ADD4;
    private string _HSS_ADD5;
    private string _WAREHOUSE_NAME;
    private string _WAREHOUSE_CODE;
    private string _REMARKS;

    #endregion

    #region Public Attributes

  
    public string JOBID { get { return _JOBID; } set { _JOBID = value; } }
   
    public string JOBDATE { get { return _JOBDATE; } set { _JOBDATE = value; } }
    public string TRANSPORT_MODE { get { return _TRANSPORT_MODE; } set { _TRANSPORT_MODE = value; } }
    public string BE_TYPE { get { return _BE_TYPE; } set { _BE_TYPE = value; } }
    public string CUSTOMS_HOUSE { get { return _CUSTOMS_HOUSE; } set { _CUSTOMS_HOUSE = value; } }
    public string IMPORTER_NAME { get { return _IMPORTER_NAME; } set { _IMPORTER_NAME = value; } }
    public string ADDRESS1 { get { return _ADDRESS1; } set { _ADDRESS1 = value; } }
    public string ADDRESS2 { get { return _ADDRESS2; } set { _ADDRESS2 = value; } }
    public string ADDRESS3 { get { return _ADDRESS3; } set { _ADDRESS3 = value; } }
    public string ADDRESS4 { get { return _ADDRESS4; } set { _ADDRESS4 = value; } }
    public string ADDRESS5 { get { return _ADDRESS5; } set { _ADDRESS5 = value; } }
    public string IEC_NO { get { return _IEC_NO; } set { _IEC_NO = value; } }
    public string BRANCH_NO { get { return _BRANCH_NO; } set { _BRANCH_NO = value; } }
    public string COUNTRY_ORIGIN { get { return _COUNTRY_ORIGIN; } set { _COUNTRY_ORIGIN = value; } }
    public string PORT_ORIGIN { get { return _PORT_ORIGIN; } set { _PORT_ORIGIN = value; } }

    public string PORT_SHIPMENT { get { return _PORT_SHIPMENT; } set { _PORT_SHIPMENT = value; } }
    public string COUNTRY_SHIPMENT { get { return _COUNTRY_SHIPMENT; } set { _COUNTRY_SHIPMENT = value; } }
    public string FILING_STATUS { get { return _FILING_STATUS; } set { _FILING_STATUS = value; } }
    public string SECTION46 { get { return _SECTION46; } set { _SECTION46 = value; } }
    public string SECTION46_DESC { get { return _SECTION46_DESC; } set { _SECTION46_DESC = value; } }
    public string FIRSTCHECK { get { return _FIRSTCHECK; } set { _FIRSTCHECK = value; } }
    public string FIRSTCHECK_DESC { get { return _FIRSTCHECK_DESC; } set { _FIRSTCHECK_DESC = value; } }
    public string GREEN_CHANNEL { get { return _GREEN_CHANNEL; } set { _GREEN_CHANNEL = value; } }
    public string GREEN_CHANNEL_DESC { get { return _GREEN_CHANNEL_DESC; } set { _GREEN_CHANNEL_DESC = value; } }
    public string KACHHA_BE { get { return _KACHHA_BE; } set { _KACHHA_BE = value; } }
    public string KACHHA_BE_DESC { get { return _KACHHA_BE_DESC; } set { _KACHHA_BE_DESC = value; } }
    public string SECTION48 { get { return _SECTION48; } set { _SECTION48 = value; } }
    public string SECTION48_DESC { get { return _SECTION48_DESC; } set { _SECTION48_DESC = value; } }
    public string HIGH_SEA_SALE { get { return _HIGH_SEA_SALE; } set { _HIGH_SEA_SALE = value; } }
    public string HIGH_SEA_SALE_NAME { get { return _HIGH_SEA_SALE_NAME; } set { _HIGH_SEA_SALE_NAME = value; } }
    public string HIGH_SEA_IEC { get { return _HIGH_SEA_IEC; } set { _HIGH_SEA_IEC = value; } }
    public string HIGH_SEA_BRANCH_SL_NO { get { return _HIGH_SEA_BRANCH_SL_NO; } set { _HIGH_SEA_BRANCH_SL_NO = value; } }
    public string HSS_ADD1 { get { return _HSS_ADD1; } set { _HSS_ADD1 = value; } }
    public string HSS_ADD2 { get { return _HSS_ADD2; } set { _HSS_ADD2 = value; } }
    public string HSS_ADD3 { get { return _HSS_ADD3; } set { _HSS_ADD3 = value; } }
    public string HSS_ADD4 { get { return _HSS_ADD4; } set { _HSS_ADD4 = value; } }
    public string HSS_ADD5 { get { return _HSS_ADD5; } set { _HSS_ADD5 = value; } }
    public string REMARKS { get { return _REMARKS; } set { _REMARKS = value; } }
    public string WAREHOUSE_NAME { get { return _WAREHOUSE_NAME; } set { _WAREHOUSE_NAME = value; } }
    public string WAREHOUSE_CODE { get { return _WAREHOUSE_CODE; } set { _WAREHOUSE_CODE = value; } }
    public string Ename { get { return _Ename; } set { _Ename = value; } }

    public string flag { get { return _flag; } set { _flag = value; } }

    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }

    #endregion


    #region Insert & Update

    public int General_details_insertupdate()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[50];

            // param[0] = new SqlParameter("@JOBID", JOBID);

            param[1] = new SqlParameter("@JOBNO", JOBNO);


            param[2] = new SqlParameter("@JOBDATE", DateTime.Parse(JOBDATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));


            param[3] = new SqlParameter("@TRANSPORT_MODE", TRANSPORT_MODE);


            param[4] = new SqlParameter("@BE_TYPE", BE_TYPE);


            param[5] = new SqlParameter("@CUSTOMS_HOUSE", CUSTOMS_HOUSE);

            param[6] = new SqlParameter("@IMPORTER_NAME", IMPORTER_NAME);


            param[7] = new SqlParameter("@ADDRESS1", ADDRESS1);


            param[8] = new SqlParameter("@ADDRESS2", ADDRESS2);


            param[9] = new SqlParameter("@ADDRESS3", ADDRESS3);


            param[10] = new SqlParameter("@ADDRESS4", ADDRESS4);


            param[11] = new SqlParameter("@IEC_NO", IEC_NO);


            param[12] = new SqlParameter("@BRANCH_NO", BRANCH_NO);


            param[13] = new SqlParameter("@COUNTRY_ORIGIN", COUNTRY_ORIGIN);


            param[14] = new SqlParameter("@PORT_SHIPMENT", PORT_SHIPMENT);


            param[15] = new SqlParameter("@COUNTRY_SHIPMENT", COUNTRY_SHIPMENT);


            param[16] = new SqlParameter("@FILING_STATUS", FILING_STATUS);


            param[17] = new SqlParameter("@SECTION46", SECTION46);


            param[18] = new SqlParameter("@SECTION46_DESC", SECTION46_DESC);


            param[19] = new SqlParameter("@FIRSTCHECK", FIRSTCHECK);


            param[20] = new SqlParameter("@FIRSTCHECK_DESC", FIRSTCHECK_DESC);
            param[21] = new SqlParameter("@GREEN_CHANNEL", GREEN_CHANNEL);
            param[22] = new SqlParameter("@GREEN_CHANNEL_DESC", GREEN_CHANNEL_DESC);
            param[23] = new SqlParameter("@KACHHA_BE", KACHHA_BE);
            param[24] = new SqlParameter("@KACHHA_BE_DESC", KACHHA_BE_DESC);
            param[25] = new SqlParameter("@SECTION48", SECTION48);
            param[26] = new SqlParameter("@SECTION48_DESC", SECTION48_DESC);
            param[27] = new SqlParameter("@HIGH_SEA_SALE", HIGH_SEA_SALE);
            param[28] = new SqlParameter("@HIGH_SEA_SALE_NAME", HIGH_SEA_SALE_NAME);
            param[29] = new SqlParameter("@HIGH_SEA_IEC", HIGH_SEA_IEC);
            param[30] = new SqlParameter("@HIGH_SEA_BRANCH_SL_NO", HIGH_SEA_BRANCH_SL_NO);
            param[31] = new SqlParameter("@HSS_ADD1", HSS_ADD1);
            param[32] = new SqlParameter("@HSS_ADD2", HSS_ADD2);
            param[33] = new SqlParameter("@HSS_ADD3", HSS_ADD3);
            param[34] = new SqlParameter("@HSS_ADD4", HSS_ADD4);
            param[35] = new SqlParameter("@HSS_ADD5", HSS_ADD5);
            param[36] = new SqlParameter("@WAREHOUSE_NAME", WAREHOUSE_NAME);
            param[37] = new SqlParameter("@WAREHOUSE_CODE", WAREHOUSE_CODE);
            param[38] = new SqlParameter("@REMARKS", REMARKS);
            param[39] = new SqlParameter("@USERID", USER_ID);
            param[40] = new SqlParameter("@BRANCHCODE", BRANCH_CODE);
            param[41] = new SqlParameter("@WORKINGPERIOD", WORKING_PERIOD);
            param[42] = new SqlParameter("@ADDRESS5", ADDRESS5);


            param[43] = new SqlParameter("@Mflag", flag);

            param[44] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[44].Direction = ParameterDirection.Output;

            param[45] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[45].Direction = ParameterDirection.Output;
            param[46] = new SqlParameter("@PORT_ORIGIN", PORT_ORIGIN);



            SqlHelper.ExecuteNonQuery(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[44].Value.ToString());



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

    #region Retrieve Record

    public DataSet RetrieveAll_General_Details()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBID", JOBID);

            param[1] = new SqlParameter("@JOBNO", JOBNO);

            param[2] = new SqlParameter("@IMPORTER_NAME", IMPORTER_NAME);

            param[3] = new SqlParameter("@TRANSPORT_MODE", TRANSPORT_MODE);

            param[4] = new SqlParameter("@CUSTOMS_HOUSE", CUSTOMS_HOUSE);

            param[5] = new SqlParameter("@name", Ename);

            param[6] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);


            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@startRowIndex", startRowIndex);

            param[10] = new SqlParameter("@maximumRows", maximumRows);

            param[11] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output;

            if (Ename == "delete")
            {
                //SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH", param);
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH_SELECT", param);

                result = Convert.ToInt32(param[7].Value.ToString());


            }
            else
            {

                //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH", param);
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[11].Value.ToString());
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                    }
                    else
                        ds.Tables.Add(dt);

                }
                else
                    ds.Tables.Add(dt);
                //string err = param[8].Value.ToString();
            }


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
}