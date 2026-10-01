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

public partial class ERoyal_Admin_Master_Country_Master : ThemeClass
{    public int currentPageNumber;
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
    public string COUNTRY_ID = "";
    string SP_QUERY;
    //string datestring;
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();
            // mainmastopusernametxt.InnerText = "Welcome Mr." + currentuser;
            Div_Pagination.Visible = false;
            if (!IsPostBack)
            {

                Edit_ExchangeDetails();
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                txtCounrty_CodeSearch.Focus();
                DataTable dt = new DataTable();
                gvdetails.EmptyDataText = "";
                gvdetails.DataSource = dt;
                gvdetails.DataBind();
                //int pageno = 1;
                //gridbind(pageno);

            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }    
       
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            //Country code must be 2 character start
            string TEMP = txtCountry_Code.Text;
            byte TEMPLEN = Convert.ToByte(TEMP.Length);
            if (TEMPLEN != 2)
            {
                //lblMsg.Text = "Country Code must be 2 character";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Country Code Should be 2 character')</script>", false);

            } ////Country code must be 2 character end

            else
            {
                try
                {


                    if (txtCountry_Code.Text != "" && txtCountry_Name.Text != "")
                    {


                        Admin_mas.Ecountry_id = "0";
                        Admin_mas.Ecountry_code = txtCountry_Code.Text;
                        Admin_mas.Ecountry_name = "0";



                        Admin_mas.Ename = "autoid";


                        dtuser = Admin_mas.RetrieveAll_Country_master();
                        string ii = Convert.ToString(Admin_mas.result);
                        if (ii == "1")
                        {
                            //lblMsg.Text = "Not Save, Country Code Already Exist";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Country Code Already Exist')</script>", false);

                        }
                        else
                        {

                            if (dtuser.Tables[0].Rows.Count > 0)
                            {
                                AUTO_ID = dtuser.Tables[0].Rows[0]["COUNTRY_ID"].ToString();

                                if (AUTO_ID != "")
                                {
                                    country_master_insert();
                                }
                                else
                                {
                                    AUTO_ID = "1";
                                    country_master_insert();

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
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }    

    }

    public void country_master_insert()
    {
        try
        {
            i = am.tbmanipulate("INSERT INTO COUNTRY_MASTER VALUES (" + AUTO_ID + ",'" + txtCountry_Code.Text + "','" + txtCountry_Name.Text + "','" + txtRemarks.Text + "')");
            if (i > 0)
            {
                //lblMsg.Text = " Successfully Saved";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);

                //mo.ResetFields(Page.Controls);
                int pageno = 1;
                gridbind(pageno);
                txtCountry_Code.Focus();
                //btnNew.Focus();
            }
            else
            {
                //lblMsg.Text = " Record Not Saved";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);

            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }    
       
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            mo.ResetFields(Page.Controls);
            //lblMsg.Text = "";
            txtCountry_Code.Focus();
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
            txtCountry_Code.Enabled = true;

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {

            int i;
            i = am.tbmanipulate("update Country_MASTER set COUNTRY_CODE='" + txtCountry_Code.Text + "', COUNTRY_NAME='" + txtCountry_Name.Text + "',COUNTRY_REMARKS='" + txtRemarks.Text + "' where COUNTRY_ID=" + ViewState["COUNTRY_ID"] + " ");
            if (i > 0)
            {
                //lblMsg.Text = "Saved Successfully";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);

                int pageno = 1;
                gridbind(pageno);
                //mo.ResetFields(Page.Controls);
                //btnNew.Focus();
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
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            int i;
            Admin_mas.Ecountry_id = ViewState["COUNTRY_ID"].ToString();
            Admin_mas.Ecountry_code = "0";
            Admin_mas.Ecountry_name = "0";
            Admin_mas.Ename = "delete";


            int pageno = 1;
            Admin_mas.startRowIndex = Convert.ToString(pageno);
            Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
            gvdetails.DataSource = Admin_mas.RetrieveAll_Country_master();
            gvdetails.DataBind();

            Grid_Total(pageno, Admin_mas.Total_Rows);

            i = Admin_mas.result;
            if (i > 0)
            {
                //lblMsg.Text = " Record Deleted";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Deleted')</script>", false);

                txtCountry_Code.Enabled = true;

                mo.ResetFields(Page.Controls);
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                txtCountry_Code.Focus();
                // btnNew.Focus();                
            }
            else
            {
                //lblMsg.Text = " Record Not Deleted";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Deleted')</script>", false);

                btnNew.Focus();
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }
    //public void gridbind()
    //{
    //    Admin_mas.Ecountry_id = "0";
    //    Admin_mas.Ecountry_code = txtCounrty_CodeSearch.Text;
    //    Admin_mas.Ecountry_name = txtCountry_NameSearch.Text;
    //    Admin_mas.Ename = "select_con";

    //    gvdetails.DataSource = Admin_mas.RetrieveAll_Country_master();
    //    gvdetails.DataBind();
    //}
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            int pageno = 1;
            gridbind(pageno);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }

    public void gridbind(int currentPageNumber1)
    {
        try
        {
            Admin_mas.Ecountry_id = "0";
            Admin_mas.Ecountry_code = txtCounrty_CodeSearch.Text;
            Admin_mas.Ecountry_name = txtCountry_NameSearch.Text;
            Admin_mas.Ename = "select_con";



            Admin_mas.startRowIndex = Convert.ToString(currentPageNumber1);
            Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
            //ds = erm.RetrieveAll_Adcode_MASTER();
            gvdetails.EmptyDataText = "No Record Found";

            gvdetails.DataSource = Admin_mas.RetrieveAll_Country_master();


            gvdetails.DataBind();

            Grid_Total(currentPageNumber1, Admin_mas.Total_Rows);


        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }

    private int CalculateTotalPages(double totalRows)
    {
        int totalPages = 0;
        try
        {
             totalPages = (int)Math.Ceiling(totalRows / gvdetails.PageSize);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
      

        return totalPages;
    }

    protected void ChangePage(object sender, CommandEventArgs e)
    {
        int currentpagenumber2 = 0;
        try
        {
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

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
        gridbind(currentpagenumber2);
        //BindData(currentpagenumber2);
        //General_GridBind(currentpagenumber2);
    }

    public void Edit_ExchangeDetails()
    {
        try
        {
            if (ViewState["COUNTRY_ID"] != "" && ViewState["COUNTRY_ID"] != null)
            {
                int i = 0;
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                COUNTRY_ID = ViewState["COUNTRY_ID"].ToString();
                // string Query = "select * from SUP_MASTER where SUP_ID='" + SUP_ID + "'";
                string Query = "COUNTRY_MASTER_SP_SELECT_CONWITHCODE";
                //gvdetails.DataSource = mo.RetrieveAll_LIKE(Query, SUP_ID);
                i = am.COUNTRY_All_BIND(Query, COUNTRY_ID);
                txtCountry_Code.Text = am.COUNTRY_CODE;
                txtCountry_Name.Text = am.COUNTRY_NAME;
                txtCountry_Name.Text = am.COUNTRY_NAME;
                txtRemarks.Text = am.COUNTRY_REMARKS;
            }
            else
            {
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                // e.Row.Attributes["onmouseout"] = "this.style.background='white'";
                e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gvdetails, "Select$" + e.Row.RowIndex.ToString()));

            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }

    protected void gvdetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            // ViewState["CATEGORY_ID"] = this.gvdetails.DataKeys[rowIndex]["CATEGORY_ID"].ToString();
            ViewState["COUNTRY_ID"] = Convert.ToString(this.gvdetails.SelectedDataKey.Value);

            if (ViewState["COUNTRY_ID"] != "" && ViewState["COUNTRY_ID"] != null)
            {
                txtCountry_Code.Text = gvdetails.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
                txtCountry_Code.Enabled = false;

                txtCountry_Name.Text = gvdetails.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
                txtRemarks.Text = gvdetails.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
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
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

       
    }


    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
      
    }


    public void Add_Pageno(int p)
    {
        try
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
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }
    protected void ddlSelectPageno_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlSelectPageno.SelectedValue != "")
            {
                ViewState["selected_change"] = "1";
                gridbind(Int32.Parse(ddlSelectPageno.SelectedValue.ToString()));

            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }
    public void Grid_Total(int currentPageNumber1, double totalRows)
    {
        try
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
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            mo.ResetFields(Page.Controls);
            //lblMsg.Text = "";
            txtCountry_Code.Focus();
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
            txtCountry_Code.Enabled = true;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }
}
