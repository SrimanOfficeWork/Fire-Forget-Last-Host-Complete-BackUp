using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Web;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class ERoyal_User_SingleWindow_UserWise : ThemeClass
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 10;
    public int i, Total_Rows;
    public string AUTO_ID;

    // NOTE: adminmaster (SW_CTH_CODE_MASTER) removed for this screen — that
    // table belongs to the Admin master screen. This screen now goes through
    // eroyalmaster's SW_* properties and the new SP_SW_CTH_CODE_MASTER_USERWISE_*
    // procedures, scoped to the logged-in user.
    eroyalmaster Emas = new eroyalmaster();

    DataSet dtuser = new DataSet();

    SqlConnection con;
    SqlCommand cmd;
    Manipulation mo = new Manipulation();
    AppSession aps = new AppSession();
    public string SW_ID = "";
    ErrorLogs er = new ErrorLogs();

    string datestring;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();

            txtFromCTHSearch.Focus();
            DateTime dat = System.DateTime.Now;
            datestring = string.Format("{0:dd/MM/yyyy}", dat);

            Div_Pagination.Visible = false;

            if (!IsPostBack)
            {
                Load_SingleWindow_UserWise_Details();
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
            if (txtFromCTH.Text != "" && ddl_AgencyCode.SelectedItem.Text != "")
            {
                Emas.SW_ID = "0";
                Emas.SW_FROM_CTH = txtFromCTH.Text.Trim();
                Emas.SW_TO_CTH = txtToCTH.Text.Trim();
                Emas.SW_AGENCY_CODE = ddl_AgencyCode.SelectedValue;
                Emas.flag = "S";

                Emas.SingleWindow_UserWise_Insert_update();

                if (Emas.result == -1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Already Exist')</script>", false);
                }
                else if (Emas.result > 0)
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
        btnNew_Click(sender, e);
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtFromCTH.Text != "" && ddl_AgencyCode.SelectedItem.Text != "")
            {
                Emas.SW_ID = ViewState["ID"].ToString();
                Emas.SW_FROM_CTH = txtFromCTH.Text.Trim();
                Emas.SW_TO_CTH = txtToCTH.Text.Trim();
                Emas.SW_AGENCY_CODE = ddl_AgencyCode.SelectedValue;
                Emas.flag = "U";

                Emas.SingleWindow_UserWise_Insert_update();

                if (Emas.result > 0)
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
            Emas.SW_ID = ViewState["ID"].ToString();
            Emas.Ename = "delete";
            Emas.RetrieveAll_SingleWindow_UserWise_master();

            if (Emas.result > 0)
            {
                mo.ResetFields(Page.Controls);

                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                txtFromCTH.Focus();
                txtFromCTH.Enabled = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Deleted')</script>", false);

                int pageno = 1;
                gridbind(pageno);
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
            Emas.SW_ID = "0";
            Emas.SW_FROM_CTH = txtFromCTHSearch.Text;
            Emas.SW_AGENCY_CODE = txtAgencyCodeSearch.Text;
            Emas.Ename = "select_con";
            Emas.startRowIndex = Convert.ToString(currentPageNumber1);
            Emas.maximumRows = Convert.ToString(gvdetails.PageSize);
            gvdetails.EmptyDataText = "No Record Found";
            gvdetails.DataSource = Emas.RetrieveAll_SingleWindow_UserWise_master();
            gvdetails.DataBind();
            Grid_Total(currentPageNumber1, Emas.result);
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
            txtFromCTH.Text = " ";
            txtToCTH.Text = " ";
            ddl_AgencyCode.SelectedValue = " ";
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

    public void  Load_SingleWindow_UserWise_Details()
    {
        try
        {
            if (ViewState["ID"] != "" && ViewState["ID"] != null)
            {
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                SW_ID = ViewState["ID"].ToString();

                Emas.SW_ID = SW_ID;
                Emas.Ename = "select_conwithcode";

                dtuser = Emas.RetrieveAll_SingleWindow_UserWise_master();
                if (dtuser.Tables[0].Rows.Count > 0)
                {
                    txtFromCTH.Text = dtuser.Tables[0].Rows[0]["FROM_CTH"].ToString();
                    txtFromCTH.Enabled = false;
                    txtToCTH.Text = dtuser.Tables[0].Rows[0]["TO_CTH"].ToString();
                    ddl_AgencyCode.SelectedValue = dtuser.Tables[0].Rows[0]["AGENCY_CODE"].ToString();
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

            Load_SingleWindow_UserWise_Details();
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
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.CssClass = "header";

            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
                e.Row.CssClass = "normal";

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
