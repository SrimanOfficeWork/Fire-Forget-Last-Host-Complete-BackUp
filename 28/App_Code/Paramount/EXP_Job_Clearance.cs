using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;


public class EXP_Job_Clearance
{

    private string _Jobno;
    private string _Branch;
    private string _Flag;

    private string _User_id;
    private string _Working_period;
    private string _Branch_Common;
    public String Xml_D;

    private string _From_date;
    private string _To_date;
    
    public string Jobno { get { return _Jobno; } set { _Jobno = value; } }
    public string Branch { get { return _Branch; } set { _Branch = value; } }
    public string Flag { get { return _Flag; } set { _Flag = value; } }
    public string User_id { get { return _User_id; } set { _User_id = value; } }
    public string Working_period { get { return _Working_period; } set { _Working_period = value; } }
    public string Branch_Common { get { return _Branch_Common; } set { _Branch_Common = value; } }

    public string From_date { get { return _From_date; } set { _From_date = value; } }
    public string To_date { get { return _To_date; } set { _To_date = value; } }

    DataSet ds = new DataSet();
    public DataSet EXP_Job_Clearance_select()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@Jobno", Jobno);
            param[1] = new SqlParameter("@Branch", Branch);
            param[2] = new SqlParameter("@Flag", Flag);
            param[3] = new SqlParameter("@User_id", User_id);
            param[4] = new SqlParameter("@Working_period", Working_period);
            param[5] = new SqlParameter("@xmlString", Xml_D);
            param[6] = new SqlParameter("@Branch_Common", Branch_Common);
            
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXP_JOB_CLEARANCE_INS_UPD_SELECT", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }
    DataSet dss = new DataSet();
    public DataSet Select_Month()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@StartDate", From_date);
            param[2] = new SqlParameter("@EndDate", To_date);
            param[3] = new SqlParameter("@Flag", Flag);
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "FINANCIAL_YEAR_MONTH_SEPERATION", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }
    public DataSet EXP_Job_Clearance_SEARCH()
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (From_date != string.Empty && From_date != null)
            {
                arr = From_date.Split('/');
                From_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (To_date != string.Empty && To_date != null)
            {
                arr2 = To_date.Split('/');
                To_date = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[10];

            param[1] = new SqlParameter("@jobno", Jobno);
            if (Jobno != string.Empty)
            {
                From_date = "";
                To_date = "";
                param[2] = new SqlParameter("@from_date", From_date);
                param[3] = new SqlParameter("@to_date", To_date);
            }
            else
            {
                param[2] = new SqlParameter("@from_date", From_date);
                param[3] = new SqlParameter("@to_date", To_date);
            }

            param[4] = new SqlParameter("@Branch", Branch);
            param[5] = new SqlParameter("@Flag", Flag);

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXP_JOB_CLEARANCE_SEARCH", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public void Open_IMP_Job_CLearance_XLs_Pdf(string Jobno_, string Branch_, string Type_)
    {
        HttpResponse Response = HttpContext.Current.Response;
        Jobno = Jobno_;
        Branch_Common = Branch_;
        Flag = "Select_XL_PDF";

        DataSet ds_pf = new DataSet();
        ds_pf = EXP_Job_Clearance_select();

        string Report_cat = "ExportJobClearance" + Jobno_;
        
        if (Type_ == "excel")
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
                gv.DataSource = ds_pf.Tables[0];
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
            if (ds_pf.Tables[0].Rows.Count > 0)
            {
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                using (StringWriter sw = new StringWriter())
                {
                    using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                    {
                        GridView gv = new GridView();
                        gv.AllowPaging = false;
                        gv.DataSource = ds_pf.Tables[0]; 
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
                            row.Cells[1].Style.Add("text-align", "left");
                            row.Cells[2].Style.Add("text-align", "left");
                            row.Cells[3].Style.Add("text-align", "left");
                            row.Cells[4].Style.Add("text-align", "left");

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