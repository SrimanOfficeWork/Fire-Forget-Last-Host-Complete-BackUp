using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Acc_Charges_Master_N_Search : ThemeClass
{
    AppSession aps = new AppSession();
    DataTable dt = new DataTable();

    Acc_Charge_Master_New_cs CI = new Acc_Charge_Master_New_cs();
    Global_variables ObjUBO = new Global_variables();

    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };

    string Start_date = string.Empty, End_date = string.Empty, From_month = string.Empty, To_month = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        hdrowindex.Value = String.Empty;
        hdBill_invno.Value = String.Empty;

        if (!IsPostBack)
        {
            Load_Grid();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Load_Grid();
    }
    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string jobno = string.Empty;
        string rowID = String.Empty;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string values = this.gvdetails.DataKeys[e.Row.RowIndex]["CHRG_ID"].ToString();

            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("ondblclick", "open_Charge_Master_N_Upd('" + values + "')");

            rowID = e.Row.RowIndex.ToString();
            e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
            e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + values + "')");

        }
    }
    protected void ddlBranch_No_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnSearch_Click(sender, e); 
    }

    private void Load_Grid()
    {
        DataSet ds1 = new DataSet();
        ObjUBO.A1 = txtFilterName.Text.Trim();           
        ObjUBO.A2 = ddlFilterChargeType.SelectedValue;  
        ObjUBO.A3 = ddlFilterActive.SelectedValue;        
        ObjUBO.A4 = ddlFilterApplicableFor.SelectedValue; 
        ObjUBO.A5 = ddlFilterChargeCategory.SelectedValue;
        ObjUBO.A10 = "Load_Grid_Data";                 

        ds1 = CI.Charge_Master_Search(ObjUBO);

        if (ds1 != null && ds1.Tables.Count > 0
            && ds1.Tables[0].Rows.Count > 0)
        {
            gvdetails.DataSource = ds1.Tables[0];
        }
        else
        {
            gvdetails.DataSource = dt;
        }
        gvdetails.DataBind();
    }





    

}