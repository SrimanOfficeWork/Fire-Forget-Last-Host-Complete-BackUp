using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

public partial class Transaction_GeneralSearch : ThemeClass
{

    public int currentPageNumber, pageno, currentPageNumber1;
    public double totalRows;
    public const int PageSize=0;
    DataTable dt = new DataTable();
    DataSet dtuser = new DataSet();
    DataSet dss = new DataSet();
    eroyalmaster erm = new eroyalmaster();
    //Transaction Transact = new Transaction();
    Transaction Transact = new Transaction();
    SqlConnection con;
    Manipulation mo;
    AppSession aps = new AppSession();
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, Name_Search;
    public string SELECT_TYPE, SELECT_BRANCH;
  
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        // commented for areawise implementation on 05-mar-2020
        /*

        if (Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = Session["SELECT_TYPE"].ToString();

            if (SELECT_TYPE == "Branchwise Job")
            {
                SELECT_BRANCH = currentbranch;
            }
            else
            {
                SELECT_BRANCH = "";
            }
        }
        else
        {
            SELECT_BRANCH = "";
        }
        
  * */
        SELECT_BRANCH = Connection.Get_Company_Type();
        //mainmastopusernametxt.InnerText = "Welcome Mr." + currentuser;
        Div_Pagination.Visible = false;
        div_pagination1.Visible = false;
        if (!IsPostBack)
        {
          
            DataTable dt = new DataTable();
            gvdetails.EmptyDataText = "";
            gvdetails.DataSource = dt;
            gvdetails.DataBind();
            
        }
             
        

        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (hdn_A_to_Z_Search.Value != "")
        {
            Name_Search = hdn_A_to_Z_Search.Value;

        }
        //----------------------------A to Z SEARCH OPTION--------------------------//
        else
        {
            Name_Search = txtImporterName.Text;
           
        }
        //set if textbox !=null after textbox clear
        if (txtJobNo.Text != "" || txtImporterName.Text != "" || txtTransport_Mode.Text != "" || txtCustomsHouse.Text != "")
        {

            ViewState["pageno"] = null;
            ViewState["pageno"] = "1";
        }
        //set if textbox !=null after textbox clear

        else
        {
            ViewState["pageno"] = null;
            
        }
        //hdn_A_to_Z_Search.Value = "";
        
        
    }
  
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        hdn_A_to_Z_Search.Value = "";
        if (Name_Search == "")
        {
            //set page 1 button click  
            if (txtJobNo.Text != "" || Name_Search != "" || txtTransport_Mode.Text != "" || txtCustomsHouse.Text != "")
            {
                pageno = 100000001;
                ViewState["pageno"] = null;
                ViewState["pageno"] = "1";
            }
            else
            {
                ViewState["pageno"] = null;

                pageno = 100000000;
            }
            //set page 1 button click  


            gridbind(pageno);
            int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
            Add_Pageno(ii);
        }
        else
        {
            int pageno = 1;

            grid_Bind_NameSearch(pageno);
            int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
            Add_Pageno(ii);
        }
    }
    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
        txtCustomsHouse.Text = "";
        txtImporterName.Text = "";
        txtJobNo.Text = "";
        txtTransport_Mode.Text = "";
        Name_Search = "";
        btnSearch_Click(sender, e);
    }
    protected void btn_A_TO_Z_Search_Click(object sender, EventArgs e)
    {
       
        if (Name_Search == "")
        {
            //set page 1 button click  
            if (txtJobNo.Text != "" || Name_Search != "" || txtTransport_Mode.Text != "" || txtCustomsHouse.Text != "")
            {
                pageno = 100000001;
                ViewState["pageno"] = null;
                ViewState["pageno"] = "1";
            }
            else
            {
                ViewState["pageno"] = null;

                pageno = 100000000;
            }
            //set page 1 button click  


            gridbind(pageno);
            int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
            Add_Pageno(ii);
        }
        else
        {
            int pageno = 1;

            grid_Bind_NameSearch(pageno);
            int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
            Add_Pageno(ii);
        }
    }
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //Session.Contents.Remove("TRANSPORT_MODE");
        //Session.Contents.Remove("IMPORT_JOBNO");
        //Session.Contents.Remove("IMPORT_JOBDATE");
        //Session.Contents.Remove("FILING_STATUS");
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string values = this.gvdetails.DataKeys[e.Row.RowIndex]["JOBID"].ToString();
            string str = this.gvdetails.DataKeys[e.Row.RowIndex]["JOBNO"].ToString();

            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";

          // e.Row.Attributes.Add("onclick", "BE_Entry_Details('" + values + "','" + str + "')");

            e.Row.Attributes.Add("onclick", "BE_Entry_Details('" + str + "','" + str + "')");

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

    public void gridbind(int currentPageNumber1)
    {

        int ttl = 0;
        int c1 = currentPageNumber1;
        //Transact.JOBID = "0";
        Transact.JOBNO = txtJobNo.Text;
        Transact.IMPORTER_NAME = Name_Search;
        Transact.TRANSPORT_MODE = txtTransport_Mode.Text;
        Transact.CUSTOMS_HOUSE = txtCustomsHouse.Text;
        Transact.Ename = "select_con";

        //Transact.WORKING_PERIOD = Working_Period;
        Transact.WORKING_PERIOD = SELECT_BRANCH;

        //if textbox !=null working

        if (currentPageNumber1 == 100000000 || currentPageNumber1 == 100000001)
        {
            Transact.startRowIndex = Convert.ToString(currentPageNumber1);
            
            Transact.maximumRows = Convert.ToString(gvdetails.PageSize);
            lblCurrentPage.Text = "1";
        }
        //if textbox !=null working

        //if textbox =null working

        else
        {
            ttl=CalculateTotalPages(double.Parse(lblTotalPages.Text));
           
            if (Int32.Parse(lblCurrentPage.Text) == ttl)
            {
                Transact.startRowIndex = "1";
                Transact.maximumRows = Convert.ToString(currentPageNumber1);
            }
            
            else
            {
                Transact.startRowIndex = Convert.ToString(currentPageNumber1+1);
                Transact.maximumRows = Convert.ToString(gvdetails.PageSize);
            }
            
        }
        gvdetails.EmptyDataText = "No Record Found";

       
        DataView dataView = new DataView(Transact.RetrieveAll_General_Details_datatable());
        if (ViewState["pageno"] == null)
        {
            dataView.Sort = "JOBNO DESC";
            ViewState["pageno"] = null;
        }

        else
        {
            dataView.Sort = "JOBNO ASC";

        }
        gvdetails.DataSource = dataView;
        gvdetails.DataBind();
        // }
        //gvdetails.DataSource = Transact.RetrieveAll_General_Details();

        //gvdetails.DataBind();

        if (gvdetails.Rows.Count > 0)
        {
            Div_Pagination.Visible = true;
            div_pagination1.Visible = true;


        }
        else 
        {
            Div_Pagination.Visible = false;
            div_pagination1.Visible = false;
            
        }
        // get the total rows
        totalRows = (double)Transact.result;
        
        lblTotalPages.Text = Convert.ToString(totalRows);

       
        //if page no = 1 working
        if (CalculateTotalPages(double.Parse(lblTotalPages.Text)) == 1)
        {
            lblCurrentPage.Text = "1";
            btnNext.Visible = false;
            btnLast.Visible = false;
            btnPrev.Visible = false;
            btnFirst.Visible = false;
        }
        //if page no = 1 working

        else
        {
            btnFirst.Visible = true;

            if (Int32.Parse(lblCurrentPage.Text) == 1 || currentPageNumber1 == 100000000 || currentPageNumber1 == 100000001 || currentPageNumber1 == 15)
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


            else if (Int32.Parse(lblCurrentPage.Text) == CalculateTotalPages(double.Parse(lblTotalPages.Text)))
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
        }
        //dss = Transact.RetrieveAll_General_Details();
        // Grid_Empty();

    }
    private int CalculateTotalPages(double totalRows)
    {
        int totalPages = (int)Math.Ceiling(totalRows / gvdetails.PageSize);

        return totalPages;
    }

    protected void ChangePage(object sender, CommandEventArgs e)
    {
        if (Name_Search == "")
        {
            int currentpagenumber2 = 0, h = 0, ii = 0;

            switch (e.CommandName)
            {
                case "Previous":
                    currentpagenumber2 = Int32.Parse(lblCurrentPage.Text) - 1;
                    lblCurrentPage.Text = Convert.ToString(currentpagenumber2);

                    currentpagenumber2 = Math.Abs((currentpagenumber2 * gvdetails.PageSize) - Int32.Parse(lblTotalPages.Text));


                    break;

                case "Next":

                    if (ViewState["pageno"] == null)
                    {
                        ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
                        lblCurrentPage.Text = Convert.ToString(Int32.Parse(lblCurrentPage.Text) + 1);
                        if (Int32.Parse(lblCurrentPage.Text) == ii)
                        {

                            lblCurrentPage.Text = Convert.ToString(Int32.Parse(lblCurrentPage.Text));
                            ii = Int32.Parse(lblTotalPages.Text) - ((Int32.Parse(lblCurrentPage.Text) - 1) * gvdetails.PageSize);
                            currentpagenumber2 = Math.Abs(ii);

                        }
                        else
                        {
                            currentpagenumber2 = Math.Abs((Int32.Parse(lblTotalPages.Text) - (gvdetails.PageSize * Int32.Parse(lblCurrentPage.Text))));

                        }
                    }

                    else
                    {
                        ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
                        if (Int32.Parse(lblCurrentPage.Text) == ii)
                            currentpagenumber2 = ii;
                        else
                        {
                            currentpagenumber2 = Int32.Parse(lblCurrentPage.Text) + 1;
                            lblCurrentPage.Text = Convert.ToString(currentpagenumber2);
                            currentpagenumber2 = Math.Abs((Int32.Parse(lblTotalPages.Text) - (gvdetails.PageSize * Int32.Parse(lblCurrentPage.Text))));

                        }

                    }


                    break;
                case "First":

                    if (ViewState["pageno"] == null)

                        currentpagenumber2 = 100000000;
                    else
                        currentpagenumber2 = 100000001;
                    break;
                case "Last":
                    int i = CalculateTotalPages(double.Parse(lblTotalPages.Text));
                    lblCurrentPage.Text = Convert.ToString(i);
                    currentpagenumber2 = Math.Abs(Int32.Parse(lblTotalPages.Text) - ((i - 1) * gvdetails.PageSize));

                    break;

            }

            gridbind(currentpagenumber2);
        }
        else
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

            grid_Bind_NameSearch(currentpagenumber2);
        }
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
        if (Name_Search == "")
        {
            ViewState["last_click"] = null;
            lblCurrentPage.Text = ddlSelectPageno.SelectedValue.ToString();
            int i = CalculateTotalPages(double.Parse(lblTotalPages.Text));
            if (ddlSelectPageno.SelectedValue != "")
            {
                string val = "";
                if (ddlSelectPageno.SelectedValue == "1")
                {

                    val = "100000000";
                    gridbind(Int32.Parse(val));


                }

                else if (Int32.Parse(ddlSelectPageno.SelectedValue) == i)
                {
                    lblCurrentPage.Text = ddlSelectPageno.SelectedValue.ToString();
                    gridbind(Math.Abs(Int32.Parse(lblTotalPages.Text) - ((Int32.Parse(ddlSelectPageno.SelectedValue) - 1) * gvdetails.PageSize)));

                }

                else
                {

                    gridbind(Math.Abs((Int32.Parse(ddlSelectPageno.SelectedValue.ToString()) * gvdetails.PageSize) - Int32.Parse(lblTotalPages.Text)));

                }

            }
        }
        else
            ddl_select_Namesearch();
    }

    public void ddl_select_Namesearch()
    {
        if (ddlSelectPageno.SelectedValue != "")
        {
            ViewState["selected_change"] = "1";

            grid_Bind_NameSearch(Int32.Parse(ddlSelectPageno.SelectedValue.ToString()));

        }
    }

    public void grid_Bind_NameSearch(int currentPageNumber1)
    {
        //Transact.JOBID = "0";
        Transact.JOBNO = txtJobNo.Text;
        Transact.IMPORTER_NAME = Name_Search;
        Transact.TRANSPORT_MODE = txtTransport_Mode.Text;
        Transact.CUSTOMS_HOUSE = txtCustomsHouse.Text;
        Transact.Ename = "select_con";

        //Transact.WORKING_PERIOD = Working_Period;
        Transact.WORKING_PERIOD = SELECT_BRANCH;
        Transact.startRowIndex = Convert.ToString(currentPageNumber1);
        Transact.maximumRows = Convert.ToString(gvdetails.PageSize);
        gvdetails.EmptyDataText = "No Record Found";

        gvdetails.DataSource = Transact.RetrieveAll_General_Details();

        gvdetails.DataBind();
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
        totalRows = (double)Transact.result;

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
        //dss = Transact.RetrieveAll_General_Details();
        // Grid_Empty();

    }
  
}