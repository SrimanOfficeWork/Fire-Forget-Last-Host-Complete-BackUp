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
using ClosedXML.Excel;
using System.IO;

public partial class ERoyal_Admin_Master_Notification_Excise : ThemeClass
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
    public string NOTIFICATION_EXCISE_ID = "";
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
            currentuser = Session["currentuser"].ToString();
            //currentbranch = Session["currentbranch"].ToString();
            //currentcomp_name = Session["currentcomp_name"].ToString();
            //comp_ConnectionStr = Session["currentcomp_db"].ToString();
            //Working_Period = Session["WorkingPeriod"].ToString();
            //LoginDate = Session["LoginDate"].ToString();

            txtNotification_Excise_NOTN_Search.Focus();

            //mainmastopusernametxt.InnerText = "Welcome Mr." + currentuser;
            Div_Pagination.Visible = false;

            GridDownloadTemplate.Visible = false;
            NewNotification_CustomsTemplate.Visible = true;

            if (!IsPostBack)
            {

                Edit_Notification_ExciseDetails();
                DataTable dt = new DataTable();
                gvdetails.EmptyDataText = "";
                gvdetails.DataSource = dt;
                gvdetails.DataBind();
                // int pageno = 1;

                //gridbind(pageno);
                ////int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
                ////Add_Pageno(ii);
                Load_ddl_Notn_Type();

            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
    }

    private void Load_ddl_Notn_Type()
    {
        try
        {
            ddl_Notn_Type.Items.Add("");
            ddl_Notn_Type.Items.Add("E");
            ddl_Notn_Type.Items.Add("1E");
            ddl_Notn_Type.Items.Add("1L");
            ddl_Notn_Type.Items.Add("2E");
            ddl_Notn_Type.Items.Add("2L");
            ddl_Notn_Type.Items.Add("1C");
            ddl_Notn_Type.Items.Add("2C");
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
            if (txtNotification_Excise_NOTN.Text != "")
            {

                //Admin_mas.ENotification_Excise_id = "0";
                Admin_mas.ENotification_Excise_id = ddl_Notn_Type.SelectedItem.Text;
                Admin_mas.ENotification_Excise_notn = txtNotification_Excise_NOTN.Text;
                Admin_mas.ENotification_Excise_notn_slno = txtNotification_Excise_NOTN_SL.Text;

                Admin_mas.Ename = "autoid";

                dtuser = Admin_mas.RetrieveAll_Notification_Excise_master();
                string ii = Convert.ToString(Admin_mas.result);
                if (ii == "1")
                {
                    //lblMsg.Text = "Not Save, CETH Code Already Exist";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Notification Excise NOTN  Already Exist')</script>", false);

                }
                else
                {

                    if (dtuser.Tables[0].Rows.Count > 0)
                    {
                        AUTO_ID = dtuser.Tables[0].Rows[0]["NOTIFICATION_EXCISE_ID"].ToString();

                        if (AUTO_ID != "")
                        {
                            Notification_Excise_master_insert();
                        }
                        else
                        {
                            AUTO_ID = "1";
                            Notification_Excise_master_insert();

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

    public void Notification_Excise_master_insert()
    {
        try
        {
            //i = am.tbmanipulate("INSERT INTO NOTIFICATION_EXCISE VALUES (" + AUTO_ID + ",'" + txtNotification_Excise_NOTN.Text + "','" + txtNotification_Excise_NOTN_SL.Text + "','" + txtNotification_Excise_CETH.Text + "','" + txtNotification_Excise_BCD_Rate.Text + "','" + txtNotification_Excise_BCD_SPL.Text + "','" + txtNotification_Excise_BCD_Unit.Text + "','" + txtNotification_Excise_BCD_SPL_Type.Text + "','" + txtNotification_Excise_CVD_Rate.Text + "','" + txtNotification_Excise_CVD_SPL.Text + "','" + txtNotification_Excise_CVD_Unit.Text + "','" + txtNotification_Excise_CVD_SPL_Type.Text + "','" + txtNotification_Excise_Applicable.Text + "','" + txtRemarks.Text  + "')");

            //i = am.tbmanipulate("INSERT INTO NOTIFICATION_EXCISE VALUES (" + AUTO_ID + ",'" + txtNotification_Excise_NOTN.Text + "','" + txtNotification_Excise_NOTN_SL.Text + "','" + txtNotification_Excise_CETH.Text + "','" + txtNotification_Excise_BCD_Rate.Text + "','" + txtNotification_Excise_BCD_SPL.Text + "','" + txtNotification_Excise_BCD_Unit.Text + "','" + txtNotification_Excise_BCD_SPL_Type.Text + "','" + txtNotification_Excise_CVD_Rate.Text + "','" + txtNotification_Excise_CVD_SPL.Text + "','" + txtNotification_Excise_CVD_Unit.Text + "','" + txtNotification_Excise_CVD_SPL_Type.Text + "','" + txtNotification_Excise_Applicable.Text + "','" + txtRemarks.Text + "','" + ddl_Notification_Excise_FLAG.SelectedItem.Text + "','" + ddl_Notn_Type.SelectedItem.Text + "')");
            i = am.tbmanipulate("INSERT INTO NOTIFICATION_EXCISE VALUES (" + AUTO_ID + ",'" + txtNotification_Excise_NOTN.Text + "','" + txtNotification_Excise_NOTN_SL.Text + "','" + txtNotification_Excise_CETH.Text + "','" + txtNotification_Excise_BCD_Rate.Text + "','" + txtNotification_Excise_BCD_SPL.Text + "','" + txtNotification_Excise_BCD_Unit.Text + "','" + txtNotification_Excise_BCD_SPL_Type.Text + "','" + txtNotification_Excise_CVD_Rate.Text + "','" + txtNotification_Excise_CVD_SPL.Text + "','" + txtNotification_Excise_CVD_Unit.Text + "','" + txtNotification_Excise_CVD_SPL_Type.Text + "','" + txtNotification_Excise_Applicable.Text + "','" + txtRemarks.Text + "','" + ddl_Notification_Excise_FLAG.SelectedItem.Text + "','" + ddl_Notn_Type.SelectedItem.Text + "','" + Connection.Current_User() + "','" + DateTime.Now + "','" + Connection.Current_User() + "','" + DateTime.Now + "','" + "S" + "')");

            if (i > 0)
            {
                //lblMsg.Text = " Saved Successfully";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);

                int pageno = 1;
                gridbind(pageno);
                //mo.ResetFields(Page.Controls);
                txtNotification_Excise_NOTN.Focus();
                //Clear();
                // btnNew.Focus();
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
            txtNotification_Excise_NOTN.Enabled = true;
            mo.ResetFields(Page.Controls);
            //lblMsg.Text = "";
            txtNotification_Excise_NOTN.Focus();
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

            /*20-08-2022
            Admin_mas.ENotification_Excise_id = ViewState["NOTIFICATION_EXCISE_ID"].ToString();
            Admin_mas.ENotification_Excise_notn = "0";
            Admin_mas.ENotification_Excise_notn_slno = "0";
             * */

            Admin_mas.ENotification_Excise_id = ddl_Notn_Type.SelectedItem.Text;
            Admin_mas.ENotification_Excise_notn = txtNotification_Excise_NOTN.Text;
            Admin_mas.ENotification_Excise_notn_slno = txtNotification_Excise_NOTN_SL.Text;
            Admin_mas.Ename = "delete";

            int pageno = 1;
            Admin_mas.startRowIndex = Convert.ToString(pageno);
            Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
            gvdetails.DataSource = Admin_mas.RetrieveAll_Notification_Excise_master();
            gvdetails.DataBind();

            Grid_Total(pageno, Admin_mas.Total_Rows);
            i = Admin_mas.result;

            if (i > 0)
            {
                //lblMsg.Text = " Record Deleted";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Deleted')</script>", false);

                mo.ResetFields(Page.Controls);
                mo.ResetFields(Page.Controls);

                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                txtNotification_Excise_NOTN.Focus();
                txtNotification_Excise_NOTN.Enabled = true;

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

            //i = am.tbmanipulate("update NOTIFICATION_EXCISE set NOTIFICATION_EXCISE_NOTN='" + txtNotification_Excise_NOTN.Text + "' ,NOTIFICATION_EXCISE_NOTN_SL='" + txtNotification_Excise_NOTN_SL.Text + "',NOTIFICATION_EXCISE_CETH='" + txtNotification_Excise_CETH.Text + "',NOTIFICATION_EXCISE_BCD_RATE='" + txtNotification_Excise_BCD_Rate.Text + "',NOTIFICATION_EXCISE_BCD_SPL='" + txtNotification_Excise_BCD_SPL.Text + "',NOTIFICATION_EXCISE_BCD_UNIT='" + txtNotification_Excise_BCD_Unit.Text + "',NOTIFICATION_EXCISE_BCD_SPL_TYPE='" + txtNotification_Excise_BCD_SPL_Type.Text + "',NOTIFICATION_EXCISE_CVD_RATE='" + txtNotification_Excise_CVD_Rate.Text + "',NOTIFICATION_EXCISE_CVD_SPL='" + txtNotification_Excise_CVD_SPL.Text + "',NOTIFICATION_EXCISE_CVD_UNIT='" + txtNotification_Excise_CVD_Unit.Text + "',NOTIFICATION_EXCISE_CVD_SPL_TYPE='" + txtNotification_Excise_CVD_SPL_Type.Text + "',NOTIFICATION_EXCISE_APPLICABLE='" + txtNotification_Excise_Applicable.Text + "',NOTIFICATION_EXCISE_REMARKS='" + txtRemarks.Text + "',NOTIFICATION_FLAG='" + ddl_Notification_Excise_FLAG.SelectedItem.Text + "',NOTIFICATION_TYPE='" + ddl_Notn_Type.SelectedItem.Text + "' where NOTIFICATION_EXCISE_NOTN='" + txtNotification_Excise_NOTN.Text + "' and NOTIFICATION_EXCISE_NOTN_SL='" + txtNotification_Excise_NOTN_SL.Text + "'and NOTIFICATION_TYPE='" + ddl_Notn_Type.SelectedItem.Text + "'");
            i = am.tbmanipulate("update NOTIFICATION_EXCISE set NOTIFICATION_EXCISE_NOTN='" + txtNotification_Excise_NOTN.Text + "' ,NOTIFICATION_EXCISE_NOTN_SL='" + txtNotification_Excise_NOTN_SL.Text + "',NOTIFICATION_EXCISE_CETH='" + txtNotification_Excise_CETH.Text + "',NOTIFICATION_EXCISE_BCD_RATE='" + txtNotification_Excise_BCD_Rate.Text + "',NOTIFICATION_EXCISE_BCD_SPL='" + txtNotification_Excise_BCD_SPL.Text + "',NOTIFICATION_EXCISE_BCD_UNIT='" + txtNotification_Excise_BCD_Unit.Text + "',NOTIFICATION_EXCISE_BCD_SPL_TYPE='" + txtNotification_Excise_BCD_SPL_Type.Text + "',NOTIFICATION_EXCISE_CVD_RATE='" + txtNotification_Excise_CVD_Rate.Text + "',NOTIFICATION_EXCISE_CVD_SPL='" + txtNotification_Excise_CVD_SPL.Text + "',NOTIFICATION_EXCISE_CVD_UNIT='" + txtNotification_Excise_CVD_Unit.Text + "',NOTIFICATION_EXCISE_CVD_SPL_TYPE='" + txtNotification_Excise_CVD_SPL_Type.Text + "',NOTIFICATION_EXCISE_APPLICABLE='" + txtNotification_Excise_Applicable.Text + "',NOTIFICATION_EXCISE_REMARKS='" + txtRemarks.Text + "',NOTIFICATION_FLAG='" + ddl_Notification_Excise_FLAG.SelectedItem.Text + "',NOTIFICATION_TYPE='" + ddl_Notn_Type.SelectedItem.Text + "',MODIFIED_BY='" + Connection.Current_User() + "',MODIFIED_ON='" + DateTime.Now + "',ACTION='" + "U" + "' where NOTIFICATION_EXCISE_NOTN='" + txtNotification_Excise_NOTN.Text + "' and NOTIFICATION_EXCISE_NOTN_SL='" + txtNotification_Excise_NOTN_SL.Text + "'and NOTIFICATION_TYPE='" + ddl_Notn_Type.SelectedItem.Text + "'");

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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            NewNotification_CustomsTemplate.Visible = false;
            GridDownloadTemplate.Visible = true;
            Main_GridView.Visible = true;
            int pageno = 1;
            gridbind(pageno);
            //int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
            //dd_Pageno(ii);
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
            Admin_mas.ENotification_Excise_id = "0";
            Admin_mas.ENotification_Excise_notn = txtNotification_Excise_NOTN_Search.Text;
            Admin_mas.ENotification_Excise_notn_slno = txtNotification_Excise_NOTN_SL_Search.Text;
            Admin_mas.Ename = "select_con";

            Admin_mas.startRowIndex = Convert.ToString(currentPageNumber1);
            Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
            //ds = erm.RetrieveAll_Adcode_MASTER();
            gvdetails.EmptyDataText = "No Record Found";

            DataSet ds = Admin_mas.RetrieveAll_Notification_Excise_master();
            gvdetails.DataSource = ds;
            gvdetails.DataBind();

            if (ds != null && ds.Tables.Count > 0)
            {
                // Session["ExportData"] = ds.Tables[1];
                DataTable dt = ds.Tables[1].Copy();

                if (dt.Columns.Contains("CTH_NO"))
                    dt.Columns.Remove("CTH_NO");

                if (dt.Columns.Contains("LEVY_1DANDS"))
                    dt.Columns.Remove("LEVY_1DANDS");

                Session["ExportData"] = dt;
            }


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


    public void Edit_Notification_ExciseDetails()
    {
        try
        {
            if (ViewState["NOTIFICATION_EXCISE_ID"] != "" && ViewState["NOTIFICATION_EXCISE_ID"] != null)
            {
                int i = 0;
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                NOTIFICATION_EXCISE_ID = ViewState["NOTIFICATION_EXCISE_ID"].ToString();
                Admin_mas.ENotification_Excise_id = NOTIFICATION_EXCISE_ID;
                Admin_mas.ENotification_Excise_notn = "0";
                Admin_mas.ENotification_Excise_notn_slno = "0";
                Admin_mas.Ename = "select_conwithcode";


                dtuser = Admin_mas.RetrieveAll_Notification_Excise_master();
                if (dtuser.Tables[0].Rows.Count > 0)
                {
                    txtNotification_Excise_NOTN.Text = dtuser.Tables[0].Rows[0]["NOTIFICATION_EXCISE_NOTN"].ToString();
                    txtNotification_Excise_NOTN.Enabled = false;

                    txtNotification_Excise_NOTN_SL.Text = dtuser.Tables[0].Rows[0]["NOTIFICATION_EXCISE_NOTN_SL"].ToString();

                    txtNotification_Excise_CETH.Text = dtuser.Tables[0].Rows[0]["NOTIFICATION_EXCISE_CETH"].ToString();
                    txtNotification_Excise_BCD_Rate.Text = dtuser.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_RATE"].ToString();
                    txtNotification_Excise_BCD_SPL.Text = dtuser.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_SPL"].ToString();
                    txtNotification_Excise_BCD_Unit.Text = dtuser.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_UNIT"].ToString();
                    txtNotification_Excise_BCD_SPL_Type.Text = dtuser.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_SPL_TYPE"].ToString();
                    txtNotification_Excise_CVD_Rate.Text = dtuser.Tables[0].Rows[0]["NOTIFICATION_EXCISE_CVD_RATE"].ToString();
                    txtNotification_Excise_CVD_SPL.Text = dtuser.Tables[0].Rows[0]["NOTIFICATION_EXCISE_CVD_SPL"].ToString();

                    txtNotification_Excise_CVD_Unit.Text = dtuser.Tables[0].Rows[0]["NOTIFICATION_EXCISE_CVD_UNIT"].ToString();

                    txtNotification_Excise_CVD_SPL_Type.Text = dtuser.Tables[0].Rows[0]["NOTIFICATION_EXCISE_CVD_SPL_TYPE"].ToString();
                    txtNotification_Excise_Applicable.Text = dtuser.Tables[0].Rows[0]["NOTIFICATION_EXCISE_APPLICABLE"].ToString();
                    txtRemarks.Text = dtuser.Tables[0].Rows[0]["NOTIFICATION_EXCISE_REMARKS"].ToString();

                    ddl_Notification_Excise_FLAG.SelectedValue = dtuser.Tables[0].Rows[0]["NOTIFICATION_FLAG"].ToString();

                    ddl_Notn_Type.Items.Clear();
                    Load_ddl_Notn_Type();
                    ddl_Notn_Type.Items.Remove(dtuser.Tables[0].Rows[0]["NOTIFICATION_TYPE"].ToString());
                    ddl_Notn_Type.SelectedItem.Text = dtuser.Tables[0].Rows[0]["NOTIFICATION_TYPE"].ToString();

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
            ViewState["NOTIFICATION_EXCISE_ID"] = Convert.ToString(this.gvdetails.SelectedDataKey.Value);

            Edit_Notification_ExciseDetails();
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
            txtNotification_Excise_NOTN.Enabled = true;
            mo.ResetFields(Page.Controls);
            //lblMsg.Text = "";
            txtNotification_Excise_NOTN.Focus();
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }

    protected void lnkExport_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["ExportData"] != null)
            {
                DataTable dt = Session["ExportData"] as DataTable;
                ExportUsingClosedXML(dt);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No data found to export!');", true);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }

    private void ExportUsingClosedXML(DataTable dt)
    {
        try
        {
            using (XLWorkbook wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add(dt, "Notification_Customs");
                ws.Row(1).Style.Font.Bold = true;
                ws.Columns().AdjustToContents();

                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", "attachment; filename=Notification_EXCISE.xlsx");
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.BinaryWrite(stream.ToArray());
                    Response.Flush();
                    Response.End();
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
    }

    protected void btn_upload_Click(object sender, EventArgs e)
    {
        string res = "";
        try
        {
            string Priority_Type = ddl_Priority.SelectedValue.ToString();
            string fileName = fileuploadExcel.FileName;
            int fileSize = fileuploadExcel.PostedFile.ContentLength;
            string fileType = fileuploadExcel.PostedFile.ContentType;
            string baseFolderPath = Server.MapPath("~/Submission/" +
                HttpContext.Current.Session["COMPANY_ID"].ToString() +
                "/" + HttpContext.Current.Session["currentbranch"].ToString() +
                "/" + HttpContext.Current.Session["currentuser"].ToString() +
                "/IMPORT_Notification_Excise");

            if (!Directory.Exists(baseFolderPath))
            {
                Directory.CreateDirectory(baseFolderPath);
            }
            else
            {
                // If folder exists, delete all existing files inside
                string[] existingFiles = Directory.GetFiles(baseFolderPath);
                foreach (string file in existingFiles)
                {
                    File.Delete(file);
                }
            }

            string savePath = Path.Combine(baseFolderPath, fileName);
            fileuploadExcel.SaveAs(savePath);

            DataSet ds = ReadExcelFileToDataTable(savePath);
            if (ds.Tables[0].Rows.Count <= 0)
            {
                res = "Empty File Not Allowed";
                Alert_msg(res);
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("SLNO");
                dt.Columns.Add("NOTIFICATION_EXCISE_NOTN");
                dt.Columns.Add("ERROR_DESCRIPTION");
                dt.Columns.Add("FIELD_Name");
                int Count = 1;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    string value = dr["NOTIFICATION_EXCISE_NOTN"].ToString().Trim();

                    if (string.IsNullOrEmpty(value) || !Regex.IsMatch(value, @"^[a-zA-Z\d/]+$"))
                    {
                        DataRow newdr = dt.NewRow();
                        newdr["ERROR_DESCRIPTION"] = "Only alphabets, numbers and '/' are allowed. Field is mandatory.";
                        newdr["NOTIFICATION_EXCISE_NOTN"] = dr["NOTIFICATION_EXCISE_NOTN"].ToString();
                        newdr["FIELD_Name"] = "NOTIFICATION_EXCISE_NOTN";
                        newdr["SLNO"] = Count;
                        dt.Rows.Add(newdr);
                    }

                    Count++;
                }

                if (dt.Rows.Count > 0)
                {
                    Main_GridView.Visible = false;
                    gv_Preview.DataSource = dt;
                    gv_Preview.DataBind();
                    Label12.Text = "Notification_Excise Excel Invalid Errors";
                    Label12.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>Excel_File_Validation()</script>", false);
                }
                else
                {
                    Admin_mas.Update_Priority = ddl_Priority.SelectedValue.ToString();
                    Admin_mas.Xml_A = DataTableToXml(ds);
                    Admin_mas.USER_ID = currentuser;

                    ds = Admin_mas.Notification_Excise_Record();
                    string result = ds.Tables[0].Rows[0][0].ToString().Trim();

                    if (result.Contains("Updated and Insert New Records Successfully") ||
                            result.Contains("Delete And Insert Records Successfully") ||
                            result.Contains("New Records Inserted Successfully") ||
                            result.Contains("Check The Duplicate Records"))
                    {
                        res = result;
                        Alert_msg(res);
                        mo.ResetFields(Page.Controls);
                        gridbind(1);
                    }
                    else
                    {
                        gv_Preview.DataSource = ds.Tables[0];
                        gv_Preview.DataBind();
                        Label12.Text = "Notification_Excise Excel Already Exist Records";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>Excel_File_Validation()</script>", false);
                        gridbind(1);
                    }
                }
            }
        }

        catch (Exception ex)
        {
            res = ex.Message;
            Alert_msg(res);
        }
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Notification_Excise_Record DETAILS', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    private DataSet ReadExcelFileToDataTable(string filePath)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add();
        try
        {
            using (var workbook = new ClosedXML.Excel.XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheets.Worksheet(1);
                var headerRow = worksheet.Row(1);
                foreach (var cell in headerRow.Cells())
                {
                    ds.Tables[0].Columns.Add(cell.Value.ToString().Trim());
                }
                foreach (var row in worksheet.RowsUsed().Skip(1))
                {
                    DataRow dataRow = ds.Tables[0].NewRow();
                    for (int col = 0; col < ds.Tables[0].Columns.Count; col++)
                    {
                        dataRow[col] = row.Cell(col + 1).Value;
                    }
                    if (dataRow.ItemArray[0] == "")
                    {
                        string values = "Please Fill NOTIFICATION_Excise_NOTN Column in your Excel";

                        ds.Tables[0].Rows.Add(values);
                        return ds;
                    }
                    else
                    {
                        ds.Tables[0].Rows.Add(dataRow);
                    }

                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
        return ds;
    }

    private string DataTableToXml(DataSet ds)
    {
        using (System.IO.StringWriter sw = new System.IO.StringWriter())
        {
            ds.Tables[0].WriteXml(sw, XmlWriteMode.WriteSchema);
            return sw.ToString();
        }
    }

    protected void gv_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.ForeColor = System.Drawing.Color.Black;
            e.Row.BackColor = System.Drawing.Color.Gray;

        }

    }
}