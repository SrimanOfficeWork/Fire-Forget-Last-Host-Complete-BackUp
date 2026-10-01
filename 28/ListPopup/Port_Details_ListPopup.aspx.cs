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
public partial class ListPopup_Port_Details_ListPopup : ThemeClass
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
    string SP_QUERY;

    public string currentuser, select_con="";
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, selectcon, Name_Search;
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

        if(Request.QueryString["Port_Ship"].ToString()!="Port_Det")
        {
            if (!string.IsNullOrEmpty(Request["Port_Ship"]))
            {
                hdn_Port_Ship.Value = Request.QueryString["Port_Ship"].ToString();
            }
        }
        else if (Request.QueryString["Port_Ship"].ToString() == "Port_Det")
        {
            Session.Remove("Transport_Mode_Port");
        }
        if (Session["Transport_Mode_Port"] != null  )
        {
            hdn.Value = Session["Transport_Mode_Port"].ToString();
            if (hdn.Value == "Air")
            {
                A_To_Z_Search();

                select_con = "select_Air";
                if (!IsPostBack)
                {
                    int pageno = 1;

                    gridbind(pageno);
                    int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
                    Add_Pageno(ii);
                    //gvdetails.Columns[0].Visible = true;
                    //gvdetails.Columns[1].Visible = false;
                }

            }
            else
            {
                A_To_Z_Search();
                select_con = "select_All";
                if (!IsPostBack)
                {
                    int pageno = 1;

                    gridbind(pageno);
                    int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
                    Add_Pageno(ii);
                }

            }
        }
        else if (Request.QueryString["Port_Ship"].ToString()=="Port_Det")
        {
            //Session["Transport_Mode_Port"]
           
            A_To_Z_Search();

            select_con = "select_All";
            if (!IsPostBack)
            {
                int pageno = 1;

                gridbind(pageno);
                int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
                Add_Pageno(ii);
            }
        }
        

    }
    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
        txtPortCode.Text = "";
        txtPortName.Text = "";

        Name_Search = "";
        btnSearch_Click(sender, e);
    }
    public void A_To_Z_Search()
    {
        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (hdn_A_to_Z_Search.Value != "")
        {
            Name_Search = hdn_A_to_Z_Search.Value;

        }
        else
        {
            Name_Search = txtPortName.Text;

        }

        //hdn_A_to_Z_Search.Value = "";
        //----------------------------A to Z SEARCH OPTION--------------------------//
    }

    public void gridbind(int currentPageNumber1)
    {
        Admin_mas.EPort_id = "0";
        Admin_mas.EPort_code_air = txtPortCode.Text;
        Admin_mas.EPort_name = Name_Search;
        //Admin_mas.EPort_name = txtPortNameSearch.Text;
        Admin_mas.Ename = select_con;



        Admin_mas.startRowIndex = Convert.ToString(currentPageNumber1);
        Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
        //ds = erm.RetrieveAll_Adcode_MASTER();
        gvdetails.DataSource = Admin_mas.RetrieveAll_Port_master();


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
            Name_Search = txtPortName.Text;
            hdn_A_to_Z_Search.Value = "";
        }

        gridbind(pageno);
        int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
        Add_Pageno(ii);
    }
    public void Script_()
    {
        Date_Time rep = new Date_Time();

        string str = rep.Replace(gvdetails.SelectedRow.Cells[1].Text);
        string str1 = rep.Replace(gvdetails.SelectedRow.Cells[2].Text);
        //string str2 = gvdetails.SelectedRow.Cells[3].Text;
        //string str3 = gvdetails.SelectedRow.Cells[4].Text;



        if (hdn.Value == "Air")
        {
            if (hdn_Port_Ship.Value == "Port_Ship")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_Port_Details_Air_Ship('" + str+"-"+str1 + "')", true);
            }
            else if (hdn_Port_Ship.Value == "Export_Port_origin")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_Export_Port_Details_Air('" + str + "-" + str1 + "')", true);
            }
            else if (hdn_Port_Ship.Value == "Export_Port_Ship")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_Export_Port_Details_Air_Ship('" + str + "-" + str1 + "')", true);
            }
            else if (hdn_Port_Ship.Value == "Jobwise_Excel_Port")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_Port_Details_Jobwise_Air('" + str + "-" + str1 + "')", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_Port_Details_Air('" + str + "-" + str1 + "')", true);
            }
        }
        else
        {
            if (hdn_Port_Ship.Value == "Port_Ship")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_Port_Details_Sea_Ship('" + str + "-" + str1 + "')", true);
            }
            else if (hdn_Port_Ship.Value == "Export_Port_origin")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_Export_Port_Details_Sea('" + str + "-" + str1 + "')", true);
            }
            else if (hdn_Port_Ship.Value == "Export_Port_Ship")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_Export_Port_Details_Sea_Ship('" + str + "-" + str1 + "')", true);
            }
            else if (hdn_Port_Ship.Value == "Jobwise_Excel_Port")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_Port_Details_Jobwise_Sea('" + str + "-" + str1 + "')", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_Port_Details_Sea('" + str + "-" + str1 + "')", true);
            }


        }
    }
    public void GridBind_TRansport()
    {
        if (hdn.Value == "Air")
        {
            selectcon = "select_Air";
            int pageno = 1;

            gridbind(pageno);
            int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
            Add_Pageno(ii);
            gvdetails.Columns[0].Visible = true;
            gvdetails.Columns[1].Visible = false;
        }
        else
        {
            selectcon = "select_Sea";
            int pageno = 1;

            gridbind(pageno);
            int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
            Add_Pageno(ii);
            gvdetails.Columns[0].Visible = false;
            gvdetails.Columns[1].Visible = true;

        }
       
    }
    protected void gvdetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (hdn.Value == "Air")
        {
            selectcon = "select_Air";
            //gvdetails.Columns[0].Visible = true;
            //gvdetails.Columns[1].Visible = false;
            Script_();
        }
        else
        {
            selectcon = "select_Sea";
            //gvdetails.Columns[0].Visible = false;
            //gvdetails.Columns[1].Visible = true;
            Script_();


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