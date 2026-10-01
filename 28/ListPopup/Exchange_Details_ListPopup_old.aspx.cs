
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

public partial class ListPopups_Exchange_Details_ListPopup : ThemeClass
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 10;
    DataSet dtuser = new DataSet();
    eroyalmaster erm = new eroyalmaster();
    SqlConnection con;
    Manipulation mo;
    AppSession aps = new AppSession();
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;

   

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

        if (!string.IsNullOrEmpty(Request["Invoice"]))
        {
            HiddenField1.Value = Request.QueryString["Invoice"].ToString();
        }

        if (!IsPostBack)
        {
            int pageno = 1;

            gridbind(pageno);
            int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
            Add_Pageno(ii);
        }
    }


    public void gridbind(int currentPageNumber1)
    {
        if (txtFrom.Text == "" && txtTo.Text == "" && txtNOTN_No.Text == "" && txtNOTN_Date.Text == "")
        {
            erm.Eexchange_id = "0";
            erm.Eexchange_effect_dt_from = "01/01/1900";
            erm.Eexchange_effect_dt_to = "01/01/1900";
            erm.Eexchange_nont_no = "0";
            erm.Eexchange_notn_date = "01/01/1900";
            erm.Ename = "select_bind";
            erm.EWorking_Period = Working_Period;


        }

        else
        {

            string strto_dt = txtTo.Text;
            string strfrom_dt = txtFrom.Text;
            string strNotification_dt = txtNOTN_Date.Text;
            string strNotification_no = txtNOTN_No.Text;
            string From_datestring = "", To_datestring = "", Notification_datestring = "", Empty_datestring = "01/01/1900", name = "select_con";
            //DateTime D_fto;
            //DateTime D_to;
            //DateTime D_Notification;
            DateTime Dt_fto;
            DateTime Dt_to;
            DateTime Dt_Notification;
            decimal D_fto;
            decimal D_to;
            decimal D_Notification;

            if (strfrom_dt != "")
            {
            }
            else
                strfrom_dt = Empty_datestring;

            if (strto_dt != "")
            {
            }
            else
                strto_dt = Empty_datestring;

            if (strNotification_dt != "")
            {
                if (strfrom_dt != Empty_datestring && strto_dt != Empty_datestring)
                {
                    name = "select_con";
                }
                else
                {
                    name = "select_NotificationDate";

                }
            }
            else
            {
                strNotification_dt = Empty_datestring;
            }
            if (strNotification_no != "")
            {
                if (strfrom_dt != Empty_datestring && strto_dt != Empty_datestring)
                {
                    name = "select_con";
                }
                else if (strNotification_no != "" && strNotification_dt != Empty_datestring)
                {
                    name = "select_NotificationDate";

                }
                else
                {
                    name = "select_Notification_No";

                }
            }
            else
            {
                strNotification_no = "";
            }
            Dt_fto = DateTime.ParseExact(strfrom_dt, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
            Dt_to = DateTime.ParseExact(strto_dt, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
            Dt_Notification = DateTime.ParseExact(strNotification_dt, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);

            From_datestring = string.Format("{0:yyyy-MM-dd}", Dt_fto);
            To_datestring = string.Format("{0:yyyy-MM-dd}", Dt_to);
            Notification_datestring = string.Format("{0:yyyy-MM-dd}", Dt_Notification);
            //D_fto = Convert.ToDecimal(From_datestring);
            //D_to = Convert.ToDecimal(To_datestring);
            //D_Notification = Convert.ToDecimal(Notification_datestring);

            erm.Eexchange_effect_dt_from = From_datestring;
            erm.Eexchange_effect_dt_to = To_datestring;

            erm.Eexchange_id = "0";

            erm.Eexchange_nont_no = strNotification_no;
            erm.Eexchange_notn_date = Notification_datestring;
            erm.Ename = name;
            erm.EWorking_Period = Working_Period;

        }
        erm.startRowIndex = Convert.ToString(currentPageNumber1);
        erm.maximumRows = Convert.ToString(gvdetails.PageSize);

        gvdetails.DataSource = erm.RetrieveAll_Exchange_master();

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
        if (HiddenField1.Value == "InvoiceCurrency")
        {
            string str1 = gvdetails.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            string str2 = gvdetails.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>GetRowValue('" + str1 + "','"+str2+"');</script>", false);

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open7", "javascript://GetRowValue('" + str2 + "')", false);
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open7", "window.close();", true);


        }
        else if (HiddenField1.Value == "Misc")
        {

            string str1 = gvdetails.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            string str2 = gvdetails.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>GetRowValue_Misc('" + str1 + "','" + str2 + "');</script>", false);

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open8", "javascript://GetRowValue_Misc('" + str1 + "','" + str2 + "')", true);


        }
        else if (HiddenField1.Value == "Agency")
        {

            string str1 = gvdetails.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            string str2 = gvdetails.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>GetRowValue_Agency('" + str1 + "','" + str2 + "');</script>", false);

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open9", "javascript://GetRowValue_Agency('" + str1 + "','" + str2 + "')", true);


        }
        else if (HiddenField1.Value == "Discount")
        {

            string str1 = gvdetails.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            string str2 = gvdetails.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>GetRowValue_Discount('" + str1 + "','" + str2 + "');</script>", false);

           // Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open10", "javascript://GetRowValue_Discount('" + str1 + "','" + str2 + "')", true);


        }
        else if (HiddenField1.Value == "Loading")
        {

            string str1 = gvdetails.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            string str2 = gvdetails.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>GetRowValue_Loading('" + str1 + "','" + str2 + "');</script>", false);

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open11", "javascript://GetRowValue_Loading('" + str1 + "','" + str2 + "')", true);


        }

        else if (HiddenField1.Value == "Freight")
        {

            string str1 = gvdetails.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            string str2 = gvdetails.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>GetRowValue_Freight('" + str1 + "','" + str2 + "');</script>", false);

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open12", "javascript://GetRowValue_Freight('" + str1 + "','" + str2 + "')", true);


        }
        else if (HiddenField1.Value == "Insurance")
        {

            string str1 = gvdetails.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            string str2 = gvdetails.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>GetRowValue_Insurance('" + str1 + "','" + str2 + "');</script>", false);

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open13", "javascript://GetRowValue_Insurance('" + str1 + "','" + str2 + "')", true);

        }
        else if (HiddenField1.Value == "HighSeaSale")
        {

            string str1 = gvdetails.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            string str2 = gvdetails.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>GetRowValue_HighSeaSale('" + str1 + "','" + str2 + "');</script>", false);

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open13", "javascript://GetRowValue_Insurance('" + str1 + "','" + str2 + "')", true);

        }
        else if (HiddenField1.Value == "ExportInvoiceCurrency")
        {

            string str1 = gvdetails.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            string str2 = gvdetails.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>GetRowValue_Export('" + str1 + "','" + str2 + "');</script>", false);

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open8", "javascript://GetRowValue_Misc('" + str1 + "','" + str2 + "')", true);


        }
        else if (HiddenField1.Value == "Commission")
        {

            string str1 = gvdetails.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            //string str2 = gvdetails.SelectedRow.Cells[4].Text;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>GetRowValue_Export_Commission('" + str1 + "');</script>", false);

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open8", "javascript://GetRowValue_Misc('" + str1 + "','" + str2 + "')", true);


        }
        else if (HiddenField1.Value == "FOBDisc")
        {

            string str1 = gvdetails.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            //string str2 = gvdetails.SelectedRow.Cells[4].Text;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>GetRowValue_Export_FOBDisc('" + str1 + "');</script>", false);

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open8", "javascript://GetRowValue_Misc('" + str1 + "','" + str2 + "')", true);


        }
        else if (HiddenField1.Value == "PackMisc")
        {

            string str1 = gvdetails.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            //string str2 = gvdetails.SelectedRow.Cells[4].Text;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>GetRowValue_Export_PackMisc('" + str1 + "');</script>", false);

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open8", "javascript://GetRowValue_Misc('" + str1 + "','" + str2 + "')", true);
        }
        else if (HiddenField1.Value == "OtherDeductions")
        {

            string str1 = gvdetails.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            //string str2 = gvdetails.SelectedRow.Cells[4].Text;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>GetRowValue_Export_OtherDeductions('" + str1 + "');</script>", false);

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open8", "javascript://GetRowValue_Misc('" + str1 + "','" + str2 + "')", true);
        }
        else if (HiddenField1.Value == "Export_Freight")
        {

            string str1 = gvdetails.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            //string str2 = gvdetails.SelectedRow.Cells[4].Text;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>GetRowValue_Export_Freight('" + str1 + "');</script>", false);

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open8", "javascript://GetRowValue_Misc('" + str1 + "','" + str2 + "')", true);
        }
        else if (HiddenField1.Value == "Export_Insurance")
        {

            string str1 = gvdetails.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            //string str2 = gvdetails.SelectedRow.Cells[4].Text;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>GetRowValue_Export_Insurance('" + str1 + "');</script>", false);

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open8", "javascript://GetRowValue_Misc('" + str1 + "','" + str2 + "')", true);
        }
        if (HiddenField1.Value == "ITEM_UNITCODE")
        {

            string str2 = gvdetails.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>GetRowValue_ITEM_UNITCODE('" + str2 + "');</script>", false);

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open7", "javascript://GetRowValue('" + str2 + "')", false);
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open7", "window.close();", true);


        }
        if (HiddenField1.Value == "ITEM_AMOUNTCODE")
        {

            string str2 = gvdetails.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>GetRowValue_ITEM_AMOUNTCODE('" + str2 + "');</script>", false);

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open7", "javascript://GetRowValue('" + str2 + "')", false);
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open7", "window.close();", true);


        }
        if (HiddenField1.Value == "Tariff_Amount_Code")
        {

            string str2 = gvdetails.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>GetRowValue_Tariff_Amount_Unit('" + str2 + "');</script>", false);

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open7", "javascript://GetRowValue('" + str2 + "')", false);
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open7", "window.close();", true);


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