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

public partial class ERoyal_Admin_Master_CTH_Master : ThemeClass

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
    public string CTH_ID = "";
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
    public string USER_ID;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        
        txtCth_Code_Search.Focus();

        //mainmastopusernametxt.InnerText = "Welcome Mr." + currentuser;
        Div_Pagination.Visible = false;

        USER_ID = Session["currentuser"].ToString(); 

        if (!IsPostBack)
        {
            SearchTemplate.Visible = false;
            spanDownloadTemplate.Visible = true;

            Edit_CthDetails();
            DataTable dt = new DataTable();
            gvdetails.EmptyDataText = "";
            gvdetails.DataSource = dt;
            gvdetails.DataBind();
            // int pageno = 1;

            //gridbind(pageno);
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //CETH code must be 8 character start
        string TEMP = txtCth_Code.Text;
        byte TEMPLEN = Convert.ToByte(TEMP.Length);
        if (TEMPLEN != 8)
        {
            //lblMsg.Text = "CETH Code must be 8  character";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('CTH Code Should be 8  character')</script>", false);

        } ////CETH code must be 8  character end

        else
        {
            try
            {
                if (txtCth_Code.Text != ""  && txtCth_Rate.Text != "")
                {
                    Admin_mas.Ecth_id = "0";
                    Admin_mas.Ecth_code = txtCth_Code.Text;
                    Admin_mas.Ecth_description = "0";

                    Admin_mas.Ename = "autoid";

                    dtuser = Admin_mas.RetrieveAll_CTH_master();
                    string ii = Convert.ToString(Admin_mas.result);
                    if (ii == "1")
                    {
                        //lblMsg.Text = "Not Save, CETH Code Already Exist";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('CTH Code Already Exist')</script>", false);
                    }
                    else
                    {
                        if (dtuser.Tables[0].Rows.Count > 0)
                        {
                            AUTO_ID = dtuser.Tables[0].Rows[0]["CTH_ID"].ToString();

                            if (AUTO_ID != "")
                            {
                                CTH_Master_insert("S");
                            }
                            else
                            {
                                AUTO_ID = "1";
                                CTH_Master_insert("S");

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

    public void CTH_Master_insert(string Action)
    {
        //i = am.tbmanipulate("INSERT INTO CTH_MASTER VALUES (" + AUTO_ID + ",'" + txtCth_Code.Text + "','" + txtCth_Description.Text + "','" + txtCth_Rate.Text + "','" + txtCth_Spl_Amount.Text + "','" + txtCth_Spl_Unit.Text + "','" + txtCth_Educational_E_Rate.Text + "','" + txtCth_S_Educational_N_Rate.Text + "','" + txtCth_SAPTA_P_Rate.Text + "','" + txtCth_SafeGuard_S_Rate.Text + "','" + txtCth_SAD_V_Rate.Text + "','" + txtCth_Aggregate_A_Rate.Text + "','" + txtCth_NCD_D_Rate.Text + "','" + txtCth_Other_O_Rate.Text + "','" + txtRemarks.Text + "','','" + txt_infra_cess.Text + "','" + "Y" + "','" + txt_InfoUQC.Text + "','" + txtCth_NCD_SplDuty.Text + "','" + txtCth_NCD_SplUnit.Text + "','" + ddl_CTH_FLAG.SelectedValue + "')");
       // i = am.tbmanipulate("INSERT INTO CTH_MASTER VALUES (" + AUTO_ID + ",'" + txtCth_Code.Text + "','" + txtCth_Description.Text + "','" + txtCth_Rate.Text + "','" + txtCth_Spl_Amount.Text + "','" + txtCth_Spl_Unit.Text + "','" + txtCth_Educational_E_Rate.Text + "','" + txtCth_S_Educational_N_Rate.Text + "','" + txtCth_SAPTA_P_Rate.Text + "','" + txtCth_SafeGuard_S_Rate.Text + "','" + txtCth_SAD_V_Rate.Text + "','" + txtCth_Aggregate_A_Rate.Text + "','" + txtCth_NCD_D_Rate.Text + "','" + txtCth_Other_O_Rate.Text + "','" + txtRemarks.Text + "','','" + txt_infra_cess.Text + "','" + ddlvalid.SelectedValue + "','" + txt_InfoUQC.Text + "','" + txtCth_NCD_SplDuty.Text + "','" + txtCth_NCD_SplUnit.Text + "','" + ddl_CTH_FLAG.SelectedValue + "')");
        i = am.tbmanipulate("INSERT INTO CTH_MASTER VALUES (" + AUTO_ID + ",'" + txtCth_Code.Text + "','" + txtCth_Description.Text + "','" + txtCth_Rate.Text + "','" + txtCth_Spl_Amount.Text + "','" + txtCth_Spl_Unit.Text + "','" + txtCth_Educational_E_Rate.Text + "','" + txtCth_S_Educational_N_Rate.Text + "','" + txtCth_SAPTA_P_Rate.Text + "','" + txtCth_SafeGuard_S_Rate.Text + "','" + txtCth_SAD_V_Rate.Text + "','" + txtCth_Aggregate_A_Rate.Text + "','" + txtCth_NCD_D_Rate.Text + "','" + txtCth_Other_O_Rate.Text + "','" + txtRemarks.Text + "','','" + txt_infra_cess.Text + "','" + ddlvalid.SelectedValue + "','" + txt_InfoUQC.Text + "','" + txtCth_NCD_SplDuty.Text + "','" + txtCth_NCD_SplUnit.Text + "','" + ddl_CTH_FLAG.SelectedValue + "','" + Connection.Current_User() + "','" + DateTime.Now + "','" + Connection.Current_User() + "','" + DateTime.Now + "','" + Action + "' )");

        if (i > 0)
        {
            //lblMsg.Text = " Saved Successfully";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);

            int pageno = 1;
            gridbind(pageno);
            //mo.ResetFields(Page.Controls);
            txtCth_Code.Focus();
            //Clear();
            btnNew.Focus();
        }
        else
        {
            //lblMsg.Text = " Record Not Saved";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        txtCth_Code.Enabled = true;
        mo.ResetFields(Page.Controls);
        // lblMsg.Text = "";
        txtCth_Code.Focus();
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnSave.Visible = true;
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {

            int i;
            Admin_mas.Ecth_id = ViewState["CTH_ID"].ToString();
            Admin_mas.Ecth_code = "0";
            Admin_mas.Ecth_description = "0";
            Admin_mas.Ename = "delete";
            int pageno = 1;
            Admin_mas.startRowIndex = Convert.ToString(pageno);
            Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
            gvdetails.DataSource = Admin_mas.RetrieveAll_CTH_master();
            gvdetails.DataBind();

            Grid_Total(pageno, Admin_mas.Total_Rows);

            i = Admin_mas.result;

            if (i > 0)
            {
                //lblMsg.Text = " Record Deleted";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Deleted')</script>", false);
                txtCth_Code.Enabled = true;

                mo.ResetFields(Page.Controls);
                txtCth_Code.Focus();
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;

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

            //i = am.tbmanipulate("update CTH_MASTER set CTH_CODE='" + txtCth_Code.Text + "' ,CTH_DESCRIPTION='" + txtCth_Description.Text + "',CTH_RATE='" + txtCth_Rate.Text + "',CTH_SPL_AMT='" + txtCth_Spl_Amount.Text + "',CTH_SPL_UNIT='" + txtCth_Spl_Unit.Text + "',CTH_EDUCATIONAL_E_RATE='" + txtCth_Educational_E_Rate.Text + "',CTH_S_EDUCATIONAL_N_RATE='" + txtCth_S_Educational_N_Rate.Text + "',CTH_SAPTA_P_RATE='" + txtCth_SAPTA_P_Rate.Text + "',CTH_SAFEGUARD_S_RATE='" + txtCth_SafeGuard_S_Rate.Text + "',CTH_SAD_V_RATE='" + txtCth_SAD_V_Rate.Text + "',CTH_AGGREGATE_A_RATE='" + txtCth_Aggregate_A_Rate.Text + "',CTH_NCD_D_RATE='" + txtCth_NCD_D_Rate.Text + "',CTH_OTHER_O_RATE='" + txtCth_Other_O_Rate.Text + "',CTH_REMARKS='" + txtRemarks.Text + "' where CTH_ID=" + ViewState["CTH_ID"] + " ");
            //i = am.tbmanipulate("update CTH_MASTER set CTH_CODE='" + txtCth_Code.Text + "' ,CTH_DESCRIPTION='" + txtCth_Description.Text + "',CTH_RATE='" + txtCth_Rate.Text + "',CTH_SPL_AMT='" + txtCth_Spl_Amount.Text + "',CTH_SPL_UNIT='" + txtCth_Spl_Unit.Text + "',CTH_EDUCATIONAL_E_RATE='" + txtCth_Educational_E_Rate.Text + "',CTH_S_EDUCATIONAL_N_RATE='" + txtCth_S_Educational_N_Rate.Text + "',CTH_SAPTA_P_RATE='" + txtCth_SAPTA_P_Rate.Text + "',CTH_SAFEGUARD_S_RATE='" + txtCth_SafeGuard_S_Rate.Text + "',CTH_SAD_V_RATE='" + txtCth_SAD_V_Rate.Text + "',CTH_AGGREGATE_A_RATE='" + txtCth_Aggregate_A_Rate.Text + "',CTH_NCD_D_RATE='" + txtCth_NCD_D_Rate.Text + "',CTH_OTHER_O_RATE='" + txtCth_Other_O_Rate.Text + "',CTH_REMARKS='" + txtRemarks.Text + "',CTH_SAFEGUARD_RATE='" + "" + "',CTH_INFRA_CESS_RATE='" + txt_infra_cess.Text + "',CTH_SQC='" + txt_InfoUQC.Text + "',CTH_NCD_SPL_DUTY='" + txtCth_NCD_SplDuty.Text + "',CTH_NCD_SPL_UNIT='" + txtCth_NCD_SplUnit.Text + "',CTH_FLAG='" + ddl_CTH_FLAG.SelectedItem.Text + "',IS_VALID='" + ddlvalid.SelectedValue + "' where CTH_ID=" + ViewState["CTH_ID"] + " ");
            i = am.tbmanipulate("update CTH_MASTER set CTH_CODE='" + txtCth_Code.Text + "' ,CTH_DESCRIPTION='" + txtCth_Description.Text + "',CTH_RATE='" + txtCth_Rate.Text + "',CTH_SPL_AMT='" + txtCth_Spl_Amount.Text + "',CTH_SPL_UNIT='" + txtCth_Spl_Unit.Text + "',CTH_EDUCATIONAL_E_RATE='" + txtCth_Educational_E_Rate.Text + "',CTH_S_EDUCATIONAL_N_RATE='" + txtCth_S_Educational_N_Rate.Text + "',CTH_SAPTA_P_RATE='" + txtCth_SAPTA_P_Rate.Text + "',CTH_SAFEGUARD_S_RATE='" + txtCth_SafeGuard_S_Rate.Text + "',CTH_SAD_V_RATE='" + txtCth_SAD_V_Rate.Text + "',CTH_AGGREGATE_A_RATE='" + txtCth_Aggregate_A_Rate.Text + "',CTH_NCD_D_RATE='" + txtCth_NCD_D_Rate.Text + "',CTH_OTHER_O_RATE='" + txtCth_Other_O_Rate.Text + "',CTH_REMARKS='" + txtRemarks.Text + "',CTH_SAFEGUARD_RATE='" + "" + "',CTH_INFRA_CESS_RATE='" + txt_infra_cess.Text + "',CTH_SQC='" + txt_InfoUQC.Text + "',CTH_NCD_SPL_DUTY='" + txtCth_NCD_SplDuty.Text + "',CTH_NCD_SPL_UNIT='" + txtCth_NCD_SplUnit.Text + "',CTH_FLAG='" + ddl_CTH_FLAG.SelectedItem.Text + "',IS_VALID='" + ddlvalid.SelectedValue + "',MODIFIED_BY='" + Connection.Current_User() + "',MODIFIED_ON='" + DateTime.Now + "',ACTION='" + "U" + "' where CTH_ID=" + ViewState["CTH_ID"] + " ");


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
        Main_Grid.Visible = true;
       // innerbox_MidMain_Grid_Admin_catagory.Visible = true;
        SearchTemplate.Visible = true;
        spanDownloadTemplate.Visible = false;
        int pageno = 1;
        gridbind(pageno);
        //int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
        //dd_Pageno(ii);
      
    }

    public void gridbind(int currentPageNumber1)
    {
        Admin_mas.Ecth_id = "0";
        Admin_mas.Ecth_code = txtCth_Code_Search.Text;
        Admin_mas.Ecth_description = txtCth_Description_Search.Text;

        Admin_mas.Ename = "select_con";

        Admin_mas.startRowIndex = Convert.ToString(currentPageNumber1);
        Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
        //ds = erm.RetrieveAll_Adcode_MASTER();
        gvdetails.EmptyDataText = "No Record Found";

        DataSet ds = Admin_mas.RetrieveAll_CTH_master();

        gvdetails.DataSource = ds;
        gvdetails.DataBind();
        //  Store the first DataTable in session for Excel export
        if (ds != null && ds.Tables.Count > 0)
        {
            Session["ExportData"] = ds.Tables[1];
        }

        //gvdetails.DataSource = Admin_mas.RetrieveAll_CTH_master();

        //gvdetails.DataBind();

        Grid_Total(currentPageNumber1, Admin_mas.Total_Rows);
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


    public void Edit_CthDetails()
    {
        if (ViewState["CTH_ID"] != "" && ViewState["CTH_ID"] != null)
        {
            int i = 0;
            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            CTH_ID = ViewState["CTH_ID"].ToString();
            Admin_mas.Ecth_id = CTH_ID;
            Admin_mas.Ecth_code = "0";
            Admin_mas.Ecth_description = "0";
            Admin_mas.Ename = "select_conwithcode";


            dtuser = Admin_mas.RetrieveAll_CTH_master();
            if (dtuser.Tables[0].Rows.Count > 0)
            {
                txtCth_Code.Text = dtuser.Tables[0].Rows[0]["CTH_CODE"].ToString();
                txtCth_Code.Enabled = false;

                txtCth_Description.Text = dtuser.Tables[0].Rows[0]["CTH_DESCRIPTION"].ToString();

                txtCth_Rate.Text = dtuser.Tables[0].Rows[0]["CTH_RATE"].ToString();
                txtCth_Spl_Amount.Text = dtuser.Tables[0].Rows[0]["CTH_SPL_AMT"].ToString();
                txtCth_Spl_Unit.Text = dtuser.Tables[0].Rows[0]["CTH_SPL_UNIT"].ToString();
                txtCth_Educational_E_Rate.Text = dtuser.Tables[0].Rows[0]["CTH_EDUCATIONAL_E_RATE"].ToString();
                txtCth_S_Educational_N_Rate.Text = dtuser.Tables[0].Rows[0]["CTH_S_EDUCATIONAL_N_RATE"].ToString();
                txtCth_SAPTA_P_Rate.Text = dtuser.Tables[0].Rows[0]["CTH_SAPTA_P_RATE"].ToString();
                txtCth_SafeGuard_S_Rate.Text = dtuser.Tables[0].Rows[0]["CTH_SAFEGUARD_S_RATE"].ToString();

                txtCth_SAD_V_Rate.Text = dtuser.Tables[0].Rows[0]["CTH_SAD_V_RATE"].ToString();

                txtCth_Aggregate_A_Rate.Text = dtuser.Tables[0].Rows[0]["CTH_AGGREGATE_A_RATE"].ToString();
                txtCth_NCD_D_Rate.Text = dtuser.Tables[0].Rows[0]["CTH_NCD_D_RATE"].ToString();
                txtCth_Other_O_Rate.Text = dtuser.Tables[0].Rows[0]["CTH_OTHER_O_RATE"].ToString();
                txtRemarks.Text = dtuser.Tables[0].Rows[0]["CTH_REMARKS"].ToString();
                txt_infra_cess.Text = dtuser.Tables[0].Rows[0]["CTH_INFRA_CESS_RATE"].ToString();
                txt_InfoUQC.Text = dtuser.Tables[0].Rows[0]["CTH_SQC"].ToString();

                txtCth_NCD_SplDuty.Text = dtuser.Tables[0].Rows[0]["CTH_NCD_SPL_DUTY"].ToString();
                txtCth_NCD_SplUnit.Text = dtuser.Tables[0].Rows[0]["CTH_NCD_SPL_UNIT"].ToString();
                ddl_CTH_FLAG.SelectedValue = dtuser.Tables[0].Rows[0]["CTH_FLAG"].ToString();
                ddlvalid.SelectedValue = dtuser.Tables[0].Rows[0]["IS_VALID"].ToString();
            }
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
        ViewState["CTH_ID"] = Convert.ToString(this.gvdetails.SelectedDataKey.Value);

        Edit_CthDetails();
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
        txtCth_Code.Enabled = true;
        mo.ResetFields(Page.Controls);
        // lblMsg.Text = "";
        txtCth_Code.Focus();
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnSave.Visible = true;
    }

   
    protected void lnkExport_Click(object sender, EventArgs e)
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

    private void ExportUsingClosedXML(DataTable dt)
    {
        using (XLWorkbook wb = new XLWorkbook())
        {
            var ws = wb.Worksheets.Add(dt, "CTH_Master");

            // Bold header + fit columns
            ws.Row(1).Style.Font.Bold = true;
            ws.Columns().AdjustToContents();

            using (MemoryStream stream = new MemoryStream())
            {
                wb.SaveAs(stream);
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment; filename=CTH_SearchResult.xlsx");
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.BinaryWrite(stream.ToArray());
                Response.Flush();
                Response.End();
            }
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
                                            HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + 
                                            HttpContext.Current.Session["currentbranch"].ToString() + "/" +
                                            HttpContext.Current.Session["currentuser"].ToString() + "/IMPORT_CTH_MASTER_EXCEL");
            
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>ShowAlert('" + res + "')</script>", false);
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("SLNO");
                dt.Columns.Add("CTH_CODE");
                dt.Columns.Add("ERROR_DESCRIPTION");
                dt.Columns.Add("FIELD_Name");
                int Count = 1;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    if (!Regex.IsMatch(dr["CTH_CODE"].ToString(), @"^\d{8}$") || string.IsNullOrEmpty(dr["CTH_CODE"].ToString()))
                    {
                        DataRow newdr = dt.NewRow();
                        newdr["ERROR_DESCRIPTION"] = "MANDATORY 8 DIGITS CTH_CODE";
                        newdr["CTH_CODE"] = dr["CTH_CODE"].ToString();
                        newdr["FIELD_Name"] = "CTH_CODE";
                        newdr["SLNO"] = Count;
                        dt.Rows.Add(newdr);
                    }
                    if (!Regex.IsMatch(dr["CTH_RATE"].ToString(), @"^\d+(\.\d+)?$") || string.IsNullOrEmpty(dr["CTH_RATE"].ToString()))
                    {
                        DataRow newdr = dt.NewRow();
                        newdr["ERROR_DESCRIPTION"] = "INVALID CTH_RATE";
                        newdr["CTH_CODE"] = dr["CTH_CODE"].ToString();
                        newdr["FIELD_Name"] = "CTH_RATE";
                        newdr["SLNO"] = Count;
                        dt.Rows.Add(newdr);
                        
                    }
                   
                    if (!Regex.IsMatch(dr["IS_VALID"].ToString(), @"^(Y|N)$") && !string.IsNullOrEmpty(dr["IS_VALID"].ToString()))
                    {
                        DataRow newdr = dt.NewRow();
                        newdr["ERROR_DESCRIPTION"] = "INVALID DATA";
                        newdr["CTH_CODE"] = dr["CTH_CODE"].ToString();
                        newdr["FIELD_Name"] = "IS_VALID";
                        newdr["SLNO"] = Count;
                        dt.Rows.Add(newdr);

                    }
                 
                   
                    Count++;
                }
                if (dt.Rows.Count <= 0)
                {

                    DataRow newdr = dt.NewRow();
                    newdr["SLNO"] = 0;
                    dt.Rows.Add(newdr);
                }
                if (dt.Rows[0][0].ToString() != "0")
                {
                    Main_Grid.Visible = false;
                    gv_Preview.DataSource = dt;
                    gv_Preview.DataBind();
                    Label12.Text = "CTH Master Excel Invalid Errors";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>Excel_File_Validation()</script>", false);
                    gridbind(1);

                }
                else
                {
                    Admin_mas.USER_ID = USER_ID;
                    Admin_mas.Priority_Type = ddl_Priority.SelectedValue.ToString();
                    Admin_mas.Qf_xml = DataTableToXml(ds);

                    ds =Admin_mas.BulkInsert_CTH_Record();
                    if (ds.Tables[0].Rows[0][0].ToString() == "Keep and Insert Records SuccessFully!" || ds.Tables[0].Rows[0][0].ToString() == "Updated And Insert Records Successfully" || ds.Tables[0].Rows[0][0].ToString() == "Delete And Insert Records Successfully" || ds.Tables[0].Rows[0][0].ToString() == "Deleted Selected datas and save new data successFully"
                    || ds.Tables[0].Rows[0][0].ToString() == "Updated your records successFully" || ds.Tables[0].Rows[0][0].ToString() == "Check The Duplicate Records" || ds.Tables[0].Rows[0][0].ToString() == "New Records Inserted Successfully")
                    {
                        res = ds.Tables[0].Rows[0][0].ToString();
                        Alert_msg(res);
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>ShowAlert('" + res + "')</script>", false);
                        mo.ResetFields(Page.Controls);
                        gridbind(1);
                    }
                    else
                    {
                        ds.Tables[0].Columns.Add("SLNO", typeof(int));
                        ds.Tables[0].Columns["SLNO"].SetOrdinal(0);
                        int slno = 1;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            row["SlNo"] = slno;
                            slno++;
                        }
                        gv_Preview.DataSource = ds.Tables[0];
                        gv_Preview.DataBind();
                        Label12.Text = "CTH Master Excel Already Exist Records";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>Excel_File_Validation()</script>", false);
                          
                        gridbind(1);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            res = ex.Message;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>ShowAlert('" + ex.Message.ToString() + "')</script>", false);
        }
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'CTH MASTER DETAILS', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    private DataSet ReadExcelFileToDataTable(string filePath)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add();
        //DataTable dt = new DataTable();
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
                    string values = "Please Fill CTH-CODE Column in your Excel";

                    ds.Tables[0].Rows.Add(values);
                    return ds;
                }
                else
                {
                    ds.Tables[0].Rows.Add(dataRow);
                }

            }
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