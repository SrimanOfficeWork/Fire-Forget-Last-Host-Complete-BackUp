using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.IO;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Diagnostics;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BussinessObject;


public class Export_XL_Upload
{
    public String Xml_D;

    private string _Ename;

    private string _JOBNO;
    private string _Branch_Code;
    private string _USER_ID;
    private string _WORKING_PERIOD;

    public string Ename { get { return _Ename; } set { _Ename = value; } }
    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string Branch_Code { get { return _Branch_Code; } set { _Branch_Code = value; } }
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }

    public String Xml_Inv;
    public String Xml_Item;
    public String Xml_Drawback;
    public String Xml_Lic;
    public String Xml_SW_dbk_SW_Stmt;
    public String Xml_SW_InfoType;
    public String Xml_Spl;
    public String Xml_Buyer;

    public int result;

    DataSet ds = new DataSet();
    public DataSet Select_Exp_INV()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            //param[0] = new SqlParameter("@Tr_mode", Mode);
            param[1] = new SqlParameter("@xmlString", Xml_D);
            param[2] = new SqlParameter("@Jobno", JOBNO);
            param[3] = new SqlParameter("@Branch_Code", Branch_Code);
            param[4] = new SqlParameter("@flag", Ename);

            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXP_EXCEL_UPLOAD_SELECT", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public void Bulk_Item_Excel_Upload(DataTable dt, DataTable dt1, DataTable dt2, DataTable dt3, DataTable dt4, DataTable dt5, string mode)
    {
        try
        {

            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@Jobno", JOBNO);
            param[1] = new SqlParameter("@Xml_Inv", Xml_Inv = EXP_ConvertDataTableToXML(dt));
            param[2] = new SqlParameter("@Xml_Item", Xml_Item = EXP_ConvertDataTableToXML(dt1));
            param[3] = new SqlParameter("@Xml_Drawback", Xml_Drawback = EXP_ConvertDataTableToXML(dt2));
            param[4] = new SqlParameter("@Xml_Lic", Xml_Lic = EXP_ConvertDataTableToXML(dt3));
            param[8] = new SqlParameter("@Xml_SW_dbk_SW_Stmt", Xml_SW_dbk_SW_Stmt = EXP_ConvertDataTableToXML(dt4));
            param[9] = new SqlParameter("@Xml_Buyer", Xml_Buyer = EXP_ConvertDataTableToXML(dt5));


            param[5] = new SqlParameter("@USER_ID", USER_ID);
            param[6] = new SqlParameter("@BRANCH_CODE", Branch_Code);
            param[7] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

            param[13] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[13].Direction = ParameterDirection.Output;
            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXP_GEN_EXCEL_UPLOAD", param);
            result = Convert.ToInt32(param[13].Value.ToString());
        }

        catch (Exception ex)
        {

        }
    }

    public void Bulk_Item_Excel_Upload_SHAHI(DataTable dt, DataTable dt1, DataTable dt2, DataTable dt3, DataTable dt4, DataTable dt5, string mode)
    {
        try
        {

            SqlParameter[] param = new SqlParameter[20];
            param[0] = new SqlParameter("@Jobno", JOBNO);
            param[1] = new SqlParameter("@Xml_Inv", Xml_Inv = EXP_ConvertDataTableToXML(dt));
            param[2] = new SqlParameter("@Xml_Item", Xml_Item = EXP_ConvertDataTableToXML(dt1));
            param[3] = new SqlParameter("@Xml_Drawback", Xml_Drawback = EXP_ConvertDataTableToXML(dt2));
            param[4] = new SqlParameter("@Xml_Lic", Xml_Lic = EXP_ConvertDataTableToXML(dt3));
            param[8] = new SqlParameter("@Xml_SW_dbk_SW_Stmt", Xml_SW_dbk_SW_Stmt = EXP_ConvertDataTableToXML(dt4));
            param[15] = new SqlParameter("@Xml_SW_InfoType", Xml_SW_InfoType = EXP_ConvertDataTableToXML(dt5));

            param[5] = new SqlParameter("@USER_ID", USER_ID);
            param[6] = new SqlParameter("@BRANCH_CODE", Branch_Code);
            param[7] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

            param[13] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[13].Direction = ParameterDirection.Output;
            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXP_GEN_SHAHI_EXCEL_UPLOAD", param);
            result = Convert.ToInt32(param[13].Value.ToString());
        }

        catch (Exception ex)
        {

        }
    }

    private static string EXP_ConvertDataTableToXML(DataTable dtData)
    {
        DataSet dsData = new DataSet();
        StringBuilder sbSQL;
        StringWriter swSQL;
        string XMLformat;
        try
        {
            sbSQL = new StringBuilder();
            swSQL = new StringWriter(sbSQL);
            dsData.Merge(dtData, true, MissingSchemaAction.AddWithKey);
            dsData.Tables[0].TableName = "SampleDataTable";
            foreach (DataColumn col in dsData.Tables[0].Columns)
            {
                col.ColumnMapping = MappingType.Attribute;
            }
            dsData.WriteXml(swSQL, XmlWriteMode.WriteSchema);
            XMLformat = sbSQL.ToString();
            return XMLformat;
        }
        catch (Exception sysException)
        {
            throw sysException;
        }
    }


    public DataSet Exp_Spl_check()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@Xml_Spl", Xml_Spl);
            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "Sp_Exp_Spl_check", param);
        }
        catch (Exception ex)
        {
        }
        return ds;
    }

    public void Bulk_Item_Excel_Upload_New_XML(DataTable dt1, DataTable dt2, DataTable dt_dbk, string EXPORT_JOBDATE, string mode)
    {
        try
        {

            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@Jobno", JOBNO);
            // param[1] = new SqlParameter("@Xml_All", Xml_Inv = EXP_ConvertDataTableToXML(dt1));
            param[1] = new SqlParameter("@Xml_All", ""); // Data directly takes from "TBL_EXPORT_EXCEL_FORMAT" table
            param[2] = new SqlParameter("@JobDate", EXPORT_JOBDATE);
            param[3] = new SqlParameter("@Xml_Drawback", Xml_Drawback = EXP_ConvertDataTableToXML(dt_dbk));
            param[9] = new SqlParameter("@Xml_Buyer", Xml_Buyer = EXP_ConvertDataTableToXML(dt2));

            param[5] = new SqlParameter("@USER_ID", USER_ID);
            param[6] = new SqlParameter("@BRANCH_CODE", Branch_Code);
            param[7] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[13] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[13].Direction = ParameterDirection.Output;
            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXP_INV_ITEM_EXCEL_UPLOAD_NEW", param);
            result = Convert.ToInt32(param[13].Value.ToString());
        }

        catch (Exception ex)
        {

        }
    }

    public DataSet Bulk_Excel_Validation(string Type)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@Type", Type);
            param[1] = new SqlParameter("@Flag", Ename);

            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXCEL_UPLOAD_VALIDATION_ALL", param);
            result = Convert.ToInt32(param[13].Value.ToString());
        }
        catch (Exception ex)
        {

        }
        return ds;
    }
    public DataSet Export_Product_Setting_Master_Bulk_Insert(UserBO objUserBL, DataTable dtdata)//** kavi & Ajith**//
    {
        DataSet ds = new DataSet(); int result = 0;
        try
        {

            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@BranchCode", Connection.Current_Branch());
            param[1] = new SqlParameter("@List", "");
            param[2] = new SqlParameter("@UserID", Connection.Current_User());
            param[3] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[4] = new SqlParameter("@name", objUserBL.Ename);
            param[5] = new SqlParameter("@Types_tbl_Data", dtdata);

            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_Export_Product_Setting_Master_bulk_Update", param);
            if (objUserBL.Ename != "Auto_ID")
            {
                result = Convert.ToInt32(param[6].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet Bulk_Item_RE_Export_Excel_Upload_(string xml_Data_ExpREItem, string EXPORT_JOBDATE, string Ename)
    {
        try
        {

            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@Jobno", JOBNO);
            param[1] = new SqlParameter("@Xml_Itemreexp", xml_Data_ExpREItem);
            param[2] = new SqlParameter("@JobDate", EXPORT_JOBDATE);
            param[3] = new SqlParameter("@Flag", Ename);

            param[5] = new SqlParameter("@USER_ID", USER_ID);
            param[6] = new SqlParameter("@BRANCH_CODE", Branch_Code);
            param[7] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[13] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[13].Direction = ParameterDirection.Output;
            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXP_ITEM_RE_EXP_EXCEL_UPLOAD", param);
            result = Convert.ToInt32(param[13].Value.ToString());
        }

        catch (Exception ex)
        {

        }
        return ds;
    }

}