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
public partial class ERoyal_Admin_Master_Supporting_Doc_Code_update : ThemeClass
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
    ErrorLogs er = new ErrorLogs();
    DropDownList ddl = new DropDownList();
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    public string DOC_ID = "";
    string SP_QUERY;
    //string datestring;
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
        //mainmastopusernametxt.InnerText = "Welcome Mr." + currentuser;
        Div_Pagination.Visible = false;
        txtDoc_CodeSearch.Focus();
        GridDownloadTemplate.Visible = false;
        USER_ID = Session["currentuser"].ToString(); 

        if (!IsPostBack)
        {
            Edit_DocumentDetails();
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            DataTable dt = new DataTable();
            gvdetails.EmptyDataText = "";
            gvdetails.DataSource = dt;
            gvdetails.DataBind();
            // int pageno = 1;
            // gridbind(pageno);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        string TEMP = txtDocCode.Text;

        try
        {
            if (txtDocCode.Text != "" && txtDocName.Text != "")
            {
                Admin_mas.EUnit_id = "0";
                Admin_mas.EUnit_code = txtDocCode.Text;
                Admin_mas.EUnit_name = txtDocName.Text;
                Admin_mas.EUnit_name = "0";
                Admin_mas.Ename = "autoid";
                dtuser = Admin_mas.RetrieveAll_SUPPROTING_DOCS_Master();
                string ii = Convert.ToString(Admin_mas.result);

                if (ii == "1")
                {
                    //lblMsg.Text = "Not Save, Country Code Already Exist";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Doc Code Already Exist')</script>", false);

                }
                else
                {

                    if (dtuser.Tables[0].Rows.Count > 0)
                    {
                        AUTO_ID = dtuser.Tables[0].Rows[0]["DOC_ID"].ToString();

                        if (AUTO_ID != "")
                        {
                            Document_Code_master_insert();
                        }
                        else
                        {
                            AUTO_ID = "1";
                            Document_Code_master_insert();

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

    public void Document_Code_master_insert()
    {
        //,PORT_COUNTRY_NAME,PORT_COUNTRY_CODE,PORT_CATEGORY,PORT_REMARKS
        //i = am.tbmanipulate("INSERT INTO SW_SUPPORTING_DOCS_CODE (DOC_ID,DOC_CODE,DOC_NAME,DOC_DESC) VALUES (" + AUTO_ID + ",'" + txtDocCode.Text + "','" + txtDocName.Text + "', '" + txtDocDescription.Text + "')");
        i = am.tbmanipulate("INSERT INTO SW_SUPPORTING_DOCS_CODE (DOC_CODE,DOC_NAME,DOC_DESC,DOC_LEVEL) VALUES ('" + txtDocCode.Text + "','" + txtDocName.Text + "', '" + txtDocDescription.Text + "', '" + ddl_DocLevel.SelectedValue + "')");

        if (i > 0)
        {
            //lblMsg.Text = " Successfully Saved";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);

            //mo.ResetFields(Page.Controls);
            int pageno = 1;
            gridbind(pageno);
            txtDocCode.Focus();

            //btnNew.Focus();
        }
        else
        {
            //lblMsg.Text = " Record Not Saved";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);

        }
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        mo.ResetFields(Page.Controls);
        //lblMsg.Text = "";
        txtDocCode.Focus();
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnSave.Visible = true;


    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {

            int i;
            //i = am.tbmanipulate("update PORT_MASTER set PORT_CODE_AIR='" + txtPortCodeAir.Text + "' ,PORT_CODE_SEA='" + txtPortCodeSea.Text + "',PORT_NAME='" + txtPortName.Text + "',PORT_COUNTRY_NAME='" + txtCountryName.Text + "',PORT_COUNTRY_CODE='" + txtCountryCode.Text + "',PORT_REMARKS='" + txtRemarks.Text + "' where PORT_ID=" + ViewState["Port_ID"] + " ");
            //i = am.tbmanipulate("update SW_SUPPORTING_DOCS_CODE set DOC_CODE='" + txtDocCode.Text + "' ,DOC_NAME='" + txtDocName.Text + "' ,DOC_DESC= '" + txtDocDescription.Text + "' where DOC_ID=" + ViewState["DOC_ID"] + " ");
            i = am.tbmanipulate("update SW_SUPPORTING_DOCS_CODE set DOC_CODE='" + txtDocCode.Text + "' ,DOC_NAME='" + txtDocName.Text + "' ,DOC_DESC= '" + txtDocDescription.Text +  "' ,DOC_LEVEL = '" + ddl_DocLevel.SelectedValue + "' where DOC_ID=" + ViewState["DOC_ID"] + " ");

            if (i > 0)
            {
                //lblMsg.Text = "Saved Successfully";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Updated Successfully')</script>", false);

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

            Admin_mas.EUnit_id = ViewState["DOC_ID"].ToString();
            Admin_mas.EUnit_code = "0";
            Admin_mas.Ename = "delete";

            int pageno = 1;
            Admin_mas.startRowIndex = Convert.ToString(pageno);
            Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
            gvdetails.DataSource = Admin_mas.RetrieveAll_SUPPROTING_DOCS_Master();
            gvdetails.DataBind();


            Grid_Total(pageno, Admin_mas.Total_Rows);


            i = Admin_mas.result;
            if (i > 0)
            {
                //lblMsg.Text = " Record Deleted";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Deleted')</script>", false);

                mo.ResetFields(Page.Controls);
         
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                txtDocCode.Focus();
                txtDocCode.Enabled = true;
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
   
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        NewSupDocTemplate.Visible = false;
        GridDownloadTemplate.Visible = true;
        Main_GridView.Visible = true;
        int pageno = 1;
        gridbind(pageno);
    }

    public void gridbind(int currentPageNumber1)
    
    {
        Admin_mas.EUnit_id = "0";
        Admin_mas.EUnit_code = txtDoc_CodeSearch.Text;
        Admin_mas.EUnit_name = txtDoc_NameSearch.Text;
        
        Admin_mas.Ename = "select_con";

        Admin_mas.startRowIndex = Convert.ToString(currentPageNumber1);
        Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
        //ds = erm.RetrieveAll_Adcode_MASTER();
        gvdetails.EmptyDataText = "No Record Found";

        DataSet ds = Admin_mas.RetrieveAll_SUPPROTING_DOCS_Master();
        gvdetails.DataSource = ds;
     //   gvdetails.DataSource = Admin_mas.RetrieveAll_SUPPROTING_DOCS_Master();
        gvdetails.DataBind();

        if (ds != null && ds.Tables.Count > 0)
        {
            Session["ExportData"] = ds.Tables[1];
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
       
    }

    public void Edit_DocumentDetails()
    {
        if (ViewState["DOC_ID"] != "" && ViewState["DOC_ID"] != null)
        {
            int i = 0;
            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;

            DOC_ID = ViewState["DOC_ID"].ToString();

            Admin_mas.EUnit_id = DOC_ID;
            Admin_mas.EUnit_code = "0";
            Admin_mas.EUnit_code = "0";
            Admin_mas.EUnit_name = "0";
            Admin_mas.Ename = "select_conwithcode";
            Admin_mas.startRowIndex = Convert.ToString("1");
            Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);

            dtuser = Admin_mas.RetrieveAll_SUPPROTING_DOCS_Master();
            if (dtuser.Tables[0].Rows.Count > 0)
            {
                txtDocCode.Text = dtuser.Tables[0].Rows[0]["DOC_CODE"].ToString();
                txtDocName.Text = dtuser.Tables[0].Rows[0]["DOC_NAME"].ToString();
                txtDocDescription.Text = dtuser.Tables[0].Rows[0]["DOC_DESC"].ToString();
                ddl_DocLevel.SelectedValue = dtuser.Tables[0].Rows[0]["DOC_LEVEL"].ToString();
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
            // e.Row.Attributes["onmouseout"] = "this.style.background='white'";
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gvdetails, "Select$" + e.Row.RowIndex.ToString()));

        }
    }

    protected void gvdetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["DOC_ID"] = Convert.ToString(this.gvdetails.SelectedDataKey.Value);
        Edit_DocumentDetails();
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
        mo.ResetFields(Page.Controls);
        //lblMsg.Text = "";

        txtDocCode.Focus();
        btnUpdate.Visible = false;
        btnDelete.Visible = false;// are you there?

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
            var ws = wb.Worksheets.Add(dt, "Sup_Doc_Master");
            ws.Row(1).Style.Font.Bold = true;
            ws.Columns().AdjustToContents();

            using (MemoryStream stream = new MemoryStream())
            {
                wb.SaveAs(stream);
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment; filename=Sup_Doc_Master.xlsx");
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
                HttpContext.Current.Session["COMPANY_ID"].ToString() +
                "/" + HttpContext.Current.Session["currentbranch"].ToString() +
                "/" + HttpContext.Current.Session["currentuser"].ToString() +
                "/SUP_DOC_MASTER_TEMPLATE");

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
                dt.Columns.Add("DOC_CODE");
                dt.Columns.Add("DOC_NAME");
                dt.Columns.Add("DOC_DESC");
                dt.Columns.Add("DOC_LEVEL");
                int Count = 1;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //if (!Regex.IsMatch(dr["CETH_CODE"].ToString(), @"^\d{8}$") || string.IsNullOrEmpty(dr["CETH_CODE"].ToString()))
                    //{
                    //    DataRow newdr = dt.NewRow();
                    //    newdr["ERROR_DESCRIPTION"] = "MANDATORY 8 DIGITS CTH_CODE";
                    //    newdr["CETH_CODE"] = dr["CETH_CODE"].ToString();
                    //    newdr["FIELD_Name"] = "CETH_CODE";
                    //    newdr["SLNO"] = Count;
                    //    dt.Rows.Add(newdr);
                    //}
                   

                    Count++;
                }

                if (dt.Rows.Count > 0)
                {
                    Main_GridView.Visible = false;
                    gv_Preview.DataSource = dt;
                    gv_Preview.DataBind();
                    Label12.Text = "Sup DOC Master Excel Invalid Errors";
                    Label12.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>Excel_File_Validation()</script>", false);
                }
                else
                {

                    Admin_mas.USER_ID = USER_ID;
                    Admin_mas.Update_Priority = ddl_Priority.SelectedValue.ToString();
                    Admin_mas.Xml_A = DataTableToXml(ds);

                    ds = Admin_mas.BulkInsert_Sup_Doc_Record();
                    if (ds.Tables[0].Rows[0][0].ToString().Contains("Updated And Insert New Records Successfully") || ds.Tables[0].Rows[0][0].ToString().Contains("Delete And Insert Records Successfully") || ds.Tables[0].Rows[0][0].ToString().Contains("New Records Inserted Successfully") || ds.Tables[0].Rows[0][0].ToString().Contains("Check The Duplicate Records"))
                    {
                        res = ds.Tables[0].Rows[0][0].ToString();
                        Alert_msg(res);
                        mo.ResetFields(Page.Controls);
                        gridbind(1);
                    }
                    else
                    {
                        gv_Preview.DataSource = ds.Tables[0];
                        gv_Preview.DataBind();
                        Label12.Text = "SUP DOC MASTER Excel Already Exist Records";
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
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'SUP DOC MASTER DETAILS', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    private DataSet ReadExcelFileToDataTable(string filePath)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add();
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
                    string values = "Please Fill DOC CODE Column in your Excel";

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