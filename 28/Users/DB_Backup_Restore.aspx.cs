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

public partial class Users_DB_Backup_Restore : ThemeClass
{

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

    }

    protected void btnrestore_Click(object sender, EventArgs e)
    {
         if (FileUpload1.HasFile == true)
            {
               string ext = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);

               if (ext.ToUpper() == ".BAK")
               {
                  // Restore();
               }
               else
               {
                   Alert_msg("Invalid File");
               
               }
            }

         else
         {
             Alert_msg("Upload your file");
         }

        
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GENERAL', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

   /* private void Restore()
    { 
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
            string _BackupName = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);


            string sqlQuery_2 = "RESTORE DATABASE " + _DatabaseName + " FROM DISK ='" + _BackupName + "'";
            SqlCommand sqlCommand_2 = new SqlCommand(sqlQuery_2, con);
            sqlCommand.CommandType = CommandType.Text;
            int iRows = sqlCommand_2.ExecuteNonQuery();
            con.Close();

        }
        catch (SqlException sqlException)
        {
           // lblMessage.Text = sqlException.Message.ToString();
        }
        catch (Exception exception)
        {
            //lblMessage.Text = exception.Message.ToString();
        }
    }*/
}