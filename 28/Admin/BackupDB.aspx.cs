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

public partial class Backup_BackupDB : System.Web.UI.Page
{
  
   // SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string Company_ID;

    public string SELECT_TYPE, SELECT_BRANCH;

    AppSession aps = new AppSession();



    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();

        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        Company_ID = Session["COMPANY_ID"].ToString();
      

       

        if (!Page.IsPostBack)
        {
            FillDatabases();
            ReadBackupFiles();
        }
    }

    private void FillDatabases()
    {
        try
        {
            SqlConnection con = new SqlConnection(comp_ConnectionStr);
            con.Open();
            string sqlQuery = "SELECT * FROM sys.databases";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, con);
            sqlCommand.CommandType = CommandType.Text;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            ddlDatabases.DataSource = dataSet.Tables[0];
            ddlDatabases.DataTextField = "name";
            ddlDatabases.DataValueField = "database_id";
            ddlDatabases.DataBind();

            con.Close();
        }
        catch (SqlException sqlException)
        {
            lblMessage.Text = sqlException.Message.ToString();
        }
        catch (Exception exception)
        {
            lblMessage.Text = exception.Message.ToString();
        }
    }

    protected void btnBackup_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection con = new SqlConnection(comp_ConnectionStr);
            string _DatabaseName = ddlDatabases.SelectedItem.Text.ToString();
            string _BackupName = _DatabaseName + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + ".bak";

            
            con.Open();
            string sqlQuery = "BACKUP DATABASE " + _DatabaseName + " TO DISK =  'D:\\Backup\\" + _BackupName + "' WITH FORMAT, MEDIANAME = 'Z_SQLServerBackups', NAME = '" + _BackupName + "';";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, con);
            sqlCommand.CommandType = CommandType.Text;
            int iRows = sqlCommand.ExecuteNonQuery();
            con.Close();
            lblMessage.Text = "The " + _DatabaseName + " database Backup with the name " + _BackupName + " successfully...";
            ReadBackupFiles();
        }
        catch (SqlException sqlException)
        {
            lblMessage.Text = sqlException.Message.ToString();
        }
        catch (Exception exception)
        {
            lblMessage.Text = exception.Message.ToString();
        }
    }

    private void ReadBackupFiles()
    {
        try
        {
            if (!Directory.Exists(@"D:\\Backup\\"))
           {
               Directory.CreateDirectory(@"D:\\Backup\\");
           }

            string[] files = Directory.GetFiles(@"D:\\Backup\\", "*.bak");
            lstBackupfiles.DataSource = files;
            lstBackupfiles.DataBind();
            lstBackupfiles.SelectedIndex = 0;
        }
        catch (Exception exception)
        {
            lblMessage.Text = exception.Message.ToString();
        }
    }


    protected void btnRestore_Click(object sender, EventArgs e)
    {
     /*   try
        {
            if (lstBackupfiles.SelectedIndex > 0)
            {
                string _DatabaseName = ddlDatabases.SelectedItem.Text.ToString();
                string _BackupName = lstBackupfiles.SelectedItem.Text.ToString();


                con.Open();
                string sqlQuery = "RESTORE DATABASE " + _DatabaseName + " FROM DISK ='" + _BackupName + "'";
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, con);
                sqlCommand.CommandType = CommandType.Text;
                int iRows = sqlCommand.ExecuteNonQuery();
                con.Close();
                lblMessage.Text = "The " + _DatabaseName + " database restored with the name " + _BackupName + " successfully...";
            }
        }
        catch (SqlException sqlException)
        {
            lblMessage.Text = sqlException.Message.ToString();
        }
        catch (Exception exception)
        {
            lblMessage.Text = exception.Message.ToString();
        }*/
    }
}
