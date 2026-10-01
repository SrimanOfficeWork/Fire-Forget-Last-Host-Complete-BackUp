using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessObject;
using System.Data;

public partial class Acc_GL_ListPopup_Orgainzation : ThemeClass
{
    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();
    Acc_Charge_Master_New_cs CM = new Acc_Charge_Master_New_cs();

    string Name_Search;
    public int currentPageNumber;
    public double totalRows;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        if (!Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["Name"]))
            {
                hdn.Value = Request.QueryString["Name"].ToString();
            }
            if (!string.IsNullOrEmpty(Request["from"]))
            {
                if (Request["from"].Trim() == "expired")
                {
                    Response.Write("<script>self.close();</script>");
                }
            }
           // Response.AppendHeader("Refresh", ((Session.Timeout * 2) + 2).ToString() + "; Url=Acc_GL_ListPopup_Orgainzation.aspx?from=expired");
            string currentPage = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            Response.AppendHeader("Refresh",
                ((Session.Timeout * 2) + 2).ToString() + "; Url=" + currentPage + "?from=expired");

            if (!string.IsNullOrEmpty(hdn.Value))
            {
                if (hdn.Value.IndexOf("ASSETS", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    ddlType.SelectedValue = "ASSETS";
                }
                else
                {
                    ddlType.SelectedValue = "LIABILITIES";
                }
            }
        }

        if (hdn_A_to_Z_Search.Value != "")
        {
            Name_Search = hdn_A_to_Z_Search.Value;
        }
        else
        {
            Name_Search = txtName_1.Text;
        }

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
        DataSet ds = new DataSet();
        ObjUBO.A1 =Name_Search;
        ObjUBO.A2 =txtCode_1.Text;
        ObjUBO.A3 = ddlType.SelectedValue.ToString();
        ObjUBO.A4 = Convert.ToString(currentPageNumber1);
        ObjUBO.A5 = Convert.ToString(gvdetails.PageSize);

        gvdetails.DataSource = CM.Customer_vendor_GL(ObjUBO);
        gvdetails.DataBind();

        Grid_Total(currentPageNumber1, CM.Total_Rows);
    }
    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
    }

    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
        txtCode_1.Text = "";
        txtName_1.Text = "";

        Name_Search = "";
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
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int pageno = 1;

        gridbind(pageno);
        int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
        Add_Pageno(ii);
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
            else
                btnNext.Visible = true;
        }

        if (ViewState["selected_change"] == "1")
        {
        }
        else
            Add_Pageno(ii);
    }

    protected void gvdetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        Date_Time obj = new Date_Time();
        if (gvdetails.SelectedRow == null)
        {
            return;
        }
        string Name = obj.Replace(gvdetails.SelectedRow.Cells[1].Text);
        string Code = obj.Replace(gvdetails.SelectedRow.Cells[2].Text);
        if (!string.IsNullOrEmpty(Request.QueryString["Name"]) && Request.QueryString["Name"].ToString() == "ASSETS")//
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:BindRowValueIn_txtCust_GL('" + Name + "','"+Code+"')", true);
        }
        else if (!string.IsNullOrEmpty(Request.QueryString["Name"]) && Request.QueryString["Name"].ToString() == "LIABILITIES")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:BindRowValue_VendorGL('" + Name + "','" + Code + "')", true);
        }
    }
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
        e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvdetails, "Select$"+ e.Row.RowIndex);
    }
}