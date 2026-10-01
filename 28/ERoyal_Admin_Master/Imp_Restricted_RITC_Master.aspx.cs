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

public partial class Imp_Restricted_RITC_Master : ThemeClass
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 10;
    public int i, Total_Rows;
    public string AUTO_ID;
    adminmaster Admin_mas = new adminmaster();

    DataSet dtuser = new DataSet();

    SqlConnection con;
    SqlCommand cmd;
    Manipulation mo = new Manipulation();
    AdminManipulation am = new AdminManipulation();
    AppSession aps = new AppSession();
    public string SW_ID= "";
    ErrorLogs er = new ErrorLogs();
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);

    string datestring;


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();

            txtFromCTH.Focus();
            DateTime dat = System.DateTime.Now;
            datestring = string.Format("{0:dd/MM/yyyy}", dat);

            Div_Pagination.Visible = false;
            //div_pagination1.Visible = false;


            if (!IsPostBack)
            {
                ddl_Status_List();
                Edit_Anti_Notn_Details();
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

    public void ddl_Status_List()
    {
        try
        {
            ddl_Status.Items.Add("");
            ddl_Status.Items.Add("REMOVED");
            ddl_Status.Items.Add("RESTRICTED");
            ddl_Status.Items.Add("PROHIBITED");
            ddl_Status.Items.Add("STATE TRADING ENTERPRISE");
        
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
            //if (txtFromCTH.Text != "" && txtAgencyCode.Text != "")
            if (txtFromCTH.Text != "")
            {
                Admin_mas.SW_id = "0";
                Admin_mas.SW_FromCTH= txtFromCTH.Text;
                Admin_mas.CTH_STATUS = ddl_Status.SelectedItem.Text;
                Admin_mas.Ename = "autoid";
                dtuser = Admin_mas.RetrieveAll_Import_Restricted_RITC_master();
                string ii = Convert.ToString(Admin_mas.result);
                if (ii == "1")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Already Exist')</script>", false);
                }
                else
                {
                    if (dtuser.Tables[0].Rows.Count > 0)
                    {
                        AntiDumpting_master_insert();
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

    public void AntiDumpting_master_insert()
    {
        try
        {
            i = am.tbmanipulate("INSERT INTO RESTRICTED_CTH(CTH_NUMBER,CTH_STATUS) VALUES ( '" + txtFromCTH.Text.Trim() + "','" + ddl_Status.SelectedItem.Text + "')");

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
            if (txtFromCTH.Text != "")
            {
                int i;

                i = am.tbmanipulate("update RESTRICTED_CTH set CTH_NUMBER='" + txtFromCTH.Text.Trim() + "',CTH_STATUS='" + ddl_Status.SelectedItem.Text + "' where CTH_NUMBER=" + txtFromCTH.Text.Trim() + " ");

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
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {

            int i;

            //Admin_mas.SW_id = ViewState["ID"].ToString();
            Admin_mas.SW_id = "0";
            Admin_mas.SW_FromCTH =txtFromCTH.Text;
            Admin_mas.SW_AgencyCode= "0";
            Admin_mas.Ename = "delete";
            int pageno = 1;
            Admin_mas.startRowIndex = Convert.ToString(pageno);
            Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
            gvdetails.DataSource = Admin_mas.RetrieveAll_Import_Restricted_RITC_master();
            gvdetails.DataBind();

            Grid_Total(pageno, Admin_mas.Total_Rows);


            i = Admin_mas.result;
            if (i > 0)
            {

                mo.ResetFields(Page.Controls);

                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                txtFromCTH.Focus();
                txtFromCTH.Enabled = true;
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

            txtFromCTH.Focus();
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
            txtFromCTH.Enabled = true;
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
            Admin_mas.SW_id = "0";
            Admin_mas.SW_FromCTH = txtFromCTH.Text;
            Admin_mas.CTH_STATUS = ddl_Status.SelectedItem.Text;
            Admin_mas.Ename = "select_con";
            Admin_mas.startRowIndex = Convert.ToString(currentPageNumber1);
            Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
            gvdetails.EmptyDataText = "No Record Found";
            gvdetails.DataSource = Admin_mas.RetrieveAll_Import_Restricted_RITC_master();
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
            txtFromCTH.Text = "";
            ddl_Status.SelectedItem.Text = " ";    
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


    public void Edit_Anti_Notn_Details()
    {
        try
        {
            if (ViewState["CTH_NUMBER"] != "" && ViewState["CTH_NUMBER"] != null)
            {
                int i = 0;
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;

                Admin_mas.SW_FromCTH = ViewState["CTH_NUMBER"].ToString();
                Admin_mas.CTH_STATUS = ddl_Status.SelectedItem.Text;
                Admin_mas.Ename = "select_conwithcode";


                dtuser = Admin_mas.RetrieveAll_Import_Restricted_RITC_master();
                if (dtuser.Tables[0].Rows.Count > 0)
                {
                    txtFromCTH.Text = dtuser.Tables[0].Rows[0]["CTH_NUMBER"].ToString();
                    txtFromCTH.Enabled = false;
                    //ddl_Status.SelectedItem.Text = dtuser.Tables[0].Rows[0]["CTH_STATUS"].ToString();

                    ddl_Status.Items.Clear();
                    ddl_Status_List();
                    ddl_Status.Items.Remove(dtuser.Tables[0].Rows[0]["CTH_STATUS"].ToString().Replace("&nbsp;", "").Replace("&#160; ", ""));
                    ddl_Status.Items.Insert(0, dtuser.Tables[0].Rows[0]["CTH_STATUS"].ToString().Replace("&nbsp;", "").Replace("&#160;", ""));

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

            // ViewState["CATEGORY_ID"] = this.gvdetails.DataKeys[rowIndex]["CATEGORY_ID"].ToString();
            ViewState["CTH_NUMBER"] = Convert.ToString(this.gvdetails.SelectedDataKey.Value);

            Edit_Anti_Notn_Details();
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

                //div_pagination1.Visible = true;

            }
            else if (gvdetails.Rows.Count == 0)
            {
                Div_Pagination.Visible = false;
                //div_pagination1.Visible = false;
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

            txtFromCTH.Focus();
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
            txtFromCTH.Enabled = true;

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }
}