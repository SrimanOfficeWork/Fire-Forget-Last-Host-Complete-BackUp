using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Acc_Company_Info_Search : ThemeClass
{
    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();

    DataTable dt = new DataTable();
    Party_Master_cs PM = new Party_Master_cs();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        hdrowindex.Value = String.Empty;
        hdBill_invno.Value = String.Empty;

        if (!IsPostBack)
        {
            load_Client_name();
            Load_Grid();
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
            string values = this.gvdetails.DataKeys[e.Row.RowIndex]["CLIENT_NAME"].ToString();

            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("ondblclick", "open_Billing_Party_Master_Upd('" + values + "')");

            rowID = e.Row.RowIndex.ToString();
            e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
            e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + values + "')");

        }
    }
    private void load_Client_name()
    {
        ddlClient_name.Items.Clear();
        DataSet ds = new DataSet();
        ObjUBO.A15 = "Client_Name_Search_Select";
        ds = PM.Billing_Party_Data_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlClient_name.DataSource = ds.Tables[0];
            ddlClient_name.DataTextField = "Client_Name";
            ddlClient_name.DataValueField = "Client_Name";
            ddlClient_name.DataBind();
        }
        ddlClient_name.Items.Insert(0, new ListItem("--Select--", String.Empty));
        ddlClient_name.SelectedIndex = 0;
    }
   
    private void Load_Grid()
    {
        try
        {
            DataSet ds1 = new DataSet();
            ObjUBO.A1 = ddlClient_name.SelectedValue.ToString();
            ObjUBO.A3 = "";
            ObjUBO.A5 = "Grid_Search";
            ds1 = PM.Billing_Party_Data_Search(ObjUBO);
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
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    

}