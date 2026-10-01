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
/// Summary description for Goods_Reg_Package
/// </summary>
public class Goods_Reg_Package
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

    private string _GOODS_PACK_ID;
    private string _GOODS_PACK_JOBNO;
    private string _GOODS_PACK_GROUP;
    private string _GOODS_PACK_FROM;
    private string _GOODS_PACK_TO;
    private string _GOODS_PACK_PACKAGETYPE;
    private string _GOODS_PACK_MODE;
    private string _GOODS_PACK_FROM_DESC;
    private string _GOODS_PACK_TO_DESC;

    private string _max_packages;

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

    public string GOODS_PACK_ID { get { return _GOODS_PACK_ID; } set { _GOODS_PACK_ID = value; } }
    public string GOODS_PACK_JOBNO { get { return _GOODS_PACK_JOBNO; } set { _GOODS_PACK_JOBNO = value; } }
    public string GOODS_PACK_GROUP { get { return _GOODS_PACK_GROUP; } set { _GOODS_PACK_GROUP = value; } }
    public string GOODS_PACK_FROM { get { return _GOODS_PACK_FROM; } set { _GOODS_PACK_FROM = value; } }
    public string GOODS_PACK_TO { get { return _GOODS_PACK_TO; } set { _GOODS_PACK_TO = value; } }
    public string GOODS_PACK_PACKAGETYPE { get { return _GOODS_PACK_PACKAGETYPE; } set { _GOODS_PACK_PACKAGETYPE = value; } }
    public string GOODS_PACK_MODE { get { return _GOODS_PACK_MODE; } set { _GOODS_PACK_MODE = value; } }
    public string GOODS_PACK_FROM_DESC { get { return _GOODS_PACK_FROM_DESC; } set { _GOODS_PACK_FROM_DESC = value; } }
    public string GOODS_PACK_TO_DESC { get { return _GOODS_PACK_TO_DESC; } set { _GOODS_PACK_TO_DESC = value; } }

    public string max_packages { get { return _max_packages; } set { _max_packages = value; } }
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

    public DataSet Goods_Package_details_insertupdate()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[50];

            param[0] = new SqlParameter("@GOODS_PACK_ID", GOODS_PACK_ID);

            param[1] = new SqlParameter("@GOODS_PACK_JOBNO", GOODS_PACK_JOBNO);

            param[2] = new SqlParameter("@GOODS_PACK_GROUP", GOODS_PACK_GROUP);

            param[3] = new SqlParameter("@GOODS_PACK_FROM", GOODS_PACK_FROM);

            param[4] = new SqlParameter("@GOODS_PACK_TO", GOODS_PACK_TO);

            param[5] = new SqlParameter("@GOODS_PACK_PACKAGETYPE", GOODS_PACK_PACKAGETYPE);

            param[6] = new SqlParameter("@GOODS_PACK_MODE", GOODS_PACK_MODE);

            param[20] = new SqlParameter("@GOODS_PACK_FROM_DESC", GOODS_PACK_FROM_DESC);

            param[21] = new SqlParameter("@GOODS_PACK_TO_DESC", GOODS_PACK_TO_DESC);

            param[7] = new SqlParameter("@USER_ID", USER_ID);

            param[8] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);

            param[9] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

            param[15] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);

            param[10] = new SqlParameter("@YEAR", YEAR);

            param[11] = new SqlParameter("@Mflag", flag);

            param[12] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[12].Direction = ParameterDirection.Output;

            param[13] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);

            param[13].Direction = ParameterDirection.Output;
         
            param[14] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[14].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_GOODS_REG_PACKAGE_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[12].Value.ToString());
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[14].Value.ToString());
            string err = param[13].Value.ToString();
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

    public DataSet Retrieve_Air_GroupNo()
    {

        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@GOODS_REG_PACK_JOBNO", GOODS_PACK_JOBNO);

            param[1] = new SqlParameter("@Working_Period", WORKING_PERIOD);


            param[2] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[2].Direction = ParameterDirection.Output;

            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3].Direction = ParameterDirection.Output;


            param[4] = new SqlParameter("@MAX_PACKAGE", SqlDbType.NVarChar, 1000);

            param[4].Direction = ParameterDirection.Output;

            //SqlHelper.ExecuteNonQuery(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_ANNEXURE_C_SEA_PACKAGE_DETAILS_AUTOID", param);
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_GOODS_REG_AIR_PACKAGE_DETAILS_AUTOID", param);


            result = Convert.ToInt32(param[2].Value.ToString());
            max_packages = param[4].Value.ToString();
            if (max_packages == "")
                max_packages = "0";
            string err = param[3].Value.ToString();

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
            er.makeLog(ex.Message);
        }
        finally
        {

        }
        return ds;
    }

    public DataSet Retrieve_Sea_GroupNo()
    {

        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@GOODS_REG_PACK_JOBNO", GOODS_PACK_JOBNO);

            param[1] = new SqlParameter("@Working_Period", WORKING_PERIOD);


            param[2] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[2].Direction = ParameterDirection.Output;

            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3].Direction = ParameterDirection.Output;


            param[4] = new SqlParameter("@MAX_PACKAGE", SqlDbType.NVarChar, 1000);

            param[4].Direction = ParameterDirection.Output;

            //SqlHelper.ExecuteNonQuery(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_ANNEXURE_C_SEA_PACKAGE_DETAILS_AUTOID", param);
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_GOODS_REG_SEA_PACKAGE_DETAILS_AUTOID", param);


            result = Convert.ToInt32(param[2].Value.ToString());
            max_packages = param[4].Value.ToString();
            if (max_packages == "")
                max_packages = "0";
            string err = param[3].Value.ToString();

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
            er.makeLog(ex.Message);
        }
        finally
        {

        }
        return ds;
    }

    public DataSet RetrieveAll_Export_Goods_Reg_Air_Sea_Package_Details()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@GOODS_REG_PACK_ID", GOODS_PACK_ID);

            param[1] = new SqlParameter("@GOODS_REG_JOBNO", GOODS_PACK_JOBNO);

            param[2] = new SqlParameter("@name", Ename);

            param[3] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[6] = new SqlParameter("@GOODS_PACK_MODE", GOODS_PACK_MODE);


            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;


            if (Ename == "delete")
            {
                //SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH", param);
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_GOODS_REG_AIR_SEA_PACKAGE_DETAILS", param);

                result = Convert.ToInt32(param[4].Value.ToString());


            }
            else if (Ename == "select")
            {

                //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH", param);
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_GOODS_REG_AIR_SEA_PACKAGE_DETAILS", param);

                string err = param[5].Value.ToString();
                //result = Convert.ToInt32(param[11].Value.ToString());

                //string err = param[8].Value.ToString();
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