using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;

using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ApplicationBlocks.Data;

public class GST_Pioneer_Tally_Data
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;

  

    public DataSet Billing_Tally_Data(Global_variables objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.A3 != string.Empty && objUserBL.A3 != null)
            {
                arr = objUserBL.A3.Split('/');
                objUserBL.A3 = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.A4 != string.Empty && objUserBL.A4 != null)
            {
                arr2 = objUserBL.A4.Split('/');
                objUserBL.A4 = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Imp_Exp", objUserBL.A1);
            param[2] = new SqlParameter("@Cus_Name", objUserBL.A2);
            param[3] = new SqlParameter("@from_date", objUserBL.A3);
            param[4] = new SqlParameter("@to_date", objUserBL.A4);
           
            param[6] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[7] = new SqlParameter("@Flag", objUserBL.A5);

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            if (Connection.COMPANYID() == "508")
            {
                ds = Connection.Get_Dataset("GST_BILL_TALLY_DATA_PEGASUS", param);
            }
            else
            {
                ds = Connection.Get_Dataset("GST_BILL_TALLY_DATA_PIONEER", param);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet IMP_EXP_Month(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@StartDate", objUserBL.A1);
            param[1] = new SqlParameter("@EndDate", objUserBL.A2);
            param[2] = new SqlParameter("@Flag", objUserBL.A3);
            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("BILL_IMP_EXP_MONTHS", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}