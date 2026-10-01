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


public partial class Export_Invoice_Cum_Packing_List_rpt : System.Web.UI.Page
{

    AppSession aps = new AppSession();

    //GST_Imp_Invoice BI = new GST_Imp_Invoice();
    //GST_Imp_Invoice_Credit_Note BI = new GST_Imp_Invoice_Credit_Note();

    Billing_UserBO ObjUBO = new Billing_UserBO();

    Self_Exporter_BO SEBOV = new Self_Exporter_BO();   //SEBOV Means SELF_EXPORTER Business Object Variables    
    Self_Exporter SEOM = new Self_Exporter();          //SEOM  Means SELF_EXPORTER Object Methods


    string CompanyName, Company_Add, ServiceTaxno, Pan_No, STATE_NAME, Remarks, Logo, LOGO1, LOGO2, Bank_Name, Bank_Branch, ACCTYPE, ACCNO, IFSC, Advance_amt, Balanced_amt, Company_Lic = string.Empty, Current_Branch = string.Empty;
    string Invoice_TITLE, GST_NO, CIN_NO, TIN_NO, TAN_NO, Inv_Jurisdiction_Location;

    string Inwords = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();
        Current_Branch = Connection.Current_Branch(); 
      
        if (!IsPostBack)
        {
           Load_Bill_Inv_No();
        }
    }
    private void Load_Bill_Inv_No()
    {
        DataSet dss = new DataSet();
        ObjUBO.Flag = "Bill_jobno_invno_select";//Inv_Tra_Jobno_Update_Select//Bill_jobno_invno_select//Bill_jobno_invno_select Bill_jobno_invno_select
        dss = SEOM.SELECT_SELF_EXPORTER_INV_CUM_PACKING_LIST(ObjUBO);
        if (dss.Tables[0].Rows.Count > 0)
        {
            ddlJob_No.DataSource = dss.Tables[0];
            ddlJob_No.DataTextField = "Inv_no";
            ddlJob_No.DataValueField = "Inv_no";
            ddlJob_No.DataBind();
            ddlJob_No.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlJob_No.SelectedIndex = 0;

            if (Request.QueryString["Bill_Invo"] == "" || Request.QueryString["Bill_Invo"] == null)
            {

            }
            else
            {
                ddlJob_No.SelectedValue = Request.QueryString["Bill_Invo"].ToString();
                load_data();
                if(Request.QueryString["Tax_Mode"].ToString()=="B")
                {                    
                    lblmsg.Text = "GST  Transport  Bill";
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
                ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
                Company_Lic = Connection.Company_License().ToLower();


                if (Company_Lic == "eri00001" || Company_Lic == "eri00004" || Company_Lic == "eri00010")
                {
                    ObjUBO.Sp_Name = "SELF_EXPORTER_INVOICE_CUM_PACKING_LIST_HARI_AND_CO";
                    load_eri02198();
                }
                else if (Company_Lic == "eri02198" || Company_Lic == "eri02099")
                {
                    ObjUBO.Sp_Name = "SELF_EXPORTER_INVOICE_CUM_PACKING_LIST_HARI_AND_CO";
                    load_eri02198();
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void load_eri02198()
    {
        string base64string = "";
        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        dss = SEOM.Self_Exporter_Invoice_Cum_Packing_List_Rpt_data(ObjUBO);
        string TaxMode = " ";
        if (dss.Tables[3].Rows.Count > 0)
        {
            string base64string1 = dss.Tables[3].Rows[0]["SignedQRCodeImage"].ToString();
            //string base64string = base64string1.Substring(base64string1.IndexOf("Submission"));
            if (base64string1.Length > 0)
            {
                base64string = base64string1.Substring(base64string1.IndexOf("Submission"));
            }
        }

        localReport.ReportPath = @"Self_Exporter_Rpt/Self_Exporter_Inv_Cum_Packing_List_rpt_HARI_AND_CO.rdlc";
        CompanyName = "HARI & CO";
        Company_Add = "4/29 E MADURAI BYE PASS ROAD," +
                        "\r\n" +
                               "TUTICORIN - 628006.";

        ServiceTaxno = " ";
        Pan_No = " ";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/HARI_AND_CO.jpeg")).AbsoluteUri;
        //LOGO1 = new Uri(Server.MapPath("~/images/Company_Logo/SKBT_FOOTER.bmp")).AbsoluteUri;

        if (base64string.Length > 0)
        {
            LOGO1 = new Uri(Server.MapPath("~/" + base64string)).AbsoluteUri;
        }
        else { LOGO1 = new Uri(Server.MapPath("~/images/txtbox-mid_90px.png")).AbsoluteUri; }

        LOGO2 = new Uri(Server.MapPath("~/images/Company_Logo/HARI_AND_CO.jpeg")).AbsoluteUri;

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

        //ReportViewer1.LocalReport.DisplayName = "IMPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");//ORIGINAL LINE
        ReportViewer1.LocalReport.DisplayName = ddlJob_No.SelectedItem.ToString();
        Remarks = " ";        
        
        STATE_NAME = " ";



        ReportParameter p1 = new ReportParameter("Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Address", Company_Add);
        ReportParameter p3 = new ReportParameter("ServiceTaxno", ServiceTaxno);
        ReportParameter p4 = new ReportParameter("Remarks", Remarks);
        ReportParameter p5 = new ReportParameter("Logo", Logo);
        ReportParameter p6 = new ReportParameter("TaxMode", TaxMode);
        ReportParameter p7 = new ReportParameter("Pan_No", Pan_No);
        ReportParameter p8 = new ReportParameter("STATE_NAME", STATE_NAME);
        ReportParameter p9 = new ReportParameter("LOGO1", LOGO1);
        ReportParameter p10 = new ReportParameter("LOGO2", LOGO2);

        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }
    private void load_eri01603()//with_e_Invoice
    {
        string base64string = "";
        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        dss = SEOM.Self_Exporter_Invoice_Cum_Packing_List_Rpt_data(ObjUBO);
        string TaxMode = " ";
        if (dss.Tables[3].Rows.Count > 0)
        {
            string base64string1 = dss.Tables[3].Rows[0]["SignedQRCodeImage"].ToString();
            //string base64string = base64string1.Substring(base64string1.IndexOf("Submission"));
            if (base64string1.Length > 0)
            {
                base64string = base64string1.Substring(base64string1.IndexOf("Submission"));
            }
        }

        localReport.ReportPath = @"Billing_Transport_Rpt/GST_Bill_Transport_Job_rpt_SKBT.rdlc";
        CompanyName = "SRI KALKI BHAGAVAN TRANSPORT";
        Company_Add = "Fleet Owners, Transport Contractor" +
                        "\r\n" +
                               "D.No. 8-50-10, 1st floor, Santoshi Nilayam, Chinawaltair, Old CBI Down, Visakhapatnam - 17." +
                                  "\r\n" +
                                 "Email: kalki_bhaghvan@yahoo.co.in";

        ServiceTaxno = " 37AHBPK6958R1ZF";
        Pan_No = " AHBPK6958R";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/SKBT_HEADER.bmp")).AbsoluteUri;
        //LOGO1 = new Uri(Server.MapPath("~/images/Company_Logo/SKBT_FOOTER.bmp")).AbsoluteUri;

        if (base64string.Length > 0)
        {
            LOGO1 = new Uri(Server.MapPath("~/" + base64string)).AbsoluteUri;
        }
        else { LOGO1 = new Uri(Server.MapPath("~/images/txtbox-mid_90px.png")).AbsoluteUri; }


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

        //ReportViewer1.LocalReport.DisplayName = "IMPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");//ORIGINAL LINE
        ReportViewer1.LocalReport.DisplayName = ddlJob_No.SelectedItem.ToString().Substring(9, 4);
        Remarks = dss.Tables[0].Rows[0]["REMARKS"].ToString();
        //STATE_NAME = dss.Tables[0].Rows[0]["STATE_NAME"].ToString();
        //STATE_NAME = dss.Tables[0].Rows[0]["STATE_NAME"].ToString();
        STATE_NAME = " ";// dss.Tables[0].Rows[0]["STATE_NAME"].ToString();



        ReportParameter p1 = new ReportParameter("Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Address", Company_Add);
        ReportParameter p3 = new ReportParameter("ServiceTaxno", ServiceTaxno);
        ReportParameter p4 = new ReportParameter("Remarks", Remarks);
        ReportParameter p5 = new ReportParameter("Logo", Logo);
        ReportParameter p6 = new ReportParameter("TaxMode", TaxMode);
        ReportParameter p7 = new ReportParameter("Pan_No", Pan_No);
        ReportParameter p8 = new ReportParameter("STATE_NAME", STATE_NAME);
        ReportParameter p9 = new ReportParameter("LOGO1", LOGO1);

        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8, p9 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }
    

 

    
    protected void ddlBillModel_SelectedIndexChanged(object sender, EventArgs e)
    {
       
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
        //string File_name = "IMPINV" + (ViewState["File_Name"].ToString()).Replace("-", "").Replace("/", "").Replace("_", "");
        //string File_name = (ViewState["File_Name"].ToString()).Substring(9, 4);//For eri01603 SKBT TRANSPORT
        string File_name = (ViewState["File_Name"].ToString());
        Response.AddHeader("content-disposition", "attachment;filename=" + File_name + ".pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.BinaryWrite(bytes);
        Response.End();
    }
}