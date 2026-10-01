using System;
using System.IO;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using BussinessObject;

/// <summary>
/// Summary description for General_ETA
/// </summary>
public class General_ETA
{
    DataSet dds = new DataSet();
    public int result = 0;
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);

    public DataSet RetrieveAll_ETA_Details(UserBO Obj)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            
            param[0] = new SqlParameter("@JOBNO", Obj.JOBNO);
            param[1] = new SqlParameter("@IMPORTER_NAME", Obj.IMPORTER_NAME);
            param[2] = new SqlParameter("@VESSEL_NAME", Obj.VESSEL_NAME);
            param[3] = new SqlParameter("@name", Obj.Ename);
          
            if (!string.IsNullOrEmpty(Obj.From_date))
                param[4] = new SqlParameter("@FROM_DATE", DateTime.Parse(Convert.ToString(Obj.From_date), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            else
            {
                param[4] = new SqlParameter("@FROM_DATE", Obj.From_date);
            }
            if (!string.IsNullOrEmpty(Obj.Todate))
                param[5] = new SqlParameter("@TO_DATE", DateTime.Parse(Convert.ToString(Obj.Todate), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            else
            {
                param[5] = new SqlParameter("@TO_DATE", Obj.Todate);
            }
            param[6] = new SqlParameter("@ETA", Obj.ETA);
            param[7] = new SqlParameter("@ACTION", Obj.action);
            param[8] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[9] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[12] = new SqlParameter("@XmlString", Obj.Xml_A);
            param[13] = new SqlParameter("@Filing_Status", Obj.FILING_STATUS);

            param[10] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;
            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;


            dds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "GENERAL_ETA_SEARCH_SELECT", param);
            result = Convert.ToInt32(param[10].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return dds;
    }
}