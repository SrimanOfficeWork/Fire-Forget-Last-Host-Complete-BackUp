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

public partial class ProfitStatementRpt : ThemeClass
{
    AppSession aps = new AppSession();
    GST_Imp_Invoice BI = new GST_Imp_Invoice();
    Billing_UserBO ObjUBO = new Billing_UserBO();

   
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        
        if (!IsPostBack)
        {
            
            btnSearch_Click(sender, e);
        }
    }

    protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
    {
        //txtsearch.Visible = true;    
        //txtsearch.Text = "";
        LoadSearch_DDL();  
    }

    private void LoadSearch_DDL()
    {
        try
        {
        txtsearch.Visible = false;   
        if (ddltype.SelectedValue != "--Select--" && ddltype.SelectedValue != "All")
        {
            lblsearch.Visible = true;
            ddlSearchValue.Visible = true;

            ObjUBO.BILL_TYPE = Rd_Job_Type.SelectedValue.ToString();

            if (ddltype.SelectedValue.ToString() == "JobWise")
            {
                ObjUBO.Flag = "Select-ImpExpJobWise";
                lblsearch.Text = "Job No:";
            }

            else if (ddltype.SelectedValue.ToString() == "CustomerWise")
            {
                ObjUBO.Flag = "Select-ImpExpCustomerWise";
                lblsearch.Text = "Customer:";
            }
            else if (ddltype.SelectedValue.ToString() == "BillInvWise")
            {
                ObjUBO.Flag = "Select-ImpExpBillInvWise";
                lblsearch.Text = "Bill / Invoice No:";

            }
          
            DataSet ds = new DataSet();

            ddlSearchValue.Items.Clear();

            ds = BI.Load_DDL(ObjUBO);


            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlSearchValue.DataSource = ds.Tables[0];

                if (ddltype.SelectedValue.ToString() == "JobWise")
                {
                    ddlSearchValue.DataTextField = "jobno";
                    ddlSearchValue.DataValueField = "jobno";
                }
                else if (ddltype.SelectedValue.ToString() == "CustomerWise")
                {
                    ddlSearchValue.DataTextField = "CustomerName";
                    ddlSearchValue.DataValueField = "CustomerName";
                }
                else if (ddltype.SelectedValue.ToString() == "BillInvWise")
                {
                    ddlSearchValue.DataTextField = "BILL_INV_NO";
                    ddlSearchValue.DataValueField = "BILL_INV_NO";
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
        //ddl.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        //ddl.SelectedIndex = 0;
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
                    BI.ExportExcel(dt, "Profit-Statment");
                }
                else if (filetype == "PDF")
                {
                    BI.Export_PDF(dt, "Profit-Statment");
                }
            }
            else
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('No Records Found', 'Profit Statement', function (r) {});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            }
        }
        else
        {
            string prompt = "<script>$(document).ready(function(){{jAlert('No Records Found', 'Profit Statement', function (r) {});}});</script>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
        }
    }

    private void clear()
    {
        lblsearch.Visible = false;
        ddlSearchValue.Visible = false;
        txtsearch.Text = "";
        txtsearch.Visible = false;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try{
                DataSet dss = new DataSet();
                DataTable dt1 = new DataTable();
                gvdetails.DataSource = dt1;
                gvdetails.DataBind();

                //ObjUBO.BRANCH_CODE = Connection.Current_Branch();

                if (ddltype.SelectedValue.ToString() != "--Select--")
                
                {               

                    if (ddltype.SelectedValue.ToString() == "JobWise")
                        ObjUBO.Flag = "Select-JobWiseProfit";
                    else if (ddltype.SelectedValue.ToString() == "CustomerWise")
                        ObjUBO.Flag = "Select-CustomerWiseProfit";
                    else if (ddltype.SelectedValue.ToString() == "BillInvWise")
                        ObjUBO.Flag = "Select-BillWiseProfit";
                    else if (ddltype.SelectedValue.ToString() == "All")
                        ObjUBO.Flag = "Select-AllProfitInfo";

                    ObjUBO.BILL_TYPE = Rd_Job_Type.SelectedValue.ToString();

                   // ObjUBO.FILE_REF_NO = txtsearch.Text;
                    ObjUBO.MODE = Connection.Company_License();//NEW LINE ADDED FOR CHANGES BASED ON PARTICULAR COMPANY INBA ERI00945
                    ObjUBO.Ref_ID = ddlSearchValue.SelectedValue.ToString();


                    dss = BI.Load_DDL(ObjUBO);

                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        gvdetails.DataSource = dss.Tables[0];
                        gvdetails.DataBind();
                        ViewState["dtdata"] = dss.Tables[0];

                        int celno = 0, totalcelno = 0;        
                        celno = dss.Tables[0].Columns.IndexOf("BillingAmt");

                        gvdetails.FooterRow.Cells[celno].Text = "Total";
                        gvdetails.FooterRow.Cells[celno + 1].Text = dss.Tables[0].Compute("Sum(BillingAmt)", "").ToString();
                        gvdetails.FooterRow.Cells[celno + 2].Text = dss.Tables[0].Compute("Sum(TotalExpAmt)", "").ToString();
                        gvdetails.FooterRow.Cells[celno + 3].Text = dss.Tables[0].Compute("Sum(Profit)", "").ToString();
                        totalcelno = celno + 3;
                        for (celno = celno + 0; celno <= totalcelno; celno++)
                        {
                            gvdetails.FooterRow.Cells[celno].Font.Bold = true;
                            gvdetails.FooterRow.Cells[celno].Font.Size = 13;
                            gvdetails.FooterRow.Cells[celno].ForeColor = Color.Red;
                        }

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