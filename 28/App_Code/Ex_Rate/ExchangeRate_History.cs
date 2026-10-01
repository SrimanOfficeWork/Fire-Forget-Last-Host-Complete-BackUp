using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Web;
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
using BussinessObject;

/// <summary>
/// Summary description for ExchangeRate_History
/// </summary>
public class ExchangeRate_History
{

    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    public int result, UpdateId;
    UserBO ObjUBO = new UserBO();

    public DataSet Reteive_All_ExRate(UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            string F_Date = "", T_date = "";
            if (objUserBL.From_date != "")
            {
                string[] sp = objUserBL.From_date.Split('/');
                string sp0 = sp[0];
                string sp1 = sp[1];
                string sp2 = sp[2];
                F_Date = sp1 + "/" + sp0 + "/" + sp2;
            }
            if (objUserBL.Todate != "")
            {
                string[] sp = objUserBL.Todate.Split('/');
                string sp0 = sp[0];
                string sp1 = sp[1];
                string sp2 = sp[2];
                T_date = sp1 + "/" + sp0 + "/" + sp2;
            }

            param[1] = new SqlParameter("@Effect_From", objUserBL.Effect_From);
            param[2] = new SqlParameter("@Currecy", objUserBL.Currecy);
            param[3] = new SqlParameter("@from_date", F_Date);
            param[4] = new SqlParameter("@to_date", T_date);
            //param[3] = new SqlParameter("@.from_date", objUserBL.from_date);
            //param[4] = new SqlParameter("@to_date", objUserBL.to_date);
            param[5] = new SqlParameter("@Month", objUserBL.Month);
            param[6] = new SqlParameter("@Year", objUserBL.Year);
            param[7] = new SqlParameter("@Ename", objUserBL.Ename);
            param[8] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            if (objUserBL.Ename == "Select_All_NormalSearch" || objUserBL.Ename == "Get_Effective_from" || objUserBL.Ename == "Get_Month" || objUserBL.Ename == "Get_Year")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "EXCHANGE_RATE_ALL_SEARCH", param);
                result = Convert.ToInt32(param[8].Value.ToString());
                string err = param[9].Value.ToString();

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                    }
                    else
                    {
                        ds.Tables.Add(dt);
                    }
                }
                else
                {
                    ds.Tables.Add(dt);
                }
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }


    public void Open_PL_XLs_ExchangeRate_History_Report(string ddlEffect_From_, string txtCurrency_, string txtfromdate_, string txttodate_, string ddl_Month_, string ddl_Year_)
    {

        HttpResponse Response = HttpContext.Current.Response;
        ObjUBO.Effect_From = ddlEffect_From_;
        ObjUBO.Currecy = txtCurrency_;
        ObjUBO.From_date = txtfromdate_;
        ObjUBO.Todate = txttodate_ == " " ? string.Empty : txttodate_;
        ObjUBO.Month = ddl_Month_;
        ObjUBO.Year = ddl_Year_;
        ObjUBO.Ename = "Select_All_NormalSearch";

        DataSet ddt = Reteive_All_ExRate(ObjUBO);
        DataTable dd = ddt.Tables[0];

        DataView dv = new DataView(dd);
        DataTable dt = dv.ToTable();

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
                    gv.HeaderRow.Style.Add("font-size", "10PX");
                    gv.HeaderRow.Style.Add("text-align", "center");

                    for (int i = 0; i < gv.Rows.Count; i++)
                    {
                        GridViewRow row = gv.Rows[i];
                        row.Attributes.Add("class", "textmode");

                        row.Cells[0].Style.Add("text-align", "center");
                        row.Cells[1].Style.Add("text-align", "center");
                        row.Cells[2].Style.Add("text-align", "center");
                        row.Cells[3].Style.Add("text-align", "left");
                        row.Cells[4].Style.Add("text-align", "center");
                        row.Cells[5].Style.Add("text-align", "center");
                        row.Cells[6].Style.Add("text-align", "center");

                        row.Cells[0].Style.Add("font-size", "8px");
                        row.Cells[1].Style.Add("font-size", "8px");
                        row.Cells[2].Style.Add("font-size", "8px");
                        row.Cells[3].Style.Add("font-size", "8px");
                        row.Cells[4].Style.Add("font-size", "8px");
                        row.Cells[5].Style.Add("font-size", "8px");
                        row.Cells[6].Style.Add("font-size", "8px");
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
                    Response.AddHeader("content-disposition", "attachment;filename=IMP_PL_1_Statement.pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();

                }
            }
        }
    }
}