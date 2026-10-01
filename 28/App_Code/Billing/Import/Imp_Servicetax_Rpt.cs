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
/// Summary description for Servicetax_Rpt
/// </summary>
public class Servicetax_Rpt
{

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    ErrorLogs er = new ErrorLogs();
    SqlDataReader dr;
    SqlCommand cmd;
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);


    public int result = 0, UPDATE_ID = 0;

    private string _flag, _Ename;
    private string _startRowIndex;
    private string _maximumRows;
    private string _totalRows;

    private string _TO_DATE;
    private string _FROM_DATE;

    private string _CLIENT_BRANCH_CODE;

    public string Ename { get { return _Ename; } set { _Ename = value; } }
    public string CLIENT_BRANCH_CODE { get { return _CLIENT_BRANCH_CODE; } set { _CLIENT_BRANCH_CODE = value; } }

    

    public string FROM_DATE { get { return _FROM_DATE; } set { _FROM_DATE = value; } }

    public string TO_DATE { get { return _TO_DATE; } set { _TO_DATE = value; } }

    


    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string totalRows { get { return _totalRows; } set { _totalRows = value; } }



    public DataSet Servicetax_Report_Details()
    {
        try
        {

            string[] arr = new string[] { };
            string[] arr2 = new string[] { };
            if (FROM_DATE != string.Empty && FROM_DATE != null)
            {
                arr = FROM_DATE.Split('/');
                FROM_DATE = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (TO_DATE != string.Empty && TO_DATE != null)
            {
                arr2 = TO_DATE.Split('/');
                TO_DATE = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@from_date", FROM_DATE);
            param[1] = new SqlParameter("@to_date", TO_DATE);

            
            param[3] = new SqlParameter("@Branch", CLIENT_BRANCH_CODE);

            param[4] = new SqlParameter("@Ename", Ename);
        
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

           

            if (Ename == "Select_All_NormalSearch" )
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMP_SERVICETAX_RPT", param);
               
                result = Convert.ToInt32(param[6].Value.ToString());

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