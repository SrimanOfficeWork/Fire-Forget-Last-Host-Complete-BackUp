using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using Microsoft.SqlServer;




public partial class Query_Updation : ThemeClass
{
    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();

    Admin_Query_Exec AQE = new Admin_Query_Exec();

    SqlCommand cmd;
    SqlConnection con;
    SqlDataAdapter da;
    SqlCommand sqlCmd;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Bulk Query', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void btn_Refresh_Click(object sender, ImageClickEventArgs e)
    {
        Delete();
        Copy();
    }
    private void Delete()
    {
        string file_path = string.Empty;
        file_path = Server.MapPath("~/Query_Data/");
        string[] filePaths = Directory.GetFiles(file_path);
        foreach (string filePath in filePaths)
            File.Delete(filePath);
    }
    private void Copy()
    {
        string file_path_f = string.Empty, targetPath = string.Empty, destFile = string.Empty, fileName = string.Empty;
        file_path_f = Server.MapPath("~/Query_Empty/");
        targetPath = Server.MapPath("~/Query_Data/");
        string[] files = System.IO.Directory.GetFiles(file_path_f);

        foreach (string s in files)
        {
            fileName = System.IO.Path.GetFileName(s);
            destFile = System.IO.Path.Combine(targetPath, fileName);
            System.IO.File.Copy(s, destFile, true);
        }
    }

    protected void btn_Create_Query_Click(object sender, EventArgs e)
    {
        if (txtquery.Text != string.Empty)
        {
            DataSet dss = new DataSet();
            ObjUBO.A1 = ddlCompany_cnt.SelectedValue.ToString();
            ObjUBO.A2 = "Comapny_DB";
            dss = AQE.Live_Company_Select(ObjUBO);

            for (int i = 0; i < dss.Tables.Count; i++)
            {

                if (dss.Tables[i].Rows.Count > 0)
                {
                    string file_path = string.Empty;
                    file_path = Server.MapPath("~/Query_Data/Query_" + i.ToString() + ".sql");
                    StreamWriter sw;
                    sw = new StreamWriter(file_path, true);

                    for (int j = 0; j < dss.Tables[i].Rows.Count; j++)
                    {
                        sw.WriteLine(dss.Tables[i].Rows[j]["DB_NAMES"].ToString());
                        sw.WriteLine(Query());

                        sw.WriteLine("GO");
                    }
                    sw.Close();
                    sw.Dispose();
                }

            }
            //---------------------
        }
        else
        {
            Alert_msg("Check Ur Query !");
        }
    }

    private string Query()
    {
        string Query = string.Empty;
        Query = @""+ txtquery.Text;
        return Query;
    }
    private void Status( string db)
    {
        ObjUBO.A1 = db;
        ObjUBO.A2 = "Sent";
        AQE.Live_Company_Select(ObjUBO);
    }
    public SqlConnection Sql_openConnection(string con)
    {
        SqlConnection conn;
        conn = new SqlConnection(con);
        if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
        {
            conn.Open();
        }
        return conn;
    }
    protected void btn_Auto_Update_Click(object sender, EventArgs e)
    {
        Auto_sql();
    }
    private void Auto_sql()
    {   
        /*
        FileInfo file = new FileInfo(Server.MapPath("~/Query_Auto/Query_50.sql"));
        string script = file.OpenText().ReadToEnd();
        */
        
        string file_path = string.Empty ,File =string.Empty;
        file_path = Server.MapPath("~/Query_Auto/");
        string[] filePaths = Directory.GetFiles(file_path);
        foreach (string filePath in filePaths)
        {
            File = filePath;
        }

        FileInfo file = new FileInfo(File);
        string script = file.OpenText().ReadToEnd();

        try
        {
            //if (txtquery.Text != string.Empty)
            //{
                DataSet dss = new DataSet();
                ObjUBO.A2 = "Con_String";
                dss = AQE.Live_Company_Select(ObjUBO);
                if (dss.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dss.Tables[0].Rows.Count; i++)
                    {
                        using (SqlConnection conn = new SqlConnection(dss.Tables[0].Rows[i][0].ToString()))
                        {
                            conn.Open();
                            SqlCommand sqlCmd = new SqlCommand(script, conn);
                            sqlCmd.ExecuteNonQuery();
                            conn.Close();
                        }
                        Status(dss.Tables[0].Rows[i][1].ToString());
                    }
                }
            //}
        }
        catch (Exception ex)
        {
            Auto_sql();
        }
    }
    protected void btn_Upload_Click(object sender, EventArgs e)
    {
        Auto_Delete();
        if (FileUpLoad1.HasFile)
        {
            FileUpLoad1.SaveAs(Server.MapPath("~/Query_Auto/") + FileUpLoad1.FileName);
            lblmsg.Text = "File Uploaded: " + FileUpLoad1.FileName;
        }
        else
        {
            lblmsg.Text = "No File Uploaded.";
        }  
    }

    private void Auto_Delete()
    {
        string file_path = string.Empty;
        file_path = Server.MapPath("~/Query_Auto/");
        string[] filePaths = Directory.GetFiles(file_path);
        foreach (string filePath in filePaths)
            File.Delete(filePath);
    }
}