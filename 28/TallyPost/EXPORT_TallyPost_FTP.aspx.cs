using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Globalization;
using BussinessObject;
using System.Text;
using System.Net;
using System.Xml;


public partial class GST_Imp_Invoice_Job_Search : ThemeClass
{
    AppSession aps = new AppSession();
    GST_Imp_Invoice BI = new GST_Imp_Invoice();
    Billing_UserBO ObjUBO = new Billing_UserBO();
    Billing_IMP_EXP_Tally objTally = new Billing_IMP_EXP_Tally();
    DataTable dt_select_grid = new DataTable();

    int result = 0;
    int select_grid_count = 0;

    public string Working_Period;

    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };

    string Start_date = string.Empty , End_date = string.Empty, From_month = string.Empty, To_month = string.Empty;

    private DataSet ds = new DataSet();
    private DataSet ds_bill = new DataSet();
    DataSet ds1 = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        Working_Period = Session["WorkingPeriod"].ToString();
        
        hdrowindex.Value = String.Empty;
        hdBill_invno.Value = String.Empty;

        if (!IsPostBack)
        {
            btnSearch_Click(sender, e);
        }
    }

    public void Selectd_grid()
    {
        dt_select_grid.Columns.Add("BILL_INV_NO");

        for (int i = 0; i < gvdetails.Rows.Count; i++)
        {
            CheckBox Select = (CheckBox)gvdetails.Rows[i].Cells[0].FindControl("chk");

            if (Select.Checked == true)
            {
                dt_select_grid.Rows.Add(gvdetails.Rows[i].Cells[1].Text);
                select_grid_count = i + 1;

            }
        }
    }

    protected void btnPostToTally_Click(object sender, EventArgs e)
    {
        DataSet ds_charge = new DataSet();
        DataSet ds_charge_all = new DataSet();

        try
        {
            Selectd_grid();

            if (select_grid_count > 0)
            {
                for (int i = 0; i < dt_select_grid.Rows.Count; i++)
                {
                    ObjUBO.BILL_INV_NO = dt_select_grid.Rows[i][0].ToString();
                    ObjUBO.from_date = txtJobDate.Text;
                    ObjUBO.todate = txttodate.Text;
                    ObjUBO.Flag = "Bind_Bill_inv_No_All_Search";
                    ObjUBO.BranchCode = Connection.Get_Company_Type();
                    ds_charge = objTally.Select_IMP_INV(ObjUBO, "EXPORT_TALLY_POST_GST_INVOICE_SEARCH_EXCEL");

                    ds_charge_all.Merge(ds_charge);

                    if (ds_charge.Tables[0].Rows.Count > 0)
                    {
                        Update_Status(ObjUBO.BILL_INV_NO, "Checked");
                    }
                }


                string localDestnDir = "";
                string ftpFolder1 = "";

                if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "10")
                {
                    ftpFolder1 = "/ROYAL/";
                }
                else if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "2")
                {
                    ftpFolder1 = "/ORIENTAL/";
                }
                else if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "4")
                {
                    ftpFolder1 = "/ROYAL/";
                }
                else if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "268")
                {
                    ftpFolder1 = "/VSM/";
                }
                else if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "287")
                {
                    ftpFolder1 = "/FALCONAIR/";
                }
                else if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "293")
                {
                    ftpFolder1 = "/PARAMOUNT/";
                }
                else if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "354")
                {
                    ftpFolder1 = "/LKSGLOBAL/";
                }
                else if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "382")
                {
                    ftpFolder1 = "/ACFA/";
                }
                else
                {
                    ftpFolder1 = "/UNKNOWN/";
                }

                localDestnDir = HttpContext.Current.Server.MapPath("~/Submission/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + HttpContext.Current.Session["currentbranch"].ToString() + "/" + HttpContext.Current.Session["currentuser"].ToString() + "/" + "TALLY" + "/");

                if (Directory.Exists(localDestnDir + "/" + ftpFolder1))
                {

                }
                else
                {
                    DirectoryInfo di = Directory.CreateDirectory(localDestnDir + "/" + ftpFolder1);
                }

                if (Directory.Exists(localDestnDir + "/" + ftpFolder1 + "/" + "Log"))
                {

                }
                else
                {
                    DirectoryInfo di = Directory.CreateDirectory(localDestnDir + "/" + ftpFolder1 + "/" + "Log");
                }


                DateTime dt_time = DateTime.Now;

                ExportToCSV_File(ds_charge_all.Tables[0], localDestnDir + "/" + ftpFolder1 + "\\" + "EXPORT_TALLY" + Convert.ToString(dt_time).Replace("/", "_").Replace(" ", "_").Replace(":", "_") + ".CSV");

                //ExportToExcel_new(ds_charge_all, localDestnDir + "/" + ftpFolder1 + "\\" + "EXPORT_TALLY" + Convert.ToString(dt_time).Replace("/", "_").Replace(" ", "_").Replace(":", "_") + ".xls");
                //ExportToExcel_new(ds_charge_all, localDestnDir + "/" + ftpFolder1 + "\\" + "EXPORT_TALLY" + Convert.ToString(dt_time).Replace("/", "_").Replace(" ", "_").Replace(":", "_") + ".xlsx");



                //***************************************** files Upload to FTP Folder **********************************************//
                /* .in server credentials
                //string ftp = "ftp://115.112.232.213:21/";
                string ftp = "ftp://182.76.213.91:21/";
                string uname = "ftpuser";
                //string pwd = "rtstallypost@#1234#@";
                //string pwd = "qwerty12345";
                string pwd = "Rts%57TckFt5";
                */

                // co.in server credentials
                string ftp = "ftp://74.63.193.105/";
                string uname = "tallyftpuser";
                string pwd = "+8mS4$n=m@9$Zw%";

                byte[] fileBytes = null;
                //string fileName1 = Path.GetFileName(localDestnDir + "/" + ftpFolder1 + "\\" + "EXPORT_TALLY" + Convert.ToString(dt_time).Replace("/", "_").Replace(" ", "_").Replace(":", "_") + ".xls");
                //string fileName1 = Path.GetFileName(localDestnDir + "/" + ftpFolder1 + "\\" + "EXPORT_TALLY" + Convert.ToString(dt_time).Replace("/", "_").Replace(" ", "_").Replace(":", "_") + ".xlsx");
                string fileName1 = Path.GetFileName(localDestnDir + "/" + ftpFolder1 + "\\" + "EXPORT_TALLY" + Convert.ToString(dt_time).Replace("/", "_").Replace(" ", "_").Replace(":", "_") + ".CSV");



                //if (fileName1.EndsWith(".xls"))
                //{
                //    File.Move(localDestnDir + "/" + ftpFolder1 + "\\" + "EXPORT_TALLY", Path.ChangeExtension(fileName1, ".xlsx"));
                //}

                //using (StreamReader fileStream = new StreamReader(localDestnDir + "/" + ftpFolder1 + "\\" + "EXPORT_TALLY" + Convert.ToString(dt_time).Replace("/", "_").Replace(" ", "_").Replace(":", "_") + ".xls"))
                //using (StreamReader fileStream = new StreamReader(localDestnDir + "/" + ftpFolder1 + "\\" + "EXPORT_TALLY" + Convert.ToString(dt_time).Replace("/", "_").Replace(" ", "_").Replace(":", "_") + ".xlsx"))
                using (StreamReader fileStream = new StreamReader(localDestnDir + "/" + ftpFolder1 + "\\" + "EXPORT_TALLY" + Convert.ToString(dt_time).Replace("/", "_").Replace(" ", "_").Replace(":", "_") + ".CSV"))
                {
                    fileBytes = Encoding.UTF8.GetBytes(fileStream.ReadToEnd());
                    fileStream.Close();
                }
                try
                {
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + ftpFolder1 + "/" + "TallyPost" + "/" + fileName1);
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

                    if (ds1 != null)
                    {
                        gvdetails.DataSource = ds1;
                        gvdetails.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    Connection.Error_Msg(ex.Message);
                }

                //gridbind(Int32.Parse(ddlSelectPageno.SelectedValue));
            }
            else
            {
                Alert_msg("Select Bill Invoice Number");
            }
            gridbind(1);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        ds_charge.Dispose();
    }

    public int Update_Status(string BillNo, string Status)
    {
        int ii = 0;
        ObjUBO.BILL_INV_NO = BillNo.Replace("-", "").Replace("/", "");
        ObjUBO.Flag = "Update_Status";
        ObjUBO.BranchCode = Connection.Get_Company_Type();
        ObjUBO.BILL_TYPE = Status;
        ObjUBO.from_date = txtJobDate.Text;
        ObjUBO.todate = txttodate.Text;

        //ds_bill = objTally.Select_IMP_INV(ObjUBO, "TALLY_POST_IMPORT_GST_INVOICE_SEARCH");
        ds_bill = objTally.Select_IMP_INV(ObjUBO, "EXPORT_TALLY_POST_GST_INVOICE_SEARCH_NEW");
        ObjUBO.startRowIndex = "1";
        int totalrows = 1;
        ObjUBO.totalRows = Convert.ToString(totalrows);
        ObjUBO.maximumRows = Convert.ToString(gvdetails.PageSize);
        ii = objTally.result;
        return ii;
    }


    public void gridbind(int currentPageNumber1)
    {
        DataView view = new DataView();
        DataTable d = new DataTable();


        //ObjUBO.BILL_INV_NO = ddl_BIllInvoiceNo.SelectedItem.Text;
        ObjUBO.BILL_INV_NO = txt_Bill_Inv_No.Text;
        ObjUBO.JOBNO = "";

        ObjUBO.from_date = txtJobDate.Text;
        ObjUBO.todate = txttodate.Text;
        ObjUBO.Flag = "Bind_Bill_inv_No";
        ObjUBO.BranchCode = Connection.Get_Company_Type();
        ObjUBO.BILL_TYPE = ddl_Status.SelectedItem.Text;
        ObjUBO.startRowIndex = Convert.ToString(currentPageNumber1);
        //int totalrows = ds1.Tables[0].Rows.Count;

        int totalrows = 1;
        ObjUBO.totalRows = Convert.ToString(totalrows);
        ObjUBO.maximumRows = Convert.ToString(gvdetails.PageSize);
        //CalculateTotalPages(totalrows);

        if (ObjUBO.BILL_TYPE == "Error List")
        {
            ObjUBO.maximumRows = Convert.ToString(7);
        }

        //ds_bill = objTally.Select_IMP_INV(ObjUBO, "EXPORT_TALLY_POST_GST_INVOICE_SEARCH");
        ds_bill = objTally.Select_IMP_INV(ObjUBO, "EXPORT_TALLY_POST_GST_INVOICE_SEARCH_NEW");


        ds1 = ds_bill;

        //Grid_Total(currentPageNumber1, objTally.result);

        ds1.Tables[0].Columns.Add("ERROR_STATUS");

        //Add_Pageno(CalculateTotalPages(ds1.Tables[0].Rows.Count));

        ViewState["CurrentPageNO"] = currentPageNumber1;

        if (ds1.Tables[0].Rows.Count > 0)
        {
            gvdetails.DataSource = ds1.Tables[0];
            gvdetails.DataBind();
        }
        else
        {
            DataTable dt = new DataTable();
            gvdetails.DataSource = dt;
            gvdetails.DataBind();
            gvdetails.EmptyDataText = "No Record Found";
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        gridbind(1);
    }

    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var row = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            if (ddl_Status.SelectedItem.Text == "Posted")
            {
                e.Row.Cells[0].Enabled = false;
                e.Row.Cells[1].Width = 150;
                e.Row.Cells[6].Font.Bold = true;
                e.Row.Cells[6].ForeColor = System.Drawing.Color.Green;
                e.Row.Cells[6].Width = 100;

                gvdetails.Columns[3].Visible = true;
                gvdetails.Columns[4].Visible = true;
                gvdetails.Columns[5].Visible = true;
                gvdetails.Columns[6].Visible = true;
                gvdetails.Columns[7].Visible = false;
                gvdetails.Columns[8].Visible = true;
                //gvdetails.Columns[9].Visible = true;
            }
            else if (ddl_Status.SelectedItem.Text == "Waiting List")
            {
                e.Row.Cells[0].Enabled = true;
                e.Row.Cells[1].Width = 150;
                e.Row.Cells[6].Text = "Waiting";
                e.Row.Cells[6].Font.Bold = true;
                e.Row.Cells[6].ForeColor = System.Drawing.Color.Blue;

                gvdetails.Columns[3].Visible = true;
                gvdetails.Columns[4].Visible = true;
                gvdetails.Columns[5].Visible = true;
                gvdetails.Columns[6].Visible = true;
                gvdetails.Columns[7].Visible = false;
                gvdetails.Columns[8].Visible = true;
                //gvdetails.Columns[9].Visible = true;
            }
            else if (ddl_Status.SelectedItem.Text == "Not Posted")
            {
                e.Row.Cells[0].Enabled = true;
                e.Row.Cells[1].Width = 150;
                e.Row.Cells[6].Text = "Not Posted";
                e.Row.Cells[6].Font.Bold = true;
                e.Row.Cells[6].ForeColor = System.Drawing.Color.Blue;
                e.Row.Cells[6].Width = 100;

                gvdetails.Columns[3].Visible = true;
                gvdetails.Columns[4].Visible = true;
                gvdetails.Columns[5].Visible = true;
                gvdetails.Columns[6].Visible = true;
                gvdetails.Columns[7].Visible = false;
                gvdetails.Columns[8].Visible = true;
                //gvdetails.Columns[9].Visible = true;
            }
            else if (ddl_Status.SelectedItem.Text == "Error List")
            {
                gvdetails.Columns[3].Visible = false;
                gvdetails.Columns[4].Visible = false;
                gvdetails.Columns[5].Visible = false;
                gvdetails.Columns[6].Visible = true;
                gvdetails.Columns[7].Visible = false;
                gvdetails.Columns[8].Visible = false;
                //gvdetails.Columns[9].Visible = false;

                e.Row.Cells[6].Font.Bold = true;
                e.Row.Cells[6].ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                e.Row.Cells[6].Font.Bold = true;
                e.Row.Cells[6].ForeColor = System.Drawing.Color.Blue;
            }
        }
    }

    private void Load_Grid()
    {
        DataSet ds1 = new DataSet();
        if (txtJobDate.Text != string.Empty || txttodate.Text != string.Empty)
        {
            ObjUBO.from_date = txtJobDate.Text;
            ObjUBO.todate = txttodate.Text;
        }
        else
        {
            //if (ddlmonth.SelectedItem.Text != string.Empty)
            //{
            //    arr_Month = ddlmonth.SelectedValue.ToString().Split('-');
            //    ObjUBO.from_date = arr_Month[0];
            //    ObjUBO.todate = arr_Month[1];
            //}
            //else
            //{
            //    ObjUBO.from_date = txtJobDate.Text;
            //    ObjUBO.todate = txttodate.Text;
            //}
        }

        //ObjUBO.Imp_Name = ddlImp_name.SelectedItem.Text;
        //ObjUBO.CHARGE_NAME = Connection.Company_License();
        //ObjUBO.Flag = "Grid_Search";
        //ds1 = BI.BILL_IMPORT_JOB_INV_SEARCH(ObjUBO);
        //gvdetails.DataSource = ds1.Tables[0];
        //gvdetails.DataBind();

    }
   
    //private void Load_Month()
    //{
    //    DataSet ds = new DataSet();
    //    if (Connection.Company_License().ToLower() == "eri00247")
    //    {
    //        arr = ("01-Apr-2016 - 31-Dec-2018").Split('-');
    //    }
    //    else
    //    {
    //    arr = Working_Period.Split('-');
    //    }
    //    Start_date = arr[0] + '-' + arr[1] + '-' + arr[2];
    //    End_date = arr[3] + '-' + arr[4] + '-' + arr[5];

    //    ObjUBO.from_date = Start_date;
    //    ObjUBO.todate = End_date;
    //    ObjUBO.Flag = "Month";
    //    ds = BI.IMP_EXP_Month(ObjUBO);

    //    ddlmonth.DataSource = ds.Tables[0];
    //    ddlmonth.DataTextField = "TheMonth";
    //    ddlmonth.DataValueField = "TheMonth_No";
    //    ddlmonth.DataBind();
       
    //    ddlmonth.Items.Insert(ddlmonth.Items.Count, new ListItem(String.Empty, String.Empty));

    //    if (Connection.Company_License().ToLower() == "eri00247")
    //    {
    //        ddlmonth.SelectedValue = ds.Tables[1].Rows[1][0].ToString();
    //    }
    //    else
    //    {
    //        ddlmonth.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
    //    }
    //}

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'TALLY POST', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    private void getFileList()
    {
        string localDestnDir = "";
        /*.in server credentials
        //string ftp = "ftp://115.112.232.213:21/";
        string ftp = "ftp://182.76.213.91:21/";
        string uname = "ftpuser";
        //string pwd = "rtstallypost@#1234#@";
        //string pwd = "qwerty12345";
        string pwd = "Rts%57TckFt5";
        */


        // co.in server credentials
        string ftp = "ftp://74.63.193.105/";
        string uname = "tallyftpuser";
        string pwd = "+8mS4$n=m@9$Zw%";

        localDestnDir = HttpContext.Current.Server.MapPath("~/Submission/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + HttpContext.Current.Session["currentbranch"].ToString() + "/" + HttpContext.Current.Session["currentuser"].ToString() + "/" + "TALLY" + "/");

        string ftpFolder1 = "";

        if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "10")
        {
            ftpFolder1 = "/ROYAL/";
        }
        else if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "2")
        {
            ftpFolder1 = "/ORIENTAL/";
        }
        else if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "4")
        {
            ftpFolder1 = "/ROYAL/";
        }
        else if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "268")
        {
            ftpFolder1 = "/VSM/";
        }
        else if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "287")
        {
            ftpFolder1 = "/FALCONAIR/";
        }
        else if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "293")
        {
            ftpFolder1 = "/PARAMOUNT/";
        }
        else if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "354")
        {
            ftpFolder1 = "/LKSGLOBAL/";
        }
        else if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "382")
        {
            ftpFolder1 = "/ACFA/";
        }
        else
        {
            ftpFolder1 = "/UNKNOWN/";
        }


        List<string> files = new List<string>();

        try
        {

            //Create FTP request

            //FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(ftp + "/" + ftpFolder1 + "/" + "TallyPost" + "//" + "Log"); --- hide on 17/02/18 by chithra
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(ftp + "/" + ftpFolder1 + "/" + "TallyPost" + "//" + "Log" + "//");

            request.Method = WebRequestMethods.Ftp.ListDirectory;
            request.Credentials = new NetworkCredential(uname, pwd);
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = false;

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            while (!reader.EndOfStream)
            {
                files.Add(reader.ReadLine());
            }

            //Clean-up
            reader.Close();
            responseStream.Close(); //redundant
            response.Close();
        }
        catch (Exception)
        {
            //MessageBox.Show("There was an error connecting to the FTP Server");
        }


        //If the list was successfully received, display it to the user
        //through a dialog
        if (files.Count != 0)
        {
            foreach (string file in files)
            {
                string filename = "";
                if (file.Contains("."))
                {
                    string[] f1 = file.Split('.');
                    filename = f1[0];
                }
                else
                {
                    filename = file;
                }

                FtpWebRequest requestFileDownload = (FtpWebRequest)WebRequest.Create(ftp + "/" + ftpFolder1 + "/" + "TallyPost" + "//" + "Log" + "//" + file.Replace("/", "-"));
                requestFileDownload.Credentials = new NetworkCredential(uname, pwd);
                //requestFileDownload.Method = WebRequestMethods.Ftp.MakeDirectory;

                requestFileDownload.Method = WebRequestMethods.Ftp.DownloadFile;
                FtpWebResponse responseFileDownload = (FtpWebResponse)requestFileDownload.GetResponse();
                Stream responseStream = responseFileDownload.GetResponseStream();

                // CHANGE THE FILE EXTENSION xml to txt File
                FileStream writeStream = new FileStream(Path.ChangeExtension(localDestnDir + "/" + ftpFolder1 + "/" + "Log" + "/" + filename.Replace("/", "-") + ".xml", ".txt"), FileMode.Create);

                int Length = 2048;
                Byte[] buffer = new Byte[Length];
                int bytesRead = responseStream.Read(buffer, 0, Length);
                while (bytesRead > 0)
                {
                    writeStream.Write(buffer, 0, bytesRead);
                    bytesRead = responseStream.Read(buffer, 0, Length);
                }
                responseStream.Close();
                writeStream.Close();
                requestFileDownload = null;

                string ALL_Lines = "";

                //READ TEXT FILE - LINE BY LINE
                string[] lines = System.IO.File.ReadAllLines(localDestnDir + "/" + ftpFolder1 + "/" + "Log" + "/" + filename.Replace("/", "-") + ".txt");
                int cnt = 0;
                foreach (string line in lines)
                {
                    if (cnt == 0)
                    {
                    }
                    else
                    {
                        ALL_Lines += "\t" + line;
                    }
                    //string lines = line.Replace(" ", "");
                    if (line.Contains("Errors  : 0"))
                    {
                        Update_Status(filename, "Posted");
                    }
                    else if (line.Contains("Created : 0"))
                    {
                        Update_Status(filename, "Error" + ALL_Lines);
                    }
                    else
                    {
                    }
                    cnt = cnt + 1;
                }

                //DELETE THE FILES FROM FTP SERVER

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + "/" + ftpFolder1 + "/" + "TallyPost" + "//" + "Log" + "//" + file.Replace("/", ""));
                //FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://mazedemo.3utilities.com:2121//ROYAL//TallyPost//Log//2.txt");
                //FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + "/" + ftpFolder1 + "/" + "TallyPost" + "//" + "Log" + "//" + "2" + ".txt");

                request.Credentials = new NetworkCredential(uname, pwd);

                request.Method = WebRequestMethods.Ftp.DeleteFile;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Console.WriteLine("Delete status: {0}", response.StatusDescription);
                response.Close();

            }

        }
    }

    private void ExportToCSV_File(DataTable dt1, string filePath)
    {
        string csv = string.Empty;

        foreach (DataColumn column in dt1.Columns)
        {
            //Add the Header row for CSV file.
            csv += column.ColumnName + ',';
        }

        //Add new line.
        csv += "\r\n";

        foreach (DataRow row in dt1.Rows)
        {
            foreach (DataColumn column in dt1.Columns)
            {
                //Add the Data rows.
                csv += row[column.ColumnName].ToString().Trim().Replace(",", ";") + ',';

            }
            //Add new line.
            csv += "\r\n";
        }

        string datetime = Convert.ToString(DateTime.Today.ToString("dd-MM-yyyy")).Trim();
        //string filepath = "C:\\Users\\Prateek\\Desktop\\MMR New  27-07 -\\Domestic\\";
        //string filename = @"BILLING_BOOK_NO" + "_4005" + "_" + datetime + ".XLSX";
        string combinepath = filePath.Replace(".xlsx", ".CSV");
        System.IO.File.WriteAllText(combinepath, csv);
    }

    protected void btn_Refresh_Click(object sender, EventArgs e)
    {
        getFileList();
        gridbind(1);
    }
}