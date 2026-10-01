using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
public partial class Bank_Reconciliation_Entry_Search : ThemeClass
{
    AppSession aps = new AppSession();
    Bank_Reconciliation_Entry_cs BR = new Bank_Reconciliation_Entry_cs();

    Global_variables ObjUBO = new Global_variables();
    DataTable dt = new DataTable();

    public string Working_Period;

    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };

    string Start_date = string.Empty , End_date = string.Empty, From_month = string.Empty, To_month = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        Working_Period = Connection.WorkingPeriod();
        
        hdrowindex.Value = String.Empty;
        hdBill_invno.Value = String.Empty;

        if (!IsPostBack)
        {
            Load_Group_Name();
            Load_Month();
            load_Bank_name();
            chk();
            btnSearch_Click(sender, e);
        }
    }
    
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataSet dss = new DataSet();

        if (chkqs.Checked == true && ddltype.SelectedItem.Value != "0" && txtsearch.Text != string.Empty)
        {
            ObjUBO.A6 = ddltype.SelectedValue.ToString();
            ObjUBO.A7 = txtsearch.Text;
        }
        else
        {
            ObjUBO.A6 = "";
            ObjUBO.A7 = "";
            txtsearch.Text = string.Empty;
            chkqs.Checked = false;
            ddltype.SelectedIndex = -1;
        }
        ObjUBO.A1 = txtfromdate.Text;
        ObjUBO.A2 = txttodate.Text;
        ObjUBO.A3 = ddlBank_name.SelectedValue.ToString();
        ObjUBO.A4 = ddl_Type.SelectedValue.ToString();
        ObjUBO.A5 = ddllocation.SelectedValue.ToString();
        ObjUBO.A15 = "Load_Grid_Data";
        dss = BR.Bank_Reconciliation_Search(ObjUBO);
        
        if (dss.Tables[0].Rows.Count > 0)
        {
          gvdetails.DataSource = dss.Tables[0];
        }
        else
          {
             gvdetails.DataSource = dt;
         }
                gvdetails.DataBind();
        chk();
    }

    private void chk()
    {
        if (chkqs.Checked == true)
        {
            ddltype.Enabled = true;
            txtsearch.Enabled = true;
        }
        else
        {
            ddltype.Enabled = false;
            txtsearch.Enabled = false;
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
            string values, Trans_no, tbl_name, PR_type,Recon_Id;
            //values = this.gvdetails.DataKeys[e.Row.RowIndex]["TRANS_ID"].ToString();
            //Trans_no = this.gvdetails.DataKeys[e.Row.RowIndex]["TRANS_NO"].ToString();
            //tbl_name = this.gvdetails.DataKeys[e.Row.RowIndex]["TRANS_TBL"].ToString();
            //PR_type = this.gvdetails.DataKeys[e.Row.RowIndex]["P_Type"].ToString();
            Recon_Id = this.gvdetails.DataKeys[e.Row.RowIndex]["RECON_ID"].ToString();
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("ondblclick", "open_Bank_Reconciliation_Update('" + Recon_Id + "')");
            //if (PR_type == "R")
            //{
            //    if (tbl_name == "ACC_GST_BR_RECEIPT_ENTRY")
            //    {
            //        e.Row.Attributes.Add("ondblclick", "open_Bank_RC_Receipt_Entry_Upd('" + values + "','" + Trans_no + "')");
            //    }
            //    else if (tbl_name == "ACC_GST_BR_OTHER_RECEIPT_ENTRY")
            //    {
            //        e.Row.Attributes.Add("ondblclick", "open_Bank_RC_Receipt_Entry_Others_Upd('" + values + "','" + Trans_no + "')");
            //    }
            //    else if (tbl_name == "ACC_GST_BR_CASH_DEPOSITE_RECEIPT_ENTRY")
            //    {
            //        e.Row.Attributes.Add("ondblclick", "open_Bank_RC_Receipt_Entry_Cash_Upd('" + values + "','" + Trans_no + "')");
            //    }
            //}
            //else if (PR_type == "P")
            //{
            //    if (tbl_name == "ACC_GST_BP_PAYMENT_ENTRY_DEBITORS")
            //    {
            //        e.Row.Attributes.Add("ondblclick", "open_Bank_RC_Payment_Entry_Upd('" + values + "','" + Trans_no + "')");
            //    }
            //    else if (tbl_name == "ACC_GST_BP_OTHER_PAYMENT_ENTRY")
            //    {
            //        e.Row.Attributes.Add("ondblclick", "open_Bank_RC_Payment_Entry_Others_Upd('" + values + "','" + Trans_no + "')");
            //    }
            //    else if (tbl_name == "ACC_GST_PAYMENT_ENTRY_CASH_WITHDRAWAL")
            //    {
            //        e.Row.Attributes.Add("ondblclick", "open_Bank_RC_Payment_Entry_Cash_Upd('" + values + "','" + Trans_no + "')");
            //    }
            //}

        }
    }
    private void load_Bank_name()
    {
       ddlBank_name.Items.Clear(); 
       DataSet ds = new DataSet();

       ObjUBO.A6 = ddl_Type.SelectedValue.ToString();
       ObjUBO.A40 = "Bank_Name_Select";
       ds = BR.Bank_Reconciliation_Select(ObjUBO);
       if (ds.Tables[0].Rows.Count > 0)
       {
           ddlBank_name.DataSource = ds.Tables[0];
           ddlBank_name.DataTextField = "BANK_NAME";
           ddlBank_name.DataValueField = "ACCOUNT_NUMBER";
           ddlBank_name.DataBind();
       }
       ddlBank_name.Items.Insert(0, new ListItem("--All--", String.Empty));
       ddlBank_name.SelectedIndex = 0;
    }
    
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
   
    private void Load_Group_Name()
    {
        ddllocation.Items.Clear();
        if (Session["ClientGrpMst"] != null)
        {
            DataSet ds = (DataSet)Session["ClientGrpMst"];
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddllocation.DataSource = ds.Tables[0];
                ddllocation.DataTextField = "GROUP_NAME";
                ddllocation.DataValueField = "GROUP_ID";
                ddllocation.DataBind();
            }

        }
        ddllocation.Items.Insert(0, new ListItem("--All--", String.Empty));
        ddllocation.SelectedIndex = 0;
    }
}