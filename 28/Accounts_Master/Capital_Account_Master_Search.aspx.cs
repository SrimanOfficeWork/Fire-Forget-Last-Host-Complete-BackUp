using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Billing_Charge_Master_Search : ThemeClass
{
    AppSession aps = new AppSession();
    Capital_Account_Master_cs CA = new Capital_Account_Master_cs();
    Global_variables ObjUBO = new Global_variables();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {     
        aps.checkSession();
        if (!IsPostBack)
        {
            gridbind();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        gridbind();
    }
    public void gridbind()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjUBO.A3 = txtLedger_name.Text;
            ObjUBO.A7 = "Grid_Data";
            ds = CA.Capital_Search(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvdetails.DataSource = ds.Tables[0];
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
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var row = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string values = this.gvdetails.DataKeys[e.Row.RowIndex]["C_ID"].ToString();
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("onclick", "open_Capital_Acc_Master_Upd('" + values + "')");
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

}