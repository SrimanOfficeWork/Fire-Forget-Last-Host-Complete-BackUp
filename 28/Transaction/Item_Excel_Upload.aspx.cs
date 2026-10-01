using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Generic;

using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Data.SqlClient;

public partial class Transaction_Item_Excel_Upload : System.Web.UI.Page
{
    Transaction Transact = new Transaction();

    public string ID,Name;
    string strConnection;
    SqlConnection sqlcon;
    SqlCommand sqlcmd;
    //string sqlcon;

    protected void Page_Load(object sender, EventArgs e)
    {
        //strConnection = "Server=server\\sqlexpress;database=ERoyalImpex;uid=sa;pwd=sa,123;";        
            
        //con.ConnectionString = "Data Source=server\\sqlexpress;Initial Catalog=ERoyalImpex;uid=sa;pwd=sa,123;Persist Security Info=True";
        //con.ConnectionString = "Data Source=server\\sqlexpress;Initial Catalog=ERoyalImpex;User ID=sa;Password=sa,123";

         //sqlcon = "Data Source=server\\sqlexpress;Initial Catalog=ERoyalImpex;UID=sa;pwd=sa,123";

        sqlcon = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["sqlcon"]);
    }

    protected void btnImport_Click(object sender, EventArgs e)
    {
        string connString = "";
        string strFileType = Path.GetExtension(fileuploadExcel.FileName).ToLower();
        string path = "C:\\Documents and Settings\\sys\\Desktop\\" + fileuploadExcel.FileName;


        //Connection String to Excel Workbook
        if (strFileType.Trim() == ".xls")
        {
            connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
        }
        else if (strFileType.Trim() == ".xlsx")
        {
            connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
        }
        string query = "SELECT [ID],[Name] FROM [sample$]";
        OleDbConnection conn = new OleDbConnection(connString);
        if (conn.State == ConnectionState.Closed)
            conn.Open();
        OleDbCommand cmd = new OleDbCommand(query, conn);
        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        // Label1.Text =Convert.ToString(ds.Tables[0].Rows[0]);
        //Label2.Text= Convert.ToString(ds.Tables[0].Rows[1]);
        grvExcelData.DataSource = ds.Tables[0];
        grvExcelData.DataBind();
        da.Dispose();
        conn.Close();
        conn.Dispose();


        int a = 0;
        if (ds.Tables[0].Rows.Count > a)
        {

            while (ds.Tables[0].Rows.Count > a)
            {
                ID = ds.Tables[0].Rows[a][0].ToString();
                Name = ds.Tables[0].Rows[a][1].ToString();
                //sqlconnew = new SqlConnection(ConfigurationManager.AppSettings.Get(sqlcon));
               
                if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();

                string str="insert into sam values('"+ID+"','"+Name+"')";
                sqlcmd = new SqlCommand(str, sqlcon);

                sqlcmd.ExecuteNonQuery();
                sqlcon.Close();
                

                a++;
            }
        }
    }
}