<%@ WebHandler Language="C#" Class="AutoCompleteHandler" %>

using System;

using System.Web;

using System.Data.SqlClient;

using System.Data;

public class AutoCompleteHandler : IHttpHandler
{

    public string[] items;
    public void ProcessRequest(HttpContext context)
    {
        string strData = string.Empty;
        string s = string.Empty;
        if (context.Request.QueryString["q"] != null)
        {
            string q = context.Request.QueryString["q"].Trim();
            string limit = context.Request.QueryString["limit"];
            string sql = "select top 10 STATE_NAME from STATE_MASTER where STATE_NAME like '" + q + "%'";

            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            // items = new string[dt.Rows.Count];
            items = new string[dt.Rows.Count == 0 ? 1 : dt.Rows.Count];
            int i = 0;
            if (dt.Rows.Count == 0)
            {
                items.SetValue("No Match Found", i);
                context.Response.ContentType = "text/plain";
                context.Response.Write(Environment.NewLine);
                context.Response.Write(items[i].ToString());
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    items.SetValue(dr["FirstName"].ToString(), i);
                    context.Response.ContentType = "text/plain";
                    context.Response.Write(Environment.NewLine);
                    context.Response.Write(items[i].ToString());
                    i++;
                }
            }
        }

    }
   

    public bool IsReusable
    {

        get
        {

            return false;

        }

    }

}
