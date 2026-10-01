using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

public class Export_Default_Entry
{
    public static void Post_Data(string Jobno, string Flag)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@Jobno", Jobno);
            param[2] = new SqlParameter("@Company_Lic", Connection.Company_License());
            param[3] = new SqlParameter("@User_Id", Connection.Current_User());
            param[4] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());

            param[5] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[6] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());

            param[7] = new SqlParameter("@Flag", Flag);
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            Connection.Get_Dataset("EXPORT_DEFAULT_ENTRY", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }


    public static void CLIENT_BASED_DBK_DEFAULT_ENTRY(string Jobno, string Flag)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@Jobno", Jobno);
            param[2] = new SqlParameter("@Company_Lic", Connection.Company_License());
            param[3] = new SqlParameter("@User_Id", Connection.Current_User());
            param[4] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());

            param[5] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[6] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());

            param[7] = new SqlParameter("@Flag", Flag);
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            Connection.Get_Dataset("EXPORT_CLIENT_BASED_DBK_DEFAULT_ENTRY", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
}