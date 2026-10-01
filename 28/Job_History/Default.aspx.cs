using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();

        //add columns to datatable

        dt.Columns.Add("StudentID");

        dt.Columns.Add("StudentName");

        //create new row and add rows to datatable

        DataRow dr;//= dt.NewRow();

       
        for(int i=0;i<=100;i++)
        {
            dr = dt.NewRow();
            dr["StudentId"] = "";

            dr["StudentName"] = "";

            dt.Rows.Add(dr);
        }
        
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
}