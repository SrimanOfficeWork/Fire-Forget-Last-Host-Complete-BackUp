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
/// Summary description for Report_Client_Master
/// </summary>
public class Billing_Comp_Master
{

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    ErrorLogs er = new ErrorLogs();
    SqlDataReader dr;
    SqlCommand cmd;
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);

    public int result = 0, UPDATE_ID = 0;
    private string _RPT_ID;
    private string _CLIENT_NAME;
    private string _CLIENT_BRSLNO;
    private string _CLIENT_ADD1;
    private string _CLIENT_ADD2;
    private string _CLIENT_ADD3;
    private string _CLIENT_ADD4;
    private string _CLIENT_COUNTRY_NAME;
    private string _CLIENT_PINCODE;
    private string _CLIENT_PHONE;
    private string _CLIENT_eMAIL;

    private string _CLIENT_USER_ID;
    private string _CLIENT_DATE_TIME;
    private string _CLIENT_STATUS;
    private string _CLIENT_BRANCH_CODE;
    private string _CLIENT_WORKING_PERIOD;

    //****************************BILLING CLIENT MASTER****************************

    private string _BILL_ID;
    private string _CITY;
    private string _CLIENT_SERVICETAXNO;
    private string _CLIENT_PANNO;
    private string _CLIENT_FAXNO;
    private string _CLIENT_WEBSITE;
    private string _CLIENT_LOGO;
    private string _CLIENT_ACTIVATION;


    private string _flag, _Ename;
    private string _startRowIndex;
    private string _maximumRows;
    private string _totalRows;
  
    public string RPT_ID { get { return _RPT_ID; } set { _RPT_ID = value; } }
    public string CLIENT_NAME { get { return _CLIENT_NAME; } set { _CLIENT_NAME = value; } }
    public string CLIENT_BRSLNO { get { return _CLIENT_BRSLNO; } set { _CLIENT_BRSLNO = value; } }

    public string CLIENT_ADD1 { get { return _CLIENT_ADD1; } set { _CLIENT_ADD1 = value; } }
    public string CLIENT_ADD2 { get { return _CLIENT_ADD2; } set { _CLIENT_ADD2 = value; } }
    public string CLIENT_ADD3 { get { return _CLIENT_ADD3; } set { _CLIENT_ADD3 = value; } }
    public string CLIENT_ADD4 { get { return _CLIENT_ADD4; } set { _CLIENT_ADD4 = value; } }
    public string CLIENT_COUNTRY_NAME { get { return _CLIENT_COUNTRY_NAME; } set { _CLIENT_COUNTRY_NAME = value; } }
    public string CLIENT_PINCODE { get { return _CLIENT_PINCODE; } set { _CLIENT_PINCODE = value; } }
    public string CLIENT_PHONE { get { return _CLIENT_PHONE; } set { _CLIENT_PHONE = value; } }
    public string CLIENT_eMAIL { get { return _CLIENT_eMAIL; } set { _CLIENT_eMAIL = value; } }
    public string CLIENT_USER_ID { get { return _CLIENT_USER_ID; } set { _CLIENT_USER_ID = value; } }
    public string CLIENT_DATE_TIME { get { return _CLIENT_DATE_TIME; } set { _CLIENT_DATE_TIME = value; } }
    public string CLIENT_STATUS { get { return _CLIENT_STATUS; } set { _CLIENT_STATUS = value; } }
    public string CLIENT_BRANCH_CODE { get { return _CLIENT_BRANCH_CODE; } set { _CLIENT_BRANCH_CODE = value; } }
    public string CLIENT_WORKING_PERIOD { get { return _CLIENT_WORKING_PERIOD; } set { _CLIENT_WORKING_PERIOD = value; } }
    public string flag { get { return _flag; } set { _flag = value; } }
    public string Ename { get { return _Ename; } set { _Ename = value; } }

    //****************************BILLING CLIENT MASTER****************************
    public string BILL_ID { get { return _BILL_ID; } set { _BILL_ID = value; } }
    public string CITY { get { return _CITY; } set { _CITY = value; } }
    public string CLIENT_SERVICETAXNO { get { return _CLIENT_SERVICETAXNO; } set { _CLIENT_SERVICETAXNO = value; } }
    public string CLIENT_PANNO { get { return _CLIENT_PANNO; } set { _CLIENT_PANNO = value; } }
    public string CLIENT_FAXNO { get { return _CLIENT_FAXNO; } set { _CLIENT_FAXNO = value; } }
    public string CLIENT_WEBSITE { get { return _CLIENT_WEBSITE; } set { _CLIENT_WEBSITE = value; } }
    public string CLIENT_LOGO { get { return _CLIENT_LOGO; } set { _CLIENT_LOGO = value; } }
    public string CLIENT_ACTIVATION { get { return _CLIENT_ACTIVATION; } set { _CLIENT_ACTIVATION = value; } }

    //************************************************************************************************************

    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string totalRows { get { return _totalRows; } set { _totalRows = value; } }

    public Billing_Comp_Master()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    #region  BILLING CLIENT MASTER

    public int Billing_Client_Master_Insert_update()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[30];

            param[0] = new SqlParameter("@BILL_ID", BILL_ID);
            param[1] = new SqlParameter("@CLIENT_NAME", CLIENT_NAME);
            param[2] = new SqlParameter("@CLIENT_ADD1", CLIENT_ADD1);
            param[3] = new SqlParameter("@CLIENT_ADD2", CLIENT_ADD2);
            param[4] = new SqlParameter("@CLIENT_ADD3", CLIENT_ADD3);
            param[5] = new SqlParameter("@CLIENT_ADD4", CLIENT_ADD4);
            param[6] = new SqlParameter("@CITY", CITY);
            param[7] = new SqlParameter("@CLIENT_COUNTRY_NAME", CLIENT_COUNTRY_NAME);
            param[8] = new SqlParameter("@CLIENT_PINCODE", CLIENT_PINCODE);
            param[9] = new SqlParameter("@CLIENT_SERVICETAXNO", CLIENT_SERVICETAXNO);
            param[10] = new SqlParameter("@CLIENT_PANNO", CLIENT_PANNO);
            param[11] = new SqlParameter("@CLIENT_FAXNO", CLIENT_FAXNO);
            param[12] = new SqlParameter("@CLIENT_EMAIL", CLIENT_eMAIL);
            param[13] = new SqlParameter("@CLIENT_WEBSITE", CLIENT_WEBSITE);
            param[14] = new SqlParameter("@CLIENT_LOGO", CLIENT_LOGO);
            //param[14] = new SqlParameter("@CLIENT_LOGO", SqlDbType.Image, 100, CLIENT_LOGO);

            param[15] = new SqlParameter("@CLIENT_ACTIVATION", CLIENT_ACTIVATION);

            param[16] = new SqlParameter("@CLIENT_USER_ID", CLIENT_USER_ID);
            //param[12] = new SqlParameter("@CLIENT_DATE_TIME", CLIENT_DATE_TIME);
            //param[13] = new SqlParameter("@CLIENT_STATUS", CLIENT_STATUS);
            param[17] = new SqlParameter("@CLIENT_BRANCH_CODE", CLIENT_BRANCH_CODE);
            param[18] = new SqlParameter("@CLIENT_WORKING_PERIOD", CLIENT_WORKING_PERIOD);

            param[19] = new SqlParameter("@Mflag", flag);

            param[20] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[20].Direction = ParameterDirection.Output;
            param[21] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[21].Direction = ParameterDirection.Output;
            param[22] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[22].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "BILLING_COMPANY_MASTER_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[20].Value.ToString());
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[22].Value.ToString());

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

        return result;

    }


    public DataSet RetrieveAll_BILLING_Client_Details()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@BILL_ID", BILL_ID);
            param[1] = new SqlParameter("@CLIENT_NAME", CLIENT_NAME);

            //param[2] = new SqlParameter("@TYPE", CLIENT_TYPE);
            param[3] = new SqlParameter("@BRANCH", CLIENT_BRANCH_CODE);

            param[4] = new SqlParameter("@name", Ename);
            param[5] = new SqlParameter("@WORKING_PERIOD", CLIENT_WORKING_PERIOD);

            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            param[8] = new SqlParameter("@startRowIndex", startRowIndex);

            param[9] = new SqlParameter("@maximumRows", maximumRows);

            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;

            //param[6] = new SqlParameter("@Mflag", flag);

            if (Ename == "BindAll_BILLING_Client" || Ename == "BindAll_BILLING_ClientWise" || Ename == "BILLING_ClientMaster_Count")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "BILLING_COMPANY_MASTER_SELECT", param);
                string err = param[5].Value.ToString();
                result = Convert.ToInt32(param[6].Value.ToString());

            }  
            else if (Ename == "delete")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "BILLING_COMPANY_MASTER_SELECT", param);
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

    #endregion

}