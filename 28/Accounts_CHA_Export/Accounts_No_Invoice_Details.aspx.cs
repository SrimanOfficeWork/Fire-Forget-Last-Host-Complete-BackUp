using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.IO;
using System.Text;


public partial class Accounts_CHA_Import_Accounts_No_Invoice_Details : ThemeClass
{
    Cha_Accounts Chrg = new Cha_Accounts();
    Global_variables ObjUBO = new Global_variables();
    DataSet ds = new DataSet();
    public string EXPORT_JOBNO;
    protected void Page_Load(object sender, EventArgs e)
    {
        EXPORT_JOBNO = Session["EXPORT_JOBNO"].ToString();
        if (!IsPostBack)
        {
            Gridbind();
        }
    }
    public void Gridbind()
    {
        ObjUBO.A2 = EXPORT_JOBNO;
        ObjUBO.A12 = "E";
        ObjUBO.A41 = "Select_Invoice_Details";
        gv_details.DataSource = Chrg.Bill_To_Party_Ins_Upd(ObjUBO);
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
            row.Cells[3].ToolTip = JobNo_Ps;
            if (e.Row.Cells[3].Text.ToString().Length > 35)
            {
                e.Row.Cells[3].Text = e.Row.Cells[3].Text.ToString().Substring(0, 35) + "...";
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