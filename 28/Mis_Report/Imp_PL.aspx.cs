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
using System.Configuration;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;


public partial class Mis_Report_Imp_PL : ThemeClass
{

    Pl_Report PL = new Pl_Report();

    DailyStatusRpt DSR1 = new DailyStatusRpt();
    //ExpeditorsRpt EXP_Rpt = new ExpeditorsRpt();

    AppSession aps = new AppSession();
    DataSet ds = new DataSet();
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, Name_Search;
    public string Company_ID;

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
        Company_ID = Session["COMPANY_ID"].ToString();

        if (IsPostBack)
        {
            if (Session["SELECT_TYPE"] != null)
            {
                SELECT_TYPE = Session["SELECT_TYPE"].ToString();

                if (SELECT_TYPE == "Branchwise Job")
                {
                    SELECT_BRANCH = currentbranch;
                }
                else
                {
                    SELECT_BRANCH = "";

                }
            }
            else
            {
                SELECT_BRANCH = "";
            }
        }

        if (!IsPostBack)
        {
            Bind_ClientMasterName();
            txtimpname.Items.Add("All");
            txtimpname.Text="All";

            if (Session["SELECT_TYPE"] != null)
            {
                SELECT_TYPE = Session["SELECT_TYPE"].ToString();

                if (SELECT_TYPE == "Branchwise Job")
                {
                    SELECT_BRANCH = currentbranch;
                    Bind_Branches();                    
                    txtbranch.Text = currentbranch;

                }
                else
                {
                    //SELECT_BRANCH = "";
                    Bind_Branches();                    
                    txtbranch.Items.Add("All");                    
                    txtbranch.Text = currentbranch;
                }
            }
            else
            {
                SELECT_BRANCH = "";

            }
            
        }

        txtimpname.Attributes.Add("onblur", "javascript:CallServerside_Importer('" + txtimpname.ClientID + "')");        
        txtJobNo.Focus();
        
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

        }
    }
    protected void btnSearch1_Click(object sender, EventArgs e)
    {
        gridBind();
    }
    private void gridBind()
    {

        PL.JobNo = txtJobNo.Text;
        PL.Jobdate = txtJobDate.Text;
        PL.To_date = txttodate.Text;
        PL.Imp_name = txtimpname.Text;
        PL.Tr_mode = ddltr_mode.SelectedItem.Text;
        PL.BRANCH_COMMON = txtbranch.Text;
        Session["txtBranch"] = txtbranch.Text;

        DataView dv = new DataView(PL.IMP_PL_QUERY());

        gvdetails.DataSource = dv;
        gvdetails.DataBind();
        gvdetails.Attributes.Add("style", "table-layout:fixed");
    }
 
    public void Bind_Branches()
    {
        string id = Company_ID;
        DSR1.companyId = id;
        DSR1.Ename = "Bind_Branches";
        ds = DSR1.DS_Report();
        txtbranch.DataSource = ds.Tables[0];
        txtbranch.DataTextField = "BRANCH";
        txtbranch.DataValueField = "BRANCH";
        txtbranch.DataBind();
        txtbranch.Items.Remove("0");
    }
 
    public void Bind_ClientMasterName()
    {
        DSR1.Ename = "Bind_IMP_EXP_Name";
        ds = DSR1.DS_Report();

        txtimpname.DataSource = ds.Tables[0];
        txtimpname.DataTextField = "IMP_EXP_NAME";
        txtimpname.DataValueField = "IMP_EXP_NAME";
        txtimpname.DataBind();
        txtimpname.Items.Remove("0");

    }

}