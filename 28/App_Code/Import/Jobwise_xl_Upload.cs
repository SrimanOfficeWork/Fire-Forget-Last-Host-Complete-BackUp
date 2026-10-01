using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Net;
using BussinessObject;

public class Jobwise_xl_Upload
{
    DataSet ds = new DataSet();
    public int result = 0;

    public DataSet Bind_Import_General_IEC_No(UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[7];

           
            param[0] = new SqlParameter("@IEC_NO", objUserBL.IEC_NO);
            param[4] = new SqlParameter("@BRANCH_SLNO", objUserBL.BRANCH_NO);
            param[1] = new SqlParameter("@name", objUserBL.Ename);
            param[5] = new SqlParameter("@Working_Period", objUserBL.WORKING_PERIOD);
            param[2] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[2].Direction = ParameterDirection.Output;
            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3].Direction = ParameterDirection.Output;

            if (objUserBL.Ename == "Select_IEC_details" || objUserBL.Ename == "Gen_MAX_ID" || objUserBL.Ename == "IGM_MAX_ID"
                || objUserBL.Ename == "CONTAINER_MAX_ID" || objUserBL.Ename == "IMPORT_Excel_Aval" || objUserBL.Ename == "Delete_Excel"
                || objUserBL.Ename == "Get_JOBID" || objUserBL.Ename == "Get_IGMNO_DATE" || objUserBL.Ename == "REIMPORT_MAX_ID"
                || objUserBL.Ename == "SINGLEWINDOW_INFO_MAX_ID" || objUserBL.Ename == "SINGLEWINDOW_CTRL_MAX_ID" || objUserBL.Ename == "SINGLEWINDOW_STMT_MAX_ID"
                || objUserBL.Ename == "INVOICE_MAX_ID" || objUserBL.Ename == "ITEM_MAX_ID" || objUserBL.Ename == "CERTIFICATE_MAX_ID"  || objUserBL.Ename == "BOND_MAX_ID"
                || objUserBL.Ename == "Check_Avail_SUPPLIER_details" || objUserBL.Ename == "SUPPORTING_DOC_MAX_ID")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMPORT_JOBWISE_EXCEL_UPLOAD_SELECT", param);
                result = Convert.ToInt32(param[2].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }



    public DataSet Select_Exp_INV(UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            //param[0] = new SqlParameter("@Tr_mode", Mode);
            param[1] = new SqlParameter("@xmlString", objUserBL.Xml_D);
            param[2] = new SqlParameter("@Jobno", objUserBL.JOBNO);
            param[3] = new SqlParameter("@Branch_Code", objUserBL.BRANCH_CODE);
            param[4] = new SqlParameter("@flag", objUserBL.Ename);

            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMP_EXP_EXCEL_UPLOAD_SELECT_JOBWISE", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet Bind_Export_General_IEC_No(UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[7];

            param[0] = new SqlParameter("@IEC_NO", objUserBL.IEC_NO);
            param[4] = new SqlParameter("@BRANCH_SLNO", objUserBL.BRANCH_NO);
            param[1] = new SqlParameter("@name", objUserBL.Ename);
            param[5] = new SqlParameter("@Working_Period", objUserBL.WORKING_PERIOD);
            param[2] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[2].Direction = ParameterDirection.Output;
            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3].Direction = ParameterDirection.Output;

            if (objUserBL.Ename == "Select_IEC_details" || objUserBL.Ename == "Gen_MAX_ID" || objUserBL.Ename == "ANNEX_PKGS_ID"
                || objUserBL.Ename == "CONTAINER_MAX_ID" || objUserBL.Ename == "INVOICE_MAX_ID" || objUserBL.Ename == "ITEM_MAX_ID"
                || objUserBL.Ename == "IMPORT_Excel_Aval" || objUserBL.Ename == "Delete_Excel" || objUserBL.Ename == "Get_JOBID"
                || objUserBL.Ename == "Get_IGMNO_DATE" || objUserBL.Ename == "AR4_MAX_ID" || objUserBL.Ename == "DRAWBACK_MAX_ID" || objUserBL.Ename == "EXP_SUPPORTING_DOCS_ID" || objUserBL.Ename == "EXP_ANNEXURE_C1_ID"
                || objUserBL.Ename == "LICENSE_MAX_ID" || objUserBL.Ename == "LICENSE_IMP_EXP_MAX_ID" || objUserBL.Ename == "Check_Avail_IEC_details"
                || objUserBL.Ename == "Check_Avail_CONSIGNEE_details" || objUserBL.Ename == "Check_Avail_BUYER_details" || objUserBL.Ename == "Check_Avail_SUPPLIER_details")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_JOBWISE_EXCEL_UPLOAD_SELECT", param);
                result = Convert.ToInt32(param[2].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}