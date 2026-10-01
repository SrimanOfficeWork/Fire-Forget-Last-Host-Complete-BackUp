using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.IO;
using System.Text;
using System.Data.SqlClient;

public partial class Accounts_CHA_Import_Acc_Financials : ThemeClass
{
    Cha_Accounts Chrg = new Cha_Accounts();
    Global_variables ObjUBO = new Global_variables();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    public string IMPORT_JOBNO, JOBNO_PS;
    protected void Page_Load(object sender, EventArgs e)
    {
        IMPORT_JOBNO = Connection.IMP_Jobno();
        Hdn_Jobno.Value = IMPORT_JOBNO;
        Hdn_Jobno_Ps.Value = Session["JOBNO_PS"].ToString();

        if (!IsPostBack)
        {
            Gridbind();
        }
    }
    public void Gridbind()
    {
        ObjUBO.A1 = IMPORT_JOBNO;
        ObjUBO.A2 = "I";
        ObjUBO.A24 = "Select_Invoice_Details";
        ds = Chrg.Acc_Financial_Search(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gv_details.DataSource = ds.Tables[0];
        }
        else
        {
            gv_details.DataSource = dt;
        }
        gv_details.DataBind();
      
    }

    protected void gv_details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string JobNo_Ps = string.Empty;
        var row = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            JobNo_Ps = this.gv_details.DataKeys[e.Row.RowIndex]["JOBNO_PS"].ToString();

            if (hdn_Grid_Disable.Value == "1")
            {
                e.Row.Enabled = false;
            }
            else
            {
                e.Row.Enabled = true;
                e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_details, "Select$" + e.Row.RowIndex.ToString()));
            }
        }
    }
    protected void gv_details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
}