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


public partial class OutstandingCrDrRpt : ThemeClass
{
    AppSession aps = new AppSession();
    GST_Imp_Invoice BI = new GST_Imp_Invoice();
    Billing_UserBO ObjUBO = new Billing_UserBO();   

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();          
         
    }

    protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
    { 
        LoadSearch_DDL();  
    }

    private void LoadSearch_DDL()
    {
        try
        {
            if (ddltype.SelectedValue == "DateWise" || ddltype.SelectedValue == "AllCustomerDateWise")
                DivDatewise.Visible=true;
            else
                DivDatewise.Visible=false;



            if (ddltype.SelectedValue == "DateWise" || ddltype.SelectedValue == "CustomerWise")
            {
                lblsearch.Text = "Customer:";
                ddlSearchValue.Visible = true;
                DataSet ds = new DataSet();

                ObjUBO.Flag = "Select-ImpExpCustomer";
                ddlSearchValue.Items.Clear();
                ds = BI.Load_Acc_Rpt(ObjUBO);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlSearchValue.DataSource = ds.Tables[0];
                    ddlSearchValue.DataTextField = "Cust_name";
                    ddlSearchValue.DataValueField = "Cust_name";
                    ddlSearchValue.DataBind();
                }
                ds.Dispose();
                GC.Collect();
            }
            else
            {
                ddlSearchValue.Visible = false;
                lblsearch.Text = "";
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
        dt.Dispose();
        GC.Collect();
        
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
                    BI.ExportExcel(dt, "Oustanding-Details");
                }
                else if (filetype == "PDF")
                {
                    BI.Export_PDF(dt, "Oustanding-Details");
                }
            }
            else
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('No Records Found', 'OS Details', function (r) {});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            }
        }
        else
        {
            string prompt = "<script>$(document).ready(function(){{jAlert('No Records Found', 'OS Details', function (r) {});}});</script>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
        }
    }

    protected void btnRdlc_Click(object sender, EventArgs e)
    {
       
        exportfile("PDF");
    }

    private void clear()
    {
        lblsearch.Visible = false;
        ddlSearchValue.Visible = false;       
        DivDatewise.Visible = false;
        DivSingleOption.Visible = false;
        lblFinalTotal.Text = "";
        
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try{
          
            DataTable dt = new DataTable();
            gvdetails.DataSource = dt;
            gvdetails.DataBind();
            selectvalues("Grid");
            dt.Dispose();
            GC.Collect();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        } 

       }
    private void selectvalues(string grd_rdlc)
    {
        try
        {
            lblFinalTotal.Text = "";
            DataSet dss = new DataSet();
            if (ddltype.SelectedValue.ToString() != "--Select--")
            {

                if (ddltype.SelectedValue.ToString() == "CustomerWise")
                {
                    ObjUBO.Flag = "Select-CustOS-CrDr";
                }

                else if (ddltype.SelectedValue.ToString() == "DateWise")
                {
                    ObjUBO.Flag = "Select-CustDateOS-CrDr";
                    ObjUBO.from_date = txtfromdate.Text.Substring(3, 2) + '/' + txtfromdate.Text.Substring(0, 2) + '/' + txtfromdate.Text.Substring(6, 4);
                    ObjUBO.todate = txttodate.Text.Substring(3, 2) + '/' + txttodate.Text.Substring(0, 2) + '/' + txttodate.Text.Substring(6, 4);
                }
                else if (ddltype.SelectedValue.ToString() == "AllCustomerWise")
                {
                    ObjUBO.Flag = "Select-AllCustOS-CrDr";
                }
                else if (ddltype.SelectedValue.ToString() == "AllCustomerDateWise")
                {
                    ObjUBO.Flag = "Select-AllCustDateOS-CrDr";
                    ObjUBO.from_date = txtfromdate.Text.Substring(3, 2) + '/' + txtfromdate.Text.Substring(0, 2) + '/' + txtfromdate.Text.Substring(6, 4);
                    ObjUBO.todate = txttodate.Text.Substring(3, 2) + '/' + txttodate.Text.Substring(0, 2) + '/' + txttodate.Text.Substring(6, 4);
                }
                
                ObjUBO.Ref_ID = ddlSearchValue.SelectedValue.ToString();

                
                if (grd_rdlc == "Grid")
                {
                    dss = BI.Load_Acc_Rpt(ObjUBO);
                    
                        if (dss.Tables[0].Rows.Count > 0)
                        {
                            gvdetails.DataSource = dss.Tables[0];
                            gvdetails.DataBind();
                            ViewState["dtdata"] = dss.Tables[0];
                            

                            int celno = 0, totalcelno=0;                          
                            celno = dss.Tables[0].Columns.IndexOf("Debit");
                           

                            gvdetails.FooterRow.Cells[celno].Text = "Total";
                            gvdetails.FooterRow.Cells[celno + 1].Text = dss.Tables[0].Compute("Sum(Debit)", "").ToString();
                            gvdetails.FooterRow.Cells[celno + 2].Text = dss.Tables[0].Compute("Sum(Credit)", "").ToString();
                            gvdetails.FooterRow.Cells[celno + 3].Text = dss.Tables[0].Compute("Sum(TDS)", "").ToString();
                            gvdetails.FooterRow.Cells[celno + 4].Text = dss.Tables[0].Compute("Sum(WriteOff)", "").ToString();
                            totalcelno = celno+4;

                            for (celno = celno + 0; celno <= totalcelno; celno++)
                            {
                                gvdetails.FooterRow.Cells[celno].Font.Bold = true;
                                gvdetails.FooterRow.Cells[celno].Font.Size = 13;
                                gvdetails.FooterRow.Cells[celno].ForeColor = Color.Red;
                            }
                            double Bal=  Convert.ToDouble(dss.Tables[0].Compute("Sum(Debit)", "").ToString()) - Convert.ToDouble(dss.Tables[0].Compute("Sum(Credit)", "").ToString()) - Convert.ToDouble(dss.Tables[0].Compute("Sum(TDS)", "").ToString()) - Convert.ToDouble(dss.Tables[0].Compute("Sum(WriteOff)", "").ToString());
                            if (Bal > 0)
                            {
                                lblFinalTotal.Text = Bal.ToString() + " -Amt in Debit";
                            }
                            else if (Bal < 0)
                            {
                                lblFinalTotal.Text = Bal.ToString() + " -Amt in Credit";
                            }
                            else
                                lblFinalTotal.Text = Bal.ToString();
                           
                            
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
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            
        }
        
    }
 

}