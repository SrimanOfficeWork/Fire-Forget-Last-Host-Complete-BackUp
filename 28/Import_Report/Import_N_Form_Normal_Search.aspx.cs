using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BussinessObject;

public partial class Import_N_Form_Normal_Search : ThemeClass
{
    AppSession aps = new AppSession();
    //Export_BL_Multiple EBM = new Export_BL_Multiple();
    //EXP_BL_Generation BL_Gen = new EXP_BL_Generation();
    DataSet ds = new DataSet();
    UserBO ObjUBO = new UserBO();
    NForm NForm = new NForm();

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

        if (!IsPostBack)
        {
            Load_ImporterName();
            Load_NF_JobNo();
            Grid_load();
        }
        
        //Grid_load();
    }


    public void Load_NF_JobNo()
    {
        ObjUBO.JOBNO = "";
        ObjUBO.Ename = "NForm_Jobno_Select";
        ObjUBO.WORKING_PERIOD = SELECT_BRANCH;

        ddlJobNo.DataSource = NForm.RetrieveAll_N_FORM_Details(ObjUBO);
        ddlJobNo.DataValueField = "JOBNO";
        ddlJobNo.DataTextField = "JOBNO";
        ddlJobNo.DataBind();
        ddlJobNo.Items.Remove("0");
        ddlJobNo.Items.Insert(0, "Select");
    }

    private void Load_ImporterName()
    {
        ObjUBO.JOBNO = "";
        ObjUBO.WORKING_PERIOD = SELECT_BRANCH;
        ObjUBO.Ename = "select_jobno";

        ds = NForm.RetrieveAll_N_FORM_Details(ObjUBO);
        ddlExp_name.DataSource = ds.Tables[0];

        ddlExp_name.DataTextField = "IMPORTER_NAME";
        ddlExp_name.DataValueField = "IMPORTER_NAME";
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
        ObjUBO.JOBNO = ddlJobNo.SelectedItem.Text=="Select" ? string.Empty : ddlJobNo.SelectedItem.Text;;
        ObjUBO._NF_NAME_APPLICANT = ddlExp_name.SelectedItem.Text;
        ObjUBO.From_date = txtfromdate.Text;
        ObjUBO.Todate = txttodate.Text;
        ObjUBO.BRANCH_CODE = SELECT_BRANCH;
        ObjUBO.Ename = "Select_All_NormalSearch";
        ds = NForm.RetrieveAll_NFORM_NORMAL_SEARCH(ObjUBO);

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
             string values = this.gvdetails.DataKeys[e.Row.RowIndex]["NFORM_ID"].ToString();
             e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
             e.Row.Attributes.Add("onclick", "open_Import_Nform_Update('" + values + "')");

             //e.Row.Attributes.Add("onclick", "open_BL_Con_Search_Update('" + values + "')");
         }
     }
}