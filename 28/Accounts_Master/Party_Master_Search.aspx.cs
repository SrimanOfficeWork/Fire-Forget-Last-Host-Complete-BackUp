using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Party_Master_Search : ThemeClass
{
    AppSession aps = new AppSession();
    DataTable dt = new DataTable();

    Party_Master_cs PM = new Party_Master_cs();
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
            load_Party_name();
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
            string Party_Name = this.gvdetails.DataKeys[e.Row.RowIndex]["PARTY_NAME"].ToString();
            string Party_Brno = this.gvdetails.DataKeys[e.Row.RowIndex]["PARTY_BRANCH_NO"].ToString();
            string Party_Id = this.gvdetails.DataKeys[e.Row.RowIndex]["PARTY_ID"].ToString();

            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("ondblclick", "open_Party_Master_Upd('" + Party_Name + "','" + Party_Brno + "','" + Party_Id + "')");

            rowID = e.Row.RowIndex.ToString();
            e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
            e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + Party_Brno + "')");

        }
    }
    private void load_Party_name()
    {
        ddlClient_name.Items.Clear();
        DataSet ds = new DataSet();
        ObjUBO.A15 = "Party_Name_Search_Select";
        ds = PM.Party_Master_Data(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlClient_name.DataSource = ds.Tables[0];
            ddlClient_name.DataTextField = "PARTY_NAME";
            ddlClient_name.DataValueField = "PARTY_NAME";
            ddlClient_name.DataBind();
        }
        ddlClient_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlClient_name.SelectedIndex = 0;
    }
    protected void ddlClient_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlBranch_No.Items.Clear();
        if (ddlClient_name.SelectedValue.ToString() != string.Empty)
        {
            DataSet ds = new DataSet();
            ObjUBO.A1 = ddlClient_name.SelectedValue.ToString();
            ObjUBO.A15 = "Client_Branch_Search_Select";
            ds = PM.Party_Master_Data(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlBranch_No.DataSource = ds.Tables[0];
                ddlBranch_No.DataTextField = "BR_SLNO";
                ddlBranch_No.DataValueField = "BR_SLNO";
                ddlBranch_No.DataBind();
            }
            ddlBranch_No.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlBranch_No.SelectedIndex = 0;
        }
    }
    protected void ddlBranch_No_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnSearch_Click(sender, e); 
    }
    private void Load_Grid()
    {
        DataSet ds1 = new DataSet();
        if (txtfromdate.Text != string.Empty || txttodate.Text != string.Empty)
        {
            ObjUBO.A2 = txtfromdate.Text;
            ObjUBO.A3 = txttodate.Text;
        }
        else
        {
            if (ddlmonth.SelectedItem.Text != string.Empty)
            {
                arr_Month = ddlmonth.SelectedValue.ToString().Split('-');
                ObjUBO.A2 = arr_Month[0];
                ObjUBO.A3 = arr_Month[1];
            }
            else
            {
                ObjUBO.A2 = txtfromdate.Text;
                ObjUBO.A3 = txttodate.Text;
            }
        }

        ObjUBO.A1 = ddlClient_name.SelectedValue.ToString();
        ObjUBO.A4 = ddlBranch_No.SelectedValue.ToString();
        ObjUBO.A5 = "Grid_Search";
        ds1 = PM.Party_Data_Search(ObjUBO);
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

        ddlmonth.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlmonth.SelectedIndex = 0;

    }

}