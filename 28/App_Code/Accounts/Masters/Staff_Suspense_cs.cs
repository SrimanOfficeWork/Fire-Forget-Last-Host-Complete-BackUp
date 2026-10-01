using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using BussinessObject;
using System.Web.UI.WebControls;
using System.Web;
using Microsoft.ApplicationBlocks.Data;


public class Staff_Suspense_cs
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;
    public DataSet Staff_Suspense_Search(Global_variables objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.A3 != string.Empty && objUserBL.A3 != null)
            {
                arr = objUserBL.A3.Split('/');
                objUserBL.A3 = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.A4 != string.Empty && objUserBL.A4 != null)
            {
                arr2 = objUserBL.A4.Split('/');
                objUserBL.A4 = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }
            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@STAFF_NAME", objUserBL.A1);
            param[2] = new SqlParameter("@SUSP_NO", objUserBL.A2);
            param[3] = new SqlParameter("@from_date", objUserBL.A3);
            param[4] = new SqlParameter("@to_date", objUserBL.A4);

            param[7] = new SqlParameter("@Flag", objUserBL.A9);
            param[8] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_STAFF_SUSPENSE_ENTRY_SEARCH", param);

            //ACC_GST_STAFF_SUSPENSE_ENTRY

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Suspense_Entry_Ins_Upd(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[25];
            param[1] = new SqlParameter("@SUSP_ID", objUserBL.A1);
            param[2] = new SqlParameter("@SUSP_NO", objUserBL.A2);
            param[3] = new SqlParameter("@STAFF_CODE", objUserBL.A3);
            param[4] = new SqlParameter("@STAFF_NAME", objUserBL.A4);
            if (objUserBL.A5 == "" || objUserBL.A5 == null)
            {
                objUserBL.A5 = "01/01/1900";
            }
            param[5] = new SqlParameter("@SUSP_GIVEN_DATE", Connection.DATE_FORMAT(objUserBL.A5));
            param[6] = new SqlParameter("@SUSP_DESCRIPTION", objUserBL.A6);
            param[7] = new SqlParameter("@SUSP_AMOUNT", objUserBL.A7);
            param[8] = new SqlParameter("@REMARKS", objUserBL.A8);
            param[9] = new SqlParameter("@SUSP_WORKINGPERIOD", objUserBL.A9);
           
            param[18] = new SqlParameter("@Flag", objUserBL.A24);
            param[19] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[20] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[21] = new SqlParameter("@User_Name", Connection.Current_User());
            param[22] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[23] = new SqlParameter("@COMPANY_ID", Connection.COMPANYID());
            param[24] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[24].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_STAFF_SUSPENSE_ENTRY_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Staff_Suspense_Data(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@SUSP_ID", objUserBL.A1);
            param[2] = new SqlParameter("@SUSP_NO", objUserBL.A2);
            param[3] = new SqlParameter("@STAFF_CODE", objUserBL.A3);

            param[12] = new SqlParameter("@Flag", objUserBL.A15);
            param[13] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_STAFF_SUSPENSE_ENTRY_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Staff_Suspense_Data(Global_variables objUserBL, string constr)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@SUSP_ID", objUserBL.A1);
            param[2] = new SqlParameter("@SUSP_NO", objUserBL.A2);
            param[3] = new SqlParameter("@STAFF_CODE", objUserBL.A3);

            param[12] = new SqlParameter("@Flag", objUserBL.A15);
            param[13] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_STAFF_SUSPENSE_ENTRY_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}