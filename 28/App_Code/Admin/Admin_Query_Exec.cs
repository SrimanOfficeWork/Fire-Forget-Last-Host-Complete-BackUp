using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;
using Microsoft.ApplicationBlocks.Data;

public class Admin_Query_Exec
{
    public DataSet Query_Exec(string constr,string SP_Name)
    {
        UserBO objUser = new UserBO();
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[1] = new SqlParameter("@SP_NAME",SP_Name);
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(constr, CommandType.StoredProcedure, "CHECK_SP_AVAILABILITY", param);
            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Live_Company_Select(Global_variables objUserBL)
    {
          DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@ID", objUserBL.A1);
            param[1] = new SqlParameter("@Flag", objUserBL.A2);

            param[2] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[2].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "LIVE_UDATEION_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}