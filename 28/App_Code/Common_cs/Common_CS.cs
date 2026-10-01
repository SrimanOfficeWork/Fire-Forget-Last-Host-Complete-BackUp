using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;
using System.Text;

public class Common_CS
{
    static string[] arr = new string[] { };
    static string[] arr_Month = new string[] { };
    static string Start_date = string.Empty,End_date = string.Empty,From_month = string.Empty,To_month = string.Empty;

    public static string Get_Arrange_Date(string date)
    {
        try
        {
            if (date != string.Empty && date != null)
            {
                arr = date.Split('/');
                date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return date;
    }
    public static string Get_Timestamp()
    {
        DateTime time = DateTime.Now;
        string val = string.Empty;
        try
        {
           val= time.ToString("yyyyMMddHHmm");
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return val;
    }
    public static DataSet Load_Month()
    {
        DataSet ds = new DataSet();
        arr = Connection.WorkingPeriod().Split('-');
        Start_date = arr[0] + '-' + arr[1] + '-' + arr[2];
        End_date = arr[3] + '-' + arr[4] + '-' + arr[5];

        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@StartDate", Start_date);
            param[1] = new SqlParameter("@EndDate", End_date);
            param[2] = new SqlParameter("@Flag", "Month");
            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("BILL_IMP_EXP_MONTHS", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public void DSC_Download()
    {
        
        HttpResponse Response = HttpContext.Current.Response;
        Response.ContentType = "application/zip";
        Response.AppendHeader("Content-Disposition", "attachment; filename=DSCTool.zip");
        Response.TransmitFile(HttpContext.Current.Server.MapPath("~/DSCTool.zip"));
        Response.End();
    }
    public static string ConvertDataTableToXML(DataTable dtData)
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

    public static bool IsNumeric(object Expression)
    {
       // double retNum;

        long number1 = 0;
       // bool isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
        bool isNum = long.TryParse(Convert.ToString(Expression), out number1);

        return isNum;
    }
    public static bool IsValidDateTime(string DT)
    {
        string dateTime = string.Empty;
        dateTime = DT == "" ? "01/01/1900" : DT;
        string[] formats = { "dd/MM/yyyy" };
        DateTime parsedDateTime;
        return DateTime.TryParseExact(dateTime, formats, new System.Globalization.CultureInfo("en-US"),
                                       System.Globalization.DateTimeStyles.None, out parsedDateTime);
    }

    public static DataSet Get_Job_User_Lock_Status(string Jobno, string Username, string Open_time, string Closing_Time, string Flg, string Type)
    {
        DataSet ds_lock = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@Jobno", Jobno);
            param[1] = new SqlParameter("@Open_By", Username);
            param[2] = new SqlParameter("@Opening_Time", Open_time);
            param[3] = new SqlParameter("@Closing_Time", Closing_Time);
            param[4] = new SqlParameter("@BranchCode", Connection.Current_Branch());
            param[5] = new SqlParameter("@Flag", Flg);
            param[7] = new SqlParameter("@Type", Type);

            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;

            ds_lock = Connection.Get_Dataset("SP_IMP_EXP_JOB_OPEN_CLOSE_USER_HISTORY", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds_lock;
    }

}