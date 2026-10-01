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

public class Bond_SummaryRpt
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

    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();

    public void Open_Import_BD_BOND_SUMMARY_XLs(string BondNo_, string BondType_, string BondLocation_, string Branch_Common_,  string _ReportType, string _Jobno)
    {

        HttpResponse Response = HttpContext.Current.Response;
        eroyalmaster erm = new eroyalmaster();
        DataTable dt = new DataTable();
        dt.Rows.Add();

        erm.LICENSE_NO = BondNo_;
        erm.LICENSE_TYPE = BondType_ == null ? string.Empty : BondType_;
        erm.PORT_OF_LICENSE = BondLocation_ == null ? string.Empty : BondLocation_;
        //erm.PRODUCT_RITC = RitcNO_ == null ? string.Empty : RitcNO_;
        //erm.SCHEME_CODE = _SchemeCode == null ? string.Empty : _SchemeCode;
        erm.SCHEME_CODE = _ReportType == null ? string.Empty : _ReportType;
        erm.PARTNO = _Jobno == null ? string.Empty : _Jobno;

        erm.EWorking_Period = Connection.Get_Company_Type();
        //erm.Ename = "SELECT_BD_BOND_REPORT";

        if (_ReportType == "PD")
        {
            erm.Ename = "SELECT_PD_BOND_REPORT";
        }
        else if (_ReportType == "RE")
        {
            erm.Ename = "SELECT_RE_BOND_REPORT";
        }
        else if (_ReportType == "DE" || _ReportType == "NB")
        {
            erm.Ename = "SELECT_DEEC_BOND_REPORT";
        }
        else if (_ReportType == "EC")
        {
            erm.Ename = "SELECT_EPCG_BOND_REPORT";
        }
        else if (_ReportType == "WH")
        {
            erm.Ename = "SELECT_WAREHOUSE_BOND_REPORT";
        }
        else if (_ReportType == "WH")
        {
            erm.Ename = "SELECT_WAREHOUSE_BOND_REPORT";
        }
        else if (_ReportType == "EI")
        {
            erm.Ename = "SELECT_EI_IGCR_BOND_REPORT";
        }
        else if (_ReportType == "EU")
        {
            erm.Ename = "SELECT_EU_END_USE_BOND_REPORT";
        }
        else
        {

        }

        ds1 = erm.RetrieveAll_IMPORT_BOND_DETAILS_SummaryReport();

        //if (ds1.Tables[1].Rows.Count > 0)
        //{
        //    if (_ReportType == "PD")
        //    {
        //        ds1.Tables[0].Rows.Add("", "", "", "", "", "","", ds1.Tables[1].Rows[0]["ASSESSABLE_VALUE"].ToString(), ds1.Tables[1].Rows[0]["MERIT_BASIC_VALUE"].ToString());
        //    }
        //    else
        //    {
        //        ds1.Tables[0].Rows.Add("", "", "", "", "", "", ds1.Tables[1].Rows[0]["ASSESSABLE_VALUE"].ToString(), ds1.Tables[1].Rows[0]["MERIT_BASIC_VALUE"].ToString(), ds1.Tables[1].Rows[0]["SOCIAL_WELFARE"].ToString(), ds1.Tables[1].Rows[0]["RE_DUTYVALUE"].ToString());
        //    }
        //}

        dt = ds1.Tables[0];

        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss
        string Filename = "";

        Filename = _ReportType + "_" + "BOND_SUMMARY_RPT";
        string strrptNametime = Filename + "_" + s;

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=" + strrptNametime + ".xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";

        if (dt.Rows.Count > 0)
        {

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

                HeaderCell.Text = _ReportType + "-" + " BOND SUMMARY REPORT" + "----" + "Dt:" + time.ToString();
                HeaderCell.ColumnSpan = 13;
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

                    
                    row.Cells[0].Width = 50;
                    row.Cells[1].Width = 110;
                    row.Cells[2].Width = 110;
                    row.Cells[3].Width = 140;
                    row.Cells[4].Width = 70;
                    row.Cells[5].Width = 80;
                    row.Cells[6].Width = 130;

                    row.Cells[7].Width = 90;
                    if (_ReportType != "EI" && _ReportType != "EU")
                    {
                        row.Cells[8].Width = 120;
                        row.Cells[9].Width = 120;
                    }
                    if (_ReportType == "PD" || _ReportType == "RE")
                    {
                        row.Cells[10].Width = 120;
                    }
                    //row.Cells[11].Width = 70;


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

                    if (_ReportType == "PD" || _ReportType == "RE")
                    {
                        row.Cells[7].Style.Add("text-align", "right");
                        row.Cells[8].Style.Add("text-align", "right");
                    }

                    if (gv.Rows[i].Cells[0].Text.Substring(0, 1) == "0")
                    {
                        gv.Rows[i].Cells[0].Text = "'" + gv.Rows[i].Cells[0].Text;
                    }

                    if (_ReportType == "PD")
                    {
                        gv.Rows[i].Cells[8].Font.Bold = true;
                        gv.Rows[i].Cells[8].Font.Size = 11;

                        gv.Rows[i].Cells[10].Font.Bold = true;
                        gv.Rows[i].Cells[10].Font.Size = 11;
                    }
                    else //if (_ReportType == "RE")
                    {
                        if (_ReportType != "EI" && _ReportType != "EU")
                        {
                            gv.Rows[i].Cells[9].Font.Bold = true;
                            gv.Rows[i].Cells[9].Font.Size = 11;
                        }
                    }
                    // else
                    //{
                    //    gv.Rows[i].Cells[5].Font.Bold = true;
                    //    gv.Rows[i].Cells[5].Font.Size = 11;
                    //}
                    /*
                    if (i == gv.Rows.Count-1)
                    {
                        gv.Rows[i].Cells[6].Font.Bold = true;
                        gv.Rows[i].Cells[6].Font.Size = 11;

                        gv.Rows[i].Cells[7].Font.Bold = true;
                        gv.Rows[i].Cells[7].Font.Size = 11;

                        gv.Rows[i].Cells[8].Font.Bold = true;
                        gv.Rows[i].Cells[8].Font.Size = 11;
                    }
                    */
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
}