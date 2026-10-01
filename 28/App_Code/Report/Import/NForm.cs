using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using BussinessObject;
/// <summary>
/// Summary description for NForm
/// </summary>
public class NForm
{
    public DataSet ds = new DataSet();
    ErrorLogs er = new ErrorLogs();
    DataTable dt = new DataTable();
    UserBO Objcls = new UserBO();
    public int result, UPDATE_ID;

    public DataSet RetrieveAll_N_FORM_Details(UserBO ObjUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", ObjUserBL.JOBNO);
            param[1] = new SqlParameter("@name", ObjUserBL.Ename);
            param[2] = new SqlParameter("@Working_Period", ObjUserBL.WORKING_PERIOD);
            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(Connection.GetConnection(), CommandType.StoredProcedure, "NForm_LCD_Report_LCD", param);
            result = Convert.ToInt32(param[3].Value.ToString());
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public int NForm_InsertUpdate(UserBO ObjUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[50];

            param[1] = new SqlParameter("@NFORM_ID", ObjUserBL.NFORM_ID);
            param[2] = new SqlParameter("@JOBNO", ObjUserBL.JOBNO);
            param[3] = new SqlParameter("@NF_NAME1",ObjUserBL.NF_NAME1);
            param[4] = new SqlParameter("@NF_NAME2",ObjUserBL.NF_NAME2);
            param[5] = new SqlParameter("@NF_NAME3",ObjUserBL.NF_NAME3);
            param[6] = new SqlParameter("@NF_NAME4",ObjUserBL.NF_NAME4);
            param[7] = new SqlParameter("@NF_TO",ObjUserBL.NF_TO);
            param[8] = new SqlParameter("@NF_FIELD1",ObjUserBL.NF_FIELD1);
            param[9] = new SqlParameter("@NF_FIELD2",ObjUserBL.NF_FIELD2);
            param[10] = new SqlParameter("@NF_FIELD3",ObjUserBL.NF_FIELD3);
            param[11] = new SqlParameter("@NF_FIELD4",ObjUserBL.NF_FIELD4);
            param[12] = new SqlParameter("@NF_FIELD5",ObjUserBL.NF_FIELD5);
            param[13] = new SqlParameter("@NF_FIELD6",ObjUserBL.NF_FIELD6);
            param[14] = new SqlParameter("@NF_FIELD7",ObjUserBL.NF_FIELD7);
            param[15] = new SqlParameter("@NF_FIELD8",ObjUserBL.NF_FIELD8);
            param[16] = new SqlParameter("@NF_NO_DATEOFDOC",ObjUserBL.NF_NO_DATEOFDOC);
            param[17] = new SqlParameter("@NF_PKGNO",ObjUserBL.NF_PKGNO);
            param[18] = new SqlParameter("@NF_DESCNO",ObjUserBL.NF_DESCNO);
            param[19] = new SqlParameter("@NF_DESC_ARTICLES",ObjUserBL.NF_DESC_ARTICLES);
            param[20] = new SqlParameter("@NF_IMPORTMARKS",ObjUserBL.NF_IMPORTMARKS);
            param[21] = new SqlParameter("@NF_WEIGHT_QTY",ObjUserBL.NF_WEIGHT_QTY);
            param[22] = new SqlParameter("@NF_NFORM_NO",ObjUserBL.NF_NFORM_NO);
            param[23] = new SqlParameter("@NF_NFORM_PKGNO",ObjUserBL.NF_NFORM_PKGNO);
            param[24] = new SqlParameter("@NF_OCTRAI_PAID",ObjUserBL.NF_OCTRAI_PAID);
            param[25] = new SqlParameter("@NF_IMP_BILL",ObjUserBL.NF_IMP_BILL);
            param[26] = new SqlParameter("@NF_PKG_ESCORTED",ObjUserBL.NF_PKG_ESCORTED);
            param[27] = new SqlParameter("@NF_NO_DATEOFEXPORT",ObjUserBL.NF_NO_DATEOFEXPORT);
            param[28] = new SqlParameter("@NF_VALUE_OCTRAI",ObjUserBL.NF_VALUE_OCTRAI);
            param[29] = new SqlParameter("@NF_REMARKS",ObjUserBL.NF_REMARKS);
            param[30] = new SqlParameter("@NF_PLACEOFEXPORT",ObjUserBL.NF_PLACEOFEXPORT);
            param[31] = new SqlParameter("@NF_NAME_APPLICANT",ObjUserBL.NF_NAME_APPLICANT);
            param[32] = new SqlParameter("@NF_DATEE",ObjUserBL.NF_DATEE);
            param[33] = new SqlParameter("@NF_AUTHORIZED",ObjUserBL.NF_AUTHORIZED);
            param[34] = new SqlParameter("@NF_ESCORD_FEES",ObjUserBL.NF_ESCORD_FEES);
            param[35] = new SqlParameter("@NF_DELIVED_TO",ObjUserBL.NF_DELIVED_TO);
            param[36] = new SqlParameter("@NF_BRANCHCODE", ObjUserBL.BRANCH_CODE);
            param[37] = new SqlParameter("@NF_YEAR", ObjUserBL.YEAR);
            param[38] = new SqlParameter("@NF_OCTRAI_NO",ObjUserBL.NF_OCTRAI_NO);
            param[39] = new SqlParameter("@NF_OCTRAI_DATE",ObjUserBL.NF_OCTRAI_DATE);
            param[40] = new SqlParameter("@NF_OCTRAI_PERCENT",ObjUserBL.NF_OCTRAI_PERCENT);
            param[41] = new SqlParameter("@NF_WORKINGPERIOD", ObjUserBL.WORKING_PERIOD);

            param[46] = new SqlParameter("@BRANCH_COMMON", ObjUserBL.BRANCH_COMMON);
            param[42] = new SqlParameter("@Mflag", ObjUserBL.flag);
            param[43] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[43].Direction = ParameterDirection.Output;
            param[44] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[44].Direction = ParameterDirection.Output;
            param[45] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[45].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(Connection.GetConnection(), CommandType.StoredProcedure, "NForm_LCD_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[43].Value.ToString());
            if (ObjUserBL.flag == "S")
                UPDATE_ID = Convert.ToInt32(param[45].Value.ToString());
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return result;
    }


    public DataSet RetrieveAll_NFORM_NORMAL_SEARCH(UserBO ObjUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", ObjUserBL.JOBNO);
            param[1] = new SqlParameter("@ImporterName", ObjUserBL.NF_NAME_APPLICANT);
            param[2] = new SqlParameter("@from_date", ObjUserBL.From_date);
            param[3] = new SqlParameter("@to_date", ObjUserBL.Todate);
            param[4] = new SqlParameter("@Working_Period", ObjUserBL.WORKING_PERIOD);
            param[5] = new SqlParameter("@Branch", ObjUserBL.BRANCH_CODE);
            param[6] = new SqlParameter("@Ename", ObjUserBL.Ename);

            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;
            //param[6] = new SqlParameter("@startRowIndex", startRowIndex);
            //param[7] = new SqlParameter("@maximumRows", maximumRows);
            //param[8] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            //param[8].Direction = ParameterDirection.Output;
            if (ObjUserBL.Ename == "delete")
            {
                SqlHelper.ExecuteDataset(Connection.GetConnection(), CommandType.StoredProcedure, "NForm_NORMAL_SEARCH", param);
                result = Convert.ToInt32(param[4].Value.ToString());
            }
            if (ObjUserBL.Ename == "autoid")
            {
                SqlHelper.ExecuteDataset(Connection.GetConnection(), CommandType.StoredProcedure, "NForm_NORMAL_SEARCH", param);
                result = Convert.ToInt32(param[4].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(Connection.GetConnection(), CommandType.StoredProcedure, "NForm_NORMAL_SEARCH", param);
                result = Convert.ToInt32(param[8].Value.ToString());

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                    }
                    else
                        ds.Tables.Add(dt);
                }
                else
                    ds.Tables.Add(dt);
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return ds;
    }
}