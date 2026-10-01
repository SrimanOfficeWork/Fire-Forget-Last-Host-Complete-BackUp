using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ApplicationBlocks.Data;

public class Auto_Instal
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;

    public DataSet Instal_Select(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@ID", objUserBL.A1);
            param[2] = new SqlParameter("@Customer_Name", objUserBL.A2);
            param[3] = new SqlParameter("@Branch_Common", objUserBL.A3);
            param[4] = new SqlParameter("@Company_Lic", objUserBL.A4);
            param[5] = new SqlParameter("@Company_Id", objUserBL.A5);
            param[6] = new SqlParameter("@Type", objUserBL.A6);
            param[7] = new SqlParameter("@Flag", objUserBL.A7);

            param[8] = new SqlParameter("@Server_Name", objUserBL.A8);
            param[9] = new SqlParameter("@Login_Name", objUserBL.A9);
            param[10] = new SqlParameter("@Login_Pwd", objUserBL.A10);
            param[11] = new SqlParameter("@From_Databse", objUserBL.A11);

            param[12] = new SqlParameter("@WorkingPeriod", Connection.WorkingPeriod());

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "AUTO_INSTAL_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Get_Data(string Flag, string Login, String TableName, string Id)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[5];
            param[1] = new SqlParameter("@ID", Id);
            param[2] = new SqlParameter("@vsTableName", TableName);
            param[3] = new SqlParameter("@Flag", Flag);
            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(Login, CommandType.StoredProcedure, "GET_DB_STRUCTURE", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet INSTALLATION_Get_Data(string Flag, string Login, String TableName, string Id)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[5];
            param[1] = new SqlParameter("@ID", Id);
            param[2] = new SqlParameter("@vsTableName", TableName);
            param[3] = new SqlParameter("@Flag", Flag);
            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(Login, CommandType.StoredProcedure, "INSTALLATION_GET_DB_STRUCTURE", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Ins_Data(String Xml_A, String Xml_B, String Xml_C, String Xml_D, String Xml_E,string flg, string Login)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@xmlString_A", Xml_A);
            param[2] = new SqlParameter("@xmlString_B", Xml_B);
            param[3] = new SqlParameter("@xmlString_C", Xml_C);
            param[4] = new SqlParameter("@xmlString_D", Xml_D);
            param[5] = new SqlParameter("@xmlString_E", Xml_E);

            param[8] = new SqlParameter("@Flag", flg);
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(Login, CommandType.StoredProcedure, "DEFAULT_DATA_INS", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet INSTALLATION_Ins_Data(String Xml_A, String Xml_B, String Xml_C, String Xml_D, String Xml_E, String Xml_F , String Xml_G, string flg, string Login)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@xmlString_A", Xml_A);
            param[2] = new SqlParameter("@xmlString_B", Xml_B);
            param[3] = new SqlParameter("@xmlString_C", Xml_C);
            param[4] = new SqlParameter("@xmlString_D", Xml_D);
            param[5] = new SqlParameter("@xmlString_E", Xml_E);
            param[6] = new SqlParameter("@xmlString_F", Xml_F);
            param[7] = new SqlParameter("@xmlString_G", Xml_G);

            param[8] = new SqlParameter("@Flag", flg);
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(Login, CommandType.StoredProcedure, "INSTALLATION_DEFAULT_DATA_INS", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Create_Wrk(string New_DB ,string flg)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[11];
            param[1] = new SqlParameter("@Db_Name_new", New_DB);
            param[2] = new SqlParameter("@Flag", flg);

            param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[10].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("CLIENT_FINANCIAL_YEAR", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Wrk_Creation_Search(Global_variables objUserBL)
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

            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@from_date", objUserBL.A1);
            param[2] = new SqlParameter("@to_date", objUserBL.A2);
            param[3] = new SqlParameter("@DB_Name", objUserBL.A3);
            param[4] = new SqlParameter("@Company_Lic", objUserBL.A4);
           
            param[6] = new SqlParameter("@Flag", objUserBL.A5);

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "WRK_CREATION_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    
}