using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ApplicationBlocks.Data;

public class Areawise_Group_Creation
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;

    public DataSet Group_Creation_Select(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[20];
            param[1] = new SqlParameter("@GROUP_ID", objUserBL.A1);
            param[2] = new SqlParameter("@GROUP_NAME", objUserBL.A2);
            param[3] = new SqlParameter("@Flag", objUserBL.A3);
            param[4] = new SqlParameter("@Loc_name", objUserBL.A4);
            param[5] = new SqlParameter("@Tr_Mode", objUserBL.A5);
            param[6] = new SqlParameter("@CustomHouse", objUserBL.A6);
            param[7] = new SqlParameter("@xmlString", objUserBL.A7);

            param[12] = new SqlParameter("@User_Id", Connection.Current_User());
            param[13] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[14] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[15] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[16] = new SqlParameter("@Company_ID", Connection.COMPANYID());

            param[17] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[17].Direction = ParameterDirection.Output;

            param[18] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[18].Direction = ParameterDirection.Output;

            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["User_current_comp_db"].ToString(), CommandType.StoredProcedure, "ADMIN_GROUP_CREATION_SELECT", param);
            if (objUserBL.A3 == "S" || objUserBL.A3 == "U" || objUserBL.A3 == "D" || objUserBL.A3 == "SS"  || objUserBL.A3 == "DD")
            {
                result = Convert.ToInt32(param[17].Value.ToString());
                if (objUserBL.A3 == "S")
                {
                  UPDATE_ID = Convert.ToInt32(param[18].Value.ToString());
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

   
    public DataSet Admin_Select(Global_variables objUserBL)
    {
        DataSet ds_2 = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[5];
            param[1] = new SqlParameter("@xmlString", objUserBL.A4);
            param[2] = new SqlParameter("@Flag", objUserBL.A5);
            param[3] = new SqlParameter("@COMPANYID", Connection.Company_License());
            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;
            ds_2 = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "FLATFILE_VALIDATION_IMP_EXP", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds_2;
    }

}