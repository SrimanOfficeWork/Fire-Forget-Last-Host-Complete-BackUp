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

public partial class Accounts_SalesStatement_Ledger_TaxRpt : ThemeClass
{
    AppSession aps = new AppSession();
    GST_Imp_Invoice BI = new GST_Imp_Invoice();
    //Billing_UserBO ObjUBO = new Billing_UserBO();

    GST_Sales_Entry_cs BP = new GST_Sales_Entry_cs();
    Accounts_GST_Sales_Rpt_cs ObjAccRpt = new Accounts_GST_Sales_Rpt_cs();
    Global_variables ObjUBO = new Global_variables();
    


    public string Working_Period;

    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };

    string Start_date = string.Empty, End_date = string.Empty, From_month = string.Empty, To_month = string.Empty;


    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        Working_Period = Session["WorkingPeriod"].ToString();
        hdrowindex.Value = String.Empty;
        hdBill_invno.Value = String.Empty;
        if (!IsPostBack)
        {

            //Load_Month();
            //load_Imp_name();
            Load_Month();
            load_Cus_name();
            btnSearch_Click(sender, e);
            divsplsearch.Visible = false; //Spl. Search Not required

        }
    }

    protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
    {
        //LoadSearch_DDL();
    }

    //private void LoadSearch_DDL()
    //{
    //    try
    //    {
    //        txtsearch.Visible = false;
    //        DivDatewise.Visible = false;

    //        if (ddltype.SelectedValue != "--Select--" && ddltype.SelectedValue != "All")
    //        {
    //            lblsearch.Visible = true;
    //            ddlSearchValue.Visible = true;

    //            ObjUBO.BILL_TYPE = Rd_Job_Type.SelectedValue.ToString();

    //            if (ddltype.SelectedValue.ToString() == "CustomerWise")
    //            {
    //                ObjUBO.Flag = "Select-ImpExpCustomerWise";
    //                lblsearch.Text = "Customer:";
    //            }
    //            else if (ddltype.SelectedValue.ToString() == "BranchWise")
    //            {
    //                ObjUBO.Flag = "Select-ImpExpBranchWise";
    //                lblsearch.Text = "Branch:";
    //            }
    //            else if (ddltype.SelectedValue.ToString() == "DateWise")
    //            {

    //                lblsearch.Text = "Date Wise:";
    //                DivDatewise.Visible = true;
    //                ddlSearchValue.Visible = false;
    //            }
    //            else if (ddltype.SelectedValue.ToString() == "JobWise")
    //            {
    //                ObjUBO.Flag = "Select-ImpExpJobWise";
    //                lblsearch.Text = "Job No:";
    //            }

    //            else if (ddltype.SelectedValue.ToString() == "BillInvWise")
    //            {
    //                ObjUBO.Flag = "Select-ImpExpBillInvWise";
    //                lblsearch.Text = "Bill / Invoice No:";

    //            }

    //            DataSet ds = new DataSet();

    //            ddlSearchValue.Items.Clear();

    //            //ds = BI.Load_DDL(ObjUBO);
    //            ds = BI.Load_DDL_Accounts(ObjUBO);


    //            if (ds.Tables[0].Rows.Count > 0)
    //            {

    //                ddlSearchValue.DataSource = ds.Tables[0];

    //                if (ddltype.SelectedValue.ToString() == "CustomerWise")
    //                {
    //                    ddlSearchValue.DataTextField = "CustomerName";
    //                    ddlSearchValue.DataValueField = "CustomerName";
    //                }
    //                else if (ddltype.SelectedValue.ToString() == "BranchWise")
    //                {
    //                    ddlSearchValue.DataTextField = "BranchName";
    //                    ddlSearchValue.DataValueField = "BranchName";
    //                }

    //                else if (ddltype.SelectedValue.ToString() == "JobWise")
    //                {
    //                    ddlSearchValue.DataTextField = "jobno";
    //                    ddlSearchValue.DataValueField = "jobno";
    //                }
    //                else if (ddltype.SelectedValue.ToString() == "BillInvWise")
    //                {
    //                    ddlSearchValue.DataTextField = "BILL_INV_NO";
    //                    ddlSearchValue.DataValueField = "BILL_INV_NO";
    //                }
    //                ddlSearchValue.DataBind();

    //            }

    //            ds.Dispose();
    //            GC.Collect();
    //        }
    //        else
    //        {
    //            clear();

    //        }
    //        //ddl.Items.Insert(0, new ListItem(String.Empty, String.Empty));
    //        //ddl.SelectedIndex = 0;
    //    }
    //    catch (Exception ex)
    //    {
    //        Connection.Error_Msg(ex.Message);
    //    }

    //}

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
                    BI.ExportExcel(dt, "Sales-Statment");
                }
                else if (filetype == "PDF")
                {
                    BI.Export_PDF(dt, "Sales-Statment");
                }
            }
            else
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('No Records Found', 'Sales Statement', function (r) {});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            }
        }
        else
        {
            string prompt = "<script>$(document).ready(function(){{jAlert('No Records Found', 'Sales Statement', function (r) {});}});</script>";
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
        txtsearch.Text = "";
        txtsearch.Visible = false;
        DivDatewise.Visible = false;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            //selectvalues("Grid");
            MultiSelectValues("Grid");
            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }

    private void MultiSelectValues(string grd_rdlc)
    {
        try
        {
            DataSet dss = new DataSet();
            DataTable dt = new DataTable();
            if (txtfromdate.Text != string.Empty || txttodate.Text != string.Empty)
            {
                ObjUBO.A1 = txtfromdate.Text;
                ObjUBO.A2 = txttodate.Text;
            }
            else
            {
                if (ddlmonth.SelectedItem.Text != string.Empty)
                {
                    arr_Month = ddlmonth.SelectedValue.ToString().Split('-');
                    ObjUBO.A1 = arr_Month[0];
                    ObjUBO.A2 = arr_Month[1];
                }
                else
                {
                    ObjUBO.A1 = txtfromdate.Text;
                    ObjUBO.A2 = txttodate.Text;
                }
            }

            //if (chkqs.Checked == true && ddltype.SelectedItem.Value != "0" && txtsearch.Text != string.Empty)
            if (ddlCharge_name.SelectedValue.ToString() != "")
            {
                ObjUBO.A4 = "CHARGE_NAME";                           //Spl Condition Label Name 
                ObjUBO.A5 = ddlCharge_name.SelectedValue.ToString(); //Spl Condition Content

                arr = ObjUBO.A5.Split('~');  //Split option required
                ObjUBO.A5 = arr[0];// +'/' + arr[0] + '/' + arr[2];

            }
            else
            {
                ObjUBO.A4 = "";
                ObjUBO.A5 = "";
                txtsearch.Text = string.Empty;
                //chkqs.Checked = false;
                ddltype.SelectedIndex = -1;
            }
            ObjUBO.A3 = ddlCus_name.SelectedValue.ToString(); // Customer Name            

            ObjUBO.A6 = ddl_Category.SelectedValue.ToString(); // Import or Export
            ObjUBO.A7 = "Load_Accounts_Sales_Ledger_Tax_Rpt";                     //Load_Tally_Data//Load_Grid_Data
            //Additional Conditions Start from A11
            ObjUBO.A11 = ddlbranch_No.SelectedValue.ToString(); // Customer Branch
            ObjUBO.A12 = ddl_tax_type.SelectedValue.ToString(); // Tax Type T or N
            ObjUBO.A13 = ddl_Rpt_type.SelectedValue.ToString(); // Rpt Type means Report Sub Name

            ObjUBO.A14 = "A";//ddl_Approval.SelectedValue.ToString(); // APPROVAL OR UNAPPROVAL
            ObjUBO.A15 = "EXTRA1";//EXTRA FIELDS 1
            ObjUBO.A15 = "EXTRA2";//EXTRA FIELDS 2

            //MULTI_BILL_INV_SEARCH
            dss = ObjAccRpt.MULTI_BILL_INV_SEARCH(ObjUBO);

            if (dss.Tables[0].Rows.Count > 0)
            {
                gvdetails.DataSource = dss.Tables[0];
            }
            else
            {
                gvdetails.DataSource = dt;
            }
            gvdetails.DataBind();
            ViewState["dtdata"] = dss.Tables[0];

            int celno = 0;
            dss.Tables[0].Columns["GRAND_TOTAL"].ColumnName = "GRAND_TOTAL";//BillingAmt
            celno = dss.Tables[0].Columns.IndexOf("GRAND_TOTAL");

            gvdetails.FooterRow.Cells[celno].Text = "";
            gvdetails.FooterRow.Cells[celno + 1].Text = "";//dss.Tables[0].Compute("Sum(GRAND_TOTAL)", "").ToString();            


            for (celno = celno + 0; celno < celno + 2; celno++)
            {

                gvdetails.FooterRow.Cells[celno].Font.Bold = true;
                gvdetails.FooterRow.Cells[celno].Font.Size = 13;
                gvdetails.FooterRow.Cells[celno].ForeColor = Color.Red;
            }

            //chk();
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
                //ObjUBO.Flag = "Select-Sales-CustomerWise";
            }
            else if (ddltype.SelectedValue.ToString() == "BranchWise")
            {
                //ObjUBO.Flag = "Select-Sales-BranchWise";
            }
            else if (ddltype.SelectedValue.ToString() == "DateWise")
            {
                //ObjUBO.Flag = "Select-Sales-DateWise";

                //ObjUBO.from_date = txtfromdateOld.Text.Substring(3, 2) + '/' + txtfromdateOld.Text.Substring(0, 2) + '/' + txtfromdateOld.Text.Substring(6, 4);
                //ObjUBO.todate = txttodateOld.Text.Substring(3, 2) + '/' + txttodateOld.Text.Substring(0, 2) + '/' + txttodateOld.Text.Substring(6, 4);

            }
            else if (ddltype.SelectedValue.ToString() == "JobWise")
            {
                //ObjUBO.Flag = "Select-Sales-JobWise";
            }
            else if (ddltype.SelectedValue.ToString() == "BillInvWise")
            {
                //ObjUBO.Flag = "Select-Sales-BillInvWise";
            }
            else if (ddltype.SelectedValue.ToString() == "All")
            {
                //ObjUBO.Flag = "Select-AllSales";
            }

            //ObjUBO.BILL_TYPE = Rd_Job_Type.SelectedValue.ToString();


            //ObjUBO.Ref_ID = ddlSearchValue.SelectedValue.ToString();

            if (grd_rdlc == "Grid")
            {
                //dss = BI.Load_DDL(ObjUBO);// OLD ORIGINAL CODE
                //dss = BI.Load_DDL_Accounts(ObjUBO);
                if (dss.Tables[0].Rows.Count > 0)
                {
                    gvdetails.DataSource = dss.Tables[0];
                    gvdetails.DataBind();
                    ViewState["dtdata"] = dss.Tables[0];


                    int celno = 0;
                    dss.Tables[0].Columns["Billing Amt"].ColumnName = "BillingAmt";
                    celno = dss.Tables[0].Columns.IndexOf("BillingAmt");

                    gvdetails.FooterRow.Cells[celno].Text = "Total";
                    gvdetails.FooterRow.Cells[celno + 1].Text = dss.Tables[0].Compute("Sum(BillingAmt)", "").ToString();


                    for (celno = celno + 0; celno < celno + 2; celno++)
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

        }
        else
        {
            DataTable dt = new DataTable();
            gvdetails.DataSource = dt;
            gvdetails.DataBind();
            dt.Dispose();
            GC.Collect();
        }

        dss.Dispose();
        GC.Collect();
    }
    
    //private void selectvalues old Remove it(string grd_rdlc)
    //{
    //    DataSet dss = new DataSet();
    //    if (ddltype.SelectedValue.ToString() != "--Select--")
    //    {

    //        if (ddltype.SelectedValue.ToString() == "CustomerWise")
    //        {
    //            ObjUBO.Flag = "Select-Sales-CustomerWise";
    //        }
    //        else if (ddltype.SelectedValue.ToString() == "BranchWise")
    //        {
    //            ObjUBO.Flag = "Select-Sales-BranchWise";
    //        }
    //        else if (ddltype.SelectedValue.ToString() == "DateWise")
    //        {
    //            ObjUBO.Flag = "Select-Sales-DateWise";

    //            ObjUBO.from_date = txtfromdateOld.Text.Substring(3, 2) + '/' + txtfromdateOld.Text.Substring(0, 2) + '/' + txtfromdateOld.Text.Substring(6, 4);
    //            ObjUBO.todate = txttodateOld.Text.Substring(3, 2) + '/' + txttodateOld.Text.Substring(0, 2) + '/' + txttodateOld.Text.Substring(6, 4);

    //        }
    //        else if (ddltype.SelectedValue.ToString() == "JobWise")
    //        {
    //            ObjUBO.Flag = "Select-Sales-JobWise";
    //        }
    //        else if (ddltype.SelectedValue.ToString() == "BillInvWise")
    //        {
    //            ObjUBO.Flag = "Select-Sales-BillInvWise";
    //        }
    //        else if (ddltype.SelectedValue.ToString() == "All")
    //        {
    //            ObjUBO.Flag = "Select-AllSales";
    //        }

    //        ObjUBO.BILL_TYPE = Rd_Job_Type.SelectedValue.ToString();


    //        ObjUBO.Ref_ID = ddlSearchValue.SelectedValue.ToString();

    //        if (grd_rdlc == "Grid")
    //        {
    //            //dss = BI.Load_DDL(ObjUBO);// OLD ORIGINAL CODE
    //            dss = BI.Load_DDL_Accounts(ObjUBO);
    //            if (dss.Tables[0].Rows.Count > 0)
    //            {
    //                gvdetails.DataSource = dss.Tables[0];
    //                gvdetails.DataBind();
    //                ViewState["dtdata"] = dss.Tables[0];


    //                int celno = 0;
    //                dss.Tables[0].Columns["Billing Amt"].ColumnName = "BillingAmt";
    //                celno = dss.Tables[0].Columns.IndexOf("BillingAmt");

    //                gvdetails.FooterRow.Cells[celno].Text = "Total";
    //                gvdetails.FooterRow.Cells[celno + 1].Text = dss.Tables[0].Compute("Sum(BillingAmt)", "").ToString();


    //                for (celno = celno + 0; celno < celno + 2; celno++)
    //                {

    //                    gvdetails.FooterRow.Cells[celno].Font.Bold = true;
    //                    gvdetails.FooterRow.Cells[celno].Font.Size = 13;
    //                    gvdetails.FooterRow.Cells[celno].ForeColor = Color.Red;
    //                }


    //            }
    //            else
    //            {
    //                DataTable dt = new DataTable();
    //                gvdetails.DataSource = dt;
    //                gvdetails.DataBind();
    //            }
    //        }

    //    }
    //    else
    //    {
    //        DataTable dt = new DataTable();
    //        gvdetails.DataSource = dt;
    //        gvdetails.DataBind();
    //        dt.Dispose();
    //        GC.Collect();
    //    }

    //    dss.Dispose();
    //    GC.Collect();
    //}

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
    //private void Load_Month old not required, remove it()
    //{
    //    DataSet ds = new DataSet();
    //    if (Connection.Company_License().ToLower() == "eri00314" || Connection.Company_License().ToLower() == "eri00247")
    //    {
    //        arr = ("01-Apr-2016 - 31-Dec-2018").Split('-');
    //    }
    //    else
    //    {
    //        arr = Working_Period.Split('-');
    //    }
    //    Start_date = arr[0] + '-' + arr[1] + '-' + arr[2];
    //    End_date = arr[3] + '-' + arr[4] + '-' + arr[5];

    //    ObjUBO.from_date = Start_date;
    //    ObjUBO.todate = End_date;
    //    ObjUBO.Flag = "Month";
    //    ds = BI.IMP_EXP_Month(ObjUBO);

    //    ddlmonth.DataSource = ds.Tables[0];
    //    ddlmonth.DataTextField = "TheMonth";
    //    ddlmonth.DataValueField = "TheMonth_No";
    //    ddlmonth.DataBind();

    //    ddlmonth.Items.Insert(ddlmonth.Items.Count, new ListItem(String.Empty, String.Empty));

    //    if (Connection.Company_License() == "eri00314" || Connection.Company_License() == "eri00247")
    //    {
    //        ddlmonth.SelectedValue = ds.Tables[1].Rows[1][0].ToString();
    //    }
    //    else
    //    {
    //        ddlmonth.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
    //    }
    //}

    public void Load_Month()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        ds = Common_CS.Load_Month();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlmonth.DataSource = ds.Tables[0];
            ddlmonth.DataTextField = "TheMonth";
            ddlmonth.DataValueField = "TheMonth_No";
            ddlmonth.DataBind();

            ddlmonth.Items.Insert(ddlmonth.Items.Count, new ListItem(String.Empty, String.Empty));
            ddlmonth.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
        }
    }    


    private void load_Charge_Name()
    {
        ddlCharge_name.Items.Clear(); 
        DataSet ds = new DataSet();
        ObjUBO.A8 = "Get_Charge_name_With_Tax";
        ds=BP.Select_Inv(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlCharge_name.DataSource = ds.Tables[0];
            ddlCharge_name.DataTextField = "charge_name";
            ddlCharge_name.DataValueField = "charge_name";
            ddlCharge_name.DataBind();
        }
        ddlCharge_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlCharge_name.SelectedIndex = 0;
    }
    //private void load_Charge_Name_old Not Required in Future, remove it()
    //{
    //    ddlCharge_name.Items.Clear();
    //    ddlbranch_No.Items.Clear();

    //    DataSet ds = new DataSet();
    //    ObjUBO.Imp_Name = ddlCus_name.SelectedItem.ToString();
    //    ObjUBO.SHIPMENT_TYPE = ddl_Category.SelectedValue.ToString();
    //    ObjUBO.Flag = "Imp_Charge_Name";
    //    ds = BI.Select_IMP_INV(ObjUBO);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        ddlCharge_name.DataSource = ds.Tables[0];
    //        ddlCharge_name.DataTextField = "charge_name";
    //        ddlCharge_name.DataValueField = "charge_name";
    //        ddlCharge_name.DataBind();
    //    }
    //    if (ddlCus_name.SelectedItem.ToString() != string.Empty)
    //    {
    //        if (ds.Tables[1].Rows.Count > 0)
    //        {
    //            ddlbranch_No.DataSource = ds.Tables[1];
    //            ddlbranch_No.DataTextField = "BRANCH_NO_LOC";
    //            ddlbranch_No.DataValueField = "BRANCH_NO";
    //            ddlbranch_No.DataBind();
    //        }
    //    }

    //    ddlCharge_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
    //    ddlCharge_name.SelectedIndex = 0;
    //    ddlbranch_No.Items.Insert(0, new ListItem(String.Empty, String.Empty));
    //    ddlbranch_No.SelectedIndex = 0;
    //}
    //private void load_Imp_name Not required, remove it()
    //{
    //    ddlImp_name.Items.Clear();
    //    ddlCharge_name.Items.Clear();
    //    DataSet ds = new DataSet();
    //    ObjUBO.SHIPMENT_TYPE = ddl_Category.SelectedValue.ToString();
    //    ObjUBO.Flag = "GST_Inv_Imp_Name_Select";

    //    ds = BI.Select_IMP_INV(ObjUBO);

    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        ddlImp_name.DataSource = ds.Tables[0];
    //        ddlImp_name.DataTextField = "Customer_Name";
    //        ddlImp_name.DataValueField = "Customer_Name";
    //        ddlImp_name.DataBind();
    //    }
    //    ddlImp_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
    //    ddlImp_name.SelectedIndex = 0;

    //    ddlCharge_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
    //    ddlCharge_name.SelectedIndex = 0;
    //}

    //private void load_Location not required, remove it()
    //{
    //    ddlbranch_No.Items.Clear();
    //    if (ddlImp_name.SelectedItem.ToString() != string.Empty)
    //    {
    //        DataSet ds = new DataSet();
    //        ObjUBO.Imp_Name = ddlImp_name.SelectedItem.ToString();
    //        ObjUBO.Flag = "Imp_Charge_Name";
    //        ds = BI.Select_IMP_INV(ObjUBO);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            ddlbranch_No.DataSource = ds.Tables[0];
    //            ddlbranch_No.DataTextField = "charge_name";
    //            ddlbranch_No.DataValueField = "charge_name";
    //            ddlbranch_No.DataBind();
    //        }
    //    }
    //    ddlbranch_No.Items.Insert(0, new ListItem(String.Empty, String.Empty));
    //    ddlbranch_No.SelectedIndex = 0;
    //}

    //protected void ddlImp_name_SelectedIndexChanged not required remove it(object sender, EventArgs e)
    //{
    //    //load_Charge_Name();
    //}
    protected void ddl_Category_SelectedIndexChanged(object sender, EventArgs e)
    {        
        load_Cus_name();
    }

    protected void ddlCus_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlbranch_No.Items.Clear();
        //Clear();
        if (ddlCus_name.SelectedValue.ToString() != string.Empty)
        {
            Load_Branch();
            load_Charge_Name();
        }
    }
    private void Load_Branch()
    {
        ddlbranch_No.Items.Clear();
        DataSet dss = new DataSet();
        ObjUBO.A2 = ddlCus_name.SelectedValue.ToString();
        ObjUBO.A8 = "Cus_Branch_Select";
        dss = BP.Select_Inv(ObjUBO);
        if (dss.Tables[0].Rows.Count > 0)
        {
            ddlbranch_No.DataSource = dss.Tables[0];
            ddlbranch_No.DataTextField = "Branch_Name";
            ddlbranch_No.DataValueField = "Branch_Slno";
            ddlbranch_No.DataBind();
        }
        ddlbranch_No.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlbranch_No.SelectedIndex = 0;
    }
    private void load_Cus_name()
    {
        try
        {
            ddlCus_name.Items.Clear();
            DataSet dss = new DataSet();
            ObjUBO.A8 = "Cus_Name_Select";
            dss = BP.Select_Inv(ObjUBO);
            if (dss.Tables[0].Rows.Count > 0)
            {
                ddlCus_name.DataSource = dss.Tables[0];
                ddlCus_name.DataTextField = "Cus_Name";
                ddlCus_name.DataValueField = "Cus_Name";
                ddlCus_name.DataBind();
            }
            ddlCus_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlCus_name.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }


}