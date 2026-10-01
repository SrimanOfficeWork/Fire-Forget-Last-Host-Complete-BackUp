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

public class Account_Statement
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;

    public DataSet IMP_EXP_Month(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@StartDate", objUserBL.from_date);
            param[1] = new SqlParameter("@EndDate", objUserBL.todate);
            param[2] = new SqlParameter("@Flag", objUserBL.Flag);
            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_BILL_IMP_EXP_MONTHS", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Select_IMP_INV(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[25];
            param[0] = new SqlParameter("@Branch_No", objUserBL.Branch_No);
            param[1] = new SqlParameter("@Trans_Mode", objUserBL.MODE);
            param[2] = new SqlParameter("@Imp_Name", objUserBL.Imp_Name);
            param[3] = new SqlParameter("@Jobno", objUserBL.JOBNO);
            param[4] = new SqlParameter("@Mflag", objUserBL.Flag);
            param[5] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[6] = new SqlParameter("@Bill_invno", objUserBL.BILL_INV_NO);
            param[7] = new SqlParameter("@FROM_QUOTATION", objUserBL.FROM_QUOTATION);
            param[9] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());
            param[10] = new SqlParameter("@J_ASS_VALUE", objUserBL.Ass_Value);
            param[11] = new SqlParameter("@J_CIF_VALUE", objUserBL.CIF_VALUE);
            param[12] = new SqlParameter("@SHIPMENT_TYPE", objUserBL.SHIPMENT_TYPE);

            param[13] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.JOB_WORKINGPERIOD);
            param[14] = new SqlParameter("@BILL_TYPE", objUserBL.BILL_TYPE);

            param[15] = new SqlParameter("@DEFAULT_CUR", objUserBL.DEFAULT_CUR);
            param[16] = new SqlParameter("@EX_RATE", objUserBL.EX_RATE);

            param[24] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[24].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_BILL_IMPORT_INV_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Select_IMP_INV(Billing_UserBO objUserBL, string constr)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[25];
            param[0] = new SqlParameter("@Branch_No", objUserBL.Branch_No);
            param[1] = new SqlParameter("@Trans_Mode", objUserBL.MODE);
            param[2] = new SqlParameter("@Imp_Name", objUserBL.Imp_Name);
            param[3] = new SqlParameter("@Jobno", objUserBL.JOBNO);
            param[4] = new SqlParameter("@Mflag", objUserBL.Flag);
            param[5] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[6] = new SqlParameter("@Bill_invno", objUserBL.BILL_INV_NO);
            param[7] = new SqlParameter("@FROM_QUOTATION", objUserBL.FROM_QUOTATION);
            param[9] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());

            param[10] = new SqlParameter("@J_ASS_VALUE", objUserBL.Ass_Value);
            param[11] = new SqlParameter("@J_CIF_VALUE", objUserBL.CIF_VALUE);
            param[12] = new SqlParameter("@SHIPMENT_TYPE", objUserBL.SHIPMENT_TYPE);

            param[13] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.JOB_WORKINGPERIOD);
            param[14] = new SqlParameter("@BILL_TYPE", objUserBL.BILL_TYPE);

            param[15] = new SqlParameter("@DEFAULT_CUR", objUserBL.DEFAULT_CUR);
            param[16] = new SqlParameter("@EX_RATE", objUserBL.EX_RATE);

            param[24] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[24].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(constr, CommandType.StoredProcedure, "ACC_GST_BILL_IMPORT_INV_SELECT", param);
            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet BILL_IMPORT_JOB_INV_Head_Rpt(Billing_UserBO objUserBL)//not required in future// once confirm then remove this method
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.from_date != string.Empty && objUserBL.from_date != null)
            {
                arr = objUserBL.from_date.Split('/');
                objUserBL.from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.todate != string.Empty && objUserBL.todate != null)
            {
                arr2 = objUserBL.todate.Split('/');
                objUserBL.todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Importer_name", objUserBL.Imp_Name);
            param[2] = new SqlParameter("@Charge_name", objUserBL.CHARGE_NAME);
            param[3] = new SqlParameter("@from_date", objUserBL.from_date);
            param[4] = new SqlParameter("@to_date", objUserBL.todate);
            param[5] = new SqlParameter("@Location", objUserBL.Branch_No_Loc);
            param[6] = new SqlParameter("@Branch", Connection.Get_Company_Type());
            param[7] = new SqlParameter("@Company_Id", Connection.COMPANYID());

            param[11] = new SqlParameter("@TYPE", objUserBL.TYPE);
            param[12] = new SqlParameter("@Tax_Mode", objUserBL.Tax_Mode);
            param[13] = new SqlParameter("@Flag", objUserBL.Flag);

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset(objUserBL.Sp_Name, param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet ACC_SELECT_SALES_MULTI_HEAD_RPT(Billing_UserBO objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.from_date != string.Empty && objUserBL.from_date != null)
            {
                arr = objUserBL.from_date.Split('/');
                objUserBL.from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.todate != string.Empty && objUserBL.todate != null)
            {
                arr2 = objUserBL.todate.Split('/');
                objUserBL.todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[25];

            param[0] = new SqlParameter("@Flag", objUserBL.Flag);
            param[1] = new SqlParameter("@from_date", objUserBL.from_date);
            param[2] = new SqlParameter("@to_date", objUserBL.todate);

            param[3] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[4] = new SqlParameter("@Company_Id", Connection.COMPANYID());            
            
            
            param[5] = new SqlParameter("@Imp_Exp", objUserBL.Imp_Exp);
            param[6] = new SqlParameter("@Trans_Mode", objUserBL.MODE);
            
            param[7] = new SqlParameter("@Local_Other", objUserBL.Local_Other);
            param[8] = new SqlParameter("@SEZ_Area", objUserBL.SEZ_Area);
            param[9] = new SqlParameter("@Based_On", objUserBL.BASED_ON);

            param[10] = new SqlParameter("@CustomerName", objUserBL.CustomerName);
            param[11] = new SqlParameter("@Location", objUserBL.Branch_No_Loc);

            param[12] = new SqlParameter("@Charge_name", objUserBL.CHARGE_NAME);
            param[13] = new SqlParameter("@Tax_Mode", objUserBL.Tax_Mode);            
            

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset(objUserBL.Sp_Name, param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    //Below 15 methods were done between 01/Apr/2024 and 31/May/2024

    public DataSet Trial_Balance_Head_Rpt(Billing_UserBO objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.from_date != string.Empty && objUserBL.from_date != null)
            {
                arr = objUserBL.from_date.Split('/');
                objUserBL.from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.todate != string.Empty && objUserBL.todate != null)
            {
                arr2 = objUserBL.todate.Split('/');
                objUserBL.todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@From_date", objUserBL.from_date);
            param[1] = new SqlParameter("@Todate", objUserBL.todate);
            param[2] = new SqlParameter("@Service", "1");

            ds = Connection.Get_Dataset(objUserBL.Sp_Name, param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Trial_Balance_Overall(Billing_UserBO objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.from_date != string.Empty && objUserBL.from_date != null)
            {
                arr = objUserBL.from_date.Split('/');
                objUserBL.from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.todate != string.Empty && objUserBL.todate != null)
            {
                arr2 = objUserBL.todate.Split('/');
                objUserBL.todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@From_Date", objUserBL.from_date);
            param[1] = new SqlParameter("@To_Date", objUserBL.todate);
            param[2] = new SqlParameter("@Report_Type", objUserBL.Sp_Name);

            //ds = Connection.Get_Dataset(objUserBL.Sp_Name, param);
            ds = Connection.Get_Dataset("ACC_GST_TRIAL_BALANCE", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Profit_And_Loss_Rpt(Billing_UserBO objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.from_date != string.Empty && objUserBL.from_date != null)
            {
                arr = objUserBL.from_date.Split('/');
                objUserBL.from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.todate != string.Empty && objUserBL.todate != null)
            {
                arr2 = objUserBL.todate.Split('/');
                objUserBL.todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@From_date", objUserBL.from_date);
            param[1] = new SqlParameter("@Todate", objUserBL.todate);
            //param[2] = new SqlParameter("@Service", "1");

            ds = Connection.Get_Dataset(objUserBL.Sp_Name, param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Balance_Sheet_Rpt(Billing_UserBO objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.from_date != string.Empty && objUserBL.from_date != null)
            {
                arr = objUserBL.from_date.Split('/');
                objUserBL.from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.todate != string.Empty && objUserBL.todate != null)
            {
                arr2 = objUserBL.todate.Split('/');
                objUserBL.todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@From_date", objUserBL.from_date);
            param[1] = new SqlParameter("@Todate", objUserBL.todate);
            //param[2] = new SqlParameter("@Service", "1");

            ds = Connection.Get_Dataset(objUserBL.Sp_Name, param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet GSTR3B_Rpt(Billing_UserBO objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.from_date != string.Empty && objUserBL.from_date != null)
            {
                arr = objUserBL.from_date.Split('/');
                objUserBL.from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.todate != string.Empty && objUserBL.todate != null)
            {
                arr2 = objUserBL.todate.Split('/');
                objUserBL.todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@From_date", objUserBL.from_date);
            param[1] = new SqlParameter("@Todate", objUserBL.todate);
            //param[2] = new SqlParameter("@Service", "1");

            ds = Connection.Get_Dataset(objUserBL.Sp_Name, param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Expense_Party_Rpt(Billing_UserBO objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.from_date != string.Empty && objUserBL.from_date != null)
            {
                arr = objUserBL.from_date.Split('/');
                objUserBL.from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.todate != string.Empty && objUserBL.todate != null)
            {
                arr2 = objUserBL.todate.Split('/');
                objUserBL.todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@FromDate", objUserBL.from_date);
            param[1] = new SqlParameter("@ToDate", objUserBL.todate);
            param[2] = new SqlParameter("@Imp_Exp", objUserBL.Expense_Imp_Exp);
            param[3] = new SqlParameter("@Tr_Mode", objUserBL.Expense_Tr_Mode);
            param[4] = new SqlParameter("@Party_Name", objUserBL.Expense_Party_Name);

            ds = Connection.Get_Dataset(objUserBL.Sp_Name, param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Expense_Overall_Rpt(Billing_UserBO objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.from_date != string.Empty && objUserBL.from_date != null)
            {
                arr = objUserBL.from_date.Split('/');
                objUserBL.from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.todate != string.Empty && objUserBL.todate != null)
            {
                arr2 = objUserBL.todate.Split('/');
                objUserBL.todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@FromDate", objUserBL.from_date);
            param[1] = new SqlParameter("@ToDate", objUserBL.todate);
            param[2] = new SqlParameter("@Imp_Exp", objUserBL.Expense_Imp_Exp);
            param[3] = new SqlParameter("@Tr_Mode", objUserBL.Expense_Tr_Mode);
            param[4] = new SqlParameter("@Party_Name", objUserBL.Expense_Party_Name);
            param[5] = new SqlParameter("@Ledger_Name", objUserBL.Expense_Ledger_Name);
            param[6] = new SqlParameter("@Job_No", objUserBL.Expense_Job_Number);
            param[7] = new SqlParameter("@Based_On", objUserBL.Sp_Name);

            ds = Connection.Get_Dataset("ACC_GST_EXPENSE_REPORT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Expense_Ledger_Rpt(Billing_UserBO objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.from_date != string.Empty && objUserBL.from_date != null)
            {
                arr = objUserBL.from_date.Split('/');
                objUserBL.from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.todate != string.Empty && objUserBL.todate != null)
            {
                arr2 = objUserBL.todate.Split('/');
                objUserBL.todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@FromDate", objUserBL.from_date);
            param[1] = new SqlParameter("@ToDate", objUserBL.todate);
            param[2] = new SqlParameter("@Imp_Exp", objUserBL.Expense_Imp_Exp);
            param[3] = new SqlParameter("@Tr_Mode", objUserBL.Expense_Tr_Mode);
            param[4] = new SqlParameter("@Party_Name", objUserBL.Expense_Party_Name);
            param[5] = new SqlParameter("@Ledger_Name", objUserBL.Expense_Ledger_Name);

            ds = Connection.Get_Dataset(objUserBL.Sp_Name, param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Expense_Job_Rpt(Billing_UserBO objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.from_date != string.Empty && objUserBL.from_date != null)
            {
                arr = objUserBL.from_date.Split('/');
                objUserBL.from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.todate != string.Empty && objUserBL.todate != null)
            {
                arr2 = objUserBL.todate.Split('/');
                objUserBL.todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@FromDate", objUserBL.from_date);
            param[1] = new SqlParameter("@ToDate", objUserBL.todate);
            param[2] = new SqlParameter("@Imp_Exp", objUserBL.Expense_Imp_Exp);
            param[3] = new SqlParameter("@Tr_Mode", objUserBL.Expense_Tr_Mode);
            param[4] = new SqlParameter("@Job_No", objUserBL.Expense_Job_Number);

            ds = Connection.Get_Dataset(objUserBL.Sp_Name, param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Expense_Staff_Rpt(Billing_UserBO objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.from_date != string.Empty && objUserBL.from_date != null)
            {
                arr = objUserBL.from_date.Split('/');
                objUserBL.from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.todate != string.Empty && objUserBL.todate != null)
            {
                arr2 = objUserBL.todate.Split('/');
                objUserBL.todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@FromDate", objUserBL.from_date);
            param[1] = new SqlParameter("@ToDate", objUserBL.todate);
            param[2] = new SqlParameter("@Imp_Exp", objUserBL.Expense_Imp_Exp);
            param[3] = new SqlParameter("@Tr_Mode", objUserBL.Expense_Tr_Mode);

            ds = Connection.Get_Dataset(objUserBL.Sp_Name, param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Expense_Select_Dropdown_Rpt(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Customer_Name", objUserBL.Expense_Party_Name);
            param[1] = new SqlParameter("@Flag", objUserBL.Expense_Select_Flag);
            ds = Connection.Get_Dataset("ACC_GST_EXPENSE_SELECT_REPORT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Purchase_Vendor_Rpt(Billing_UserBO objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.from_date != string.Empty && objUserBL.from_date != null)
            {
                arr = objUserBL.from_date.Split('/');
                objUserBL.from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.todate != string.Empty && objUserBL.todate != null)
            {
                arr2 = objUserBL.todate.Split('/');
                objUserBL.todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[7];
            //param[0] = new SqlParameter("@FromDate", objUserBL.from_date);
            //param[1] = new SqlParameter("@ToDate", objUserBL.todate);
            //param[2] = new SqlParameter("@Imp_Exp", objUserBL.Expense_Imp_Exp);
            //param[3] = new SqlParameter("@Job_No", objUserBL.Expense_Job_Number);
            
            
            param[0] = new SqlParameter("@Based_On", "Vendor_Wise");
            param[1] = new SqlParameter("@Imp_Exp", objUserBL.Expense_Imp_Exp);
            param[2] = new SqlParameter("@Vendor_Name", objUserBL.Expense_Party_Name);
            param[3] = new SqlParameter("@Ledger_Name", "");
            param[4] = new SqlParameter("@Job_No", "");
            param[5] = new SqlParameter("@From_Date", objUserBL.from_date);
            param[6] = new SqlParameter("@To_Date", objUserBL.todate);

            ds = Connection.Get_Dataset(objUserBL.Sp_Name, param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Purchase_Ledger_Rpt(Billing_UserBO objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.from_date != string.Empty && objUserBL.from_date != null)
            {
                arr = objUserBL.from_date.Split('/');
                objUserBL.from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.todate != string.Empty && objUserBL.todate != null)
            {
                arr2 = objUserBL.todate.Split('/');
                objUserBL.todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[7];
            //param[0] = new SqlParameter("@FromDate", objUserBL.from_date);
            //param[1] = new SqlParameter("@ToDate", objUserBL.todate);
            //param[2] = new SqlParameter("@Imp_Exp", objUserBL.Expense_Imp_Exp);
            //param[3] = new SqlParameter("@Job_No", objUserBL.Expense_Job_Number);


            param[0] = new SqlParameter("@Based_On", "Ledger_Wise");
            param[1] = new SqlParameter("@Imp_Exp", objUserBL.Expense_Imp_Exp);
            param[2] = new SqlParameter("@Vendor_Name", objUserBL.Expense_Party_Name);
            param[3] = new SqlParameter("@Ledger_Name", objUserBL.Expense_Ledger_Name);
            param[4] = new SqlParameter("@Job_No", "");
            param[5] = new SqlParameter("@From_Date", objUserBL.from_date);
            param[6] = new SqlParameter("@To_Date", objUserBL.todate);

            ds = Connection.Get_Dataset(objUserBL.Sp_Name, param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Purchase_Job_Rpt(Billing_UserBO objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.from_date != string.Empty && objUserBL.from_date != null)
            {
                arr = objUserBL.from_date.Split('/');
                objUserBL.from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.todate != string.Empty && objUserBL.todate != null)
            {
                arr2 = objUserBL.todate.Split('/');
                objUserBL.todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[7];
            //param[0] = new SqlParameter("@FromDate", objUserBL.from_date);
            //param[1] = new SqlParameter("@ToDate", objUserBL.todate);
            //param[2] = new SqlParameter("@Imp_Exp", objUserBL.Expense_Imp_Exp);
            //param[3] = new SqlParameter("@Job_No", objUserBL.Expense_Job_Number);


            param[0] = new SqlParameter("@Based_On", "Job_Wise");
            param[1] = new SqlParameter("@Imp_Exp", objUserBL.Expense_Imp_Exp);
            param[2] = new SqlParameter("@Vendor_Name", "");
            param[3] = new SqlParameter("@Ledger_Name", "");
            param[4] = new SqlParameter("@Job_No", objUserBL.Expense_Job_Number);
            param[5] = new SqlParameter("@From_Date", objUserBL.from_date);
            param[6] = new SqlParameter("@To_Date", objUserBL.todate);

            ds = Connection.Get_Dataset(objUserBL.Sp_Name, param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Payment_Outstanding_Rpt(Billing_UserBO objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.from_date != string.Empty && objUserBL.from_date != null)
            {
                arr = objUserBL.from_date.Split('/');
                objUserBL.from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.todate != string.Empty && objUserBL.todate != null)
            {
                arr2 = objUserBL.todate.Split('/');
                objUserBL.todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@FromDate", objUserBL.from_date);
            param[1] = new SqlParameter("@ToDate", objUserBL.todate);
            param[2] = new SqlParameter("@Imp_Exp", objUserBL.Expense_Imp_Exp);
            param[3] = new SqlParameter("@Vendor_Name", objUserBL.Expense_Party_Name);
            param[4] = new SqlParameter("@Job_No", objUserBL.Expense_Job_Number);

            ds = Connection.Get_Dataset(objUserBL.Sp_Name, param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

}