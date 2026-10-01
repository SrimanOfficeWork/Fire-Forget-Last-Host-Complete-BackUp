using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using System.Web.Services;
using BussinessObject;

public partial class Export_Product_Master_Bulk : ThemeClass
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    UserBO ObjUBO = new UserBO();
    EXP_Item Item = new EXP_Item();

    public int i;
    public string currentuser;
    public string currentbranch;
    public string SELECT_TYPE, SELECT_BRANCH, EXPORT_JOBNO, COMPANY_IDD, Audit_YN = "";

    public string Item_Slno = string.Empty;
    DataTable dt_mapping = new DataTable();

    //Product_Export_Master PEM = new Product_Export_Master();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        COMPANY_IDD = Connection.COMPANYID();
        //if (Session["SELECT_TYPE"] != null)
        //{
        //    SELECT_TYPE = Session["SELECT_TYPE"].ToString();

        //    if (SELECT_TYPE == "Branchwise Job")
        //    {
        //        SELECT_BRANCH = currentbranch;
        //    }
        //    else
        //    {
        //        SELECT_BRANCH = "";
        //    }
        //}
        //else
        //{
        //    SELECT_BRANCH = "";
        //}

        if (Session["EXPORT_JOBNO"] != null)
        {
            EXPORT_JOBNO = Session["EXPORT_JOBNO"].ToString();
        }

        if (Connection.Audit_Logs(COMPANY_IDD) == "Y")
        {
            Audit_YN = "Y";
        }

        if (!Page.IsPostBack)
        {
            if (Session["EXPORT_JOBNO"] != null && Session["Inv_SL_No"] != null)
            {
                load_Item_desc();
            }
            //ddlinvno.Enabled = false;
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
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Billing Invoice', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Billing Invoice', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void gv_Item_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
        }
    }
    protected void gv_Item_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
    }
    private void load_Item_desc()
    {
        //Session["Inv_SL_No"]
        //Session["Item_SLNo"]

        DataSet ds = new DataSet();
        ObjUBO.JOBNO = EXPORT_JOBNO;
        ObjUBO.BRANCH_COMMON = Connection.Get_Company_Type();
        ObjUBO.Ename = "Bind_Invoice_Details";
        ObjUBO.Xml_A = "";
        ds = Item.RetrieveAll_Taxable_Value_Update(ObjUBO);

        // ----Audit Modified Data -----------------------------------
        if (Audit_YN == "Y")
        {
            DataTable dt_m2 = ds.Tables[0].Clone();
            Tbl_Filed_Modified_History(dt_m2);
        }


        if (ds.Tables[0].Rows.Count > 0)
        {
            gv_Item_Details.DataSource = ds.Tables[0];
            gv_Item_Details.DataBind();

            if (Audit_YN == "Y")
            {
                DataTable_Mapping_Controls((DataTable)ViewState["dt_Prev_Table"]);
            }

            //ddlinvno.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["INVOICE_NO"].ToString(), Session["Inv_SL_No"].ToString()));
            //ddlinvno.SelectedIndex = 0;
        }
        else
        {
            DataTable dt = new DataTable();
            gv_Item_Details.DataSource = dt;
            gv_Item_Details.DataBind();
        }

    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        Selected_Item();
        if (Item_Slno != string.Empty)
        {

            DataSet ds = new DataSet();
            ObjUBO.JOBNO = EXPORT_JOBNO;
            ObjUBO.BRANCH_COMMON = Connection.Get_Company_Type();
            ObjUBO.Ename = "Get_TaxableValue_Calc";
            ObjUBO.Xml_A = Item_Slno.TrimEnd(',');
            ds = Item.RetrieveAll_Taxable_Value_Update(ObjUBO);
            i = Item.result;

            if (i == 1)
            {
                // ----Audit Modified Data -----------------------------------
                if (Audit_YN == "Y")
                {
                    Audit_Modified_DataTableComparer();
                }
                //------------------------------------------------------------

                Alert_msg("Update Successfully!", "btnupdate");
            }
            else
            {
                Alert_msg("Not Updated");
            }


            //load_Item_desc();
        }
        else
        {
            Alert_msg("No Item Select", "btnupdate");
        }

    }

    string Selected_Item()
    {

        for (int i = 0; i < gv_Item_Details.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)gv_Item_Details.Rows[i].Cells[0].FindControl("D_CHECK");
            string ExRate = ((TextBox)gv_Item_Details.Rows[i].FindControl("txt_ExRate")).Text;

            if (chk.Checked)
            {
                Item_Slno += gv_Item_Details.Rows[i].Cells[1].Text + "-" + ExRate + ",";
            }

        }
        return Item_Slno;
    }


    #region Export Audit Logs

    private void Tbl_Filed_Modified_History(DataTable dt_Curr_tbl_struct)
    {
        try
        {
            ViewState["dt_Prev_Table"] = dt_Curr_tbl_struct;
            dt_mapping = dt_Curr_tbl_struct;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void Audit_Modified_DataTableComparer()
    {
        try
        {
            DataTable dt_Prev = (DataTable)ViewState["dt_Prev_Table"];
            DataTable dt_m2 = dt_Prev.Clone();
            DataTable dt_modified = DataTable_Mapping_Controls(dt_m2);
            DataTableComparer Dt_Change = new DataTableComparer();
            Dt_Change.GetMismatchedRowsFast_EXP(dt_Prev, dt_modified, "INVOICE_SLNO", "Bulk_Item_IGST_Update", EXPORT_JOBNO, hdinvslno.Value, "", currentuser, currentbranch);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private DataTable DataTable_Mapping_Controls(DataTable dt_mapping)
    {
        try
        {
            foreach (GridViewRow row in gv_Item_Details.Rows)
            {
                TextBox txt_Exrate_Rate = (TextBox)row.FindControl("txt_ExRate");
                DataRow dr = dt_mapping.NewRow();

                dr["INVOICE_SLNO"] = row.Cells[1].Text;
                dr["INVOICE_NO"] = row.Cells[2].Text;
                dr["INVOICE_CURRENCY"] = row.Cells[3].Text;
                dr["EXCHANGE_RATE"] = txt_Exrate_Rate.Text;

                dt_mapping.Rows.Add(dr);
                ViewState["dt_mapping"] = dt_mapping;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return dt_mapping;
    }

    #endregion
}