using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BussinessObject;

public partial class BL_Generation_Annexure_Search : ThemeClass
{
    AppSession aps = new AppSession();
    DataSet ds = new DataSet();
    DataSet dsData = new DataSet();
    Billing_UserBO objUBO = new Billing_UserBO();
    Covering_LTR LTR = new Covering_LTR();

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, Name_Search;
    public string SELECT_TYPE, SELECT_BRANCH,Annex_Report_Type;
  
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
            Covering_No_Running();
            Grid_load();  
        }          
    }


    private void Grid_load()
    {
        objUBO.SW_ID = "";
        objUBO.IMPORTER_NAME = ddl_PartyName.SelectedValue;
        objUBO.TYPE = ddl_Type.SelectedItem.Text;
        objUBO.From_date = txtfromdate.Text;
        objUBO.Todate = txttodate.Text;

        objUBO.BRANCH_CODE = SELECT_BRANCH;
        objUBO.WORKING_PERIOD = SELECT_BRANCH;
        objUBO.flag = "Select_COVERING_LETTER_NORMAL_SEARCH";

        ds = LTR.RetrieveAll_COVERING_LETTER_NORMAL_SEARCH_Vaishnavi(objUBO);

        gvdetails.DataSource = ds.Tables[0];
        gvdetails.DataBind();

    }

    public void Covering_No_Running()
    {
        objUBO.SW_ID = "";
        objUBO.COVERING_NO = "";
        objUBO.TYPE = ddl_Type.SelectedItem.Text;
        objUBO.BRANCH_CODE = currentbranch;
        objUBO.WORKING_PERIOD = SELECT_BRANCH;
        objUBO.flag = "SELECT_MAXID";

        dsData = LTR.RetrieveAll_CoveringLetter_Details(objUBO);

        if (ddl_Type.SelectedItem.Text == "Import")
        {
            if (dsData.Tables[1].Rows.Count > 0)
            {
                ddl_PartyName.DataSource = dsData.Tables[1];
                ddl_PartyName.DataValueField = "IMPORTER_NAME";
                ddl_PartyName.DataTextField = "IMPORTER_NAME";
                ddl_PartyName.DataBind();
                ddl_PartyName.Items.Insert(0, "");
            }
        }
        else
        {
            if (dsData.Tables[1].Rows.Count > 0)
            {
                ddl_PartyName.DataSource = dsData.Tables[1];
                ddl_PartyName.DataValueField = "EXPORTER_NAME";
                ddl_PartyName.DataTextField = "EXPORTER_NAME";
                ddl_PartyName.DataBind();
                ddl_PartyName.Items.Insert(0, "");
            }
        }
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
             e.Row.Attributes.Add("onclick", "open_CoveringLetter_Search_Update_Vaishnavi('" + values + "')");

             //e.Row.Attributes.Add("onclick", "open_BL_Annexure_Search_Update('" + values + "','" + Type + "')");

             string Y1 = Working_Period.Substring(9, 2);
             string Y2 = Working_Period.Substring(23, 2);

             string type = e.Row.Cells[2].Text;
             string Cov_No=e.Row.Cells[0].Text;

             //if (ddl_Type.SelectedItem.Text == "Import")
             //{
             //    e.Row.Cells[0].Text = "IMP/" + Cov_No + "/" + Y1 + "-" + Y2;
             //}
             //else
             //{
             //    e.Row.Cells[0].Text = "EXP/" + Cov_No + "/" + Y1 + "-" + Y2;
             //}

         }
     }
    
     public void Alert_msg(string msg)
     {
         string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'BL Annexure Details', function (r) {});}});</script>";
         ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
     }

     public void Alert_msg(string msg, string focus)
     {
         string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'BL Annexure Details', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
         ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
     }
     protected void BtnNew_Click(object sender, EventArgs e)
     {
         ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>open_CoveringLetter_Search_New('New');</script>", false); 
     }
    
     protected void ddl_Type_SelectedIndexChanged(object sender, EventArgs e)
     {
         Covering_No_Running();
         Grid_load();
     }
}