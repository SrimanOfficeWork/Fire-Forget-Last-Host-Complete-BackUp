using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class ExpensesPaymentEntrySearch : ThemeClass
{
    AppSession aps = new AppSession();
    GST_Imp_Invoice BI = new GST_Imp_Invoice();
    Billing_UserBO ObjUBO = new Billing_UserBO();

    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };


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
        txtsearch.Text = "";
        txtsearch.Visible = false;
        DivDatewise.Visible = false;
        lblsearch.Text = "";
        ddlSearchValue.Visible = false;

        if (ddltype.SelectedValue.ToString() == "FRN" || ddltype.SelectedValue.ToString() == "ExpNo" || ddltype.SelectedValue.ToString() == "ExpVoucherNo" || ddltype.SelectedValue.ToString() == "JobNo" || ddltype.SelectedValue.ToString() == "CustomerName")
            {
                txtsearch.Visible = true;                 
            }

        else if (ddltype.SelectedValue.ToString() == "Datewise")
            {
                 
                DivDatewise.Visible = true;
               
            }
        else if (ddltype.SelectedValue.ToString() == "Monthwise")
            {
                lblsearch.Text = "Month wise";
                Load_Month();
            }
        else if (ddltype.SelectedValue.ToString() == "SelectCustomer")
            {
                lblsearch.Text = "Customer wise";
                load_CustJob("CustName");
            }
        else if (ddltype.SelectedValue.ToString() == "SelectJob")
            {
                lblsearch.Text = "JobNo wise";
                load_CustJob("Job");   
            }
        else if (ddltype.SelectedValue.ToString() == "0")
        {
            
        }
    }
 
    protected void btnSearch_Click(object sender, EventArgs e)
    {
                DataSet dss = new DataSet();

                if (ddltype.SelectedValue.ToString() != "0")
                {
                    ObjUBO.MODE = "Select Exp-Payment";

                    if (ddltype.SelectedValue.ToString() == "FRN")
                        ObjUBO.Flag = "FRN-Like";

                    else if (ddltype.SelectedValue.ToString() == "ExpNo")
                        ObjUBO.Flag = "ExpNo-Like";
                    else if (ddltype.SelectedValue.ToString() == "ExpVoucherNo")
                        ObjUBO.Flag = "ExpVoucherNo-Like";
                    else if (ddltype.SelectedValue.ToString() == "JobNo")
                        ObjUBO.Flag = "JobNo-Like";
                    else if (ddltype.SelectedValue.ToString() == "CustomerName")
                        ObjUBO.Flag = "Customer-Like";
                    else if (ddltype.SelectedValue.ToString() == "Datewise")
                    {
                        ObjUBO.Flag = "Datewise";
                        ObjUBO.from_date = txtfromdate.Text;
                        ObjUBO.todate = txttodate.Text;
                    }

                    else if (ddltype.SelectedValue.ToString() == "Monthwise")
                    {
                        ObjUBO.Flag = "Monthwise";
                        if (ddlSearchValue.SelectedValue.ToString() != "")
                        {
                            arr_Month = ddlSearchValue.SelectedValue.ToString().Split('-');
                            ObjUBO.from_date = arr_Month[0];
                            ObjUBO.todate = arr_Month[1];
                        }
                        else
                        {
                            ObjUBO.Flag = "All-Expenses";
                        }
                    }

                    else if (ddltype.SelectedValue.ToString() == "SelectCustomer")
                        ObjUBO.Flag = "Customer-Single";
                    else if (ddltype.SelectedValue.ToString() == "SelectJob")
                        ObjUBO.Flag = "Job-Single";
                    else if (ddltype.SelectedValue.ToString() == "All")
                        ObjUBO.Flag = "All-Expenses";

                    if (Rd_Job_Type.SelectedIndex == 0)
                    {
                        ObjUBO.BILL_TYPE = "Imp";
                    }
                    else
                    {
                        ObjUBO.BILL_TYPE = "Exp";
                    }


                    ObjUBO.FILE_REF_NO = txtsearch.Text;

                    if (ddltype.SelectedValue.ToString() == "SelectCustomer" || ddltype.SelectedValue.ToString() == "SelectJob" )
                    {
                        ObjUBO.FILE_REF_NO = ddlSearchValue.SelectedValue.ToString();
                    }
                  

                    dss = BI.Exp_Pay_Search(ObjUBO);

                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        gvdetails.DataSource = dss.Tables[0];
                    }
                    else
                    {
                        DataTable dt = new DataTable();
                        gvdetails.DataSource = dt;
                    }
                    gvdetails.DataBind();
                }
                else
                {
                    DataTable dt = new DataTable();
                    gvdetails.DataSource = dt;
                    gvdetails.DataBind();   
                   // Response.Redirect("ExpensesPaymentEntry.aspx?Page=Edit&Refno=13");
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
        string jobno = string.Empty;
        string rowID = String.Empty;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string values = this.gvdetails.DataKeys[e.Row.RowIndex]["Exp_ID"].ToString();
           

            string ExpVoucherNo = this.gvdetails.DataKeys[e.Row.RowIndex]["Exp_VoucherNo"].ToString();

            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
          
         e.Row.Attributes.Add("ondblclick", "open_ExpensesPaymentEntrySearch_Update('" + values + "','" + ExpVoucherNo + "')");       

            rowID = e.Row.RowIndex.ToString();
            e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
            e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + values + "','" + ExpVoucherNo + "')");
            
           
        }
    }

    private void load_CustJob(string name_job)
    {
        ddlSearchValue.Visible = true;
        if (name_job == "CustName")
        {
           
            ObjUBO.Flag = "Select-ImpExpCustomer";
        }
        else if (name_job == "Job")
        {
           
            ObjUBO.Flag = "Select-ImpExpJobNo";
        }

        DataSet ds = new DataSet();

        ddlSearchValue.Items.Clear();
            if (Rd_Job_Type.SelectedIndex == 0)
            {
                ObjUBO.BILL_TYPE = "Imp";               
            }
            else if (Rd_Job_Type.SelectedIndex == 1)
            {
                ObjUBO.BILL_TYPE = "Exp";              
            }
            ds = BI.Load_DDL(ObjUBO);

            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlSearchValue.DataSource = ds.Tables[0];

                if (name_job == "CustName")
                {
                    ddlSearchValue.DataTextField = "Customer_name";
                    ddlSearchValue.DataValueField = "Customer_name";
                }
                else if (name_job == "Job")
                {
                    ddlSearchValue.DataTextField = "JOb_no";
                    ddlSearchValue.DataValueField = "JOb_no";
                }
                ddlSearchValue.DataBind();

            }
            //ddl.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            //ddl.SelectedIndex = 0;
       
    }
    
    private void Load_Grid()
    {
        

        DataSet ds1 = new DataSet();
        if (txtfromdate.Text != string.Empty || txttodate.Text != string.Empty)
        {
            ObjUBO.from_date = txtfromdate.Text;
            ObjUBO.todate = txttodate.Text;
        }
        else
        {
            if (ddlSearchValue.SelectedItem.Text != string.Empty)
            {
                arr_Month = ddlSearchValue.SelectedValue.ToString().Split('-');
                ObjUBO.from_date = arr_Month[0];
                ObjUBO.todate = arr_Month[1];
            }
            else
            {
                ObjUBO.from_date = txtfromdate.Text;
                ObjUBO.todate = txttodate.Text;
            }
        }

        ObjUBO.Imp_Name = ddlSearchValue.SelectedItem.Text;
        ObjUBO.CHARGE_NAME = Connection.Company_License();
        ObjUBO.Flag = "Grid_Search";
        ds1 = BI.Exp_Pay_Search(ObjUBO);
        gvdetails.DataSource = ds1.Tables[0];
        gvdetails.DataBind();

    }
   
    private void Load_Month()
    {
         //string Working_Period = Session["WorkingPeriod"].ToString();
        string Start_date = string.Empty, End_date = string.Empty;

        DataSet ds = new DataSet();
        if (Connection.Company_License().ToLower() == "eri00247")
        {
            arr = ("01-Apr-2016 - 31-Dec-2018").Split('-');
        }
        else
        {
            arr = Session["WorkingPeriod"].ToString().Split('-');
        }
        Start_date = arr[0] + '-' + arr[1] + '-' + arr[2];
        End_date = arr[3] + '-' + arr[4] + '-' + arr[5];

        ObjUBO.from_date = Start_date;
        ObjUBO.todate = End_date;
        ObjUBO.Flag = "Month";
        ds = BI.IMP_EXP_Month(ObjUBO);

        ddlSearchValue.DataSource = ds.Tables[0];
        ddlSearchValue.DataTextField = "TheMonth";
        ddlSearchValue.DataValueField = "TheMonth_No";
        ddlSearchValue.DataBind();

        ddlSearchValue.Items.Insert(ddlSearchValue.Items.Count, new ListItem(String.Empty, String.Empty));

        if (Connection.Company_License().ToLower() == "eri00247")
        {
            ddlSearchValue.SelectedValue = ds.Tables[1].Rows[1][0].ToString();
        }
        else
        {
            ddlSearchValue.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
        }
    }

    protected void btnTempEntry_Click(object sender, EventArgs e)
    {

    }


}