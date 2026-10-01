using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using ClosedXML.Excel;
//using tem = Microsoft.Office.Interop;

//using DocumentFormat.OpenXml.Packaging;
//using DocumentFormat.OpenXml.Spreadsheet;

public class BMW_Excel
{
    DataTable dt = new DataTable();

    private string _Jobno;
    private string _Branch_Code;
    private string _Importer_Name;
    private string _Based_Date;
    private string _fromdate;
    private string _todate;
    private string _flag;


    public string Jobno { get { return _Jobno; } set { _Jobno = value; } }
    public string Branch_Code { get { return _Branch_Code; } set { _Branch_Code = value; } }
    public string Importer_Name { get { return _Importer_Name; } set { _Importer_Name = value; } }
    public string Based_Date { get { return _Based_Date; } set { _Based_Date = value; } }
    public string fromdate { get { return _fromdate; } set { _fromdate = value; } }
    public string todate { get { return _todate; } set { _todate = value; } }
    public string flag { get { return _flag; } set { _flag = value; } }


    public int result;

    public DataSet RetrieveAll_IMPORT_BMW_EXCEL()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[5];

            param[0] = new SqlParameter("@JOBNO", Jobno);
            param[1] = new SqlParameter("@Branch_Code", Branch_Code);

            param[2] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[2].Direction = ParameterDirection.Output;

            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_SANCO_BMW_EXCEL_REPORT", param);
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

    public DataSet RetrieveAll_IMPORT_DUTYWORKSHEET_EXCEL()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[5];

            param[0] = new SqlParameter("@JOBNO", Jobno);
            param[1] = new SqlParameter("@Branch_Code", Branch_Code);

            param[2] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[2].Direction = ParameterDirection.Output;

            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_DUTY_WORKSHEET_EXCEL_REPORT", param);
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

    public void Open_Import_SANCO_BMW_XLs(string Jobno_, string Branch_Common_)
    {

        HttpResponse Response = HttpContext.Current.Response;
        BMW_Excel BMW = new BMW_Excel();
        DataTable dt = new DataTable();
        dt.Rows.Add();

        BMW.Jobno = Jobno_;
        BMW.Branch_Code = Branch_Common_;

        DataSet dss = BMW.RetrieveAll_IMPORT_BMW_EXCEL();
        dt = dss.Tables[0];

        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss
        string Filename = "";

        Filename = "JobNo-" + Jobno_ + "-BMW_RPT";
        string strrptNametime = Filename + "_" + s;

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=" + strrptNametime + ".xls");
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

            /*
            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);         
            TableCell HeaderCell = new TableCell();

            HeaderCell.Text = Jobno_ + " BMW" + "----" + "Dt:" + time.ToString();
            HeaderCell.ColumnSpan = 12;
            //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#F87217");
            HeaderCell.BackColor = System.Drawing.Color.PowderBlue;
            HeaderCell.Font.Bold = true;
            HeaderCell.Font.Size = 14;
            HeaderCell.Height = 40;
            HeaderCell.Style.Add("text-align", "center");
            HeaderCell.Style.Add("NumberFormat", "@");

            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderCell.BackColor = System.Drawing.Color.PowderBlue;
            HeaderGridRow.Cells.Add(HeaderCell);
            */

            gv.GridLines = 0;
            gv.Font.Size = 9;
            // *******************HEADER ROW SETTINGS----------------------------------
            gv.HeaderRow.BackColor = System.Drawing.Color.LightGray;
            gv.HeaderRow.Font.Size = 11;
            gv.HeaderRow.Font.Underline = true;
            //gv.HeaderRow.BorderStyle = System.Web.UI.WebControls.BorderStyle.Outset;
            //gv.HeaderRow.BorderWidth = 1;
            //gv.HeaderRow.Font.Underline = true;

            //*************************************************************************


            //*********************DATA ROW SETTINGS***********************************
            for (int i = 0; i < gv.Rows.Count; i++)
            {
                GridViewRow row = gv.Rows[i];

                row.Cells[0].Width = 100;
                row.Cells[1].Width = 320;
                row.Cells[2].Width = 150;
                row.Cells[3].Width = 100;
                row.Cells[4].Width = 600;
                row.Cells[5].Width = 100;
                row.Cells[6].Width = 150;
                row.Cells[7].Width = 130;
                row.Cells[8].Width = 110;
                row.Cells[9].Width = 110;

                //if (i == 0)
                //{
                //    row.Cells[0].BorderWidth = 1;
                //}

                //row.Cells[0].Style.Add("NumberFormat ", "text");
                //row.Cells[i].Attributes.Add("style", "textmode");

                row.Attributes.Add("class", "textmode");

                row.Cells[0].Style.Add("text-align", "center");
                row.Cells[1].Style.Add("text-align", "left");
                row.Cells[2].Style.Add("text-align", "left");
                row.Cells[3].Style.Add("text-align", "left");
                row.Cells[4].Style.Add("text-align", "left");
                row.Cells[5].Style.Add("text-align", "left");
                row.Cells[6].Style.Add("text-align", "left");
                row.Cells[7].Style.Add("text-align", "right");
                row.Cells[8].Style.Add("text-align", "right");
                row.Cells[9].Style.Add("text-align", "right");

                if (gv.Rows[i].Cells[0].Text.Substring(0, 1) == "0")
                {
                    gv.Rows[i].Cells[0].Text = "'" + gv.Rows[i].Cells[0].Text;
                }
                if (gv.Rows[i].Cells[1].Text.Substring(0, 1) == "0")
                {
                    gv.Rows[i].Cells[1].Text = "'" + gv.Rows[i].Cells[1].Text;
                }
                if (gv.Rows[i].Cells[2].Text.Substring(0, 2) == "00")
                {
                    gv.Rows[i].Cells[2].Text = "'" + gv.Rows[i].Cells[2].Text;
                }
                if (gv.Rows[i].Cells[3].Text.Substring(0, 1) == "0")
                {
                    gv.Rows[i].Cells[3].Text = "'" + gv.Rows[i].Cells[3].Text;
                }
                if (gv.Rows[i].Cells[4].Text.Substring(0, 1) == "0")
                {
                    gv.Rows[i].Cells[4].Text = "'" + gv.Rows[i].Cells[4].Text;
                }
                gv.Rows[i].Cells[8].Font.Bold = true;
                gv.Rows[i].Cells[8].Font.Size = 10;

            }
            //*************************************************************************

            //gv.Controls[0].Controls.AddAt(0, HeaderGridRow);
            gv.RenderControl(hw);

            //string style = @"<style> .text { } </style>";
            //string style = @"<style> .text { mso-number-format:\@; } </style>";
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            //Response.ContentType = "application/text";
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }

    public void Open_Import_DUTY_WORKSHEET_XLs(string Jobno_, string Branch_Common_)
    {

        HttpResponse Response = HttpContext.Current.Response;
        BMW_Excel BMW = new BMW_Excel();
        DataTable dt = new DataTable();
        dt.Rows.Add();

        BMW.Jobno = Jobno_;
        BMW.Branch_Code = Branch_Common_;

        DataSet dss = BMW.RetrieveAll_IMPORT_DUTYWORKSHEET_EXCEL();
        dt = dss.Tables[0];

        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss
        string Filename = "";

        Filename = "JobNo-" + Jobno_ + "-IMPORT_DUTY_WORKSHEET";
        string strrptNametime = Filename + "_" + s;

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=" + strrptNametime + ".xls");
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

            /*
            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);         
            TableCell HeaderCell = new TableCell();

            HeaderCell.Text = Jobno_ + " BMW" + "----" + "Dt:" + time.ToString();
            HeaderCell.ColumnSpan = 12;
            //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#F87217");
            HeaderCell.BackColor = System.Drawing.Color.PowderBlue;
            HeaderCell.Font.Bold = true;
            HeaderCell.Font.Size = 14;
            HeaderCell.Height = 40;
            HeaderCell.Style.Add("text-align", "center");
            HeaderCell.Style.Add("NumberFormat", "@");

            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderCell.BackColor = System.Drawing.Color.PowderBlue;
            HeaderGridRow.Cells.Add(HeaderCell);
            */

            gv.GridLines = 0;
            gv.Font.Size = 9;
            // *******************HEADER ROW SETTINGS----------------------------------
            gv.HeaderRow.BackColor = System.Drawing.Color.LightGray;
            gv.HeaderRow.Font.Size = 11;
            gv.HeaderRow.Font.Underline = true;
            //gv.HeaderRow.BorderStyle = System.Web.UI.WebControls.BorderStyle.Outset;
            //gv.HeaderRow.BorderWidth = 1;
            //gv.HeaderRow.Font.Underline = true;

            //*************************************************************************


            //*********************DATA ROW SETTINGS***********************************
            for (int i = 0; i < gv.Rows.Count; i++)
            {
                GridViewRow row = gv.Rows[i];

                row.Cells[0].Width = 50;
                row.Cells[1].Width = 320;
                row.Cells[2].Width = 150;
                row.Cells[3].Width = 100;
                row.Cells[4].Width = 100;
                row.Cells[5].Width = 150;
                row.Cells[6].Width = 100;
                row.Cells[7].Width = 150;
                row.Cells[8].Width = 100;
                row.Cells[9].Width = 100;
                row.Cells[11].Width = 400;

                //if (i == 0)
                //{
                //    row.Cells[0].BorderWidth = 1;
                //}

                //row.Cells[0].Style.Add("NumberFormat ", "text");
                //row.Cells[i].Attributes.Add("style", "textmode");

                row.Attributes.Add("class", "textmode");

                row.Cells[0].Style.Add("text-align", "center");
                row.Cells[1].Style.Add("text-align", "left");
                row.Cells[2].Style.Add("text-align", "left");
                row.Cells[3].Style.Add("text-align", "left");
                row.Cells[4].Style.Add("text-align", "left");
                row.Cells[5].Style.Add("text-align", "left");
                row.Cells[6].Style.Add("text-align", "left");
                row.Cells[7].Style.Add("text-align", "right");
                row.Cells[8].Style.Add("text-align", "right");
                row.Cells[9].Style.Add("text-align", "right");
                row.Cells[21].Style.Add("text-align", "center");
                row.Cells[22].Style.Add("text-align", "center");
                row.Cells[27].Style.Add("text-align", "center");
                row.Cells[28].Style.Add("text-align", "center");
                row.Cells[29].Style.Add("text-align", "center");
                row.Cells[30].Style.Add("text-align", "center");
                row.Cells[31].Style.Add("text-align", "center");
                row.Cells[32].Style.Add("text-align", "center");
                row.Cells[33].Style.Add("text-align", "center");
                row.Cells[34].Style.Add("text-align", "center");
                row.Cells[35].Style.Add("text-align", "center");

                row.Cells[36].Style.Add("text-align", "center");
                row.Cells[38].Style.Add("text-align", "left");
                row.Cells[39].Style.Add("text-align", "center");


                if (gv.Rows[i].Cells[0].Text.Substring(0, 1) == "0")
                {
                    gv.Rows[i].Cells[0].Text = "'" + gv.Rows[i].Cells[0].Text;
                }
                if (gv.Rows[i].Cells[1].Text.Substring(0, 1) == "0")
                {
                    gv.Rows[i].Cells[1].Text = "'" + gv.Rows[i].Cells[1].Text;
                }
                if (gv.Rows[i].Cells[2].Text.Substring(0, 2) == "00")
                {
                    gv.Rows[i].Cells[2].Text = "'" + gv.Rows[i].Cells[2].Text;
                }
                if (gv.Rows[i].Cells[3].Text.Substring(0, 1) == "0")
                {
                    gv.Rows[i].Cells[3].Text = "'" + gv.Rows[i].Cells[3].Text;
                }
                if (gv.Rows[i].Cells[4].Text.Substring(0, 1) == "0")
                {
                    gv.Rows[i].Cells[4].Text = "'" + gv.Rows[i].Cells[4].Text;
                }
                gv.Rows[i].Cells[8].Font.Bold = true;
                gv.Rows[i].Cells[8].Font.Size = 10;

            }
            //*************************************************************************

            //gv.Controls[0].Controls.AddAt(0, HeaderGridRow);
            gv.RenderControl(hw);

            //string style = @"<style> .text { } </style>";
            //string style = @"<style> .text { mso-number-format:\@; } </style>";
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            //Response.ContentType = "application/text";
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }

    public void Open_Import_Excel_Download_XLs(string Jobno_, string Branch_Common_)
    {

        HttpResponse Response = HttpContext.Current.Response;
        BMW_Excel BMW = new BMW_Excel();
        DataTable dt = new DataTable();
        dt.Rows.Add();

        BMW.Jobno = Jobno_;
        BMW.Branch_Code = Branch_Common_;

        DataSet dss = BMW.RetrieveAll_IMPORT_EXCELDOWNLOAD_EXCEL();
        dt = dss.Tables[0];


        DateTime time = DateTime.Now;
        //String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss
        string Filename = "";

        Filename = "JobNo-" + Jobno_ + "-IMPORT_INVOICE_ITEM";
        //string strrptNametime = Filename + "_" + s;
        string strrptNametime = Filename;


        //----------------------------------------------

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=" + strrptNametime + ".xls");
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

            /*
            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);         
            TableCell HeaderCell = new TableCell();

            HeaderCell.Text = Jobno_ + " BMW" + "----" + "Dt:" + time.ToString();
            HeaderCell.ColumnSpan = 12;
            //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#F87217");
            HeaderCell.BackColor = System.Drawing.Color.PowderBlue;
            HeaderCell.Font.Bold = true;
            HeaderCell.Font.Size = 14;
            HeaderCell.Height = 40;
            HeaderCell.Style.Add("text-align", "center");
            HeaderCell.Style.Add("NumberFormat", "@");

            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderCell.BackColor = System.Drawing.Color.PowderBlue;
            HeaderGridRow.Cells.Add(HeaderCell);
            */

            //gv.GridLines = 0;
            gv.Font.Size = 10;
            // *******************HEADER ROW SETTINGS----------------------------------// kavi & Ajith...Changes for Sri Logistics //
            gv.HeaderRow.BackColor = System.Drawing.Color.LightGray;
            gv.HeaderRow.Cells[0].BackColor = System.Drawing.Color.Yellow;
            gv.HeaderRow.Cells[1].BackColor = System.Drawing.Color.Yellow;
            gv.HeaderRow.Cells[2].BackColor = System.Drawing.Color.Yellow;
            gv.HeaderRow.Cells[3].BackColor = System.Drawing.Color.Yellow;
            gv.HeaderRow.Cells[4].BackColor = System.Drawing.Color.Yellow;
            gv.HeaderRow.Cells[5].BackColor = System.Drawing.Color.Yellow;
            gv.HeaderRow.Cells[6].BackColor = System.Drawing.Color.Yellow;
            gv.HeaderRow.Cells[7].BackColor = System.Drawing.Color.Yellow;
            gv.HeaderRow.Cells[8].BackColor = System.Drawing.Color.Yellow;
            gv.HeaderRow.Cells[18].BackColor = System.Drawing.Color.Yellow;
            gv.HeaderRow.Cells[19].BackColor = System.Drawing.Color.Yellow;
            gv.HeaderRow.Cells[20].BackColor = System.Drawing.Color.Yellow;
            gv.HeaderRow.Cells[21].BackColor = System.Drawing.Color.Yellow;
            gv.HeaderRow.Cells[22].BackColor = System.Drawing.Color.Yellow;
            gv.HeaderRow.Cells[25].BackColor = System.Drawing.Color.Yellow;
            gv.HeaderRow.Cells[26].BackColor = System.Drawing.Color.Yellow;
            gv.HeaderRow.Cells[31].BackColor = System.Drawing.Color.Yellow;
            gv.HeaderRow.Cells[32].BackColor = System.Drawing.Color.Yellow;
            gv.HeaderRow.Cells[33].BackColor = System.Drawing.Color.Yellow;
            gv.HeaderRow.Cells[34].BackColor = System.Drawing.Color.Yellow;
            gv.HeaderRow.Cells[35].BackColor = System.Drawing.Color.Yellow;
            gv.HeaderRow.Cells[36].BackColor = System.Drawing.Color.Yellow;
            gv.HeaderRow.Cells[55].BackColor = System.Drawing.Color.Yellow;
            gv.HeaderRow.Cells[56].BackColor = System.Drawing.Color.Yellow;
            gv.HeaderRow.Cells[97].BackColor = System.Drawing.Color.Yellow;
            gv.HeaderRow.Cells[98].BackColor = System.Drawing.Color.Yellow;
            gv.HeaderRow.Font.Size = 10;
            gv.HeaderRow.Font.Underline = true;

            //gv.HeaderRow.BorderStyle = System.Web.UI.WebControls.BorderStyle.Outset;
            //gv.HeaderRow.BorderWidth = 1;
            //gv.HeaderRow.Font.Underline = true;

            //*************************************************************************


            //*********************DATA ROW SETTINGS***********************************
            for (int i = 0; i < gv.Rows.Count; i++)
            {
                GridViewRow row = gv.Rows[i];

                row.Cells[0].Width = 100;
                row.Cells[1].Width = 200;
                row.Cells[2].Width = 110;
                row.Cells[3].Width = 130;
                row.Cells[4].Width = 150;
                row.Cells[5].Width = 130;
                row.Cells[6].Width = 150;
                row.Cells[7].Width = 150;
                row.Cells[8].Width = 150;
                row.Cells[9].Width = 150;
                row.Cells[10].Width = 150;
                row.Cells[11].Width = 150;
                row.Cells[12].Width = 150;
                row.Cells[13].Width = 150;
                row.Cells[14].Width = 150;
                row.Cells[15].Width = 150;
                row.Cells[16].Width = 150;
                row.Cells[17].Width = 150;
                row.Cells[18].Width = 600;
                row.Cells[19].Width = 600;
                row.Cells[20].Width = 150;
                row.Cells[21].Width = 150;
                row.Cells[22].Width = 150;
                row.Cells[23].Width = 150;
                row.Cells[24].Width = 150;
                row.Cells[25].Width = 150;
                row.Cells[26].Width = 150;
                row.Cells[27].Width = 150;
                row.Cells[28].Width = 150;
                row.Cells[29].Width = 150;
                row.Cells[30].Width = 150;
                row.Cells[31].Width = 200;
                row.Cells[32].Width = 150;
                row.Cells[33].Width = 150;
                row.Cells[34].Width = 150;
                row.Cells[35].Width = 200;
                row.Cells[36].Width = 200;
                row.Cells[37].Width = 200;
                row.Cells[38].Width = 150;
                row.Cells[39].Width = 150;
                row.Cells[40].Width = 150;
                row.Cells[41].Width = 100;
                row.Cells[42].Width = 100;
                row.Cells[43].Width = 150;
                row.Cells[44].Width = 150;
                row.Cells[45].Width = 200;
                row.Cells[46].Width = 150;
                row.Cells[47].Width = 150;
                row.Cells[48].Width = 150;
                row.Cells[49].Width = 100;
                row.Cells[50].Width = 200;
                row.Cells[51].Width = 150;
                row.Cells[52].Width = 150;
                row.Cells[53].Width = 150;
                row.Cells[54].Width = 150;
                row.Cells[55].Width = 150;
                row.Cells[56].Width = 200;
                row.Cells[57].Width = 200;
                row.Cells[58].Width = 200;
                row.Cells[59].Width = 200;
                row.Cells[60].Width = 200;
                row.Cells[61].Width = 200;
                row.Cells[62].Width = 200;
                row.Cells[63].Width = 150;
                row.Cells[64].Width = 150;
                row.Cells[65].Width = 150;
                row.Cells[66].Width = 150;
                row.Cells[67].Width = 150;
                row.Cells[68].Width = 150;
                row.Cells[69].Width = 150;
                row.Cells[70].Width = 150;
                row.Cells[71].Width = 200;
                row.Cells[72].Width = 200;
                row.Cells[73].Width = 200;
                row.Cells[74].Width = 200;
                row.Cells[75].Width = 200;
                row.Cells[76].Width = 150;
                row.Cells[77].Width = 150;
                row.Cells[78].Width = 150;
                row.Cells[79].Width = 150;


                gv.Rows[i].Cells[0].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[1].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[2].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[3].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[4].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[5].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[6].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[7].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[8].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[9].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[10].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[11].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[12].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[13].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[14].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[15].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[16].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[17].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[18].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[19].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[20].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[21].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[22].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[23].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[24].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[25].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[26].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[27].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[28].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[29].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[30].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[31].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[32].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[33].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[34].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[35].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[36].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[37].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[38].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[39].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[40].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[41].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[42].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[43].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[44].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[45].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[46].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[47].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[48].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[49].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[50].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[51].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[52].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[53].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[54].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[55].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[56].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[57].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[58].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[59].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[60].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[61].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[62].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[63].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[64].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[65].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[66].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[67].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[68].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[69].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[70].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[71].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[72].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[73].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[74].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[75].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[76].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[77].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[78].Attributes.Add("class", "textmode");
                gv.Rows[i].Cells[79].Attributes.Add("class", "textmode");







                row.Cells[0].Style.Add("text-align", "center");
                row.Cells[1].Style.Add("text-align", "left");
                row.Cells[2].Style.Add("text-align", "left");
                row.Cells[3].Style.Add("text-align", "left");
                row.Cells[4].Style.Add("text-align", "left");
                row.Cells[5].Style.Add("text-align", "left");
                row.Cells[6].Style.Add("text-align", "left");
                row.Cells[7].Style.Add("text-align", "right");
                row.Cells[8].Style.Add("text-align", "right");
                row.Cells[9].Style.Add("text-align", "right");
                row.Cells[21].Style.Add("text-align", "center");
                row.Cells[22].Style.Add("text-align", "center");
                row.Cells[27].Style.Add("text-align", "center");
                row.Cells[28].Style.Add("text-align", "center");
                row.Cells[29].Style.Add("text-align", "center");
                row.Cells[30].Style.Add("text-align", "center");
                row.Cells[31].Style.Add("text-align", "center");
                row.Cells[32].Style.Add("text-align", "center");
                row.Cells[33].Style.Add("text-align", "center");
                row.Cells[34].Style.Add("text-align", "center");
                row.Cells[35].Style.Add("text-align", "center");

                row.Cells[36].Style.Add("text-align", "center");
                row.Cells[38].Style.Add("text-align", "left");
                row.Cells[39].Style.Add("text-align", "center");


                //if (gv.Rows[i].Cells[0].Text.Substring(0, 1) == "0")
                //{
                //    gv.Rows[i].Cells[0].Text = "'" + gv.Rows[i].Cells[0].Text;
                //}
                //if (gv.Rows[i].Cells[1].Text.Substring(0, 1) == "0")
                //{
                //    gv.Rows[i].Cells[1].Text = "'" + gv.Rows[i].Cells[1].Text;
                //}
                //if (gv.Rows[i].Cells[2].Text.Substring(0, 2) == "00")
                //{
                //    gv.Rows[i].Cells[2].Text = "'" + gv.Rows[i].Cells[2].Text;
                //}
                //if (gv.Rows[i].Cells[3].Text.Substring(0, 1) == "0")
                //{
                //    gv.Rows[i].Cells[3].Text = "'" + gv.Rows[i].Cells[3].Text;
                //}
                //if (gv.Rows[i].Cells[4].Text.Substring(0, 1) == "0")
                //{
                //    gv.Rows[i].Cells[4].Text = "'" + gv.Rows[i].Cells[4].Text;
                //}
                //gv.Rows[i].Cells[8].Font.Bold = true;
                //gv.Rows[i].Cells[8].Font.Size = 10;

            }
            //*************************************************************************

            //gv.Controls[0].Controls.AddAt(0, HeaderGridRow);
            gv.RenderControl(hw);

            //string style = @"<style> .text { } </style>";
            //string style = @"<style> .text { mso-number-format:\@; } </style>";
            //string style = @"<style> .textmode { } </style>";
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.ContentType = "application/text";
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

    }

    public void Open_Import_Excel_Download_XLSX(string Jobno_, string Branch_Common_)//download .XLSX
    {
        HttpResponse Response = HttpContext.Current.Response;
        BMW_Excel BMW = new BMW_Excel();
        DataTable dt = new DataTable();
        dt.Rows.Add();

        BMW.Jobno = Jobno_;
        BMW.Branch_Code = Branch_Common_;

        DataSet dss = BMW.RetrieveAll_IMPORT_EXCELDOWNLOAD_EXCEL();
        dt = dss.Tables[0];


        DateTime time = DateTime.Now;
        string Filename = "JobNo-" + Jobno_ + "-IMPORT_INVOICE_ITEM";

        using (var workbook = new XLWorkbook())
        {
            var worksheet = workbook.Worksheets.Add(dt, Filename);

            worksheet.Table(0).Theme = XLTableTheme.None;

            worksheet.Cell("A1").Style.Fill.BackgroundColor = XLColor.Yellow;
            worksheet.Cell("B1").Style.Fill.BackgroundColor = XLColor.Yellow;
            worksheet.Cell("C1").Style.Fill.BackgroundColor = XLColor.Yellow;
            worksheet.Cell("D1").Style.Fill.BackgroundColor = XLColor.Orange;
            worksheet.Cell("E1").Style.Fill.BackgroundColor = XLColor.Orange;
            worksheet.Cell("F1").Style.Fill.BackgroundColor = XLColor.Yellow;
            worksheet.Cell("G1").Style.Fill.BackgroundColor = XLColor.Yellow;
            worksheet.Cell("H1").Style.Fill.BackgroundColor = XLColor.Orange;
            worksheet.Cell("I1").Style.Fill.BackgroundColor = XLColor.Yellow;
            worksheet.Cell("L1").Style.Fill.BackgroundColor = XLColor.Orange;
            worksheet.Cell("O1").Style.Fill.BackgroundColor = XLColor.Orange;
            worksheet.Cell("R1").Style.Fill.BackgroundColor = XLColor.Orange;
            worksheet.Cell("S1").Style.Fill.BackgroundColor = XLColor.Yellow;
            worksheet.Cell("T1").Style.Fill.BackgroundColor = XLColor.Yellow;
            worksheet.Cell("U1").Style.Fill.BackgroundColor = XLColor.Yellow;
            worksheet.Cell("V1").Style.Fill.BackgroundColor = XLColor.Yellow;
            worksheet.Cell("W1").Style.Fill.BackgroundColor = XLColor.Yellow;
            worksheet.Cell("Z1").Style.Fill.BackgroundColor = XLColor.Yellow;
            worksheet.Cell("AA1").Style.Fill.BackgroundColor = XLColor.Orange;
            worksheet.Cell("AF1").Style.Fill.BackgroundColor = XLColor.Yellow;
            worksheet.Cell("AG1").Style.Fill.BackgroundColor = XLColor.Yellow;
            worksheet.Cell("AH1").Style.Fill.BackgroundColor = XLColor.Yellow;
            worksheet.Cell("AI1").Style.Fill.BackgroundColor = XLColor.Orange;
            worksheet.Cell("AJ1").Style.Fill.BackgroundColor = XLColor.Orange;
            worksheet.Cell("AK1").Style.Fill.BackgroundColor = XLColor.Orange;
            worksheet.Cell("AP1").Style.Fill.BackgroundColor = XLColor.Yellow;
            worksheet.Cell("AR1").Style.Fill.BackgroundColor = XLColor.Yellow;
            
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


    public DataSet RetrieveAll_IMPORT_EXCELDOWNLOAD_EXCEL()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[5];

            param[0] = new SqlParameter("@JOBNO", Jobno);
            param[1] = new SqlParameter("@Branch_Code", Branch_Code);

            param[2] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[2].Direction = ParameterDirection.Output;

            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_EXCEL_INVOICE_DOWNLOAD_REPORT", param);
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


    public DataSet RetrieveAll_IMPORT_Monthwise_Rpt()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@JOBNO", Jobno);
            param[1] = new SqlParameter("@Importer_Name", Importer_Name);
            param[2] = new SqlParameter("@Based_Date", Based_Date);
            param[3] = new SqlParameter("@fromdate", fromdate);
            param[4] = new SqlParameter("@todate", todate);
            param[7] = new SqlParameter("@flag", flag);

            param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_SANCO_BMW_MONTHWISE_REPORT", param);
            //result = Convert.ToInt32(param[2].Value.ToString());

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

    //------------------------------------------------------------------DIANA-----------------------------------------------------------------------------------//

    public DataSet RetrieveAll_IMPORT_DUTYWORKSHEET_ALL_EXCEL()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[5];

            param[0] = new SqlParameter("@JOBNO", Jobno);
            param[1] = new SqlParameter("@Branch_Code", Branch_Code);

            param[2] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[2].Direction = ParameterDirection.Output;

            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_DUTY_WORKSHEET_EXCEL_REPORT_All", param);

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public void Open_Import_DUTY_WORKSHEET_ALL_XLs(string Jobno_, string Branch_Common_)
    {
        ThemeClass th = new ThemeClass();
        HttpResponse Response = HttpContext.Current.Response;
        BMW_Excel BMW = new BMW_Excel();
        DataTable dt = new DataTable();
        BMW.Jobno = Jobno_;
        BMW.Branch_Code = Branch_Common_;
        DataSet dss = BMW.RetrieveAll_IMPORT_DUTYWORKSHEET_ALL_EXCEL();
        DateTime time = DateTime.Now;
        string s = time.ToString("yyyyMMdd");
        string strrptNametime = string.Empty;
        string Filename = "";

        using (XLWorkbook wb = new XLWorkbook())
        {
            foreach (DataTable table in dss.Tables)
            {
                // Set Filename based on the table name
                if (table.TableName == "Table")
                {
                    Filename = "JobNo_" + Jobno_ + "_" + s;

                }
                else if (table.TableName == "Table1")
                {
                    Filename = "License_Details" + s;
                }
                else
                {
                    Filename = "SW_Info_Type" + s;
                }

                strrptNametime = "JobNo_" + Jobno_ + "_" + s;
                IXLWorksheet worksheet = wb.AddWorksheet(Filename);
                worksheet.Name = Filename;
                worksheet.Cell(1, 1).InsertTable(table);
                worksheet.Row(1).Style.Font.Bold = true;
                worksheet.Row(1).Style.Font.FontColor = XLColor.Black;
                worksheet.Style.Border.SetTopBorder(XLBorderStyleValues.None);
                worksheet.Style.Border.SetLeftBorder(XLBorderStyleValues.None);
                worksheet.Style.Border.SetRightBorder(XLBorderStyleValues.None);
                worksheet.Style.Border.SetBottomBorder(XLBorderStyleValues.None);

                worksheet.Columns().AdjustToContents();
                worksheet.Tables.FirstOrDefault().ShowAutoFilter = false;
            }
            wb.Worksheet(1).Range("A1:AT1").Style.Fill.BackgroundColor = XLColor.Gray;
            wb.Worksheet(2).Range("A1:R1").Style.Fill.BackgroundColor = XLColor.Gray;
            wb.Worksheet(3).Range("A1:L1").Style.Fill.BackgroundColor = XLColor.Gray;
            // Send the response with the Excel file as an attachment
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=" + strrptNametime + ".xlsx");

            using (MemoryStream MyMemoryStream = new MemoryStream())
            {
                wb.SaveAs(MyMemoryStream);
                MyMemoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }

            // Save the file to the server
            string filePath = th.Server.MapPath("~/Submission/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + HttpContext.Current.Session["currentbranch"].ToString() + "/" + HttpContext.Current.Session["currentuser"].ToString() + "/" + strrptNametime + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx");
            wb.SaveAs(filePath);

            // Trigger download in the browser for the saved file
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + strrptNametime + ".xlsx");
            Response.TransmitFile(filePath);
            Response.End();
        }
    }
}