using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.IO;

public partial class Acc_Payment_Request : ThemeClass
{
    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();
    Payment_Request PR = new Payment_Request();

    DataSet ds = new DataSet();
    DataTable dt = new DataTable();

    public string Imp_Exp ,JOBNO ,JOBNO_PS;
    public int i;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        try
        {
            if (!IsPostBack)
            {
                Imp_Exp=Request.QueryString["IMP_EXP"].ToString();

                if ( Imp_Exp!= null && Imp_Exp != string.Empty)
                {
                    if (Imp_Exp == "I")
                    {
                        JOBNO=Connection.IMP_Jobno();
                    }
                    else if (Imp_Exp == "E")
                    {
                        JOBNO = Connection.EXP_Jobno();
                    }
                    Load_Grid(Imp_Exp, JOBNO, Session["JOBNO_PS"].ToString());
                }
                else
                { 
                
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }


    protected void Load_Grid_Click(object sender, EventArgs e)
    {

        try
        {
            Load_Grid(Request.QueryString["IMP_EXP"].ToString(), Request.QueryString["IMP_EXP"].ToString() == "I"
        ? Connection.IMP_Jobno()
        : Connection.EXP_Jobno(), Session["JOBNO_PS"].ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }

    private void Load_Grid(string Imp_Exp,string Jobno,string Jobno_Ps)
    {
        ObjUBO.A8 = Imp_Exp;
        ObjUBO.A9 = Jobno;
        ObjUBO.A10 = Jobno_Ps;
        ObjUBO.A50 = "Load_PR_Data";
        ds = PR.Payment_Request_Select(ObjUBO);
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
        string rowID = String.Empty;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string id = this.gv_details.DataKeys[e.Row.RowIndex]["BP_R_ID"].ToString();
            string REF_NO = this.gv_details.DataKeys[e.Row.RowIndex]["REF_NO"].ToString();
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("ondblclick", "open_Payment_Request('" + id + "')"); 
            rowID = e.Row.RowIndex.ToString();
            e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
            e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + id + "')");
            e.Row.Font.Bold = true;
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
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Payment Request', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Payment Request', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
   
}