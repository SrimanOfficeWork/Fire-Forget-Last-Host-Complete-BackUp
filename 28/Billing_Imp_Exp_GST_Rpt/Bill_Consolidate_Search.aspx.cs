using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.Data.SqlClient;

public partial class Bill_Consolidate_Search : ThemeClass
{
    AppSession aps = new AppSession();
    GST_Bill_Consolidate BC = new GST_Bill_Consolidate();
    Billing_UserBO ObjUBO = new Billing_UserBO();

    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };

    string Start_date = string.Empty, End_date = string.Empty, From_month = string.Empty, To_month = string.Empty;
    public string Working_Period;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        Working_Period = Connection.WorkingPeriod();

        if (!IsPostBack)
        {
            Load_Month();
            Load_Customer_Name();
        }
    }
    protected void ddlCus_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlreportname.Items.Clear();
        if (ddlCus_name.SelectedValue.ToString() !=string.Empty)
        {
            DataSet ds = new DataSet();
            ObjUBO.BILL_TYPE = ddlcategory.SelectedValue.ToString();
            ObjUBO.Imp_Name = ddlCus_name.SelectedValue.ToString();
            ObjUBO.Flag = "Report_Name_Select";
            ds = BC.GST_Bill_Consolidate_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlreportname.DataSource = ds.Tables[0];
                ddlreportname.DataTextField = "REF_NAME";
                ddlreportname.DataValueField = "REF_NAME";
                ddlreportname.DataBind();
            }
        }
        ddlreportname.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlreportname.SelectedIndex = 0;
    }
    protected void ddlreportname_SelectedIndexChanged(object sender, EventArgs e)
    {
       ddlinv_no.Items.Clear();
      if(ddlreportname.SelectedValue.ToString() !=string.Empty)
      {
          DataSet ds = new DataSet();
          ObjUBO.BILL_TYPE = ddlcategory.SelectedValue.ToString();
          ObjUBO.Imp_Name = ddlCus_name.SelectedValue.ToString();
          ObjUBO.CHARGE_NAME = ddlreportname.SelectedValue.ToString();
          ObjUBO.Flag = "Search_Inv_No";
          ds = BC.GST_Bill_Consolidate_Select(ObjUBO);

          if (ds.Tables[0].Rows.Count > 0)
          {
              ddlinv_no.DataSource = ds.Tables[0];
              ddlinv_no.DataTextField = "BILL_INV_NO";
              ddlinv_no.DataValueField = "BILL_INV_NO";
              ddlinv_no.DataBind();
          }
      }
      ddlinv_no.Items.Insert(0, new ListItem(String.Empty, String.Empty));
      ddlinv_no.SelectedIndex = 0;
    }
    private void Grid_load()
    {
        DataSet ds = new DataSet();
        ObjUBO.BILL_TYPE = ddlcategory.SelectedValue.ToString();
        ObjUBO.Imp_Name = ddlCus_name.SelectedValue.ToString();
        ObjUBO.SHIPMENT_TYPE = ddlreportname.SelectedValue.ToString();
        ObjUBO.BILL_INV_NO = ddlinv_no.SelectedValue.ToString();
        ObjUBO.from_date = txtfromdate.Text;
        ObjUBO.todate = txttodate.Text;
        ds = BC.GST_BILL_CONSOLIDATE_SEARCH(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvdetails.DataSource = ds.Tables[0];
            gvdetails.DataBind();
        }
        else
        {
            DataTable dt = new DataTable();
            gvdetails.DataSource = dt;
            gvdetails.DataBind();
        }

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Grid_load();
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
        string rowID = String.Empty;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string values = this.gvdetails.DataKeys[e.Row.RowIndex]["IMP_EXP_ID"].ToString();
            string values2 = this.gvdetails.DataKeys[e.Row.RowIndex]["TYPE"].ToString();

            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("ondblclick", "open_Bill_Con_Search_Update('" + values + "','" + values2 + "')");

            rowID = e.Row.RowIndex.ToString();
            e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
            e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + values + "','" + values2 + "')");
        }


     }
    private void Load_Month()
     {
         DataSet ds = new DataSet();
         if (Connection.Company_License().ToLower() == "eri00314" || Connection.Company_License().ToLower() == "eri00247")
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
         ds = BC.IMP_EXP_Month(ObjUBO);

         ddlmonth.DataSource = ds.Tables[0];
         ddlmonth.DataTextField = "TheMonth";
         ddlmonth.DataValueField = "TheMonth_No";
         ddlmonth.DataBind();

         ddlmonth.Items.Insert(ddlmonth.Items.Count, new ListItem(String.Empty, String.Empty));

         if (Connection.Company_License() == "eri00314" || Connection.Company_License() == "eri00247")
         {
             ddlmonth.SelectedValue = ds.Tables[1].Rows[1][0].ToString();
         }
         else
         {
             ddlmonth.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
         }
     }
     protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
     {
         Load_Customer_Name();
     }
     private void Load_Customer_Name()
     {
         ddlCus_name.Items.Clear();
         ddlreportname.Items.Clear();
         ddlinv_no.Items.Clear();

         DataSet ds = new DataSet();
         ObjUBO.BILL_TYPE = ddlcategory.SelectedValue.ToString();
         ObjUBO.Flag = "Search_Name_Select";
         ds = BC.GST_Bill_Consolidate_Select(ObjUBO);
         if (ds.Tables[0].Rows.Count > 0)
         {
             ddlCus_name.DataSource = ds.Tables[0];
             ddlCus_name.DataTextField = "Customer_Name";
             ddlCus_name.DataValueField = "Customer_Name";
             ddlCus_name.DataBind();
         }
         ddlCus_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
         ddlCus_name.SelectedIndex = 0;
         ddlreportname.Items.Insert(0, new ListItem(String.Empty, String.Empty));
         ddlreportname.SelectedIndex = 0;
         ddlinv_no.Items.Insert(0, new ListItem(String.Empty, String.Empty));
         ddlinv_no.SelectedIndex = 0;
     }
}