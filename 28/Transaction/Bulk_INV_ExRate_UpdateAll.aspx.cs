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

    public int i;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        if (!Page.IsPostBack)
        {
            Load_Invoice();
        }
        DataTable dt = new DataTable();
        GV.DataSource = dt;
        GV.DataBind();
    }

    private void Load_Invoice()
    {
        try
        {
            adminmaster erm = new adminmaster();
            DataSet ds = new DataSet();
            DataSet ds_admin = new DataSet();
            string New_Exrate = "0", Currency = "", str_Currency_list = "";

            Transact.JOBNO = Session["IMPORT_JOBNO"].ToString();
            Transact.INVOICE_NO = "";
            Transact.WORKING_PERIOD = Connection.Get_Company_Type();
            Transact.flag = "Distinct_Invoice_Currency_List";
            Transact.TERMS = "";
            Transact.INVOICE_SLNO = "";
            ds = Transact.RetrieveAll_Invoice_Details();

            if (ds.Tables[0].Rows.Count > 0)
            {
                erm.Eexchange_id = "0";
                erm.Ename = "Get_Invoice_Currency_Exrate";
                erm.EXCHANGE_CUR_CODE = "";
                erm.EXCHANGE_NAME = "";
                erm.EWorking_Period = Session["IMPORT_JOBNO"].ToString();
                ds_admin = erm.RetrieveAll_Exchange_master();

                DataView dv = new DataView(ds.Tables[0]);
                DataTable dt_cur_distinct = dv.ToTable(true, "INVOICE_CURRENCY");
                

                for (int i = 0; i <= dt_cur_distinct.Rows.Count - 1; i++)
                {
                    var query = from t in ds_admin.Tables[0].AsEnumerable()
                                where t.Field<string>("EXCHANGE_CUR_CODE").Equals(ds.Tables[0].Rows[i]["INVOICE_CURRENCY"].ToString())
                                select t;

                    if (query.Count() > 0)
                    {
                        DataTable dt_Curr = query.CopyToDataTable();
                        Currency = dt_Curr.Rows[0]["EXCHANGE_CUR_CODE"].ToString();
                        New_Exrate = dt_Curr.Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();
                    }
                    else
                    {
                        // NON STATNDARD CURRENCY 
                         //Currency = ds.Tables[0].Rows[i]["INVOICE_CURRENCY"].ToString();
                         //New_Exrate = ds.Tables[0].Rows[i]["INVOICE_EXRATE"].ToString();
                    }
                    str_Currency_list += Currency + "" + New_Exrate + ",";
                    var rowsToUpdate = ds.Tables[0].AsEnumerable().Where(r => r.Field<string>("INVOICE_CURRENCY") == Currency);

                    foreach (var row in rowsToUpdate)
                    {
                        row.SetField("NEW_EXRATE", New_Exrate);
                    }
                }
                //ViewState["Currency_list"] = str_Currency_list;
                gv_Details.DataSource = ds.Tables[0];
                gv_Details.DataBind();
                ViewState["dt_cur_distinct"] = ds.Tables[0];
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
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

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string str_Currency_list = "";
            foreach (GridViewRow row in gv_Details.Rows)
            {
                TextBox txt_ExRate = (TextBox)row.FindControl("txt_ExRate");
                if (txt_ExRate.Text != "")
                {
                    string curr_Name = row.Cells[1].Text;
                    str_Currency_list += curr_Name + "" + txt_ExRate.Text + ",";
                }
            }

            if (str_Currency_list != "")
            {
                DataSet dss = new DataSet();
                Transact.JOBNO = Session["IMPORT_JOBNO"].ToString();
                Transact.INVOICE_NO = str_Currency_list;
                Transact.WORKING_PERIOD = Connection.Get_Company_Type();
                Transact.flag = "Update_Invoice_exRate_Currency_List";
                Transact.TERMS = "";
                Transact.INVOICE_SLNO = "";
                dss = Transact.RetrieveAll_Invoice_Details();

                Alert_msg("Updated");
                Load_Invoice();
            }
            else
            {
                Alert_msg("New Ex.Rate - Should not be Empty");
            }

            
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        DataTable dd = (DataTable)ViewState["dt_cur_distinct"];
        var rowsToUpdate = dd.AsEnumerable();

        foreach (var row in rowsToUpdate)
        {
            row.SetField("NEW_EXRATE", "");
        }

        gv_Details.DataSource = dd;
        gv_Details.DataBind();
    }
}