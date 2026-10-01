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


public partial class ExpensesEntryRpt : ThemeClass
{
    AppSession aps = new AppSession();
    GST_Imp_Invoice BI = new GST_Imp_Invoice();
    Billing_UserBO ObjUBO = new Billing_UserBO();   

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();       
        
        hdrowindex.Value = String.Empty;
        hdBill_invno.Value = String.Empty;         
    }

    protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
    { 
        LoadSearch_DDL();  
    }

    private void LoadSearch_DDL()
    {
        try
        {
            DataSet ds = new DataSet();
           
            ObjUBO.BILL_TYPE = Rd_Job_Type.SelectedValue.ToString();

            DivDatewise.Visible = false;
            DivMultipleOption.Visible = false;
            DivSingleOption.Visible = false;
            if (ddltype.SelectedValue == "MultipleCriteria")
            {
                DivMultipleOption.Visible = true;
                DivSingleOption.Visible = false;
                ObjUBO.Flag = "Select-Expenses-Customer";
                ddlcustomer.Items.Clear();
                ds = BI.Load_DDL(ObjUBO);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlcustomer.DataSource = ds.Tables[0];
                    ddlcustomer.DataTextField = "Customer_Name";
                    ddlcustomer.DataValueField = "Customer_Name";
                    ddlcustomer.DataBind();
                    ddlcustomer.Items.Insert(0, new ListItem("All", "All"));
                    ddlcustomer.SelectedIndex = 0;
                }

                ObjUBO.Flag = "Select-Expenses-Heading";
               ddlExpensesHead.Items.Clear();
                ds = BI.Load_DDL(ObjUBO);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlExpensesHead.DataSource = ds.Tables[0];
                    ddlExpensesHead.DataTextField = "Exp_Details";
                    ddlExpensesHead.DataValueField = "Exp_Details";
                    ddlExpensesHead.DataBind();
                    ddlExpensesHead.Items.Insert(0, new ListItem("All", "All"));
                    ddlExpensesHead.SelectedIndex = 0;
                }
               
            }
            else
            {
                DivMultipleOption.Visible = false;
                DivSingleOption.Visible = true;

                if (ddltype.SelectedValue != "--Select--" && ddltype.SelectedValue != "All")
                {
                    lblsearch.Visible = true;
                    ddlSearchValue.Visible = true;
                   

                    if (ddltype.SelectedValue.ToString() == "CustomerWise")
                    {
                        ObjUBO.Flag = "Select-Expenses-Customer";
                        lblsearch.Text = "Customer:";
                    }

                    else if (ddltype.SelectedValue.ToString() == "DateWise")
                    {

                        lblsearch.Text = "Date Wise:";
                        DivDatewise.Visible = true;
                        ddlSearchValue.Visible = false;

                    }
                    else if (ddltype.SelectedValue.ToString() == "JobnoWise")
                    {
                        lblsearch.Text = "Job No:";
                        ObjUBO.Flag = "Select-Expenses-Jobno";
                    }

                    else if (ddltype.SelectedValue.ToString() == "VoucherWise")
                    {
                        ObjUBO.Flag = "Select-Expenses-Voucher";
                        lblsearch.Text = "Voucher No:";
                    }
                    else if (ddltype.SelectedValue.ToString() == "GivenBy")
                    {
                        lblsearch.Text = "Amt Given By:";
                        ObjUBO.Flag = "Select-Expenses-GivenBy";
                    }
                    else if (ddltype.SelectedValue.ToString() == "Assignee" || ddltype.SelectedValue.ToString() == "Vendor")
                    {
                        lblsearch.Text = "Amt SpendBy:";
                        ObjUBO.Flag = "Select-Expenses-Assignee";
                    }
                    else if (ddltype.SelectedValue.ToString() == "ExpensesHead")
                    {
                        lblsearch.Text = "Expenses Heads";
                        ObjUBO.Flag = "Select-Expenses-Heading";
                    } 

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
                        else if (ddltype.SelectedValue.ToString() == "JobnoWise")
                        {
                            ddlSearchValue.DataTextField = "job_no";
                            ddlSearchValue.DataValueField = "job_no";
                        }

                        else if (ddltype.SelectedValue.ToString() == "VoucherWise")
                        {
                            ddlSearchValue.DataTextField = "Exp_VoucherNo";
                            ddlSearchValue.DataValueField = "Exp_VoucherNo";
                        }
                        else if (ddltype.SelectedValue.ToString() == "GivenBy")
                        {
                            ddlSearchValue.DataTextField = "GivenBy";
                            ddlSearchValue.DataValueField = "GivenBy";
                        }
                        else if (ddltype.SelectedValue.ToString() == "Assignee" || ddltype.SelectedValue.ToString() == "Vendor")
                        {
                            ddlSearchValue.DataTextField = "Assignee";
                            ddlSearchValue.DataValueField = "Assignee";
                        }
                        else if (ddltype.SelectedValue.ToString() == "ExpensesHead")
                        {
                            ddlSearchValue.DataTextField = "Exp_Details";
                            ddlSearchValue.DataValueField = "Exp_Details";
                        }
                        ddlSearchValue.DataBind();

                    }
                }
                else
                {
                    clear();

                }

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
                    BI.ExportExcel(dt, "Expenses-Details");
                }
                else if (filetype == "PDF")
                {
                    BI.Export_PDF(dt, "Expenses-Details");
                }
            }
            else
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('No Records Found', 'Expenses Details', function (r) {});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            }
        }
        else
        {
            string prompt = "<script>$(document).ready(function(){{jAlert('No Records Found', 'Expenses Details', function (r) {});}});</script>";
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
        DivMultipleOption.Visible = false;
        //lblTotExp.Text = "";
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try{
           // lblTotExp.Text = "";
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
        try
        {
            DataSet dss = new DataSet();
            if (ddltype.SelectedValue.ToString() != "--Select--")
            {

                if (ddltype.SelectedValue.ToString() == "CustomerWise")
                {
                    ObjUBO.Flag = "Select-ImpExpCustomerWise-Expenses";
                }

                else if (ddltype.SelectedValue.ToString() == "DateWise")
                {
                    ObjUBO.Flag = "Select-ImpExpDateWise-Expenses";
                    ObjUBO.from_date = txtfromdate.Text.Substring(3, 2) + '/' + txtfromdate.Text.Substring(0, 2) + '/' + txtfromdate.Text.Substring(6, 4);
                    ObjUBO.todate = txttodate.Text.Substring(3, 2) + '/' + txttodate.Text.Substring(0, 2) + '/' + txttodate.Text.Substring(6, 4);

                }

                else if (ddltype.SelectedValue.ToString() == "JobnoWise")
                {
                    ObjUBO.Flag = "Select-ImpExpJobNo-Expenses";
                }
                else if (ddltype.SelectedValue.ToString() == "VoucherWise")
                {
                    ObjUBO.Flag = "Select-ImpExpVoucher-Expenses";
                }
                else if (ddltype.SelectedValue.ToString() == "GivenBy")
                {
                    ObjUBO.Flag = "Select-ImpExpGivenBy-Expenses";
                }
                else if (ddltype.SelectedValue.ToString() == "Assignee" || ddltype.SelectedValue.ToString() == "Vendor")
                {
                    ObjUBO.Flag = "Select-ImpExpAssignee-Expenses";
                }
                else if (ddltype.SelectedValue.ToString() == "ExpensesHead")
                {
                    ObjUBO.Flag = "Select-ImpExpHeader-Expenses";
                }
                else if (ddltype.SelectedValue.ToString() == "All")
                {
                    ObjUBO.Flag = "Select-AllExpenses";
                } 

                ObjUBO.BILL_TYPE = Rd_Job_Type.SelectedValue.ToString();
                ObjUBO.MODE = RdReportType.SelectedValue.ToString();


                ObjUBO.Ref_ID = ddlSearchValue.SelectedValue.ToString();

                if (ddltype.SelectedValue.ToString() == "MultipleCriteria")
                {
                    ObjUBO.Flag = "Select-Expenses-MultipleCriteria";
                    ObjUBO.from_date = txtfromdateMult.Text.Substring(3, 2) + '/' + txtfromdateMult.Text.Substring(0, 2) + '/' + txtfromdateMult.Text.Substring(6, 4);
                    ObjUBO.todate = txttodateMult.Text.Substring(3, 2) + '/' + txttodateMult.Text.Substring(0, 2) + '/' + txttodateMult.Text.Substring(6, 4);
                    ObjUBO.Ref_ID = ddlcustomer.SelectedValue.ToString(); // customer details
                    ObjUBO.BRANCH_CODE = ddlExpensesHead.SelectedValue.ToString();  // expenses header
                }

                if (grd_rdlc == "Grid")
                {
                    dss = BI.Load_DDL(ObjUBO);
                    
                        if (dss.Tables[0].Rows.Count > 0)
                        {
                            gvdetails.DataSource = dss.Tables[0];
                            gvdetails.DataBind();
                            ViewState["dtdata"] = dss.Tables[0];
                            dss.Tables[0].Columns["Exp Amt"].ColumnName = "expensesamt";

                            int celno = 0;                          
                            celno = dss.Tables[0].Columns.IndexOf("expensesamt"); 
                            gvdetails.FooterRow.Cells[celno].Text = "Total";
                            gvdetails.FooterRow.Cells[celno + 1].Text = dss.Tables[0].Compute("Sum(expensesamt)", "").ToString();
                            for (celno = celno + 0; celno < celno + 2; celno++)
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