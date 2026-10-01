using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BussinessObject;

public partial class Exchange_Rate_Search : ThemeClass
{
    AppSession aps = new AppSession();
    ExchangeRate_History ex_Rate = new ExchangeRate_History();
    DataSet ds = new DataSet();
    DataTable ddt = new DataTable();
    UserBO ObjUBO = new UserBO();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
      
        if (IsPostBack)
        {
            Grid_load();
        }

        if (!IsPostBack)
        {
            Load_Effective_From_Date();
           
        }
        //Grid_load();
    }

    private void Load_Effective_From_Date()
    {

        ObjUBO.Effect_From = txtCurrency.Text;
        ObjUBO.Currecy = txtCurrency.Text;
        ObjUBO.From_date = txtfromdate.Text == string.Empty ? "01/01/1900" : txtfromdate.Text;
        ObjUBO.Todate = txttodate.Text == string.Empty ? "01/01/1900" : txttodate.Text;
        //ObjUBO.from_date = txtfromdate.Text;
        //ObjUBO.to_date = txttodate.Text;
        ObjUBO.Month = "";
        ObjUBO.Year = "";
        ObjUBO.Ename = "Get_Effective_from";
        ds = ex_Rate.Reteive_All_ExRate(ObjUBO);

        ddlEffect_From.DataSource = ds.Tables[0];
        ddlEffect_From.DataTextField = "EXCHANGE_EFFECT_DT_FROM";
        ddlEffect_From.DataValueField = "EXCHANGE_EFFECT_DT_FROM";
        ddlEffect_From.DataBind();
        ddlEffect_From.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlEffect_From.SelectedIndex = 0;

        ddl_Month.DataSource = ds.Tables[1];
        ddl_Month.DataTextField = "MONTH";
        ddl_Month.DataValueField = "MONTH";
        ddl_Month.DataBind();
        ddl_Month.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddl_Month.SelectedIndex = 0;

        ddl_Year.DataSource = ds.Tables[2];
        ddl_Year.DataTextField = "YEAR";
        ddl_Year.DataValueField = "YEAR";
        ddl_Year.DataBind();
        ddl_Year.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddl_Year.SelectedIndex = 0;
    }

    protected void ddlEffect_From_SelectedIndexChanged(object sender, EventArgs e)
    {
        Grid_load();
    }
    protected void ddlreportname_SelectedIndexChanged(object sender, EventArgs e)
    {
        Grid_load();
    }
    private void Grid_load()
    {
        ObjUBO.Effect_From = ddlEffect_From.SelectedItem.Text;
        ObjUBO.Currecy = txtCurrency.Text;
        ObjUBO.From_date = txtfromdate.Text == string.Empty ? "01/01/1900" : txtfromdate.Text;
        ObjUBO.Todate = txttodate.Text == string.Empty ? "01/01/1900" : txttodate.Text;
        //ObjUBO.from_date = txtfromdate.Text;
        //ObjUBO.to_date = txttodate.Text;
        //ObjUBO.Month = ddl_Month.SelectedItem.Text.Substring(0,2);

        if (ddl_Month.SelectedItem.Text == "")
        {
            ObjUBO.Month = ddl_Month.SelectedItem.Text;
        }
        else
        {
            ObjUBO.Month = ddl_Month.SelectedItem.Text.Substring(0, 2);
        }
        ObjUBO.Year = ddl_Year.SelectedItem.Text;
        ObjUBO.Ename = "Select_All_NormalSearch";
        ds = ex_Rate.Reteive_All_ExRate(ObjUBO);

        gvdetails.DataSource = ds.Tables[0];
        gvdetails.DataBind();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Grid_load();
    }

     protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //Add CSS class on header row.
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        //Add CSS class on normal row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        //Add CSS class on alternate row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }

}