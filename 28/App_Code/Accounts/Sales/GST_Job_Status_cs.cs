using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using BussinessObject;
using System.Web.UI.WebControls;
using System.Web;

public class GST_Job_Status_cs
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;
    Global_variables ObjUBO = new Global_variables();
    public DataSet Select_Job(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[21];
            param[1] = new SqlParameter("@Imp_Exp", objUserBL.A1);
            param[2] = new SqlParameter("@Bill_Id", objUserBL.A2);
            param[3] = new SqlParameter("@Jobno", objUserBL.A3);

            param[17] = new SqlParameter("@flag", objUserBL.A40);
            param[18] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[19] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());

            param[20] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[20].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_JOB_STATUS_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet BILL_JOB_SEARCH(Global_variables objUserBL)
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

            SqlParameter[] param = new SqlParameter[16];
            param[1] = new SqlParameter("@from_date", objUserBL.A1);
            param[2] = new SqlParameter("@to_date", objUserBL.A2);
            param[3] = new SqlParameter("@Imp_Exp", objUserBL.A3);
            param[4] = new SqlParameter("@Search_Cat", objUserBL.A4);
            param[5] = new SqlParameter("@Search_Item", objUserBL.A5);
            param[6] = new SqlParameter("@Cus_name", objUserBL.A6);
            param[7] = new SqlParameter("@Job_Status", objUserBL.A7);
            param[8] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[9] = new SqlParameter("@Flag", objUserBL.A10);

            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_JOB_STATUS_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}