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

public partial class Imp_Exp_ThirdParty_Master_ListPopup : ThemeClass
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 15;
    adminmaster Admin_mas = new adminmaster();
    eroyalmaster erm = new eroyalmaster();
    string str;
    Manipulation mo = new Manipulation();
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    DataSet ds = new DataSet();
    string SP_QUERY;

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, selectcon, Name_Search,Buyer_YN="";

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

        if (!string.IsNullOrEmpty(Request["Invoice"]))
        {
            hdn.Value = Request.QueryString["Invoice"].ToString();

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

        //hdn_A_to_Z_Search.Value = "";
        //----------------------------A to Z SEARCH OPTION--------------------------//
        //if (!string.IsNullOrEmpty(Request["Supplier"]))
        //{
        //    hdn.Value = Request.QueryString["Supplier"].ToString();
        //}

        if (!IsPostBack)
        {
            if (hdn.Value == "Exp_ThirdParty")
            {
                innerbox_MidMain_top_currency.InnerText = "Export - Third Party Master";
                tag_label_country_pop.InnerText = "Third Party Name";
                gvdetails.Columns[0].Visible = false;
                gvdetails.Columns[1].Visible = true;
            }

            if (hdn.Value == "Imp_ThirdParty")
            {
                innerbox_MidMain_top_currency.InnerText = "Import - Third Party Master";
                tag_label_country_pop.InnerText = "Third Party Name";
                gvdetails.Columns[0].Visible = false;
                gvdetails.Columns[1].Visible = true;
            }

            int pageno = 1;

            gridbind(pageno);
            int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
            Add_Pageno(ii);
        }
    }
    public void gridbind(int currentPageNumber1)
    {
        erm.Ebuyerid = "0";
        erm.Ename = "select_con";
        erm.Ebuyer_name = Name_Search;

        erm.EWorking_Period = Working_Period;
        erm.startRowIndex = Convert.ToString(currentPageNumber1);
        erm.maximumRows = Convert.ToString(gvdetails.PageSize);

        if (hdn.Value == "Exp_ThirdParty")
        {
            ds = erm.RetrieveAll_Exp_ThirdParty_MASTER();
            ds.Tables[0].Columns.Add("BUYER_RELATED_Y_N");

            gvdetails.DataSource = ds;
            gvdetails.DataBind();
        }
        else
        {
            gvdetails.DataSource = erm.RetrieveAll_Imp_ThirdParty_MASTER();
            gvdetails.DataBind();

            ds = erm.RetrieveAll_Imp_ThirdParty_MASTER();
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    Buyer_YN = ds.Tables[0].Rows[0]["BUYER_RELATED_Y_N"].ToString();
            //}
        }
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
    protected void gvdetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        Date_Time rep = new Date_Time();

        string str = rep.Replace(gvdetails.SelectedRow.Cells[0].Text);
        string str1 = rep.Replace(gvdetails.SelectedRow.Cells[1].Text);
        string str2 = rep.Replace(gvdetails.SelectedRow.Cells[2].Text);
        string str3 = rep.Replace(gvdetails.SelectedRow.Cells[3].Text);
        string str4 = rep.Replace(gvdetails.SelectedRow.Cells[4].Text);

        string str5 = rep.Replace(gvdetails.SelectedRow.Cells[5].Text);

        string str6 = rep.Replace(gvdetails.SelectedRow.Cells[6].Text);
        string str7 = rep.Replace(gvdetails.SelectedRow.Cells[7].Text);
        string str8 = rep.Replace(gvdetails.SelectedRow.Cells[8].Text);
        string str9 = rep.Replace(gvdetails.SelectedRow.Cells[9].Text);
        string str10 = rep.Replace(gvdetails.SelectedRow.Cells[10].Text);
        string str11= rep.Replace(gvdetails.SelectedRow.Cells[11].Text);
        string str12 = rep.Replace(gvdetails.SelectedRow.Cells[12].Text);

        
        if (hdn.Value == "Exp_ThirdParty")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_ThirdParty_Export('" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "','" + str5 + "','" + str6 + "','" + str7 + "','" + str8 + "','" + str9 + "','" + str10 + "','" + str11 + "')", true);     
        }
        else if (hdn.Value == "Imp_ThirdParty")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_ThirdParty_Import('" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "','" + str5 + "','" + str6 + "','" + str7 + "','" + str8 + "','" + str9 + "','" + str10 + "','" + str11 + "','" + str12 + "')", true);
        }
        else
        {
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
}
