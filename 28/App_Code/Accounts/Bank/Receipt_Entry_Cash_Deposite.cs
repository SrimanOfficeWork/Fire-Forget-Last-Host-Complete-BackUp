using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using BussinessObject;
using System.Web.UI.WebControls;
using System.Web;
public class Receipt_Entry_Cash_Deposite
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
    public DataSet Acc_Gst_Br_Cash_Receipt_Select(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[30];

            param[2] = new SqlParameter("@BR_C_ID", objUserBL.A1);
            param[3] = new SqlParameter("@BR_Cash_Id", objUserBL.A2);

            param[4] = new SqlParameter("@BR_C_P", objUserBL.A3);
            param[5] = new SqlParameter("@BR_C_NO", objUserBL.A4);
            param[6] = new SqlParameter("@BR_C_S", objUserBL.A5);
            param[7] = new SqlParameter("@JOB_ID", objUserBL.A6);
            param[8] = new SqlParameter("@BR_C_JOB_AMT", objUserBL.A7);


            param[16] = new SqlParameter("@flag", objUserBL.A40); //Flag
            param[17] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[18] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());

            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_BR_CASH_DEPOSITE_RECEIPT_ENTRY_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }





    //ACC_GST_BR_RECEIPT_ENTRY
    public DataSet ACC_GST_BR_C_RECEIPT_ENTRY_INS_UPD(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[43];
            param[1] = new SqlParameter("@BR_C_ID", objUserBL.A1);
            param[2] = new SqlParameter("@R_C", objUserBL.A2);
            param[3] = new SqlParameter("@BR_C_P", objUserBL.A3);
            param[4] = new SqlParameter("@BR_C_NO", objUserBL.A4);
            param[5] = new SqlParameter("@BR_C_S", objUserBL.A5);

            param[6] = new SqlParameter("@BR_C_DATE", Connection.DATE_FORMAT(objUserBL.A6));

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




            ds = Connection.Get_Dataset("ACC_GST_BR_CASH_DEPOSITE_RECEIPT_ENTRY_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}