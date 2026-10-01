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
/// Summary description for Goods_Reg_Sea_Container_Package
/// </summary>
public class Goods_Reg_Sea_Container_Package
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

    private string _GOODS_SEA_CON_ID;
    private string _GOODS_SEA_CON_JOBNO;
    private string _GOODS_SEA_CON_EQMT_SERIAL_NO;
    private string _GOODS_SEA_CON_EQMT_TYPE;
    private string _GOODS_SEA_CON_EQMT_ID;
    private string _GOODS_SEA_CON_EQMT_LOC;
    private string _GOODS_SEA_CON_PCKG_FROM;
    private string _GOODS_SEA_CON_PCKG_TO;
    private string _GOODS_SEA_CON_PCKG_COUNT;
    private string _GOODS_SEA_CON_PCKG_UQC;


    //--DOCUMENT TABLE
    private string _GOODS_DOCS_ID;
    private string _GOODS_DOCS_JOBNO;
    private string _MODE;
    private string _GOODS_DOCS_SERIAL_NO;
    private string _GOODS_DOCS_NAME;


    private string _flag;
    private string _USER_ID;
    private string _BRANCH_CODE;
    private string _YEAR;
    private string _WORKING_PERIOD;
    private string _BRANCH_COMMON;
    private string _MODIFIED_BY;
    private string _MODIFIED_ON;

    private string _Ename;

    private string _startRowIndex;

    private string _maximumRows;
    private string _totalRows;

    #endregion

    # region Public Attributes

    public string GOODS_SEA_CON_ID { get { return _GOODS_SEA_CON_ID; } set { _GOODS_SEA_CON_ID = value; } }
    public string GOODS_SEA_CON_JOBNO { get { return _GOODS_SEA_CON_JOBNO; } set { _GOODS_SEA_CON_JOBNO = value; } }
    public string GOODS_SEA_CON_EQMT_SERIAL_NO { get { return _GOODS_SEA_CON_EQMT_SERIAL_NO; } set { _GOODS_SEA_CON_EQMT_SERIAL_NO = value; } }
    public string GOODS_SEA_CON_EQMT_TYPE { get { return _GOODS_SEA_CON_EQMT_TYPE; } set { _GOODS_SEA_CON_EQMT_TYPE = value; } }
    public string GOODS_SEA_CON_EQMT_ID { get { return _GOODS_SEA_CON_EQMT_ID; } set { _GOODS_SEA_CON_EQMT_ID = value; } }
    public string GOODS_SEA_CON_EQMT_LOC { get { return _GOODS_SEA_CON_EQMT_LOC; } set { _GOODS_SEA_CON_EQMT_LOC = value; } }

    public string GOODS_SEA_CON_PCKG_FROM { get { return _GOODS_SEA_CON_PCKG_FROM; } set { _GOODS_SEA_CON_PCKG_FROM = value; } }
    public string GOODS_SEA_CON_PCKG_TO { get { return _GOODS_SEA_CON_PCKG_TO; } set { _GOODS_SEA_CON_PCKG_TO = value; } }
    public string GOODS_SEA_CON_PCKG_COUNT { get { return _GOODS_SEA_CON_PCKG_COUNT; } set { _GOODS_SEA_CON_PCKG_COUNT = value; } }
    public string GOODS_SEA_CON_PCKG_UQC { get { return _GOODS_SEA_CON_PCKG_UQC; } set { _GOODS_SEA_CON_PCKG_UQC = value; } }

    public string GOODS_DOCS_ID { get { return _GOODS_DOCS_ID; } set { _GOODS_DOCS_ID = value; } }
    public string GOODS_DOCS_JOBNO { get { return _GOODS_DOCS_JOBNO; } set { _GOODS_DOCS_JOBNO = value; } }
    public string MODE { get { return _MODE; } set { _MODE = value; } }
    public string GOODS_DOCS_SERIAL_NO { get { return _GOODS_DOCS_SERIAL_NO; } set { _GOODS_DOCS_SERIAL_NO = value; } }
    public string GOODS_DOCS_NAME { get { return _GOODS_DOCS_NAME; } set { _GOODS_DOCS_NAME = value; } }


    public string flag { get { return _flag; } set { _flag = value; } }
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }
    public string BRANCH_COMMON { get { return _BRANCH_COMMON; } set { _BRANCH_COMMON = value; } }
    public string MODIFIED_BY { get { return _MODIFIED_BY; } set { _MODIFIED_BY = value; } }
    public string MODIFIED_ON { get { return _MODIFIED_ON; } set { _MODIFIED_ON = value; } }


    public string Ename { get { return _Ename; } set { _Ename = value; } }

    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string totalRows { get { return _totalRows; } set { _totalRows = value; } }

    #endregion

    public DataSet Goods_Reg_Sea_Container_details_insertupdate()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[50];

            param[0] = new SqlParameter("@GOODS_SEA_CON_ID", GOODS_SEA_CON_ID);
            param[1] = new SqlParameter("@GOODS_SEA_CON_JOBNO", GOODS_SEA_CON_JOBNO);
            param[2] = new SqlParameter("@GOODS_SEA_CON_EQMT_SERIAL_NO", GOODS_SEA_CON_EQMT_SERIAL_NO);
            param[3] = new SqlParameter("@GOODS_SEA_CON_EQMT_TYPE", GOODS_SEA_CON_EQMT_TYPE);
            param[4] = new SqlParameter("@GOODS_SEA_CON_EQMT_ID", GOODS_SEA_CON_EQMT_ID);
            param[5] = new SqlParameter("@GOODS_SEA_CON_EQMT_LOC", GOODS_SEA_CON_EQMT_LOC);
            param[6] = new SqlParameter("@GOODS_SEA_CON_PCKG_FROM", GOODS_SEA_CON_PCKG_FROM);
            param[7] = new SqlParameter("@GOODS_SEA_CON_PCKG_TO", GOODS_SEA_CON_PCKG_TO);
            param[8] = new SqlParameter("@GOODS_SEA_CON_PCKG_COUNT", GOODS_SEA_CON_PCKG_COUNT);
            param[9] = new SqlParameter("@GOODS_SEA_CON_PCKG_UQC", GOODS_SEA_CON_PCKG_UQC);

            param[10] = new SqlParameter("@USER_ID", USER_ID);
            param[11] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[12] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[13] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
            param[14] = new SqlParameter("@YEAR", YEAR);
            param[15] = new SqlParameter("@Mflag", flag);
            param[16] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[16].Direction = ParameterDirection.Output;
            param[17] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[17].Direction = ParameterDirection.Output;
            param[18] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[18].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_GOODS_REG_SEA_CONTAINER_PACKAGE_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[16].Value.ToString());
            string err = param[17].Value.ToString();
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[18].Value.ToString());

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

    public DataSet RetrieveAll_GoodsReg_Container_Package_Details()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@GOODS_SEA_CON_ID", GOODS_SEA_CON_ID);
            param[1] = new SqlParameter("@GOODS_SEA_CON_JOBNO", GOODS_SEA_CON_JOBNO);
            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            if (Ename == "delete")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_GOODS_REG_SEA_CONTAINER_PACKAGE_DETAILS", param);
                result = Convert.ToInt32(param[4].Value.ToString());
            }
            else if (Ename == "select")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_GOODS_REG_SEA_CONTAINER_PACKAGE_DETAILS", param);
                string err = param[5].Value.ToString();
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



    //---------------------------- DOCUMENT DETAILS-----------------------------------------

    public DataSet Goods_Reg_DOCUMNET_details_InsertUpdate()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[50];

            param[0] = new SqlParameter("@GOODS_DOCS_ID", GOODS_DOCS_ID);
            param[1] = new SqlParameter("@GOODS_DOCS_JOBNO", GOODS_DOCS_JOBNO);
            param[2] = new SqlParameter("@MODE", MODE);
            param[3] = new SqlParameter("@GOODS_DOCS_SERIAL_NO", GOODS_DOCS_SERIAL_NO);
            param[4] = new SqlParameter("@GOODS_DOCS_NAME", GOODS_DOCS_NAME);


            param[10] = new SqlParameter("@USER_ID", USER_ID);
            param[11] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[12] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[13] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
            param[14] = new SqlParameter("@YEAR", YEAR);
            param[15] = new SqlParameter("@Mflag", flag);
            param[16] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[16].Direction = ParameterDirection.Output;
            param[17] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[17].Direction = ParameterDirection.Output;
            param[18] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[18].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_GOODS_REG_DOCS_INSERT_UPDATE", param);
            
            if (!String.IsNullOrEmpty(param[16].Value.ToString()))
            {
                result = Convert.ToInt32(param[16].Value.ToString());
            }
            string err = param[17].Value.ToString();
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[18].Value.ToString());

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



    public DataSet RetrieveAll_GoodsReg_DOCUMNET_Details()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@GOODS_DOCS_ID", GOODS_DOCS_ID);
            param[1] = new SqlParameter("@GOODS_DOCS_JOBNO", GOODS_DOCS_JOBNO);
            param[2] = new SqlParameter("@MODE", MODE);

            param[3] = new SqlParameter("@name", Ename);
            param[4] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

            param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;

            if (Ename == "delete")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_GOODS_REG_DOCS_DETAILS", param);
                result = Convert.ToInt32(param[5].Value.ToString());
            }
            else if (Ename == "select")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_GOODS_REG_DOCS_DETAILS", param);
                string err = param[6].Value.ToString();
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