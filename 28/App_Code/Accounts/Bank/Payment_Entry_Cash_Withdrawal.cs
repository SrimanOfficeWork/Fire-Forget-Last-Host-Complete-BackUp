using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using BussinessObject;
using System.Web.UI.WebControls;

public class Payment_Entry_Cash_Withdrawal
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;
    private string _xmlString;
    # region ClearFunction
    public void ResetFields(ControlCollection pageControls)
    {
        foreach (Control contl in pageControls)
        {
            string strCntName = (contl.GetType()).Name;
            switch (strCntName)
            {
                case "TextBox":
                    TextBox tbSource = (TextBox)contl;
                    tbSource.Text = "";
                    break;
                //case "RadioButtonList":
                //    RadioButtonList rblSource = (RadioButtonList)contl;
                //    rblSource.SelectedIndex = -1;
                //    break;
                case "DropDownList":
                    DropDownList ddlSource = (DropDownList)contl;
                    ddlSource.SelectedIndex = -1;

                    break;

                case "CheckBox":
                    CheckBox chkSource = (CheckBox)contl;
                    chkSource.Checked = false;
                    break;

            }

            ResetFields(contl.Controls);
        }
    }

    public void ResetFields_without_dropdown(ControlCollection pageControls)
    {
        foreach (Control contl in pageControls)
        {
            string strCntName = (contl.GetType()).Name;
            switch (strCntName)
            {
                case "TextBox":
                    TextBox tbSource = (TextBox)contl;
                    tbSource.Text = "";
                    break;

                //case "DropDownList":
                //    DropDownList ddlSource = (DropDownList)contl;
                //    ddlSource.SelectedIndex = -1;

                //    break;

                case "CheckBox":
                    CheckBox chkSource = (CheckBox)contl;
                    chkSource.Checked = false;
                    break;

            }

            ResetFields(contl.Controls);
        }
    }


    # endregion
    public string xmlString { get { return _xmlString; } set { _xmlString = value; } }
    public DataSet Acc_Gst_Payment_Cash_Withdrawal_Select(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[30];

            param[2] = new SqlParameter("@BP_C_ID", objUserBL.A1);
            param[3] = new SqlParameter("@BP_Cash_Id", objUserBL.A2);

            param[4] = new SqlParameter("@BP_C_P", objUserBL.A3);
            param[5] = new SqlParameter("@BP_C_NO", objUserBL.A4);
            param[6] = new SqlParameter("@BP_C_S", objUserBL.A5);
            param[7] = new SqlParameter("@JOB_ID", objUserBL.A6);
            param[8] = new SqlParameter("@BP_C_JOB_AMT", objUserBL.A7);


            param[16] = new SqlParameter("@flag", objUserBL.A40); //Flag
            param[17] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[18] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());

            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_PAYMENT_ENTRY_CASH_WITHDRAWAL_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    //ACC_GST_BR_RECEIPT_ENTRY
    public DataSet Acc_Gst_Payment_Cash_Withdrawal_Ins_Upd(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[43];
            param[1] = new SqlParameter("@BP_C_ID", objUserBL.A1);
            param[2] = new SqlParameter("@R_C", objUserBL.A2);
            param[3] = new SqlParameter("@BP_C_P", objUserBL.A3);
            param[4] = new SqlParameter("@BP_C_NO", objUserBL.A4);
            param[5] = new SqlParameter("@BP_C_S", objUserBL.A5);

            param[6] = new SqlParameter("@BP_C_DATE", Connection.DATE_FORMAT(objUserBL.A6));

            param[7] = new SqlParameter("@POSTING_DATE", Connection.DATE_FORMAT(objUserBL.A7));
            param[8] = new SqlParameter("@BANK_NAME", objUserBL.A8);



            param[32] = new SqlParameter("@AC_NO", objUserBL.A9);
            param[16] = new SqlParameter("@FUND_CUR", objUserBL.A10);
            param[17] = new SqlParameter("@FUND_EX_RATE", objUserBL.A11);
            param[18] = new SqlParameter("@FUND_CUR_AMT", objUserBL.A12);
            param[19] = new SqlParameter("@FUND_INR_AMT", objUserBL.A13);

            param[23] = new SqlParameter("@NARRATION", objUserBL.A14);
            param[35] = new SqlParameter("@REFERANCE_NUMBER", objUserBL.A15);
            param[36] = new SqlParameter("@REFERENCE_DATE", Connection.DATE_FORMAT(objUserBL.A16));
            param[24] = new SqlParameter("@JOB_LICENSE", objUserBL.A17);
            param[25] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.A18);

            param[26] = new SqlParameter("@flag", objUserBL.A19);
            param[27] = new SqlParameter("@User_Name", Connection.Current_User());
            param[28] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[29] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[30] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[31] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[31].Direction = ParameterDirection.Output;




            ds = Connection.Get_Dataset("ACC_GST_PAYMENT_ENTRY_CASH_WITHDRAWAL_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    //CASHWITHDRAWAL nEW
    public DataSet Acc_CashWithdrawal_Select(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[30];

            param[2] = new SqlParameter("@BP_C_ID", objUserBL.A1);
            param[3] = new SqlParameter("@BP_Cash_Id", objUserBL.A2);

            param[4] = new SqlParameter("@BP_C_P", objUserBL.A3);
            param[5] = new SqlParameter("@BP_C_NO", objUserBL.A4);
            param[6] = new SqlParameter("@BP_C_S", objUserBL.A5);
            param[7] = new SqlParameter("@JOB_ID", objUserBL.A6);
            param[8] = new SqlParameter("@BP_C_JOB_AMT", objUserBL.A7);


            param[16] = new SqlParameter("@flag", objUserBL.A40); //Flag
            param[17] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[18] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());

            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_CASHWITHDRAWAL_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    //cashwithdraw header page section insert update
    public DataSet Acc_Gst_Payment_Grid_Search(Global_variables objUserBL)
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
            param[0] = new SqlParameter("@Payment_NO", objUserBL.A3);
            param[1] = new SqlParameter("@from_date", objUserBL.A1);
            param[2] = new SqlParameter("@to_date", objUserBL.A2);
            param[3] = new SqlParameter("@PARTY_NAME", objUserBL.A5);

            param[12] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[13] = new SqlParameter("@Flag", objUserBL.A40);
            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;
          
            

            if (objUserBL.A4 == "Payment_Creditors")
            {
                ds = Connection.Get_Dataset("ACC_GST_PAYMENT_ENTRY_GRID_SEARCH", param);
            }
            else if (objUserBL.A4 == "Other_Payment_New")
            {
                ds = Connection.Get_Dataset("ACC_OTHERPAYMENTS_NEW_GRID_SEARCH", param);
            }
            else if (objUserBL.A4 == "Cash_Withdrawal_New")
            {
                ds = Connection.Get_Dataset("ACC_CASHWITHDRAWAL_NEW_GRID_SEARCH", param);
            }
            else if (objUserBL.A4 == "All")
            {
                ds = Connection.Get_Dataset("ACC_ALL_PAYMENT_SEARCH", param);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    public DataSet Acc_CashWithdrawal_Ins_Upd(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[35];

            param[1] = new SqlParameter("@BP_C_ID", objUserBL.A1);

            param[3] = new SqlParameter("@BP_C_P", objUserBL.A3);
            param[4] = new SqlParameter("@BP_C_NO", objUserBL.A4);
            param[5] = new SqlParameter("@BP_C_S", objUserBL.A5);

            param[8] = new SqlParameter("@BANK_NAME", objUserBL.A8);
            param[9] = new SqlParameter("@AC_NO", objUserBL.A24);
            param[10] = new SqlParameter("@GL_CODE", objUserBL.A23);

            param[11] = new SqlParameter("@FUND_CUR", objUserBL.A10);            
            param[12] = new SqlParameter("@FUND_EX_RATE", string.IsNullOrWhiteSpace(objUserBL.A11) ?
                        (object)DBNull.Value : Convert.ToDecimal(objUserBL.A11));
            
            param[13] = new SqlParameter("@FUND_CUR_AMT",
    string.IsNullOrWhiteSpace(objUserBL.A9)
        ? (object)DBNull.Value
        : Convert.ToDecimal(objUserBL.A9));

            param[14] = new SqlParameter("@REFERENCE_NUMBER", objUserBL.A12);
            param[16] = new SqlParameter("@INSTRUMENT_TYPE", objUserBL.A14);
            param[17] = new SqlParameter("@INSTRUMENT_NO", objUserBL.A15);            

            param[19] = new SqlParameter("@PAYEE_TYPE", objUserBL.A17);
            param[20] = new SqlParameter("@PAYEE_NAME", objUserBL.A18);

            param[21] = new SqlParameter("@CHEQUE_TYPE", objUserBL.A19);
            param[22] = new SqlParameter("@PAYMENT_MODE", objUserBL.A20);
            //param[23] = new SqlParameter("@NOT_OVER_AMOUNT", objUserBL.A21);
            param[23] = new SqlParameter("@NOT_OVER_AMOUNT",
    string.IsNullOrWhiteSpace(objUserBL.A21)
        ? (object)DBNull.Value
        : Convert.ToDecimal(objUserBL.A21));

            param[24] = new SqlParameter("@NARRATION", objUserBL.A22);

            //param[25] = new SqlParameter("@flag", objUserBL.A28);
            param[25] = new SqlParameter("@flag", objUserBL.A40);

            param[28] = new SqlParameter("@User_Name", Connection.Current_User());
            param[26] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[27] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());



            param[6] = new SqlParameter("@BP_C_DATE",
    string.IsNullOrWhiteSpace(objUserBL.A6)
        ? (object)DBNull.Value
        : DateTime.ParseExact(objUserBL.A6, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));

            param[7] = new SqlParameter("@POSTING_DATE",
                string.IsNullOrWhiteSpace(objUserBL.A7)
                    ? (object)DBNull.Value
                    : DateTime.ParseExact(objUserBL.A7, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));

            param[15] = new SqlParameter("@REFERENCE_DATE",
                string.IsNullOrWhiteSpace(objUserBL.A13)
                    ? (object)DBNull.Value
                    : DateTime.ParseExact(objUserBL.A13, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));

            param[18] = new SqlParameter("@INSTRUMENT_DATE",
                string.IsNullOrWhiteSpace(objUserBL.A16)
                    ? (object)DBNull.Value
                    : DateTime.ParseExact(objUserBL.A16, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));


            param[31] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[31].Direction = ParameterDirection.Output;


            foreach (SqlParameter p in param)
            {
                if (p != null)
                {
                    System.Diagnostics.Debug.WriteLine(
                        p.ParameterName + " = " +
                        (p.Value == null || p.Value == DBNull.Value ? "NULL" : p.Value.ToString()));
                }
            }

            ds = Connection.Get_Dataset("ACC_CASHWITHDRAWAL_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    //cashwithdraw Linedetials insert update
    public DataSet cw_LineDetails_Ins_Upd(Global_variables objUserBL)
    {
        DataSet ds = null;

        try
        {
            SqlParameter[] param = new SqlParameter[]
        {
                new SqlParameter("@BPL_ID", objUserBL.A1),
                new SqlParameter("@BP_C_P", objUserBL.A5),
                new SqlParameter("@BP_C_NO", objUserBL.A6),
                new SqlParameter("@BP_C_S", objUserBL.A7),

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

            ds = Connection.Get_Dataset("ACC_CW_LINEDETAILS_INS_UPD", param);

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



    public DataSet Acc_ExpensesandOtherPayments_Ins_Upd(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[35];

            param[1] = new SqlParameter("@BP_C_ID", objUserBL.A1);

            param[3] = new SqlParameter("@BP_C_P", objUserBL.A3);
            param[4] = new SqlParameter("@BP_C_NO", objUserBL.A4);
            param[5] = new SqlParameter("@BP_C_S", objUserBL.A5);

            param[8] = new SqlParameter("@BANK_NAME", objUserBL.A8);
            param[9] = new SqlParameter("@AC_NO", objUserBL.A24);
            param[10] = new SqlParameter("@GL_CODE", objUserBL.A23);

            param[11] = new SqlParameter("@FUND_CUR", objUserBL.A10);
            //param[12] = new SqlParameter("@FUND_EX_RATE", objUserBL.A11);
            param[12] = new SqlParameter("@FUND_EX_RATE", string.IsNullOrWhiteSpace(objUserBL.A11) ?
                        (object)DBNull.Value : Convert.ToDecimal(objUserBL.A11));


            //param[13] = new SqlParameter("@FUND_CUR_AMT", objUserBL.A9);
            param[13] = new SqlParameter("@FUND_CUR_AMT",
    string.IsNullOrWhiteSpace(objUserBL.A9)
        ? (object)DBNull.Value
        : Convert.ToDecimal(objUserBL.A9));

            param[14] = new SqlParameter("@REFERENCE_NUMBER", objUserBL.A12);
            param[16] = new SqlParameter("@INSTRUMENT_TYPE", objUserBL.A14);
            param[17] = new SqlParameter("@INSTRUMENT_NO", objUserBL.A15);

            param[19] = new SqlParameter("@PAYEE_TYPE", objUserBL.A17);
            param[20] = new SqlParameter("@PAYEE_NAME", objUserBL.A18);

            param[21] = new SqlParameter("@CHEQUE_TYPE", objUserBL.A19);
            param[22] = new SqlParameter("@PAYMENT_MODE", objUserBL.A20);
            //param[23] = new SqlParameter("@NOT_OVER_AMOUNT", objUserBL.A21);
            param[23] = new SqlParameter("@NOT_OVER_AMOUNT",
    string.IsNullOrWhiteSpace(objUserBL.A21)
        ? (object)DBNull.Value
        : Convert.ToDecimal(objUserBL.A21));

            param[24] = new SqlParameter("@NARRATION", objUserBL.A22);
            param[25] = new SqlParameter("@flag", objUserBL.A40);

            param[29] = new SqlParameter("@RecordType", objUserBL.A29);

            param[28] = new SqlParameter("@User_Name", Connection.Current_User());
            param[26] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[27] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());



            param[6] = new SqlParameter("@BP_C_DATE",
    string.IsNullOrWhiteSpace(objUserBL.A6)
        ? (object)DBNull.Value
        : DateTime.ParseExact(objUserBL.A6, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));

            param[7] = new SqlParameter("@POSTING_DATE",
                string.IsNullOrWhiteSpace(objUserBL.A7)
                    ? (object)DBNull.Value
                    : DateTime.ParseExact(objUserBL.A7, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));

            param[15] = new SqlParameter("@REFERENCE_DATE",
                string.IsNullOrWhiteSpace(objUserBL.A13)
                    ? (object)DBNull.Value
                    : DateTime.ParseExact(objUserBL.A13, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));

            param[18] = new SqlParameter("@INSTRUMENT_DATE",
                string.IsNullOrWhiteSpace(objUserBL.A16)
                    ? (object)DBNull.Value
                    : DateTime.ParseExact(objUserBL.A16, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));


            param[31] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[31].Direction = ParameterDirection.Output;


            foreach (SqlParameter p in param)
            {
                if (p != null)
                {
                    System.Diagnostics.Debug.WriteLine(
                        p.ParameterName + " = " +
                        (p.Value == null || p.Value == DBNull.Value ? "NULL" : p.Value.ToString()));
                }
            }

            //ds = Connection.Get_Dataset("ACC_CASHWITHDRAWAL_INS_UPD", param);
            ds = Connection.Get_Dataset("ACC_EXPANDOTHERPAYMENTS_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    public DataSet expOthPaymnts_LineDetails_Ins_Upd(Global_variables objUserBL)
    {
        DataSet ds = null;

        try
        {
            SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@BPL_ID", objUserBL.A1),

            new SqlParameter("@BP_C_P", objUserBL.A5),
            new SqlParameter("@BP_C_NO", objUserBL.A6),
            new SqlParameter("@BP_C_S", objUserBL.A7),

            new SqlParameter("@IMP_EXP", objUserBL.A10),
            new SqlParameter("@CHARGE_NAME", objUserBL.A11),
            new SqlParameter("@AMOUNT", objUserBL.A12),
            new SqlParameter("@DR_CR", objUserBL.A13),
            new SqlParameter("@LINKED_GL", objUserBL.A14),
            new SqlParameter("@COSTCENTER", objUserBL.A15),
            new SqlParameter("@ACC_BRANCH", objUserBL.A16),
            new SqlParameter("@NARRATION", objUserBL.A19),

            // GST Fields
            new SqlParameter("@TAX_TYPE", objUserBL.A20),
            new SqlParameter("@HSN_SAC_TYPE", objUserBL.A21),
            new SqlParameter("@HSN_SAC_CODE", objUserBL.A22),
            new SqlParameter("@CGST_RATE", objUserBL.A23),
            new SqlParameter("@CGST_AMT", objUserBL.A24),
            new SqlParameter("@SGST_RATE", objUserBL.A25),
            new SqlParameter("@SGST_AMT", objUserBL.A26),
            new SqlParameter("@IGST_RATE", objUserBL.A27),
            new SqlParameter("@IGST_AMT", objUserBL.A28),
            new SqlParameter("@CESS_RATE", objUserBL.A29),
            new SqlParameter("@CESS_AMT", objUserBL.A30),
            new SqlParameter("@AVAIL_TAX_CREDIT", objUserBL.A31),

            new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod()),
            new SqlParameter("@CREATEDBY", Connection.Current_User()),
            new SqlParameter("@MODIFIEDBY", Connection.Current_User()),

            new SqlParameter("@User_Name", Connection.Current_User()),
            new SqlParameter("@BRANCH_CODE", Connection.Current_Branch()),
            new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type()),

            // Grid
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

            ds = Connection.Get_Dataset("ACC_EXP_OTHPAYMENTS_LINEDETAILS_INS_UPD", param);

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


    public DataSet ACC_BankPayments_EXPOTH_RPT(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();

        try
        {
            SqlParameter[] param = new SqlParameter[25];


            param[0] = new SqlParameter("@BP_P", objUserBL.A1);
            param[1] = new SqlParameter("@BP_NO", objUserBL.A2);
            param[2] = new SqlParameter("@BP_S", objUserBL.A3);

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

            ds = Connection.Get_Dataset("ACC_BANKPAYMENTS_OTHEXPENSES_RPT", param);     //ACC_BANKPAYMENTS_RPT

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }


    
    public DataSet ACC_BankPayments_CASHWITHDRAWAL_RPT(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();

        try
        {
            SqlParameter[] param = new SqlParameter[25];


            param[0] = new SqlParameter("@BP_P", objUserBL.A1);
            param[1] = new SqlParameter("@BP_NO", objUserBL.A2);
            param[2] = new SqlParameter("@BP_S", objUserBL.A3);

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

            ds = Connection.Get_Dataset("ACC_BANKPAYMENTS_CASHWITHDRAWAL_RPT", param);     //ACC_BANKPAYMENTS_CASHWITHDRAWAL_RPT
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }

}