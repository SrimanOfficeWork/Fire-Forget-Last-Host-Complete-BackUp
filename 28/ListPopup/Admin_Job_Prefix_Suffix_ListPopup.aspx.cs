using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class Product_Imp_Exp_Master_ListPopup : ThemeClass
{
    AppSession aps = new AppSession();
    DataSet ds = new DataSet();
    private static IEnumerable<DataRow> query;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
       
        if (!IsPostBack)
        {
            gridbind();
        }
    }
    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
        btnSearch_Click(sender, e);
    }
    private void gridbind()
    {
        Admin_job_Prefix_Suffix JPS = new Admin_job_Prefix_Suffix();
        JPS.Ename = "Gridview_Select";
        ds = JPS.Job_prefix_Suffix_Select_Areawise();
        ViewState["ds_data"] = ds.Tables[0];

        gvdetails.DataSource = ds.Tables[0];
        gvdetails.DataBind();

        if (ds.Tables[1].Rows.Count > 0)
        {
            ddl_Branch.DataSource = ds.Tables[1];
            ddl_Branch.DataTextField = "BRANCH_CODE";
            ddl_Branch.DataTextField = "BRANCH_CODE";
            ddl_Branch.DataBind();
        }

        ddl_Branch.Items.Insert(0, "");

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataTable dt_filter = new DataTable();
        dt_filter = (DataTable)ViewState["ds_data"];

      // private static IEnumerable<DataRow> query;

        DataTable dt_output = new DataTable();
        int Row_Count = 0, z = 0;

        if (ddl_Type.SelectedItem.Text != ""  && ddl_Branch.SelectedItem.Text != "")
        {
            query = from t in dt_filter.AsEnumerable()
                    where t.Field<string>("JobType") == ddl_Type.SelectedItem.Text && t.Field<string>("BRANCH_CODE") == ddl_Branch.SelectedItem.Text
                    select t;
        }
        else if (ddl_Type.SelectedItem.Text != "" && ddl_Branch.SelectedItem.Text == "")
        {
            query = from t in dt_filter.AsEnumerable()
                    where t.Field<string>("JobType") == ddl_Type.SelectedItem.Text
                    select t;
        }
        else if (ddl_Type.SelectedItem.Text == "" && ddl_Branch.SelectedItem.Text != "")
        {
            query = from t in dt_filter.AsEnumerable()
                    where t.Field<string>("BRANCH_CODE") == ddl_Branch.SelectedItem.Text
                    select t;
        }
        else
        {
            dt_output = dt_filter;
            z = 1;
        }

        if (z == 0)
        {
            Row_Count = query.Count();
            if (Row_Count > 0)
            {
                dt_output = query.CopyToDataTable();
            }
        }

        gvdetails.DataSource = dt_output;
        gvdetails.DataBind();

    }

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var row = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
          
        }
    }

    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
   
}