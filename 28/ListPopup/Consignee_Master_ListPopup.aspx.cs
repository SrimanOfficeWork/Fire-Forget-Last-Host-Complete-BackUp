using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class ListPopup_Consignee_Master_ListPopup : ThemeClass
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 15;

    adminmaster Admin_mas = new adminmaster();
    eroyalmaster erm = new eroyalmaster();
    string str;

    Manipulation mo = new Manipulation();
    AppSession aps = new AppSession();
    DataSet ds = new DataSet();
  
    public string Working_Period,Name_Search;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        Working_Period = Session["WorkingPeriod"].ToString();

        if (!string.IsNullOrEmpty(Request["Consignee"]))
        {
            hdn.Value = Request.QueryString["Consignee"].ToString();
        }
        if (!string.IsNullOrEmpty(Request["Name"]))
        {
            hdn_Name.Value = Request.QueryString["Name"].ToString();
        }
         //----------------------------A to Z SEARCH OPTION--------------------------//
        if (hdn_A_to_Z_Search.Value != "")
        {
            Name_Search = hdn_A_to_Z_Search.Value;
        }
        else
        {
            Name_Search = txtConsigneeName.Text;
        }
        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (!IsPostBack)
        {
            if (hdn.Value == "BUYER")
            {
                innerbox_MidMain_top_currency.InnerText = "Buyer Master";
                tag_label_country_pop.InnerText = "Buyer Name";
                gvdetails.Columns[0].Visible = false;
                gvdetails.Columns[1].Visible = true;
            }
            else
            {
                innerbox_MidMain_top_currency.InnerText = "Consignee Master";
                tag_label_country_pop.InnerText = "Consignee Name";
                //tag_label_brslno.InnerText = "Branch Slno";
                gvdetails.Columns[0].Visible = true;
                gvdetails.Columns[1].Visible = false;
            }
            int pageno = 1;
            gridbind(pageno);
            int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
            Add_Pageno(ii);
        }
    }
    public void gridbind(int currentPageNumber1)
    {
        erm.Econsigneeid = "0";
        if (hdn.Value == "Consignee_BranchSlNo")
        {
            erm.Ename = "Get_Consignee_BranchSlNo";
            erm.Econsignee_name = hdn_Name.Value;
        }
        else
        {
            erm.Ename = "select_con";
            erm.Econsignee_name = Name_Search;
        }

        erm.CONSIGNEE_BRANCHSLNO = txtBranch_SlNo.Text;
        erm.EWorking_Period = Working_Period;
        erm.startRowIndex = Convert.ToString(currentPageNumber1);
        erm.maximumRows = Convert.ToString(gvdetails.PageSize);
        gvdetails.DataSource = erm.RetrieveAll_Consignee_MASTER();
        gvdetails.DataBind();
        Grid_Total(currentPageNumber1, erm.result);
    }

    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
        txtConsigneeName.Text = "";
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
        string A_Z = Hdn_GetValue.Value;
        if (A_Z == "A_Z")
        {
            Hdn_GetValue.Value = "";
        }
        else
        {
            Name_Search = txtConsigneeName.Text;
            hdn_A_to_Z_Search.Value = "";
        }

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
            else btnNext.Visible = true;
        }
        if (ViewState["selected_change"] == "1")
        {
        }
        else
            Add_Pageno(ii);
    }
    protected void gvdetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        Date_Time rep = new Date_Time();
        string str = rep.Replace(gvdetails.SelectedRow.Cells[0].Text);
        string str1 = rep.Replace(gvdetails.SelectedRow.Cells[1].Text);
        string str2 = rep.Replace(gvdetails.SelectedRow.Cells[2].Text);
        string str3 = rep.Replace(gvdetails.SelectedRow.Cells[3].Text);
        string str4 = rep.Replace(gvdetails.SelectedRow.Cells[4].Text);
        string str7 = rep.Replace(gvdetails.SelectedRow.Cells[5].Text);
        string str5 = rep.Replace(gvdetails.SelectedRow.Cells[6].Text);
        string str6 = rep.Replace(gvdetails.SelectedRow.Cells[7].Text);
        string str8 = rep.Replace(gvdetails.SelectedRow.Cells[8].Text);

        if (hdn.Value == "BUYER")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_Export_Buyer('" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "','" + str5 + "','" + str6 + "')", true);
        }
        else if (hdn.Value == "Bill_Con_name")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_Bill_Consignee('" + str + "','" + str2 + " " + str3 + " " + str4 + " " + str5 + " " + str6 + "')", true);
        }
        else if(hdn.Value =="CONSIGNEE_EGM")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_Export_Egm('" + str + "','" + str3 + "','" + str4 + "','" + str5 + "','" + str6 + "')", true);
        }
        else if (hdn.Value == "Beneficiary")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_Beneficiary('" + str + "','" + str3 + "','" + str4 + "','" + str7 + "','" + str8 + "')", true);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_Export('" + HttpUtility.HtmlEncode(str) + "','" + str3 + "','" + str4 + "','" + str7 + "','" + str5 + "','" + str6 + "','" + str2 + "')", true);
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
}
