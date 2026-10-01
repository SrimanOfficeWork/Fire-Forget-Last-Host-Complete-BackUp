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


public class Auto_IRN_Upload
{
    public String Xml_All;
    public int result;

    DataSet ds = new DataSet();

    public Auto_IRN_Upload()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public DataSet Imp_Exp_Auto_IRN_Insert(string Jobno, string flag, string Type,DataTable xml_Doc_type)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[25];
            param[0] = new SqlParameter("@Jobno", Jobno);
            param[1] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[2] = new SqlParameter("@WP", Connection.WorkingPeriod());
            param[3] = new SqlParameter("@UserId", Connection.Current_User());
            param[4] = new SqlParameter("@Mflag", flag);
            param[7] = new SqlParameter("@Imp_Exp_Type", Type);
            param[8] = new SqlParameter("@Xml_DOC_CODE", Xml_All = EXP_ConvertDataTableToXML(xml_Doc_type));

            param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;

          //ds=  Connection.Get_Dataset("IMP_EXP_AUTO_IRN_UPLOAD_JOB", param);//Jobno_Invslno_Itemslno_filenameSigned.pdf
            ds = Connection.Get_Dataset("IMP_EXP_AUTO_IRN_UPLOAD_JOB_DOCNAME_SPLIT", param);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
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

}