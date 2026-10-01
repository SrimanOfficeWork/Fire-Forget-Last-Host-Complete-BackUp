using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using BussinessObject;
using System.IO;
using System.Text;


public partial class Supporting_Docs_ListPopup : ThemeClass
{
    AppSession aps = new AppSession();
    adminmaster Admin_mas = new adminmaster();
    UserBO ObjUBO = new UserBO();
    SW_Support_Docs Sup_Doc = new SW_Support_Docs();

    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 10;
    public string Name_Search;
    public string SUPPLIER_NAME = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        //if (!string.IsNullOrEmpty(Request["Imp_Exp"]))
        //{
        //    hdn_JobType.Value = Request.QueryString["Imp_Exp"].ToString();
        //}
        //else
        //{
        //    hdn_JobType.Value = "";
        //}
        //if (!string.IsNullOrEmpty(Session["IMPORTER_NAME"] as string))
        //{
        //    HiddenField1.Value = Session["IMPORTER_NAME"].ToString();
        //    //hdn_JobType.Value = Session["SVB_ID"].ToString();
        //}
        //else
        //{
        //    HiddenField1.Value = "";
        //}

        //HiddenField2.Value =Session["SUPPLIER_NAME"].ToString();
        //if (!string.IsNullOrEmpty(Request["Supplier"]))
        //{
        //    HiddenField2.Value = Request.QueryString["Supplier"].ToString();
        //}
        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (hdn_A_to_Z_Search.Value != "")
        {
            Name_Search = hdn_A_to_Z_Search.Value;
        }
        else
        {
            Name_Search = txtCushouse.Text; 
        }

        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (!IsPostBack)
        {
            int pageno = 1;
            //SUPPLIER_NAME = Session["SUPPLIER_NAME"].ToString();
            if (!string.IsNullOrEmpty(Request["SUPPLIER_NAME"].ToString()))
            {
                SUPPLIER_NAME = Request.QueryString["SUPPLIER_NAME"].ToString();
            }
            gridbind(pageno);
            int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
            Add_Pageno(ii);
        }
    }

    private void gridbind(int currentPageNumber1)
    {
        Admin_mas.ESvbid = hdn_JobType.Value.ToString();
        Admin_mas.ESvb_relation = txt_SVB_Refno.Text;
        Admin_mas.ESvbcustom_house = Name_Search;
        Admin_mas.ESupName = SUPPLIER_NAME;
        Admin_mas.Ename = "select_con";
        if (!string.IsNullOrEmpty(Session["IMPORTER_NAME"] as string))
        {
            HiddenField1.Value = Session["IMPORTER_NAME"].ToString();
            //hdn_JobType.Value = Session["SVB_ID"].ToString();
            //HiddenField2.Value = Session["SUPPLIER_NAME"].ToString();
        }
        else
        {
            HiddenField1.Value = "";
        }
        
        Admin_mas.EImpName = HiddenField1.Value.ToString();
        Admin_mas.startRowIndex = Convert.ToString(currentPageNumber1);
        Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
        gvdetails.DataSource = Admin_mas.SVB_Relation_Master();
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
            Name_Search = txtCushouse.Text; 
            hdn_A_to_Z_Search.Value = "";
        }

        gridbind(pageno);
        int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
        Add_Pageno(ii);
    }
    protected void gvdetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        Date_Time rep = new Date_Time();
        //string txtImporterName = rep.Replace(gvdetails.SelectedRow.Cells[1].Text); //ICEGATE_ID
        //string txtSupplierName = rep.Replace(gvdetails.SelectedRow.Cells[2].Text); 
        string txtSVB_RefNo = rep.Replace(gvdetails.SelectedRow.Cells[3].Text); 
        string txtSVBDate = rep.Replace(gvdetails.SelectedRow.Cells[4].Text); 
        string txtCustomsHouse = rep.Replace(gvdetails.SelectedRow.Cells[5].Text);
        string ddlLoadingOn = rep.Replace(gvdetails.SelectedRow.Cells[6].Text);
        //if (ddlLoadingOn.Replace'A','Assesable');
        //string ddlLoadingOn = "";
        //ddlLoadingOn = gvdetails.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
        if (ddlLoadingOn == "A")
        {
            ddlLoadingOn = "Assessable";
        }
        else if (ddlLoadingOn == "D")
        {
            ddlLoadingOn = "Duty";
        }
        else if (ddlLoadingOn == "B")
        {
            ddlLoadingOn = "Both";
        }
        else
        {
            ddlLoadingOn = "";
        }
        string txtAssesable_Rate = rep.Replace(gvdetails.SelectedRow.Cells[7].Text);
        string ddlAssesable_Status = rep.Replace(gvdetails.SelectedRow.Cells[8].Text);
        //string load_on = "";
        //string txtAssesable_Rate = string.Empty;
        //if (ddlLoadingOn == "A")
        //{
        //    load_on = "Assessable";

        //    txtAssesable_Rate.Enabled = true;
        //    ddlAssesable_Status.Enabled = true;


        //}
        //else if (ddlLoadingOn == "D")
        //{
        //    load_on = "Duty";
        //    txtDuty_Rate.Enabled = true;
        //    ddlDuty_Status.Enabled = true;
        //}
        //else if (ddlLoadingOn == "B")
        //{
        //    load_on = "Both";

        //    txtAssesable_Rate.Enabled = true;
        //    ddlAssesable_Status.Enabled = true;
        //    txtDuty_Rate.Enabled = true;
        //    ddlDuty_Status.Enabled = true;
        //}
        if (ddlAssesable_Status == "P")
        {
            ddlAssesable_Status = "Provisional";
        }
        else if (ddlAssesable_Status == "F")
        {
            ddlAssesable_Status = "Final";
        }
        else
        {
            ddlAssesable_Status = "";
        }
        string txtDuty_Rate = rep.Replace(gvdetails.SelectedRow.Cells[9].Text);
        string ddlDuty_Status = rep.Replace(gvdetails.SelectedRow.Cells[10].Text);
        if (ddlDuty_Status == "P")
        {
            ddlDuty_Status = "Provisional";
        }
        else if (ddlDuty_Status == "F")
        {
            ddlDuty_Status = "Final";
        }
        else
        {
            ddlDuty_Status = "";
        }

        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open1", "javascript:GetRowValue('"  + txtSVB_RefNo + "','" + txtSVBDate + "','" + txtCustomsHouse + "','" + ddlLoadingOn + "' ,'" + txtAssesable_Rate + "','" + ddlAssesable_Status + "' ,'" + txtDuty_Rate + "','" + ddlDuty_Status + "' )", true);   
        
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

    [System.Web.Services.WebMethod]
    public static string Get_Assessable(string rate)
    {
        string Assesable= "";
        string str = "";
        DataSet ds = new DataSet();
        try
        {
            adminmaster Admin_mas = new adminmaster();
            Admin_mas.EAssesableRate = rate;
            Admin_mas.Ename = "select_con";
            ds = Admin_mas.SVB_Relation_Master();

            if (ds.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Assesable = ds.Tables[0].Rows[i]["SVB_ASSESABLE_RATE"].ToString();

                    str += Assesable + ',';


                }
                //str = str + "<option value=" + str + "</option>";
                //str = "<option value=0></option>" + str;
                //List<Item> items = new List<Item>();
            }


            //List<Item> items = new List<Item>();
            //var results = item.Where(item => item.Contains(custid.ToLower()));

            return str;


            //------------------------------------
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return str;
    }
   
}