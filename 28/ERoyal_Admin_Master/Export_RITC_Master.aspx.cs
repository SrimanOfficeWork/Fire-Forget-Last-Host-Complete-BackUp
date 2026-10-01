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
using System.Data.OleDb;
using ClosedXML.Excel;
using System.Xml;

public partial class Export_RITC_Master : ThemeClass
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
    public string RITC_ID = "";
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
            //currentuser = Session["currentuser"].ToString();
            //currentbranch = Session["currentbranch"].ToString();
            //currentcomp_name = Session["currentcomp_name"].ToString();
            //comp_ConnectionStr = Session["currentcomp_db"].ToString();
            //Working_Period = Session["WorkingPeriod"].ToString();
            //LoginDate = Session["LoginDate"].ToString();

            txtRITCCodeSearch.Focus();

            // mainmastopusernametxt.InnerText = "Welcome Mr." + currentuser;
            Div_Pagination.Visible = false;
            NewRODTEPTemplate.Visible = true;
            GridDownloadTemplate.Visible = false;

            if (!IsPostBack)
            {
                load_ddl();

                Edit_Details();
                DataTable dt = new DataTable();
                gvdetails.EmptyDataText = "";
                gvdetails.DataSource = dt;
                gvdetails.DataBind();
                //int pageno = 1;

                //gridbind(pageno);
                ////int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
                ////Add_Pageno(ii);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //Unit code must be 3 character start
        string TEMP = txt_RITCCode.Text;
        byte TEMPLEN = Convert.ToByte(TEMP.Length);
        if (TEMPLEN != 8)
        {
            //lblMsg.Text = "CETH Code must be 8  character";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('RITC Code Should be 8 character')</script>", false);

        } ////CETH code must be 8  character end

        else
        {
            try
            {
                if (txt_RITCCode.Text != "" && txt_Description.Text != "")
                {
                    Admin_mas.ERITC_ID = "0";
                    Admin_mas.ERITC_CODE = txt_RITCCode.Text;
                    Admin_mas.EUnit_name = "0";
                    Admin_mas.Ename = "autoid";

                    dtuser = Admin_mas.RetrieveAll_Export_RITC__Master();
                    string ii = Convert.ToString(Admin_mas.result);
                    if (ii == "1")
                    {
                        //lblMsg.Text = "Not Save, CETH Code Already Exist";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('RITC Code Already Exist')</script>", false);

                    }
                    else
                    {
                        if (dtuser.Tables[0].Rows.Count > 0)
                        {
                            AUTO_ID = dtuser.Tables[0].Rows[0]["RITC_ID"].ToString();

                            if (AUTO_ID != "")
                            {
                                Export_RITC_insert();
                            }
                            else
                            {
                                AUTO_ID = "1";
                                Export_RITC_insert();
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

    public void Export_RITC_insert()
    {
        try
        {
            //i = am.tbmanipulate("INSERT INTO EXPORT_RITC_MASTER VALUES (" + AUTO_ID + ",'" + txt_RITCCode.Text + "','" + txt_Description.Text + "','" + txtRemarks.Text + "')");

            //i = am.tbmanipulate("INSERT INTO EXPORT_RITC_MASTER VALUES (" + AUTO_ID + ",'" + txt_RITCCode.Text + "','" + "" + "','" + txt_Description.Text + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "')");
            i = am.tbmanipulate("INSERT INTO EXPORT_RITC_MASTER VALUES (" + AUTO_ID + ",'" + txt_RITCCode.Text + "','" + txt_UQC.Text.ToUpper() + "','" + txt_Description.Text + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + ddl_Isvalid.SelectedItem.Text + "','" + "" + "')");

            if (i > 0)
            {
                //lblMsg.Text = " Saved Successfully";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);

                int pageno = 1;
                gridbind(pageno);
                //mo.ResetFields(Page.Controls);
                txt_RITCCode.Focus();
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
            mo.ResetFields(Page.Controls);
            //lblMsg.Text = "";
            txt_RITCCode.Focus();
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
            txt_RITCCode.Enabled = true;

            load_ddl();

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

            Admin_mas.ERITC_ID = ViewState["RITC_ID"].ToString();
            Admin_mas.ERITC_CODE = "0";
            Admin_mas.EUnit_name = "0";

            Admin_mas.Ename = "delete";

            int pageno = 1;
            Admin_mas.startRowIndex = Convert.ToString(pageno);
            Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
            gvdetails.DataSource = Admin_mas.RetrieveAll_Export_RITC__Master();
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
                txt_RITCCode.Enabled = true;

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

            i = am.tbmanipulate("update EXPORT_RITC_MASTER set RITC_CODE='" + txt_RITCCode.Text + "' ,RITC_ITEMDESC='" + txt_Description.Text + "',RITC_ITEMUNIT='" + txt_UQC.Text.ToUpper() + "',RITC_VALID='" + ddl_Isvalid.SelectedItem.Text + "' where RITC_ID=" + ViewState["RITC_ID"] + " ");
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
            Main_GridView.Visible = true;
            NewRODTEPTemplate.Visible = false;
            GridDownloadTemplate.Visible = true;
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
            Admin_mas.ERITC_ID = "0";
            Admin_mas.ERITC_CODE = txtRITCCodeSearch.Text;
            Admin_mas.ERITC_DESCRIPTION = txtDescriptionSearch.Text;
            Admin_mas.Ename = "select_con";

            Admin_mas.startRowIndex = Convert.ToString(currentPageNumber1);
            Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
            //ds = erm.RetrieveAll_Adcode_MASTER();
            gvdetails.EmptyDataText = "No Record Found";

            DataSet ds = Admin_mas.RetrieveAll_Export_RITC__Master();

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


    public void Edit_Details()
    {
        try
        {
            if (ViewState["RITC_ID"] != "" && ViewState["RITC_ID"] != null)
            {
                int i = 0;
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                RITC_ID = ViewState["RITC_ID"].ToString();

                // string Query = "select * from SUP_MASTER where SUP_ID='" + SUP_ID + "'";

                string Query = "UNIT_MASTER_SP_SELECT_CONWITHCODE";

                //gvdetails.DataSource = mo.RetrieveAll_LIKE(Query, SUP_ID);

                i = am.Unit_Master_All_BIND(Query, RITC_ID);

                txt_RITCCode.Text = am.UNIT_CODE;

                txt_Description.Text = am.UNIT_NAME;
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

    protected void load_ddl()
    {
        try
        {
            ddl_Isvalid.Items.Clear();
            ddl_Isvalid.Items.Add("");
            ddl_Isvalid.Items.Add("Y");
            ddl_Isvalid.Items.Add("N");
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
            ViewState["RITC_ID"] = Convert.ToString(this.gvdetails.SelectedDataKey.Value);

            if (ViewState["RITC_ID"] != "" && ViewState["RITC_ID"] != null)
            {
                txt_RITCCode.Text = gvdetails.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
                txt_RITCCode.Enabled = false;

                txt_Description.Text = gvdetails.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
                txt_UQC.Text = gvdetails.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");

                load_ddl();
                if (!string.IsNullOrEmpty(gvdetails.SelectedRow.Cells[4].Text.Replace("&nbsp;", "")))
                {
                    ddl_Isvalid.SelectedValue = gvdetails.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
                }

                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;

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
            txt_RITCCode.Focus();
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
            txt_RITCCode.Enabled = true;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'RITC DETAILS', function (r) {});}});</script>";
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


    private void CleanDataTable(DataTable dt)
    {
        try
        {
            foreach (DataRow row in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (row[i] != null && row[i] != DBNull.Value)
                    {
                        string value = row[i].ToString();

                        value = new string(value.Where(ch => XmlConvert.IsXmlChar(ch)).ToArray());

                        row[i] = value;
                    }
                }
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
            CleanDataTable(dt);
            using (XLWorkbook wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add(dt, "RITC_Master");
                ws.Row(1).Style.Font.Bold = true;
                ws.Columns().AdjustToContents();

                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", "attachment; filename=RITC_Master.xlsx");
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
                "/EXPORT_RITC_MASTER_EXCEL");

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
                dt.Columns.Add("RITC_CODE");
                dt.Columns.Add("ERROR_DESCRIPTION");
                dt.Columns.Add("FIELD_Name");
                int Count = 1;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (!Regex.IsMatch(dr["RITC_CODE"].ToString(), @"^\d{8}$") || string.IsNullOrEmpty(dr["RITC_CODE"].ToString()))
                    {
                        DataRow newdr = dt.NewRow();
                        newdr["ERROR_DESCRIPTION"] = "MANDATORY 8 DIGITS RITC_CODE";
                        newdr["RITC_CODE"] = dr["RITC_CODE"].ToString();
                        newdr["FIELD_Name"] = "RITC_CODE";
                        newdr["SLNO"] = Count;
                        dt.Rows.Add(newdr);
                    }

                    if (string.IsNullOrEmpty(dr["RITC_ITEMDESC"].ToString()))
                    {
                        DataRow newdr = dt.NewRow();
                        newdr["ERROR_DESCRIPTION"] = "RITC_ITEMDESC IS MANDATORY";
                        newdr["RITC_CODE"] = dr["RITC_CODE"].ToString();
                        newdr["FIELD_Name"] = "RITC_ITEMDESC";
                        newdr["SLNO"] = Count;
                        dt.Rows.Add(newdr);
                    }

                    //if (string.IsNullOrEmpty(dr["RITC_ITEMUNIT"].ToString()))
                    //{
                    //    DataRow newdr = dt.NewRow();
                    //    newdr["ERROR_DESCRIPTION"] = "RITC_ITEMUNIT IS MANDATORY";
                    //    newdr["RITC_CODE"] = dr["RITC_CODE"].ToString();
                    //    newdr["FIELD_Name"] = "RITC_ITEMUNIT";
                    //    newdr["SLNO"] = Count;
                    //    dt.Rows.Add(newdr);
                    //}

                    //if (string.IsNullOrEmpty(dr["RITC_VALID"].ToString()))
                    //{
                    //    DataRow newdr = dt.NewRow();
                    //    newdr["ERROR_DESCRIPTION"] = "RITC_ITEMUNIT IS MANDATORY";
                    //    newdr["RITC_CODE"] = dr["RITC_CODE"].ToString();
                    //    newdr["FIELD_Name"] = "RITC_VALID";
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
                    Label12.Text = "RITC Master Excel Invalid Errors";
                    Label12.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>Excel_File_Validation()</script>", false);
                }
                else
                {

                    Admin_mas.Update_Priority = ddl_Priority.SelectedValue.ToString();
                    Admin_mas.Xml_A = DataTableToXml(ds);

                    ds = Admin_mas.Export_RITC_Master_Bulk_Insert();
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
                        Label12.Text = "RITC Master Excel Already Exist Records";
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
                        string values = "Please Fill RIDC CODE Column in your Excel";

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
            e.Row.BackColor = System.Drawing.Color.White;

        }

    }

}