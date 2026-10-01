using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using BussinessObject;
using System.Web.UI.WebControls;
using System.Web;

public class Company_Info_cs
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;
    public DataSet Company_Entry_Search(Global_variables objUserBL)
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
          
            param[7] = new SqlParameter("@Flag", objUserBL.A10);
            param[8] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_COMPANY_INFO_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Company_Entry_Select(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@C_ID", objUserBL.A1); 

            param[7] = new SqlParameter("@Flag", objUserBL.A9);
            param[8] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_COMPANY_INFO_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Company_Entry_Ins_Upd(Global_variables objUserBL)
    {
        
        try
        {
            SqlParameter[] param = new SqlParameter[40];

            param[2] = new SqlParameter("@C_ID", objUserBL.A1); 
            param[3] = new SqlParameter("@COMPANY_NAME", objUserBL.A2); 
            param[4] = new SqlParameter("@COMPANY_BRANCH", objUserBL.A3);
            param[5] = new SqlParameter("@ADD_1", objUserBL.A4); 
            param[6] = new SqlParameter("@ADD_2", objUserBL.A5); 
            param[7] = new SqlParameter("@ADD_3", objUserBL.A6); 
            param[8] = new SqlParameter("@ADD_4", objUserBL.A7);
            param[9] = new SqlParameter("@ADD_5", objUserBL.A8); 
            param[10] = new SqlParameter("@TAN_PAN_NO", objUserBL.A9);
            param[11] = new SqlParameter("@GST_REG_TYPE", objUserBL.A10); 
            param[12] = new SqlParameter("@STATE_CODE", objUserBL.A11);
            param[14] = new SqlParameter("@GST_NO", objUserBL.A12); 
            param[15] = new SqlParameter("@JOB_LICENSE", objUserBL.A13); 

            param[33] = new SqlParameter("@Flag", objUserBL.A33); 
            param[34] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[35] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[36] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[37] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());

            param[39] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[39].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_COMPANY_INFO_INS_UPD", param);
            //ds = ParaMount_Connection.Get_Combined_Con("ACC_GST_COMPANY_INFO_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_AUTOCOMPLETE_SEARCH_CHARGE(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Name_Search", objUserBL.A1);
            param[2] = new SqlParameter("@name", objUserBL.A2);
            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@Notn_No_Search", objUserBL.A3);
            param[6] = new SqlParameter("@Notn_Type", objUserBL.A4);
            ds = Connection.Get_Dataset("SP_AUTOCOMPLETE_SEARCH_MASTER_CHARGE", param);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    public DataSet RetrieveAll_AUTOCOMPLETE_SEARCH_PART_II(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Name_Search", objUserBL.A1);
            param[2] = new SqlParameter("@name", objUserBL.A2);
            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@Notn_No_Search", objUserBL.A3);
            param[6] = new SqlParameter("@Notn_Type", objUserBL.A4);
            ds = Connection.Get_Dataset("SP_AUTOCOMPLETE_SEARCH_MASTER_PART_II", param);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }




  
}