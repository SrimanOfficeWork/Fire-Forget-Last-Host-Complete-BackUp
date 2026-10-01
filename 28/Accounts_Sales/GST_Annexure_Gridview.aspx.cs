using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessObject;
using System.Data;
public partial class GST_Annexure_Gridview : ThemeClass
{
    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();
    GST_Sales_Entry_cs SR = new GST_Sales_Entry_cs();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Gridbind();
        }

    }
    private void Gridbind()
    {

        if (!string.IsNullOrEmpty(Request.QueryString["Bill_Inv_No"]))
        {
            ObjUBO.A1 = Request.QueryString["Bill_Inv_No"].ToString();

        }
        DataSet ds = SR.Acc_Gst_Annexure_Search_Select(ObjUBO);
        if (ds != null && ds.Tables.Count > 0)
        {
            DataTable dtFull = ds.Tables[0];
            DataTable dtFixed = dtFull.DefaultView.ToTable(false, dtFull.Columns.Cast<DataColumn>().Take(6).Select(c => c.ColumnName).ToArray());
            DataTable dtScrollable = dtFull.DefaultView.ToTable(false, dtFull.Columns.Cast<DataColumn>().Skip(6).Select(c => c.ColumnName).ToArray());
            gvdetails_fixed.DataSource = dtFixed;
            gvdetails_fixed.DataBind();
            gvdetails_scrollable.DataSource = dtScrollable;
            gvdetails_scrollable.DataBind();
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
