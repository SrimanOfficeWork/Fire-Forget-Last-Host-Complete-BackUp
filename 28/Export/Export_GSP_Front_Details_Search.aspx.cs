using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Export_GSP_Front_Details_Search : ThemeClass
{
    AppSession aps = new AppSession();
    Export_BL_Multiple EBM = new Export_BL_Multiple();
    //EXP_BL_Generation BL_Gen = new EXP_BL_Generation();
    //Certificate_Of_Origin COO = new Certificate_Of_Origin();
    GSP_Details GSP = new GSP_Details();
    DataSet ds = new DataSet();

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
        // commented for areawise implementation on 05-mar-2020
        /*

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
          * */
        SELECT_BRANCH = Connection.Get_Company_Type();
        if (!IsPostBack)
        {
            Load_ExporterName();
            
        }
        Grid_load();
    }

    private void Load_ExporterName()
    {

        GSP.JOBNO = "";
        GSP.BRANCH_CODE = SELECT_BRANCH;
        GSP.Ename = "Get_GSP_Except_JobNo";

        ds = GSP.GSP_NORMAL_SEARCH();
        ddlExp_name.DataSource = ds.Tables[1];
        ddlExp_name.DataTextField = "EXPORTER_NAME";
        ddlExp_name.DataValueField = "EXPORTER_NAME";
        ddlExp_name.DataBind();
        ddlExp_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlExp_name.SelectedIndex = 0;
    
    }
    protected void ddlExp_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        Grid_load();
    }
    protected void ddlreportname_SelectedIndexChanged(object sender, EventArgs e)
    {
        Grid_load();
    }
    private void Grid_load()
    {
        GSP.JOBNO = txtjobno.Text;
        GSP.EXPORTER_NAME = ddlExp_name.SelectedItem.Text;
        GSP.FROM_DATE = txtfromdate.Text;
        GSP.TO_DATE = txttodate.Text;
        GSP.BRANCH_CODE = SELECT_BRANCH;
        GSP.Ename = "Select_All_NormalSearch";

        ds = GSP.GSP_NORMAL_SEARCH();

        gvdetails.DataSource = ds.Tables[0];
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
             string values = this.gvdetails.DataKeys[e.Row.RowIndex]["GSPID"].ToString();
             e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
             e.Row.Attributes.Add("onclick", "open_GSP_Normal_Search_Update('" + values + "')");

         }
     }

}