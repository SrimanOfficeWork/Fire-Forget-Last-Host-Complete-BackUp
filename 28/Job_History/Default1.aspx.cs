using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;

public partial class Job_Histry_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       //string d= "=server\sqlexpress;database=ImpexLogin;uid=sa;pwd=sa,123;";
        SqlConnection con;
        SqlCommand  cmd;
        SqlDataAdapter da;
        DataSet ds=new DataSet();
        con=new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);
        con.Open();
        cmd=new SqlCommand("select * from EXCHANGE_MASTER",con);
        da=new SqlDataAdapter(cmd);
        da.Fill(ds);
        gvdetails.DataSource=ds;
        gvdetails.DataBind();
    }

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox headerchk = (CheckBox)gvdetails.HeaderRow.FindControl("chkheader");
            CheckBox childchk = (CheckBox)e.Row.FindControl("chkchild");
            childchk.Attributes.Add("onclick", "javascript:Selectchildcheckboxes('" + headerchk.ClientID + "')");
        }
    }
}