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


public class Export_PDF_Upload
{

    public String Xml_D;

    private string _Ename;

    private string _EXPORTER_NAME;
    private string _BRANCH_NO;
    private string _JOBNO;
    private string _Branch_Code;
    private string _USER_ID;
    private string _WORKING_PERIOD;
    private string _flag;
    private string _INV_SLNO;
    private string _ITEM_SLNO;
    private string _JOBNO_PS;
    private string _COMAPANY_ID;

    public string EXPORTER_NAME { get { return _EXPORTER_NAME; } set { _EXPORTER_NAME = value; } }
    public string BRANCH_NO { get { return _BRANCH_NO; } set { _BRANCH_NO = value; } }
    public string Ename { get { return _Ename; } set { _Ename = value; } }
    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string Branch_Code { get { return _Branch_Code; } set { _Branch_Code = value; } }
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string WORKINGPERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }
    public string flag { get { return _flag; } set { _flag = value; } }
    public string INV_SLNO { get { return _INV_SLNO; } set { _INV_SLNO = value; } }
    public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }
    public string JOBNO_PS { get { return _JOBNO_PS; } set { _JOBNO_PS = value; } }
    public string COMAPANY_ID { get { return _COMAPANY_ID; } set { _COMAPANY_ID = value; } }


    public String Xml_All, Xml_Gen, Xml_annex, Xml_annex_Air, Xml_Con, Xml_AR_4;
    public String Xml_Inv;
    public String Xml_Item;
    public String Xml_Drawback;
    public String Xml_Lic;
    public String Xml_SW_dbk_SW_Stmt;
    public String Xml_SW_InfoType;
    public String Xml_Spl;
    public String Xml_Buyer;
    public String Xml_ROSL;

    public int result;

    DataSet ds = new DataSet();

	public Export_PDF_Upload()
	{
		//
		// TODO: Add constructor logic here
		//
	}



    public DataSet Exp_PDF_Upload_New_XML(DataTable dt_gen, DataTable dt1, DataTable dt_dbk, DataTable dt_inv, DataTable dt_annex)
    {
        try
        {

            SqlParameter[] param = new SqlParameter[25];
            param[0] = new SqlParameter("@EXPORTER_NAME", EXPORTER_NAME);
            param[9] = new SqlParameter("@BRANCH_NO", BRANCH_NO);
            param[1] = new SqlParameter("@Jobno", JOBNO);
            param[10] = new SqlParameter("@Xml_Gen", Xml_Gen = EXP_ConvertDataTableToXML(dt_gen));
            param[2] = new SqlParameter("@Xml_All", Xml_All = EXP_ConvertDataTableToXML(dt1));
            param[3] = new SqlParameter("@Xml_Drawback", Xml_Drawback = EXP_ConvertDataTableToXML(dt_dbk));
            param[4] = new SqlParameter("@Xml_Inv", Xml_Inv = EXP_ConvertDataTableToXML(dt_inv));
            param[15] = new SqlParameter("@Xml_annex", Xml_annex = EXP_ConvertDataTableToXML(dt_annex));

            param[5] = new SqlParameter("@USER_ID", USER_ID);
            param[6] = new SqlParameter("@BRANCH_CODE", Branch_Code);
            param[7] = new SqlParameter("@WORKING_PERIOD", WORKINGPERIOD);
            param[8] = new SqlParameter("@flag", flag);

            param[13] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[13].Direction = ParameterDirection.Output;
            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXP_PDF_UPLOAD_SELECT", param);
            result = Convert.ToInt32(param[13].Value.ToString());
        }
        catch (Exception ex)
        {

        }

        return ds;
    }


    public DataSet Exp_PDF_Upload_New_XML_AI(DataTable dt_gen, DataTable dt1, DataTable dt_dbk, DataTable dt_inv, DataTable dt_annex, DataTable Dt_anx_Air, DataTable dt_Temp_Con)
    {
        try
        {

            SqlParameter[] param = new SqlParameter[25];
            param[0] = new SqlParameter("@EXPORTER_NAME", EXPORTER_NAME);
            param[1] = new SqlParameter("@BRANCH_NO", BRANCH_NO);
            param[2] = new SqlParameter("@Jobno", JOBNO);
            param[3] = new SqlParameter("@Jobno_PS", JOBNO_PS);
            param[4] = new SqlParameter("@Company_ID", COMAPANY_ID);
            param[5] = new SqlParameter("@Xml_Gen", Xml_Gen = EXP_ConvertDataTableToXML(dt_gen));
            param[6] = new SqlParameter("@Xml_All", Xml_All = EXP_ConvertDataTableToXML(dt1));
            param[7] = new SqlParameter("@Xml_Drawback", Xml_Drawback = EXP_ConvertDataTableToXML(dt_dbk));
            param[8] = new SqlParameter("@Xml_Inv", Xml_Inv = EXP_ConvertDataTableToXML(dt_inv));
            param[9] = new SqlParameter("@Xml_annex", Xml_annex = EXP_ConvertDataTableToXML(dt_annex));
            param[10] = new SqlParameter("@Xml_annex_Air", Xml_annex_Air = EXP_ConvertDataTableToXML(Dt_anx_Air));
            param[11] = new SqlParameter("@Xml_Con", Xml_Con = EXP_ConvertDataTableToXML(dt_Temp_Con));

            param[12] = new SqlParameter("@USER_ID", USER_ID);
            param[13] = new SqlParameter("@BRANCH_CODE", Branch_Code);
            param[14] = new SqlParameter("@WORKING_PERIOD", WORKINGPERIOD);
            param[15] = new SqlParameter("@flag", flag);
            param[16] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[16].Direction = ParameterDirection.Output;
            param[17] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[17].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXP_PDF_UPLOAD_SELECT_AI", param);
            result = Convert.ToInt32(param[16].Value.ToString());
        }
        catch (Exception ex)
        {

        }

        return ds;
    }


    public int Exp_PDF_Update_ITEM_to_MASTER()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[25];
            param[0] = new SqlParameter("@JOBNO", JOBNO);
            param[1] = new SqlParameter("@INV_SLNO", INV_SLNO);
            param[2] = new SqlParameter("@ITEM_SLNO", ITEM_SLNO);        
            param[3] = new SqlParameter("@BRANCH_CODE", Branch_Code);
            param[4] = new SqlParameter("@flag", flag);

            param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXP_ITEM_UPDATE_TO_PDF_MASTER", param);
            result = Convert.ToInt32(param[5].Value.ToString());


        }

        catch (Exception ex)
        {

        }

        return result;
    }


    public static void Exp_PDF_Auto_IRN_Insert()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[25];
            param[0] = new SqlParameter("@Jobno", Connection.EXP_Jobno());
            param[1] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[2] = new SqlParameter("@WP", Connection.WorkingPeriod());
            param[3] = new SqlParameter("@UserId", Connection.Current_User());
            param[4] = new SqlParameter("@Mflag", "");

            param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;

            Connection.Get_Dataset("EXP_PDF_AUTO_IRN_UPLOAD", param);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
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

    public DataSet Exp_XML_JSON_Upload_New_XML_AI(DataTable dt_gen, DataTable dt1, DataTable dt_dbk, DataTable dt_inv, DataTable dt_annex, DataTable Dt_anx_Air)
    {
        try
        {

            SqlParameter[] param = new SqlParameter[25];
            param[0] = new SqlParameter("@EXPORTER_NAME", EXPORTER_NAME);
            param[1] = new SqlParameter("@BRANCH_NO", BRANCH_NO);
            param[2] = new SqlParameter("@Jobno", JOBNO);
            param[3] = new SqlParameter("@Jobno_PS", JOBNO_PS);
            param[4] = new SqlParameter("@Company_ID", COMAPANY_ID);
            param[5] = new SqlParameter("@Xml_Gen", Xml_Gen = EXP_ConvertDataTableToXML(dt_gen));
            param[6] = new SqlParameter("@Xml_All", Xml_All = EXP_ConvertDataTableToXML(dt1));
            param[7] = new SqlParameter("@Xml_Drawback", Xml_Drawback = EXP_ConvertDataTableToXML(dt_dbk));
            param[8] = new SqlParameter("@Xml_Inv", Xml_Inv = EXP_ConvertDataTableToXML(dt_inv));
            param[9] = new SqlParameter("@Xml_annex", Xml_annex = EXP_ConvertDataTableToXML(dt_annex));
            param[10] = new SqlParameter("@Xml_annex_Air", Xml_annex_Air = EXP_ConvertDataTableToXML(Dt_anx_Air));

            param[11] = new SqlParameter("@USER_ID", USER_ID);
            param[12] = new SqlParameter("@BRANCH_CODE", Branch_Code);
            param[13] = new SqlParameter("@WORKING_PERIOD", WORKINGPERIOD);
            param[14] = new SqlParameter("@flag", flag);
            param[15] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[15].Direction = ParameterDirection.Output;
            param[16] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[16].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXP_XML_JSON_UPLOAD_SELECT_AI", param);
            result = Convert.ToInt32(param[15].Value.ToString());
        }
        catch (Exception ex)
        {

        }

        return ds;
    }

    public DataSet Exp_Excel_Upload_New_XML_AI(DataTable dt_gen, DataTable dt1, DataTable dt_dbk, DataTable dt_inv, DataTable dt_annex, DataTable Dt_anx_Air, DataTable dt_Temp_Con, DataTable dt_AR_4_Details)
    {
        try
        {

            SqlParameter[] param = new SqlParameter[25];
            param[0] = new SqlParameter("@EXPORTER_NAME", EXPORTER_NAME);
            param[1] = new SqlParameter("@BRANCH_NO", BRANCH_NO);
            param[2] = new SqlParameter("@Jobno", JOBNO);
            param[3] = new SqlParameter("@Jobno_PS", JOBNO_PS);
            param[4] = new SqlParameter("@Company_ID", COMAPANY_ID);
            param[5] = new SqlParameter("@Xml_Gen", Xml_Gen = EXP_ConvertDataTableToXML(dt_gen));
            param[6] = new SqlParameter("@Xml_All", Xml_All = EXP_ConvertDataTableToXML(dt1));
            param[7] = new SqlParameter("@Xml_Drawback", Xml_Drawback = EXP_ConvertDataTableToXML(dt_dbk));
            param[8] = new SqlParameter("@Xml_Inv", Xml_Inv = EXP_ConvertDataTableToXML(dt_inv));
            param[9] = new SqlParameter("@Xml_annex", Xml_annex = EXP_ConvertDataTableToXML(dt_annex));
            param[10] = new SqlParameter("@Xml_annex_Air", Xml_annex_Air = EXP_ConvertDataTableToXML(Dt_anx_Air));
            param[11] = new SqlParameter("@Xml_Con", Xml_Con = EXP_ConvertDataTableToXML(dt_Temp_Con));
            param[12] = new SqlParameter("@Xml_AR_4", Xml_AR_4 = EXP_ConvertDataTableToXML(dt_AR_4_Details));

            param[13] = new SqlParameter("@USER_ID", USER_ID);
            param[14] = new SqlParameter("@BRANCH_CODE", Branch_Code);
            param[15] = new SqlParameter("@WORKING_PERIOD", WORKINGPERIOD);
            param[16] = new SqlParameter("@flag", flag);
            param[17] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[17].Direction = ParameterDirection.Output;
            param[18] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[18].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXP_Excel_UPLOAD_SELECT_AI", param);
            result = Convert.ToInt32(param[17].Value.ToString());
        }
        catch (Exception ex)
        {

        }

        return ds;
    }
}