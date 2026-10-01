using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ApplicationBlocks.Data;

public class Exp_Packing_List
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;
    
    public DataSet Pkg_List_Select(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[2] = new SqlParameter("@Item_Id", objUserBL.A1);
            param[3] = new SqlParameter("@Exp_name", objUserBL.A2);
            param[4] = new SqlParameter("@Con_Jobno", objUserBL.A3);
            param[5] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[6] = new SqlParameter("@Flag", objUserBL.A4);
            param[7] = new SqlParameter("@Company_Id", Connection.COMPANYID());
            
            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("EXP_PACKING_LIST_CONSOLIDATED_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Pkg_List_Rpt(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[2] = new SqlParameter("@Item_Id", objUserBL.A1);
            param[5] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[6] = new SqlParameter("@Flag", objUserBL.A4);
            param[7] = new SqlParameter("@Company_Id", Connection.COMPANYID());

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("EXP_PACKING_LIST_CONSOLIDATED_RPT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public void Packing_List_INS_UPD(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[51];
            param[1] = new SqlParameter("@ID", objUserBL.A1);
            param[2] = new SqlParameter("@EXPORTER_NAME", objUserBL.A2);
            param[3] = new SqlParameter("@R_ID", objUserBL.A3);
            param[4] = new SqlParameter("@REF_NAME", objUserBL.A4);
            param[5] = new SqlParameter("@JOBNO", objUserBL.A5);
            param[6] = new SqlParameter("@PACKING_DATE", Connection.DATE_FORMAT(objUserBL.A6));
            param[7] = new SqlParameter("@INVOCE_NO_DATE", objUserBL.A7);

            param[8] = new SqlParameter("@DESC_I", objUserBL.A8);
            param[9] = new SqlParameter("@DESC_II", objUserBL.A9);
            param[10] = new SqlParameter("@DESC_III", objUserBL.A10);
            param[11] = new SqlParameter("@TOTAL_NET_WGT", objUserBL.A11);
            param[12] = new SqlParameter("@TOTAL_GROSS_WGT", objUserBL.A12);
            param[13] = new SqlParameter("@xmlString", objUserBL.A13);
            param[14] = new SqlParameter("@DESC_IV", objUserBL.A15);

            param[43] = new SqlParameter("@Flag", objUserBL.A14);
            param[44] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[45] = new SqlParameter("@User_Id", Connection.Current_User());
            param[46] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[47] = new SqlParameter("@Working_period", Connection.WorkingPeriod());

            param[48] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[48].Direction = ParameterDirection.Output;

            param[49] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[49].Direction = ParameterDirection.Output;

            param[50] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[50].Direction = ParameterDirection.Output;

            Connection.Get_Dataset("EXPORT_PACKING_LIST_CONSOLIDATED_INS_UPD", param);
            result = Convert.ToInt32(param[48].Value.ToString());

            if (objUserBL.A14 == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[50].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public DataSet Packing_List_Search(Global_variables objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.A4 != string.Empty && objUserBL.A4 != null)
            {
                arr = objUserBL.A4.Split('/');
                objUserBL.A4 = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.A5 != string.Empty && objUserBL.A5 != null)
            {
                arr2 = objUserBL.A5.Split('/');
                objUserBL.A5 = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[15];

            param[1] = new SqlParameter("@Exp_Name", objUserBL.A1);
            param[2] = new SqlParameter("@Exp_Ref_Name", objUserBL.A2);
            param[3] = new SqlParameter("@Jobno", objUserBL.A3);
            param[4] = new SqlParameter("@from_date", objUserBL.A4);
            param[5] = new SqlParameter("@to_date", objUserBL.A5);
          
            param[6] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[7] = new SqlParameter("@Flag", objUserBL.A6);

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("EXPORT_PACKING_LIST_CONSOLIDATED_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}