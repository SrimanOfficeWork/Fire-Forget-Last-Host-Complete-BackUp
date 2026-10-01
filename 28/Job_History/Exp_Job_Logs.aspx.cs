using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class Exp_Job_Logs : ThemeClass
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    public int i;
    public string JobNo = "";
    Export_General_New Exp = new Export_General_New();
    DataSet _dataset = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        JobNo = Connection.EXP_Jobno();
        if (!IsPostBack)
        {
            PageNames();
            DataTable dt = new DataTable();
            gvdetails.DataSource = dt;
            gvdetails.DataBind();
        }
    }

    public void PageNames()
    {
        try
        {
            ddl_EXP_PageName.Items.Clear();
            DataTable dtPages = new DataTable();
            dtPages.Columns.Add("PageName");
            dtPages.Rows.Add("--Select--");
            dtPages.Rows.Add("General");
            dtPages.Rows.Add("Invoice");
            dtPages.Rows.Add("AR4 Details");
            dtPages.Rows.Add("Item");
            dtPages.Rows.Add("License");
            dtPages.Rows.Add("License_Imp_Exp");
            dtPages.Rows.Add("ReExport");
            dtPages.Rows.Add("Quota");
            dtPages.Rows.Add("Drawback");
            dtPages.Rows.Add("SW Info Type");
            dtPages.Rows.Add("SW Constituent");
            dtPages.Rows.Add("SW Production");
            dtPages.Rows.Add("SW Control");
            dtPages.Rows.Add("SW Statement");
            dtPages.Rows.Add("Sup Docs");
            dtPages.Rows.Add("All");

            ddl_EXP_PageName.DataSource = dtPages;
            ddl_EXP_PageName.DataTextField = "PageName";
            ddl_EXP_PageName.DataValueField = "PageName";
            ddl_EXP_PageName.DataBind();

            //if (hdn_Tab_click.Value == "Jobmodified")
            //{
            dtPages.Rows.Add("Bulk_INV_Exrate_upd");
            dtPages.Rows.Add("Bulk_Item_IGST_Update");
            dtPages.Rows.Add("Item_RODTEP_Update");
            //}

            ddl_EXP_PageName2.DataSource = dtPages;
            ddl_EXP_PageName2.DataTextField = "PageName";
            ddl_EXP_PageName2.DataValueField = "PageName";
            ddl_EXP_PageName2.DataBind();

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }


    protected void ddl_EXP_PageName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddl_EXP_PageName.SelectedItem.Text == "--Select--")
            {
                gvdetails.DataSource = null;
                gvdetails.DataBind();
                lbl_cols_count.Text = "Rows Count :0";
                ViewState["Exp_job_log"] = null;
            }
            else
            {
                _dataset = Exp.Exp_Job_Logs_All_Details(JobNo, "", "", ddl_EXP_PageName.SelectedItem.Text, "", "Search");
                if (_dataset.Tables[0].Rows.Count > 0)
                {
                    gvdetails.DataSource = _dataset.Tables[0];
                    gvdetails.DataBind();
                    lbl_cols_count.Text = "Rows Count : " + Convert.ToString(_dataset.Tables[0].Rows.Count);
                    ViewState["Exp_job_log"] = _dataset.Tables[0];
                }
                else
                {
                    gvdetails.DataSource = null;
                    gvdetails.DataBind();
                    lbl_cols_count.Text = "Rows Count :0";
                    ViewState["Exp_job_log"] = null;
                }

            }

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    protected void btnexcel_Click(object sender, EventArgs e)
    {
        exportfile("Excel");
    }

    private void exportfile(string filetype)
    {
        try
        {
            DataTable dt_new = new DataTable();
            dt_new = (DataTable)ViewState["Exp_job_log"];
            string dt_time = DateTime.Now.ToString();

            if (filetype == "Excel")
            {
                HttpResponse Response = HttpContext.Current.Response;
                GridView grd = new GridView();
                grd.DataSource = dt_new;
                grd.DataBind();

                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename= " + "Export_Job_History" + dt_time + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                    grd.HeaderStyle.BackColor = System.Drawing.Color.LightGray;
                    grd.HeaderStyle.ForeColor = System.Drawing.Color.Blue;
                    grd.HeaderStyle.Height = 26;
                    grd.RowStyle.Height = 18;

                    grd.RenderControl(hw);
                    string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                    Response.Write(style);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
            }
            else
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('No Records Found', 'Export Job History', function (r) {});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

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


    protected void btnexcel_Modified_Click(object sender, EventArgs e)
    {
        Modified_exportfile("Excel");
    }

    private void Modified_exportfile(string filetype)
    {

        DataTable dt_new = new DataTable();
        dt_new = (DataTable)ViewState["Vw_Data_Modified"];
        string dt_time = DateTime.Now.ToString();


        if (filetype == "Excel")
        {
            HttpResponse Response = HttpContext.Current.Response;


            GridView grd = new GridView();
            grd.DataSource = dt_new;
            grd.DataBind();

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename= " + "Export_Job_Modified_History" + dt_time + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {

                HtmlTextWriter hw = new HtmlTextWriter(sw);
                grd.HeaderStyle.BackColor = System.Drawing.Color.LightGray;
                grd.HeaderStyle.ForeColor = System.Drawing.Color.Blue;
                grd.HeaderStyle.Height = 26;
                grd.RowStyle.Height = 18;

                grd.RenderControl(hw);
                string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
            //}
        }
        else
        {
            string prompt = "<script>$(document).ready(function(){{jAlert('No Records Found', 'Export Job History', function (r) {});}});</script>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
        }
    }


    protected void ddl_EXP_PageName2_SelectedIndexChanged1(object sender, EventArgs e)
    {
        DataTable dt_cols = new DataTable();
        string GroupId = HttpContext.Current.Session["GroupID"].ToString();
        string folderPath = Server.MapPath("~/logs_DataModifiedHistory/EXP/" + Connection.WorkingPeriod() + "/" + Connection.COMPANYID() + "/" + GroupId + "/");

        string filePath = folderPath + "/" + JobNo + ".log";

        // Define columns
        dt_cols.Columns.Add("PageName");
        dt_cols.Columns.Add("Jobno");
        dt_cols.Columns.Add("InvSlno");
        dt_cols.Columns.Add("ItemSlno");
        dt_cols.Columns.Add("ColumnName");
        dt_cols.Columns.Add("OldValue");
        dt_cols.Columns.Add("NewValue");
        dt_cols.Columns.Add("Modified_Time");
        dt_cols.Columns.Add("User");
        dt_cols.Columns.Add("Branch");

        if (File.Exists(filePath) == true)
        {
            string contents = File.ReadAllText(filePath);

            contents.Split('\n')
                .Select(line => line.Trim())
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .Select(line => line.Split('|'))
                //.Where(cols => cols.Length == 9) // ✅ safety check
                .ToList()
                .ForEach(cols =>
                {
                    dt_cols.Rows.Add(
                        cols[0],
                        cols[1],
                        cols[2],
                        cols[3],
                        cols[4],
                        cols[5],
                        cols[6],
                        cols[7],
                        cols[8],
                        cols[9]
                    );
                });
        }

        //#Select Particular Pages
        if (ddl_EXP_PageName2.SelectedItem.Text != "--Select--" && ddl_EXP_PageName2.SelectedItem.Text != "All")
        {
            DataTable dt_output = new DataTable();
            var PageName = from DataRow drr in dt_cols.AsEnumerable()
                           where drr.Field<string>("PageName") == ddl_EXP_PageName2.SelectedItem.Text
                           select drr;

            DataView dvv = PageName.AsDataView();

            if (dvv.Count > 0)
            {
                dt_output = PageName.CopyToDataTable();
            }

            gvdetails2.DataSource = dt_output;
            gvdetails2.DataBind();

            lbl_cols_count2.Text = "Rows Count : " + Convert.ToString(dt_output.Rows.Count);

            ViewState["Vw_Data_Modified"] = dt_output;
        }
        else if (ddl_EXP_PageName2.SelectedItem.Text == "All")
        {
            gvdetails2.DataSource = dt_cols;
            gvdetails2.DataBind();

            lbl_cols_count2.Text = "Rows Count : " + Convert.ToString(dt_cols.Rows.Count);

            ViewState["Vw_Data_Modified"] = dt_cols;
        }

        ScriptManager.RegisterStartupScript(this, GetType(), "test", "tab2();", true);
    }

    protected void gvdetails2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].BackColor = System.Drawing.Color.LightGray;
            e.Row.Cells[1].BackColor = System.Drawing.Color.Thistle;
            e.Row.Cells[2].BackColor = System.Drawing.Color.Thistle;
            e.Row.Cells[3].BackColor = System.Drawing.Color.LightSkyBlue;
            e.Row.Cells[4].BackColor = System.Drawing.Color.LightPink;
            e.Row.Cells[5].BackColor = System.Drawing.Color.LightGreen;
            e.Row.Cells[6].BackColor = System.Drawing.Color.LightGray;
            e.Row.Cells[7].BackColor = System.Drawing.Color.PeachPuff;
        }

    }
}