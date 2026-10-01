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
/// Summary description for Duty_Intimation
/// </summary>
public class Duty_Intimation
{
    SqlDataAdapter da;
    SqlDataReader dr;
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    ErrorLogs er = new ErrorLogs();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    SqlCommand cmd;
    int A1, A2;
    //SqlConnection con = new SqlConnection();
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);
    public int result, UPDATE_ID = 0;

    # region Private Attributes

    private string _DUTY_ID;
    private string _JOBNO;
    private string _FILE_REF_NO;
    private string _IMPORTER_NAME;
    private string _ADDRESS1;
    private string _ADDRESS2;
    private string _ADDRESS3;
    private string _ADDRESS4;
    private string _ADDRESS5;

    private string _ATTENTION;

    private string _SUBJECT;
    private string _DESCRIPTION;
    private string _PACKAGES;
    private string _INVOICE_NO;
    private string _INVOICE_DATE;
    private string _SUPPLIER_NAME;

    private string _GROSSWEIGHT;

     private string _ASSESSABLE_VALUE;
    private string _DUTY_VALUE;
    private string _DIRECT_INDIRECT;
    private string _NAME1;
    private string _NAME2;
    private string _NAME3;
     private string _DD;

     private string _TR6_CHALLAN_NO, _EDD;
   
    private string _flag;
    private string _USER_ID;    
    private string _BRANCH_CODE;
    private string _YEAR;
    private string _WORKING_PERIOD;
    private string _BRANCH_COMMON;

    private string _Ename;

    private string _startRowIndex;

    private string _maximumRows;
    private string _totalRows;


    #endregion

    # region Public Attributes


    public string DUTY_ID { get { return _DUTY_ID; } set { _DUTY_ID = value; } }
    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string FILE_REF_NO { get { return _FILE_REF_NO; } set { _FILE_REF_NO = value; } }    

    public string IMPORTER_NAME { get { return _IMPORTER_NAME; } set { _IMPORTER_NAME = value; } }
    public string ADDRESS1 { get { return _ADDRESS1; } set { _ADDRESS1 = value; } }
    public string ADDRESS2 { get { return _ADDRESS2; } set { _ADDRESS2 = value; } }
    public string ADDRESS3 { get { return _ADDRESS3; } set { _ADDRESS3 = value; } }
    public string ADDRESS4 { get { return _ADDRESS4; } set { _ADDRESS4 = value; } }
    public string ADDRESS5 { get { return _ADDRESS5; } set { _ADDRESS5 = value; } }

    public string ATTENTION { get { return _ATTENTION; } set { _ATTENTION = value; } }
    public string SUBJECT { get { return _SUBJECT; } set { _SUBJECT = value; } }
    public string DESCRIPTION { get { return _DESCRIPTION; } set { _DESCRIPTION = value; } }
    public string PACKAGES { get { return _PACKAGES; } set { _PACKAGES = value; } }
    public string INVOICE_NO { get { return _INVOICE_NO; } set { _INVOICE_NO = value; } }
    public string INVOICE_DATE { get { return _INVOICE_DATE; } set { _INVOICE_DATE = value; } }

    public string SUPPLIER_NAME { get { return _SUPPLIER_NAME; } set { _SUPPLIER_NAME = value; } }
    public string GROSSWEIGHT { get { return _GROSSWEIGHT; } set { _GROSSWEIGHT = value; } }
    public string ASSESSABLE_VALUE { get { return _ASSESSABLE_VALUE; } set { _ASSESSABLE_VALUE = value; } }
    public string DUTY_VALUE { get { return _DUTY_VALUE; } set { _DUTY_VALUE = value; } }
    public string DIRECT_INDIRECT { get { return _DIRECT_INDIRECT; } set { _DIRECT_INDIRECT = value; } }
    public string NAME1 { get { return _NAME1; } set { _NAME1 = value; } }
    public string NAME2 { get { return _NAME2; } set { _NAME2 = value; } }
    public string NAME3 { get { return _NAME3; } set { _NAME3 = value; } }
    public string DD { get { return _DD; } set { _DD = value; } }

    public string TR6_CHALLAN_NO { get { return _TR6_CHALLAN_NO; } set { _TR6_CHALLAN_NO = value; } }
    public string EDD { get { return _EDD; } set { _EDD = value; } }

    public string flag { get { return _flag; } set { _flag = value; } }
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }
    public string BRANCH_COMMON { get { return _BRANCH_COMMON; } set { _BRANCH_COMMON = value; } }
    
    public string Ename { get { return _Ename; } set { _Ename = value; } }

    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string totalRows { get { return _totalRows; } set { _totalRows = value; } }

    #endregion

    #region Insert & Update

    public int Duty_Intimation_insertupdate()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[50];
            param[1] = new SqlParameter("@JOBNO", JOBNO);

            param[2] = new SqlParameter("@FILE_REF_NO", FILE_REF_NO);          

            param[3] = new SqlParameter("@IMPORTER_NAME", IMPORTER_NAME);

            param[4] = new SqlParameter("@ADDRESS1", ADDRESS1);

            param[5] = new SqlParameter("@ADDRESS2", ADDRESS2);

            param[6] = new SqlParameter("@ADDRESS3", ADDRESS3);

            param[7] = new SqlParameter("@ADDRESS4", ADDRESS4);

            param[8] = new SqlParameter("@ADDRESS5", ADDRESS5);

            param[9] = new SqlParameter("@ATTENTION", ATTENTION);

            param[10] = new SqlParameter("@SUBJECT", SUBJECT);

            param[11] = new SqlParameter("@DESCRIPTION", DESCRIPTION);

            param[12] = new SqlParameter("@PACKAGES", PACKAGES);

            param[13] = new SqlParameter("@INVOICE_NO", INVOICE_NO);

            param[14] = new SqlParameter("@INVOICE_DATE", DateTime.Parse(INVOICE_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            param[15] = new SqlParameter("@SUPPLIER_NAME", SUPPLIER_NAME);

            param[16] = new SqlParameter("@GROSSWEIGHT", GROSSWEIGHT);

            param[17] = new SqlParameter("@ASSESSABLE_VALUE", ASSESSABLE_VALUE);

            param[18] = new SqlParameter("@DUTY_VALUE", DUTY_VALUE);

            param[19] = new SqlParameter("@DIRECT_INDIRECT", DIRECT_INDIRECT);

            param[20] = new SqlParameter("@NAME1", NAME1);

            param[21] = new SqlParameter("@NAME2", NAME2);

            param[22] = new SqlParameter("@NAME3", NAME3);

            param[23] = new SqlParameter("@DD", DD);

            param[33] = new SqlParameter("@TR6_CHALLAN_NO", TR6_CHALLAN_NO);

            param[34] = new SqlParameter("@EDD", EDD);  

            param[24] = new SqlParameter("@USERID", USER_ID);

            param[25] = new SqlParameter("@BRANCHCODE", BRANCH_CODE);

            param[31] = new SqlParameter("@YEAR", YEAR);

            param[26] = new SqlParameter("@WORKINGPERIOD", WORKING_PERIOD);

            param[32] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);

            param[27] = new SqlParameter("@Mflag", flag);

            param[28] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[28].Direction = ParameterDirection.Output;

            param[29] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);

            param[29].Direction = ParameterDirection.Output;
            param[30] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[30].Direction = ParameterDirection.Output;


            SqlHelper.ExecuteNonQuery(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "DUTY_INTIMATION_LETTER_DETAILS_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[28].Value.ToString());
            string err = param[29].Value.ToString();
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[30].Value.ToString());

        }
        catch (Exception ex)
        {

            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return result;
    }

    #endregion
    public DataSet EmailsRead()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", JOBNO);
            param[1] = new SqlParameter("@name", Ename);
            param[2] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);

            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMP_DUTY_INTIMATION", param);
            string err = param[5].Value.ToString();

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }


}