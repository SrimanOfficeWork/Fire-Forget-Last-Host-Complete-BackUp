using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.IO;
using BussinessObject;

public class EXP_Item
{
    public int result, UPDATE_ID = 0, UPDATE_ITEMSLNO = 0, Gridview_Rowcount;
    public string TOTAL_ITEM_VALUE = "";
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);

    public DataSet Export_Item_Details_insertupdate(UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[90];
            param[0] = new SqlParameter("@ITEM_ID", objUserBL.ITEM_ID);
            param[1] = new SqlParameter("@JOBNO", objUserBL.JOBNO);
            param[2] = new SqlParameter("@INVOICE_SLNO", objUserBL.INVOICE_SLNO);
            param[3] = new SqlParameter("@INVOICE_NO", objUserBL.INVOICE_NO);
            param[4] = new SqlParameter("@ITEM_SLNO", objUserBL.ITEM_SLNO);
            param[5] = new SqlParameter("@ITEM_DESCRIPTION", objUserBL.ITEM_DESCRIPTION);
            param[6] = new SqlParameter("@RITCNO", objUserBL.RITCNO);
            param[7] = new SqlParameter("@ITEM_QTY", objUserBL.ITEM_QTY);
            param[8] = new SqlParameter("@ITEM_QTY_CODE", objUserBL.ITEM_QTY_CODE);
            param[9] = new SqlParameter("@ITEM_UNIT_PRICE", objUserBL.ITEM_UNIT_PRICE);
            param[10] = new SqlParameter("@ITEM_PER", objUserBL.ITEM_PER);
            param[42] = new SqlParameter("@ITEM_AMOUNT", objUserBL.ITEM_AMOUNT);
            param[11] = new SqlParameter("@ITEM_PMVVALUE", objUserBL.ITEM_PMVVALUE);
            param[13] = new SqlParameter("@ITEM_SCHEME_CODE", objUserBL.ITEM_SCHEME_CODE);
            param[15] = new SqlParameter("@ITEM_ACCESSORIES_DESC", objUserBL.ITEM_ACCESSORIES_DESC);
            param[17] = new SqlParameter("@ITEM_AR4_NO", objUserBL.ITEM_AR4_NO);
            param[18] = new SqlParameter("@ITEM_AR4_DATE", DateTime.Parse(objUserBL.ITEM_AR4_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[19] = new SqlParameter("@ITEM_COMMISSION_RATE", objUserBL.ITEM_COMMISSION_RATE);
            param[20] = new SqlParameter("@ITEM_DIVISION", objUserBL.ITEM_DIVISION);
            param[21] = new SqlParameter("@ITEM_RANGE", objUserBL.ITEM_RANGE);
            param[22] = new SqlParameter("@ITEM_REMARKS", objUserBL.ITEM_REMARKS);
            param[25] = new SqlParameter("@ITEM_IECCODE", objUserBL.ITEM_IECCODE);
            param[43] = new SqlParameter("@ITEM_EXPORTER_NAME", objUserBL.ITEM_EXPORTER_NAME);
            param[26] = new SqlParameter("@BR_SLNO", objUserBL.BR_SLNO);
            param[27] = new SqlParameter("@ADDRESS1", objUserBL.ADDRESS1);
            param[28] = new SqlParameter("@ADDRESS2", objUserBL.ADDRESS2);
            param[29] = new SqlParameter("@ADDRESS3", objUserBL.ADDRESS3);
            param[30] = new SqlParameter("@ADDRESS4", objUserBL.ADDRESS4);
            param[31] = new SqlParameter("@ADDRESS5", objUserBL.ADDRESS5);
            param[33] = new SqlParameter("@ITEM_STR_CODE", objUserBL.ITEM_STR_CODE);
            param[34] = new SqlParameter("@REWARD_POINTS", objUserBL.REWARD_POINTS);
            param[35] = new SqlParameter("@USER_ID", objUserBL.USER_ID);
            param[36] = new SqlParameter("@BRANCH_CODE", objUserBL.BRANCH_CODE);
            param[37] = new SqlParameter("@YEAR", objUserBL.YEAR);
            param[38] = new SqlParameter("@WORKING_PERIOD", objUserBL.WORKING_PERIOD);
            param[47] = new SqlParameter("@BRANCH_COMMON", objUserBL.BRANCH_COMMON);
            param[48] = new SqlParameter("@CESS_YN", objUserBL.CESS_YN);
            param[39] = new SqlParameter("@Mflag", objUserBL.flag);

            param[49] = new SqlParameter("@MANUFACTURER_PRODUCER", objUserBL.MANUFACTURER_PRODUCER_CODE);
            param[50] = new SqlParameter("@M_P_GROWER_CODE", objUserBL.M_P_GROWER_CODE);
            param[51] = new SqlParameter("@M_P_GROWER_ADD1", objUserBL.M_P_GROWER_ADD1);
            param[52] = new SqlParameter("@M_P_GROWER_ADD2", objUserBL.M_P_GROWER_ADD2);
            param[53] = new SqlParameter("@M_P_GROWER_CITY", objUserBL.M_P_GROWER_CITY);
            param[54] = new SqlParameter("@M_P_GROWER_COUNTRY_SUBDIV", objUserBL.M_P_GROWER_COUNTRY_SUBDIV);
            param[55] = new SqlParameter("@M_P_GROWER_PIN", objUserBL.M_P_GROWER_PIN);
            param[56] = new SqlParameter("@M_P_GROWER_COUNTRY", objUserBL.M_P_GROWER_COUNTRY);
            param[57] = new SqlParameter("@SOURCE_STATE", objUserBL.SOURCE_STATE);
            param[58] = new SqlParameter("@TRANSIT_COUNTRY", objUserBL.TRANSIT_COUNTRY);
            param[59] = new SqlParameter("@ACCESSORY_STATUS", objUserBL.ACCESSORY_STATUS);

            param[60] = new SqlParameter("@HAWB_NO", objUserBL.HAWB_NO);
            param[61] = new SqlParameter("@TOTAL_PKGS", objUserBL.TOTAL_PKGS);
            param[62] = new SqlParameter("@ENDUSE_ITEM", objUserBL.ENDUSE_ITEM);
            param[63] = new SqlParameter("@IGST_PAYMENT", objUserBL.IGST_PAYMENT);
            param[64] = new SqlParameter("@TAXABLE_VALUE", objUserBL.TAXABLE_VALUE);
            param[65] = new SqlParameter("@IGST_AMT", objUserBL.IGST_AMT);

            param[66] = new SqlParameter("@GSTN_TYPE", objUserBL.GSTN_TYPE);
            param[67] = new SqlParameter("@GSTN_ID", objUserBL.GSTN_ID);
            param[68] = new SqlParameter("@IGST_RATE", objUserBL.IGST_RATE);
            param[69] = new SqlParameter("@PMV_METHOD", objUserBL.PMV_METHOD);
            param[70] = new SqlParameter("@PMV_RATE", objUserBL.PMV_RATE);
            param[71] = new SqlParameter("@PMV_PER_UNIT", objUserBL.PMV_PER_UNIT);


            param[72] = new SqlParameter("@INFO_MSR", objUserBL.INFO_MSR);
            param[73] = new SqlParameter("@INFO_UQC", objUserBL.INFO_UQC);
            param[74] = new SqlParameter("@STATE_OF_ORIGIN", objUserBL.STATE_OF_ORIGIN);
            param[75] = new SqlParameter("@DISTRICT_OF_ORIGIN", objUserBL.DISTRICT_OF_ORIGIN);
            param[76] = new SqlParameter("@PTA_FTA", objUserBL.PTA_FTA);
            param[77] = new SqlParameter("@GST_CESS_AMT", objUserBL.GST_CESS_AMT);
            param[78] = new SqlParameter("@RODTEP", objUserBL.RODTEP);

            param[79] = new SqlParameter("@AMENDMENT_TYPE", objUserBL.AMENDMENT_TYPE);
            param[80] = new SqlParameter("@AMENDMENT_STATUS", objUserBL.AMENDMENT_STATUS);
            param[81] = new SqlParameter("@JOBNO_PS", objUserBL.JOBNO_PS);
            param[82] = new SqlParameter("@PART_NO", objUserBL.PART_NO);

            param[40] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[40].Direction = ParameterDirection.Output;
            param[41] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[41].Direction = ParameterDirection.Output;
            param[44] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[44].Direction = ParameterDirection.Output;
            param[45] = new SqlParameter("@UPDATE_ITEMSLNO", SqlDbType.Int, 1);
            param[45].Direction = ParameterDirection.Output;
            param[46] = new SqlParameter("@TOTAL_PRODUCT_VALUE", SqlDbType.Money);
            param[46].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(Connection.GetConnection(), CommandType.StoredProcedure, "SP_EXPORT_ITEM_DETAILS_INSERT_UPDATE_NEW", param);
            result = Convert.ToInt32(param[40].Value.ToString());

            TOTAL_ITEM_VALUE = param[46].Value.ToString();
            if (TOTAL_ITEM_VALUE != "")
                TOTAL_ITEM_VALUE = Convert.ToString(Math.Round(Convert.ToDouble(TOTAL_ITEM_VALUE), 2).ToString("0.00"));
            string err = param[41].Value.ToString();

            if (objUserBL.flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[44].Value.ToString());
                UPDATE_ITEMSLNO = Convert.ToInt32(param[45].Value.ToString());
            }
            else if (objUserBL.flag == "U")
                UPDATE_ITEMSLNO = Convert.ToInt32(param[45].Value.ToString());

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Gridview_Rowcount = ds.Tables[0].Rows.Count;
                }
                else
                    ds.Tables.Add(dt);
            }
            else
                ds.Tables.Add(dt);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }
    public DataSet RetrieveAll_Item_Details(UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@JOBNO", objUserBL.JOBNO);
            param[7] = new SqlParameter("@ITEM_ID", objUserBL.ITEM_ID);
            param[1] = new SqlParameter("@INVOICE_SLNO", objUserBL.INVOICE_SLNO);
            param[2] = new SqlParameter("@ITEM_SLNO", objUserBL.ITEM_SLNO);
            param[3] = new SqlParameter("@name", objUserBL.Ename);
            param[4] = new SqlParameter("@WORKING_PERIOD", objUserBL.WORKING_PERIOD);
            param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@INVOICE_NO", objUserBL.INVOICE_NO);
            param[9] = new SqlParameter("@TOTAL_PRODUCT_VALUE", SqlDbType.Money);
            param[9].Direction = ParameterDirection.Output;

            if (objUserBL.Ename == "delete")
            {
                ds = SqlHelper.ExecuteDataset(Connection.GetConnection(), CommandType.StoredProcedure, "SP_EXPORT_ITEM_DETAILS_SELECT_NEW", param);
                result = Convert.ToInt32(param[5].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(Connection.GetConnection(), CommandType.StoredProcedure, "SP_EXPORT_ITEM_DETAILS_SELECT_NEW", param);
            } 

            string err = param[6].Value.ToString();

            TOTAL_ITEM_VALUE = param[9].Value.ToString();
            if (TOTAL_ITEM_VALUE != "")
                TOTAL_ITEM_VALUE = Convert.ToString(Math.Round(Convert.ToDouble(TOTAL_ITEM_VALUE), 2).ToString("0.00"));

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Gridview_Rowcount = ds.Tables[0].Rows.Count;
                }
                else
                    ds.Tables.Add(dt);
            }
            else
                ds.Tables.Add(dt);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }
    public double RetrieveAll_Item_Calc(UserBO objUserBL)
    {
        double f = 0;
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", objUserBL.JOBNO);
            param[7] = new SqlParameter("@INVOICE_SLNO", objUserBL.INVOICE_SLNO);
            param[1] = new SqlParameter("@QTY", objUserBL.ITEM_QTY);
            param[3] = new SqlParameter("@Mflag", objUserBL.Ename);
            param[4] = new SqlParameter("@WORKING_PERIOD", objUserBL.WORKING_PERIOD);
            //param[5] = new SqlParameter("@MStatus", SqlDbType.Money);
            //param[5].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@MStatus", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@ITEM_VALUE", objUserBL.ITEM_VALUE);
            param[9] = new SqlParameter("@flag", objUserBL.flag);
            param[10] = new SqlParameter("@ITEM_ID", objUserBL.ITEM_ID);

            SqlHelper.ExecuteDataset(Connection.GetConnection(), CommandType.StoredProcedure, "SP_EXPORT_ITEM_DETAILS_INSERT_UPDATE_CALC", param);
            string err = param[6].Value.ToString();
            f = Convert.ToDouble(param[5].Value);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return f;
    }
    public DataSet Get_Inv_Item_Tot_Val(UserBO objUserBL)
    {
        DataSet dss = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@Jobno", Connection.EXP_Jobno());
            param[2] = new SqlParameter("@Inv_Slno", objUserBL.INVOICE_SLNO);
            param[3] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[4] = new SqlParameter("@flag", objUserBL.flag);
          
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            dss = SqlHelper.ExecuteDataset(Connection.GetConnection(), CommandType.StoredProcedure, "EXPORT_INV_ITEM_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return dss;
    }

    public DataSet Export_Product_Details_insertupdate(UserBO objUserBL)
    {
        DataSet dss = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[20];
            param[0] = new SqlParameter("@JOBNO", objUserBL.JOBNO);
            param[1] = new SqlParameter("@INVOICE_SLNO", objUserBL.INVOICE_SLNO);
            param[2] = new SqlParameter("@ITEM_SLNO", objUserBL.ITEM_SLNO);
            param[3] = new SqlParameter("@SCHEME_CODE", objUserBL.ITEM_SCHEME_CODE);
            param[4] = new SqlParameter("@RITCNO", objUserBL.RITCNO);
            param[5] = new SqlParameter("@ITEM_DESCRIPTION", objUserBL.ITEM_DESCRIPTION);
            param[6] = new SqlParameter("@REWARD_POINTS", objUserBL.REWARD_POINTS);
            param[7] = new SqlParameter("@STR_CODE", objUserBL.ITEM_STR_CODE);
            param[8] = new SqlParameter("@DRAWBACK_SL_NO", objUserBL.DRAWBACK_SL_NO);
            param[9] = new SqlParameter("@STR_Y_N", objUserBL.STR_Y_N);
            param[10] = new SqlParameter("@BRANCH_COMMON", objUserBL.BRANCH_COMMON);

            param[15] = new SqlParameter("@Mflag", objUserBL.flag);
            param[16] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[16].Direction = ParameterDirection.Output;
            param[17] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[17].Direction = ParameterDirection.Output;

            dss = SqlHelper.ExecuteDataset(Connection.GetConnection(), CommandType.StoredProcedure, "EXPORT_PRODUCT_MASTER_SINGLE_INS_UPD", param);
            result = Convert.ToInt32(param[16].Value.ToString());

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return dss;
    }

    public DataSet RetrieveAll_Taxable_Value_Update(UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@JOBNO", objUserBL.JOBNO);
            param[1] = new SqlParameter("@xml_exrate", objUserBL.Xml_A);
            param[3] = new SqlParameter("@name", objUserBL.Ename);
            param[4] = new SqlParameter("@BranchCode", objUserBL.BRANCH_COMMON);
            param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(Connection.GetConnection(), CommandType.StoredProcedure, "SP_EXPORT_UPDATE_INV_EXRATE_TAXABLEVALUE", param);
            result = Convert.ToInt32(param[5].Value.ToString());
            string err = param[6].Value.ToString();

            
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Gridview_Rowcount = ds.Tables[0].Rows.Count;
                }
                else
                    ds.Tables.Add(dt);
            }
            else
                ds.Tables.Add(dt);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Export_Rodtep_Details_insertupdate(UserBO objUserBL)
    {
        DataSet dss = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[20];
            param[0] = new SqlParameter("@JOBNO", objUserBL.JOBNO);
            param[1] = new SqlParameter("@INVOICE_SLNO", objUserBL.INVOICE_SLNO);
            param[2] = new SqlParameter("@ITEM_SLNO", objUserBL.ITEM_SLNO);
            param[3] = new SqlParameter("@RITCNO", objUserBL.RITCNO);
            param[4] = new SqlParameter("@RODTEP_RATE", objUserBL.ITEM_UNIT_PRICE);
            param[5] = new SqlParameter("@RODTEP_CAPVALUE", objUserBL.ITEM_PER);
            param[6] = new SqlParameter("@RODTEP_CAPVALUE_PER", objUserBL.ITEM_AMOUNT);
            param[7] = new SqlParameter("@RODTEP_CAPVALUE_UNIT", objUserBL.ITEM_PMVVALUE);
            param[8] = new SqlParameter("@RODTEP_AMOUNT", objUserBL.ITEM_SCHEME_CODE);
            param[9] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());
            param[10] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[11] = new SqlParameter("@Mflag", objUserBL.flag);
            param[12] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[12].Direction = ParameterDirection.Output;
            param[13] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[13].Direction = ParameterDirection.Output;
            param[14] = new SqlParameter("@CREATED_BY", Connection.Current_User());
            param[15] = new SqlParameter("@ITEM_QTY", objUserBL.ITEM_QTY);
            param[16] = new SqlParameter("@ITEM_QTY_CODE", objUserBL.ITEM_QTY_CODE);
            dss = SqlHelper.ExecuteDataset(Connection.GetConnection(), CommandType.StoredProcedure, "EXPORT_RODTEP_INFO_DETAILS_INS_UPD", param);
            result = Convert.ToInt32(param[12].Value.ToString());

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return dss;
    }
}