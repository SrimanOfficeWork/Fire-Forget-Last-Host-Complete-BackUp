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
using Microsoft.ApplicationBlocks.Data;
using System.IO;
using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using exc = Microsoft.Office.Interop.Excel;



/// <summary>
/// Summary description for Export_MIS_2
/// </summary>
public class Export_MIS_2
{

    SqlDataAdapter da;
    SqlDataReader dr;
    DataSet ds = new DataSet();
    SqlCommand cmd;
    DataTable dt = new DataTable();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    public int result = 0;

    private string _jobno;
    private string _jobdate;
    private string _Exp_name;
    private string _branch;
    private string _todate;
    private string _Ename;
    private string _Tr_mode;

    private string _SB_type;
    private string _port;
    private string _Report_cat;
    private string _search_con;
    private string _country, _UserID;
    private string _CusHouse;

    public string JobNo
    {
        get { return _jobno; }
        set { _jobno = value; }
    }
    public string Jobdate
    {
        get { return _jobdate; }
        set { _jobdate = value; }
    }
    public string Exp_name
    {
        get { return _Exp_name; }
        set { _Exp_name = value; }
    }
    public string Branch
    {
        get { return _branch; }
        set { _branch = value; }
    }
    public string To_date
    {
        get { return _todate; }
        set { _todate = value; }
    }
    public string Ename
    {
        get { return _Ename; }
        set { _Ename = value; }
    }
    public string Tr_mode
    {
        get { return _Tr_mode; }
        set { _Tr_mode = value; }
    }
    public string SB_type
    {
        get { return _SB_type; }
        set { _SB_type = value; }
    }
    public string Port
    {
        get { return _port; }
        set { _port = value; }
    }
    public string Report_cat
    {
        get { return _Report_cat; }
        set { _Report_cat = value; }
    }

    public string Search_con
    {
        get { return _search_con; }
        set { _search_con = value; }
    }
    public string Country
    {
        get { return _country; }
        set { _country = value; }
    }
    public string UserID
    {
        get { return _UserID; }
        set { _UserID = value; }
    }


    public string CusHouse
    {
        get { return _CusHouse; }
        set { _CusHouse = value; }
    }

    public DataTable Export_MIS_Statement()
    {
        try
        {

            string[] arr = new string[] { };
            string[] arr2 = new string[] { };
            if (Jobdate != string.Empty && Jobdate != null)
            {
                arr = Jobdate.Split('/');
                Jobdate = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (To_date != string.Empty && To_date != null)
            {
                arr2 = To_date.Split('/');
                To_date = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }
            SqlParameter[] param = new SqlParameter[15];

            param[1] = new SqlParameter("@jobno", JobNo == string.Empty ? string.Empty : JobNo);

            param[2] = new SqlParameter("@from_date", Jobdate == string.Empty ? string.Empty : Jobdate);
            param[3] = new SqlParameter("@to_date", To_date == string.Empty ? string.Empty : To_date);

            param[4] = new SqlParameter("@Exp_name", Exp_name = Exp_name == "All" ? string.Empty : Exp_name);
            param[5] = new SqlParameter("@Branch", Branch == string.Empty ? string.Empty : Branch);

            param[6] = new SqlParameter("@Name", Ename);

            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_MIS_statement_Report", param);
            result = Convert.ToInt32(param[7].Value.ToString());

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds.Tables[0];
    }




    public void Open_MIS_XLs_Expeditors_Rpt(string JobNo_, string Jobdate_, string Exp_name_, string To_date_, string Branch_, string p_Type)
    {
        string ClientNm, P_clientName;
        HttpResponse Response = HttpContext.Current.Response;
        JobNo = JobNo_;
        Jobdate = Jobdate_;
        Exp_name = Exp_name_;
        To_date = To_date_ == " " ? string.Empty : To_date_;
        Branch = Branch_;
        Ename = "Bind_Grid_Details";

        ClientNm = Exp_name;


        if (ClientNm.Contains(" "))
        {
            P_clientName = ClientNm.Replace(" ", "_");
        }
        else
        {
            P_clientName = ClientNm;
        }


        DataView dv = new DataView(Export_MIS_Statement());
        DataTable dt = dv.ToTable();
        if (p_Type == "excel")
        {

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + P_clientName + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                GridView gv = new GridView();

                gv.HeaderStyle.BackColor = System.Drawing.Color.RoyalBlue;
                gv.HeaderStyle.ForeColor = System.Drawing.Color.White;
                gv.AllowPaging = false;
                gv.DataSource = dt;
                gv.DataBind();


                foreach (TableCell cell in gv.HeaderRow.Cells)
                {
                    cell.BackColor = gv.HeaderStyle.BackColor;
                }

                gv.RenderControl(hw);

                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }

        }

    }


    public void Open_EXP_MIS_XLs_Mail(string JobNo_, string Jobdate_, string Exp_name_, string To_date_, string Branch_, string p_Type)
    {
        string Grid_Excel = HttpContext.Current.Server.MapPath("~/Submission/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + HttpContext.Current.Session["currentbranch"].ToString() + "/" + HttpContext.Current.Session["currentuser"].ToString() + "/" + "Grid_Excel" + "/");

        if (Directory.Exists(Grid_Excel) == false)
        {
            Directory.CreateDirectory(Grid_Excel);
        }

        string ClientNm, P_clientName;
        HttpResponse Response = HttpContext.Current.Response;
        JobNo = JobNo_;
        Jobdate = Jobdate_;
        Exp_name = Exp_name_;
        To_date = To_date_ == " " ? string.Empty : To_date_;
        Branch = Branch_;
        Ename = "Bind_Grid_Details";
        ClientNm = Exp_name;

        if (ClientNm.Contains(" "))
        {
            P_clientName = ClientNm.Replace(" ", "_");
        }
        else
        {
            P_clientName = ClientNm;
        }

        DataView dv = new DataView(Export_MIS_Statement());
        DataTable dt = dv.ToTable();
        if (p_Type == "excel")
        {
            Response.Clear();
            Response.Buffer = true;

            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                GridView gv = new GridView();
                gv.HeaderStyle.BackColor = System.Drawing.Color.RoyalBlue;
                gv.HeaderStyle.ForeColor = System.Drawing.Color.White;
                gv.AllowPaging = false;
                gv.DataSource = dt;
                gv.DataBind();

                foreach (TableCell cell in gv.HeaderRow.Cells)
                {
                    cell.BackColor = gv.HeaderStyle.BackColor;
                }

                gv.RenderControl(hw);

                string str = "EXP_MIS.xls";
                HttpContext.Current.Session.Remove(Grid_Excel);
                if (File.Exists(Grid_Excel + str))
                {
                    DirectoryInfo dir = new DirectoryInfo(Grid_Excel);
                    foreach (FileInfo fi in dir.GetFiles())
                    {
                        fi.Delete();
                    }
                    str = "EXP_MIS.xls";

                    StreamWriter myWriter = new StreamWriter((Grid_Excel + "\\" + str + ""), true, System.Text.Encoding.Unicode);
                    myWriter.Write(sw.ToString());
                    myWriter.Flush();
                    myWriter.Close();

                    HttpContext.Current.Session["EXP_MIS_Grid_Excel"] = Grid_Excel + str;
                }
                else
                {
                    StreamWriter myWriter = new StreamWriter((Grid_Excel + "\\" + str + ""), true, System.Text.Encoding.Unicode);
                    myWriter.Write(sw.ToString());
                    myWriter.Flush();
                    myWriter.Close();

                    HttpContext.Current.Session["EXP_MIS_Grid_Excel"] = Grid_Excel + str;
                }
            }

        }

    }

    public void Open_Export_Excel_Download_XLSX(string Jobno_, string Branch_Common_)//download .XLSX
    {
        HttpResponse Response = HttpContext.Current.Response;
        Export_MIS_2 expr = new Export_MIS_2();
        DataTable dt = new DataTable();
        dt.Rows.Add();

        expr.JobNo = Jobno_;
        expr.Branch = Branch_Common_;

        DataSet dss = expr.RetrieveAll_EXPORT_EXCELDOWNLOAD_EXCEL();
        dt = dss.Tables[0];
        DateTime time = DateTime.Now;

        string Filename = "";
        Filename = "JobNo-" + Jobno_ + "-Exp_Inv_Itm";

        using (var workbook = new XLWorkbook())
        {
            var worksheet = workbook.Worksheets.Add(dt, Filename);

            worksheet.Table(0).Theme = XLTableTheme.None;

            worksheet.Cell("A1").Style.Fill.BackgroundColor = XLColor.Yellow;
            worksheet.Cell("B1").Style.Fill.BackgroundColor = XLColor.Yellow;
            worksheet.Cell("C1").Style.Fill.BackgroundColor = XLColor.Yellow;
            worksheet.Cell("D1").Style.Fill.BackgroundColor = XLColor.Orange;
            worksheet.Cell("E1").Style.Fill.BackgroundColor = XLColor.Yellow;
            worksheet.Cell("F1").Style.Fill.BackgroundColor = XLColor.Orange;
            worksheet.Cell("I1").Style.Fill.BackgroundColor = XLColor.Orange;
            worksheet.Cell("K1").Style.Fill.BackgroundColor = XLColor.Orange;
            worksheet.Cell("N1").Style.Fill.BackgroundColor = XLColor.Orange;
            worksheet.Cell("Q1").Style.Fill.BackgroundColor = XLColor.Orange;
            worksheet.Cell("T1").Style.Fill.BackgroundColor = XLColor.Orange;
            worksheet.Cell("W1").Style.Fill.BackgroundColor = XLColor.Orange;
            worksheet.Cell("Z1").Style.Fill.BackgroundColor = XLColor.Orange;
            worksheet.Cell("AA1").Style.Fill.BackgroundColor = XLColor.Orange;
            worksheet.Cell("AB1").Style.Fill.BackgroundColor = XLColor.Orange;
            worksheet.Cell("AC1").Style.Fill.BackgroundColor = XLColor.Yellow;
            worksheet.Cell("AD1").Style.Fill.BackgroundColor = XLColor.Yellow;
            worksheet.Cell("AE1").Style.Fill.BackgroundColor = XLColor.Yellow;
            worksheet.Cell("AF1").Style.Fill.BackgroundColor = XLColor.Yellow;
            worksheet.Cell("AG1").Style.Fill.BackgroundColor = XLColor.Yellow;
            worksheet.Cell("AH1").Style.Fill.BackgroundColor = XLColor.Orange;

            worksheet.Cell("AJ1").Style.Fill.BackgroundColor = XLColor.BabyPink;
            worksheet.Cell("AK1").Style.Fill.BackgroundColor = XLColor.BabyPink;

            worksheet.Cell("AL1").Style.Fill.BackgroundColor = XLColor.Orange;
            worksheet.Cell("AM1").Style.Fill.BackgroundColor = XLColor.Orange;

            worksheet.Cell("AO1").Style.Fill.BackgroundColor = XLColor.BlizzardBlue;

            worksheet.Cell("AP1").Style.Fill.BackgroundColor = XLColor.GrannySmithApple;
            worksheet.Cell("AQ1").Style.Fill.BackgroundColor = XLColor.GrannySmithApple;

            worksheet.Cell("AR1").Style.Fill.BackgroundColor = XLColor.Orange;
            worksheet.Cell("AS1").Style.Fill.BackgroundColor = XLColor.Orange;

            worksheet.Cell("AW1").Style.Fill.BackgroundColor = XLColor.OrangeColorWheel;
            worksheet.Cell("AX1").Style.Fill.BackgroundColor = XLColor.Orange;
            worksheet.Cell("AY1").Style.Fill.BackgroundColor = XLColor.Orange;
            worksheet.Cell("AZ1").Style.Fill.BackgroundColor = XLColor.Orange;
            worksheet.Cell("BA1").Style.Fill.BackgroundColor = XLColor.Orange;
            worksheet.Cell("BB1").Style.Fill.BackgroundColor = XLColor.Orange;
            worksheet.Cell("BC1").Style.Fill.BackgroundColor = XLColor.Orange;
            worksheet.Cell("BD1").Style.Fill.BackgroundColor = XLColor.Orange;

            worksheet.Cell("BE1").Style.Fill.BackgroundColor = XLColor.Orange;
            worksheet.Cell("BF1").Style.Fill.BackgroundColor = XLColor.Orange;
            worksheet.Cell("BG1").Style.Fill.BackgroundColor = XLColor.Orange;
            worksheet.Cell("BH1").Style.Fill.BackgroundColor = XLColor.Orange;
            worksheet.Cell("BI1").Style.Fill.BackgroundColor = XLColor.Orange;
            worksheet.Cell("BJ1").Style.Fill.BackgroundColor = XLColor.Orange;
            worksheet.Cell("BK1").Style.Fill.BackgroundColor = XLColor.Orange;
            worksheet.Cell("BL1").Style.Fill.BackgroundColor = XLColor.Yellow;
            worksheet.Cell("BM1").Style.Fill.BackgroundColor = XLColor.Yellow;
            worksheet.Cell("BN1").Style.Fill.BackgroundColor = XLColor.Yellow;
            worksheet.Cell("BO1").Style.Fill.BackgroundColor = XLColor.Orange;
            worksheet.Cell("BP1").Style.Fill.BackgroundColor = XLColor.Orange;
            worksheet.Cell("BQ1").Style.Fill.BackgroundColor = XLColor.Yellow;
            worksheet.Cell("BR1").Style.Fill.BackgroundColor = XLColor.Orange;




            //worksheet.Range("A1:X1").Style.Font.FontColor = XLColor.Black;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                workbook.SaveAs(memoryStream);

                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment; filename=" + Filename + ".xlsx");
                memoryStream.Position = 0;


                Response.BinaryWrite(memoryStream.ToArray());
                Response.End();
            }
        }
    }


    public DataSet RetrieveAll_EXPORT_EXCELDOWNLOAD_EXCEL()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[5];

            param[0] = new SqlParameter("@JOBNO", JobNo);
            param[1] = new SqlParameter("@Branch_Code", Branch);

            param[2] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[2].Direction = ParameterDirection.Output;

            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXPORT_EXCEL_INVOICE_DOWNLOAD_REPORT", param);
            result = Convert.ToInt32(param[2].Value.ToString());

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                    ds.Tables.Add(dt);
            }
            else
                ds.Tables.Add(dt);

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }


    public DataTable Exp_MIS_Rpt_Optimized()
    {
        DataSet ds_exp_mis = new DataSet();
        try
        {

            string[] arr = new string[] { };
            string[] arr2 = new string[] { };
            if (Jobdate != string.Empty && Jobdate != null)
            {
                arr = Jobdate.Split('/');
                Jobdate = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (To_date != string.Empty && To_date != null)
            {
                arr2 = To_date.Split('/');
                To_date = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }


            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@jobdate", Jobdate == string.Empty ? string.Empty : Jobdate);
            param[1] = new SqlParameter("@Exportername", Exp_name == string.Empty ? string.Empty : Exp_name);
            param[2] = new SqlParameter("@Mode", Tr_mode == string.Empty ? string.Empty : Tr_mode);
            param[3] = new SqlParameter("@port", Port == string.Empty ? string.Empty : Port);
            param[4] = new SqlParameter("@SBtype", SB_type == string.Empty ? string.Empty : SB_type);
            param[6] = new SqlParameter("@todate", To_date == string.Empty ? string.Empty : To_date);
            param[7] = new SqlParameter("@Country", Country == string.Empty ? string.Empty : Country);
            param[5] = new SqlParameter("@CustomHouse", CusHouse == string.Empty ? string.Empty : CusHouse);

            param[8] = new SqlParameter("@Branch", Connection.Current_Branch());
            param[9] = new SqlParameter("@Report_Cat", Report_cat);
            param[12] = new SqlParameter("@UserId", UserID);            

            ds_exp_mis = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "sp_Exp_MIS_info_Rpt_Optimized", param);

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }

        if (ds_exp_mis.Tables.Count == 0)
        {
            ds_exp_mis.Tables.Add(dt);
        }

        return ds_exp_mis.Tables[0];
    }



    public void Open_Exp_MIS_XLs_Report(string Jobdate_, string Exp_name_, string Tr_mode_, string Branch_, string SB_type_, string Report_cat_, string Port_, string Type_, string To_date_, string Country_, string UserID_, string CustHouse_)
    {
        HttpResponse Response = HttpContext.Current.Response;
        Jobdate = Jobdate_;
        Exp_name = Exp_name_;
        Tr_mode = Tr_mode_;
        Branch = Branch_;
        SB_type = SB_type_ == "All" ? "" : SB_type_;
        Report_cat = Report_cat_;
        Port = Port_;
        To_date = To_date_ == " " ? string.Empty : To_date_;
        Country = Country_;
        UserID = UserID_;
        CusHouse = CustHouse_;// Added by George Bush on 09-06-2026


        DataView dv = new DataView(Exp_MIS_Rpt_Optimized());
        DataTable dt = dv.ToTable();
        if (Type_ == "excel")
        {
            if (dt.Rows.Count > 0)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=" + Report_cat + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);

                    //To Export all pages
                    GridView gv = new GridView();
                    gv.AllowPaging = false;
                    gv.DataSource = dt;
                    gv.DataBind();


                    foreach (TableCell cell in gv.HeaderRow.Cells)
                    {
                        cell.BackColor = gv.HeaderStyle.BackColor;
                    }

                    gv.RenderControl(hw);

                    //style to format numbers to string
                    string style = @"<style> .textmode { } </style>";
                    Response.Write(style);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
            }

        }
        if (Type_ == "Pdf")
        {
            if (dt.Rows.Count > 0)
            {
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                using (StringWriter sw = new StringWriter())
                {
                    using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                    {
                        GridView gv = new GridView();
                        gv.AllowPaging = false;
                        gv.DataSource = dt;
                        gv.DataBind();

                        //-----------------------------------------
                        gv.HeaderRow.Style.Add("font-weight", "bold");
                        gv.HeaderRow.Style.Add("font-size", "15PX");
                        gv.HeaderRow.Style.Add("text-align", "center");

                        for (int i = 0; i < gv.Rows.Count; i++)
                        {
                            GridViewRow row = gv.Rows[i];
                            row.Attributes.Add("class", "textmode");

                            row.Cells[0].Style.Add("text-align", "left");
                            row.Cells[1].Style.Add("text-align", "center");
                            row.Cells[2].Style.Add("text-align", "center");
                            row.Cells[3].Style.Add("text-align", "right");
                            row.Cells[4].Style.Add("text-align", "right");
                            row.Cells[5].Style.Add("text-align", "right");
                            row.Cells[6].Style.Add("text-align", "right");

                        }
                        //------------------------------------------


                        gv.RenderControl(hw);
                        StringReader sr = new StringReader(sw.ToString());
                        Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                        pdfDoc.Open();
                        htmlparser.Parse(sr);
                        pdfDoc.Close();

                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-disposition", "attachment;filename=" + Report_cat + ".pdf");
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.Write(pdfDoc);
                        Response.End();

                    }
                }
            }

        }

    }
}


