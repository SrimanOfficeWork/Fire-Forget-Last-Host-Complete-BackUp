using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.IO;

using Ionic.Zip;
using System.Collections.Generic;


using System.Text;
using System.IO.Compression;
/// <summary>
/// Summary description for DB_backup
/// </summary>
public class DB_backup
{
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string Company_ID;

    public string Client_Database;
    public string Comp_License_DB_BKP;

    public string SELECT_TYPE, SELECT_BRANCH;

    AppSession aps = new AppSession();


    public void Backup()
    {
        aps.checkSession();
        currentuser = HttpContext.Current.Session["currentuser"].ToString();
        currentbranch = HttpContext.Current.Session["currentbranch"].ToString();
        currentcomp_name = HttpContext.Current.Session["currentcomp_name"].ToString();
        comp_ConnectionStr = HttpContext.Current.Session["currentcomp_db"].ToString();

        Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();
        LoginDate = HttpContext.Current.Session["LoginDate"].ToString();
        Company_ID = HttpContext.Current.Session["COMPANY_ID"].ToString();
        try
        {
            SqlConnection con = new SqlConnection(comp_ConnectionStr);
            con.Open();
            string sqlQuery = " SELECT DB_NAME() as name ";

            SqlCommand sqlCommand = new SqlCommand(sqlQuery, con);
            sqlCommand.CommandType = CommandType.Text;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);


            string _DatabaseName = dataSet.Tables[0].Rows[0][0].ToString();
            // string _BackupName = _DatabaseName + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + ".bak";
            string _BackupName = _DatabaseName + ".bak";

            string path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/");

            string sqlQuery_2 = "BACKUP DATABASE " + _DatabaseName + " TO DISK =  '" + path + _BackupName + "' WITH FORMAT, MEDIANAME = 'Z_SQLServerBackups', NAME = '" + _BackupName + "';";
            SqlCommand sqlCommand_2 = new SqlCommand(sqlQuery_2, con);
            sqlCommand_2.CommandType = CommandType.Text;
            sqlCommand_2.CommandTimeout = 3000000;
            int iRows = sqlCommand_2.ExecuteNonQuery();
            con.Close();

            file_download(_DatabaseName);

        }
        catch (SqlException sqlException)
        {
            //lblMessage.Text = sqlException.Message.ToString();
        }
        catch (Exception exception)
        {
            //lblMessage.Text = exception.Message.ToString();
        }

    }


    public void All_DB_Backup()
    {
        aps.checkSession();
        currentuser = HttpContext.Current.Session["currentuser"].ToString();
        currentbranch = HttpContext.Current.Session["currentbranch"].ToString();
        currentcomp_name = HttpContext.Current.Session["currentcomp_name"].ToString();
        comp_ConnectionStr = HttpContext.Current.Session["currentcomp_db"].ToString();

        Client_Database = HttpContext.Current.Session["Client_Server"].ToString();

        Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();
        LoginDate = HttpContext.Current.Session["LoginDate"].ToString();
        Company_ID = HttpContext.Current.Session["COMPANY_ID"].ToString();

        Comp_License_DB_BKP=HttpContext.Current.Session["Comp_License_DB_BKP"].ToString();

        try
        {
            SqlConnection con = new SqlConnection(Client_Database);
            con.Open();
            string sqlQuery = " SELECT DB_NAME() as name ";

            SqlCommand sqlCommand = new SqlCommand(sqlQuery, con);
            sqlCommand.CommandType = CommandType.Text;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);


            string _DatabaseName = dataSet.Tables[0].Rows[0][0].ToString();

            _DatabaseName = "[" + _DatabaseName + "]";

            //string _DatabaseName;
           
            //if (dataSet.Tables[0].Rows[0][0].ToString() == "7ELEVEN_1516")
            //{
            //    _DatabaseName = "[7ELEVEN_1516]";
            //}
            //else
            //{
            //    _DatabaseName = dataSet.Tables[0].Rows[0][0].ToString();
            //}


            // string _BackupName = _DatabaseName + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + ".bak";
            string _BackupName = _DatabaseName + ".bak";

            string _BackupName_comp_license = Comp_License_DB_BKP + "_" +_DatabaseName + ".bak";

            string path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/");

            string sqlQuery_2 = "BACKUP DATABASE " + _DatabaseName + " TO DISK =  '" + path + _BackupName_comp_license + "' WITH FORMAT, MEDIANAME = 'Z_SQLServerBackups', NAME = '" + _BackupName + "';";
            SqlCommand sqlCommand_2 = new SqlCommand(sqlQuery_2, con);
            sqlCommand_2.CommandType = CommandType.Text;
            int iRows = sqlCommand_2.ExecuteNonQuery();
            con.Close();

            DB_download(_DatabaseName);

        }
        catch (SqlException sqlException)
        {
            //lblMessage.Text = sqlException.Message.ToString();
        }
        catch (Exception exception)
        {
            //lblMessage.Text = exception.Message.ToString();
        }

    }

    private void file_download(string _DatabaseName)
    {
        HttpResponse Response = HttpContext.Current.Response;
        string filePath = _DatabaseName + ".bak";
       
        //Response.ContentType = "application/bak";
        //Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath_zip + "\"");
        // Response.TransmitFile(System.Web.HttpContext.Current.Server.MapPath("~/Submission/" + filePath_zip));
        //Response.End();


        using (ZipFile zip = new ZipFile())
        {
            zip.AlternateEncodingUsage = ZipOption.AsNecessary;
            zip.AddDirectoryByName("Files");
            //foreach (GridViewRow row in GridView1.Rows)
            //{
            //    if ((row.FindControl("chkSelect") as CheckBox).Checked)
            //    {
            //        string filePath = "E:/ERoyalimpex_Branchwise_Job_SingleWindow/Submission/" + filePath;
            //        zip.AddFile(filePath, "Files");
            //    }
            //}

            //string filePathNEW = "~/Submission/" + filePath;
            //string filePathNEW = Directory.GetFiles(server.MapPath("~/Files/"));

            string filePathNEW = System.Web.HttpContext.Current.Server.MapPath("~/Submission/" + filePath);

            zip.AddFile(filePathNEW, "Files");

            Response.Clear();
            Response.BufferOutput = false;
            string zipName = String.Format(_DatabaseName + "_{0}.zip", DateTime.Now.ToString("dd-MM-yyyy-HHmmss"));
            Response.ContentType = "application/zip";
            Response.AddHeader("content-disposition", "attachment; filename=" + zipName);            
            zip.Save(Response.OutputStream);
            Response.End();
        }


    }

    private void DB_download(string _DatabaseName)
    {
        HttpResponse Response = HttpContext.Current.Response;
        string filePath = Comp_License_DB_BKP+"_"+_DatabaseName + ".bak";

        //Response.ContentType = "application/bak";
        //Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");

        //Response.TransmitFile(System.Web.HttpContext.Current.Server.MapPath("~/Submission/" + filePath));
        //Response.End();

        using (ZipFile zip = new ZipFile())
        {
            zip.AlternateEncodingUsage = ZipOption.AsNecessary;
            zip.AddDirectoryByName("Files");
           
            string filePathNEW = System.Web.HttpContext.Current.Server.MapPath("~/Submission/" + filePath);

            zip.AddFile(filePathNEW, "Files");

            Response.Clear();
            Response.BufferOutput = false;
            string zipName = String.Format(_DatabaseName + "_{0}.zip", DateTime.Now.ToString("dd-MM-yyyy-HHmmss"));
            Response.ContentType = "application/zip";
            Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
            zip.Save(Response.OutputStream);
            Response.End();
        }
       
    }
    public void Backup_All_Zip(string errorFolder, string F_Path)
    {
        HttpResponse Response = HttpContext.Current.Response;
        using (ZipFile zip = new ZipFile())
        {
            zip.AlternateEncodingUsage = ZipOption.AsNecessary;
            //zip.AddDirectoryByName("Files");
            zip.AddDirectoryByName(F_Path);

            //-------------------------------------------------------------------------------------------------
            string[] filePaths = Directory.GetFiles(errorFolder);
            // List<ListItem> files = new List<ListItem>();
            foreach (string filePath in filePaths)
            {
                //zip.AddFile(filePath, "Files");
                zip.AddFile(filePath, F_Path);
            }
            //-------------------------------------------------------------------------------------------------
            Response.Clear();
            Response.BufferOutput = false;
            string zipName = F_Path + ".Zip";
            Response.ContentType = "application/zip";
            Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
            zip.Save(Response.OutputStream);
            Response.End();
        }
    }
   
}