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


public partial class Cus_DSR_Exp_Job_Search : ThemeClass
{
    AppSession aps = new AppSession();

    Global_variables GV = new Global_variables();
    DSR_EXP_CS DR = new DSR_EXP_CS();

    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };

    string Start_date = string.Empty , End_date = string.Empty, From_month = string.Empty, To_month = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        
        hdrowindex.Value = String.Empty;
        hdBill_invno.Value = String.Empty;

        if (!IsPostBack)
        {
            Load_Wrk_Month();
            load_Exp_name();
            btnSearch_Click(sender, e);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
            Load_Grid();
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
            string values = this.gvdetails.DataKeys[e.Row.RowIndex]["ID"].ToString();
            string JOBNO = this.gvdetails.DataKeys[e.Row.RowIndex]["JOBNO"].ToString();

            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("ondblclick", "Open_CUS_DSR_Exp_Job_Search_Update('" + values + "','" + JOBNO + "')");
          
            rowID = e.Row.RowIndex.ToString();
            e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
            e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + values + "','" + JOBNO + "')");
        }
    }
   
    private void load_Exp_name()
    {
            ddlCus_name.Items.Clear();
            ddl_Jobno.Items.Clear();

            DataSet ds = new DataSet();
            GV.A4 = "EXP_DSR_CUS_Name";
            ds = DR.DSR_Select(GV);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlCus_name.DataSource = ds.Tables[0];
                ddlCus_name.DataTextField = "EXPORTER_NAME";
                ddlCus_name.DataValueField = "EXPORTER_NAME";
                ddlCus_name.DataBind();
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl_Jobno.DataSource = ds.Tables[1];
                ddl_Jobno.DataTextField = "JOBNO_PS";
                ddl_Jobno.DataValueField = "JOBNO";
                ddl_Jobno.DataBind();
            }

            ddlCus_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlCus_name.SelectedIndex = 0;
            ddl_Jobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddl_Jobno.SelectedIndex = 0;

           if (ds.Tables[2].Rows.Count > 0)
            {
               btn_New_Entry.Visible = true;
            }
           else
           {
               btn_New_Entry.Visible = false;
           }
    }
    protected void ddlbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_Exp_name();
    }
    protected void ddlImp_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnSearch_Click(sender, e);
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

        GV.A3 = ddlCus_name.SelectedValue.ToString();
        GV.A4 = ddl_Jobno.SelectedValue.ToString();
        GV.A5 = "Grid_Search";
        ds1 = DR.CUS_DSR_EXPORT_JOB_SEARCH(GV);
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

   
}