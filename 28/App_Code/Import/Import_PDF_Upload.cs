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


public class Import_PDF_Upload
{
    public int result;
    DataSet ds = new DataSet();


    private string _USER_ID, _Working_Period, _BRANCH_CODE, _YEAR, _flag, _INVOICE_NO;
    private string _Xml_ItemData, _Xml_InvData, _Xmlcurr;
    private string _Suppliername;
    private string _EXCHANGE_CUR_CODE, _EXCHANGE_RATE;
    private string _IMPORTER_NAME;
    private string _BRANCH_NO;
    private string _JOBNO;
    private string _Branch_Code;
    private string _WORKING_PERIOD;
    private string _JOBNO_PS; 
    private string _BRANCH_COMMON;

    public string EXCHANGE_CUR_CODE { get { return _EXCHANGE_CUR_CODE; } set { _EXCHANGE_CUR_CODE = value; } }
    public string EXCHANGE_RATE { get { return _EXCHANGE_RATE; } set { _EXCHANGE_RATE = value; } }

    public string Suppliername { get { return _Suppliername; } set { _Suppliername = value; } }
    public string flag { get { return _flag; } set { _flag = value; } }
    public string INVOICE_NO { get { return _INVOICE_NO; } set { _INVOICE_NO = value; } }
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string Working_Period { get { return _Working_Period; } set { _Working_Period = value; } }
    public string Xml_ItemData { get { return _Xml_ItemData; } set { _Xml_ItemData = value; } }
    public string Xml_InvData { get { return _Xml_InvData; } set { _Xml_InvData = value; } }
    public string Xmlcurr { get { return _Xmlcurr; } set { _Xmlcurr = value; } }
    public string IMPORTER_NAME { get { return _IMPORTER_NAME; } set { _IMPORTER_NAME = value; } }
    public string BRANCH_NO { get { return _BRANCH_NO; } set { _BRANCH_NO = value; } }
    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string Branch_Code { get { return _Branch_Code; } set { _Branch_Code = value; } }
    public string WORKINGPERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }
    public string JOBNO_PS { get { return _JOBNO_PS; } set { _JOBNO_PS = value; } }
    public string BRANCH_COMMON { get { return _BRANCH_COMMON; } set { _BRANCH_COMMON = value; } }

    public String Xml_All, Xml_Gen, Xml_annex, Xml_Items;
    public String Xml_Inv;
    public String Xml_Drawback;

    public DataSet Import_PDFInsert_WithoutDT(UserBO objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {

            SqlParameter[] param = new SqlParameter[50];

            param[0] = new SqlParameter("@Opr_Flag", objUserBL.flag);
            param[1] = new SqlParameter("@INVOICE_ID", objUserBL.AWB_INV_NO);
            param[2] = new SqlParameter("@Jobno", Connection.IMP_Jobno());


            param[3] = new SqlParameter("@UserID", Connection.Current_User());
            param[4] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());
            param[5] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());

            param[6] = new SqlParameter("@YEAR", objUserBL.Year);


            param[8] = new SqlParameter("@Mstatus", SqlDbType.Int, 0);
            param[8].Direction = ParameterDirection.Output;


            ds = Connection.Get_Dataset("Import_PDF_Upload_SP", param);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public void Import_PDFInsert(UserBO objUserBL, DataTable dtdataInv, DataTable dtdataItem)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[50];

            param[0] = new SqlParameter("@Opr_Flag", objUserBL.flag);
            param[1] = new SqlParameter("@INVOICE_ID", objUserBL.INVOICE_NO);
            param[2] = new SqlParameter("@Jobno", Connection.IMP_Jobno());
            param[3] = new SqlParameter("@UserID", Connection.Current_User());
            param[4] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());
            param[5] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[6] = new SqlParameter("@YEAR", objUserBL.Year);
            param[15] = new SqlParameter("@InvData", dtdataInv);
            param[16] = new SqlParameter("@ItemData", dtdataItem);
            param[17] = new SqlParameter("@Mstatus", SqlDbType.Int, 0);
            param[17].Direction = ParameterDirection.Output;

            Connection.Get_Dataset("Import_PDF_Upload_SP", param);
            result = Convert.ToInt32(param[17].Value.ToString());

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public DataSet Import_Suzuki_Invoice_pdf(UserBO objUserBL)
    {

        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[50];

            param[0] = new SqlParameter("@Opr_Flag", flag);
            param[1] = new SqlParameter("@Suppliername", Suppliername);
            param[2] = new SqlParameter("@Jobno", Connection.IMP_Jobno());
            param[3] = new SqlParameter("@UserID", Connection.Current_User());
            param[4] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());
            param[5] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[6] = new SqlParameter("@YEAR", objUserBL.Year);
            param[7] = new SqlParameter("@Xml_InvData", Xml_InvData);
            param[8] = new SqlParameter("@EXCHANGE_RATE", EXCHANGE_RATE);

            ds = Connection.Get_Dataset("Import_Inv_PDF_Upload_SP", param);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Import_Suzuki_Item_pdf(UserBO objUserBL)
    {

        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[50];

            param[0] = new SqlParameter("@Opr_Flag", flag);
            param[1] = new SqlParameter("@INVOICE_SNO", objUserBL.INVOICE_SLNO);
            param[2] = new SqlParameter("@Jobno", Connection.IMP_Jobno());
            param[3] = new SqlParameter("@UserID", Connection.Current_User());
            param[4] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());
            param[5] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[6] = new SqlParameter("@YEAR", "");
            param[7] = new SqlParameter("@Xml_ItemData", Xml_ItemData);

            ds = Connection.Get_Dataset("Import_Item_PDF_Upload_SP", param);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }




    //public DataSet Retrieve_Exchange_Rate_details()
    //{
    //    DataSet ds = new DataSet();
    //    try
    //    {
    //        SqlParameter[] param = new SqlParameter[5];
    //        param[1] = new SqlParameter("@EXCHANGE_CUR_CODE", EXCHANGE_CUR_CODE);
    //        ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "IMPORT_EXCHANGE_RATE_DETAILS", param);

    //    }
    //    catch (Exception ex)
    //    {
    //        Connection.Error_Msg(ex.Message);
    //    }
    //    finally
    //    {

    //    }
    //    return ds;
    //}



    public DataSet Import_Vestas_Inv_item_pdf(UserBO objUserBL)
    {

        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[50];

            param[0] = new SqlParameter("@Opr_Flag", flag);
            param[1] = new SqlParameter("@Suppliername", Suppliername);
            param[2] = new SqlParameter("@Jobno", Connection.IMP_Jobno());
            param[3] = new SqlParameter("@UserID", Connection.Current_User());
            param[4] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());
            param[5] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[6] = new SqlParameter("@YEAR", "");
            param[7] = new SqlParameter("@Xml_InvData", Xml_InvData);
            param[8] = new SqlParameter("@Xml_ItemData", Xml_ItemData);
            param[9] = new SqlParameter("@EXCHANGE_RATE", EXCHANGE_RATE);

            ds = Connection.Get_Dataset("Import_Vestas_Inv_Item_PDF_Upload_SP", param);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Imp_PDF_Upload_New_XML(DataTable dt_gen, DataTable dt1, DataTable dt_dbk, DataTable dt_inv, DataTable dt_annex)//* kavi & Ajith *//
    {
        try
        {
            SqlParameter[] param = new SqlParameter[25];
            param[0] = new SqlParameter("@IMPORTER_NAME", IMPORTER_NAME);
            param[9] = new SqlParameter("@BRANCH_NO", BRANCH_NO);
            param[1] = new SqlParameter("@Jobno", JOBNO);
            param[10] = new SqlParameter("@Xml_Gen", Xml_Gen = IMP_ConvertDataTableToXML(dt_gen));
            param[2] = new SqlParameter("@Xml_All", Xml_All = IMP_ConvertDataTableToXML(dt1));
            param[3] = new SqlParameter("@Xml_Drawback", Xml_Drawback = IMP_ConvertDataTableToXML(dt_dbk));
            param[4] = new SqlParameter("@Xml_Inv", Xml_Inv = IMP_ConvertDataTableToXML(dt_inv));
            param[15] = new SqlParameter("@Xml_annex", Xml_annex = IMP_ConvertDataTableToXML(dt_annex));

            param[5] = new SqlParameter("@USER_ID", USER_ID);
            param[6] = new SqlParameter("@BRANCH_CODE", Branch_Code);
            param[7] = new SqlParameter("@WORKING_PERIOD", WORKINGPERIOD);
            param[8] = new SqlParameter("@flag", flag);

            param[13] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[13].Direction = ParameterDirection.Output;
            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMP_PDF_UPLOAD_SELECT", param);
            result = Convert.ToInt32(param[13].Value.ToString());
        }
        catch (Exception ex)
        {

        }

        return ds;
    }



    private static string IMP_ConvertDataTableToXML(DataTable dtData)//* kavi & Ajith *//
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
                //if (col.ColumnName == "ITEM_DESC")
                //{
                //    dsData.Tables[0].Columns[col.ColumnName] = dsData.Tables[0].Columns["ITEM_DESC"].ToString().Replace("&#xA;", "");
                //}
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


    public DataSet Ocr_Import_Xml_Converter(DataTable dt_Item)
    {
        try
        {
            const int BATCH_SIZE = 200;
            int totalRows = dt_Item.Rows.Count;

            for (int start = 0; start < totalRows; start += BATCH_SIZE)
            {
                DataTable batch = dt_Item.Clone();
                int end = Math.Min(start + BATCH_SIZE, totalRows);
                for (int i = start; i < end; i++)
                    batch.ImportRow(dt_Item.Rows[i]);

                SqlParameter[] param = new SqlParameter[10];
                param[0] = new SqlParameter("@Jobno", JOBNO);
                param[1] = new SqlParameter("@Xml_Item", Xml_Items = IMP_ConvertDataTableToXML(batch));
                param[2] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
                param[3] = new SqlParameter("@Jobno_PS", JOBNO_PS);
                param[4] = new SqlParameter("@USER_ID", USER_ID);
                param[5] = new SqlParameter("@BRANCH_CODE", Branch_Code);
                param[6] = new SqlParameter("@WORKING_PERIOD", WORKINGPERIOD);
                param[7] = new SqlParameter("@Mflag", flag);
                param[8] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
                param[8].Direction = ParameterDirection.Output;
                param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
                param[9].Direction = ParameterDirection.Output;

                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "OCR_ITEM_DETAILS_BULK_INSERT_UPDATE", param);
            }
        }
        catch (Exception ex)
        {
        }
        return ds;
    }

}