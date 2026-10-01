using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Cus_DSR_Select_Search : ThemeClass
{
    AppSession aps = new AppSession();

    Global_variables GV = new Global_variables();
    DSR_CS DR = new DSR_CS();

    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };

    string Start_date = string.Empty, End_date = string.Empty, From_month = string.Empty, To_month = string.Empty;


    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        if (!IsPostBack)
        {
            Load_Wrk_Month();
            Load_Report_Name();
            Load_Grid();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Load_Grid();
    }
     private void Load_Grid()
     {
         DataTable dt = new DataTable();

         DataSet ds1 = new DataSet();
         if (txtfromdate.Text != string.Empty || txttodate.Text != string.Empty)
         {
             GV.A1 = txtfromdate.Text;
             GV.A2 = txttodate.Text;
         }
         else
         {
             if (ddlmonth.SelectedItem.Text != string.Empty)
             {
                 arr_Month = ddlmonth.SelectedValue.ToString().Split('-');
                 GV.A1 = arr_Month[0];
                 GV.A2 = arr_Month[1];
             }
             else
             {
                 GV.A1 = txtfromdate.Text;
                 GV.A2 = txttodate.Text;
             }
         }

         GV.A3 = ddl_Report_Name.SelectedValue.ToString();
         GV.A5 = "Grid_Search";
         ds1 = DR.CUS_DSR_IMP_CREATED_REPORT_SEARCH(GV);
         if (ds1.Tables[0].Rows.Count > 0)
         {
             gvdetails.DataSource = ds1.Tables[0];
             gvdetails.DataBind();
         }
         else
         {
             gvdetails.DataSource = dt;
             gvdetails.DataBind();
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

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string jobno = string.Empty;
        string rowID = String.Empty;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string R_ID = this.gvdetails.DataKeys[e.Row.RowIndex]["R_ID"].ToString();
            string REPORT_NAME = this.gvdetails.DataKeys[e.Row.RowIndex]["REPORT_NAME"].ToString();

            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("ondblclick", "open_Cus_DSR_Select_update('" + R_ID + "','" + Server.UrlEncode(REPORT_NAME) + "')");
            
            rowID = e.Row.RowIndex.ToString();
            e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
            e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + R_ID + "','" + REPORT_NAME + "')");
        }
    }
   
    private void Load_Report_Name()
    {
        ds.Clear();
        ddl_Report_Name.Items.Clear();
        GV.A4 = "IMP_DSR_CUS_Report_Names";
        ds = DR.DSR_Select(GV);

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl_Report_Name.DataSource = ds.Tables[0];
            ddl_Report_Name.DataTextField = ds.Tables[0].Columns["REPORT_NAME"].ToString();
            ddl_Report_Name.DataValueField = ds.Tables[0].Columns["REPORT_NAME"].ToString();
            ddl_Report_Name.DataBind();
        }
        ddl_Report_Name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddl_Report_Name.SelectedIndex = 0;
    }
    public void Load_Wrk_Month()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        ds = Common_CS.Load_Month();

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlmonth.DataSource = ds.Tables[0];
            ddlmonth.DataTextField = "TheMonth";
            ddlmonth.DataValueField = "TheMonth_No";
            ddlmonth.DataBind();

            ddlmonth.Items.Insert(ddlmonth.Items.Count, new ListItem(String.Empty, String.Empty));
            ddlmonth.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
        }
    }

    protected void btn_DSR_Entry_Click(object sender, EventArgs e)
    {
        Response.Redirect("Cus_DSR_Imp_Job_Search.aspx", false);
    }
    protected void btn_Rpt_Data_Click(object sender, EventArgs e)
    {
        Response.Redirect("Cus_Import_Dynamic_Report.aspx", false);
    }
}