using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.Reporting.WebForms;
using Microsoft.ReportingServices.Rendering;
using Microsoft.ReportingServices.Library;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

using BussinessObject;
using System.IO;
using System.Text;

public partial class GST_Bill_Export_Job_rpt_Credit_Note : System.Web.UI.Page
{
    AppSession aps = new AppSession();
    GST_Exp_Invoice_Credit_Note BI = new GST_Exp_Invoice_Credit_Note();
    Billing_UserBO ObjUBO = new Billing_UserBO();
    string CompanyName, Company_Add, ServiceTaxno, STATE_NAME, Pan_No, Remarks, Logo, LOGO1, LOGO2, Bank_Name, Bank_Branch, ACCTYPE, ACCNO, IFSC, Advance_amt, Balanced_amt, Company_Lic = string.Empty, Inwords = string.Empty, Current_Branch = string.Empty;
   
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
        ObjUBO.Flag = "Bill_jobno_invno_select";
        dss = BI.Select_Exp_INV(ObjUBO);
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

                if (Request.QueryString["Tax_Mode"].ToString() == "B")
                {
                    lblmsg.Text = "GST Export Credit Note Bill";
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

            if (Company_Lic == "eri00010")
            {
               // ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_eROYAL_COMMON";
                //load_eri00001();
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_KSQUARE_CHENNAI_CREDIT_NOTE";
                load_eri00653();
            }
            else if (Company_Lic == "eri00188")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_KSQUARE_MUMBAI_CREDIT_NOTE";
                load_eri00188();
            }
            else if (Company_Lic == "eri00244")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_DENKEN_CREDIT_NOTE";
                load_eri00244();
            }

            else if (Company_Lic == "eri00268")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_VSM_CREDIT_NOTE";
                load_eri00268();
            }
            else if (Company_Lic == "eri00353")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_ENSEN_CREDIT_NOTE";
                load_eri00353();
            }
            else if (Company_Lic == "eri00507")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_SGSL_CREDIT_NOTE";
                load_eri00507();
            }

            else if (Company_Lic == "eri00653")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_KSQUARE_CHENNAI_CREDIT_NOTE";
                load_eri00653();
            }
            else if (Company_Lic == "eri01157")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_R_K_CONTAINER_CREDIT_NOTE";
                load_eri01157();
            }
            else if (Company_Lic == "eri01159")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_SEAGULL_CREDIT_NOTE";
                load_eri01159();
            }
            else if (Company_Lic == "eri01186")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_DENKEN_BLR_CREDIT_NOTE";
                load_eri01186();
            }
            else if (Company_Lic == "eri01316")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_THEESHIKSHA_CREDIT_NOTE";
                load_eri01316();
            }
            else if (Company_Lic == "eri02085")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_ROSAN_CREDIT_NOTE";
                load_eri02085();
            }

        }
    }

    private void load_eri00188()
    {
        string base64string = "";
        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string base64string1 = dss.Tables[2].Rows[0]["SignedQRCodeImage"].ToString();
        if (base64string1.Length > 0)
        {
            base64string = base64string1.Substring(base64string1.IndexOf("Submission"));
        }
        if (dss.Tables[0].Rows.Count > 0)
        {
            localReport.ReportPath = @"Billing_Exp_Rpt_Credit_Note/GST_Bill_Export_Job_rpt_KSQUARE_MUMBAI_Credit_Note.rdlc";
        }

        CompanyName = "K SQUARE LOGISTICS";
        Company_Add = "BUILDING NO 1 EDISON PLOT NO GEN 2 1 C PART, RAHEJA TESLA INDUSTRIAL UNIT NO 222, TTC INDUSTRIAL AREA, MIDC JUINAGAR, NAVI MUMBAI, THANE, MAHARASHTRA, 400705." +
                               "\r\n" +
                               "E-mail: info@ksquarecha.com Web:www.ksquarecha.com";



        Logo = new Uri(Server.MapPath("~/images/Company_Logo/KSQUARE_CHENNAI.jpg")).AbsoluteUri;
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

        ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        ReportParameter p1 = new ReportParameter("Name", CompanyName);
        ReportParameter p7 = new ReportParameter("Logo", Logo);
        ReportParameter p8 = new ReportParameter("LOGO1", LOGO1);

        ReportParameter[] p = { p1, p7, p8 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }

    private void load_eri00244()
    {
        string base64string = "";
        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        if (dss.Tables[5].Rows.Count > 0)
        {
            string base64string1 = dss.Tables[5].Rows[0]["SignedQRCodeImage"].ToString();
            //string base64string = base64string1.Substring(base64string1.IndexOf("Submission"));
            if (base64string1.Length > 0)
            {
                base64string = base64string1.Substring(base64string1.IndexOf("Submission"));
            }
        }
        localReport.ReportPath = @"Billing_Exp_Rpt_Credit_Note/GST_Bill_Export_Job_rpt_DENKEN_Credit_Note.rdlc";

        CompanyName = "DENKEN GLOBAL SUPPLY CHAIN PVT LTD";
        Company_Add = "No.5, Avvaiyar Street," +
                        "\r\n" +
                        "1 st Floor, Meenambakkam," +
                         "\r\n" +
                               "CHENNAI - 600 027.";

        Logo = new Uri(Server.MapPath("~/images/Company_Logo/Denken.png")).AbsoluteUri;
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
        ReportDataSource datasource4 = new ReportDataSource("DataSet5", dss.Tables[4]);
        ReportViewer1.LocalReport.DataSources.Add(datasource4);
        ReportDataSource datasource5 = new ReportDataSource("DataSet6", dss.Tables[5]);
        ReportViewer1.LocalReport.DataSources.Add(datasource5);



        ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");

        ReportParameter p1 = new ReportParameter("Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Address", Company_Add);
        ReportParameter p3 = new ReportParameter("Logo", Logo);
        ReportParameter p4 = new ReportParameter("LOGO1", LOGO1);
        ReportParameter[] p = { p1, p2, p3, p4 };
        ReportViewer1.LocalReport.SetParameters(p);
        Report_Print();

    }

    private void load_eri00268()
    {
        string base64string = "";
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";

        string base64string1 = dss.Tables[3].Rows[0]["SignedQRCodeImage"].ToString();
        //string base64string = base64string1.Substring(base64string1.IndexOf("Submission"));
        if (base64string1.Length > 0)
        {
            base64string = base64string1.Substring(base64string1.IndexOf("Submission"));
        }

        localReport.ReportPath = @"Billing_Exp_Rpt_Credit_Note/GST_Bill_Export_Job_rpt_VSM_Credit_Note.rdlc";

        CompanyName = "VSM LOGISTICS";
        Company_Add = "NEW NO.231,OLD NO.111,1ST FLOOR," +
                        "\r\n" +
                       "OEC COMPLEX,LINGHI CHETTY STREET," +
                         "\r\n" +
                               "CHENNAI-600 001." +
                                "\r\n" +
                                 "PHONE NO:044-42039137" +
                                  "\r\n" +
                                 "EMAIL :admin@vsmlog.com" +
                                      "\r\n" +
                                    "PAN:AALFV9621K";


        ServiceTaxno = "33AALFV9621K1ZP";
        Pan_No = "AALFV9621K";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/VSM.jpg")).AbsoluteUri;

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

        ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        Remarks = dss.Tables[0].Rows[0]["REMARKS"].ToString();
        STATE_NAME = dss.Tables[0].Rows[0]["STATE_NAME"].ToString();


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

    private void load_eri00353()
    {
        string base64string = "";
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;
        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);

        localReport.ReportPath = @"Billing_Exp_Rpt_Credit_Note/GST_Bill_Export_Job_rpt_ENSEN_Credit_Note.rdlc";
        if (dss.Tables[4].Rows.Count > 0)
        {
            string base64string1 = dss.Tables[4].Rows[0]["SignedQRCodeImage"].ToString();
            //string base64string = base64string1.Substring(base64string1.IndexOf("Submission"));
            if (base64string1.Length > 0)
            {
                base64string = base64string1.Substring(base64string1.IndexOf("Submission"));
            }
        }
        CompanyName = "ENSEN SHIPPINGS";
        Company_Add = "109/223,SECOND FLOOR," +
                           "\r\n" +
                           "THAMBU CHETTY STREET," +
                            "\r\n" +
                                    "CHENNAI 600 001" +
                                    "\r\n" +
                                    "PHONE NO : 044-25250045,25250009" +
                                     "\r\n" +
                                    "GSTIN NO:33AADFE5437E1ZT" +
                                     "\r\n" +
                                     "EMAIL : shri@ensenshippings.com, accounts@ensenshippings.com" +
                                      "\r\n" +
                                    "WEBSITE : www.ensenshippings.com";

        ServiceTaxno = "33AADFE5437E1ZTA";
        Pan_No = " ";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/Ensen.JPG")).AbsoluteUri;
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
        ReportDataSource datasource3 = new ReportDataSource("DataSet4", dss.Tables[4]);
        ReportViewer1.LocalReport.DataSources.Add(datasource3);
        ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");

        string Inv_No = string.Empty, Inv_Date = string.Empty, Net_Amt = string.Empty, Amt_words = string.Empty, Tot_Rev_Amt = string.Empty, User_ID = string.Empty;

        if (dss.Tables[0].Rows.Count > 0)
        {
            Inv_No = dss.Tables[0].Rows[0]["BILL_INV_NO"].ToString();
            Inv_Date = dss.Tables[0].Rows[0]["BILL_INV_DATE"].ToString();
            User_ID = dss.Tables[0].Rows[0]["CREATEDBY"].ToString();
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
        ReportParameter p11 = new ReportParameter("CREATEDBY", User_ID);
        ReportParameter p12 = new ReportParameter("LOGO1", LOGO1);

        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p11, p12 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();
    }
    private void load_eri00507()
    {
        string base64string = "";
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
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
        localReport.ReportPath = @"Billing_Exp_Rpt_Credit_Note/GST_Bill_Export_Job_rpt_SGSL_Credit_Note.rdlc";


        CompanyName = "SHREE GANESH SHIPPING AND LOGISTICS";
        Company_Add = "Office No - 103, 1st Floor, Plot no 108, K. Sons Complex," +
                        "\r\n" +
                               "Sector 8, Gandhidham - Kutch, Gujarat - 370201" +
                                "\r\n" +
                                 "Ph: (02836) 232541/42  MOB: +91 90999 50844" +
                                  "\r\n" +
                                 "E-mail: shreeganeshshippingandlogsitic@gmail.com";


        ServiceTaxno = " 24ADOFS1731M1ZR";
        Pan_No = " ADOFS1731M";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/SGSL.jpg")).AbsoluteUri;

        if (base64string.Length > 0)
        {
            LOGO1 = new Uri(Server.MapPath("~/" + base64string)).AbsoluteUri;
        }
        else { LOGO1 = new Uri(Server.MapPath("~/images/txtbox-mid_90px.png")).AbsoluteUri; }

        LOGO2 = new Uri(Server.MapPath("~/images/Company_Logo/SGSL.jpg")).AbsoluteUri;


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



        ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        Remarks = dss.Tables[0].Rows[0]["REMARKS"].ToString();
        STATE_NAME = dss.Tables[0].Rows[0]["STATE_NAME"].ToString();


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
    private void load_eri00653()
    {
        string base64string = "";
        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string base64string1 = dss.Tables[2].Rows[0]["SignedQRCodeImage"].ToString();
        if (base64string1.Length > 0)
        {
            base64string = base64string1.Substring(base64string1.IndexOf("Submission"));
        }
        if (dss.Tables[0].Rows.Count > 0)
        {
            localReport.ReportPath = @"Billing_Exp_Rpt_Credit_Note/GST_BILL_EXPORT_JOB_RPT_KSQUARE_CHENNAI_Credit_Note.rdlc";
        }

        CompanyName = "K SQUARE LOGISTICS";
        Company_Add = "REG.OFF: NO 43/44, BALAJI NAGAR, 3RD STREET, KORATTUR, CHENNAI 600076, INDIA. LANDLINE: 7358687856 " +
        "\r\n" +
        "E-mail: info@ksquarecha.com Web:www.ksquarecha.com";



        Logo = new Uri(Server.MapPath("~/images/Company_Logo/KSQUARE_CHENNAI.jpg")).AbsoluteUri;
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

        ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        ReportParameter p1 = new ReportParameter("Name", CompanyName);
        ReportParameter p7 = new ReportParameter("Logo", Logo);
        ReportParameter p8 = new ReportParameter("LOGO1", LOGO1);

        ReportParameter[] p = { p1, p7, p8 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }

    private void load_eri01157()
    {
        string base64string = "";
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
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
        localReport.ReportPath = @"Billing_Exp_Rpt_Credit_Note/GST_Bill_Export_Job_rpt_R_K_CONTAINER_Credit_Note.rdlc";
        CompanyName = "R.K.Container Movers Pvt. Ltd.";
        Company_Add = "Custom House Agent" +
                        "\r\n" +
                               "No.109/223, 3rd Floor, Thambu Chetty Street, Chennai - 600 001." +
                                "\r\n" +
                                 "Phone:044-25221393| E-mail: accounts@rkcontainermovers.com" +
                                  "\r\n" +
                                 "Web:www.rkcontainermovers.com";

        ServiceTaxno = "33AAGCR1823B2ZY";
        Pan_No = "U63000TN2012PTC088553";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/R_K_CONTAINER_logo.jpg")).AbsoluteUri;
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



        ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        Remarks = dss.Tables[0].Rows[0]["REMARKS"].ToString();
        STATE_NAME = dss.Tables[0].Rows[0]["STATE_NAME"].ToString();


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
    private void load_eri01159()
    {
        string base64string = "";
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
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
        localReport.ReportPath = @"Billing_Exp_Rpt_Credit_Note/GST_Bill_Export_Job_rpt_SEAGULL_Credit_Note.rdlc";
        CompanyName = "SEAGULL CLEARING & FORWARDING AGENCIES (P) LTD";
        Company_Add = "BEACH HOUSE, ROOM NO. 3, 2ND FLOOR," +
                        "\r\n" +
                               "NO. 20, SECOND LINE BEACH, CHENNAI - 600001, TAMILNADU." +
                                "\r\n" +
                                 "Tel:(+91)-44-25249086/25264505/6. Fax(+91)-044-25248221" +
                                  "\r\n" +
                                 "E-mail: seagullcfa@seagullclearing.net";

        ServiceTaxno = "33AABCS2390D1ZR";
        Pan_No = "AABCS2390D";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/SEAGULL_LOGO.png")).AbsoluteUri;

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



        ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        Remarks = dss.Tables[0].Rows[0]["REMARKS"].ToString();
        STATE_NAME = dss.Tables[0].Rows[0]["STATE_NAME"].ToString();


        ReportParameter p1 = new ReportParameter("Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Address", Company_Add);
        ReportParameter p3 = new ReportParameter("ServiceTaxno", ServiceTaxno);
        ReportParameter p4 = new ReportParameter("Remarks", Remarks);
        ReportParameter p5 = new ReportParameter("Logo", Logo);
        ReportParameter p6 = new ReportParameter("TaxMode", TaxMode);
        ReportParameter p7 = new ReportParameter("Pan_No", Pan_No);
        ReportParameter p8 = new ReportParameter("STATE_NAME", STATE_NAME);
        //ReportParameter p9 = new ReportParameter("LOGO1", LOGO1);
        //ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8, p9 };
        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }
    private void load_eri01186()
    {
        string base64string = "";
        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        if (dss.Tables[5].Rows.Count > 0)
        {
            string base64string1 = dss.Tables[5].Rows[0]["SignedQRCodeImage"].ToString();
            //string base64string = base64string1.Substring(base64string1.IndexOf("Submission"));
            if (base64string1.Length > 0)
            {
                base64string = base64string1.Substring(base64string1.IndexOf("Submission"));
            }
        }
        localReport.ReportPath = @"Billing_Exp_Rpt_Credit_Note/GST_Bill_Export_Job_rpt_DENKEN_BLR_Credit_Note.rdlc";

        CompanyName = "DENKEN GLOBAL SUPPLY CHAIN PVT LTD";
        Company_Add = "UNIT NO 149, CARGO VILLAGE," +
                        "\r\n" +
                        "KEMPEGOWDA INTERNATIONAL AIRPORT," +
                         "\r\n" +
                               "Bengaluru, Devaganahalli," +
                               "\r\n" +
                               "Bengaluru Rural, Karnataka, 560300";




        Logo = new Uri(Server.MapPath("~/images/Company_Logo/Denken.png")).AbsoluteUri;
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
        ReportDataSource datasource4 = new ReportDataSource("DataSet5", dss.Tables[4]);
        ReportViewer1.LocalReport.DataSources.Add(datasource4);
        ReportDataSource datasource5 = new ReportDataSource("DataSet6", dss.Tables[5]);
        ReportViewer1.LocalReport.DataSources.Add(datasource5);



        ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");

        ReportParameter p1 = new ReportParameter("Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Address", Company_Add);
        ReportParameter p3 = new ReportParameter("Logo", Logo);
        ReportParameter p4 = new ReportParameter("LOGO1", LOGO1);
        ReportParameter[] p = { p1, p2, p3, p4 };
        ReportViewer1.LocalReport.SetParameters(p);
        Report_Print();

    }
    private void load_eri01316()
    {

        string base64string = "";
        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
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
        localReport.ReportPath = @"Billing_Exp_Rpt_Credit_Note/GST_Bill_Export_Job_rpt_THEESHIKSHA_Credit_Note.rdlc";


        CompanyName = "THEESHIKSHA LOGISTIC PRIVATE LIMITED";
        Company_Add = "No. 39, Natesan Nagar, 5th Main Road," +
                        "\r\n" +
                               "Virugambakkam, Chennai - 600092, India." +
                                  "\r\n" +
                                 "Ph: +91 44 4677 6565  email:  info@tslpl.net";

        ServiceTaxno = " 33AAFCT1412K1ZM";
        Pan_No = " AAFCT1412K";

        Logo = new Uri(Server.MapPath("~/images/Company_Logo/THEESHIKSHA.png")).AbsoluteUri;
        if (base64string.Length > 0)
        {
            LOGO1 = new Uri(Server.MapPath("~/" + base64string)).AbsoluteUri;
        }
        else { LOGO1 = new Uri(Server.MapPath("~/images/txtbox-mid_90px.png")).AbsoluteUri; }

        LOGO2 = new Uri(Server.MapPath("~/images/Company_Logo/THEESHIKSHA.png")).AbsoluteUri;


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



        ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        Remarks = dss.Tables[0].Rows[0]["REMARKS"].ToString();
        STATE_NAME = dss.Tables[0].Rows[0]["STATE_NAME"].ToString();


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

    private void load_eri02085()
    {
        string base64string = "";
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
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
        localReport.ReportPath = @"Billing_Exp_Rpt_Credit_Note/GST_Bill_Export_Job_rpt_ROSAN_Credit_Note.rdlc";
        CompanyName = "ROSAN SEA AIR SERVICES PVT LTD";
        Company_Add = "No.6-1, Asher Nagar, 1st Street, Roja Street," +
                        "\r\n" +
                               "Avinashi Road, Behind S.A.P. Theatre, Gandhi Nagar P.O." +
                                "\r\n" +
                                 "TIRUPUR - 641603, INDIA." +
                                  "\r\n" +
                                 "TEL: +91 421 43364 00/33 MOB: +91 99944 34500" +
                                  "\r\n" +
                                 "E-mail: sankar@rosanseaair.com  web: www.rosanseaair.com";


        ServiceTaxno = " 33AADCR0419A1Z6";
        Pan_No = " AADCR0419A";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/ROSAN.png")).AbsoluteUri;

        if (base64string.Length > 0)
        {
            LOGO1 = new Uri(Server.MapPath("~/" + base64string)).AbsoluteUri;
        }
        else { LOGO1 = new Uri(Server.MapPath("~/images/txtbox-mid_90px.png")).AbsoluteUri; }
        LOGO2 = new Uri(Server.MapPath("~/images/Company_Logo/ROSAN.png")).AbsoluteUri;

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



        ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        Remarks = dss.Tables[0].Rows[0]["REMARKS"].ToString();
        STATE_NAME = dss.Tables[0].Rows[0]["STATE_NAME"].ToString();


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
        string File_name = "EXPINV" + (ViewState["File_Name"].ToString()).Replace("-", "").Replace("/", "").Replace("_", "");
        Response.AddHeader("content-disposition", "attachment;filename=" + File_name + ".pdf");

        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.BinaryWrite(bytes);
        Response.End();
    }
}