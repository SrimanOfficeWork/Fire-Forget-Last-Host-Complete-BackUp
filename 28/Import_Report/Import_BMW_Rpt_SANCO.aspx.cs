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


public partial class Import_BMW_Rpt_SANCO : System.Web.UI.Page
{
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;

    public string SELECT_TYPE, SELECT_BRANCH;

    AppSession aps = new AppSession();
    Company_Master Comp = new Company_Master();
    BMW_Excel BMW = new BMW_Excel();
    string errorFolder = "";

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
            load_ImporterName();
        }
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Report_data("");
    }

    private void Report_data(string btnexcel_clk)
    {
        try
        {
           
                bool isEmpty = true;
                string F_date, T_date;

                string[] arr = new string[] { };
                string[] arr2 = new string[] { };


                if (txtFrom_Date.Text != "")
                {
                    arr = txtFrom_Date.Text.Split('/');
                    F_date = arr[1] + '/' + arr[0] + '/' + arr[2];
                }
                else
                {
                    F_date = "";
                }

                if (txtTo_Date.Text != "")
                {
                    arr = txtTo_Date.Text.Split('/');
                    T_date = arr[1] + '/' + arr[0] + '/' + arr[2];
                }
                else
                {
                    T_date = "";
                }


                BMW.Jobno = ddlJobNo.SelectedItem.Text;
                BMW.Importer_Name = ddlimpname.SelectedItem.Text;
                BMW.Based_Date = ddl_date.SelectedValue;
                BMW.fromdate = F_date;
                BMW.todate = T_date;
                BMW.flag = "Bind_Data";

                DataSet dss = BMW.RetrieveAll_IMPORT_Monthwise_Rpt();
                DataTable dt = new DataTable();
                if (dss.Tables[0].Rows.Count > 0)
                {
                    //----------------ViewState-  while Bind large Data - OutofMemory exception throwing --hide on 19-07-2022
                    //ViewState["Excel"] = dss.Tables[0];

                    //----------- to Avoid Out of Memory exception while Grid load the big data
                    int pageNum = 1;
                    int pageSize = 100;

                    DataTable dtPage = dss.Tables[0].Rows.Cast<System.Data.DataRow>().Skip((pageNum - 1) * pageSize).Take(pageSize).CopyToDataTable();

                    GvReport.DataSource = dtPage;
                    GvReport.DataBind();


                    lbl_count.Text = "Row Count : " + Convert.ToString(dss.Tables[0].Rows.Count);
                    lbl_cols_count.Text = "Column Count : " + Convert.ToString(dss.Tables[0].Columns.Count);

                    if (btnexcel_clk == "Yes")
                    {
                        exportfile("Excel", dss.Tables[0]);
                    }

                }
                else
                {
                    DataTable dt_empty = new DataTable();
                    //GvReport.DataSource = dt_empty;
                    //GvReport.DataBind();
                    lbl_count.Text = "Row Count : 0";
                    lbl_cols_count.Text = "Column Count : 0";
                }
           
        }
        catch (Exception ex)
        {
            ErrorLogs err = new ErrorLogs();
            err.makeLog(ex.Message);
        }
    }

    private void jobload()
    {
       
        CheckList chklist = new CheckList();
        chklist.JOBNo = "";
        chklist.Ename = "select_jobno";
        chklist.Workingperiod = SELECT_BRANCH;

        ddlJobNo.DataSource = chklist.RetrieveAll_General_Details();
        ddlJobNo.DataValueField = "JOBNO";
        ddlJobNo.DataTextField = "JOBNO";
        ddlJobNo.DataBind();

        ListItem li = new ListItem(string.Empty, string.Empty);
        ddlJobNo.Items.Insert(0, li);
        
    }


    private void load_ImporterName()
    {
        
        DataSet ds = new DataSet();

        BMW.flag = "Bind_Imp_Name";

        ds = BMW.RetrieveAll_IMPORT_Monthwise_Rpt();

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlimpname.DataSource = ds.Tables[0];
            ddlimpname.DataValueField = "IMPORTER_NAME";
            ddlimpname.DataTextField = "IMPORTER_NAME";
            ddlimpname.DataBind();

            ddlimpname.Items.Insert(0, "BMW INDIA PRIVATE LIMITED");
            ddlimpname.Items.Insert(1, new ListItem(string.Empty, string.Empty));
            ddlimpname.SelectedIndex = 0;
        }
        else
        {
            ddlimpname.Items.Insert(0, "BMW INDIA PRIVATE LIMITED");
            ddlimpname.Items.Insert(1, new ListItem(string.Empty, string.Empty));
            ddlimpname.SelectedIndex = 0;
        }

    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Import - Custom Duty Report ', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }


    protected void btnexcel_Click(object sender, EventArgs e)
    {
        //exportfile("Excel");
        Report_data("Yes");
    }

    private void exportfile(string filetype, DataTable dt)
    {
        //if (GvReport.Rows.Count > 0)
        //{
            //DataTable dt = new DataTable();
            //dt = (DataTable)ViewState["Excel"];
            if (dt.Rows.Count > 0)
            {
                if (filetype == "Excel")
                {
                    ExportExcel(dt, "Import-BMW-Report");
                }
            }
            else
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('No Records Found', 'Import - BMW Report ', function (r) {});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            }
        //}
        //else
        //{
        //    string prompt = "<script>$(document).ready(function(){{jAlert('No Records Found', 'Import - BMW Report ', function (r) {});}});</script>";
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
        //}
    }

    protected void btnRdlc_Click(object sender, EventArgs e)
    {

        //exportfile("PDF");
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


}