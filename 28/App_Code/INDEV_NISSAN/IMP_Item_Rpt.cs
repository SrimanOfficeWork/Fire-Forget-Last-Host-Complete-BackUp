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
using BussinessObject;


public class IMP_Item_Rpt
{
    public int result = 0, UPDATE_ID = 0;
    ErrorLogs er = new ErrorLogs();

    private string _Jobno;
    private string _Branch_Type;
    private string _Flag;
    private string _From_date;
    private string _To_date;
    private string _Imp_Name;
    private string _Country_Orgin;
    private string _Basic_Notn;

    public string Jobno { get { return _Jobno; } set { _Jobno = value; } }
    public string Branch_Type { get { return _Branch_Type; } set { _Branch_Type = value; } }
    public string Flag { get { return _Flag; } set { _Flag = value; } }

    public string From_date { get { return _From_date; } set { _From_date = value; } }
    public string To_date { get { return _To_date; } set { _To_date = value; } }
    public string Imp_Name { get { return _Imp_Name; } set { _Imp_Name = value; } }
    public string Country_Orgin { get { return _Country_Orgin; } set { _Country_Orgin = value; } }
    public string Basic_Notn { get { return _Basic_Notn; } set { _Basic_Notn = value; } }

    DataSet ds = new DataSet();
    public DataSet IMP_Items()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@Jobno", Jobno);
            param[4] = new SqlParameter("@Branch", Branch_Type);
            param[3] = new SqlParameter("@Flag", Flag);

            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_NISSAN_IMP_ITEMS_CHECKLIST_RPT", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet IMP_Select()
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
            param[0] = new SqlParameter("@Jobno", Jobno);
            param[1] = new SqlParameter("@From_date", From_date);
            param[2] = new SqlParameter("@To_date", To_date);
            param[3] = new SqlParameter("@Flag", Flag);
            param[4] = new SqlParameter("@Branch", Connection.Get_Company_Type());
            param[5] = new SqlParameter("@Basic_Notn", Basic_Notn);
            param[6] = new SqlParameter("@Country_Orgin", Country_Orgin);
            param[7] = new SqlParameter("@Imp_Name", Imp_Name);


            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_NISSAN_IMP_SELECT", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }
    public DataSet IMPORT_JOB_SEARCH(Billing_UserBO objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.from_date != string.Empty && objUserBL.from_date != null)
            {
                arr = objUserBL.from_date.Split('/');
                objUserBL.from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.todate != string.Empty && objUserBL.todate != null)
            {
                arr2 = objUserBL.todate.Split('/');
                objUserBL.todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Imp_Name", objUserBL.Imp_Name);
            param[3] = new SqlParameter("@from_date", objUserBL.from_date);
            param[4] = new SqlParameter("@to_date", objUserBL.todate);
            param[5] = new SqlParameter("@Jobno", objUserBL.JOBNO);
            param[6] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[8] = new SqlParameter("@Flag", objUserBL.Flag);

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("INDEV_NISSAN_IMP_ITEMS_CHECKLIST_RPT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet IMP_Month_Wise_Select()
    {
        try
        {
           

            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Imp_Name", Imp_Name.TrimEnd(','));
            param[2] = new SqlParameter("@Jobno", Jobno);
            param[3] = new SqlParameter("@From_date", From_date);
            param[4] = new SqlParameter("@To_date", To_date);
            param[5] = new SqlParameter("@Branch",Branch_Type);
            param[6] = new SqlParameter("@Flag", Flag);

            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_NISSAN_IMP_MONTHLY_RPT", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public void Open_XL_Itemwise_Data(string Jobno_, string ddlImp_name_, string Fromdate_, string Todate_, string Month_)
    {
        Billing_UserBO objUserBL = new Billing_UserBO();
        HttpResponse Response = HttpContext.Current.Response;

        if (Fromdate_ != string.Empty || Todate_ != string.Empty)
        {
            objUserBL.from_date = Fromdate_;
            objUserBL.todate = Todate_;
        }
        else
        {
            if (Month_ != string.Empty)
            {
                string[] arr_Month = new string[] { };
                arr_Month = Month_.Split('-');
                objUserBL.from_date = arr_Month[0];
                objUserBL.todate = arr_Month[1];
            }
            else
            {
                objUserBL.from_date = Fromdate_;
                objUserBL.todate = Todate_;
            }
        }

        objUserBL.Imp_Name = ddlImp_name_;
        objUserBL.JOBNO = Jobno_;
        objUserBL.Flag = "Grid_Search";

        DataSet dss = IMPORT_JOB_SEARCH(objUserBL);
        DataTable dt = new DataTable();
        dt = dss.Tables[0];


        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss
        string Filename = "";

        Filename = "ITEM_WISE_REPORT_CHECKLIST";
        string strrptNametime = Filename + "_" + s;

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=" + strrptNametime + ".xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView gv = new GridView();
            gv.AllowPaging = false;
            gv.DataSource = dt;
            gv.DataBind();

            if (gv.Rows.Count > 0)
            {
                foreach (TableCell cell in gv.HeaderRow.Cells)
                {
                    cell.BackColor = gv.HeaderStyle.BackColor;
                }
                for (int i = 0; i < gv.HeaderRow.Cells.Count; i++)
                {
                    gv.HeaderRow.Cells[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#D8D8D8");
                }
                gv.RenderControl(hw);
            }
            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }

    public DataSet IMP_FTA_Select()
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
            param[1] = new SqlParameter("@Imp_Name", Imp_Name.TrimEnd(','));
            param[2] = new SqlParameter("@Country_Orgin", Country_Orgin);
            param[3] = new SqlParameter("@From_date", From_date);
            param[4] = new SqlParameter("@To_date", To_date);
            param[5] = new SqlParameter("@Branch", Branch_Type);
            param[6] = new SqlParameter("@Flag", Flag);
            param[7] = new SqlParameter("@Basic_Notn", Basic_Notn.TrimEnd(','));
            param[8] = new SqlParameter("@Jobno", Jobno);
            
            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_NISSAN_IMP_FTA", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }
    public DataSet IMP_EXP_Month(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@StartDate", objUserBL.from_date);
            param[1] = new SqlParameter("@EndDate", objUserBL.todate);
            param[2] = new SqlParameter("@Flag", objUserBL.Flag);
            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("BILL_IMP_EXP_MONTHS", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public void Open_Import_Item_XLs_Report(string Jobno_ , string Branch_)
    {
        DataTable dt;
        Jobno = Jobno_;
        Branch_Type = Branch_;
        DataSet dss =  IMP_Items();
        dt = dss.Tables[0];


        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss
        string Filename = "";

        Filename = "ITEM_WISE_REPORT_CHECKLIST";
        string strrptNametime = Filename + "_" + s;
        HttpResponse Response = HttpContext.Current.Response;

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + strrptNametime + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                GridView gv = new GridView();
                gv.AllowPaging = false;
                gv.DataSource = dt;
                gv.DataBind();

                if (gv.Rows.Count > 0)
                {
                    foreach (TableCell cell in gv.HeaderRow.Cells)
                    {
                        cell.BackColor = gv.HeaderStyle.BackColor;
                    }
                    for (int i = 0; i < gv.HeaderRow.Cells.Count; i++)
                    {
                        gv.HeaderRow.Cells[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#D8D8D8 ");
                    }

                    gv.RenderControl(hw);
                }

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
    }
    public void Load_IMP_Report_Data_Xls_Mail(string Jobno_, string Branch_)
    {

        string Grid_Excel = HttpContext.Current.Server.MapPath("~/Submission/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + HttpContext.Current.Session["currentbranch"].ToString() + "/" + HttpContext.Current.Session["currentuser"].ToString() + "/" + "Grid_Excel" + "/");

        if (Directory.Exists(Grid_Excel) == false)
        {
            Directory.CreateDirectory(Grid_Excel);
        }
        DataTable dt;
        Jobno = Jobno_;
        Branch_Type = Branch_;
        DataSet dss = IMP_Items();
        dt = dss.Tables[0];

        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss
        string Filename = "";

        Filename = "ITEM_WISE_REPORT_CHECKLIST";
        string strrptNametime = Filename + "_" + s;

        HttpResponse Response = HttpContext.Current.Response;
        Response.Clear();
        Response.Buffer = true;

            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                GridView gv = new GridView();
                gv.AllowPaging = false;
                gv.DataSource = dt;
                gv.DataBind();

                if (gv.Rows.Count > 0)
                {
                    foreach (TableCell cell in gv.HeaderRow.Cells)
                    {
                        cell.BackColor = gv.HeaderStyle.BackColor;
                    }
                    for (int i = 0; i < gv.HeaderRow.Cells.Count; i++)
                    {
                        gv.HeaderRow.Cells[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#D8D8D8 ");
                    }

                    gv.RenderControl(hw);
                }
                

                string str = Filename+".xls";
                HttpContext.Current.Session.Remove(Grid_Excel);
                if (File.Exists(Grid_Excel + str))
                {
                    DirectoryInfo dir = new DirectoryInfo(Grid_Excel);
                    foreach (FileInfo fi in dir.GetFiles())
                    {
                        fi.Delete();
                    }
                    str = Filename + ".xls";

                    StreamWriter myWriter = new StreamWriter((Grid_Excel + "\\" + str + ""), true, System.Text.Encoding.Unicode);
                    myWriter.Write(sw.ToString());
                    myWriter.Flush();
                    myWriter.Close();

                    HttpContext.Current.Session["IMP_NIS_ITEM_CHK_RPT"] = Grid_Excel + str;
                }
                else
                {
                    StreamWriter myWriter = new StreamWriter((Grid_Excel + "\\" + str + ""), true, System.Text.Encoding.Unicode);
                    myWriter.Write(sw.ToString());
                    myWriter.Flush();
                    myWriter.Close();

                    HttpContext.Current.Session["IMP_NIS_ITEM_CHK_RPT"] = Grid_Excel + str;
                }

            }
    }



    public void Load_IMP_Report_Data_Xls_Mail_New(string Jobno_, string ddlImp_name_, string Fromdate_, string Todate_, string Month_)
    {
        Billing_UserBO objUserBL = new Billing_UserBO();
        string Grid_Excel = HttpContext.Current.Server.MapPath("~/Submission/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + HttpContext.Current.Session["currentbranch"].ToString() + "/" + HttpContext.Current.Session["currentuser"].ToString() + "/" + "Grid_Excel" + "/");

        if (Directory.Exists(Grid_Excel) == false)
        {
            Directory.CreateDirectory(Grid_Excel);
        }

        if (Fromdate_ != string.Empty || Todate_ != string.Empty)
        {
            objUserBL.from_date = Fromdate_;
            objUserBL.todate = Todate_;
        }
        else
        {
            if (Month_ != string.Empty)
            {
                string[] arr_Month = new string[] { };
                arr_Month = Month_.Split('-');
                objUserBL.from_date = arr_Month[0];
                objUserBL.todate = arr_Month[1];
            }
            else
            {
                objUserBL.from_date = Fromdate_;
                objUserBL.todate = Todate_;
            }
        }

        objUserBL.Imp_Name = ddlImp_name_;
        objUserBL.JOBNO = Jobno_;
        objUserBL.Flag = "Grid_Search";

        DataSet dss = IMPORT_JOB_SEARCH(objUserBL);
        DataTable dt;
        dt = dss.Tables[0];

        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss
        string Filename = "";

        Filename = "ITEM_WISE_REPORT_CHECKLIST";
        string strrptNametime = Filename + "_" + s;

        HttpResponse Response = HttpContext.Current.Response;
        Response.Clear();
        Response.Buffer = true;

        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView gv = new GridView();
            gv.AllowPaging = false;
            gv.DataSource = dt;
            gv.DataBind();

            if (gv.Rows.Count > 0)
            {
                foreach (TableCell cell in gv.HeaderRow.Cells)
                {
                    cell.BackColor = gv.HeaderStyle.BackColor;
                }
                for (int i = 0; i < gv.HeaderRow.Cells.Count; i++)
                {
                    gv.HeaderRow.Cells[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#D8D8D8 ");
                }

                gv.RenderControl(hw);
            }


            string str = Filename + ".xls";
            HttpContext.Current.Session.Remove(Grid_Excel);
            if (File.Exists(Grid_Excel + str))
            {
                DirectoryInfo dir = new DirectoryInfo(Grid_Excel);
                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }
                str = Filename + ".xls";

                StreamWriter myWriter = new StreamWriter((Grid_Excel + "\\" + str + ""), true, System.Text.Encoding.Unicode);
                myWriter.Write(sw.ToString());
                myWriter.Flush();
                myWriter.Close();

                HttpContext.Current.Session["IMP_NIS_ITEM_CHK_RPT_New"] = Grid_Excel + str;
            }
            else
            {
                StreamWriter myWriter = new StreamWriter((Grid_Excel + "\\" + str + ""), true, System.Text.Encoding.Unicode);
                myWriter.Write(sw.ToString());
                myWriter.Flush();
                myWriter.Close();

                HttpContext.Current.Session["IMP_NIS_ITEM_CHK_RPT_New"] = Grid_Excel + str;
            }

        }
    }



    public void Open_IND_NIS_Month_XLs_Report(string Jobno_, string ddl_Imp_name_, string txtfromdate_, string txttodate_, string ddlmonth_, string Branch_)
    {
        /*
        if (txtfromdate_ != string.Empty || txttodate_ != string.Empty)
        {
            From_date = txtfromdate_;
            To_date = txttodate_;
        }
        else
        {
            if (ddlmonth_ != string.Empty)
            {
                string[] arr_Month = new string[] { };
                arr_Month = ddlmonth_.Split('-');
                From_date = arr_Month[0];
                To_date = arr_Month[1];
            }
            else
            {
                From_date = txtfromdate_;
                To_date = txttodate_;
            }
        }
        */
        if (txtfromdate_ != string.Empty || txttodate_ != string.Empty)
        {

            if (Jobno_ != string.Empty)
            {
                From_date = string.Empty;
                To_date = string.Empty;
            }
            else
            {
                From_date = txtfromdate_;
                To_date = txttodate_;
                Jobno_ = string.Empty;
            }
        }
        else
        {
            if (ddlmonth_!= string.Empty)
            {

                if (Jobno_ != string.Empty)
                {
                    From_date = string.Empty;
                    To_date = string.Empty;
                }
                else
                {
                    string[] arr_Month = new string[] { };
                    arr_Month = ddlmonth_.Split('-');

                    From_date = arr_Month[0];
                    To_date = arr_Month[1];
                    Jobno_ = string.Empty;
                }
            }
            else
            {
                if (Jobno_ != string.Empty)
                {
                    From_date = string.Empty;
                    To_date = string.Empty;
                }
                else
                {
                    From_date = txtfromdate_;
                    To_date = txttodate_;
                    Jobno_ = string.Empty;
                }
            }
        }
        DataTable dt;
        Imp_Name = ddl_Imp_name_;
        Jobno = Jobno_;
        Branch_Type = Branch_;

        DataSet dss = IMP_Month_Wise_Select();
        dt = dss.Tables[0];

        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss
        string Filename = "";

        Filename = "IMP_MONTHWISE_Rpt";
        string strrptNametime = Filename + "_" + s;
        HttpResponse Response = HttpContext.Current.Response;

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=" + strrptNametime + ".xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView gv = new GridView();
            gv.AllowPaging = false;
            gv.DataSource = dt;
            gv.DataBind();

            if (gv.Rows.Count > 0)
            {
                foreach (TableCell cell in gv.HeaderRow.Cells)
                {
                    cell.BackColor = gv.HeaderStyle.BackColor;
                }
                for (int i = 0; i < gv.HeaderRow.Cells.Count; i++)
                {
                    gv.HeaderRow.Cells[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#D8D8D8 ");
                }

                gv.RenderControl(hw);
            }

            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }
    public void Load_IND_NIS_Month_XLs_Report_Mail(string Jobno_, string ddl_Imp_name_, string txtfromdate_, string txttodate_, string ddlmonth_, string Branch_)
    {
        string Grid_Excel = HttpContext.Current.Server.MapPath("~/Submission/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + HttpContext.Current.Session["currentbranch"].ToString() + "/" + HttpContext.Current.Session["currentuser"].ToString() + "/" + "Grid_Excel" + "/");

        if (Directory.Exists(Grid_Excel) == false)
        {
            Directory.CreateDirectory(Grid_Excel);
        }

        if (txtfromdate_ != string.Empty || txttodate_ != string.Empty)
        {

            if (Jobno_ != string.Empty)
            {
                From_date = string.Empty;
                To_date = string.Empty;
            }
            else
            {
                From_date = txtfromdate_;
                To_date = txttodate_;
                Jobno_ = string.Empty;
            }
        }
        else
        {
            if (ddlmonth_ != string.Empty)
            {

                if (Jobno_ != string.Empty)
                {
                    From_date = string.Empty;
                    To_date = string.Empty;
                }
                else
                {
                    string[] arr_Month = new string[] { };
                    arr_Month = ddlmonth_.Split('-');

                    From_date = arr_Month[0];
                    To_date = arr_Month[1];
                    Jobno_ = string.Empty;
                }
            }
            else
            {
                if (Jobno_ != string.Empty)
                {
                    From_date = string.Empty;
                    To_date = string.Empty;
                }
                else
                {
                    From_date = txtfromdate_;
                    To_date = txttodate_;
                    Jobno_ = string.Empty;
                }
            }
        }

        DataTable dt;
        Imp_Name = ddl_Imp_name_;
        Jobno = Jobno_;
        Branch_Type = Branch_;
        DataSet dss = IMP_Month_Wise_Select();
        dt = dss.Tables[0];
        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss
        string Filename = "";

        Filename = "IMP_MONTHWISE_Rpt";
        string strrptNametime = Filename + "_" + s;

        HttpResponse Response = HttpContext.Current.Response;
        Response.Clear();
        Response.Buffer = true;

        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView gv = new GridView();
            gv.AllowPaging = false;
            gv.DataSource = dt;
            gv.DataBind();

            if (gv.Rows.Count > 0)
            {
                foreach (TableCell cell in gv.HeaderRow.Cells)
                {
                    cell.BackColor = gv.HeaderStyle.BackColor;
                }
                for (int i = 0; i < gv.HeaderRow.Cells.Count; i++)
                {
                    gv.HeaderRow.Cells[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#D8D8D8 ");
                }

                gv.RenderControl(hw);
            }


            string str = Filename + ".xls";
            HttpContext.Current.Session.Remove(Grid_Excel);
            if (File.Exists(Grid_Excel + str))
            {
                DirectoryInfo dir = new DirectoryInfo(Grid_Excel);
                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }
                str = Filename + ".xls";

                StreamWriter myWriter = new StreamWriter((Grid_Excel + "\\" + str + ""), true, System.Text.Encoding.Unicode);
                myWriter.Write(sw.ToString());
                myWriter.Flush();
                myWriter.Close();

                HttpContext.Current.Session["INDEV_NIS_MONTH_RPT"] = Grid_Excel + str;
            }
            else
            {
                StreamWriter myWriter = new StreamWriter((Grid_Excel + "\\" + str + ""), true, System.Text.Encoding.Unicode);
                myWriter.Write(sw.ToString());
                myWriter.Flush();
                myWriter.Close();

                HttpContext.Current.Session["INDEV_NIS_MONTH_RPT"] = Grid_Excel + str;
            }

        }
    }
    public void Open_IND_NIS_FTA_XLs_Report(string ddlorgin_, string ddl_Imp_name_, string txtfromdate_, string txttodate_, string ddlmonth_, string Branch_, string Basic_Notn_2_, string ddljobno_)
    {
        if (txtfromdate_ != string.Empty || txttodate_ != string.Empty)
        {
            From_date = txtfromdate_;
            To_date = txttodate_;
        }
        else
        {
            if (ddlmonth_ != string.Empty)
            {
                string[] arr_Month = new string[] { };
                arr_Month = ddlmonth_.Split('-');
                From_date = arr_Month[0];
                To_date = arr_Month[1];
            }
            else
            {
                From_date = txtfromdate_;
                To_date = txttodate_;
            }
        }
        
        
        DataTable dt;
        Imp_Name = ddl_Imp_name_;
        Country_Orgin = ddlorgin_;
        Branch_Type = Branch_;
        Basic_Notn = Basic_Notn_2_;
        Jobno = ddljobno_;

        DataSet dss = IMP_FTA_Select();
        dt = dss.Tables[0];

        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss
        string Filename = "";

        Filename = "IMP_FTA_Rpt";
        string strrptNametime = Filename + "_" + s;
        HttpResponse Response = HttpContext.Current.Response;

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=" + strrptNametime + ".xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView gv = new GridView();
            gv.AllowPaging = false;
            gv.DataSource = dt;
            gv.DataBind();

            if (gv.Rows.Count > 0)
            {
                foreach (TableCell cell in gv.HeaderRow.Cells)
                {
                    cell.BackColor = gv.HeaderStyle.BackColor;
                }
                for (int i = 0; i < gv.HeaderRow.Cells.Count; i++)
                {
                    gv.HeaderRow.Cells[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#D8D8D8 ");
                }

                gv.RenderControl(hw);
            }

            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }

    public void Load_IND_NIS_FTA_XLs_Report_Mail(string ddlorgin_, string ddl_Imp_name_, string txtfromdate_, string txttodate_, string ddlmonth_, string Branch_, string Basic_Notn_2_, string ddljobno_)
    {
        string Grid_Excel = HttpContext.Current.Server.MapPath("~/Submission/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + HttpContext.Current.Session["currentbranch"].ToString() + "/" + HttpContext.Current.Session["currentuser"].ToString() + "/" + "Grid_Excel" + "/");

        if (Directory.Exists(Grid_Excel) == false)
        {
            Directory.CreateDirectory(Grid_Excel);
        }
        if (txtfromdate_ != string.Empty || txttodate_ != string.Empty)
        {
            From_date = txtfromdate_;
            To_date = txttodate_;
        }
        else
        {
            if (ddlmonth_ != string.Empty)
            {
                string[] arr_Month = new string[] { };
                arr_Month = ddlmonth_.Split('-');
                From_date = arr_Month[0];
                To_date = arr_Month[1];
            }
            else
            {
                From_date = txtfromdate_;
                To_date = txttodate_;
            }
        }


        DataTable dt;
        Imp_Name = ddl_Imp_name_;
        Country_Orgin = ddlorgin_;
        Branch_Type = Branch_;
        Basic_Notn = Basic_Notn_2_;
        Jobno = ddljobno_;
        DataSet dss = IMP_FTA_Select();
        dt = dss.Tables[0];

        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss
        string Filename = "";

        Filename = "IMP_FTA_Rpt";
        string strrptNametime = Filename + "_" + s;

        HttpResponse Response = HttpContext.Current.Response;
        Response.Clear();
        Response.Buffer = true;

        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView gv = new GridView();
            gv.AllowPaging = false;
            gv.DataSource = dt;
            gv.DataBind();

            if (gv.Rows.Count > 0)
            {
                foreach (TableCell cell in gv.HeaderRow.Cells)
                {
                    cell.BackColor = gv.HeaderStyle.BackColor;
                }
                for (int i = 0; i < gv.HeaderRow.Cells.Count; i++)
                {
                    gv.HeaderRow.Cells[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#D8D8D8 ");
                }

                gv.RenderControl(hw);
            }


            string str = Filename + ".xls";
            HttpContext.Current.Session.Remove(Grid_Excel);
            if (File.Exists(Grid_Excel + str))
            {
                DirectoryInfo dir = new DirectoryInfo(Grid_Excel);
                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }
                str = Filename + ".xls";

                StreamWriter myWriter = new StreamWriter((Grid_Excel + "\\" + str + ""), true, System.Text.Encoding.Unicode);
                myWriter.Write(sw.ToString());
                myWriter.Flush();
                myWriter.Close();

                HttpContext.Current.Session["INDEV_NIS_FTA_RPT"] = Grid_Excel + str;
            }
            else
            {
                StreamWriter myWriter = new StreamWriter((Grid_Excel + "\\" + str + ""), true, System.Text.Encoding.Unicode);
                myWriter.Write(sw.ToString());
                myWriter.Flush();
                myWriter.Close();

                HttpContext.Current.Session["INDEV_NIS_FTA_RPT"] = Grid_Excel + str;
            }

        }
    }

}