using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Text;

public partial class Admin_Admin_Excel_Upload : System.Web.UI.Page
{
    string path;
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        method();
       
    }

    
    public void method()
    {
        //String strConnection = System.Configuration.ConfigurationManager.AppSettings["con"];

       // string strConnection = "Server=server\\sqlexpress;database=ERoyalImpex;uid=sa;pwd=sa,123;";
        string strConnection = "Server=103.21.58.192;database=srimathi1314;uid=impexsrimathi;pwd=srimathiimpex;";
        //file upload path
        path= fileuploadExcel.PostedFile.FileName;
        fileuploadExcel.SaveAs(Server.MapPath("~/") + path);
        //path = Path.GetFileName(fileuploadExcel.PostedFile.FileName).ToString();
        
        //Create connection string to Excel work book
        string excelConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/") + path + ";Extended Properties=Excel 12.0;Persist Security Info=False";
        //string excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=Excel 8.0;";

        //Create Connection to Excel work book
       
        using (OleDbConnection conn = new OleDbConnection(excelConnectionString))
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;

            // Get all Sheets in Excel File
            DataTable dtSheet = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            // Loop through all Sheets to get data
            foreach (DataRow dr in dtSheet.Rows)
            {
                string sheetName = dr["TABLE_NAME"].ToString();

                // Get all rows from the Sheet
                cmd.CommandText = "Select * from [" + sheetName + "]";

                DataTable dt = new DataTable();
                dt.TableName = sheetName.Replace("$", string.Empty);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    OleDbDataReader dReader;
                    dReader = cmd.ExecuteReader();
                    SqlBulkCopy sqlBulk = new SqlBulkCopy(strConnection);
                    //Give your Destination table name
                    sqlBulk.DestinationTableName = Path.GetFileNameWithoutExtension(path);//tablename
                    sqlBulk.WriteToServer(dt);
                    dReader.Close();
                }
                //OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                //da.Fill(dt);

                //// Add table into DataSet
                //ds.Tables.Add(dt);
                
            }
            
            cmd = null;
            conn.Close();
        }
       
    }
    public void method1()
    {
        String strConnection = System.Configuration.ConfigurationManager.AppSettings["con"];

        Dictionary<string, string> props = new Dictionary<string, string>();

        // For Excel 2007/2010
        if (fileuploadExcel.PostedFile.FileName.EndsWith(".xlsx"))
        {
            props["Provider"] = "Microsoft.ACE.OLEDB.12.0;";
            props["Extended Properties"] = "Excel 12.0 XML";
        }
        // For Excel 2003 and older
        else if (fileuploadExcel.PostedFile.FileName.EndsWith(".xls"))
        {
            props["Provider"] = "Microsoft.Jet.OLEDB.4.0";
            props["Extended Properties"] = "Excel 8.0";
        }


        props["Data Source"] = fileuploadExcel.PostedFile.FileName;
        StringBuilder sb = new StringBuilder();

        foreach (KeyValuePair<string, string> prop in props)
        {
            sb.Append(prop.Key);
            sb.Append('=');
            sb.Append(prop.Value);
            sb.Append(';');
        }

        string connectionString = sb.ToString();
        // -- End of Constructing OLEDB connection string to Excel file

        // Connecting to Excel File
        using (OleDbConnection conn = new OleDbConnection(connectionString))
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;

            // Get all Sheets in Excel File
            DataTable dtSheet = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            // Loop through all Sheets to get data
            foreach (DataRow dr in dtSheet.Rows)
            {
                string sheetName = dr["TABLE_NAME"].ToString();

                // Get all rows from the Sheet
                cmd.CommandText = "SELECT * FROM [" + sheetName + "]";

                DataTable dt = new DataTable();
                dt.TableName = sheetName.Replace("$", string.Empty);
                OleDbDataReader dReader;
                dReader = cmd.ExecuteReader();
                SqlBulkCopy sqlBulk = new SqlBulkCopy(strConnection);
                //Give your Destination table name
                sqlBulk.DestinationTableName = "AIRLINE_MASTER";
                sqlBulk.WriteToServer(dReader);
                conn.Close();
                //OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                //da.Fill(dt);

                //// Add table into DataSet
                //ds.Tables.Add(dt);
            }

            cmd = null;
            conn.Close();
        }
    }
}