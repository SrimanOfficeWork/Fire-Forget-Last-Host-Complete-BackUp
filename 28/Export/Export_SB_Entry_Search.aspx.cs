using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Export_General_Search : ThemeClass
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 0;
    public int pageno = 0;
    DataTable dt = new DataTable();
    DataSet dtuser = new DataSet();
    DataSet dss = new DataSet();
    Export_General_New Exp = new Export_General_New();

   
  
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
            Name_Search = txtExporterName.Text;

        }
        //set if textbox !=null after textbox clear
        if (txtJobNo.Text != "" || txtExporterName.Text != "" || txtTransport_Mode.Text != "" || txtCustomsHouse.Text != "")
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

    private void BindData(int currentPageNumber1)
    {

        //string connectionString = "Server=localhost;Database=Northwind;Trusted_Connection=true";
        SqlConnection myConnection = new SqlConnection(comp_ConnectionStr);
        SqlCommand myCommand = new SqlCommand("usp_GetProductsnew", myConnection);
        myCommand.CommandType = CommandType.StoredProcedure;

        myCommand.Parameters.AddWithValue("@startRowIndex", currentPageNumber1);
        myCommand.Parameters.AddWithValue("@maximumRows", gvdetails.PageSize);
        myCommand.Parameters.Add("@totalRows", SqlDbType.Int, 4);
        myCommand.Parameters["@totalRows"].Direction = ParameterDirection.Output;

        SqlDataAdapter ad = new SqlDataAdapter(myCommand);

        DataSet ds = new DataSet();
        ad.Fill(ds);

        gvdetails.DataSource = ds;
        gvdetails.DataBind();

        // get the total rows
        double totalRows = (int)myCommand.Parameters["@totalRows"].Value;

        lblTotalPages.Text = CalculateTotalPages(totalRows).ToString();

        lblCurrentPage.Text = currentPageNumber1.ToString();
        if (currentPageNumber1 == 1)
        {
            btnPrev.Enabled = false;

            if (Int32.Parse(lblTotalPages.Text) > 0)
            {
                btnNext.Enabled = true;
            }
            else
                btnNext.Enabled = false;

        }
        else if (currentPageNumber1 == Int32.Parse(lblTotalPages.Text))
        {
            btnNext.Enabled = false;

        }


        else
        {
            btnPrev.Enabled = true;

            if (currentPageNumber == Int32.Parse(lblTotalPages.Text))
                btnNext.Enabled = false;
            else btnNext.Enabled = true;
        }


    }

    private void General_GridBind(int currentPageNumber1)
    {
        Exp.startRowIndex = Convert.ToString(currentPageNumber1);
        Exp.maximumRows = Convert.ToString(gvdetails.PageSize);
        gvdetails.EmptyDataText = "No Record Found";

        gvdetails.DataSource = Exp.RetrieveAll_General_Details();

        gvdetails.DataBind();

        // get the total rows
        totalRows = (double)Exp.result;

        //lblTotalPages.Text = CalculateTotalPages(totalRows).ToString();
        lblTotalPages.Text = Convert.ToString(totalRows);

        lblCurrentPage.Text = Convert.ToString(currentPageNumber1);
        if (currentPageNumber1 == 1)
        {
            btnPrev.Enabled = false;

            if (Int32.Parse(lblTotalPages.Text) > 0)
            {
                btnNext.Enabled = true;
            }
            else
                btnNext.Enabled = false;

        }
        else if (currentPageNumber1 == Int32.Parse(lblTotalPages.Text))
        {
            btnNext.Enabled = false;

        }

        else
        {
            btnPrev.Enabled = true;
            btnLast.Enabled = true;

            if (currentPageNumber == Int32.Parse(lblTotalPages.Text))
                btnNext.Enabled = false;
            else btnNext.Enabled = true;
        }
    }

    
    public void Grid_Empty()
    {
        if (dss.Tables.Count > 0)
        {
            if (dss.Tables[0].Rows.Count > 0)
            {
                gvdetails.DataSource = dss;

                gvdetails.DataBind();
            }
            else
            {
                gvdetails.DataSource = dt;
                gvdetails.DataBind();

            }

        }
        else
        {

            gvdetails.DataSource = dt;
            gvdetails.DataBind();

        }
    }


    public void gridbind(int currentPageNumber1)
    {
        int ttl = 0;
        //Transact.JOBID = "0";
        Exp.JOBNO = txtJobNo.Text;
        Exp.EXPORTER_NAME = txtExporterName.Text;
        Exp.TRANSPORT_MODE = txtTransport_Mode.Text;
        Exp.CUSTOMS_HOUSE = txtCustomsHouse.Text;
        Exp.Ename = "select_con";
        Exp.WORKING_PERIOD = SELECT_BRANCH;
        if (currentPageNumber1 == 100000000 || currentPageNumber1 == 100000001)
        {
            Exp.startRowIndex = Convert.ToString(currentPageNumber1);
            Exp.maximumRows = Convert.ToString(gvdetails.PageSize);
            lblCurrentPage.Text = "1";
        }
        else
        {
            ttl=CalculateTotalPages(double.Parse(lblTotalPages.Text));
            if (Int32.Parse(lblCurrentPage.Text) == ttl)
            {
                Exp.startRowIndex = "1";
                Exp.maximumRows = Convert.ToString(currentPageNumber1);
            }
            else
            {
                Exp.startRowIndex = Convert.ToString(currentPageNumber1+1);
                Exp.maximumRows = Convert.ToString(gvdetails.PageSize);
            }
        }
        gvdetails.EmptyDataText = "No Record Found";
        DataView dataView = new DataView(Exp.RetrieveAll_General_Details_DataTable());
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
        if (gvdetails.Rows.Count > 0)
        {
            Div_Pagination.Visible = true;
        }
        else 
        {
            Div_Pagination.Visible = false;
        }
        totalRows = (double)Exp.result;
        lblTotalPages.Text = Convert.ToString(totalRows);
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
        txtExporterName.Text = "";
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
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string values = this.gvdetails.DataKeys[e.Row.RowIndex]["JOBID"].ToString();


            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";

            e.Row.Attributes.Add("onclick", "Export_SB_Entry_Update('" + values + "')");
          
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
        Exp.JOBNO = txtJobNo.Text;
        Exp.EXPORTER_NAME = Name_Search;
        Exp.TRANSPORT_MODE = txtTransport_Mode.Text;
        Exp.CUSTOMS_HOUSE = txtCustomsHouse.Text;
        Exp.Ename = "select_con";
        Exp.WORKING_PERIOD = SELECT_BRANCH;
        Exp.startRowIndex = Convert.ToString(currentPageNumber1);
        Exp.maximumRows = Convert.ToString(gvdetails.PageSize);
        gvdetails.EmptyDataText = "No Record Found";

        gvdetails.DataSource = Exp.RetrieveAll_General_Details_DataTable();

        gvdetails.DataBind();
        if (gvdetails.Rows.Count > 0)
        {
            Div_Pagination.Visible = true;

        }
        else if (gvdetails.Rows.Count == 0)
        {
            Div_Pagination.Visible = false;

        }
        // get the total rows
        totalRows = (double)Exp.result;

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