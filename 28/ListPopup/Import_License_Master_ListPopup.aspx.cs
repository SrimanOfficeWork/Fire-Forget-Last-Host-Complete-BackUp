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


public partial class Import_License_Master_ListPopup : ThemeClass
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
    public string LoginDate, selectcon, ExRate = "";

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
            if (!string.IsNullOrEmpty(Request["License_type"]))
            {
                hdn_license_type.Value = Request.QueryString["License_type"].ToString();
            }

            //string aa = Session["RB_Y_N"].ToString();
            int pageno = 1;

            gridbind(pageno);
            int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
            Add_Pageno(ii);
        }
    }

    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
        //txtLicense_No.Text = "";
        //txt_PartyName.Text = "";
      
        //Name_Search = "";
        btnSearch_Click(sender, e);
    }
    private void gridbind(int currentPageNumber1)
    {

        erm.LICENSE_ID = "0";
        erm.LICENSE_NO = txtLicense_No.Text;
        erm.PARTY_NAME = txt_PartyName.Text == null ? string.Empty : txt_PartyName.Text;
        erm.LICENSE_ITEM_DESCRIPTION = txt_Desc.Text == null ? string.Empty : txt_Desc.Text;
        erm.LICENSE_REG_TYPE = hdn_license_type.Value;
        erm.SCHEME_CODE = Session["SCHEME_CODE"].ToString();
        erm.PART_NO = Session["Part_No"] == null? "" : Session["Part_No"].ToString().Trim();
        erm.Ename = "select_License";
        erm.EWorking_Period = Session["WorkingPeriod"].ToString();
        erm.startRowIndex = Convert.ToString(currentPageNumber1);
        erm.maximumRows = Convert.ToString(gvdetails.PageSize);
        gvdetails.DataSource = erm.RetrieveAll_IMPORT_LICENSE_MASTER();
        gvdetails.DataBind();

        Grid_Total(currentPageNumber1, erm.result);

    }

    public string Get_ExchangeRate(string Currency)
    {
        DataSet ds = new DataSet();
        Admin_mas.Eexchange_id = "0";
        Admin_mas.Ename = "select_con";
        Admin_mas.EXCHANGE_CUR_CODE = Currency;
        Admin_mas.EXCHANGE_NAME = "";
        Admin_mas.EWorking_Period = Working_Period;

        Admin_mas.startRowIndex = Convert.ToString(1);
        Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
        ds = Admin_mas.RetrieveAll_Exchange_master();

        if (ds.Tables[0].Rows.Count > 0)
        {
            ExRate = ds.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();
        }
        else
        {
            ExRate = "0";
        }
        return ExRate;
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
        string Amount = "", Qty = "";
        string str = rep.Replace(gvdetails.SelectedRow.Cells[0].Text);
        string str1 = rep.Replace(gvdetails.SelectedRow.Cells[1].Text);
        string str2 = rep.Replace(gvdetails.SelectedRow.Cells[2].Text);
        string str4 = rep.Replace(gvdetails.SelectedRow.Cells[6].Text);
        string str5 = rep.Replace(gvdetails.SelectedRow.Cells[7].Text);
        string str6 = rep.Replace(gvdetails.SelectedRow.Cells[8].Text);
        string str7 = rep.Replace(gvdetails.SelectedRow.Cells[9].Text);

        string lic_no = rep.Replace(gvdetails.SelectedRow.Cells[4].Text);
        string lic_date = rep.Replace(gvdetails.SelectedRow.Cells[5].Text);
        string UnitQty = rep.Replace(gvdetails.SelectedRow.Cells[10].Text);
        string desc = rep.Replace(gvdetails.SelectedRow.Cells[11].Text);
        string currency = rep.Replace(gvdetails.SelectedRow.Cells[12].Text);
        if (currency != "")
        {
            ExRate = Get_ExchangeRate(currency);
        }
        else
        {
            ExRate = "";
        }
       
        if (Session["RB_Y_N"].ToString() == "Yes")
        {
            erm.LICENSE_ID = "0";
            erm.LICENSE_NO = str;
            erm.LICENSE_ITEM_DESCRIPTION = "";
            erm.SCHEME_CODE = Session["SCHEME_CODE"].ToString();
            erm.Ename = "Get_Remaining_Debit_Amt";
            erm.EWorking_Period = Session["WorkingPeriod"].ToString();

            ds = erm.RetrieveAll_IMPORT_LICENSE_MASTER();

            if (ds.Tables[0].Rows.Count > 0)
            {
                Amount = ds.Tables[0].Rows[0]["REMAINING_AMT"].ToString();
            }
            else
            {
                Amount = "0";
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                Qty = ds.Tables[1].Rows[0]["REMAINING_QTY"].ToString();
            }
            else
            {
                Qty = "0";
            }
        }

        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_License_Import('" + str + "','" + str1 + "','" + str2 + "','" + str4 + "','" + str5 + "','" + str6 + "','" + str7 + "','" + Amount + "','" + Qty + "','" + lic_no + "','" + lic_date + "','" + UnitQty + "','" + desc + "','" + currency + "','" + ExRate + "')", true);

    }
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var row = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvdetails, "Select$" + e.Row.RowIndex);
            e.Row.Cells[11].ToolTip = e.Row.Cells[11].Text;
            if (e.Row.Cells[11].Text.Length > 25)
            {
                e.Row.Cells[11].Text = e.Row.Cells[11].Text.Substring(0, 25) + "...";
            }
            
            //string desc = this.gvdetails.DataKeys[e.Row.RowIndex][7].ToString();
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
