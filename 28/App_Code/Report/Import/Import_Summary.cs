using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.IO;

using System.Web.UI;
using System.Web.UI.WebControls;

using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

using System.IO;
using iTextSharp.text.html.simpleparser;
using System.Data;
using iTextSharp.text;



public class Import_Summary
{
    private string _StartDate;
    private string _EndDate;

    private string _Mode;
    private string _Branch;
    private string _Mflag;


    private string _Report_cat;
    private string _from_date;
    private string _to_date;
    private string _Tr_mode;
    private string _Select_Item;


    private string _Qstart;
    private string _QEnd;


    public string Mode { get { return _Mode; } set { _Mode = value; } }
    public string Branch { get { return _Branch; } set { _Branch = value; } }
    public string Mflag { get { return _Mflag; } set { _Mflag = value; } }


    public string StartDate { get { return _StartDate; } set { _StartDate = value; } }
    public string EndDate { get { return _EndDate; } set { _EndDate = value; } }

    public string Report_cat { get { return _Report_cat; } set { _Report_cat = value; } }
    public string from_date { get { return _from_date; } set { _from_date = value; } }
    public string to_date { get { return _to_date; } set { _to_date = value; } }
    public string Tr_mode { get { return _Tr_mode; } set { _Tr_mode = value; } }

    public string Qstart { get { return _Qstart; } set { _Qstart = value; } }
    public string QEnd { get { return _QEnd; } set { _QEnd = value; } }
    public string Select_Item { get { return _Select_Item; } set { _Select_Item = value; } }



    public int result;
    DataSet ds = new DataSet();

    public DataSet Working_Year_Load()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@StartDate", StartDate);
            param[1] = new SqlParameter("@EndDate", EndDate);

            param[2] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[2].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "REPORT_YEAR_WISE", param);

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }
    public DataSet Select_Summary_details()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@Mode", Mode);
            param[1] = new SqlParameter("@Branch", Branch);
            param[2] = new SqlParameter("@Mflag", Mflag);

            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_SELECT_SUMMARY_DETAILS", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet Load_Report_Data()
    {
        try
        {

            string[] arr = new string[] { };
            string[] arr2 = new string[] { };
            if (from_date != string.Empty && from_date != null)
            {
                arr = from_date.Split('/');
                from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (to_date != string.Empty && to_date != null)
            {
                arr2 = to_date.Split('/');
                to_date = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }


            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@Report_cat", Report_cat);
            param[1] = new SqlParameter("@from_date", from_date);
            param[2] = new SqlParameter("@to_date", to_date);
            param[3] = new SqlParameter("@Select_Item", Select_Item);
            param[4] = new SqlParameter("@Tr_mode", Tr_mode = Tr_mode == "All" ? "" : Tr_mode);
            param[5] = new SqlParameter("@Branch", Branch);

            param[6] = new SqlParameter("@Qstart", Qstart);
            param[7] = new SqlParameter("@QEnd", QEnd);
            param[8] = new SqlParameter("@Start_month", StartDate);
            param[9] = new SqlParameter("@End_month", EndDate);

            param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[10].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_SUMMARY_RPT", param);

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public void Load_Summary_Report_Data_Xls(string Category_, string Fromdate_, string Todate_, string Tr_Mode_, string Select_Item_, string TheQuarter_Start_, string TheQuarter_End_, string W_Start_month_, string W_End_month_, string Branch_, string Type_)
    {
        HttpResponse Response = HttpContext.Current.Response;

        Report_cat = Category_;
        from_date = Fromdate_;
        to_date = Todate_;
        Select_Item = Select_Item_;
        Tr_mode = Tr_Mode_;
        Branch = Branch_;

        Qstart = TheQuarter_Start_;
        QEnd = TheQuarter_End_;
        StartDate = W_Start_month_;
        EndDate = W_End_month_;

        DataSet dss = Load_Report_Data();
        DataTable dt = dss.Tables[0];
        int lastRowIndex = 0;

        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss
        string Filename = "";

        Filename = Report_cat;
        string strCampNametime = Filename + "_" + s;


        if (Type_ == "excel")
        {

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + strCampNametime + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                GridView gv = new GridView();

                gv.AllowPaging = false;
                gv.DataSource = dt;
                gv.DataBind();

                //-----------------------------------------------Start--------------------------------------------------------------------------------------------

                if (dss.Tables[0].Rows.Count > 0)
                {
                    /*
                    
                   foreach (GridViewRow grv in gv.Rows)
                   {
                       
                       if (grv.RowType == DataControlRowType.DataRow)
                       {
                           if (grv.RowIndex > lastRowIndex)
                           {
                               //getting the last data row index
                               lastRowIndex = grv.RowIndex;
                           }
                       }
                   }
                   if (Tr_mode != "")
                   {

                       for (int j = 0; j <= lastRowIndex - 1; j++)
                       {
                           gv.Rows[j].Cells[0].Style["border-bottom"] = "1px solid #000000";
                           gv.Rows[j].Cells[1].Style["border-bottom"] = "1px solid #000000";
                           gv.Rows[j].Cells[2].Style["border-bottom"] = "1px solid #000000";
                           gv.Rows[j].Cells[3].Style["border-bottom"] = "1px solid #000000";
                           gv.Rows[j].Cells[4].Style["border-bottom"] = "1px solid #000000";
                           gv.Rows[j].Cells[5].Style["border-bottom"] = "1px solid #000000";
                       }

                       gv.Rows[lastRowIndex].Cells[5].Style["border-bottom"] = "1px solid #000000";
                       gv.Rows[lastRowIndex].Cells[4].Style["border-bottom"] = "1px solid #000000";
                       gv.Rows[lastRowIndex].Cells[3].Style["border-bottom"] = "1px solid #000000";
                       gv.Rows[lastRowIndex].Cells[2].Style["border-bottom"] = "1px solid #000000";
                       gv.Rows[lastRowIndex].Cells[1].Style["border-bottom"] = "1px solid #000000";
                       gv.Rows[lastRowIndex].Cells[0].Style["border-bottom"] = "1px solid #000000";

                       gv.HeaderRow.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                       gv.HeaderRow.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                       gv.HeaderRow.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                       gv.HeaderRow.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                       gv.HeaderRow.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                       gv.HeaderRow.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");


                       gv.Rows[lastRowIndex].Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                       gv.Rows[lastRowIndex].Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                       gv.Rows[lastRowIndex].Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                       gv.Rows[lastRowIndex].Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                       gv.Rows[lastRowIndex].Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                       gv.Rows[lastRowIndex].Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");

                   }
                   else
                   {

                       for (int j = 0; j <= lastRowIndex - 4; j++)
                       {
                           gv.Rows[j].Cells[0].Style["border-bottom"] = "1px solid #000000";
                           gv.Rows[j].Cells[1].Style["border-bottom"] = "1px solid #000000";
                           gv.Rows[j].Cells[2].Style["border-bottom"] = "1px solid #000000";
                           gv.Rows[j].Cells[3].Style["border-bottom"] = "1px solid #000000";
                           gv.Rows[j].Cells[4].Style["border-bottom"] = "1px solid #000000";
                           gv.Rows[j].Cells[5].Style["border-bottom"] = "1px solid #000000";
                           gv.Rows[j].Cells[6].Style["border-bottom"] = "1px solid #000000";
                       }
                       gv.Rows[lastRowIndex].Cells[6].Style["border-bottom"] = "1px solid #000000";
                       gv.Rows[lastRowIndex].Cells[5].Style["border-bottom"] = "1px solid #000000";
                       gv.Rows[lastRowIndex].Cells[4].Style["border-bottom"] = "1px solid #000000";
                       gv.Rows[lastRowIndex].Cells[3].Style["border-bottom"] = "1px solid #000000";
                       gv.Rows[lastRowIndex].Cells[2].Style["border-bottom"] = "1px solid #000000";
                       gv.Rows[lastRowIndex].Cells[1].Style["border-bottom"] = "1px solid #000000";
                       gv.Rows[lastRowIndex].Cells[0].Style["border-bottom"] = "1px solid #000000";


                       int last = 0;
                       last = lastRowIndex - 3;

                       for (int z = last; z <= lastRowIndex; z++)
                       {
                           gv.Rows[z].Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                           gv.Rows[z].Font.Bold = true;

                           gv.Rows[z].Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                           gv.Rows[z].Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                           gv.Rows[z].Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                           gv.Rows[z].Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                       }

                       gv.HeaderRow.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                       gv.HeaderRow.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                       gv.HeaderRow.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                       gv.HeaderRow.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                       gv.HeaderRow.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                       gv.HeaderRow.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                       gv.HeaderRow.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                   }
                   */
                }

                //-----------------------------------------------End------------------------------------------------------------------------------------------------
                gv.RenderControl(hw);

                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }

        }

        else if (Type_ == "Pdf")
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




                        if (dss.Tables[0].Rows.Count > 0)
                        {


                            foreach (GridViewRow grv in gv.Rows)
                            {
                                if (grv.RowType == DataControlRowType.DataRow)
                                {
                                    if (grv.RowIndex > lastRowIndex)
                                    {
                                        //getting the last data row index
                                        lastRowIndex = grv.RowIndex;
                                    }
                                }
                            }
                            if (Tr_mode != "")
                            {

                                for (int j = 0; j <= lastRowIndex - 1; j++)
                                {
                                    gv.Rows[j].Cells[0].Style["border-bottom"] = "1px solid #000000";
                                    gv.Rows[j].Cells[1].Style["border-bottom"] = "1px solid #000000";
                                    gv.Rows[j].Cells[2].Style["border-bottom"] = "1px solid #000000";
                                    gv.Rows[j].Cells[3].Style["border-bottom"] = "1px solid #000000";
                                    gv.Rows[j].Cells[4].Style["border-bottom"] = "1px solid #000000";
                                    gv.Rows[j].Cells[5].Style["border-bottom"] = "1px solid #000000";
                                }

                                gv.Rows[lastRowIndex].Cells[5].Style["border-bottom"] = "1px solid #000000";
                                gv.Rows[lastRowIndex].Cells[4].Style["border-bottom"] = "1px solid #000000";
                                gv.Rows[lastRowIndex].Cells[3].Style["border-bottom"] = "1px solid #000000";
                                gv.Rows[lastRowIndex].Cells[2].Style["border-bottom"] = "1px solid #000000";
                                gv.Rows[lastRowIndex].Cells[1].Style["border-bottom"] = "1px solid #000000";
                                gv.Rows[lastRowIndex].Cells[0].Style["border-bottom"] = "1px solid #000000";

                                gv.HeaderRow.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                gv.HeaderRow.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                gv.HeaderRow.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                gv.HeaderRow.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                gv.HeaderRow.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                gv.HeaderRow.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");


                                gv.Rows[lastRowIndex].Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                gv.Rows[lastRowIndex].Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                gv.Rows[lastRowIndex].Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                gv.Rows[lastRowIndex].Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                gv.Rows[lastRowIndex].Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                gv.Rows[lastRowIndex].Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");

                            }
                            else
                            {

                                for (int j = 0; j <= lastRowIndex - 4; j++)
                                {
                                    gv.Rows[j].Cells[0].Style["border-bottom"] = "1px solid #000000";
                                    gv.Rows[j].Cells[1].Style["border-bottom"] = "1px solid #000000";
                                    gv.Rows[j].Cells[2].Style["border-bottom"] = "1px solid #000000";
                                    gv.Rows[j].Cells[3].Style["border-bottom"] = "1px solid #000000";
                                    gv.Rows[j].Cells[4].Style["border-bottom"] = "1px solid #000000";
                                    gv.Rows[j].Cells[5].Style["border-bottom"] = "1px solid #000000";
                                    gv.Rows[j].Cells[6].Style["border-bottom"] = "1px solid #000000";
                                }

                                gv.Rows[lastRowIndex].Cells[6].Style["border-bottom"] = "1px solid #000000";
                                gv.Rows[lastRowIndex].Cells[5].Style["border-bottom"] = "1px solid #000000";
                                gv.Rows[lastRowIndex].Cells[4].Style["border-bottom"] = "1px solid #000000";
                                gv.Rows[lastRowIndex].Cells[3].Style["border-bottom"] = "1px solid #000000";
                                gv.Rows[lastRowIndex].Cells[2].Style["border-bottom"] = "1px solid #000000";
                                gv.Rows[lastRowIndex].Cells[1].Style["border-bottom"] = "1px solid #000000";
                                gv.Rows[lastRowIndex].Cells[0].Style["border-bottom"] = "1px solid #000000";


                                int last = 0;
                                last = lastRowIndex - 3;

                                for (int z = last; z <= lastRowIndex; z++)
                                {
                                    gv.Rows[z].Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                    gv.Rows[z].Font.Bold = true;

                                    gv.Rows[z].Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                    gv.Rows[z].Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                    gv.Rows[z].Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                    gv.Rows[z].Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                }

                                gv.HeaderRow.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                gv.HeaderRow.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                gv.HeaderRow.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                gv.HeaderRow.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                gv.HeaderRow.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                gv.HeaderRow.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                gv.HeaderRow.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                            }
                        }





                        //-----------------------------------------
                        gv.HeaderRow.Style.Add("font-weight", "bold");
                        gv.HeaderRow.Style.Add("font-size", "15PX");
                        gv.HeaderRow.Style.Add("text-align", "center");

                        for (int i = 0; i < gv.Rows.Count; i++)
                        {
                            GridViewRow row = gv.Rows[i];
                            row.Attributes.Add("class", "textmode");

                            if (Tr_mode != "")
                            {
                                row.Cells[0].Style.Add("text-align", "left");
                                row.Cells[1].Style.Add("text-align", "left");
                                row.Cells[2].Style.Add("text-align", "right");
                                row.Cells[3].Style.Add("text-align", "right");
                                row.Cells[4].Style.Add("text-align", "right");
                            }
                            else
                            {
                                row.Cells[0].Style.Add("text-align", "left");
                                row.Cells[1].Style.Add("text-align", "left");
                                row.Cells[2].Style.Add("text-align", "center");
                                row.Cells[3].Style.Add("text-align", "right");
                                row.Cells[4].Style.Add("text-align", "right");
                                row.Cells[5].Style.Add("text-align", "right");
                                row.Cells[6].Style.Add("text-align", "right");
                            }

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
                        Response.AddHeader("content-disposition", "attachment;filename=" + strCampNametime + ".pdf");
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.Write(pdfDoc);
                        Response.End();

                    }
                }
            }

        }

    }


    public void Load_Summary_Report_Data_Xls_Mail(string Category_, string Fromdate_, string Todate_, string Tr_Mode_, string Select_Item_, string TheQuarter_Start_, string TheQuarter_End_, string W_Start_month_, string W_End_month_, string Branch_, string Type_)
    {

        string Grid_Excel = HttpContext.Current.Server.MapPath("~/Submission/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + HttpContext.Current.Session["currentbranch"].ToString() + "/" + HttpContext.Current.Session["currentuser"].ToString() + "/" + "Grid_Excel" + "/");

        if (Directory.Exists(Grid_Excel) == false)
        {
            Directory.CreateDirectory(Grid_Excel);
        }


        HttpResponse Response = HttpContext.Current.Response;
        Report_cat = Category_;
        from_date = Fromdate_;
        to_date = Todate_;
        Select_Item = Select_Item_;
        Tr_mode = Tr_Mode_;
        Branch = Branch_;

        Qstart = TheQuarter_Start_;
        QEnd = TheQuarter_End_;
        StartDate = W_Start_month_;
        EndDate = W_End_month_;

        DataSet dss = Load_Report_Data();
        DataTable dt = dss.Tables[0];
        int lastRowIndex = 0;

        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss
        string Filename = "";

        Filename = Report_cat;
        string strCampNametime = Filename + "_" + s;

        if (Type_ == "excel")
        {

            Response.Clear();
            Response.Buffer = true;

            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                GridView gv = new GridView();

                gv.AllowPaging = false;
                gv.DataSource = dt;
                gv.DataBind();

                //-----------------------------------------------Start--------------------------------------------------------------------------------------------

                if (dss.Tables[0].Rows.Count > 0)
                {


                    foreach (GridViewRow grv in gv.Rows)
                    {
                        if (grv.RowType == DataControlRowType.DataRow)
                        {
                            if (grv.RowIndex > lastRowIndex)
                            {
                                //getting the last data row index
                                lastRowIndex = grv.RowIndex;
                            }
                        }
                    }
                    if (Tr_mode != "")
                    {

                        for (int j = 0; j <= lastRowIndex - 1; j++)
                        {
                            gv.Rows[j].Cells[0].Style["border-bottom"] = "1px solid #000000";
                            gv.Rows[j].Cells[1].Style["border-bottom"] = "1px solid #000000";
                            gv.Rows[j].Cells[2].Style["border-bottom"] = "1px solid #000000";
                            gv.Rows[j].Cells[3].Style["border-bottom"] = "1px solid #000000";
                            gv.Rows[j].Cells[4].Style["border-bottom"] = "1px solid #000000";
                            gv.Rows[j].Cells[5].Style["border-bottom"] = "1px solid #000000";
                        }
                        gv.Rows[lastRowIndex].Cells[5].Style["border-bottom"] = "1px solid #000000";
                        gv.Rows[lastRowIndex].Cells[4].Style["border-bottom"] = "1px solid #000000";
                        gv.Rows[lastRowIndex].Cells[3].Style["border-bottom"] = "1px solid #000000";
                        gv.Rows[lastRowIndex].Cells[2].Style["border-bottom"] = "1px solid #000000";
                        gv.Rows[lastRowIndex].Cells[1].Style["border-bottom"] = "1px solid #000000";
                        gv.Rows[lastRowIndex].Cells[0].Style["border-bottom"] = "1px solid #000000";

                        gv.HeaderRow.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                        gv.HeaderRow.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                        gv.HeaderRow.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                        gv.HeaderRow.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                        gv.HeaderRow.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                        gv.HeaderRow.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");


                        gv.Rows[lastRowIndex].Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                        gv.Rows[lastRowIndex].Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                        gv.Rows[lastRowIndex].Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                        gv.Rows[lastRowIndex].Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                        gv.Rows[lastRowIndex].Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                        gv.Rows[lastRowIndex].Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");

                    }
                    else
                    {

                        for (int j = 0; j <= lastRowIndex - 4; j++)
                        {
                            gv.Rows[j].Cells[0].Style["border-bottom"] = "1px solid #000000";
                            gv.Rows[j].Cells[1].Style["border-bottom"] = "1px solid #000000";
                            gv.Rows[j].Cells[2].Style["border-bottom"] = "1px solid #000000";
                            gv.Rows[j].Cells[3].Style["border-bottom"] = "1px solid #000000";
                            gv.Rows[j].Cells[4].Style["border-bottom"] = "1px solid #000000";
                            gv.Rows[j].Cells[5].Style["border-bottom"] = "1px solid #000000";
                            gv.Rows[j].Cells[6].Style["border-bottom"] = "1px solid #000000";
                        }
                        gv.Rows[lastRowIndex].Cells[6].Style["border-bottom"] = "1px solid #000000";
                        gv.Rows[lastRowIndex].Cells[5].Style["border-bottom"] = "1px solid #000000";
                        gv.Rows[lastRowIndex].Cells[4].Style["border-bottom"] = "1px solid #000000";
                        gv.Rows[lastRowIndex].Cells[3].Style["border-bottom"] = "1px solid #000000";
                        gv.Rows[lastRowIndex].Cells[2].Style["border-bottom"] = "1px solid #000000";
                        gv.Rows[lastRowIndex].Cells[1].Style["border-bottom"] = "1px solid #000000";
                        gv.Rows[lastRowIndex].Cells[0].Style["border-bottom"] = "1px solid #000000";


                        int last = 0;
                        last = lastRowIndex - 3;

                        for (int z = last; z <= lastRowIndex; z++)
                        {
                            gv.Rows[z].Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                            gv.Rows[z].Font.Bold = true;

                            gv.Rows[z].Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                            gv.Rows[z].Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                            gv.Rows[z].Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                            gv.Rows[z].Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                        }

                        gv.HeaderRow.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                        gv.HeaderRow.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                        gv.HeaderRow.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                        gv.HeaderRow.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                        gv.HeaderRow.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                        gv.HeaderRow.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                        gv.HeaderRow.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                    }
                }

                //-----------------------------------------------End------------------------------------------------------------------------------------------------
                gv.RenderControl(hw);


                string str = "Import_Summary.xls";


                HttpContext.Current.Session.Remove(Grid_Excel);
                if (File.Exists(Grid_Excel + str))
                {
                    DirectoryInfo dir = new DirectoryInfo(Grid_Excel);
                    foreach (FileInfo fi in dir.GetFiles())
                    {
                        fi.Delete();
                    }
                    str = "Import_Summary.xls";

                    StreamWriter myWriter = new StreamWriter((Grid_Excel + "\\" + str + ""), true, System.Text.Encoding.Unicode);
                    myWriter.Write(sw.ToString());
                    myWriter.Flush();
                    myWriter.Close();

                    HttpContext.Current.Session["Import_Summary"] = Grid_Excel + str;
                }
                else
                {
                    StreamWriter myWriter = new StreamWriter((Grid_Excel + "\\" + str + ""), true, System.Text.Encoding.Unicode);
                    myWriter.Write(sw.ToString());
                    myWriter.Flush();
                    myWriter.Close();

                    HttpContext.Current.Session["Import_Summary"] = Grid_Excel + str;
                }
            }

        }

        else if (Type_ == "Pdf")
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

                        if (dss.Tables[0].Rows.Count > 0)
                        {

                            foreach (GridViewRow grv in gv.Rows)
                            {
                                if (grv.RowType == DataControlRowType.DataRow)
                                {
                                    if (grv.RowIndex > lastRowIndex)
                                    {
                                        //getting the last data row index
                                        lastRowIndex = grv.RowIndex;
                                    }
                                }
                            }
                            if (Tr_mode != "")
                            {

                                for (int j = 0; j <= lastRowIndex - 1; j++)
                                {
                                    gv.Rows[j].Cells[0].Style["border-bottom"] = "1px solid #000000";
                                    gv.Rows[j].Cells[1].Style["border-bottom"] = "1px solid #000000";
                                    gv.Rows[j].Cells[2].Style["border-bottom"] = "1px solid #000000";
                                    gv.Rows[j].Cells[3].Style["border-bottom"] = "1px solid #000000";
                                    gv.Rows[j].Cells[4].Style["border-bottom"] = "1px solid #000000";
                                    gv.Rows[j].Cells[5].Style["border-bottom"] = "1px solid #000000";
                                }
                                gv.Rows[lastRowIndex].Cells[5].Style["border-bottom"] = "1px solid #000000";
                                gv.Rows[lastRowIndex].Cells[4].Style["border-bottom"] = "1px solid #000000";
                                gv.Rows[lastRowIndex].Cells[3].Style["border-bottom"] = "1px solid #000000";
                                gv.Rows[lastRowIndex].Cells[2].Style["border-bottom"] = "1px solid #000000";
                                gv.Rows[lastRowIndex].Cells[1].Style["border-bottom"] = "1px solid #000000";
                                gv.Rows[lastRowIndex].Cells[0].Style["border-bottom"] = "1px solid #000000";

                                gv.HeaderRow.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                gv.HeaderRow.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                gv.HeaderRow.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                gv.HeaderRow.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                gv.HeaderRow.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                gv.HeaderRow.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");


                                gv.Rows[lastRowIndex].Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                gv.Rows[lastRowIndex].Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                gv.Rows[lastRowIndex].Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                gv.Rows[lastRowIndex].Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                gv.Rows[lastRowIndex].Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                gv.Rows[lastRowIndex].Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");

                            }
                            else
                            {

                                for (int j = 0; j <= lastRowIndex - 4; j++)
                                {
                                    gv.Rows[j].Cells[0].Style["border-bottom"] = "1px solid #000000";
                                    gv.Rows[j].Cells[1].Style["border-bottom"] = "1px solid #000000";
                                    gv.Rows[j].Cells[2].Style["border-bottom"] = "1px solid #000000";
                                    gv.Rows[j].Cells[3].Style["border-bottom"] = "1px solid #000000";
                                    gv.Rows[j].Cells[4].Style["border-bottom"] = "1px solid #000000";
                                    gv.Rows[j].Cells[5].Style["border-bottom"] = "1px solid #000000";
                                    gv.Rows[j].Cells[6].Style["border-bottom"] = "1px solid #000000";
                                }
                                gv.Rows[lastRowIndex].Cells[6].Style["border-bottom"] = "1px solid #000000";
                                gv.Rows[lastRowIndex].Cells[5].Style["border-bottom"] = "1px solid #000000";
                                gv.Rows[lastRowIndex].Cells[4].Style["border-bottom"] = "1px solid #000000";
                                gv.Rows[lastRowIndex].Cells[3].Style["border-bottom"] = "1px solid #000000";
                                gv.Rows[lastRowIndex].Cells[2].Style["border-bottom"] = "1px solid #000000";
                                gv.Rows[lastRowIndex].Cells[1].Style["border-bottom"] = "1px solid #000000";
                                gv.Rows[lastRowIndex].Cells[0].Style["border-bottom"] = "1px solid #000000";


                                int last = 0;
                                last = lastRowIndex - 3;

                                for (int z = last; z <= lastRowIndex; z++)
                                {
                                    gv.Rows[z].Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                    gv.Rows[z].Font.Bold = true;

                                    gv.Rows[z].Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                    gv.Rows[z].Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                    gv.Rows[z].Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                    gv.Rows[z].Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                }

                                gv.HeaderRow.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                gv.HeaderRow.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                gv.HeaderRow.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                gv.HeaderRow.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                gv.HeaderRow.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                gv.HeaderRow.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                                gv.HeaderRow.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                            }
                        }





                        //-----------------------------------------
                        gv.HeaderRow.Style.Add("font-weight", "bold");
                        gv.HeaderRow.Style.Add("font-size", "15PX");
                        gv.HeaderRow.Style.Add("text-align", "center");

                        for (int i = 0; i < gv.Rows.Count; i++)
                        {
                            GridViewRow row = gv.Rows[i];
                            row.Attributes.Add("class", "textmode");

                            if (Tr_mode != "")
                            {
                                row.Cells[0].Style.Add("text-align", "left");
                                row.Cells[1].Style.Add("text-align", "left");
                                row.Cells[2].Style.Add("text-align", "right");
                                row.Cells[3].Style.Add("text-align", "right");
                                row.Cells[4].Style.Add("text-align", "right");
                                row.Cells[5].Style.Add("text-align", "right");
                            }
                            else
                            {
                                row.Cells[0].Style.Add("text-align", "left");
                                row.Cells[1].Style.Add("text-align", "left");
                                row.Cells[2].Style.Add("text-align", "center");
                                row.Cells[3].Style.Add("text-align", "right");
                                row.Cells[4].Style.Add("text-align", "right");
                                row.Cells[5].Style.Add("text-align", "right");
                                row.Cells[6].Style.Add("text-align", "right");
                            }

                        }
                        //------------------------------------------

                        gv.RenderControl(hw);
                       
                        //-----------------------------------------------------------------------------------------------------------------------------------------------
                        string str = "Import_Summary.pdf";

                        HttpContext.Current.Session.Remove(Grid_Excel);
                        if (File.Exists(Grid_Excel + str))
                        {
                            DirectoryInfo dir = new DirectoryInfo(Grid_Excel);
                            foreach (FileInfo fi in dir.GetFiles())
                            {
                                fi.Delete();
                            }
                            str = "Import_Summary.pdf";

                            string path = (Grid_Excel + "\\" + str + "");

                            dynamic output = new FileStream(path, FileMode.Create);
                            StringReader sr = new StringReader(sw.ToString());
                            iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(PageSize.A4, 10f, 10f, 10f, 0f);
                            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                            iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDoc, output);
                            pdfDoc.Open();
                            htmlparser.Parse(sr);
                            pdfDoc.Close();

                            HttpContext.Current.Session["Import_Summary"] = Grid_Excel + str;
                        }
                        else
                        {

                            string path = (Grid_Excel + "\\" + str + "");

                            dynamic output = new FileStream(path, FileMode.Create);
                            StringReader sr = new StringReader(sw.ToString());
                            iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(PageSize.A4, 10f, 10f, 10f, 0f);
                            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                            iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDoc, output);
                            pdfDoc.Open();
                            htmlparser.Parse(sr);
                            pdfDoc.Close();

                            HttpContext.Current.Session["Import_Summary"] = Grid_Excel + str;
                        }

                        //----------------------------------------------------------------------------------------------------------------------------------------------
                    }
                }
            }

        }

    }


    public DataSet Load_Report_Data_GroupWise()
    {
        try
        {

            string[] arr = new string[] { };
            string[] arr2 = new string[] { };
            if (from_date != string.Empty && from_date != null)
            {
                arr = from_date.Split('/');
                from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (to_date != string.Empty && to_date != null)
            {
                arr2 = to_date.Split('/');
                to_date = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }


            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@Report_cat", Report_cat);
            param[1] = new SqlParameter("@from_date", from_date);
            param[2] = new SqlParameter("@to_date", to_date);
            param[3] = new SqlParameter("@Select_Item", Select_Item);
            param[4] = new SqlParameter("@Tr_mode", Tr_mode = Tr_mode == "All" ? "" : Tr_mode);
            // param[4] = new SqlParameter("@Tr_mode", Tr_mode);
            param[5] = new SqlParameter("@Branch", Branch);

            param[6] = new SqlParameter("@Qstart", Qstart);
            param[7] = new SqlParameter("@QEnd", QEnd);
            param[8] = new SqlParameter("@Start_month", StartDate);
            param[9] = new SqlParameter("@End_month", EndDate);

            param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[10].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_SUMMARY_RPT_GroupWise", param);

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }
}