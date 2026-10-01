using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class INDEV_NISSAN_Imp_MonthWise_chk_Rpt : ThemeClass
{
    AppSession aps = new AppSession();

    DataSet ds = new DataSet();
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, Name_Search;
    public string SELECT_TYPE, SELECT_BRANCH;

    IMP_Item_Rpt IIR = new IMP_Item_Rpt();

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
                HDBranch.Value = currentbranch;
            }
            else
            {
                SELECT_BRANCH = "";
                HDBranch.Value = "";
            }
        }
        else
        {
            SELECT_BRANCH = "";
            HDBranch.Value = "";
        }

       
        if (!IsPostBack)
        {
            DSR_monthly_jobo.Value = string.Empty;
            load_Imp_Name();
            Load_Month();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Load_Grid();
    }

    private void Load_Month()
    {
        Billing_Imp_Invoice BI = new Billing_Imp_Invoice();
        DataSet ds = new DataSet();
        arr = Working_Period.Split('-');
        Start_date = arr[0] + '-' + arr[1] + '-' + arr[2];
        End_date = arr[3] + '-' + arr[4] + '-' + arr[5];

        BI.from_date = Start_date;
        BI.todate = End_date;
        BI.Flag = "Month";

        ds = BI.IMP_EXP_Month();

        ddlmonth.DataSource = ds.Tables[0];
        ddlmonth.DataTextField = "TheMonth";
        ddlmonth.DataValueField = "TheMonth_No";
        ddlmonth.DataBind();

        ddlmonth.Items.Insert(ddlmonth.Items.Count, new ListItem(String.Empty, String.Empty));
        ddlmonth.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
    }

    private void load_Imp_Name()
    {
        DataSet ds = new DataSet();
        IIR.Flag = "Importer_Name_Select";
        IIR.Branch_Type = SELECT_BRANCH;
        ds = IIR.IMP_Select();

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl_Imp_name.DataSource = ds.Tables[0];
            ddl_Imp_name.DataTextField = "IMPORTER_NAME";
            ddl_Imp_name.DataValueField = "IMPORTER_NAME";
            ddl_Imp_name.DataBind();

            ddl_Imp_name.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddl_Imp_name.SelectedIndex = 0;
        }
        else
        {
            ddl_Imp_name.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddl_Imp_name.SelectedIndex = 0;
        }
    }
    
     
    private void load_Jobno( string a, string b)
    {
        DataSet ds = new DataSet();
        IIR.Flag = a;
        IIR.Jobno= b;
        IIR.Branch_Type = SELECT_BRANCH;
        ds = IIR.IMP_Select();
        if (ds.Tables[0].Rows.Count > 0)
        {
            cbList.DataSource = ds.Tables[0];
            cbList.DataTextField = "JOBNO";
            cbList.DataValueField = "JOBNO";
            cbList.DataBind();
        }
        else
        {
           
        }
    }
  
    
     private void Load_Grid()
     {
           
             string values = "";
             foreach (ListItem objItem in cbList.Items)
             {
                 if (objItem.Selected)
                 {
                     values += objItem.Value + ",";
                 }
             }

             if (values != string.Empty)
             {
                 DSR_monthly_jobo.Value = values;
                 IIR.Imp_Name = values;
                 IIR.Branch_Type = SELECT_BRANCH;
                 ds = IIR.IMP_Month_Wise_Select();

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
             else
             {
                 DSR_monthly_jobo.Value = values;
                 Grid_Empty();
                 ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('Select a Jobno');", true);
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
       
    }
   

    protected void btnload_jobno_Click(object sender, EventArgs e)
    {
        if (ddl_Imp_name.SelectedItem.Text == string.Empty && txtfromdate.Text ==string.Empty && txttodate.Text ==string.Empty && ddlmonth.SelectedItem.Text ==string.Empty)
        { 
             //arr_Month = ddlmonth.SelectedValue.ToString().Split('-');
            IIR.From_date = string.Empty;
            IIR.To_date = string.Empty;
            IIR.Jobno =string.Empty;
        }
        else if (ddl_Imp_name.SelectedItem.Text == string.Empty && txtfromdate.Text != string.Empty && txttodate.Text == string.Empty && ddlmonth.SelectedItem.Text == string.Empty)
        {
            IIR.From_date = txtfromdate.Text;
            IIR.To_date = string.Empty;
            IIR.Jobno = string.Empty;
        }
        else if (ddl_Imp_name.SelectedItem.Text == string.Empty && txtfromdate.Text == string.Empty && txttodate.Text != string.Empty && ddlmonth.SelectedItem.Text == string.Empty)
        {
            IIR.From_date =string.Empty;
            IIR.To_date = txttodate.Text;
            IIR.Jobno = string.Empty;
        }
        else if (ddl_Imp_name.SelectedItem.Text == string.Empty && txtfromdate.Text != string.Empty && txttodate.Text != string.Empty && ddlmonth.SelectedItem.Text == string.Empty)
        {
            IIR.From_date = txtfromdate.Text;
            IIR.To_date = txttodate.Text;
            IIR.Jobno = string.Empty;
        }
        else if (ddl_Imp_name.SelectedItem.Text != string.Empty && txtfromdate.Text != string.Empty && txttodate.Text == string.Empty && ddlmonth.SelectedItem.Text == string.Empty)
        {
            IIR.From_date = txtfromdate.Text;
            IIR.To_date = string.Empty;
            IIR.Jobno = ddl_Imp_name.SelectedItem.Text;
        }
        else if (ddl_Imp_name.SelectedItem.Text != string.Empty && txtfromdate.Text == string.Empty && txttodate.Text == string.Empty && ddlmonth.SelectedItem.Text == string.Empty)
        {
            IIR.From_date = string.Empty;
            IIR.To_date = string.Empty;
            IIR.Jobno = ddl_Imp_name.SelectedItem.Text;
        }
        else if (ddl_Imp_name.SelectedItem.Text != string.Empty && txtfromdate.Text != string.Empty && txttodate.Text != string.Empty && ddlmonth.SelectedItem.Text == string.Empty)
        {
            IIR.From_date = txtfromdate.Text;
            IIR.To_date = txttodate.Text;
            IIR.Jobno = ddl_Imp_name.SelectedItem.Text;
        }
        else if (ddl_Imp_name.SelectedItem.Text == string.Empty && txtfromdate.Text == string.Empty && txttodate.Text == string.Empty && ddlmonth.SelectedItem.Text != string.Empty)
        {
            arr_Month = ddlmonth.SelectedValue.ToString().Split('-');
            IIR.From_date = arr_Month[0]; ;
            IIR.To_date = arr_Month[1];
            IIR.Jobno = string.Empty;
        }
        else if (ddl_Imp_name.SelectedItem.Text != string.Empty && txtfromdate.Text == string.Empty && txttodate.Text == string.Empty && ddlmonth.SelectedItem.Text != string.Empty)
        {
            arr_Month = ddlmonth.SelectedValue.ToString().Split('-');
            IIR.From_date = arr_Month[0]; 
            IIR.To_date = arr_Month[1];
            IIR.Jobno = ddl_Imp_name.SelectedItem.Text;
        }
        else if (ddl_Imp_name.SelectedItem.Text != string.Empty && txtfromdate.Text != string.Empty && txttodate.Text == string.Empty && ddlmonth.SelectedItem.Text != string.Empty)
        {
            IIR.From_date = txtfromdate.Text;
            IIR.To_date = string.Empty;
            IIR.Jobno = ddl_Imp_name.SelectedItem.Text;
        }
        else if (ddl_Imp_name.SelectedItem.Text != string.Empty && txtfromdate.Text == string.Empty && txttodate.Text != string.Empty && ddlmonth.SelectedItem.Text != string.Empty)
        {
            IIR.From_date = string.Empty;
            IIR.To_date = txttodate.Text;
            IIR.Jobno = ddl_Imp_name.SelectedItem.Text;
        }
        else if (ddl_Imp_name.SelectedItem.Text != string.Empty && txtfromdate.Text != string.Empty && txttodate.Text != string.Empty && ddlmonth.SelectedItem.Text != string.Empty)
        {
            IIR.From_date = txtfromdate.Text;
            IIR.To_date = txttodate.Text;
            IIR.Jobno = ddl_Imp_name.SelectedItem.Text;
        }
        else if (ddl_Imp_name.SelectedItem.Text == string.Empty && txtfromdate.Text != string.Empty && txttodate.Text != string.Empty && ddlmonth.SelectedItem.Text != string.Empty)
        {
            IIR.From_date = txtfromdate.Text;
            IIR.To_date = txttodate.Text;
            IIR.Jobno = string.Empty;
        }
        else if (ddl_Imp_name.SelectedItem.Text == string.Empty && txtfromdate.Text == string.Empty && txttodate.Text != string.Empty && ddlmonth.SelectedItem.Text != string.Empty)
        {
            IIR.From_date = string.Empty;
            IIR.To_date = txttodate.Text;
            IIR.Jobno = string.Empty;
        }
        else if (ddl_Imp_name.SelectedItem.Text == string.Empty && txtfromdate.Text != string.Empty && txttodate.Text == string.Empty && ddlmonth.SelectedItem.Text != string.Empty)
        {
            IIR.From_date = txtfromdate.Text;
            IIR.To_date = string.Empty;
            IIR.Jobno = string.Empty;
        }

        IIR.Branch_Type = SELECT_BRANCH;
        IIR.Flag ="Select_Monthly_DSR_Jobno" ;
        ds = IIR.IMP_Select();
        if (ds.Tables[0].Rows.Count > 0)
        {
            cbList.DataSource = ds.Tables[0];
            cbList.DataTextField = "JOBNO";
            cbList.DataValueField = "JOBNO";
            cbList.DataBind();
        }
        else
        {
            cbAll.Checked = false;
            cbList.Items.Clear();
            cbList.DataSource = null;
            cbList.DataBind();
        }
    }
    
    protected void gvdetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvdetails.PageIndex = e.NewPageIndex;
        Load_Grid();
    }
}