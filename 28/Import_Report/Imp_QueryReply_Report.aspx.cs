using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using System.Net;
using System.Xml;
using System.Data.SqlClient;
using ClosedXML.Excel;


public partial class DSR_Template_Import_Dynamicreport : System.Web.UI.Page
{
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;

    public string SELECT_TYPE, SELECT_BRANCH;

    AppSession aps = new AppSession();
    Dynamic_Report_GroupNew DRT = new Dynamic_Report_GroupNew();
    Company_Master Comp = new Company_Master();
    CustomDuty_Rpt CDR = new CustomDuty_Rpt();
    string errorFolder = "", csv = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();

        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

        SELECT_BRANCH = Connection.Get_Company_Type();       

        if (!IsPostBack)
        {
            jobload();
            
        }
    }

    private void jobload()
    {

        DataSet ds = new DataSet();

        CDR.flag = "Bind_JOBNO";
        CDR.BRANCH_CODE = SELECT_BRANCH;

        ds = CDR.Report_data();

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlJobNo.DataSource = ds.Tables[0];
            ddlJobNo.DataValueField = "JOBNO";
            ddlJobNo.DataTextField = "JOBNO";
            ddlJobNo.DataBind();

            ddlJobNo.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddlJobNo.SelectedIndex = 0;
        }
        else
        {
            ddlJobNo.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddlJobNo.SelectedIndex = 0;
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Imp_QueryReply_Rpt();      
    }

    private void Imp_QueryReply_Rpt()
    {

        if (!string.IsNullOrEmpty(txtFrom_Date.Text) && string.IsNullOrEmpty(txtTo_Date.Text))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "<script language='javascript'>alert('Please provide both FromDate and ToDate!')</script>", false);
        }

        if (string.IsNullOrEmpty(txtFrom_Date.Text) && !string.IsNullOrEmpty(txtTo_Date.Text))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "<script language='javascript'>alert('Please provide both FromDate and ToDate!')</script>", false);
        }
        if (string.IsNullOrEmpty(ddlJobNo.SelectedItem.Text) && string.IsNullOrEmpty(txtFrom_Date.Text) && string.IsNullOrEmpty(txtTo_Date.Text))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "<script language='javascript'>alert('Please provide either JobNo OR both FromDate and ToDate!')</script>", false);
        }


        DataSet ds = new DataSet();
        string query = @"DECLARE @GROUP_ID INT;
        SET @GROUP_ID = CASE WHEN ISNULL(@BRANCH_CODE, '') <> '' THEN (SELECT TOP 1 GROUP_ID FROM TBL_GROUPMASTER WHERE BRANCHCODE = @BRANCH_CODE) ELSE 1  END;
        
        SELECT ROW_NUMBER() OVER (ORDER BY DATE_TIME ASC, ID ASC) AS [S.NO],JOBNO, QUERY_NO AS 'QUERY NO', QUERY_DESC AS 'QUERY DESCRIPTION', USER_ID AS 'USER', DATE_TIME AS 'DATETIME'
        FROM IMPORT_QUERY_REPLY WHERE BRANCH_CODE IN (SELECT BRANCHCODE FROM TBL_GROUPMASTER WHERE GROUP_ID = @GROUP_ID)
          AND (@JOBNO IS NULL OR @JOBNO = '' OR JOBNO = @JOBNO)  AND (@FromDate IS NULL OR DATE_TIME >= @FromDate)  AND (@ToDate IS NULL OR DATE_TIME < DATEADD(DAY, 1, @ToDate)); ";

        using (SqlConnection conn = new SqlConnection(HttpContext.Current.Session["currentcomp_db"].ToString()))
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Strings: AddWithValue is fine
                cmd.Parameters.AddWithValue("@BRANCH_CODE", string.IsNullOrEmpty(currentbranch) ? (object)DBNull.Value : currentbranch);
                cmd.Parameters.AddWithValue("@JOBNO", string.IsNullOrEmpty(ddlJobNo.SelectedItem.Text) ? (object)DBNull.Value : ddlJobNo.SelectedItem.Text);

                // Dates: safer with explicit type
                if (string.IsNullOrEmpty(txtFrom_Date.Text))
                    cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = DateTime.Parse(txtFrom_Date.Text);

                if (string.IsNullOrEmpty(txtTo_Date.Text))
                    cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = DateTime.Parse(txtTo_Date.Text);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds);
                }
            }
        }

        if (ds.Tables[0].Rows.Count > 0)
        {

            ViewState["Excel"] = ds.Tables[0];
            GvReport.DataSource = ds.Tables[0];
            GvReport.DataBind();
            lbl_count.Text = "Row Count : " + Convert.ToString(ds.Tables[0].Rows.Count);
            lbl_cols_count.Text = "Column Count : " + Convert.ToString(ds.Tables[0].Columns.Count);

        }
        else
        {
            DataTable dt_empty = new DataTable();
            GvReport.DataSource = dt_empty;
            GvReport.DataBind();
            lbl_count.Text = "Row Count : 0";
            lbl_cols_count.Text = "Column Count : 0";

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "<script language='javascript'>alert('No data found!')</script>", false);
        }
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Import - Custom Duty Report ', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void btnexcel_Click(object sender, EventArgs e)
    {
        exportfile();       
    }

    private void exportfile()
    {
        if (GvReport.Rows.Count > 0)
        {
            DataSet ds = new DataSet();            
            DataTable dt = ViewState["Excel"] as DataTable;

            if (dt != null && dt.Rows.Count > 0)
            {
                ds.Tables.Add(dt);   
                DownloadExel(ds);   
            }
            else
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('No Records Found', 'Import - Query Report Report ', function (r) {});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            }
        }
        else
        {
            string prompt = "<script>$(document).ready(function(){{jAlert('No Records Found', 'Import - Query Report Report ', function (r) {});}});</script>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
        }
    }

    public void DownloadExel(DataSet dsExcelData)
    {
        #region single sheet excel download

        ThemeClass th = new ThemeClass();
        HttpResponse Response = HttpContext.Current.Response;
        BMW_Excel BMW = new BMW_Excel();

        if (dsExcelData != null && dsExcelData.Tables.Count > 0 && dsExcelData.Tables[0].Rows.Count > 0)
        {
            string s = DateTime.Now.ToString("yyyyMMdd");
            string strrptNametime = "ImpQueryReplyRpt_" + s;

            byte[] excelBytes = null;
            using (XLWorkbook wb = new XLWorkbook())
            {
                // Pick the first table (or whichever you want)
                DataTable table = dsExcelData.Tables[0];

                // Instead of dynamic naming, use a fixed sheet name
                string sheetLabel = "ImpQueryReply";

                DataTable textTable = ConvertAllColumnsToText(table);
                IXLWorksheet worksheet = wb.AddWorksheet(sheetLabel);

                // Force all columns to Text format
                for (int colIndex = 1; colIndex <= textTable.Columns.Count; colIndex++)
                {
                    worksheet.Column(colIndex).Style.NumberFormat.SetFormat("@");
                }

                // Insert data
                InsertDataAsText(worksheet, textTable);

                // Remove borders
                worksheet.Style.Border.SetTopBorder(XLBorderStyleValues.None);
                worksheet.Style.Border.SetLeftBorder(XLBorderStyleValues.None);
                worksheet.Style.Border.SetRightBorder(XLBorderStyleValues.None);
                worksheet.Style.Border.SetBottomBorder(XLBorderStyleValues.None);

                using (MemoryStream ms = new MemoryStream())
                {
                    wb.SaveAs(ms);
                    excelBytes = ms.ToArray();
                }
            }

            Response.Clear();
            Response.ClearHeaders();
            Response.ClearContent();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=" + strrptNametime + ".xlsx");
            Response.AddHeader("content-length", excelBytes.Length.ToString());
            Response.BinaryWrite(excelBytes);
            Response.Flush();
            HttpContext.Current.ApplicationInstance.Response.End();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "<script language='javascript'>alert('Data not found!')</script>", false);
        }

        #endregion
    }

    private void InsertDataAsText(IXLWorksheet worksheet, DataTable textTable)
    {
        int totalCols = textTable.Columns.Count;
        int totalRows = textTable.Rows.Count;

        // ── Pre-format entire range as text BEFORE writing values ────────────────
        IXLRange fullRange = worksheet.Range(1, 1, totalRows + 1, totalCols);
        fullRange.Style.NumberFormat.Format = "@";

        // ── Write header row ──────────────────────────────────────────────────────
        for (int col = 0; col < totalCols; col++)
        {
            var cell = worksheet.Cell(1, col + 1);
            cell.Value = textTable.Columns[col].ColumnName;

            // ── Blue header styling ───────────────────────────────────────────────
            cell.Style.Font.Bold = true;
            cell.Style.Font.FontColor = XLColor.White;
            cell.Style.Fill.BackgroundColor = XLColor.FromArgb(68, 114, 196); // Excel blue
            cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            //cell.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            cell.Style.Border.BottomBorderColor = XLColor.White;
        }

        // ── Write data rows ───────────────────────────────────────────────────────
        for (int row = 0; row < totalRows; row++)
        {
            for (int col = 0; col < totalCols; col++)
            {
                var cell = worksheet.Cell(row + 2, col + 1);
                cell.Value = textTable.Rows[row][col].ToString();

                //// ── Alternate row color for readability ───────────────────────────
                //if (row % 2 == 0)
                //{
                //    cell.Style.Fill.BackgroundColor = XLColor.FromArgb(221, 235, 247); // light blue
                //}
            }
        }

        // ── Auto-fit columns ──────────────────────────────────────────────────────
        worksheet.Columns().AdjustToContents();
    }

    private DataTable ConvertAllColumnsToText(DataTable source)
    {
        DataTable textTable = new DataTable(source.TableName);

        foreach (DataColumn col in source.Columns)
            textTable.Columns.Add(col.ColumnName, typeof(string));

        foreach (DataRow sourceRow in source.Rows)
        {
            DataRow newRow = textTable.NewRow();
            foreach (DataColumn col in source.Columns)
            {
                newRow[col.ColumnName] = sourceRow[col] == DBNull.Value
                    ? string.Empty : sourceRow[col].ToString();
            }
            textTable.Rows.Add(newRow);
        }
        return textTable;
    }

    protected void GvReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                //e.Row.Cells[i].Attributes.Add("style", "white-space:nowrap;");
                //e.Row.Cells[i + 1].Text = e.Row.Cells[i + 1].Text + "  ";
            }
        }
    }

    protected void GvReport_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.Header)
        //    e.Row.CssClass = "header";
        //if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
        //    e.Row.CssClass = "normal";
        //if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
        //    e.Row.CssClass = "alternate";
    }

    

    

}