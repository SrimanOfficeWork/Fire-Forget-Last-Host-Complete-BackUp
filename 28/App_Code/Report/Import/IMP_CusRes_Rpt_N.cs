using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Web.UI;
using System.Web.UI.WebControls;


public class IMP_CusRes_Rpt_N
{
    private string _jobno;
    private string _fromdate;
    private string _todate;
    private string _branch;

    DataSet ds;
    public int result = 0;

    public string jobno
    {
        get { return _jobno; }
        set { _jobno = value; }
    }
    public string fromdate
    {
        get { return _fromdate; }
        set { _fromdate = value; }
    }
    public string todate
    {
        get { return _todate; }
        set { _todate = value; }
    }
    public string branch
    {
        get { return _branch; }
        set { _branch = value; }
    }

 

    public DataSet  Cusres_data()
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };
            if (fromdate != string.Empty && fromdate != null)
            {
                arr = fromdate.Split('/');
                fromdate = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (todate != string.Empty && todate != null)
            {
                arr2 = todate.Split('/');
                todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@JOBNO", jobno=jobno == string.Empty ? "All" : jobno);
            param[1] = new SqlParameter("@Fromdate",fromdate= fromdate == string.Empty ? string.Empty : fromdate);
            param[2] = new SqlParameter("@Todate",todate= todate == string.Empty ? string.Empty : todate);
            param[3] = new SqlParameter("@Working_Period", branch == string.Empty ? string.Empty : branch);

            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_CUSRES_REPORT_N", param);
            result = Convert.ToInt32(param[9].Value.ToString());

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }





    public void Open_Cusres_N_Rpt(string Jobdate_, string JobNo_, string To_date_, string Branch_, string Type_)
    {
        HttpResponse Response = HttpContext.Current.Response;
        jobno = JobNo_;
        fromdate = Jobdate_;
        todate = To_date_;
        branch = Branch_;
        ds = Cusres_data();

        DataTable dt = ds.Tables[0]; 
        if (Type_ == "excel")
        {

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=CUSRES.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                GridView gv = new GridView();


                gv.HeaderStyle.BackColor = System.Drawing.Color.RoyalBlue;
                gv.HeaderStyle.ForeColor = System.Drawing.Color.White;

                //gv.HeaderRow.Style.Add("width", "100px");
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
                        gv.HeaderRow.Style.Add("font-size", "10PX");
                        gv.HeaderRow.Style.Add("text-align", "center");
                        //gv.HeaderRow.Style.Add("width", "800px");
                        gv.HeaderStyle.BackColor = System.Drawing.Color.RoyalBlue;
                        gv.HeaderStyle.ForeColor = System.Drawing.Color.White;

                        gv.HeaderStyle.Width = 1000;

                        var gg = new PdfPTable(24) { WidthPercentage = 600 };
                        var calWidth = new[] { 6f, 100f, 30f, 40f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f };
                        gg.SetWidths(calWidth);

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

                            //row.Cells[2].Width = 200;



                        }
                        //------------------------------------------


                        gv.RenderControl(hw);
                        StringReader sr = new StringReader(sw.ToString());
                        Document pdfDoc = new Document(PageSize.A2, 30f, 30f, 30f, 30f);
                        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                        pdfDoc.Open();
                        htmlparser.Parse(sr);
                        pdfDoc.Close();

                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-disposition", "attachment;filename=CUSRES.pdf");
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.Write(pdfDoc);
                        Response.End();

                    }
                }
            }

        }

    }

}