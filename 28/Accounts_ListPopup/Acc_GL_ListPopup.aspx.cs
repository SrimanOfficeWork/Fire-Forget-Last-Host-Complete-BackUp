using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessObject;
using System.Data;

public partial class Acc_GL_ListPopup : ThemeClass
{
    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();
    Acc_Charge_Master_New_cs CM = new Acc_Charge_Master_New_cs();

    string  Name_Search;
    public int currentPageNumber;
    public double totalRows;
  

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        if (!string.IsNullOrEmpty(Request["Name"]))
        {
            hdn.Value = Request.QueryString["Name"].ToString();
        }

        if (!Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["from"]))
            {
                if (Request["from"].Trim() == "expired")
                {
                    Response.Write("<script>self.close();</script>");
                }
            }
            Response.AppendHeader("Refresh", ((Session.Timeout * 2) + 2).ToString() + "; Url=Acc_GL_ListPopup.aspx?from=expired");

            if (!string.IsNullOrEmpty(hdn.Value))
            {
                if (hdn.Value.IndexOf("Expense", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    ddlType.SelectedValue = "EXPENSES";
                }
                else if (hdn.Value.IndexOf("Income", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    ddlType.SelectedValue = "INCOME";
                }
            }
        }

        if (hdn_A_to_Z_Search.Value != "")
        {
            Name_Search = hdn_A_to_Z_Search.Value;
        }
        else
        {
            Name_Search = txtName.Text;
        }

        hdn_A_to_Z_Search.Value = "";

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

        ObjUBO.A1 = "0";
        ObjUBO.A2 = txtCode.Text;
        ObjUBO.A3 = Name_Search;
        ObjUBO.A4 = ddlType.SelectedValue.ToString();
        ObjUBO.A5 = Convert.ToString(currentPageNumber1);
        ObjUBO.A6 = Convert.ToString(gvdetails.PageSize);
        ObjUBO.A10 = "select_con";

        gvdetails.DataSource = CM.GL_Ledger_Grid(ObjUBO);
        gvdetails.DataBind();

        Grid_Total(currentPageNumber1, CM.Total_Rows);
    }

    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
        txtCode.Text = "";
        txtName.Text = "";

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


    protected void gvdetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        Date_Time rep = new Date_Time();

        string nameVal = rep.Replace(gvdetails.SelectedRow.Cells[1].Text);
        string codeVal = rep.Replace(gvdetails.SelectedRow.Cells[2].Text);


        if (Request.QueryString["Name"].ToString() == "txt_R2_Income")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_GL_R2_Income('" + nameVal + "','" + codeVal + "')", true);
        }
        else if (Request.QueryString["Name"].ToString() == "txt_R2_Expense")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_GL_R2_Expense('" + nameVal + "','" + codeVal + "')", true);
        }
        else if (Request.QueryString["Name"].ToString() == "txt_R3_Income")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_GL_R3_Income('" + nameVal + "','" + codeVal + "')", true);
        }
        else if (Request.QueryString["Name"].ToString() == "txt_R3_Expense")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_GL_R3_Expense('" + nameVal + "','" + codeVal + "')", true);
        }
        else if (Request.QueryString["Name"].ToString() == "txt_R5_Income")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_GL_R5_Income('" + nameVal + "')", true);
        }
        else if (Request.QueryString["Name"].ToString() == "txt_R5_Expense")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_GL_R5_Expense('" + nameVal + "')", true);
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
}
