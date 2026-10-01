using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

public partial class eRoyalMasters_Default : ThemeClass
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
    public string LoginDate, Name_Search;



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
        //mainmastopusernametxt.InnerText = "Welcome Mr." + currentuser;
        Div_Pagination.Visible = false;
        div_pagination1.Visible = false;
        
        ////----------------------------A to Z SEARCH OPTION--------------------------//
        //if (hdn_A_to_Z_Search.Value != "")
        //{
        //    Name_Search = hdn_A_to_Z_Search.Value;

        //}
        //else
        //{
        //    Name_Search = txtimpexpname.Text;

        //}

        //hdn_A_to_Z_Search.Value = "";
        ////----------------------------A to Z SEARCH OPTION--------------------------//
        if (!IsPostBack)
        {
            btnSearch_Click(sender, e);
            //DataTable dt = new DataTable();
            //gvdetails.EmptyDataText = "";
            //gvdetails.DataSource = dt;
            //gvdetails.DataBind();

        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int pageno = 1;

        gridbind(pageno);
        int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
        Add_Pageno(ii);
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
        gvdetails.EmptyDataText = "No Record Found";
        gvdetails.DataSource = erm.RetrieveAll_Exchange_master();

        gvdetails.DataBind();
        Grid_Total(currentPageNumber1, erm.result);


    }
    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
        txtFrom.Text = ""; txtTo.Text = ""; txtNOTN_No.Text = ""; txtNOTN_Date.Text = "";
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

    protected void imgbtn_Click(object sender, ImageClickEventArgs e)
    {


        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        Session["EXCHANGE_ID"] = gvdetails.DataKeys[gvrow.RowIndex].Value.ToString();


        //imgbtn.Attributes.Add("OnClientClick", "window.open('Suppliermasterentry.aspx','targetWindow','toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,resizable=yes,');return false;");
        string popupScript = "window.open('../eRoyalMasters/Exchange_Master.aspx?EXCHANGE_ID=" + Session["EXCHANGE_ID"].ToString() + "','NewWindow','width=620,height=450,menubar=no,left=200,top=90,bottom=60,resizable=0,ScrollBars=1');";
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "NewWindow", popupScript, true);

        //Page.ClientScript.RegisterStartupScript(typeof(string), "popup", "<script> window.open('../eRoyalMasters/Suppliermasterentry.aspx', '_self');</script>");



    }

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string values = this.gvdetails.DataKeys[e.Row.RowIndex]["EXCHANGE_ID"].ToString();


            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";


            e.Row.Attributes.Add("onclick", "Exchange_Master_update('" + values + "')");

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
}