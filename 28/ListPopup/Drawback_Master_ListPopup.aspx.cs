using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ListPopup_Drawback_Master_ListPopup : ThemeClass
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 10;
    adminmaster Admin_mas = new adminmaster();
    Manipulation mo;
    AdminManipulation am = new AdminManipulation();
    public string Name_Search, RITC_NO;
    AppSession aps = new AppSession();
    string Item_Unit = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        Item_Unit = Request.QueryString["Unit"].ToString();

        if (!string.IsNullOrEmpty(Request["Drawback"]))
        {
            hdn.Value = Request.QueryString["Drawback"].ToString();

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
        RITC_NO = Session["EXP_RITCNO"].ToString();
        Hdn_RITC_4_digit.Value = RITC_NO.Substring(0, 4);
        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (!IsPostBack)
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
    }

   
    public void gridbind(int currentPageNumber1)
    {
        Admin_mas.Edrawback_id = "0";

        if (txtDrawbackNo.Text != "" && txtDescription.Text!="")
        {
            Admin_mas.Edrawback_slno = txtDrawbackNo.Text;
            Admin_mas.Edrawback_description = Name_Search;
            Hdn_RITC_4_digit.Value = "";
        }
     
        else if (txtDrawbackNo.Text != "" && txtDescription.Text == "")
        {
            Admin_mas.Edrawback_slno = txtDrawbackNo.Text;
            Admin_mas.Edrawback_description = Name_Search;
            Hdn_RITC_4_digit.Value = "";
        }

        else if (txtDrawbackNo.Text == "" && txtDescription.Text != "")
        {
            Admin_mas.Edrawback_slno = "";
            Admin_mas.Edrawback_description = Name_Search;
            Hdn_RITC_4_digit.Value = "";
        }
        else if (txtDrawbackNo.Text == "" && txtDescription.Text == "")
        {
            Admin_mas.Edrawback_slno = Hdn_RITC_4_digit.Value;
            Admin_mas.Edrawback_description = Name_Search;
          
        }

        Admin_mas.Ename = "select_con";

        Admin_mas.startRowIndex = Convert.ToString(currentPageNumber1);
        Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
        //ds = erm.RetrieveAll_Adcode_MASTER();
        gvdetails.EmptyDataText = "No Record Found";

        gvdetails.DataSource = Admin_mas.RetrieveAll_Drawback_master();

        gvdetails.DataBind();

        Grid_Total(currentPageNumber1, Admin_mas.Total_Rows);

    }
    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
        txtDrawbackNo.Text = "";
        txtDescription.Text = "";

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

        gridbind(pageno);
        int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
        Add_Pageno(ii);
    }
    protected void gvdetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        Date_Time rep = new Date_Time();

        string str = rep.Replace(gvdetails.SelectedRow.Cells[1].Text);
        string str1 = rep.Replace(gvdetails.SelectedRow.Cells[2].Text);
        string str2 = rep.Replace(gvdetails.SelectedRow.Cells[3].Text);
        string str3 = rep.Replace(gvdetails.SelectedRow.Cells[4].Text);
        string str4 = rep.Replace(gvdetails.SelectedRow.Cells[5].Text);
        string str5 = rep.Replace(gvdetails.SelectedRow.Cells[6].Text);

        if (str1 == "")
        {
            str1 = Item_Unit;
        }

        if (hdn.Value.Trim() == "EXPORT_DrawbackNo")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue('" + str + "','" + str1 + "','" + str2 + "',' " + str3 + "','"+ str4 +"','"+str5+"')", true);
        }

        else if (hdn.Value == "EXPORT_Product_DrawbackNo")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_Export_Product('" + str + "')", true);
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