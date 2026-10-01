using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

public partial class Application_ErrorLogs_Report : System.Web.UI.Page
{
    
    AppSession aps = new AppSession();
    DataTable dt_errors = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();
       
        string path = Server.MapPath("~/Logs/");
        string filename = "";
        if (txtFrom_Date.Text == "")
        {
            /*This will get all files in the Latest top directory
            DirectoryInfo di = new DirectoryInfo(path);
            var newestFile = di.GetFiles("*", SearchOption.TopDirectoryOnly)
                         .OrderByDescending(f => f.LastWriteTime)  //Sort(desc) by LastWriteTime
                         .First();  //Take the first file
             path = path + "\\" + newestFile;
            */

            DateTime dt_now = DateTime.Today;
            filename = dt_now.ToString().Replace("00:00:00", "");
        }
        else
        {
            filename = txtFrom_Date.Text;
        }

        string[] f1 = filename.Split('/');
        //path = path + "\\" + "ErrorLog_" + f1[2].Trim() + f1[1] + f1[0] + ".log";
        path = path + "ErrorLog_" + f1[2].Trim() + f1[1] + f1[0] + ".log";

        DirectoryInfo di = new DirectoryInfo(path);

        if (File.Exists(path))
        {
            
            dt_errors.Columns.Add("DateTime");
            dt_errors.Columns.Add("CompanyID");
            dt_errors.Columns.Add("Name");
            dt_errors.Columns.Add("Branch");
            dt_errors.Columns.Add("PageError");

            string[] lines = File.ReadAllLines(path);

            if (lines.Length > 0)
            {
                for (int i = 0; i <= lines.Length - 1; i++)
                {
                    string[] splt_cnt = lines[i].Split('/');

                    if (splt_cnt.Count() > 4)
                    {
                        string splitword = " : ";
                        string datet = lines[i].Substring(0, 22);
                        string code = lines[i].Substring(lines[i].IndexOf(splitword) + splitword.Length);
                        string[] splt1 = code.Split('/');
                        int comp_splt = splt1[1].Length;

                        string Errword = "Page:";
                        string ErrorPage = lines[i].Substring(lines[i].IndexOf(Errword) + Errword.Length);
                        int comp_start = 35 + comp_splt;
                        int comp_end = lines[i].IndexOf(Errword) - comp_start;
                        string comp_name = lines[i].Substring(comp_start, comp_end);

                        dt_errors.Rows.Add(datet, splt1[0], comp_name, splt1[1], ErrorPage);

                    }
                }
            }

            GvReport.DataSource = dt_errors;
            GvReport.DataBind();

            ViewState["dt_app_error"] = dt_errors;
        }
        else
        {
            Alert_msg("File Not Found","");
        }
    }

    
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt_err = (DataTable)ViewState["dt_app_error"];

            var FullName1 = from DataRow drr in dt_err.AsEnumerable()
                            where drr.Field<string>("CompanyID").ToLower().Contains(txt_CompanyID.Text.ToLower()) && drr.Field<string>("Name").ToLower().Contains(txt_CompanyName.Text.ToLower()) &&
                            drr.Field<string>("PageError").ToLower().Contains(txt_ErrorDesc.Text.ToLower())
                            select drr;

            DataView dvv = FullName1.AsDataView();

            if (dvv.Count > 0)
            {
                DataTable dt_2 = dvv.ToTable();
                GvReport.DataSource = dt_2;
                GvReport.DataBind();

                ViewState["dt_app_error"] = dt_2;
            }
            else
            {
                DataTable dt_empty = new DataTable();
                GvReport.DataSource = dt_empty;
                GvReport.DataBind();

                ViewState["dt_app_error"] = dt_empty;
            }
        }
        catch (Exception ex)
        {
            ErrorLogs err = new ErrorLogs();
            err.makeLog(ex.Message);
        }
    }


    protected void btnexcel_Click(object sender, EventArgs e)
    {
        if (GvReport.Rows.Count > 0)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)ViewState["dt_app_error"];
            if (dt.Rows.Count > 0)
            {
                ExportExcel(dt, "Application Error Logs Report");
            }
            else
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('No Records Found', 'Application Error Logs Report', function (r) {});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            }
        }
        else
        {
            string prompt = "<script>$(document).ready(function(){{jAlert('No Records Found', 'Application Error Logs Report', function (r) {});}});</script>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
        }
    }


    protected void GvReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {   
        if (e.Row.RowType == DataControlRowType.DataRow)
        {       
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                e.Row.Cells[i].Attributes.Add("style", "white-space:nowrap;");
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

    public void ExportExcel(DataTable dtdata, string filename)
    {

        HttpResponse Response = HttpContext.Current.Response;
        GridView grd = new GridView();
        grd.DataSource = dtdata;
        grd.DataBind();

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename= " + filename + ".xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {

            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //foreach (TableCell cell in grd.HeaderRow.Cells)
            //{
            //    //cell.BackColor = grd.HeaderStyle.BackColor;
            //    cell.BackColor=grd.HeaderRow.BackColor
            //}

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

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Application Error Logs Report', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
}