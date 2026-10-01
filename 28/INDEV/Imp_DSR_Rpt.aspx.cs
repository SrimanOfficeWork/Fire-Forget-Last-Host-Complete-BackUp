using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
public partial class Imp_DSR_Rpt : ThemeClass
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

    

    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };

    string Start_date = string.Empty;
    string End_date = string.Empty;

    string From_month = string.Empty;
    string To_month = string.Empty;

    IMP_INDEV_DSR_Entry IDSR = new IMP_INDEV_DSR_Entry();

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
            Load_Month();
            load_Jobno();
            btnSearch_Click(sender, e);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Load_Grid();
    }
    private void Load_Month()
    {
        Billing_Imp_Invoice BE = new Billing_Imp_Invoice();
        DataSet ds = new DataSet();
        arr = Working_Period.Split('-');
        Start_date = arr[0] + '-' + arr[1] + '-' + arr[2];
        End_date = arr[3] + '-' + arr[4] + '-' + arr[5];

        BE.from_date = Start_date;
        BE.todate = End_date;
        BE.Flag = "Month";
        ds = BE.IMP_EXP_Month();

        ddlmonth.DataSource = ds.Tables[0];
        ddlmonth.DataTextField = "TheMonth";
        ddlmonth.DataValueField = "TheMonth_No";
        ddlmonth.DataBind();

        ddlmonth.Items.Insert(ddlmonth.Items.Count, new ListItem(String.Empty, String.Empty));
        ddlmonth.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
    }
    private void load_Jobno()
    {
        IMP_Item_Rpt IIR = new IMP_Item_Rpt();
        DataSet ds = new DataSet();
        IIR.Flag = "Select_DSR";
        IIR.Branch_Type = SELECT_BRANCH;
        ds = IIR.IMP_Select();

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddljobno.DataSource = ds.Tables[0];
            ddljobno.DataTextField = "JOBNO";
            ddljobno.DataValueField = "JOBNO";
            ddljobno.DataBind();

            ddljobno.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddljobno.SelectedIndex = 0;
        }
        else
        {
            ddljobno.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddljobno.SelectedIndex = 0;
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
    protected void ddljobno_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    private void Load_Grid()
    {
        DataSet ds1 = new DataSet();
        if (txtfromdate.Text != string.Empty || txttodate.Text != string.Empty)
        {
            IDSR.from_date = txtfromdate.Text;
            IDSR.todate = txttodate.Text;
        }
        else
        {
            if (ddlmonth.SelectedItem.Text != string.Empty)
            {
                arr_Month = ddlmonth.SelectedValue.ToString().Split('-');
                IDSR.from_date = arr_Month[0];
                IDSR.todate = arr_Month[1];
            }
            else
            {
                IDSR.from_date = txtfromdate.Text;
                IDSR.todate = txttodate.Text;
            }
        }

            IDSR.JobType = ddljobtype.SelectedValue.ToString();
            IDSR.JOBNO=ddljobno.SelectedValue.ToString();
            IDSR.BRANCH_CODE=SELECT_BRANCH;
            ds1 = IDSR.IMP_Master_Search();
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
}