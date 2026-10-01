using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ListPopup_Notification_Excise_Master_ListPopup : ThemeClass
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 10;
    adminmaster Admin_mas = new adminmaster();
    Manipulation mo;
    string str;
    AppSession aps = new AppSession();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();

            if (!string.IsNullOrEmpty(Request["id"]))
            {
                HiddenField1.Value = Request.QueryString["id"].ToString();
            }

            if (!string.IsNullOrEmpty(Request["RITC"]))
            {
                txtRITCNo.Text = Request.QueryString["RITC"].ToString();
            }

            if (!IsPostBack)
            {
                int pageno = 1;

                gridbind(pageno);
                int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
                Add_Pageno(ii);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }


    private void gridbind(int currentPageNumber1)
    {
        Admin_mas.ENotification_Excise_id = txtRITCNo.Text;
        Admin_mas.ENotification_Excise_notn = txtNotnNo.Text;
        Admin_mas.ENotification_Excise_notn_slno = txtNotnSrNo.Text;

        //if (Request.QueryString["id"].ToString() == "LEVY_NOTN" || Request.QueryString["id"].ToString() == "LEVY_EXC_NOTN" || Request.QueryString["id"].ToString() == "LEVY_CP_CESS_NOTN" || Request.QueryString["id"].ToString() == "LEVY_EXC_CP_CESS_NOTN")
        if (Request.QueryString["id"].ToString() == "LEVY_NOTN" || Request.QueryString["id"].ToString() == "LEVY_EXC_NOTN_V2" || Request.QueryString["id"].ToString() == "LEVY_CP_CESS_NOTN" || Request.QueryString["id"].ToString() == "LEVY_EXC_CP_CESS_NOTN")        
        {
           
            Admin_mas.Ename = Request.QueryString["id"].ToString();
        }
        else
        {
            Admin_mas.Ename = "select_con";
        }

        Admin_mas.startRowIndex = Convert.ToString(currentPageNumber1);
        Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
        //ds = erm.RetrieveAll_Adcode_MASTER();
        gvdetails.DataSource = Admin_mas.RetrieveAll_Notification_Excise_master();
        gvdetails.DataBind();
        Grid_Total(currentPageNumber1, Admin_mas.Total_Rows);


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

        string str = rep.Replace(gvdetails.SelectedRow.Cells[2].Text);
        string str1 = rep.Replace(gvdetails.SelectedRow.Cells[3].Text);
        string str2 = rep.Replace(gvdetails.SelectedRow.Cells[5].Text);
        string str3 = rep.Replace(gvdetails.SelectedRow.Cells[6].Text);
        string str4 = rep.Replace(gvdetails.SelectedRow.Cells[7].Text);
        string str5 = rep.Replace(gvdetails.SelectedRow.Cells[8].Text);
        string str6 = rep.Replace(gvdetails.SelectedRow.Cells[9].Text);
        string str7 = rep.Replace(gvdetails.SelectedRow.Cells[10].Text);
        if (HiddenField1.Value == "CVD")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "open1", "javascript:GetRowValue_CVD('" + str + "','" + str1 + "','" + str5 + "','" + str6 + "','" + str7 + "')", true);
        }
        else if (HiddenField1.Value == "Addl_Duty")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "open1", "javascript:GetRowValue_Addl_Duty('" + str + "','" + str1 + "','" + str2 + "')", true);
        }
        else if (HiddenField1.Value == "Addl_Duty_GSI")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "open1", "javascript:GetRowValue_Addl_Duty_GSI('" + str + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "')", true);
        }
        else if (HiddenField1.Value == "Addl_She11_Notn")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "open1", "javascript:GetRowValue_Addl_She11_Notn('" + str + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "')", true);
        }
        else if (HiddenField1.Value == "Addl_TTA_Notn")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "open1", "javascript:GetRowValue_Addl_TTA_Notn('" + str + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "')", true);
        }
        else if (HiddenField1.Value == "Addl_Health_Cess")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "open1", "javascript:GetRowValue_Addl_Health_Cess('" + str + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "')", true);
        }
        else if (HiddenField1.Value == "Cess_Notn")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "open1", "javascript:GetRowValue_Cess_Notn('" + str + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "')", true);
        }
        else if (HiddenField1.Value == "Infra_Notn")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "open1", "javascript:GetRowValue_Infra_Notn('" + str + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "')", true);
        }
        //--------------------------------- 

        else if (HiddenField1.Value == "LEVY_NOTN")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "open1", "javascript:GetRowValue_LEVY_NOTN('" + str + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "')", true);
        }
        else if (HiddenField1.Value == "LEVY_EXC_NOTN")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "open1", "javascript:GetRowValue_LEVY_EXC_NOTN('" + str + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "')", true);
        }
        else if (HiddenField1.Value == "LEVY_CP_CESS_NOTN")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "open1", "javascript:GetRowValue_LEVY_CP_CESS_NOTN('" + str + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "')", true);
        }
        else if (HiddenField1.Value == "LEVY_EXC_CP_CESS_NOTN")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "open1", "javascript:GetRowValue_LEVY_EXC_CP_CESS_NOTN('" + str + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "')", true);
        }
        else if (HiddenField1.Value == "LEVY_EXC_NOTN_V2")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "open1", "javascript:GetRowValue_LEVY_EXC_NOTN('" + str + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "')", true);
        }
        else
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open1", "javascript:GetRowValue('" + str + "','" + str1 + "')", true);
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