using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class GST_Imp_Exp_Invoice_Job_Search : ThemeClass
{
    AppSession aps = new AppSession();
   // GST_Imp_Invoice BI = new GST_Imp_Invoice();

    GST_Bill_Consolidate GBC = new GST_Bill_Consolidate();
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

            dss = GBC.BILL_IMPORT_JOB_INV_SEARCH(ObjUBO);

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
        //ID,IMP_EXP,Invoice_No
        string rowID = String.Empty;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string ID = this.gvdetails.DataKeys[e.Row.RowIndex]["ID"].ToString();
            string IMP_EXP = this.gvdetails.DataKeys[e.Row.RowIndex]["IMP_EXP"].ToString();
            string Invoice_No = this.gvdetails.DataKeys[e.Row.RowIndex]["Invoice_No"].ToString();

             e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
             e.Row.Attributes.Add("ondblclick", "open_GST_Imp_Exp_Inv_Job_Search_Update('" + ID + "','" + IMP_EXP + "','" + Invoice_No + "')");
            
          
             rowID = e.Row.RowIndex.ToString();
             e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
             e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + ID + "','" + Invoice_No + "','" + IMP_EXP + "')");
             
        }
    }
   
    private void load_Imp_name()
    {
        ddlCus_name.Items.Clear();
            DataSet ds = new DataSet();
            ObjUBO.BILL_TYPE = ddl_Type.SelectedValue.ToString();
            ObjUBO.Flag = "Customer_Name_Search_Select";
            ds = GBC.GST_Bill_Consolidate_Select(ObjUBO);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlCus_name.DataSource = ds.Tables[0];
                ddlCus_name.DataTextField = "CUSTOMER_NAME";
                ddlCus_name.DataValueField = "CUSTOMER_NAME";
                ddlCus_name.DataBind();
            }
            ddlCus_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlCus_name.SelectedIndex = 0;
       
    }
    protected void ddlbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_Imp_name();
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
        ObjUBO.CONSIGNEE_NAME = ddl_Type.SelectedValue.ToString();
        ObjUBO.Imp_Name = ddlCus_name.SelectedItem.Text;
        ObjUBO.Flag = "Grid_Search";
        ds1 = GBC.BILL_IMPORT_JOB_INV_SEARCH(ObjUBO);

        if (ds1.Tables[0].Rows.Count > 0)
        {
            gvdetails.DataSource = ds1.Tables[0];
            gvdetails.DataBind();
        }
        else
        {
            DataTable dt = new DataTable();
            gvdetails.DataSource = dt;
            gvdetails.DataBind();
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
        ds = GBC.IMP_EXP_Month(ObjUBO);

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

    protected void ddl_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_Imp_name();
    }
}