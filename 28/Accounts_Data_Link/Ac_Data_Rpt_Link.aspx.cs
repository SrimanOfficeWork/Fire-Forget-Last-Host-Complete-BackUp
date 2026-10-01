using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Ac_Data_Rpt_Link : System.Web.UI.Page
{
    AppSession aps = new AppSession();
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        if (Request.QueryString["Accounts_Tally_Data"] != "" && Request.QueryString["Accounts_Tally_Data"] != null)
        {
            Accounts_Tally_Data BI = new Accounts_Tally_Data();
            BI.Open_Accounts_Tally_Data(
                Request.QueryString["ddlSearch_Cat"].ToString(),
                Request.QueryString["txtsearch"].ToString(),
                Request.QueryString["Imp_name"].ToString(),
                Request.QueryString["Fromdate"].ToString(),
                Request.QueryString["Todate"].ToString(),
                Request.QueryString["Month"].ToString(),
                Request.QueryString["Type"].ToString(),
                Request.QueryString["Imp_Exp"].ToString()
                );
        }
        else if (Request.QueryString["Journal_Entry_Data"] != "" && Request.QueryString["Journal_Entry_Data"] != null)
        {
            Journal_Entry_cs JE = new Journal_Entry_cs();
            JE.JV_Payment_Data_XL(
                Request.QueryString["JV_No"].ToString(),
                Request.QueryString["Fromdate"].ToString(),
                Request.QueryString["Todate"].ToString(),
                Request.QueryString["Month"].ToString()
                );
        }
        else if (Request.QueryString["Accounts_purchase_Tally_Data"] != "" && Request.QueryString["Accounts_purchase_Tally_Data"] != null)
        {
            Purchase_cs PT = new Purchase_cs();
            PT.Open_Purchase_Tally_Data(

                Request.QueryString["VenBillno"].ToString(),
                Request.QueryString["Vendor_name"].ToString(),
                Request.QueryString["Fromdate"].ToString(),
                Request.QueryString["Todate"].ToString(),
                Request.QueryString["Month"].ToString()
              
                );
        }
        else if (Request.QueryString["Accounts_Journal_Tally_Data"] != "" && Request.QueryString["Accounts_Journal_Tally_Data"] != null)
        {
            Journal_Entry_cs JE = new Journal_Entry_cs();
            JE.Open_Journal_Tally_Data(
                Request.QueryString["TransNo"].ToString(),
                Request.QueryString["Fromdate"].ToString(),
                Request.QueryString["Todate"].ToString(),
                Request.QueryString["Month"].ToString()
                );
        }
        else if (Request.QueryString["Accounts_Expense_Tally_Data"] != "" && Request.QueryString["Accounts_Expense_Tally_Data"] != null)
        {
            Expense_Entry_cs Ex = new Expense_Entry_cs();
            Ex.Open_Expense_Tally_Data(

                Request.QueryString["Voucher_RefNo"].ToString(),
                Request.QueryString["Cus_Name"].ToString(),
                Request.QueryString["JobNO"].ToString(),
                Request.QueryString["Fromdate"].ToString(),
                Request.QueryString["Todate"].ToString(),
                Request.QueryString["Month"].ToString()

                );
        }
        else if (Request.QueryString["Accounts_Payment_Tally_Data"] != "" && Request.QueryString["Accounts_Payment_Tally_Data"] != null)
        {
            Payment_Entry_Debitors PD = new Payment_Entry_Debitors();
            PD.Open_Payment_Tally_Data(
                Request.QueryString["PaymentNo"].ToString(),
                Request.QueryString["Party_Name"].ToString(),
                Request.QueryString["PaymentType"].ToString(),
                Request.QueryString["Fromdate"].ToString(),
                Request.QueryString["Todate"].ToString(),
                Request.QueryString["Month"].ToString()

                );
        }
        else if (Request.QueryString["Accounts_Receipt_Tally_Data"] != "" && Request.QueryString["Accounts_Receipt_Tally_Data"] != null)
        {
            ReceiptEntry_cs PD = new ReceiptEntry_cs();
            PD.Open_Receipt_Tally_Data(
                Request.QueryString["ReceiptNo"].ToString(),
                Request.QueryString["Party_Name"].ToString(),
                Request.QueryString["PaymentType"].ToString(),
                Request.QueryString["Fromdate"].ToString(),
                Request.QueryString["Todate"].ToString(),
                Request.QueryString["Month"].ToString()

                );
        }
        else if (Request.QueryString["Accounts_Credit_Tally_Data"] != "" && Request.QueryString["Accounts_Credit_Tally_Data"] != null)
        {
            GST_Credit_Note_Entry_cs CN = new GST_Credit_Note_Entry_cs();
            CN.open_Credit_Tally_Data(

                Request.QueryString["ddlSearch_Cat"].ToString(),
                Request.QueryString["txtsearch"].ToString(),
                Request.QueryString["Imp_name"].ToString(),
                Request.QueryString["Fromdate"].ToString(),
                Request.QueryString["Todate"].ToString(),
                Request.QueryString["Month"].ToString(),
                Request.QueryString["Imp_Exp"].ToString(),
                Request.QueryString["Flag"].ToString()

                );
        }
        else if (Request.QueryString["Cost_Sheet_Data"] != "" && Request.QueryString["Cost_Sheet_Data"] != null)
        {
            Cha_Accounts CN = new Cha_Accounts();
            CN.Open_Cost_Sheet(

                Request.QueryString["JOBNO_PS"].ToString(),
                Request.QueryString["JOBTYPE"].ToString(),
                Request.QueryString["Flag"].ToString()

                );
        }
        else if (Request.QueryString["Payment_Request_Data"] != "" && Request.QueryString["Payment_Request_Data"] != null)
        {
            Payment_Request PR = new Payment_Request();
            PR.Open_Payment_Request(

                Request.QueryString["ddlSearch_Cat"].ToString(),
                Request.QueryString["txtsearch"].ToString(),
                Request.QueryString["Imp_name"].ToString(),
                Request.QueryString["Fromdate"].ToString(),
                Request.QueryString["Todate"].ToString(),
                Request.QueryString["Month"].ToString(),
                Request.QueryString["Type"].ToString(),
                Request.QueryString["Imp_Exp"].ToString()

                );
        }
    }
}