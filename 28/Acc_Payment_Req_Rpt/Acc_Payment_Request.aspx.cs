using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessObject;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Reporting.WebForms;
using Microsoft.ReportingServices.Rendering;
using Microsoft.ReportingServices.Library;
using ClosedXML.Excel;


public partial class Acc_Payment_Req_Rpt_Acc_Payment_Request : System.Web.UI.Page
{
    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();
    Payment_Request PR = new Payment_Request();

    string CompanyName = string.Empty, Company_Add = string.Empty, Logo = string.Empty, Company_Lic = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();

        if (!IsPostBack)
        {
            load_data();
        }
    }
   
    private void load_data()
    {
        try
        {

            DataSet dss = new DataSet();
            LocalReport localReport = ReportViewer1.LocalReport;
            Company_Lic = Connection.Company_License().ToLower();
            if (Company_Lic == "eri00480" || Company_Lic == "eri00010" || Company_Lic == "eri01019")
            {
                CompanyName = "Sanco Trans Limited";
                Company_Add = "ST Tower, New No.24 & 25,Second Line Beach Road," +
                                       "\r\n" +
                                       "Chennai - 600001,TAMILNADU" +
                                        "\r\n" +
                                       "Tel. No.-9444400252" +
                                        "\r\n" +
                                        "Email -sfd.billing@sancotrans.com";
                Logo = new Uri(Server.MapPath("~/images/Company_Logo/Acc_Sanco.png")).AbsoluteUri;
            }
            else if (Company_Lic == "eri01176" || Company_Lic == "eri01277")
            {
                CompanyName = "Sanco Trans Limited";
                Company_Add = "5B / 6, Karumattampatti –Annur Main Road," +
                                       "\r\n" +
                                       "K.Rayarpalayam, Karumattampatti," +
                                        "\r\n" +
                                       "Coimbatore - 641659,TAMILNADU" +
                                        "\r\n" +
                                       "Tel. No.-9444445283 Email -sfd.cbe@sancotrans.com";
                Logo = new Uri(Server.MapPath("~/images/Company_Logo/Acc_Sanco.png")).AbsoluteUri;
            }
            else if (Company_Lic == "eri01011")
            {
                CompanyName = "Sanco Trans Limited";
                Company_Add = "No.68, MTR Complex -3rd Floor,Outer Ring Road," +
                                       "\r\n" +
                                       "B.Channasandra, Kasturi Nagar," +
                                        "\r\n" +
                                       "Bangalore - 560043, Karnataka" +
                                        "\r\n" +
                                       "Tel. No.-9538892200 Email -blr@sancotrans.com";
                 Logo = new Uri(Server.MapPath("~/images/Company_Logo/Acc_Sanco.png")).AbsoluteUri;
            }
            else
            {
                CompanyName = "";
                Company_Add = "";
                Logo = new Uri(Server.MapPath("")).AbsoluteUri;

            }
            ReportViewer1.LocalReport.EnableExternalImages = true;
            ObjUBO.A1 = Request.QueryString["REF_NO"].ToString();
            ObjUBO.A2 = Request.QueryString["I_E"].ToString();
            ObjUBO.A3 = Request.QueryString["JOBNO"].ToString();
            ObjUBO.A4 = Request.QueryString["JOBNO_PS"].ToString();
            ObjUBO.A50 = "PAYMENT_REQ_RPT";
            dss = PR.Payment_Request_RpT(ObjUBO);

            if (dss.Tables[0].Rows.Count > 0)
            {


                localReport.ReportPath = @"Acc_Payment_Req_Rpt/Acc_Payment_Req.rdlc";

                List<ReportParameter> paramList = new List<ReportParameter>();
                this.ReportViewer1.LocalReport.SetParameters(paramList);
                ReportViewer1.LocalReport.DataSources.Clear();

                ReportDataSource datasource = new ReportDataSource("DataSet1", dss.Tables[0]);
                ReportViewer1.LocalReport.DataSources.Add(datasource);
                ReportDataSource datasource1 = new ReportDataSource("DataSet2", dss.Tables[1]);
                ReportViewer1.LocalReport.DataSources.Add(datasource1);
                ReportDataSource datasource2 = new ReportDataSource("DataSet3", dss.Tables[2]);
                ReportViewer1.LocalReport.DataSources.Add(datasource2);
            }
            ReportViewer1.LocalReport.DisplayName = "Payment Request Report";
            ReportParameter p1 = new ReportParameter("Company_Name", CompanyName);
            ReportParameter p2 = new ReportParameter("Company_Add", Company_Add);
            ReportParameter p3 = new ReportParameter("Logo", Logo);

            ReportParameter[] p = { p1, p2, p3 };
            ReportViewer1.LocalReport.SetParameters(p);
            Report_Print();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }


    private void Report_Print()
    {
        Warning[] warnings;
        string[] streamIds;
        string mimeType = string.Empty, encoding = string.Empty, extension = string.Empty;
        byte[] bytes = ReportViewer1.LocalReport.Render("pdf", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
        Session.Remove("report");
        Session["report"] = bytes;
        //--------------------------------------To Print------------------------------------------------------------------------------------//
        ReportViewer1.Visible = true;
    }
    protected void btnpdf_Click(object sender, EventArgs e)
    {
        byte[] bytes = (byte[])Session["report"];
        Response.ClearHeaders();
        Response.Clear();

        Response.ContentType = "application/pdf";
        string File_name = "PaymentRequest";
        Response.AddHeader("content-disposition", "attachment;filename=" + File_name + ".pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.BinaryWrite(bytes);
        Response.End();
    }
}