using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;

public class SW_CONST
{

    public int result, UPDATE_ID = 0;

    public int SW_CONSTITUENT_Details_Insert_Update(UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[30];

            param[0] = new SqlParameter("@SW_CONST_ID", objUserBL.SW_ID);
            param[1] = new SqlParameter("@JOBNO", objUserBL.JOBNO);
            param[2] = new SqlParameter("@INVOICE_SLNO", objUserBL.INVOICE_SLNO);
            param[3] = new SqlParameter("@ITEM_SLNO", objUserBL.ITEM_SLNO);

            param[4] = new SqlParameter("@CONSTITUENT_SRNO", objUserBL.CONSTITUENT_SRNO);
            param[5] = new SqlParameter("@CONSTITUENT_ELEMENT_NAME", objUserBL.CONSTITUENT_ELEMENT_NAME);
            param[6] = new SqlParameter("@CONSTITUENT_ELEMENT_CODE", objUserBL.CONSTITUENT_ELEMENT_CODE);
            param[7] = new SqlParameter("@CONSTITUENT_PERCENTAGE", objUserBL.CONSTITUENT_PERCENTAGE);
            param[8] = new SqlParameter("@CONSTITUENT_YIELD_PERCENTAGE", objUserBL.CONSTITUENT_YIELD_PERCENTAGE);
            param[9] = new SqlParameter("@ACTIVE_INGREDIENT", objUserBL.ACTIVE_INGREDIENT);

            param[10] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[11] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[12] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());
            param[13] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[14] = new SqlParameter("@Mflag",objUserBL.flag);
            param[18] = new SqlParameter("@AMENDMENT_TYPE", objUserBL.AMENDMENT_TYPE);
            param[19] = new SqlParameter("@AMENDMENT_STATUS", objUserBL.AMENDMENT_STATUS);

            param[15] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[15].Direction = ParameterDirection.Output;
            
            param[16] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[16].Direction = ParameterDirection.Output;

            param[17] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[17].Direction = ParameterDirection.Output;

            if (objUserBL.Ename == "B")
            {
                Connection.Get_Dataset("IMP_ITEM_SINGLEWINDOW_CONSTITUENT_INS_UPD_BULK", param);
            }
            else
            {
                Connection.Get_Dataset("IMP_ITEM_SINGLEWINDOW_CONSTITUENT_INS_UPD", param);
            }
            result = Convert.ToInt32(param[15].Value.ToString());

            if (objUserBL.flag == "S")
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
            result = Convert.ToInt32(param[8].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}