using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using BussinessObject;

public partial class ListPopups_Unit_ListPopup : ThemeClass
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
        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (!IsPostBack)
        {
            int pageno = 1;

            gridbind(pageno);
            int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
            Add_Pageno(ii);
        }

        txtDescription.Attributes.Add("onblur", "javascript:CallServerside_Importer_2('" + txtDescription.ClientID + "', '" + txtCode.ClientID + "')");
    }


    private void gridbind(int currentPageNumber1)
    {

        Admin_mas.EUnit_id = "0";
        Admin_mas.EUnit_code = txtCode.Text;
        Admin_mas.EUnit_name = Name_Search;
        Admin_mas.Ename = "select_con";

        //string Query = "STATE_MASTER_SP_SELECT_CON";
        //gvdetails.DataSource = am.RetrieveAll_State_Master_LIKE(Query, txtStateCode.Text, txtStateName.Text);

        //gvdetails.DataBind();

        Admin_mas.startRowIndex = Convert.ToString(currentPageNumber1);
        Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
        //ds = erm.RetrieveAll_Adcode_MASTER();
        gvdetails.DataSource = Admin_mas.RetrieveAll_SUPPROTING_DOCS_Master();
        gvdetails.DataBind();
        Grid_Total(currentPageNumber1, Admin_mas.Total_Rows);

    }
    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
        //txtDescription.Text = "";
        //txtCode.Text = "";
        //Name_Search = "";

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
            Name_Search = txtDescription.Text;
            hdn_A_to_Z_Search.Value = "";
        }

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

        Get_INVOICE_NO_frm_JOB();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open1", "javascript:GetRowValue('" + str + "','" + str1 + "','" + str2 + "')", true);
    }

    public void Get_INVOICE_NO_frm_JOB()
    {

        DataSet dss = new DataSet();
        if (hdn_JobType.Value == "Export")
        {
            ObjUBO.JOBNO = HttpContext.Current.Session["EXPORT_JOBNO"].ToString();
            ObjUBO.INVOICE_SLNO = HttpContext.Current.Session["Inv_SL_No"].ToString();
        }
        else
        {
            ObjUBO.JOBNO = Connection.IMP_Jobno();
            ObjUBO.INVOICE_SLNO = Connection.IMP_Invoice_Slno();
        }
        ObjUBO.ITEM_SLNO = "";
        ObjUBO.BRANCH_COMMON = Connection.Get_Company_Type();

        ObjUBO.Ename = "IMP_SUP_DOC_IGM_INVOICE_DETAILS_SELECT";

        dss = Sup_Doc.SingleWindow_Select(ObjUBO);

        if (dss.Tables[0].Rows.Count > 0)
        {
            hdn_invno.Value = dss.Tables[0].Rows[0]["INVOICE_NO"].ToString();
            hdn_invdate.Value = dss.Tables[0].Rows[0]["INVOICE_DATE"].ToString();
        }
        if (dss.Tables[1].Rows.Count > 0)
        {
            hdn_mbl_no.Value = dss.Tables[1].Rows[0]["IGM_MAWB_MBL"].ToString();
            hdn_mbldate.Value = dss.Tables[1].Rows[0]["IGM_MAWB_MBLDATE"].ToString().Replace("01/01/1900", "");
            hdn_hblno.Value = dss.Tables[1].Rows[0]["IGM_HAWB_HBLNO"].ToString();
            hdn_hbldate.Value = dss.Tables[1].Rows[0]["IGM_HAWB_HBLDATE"].ToString().Replace("01/01/1900", "");
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