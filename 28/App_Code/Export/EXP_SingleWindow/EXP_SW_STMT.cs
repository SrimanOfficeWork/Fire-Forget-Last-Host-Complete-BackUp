using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;

public class EXP_SW_STMT
{
    public int result, UPDATE_ID = 0;

    public int SW_Statement(UserBO objUserBL, string Type)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[100];

            param[0] = new SqlParameter("@SW_STMT_ID", objUserBL.SW_STMT_ID);
            param[1] = new SqlParameter("@JOBNO", objUserBL.JOBNO);
            param[2] = new SqlParameter("@INVOICE_SLNO", objUserBL.INVOICE_SLNO);
            param[3] = new SqlParameter("@ITEM_SLNO", objUserBL.ITEM_SLNO);
            param[4] = new SqlParameter("@USER_ID", objUserBL.USER_ID);

            param[28] = new SqlParameter("@SLNO", objUserBL.JOBID);

            param[31] = new SqlParameter("@STMT_TYPE", objUserBL.STMT_TYPE);
            param[32] = new SqlParameter("@STMT_CODE", objUserBL.STMT_CODE);
            param[33] = new SqlParameter("@STMT_TEXT", objUserBL.STMT_TEXT);
            param[34] = new SqlParameter("@I_U_TYPE", objUserBL.I_U_TYPE);

            param[57] = new SqlParameter("@BRANCH_CODE", objUserBL.BRANCH_CODE);
            param[58] = new SqlParameter("@WORKING_PERIOD", objUserBL.WORKING_PERIOD);
            param[59] = new SqlParameter("@Mflag", objUserBL.Ename);
            param[61] = new SqlParameter("@BRANCH_COMMON", objUserBL.BRANCH_COMMON);

            param[65] = new SqlParameter("@AMENDMENT_TYPE", objUserBL.AMENDMENT_TYPE);
            param[66] = new SqlParameter("@AMENDMENT_STATUS", objUserBL.AMENDMENT_STATUS);


            param[62] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[62].Direction = ParameterDirection.Output;

            param[63] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[63].Direction = ParameterDirection.Output;

            param[64] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[64].Direction = ParameterDirection.Output;

            if (Type == "Single")
            {
                Connection.Get_Dataset("EXP_ITEM_SINGLEWINDOW_STMT_INS_UPD", param);
            }
            else
            {
                Connection.Get_Dataset("EXP_ITEM_SINGLEWINDOW_STMT_INS_UPD_BULK", param);
            }

            result = Convert.ToInt32(param[62].Value.ToString());

            if (objUserBL.Ename == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[64].Value.ToString());
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