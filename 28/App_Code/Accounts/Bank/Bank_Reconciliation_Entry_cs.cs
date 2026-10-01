using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using BussinessObject;
using System.Web.UI.WebControls;
using System.Web;

public class Bank_Reconciliation_Entry_cs
{
    DataSet ds = new DataSet();
    public DataSet Bank_Reconciliation_Search(Global_variables objUserBL)
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
            param[3] = new SqlParameter("@Bank_Acno", objUserBL.A3);

            param[4] = new SqlParameter("@Trans_Type", objUserBL.A4);
            param[5] = new SqlParameter("@Group_Name", objUserBL.A5);

            param[6] = new SqlParameter("@Search_Cat", objUserBL.A6);
            param[7] = new SqlParameter("@Search_Item", objUserBL.A7);

            param[12] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[13] = new SqlParameter("@Flag", objUserBL.A15);

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_BANK_RECONCILIATION_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Bank_Reconciliation_Select(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[20];

            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.A4 != string.Empty && objUserBL.A4 != null)
            {
                arr = objUserBL.A4.Split('/');
                objUserBL.A4 = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.A5 != string.Empty && objUserBL.A5 != null)
            {
                arr2 = objUserBL.A5.Split('/');
                objUserBL.A5 = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            param[2] = new SqlParameter("@Bank_Acno", objUserBL.A1);
            param[3] = new SqlParameter("@Trans_Type", objUserBL.A2);
            param[4] = new SqlParameter("@Group_Name", objUserBL.A3);
            param[5] = new SqlParameter("@from_date", objUserBL.A4);
            param[6] = new SqlParameter("@to_date", objUserBL.A5);
            param[7] = new SqlParameter("@RECON_ID", objUserBL.A6);

            param[16] = new SqlParameter("@flag", objUserBL.A40); //Flag
            param[17] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[18] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());

            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_BANK_RECONCILIATION_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Bank_Reconciliation_Ins_Upd(Global_variables objUserBL)
    {
        DataSet ds_s = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[16];

            param[1] = new SqlParameter("@ID", objUserBL.A51); //A1
            param[2] = new SqlParameter("@xmlString_Charge", objUserBL.A52);//A38

            param[9] = new SqlParameter("@flag", objUserBL.A80);//A39
            param[10] = new SqlParameter("@Company_Lic", Connection.Company_License());
            param[11] = new SqlParameter("@USER_NAME", Connection.Current_User());
            param[12] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[13] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[14] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());

            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;

            ds_s = Connection.Get_Dataset("ACC_GST_BANK_RECONCILIATION_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds_s;
    }
}