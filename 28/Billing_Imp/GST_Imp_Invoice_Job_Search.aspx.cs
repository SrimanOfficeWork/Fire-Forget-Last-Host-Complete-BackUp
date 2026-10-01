using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class GST_Imp_Invoice_Job_Search : ThemeClass
{
    AppSession aps = new AppSession();
    GST_Imp_Invoice BI = new GST_Imp_Invoice();
    Billing_UserBO ObjUBO = new Billing_UserBO();

    public string Working_Period;

    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };

    string Start_date = string.Empty , End_date = string.Empty, From_month = string.Empty, To_month = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        Working_Period = Session["WorkingPeriod"].ToString();
        
        hdrowindex.Value = String.Empty;
        hdBill_invno.Value = String.Empty;

        if (!IsPostBack)
        {
            Load_Month();
            load_Imp_name();
            chk();
            btnSearch_Click(sender, e);
            load_Pending_Job_Cnt();
            if (Connection.Company_License().ToLower() == "eri00399")
            {
                ddlMultiCompany.Visible = true;
            }
            if (Connection.Company_License().ToLower() == "eri01509")
            {
                btnLedgerDetails.Visible = true;
            }
        }
    }
    private void load_Pending_Job_Cnt()
    {
        DataSet ds1 = new DataSet();
        ObjUBO.Flag = "Pending_Job_cnt";
        ds1 = BI.Select_IMP_INV(ObjUBO);
        if (ds1.Tables[0].Rows.Count > 0)
        {
            lblcnt.Text = ds1.Tables[0].Rows[0][0].ToString();
        }
        else
        {
            lblcnt.Text = "0";
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
            if (dss.Tables[0].Rows.Count > 0)
            {
                lblInvcnt.Text = dss.Tables[1].Rows[0][0].ToString();
                lbleInvcnt.Text = dss.Tables[1].Rows[0][1].ToString();
            }
            else
            {

                lblInvcnt.Text = "";
                lbleInvcnt.Text = "";
            }


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
            string values = this.gvdetails.DataKeys[e.Row.RowIndex]["FILE_REF_NO"].ToString();
            string Bill_invno = this.gvdetails.DataKeys[e.Row.RowIndex]["Invoice_No"].ToString();

            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("ondblclick", "open_GST_Imp_Inv_Job_Search_Update('" + values + "','" + Bill_invno + "')");
          
            rowID = e.Row.RowIndex.ToString();
            e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
            e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + values + "','" + Bill_invno + "')");

           /* if (DataBinder.Eval(e.Row.DataItem, "Bill_Status").ToString() == "G")
            {
                e.Row.ForeColor = System.Drawing.Color.Green;
            }*/
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

        if (ddlMultiCompany.SelectedValue == "Transport" || ddlMultiCompany.SelectedValue == "eInvoice_Transport")
        {
            ObjUBO.Flag = "Grid_Search_Transport";
        }
        else
        {
            ObjUBO.Flag = "Grid_Search";
        }

        ds1 = BI.BILL_IMPORT_JOB_INV_SEARCH(ObjUBO);
        gvdetails.DataSource = ds1.Tables[0];
        gvdetails.DataBind();
        if (ds1.Tables[1].Rows.Count > 0)
        {
            lblInvcnt.Text = ds1.Tables[1].Rows[0][0].ToString();
            lbleInvcnt.Text = ds1.Tables[1].Rows[0][1].ToString();
        }
        else
        {
            lblInvcnt.Text = "";
            lbleInvcnt.Text = "";
        }


    }
   
    private void Load_Month()
    {
        DataSet ds = new DataSet();
        if (Connection.Company_License().ToLower() == "eri00247")
        {
            arr = ("01-Apr-2016 - 31-Dec-2018").Split('-');
        }
        else
        {
        arr = Working_Period.Split('-');
        }
        Start_date = arr[0] + '-' + arr[1] + '-' + arr[2];
        End_date = arr[3] + '-' + arr[4] + '-' + arr[5];

        ObjUBO.from_date = Start_date;
        ObjUBO.todate = End_date;
        ObjUBO.Flag = "Month";
        ds = BI.IMP_EXP_Month(ObjUBO);

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