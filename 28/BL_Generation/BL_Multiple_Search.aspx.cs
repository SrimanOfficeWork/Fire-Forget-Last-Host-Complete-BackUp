using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class BL_Multiple_Search : ThemeClass
{
    AppSession aps = new AppSession();
    Export_BL_Multiple EBM = new Export_BL_Multiple();

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
    }

    private void Load_Shippername()
    { 
        EBM.Branch = SELECT_BRANCH;
        EBM.Flag = "Select_ShipperName";
        EBM.Mode = "";

        ddlExp_name.DataSource = EBM.Exp_Name();
        ddlExp_name.DataTextField = "Shipper_name";
        ddlExp_name.DataValueField = "Shipper_name";
        ddlExp_name.DataBind();
        ddlExp_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlExp_name.SelectedIndex = 0;
    
    }
    protected void ddlExp_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        EBM.Exp_name = ddlExp_name.SelectedItem.Text;
        EBM.Branch = SELECT_BRANCH;
        EBM.Flag = "Select_Ref_name";

        ddlreportname.DataSource = EBM.Exp_Name();
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

        EBM.Job = txtjobno.Text;
        EBM.Shipper_name = ddlExp_name.SelectedItem.Text;
        EBM.Ref_name = ddlreportname.SelectedIndex > 0 ? ddlreportname.SelectedItem.Text : ""; ;
        EBM.from_date = txtfromdate.Text;
        EBM.todate = txttodate.Text;
        EBM.Branch = SELECT_BRANCH;
        EBM.Type = ddltype.SelectedValue.ToString();

        gvdetails.DataSource = EBM.Multiple_BL_Search();
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
             string values = this.gvdetails.DataKeys[e.Row.RowIndex]["BL_ID"].ToString();
             e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
             e.Row.Attributes.Add("onclick", "open_BL_Con_Search_Update('" + values + "')");

         }
     }
}