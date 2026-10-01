using System;
using System.Collections.Generic;
using System.Web;
using System.Configuration;
using System.IO;
using System.Diagnostics;

public class ErrorLogs
{
    public string errorFolder;
    public ErrorLogs()
    {
        try
        {
            //errorFolder = HttpContext.Current.Request.PhysicalApplicationPath + (string)ConfigurationManager.AppSettings["logFolder"] + "\\";
            errorFolder = HttpContext.Current.Request.PhysicalApplicationPath + "logs" + "\\";
        }
        catch (Exception ex)
        {
            // Connection.Error_Msg(ex.Message);
        }
    }

    public void makeLog(string errorText)
    {
        try
        {
            string logline, logFileName;
            //StreamWriter sw = new StreamWriter("C:/PinokeyErrors/ErrorList.txt", true);

            logFileName = "ErrorLog_" + DateTime.Now.ToString("yyyyMMdd") + ".log";
            StreamWriter sw = new StreamWriter(errorFolder + logFileName, true);
            logline = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt") + " : " + HttpContext.Current.Session["COMPANY_LICENSE"].ToString() + "/" + HttpContext.Current.Session["GroupName"].ToString() + "/" + HttpContext.Current.Session["CLIENT_NAME"].ToString() + "/Page:" + HttpContext.Current.Request.CurrentExecutionFilePath + "-->" + errorText;
            sw.WriteLine(logline);
            sw.Close();
            sw.Dispose();
        }
        catch (Exception ex)
        {
           // Connection.Error_Msg(ex.Message);
         }
        
    }
}