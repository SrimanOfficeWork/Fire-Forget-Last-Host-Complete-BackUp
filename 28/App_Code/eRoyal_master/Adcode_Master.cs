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
/// Summary description for Adcode_Master
/// </summary>
public class Adcode_Master
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

    private string _ADCODE_ID;
    private string _ADCODE_IEC_CODE;
    private string _ADCODE_IEC_NAME;
    private string _ADCODE_IEC_ADCODE;
    private string _ADCODE_BANK_NAME;
    private string _ADCODE_BANK_ACCOUNT_NO;
    private string _ADCODE_BANK_ADD1;
    private string _ADCODE_BANK_ADD2;
    private string _ADCODE_BANK_CITY;
    private string _ADCODE_BANK_STATE;
    private string _ADCODE_BANK_PIN_CODE;
    private string _ADCODE_REMARKS;
    private string _flag;

    private string _USER_ID;
    private string _BRANCH_CODE;
    private string _YEAR;

    private string _Eadcodeid;
    private string _EWorking_Period;
    private string _Ename;
    private string _Eadcode_iec_name;
    #endregion

    #region Public Attributes

    public string ADCODE_ID { get { return _ADCODE_ID; } set { _ADCODE_ID = value; } }

    public string ADCODE_IEC_CODE { get { return _ADCODE_IEC_CODE; } set { _ADCODE_IEC_CODE = value; } }
    public string ADCODE_IEC_NAME { get { return _ADCODE_IEC_NAME; } set { _ADCODE_IEC_NAME = value; } }
    public string ADCODE_IEC_ADCODE { get { return _ADCODE_IEC_ADCODE; } set { _ADCODE_IEC_ADCODE = value; } }
    public string ADCODE_BANK_NAME { get { return _ADCODE_BANK_NAME; } set { _ADCODE_BANK_NAME = value; } }
    public string ADCODE_BANK_ACCOUNT_NO { get { return _ADCODE_BANK_ACCOUNT_NO; } set { _ADCODE_BANK_ACCOUNT_NO = value; } }
    public string ADCODE_BANK_ADD1 { get { return _ADCODE_BANK_ADD1; } set { _ADCODE_BANK_ADD1 = value; } }
    public string ADCODE_BANK_ADD2 { get { return _ADCODE_BANK_ADD2; } set { _ADCODE_BANK_ADD2 = value; } }
    public string ADCODE_BANK_CITY { get { return _ADCODE_BANK_CITY; } set { _ADCODE_BANK_CITY = value; } }
    public string ADCODE_BANK_STATE { get { return _ADCODE_BANK_STATE; } set { _ADCODE_BANK_STATE = value; } }
    public string ADCODE_BANK_PIN_CODE { get { return _ADCODE_BANK_PIN_CODE; } set { _ADCODE_BANK_PIN_CODE = value; } }
    public string ADCODE_REMARKS { get { return _ADCODE_REMARKS; } set { _ADCODE_REMARKS = value; } }
    public string flag { get { return _flag; } set { _flag = value; } }

    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }

    #endregion

    #region Retrieve Attributes

    public string Eadcodeid { get { return _Eadcodeid; } set { _Eadcodeid = value; } }
    public string EWorking_Period { get { return _EWorking_Period; } set { _EWorking_Period = value; } }
    public string Ename { get { return _Ename; } set { _Ename = value; } }
    public string Eadcode_iec_name { get { return _Eadcode_iec_name; } set { _Eadcode_iec_name = value; } }

    #endregion


    #region Insert & Update

    public int Adcode_Master_Insert_update()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[20];

            param[0] = new SqlParameter("@ADCODE_ID", ADCODE_ID);
            param[1] = new SqlParameter("@ADCODE_IEC_CODE", ADCODE_IEC_CODE);

            param[2] = new SqlParameter("@ADCODE_IEC_NAME", ADCODE_IEC_NAME);
            param[3] = new SqlParameter("@ADCODE_IEC_ADCODE", ADCODE_IEC_ADCODE);
            param[4] = new SqlParameter("@ADCODE_BANK_NAME", ADCODE_BANK_NAME);
            param[5] = new SqlParameter("@ADCODE_BANK_ACCOUNT_NO", ADCODE_BANK_ACCOUNT_NO);
            param[6] = new SqlParameter("@ADCODE_BANK_ADD1", ADCODE_BANK_ADD1);
            param[7] = new SqlParameter("@ADCODE_BANK_ADD2", ADCODE_BANK_ADD2);
            param[8] = new SqlParameter("@ADCODE_BANK_CITY", ADCODE_BANK_CITY);
            param[9] = new SqlParameter("@ADCODE_BANK_STATE", ADCODE_BANK_STATE);
            param[10] = new SqlParameter("@ADCODE_BANK_PIN_CODE", ADCODE_BANK_PIN_CODE);
            param[11] = new SqlParameter("@ADCODE_REMARKS", ADCODE_REMARKS);
            param[12] = new SqlParameter("@ADCODE_USER_ID", USER_ID);
            param[13] = new SqlParameter("@ADCODE_BRANCH_CODE", BRANCH_CODE);
            param[14] = new SqlParameter("@ADCODE_YEAR", YEAR);
            param[15] = new SqlParameter("@ADCODE_WORKING_PERIOD", EWorking_Period);
            param[16] = new SqlParameter("@Mflag", flag);



            param[17] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[17].Direction = ParameterDirection.Output;

            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;


            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_ADCODE_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[17].Value.ToString());



        }
        catch (Exception ex)
        {

            er.makeLog(ex.Message);
        }


        return result;

    }

    #endregion

    #region Retrieve Record

    public DataSet RetrieveAll_Adcode_MASTER()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@ADCODE_ID", Eadcodeid);
            param[1] = new SqlParameter("@Working_Period", EWorking_Period);

            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@ADCODE_IEC_NAME", Eadcode_iec_name);


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
                //SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_ADCODEMASTER", param);
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_ADCODEMASTER__SEARCH_SELECT", param);

                result = Convert.ToInt32(param[4].Value.ToString());


            }
            else
            {

                //s = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_ADCODEMASTER", param);
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_ADCODEMASTER__SEARCH_SELECT", param);
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