using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Web;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.IO;
using System.Net;
using Ionic.Zip;


public class Export_FlatFile_Generation
{
    #region Private string

    private int exp_result;
   
    private string _JOBNO;
    private string _TRANSPORT_MODE;
    private string _Ename;
    private string _Workingperiod;
    private string _name1;
    private string _name2;
    private string _name3;


    #endregion


    #region public string

    public int result;
    public DataSet ds= new DataSet();

    public string JOBNo
    {
        get { return _JOBNO; }
        set { _JOBNO = value; }
    }
    public string TRANSPORT_MODE
    {
        get { return _TRANSPORT_MODE; }
        set { _TRANSPORT_MODE = value; }
    }

    public string Ename
    {
        get { return _Ename; }
        set { _Ename = value; }
    }
    public string Workingperiod
    {
        get { return _Workingperiod; }
        set { _Workingperiod = value; }
    }

    public string name1
    {
        get { return _name1; }
        set { _name1 = value; }
    }
    public string name2
    {
        get { return _name2; }
        set { _name2 = value; }
    }
    public string name3
    {
        get { return _name3; }
        set { _name3 = value; }
    }
    #endregion


    public DataSet Retrieve_Export_All_Details()
    {
        try
        {
            
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", JOBNo);

            param[6] = new SqlParameter("@TRANSPORT_MODE", TRANSPORT_MODE);

            param[1] = new SqlParameter("@name", Ename);

            param[2] = new SqlParameter("@Working_Period", Workingperiod);


            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;

            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            if (Ename == "FlatFile")
            {

                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_FLAT_FILE_GENERATION", param);
                string err = param[5].Value.ToString();
                result = Convert.ToInt32(param[3].Value.ToString());
            }
            else if (Ename == "Exp_Combine_FlatFile")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_COMBINE_FLAT_FILE_GENERATION", param);
                string err = param[5].Value.ToString();
                result = Convert.ToInt32(param[3].Value.ToString());
            }

            else if (Ename == "Export_Goods_Registration_FlatFile")
            {

                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_FLAT_FILE_GENERATION", param);
                string err = param[5].Value.ToString();
                result = Convert.ToInt32(param[3].Value.ToString());
            }

            else
            {

                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_FLAT_FILE_GENERATION", param);
                string err = param[5].Value.ToString();
                result = Convert.ToInt32(param[3].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;

    }

    public void Open_Textfile(string errorFolder)
    {

        try
        {
            //FileInfo file = new FileInfo(errorFolder + HttpContext.Current.Session["createflename"].ToString());
            ////StringWriter sw1 = new StringWriter();
            ////sw1.Write(file.FullName);
            ////HtmlTextWriter htw = new HtmlTextWriter(sw1);

            //HttpResponse Respon = HttpContext.Current.Response;

            //Respon.Clear();
            //Respon.ClearHeaders();
            //Respon.ClearContent();
            //Respon.AddHeader("Content-Disposition", "attachment; filename =" + HttpContext.Current.Session["createflename"].ToString());
            ////Response.AppendHeader("Content-Length", file.Length.ToString());
            //Respon.ContentType = "text/plain";

            //Respon.WriteFile(file.FullName);
            //Respon.Flush();
            //Respon.Close();
            ////Respon.End();
            //HttpContext.Current.ApplicationInstance.CompleteRequest();


            //--------------------------------------

            //FileInfo file1 = new FileInfo(errorFolder + HttpContext.Current.Session["createflename"].ToString());

            //HttpResponse Response = HttpContext.Current.Response;

            //Response.ContentType = "text/plain";
            //Response.AppendHeader("Content-Disposition", "attachment; filename=" + HttpContext.Current.Session["createflename"].ToString());

            //// Write the file to the Response
            //const int bufferLength = 10000;
            //byte[] buffer = new Byte[bufferLength];
            //int length = 0;
            //Stream download = null;
            //try
            //{
            //    download = new FileStream(HttpContext.Current.Server.MapPath(file1.ToString()),
            //                                                   FileMode.Open,
            //                                                   FileAccess.Read);
            //    do
            //    {
            //        if (Response.IsClientConnected)
            //        {
            //            length = download.Read(buffer, 0, bufferLength);
            //            Response.OutputStream.Write(buffer, 0, length);
            //            buffer = new Byte[bufferLength];
            //        }
            //        else
            //        {
            //            length = -1;
            //        }
            //    }
            //    while (length > 0);
            //    Response.Flush();
            //    Response.End();
            //}
            //finally
            //{
            //    if (download != null)
            //        download.Close();
            //}


            //--------------------

            //FileInfo FileName = new FileInfo(errorFolder + HttpContext.Current.Session["createflename"].ToString());
            //if (File.Exists(HttpContext.Current.Server.MapPath(string.Concat(FileName))) == true)
            //{
            //    string attachment = "attachment; filename=" + FileName;
            //    HttpContext.Current.Response.ClearContent();
            //    HttpContext.Current.Response.AddHeader("content-disposition", attachment);
            //    HttpContext.Current.Response.ContentType = "application/text";
            //    HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.Default;
            //    HttpContext.Current.Response.TransmitFile(string.Concat(FileName));
            //    HttpContext.Current.Response.End();
            //}

            //---------------------------


            string strURL = errorFolder + HttpContext.Current.Session["createflename"].ToString();
            WebClient req = new WebClient();
            HttpResponse response = HttpContext.Current.Response;
            response.Clear();
            response.ClearContent();
            response.ClearHeaders();
            response.Buffer = true;
            response.ContentType = "text/plain";
            response.AddHeader("Content-Disposition", "attachment;filename=\"" + HttpContext.Current.Session["createflename"].ToString());
            byte[] data = req.DownloadData(strURL);
            //response.BinaryWrite(data);
            response.TransmitFile(strURL);
            response.End();

         }

        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }



    public void Open_Imp_Eway_Bill_Zip(string errorFolder)
    {
        HttpResponse Response = HttpContext.Current.Response;
        using (ZipFile zip = new ZipFile())
        {
            zip.AlternateEncodingUsage = ZipOption.AsNecessary;
            //zip.AddDirectoryByName("Files");
            zip.AddDirectoryByName(Connection.IMP_Jobno().ToString());

            //-------------------------------------------------------------------------------------------------
            string[] filePaths = Directory.GetFiles(errorFolder);
            // List<ListItem> files = new List<ListItem>();
            foreach (string filePath in filePaths)
            {
                //zip.AddFile(filePath, "Files");
                zip.AddFile(filePath, Connection.IMP_Jobno().ToString());
            }
            //-------------------------------------------------------------------------------------------------
            Response.Clear();
            Response.BufferOutput = false;
            string zipName =  Connection.IMP_Jobno().ToString()+ ".Zip";
            Response.ContentType = "application/zip";
            Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
            zip.Save(Response.OutputStream);
            Response.End();
        }
    }


    public void Open_Textfile(string errorFolder, string file)
    {

        try
        {
            string strURL = errorFolder+file;
            WebClient req = new WebClient();
            HttpResponse response = HttpContext.Current.Response;
            response.Clear();
            response.ClearContent();
            response.ClearHeaders();
            response.Buffer = true;
            response.ContentType = "text/plain";
            response.AddHeader("Content-Disposition", "attachment;filename=\"" + file);
            byte[] data = req.DownloadData(strURL);
            //response.BinaryWrite(data);
            response.TransmitFile(strURL);
            response.End();
        }

        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public DataSet Search_Admin_Master()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@CODE", name1);
            param[6] = new SqlParameter("@CODE1", name2);
            param[1] = new SqlParameter("@CODE2", name3);
            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            if (Ename == "IMPORT_SELECT")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "FLATFILE_ADMIN_SEARCH_SELECT", param);
                string err = param[5].Value.ToString();
            }
            else if (Ename == "IMPORT_SELECT_COUNTRY")
            {

                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "FLATFILE_ADMIN_SEARCH_SELECT", param);
                string err = param[5].Value.ToString();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}