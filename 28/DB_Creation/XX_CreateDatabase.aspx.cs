using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

public partial class XX_CreateDatabase : System.Web.UI.Page
{
    SqlConnection conn1 = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    //public string ConnectionString = "Integrated Security=SSPI;" +
    //                                 "Initial Catalog=;" +
    //                                 "Data Source=Admin-Server;User ID=sa;Password=sa,123;";
    public SqlDataReader reader = null;
    public SqlConnection conn = null;
    public SqlCommand cmd = null;
    //public System.Windows.Forms.Button AlterTableBtn;
    public string sql = null;
    //public System.Windows.Forms.Button CreateOthersBtn;
    //public System.Windows.Forms.Button button1;

    //private void ExecuteSQLStmt(string sql)
    //{
    //    SqlConnection conn = new SqlConnection(ConnectionString);

    //        conn.Close();
    //    conn.ConnectionString = "Integrated Security=SSPI;" +
    //    "Initial Catalog=mydb;" +
    //    "Data Source=Admin-Server;User ID=sa;Password=sa,123;"; 
    //    conn.Open();
    //    cmd = new SqlCommand(sql, conn);
    //    try
    //    {
    //        cmd.ExecuteNonQuery();
    //    }
    //    catch (SqlException ae)
    //    {
    //        MessageBox.Show(ae.Message.ToString());
    //    }
    //}
    public void GetDbCreationQuery()
    {
         /*
        SqlConnection conn1 = new SqlConnection();
        //conn1.ConnectionString = "Data Source=ADMIN_IMPEX;" +
        //"Initial Catalog=mydb;" +
        //"User id=rtsadmin;" +
        //"Password=rtsimpexadmin123@;";

       
        //conn1.ConnectionString = "Server=115.112.232.213;database=ADMIN_IMPEX;uid=rtsadmin;pwd=rtsimpexadmin123@;";
        conn1 = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);
        conn1.Open();
        */
        
        //conn1 = "Data Source=servername;" + "Initial Catalog=databasename;User id=uasername;Password=password;";
        //SqlConnection connection;
        //connection = new SqlConnection(ConnectionString);
        //connection.Open();

        /*SqlConnection conn1 = new SqlConnection();
        conn1.ConnectionString = "Data Source=115.112.232.213;" +
        "Initial Catalog=master;" +
        "User id=rtsadmin;" +
        "Password=rtsimpexadmin123@;";
        */
        SqlConnection conn1 = new SqlConnection();
        conn1.ConnectionString = "Integrated Security=SSPI;Data Source=localhost;" +
        "Initial Catalog=master;" +
        "Trusted_connection=true;";

      

        if (conn1.State != ConnectionState.Open)
            conn1.Open();

        string sql = "CREATE DATABASE "+txtName.Text;

        cmd = new SqlCommand(sql, conn1);
        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (SqlException ae)
        {
            //MessageBox.Show(ae.Message.ToString());
        }

    }

    //public void Get_TabelStructure()
    //{
    //    SqlConnection conn1 = new SqlConnection();
    //    conn1.ConnectionString =
    //    "Data Source=ADMIN-SERVER;" +
    //    "Initial Catalog=DB123;" +
    //    "User id=sa;" +
    //    "Password=sa,123;";
    //    conn1.Open();

    //    if (conn1.State != ConnectionState.Open)
    //        conn1.Open();

    //    string sql = "select * from DB_TABLE";

    //    SqlCommand cmd = new SqlCommand(sql, conn1);
    //    SqlDataReader reader = cmd.ExecuteReader();
    //    DataTable schema = reader.GetSchemaTable();

    //    cmd = new SqlCommand(sql, conn1);
    //    try
    //    {
    //        cmd.ExecuteNonQuery();
    //    }
    //    catch (SqlException ae)
    //    {
    //        MessageBox.Show(ae.Message.ToString());
    //    }
    //}

    protected void btn_Create_Click(object sender, EventArgs e)
    {
        if (txtName.Text != "")
        {
            GetDbCreationQuery();
        }
        else
        {
            //MessageBox.Show(" Enter Database Name");
        }
    }
}