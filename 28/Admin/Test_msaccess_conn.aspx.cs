using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;

public partial class Admin_Test : System.Web.UI.Page
{
    OleDbCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {

        OleDbConnection connExport = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+Server.MapPath("~/Submission/IMPORT.mdb")+";User Id=admin;Password=;");
        
        //cmd = new OleDbCommand("select * from COUNTRY_MASTER");
        //cmd.Connection = connExport;

        //OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        //DataSet d = new DataSet();
        //da.Fill(d);
        //GridView1.DataSource = d;
        //GridView1.DataBind();
        connExport.Open();
        cmd = new OleDbCommand("insert into COUNTRY_MASTER (Country_CD,Country_Name) values('vv','fff')");
        cmd.Connection = connExport;
        cmd.ExecuteNonQuery();
        cmd.Connection = connExport;
        cmd.CommandText = "select * from COUNTRY_MASTER";

        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        DataSet d = new DataSet();
        da.Fill(d);
        GridView1.DataSource = d;
        GridView1.DataBind();
    }
}