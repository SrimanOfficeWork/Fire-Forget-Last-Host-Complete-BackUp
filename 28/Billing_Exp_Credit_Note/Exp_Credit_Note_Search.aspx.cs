using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Exp_Credit_Note_Search : ThemeClass
{
    AppSession aps = new AppSession();
    GST_Exp_Invoice_Credit_Note BI = new GST_Exp_Invoice_Credit_Note();
    Billing_UserBO ObjUBO = new Billing_UserBO();

    public string Working_Period;

    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };

    string Start_date = string.Empty,End_date = string.Empty ,From_month = string.Empty,To_month = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        hdrowindex.Value = String.Empty;
        hdBill_invno.Value = String.Empty;

        if (!IsPostBack)
        {
            Load_Month();
           
            load_Exp_name();
            chk();
            btnSearch_Click(sender, e);
        }
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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (chkqs.Checked == true && ddltype.SelectedItem.Value !="0" && txtsearch.Text !=string.Empty )
        {
            DataSet dss = new DataSet();
            if (txtfromdate.Text != string.Empty || txttodate.Text != string.Empty)
            {
                ObjUBO.from_date = txtfromdate.Text;
                ObjUBO.todate = txttodate.Text;
            }
            else
            {
                if (ddlmonth.SelectedItem.Text != string.Empty)
                {
                    arr_Month = ddlmonth.SelectedValue.ToString().Split('-');
                    ObjUBO.from_date = arr_Month[0];
                    ObjUBO.todate = arr_Month[1];
                }
                else
                {
                    ObjUBO.from_date = txtfromdate.Text;
                    ObjUBO.todate = txttodate.Text;
                }
            }

            ObjUBO.CHARGE_NAME = ddltype.SelectedValue.ToString();
            ObjUBO.CONSIGNEE_NAME = txtsearch.Text;
            ObjUBO.Flag = "Quick_Search";
            dss = BI.BILL_EXPORT_JOB_INV_SEARCH(ObjUBO);

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
            Load_Grid();
            txtsearch.Text = string.Empty;
            chkqs.Checked = false;
            ddltype.SelectedIndex = -1;
            Session.Remove("Bill_EXP_MASTER_XL");
            Session.Remove("Bill_EXP_MASTER_Tally");
        }
        chk();

        lbljobcnt.Text = gvdetails.Rows.Count.ToString();
    }

     protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //Add CSS class on header row.
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        //Add CSS class on normal row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        //Add CSS class on alternate row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }

     protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
     {
         string jobno = string.Empty;
         string rowID = String.Empty;

         if (e.Row.RowType == DataControlRowType.DataRow)
         {
             string values = this.gvdetails.DataKeys[e.Row.RowIndex]["CREDIT_BILL_INV_NO"].ToString();
             string Bill_invno = this.gvdetails.DataKeys[e.Row.RowIndex]["Invoice_No"].ToString();
             
             e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
             e.Row.Attributes.Add("ondblclick", "open_GST_Exp_Credit_Note_Update('" + values + "','" + Bill_invno + "')");

             rowID = e.Row.RowIndex.ToString();
             e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
             e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + values + "','" + Bill_invno + "')");

             if (DataBinder.Eval(e.Row.DataItem, "Bill_Status").ToString() == "Y")
             {
                 e.Row.ForeColor = System.Drawing.Color.Blue;
             }
             else if (DataBinder.Eval(e.Row.DataItem, "Bill_Status").ToString() == "R")
             {
                 e.Row.ForeColor = System.Drawing.Color.Red;
             }
         }
     }

     private void load_Exp_name()
     {
             DataSet dss = new DataSet();
             ObjUBO.Flag = "Inv_Exp_Name_Select";
             dss = BI.Select_Exp_INV(ObjUBO);

             ddlExp_name.DataSource = dss.Tables[0];
             ddlExp_name.DataTextField = "Exp_Name";
             ddlExp_name.DataValueField = "Exp_Name";
             ddlExp_name.DataBind();
             ddlExp_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
             ddlExp_name.SelectedIndex = 0;
        
     }
     protected void ddlExp_name_SelectedIndexChanged(object sender, EventArgs e)
     {
         btnSearch_Click(sender, e);
     }
     private void Load_Grid()
     {
         DataSet ds1=new DataSet();
         if (txtfromdate.Text != string.Empty || txttodate.Text != string.Empty)
         {
             ObjUBO.from_date = txtfromdate.Text;
             ObjUBO.todate = txttodate.Text;
         }
         else
         {
             if (ddlmonth.SelectedItem.Text != string.Empty)
             {
                 arr_Month = ddlmonth.SelectedValue.ToString().Split('-');
                 ObjUBO.from_date = arr_Month[0];
                 ObjUBO.todate = arr_Month[1];
             }
             else
             {
                 ObjUBO.from_date = txtfromdate.Text;
                 ObjUBO.todate = txttodate.Text;
             }
         }

         ObjUBO.Exp_Name = ddlExp_name.SelectedItem.Text;
         //ObjUBO.CHARGE_NAME = Connection.Company_License();
         ObjUBO.Flag = "Grid_Search";
         ds1 = BI.BILL_EXPORT_JOB_INV_SEARCH(ObjUBO);

         gvdetails.DataSource = ds1.Tables[0];
         gvdetails.DataBind();
         
     }
    
     protected void ddlinvno_SelectedIndexChanged(object sender, EventArgs e)
     {
         Load_Grid();
     }
     private void Load_Month()
     {
         DataSet ds = new DataSet();
         ds = Common_CS.Load_Month();
         ddlmonth.DataSource = ds.Tables[0];
         ddlmonth.DataTextField = "TheMonth";
         ddlmonth.DataValueField = "TheMonth_No";
         ddlmonth.DataBind();

         ddlmonth.Items.Insert(ddlmonth.Items.Count, new ListItem(String.Empty, String.Empty));
         ddlmonth.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
     }
}