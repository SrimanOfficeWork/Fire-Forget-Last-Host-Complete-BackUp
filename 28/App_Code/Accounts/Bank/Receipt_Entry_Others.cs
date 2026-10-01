using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using BussinessObject;
using System.Web.UI.WebControls;
using System.Web;

public class Receipt_Entry_Others
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
    public DataSet Acc_Gst_Br_Other_Receipt_Select(Global_variables objUserBL)
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
            ds = Connection.Get_Dataset("ACC_GST_BR_OTHER_RECEIPT_ENTRY_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    //ACC_GST_BR_RECEIPT_ENTRY
    public DataSet ACC_GST_BR_O_RECEIPT_ENTRY_INS_UPD(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[43];
            param[1] = new SqlParameter("@BR_O_ID", objUserBL.A1);
            param[2] = new SqlParameter("@R_O", objUserBL.A2);
            param[3] = new SqlParameter("@BR_O_P", objUserBL.A3);
            param[4] = new SqlParameter("@BR_O_NO", objUserBL.A4);
            param[5] = new SqlParameter("@BR_O_S", objUserBL.A5);
            param[6] = new SqlParameter("@BR_O_DATE", Connection.DATE_FORMAT(objUserBL.A6));
            param[7] = new SqlParameter("@POSTING_DATE", Connection.DATE_FORMAT(objUserBL.A7));
            param[8] = new SqlParameter("@BANK_NAME", objUserBL.A8);
            param[9] = new SqlParameter("@ISSUSER_BANK_NAME", objUserBL.A9);
            param[10] = new SqlParameter("@ISSUSER_BANK_NO", objUserBL.A10);
            param[11] = new SqlParameter("@CHARGE_ID", objUserBL.A11);
            param[12] = new SqlParameter("@CHARGE_NAME", objUserBL.A12);
            param[13] = new SqlParameter("@FUND_TYPE", objUserBL.A13);
            param[14] = new SqlParameter("@FUND_ID", objUserBL.A14);
            param[15] = new SqlParameter("@FUND_DATE", Connection.DATE_FORMAT(objUserBL.A15));
            param[16] = new SqlParameter("@FUND_CUR", objUserBL.A16);
            param[17] = new SqlParameter("@FUND_EX_RATE", objUserBL.A17);
            param[18] = new SqlParameter("@FUND_CUR_AMT", objUserBL.A18);
            param[19] = new SqlParameter("@FUND_INR_AMT", objUserBL.A19);
            param[20] = new SqlParameter("@AMOUNT", objUserBL.A20);
            param[21] = new SqlParameter("@AMOUNT_TYPE", objUserBL.A21);
            param[22] = new SqlParameter("@TAX", objUserBL.A22);
            param[23] = new SqlParameter("@NARRATION", objUserBL.A23);
            param[24] = new SqlParameter("@JOB_LICENSE", objUserBL.A24);
            param[25] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.A25);

            param[26] = new SqlParameter("@flag", objUserBL.A27);

            param[27] = new SqlParameter("@AC_NO", objUserBL.A28);
            param[28] = new SqlParameter("@BRANCH", objUserBL.A29);
            param[29] = new SqlParameter("@CHARGE_NARRATION", objUserBL.A30);
            param[30] = new SqlParameter("@REFERANCE_NUMBER", objUserBL.A31);
            param[31] = new SqlParameter("@REFERENCE_DATE",Connection.DATE_FORMAT(objUserBL.A32));
            param[32] = new SqlParameter("@Issuer_Bank_info_No", objUserBL.A33);
            param[33] = new SqlParameter("@SALES_BILL_INV_NO", objUserBL.A34);
           
            param[38] = new SqlParameter("@User_Name", Connection.Current_User());
            param[39] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[40] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[41] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[42] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[42].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_BR_OTHER_RECEIPT_ENTRY_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}