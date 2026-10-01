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



public partial class DSRDynamicTmpSearch : ThemeClass
{
    AppSession aps = new AppSession();
   
    public string currentbranch;  
   
    public string Working_Period;
    
    public string SELECT_TYPE, SELECT_BRANCH;

    Dynamic_Report DRT = new Dynamic_Report();
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        
        currentbranch = Session["currentbranch"].ToString();     
      
        Working_Period = Session["WorkingPeriod"].ToString();
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
            
            btnSearch_Click(sender, e);
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
       DRT.ACTIVE=ddlactive.SelectedItem.Text;
       DRT.WORKING_PERIOD = SELECT_BRANCH;
       DRT.flag = "Select-DSR_TEMPLATE";

       ds = DRT.DSR_DynamicRpt();
        
       gvdetails.DataSource = ds;
       gvdetails.DataBind();
    }

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string jobno = string.Empty;
        string rowID = String.Empty;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string values = this.gvdetails.DataKeys[e.Row.RowIndex]["ID"].ToString();
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("onclick", "open_DSRDynamicUPD('" + values + "')");           
        }
    }
}