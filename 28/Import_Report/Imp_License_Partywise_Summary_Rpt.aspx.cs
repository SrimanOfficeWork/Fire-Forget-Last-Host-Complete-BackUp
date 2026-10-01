using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;

public partial class Imp_License_Partywise_Summary_Rpt : ThemeClass
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 25;
    SqlCommand com, cmd, cmd1;
    SqlDataReader dr, dr1;

    //SqlDataAdapter da;
    DataTable dt;
    //DataRow de;
    DataSet dtuser = new DataSet();
    DataSet ds1 = new DataSet();
    eroyalmaster erm = new eroyalmaster();
    SqlConnection con;
    Manipulation mo;
    AppSession aps = new AppSession();
    adminmaster adm = new adminmaster();
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, Name_Search;
    //int _startIndex = 0;
    //int _thisPage = 1;
    //int _pageSize = 10;
    //int _totalNumberOfRows = 0;
    //int[] f = new int[100];
    //int[] l = new int[100];
    //public string str, title, state, magimage, pagestr, startpage, comments, mm, lastpost, selqry;
    //int i, j, ii, k, page, pageno, start, first, last, m, n, fir, la, kk, mmm, z, a, b, c, res;
    const int pageSize = 10;
    const int pageDispCount = 10;
    //private DataTable dt = new DataTable();
    private DataSet ds = new DataSet();
    public string SELECT_TYPE, SELECT_BRANCH;
    protected void Page_Load(object sender, EventArgs e)
    {

        txtLicense_No.Focus();
        aps.checkSession();
        // if (!Page.IsPostBack)
        //{
        //Response.AppendHeader("Refresh", ((Session.Timeout * 3) + 3).ToString() + "; Url=../LoginPage/Default.aspx?from=expired");

        // }
        con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

        // commented for areawise implementation on 05-mar-2020
        /*
        if (Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = Session["SELECT_TYPE"].ToString();

            if (SELECT_TYPE == "Branchwise Job")
            {
                SELECT_BRANCH = currentbranch;
                hdnBranch.Value = SELECT_BRANCH;
            }
            else
            {
                SELECT_BRANCH = "";
                hdnBranch.Value = SELECT_BRANCH;
            }
        }
        else
        {
            SELECT_BRANCH = "";
            hdnBranch.Value = SELECT_BRANCH;
        }
      * */
        SELECT_BRANCH = Connection.Get_Company_Type();
        hdnBranch.Value = SELECT_BRANCH;
        if (!IsPostBack)
        {
            Get_PartyName_LICNESE();
            //btnSearch_Click(sender, e);
        }
        //btnSearch_Click(sender, e);
        //Get_PartyName_LICNESE();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //int pageno = 1;
        //if (txtLicense_No.Text != "")
        //{
            gridbind();
        //}
        //else
        //{
        //    gvdetails.DataSource = dt;
        //    gvdetails.DataBind();
        //}
    }
    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
        //txtLicense_No.Text = "";
        //Name_Search = "";
        btnSearch_Click(sender, e);
    }

    public void Get_PartyName_LICNESE()
    {
        if (txtLicense_No.Text != "")
        {
            ddl_Port_License.Items.Remove("");
            erm.LICENSE_NO = txtLicense_No.Text;
            erm.IMP_EXP_NAME = "";
            erm.PORT_OF_LICENSE = "";
            erm.EWorking_Period = SELECT_BRANCH;
            erm.Ename = "select_License_JOBNO_TO_IMPORTER_NAME";
            ds1 = erm.RetrieveAll_IMPORT_LICENSE_DEBIT_AMT_REPORT_PARTYWISE();

            if (ds1.Tables[0].Rows.Count > 0)
            {
                ddl_Partyname.DataSource = ds1.Tables[0];
                ddl_Partyname.DataTextField = "ImporterName";
                ddl_Partyname.DataValueField = "ImporterName";
                ddl_Partybrslno.DataSource = ds1.Tables[0];
                ddl_Partybrslno.DataTextField = "Importer_Br_Slno";
                ddl_Partybrslno.DataValueField = "Importer_Br_Slno";
                ddl_Partyname.DataBind();
                ddl_Partybrslno.DataBind();
                ddl_Partyname.Items.Insert(0, "");
                ddl_Partybrslno.Items.Insert(0, "");
            }
            else
            {
                ddl_Partyname.Items.Insert(0, "");
                ddl_Partybrslno.Items.Insert(0, "");
            }
            if (ds1.Tables[1].Rows.Count > 0)
            {
                ddl_Port_License.DataSource = ds1.Tables[1];
                ddl_Port_License.DataTextField = "PORT_OF_LICENSE";
                ddl_Port_License.DataValueField = "PORT_OF_LICENSE";
                ddl_Port_License.DataBind();
                ddl_Port_License.Items.Insert(0, "");
            }
            else
            {
                ddl_Port_License.Items.Insert(0, "");
            }
            if (ds1.Tables[2].Rows.Count > 0)
            {
                ddl_SchemeCode.DataSource = ds1.Tables[2];
                ddl_SchemeCode.DataTextField = "SCHEME_CODE";
                ddl_SchemeCode.DataValueField = "SCHEME_CODE";
                ddl_SchemeCode.DataBind();
                ddl_SchemeCode.Items.Insert(0, "");
            }
            else
            {
                ddl_SchemeCode.Items.Insert(0, "");
            }
        }
        else
        {
            erm.LICENSE_NO = "";
            erm.LICENSE_DATE = "";
            erm.PORT_OF_LICENSE = "";
            erm.EWorking_Period = SELECT_BRANCH;
            erm.Ename = "select_General_IMPORTER_NAME";
            ds1 = erm.RetrieveAll_IMPORT_LICENSE_DEBIT_AMT_REPORT_PARTYWISE();
            if (ds1.Tables[0].Rows.Count > 0)
            {
                ddl_Partyname.DataSource = ds1.Tables[0];
                ddl_Partyname.DataTextField = "IMPORTER_NAME";
                ddl_Partyname.DataValueField = "IMPORTER_NAME";
                ddl_Partybrslno.DataSource = ds1.Tables[0];
                ddl_Partybrslno.DataTextField = "BRANCH_NO";
                ddl_Partybrslno.DataValueField = "BRANCH_NO";
                ddl_Partyname.DataBind();
                ddl_Partybrslno.DataBind();
                ddl_Partyname.Items.Insert(0, "");
                ddl_Partybrslno.Items.Insert(0, "");
            }
            else
            {
                ddl_Partyname.Items.Insert(0, "");
                ddl_Partybrslno.Items.Insert(0, "");
            }
            if (ds1.Tables[1].Rows.Count > 0)
            {
                ddl_Port_License.DataSource = ds1.Tables[1];
                ddl_Port_License.DataTextField = "PORT_OF_LICENSE";
                ddl_Port_License.DataValueField = "PORT_OF_LICENSE";
                ddl_Port_License.DataBind();
                ddl_Port_License.Items.Insert(0, "");
            }
            else
            {
                ddl_Port_License.Items.Insert(0, "");
            }
            if (ds1.Tables[2].Rows.Count > 0)
            {
                ddl_SchemeCode.DataSource = ds1.Tables[2];
                ddl_SchemeCode.DataTextField = "SCHEME_CODE";
                ddl_SchemeCode.DataValueField = "SCHEME_CODE";
                ddl_SchemeCode.DataBind();
                ddl_SchemeCode.Items.Insert(0, "");
            }
            else
            {
                ddl_SchemeCode.Items.Insert(0, "");
            }
        }
    }
   

    public void gridbind()
    {
        if ((ddl_Partyname.SelectedItem.Text != "" || ddl_Partyname.SelectedItem.Text != null) && ddl_Port_License.SelectedItem.Text == "" && ddl_SchemeCode.SelectedItem.Text == "" && ddl_Partybrslno.SelectedItem.Text == "")
        {
            erm.LICENSE_NO = "";
            erm.LICENSE_DATE = "";
            erm.IMP_EXP_NAME = ddl_Partyname.SelectedItem.Text == null ? string.Empty : ddl_Partyname.SelectedItem.Text;
            erm.IMP_EXP_BRSLNO = "";
            erm.PORT_OF_LICENSE = "";
            erm.SCHEME_CODE = "";
 
            erm.EWorking_Period = SELECT_BRANCH;
            erm.Ename = "PARTYWISE";
            ds1 = erm.RetrieveAll_IMPORT_LICENSE_DEBIT_AMT_REPORT_PARTYWISE();
 
        }
        else
        {
        erm.LICENSE_NO = txtLicense_No.Text;
        erm.LICENSE_DATE = "";
        erm.IMP_EXP_NAME = ddl_Partyname.SelectedItem.Text==null? string.Empty: ddl_Partyname.SelectedItem.Text;
        erm.IMP_EXP_BRSLNO = ddl_Partybrslno.SelectedItem.Text == null ? string.Empty : ddl_Partybrslno.SelectedItem.Text;
        erm.PORT_OF_LICENSE = ddl_Port_License.SelectedItem.Text == null ? string.Empty : ddl_Port_License.SelectedItem.Text;
        erm.SCHEME_CODE = ddl_SchemeCode.SelectedItem.Text == null ? string.Empty : ddl_SchemeCode.SelectedItem.Text;
 
        erm.EWorking_Period = SELECT_BRANCH;
        erm.Ename = "SELECT_LICENSE_PARTYWISE";
        ds1 = erm.RetrieveAll_IMPORT_LICENSE_DEBIT_AMT_REPORT_PARTYWISE();
        }
        if (ds1.Tables[0].Rows.Count > 0)
        {      
            gvdetails.DataSource = ds1.Tables[0];
            gvdetails.DataBind();
        }
        else
        {
            gvdetails.DataSource = dt;
            gvdetails.DataBind();
            gvdetails.EmptyDataText = "No Record Found";
        }
    }

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var row = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].CssClass = "locked";
        }
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
    protected void txtLicense_No_TextChanged(object sender, EventArgs e)
    {
        Get_PartyName_LICNESE();
    }

}