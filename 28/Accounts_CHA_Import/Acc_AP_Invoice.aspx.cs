using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.IO;

public partial class Acc_AP_Invoice : ThemeClass
{
    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();
    Purchase_cs BI = new Purchase_cs();


    DataSet ds = new DataSet();
    DataTable dt = new DataTable();

    public string JOBNO,JOBNO_PS;
    public int i;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        try
        {
            JOBNO = Connection.IMP_Jobno();
            JOBNO_PS = Session["JOBNO_PS"].ToString();
            
            if (!IsPostBack)
            {
                Load_Grid();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void Load_Grid()
    {
        ObjUBO.A2 = JOBNO;
        ObjUBO.A3 = JOBNO_PS;
        ObjUBO.A4 = "I";
        ObjUBO.A19 = "Purchase_Inv_Select";
        ds = BI.Purchase_Entry_Select(ObjUBO);
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
   
    protected void gv_details_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void gv_details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
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

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GENERAL', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GENERAL', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

}