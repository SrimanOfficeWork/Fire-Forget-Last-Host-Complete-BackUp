using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ApplicationBlocks.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Services;
using System.Data.OleDb;
using System.Collections;


public class Import_XL_Upload
{
  public  int result = 0;


    private string _result1, _Flag;
    public string result1 { get { return _result1; } set { _result1 = value; } }
    public string Flag { get { return _Flag; } set { _Flag = value; } }
  
    public DataSet IMP_CP_XL_Select(UserBO objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Jobno", Connection.IMP_Jobno());
            param[2] = new SqlParameter("@xmlString", objUserBL.Xml_D);
            param[3] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[4] = new SqlParameter("@flag", objUserBL.flag);
            param[12] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());

            param[13] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[13].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("IMP_EXCEL_UPLOAD_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    //public DataSet Special_Character_Chk(UserBO objUserBL)
    //{
    //    DataSet ds = new DataSet();
    //    try
    //    {
    //        SqlParameter[] param = new SqlParameter[5];

    //        param[1] = new SqlParameter("@xmlString", objUserBL.Xml_D);
    //        param[2] = new SqlParameter("@Cus_Code", objUserBL.CUSTOMS_HOUSE);
    //        param[3] = new SqlParameter("@flag", objUserBL.flag);

    //        param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
    //        param[4].Direction = ParameterDirection.Output;

    //        ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "ADMIN_XL_UPLOAD_SELECT_Chk_FTA_New", param);
    //        //ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "ADMIN_XL_UPLOAD_SELECT_Chk_FTA_Test", param);
    //        //ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "ADMIN_XL_UPLOAD_SELECT_Chk_antony", param);
    //        //ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "ADMIN_XL_UPLOAD_SELECT_Chk_Ram", param);
    //    }
    //    catch (Exception ex)
    //    {
    //        Connection.Error_Msg(ex.Message);
    //    }
    //    return ds;
    //}

    public DataSet Special_Character_Chk(UserBO objUserBL)
    {
        DataSet ds = new DataSet();

        try
        {
            using (SqlConnection con = new SqlConnection(
                System.Configuration.ConfigurationManager.AppSettings["con"]))
            {
                using (SqlCommand cmd = new SqlCommand("ADMIN_XL_UPLOAD_SELECT_Chk_FTA_New", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // ✅ Increase timeout (in seconds)
                    cmd.CommandTimeout = 300;   // 5 minutes

                    cmd.Parameters.Add("@xmlString", SqlDbType.NVarChar).Value =
                      string.IsNullOrEmpty(objUserBL.Xml_D)
                      ? (object)DBNull.Value
                      : objUserBL.Xml_D;

                    cmd.Parameters.Add("@Cus_Code", SqlDbType.VarChar).Value =
                        string.IsNullOrEmpty(objUserBL.CUSTOMS_HOUSE)
                        ? (object)DBNull.Value
                        : objUserBL.CUSTOMS_HOUSE;

                    cmd.Parameters.Add("@flag", SqlDbType.VarChar).Value =
                        string.IsNullOrEmpty(objUserBL.flag)
                        ? (object)DBNull.Value
                        : objUserBL.flag;

                    SqlParameter outputParam = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
                    outputParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outputParam);

                    con.Open();  // 🔸 open manually
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        ds = new DataSet();
                        da.Fill(ds);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }

    public DataSet Special_Character_Chk_FTA(UserBO objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[5];

            param[1] = new SqlParameter("@xmlString", objUserBL.Xml_D);
            param[2] = new SqlParameter("@Cus_Code", objUserBL.CUSTOMS_HOUSE);
            param[3] = new SqlParameter("@flag", objUserBL.flag);

            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "ADMIN_XL_UPLOAD_SELECT_Chk_FTA_New", param);
            //ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "ADMIN_XL_UPLOAD_SELECT_Chk_antony", param);
            //ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "ADMIN_XL_UPLOAD_SELECT_Chk_Ram", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet ValidateImportCthUqc(UserBO objUserBL) // Added by shanthini on 08-07-2026
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@xml_Data_Item", objUserBL.Xml_D);
            param[1] = new SqlParameter("@flag", objUserBL.flag);
            param[2] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[2].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "ADMIN_GET_IMPORT_CTH_UQC_VALIDATION", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet IMP_Gen_XL_DML(UserBO objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[25];
            param[1] = new SqlParameter("@Jobno", Connection.IMP_Jobno());
            param[2] = new SqlParameter("@Supplier_name", objUserBL.SHIPPER_NAME);
            param[3] = new SqlParameter("@Imp_name", Connection.Get_Importer_Name());

            param[4] = new SqlParameter("@All_XL_details", objUserBL.Xml_A);
            param[5] = new SqlParameter("@SAPTA_Rate", objUserBL.Xml_B);
            param[6] = new SqlParameter("@Ex_Rate", objUserBL.Xml_C);
            param[7] = new SqlParameter("@Scheme_Code", objUserBL.Xml_D);
            param[8] = new SqlParameter("@LEVY", objUserBL.Xml_E);
            param[9] = new SqlParameter("@COUNTRY", objUserBL.Xml_F);
            param[10] = new SqlParameter("@SIMS", objUserBL.Xml_G);
            param[20] = new SqlParameter("@FTA", objUserBL.Xml_FTA);
            param[21] = new SqlParameter("@REM", objUserBL.Xml_REM);


            param[11] = new SqlParameter("@User_Id", Connection.Current_User());
            param[12] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[13] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[14] = new SqlParameter("@COMPANYID", Connection.COMPANYID());
            param[15] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());
            param[16] = new SqlParameter("@flag", objUserBL.flag);
            param[17] = new SqlParameter("@Tr_Mode", objUserBL.Tr_Mode);
            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;
         
            ds = Connection.Get_Dataset("IMP_GEN_EXCEL_UPLOAD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet IMP_CP_XL_DML(UserBO objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Jobno", Connection.IMP_Jobno());
            param[2] = new SqlParameter("@Supplier_name", objUserBL.SHIPPER_NAME);

            param[3] = new SqlParameter("@xmlString", objUserBL.Xml_D);
            param[4] = new SqlParameter("@xmlCurrency", ConvertDataTableToXML(IMP_EX_Rate()));

            param[5] = new SqlParameter("@User_Id", Connection.Current_User());
            param[6] = new SqlParameter("@Branch_Code", Connection.Current_Branch());

            param[7] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[12] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());
            param[13] = new SqlParameter("@flag", objUserBL.flag);

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("IMP_CP_EXCEL_UPLOAD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet IMP_CP_Prouct_Master_DML(UserBO objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[18];

            param[2] = new SqlParameter("@Part_no", objUserBL.CONSIGNEE_NAME);
            param[3] = new SqlParameter("@Item_Dec", objUserBL.ITEM_DESCRIPTION);
            param[4] = new SqlParameter("@HSN_Code", objUserBL.ADDRESS1);
            param[5] = new SqlParameter("@Basic_Notn", objUserBL.ADDRESS2);
            param[6] = new SqlParameter("@Basic_Notn_Slno", objUserBL.ADDRESS3);
            param[7] = new SqlParameter("@IGST_Notn", objUserBL.ADDRESS4);
            param[8] = new SqlParameter("@IGST_Notn_Slno", objUserBL.ADDRESS5);
            param[9] = new SqlParameter("@User_Id", Connection.Current_User());
            param[10] = new SqlParameter("@Branch_Code", Connection.Current_Branch());

            param[11] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[12] = new SqlParameter("@flag", objUserBL.flag);
            param[13] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("IMP_CP_PRODUCT_MASTER_DML", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataTable IMP_EX_Rate()
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@INVOICE_CURRENCY", "");
            param[2] = new SqlParameter("@name", "IMPORT_CURRENCY");
            param[3] = new SqlParameter("@Working_Period", "");

            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;

            param[7] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_EXCHANGE_MASTER_SEARCH_INVOICE_CURRENCY", param);

            dt = ds.Tables[0]; 
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return dt;
    }

    private static string ConvertDataTableToXML(DataTable dtData)
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

    public DataSet Imp_Product_Master(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[25];
            param[1] = new SqlParameter("@Part_no", objUserBL.A1);
            param[2] = new SqlParameter("@Ritc_No", objUserBL.A2);
            param[3] = new SqlParameter("@Item_Dec", objUserBL.A3);
            param[4] = new SqlParameter("@General_Dec", objUserBL.A4);
            param[5] = new SqlParameter("@IGST_Levy_Notn", objUserBL.A5);
            param[6] = new SqlParameter("@IGST_Levy_Notn_Slno", objUserBL.A6);

            param[7] = new SqlParameter("@IGST_Levy_Notn_Slno_Rate", objUserBL.A7);
            param[8] = new SqlParameter("@IGST_Levy_Compensation_Cess_Notn", objUserBL.A8);
            param[9] = new SqlParameter("@IGST_Levy_Compensation_Cess_Notn_Slno", objUserBL.A9);
            param[10] = new SqlParameter("@IGST_Levy_Compensation_Cess_Notn_Rate", objUserBL.A10);

            param[11] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[12] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[13] = new SqlParameter("@COMPANY_ID", Connection.COMPANYID());
            param[14] = new SqlParameter("@User_Id", Connection.Current_User());
            param[15] = new SqlParameter("@flag", objUserBL.A11);
            param[16] = new SqlParameter("@Product_Id", objUserBL.A12);

            param[23] = new SqlParameter("@PRODUCT_BCD_NOTN", objUserBL.A13);
            param[24] = new SqlParameter("@PRODUCT_BCD_SLNO", objUserBL.A14);

            param[17] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[17].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("IMP_PRODUCT_MASTER_INS_UPD_FAIRMACS", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Import_Product_Master_Bulk_Insert(UserBO objUserBL,DataTable dtdata)
    {
        DataSet ds = new DataSet(); int result = 0;
        try
        {
            
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@BranchCode", Connection.Current_Branch());
            param[1] = new SqlParameter("@List", "");
            param[2] = new SqlParameter("@UserID", Connection.Current_User());
            param[3] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[4] = new SqlParameter("@name",  objUserBL.Ename);
            param[5] = new SqlParameter("@Types_tbl_Data", dtdata);

            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_Import_Product_Master_bulk_Update", param);
            result = Convert.ToInt32(param[6].Value.ToString());
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public DataSet Import_Pdf_Reader_Product_Master_Bulk_Insert(UserBO objUserBL, DataTable dtdata)
    {
        DataSet ds = new DataSet(); int result = 0;
        try
        {

            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@BranchCode", Connection.Current_Branch());
            //param[1] = new SqlParameter("@List", "");
            param[2] = new SqlParameter("@UserID", Connection.Current_User());
            param[3] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[4] = new SqlParameter("@name", objUserBL.Ename);
            //param[5] = new SqlParameter("@Types_tbl_Data", dtdata);

            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_Import_Pdf_Reader_Product_Master_bulk_Update", param);
            result = Convert.ToInt32(param[6].Value.ToString());
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public DataSet BulkXBE_SEC65_Excel_Upload(string Flag)
    {
        DataSet ds = new DataSet(); 
        try
        {

            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@Jobno", Connection.IMP_Jobno());
            //param[1] = new SqlParameter("@Types_tbl_XBE", dt1);
            param[2] = new SqlParameter("@BranchCode", Connection.Current_Branch());
            param[3] = new SqlParameter("@name", Flag);
            param[9] = new SqlParameter("@UserID", Connection.Current_User());

            param[5] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
           
            param[13] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[13].Direction = ParameterDirection.Output;
            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMPORT_XBE_SEC65_EXCEL_UPLOAD", param);
            result1 = param[13].Value.ToString();
        }

        catch (Exception ex)
        {

        }
        return ds;
    }

    public DataSet Bulk_Excel_Validation(string Type)
    {
        DataSet ds_xl = new DataSet(); 
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@Type", Type);
            param[3] = new SqlParameter("@Flag", Flag);

            param[1] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[1].Direction = ParameterDirection.Output;
            param[2] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[2].Direction = ParameterDirection.Output;

            ds_xl = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXCEL_UPLOAD_VALIDATION_ALL", param);
            result1 = param[1].Value.ToString();
        }
        catch (Exception ex)
        {

        }
        return ds_xl;
    }

    public DataSet Import_Bulk_SW_Excel_Upload(string Flag,string Avl_Tbl_Count)
    {
        DataSet ds = new DataSet();
        try
        {

            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@JobNo", Connection.IMP_Jobno());
            param[1] = new SqlParameter("@BranchCode", Connection.Current_Branch());
            param[2] = new SqlParameter("@Flag", Flag);
            param[3] = new SqlParameter("@Tbl_Del_Flag", Avl_Tbl_Count);
            param[4] = new SqlParameter("@UserID", Connection.Current_User());
            param[5] = new SqlParameter("@WorkingPeriod", Connection.WorkingPeriod());

            param[13] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[13].Direction = ParameterDirection.Output;
            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_SW_EXCEL_UPLOAD_ALL", param);
            result1 = param[14].Value.ToString();

            if (Flag == "Delete_All")
            {
                result = Convert.ToInt32(param[13].Value.ToString());
            }
            
        }

        catch (Exception ex)
        {

        }
        return ds;
    }

    public DataSet Import_Product_Setting_Master_Bulk_Insert(UserBO objUserBL, DataTable dtdata)//** kavi & Ajith**//
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
            //param[8] = new SqlParameter("@PO_TYPE", );

            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_Import_Product_Setting_Master_bulk_Update", param);
            if (objUserBL.Ename != "Auto_ID")
            {
                result = Convert.ToInt32(param[6].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public DataSet Import_CaterPillar_Master_Bulk_Insert(UserBO objUserBL, DataTable dtdata)//** kavi & Ajith**//
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
            //param[8] = new SqlParameter("@PO_TYPE", );

            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_CATERPILLAR_MASTER_BULK_UPDATE", param);
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
    public string GetDataFromSP(string name , UserBO objUserBL)
    {
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string alert = "";
        HttpResponse Response = HttpContext.Current.Response;

        try
        {
            // ── 1. Fetch data from Stored Procedure ──────────────────────────────
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@IMP_CLIENT_IEC_NAME", objUserBL._SLNO);
            param[1] = new SqlParameter("@IMP_CLIENT_ID", objUserBL._SLNO);
            param[2] = new SqlParameter("@IMP_CLIENT_BRANCH_SLNO", objUserBL.SLNO);
            param[3] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[4] = new SqlParameter("@name", name);
            param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@startRowIndex", 0);
            param[8] = new SqlParameter("@maximumRows", int.MaxValue);
            param[9] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[9].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(),
                   CommandType.StoredProcedure, "OCR_IMP_CLIENT_MASTER_SEARCH_SELECT", param);

            dt = ds.Tables[0];
            string filename = "IMPORT_PRODUCT_SETTING_BULK_UPLOAD_"
                                     + DateTime.Now.ToString("yyyyMMddHHmm");
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                GridView gv = new GridView();

                gv.HeaderStyle.BackColor = System.Drawing.Color.RoyalBlue;
                gv.HeaderStyle.ForeColor = System.Drawing.Color.White;
                gv.AllowPaging = false;
                gv.DataSource = dt;
                gv.DataBind();


                foreach (TableCell cell in gv.HeaderRow.Cells)
                {
                    cell.BackColor = gv.HeaderStyle.BackColor;
                }

                gv.RenderControl(hw);

                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }

        }
  
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);

            // Surface the error to the caller so you can see what went wrong
            alert = "Export failed: " + ex.Message;
        }

        return alert;
    }
}