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
/// Summary description for Retail_St
/// </summary>
public class Retail_Stmts
{
    SqlDataAdapter da;
    SqlDataReader dr;
    DataSet ds = new DataSet();
    SqlCommand cmd;
    DataTable dt = new DataTable();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    public int result = 0;

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
    
    private string _Report_cat;
    private string _search_con;
    private string _todate;
    private string _Fromdate;
    private string _Branch;
    private string _Ename;

    #region LOGIN DETAILS
    public string LOGIN_ID;

    public string USERNAME;
    public string PWD;

    public string ISLOGIN;
    public string DATABASE_ID, SERVER_NAME, DATABASE_NAME, WORKING_PERIOD, SELECT_JOB, COMPANY_LICENSE;
    #endregion


    #region Retail_Attributes
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
    public string Report_cat
    {
        get { return _Report_cat; }
        set { _Report_cat = value; }
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
    public string Ename
    {
        get { return _Ename; }
        set { _Ename = value; }
    }

    #endregion Retail_Attributes

    private string _COMPANY_ID;
    private string _COMPANY_LICENSE;
    private string _CLIENT_NAME;
    private string _ADDRESS;
    private string _PHONE_NO;
    private string _CONTACT_PERSON;
    private string _MOBILE_NO;

    private string _startRowIndex;

    private string _maximumRows;
    private string _totalRows;


    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }

    public string COMPANY_ID { get { return _COMPANY_ID; } set { _COMPANY_ID = value; } }
    //public string COMPANY_LICENSE { get { return _COMPANY_LICENSE; } set { _COMPANY_LICENSE = value; } }
    public string CONTACT_PERSON { get { return _CONTACT_PERSON; } set { _CONTACT_PERSON = value; } }
    public string MOBILE_NO { get { return _MOBILE_NO; } set { _MOBILE_NO = value; } }

  

    public string CLIENT_NAME { get { return _CLIENT_NAME; } set { _CLIENT_NAME = value; } }
    public string ADDRESS { get { return _ADDRESS; } set { _ADDRESS = value; } }
    public string PHONE_NO { get { return _PHONE_NO; } set { _PHONE_NO = value; } }

    public DataTable Retail_Statement_Xls()
    {
        try
        {
            string xxx;
            
           

            string[] arr = new string[] { };
            string[] arr2 = new string[] { };
            if (Fromdate != string.Empty && Fromdate != null)
            {
                arr = Fromdate.Split('/');
                Fromdate = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (To_date != string.Empty && To_date != null)
            {
                arr2 = To_date.Split('/');
                To_date = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[10];


            param[0] = new SqlParameter("@JobType", Job_type);
            param[1] = new SqlParameter("@Transport_Mode", Tr_mode = Tr_mode == "All" ? string.Empty : Tr_mode);
            param[2] = new SqlParameter("@fromdate", Fromdate = Fromdate == string.Empty ? string.Empty : Fromdate);
            param[3] = new SqlParameter("@todate", To_date = To_date == string.Empty ? string.Empty : To_date);
            param[4] = new SqlParameter("@Branch", Branch = Branch == "All" ? string.Empty : Branch);

            param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;


            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["getpath_Retail"].ToString(), CommandType.StoredProcedure, "SP_RETAIL_SALES_STMTS", param);
            //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "sp_Retail_Sales_St_Newtest_Backup1_", param);
            result = Convert.ToInt32(param[5].Value.ToString());

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }

        return ds.Tables[0];
    }
    
	public  DataSet Retail_Statement()
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
            if (To_date != string.Empty && To_date != null)
            {
                arr2 = To_date.Split('/');
                To_date = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@JobType", Job_type);
            param[1] = new SqlParameter("@Transport_Mode",Tr_mode= Tr_mode=="All"? string.Empty:Tr_mode);
            param[2] = new SqlParameter("@fromdate", Fromdate=Fromdate == string.Empty ? string.Empty : Fromdate);
            param[3] = new SqlParameter("@todate",To_date= To_date == string.Empty ? string.Empty : To_date);
            param[4] = new SqlParameter("@Branch",Branch= Branch =="All"?string.Empty:Branch);
            
            param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["getpath_Retail"].ToString(), CommandType.StoredProcedure, "SP_RETAIL_SALES_STMTS", param);
            //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "sp_Retail_Sales_St_Newtest_Backup1_", param);

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }


        return ds;
	}

    public DataSet Retail_RetrieveAll_Database_Details()
    {

        try
        {


            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@DATABASE_ID", DATABASE_ID);

            param[1] = new SqlParameter("@COMPANY_LICENSE", COMPANY_LICENSE);

            param[2] = new SqlParameter("@SERVER_NAME", SERVER_NAME);

            param[3] = new SqlParameter("@DATABASE_NAME", DATABASE_NAME);
            param[4] = new SqlParameter("@LOGIN_NAME", USERNAME);
            param[5] = new SqlParameter("@PWD", PWD);
            param[6] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

            param[11] = new SqlParameter("@SELECT_JOB", SELECT_JOB);

            param[7] = new SqlParameter("@name", Ename);

            param[8] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            param[10] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;



            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_DATABASE_DETAILS_INSERT_UPDATE", param);

            if (Ename == "All_Retail_ClientName_With_CompanyLicense" || Ename == "Database_Check_Servername")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_DATABASE_DETAILS_INSERT_UPDATE", param);
                result = Convert.ToInt32(param[7].Value.ToString());
            }

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
            //string err = param[8].Value.ToString();

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }


    public DataSet RetrieveAll_Company_Details()
    {

        try
        {


            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@COMPANY_ID", COMPANY_ID);

            param[1] = new SqlParameter("@COMPANY_LICENSE", COMPANY_LICENSE);

            param[2] = new SqlParameter("@CLIENT_NAME", CLIENT_NAME);

            param[3] = new SqlParameter("@CONTACT_PERSON", CONTACT_PERSON);

            param[4] = new SqlParameter("@MOBILE_NO", MOBILE_NO);

            param[5] = new SqlParameter("@name", Ename);

            //param[6] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);


            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@startRowIndex", startRowIndex);

            param[10] = new SqlParameter("@maximumRows", maximumRows);

            param[11] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output;

          
          if (Ename == "All_Retail_ClientName_With_CompanyLicense" || Ename == "Retail_Select_BranchName")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_COMPANY_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[7].Value.ToString());
            }

   

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public void Open_Retail_XLs_Report(string Fromdate_, string Imp_name_, string Tr_mode_, string Branch_, string Job_type_, string To_date_, string p_Type)
    {
        string Re_Impname;
        HttpResponse Response = HttpContext.Current.Response;
        Fromdate = Fromdate_;
        Imp_name = Imp_name_;
        Job_type = Job_type_;
        Tr_mode = Tr_mode_;
        To_date = To_date_ == " " ? string.Empty : To_date_;
        Branch = Branch_;
        //Ename = "Search_TransportMode";

        string Impname = Imp_name;
        if (Impname.Contains(" "))
        {
             Re_Impname = Impname.Replace(" ", "_");
        }
        else
        {
             Re_Impname = Impname;
        }

        DataView dv = new DataView(Retail_Statement_Xls());
        DataTable dt = dv.ToTable();
        if (p_Type == "excel")
        {

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + Re_Impname + ".xls");
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
                        Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                        pdfDoc.Open();
                        htmlparser.Parse(sr);
                        pdfDoc.Close();

                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-disposition", "attachment;filename=" + Re_Impname + ".pdf");
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.Write(pdfDoc);
                        Response.End();

                    }
                }
            }

        }

        /*
         Response.ContentType = "application/pdf";
         Response.AddHeader("content-disposition", "attachment;filename=" + Report_cat + ".pdf");
         Response.Cache.SetCacheability(HttpCacheability.NoCache);
         StringWriter sw = new StringWriter();
         HtmlTextWriter hw = new HtmlTextWriter(sw);
         GridView gv = new GridView();
         gv.AllowPaging = false;
         gv.DataSource = dt;
         gv.DataBind();
         gv.RenderControl(hw);
         StringReader sr = new StringReader(sw.ToString());
         Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
         HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
         PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
         pdfDoc.Open();
         htmlparser.Parse(sr);
         pdfDoc.Close();
         Response.Write(pdfDoc);
         Response.End();  */

    }


}