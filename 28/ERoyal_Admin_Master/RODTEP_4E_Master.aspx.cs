using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;
using ClosedXML.Excel;
using System.IO;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

public partial class RODTEP_Master : ThemeClass
{
    public int currentPageNumber, rowIndex, i, Total_Rows;
    public double totalRows;
    public const int PAGESIZE = 15;
    public string AUTO_ID, RODTEP_ID = "", RODTEP_RATE;

    SqlConnection con;
    SqlCommand cmd;

    adminmaster Admin_mas = new adminmaster();

    DataSet dtuser = new DataSet();
    DataTable dt = new DataTable();

    Manipulation mo = new Manipulation();
    AdminManipulation am = new AdminManipulation();
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();

            txtRODTEPTARSearch.Focus();

            Div_Pagination.Visible = false;
            NewRODTEPTemplate.Visible = true;
            GridDownloadTemplate.Visible = false;

            if (!IsPostBack)
            {
                Edit_RODTEP_Details();

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
            if (txtRODTEPTAR.Text != "")
            {

                Admin_mas.ERODTEP_id = "0";
                Admin_mas.ERODTEP_TARIFF = txtRODTEPTAR.Text;
                Admin_mas.ERODTEP_DESC = "0";
                Admin_mas.Ename = "autoid_4RE";

                dtuser = Admin_mas.RetrieveAll_RODTEP_master();
                string ii = Convert.ToString(Admin_mas.result);
                if (ii == "1")
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('RODTEP TARIFF Already Exist')</script>", false);
                    Alert_msg("RODTEP TARIFF Already Exist");
                }
                else
                {

                    if (dtuser.Tables[0].Rows.Count > 0)
                    {
                        AUTO_ID = dtuser.Tables[0].Rows[0]["RODTEP_ID"].ToString();

                        if (AUTO_ID != "")
                        {
                            RODTEP_master_insert();
                        }
                        else
                        {
                            AUTO_ID = "1";
                            RODTEP_master_insert();

                        }

                    }
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
        }

    }


    public void clear()
    {
        try
        {
            txtRODTEPTAR.Text = " ";
            txtDesC.Text = " ";
            txtRODTEPRATE.Text = " ";
            txtRODTEPUQC.Text = " ";
            txtCAP.Text = " ";

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }

    public void RODTEP_master_insert()
    {
        try
        {
            i = am.tbmanipulate("INSERT INTO EXPORT_RODTEP_MASTER_4RE VALUES (" + AUTO_ID + ",'" + txtRODTEPTAR.Text.Trim() + "','" + txtDesC.Text.Trim() + "','" + txtRODTEPRATE.Text.Trim() + "','" + txtRODTEPUQC.Text.Trim() + "','" + txtCAP.Text.Trim() + "')");
            if (i > 0)
            {
                Alert_msg("Saved Successfully");

                int pageno = 1;
                gridbind(pageno);

            }
            else
            {
                Alert_msg("Record Not Saved");
            }
            clear();
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
            i = am.tbmanipulate("update EXPORT_RODTEP_MASTER_4RE  set RODTEP_TARIFF='" + txtRODTEPTAR.Text + "' ,RODTEP_DESC='" + txtDesC.Text + "',RODTEP_RATE='" + txtRODTEPRATE.Text + "',RODTEP_UQC='" + txtRODTEPUQC.Text + "',RODTEP_CAP='" + txtCAP.Text + "' where RODTEP_ID=" + ViewState["RODTEP_ID"] + " ");
            if (i > 0)
            {
                Alert_msg("Updated Successfully");

                btnNew.Focus();
            }
            else
            {
                Alert_msg("Record Not Saved");
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

            Admin_mas.ERODTEP_id = ViewState["RODTEP_ID"].ToString();
            Admin_mas.ERODTEP_TARIFF = "0";
            Admin_mas.ERODTEP_DESC = "0";
            Admin_mas.Ename = "delete_4RE";
            int pageno = 1;
            Admin_mas.startRowIndex = Convert.ToString(pageno);
            Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
            gvdetails.DataSource = Admin_mas.RetrieveAll_RODTEP_master();
            gvdetails.DataBind();

            Grid_Total(pageno, Admin_mas.Total_Rows);

            i = Admin_mas.result;
            if (i > 0)
            {

                mo.ResetFields(Page.Controls);

                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                txtRODTEPTAR.Focus();
                txtRODTEPTAR.Enabled = true;

                Alert_msg("Record Deleted");


            }
            else
            {

                Alert_msg("Record Not Deleted");

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
            txtRODTEPTAR.Focus();
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
            txtRODTEPTAR.Enabled = true;

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
            Main_GridView.Visible = true;
            NewRODTEPTemplate.Visible = false;
            GridDownloadTemplate.Visible = true;
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
            Admin_mas.ERODTEP_id = "0";
            Admin_mas.ERODTEP_TARIFF = txtRODTEPTARSearch.Text;
            Admin_mas.ERODTEP_DESC = txtDesCSearch.Text;
            Admin_mas.Ename = "select_con_4RE";
            Admin_mas.startRowIndex = Convert.ToString(currentPageNumber1);
            Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
            gvdetails.EmptyDataText = "No Record Found";
            DataSet ds = Admin_mas.RetrieveAll_RODTEP_master();

            gvdetails.DataSource = ds;
            gvdetails.DataBind();

            if (ds != null && ds.Tables.Count > 0)
            {
                Session["ExportData"] = ds.Tables[1];
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

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }


    public void Edit_RODTEP_Details()
    {
        try
        {
            if (ViewState["RODTEP_ID"] != "" && ViewState["RODTEP_ID"] != null)
            {
                int i = 0;
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                RODTEP_ID = ViewState["RODTEP_ID"].ToString();


                Admin_mas.ERODTEP_id = RODTEP_ID;
                Admin_mas.ERODTEP_TARIFF = "0";
                Admin_mas.ERODTEP_DESC = "0";
                Admin_mas.Ename = "select_conwithcode_4RE";


                dtuser = Admin_mas.RetrieveAll_RODTEP_master();
                if (dtuser.Tables[0].Rows.Count > 0)
                {
                    txtRODTEPTAR.Text = dtuser.Tables[0].Rows[0]["RODTEP_TARIFF"].ToString();
                    txtRODTEPTAR.Enabled = false;

                    txtDesC.Text = dtuser.Tables[0].Rows[0]["RODTEP_DESC"].ToString();

                    txtRODTEPRATE.Text = dtuser.Tables[0].Rows[0]["RODTEP_RATE"].ToString();
                    txtRODTEPUQC.Text = dtuser.Tables[0].Rows[0]["RODTEP_UQC"].ToString();
                    txtCAP.Text = dtuser.Tables[0].Rows[0]["RODTEP_CAP"].ToString();

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

            ViewState["RODTEP_ID"] = Convert.ToString(this.gvdetails.SelectedDataKey.Value);

            Edit_RODTEP_Details();
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


            txtRODTEPTAR.Focus();
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
            txtRODTEPTAR.Enabled = true;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }


    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'RODTEP 4E DETAILS', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
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
                var ws = wb.Worksheets.Add(dt, "RODTEP_4RE_Master");
                ws.Row(1).Style.Font.Bold = true;
                ws.Columns().AdjustToContents();

                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", "attachment; filename=RODTEP_4RE_Master.xlsx");
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
                "/EXPOERT_RODTEP_4RE_MASTER_EXCEL");

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
                dt.Columns.Add("RODTEP_TARIFF");
                dt.Columns.Add("ERROR_DESCRIPTION");
                dt.Columns.Add("FIELD_Name");
                int Count = 1;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (!Regex.IsMatch(dr["RODTEP_TARIFF"].ToString(), @"^\d{8}$") || string.IsNullOrEmpty(dr["RODTEP_TARIFF"].ToString()))
                    {
                        DataRow newdr = dt.NewRow();
                        newdr["ERROR_DESCRIPTION"] = "MANDATORY 8 DIGITS RODTEP_TARIFF";
                        newdr["RODTEP_TARIFF"] = dr["RODTEP_TARIFF"].ToString();
                        newdr["FIELD_Name"] = "RODTEP_TARIFF";
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
                    Label12.Text = "RODTEP Master Excel Invalid Errors";
                    Label12.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>Excel_File_Validation()</script>", false);
                }
                else
                {

                    Admin_mas.Update_Priority = ddl_Priority.SelectedValue.ToString();
                    Admin_mas.Xml_A = DataTableToXml(ds);

                    ds = Admin_mas.Export_RODEP_4E_Master_Bulk_Insert();
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
                        Label12.Text = "RODTEP Master Excel Already Exist Records";
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
                        string values = "Please Fill RODTEP CODE Column in your Excel";

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