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
using System.Net;
using BussinessObject;


/// <summary>
/// Summary description for GST_Summary_Report
/// </summary>
public class GST_Summary_Report
{
    Billing_UserBO Bll_UsrBO = new Billing_UserBO();
    DataSet ds = new DataSet();
    DateTime d = DateTime.Today;

    public string _Imp_name, _todate, _Fromdate, _Branch;

    public string Imp_name
    {
        get { return _Imp_name; }
        set { _Imp_name = value; }
    }
    public string To_date
    {
        get { return _todate; }
        set { _todate = value; }
    }
    public string Fromdate
    {
        get { return _Fromdate; }
        set { _Fromdate = value; }
    }
    public string Branch
    {
        get { return _Branch; }
        set { _Branch = value; }
    }

    public DataSet RetrieveAll_GST_SummaryReport_Details(Billing_UserBO objBll_UsrBO)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@Client_name", objBll_UsrBO.Imp_Name);
            param[1] = new SqlParameter("@Flag", objBll_UsrBO.Flag);
            param[2] = new SqlParameter("@from_date",Connection.DATE_FORMAT( objBll_UsrBO.from_date == "" ? "01/01/1900" :  objBll_UsrBO.from_date));
            param[3] = new SqlParameter("@to_date", Connection.DATE_FORMAT(objBll_UsrBO.todate == "" ? d.ToShortDateString() : objBll_UsrBO.todate));
            param[4] = new SqlParameter("@Branch", objBll_UsrBO.BranchCode);

            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "GST_BILL_IMPORT_SUMMARY_REPORT", param);
            string err = param[5].Value.ToString();

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }


    public void Open_Retail_XLs_Report(string Imp_name_, string fromdate_, string Todate_, string Branch_Common_)
    {
       Billing_UserBO objUserBO = new Billing_UserBO();
        HttpResponse Response = HttpContext.Current.Response;
        objUserBO.Imp_Name = Imp_name_;
        objUserBO.from_date = fromdate_;
        objUserBO.todate = Todate_;
        objUserBO.BranchCode = Branch_Common_;
        objUserBO.Flag = "Get_IMPORT_GST_Summary_Report";
        //To_date = To_date_ == " " ? string.Empty : To_date_;
        //Branch = Branch_ == " " ? string.Empty : Branch_;

        //ClientNm = ClientName;

        //if (ClientNm.Contains(" "))
        //{
        //    P_clientName = ClientNm.Replace(" ", "_");
        //}
        //else
        //{
        //    P_clientName = ClientNm;
        //}

        DataSet dss = RetrieveAll_GST_SummaryReport_Details(objUserBO);
        DataTable dtt = dss.Tables[0];
        DataView dv = new DataView(dtt);
        DataTable dt = dv.ToTable();
        //if (p_Type == "excel")
        //{

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + "GST_REPORT" + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
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

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }

        //}

        //if (p_Type == "Pdf")
        //{
        //    if (dt.Rows.Count > 0)
        //    {
        //        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //        using (StringWriter sw = new StringWriter())
        //        {
        //            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
        //            {
        //                GridView gv = new GridView();
        //                gv.AllowPaging = false;
        //                gv.DataSource = dt;
        //                gv.DataBind();

        //                //-----------------------------------------
        //                gv.HeaderRow.Style.Add("font-weight", "bold");
        //                gv.HeaderRow.Style.Add("font-size", "10px");
        //                gv.HeaderRow.Style.Add("text-align", "center");
        //                gv.HeaderRow.Style.Add("width", "100px");

        //                gv.HeaderStyle.BackColor = System.Drawing.Color.RoyalBlue;
        //                gv.HeaderStyle.ForeColor = System.Drawing.Color.White;

        //                for (int i = 0; i < gv.Rows.Count; i++)
        //                {
        //                    GridViewRow row = gv.Rows[i];
        //                    row.Attributes.Add("class", "textmode");

        //                    row.Cells[0].Style.Add("text-align", "left");
        //                    row.Cells[1].Style.Add("text-align", "center");
        //                    row.Cells[2].Style.Add("text-align", "center");
        //                    row.Cells[3].Style.Add("text-align", "right");
        //                    row.Cells[4].Style.Add("text-align", "right");
        //                    row.Cells[5].Style.Add("text-align", "right");
        //                    row.Cells[6].Style.Add("text-align", "right");

        //                }
        //                //------------------------------------------


        //                gv.RenderControl(hw);
        //                StringReader sr = new StringReader(sw.ToString());
        //                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
        //                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        //                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //                pdfDoc.Open();
        //                htmlparser.Parse(sr);
        //                pdfDoc.Close();

        //                Response.ContentType = "application/pdf";
        //                Response.AddHeader("content-disposition", "attachment;filename=" + P_clientName + ".pdf");
        //                Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //                Response.Write(pdfDoc);
        //                Response.End();

        //            }
        //        }
        //    }

        //}
    }
}