using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Net;
using System.IO;
/// <summary>
/// Summary description for Bill_Imp_Exp_Servicetax_Rpt
/// </summary>
public class Bill_Imp_Exp_Servicetax_Rpt
{
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);

    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    ErrorLogs er = new ErrorLogs();
    SqlDataReader dr;
    SqlCommand cmd;
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);


    public int result = 0, UPDATE_ID = 0;

    private string _Mode;
    private string _Flag;
   
    private string _startRowIndex;
    private string _maximumRows;
    private string _totalRows;
    private string _Bill_No;

    private string _from_date;
    private string _todate;

    private string _Branch;

    private string _MODULE;

    public string Flag { get { return _Flag; } set { _Flag = value; } }
    public string Branch { get { return _Branch; } set { _Branch = value; } }


    public string MODULE { get { return _MODULE; } set { _MODULE = value; } }



    public string from_date { get { return _from_date; } set { _from_date = value; } }

    public string todate { get { return _todate; } set { _todate = value; } }

    public string Mode { get { return _Mode; } set { _Mode = value; } }

    public string Bill_No { get { return _Bill_No; } set { _Bill_No = value; } }

    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string totalRows { get { return _totalRows; } set { _totalRows = value; } }



    public DataSet Bill_Imp_Exp_Servicetax_Report_Details()
    
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

            SqlParameter[] param = new SqlParameter[15];

           
            param[3] = new SqlParameter("@from_date", from_date);
            param[4] = new SqlParameter("@to_date", todate);
            param[5] = new SqlParameter("@Tr_mode", Mode);
            param[11] = new SqlParameter("@Branch", Branch);
            //param[7] = new SqlParameter("@Bill_No", Bill_No);
            param[8] = new SqlParameter("@Flag", Flag);
            
            param[10] = new SqlParameter("@MODULE", MODULE);

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;

            if (Flag =="Grid_Search")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "BILL_IMP_EXP_SERVICETAX_RPT", param);

                result = Convert.ToInt32(param[6].Value.ToString());

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
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public void Bil_Imp_Exp_Servicetax_XLs_Report(string ddl_Imp_Exp,string Fromdate_, string Todate_, string Mode_, string Branch_, string Type_)
    {

        if (Fromdate_ != string.Empty || Todate_ != string.Empty)
        {
            from_date = Fromdate_;
            todate = Todate_;
        }
       

        HttpResponse Response = HttpContext.Current.Response;
        MODULE = ddl_Imp_Exp;
        from_date = Fromdate_;
        todate = Todate_;
        Mode = Mode_;
        Branch = Branch_;

        Flag = "Grid_Search";
        DataSet dss = Bill_Imp_Exp_Servicetax_Report_Details();
        DataTable dt = dss.Tables[0];
       
        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss
        string Filename = "";

        Filename = "Bil_Imp_Exp_Servicetax_Rpt";
        string strrptNametime = Filename + "_" + s;

        if (Type_ == "excel")
        {

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
        if (Type_ == "Pdf")
        {


        }

    }
}