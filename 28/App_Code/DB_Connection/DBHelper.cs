using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using BussinessObject;

/// <summary>
/// Minimal, dependency-free ADO.NET helper. Drop this in App_Code.
/// Connection string key expected in Web.config:
///
///   <connectionStrings>
///     <add name="DSRConnection"
///          connectionString="Data Source=YOUR_SERVER;Initial Catalog=YOUR_DB;
///                             User ID=sa;Password=yourpassword;" />
///   </connectionStrings>
/// </summary>
public static class DBHelper
{
    private static string ConnString
    {
        get { return
            HttpContext.Current.Session["currentcomp_db"].ToString();
            //ConfigurationManager.ConnectionStrings["DSRConnection"].ConnectionString;
        }
    }

    public static DataTable ExecuteQuery(string sql, params SqlParameter[] parameters)
    {
        using (SqlConnection conn = new SqlConnection(ConnString))
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            if (parameters != null) cmd.Parameters.AddRange(parameters);
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }

    public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
    {
        using (SqlConnection conn = new SqlConnection(ConnString))
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            if (parameters != null) cmd.Parameters.AddRange(parameters);
            conn.Open();
            return cmd.ExecuteNonQuery();
        }
    }

    public static object ExecuteScalar(string sql, params SqlParameter[] parameters)
    {
        using (SqlConnection conn = new SqlConnection(ConnString))
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            if (parameters != null) cmd.Parameters.AddRange(parameters);
            conn.Open();
            return cmd.ExecuteScalar();
        }
    }
}
