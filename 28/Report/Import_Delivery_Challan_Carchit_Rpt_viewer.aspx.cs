using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Data.SqlClient;
using System.IO;
using Microsoft.ApplicationBlocks.Data;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Web.UI.WebControls.WebParts;
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Microsoft.Reporting.WebForms;

public partial class Import_Delivery_Challan_Carchit : System.Web.UI.Page
{
   
    AppSession aps = new AppSession();
    Transaction Transact = new Transaction();
    adminmaster adm = new adminmaster();
    DataSet ds = new DataSet();
    
    public string working_period, ddlJobNo;
   
    Delivery_Challan_Carchit dc = new Delivery_Challan_Carchit();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();

        working_period = HttpContext.Current.Session["WorkingPeriod"].ToString();
       
        if (!IsPostBack)
        {
            Page_loaItem_Details();
        }
    }


    public void Page_loaItem_Details()
    {
        try
        {
            if (Request.QueryString["jobno"] == "" || Request.QueryString["jobno"] == null)
            {
            }
            else
            {
                ddlJobNo = Request.QueryString["jobno"].ToString();
                Session["JobNo"] = ddlJobNo;

                if (Connection.COMPANYID() == "3004")
                {
                    ReportViewer1.LocalReport.ReportPath = @"Report/Import_Delivery_Challan_Carchit_Common.rdlc";
                }
                ReportViewer1.LocalReport.EnableExternalImages = true;
                List<ReportParameter> paramList = new List<ReportParameter>(); this.ReportViewer1.LocalReport.SetParameters(paramList);

                ReportViewer1.LocalReport.DataSources.Clear();
                GetGeneral();

                 
                //--------------------------------------To Print------------------------------------------------------------------------------------//
                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;
                string fileName = "a";
                byte[] bytes = ReportViewer1.LocalReport.Render("pdf", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                Session.Remove("report");
                Session["report"] = bytes;
                //--------------------------------------To Print------------------------------------------------------------------------------------//
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog
                (ex.Message);
        }
    }

    public void GetGeneral()
    {
        DataSet ds = new DataSet();

        dc.JOBNO = ddlJobNo;
        dc.flag = "Job_Search";
        dc.WORKING_PERIOD = working_period;
        dc.BRANCH_COMMON = Connection.Get_Company_Type();
        ds.Clear();
        ds = dc.Delivery_Challan_Carchit_Insert_Update();
        if (dc.result == 2)
        {
            ReportDataSource dataSource1 = new ReportDataSource("DataSet1", ds.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(dataSource1);
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Warning[] warnings;
        string[] streamIds;
        string mimeType = string.Empty;
        string encoding = string.Empty;
        string extension = string.Empty;
        string fileName = "a";

        byte[] bytes = ReportViewer1.LocalReport.Render("word", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
        Session["report"] = bytes;


        //Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
        Response.Buffer = true;
        Response.Clear();
        Response.ContentType = "application/rtf";

        //Response.BinaryWrite(bytes); // create the file
        //Response.Flush(); // send it to the client to download
        Response.OutputStream.Write(bytes, 0, bytes.Length);
        Response.AddHeader("content-disposition", "attachment; filename=" + fileName + "." + "RTF");
        //String encodedImgData = Convert.ToBase64String(bytes);

        //Response.Write(String.Format(encodedImgData)); // create the file
        //Response.Flush(); // send it to the client to download
        Response.OutputStream.Flush();
        Response.OutputStream.Close();
        Response.Flush();
        Response.Close();
    }
}