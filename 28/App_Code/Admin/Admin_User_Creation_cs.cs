using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;
using Microsoft.ApplicationBlocks.Data;

public class Admin_User_Creation_cs
{
    DataSet ds = new DataSet();
    public DataSet Admin_User_Select(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[21];
            param[1] = new SqlParameter("@COMPANY_LICENSE", objUserBL.A1);
            param[2] = new SqlParameter("@COMPANY_ID", objUserBL.A2);

            param[16] = new SqlParameter("@flag", objUserBL.A40);
            param[17] = new SqlParameter("@User_Name",Connection.Current_User());
            param[18] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "ADMIN_USER_CREATION_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Admin_User_Insert_Update(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[21];
            param[1] = new SqlParameter("@U_ID", objUserBL.A1);
            param[2] = new SqlParameter("@COMPANY_LICENSE", objUserBL.A2);
            param[3] = new SqlParameter("@COMPANY_ID", objUserBL.A3);

            param[4] = new SqlParameter("@USER_ROLE", objUserBL.A4);
            param[5] = new SqlParameter("@USERID", objUserBL.A5);

            if (objUserBL.A6 == null)
            {
                objUserBL.A6 = string.Empty;
            }
            param[6] = new SqlParameter("@USER_CREATEDON", Connection.DATE_FORMAT(objUserBL.A6 == string.Empty ? "01/01/1900" : objUserBL.A6));
            param[7] = new SqlParameter("@USER_STATUS", objUserBL.A7);
            if (objUserBL.A8 == null)
            {
                objUserBL.A8 = string.Empty;
            }
            param[8] = new SqlParameter("@ACTIVEON", Connection.DATE_FORMAT(objUserBL.A8 == string.Empty ? "01/01/1900" : objUserBL.A8));
            if (objUserBL.A9 == null)
            {
                objUserBL.A9 = string.Empty;
            }
            param[9] = new SqlParameter("@INACTIVEON", Connection.DATE_FORMAT(objUserBL.A9 == string.Empty ? "01/01/1900" : objUserBL.A9));
            param[10] = new SqlParameter("@REMARKS", objUserBL.A10);
            param[11] = new SqlParameter("@LEAD_BY", objUserBL.A11);

            param[17] = new SqlParameter("@flag", objUserBL.A20);
            param[18] = new SqlParameter("@User_Name", Connection.Current_User());
            param[19] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[20] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[20].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "ADMIN_USER_CREATION_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Admin_Premium_Services_Select(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[21];
            param[1] = new SqlParameter("@COMPANY_LICENSE", objUserBL.A1);
            param[2] = new SqlParameter("@COMPANY_ID", objUserBL.A2);
            param[3] = new SqlParameter("@IMP_EXP", objUserBL.A3);

            param[16] = new SqlParameter("@flag", objUserBL.A40);
            param[17] = new SqlParameter("@User_Name", Connection.Current_User());
            param[18] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "ADMIN_PREMIUM_SERVICES_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Admin_Premium_Services_Insert_Update(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[21];
            param[1] = new SqlParameter("@P_ID", objUserBL.A1);
            param[2] = new SqlParameter("@COMPANY_LICENSE", objUserBL.A2);
            param[3] = new SqlParameter("@COMPANY_ID", objUserBL.A3);

            param[4] = new SqlParameter("@IMP_EXP", objUserBL.A4);
            param[5] = new SqlParameter("@FEATURES", objUserBL.A5);


            if (objUserBL.A6 == null)
            {
                objUserBL.A6 = string.Empty;
            }
            param[6] = new SqlParameter("@USER_CREATEDON", Connection.DATE_FORMAT(objUserBL.A6 == string.Empty ? "01/01/1900" : objUserBL.A6));
            param[7] = new SqlParameter("@F_STATUS", objUserBL.A7);

            if (objUserBL.A8 == null)
            {
                objUserBL.A8 = string.Empty;
            }
            param[8] = new SqlParameter("@ACTIVEON", Connection.DATE_FORMAT(objUserBL.A8 == string.Empty ? "01/01/1900" : objUserBL.A8));
            if (objUserBL.A9 == null)
            {
                objUserBL.A9 = string.Empty;
            }
            param[9] = new SqlParameter("@INACTIVEON", Connection.DATE_FORMAT(objUserBL.A9 == string.Empty ? "01/01/1900" : objUserBL.A9));
            param[10] = new SqlParameter("@REMARKS", objUserBL.A10);
            param[11] = new SqlParameter("@LEAD_BY", objUserBL.A11);
            param[12] = new SqlParameter("@VENDOR", objUserBL.A12);
            param[13] = new SqlParameter("@PDF_UPLOAD", objUserBL.A13);

            param[17] = new SqlParameter("@flag", objUserBL.A20);
            param[18] = new SqlParameter("@User_Name", Connection.Current_User());
            param[19] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[20] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[20].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "ADMIN_PREMIUM_SERVICES_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

}