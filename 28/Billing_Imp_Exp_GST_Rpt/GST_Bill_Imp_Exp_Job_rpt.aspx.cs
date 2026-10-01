using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using Microsoft.ReportingServices.Rendering;
using Microsoft.ReportingServices.Library;
using System.Data.SqlClient;
using System.Data;
using BussinessObject;
using System.IO;
using System.Text;


public partial class GST_Bill_Imp_Exp_Job_rpt : System.Web.UI.Page
{

    AppSession aps = new AppSession();
    GST_Bill_Consolidate GBC = new GST_Bill_Consolidate();
    Billing_UserBO ObjUBO = new Billing_UserBO();
    string CompanyName, Company_Add, ServiceTaxno, Pan_No,STATE_NAME, Remarks, Logo, Advance_amt, Balanced_amt, Company_Lic = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();
        Company_Lic = Connection.Company_License().ToLower();
        
        if (!IsPostBack)
        {
            if (Company_Lic == "eri00353")
            {
                Bank.Visible = true;
            }
           Load_Bill_Inv_No();
        }
    }
    private void Load_Bill_Inv_No()
    {
        DataSet dss = new DataSet();
        ObjUBO.Flag = "Bill_jobno_invno_select";
        dss = GBC.GST_Bill_Consolidate_Select(ObjUBO);

        if (dss.Tables[0].Rows.Count > 0)
        {
            ddlJob_No.DataSource = dss.Tables[0];
            ddlJob_No.DataTextField = "BILL_INV_NO";
            ddlJob_No.DataValueField = "ID";
            ddlJob_No.DataBind();
            ddlJob_No.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlJob_No.SelectedIndex = 0;

            if (Request.QueryString["Job_Id"] == "" || Request.QueryString["Job_Id"] == null)
            {

            }
            else
            {
                ddlJob_No.SelectedValue = Request.QueryString["Job_Id"].ToString();
                load_data();
                if (Request.QueryString["Job_Id"].ToString() != string.Empty)
                {
                    lblmsg.Text = "GST Comine Bill";
                }
            }
        }

    }
    protected void ddlJob_No_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_data();
    }
    private void load_data()
    {
        try
        {
            if (ddlJob_No.SelectedItem.Text != "")
            {

                if (ddlJob_No.SelectedItem.ToString() != string.Empty)
                {
                    ViewState["File_Name"] = ddlJob_No.SelectedItem.ToString();
                }
                else
                {
                    ViewState["File_Name"] = "";
                }
                ObjUBO.ID = ddlJob_No.SelectedValue.ToString();
                ObjUBO.BILL_INV_NO = ddlJob_No.SelectedItem.ToString();
               

                
                if (Company_Lic == "eri00382")
                {
                    ObjUBO.Sp_Name = "GST_BILL_IMP_EXP_JOB_RPT_ACFA";
                    load_eri00382();
                }
                else if (Company_Lic == "eri00353" || Company_Lic.ToLower() == "eri00010")
                {
                    ObjUBO.Sp_Name = "GST_BILL_IMP_EXP_JOB_RPT_ENSEN";
                    load_eri00353();
                }

            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void load_eri00353()
    {
        string  BANK_NAME=string.Empty, AC_NO=string.Empty,BRANCH_NAME=string.Empty,IFSC_CODE=string.Empty;
        if (ddlbank.SelectedValue.ToString() == "S")
        {
            BANK_NAME= "STATE BANK OF INDIA";
            AC_NO="32426974393";
            BRANCH_NAME="PONDICHERRY";
            IFSC_CODE="SBIN0012797";
        }
        else
        {
            BANK_NAME = "KOTAK MAHINDRA BANK";
            AC_NO = "855011001889";
            BRANCH_NAME = "CHENNAI";
            IFSC_CODE = "KKBK0008497";
        }
        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        dss = GBC.Combine_Invoice_Job_Rpt_data(ObjUBO);

        localReport.ReportPath = @"Billing_Imp_Exp_GST_Rpt/GST_Bill_Imp_Exp_Job_rpt_ENSEN.rdlc";
        CompanyName = "ACFA LOGISTICS PVT LTD";

        CompanyName = "ENSEN SHIPPINGS";
        Company_Add = "109/223,SECOND FLOOR," +
                           "\r\n" +
                           "THAMBU CHETTY STREET," +
                            "\r\n" +
                                    "CHENNAI 600 001" +
                                    "\r\n" +
                                    "PHONE NO : 044-25250045,25250009" +
                                     "\r\n" +
                                    "GSTIN NO : 33AADFE5437E1ZT" +
                                     "\r\n" +
                                    "EMAIL : shri@ensenshippings.com, accounts@ensenshippings.com" +
                                      "\r\n" +
                                    "WEBSITE  : www.ensenshippings.com";

        ServiceTaxno = "33AADFE5437E1ZTA";
        Pan_No = " ";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/Ensen.JPG")).AbsoluteUri;


        ReportViewer1.LocalReport.EnableExternalImages = true;

        List<ReportParameter> paramList = new List<ReportParameter>();
        this.ReportViewer1.LocalReport.SetParameters(paramList);
        ReportViewer1.LocalReport.DataSources.Clear();

        ReportDataSource datasource = new ReportDataSource("DataSet1", dss.Tables[0]);
        ReportViewer1.LocalReport.DataSources.Add(datasource);
        ReportDataSource datasource1 = new ReportDataSource("DataSet2", dss.Tables[1]);
        ReportViewer1.LocalReport.DataSources.Add(datasource1);
        ReportDataSource datasource2 = new ReportDataSource("DataSet3", dss.Tables[2]);
        ReportViewer1.LocalReport.DataSources.Add(datasource2);

        ReportViewer1.LocalReport.DisplayName = "INV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");


        string Inv_No = string.Empty, Inv_Date = string.Empty, Net_Amt = string.Empty, Amt_words = string.Empty, GSTN_ID = string.Empty;

        if (dss.Tables[0].Rows.Count > 0)
        {
            Inv_No = dss.Tables[0].Rows[0]["BILL_INV_NO"].ToString();
            Inv_Date = dss.Tables[0].Rows[0]["BILL_INV_DATE"].ToString();
            GSTN_ID = dss.Tables[0].Rows[0]["GSTN_ID"].ToString();
        }

        ReportParameter p1 = new ReportParameter("Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Address", Company_Add);
        ReportParameter p3 = new ReportParameter("ServiceTaxno", ServiceTaxno);

        ReportParameter p4 = new ReportParameter("Inv_No", Inv_No);
        ReportParameter p5 = new ReportParameter("Inv_Date", Inv_Date);
        ReportParameter p6 = new ReportParameter("Net_Amt", Net_Amt);

        ReportParameter p7 = new ReportParameter("Logo", Logo);
        ReportParameter p8 = new ReportParameter("Pan_No", Pan_No);
        ReportParameter p9 = new ReportParameter("Amt_words", Amt_words);
        ReportParameter p10 = new ReportParameter("GSTN_ID", GSTN_ID);

        ReportParameter p11 = new ReportParameter("BANK_NAME", BANK_NAME);
        ReportParameter p12 = new ReportParameter("AC_NO", AC_NO);
        ReportParameter p13 = new ReportParameter("BRANCH_NAME", BRANCH_NAME);
        ReportParameter p14 = new ReportParameter("IFSC_CODE", IFSC_CODE);

        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10,p11,p12,p13,p14 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();
    }
    private void load_eri00382()
    {
        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        dss = GBC.Combine_Invoice_Job_Rpt_data(ObjUBO);

        localReport.ReportPath = @"Billing_Imp_Exp_GST_Rpt/GST_Bill_Imp_Exp_Job_rpt_ACFA.rdlc";
        CompanyName = "ACFA LOGISTICS PVT LTD";

        Company_Add = "NO.75.SPURTANK ROAD," +
                        "\r\n" +
                               "CHETPET," +
                                "\r\n" +
                                 "CHENNAI -600031." +
                                "\r\n" +
                                 "PHONE NO: 044-28362862,63,64,65,69,044-28361676,28366810" +
                                  "\r\n" +
                                 "EMAIL : accounts@acfafreight.com,rprabhakar@acfamail.com";

        ServiceTaxno = "33AAJCA0067B1ZB";
        Pan_No = "AAJCA0067B";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/ACFA.png")).AbsoluteUri;

        ReportViewer1.LocalReport.EnableExternalImages = true;

        List<ReportParameter> paramList = new List<ReportParameter>();
        this.ReportViewer1.LocalReport.SetParameters(paramList);
        ReportViewer1.LocalReport.DataSources.Clear();

        ReportDataSource datasource = new ReportDataSource("DataSet1", dss.Tables[0]);
        ReportViewer1.LocalReport.DataSources.Add(datasource);
        ReportDataSource datasource1 = new ReportDataSource("DataSet2", dss.Tables[1]);
        ReportViewer1.LocalReport.DataSources.Add(datasource1);
        ReportDataSource datasource2 = new ReportDataSource("DataSet3", dss.Tables[2]);
        ReportViewer1.LocalReport.DataSources.Add(datasource2);

        ReportViewer1.LocalReport.DisplayName = "INV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");


        string Inv_No = string.Empty, Inv_Date = string.Empty, Net_Amt = string.Empty, Amt_words = string.Empty, GSTN_ID = string.Empty;

        if (dss.Tables[0].Rows.Count > 0)
        {
            Inv_No = dss.Tables[0].Rows[0]["BILL_INV_NO"].ToString();
            Inv_Date = dss.Tables[0].Rows[0]["BILL_INV_DATE"].ToString();
            GSTN_ID = dss.Tables[0].Rows[0]["GSTN_ID"].ToString();
        }

        ReportParameter p1 = new ReportParameter("Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Address", Company_Add);
        ReportParameter p3 = new ReportParameter("ServiceTaxno", ServiceTaxno);

        ReportParameter p4 = new ReportParameter("Inv_No", Inv_No);
        ReportParameter p5 = new ReportParameter("Inv_Date", Inv_Date);
        ReportParameter p6 = new ReportParameter("Net_Amt", Net_Amt);

        ReportParameter p7 = new ReportParameter("Logo", Logo);
        ReportParameter p8 = new ReportParameter("Pan_No", Pan_No);
        ReportParameter p9 = new ReportParameter("Amt_words", Amt_words);
        ReportParameter p10 = new ReportParameter("GSTN_ID", GSTN_ID);
        
        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8, p9,p10 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();
    }
    
    private void Report_Print()
    {
           Warning[] warnings;
           string[] streamIds;
           string mimeType = string.Empty, encoding = string.Empty,extension = string.Empty;

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
        string File_name = "INV" + (ViewState["File_Name"].ToString()).Replace("-", "").Replace("/", "").Replace("_", "");
        Response.AddHeader("content-disposition", "attachment;filename="+File_name+".pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.BinaryWrite(bytes);
        Response.End();
    }

    protected void ddlbank_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_data();
    }
}