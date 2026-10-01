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

public partial class ERoyal_Admin_Master_Drawback : ThemeClass
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 10;
    public int i, Total_Rows;
    public string AUTO_ID;
    adminmaster Admin_mas = new adminmaster();

    DataSet dtuser = new DataSet();

    SqlConnection con;
    public int rowIndex;
    SqlCommand cmd;
    Manipulation mo = new Manipulation();
    AdminManipulation am = new AdminManipulation();
    AppSession aps = new AppSession();
    public string DRAWBACK_ID = "";
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
            txtDrawbacknoSearch.Focus();
            DateTime dat = System.DateTime.Now;
            datestring = string.Format("{0:dd/MM/yyyy}", dat);

            txtNotnDate.Text = datestring;
            //mainmastopusernametxt.InnerText = "Welcome Mr." + currentuser;
            Div_Pagination.Visible = false;

            NewDrawbackTemplate.Visible = true;
            GridDownloadTemplate.Visible = false;

            if (!IsPostBack)
            {

                Edit_ExchangeDetails();
                DataTable dt = new DataTable();
                gvdetails.EmptyDataText = "";
                gvdetails.DataSource = dt;
                gvdetails.DataBind();
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
            if (txtDrawbackNo.Text != "" && txtNotnNo.Text != "" && txtNotnDate.Text != "" && txtDBKRate.Text != "" && txtDescription.Text != "")
            {

                Admin_mas.Edrawback_id = "0";
                Admin_mas.Edrawback_slno = txtDrawbackNo.Text;
                Admin_mas.Edrawback_description = "0";
                Admin_mas.Ename = "autoid";
                dtuser = Admin_mas.RetrieveAll_Drawback_master();
                string ii = Convert.ToString(Admin_mas.result);
                if (ii == "1")
                {
                    //lblMsg.Text = "Not Save, Category No Already Exist";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Drawback No Already Exist')</script>", false);
                }
                else
                {

                    if (dtuser.Tables[0].Rows.Count > 0)
                    {
                        AUTO_ID = dtuser.Tables[0].Rows[0]["DRAWBACK_ID"].ToString();

                        if (AUTO_ID != "")
                        {
                            Drawback_master_insert();
                        }
                        else
                        {
                            AUTO_ID = "1";
                            Drawback_master_insert();

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

    public void Drawback_master_insert()
    {
        try
        {
            DateTime Exchange_NONT_Date = DateTime.Parse(txtNotnDate.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

            i = am.tbmanipulate("INSERT INTO DRAWBACK_MASTER VALUES (" + AUTO_ID + ",'" + txtDrawbackNo.Text + "','" + txtNotnNo.Text + "','" + Exchange_NONT_Date + "','" + txtDBKRate.Text + "','" + txtDBKValueCAP.Text + "','" + txtUnit.Text + "','" + txtNo_Of_Units.Text + "','" + txtDescription.Text + "','" + txtCustoms.Text + "','" + txtExcise.Text + "','" + txtRemarks.Text + "')");
            if (i > 0)
            {
                //lblMsg.Text = " Saved Successfully";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);

                int pageno = 1;
                gridbind(pageno);

                //mo.ResetFields(Page.Controls);
                //txtCategoryNo.Focus();
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
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {

            int i;
            DateTime NONT_Date = DateTime.Parse(txtNotnDate.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

            i = am.tbmanipulate("update DRAWBACK_MASTER set DRAWBACK_SLNO='" + txtDrawbackNo.Text + "' ,DRAWBACK_NOTN_NO='" + txtNotnNo.Text + "',DRAWBACK_NOTN_DATE='" + NONT_Date + "',DRAWBACK_VALUE_CAP='" + txtDBKValueCAP.Text + "',DRAWBACK_UNIT='" + txtUnit.Text + "',DRAWBACK_NOOFUNITS='" + txtNo_Of_Units.Text + "',DRAWBACK_DESCRIPTION='" + txtDescription.Text + "',DRAWBACK_CUSTOMS='" + txtCustoms.Text + "',DRAWBACK_EXCISE='" + txtExcise.Text + "',DRAWBACK_REMARKS='" + txtRemarks.Text + "',DRAWBACK_RATE='" + txtDBKRate.Text + "' where DRAWBACK_ID=" + ViewState["DRAWBACK_ID"] + " ");
            if (i > 0)
            {
                //lblMsg.Text = "Saved Successfully";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);

                //int pageno = 1;
                //gridbind(pageno);
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
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {

            int i;

            Admin_mas.Edrawback_id = ViewState["DRAWBACK_ID"].ToString();
            Admin_mas.Edrawback_slno = "0";
            Admin_mas.Edrawback_description = "0";
            Admin_mas.Ename = "delete";
            int pageno = 1;
            Admin_mas.startRowIndex = Convert.ToString(pageno);
            Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
            gvdetails.DataSource = Admin_mas.RetrieveAll_Drawback_master();
            gvdetails.DataBind();

            Grid_Total(pageno, Admin_mas.Total_Rows);

            //int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
            //Add_Pageno(ii);
            i = Admin_mas.result;
            if (i > 0)
            {
                //lblMsg.Text = " Record Deleted";
                // gridbind();

                mo.ResetFields(Page.Controls);

                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                txtDrawbackNo.Focus();
                txtDrawbackNo.Enabled = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Deleted')</script>", false);


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
    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            mo.ResetFields(Page.Controls);

            //lblMsg.Text = "";
            txtDrawbackNo.Focus();
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
            txtDrawbackNo.Enabled = true;

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }

    //public void gridbind()
    //{
    //    Admin_mas.Ecategoryid = "0";
    //    Admin_mas.Ecategoryname = txtCategoryNameSearch.Text;
    //    Admin_mas.Ecategoryno = txtCategoryNoSearch.Text;

    //    Admin_mas.Ename = "select_con";


    //    gvdetails.DataSource = Admin_mas.RetrieveAll_Category_master();

    //    gvdetails.DataBind();
    //}
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            Main_GridView.Visible = true;
            NewDrawbackTemplate.Visible = false;
            GridDownloadTemplate.Visible = true;
            int pageno = 1;
            gridbind(pageno);
            //int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
            // Add_Pageno(ii);
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
            Admin_mas.Edrawback_id = "0";
            Admin_mas.Edrawback_slno = txtDrawbacknoSearch.Text;
            Admin_mas.Edrawback_description = txtDescriptionSearch.Text;
            Admin_mas.Ename = "select_con";
            Admin_mas.startRowIndex = Convert.ToString(currentPageNumber1);
            Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
            //ds = erm.RetrieveAll_Adcode_MASTER();
            gvdetails.EmptyDataText = "No Record Found";

            DataSet ds = Admin_mas.RetrieveAll_Drawback_master();

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
            //BindData(currentpagenumber2);
            //General_GridBind(currentpagenumber2);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }


    public void Edit_ExchangeDetails()
    {
        try
        {
            if (ViewState["DRAWBACK_ID"] != "" && ViewState["DRAWBACK_ID"] != null)
            {
                int i = 0;
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                DRAWBACK_ID = ViewState["DRAWBACK_ID"].ToString();


                Admin_mas.Edrawback_id = DRAWBACK_ID;
                Admin_mas.Edrawback_slno = "0";
                Admin_mas.Edrawback_description = "0";
                Admin_mas.Ename = "select_conwithcode";


                dtuser = Admin_mas.RetrieveAll_Drawback_master();
                if (dtuser.Tables[0].Rows.Count > 0)
                {
                    txtDrawbackNo.Text = dtuser.Tables[0].Rows[0]["DRAWBACK_SLNO"].ToString();
                    txtDrawbackNo.Enabled = false;

                    txtNotnNo.Text = dtuser.Tables[0].Rows[0]["DRAWBACK_NOTN_NO"].ToString();

                    DateTime DRAWBACK_NOTN_DATE = Convert.ToDateTime(dtuser.Tables[0].Rows[0]["DRAWBACK_NOTN_DATE"].ToString());

                    txtNotnDate.Text = string.Format("{0:dd/MM/yyyy}", DRAWBACK_NOTN_DATE);

                    txtDBKRate.Text = dtuser.Tables[0].Rows[0]["DRAWBACK_RATE"].ToString();
                    txtDBKValueCAP.Text = dtuser.Tables[0].Rows[0]["DRAWBACK_VALUE_CAP"].ToString();
                    txtUnit.Text = dtuser.Tables[0].Rows[0]["DRAWBACK_UNIT"].ToString();
                    txtNo_Of_Units.Text = dtuser.Tables[0].Rows[0]["DRAWBACK_NOOFUNITS"].ToString();
                    txtDescription.Text = dtuser.Tables[0].Rows[0]["DRAWBACK_DESCRIPTION"].ToString();
                    txtCustoms.Text = dtuser.Tables[0].Rows[0]["DRAWBACK_CUSTOMS"].ToString();
                    txtExcise.Text = dtuser.Tables[0].Rows[0]["DRAWBACK_EXCISE"].ToString();
                    txtRemarks.Text = dtuser.Tables[0].Rows[0]["DRAWBACK_REMARKS"].ToString();
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
            ViewState["DRAWBACK_ID"] = Convert.ToString(this.gvdetails.SelectedDataKey.Value);

            Edit_ExchangeDetails();
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
            mo.ResetFields(Page.Controls);

            //lblMsg.Text = "";
            txtDrawbackNo.Focus();
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
            txtDrawbackNo.Enabled = true;

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
            foreach (DataRow row in dt.Rows)
            {
                string cellValue = row["DRAWBACK_NOTN_DATE"] != DBNull.Value
                    ? row["DRAWBACK_NOTN_DATE"].ToString().Trim()
                    : string.Empty;

                if (!string.IsNullOrEmpty(cellValue))
                {
                    DateTime parsedDate; // Declare first for older C# versions

                    if (DateTime.TryParse(cellValue, out parsedDate))
                    {
                        row["DRAWBACK_NOTN_DATE"] = parsedDate.ToString("dd/MM/yyyy"); // Store as DateTime
                    }
                }
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add(dt, "Drawback_Master");
                ws.Row(1).Style.Font.Bold = true;
                ws.Columns().AdjustToContents();

                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", "attachment; filename=Drawback_Master.xlsx");
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
                "/Drawback_Master");

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
                dt.Columns.Add("DRAWBACK_SLNO");
                dt.Columns.Add("ERROR_DESCRIPTION");
                dt.Columns.Add("FIELD_Name");
                int Count = 1;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    if (string.IsNullOrEmpty(dr["DRAWBACK_SLNO"].ToString()) ||
                            !Regex.IsMatch(dr["DRAWBACK_SLNO"].ToString(), @"^[a-zA-Z0-9]+$"))
                    {
                        DataRow newdr = dt.NewRow();
                        newdr["ERROR_DESCRIPTION"] = "Only alphabets and numbers are allowed.";
                        newdr["DRAWBACK_SLNO"] = dr["DRAWBACK_SLNO"].ToString();
                        newdr["FIELD_Name"] = "DRAWBACK_SLNO";
                        newdr["SLNO"] = Count;
                        dt.Rows.Add(newdr);
                    }


                    string value = dr["DRAWBACK_NOTN_NO"].ToString().Trim();

                    if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, @"^[\d/]+$"))
                    {
                        DataRow newdr = dt.NewRow();
                        newdr["ERROR_DESCRIPTION"] = "Only numbers and '/' are allowed. Field is mandatory.";
                        newdr["DRAWBACK_SLNO"] = dr["DRAWBACK_SLNO"].ToString();
                        newdr["FIELD_Name"] = "DRAWBACK_NOTN_NO";
                        newdr["SLNO"] = Count;
                        dt.Rows.Add(newdr);
                    }

                    if (string.IsNullOrWhiteSpace(dr["DRAWBACK_RATE"].ToString()) ||
                        !Regex.IsMatch(dr["DRAWBACK_RATE"].ToString(), @"^\d+(\.\d+)?$"))
                    {
                        DataRow newdr = dt.NewRow();
                        newdr["ERROR_DESCRIPTION"] = "Only numbers or decimal values are allowed and field is mandatory.";
                        newdr["DRAWBACK_SLNO"] = dr["DRAWBACK_SLNO"].ToString();
                        newdr["FIELD_Name"] = "DRAWBACK_RATE";
                        newdr["SLNO"] = Count;
                        dt.Rows.Add(newdr);
                    }


                    if (string.IsNullOrWhiteSpace(dr["DRAWBACK_DESCRIPTION"].ToString()))
                    {
                        DataRow newdr = dt.NewRow();
                        newdr["ERROR_DESCRIPTION"] = "Field is mandatory and cannot be empty.";
                        newdr["DRAWBACK_SLNO"] = dr["DRAWBACK_SLNO"].ToString();
                        newdr["FIELD_Name"] = "DRAWBACK_DESCRIPTION";
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
                    Label12.Text = "Drawback_Master Excel Invalid Errors";
                    Label12.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>Excel_File_Validation()</script>", false);
                }
                else
                {
                    Admin_mas.Update_Priority = ddl_Priority.SelectedValue.ToString();
                    Admin_mas.Xml_A = DataTableToXml(ds);

                    ds = Admin_mas.BulkInsert_DRAWBACK_Record();
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
                        Label12.Text = "Drawback_Master Excel Already Exist Records";
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
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Drawback_Master DETAILS', function (r) {});}});</script>";
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
                        string values = "Please Fill DRAWBACK_SLNO Column in your Excel";

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