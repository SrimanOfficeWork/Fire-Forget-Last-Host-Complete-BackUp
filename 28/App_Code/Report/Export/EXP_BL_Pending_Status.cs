using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.IO;


using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

public class EXP_BL_Pending_Status
{
    public int result = 0, UPDATE_ID = 0;
    DataSet ds = new DataSet();
    string Report_cat;
    string T_date, F_date,j_no;

    private string _IMP_EXP;
    private string _Branch;

    private string _Exp_name;
    private string _Filed_Type;
    private string _jobno;
    private string _from_date;
    private string _to_date;
    private string _Tr_mode;
    private string _Excel;
    private string _Orderby;

    
    public string Branch { get { return _Branch; } set { _Branch = value; } }
    public string IMP_EXP { get { return _IMP_EXP; } set { _IMP_EXP = value; } }


    public string Exp_name { get { return _Exp_name; } set { _Exp_name = value; } }
    public string Filed_Type { get { return _Filed_Type; } set { _Filed_Type = value; } }
    public string jobno { get { return _jobno; } set { _jobno = value; } }
    public string from_date { get { return _from_date; } set { _from_date = value; } }
    public string to_date { get { return _to_date; } set { _to_date = value; } }
    public string Tr_mode { get { return _Tr_mode; } set { _Tr_mode = value; } }
    public string Excel { get { return _Excel; } set { _Excel = value; } }
    public string Orderby { get { return _Orderby; } set { _Orderby = value; } }
    
    
    public DataSet Job_Filed_Status()
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
            if (to_date != string.Empty && to_date != null)
            {
                arr2 = to_date.Split('/');
                to_date = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[15];

            param[1] = new SqlParameter("@imp_name", Exp_name);
            param[2] = new SqlParameter("@jobno", jobno);
            param[3] = new SqlParameter("@from_date", from_date);
            param[4] = new SqlParameter("@to_date", to_date);
            param[5] = new SqlParameter("@Tr_mode", Tr_mode);
            param[6] = new SqlParameter("@Branch", Branch);
            param[7] = new SqlParameter("@Excel", Excel);
            param[8] = new SqlParameter("@Orderby", Orderby);
            
            param[9] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[9].Direction = ParameterDirection.Output;
            param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[10].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXP_BL_PENDING_JOBS", param);
            result = Convert.ToInt32(param[9].Value.ToString());

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }

        return ds;

    }

    public void Open_BLP_XLs_Report(string EXP_name_, string Jobno_, string Fromdate_, string Todate_, string Tr_mode_, string Branch_, string Type_, string Excel_jobno_, string Orderby_)
    {
        HttpResponse Response = HttpContext.Current.Response;

        Exp_name = EXP_name_;
        F_date = Fromdate_.Trim();
        T_date = Todate_.Trim();
        j_no = Jobno_.Trim();

        jobno = j_no;
        from_date = F_date == " " ? string.Empty : F_date;
        to_date = T_date == "  " ? string.Empty : T_date;
        Tr_mode = Tr_mode_;
        Branch = Branch_;
        Excel = Excel_jobno_;
        Orderby = Orderby_;


        DataSet dss = Job_Filed_Status();
        DataTable dt = dss.Tables[0];
        if (Type_ == "excel")
        {

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Export_Pending_Jobs.xls");
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

                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }

        }

    }
     

    public void Open_BLP_XLs_Mail(string EXP_name_, string Jobno_, string Fromdate_, string Todate_, string Tr_mode_, string Branch_, string Type_,string Excel_jobno_,string Orderby_) 
    {
        string Grid_Excel = HttpContext.Current.Server.MapPath("~/Submission/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + HttpContext.Current.Session["currentbranch"].ToString() + "/" + HttpContext.Current.Session["currentuser"].ToString() + "/" + "Grid_Excel" + "/");

        if (Directory.Exists(Grid_Excel) == false)
        {
            Directory.CreateDirectory(Grid_Excel);
        }

        HttpResponse Response = HttpContext.Current.Response;

        Exp_name = EXP_name_;
        F_date = Fromdate_.Trim();
        T_date = Todate_.Trim();
        j_no = Jobno_.Trim();

        jobno = j_no;
        from_date = F_date == " " ? string.Empty : F_date;
        to_date = T_date == "  " ? string.Empty : T_date;
        Tr_mode = Tr_mode_;
        Branch = Branch_;
        Excel= Excel_jobno_;
        Orderby = Orderby_;


        DataSet dss = Job_Filed_Status();
        DataTable dt = dss.Tables[0];
        if (Type_ == "excel")
        {
            Response.Clear();
            Response.Buffer = true;
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

                string str ="Export_BL_Pending_Jobs.xls";
                HttpContext.Current.Session.Remove(Grid_Excel);
                if (File.Exists(Grid_Excel + str))
                {
                    DirectoryInfo dir = new DirectoryInfo(Grid_Excel);
                    foreach (FileInfo fi in dir.GetFiles())
                    {
                        fi.Delete();
                    }
                    str = "Export_BL_Pending_Jobs.xls";

                    StreamWriter myWriter = new StreamWriter((Grid_Excel + "\\" + str + ""), true, System.Text.Encoding.Unicode);
                    myWriter.Write(sw.ToString());
                    myWriter.Flush();
                    myWriter.Close();

                    HttpContext.Current.Session["BL_Pending_Jobs"] = Grid_Excel + str;
                }
                else
                {
                    StreamWriter myWriter = new StreamWriter((Grid_Excel + "\\" + str + ""), true, System.Text.Encoding.Unicode);
                    myWriter.Write(sw.ToString());
                    myWriter.Flush();
                    myWriter.Close();

                    HttpContext.Current.Session["BL_Pending_Jobs"] = Grid_Excel + str;
                }

            }

        }

    }

}