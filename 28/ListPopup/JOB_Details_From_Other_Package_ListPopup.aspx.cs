using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
public partial class ListPopups_JOB_Details_From_Other_Package_ListPopup : ThemeClass
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

    GST_Imp_Invoice BI = new GST_Imp_Invoice();
    Billing_UserBO ObjUBO = new Billing_UserBO();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();


        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

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
            Name_Search = txtRefNo.Text;
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
                txtRefNo.Text = hdn_IEC_NO.Value;
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
            else if (hdn.Value == "EXPORT_ITEM_IECNO" || hdn.Value == "Exporter_AnnuxureC1" || hdn.Value == "Export_Item_Branch" || hdn.Value == "Exporter" || hdn.Value == "Exporter_item" || a == "Export_Item_Branch" || a == "Export_Branch" || hdn.Value == "Exporter_AnnuxureC1_NEW")
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
            ObjUBO.JOBNO = txtJobNo.Text;            
            ObjUBO.FILE_REF_NO = txtRefNo.Text;            
            ObjUBO.Sp_Name = "JOB_DETAILS_FROM_OTHER_PACKAGE_SP";                         
            ds = BI.JOB_DETAILS_FROM_OTHER_PACKAGE_SP_Binding(ObjUBO);
            gvdetails.DataSource = ds;
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
        txtJobNo.Text = "";
        txtRefNo.Text = "";

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
            Name_Search = txtRefNo.Text;
            hdn_A_to_Z_Search.Value = "";
        }

        gridbind(pageno);
        int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
        Add_Pageno(ii);
    }
    //protected void gvdetails_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    Date_Time rep = new Date_Time();

    //    string str = rep.Replace(gvdetails.SelectedRow.Cells[1].Text);
    //    string str1 = rep.Replace(gvdetails.SelectedRow.Cells[2].Text);
    //    string str2 = rep.Replace(gvdetails.SelectedRow.Cells[3].Text);
    //    string str3 = rep.Replace(gvdetails.SelectedRow.Cells[4].Text);
    //    string str4 = rep.Replace(gvdetails.SelectedRow.Cells[5].Text);

    //    if (hdn.Value == "seller")
    //    {
    //        //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_ImporterDetails_Seller('" + str + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "','" + str5 + "','" + str6 + "','" + str7 + "')", true);
    //        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_ImporterDetails_Seller('" + str + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "')", true);
    //    }

    //    //else
    //    //{
    //        //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_ImporterDetails('" + str + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "','" + str5 + "','" + str6 + "','" + str7 + "','" + str8 + "','" + str_ADCode + "')", true);
    //    //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_ImporterDetails('" + str + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "')", true);
    //    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_job_Details_from_Other_Package('" + str + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "')", true);
        

    //    //}
    //}
    protected void gvdetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        Date_Time rep = new Date_Time();
        string tjobno = rep.Replace(gvdetails.SelectedRow.Cells[1].Text); 
        string tFILE_REF_NO = rep.Replace(gvdetails.SelectedRow.Cells[2].Text); 
        string tITEM_DESCRIPTION = rep.Replace(gvdetails.SelectedRow.Cells[3].Text); 
        string tASSESSABLEVALUE = rep.Replace(gvdetails.SelectedRow.Cells[4].Text); 
        string tMAWB_MBL_NO = rep.Replace(gvdetails.SelectedRow.Cells[5].Text); 
        string tMAWB_MBL_DT = rep.Replace(gvdetails.SelectedRow.Cells[6].Text); 
        string tHAWB_HBL_NO = rep.Replace(gvdetails.SelectedRow.Cells[7].Text); 
        string tHAWB_HBL_DT = rep.Replace(gvdetails.SelectedRow.Cells[8].Text); 
        string tPKGS_VALUE = rep.Replace(gvdetails.SelectedRow.Cells[9].Text); 
        string tPKGS_UOM = rep.Replace(gvdetails.SelectedRow.Cells[10].Text);
        string tGRWT_VALUE = rep.Replace(gvdetails.SelectedRow.Cells[11].Text);
        string tGRWT_UOM = rep.Replace(gvdetails.SelectedRow.Cells[12].Text); 
        string tNETWT_VALUE = rep.Replace(gvdetails.SelectedRow.Cells[13].Text); 
        string tNETWT_UOM = rep.Replace(gvdetails.SelectedRow.Cells[14].Text); 
        string tCOUNTRY_OF_SHIPMENT = rep.Replace(gvdetails.SelectedRow.Cells[15].Text); 
        string tPORT_OF_SHIPMENT = rep.Replace(gvdetails.SelectedRow.Cells[16].Text);

        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_job_Details_from_Other_Package('" + tjobno + "','" + tFILE_REF_NO + "','" + tITEM_DESCRIPTION + "','" + tASSESSABLEVALUE + "','" + tMAWB_MBL_NO + "','" + tMAWB_MBL_DT + "','" + tHAWB_HBL_NO + "','" + tHAWB_HBL_DT + "','" + tPKGS_VALUE + "','" + tPKGS_UOM + "','" + tGRWT_VALUE + "','" + tGRWT_UOM + "','" + tNETWT_VALUE + "','" + tNETWT_UOM + "','" + tCOUNTRY_OF_SHIPMENT + "','" + tPORT_OF_SHIPMENT + "')", true);
        
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
                gvdetails.HeaderRow.Cells[16].Visible = true;

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
                //e.Row.Cells[13].CssClass = "hideGridColumn";
                //e.Row.Cells[13].ControlStyle.CssClass = "hideGridColumn";
                //gvdetails.HeaderRow.Cells[13].Visible = false;
                //gvdetails.HeaderRow.Cells[20].Visible = false;

                //e.Row.Cells[16].CssClass = "hideGridColumn";
                //e.Row.Cells[16].ControlStyle.CssClass = "hideGridColumn";
                //gvdetails.HeaderRow.Cells[16].Visible = false;
                //gvdetails.HeaderRow.Cells[21].Visible = true;

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