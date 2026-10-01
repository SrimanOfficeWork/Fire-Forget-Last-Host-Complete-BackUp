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

public partial class ERoyal_Admin_Master_AntiDumpting : ThemeClass
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 10;
    public int i, Total_Rows;
    public string AUTO_ID;
    adminmaster Admin_mas = new adminmaster();

    DataSet dtuser = new DataSet();

    string category;
    public string ANTI_DATE;

    SqlConnection con;
    public int rowIndex;
    SqlCommand cmd;
    Manipulation mo = new Manipulation();
    AdminManipulation am = new AdminManipulation();
    AppSession aps = new AppSession();
    public string CUSTOMHOUSE_ID ="";
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
            aps.checkSession();
            //currentuser = Session["currentuser"].ToString();
            //currentbranch = Session["currentbranch"].ToString();
            //currentcomp_name = Session["currentcomp_name"].ToString();
            //comp_ConnectionStr = Session["currentcomp_db"].ToString();
            //Working_Period = Session["WorkingPeriod"].ToString();
            //LoginDate = Session["LoginDate"].ToString();

            txtCHCodeSearch.Focus();
            DateTime dat = System.DateTime.Now;
            datestring = string.Format("{0:dd/MM/yyyy}", dat);


            //mainmastopusernametxt.InnerText = "Welcome Mr." + currentuser;
            Div_Pagination.Visible = false;
            div_pagination1.Visible = false;


            if (!IsPostBack)
            {

                Edit_CustomHouse_Details();
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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtCHCode.Text != "" && txtCHName.Text != "")
            {

                Admin_mas.CH_id = "0";
                Admin_mas.CH_Code = txtCHCode.Text;
 
                Admin_mas.Ename = "autoid";

                dtuser = Admin_mas.RetrieveAll_CustomHouse_master();
                string ii = Convert.ToString(Admin_mas.result);
                if (ii == "1")
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Custom House Code Already Exist')</script>", false);

                }
                else
                {

                    if (dtuser.Tables[0].Rows.Count > 0)
                    {
                        AUTO_ID = dtuser.Tables[0].Rows[0]["CUSTOMHOUSE_ID"].ToString();

                        if (AUTO_ID != "")
                        {
                            CustomHouse_master_insert();
                        }
                        else
                        {
                            AUTO_ID = "1";
                            CustomHouse_master_insert();

                        }

                    }
                }

            }
            else
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Enter All Mandatory Field')</script>", false);


            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

        clear();
    }

    public void CustomHouse_master_insert()
    {
        try
        {
            if (ddlCategory.SelectedItem.Text == "S")
            {
                category = ddlCategory.SelectedItem.Text;
            }
            if (ddlCategory.SelectedItem.Text == "A")
            {
                category = ddlCategory.SelectedItem.Text;
            }
            if (ddlCategory.SelectedItem.Text == "L")
            {
                category = ddlCategory.SelectedItem.Text;
            }


            i = am.tbmanipulate("INSERT INTO CUSTOMS_HOUSE(CUSTOMHOUSE_ID,CUSTOMHOUSE_CODE,CUSTOMHOUSE_NAME,CUSTOMHOUSE_CATEGORY,AREA) VALUES (" + AUTO_ID + ",'" + txtCHCode.Text.Trim() + "','" + txtCHName.Text.Trim() + "','" + category + "','" + txtCHArea.Text + "')");
            if (i > 0)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);

                int pageno = 1;
                gridbind(pageno);

            }
            else
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);

            }
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

            if (ddlCategory.SelectedItem.Text == "S")
            {
                 category = ddlCategory.SelectedItem.Text;
            }
            if (ddlCategory.SelectedItem.Text == "A")
            {
                category = ddlCategory.SelectedItem.Text;
            }
            if (ddlCategory.SelectedItem.Text == "L")
            {
                category = ddlCategory.SelectedItem.Text;
            }

            i = am.tbmanipulate("update CUSTOMS_HOUSE set CUSTOMHOUSE_CODE='" + txtCHCode.Text.Trim() + "',CUSTOMHOUSE_NAME='" + txtCHName.Text.Trim() + "',CUSTOMHOUSE_CATEGORY='" + category + "', AREA='" + txtCHArea.Text + "' where CUSTOMHOUSE_ID=" + ViewState["CUSTOMHOUSE_ID"] + " ");
            if (i > 0)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Updated Successfully')</script>", false);
                int pageno = 1;
                gridbind(pageno);

                btnNew.Focus();
            }
            else
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Updated')</script>", false);

            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

        clear();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {

            int i;

            Admin_mas.CH_id= ViewState["CUSTOMHOUSE_ID"].ToString();
            Admin_mas.CH_Code = "0";
            Admin_mas.CH_Name= "0";
            Admin_mas.Ename = "delete";
            int pageno = 1;
            Admin_mas.startRowIndex = Convert.ToString(pageno);
            Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
            gvdetails.DataSource = Admin_mas.RetrieveAll_CustomHouse_master();
            gvdetails.DataBind();

            Grid_Total(pageno, Admin_mas.Total_Rows);


            i = Admin_mas.result;
            if (i > 0)
            {

                mo.ResetFields(Page.Controls);

                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                txtCHCode.Focus();
                txtCHCode.Enabled = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Deleted')</script>", false);
            }
            else
            {

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


            txtCHCode.Focus();
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
            txtCHCode.Enabled = true;
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

            //int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
            //Add_Pageno(ii);

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
            Admin_mas.CH_id = "0";
            Admin_mas.CH_Code = txtCHCodeSearch.Text;

            Admin_mas.CH_Name = txtCHNameSearch.Text;
            //my corrections

            Admin_mas.CH_Area = txtCHAreaSearch.Text;

            Admin_mas.Ename = "select_con";


            Admin_mas.startRowIndex = Convert.ToString(currentPageNumber1);
            Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);

            gvdetails.EmptyDataText = "No Record Found";

            gvdetails.DataSource = Admin_mas.RetrieveAll_CustomHouse_master();


            gvdetails.DataBind();

            Grid_Total(currentPageNumber1, Admin_mas.Total_Rows);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       

    }


    public void clear()
    {
        try
        {
            txtCHCode.Text = "";
            txtCHName.Text = "";
            ddlCategory.SelectedIndex = -1;
            txtCHArea.Text = "";
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
            Connection.Error_Msg(ex.Message);
        }
       

    }


    public void Edit_CustomHouse_Details()
    {
        try
        {
            if (ViewState["CUSTOMHOUSE_ID"] != "" && ViewState["CUSTOMHOUSE_ID"] != null)
            {
                int i = 0;
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                CUSTOMHOUSE_ID = ViewState["CUSTOMHOUSE_ID"].ToString();


                Admin_mas.CH_id = CUSTOMHOUSE_ID;
                Admin_mas.CH_Code = "0";
                Admin_mas.CH_Name = "0";
                Admin_mas.Ename = "select_conwithcode";


                dtuser = Admin_mas.RetrieveAll_CustomHouse_master();
                if (dtuser.Tables[0].Rows.Count > 0)
                {
                    txtCHCode.Text = dtuser.Tables[0].Rows[0]["CUSTOMHOUSE_CODE"].ToString();
                    txtCHCode.Enabled = false;

                    txtCHName.Text = dtuser.Tables[0].Rows[0]["CUSTOMHOUSE_NAME"].ToString();
                    ddlCategory.SelectedItem.Text = dtuser.Tables[0].Rows[0]["CUSTOMHOUSE_CATEGORY"].ToString();
                    txtCHArea.Text = dtuser.Tables[0].Rows[0]["AREA"].ToString();
                }
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
                //e.Row.Attributes["onmouseout"] = "this.style.background='white'";
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
            ViewState["CUSTOMHOUSE_ID"] = Convert.ToString(this.gvdetails.SelectedDataKey.Value);

            Edit_CustomHouse_Details();
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

                div_pagination1.Visible = true;

            }
            else if (gvdetails.Rows.Count == 0)
            {
                Div_Pagination.Visible = false;
                div_pagination1.Visible = false;
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

            txtCHCode.Focus();
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
            txtCHCode.Enabled = true;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }
}