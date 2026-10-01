using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;

public class Imp_Sup_Doc_Copy
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;

    public DataSet IMP_Sup_Doc_Select(Global_variables objUser)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@WH_JOBNO", objUser.A1);
            param[2] = new SqlParameter("@JOBNO", objUser.A2);

            param[3] = new SqlParameter("@Inv_Slno", objUser.A3);
            param[4] = new SqlParameter("@Item_Slno", objUser.A4);

            param[5] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[6] = new SqlParameter("@flag", objUser.A5);

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("IMP_WH_SUP_DOC_COPY_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public void WH_To_Exbond_Sup_Copy(Global_variables objUser)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[30];
            param[0] = new SqlParameter("@WH_Jobno", objUser.A1);
            param[1] = new SqlParameter("@Ex_Jobno", objUser.A2);
            param[2] = new SqlParameter("@Ex_Inv_Slno", objUser.A3);
            param[3] = new SqlParameter("@Ex_Item_Slno", objUser.A4);

            param[4] = new SqlParameter("@xmlString_A", objUser.A5);
            param[5] = new SqlParameter("@xmlString_B", objUser.A6);

            param[6] = new SqlParameter("@WH_WorkingPeriod", objUser.A7);
            param[7] = new SqlParameter("@DB_Name", objUser.A8);

            param[8] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[9] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[10] = new SqlParameter("@User_Id", Connection.Current_User());

            param[11] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output;

            param[12] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[12].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("WAREHOUSE_TO_EXBOND_SUPPORTING_DOC_COPY", param);
            result = Convert.ToInt32(param[11].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
}