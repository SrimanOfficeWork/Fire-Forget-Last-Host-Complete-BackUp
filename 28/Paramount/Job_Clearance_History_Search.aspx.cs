using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;

public partial class Job_Clearance_History_Search : ThemeClass
{
    AppSession aps = new AppSession();
    Paramount_Exp_Job_Clearance PEJC = new Paramount_Exp_Job_Clearance();

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, Name_Search;
    public string SELECT_TYPE, SELECT_BRANCH;

    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };

    string Start_date = string.Empty;
    string End_date = string.Empty;

    string From_month = string.Empty;
    string To_month = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        if (Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = Session["SELECT_TYPE"].ToString();

            if (SELECT_TYPE == "Branchwise Job")
            {
                SELECT_BRANCH = currentbranch;
                HDBranch.Value = SELECT_BRANCH;
            }
            else
            {
                SELECT_BRANCH = "";
                HDBranch.Value = SELECT_BRANCH;
            }
        }
        else
        {
            SELECT_BRANCH = "";
            HDBranch.Value = SELECT_BRANCH;
        }

        if (!IsPostBack)
        {
            Load_Month();
            Load_Shippername();
        }
    }

    private void Load_Month()
    {
        DataSet ds = new DataSet();
        arr = Working_Period.Split('-');
        Start_date = arr[0] + '-' + arr[1] + '-' + arr[2];
        End_date = arr[3] + '-' + arr[4] + '-' + arr[5];

        PEJC.From_date = Start_date;
        PEJC.To_date = End_date;
        PEJC.Flag = "Month";

        ds = PEJC.Select_Month();

        ddlmonth.DataSource = ds.Tables[0];
        ddlmonth.DataTextField = "TheMonth";
        ddlmonth.DataValueField = "TheMonth_No";
        ddlmonth.DataBind();

        ddlmonth.Items.Insert(ddlmonth.Items.Count, new ListItem(String.Empty, String.Empty));
        ddlmonth.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
    }

    private void Load_Shippername()
    {
        PEJC.Branch_Common = SELECT_BRANCH;
        PEJC.Flag = "Select_ShipperName";
        PEJC.Mode = "";
        ddlExp_name.DataSource = PEJC.Item_Select();
        ddlExp_name.DataTextField = "Exporter_Name";
        ddlExp_name.DataValueField = "Exporter_Name";
        ddlExp_name.DataBind();
        ddlExp_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlExp_name.SelectedIndex = 0;

        ddlreportname.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlreportname.SelectedIndex = 0;
    
    }
    protected void ddlExp_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlreportname.Items.Clear();
        PEJC.Exp_name = ddlExp_name.SelectedItem.Text;
        PEJC.Branch_Common = SELECT_BRANCH;
        PEJC.Flag = "Select_Ref_name";

        ddlreportname.DataSource = PEJC.Item_Select();
        ddlreportname.DataTextField = "REF_NAME";
        ddlreportname.DataValueField = "REF_NAME";
        ddlreportname.DataBind();
        ddlreportname.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlreportname.SelectedIndex = 0;
    }
    protected void ddlreportname_SelectedIndexChanged(object sender, EventArgs e)
    {
        Grid_load();
    }
    private void Grid_load()
    {
        if (txtfromdate.Text != string.Empty || txttodate.Text != string.Empty)
        {
            PEJC.from_date = txtfromdate.Text;
            PEJC.todate = txttodate.Text;
        }
        else
        {
            if (ddlmonth.SelectedItem.Text != string.Empty)
            {
                arr_Month = ddlmonth.SelectedValue.ToString().Split('-');
                PEJC.from_date = arr_Month[0];
                PEJC.todate = arr_Month[1];
            }
            else
            {
                PEJC.from_date = txtfromdate.Text;
                PEJC.todate = txttodate.Text;
            }
        }

        PEJC.Jobno = txtjobno.Text;
        PEJC.Exp_name = ddlExp_name.SelectedItem.Text;
        PEJC.REF_NAME = ddlreportname.SelectedIndex > 0 ? ddlreportname.SelectedItem.Text : ""; 
        PEJC.Branch_Common = SELECT_BRANCH;
        PEJC.Flag = "Grid_Data";

        gvdetails.DataSource = PEJC.Job_History_Search();
        gvdetails.DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Grid_load();
    }
    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //Add CSS class on header row.
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
       
        //Add CSS class on normal row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        //Add CSS class on alternate row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
     protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
     {

         if (e.Row.RowType == DataControlRowType.DataRow)
         {
             string values = this.gvdetails.DataKeys[e.Row.RowIndex]["SL_NO"].ToString();
             e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
             e.Row.Attributes.Add("ondblclick", "open_paramount_job_clearance_History_Update('" + values + "')");

            e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
            e.Row.Attributes.Add("onclick", "Get_Row_ID('" + values + "')");
         }
     }

   
   
}