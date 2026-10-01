using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Web.Hosting;
using System.Web;
using System.Linq;

public class DataTableComparer
{
    public string RowIdentifier { get; set; }
    public string ColumnName { get; set; }
    public object OldValue { get; set; }
    public object NewValue { get; set; }
    public object JobNo1 { get; set; }
    public object User { get; set; }
    public object Branch { get; set; }
    public object Inv_slno { get; set; }
    public object Item_slno { get; set; }

    public string GetMismatchedRowsFast(DataTable dt1, DataTable dt2, string keyColumn, string PageName, string JOBNO, string INV_SLNO, string ITEM_SLNO, string UserID, string Branch)
    {
        DataTable result = dt1.Clone();

        // Create dictionary for fast lookup
        Dictionary<string, DataRow> dict = new Dictionary<string, DataRow>();
        string Output_Alltext = "";
        foreach (DataRow r in dt2.Rows)
        {
            dict[r[keyColumn].ToString()] = r;
        }

        foreach (DataRow r1 in dt1.Rows)
        {
            string key = r1[keyColumn].ToString();

            if (dict.ContainsKey(key))
            {
                DataRow r2 = dict[key];

                foreach (DataColumn col in dt1.Columns)
                {
                    if (r1[col.ColumnName].ToString() != r2[col.ColumnName].ToString())
                    {
                        result.ImportRow(r1);

                        string Output = string.Join("|",
                            PageName,
                            JOBNO,
                            INV_SLNO,
                            ITEM_SLNO,
                            col.ColumnName,
                            r1[col.ColumnName],
                            r2[col.ColumnName],
                            DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt"),
                            UserID,
                            Branch
                   );

                        Output_Alltext += Output + Environment.NewLine;
                    }
                }
            }
        }


        if (Output_Alltext != "")
        {
            string GroupId = HttpContext.Current.Session["GroupID"].ToString();
            string COMPANY_ID = Connection.COMPANYID();
            string folderPath = HttpContext.Current.Server.MapPath("~/logs_DataModifiedHistory/IMP/" + Connection.WorkingPeriod() + "/" + COMPANY_ID + "/" + GroupId + "/");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath); // Creates the folder
            }

            string filePath = folderPath + "/" + JOBNO + ".log";

            if (!string.IsNullOrWhiteSpace(Output_Alltext))
            {
                using (FileStream fs = new FileStream(
                    filePath,
                    FileMode.Append,
                    FileAccess.Write,
                    FileShare.None)) // 🔒 prevents conflicts
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(Output_Alltext);
                }
            }
        }

        return Output_Alltext;
    }


    public string GetMismatchedRowsFast_EXP(DataTable dt1, DataTable dt2, string keyColumn, string PageName, string JOBNO, string INV_SLNO, string ITEM_SLNO, string UserID, string Branch)
    {
        DataTable result = dt1.Clone();

        // Create dictionary for fast lookup
        Dictionary<string, DataRow> dict = new Dictionary<string, DataRow>();
        string Output_Alltext = "";
        foreach (DataRow r in dt2.Rows)
        {
            dict[r[keyColumn].ToString()] = r;
        }

        foreach (DataRow r1 in dt1.Rows)
        {
            string key = r1[keyColumn].ToString();

            if (dict.ContainsKey(key))
            {
                DataRow r2 = dict[key];

                foreach (DataColumn col in dt1.Columns)
                {
                    if (r1[col.ColumnName].ToString() != r2[col.ColumnName].ToString())
                    {
                        result.ImportRow(r1);

                        string Output = string.Join("|",
                            PageName,
                            JOBNO,
                            INV_SLNO,
                            ITEM_SLNO,
                            col.ColumnName,
                            r1[col.ColumnName],
                            r2[col.ColumnName],
                            DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt"),
                            UserID,
                            Branch
                   );

                        Output_Alltext += Output + Environment.NewLine;
                    }
                }
            }

        }


        if (Output_Alltext != "")
        {
            string GroupId = HttpContext.Current.Session["GroupID"].ToString();
            string COMPANY_ID = Connection.COMPANYID();


            string folderPath = HttpContext.Current.Server.MapPath("~/logs_DataModifiedHistory/EXP/" + Connection.WorkingPeriod() + "/" + COMPANY_ID + "/" + GroupId + "/");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath); // Creates the folder
            }

            string filePath = folderPath + "/" + JOBNO + ".log";

            if (!string.IsNullOrWhiteSpace(Output_Alltext))
            {
                using (FileStream fs = new FileStream(
                    filePath,
                    FileMode.Append,
                    FileAccess.Write,
                    FileShare.None)) // 🔒 prevents conflicts
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(Output_Alltext);
                }
            }
        }

        return Output_Alltext;
    }

    public void DeleteLast30Files(string folderPath)
    {
        var directory = new DirectoryInfo(folderPath);

        DateTime del_date = DateTime.Now.AddDays(-30);

        var files = new DirectoryInfo(folderPath).GetFiles()
            .Where(f => f.LastWriteTime.Date < del_date.Date)
            .ToList();

        foreach (var file in files)
        {
            file.Delete();
        }
    }

}



