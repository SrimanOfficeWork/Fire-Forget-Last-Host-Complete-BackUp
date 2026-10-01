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
/// Summary description for Import_General
/// </summary>
public class Imp_RITC_FTA_ADD
{
    SqlDataAdapter da;
    SqlDataReader dr;
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    ErrorLogs er = new ErrorLogs();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    SqlCommand cmd;
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);
    public int result;
    public string err;


    # region Common Attributes

    private string _flag;
    private string _USER_ID;
    private string _BRANCH_CODE;
    private string _YEAR;
    private string _WORKING_PERIOD;
    private string _JOBNO;
    private string _INVOICE_SLNO;
    private string _ITEM_SLNO;

    private string _JOBID;
    private string _Ename;
    private string _PRODUCT_BCD_NOTN, _NOTN_NO, _NOTN_SLNO, _RATE, _XmlString, _CTH;
    private string _PRODUCT_BCD_SLNO;
    private string _PRODUCT_BCD_RATE;
    private string _PRODUCT_SAPTA_NOTN;
    private string _PRODUCT_SAPTA_SLNO;
    private string _PRODUCT_SAPTA_RATE;
    private string _CTH_SLNO;
    private string _CTH_SUPPLIER_SLNO;

    #endregion

    #region Public Attributes

  
    public string JOBID { get { return _JOBID; } set { _JOBID = value; } }
    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string CTH { get { return _CTH; } set { _CTH = value; } }
    public string INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }
    public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }


    public string NOTN_NO { get { return _NOTN_NO; } set { _NOTN_NO = value; } }
    public string NOTN_SLNO { get { return _NOTN_SLNO; } set { _NOTN_SLNO = value; } }
    public string RATE { get { return _RATE; } set { _RATE = value; } }
    public string PRODUCT_BCD_NOTN { get { return _PRODUCT_BCD_NOTN; } set { _PRODUCT_BCD_NOTN = value; } }
    public string PRODUCT_BCD_SLNO { get { return _PRODUCT_BCD_SLNO; } set { _PRODUCT_BCD_SLNO = value; } }
    public string PRODUCT_BCD_RATE { get { return _PRODUCT_BCD_RATE; } set { _PRODUCT_BCD_RATE = value; } }
    public string PRODUCT_SAPTA_NOTN { get { return _PRODUCT_SAPTA_NOTN; } set { _PRODUCT_SAPTA_NOTN = value; } }
    public string PRODUCT_SAPTA_SLNO { get { return _PRODUCT_SAPTA_SLNO; } set { _PRODUCT_SAPTA_SLNO = value; } }
    public string PRODUCT_SAPTA_RATE { get { return _PRODUCT_SAPTA_RATE; } set { _PRODUCT_SAPTA_RATE = value; } }
    public string CTH_SLNO { get { return _CTH_SLNO; } set { _CTH_SLNO = value; } }
    public string CTH_SUPPLIER_SLNO { get { return _CTH_SUPPLIER_SLNO; } set { _CTH_SUPPLIER_SLNO = value; } }
   
    public string flag { get { return _flag; } set { _flag = value; } }

    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }
    public string XmlString { get { return _XmlString; } set { _XmlString = value; } }

    #endregion


    public DataSet Imp_FTA_SAPTA_ADD_BulkUpdate()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[17];

            param[0] = new SqlParameter("@Jobno", JOBNO);
            param[15] = new SqlParameter("@CTH", CTH);
            param[1] = new SqlParameter("@InvSlNo", INVOICE_SLNO);
            param[2] = new SqlParameter("@ItemSlNo", ITEM_SLNO);
            param[3] = new SqlParameter("@NOTN_NO", PRODUCT_BCD_NOTN);
            param[4] = new SqlParameter("@NOTN_SLNO", NOTN_SLNO);
            param[5] = new SqlParameter("@RATE", RATE);
            param[6] = new SqlParameter("@ADD_CTH_SLNO", CTH_SLNO);
            param[7] = new SqlParameter("@ADD_SUP_SLNO", CTH_SUPPLIER_SLNO);
            param[8] = new SqlParameter("@XmlString", XmlString);
            param[9] = new SqlParameter("@UserId", Connection.Current_User());
            param[10] = new SqlParameter("@Branch", Connection.Current_Branch());
            param[11] = new SqlParameter("@WorkingPeriod", Connection.WorkingPeriod());
            param[12] = new SqlParameter("@flag", flag);

            param[13] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[13].Direction = ParameterDirection.Output;
            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

          //  SqlHelper.ExecuteNonQuery(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMP_RITC_BASED_FTA_SAPTA_BULK_UPDATE", param);
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMP_RITC_BASED_FTA_SAPTA_BULK_UPDATE", param);
            result = Convert.ToInt32(param[13].Value.ToString());
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

    /*
    public DataSet RetrieveAll_General_Details()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15]; param[0] = new SqlParameter("@JOBID", JOBID);
            param[1] = new SqlParameter("@JOBNO", JOBNO);
            param[2] = new SqlParameter("@IMPORTER_NAME", IMPORTER_NAME);
            param[3] = new SqlParameter("@TRANSPORT_MODE", TRANSPORT_MODE);
            param[4] = new SqlParameter("@CUSTOMS_HOUSE", CUSTOMS_HOUSE);
            param[5] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@startRowIndex", startRowIndex); param[10] = new SqlParameter("@maximumRows", maximumRows); param[11] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output; if (Ename == "delete")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH_SELECT", param); result = Convert.ToInt32(param[7].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[11].Value.ToString());
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
    */
}