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
            Name_Search = txtimpexpname.Text;

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
        txtimpexpname.Text = "";

        Name_Search = "";
        btnSearch_Click(sender, e);
    }
    private void gridbind(int currentPageNumber1)
    {
        erm.Esupid = "0";
        erm.Esup_name = Name_Search;
        erm.Ename = "select_con";
        erm.EWorking_Period = Working_Period;

        erm.startRowIndex = Convert.ToString(currentPageNumber1);
        erm.maximumRows = Convert.ToString(gvdetails.PageSize);
        gvdetails.DataSource = erm.RetrieveAll_Supplier_MASTER();
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
        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();
        DataSet ds_2 = new DataSet();

        string txt_supplier_name = string.Empty ,ALL_Item = string.Empty,Connect = string.Empty ,txtSVB_RefNo = string.Empty,SVB_CustomHouse = string.Empty ,LoadingOn = string.Empty
              , txtAssesable_Rate = string.Empty, txtDuty_Rate = string.Empty, Ass_Status = string.Empty, Duty_Status = string.Empty, svb_date = string.Empty;

        string str = rep.Replace(gvdetails.SelectedRow.Cells[1].Text).Replace("'","''");
        string SUP_BRANCH_SLNO = rep.Replace(gvdetails.SelectedRow.Cells[2].Text);
        string str1 = rep.Replace(gvdetails.SelectedRow.Cells[3].Text);
        string str2 = rep.Replace(gvdetails.SelectedRow.Cells[4].Text);
        string str3 = rep.Replace(gvdetails.SelectedRow.Cells[5].Text);
        string str4 = rep.Replace(gvdetails.SelectedRow.Cells[6].Text);
        string str5 = rep.Replace(gvdetails.SelectedRow.Cells[7].Text);
        string str6 = rep.Replace(gvdetails.SelectedRow.Cells[8].Text);
        string str_br = SUP_BRANCH_SLNO + "--" + str; // Added by pandiyan on 16/02/2026 send with brslno for ex upload

        if (hdn.Value == "Supplier")
        {
            if (str != null && str != "")
            {

                if (Session["IMPORT_JOBNO"] != null || Session["IMPORT_JOBDATE"] != null)
                {
                    IMPORT_JOBNO = Session["IMPORT_JOBNO"].ToString();
                    SVR.SVB_ID_N = IMPORT_JOBNO;
                    SVR.flag = "Get_Importername";
                    SVR.BRANCH_CODE = SELECT_BRANCH;
                    ds_imp = SVR.SVB_Select();

                    if (ds_imp.Tables[0].Rows.Count > 0)
                    {
                        ImporterName = ds_imp.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                    }
                }
               
                SVR.SVB_ID_N = "";
                SVR.flag = "Select_all";
                ds_2 = SVR.SVB_Select();
                string importer_name = (ImporterName).Replace("'","''");

                DataView view1 = ds_2.Tables[0].DefaultView;
                view1.RowFilter = "IMP_NAME = '" + importer_name + "'  and " + "SUPPLIER_NAME = '" + str + "'";

                DataTable table1 = view1.ToTable();
                DataSet dss1 = new DataSet();
                dss1.Tables.Add(table1);

           
                if (dss1.Tables[0].Rows.Count > 0)
                {
                    if (dss1.Tables[0].Rows.Count == 1)
                    {
                        string chksvb = dss1.Tables[0].Rows[0]["SVB_RELATION"].ToString();

                        txtSVB_RefNo = dss1.Tables[0].Rows[0]["SVB_REF_NO"].ToString();
                        SVB_CustomHouse = dss1.Tables[0].Rows[0]["SVB_CUSTOM_HOUSE"].ToString();
                        LoadingOn = dss1.Tables[0].Rows[0]["SVB_LOADING_ON"].ToString();

                        svb_date = dss1.Tables[0].Rows[0]["SVB_REF_DATE"].ToString();

                        string load_on = "";
                        if (LoadingOn == "A")
                        {
                            load_on = "Assessable";
                        }
                        else if (LoadingOn == "D")
                        {
                            load_on = "Duty";
                        }
                        else if (LoadingOn == "B")
                        {
                            load_on = "Both";
                        }
                        txtAssesable_Rate = dss1.Tables[0].Rows[0]["SVB_ASSESABLE_RATE"].ToString();
                        txtDuty_Rate = dss1.Tables[0].Rows[0]["SVB_DUTY_RATE"].ToString();
                        Ass_Status = dss1.Tables[0].Rows[0]["SVB_ASSESABLE_STATUS"].ToString();
                        string assesable = "";
                        if (Ass_Status == "P")
                        {
                            assesable = "Provisional";
                        }
                        else if (Ass_Status == "F")
                        {
                            assesable = "Final";
                        }

                        Duty_Status = dss1.Tables[0].Rows[0]["SVB_DUTY_STATUS"].ToString();

                        string duty_status = "";
                        if (Duty_Status == "P")
                        {
                            duty_status = "Provisional";

                        }
                        else if (Duty_Status == "F")
                        {
                            duty_status = "Final";
                        }


                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_Supplier_with_SVBDetails('" + HttpUtility.HtmlEncode(str.Replace("''", "'")) + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "','" + str5 + "','" + str6 + "','" + txtSVB_RefNo + "','" + SVB_CustomHouse + "','" + load_on + "','" + txtAssesable_Rate + "','" + txtDuty_Rate + "','" + assesable + "','" + duty_status + "','" + svb_date + "','" + chksvb + "','" + SUP_BRANCH_SLNO + "')", true);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_Supplier_with_SVBDetails('" + HttpUtility.HtmlEncode(str.Replace("''", "'")) + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "','" + str5 + "','" + str6 + "','" + txtSVB_RefNo + "','" + SVB_CustomHouse + "','" + LoadingOn + "','" + txtAssesable_Rate + "','" + txtDuty_Rate + "','" + Ass_Status + "','" + Duty_Status + "','" + svb_date + "','" + "N" + "','" + SUP_BRANCH_SLNO + "')", true);
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_Supplier_with_SVBDetails('" + HttpUtility.HtmlEncode(str.Replace("''", "'")) + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "','" + str5 + "','" + str6 + "','" + txtSVB_RefNo + "','" + SVB_CustomHouse + "','" + LoadingOn + "','" + txtAssesable_Rate + "','" + txtDuty_Rate + "','" + Ass_Status + "','" + Duty_Status + "','" + svb_date + "','" + "N" + "','" + SUP_BRANCH_SLNO + "')", true);
                }
            }
        }
        else if (hdn.Value == "Seller")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_Seller('" + str + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "','" + str5 + "','" + str6 + "')", true);
        }
        else if (hdn.Value == "Broker")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_Broker('" + str + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "','" + str5 + "','" + str6 + "')", true);
        }
        else if (hdn.Value == "SVB")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_SVB('" + str + "')", true);
        }
        else if (hdn.Value == "Bill_Supplier_name")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_Bill_Supplier('" + str + "','" + str2 + " " + str3 + " " + str4 + "')", true);
        }
        else if (hdn.Value == "GSupplier")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_Gen_Xl_Supplier('" + str_br + "')", true);
        }
        else if (hdn.Value == "Sup_Supplier")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_Sup_Supplier('" + str + "')", true);
        }
        else if (hdn.Value == "Beneficiary")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_Beneficiary('" + str + "','" + str1 + "','" + str2 + "','" + str4 + "','" + str6 + "')", true);
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
