using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Imp_Job_Clearance_Search : ThemeClass
{
    AppSession aps = new AppSession();
    IMP_Job_Clearance IJC = new IMP_Job_Clearance();

    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };

    string Start_date = string.Empty
          ,End_date = string.Empty
          ,From_month = string.Empty
          ,To_month = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        if (!IsPostBack)
        {
            load_Imp_Name();
            Load_Month();
            btnSearch_Click(sender, e);
        }
    }
    
    private void load_Imp_Name()
    {
        DataSet ds = new DataSet();
       //IJC.Flag = "Select_Grid_Jobno";
        IJC.Flag = "Job_Clearnced_Imp_Name";
        ds = IJC.IMP_Job_Clearance_select();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlImp_name.DataSource = ds.Tables[0];
            ddlImp_name.DataTextField = "IMPORTER_NAME";
            ddlImp_name.DataValueField = "IMPORTER_NAME";
            ddlImp_name.DataBind();
            ddlImp_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlImp_name.SelectedIndex = 0;
        }
        else
        {
            ddlImp_name.Items.Clear();
            ddlImp_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlImp_name.SelectedIndex = 0;
        }
    }
     
    private void Load_Month()
    {
        DataSet ds = new DataSet();
        arr = Connection.WorkingPeriod().Split('-');
        Start_date = arr[0] + '-' + arr[1] + '-' + arr[2];
        End_date = arr[3] + '-' + arr[4] + '-' + arr[5];

        IJC.From_date = Start_date;
        IJC.To_date = End_date;
        IJC.Flag = "Month";

        ds = IJC.Select_Month();

        ddlmonth.DataSource = ds.Tables[0];
        ddlmonth.DataTextField = "TheMonth";
        ddlmonth.DataValueField = "TheMonth_No";
        ddlmonth.DataBind();

        ddlmonth.Items.Insert(ddlmonth.Items.Count, new ListItem(String.Empty, String.Empty));
        ddlmonth.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Load_Grid();
    }
    private void Load_Grid()
    {
        DataSet ds1 = new DataSet();
        if (txtfromdate.Text != string.Empty || txttodate.Text != string.Empty)
        {
            IJC.From_date = txtfromdate.Text;
            IJC.To_date = txttodate.Text;
        }
        else
        {
            if (ddlmonth.SelectedItem.Text != string.Empty)
            {
                arr_Month = ddlmonth.SelectedValue.ToString().Split('-');
                IJC.From_date = arr_Month[0];
                IJC.To_date = arr_Month[1];
            }
            else
            {
                IJC.From_date = txtfromdate.Text;
                IJC.To_date = txttodate.Text;
            }
        }
        IJC.Imp_Name = ddlImp_name.SelectedValue.ToString();
        IJC.Jobno = txtjobno.Text;
        IJC.Flag = "Grid";
        ds1 = IJC.IMP_Job_Clearance_SEARCH();

        gvdetails.DataSource = ds1.Tables[0];
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

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string jobno = string.Empty;
        string rowID = String.Empty;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string values = this.gvdetails.DataKeys[e.Row.RowIndex]["Jobno"].ToString();

            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("ondblclick", "open_Imp_Job_Clearance_Search_Update('" + values + "')");
            
            rowID = e.Row.RowIndex.ToString();
            e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
            e.Row.Attributes.Add("onclick", "Get_Row_ID('" + values + "')");
        }

    }

}