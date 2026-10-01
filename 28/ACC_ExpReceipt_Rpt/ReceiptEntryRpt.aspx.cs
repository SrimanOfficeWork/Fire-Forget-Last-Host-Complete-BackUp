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


public partial class ReceiptEntryRpt : ThemeClass
{
    AppSession aps = new AppSession();
    GST_Imp_Invoice BI = new GST_Imp_Invoice();
    Billing_UserBO ObjUBO = new Billing_UserBO();   

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();       
        
        hdrowindex.Value = String.Empty;
        hdBill_invno.Value = String.Empty;

        //if (!IsPostBack)
        //{
        //    btnSearch_Click(sender, e);
        //}
    }

    protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
    { 
        LoadSearch_DDL();  
    }

    private void LoadSearch_DDL()
    {
        try
        {
         
        DivDatewise.Visible = false;

        if (ddltype.SelectedValue != "--Select--" && ddltype.SelectedValue != "All")
        {
            lblsearch.Visible = true;
            ddlSearchValue.Visible = true;

            ObjUBO.BILL_TYPE = Rd_Job_Type.SelectedValue.ToString();

             if (ddltype.SelectedValue.ToString() == "CustomerWise")
            {
                ObjUBO.Flag = "Select-Receipt-Customer";
                lblsearch.Text = "Customer:";
            }
             
             else if (ddltype.SelectedValue.ToString() == "DateWise")
             {
                
                 lblsearch.Text = "Date Wise:";
                 DivDatewise.Visible = true;
                 ddlSearchValue.Visible = false;

             }
             else if (ddltype.SelectedValue.ToString() == "PayModeWise")
            {
                lblsearch.Text = "Pay Mode Wise:";
                ObjUBO.Flag = "Select-Receipt-Paymode";
                
            }

             else if (ddltype.SelectedValue.ToString() == "PayForWise")
             {
                 ObjUBO.Flag = "Select-Receipt-PayFor";
                 lblsearch.Text = "Paymen For:";
             }
            
            DataSet ds = new DataSet();

            ddlSearchValue.Items.Clear();

            ds = BI.Load_DDL(ObjUBO);


            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlSearchValue.DataSource = ds.Tables[0];

                if (ddltype.SelectedValue.ToString() == "CustomerWise")
                {
                    ddlSearchValue.DataTextField = "Customer_Name";
                    ddlSearchValue.DataValueField = "Customer_Name";
                }
                else if (ddltype.SelectedValue.ToString() == "PayModeWise")
                {
                    ddlSearchValue.DataTextField = "PaymentMode";
                    ddlSearchValue.DataValueField = "PaymentMode";
                }

                else if (ddltype.SelectedValue.ToString() == "PayForWise")
                {
                    ddlSearchValue.DataTextField = "IsJob_Advance";
                    ddlSearchValue.DataValueField = "IsJob_Advance";
                }               
                ddlSearchValue.DataBind();

            }
            ds.Dispose();
            GC.Collect();
        }
        else
        {
            clear();            
        }
         
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
        ddltype.SelectedIndex = 0; 
        
    }
    protected void btnexcel_Click(object sender, EventArgs e)
    {
        exportfile("Excel");        
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
                    BI.ExportExcel(dt, "Receipt-Details");
                }
                else if (filetype == "PDF")
                {
                    BI.Export_PDF(dt, "Receipt-Details");
                }
            }
            else
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('No Records Found', 'Receipt Details', function (r) {});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            }
        }
        else
        {
            string prompt = "<script>$(document).ready(function(){{jAlert('No Records Found', 'Receipt Details', function (r) {});}});</script>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
        }
    }
   

    protected void btnRdlc_Click(object sender, EventArgs e)
    {
        //selectvalues("RDLC-Report");
        exportfile("PDF");
    }

    private void clear()
    {
        lblsearch.Visible = false;
        ddlSearchValue.Visible = false;       
        DivDatewise.Visible = false;
       
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try{
            DataTable dt = new DataTable();
            gvdetails.DataSource = dt;
            gvdetails.DataBind();
            selectvalues("Grid");
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        } 
        
       }
    private void selectvalues(string grd_rdlc)
    {
        DataSet dss = new DataSet();

        if (ddltype.SelectedValue.ToString() != "--Select--")
        {

            if (ddltype.SelectedValue.ToString() == "CustomerWise")
            {
                ObjUBO.Flag = "Select-ImpExpCustomerWise-Receipt";
            }
           
            else if (ddltype.SelectedValue.ToString() == "DateWise")
            {
                ObjUBO.Flag = "Select-ImpExpDateWise-Receipt";                 
                ObjUBO.from_date = txtfromdate.Text.Substring(3, 2) + '/' + txtfromdate.Text.Substring(0, 2) + '/' + txtfromdate.Text.Substring(6, 4);
                ObjUBO.todate = txttodate.Text.Substring(3, 2) + '/' + txttodate.Text.Substring(0, 2) + '/' + txttodate.Text.Substring(6, 4);
                
            }
           
            else if (ddltype.SelectedValue.ToString() == "PayModeWise")   
            {
                ObjUBO.Flag = "Select-ImpExpPaymode-Receipt";
            }
            else if (ddltype.SelectedValue.ToString() == "PayForWise")   
            {
                ObjUBO.Flag = "Select-ImpExpPayfor-Receipt";
            }
            else if (ddltype.SelectedValue.ToString() == "All")
            {
                ObjUBO.Flag = "Select-AllReceipts";
            }

            

            ObjUBO.Ref_ID = ddlSearchValue.SelectedValue.ToString();


            ObjUBO.BILL_TYPE = Rd_Job_Type.SelectedValue.ToString();
            ObjUBO.MODE = RdReportType.SelectedValue.ToString();

            if (grd_rdlc == "Grid")
            {
                dss = BI.Load_DDL(ObjUBO);
                if (dss.Tables[0].Rows.Count>0)
                {
                    gvdetails.DataSource = dss.Tables[0];
                    gvdetails.DataBind();
                    ViewState["dtdata"] = dss.Tables[0];

                    int celno = 0;                    
                    celno = dss.Tables[0].Columns.IndexOf("ReceivedAmt");

                    gvdetails.FooterRow.Cells[celno].Text = "Total";
                    gvdetails.FooterRow.Cells[celno + 1].Text = dss.Tables[0].Compute("Sum(ReceivedAmt)", "").ToString();
                    gvdetails.FooterRow.Cells[celno + 2].Text = dss.Tables[0].Compute("Sum(TDSAmt)", "").ToString();
                    for (celno = celno + 0; celno < celno + 3; celno++)
                    {

                        gvdetails.FooterRow.Cells[celno].Font.Bold = true;
                        gvdetails.FooterRow.Cells[celno].Font.Size = 13;
                        gvdetails.FooterRow.Cells[celno].ForeColor = Color.Red;
                    }

                }                 
                 
            }
            
        }
        else
        {
            DataTable dt = new DataTable();
            gvdetails.DataSource = dt;
            gvdetails.DataBind();

        }
        dss.Dispose();
        GC.Collect();
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