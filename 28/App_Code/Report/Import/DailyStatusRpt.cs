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

/// <summary>
/// Summary description for DailyStatusRpt
/// </summary>
public class DailyStatusRpt
{

    SqlDataAdapter da;
    SqlDataReader dr;
    DataSet ds = new DataSet();
    SqlCommand cmd;
    DataTable dt = new DataTable();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    public int result = 0;

    private string _ClientName;
    private string _jobno;
    private string _jobdate;
    private string _fromdate;
    private string _Job_type;
    private string _Tr_mode;   
    private string _location;
    private string _Imp_name;
    private string _Sup_name;
    private string _invoiceno;
    private string _invoicedate;
    private string _todate;
    private string _Fromdate;
    private string _Branch;
    private string _companyId;
    private string _Ename;

       #region Public_DSR

     public string ClientName
    {
        get { return _ClientName; }
        set { _ClientName = value; }
    }
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
    //public string Fromdate
    //{
    //    get { return _Fromdate; }
    //    set { _Fromdate = value; }
    //}
    public string Imp_name
    {
        get { return _Imp_name; }
        set { _Imp_name = value; }
    }
    public string Job_type
    {
        get { return _Job_type; }
        set { _Job_type = value; }
    }
    public string Tr_mode
    {
        get { return _Tr_mode; }
        set { _Tr_mode = value; }
    }
    public string Location
    {
        get { return _location; }
        set { _location = value; }
    }
    public string Sup_name
    {
        get { return _Sup_name; }
        set { _Sup_name = value; }
    }
    public string Invoiceno
    {
        get { return _invoiceno; }
        set { _invoiceno = value; }
    }
    public string InvoiceDate
    {
        get { return _invoicedate; }
        set { _invoicedate = value; }
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
    public string companyId
    {
        get { return _companyId; }
        set { _companyId = value; }
    }
    public string Ename
    {
        get { return _Ename; }
        set { _Ename = value; }
    }

    #endregion DSR




    public DataSet DS_Report()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            ClientName = ClientName == null ? string.Empty : ClientName;
            Job_type = Job_type == null ? string.Empty : Job_type;
            Tr_mode = Tr_mode == null ? string.Empty : Tr_mode;

            Fromdate = Fromdate == null ? string.Empty : Fromdate;
            To_date = To_date == null ? string.Empty : To_date;
            Branch = Branch == null ? string.Empty : Branch;
            companyId = companyId == null ? string.Empty : companyId;
            


            param[0] = new SqlParameter("@ClientName", ClientName);
            param[1] = new SqlParameter("@JobType", Job_type);
            param[2] = new SqlParameter("@Transport_Mode", Tr_mode = Tr_mode == "All" ? string.Empty : Tr_mode);
            param[3] = new SqlParameter("@fromdate", Fromdate = Fromdate == string.Empty ? string.Empty : Fromdate);
            param[4] = new SqlParameter("@todate", To_date = To_date == string.Empty ? string.Empty : To_date);
            param[5] = new SqlParameter("@Branch", Branch = Branch == "All" ? string.Empty : Branch);
            param[6] = new SqlParameter("@CompanyID", companyId);
            param[7] = new SqlParameter("@name", Ename);
            param[8] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_DAILY_STATUS_REPORT", param);

            
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }


        return ds;
    }


    public DataTable DS_Report_Stmt()
    {

        try
        {
            Fromdate = Fromdate == null ? string.Empty : Fromdate;
            To_date = To_date == null ? string.Empty : To_date;
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            //if (Fromdate != string.Empty && Fromdate != null)
            //{
            //    arr = Fromdate.Split('/');
            //    Fromdate = arr[1] + '/' + arr[0] + '/' + arr[2];
            //}
            //if (To_date != string.Empty && To_date != null)
            //{
            //    arr2 = To_date.Split('/');
            //    To_date = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            //}
            
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@imp_name", ClientName=ClientName=="All"?string.Empty:ClientName);
            param[1] = new SqlParameter("@JobType", Job_type);
            param[2] = new SqlParameter("@Tr_mode", Tr_mode = Tr_mode == "All" ? string.Empty : Tr_mode);
           // param[3] = new SqlParameter("@from_date",Fromdate= Fromdate = Fromdate == string.Empty ? string.Empty : Fromdate);
            //param[4] = new SqlParameter("@to_date", To_date=To_date = To_date == string.Empty ? string.Empty : To_date);
            param[3]=new SqlParameter("@from_date",string.IsNullOrEmpty(Fromdate)?(object)DBNull.Value:Convert.ToDateTime(Fromdate));
            param[4] = new SqlParameter("@to_date", string.IsNullOrEmpty(To_date) ? (object)DBNull.Value : Convert.ToDateTime(To_date));
            param[5] = new SqlParameter("@Branch", Branch = Branch == "All" ? string.Empty : Branch);
            param[6] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_DAILY_STATUS_REPORT_BIND_ALL", param);


        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }

        return ds.Tables[0];
    }

    public void Open_Retail_XLs_Report(string Fromdate_, string ClientName_, string Tr_mode_, string Branch_, string Job_type_, string To_date_, string p_Type)
    {
        string ClientNm,P_clientName;
        HttpResponse Response = HttpContext.Current.Response;
        Fromdate = Fromdate_;
        ClientName = ClientName_;
        Job_type = Job_type_;
        Tr_mode = Tr_mode_;
        To_date = To_date_ == " " ? string.Empty : To_date_;
        Branch = Branch_ == " " ? string.Empty : Branch_;

      
        ClientNm = ClientName;

        if (ClientNm.Contains(" "))
        {
            P_clientName = ClientNm.Replace(" ", "_");
        }
        else
        {
            P_clientName = ClientNm;
        }
  

        DataView dv = new DataView(DS_Report_Stmt());
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

        }

        if (p_Type == "Pdf")
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
                        gv.HeaderRow.Style.Add("font-size", "10px");
                        gv.HeaderRow.Style.Add("text-align", "center");
                        gv.HeaderRow.Style.Add("width", "100px");

                        gv.HeaderStyle.BackColor = System.Drawing.Color.RoyalBlue;
                        gv.HeaderStyle.ForeColor = System.Drawing.Color.White;

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
                        Response.AddHeader("content-disposition", "attachment;filename=" + P_clientName + ".pdf");
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.Write(pdfDoc);
                        Response.End();

                    }
                }
            }

        }
      
    }



    public void Open_Retail_XLs_Mail(string Fromdate_, string ClientName_, string Tr_mode_, string Branch_, string Job_type_, string To_date_, string p_Type)
    {
        string Grid_Excel = HttpContext.Current.Server.MapPath("~/Submission/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + HttpContext.Current.Session["currentbranch"].ToString() + "/" + HttpContext.Current.Session["currentuser"].ToString() + "/" + "Grid_Excel" + "/");

        if (Directory.Exists(Grid_Excel) == false)
        {
            Directory.CreateDirectory(Grid_Excel);
        }

        string ClientNm, P_clientName;
        HttpResponse Response = HttpContext.Current.Response;
        Fromdate = Fromdate_;
        ClientName = ClientName_;
        Job_type = Job_type_;
        Tr_mode = Tr_mode_;
        To_date = To_date_ == " " ? string.Empty : To_date_;
        Branch = Branch_ == " " ? string.Empty : Branch_;
        ClientNm = ClientName;

        if (ClientNm.Contains(" "))
        {
            P_clientName = ClientNm.Replace(" ", "_");
        }
        else
        {
            P_clientName = ClientNm;
        }


        DataView dv = new DataView(DS_Report_Stmt());
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
                string str ="DSR.xls";
                HttpContext.Current.Session.Remove(Grid_Excel);
                if (File.Exists(Grid_Excel + str))
                {
                    DirectoryInfo dir = new DirectoryInfo(Grid_Excel);
                    foreach (FileInfo fi in dir.GetFiles())
                    {
                        fi.Delete();
                    }
                    str = "DSR.xls";

                    StreamWriter myWriter = new StreamWriter((Grid_Excel + "\\" + str + ""), true, System.Text.Encoding.Unicode);
                    myWriter.Write(sw.ToString());
                    myWriter.Flush();
                    myWriter.Close();

                    HttpContext.Current.Session["DSR"] = Grid_Excel + str;
                }
                else
                {
                    StreamWriter myWriter = new StreamWriter((Grid_Excel + "\\" + str + ""), true, System.Text.Encoding.Unicode);
                    myWriter.Write(sw.ToString());
                    myWriter.Flush();
                    myWriter.Close();

                    HttpContext.Current.Session["DSR"] = Grid_Excel + str;
                }
              
            }

        }

    }
}