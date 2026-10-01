using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;

using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ApplicationBlocks.Data;

public class WareHouse_Cs
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;

    public DataSet WH_Select(Global_variables objUserBL, string Connstr)
    {
        try
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(Connstr);
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@JOBNO", objUserBL.A1);
            param[1] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[2] = new SqlParameter("@Flag", objUserBL.A3);
            //param[3] = new SqlParameter("@DB_Name",builder.InitialCatalog);
            param[3] = new SqlParameter("@DB_Name", objUserBL.A4);
            param[4] = new SqlParameter("@WH_WorkingPeriod", objUserBL.A5);
            param[5] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;
            //ds = SqlHelper.ExecuteDataset(Connstr, CommandType.StoredProcedure, "WAREHOUSE_SELECT", param);
            ds = SqlHelper.ExecuteDataset(Connstr, CommandType.StoredProcedure, "WAREHOUSE_SELECT", param);
            //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "WAREHOUSE_SELECT", param);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet WH_Select_Details(Global_variables objUserBL, string Connstr) // Added by pandiyan on 07/05/2026 
    {
        try
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(Connstr);
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@JOBNO", objUserBL.A1);
            param[1] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[2] = new SqlParameter("@Flag", objUserBL.A3);
            param[3] = new SqlParameter("@DB_Name", builder.InitialCatalog);
            // param[3] = new SqlParameter("@DB_Name", objUserBL.A4);
            param[4] = new SqlParameter("@WH_WorkingPeriod", objUserBL.A5);
            param[5] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "WAREHOUSE_SELECT", param);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


     public DataSet WH_Select(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@JOBNO", objUserBL.A1);
            param[1] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[2] = new SqlParameter("@Flag", objUserBL.A3);
            param[3] = new SqlParameter("@DB_Name", objUserBL.A4);
            param[4] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[5] = new SqlParameter("@WH_WorkingPeriod", objUserBL.A5);
            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("WAREHOUSE_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

     public DataSet Generate_Exbond_Job(Global_variables objUserBL, String Xml_Data)
     {
         DataSet ds = new DataSet();
         try
         {
             SqlParameter[] param = new SqlParameter[25];
             param[1] = new SqlParameter("@OLD_JOBNO", objUserBL.A1);
             param[2] = new SqlParameter("@CURRENT_JOBNO", objUserBL.A2);
             param[3] = new SqlParameter("@Flag", objUserBL.A3);
             param[4] = new SqlParameter("@DB_Name", objUserBL.A4);
             param[5] = new SqlParameter("@xmlString", Xml_Data);

             param[6] = new SqlParameter("@PORT_ORIGIN", objUserBL.A5);
             param[7] = new SqlParameter("@PORT_SHIPMENT", objUserBL.A6);

             param[8] = new SqlParameter("@USERID", Connection.Current_User());
             param[9] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
             param[10] = new SqlParameter("@Current_Working_Period", Connection.WorkingPeriod());

             param[11] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
             param[11].Direction = ParameterDirection.Output;
             param[12] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
             param[12].Direction = ParameterDirection.Output;
             param[13] = new SqlParameter("@Company_Id", Connection.COMPANYID().ToString()); // Added by shanthini on 30-07-2026

             ds = Connection.Get_Dataset("IMP_WAREHOUSE_TO_EXBOND_WORKING_PERIOD", param);

             // result = Convert.ToInt32(param[11].Value.ToString()); 
         }
         catch (Exception ex)
         {
             Connection.Error_Msg(ex.Message);
         }
         return ds;
     }
    
}