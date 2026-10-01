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
/// Summary description for Goods_Reg_Ar4
/// </summary>
public class Goods_Reg_Ar4
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
    public int result, Update_id;

    # region Private Attributes

    private string _GOODS_AR4_ID;
    private string _GOODS_AR4_JOBNO;
    private string _GOODS_AR4_NO;
    private string _GOODS_AR4_DATE;
    private string _GOODS_AR4_COMMISSION_RATE;
    private string _GOODS_AR4_DIVISION;
    private string _GOODS_AR4_RANGE;
    private string _GOODS_AR4_REMARKS;
   
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

    public string GOODS_AR4_ID { get { return _GOODS_AR4_ID; } set { _GOODS_AR4_ID = value; } }
    public string GOODS_AR4_JOBNO { get { return _GOODS_AR4_JOBNO; } set { _GOODS_AR4_JOBNO = value; } }
    public string GOODS_AR4_NO { get { return _GOODS_AR4_NO; } set { _GOODS_AR4_NO = value; } }
    public string GOODS_AR4_DATE { get { return _GOODS_AR4_DATE; } set { _GOODS_AR4_DATE = value; } }
    public string GOODS_AR4_COMMISSION_RATE { get { return _GOODS_AR4_COMMISSION_RATE; } set { _GOODS_AR4_COMMISSION_RATE = value; } }

    public string GOODS_AR4_DIVISION { get { return _GOODS_AR4_DIVISION; } set { _GOODS_AR4_DIVISION = value; } }
    public string GOODS_AR4_RANGE { get { return _GOODS_AR4_RANGE; } set { _GOODS_AR4_RANGE = value; } }
    public string GOODS_AR4_REMARKS { get { return _GOODS_AR4_REMARKS; } set { _GOODS_AR4_REMARKS = value; } }

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

    public DataSet Goods_Reg_Ar4_details_insertupdate()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[50];

            param[0] = new SqlParameter("@GOODS_AR4_ID", GOODS_AR4_ID);

            param[1] = new SqlParameter("@GOODS_AR4_JOBNO", GOODS_AR4_JOBNO);

            param[2] = new SqlParameter("@GOODS_AR4_NO", GOODS_AR4_NO);

            param[3] = new SqlParameter("@GOODS_AR4_DATE", DateTime.Parse(GOODS_AR4_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            param[4] = new SqlParameter("@GOODS_AR4_COMMISSION_RATE", GOODS_AR4_COMMISSION_RATE);

            param[5] = new SqlParameter("@GOODS_AR4_DIVISION", GOODS_AR4_DIVISION);

            param[6] = new SqlParameter("@GOODS_AR4_RANGE", GOODS_AR4_RANGE);

            param[7] = new SqlParameter("@GOODS_AR4_REMARKS", GOODS_AR4_REMARKS);

            param[8] = new SqlParameter("@USER_ID", USER_ID);

            param[9] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);

            param[10] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

            param[16] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);

            param[11] = new SqlParameter("@YEAR", YEAR);

            param[12] = new SqlParameter("@Mflag", flag);

            param[13] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[13].Direction = ParameterDirection.Output;

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);

            param[14].Direction = ParameterDirection.Output;
            param[15] = new SqlParameter("@Update_id", SqlDbType.NVarChar, 1000);

            param[15].Direction = ParameterDirection.Output;

            ds=SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_GOODS_REG_AR4_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[13].Value.ToString());
            Update_id = Convert.ToInt32(param[15].Value.ToString());
            string err = param[14].Value.ToString();
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
    public DataSet RetrieveAll_Annexure_Details()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@GOODS_AR4_ID", GOODS_AR4_ID);

            param[1] = new SqlParameter("@GOODS_AR4_JOBNO", GOODS_AR4_JOBNO);

            param[2] = new SqlParameter("@name", Ename);

            param[3] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);


            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;


            if (Ename == "delete")
            {
                //SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH", param);
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_GOODS_REG_AR4_DETAILS", param);

                result = Convert.ToInt32(param[4].Value.ToString());


            }
            else if (Ename == "select")
            {

                //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH", param);
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_GOODS_REG_AR4_DETAILS", param);

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