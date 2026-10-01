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
        ddl_Branch.Items.Clear();
        ddl_Branch.Items.Add(currentbranch);

        if (!IsPostBack)
        {
            jobload();
            load_Report_Name();
        }
    }

   
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (ddlJobNo.SelectedItem.Text != "")
        {
            Report_data();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Select JobNo')", true);
            ddlJobNo.Focus();
        }
    }

    private void Report_data()
    {
        try
        {
            /*
            string Branchlist = "";
            
            foreach (ListItem item in ListBox1.Items)
            {
                if (item.Selected)
                {
                    //message += item.Text + "~" + item.Value + "\\n";
                    Branchlist += item.Value + "~";
                }
            }
            */
            string Branchlist = Session["GroupID"].ToString();

            if (Branchlist != "")
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

                }
                {
                    T_date = "";
                }


                CDR.Jobno = ddlJobNo.SelectedItem.Text;
                CDR.From_date = F_date;
                CDR.To_date = T_date;
                CDR.Imp_Name = ddlimpname.SelectedItem.Text;
                CDR.BRANCH_CODE = Branchlist;
                CDR.flag = "Bind_Data";

                DataSet dss = CDR.Report_data();
                DataTable dt = new DataTable();
                if (dss.Tables[0].Rows.Count > 0)
                {

                    ViewState["Excel"] = dss.Tables[0];
                    GvReport.DataSource = dss.Tables[0];
                    GvReport.DataBind();

                    ViewState["str_CSV"] = dss.Tables[1].Rows[0][0].ToString();


                    lbl_count.Text = "Row Count : " + Convert.ToString(dss.Tables[0].Rows.Count);
                    lbl_cols_count.Text = "Column Count : " + Convert.ToString(dss.Tables[0].Columns.Count);

                }
                else
                {
                    DataTable dt_empty = new DataTable();
                    GvReport.DataSource = dt_empty;
                    GvReport.DataBind();
                    lbl_count.Text = "Row Count : 0";
                    lbl_cols_count.Text = "Column Count : 0";
                }
            }
            else
            {
                //Alert_msg("Select Group", ListBox1.Text);
                Alert_msg("Select Group", ddl_Branch.SelectedItem.Text);
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
        /*
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
         * */

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


    private void load_Report_Name()
    {
        DataSet ds = new DataSet();

        CDR.flag = "Bind_Imp_Name";
        CDR.BRANCH_CODE = SELECT_BRANCH;

        ds = CDR.Report_data();

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlimpname.DataSource = ds.Tables[0];
            ddlimpname.DataValueField = "Imp_name";
            ddlimpname.DataTextField = "Imp_name";
            ddlimpname.DataBind();

            ddlimpname.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddlimpname.SelectedIndex = 0;
        }
        else
        {
            ddlimpname.Items.Insert(0, new ListItem(string.Empty, string.Empty));
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
        exportfile("Excel");
    }

    private void exportfile(string filetype)
    {
        if (GvReport.Rows.Count > 0)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)ViewState["Excel"];
            if (dt.Rows.Count > 0)
            {
                if (filetype == "Excel")
                {
                    ExportExcel(dt, "Import-CustomsDuty-Report");
                }
            }
            else
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('No Records Found', 'Import - Custom Duty Report ', function (r) {});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            }
        }
        else
        {
            string prompt = "<script>$(document).ready(function(){{jAlert('No Records Found', 'Import - Custom Duty Report ', function (r) {});}});</script>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
        }
    }

    protected void btnRdlc_Click(object sender, EventArgs e)
    {

        exportfile("PDF");
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

        //Build the CSV file data as a Comma separated string.
        string csv = string.Empty;

        
        foreach (DataColumn column in dtdata.Columns)
        {
            if (column.ToString() != "JOBNO" && column.ToString() != "BRANCHCODE" && column.ToString() != "INVOICE_SLNO")
            {
                //Add the Header row for CSV file.
                csv += column.ColumnName + ',';
            }
        }
       
        //Add new line.
        csv += "\r\n";
        
        foreach (DataRow row in dtdata.Rows)
        {
            foreach (DataColumn column in dtdata.Columns)
            {
                if (column.ToString() != "JOBNO" && column.ToString() != "BRANCHCODE" && column.ToString() != "INVOICE_SLNO")
                {
                    if (column.ToString() == "Item_Slno")
                    {
                        csv += row[column.ColumnName].ToString().Replace(",", " ") + "0" + ',';
                    }
                    else if (column.ToString() == "Freight_invoice_date")
                    {
                        csv += row[column.ColumnName].ToString().Replace(".", "-") + ',';
                    }
                    else
                    {
                        csv += row[column.ColumnName].ToString().Replace(",", " ") + ',';
                    }
                }
            }

            //Add new line.
            csv += "\r\n";
        }
       
       
        //csv = ViewState["str_CSV"].ToString().Replace("\r\n,", "\r\n");// hide on 14-06-2022 for Data Overloading issue

        //string filename1 = "Customs_" + dtdata.Rows[0]["BE_NO"].ToString() + "_" + dtdata.Rows[0]["Vendor_Name"].ToString() + "_" + dtdata.Rows[0]["TRANSPORT_MODE"].ToString() + dtdata.Rows[0]["BE_DATE"].ToString().Replace("/", "").Replace(" ", "") + ".csv";
        string filename1 = "Customs_" + dtdata.Rows[0]["BE_NO"].ToString() + "_" + dtdata.Rows[0]["BE_DATE"].ToString().Replace("/", "").Replace(" ", "") + "_" + dtdata.Rows[0]["Vendor_Name"].ToString() + "_" + dtdata.Rows[0]["TRANSPORT_MODE"].ToString() + ".csv";


        //Download the CSV file.
        Response.Clear();
        Response.Buffer = true;
        //Response.AddHeader("content-disposition", "attachment;filename=SqlExport.csv");
        Response.AddHeader("content-disposition", "attachment;filename= " + filename1);
        Response.Charset = "";
        Response.ContentType = "application/text";
        Response.Output.Write(csv);
        Response.Flush();
        Response.End();
        // System.IO.File.WriteAllText(errorFolder, csv);

        /*
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename= " + filename + ".csv");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-csv";
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
        */
    }

    protected void btn_Post_Data_Click(object sender, EventArgs e)
    {
        DataTable ds_grid = new DataTable();
        ds_grid = (DataTable)ViewState["Excel"];

        if (ds_grid.Rows.Count > 0)
        {
            if (ds_grid.Rows[0]["Vendor_Name"].ToString() != "")
            {

                string errorFolder = "", csv = "";

                string SELECT_TYPE = HttpContext.Current.Session["SELECT_TYPE"].ToString();
                if (SELECT_TYPE == "Branchwise Job")
                {
                    errorFolder = HttpContext.Current.Server.MapPath("~/Submission/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + HttpContext.Current.Session["currentbranch"].ToString() + "/" + currentuser + "/" + "Customs_Duty_Rpt" + "/");

                }
                else if (SELECT_TYPE == "Areawise Job")
                {
                    errorFolder = HttpContext.Current.Server.MapPath("~/Submission/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + HttpContext.Current.Session["GroupName"].ToString() + "/" + currentuser + "/" + "Customs_Duty_Rpt" + "/");
                }
                else
                {
                    errorFolder = HttpContext.Current.Server.MapPath("~/Submission/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + currentuser + "/" + "Customs_Duty_Rpt" + "/");
                }

                if (Directory.Exists(errorFolder) == false)
                {
                    Directory.CreateDirectory(errorFolder);
                }



                DateTime dt_time = DateTime.Now;
                foreach (DataColumn column in ds_grid.Columns)
                {
                    if (column.ToString() != "JOBNO" && column.ToString() != "BRANCHCODE" && column.ToString() != "INVOICE_SLNO")
                    {
                        //Add the Header row for CSV file.
                        csv += column.ColumnName + ',';
                    }
                }

                //Add new line.
                csv += "\r\n";

                foreach (DataRow row in ds_grid.Rows)
                {
                    foreach (DataColumn column in ds_grid.Columns)
                    {
                        if (column.ToString() != "JOBNO" && column.ToString() != "BRANCHCODE" && column.ToString() != "INVOICE_SLNO")
                        {

                            if (column.ToString() == "Item_Slno")
                            {
                                csv += row[column.ColumnName].ToString().Replace(",", " ") + "0" + ',';
                            }
                            else if (column.ToString() == "Freight_invoice_date")
                            {
                                csv += row[column.ColumnName].ToString().Replace(".", "-") + ',';
                            }
                            else
                            {
                                csv += row[column.ColumnName].ToString().Replace(",", " ") + ',';
                            }
                        }
                    }

                    //Add new line.
                    csv += "\r\n";
                }


                //csv = ViewState["str_CSV"].ToString().Replace("\r\n,", "\r\n");// hide on 14-06-2022 for Data Overloading issue

                //string localDestnDir = errorFolder + "Customs_" + ds_grid.Rows[0]["BE_NO"].ToString() + "_" + ds_grid.Rows[0]["Vendor_Name"].ToString() + "_" + ds_grid.Rows[0]["TRANSPORT_MODE"].ToString() + ds_grid.Rows[0]["BE_DATE"].ToString().Replace("/", "").Replace(" ", "") + ".CSV";
                string localDestnDir = errorFolder + "Customs_" + ds_grid.Rows[0]["BE_NO"].ToString() +"_"+ ds_grid.Rows[0]["BE_DATE"].ToString().Replace("/", "").Replace(" ", "") + "_" + ds_grid.Rows[0]["Vendor_Name"].ToString() + "_" + ds_grid.Rows[0]["TRANSPORT_MODE"].ToString()  + ".CSV";


                System.IO.DirectoryInfo di = new DirectoryInfo(errorFolder);

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }

                //System.IO.File.WriteAllText(errorFolder + "/" + "Customs_Duty_Rpt.csv", csv);
                System.IO.File.WriteAllText(localDestnDir, csv);



                //string ftp = "ftp://74.63.193.105/";
                //string uname = "tallyftpuser";
                //string pwd = "+8mS4$n=m@9$Zw%";
                /*
                string ftp = "ftp://74.63.193.105/";
                string uname = "tallyftpuser";
                string pwd = "+8mS4$n=m@9$Zw%";
                */

                /* hide on 20-05-2022
                string ftp = "ftp://13.127.150.99/";
                string uname = "Fairmacs_test";
                string pwd = "Fairmac@2021#!";
                */

                string ftp = "ftp://13.127.150.99/";
                string uname = "Fairmacs_PRD";
                string pwd = "FairmacsPRD";

                string ftpFolder1 = "";
                ftpFolder1 = "/data/Fairmacs";
                //DateTime dt_time = DateTime.Now;

                byte[] fileBytes = null;

                string fileName1 = Path.GetFileName(localDestnDir);

                using (StreamReader fileStream = new StreamReader(localDestnDir))
                {
                    fileBytes = Encoding.UTF8.GetBytes(fileStream.ReadToEnd());
                    fileStream.Close();
                }
                try
                {
                    //FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + "/data/Fairmacs" + "/" + "DEV" + "/" + fileName1);
                    //FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + "Archive" + "/" + fileName1);
                    //FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + "data/Fairmacs" + "/" + "PRD" + "/" + fileName1);
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + fileName1);
                    request.Credentials = new NetworkCredential(uname, pwd);
                    //request.Method = WebRequestMethods.Ftp.MakeDirectory;

                    request.Method = WebRequestMethods.Ftp.UploadFile;
                    request.ContentLength = fileBytes.Length;
                    request.UsePassive = true;
                    request.UseBinary = true;

                    request.ServicePoint.ConnectionLimit = fileBytes.Length;
                    request.EnableSsl = false;

                    using (Stream requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(fileBytes, 0, fileBytes.Length);
                        requestStream.Close();
                    }

                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                    response.Close();

                    //----------To Insert Jobno in IMP_CUSTOMS_DUTY_RPT_FAIMACS table-----------------------
                    int x = Rpt_Status_Insert();
                    if (x == 1)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('File Sent Successfully..')", true);
                    }

                }
                catch (Exception ex)
                {
                    Connection.Error_Msg(ex.Message);
                }

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Vendor Name - Should not be Empty')", true);
            }
        }
        
    }


    private int Rpt_Status_Insert()
    {
        int Result = 0;
        DataSet ds1 = new DataSet();

        CDR.Jobno = ddlJobNo.SelectedItem.Text;
        CDR.From_date = "C";
        CDR.To_date = "";
        CDR.Imp_Name = Connection.Current_User();
        CDR.BRANCH_CODE = Connection.Current_Branch();
        CDR.flag = "Insert";
        ds1 = CDR.Report_data();

        Result = CDR.result;
        return Result;
    }
    protected void btn_Release_Click(object sender, EventArgs e)
    {
        DataSet ds1 = new DataSet();

        CDR.Jobno = ddlJobNo.SelectedItem.Text;
        CDR.From_date = "C";
        CDR.To_date = "";
        CDR.Imp_Name = Connection.Current_User();
        CDR.BRANCH_CODE = Connection.Current_Branch();
        CDR.flag = "Filed_Job_Release";
        ds1 = CDR.Report_data();

    }
}