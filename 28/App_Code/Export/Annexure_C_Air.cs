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
/// Summary description for Annexure_C_Air
/// </summary>
/// 

public class Annexure_C_Air
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

    # region Private Attributes

    private string _ANNEX_AIR_ID;
    private string _ANNEX_AIR_JOBNO;
    private string _ANNEX_AIR_SEALNO;
    private string _ANNEX_AIR_SEAL_AGENCY;
    private string _ANNEX_AIR_NATURE_OF_CARGO;
    private string _ANNEX_AIR_MARKS_NOS;
    private string _ANNEX_AIR_TOTAL_PACKAGES;
    private string _ANNEX_AIR_UNIT_CODE;
    private string _ANNEX_AIR_FREIGHT_AMT;
    private string _ANNEX_AIR_INSURANCE_AMT;
    private string _ANNEX_AIR_GROSS_WEIGHT;
    private string _ANNEX_AIR_GR_UNIT_CODE;
    private string _ANNEX_AIR_NET_WEIGHT;
    private string _ANNEX_AIR_MAWB_NO;
    private string _ANNEX_AIR_HAWB_NO;
    private string _ANNEX_AIR_TOTAL_PACKAGES_MAWB;
    private string _ANNEX_AIR_ROTATION_NO;
    private string _ANNEX_AIR_ROTATION_DATE;
    private string _ANNEX_AIR_FOB_VALUE;
    private string _ANNEX_AIR_MAWB_DATE;
    private string _ANNEX_AIR_HAWB_DATE;

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
    private string _JOBNO_PS;


    #endregion


    # region Public Attributes

    public string ANNEX_AIR_ID { get { return _ANNEX_AIR_ID; } set { _ANNEX_AIR_ID = value; } }
    public string ANNEX_AIR_JOBNO { get { return _ANNEX_AIR_JOBNO; } set { _ANNEX_AIR_JOBNO = value; } }
    public string ANNEX_AIR_SEALNO { get { return _ANNEX_AIR_SEALNO; } set { _ANNEX_AIR_SEALNO = value; } }
    public string ANNEX_AIR_SEAL_AGENCY { get { return _ANNEX_AIR_SEAL_AGENCY; } set { _ANNEX_AIR_SEAL_AGENCY = value; } }
    public string ANNEX_AIR_NATURE_OF_CARGO { get { return _ANNEX_AIR_NATURE_OF_CARGO; } set { _ANNEX_AIR_NATURE_OF_CARGO = value; } }
    public string ANNEX_AIR_MARKS_NOS { get { return _ANNEX_AIR_MARKS_NOS; } set { _ANNEX_AIR_MARKS_NOS = value; } }
    public string ANNEX_AIR_TOTAL_PACKAGES { get { return _ANNEX_AIR_TOTAL_PACKAGES; } set { _ANNEX_AIR_TOTAL_PACKAGES = value; } }
    public string ANNEX_AIR_UNIT_CODE { get { return _ANNEX_AIR_UNIT_CODE; } set { _ANNEX_AIR_UNIT_CODE = value; } }
    public string ANNEX_AIR_FREIGHT_AMT { get { return _ANNEX_AIR_FREIGHT_AMT; } set { _ANNEX_AIR_FREIGHT_AMT = value; } }
    public string ANNEX_AIR_INSURANCE_AMT { get { return _ANNEX_AIR_INSURANCE_AMT; } set { _ANNEX_AIR_INSURANCE_AMT = value; } }
    public string ANNEX_AIR_GROSS_WEIGHT { get { return _ANNEX_AIR_GROSS_WEIGHT; } set { _ANNEX_AIR_GROSS_WEIGHT = value; } }
    public string ANNEX_AIR_GR_UNIT_CODE { get { return _ANNEX_AIR_GR_UNIT_CODE; } set { _ANNEX_AIR_GR_UNIT_CODE = value; } }
    public string ANNEX_AIR_NET_WEIGHT { get { return _ANNEX_AIR_NET_WEIGHT; } set { _ANNEX_AIR_NET_WEIGHT = value; } }
    public string ANNEX_AIR_MAWB_NO { get { return _ANNEX_AIR_MAWB_NO; } set { _ANNEX_AIR_MAWB_NO = value; } }
    public string ANNEX_AIR_HAWB_NO { get { return _ANNEX_AIR_HAWB_NO; } set { _ANNEX_AIR_HAWB_NO = value; } }
    public string ANNEX_AIR_TOTAL_PACKAGES_MAWB { get { return _ANNEX_AIR_TOTAL_PACKAGES_MAWB; } set { _ANNEX_AIR_TOTAL_PACKAGES_MAWB = value; } }
    public string ANNEX_AIR_ROTATION_NO { get { return _ANNEX_AIR_ROTATION_NO; } set { _ANNEX_AIR_ROTATION_NO = value; } }
    public string ANNEX_AIR_ROTATION_DATE { get { return _ANNEX_AIR_ROTATION_DATE; } set { _ANNEX_AIR_ROTATION_DATE = value; } }
    public string ANNEX_AIR_FOB_VALUE { get { return _ANNEX_AIR_FOB_VALUE; } set { _ANNEX_AIR_FOB_VALUE = value; } }
    public string ANNEX_AIR_MAWB_DATE { get { return _ANNEX_AIR_MAWB_DATE; } set { _ANNEX_AIR_MAWB_DATE = value; } }
    public string ANNEX_AIR_HAWB_DATE { get { return _ANNEX_AIR_HAWB_DATE; } set { _ANNEX_AIR_HAWB_DATE = value; } }

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
    public string JOBNO_PS { get { return _JOBNO_PS; } set { _JOBNO_PS = value; } }


    #endregion

    #region Insert & Update

    public int Annexure_C_Air_details_insertupdate()
    {
        try
        {
            
    
            SqlParameter[] param = new SqlParameter[50];

            // param[0] = new SqlParameter("@ANNEX_ID", ANNEX_ID);

            param[1] = new SqlParameter("@ANNEX_AIR_JOBNO", ANNEX_AIR_JOBNO);

            param[2] = new SqlParameter("@ANNEX_AIR_SEALNO", ANNEX_AIR_SEALNO);

            param[3] = new SqlParameter("@ANNEX_AIR_SEAL_AGENCY", ANNEX_AIR_SEAL_AGENCY);

            param[4] = new SqlParameter("@ANNEX_AIR_NATURE_OF_CARGO",ANNEX_AIR_NATURE_OF_CARGO);

            param[5] = new SqlParameter("@ANNEX_AIR_MARKS_NOS", ANNEX_AIR_MARKS_NOS);

            param[6] = new SqlParameter("@ANNEX_AIR_TOTAL_PACKAGES", ANNEX_AIR_TOTAL_PACKAGES);

            param[7] = new SqlParameter("@ANNEX_AIR_UNIT_CODE", ANNEX_AIR_UNIT_CODE);

            param[8] = new SqlParameter("@ANNEX_AIR_FREIGHT_AMT", ANNEX_AIR_FREIGHT_AMT);

            param[9] = new SqlParameter("@ANNEX_AIR_INSURANCE_AMT", ANNEX_AIR_INSURANCE_AMT);

            param[10] = new SqlParameter("@ANNEX_AIR_GROSS_WEIGHT", ANNEX_AIR_GROSS_WEIGHT);

            param[11] = new SqlParameter("@ANNEX_AIR_GR_UNIT_CODE", ANNEX_AIR_GR_UNIT_CODE);

            param[12] = new SqlParameter("@ANNEX_AIR_NET_WEIGHT", ANNEX_AIR_NET_WEIGHT);

            param[13] = new SqlParameter("@ANNEX_AIR_MAWB_NO", ANNEX_AIR_MAWB_NO);

            param[14] = new SqlParameter("ANNEX_AIR_HAWB_NO", ANNEX_AIR_HAWB_NO);

            param[15] = new SqlParameter("@ANNEX_AIR_TOTAL_PACKAGES_MAWB", ANNEX_AIR_TOTAL_PACKAGES_MAWB);

            param[16] = new SqlParameter("@ANNEX_AIR_ROTATION_NO", ANNEX_AIR_ROTATION_NO);

            param[17] = new SqlParameter("@ANNEX_AIR_ROTATION_DATE", DateTime.Parse(ANNEX_AIR_ROTATION_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            param[18] = new SqlParameter("@ANNEX_AIR_FOB_VALUE", ANNEX_AIR_FOB_VALUE);

            param[27] = new SqlParameter("@ANNEX_AIR_MAWB_DATE", ANNEX_AIR_MAWB_DATE);

            param[28] = new SqlParameter("@ANNEX_AIR_HAWB_DATE", ANNEX_AIR_HAWB_DATE);

            param[19] = new SqlParameter("@USER_ID", USER_ID);

            param[20] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);

            param[21] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

            param[26] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);

            param[29] = new SqlParameter("@JOBNO_PS", JOBNO_PS);

            param[22] = new SqlParameter("@YEAR", YEAR);

            param[23] = new SqlParameter("@Mflag", flag);

            param[24] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[24].Direction = ParameterDirection.Output;

            param[25] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);

            param[25].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_ANNEXURE_C_AIR_DETAILS_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[24].Value.ToString());
            string err = param[25].Value.ToString();

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

    public DataSet RetrieveAll_Annexure_C_Air_Details()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[10];

            //param[0] = new SqlParameter("@ANNEX_ID", ANNEX_ID);

            param[1] = new SqlParameter("@ANNEX_AIR_JOBNO", ANNEX_AIR_JOBNO);

            param[2] = new SqlParameter("@name", Ename);

            param[3] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);


            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;


            if (Ename == "delete")
            {
                //SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH", param);
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_ANNEXURE_C_AIR_DETAILS", param);

                result = Convert.ToInt32(param[4].Value.ToString());
            }
            else if (Ename == "select")
            {

                //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH", param);
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_ANNEXURE_C_AIR_DETAILS", param);

                string err = param[5].Value.ToString();
                result = Convert.ToInt32(param[4].Value.ToString());
               
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

}