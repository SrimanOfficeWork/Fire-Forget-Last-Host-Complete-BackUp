using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ApplicationBlocks.Data;
using BussinessObject;


public class E_Inv_Cancellation_Entry_cs
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;
    Global_variables ObjUBO = new Global_variables();
    public DataSet e_Inv_Cancel_Search(Global_variables objUserBL)
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
            param[3] = new SqlParameter("@Cus_name", objUserBL.A3);
            param[4] = new SqlParameter("@Search_Cat", objUserBL.A4);
            param[5] = new SqlParameter("@Search_Item", objUserBL.A5);
            param[7] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[8] = new SqlParameter("@Flag", objUserBL.A7);

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_BILL_SALES_INV_CANCELED_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet e_Inv_Cancel_Select(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[21];
            param[1] = new SqlParameter("@Bill_Id", objUserBL.A1);
            param[2] = new SqlParameter("@Bill_Invno", objUserBL.A2);
            param[3] = new SqlParameter("@Imp_Exp", objUserBL.A3);
            
            param[17] = new SqlParameter("@flag", objUserBL.A40);
            param[18] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[19] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());

            param[20] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[20].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_BILL_SALES_INV_CANCELED_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet e_Inv_Cancellation(Global_variables objUserBL)
    {
        DataSet ds_s = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[16];

            param[1] = new SqlParameter("@ID", objUserBL.A1); 
            param[2] = new SqlParameter("@BILL_INV_NO", objUserBL.A2);
            param[3] = new SqlParameter("@INV_CANCEL_REASON", objUserBL.A3);
            param[4] = new SqlParameter("@INV_CANCEL_REMARKS", objUserBL.A4);

            param[9] = new SqlParameter("@flag", objUserBL.A15);
            param[10] = new SqlParameter("@Company_Lic", Connection.Company_License());
            param[11] = new SqlParameter("@USER_NAME", Connection.Current_User());
            param[12] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[13] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[14] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());

            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;

            ds_s = Connection.Get_Dataset("ACC_GST_BILL_SALES_INV_CANCELED_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds_s;
    }
    
}