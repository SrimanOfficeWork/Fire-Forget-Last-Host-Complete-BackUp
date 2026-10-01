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


public class INDEV_IMP_DSR_Rack_Rpt
{

    private string _from_date;
    private string _todate;
    private string _BRANCH_CODE;
    private string _JOBNO;

    public string from_date { get { return _from_date; } set { _from_date = value; } }
    public string todate { get { return _todate; } set { _todate = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }

    DataSet ds = new DataSet();
    DataSet dss = new DataSet();
    DataTable dt = new DataTable();

    public DataSet IMP_DSR_Rack_Master_Search()
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
            if (todate != string.Empty && todate != null)
            {
                arr2 = todate.Split('/');
                todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[10];
            param[2] = new SqlParameter("@jobno", JOBNO);
            param[3] = new SqlParameter("@from_date", from_date);
            param[4] = new SqlParameter("@to_date", todate);
            param[5] = new SqlParameter("@Branch", BRANCH_CODE);

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_IMP_DSR_RACK_RPT", param);

            if (ds.Tables[0].Columns.Count > 7)
            {
                
                DataTable dt = ds.Tables[0];
                //dt.Columns.Remove("columnName");
                dt.Columns.RemoveAt(7);
                dt.Columns.RemoveAt(7);
                dt.Columns.RemoveAt(7);
                ds.Tables.Add(dt);
            }
            else
            {
                
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

    
    public void Open_IND_NIS_IMp_DSR_Rack_rpt_XLs_Report(string JOBNO_, string txtfromdate_, string txttodate_, string ddlmonth_, string Branch_)
    {
        if (txtfromdate_ != string.Empty || txttodate_ != string.Empty)
        {
            from_date = txtfromdate_;
            todate = txttodate_;
        }
        else
        {
            if (ddlmonth_ != string.Empty)
            {
                string[] arr_Month = new string[] { };
                arr_Month = ddlmonth_.Split('-');
                from_date = arr_Month[0];
                todate = arr_Month[1];
            }
            else
            {
                from_date = txtfromdate_;
                todate = txttodate_;
            }
        }

        DataTable dt;
        JOBNO = JOBNO_;
        BRANCH_CODE = Branch_;

        DataSet dss = IMP_DSR_Rack_Master_Search();


        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss
        string Filename = "";

        Filename = "IMP_DSR_Rack_Rpt";
        string strrptNametime = Filename + "_" + s;
        HttpResponse Response = HttpContext.Current.Response;

        Response.AppendHeader("Content-Disposition", "attachment; filename=" + strrptNametime + ".xls");
        Response.ContentType = "application/ms-excel";

        Response.Write("<table border= '10px' solid='black' width='100%'>");
        Response.Write("<tr >");
        for (int i = 0; i < dss.Tables[0].Columns.Count; i++)
        {
            Response.Write("<td bgcolor='D8D8D8' width='100%' >" + dss.Tables[0].Columns[i].ColumnName + "</td>");
        }
        Response.Write("</tr>");
        for (int i = 0; i < dss.Tables[0].Rows.Count; i++)
        {
            Response.Write("<tr>");
            DataRow row = dss.Tables[0].Rows[i];
            for (int j = 0; j < dss.Tables[0].Columns.Count; j++)
            {

                Response.Write("<td>" + row[j] + "</td>");
            }
            Response.Write("</tr>");
        }
        Response.Write("</table>");
        Response.Flush();
        Response.End();
    }
    public void Load_IND_NIS_DSR_Rack__Mail(string JOBNO_, string txtfromdate_, string txttodate_, string ddlmonth_, string Branch_)
    {
        string Grid_Excel = HttpContext.Current.Server.MapPath("~/Submission/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + HttpContext.Current.Session["currentbranch"].ToString() + "/" + HttpContext.Current.Session["currentuser"].ToString() + "/" + "Grid_Excel" + "/");

        if (Directory.Exists(Grid_Excel) == false)
        {
            Directory.CreateDirectory(Grid_Excel);
        }
        if (txtfromdate_ != string.Empty || txttodate_ != string.Empty)
        {
            from_date = txtfromdate_;
            todate = txttodate_;
        }
        else
        {
            if (ddlmonth_ != string.Empty)
            {
                string[] arr_Month = new string[] { };
                arr_Month = ddlmonth_.Split('-');
                from_date = arr_Month[0];
                todate = arr_Month[1];
            }
            else
            {
                from_date = txtfromdate_;
                todate = txttodate_;
            }
        }

        DataTable dt;
        JOBNO = JOBNO_;
        BRANCH_CODE = Branch_;

        DataSet dss = IMP_DSR_Rack_Master_Search();

        dt = dss.Tables[0];

        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss
        string Filename = "IMP_DSR_Rack_Rpt";

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

                HttpContext.Current.Session["INDEV_NIS_DSR_Rack"] = Grid_Excel + str;
            }
            else
            {
                StreamWriter myWriter = new StreamWriter((Grid_Excel + "\\" + str + ""), true, System.Text.Encoding.Unicode);
                myWriter.Write(sw.ToString());
                myWriter.Flush();
                myWriter.Close();

                HttpContext.Current.Session["INDEV_NIS_DSR_Rack"] = Grid_Excel + str;
            }

        }
    }

    

}