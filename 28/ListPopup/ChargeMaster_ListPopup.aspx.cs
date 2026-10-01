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

public partial class ListPopup_ChargeMaster_ListPopup : System.Web.UI.Page
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 15;
    adminmaster Admin_mas = new adminmaster();
    Charge_Master charge = new Charge_Master();
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
    public string LoginDate, selectcon;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();



        if (!IsPostBack)
        {
            //if (!string.IsNullOrEmpty(Request["ChargeName"]))
            //{


            //    txtCharge_Name.Text = Request.QueryString["ChargeName"].ToString();
            //}
            
            int pageno = 1;

            gridbind(pageno);
            int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
            Add_Pageno(ii);
        }

        if (!string.IsNullOrEmpty(Request["ChargeName"]))
        {
            HiddenField1.Value = Request.QueryString["ChargeName"].ToString();
        }
    }

    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
        //txtclientname.Text = "";
        //txtiecno.Text = "";

        //Name_Search = "";
        btnSearch_Click(sender, e);
    }
    private void gridbind(int currentPageNumber1)
    {        
        charge.CHARGE_ID = "0";
        charge.CHARGE_NAME = txtCharge_Name.Text;
        charge.CHARGE_CODE = txtCharge_Code.Text;
        charge.Ename = "select_con";
        charge.WORKING_PERIOD = Session["WorkingPeriod"].ToString();

        charge.startRowIndex = Convert.ToString(currentPageNumber1);
        charge.maximumRows = Convert.ToString(gvdetails.PageSize);
        //ds = charge.RetrieveAll_Charge_Master();
        gvdetails.EmptyDataText = "No Record Found";

        gvdetails.DataSource = charge.RetrieveAll_Charge_Master();
        gvdetails.DataBind();
        Grid_Total(currentPageNumber1, charge.result);
              

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

        string str2 = rep.Replace(gvdetails.SelectedRow.Cells[0].Text);
        string str = rep.Replace(gvdetails.SelectedRow.Cells[1].Text);
        string str1 = rep.Replace(gvdetails.SelectedRow.Cells[3].Text);

        if (HiddenField1.Value == "Quote")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue('" + str + "','" + str2 + "')", true);
        }
        else if (HiddenField1.Value == "Expense")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_Expense('" + str + "')", true);
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
