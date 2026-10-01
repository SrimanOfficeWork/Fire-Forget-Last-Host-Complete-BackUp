using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using BussinessObject;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Acc_General_Reports
/// </summary>
public class Acc_General_Reports
{
    DataSet ds = new DataSet();

    public DataSet Acc_GST_Profit_Loss_Select(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@Flag", objUserBL.A1);

            param[1] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[1].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_PROFIT_LOSS_REPORT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }

    public DataSet ACC_GST_BILL_ACCOUNTS_RECEIVABLE_SEARCH_SELECT(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();

        try
        {
            SqlParameter[] param = new SqlParameter[20];

            param[0] = new SqlParameter("@CUS_NAME", objUserBL.A1);
            param[1] = new SqlParameter("@GRAND_TOTAL", objUserBL.A2);
            param[2] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[3] = new SqlParameter("@Basis", objUserBL.A4);
            param[4] = new SqlParameter("@AsOnDate", objUserBL.A5);
            param[9] = new SqlParameter("@Flag", objUserBL.A10);

            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;

            if (objUserBL.A20 == "Summary" || objUserBL.A10 == "Load_CusName")
            {
                ds = Connection.Get_Dataset("ACC_GST_BILL_ACCOUNTS_RECEIVABLE_SEARCH_SELECT", param);
            }
            else if (objUserBL.A20 == "Detail")
            {
                param[10] = new SqlParameter("@startRowIndex", objUserBL.A6);
                param[11] = new SqlParameter("@maximumRows", objUserBL.A7);
                param[12] = new SqlParameter("@totalRows", SqlDbType.Int);
                param[12].Direction = ParameterDirection.Output;
               
                ds = Connection.Get_Dataset("ACC_GST_BILL_ACCOUNTS_RECEIVABLE_DETAIL_SEARCH", param);
                objUserBL.A11 =(param[12].Value!=DBNull.Value&&param[12].Value!=null)? param[12].Value.ToString():"0";
                objUserBL.A12 = param[15].Value.ToString();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }


    public DataSet ACC_GST_BILL_ACCOUNTS_PAYABLE_SEARCH_SELECT(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();

        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@CUS_NAME", objUserBL.A1);
            param[1] = new SqlParameter("@GRAND_TOTAL", objUserBL.A2);
            param[2] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[3] = new SqlParameter("@Basis", objUserBL.A4);
            param[4] = new SqlParameter("@AsOnDate", objUserBL.A5);
            param[5] = new SqlParameter("@startRowIndex", objUserBL.A6);
            param[6] = new SqlParameter("@maximumRows", objUserBL.A7);

            param[9] = new SqlParameter("@Flag", objUserBL.A10);

            param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[10].Direction = ParameterDirection.Output;
            param[11] = new SqlParameter("@totalRows", SqlDbType.Int);
            param[11].Direction = ParameterDirection.Output;

            foreach (SqlParameter p in param)
            {
                if (p != null)
                {
                    System.Diagnostics.Debug.WriteLine(p.ParameterName + " = " + " '" + (p.Value == null || p.Value == DBNull.Value ? "NULL" : p.Value.ToString()) + "',");
                }
            }

            if (objUserBL.A10 == "Load_CusName")
            {
                ds = Connection.Get_Dataset("ACC_GST_BILL_ACCOUNTS_PAYABLE_SEARCH_SELECT", param);
            }
            else if (objUserBL.A12 == "Summary")
            {
                ds = Connection.Get_Dataset("ACC_GST_BILL_ACCOUNTS_PAYABLE_SEARCH_SELECT", param);
            }
            else if (objUserBL.A12 == "Detail")
            {
                ds = Connection.Get_Dataset("ACC_GST_BILL_ACCOUNTS_PAYABLE_DETAIL_SEARCH_flagexcelloadrpt", param);              //detail change proc
            }
            objUserBL.A8 = (param[11].Value != null && param[11].Value != DBNull.Value) ? param[11].Value.ToString() : "0";

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }

    public DataSet ACC_GST_BILL_ACCOUNTS_PAYABLE_SEARCH_SELECT_eXCEL(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();

        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@CUS_NAME", objUserBL.A1);
            param[1] = new SqlParameter("@GRAND_TOTAL", objUserBL.A2);
            param[2] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[3] = new SqlParameter("@Basis", objUserBL.A4);
            param[4] = new SqlParameter("@AsOnDate", objUserBL.A5);

            param[5] = new SqlParameter("@startRowIndex", objUserBL.A6);
            param[6] = new SqlParameter("@maximumRows", objUserBL.A7);

            param[9] = new SqlParameter("@Flag", objUserBL.A10);

            param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[10].Direction = ParameterDirection.Output;

            param[11] = new SqlParameter("@totalRows", SqlDbType.Int);
            param[11].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_BILL_ACCOUNTS_PAYABLE_DETAIL_SEARCH_flagexcelloadrpt", param);

            if (param[6].Value != null && param[6].Value != DBNull.Value)
            {
                string errorMsg = param[6].Value.ToString();

                if (!string.IsNullOrEmpty(errorMsg))
                {
                    Connection.Error_Msg(errorMsg);
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }

    public DataSet Acc_GST_Account_Summary_Report_Daywise(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@Flag", objUserBL.A1);

            param[1] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[1].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_ACCOUNT_SUMMARY_REPORT_DAYWISE", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }
}