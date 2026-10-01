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
using BussinessObject;


public class Staff_master
{
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    DataSet dtuser = new DataSet();
    DataTable dt = new DataTable();
    ErrorLogs er = new ErrorLogs();
    SqlDataReader dr;
    SqlCommand cmd;
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);
      public int result = 0, UPDATE_ID = 0;

    //public Staff_master()
    //{


  //---------STAFF_MASTER-------- 

    private string _STAFF_ID;
    private string _STAFF_CODE;
    private string _STAFF_FULL_NAME;
    private string _STAFF_NAME;
    private string _EMPLOYEE_ID;
    private string _AADHAR_ID;
    private string _PAN_ID;
    private string _OTHER_ID_TYPE;
    private string _OTHER_ID_NO;
    private string _ENTRY_DATE;
    private string _BANK_DETAILS;
    private string _DOJ;
    private string _EMP_STATUS;
    private string _REMARKS;
    private string _DRIVING_LICENSE; 
    private string _PASSPORT;
    private string _REASON;
    private string _STATUS;
    private string _WORKING_PERIOD;
    private string _MODIFIEDBY;
    private string  _MODIFIEDON;
    private string  _BRANCH_CODE;
    private string _YEAR;
    private string _flag;
    private string _BANK_NAME;
    private string _IFSC_CODE;
    private string _BANK_BRANCH_NAME;
    private string _SWIFT_CODE;
    private string _ACCOUNT_NO;
    private string _BANK_USER_NAME;
    private string _STAFF_PREVIOUS_DEBIT;
    private string _STAFF_PREVIOUS_CREDIT;
    private string _STAFF_WRITE_OFF;
    private string _STAFF_BALANCE;
    private string _STAFF_PR_CR_ID;
    private string _STAFF_ENTRY_DATE;
    private string _startRowIndex, _maximumRows, _totalRows, _Eadcodeid, _EWorking_Period, _Ename;
    private string _ID;
    private string _SUSP_ID;
    private string _SUSP_GIVEN_DATE;
    private string _SUSP_DESCRIPTION;
    private string _SUSP_AMOUNT;




  //---------STAFFMASTER--------
    public string STAFF_ID { get { return _STAFF_ID; } set { _STAFF_ID = value; } }
    public string STAFF_PR_CR_ID { get { return _STAFF_PR_CR_ID; } set { _STAFF_PR_CR_ID = value; } }
    public string STAFF_CODE { get { return _STAFF_CODE; } set { _STAFF_CODE = value; } }
    public string STAFF_FULL_NAME { get { return _STAFF_FULL_NAME; } set { _STAFF_FULL_NAME = value; } }
    public string STAFF_NAME { get { return _STAFF_NAME; } set { _STAFF_NAME = value; } }
    public string EMPLOYEE_ID { get { return _EMPLOYEE_ID; } set { _EMPLOYEE_ID = value; } }
    public string AADHAR_ID { get { return _AADHAR_ID; } set { _AADHAR_ID = value; } }
    public string PAN_ID { get { return _PAN_ID; } set { _PAN_ID = value; } }
    public string OTHER_ID_TYPE { get { return _OTHER_ID_TYPE; } set { _OTHER_ID_TYPE = value; } }
    public string OTHER_ID_NO { get { return _OTHER_ID_NO; } set { _OTHER_ID_NO = value; } }
    public string ENTRY_DATE { get { return _ENTRY_DATE; } set { _ENTRY_DATE = value; } }
    public string BANK_DETAILS { get { return _BANK_DETAILS; } set { _BANK_DETAILS = value; } }
    public string DOJ { get { return _DOJ; } set { _DOJ = value; } }
    public string EMP_STATUS { get { return _EMP_STATUS; } set { _EMP_STATUS = value; } }
    public string REMARKS { get { return _REMARKS; } set { _REMARKS = value; } }
    public string DRIVING_LICENSE { get { return _DRIVING_LICENSE; } set { _DRIVING_LICENSE = value; } }
    public string PASSPORT { get { return _PASSPORT; } set { _PASSPORT = value; } }
    public string REASON { get { return _REASON; } set { _REASON = value; } }
    public string BANK_NAME { get { return _BANK_NAME; } set { _BANK_NAME = value; } }
    public string IFSC_CODE { get { return _IFSC_CODE; } set { _IFSC_CODE = value; } }
    public string BANK_BRANCH_NAME { get { return _BANK_BRANCH_NAME; } set { _BANK_BRANCH_NAME = value; } }
    public string SWIFT_CODE { get { return _SWIFT_CODE; } set { _SWIFT_CODE = value; } }
    public string ACCOUNT_NO { get { return _ACCOUNT_NO; } set { _ACCOUNT_NO = value; } }
    public string BANK_USER_NAME { get { return _BANK_USER_NAME; } set { _BANK_USER_NAME = value; } }
    public string STAFF_PREVIOUS_DEBIT { get { return _STAFF_PREVIOUS_DEBIT; } set { _STAFF_PREVIOUS_DEBIT = value; } }
    public string STAFF_PREVIOUS_CREDIT { get { return _STAFF_PREVIOUS_CREDIT; } set { _STAFF_PREVIOUS_CREDIT = value; } }
    public string STAFF_WRITE_OFF { get { return _STAFF_WRITE_OFF; } set { _STAFF_WRITE_OFF = value; } }
    public string STAFF_BALANCE { get { return _STAFF_BALANCE; } set { _STAFF_BALANCE = value; } }
    public string STAFF_ENTRY_DATE { get { return _STAFF_ENTRY_DATE; } set { _STAFF_ENTRY_DATE = value; } }
    public string STATUS { get { return _STATUS; } set { _STATUS = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string MODIFIEDBY { get { return _MODIFIEDBY; } set { _MODIFIEDBY = value; } }
    public string MODIFIEDON { get { return _MODIFIEDON; } set { _MODIFIEDON = value; } }
    public string flag { get { return _flag; } set { _flag = value; } }
    public string EWorking_Period { get { return _EWorking_Period; } set { _EWorking_Period = value; } }
    public string Ename { get { return _Ename; } set { _Ename = value; } }
    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string totalRows { get { return _totalRows; } set { _totalRows = value; } }
    public string ID { get { return _ID; } set { _ID = value; } }
    public string SUSP_ID { get { return _SUSP_ID; } set { _SUSP_ID = value; } }
    public string SUSP_GIVEN_DATE { get { return _SUSP_GIVEN_DATE; } set { _SUSP_GIVEN_DATE = value; } }
    public string SUSP_DESCRIPTION { get { return _SUSP_DESCRIPTION; } set { _SUSP_DESCRIPTION = value; } }
    public string SUSP_AMOUNT { get { return _SUSP_AMOUNT; } set { _SUSP_AMOUNT = value; } }

 public int Staff_Master_Insert_update()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[45];

            param[0] = new SqlParameter("@STAFF_ID", STAFF_ID);
            param[1] = new SqlParameter("@STAFF_CODE", STAFF_CODE);
            param[2] = new SqlParameter("@STAFF_FULL_NAME", STAFF_FULL_NAME);
            param[3] = new SqlParameter("@STAFF_NAME", STAFF_NAME);
            param[4] = new SqlParameter("@EMPLOYEE_ID", EMPLOYEE_ID);
            param[5] = new SqlParameter("@AADHAR_ID", AADHAR_ID);
            param[6] = new SqlParameter("@PAN_ID", PAN_ID);
            param[7] = new SqlParameter("@OTHER_ID_TYPE", OTHER_ID_TYPE);
            param[8] = new SqlParameter("@OTHER_ID_NO", OTHER_ID_NO);
            param[9] = new SqlParameter("@ENTRY_DATE", DateTime.Parse(ENTRY_DATE == string.Empty ? "01/01/1900" : ENTRY_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[10] = new SqlParameter("@BANK_DETAILS", BANK_DETAILS);
            param[11] = new SqlParameter("@DOJ", DateTime.Parse(DOJ == string.Empty ? "01/01/1900" : DOJ, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[12] = new SqlParameter("@EMP_STATUS", EMP_STATUS);
            param[13] = new SqlParameter("@REMARKS", REMARKS);
            param[31] = new SqlParameter("@DRIVING_LICENSE", DRIVING_LICENSE);
            param[32] = new SqlParameter("@PASSPORT", PASSPORT);
            param[33] = new SqlParameter("@REASON", REASON);
            param[34] = new SqlParameter("@BANK_NAME", BANK_NAME);
            param[35] = new SqlParameter("@IFSC_CODE", IFSC_CODE);
            param[36] = new SqlParameter("@BANK_BRANCH_NAME", BANK_BRANCH_NAME);
            param[37] = new SqlParameter("@SWIFT_CODE", SWIFT_CODE);
            param[38] = new SqlParameter("@ACCOUNT_NO", ACCOUNT_NO);
            param[39] = new SqlParameter("@BANK_USER_NAME", BANK_USER_NAME);
          
           // param[22] = new SqlParameter("@USER_ID", USER_ID);
           // param[23] = new SqlParameter("@DATE_TIME", DateTime.Parse(DATE_TIME, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[24] = new SqlParameter("@STATUS", STATUS);
            param[25] = new SqlParameter("@Mflag", flag);
            param[26] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[27] = new SqlParameter("@YEAR", YEAR);
            param[28] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[29] = new SqlParameter("@MODIFIEDBY", MODIFIEDBY);
            param[30] = new SqlParameter("@MODIFIEDON", DateTime.Parse(MODIFIEDON, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            param[19] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[19].Direction = ParameterDirection.Output;

            param[20] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[20].Direction = ParameterDirection.Output;
            param[21] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[21].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "STAFF_MASTER_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[19].Value.ToString());
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[21].Value.ToString());

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return result;

    }
//SEARCH AND SELECT
 public DataSet RetrieveAll_Staff_MASTER()
    {
        DataSet ds = new DataSet();
        try
        {

            SqlParameter[] param = new SqlParameter[17];

            param[0] = new SqlParameter("@STAFF_ID", STAFF_ID);
            param[1] = new SqlParameter("@WORKING_PERIOD", EWorking_Period);

            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@STAFF_NAME", STAFF_NAME);
            param[9] = new SqlParameter("@EMPLOYEE_ID", EMPLOYEE_ID);

            param[11] = new SqlParameter("@AADHAR_ID", AADHAR_ID);
            //param[11] = new SqlParameter("@ACCOUNT_NO", ACCOUNT_NUMBER);
            param[12] = new SqlParameter("@PAN_ID", PAN_ID);
            param[13] = new SqlParameter("@OTHER_ID_TYPE", OTHER_ID_TYPE);
            param[14] = new SqlParameter("@OTHER_ID_NO", OTHER_ID_NO);


            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;

            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@startRowIndex", startRowIndex);

            param[7] = new SqlParameter("@maximumRows", maximumRows);

            param[8] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;


            if (Ename == "delete" || Ename == "Check_Avail")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "STAFF_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[4].Value.ToString());
            }
            else if (Ename == "select_Staffcode" || Ename == "select_con" || Ename == "select_conwithcode")
            {

                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "STAFF_MASTER_SEARCH_SELECT", param);
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
            er.makeLog(ex.Message);
        }
        return ds;
    }
 //AUTO JOB ID GENERATION 
    public DataSet Load_DDL(Billing_UserBO objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[25];

            param[0] = new SqlParameter("@flag", objUserBL.Flag);
            param[1] = new SqlParameter("@Jobno", objUserBL.JOBNO);
            param[2] = new SqlParameter("@BRANCHCODE", objUserBL.BRANCH_CODE);
            param[3] = new SqlParameter("@Jobtype", objUserBL.BILL_TYPE);
            param[4] = new SqlParameter("@Ref_id", objUserBL.Ref_ID);
            param[5] = new SqlParameter("@FromDate", objUserBL.from_date);
            param[6] = new SqlParameter("@ToDate", objUserBL.todate);
            param[7] = new SqlParameter("@Rptformat", objUserBL.MODE);

            ds = Connection.Get_Dataset("Load_ddl_SP", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }    


// STAFF MASTER PREVIOUS CREDIT DEBIT 
    // INSERT UPDATE


    public int staff_previous_cr_dr_entry_Insert_update()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[30];

            param[0] = new SqlParameter("@STAFF_PR_CR_ID", STAFF_PR_CR_ID);
            param[1] = new SqlParameter("@STAFF_CODE", STAFF_CODE);
            param[2] = new SqlParameter("@STAFF_NAME", STAFF_NAME);
            param[3] = new SqlParameter("@STAFF_PREVIOUS_DEBIT", STAFF_PREVIOUS_DEBIT);
            param[4] = new SqlParameter("@STAFF_PREVIOUS_CREDIT", STAFF_PREVIOUS_CREDIT);
            param[5] = new SqlParameter("@STAFF_WRITE_OFF", STAFF_WRITE_OFF);
            param[6] = new SqlParameter("@STAFF_BALANCE", STAFF_BALANCE);
            param[7] = new SqlParameter("@STAFF_ENTRY_DATE", DateTime.Parse(STAFF_ENTRY_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[8] = new SqlParameter("@REMARKS", REMARKS);
            param[9] = new SqlParameter("@Mflag", flag);
            param[10] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[16] = new SqlParameter("@YEAR", YEAR);
            //param[14] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[15] = new SqlParameter("@MODIFIEDBY", MODIFIEDBY);
            param[17] = new SqlParameter("@STATUS", STATUS);
            //param[14] = new SqlParameter("@MODIFIEDON", DateTime.Parse(MODIFIEDON, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[11] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output;
            param[12] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[12].Direction = ParameterDirection.Output;
            param[13] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[13].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_STAFF_PREVIOUS_CR_DR_ENTRY", param);

            result = Convert.ToInt32(param[11].Value.ToString());
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[13].Value.ToString());

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return result;

    }



    //SEARCH AND SELECT
    public DataSet RetrieveAll_staff_previous_cr_dr_entry()
    {
        DataSet ds = new DataSet();
        try
        {

            SqlParameter[] param = new SqlParameter[20];

            param[0] = new SqlParameter("@STAFF_PR_CR_ID", STAFF_PR_CR_ID);
            param[1] = new SqlParameter("@WORKING_PERIOD", EWorking_Period);

            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@STAFF_NAME", STAFF_NAME);
            param[4] = new SqlParameter("@STAFF_PREVIOUS_DEBIT", STAFF_PREVIOUS_DEBIT);
            param[5] = new SqlParameter("@STAFF_PREVIOUS_CREDIT", STAFF_PREVIOUS_CREDIT);
            //param[11] = new SqlParameter("@ACCOUNT_NO", ACCOUNT_NUMBER);
            //param[6] = new SqlParameter("@STAFF_WRITE_OFF", STAFF_WRITE_OFF);
            //param[7] = new SqlParameter("@STAFF_BALANCE", STAFF_BALANCE);
            //param[8] = new SqlParameter("@STAFF_ENTRY_DATE", STAFF_ENTRY_DATE);
            //param[9] = new SqlParameter("@REMARKS", REMARKS);
            param[10] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[11] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output;
            param[12] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[12].Direction = ParameterDirection.Output;
            param[13] = new SqlParameter("@startRowIndex", startRowIndex);
            param[14] = new SqlParameter("@maximumRows", maximumRows);
            param[15] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[15].Direction = ParameterDirection.Output;
            param[16] = new SqlParameter("@STAFF_CODE", STAFF_CODE);

            if (Ename == "delete" || Ename == "Check_Avail")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_STAFF_PREVIOUS_CR_DR_ENTRY_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[11].Value.ToString());
            }
            else if (Ename == "select_Staffcode" || Ename == "select_con" || Ename == "select_conwithcode")
            {

                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_STAFF_PREVIOUS_CR_DR_ENTRY_SEARCH_SELECT", param);
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
            er.makeLog(ex.Message);
        }
        return ds;
    }
    // staff_name search

    public DataSet Load_Staff_name(Billing_UserBO objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[25];

            param[0] = new SqlParameter("@flag", objUserBL.Flag);
            param[1] = new SqlParameter("@BRANCHCODE", objUserBL.BRANCH_CODE);
            param[2] = new SqlParameter("@STAFF_NAME", objUserBL.STAFF_NAME);
            param[3] = new SqlParameter("@STAFF_PR_CR_ID", STAFF_PR_CR_ID);
            param[4] = new SqlParameter("@ID", ID);
            //param[3] = new SqlParameter("@Ref_id", objUserBL.Ref_ID);
            //param[4] = new SqlParameter("@FromDate", objUserBL.from_date);
            
            
                ds = Connection.Get_Dataset("SP_STAFF_MASTER_NAME_SELECT", param);
            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    // STAFF SUSPENSE ENTRY
    // INSERT UPDATE


    public int staff_Suspense_entry_Insert_update()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[30];

            param[0] = new SqlParameter("@ID", ID);
            param[1] = new SqlParameter("@SUSP_ID", SUSP_ID);
            param[2] = new SqlParameter("@STAFF_CODE", STAFF_CODE);
            param[3] = new SqlParameter("@STAFF_NAME", STAFF_NAME);
            param[4] = new SqlParameter("@SUSP_DESCRIPTION", SUSP_DESCRIPTION);
            param[5] = new SqlParameter("@SUSP_AMOUNT", SUSP_AMOUNT);
            param[6] = new SqlParameter("@SUSP_GIVEN_DATE", DateTime.Parse(SUSP_GIVEN_DATE == string.Empty ? "01/01/1900" : SUSP_GIVEN_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[7] = new SqlParameter("@REMARKS", REMARKS);
            param[8] = new SqlParameter("@Mflag", flag);
            param[9] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[13] = new SqlParameter("@YEAR", YEAR);
            //param[14] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[15] = new SqlParameter("@MODIFIEDBY", MODIFIEDBY);
            param[17] = new SqlParameter("@STATUS", STATUS);
            //param[14] = new SqlParameter("@MODIFIEDON", DateTime.Parse(MODIFIEDON, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[10] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;
            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;
            param[12] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[12].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_STAFF_SUSPSENE_ENTRY_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[10].Value.ToString());
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[12].Value.ToString());

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return result;

    }



    //SEARCH AND SELECT
    public DataSet RetrieveAll_staff_Suspense_entry()
    {
        DataSet ds = new DataSet();
        try
        {

            SqlParameter[] param = new SqlParameter[20];

            param[0] = new SqlParameter("@ID", ID);
            param[1] = new SqlParameter("@WORKING_PERIOD", EWorking_Period);
            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@STAFF_NAME", STAFF_NAME);
            param[4] = new SqlParameter("@SUSP_DESCRIPTION", SUSP_DESCRIPTION);
            param[10] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[11] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output;
            param[12] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[12].Direction = ParameterDirection.Output;
            param[13] = new SqlParameter("@startRowIndex", startRowIndex);
            param[14] = new SqlParameter("@maximumRows", maximumRows);
            param[15] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[15].Direction = ParameterDirection.Output;
            param[16] = new SqlParameter("@STAFF_CODE", STAFF_CODE);
            param[17] = new SqlParameter("@SUSP_ID", SUSP_ID);

            if (Ename == "delete" || Ename == "Check_Avail")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_STAFF_SUSPSENE_ENTRY_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[11].Value.ToString());
            }
            else if (Ename == "select_Staffcode" || Ename == "select_con" || Ename == "select_conwithcode")
            {

                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_STAFF_SUSPSENE_ENTRY_SEARCH_SELECT", param);
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
            er.makeLog(ex.Message);
        }
        return ds;
    }


	}
