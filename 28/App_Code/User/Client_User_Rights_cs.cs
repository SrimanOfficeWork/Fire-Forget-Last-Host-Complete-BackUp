using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;
using Microsoft.ApplicationBlocks.Data;


public class Client_User_Rights_cs
{
    DataSet ds = new DataSet();
    public DataSet CHA_User_Rights_Select(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[21];
            param[1] = new SqlParameter("@COMPANY_LICENSE", objUserBL.A1);
            param[2] = new SqlParameter("@COMPANY_ID", objUserBL.A2);
            param[3] = new SqlParameter("@EmpId", objUserBL.A3);

            param[16] = new SqlParameter("@flag", objUserBL.A40);
            param[17] = new SqlParameter("@User_Name", Connection.Current_User());
            param[18] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("CHA_USER_MENU_RIGHTS_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Admin_User_Rights_Select(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[21];
            param[1] = new SqlParameter("@COMPANY_LICENSE", objUserBL.A1);
            param[2] = new SqlParameter("@COMPANY_ID", objUserBL.A2);
            param[3] = new SqlParameter("@EmpId", objUserBL.A3);
            param[4] = new SqlParameter("@ERoyal_UserName", objUserBL.A4);

            param[16] = new SqlParameter("@flag", objUserBL.A40);
            param[17] = new SqlParameter("@User_Name", Connection.Current_User());
            param[18] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "CHA_USER_RIGHTS_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet User_Rights_Insert_Update(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@Client_User_ID", objUserBL.A1);
            param[2] = new SqlParameter("@ERoyal_EMP_ID", objUserBL.A2);
            param[3] = new SqlParameter("@xmlString_User", objUserBL.A5);

            param[4] = new SqlParameter("@flag", objUserBL.A10);
            param[5] = new SqlParameter("@COMPANY_ID", Connection.COMPANYID());
            param[6] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());
            param[7] = new SqlParameter("@User_Name", Connection.Current_User());
            param[8] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "CLIENT_USER_RIGHTS_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}