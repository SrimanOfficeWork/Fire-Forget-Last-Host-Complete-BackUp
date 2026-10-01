using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessObject;
using System.Data;
public partial class Accounts_Cash_Payment_Request_Search_Entry : ThemeClass
{
    AppSession aps = new AppSession();
    Payment_Request PR = new Payment_Request();
    Global_variables ObjUBO = new Global_variables();
    DataTable dt = new DataTable();
    public string Working_Period;

    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };

    string Start_date = string.Empty, End_date = string.Empty, From_month = string.Empty, To_month = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        Working_Period = Connection.WorkingPeriod();

        if (!IsPostBack)
        {
            Load_Month();
            load_Imp_name();
            btnSearch_Click(sender, e);

        }
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataSet dss = new DataSet();
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

        if (chkqs.Checked == true && ddltype.SelectedItem.Value != "0" && txtsearch.Text != string.Empty)
        {
            ObjUBO.A4 = ddltype.SelectedValue.ToString();
            ObjUBO.A5 = txtsearch.Text;

        }
        else
        {
            ObjUBO.A4 = "";
            ObjUBO.A5 = "";
            txtsearch.Text = string.Empty;
            chkqs.Checked = false;
            ddltype.SelectedIndex = -1;
        }
        ObjUBO.A3 = ddlCus_name.SelectedValue.ToString();
        ObjUBO.A6 = ddl_Type.SelectedValue.ToString();
        ObjUBO.A7 = "Load_Grid_Data";
        dss = PR.Payment_Request_Search(ObjUBO);

        if (dss.Tables[0].Rows.Count > 0)
        {
            gvdetails.DataSource = dss.Tables[0];
        }
        else
        {
            gvdetails.DataSource = dt;
        }
        gvdetails.DataBind();
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
            string ID = this.gvdetails.DataKeys[e.Row.RowIndex]["ID"].ToString();
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("ondblclick", "Open_Payment_Request_Upd('" + ID + "')");
            rowID = e.Row.RowIndex.ToString();
            e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
            e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + ID + "')");

            e.Row.Font.Bold = true;
        }
    }
    private void load_Imp_name()
    {
        DataSet ds = new DataSet();
        ObjUBO.A5 = "";
        ObjUBO.A50 = "Load_Pay_Cusname";
        ds = PR.Payment_Request_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlCus_name.DataSource = ds.Tables[0];
            ddlCus_name.DataTextField = "Pay_CusName";
            ddlCus_name.DataValueField = "Pay_CusName";
            ddlCus_name.DataBind();
        }
        ddlCus_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlCus_name.SelectedIndex = 0;
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

  
}