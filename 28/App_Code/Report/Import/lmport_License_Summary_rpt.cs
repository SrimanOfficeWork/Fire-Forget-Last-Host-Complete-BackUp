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
using System.IO;
using System.Net;

/// <summary>
/// Summary description for license
/// </summary>
public class licensereport
{
    #region public string

    public DataSet ds = new DataSet();

    public int result;
    private bool result1;
    private string _JOBNO;


    private string _LICENSENO, _REGISTRATION_NO, _LICENSE_BALANCE;
    public string _LICENSEDATE, _REGISTRATION_DATE, _LICENCE_VALUE, _DEBIT_DUTY;
    private string _Workingperiod,_Flag;

    public string LicenseNo
    {
        get { return _LICENSENO; }
        set { _LICENSENO = value; }
    }
   
    public string Workingperiod
    {
        get { return _Workingperiod; }
        set { _Workingperiod = value; }
    }

     
     public string LICENSE_DATE { get { return _LICENSEDATE; } set { _LICENSEDATE = value; } }
     public string REGISTRATION_NO { get { return _REGISTRATION_NO; } set { _REGISTRATION_NO = value; } }
     public string REGISTRATION_DATE { get { return _REGISTRATION_DATE; } set { _REGISTRATION_DATE = value; } }
     public string LICENCE_VALUE { get { return _LICENCE_VALUE; } set { _LICENCE_VALUE = value; } }
     public string DEBIT_DUTY { get { return _DEBIT_DUTY; } set { _DEBIT_DUTY = value; } }
     public string LICENSE_BALANCE { get { return _LICENSE_BALANCE; } set { _LICENSE_BALANCE = value; } }
     public string Flag { get { return _Flag; } set { _Flag = value; } }
      

    #endregion

    public List<licensereport> import_license_master(DataTable dt)
    {
        List<licensereport> list = new List<licensereport>();
        list.Clear();
        int i = 0;

        while (dt.Rows.Count > i)
        {
            //string JOBNO = "5";
            DataRow row = dt.Rows[i];

            list.Add(new licensereport()
            {
                LicenseNo = row["LICENSE_NO"].ToString(),
                LICENSE_DATE = row["LICENSE_DATE"].ToString(),
                REGISTRATION_NO = row["REGISTRATION_NO"].ToString(),
                REGISTRATION_DATE = row["REGISTRATION_DATE"].ToString(),
                LICENCE_VALUE = row["TOTAL_DEBIT_AMT"].ToString(),
                
            });
            i++;
        }

        return list;
    }


    public List<licensereport> license_details(DataTable dt)
    {

        List<licensereport> list = new List<licensereport>();

        list.Clear();
        int i = 0;

        while (dt.Rows.Count > i)
        {
            DataRow row = dt.Rows[i];

            list.Add(new licensereport()
            {

                DEBIT_DUTY = row["DEBIT_DUTY"].ToString(),
               

            });
            i++;
        }

        return list;
    }


    public DataSet RetrieveAll_License_SummaryReport_Details()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@LICENSE_NO", LicenseNo);
            param[1] = new SqlParameter("@Flag", Flag);
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "BAS_IMP_LICENSE_SUMMARY_RPT", param);
            string err = param[5].Value.ToString();

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