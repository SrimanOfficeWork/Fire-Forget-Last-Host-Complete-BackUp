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
/// Summary description for Charge_Master
/// </summary>
public class Charge_Master
{
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    DataSet dtuser = new DataSet();
    DataTable dt = new DataTable();
    ErrorLogs er = new ErrorLogs();
    SqlDataReader dr;
    SqlCommand cmd;
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);
    public string str;
    private string _startRowIndex;
    private string _maximumRows;
    private string _totalRows;
    private string _ALLOW_QUOTATION;
    private string _BRANCH_COMMON;
    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string totalRows { get { return _totalRows; } set { _totalRows = value; } }
    public string ALLOW_QUOTATION { get { return _ALLOW_QUOTATION; } set { _ALLOW_QUOTATION = value; } }
    public string BRANCH_COMMON { get { return _BRANCH_COMMON; } set { _BRANCH_COMMON = value; } }
    
    public int result = 0, UPDATE_ID = 0;

    #region Insert,update Private Attributes

    //---------Charge Master--------------
    private string _CHARGE_ID;

    private string _CHARGE_CODE;
    private string _CHARGE_NAME;
    private string _TAX_MODE;
    private string _CHARGE_TYPE;
    private string _DESCRIPTION;
    private string _CREATED_BY;
    private string _MODIFIED_BY;
    private string _CREATED_ON;
    private string _MODIFIED_ON;
   
    private string _flag;
     
    private string _BRANCH_CODE;
    private string _YEAR;
    private string _WORKING_PERIOD;

    private string _Ename;

    #endregion

    #region Insert,update Attributes

    //---------adcode--------------
    public string CHARGE_ID { get { return _CHARGE_ID; } set { _CHARGE_ID = value; } }

    public string CHARGE_CODE { get { return _CHARGE_CODE; } set { _CHARGE_CODE = value; } }
    public string CHARGE_NAME { get { return _CHARGE_NAME; } set { _CHARGE_NAME = value; } }
    public string TAX_MODE { get { return _TAX_MODE; } set { _TAX_MODE = value; } }
    public string CHARGE_TYPE { get { return _CHARGE_TYPE; } set { _CHARGE_TYPE = value; } }
    public string DESCRIPTION { get { return _DESCRIPTION; } set { _DESCRIPTION = value; } }

    
    public string CREATED_BY { get { return _CREATED_BY; } set { _CREATED_BY = value; } }
    public string MODIFIED_BY { get { return _MODIFIED_BY; } set { _MODIFIED_BY = value; } }
    public string CREATED_ON { get { return _CREATED_ON; } set { _CREATED_ON = value; } }
    public string MODIFIED_ON { get { return _MODIFIED_ON; } set { _MODIFIED_ON = value; } }
  
    public string flag { get { return _flag; } set { _flag = value; } }
   
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }

    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }

    public string Ename { get { return _Ename; } set { _Ename = value; } }

    #endregion

    #region Retrieve
    public DataSet RetrieveAll_Charge_Master()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@CHARGE_ID", CHARGE_ID);
            param[1] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@CHARGE_CODE", CHARGE_CODE);
            param[9] = new SqlParameter("@CHARGE_NAME", CHARGE_NAME);
                      

            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[4].Direction = ParameterDirection.Output;

            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@startRowIndex", startRowIndex);

            param[7] = new SqlParameter("@maximumRows", maximumRows);

            param[8] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;

            param[10] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);

            


            if (Ename == "delete")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "BL_CHARGE_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[4].Value.ToString());
            }
            else if (Ename == "Select_max_ChargeId")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "BL_CHARGE_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[4].Value.ToString());
            }

            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "BL_CHARGE_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[8].Value.ToString());

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Ename = "1";
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


    public int Charge_Master_Insert_update()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[22];

            param[0] = new SqlParameter("@CHARGE_ID", CHARGE_ID);
            param[1] = new SqlParameter("@CHARGE_CODE", CHARGE_CODE);

            param[2] = new SqlParameter("@CHARGE_NAME", CHARGE_NAME);
            param[3] = new SqlParameter("@TAX_MODE", TAX_MODE);
            param[4] = new SqlParameter("@CHARGE_TYPE", CHARGE_TYPE);

            param[9] = new SqlParameter("@DESCRIPTION", DESCRIPTION);
            
            param[5] = new SqlParameter("@CREATED_BY", CREATED_BY);
            param[6] = new SqlParameter("@MODIFIED_BY", MODIFIED_BY);
            param[7] = new SqlParameter("@CREATED_ON", CREATED_ON);
            param[8] = new SqlParameter("@MODIFIED_ON", MODIFIED_ON);

            param[13] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[14] = new SqlParameter("@YEAR", YEAR);
            param[15] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[16] = new SqlParameter("@Mflag", flag);
            param[17] = new SqlParameter("@ALLOW_QUOTATION", ALLOW_QUOTATION);
            param[18] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
            
            param[19] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[19].Direction = ParameterDirection.Output;

            param[20] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[20].Direction = ParameterDirection.Output;
            param[21] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[21].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "BL_CHARGE_MASTER_INSERT_UPDATE", param);
            result = Convert.ToInt32(param[19].Value.ToString());
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[21].Value.ToString());



        }
        catch (Exception ex)
        {

            er.makeLog(ex.Message);
        }


        return result;

    }

   
}