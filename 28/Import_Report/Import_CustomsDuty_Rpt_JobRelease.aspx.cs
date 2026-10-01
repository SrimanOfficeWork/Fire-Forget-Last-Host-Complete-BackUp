using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class Bulk_INV_ExRate_UpdateAll : ThemeClass
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    Transaction Transact = new Transaction();
    CustomDuty_Rpt CDR = new CustomDuty_Rpt();

    public int i;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        if (!Page.IsPostBack)
        {
            jobload();
        }
       
    }

    private void jobload()
    {
        
        DataSet ds = new DataSet();

        CDR.flag = "Bind_Filed_JOBNO";
        CDR.BRANCH_CODE = Session["GroupID"].ToString();

        ds = CDR.Report_data();

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlJobNo.DataSource = ds.Tables[0];
            ddlJobNo.DataValueField = "JOBNO";
            ddlJobNo.DataTextField = "JOBNO";
            ddlJobNo.DataBind();

            ddlJobNo.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddlJobNo.SelectedIndex = 0;
        }
        else
        {
            ddlJobNo.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddlJobNo.SelectedIndex = 0;
        }
    }

    protected void gv_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        //Add CSS class on normal row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        //Add CSS class on alternate row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }

    protected void gv_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Exrate Update All', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }


    protected void btnRelease_Click(object sender, EventArgs e)
    {
        DataSet ds1 = new DataSet();

        CDR.Jobno = ddlJobNo.SelectedItem.Text;
        CDR.From_date = "C";
        CDR.To_date = "";
        CDR.Imp_Name = Connection.Current_User();
        CDR.BRANCH_CODE = Connection.Current_Branch();
        CDR.flag = "Filed_Job_Release";
        ds1 = CDR.Report_data();

        if (CDR.result == 1)
        {
            Alert_msg("Job Released");
        }

    }
}