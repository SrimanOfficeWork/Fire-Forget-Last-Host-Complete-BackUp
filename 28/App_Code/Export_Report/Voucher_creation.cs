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
using BussinessObject;
/// <summary>
/// Summary description for Voucher_creation
/// </summary>
public class Voucher_creation
{
    Date_Time dt_time = new Date_Time();
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
    public int result, UPDATE_ID = 0, UpdateId = 0;
    

    # region Private Attributes


    private string _Voucher_id;
    private string _Job_no;
    private string _Customer_Name;
    private string _Voucher_no;
    private string _Staff_name;
    private string _Department;
    private string _Voucher_Date;
    private string _Particular;
    private string _Amount;
    private string _Total;
    private string _Incurred;
    private string _Certified;
    private string _Approved;
    private string _Verified;
    private string _flag;
    private string _USER_ID;
    private string _BRANCH_CODE;
    private string _YEAR;
    private string _WORKING_PERIOD, _IMAGE_FILE;
    private string _BRANCH_COMMON;
    private string _Voucher_SUB_ID;
    private string _Xml_D;
    private string _Ename;

    private string _startRowIndex;

    private string _maximumRows;
    private string _totalRows;
    private string _Exportername;
    private string _DOCUMENTS_NAME, _FILE_PATH;
    private string _DOC_ID;
    // import

    private string _imp_Voucher_id;
    private string _imp_Job_no;
    private string _imp_Customer_Name;
    private string _imp_Voucher_no;
    private string _imp_Staff_name;
    private string _imp_Department;
    private string _imp_Voucher_Date;
    private string _imp_Particular;
    private string _imp_Amount;
   // private string _Total;
    private string _imp_Incurred;
    private string _imp_Certified;
    private string _imp_Approved;
    private string _imp_Verified;
    private string _Importername;
    private string _imp_DOCUMENTS_NAME, _imp_FILE_PATH;
    private string _imp_DOC_ID;
    #endregion 
    # region Public Attributes

    public string Voucher_id { get { return _Voucher_id; } set { _Voucher_id = value; } }
    public string Voucher_no { get { return _Voucher_no; } set { _Voucher_no = value; } }
    public string Staff_name { get { return _Staff_name; } set { _Staff_name = value; } }
    public string Job_no { get { return _Job_no; } set { _Job_no = value; } }
    public string Customer_Name { get { return _Customer_Name; } set { _Customer_Name = value; } }
    public string Department { get { return _Department; } set { _Department = value; } }
    public string Voucher_Date { get { return _Voucher_Date; } set { _Voucher_Date = value; } }
    public string Particular { get { return _Particular; } set { _Particular = value; } }
    public string Amount { get { return _Amount; } set { _Amount = value; } }
    public string Total { get { return _Total; } set { _Total = value; } }
    public string Incurred { get { return _Incurred; } set { _Incurred = value; } }
    public string Certified { get { return _Certified; } set { _Certified = value; } }
    public string Approved { get { return _Approved; } set { _Approved = value; } }
    public string Verified { get { return _Verified; } set { _Verified = value; } }
    public string flag { get { return _flag; } set { _flag = value; } }
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string Voucher_SUB_ID { get { return _Voucher_SUB_ID; } set { _Voucher_SUB_ID = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }
    public string BRANCH_COMMON { get { return _BRANCH_COMMON; } set { _BRANCH_COMMON = value; } }
    public string IMAGE_FILE { get { return _IMAGE_FILE; } set { _IMAGE_FILE = value; } }
    public string Ename { get { return _Ename; } set { _Ename = value; } }
    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string totalRows { get { return _totalRows; } set { _totalRows = value; } }
    public string Exportername { get { return _Exportername; } set { _Exportername = value; } }
    public string Xml_D { get { return _Xml_D; } set { _Xml_D = value; } }
    public string DOC_ID { get { return _DOC_ID; } set { _DOC_ID = value; } }
    public string DOCUMENTS_NAME { get { return _DOCUMENTS_NAME; } set { _DOCUMENTS_NAME = value; } }
    public string FILE_PATH { get { return _FILE_PATH; } set { _FILE_PATH = value; } }

    // import
    public string Imp_Voucher_id { get { return _imp_Voucher_id; } set { _imp_Voucher_id = value; } }
    public string Imp_Voucher_no { get { return _imp_Voucher_no; } set { _imp_Voucher_no = value; } }
    public string Imp_Staff_name { get { return _imp_Staff_name; } set { _imp_Staff_name = value; } }
    public string Imp_Job_no { get { return _imp_Job_no; } set { _imp_Job_no = value; } }
    public string Imp_Customer_Name { get { return _imp_Customer_Name; } set { _imp_Customer_Name = value; } }
    public string Imp_Department { get { return _imp_Department; } set { _imp_Department = value; } }
    public string Imp_Voucher_Date { get { return _imp_Voucher_Date; } set { _imp_Voucher_Date = value; } }
    public string Imp_Particular { get { return _imp_Particular; } set { _Particular = value; } }
    public string Imp_Amount { get { return _imp_Amount; } set { _imp_Amount = value; } }
    public string Imp_Incurred { get { return _imp_Incurred; } set { _imp_Incurred = value; } }
    public string Imp_Certified { get { return _imp_Certified; } set { _imp_Certified = value; } }
    public string Imp_Approved { get { return _imp_Approved; } set { _imp_Approved = value; } }
    public string Imp_Verified { get { return _imp_Verified; } set { _imp_Verified = value; } }
    public string Importername { get { return _Importername; } set { _Importername = value; } }
    public string Imp_DOC_ID { get { return _imp_DOC_ID; } set { _imp_DOC_ID = value; } }
    public string Imp_DOCUMENTS_NAME { get { return _imp_DOCUMENTS_NAME; } set { _imp_DOCUMENTS_NAME = value; } }
    public string Imp_FILE_PATH { get { return _imp_FILE_PATH; } set { _imp_FILE_PATH = value; } }
    #endregion
    // Insert & Update

    public DataSet Voucher_Creation_insertupdate()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[50];
            // param[0] = new SqlParameter("@JOBID", JOBID);
            param[32] = new SqlParameter("@Voucher_id", Voucher_id);
            param[35] = new SqlParameter("@Voucher_SUB_ID", Voucher_SUB_ID);
            param[1] = new SqlParameter("@JOBNO", Job_no);
            param[2] = new SqlParameter("@Customer_Name", Customer_Name);
            param[3] = new SqlParameter("@Department", Department);
            param[4] = new SqlParameter("@Voucher_Date", DateTime.Parse(Voucher_Date, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            //param[5] = new SqlParameter("@Particular", Particular);
            //param[6] = new SqlParameter("@Amount", Amount);
            param[7] = new SqlParameter("@Total", Total);
            param[8] = new SqlParameter("@Incurred", Incurred);
            param[9] = new SqlParameter("@Certified", Certified);
            param[10] = new SqlParameter("@Approved", Approved);
            param[11] = new SqlParameter("@Verified", Verified);
            param[25] = new SqlParameter("@USERID", Connection.Current_User());
            param[26] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[27] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());
            //param[34] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[34] = new SqlParameter("@BRANCH_COMMON", Connection.Current_Branch());
            param[28] = new SqlParameter("@Mflag", flag);
            param[29] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[29].Direction = ParameterDirection.Output;
            param[30] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[30].Direction = ParameterDirection.Output;
            param[31] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[31].Direction = ParameterDirection.Output;
            param[36] = new SqlParameter("@xmlString", Xml_D);
            param[37] = new SqlParameter("@Voucher_no", Voucher_no);
            param[38] = new SqlParameter("@Staff_name", Staff_name);
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "VOUCHER_CREATION_DETAILS_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[29].Value.ToString());
            string err = param[30].Value.ToString();
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[31].Value.ToString());

        }
        catch (Exception ex)
        {

            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }


    public DataSet Voucher_Creation_Select(UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[18];

            param[0] = new SqlParameter("@Item_Id", objUserBL.ITEM_ID);
            param[1] = new SqlParameter("@Jobno", objUserBL.JOBNO);
            param[2] = new SqlParameter("@DOC_Refno", objUserBL.File_Refno);
            param[3] = new SqlParameter("@Imp_name", objUserBL.Imp_Name);
            param[16] = new SqlParameter("@Exp_name", objUserBL.Exp_Name);
            param[6] = new SqlParameter("@From_date", objUserBL.From_date);
            param[7] = new SqlParameter("@Todate", objUserBL.Todate);
            param[4] = new SqlParameter("@Branch_common", Connection.Current_Branch());
            param[5] = new SqlParameter("@Flag", objUserBL.flag);

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            param[15] = new SqlParameter("@Mstatus", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("VOUCHER_CREATION_SELECT", param);

            if (objUserBL.flag == "D")
            {
                result = Convert.ToInt32(param[15].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

 public DataSet Voucher_Creation_Doc_Details_Insert()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[20];

            param[0] = new SqlParameter("@DOC_ID", DOC_ID);
            param[1] = new SqlParameter("@CUSTOMER_NAME", Customer_Name);
            param[2] = new SqlParameter("@DOCUMENTS_NAME", DOCUMENTS_NAME);
            param[3] = new SqlParameter("@JOB_NO", Job_no);
            param[4] = new SqlParameter("@FILE_PATH", FILE_PATH);
            param[5] = new SqlParameter("@BRANCHCODE", Connection.Current_Branch());
            //param[6] = new SqlParameter("@NAME", NAME);
            param[7] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            //param[8] = new SqlParameter("@CREATEDON", DateTime.Parse(CREATEDON, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            // param[9] = new SqlParameter("@MODIFIEDBY", MODIFIEDBY);
            // param[10] = new SqlParameter("@MODIFIEDON", DateTime.Parse(MODIFIEDON, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[11] = new SqlParameter("@Mflag", flag);

            param[12] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);

            param[12].Direction = ParameterDirection.Output;

            param[13] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[13].Direction = ParameterDirection.Output;

            param[14] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[14].Direction = ParameterDirection.Output;
            param[15] = new SqlParameter("@VOUCHER_ID", Voucher_id);
            //param[16] = new SqlParameter("@KYC_SUB_ID", KYC_SUB_ID);
            //param[17] = new SqlParameter("@USER_ID", USER_ID);
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "VOUCHER_CREATION_DOCUMENTS_INSERT", param);

            result = Convert.ToInt32(param[12].Value.ToString());
            // if (Mflag == "S")
            UPDATE_ID = Convert.ToInt32(param[14].Value.ToString());
        }
        catch (Exception ex)
        {

            er.makeLog(ex.Message);
        }


        return ds;

    }
 public DataSet Imp_Voucher_Creation_insertupdate()
 {
     try
     {
         SqlParameter[] param = new SqlParameter[50];
         // param[0] = new SqlParameter("@JOBID", JOBID);
         param[32] = new SqlParameter("@Imp_Voucher_id", Imp_Voucher_id);
         param[35] = new SqlParameter("@Voucher_SUB_ID", Voucher_SUB_ID);
         param[1] = new SqlParameter("@JOBNO", Imp_Job_no);
         param[2] = new SqlParameter("@Imp_Customer_Name", Imp_Customer_Name);
         param[3] = new SqlParameter("@Imp_Department", Imp_Department);
         param[4] = new SqlParameter("@Imp_Voucher_Date", DateTime.Parse(Imp_Voucher_Date, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
         //param[5] = new SqlParameter("@Particular", Particular);
         //param[6] = new SqlParameter("@Amount", Amount);
         param[7] = new SqlParameter("@Total", Total);
         param[8] = new SqlParameter("@Imp_Incurred", Imp_Incurred);
         param[9] = new SqlParameter("@Imp_Certified", Imp_Certified);
         param[10] = new SqlParameter("@Imp_Approved", Imp_Approved);
         param[11] = new SqlParameter("@Imp_Verified", Imp_Verified);
         param[25] = new SqlParameter("@USERID", Connection.Current_User());
         param[26] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
         param[27] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());
         //param[34] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
         param[34] = new SqlParameter("@BRANCH_COMMON", Connection.Current_Branch());
         param[28] = new SqlParameter("@Mflag", flag);
         param[29] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
         param[29].Direction = ParameterDirection.Output;
         param[30] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
         param[30].Direction = ParameterDirection.Output;
         param[31] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
         param[31].Direction = ParameterDirection.Output;
         param[36] = new SqlParameter("@xmlString", Xml_D);
         param[37] = new SqlParameter("@Imp_Voucher_no", Imp_Voucher_no);
         param[38] = new SqlParameter("@Imp_Staff_name", Imp_Staff_name);
         ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMP_VOUCHER_CREATION_DETAILS_INSERT_UPDATE", param);

         result = Convert.ToInt32(param[29].Value.ToString());
         string err = param[30].Value.ToString();
         if (flag == "S")
             UPDATE_ID = Convert.ToInt32(param[31].Value.ToString());

     }
     catch (Exception ex)
     {

         ErrorLogs er = new ErrorLogs();
         er.makeLog(ex.Message);
         //throw new ArgumentException(ex.Message);
     }
     return ds;
 }


 public DataSet Imp_Voucher_Creation_Select(UserBO objUserBL)
 {
     try
     {
         SqlParameter[] param = new SqlParameter[18];

         param[0] = new SqlParameter("@Item_Id", objUserBL.ITEM_ID);
         param[1] = new SqlParameter("@Jobno", objUserBL.JOBNO);
         param[2] = new SqlParameter("@DOC_Refno", objUserBL.File_Refno);
         param[3] = new SqlParameter("@Imp_name", objUserBL.Imp_Name);
        // param[16] = new SqlParameter("@Exp_name", objUserBL.Exp_Name);
         param[6] = new SqlParameter("@From_date", objUserBL.From_date);
         param[7] = new SqlParameter("@Todate", objUserBL.Todate);
         param[4] = new SqlParameter("@Branch_common", Connection.Current_Branch());
         param[5] = new SqlParameter("@Flag", objUserBL.flag);

         param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
         param[14].Direction = ParameterDirection.Output;

         param[15] = new SqlParameter("@Mstatus", SqlDbType.NVarChar, 1000);
         param[15].Direction = ParameterDirection.Output;

         ds = Connection.Get_Dataset("IMP_VOUCHER_CREATION_SELECT", param);

         if (objUserBL.flag == "D")
         {
             result = Convert.ToInt32(param[15].Value.ToString());
         }
     }
     catch (Exception ex)
     {
         Connection.Error_Msg(ex.Message);
     }
     return ds;
 }

 public DataSet Imp_Voucher_Creation_Doc_Details_Insert()
 {
     DataSet ds = new DataSet();
     try
     {
         //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
         SqlParameter[] param = new SqlParameter[20];

         param[0] = new SqlParameter("@IMP_DOC_ID", Imp_DOC_ID);
         param[1] = new SqlParameter("@Imp_Customer_Name", Imp_Customer_Name);
         param[2] = new SqlParameter("@IMP_DOCUMENTS_NAME", Imp_DOCUMENTS_NAME);
         param[3] = new SqlParameter("@IMP_JOB_NO", Imp_Job_no);
         param[4] = new SqlParameter("@IMP_FILE_PATH", Imp_FILE_PATH);
         param[5] = new SqlParameter("@BRANCHCODE", Connection.Current_Branch());
         //param[6] = new SqlParameter("@NAME", NAME);
         param[7] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
         //param[8] = new SqlParameter("@CREATEDON", DateTime.Parse(CREATEDON, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
         // param[9] = new SqlParameter("@MODIFIEDBY", MODIFIEDBY);
         // param[10] = new SqlParameter("@MODIFIEDON", DateTime.Parse(MODIFIEDON, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
         param[11] = new SqlParameter("@Mflag", flag);

         param[12] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);

         param[12].Direction = ParameterDirection.Output;

         param[13] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
         param[13].Direction = ParameterDirection.Output;

         param[14] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
         param[14].Direction = ParameterDirection.Output;
         param[15] = new SqlParameter("@Imp_Voucher_id", Imp_Voucher_id);
         //param[16] = new SqlParameter("@KYC_SUB_ID", KYC_SUB_ID);
         //param[17] = new SqlParameter("@USER_ID", USER_ID);
         ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMP_VOUCHER_CREATION_DOCUMENTS_INSERT", param);

         result = Convert.ToInt32(param[12].Value.ToString());
         // if (Mflag == "S")
         UPDATE_ID = Convert.ToInt32(param[14].Value.ToString());
     }
     catch (Exception ex)
     {

         er.makeLog(ex.Message);
     }


     return ds;

 }
}