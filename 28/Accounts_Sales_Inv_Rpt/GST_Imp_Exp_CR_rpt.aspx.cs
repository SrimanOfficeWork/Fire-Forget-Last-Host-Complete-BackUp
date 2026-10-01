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
using System.Drawing;
using QRCoder;


public partial class GST_Imp_Exp_CR_rpt : System.Web.UI.Page
{

    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();
    GST_Credit_Note_Entry_cs CR = new GST_Credit_Note_Entry_cs();

    string CompanyName = string.Empty, Company_Add = string.Empty, Logo = string.Empty, Bill_Type =string.Empty, QR_Image=string.Empty
         , Company_Add_2 = string.Empty, Company_Lic = string.Empty, Bank_Details = string.Empty
         , GSTN_ID = string.Empty, PAN_NO = string.Empty, STATE_NAME = string.Empty, CIN = string.Empty
         ,QRImage_path =string.Empty
         ;

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
        ObjUBO.A40 = "Bill_Inv_no_Select";
        dss = CR.Select_Inv(ObjUBO);
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
        //load_data();
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
                if (Company_Lic == "eri02360" || Company_Lic == "eri02563")
                {
                    ObjUBO.A9 = "GST_BILL_JOB_CR_RPT_INSOORYA";
                    load_Eri02360();
                }
                else if (Company_Lic == "eri00599")
                {
                    ObjUBO.A9 = "GST_BILL_JOB_CR_RPT_JSV";
                    load_Eri00599();
                }
                else if (Company_Lic == "eri02349")
                {
                    ObjUBO.A9 = "ACC_GST_BILL_JOB_RPT_TBSL_CR";
                    load_Eri02349();
                }
                else if (Company_Lic == "eri03267")
                {
                    ObjUBO.A9 = "ACC_GST_BILL_JOB_RPT_KPS_CR";
                    load_Eri03267();
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void load_Eri03267()
    {
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;
        CompanyName = "KPS WORLDWIDE LOGISTICS PRIVATE LIMITED";
        Company_Add = "No.14, Second Line Beach Road, Jahangir Street, Mannady" +
                               "\r\n" +
                               "Chennai -600001,TAMILNADU" +
                                "\r\n" +
                               "Email -finance@kpsgroups.net";

        GSTN_ID = "GSTNIN : 33AAMCK8639G1Z6";
        PAN_NO = "PAN No : AAMCK8639G";
        STATE_NAME = "State : [33] TAMILNADU";
        CIN = "CIN : U52292TN2026PTC193070";


        Logo = new Uri(Server.MapPath("~/images/Company_Logo/ACC_KPS_CO.png")).AbsoluteUri;
        //Sign = new Uri(Server.MapPath("~/images/Company_Logo/Jaagruthi_Logistics_Sign.jpg")).AbsoluteUri;
       
        ReportViewer1.LocalReport.EnableExternalImages = true;
        dss =CR.Invoice_Job_Rpt_data(ObjUBO);
        if (dss.Tables[0].Rows.Count > 0)
        {
            if (dss.Tables[0].Rows[0]["SignedQRCode"].ToString() != string.Empty)
            {
                QRImage_path = QR_Imagepath(dss.Tables[0].Rows[0]["SignedQRCode"].ToString(), dss.Tables[0].Rows[0]["BILL_INV_NO"].ToString().Replace('/', '_'));
                QR_Image = new Uri(QRImage_path).AbsoluteUri;
            }
            else
            {
                QR_Image = " ";
            }
            if (dss.Tables[0].Rows[0]["LOCAL_OTHER"].ToString() == "L")
            {
                if (dss.Tables[0].Rows[0]["IMP_EXP"].ToString() == "I")
                {
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/Acc_GST_Bill_Job_rpt_Kps_TL.rdlc";
                }
                else
                {
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/Acc_GST_Bill_Job_rpt_Kps_E_TL.rdlc";
                }

                List<ReportParameter> paramList = new List<ReportParameter>();
                this.ReportViewer1.LocalReport.SetParameters(paramList);
                ReportViewer1.LocalReport.DataSources.Clear();

                ReportDataSource datasource = new ReportDataSource("Home", dss.Tables[0]);
                ReportViewer1.LocalReport.DataSources.Add(datasource);
                ReportDataSource datasource1 = new ReportDataSource("General", dss.Tables[1]);
                ReportViewer1.LocalReport.DataSources.Add(datasource1);
                ReportDataSource datasource2 = new ReportDataSource("IGM", dss.Tables[2]);
                ReportViewer1.LocalReport.DataSources.Add(datasource2);
                ReportDataSource datasource3 = new ReportDataSource("Invoice", dss.Tables[3]);
                ReportViewer1.LocalReport.DataSources.Add(datasource3);
                ReportDataSource datasource4 = new ReportDataSource("Item", dss.Tables[4]);
                ReportViewer1.LocalReport.DataSources.Add(datasource4);
                ReportDataSource datasource5 = new ReportDataSource("BE_SB", dss.Tables[5]);
                ReportViewer1.LocalReport.DataSources.Add(datasource5);
                ReportDataSource datasource6 = new ReportDataSource("Charge", dss.Tables[6]);
                ReportViewer1.LocalReport.DataSources.Add(datasource6);

                ReportDataSource datasource7 = new ReportDataSource("Charge_Total", dss.Tables[7]);
                ReportViewer1.LocalReport.DataSources.Add(datasource7);
                ReportDataSource datasource8 = new ReportDataSource("GST_Total", dss.Tables[8]);
                ReportViewer1.LocalReport.DataSources.Add(datasource8);

                ReportDataSource datasource9 = new ReportDataSource("HSN_Charge_Local", dss.Tables[11]);
                ReportViewer1.LocalReport.DataSources.Add(datasource9);

                if (dss.Tables[0].Rows.Count > 0)
                {
                    Bill_Type = dss.Tables[0].Rows[0]["BILL_TYPE"].ToString();
                   
                }
            }
            else
            {
                if (dss.Tables[0].Rows[0]["IMP_EXP"].ToString() == "I")
                {
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/Acc_GST_Bill_Job_rpt_Kps_TO.rdlc";
                }
                else
                {
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/Acc_GST_Bill_Job_rpt_Kps_E_TO.rdlc";
                }

                List<ReportParameter> paramList = new List<ReportParameter>();
                this.ReportViewer1.LocalReport.SetParameters(paramList);
                ReportViewer1.LocalReport.DataSources.Clear();

                ReportDataSource datasource = new ReportDataSource("Home", dss.Tables[0]);
                ReportViewer1.LocalReport.DataSources.Add(datasource);
                ReportDataSource datasource1 = new ReportDataSource("General", dss.Tables[1]);
                ReportViewer1.LocalReport.DataSources.Add(datasource1);
                ReportDataSource datasource2 = new ReportDataSource("IGM", dss.Tables[2]);
                ReportViewer1.LocalReport.DataSources.Add(datasource2);
                ReportDataSource datasource3 = new ReportDataSource("Invoice", dss.Tables[3]);
                ReportViewer1.LocalReport.DataSources.Add(datasource3);
                ReportDataSource datasource4 = new ReportDataSource("Item", dss.Tables[4]);
                ReportViewer1.LocalReport.DataSources.Add(datasource4);
                ReportDataSource datasource5 = new ReportDataSource("BE_SB", dss.Tables[5]);
                ReportViewer1.LocalReport.DataSources.Add(datasource5);
                ReportDataSource datasource6 = new ReportDataSource("Charge", dss.Tables[6]);
                ReportViewer1.LocalReport.DataSources.Add(datasource6);

                ReportDataSource datasource7 = new ReportDataSource("Charge_Total", dss.Tables[7]);
                ReportViewer1.LocalReport.DataSources.Add(datasource7);
                ReportDataSource datasource8 = new ReportDataSource("GST_Total", dss.Tables[8]);
                ReportViewer1.LocalReport.DataSources.Add(datasource8);

                ReportDataSource datasource9 = new ReportDataSource("HSN_Charge_Other", dss.Tables[11]);
                ReportViewer1.LocalReport.DataSources.Add(datasource9);

                if (dss.Tables[0].Rows.Count > 0)
                {
                    Bill_Type = dss.Tables[0].Rows[0]["BILL_TYPE"].ToString();
                   
                }
            }
        }
        ReportViewer1.LocalReport.DisplayName = "INV " + ddl_Inv_No.SelectedValue.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        ReportParameter p1 = new ReportParameter("Company_Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Company_Add", Company_Add);
        ReportParameter p3 = new ReportParameter("Bill_Type", Bill_Type);
        ReportParameter p4 = new ReportParameter("QR_Image", QR_Image);
        ReportParameter p5 = new ReportParameter("Logo", Logo);
        ReportParameter p6 = new ReportParameter("Company_Sign", "");
        ReportParameter p7 = new ReportParameter("Reg_Sez", "");

        ReportParameter p8 = new ReportParameter("GSTN_ID", GSTN_ID);
        ReportParameter p9 = new ReportParameter("PAN_NO", PAN_NO);
        ReportParameter p10 = new ReportParameter("STATE_NAME", STATE_NAME);
        ReportParameter p11 = new ReportParameter("CIN", CIN);

        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p6, p7, p8, p9, p10, p11 };
        ReportViewer1.LocalReport.SetParameters(p);
        Report_Print();
    }
    private void load_Eri02349()
    {
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;
        CompanyName = "TRUE BLUE SHIPPING & LOGISTICS";
        /*
        Company_Add = "Door No.21-C,5th Cross Street," +
                               "\r\n" +
                               "South Phase,Guindy Industrial Estate," +
                               "\r\n" +
                               "Chennai - 600 032";
        */
        Company_Add = "Sai Samuthira Building," +
                               "\r\n" +
                               "2E, Plot 41B & 41C, North Phase, SIDCO Industrial Estate" +
                               "\r\n" +
                               "Ekkatuthangal, Chennai – 600 032";  

        GSTN_ID = "GSTNIN : 33AAQFT5445C1Z5";
        PAN_NO = " ";
        STATE_NAME = "State : [33] TAMILNADU";
        CIN = "CIN :";

        Logo = new Uri(Server.MapPath("~/images/Company_Logo/TRUE_BLUE.PNG")).AbsoluteUri;
        ReportViewer1.LocalReport.EnableExternalImages = true;
        dss = CR.Invoice_Job_Rpt_data(ObjUBO);
        if (dss.Tables[0].Rows.Count > 0)
        {
            Bill_Type = dss.Tables[0].Rows[0]["BILL_TYPE"].ToString();

            if (dss.Tables[0].Rows[0]["SignedQRCode"].ToString() != string.Empty)
            {
                QRImage_path = QR_Imagepath(dss.Tables[0].Rows[0]["SignedQRCode"].ToString(), dss.Tables[0].Rows[0]["BILL_INV_NO"].ToString().Replace('/', '_'));
                QR_Image = new Uri(QRImage_path).AbsoluteUri;
            }
            else
            {
                QR_Image = " ";
            }
            if (dss.Tables[0].Rows[0]["LOCAL_OTHER"].ToString() == "L")
            {
                if (dss.Tables[0].Rows[0]["IMP_EXP"].ToString() == "I")
                {
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/Acc_GST_Bill_Job_rpt_TBSL_TL_CR.rdlc";
                }
                else
                {
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/Acc_GST_Bill_Job_rpt_TBSL_E_TL_CR.rdlc"; 
                }

                List<ReportParameter> paramList = new List<ReportParameter>();
                this.ReportViewer1.LocalReport.SetParameters(paramList);
                ReportViewer1.LocalReport.DataSources.Clear();

                ReportDataSource datasource = new ReportDataSource("Home", dss.Tables[0]);
                ReportViewer1.LocalReport.DataSources.Add(datasource);
                ReportDataSource datasource1 = new ReportDataSource("General", dss.Tables[1]);
                ReportViewer1.LocalReport.DataSources.Add(datasource1);
                ReportDataSource datasource2 = new ReportDataSource("IGM", dss.Tables[2]);
                ReportViewer1.LocalReport.DataSources.Add(datasource2);
                ReportDataSource datasource3 = new ReportDataSource("Invoice", dss.Tables[3]);
                ReportViewer1.LocalReport.DataSources.Add(datasource3);
                ReportDataSource datasource4 = new ReportDataSource("Item", dss.Tables[4]);
                ReportViewer1.LocalReport.DataSources.Add(datasource4);
                ReportDataSource datasource5 = new ReportDataSource("BE_SB", dss.Tables[5]);
                ReportViewer1.LocalReport.DataSources.Add(datasource5);
                ReportDataSource datasource6 = new ReportDataSource("Charge", dss.Tables[6]);
                ReportViewer1.LocalReport.DataSources.Add(datasource6);

                ReportDataSource datasource7 = new ReportDataSource("Charge_Total", dss.Tables[7]);
                ReportViewer1.LocalReport.DataSources.Add(datasource7);
                ReportDataSource datasource8 = new ReportDataSource("GST_Total", dss.Tables[8]);
                ReportViewer1.LocalReport.DataSources.Add(datasource8);

                ReportDataSource datasource9 = new ReportDataSource("HSN_Charge_Local", dss.Tables[11]);
                ReportViewer1.LocalReport.DataSources.Add(datasource9);


            }
            else
            {
                if (dss.Tables[0].Rows[0]["IMP_EXP"].ToString() == "I")
                {
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/Acc_GST_Bill_Job_rpt_TBSL_TO_CR.rdlc";
                }
                else
                {
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/Acc_GST_Bill_Job_rpt_TBSL_E_TO_CR.rdlc";
                }

                List<ReportParameter> paramList = new List<ReportParameter>();
                this.ReportViewer1.LocalReport.SetParameters(paramList);
                ReportViewer1.LocalReport.DataSources.Clear();

                ReportDataSource datasource = new ReportDataSource("Home", dss.Tables[0]);
                ReportViewer1.LocalReport.DataSources.Add(datasource);
                ReportDataSource datasource1 = new ReportDataSource("General", dss.Tables[1]);
                ReportViewer1.LocalReport.DataSources.Add(datasource1);
                ReportDataSource datasource2 = new ReportDataSource("IGM", dss.Tables[2]);
                ReportViewer1.LocalReport.DataSources.Add(datasource2);
                ReportDataSource datasource3 = new ReportDataSource("Invoice", dss.Tables[3]);
                ReportViewer1.LocalReport.DataSources.Add(datasource3);
                ReportDataSource datasource4 = new ReportDataSource("Item", dss.Tables[4]);
                ReportViewer1.LocalReport.DataSources.Add(datasource4);
                ReportDataSource datasource5 = new ReportDataSource("BE_SB", dss.Tables[5]);
                ReportViewer1.LocalReport.DataSources.Add(datasource5);
                ReportDataSource datasource6 = new ReportDataSource("Charge", dss.Tables[6]);
                ReportViewer1.LocalReport.DataSources.Add(datasource6);

                ReportDataSource datasource7 = new ReportDataSource("Charge_Total", dss.Tables[7]);
                ReportViewer1.LocalReport.DataSources.Add(datasource7);
                ReportDataSource datasource8 = new ReportDataSource("GST_Total", dss.Tables[8]);
                ReportViewer1.LocalReport.DataSources.Add(datasource8);

                ReportDataSource datasource9 = new ReportDataSource("HSN_Charge_Other", dss.Tables[11]);
                ReportViewer1.LocalReport.DataSources.Add(datasource9);
            }
        }
        ReportViewer1.LocalReport.DisplayName = "INV " + ddl_Inv_No.SelectedValue.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        ReportParameter p1 = new ReportParameter("Company_Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Company_Add", Company_Add);
        ReportParameter p3 = new ReportParameter("Bill_Type", Bill_Type);
        ReportParameter p4 = new ReportParameter("QR_Image", QR_Image);
        ReportParameter p5 = new ReportParameter("Logo", Logo);

        ReportParameter[] p = { p1, p2, p3, p4, p5 };
        ReportViewer1.LocalReport.SetParameters(p);
        Report_Print();
    }
    private void load_Eri00599()
    {
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;
        CompanyName = "JSV FREIGHT LOGISTICS";

        Company_Add = "3RD FLOOR, O,NO.45, N.NO.89, MARINE TOWER," +
                               "\r\n" +
                               "THAMBU CHETTY STREET, PARRYS," +
                               "\r\n" +
                               "Chennai, Tamil Nadu - 600001";


        GSTN_ID = "GSTNIN : 33AAPFJ5282Q1ZK";
        PAN_NO = "PAN No : AABF14611E";
        STATE_NAME = "State : [33] TAMILNADU";
        CIN = "CIN :";

        Logo = new Uri(Server.MapPath("~/images/Company_Logo/JSV.jpg")).AbsoluteUri;
        ReportViewer1.LocalReport.EnableExternalImages = true;
        dss = CR.Invoice_Job_Rpt_data(ObjUBO);
        if (dss.Tables[0].Rows.Count > 0)
        {
            if (dss.Tables[0].Rows[0]["SignedQRCode"].ToString() != string.Empty)
            {
                QRImage_path = QR_Imagepath(dss.Tables[0].Rows[0]["SignedQRCode"].ToString(), dss.Tables[0].Rows[0]["BILL_INV_NO"].ToString().Replace('/', '_'));
                QR_Image = new Uri(QRImage_path).AbsoluteUri;
            }
            else
            {
                QR_Image = " ";
            }
            if (dss.Tables[0].Rows[0]["LOCAL_OTHER"].ToString() == "L")
            {
                localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/GST_Bill_Job_rpt_JSV_E_TL_CR.rdlc";

                List<ReportParameter> paramList = new List<ReportParameter>();
                this.ReportViewer1.LocalReport.SetParameters(paramList);
                ReportViewer1.LocalReport.DataSources.Clear();

                ReportDataSource datasource = new ReportDataSource("Home", dss.Tables[0]);
                ReportViewer1.LocalReport.DataSources.Add(datasource);

                ReportDataSource datasource2 = new ReportDataSource("Charge", dss.Tables[1]);
                ReportViewer1.LocalReport.DataSources.Add(datasource2);

                ReportDataSource datasource3 = new ReportDataSource("Charge_Total", dss.Tables[2]);
                ReportViewer1.LocalReport.DataSources.Add(datasource3);
                ReportDataSource datasource4 = new ReportDataSource("GST_Total", dss.Tables[3]);
                ReportViewer1.LocalReport.DataSources.Add(datasource4);

                ReportDataSource datasource5 = new ReportDataSource("HSN_Charge_Local", dss.Tables[6]);
                ReportViewer1.LocalReport.DataSources.Add(datasource5);

                Bill_Type = "CREDIT NOTE";
            }
            else
            {
                localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/GST_Bill_Job_rpt_JSV_E_TO.rdlc";

                List<ReportParameter> paramList = new List<ReportParameter>();
                this.ReportViewer1.LocalReport.SetParameters(paramList);
                ReportViewer1.LocalReport.DataSources.Clear();

                ReportDataSource datasource = new ReportDataSource("Home", dss.Tables[0]);
                ReportViewer1.LocalReport.DataSources.Add(datasource);

                ReportDataSource datasource2 = new ReportDataSource("Charge", dss.Tables[1]);
                ReportViewer1.LocalReport.DataSources.Add(datasource2);

                ReportDataSource datasource3 = new ReportDataSource("Charge_Total", dss.Tables[2]);
                ReportViewer1.LocalReport.DataSources.Add(datasource3);
                ReportDataSource datasource4 = new ReportDataSource("GST_Total", dss.Tables[3]);
                ReportViewer1.LocalReport.DataSources.Add(datasource4);

                ReportDataSource datasource5 = new ReportDataSource("HSN_Charge_Other", dss.Tables[7]);
                ReportViewer1.LocalReport.DataSources.Add(datasource5);

                Bill_Type = "CREDIT NOTE";
            }
        }
        ReportViewer1.LocalReport.DisplayName = "INV " + ddl_Inv_No.SelectedValue.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        ReportParameter p1 = new ReportParameter("Company_Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Company_Add", Company_Add);
        ReportParameter p3 = new ReportParameter("Bill_Type", Bill_Type);
        ReportParameter p4 = new ReportParameter("QR_Image", QR_Image);
        ReportParameter p5 = new ReportParameter("Logo", Logo);

        ReportParameter[] p = { p1, p2, p3, p4, p5 };
        ReportViewer1.LocalReport.SetParameters(p);
        Report_Print();
    }

    private void load_Eri02360()
    {
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;
        CompanyName = "Insoorya Express Cargo";

        string Br_Name = string.Empty;
        Br_Name = Connection.Current_Branch().ToLower();

        if (Br_Name == "acc, chennai" || Br_Name == "cusHouse, chennai" || Br_Name == "customs, ennore" || Br_Name == "customs, kattupalli" || Br_Name == "sez, sez perundurai")
        {
            Company_Add = "No.118/273, THAMBU CHETTY STREET, II ND FLOOR" +
                            "\r\n" +
                            "CHENNAI - 600001,TAMILNADU";
        }
        else if (Br_Name == "acc, coiambatore" || Br_Name == "icd, chettipalayam" || Br_Name == "icd, irugur")
        {
            Company_Add = "86/1A, MARUTHAM COMPLEX, 1ST FLOOR," +
                               "\r\n" +
                               "OPP.SINGANALLUR BUS STAND, KAMARAJAR ROAD," +
                               "\r\n" +
                               "SINGANALLUR, COIMBATORE-641015";
        }
        else if (Br_Name == "icd, tuticorin" || Br_Name == "cushouse, tuticorin")
        {
            Company_Add = "No : 20A/3, S.M. Puram 1st street," +
                                "\r\n" +
                                "Tuticorin - 628002"; 
        }


        GSTN_ID = "GSTNIN : 33AABF14611E1Z1";
        PAN_NO = "PAN No : AABF14611E";
        STATE_NAME = "State : [33] TAMILNADU";
        CIN = "CIN :";

        Logo = new Uri(Server.MapPath("~/images/Company_Logo/Insoorya.jpg")).AbsoluteUri;
        ReportViewer1.LocalReport.EnableExternalImages = true;
        dss = CR.Invoice_Job_Rpt_data(ObjUBO);
        if (dss.Tables[0].Rows.Count > 0)
        {
            if (dss.Tables[0].Rows[0]["SignedQRCode"].ToString() != string.Empty)
            {
                QRImage_path = QR_Imagepath(dss.Tables[0].Rows[0]["SignedQRCode"].ToString(), dss.Tables[0].Rows[0]["BILL_INV_NO"].ToString().Replace('/','_'));
                QR_Image = new Uri(QRImage_path).AbsoluteUri;
            }
            else
            {
                QR_Image = " ";
            }
            if (dss.Tables[0].Rows[0]["LOCAL_OTHER"].ToString() == "L")
            {
                localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/GST_Bill_Job_rpt_Insoorya_E_TL_CR.rdlc";

                List<ReportParameter> paramList = new List<ReportParameter>();
                this.ReportViewer1.LocalReport.SetParameters(paramList);
                ReportViewer1.LocalReport.DataSources.Clear();

                ReportDataSource datasource = new ReportDataSource("Home", dss.Tables[0]);
                ReportViewer1.LocalReport.DataSources.Add(datasource);
                
                ReportDataSource datasource2 = new ReportDataSource("Charge", dss.Tables[1]);
                ReportViewer1.LocalReport.DataSources.Add(datasource2);

                ReportDataSource datasource3 = new ReportDataSource("Charge_Total", dss.Tables[2]);
                ReportViewer1.LocalReport.DataSources.Add(datasource3);
                ReportDataSource datasource4 = new ReportDataSource("GST_Total", dss.Tables[3]);
                ReportViewer1.LocalReport.DataSources.Add(datasource4);

                ReportDataSource datasource5 = new ReportDataSource("HSN_Charge_Local", dss.Tables[6]);
                ReportViewer1.LocalReport.DataSources.Add(datasource5);

                Bill_Type = "CREDIT NOTE";
            }
            else
            {
                localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/GST_Bill_Job_rpt_Insoorya_E_TO.rdlc";

                List<ReportParameter> paramList = new List<ReportParameter>();
                this.ReportViewer1.LocalReport.SetParameters(paramList);
                ReportViewer1.LocalReport.DataSources.Clear();

                ReportDataSource datasource = new ReportDataSource("Home", dss.Tables[0]);
                ReportViewer1.LocalReport.DataSources.Add(datasource);
                
                ReportDataSource datasource2 = new ReportDataSource("Charge", dss.Tables[1]);
                ReportViewer1.LocalReport.DataSources.Add(datasource2);

                ReportDataSource datasource3 = new ReportDataSource("Charge_Total", dss.Tables[2]);
                ReportViewer1.LocalReport.DataSources.Add(datasource3);
                ReportDataSource datasource4 = new ReportDataSource("GST_Total", dss.Tables[3]);
                ReportViewer1.LocalReport.DataSources.Add(datasource4);

                ReportDataSource datasource5 = new ReportDataSource("HSN_Charge_Other", dss.Tables[7]);
                ReportViewer1.LocalReport.DataSources.Add(datasource5);

                Bill_Type = "CREDIT NOTE";
            }
        }
        ReportViewer1.LocalReport.DisplayName = "INV " + ddl_Inv_No.SelectedValue.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        ReportParameter p1 = new ReportParameter("Company_Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Company_Add", Company_Add);
        ReportParameter p3 = new ReportParameter("Bill_Type", Bill_Type);
        ReportParameter p4 = new ReportParameter("QR_Image", QR_Image);
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
            ds_A = CR.Select_Inv(ObjUBO);

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
            ss = CR.Select_Inv(ObjUBO);
            if (ss.Tables[0].Rows.Count > 1)
            {
                btn_Annexure.Visible = true;
            }
        }
    }
    private string QR_Imagepath(string SignedQRCode,string Invno)
    {
        //https://www.aspsnippets.com/Articles/880/Dynamically-generate-and-display-QR-code-Image-in-ASPNet/
        string errorFolder = "", imagename = "";
        string QRimgpath = " ";
        if (SignedQRCode != "")
        {
            string code = SignedQRCode;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
            System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
            imgBarCode.Height = 150;
            imgBarCode.Width = 150;
            using (Bitmap bitMap = qrCode.GetGraphic(20))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] byteImage = ms.ToArray();
                    System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                    errorFolder = Server.MapPath("~/Submission/" + "/Accounts/" + Connection.COMPANYID() + "/ACC_GST_BILL_QRCODE/" + "/" + Connection.Current_User() + "/");
                    if (Directory.Exists(errorFolder) == false)
                    {
                        Directory.CreateDirectory(errorFolder);
                    }
                    if (Directory.Exists(errorFolder) == true)
                    {
                        DirectoryInfo dir = new DirectoryInfo(errorFolder);
                        foreach (FileInfo fi in dir.GetFiles())
                        {
                           fi.Delete();
                        }
                    }
                    imagename = Invno + ".png";
                    QRimgpath = errorFolder + imagename;
                    img.Save(QRimgpath);
                }
            }
        }
        return QRimgpath;
    }
}