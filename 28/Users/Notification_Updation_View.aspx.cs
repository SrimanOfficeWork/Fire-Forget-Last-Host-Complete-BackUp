using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Web;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using BussinessObject;
using System.IO;


public partial class Notification_Updation_View : ThemeClass
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 10;
    //public int pageno = 1;
    public int i, Total_Rows;

    public string AUTO_ID;
    adminmaster Admin_mas = new adminmaster();
    DataSet dtuser = new DataSet();
    Manipulation mo = new Manipulation();
    AdminManipulation am = new AdminManipulation();
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    DropDownList ddl = new DropDownList();
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    public string NOTIFICATIONF_ID = "";
    string SP_QUERY;
    //string datestring;
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string Upload_FileName = " ";
    public string errorFolder = "", fileName, attach_File, Upload_Flag;

    public string FILE_ATTACHMENT;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        //mainmastopusernametxt.InnerText = "Welcome Mr." + currentuser;
        //Div_Pagination.Visible = false;
        txt_Notificationsearch.Focus();

        if (!IsPostBack)
        {
           
            
            DataTable dt = new DataTable();
            gvdetails.EmptyDataText = "";
            gvdetails.DataSource = dt;
            gvdetails.DataBind();

            btnSearch_Click(sender, e);
            // int pageno = 1;
            // gridbind(pageno);
        }
    }
   
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int pageno = 1;
        gridbind(pageno);
    }

    public void gridbind(int currentPageNumber1)
    {
        Admin_mas.ENOTIFICATIONF_ID = "0";
        Admin_mas.ENOTIFICATION_NUMBER = txt_Notificationsearch.Text;
        Admin_mas.ENOTIFICATION_EFFECTIVEDATE = txteffectivedate_Search.Text;

        Admin_mas.Efromdate = txtfromdate.Text;
        Admin_mas.Etodate = txttodate.Text;
        //Admin_mas.ENOTIFICATION_DATEOFISSUE = txtdateofissue.Text;
        //Admin_mas.ENOTIFICATION_EFFECTIVEDATE = txteffective_date.Text;
        Admin_mas.ENOTIFICATION_DESCRIPTION = txtdescriptionsearch.Text;
        //Admin_mas.EFILE_ATTACHMENT = txtdescription.Text;
        //Admin_mas.EPort_name = txtPortNameSearch.Text;
        Admin_mas.Ename = "select_con";



        Admin_mas.startRowIndex = Convert.ToString(currentPageNumber1);
        Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
        //ds = erm.RetrieveAll_Adcode_MASTER();
        gvdetails.EmptyDataText = "No Record Found";
        DataSet ds = new DataSet();
        //gvdetails.DataSource = Admin_mas.RetrieveAll_AntiDumpting_master();
        ds = Admin_mas.RetrieveAll_Notification_Updation_master();
        gvdetails.DataSource = ds.Tables[0];

        gvdetails.DataBind();

        Grid_Total(currentPageNumber1, Admin_mas.Total_Rows);


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

  
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton txt = (LinkButton)e.Row.FindControl("lnkfileDownload");
            //LinkButton txtnew = (LinkButton)e.Row.FindControl("lnkfileDownload1");

            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes["onmouseout"] = "this.style.background='white'";
            //e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gvdetails, "Select$" + e.Row.RowIndex.ToString()));
            e.Row.Attributes.Add("ondblclick", ClientScript.GetPostBackClientHyperlink(this.gvdetails, "Select$" + e.Row.RowIndex.ToString()));

            //e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(this.gvdetails, "Edit$" + e.Row.RowIndex.ToString());
            //e.Row.Attributes["style"] = "cursor:pointer";
        }
    }

    protected void gvdetails_SelectedIndexChanged(object sender, EventArgs e)
    {

        ViewState["NOTIFICATIONF_ID"] = Convert.ToString(this.gvdetails.SelectedDataKey.Value);






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

    

    protected void lnkfileDownload_Click(object sender, EventArgs e)
    {
        LinkButton lnkbtn = sender as LinkButton;
        GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;

        //string EGM_ID = Convert.ToString(this.gvdetails.SelectedDataKey.Value);

        //lblfilename.Text= lnkbtn.Text;

        string filePath = (sender as LinkButton).CommandArgument;
        //ViewState["Upload_FileName"] = FileUploadNew.FileName;

        filePath = Server.MapPath("~/Submission/Notification_Updation/" + lnkbtn.Text);
        Response.ContentType = ContentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=\"" + Path.GetFileName(filePath));
        Response.WriteFile(filePath);
        Response.TransmitFile(filePath);
        Response.End();






    }



}