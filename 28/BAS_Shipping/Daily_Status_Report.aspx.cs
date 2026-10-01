using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using GeneraReport;
using Microsoft.Reporting.WebForms;

public partial class Daily_Status_Report : ThemeClass
{
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string Company_ID;
    public string SELECT_TYPE, SELECT_BRANCH;

    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };

    string Start_date = string.Empty;
    string End_date = string.Empty;

    string From_month = string.Empty;
    string To_month = string.Empty;

    AppSession aps = new AppSession();

    BAS_IMP_DSR BID = new BAS_IMP_DSR(); 
   
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
            Load_Tr_Mode();
            load_Jobno();
        }
    }

    private void Load_Tr_Mode()
    {
        // ddlmode 
        if (Session["CUSTOMHOUSE_TRANSPORT_MODE"].ToString() == "A")
        {
            ddlmode.Items.Insert(0, new ListItem("Air", "Air"));
            ddlmode.SelectedIndex = 0;
        }
        else if (Session["CUSTOMHOUSE_TRANSPORT_MODE"].ToString() == "S")
        {
            ddlmode.Items.Insert(0, new ListItem("Sea", "Sea"));
            ddlmode.SelectedIndex = 0;
        }
        else if (Session["CUSTOMHOUSE_TRANSPORT_MODE"].ToString() == "L")
        {
            ddlmode.Items.Insert(0, new ListItem("Land", "Land"));
            ddlmode.SelectedIndex = 0;
        }
    }
    private void load_Jobno()
    {
        ddl_Imp_name.Items.Clear();
        DataSet ds =new DataSet();
       BID.Imp_name="";
       BID.Mode = ddlmode.SelectedItem.Text;
       BID.from_date = "";
       BID.todate = "";

       BID.Branch_Code = SELECT_BRANCH;
       BID.Flag = "DSR_Jobno_Imp_name";

       ds = BID.BAS_IMP_DAILY_STATUS_RPT();

       if (ds.Tables[0].Rows.Count > 0)
       {
           ddljobno.DataSource = ds.Tables[0];
           ddljobno.DataTextField = "JOBNO_PS";
           ddljobno.DataValueField = "JOBNO";
           ddljobno.DataBind();
           ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
           ddljobno.SelectedIndex = 0;
       }
       else
        {
            ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddljobno.SelectedIndex = 0;
        }
       if (ds.Tables[1].Rows.Count > 0)
       {

           ddl_Imp_name.DataSource = ds.Tables[1];
           ddl_Imp_name.DataTextField = "Imp_Name";
           ddl_Imp_name.DataValueField = "Imp_Name";
           ddl_Imp_name.DataBind();
       }
        else
        {
           
            ddl_Imp_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddl_Imp_name.SelectedIndex = 0;
        }
    }

    private void Load_Grid()
    {
        try
        {
            DataSet ds1 = new DataSet();
            if (txtfromdate.Text != string.Empty || txttodate.Text != string.Empty)
            {
                BID.from_date = txtfromdate.Text;
                BID.todate = txttodate.Text;
            }
            else
            {
                if (ddlmonth.SelectedItem.Text != string.Empty)
                {
                    arr_Month = ddlmonth.SelectedValue.ToString().Split('-');
                    BID.from_date = arr_Month[0];
                    BID.todate = arr_Month[1];
                }
                else
                {
                    BID.from_date = txtfromdate.Text;
                    BID.todate = txttodate.Text;
                }
            }

            BID.Jobno = ddljobno.SelectedValue.ToString();
            BID.Imp_name = ddl_Imp_name.SelectedItem.Text;
            BID.Mode = ddlmode.SelectedItem.Text;
            BID.Branch_Code = SELECT_BRANCH;
            BID.Flag = "DSR_Search_Data";
            ds1 = BID.BAS_IMP_DAILY_STATUS_RPT();
            if (ds1.Tables[0].Rows.Count > 0)
            {
                gvdetails.DataSource = ds1.Tables[0];
                gvdetails.DataBind();
            }
            else
            {
                gvdetails.DataSource = null;
                gvdetails.DataBind();
            }
        }
        catch (Exception ex)
        { 
        
        }
    }
    private void Load_Month()
    {
       
        DataSet ds2 = new DataSet();
        arr = Working_Period.Split('-');
        Start_date = arr[0] + '-' + arr[1] + '-' + arr[2];
        End_date = arr[3] + '-' + arr[4] + '-' + arr[5];

        BID.from_date = Start_date;
        BID.todate = End_date;
        BID.Flag = "Month";
        ds2 = BID.Select_Month();

        ddlmonth.DataSource = ds2.Tables[0];
        ddlmonth.DataTextField = "TheMonth";
        ddlmonth.DataValueField = "TheMonth_No";
        ddlmonth.DataBind();

        ddlmonth.Items.Insert(ddlmonth.Items.Count, new ListItem(String.Empty, String.Empty));
        ddlmonth.SelectedValue = ds2.Tables[1].Rows[0][0].ToString();
    }
   
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Load_Grid();
    }

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    { 
    
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
}
