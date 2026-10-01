using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.IO;


public partial class Export_Acc_Charge_Details : ThemeClass
{
    Cha_Accounts Chrg = new Cha_Accounts();
    Global_variables ObjUBO = new Global_variables();
    AppSession aps = new AppSession();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    public string JOBNO, JOBNO_PS;

    public int i;
    protected void Page_Load(object sender, EventArgs e)
    {

        aps.checkSession();
        try
        {
            JOBNO = Connection.EXP_Jobno();
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
        DataSet ds = new DataSet();
        ObjUBO.A2 = JOBNO;
        ObjUBO.A13 = JOBNO_PS;
        ObjUBO.A10 = "E";
        ObjUBO.A12 = "R";
        ObjUBO.A15 = "Load_Charge_Grid";
        ds = Chrg.charge_Data_Search_new(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[4].Rows.Count == 0)
            {

                Quotation_Ins();

            }
            else
            {
                Load_grid(ds);
            }
        }
        else
        {
            Quotation_Ins();
        }
    }

    private void Quotation_Ins()
    {
        //------------------Quotation_Ins---------------------------------------------------------------
        ObjUBO.A2 = JOBNO;
        ObjUBO.A3 = JOBNO_PS;
        ObjUBO.A10 = "E";
        ObjUBO.A40 = "Quotaion_Charge";
        Chrg.CHA_Quotation_Charge_Select(ObjUBO);
        //---------------------------------------------------------------------------------

        DataSet dss = new DataSet();
        ObjUBO.A2 = JOBNO;
        ObjUBO.A13 = JOBNO_PS;
        ObjUBO.A10 = "E";
        ObjUBO.A12 = "R";
        ObjUBO.A15 = "Load_Charge_Grid";
        dss = Chrg.charge_Data_Search_new(ObjUBO);
        Load_grid(dss);
    }
    private void Load_grid(DataSet ds)
    {
        if (ds.Tables[0].Rows.Count > 0)
        {
            gv_details.DataSource = ds.Tables[0];
            gv_details.DataBind();
        }
        else
        {
            gv_details.DataSource = dt;
            gv_details.DataBind();
        }
       
    }

   

    protected void gv_details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string rowID = String.Empty;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string values = this.gv_details.DataKeys[e.Row.RowIndex]["JOBNO"].ToString();
            string id = this.gv_details.DataKeys[e.Row.RowIndex]["CHARGE_ID"].ToString();
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("ondblclick", "open_Imp_Exp_Charge_Upd('" + values + "','" + id + "','" + 'E' + "')");
            rowID = e.Row.RowIndex.ToString();
            e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
            e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + values + "','" + id + "','" + 'E' + "')");

        }

    }
    protected void Load_Click(object sender, EventArgs e)
    {

        try
        {
            Load_Grid();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
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


    protected void chkQuotation_CheckedChanged(object sender, EventArgs e)
    {
        Quotation_Ins();
    }
}