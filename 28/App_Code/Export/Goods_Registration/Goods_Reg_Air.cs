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
/// Summary description for Goods_Reg_Air
/// </summary>
public class Goods_Reg_Air
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

    private string _GOODS_AIR_ID;
    private string _GOODS_AIR_JOBNO;
    private string _GOODS_AIR_SB_NO;
    private string _GOODS_AIR_SB_DATE;
    private string _GOODS_AIR_SEAL_TYPE;
    private string _GOODS_AIR_NATURE_OF_CARGO;
    private string _GOODS_AIR_GROSS_WEIGHT;
    private string _GOODS_AIR_NET_WEIGHT;
    private string _GOODS_AIR_UNIT_MESUR;
    private string _GOODS_AIR_TOTAL_PACKAGES;
    private string _GOODS_AIR_MARKS_NOS;
    private string _GOODS_AIR_MAWB_NO;
    private string _GOODS_AIR_MAWB_DATE;
    private string _GOODS_AIR_HAWB_NO;
    private string _GOODS_AIR_HAWB_DATE;

    //-----NEW FIELDS ADD-----

    private string _GOODS_AIR_NO_LOOSE_PKTS;
    private string _GOODS_AIR_TRANSHIPPER_CODE;
    private string _GOODS_AIR_GATEWAY_PORT;
    private string _GOODS_AIR_WAREHOUSECODE;
    //------------------------
  
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

    public string GOODS_AIR_ID { get { return _GOODS_AIR_ID; } set { _GOODS_AIR_ID = value; } }
    public string GOODS_AIR_JOBNO { get { return _GOODS_AIR_JOBNO; } set { _GOODS_AIR_JOBNO = value; } }
    public string GOODS_AIR_SB_NO { get { return _GOODS_AIR_SB_NO; } set { _GOODS_AIR_SB_NO = value; } }
    public string GOODS_AIR_SB_DATE { get { return _GOODS_AIR_SB_DATE; } set { _GOODS_AIR_SB_DATE = value; } }
    public string GOODS_AIR_SEAL_TYPE { get { return _GOODS_AIR_SEAL_TYPE; } set { _GOODS_AIR_SEAL_TYPE = value; } }
    public string GOODS_AIR_NATURE_OF_CARGO { get { return _GOODS_AIR_NATURE_OF_CARGO; } set { _GOODS_AIR_NATURE_OF_CARGO = value; } }
    public string GOODS_AIR_GROSS_WEIGHT { get { return _GOODS_AIR_GROSS_WEIGHT; } set { _GOODS_AIR_GROSS_WEIGHT = value; } }
    public string GOODS_AIR_NET_WEIGHT { get { return _GOODS_AIR_NET_WEIGHT; } set { _GOODS_AIR_NET_WEIGHT = value; } }
    public string GOODS_AIR_UNIT_MESUR { get { return _GOODS_AIR_UNIT_MESUR; } set { _GOODS_AIR_UNIT_MESUR = value; } }
    public string GOODS_AIR_TOTAL_PACKAGES { get { return _GOODS_AIR_TOTAL_PACKAGES; } set { _GOODS_AIR_TOTAL_PACKAGES = value; } }
    public string GOODS_AIR_MARKS_NOS { get { return _GOODS_AIR_MARKS_NOS; } set { _GOODS_AIR_MARKS_NOS = value; } }
    public string GOODS_AIR_MAWB_NO { get { return _GOODS_AIR_MAWB_NO; } set { _GOODS_AIR_MAWB_NO = value; } }
    public string GOODS_AIR_MAWB_DATE { get { return _GOODS_AIR_MAWB_DATE; } set { _GOODS_AIR_MAWB_DATE = value; } }
    public string GOODS_AIR_HAWB_NO { get { return _GOODS_AIR_HAWB_NO; } set { _GOODS_AIR_HAWB_NO = value; } }
    public string GOODS_AIR_HAWB_DATE { get { return _GOODS_AIR_HAWB_DATE; } set { _GOODS_AIR_HAWB_DATE = value; } }

    //-----NEW FIELDS ADD-----
    public string GOODS_AIR_NO_LOOSE_PKTS { get { return _GOODS_AIR_NO_LOOSE_PKTS; } set { _GOODS_AIR_NO_LOOSE_PKTS = value; } }
    public string GOODS_AIR_TRANSHIPPER_CODE { get { return _GOODS_AIR_TRANSHIPPER_CODE; } set { _GOODS_AIR_TRANSHIPPER_CODE = value; } }
    public string GOODS_AIR_GATEWAY_PORT { get { return _GOODS_AIR_GATEWAY_PORT; } set { _GOODS_AIR_GATEWAY_PORT = value; } }
    public string GOODS_AIR_WAREHOUSECODE { get { return _GOODS_AIR_WAREHOUSECODE; } set { _GOODS_AIR_WAREHOUSECODE = value; } }
    //-----------------------
   
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

    public int Goods_Reg_Air_details_insertupdate()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[50];

            // param[0] = new SqlParameter("@GOODS_AIR_ID", GOODS_AIR_ID);

            param[1] = new SqlParameter("@GOODS_AIR_JOBNO", GOODS_AIR_JOBNO);

            param[2] = new SqlParameter("@GOODS_AIR_SB_NO", GOODS_AIR_SB_NO);

            param[3] = new SqlParameter("@GOODS_AIR_SB_DATE", DateTime.Parse(GOODS_AIR_SB_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            param[4] = new SqlParameter("@GOODS_AIR_SEAL_TYPE", GOODS_AIR_SEAL_TYPE);

            param[5] = new SqlParameter("@GOODS_AIR_NATURE_OF_CARGO", GOODS_AIR_NATURE_OF_CARGO);

            param[6] = new SqlParameter("@GOODS_AIR_GROSS_WEIGHT", GOODS_AIR_GROSS_WEIGHT);

            param[7] = new SqlParameter("@GOODS_AIR_NET_WEIGHT", GOODS_AIR_NET_WEIGHT);

            param[8] = new SqlParameter("@GOODS_AIR_UNIT_MESUR", GOODS_AIR_UNIT_MESUR);

            param[9] = new SqlParameter("@GOODS_AIR_TOTAL_PACKAGES", GOODS_AIR_TOTAL_PACKAGES);

            param[10] = new SqlParameter("@GOODS_AIR_MARKS_NOS", GOODS_AIR_MARKS_NOS);

            param[11] = new SqlParameter("@GOODS_AIR_MAWB_NO", GOODS_AIR_MAWB_NO);

            param[12] = new SqlParameter("@GOODS_AIR_MAWB_DATE", DateTime.Parse(GOODS_AIR_MAWB_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            param[13] = new SqlParameter("@GOODS_AIR_HAWB_NO", GOODS_AIR_HAWB_NO);

            param[14] = new SqlParameter("GOODS_AIR_HAWB_DATE", DateTime.Parse(GOODS_AIR_HAWB_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            //NEW FIELDS ADD
            param[23] = new SqlParameter("@GOODS_AIR_NO_LOOSE_PKTS", GOODS_AIR_NO_LOOSE_PKTS);

            param[24] = new SqlParameter("@GOODS_AIR_TRANSHIPPER_CODE", GOODS_AIR_TRANSHIPPER_CODE);

            param[25] = new SqlParameter("@GOODS_AIR_GATEWAY_PORT", GOODS_AIR_GATEWAY_PORT);

            param[26] = new SqlParameter("@GOODS_AIR_WAREHOUSECODE", GOODS_AIR_WAREHOUSECODE);
                   

            param[15] = new SqlParameter("@USER_ID", USER_ID);

            param[16] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);

            param[17] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

            param[22] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
            

            param[18] = new SqlParameter("@YEAR", YEAR);

            param[19] = new SqlParameter("@Mflag", flag);

            param[20] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[20].Direction = ParameterDirection.Output;

            param[21] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);

            param[21].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_GOODS_REG_AIR_INSERT_UPDATE", param);

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

    public DataSet RetrieveAll_Goods_Reg_Air_Details()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[10];

            //param[0] = new SqlParameter("@ANNEX_ID", ANNEX_ID);

            param[1] = new SqlParameter("@Goods_Reg_AIR_JOBNO", GOODS_AIR_JOBNO);

            param[2] = new SqlParameter("@name", Ename);

            param[3] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);


            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;


            if (Ename == "delete")
            {
                //SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH", param);
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_GOODS_REG_AIR_DETAILS", param);

                result = Convert.ToInt32(param[4].Value.ToString());


            }
            else if (Ename == "select")
            {

                //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH", param);
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_GOODS_REG_AIR_DETAILS", param);

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