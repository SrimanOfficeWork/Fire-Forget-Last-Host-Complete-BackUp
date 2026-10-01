using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Net;


/// <summary>
/// Summary description for Supplier_Master
/// </summary>
public class Supplier_Master
{
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    DataSet dtuser = new DataSet();
    DataTable dt = new DataTable();
    ErrorLogs er = new ErrorLogs();
    SqlDataReader dr;
    SqlCommand cmd;
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);
    private string _startRowIndex;
    private string _maximumRows;
    private string _totalRows;

    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string totalRows { get { return _totalRows; } set { _totalRows = value; } }
    public int result = 0;

    #region private Attributes

    private string _SUP_ID;
    private string _SUP_NAME;
    private string _SUP_ADD1;
    private string _SUP_ADD2;
    private string _SUP_ADD3;
    private string _SUP_COUNTRY_NAME;
    private string _SUP_COUNTRY_CODE;
    private string _SUP_PIN_CODE;
    private string _SUP_REMARKS;

    private string _flag;
    private string _USER_ID;
    private string _BRANCH_CODE;
    private string _YEAR;
    private string _EWorking_Period;

    private string _Esupid;
    private string _Esup_name;
    private string _Ename;

    #endregion

    #region Public Attributes

    public string SUP_ID { get { return _SUP_ID; } set { _SUP_ID = value; } }
    public string SUP_NAME { get { return _SUP_NAME; } set { _SUP_NAME = value; } }
    public string SUP_ADD1 { get { return _SUP_ADD1; } set { _SUP_ADD1 = value; } }
    public string SUP_ADD2 { get { return _SUP_ADD2; } set { _SUP_ADD2 = value; } }
    public string SUP_ADD3 { get { return _SUP_ADD3; } set { _SUP_ADD3 = value; } }
    public string SUP_COUNTRY_NAME { get { return _SUP_COUNTRY_NAME; } set { _SUP_COUNTRY_NAME = value; } }
    public string SUP_COUNTRY_CODE { get { return _SUP_COUNTRY_CODE; } set { _SUP_COUNTRY_CODE = value; } }
    public string SUP_PIN_CODE { get { return _SUP_PIN_CODE; } set { _SUP_PIN_CODE = value; } }
    public string SUP_REMARKS { get { return _SUP_REMARKS; } set { _SUP_REMARKS = value; } }

    public string flag { get { return _flag; } set { _flag = value; } }
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string EWorking_Period { get { return _EWorking_Period; } set { _EWorking_Period = value; } }

    #endregion

    #region Retrieve Attributes

    public string Esupid { get { return _Esupid; } set { _Esupid = value; } }
    public string Esup_name { get { return _Esup_name; } set { _Esup_name = value; } }
    public string Ename { get { return _Ename; } set { _Ename = value; } }
   
    #endregion

    #region Insert & Update

    public int Supplier_Master_Insert_update()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[20];

            param[0] = new SqlParameter("@SUP_ID", SUP_ID);
            param[1] = new SqlParameter("@SUP_NAME", SUP_NAME);

            param[2] = new SqlParameter("@SUP_ADD1", SUP_ADD1);
            param[3] = new SqlParameter("@SUP_ADD2", SUP_ADD2);
            param[4] = new SqlParameter("@SUP_ADD3", SUP_ADD3);
            param[5] = new SqlParameter("@SUP_COUNTRY_NAME", SUP_COUNTRY_NAME);
            param[6] = new SqlParameter("@SUP_COUNTRY_CODE", SUP_COUNTRY_CODE);
            param[7] = new SqlParameter("@SUP_PIN_CODE", SUP_PIN_CODE);
            param[8] = new SqlParameter("@SUP_REMARKS", SUP_REMARKS);

            param[9] = new SqlParameter("@SUP_USER_ID", USER_ID);
            param[10] = new SqlParameter("@SUP_BRANCH_CODE", BRANCH_CODE);
            param[11] = new SqlParameter("@SUP_YEAR", YEAR);
            param[12] = new SqlParameter("@SUP_WORKING_PERIOD", EWorking_Period);
            param[13] = new SqlParameter("@Mflag", flag);



            param[14] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[14].Direction = ParameterDirection.Output;

            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;


            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_SUPPLIER_MASTER_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[14].Value.ToString());



        }
        catch (Exception ex)
        {

            er.makeLog(ex.Message);
        }


        return result;

    }

    #endregion

    #region Retrieve Record

    public DataSet RetrieveAll_Supplier_MASTER()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@SUP_ID", Esupid);
            param[1] = new SqlParameter("@Working_Period", EWorking_Period);

            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@SUP_NAME", Esup_name);


            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[4].Direction = ParameterDirection.Output;

            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@startRowIndex", startRowIndex);

            param[7] = new SqlParameter("@maximumRows", maximumRows);

            param[8] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;
            if (Ename == "delete")
            {
                //SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_SUPPLIERMASTER", param);
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_SUPPLIERMASTER_SEARCH_SELECT", param);

                result = Convert.ToInt32(param[4].Value.ToString());


            }
            else
            {
                //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_SUPPLIERMASTER", param);
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_SUPPLIERMASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[8].Value.ToString());

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
        }
        catch (Exception ex)
        {

            er.makeLog(ex.Message);
        }


        return ds;

    }

    #endregion
}