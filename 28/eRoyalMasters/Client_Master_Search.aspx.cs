using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

public partial class eRoyalMasters_Client_Master_Search : ThemeClass
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 14;
    DataSet dtuser = new DataSet();
    eroyalmaster erm = new eroyalmaster();
    SqlConnection con;
    Manipulation mo;
    AppSession aps = new AppSession();
    Default_Settings Default = new Default_Settings();
    DataSet ds = new DataSet();
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate,Name_Search;

    protected void Page_Load(object sender, EventArgs e)
    
    {
        txtimpexpname.Focus();
        aps.checkSession();
        con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        //mainmastopusernametxt.InnerText = "Welcome Mr." + currentuser;
        Div_Pagination.Visible = false;
        div_pagination1.Visible = false;
       
        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (hdn_A_to_Z_Search.Value != "")
        {
            Name_Search = hdn_A_to_Z_Search.Value;
        }
        else
        {
            Name_Search = txtimpexpname.Text;
        }

        //hdn_A_to_Z_Search.Value = "";
        //----------------------------A to Z SEARCH OPTION--------------------------//
       
        if (!IsPostBack)
        {
            Get_Client_Default_Settings();
            btnSearch_Click(sender, e);
            //DataTable dt = new DataTable();
            //gvdetails.EmptyDataText = "";
            //gvdetails.DataSource = dt;
            //gvdetails.DataBind();
        }
        //btnSearch_Click(sender, e);
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
            Name_Search = txtimpexpname.Text;
            hdn_A_to_Z_Search.Value = "";
        }

        gridbind(pageno);
        int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
        Add_Pageno(ii);
    }
    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
        txtimpexpname.Text = "";
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

   
    public void gridbind(int currentPageNumber1)
    {
        erm.Eimp_exp_id = "";
        erm.Eimp_exp_name = Name_Search;
        erm.Eimp_exp_iecno = txtIecno.Text;
        erm.Eimp_state = txtCommercial_StateName.Text;
        erm.Eimp_exp_brslno = "";
        erm.Ename = "select_ADcode_STD_Search";
        erm.EWorking_Period = Working_Period;

        string get_ddlType = ddlType.SelectedItem.Text;
        if (get_ddlType == "Non-Standard")
        {
            erm.STANDARD_TYPE = "Non_STD";
            Session["get_ddlType"] = erm.STANDARD_TYPE;
        }
        else
        {
            erm.STANDARD_TYPE = "";
            Session["get_ddlType"] = erm.STANDARD_TYPE;
        }

        erm.startRowIndex = Convert.ToString(currentPageNumber1);
        erm.maximumRows = Convert.ToString(gvdetails.PageSize);
        gvdetails.EmptyDataText = "No Record Found";
      
        //------
        DataSet ds = new DataSet();
        ds = erm.RetrieveAll_Imp_exp_master_STD_TYPE();
        this.ViewState.Remove("sorttable");
        ViewState["sorttable"] = ds.Tables[0];

        //we cannot asc sort in sqlserver because we used rowcount thats y we asc here
        gvdetails.DataSource = aps.GridView_Sorting(erm.RetrieveAll_Imp_exp_master_STD_TYPE(), "IMP_EXP_NAME");
        //gvdetails.DataSource = ds.Tables[0];
        gvdetails.DataBind();
        //we cannot asc sort in sqlserver because we used rowcount thats y we asc here
        Grid_Total(currentPageNumber1, erm.result);

        if (ds.Tables[0].Rows.Count > 0)
        {
            tblsort("test");
        }
        Session.Remove("STANDARD_TYPE");
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        Session["IMP_EXP_ID"] = null;

        //string popupScript1;
        //popupScript1 = "window.open('../eRoyalMasters/Client_Master.aspx','NewWindow','width=620,height=570,menubar=no,left=180,top=60,bottom=60,resizable=0,ScrollBars=1');";
        //Page.ClientScript.RegisterStartupScript(Page.GetType(), "NewWindow", popupScript1, true);
    }


    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var row = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string values = this.gvdetails.DataKeys[e.Row.RowIndex]["IMP_EXP_ID"].ToString();
            var des0 = row.Cells[0].Text.Replace("&amp;", "&");
            string Type = ddlType.SelectedValue;

            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            //e.Row.Attributes.Add("onclick", "opennewclientupdate('" + values + "')");
            //e.Row.Attributes.Add("onclick", "opennewclientupdate('" + values + "','" + Server.UrlEncode(des0) + "')");
            //e.Row.Attributes.Add("onclick", "opennewclientupdate('" + values + "','" + HttpUtility.HtmlEncode(des0) + "')");
            e.Row.Attributes.Add("onclick", "opennewclientupdate_N('" + values + "','" + des0 + "')");
            //e.Row.Attributes.Add("onclick", "opennewclientupdate('" + values + "','" + HttpUtility.HtmlEncode(des0) + "')");
            //var des0 = row.Cells[0].Text.Replace("&amp;", "&");
            var des3 = row.Cells[3].Text.Replace("&amp;", "&");
            var des4 = row.Cells[4].Text.Replace("&amp;", "&");

            if (des0.Length > 25)
            {
                row.Cells[0].Text = des0.Substring(0, 25) + "...";
                row.Cells[0].ToolTip = des0;
            }
            if (des3.Length > 15)
            {
                row.Cells[3].Text = des3.Substring(0, 15) + "...";
                row.Cells[3].ToolTip = des3;
            }
            if (des4.Length > 15)
            {
                row.Cells[4].Text = des4.Substring(0, 15) + "...";
                row.Cells[4].ToolTip = des4;
            }
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
            div_pagination1.Visible = true;
        }
        else if (gvdetails.Rows.Count == 0)
        {
            Div_Pagination.Visible = false;
            div_pagination1.Visible = false;
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
            if (Int32.Parse(lblTotalPages.Text) > 10)
            {
                btnNext.Visible = true;
                btnLast.Visible = true;
            }
            else
            {
                btnNext.Visible = false;
                btnLast.Visible = false;
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

    //---------------------Table sort Testing---------------------------------//

    protected void gvdetails_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sortingDirection = string.Empty;
        if (gvdetails.Rows.Count > 0)
        {
            
            if (HD_tbl_sort.Value == string.Empty)
            {
                sortProperty = SortDirection.Ascending;
                sortingDirection = "Asc";
                HD_tbl_sort.Value = "1";
            }
            else
            {
                if (sortProperty == SortDirection.Descending)
                {
                    sortProperty = SortDirection.Ascending;
                    sortingDirection = "Asc";
                }
                else
                {
                    sortProperty = SortDirection.Descending;
                    sortingDirection = "Desc";
                }
            }
                HD_tbl_sort.Value = e.SortExpression.ToString();
                DataView sortedView = new DataView();
                sortedView = new DataView((DataTable)ViewState["sorttable"]);

                sortedView.Sort = e.SortExpression + " " + sortingDirection;
                gvdetails.DataSource = sortedView;
                gvdetails.DataBind();
            
            Div_Pagination.Visible = true;
            div_pagination1.Visible = true;

            tblsort(sortingDirection);
        }
    }
    public SortDirection sortProperty
    {
        get
        {
            if (ViewState["SortingState"] == null)
            {
                ViewState["SortingState"] = SortDirection.Ascending;
            }
            return (SortDirection)ViewState["SortingState"];
        }
        set
        {
            ViewState["SortingState"] = value;
        }
    }

    private void tblsort(string sortingDirection)
    {
        GridViewRow gridViewHeaderRow = gvdetails.HeaderRow;
        foreach (TableCell headerCell in gridViewHeaderRow.Cells)
        {
            if (headerCell.HasControls())
            {
                LinkButton headerButton = headerCell.Controls[0] as LinkButton;

                if (headerButton != null)
                {
                    System.Web.UI.HtmlControls.HtmlGenericControl div = new System.Web.UI.HtmlControls.HtmlGenericControl("div");

                    Label headerText = new Label();
                    headerText.Text = headerButton.Text;

                    div.Controls.Add(headerText);

                    System.Web.UI.WebControls.Image headerImage = new System.Web.UI.WebControls.Image();
                    if (HD_tbl_sort.Value == headerButton.CommandArgument)
                    {
                        if (sortingDirection == "Asc")
                        {
                            headerImage.ImageUrl = "~/images/icons/asc.png";
                            headerImage.CssClass = "space";
                        }
                        else
                        {
                            headerImage.ImageUrl = "~/images/icons/desc.png";
                            headerImage.CssClass = "space";
                        }
                        div.Controls.Add(headerImage);
                    }
                    else
                    {
                        headerImage.ImageUrl = "~/images/icons/Sync.png";
                        headerImage.CssClass = "space_2";
                        div.Controls.Add(headerImage);
                    }
                    headerButton.Controls.Add(div);
                }
            }
        }   
    }

    public void Get_Client_Default_Settings()
    {
        Default.STANDARD_TYPE = "";
        Default.USER_ID = currentuser;
        Default.BRANCH_CODE = currentbranch;
        Default.YEAR = "";
        Default.WORKING_PERIOD = Working_Period;
        Default.BRANCH_COMMON = currentbranch;
        Default.flag = "Get_Details";

        ds = Default.Client_DefaultSettings_Insert_Update();

        if (ds.Tables[0].Rows.Count > 0)
        {
            string STANDARD_TYPE = ds.Tables[0].Rows[0]["STANDARD_TYPE"].ToString();

            if (STANDARD_TYPE == "Non_STD")
            {
                ddlType.SelectedItem.Text = "Non-Standard";

                ddlType.Items.Clear();
                ddlType.Items.Add("Non-Standard");
                ddlType.Items.Add("Standard");
            }
            else
            {
                ddlType.SelectedItem.Text = "Standard";

                ddlType.Items.Clear();
                ddlType.Items.Add("Standard");
                ddlType.Items.Add("Non-Standard");
              
            }
        }
    }
}