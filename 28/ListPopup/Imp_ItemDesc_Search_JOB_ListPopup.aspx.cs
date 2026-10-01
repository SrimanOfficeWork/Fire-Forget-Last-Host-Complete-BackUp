using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class Imp_ItemDesc_Search_JOB_ListPopup : ThemeClass
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 10;
    adminmaster Admin_mas = new adminmaster();
    AppSession aps = new AppSession();
    eroyalmaster erm = new eroyalmaster();
    public string F_Description;
    SqlConnection con;
    Manipulation mo;
   
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, Name_Search;
    public string SELECT_TYPE, SELECT_BRANCH;
    public string Flag = "";

    DataSet ds = new DataSet();
    string COMP_WORKING_PERIOD = "", DB_CONN = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

        DB_CONN = comp_ConnectionStr;

        SELECT_BRANCH=Connection.Get_Company_Type();

        if (!string.IsNullOrEmpty(Request["id"]))
        {
            HiddenField1.Value = Request.QueryString["id"].ToString();
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

        con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);

         if (!IsPostBack)
         {
             LoadFinancialYear();

             ddl_WorkingPeriod.Items.Remove(Working_Period);
             ddl_WorkingPeriod.Items.Insert(0, Working_Period);
         }
       
        if (!IsPostBack)
        {
            int pageno = 1;

            Flag = "select_bind";
            ViewState["Flag"] = Flag;

            DB_CONNECTION_Path(1,Flag);
        }

        //txtParty.Attributes.Add("onblur", "javascript:CallServerside_Importer('" + txtParty.ClientID + "', '" + txtParty.ClientID + "')");
    }

    #region FinancialYear

    public void LoadFinancialYear()
    {
        DataTable dt_fin_year = DB_CONNECTION();

        int i = 0;

        while (dt_fin_year.Rows.Count-1>=i)
        {
            ddl_WorkingPeriod.Items.Add(dt_fin_year.Rows[i]["WORKING_PERIOD"].ToString());
            i += 1;
        }
        ddl_WorkingPeriod.Items.Remove(Working_Period);
        ddl_WorkingPeriod.Items.Insert(0, Working_Period);
    }
    #endregion
    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
        txtDescription.Text = "";
        txtParty.Text = "";
        Name_Search = "";
        btnSearch_Click(sender, e);
    }

    public DataTable DB_CONNECTION()
    {
            ds = (DataSet)Session["COMPANY_DETAILS_DS"];
            return ds.Tables[2];
    }

    public string DB_CONNECTION_Path(int pageno,string Flag)
    {
        string DB_Conn="";
        ds = (DataSet)Session["COMPANY_DETAILS_DS"];

        DataView view1 = ds.Tables[2].DefaultView;
        string a = ddl_WorkingPeriod.SelectedValue.ToString();
        view1.RowFilter = "WORKING_PERIOD = '" + a + "'";
        DataTable table1 = view1.ToTable();
        //-----------------------------------------------------------------//
        COMP_WORKING_PERIOD = table1.Rows[0]["WORKING_PERIOD"].ToString();

        if (ddl_WorkingPeriod.SelectedValue == COMP_WORKING_PERIOD)
        {
            DB_CONN = table1.Rows[0]["SERVER_NAME"].ToString();
        }

        hdn_DB_Conn.Value = DB_CONN;
        ViewState["Flag"] = Flag;
        gridbind(pageno, ViewState["Flag"].ToString());
        int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
        Add_Pageno(ii);
        return DB_Conn;
    }
    private void gridbind(int currentPageNumber1, string Flag)
    {
        if (Name_Search == "" && txtDescription.Text == "" && txtParty.Text == "" && txtRITCNo.Text == "")
        {
            erm.Eproduct_imp_id = "0";
            erm.Eproduct_imp_cth = "0";
            erm.Eproduct_imp_ceth = "0";
            erm.Eproduct_imp_ritc = "0";
            erm.Eproduct_imp_description = "0";
            erm.Ename = "select_bind";
            erm.EWorking_Period = SELECT_BRANCH;

        }
        else
        {
            erm.Eproduct_imp_id = "0";
            erm.Eproduct_imp_ceth = "";
            erm.Eproduct_imp_ritc = txtRITCNo.Text;
            erm.Eproduct_imp_description = Name_Search;
            erm.PARTY_NAME = txtParty.Text;
            erm.Ename = Flag;
            erm.EWorking_Period = SELECT_BRANCH;
        }

        erm.startRowIndex = Convert.ToString(currentPageNumber1);
        erm.maximumRows = Convert.ToString(gvdetails.PageSize);
        gvdetails.EmptyDataText = "No Record Found";
        gvdetails.DataSource = aps.GridView_Sorting(erm.RetrieveAll_Import_ItemDesc_Search_from_JOB_MASTER(DB_CONN), "ITEM_DESCRIPTION");       
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

        gridbind(currentpagenumber2, ViewState["Flag"].ToString());
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int pageno = 1;
        string A_Z = Hdn_GetValue.Value;
        if (A_Z == "A_Z")
        {
            Hdn_GetValue.Value = "";
            Flag = "select_con_Alpha_Search";
            ViewState["Flag"] = Flag;
        }
        else
        {
            Name_Search = txtDescription.Text;
            hdn_A_to_Z_Search.Value = "";
            Flag = "select_con";
            ViewState["Flag"] = Flag;
        }

        DB_CONNECTION_Path(pageno, Flag);
    }
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var row = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var desc = row.Cells[1].Text;
            var gendesc = row.Cells[2].Text;

            if (desc.Length > 45)
            {
                row.Cells[1].Text = desc.Substring(0, 45) + "...";
                row.Cells[1].ToolTip = desc;
            }

            if (gendesc.Length > 35)
            {
                row.Cells[2].Text = gendesc.Substring(0, 35) + "...";
                row.Cells[2].ToolTip = gendesc;
            }

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
            DB_CONNECTION_Path(Int32.Parse(ddlSelectPageno.SelectedValue.ToString()), ViewState["Flag"].ToString());
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
    public static string GetImporter(string custid)
    {
        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();
        Auto.Ename = "IMP_EXP_MASTER_IMPORTER_SEARCH";
        Auto.Enamesearch = custid;

        ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
        if (ds.Tables[0].Rows.Count > 0)
        {


            string Address1 = ds.Tables[0].Rows[0]["IMP_EXP_ADD1"].ToString();
            string Address2 = ds.Tables[0].Rows[0]["IMP_EXP_ADD2"].ToString();
            string Address3 = ds.Tables[0].Rows[0]["IMP_EXP_ADD3"].ToString();
            string Address4 = ds.Tables[0].Rows[0]["IMP_EXP_ADD4"].ToString();
            string Address5 = ds.Tables[0].Rows[0]["IMP_EXP_PIN_CODE"].ToString();
            string IECNo = ds.Tables[0].Rows[0]["IMP_EXP_IECNO"].ToString();
            string BranchNo = ds.Tables[0].Rows[0]["IMP_EXP_BRSLNO"].ToString();
            string IMP_EXP_TYPE = ds.Tables[0].Rows[0]["IMP_EXP_TYPE"].ToString();
            custid = Address1 + "~~" + Address2 + "~~" + Address3 + "~~" + Address4 + "~~" + Address5 + "~~" + IECNo + "~~" + BranchNo + "~~" + IMP_EXP_TYPE;
        }

        return custid;
    }
    protected void ddl_WorkingPeriod_SelectedIndexChanged(object sender, EventArgs e)
    {

        DB_CONNECTION_Path(1,"select_bind");
    }
}