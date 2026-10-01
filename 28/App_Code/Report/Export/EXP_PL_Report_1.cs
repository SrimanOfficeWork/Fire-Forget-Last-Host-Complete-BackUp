using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
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


public class EXP_PL_Report_1
{
    DataSet ds = new DataSet();

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

    private string _From_date;
    private string _BRANCH_COMMON;
    private string _PL_or_PL1;

    public int result = 0;

    //--------------

    public string From_date
    {
        get { return _From_date; }
        set { _From_date = value; }
    }

    public string Jobdate
    {
        get { return _jobdate; }
        set { _jobdate = value; }
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

    public string Country
    {
        get { return _country; }
        set { _country = value; }
    }

    public string JobNo
    {
        get { return _jobno; }
        set { _jobno = value; }
    }
    public string BRANCH_COMMON
    {
        get { return _BRANCH_COMMON; }
        set { _BRANCH_COMMON = value; }
    }

    public string PL_or_PL1
    {
        get { return _PL_or_PL1; }
        set { _PL_or_PL1 = value; }
    }
    


	public DataSet EXP_Pl_Rpt1_Data()
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

            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@from_date", From_date == null ? string.Empty : From_date);
            param[1] = new SqlParameter("@to_date", To_date == null ? string.Empty : To_date);
            param[2] = new SqlParameter("@Imp_name", Imp_name == null ? string.Empty : Imp_name);

            param[3] = new SqlParameter("@Branch", Branch == null ? string.Empty : Branch);
            param[4] = new SqlParameter("@Job_Type", BRANCH_COMMON == null ? string.Empty : BRANCH_COMMON);

            param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;

            if (PL_or_PL1 == "EXP_PL")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXP_PL_Report", param);
            }
            else if (PL_or_PL1 == "EX_PL1")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXP_PL_Report_1", param);
            }

            result = Convert.ToInt32(param[5].Value.ToString());
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public void PL_1_XLs_PDF(string Jobdate_, string To_date_, string Imp_name_, string Branch_, string Type_, string Job_Type_ ,string PL_)
    {
        HttpResponse Response = HttpContext.Current.Response;
        From_date = Jobdate_;
        To_date = To_date_ == " " ? string.Empty : To_date_;
        Imp_name = Imp_name_;
        Branch = Branch_;
        BRANCH_COMMON = Job_Type_;
        PL_or_PL1 = PL_;

        DataSet dt = EXP_Pl_Rpt1_Data();

        if (Type_ == "excel")
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + PL_ + "_Report.xls");
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
            if (dt.Tables[0].Rows.Count > 0)
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
                        Response.AddHeader("content-disposition", "attachment;filename=EXP_PL_Report.pdf");
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.Write(pdfDoc);
                        Response.End();

                    }
                }
            }

        }
    }


    public void PL_1_XLs_PDF_Excel_Attach(string Jobdate_, string To_date_, string Imp_name_, string Branch_, string Type_, string Job_Type_, string PL_)
    {

               string  Grid_Excel =HttpContext.Current.Server.MapPath("~/Submission/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + HttpContext.Current. Session["currentbranch"].ToString() + "/" +  HttpContext.Current.Session["currentuser"].ToString() + "/"+"Grid_Excel"+"/");

               if (Directory.Exists(Grid_Excel) == false)
               {
                   Directory.CreateDirectory(Grid_Excel);
               }


        HttpResponse Response = HttpContext.Current.Response;
        From_date = Jobdate_;
        To_date = To_date_ == " " ? string.Empty : To_date_;
        Imp_name = Imp_name_;
        Branch = Branch_;
        BRANCH_COMMON = Job_Type_;
        PL_or_PL1 = PL_;

        DataSet dt = EXP_Pl_Rpt1_Data();

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

            string str = PL_ + ".xls";

            HttpContext.Current.Session.Remove(Grid_Excel);
            if (File.Exists(Grid_Excel + str))
            {
                DirectoryInfo dir = new DirectoryInfo(Grid_Excel);
                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }
                str = PL_ + ".xls";

                StreamWriter myWriter = new StreamWriter((Grid_Excel + "\\" + str + ""), true, System.Text.Encoding.Unicode);
                myWriter.Write(sw.ToString());
                myWriter.Flush();
                myWriter.Close();
                
                HttpContext.Current.Session["EXP_Grid_Excel"] = Grid_Excel + str;
            }
            else
            {
                StreamWriter myWriter = new StreamWriter((Grid_Excel + "\\" + str + ""), true, System.Text.Encoding.Unicode);
                myWriter.Write(sw.ToString());
                myWriter.Flush();
                myWriter.Close();

                HttpContext.Current.Session["EXP_Grid_Excel"] = Grid_Excel + str;
            }
            

            }

        }
        
    }
	
}