using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Credit_Note_Search : ThemeClass
{
    AppSession aps = new AppSession();
    GST_Imp_Invoice_Credit_Note BI = new GST_Imp_Invoice_Credit_Note();
    Billing_UserBO ObjUBO = new Billing_UserBO();

    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };

    string Start_date = string.Empty , End_date = string.Empty, From_month = string.Empty, To_month = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        
        hdrowindex.Value = String.Empty;
        hdBill_invno.Value = String.Empty;

        if (!IsPostBack)
        {
            Load_Month();
            load_Imp_name();
            chk();
            btnSearch_Click(sender, e);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        if (chkqs.Checked == true && ddltype.SelectedItem.Value != "0" && txtsearch.Text != string.Empty)
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
            dss = BI.BILL_IMPORT_JOB_INV_SEARCH(ObjUBO);

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
            string values = this.gvdetails.DataKeys[e.Row.RowIndex]["CREDIT_BILL_INV_NO"].ToString();
            string Bill_invno = this.gvdetails.DataKeys[e.Row.RowIndex]["Invoice_No"].ToString();

            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("ondblclick", "open_GST_Imp_Credit_Note_Update('" + values + "','" + Bill_invno + "')");
          
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
   
    private void load_Imp_name()
    {
            DataSet ds = new DataSet();
            ObjUBO.Flag = "Inv_Imp_Name_Select";
            ds = BI.Select_IMP_INV(ObjUBO);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlImp_name.DataSource = ds.Tables[0];
                ddlImp_name.DataTextField = "Imp_Name";
                ddlImp_name.DataValueField = "Imp_Name";
                ddlImp_name.DataBind();
            }
            ddlImp_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlImp_name.SelectedIndex = 0;
       
    }
    protected void ddlbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_Imp_name();
    }
    protected void ddlImp_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnSearch_Click(sender, e);
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

        ObjUBO.Imp_Name = ddlImp_name.SelectedItem.Text;
        ObjUBO.CHARGE_NAME = Connection.Company_License();
        ObjUBO.Flag = "Grid_Search";
        ds1 = BI.BILL_IMPORT_JOB_INV_SEARCH(ObjUBO);
        gvdetails.DataSource = ds1.Tables[0];
        gvdetails.DataBind();
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

        if (Connection.Company_License().ToLower() == "eri00247")
        {
            ddlmonth.SelectedValue = ds.Tables[1].Rows[1][0].ToString();
        }
        else
        {
            ddlmonth.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
        }
    }

}