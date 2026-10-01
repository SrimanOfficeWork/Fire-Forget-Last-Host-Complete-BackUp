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
/// Summary description for Consignee_Master
/// </summary>
public class Consignee_Master
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

    private string _CONSIGNEE_ID;
    private string _CONSIGNEE_NAME;
    private string _CONSIGNEE_ADD1;
    private string _CONSIGNEE_ADD2;
    private string _CONSIGNEE_ADD3;
    private string _CONSIGNEE_COUNTRY_NAME;
    private string _CONSIGNEE_COUNTRY_CODE;
    private string _CONSIGNEE_PIN_CODE;
    private string _CONSIGNEE_REMARKS;

    private string _flag;
    private string _USER_ID;
    private string _BRANCH_CODE;
    private string _YEAR;
    private string _EWorking_Period;

    private string _Econsigneeid;
    private string _Econsignee_name;
    private string _Ename;
   

    #endregion

    #region Public Attributes

    public string CONSIGNEE_ID { get { return _CONSIGNEE_ID; } set { _CONSIGNEE_ID = value; } }
    public string CONSIGNEE_NAME { get { return _CONSIGNEE_NAME; } set { _CONSIGNEE_NAME = value; } }
    public string CONSIGNEE_ADD1 { get { return _CONSIGNEE_ADD1; } set { _CONSIGNEE_ADD1 = value; } }
    public string CONSIGNEE_ADD2 { get { return _CONSIGNEE_ADD2; } set { _CONSIGNEE_ADD2 = value; } }
    public string CONSIGNEE_ADD3 { get { return _CONSIGNEE_ADD3; } set { _CONSIGNEE_ADD3 = value; } }
    public string CONSIGNEE_COUNTRY_NAME { get { return _CONSIGNEE_COUNTRY_NAME; } set { _CONSIGNEE_COUNTRY_NAME = value; } }
    public string CONSIGNEE_COUNTRY_CODE { get { return _CONSIGNEE_COUNTRY_CODE; } set { _CONSIGNEE_COUNTRY_CODE = value; } }
    public string CONSIGNEE_PIN_CODE { get { return _CONSIGNEE_PIN_CODE; } set { _CONSIGNEE_PIN_CODE = value; } }
    public string CONSIGNEE_REMARKS { get { return _CONSIGNEE_REMARKS; } set { _CONSIGNEE_REMARKS = value; } }

    public string flag { get { return _flag; } set { _flag = value; } }
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string EWorking_Period { get { return _EWorking_Period; } set { _EWorking_Period = value; } }

    #endregion

    #region Retrieve Attributes

    public string Econsigneeid { get { return _Econsigneeid; } set { _Econsigneeid = value; } }
    public string Econsignee_name { get { return _Econsignee_name; } set { _Econsignee_name = value; } }
    public string Ename { get { return _Ename; } set { _Ename = value; } }
   

    #endregion

    #region Insert & Update

    public int Consignee_Master_Insert_update()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[20];

            param[0] = new SqlParameter("@CONSIGNEE_ID", CONSIGNEE_ID);
            param[1] = new SqlParameter("@CONSIGNEE_NAME", CONSIGNEE_NAME);

            param[2] = new SqlParameter("@CONSIGNEE_ADD1", CONSIGNEE_ADD1);
            param[3] = new SqlParameter("@CONSIGNEE_ADD2", CONSIGNEE_ADD2);
            param[4] = new SqlParameter("@CONSIGNEE_ADD3", CONSIGNEE_ADD3);
            param[5] = new SqlParameter("@CONSIGNEE_COUNTRY_NAME", CONSIGNEE_COUNTRY_NAME);
            param[6] = new SqlParameter("@CONSIGNEE_COUNTRY_CODE", CONSIGNEE_COUNTRY_CODE);
            param[7] = new SqlParameter("@CONSIGNEE_PIN_CODE", CONSIGNEE_PIN_CODE);
            param[8] = new SqlParameter("@CONSIGNEE_REMARKS", CONSIGNEE_REMARKS);

            param[9] = new SqlParameter("@CONSIGNEE_USER_ID", USER_ID);
            param[10] = new SqlParameter("@CONSIGNEE_BRANCH_CODE", BRANCH_CODE);
            param[11] = new SqlParameter("@CONSIGNEE_YEAR", YEAR);
            param[12] = new SqlParameter("@CONSIGNEE_WORKING_PERIOD", EWorking_Period);
            param[13] = new SqlParameter("@Mflag", flag);



            param[14] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[14].Direction = ParameterDirection.Output;

            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;


            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_CONSIGNEE_MASTER_INSERT_UPDATE", param);

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

    public DataSet RetrieveAll_Consignee_MASTER()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@CONSIGNEE_ID", Econsigneeid);
            param[1] = new SqlParameter("@Working_Period", EWorking_Period);

            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@CONSIGNEE_NAME", Econsignee_name);


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
                //SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_CONSIGNEE_MASTER", param);
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_CONSIGNEE_MASTER_SEARCH_SELECT", param);

                result = Convert.ToInt32(param[4].Value.ToString());


            }
            else
            {
                //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_CONSIGNEE_MASTER", param);
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_CONSIGNEE_MASTER_SEARCH_SELECT", param);
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