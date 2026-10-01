using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using BussinessObject;

public partial class ESanchitMailTrack : ThemeClass
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 10;
    SqlConnection con;
    Manipulation mo;
    adminmaster Admin_mas = new adminmaster();
    public string Name_Search;
    AppSession aps = new AppSession();
    UserBO ObjUBO = new UserBO();
    SW_Support_Docs Sup_Doc = new SW_Support_Docs();
    public static Maildb mdb = new Maildb(); 

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        if (!string.IsNullOrEmpty(Request["SUPDOC"]))
        {
            HiddenField1.Value = Request.QueryString["SUPDOC"].ToString();
        }

        if (!string.IsNullOrEmpty(Request["Jobtype"]))
        {
            hdn_JobType.Value = Request.QueryString["Jobtype"].ToString();
        }

        
        if (!IsPostBack)
        {
            int pageno = 1;

            gridbind(pageno);
            int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
            Add_Pageno(ii);
        }

       // txtIRNNo.Attributes.Add("onblur", "javascript:CallServerside_Importer_2('" + txtIRNNo.ClientID + "', '" + txtIRNNo.ClientID + "')");
    }


    private void gridbind(int currentPageNumber1)
    {
        DataSet ds = new DataSet();
        //Admin_mas.EUnit_id = "0";
        //Admin_mas.EUnit_code = "";
        //Admin_mas.EUnit_name = Name_Search;
        //Admin_mas.Ename = "select_con";
        //Admin_mas.name = ""; Admin_mas.com

        Admin_mas.Ename = "select_con_new";
        Admin_mas.Esan_EmailID = "";
        Admin_mas.Esan_Company = "";
        Admin_mas.Esan_CustID = "";
        Admin_mas.Esan_FileFormat = "";
        Admin_mas.EWorking_Period = ""; Admin_mas.Esan_Trasaction = ""; Admin_mas.BRANCH_CODE = "";  
        
        Admin_mas.startRowIndex = Convert.ToString(currentPageNumber1);
        Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
        Admin_mas.IRN_no = txtIRNNo.Text;
        Admin_mas.DRN_no = txtDRNNo.Text;

        ds = Admin_mas.RetrieveAll_Esanchit_Master(ds);
        gvdetails.DataSource = ds.Tables[0];
        gvdetails.DataBind();
        Grid_Total(currentPageNumber1, Admin_mas.Total_Rows);

         

    }
    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
         
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
        //IRN_no, DRN_no, filetype, Icegate
        Date_Time rep = new Date_Time();
        string IRN_no = gvdetails.SelectedRow.Cells[1].Text;
        string DRN_no = gvdetails.SelectedRow.Cells[2].Text;
        string Icegate = gvdetails.SelectedRow.Cells[3].Text;
        string filetype =  gvdetails.SelectedRow.Cells[6].Text;
        string IceFilename = gvdetails.SelectedRow.Cells[5].Text;
        string doctypecode = gvdetails.SelectedRow.Cells[4].Text;

        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open1", "javascript:GetRowValue('" + IRN_no + "','" + DRN_no + "','" + filetype + "','" + Icegate + "','" + doctypecode + "')", true);
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