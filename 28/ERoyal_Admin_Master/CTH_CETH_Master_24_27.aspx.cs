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

public partial class ERoyal_Admin_Master_CTH_CETH_Master_24_27 : ThemeClass
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 10;
    public int i, Total_Rows;
    public string AUTO_ID;
    adminmaster Admin_mas = new adminmaster();

    DataSet dtuser = new DataSet();

    SqlConnection con;
    public int rowIndex;
    SqlCommand cmd;
    Manipulation mo = new Manipulation();
    AdminManipulation am = new AdminManipulation();
    AppSession aps = new AppSession();
    public string ID;
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
        try
        {
            Div_Pagination.Visible = false;
            txt_cth_codeSearch.Focus();
            if (!IsPostBack)
            {

                Edit_cth_ceth_24_27_details();
                int pageno = 1;

                DataTable dt = new DataTable();
                gvdetails.EmptyDataText = "";
                gvdetails.DataSource = dt;
                gvdetails.DataBind();

            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }


    }
    public void insert_update(string a1, string a2)
    {
        try
        {
            Admin_mas.Eceth_id = a1;
            Admin_mas.Ecth_code = txt_cth_code.Text;
            Admin_mas.Eceth_code = txt_ceth_code.Text;
            Admin_mas.Eceth_remarks = txtRemarks.Text;

            Admin_mas.Ename = a2;
            int pageno = 1;
            Admin_mas.startRowIndex = Convert.ToString(pageno);
            Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
            gvdetails.DataSource = Admin_mas.cth_ceth_master_24_27_insert_update();
            gvdetails.DataBind();
            i = Admin_mas.result;

            Grid_Total(pageno, Admin_mas.Total_Rows);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        
        string TEMP = txt_cth_code.Text;
        byte TEMPLEN = Convert.ToByte(TEMP.Length);
        if (TEMPLEN != 8)
        {         
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('CTH Code Should be 8 Integer')</script>", false);
        }

        else
        {
            try
            {
                if (txt_cth_code.Text != "" && txt_ceth_code.Text != "")
                {
                    string a1 = "";
                    string a2 = "S";                    
                    insert_update(a1, a2);
                    if (i > 0)
                    {
                        if (i == 1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('CTH Code Already Exist')</script>", false);
                        }
                        else
                        {
                            if (i == 2)
                            {
                                //lblMsg.Text = "Saved Successfully";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);
                                txt_cth_code.Focus();                                
                            }
                            else
                            {
                                //lblMsg.Text = "Record Not Saved";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);
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
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string a1 = Convert.ToString(ViewState["ID"]);
            string a2 = "U";

            insert_update(a1, a2);
            if (i > 0)
            {
                //lblMsg.Text = "Saved Successfully";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);
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
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {

            int i;

            Admin_mas.Eceth_id = ViewState["ID"].ToString();
            Admin_mas.Eceth_code = "0";
            Admin_mas.Ecth_code = "0";

            Admin_mas.Ename = "delete";
            int pageno = 1;
            Admin_mas.startRowIndex = Convert.ToString(pageno);
            Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
            gvdetails.DataSource = Admin_mas.RetrieveAll_cth_ceth_master_24_27();
            gvdetails.DataBind();

            Grid_Total(pageno, Admin_mas.Total_Rows);

            i = Admin_mas.result;
            if (i > 0)
            {
                mo.ResetFields(Page.Controls);
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
              
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Deleted')</script>", false);
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
    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            mo.ResetFields(Page.Controls);
            txt_cth_code.Focus();

            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }
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
            Admin_mas.Eceth_id = "0";
            Admin_mas.Eceth_code = txt_ceth_codeSearch.Text;
            Admin_mas.Ecth_code = txt_cth_codeSearch.Text;
            Admin_mas.Ename = "select_con";
            Admin_mas.startRowIndex = Convert.ToString(currentPageNumber1);
            Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);

            gvdetails.EmptyDataText = "No Record Found";
            gvdetails.DataSource = Admin_mas.RetrieveAll_cth_ceth_master_24_27();
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
            gridbind(currentpagenumber2);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
    }
    public void Edit_cth_ceth_24_27_details()
    {
        try
        {
            if (ViewState["ID"] != "" && ViewState["ID"] != null)
            {
                int i = 0;
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                string Query = "CATEGORY_MASTER_SP_SELECT_CONWITHCODE";
                i = am.Category_Master_All_BIND(Query, ID);
                txt_cth_code.Text = am.CATEGORY_NO;
                txt_ceth_code.Text = am.CATEGORY_NAME;
                txtRemarks.Text = am.CATEGORY_REMARKS;
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
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
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
            ViewState["ID"] = Convert.ToString(this.gvdetails.SelectedDataKey.Value);

            if (ViewState["ID"] != "" && ViewState["ID"] != null)
            {
                txt_cth_code.Text = gvdetails.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");

                txt_ceth_code.Text = gvdetails.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
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
                }

            }
            else if (Int32.Parse(lblCurrentPage.Text) == ii)
            {
                btnNext.Visible = false;
                btnPrev.Visible = true;
            }
            else
            {
                btnPrev.Visible = true;
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
            txt_cth_code.Focus();
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }
}