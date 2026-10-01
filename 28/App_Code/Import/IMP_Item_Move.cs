using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.IO;
using BussinessObject;

public class IMP_Item_Move
{
    public DataSet RetrieveAll_Item_Details(UserBO objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@JOBNO", objUserBL.JOBNO);
            param[1] = new SqlParameter("@INVOICE_SLNO", objUserBL.INVOICE_SLNO);
            param[2] = new SqlParameter("@ITEM_FROM_SLNO", objUserBL.From_Item_Slno);
            param[3] = new SqlParameter("@ITEM_TO_SLNO", objUserBL.To_Item_Slno);
            param[4] = new SqlParameter("@BRANCH_COMMON", objUserBL.BRANCH_COMMON);
            param[5] = new SqlParameter("@Flag", objUserBL.flag);
            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(Connection.GetConnection(), CommandType.StoredProcedure, "IMP_ITEM_MOVE", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Get_Inv_Item_Tot_Val(UserBO objUserBL)
    {
        DataSet dss = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@Jobno", Connection.IMP_Jobno());
            param[2] = new SqlParameter("@Inv_Slno", objUserBL.INVOICE_SLNO);
            param[3] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[4] = new SqlParameter("@flag", objUserBL.flag);

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            dss = SqlHelper.ExecuteDataset(Connection.GetConnection(), CommandType.StoredProcedure, "IMPORT_INV_ITEM_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return dss;
    }
}