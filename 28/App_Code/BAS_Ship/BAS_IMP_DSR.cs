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

public class BAS_IMP_DSR
{
    private string _Jobno;
    private string _Imp_name;
    private string _Mode;
    private string _Branch_Code;
    private string _Flag;

    public string Jobno { get { return _Jobno; } set { _Jobno = value; } }
    public string Imp_name { get { return _Imp_name; } set { _Imp_name = value; } }
    public string Mode { get { return _Mode; } set { _Mode = value; } }
    public string Branch_Code { get { return _Branch_Code; } set { _Branch_Code = value; } }
    public string Flag { get { return _Flag; } set { _Flag = value; } }


    private string _from_date;
    private string _todate;
    public string from_date { get { return _from_date; } set { _from_date = value; } }
    public string todate { get { return _todate; } set { _todate = value; } }

    private string _Br_slno;
    public string Br_slno { get { return _Br_slno; } set { _Br_slno = value; } }

    DataSet ds = new DataSet();
    public DataSet BAS_IMP_DAILY_STATUS_RPT()
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
            if (todate != string.Empty && todate != null)
            {
                arr2 = todate.Split('/');
                todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@Jobno", Jobno);
            param[1] = new SqlParameter("@Imp_Name", Imp_name);
            param[2] = new SqlParameter("@Tr_mode", Mode);
            param[3] = new SqlParameter("@from_date", from_date);
            param[4] = new SqlParameter("@to_date", todate);

            param[5] = new SqlParameter("@Branch_Code", Branch_Code);
            param[6] = new SqlParameter("@Flag", Flag);

            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "BAS_IMP_DAILY_STATUS_RPT", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public void Open_Import_DSR_XLs(string Imp_name_, string Jobno_, string Mode_, string Fromdate_, string Todate_, string Branch_Common_, string Month_)
    {

        if (Fromdate_ != string.Empty || Todate_ != string.Empty)
        {
            from_date = Fromdate_;
            todate = Todate_;
        }
        else
        {
            if (Month_ != string.Empty)
            {
                string[] arr_Month = new string[] { };
                arr_Month = Month_.Split('-');
                from_date = arr_Month[0];
                todate = arr_Month[1];
            }
            else
            {
                from_date = Fromdate_;
                todate = Todate_;
            }
        }

        HttpResponse Response = HttpContext.Current.Response;

        Imp_name = Imp_name_;
        Jobno = Jobno_;
        Mode = Mode_;
        Branch_Code = Branch_Common_;
        Flag = "DSR_Search_Data";

        DataTable dt;
        DataSet dss = BAS_IMP_DAILY_STATUS_RPT();
        //dt = dss.Tables[0];


        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss
        string Filename = "";

        Filename = "IMPORT_DAILY_STATUS_RPT";
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
                    gv.DataSource = dss.Tables[0];
                    gv.DataBind();

                    GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                    TableCell HeaderCell = new TableCell();

                    HeaderCell.Text = Imp_name_ + " REPORT AIR IMPORTS AS ON " +time.ToString();
                    HeaderCell.ColumnSpan = 17;
                    HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#F87217");
                    HeaderCell.Font.Bold = true;
                    HeaderCell.Font.Size = 14;
                    HeaderCell.Style.Add("text-align", "center");
                    HeaderGridRow.Cells.Add(HeaderCell);

                    gv.Controls[0].Controls.AddAt(0, HeaderGridRow);
                    gv.RenderControl(hw);



                    if (Imp_name_ == "TURBO ENERGY PRIVATE LIMITED," || Imp_name_ == "EMERSON PROCESS MANAGEMENT CHENNAI PRIVATE LIMITED")
                    {
                        if (dss.Tables[1].Rows.Count > 0)
                        {

                            GridView gv_2 = new GridView();
                            gv_2.AllowPaging = false;
                            gv_2.DataSource = dss.Tables[1];
                            gv_2.DataBind();

                            GridViewRow HeaderGridRow_2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                            TableCell HeaderCell_2 = new TableCell();

                            HeaderCell_2.Text = "Regulator  -  AIR IMPORTS STATUS";
                            HeaderCell_2.ColumnSpan = 17;
                            HeaderCell_2.BackColor = System.Drawing.ColorTranslator.FromHtml("#F87217");
                            HeaderCell_2.Font.Bold = true;
                            HeaderCell_2.Font.Size = 14;
                            HeaderCell_2.Style.Add("text-align", "center");
                            HeaderGridRow_2.Cells.Add(HeaderCell_2);

                            gv_2.Controls[0].Controls.AddAt(0, HeaderGridRow_2);
                            gv_2.RenderControl(hw);
                        }
                    }


                    string style = @"<style> .textmode { } </style>";
                    Response.Write(style);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
            

    }


    public void Open_Import_LICENSE_RPT_PARTYWISE_XLs(string Imp_name_, string Br_slno_, string Jobno_, string Mode_, string Branch_Common_, string _SchemeCode)
    {

        HttpResponse Response = HttpContext.Current.Response;
        eroyalmaster erm = new eroyalmaster();
        DataTable dt = new DataTable();
        dt.Rows.Add();

        erm.LICENSE_NO = Jobno_;
        erm.IMP_EXP_NAME = Imp_name_;
        erm.IMP_EXP_BRSLNO = Br_slno_;
        erm.PORT_OF_LICENSE = Mode_;
        erm.SCHEME_CODE = _SchemeCode;
        erm.EWorking_Period = Branch_Common_;
        erm.Ename = "SELECT_LICENSE_PARTYWISE";
        DataSet dss = erm.RetrieveAll_IMPORT_LICENSE_DEBIT_AMT_REPORT_PARTYWISE();
        dt = dss.Tables[0];

        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss
        string Filename = "";

        Filename = "IMPORT_LICENSE_SUMMARY_RPT";
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

            HeaderCell.Text = Imp_name_ + " IMPORT-LICENSE SUMMARY REPORT" + "----" + "Dt:" + time.ToString();
            HeaderCell.ColumnSpan = 14;
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

                row.Cells[0].Width = 130;
                row.Cells[1].Width = 110;
                row.Cells[2].Width = 90;
                row.Cells[3].Width = 100;
                row.Cells[4].Width = 150;
                row.Cells[5].Width = 100;
                row.Cells[6].Width = 100;
                row.Cells[7].Width = 100;
                row.Cells[8].Width = 110;
                row.Cells[9].Width = 110;

                //if (i == 0)
                //{
                //    row.Cells[0].BorderWidth = 1;
                //}

                //row.Cells[0].Style.Add("NumberFormat ", "text");
                //row.Cells[i].Attributes.Add("style", "textmode");

                row.Attributes.Add("class", "textmode");

                row.Cells[0].Style.Add("text-align", "left");
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


    DataSet ds1 = new DataSet();
    public DataSet Select_Month()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[1] = new SqlParameter("@StartDate", from_date);
            param[2] = new SqlParameter("@EndDate", todate);
            param[3] = new SqlParameter("@Flag", Flag);
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds1 = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "FINANCIAL_YEAR_MONTH_SEPERATION", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds1;
    }


    public void Open_Import_SIMS_XLs(string stlno, string regndate, string frmdate, string todate, string Branch_Common_, string jobno)
    {

        HttpResponse Response = HttpContext.Current.Response;
        eroyalmaster erm = new eroyalmaster();
        DataTable dt = new DataTable();
        dt.Rows.Add();

        erm.STLNO = stlno;
        erm.REGNDATE = regndate;
        erm.FRMDATE = frmdate;
        erm.TODATE = todate;
        erm.JOBNO = jobno;
        erm.EWorking_Period = Branch_Common_;
        erm.Ename = "SELECT_SIMS_RPT";
        DataSet dss = erm.Retrive_Import_Sims();
        dt = dss.Tables[0];

        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss
        string Filename = "";

        Filename = "IMPORT_SIMS_RPT";
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

            HeaderCell.Text = stlno + " IMPORT-SIMS REPORT" + "----" + "Dt:" + time.ToString();
            HeaderCell.ColumnSpan = 9;
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

                row.Cells[0].Width = 130;
                row.Cells[1].Width = 110;
                row.Cells[2].Width = 90;
                row.Cells[3].Width = 100;
                row.Cells[4].Width = 100;
                row.Cells[5].Width = 150;
                row.Cells[6].Width = 100;
                row.Cells[7].Width = 100;
                row.Cells[8].Width = 110;
                //row.Cells[9].Width = 100;


                //if (i == 0)
                //{
                //    row.Cells[0].BorderWidth = 1;
                //}

                //row.Cells[0].Style.Add("NumberFormat ", "text");
                //row.Cells[i].Attributes.Add("style", "textmode");

                row.Attributes.Add("class", "textmode");

                row.Cells[0].Style.Add("text-align", "left");
                row.Cells[1].Style.Add("text-align", "center");
                row.Cells[2].Style.Add("text-align", "center");
                row.Cells[3].Style.Add("text-align", "center");
                row.Cells[4].Style.Add("text-align", "center");
                row.Cells[5].Style.Add("text-align", "center");
                row.Cells[6].Style.Add("text-align", "center");
                row.Cells[7].Style.Add("text-align", "center");
                row.Cells[8].Style.Add("text-align", "center");
                //row.Cells[9].Style.Add("text-align", "center");


                //if (gv.Rows[i].Cells[4].Text.Substring(0, 1) == "0")
                //{
                //    gv.Rows[i].Cells[4].Text = "'" + gv.Rows[i].Cells[4].Text;
                //}
                //gv.Rows[i].Cells[8].Font.Bold = true;
                //gv.Rows[i].Cells[8].Font.Size = 10;

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