using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;


public class SW_CONTROL
{
    public int result, UPDATE_ID = 0;

    public int SW_CONTROL_Details_Insert_Update(UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[30];

            param[0] = new SqlParameter("@SW_CONTROL_ID", objUserBL.SW_ID);
            param[1] = new SqlParameter("@JOBNO", objUserBL.JOBNO);
            param[2] = new SqlParameter("@INVOICE_SLNO", objUserBL.INVOICE_SLNO);
            param[3] = new SqlParameter("@ITEM_SLNO", objUserBL.ITEM_SLNO);
            param[4] = new SqlParameter("@CONTROL_TYPE_CODE", objUserBL.CONTROL_TYPE_CODE);
            param[5] = new SqlParameter("@CONTROL_LOCATION", objUserBL.CONTROL_LOCATION);
            param[6] = new SqlParameter("@CONTROL_START_DATE", Connection.DATE_FORMAT(objUserBL.CONTROL_START_DATE == null ? "01/01/1900" : objUserBL.CONTROL_START_DATE));
            param[7] = new SqlParameter("@CONTROL_END_DATE", Connection.DATE_FORMAT(objUserBL.CONTROL_END_DATE == null ? "01/01/1900" : objUserBL.CONTROL_END_DATE));
            param[8] = new SqlParameter("@CONTROL_RESULT_CODE", objUserBL.CONTROL_RESULT_CODE);
            param[9] = new SqlParameter("@CONTROL_RESULT_TEXT", objUserBL.CONTROL_RESULT_TEXT);
            param[10] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[18] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[20] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());
            param[13] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[14] = new SqlParameter("@Mflag", objUserBL.flag);

            param[21] = new SqlParameter("@CONTROL_MSR", objUserBL.CONTROL_MSR);
            param[22] = new SqlParameter("@CONTROL_UQC", objUserBL.CONTROL_UQC);
            param[23] = new SqlParameter("@CONTROL_SLNO", objUserBL.CONTROL_SLNO);
            param[24] = new SqlParameter("@AMENDMENT_TYPE", objUserBL.AMENDMENT_TYPE);
            param[25] = new SqlParameter("@AMENDMENT_STATUS", objUserBL.AMENDMENT_STATUS);

            param[15] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[15].Direction = ParameterDirection.Output;

            param[16] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[16].Direction = ParameterDirection.Output;

            param[17] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[17].Direction = ParameterDirection.Output;

            if (objUserBL.Ename == "B")
            {
                Connection.Get_Dataset("IMP_ITEM_SINGLEWINDOW_CONTROL_INS_UPD_BULK", param);
            }
            else
            {
                Connection.Get_Dataset("IMP_ITEM_SINGLEWINDOW_CONTROL_INS_UPD", param);
            }
            result = Convert.ToInt32(param[15].Value.ToString());

            if (objUserBL.flag == "S" || objUserBL.flag == "BES")
            {
                UPDATE_ID = Convert.ToInt32(param[17].Value.ToString());
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
            param[6] = new SqlParameter("@xmlString", objUserBL.Xml_A);

            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            param[8] = new SqlParameter("@Mstatus", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("IMP_ITEM_SINGLEWINDOW_SELECT", param);
           // result = Convert.ToInt32(param[8].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}