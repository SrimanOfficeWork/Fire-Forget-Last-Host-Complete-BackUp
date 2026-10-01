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



public partial class Import_MasterPage_Dynamic_Report_Design_Search : ThemeClass
{
    AppSession aps = new AppSession();
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, Name_Search;
    public string SELECT_TYPE, SELECT_BRANCH;

    Dynamic_Report DRT = new Dynamic_Report();
    DataSet ds = new DataSet();

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
            Tr_mode_load();
            btnSearch_Click(sender, e);
        }

    }
    private void Tr_mode_load()
    {
        if (Session["SELECT_TYPE"].ToString() == "Branchwise Job")
        {
            ddlTr_Mode.Items.Add(new ListItem("Air", "Air"));
            ddlTr_Mode.Items.Add(new ListItem("Sea", "Sea"));
            ddlTr_Mode.Items.Add(new ListItem("Land", "Land"));
        }
        else
        {
            ddlTr_Mode.Items.Add(new ListItem("All", "All"));
            ddlTr_Mode.Items.Add(new ListItem("Air", "Air"));
            ddlTr_Mode.Items.Add(new ListItem("Sea", "Sea"));
            ddlTr_Mode.Items.Add(new ListItem("Land", "Land"));
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        gridBind();
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

    private void gridBind()
    {
       DRT.TYPE=ddltype.SelectedItem.Text;
       DRT.TR_MODE=ddlTr_Mode.SelectedItem.Text;
       DRT.ACTIVE=ddlactive.SelectedItem.Text;
       DRT.WORKING_PERIOD = SELECT_BRANCH;
       DRT.Select_Con = "Temp";
       
       ds = DRT.All_Record();
       gvdetails.DataSource = ds;
       gvdetails.DataBind();
    }

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string jobno = string.Empty;
        string rowID = String.Empty;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string values = this.gvdetails.DataKeys[e.Row.RowIndex]["T_ID"].ToString();
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("onclick", "open_Dynamic_Report_Update('" + values + "')");

            /*
            jobno = this.gvdetails.DataKeys[e.Row.RowIndex]["T_ID"].ToString();
            rowID = e.Row.RowIndex.ToString();
            e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
            e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + jobno + "')");
            */

        }
    }
}