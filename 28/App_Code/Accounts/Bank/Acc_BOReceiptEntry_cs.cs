using System;
using System.Data;
using System.Data.SqlClient;
using BussinessObject;

public class Acc_BOReceiptEntry_cs
{
    DataSet ds = new DataSet();
    public DataSet Acc_Gst_Other_Receipt_Select(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[30];

            param[2] = new SqlParameter("@BR_O_ID", objUserBL.A1);
            param[3] = new SqlParameter("@BR_OTHER_Ch_Id", objUserBL.A2);

            param[4] = new SqlParameter("@BR_O_P", objUserBL.A3);
            param[5] = new SqlParameter("@BR_O_NO", objUserBL.A4);
            param[6] = new SqlParameter("@BR_O_S", objUserBL.A5);
            param[7] = new SqlParameter("@JOB_ID", objUserBL.A6);
            param[8] = new SqlParameter("@BR_O_JOB_AMT", objUserBL.A7);


            param[16] = new SqlParameter("@flag", objUserBL.A40); //Flag
            param[17] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[18] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());

            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;
            param[20] = new SqlParameter("@CHARGE_NAME", objUserBL.A8);
            param[21] = new SqlParameter("@Tax_Type", objUserBL.A9);

            ds = Connection.Get_Dataset("ACC_BR_OTHER_RECEIPT_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    public DataSet BOR_Header_Ins_Upd(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[30];

            param[0] = new SqlParameter("@BR_O_ID", objUserBL.A1);

            param[1] = new SqlParameter("@BR_O_P", objUserBL.A3);
            param[2] = new SqlParameter("@BR_O_NO", objUserBL.A4);
            param[3] = new SqlParameter("@BR_O_S", objUserBL.A5);

            param[4] = new SqlParameter("@BR_O_DATE", Connection.DATE_FORMAT(objUserBL.A6));
            param[5] = new SqlParameter("@POSTING_DATE", Connection.DATE_FORMAT(objUserBL.A7));
            param[6] = new SqlParameter("@BANK_NAME", objUserBL.A8);
            param[7] = new SqlParameter("@FUND_CUR_AMT", objUserBL.A9);
            param[8] = new SqlParameter("@FUND_CUR", objUserBL.A10);
            param[9] = new SqlParameter("@FUND_EX_RATE", objUserBL.A11);

            param[10] = new SqlParameter("@REFERENCE_NUMBER", objUserBL.A12);
            param[11] = new SqlParameter("@REFERENCE_DATE", Connection.DATE_FORMAT(objUserBL.A13));

            param[12] = new SqlParameter("@FUND_TYPE", objUserBL.A14);
            param[13] = new SqlParameter("@Issuer_Bank_info_No", objUserBL.A15);
            param[14] = new SqlParameter("@FUND_DATE", Connection.DATE_FORMAT(objUserBL.A16));

            param[15] = new SqlParameter("@ISSUSER_BANK_NAME", objUserBL.A17);
            param[16] = new SqlParameter("@ISSUSER_BANK_NO", objUserBL.A18);

            param[17] = new SqlParameter("@NARRATION", objUserBL.A19);

            param[18] = new SqlParameter("@FLAG", objUserBL.A40);
            param[19] = new SqlParameter("@User_Name", Connection.Current_User());
            param[20] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[21] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());

            param[25] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[25].Direction = ParameterDirection.Output;

            param[26] = new SqlParameter("@AC_NO", objUserBL.A20);
            param[27] = new SqlParameter("@GLCODE", objUserBL.A21);

            foreach (SqlParameter p in param)
            {
                if (p != null)
                {
                    System.Diagnostics.Debug.WriteLine(
                        p.ParameterName + " = " +
                        (p.Value == null || p.Value == DBNull.Value ? "NULL" : p.Value.ToString()));
                }
            }
            ds = Connection.Get_Dataset("ACC_GST_BOR_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }


    public DataSet BOR_LineDetails_Ins_Upd(Global_variables objUserBL)
    {
        DataSet ds = null;

        try
        {
            SqlParameter[] param = new SqlParameter[]
        {
                new SqlParameter("@BORL_ID", objUserBL.A1),
                new SqlParameter("@BR_O_P", objUserBL.A5),
                new SqlParameter("@BR_O_NO", objUserBL.A6),
                new SqlParameter("@BR_O_S", objUserBL.A7),

                new SqlParameter("@IMP_EXP", objUserBL.A10),
                new SqlParameter("@CHARGE_NAME", objUserBL.A11),
                new SqlParameter("@AMOUNT", objUserBL.A12),
                new SqlParameter("@DR_CR", objUserBL.A13),
                new SqlParameter("@LINKED_GL", objUserBL.A14),
                new SqlParameter("@COSTCENTER", objUserBL.A15),
                new SqlParameter("@ACC_BRANCH", objUserBL.A16),
                new SqlParameter("@NARRATION", objUserBL.A19),

                new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod()),
                new SqlParameter("@CREATEDBY", Connection.Current_User()),
                new SqlParameter("@MODIFIEDBY", Connection.Current_User()),

                new SqlParameter("@User_Name", Connection.Current_User()),
                new SqlParameter("@BRANCH_CODE", Connection.Current_Branch()),
                new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type()),

                //grid
                new SqlParameter("@xmlString_Gen", objUserBL.A49),
                new SqlParameter("@flag", objUserBL.A50),
            new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000)
            {
                Direction = ParameterDirection.Output
            }
        };

            foreach (SqlParameter p in param)
            {
                if (p != null)
                {
                    System.Diagnostics.Debug.WriteLine(
                        p.ParameterName + " = " +
                        (p.Value == null || p.Value == DBNull.Value ? "NULL" : p.Value.ToString()));
                }
            }

            ds = Connection.Get_Dataset("ACC_BOR_LINEDETAILS_INS_UPD", param);

            string errorMsg = Convert.ToString(param[param.Length - 1].Value);

            if (!string.IsNullOrWhiteSpace(errorMsg))
            {
                throw new Exception(errorMsg);
            }

            if (ds == null)
            {
                throw new Exception("No data was returned from the stored procedure.");
            }

            return ds;
        }
        catch (SqlException ex)
        {
            throw new Exception("Database error while saving Bank Other Receipt Line. " + ex.Message, ex);
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to save Bank Other Receipt Line. " + ex.Message, ex);
        }
    }


    public DataSet Acc_Gst_Recipit_Grid_Search(Global_variables objUserBL)
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

            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@from_date", objUserBL.A1);
            param[2] = new SqlParameter("@to_date", objUserBL.A2);
            param[3] = new SqlParameter("@RECIPIT_NO", objUserBL.A3);
            param[4] = new SqlParameter("@PARTY_NAME", objUserBL.A5);

            param[12] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[13] = new SqlParameter("@Flag", objUserBL.A40);
            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;
            if (objUserBL.A4 == "Other_Receipts")
            {
                ds = Connection.Get_Dataset("ACC_OTHER_RECIPIT_ENTRY_NEW_GRID_SEARCH", param);
            }
            else if (objUserBL.A4 == "Cash_Deposit")
            {
                ds = Connection.Get_Dataset("ACC_CASHDEPOSIT_NEW_GRID_SEARCH", param);
            }
            else if (objUserBL.A4 == "All")
            {
                ds = Connection.Get_Dataset("ACC_ALL_RECEIPT_GRID_SEARCH", param);
            }
            objUserBL.A6 = param[14].Value.ToString();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    public DataSet ACC_BankRceipts_OtherReceipts_RPT(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();

        try
        {
            SqlParameter[] param = new SqlParameter[25];


            param[0] = new SqlParameter("@BR_P", objUserBL.A1);
            param[1] = new SqlParameter("@BR_NO", objUserBL.A2);
            param[2] = new SqlParameter("@BR_S", objUserBL.A3);

            param[4] = new SqlParameter("@MFLAG", objUserBL.A25);
            param[3] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, -1);
            param[5].Direction = ParameterDirection.Output;

            foreach (SqlParameter p in param)
            {
                if (p != null)
                {
                    System.Diagnostics.Debug.WriteLine(
                        p.ParameterName + " = " +
                        (p.Value == null || p.Value == DBNull.Value ? "NULL" : p.Value.ToString()));
                }
            }

            ds = Connection.Get_Dataset("ACC_BANKRECEIPTS_OTHERRECEIPTS_RPT", param);     //ACC_BANKPAYMENTS_RPT

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }

    public DataSet ACC_BankRceipts_Cashdeposit_RPT(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();

        try
        {
            SqlParameter[] param = new SqlParameter[25];

            param[0] = new SqlParameter("@BR_P", objUserBL.A1);
            param[1] = new SqlParameter("@BR_NO", objUserBL.A2);
            param[2] = new SqlParameter("@BR_S", objUserBL.A3);

            param[4] = new SqlParameter("@MFLAG", objUserBL.A25);
            param[3] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, -1);
            param[5].Direction = ParameterDirection.Output;

            foreach (SqlParameter p in param)
            {
                if (p != null)
                {
                    System.Diagnostics.Debug.WriteLine(
                        p.ParameterName + " = " +
                        (p.Value == null || p.Value == DBNull.Value ? "NULL" : p.Value.ToString()));
                }
            }

            ds = Connection.Get_Dataset("ACC_BANKRECEIPTS_CASHDEPOSIT_RPT", param);   
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    } 
}

