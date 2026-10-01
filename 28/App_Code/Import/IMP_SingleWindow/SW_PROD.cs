using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;

public class SW_PROD
{
    public int result, UPDATE_ID = 0;

    public int SW_PRODUCTION_Details_Insert_Update(UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[30];

            param[0] = new SqlParameter("@SW_PROD_ID",objUserBL.SW_ID);
            param[1] = new SqlParameter("@JOBNO", objUserBL.JOBNO);
            param[2] = new SqlParameter("@INVOICE_SLNO", objUserBL.INVOICE_SLNO);
            param[3] = new SqlParameter("@ITEM_SLNO", objUserBL.ITEM_SLNO);

            param[4] = new SqlParameter("@PRODUCTION_BATCH_IDENTIFIER", objUserBL.PRODUCTION_BATCH_IDENTIFIER);
            param[5] = new SqlParameter("@PRODUCTION_BATCH_QUANTITY", objUserBL.PRODUCTION_BATCH_QUANTITY);
            param[6] = new SqlParameter("@UNIT_QTY_CODE", objUserBL.UNIT_QTY_CODE);

            param[7] = new SqlParameter("@DATE_OF_MANUFACTURING", Connection.DATE_FORMAT(objUserBL.DATE_OF_MANUFACTURING == null ? "01/01/1900" : objUserBL.DATE_OF_MANUFACTURING));
            param[8] = new SqlParameter("@DATE_OF_EXPIRY", Connection.DATE_FORMAT(objUserBL.DATE_OF_EXPIRY == null ? "01/01/1900" : objUserBL.DATE_OF_EXPIRY));

            param[9] = new SqlParameter("@BEST_BEFORE", Connection.DATE_FORMAT(objUserBL.BEST_BEFORE == null ? "01/01/1900" : objUserBL.BEST_BEFORE));

            param[10] = new SqlParameter("@RESIDUAL_SHELF_LIFE_DAYS", objUserBL.RESIDUAL_SHELF_LIFE_DAYS);
            param[11] = new SqlParameter("@TOTAL_SHELF_LIFE_DAYS", objUserBL.TOTAL_SHELF_LIFE_DAYS);
            param[12] = new SqlParameter("@RESIDUAL_SHELF_PERCENT", objUserBL.RESIDUAL_SHELF_PERCENT);

            param[13] = new SqlParameter("@USER_ID", objUserBL.USER_ID);

            param[16] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[18] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());
            param[21] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());

            param[22] = new SqlParameter("@Mflag", objUserBL.flag);
            param[26] = new SqlParameter("@AMENDMENT_TYPE", objUserBL.AMENDMENT_TYPE);
            param[27] = new SqlParameter("@AMENDMENT_STATUS", objUserBL.AMENDMENT_STATUS);

            param[23] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[23].Direction = ParameterDirection.Output;

            param[24] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[24].Direction = ParameterDirection.Output;

            param[25] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[25].Direction = ParameterDirection.Output;

            if (objUserBL.Ename == "B")
            {
                Connection.Get_Dataset("IMP_ITEM_SINGLEWINDOW_PRODUCTION_INS_UPD_BULK", param);
            }
            else
            {
                Connection.Get_Dataset("IMP_ITEM_SINGLEWINDOW_PRODUCTION_INS_UPD", param);
            }
            result = Convert.ToInt32(param[23].Value.ToString());
            if (objUserBL.Ename == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[25].Value.ToString());
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