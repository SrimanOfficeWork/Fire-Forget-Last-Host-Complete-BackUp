using System;
using System.Data;
using System.Data.SqlClient;
using BussinessObject;

public class Acc_Unbilled_Jobs
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;
    Global_variables ObjUBO = new Global_variables();

    public DataSet Select_UnbilledJobs(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();

        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@Branch", objUserBL.A1);        
            param[1] = new SqlParameter("@LOB", objUserBL.A2);
            param[2] = new SqlParameter("@SEARCH_TYPE", objUserBL.A3);   
            param[3] = new SqlParameter("@SEARCH_ITEM", objUserBL.A4);
            param[4] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[5] = new SqlParameter("@JOBNO", objUserBL.A5);
            param[6] = new SqlParameter("@JobDate", objUserBL.A6);
            param[7] = new SqlParameter("@Flag", objUserBL.A7);
           

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_UNBILLED_JOB_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }
}