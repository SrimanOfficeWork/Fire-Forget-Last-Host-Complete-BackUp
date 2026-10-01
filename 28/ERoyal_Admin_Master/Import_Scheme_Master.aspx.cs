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
using System.IO;
using Microsoft.ApplicationBlocks.Data;
using ClosedXML.Excel;
using System.Globalization;

public partial class Import_Scheme_Master : ThemeClass
{
    public int currentPageNumber;
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
    public string NOTIFICATION_CUSTOMS_ID = "";
    ErrorLogs er = new ErrorLogs();
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        ddl_SchemeCode_Search.Focus();
        Div_Pagination.Visible = false;
        SchemeMasterExcel_download.Visible = false;
        NewSchemeMasterExcelTemplate.Visible = true;
        if (!IsPostBack)
        {
            //Edit_Notification_CustomsDetails();
            DataTable dt = new DataTable();
            gvdetails.EmptyDataText = "";
            gvdetails.DataSource = dt;
            gvdetails.DataBind();
            btnUpdate.Visible = false;
            btnDelete.Visible = false;

            Load_Dropdown();

        }
    }

    private void Load_Dropdown()
    {
        DataSet ds_bind = new DataSet();
        Admin_mas.SCHEME_IMPORT_ID = "0";
        Admin_mas.SCHEME_IMPORT_CODE = "";
        Admin_mas.SCHEME_IMPORT_NAME = "";
        Admin_mas.SCHEME_NOTN = "";

        Admin_mas.Ename = "Select_Schemecode";
        ds_bind = Admin_mas.RetrieveAll_Import_Scheme_master();

        if (ds_bind.Tables[0].Rows.Count > 0)
        {
            ddl_SchemeCode_Search.DataSource = ds_bind.Tables[0];
            ddl_SchemeCode_Search.DataTextField = "SCHEME_IMPORT_CODE";
            ddl_SchemeCode_Search.DataValueField = "SCHEME_IMPORT_CODE";
            ddl_SchemeCode_Search.DataBind();
            ddl_SchemeCode_Search.Items.Insert(0, "");
        }

        if (ds_bind.Tables[1].Rows.Count > 0)
        {
            ddl_SchemeName_Search.DataSource = ds_bind.Tables[1];
            ddl_SchemeName_Search.DataTextField = "SCHEME_IMPORT_NAME";
            ddl_SchemeName_Search.DataValueField = "SCHEME_IMPORT_NAME";
            ddl_SchemeName_Search.DataBind();
            ddl_SchemeName_Search.Items.Insert(0, "");

        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtSchemeCode.Text != "")
            {
                Admin_mas.SCHEME_IMPORT_ID = "0";

                Admin_mas.SCHEME_IMPORT_CODE = txtSchemeCode.Text;
                Admin_mas.SCHEME_IMPORT_NAME = txtSchemeName.Text;
                Admin_mas.SCHEME_NOTN = txtSchemeNotn.Text;
                Admin_mas.SCHEME_NOTN_SLNO = txtSchemeNotnSlno.Text;
                Admin_mas.SCHEME_RATE = txtSchemeRate.Text;
                Admin_mas.SCHEME_NOTN_DATE = txtSchemeDate.Text;
               // Admin_mas.SCHEME_AIDC_RATE = txt_AIDC_Tariff_Rate.Text;
                Admin_mas.Ename = "autoid";
                dtuser = Admin_mas.RetrieveAll_Import_Scheme_master();
                string ii = Convert.ToString(Admin_mas.result);

                if (ii == "1")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Scheme Notn Already Exist')</script>", false);
                }
                else
                {
                    if (dtuser.Tables[0].Rows.Count > 0)
                    {
                        AUTO_ID = dtuser.Tables[0].Rows[0]["SCHEME_IMPORT_ID"].ToString();

                        if (AUTO_ID != "")
                        {
                            Notification_customs_master_insert();
                        }
                        else
                        {
                            AUTO_ID = "1";
                            Notification_customs_master_insert();
                        }

                    }
                }
            }
            else
            {
                //lblMsg.Text = "Enter All Mandatory Field";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Enter All Mandatory Field')</script>", false);
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public void Notification_customs_master_insert()
    {

        if (txtSchemeDate.Text != "")
        {
            string[] sp = txtSchemeDate.Text.Split('/');
            txtSchemeDate.Text = sp[1] + "/" + sp[0] + "/" + sp[2];
        }
        else
        {
            txtSchemeDate.Text = "01/01/1900";
        }

        i = am.tbmanipulate("INSERT INTO SCHEME_IMPORT VALUES (" + AUTO_ID + ",'" + txtSchemeCode.Text + "','" + txtSchemeName.Text + "','" + txtSchemeNotn.Text + "','" + txtSchemeNotnSlno.Text + "','" + txtSchemeRate.Text + "','" + txtSchemeDate.Text + "','" + txt_AIDC_Tariff_Rate.Text + "')");


        if (i > 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);

            int pageno = 1;
            gridbind(pageno);//10-11-2022
            //mo.ResetFields(Page.Controls);
            txtSchemeCode.Focus();
            Load_Dropdown();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);
        }
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        txtSchemeCode.Enabled = true;
        txtSchemeName.Enabled = true;
        mo.ResetFields(Page.Controls);
        //lblMsg.Text = "";
        txtSchemeCode.Focus();
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnSave.Visible = true;
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            int i;

            Admin_mas.SCHEME_IMPORT_ID = ViewState["SCHEME_IMPORT_ID"].ToString();
            Admin_mas.SCHEME_IMPORT_CODE = "0";
            Admin_mas.SCHEME_IMPORT_NAME = "0";
            Admin_mas.Ename = "delete";
            
            int pageno = 1;
            Admin_mas.startRowIndex = Convert.ToString(pageno);
            Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
            gvdetails.DataSource = Admin_mas.RetrieveAll_Import_Scheme_master();
            gvdetails.DataBind();

            Grid_Total(pageno, Admin_mas.Total_Rows);
            i = Admin_mas.result;

            if (i > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Deleted')</script>", false);
                mo.ResetFields(Page.Controls);
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                txtSchemeCode.Focus();
                txtSchemeCode.Enabled = true;

                Load_Dropdown();
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
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            int i;
           
            //hide on 21-07-2026 for datetime conversion issue
            //i = am.tbmanipulate("update SCHEME_IMPORT set  SCHEME_IMPORT_CODE='" + txtSchemeCode.Text + "', SCHEME_IMPORT_NAME='" + txtSchemeName.Text + "' ,SCHEME_NOTN='" + txtSchemeNotn.Text + "' ,SCHEME_NOTN_SLNO='" + txtSchemeNotnSlno.Text + "' ,SCHEME_RATE='" + txtSchemeRate.Text + "' ,SCHEME_NOTN_DATE='" + DateTime.Parse(txtSchemeDate.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault) + "' ,SCHEME_AIDC_RATE='" + txt_AIDC_Tariff_Rate.Text + "' where SCHEME_IMPORT_ID=" + ViewState["SCHEME_IMPORT_ID"].ToString() + " ");
            DateTime schemeDate = DateTime.ParseExact(txtSchemeDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string sqlSafeDate = schemeDate.ToString("yyyyMMdd"); // '20260721' - unambiguous in SQL Server

            i = am.tbmanipulate("update SCHEME_IMPORT set  SCHEME_IMPORT_CODE='" + txtSchemeCode.Text + "', SCHEME_IMPORT_NAME='" + txtSchemeName.Text + "' ,SCHEME_NOTN='" + txtSchemeNotn.Text + "' ,SCHEME_NOTN_SLNO='" + txtSchemeNotnSlno.Text + "' ,SCHEME_RATE='" + txtSchemeRate.Text + "' ,SCHEME_NOTN_DATE='" + sqlSafeDate + "' ,SCHEME_AIDC_RATE='" + txt_AIDC_Tariff_Rate.Text + "' where SCHEME_IMPORT_ID=" + ViewState["SCHEME_IMPORT_ID"].ToString() + " ");
            if (i > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Updated Successfully')</script>", false);
                int pageno = 1;
                gridbind(pageno);
                //Clear();
                btnNew.Focus();
                Load_Dropdown();
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
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int pageno = 1;
        NewSchemeMasterExcelTemplate.Visible = false;
        SchemeMasterExcel_download.Visible = true;
        gridbind(pageno);
        //int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
        //dd_Pageno(ii);

    }

    public void gridbind(int currentPageNumber1)
    {
        Admin_mas.SCHEME_IMPORT_ID = "0";
        Admin_mas.SCHEME_IMPORT_CODE = ddl_SchemeCode_Search.SelectedValue;
        Admin_mas.SCHEME_IMPORT_NAME = ddl_SchemeName_Search.SelectedValue;
        Admin_mas.SCHEME_NOTN = txtSchemeNotn_Search.Text;


        Admin_mas.Ename = "select_con";
        Admin_mas.startRowIndex = Convert.ToString(currentPageNumber1);
        Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
        //ds = erm.RetrieveAll_Adcode_MASTER();
        gvdetails.EmptyDataText = "No Record Found";

        DataSet ds = Admin_mas.RetrieveAll_Import_Scheme_master();
        gvdetails.DataSource = ds;
        gvdetails.DataBind();
        if (ds.Tables[1].Rows.Count > 0)
        {
            Session["ExcelData"] = ds.Tables[1];
        }

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


    public void Edit_Notification_CustomsDetails()
    {
        if (ViewState["SCHEME_IMPORT_ID"] != "" && ViewState["SCHEME_IMPORT_ID"] != null)
        {
            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;


            NOTIFICATION_CUSTOMS_ID = ViewState["SCHEME_IMPORT_ID"].ToString();
            Admin_mas.SCHEME_IMPORT_ID = NOTIFICATION_CUSTOMS_ID;
            Admin_mas.SCHEME_IMPORT_CODE = "0";
            Admin_mas.SCHEME_IMPORT_NAME = "0";
            Admin_mas.Ename = "select_conwithcode";

            dtuser = Admin_mas.RetrieveAll_Import_Scheme_master();
            if (dtuser.Tables[0].Rows.Count > 0)
            {
                txtSchemeCode.Text = dtuser.Tables[0].Rows[0]["SCHEME_IMPORT_CODE"].ToString();
                txtSchemeCode.Enabled = false;
                txtSchemeName.Enabled = false;

                txtSchemeName.Text = dtuser.Tables[0].Rows[0]["SCHEME_IMPORT_NAME"].ToString();
                txtSchemeDate.Text = dtuser.Tables[0].Rows[0]["SCHEME_NOTN_DATE"].ToString();
                txtSchemeNotn.Text = dtuser.Tables[0].Rows[0]["SCHEME_NOTN"].ToString();
                txtSchemeNotnSlno.Text = dtuser.Tables[0].Rows[0]["SCHEME_NOTN_SLNO"].ToString();
                txtSchemeRate.Text = dtuser.Tables[0].Rows[0]["SCHEME_RATE"].ToString();
                txt_AIDC_Tariff_Rate.Text = dtuser.Tables[0].Rows[0]["SCHEME_AIDC_RATE"].ToString();

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

        ViewState["SCHEME_IMPORT_ID"] = Convert.ToString(this.gvdetails.SelectedDataKey.Value);

        Edit_Notification_CustomsDetails();
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
        txtSchemeNotn.Enabled = true;
        mo.ResetFields(Page.Controls);

        txtSchemeNotn.Focus();
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnSave.Visible = true;
    }
    protected void btnUploadClick_Click(object sender, EventArgs e)
    {

        string _res = string.Empty;
        try
        {
            string _priorityType = DropDownList1.SelectedValue.ToString();
            if (_priorityType == "-1")
            {
                AlertMessage("Please select Update Priority");
                return;
            }
            string fileName = FileUpload1.FileName;
            int _fileSize = FileUpload1.PostedFile.ContentLength;
            string _fileType = FileUpload1.PostedFile.ContentType;
            string baseFolderPath = Server.MapPath("~/Submission/" + HttpContext.Current.Session["COMPANY_ID"].ToString() +
                                                             "/" + HttpContext.Current.Session["currentbranch"].ToString() +
                                                             "/" + HttpContext.Current.Session["currentuser"].ToString() + "/IMPORT_SCHEME_MASTER");
            if (!Directory.Exists(baseFolderPath))
            {
                Directory.CreateDirectory(baseFolderPath);
            }
            else
            {
                string[] ExistingFiles = Directory.GetFiles(baseFolderPath);
                foreach (var _file in ExistingFiles)
                {
                    File.Delete(_file);
                }
            }
            string _SavePath = Path.Combine(baseFolderPath, fileName);
            FileUpload1.SaveAs(_SavePath);
            DataSet ds = SaveExcelFiletoTable(_SavePath);
            if (ds.Tables[0].Rows.Count <= 0)
            {
                AlertMessage("Empty Excel File not allowed");
                return;
            }

            Admin_mas.Update_Priority = _priorityType;
            Admin_mas.Xml_A = DataTableToXml(ds);
            ds = Admin_mas.Scheme_Import_Insert_Update();
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count <= 0)
            {
                AlertMessage("Empty Excel File not allowed");
                return;
            }
            string result = ds.Tables[0].Rows[0][0].ToString();
            if (result.Contains("Delete And Insert Records Successfully"))
            {
                int pageno = 1;
                gridbind(pageno);
                Load_Dropdown();
                AlertMessage(result);
            }
            else
            {
                AlertMessage("No record's were added");
            }

        }

        catch (Exception ex)
        {
            _res = ex.Message;
            AlertMessage(_res);
        }
    }

    public void AlertMessage(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Notification_Customs_Record DETAILS', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }


    public DataSet SaveExcelFiletoTable(string FilePath)
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ds.Tables.Add(dt);
        using (var workBook = new ClosedXML.Excel.XLWorkbook(FilePath))
        {
            var _workSheet = workBook.Worksheet(1);
            var hearderRow = _workSheet.Row(1);
            foreach (var cell in hearderRow.Cells())
            {
                string colName = cell.Value.ToString();
                if (!string.IsNullOrEmpty(colName))
                {
                    ds.Tables[0].Columns.Add(cell.Value.ToString().Trim());
                }
            }
            foreach (var row in _workSheet.RowsUsed().Skip(1))
            {
                DataRow dataRow = ds.Tables[0].NewRow();
                for (int col = 0; col < ds.Tables[0].Columns.Count; col++)
                {
                    dataRow[col] = row.Cell(col + 1).Value.ToString().Trim();
                }
                ds.Tables[0].Rows.Add(dataRow);
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

    protected void link_downloadExcel_Click(object sender, EventArgs e)
    {
        if (Session["ExcelData"] != null)
        {
            DataTable dt = Session["ExcelData"] as DataTable;
            ExportUsingClosedXML(dt);
        }
        else
        {
            AlertMessage("No data found to export");
        }
    }
    private void ExportUsingClosedXML(DataTable dt)
    {
        using (XLWorkbook wb = new XLWorkbook())
        {
            var ws = wb.Worksheets.Add(dt, "SCHEME_MASTER");
            ws.Row(1).Style.Font.Bold = true;
            ws.Columns().AdjustToContents();

            using (MemoryStream stream = new MemoryStream())
            {
                wb.SaveAs(stream);
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment; filename=Notification_Customs.xlsx");
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.BinaryWrite(stream.ToArray());
                Response.Flush();
                Response.End();
            }
        }
    }
}