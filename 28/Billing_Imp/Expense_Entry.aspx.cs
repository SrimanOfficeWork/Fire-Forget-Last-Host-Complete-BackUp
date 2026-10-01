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


public partial class Expense_Entry : ThemeClass
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    Billing_UserBO ObjUBO = new Billing_UserBO();

    public int i;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        if (!IsPostBack)
        {
            if (Request.QueryString["Job_no"] != null && Request.QueryString["Job_no"] != string.Empty && Request.QueryString["Type"] != null && Request.QueryString["Type"] != string.Empty)
            {
                DataSet dss = new DataSet();
                if (Request.QueryString["Type"].ToString() == "I")
                {
                    GST_Imp_Invoice BI = new GST_Imp_Invoice();
                    ObjUBO.JOBNO = Request.QueryString["Job_no"].ToString();
                    ObjUBO.Flag = "Expense_Entry";
                    dss = BI.Select_IMP_INV(ObjUBO);
                }
                else if (Request.QueryString["Type"].ToString() == "E")
                {
                    GST_Exp_Invoice BE = new GST_Exp_Invoice();
                    ObjUBO.JOBNO = Request.QueryString["Job_no"].ToString();
                    ObjUBO.Flag = "Expense_Entry";
                    dss = BE.Select_Exp_INV(ObjUBO);
                }

                if (dss.Tables[0].Rows.Count > 0)
                {
                    gvAll.DataSource = dss.Tables[0];
                    gvAll.DataBind();
                }
                else
                {
                    DataTable dt = new DataTable();
                    gvAll.DataSource = dt;
                    gvAll.DataBind();
                }
            }

        }
    }
    
    protected void gvAll_RowCreated(object sender, GridViewRowEventArgs e)
    {
        /* if (e.Row.RowType == DataControlRowType.Header)
             e.Row.CssClass = "header";

         if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
             e.Row.CssClass = "normal";

         if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
             e.Row.CssClass = "alternate";*/
    }
    protected void gvAll_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           
        }
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'BL_Container Details', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'BL_Container Details', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

}