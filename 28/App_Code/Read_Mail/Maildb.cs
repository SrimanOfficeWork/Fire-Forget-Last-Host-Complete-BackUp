using System;
using System.Linq;
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

public class Maildb
{
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    public DataSet dsMailContents = new DataSet();
    public EmailHistory EmailHistory { get; set; }
    public byte[] Binary { get; set; }
    public string Name { get; set; }
    public string Encoding { get; set; }
    private int _MessageId;

    public int Id { get; set; }
    public string Body { get; set; }
    public DateTime DateTime { get; set; }
    public bool IsNew { get; set; }
    public string FromEmail { get; set; }
    public string FromName { get; set; }
    public string ToEmail { get; set; }
    public string ToName { get; set; }
    public string LastErrorMessage { get; set; }
    public string Mode, Emailid, MessageDetails, JOB_TYPE, SEARCH_TYPE, CUSTOM_HOUSE, Ename, ATTACHMENT, date1,date2;
    public string COMPANY_ID,COMPANY_LIC_ID, IMAP_SERVER, SERVERTYPE, HOSTNAME, USER_NAME, PWD, FOLDER, PORT, ENABLE_SSL, startRowIndex, maximumRows, USER_CREATION_ID, CUSTOM_HOUSE_ID, Path_ext, TRANSPORT_MODE, CLIENT_NAME, FILE_TYPE;

    public string BRANCH_CODE, WORKINGPERIOD, CREATEDON, CREATEDBY, MODIFIEDBY, MODIFIEDON, BRANCH_COMMON,servername;
    public string MAIL_SETTING_ID,Tenantid,Clientid,Clientsecid;
    
    public int result, Update_Id;
    public string FROM_DATE, TO_DATE;
  
    public int MessageId
    {
        get { return _MessageId; }
        set { _MessageId = value; }
    }

    private string _MsgDate;

    public string MsgDate
    {
        get { return _MsgDate; }
        set { _MsgDate = value; }
    }
    private string _MsgFrom;

    public string MsgFrom
    {
        get { return _MsgFrom; }
        set { _MsgFrom = value; }
    }
    private String _Subject;

    public String Subject
    {
        get { return _Subject; }
        set { _Subject = value; }
    }
    private String _Message, _JOB_NO, _JOB_DATE, _BE_NO, _BE_DATE, _SB_NO, _SB_DATE, _IMP_TOTAL_DUTY_VALUE, _IMP_TOTAL_ASSBL_VALUE;
    private string _TR6_CHALLAN_NO, _EDD, _CUSTOMS_DUTY;

    public String Message
    {
        get { return _Message; }
        set { _Message = value; }
    }
    public String JOB_NO
    {
        get { return _JOB_NO; }
        set { _JOB_NO = value; }
    }
    public String JOB_DATE
    {
        get { return _JOB_DATE; }
        set { _JOB_DATE = value; }
    }
    public String BE_NO
    {
        get { return _BE_NO; }
        set { _BE_NO = value; }
    }
    public String BE_DATE
    {
        get { return _BE_DATE; }
        set { _BE_DATE = value; }
    }
    public String SB_NO
    {
        get { return _SB_NO; }
        set { _SB_NO = value; }
    }
    public String SB_DATE
    {
        get { return _SB_DATE; }
        set { _SB_DATE = value; }
    }
    public String IMP_TOTAL_DUTY_VALUE
    {
        get { return _IMP_TOTAL_DUTY_VALUE; }
        set { _IMP_TOTAL_DUTY_VALUE = value; }
    }
    public String IMP_TOTAL_ASSBL_VALUE
    {
        get { return _IMP_TOTAL_ASSBL_VALUE; }
        set { _IMP_TOTAL_ASSBL_VALUE = value; }
    }
    public String WORKING_PERIOD;
    
    private List<MailAttachments> _AttachMents;

    public List<MailAttachments> AttachMents
    {
        get { return _AttachMents; }
        set { _AttachMents = value; }
    }


    public string TR6_CHALLAN_NO
    {
        get { return _TR6_CHALLAN_NO; }
        set { _TR6_CHALLAN_NO = value; }
    }
    public string EDD
    {
        get { return _EDD; }
        set { _EDD = value; }
    }
    public string CUSTOMS_DUTY
    {
        get { return _CUSTOMS_DUTY; }
        set { _CUSTOMS_DUTY = value; }
    }
    public string IRN_no, DRN_no, Doc_Name;

    public Maildb()
    {
        MessageId = 0;
        Message = "";
        Subject = "";
        MsgFrom = "";
        MsgDate = "";
    }

    public DataSet MailSettting_INSERT_UPDATE_SEARCH()
    {
        try
        {      
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@COMPANY_ID", COMPANY_ID);
            param[1] = new SqlParameter("@IMAP_SERVER", IMAP_SERVER);
            param[2] = new SqlParameter("@USER_NAME", USER_NAME);
            param[3] = new SqlParameter("@PWD", PWD);
            param[4] = new SqlParameter("@FOLDER", FOLDER);
            param[5] = new SqlParameter("@PORT", PORT);
            param[6] = new SqlParameter("@Mflag", Ename);
            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;         
            param[9] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[9].Direction = ParameterDirection.Output;
            param[11] = new SqlParameter("@CUSTOM_HOUSE", CUSTOM_HOUSE);

            if (Ename == "S" || Ename == "U" || Ename == "Delete")
            {
                Connection.Get_Dataset("MAIL_SETTING_DETAILS_INSERT_UPDATE", param);
                result = Convert.ToInt32(param[7].Value.ToString());
                if(Ename =="S")
                    Update_Id = Convert.ToInt32(param[9].Value.ToString());
            }
            else if (Ename == "Search")
            {
                ds = Connection.Get_Dataset("MAIL_SETTING_DETAILS_INSERT_UPDATE", param);
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
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet MailSettting_INSERT_UPDATE_SEARCH_New()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[25];
            param[0] = new SqlParameter("@COMPANY_ID", COMPANY_ID);
            param[1] = new SqlParameter("@SERVER_TYPE", SERVERTYPE);
            param[2] = new SqlParameter("@HOST_NAME", HOSTNAME);
            param[3] = new SqlParameter("@USER_NAME", USER_NAME);
            param[4] = new SqlParameter("@PWD", PWD);
            param[5] = new SqlParameter("@FOLDER", FOLDER);
            param[6] = new SqlParameter("@PORT", PORT);
            param[7] = new SqlParameter("@ENABLE_SSL", ENABLE_SSL);
            param[8] = new SqlParameter("@Mflag", Ename);
            param[9] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[10] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[11] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[12] = new SqlParameter("@CREATEDBY", Connection.Current_User());
            param[13] = new SqlParameter("@MODIFIEDBY", Connection.Current_User());
            param[14] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[14].Direction = ParameterDirection.Output;
            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;
            param[16] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[16].Direction = ParameterDirection.Output;
            param[17] = new SqlParameter("@CUSTOM_HOUSE", CUSTOM_HOUSE);
            param[18] = new SqlParameter("@MAIL_SETTING_ID", MAIL_SETTING_ID);
            param[19] = new SqlParameter("@TENANT_ID", Tenantid);
            param[20] = new SqlParameter("@CLIENT_ID", Clientid);
            param[21] = new SqlParameter("@CLIENT_SEC_ID", Clientsecid);


            if (Ename == "S" || Ename == "U" || Ename == "Delete")
            {
                Connection.Get_Dataset("MAIL_SETTING_DETAILS_INSERT_UPDATE_NEW", param);
                result = Convert.ToInt32(param[14].Value.ToString());
                if (Ename == "S")
                    Update_Id = Convert.ToInt32(param[16].Value.ToString());
            }
            else if (Ename == "Search" || Ename == "Search_Distinct")
            {
                ds = Connection.Get_Dataset("MAIL_SETTING_DETAILS_INSERT_UPDATE_NEW", param);
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
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet MailSettting_INSERT_UPDATE_SEARCH_New_Read(string servername)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[25];
            param[0] = new SqlParameter("@COMPANY_ID", Connection.COMPANYID());
            param[1] = new SqlParameter("@SERVER_TYPE", SERVERTYPE);
            param[2] = new SqlParameter("@HOST_NAME", HOSTNAME);
            param[3] = new SqlParameter("@USER_NAME", USER_NAME);
            param[4] = new SqlParameter("@PWD", PWD);
            param[5] = new SqlParameter("@FOLDER", FOLDER);
            param[6] = new SqlParameter("@PORT", PORT);
            param[7] = new SqlParameter("@ENABLE_SSL", ENABLE_SSL);
            param[8] = new SqlParameter("@Mflag", Ename);
            param[9] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[10] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[11] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[12] = new SqlParameter("@CREATEDBY", Connection.Current_User());
            param[13] = new SqlParameter("@MODIFIEDBY", Connection.Current_User());
            param[14] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[14].Direction = ParameterDirection.Output;
            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;
            param[16] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[16].Direction = ParameterDirection.Output;
            param[17] = new SqlParameter("@CUSTOM_HOUSE", CUSTOM_HOUSE);
            param[18] = new SqlParameter("@MAIL_SETTING_ID", MAIL_SETTING_ID);
            param[19] = new SqlParameter("@TENANT_ID", Tenantid);
            param[20] = new SqlParameter("@CLIENT_ID", Clientid);
            param[21] = new SqlParameter("@CLIENT_SEC_ID", Clientsecid);

            if (Ename == "S" || Ename == "U" || Ename == "Delete")
            {
                Connection.Get_Dataset("MAIL_SETTING_DETAILS_INSERT_UPDATE_NEW", param);
                result = Convert.ToInt32(param[14].Value.ToString());
                if (Ename == "S")
                    Update_Id = Convert.ToInt32(param[16].Value.ToString());
            }

            else if (Ename == "Search" || Ename == "Search_Distinct")
            {
                ds = Connection.Get_Dataset("MAIL_SETTING_DETAILS_INSERT_UPDATE_NEW", param);
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
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Retrieve_Mailsetting_Details()
    {
        DataSet ds = new DataSet();
        try
        {
            
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@MAIL_SETTING_ID", MAIL_SETTING_ID);
            param[1] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[9] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[2] = new SqlParameter("@Mflag", Ename);
            param[3] = new SqlParameter("@USER_NAME", USER_NAME);

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
                Connection.Get_Dataset("SP_MAIL_SETTING_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[4].Value.ToString());
            }
            else
            {
               ds=Connection.Get_Dataset("SP_MAIL_SETTING_SEARCH_SELECT", param);
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
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet StoreMailContents(DataSet ds, string EmailId, string mode, string New_Jobtype, string SELECT_BRANCH, string servername)
    {
       
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@Mode", mode);
            param[1] = new SqlParameter("@Emailid", EmailId);
            param[2] = new SqlParameter("@MessageDetails", ds.GetXml().Replace("&#x1D;", ""));
            param[3] = new SqlParameter("@COMPANY_ID", Connection.COMPANYID());
            param[5] = new SqlParameter("@CUSTOM_HOUSE", CUSTOM_HOUSE_ID);
            param[6] = new SqlParameter("@FILE_FORMAT", Path_ext);
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;
            param[11] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[10] = new SqlParameter("@TRANSACTION", New_Jobtype);
            param[12] = new SqlParameter("@SELECT_BRANCH", SELECT_BRANCH);
            dsMailContents = SqlHelper.ExecuteDataset(servername, CommandType.StoredProcedure, "MAIL_CONTENTS_INSERT_UPDATE", param);
            string s = param[8].Value.ToString();
            LastErrorMessage = param[8].Value.ToString();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return dsMailContents;
    }

    public DataSet StoreMailContents_Grid_Search(string mode, string New_Jobtype, string SELECT_BRANCH)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@Mode", mode);
            param[3] = new SqlParameter("@COMPANY_ID", COMPANY_ID);
            param[5] = new SqlParameter("@CUSTOM_HOUSE", CUSTOM_HOUSE_ID);
            param[6] = new SqlParameter("@FILE_FORMAT", Path_ext);
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;
            param[11] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[10] = new SqlParameter("@TRANSACTION", New_Jobtype);
            param[12] = new SqlParameter("@SELECT_BRANCH", SELECT_BRANCH);
            param[13] = new SqlParameter("@CLIENT_NAME", CLIENT_NAME);
            param[14] = new SqlParameter("@FILE_TYPE", FILE_TYPE);

            dsMailContents = Connection.Get_Dataset("MAIL_CONTENTS_INSERT_UPDATE_SEARCH_FILTER", param);
            string s = param[8].Value.ToString();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return dsMailContents;
    }

    public DataTable GetMailContents(string New_Jobtype,string SELECT_BRANCH)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[25];

            param[0] = new SqlParameter("@Mode", Mode);
            param[1] = new SqlParameter("@Emailid", Emailid);
            param[2] = new SqlParameter("@JOB_TYPE", JOB_TYPE);
            param[3] = new SqlParameter("@ATTACHMENT", ATTACHMENT);

            if (FROM_DATE != "")
                param[4] = new SqlParameter("@FROM_DATE", DateTime.Parse(Convert.ToString(FROM_DATE), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            else
            {
                param[4] = new SqlParameter("@FROM_DATE", FROM_DATE);
            }
            if (TO_DATE != "")
                param[5] = new SqlParameter("@TO_DATE", DateTime.Parse(Convert.ToString(toDate(TO_DATE)), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
                else
                {
                    param[5] = new SqlParameter("@TO_DATE", TO_DATE);
                }
            param[6] = new SqlParameter("@CUSTOMS_HOUSE", CUSTOM_HOUSE);
            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@startRowIndex", startRowIndex);
            
            param[10] = new SqlParameter("@maximumRows", maximumRows);

            param[11] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output;
            param[12] = new SqlParameter("@JOB_NO", JOB_NO);
            param[13] = new SqlParameter("@BE_NO", BE_NO);
            param[14] = new SqlParameter("@SB_NO", SB_NO);
            param[15] = new SqlParameter("@COMPANY_ID", COMPANY_ID);
            param[16] = new SqlParameter("@CUSTOM_HOUSE_ID", CUSTOM_HOUSE_ID);
            param[17] = new SqlParameter("@TRANSPORT_MODE", TRANSPORT_MODE);
            param[18] = new SqlParameter("@BRANCHCODE", BRANCH_CODE);
            param[19] = new SqlParameter("@TRANSACTION", New_Jobtype);
            param[20] = new SqlParameter("@SELECT_BRANCH", SELECT_BRANCH);

            ds = Connection.Get_Dataset("MAIL_CONTENTS_SEARCH_SELECT", param);
            result = Convert.ToInt32(param[11].Value.ToString());
            string f =param[8].Value.ToString();
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
            Connection.Error_Msg(ex.Message);
        }
        return ds.Tables[0];
    }

    public DataSet Retrieve_Error_Code_details()
    {

        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@Flag", Ename);
            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "IMPORT_ERROR_CODE_DETAILS", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }

    public string frm_Date(string dt)
    {
        string[] s1 = dt.Split(new string[] { "/" }, StringSplitOptions.None);
        double s = Convert.ToDouble(s1[0].ToString());
        //s = s + 1;
        if (Convert.ToString(s).Length == 1)
            date1 = "0"+Convert.ToString(s);
        else if (Convert.ToString(s).Length == 2)
            date1 =  Convert.ToString(s);

        return date1 = date1 + "/" + s1[1].ToString() + "/" + s1[2].ToString();
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

    public DataSet Esanchit_StoreMailContents(DataSet ds, string EmailId, string mode, string New_Jobtype, string SELECT_BRANCH, string servername)
    {
        
        try
        {
            SqlParameter[] param = new SqlParameter[25];

            param[0] = new SqlParameter("@Mode", mode);
            param[1] = new SqlParameter("@MessageDetails", ds.GetXml().Replace("&#x1D;", "")); // changed this on 26-jun-21  
            //param[1] = new SqlParameter("@MessageDetails", xml_msg);
            param[2] = new SqlParameter("@Emailid", EmailId);
            param[3] = new SqlParameter("@COMPANY_ID", COMPANY_ID);
            param[4] = new SqlParameter("@CUSTOM_HOUSE", CUSTOM_HOUSE_ID);
            param[5] = new SqlParameter("@FILE_FORMAT", Path_ext);
            param[6] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[7] = new SqlParameter("@TRANSACTION", New_Jobtype);
            param[8] = new SqlParameter("@SELECT_BRANCH", SELECT_BRANCH);
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            param[10] = new SqlParameter("@startRowIndex", startRowIndex);
            param[11] = new SqlParameter("@maximumRows", maximumRows);
            param[12] = new SqlParameter("@IRN_no", IRN_no);
            param[13] = new SqlParameter("@DRN_no", DRN_no);
            param[14] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[14].Direction = ParameterDirection.Output;

            dsMailContents = SqlHelper.ExecuteDataset(servername, CommandType.StoredProcedure, "ESANCHIT_MAIL_INSERT_UPDATE", param);

            string s = param[8].Value.ToString();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return dsMailContents;
    }

    public   DataSet GetGroup(string Company_id, string Company_license, string Mflag, string ErrorMsg,   string IMP_EXP)
    {
        DataSet ds = new DataSet();
        SqlParameter[] param = new SqlParameter[8];
        param[1] = new SqlParameter("@Company_id", Company_id);
        param[2] = new SqlParameter("@Company_license", Company_license);
        param[3] = new SqlParameter("@Mflag", Mflag);
        param[4] = new SqlParameter("@ErrorMsg", ErrorMsg);
        param[4].Direction = ParameterDirection.Output;
        param[5] = new SqlParameter("@IMP_EXP", IMP_EXP);
        ds = Connection.Get_Dataset("ALL_COMPANY_DETAILS_SELECT", param);
        return ds;
    }

    public DataSet Esanchit_Filter_Search()
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
            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@IRN_no", IRN_no);
            param[2] = new SqlParameter("@DRN_no", DRN_no);
            param[3] = new SqlParameter("@Doc_Name", Doc_Name);
            param[4] = new SqlParameter("@from_date", FROM_DATE);
            param[5] = new SqlParameter("@to_date", TO_DATE);
            param[6] = new SqlParameter("@Flag", Ename);
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ESANCHIT_DETAILS_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}
