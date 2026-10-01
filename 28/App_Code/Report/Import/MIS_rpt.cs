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

using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;


public class MIS_rpt:ErrorLogs
{

    SqlDataAdapter da;
    SqlDataReader dr;
    DataSet ds = new DataSet();
    SqlCommand cmd;
    DataTable dt = new DataTable();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    public int result = 0;

    private string _jobdate;
    private string _Imp_name;
    private string _Tr_mode;
    private string _branch;
    private string _BE_type;
    private string _port;
    private string _Report_cat;
    private string _search_con;
    private string _todate;
    private string _country;
    private string _jobno;

    private string _Branchcode;
    private string _userID;
    private string _cusHouse;

    //--------------
    string currentbranch = string.Empty;
    string SELECT_TYPE = string.Empty;
    string SELECT_BRANCH = string.Empty;


    public string Jobdate
    {
        get { return _jobdate; }
        set {_jobdate=value; }
    }
    public string Imp_name
    {
        get { return _Imp_name; }
        set { _Imp_name = value; }
    }
    public string Tr_mode
    {
        get { return _Tr_mode; }
        set { _Tr_mode = value; }
    }
    public string Branch
    {
        get { return _branch; }
        set { _branch = value; }
    }
    public string BE_type
    {
        get { return _BE_type; }
        set { _BE_type = value; }
    }
    public string Port
    {
        get { return _port; }
        set { _port = value; }
    }
    public string Report_cat
    {
        get {return _Report_cat; }
        set { _Report_cat=value ;}
    }

    public string Search_con
    {
        get { return _search_con; }
        set { _search_con = value; }
    }
    public string To_date
    {
        get { return _todate; }
        set { _todate = value; }
    }

    public string Country
    {
        get { return _country; }
        set { _country = value; }
    }

    public string JobNo
    {
        get { return _jobno; }
        set {_jobno=value; }
    }

    public string Branchcode
    {
        get { return _Branchcode; }
        set { _Branchcode = value; }
    }

    public string UserID
    {
        get { return _userID; }
        set { _userID = value; }
    }

    public string CusHouse
    {
        get { return _cusHouse; }
        set { _cusHouse = value; }
    }

    

    public DataTable MIS_info()
    {
        try
        {
            currentbranch = HttpContext.Current.Session["currentbranch"].ToString();
            // commented for areawise implementation on 05-mar-2020
        /*
            if ( HttpContext.Current.Session["SELECT_TYPE"] != null)
            {
                SELECT_TYPE = HttpContext.Current.Session["SELECT_TYPE"].ToString();
               

                if (SELECT_TYPE == "Branchwise Job")
                {
                    SELECT_BRANCH = currentbranch;
                }
                else
                {
                    SELECT_BRANCH = "";
                }
            }
            else
            {
                SELECT_BRANCH = "";
            }

              * */
            SELECT_BRANCH = Connection.Get_Company_Type();


            string[] arr = new string[] {};
            string[] arr2 = new string[] { };
            if (Jobdate!=string.Empty && Jobdate!=null )
            {
                arr = Jobdate.Split('/');
                Jobdate = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (To_date != string.Empty && To_date != null)
            {
                arr2 = To_date.Split('/');
                To_date = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[14];
            param[0] = new SqlParameter("@jobdate", Jobdate == string.Empty ? string.Empty : Jobdate);
            param[1] = new SqlParameter("@Importername", Imp_name==string.Empty? string.Empty:Imp_name);
            param[2] = new SqlParameter("@Mode", Tr_mode==string.Empty? string.Empty:Tr_mode);
            param[3] = new SqlParameter("@port",  Port==string.Empty? string.Empty:Port);
            param[4] = new SqlParameter("@BEtype", BE_type==string.Empty? string.Empty:BE_type);
            param[5] = new SqlParameter("@Branch", Branch == string.Empty ? string.Empty : Branch);

            param[6] = new SqlParameter("@todate", To_date == string.Empty ? string.Empty : To_date);
            param[7] = new SqlParameter("@Country",Country== string.Empty ? string.Empty :Country);

            //param[8] = new SqlParameter("@Branchcode", SELECT_BRANCH == string.Empty ? string.Empty : Branchcode);//09-08-2021 by Chithra for Boxco
            param[8] = new SqlParameter("@Branchcode", SELECT_BRANCH);

            param[9] = new SqlParameter("@Report_Cat", Report_cat);

            param[10] = new SqlParameter("@UserId", UserID == string.Empty ? string.Empty : UserID);   // Added by shanthini on 18-06-2026  
            param[11] = new SqlParameter("@CusHouse", CusHouse == string.Empty ? string.Empty : CusHouse); 


            param[12] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[12].Direction = ParameterDirection.Output;
            param[13] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[13].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "sp_MIS_info", param);
            result = Convert.ToInt32(param[12].Value.ToString());
            
         }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        //return ds.Tables[0];
        return (ds.Tables.Count > 0) ? ds.Tables[0] : new DataTable();
    }


    public DataTable MIS_Statement_rpt()    
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

            param[0] = new SqlParameter("@jobno", JobNo == string.Empty ? string.Empty : JobNo);
            param[1] = new SqlParameter("@imp_name", Imp_name == string.Empty ? string.Empty : Imp_name);
            param[2] = new SqlParameter("@from_date", Jobdate == string.Empty ? string.Empty : Jobdate);
            param[3] = new SqlParameter("@to_date", To_date == string.Empty ? string.Empty : To_date);
            param[4] = new SqlParameter("@Tr_mode", Tr_mode == string.Empty ? string.Empty : Tr_mode);
            param[5] = new SqlParameter("@Branch", Branch == string.Empty ? string.Empty : Branch);


            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_MIS_statement_Rpt", param);
            result = Convert.ToInt32(param[6].Value.ToString());

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds.Tables[0];
    }



    //public void Open_MIS_XLs_Report(string Jobdate_, string Imp_name_, string Tr_mode_, string Branch_, string BE_type_, string Report_cat_, string Port_, string Type_, string To_date_, string Country_, string UserID_, string CusHouse_)
    //{
    //    HttpResponse Response = HttpContext.Current.Response;
    //    Jobdate = Jobdate_;
    //    Imp_name = Imp_name_;
    //    Tr_mode = Tr_mode_;
    //    Branch = Branch_;
    //    BE_type = BE_type_ == "All" ? "" : BE_type_;
    //    Report_cat = Report_cat_;
    //    Port = Port_;
    //    To_date = To_date_ == " " ? string.Empty : To_date_;
    //    Country = Country_;
    //    UserID = UserID_;   
    //    CusHouse = CusHouse_; 


    //    DataView dv = new DataView(MIS_info());
    //    DataTable dt = dv.ToTable();
    //    if (Type_ == "excel")
    //    {

    //        Response.Clear();
    //        Response.Buffer = true;
    //        Response.AddHeader("content-disposition", "attachment;filename=" + Report_cat + ".xls");
    //        Response.Charset = "";
    //        Response.ContentType = "application/vnd.ms-excel";
    //        using (StringWriter sw = new StringWriter())
    //        {
    //            HtmlTextWriter hw = new HtmlTextWriter(sw);

    //            //To Export all pages
    //            GridView gv = new GridView();
    //            gv.AllowPaging = false;
    //            gv.DataSource = dt;
    //            gv.DataBind();


    //            foreach (TableCell cell in gv.HeaderRow.Cells)
    //            {
    //                cell.BackColor = gv.HeaderStyle.BackColor;
    //            }



    //            gv.RenderControl(hw);

    //            //style to format numbers to string
    //            string style = @"<style> .textmode { } </style>";
    //            Response.Write(style);
    //            Response.Output.Write(sw.ToString());
    //            Response.Flush();
    //            Response.End();
    //        }


    //        /*string attachment = "attachment; filename=" + Report_cat + ".xls";
    //        Response.ClearContent();
    //        Response.AddHeader("content-disposition", attachment);
    //        Response.ContentType = "application/vnd.ms-excel";
    //        string tab = "";
    //        foreach (DataColumn dc in dt.Columns)
    //        {
    //            Response.Write(tab + dc.ColumnName);
    //            tab = "\t";
    //        }
    //        Response.Write("\n");
    //        int i;
    //        foreach (DataRow dr in dt.Rows)
    //        {
    //            tab = "";
    //            for (i = 0; i < dt.Columns.Count; i++)
    //            {
    //                Response.Write(tab + dr[i].ToString());
    //                tab = "\t";
    //            }
    //            Response.Write("\n");
    //        }
    //        Response.End();*/

    //    }
    //    if (Type_ == "Pdf")
    //    {
    //        if (dt.Rows.Count > 0)
    //        {
    //            Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //            using (StringWriter sw = new StringWriter())
    //            {
    //                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
    //                {
    //                    GridView gv = new GridView();
    //                    gv.AllowPaging = false;
    //                    gv.DataSource = dt;
    //                    gv.DataBind();

    //                    //-----------------------------------------
    //                    gv.HeaderRow.Style.Add("font-weight", "bold");
    //                    gv.HeaderRow.Style.Add("font-size", "15PX");
    //                    gv.HeaderRow.Style.Add("text-align", "center");

    //                    for (int i = 0; i < gv.Rows.Count; i++)
    //                    {
    //                        GridViewRow row = gv.Rows[i];
    //                        row.Attributes.Add("class", "textmode");

    //                        row.Cells[0].Style.Add("text-align", "left");
    //                        row.Cells[1].Style.Add("text-align", "center");
    //                        row.Cells[2].Style.Add("text-align", "center");
    //                        row.Cells[3].Style.Add("text-align", "right");
    //                        row.Cells[4].Style.Add("text-align", "right");
    //                        row.Cells[5].Style.Add("text-align", "right");
    //                        row.Cells[6].Style.Add("text-align", "right");

    //                    }
    //                    //------------------------------------------


    //                    gv.RenderControl(hw);
    //                    StringReader sr = new StringReader(sw.ToString());
    //                    Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
    //                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
    //                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
    //                    pdfDoc.Open();
    //                    htmlparser.Parse(sr);
    //                    pdfDoc.Close();

    //                    Response.ContentType = "application/pdf";
    //                    Response.AddHeader("content-disposition", "attachment;filename=" + Report_cat + ".pdf");
    //                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //                    Response.Write(pdfDoc);
    //                    Response.End();

    //                }
    //            }
    //        }

    //    }

    //}


    // ============================================================================

    //public void Open_MIS_XLs_Report(string Jobdate_, string Imp_name_, string Tr_mode_, string Branch_, string BE_type_, string Report_cat_, string Port_, string Type_, string To_date_, string Country_, string UserID_, string CusHouse_)
    //{
    //    HttpResponse Response = HttpContext.Current.Response;
    //    Jobdate = Jobdate_;
    //    Imp_name = Imp_name_;
    //    Tr_mode = Tr_mode_;
    //    Branch = Branch_;
    //    BE_type = BE_type_ == "All" ? "" : BE_type_;
    //    Report_cat = Report_cat_;
    //    Port = Port_;
    //    To_date = To_date_ == " " ? string.Empty : To_date_;
    //    Country = Country_;
    //    UserID = UserID_;
    //    CusHouse = CusHouse_;

    //    DataView dv = new DataView(MIS_info());
    //    DataTable dt = dv.ToTable();

    //    // ── EXCEL ───────────────────────────────────────────────────────────────
    //    if (Type_ == "excel")
    //    {
    //        if (dt.Rows.Count > 0)                       
    //        {
    //            Response.Clear();
    //            Response.Buffer = true;
    //            Response.AddHeader("content-disposition", "attachment;filename=" + Report_cat + ".xls");
    //            Response.Charset = "";
    //            Response.ContentType = "application/vnd.ms-excel";
    //            using (StringWriter sw = new StringWriter())
    //            {
    //                HtmlTextWriter hw = new HtmlTextWriter(sw);

    //                GridView gv = new GridView();
    //                gv.HeaderStyle.BackColor = System.Drawing.Color.RoyalBlue; 
    //                gv.HeaderStyle.ForeColor = System.Drawing.Color.White;
    //                gv.AllowPaging = false;
    //                gv.DataSource = dt;
    //                gv.DataBind();

    //                if (gv.HeaderRow != null)
    //                {
    //                    foreach (TableCell cell in gv.HeaderRow.Cells)
    //                    {
    //                        cell.BackColor = gv.HeaderStyle.BackColor;
    //                    }
    //                }

    //                gv.RenderControl(hw);

    //                string style = @"<style> .textmode { } </style>";
    //                Response.Write(style);
    //                Response.Output.Write(sw.ToString());
    //                Response.Flush();
    //                Response.End();
    //            }
    //        }
    //        else
    //        {
    //            Response.Clear();
    //            Response.Write("NO DATA: rows=0 | Branch=" + Branch + " | Report_cat=" + Report_cat + " | To_date=" + To_date);
    //            Response.End();
    //        }
    //    }

    //    // ── PDF ───────────────────────────────────────────────────────────────
    //    if (Type_ == "Pdf")
    //    {
    //        if (dt.Rows.Count > 0)
    //        {
    //            Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //            using (StringWriter sw = new StringWriter())
    //            {
    //                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
    //                {
    //                    GridView gv = new GridView();
    //                    gv.AllowPaging = false;
    //                    gv.DataSource = dt;
    //                    gv.DataBind();

    //                    if (gv.HeaderRow != null)
    //                    {
    //                        gv.HeaderRow.Style.Add("font-weight", "bold");
    //                        gv.HeaderRow.Style.Add("font-size", "15PX");
    //                        gv.HeaderRow.Style.Add("text-align", "center");
    //                    }

    //                    for (int i = 0; i < gv.Rows.Count; i++)
    //                    {
    //                        GridViewRow row = gv.Rows[i];
    //                        row.Attributes.Add("class", "textmode");

                           
    //                        if (row.Cells.Count > 0) row.Cells[0].Style.Add("text-align", "left");
    //                        if (row.Cells.Count > 1) row.Cells[1].Style.Add("text-align", "center");
    //                        if (row.Cells.Count > 2) row.Cells[2].Style.Add("text-align", "center");
    //                        if (row.Cells.Count > 3) row.Cells[3].Style.Add("text-align", "right");
    //                        if (row.Cells.Count > 4) row.Cells[4].Style.Add("text-align", "right");
    //                        if (row.Cells.Count > 5) row.Cells[5].Style.Add("text-align", "right");
    //                        if (row.Cells.Count > 6) row.Cells[6].Style.Add("text-align", "right");
    //                    }

    //                    gv.RenderControl(hw);
    //                    StringReader sr = new StringReader(sw.ToString());
    //                    Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
    //                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
    //                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
    //                    pdfDoc.Open();
    //                    htmlparser.Parse(sr);
    //                    pdfDoc.Close();

    //                    Response.ContentType = "application/pdf";
    //                    Response.AddHeader("content-disposition", "attachment;filename=" + Report_cat + ".pdf");
    //                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //                    //Response.Write(pdfDoc);
    //                    Response.End();
    //                }
    //            }
    //        }
    //    }
    //    else
    //    {
    //        Response.Clear();
    //        Response.Write("NO DATA: rows=0 | Branch=" + Branch + " | Report_cat=" + Report_cat);
    //        Response.End();
    //    }
    //}

    public void Open_MIS_XLs_Report(string Jobdate_, string Imp_name_, string Tr_mode_, string Branch_, string BE_type_, string Report_cat_, string Port_, string Type_, string To_date_, string Country_, string UserID_, string CusHouse_)
    {
        HttpResponse Response = HttpContext.Current.Response;
        Jobdate = Jobdate_;
        Imp_name = Imp_name_;
        Tr_mode = Tr_mode_;
        Branch = Branch_;
        BE_type = BE_type_ == "All" ? "" : BE_type_;
        Report_cat = Report_cat_;
        Port = Port_;
        To_date = To_date_ == " " ? string.Empty : To_date_;
        Country = Country_;
        UserID = UserID_;
        CusHouse = CusHouse_;

        DataView dv = new DataView(MIS_info());
        DataTable dt = dv.ToTable();
        while (dt.Columns.Count > 12)
            dt.Columns.RemoveAt(dt.Columns.Count - 1);

        // ── EXCEL ───────────────────────────────────────────────────────────────
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

                    GridView gv = new GridView();
                    //gv.HeaderStyle.BackColor = System.Drawing.Color.RoyalBlue;
                    //gv.HeaderStyle.ForeColor = System.Drawing.Color.White;
                    gv.AllowPaging = false;
                    gv.GridLines = GridLines.Both;
                    gv.AutoGenerateColumns = true;
                    gv.DataSource = dt;
                    gv.DataBind();

                    // Color ONLY the real header columns (prevents blue bleeding into extra column)
                    if (gv.HeaderRow != null)
                    {
                        for (int c = 0; c < dt.Columns.Count; c++)
                        {
                            if (c < gv.HeaderRow.Cells.Count)
                            {
                                gv.HeaderRow.Cells[c].BackColor = System.Drawing.Color.RoyalBlue;
                                gv.HeaderRow.Cells[c].ForeColor = System.Drawing.Color.White;
                            }
                        }
                    }

                    gv.RenderControl(hw);

                    string style = @"<style> .textmode { } </style>";
                    Response.Write(style);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
            }
            else
            {
                Response.Clear();
                Response.Write("NO DATA: rows=0 | Branch=" + Branch + " | Report_cat=" + Report_cat + " | To_date=" + To_date);
                Response.End();
            }
        }

        // ── PDF ───────────────────────────────────────────────────────────────
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

                        if (gv.HeaderRow != null)
                        {
                            gv.HeaderRow.Style.Add("font-weight", "bold");
                            gv.HeaderRow.Style.Add("font-size", "15PX");
                            gv.HeaderRow.Style.Add("text-align", "center");
                        }

                        for (int i = 0; i < gv.Rows.Count; i++)
                        {
                            GridViewRow row = gv.Rows[i];
                            row.Attributes.Add("class", "textmode");

                            if (row.Cells.Count > 0) row.Cells[0].Style.Add("text-align", "left");
                            if (row.Cells.Count > 1) row.Cells[1].Style.Add("text-align", "center");
                            if (row.Cells.Count > 2) row.Cells[2].Style.Add("text-align", "center");
                            if (row.Cells.Count > 3) row.Cells[3].Style.Add("text-align", "right");
                            if (row.Cells.Count > 4) row.Cells[4].Style.Add("text-align", "right");
                            if (row.Cells.Count > 5) row.Cells[5].Style.Add("text-align", "right");
                            if (row.Cells.Count > 6) row.Cells[6].Style.Add("text-align", "right");
                        }

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
                        Response.End();
                    }
                }
            }
            else
            {
                Response.Clear();
                Response.Write("NO DATA: rows=0 | Branch=" + Branch + " | Report_cat=" + Report_cat);
                Response.End();
            }
        }
    }

    public void Open_MIS_XLs_Statement_Report(string Jobdate_, string Imp_name_, string Tr_mode_, string jobno_, string To_date_, string Type_)
    {

        HttpResponse Response = HttpContext.Current.Response;
        Jobdate = Jobdate_;
        Imp_name = Imp_name_;
        Tr_mode = Tr_mode_;
        To_date = To_date_ == " " ? string.Empty : To_date_;
        JobNo = jobno_;

        if (HttpContext.Current.Session["SELECT_TYPE"] != null)
        {
            // commented for areawise implementation on 05-mar-2020
            /*
                SELECT_TYPE = HttpContext.Current.Session["SELECT_TYPE"].ToString();

                if (SELECT_TYPE == "Branchwise Job")
                {
                    Branch = HttpContext.Current.Session["currentbranch"].ToString();
                }
                else
                {
                    Branch = "";
                }
            }
            else
            {
                Branch = "";
            }
              * */
            Branch = Connection.Get_Company_Type();

            DataView dv = new DataView(MIS_Statement_rpt());
            DataTable dt = dv.ToTable();
            if (Type_ == "excel")
            {

                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=MIS_Statement.xls");
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
                            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                            pdfDoc.Open();
                            htmlparser.Parse(sr);
                            pdfDoc.Close();

                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-disposition", "attachment;filename=MIS_Statement.pdf");
                            Response.Cache.SetCacheability(HttpCacheability.NoCache);
                            Response.Write(pdfDoc);
                            Response.End();

                        }
                    }
                }

            }
        }
    }

    public DataSet imp_name_search()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@Imp_name", Imp_name);
            param[1] = new SqlParameter("@searh_con", Search_con);
            param[4] = new SqlParameter("@UserCreation_ID", HttpContext.Current.Session["USER_CREATION_ID"].ToString());

            
            param[2] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[2].Direction = ParameterDirection.Output;
            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;

            //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "sp_MIS_Auto_search", param);
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "sp_MIS_Auto_search_USERWISE_IEC_BASED_SEARCH", param);

            result = Convert.ToInt32(param[3].Value.ToString());

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet imp_name_search(string DB_Conn)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@Imp_name", Imp_name);
            param[1] = new SqlParameter("@searh_con", Search_con);


            param[2] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[2].Direction = ParameterDirection.Output;
            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(DB_Conn, CommandType.StoredProcedure, "sp_MIS_Auto_search", param);
            result = Convert.ToInt32(param[3].Value.ToString());

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public void MIS_XLs_Report_1_Mail(string Jobdate_, string Imp_name_, string Tr_mode_, string Branch_, string BE_type_, string Report_cat_, string Port_, string Type_, string To_date_, string Country_)
    {
        string Grid_Excel = HttpContext.Current.Server.MapPath("~/Submission/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + HttpContext.Current.Session["currentbranch"].ToString() + "/" + HttpContext.Current.Session["currentuser"].ToString() + "/" + "Grid_Excel" + "/");

        if (Directory.Exists(Grid_Excel) == false)
        {
            Directory.CreateDirectory(Grid_Excel);
        }

        HttpResponse Response = HttpContext.Current.Response;
        Jobdate = Jobdate_;
        Imp_name = Imp_name_;
        Tr_mode = Tr_mode_;
        Branch = Branch_;
        BE_type = BE_type_ == "All" ? "" : BE_type_;
        Report_cat = Report_cat_;
        Port = Port_;
        To_date = To_date_ == " " ? string.Empty : To_date_;
        Country = Country_;

        DataView dv = new DataView(MIS_info());
        DataTable dt = dv.ToTable();
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

                foreach (TableCell cell in gv.HeaderRow.Cells)
                {
                    cell.BackColor = gv.HeaderStyle.BackColor;
                }
                gv.RenderControl(hw);

                string str = "IMP_" + Report_cat_ + "_MIS_1.xls";
                HttpContext.Current.Session.Remove(Grid_Excel);
                if (File.Exists(Grid_Excel + str))
                {
                    DirectoryInfo dir = new DirectoryInfo(Grid_Excel);
                    foreach (FileInfo fi in dir.GetFiles())
                    {
                        fi.Delete();
                    }
                    str = "IMP_" + Report_cat_ + "_MIS_1.xls";

                    StreamWriter myWriter = new StreamWriter((Grid_Excel + "\\" + str + ""), true, System.Text.Encoding.Unicode);
                    myWriter.Write(sw.ToString());
                    myWriter.Flush();
                    myWriter.Close();

                    HttpContext.Current.Session["IMP_MIS_1_Grid_Excel"] = Grid_Excel + str;
                }
                else
                {
                    StreamWriter myWriter = new StreamWriter((Grid_Excel + "\\" + str + ""), true, System.Text.Encoding.Unicode);
                    myWriter.Write(sw.ToString());
                    myWriter.Flush();
                    myWriter.Close();

                    HttpContext.Current.Session["IMP_MIS_1_Grid_Excel"] = Grid_Excel + str;
                }
            }
        }
    }

    public void Open_MIS_2_XLs_Mail(string Jobdate_, string Imp_name_, string Tr_mode_, string jobno_, string To_date_, string Type_)
    {

        string Grid_Excel = HttpContext.Current.Server.MapPath("~/Submission/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + HttpContext.Current.Session["currentbranch"].ToString() + "/" + HttpContext.Current.Session["currentuser"].ToString() + "/" + "Grid_Excel" + "/");

        if (Directory.Exists(Grid_Excel) == false)
        {
            Directory.CreateDirectory(Grid_Excel);
        }

        HttpResponse Response = HttpContext.Current.Response;
        Jobdate = Jobdate_;
        Imp_name = Imp_name_;
        Tr_mode = Tr_mode_;
        To_date = To_date_ == " " ? string.Empty : To_date_;
        JobNo = jobno_;

        DataView dv = new DataView(MIS_Statement_rpt());
        DataTable dt = dv.ToTable();
        if (Type_ == "excel")
        {

            Response.Clear();
            Response.Buffer = true;
            
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

                string str = "IMP_MIS_2.xls";
                HttpContext.Current.Session.Remove(Grid_Excel);
                if (File.Exists(Grid_Excel + str))
                {
                    DirectoryInfo dir = new DirectoryInfo(Grid_Excel);
                    foreach (FileInfo fi in dir.GetFiles())
                    {
                        fi.Delete();
                    }
                    str = "IMP_MIS_2.xls";

                    StreamWriter myWriter = new StreamWriter((Grid_Excel + "\\" + str + ""), true, System.Text.Encoding.Unicode);
                    myWriter.Write(sw.ToString());
                    myWriter.Flush();
                    myWriter.Close();

                    HttpContext.Current.Session["IMP_MIS_2_Grid_Excel"] = Grid_Excel + str;
                }
                else
                {
                    StreamWriter myWriter = new StreamWriter((Grid_Excel + "\\" + str + ""), true, System.Text.Encoding.Unicode);
                    myWriter.Write(sw.ToString());
                    myWriter.Flush();
                    myWriter.Close();

                    HttpContext.Current.Session["IMP_MIS_2_Grid_Excel"] = Grid_Excel + str;
                }


            }

        }
    }

}