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

public partial class ERoyal_Admin_Master_Cess_Master : ThemeClass
{
    DataSet dss = new DataSet();
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 10;
    public int i;
    public string AUTO_ID;
    public string CESS_NOTN_DATE1;
    adminmaster Admin_mas = new adminmaster();

    DataSet dtuser = new DataSet();
    SqlConnection con;
    SqlCommand cmd;
    Manipulation mo = new Manipulation();
    AdminManipulation am = new AdminManipulation();
    AppSession aps = new AppSession();
    public string CESS_ID = "";
    public int rowindex;

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
            //aps.checkSession();


            txtCessSLNoSearch.Focus();
            //mainmastopusernametxt.InnerText = "Welcome Mr." + currentuser;
            Div_Pagination.Visible = false;


            if (!IsPostBack)
            {

                DateTime dat = System.DateTime.Now;
                datestring = string.Format("{0:dd/MM/yyyy}", dat);

                txtCessNotnDate.Text = datestring;

                ddlCessFlag.Items.Clear();

                ddlCessFlag.Items.Add("Y");
                ddlCessFlag.Items.Add("N");
                //StateName();
                Edit_CessDetails();
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
            if (txtCessSLNo.Text != "" && txtCessNotnNo.Text != "" && txtCessNotnDate.Text != "" && ddlCessFlag.SelectedValue != "" && txtCessRate.Text != "" && txtCessRITCNo.Text != "")
            {

                Admin_mas.Ecessid = "0";
                Admin_mas.Ecess_slno = txtCessSLNo.Text;
                Admin_mas.Ecess_notnno = "0";
                Admin_mas.Ename = "autoid";
                dtuser = Admin_mas.RetrieveAll_Cess_master();
                string ii = Convert.ToString(Admin_mas.result);
                if (ii == "1")
                {
                    //lblMsg.Text = "Not Save, Cess No Already Exist";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Cess No Already Exist')</script>", false);

                }
                else
                {

                    if (dtuser.Tables[0].Rows.Count > 0)
                    {
                        AUTO_ID = dtuser.Tables[0].Rows[0]["CESS_ID"].ToString();

                        if (AUTO_ID != "")
                        {
                            cess_master_insert();
                        }
                        else
                        {
                            AUTO_ID = "1";
                            cess_master_insert();

                        }

                    }
                }
            }
            else
            {
                // lblMsg.Text = "Enter All Mandatory Field";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Enter All Mandatory Field')</script>", false);

            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    public void cess_master_insert()
    {
        try
        {
            if (txtCessNotnDate.Text != "" || txtCessNotnDate.Text != null)
            {
                string txtCessNotnDate1 = txtCessNotnDate.Text;

                string[] date1 = txtCessNotnDate1.Split('/');
                string part1 = date1[0];
                string part2 = date1[1];
                string part3 = date1[2];

                CESS_NOTN_DATE1 = part2 + "/" + part1 + "/" + part3;
            }

            //DateTime Cess_NONT_Date = DateTime.Parse(txtCessNotnDate.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

            i = am.tbmanipulate("INSERT INTO CESS_MASTER VALUES (" + AUTO_ID + ",'" + txtCessSLNo.Text + "','" + txtCessNotnNo.Text + "','" + CESS_NOTN_DATE1 + "','" + ddlCessFlag.SelectedValue.ToString() + "','" + txtCessRate.Text + "','" + txtCessQty.Text + "','" + txtCessValue.Text + "','" + txtCessUnit.Text + "','" + txtCessRITCNo.Text + "','" + txtRemarks.Text + "','" + txt_Tarr_Value.Text + "','" + txt_Tarr_Unit.Text + "')");
            if (i > 0)
            {
                //lblMsg.Text = " Saved Successfully";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);
                int pageno = 1;
                gridbind(pageno);
                //mo.ResetFields(Page.Controls);
                txtCessSLNo.Focus();
                txtCessSLNo.Focus();

                DateTime dat = System.DateTime.Now;
                datestring = string.Format("{0:dd/MM/yyyy}", dat);
                txtCessNotnDate.Text = datestring;

                //Clear();
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
            txtCessSLNo.Enabled = true;
            mo.ResetFields(Page.Controls);

            ddlCessFlag.Items.Clear();
            //ddlCessFlag.Items.Add("-Select-");
            ddlCessFlag.Items.Add("Y");
            ddlCessFlag.Items.Add("N");

            //lblMsg.Text = "";
            txtCessSLNo.Focus();

            DateTime dat = System.DateTime.Now;
            datestring = string.Format("{0:dd/MM/yyyy}", dat);

            txtCessNotnDate.Text = datestring;

            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {

            int i;
            Admin_mas.Ecessid = ViewState["CESS_ID"].ToString();
            Admin_mas.Ecess_slno = "0";
            Admin_mas.Ecess_notnno = "0";

            Admin_mas.Ename = "delete";

            int pageno = 1;
            Admin_mas.startRowIndex = Convert.ToString(pageno);
            Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
            gvdetails.DataSource = Admin_mas.RetrieveAll_Cess_master();
            gvdetails.DataBind();

            Grid_Total(pageno, Admin_mas.Total_Rows);

            //int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
            //Add_Pageno(ii);
            i = Admin_mas.result;


            if (i > 0)
            {
                //lblMsg.Text = " Record Deleted";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Deleted')</script>", false);

                txtCessSLNo.Enabled = true;

                mo.ResetFields(Page.Controls);
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;

                DateTime dat = System.DateTime.Now;
                datestring = string.Format("{0:dd/MM/yyyy}", dat);

                txtCessNotnDate.Text = datestring;

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
            if (txtCessNotnDate.Text != "" || txtCessNotnDate.Text != null)
            {
                string txtCessNotnDate1 = txtCessNotnDate.Text;

                string[] date1 = txtCessNotnDate1.Split('/');
                string part1 = date1[0];
                string part2 = date1[1];
                string part3 = date1[2];

                CESS_NOTN_DATE1 = part2 + "/" + part1 + "/" + part3;
            }

            int i;

            DateTime NONT_Date = DateTime.Parse(txtCessNotnDate.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

            i = am.tbmanipulate("update CESS_MASTER set CESS_SLNO='" + txtCessSLNo.Text + "' ,CESS_NOTN_NO='" + txtCessNotnNo.Text + "',CESS_NOTN_DATE='" + CESS_NOTN_DATE1 + "',CESS_FLAG='" + ddlCessFlag.SelectedValue.ToString() + "',CESS_RATE='" + txtCessRate.Text + "',CESS_QTY='" + txtCessQty.Text + "',CESS_VALUE='" + txtCessValue.Text + "',CESS_UNIT='" + txtCessUnit.Text + "',CESS_RITC_NO='" + txtCessRITCNo.Text + "',CESS_REMARKS='" + txtRemarks.Text + "',TAR_VALUE='" + txt_Tarr_Value.Text + "',TAR_UNIT='" + txt_Tarr_Unit.Text + "' where CESS_ID=" + ViewState["CESS_ID"] + " ");
            if (i > 0)
            {
                //lblMsg.Text = "Records Saved";
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

    public void Edit_CessDetails()
    {
        try
        {
            if (ViewState["CESS_ID"] != "" && ViewState["CESS_ID"] != null)
            {
                int i = 0;
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                CESS_ID = ViewState["CESS_ID"].ToString();


                // string Query = "select * from SUP_MASTER where SUP_ID='" + SUP_ID + "'";

                string Query = "CESS_MASTER_SP_SELECT_CONWITHCODE";

                //gvdetails.DataSource = mo.RetrieveAll_LIKE(Query, SUP_ID);

                i = am.CESS_All_BIND(Query, CESS_ID);

                txtCessSLNo.Text = am.CESS_SLNO.Replace("&nbsp;", "");
                txtCessNotnNo.Text = am.CESS_NOTN_NO.Replace("&nbsp;", "");

                DateTime CESS_NOTN_DATE = Convert.ToDateTime(am.CESS_NOTN_DATE.ToString().Replace("&nbsp;", ""));

                txtCessNotnDate.Text = string.Format("{0:dd/MM/yyyy}", CESS_NOTN_DATE);

                //txtDBKRate.Text = am.CESS_FLAG;
                string flag = gvdetails.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
                ddlCessFlag.Items.Clear();
                ddlCessFlag.Items.Add("Y");
                ddlCessFlag.Items.Add("N");
                ddlCessFlag.Items.Remove(flag);

                ddlCessFlag.Items.Insert(0, flag);
                txtCessQty.Text = am.CESS_QTY.Replace("&nbsp;", "");

                txtCessRate.Text = am.CESS_RATE.Replace("&nbsp;", "");
                txtCessValue.Text = am.CESS_VALUE.Replace("&nbsp;", "");
                txtCessUnit.Text = am.CESS_UNIT.Replace("&nbsp;", "");
                txtCessRITCNo.Text = am.CESS_RITC_NO.Replace("&nbsp;", "");

                txtRemarks.Text = am.CESS_REMARKS.Replace("&nbsp;", "");

                txt_Tarr_Value.Text = am.TAR_VALUE.Replace("&nbsp;", "");
                txt_Tarr_Unit.Text = am.TAR_UNIT.Replace("&nbsp;", "");

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

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvdetails, "Select$" + e.Row.RowIndex.ToString());

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

            ViewState["CESS_ID"] = Convert.ToString(this.gvdetails.SelectedDataKey.Value);
            if (ViewState["CESS_ID"] != "" && ViewState["CESS_ID"] != null)
            {
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                txtCessSLNo.Text = gvdetails.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
                txtCessSLNo.Enabled = false;
                txtCessNotnNo.Text = gvdetails.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");

                DateTime CESS_NOTN_DATE = Convert.ToDateTime(gvdetails.SelectedRow.Cells[3].Text.Replace("&nbsp;", ""));

                txtCessNotnDate.Text = string.Format("{0:dd/MM/yyyy}", CESS_NOTN_DATE);

                //txtDBKRate.Text = am.CESS_FLAG;
                ddlCessFlag.Items.Clear();

                ddlCessFlag.Items.Add(gvdetails.SelectedRow.Cells[4].Text.Replace("&nbsp;", ""));
                ddlCessFlag.Items.Add("Y");
                ddlCessFlag.Items.Add("N");
                txtCessQty.Text = gvdetails.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
                txtCessRate.Text = gvdetails.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");

                txtCessValue.Text = gvdetails.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
                txtCessUnit.Text = gvdetails.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
                txtCessRITCNo.Text = gvdetails.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");

                txtRemarks.Text = gvdetails.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");
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

    public void gridbind(int currentPageNumber1)
    {
        try
        {
            Admin_mas.Ecessid = "0";
            Admin_mas.Ecess_slno = txtCessSLNoSearch.Text;
            Admin_mas.Ecess_notnno = txtCessNotnNoSearch.Text;

            //Admin_mas.Ename = "select_con";
            Admin_mas.Ename = "Select_SerialNo_Ritc";

            Admin_mas.startRowIndex = Convert.ToString(currentPageNumber1);
            Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);

            dss = Admin_mas.RetrieveAll_Cess_master();


            gvdetails.EmptyDataText = "No Record Found";
            gvdetails.DataSource = dss.Tables[1];


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
            //BindData(currentpagenumber2);
            //General_GridBind(currentpagenumber2);
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
            txtCessSLNo.Enabled = true;
            mo.ResetFields(Page.Controls);

            ddlCessFlag.Items.Clear();
            //ddlCessFlag.Items.Add("-Select-");
            ddlCessFlag.Items.Add("Y");
            ddlCessFlag.Items.Add("N");

            //lblMsg.Text = "";
            txtCessSLNo.Focus();

            DateTime dat = System.DateTime.Now;
            datestring = string.Format("{0:dd/MM/yyyy}", dat);

            txtCessNotnDate.Text = datestring;

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