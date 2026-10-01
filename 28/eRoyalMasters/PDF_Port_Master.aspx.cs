using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
//using System.Text;
//using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Web;
//using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Web.UI.HtmlControls;
//using System.Data.SqlClient;

public partial class PDF_Port_Master : ThemeClass
{   
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 10;
    public int i, Total_Rows;

    public string AUTO_ID;
    Manipulation mo = new Manipulation();
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    eroyalmaster erm = new eroyalmaster();
    DataSet ds = new DataSet();
    //IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
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
            Div_Pagination.Visible = false;
            if (!IsPostBack)
            {
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                txtPort_CodeSearch.Focus();
                DataTable dt = new DataTable();
                gvdetails.EmptyDataText = "";
                gvdetails.DataSource = dt;
                gvdetails.DataBind();

            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
        
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtPDFPort_Name.Text != "" && txtPort_Name.Text != "" && txtPort_Code.Text != "" && txtCountryCode.Text != "")
            {
                if (txtPort_Code.Text.Length <= 5)
                {
                    try
                    {
                        string a1 = "";
                        string a2 = "S";
                        string a3 = "";
                        i = insert_update(a1, a2, a3);
                        HiddenField1.Value = Convert.ToString(erm.UPDATE_ID);

                        if (i == 1)
                        {
                            btnUpdate.CssClass = "save";
                            btnUpdate.Visible = true;
                            btnSave.Visible = false;
                            ViewState["UPDATED_ID"] = null;

                            btnSave.Focus();
                            Alert_msg("Saved Successfully", "btnSave");
                            gridbind(1);

                        }
                        else if (i == 2)
                        {
                            Alert_msg("PORT Already exixts!", "btnSave");
                        }
                        else
                        {
                            Alert_msg("PORT Not Saved", "btnNew");
                        }
                    }
                    catch (Exception ex)
                    {
                        er.makeLog(ex.Message);
                    }
                }
                else
                {
                    Alert_msg("Invalid - Port Code");
                }
            }
            else
            {
                Alert_msg("Enter All Mandatory Field");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
        
    }

    public int insert_update(string a1, string a2, string a3)
    {
       
        int i = 0;
        try
        {
            if (HiddenField1.Value != "")
                erm.ID = HiddenField1.Value;
            else
                erm.ID = "";

            erm.PDF_PORTNAME = txtPDFPort_Name.Text;
            erm.PORT_NAME = txtPort_Name.Text;
            erm.PORT_CODE = txtPort_Code.Text;
            erm.COUNTRY_CODE = txtCountryCode.Text;
            erm.Ename = a2;
            erm.USER_ID = Connection.Current_User();
            erm.BRANCH_CODE = Connection.Current_Branch();
            erm.startRowIndex = Convert.ToString(1);
            erm.maximumRows = Convert.ToString(gvdetails.PageSize);

            ds = erm.PDF_PORT_MASTER_Insert_update_Search();

            i = erm.result;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
        return i;
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            mo.ResetFields(Page.Controls);
            txtPDFPort_Name.Focus();
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
        
       
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtPDFPort_Name.Text != "" && txtPort_Name.Text != "" && txtPort_Code.Text != "" && txtCountryCode.Text != "")
            {
                if (txtPort_Code.Text.Length >= 5)
                {
                    try
                    {
                        string a1 = HiddenField1.Value;
                        string a2 = "U";
                        string a3 = "";
                        i = insert_update(a1, a2, a3);
                        HiddenField1.Value = Convert.ToString(erm.UPDATE_ID);

                        if (i == 1)
                        {
                            if (ViewState["UPDATED_ID"] != null)
                            {
                                Alert_msg("Updated Successfully", "btnUpdate");
                                gridbind(1);
                            }
                            else
                            {
                                Alert_msg("Saved Successfully", "btnUpdate");
                            }
                        }
                        else if (i == 2)
                        {
                            Alert_msg("PORT Already exixts!", "btnSave");
                        }
                        else
                        {
                            Alert_msg("PORT Not Saved", "btnNew");
                        }
                    }
                    catch (Exception ex)
                    {
                        er.makeLog(ex.Message);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
                    }
                }
                else
                {
                    Alert_msg("Invalid - Port Code");
                }
            }
            else
            {
                Alert_msg("Enter All Mandatory Field");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            erm.ID = HiddenField1.Value;
            erm.PDF_PORTNAME = txtPDFPort_Name.Text;
            erm.PORT_NAME = txtPort_Name.Text;
            erm.PORT_CODE = txtPort_Code.Text;
            erm.COUNTRY_CODE = txtCountryCode.Text;
            erm.Ename = "delete";
            erm.startRowIndex = Convert.ToString(1);
            erm.maximumRows = Convert.ToString(gvdetails.PageSize);
            gvdetails.EmptyDataText = "No Record Found";

            gvdetails.DataSource = erm.PDF_PORT_MASTER_Insert_update_Search();
            gvdetails.DataBind();

            i = erm.result;

            if (i > 0)
            {
                Alert_msg("Record Deleted");

                mo.ResetFields(Page.Controls);
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
            }
            else
            {
                Alert_msg("Record not Deleted");
            }

            Grid_Total(1, erm.result);         
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
    }
    
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int pageno = 1;
        gridbind(pageno);
    }

    public void gridbind(int currentPageNumber1)
    {
        try
        {
            erm.PDF_PORTNAME = txtPDFPort_Name.Text;
            erm.PORT_NAME = txtPort_NameSearch.Text;
            erm.PORT_CODE = txtPort_CodeSearch.Text;
            erm.COUNTRY_CODE = txtCountryCode.Text;
            erm.Ename = "select_con";
            erm.startRowIndex = Convert.ToString(currentPageNumber1);
            erm.maximumRows = Convert.ToString(gvdetails.PageSize);
            gvdetails.EmptyDataText = "No Record Found";

            gvdetails.DataSource = erm.PDF_PORT_MASTER_Insert_update_Search();
            gvdetails.DataBind();

            Grid_Total(currentPageNumber1, erm.result);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
    }

    private int CalculateTotalPages(double totalRows)
    {
        int totalPages = (int)Math.Ceiling(totalRows / gvdetails.PageSize);
        return totalPages;
    }

    protected void ChangePage(object sender, CommandEventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
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
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
        
    }

    protected void gvdetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ViewState["PORT_ID"] = Convert.ToString(this.gvdetails.SelectedDataKey.Value);

            if (ViewState["PORT_ID"] != "" && ViewState["PORT_ID"] != null)
            {
                txtPDFPort_Name.Text = gvdetails.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
                txtPort_Name.Text = gvdetails.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
                txtPort_Code.Text = gvdetails.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
                txtCountryCode.Text = gvdetails.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");


                ViewState["UPDATED_ID"] = HiddenField1.Value;
                HiddenField1.Value = ViewState["PORT_ID"].ToString();

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
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
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
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
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
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
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
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
        
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            mo.ResetFields(Page.Controls);
            //lblMsg.Text = "";
            txtPDFPort_Name.Focus();
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'USER WISE-PORT MASTER', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'USER WISE-PORT MASTER', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
}
