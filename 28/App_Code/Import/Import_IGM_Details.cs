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
/// Summary description for Import_IGM_Details
/// </summary>
public class Import_IGM_Details
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

    private string _IGM_ID;
    private string _IGM_SLNO_UPDATE;
    private string _IGM_JOBNO;
    private string _IGM_JOBDATE;
    private string _IGM_AIRLINECODE;
    private string _IGM_AIRLINENAME;
    private string _IGM_FLIGHTNO_VESSELNO;
    private string _IGM_FLIGHT_VESSELDATE;
    private string _IGM_NO;
    private string _IGM_DATE;
    private string _IGM_MAWB_MBL;
    private string _IGM_MAWB_MBLDATE;
    private string _IGM_HAWB_HBLNO;
    private string _IGM_HAWB_HBLDATE;
    private string _IGM_NOOFPACKAGE;
    private string _IGM_PACKAGETYPE;
    private string _IGM_GROSSWEIGHT;
    private string _IGM_TYPEOFWEIGHT;
    private string _IGM_NETWEIGHT;
    private string _IGM_NETWEIGHTTYPE;
    private string _IGM_MARKSNOS;
    private string _IGM_TRANSPORTMODE;
    private string _IGM_GATEWAY_IGM_NO;
    private string _IGM_GATEWAY_IGM_DATE;
    private string _IGM_GATEWAY_PORT_CODE;
    private string _TRANSPORT_MODE;
    private string _Ename;

    #endregion

    #region Public Attributes

   
    public string IGM_SLNO_UPDATE { get { return _IGM_SLNO_UPDATE; } set { _IGM_SLNO_UPDATE = value; } }
    public string IGM_ID { get { return _IGM_ID; } set { _IGM_ID = value; } }
    public string IGM_JOBNO { get { return _IGM_JOBNO; } set { _IGM_JOBNO = value; } }
    public string IGM_JOBDATE { get { return _IGM_JOBDATE; } set { _IGM_JOBDATE = value; } }
    public string IGM_AIRLINECODE { get { return _IGM_AIRLINECODE; } set { _IGM_AIRLINECODE = value; } }
    public string IGM_AIRLINENAME { get { return _IGM_AIRLINENAME; } set { _IGM_AIRLINENAME = value; } }
    public string IGM_FLIGHTNO_VESSELNO { get { return _IGM_FLIGHTNO_VESSELNO; } set { _IGM_FLIGHTNO_VESSELNO = value; } }
    public string IGM_FLIGHT_VESSELDATE { get { return _IGM_FLIGHT_VESSELDATE; } set { _IGM_FLIGHT_VESSELDATE = value; } }
    public string IGM_NO { get { return _IGM_NO; } set { _IGM_NO = value; } }
    public string IGM_DATE { get { return _IGM_DATE; } set { _IGM_DATE = value; } }
    public string IGM_MAWB_MBL { get { return _IGM_MAWB_MBL; } set { _IGM_MAWB_MBL = value; } }
    public string IGM_MAWB_MBLDATE { get { return _IGM_MAWB_MBLDATE; } set { _IGM_MAWB_MBLDATE = value; } }
    public string IGM_HAWB_HBLNO { get { return _IGM_HAWB_HBLNO; } set { _IGM_HAWB_HBLNO = value; } }
    public string IGM_HAWB_HBLDATE { get { return _IGM_HAWB_HBLDATE; } set { _IGM_HAWB_HBLDATE = value; } }
    public string IGM_NOOFPACKAGE { get { return _IGM_NOOFPACKAGE; } set { _IGM_NOOFPACKAGE = value; } }
    public string IGM_PACKAGETYPE { get { return _IGM_PACKAGETYPE; } set { _IGM_PACKAGETYPE = value; } }
    public string IGM_GROSSWEIGHT { get { return _IGM_GROSSWEIGHT; } set { _IGM_GROSSWEIGHT = value; } }
    public string IGM_TYPEOFWEIGHT { get { return _IGM_TYPEOFWEIGHT; } set { _IGM_TYPEOFWEIGHT = value; } }
    public string IGM_NETWEIGHT { get { return _IGM_NETWEIGHT; } set { _IGM_NETWEIGHT = value; } }
    public string IGM_NETWEIGHTTYPE { get { return _IGM_NETWEIGHTTYPE; } set { _IGM_NETWEIGHTTYPE = value; } }
    public string IGM_MARKSNOS { get { return _IGM_MARKSNOS; } set { _IGM_MARKSNOS = value; } }
    public string IGM_TRANSPORTMODE { get { return _IGM_TRANSPORTMODE; } set { _IGM_TRANSPORTMODE = value; } }
    public string IGM_GATEWAY_IGM_NO { get { return _IGM_GATEWAY_IGM_NO; } set { _IGM_GATEWAY_IGM_NO = value; } }
    public string IGM_GATEWAY_IGM_DATE { get { return _IGM_GATEWAY_IGM_DATE; } set { _IGM_GATEWAY_IGM_DATE = value; } }
    public string IGM_GATEWAY_PORT_CODE { get { return _IGM_GATEWAY_PORT_CODE; } set { _IGM_GATEWAY_PORT_CODE = value; } }

    public string TRANSPORT_MODE { get { return _TRANSPORT_MODE; } set { _TRANSPORT_MODE = value; } }
    public string flag { get { return _flag; } set { _flag = value; } }
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }
    public string Ename { get { return _Ename; } set { _Ename = value; } }

    #endregion

    #region Insert & Update

    public DataSet IGM_Details_insertupdate()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[35];
            param[0] = new SqlParameter("@JOBNO", IGM_JOBNO);
            param[31] = new SqlParameter("@IGM_SLNO_Update", IGM_SLNO_UPDATE);
            param[1] = new SqlParameter("@IGM_JOBDATE", DateTime.Parse(IGM_JOBDATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[2] = new SqlParameter("@IGM_AIRLINECODE", IGM_AIRLINECODE);
            param[3] = new SqlParameter("@IGM_AIRLINENAME", IGM_AIRLINENAME);
            param[4] = new SqlParameter("@IGM_FLIGHTNO_VESSELNO", IGM_FLIGHTNO_VESSELNO);
            param[5] = new SqlParameter("@IGM_FLIGHT_VESSELDATE", DateTime.Parse(IGM_FLIGHT_VESSELDATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[6] = new SqlParameter("@IGM_NO", IGM_NO);
            param[7] = new SqlParameter("@IGM_DATE", DateTime.Parse(IGM_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[8] = new SqlParameter("@IGM_MAWB_MBL", IGM_MAWB_MBL);
            param[9] = new SqlParameter("@IGM_MAWB_MBLDATE", DateTime.Parse(IGM_MAWB_MBLDATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[10] = new SqlParameter("@IGM_HAWB_HBLNO", IGM_HAWB_HBLNO);
            param[11] = new SqlParameter("@IGM_HAWB_HBLDATE", DateTime.Parse(IGM_HAWB_HBLDATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[12] = new SqlParameter("@IGM_NOOFPACKAGE", IGM_NOOFPACKAGE);
            param[13] = new SqlParameter("@IGM_PACKAGETYPE", IGM_PACKAGETYPE);
            param[14] = new SqlParameter("@IGM_GROSSWEIGHT", IGM_GROSSWEIGHT);
            param[15] = new SqlParameter("@IGM_TYPEOFWEIGHT", IGM_TYPEOFWEIGHT);
            param[16] = new SqlParameter("@IGM_NETWEIGHT", IGM_NETWEIGHT);
            param[17] = new SqlParameter("@IGM_NETWEIGHTTYPE", IGM_NETWEIGHTTYPE);
            param[18] = new SqlParameter("@IGM_TRANSPORTMODE", IGM_TRANSPORTMODE);
            param[19] = new SqlParameter("@IGM_MARKSNOS", IGM_MARKSNOS);
            param[20] = new SqlParameter("@IGM_USER_ID", USER_ID);
            param[21] = new SqlParameter("@IGM_BRANCH_CODE", BRANCH_CODE);
            param[22] = new SqlParameter("@IGM_YEAR", YEAR);
            param[23] = new SqlParameter("@IGM_WORKING_PERIOD", WORKING_PERIOD);
            param[24] = new SqlParameter("@Mflag", flag);
            param[25] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[25].Direction = ParameterDirection.Output;
            param[26] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[26].Direction = ParameterDirection.Output;
            param[27] = new SqlParameter("@IGMSLNO", SqlDbType.Int, 1);
            param[27].Direction = ParameterDirection.Output;
            param[28] = new SqlParameter("@IGM_GATEWAY_IGM_NO", IGM_GATEWAY_IGM_NO);
            param[29] = new SqlParameter("@IGM_GATEWAY_IGM_DATE", DateTime.Parse(IGM_GATEWAY_IGM_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[30] = new SqlParameter("@IGM_GATEWAY_PORT_CODE", IGM_GATEWAY_PORT_CODE);


            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IGMDETAILS_INSERT_UPDATE", param);


            //IGMSLNO = Convert.ToInt32(param[27].Value.ToString());
            result = Convert.ToInt32(param[25].Value.ToString());
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

    #region Retrieve Record

    public DataSet RetrieveAll_IGM_Details()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[10];


            param[0] = new SqlParameter("@JOBNO", JOBNO);

            param[6] = new SqlParameter("@IGM_SLNO", IGM_SLNO_UPDATE);

            param[1] = new SqlParameter("@name", Ename);

            param[2] = new SqlParameter("@IGM_TRANSPORTMODE", TRANSPORT_MODE);

            param[3] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);


            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;


            //param[6] = new SqlParameter("@Mflag", flag);

            if (Ename == "select_con")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IGMDETAILS_SELECT", param);
                string err = param[5].Value.ToString();

            }
            else if (Ename == "delete")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IGMDETAILS_SELECT", param);
                //string err = param[5].Value.ToString();
                //string status = param[4].Value.ToString();
                result = Convert.ToInt32(param[4].Value.ToString());
            }
            else
            {
            }

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

    public DataSet MAWBMBLNo()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[15];


            param[0] = new SqlParameter("@name", Ename);
            param[1] = new SqlParameter("@JOBNO", IGM_MAWB_MBL);

            param[2] = new SqlParameter("@IGM_SLNO", "");
            param[3] = new SqlParameter("@Working_Period",WORKING_PERIOD);
            param[4] = new SqlParameter("@IGM_TRANSPORTMODE", "");

            param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;


            param[13] = new SqlParameter("@BRANCH_CODE",Connection.Current_Branch());
            param[14] = new SqlParameter("@USER_ID",Connection.Current_User());

            if (Ename == "IGM_MAWB_MBL_Dup")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IGMDETAILS_SELECT", param);
                string err = param[7].Value.ToString();
            }
            else
            {
            }

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