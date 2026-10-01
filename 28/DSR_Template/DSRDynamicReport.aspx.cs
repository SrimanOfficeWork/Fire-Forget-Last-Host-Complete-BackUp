using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.IO;
using System.Drawing;
using ImapX;


public partial class DSRDynamicReport : ThemeClass
{
    AppSession aps = new AppSession();
     Dynamic_Report DRT = new Dynamic_Report();
     GST_Imp_Invoice BI = new GST_Imp_Invoice();   
    
    public string currentbranch;
    public string Working_Period;
    public string SELECT_TYPE, SELECT_BRANCH;
   
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
            LoadSearch_DDL();
        }
    }

   
    private void LoadSearch_DDL()
    {
        try
        {
          
            DataSet ds = new DataSet();
            ddlSearchValue.Items.Clear();
            
            DRT.WORKING_PERIOD = SELECT_BRANCH;
            DRT.flag = "Select-DSR-TemplateName";
            ds = DRT.DSR_DynamicRpt(); 
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlSearchValue.DataSource = ds.Tables[0];                 
                ddlSearchValue.DataTextField = "TEMPLATE_NAME";
                ddlSearchValue.DataValueField = "T_ID";                
                ddlSearchValue.DataBind();
            }

            DRT.flag = "Select-DSR-JobNo";
            ds = DRT.DSR_DynamicRpt();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlJobno.DataSource = ds.Tables[0];
                ddlJobno.DataTextField = "JOBNO";
                ddlJobno.DataValueField = "JOBNO";
                ddlJobno.DataBind();
            }

            ddlJobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlJobno.SelectedIndex = 0;
            

            DRT.flag = "Select-DSR-CustomerName";
            ds = DRT.DSR_DynamicRpt();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlCustomer.DataSource = ds.Tables[0];
                ddlCustomer.DataTextField = "CUSTOMER_NAME";
                ddlCustomer.DataValueField = "CUSTOMER_NAME";
                ddlCustomer.DataBind();
            }
            ddlCustomer.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlCustomer.SelectedIndex = 0;

            ds.Dispose();
            GC.Collect();
        }
         
       
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        clear();
        DataTable dt = new DataTable();
        gvdetails.DataSource = dt;
        gvdetails.DataBind();
        dt.Dispose();
        GC.Collect();      

    }
    protected void btnexcel_Click(object sender, EventArgs e)
    {
        exportfile("Excel");        
    }

    protected void btnRdlc_Click(object sender, EventArgs e)
    {       
        exportfile("PDF");
    }

    private void exportfile(string filetype)
    {
        if (gvdetails.Rows.Count > 0)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)ViewState["dtdata"];
            if (dt.Rows.Count > 0)
            {
                if (filetype == "Excel")
                {
                    BI.ExportExcel(dt, "DSR-Report");
                }
                else if (filetype == "PDF")
                {
                    BI.Export_PDF(dt, "DSR-Report");
                }
            }
            else
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('No Records Found', 'DSR Report', function (r) {});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            }
        }
        else
        {
            string prompt = "<script>$(document).ready(function(){{jAlert('No Records Found', 'DSR Report', function (r) {});}});</script>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
        }
    }

    private void clear()
    {

        ddlSearchValue.SelectedIndex = -1;
        
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try{
                DataSet dss = new DataSet();
                DataTable dt1 = new DataTable();
                gvdetails.DataSource = dt1;
                gvdetails.DataBind();

                if (ddlSearchValue.SelectedValue.ToString() != "--Select--")
                
                {

                    DRT.WORKING_PERIOD = SELECT_BRANCH;
                    DRT.flag = "Select-DSR-DynamicRpt";

                    DRT.T_ID = ddlSearchValue.SelectedValue.ToString();
                    DRT.TEMPLATE_NAME = ddlCustomer.SelectedValue.ToString();
                    DRT.TYPE= ddlJobno.SelectedValue.ToString();

                   
                    dss = DRT.DSR_DynamicRpt(); 

                    if (dss.Tables[0].Rows.Count > 0)
                    {

                        

                        gvdetails.DataSource = dss.Tables[0];
                        gvdetails.DataBind();
                        ViewState["dtdata"] = dss.Tables[0];

                        

                    }
                    else
                    {
                        DataTable dt = new DataTable();
                        gvdetails.DataSource = dt;
                        gvdetails.DataBind();                        
                    }
                   
                }
                dss.Dispose();
                GC.Collect();
                
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        } 

        }
       

    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        
        

    }
     
}