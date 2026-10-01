using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

using System.Text;
 

public partial class PaymentEntrySearch : ThemeClass
{
    AppSession aps = new AppSession();
    GST_Imp_Invoice BI = new GST_Imp_Invoice();
    Billing_UserBO ObjUBO = new Billing_UserBO();

    
    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };


    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        Load_GridSearch();
    }

    protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        txtsearch.Text = "";
        txtsearch.Visible = false;
        DivDatewise.Visible = false;
        lblsearch.Text = "";
        ddlSearchValue.Visible = false;
        if (ddltype.SelectedValue.ToString() == "PaymentNo" || ddltype.SelectedValue.ToString() == "PaymentVoucherNo" || ddltype.SelectedValue.ToString() == "JobNo" || ddltype.SelectedValue.ToString() == "CustomerName" || ddltype.SelectedValue.ToString() == "BillInvNo")
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
        else if (ddltype.SelectedValue.ToString() == "SelectBill-Invoice-No")
        {
            lblsearch.Text = "Bill/Inv wise";
            load_CustJob("BillInvNo");
        }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }

    public void Load_GridSearch()
    {
         try
        {
            DataSet dss = new DataSet();

          
                ObjUBO.MODE = "Select JournalEntry";

                ObjUBO.Flag = "ALlVoucher";
                
               

             dss = BI.JornalEntry_Search(ObjUBO);

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
         catch (Exception ex)
         {
             Connection.Error_Msg(ex.Message);
         }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dss = new DataSet();

            //if (ddltype.SelectedValue.ToString() != "0")
            //{
                ObjUBO.MODE = "Select JournalEntry";

                //if (ddltype.SelectedValue.ToString() == "PaymentNo")
                //    ObjUBO.Flag = "PaymentNo-Like";
                //else if (ddltype.SelectedValue.ToString() == "PaymentVoucherNo")
                //    ObjUBO.Flag = "PaymentVoucherNo-Like";
                //else if (ddltype.SelectedValue.ToString() == "JobNo")
                //    ObjUBO.Flag = "PaymentJobNo-Like";
                //else if (ddltype.SelectedValue.ToString() == "CustomerName")
                //    ObjUBO.Flag = "PaymentCustomer-Like";
                //else if (ddltype.SelectedValue.ToString() == "BillInvNo")
                //    ObjUBO.Flag = "BillInvNo-Like";
                //else if (ddltype.SelectedValue.ToString() == "Datewise")
                //{
                //    ObjUBO.Flag = "Payment-Datewise";
                //    ObjUBO.from_date = txtfromdate.Text;
                //    ObjUBO.todate = txttodate.Text;
                //}

                //else if (ddltype.SelectedValue.ToString() == "Monthwise")
                //{
                //    ObjUBO.Flag = "Payment-Monthwise";
                //    if (ddlSearchValue.SelectedValue.ToString() != "")
                //    {
                //        arr_Month = ddlSearchValue.SelectedValue.ToString().Split('-');
                //        ObjUBO.from_date = arr_Month[0];
                //        ObjUBO.todate = arr_Month[1];
                //    }
                //    else
                //    {
                //        ObjUBO.Flag = "All-Payments";
                        
                //    }
                //}
                
                    

                //else if (ddltype.SelectedValue.ToString() == "SelectCustomer")
                //    ObjUBO.Flag = "PaymentCustomer-Single";
                //else if (ddltype.SelectedValue.ToString() == "SelectJob")
                //    ObjUBO.Flag = "PaymentJob-Single";
                //else if (ddltype.SelectedValue.ToString() == "All")
                //    ObjUBO.Flag = "All-Payments";

                //else if (ddltype.SelectedValue.ToString() == "SelectBill-Invoice-No")
                //    ObjUBO.Flag = "SelectBill-Invoice-No";
                ObjUBO.Flag = "PaymentVoucherNo-Like";
                
                //ObjUBO.BILL_TYPE = Rd_Job_Type.SelectedValue.ToString();

                ObjUBO.FILE_REF_NO = txtsearch.Text;

                //if (ddltype.SelectedValue.ToString() == "SelectCustomer" || ddltype.SelectedValue.ToString() == "SelectJob" || ddltype.SelectedValue.ToString() == "SelectBill-Invoice-No")
                //{
                //    ObjUBO.FILE_REF_NO = ddlSearchValue.SelectedValue.ToString();
                //}



                dss = BI.JornalEntry_Search(ObjUBO);

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
               
            //}
            //else
            //{
            //    DataTable dt = new DataTable();
            //    gvdetails.DataSource = dt;
            //    gvdetails.DataBind();

            //}

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {
         
        ddltype.SelectedIndex = 0;
        txtfromdate.Text = "";
        DivDatewise.Visible = false;
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
        //if (gvdetails.Rows.Count > 0)
       // {
            e.Row.Cells[1].Visible = false;
        //}
      
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

          
            string values = this.gvdetails.DataKeys[e.Row.RowIndex]["JOURNAL_ID"].ToString();

            string PaymentVoucherNo = this.gvdetails.DataKeys[e.Row.RowIndex]["VOUCHER_NO"].ToString();

            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";

            e.Row.Attributes.Add("ondblclick", "open_JournalUpd('" + values + "','" + PaymentVoucherNo + "')");
          
            rowID = e.Row.RowIndex.ToString();
            e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
            e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + values + "','" + PaymentVoucherNo + "')");
        }

       
    }

    private void load_CustJob(string name_job)
    {
        try
        {
        ddlSearchValue.Visible = true;
        if (name_job == "CustName")
        {            
            ObjUBO.Flag = "Select-ImpExpCustomer-Payment";
        }
        else if (name_job == "Job")
        {
            
            ObjUBO.Flag = "Select-ImpExpJobNo-Payment";
        }
        else if (name_job == "BillInvNo")
        {
           
            ObjUBO.Flag = "Select-ImpExpBillInvNo-Payment";
        }        

        DataSet ds = new DataSet();

        ddlSearchValue.Items.Clear();
           
            ObjUBO.BILL_TYPE = Rd_Job_Type.SelectedValue.ToString();


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
                    ddlSearchValue.DataTextField = "JOB_NO";
                    ddlSearchValue.DataValueField = "JOB_NO";
                }
                else if (name_job == "BillInvNo")
                {
                    ddlSearchValue.DataTextField = "Bill_Inv_RefNo";
                    ddlSearchValue.DataValueField = "Bill_Inv_RefNo";
                }
                ddlSearchValue.DataBind();

            }
            //ddl.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            //ddl.SelectedIndex = 0;

            ds.Dispose();
            GC.Collect();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
   
     

    private void Load_Grid()
    {       
        try
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

        ds1.Dispose();
        GC.Collect();

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

     

    }
   
    private void Load_Month()
    {
         //string Working_Period = Session["WorkingPeriod"].ToString();
        ddlSearchValue.Visible = true;
        ddlSearchValue.Items.Clear();
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

        ddlSearchValue.Items.Insert(ddlSearchValue.Items.Count, new System.Web.UI.WebControls.ListItem(String.Empty, String.Empty));

        if (Connection.Company_License().ToLower() == "eri00247")
        {
            ddlSearchValue.SelectedValue = ds.Tables[1].Rows[1][0].ToString();
        }
        else
        {
            ddlSearchValue.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
        }
        ds.Dispose();
        GC.Collect();
    }

    protected void btnPdfPrint_Click(object sender, EventArgs e)
    {
 
        StringBuilder sb = new StringBuilder(); 
        DataSet dss = new DataSet();
        ObjUBO.MODE = "Select PaymentEntry";
        ObjUBO.Flag = "Select-PaymentSingle";
        ObjUBO.FILE_REF_NO = hdrowindex.Value;   

        dss = BI.Exp_Pay_Search(ObjUBO);
        if (dss.Tables.Count > 0)
        {
            sb.Append("<html><table border='1'>");
            sb.Append("<tr><td style='text-align:center' colspan='2'>Payment Voucher</td></tr><tr><td>Payment No:</td><td> " + dss.Tables[0].Rows[0]["Payment_VoucherNo"].ToString() + " </td></tr>");
            sb.Append("<tr><td>Payment Date:</td><td> " + dss.Tables[2].Rows[0]["Payment Date"].ToString() + " </td></tr>");
            sb.Append("<tr><td>Customer Name:</td><td> " + dss.Tables[0].Rows[0]["Customer_Name"].ToString() + " </td></tr>");
            sb.Append("<tr><td>Mode Of Payment:</td><td> " + dss.Tables[0].Rows[0]["PaymentMode"].ToString() + " </td></tr>");
            sb.Append("<tr><td>Received Amt:</td><td> " + dss.Tables[0].Rows[0]["TotalPaymentAmt"].ToString() + " </td></tr>");

            if (dss.Tables[0].Rows[0]["PaymentMode"].ToString() == "Cheque" || dss.Tables[0].Rows[0]["PaymentMode"].ToString() == "Net Banking")
            {
                sb.Append("<tr><td colspan='2'><br/><br/></td></tr><tr><td colspan='2'><table border='1'><tr><td>Bank Name</td><td> " + dss.Tables[0].Rows[0]["Bank"].ToString() + " </td><td>Branch</td><td> " + dss.Tables[0].Rows[0]["Branch"].ToString() + " </td> ");
                sb.Append("<td>Chq/Ref#</td><td> " + dss.Tables[0].Rows[0]["Chq_Net_RefNo"].ToString() + " </td><td>Chq/Ref Date</td><td> " + dss.Tables[0].Rows[0]["Chq_Net_Date"].ToString() + " </td></tr> </table> </td></tr>");
            }
            sb.Append("</table></html>");  
        }

        string File_name = "Payment" + hdrowindex.Value;

        BI.ConvStrPDF(sb, File_name);
        dss.Dispose();
        GC.Collect();

    }
         

}