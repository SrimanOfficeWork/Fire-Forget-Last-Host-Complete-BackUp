using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ApplicationBlocks.Data;
using BussinessObject;


public class Imp_Exp_Rpt
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;
    Global_variables ObjUBO = new Global_variables();

    public DataSet IMP_EXP_DATA(Global_variables objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.A5 != string.Empty && objUserBL.A5 != null)
            {
                arr = objUserBL.A5.Split('/');
                objUserBL.A5 = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.A6 != string.Empty && objUserBL.A6 != null)
            {
                arr2 = objUserBL.A6.Split('/');
                objUserBL.A6 = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[21];
            param[2] = new SqlParameter("@Imp_Exp", objUserBL.A1);
            param[3] = new SqlParameter("@Cus_name", objUserBL.A2);
            param[4] = new SqlParameter("@Tr_mode", objUserBL.A3);
            param[5] = new SqlParameter("@Filter", objUserBL.A4);
            param[6] = new SqlParameter("@from_date", objUserBL.A5);
            param[7] = new SqlParameter("@to_date", objUserBL.A6);
            param[8] = new SqlParameter("@Flag", objUserBL.A7);
            param[9] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());

            param[20] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[20].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("IMP_EXP_JOB_COUNT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}