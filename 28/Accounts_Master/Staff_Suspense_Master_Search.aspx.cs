using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Staff_Suspense_Master_Search : ThemeClass
{
    AppSession aps = new AppSession();
    DataTable dt = new DataTable();

    Staff_Suspense_cs SP = new Staff_Suspense_cs();
    Global_variables ObjUBO = new Global_variables();

    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };

    string Start_date = string.Empty, End_date = string.Empty, From_month = string.Empty, To_month = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        hdrowindex.Value = String.Empty;
        hdBill_invno.Value = String.Empty;

        if (!IsPostBack)
        {
            Load_Month();
            Load_Staff_name();
            btnSearch_Click(sender, e);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Load_Grid();
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
            string values = this.gvdetails.DataKeys[e.Row.RowIndex]["SUSP_ID"].ToString();
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("ondblclick", "opennew_Staff_Suspense_Entry_Upd('" + values + "')");
            rowID = e.Row.RowIndex.ToString();
            e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
            e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + values + "')");
        }
    }
    private void Load_Staff_name()
    {
       DataSet ds = new DataSet();
       ddlstaff_name.Items.Clear();
       ObjUBO.A15 = "Staff_Name_Search_Select";
       ds = SP.Staff_Suspense_Data(ObjUBO);
       if (ds.Tables[0].Rows.Count > 0)
        {
            ddlstaff_name.DataSource = ds.Tables[0];
            ddlstaff_name.DataTextField = "STAFF_NAME";
            ddlstaff_name.DataValueField = "STAFF_NAME";
            ddlstaff_name.DataBind();
        }
       ddlstaff_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
       ddlstaff_name.SelectedIndex = 0;
    }
    protected void ddlImp_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnSearch_Click(sender, e);
    }
    private void Load_Grid()
    {
        DataSet ds1 = new DataSet();
        ObjUBO.A1 = ddlstaff_name.SelectedValue.ToString();
        ObjUBO.A2 = txt_suspno.Text; 
        if (txtfromdate.Text != string.Empty || txttodate.Text != string.Empty)
        {
            ObjUBO.A3 = txtfromdate.Text;
            ObjUBO.A4 = txttodate.Text;
        }
        else
        {
            if (ddlmonth.SelectedItem.Text != string.Empty)
            {
                arr_Month = ddlmonth.SelectedValue.ToString().Split('-');
                ObjUBO.A3 = arr_Month[0];
                ObjUBO.A4 = arr_Month[1];
            }
            else
            {
                ObjUBO.A3 = txtfromdate.Text;
                ObjUBO.A4 = txttodate.Text;
            }
        }
       
        ObjUBO.A9 = "Grid_Search";
        ds1 = SP.Staff_Suspense_Search(ObjUBO);
        if (ds1.Tables[0].Rows.Count > 0)
        {
            gvdetails.DataSource = ds1.Tables[0];
        }
        else
        {
            gvdetails.DataSource = dt;
        }
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
        ddlmonth.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
    }

}