using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Staff_Master_Search : ThemeClass
{
    AppSession aps = new AppSession();
    DataTable dt = new DataTable();

    Staff_Master_cs SM = new Staff_Master_cs();
    Global_variables ObjUBO = new Global_variables();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        hdrowindex.Value = String.Empty;
        hdBill_invno.Value = String.Empty;

        if (!IsPostBack)
        {
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
            string values = this.gvdetails.DataKeys[e.Row.RowIndex]["STAFF_ID"].ToString();
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("ondblclick", "open_Staff_Master_UPD('" + values + "')");
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
       ds = SM.Staff_Master_Data(ObjUBO);
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
        ObjUBO.A1 = txtEmp_Id.Text;
        ObjUBO.A2 = ddlstaff_name.SelectedValue.ToString();
        ObjUBO.A3 = txtMobile_No.Text;
        ObjUBO.A4 = "Grid_Search";
        ds1 = SM.Staff_Master_Search(ObjUBO);
        if (ds1.Tables[0].Rows.Count > 0)
        {
            gvdetails.DataSource = ds1.Tables[0];
        }
        else {
            gvdetails.DataSource = dt;
        }
        gvdetails.DataBind();
    }
}