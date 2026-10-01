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
/// Summary description for Annexure_C_Sea
/// </summary>
public class Annexure_C_Sea
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


    private string _ANNEX_SEA_ID;
    private string _ANNEX_SEA_JOBNO;
    private string _ANNEX_SEA_FAC_STUFFED;
    private string _ANNEX_SEA_SAMPLE_ACCOM;
    private string _ANNEX_SEA_NATURE_OF_CARGO;
    private string _ANNEX_SEA_MARKS_NOS;
    private string _ANNEX_SEA_TOTAL_PACKAGES;
    private string _ANNEX_SEA_LOOSE_PACKETS;
    private string _ANNEX_SEA_NO_CONTAINERS;
    private string _ANNEX_SEA_GROSS_WEIGHT;
    private string _ANNEX_SEA_NET_WEIGHT;
    private string _ANNEX_SEA_UNIT_MEASUREMENT;
    private string _ANNEX_SEA_ROTATION_NO;
    private string _ANNEX_SEA_ROTATION_DATE;
    private string _ANNEX_SEA_FOB_VALUE;
    
    private string _flag;
    private string _USER_ID;
    private string _BRANCH_CODE;
    private string _YEAR;
    private string _WORKING_PERIOD;
    private string _BRANCH_COMMON;
    private string _ANNEX_SEA_SEAL_TYPE;
    private string _ANNEX_SEA_FACTORY_ADD, _ANNEX_SEA_VOYAGENO, _ANNEX_SEA_VESSELNO, _ANNEX_SEA_VESSEL_DATE, _ANNEX_SEA_PKG_UNIT_CODE;
    private string _Ename;
    private string _startRowIndex;
    private string _maximumRows;
    private string _totalRows, _JOBNO_PS;

    #endregion

    # region Public Attributes

   
    public string ANNEX_SEA_ID { get { return _ANNEX_SEA_ID; } set { _ANNEX_SEA_ID = value; } }
    public string ANNEX_SEA_JOBNO { get { return _ANNEX_SEA_JOBNO; } set { _ANNEX_SEA_JOBNO = value; } }
    public string ANNEX_SEA_FAC_STUFFED { get { return _ANNEX_SEA_FAC_STUFFED; } set { _ANNEX_SEA_FAC_STUFFED = value; } }
    public string ANNEX_SEA_SAMPLE_ACCOM { get { return _ANNEX_SEA_SAMPLE_ACCOM; } set { _ANNEX_SEA_SAMPLE_ACCOM = value; } }
    public string ANNEX_SEA_NATURE_OF_CARGO { get { return _ANNEX_SEA_NATURE_OF_CARGO; } set { _ANNEX_SEA_NATURE_OF_CARGO = value; } }
    public string ANNEX_SEA_MARKS_NOS { get { return _ANNEX_SEA_MARKS_NOS; } set { _ANNEX_SEA_MARKS_NOS = value; } }
    public string ANNEX_SEA_TOTAL_PACKAGES { get { return _ANNEX_SEA_TOTAL_PACKAGES; } set { _ANNEX_SEA_TOTAL_PACKAGES = value; } }
    public string ANNEX_SEA_LOOSE_PACKETS { get { return _ANNEX_SEA_LOOSE_PACKETS; } set { _ANNEX_SEA_LOOSE_PACKETS = value; } }
    public string ANNEX_SEA_NO_CONTAINERS { get { return _ANNEX_SEA_NO_CONTAINERS; } set { _ANNEX_SEA_NO_CONTAINERS = value; } }
    public string ANNEX_SEA_GROSS_WEIGHT { get { return _ANNEX_SEA_GROSS_WEIGHT; } set { _ANNEX_SEA_GROSS_WEIGHT = value; } }
    public string ANNEX_SEA_NET_WEIGHT { get { return _ANNEX_SEA_NET_WEIGHT; } set { _ANNEX_SEA_NET_WEIGHT = value; } }
    public string ANNEX_SEA_UNIT_MEASUREMENT { get { return _ANNEX_SEA_UNIT_MEASUREMENT; } set { _ANNEX_SEA_UNIT_MEASUREMENT = value; } }
    public string ANNEX_SEA_ROTATION_NO { get { return _ANNEX_SEA_ROTATION_NO; } set { _ANNEX_SEA_ROTATION_NO = value; } }
    public string ANNEX_SEA_ROTATION_DATE { get { return _ANNEX_SEA_ROTATION_DATE; } set { _ANNEX_SEA_ROTATION_DATE = value; } }
    public string ANNEX_SEA_FOB_VALUE { get { return _ANNEX_SEA_FOB_VALUE; } set { _ANNEX_SEA_FOB_VALUE = value; } }

    public string ANNEX_SEA_FACTORY_ADD { get { return _ANNEX_SEA_FACTORY_ADD; } set { _ANNEX_SEA_FACTORY_ADD = value; } }
    public string ANNEX_SEA_VOYAGENO { get { return _ANNEX_SEA_VOYAGENO; } set { _ANNEX_SEA_VOYAGENO = value; } }
    public string ANNEX_SEA_VESSELNO { get { return _ANNEX_SEA_VESSELNO; } set { _ANNEX_SEA_VESSELNO = value; } }
    public string ANNEX_SEA_VESSEL_DATE { get { return _ANNEX_SEA_VESSEL_DATE; } set { _ANNEX_SEA_VESSEL_DATE = value; } }
    public string ANNEX_SEA_PKG_UNIT_CODE { get { return _ANNEX_SEA_PKG_UNIT_CODE; } set { _ANNEX_SEA_PKG_UNIT_CODE = value; } }   
 

    public string flag { get { return _flag; } set { _flag = value; } }
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }
    public string BRANCH_COMMON { get { return _BRANCH_COMMON; } set { _BRANCH_COMMON = value; } }
    public string ANNEX_SEA_SEAL_TYPE { get { return _ANNEX_SEA_SEAL_TYPE; } set { _ANNEX_SEA_SEAL_TYPE = value; } }

    public string Ename { get { return _Ename; } set { _Ename = value; } }

    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string totalRows { get { return _totalRows; } set { _totalRows = value; } }
    public string JOBNO_PS { get { return _JOBNO_PS; } set { _JOBNO_PS = value; } }

    #endregion

    #region Insert & Update

    public int Annexure_C_Sea_details_insertupdate()
    {
        try
        {

          
            SqlParameter[] param = new SqlParameter[50];

            // param[0] = new SqlParameter("@ANNEX_SEA_ID", ANNEX_SEA_ID);

            param[1] = new SqlParameter("@ANNEX_SEA_JOBNO", ANNEX_SEA_JOBNO);

            param[2] = new SqlParameter("@ANNEX_SEA_FAC_STUFFED", ANNEX_SEA_FAC_STUFFED);

            param[3] = new SqlParameter("@ANNEX_SEA_SAMPLE_ACCOM", ANNEX_SEA_SAMPLE_ACCOM);

            param[4] = new SqlParameter("@ANNEX_SEA_NATURE_OF_CARGO", ANNEX_SEA_NATURE_OF_CARGO);

            param[5] = new SqlParameter("@ANNEX_SEA_MARKS_NOS", ANNEX_SEA_MARKS_NOS);

            param[6] = new SqlParameter("@ANNEX_SEA_TOTAL_PACKAGES", ANNEX_SEA_TOTAL_PACKAGES);

            param[7] = new SqlParameter("@ANNEX_SEA_LOOSE_PACKETS", ANNEX_SEA_LOOSE_PACKETS);

            param[8] = new SqlParameter("@ANNEX_SEA_NO_CONTAINERS", ANNEX_SEA_NO_CONTAINERS);

            param[9] = new SqlParameter("@ANNEX_SEA_GROSS_WEIGHT", ANNEX_SEA_GROSS_WEIGHT);

            param[10] = new SqlParameter("@ANNEX_SEA_NET_WEIGHT", ANNEX_SEA_NET_WEIGHT);

            param[11] = new SqlParameter("@ANNEX_SEA_UNIT_MEASUREMENT", ANNEX_SEA_UNIT_MEASUREMENT);

            param[12] = new SqlParameter("@ANNEX_SEA_ROTATION_NO", ANNEX_SEA_ROTATION_NO);

            param[13] = new SqlParameter("@ANNEX_SEA_ROTATION_DATE", DateTime.Parse(ANNEX_SEA_ROTATION_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            param[14] = new SqlParameter("ANNEX_SEA_FOB_VALUE", ANNEX_SEA_FOB_VALUE);

            param[15] = new SqlParameter("@USER_ID", USER_ID);

            param[16] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);

            param[17] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

            param[22] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);

            param[23] = new SqlParameter("@ANNEX_SEA_SEAL_TYPE", ANNEX_SEA_SEAL_TYPE);

            param[24] = new SqlParameter("@ANNEX_SEA_FACTORY_ADD", ANNEX_SEA_FACTORY_ADD);

            param[25] = new SqlParameter("@ANNEX_SEA_VOYAGENO", ANNEX_SEA_VOYAGENO);

            param[26] = new SqlParameter("@ANNEX_SEA_VESSELNO", ANNEX_SEA_VESSELNO);

            param[27] = new SqlParameter("@ANNEX_SEA_VESSEL_DATE", ANNEX_SEA_VESSEL_DATE);

            param[28] = new SqlParameter("@ANNEX_SEA_PKG_UNIT_CODE", ANNEX_SEA_PKG_UNIT_CODE);

            param[29] = new SqlParameter("@JOBNO_PS", JOBNO_PS);

            param[18] = new SqlParameter("@YEAR", YEAR);

            param[19] = new SqlParameter("@Mflag", flag);

            param[20] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[20].Direction = ParameterDirection.Output;

            param[21] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[21].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_ANNEXURE_C_SEA_DETAILS_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[20].Value.ToString());
            string err = param[21].Value.ToString();

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

    public DataSet RetrieveAll_Annexure_C_Sea_Details()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];

            //param[0] = new SqlParameter("@ANNEX_ID", ANNEX_ID);

            param[1] = new SqlParameter("@ANNEX_SEA_JOBNO", ANNEX_SEA_JOBNO);
            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;


            if (Ename == "delete")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_ANNEXURE_C_SEA_DETAILS", param);
                result = Convert.ToInt32(param[4].Value.ToString());
            }
            else if (Ename == "select" || Ename == "Update_Container_Count")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_ANNEXURE_C_SEA_DETAILS", param);

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