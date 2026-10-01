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

public class Company_Master
{
    ErrorLogs er = new ErrorLogs();
    SqlDataAdapter da;
    SqlDataReader dr;
    DataSet ds = new DataSet();

    DataTable dt = new DataTable();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    SqlCommand cmd;
    int A1, A2;
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);

    private string _startRowIndex, _CHA_ConfigDetals, _Freight_ConfigDetals;

    private string _maximumRows;
    private string _totalRows;
           
    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string totalRows { get { return _totalRows; } set { _totalRows = value; } }
    public int Update_Id = 0;


    #region Company_Master Private_Attributes

    private string _COMPANY_ID;
    private string _COMPANY_LICENSE;
    private string _CLIENT_NAME;
    private string _ADDRESS;
    private string _PHONE_NO;
    private string _FAX;
    private string _EMAILID;
    private string _CONTACT_PERSON;
    private string _MOBILE_NO;
    private string _ALTERNATE_NO;

    private string _DATE_OF_INSTALLATION;
    private string _METHOD_OF_PURCHASE;
    private string _NO_OF_USERS;
    private string _COMPANY_STATUS;
    private string _NEXT_RENEWEL_DATE;
    private string _SELECT_OPTION;
    private string _USER_ID;
    private string _DATE_TIME;
    private string _STATUS;

    private string _DEFAULT_DATE;
    private string _NETWORK_IP;
    private string _USER_JOB_LOCK;
    private string _BILLING_STATUS;

    private string _Ename;
    private string _flag;

    private string _Acc, _Import, _Export, _Billing, _Imp_Sez, _Exp_Sez;
    #endregion
    
    public string Import { get { return _Import; } set { _Import = value; } }
    public string Export { get { return _Export; } set { _Export = value; } }
    public string Billing { get { return _Billing; } set { _Billing = value; } }
    public string Acc { get { return _Acc; } set { _Acc = value; } }

    public string Imp_Sez { get { return _Imp_Sez; } set { _Imp_Sez = value; } }
    public string Exp_Sez { get { return _Exp_Sez; } set { _Exp_Sez = value; } }

    #region CHA_LICENSE Private_Attributes
    
    private string _CHA_LICENSE_ID;
    private string _BRANCH;
    private string _PORT_OF_FILING;
    private string _ICEGATE_ID;
    private string _ICEGATE_PWD;
   
    private string _ICEGATE_EMAIL_ID;
    private string _ICEGATE_EMAIL_PWD;
    private string _CHA_NO;
    private string _CHA_NAME;
    private string _CHA_ADDRESS;
    private string _CHA_ADDRESS1;
    private string _CHA_ADDRESS2;
    private string _CHA_ADDRESS3;

    private string _CHA_ADDRESS4;
   
    #endregion

    #region Company_Master Public_Attributes

    public string COMPANY_ID { get { return _COMPANY_ID; } set { _COMPANY_ID = value; } }
    public string COMPANY_LICENSE { get { return _COMPANY_LICENSE; } set { _COMPANY_LICENSE = value; } }
    ////public string INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }
    ////public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }

    public string CLIENT_NAME { get { return _CLIENT_NAME; } set { _CLIENT_NAME = value; } }
    public string ADDRESS { get { return _ADDRESS; } set { _ADDRESS = value; } }
    public string PHONE_NO { get { return _PHONE_NO; } set { _PHONE_NO = value; } }
    public string FAX { get { return _FAX; } set { _FAX = value; } }
    public string EMAILID { get { return _EMAILID; } set { _EMAILID = value; } }
    public string CONTACT_PERSON { get { return _CONTACT_PERSON; } set { _CONTACT_PERSON = value; } }
    public string MOBILE_NO { get { return _MOBILE_NO; } set { _MOBILE_NO = value; } }
    public string ALTERNATE_NO { get { return _ALTERNATE_NO; } set { _ALTERNATE_NO = value; } }

    public string DATE_OF_INSTALLATION { get { return _DATE_OF_INSTALLATION; } set { _DATE_OF_INSTALLATION = value; } }
    public string METHOD_OF_PURCHASE { get { return _METHOD_OF_PURCHASE; } set { _METHOD_OF_PURCHASE = value; } }

    public string NO_OF_USERS { get { return _NO_OF_USERS; } set { _NO_OF_USERS = value; } }
    public string COMPANY_STATUS { get { return _COMPANY_STATUS; } set { _COMPANY_STATUS = value; } }

    public string NEXT_RENEWEL_DATE { get { return _NEXT_RENEWEL_DATE; } set { _NEXT_RENEWEL_DATE = value; } }
    public string SELECT_OPTION { get { return _SELECT_OPTION; } set { _SELECT_OPTION = value; } }

    public string DEFAULT_DATE { get { return _DEFAULT_DATE; } set { _DEFAULT_DATE = value; } }

    public string NETWORK_IP { get { return _NETWORK_IP; } set { _NETWORK_IP = value; } }

    public string USER_JOB_LOCK { get { return _USER_JOB_LOCK; } set { _USER_JOB_LOCK = value; } }

    public string BILLING_STATUS { get { return _BILLING_STATUS; } set { _BILLING_STATUS = value; } }
    
    
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }

    public string Ename { get { return _Ename; } set { _Ename = value; } }
    public string flag { get { return _flag; } set { _flag = value; } }

    public int result = 0;

    public string License_No;

    public string CHA_ConfigDetals { get { return _CHA_ConfigDetals; } set { _CHA_ConfigDetals = value; } }
    public string Freight_ConfigDetals { get { return _Freight_ConfigDetals; } set { _Freight_ConfigDetals = value; } }

    
    #endregion

    #region CHA_LICENSE Public_Attributes

    public string CHA_LICENSE_ID { get { return _CHA_LICENSE_ID; } set { _CHA_LICENSE_ID = value; } }
    public string BRANCH { get { return _BRANCH; } set { _BRANCH = value; } }
    ////public string INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }
    ////public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }

    public string PORT_OF_FILING { get { return _PORT_OF_FILING; } set { _PORT_OF_FILING = value; } }
    public string ICEGATE_PWD { get { return _ICEGATE_PWD; } set { _ICEGATE_PWD = value; } }
    public string ICEGATE_ID { get { return _ICEGATE_ID; } set { _ICEGATE_ID = value; } }

    public string ICEGATE_EMAIL_ID { get { return _ICEGATE_EMAIL_ID; } set { _ICEGATE_EMAIL_ID = value; } }
    public string ICEGATE_EMAIL_PWD { get { return _ICEGATE_EMAIL_PWD; } set { _ICEGATE_EMAIL_PWD = value; } }

    public string CHA_NO { get { return _CHA_NO; } set { _CHA_NO = value; } }
    public string CHA_NAME { get { return _CHA_NAME; } set { _CHA_NAME = value; } }
    public string CHA_ADDRESS { get { return _CHA_ADDRESS; } set { _CHA_ADDRESS = value; } }
    public string CHA_ADDRESS1 { get { return _CHA_ADDRESS1; } set { _CHA_ADDRESS1 = value; } }
    public string CHA_ADDRESS2 { get { return _CHA_ADDRESS2; } set { _CHA_ADDRESS2 = value; } }
    public string CHA_ADDRESS3 { get { return _CHA_ADDRESS3; } set { _CHA_ADDRESS3 = value; } }

    public string CHA_ADDRESS4 { get { return _CHA_ADDRESS4; } set { _CHA_ADDRESS4 = value; } }
  
    #endregion

    #region Retrieve AutoID

    public string Retrieve_License_No()
    {

        try
        {
            SqlParameter[] param = new SqlParameter[10];



           // param[1] = new SqlParameter("@Working_Period", WORKING_PERIOD);


            param[2] = new SqlParameter("@MStatus", SqlDbType.VarChar, 20);

            param[2].Direction = ParameterDirection.Output;

            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3].Direction = ParameterDirection.Output;
            param[4] = new SqlParameter("@companyid", SqlDbType.Int, 1);

            param[4].Direction = ParameterDirection.Output;
           // SqlHelper.ExecuteNonQuery(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_GENERAL_DETAILS_AUTOID", param);

            SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_COMPANY_MASTER_DETAILS_AUTOID", param);

            License_No = param[2].Value.ToString();
            COMPANY_ID = param[4].Value.ToString();

            string err = param[3].Value.ToString();

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        finally
        {

        }
        return License_No;
    }

    #endregion

    #region LOGIN DETAILS
    public string LOGIN_ID;

	public string USERNAME;
	public string PWD;
	
	public string ISLOGIN;
    public string DATABASE_ID, SERVER_NAME, DATABASE_NAME, WORKING_PERIOD, SELECT_JOB;
    #endregion

    public int Company_Master_Insert_update()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[36];
            param[1] = new SqlParameter("@COMPANY_LICENSE", COMPANY_LICENSE);
            param[2] = new SqlParameter("@CLIENT_NAME", CLIENT_NAME);
            param[3] = new SqlParameter("@ADDRESS", ADDRESS);
            param[4] = new SqlParameter("@PHONE_NO", PHONE_NO);
            param[5] = new SqlParameter("@FAX", FAX);
            param[6] = new SqlParameter("@EMAILID", EMAILID);
            param[7] = new SqlParameter("@CONTACT_PERSON", CONTACT_PERSON);
            param[8] = new SqlParameter("@MOBILE_NO", MOBILE_NO);
            param[9] = new SqlParameter("@ALTERNATE_NO", ALTERNATE_NO);
            param[10] = new SqlParameter("@DATE_OF_INSTALLATION", DateTime.Parse(DATE_OF_INSTALLATION, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[11] = new SqlParameter("@METHOD_OF_PURCHASE", METHOD_OF_PURCHASE);
            param[12] = new SqlParameter("@NO_OF_USERS", NO_OF_USERS);
            param[13] = new SqlParameter("@COMPANY_STATUS", COMPANY_STATUS);
            param[14] = new SqlParameter("@NEXT_RENEWEL_DATE", DateTime.Parse(NEXT_RENEWEL_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[15] = new SqlParameter("@SELECT_OPTION", SELECT_OPTION);
            param[16] = new SqlParameter("@DEFAULT_DATE", DEFAULT_DATE);
            param[17] = new SqlParameter("@NETWORK_IP", NETWORK_IP);
            param[18] = new SqlParameter("@USER_JOB_LOCK", USER_JOB_LOCK);
            param[19] = new SqlParameter("@BILLING_STATUS", BILLING_STATUS);

            param[20] = new SqlParameter("@IMPORT", Import);
            param[21] = new SqlParameter("@EXPORT", Export);
            param[22] = new SqlParameter("@BILLING", Billing);
            param[23] = new SqlParameter("@ACCOUNTS", Acc);
            param[24] = new SqlParameter("@IMP_SEZ", Imp_Sez);
            param[25] = new SqlParameter("@EXP_SEZ", Exp_Sez);

            param[32] = new SqlParameter("@USER_ID", USER_ID);
            param[33] = new SqlParameter("@Mflag", flag);

            param[34] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[34].Direction = ParameterDirection.Output;
            param[35] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[35].Direction = ParameterDirection.Output;
          
            SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_COMPANY_MASTER_INSERT_UPDATE", param);
            result = Convert.ToInt32(param[34].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }
    public DataSet CHA_LICENSE_Insert_update()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[25];

            param[0] = new SqlParameter("@CHA_LICENSE_ID", CHA_LICENSE_ID);
            param[1] = new SqlParameter("@COMPANY_ID", COMPANY_ID);
            param[2] = new SqlParameter("@BRANCH", BRANCH);
            param[3] = new SqlParameter("@PORT_OF_FILING", PORT_OF_FILING);
            param[4] = new SqlParameter("@ICEGATE_ID", ICEGATE_ID);
            param[5] = new SqlParameter("@CHA_NO", CHA_NO);
            param[6] = new SqlParameter("@CHA_NAME", CHA_NAME);
            param[7] = new SqlParameter("@CHA_ADDRESS", CHA_ADDRESS);
            param[8] = new SqlParameter("@CHA_ADDRESS1", CHA_ADDRESS1);
            param[9] = new SqlParameter("@CHA_ADDRESS2", CHA_ADDRESS2);
            param[10] = new SqlParameter("@CHA_ADDRESS3", CHA_ADDRESS3);
            param[11] = new SqlParameter("@CHA_ADDRESS4", CHA_ADDRESS4);
            param[12] = new SqlParameter("@USER_ID", USER_ID);
            param[16] = new SqlParameter("@Mflag", flag);
            param[17] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[17].Direction = ParameterDirection.Output;
            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;
            param[20] = new SqlParameter("@ICEGATE_PWD", ICEGATE_PWD);
            param[21] = new SqlParameter("@ICEGATE_EMAIL_ID", ICEGATE_EMAIL_ID);
            param[22] = new SqlParameter("@ICEGATE_EMAIL_PWD", ICEGATE_EMAIL_PWD);
          
            ds=SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CHA_LICENSE_DETAILS_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[17].Value.ToString());
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
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataTable RetrieveAll_Company_Details_datatable()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@COMPANY_ID", COMPANY_ID);
            param[1] = new SqlParameter("@COMPANY_LICENSE", COMPANY_LICENSE);
            param[2] = new SqlParameter("@CLIENT_NAME", CLIENT_NAME);
            param[3] = new SqlParameter("@CONTACT_PERSON", CONTACT_PERSON);
            param[4] = new SqlParameter("@MOBILE_NO", MOBILE_NO);
            param[5] = new SqlParameter("@name", Ename);
            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@startRowIndex", startRowIndex);
            param[10] = new SqlParameter("@maximumRows", maximumRows);
            param[11] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output;

            if (Ename == "delete")
            {
                SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_COMPANY_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[7].Value.ToString());
            }
            else if (Ename == "select_con")
            {
                ds= SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_COMPANY_MASTER_SEARCH_SELECT", param);
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
            else
            {
                ds=SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_COMPANY_MASTER_SEARCH_SELECT", param);
                string err = param[8].Value.ToString();
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
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds.Tables[0];
    }
    public DataSet RetrieveAll_Company_Details()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@COMPANY_ID", COMPANY_ID);
            param[1] = new SqlParameter("@COMPANY_LICENSE", COMPANY_LICENSE);
            param[2] = new SqlParameter("@CLIENT_NAME", CLIENT_NAME);
            param[3] = new SqlParameter("@CONTACT_PERSON", CONTACT_PERSON);
            param[4] = new SqlParameter("@MOBILE_NO", MOBILE_NO);
            param[5] = new SqlParameter("@name", Ename);
            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@startRowIndex", startRowIndex);
            param[10] = new SqlParameter("@maximumRows", maximumRows);
            param[11] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output;

            if (Ename == "delete" || Ename == "delete_DataBase_Details" || Ename == "All_Database" || Ename == "Return_All_Database" || Ename == "All_ClientName_With_CompanyLicense" || Ename == "Select_Working_Period" || Ename == "Select_Client_details" || Ename == "Select_WorkingPeriod_DatabaseName")
            {
                ds=SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_COMPANY_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[7].Value.ToString());
            }
            else if (Ename == "select_con" || Ename == "select_Id" || Ename == "Select_Login_Details" || Ename == "select_Company_Login_Details")
            {
                ds=SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_COMPANY_MASTER_SEARCH_SELECT", param);
                if(Ename == "select_con")
                result = Convert.ToInt32(param[11].Value.ToString());
                else
                    result = Convert.ToInt32(param[7].Value.ToString());

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
                string err = param[8].Value.ToString();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet RetrieveAll_CHA_License_Details()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@CHA_LICENSE_ID", CHA_LICENSE_ID);
            param[2] = new SqlParameter("@COMPANY_ID", COMPANY_ID);
            param[5] = new SqlParameter("@name", Ename);
            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;
            if (Ename == "delete")
            {
                ds=SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CHA_LICENSE_DETAILS_SELECT", param);
                result = Convert.ToInt32(param[7].Value.ToString());
            }
            else if (Ename == "select_con")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CHA_LICENSE_DETAILS_SELECT", param);
            }
            result = Convert.ToInt32(param[7].Value.ToString());
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
        return ds;
    }

    public DataSet RetrieveAll_Login_Details()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@LOGIN_ID", LOGIN_ID);
            param[1] = new SqlParameter("@COMPANY_LICENSE", COMPANY_LICENSE);
            param[2] = new SqlParameter("@USERNAME", USERNAME);
            param[3] = new SqlParameter("@PWD", PWD);
            param[5] = new SqlParameter("@name", Ename);
            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;
            param[10] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;

            if (Ename == "delete" || Ename == "S" || Ename == "U")
            {
                SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_LOGIN_MASTER_INSERT_UPDATE", param);
                result = Convert.ToInt32(param[7].Value.ToString());
                if(Ename == "S")
                Update_Id = Convert.ToInt32(param[10].Value.ToString());
            }
            else if (Ename == "Select_Login_Details")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_LOGIN_MASTER_INSERT_UPDATE", param);
                result = Convert.ToInt32(param[7].Value.ToString());
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
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }
    public DataSet RetrieveAll_Database_Details()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@DATABASE_ID", DATABASE_ID);
            param[1] = new SqlParameter("@COMPANY_LICENSE", COMPANY_LICENSE);
            param[2] = new SqlParameter("@SERVER_NAME", SERVER_NAME);
            param[3] = new SqlParameter("@DATABASE_NAME", DATABASE_NAME);
            param[4] = new SqlParameter("@LOGIN_NAME", USERNAME);
            param[5] = new SqlParameter("@PWD", PWD);
            param[6] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[11] = new SqlParameter("@SELECT_JOB", SELECT_JOB);
            param[7] = new SqlParameter("@name", Ename);
            param[8] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            param[10] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;
            ds=SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_DATABASE_DETAILS_INSERT_UPDATE", param);
                result = Convert.ToInt32(param[8].Value.ToString());
                if (Ename == "S")
                    Update_Id = Convert.ToInt32(param[10].Value.ToString());
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
        return ds;
    }

    public DataSet RetrieveAll_Groups()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@Company_id", COMPANY_ID);
            param[1] = new SqlParameter("@Company_license", BRANCH);
            param[2] = new SqlParameter("@IMP_EXP", USER_ID);
            param[3] = new SqlParameter("@Mflag", flag);
            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "ALL_COMPANY_DETAILS_SELECT", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }
    public DataSet RetrieveAll_Groups_Admin()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@Company_id", COMPANY_ID);
            param[1] = new SqlParameter("@Company_license", BRANCH);
            param[2] = new SqlParameter("@IMP_EXP", USER_ID);
            param[3] = new SqlParameter("@Mflag", flag);
            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["User_current_comp_db"].ToString(), CommandType.StoredProcedure, "ALL_COMPANY_DETAILS_SELECT", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

    
}