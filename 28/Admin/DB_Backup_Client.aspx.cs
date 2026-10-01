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

public partial class Admin_DB_Backup_Client : ThemeClass
{

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string Company_ID;
    public string Comp_license;

    public string SELECT_TYPE, SELECT_BRANCH;

    Sales_Stmts SS = new Sales_Stmts();
    AppSession aps = new AppSession();

    DataSet ds = new DataSet();

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



        if (!IsPostBack)
        {           
            load_Client_name();
        }
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

    private void load_Client_name()
    {
        
        //SS.flag = "All_Client_Names";
	SS.flag = "All_Client_Names_Backup";

        SS.Working_period = Working_Period;
        ds = SS.All_DB_Backup_Select();

        Session.Remove("ds");
        Session["ds"] = ds;

        ddlClient_name.DataTextField = ds.Tables[0].Columns["COMPANY_LICENSE"].ToString();
        ddlClient_name.DataValueField = ds.Tables[0].Columns["COMPANY_ID"].ToString();

        ddlClient_name.DataSource = ds.Tables[0];
        ddlClient_name.DataBind();
        ddlClient_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlClient_name.SelectedIndex = 0;

        //ddl_WorkingPeriod.DataTextField = ds.Tables[1].Columns["WORKING_PERIOD"].ToString();
        //ddl_WorkingPeriod.DataValueField = ds.Tables[1].Columns["WORKING_PERIOD"].ToString();
        //ddl_WorkingPeriod.DataSource = ds.Tables[1];
        //ddl_WorkingPeriod.DataBind();

        //ddl_WorkingPeriod.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        //ddl_WorkingPeriod.SelectedIndex = 0;

   
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
    protected void ddlClient_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlClient_name.SelectedItem.Text != string.Empty)
        {
            string[] s1 = ddlClient_name.SelectedItem.Text.Split(new string[] { "-" }, StringSplitOptions.None);
            Comp_license = s1[0].ToString();

            ds = (DataSet)HttpContext.Current.Session["ds"];

            DataView view_db = ds.Tables[1].DefaultView;
            view_db.Sort = "WORKING_PERIOD desc";
            view_db.RowFilter = "COMPANY_LICENSE = '" + Comp_license + "'" ;
            DataTable table_Lic = view_db.ToTable();
            DataSet dss_db = new DataSet();
            dss_db.Tables.Add(table_Lic);

            ddl_WorkingPeriod.DataTextField = dss_db.Tables[0].Columns["WORKING_PERIOD"].ToString();
            ddl_WorkingPeriod.DataValueField = dss_db.Tables[0].Columns["WORKING_PERIOD"].ToString();
            ddl_WorkingPeriod.DataSource = dss_db.Tables[0];
            ddl_WorkingPeriod.DataBind();

            //ddl_WorkingPeriod.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            //ddl_WorkingPeriod.SelectedIndex = 0;

            Session.Remove("Comp_License_DB_BKP");
            Session["Comp_License_DB_BKP"] = Comp_license;
            //Comp_Name = s1[1].ToString();
        }
        load_database_name();
    }

    private void load_database_name()
    {
        if (ddlClient_name.SelectedItem.Text != string.Empty)
        {
            string[] s1 = ddlClient_name.SelectedItem.Text.Split(new string[] { "-" }, StringSplitOptions.None);
            Comp_license = s1[0].ToString();
                       

            DataSet ds_db = new DataSet();
            SS.flag = "All_DataBase_details";
            SS.Working_Period = ddl_WorkingPeriod.SelectedItem.Text;
            SS.Select_Item = Comp_license;

            ds_db = SS.All_DB_Backup_Select();

            //ddldatabase.DataTextField = ds.Tables[0].Columns["DATABASE_NAME"].ToString();
            //ddldatabase.DataValueField = ds.Tables[0].Columns["WORKING_PERIOD"].ToString();

            //ddldatabase.DataSource = ds.Tables[0];
            //ddldatabase.DataBind();

            if (ds_db.Tables[0].Rows.Count > 0)
            {
                //Hdservername.Value = ds.Tables[0].Columns["SERVER_NAME"].ToString();
                Session["Client_Server"] = ds_db.Tables[0].Rows[0]["SERVER_NAME"].ToString(); ;
            }
            else
            {
                Session["Client_Server"] = "";
            }

            /*
            ddldatabase.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddldatabase.SelectedIndex = 0;
            */
                     

        }
        
    }
    protected void ddl_WorkingPeriod_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_database_name();
    }
}