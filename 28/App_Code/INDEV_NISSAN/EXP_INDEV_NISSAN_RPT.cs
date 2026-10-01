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


public class EXP_INDEV_NISSAN_RPT
{
    public int result = 0, UPDATE_ID = 0;
    ErrorLogs er = new ErrorLogs();

    private string _Jobno, _Branch_Type, _Flag, _From_date, _To_date, _Exp_Name, _ItemDesc;

    public string Jobno { get { return _Jobno; } set { _Jobno = value; } }
    public string Flag { get { return _Flag; } set { _Flag = value; } }

    public string From_date { get { return _From_date; } set { _From_date = value; } }
    public string To_date { get { return _To_date; } set { _To_date = value; } }
    public string Exp_Name { get { return _Exp_Name; } set { _Exp_Name = value; } }
    public string ItemDesc { get { return _ItemDesc; } set { _ItemDesc = value; } }


    public DataSet EXP_Select()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@Jobno", Jobno);
            param[1] = new SqlParameter("@Exp_Name", Exp_Name);
            param[3] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[4] = new SqlParameter("@Flag", Flag);

            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("INDEV_NISSAN_EXP_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet EXP_PART_LEVEL_DATA_Select()
    {
        DataSet ds = new DataSet();
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
            param[1] = new SqlParameter("@Exp_Name", Exp_Name);
            param[2] = new SqlParameter("@Jobno", Jobno);
            param[3] = new SqlParameter("@From_date", From_date);
            param[4] = new SqlParameter("@To_date", To_date);
            param[5] = new SqlParameter("@Branch",Connection.Get_Company_Type());
            param[6] = new SqlParameter("@ItemDesc", ItemDesc);
            param[7] = new SqlParameter("@Flag", Flag);


            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("INDEV_NISSAN_EXP_PART_LEVEL_DATA", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public void Open_IND_NIS_PART_LEVEL_DATA_XLs_Report(string ddl_Exp_name_, string txtfromdate_, string txttodate_, string ddlmonth_, string Branch_, string Jobno_, string ItemDesc_)
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
        Exp_Name = ddl_Exp_name_;
        Jobno = Jobno_;
        ItemDesc = ItemDesc_;

        DataSet dss = EXP_PART_LEVEL_DATA_Select();

        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss
        string Filename = "";

        Filename = "EXPORT_PART_LEVEL_DATA";
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
    public void Load_IND_NIS_PART_LEVEL_DATA_XLs_Report_Mail(string ddl_Exp_name_, string txtfromdate_, string txttodate_, string ddlmonth_, string Branch_, string ItemDesc_)
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
        Exp_Name = ddl_Exp_name_;
        ItemDesc = ItemDesc_;

        DataSet dss = EXP_PART_LEVEL_DATA_Select();
        dt = dss.Tables[0];

        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss
        string Filename = "";

        Filename = "EXPORT_PART_LEVEL_DATA";
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

                HttpContext.Current.Session["INDEV_NIS_PART_LEVEL_DATA"] = Grid_Excel + str;
            }
            else
            {
                StreamWriter myWriter = new StreamWriter((Grid_Excel + "\\" + str + ""), true, System.Text.Encoding.Unicode);
                myWriter.Write(sw.ToString());
                myWriter.Flush();
                myWriter.Close();

                HttpContext.Current.Session["INDEV_NIS_PART_LEVEL_DATA"] = Grid_Excel + str;
            }

        }
    }
    
}