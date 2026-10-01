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

public partial class ERoyal_Admin_Master_ROSL : ThemeClass
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 15;
    public int i, Total_Rows;
    public string AUTO_ID;



    SqlConnection con;
    SqlCommand cmd;


    adminmaster Admin_mas = new adminmaster();

    DataSet dtuser = new DataSet();

    public int rowIndex;

    Manipulation mo = new Manipulation();
    AdminManipulation am = new AdminManipulation();
    AppSession aps = new AppSession();
    public string ROSL_ID = "";

    public string ROSL_DATE;
    ErrorLogs er = new ErrorLogs();
    DropDownList ddl = new DropDownList();
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);


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

            txtROSLNoSearch.Focus();
            DateTime dat = System.DateTime.Now;
            datestring = string.Format("{0:dd/MM/yyyy}", dat);

            txtNotnDate.Text = datestring;
            //mainmastopusernametxt.InnerText = "Welcome Mr." + currentuser;
            Div_Pagination.Visible = false;

            NewROSLTemplate.Visible = true;
            GridDownloadTemplate.Visible = false;

            if (!IsPostBack)
            {

                Edit_ROSL_Details();
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
            if (txtROSLNo.Text != "" && txtROSLNotnNo.Text != "" && txtNotnDate.Text != "" && txtROSLRate.Text != "" && txtDescription.Text != "")
            {

                Admin_mas.EROSL_id = "0";
                Admin_mas.EROSL_slno = txtROSLNo.Text;

                Admin_mas.EROSL_Headerno = "0";

                Admin_mas.EROSL_description = "0";



                Admin_mas.Ename = "autoid";


                dtuser = Admin_mas.RetrieveAll_ROSL_master();
                string ii = Convert.ToString(Admin_mas.result);
                if (ii == "1")
                {

                    //lblMsg.Text = "Not Save, Category No Already Exist";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('ROSL SLNo Already Exist')</script>", false);

                }
                else
                {

                    if (dtuser.Tables[0].Rows.Count > 0)
                    {
                        AUTO_ID = dtuser.Tables[0].Rows[0]["ROSL_ID"].ToString();

                        if (AUTO_ID != "")
                        {
                            ROSL_master_insert();
                        }
                        else
                        {
                            AUTO_ID = "1";
                            ROSL_master_insert();

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


    public void clear()
    {
        try
        {

            txtROSLNo.Text = " ";
            txtNotnDate.Text = " ";
            txtROSLNotnNo.Text = " ";
            txtROSLRate.Text = " ";
            txtROSLAmnt.Text = " ";
            txtROSLUnit.Text = " ";
            txtNo_Of_Units.Text = " ";
            txtDescription.Text = " ";
            txtCustoms.Text = " ";
            txtExcise.Text = " ";
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }

    public void ROSL_master_insert()
    {
        try
        {
            if (txtNotnDate.Text != "" || txtNotnDate.Text != null)
            {
                string txtNotnDate1 = txtNotnDate.Text;

                string[] date1 = txtNotnDate1.Split('/');
                string part1 = date1[0];
                string part2 = date1[1];
                string part3 = date1[2];

                ROSL_DATE = part2 + "/" + part1 + "/" + part3;
            }

            string hdr, ROSL_HeaderNo;

            ROSL_HeaderNo = txtROSLNo.Text;

            hdr = ROSL_HeaderNo.Substring(0, 2);



            i = am.tbmanipulate("INSERT INTO EXPORT_ROSL_MASTER VALUES (" + AUTO_ID + ",'" + hdr + "','" + txtROSLNo.Text + "','" + txtROSLNotnNo.Text + "','" + ROSL_DATE + "','" + txtROSLRate.Text + "','" + txtROSLAmnt.Text + "','" + txtROSLUnit.Text + "','" + txtNo_Of_Units.Text + "','" + txtDescription.Text + "','" + txtCustoms.Text + "','" + txtExcise.Text + "')");
            if (i > 0)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);

                int pageno = 1;
                gridbind(pageno);


            }
            else
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);

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

            if (txtNotnDate.Text != "" || txtNotnDate.Text != null)
            {
                string txtNotnDate1 = txtNotnDate.Text;

                string[] date1 = txtNotnDate1.Split('/');
                string part1 = date1[0];
                string part2 = date1[1];
                string part3 = date1[2];

                ROSL_DATE = part2 + "/" + part1 + "/" + part3;
            }



            //DateTime NONT_Date = DateTime.Parse(txtNotnDate.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);


            i = am.tbmanipulate("update EXPORT_ROSL_MASTER set ROSL_SLNO='" + txtROSLNo.Text + "' ,ROSL_NOTN_NO='" + txtROSLNotnNo.Text + "',DRAWBACK_NOTN_DATE='" + ROSL_DATE + "',ROSL_RATE='" + txtROSLRate.Text + "',ROSL_AMT='" + txtROSLAmnt.Text + "',ROSL_UNIT='" + txtROSLUnit.Text + "',ROSL_NOOFUNITS='" + txtNo_Of_Units.Text + "',ROSL_DESCRIPTION='" + txtDescription.Text + "',ROSL_CUSTOMS='" + txtCustoms.Text + "',ROSL_EXCISE='" + txtExcise.Text + "' where ROSL_ID=" + ViewState["ROSL_ID"] + " ");
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


        clear();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {

            int i;

            Admin_mas.EROSL_id = ViewState["ROSL_ID"].ToString();
            Admin_mas.EROSL_slno = "0";
            Admin_mas.EROSL_description = "0";
            Admin_mas.Ename = "delete";
            int pageno = 1;
            Admin_mas.startRowIndex = Convert.ToString(pageno);
            Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
            gvdetails.DataSource = Admin_mas.RetrieveAll_ROSL_master();
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
                txtROSLNo.Focus();
                txtROSLNo.Enabled = true;
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
            txtROSLNo.Focus();
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
            txtROSLNo.Enabled = true;
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
            NewROSLTemplate.Visible = false;
            GridDownloadTemplate.Visible = true;
            Main_GridView.Visible = true;

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
            Admin_mas.EROSL_id = "0";
            Admin_mas.EROSL_slno = txtROSLNoSearch.Text;
            Admin_mas.EROSL_description = txtDescriptionSearch.Text;
            Admin_mas.Ename = "select_con";
            Admin_mas.startRowIndex = Convert.ToString(currentPageNumber1);
            Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
            //ds = erm.RetrieveAll_Adcode_MASTER();
            gvdetails.EmptyDataText = "No Record Found";
            DataSet ds = Admin_mas.RetrieveAll_ROSL_master();

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


    public void Edit_ROSL_Details()
    {
        try
        {
            if (ViewState["ROSL_ID"] != "" && ViewState["ROSL_ID"] != null)
            {
                int i = 0;
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                ROSL_ID = ViewState["ROSL_ID"].ToString();


                Admin_mas.EROSL_id = ROSL_ID;
                Admin_mas.EROSL_slno = "0";
                Admin_mas.EROSL_description = "0";
                Admin_mas.Ename = "select_conwithcode";


                dtuser = Admin_mas.RetrieveAll_ROSL_master();
                if (dtuser.Tables[0].Rows.Count > 0)
                {
                    txtROSLNo.Text = dtuser.Tables[0].Rows[0]["ROSL_SLNO"].ToString();
                    txtROSLNo.Enabled = false;

                    txtROSLNotnNo.Text = dtuser.Tables[0].Rows[0]["ROSL_NOTN_NO"].ToString();

                    DateTime DRAWBACK_NOTN_DATE = Convert.ToDateTime(dtuser.Tables[0].Rows[0]["DRAWBACK_NOTN_DATE"].ToString());

                    txtNotnDate.Text = string.Format("{0:dd/MM/yyyy}", DRAWBACK_NOTN_DATE);

                    txtROSLRate.Text = dtuser.Tables[0].Rows[0]["ROSL_RATE"].ToString();
                    txtROSLAmnt.Text = dtuser.Tables[0].Rows[0]["ROSL_AMT"].ToString();
                    txtROSLUnit.Text = dtuser.Tables[0].Rows[0]["ROSL_UNIT"].ToString();
                    txtNo_Of_Units.Text = dtuser.Tables[0].Rows[0]["ROSL_NOOFUNITS"].ToString();
                    txtDescription.Text = dtuser.Tables[0].Rows[0]["ROSL_DESCRIPTION"].ToString();
                    txtCustoms.Text = dtuser.Tables[0].Rows[0]["ROSL_CUSTOMS"].ToString();
                    txtExcise.Text = dtuser.Tables[0].Rows[0]["ROSL_EXCISE"].ToString();
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
            ViewState["ROSL_ID"] = Convert.ToString(this.gvdetails.SelectedDataKey.Value);

            Edit_ROSL_Details();
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


            txtROSLNo.Focus();
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
            txtROSLNo.Enabled = true;
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
                var ws = wb.Worksheets.Add(dt, "ROSL_Master");
                ws.Row(1).Style.Font.Bold = true;
                ws.Columns().AdjustToContents();

                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", "attachment; filename=ROSL_Master.xlsx");
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
                "/ROSL_Master");

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
                dt.Columns.Add("ROSL_SLNO");
                dt.Columns.Add("ERROR_DESCRIPTION");
                dt.Columns.Add("FIELD_Name");
                int Count = 1;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    if (string.IsNullOrEmpty(dr["ROSL_SLNO"].ToString()) ||
                            !Regex.IsMatch(dr["ROSL_SLNO"].ToString(), @"^[a-zA-Z0-9]+$"))
                    {
                        DataRow newdr = dt.NewRow();
                        newdr["ERROR_DESCRIPTION"] = "Only alphabets and numbers are allowed.";
                        newdr["ROSL_SLNO"] = dr["ROSL_SLNO"].ToString();
                        newdr["FIELD_Name"] = "ROSL_SLNO";
                        newdr["SLNO"] = Count;
                        dt.Rows.Add(newdr);
                    }


                    string value = dr["ROSL_NOTN_NO"].ToString().Trim();

                    if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, @"^[\d/]+$"))
                    {
                        DataRow newdr = dt.NewRow();
                        newdr["ERROR_DESCRIPTION"] = "Only numbers and '/' are allowed. Field is mandatory.";
                        newdr["ROSL_SLNO"] = dr["ROSL_SLNO"].ToString();
                        newdr["FIELD_Name"] = "ROSL_NOTN_NO";
                        newdr["SLNO"] = Count;
                        dt.Rows.Add(newdr);
                    }

                    if (string.IsNullOrWhiteSpace(dr["ROSL_RATE"].ToString()) ||
                        !Regex.IsMatch(dr["ROSL_RATE"].ToString(), @"^\d+(\.\d+)?$"))
                    {
                        DataRow newdr = dt.NewRow();
                        newdr["ERROR_DESCRIPTION"] = "Only numbers or decimal values are allowed and field is mandatory.";
                        newdr["ROSL_SLNO"] = dr["ROSL_SLNO"].ToString();
                        newdr["FIELD_Name"] = "ROSL_RATE";
                        newdr["SLNO"] = Count;
                        dt.Rows.Add(newdr);
                    }


                    if (string.IsNullOrWhiteSpace(dr["ROSL_DESCRIPTION"].ToString()))
                    {
                        DataRow newdr = dt.NewRow();
                        newdr["ERROR_DESCRIPTION"] = "Field is mandatory and cannot be empty.";
                        newdr["ROSL_SLNO"] = dr["ROSL_SLNO"].ToString();
                        newdr["FIELD_Name"] = "ROSL_DESCRIPTION";
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
                    Label12.Text = "ROSL_Master Excel Invalid Errors";
                    Label12.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>Excel_File_Validation()</script>", false);
                }
                else
                {
                    Admin_mas.Update_Priority = ddl_Priority.SelectedValue.ToString();
                    Admin_mas.Xml_A = DataTableToXml(ds);

                    ds = Admin_mas.ROSL_Master_Record();
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
                        Label12.Text = "ROSL_Master Excel Already Exist Records";
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
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'ROSL_Master DETAILS', function (r) {});}});</script>";
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
                        string values = "Please Fill ROSL_SLNO Column in your Excel";

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