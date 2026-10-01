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
/// Summary description for Annexure
/// </summary>
public class Annexure
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

    private string _ANNEX_ADDRESS1;
    private string _ANNEX_ADDRESS2;
    private string _ANNEX_ADDRESS3;
    private string _ANNEX_ADDRESS4;
    private string _ANNEX_ID;
    private string _ANNEX_JOBNO;
    private string _ANNEX_EXPORTERNAME;
    private string _ANNEX_IECCODE;
    private string _ANNEX_BR_SLNO;
    private string _ANNEX_EXAM_DATE;
    private string _ANNEX_EXAM_OFFICER;
    private string _ANNEX_EXAM_DESIGN;
    private string _ANNEX_SUPER_NAME;
    private string _ANNEX_SUPER_DESIGN;
    private string _ANNEX_COMMISSION_RATE;
    private string _ANNEX_DIVISION;
    private string _ANNEX_RANGE;
    private string _ANNEX_VERIFIED_EXAM_OFFICER;
    private string _ANNEX_SAMPLE_DRAWN;
    private string _ANNEX_SEAL_NO;


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



    #endregion

    # region Public Attributes
    public string ANNEX_ADDRESS1 { get { return _ANNEX_ADDRESS1; } set { _ANNEX_ADDRESS1 = value; } }
    public string ANNEX_ADDRESS2 { get { return _ANNEX_ADDRESS2; } set { _ANNEX_ADDRESS2 = value; } }
    public string ANNEX_ADDRESS3 { get { return _ANNEX_ADDRESS3; } set { _ANNEX_ADDRESS3 = value; } }
    public string ANNEX_ADDRESS4 { get { return _ANNEX_ADDRESS4; } set { _ANNEX_ADDRESS4 = value; } }
    public string ANNEX_ID { get { return _ANNEX_ID; } set { _ANNEX_ID = value; } }
    public string ANNEX_JOBNO { get { return _ANNEX_JOBNO; } set { _ANNEX_JOBNO = value; } }
    public string ANNEX_EXPORTERNAME { get { return _ANNEX_EXPORTERNAME; } set { _ANNEX_EXPORTERNAME = value; } }

    public string ANNEX_IECCODE { get { return _ANNEX_IECCODE; } set { _ANNEX_IECCODE = value; } }
    public string ANNEX_BR_SLNO { get { return _ANNEX_BR_SLNO; } set { _ANNEX_BR_SLNO = value; } }
    public string ANNEX_EXAM_DATE { get { return _ANNEX_EXAM_DATE; } set { _ANNEX_EXAM_DATE = value; } }
    public string ANNEX_EXAM_OFFICER { get { return _ANNEX_EXAM_OFFICER; } set { _ANNEX_EXAM_OFFICER = value; } }
    public string ANNEX_EXAM_DESIGN { get { return _ANNEX_EXAM_DESIGN; } set { _ANNEX_EXAM_DESIGN = value; } }
    public string ANNEX_SUPER_NAME { get { return _ANNEX_SUPER_NAME; } set { _ANNEX_SUPER_NAME = value; } }
    public string ANNEX_SUPER_DESIGN { get { return _ANNEX_SUPER_DESIGN; } set { _ANNEX_SUPER_DESIGN = value; } }
    public string ANNEX_COMMISSION_RATE { get { return _ANNEX_COMMISSION_RATE; } set { _ANNEX_COMMISSION_RATE = value; } }
    public string ANNEX_DIVISION { get { return _ANNEX_DIVISION; } set { _ANNEX_DIVISION = value; } }
    public string ANNEX_RANGE { get { return _ANNEX_RANGE; } set { _ANNEX_RANGE = value; } }
    public string ANNEX_VERIFIED_EXAM_OFFICER { get { return _ANNEX_VERIFIED_EXAM_OFFICER; } set { _ANNEX_VERIFIED_EXAM_OFFICER = value; } }
    public string ANNEX_SAMPLE_DRAWN { get { return _ANNEX_SAMPLE_DRAWN; } set { _ANNEX_SAMPLE_DRAWN = value; } }
    public string ANNEX_SEAL_NO { get { return _ANNEX_SEAL_NO; } set { _ANNEX_SEAL_NO = value; } }
    
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

    #endregion

    #region Insert & Update

    public int Annexure_details_insertupdate()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[50];

            // param[0] = new SqlParameter("@ANNEX_ID", ANNEX_ID);

            param[1] = new SqlParameter("@ANNEX_JOBNO", ANNEX_JOBNO);

            param[2] = new SqlParameter("@ANNEX_IECCODE", ANNEX_IECCODE);

            param[3] = new SqlParameter("@ANNEX_BR_SLNO", ANNEX_BR_SLNO);

            param[4] = new SqlParameter("@ANNEX_EXAM_DATE", DateTime.Parse(ANNEX_EXAM_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            param[5] = new SqlParameter("@ANNEX_EXAM_OFFICER", ANNEX_EXAM_OFFICER);

            param[6] = new SqlParameter("@ANNEX_EXAM_DESIGN", ANNEX_EXAM_DESIGN);

            param[7] = new SqlParameter("@ANNEX_SUPER_NAME", ANNEX_SUPER_NAME);

            param[8] = new SqlParameter("@ANNEX_SUPER_DESIGN", ANNEX_SUPER_DESIGN);

            param[9] = new SqlParameter("@ANNEX_COMMISSION_RATE", ANNEX_COMMISSION_RATE);

            param[10] = new SqlParameter("@ANNEX_DIVISION", ANNEX_DIVISION);

            param[11] = new SqlParameter("@ANNEX_RANGE", ANNEX_RANGE);

            param[12] = new SqlParameter("@ANNEX_VERIFIED_EXAM_OFFICER", ANNEX_VERIFIED_EXAM_OFFICER);

            param[13] = new SqlParameter("@ANNEX_SAMPLE_DRAWN", ANNEX_SAMPLE_DRAWN);

            param[14] = new SqlParameter("ANNEX_SEAL_NO", ANNEX_SEAL_NO);

            param[15] = new SqlParameter("@USER_ID", USER_ID);

            param[16] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);

            param[17] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

            param[27] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);

            param[18] = new SqlParameter("@YEAR", YEAR);

            param[19] = new SqlParameter("@Mflag", flag);

            param[20] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[20].Direction = ParameterDirection.Output;

            param[21] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);

            param[21].Direction = ParameterDirection.Output;
            param[22] = new SqlParameter("@ANNEX_EXPORTERNAME", ANNEX_EXPORTERNAME);
            param[23] = new SqlParameter("@ANNEX_ADDRESS1", ANNEX_ADDRESS1);
            param[24] = new SqlParameter("@ANNEX_ADDRESS2", ANNEX_ADDRESS2);
            param[25] = new SqlParameter("@ANNEX_ADDRESS3", ANNEX_ADDRESS3);
            param[26] = new SqlParameter("@ANNEX_ADDRESS4", ANNEX_ADDRESS4);

            SqlHelper.ExecuteNonQuery(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_ANNEXURE_C1_DETAILS_INSERT_UPDATE", param);

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


    public DataSet RetrieveAll_Annexure_Details()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[10];

            //param[0] = new SqlParameter("@ANNEX_ID", ANNEX_ID);

            param[1] = new SqlParameter("@ANNEX_JOBNO", ANNEX_JOBNO);

            param[2] = new SqlParameter("@name", Ename);

            param[3] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);


            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;
         

            if (Ename == "delete")
            {
                //SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH", param);
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_ANNEXURE_C1_DETAILS", param);

                result = Convert.ToInt32(param[4].Value.ToString());


            }
            else if (Ename == "select")
            {

                //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH", param);
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_ANNEXURE_C1_DETAILS", param);

                string err = param[5].Value.ToString();
                //result = Convert.ToInt32(param[11].Value.ToString());
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