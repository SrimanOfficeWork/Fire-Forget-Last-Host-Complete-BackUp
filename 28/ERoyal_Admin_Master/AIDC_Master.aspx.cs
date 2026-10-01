using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.OleDb;
using ClosedXML.Excel;
using System.Text.RegularExpressions;

public partial class AIDC_Master : ThemeClass
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 10;
    //public int pageno = 1;
    public int i, Total_Rows;
    adminmaster Admin_mas = new adminmaster();
    AppSession aps = new AppSession();
    Manipulation mo = new Manipulation();
    DataSet ds = new DataSet();
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    string FTA_NOTN;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();
            //gridbind(1);
            DownloadTemplate.Visible = false;
            NewDownloadTemplate.Visible = true;
            if (!IsPostBack)
            {
                Edit_AIDC();
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                DataTable dt = new DataTable();
                gvdetails.EmptyDataText = "";
                gvdetails.DataSource = dt;
                gvdetails.DataBind();
                ViewState["ID"] = "";
                // int pageno = 1;
                // gridbind(pageno);
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
            ds = AIDC_master_insert_select("insert");
            i = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            if (i > 0)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);

                mo.ResetFields(Page.Controls);
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
            DownloadTemplate.Visible = true;
            NewDownloadTemplate.Visible = false;
            Main_GridView.Visible = true;
            Admin_mas.ID = "";

            Admin_mas.AIDC_RITC_NO = txtAidcRitcSearach.Text;
            Admin_mas.AIDC_NOTN_NO = txtAidcNotnNoSearch.Text;


            Admin_mas.Ename = "select_con";



            Admin_mas.startRowIndex = Convert.ToString(currentPageNumber1);
            //Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
            Admin_mas.maximumRows = "";
            //ds = erm.RetrieveAll_Adcode_MASTER();
            gvdetails.EmptyDataText = "No Record Found";
            ds = Admin_mas.Aidc_master();
            gvdetails.DataSource = ds;


            gvdetails.DataBind();

            Session["ExportData"] = ds.Tables[0];


            ////Grid_Total(currentPageNumber1, Admin_mas.Total_Rows);


        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }
    //public void Add_Pageno(int p)
    //{
    //    if (p != 0)
    //    {
    //        ddlSelectPageno.Items.Clear();
    //        for (int i = 1; i <= p; i++)
    //        {

    //            ddlSelectPageno.Items.Add(Convert.ToString(i));
    //        }
    //    }
    //}

    //public void Grid_Total(int currentPageNumber1, double totalRows)
    //{
    //    if (gvdetails.Rows.Count > 0)
    //    {
    //        Div_Pagination.Visible = true;

    //    }
    //    else if (gvdetails.Rows.Count == 0)
    //    {
    //        Div_Pagination.Visible = false;

    //    }
    //    // get the total rows
    //    //totalRows = (double)Admin_mas.Total_Rows;

    //    //lblTotalPages.Text = CalculateTotalPages(totalRows).ToString();
    //    lblTotalPages.Text = Convert.ToString(totalRows);

    //    lblCurrentPage.Text = Convert.ToString(currentPageNumber1);

    //    int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));

    //    if (currentPageNumber1 == 1)
    //    {

    //        btnPrev.Visible = false;

    //        if (Int32.Parse(lblTotalPages.Text) > 0)
    //        {
    //            btnNext.Visible = true;
    //            btnLast.Visible = true;
    //        }
    //        else
    //        {
    //            btnNext.Visible = false;
    //            //btnLast.Visible = true;

    //        }

    //    }


    //    else if (Int32.Parse(lblCurrentPage.Text) == ii)
    //    {
    //        btnNext.Visible = false;
    //        //btnLast.Visible = false;
    //        btnPrev.Visible = true;

    //    }

    //    else
    //    {
    //        btnPrev.Visible = true;
    //        //btnLast.Visible = true;

    //        if (currentPageNumber == Int32.Parse(lblTotalPages.Text))
    //            btnNext.Visible = false;
    //        else btnNext.Visible = true;
    //    }
    //    if (ViewState["selected_change"] == "1")
    //    {
    //    }
    //    else
    //        Add_Pageno(ii);
    //}

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
    //protected void ChangePage(object sender, CommandEventArgs e)
    //{
    //    int currentpagenumber2 = 0;
    //    switch (e.CommandName)
    //    {
    //        case "Previous":
    //            currentpagenumber2 = Int32.Parse(lblCurrentPage.Text) - 1;

    //            break;

    //        case "Next":


    //            int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
    //            if (Int32.Parse(lblCurrentPage.Text) == ii)
    //                currentpagenumber2 = ii;
    //            else
    //                currentpagenumber2 = Int32.Parse(lblCurrentPage.Text) + 1;

    //            break;
    //        case "First":
    //            currentpagenumber2 = 1;

    //            break;
    //        case "Last":
    //            int i = CalculateTotalPages(double.Parse(lblTotalPages.Text));

    //            currentpagenumber2 = i;
    //            break;
    //    }

    //    gridbind(currentpagenumber2);
    //    //BindData(currentpagenumber2);
    //    //General_GridBind(currentpagenumber2);
    //}
    //protected void ddlSelectPageno_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlSelectPageno.SelectedValue != "")
    //    {
    //        ViewState["selected_change"] = "1";
    //        gridbind(Int32.Parse(ddlSelectPageno.SelectedValue.ToString()));

    //    }
    //}

    private DataSet AIDC_master_insert_select(string ename)
    {
        try
        {
            if (ViewState["ID"] != "" && ViewState["ID"] != null)
            {
                Admin_mas.AIDC_ID = ViewState["ID"].ToString();
            }
            Admin_mas.AIDC_RITC_NO = txtAidcRitcno.Text;
            Admin_mas.AIDC_NOTN_NO = txtAidcNotnNo.Text;
            Admin_mas.AIDC_NOTN_SLNO = txtAidcNotnSlno.Text;
            Admin_mas.AIDC_NOTN_RATE = txtAidcNotnRate.Text;
            Admin_mas.AIDC_DESCRIPTION = txtDescription.Text;
            Admin_mas.AIDC_FLAG = ddlflag.SelectedValue;

            Admin_mas.Ename = ename;
            ds = Admin_mas.Aidc_master();
           

            //if (i > 0)
            //{
            //    //lblMsg.Text = " Successfully Saved";
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);

            //    //mo.ResetFields(Page.Controls);
            //    int pageno = 1;
            //    //gridbind(pageno);
            //    //txtWarehouseCode.Focus();

            //    //btnNew.Focus();
            //}
            //else
            //{
            //    //lblMsg.Text = " Record Not Saved";
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);

            //}
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            int pageno = 1;
            Admin_mas.startRowIndex = Convert.ToString(pageno);
            Admin_mas.maximumRows = "";
            gvdetails.DataSource = AIDC_master_insert_select("delete");
            gvdetails.DataBind();
            //Grid_Total(pageno, Admin_mas.Total_Rows);
            i = Admin_mas.result;
            if (i > 0)
            {
                //lblMsg.Text = " Record Deleted";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Deleted')</script>", false);


                mo.ResetFields(Page.Controls);
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                txtAidcRitcno.Focus();
                txtAidcRitcno.Enabled = true;

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
                // e.Row.Attributes["onmouseout"] = "this.style.background='white'";
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


            Edit_AIDC();
            txtAidcRitcno.Focus();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
     
    }

    public void Edit_AIDC()
    {
        try
        {
            if (ViewState["ID"] != "" && ViewState["ID"] != null)
            {
                int i = 0;
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;


                Admin_mas.AIDC_ID = ViewState["ID"].ToString();

                //Admin_mas.FTA_NOTN = txtFtanotn.Text;


                Admin_mas.Ename = "select_conwithcode";
                Admin_mas.startRowIndex = Convert.ToString("1");
                Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);

                ds = Admin_mas.Aidc_master();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtAidcRitcno.Text = ds.Tables[0].Rows[0]["AIDC_RITC_NO"].ToString();

                    txtAidcNotnNo.Text = ds.Tables[0].Rows[0]["AIDC_NOTN_NO"].ToString();

                    txtAidcNotnSlno.Text = ds.Tables[0].Rows[0]["AIDC_NOTN_SLNO"].ToString();
                    txtAidcNotnRate.Text = ds.Tables[0].Rows[0]["AIDC_NOTN_RATE"].ToString();
                    txtDescription.Text = ds.Tables[0].Rows[0]["AIDC_DESCRIPTION"].ToString();
                    ddlflag.SelectedValue = ds.Tables[0].Rows[0]["AIDC_FLAG"].ToString();

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
    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            mo.ResetFields(Page.Controls);
            //lblMsg.Text = "";
            txtAidcRitcno.Focus();
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
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
            ds = AIDC_master_insert_select("update");
            i = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            if (i > 0)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Updated Successfully')</script>", false);
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                mo.ResetFields(Page.Controls);
                int pageno = 1;
                gridbind(pageno);

            }
            else
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Updated')</script>", false);

            }
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
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            mo.ResetFields(Page.Controls);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
      
    }
    protected void btnCance_Click(object sender, EventArgs e)
    {
        try
        {
            mo.ResetFields(Page.Controls);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
     
    }

    protected void lnkImport_Click(object sender, EventArgs e)
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
                var ws = wb.Worksheets.Add(dt, "AIDC_Master");
                ws.Row(1).Style.Font.Bold = true;
                ws.Columns().AdjustToContents();

                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", "attachment; filename=AIDC_Master.xlsx");
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


    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'AIDC DETAILS', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
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
                "/Import_AIDC_MASTER_EXCEL");

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
                dt.Columns.Add("AIDC_RITC_NO");
                dt.Columns.Add("ERROR_DESCRIPTION");
                dt.Columns.Add("FIELD_Name");
                int Count = 1;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
               
                    if (string.IsNullOrEmpty(dr["AIDC_NOTN_NO"].ToString()))
                    {
                        DataRow newdr = dt.NewRow();
                        newdr["ERROR_DESCRIPTION"] = "AIDC_NOTN_NO is mandatory";
                        newdr["AIDC_RITC_NO"] = dr["AIDC_RITC_NO"].ToString();
                        newdr["FIELD_Name"] = "AIDC_NOTN_NO";
                        newdr["SLNO"] = Count;
                        dt.Rows.Add(newdr);
                    }

                    if (string.IsNullOrEmpty(dr["AIDC_NOTN_SLNO"].ToString()))
                    {
                        DataRow newdr = dt.NewRow();
                        newdr["ERROR_DESCRIPTION"] = "AIDC_NOTN_SLNO is mandatory";
                        newdr["AIDC_RITC_NO"] = dr["AIDC_RITC_NO"].ToString();
                        newdr["FIELD_Name"] = "AIDC_NOTN_SLNO";
                        newdr["SLNO"] = Count;
                        dt.Rows.Add(newdr);
                    }

                    if (string.IsNullOrEmpty(dr["AIDC_NOTN_RATE"].ToString()))
                    {
                        DataRow newdr = dt.NewRow();
                        newdr["ERROR_DESCRIPTION"] = "AIDC_NOTN_RATE is mandatory";
                        newdr["AIDC_RITC_NO"] = dr["AIDC_RITC_NO"].ToString();
                        newdr["FIELD_Name"] = "AIDC_NOTN_RATE";
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
                    Label12.Text = "AIDC Master Excel Invalid Errors";
                    Label12.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>Excel_File_Validation()</script>", false);
                }
                else
                {

                    Admin_mas.Update_Priority = ddl_Priority.SelectedValue.ToString();
                    Admin_mas.Xml_A = DataTableToXml(ds);

                    ds = Admin_mas.Import_AIDC_Master_Bulk_Insert();
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
                        Label12.Text = "AIDC Master Excel Already Exist Records";
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
                    //if (dataRow.ItemArray[0] == "")
                    //{
                    //    string values = "Please Fill AIDC_RITC_NO Column in your Excel";

                    //    ds.Tables[0].Rows.Add(values);
                    //    return ds;
                    //}
                    //else
                    //{
                    //    ds.Tables[0].Rows.Add(dataRow);
                    //}
                    ds.Tables[0].Rows.Add(dataRow);

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
            e.Row.BackColor = System.Drawing.Color.White;

        }

    }

}