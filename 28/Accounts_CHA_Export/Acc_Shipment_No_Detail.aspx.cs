using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.Collections.Generic;

public partial class Accounts_CHA_Export_Acc_Shipment_No_Detail : ThemeClass
{
    Cha_Accounts Chrg = new Cha_Accounts();
    Global_variables ObjUBO = new Global_variables();
    AppSession aps = new AppSession();
    DataTable dt = new DataTable();
    DataSet ds = new DataSet();
    public string EXPORT_JOBNO, ID, JOBNO_PS;
    public int i;
    private DataTable GridData
    {
        get { return ViewState["GridData"] as DataTable; }
        set { ViewState["GridData"] = value; }
    }

    private string SortDirection
    {
        get { return ViewState["SortDirection"] as string ?? "ASC"; }
        set { ViewState["SortDirection"] = value; }
    }

    private string SortExpression
    {
        get { return ViewState["SortExpression"] as string ?? ""; }
        set { ViewState["SortExpression"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        EXPORT_JOBNO = Session["EXPORT_JOBNO"].ToString();
        JOBNO_PS = Session["JOBNO_PS"].ToString();

        if (!IsPostBack)
        {
            Load_Shipment_No();
        }
    }

    private void Load_Shipment_No()
    {
       
        ObjUBO.A8 = "LOAD_SHIPMENT_NO";
        ObjUBO.A3 = JOBNO_PS;
        ObjUBO.A5 = Request.QueryString["SHIPMENTTYPE"].ToString();
        ds = Chrg.Bill_To_Shipment_Search(ObjUBO);

        if (ds.Tables[0].Rows.Count > 0)
        {
            txtShipment_pf.Text = ds.Tables[0].Rows[0]["SHIPMENT_PF"].ToString();
            txtShipment_No.Text = ds.Tables[0].Rows[0]["SHIPMENT_NO"].ToString();
            txtShipment_sf.Text = ds.Tables[0].Rows[0]["SHIPMENT_SF"].ToString();
        }
        if (ds.Tables[1].Rows.Count > 0)
        {
            GridData = ds.Tables[1];
            gv_details.DataSource = GridData;
            gv_details.DataBind();
        }

    }


    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        try
        {
            var checkedValues = new List<string>();
            foreach (GridViewRow row in gv_details.Rows)
            {
                var chk = (CheckBox)row.FindControl("chkSelect");
                if (chk != null && chk.Checked)
                {
                    checkedValues.Add(row.Cells[4].Text);
                }
            }
            HiddenField_index.Value = string.Join(",", checkedValues);
            if (HiddenField_index.Value != "")
            {
                ObjUBO.A6 = txtShipment_pf.Text;
                ObjUBO.A7 = txtShipment_sf.Text;
                ObjUBO.A1 = txtShipment_No.Text;
                ObjUBO.A3 = HiddenField_index.Value;
                ObjUBO.A5 = Request.QueryString["SHIPMENTTYPE"].ToString();
                ObjUBO.A8 = "UPDATE_SHIPMENT_NO";
                ds = Chrg.Bill_To_Shipment_Search(ObjUBO);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Alert_msg("Updated SuccessFully", "Shipment Invoice");
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    GridData = ds.Tables[1];
                    gv_details.DataSource = GridData;
                    gv_details.DataBind();
                }
            }
            else
            {
                Alert_msg("Select Ur JOb", "Shipment Invoice");
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }
    protected void gvdetails_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (GridData == null) return;

        // Toggle direction
        if (SortExpression == e.SortExpression)
            SortDirection = (SortDirection == "ASC") ? "DESC" : "ASC";
        else
            SortDirection = "ASC";

        SortExpression = e.SortExpression;

        GridData.DefaultView.Sort = e.SortExpression + " " + SortDirection;

        gv_details.DataSource = GridData;
        gv_details.DataBind();
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

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GENERAL', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
}