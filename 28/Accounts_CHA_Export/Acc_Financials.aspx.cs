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
    public string EXPORT_JOBNO, JOBNO_PS;
    protected void Page_Load(object sender, EventArgs e)
    {
        EXPORT_JOBNO = Connection.EXP_Jobno();
        Hdn_Jobno.Value = EXPORT_JOBNO;
        Hdn_Jobno_Ps.Value = Session["JOBNO_PS"].ToString();
        if (!IsPostBack)
        {
            Gridbind();
        }
    }
    public void Gridbind()
    {
        ObjUBO.A1 = EXPORT_JOBNO;
        ObjUBO.A2 = "E";
        ObjUBO.A24 = "Select_Invoice_Details";
        gv_details.DataSource = Chrg.Acc_Financial_Search(ObjUBO);
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