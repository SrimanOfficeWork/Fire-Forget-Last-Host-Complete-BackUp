using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class BL_Generation_Annexure_Search : ThemeClass
{
    AppSession aps = new AppSession();
    Export_BL_Multiple EBM = new Export_BL_Multiple();
    EXP_BL_Generation BL_Gen = new EXP_BL_Generation();
    DataSet ds = new DataSet();

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, Name_Search;
    public string SELECT_TYPE, SELECT_BRANCH,Annex_Report_Type;
    public string jjjobno;

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
                if (Request.QueryString["Name"] == null)
                {

                }
                else
                {
                    if (Request.QueryString["Name"] == "COO")
                    {
                        Annex_Report_Type = "Certificate of Origin";
                        lbl_heading.Text = "Certificate of Origin - ANNEXURE";
                    }
                    if (Request.QueryString["Name"] == "BL_Generation")
                    {
                        Annex_Report_Type = "BL Generation";
                        lbl_heading.Text = "BL Generation - ANNEXURE";
                    }
                    HiddenField_Type.Value = Annex_Report_Type;
                    Grid_load();
                }               
        }            
    }

    
    private void Grid_load()
    {
        if (HiddenField_Type.Value == "COO")
        {
            HiddenField_Type.Value = "Certificate of Origin";
        }
        if (HiddenField_Type.Value == "BL_Generation")
        {
            HiddenField_Type.Value = "BL Generation";
        }

            BL_Gen.JOBNO = txtjobno.Text;
            BL_Gen.REPORT_TYPE = HiddenField_Type.Value;
            //BL_Gen.REPORT_TYPE = ddl_Type.SelectedItem.Text;
            BL_Gen.FROM_DATE = txtfromdate.Text;
            BL_Gen.TO_DATE = txttodate.Text;
            BL_Gen.BRANCHCODE = SELECT_BRANCH;
            BL_Gen.Ename = "Select_All_NormalSearch";

            ds = BL_Gen.BL_ANNEXURE_GENERAL_SEARCH();

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

             string values = this.gvdetails.DataKeys[e.Row.RowIndex]["BL_ANX_ID"].ToString();

             hdn_JOBNO1.Value = values;
             HiddenField_Type.Value = Request.QueryString["Name"].ToString();
             string Type = HiddenField_Type.Value;

             e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";

             //e.Row.Attributes.Add("onclick", "open_BL_Annexure_Search_Update('" + values + "')");

             e.Row.Attributes.Add("onclick", "open_BL_Annexure_Search_Update('" + values + "','" + Type + "')");

            

             var marks_Nos_val = e.Row.Cells[2].Text;
             var Goods_Description = e.Row.Cells[3].Text;

             if (e.Row.Cells[2].Text.Length > 30)
             {
                 e.Row.Cells[2].Text = marks_Nos_val.Substring(0, 30).Replace("\r\n", "  ") + "...";
             }
             if (e.Row.Cells[3].Text.Length > 30)
             {
                 e.Row.Cells[3].Text = Goods_Description.Substring(0, 30).Replace("\r\n","  ") + "...";
             }

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
         HiddenField_Type.Value = Request.QueryString["Name"].ToString();
         ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>Open_Annnexure_New('New','" + HiddenField_Type.Value + "');</script>", false);

         //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>Open_Annnexure_LCD('New','" + HiddenField_Type.Value + "');</script>", false);
     }
}