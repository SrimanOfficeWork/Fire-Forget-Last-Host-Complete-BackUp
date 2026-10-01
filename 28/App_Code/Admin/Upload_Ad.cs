using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;
using Microsoft.ApplicationBlocks.Data;
public class Upload_Ad
{
    DataSet ds = new DataSet();
    public DataSet Upload_Ads_Ins_Up(Global_variables objUserBL, string xmlData)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@MFLAG", objUserBL.A1);
            param[2] = new SqlParameter("@ERRORMSG", SqlDbType.NVarChar, 1000);
            param[2].Direction = ParameterDirection.Output;
            param[3] = new SqlParameter("@XMLData", xmlData);
            return SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "EROYAL_UPLOAD_ADS", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
            return null;
        }
    }

   
}