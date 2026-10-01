using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Party_Credit_Limit_Search : ThemeClass
{
    AppSession aps = new AppSession();
    DataTable dt = new DataTable();

    Party_Master_cs PM = new Party_Master_cs();
    Global_variables ObjUBO = new Global_variables();

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
            string values = this.gvdetails.DataKeys[e.Row.RowIndex]["PARTY_ID"].ToString();

            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("ondblclick", "open_Party_Master_Cr_Limit_Upd('" + values + "')");
          
            rowID = e.Row.RowIndex.ToString();
            e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
            e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + values + "')");
            
        }
    }
    private void load_Party_name()
    {
        ddlParty_name.Items.Clear();
            DataSet ds = new DataSet();
            ObjUBO.A15 = "Party_Name_Search_Select";
            ds = PM.Party_Master_Data(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlParty_name.DataSource = ds.Tables[0];
                ddlParty_name.DataTextField = "PARTY_NAME";
                ddlParty_name.DataValueField = "PARTY_NAME";
                ddlParty_name.DataBind();
            }
            ddlParty_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlParty_name.SelectedIndex = 0;
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
        ObjUBO.A1 = ddlParty_name.SelectedValue.ToString();
        ObjUBO.A4 = "Grid_Search";
        ds1 = PM.Entry_Data_Search(ObjUBO);
        if (ds1.Tables[0].Rows.Count > 0)
        {
            gvdetails.DataSource = ds1.Tables[0];
        }
        else {
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