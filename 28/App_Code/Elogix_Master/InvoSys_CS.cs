using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;

using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.IO;

using System.Text;



public class InvoSys_CS
{
    public DataSet Company_Details(string COMPANY_LICENSE, string WORKING_PERIOD)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@COMPANY_LICENSE", COMPANY_LICENSE);
            param[2] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[3] = new SqlParameter("@name", "Company_details");
            param[4] = new SqlParameter("@Tr_mode", "");
            param[5] = new SqlParameter("@Customs_House", "");
            param[6] = new SqlParameter("@Port_Destination", "");
            param[7] = new SqlParameter("@Port_Of_Discharge", "");

            param[8] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(Connection.Get_DSC_Con_String(COMPANY_LICENSE), CommandType.StoredProcedure, "E_LOGIX_ADMIN_DETAILS", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public void Import_Data(DataSet ds,string Branch_Common, string Login)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Company_Det", ConvertDataTableToXML(ds.Tables[0]));
            param[2] = new SqlParameter("@General", ConvertDataTableToXML(ds.Tables[1]));
            param[3] = new SqlParameter("@IGM", ConvertDataTableToXML(ds.Tables[2]));
            param[4] = new SqlParameter("@Container", ConvertDataTableToXML(ds.Tables[3]));
            param[5] = new SqlParameter("@Invoice", ConvertDataTableToXML(ds.Tables[4]));
            param[6] = new SqlParameter("@Branch_Common", Branch_Common);

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(Login, CommandType.StoredProcedure, "INVO_SYS_IMP_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
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


    public DataSet E_Logix_Chennai_Ref(UserBO objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Jobno", objUserBL.JOBNO);
            param[2] = new SqlParameter("@TYPE", objUserBL.File_Type);
            param[3] = new SqlParameter("@Ref_loc", objUserBL.INVOICE_NO);
            param[4] = new SqlParameter("@Ref_Ref_Type", objUserBL.INVOICE_SLNO);
            param[5] = new SqlParameter("@Flag", objUserBL.flag);
            param[6] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[7] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[8] = new SqlParameter("@User", Connection.Current_User());
            param[9] = new SqlParameter("@Company_Lic", Connection.Company_License());
            param[10] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("INVO_SYS_IMP_EXP_CHENNAI", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

}