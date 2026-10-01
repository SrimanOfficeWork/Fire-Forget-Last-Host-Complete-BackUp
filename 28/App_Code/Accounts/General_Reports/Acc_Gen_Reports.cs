using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;

using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ApplicationBlocks.Data;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Text;

public class Acc_Gen_Reports
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;

    public DataSet Acc_Gen_Rev_Cost_Rpt(Global_variables objUserBL)
    {
        try
        {
           
            SqlParameter[] param = new SqlParameter[16];
            param[0] = new SqlParameter("@FromDate", objUserBL.A1);
            param[1] = new SqlParameter("@ToDate", objUserBL.A2);
            param[2] = new SqlParameter("@JobNo_PS", objUserBL.A3);
            param[3] = new SqlParameter("@PARTY_NAME", objUserBL.A5);
            
            param[10] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[11] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[12] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[13] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());
            param[14] = new SqlParameter("@MFLAG", objUserBL.A4);
            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_JOB_REVENUE_COST_RPT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Acc_Purchase_entry_Rpt(Global_variables objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.A1 != string.Empty && objUserBL.A1 != null)
            {
                arr = objUserBL.A1.Split('/');
                objUserBL.A1 = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.A2 != string.Empty && objUserBL.A2 != null)
            {
                arr2 = objUserBL.A2.Split('/');
                objUserBL.A2 = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[16];
            param[0] = new SqlParameter("@from_date", objUserBL.A1);
            param[1] = new SqlParameter("@to_date ", objUserBL.A2);
            param[2] = new SqlParameter("@Report_Type", objUserBL.A3);
            param[3] = new SqlParameter("@Vendor_name", objUserBL.A5);
            param[4] = new SqlParameter("@Bill_no", objUserBL.A6);
            param[5] = new SqlParameter("@Jobno", objUserBL.A7);
            param[6] = new SqlParameter("@Charge_name", objUserBL.A8);

           
            param[10] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[11] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[12] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[13] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());
            param[14] = new SqlParameter("@MFLAG", objUserBL.A4);
            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;
            //ds = Connection.Get_Dataset("ACC_GST_PURCHASE_ENTRY_REPORT", param);
            ds = Connection.Get_Dataset("ACC_GST_BILL_PURCHASE_ENTRY_REPORT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Acc_sales_outstanding_Rpt(Global_variables objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.A1 != string.Empty && objUserBL.A1 != null)
            {
                arr = objUserBL.A1.Split('/');
                objUserBL.A1 = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.A2 != string.Empty && objUserBL.A2 != null)
            {
                arr2 = objUserBL.A2.Split('/');
                objUserBL.A2 = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[16];
            param[0] = new SqlParameter("@from_date", objUserBL.A1);
            param[1] = new SqlParameter("@to_date ", objUserBL.A2);
            param[2] = new SqlParameter("@Report_Type", objUserBL.A3);
            param[3] = new SqlParameter("@Party_name", objUserBL.A5);
            param[4] = new SqlParameter("@Type", objUserBL.A6);
            param[5] = new SqlParameter("@Jobno", objUserBL.A7);

           
            param[10] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[11] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[12] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[13] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());
            param[14] = new SqlParameter("@MFLAG", objUserBL.A4);
            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;
            

            ds = Connection.Get_Dataset("ACC_GST_SALES_OUTSTANDING_REPORT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Acc_Cash_Book_Rpt(Global_variables objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.A1 != string.Empty && objUserBL.A1 != null)
            {
                arr = objUserBL.A1.Split('/');
                objUserBL.A1 = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.A2 != string.Empty && objUserBL.A2 != null)
            {
                arr2 = objUserBL.A2.Split('/');
                objUserBL.A2 = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[16];
            param[0] = new SqlParameter("@from_date", objUserBL.A1);
            param[1] = new SqlParameter("@to_date ", objUserBL.A2);
            param[2] = new SqlParameter("@Charge_name", objUserBL.A3);
           
            param[10] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[11] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[12] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[13] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());
            param[14] = new SqlParameter("@MFLAG", objUserBL.A4);
            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;


            ds = Connection.Get_Dataset("ACC_GST_CASH_PAYMENT_RECEIPT_REPORT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Acc_Ledger_Transaction_Rpt(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[16];
            param[1] = new SqlParameter("@Charge_name", objUserBL.A1);

            param[10] = new SqlParameter("@MFLAG", objUserBL.A16);
            param[11] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[12] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[13] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[14] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());
            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;


            ds = Connection.Get_Dataset("ACC_GST_LEDGER_TRANSACTION_REPORT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    
    public DataSet Acc_Ledger_Transaction_PL_Rpt(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[16];
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.A3 != string.Empty && objUserBL.A3 != null)
            {
                arr = objUserBL.A3.Split('/');
                objUserBL.A3 = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.A2 != string.Empty && objUserBL.A2 != null)
            {
                arr2 = objUserBL.A2.Split('/');
                objUserBL.A2 = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            param[0] = new SqlParameter("@Charge_name", objUserBL.A1);
            param[1] = new SqlParameter("@from_date", objUserBL.A3);
            param[2] = new SqlParameter("@to_date ", objUserBL.A2);

            param[10] = new SqlParameter("@MFLAG", objUserBL.A16);
            param[11] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[12] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[13] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[14] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());
            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_LEDGERWISE_PL_REPORT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Acc_Payment_outstanding_Rpt(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[16];
            param[1] = new SqlParameter("@Vendor_name", objUserBL.A1);
            param[2] = new SqlParameter("@Type", objUserBL.A2);


            param[10] = new SqlParameter("@MFLAG", objUserBL.A16);
            param[11] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[12] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[13] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[14] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());
            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;


            ds = Connection.Get_Dataset("ACC_GST_PURCHASE_PAYMENT_OUTSTANDING_REPORT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Acc_GSTR2_Rpt_New(Global_variables objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.A1 != string.Empty && objUserBL.A1 != null)
            {
                arr = objUserBL.A1.Split('/');
                objUserBL.A1 = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.A2 != string.Empty && objUserBL.A2 != null)
            {
                arr2 = objUserBL.A2.Split('/');
                objUserBL.A2 = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[16];
            param[0] = new SqlParameter("@from_date", objUserBL.A1);
            param[1] = new SqlParameter("@to_date ", objUserBL.A2);


            param[10] = new SqlParameter("@MFLAG", objUserBL.A16);
            param[11] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[12] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[13] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[14] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());
            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_GSTR_II_REPORT_NEW", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Acc_GSTR2_Rpt(Global_variables objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.A1 != string.Empty && objUserBL.A1 != null)
            {
                arr = objUserBL.A1.Split('/');
                objUserBL.A1 = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.A2 != string.Empty && objUserBL.A2 != null)
            {
                arr2 = objUserBL.A2.Split('/');
                objUserBL.A2 = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[16];
            param[0] = new SqlParameter("@from_date", objUserBL.A1);
            param[1] = new SqlParameter("@to_date ", objUserBL.A2);


            param[10] = new SqlParameter("@MFLAG", objUserBL.A16);
            param[11] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[12] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[13] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[14] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());
            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_GSTR_II_REPORT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Acc_GSTR3_Rpt(Global_variables objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.A1 != string.Empty && objUserBL.A1 != null)
            {
                arr = objUserBL.A1.Split('/');
                objUserBL.A1 = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.A2 != string.Empty && objUserBL.A2 != null)
            {
                arr2 = objUserBL.A2.Split('/');
                objUserBL.A2 = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[16];
            param[0] = new SqlParameter("@from_date", objUserBL.A1);
            param[1] = new SqlParameter("@to_date ", objUserBL.A2);


            param[10] = new SqlParameter("@MFLAG", objUserBL.A16);
            param[11] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[12] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[13] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[14] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());
            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_GSTR_III_REPORT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Acc_Trail_Balance_Rpt(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[16];
            param[10] = new SqlParameter("@MFLAG", objUserBL.A16);
            param[11] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[12] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[13] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[14] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());
            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_TRAIL_BALANCE_REPORT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Acc_Trail_Balance_Rpt_New(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[16];
            param[10] = new SqlParameter("@MFLAG", objUserBL.A16);
            param[11] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[12] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[13] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[14] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());
            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_TRAIL_BALANCE_REPORT_NEW", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Acc_Ledgerwise_Profit_and_Loss_Rpt(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[16];
            param[1] = new SqlParameter("@Charge_name", objUserBL.A1);

            param[10] = new SqlParameter("@MFLAG", objUserBL.A16);
            param[11] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[12] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[13] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[14] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());
            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;


            ds = Connection.Get_Dataset("ACC_GST_LEDGERWISE_PROFIT_AND_LOSS_REPORT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Acc_Balance_Sheet_Rpt(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[16];
            param[10] = new SqlParameter("@MFLAG", objUserBL.A16);
            param[11] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[12] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[13] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[14] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());
            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_BALANCE_SHEET_REPORT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Acc_sales_Summary_Rpt(Global_variables objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.A1 != string.Empty && objUserBL.A1 != null)
            {
                arr = objUserBL.A1.Split('/');
                objUserBL.A1 = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.A2 != string.Empty && objUserBL.A2 != null)
            {
                arr2 = objUserBL.A2.Split('/');
                objUserBL.A2 = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[16];
            param[0] = new SqlParameter("@from_date", objUserBL.A1);
            param[1] = new SqlParameter("@to_date ", objUserBL.A2);
            param[2] = new SqlParameter("@Party_name", objUserBL.A3);
            param[4] = new SqlParameter("@Type", objUserBL.A4);
            param[5] = new SqlParameter("@GROUP_ID", objUserBL.A5);
            param[10] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[11] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[12] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[13] = new SqlParameter("@MFLAG", objUserBL.A16);
            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_SALES_SUMMARY_REPORT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Acc_sales_Ledger_Summary_Rpt(Global_variables objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.A1 != string.Empty && objUserBL.A1 != null)
            {
                arr = objUserBL.A1.Split('/');
                objUserBL.A1 = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.A2 != string.Empty && objUserBL.A2 != null)
            {
                arr2 = objUserBL.A2.Split('/');
                objUserBL.A2 = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[16];
            param[0] = new SqlParameter("@from_date", objUserBL.A1);
            param[1] = new SqlParameter("@to_date ", objUserBL.A2);
            param[2] = new SqlParameter("@Party_name", objUserBL.A3);
            param[3] = new SqlParameter("@Type", objUserBL.A4);
            param[4] = new SqlParameter("@GROUP_ID", objUserBL.A5);
            param[5] = new SqlParameter("@Charge_name", objUserBL.A6);
            param[6] = new SqlParameter("@GROUP_NAME", objUserBL.A7);
            param[7] = new SqlParameter("@SUB_GROUP_NAME", objUserBL.A8);

            param[10] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[11] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[12] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[13] = new SqlParameter("@MFLAG", objUserBL.A16);
            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;


            ds = Connection.Get_Dataset("ACC_SALES_LEGDER_SUMMARY_REPORT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Acc_GSTR1_Rpt(Global_variables objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.A1 != string.Empty && objUserBL.A1 != null)
            {
                arr = objUserBL.A1.Split('/');
                objUserBL.A1 = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.A2 != string.Empty && objUserBL.A2 != null)
            {
                arr2 = objUserBL.A2.Split('/');
                objUserBL.A2 = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[16];
            param[0] = new SqlParameter("@from_date", objUserBL.A1);
            param[1] = new SqlParameter("@to_date ", objUserBL.A2);

            param[9] = new SqlParameter("@COMPANYID", Connection.COMPANYID());
            param[10] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[11] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[12] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[13] = new SqlParameter("@MFLAG", objUserBL.A16);
            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_GSTR_I_REPORT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Acc_Financial_Rpt(Global_variables objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.A1 != string.Empty && objUserBL.A1 != null)
            {
                arr = objUserBL.A1.Split('/');
                objUserBL.A1 = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.A2 != string.Empty && objUserBL.A2 != null)
            {
                arr2 = objUserBL.A2.Split('/');
                objUserBL.A2 = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[16];
            param[0] = new SqlParameter("@from_date", objUserBL.A1);
            param[1] = new SqlParameter("@to_date ", objUserBL.A2);
            param[2] = new SqlParameter("@Ac_No", objUserBL.A3);
            param[4] = new SqlParameter("@Type", objUserBL.A4);
            param[5] = new SqlParameter("@GROUP_ID", objUserBL.A5);

            param[10] = new SqlParameter("@MFLAG", objUserBL.A16);
            param[11] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[12] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[13] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
           
            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_TRANSACTION_REPORT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Acc_Sales_Container_Rpt(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[16];
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.A1 != string.Empty && objUserBL.A1 != null)
            {
                arr = objUserBL.A1.Split('/');
                objUserBL.A1 = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.A2 != string.Empty && objUserBL.A2 != null)
            {
                arr2 = objUserBL.A2.Split('/');
                objUserBL.A2 = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }
            param[1] = new SqlParameter("@from_date", objUserBL.A1);
            param[2] = new SqlParameter("@to_date", objUserBL.A2);

            param[3] = new SqlParameter("@Party_name", objUserBL.A3);
            param[4] = new SqlParameter("@R_O_Jobs", objUserBL.A4);
            param[5] = new SqlParameter("@Imp_Exp", objUserBL.A5);

            param[13] = new SqlParameter("@Flag", objUserBL.A13);
            param[12] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[14] = new SqlParameter("@Company_Lic", Connection.Company_License());
            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_SALES_BILL_JOB_CONTAINER_RPT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Acc_sales_group_Summary_Rpt(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[16];
            param[1] = new SqlParameter("@GROUP_ID", objUserBL.A1);
            param[2] = new SqlParameter("@GROUP_NAME", objUserBL.A2);
            param[3] = new SqlParameter("@SUB_GROUP", objUserBL.A3);

            param[10] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[11] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[12] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[13] = new SqlParameter("@MFLAG", objUserBL.A16);
            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_SALES_GROUP_SUMMARY_REPORT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}