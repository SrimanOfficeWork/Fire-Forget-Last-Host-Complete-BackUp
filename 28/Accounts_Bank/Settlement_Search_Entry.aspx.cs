using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.Text;
using System.IO;
using System.Globalization;


public partial class Settlement_Search_Entry : ThemeClass
{
    AppSession aps = new AppSession();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    Global_variables objUBO = new Global_variables();
    Settlement_cs set = new Settlement_cs();
    public int currentPageNumber;
    public double totalRows;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
       
        if (!IsPostBack)
        {
            gridbind(1);
            Load_Group_Name();
        }
    }
    
   
    private void gridbind(int currentPageNumber1)
    {
        objUBO.A1 = txt_OrganizationCode.Text;
        objUBO.A2 = txttransNo.Text;
        objUBO.A3 = txtNarration.Text;
        objUBO.A4 =Convert.ToString(currentPageNumber1);
        objUBO.A5 =Convert.ToString(gvdetails.PageSize);
        objUBO.A6 = "SEARCH GRID";
        ds = set.LoadSettlementEntrySearch(objUBO);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            gvdetails.DataSource = ds.Tables[0];
            gvdetails.DataBind();
        }
        else
        {
            gvdetails.DataSource = dt;
            gvdetails.DataBind();
        }
        Grid_Total(currentPageNumber1, Convert.ToInt32(objUBO.A8));
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int pageno = 1;
        gridbind(pageno);
        int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
        Add_Pageno(ii,currentPageNumber);
    }
    public void Add_Pageno(int p,int currentPage)
    {
        if (p != 0)
        {
            ddlSelectPageno.Items.Clear();
            for (int i = 1; i <= p; i++)
            {
                ddlSelectPageno.Items.Add(Convert.ToString(i));
            }
            if (currentPage >= 1 && currentPage <= p)
            {
                ddlSelectPageno.SelectedValue = currentPage.ToString();
            }
        }
    }
    protected void ddlSelectPageno_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSelectPageno.SelectedValue != "")
        {
            int SelectedPageNo =Convert.ToInt32(ddlSelectPageno.SelectedValue);
            gridbind(SelectedPageNo);
        }
    }
    private void Load_Group_Name()
    {
        ddlLocation.Items.Clear();
        if (Session["ClientGrpMst"] != null)
        {
            DataSet ds = (DataSet)Session["ClientGrpMst"];
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlLocation.DataSource = ds.Tables[0];
                ddlLocation.DataTextField = "GROUP_NAME";
                ddlLocation.DataValueField = "GROUP_ID";
                ddlLocation.DataBind();
            }
        }
        ddlLocation.Items.Insert(0, new ListItem("", ""));
        ddlLocation.SelectedIndex = 0;
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

    private int CalculateTotalPages(double totalRows)
    {
        int totalPages = (int)Math.Ceiling(totalRows / gvdetails.PageSize);
        return totalPages;
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
            btnNext.Visible = true;
            btnPrev.Visible = true;
           /* if (currentPageNumber == Int32.Parse(lblTotalPages.Text))
            { btnNext.Visible = false; }
            else
            { btnNext.Visible = true; }*/
        }

        Add_Pageno(ii, currentPageNumber1);
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
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string S_PF = this.gvdetails.DataKeys[e.Row.RowIndex]["S_PF"].ToString();
            string S_NO = this.gvdetails.DataKeys[e.Row.RowIndex]["S_NO"].ToString();
            string S_SF = this.gvdetails.DataKeys[e.Row.RowIndex]["S_SF"].ToString();
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("onclick", "OpenSettlementpage('"+S_PF+"','"+S_NO+"','"+S_SF+"')");

            Label lblNarration = (Label)e.Row.FindControl("lblNarration");
            string Narattion = DataBinder.Eval(e.Row.DataItem, "NARRATION").ToString();
            lblNarration.ToolTip = Narattion;
            if (Narattion.Length > 50)
            {
                lblNarration.Text = Narattion.Substring(0, 50) + "...";
            }
            else
            {
                lblNarration.Text = Narattion;
            }
        }
    }
}