using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Export_Despatch_Search : ThemeClass
{
    AppSession aps = new AppSession();
    //Export_BL_Multiple EBM = new Export_BL_Multiple();
    Despatch DSP = new Despatch();

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
            Load_Shippername();
        }
        Grid_load();
    }

    private void Load_Shippername()
    { 
        DSP.Branch = SELECT_BRANCH;
        DSP.flag = "Select_ShipperName";
        DSP.MODE = "";

        ddlExp_name.DataSource = DSP.Export_Despatch_Name();
        ddlExp_name.DataTextField = "Shipper_name";
        ddlExp_name.DataValueField = "Shipper_name";
        ddlExp_name.DataBind();
        ddlExp_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlExp_name.SelectedIndex = 0;
    
    }
    protected void ddlExp_name_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        DSP.EXPORTER_NAME = ddlExp_name.SelectedItem.Text;
        DSP.Branch = SELECT_BRANCH;
        DSP.flag = "Select_Ref_name";

        ddlreportname.DataSource = DSP.Export_Despatch_Name();
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

        DSP.JOBNO = txtjobno.Text;
        DSP.EXPORTER_NAME = ddlExp_name.SelectedItem.Text;
        DSP.REF_NAME = ddlreportname.SelectedIndex > 0 ? ddlreportname.SelectedItem.Text : ""; ;
        DSP.from_date = txtfromdate.Text;
        DSP.todate = txttodate.Text;
        DSP.Branch = SELECT_BRANCH;
       
        gvdetails.DataSource = DSP.EXPORT_DESPATCH_GENERAL_Search();
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
             string values = this.gvdetails.DataKeys[e.Row.RowIndex]["ID"].ToString();
             e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
             e.Row.Attributes.Add("onclick", "open_Export_Despatch_Search_Update('" + values + "')");

         }
     }
}