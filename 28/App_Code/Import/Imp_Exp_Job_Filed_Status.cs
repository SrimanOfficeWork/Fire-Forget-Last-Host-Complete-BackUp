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

public class Imp_Exp_Job_Filed_Status
{
    public int result = 0, UPDATE_ID = 0;
    DataSet ds = new DataSet();
    string Report_cat;
    string T_date,F_date;
    
    private string _IMP_EXP;
    private string _Branch;

    private string _Imp_name;
    private string  _Filed_Type;
    private string _jobno;
    private string _from_date;
    private string _to_date;
    private string _Tr_mode;

    public string Branch { get { return _Branch; } set { _Branch = value; } }
    public string IMP_EXP { get { return _IMP_EXP; } set { _IMP_EXP = value; } }


    public string Imp_name { get { return _Imp_name; } set { _Imp_name = value; } }
    public string Filed_Type { get { return _Filed_Type; } set { _Filed_Type = value; } }
    public string jobno { get { return _jobno; } set { _jobno = value; } }
    public string from_date { get { return _from_date; } set { _from_date = value; } }
    public string to_date { get { return _to_date; } set { _to_date = value; } }
    public string Tr_mode { get { return _Tr_mode; } set { _Tr_mode = value; } }



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

            SqlParameter[] param = new SqlParameter[10];

            param[1] = new SqlParameter("@imp_name", Imp_name);
            param[2] = new SqlParameter("@Filed_Type", Filed_Type);
            param[3] = new SqlParameter("@jobno", jobno);
            param[4] = new SqlParameter("@from_date", from_date);
            param[5] = new SqlParameter("@to_date", to_date);
            param[6] = new SqlParameter("@Tr_mode", Tr_mode);
            param[7] = new SqlParameter("@Branch", Branch);

            param[8] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            if (IMP_EXP == "Import")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMP_JOB_FILED_STATUS", param);
            }
            else if (IMP_EXP == "Export")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXP_JOB_FILED_STATUS", param);
            }
            result = Convert.ToInt32(param[8].Value.ToString());

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }

        return ds;

    }

    public void Open_JFS_XLs_Report(string IMP_EXP_, string IMP_EXP_name_, string Jobno_, string Fromdate_, string Todate_, string Tr_mode_, string Branch_, string JobCat_, string Type_)
    {
        HttpResponse Response = HttpContext.Current.Response;

          IMP_EXP = IMP_EXP_;
          Imp_name = IMP_EXP_name_;

          F_date = Fromdate_.Trim();
          T_date = Todate_.Trim();

          jobno = Jobno_;
          from_date = Fromdate_ == " " ? string.Empty : Fromdate_;
          to_date = T_date == "  " ? string.Empty : T_date; 
          Tr_mode = Tr_mode_;
          Branch = Branch_;
          Filed_Type = JobCat_;

          if (JobCat_ == "P")
          {
              Report_cat = "Pending_Jobs"; 
          }
          else if (JobCat_ == "F")
          {
              Report_cat = "Filed_Jobs";
          }
          if (IMP_EXP == "Import")
          {
              if (JobCat_ == "BE")
              {
                  Report_cat = "BE_Filed_Jobs";
              }
          }
          else
          {
              if (JobCat_ == "SB")
              {
                  Report_cat = "SB_Filed_Jobs";
              }
          }


         DataSet dss= Job_Filed_Status();
         DataTable dt = dss.Tables[0];
        if (Type_ == "excel")
        {

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + IMP_EXP +'_'+ Report_cat + ".xls");
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

    public void Open_JFS_XLs_Mail(string IMP_EXP_, string IMP_EXP_name_, string Jobno_, string Fromdate_, string Todate_, string Tr_mode_, string Branch_, string JobCat_, string Type_)
    {

        string Grid_Excel = HttpContext.Current.Server.MapPath("~/Submission/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + HttpContext.Current.Session["currentbranch"].ToString() + "/" + HttpContext.Current.Session["currentuser"].ToString() + "/" + "Grid_Excel" + "/");

        if (Directory.Exists(Grid_Excel) == false)
        {
            Directory.CreateDirectory(Grid_Excel);
        }


        HttpResponse Response = HttpContext.Current.Response;

        IMP_EXP = IMP_EXP_;
        Imp_name = IMP_EXP_name_;

        F_date = Fromdate_.Trim();
        T_date = Todate_.Trim();

        jobno = Jobno_;
        from_date = Fromdate_ == " " ? string.Empty : Fromdate_;
        to_date = T_date == "  " ? string.Empty : T_date;
        Tr_mode = Tr_mode_;
        Branch = Branch_;
        Filed_Type = JobCat_;

        if (JobCat_ == "P")
        {
            Report_cat = "Pending_Jobs";
        }
        else if (JobCat_ == "F")
        {
            Report_cat = "Filed_Jobs";
        }
        if (IMP_EXP == "Import")
        {
            if (JobCat_ == "BE")
            {
                Report_cat = "BE_Filed_Jobs";
            }
        }
        else
        {
            if (JobCat_ == "SB")
            {
                Report_cat = "SB_Filed_Jobs";
            }
        }


        DataSet dss = Job_Filed_Status();
        DataTable dt = dss.Tables[0];
        if (Type_ == "excel")
        {
            /*
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + IMP_EXP + '_' + Report_cat + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            */
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



                string str =  IMP_EXP+"_"+ "JobStatus.xls";
                HttpContext.Current.Session.Remove(Grid_Excel);
                if (File.Exists(Grid_Excel + str))
                {
                    DirectoryInfo dir = new DirectoryInfo(Grid_Excel);
                    foreach (FileInfo fi in dir.GetFiles())
                    {
                        fi.Delete();
                    }
                    str = IMP_EXP + "_" + "JobStatus.xls";

                    StreamWriter myWriter = new StreamWriter((Grid_Excel + "\\" + str + ""), true, System.Text.Encoding.Unicode);
                    myWriter.Write(sw.ToString());
                    myWriter.Flush();
                    myWriter.Close();

                    HttpContext.Current.Session["IMP_EXP_JobStauts"] = Grid_Excel + str;
                }
                else
                {
                    StreamWriter myWriter = new StreamWriter((Grid_Excel + "\\" + str + ""), true, System.Text.Encoding.Unicode);
                    myWriter.Write(sw.ToString());
                    myWriter.Flush();
                    myWriter.Close();

                    HttpContext.Current.Session["IMP_EXP_JobStauts"] = Grid_Excel + str;
                }
               
            }

        }

    } 


    

}