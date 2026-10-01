using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using BussinessObject;
using System.Web.UI.WebControls;
using System.Web;

public class Imp_Exp_Job_Deleted_History
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;

    public DataSet Job_Deleted_Select(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Jobno", objUserBL.A1);
            param[2] = new SqlParameter("@Client_Name", objUserBL.A2);
            param[3] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[4] = new SqlParameter("@Flag", objUserBL.A3);
            param[5] = new SqlParameter("@COMPANY_ID", Connection.COMPANYID());

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("IMP_EXP_JOB_DELETED_HISTORY_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Job_Deleted_Search(Global_variables objUserBL)
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

            param[3] = new SqlParameter("@Client_name", objUserBL.A3);
            param[4] = new SqlParameter("@jobno", objUserBL.A4);
            param[5] = new SqlParameter("@Flag", objUserBL.A5);
            param[6] = new SqlParameter("@Imp_Exp", objUserBL.A6);
            param[7] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("IMP_EXP_JOB_DELETED_HISTORY_SEARCH", param);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}