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

/// <summary>
/// Summary description for TALLY_Excel
/// </summary>
public class TALLY_Excel
{
    private string _Jobno;
    private string _Imp_name;
    private string _Exp_name;
    private string _Branch_Code;
    private string _Flag;
    private string _Fromdate;
    private string _Todate;

    public string Jobno { get { return _Jobno; } set { _Jobno = value; } }
    public string Imp_name { get { return _Imp_name; } set { _Imp_name = value; } }
    public string Exp_name { get { return _Exp_name; } set { _Exp_name = value; } }
    public string Branch_Code { get { return _Branch_Code; } set { _Branch_Code = value; } }
    public string Flag { get { return _Flag; } set { _Flag = value; } }
    public string Fromdate { get { return _Fromdate; } set { _Fromdate = value; } }
    public string Todate { get { return _Todate; } set { _Todate = value; } }

    DataSet ds = new DataSet();
    public DataSet BAS_IMP_TALLY_EXCEL_REPORT()
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (Fromdate != string.Empty && Fromdate != null)
            {
                arr = Fromdate.Split('/');
                Fromdate = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (Todate != string.Empty && Todate != null)
            {
                arr2 = Todate.Split('/');
                Todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@Jobno", Jobno);
            param[1] = new SqlParameter("@Imp_Name", Imp_name);
            param[2] = new SqlParameter("@from_date", Fromdate);
            param[3] = new SqlParameter("@to_date", Todate);


            param[5] = new SqlParameter("@Branch_Common", Branch_Code);
            param[6] = new SqlParameter("@Flag", Flag);

            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMP_BILLING_TALLY_EXCEL_FORMAT", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }



    public void Open_Import_TALLY_EXCEL_XLs(string Imp_name_, string Jobno_, string Branch_Common_, string from_date, string todate)
    {

        HttpResponse Response = HttpContext.Current.Response;
        TALLY_Excel excel = new TALLY_Excel();
        DataTable dt = new DataTable();
        dt.Rows.Add();


        excel.Jobno = Jobno_;
        excel.Imp_name = "";
        excel.Branch_Code = Branch_Common_;
        excel.Fromdate = from_date;
        excel.Todate = todate;
        excel.Flag = "IMPORT_TALLY_EXCEL_BIND";
        DataSet dss = excel.BAS_IMP_TALLY_EXCEL_REPORT();
        dt = dss.Tables[0];

       

        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss
        string Filename = "";

        Filename = "IMPORT_TALLY_EXCEL_FORMAT";
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

            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell HeaderCell = new TableCell();

            HeaderCell.Text = Imp_name_ + " IMPORT_TALLY_EXCEL_FORMAT" + "----" + "Dt:" + time.ToString();
            HeaderCell.ColumnSpan = 10;
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
            gv.GridLines = 0;
            gv.Font.Size = 9;

            // *******************HEADER ROW SETTINGS----------------------------------
            //gv.HeaderRow.BackColor = System.Drawing.Color.LightGray;
            //gv.HeaderRow.Font.Size = 11;
            //gv.HeaderRow.Font.Underline = true;

            //gv.HeaderRow.BorderStyle = System.Web.UI.WebControls.BorderStyle.Outset;
            //gv.HeaderRow.BorderWidth = 1;
            //gv.HeaderRow.Font.Underline = true;

            //*************************************************************************


            //*********************DATA ROW SETTINGS***********************************
            for (int i = 0; i < gv.Rows.Count; i++)
            {
                GridViewRow row = gv.Rows[i];

                row.Cells[0].Width = 80;
                row.Cells[1].Width = 100;
                row.Cells[2].Width = 320;
                row.Cells[3].Width = 250;
                row.Cells[4].Width = 150;
                row.Cells[5].Width = 150;
                row.Cells[6].Width = 150;
                row.Cells[7].Width = 100;
                row.Cells[8].Width = 90;
                row.Cells[9].Width = 140;
                row.Cells[10].Width = 550;
                row.Cells[11].Width = 120;
                row.Cells[12].Width = 120;
                row.Cells[13].Width = 100;
                row.Cells[14].Width = 100;
                //row.Cells[14].Width = 100;


                //if (i == 0)
                //{
                //    row.Cells[0].BorderWidth = 1;
                //}

                //row.Cells[0].Style.Add("NumberFormat ", "text");
                //row.Cells[i].Attributes.Add("style", "textmode");

                row.Attributes.Add("class", "textmode");

                row.Cells[0].Style.Add("text-align", "center");
                row.Cells[1].Style.Add("text-align", "center");
                row.Cells[2].Style.Add("text-align", "left");
                row.Cells[3].Style.Add("text-align", "left");
                row.Cells[4].Style.Add("text-align", "left");
                row.Cells[5].Style.Add("text-align", "left");
                row.Cells[6].Style.Add("text-align", "left");
                row.Cells[7].Style.Add("text-align", "left");
                row.Cells[8].Style.Add("text-align", "right");
                row.Cells[9].Style.Add("text-align", "center");
                row.Cells[10].Style.Add("text-align", "left");
                row.Cells[11].Style.Add("text-align", "left");



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

            gv.Controls[0].Controls.AddAt(0, HeaderGridRow);
            gv.RenderControl(hw);

            //string style = @"<style> .text { } </style>";
            string style = @"<style> .text { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.ContentType = "application/text";
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }

    public DataSet BAS_EXP_TALLY_EXCEL_REPORT()
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (Fromdate != string.Empty && Fromdate != null)
            {
                arr = Fromdate.Split('/');
                Fromdate = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (Todate != string.Empty && Todate != null)
            {
                arr2 = Todate.Split('/');
                Todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@Jobno", Jobno);
            param[1] = new SqlParameter("@Exp_Name", Exp_name);
            param[2] = new SqlParameter("@from_date", Fromdate);
            param[3] = new SqlParameter("@to_date", Todate);


            param[5] = new SqlParameter("@Branch_Common", Branch_Code);
            param[6] = new SqlParameter("@Flag", Flag);

            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXP_BILLING_TALLY_EXCEL_FORMAT", param);//IMP_BILLING_TALLY_EXCEL_FORMAT

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }
    public void Open_Export_TALLY_EXCEL_XLs(string Exp_name_, string Jobno_, string Branch_Common_, string from_date, string todate)
    {

        HttpResponse Response = HttpContext.Current.Response;
        TALLY_Excel excel = new TALLY_Excel();
        DataTable dt = new DataTable();
        dt.Rows.Add();


        excel.Jobno = Jobno_;
        excel.Exp_name = "";
        excel.Branch_Code = Branch_Common_;
        excel.Fromdate = from_date;
        excel.Todate = todate;
        excel.Flag = "EXPORT_TALLY_EXCEL_BIND";
        DataSet dss = excel.BAS_EXP_TALLY_EXCEL_REPORT();
        dt = dss.Tables[0];



        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss
        string Filename = "";

        Filename = "EXPORT_TALLY_EXCEL_FORMAT";
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

            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell HeaderCell = new TableCell();

            HeaderCell.Text = Exp_name_ + " EXPORT_TALLY_EXCEL_FORMAT" + "----" + "Dt:" + time.ToString();
            HeaderCell.ColumnSpan = 10;
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
            gv.GridLines = 0;
            gv.Font.Size = 9;

            // *******************HEADER ROW SETTINGS----------------------------------
            //gv.HeaderRow.BackColor = System.Drawing.Color.LightGray;
            //gv.HeaderRow.Font.Size = 11;
            //gv.HeaderRow.Font.Underline = true;

            //gv.HeaderRow.BorderStyle = System.Web.UI.WebControls.BorderStyle.Outset;
            //gv.HeaderRow.BorderWidth = 1;
            //gv.HeaderRow.Font.Underline = true;

            //*************************************************************************


            //*********************DATA ROW SETTINGS***********************************
            for (int i = 0; i < gv.Rows.Count; i++)
            {
                GridViewRow row = gv.Rows[i];

                row.Cells[0].Width = 80;
                row.Cells[1].Width = 100;
                row.Cells[2].Width = 320;
                row.Cells[3].Width = 250;
                row.Cells[4].Width = 150;
                row.Cells[5].Width = 150;
                row.Cells[6].Width = 150;
                row.Cells[7].Width = 100;
                row.Cells[8].Width = 90;
                row.Cells[9].Width = 140;
                row.Cells[10].Width = 550;
                row.Cells[11].Width = 120;
                row.Cells[12].Width = 120;
                row.Cells[13].Width = 100;
                row.Cells[14].Width = 100;
                //row.Cells[14].Width = 100;


                //if (i == 0)
                //{
                //    row.Cells[0].BorderWidth = 1;
                //}

                //row.Cells[0].Style.Add("NumberFormat ", "text");
                //row.Cells[i].Attributes.Add("style", "textmode");

                row.Attributes.Add("class", "textmode");

                row.Cells[0].Style.Add("text-align", "center");
                row.Cells[1].Style.Add("text-align", "center");
                row.Cells[2].Style.Add("text-align", "left");
                row.Cells[3].Style.Add("text-align", "left");
                row.Cells[4].Style.Add("text-align", "left");
                row.Cells[5].Style.Add("text-align", "left");
                row.Cells[6].Style.Add("text-align", "left");
                row.Cells[7].Style.Add("text-align", "left");
                row.Cells[8].Style.Add("text-align", "right");
                row.Cells[9].Style.Add("text-align", "center");
                row.Cells[10].Style.Add("text-align", "left");
                row.Cells[11].Style.Add("text-align", "left");



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

            gv.Controls[0].Controls.AddAt(0, HeaderGridRow);
            gv.RenderControl(hw);

            //string style = @"<style> .text { } </style>";
            string style = @"<style> .text { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.ContentType = "application/text";
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }


}