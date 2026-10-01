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


public class BE_Entry
{
    
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);

    int A1, A2;
    public int result = 0, UPDATE_ID = 0;

    private string _BE_ID,_BE_JOBNO,_BE_NO_OF_PACKAGES,_BE_PACKAGE_CODE,_BE_WEIGHT,_BE_UNIT_CODE,_BE_TRANSPORT_MODE,_BE_TYPE,_BE_NO,_BE_DATE,_BE_ASSESSABLE_VALUE
                   ,_BE_DUTY,_BE_INBOND_NO,_BE_INBOND_DATE,_BE_WAREHOUSE_CUSTOMS,_BE_WAREHOUSE_CUSTOMS_CODE,_USER_ID,_DATE_TIME,_STATUS,_BRANCH_CODE,_YEAR
                   , _WORKING_PERIOD, _BRANCH_COMMON, _flag, _Ename, _Expense_Amt, _TR_NO, _LATE_FEES, _INTEREST;

   
    public string BE_ID { get { return _BE_ID; } set { _BE_ID = value; } }
    public string BE_JOBNO { get { return _BE_JOBNO; } set { _BE_JOBNO = value; } }
    public string BE_NO_OF_PACKAGES { get { return _BE_NO_OF_PACKAGES; } set { _BE_NO_OF_PACKAGES = value; } }
    public string BE_PACKAGE_CODE { get { return _BE_PACKAGE_CODE; } set { _BE_PACKAGE_CODE = value; } }
    public string BE_WEIGHT { get { return _BE_WEIGHT; } set { _BE_WEIGHT = value; } }
    public string BE_UNIT_CODE { get { return _BE_UNIT_CODE; } set { _BE_UNIT_CODE = value; } }
    public string BE_TRANSPORT_MODE { get { return _BE_TRANSPORT_MODE; } set { _BE_TRANSPORT_MODE = value; } }
    public string BE_TYPE { get { return _BE_TYPE; } set { _BE_TYPE = value; } }
    public string BE_NO { get { return _BE_NO; } set { _BE_NO = value; } }
    public string BE_DATE { get { return _BE_DATE; } set { _BE_DATE = value; } }
    public string BE_ASSESSABLE_VALUE { get { return _BE_ASSESSABLE_VALUE; } set { _BE_ASSESSABLE_VALUE = value; } }
    public string BE_DUTY { get { return _BE_DUTY; } set { _BE_DUTY = value; } }
    public string BE_INBOND_NO { get { return _BE_INBOND_NO; } set { _BE_INBOND_NO = value; } }
    public string BE_INBOND_DATE { get { return _BE_INBOND_DATE; } set { _BE_INBOND_DATE = value; } }
    public string BE_WAREHOUSE_CUSTOMS { get { return _BE_WAREHOUSE_CUSTOMS; } set { _BE_WAREHOUSE_CUSTOMS = value; } }
    public string BE_WAREHOUSE_CUSTOMS_CODE { get { return _BE_WAREHOUSE_CUSTOMS_CODE; } set { _BE_WAREHOUSE_CUSTOMS_CODE = value; } }
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }
    public string BRANCH_COMMON { get { return _BRANCH_COMMON; } set { _BRANCH_COMMON = value; } }
    public string flag { get { return _flag; } set { _flag = value; } }
    public string Ename { get { return _Ename; } set { _Ename = value; } }
    public string Expense_Amt { get { return _Expense_Amt; } set { _Expense_Amt = value; } }
    public string TR_NO { get { return _TR_NO; } set { _TR_NO = value; } }
    public string LATE_FEES { get { return _LATE_FEES; } set { _LATE_FEES = value; } }
    public string INTEREST { get { return _INTEREST; } set { _INTEREST = value; } }


    public int BE_Entry_Details_insertupdate()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[40];
            param[1] = new SqlParameter("@BE_ID", BE_ID);
            param[2] = new SqlParameter("@BE_JOBNO", BE_JOBNO);
            param[3] = new SqlParameter("@BE_NO_OF_PACKAGES", BE_NO_OF_PACKAGES);
            param[4] = new SqlParameter("@BE_PACKAGE_CODE", BE_PACKAGE_CODE);
            param[5] = new SqlParameter("@BE_WEIGHT", BE_WEIGHT);
            param[6] = new SqlParameter("@BE_UNIT_CODE", BE_UNIT_CODE);
            param[7] = new SqlParameter("@BE_TRANSPORT_MODE", BE_TRANSPORT_MODE);
            param[8] = new SqlParameter("@BE_TYPE", BE_TYPE);
            param[9] = new SqlParameter("@BE_NO", BE_NO);
            param[10] = new SqlParameter("@BE_DATE", DateTime.Parse(BE_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[12] = new SqlParameter("@BE_ASSESSABLE_VALUE", BE_ASSESSABLE_VALUE);
            param[13] = new SqlParameter("@BE_DUTY", BE_DUTY);
            param[14] = new SqlParameter("@BE_INBOND_NO", BE_INBOND_NO);
            param[15] = new SqlParameter("@BE_INBOND_DATE", DateTime.Parse(BE_INBOND_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[16] = new SqlParameter("@BE_WAREHOUSE_CUSTOMS", BE_WAREHOUSE_CUSTOMS);
            param[17] = new SqlParameter("@BE_WAREHOUSE_CUSTOMS_CODE", BE_WAREHOUSE_CUSTOMS_CODE);
            param[18] = new SqlParameter("@EXPENSE_AMT", Expense_Amt);
            param[33] = new SqlParameter("@TR_NO", TR_NO);
            param[34] = new SqlParameter("@LATE_FEES", LATE_FEES);
            param[35] = new SqlParameter("@INTEREST", INTEREST);

            param[20] = new SqlParameter("@USER_ID", USER_ID);
            param[21] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[22] = new SqlParameter("@YEAR", YEAR);
            param[23] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

            param[24] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
            param[25] = new SqlParameter("@Mflag", flag);

            param[27] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[27].Direction = ParameterDirection.Output;
            param[28] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[28].Direction = ParameterDirection.Output;
           
            param[32] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[32].Direction = ParameterDirection.Output;

            Connection.Get_Dataset("BE_ENTRY_DETAILS_INSERT_UPDATE", param);
            result = Convert.ToInt32(param[27].Value.ToString());

            if (flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[32].Value.ToString());
            }
          
        }
        catch (Exception ex)
        {
            Err_Msg(ex.Message);
        }
        return result;
    }

    public DataSet RetrieveAll_BE_Entry_Details()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@JOBID", BE_ID);
            param[5] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;
          

            if (Ename == "delete")
            {
                Connection.Get_Dataset("BE_ENTRY_DETAILS_SELECT", param);
                result = Convert.ToInt32(param[7].Value.ToString());
            }
            else if (Ename == "select_Details" || Ename == "select_Warehouse")
            {
                ds = Connection.Get_Dataset("BE_ENTRY_DETAILS_SELECT", param);
                result = Convert.ToInt32(param[7].Value.ToString());
                string s = param[8].Value.ToString();
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                    }
                    else
                    {
                        ds = Return_Value();
                    }

                }
                else
                {
                    ds = Return_Value();
                }
            }
            else
            {
                ds = Connection.Get_Dataset("BE_ENTRY_DETAILS_SELECT", param);
                result = Convert.ToInt32(param[7].Value.ToString());
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                    }
                    else
                    {
                        ds = Return_Value();
                    }
                }
                else
                {
                   ds= Return_Value();
                }
            }
        }
        catch (Exception ex)
        {
            Err_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet RetrieveAll_BE_Entry_Details(string Con_str)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@JOBID", BE_ID);
            param[5] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(Con_str, CommandType.StoredProcedure, "BE_ENTRY_DETAILS_SELECT", param);
            result = Convert.ToInt32(param[7].Value.ToString());
            string s = param[8].Value.ToString();
        }
        catch (Exception ex)
        {
            Err_Msg(ex.Message);
        }
        return ds;
    }
    private void Err_Msg( string Error)
    {
        Connection.Error_Msg(Error);
    }

    private DataSet Return_Value()
    {
        ds.Tables.Add(dt);
        return ds;
    }

}