using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using BussinessObject;
using System.IO;
using System.Text;
/// <summary>
/// Summary description for TDS_receivable_Payable
/// </summary>
public class TDS_receivable_Payable
{
    Global_variables ObjUBO = new Global_variables();
    DataSet dss = new DataSet();
    public DataSet LoadTDS_receivable(Global_variables objuser)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objuser.A1 != string.Empty && objuser.A1 != null)
            {
                arr = objuser.A1.Split('/');
                objuser.A1 = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objuser.A2 != string.Empty && objuser.A2 != null)
            {
                arr2 = objuser.A2.Split('/');
                objuser.A2 = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@Fromdate", objuser.A1);
            param[1] = new SqlParameter("@Todate", objuser.A2);
            param[2]=new SqlParameter("@OrgName",objuser.A3);
            param[3]=new SqlParameter("@Flag",objuser.A6);
            param[6] = new SqlParameter("@startRowIndex", objuser.A7);
            param[7] = new SqlParameter("@maximumRows", objuser.A8);
            param[8] = new SqlParameter("@totalRows", SqlDbType.Int);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.VarChar,1000);
            param[9].Direction = ParameterDirection.Output;
            dss = Connection.Get_Dataset("ACC_GET_TDS_RECEIVABLE", param);
            objuser.A9 = (param[8].Value != DBNull.Value && param[8].Value != null) ? param[8].Value.ToString() : "0";
            objuser.A10 = param[9].Value.ToString();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return dss;
    }

    //TDS payable search params 
    public DataSet ACC_TDSPAYABLE_SELECT(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[11];

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


            param[1] = new SqlParameter("@Location", objUserBL.A2);
            param[2] = new SqlParameter("@FromDate", objUserBL.A3);
            param[3] = new SqlParameter("@ToDate", objUserBL.A4);

            param[4] = new SqlParameter("@Status", objUserBL.A5);
            param[5] = new SqlParameter("@Type", objUserBL.A6);
            param[6] = new SqlParameter("@SectionCode", objUserBL.A7);

            param[7] = new SqlParameter("@OrgType", objUserBL.A8);
            param[0] = new SqlParameter("@Organization", objUserBL.A1);

            param[8] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());

            param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[10].Direction = ParameterDirection.Output;


            foreach (SqlParameter p in param)
            {
                if (p != null)
                {
                    System.Diagnostics.Debug.WriteLine(
                        p.ParameterName + " = " +
                        (p.Value == null || p.Value == DBNull.Value ? "NULL" : p.Value.ToString()));
                }
            }


            if (objUserBL.A6 == "Summary")
            {
                ds = Connection.Get_Dataset("ACC_TDSPAYABLE_SELECT_summary", param);   //procedure name 
            }
            else if (objUserBL.A6 == "Detail")
                ds = Connection.Get_Dataset("ACC_TDSPAYABLE_SELECT", param);   //procedure name 
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}