using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class INDEV_NISSAN_EXP_PART_LEVEL_DATA_Rpt : ThemeClass
{
    AppSession aps = new AppSession();
    EXP_INDEV_NISSAN_RPT EIN = new EXP_INDEV_NISSAN_RPT();

    DataSet ds = new DataSet();
    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        HDBranch.Value = Connection.Get_Company_Type(); 

        if (!IsPostBack)
        {
            load_Exp_Name();
            Load_Month();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Load_Grid();
    }
    private void Load_Month()
    {
        ds = Common_CS.Load_Month();
        ddlmonth.DataSource = ds.Tables[0];
        ddlmonth.DataTextField = "TheMonth";
        ddlmonth.DataValueField = "TheMonth_No";
        ddlmonth.DataBind();

        ddlmonth.Items.Insert(ddlmonth.Items.Count, new ListItem(String.Empty, String.Empty));
        ddlmonth.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
    }
    private void load_Exp_Name()
    {
        ddl_Exp_name.Items.Clear();
        ddl_Jobno.Items.Clear();
        
        EIN.Flag = "Select_Exporter_Name";
        ds = EIN.EXP_Select();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl_Exp_name.DataSource = ds.Tables[0];
            ddl_Exp_name.DataTextField = "EXPORTER_NAME";
            ddl_Exp_name.DataValueField = "EXPORTER_NAME";
            ddl_Exp_name.DataBind();
        }

        if (ds.Tables[1].Rows.Count > 0)
        {
            ddl_Jobno.DataSource = ds.Tables[1];
            ddl_Jobno.DataTextField = "JOBNO";
            ddl_Jobno.DataValueField = "JOBNO";
            ddl_Jobno.DataBind();
        }
        ddl_Exp_name.Items.Insert(0, new ListItem(string.Empty, string.Empty));
        ddl_Exp_name.SelectedIndex = 0;
        ddl_Jobno.Items.Insert(0, new ListItem(string.Empty, string.Empty));
        ddl_Jobno.SelectedIndex = 0;
    }
     private void Load_Grid()
     {
       if (txtfromdate.Text != string.Empty || txttodate.Text != string.Empty)
         {
             EIN.From_date = txtfromdate.Text;
             EIN.To_date = txttodate.Text;
         }
         else
         {
             if (ddlmonth.SelectedItem.Text != string.Empty)
             {
                 arr_Month = ddlmonth.SelectedValue.ToString().Split('-');
                 EIN.From_date = arr_Month[0];
                 EIN.To_date = arr_Month[1];
             }
             else
             {
                 EIN.From_date = txtfromdate.Text;
                 EIN.To_date = txttodate.Text;
             }
         }

           EIN.Exp_Name = ddl_Exp_name.SelectedValue.ToString();
           EIN.Jobno = ddl_Jobno.SelectedValue.ToString();
           ds = EIN.EXP_PART_LEVEL_DATA_Select();
             if (ds.Tables[0].Rows.Count > 0)
             {
                 gvdetails.DataSource = ds;
                 gvdetails.DataBind();
             }
             else
             {
                 Grid_Empty();
             }
     }
     private void Grid_Empty()
     {
         DataTable dt = new DataTable();
         gvdetails.DataSource = dt;
         gvdetails.DataBind();
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
    protected void gvdetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvdetails.PageIndex = e.NewPageIndex;
        Load_Grid();
    }
    protected void ddl_Exp_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_Jobno();
    }
    private void Load_Jobno()
    {
        ddl_Jobno.Items.Clear();
        EIN.Exp_Name = ddl_Exp_name.SelectedValue.ToString();
        EIN.Flag = "Select_Exporter_Jobno";
        ds = EIN.EXP_Select();

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl_Jobno.DataSource = ds.Tables[0];
            ddl_Jobno.DataTextField = "JOBNO";
            ddl_Jobno.DataValueField = "JOBNO";
            ddl_Jobno.DataBind();
        }

        ddl_Jobno.Items.Insert(0, new ListItem(string.Empty, string.Empty));
        ddl_Jobno.SelectedIndex = 0;
    }
    protected void ddl_Jobno_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_Jobno.SelectedValue.ToString() != string.Empty)
        {
            Load_Exp_Name();
        }
    }
    private void Load_Exp_Name()
    {
        EIN.Jobno = ddl_Jobno.SelectedValue.ToString();
        EIN.Flag = "Select_Job_Exporter";
        ds = EIN.EXP_Select();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl_Exp_name.SelectedValue = ds.Tables[0].Rows[0][0].ToString();
        }
        
    }
}