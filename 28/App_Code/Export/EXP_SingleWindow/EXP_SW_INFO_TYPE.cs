using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using BussinessObject;

public class EXP_SW_INFO_TYPE
{
    public int result, UPDATE_ID = 0;

    public int SW_INFOTYPE_Details_Insert_Update(UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[30];

            param[0] = new SqlParameter("@SW_INFO_TYPE_ID", objUserBL.SW_ID);
            param[1] = new SqlParameter("@JOBNO", objUserBL.JOBNO);
            param[2] = new SqlParameter("@INVOICE_SLNO", objUserBL.INVOICE_SLNO);
            param[3] = new SqlParameter("@ITEM_SLNO", objUserBL.ITEM_SLNO);

            param[4] = new SqlParameter("@INFO_TYPE", objUserBL.INFO_TYPE);
            param[5] = new SqlParameter("@INFO_QUALIFIER", objUserBL.INFO_QUALIFIER);
            param[6] = new SqlParameter("@INFO_CODE", objUserBL.INFO_CODE);
            param[7] = new SqlParameter("@INFO_TEXT", objUserBL.INFO_TEXT);
            param[8] = new SqlParameter("@INFO_MSR", objUserBL.INFO_MSR);
            param[9] = new SqlParameter("@INFO_UQC", objUserBL.INFO_UQC);
            param[10] = new SqlParameter("@DEPARTMENT", objUserBL.DEPARTMENT);
            param[11] = new SqlParameter("@I_U_TYPE", objUserBL.I_U_TYPE);

            param[12] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[13] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[14] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());
            param[15] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            
            param[16] = new SqlParameter("@Mflag", objUserBL.flag);
            param[17] = new SqlParameter("@SLNO", objUserBL.JOBID);


            param[18] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[18].Direction = ParameterDirection.Output;

            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;

            param[20] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[20].Direction = ParameterDirection.Output;

            if (objUserBL.Ename == "B")
            {
                Connection.Get_Dataset("EXP_ITEM_SINGLEWINDOW_INFOTYPE_INS_UPD_BULK", param);
            }
            else
            {
                Connection.Get_Dataset("EXP_ITEM_SINGLEWINDOW_INFOTYPE_INS_UPD", param);
            }
            result = Convert.ToInt32(param[18].Value.ToString());

            if (objUserBL.flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[20].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }
    DataSet ds = new DataSet();
    public DataSet SingleWindow_Select(UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@JOBNO", objUserBL.JOBNO);
            param[1] = new SqlParameter("@INVOICE_SLNO", objUserBL.INVOICE_SLNO);
            param[2] = new SqlParameter("@ITEM_SLNO", objUserBL.ITEM_SLNO);
            param[3] = new SqlParameter("@BRANCH_COMMON", objUserBL.BRANCH_COMMON);
            param[4] = new SqlParameter("@Mflag", objUserBL.Ename);
            param[5] = new SqlParameter("@DELETE_ID", objUserBL.DELETE_ID);

            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            param[8] = new SqlParameter("@Mstatus", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("EXP_ITEM_SINGLEWINDOW_SELECT", param);
            result = Convert.ToInt32(param[8].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


}