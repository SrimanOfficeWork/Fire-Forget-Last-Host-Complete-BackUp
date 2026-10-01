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


public partial class Billing_Imp_Rpt_Bill_Import_Job_rpt : System.Web.UI.Page
{

    AppSession aps = new AppSession();
    Billing_Imp_Invoice BI = new Billing_Imp_Invoice();

    
    public string SELECT_BRANCH;

    string CompanyName, Company_Add, ServiceTaxno,Pan_No, Remarks, Logo, Advance_amt, Balanced_amt;

    
    DataSet ds = new DataSet();
    DataSet dso = new DataSet();
    DataTable dtCopy = new DataTable();
    int max;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();
        SELECT_BRANCH = Connection.Get_Company_Type();

        if (!IsPostBack)
        {
           Load_Bill_Inv_No();
        }
    }

    private void Load_Bill_Inv_No()
    {
        DataSet dss = new DataSet();
        BI.Mode = "";
        BI.Branch = SELECT_BRANCH;
        BI.Mflag = "Bill_jobno_invno_select";
        dss = BI.Select_IMP_INV();

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
                    lblmsg.Text= "Import Tax & Non-Tax Bill";
                }
                else if(Request.QueryString["Tax_Mode"].ToString()=="T")
                {
                    lblmsg.Text = "Import Tax Bill";
                }
                else 
                {
                    lblmsg.Text = "Import Non-Tax Bill";
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
                if (Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00005")
                {
                    load_eri00004();
                }
                else if (Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00002")
                {
                    load_eri00002();
                }
                else if (Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00146")
                {
                    load_eri00146();
                }
                else if (Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00004")
                {
                    load_eri00004();
                }
                else if (Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00156")
                {
                    load_eri00156();
                }
                else if (Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00247" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00010")
                {
                    load_eri00247();
                }
                else if (Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00314")
                {
                    load_eri00314();
                }
                else if (Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00352")
                {
                    load_eri00352();
                }
            }
        }
        catch (Exception ex)
        {
            //throw ex;
        }
    }
    private void load_eri00002()
    {
        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        BI.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        BI.Branch = SELECT_BRANCH;
        BI.Tax_Mode = Request.QueryString["Tax_Mode"].ToString();
        dss = BI.Invoice_Job_Rpt_data();

        string TaxMode = string.Empty;

        if (Request.QueryString["Tax_Mode"].ToString() == "T")
        {
            TaxMode = " ( T )";
        }
        else if (Request.QueryString["Tax_Mode"].ToString() == "N")
        {
            TaxMode = " ( N )";
        }
        else if (Request.QueryString["Tax_Mode"].ToString() == "B")
        {
            TaxMode = " ";
        }

        localReport.ReportPath = @"Billing_Imp_Rpt/Oriental_Bill_Import_Job_rpt.rdlc";

        /*
        CompanyName = "ORIENTAL SHIPPING & CLEARING AGENCY PVT. LTD.,";
        Company_Add = "1/22 B , M..K.N  ROAD, ALANDUR, " +
                         "\r\n" +
                               "CHENNAI -600016," +
                                "\r\n" +
                                "PHONE:22312516, FAX: 22312513.";

        ServiceTaxno = " ";
        Pan_No = "12345678";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/OSCA.png")).AbsoluteUri;
        */
        if (dss.Tables[4].Rows.Count > 0)
        {
            if (dss.Tables[4].Rows[0]["CLIENT_NAME"].ToString() != string.Empty && dss.Tables[4].Rows[0]["CLIENT_NAME"].ToString() != null)
            {
                CompanyName = dss.Tables[4].Rows[0]["CLIENT_NAME"].ToString();
            }
            else
            {
                CompanyName = "  ";
            }
            if (dss.Tables[4].Rows[0]["Clnt_Address"].ToString() != string.Empty && dss.Tables[4].Rows[0]["Clnt_Address"].ToString() != null)
            {
                Company_Add = dss.Tables[4].Rows[0]["Clnt_Address"].ToString();
            }
            else
            {
                Company_Add = "  ";
            }
            if (dss.Tables[4].Rows[0]["CLIENT_SERVICETAXNO"].ToString() != string.Empty && dss.Tables[4].Rows[0]["CLIENT_SERVICETAXNO"].ToString() != null)
            {
                ServiceTaxno = dss.Tables[4].Rows[0]["CLIENT_SERVICETAXNO"].ToString();
            }
            else
            {
                ServiceTaxno = "  ";
            }
            if (dss.Tables[4].Rows[0]["CLIENT_PANNO"].ToString() != string.Empty && dss.Tables[4].Rows[0]["CLIENT_PANNO"].ToString() != null)
            {
                Pan_No = dss.Tables[4].Rows[0]["CLIENT_PANNO"].ToString();
            }
            else
            {
                Pan_No = "  ";
            }

            //Logo = new Uri(Server.MapPath("~/images/Company_Logo/" + dss.Tables[4].Rows[0]["CLIENT_LOGO"].ToString())).AbsoluteUri;
            Logo = new Uri(Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + "BillingClient/" + dss.Tables[4].Rows[0]["CLIENT_LOGO"].ToString())).AbsoluteUri;
        }
        else
        {
            CompanyName = " ";
            Company_Add = " ";
            ServiceTaxno = "  ";
            Pan_No = " ";
            Logo = new Uri(Server.MapPath("~/images/Company_Logo/OSCA.png")).AbsoluteUri;
        }

        ReportViewer1.LocalReport.EnableExternalImages = true;

        List<ReportParameter> paramList = new List<ReportParameter>();
        this.ReportViewer1.LocalReport.SetParameters(paramList);
        ReportViewer1.LocalReport.DataSources.Clear();

        ReportDataSource datasource = new ReportDataSource("Imp_General_1", dss.Tables[0]);
        ReportViewer1.LocalReport.DataSources.Add(datasource);
       
        DataTable dt = new DataTable();
        dt.Columns.Add("CHARGE_NAME");
        dt.Columns.Add("NonTaxamt");
        dt.Columns.Add("Taxamt");
        dt = dss.Tables[1];

            if (dss.Tables[2].Rows.Count > 0)
            {
                if (dss.Tables[2].Rows[0]["Tax_tot"].ToString() == "0.00")
                {
                    max = 40;
                    //32
                }
                else
                {
                    max = 36;
                    //28
                }
            }
            else
            {
                max = 26;
            }
            for (int i = dt.Rows.Count; i <= max; i++)
            {
                dt.Rows.Add("", "", "");
            }
            dtCopy = dt.Copy();
            dso.Tables.Add(dtCopy);

        ReportDataSource datasource1 = new ReportDataSource("Imp_General_2", dso.Tables[0]);
        ReportViewer1.LocalReport.DataSources.Add(datasource1);
        ReportDataSource datasource2 = new ReportDataSource("Imp_General_3", dss.Tables[2]);
        ReportViewer1.LocalReport.DataSources.Add(datasource2);
        ReportViewer1.LocalReport.DisplayName = "Import_Invoice";
        Remarks = dss.Tables[0].Rows[0]["REMARKS"].ToString();

        if (dss.Tables[3].Rows.Count > 0)
        {
            Advance_amt = dss.Tables[3].Rows[0]["Advance_amt"].ToString();
            Balanced_amt = dss.Tables[3].Rows[0]["Balanced_amt"].ToString();
        }
        else
        {
            Advance_amt = " ";
            Balanced_amt = " ";
        }

        ReportParameter p1 = new ReportParameter("Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Address", Company_Add);
        ReportParameter p3 = new ReportParameter("ServiceTaxno", ServiceTaxno);
        ReportParameter p4 = new ReportParameter("Remarks", Remarks);
        ReportParameter p5 = new ReportParameter("Logo", Logo);
        ReportParameter p6 = new ReportParameter("TaxMode", TaxMode);
        ReportParameter p7 = new ReportParameter("Advance_amt", Advance_amt);
        ReportParameter p8 = new ReportParameter("Balanced_amt", Balanced_amt);
        ReportParameter p9 = new ReportParameter("Pan_No", Pan_No);

        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8,p9 };
        ReportViewer1.LocalReport.SetParameters(p);

        //--------------------------------------To Print------------------------------------------------------------------------------------//
        Warning[] warnings;
        string[] streamIds;
        string mimeType = string.Empty;
        string encoding = string.Empty;
        string extension = string.Empty;

        byte[] bytes = ReportViewer1.LocalReport.Render("pdf", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
        Session.Remove("report");
        Session["report"] = bytes;
        //--------------------------------------To Print------------------------------------------------------------------------------------//
        ReportViewer1.Visible = true;
    }
    private void load_eri00146()
    {
        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        BI.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        BI.Branch = SELECT_BRANCH;
        BI.Tax_Mode = Request.QueryString["Tax_Mode"].ToString();
        dss = BI.Invoice_Job_Rpt_data();

        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Imp_Rpt/Bill_Import_Job_rpt.rdlc";
        
        CompanyName = "BLUE WORLD CARGO";
        Company_Add = "BWC TOWERS," +
                        "\r\n" +
                        "4TH FLOOR,NEW NO. 46/2 OLD NO.37/2," +
                         "\r\n" +
                               "NORTH BEACH ROAD 3RD LINE" +
                                "\r\n" +
                                "CLIVE BATTERY" +
                                 "\r\n" +
                                 "CHENNAI 600 001" +
                                 "\r\n" +
                                 "PHONE NO: 044-25225178,25241958" +
                                  "\r\n" +
                                 "SERVICE TAX NO:AACFB0739PST001" +
                                  "\r\n" +
                                 "PAN NO .: AACFB0739P" +
                                   "\r\n" +
                                 "WEBSITE: www.bwclogistics.com";

        ServiceTaxno = "AACFB0739PST001";
        Pan_No = " ";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/BLUE WORLD Cargo logo.JPG")).AbsoluteUri;
        
        /*
        if (dss.Tables[4].Rows.Count > 0)
        {
            if (dss.Tables[4].Rows[0]["CLIENT_NAME"].ToString() != string.Empty && dss.Tables[4].Rows[0]["CLIENT_NAME"].ToString() != null)
            {
                CompanyName = dss.Tables[4].Rows[0]["CLIENT_NAME"].ToString();
            }
            else
            {
                CompanyName = "  ";
            }
            if (dss.Tables[4].Rows[0]["Clnt_Address"].ToString() != string.Empty && dss.Tables[4].Rows[0]["Clnt_Address"].ToString() != null)
            {
                Company_Add = dss.Tables[4].Rows[0]["Clnt_Address"].ToString();
            }
            else
            {
                Company_Add = "  ";
            }
            if (dss.Tables[4].Rows[0]["CLIENT_SERVICETAXNO"].ToString() != string.Empty && dss.Tables[4].Rows[0]["CLIENT_SERVICETAXNO"].ToString() != null)
            {
                ServiceTaxno = dss.Tables[4].Rows[0]["CLIENT_SERVICETAXNO"].ToString();
            }
            else
            {
                ServiceTaxno = "  ";
            }
            if (dss.Tables[4].Rows[0]["CLIENT_PANNO"].ToString() != string.Empty && dss.Tables[4].Rows[0]["CLIENT_PANNO"].ToString() != null)
            {
                Pan_No = dss.Tables[4].Rows[0]["CLIENT_PANNO"].ToString();
            }
            else
            {
                Pan_No = "  ";
            }

            //Logo = new Uri(Server.MapPath("~/images/Company_Logo/" + dss.Tables[4].Rows[0]["CLIENT_LOGO"].ToString())).AbsoluteUri;
            Logo = new Uri(Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + "BillingClient/" + dss.Tables[4].Rows[0]["CLIENT_LOGO"].ToString())).AbsoluteUri;
        }
        else
        {
            CompanyName = " ";
            Company_Add = " ";
            ServiceTaxno = "  ";
            Pan_No = " ";
            Logo = new Uri(Server.MapPath("~/images/Company_Logo/BLUE WORLD Cargo logo.JPG")).AbsoluteUri;
        }
        */

        ReportViewer1.LocalReport.EnableExternalImages = true;

        List<ReportParameter> paramList = new List<ReportParameter>();
        this.ReportViewer1.LocalReport.SetParameters(paramList);
        ReportViewer1.LocalReport.DataSources.Clear();

        ReportDataSource datasource = new ReportDataSource("Imp_General_1", dss.Tables[0]);
        ReportViewer1.LocalReport.DataSources.Add(datasource);
        ReportDataSource datasource1 = new ReportDataSource("Imp_General_2", dss.Tables[1]);
        ReportViewer1.LocalReport.DataSources.Add(datasource1);

        ReportDataSource datasource2 = new ReportDataSource("Imp_General_3", dss.Tables[2]);
        ReportViewer1.LocalReport.DataSources.Add(datasource2);
        ReportViewer1.LocalReport.DisplayName = "Import_Invoice";
        Remarks = dss.Tables[0].Rows[0]["REMARKS"].ToString();

        if (dss.Tables[3].Rows.Count > 0)
        {
            Advance_amt = dss.Tables[3].Rows[0]["Advance_amt"].ToString();
            Balanced_amt = dss.Tables[3].Rows[0]["Balanced_amt"].ToString();
        }
        else
        {
            Advance_amt = " ";
            Balanced_amt = " ";
        }

        ReportParameter p1 = new ReportParameter("Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Address", Company_Add);
        ReportParameter p3 = new ReportParameter("ServiceTaxno", ServiceTaxno);
        ReportParameter p4 = new ReportParameter("Remarks", Remarks);
        ReportParameter p5 = new ReportParameter("Logo", Logo);
        ReportParameter p6 = new ReportParameter("TaxMode", TaxMode);
        ReportParameter p7 = new ReportParameter("Advance_amt", Advance_amt);
        ReportParameter p8 = new ReportParameter("Balanced_amt", Balanced_amt);
        ReportParameter p9 = new ReportParameter("Pan_No", Pan_No);

        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8, p9 };
        ReportViewer1.LocalReport.SetParameters(p);

        //--------------------------------------To Print------------------------------------------------------------------------------------//
        Warning[] warnings;
        string[] streamIds;
        string mimeType = string.Empty;
        string encoding = string.Empty;
        string extension = string.Empty;

        byte[] bytes = ReportViewer1.LocalReport.Render("pdf", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
        Session.Remove("report");
        Session["report"] = bytes;
        //--------------------------------------To Print------------------------------------------------------------------------------------//
        ReportViewer1.Visible = true;
    }
    private void load_eri00314()
    {
        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        BI.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        BI.Branch = SELECT_BRANCH;
        BI.Tax_Mode = Request.QueryString["Tax_Mode"].ToString();
        dss = BI.Invoice_Job_Rpt_data();
       
        localReport.ReportPath = @"Billing_Imp_Rpt/Bill_Import_Job_rpt_Sab.rdlc";

       
            CompanyName = "SAABARI LOGISTICS PRIVATE LTD";
            Company_Add = "KALYANI HOUSE, 1ST FLOOR," +
                            "\r\n" +
                            "#54 (OLD #91), ARMENIAN STREET," +
                             "\r\n" +
                                   "CHENNAI - 600001." +
                                    "\r\n" +
                                     "PHONE NO: 044-25260628,25215588" +
                                      "\r\n" +
                                     "FAX NO:25260415" +
                                      "\r\n" +
                                     "EMAIL :info@Saabarilogistics.com";


            ServiceTaxno = "AAFCS2437PST001";
            Pan_No = "AAFCS2437P";
            //Logo = new Uri(Server.MapPath("~/images/Company_Logo/BLUE WORLD Cargo logo.JPG")).AbsoluteUri;
            Logo = new Uri(Server.MapPath("~/images/Company_Logo/Sabari_logo.png")).AbsoluteUri;


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

            ReportDataSource datasource6 = new ReportDataSource("DataSet7", dss.Tables[5]);
            ReportViewer1.LocalReport.DataSources.Add(datasource6);

            ReportViewer1.LocalReport.DisplayName = "ImportInvoice";


            string Inv_No = string.Empty, Inv_Date = string.Empty, Net_Amt = string.Empty, Amt_words = string.Empty;

            if (dss.Tables[0].Rows.Count > 0)
            {
                Inv_No = dss.Tables[0].Rows[0]["BILL_INV_NO"].ToString();
                Inv_Date = dss.Tables[0].Rows[0]["BILL_INV_DATE"].ToString();  
            }

            if (dss.Tables[3].Rows.Count > 0)
            {
                    Net_Amt = dss.Tables[3].Rows[dss.Tables[3].Rows.Count-1][1].ToString();
            }

            if (dss.Tables[4].Rows.Count > 0)
            {
                Amt_words = dss.Tables[4].Rows[0]["Des_txt"].ToString();
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


            ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8, p9 };
            ReportViewer1.LocalReport.SetParameters(p);
         
            //--------------------------------------To Print------------------------------------------------------------------------------------//
            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;

            byte[] bytes = ReportViewer1.LocalReport.Render("pdf", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
            Session.Remove("report");
            Session["report"] = bytes;
            //--------------------------------------To Print------------------------------------------------------------------------------------//
            ReportViewer1.Visible = true;

        
    }

    private void load_eri00247()
    {
        string SHIPPER_NAME = string.Empty
            , SHIPPER_ADDRESS = string.Empty
            , Bill_no = string.Empty
            , Bill_Date = string.Empty
            , Your_Ref = string.Empty
            , Our_Ref = string.Empty
            , MAWB_MBL = string.Empty
            , HBL_HAWB = string.Empty;


        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        BI.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        BI.Branch = SELECT_BRANCH;
        BI.Tax_Mode = Request.QueryString["Tax_Mode"].ToString();
        dss = BI.Invoice_Job_Rpt_data();
        if (dss.Tables[0].Rows.Count > 0)
        {
            SHIPPER_NAME = dss.Tables[0].Rows[0]["SHIPPER_NAME"].ToString();
           // SHIPPER_ADDRESS = dss.Tables[0].Rows[0]["SHIPPER_ADDRESS"].ToString();
            SHIPPER_ADDRESS = dss.Tables[0].Rows[0]["SHIPPER_ADDRESS"].ToString() == "" ? "  " : dss.Tables[0].Rows[0]["SHIPPER_ADDRESS"].ToString();
            Bill_no = dss.Tables[0].Rows[0]["Bill_No"].ToString();
            Bill_Date = dss.Tables[0].Rows[0]["Bill_Date"].ToString();
            Your_Ref = dss.Tables[0].Rows[0]["You_Ref"].ToString() == "" ? "  " : dss.Tables[0].Rows[0]["You_Ref"].ToString();
            Our_Ref = dss.Tables[0].Rows[0]["Our_Ref"].ToString() == "" ? "  " : dss.Tables[0].Rows[0]["Our_Ref"].ToString();
            MAWB_MBL = dss.Tables[0].Rows[0]["MAWB_MBL"].ToString();
            HBL_HAWB = dss.Tables[0].Rows[0]["HBL_HAWB"].ToString();
        }
        else
        {
            SHIPPER_NAME = " ";
            SHIPPER_ADDRESS = " ";
            Bill_no =  " ";
            Bill_Date =  " ";
            Your_Ref =  " ";
            Our_Ref =  " ";
            MAWB_MBL = " ";
            HBL_HAWB = " ";
        }
        

        localReport.ReportPath = @"Billing_Imp_Rpt/Bill_Import_Job_rpt_BAS.rdlc";
        CompanyName = "BAS SHIPPING PRIVATE LIMITED";

        /*
        Company_Add = "No.210,Old No.228,2nd & 3rd Floor,Thambu chetty Street,Parrys,Chennai-600 001." +
                        "\r\n" + "Phone : 42130810,42984500.Fax No.: 42159691,"+
                         "\r\n" +
                        "Regd. Off : No.210,Old No.228,2nd & 3rd Floor,Thambu chetty Street,Chennai-600 001." +
                        "\r\n" + "Phone:42984500. E-mail:basshipping@eth.net";
        */
       /* Company_Add = "No.210,Old No.228,2nd & 3rd Floor,Thambu chetty Street,Parrys,Chennai-600 001." +
                        "\r\n" + "Phone : 42130810,42984500.Fax No.: 42159691," +
                        "\r\n" + "Phone:42984500. E-mail:basshipping@eth.net"; */

        Company_Add = "No. 210, Old No. 228, 2nd & 3rd Floor, Thambu chetty Street," +
                        "\r\n" + "Parrys, Chennai - 600 001." +
                        "\r\n" + "Phone : 044 - 25263080 / 044 - 25267848." +
                         "\r\n" + "E-mail : basshipping@eth.net";
                        
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/BAS LOGO.bmp")).AbsoluteUri;

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

        ReportDataSource datasource3 = new ReportDataSource("Adv_Amount", dss.Tables[3]);
        ReportViewer1.LocalReport.DataSources.Add(datasource3);

        ReportViewer1.LocalReport.DisplayName = "Import_Invoice";

        ReportParameter p1 = new ReportParameter("Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Address", Company_Add);
        ReportParameter p3 = new ReportParameter("Logo", Logo);

        ReportParameter p4 = new ReportParameter("SHIPPER_NAME", SHIPPER_NAME);
        ReportParameter p5 = new ReportParameter("SHIPPER_ADDRESS", SHIPPER_ADDRESS);

        ReportParameter p6 = new ReportParameter("Bill_no", Bill_no);
        ReportParameter p7 = new ReportParameter("Bill_Date", Bill_Date);
        ReportParameter p8 = new ReportParameter("Your_Ref", Your_Ref);
        ReportParameter p9 = new ReportParameter("Our_Ref", Our_Ref);
        ReportParameter p10 = new ReportParameter("MAWB_MBL", MAWB_MBL);
        ReportParameter p11 = new ReportParameter("HBL_HAWB", HBL_HAWB);
        

        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11 };
        ReportViewer1.LocalReport.SetParameters(p);

        //--------------------------------------To Print------------------------------------------------------------------------------------//
        Warning[] warnings;
        string[] streamIds;
        string mimeType = string.Empty;
        string encoding = string.Empty;
        string extension = string.Empty;

        byte[] bytes = ReportViewer1.LocalReport.Render("pdf", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
        Session.Remove("report");
        Session["report"] = bytes;
        //--------------------------------------To Print------------------------------------------------------------------------------------//
        ReportViewer1.Visible = true;
    }

    private void load_eri00156()
    {
        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        BI.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        BI.Branch = SELECT_BRANCH;
        BI.Tax_Mode = Request.QueryString["Tax_Mode"].ToString();
        dss = BI.Invoice_Job_Rpt_data();

        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Imp_Rpt/Bill_Import_Job_rpt.rdlc";

        /*
        CompanyName = "World Cargo Logistics";
        Company_Add = "New Add : 140, Citi of Joy," +
                        "\r\n" +
                        "Ecstasy Park, Mulund West, " +
                         "\r\n" +
                                "Mumbai - 400080 " +
                                 "\r\n" +
                                 "PHONE NO: 91 22 32558888" +
                                  "\r\n" +
                                 "SERVICE TAX NO: AABFW7031NSD001" +
                                  "\r\n" +
                                 "PAN NO .: AABFW7031N" ;

        ServiceTaxno = "AABFW7031NSD001";
        Pan_No = " ";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/MC.jpg")).AbsoluteUri;
        */
        if (dss.Tables[4].Rows.Count > 0)
        {
            if (dss.Tables[4].Rows[0]["CLIENT_NAME"].ToString() != string.Empty && dss.Tables[4].Rows[0]["CLIENT_NAME"].ToString() != null)
            {
                CompanyName = dss.Tables[4].Rows[0]["CLIENT_NAME"].ToString();
            }
            else
            {
                CompanyName = "  ";
            }
            if (dss.Tables[4].Rows[0]["Clnt_Address"].ToString() != string.Empty && dss.Tables[4].Rows[0]["Clnt_Address"].ToString() != null)
            {
                Company_Add = dss.Tables[4].Rows[0]["Clnt_Address"].ToString();
            }
            else
            {
                Company_Add = "  ";
            }
            if (dss.Tables[4].Rows[0]["CLIENT_SERVICETAXNO"].ToString() != string.Empty && dss.Tables[4].Rows[0]["CLIENT_SERVICETAXNO"].ToString() != null)
            {
                ServiceTaxno = dss.Tables[4].Rows[0]["CLIENT_SERVICETAXNO"].ToString();
            }
            else
            {
                ServiceTaxno = "  ";
            }
            if (dss.Tables[4].Rows[0]["CLIENT_PANNO"].ToString() != string.Empty && dss.Tables[4].Rows[0]["CLIENT_PANNO"].ToString() != null)
            {
                Pan_No = dss.Tables[4].Rows[0]["CLIENT_PANNO"].ToString();
            }
            else
            {
                Pan_No = "  ";
            }

            //Logo = new Uri(Server.MapPath("~/images/Company_Logo/" + dss.Tables[4].Rows[0]["CLIENT_LOGO"].ToString())).AbsoluteUri;
            Logo = new Uri(Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + "BillingClient/" + dss.Tables[4].Rows[0]["CLIENT_LOGO"].ToString())).AbsoluteUri;
        }
        else
        {
            CompanyName = " ";
            Company_Add = " ";
            ServiceTaxno = "  ";
            Pan_No = " ";
            Logo = new Uri(Server.MapPath("~/images/Company_Logo/MC.jpg")).AbsoluteUri;
        }

        ReportViewer1.LocalReport.EnableExternalImages = true;

        List<ReportParameter> paramList = new List<ReportParameter>();
        this.ReportViewer1.LocalReport.SetParameters(paramList);
        ReportViewer1.LocalReport.DataSources.Clear();

        ReportDataSource datasource = new ReportDataSource("Imp_General_1", dss.Tables[0]);
        ReportViewer1.LocalReport.DataSources.Add(datasource);
        ReportDataSource datasource1 = new ReportDataSource("Imp_General_2", dss.Tables[1]);
        ReportViewer1.LocalReport.DataSources.Add(datasource1);

        ReportDataSource datasource2 = new ReportDataSource("Imp_General_3", dss.Tables[2]);
        ReportViewer1.LocalReport.DataSources.Add(datasource2);
        ReportViewer1.LocalReport.DisplayName = "Import_Invoice";
        Remarks = dss.Tables[0].Rows[0]["REMARKS"].ToString();

        if (dss.Tables[3].Rows.Count > 0)
        {
            Advance_amt = dss.Tables[3].Rows[0]["Advance_amt"].ToString();
            Balanced_amt = dss.Tables[3].Rows[0]["Balanced_amt"].ToString();
        }
        else
        {
            Advance_amt = " ";
            Balanced_amt = " ";
        }

        ReportParameter p1 = new ReportParameter("Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Address", Company_Add);
        ReportParameter p3 = new ReportParameter("ServiceTaxno", ServiceTaxno);
        ReportParameter p4 = new ReportParameter("Remarks", Remarks);
        ReportParameter p5 = new ReportParameter("Logo", Logo);
        ReportParameter p6 = new ReportParameter("TaxMode", TaxMode);
        ReportParameter p7 = new ReportParameter("Advance_amt", Advance_amt);
        ReportParameter p8 = new ReportParameter("Balanced_amt", Balanced_amt);
        ReportParameter p9 = new ReportParameter("Pan_No", Pan_No);

        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8, p9 };
        ReportViewer1.LocalReport.SetParameters(p);

        //--------------------------------------To Print------------------------------------------------------------------------------------//
        Warning[] warnings;
        string[] streamIds;
        string mimeType = string.Empty;
        string encoding = string.Empty;
        string extension = string.Empty;

        byte[] bytes = ReportViewer1.LocalReport.Render("pdf", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
        Session.Remove("report");
        Session["report"] = bytes;
        //--------------------------------------To Print------------------------------------------------------------------------------------//
        ReportViewer1.Visible = true;
    }
    

    private void load_eri00004()
    {
        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        BI.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        BI.Branch = SELECT_BRANCH;
        BI.Tax_Mode = Request.QueryString["Tax_Mode"].ToString();
        dss = BI.Invoice_Job_Rpt_data();

        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Imp_Rpt/Bill_Import_Job_rpt.rdlc";

        if (dss.Tables[4].Rows.Count > 0)
        {
            if (dss.Tables[4].Rows[0]["CLIENT_NAME"].ToString() != string.Empty && dss.Tables[4].Rows[0]["CLIENT_NAME"].ToString() != null)
            {
                CompanyName = dss.Tables[4].Rows[0]["CLIENT_NAME"].ToString();
            }
            else
            {
                CompanyName = "  ";
            }
            if (dss.Tables[4].Rows[0]["Clnt_Address"].ToString() != string.Empty && dss.Tables[4].Rows[0]["Clnt_Address"].ToString() != null)
            {
                Company_Add = dss.Tables[4].Rows[0]["Clnt_Address"].ToString();
            }
            else
            {
                Company_Add = "  ";
            }
            if (dss.Tables[4].Rows[0]["CLIENT_SERVICETAXNO"].ToString() != string.Empty && dss.Tables[4].Rows[0]["CLIENT_SERVICETAXNO"].ToString() != null)
            {
                ServiceTaxno = dss.Tables[4].Rows[0]["CLIENT_SERVICETAXNO"].ToString();
            }
            else
            {
                ServiceTaxno = "  ";
            }
            if (dss.Tables[4].Rows[0]["CLIENT_PANNO"].ToString() != string.Empty && dss.Tables[4].Rows[0]["CLIENT_PANNO"].ToString() != null)
            {
                Pan_No = dss.Tables[4].Rows[0]["CLIENT_PANNO"].ToString();
            }
            else
            {
                Pan_No = "  ";
            }
            
           // Logo = new Uri(Server.MapPath("~/images/Company_Logo/" + dss.Tables[4].Rows[0]["CLIENT_LOGO"].ToString())).AbsoluteUri;
            Logo = new Uri(Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + "BillingClient/" + dss.Tables[4].Rows[0]["CLIENT_LOGO"].ToString())).AbsoluteUri;
        }
        else
        {
            CompanyName = " ";
            Company_Add = " ";
            ServiceTaxno = "  ";
            Pan_No = " ";
           Logo = new Uri(Server.MapPath("~/images/Company_Logo/RoyalTechSystems_Logo_big.GIF")).AbsoluteUri;
        
        }

        

        ReportViewer1.LocalReport.EnableExternalImages = true;

        List<ReportParameter> paramList = new List<ReportParameter>();
        this.ReportViewer1.LocalReport.SetParameters(paramList);
        ReportViewer1.LocalReport.DataSources.Clear();

        ReportDataSource datasource = new ReportDataSource("Imp_General_1", dss.Tables[0]);
        ReportViewer1.LocalReport.DataSources.Add(datasource);
        ReportDataSource datasource1 = new ReportDataSource("Imp_General_2", dss.Tables[1]);
        ReportViewer1.LocalReport.DataSources.Add(datasource1);

        ReportDataSource datasource2 = new ReportDataSource("Imp_General_3", dss.Tables[2]);
        ReportViewer1.LocalReport.DataSources.Add(datasource2);
        ReportViewer1.LocalReport.DisplayName = "Import_Invoice";
        Remarks = dss.Tables[0].Rows[0]["REMARKS"].ToString();

        if (dss.Tables[3].Rows.Count > 0)
        {
            Advance_amt = dss.Tables[3].Rows[0]["Advance_amt"].ToString();
            Balanced_amt = dss.Tables[3].Rows[0]["Balanced_amt"].ToString();
        }
        else
        {
            Advance_amt = " ";
            Balanced_amt = " ";
        }

        ReportParameter p1 = new ReportParameter("Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Address", Company_Add);
        ReportParameter p3 = new ReportParameter("ServiceTaxno", ServiceTaxno);
        ReportParameter p4 = new ReportParameter("Remarks", Remarks);
        ReportParameter p5 = new ReportParameter("Logo", Logo);
        ReportParameter p6 = new ReportParameter("TaxMode", TaxMode);
        ReportParameter p7 = new ReportParameter("Advance_amt", Advance_amt);
        ReportParameter p8 = new ReportParameter("Balanced_amt", Balanced_amt);
        ReportParameter p9 = new ReportParameter("Pan_No", Pan_No);

        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8, p9 };
        ReportViewer1.LocalReport.SetParameters(p);

        //--------------------------------------To Print------------------------------------------------------------------------------------//
        Warning[] warnings;
        string[] streamIds;
        string mimeType = string.Empty;
        string encoding = string.Empty;
        string extension = string.Empty;

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
        Response.AddHeader("content-disposition", "attachment;filename=ImportInvoice.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.BinaryWrite(bytes);
        Response.End();
    }
    private void load_eri00352()
    {
        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        BI.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        BI.Branch = SELECT_BRANCH;
        BI.Tax_Mode = Request.QueryString["Tax_Mode"].ToString();
        dss = BI.Invoice_Job_Rpt_data();

        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Imp_Rpt/Bill_Import_Job_rpt_Anax.rdlc";

        CompanyName = "ANAX AIR SERVICES PVT.LTD.";
        Company_Add = "A PROFESSIONAL SERVICE CO.," +
                        "\r\n" +
                        "908, 9th Floor, Vishwadeep Tower," +
                         "\r\n" +
                               "District Centre," +
                                "\r\n" +
                                "Janakpuri," +
                                 "\r\n" +
                                 "New Delhi- 110058" +
                                 "\r\n" +
                                 "Tel.: 011 - 47985455, 47058203" +
                                  "\r\n" +
                                 "E-mail : info@anaxairs.in" +
                                   "\r\n" +
                                 "WEBSITE: www.anaxairs.in";

        //ServiceTaxno = "AACFB0739PST001";
        ServiceTaxno = "AACFB0739PST001";
        Pan_No = " ";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/ANAX.jpg")).AbsoluteUri;

        ReportViewer1.LocalReport.EnableExternalImages = true;

        List<ReportParameter> paramList = new List<ReportParameter>();
        this.ReportViewer1.LocalReport.SetParameters(paramList);
        ReportViewer1.LocalReport.DataSources.Clear();

        ReportDataSource datasource = new ReportDataSource("Imp_General_1", dss.Tables[0]);
        ReportViewer1.LocalReport.DataSources.Add(datasource);
        ReportDataSource datasource1 = new ReportDataSource("Imp_General_2", dss.Tables[1]);
        ReportViewer1.LocalReport.DataSources.Add(datasource1);

        ReportDataSource datasource2 = new ReportDataSource("Imp_General_3", dss.Tables[2]);
        ReportViewer1.LocalReport.DataSources.Add(datasource2);
        ReportViewer1.LocalReport.DisplayName = "Import_Invoice";
        Remarks = dss.Tables[0].Rows[0]["REMARKS"].ToString();

        if (dss.Tables[3].Rows.Count > 0)
        {
            Advance_amt = dss.Tables[3].Rows[0]["Advance_amt"].ToString();
            Balanced_amt = dss.Tables[3].Rows[0]["Balanced_amt"].ToString();
        }
        else
        {
            Advance_amt = " ";
            Balanced_amt = " ";
        }

        ReportParameter p1 = new ReportParameter("Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Address", Company_Add);
        ReportParameter p3 = new ReportParameter("ServiceTaxno", ServiceTaxno);
        ReportParameter p4 = new ReportParameter("Remarks", Remarks);
        ReportParameter p5 = new ReportParameter("Logo", Logo);
        ReportParameter p6 = new ReportParameter("TaxMode", TaxMode);
        ReportParameter p7 = new ReportParameter("Advance_amt", Advance_amt);
        ReportParameter p8 = new ReportParameter("Balanced_amt", Balanced_amt);
        ReportParameter p9 = new ReportParameter("Pan_No", Pan_No);

        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8, p9 };
        ReportViewer1.LocalReport.SetParameters(p);

        //--------------------------------------To Print------------------------------------------------------------------------------------//
        Warning[] warnings;
        string[] streamIds;
        string mimeType = string.Empty;
        string encoding = string.Empty;
        string extension = string.Empty;

        byte[] bytes = ReportViewer1.LocalReport.Render("pdf", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
        Session.Remove("report");
        Session["report"] = bytes;
        //--------------------------------------To Print------------------------------------------------------------------------------------//
        ReportViewer1.Visible = true;
    }
}