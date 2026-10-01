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
/// Summary description for Statements
/// </summary>
public class Statement
{
    SqlDataAdapter da;
    SqlDataReader dr;
    DataSet ds = new DataSet();

    DataTable dt = new DataTable();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    SqlCommand cmd;
    int A1, A2;
    //SqlConnection con = new SqlConnection();
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);
    string date2;

    public int result = 0;

    # region Common_Private_Attributes

    private string _flag;

    private string _USER_ID;
    private string _BRANCH_CODE;
    private string _YEAR;
    private string _WORKING_PERIOD;
    private string _JOBNO;
    private string _Workingperiod;
    private string _Ename;
    private string _EXPORTER_NAME;
    private string _CONSIGNEE_NAME;
    private string _FROMDATE;
    private string _TODATE;
    private string _INVOICE_NO;

    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string Ename { get { return _Ename; } set { _Ename = value; } }
    public string Workingperiod { get { return _Workingperiod; } set { _Workingperiod = value; } }



    public string Jobdate { get; set; }
    public string Transport_mode { get; set; }
    public string EXPORTER_NAME { get { return _EXPORTER_NAME; } set { _EXPORTER_NAME = value; } }
    public string CONSIGNEE_NAME { get { return _CONSIGNEE_NAME; } set { _CONSIGNEE_NAME = value; } }

    public string FROMDATE { get { return _FROMDATE; } set { _FROMDATE = value; } }
    public string TODATE { get { return _TODATE; } set { _TODATE = value; } }
    public string INVOICE_NO { get { return _INVOICE_NO; } set { _INVOICE_NO = value; } }

    #endregion

    public DataTable RetrieveAll_Details()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", JOBNO);
            param[1] = new SqlParameter("@EXPORTER_NAME", EXPORTER_NAME);

            param[2] = new SqlParameter("@CONSIGNEE_NAME", CONSIGNEE_NAME);

            param[11] = new SqlParameter("@INVOICE_NO", INVOICE_NO);

            if (!string.IsNullOrEmpty(FROMDATE))
                param[3] = new SqlParameter("@FROMDATE", DateTime.Parse(Convert.ToString(FROMDATE), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            else
            {
                param[3] = new SqlParameter("@FROMDATE", FROMDATE);
            }
            if (!string.IsNullOrEmpty(TODATE))
               // param[4] = new SqlParameter("@TODATE", DateTime.Parse(Convert.ToString(toDate((TODATE))), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
                param[4] = new SqlParameter("@TODATE", DateTime.Parse(Convert.ToString(TODATE), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            else
            {
                param[4] = new SqlParameter("@TODATE", TODATE);
            }
            if (!string.IsNullOrEmpty(Jobdate))
                param[5] = new SqlParameter("@JOBDATE", DateTime.Parse(Convert.ToString(Jobdate), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            else
            {
                param[5] = new SqlParameter("@JOBDATE", Jobdate);
            }

            param[6] = new SqlParameter("@name", Ename);
            param[7] = new SqlParameter("@Working_Period", Workingperiod);
            param[8] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            param[10] = new SqlParameter("@TRANSPORT_MODE", Transport_mode);

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXPORT_JOB_STATEMENT_SEARCH_SELECT", param);

            dt = ds.Tables[0];
            //if (ds.Tables.Count > 0)
            //{
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //    }
            //    else
            //        ds.Tables.Add(dt);

            //}
            //else
            //    ds.Tables.Add(dt);
            string err = param[5].Value.ToString();
            
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return dt;
    }

    public string toDate(string dt)
    {
        string[] s1 = dt.Split(new string[] { "/" }, StringSplitOptions.None);
        double s = Convert.ToDouble(s1[0].ToString());
        // s = s + 1;
        if (s < 31)
        {
            s = s + 1;
        }

        if (Convert.ToString(s).Length == 1)
            date2 = "0" + Convert.ToString(s);
        else if (Convert.ToString(s).Length == 2)
            date2 = Convert.ToString(s);

        return date2 = date2 + "/" + s1[1].ToString() + "/" + s1[2].ToString();
    }

}