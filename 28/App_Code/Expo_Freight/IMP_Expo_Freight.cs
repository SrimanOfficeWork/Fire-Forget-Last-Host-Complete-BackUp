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



public class IMP_Expo_Freight
{

    public int result = 0, UPDATE_ID = 0;
    ErrorLogs er = new ErrorLogs();

    private string _Jobno;
    private string _Branch_Type;
    private string _Flag;
    private string _From_date;
    private string _To_date;

    public string Jobno { get { return _Jobno; } set { _Jobno = value; } }
    public string Branch_Type { get { return _Branch_Type; } set { _Branch_Type = value; } }
    public string Flag { get { return _Flag; } set { _Flag = value; } }

    public string From_date { get { return _From_date; } set { _From_date = value; } }
    public string To_date { get { return _To_date; } set { _To_date = value; } }


    DataSet ds = new DataSet();
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
            param[4] = new SqlParameter("@Branch", Branch_Type);

            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMP_EXPO_FREIGHT_SELECT", param);
           
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

    public void Open_EXPO_FREIGHT_RPT_I_XLs( string txtfromdate_, string txttodate_, string ddlmonth_, string Branch_, string ddljobno_)
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
        Branch_Type = Branch_;
        Jobno = ddljobno_;
        Flag = "Select_Jobno_Rpt";
        DataSet dss = IMP_Select();
        dt = dss.Tables[0];

        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss
        string Filename = "";

        Filename = "IMP_Invoice_Rpt";
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
    public void Load_EXPO_FREIGHT_RPT_I_XLs_Mail(string txtfromdate_, string txttodate_, string ddlmonth_, string Branch_, string ddljobno_)
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
        Branch_Type = Branch_;
        Jobno = ddljobno_;
        Flag = "Select_Jobno_Rpt";
        DataSet dss = IMP_Select();
        dt = dss.Tables[0];

        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss
        string Filename = "";

        Filename = "IMP_Invoice_Rpt";
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

                HttpContext.Current.Session["EXPO_Freight_RPT_1"] = Grid_Excel + str;
            }
            else
            {
                StreamWriter myWriter = new StreamWriter((Grid_Excel + "\\" + str + ""), true, System.Text.Encoding.Unicode);
                myWriter.Write(sw.ToString());
                myWriter.Flush();
                myWriter.Close();

                HttpContext.Current.Session["EXPO_Freight_RPT_1"] = Grid_Excel + str;
            }

        }
    }


   
}