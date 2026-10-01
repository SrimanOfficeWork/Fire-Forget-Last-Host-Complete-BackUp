using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class ListPopups_Unit_ListPopup : ThemeClass
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 10;
    SqlConnection con;
    Manipulation mo;
    adminmaster Admin_mas = new adminmaster();
    public string Name_Search;
    AppSession aps = new AppSession();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        if (!string.IsNullOrEmpty(Request["unit"]))
        {
            HiddenField1.Value = Request.QueryString["unit"].ToString();
        }

        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (hdn_A_to_Z_Search.Value != "")
        {
            Name_Search = hdn_A_to_Z_Search.Value;

        }
        else
        {
            Name_Search = txtDescription.Text;

        }

        //hdn_A_to_Z_Search.Value = "";
        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (!IsPostBack)
        {
            int pageno = 1;

            gridbind(pageno);
            int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
            Add_Pageno(ii);
        }
    }


    private void gridbind(int currentPageNumber1)
    {
        Admin_mas.EUnit_id = "0";
        Admin_mas.EUnit_code = txtCode.Text;
        Admin_mas.EUnit_name = Name_Search;
        Admin_mas.Ename = "select_con";

        //string Query = "STATE_MASTER_SP_SELECT_CON";
        //gvdetails.DataSource = am.RetrieveAll_State_Master_LIKE(Query, txtStateCode.Text, txtStateName.Text);

        //gvdetails.DataBind();

        Admin_mas.startRowIndex = Convert.ToString(currentPageNumber1);
        Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
        //ds = erm.RetrieveAll_Adcode_MASTER();

        if (HiddenField1.Value == "ITEM_QTY" || HiddenField1.Value == "EXPORT_ITEM_QTY")
        {
            gvdetails.DataSource = Admin_mas.RetrieveAll_Unit_master_STD();
            gvdetails.DataBind();
        }
        else
        {
            gvdetails.DataSource = Admin_mas.RetrieveAll_Unit_master();
            gvdetails.DataBind();
        }
        Grid_Total(currentPageNumber1, Admin_mas.Total_Rows);


    }
    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
        //txtDescription.Text = "";
        //txtCode.Text = "";
        //Name_Search = "";

        btnSearch_Click(sender, e);
    }

    private int CalculateTotalPages(double totalRows)
    {
        int totalPages = (int)Math.Ceiling(totalRows / gvdetails.PageSize);

        return totalPages;
    }

    protected void ChangePage(object sender, CommandEventArgs e)
    {
        int currentpagenumber2 = 0;
        switch (e.CommandName)
        {
            case "Previous":
                currentpagenumber2 = Int32.Parse(lblCurrentPage.Text) - 1;

                break;

            case "Next":


                int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
                if (Int32.Parse(lblCurrentPage.Text) == ii)
                    currentpagenumber2 = ii;
                else
                    currentpagenumber2 = Int32.Parse(lblCurrentPage.Text) + 1;

                break;
            case "First":
                currentpagenumber2 = 1;

                break;
            case "Last":
                int i = CalculateTotalPages(double.Parse(lblTotalPages.Text));

                currentpagenumber2 = i;
                break;
        }

        gridbind(currentpagenumber2);
        //BindData(currentpagenumber2);
        //General_GridBind(currentpagenumber2);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int pageno = 1;
        string A_Z = Hdn_GetValue.Value;

        if (A_Z == "A_Z")
        {
            Hdn_GetValue.Value = "";
        }
        else
        {
            Name_Search = txtDescription.Text;
            hdn_A_to_Z_Search.Value = "";
        }

        gridbind(pageno);
        int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
        Add_Pageno(ii);
    }
    protected void gvdetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        Date_Time rep = new Date_Time();

        string str = rep.Replace(gvdetails.SelectedRow.Cells[2].Text);
        if (HiddenField1.Value == "ITEM_CTH_QTY1_CODE")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open1", "javascript:GetRowValue9('" + str + "')", true);
        }
        else if (HiddenField1.Value == "ITEM_CTH_QTY2_CODE")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open1", "javascript:GetRowValue10('" + str + "')", true);
        }
        else if (HiddenField1.Value == "BasicUnit")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open1", "javascript:GetRowValue('" + str + "')", true);
        }
        else if (HiddenField1.Value == "NCD_UNIT")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open2", "javascript:GetRowValue1('" + str + "')", true);
        }

        else if (HiddenField1.Value == "Safeguard_UNIT")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open3", "javascript:GetRowValue2('" + str + "')", true);
        }
        else if (HiddenField1.Value == "Tariff_UNIT")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open3", "javascript:GetRowValue_Tariff_Unit('" + str + "')", true);
        }
        else if (HiddenField1.Value == "CVD_UNIT")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open4", "javascript:GetRowValue3('" + str + "')", true);
        }
        else if (HiddenField1.Value == "Addl_GSI_UNIT")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open5", "javascript:GetRowValue4('" + str + "')", true);
        }
        else if (HiddenField1.Value == "Addl_SHE11_UNIT")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open6", "javascript:GetRowValue5('" + str + "')", true);
        }
        else if (HiddenField1.Value == "Addl_TTA_UNIT")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open6", "javascript:GetRowValue6('" + str + "')", true);
        }
        else if (HiddenField1.Value == "Addl_Health_CESS_UNIT")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open7", "javascript:GetRowValue7('" + str + "')", true);
        }
        else if (HiddenField1.Value == "CESS_UNIT")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open7", "javascript:GetRowValue8('" + str + "')", true);
        }
        else if (HiddenField1.Value == "OTHER_DUTY_UNIT")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open7", "javascript:GetRowValue11('" + str + "')", true);
        }
        else if (HiddenField1.Value == "GrossWeight")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open7", "javascript:GetRowValue_GrossWeight_Code('" + str + "')", true);
        }
        else if (HiddenField1.Value == "Netweight")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open7", "javascript:GetRowValue_NetWeight_Code('" + str + "')", true);
        }
        else if (HiddenField1.Value == "ITEM_QTY")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open11", "javascript:GetRowValue_Item_Qty('" + str + "')", true);
        }
        else if (HiddenField1.Value == "Item_unitcode")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open11", "javascript:GetRowValue_Item_unitcode('" + str + "')", true);
        }
        else if (HiddenField1.Value == "EXPORT_ITEM_QTY")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open11", "javascript:GetRowValue_EXPORT_ITEM_QTY('" + str + "')", true);
        }
        else if (HiddenField1.Value == "EXPORT_JOBBING")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open11", "javascript:GetRowValue_EXPORT_JOBBING('" + str + "')", true);
        }
        else if (HiddenField1.Value == "ANNEX_C_AIR_PKG")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open11", "javascript:GetRowValue_ANNEX_C_AIR_PKG('" + str + "')", true);
        }
        else if (HiddenField1.Value == "ANNEX_C_AIR_GR_WGT")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open11", "javascript:GetRowValue_ANNEX_C_AIR_GR_WGT('" + str + "')", true);
        }
        else if (HiddenField1.Value == "ANNEX_C_SEA")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open11", "javascript:GetRowValue_ANNEX_C_SEA('" + str + "')", true);
        }
        else if (HiddenField1.Value == "ANNEX_C_SEA_PACK")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open11", "javascript:GetRowValue_ANNEX_C_SEA_PACK('" + str + "')", true);
        }
        else if (HiddenField1.Value == "EXPORT_LICENSE")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open11", "javascript:GetRowValue_EXPORT_LICENSE('" + str + "')", true);
        }
        else if (HiddenField1.Value == "LICENSE_MASTER")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open11", "javascript:GetRowValue_LICENSE_MASTER('" + str + "')", true);
        }
        else if (HiddenField1.Value == "Export_Cess_details")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open7", "javascript:GetRowValue_Export_Cess_details('" + str + "')", true);
        }
        else if (HiddenField1.Value == "Export_Billing_Charge_wgt")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open7", "javascript:GetRowValue_Export_Billing_Charge_wgt('" + str + "')", true);
        }
        else if (HiddenField1.Value == "Gross_Wgt_Code")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open12", "javascript:GetRowValue_Import_Exbond_Gross_Wgt('" + str + "')", true);
        }
        else if (HiddenField1.Value == "Package_Code")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open13", "javascript:GetRowValue_Import_Exbond_PackCode('" + str + "')", true);
        }
        else if (HiddenField1.Value == "IGST_LEVY_UNIT")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open13", "javascript:GetRowValue_IGST_LEVY_UNIT('" + str + "')", true);
        }
        else if (HiddenField1.Value == "IGST_LEVY_COMPENSATION_CESS_UNIT")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open13", "javascript:GetRowValue_IGST_LEVY_COMPENSATION_CESS_UNIT('" + str + "')", true);
        }
        else if (HiddenField1.Value == "Tariff_Amount_Code")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open13", "javascript:GetRowValue_Tariff_Amount_Code('" + str + "')", true);
        }
        else if (HiddenField1.Value == "LICENSE_MASTER_ExpQty")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open11", "javascript:GetRowValue_LICENSE_MASTER_ExpQty('" + str + "')", true);
        }

    }
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";


            e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvdetails, "Select$" + e.Row.RowIndex);

        }
    }
   
    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
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
    public void Add_Pageno(int p)
    {
        if (p != 0)
        {
            ddlSelectPageno.Items.Clear();
            for (int i = 1; i <= p; i++)
            {

                ddlSelectPageno.Items.Add(Convert.ToString(i));
            }
        }
    }
    protected void ddlSelectPageno_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSelectPageno.SelectedValue != "")
        {
            ViewState["selected_change"] = "1";
            gridbind(Int32.Parse(ddlSelectPageno.SelectedValue.ToString()));

        }
    }
    public void Grid_Total(int currentPageNumber1, double totalRows)
    {
        if (gvdetails.Rows.Count > 0)
        {
            Div_Pagination.Visible = true;

        }
        else if (gvdetails.Rows.Count == 0)
        {
            Div_Pagination.Visible = false;

        }
        // get the total rows
        //totalRows = (double)Admin_mas.Total_Rows;

        //lblTotalPages.Text = CalculateTotalPages(totalRows).ToString();
        lblTotalPages.Text = Convert.ToString(totalRows);

        lblCurrentPage.Text = Convert.ToString(currentPageNumber1);

        int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));

        if (currentPageNumber1 == 1)
        {

            btnPrev.Visible = false;

            if (Int32.Parse(lblTotalPages.Text) > 0)
            {
                btnNext.Visible = true;
                btnLast.Visible = true;
            }
            else
            {
                btnNext.Visible = false;
                //btnLast.Visible = true;

            }

        }


        else if (Int32.Parse(lblCurrentPage.Text) == ii)
        {
            btnNext.Visible = false;
            //btnLast.Visible = false;
            btnPrev.Visible = true;

        }

        else
        {
            btnPrev.Visible = true;
            //btnLast.Visible = true;

            if (currentPageNumber == Int32.Parse(lblTotalPages.Text))
                btnNext.Visible = false;
            else btnNext.Visible = true;
        }
        if (ViewState["selected_change"] == "1")
        {
        }
        else
            Add_Pageno(ii);
    }
}