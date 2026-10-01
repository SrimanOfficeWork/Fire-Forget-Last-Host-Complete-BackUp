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

public partial class ERoyal_Admin_Master_Location_Master : ThemeClass
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 10;
    //public int pageno = 1;
    public int i, Total_Rows;

    public string AUTO_ID;
    adminmaster Admin_mas = new adminmaster();
    DataSet dtuser = new DataSet();
    SqlConnection con;
    SqlCommand cmd;
    Manipulation mo = new Manipulation();
    AdminManipulation am = new AdminManipulation();
    AppSession aps = new AppSession();
    public string LOCATION_ID = "";
    ErrorLogs er = new ErrorLogs();
    DropDownList ddl = new DropDownList();
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);

    string SP_QUERY;
    string datestring;

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        //currentuser = Session["currentuser"].ToString();
        //currentbranch = Session["currentbranch"].ToString();
        //currentcomp_name = Session["currentcomp_name"].ToString();
        //comp_ConnectionStr = Session["currentcomp_db"].ToString();
        //Working_Period = Session["WorkingPeriod"].ToString();
        //LoginDate = Session["LoginDate"].ToString();

        txtLocationCodeSearch.Focus();

        //mainmastopusernametxt.InnerText = "Welcome Mr." + currentuser;
        Div_Pagination.Visible = false;

        if (!IsPostBack)
        {

            Edit_ExchangeDetails();
            DataTable dt = new DataTable();
            gvdetails.EmptyDataText = "";
            gvdetails.DataSource = dt;
            gvdetails.DataBind();
            // int pageno = 1;

            // gridbind(pageno);
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //Location code must be 6 character start
        string TEMP = txtLocationCode.Text;
        byte TEMPLEN = Convert.ToByte(TEMP.Length);
        if (TEMPLEN != 6)
        {
            // lblMsg.Text = "Location Code must be 6 character";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Location Code Should be 6 character')</script>", false);


        } ////Location code must be 6 character end

        else
        {
            try
            {


                if (txtLocationCode.Text != "" && txtLocationName.Text != "" && txtLocationState.Text != "")
                {

                    Admin_mas.Elocation_id = "0";
                    Admin_mas.Elocation_code = txtLocationCode.Text;
                    Admin_mas.Elocation_name = "0";



                    Admin_mas.Ename = "autoid";


                    dtuser = Admin_mas.RetrieveAll_Location_master();
                    string ii = Convert.ToString(Admin_mas.result);
                    if (ii == "1")
                    {
                        // lblMsg.Text = "Not Save, Location Code Already Exist";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Location Code Already Exist')</script>", false);
                    }
                    else
                    {

                        if (dtuser.Tables[0].Rows.Count > 0)
                        {
                            AUTO_ID = dtuser.Tables[0].Rows[0]["LOCATION_ID"].ToString();

                            if (AUTO_ID != "")
                            {
                                Location_master_insert();
                            }
                            else
                            {
                                AUTO_ID = "1";
                                Location_master_insert();

                            }

                        }
                    }

                }
                else
                {
                    //lblMsg.Text = "Enter All Mandatory Field";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Enter All Mandatory Field')</script>", false);


                }
            }
            catch (Exception ex)
            {
                er.makeLog(ex.Message);
            }
        }
    }

    public void Location_master_insert()
    {
        i = am.tbmanipulate("INSERT INTO LOCATION_MASTER VALUES (" + AUTO_ID + ",'" + txtLocationCode.Text + "','" + txtLocationName.Text + "','" + txtLocationState.Text + "','" + txtRemarks.Text + "')");
        if (i > 0)
        {
            //lblMsg.Text = " Saved Successfully";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);

            int pageno = 1;
            gridbind(pageno);
            //mo.ResetFields(Page.Controls);

            //Clear();
            // btnNew.Focus();

        }
        else
        {
            //lblMsg.Text = " Record Not Saved";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);



        }
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        mo.ResetFields(Page.Controls);
        //lblMsg.Text = "";
        txtLocationCode.Enabled = true;
        mo.ResetFields(Page.Controls);

        txtLocationCode.Focus();
        btnSave.Visible = true;
        btnUpdate.Visible = false;
        btnDelete.Visible = false;

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {

            int i;
            Admin_mas.Elocation_id = ViewState["LOCATION_ID"].ToString();
            Admin_mas.Elocation_code = "0";
            Admin_mas.Elocation_name = "0";
            Admin_mas.Ename = "delete";

            int pageno = 1;
            Admin_mas.startRowIndex = Convert.ToString(pageno);
            Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
            gvdetails.DataSource = Admin_mas.RetrieveAll_Location_master();
            gvdetails.DataBind();


            Grid_Total(pageno, Admin_mas.Total_Rows);


            i = Admin_mas.result;

            if (i > 0)
            {
                //lblMsg.Text = " Record Deleted";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Deleted')</script>", false);


                mo.ResetFields(Page.Controls);
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                txtLocationCode.Focus();
                txtLocationCode.Enabled = true;



            }
            else
            {
                //lblMsg.Text = " Record Not Deleted";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Deleted')</script>", false);


            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {

            int i;

            i = am.tbmanipulate("update LOCATION_MASTER set LOCATION_CODE='" + txtLocationCode.Text + "' ,LOCATION_NAME='" + txtLocationName.Text + "',LOCATION_STATE='" + txtLocationState.Text + "',LOCATION_REMARKS='" + txtRemarks.Text + "' where LOCATION_ID=" + ViewState["LOCATION_ID"] + " ");
            if (i > 0)
            {
                //lblMsg.Text = "Saved Successfully";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);
                int pageno = 1;
                gridbind(pageno);
                //Clear();
                btnNew.Focus();

            }
            else
            {
                //lblMsg.Text = "Record Not Saved";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);


            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }


    public void gridbind(int currentPageNumber1)
    {
        Admin_mas.Elocation_id = "0";
        Admin_mas.Elocation_code = txtLocationCodeSearch.Text;
        Admin_mas.Elocation_name = txtLocationNameSearch.Text;
        Admin_mas.Ename = "select_con";



        Admin_mas.startRowIndex = Convert.ToString(currentPageNumber1);
        Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
        //ds = erm.RetrieveAll_Adcode_MASTER();
        gvdetails.EmptyDataText = "No Record Found";

        gvdetails.DataSource = Admin_mas.RetrieveAll_Location_master();


        gvdetails.DataBind();

        Grid_Total(currentPageNumber1, Admin_mas.Total_Rows);


    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int pageno = 1;
        gridbind(pageno);
        //int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
        //dd_Pageno(ii);

    }


    public void Edit_ExchangeDetails()
    {
        if (ViewState["LOCATION_ID"] != "" && ViewState["LOCATION_ID"] != null)
        {
            int i = 0;
            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            LOCATION_ID = ViewState["LOCATION_ID"].ToString();


            // string Query = "select * from SUP_MASTER where SUP_ID='" + SUP_ID + "'";

            string Query = "LOCATION_MASTER_SP_SELECT_CONWITHCODE";

            //gvdetails.DataSource = mo.RetrieveAll_LIKE(Query, SUP_ID);

            i = am.Location_Master_All_BIND(Query, LOCATION_ID);

            txtLocationCode.Text = am.LOCATION_CODE;

            txtLocationName.Text = am.LOCATION_NAME;
            txtLocationState.Text = am.LOCATION_STATE;

            txtRemarks.Text = am.LOCATION_REMARKS;

        }
        else
        {
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;

        }
    }



    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            //e.Row.Attributes["onmouseout"] = "this.style.background='white'";
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gvdetails, "Select$" + e.Row.RowIndex.ToString()));

        }
    }

    protected void gvdetails_SelectedIndexChanged(object sender, EventArgs e)
    {

        // ViewState["CATEGORY_ID"] = this.gvdetails.DataKeys[rowIndex]["CATEGORY_ID"].ToString();
        ViewState["LOCATION_ID"] = Convert.ToString(this.gvdetails.SelectedDataKey.Value);

        if (ViewState["LOCATION_ID"] != "" && ViewState["LOCATION_ID"] != null)
        {
            txtLocationCode.Text = gvdetails.SelectedRow.Cells[1].Text.Replace("&nbsp;","");
            txtLocationCode.Enabled = false;

            txtLocationName.Text = gvdetails.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            txtLocationState.Text = gvdetails.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");

            txtRemarks.Text = gvdetails.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;

        }
        else
        {
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;

        }
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
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        mo.ResetFields(Page.Controls);
        //lblMsg.Text = "";
        txtLocationCode.Enabled = true;
        mo.ResetFields(Page.Controls);

        txtLocationCode.Focus();
        btnSave.Visible = true;
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
    }

}