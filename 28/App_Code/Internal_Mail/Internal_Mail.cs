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
/// Summary description for BE_Entry
/// </summary>
public class Internal_Mail
{
    SqlDataAdapter da;
    SqlDataReader dr;
    DataSet ds = new DataSet();

    DataTable dt = new DataTable();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    SqlCommand cmd;
    int A1, A2;

    public int result = 0, UPDATE_ID = 0;
    //SqlConnection con = new SqlConnection();
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);

    #region Private_Attributes
    public int totalrows { get; set; }
    private string _INBOX_ID;
    private string _RECEIVED_FROM;
    private string _TO_ADDRESS;
    private string _SUBJECT;
    private string _BODY_CONTENT;
    private string _RECEIVED_DATE;
    private string _FILE_NAME;
    private string _RANDOM_FILE_NO;

    private string _INBOX;
    private string _SENT;
    private string _TRASH;
    private string _FOLDER;


    private string _READ_STATUS;
    private string _DELETE_STATUS;
    private string _USER_ID;
    private string _DATE_TIME;
    private string _STATUS;
    private string _BRANCH_CODE;
    private string _YEAR;
    private string _WORKING_PERIOD;

    private string  _flag;
    private string _Ename;
    #endregion

    #region Public_Attributes
    public string FROM_ADD, TO_ADD, date1, date2, USER_CREATION_ID;
    public string COMPANY_ID, startRowIndex, maximumRows;

    public string FROM_DATE, TO_DATE, REFERENCE_ID;
    public string INBOX_ID { get { return _INBOX_ID; } set { _INBOX_ID = value; } }
    public string RECEIVED_FROM { get { return _RECEIVED_FROM; } set { _RECEIVED_FROM = value; } }
    public string TO_ADDRESS { get { return _TO_ADDRESS; } set { _TO_ADDRESS = value; } }
    public string SUBJECT { get { return _SUBJECT; } set { _SUBJECT = value; } }
    public string BODY_CONTENT { get { return _BODY_CONTENT; } set { _BODY_CONTENT = value; } }
    public string RECEIVED_DATE { get { return _RECEIVED_DATE; } set { _RECEIVED_DATE = value; } }
    public string FILE_NAME { get { return _FILE_NAME; } set { _FILE_NAME = value; } }
    public string RANDOM_FILE_NO { get { return _RANDOM_FILE_NO; } set { _RANDOM_FILE_NO = value; } }

    public string INBOX { get { return _INBOX; } set { _INBOX = value; } }
    public string SENT { get { return _SENT; } set { _SENT = value; } }
    public string TRASH { get { return _TRASH; } set { _TRASH = value; } }
    public string FOLDER { get { return _FOLDER; } set { _FOLDER = value; } }


    public string READ_STATUS { get { return _READ_STATUS; } set { _READ_STATUS = value; } }
    public string DELETE_STATUS { get { return _DELETE_STATUS; } set { _DELETE_STATUS = value; } }

   

    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }

    public string flag { get { return _flag; } set { _flag = value; } }
    public string Ename { get { return _Ename; } set { _Ename = value; } }
    #endregion

    public int Send_Mail()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[35];
            param[0] = new SqlParameter("@INBOX_ID", INBOX_ID);
            param[31] = new SqlParameter("@RECEIVED_FROM", RECEIVED_FROM);
            param[1] = new SqlParameter("@TO_ADDRESS", TO_ADDRESS);
            param[2] = new SqlParameter("@SUBJECT", SUBJECT);
            param[3] = new SqlParameter("@BODY_CONTENT", BODY_CONTENT);
           
            param[5] = new SqlParameter("@FILE_NAME", FILE_NAME);
            param[14] = new SqlParameter("@RANDOM_FILE_NO", RANDOM_FILE_NO);
            param[6] = new SqlParameter("@INBOX", INBOX);
            
            param[8] = new SqlParameter("@SENT", SENT);
            param[9] = new SqlParameter("@TRASH", TRASH);
            param[10] = new SqlParameter("@FOLDER", FOLDER);
            param[12] = new SqlParameter("@READ_STATUS", READ_STATUS);
            param[13] = new SqlParameter("@DELETE_STATUS", DELETE_STATUS);

            param[20] = new SqlParameter("@USER_ID", USER_ID);
            param[21] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[22] = new SqlParameter("@YEAR", YEAR);
            param[23] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[24] = new SqlParameter("@Mflag", flag);
            param[25] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[25].Direction = ParameterDirection.Output;
            param[26] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[26].Direction = ParameterDirection.Output;
           
            param[32] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[32].Direction = ParameterDirection.Output;
            param[33] = new SqlParameter("@USER_CREATION_ID", USER_CREATION_ID);

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INTERNAL_MAIL_SEND", param);

            string f = param[26].Value.ToString();
           
            result = Convert.ToInt32(param[25].Value.ToString());
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[32].Value.ToString());
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
        return result;
    }

    public DataTable GetMail()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[30];

            param[0] = new SqlParameter("@Mflag", flag);

            param[1] = new SqlParameter("@FROM_ADDRESS", FROM_ADD);
            param[2] = new SqlParameter("@TO_ADDRESS", TO_ADD);
            Maildb dtt = new Maildb();
            //string dt = DateTime.Parse(Convert.ToString("08/04/2013"), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).ToString();
            if (FROM_DATE != "")
                param[4] = new SqlParameter("@FROM_DATE", DateTime.Parse(Convert.ToString(FROM_DATE), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            else
            {
                param[4] = new SqlParameter("@FROM_DATE", FROM_DATE);
            }
            if (TO_DATE != "")
                param[5] = new SqlParameter("@TO_DATE", DateTime.Parse(Convert.ToString(dtt.toDate((TO_DATE))), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            else
            {
                param[5] = new SqlParameter("@TO_DATE", TO_DATE);
            }
           
            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@startRowIndex", startRowIndex);

            param[10] = new SqlParameter("@maximumRows", maximumRows);

            param[11] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output;
            param[12] = new SqlParameter("@INBOX", INBOX);
            param[13] = new SqlParameter("@SENT", SENT);
            param[14] = new SqlParameter("@TRASH", TRASH);
            param[15] = new SqlParameter("@FOLDER", FOLDER);
            param[16] = new SqlParameter("@INBOX_ID", INBOX_ID);
            param[17] = new SqlParameter("@READ_STATUS", READ_STATUS);
            param[18] = new SqlParameter("@DELETE_STATUS", DELETE_STATUS);
            param[19] = new SqlParameter("@REFERENCE_ID", REFERENCE_ID);
            param[20] = new SqlParameter("@USER_CREATION_ID", USER_CREATION_ID);


            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INTERNAL_MAIL_INBOX_SEARCH_SELECT", param);
            if (flag == "select_con" || flag == "select_all" || flag == "INBOX_UNREAD_MESSAGE_COUNT_STATUS")
            {
               
                if(!string.IsNullOrWhiteSpace(param[11].Value.ToString()))
                totalrows = Convert.ToInt32(param[11].Value.ToString());
            }
            else
            {
                result = Convert.ToInt32(param[7].Value.ToString());
            }
            string f = param[8].Value.ToString();
            //string fa = param[11].Value.ToString();
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

        }
        return ds.Tables[0];
    }
    protected string GetRandomNumber(int length, string characterSet)
    {

        string randomData = "";

        int position = 0;

        byte[] data = new byte[length];

        int characterSetLength = characterSet.Length;

        System.Security.Cryptography.RandomNumberGenerator random = System.Security.Cryptography.RandomNumberGenerator.Create();

        random.GetBytes(data);

        for (int index = 0; (index < length); index++)
        {

            position = data[index];

            position = (position % characterSetLength);

            randomData = (randomData + characterSet.Substring(position, 1));

        }

        return randomData;



    }


    
}