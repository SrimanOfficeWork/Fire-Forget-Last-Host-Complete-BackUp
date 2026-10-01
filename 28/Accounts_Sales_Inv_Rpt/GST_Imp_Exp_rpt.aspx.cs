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
using ClosedXML.Excel;


public partial class GST_Bill_Import_Job_rpt : System.Web.UI.Page
{

    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();
    GST_Sales_Entry_cs SR = new GST_Sales_Entry_cs();

    string CompanyName = string.Empty, Company_Add = string.Empty, Logo = string.Empty, Sign = string.Empty, Bill_Type = string.Empty, QR_Image = string.Empty
         , Company_Add_2 = string.Empty, Company_Lic = string.Empty, Bank_Details = string.Empty
         , GSTN_ID = string.Empty, PAN_NO = string.Empty, STATE_NAME = string.Empty, CIN = string.Empty
         , QRImage_path = string.Empty, User_Id = string.Empty, Remarks = string.Empty, ServiceTaxno = string.Empty, Seal = string.Empty
         , Reg_Sez = string.Empty, Signature = string.Empty;
         
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
        dss = SR.Select_Inv(ObjUBO);
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

                if (Company_Lic == "eri00001") 
                {
                    ObjUBO.A9 = "GST_BILL_JOB_RPT_RTS";
                    load_Eri00001();
                }
                else if (Company_Lic == "eri00744")
                {
                    //ObjUBO.A9 = "ACC_GST_BILL_JOB_RPT_SUNGLOBAL_LOGISTICS"; 10-may-2025)
                    ObjUBO.A9 = "ACC_GST_BILL_JOB_RPT_SGL";
                    load_Eri00744();
                    Annexure_Chk();
                }
                else if (Company_Lic == "eri02360" || Company_Lic == "eri02563")
                {
                    ObjUBO.A9 = "GST_BILL_JOB_RPT_INSOORYA";
                    load_Eri02360();
                }
                else if (Company_Lic == "eri00002")
                {
                    ObjUBO.A9 = "ACC_GST_BILL_JOB_RPT_ORIENTAL";
                    load_eri00002();
                }
                else if (Company_Lic == "eri03196")
                {
                    ObjUBO.A9 = "ACC_GST_BILL_JOB_RPT_SHIVNERI";
                    load_eri03196();
                }
                else if (Company_Lic == "eri00576")
                {
                    ObjUBO.A9 = "ACC_GST_BILL_JOB_RPT_GROUP_A";
                    load_eri00576();
                }
                else if (Company_Lic == "eri00599")
                {
                    ObjUBO.A9 = "GST_BILL_JOB_RPT_JSV";
                    load_Eri00599();
                }
                else if (Company_Lic == "eri02349") 
                {
                    ObjUBO.A9 = "GST_BILL_JOB_RPT_TBSL";
                    load_Eri02349();
                }
                else if (Company_Lic == "eri03209")
                {
                    ObjUBO.A9 = "ACC_GST_BILL_JOB_RPT_ASJ";
                    load_Eri03209();
                }
                /*
                else if (Company_Lic == "eri00293")
                {
                    ObjUBO.A9 = "GST_BILL_JOB_RPT_PARAMOUNT_IMP_EXP";
                    load_ERI00293();
                }*/
                else if (Company_Lic == "eri00293" || Company_Lic == "eri00408")
                {
                    ObjUBO.A9 = "ACC_GST_BILL_JOB_RPT_PARAMOUNT";
                    load_eri00293();
                    Annexure_Chk();
                }
                else if (Company_Lic == "eri03004")
                {
                    ObjUBO.A9 = "ACC_GST_BILL_JOB_RPT_JAAGRUTHI";
                    load_Eri03004();
                }
                else if (Company_Lic == "eri00480")
                {
                    ObjUBO.A9 = "ACC_GST_BILL_JOB_RPT_SANCO_480";
                    load_Eri00480();
                }
                else if (Company_Lic == "eri01019")
                {
                    ObjUBO.A9 = "ACC_GST_BILL_JOB_RPT_SANCO";
                    load_Eri00480();
                }
                else if (Company_Lic == "eri01176" || Company_Lic == "eri01277")
                {
                    ObjUBO.A9 = "ACC_GST_BILL_JOB_RPT_SANCO";
                    load_ERI01176();
                }
                else if (Company_Lic == "eri01011" || Company_Lic == "eri01280")
                {
                    ObjUBO.A9 = "ACC_GST_BILL_JOB_RPT_SANCO";
                    load_ERI01011();
                }
                else if (Company_Lic == "eri01698")
                {
                    ObjUBO.A9 = "GST_BILL_JOB_RPT_SHS";
                    load_Eri01698();
                }
                else if (Company_Lic == "eri03267")
                {
                    ObjUBO.A9 = "ACC_GST_BILL_JOB_RPT_KPS";
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
        Sign = " ";
        ReportViewer1.LocalReport.EnableExternalImages = true;
        dss = SR.Invoice_Job_Rpt_data(ObjUBO);
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
                    if (dss.Tables[0].Rows[0]["REG_SEZ"].ToString() == "S")
                    {
                        Reg_Sez = "(SUPPLY TO SEZ UNIT OR SEZ DEVELOPER FOR AUTHORISED OPERATIONS UNDER BOND OR LETTER OF UNDERTAKING WITHOUT PAYMENT OF INTEGRATED TAX)";
                    }
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
                    if (dss.Tables[0].Rows[0]["REG_SEZ"].ToString() == "S")
                    {
                        Reg_Sez = "(SUPPLY TO SEZ UNIT OR SEZ DEVELOPER FOR AUTHORISED OPERATIONS UNDER BOND OR LETTER OF UNDERTAKING WITHOUT PAYMENT OF INTEGRATED TAX)";
                    }
                }
            }
        }
        ReportViewer1.LocalReport.DisplayName = "INV " + ddl_Inv_No.SelectedValue.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        ReportParameter p1 = new ReportParameter("Company_Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Company_Add", Company_Add);
        ReportParameter p3 = new ReportParameter("Bill_Type", Bill_Type);
        ReportParameter p4 = new ReportParameter("QR_Image", QR_Image);
        ReportParameter p5 = new ReportParameter("Logo", Logo);
        ReportParameter p6 = new ReportParameter("Company_Sign", Sign);
        ReportParameter p7 = new ReportParameter("Reg_Sez", Reg_Sez);

        ReportParameter p8 = new ReportParameter("GSTN_ID", GSTN_ID);
        ReportParameter p9 = new ReportParameter("PAN_NO", PAN_NO);
        ReportParameter p10 = new ReportParameter("STATE_NAME", STATE_NAME);
        ReportParameter p11 = new ReportParameter("CIN", CIN);

        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p6, p7, p8, p9, p10, p11 };
        ReportViewer1.LocalReport.SetParameters(p);
        Report_Print();
    }
    private void load_ERI01011()
    {
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;
        CompanyName = "Sanco Trans Limited";
        Company_Add = "No.68, MTR Complex -3rd Floor,Outer Ring Road," +
                               "\r\n" +
                               "B.Channasandra, Kasturi Nagar," +
                                "\r\n" +
                               "Bangalore - 560043, Karnataka" +
                                "\r\n" +
                               "Tel. No.-9538892200 Email -blr@sancotrans.com";



        GSTN_ID = "GSTNIN : 29AAACS7690F1Z0";
        PAN_NO = "PAN No : AAACS7690F";
        STATE_NAME = "State : [29] KARNATAKA"; 
        CIN = "CIN : L60220TN1979PLC007970";


        Logo = new Uri(Server.MapPath("~/images/Company_Logo/Acc_Sanco.png")).AbsoluteUri;
        //Sign = new Uri(Server.MapPath("~/images/Company_Logo/Jaagruthi_Logistics_Sign.jpg")).AbsoluteUri;
        Sign = " ";
        ReportViewer1.LocalReport.EnableExternalImages = true;
        dss = SR.Invoice_Job_Rpt_data(ObjUBO);
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
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/Acc_GST_Bill_Job_rpt_Sanco_TL.rdlc";
                }
                else
                {
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/Acc_GST_Bill_Job_rpt_Sanco_E_TL.rdlc";
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
                    if (dss.Tables[0].Rows[0]["REG_SEZ"].ToString() == "S")
                    {
                        Reg_Sez = "(SUPPLY TO SEZ UNIT OR SEZ DEVELOPER FOR AUTHORISED OPERATIONS UNDER BOND OR LETTER OF UNDERTAKING WITHOUT PAYMENT OF INTEGRATED TAX)";
                    }
                }
            }
            else
            {
                if (dss.Tables[0].Rows[0]["IMP_EXP"].ToString() == "I")
                {
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/Acc_GST_Bill_Job_rpt_Sanco_TO.rdlc";
                }
                else
                {
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/Acc_GST_Bill_Job_rpt_Sanco_E_TO.rdlc";
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
                    if (dss.Tables[0].Rows[0]["REG_SEZ"].ToString() == "S")
                    {
                        Reg_Sez = "(SUPPLY TO SEZ UNIT OR SEZ DEVELOPER FOR AUTHORISED OPERATIONS UNDER BOND OR LETTER OF UNDERTAKING WITHOUT PAYMENT OF INTEGRATED TAX)";
                    }
                }
            }
        }
        ReportViewer1.LocalReport.DisplayName = "INV " + ddl_Inv_No.SelectedValue.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        ReportParameter p1 = new ReportParameter("Company_Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Company_Add", Company_Add);
        ReportParameter p3 = new ReportParameter("Bill_Type", Bill_Type);
        ReportParameter p4 = new ReportParameter("QR_Image", QR_Image);
        ReportParameter p5 = new ReportParameter("Logo", Logo);
        ReportParameter p6 = new ReportParameter("Company_Sign", Sign);
        ReportParameter p7 = new ReportParameter("Reg_Sez", Reg_Sez);

        ReportParameter p8 = new ReportParameter("GSTN_ID", GSTN_ID);
        ReportParameter p9 = new ReportParameter("PAN_NO", PAN_NO);
        ReportParameter p10 = new ReportParameter("STATE_NAME", STATE_NAME);
        ReportParameter p11 = new ReportParameter("CIN", CIN);

        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p6, p7, p8, p9, p10, p11 };
      
        ReportViewer1.LocalReport.SetParameters(p);
        Report_Print();
    }

    private void load_ERI01176()
    {
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;
        CompanyName = "Sanco Trans Limited";
        Company_Add = "5B / 6, Karumattampatti –Annur Main Road," +
                               "\r\n" +
                               "K.Rayarpalayam, Karumattampatti," +
                                "\r\n" +
                               "Coimbatore - 641659,TAMILNADU" +
                                "\r\n" +
                               "Tel. No.-9444445283 Email -sfd.cbe@sancotrans.com";

        GSTN_ID = "GSTNIN : 33AAACS7690F1ZB";
        PAN_NO = "PAN No : AAACS7690F";
        STATE_NAME = "State : [33] TAMILNADU";
        CIN = "CIN : L60220TN1979PLC007970";


        Logo = new Uri(Server.MapPath("~/images/Company_Logo/Acc_Sanco.png")).AbsoluteUri;
        //Sign = new Uri(Server.MapPath("~/images/Company_Logo/Jaagruthi_Logistics_Sign.jpg")).AbsoluteUri;
        Sign = " ";
        ReportViewer1.LocalReport.EnableExternalImages = true;
        dss = SR.Invoice_Job_Rpt_data(ObjUBO);
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
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/Acc_GST_Bill_Job_rpt_Sanco_TL.rdlc";
                }
                else
                {
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/Acc_GST_Bill_Job_rpt_Sanco_E_TL.rdlc";
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
                    if (dss.Tables[0].Rows[0]["REG_SEZ"].ToString() == "S")
                    {
                        Reg_Sez = "(SUPPLY TO SEZ UNIT OR SEZ DEVELOPER FOR AUTHORISED OPERATIONS UNDER BOND OR LETTER OF UNDERTAKING WITHOUT PAYMENT OF INTEGRATED TAX)";
                    }
                }
            }
            else
            {
                if (dss.Tables[0].Rows[0]["IMP_EXP"].ToString() == "I")
                {
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/Acc_GST_Bill_Job_rpt_Sanco_TO.rdlc";
                }
                else
                {
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/Acc_GST_Bill_Job_rpt_Sanco_E_TO.rdlc";
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
                    if (dss.Tables[0].Rows[0]["REG_SEZ"].ToString() == "S")
                    {
                        Reg_Sez = "(SUPPLY TO SEZ UNIT OR SEZ DEVELOPER FOR AUTHORISED OPERATIONS UNDER BOND OR LETTER OF UNDERTAKING WITHOUT PAYMENT OF INTEGRATED TAX)";
                    }
                }
            }
        }
        ReportViewer1.LocalReport.DisplayName = "INV " + ddl_Inv_No.SelectedValue.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        ReportParameter p1 = new ReportParameter("Company_Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Company_Add", Company_Add);
        ReportParameter p3 = new ReportParameter("Bill_Type", Bill_Type);
        ReportParameter p4 = new ReportParameter("QR_Image", QR_Image);
        ReportParameter p5 = new ReportParameter("Logo", Logo);
        ReportParameter p6 = new ReportParameter("Company_Sign", Sign);
        ReportParameter p7 = new ReportParameter("Reg_Sez", Reg_Sez);


        ReportParameter p8 = new ReportParameter("GSTN_ID", GSTN_ID);
        ReportParameter p9 = new ReportParameter("PAN_NO", PAN_NO);
        ReportParameter p10 = new ReportParameter("STATE_NAME", STATE_NAME);
        ReportParameter p11 = new ReportParameter("CIN", CIN);

        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p6, p7, p8, p9, p10, p11 };
        ReportViewer1.LocalReport.SetParameters(p);
        Report_Print();
    }

    private void load_Eri00480()
    {
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;
        CompanyName = "Sanco Trans Limited";
        Company_Add = "ST Tower, New No.24 & 25,Second Line Beach Road," +
                               "\r\n" +
                               "Chennai - 600001,TAMILNADU" +
                                "\r\n" +
                               "Tel. No.-9444400252 Email -sfd.billing@sancotrans.com";

        GSTN_ID = "GSTNIN : 33AAACS7690F1ZB";
        PAN_NO = "PAN No : AAACS7690F";
        STATE_NAME = "State : [33] TAMILNADU";
        CIN = "CIN : L60220TN1979PLC007970";


        Logo = new Uri(Server.MapPath("~/images/Company_Logo/Acc_Sanco.png")).AbsoluteUri;
        //Sign = new Uri(Server.MapPath("~/images/Company_Logo/Jaagruthi_Logistics_Sign.jpg")).AbsoluteUri;
        Sign = " ";
        ReportViewer1.LocalReport.EnableExternalImages = true;
        dss = SR.Invoice_Job_Rpt_data(ObjUBO);
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
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/Acc_GST_Bill_Job_rpt_Sanco_TL.rdlc"; 
                }
                else
                {
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/Acc_GST_Bill_Job_rpt_Sanco_E_TL.rdlc";
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
                    if (dss.Tables[0].Rows[0]["REG_SEZ"].ToString() == "S")
                    {
                        Reg_Sez = "(SUPPLY TO SEZ UNIT OR SEZ DEVELOPER FOR AUTHORISED OPERATIONS UNDER BOND OR LETTER OF UNDERTAKING WITHOUT PAYMENT OF INTEGRATED TAX)";
                    }
                }
            }
            else
            {
                if (dss.Tables[0].Rows[0]["IMP_EXP"].ToString() == "I")
                {
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/Acc_GST_Bill_Job_rpt_Sanco_TO.rdlc";
                }
                else
                {
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/Acc_GST_Bill_Job_rpt_Sanco_E_TO.rdlc";
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
                    if (dss.Tables[0].Rows[0]["REG_SEZ"].ToString() == "S")
                    {
                        Reg_Sez = "(SUPPLY TO SEZ UNIT OR SEZ DEVELOPER FOR AUTHORISED OPERATIONS UNDER BOND OR LETTER OF UNDERTAKING WITHOUT PAYMENT OF INTEGRATED TAX)";
                    }
                }
            }
        }
        ReportViewer1.LocalReport.DisplayName = "INV " + ddl_Inv_No.SelectedValue.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        ReportParameter p1 = new ReportParameter("Company_Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Company_Add", Company_Add);
        ReportParameter p3 = new ReportParameter("Bill_Type", Bill_Type);
        ReportParameter p4 = new ReportParameter("QR_Image", QR_Image);
        ReportParameter p5 = new ReportParameter("Logo", Logo);
        ReportParameter p6 = new ReportParameter("Company_Sign", Sign);
        ReportParameter p7 = new ReportParameter("Reg_Sez", Reg_Sez);

        ReportParameter p8 = new ReportParameter("GSTN_ID", GSTN_ID);
        ReportParameter p9 = new ReportParameter("PAN_NO", PAN_NO);
        ReportParameter p10 = new ReportParameter("STATE_NAME", STATE_NAME);
        ReportParameter p11 = new ReportParameter("CIN", CIN);

        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p6, p7, p8, p9, p10, p11 };
        ReportViewer1.LocalReport.SetParameters(p);
        Report_Print();
    }
    private void load_Eri03004()
    {
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;
        CompanyName = "JAAGRUTHI LOGISTICS PVT LTD";
        Company_Add = "Plot No. 122 & 123, 5th Floor, Krishna Building," +
                               "\r\n" +
                               "Diamond Hills, Lumbini Avenue," +
                                "\r\n" +
                                "Gachibowli, Hyderabad - 500032.";

        GSTN_ID = "GSTNIN : 36AACCJ0551G1ZW";
        PAN_NO = "PAN No : AACCJ0551G";
        STATE_NAME = "State : [36] TELANGANA";
        CIN = "CIN :";

        Logo = new Uri(Server.MapPath("~/images/Company_Logo/Jaagruthi_Logistics.jpg")).AbsoluteUri;
        Sign = new Uri(Server.MapPath("~/images/Company_Logo/Jaagruthi_Logistics_Sign.jpg")).AbsoluteUri;
        ReportViewer1.LocalReport.EnableExternalImages = true;
        dss = SR.Invoice_Job_Rpt_data(ObjUBO);
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
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/Acc_GST_Bill_Job_rpt_Jaagruthi_TL.rdlc";
                }
                else
                {
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/Acc_GST_Bill_Job_rpt_Jaagruthi_E_TL.rdlc";
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
                    if (dss.Tables[0].Rows[0]["REG_SEZ"].ToString() == "S")
                    {
                        Reg_Sez = "(SUPPLY TO SEZ UNIT OR SEZ DEVELOPER FOR AUTHORISED OPERATIONS UNDER BOND OR LETTER OF UNDERTAKING WITHOUT PAYMENT OF INTEGRATED TAX)";
                    }
                }
            }
            else
            {
                if (dss.Tables[0].Rows[0]["IMP_EXP"].ToString() == "I")
                {
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/Acc_GST_Bill_Job_rpt_Jaagruthi_TO.rdlc";
                }
                else
                {
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/Acc_GST_Bill_Job_rpt_Jaagruthi_E_TO.rdlc"; 
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
                    if (dss.Tables[0].Rows[0]["REG_SEZ"].ToString() == "S")
                    {
                        Reg_Sez = "(SUPPLY TO SEZ UNIT OR SEZ DEVELOPER FOR AUTHORISED OPERATIONS UNDER BOND OR LETTER OF UNDERTAKING WITHOUT PAYMENT OF INTEGRATED TAX)";
                    }
                }
            }
        }
        ReportViewer1.LocalReport.DisplayName = "INV " + ddl_Inv_No.SelectedValue.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        ReportParameter p1 = new ReportParameter("Company_Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Company_Add", Company_Add);
        ReportParameter p3 = new ReportParameter("Bill_Type", Bill_Type);
        ReportParameter p4 = new ReportParameter("QR_Image", QR_Image);
        ReportParameter p5 = new ReportParameter("Logo", Logo);
        ReportParameter p6 = new ReportParameter("Company_Sign", Sign);
        ReportParameter p7 = new ReportParameter("Reg_Sez", Reg_Sez);


        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p6, p7 };
        ReportViewer1.LocalReport.SetParameters(p);
        Report_Print();
    }
    private void load_Eri03209()
    {
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;
        CompanyName = "ASJ SHIPPING INDIA PVT. LTD.";
        Company_Add = "House No. 34, KH No. 345-346, PP 642," +
                        "\r\n" +
                        "Shiv Nagar, New Roshan Pura," +
                        "\r\n" +
                        "Najafgarh, New Delhi - 110043.";

        Company_Add_2 = "Email : asj.shippingindiapvtltd@gmail.com" +
                                "\r\n" +
                               "Mob. No. -9999773332/9812498493" +
                                "\r\n" +
                              "Website : www.asjshippingindia.com";
        GSTN_ID = "GSTIN : 07AAZCA0141Q1Z4";
        PAN_NO = " ";
        STATE_NAME = " ";

        Logo = new Uri(Server.MapPath("~/images/Company_Logo/ASJ.png")).AbsoluteUri;
        Seal = new Uri(Server.MapPath("~/images/Company_Logo/ASJ_sign.png")).AbsoluteUri;
        ReportViewer1.LocalReport.EnableExternalImages = true;
        dss = SR.Invoice_Job_Rpt_data(ObjUBO);
        localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/Acc_GST_Bill_Job_rpt_ASJ.rdlc";

        ReportViewer1.LocalReport.EnableExternalImages = true;

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
       //ReportDataSource datasource7 = new ReportDataSource("Charge_Total", dss.Tables[7]);
       //ReportViewer1.LocalReport.DataSources.Add(datasource7);

        ReportDataSource datasource7 = new ReportDataSource("Total_Amt", dss.Tables[7]);
        ReportViewer1.LocalReport.DataSources.Add(datasource7);

        ReportDataSource datasource8 = new ReportDataSource("Gst_Total", dss.Tables[8]);
        ReportViewer1.LocalReport.DataSources.Add(datasource8);

        ReportDataSource datasource9 = new ReportDataSource("Bank", dss.Tables[9]);
        ReportViewer1.LocalReport.DataSources.Add(datasource9);

        ReportViewer1.LocalReport.DisplayName = "INV " + ddl_Inv_No.SelectedValue.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        ReportParameter p1 = new ReportParameter("Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Address", Company_Add);
        ReportParameter p3 = new ReportParameter("Address_II", Company_Add_2);
        ReportParameter p4 = new ReportParameter("GSTN_ID", GSTN_ID);
        ReportParameter p5 = new ReportParameter("Logo", Logo);
        ReportParameter p6 = new ReportParameter("Bill_Type", Bill_Type);
        ReportParameter p7 = new ReportParameter("Seal", Seal);
        ReportParameter[] p = { p1, p2, p3, p4, p5, p6 ,p7 };
        ReportViewer1.LocalReport.SetParameters(p);
        Report_Print();
        
    }
    private void load_eri03196()
    {
        Company_Add = "LICENSED CUSTOM BROKER, FREIGHT FORWARDER, SHIPPING & WAREHOUSING AGENT";

        Company_Add_2 = "NEELKANTH CORNER CHS.SHOP NO.02 PLOT NO.02, SECTORE.02, SANAPADA(E) NAVI MUMBAI - 400705." +
                                "\r\n" +
                               "Tel.: 022-31969125 / 022-65023687 E-mail : admin@shivnerilogistics.com" +
                               "\r\n" +
                               "AEO CER. NO.: INADNFS2392D0F224 UDYAM NO.: UDYAM-MH-33-0050376";

        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        dss = SR.Invoice_Job_Rpt_data(ObjUBO);

        localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/Acc_GST_Bill_Job_rpt_SHIVNERI.rdlc";
        CompanyName = "SHIVNERI LOGISTICS LLP";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/SHIVNERI.png")).AbsoluteUri;

        ReportViewer1.LocalReport.EnableExternalImages = true;

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
        
        ReportViewer1.LocalReport.DisplayName = "INV " + ddl_Inv_No.SelectedValue.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        ReportParameter p1 = new ReportParameter("Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Address", Company_Add);
        ReportParameter p3 = new ReportParameter("Address_II", Company_Add_2);
        ReportParameter p4 = new ReportParameter("Logo", Logo);
        ReportParameter p5 = new ReportParameter("Bill_Type", Bill_Type);

        ReportParameter[] p = { p1, p2, p3, p4, p5};
        ReportViewer1.LocalReport.SetParameters(p);
        Report_Print();
    }
    private void load_eri00576()
    {
        Company_Add = "301-302, Plot No. 50, Community Centre, Naraina Industrial Area Phase-I, New Delhi-110028, India" +
                               "\r\n" +
                               "Tel No : +91 11 25895463 Email :admin@groupalogistics.com www.groupalogistics.com" +
                               "\r\n" +
                               "GSTIN : 07AADCG9923A1ZT CIN:U63090DL2010PTC209884";

        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        dss = SR.Invoice_Job_Rpt_data(ObjUBO);

        localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/Acc_GST_Bill_Job_rpt_Group_A.rdlc";
        CompanyName = "Group A Logistics India Pvt Ltd";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/GROUP_A.png")).AbsoluteUri;

        ReportViewer1.LocalReport.EnableExternalImages = true;


        ReportDataSource datasource = new ReportDataSource("General", dss.Tables[0]);
        ReportViewer1.LocalReport.DataSources.Add(datasource);
        ReportDataSource datasource1 = new ReportDataSource("Charge", dss.Tables[1]);
        ReportViewer1.LocalReport.DataSources.Add(datasource1);
        ReportDataSource datasource2 = new ReportDataSource("Charge_Total", dss.Tables[2]);
        ReportViewer1.LocalReport.DataSources.Add(datasource2);

        ReportViewer1.LocalReport.DisplayName = "INV " + ddl_Inv_No.SelectedValue.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        ReportParameter p1 = new ReportParameter("Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Address", Company_Add);
        ReportParameter p3 = new ReportParameter("ServiceTaxno", " ");
        ReportParameter p4 = new ReportParameter("Remarks", "  ");
        ReportParameter p5 = new ReportParameter("Logo", Logo);
        ReportParameter p6 = new ReportParameter("TaxMode", " ");
        ReportParameter p7 = new ReportParameter("Pan_No", " ");
        ReportParameter p8 = new ReportParameter("STATE_NAME", " ");

        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8 };
        ReportViewer1.LocalReport.SetParameters(p);
        Report_Print();
    }
    private void load_eri00002()
    {
        Company_Add = "1/22 B, M.K.N  ROAD, ALANDUR," +
                               "\r\n" +
                               "CHENNAI-600016." +
                               "\r\n" +
                               "PHONE NO: 044 - 2231 2513,2231 2516" +
                               "\r\n" +
                                "EMAIL :osca@oscalogistics.com" +
                               "\r\n" +
                               "WEBSITE : www.oscalogistics.com" +
                               "\r\n" +
                               "PAN: AAACO0422F" +
                               "\r\n" +
                               "CIN:U6303TN1986PTC012905";
        
        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        dss = SR.Invoice_Job_Rpt_data(ObjUBO);
        
        localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/Acc_GST_Bill_Job_rpt_ORIENTAL.rdlc";
        CompanyName = "ORIENTAL SHIPPING & CLEARING AGENCY PVT. LTD";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/oriental.png")).AbsoluteUri;

        ReportViewer1.LocalReport.EnableExternalImages = true;

        
            ReportDataSource datasource = new ReportDataSource("General", dss.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            ReportDataSource datasource1 = new ReportDataSource("Charge", dss.Tables[1]);
            ReportViewer1.LocalReport.DataSources.Add(datasource1);
            ReportDataSource datasource2 = new ReportDataSource("Charge_Total", dss.Tables[2]);
            ReportViewer1.LocalReport.DataSources.Add(datasource2);

            ReportViewer1.LocalReport.DisplayName = "INV " + ddl_Inv_No.SelectedValue.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
            ReportParameter p1 = new ReportParameter("Name", CompanyName);
            ReportParameter p2 = new ReportParameter("Address", Company_Add);
            ReportParameter p3 = new ReportParameter("ServiceTaxno", " ");
            ReportParameter p4 = new ReportParameter("Remarks", "  ");
            ReportParameter p5 = new ReportParameter("Logo", Logo);
            ReportParameter p6 = new ReportParameter("TaxMode", " ");
            ReportParameter p7 = new ReportParameter("Pan_No", " ");
            ReportParameter p8 = new ReportParameter("STATE_NAME", " ");
            
            ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8 };
            ReportViewer1.LocalReport.SetParameters(p);
            Report_Print();

        
        /*
        List<ReportParameter> paramList = new List<ReportParameter>();
        this.ReportViewer1.LocalReport.SetParameters(paramList);
        ReportViewer1.LocalReport.DataSources.Clear();

        ReportDataSource datasource = new ReportDataSource("General", dss.Tables[0]);
        ReportViewer1.LocalReport.DataSources.Add(datasource);
        ReportDataSource datasource1 = new ReportDataSource("Charge", dss.Tables[1]);
        ReportViewer1.LocalReport.DataSources.Add(datasource1);
        ReportDataSource datasource2 = new ReportDataSource("Charge_Total", dss.Tables[2]);
        ReportViewer1.LocalReport.DataSources.Add(datasource2);
        ReportViewer1.LocalReport.DisplayName =  ddl_Inv_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        Remarks = dss.Tables[0].Rows[0]["REMARKS"].ToString();
        STATE_NAME = dss.Tables[0].Rows[0]["STATE_NAME"].ToString();

        ReportParameter p1 = new ReportParameter("Name", CompanyName);
        
        ReportParameter p2 = new ReportParameter("Address", Company_Add);
        ReportParameter p3 = new ReportParameter("ServiceTaxno", ServiceTaxno);
        ReportParameter p4 = new ReportParameter("Remarks", Remarks);
        ReportParameter p5 = new ReportParameter("Logo", Logo);
        ReportParameter p6 = new ReportParameter("TaxMode", TaxMode);
        ReportParameter p7 = new ReportParameter("Pan_No", PAN_NO);
        ReportParameter p8 = new ReportParameter("STATE_NAME", STATE_NAME);
        */
    }
    private void load_eri00293()
    {
        CompanyName = "Paramount Shipping Services Pvt Ltd";
        Company_Add = "163, Thambuchetty Street, III Floor, Chennai-1," +
                        "\r\n" +
                            "GSTIN : 33AAECP5649R1ZQ" +
                            "\r\n" +
                            "Phone No: 42248888,4206 1130,35" +
                          "\r\n" +
                            "WEBSITE : www.paramountship.com";
                           
        Company_Add_2 = "PAN No : AAECP5649R CIN NO : U63090TN2008PTC066600";


        Logo = new Uri(Server.MapPath("~/images/Company_Logo/paramount.PNG")).AbsoluteUri;
        ReportViewer1.LocalReport.EnableExternalImages = true;

        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        dss = SR.Invoice_Job_Rpt_data(ObjUBO);

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
            Bank_Details = dss.Tables[0].Rows[0]["BANK_DETAILS"].ToString();
            if (dss.Tables[0].Rows[0]["Tax_Type"].ToString() == "T")
            {
                if (dss.Tables[0].Rows[0]["LOCAL_OTHER"].ToString() == "L")
                {
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/GST_Bill_Job_rpt_PARAMOUNT_TL.rdlc";
                }
                else if (dss.Tables[0].Rows[0]["LOCAL_OTHER"].ToString() == "O")
                {
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/GST_Bill_Job_rpt_PARAMOUNT_TO.rdlc";
                }

                List<ReportParameter> paramList = new List<ReportParameter>();
                this.ReportViewer1.LocalReport.SetParameters(paramList);
                ReportViewer1.LocalReport.DataSources.Clear();

                ReportDataSource datasource = new ReportDataSource("Home", dss.Tables[0]);
                ReportViewer1.LocalReport.DataSources.Add(datasource);

                ReportDataSource datasource1 = new ReportDataSource("Gen", dss.Tables[1]);
                ReportViewer1.LocalReport.DataSources.Add(datasource1);

                ReportDataSource datasource2 = new ReportDataSource("IGM", dss.Tables[2]);
                ReportViewer1.LocalReport.DataSources.Add(datasource2);

                ReportDataSource datasource3 = new ReportDataSource("Invoice", dss.Tables[3]);
                ReportViewer1.LocalReport.DataSources.Add(datasource3);

                ReportDataSource datasource4 = new ReportDataSource("Item", dss.Tables[4]);
                ReportViewer1.LocalReport.DataSources.Add(datasource4);

                ReportDataSource datasource5 = new ReportDataSource("BE_SB_No", dss.Tables[5]);
                ReportViewer1.LocalReport.DataSources.Add(datasource5);

                ReportDataSource datasource6 = new ReportDataSource("Charge", dss.Tables[6]);
                ReportViewer1.LocalReport.DataSources.Add(datasource6);

                ReportDataSource datasource7 = new ReportDataSource("Amt_Words", dss.Tables[7]);
                ReportViewer1.LocalReport.DataSources.Add(datasource7);

                if (dss.Tables[0].Rows[0]["LOCAL_OTHER"].ToString() == "L")
                {
                    ReportDataSource datasource8 = new ReportDataSource("HSN_Tax_Rate_L", dss.Tables[8]);
                    ReportViewer1.LocalReport.DataSources.Add(datasource8);

                    ReportDataSource datasource9 = new ReportDataSource("HSN_Tax_Total_L", dss.Tables[9]);
                    ReportViewer1.LocalReport.DataSources.Add(datasource9);
                }
                else if (dss.Tables[0].Rows[0]["LOCAL_OTHER"].ToString() == "O")
                {
                    ReportDataSource datasource8 = new ReportDataSource("HSN_Tax_Rate_O", dss.Tables[8]);
                    ReportViewer1.LocalReport.DataSources.Add(datasource8);

                    ReportDataSource datasource9 = new ReportDataSource("HSN_Tax_Total_O", dss.Tables[9]);
                    ReportViewer1.LocalReport.DataSources.Add(datasource9);
                }

                if (dss.Tables[8].Rows.Count > 0)
                {
                    //Bill_Type = "DUTY INVOICE";
                    Bill_Type = "TAX INVOICE";
                }
                else
                {
                    Bill_Type = "TAX INVOICE";
                }
                Remarks = dss.Tables[0].Rows[0]["Remarks"].ToString();
            }
            else
            {
                /*
               if (dss.Tables[0].Rows[0]["Tax_Type"].ToString() == "N")
               {
                   localReport.ReportPath = @"Accounts_Invoice_Rpt/GST_Bill_Job_rpt_PARAMOUNT_NT.rdlc";
               }
               else if (dss.Tables[0].Rows[0]["Tax_Type"].ToString() == "R")
               {
                   localReport.ReportPath = @"Accounts_Invoice_Rpt/GST_Bill_Job_rpt_PARAMOUNT_RI.rdlc";
               }
               */
                localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/GST_Bill_Job_rpt_PARAMOUNT_RI.rdlc";

                List<ReportParameter> paramList = new List<ReportParameter>();
                this.ReportViewer1.LocalReport.SetParameters(paramList);
                ReportViewer1.LocalReport.DataSources.Clear();

                ReportDataSource datasource = new ReportDataSource("Home", dss.Tables[0]);
                ReportViewer1.LocalReport.DataSources.Add(datasource);

                ReportDataSource datasource1 = new ReportDataSource("Gen", dss.Tables[1]);
                ReportViewer1.LocalReport.DataSources.Add(datasource1);

                ReportDataSource datasource2 = new ReportDataSource("IGM", dss.Tables[2]);
                ReportViewer1.LocalReport.DataSources.Add(datasource2);

                ReportDataSource datasource3 = new ReportDataSource("Invoice", dss.Tables[3]);
                ReportViewer1.LocalReport.DataSources.Add(datasource3);

                ReportDataSource datasource4 = new ReportDataSource("Item", dss.Tables[4]);
                ReportViewer1.LocalReport.DataSources.Add(datasource4);

                ReportDataSource datasource5 = new ReportDataSource("BE_SB_No", dss.Tables[5]);
                ReportViewer1.LocalReport.DataSources.Add(datasource5);

                ReportDataSource datasource6 = new ReportDataSource("Charge", dss.Tables[6]);
                ReportViewer1.LocalReport.DataSources.Add(datasource6);

                ReportDataSource datasource7 = new ReportDataSource("Amt_Words", dss.Tables[7]);
                ReportViewer1.LocalReport.DataSources.Add(datasource7);

                ReportDataSource datasource8 = new ReportDataSource("Non_Re_HSN__Total", dss.Tables[8]);
                ReportViewer1.LocalReport.DataSources.Add(datasource8);

                Bill_Type = "REIMBURSEMENT INVOICE";
                Remarks = "  ";

            }
        }
        ReportViewer1.LocalReport.DisplayName = "INV " + ddl_Inv_No.SelectedValue.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        ReportParameter p1 = new ReportParameter("Company_Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Company_Add", Company_Add);
        ReportParameter p3 = new ReportParameter("Bank_Details", Bank_Details);
        ReportParameter p4 = new ReportParameter("Bill_Type", Bill_Type);
        ReportParameter p5 = new ReportParameter("User_Id", dss.Tables[0].Rows[0]["Createdby"].ToString());
        ReportParameter p6 = new ReportParameter("Company_Add_II", Company_Add_2);
        ReportParameter p7 = new ReportParameter("Remarks", Remarks);
        ReportParameter p8 = new ReportParameter("QR_Image", QR_Image);
        ReportParameter p9 = new ReportParameter("Logo", Logo);

        ReportParameter p10 = new ReportParameter("ACKNO", "ACKNO :" + dss.Tables[0].Rows[0]["ACKNO"].ToString());
        ReportParameter p11 = new ReportParameter("ACKDT", "ACKDT :" + dss.Tables[0].Rows[0]["Ack_Date"].ToString());
        ReportParameter p12 = new ReportParameter("IRNNO", "IRNNO :" + dss.Tables[0].Rows[0]["IRN_NO"].ToString());
        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12 };
        ReportViewer1.LocalReport.SetParameters(p);
        Report_Print();
    }
    private void load_Eri01698()
    {
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;
        CompanyName = "SHIVAM SHIPPING";

        Company_Add = "No. 101/32, Al Jannathu Building, 4th Floor, Armenian," +
                               "\r\n" +
                               "Street, Chennai-600001" +
                                "\r\n" +
                            "Email: shivamshippingjk@gmail.com" +
                                "\r\n" +
                            "Phone No: 9238207565";

        GSTN_ID = "GSTNIN : 33BBIPJ58731ZC";
        PAN_NO = " ";
        STATE_NAME = "State : [33] TAMILNADU";
        CIN = "CIN :";

        Logo = new Uri(Server.MapPath("~/images/Company_Logo/shivam_Logo.PNG")).AbsoluteUri;
        Signature = new Uri(Server.MapPath("~/images/Company_Logo/Shivam_Signature.JPG")).AbsoluteUri;
        ReportViewer1.LocalReport.EnableExternalImages = true;
        dss = SR.Invoice_Job_Rpt_data(ObjUBO);
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
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/GST_Bill_Job_rpt_SH_TL.rdlc";
                }
                else
                {
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/GST_Bill_Job_rpt_SH_E_TL.rdlc";
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
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/GST_Bill_Job_rpt_SH_TO.rdlc";
                }
                else
                {
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/GST_Bill_Job_rpt_SH_E_TO.rdlc";
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
        ReportParameter p6 = new ReportParameter("Signature", Signature);
        ReportParameter p7 = new ReportParameter("GSTN_ID", GSTN_ID);
        ReportParameter p8 = new ReportParameter("PAN_NO", PAN_NO);
        ReportParameter p9 = new ReportParameter("STATE_NAME", STATE_NAME);
        ReportParameter p10 = new ReportParameter("CIN", CIN);
        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 };
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
        dss = SR.Invoice_Job_Rpt_data(ObjUBO);
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
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/GST_Bill_Job_rpt_TBSL_TL.rdlc";
                }
                else
                {
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/GST_Bill_Job_rpt_TBSL_E_TL.rdlc";
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
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/GST_Bill_Job_rpt_TBSL_TO.rdlc";
                }
                else
                {
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/GST_Bill_Job_rpt_TBSL_E_TO.rdlc";
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
    private void load_Eri00001()
    {
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;
        CompanyName = "TRUE BLUE SHIPPING & LOGISTICS";

        Company_Add = "No: 5/41, Balaji Nagar," +
                               "\r\n" +
                               "5th Cross Street, Ekkattuthangal," +
                               "\r\n" +
                               "Chennai - 600 032" +
                               "\r\n" +
                               "GSTIN/UIN: 33AAQFT5445C1Z5" +
                               "\r\n" +
                               "State Name : Tamil Nadu, Code : 33";

        Logo = new Uri(Server.MapPath("~/images/Company_Logo/ROYAL.jpg")).AbsoluteUri;
        ReportViewer1.LocalReport.EnableExternalImages = true;
        dss = SR.Invoice_Job_Rpt_data(ObjUBO);
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
                localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/GST_Bill_Job_rpt_RTS_TL.rdlc";
            }
            else
            {
                localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/GST_Bill_Job_rpt_RTS_TO.rdlc";
            }

            List<ReportParameter> paramList = new List<ReportParameter>();
            this.ReportViewer1.LocalReport.SetParameters(paramList);
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource datasource = new ReportDataSource("HOME", dss.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            ReportDataSource datasource1 = new ReportDataSource("GENERAL", dss.Tables[1]);
            ReportViewer1.LocalReport.DataSources.Add(datasource1);
            ReportDataSource datasource2 = new ReportDataSource("IGM", dss.Tables[2]);
            ReportViewer1.LocalReport.DataSources.Add(datasource2);
            ReportDataSource datasource3 = new ReportDataSource("INVOICE", dss.Tables[3]);
            ReportViewer1.LocalReport.DataSources.Add(datasource3);
            ReportDataSource datasource4 = new ReportDataSource("ITEM", dss.Tables[4]);
            ReportViewer1.LocalReport.DataSources.Add(datasource4);
            ReportDataSource datasource5 = new ReportDataSource("BE_SB", dss.Tables[5]);
            ReportViewer1.LocalReport.DataSources.Add(datasource5);
            ReportDataSource datasource6 = new ReportDataSource("Charge", dss.Tables[6]);
            ReportViewer1.LocalReport.DataSources.Add(datasource6);

            ReportDataSource datasource7 = new ReportDataSource("GST_Total", dss.Tables[7]);
            ReportViewer1.LocalReport.DataSources.Add(datasource7);
            ReportDataSource datasource8 = new ReportDataSource("HSN_Charge", dss.Tables[8]);
            ReportViewer1.LocalReport.DataSources.Add(datasource8);


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
    }
    private void load_Eri00599()
    {
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;
        CompanyName = "JSV FREIGHT LOGISTICS";

        Company_Add = "Marine Tower,3rd Floor," +
                               "\r\n" +
                               "Old No:45,New No:89,Thambu Chetty Street" +
                               "\r\n" +
                               "Chennai - 600 001" +
                               "\r\n" +
                               "UDYAM : UDYAM-TN-02-0126970 (Small)" +
                               "\r\n" +
                               "GSTIN/UIN: 33AAPFJ5282Q1ZK" +
                               "\r\n" +
                               "State Name : Tamil Nadu, Code : 33" +
                               "\r\n" +
                               "E-Mail : admin@jsvfreight.in";

        Logo = new Uri(Server.MapPath("~/images/Company_Logo/JSV_Freight.jpeg")).AbsoluteUri;
        ReportViewer1.LocalReport.EnableExternalImages = true;
        dss = SR.Invoice_Job_Rpt_data(ObjUBO);
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
                localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/GST_Bill_Job_rpt_JSV_TL.rdlc";

            }
            else
            {
                localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/GST_Bill_Job_rpt_JSV_TO.rdlc";
            }

            List<ReportParameter> paramList = new List<ReportParameter>();
            this.ReportViewer1.LocalReport.SetParameters(paramList);
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource datasource = new ReportDataSource("HOME", dss.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            ReportDataSource datasource1 = new ReportDataSource("GENERAL", dss.Tables[1]);
            ReportViewer1.LocalReport.DataSources.Add(datasource1);
            ReportDataSource datasource2 = new ReportDataSource("IGM", dss.Tables[2]);
            ReportViewer1.LocalReport.DataSources.Add(datasource2);
            ReportDataSource datasource3 = new ReportDataSource("INVOICE", dss.Tables[3]);
            ReportViewer1.LocalReport.DataSources.Add(datasource3);
            ReportDataSource datasource4 = new ReportDataSource("ITEM", dss.Tables[4]);
            ReportViewer1.LocalReport.DataSources.Add(datasource4);
            ReportDataSource datasource5 = new ReportDataSource("BE_SB", dss.Tables[5]);
            ReportViewer1.LocalReport.DataSources.Add(datasource5);
            ReportDataSource datasource6 = new ReportDataSource("Charge", dss.Tables[6]);
            ReportViewer1.LocalReport.DataSources.Add(datasource6);

            ReportDataSource datasource7 = new ReportDataSource("GST_Total", dss.Tables[7]);
            ReportViewer1.LocalReport.DataSources.Add(datasource7);
            ReportDataSource datasource8 = new ReportDataSource("HSN_Charge", dss.Tables[8]);
            ReportViewer1.LocalReport.DataSources.Add(datasource8);


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
        dss = SR.Invoice_Job_Rpt_data(ObjUBO);
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
                if (dss.Tables[0].Rows[0]["IMP_EXP"].ToString() == "I")
                {
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/GST_Bill_Job_rpt_Insoorya_TL.rdlc";
                }
                else
                {
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/GST_Bill_Job_rpt_Insoorya_E_TL.rdlc";
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

                Bill_Type = "TAX INVOICE";
            }
            else
            {
                if (dss.Tables[0].Rows[0]["IMP_EXP"].ToString() == "I")
                {
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/GST_Bill_Job_rpt_Insoorya_TO.rdlc";
                }
                else
                {
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/GST_Bill_Job_rpt_Insoorya_E_TO.rdlc";
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

                Bill_Type = "TAX INVOICE";
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
    private void load_Eri00744()
    {
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;
        CompanyName = "SUN GLOBAL LOGISTICS PRIVATE LIMITED";

        string Br_Name = string.Empty;
        Br_Name = Connection.Current_Branch().ToLower();

        Company_Add = "Survey No, 742,  Kattrambakkam, North Avenue Road," +
        "\r\n" +
        "(Sipcot Irungattukottai), Sriperumbudur - 602 117." +
        "\r\n" +
        "Tel : 044 - 45969696  Fax : 25393294 E-mail : acc@sunglobal.in";

        GSTN_ID = "GSTIN : 33AAFCS6623P1ZY";
        PAN_NO = "PAN : AAFCS6623P";
        STATE_NAME = "State : [33] TAMILNADU";
        CIN = "CIN :";

        Logo = new Uri(Server.MapPath("~/images/Company_Logo/Acc_SGL.PNG")).AbsoluteUri;
        ReportViewer1.LocalReport.EnableExternalImages = true;
        dss = SR.Invoice_Job_Rpt_data(ObjUBO);
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
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/Acc_GST_Bill_Job_rpt_SGL_TL.rdlc";
                }
                else
                {
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/Acc_GST_Bill_Job_rpt_SGL_E_TL.rdlc";
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

                Bill_Type = "TAX INVOICE";
            }
            else
            {
                if (dss.Tables[0].Rows[0]["IMP_EXP"].ToString() == "I")
                {
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/Acc_GST_Bill_Job_rpt_SGL_TO.rdlc";
                }
                else
                {
                    localReport.ReportPath = @"Accounts_Sales_Inv_Rpt/Acc_GST_Bill_Job_rpt_SGL_E_TO.rdlc";
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

                Bill_Type = "TAX INVOICE";
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
        if (ddl_Inv_No.SelectedValue.ToString() != string.Empty)
        {
            ObjUBO.A1 = ddl_Inv_No.SelectedValue.ToString();
            ds_A = SR.Ass_Gst_Annexure_Invoice_Select(ObjUBO);
            if (ds_A.Tables[0].Rows.Count > 0)
            {
                string strrptNametime = ddl_Inv_No.SelectedValue + "_" + Common_CS.Get_Timestamp();
                using (XLWorkbook wb = new XLWorkbook())
                {
                    ds_A.Tables[0].Columns.Remove("JOBNO1");
                    var worksheet = wb.Worksheets.Add(ds_A.Tables[0], strrptNametime);
                    var lastCell = worksheet.Cell(worksheet.LastRowUsed().RowNumber(), worksheet.LastColumnUsed().ColumnNumber());
                    lastCell.Style.Fill.SetBackgroundColor(XLColor.LightGreen);
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.Buffer = true;
                    HttpContext.Current.Response.Charset = "";
                    HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + strrptNametime + ".xlsx");

                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(HttpContext.Current.Response.OutputStream);
                        HttpContext.Current.Response.Flush();
                        HttpContext.Current.Response.End();
                    }
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
            ObjUBO.A4 = ddl_Inv_No.SelectedValue.ToString();
            ObjUBO.A40 = "Bill_Inv_no_Annexure_Chk";
            ss = SR.Select_Inv(ObjUBO);
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
}                                                                                                                                                                   