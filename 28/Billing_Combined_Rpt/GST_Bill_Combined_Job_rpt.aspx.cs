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


public partial class GST_Bill_Import_Job_rpt : System.Web.UI.Page
{

    AppSession aps = new AppSession();

    GST_Billing_Paramount BP = new GST_Billing_Paramount();
    Global_variables ObjUBO = new Global_variables();

    string CompanyName = string.Empty, Company_Add = string.Empty, Company_Add_2 = string.Empty, Company_Lic = string.Empty, Bank_Details = string.Empty, Remarks = string.Empty, Logo = string.Empty, LOGO1 = string.Empty, LOGO2 = string.Empty;


    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();
      
        if (!IsPostBack)
        {
           Load_Bill_Inv_No();
        }
    }
    private void Load_Bill_Inv_No()
    {
        DataSet dss = new DataSet();
        ddl_Inv_No.Items.Clear();
        
        ObjUBO.A8 = "Bill_Inv_no_Select";
        dss = BP.Select_Inv(ObjUBO);

        if (dss.Tables[0].Rows.Count > 0)
        {
            ddl_Inv_No.DataSource = dss.Tables[0];
            ddl_Inv_No.DataTextField = "BILL_INV_NO";
            ddl_Inv_No.DataValueField = "BILL_INV_NO";
            ddl_Inv_No.DataBind();
        }
        ddl_Inv_No.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddl_Inv_No.SelectedIndex = 0;


       if (Request.QueryString["Bill_Inv_No"] == "" || Request.QueryString["Bill_Inv_No"] == null)
       {

       }
       else
       {
           ddl_Inv_No.SelectedValue = Request.QueryString["Bill_Inv_No"].ToString();
           load_data();
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
            if (ddl_Inv_No.SelectedValue.ToString() != "")
            {
                if (ddl_Inv_No.SelectedValue.ToString() != string.Empty)
                {
                    ViewState["File_Name"] = ddl_Inv_No.SelectedValue.ToString();
                }
                else
                {
                    ViewState["File_Name"] = "";
                }
                ObjUBO.A3 = ddl_Inv_No.SelectedValue.ToString();
                Company_Lic = Connection.Company_License().ToLower();
               
                if (Company_Lic == "eri00010")
                {
                    ObjUBO.A9 = "GST_BILL_JOB_RPT_PARAMOUNT";
                    load_eri00010();
                    Annexure_Chk();
                }
                else if (Company_Lic == "eri00293")
                {
                    ObjUBO.A9 = "GST_BILL_JOB_RPT_PARAMOUNT";
                    load_eri00010();
                    Annexure_Chk();
                }
                else if (Company_Lic == "eri00744")
                {
                    ObjUBO.A9 = "GST_BILL_JOB_RPT_SUNGLOBAL_Live";
                    load_eri00744();
                }
                else if (Company_Lic == "eri00375")
                {
                    ObjUBO.A9 = "GST_BILL_JOB_RPT_SUBRAMANY_LOG";
                    load_eri00375();
                    Annexure_Chk();
                }
                else if (Company_Lic == "eri00704")
                {
                    ObjUBO.A9 = "GST_BILL_JOB_RPT_JAINESH";
                    load_eri00704();
                    Annexure_Chk();
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void load_eri00010()
    {
        CompanyName = "Paramount Shipping Services Pvt Ltd";
        Company_Add = "163, Thambuchetty Street, III Floor, Chennai-1, GSTIN/UIN : 33AAECP5649R1ZQ," +
                        "\r\n" +
                        "State Name : Tamil Nadu, Code:33, Phone No: 044-61108888" +
                          "\r\n" +
                             "Email: accounts@paramountship.com WEBSITE : www.paramountship.com" +
                                   "\r\n" +
                                   "PAN No : AAECP5649R CIN NO : U63090TN2008PTC066600";

        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        dss = BP.Invoice_Job_Rpt_data(ObjUBO);

        if (dss.Tables[0].Rows.Count > 0)
        {

            Bank_Details = dss.Tables[0].Rows[0]["BANK_DETAILS"].ToString();

            if (dss.Tables[0].Rows[0]["Tax_Type"].ToString() == "T")
            {

                if (dss.Tables[0].Rows[0]["LOCAL_OTHER"].ToString() == "L")
                {
                    localReport.ReportPath = @"Billing_Paramount/GST_Bill_Job_rpt_PARAMOUNT_TL.rdlc";
                }
                else if (dss.Tables[0].Rows[0]["LOCAL_OTHER"].ToString() == "O")
                {
                    localReport.ReportPath = @"Billing_Paramount/GST_Bill_Job_rpt_PARAMOUNT_TO.rdlc";
                }

                List<ReportParameter> paramList = new List<ReportParameter>();
                this.ReportViewer1.LocalReport.SetParameters(paramList);
                ReportViewer1.LocalReport.DataSources.Clear();

                ReportDataSource datasource = new ReportDataSource("DataSet1", dss.Tables[0]);
                ReportViewer1.LocalReport.DataSources.Add(datasource);
                ReportDataSource datasource1 = new ReportDataSource("DataSet2", dss.Tables[1]);
                ReportViewer1.LocalReport.DataSources.Add(datasource1);

                ReportDataSource datasource2 = new ReportDataSource("DataSet3", dss.Tables[2]);
                ReportViewer1.LocalReport.DataSources.Add(datasource2);

                ReportDataSource datasource3 = new ReportDataSource("DataSet4", dss.Tables[3]);
                ReportViewer1.LocalReport.DataSources.Add(datasource3);

                ReportDataSource datasource4 = new ReportDataSource("DataSet5", dss.Tables[4]);
                ReportViewer1.LocalReport.DataSources.Add(datasource4);

                ReportDataSource datasource5 = new ReportDataSource("DataSet6", dss.Tables[5]);
                ReportViewer1.LocalReport.DataSources.Add(datasource5);

                ReportDataSource datasource6 = new ReportDataSource("DataSet7", dss.Tables[6]);
                ReportViewer1.LocalReport.DataSources.Add(datasource6);
               
            }
            else
            {
                    if (dss.Tables[0].Rows[0]["Tax_Type"].ToString() == "N")
                    {
                        localReport.ReportPath = @"Billing_Paramount/GST_Bill_Job_rpt_PARAMOUNT_NT.rdlc";
                    }
                    else if (dss.Tables[0].Rows[0]["Tax_Type"].ToString() == "R")
                    {
                        localReport.ReportPath = @"Billing_Paramount/GST_Bill_Job_rpt_PARAMOUNT_RI.rdlc";
                    }

                    List<ReportParameter> paramList = new List<ReportParameter>();
                    this.ReportViewer1.LocalReport.SetParameters(paramList);
                    ReportViewer1.LocalReport.DataSources.Clear();

                    ReportDataSource datasource = new ReportDataSource("DataSet1", dss.Tables[0]);
                    ReportViewer1.LocalReport.DataSources.Add(datasource);
                    ReportDataSource datasource1 = new ReportDataSource("DataSet2", dss.Tables[1]);
                    ReportViewer1.LocalReport.DataSources.Add(datasource1);

                    ReportDataSource datasource2 = new ReportDataSource("DataSet3", dss.Tables[2]);
                    ReportViewer1.LocalReport.DataSources.Add(datasource2);

                    ReportDataSource datasource3 = new ReportDataSource("DataSet4", dss.Tables[3]);
                    ReportViewer1.LocalReport.DataSources.Add(datasource3);

                    ReportDataSource datasource4 = new ReportDataSource("DataSet5", dss.Tables[4]);
                    ReportViewer1.LocalReport.DataSources.Add(datasource4);
            }
        }
        ReportViewer1.LocalReport.DisplayName = "INV " + ddl_Inv_No.SelectedValue.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        ReportParameter p1 = new ReportParameter("Company_Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Company_Add", Company_Add);
        ReportParameter p3 = new ReportParameter("Bank_Details", Bank_Details);
        ReportParameter[] p = { p1, p2, p3 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();
    }
    private void load_eri00375()
    {
        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        dss = BP.Invoice_Job_Rpt_data(ObjUBO);


        CompanyName = "  ";
        Company_Add = "  ";
        Bank_Details = "  ";
        Remarks = "  ";


        Logo = new Uri(Server.MapPath("~/images/Company_Logo/Subramany.jpg")).AbsoluteUri;

        if (dss.Tables[0].Rows.Count > 0)
        {

            localReport.ReportPath = @"Billing_Combined_Rpt/GST_Bill_Job_rpt_SUBRAMANY_LOG.rdlc";

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
            ReportDataSource datasource3 = new ReportDataSource("DataSet4", dss.Tables[3]);
            ReportViewer1.LocalReport.DataSources.Add(datasource3);
            ReportDataSource datasource4 = new ReportDataSource("DataSet5", dss.Tables[4]);
            ReportViewer1.LocalReport.DataSources.Add(datasource4);
        }
        ReportViewer1.LocalReport.DisplayName = "INV" + ddl_Inv_No.SelectedValue.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        ReportParameter p1 = new ReportParameter("CompanyName", CompanyName);
        ReportParameter p2 = new ReportParameter("Company_Add", Company_Add);
        ReportParameter p3 = new ReportParameter("Bank_Details", Bank_Details);
        ReportParameter p4 = new ReportParameter("Remarks", Remarks);
        ReportParameter p5 = new ReportParameter("Logo", Logo);
        ReportParameter[] p = { p1, p2, p3, p4, p5 };
        ReportViewer1.LocalReport.SetParameters(p);
        Report_Print();
    }
    private void load_eri00744()
    {
        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        dss = BP.Invoice_Job_Rpt_data(ObjUBO);

        Bank_Details = "  ";
        CompanyName = "  ";
        Company_Add = "  ";

        if (dss.Tables[0].Rows.Count > 0)
        {

            //localReport.ReportPath = @"Billing_Paramount/GST_Bill_Job_rpt_SUNGLOBAL.rdlc";            
            localReport.ReportPath = @"Billing_Combined_Rpt/GST_Bill_Job_rpt_SUNGLOBAL.rdlc";
            List<ReportParameter> paramList = new List<ReportParameter>();
            this.ReportViewer1.LocalReport.SetParameters(paramList);
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource datasource = new ReportDataSource("DataSet1", dss.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            ReportDataSource datasource1 = new ReportDataSource("DataSet2", dss.Tables[1]);
            ReportViewer1.LocalReport.DataSources.Add(datasource1);
            ReportDataSource datasource2 = new ReportDataSource("DataSet3", dss.Tables[2]);
            ReportViewer1.LocalReport.DataSources.Add(datasource2);
            ReportDataSource datasource3 = new ReportDataSource("DataSet4", dss.Tables[3]);
            ReportViewer1.LocalReport.DataSources.Add(datasource3);
            ReportDataSource datasource4 = new ReportDataSource("DataSet5", dss.Tables[4]);
            ReportViewer1.LocalReport.DataSources.Add(datasource4);
        }
        ReportViewer1.LocalReport.DisplayName = "INV" + ddl_Inv_No.SelectedValue.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        ReportParameter p1 = new ReportParameter("CompanyName", CompanyName);
        ReportParameter p2 = new ReportParameter("Company_Add", Company_Add);
        ReportParameter p3 = new ReportParameter("Bank_Details", Bank_Details);
        ReportParameter[] p = { p1, p2, p2 };
        ReportViewer1.LocalReport.SetParameters(p);
        Report_Print();
    }
    private void load_eri00704()
    {
        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        dss = BP.Invoice_Job_Rpt_data(ObjUBO);


        CompanyName = "  ";
        Company_Add = "  ";
        Bank_Details = "  ";
        Remarks = "  ";


        Logo = new Uri(Server.MapPath("~/images/Company_Logo/JAINESH.jpg")).AbsoluteUri;

        if (dss.Tables[0].Rows.Count > 0)
        {

            localReport.ReportPath = @"Billing_Combined_Rpt/GST_Bill_Job_rpt_JAINESH.rdlc";

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
            ReportDataSource datasource3 = new ReportDataSource("DataSet4", dss.Tables[3]);
            ReportViewer1.LocalReport.DataSources.Add(datasource3);
            ReportDataSource datasource4 = new ReportDataSource("DataSet5", dss.Tables[4]);
            ReportViewer1.LocalReport.DataSources.Add(datasource4);
        }
        ReportViewer1.LocalReport.DisplayName = "INV" + ddl_Inv_No.SelectedValue.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        ReportParameter p1 = new ReportParameter("CompanyName", CompanyName);
        ReportParameter p2 = new ReportParameter("Company_Add", Company_Add);
        ReportParameter p3 = new ReportParameter("Bank_Details", Bank_Details);
        ReportParameter p4 = new ReportParameter("Remarks", Remarks);
        ReportParameter p5 = new ReportParameter("Logo", Logo);
        ReportParameter[] p = { p1, p2, p3, p4, p5 };
        ReportViewer1.LocalReport.SetParameters(p);
        Report_Print();
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
        string File_name = "INV" + (ViewState["File_Name"].ToString()).Replace("-", "").Replace("/", "").Replace("_", "");
        Response.AddHeader("content-disposition", "attachment;filename=" + File_name + ".pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.BinaryWrite(bytes);
        Response.End();
    }
    protected void btn_Annexure_Click(object sender, EventArgs e)
    {
        DataSet ds_A = new DataSet();
        DataTable dt = new DataTable();
        if (ddl_Inv_No.SelectedValue.ToString() != string.Empty)
        {
            ObjUBO.A1 = ddl_Inv_No.SelectedValue.ToString();
            ObjUBO.A8 = "Bill_Inv_no_Annexure";
            ds_A = BP.Select_Inv(ObjUBO);

            dt = ds_A.Tables[0];
            if (ds_A.Tables[0].Rows.Count > 0)
            {
                DateTime time = DateTime.Now;
                String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss
                string strrptNametime = ddl_Inv_No.SelectedValue.ToString() + "_" + s;

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
                    gv.ShowHeader = false;
                    gv.DataSource = dt;
                    gv.DataBind();
                    gv.RenderControl(hw);
                    //style to format numbers to string
                    string style = @"<style> .textmode { } </style>";
                    Response.Write(style);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
            }
        }
    }
    private void Annexure_Chk()
    {
        DataSet ss = new DataSet();
        btn_Annexure.Visible = false;

        if (ddl_Inv_No.SelectedValue.ToString() != string.Empty)
        {
            ObjUBO.A1 = ddl_Inv_No.SelectedValue.ToString();
            ObjUBO.A8 = "Bill_Inv_no_Annexure_Chk";
            ss = BP.Select_Inv(ObjUBO);
            if (ss.Tables[0].Rows.Count > 1)
            {
                btn_Annexure.Visible = true;
            }
        }
    }
}