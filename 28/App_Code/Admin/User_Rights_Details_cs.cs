using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;
using Microsoft.ApplicationBlocks.Data;

public class User_Rights_Details_cs
{
    DataSet ds = new DataSet();
    public DataSet User_Rights_Select(Global_variables objUserBL)
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
            SqlParameter[] param = new SqlParameter[16];
            param[1] = new SqlParameter("@U_ID", objUserBL.A1);
            param[2] = new SqlParameter("@COMPANY_LICENSE", objUserBL.A2);
            param[3] = new SqlParameter("@COMPANY_ID", objUserBL.A3);
            param[4] = new SqlParameter("@EMP_ID", objUserBL.A4);
            param[5] = new SqlParameter("@xmlString_User", objUserBL.A10);//A38

            param[12] = new SqlParameter("@flag", objUserBL.A20);
            param[13] = new SqlParameter("@User_Name", Connection.Current_User());
            param[14] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "CHA_USER_RIGHTS_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Copper_Login_Details_Insert_Update(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[16];

            param[1] = new SqlParameter("@EROYAL_CID", objUserBL.A1);
            param[2] = new SqlParameter("@flag", objUserBL.A2);
            param[3] = new SqlParameter("@BRANCH_CODE", objUserBL.A3);
            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "COPPERHAWK_LOGIND_DETAILS", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet GetJobDetails(Global_variables ObjUBO)
    {
        DataSet ds = new DataSet();

        try
        {
            SqlParameter[] param = new SqlParameter[8];

            param[0] = new SqlParameter("@Month", ObjUBO.A1);

            param[1] = new SqlParameter("@ImporterName", ObjUBO.A2);

            param[2] = new SqlParameter("@ExporterName", ObjUBO.A2);

            param[3] = new SqlParameter("@Status", ObjUBO.A3);

            param[4] = new SqlParameter("@flag", ObjUBO.A4);
            param[5] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());

            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "DASHBOARD_JOB_REPORT_DOWNLOAD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }

}