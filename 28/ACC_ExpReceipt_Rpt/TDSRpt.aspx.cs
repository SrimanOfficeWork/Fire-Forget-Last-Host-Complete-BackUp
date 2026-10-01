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


public partial class TDSRpt : ThemeClass
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
            ddlSearchValue.Visible = false;
            lblsearch.Visible = false;
            DataSet ds = new DataSet();


            ObjUBO.BILL_TYPE = Rd_Job_Type.SelectedValue.ToString();
            

            if (ddltype.SelectedValue.Contains("Single"))
            {
                ddlSearchValue.Visible = true;
                lblsearch.Visible = true;
                ddlSearchValue.Items.Clear();
                ObjUBO.Flag = "Select-Receipt-Customer";
                lblsearch.Text = "Customer:";

                ds = BI.Load_DDL(ObjUBO);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlSearchValue.DataSource = ds.Tables[0];
                    ddlSearchValue.DataTextField = "Customer_Name";
                    ddlSearchValue.DataValueField = "Customer_Name";
                    ddlSearchValue.DataBind();
                }
            }
            //else
            //{
            //    clear();
            //}

            ds.Dispose();
            GC.Collect();

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }
    //protected void Rd_Job_Type_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        btnCancel_Click(sender, e);

    //    }
    //    catch (Exception ex)
    //    {
    //        Connection.Error_Msg(ex.Message);
    //    }
    //}

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        clear();        
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
                    BI.ExportExcel(dt, "TDS-Details");
                }
                else if (filetype == "PDF")
                {
                    BI.Export_PDF(dt, "TDS-Details");
                }
            }
            else
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('No Records Found', 'TDS Details', function (r) {});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            }
        }
        else
        {
            string prompt = "<script>$(document).ready(function(){{jAlert('No Records Found', 'TDS Details', function (r) {});}});</script>";
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
        DataTable dt = new DataTable();
        gvdetails.DataSource = dt;
        gvdetails.DataBind();

        dt.Dispose();
        GC.Collect();
     
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
            DataSet dss = new DataSet();
            if (ddltype.SelectedValue.ToString() != "--Select--")
            {

                if (ddltype.SelectedValue.ToString() == "AllCustomerTDS")
                {
                    ObjUBO.Flag = "Select-AllCustomerTDS";
                }
                else if (ddltype.SelectedValue.ToString() == "TDSWithCert")
                {
                    ObjUBO.Flag = "Select-TDSWithCert";
                }
                else if (ddltype.SelectedValue.ToString() == "TDSWithoutCert")
                {
                    ObjUBO.Flag = "Select-TDSWithoutCert";
                }
                else if (ddltype.SelectedValue.ToString() == "SingleCustomerTDS")
                {
                    ObjUBO.Flag = "Select-SingleCustomerTDS";
                }
                else if (ddltype.SelectedValue.ToString() == "SingleTDSWithCert")
                {
                    ObjUBO.Flag = "Select-SingleTDSWithCert";
                }
                else if (ddltype.SelectedValue.ToString() == "SingleTDSWithoutCert")
                {
                    ObjUBO.Flag = "Select-SingleTDSWithoutCert";
                }

                ObjUBO.from_date = txtfromdate.Text.Substring(3, 2) + '/' + txtfromdate.Text.Substring(0, 2) + '/' + txtfromdate.Text.Substring(6, 4);
                ObjUBO.todate = txttodate.Text.Substring(3, 2) + '/' + txttodate.Text.Substring(0, 2) + '/' + txttodate.Text.Substring(6, 4);


                ObjUBO.BILL_TYPE = Rd_Job_Type.SelectedValue.ToString();
               

                ObjUBO.Ref_ID = ddlSearchValue.SelectedValue.ToString();  // customer name


                dss = BI.Load_DDL(ObjUBO);
                 
                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        gvdetails.DataSource = dss.Tables[0];
                        gvdetails.DataBind();
                        ViewState["dtdata"] = dss.Tables[0];

                        int celno = 0;
                        dss.Tables[0].Columns["TDS Amt"].ColumnName = "TDSAmt";
                        celno = dss.Tables[0].Columns.IndexOf("TDSAmt");

                        gvdetails.FooterRow.Cells[celno].Text = "Total";
                        gvdetails.FooterRow.Cells[celno + 1].Text = dss.Tables[0].Compute("Sum(TDSAmt)", "").ToString();                        
                        for (celno = celno + 0; celno < celno + 2; celno++)
                        {

                            gvdetails.FooterRow.Cells[celno].Font.Bold = true;
                            gvdetails.FooterRow.Cells[celno].Font.Size = 13;
                            gvdetails.FooterRow.Cells[celno].ForeColor = Color.Red;
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
       
    }
 

}