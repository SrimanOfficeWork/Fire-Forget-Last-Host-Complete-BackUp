using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Vendor_Master_Search : ThemeClass
{

    AppSession aps = new AppSession();

    //GST_Charge_Master CH = new GST_Charge_Master();
    //GST_Expense_Charge_Master CH = new GST_Expense_Charge_Master();
    GST_Vendor_Master CH = new GST_Vendor_Master();
    
    Billing_UserBO ObjUBO = new Billing_UserBO();

    public string Name_Search;
    public int currentPageNumber;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        Div_Pagination.Visible = false;
        div_pagination1.Visible = false;

        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (hdn_A_to_Z_Search.Value != "")
        {
            Name_Search = hdn_A_to_Z_Search.Value;
        }
        else
        {
            Name_Search = txtCharge_name.Text;
        }

        hdn_A_to_Z_Search.Value = "";
        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (!IsPostBack)
        {
            btnSearch_Click(sender, e);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int pageno = 1;
        gridbind(pageno);
        int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
        Add_Pageno(ii);
    }
    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
        txtCharge_name.Text = "";
        Name_Search = "";
        btnSearch_Click(sender, e);
    }

    public void gridbind(int currentPageNumber1)
    {
        DataSet ds = new DataSet();

        ObjUBO.VENDOR_NAME = Name_Search;
        ObjUBO.Flag = "Grid_Data";

        ObjUBO.Party_Ref = Convert.ToString(currentPageNumber1);
        ObjUBO.REMARKS = Convert.ToString(gvdetails.PageSize);
        ObjUBO.BR_CODE_LOCATION = "";
        
        //ds = CH.Charge_Master_Select(ObjUBO);
        //ds = CH.GST_Expense_Charge_Master_Select(ObjUBO);
          ds = CH.GST_Vendor_Master_Select(ObjUBO);

        if (ds.Tables[0].Rows.Count > 0)
        {
            gvdetails.DataSource = ds.Tables[0];
            gvdetails.DataBind();

            Grid_Total(currentPageNumber1, CH.result);
        }
        else
        {
            DataTable dt = new DataTable();
            gvdetails.DataSource = dt;
            gvdetails.DataBind();
            lblTotalPages.Text = "0";
        }
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
    }

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //var row = e.Row;
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    string values = this.gvdetails.DataKeys[e.Row.RowIndex]["VEN_ID"].ToString();
        //    e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
        //    //e.Row.Attributes.Add("onclick", "opennew_Expense_chargemaster_edit('" + values + "')");
        //    e.Row.Attributes.Add("onclick", "opennew_Vendormaster_edit('" + values + "')");
        //}


        //////////////////////////////////////////

        //string jobno = string.Empty;
        string rowID = String.Empty;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            
            string values = this.gvdetails.DataKeys[e.Row.RowIndex]["VEN_ID"].ToString();


            string VEN_CODE= this.gvdetails.DataKeys[e.Row.RowIndex]["VEN_CODE"].ToString();

            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";

            //e.Row.Attributes.Add("ondblclick", "open_ExpensesPaymentEntrySearch_Update('" + values + "','" + ExpVoucherNo + "')");
            e.Row.Attributes.Add("ondblclick", "open_VendorMaster_Search_Update('" + values + "','" + VEN_CODE + "')");
            

            rowID = e.Row.RowIndex.ToString();
            e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
            e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + values + "','" + VEN_CODE + "')");


        }
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
            div_pagination1.Visible = true;
        }
        else if (gvdetails.Rows.Count == 0)
        {
            Div_Pagination.Visible = false;
            div_pagination1.Visible = false;

        }

        lblTotalPages.Text = Convert.ToString(totalRows);
        lblCurrentPage.Text = Convert.ToString(currentPageNumber1);
        int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));

        if (currentPageNumber1 == 1)
        {
            btnPrev.Visible = false;
            if (Int32.Parse(lblTotalPages.Text) > 10)
            {
                btnNext.Visible = true;
                btnLast.Visible = true;
            }
            else
            {
                btnNext.Visible = false;
                btnLast.Visible = false;
            }
        }
        else if (Int32.Parse(lblCurrentPage.Text) == ii)
        {
            btnNext.Visible = false;
            btnPrev.Visible = true;
        }
        else
        {
            btnPrev.Visible = true;

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