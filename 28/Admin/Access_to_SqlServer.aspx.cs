using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Xml;
using System.Web.SessionState;
using System.IO;


public partial class Transaction_Default2 : ThemeClass
{

    AppSession aps = new AppSession();
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string errorFolder = "";
  

    SqlConnection conadmin = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);
    OleDbConnection connExport = new OleDbConnection(System.Configuration.ConfigurationManager.AppSettings["connExport"]);
    OleDbConnection connImport = new OleDbConnection(System.Configuration.ConfigurationManager.AppSettings["connImport"]);

    string con123 = "Server=server=103.21.58.192;database=vaishnavi1314;uid=impexvaishnavi;pwd=vaishnaviimpex;";


    protected System.Data.SqlClient.SqlConnection sqlConnection;
    protected System.Data.SqlClient.SqlCommand sqlCommand;
    protected System.Data.OleDb.OleDbConnection oleDbConn;
    protected System.Data.OleDb.OleDbCommand oleDbCommand;
    SqlDataAdapter da = new SqlDataAdapter();
    OleDbCommand mycommand = new OleDbCommand();

    ConsigneeUpload consignee = new ConsigneeUpload();
    ConsigneeUpload sup = new ConsigneeUpload();
    ConsigneeUpload buyer = new ConsigneeUpload();
    ConsigneeUpload AD_Code = new ConsigneeUpload();
    ConsigneeUpload ImpEX = new ConsigneeUpload();
    AdminMasterDetails admin = new AdminMasterDetails();


    SqlConnection conn;
    SqlCommand cmd = new SqlCommand();
    DataSet ds = new DataSet();


    SqlConnection conERoyal;
    SqlCommand connex = new SqlCommand();

    SqlConnection conImpexLogin;
    SqlCommand cmdImpexLogin = new SqlCommand();
    SqlDataReader dd;


    OleDbCommand ocmd = new OleDbCommand();

    protected void Page_Load(object sender, EventArgs e)
    {

        aps.checkSession();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
         
    }
  
}