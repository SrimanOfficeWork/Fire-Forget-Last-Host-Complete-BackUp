using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ListPopups_IMPORTER_Details_ListPopup : ThemeClass
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 10;
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
    public string LoginDate, Name_Search, STANDARD_TYPE;
    public string BE_Type = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

        if (Session["BE_TYPE"] != null)
        {
            BE_Type = Session["BE_TYPE"].ToString();
        }
        else
        {
            BE_Type = "";
        }

        if (Session["STANDARD_TYPE"] != null)
        {
            STANDARD_TYPE = Session["STANDARD_TYPE"].ToString();
        }

        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (hdn_A_to_Z_Search.Value != "")
        {
            Name_Search = hdn_A_to_Z_Search.Value;
        }
        else
        {
            Name_Search = txtIECName.Text;
        }

        //hdn_A_to_Z_Search.Value = "";
        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (!string.IsNullOrEmpty(Request["seller_id"]))
        {
            hdn.Value = Request.QueryString["seller_id"].ToString().Trim();

            if (!string.IsNullOrEmpty(Request["NAME"]))
            {
                hdn_IEC_NO.Value = Request.QueryString["NAME"].ToString().Trim();
            }

            hdn_IEC_NO.Value = hdn_IEC_NO.Value.Trim();
            if (hdn_IEC_NO.Value.Length == 10)
            {
                txtIECNO.Text = hdn_IEC_NO.Value;
            }
        }
        
        if (!IsPostBack)
        {
            int pageno = 1;

            gridbind(pageno);
            int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
            Add_Pageno(ii);

            string a = "";
            if (!string.IsNullOrEmpty(Request["seller_id"]))
            {
                a = Request.QueryString["seller_id"].ToString().Trim();
            }
            if (hdn.Value == "seller" || a == "Import_Branch" || a == "Import_HighSea_Branch" || hdn.Value == "IMPORTER_DETAILS")
            {
                innerbox_MidMain_top_currency.InnerText = "Importer Master"; 
            }
            else if (hdn.Value == "EXPORT_ITEM_IECNO" || hdn.Value == "Exporter_AnnuxureC1" || hdn.Value == "Export_Item_Branch" || hdn.Value == "Exporter" || hdn.Value == "Exporter_item" || a == "Export_Item_Branch" || a == "Export_Branch" || hdn.Value == "Exporter_AnnuxureC1_NEW" )
            {
                innerbox_MidMain_top_currency.InnerText = "Exporter Master";
            }
            else if (hdn.Value == "Quote")
            {
                innerbox_MidMain_top_currency.InnerText = "Client Master";
            }
        }
    }


    private void gridbind(int currentPageNumber1)
    {
        erm.Eimp_exp_id = "0";
        erm.Eimp_exp_name = Name_Search;
        erm.Eimp_exp_iecno = txtIECNO.Text;
        erm.Eimp_exp_brslno = "0";
        erm.Eimp_state = "";

        if (hdn.Value == "IMPORTER_DETAILS" || hdn.Value == "Exporter")
        {
            erm.Ename = "select_con";
        }
        else
        {
            erm.Ename = "select_ADcode_STD_Search";
        }
        erm.EWorking_Period = Working_Period;
        erm.STANDARD_TYPE = STANDARD_TYPE;
        erm.startRowIndex = Convert.ToString(currentPageNumber1);
        erm.maximumRows = Convert.ToString(gvdetails.PageSize);

        ds = erm.RetrieveAll_Imp_exp_master_STD_TYPE();

        DataTable dtt = new DataTable();
        dtt = ds.Tables[0];

        //if (hdn.Value != "IMPORTER_DETAILS" && hdn.Value != "Exporter")
        //{
        //    dtt.Columns.Add("ADCODE_IEC_ADCODE");
        //    dtt.Columns.Add("IMPORT_ADCODE");
        //}


        gvdetails.DataSource = dtt;
        gvdetails.DataBind();
        Grid_Total(currentPageNumber1, erm.result);

    }

    private int CalculateTotalPages(double totalRows)
    {
        int totalPages = (int)Math.Ceiling(totalRows / gvdetails.PageSize);

        return totalPages;
    }
    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
        txtIECName.Text = "";
        txtIECNO.Text = "";

        Name_Search = "";
        btnSearch_Click(sender, e);
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
            Name_Search = txtIECName.Text;
            hdn_A_to_Z_Search.Value = "";
        }

        gridbind(pageno);
        int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
        Add_Pageno(ii);
    }
    protected void gvdetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        Date_Time rep = new Date_Time();

        string str = rep .Replace(gvdetails.SelectedRow.Cells[1].Text); 
        string str1 = rep .Replace(gvdetails.SelectedRow.Cells[2].Text);
        string str2 = rep .Replace(gvdetails.SelectedRow.Cells[3].Text);
        string str3 = rep .Replace(gvdetails.SelectedRow.Cells[4].Text);
        string str4 = rep .Replace(gvdetails.SelectedRow.Cells[5].Text);
        string str5 = rep .Replace(gvdetails.SelectedRow.Cells[6].Text);
        string str6 = rep .Replace(gvdetails.SelectedRow.Cells[7].Text);
        string str7 = rep .Replace(gvdetails.SelectedRow.Cells[8].Text);
        string str8 = rep .Replace(gvdetails.SelectedRow.Cells[9].Text);
        string str9 = rep .Replace(gvdetails.SelectedRow.Cells[10].Text);

        string str_TIN = rep.Replace(gvdetails.SelectedRow.Cells[11].Text);
        string str_StateCode = rep.Replace(gvdetails.SelectedRow.Cells[12].Text);
        string str_ADCode = rep.Replace(gvdetails.SelectedRow.Cells[13].Text);

        string str_Type_Of_Exporter = rep.Replace(gvdetails.SelectedRow.Cells[14].Text);
        string str_MarksNos = rep.Replace(gvdetails.SelectedRow.Cells[15].Text);
        string str_Import_ADCode= rep.Replace(gvdetails.SelectedRow.Cells[16].Text);


        string M_COMMERCIAL_DETAILS_STATUS = rep.Replace(gvdetails.SelectedRow.Cells[17].Text);
        string M_COMMERCIAL_TAX_STATENAME = rep.Replace(gvdetails.SelectedRow.Cells[18].Text);
        string M_COMMERCIAL_TAX_STATECODE = rep.Replace(gvdetails.SelectedRow.Cells[19].Text);
        string M_COMMERCIAL_TAX_REGISTRATION_NO = rep.Replace(gvdetails.SelectedRow.Cells[20].Text);
        string M_COMMERCIAL_TAX_TYPE = rep.Replace(gvdetails.SelectedRow.Cells[21].Text);

        string str_GSTN_TYPE = rep.Replace(gvdetails.SelectedRow.Cells[22].Text);
        string str_GSTN_ID = rep.Replace(gvdetails.SelectedRow.Cells[23].Text);
        string str_Bank_AccNo = rep.Replace(gvdetails.SelectedRow.Cells[24].Text);
        string str_IFSC_Code = rep.Replace(gvdetails.SelectedRow.Cells[25].Text);

        string Warehouse_code = rep.Replace(gvdetails.SelectedRow.Cells[26].Text);
        string Payment_method = rep.Replace(gvdetails.SelectedRow.Cells[27].Text);

        if (hdn.Value == "seller")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_ImporterDetails_Seller('" + str + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "','" + str5 + "','" + str6 + "','" + str7 + "')", true);
        }

        if (hdn.Value == "IMPORTER_DETAILS" || hdn.Value == "Import_Branch")
        {
            if (str_Import_ADCode != "")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_ImporterDetails_Commercial('" + HttpUtility.HtmlEncode(str) + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "','" + str5 + "','" + str6 + "','" + str7
                    + "','" + str8 + "','" + str_TIN + "','" + str_StateCode + "','" + str_Import_ADCode
                    + "' ,'" + M_COMMERCIAL_DETAILS_STATUS + "' ,'" + M_COMMERCIAL_TAX_STATENAME + "','" + M_COMMERCIAL_TAX_STATECODE + "','" + M_COMMERCIAL_TAX_REGISTRATION_NO + "','" + M_COMMERCIAL_TAX_TYPE + "','" + str_GSTN_TYPE + "','" + str_GSTN_ID + "','" + Session["COMPANY_ID"].ToString() + "','" + Warehouse_code + "','" + Payment_method + "','" + BE_Type + "')", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_ImporterDetails_Commercial('" + HttpUtility.HtmlEncode(str) + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "','" + str5 + "','" + str6 + "','" + str7 + "','" + str8 + "','" + str_TIN + "','" + str_StateCode + "','" + str_ADCode
                     + "' ,'" + M_COMMERCIAL_DETAILS_STATUS + "' ,'" + M_COMMERCIAL_TAX_STATENAME + "','" + M_COMMERCIAL_TAX_STATECODE + "','" + M_COMMERCIAL_TAX_REGISTRATION_NO + "','" + M_COMMERCIAL_TAX_TYPE + "','" + str_GSTN_TYPE + "','" + str_GSTN_ID + "','" + Session["COMPANY_ID"].ToString() + "','" + Warehouse_code + "','" + Payment_method + "','" + BE_Type + "')", true);
            }
        }
        if (hdn_IEC_NO.Value.Length == 10) 
        {
            string a = "";
            
            if (!string.IsNullOrEmpty(Request["seller_id"]))
            {
                a = Request.QueryString["seller_id"].ToString().Trim();
            }
           
            if (a == "Import_Branch")
            {
                //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_ImporterDetails('" + str + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "','" + str5 + "','" + str6 + "','" + str7 + "','" + str8 + "','" + str_ADCode + "')", true);
            }
            else if(a == "Import_HighSea_Branch")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_ImporterDetails_Seller('" + str + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "','" + str5 + "','" + str6 + "','" + str7 + "')", true);
            }
            else if (a == "Export_Branch")
            {
                //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_ExporterDetails('" + str + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "','" + str5 + "','" + str6 + "','" + str7 + "','" + str9 + "')", true);
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_ExporterDetails('" + str + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "','" + str5 + "','" + str6 + "','" + str7 + "','" + str9 + "','" + str_Type_Of_Exporter + "','" + str_MarksNos + "','" + str_ADCode + "','" + str_GSTN_TYPE + "','" + str_GSTN_ID + "','" + str_Bank_AccNo + "','" + str_IFSC_Code + "')", true);
            }
            else if (a == "Export_Item_Branch")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_ExporterDetails_Item('" + str + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "','" + str5 + "','" + str6 + "','" + str7 + "')", true);
            }
           

        }
        if (hdn.Value == "EXPORT_ITEM_IECNO")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_ImporterDetails_Export_Item('" + str + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "','" + str5 + "','" + str6 + "','" + str7 + "')", true);

        }
        else if (hdn.Value == "Exporter_AnnuxureC1")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_GetRowValue_ExporterDetailsExporterDetails_Item_AnnuxureC1('" + str + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "','" + str5 + "','" + str6 + "','" + str7 + "')", true);
        }
        else if (hdn.Value == "Exporter_AnnuxureC1_NEW")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_ExporterDetails_Item_AnnuxureC1_NEW('" + str + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "','" + str5 + "','" + str6 + "','" + str7 + "')", true);
        }
        else if (hdn.Value == "Exporter")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_ExporterDetails('" + HttpUtility.HtmlEncode(str) + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "','" + str5 + "','" + str6 + "','" + str7 + "','" + str9 + "','" + str_Type_Of_Exporter + "','" + str_MarksNos + "','" + str_ADCode + "','" + str_GSTN_TYPE + "','" + str_GSTN_ID + "','" + str_Bank_AccNo + "','" + str_IFSC_Code + "','" + str8 + "')", true);
        }
        else if (hdn.Value == "Exporter_item")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_Exporter_3rdparty_Details('" + str + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "','" + str5 + "','" + str6 + "','" + str7 + "','" + str9 + "','" + str_GSTN_TYPE + "','" + str_GSTN_ID + "')", true);
        }
        else if (hdn.Value == "Quote")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_ClientDetails_Quote('" + str + "')", true);
        }
        else if (hdn.Value == "SVB")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_ImporterDetails_SVB('" + str + "')", true);
        }
        else if (hdn.Value == "Bill_Exp_name")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_Bill_Exp_name('" + str + "','" + str1 + "',' " + str2 + "',' " + str3 + "',' " + str4 + "',' " + str5 + "' ,'" + str7 + "')", true);
        }
        else if (hdn.Value == "GST_Bill_Exp_name")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_GST_Bill_Exp_name('" + str + "','" + str1 + "',' " + str2 + "',' " + str3 + "',' " + str4 + "',' " + str5 + "' ,'" + str7 + "','" + str_GSTN_ID + "')", true);
        }
        else if (hdn.Value == "Bill_Imp_name")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_Bill_Imp_name('" + str + "','" + str1 + "',' " + str2 + "','" + str3 + "','" + str4 + "','" + str5 + "','" + str7 + "')", true);
        }      
        else if (hdn.Value == "GST_Bill_Imp_name")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_GST_Bill_Imp_name('" + str + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "','" + str5 + "','" + str7 + "','" + str_GSTN_ID + "','" + M_COMMERCIAL_TAX_STATECODE + "','" + M_COMMERCIAL_TAX_STATENAME + "')", true);
        }

        else if (hdn.Value == "GST_Bill_Cus_name")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_GST_Bill_Cus_name('" + str + "','" + str1 + "',' " + str2 + "','" + str3 + "','" + str4 + "','" + str5 + "','" + str7 + "','" + str_GSTN_ID + "','" + M_COMMERCIAL_TAX_STATECODE + "','" + M_COMMERCIAL_TAX_STATENAME + "')", true);
        }
        else if (hdn.Value == "ImporterDetails_Egm")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_ImporterDetails_Egm('" + str + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "' )", true);
        }
        else if (hdn.Value == "Supporting_Doc_Details")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_Supporting_Doc_Details('" + str + "','" + str6 + "','" + str1 + "','" + str2 + "','" + str4 + "','" + str5 + "' )", true);
        }
        else if (hdn.Value == "PDFSETTINGMASTER")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_ImporterSettingDetails('" + str + "','" + str7 + "','" + str6 + "','" + str_Import_ADCode + "')", true);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_ImporterDetails('" + str + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "','" + str5 + "','" + str6 + "','" + str7 + "','" + str8 + "','" + str_ADCode + "')", true);

        }
                
    }
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";

            e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvdetails, "Select$" + e.Row.RowIndex);

            if (hdn.Value == "IMPORTER_DETAILS" || hdn.Value == "Import_Branch")
            {
                e.Row.Cells[16].CssClass = "column_style_left";
                e.Row.Cells[16].ControlStyle.CssClass = "column_style_left";

                //e.Row.Cells[16].Visible = true;
                gvdetails.HeaderRow.Cells[16].Visible=true;
                
                e.Row.Cells[13].CssClass = "hideGridColumn";
                e.Row.Cells[13].ControlStyle.CssClass = "hideGridColumn";
                gvdetails.HeaderRow.Cells[13].Visible = false;

                gvdetails.Columns[20].Visible = true;
                gvdetails.Columns[21].Visible = true;
                gvdetails.Columns[22].Visible = false;
                gvdetails.Columns[23].Visible = false;

            }
            else if (hdn.Value == "Exporter" || hdn.Value == "Export_Branch")
            {
                e.Row.Cells[16].CssClass = "hideGridColumn";
                e.Row.Cells[16].ControlStyle.CssClass = "hideGridColumn";
                gvdetails.HeaderRow.Cells[16].Visible = false;

                e.Row.Cells[13].CssClass = "column_style_left";
                e.Row.Cells[13].ControlStyle.CssClass = "column_style_left";
                gvdetails.HeaderRow.Cells[13].Visible = true;

                gvdetails.Columns[20].Visible = false;
                gvdetails.Columns[21].Visible = false;
                gvdetails.Columns[22].Visible = true;
                gvdetails.Columns[23].Visible = true;


            }
            else
            {
                e.Row.Cells[13].CssClass = "hideGridColumn";
                e.Row.Cells[13].ControlStyle.CssClass = "hideGridColumn";
                gvdetails.HeaderRow.Cells[13].Visible = false;
                gvdetails.HeaderRow.Cells[20].Visible = false;

                e.Row.Cells[16].CssClass = "hideGridColumn";
                e.Row.Cells[16].ControlStyle.CssClass = "hideGridColumn";
                gvdetails.HeaderRow.Cells[16].Visible = false;                
                gvdetails.HeaderRow.Cells[21].Visible = true;

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
    ///auto search
    [System.Web.Services.WebMethod]
    public static string GetClient_Name(string txtIec_Code)
    {
        string Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();
        string ADCODE_BANK_ACCOUNT_NO = "";
        if (txtIec_Code.Length == 10)
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            // custid = Auto.Country_Master_FromClientSide_Calling(custid);
            eroyalmaster erm = new eroyalmaster();
            erm.Eadcodeid = "0";
            erm.ADCODE_IEC_ADCODE = "";
            erm.ADCODE_IEC_CODE = txtIec_Code;
            erm.Ename = "Get_Adcode";
            erm.EWorking_Period = Working_Period;

            ds = erm.RetrieveAll_Adcode_MASTER();
            if (ds.Tables[0].Rows.Count > 0)
            {

                txtIec_Code = ds.Tables[0].Rows[0]["ADCODE_IEC_ADCODE"].ToString();
                ADCODE_BANK_ACCOUNT_NO = ds.Tables[0].Rows[0]["ADCODE_BANK_ACCOUNT_NO"].ToString();

            }
            else
            {
                txtIec_Code = "";
            }

        }
        else
        {
            txtIec_Code = "";
        }
        return txtIec_Code = txtIec_Code + "~~" + ADCODE_BANK_ACCOUNT_NO;
    }
    ///auto search
}