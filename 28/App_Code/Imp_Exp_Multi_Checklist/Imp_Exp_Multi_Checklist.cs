using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using BussinessObject;
using System.IO;
using Ionic.Zip;

public class Imp_Exp_Multi_Checklist
{
    DataSet ds = new DataSet();
    public DataSet Get_imp_exp_PartyName(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@JOBNO_MULTI", objUserBL.A1);
            param[1] = new SqlParameter("@PARTY_NAME", objUserBL.A2);
            param[2] = new SqlParameter("@FROM_DATE", objUserBL.A3);
            param[3] = new SqlParameter("@TO_DATE", objUserBL.A4);
            param[4] = new SqlParameter("@JobType", objUserBL.A5);

            param[5] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());
            param[6] = new SqlParameter("@MFLAG", objUserBL.A14);
            param[7] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());
            param[8] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            ds = Connection.Get_Dataset("IMP_EXP_MULTIPLE_CHECKLIST", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;

    }
    public void CreateZipAndDownload(HttpContext context, string folderPath, string downloadToken)
    {
        try
        {
            if (!Directory.Exists(folderPath))
                throw new DirectoryNotFoundException("Folder not found: " + folderPath);

            string[] pdfFiles = Directory.GetFiles(folderPath, "*.pdf");
            var validFiles = new List<string>();
            foreach (string f in pdfFiles)
            {
                if (new FileInfo(f).Length > 0)
                    validFiles.Add(f);
            }

            if (validFiles.Count == 0)
                throw new Exception("No PDF files were generated.");

            context.Response.Clear();
            context.Response.ContentType = "application/zip";
            context.Response.AppendHeader("Content-Disposition",
                "attachment; filename=Multiple_checklist.zip");

            // ★ Set cookie BEFORE streaming — browser receives it with the response
            // JS polls for this cookie to detect download completion
            HttpCookie cookie = new HttpCookie("downloadReady_" + downloadToken, "1");
            cookie.Path = "/";
            context.Response.Cookies.Add(cookie);

            using (ZipFile zip = new ZipFile())
            {
                foreach (string f in validFiles)
                    zip.AddFile(f, "Multiple_checklist");

                zip.Save(context.Response.OutputStream);
            }

            context.Response.Flush();
        }
        catch (Exception ex)
        {
            context.Response.Clear();
            context.Response.StatusCode = 500;
            context.Response.Write("Error: " + ex.Message);
            context.Response.Flush();
        }
        finally
        {
            try
            {
                if (Directory.Exists(folderPath))
                    Directory.Delete(folderPath, true);
            }
            catch { }

            try { context.Response.End(); }
            catch { }
        }
    }

 
}



