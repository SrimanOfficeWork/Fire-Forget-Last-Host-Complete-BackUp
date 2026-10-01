using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using ImapX;
using System.IO;
using System.Collections;

public partial class Docket_Entry_Docket_General_Search : ThemeClass
{

    public int currentPageNumber, pageno, currentPageNumber1;
    public double totalRows;
    public const int PageSize = 0;
    Manipulation mo;
    DataTable dt = new DataTable();
    DataSet dtuser = new DataSet();

    DataTable t;

    DataSet dss = new DataSet();
    AppSession aps = new AppSession();
    Decket_General docket = new Decket_General();
    SqlConnection con;
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, Name_Search;
    public string SELECT_TYPE, SELECT_BRANCH;
   
  
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
            Load_Imp_Name();

            btnSearchAll_Click(sender, e);

            gridbind_all();

        }
       
    }



  
    protected void btnSearch_Click(object sender, EventArgs e)
    {
      
        gridbind();
    }

    

    public void gridbind( )
    {
        DataSet ds1 = new DataSet();
      
        docket.WORKING_PERIOD = SELECT_BRANCH;

        if (ddlImp_name.SelectedItem.Text == string.Empty && txtfromdate.Text != string.Empty && txttodate.Text != string.Empty)
        {

            docket.CLIENT_BRANCH_CODE = currentbranch;
            docket.FROM_DATE = txtfromdate.Text;
            docket.TO_DATE = txttodate.Text;
            docket.IMPORTER_NAME = ddlImp_name.SelectedItem.Text;
            docket.Ename = "Select_All_NormalSearch";
            ds1 = docket.Docket_Grid_Search();
            gvdetails.DataSource = ds1.Tables[0];
            gvdetails.DataBind();
        }

        else if (ddlImp_name.SelectedItem.Text != string.Empty && txtfromdate.Text != string.Empty && txttodate.Text != string.Empty)
        {
            Importerwise_monthlyrpt();
        }

        else if (ddlImp_name.SelectedItem.Text != string.Empty && txtfromdate.Text == string.Empty && txttodate.Text == string.Empty)
        {
            Importer_gridload();

        }

        else
        {
            gridbind_all();

        }


      
    }





    public void gridbind_all()
    {
        DataSet ds1 = new DataSet();
      
        docket.WORKING_PERIOD = SELECT_BRANCH;

            docket.CLIENT_BRANCH_CODE = currentbranch;
            docket.FROM_DATE = txtfromdate.Text;
            docket.TO_DATE = txttodate.Text;
            docket.IMPORTER_NAME = ddlImp_name.SelectedItem.Text;
            docket.Ename = "GridSearch_LoadAll";
            ds1 = docket.Docket_Grid_Search();
            gvdetails.DataSource = ds1.Tables[0];
            gvdetails.DataBind();

    }
    public void Importer_gridload()
    {
        DataSet ds1 = new DataSet();
     
        docket.CLIENT_BRANCH_CODE = currentbranch;
        docket.FROM_DATE = txtfromdate.Text;
        docket.TO_DATE = txttodate.Text;
        docket.IMPORTER_NAME = ddlImp_name.SelectedItem.Text;
        docket.Ename = "Importernamewise_gridload";
        ds1 = docket.Docket_Grid_Search();

        gvdetails.DataSource = ds1.Tables[0];
        gvdetails.DataBind();
       
    }


    public void Importerwise_monthlyrpt()
    {
        DataSet ds1 = new DataSet();


        if (ddlImp_name.SelectedItem.Text != string.Empty || txtfromdate.Text != string.Empty || txttodate.Text != string.Empty)
        {
            docket.CLIENT_BRANCH_CODE = currentbranch;
            docket.FROM_DATE = txtfromdate.Text;
            docket.TO_DATE = txttodate.Text;
            docket.IMPORTER_NAME = ddlImp_name.SelectedItem.Text;
            docket.Ename = "Importerwise_monthlyrpt";
            ds1 = docket.Docket_Grid_Search();

            gvdetails.DataSource = ds1.Tables[0];
            gvdetails.DataBind();
        }

    }



    private void Load_Imp_Name()
    {
        DataSet dss = new DataSet();
        docket.CLIENT_BRANCH_CODE = currentbranch;
        docket.Ename = "Load_importer_name";
        dss = docket.Docket_Grid_Search();
        ddlImp_name.DataSource = dss.Tables[0];
        ddlImp_name.DataTextField = "IMPORTER_NAME";
        ddlImp_name.DataValueField = "IMPORTER_NAME";
        ddlImp_name.DataBind();
        ddlImp_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlImp_name.SelectedIndex = 0;
    }
   
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string jobno = string.Empty;
        string rowID = string.Empty;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string values = this.gvdetails.DataKeys[e.Row.RowIndex]["FILE_REFNO"].ToString();
            string Bill_invno = this.gvdetails.DataKeys[e.Row.RowIndex]["FILE_REFNO"].ToString();

            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("ondblclick", "Docket_Search_Update('" + values + "','" + Bill_invno + "')");

          
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

    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
        gridbind_all();
     
    }

   


   


   
}