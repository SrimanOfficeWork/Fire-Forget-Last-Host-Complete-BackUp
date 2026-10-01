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

public partial class ListPopups_Supplier_Details_ListPopup : ThemeClass
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 10;
    adminmaster Admin_mas = new adminmaster();
    eroyalmaster erm = new eroyalmaster();
    string str;
    Manipulation mo = new Manipulation();
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    DataSet ds = new DataSet();
    DataSet ds_imp = new DataSet();
    Svb_Relation SVR = new Svb_Relation();
    string SP_QUERY, Name_Search, IMPORT_JOBNO;

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string  selectcon;
    public string SELECT_TYPE, SELECT_BRANCH,ImporterName="";

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
       
        SELECT_BRANCH = Connection.Get_Company_Type();

        if (!string.IsNullOrEmpty(Request["Supplier"]))
        {
            hdn.Value = Request.QueryString["Supplier"].ToString();
        }
        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (hdn_A_to_Z_Search.Value != "")
        {
            Name_Search = hdn_A_to_Z_Search.Value;

        }
        else
        {
            Name_Search = txt_transport_name.Text;

        }

        hdn_A_to_Z_Search.Value = "";
        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (!IsPostBack)
        {
            int pageno = 1;
            //Get_ImporterName_frm_Job();
            gridbind(pageno);
            int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
            Add_Pageno(ii);
        }

       
    }

    public void Get_ImporterName_frm_Job()
    {
        if (Session["IMPORT_JOBNO"] != null || Session["IMPORT_JOBDATE"] != null)
        {
            IMPORT_JOBNO = Session["IMPORT_JOBNO"].ToString();

            Svb_Relation SVR = new Svb_Relation();
            SVR.SVB_ID_N = IMPORT_JOBNO;
            SVR.flag = "Get_Importername";
            SVR.BRANCH_CODE = SELECT_BRANCH;
            ds_imp = SVR.SVB_Select();

            if (ds_imp.Tables[0].Rows.Count > 0)
            {
                ImporterName = ds_imp.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
            }
        }
    }

    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
        txt_transport_name.Text = "";

        Name_Search = "";
        btnSearch_Click(sender, e);
    }
    private void gridbind(int currentPageNumber1)
    {
        erm.Etransid = "0";
        erm.Etrans_name = Name_Search;
        erm.Ename = "select_con";
        erm.EWorking_Period = Working_Period;

        erm.startRowIndex = Convert.ToString(currentPageNumber1);
        erm.maximumRows = Convert.ToString(gvdetails.PageSize);
        gvdetails.DataSource = erm.RetrieveAll_Transport_MASTER();
        gvdetails.DataBind();
        Grid_Total(currentPageNumber1, erm.result);
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

       // string str = rep.Replace(gvdetails.SelectedRow.Cells[0].Text);
        string str1 = rep.Replace(gvdetails.SelectedRow.Cells[0].Text);
        string str2 = rep.Replace(gvdetails.SelectedRow.Cells[1].Text);
        string str3 = rep.Replace(gvdetails.SelectedRow.Cells[8].Text);
        string str4 = rep.Replace(gvdetails.SelectedRow.Cells[3].Text);
        string str5 = rep.Replace(gvdetails.SelectedRow.Cells[4].Text);
        string str6 = rep.Replace(gvdetails.SelectedRow.Cells[5].Text);
        string str7 = rep.Replace(gvdetails.SelectedRow.Cells[6].Text);
        string str8 = rep.Replace(gvdetails.SelectedRow.Cells[7].Text);

        if (hdn.Value == "hdn")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_Export_Buyer('" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "','" + str5 + "','" + str6 + "')", true);

        }
        else
        {

            // Parse the date string and format it
            DateTime dateValue;
            if (DateTime.TryParse(str7, out dateValue))
            {
                str7 = dateValue.ToString("dd/MM/yyyy");
            }

            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_Transport_Master('" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "','" + str5 + "','" + str6 + "','" + str7 + "','" + str8 + "')", true);
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_Transport_Master('" + "Testing1" + "','" + "Testing2" + "','" + "Testing3" + "','" + "Testing4" + "','" + "Testing5" + "','" + "Testing6" + "','" + "Testing7" + "','" + "testing8" + "')", true);
            
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
            else btnNext.Visible = true;
        }
        if (ViewState["selected_change"] == "1")
        {
        }
        else
            Add_Pageno(ii);
    }

}
