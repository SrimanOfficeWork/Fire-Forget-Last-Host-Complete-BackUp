using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

using System.IO;

public partial class Database_BK : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //E:\Balaji\Copy (2) of eRoyalimpex\Submission\
        //string path = "E:/Balaji/Copy (2) of eRoyalimpex/Submission/";
        string path = Server.MapPath("~/Submission/");
        // string Filename = TextBox1.Text + "_" + System.DateTime.Now.ToShortDateString();
        string year = string.Format("{0:dd-MM-yyyy}", System.DateTime.Now);
        string comp_ConnectionStr = Session["currentcomp_db"].ToString();
        string database_name;
        string[] res = comp_ConnectionStr.Split(';');
        database_name = res[1];
        res = database_name.Split('=');
        database_name = res[1];


        string Filename = database_name+"_" + year;


        adminmaster adm = new adminmaster();
        adm.databasename = database_name;
        adm.path = path;
        adm.filename = Filename;
        adm.RetrieveAll_DB_master(comp_ConnectionStr);


        if (adm.result1 == "Database successfully backed up!")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('" + adm.result1 + "')</script>", false);

            System.IO.FileInfo file = new System.IO.FileInfo(path + Filename);
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
            Response.AddHeader("Content-Length", file.Length.ToString());
            Response.ContentType = "application/octet-stream";
            Response.WriteFile(file.FullName);
            Response.End();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Database backed up Failed')</script>", false);
           // Response.Redirect("E_royal_Impex_Home.aspx");
        }
        Response.Redirect("E_royal_Impex_Home.aspx");
    }
   
}