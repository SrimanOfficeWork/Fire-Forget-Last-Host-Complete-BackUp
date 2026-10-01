using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;


public class Live_updation
{
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    DataSet ds = new DataSet();
    public int result = 0, UPDATE_ID = 0;


    private string _ID;
    private string _TYPE;
    private string _SCROLL_MSG;
    private string _EFFECTIVE_FROM;
    private string _DETAIL_MSG;
    private string _USERID;
    private string _Flag;
    private string _EFFECTIVE_TO;
    private string _ImagePath;
    private string _WhatsAppLink;
    private string _DriveLink;
    private string _YoutubeLink;
    private string _WebsiteLink;
    public string ID { get { return _ID; } set { _ID = value; } }
    public string TYPE { get { return _TYPE; } set { _TYPE = value; } }

    public string SCROLL_MSG { get { return _SCROLL_MSG; } set { _SCROLL_MSG = value; } }
    public string EFFECTIVE_FROM { get { return _EFFECTIVE_FROM; } set { _EFFECTIVE_FROM = value; } }
    public string DETAIL_MSG { get { return _DETAIL_MSG; } set { _DETAIL_MSG = value; } }
    public string USERID { get { return _USERID; } set { _USERID = value; } }
    public string Flag { get { return _Flag; } set { _Flag = value; } }
    public string EFFECTIVE_TO { get { return _EFFECTIVE_TO; } set { _EFFECTIVE_TO = value; } }
    public string ImagePath { get { return _ImagePath; } set { _ImagePath = value; } }
    public string WhatsAppLink { get { return _WhatsAppLink; } set { _WhatsAppLink = value; } }
    public string DriveLink { get { return _DriveLink; } set { _DriveLink = value; } }
    public string YoutubeLink { get { return _YoutubeLink; } set { _YoutubeLink = value; } }
    public string WebsiteLink { get { return _WebsiteLink; } set { _WebsiteLink = value; } }
 
    public void Live_Updation_INS_UPD()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[11];

            param[0] = new SqlParameter("@ID", ID);
            param[1] = new SqlParameter("@TYPE", TYPE);
            param[2] = new SqlParameter("@SCROLL_MSG", SCROLL_MSG);
            if (EFFECTIVE_FROM == "" || EFFECTIVE_FROM == null)
            {
                EFFECTIVE_FROM = "01/01/1900";
            }
            param[3] = new SqlParameter("@EFFECTIVE_FROM", DateTime.Parse(EFFECTIVE_FROM, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[4] = new SqlParameter("@DETAIL_MSG", DETAIL_MSG);
            param[5] = new SqlParameter("@USERID", USERID);
            param[6] = new SqlParameter("@flag", Flag);
            if (EFFECTIVE_TO == null || EFFECTIVE_TO == "")
            {
                EFFECTIVE_TO = "01/01/1900";
            }
            DateTime effToDate = DateTime.Parse(EFFECTIVE_TO, provider,System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime effToDateFinal;
            if (effToDate.Year == 1900)
            {
                effToDateFinal = effToDate; 
            }
            else
            {
                effToDateFinal = effToDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            }
            param[7] = new SqlParameter("@EFFECTIVE_TO", effToDateFinal);
            param[8] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            param[10] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "LIVE_UPDATION_INS_UPD", param);
            result = Convert.ToInt32(param[8].Value.ToString());

            if (Flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[10].Value.ToString());
            }

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }

    public DataSet Master_Search_live_updation()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@TYPE", TYPE);
            param[1] = new SqlParameter("@SCROLL_MSG", SCROLL_MSG);

            param[2] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[2].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "LIVE_UDATEION_SEARCH", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }
    public DataSet live_updation_Select()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@ID", ID);
            param[1] = new SqlParameter("@Flag", Flag);

            param[2] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[2].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "LIVE_UDATEION_SELECT", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

     public DataSet Live_Updation_Img_Select()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[9];  
            param[0] = new SqlParameter("@Flag", Flag);
            param[1] = new SqlParameter("@IMAGE_PATH", ImagePath);
            if (EFFECTIVE_FROM == "" || EFFECTIVE_FROM == null)
            {
                EFFECTIVE_FROM = "01/01/1900";
            }
            param[2] = new SqlParameter("@EFFECTIVE_FROM", DateTime.Parse(EFFECTIVE_FROM, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            if (EFFECTIVE_TO == null)
            {
                EFFECTIVE_TO = "01/01/1900";
            }
            DateTime effToDate = DateTime.Parse(EFFECTIVE_TO, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime effToDateFinal;
            if (effToDate.Year == 1900)
            {
                effToDateFinal = effToDate;
            }
            else
            {
                effToDateFinal = effToDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            }
            param[3] = new SqlParameter("@EFFECTIVE_TO", effToDateFinal);

            // Added by shanthini on 22-07-2026
            param[4] = new SqlParameter("@WHATSAPP_LINK", (object)WhatsAppLink ?? "");
            param[5] = new SqlParameter("@DRIVE_LINK", (object)DriveLink ?? "");
            param[6] = new SqlParameter("@YOUTUBE_LINK", (object)YoutubeLink ?? "");
            param[7] = new SqlParameter("@WEBSITE_LINK", (object)WebsiteLink ?? "");

            param[8] = new SqlParameter("@Status", SqlDbType.Int);   
            //ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_POPUP_IMAGE_MASTER", param);
            //result = Convert.ToInt32(param[8].Value.ToString()); 

            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_POPUP_IMAGE_MASTER", param);

            if (param[8].Value != null && param[8].Value != DBNull.Value)
            {
                result = Convert.ToInt32(param[8].Value.ToString());
            }
            else
            {
                result = 1; 
            }
 
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

}