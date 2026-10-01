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
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

public partial class GST_Bill_Export_Job_rpt :  System.Web.UI.Page
{
    AppSession aps = new AppSession();
    GST_Exp_Invoice BI = new GST_Exp_Invoice();
    Billing_UserBO ObjUBO = new Billing_UserBO();


    string CompanyName, Company_Add, ServiceTaxno, STATE_NAME, Pan_No, Remarks, Logo, LOGO1,LOGO2, Bank_Name, Bank_Branch, ACCTYPE, ACCNO, IFSC, Advance_amt, Balanced_amt, Company_Lic = string.Empty, Inwords = string.Empty, Current_Branch = string.Empty, Current_Group = string.Empty;

    //QRCode_to_Image Start
    QRCode_to_Image_Request QRCI = new QRCode_to_Image_Request();
    string phy_path = string.Empty;
    string QRImage_path = string.Empty;
    string QR_Image = string.Empty;
    //public string InvoiceNo { get; set; }
    //public string Data { get; set; }
    //QRCode_to_Image End
   
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();
        Current_Branch = Connection.Current_Branch();
        Current_Group = Connection.Current_Group();

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
                    lblmsg.Text = "GST Export Bill";
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

            if (Company_Lic == "eri00001" || Company_Lic == "eri02099")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_eROYAL_COMMON";
                load_eri00001();
            }
            else if (Company_Lic == "eri00002")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_ORIENTAL";
                load_eri00002();
            }
            else if (Company_Lic.ToLower() == "eri00004" ) 
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_e_ROYAL_BRANCH";
                load_eri00004();
            }
            else if (Company_Lic == "eri00945")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_INBA";
                load_eri00945();
            }
            else if (Company_Lic == "eri00132")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_SHRINATH";
                load_eri00132();
            }
            else if (Company_Lic == "eri00141")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_AREN_SHIPPING";
                load_eri00141();
            }
            else if (Company_Lic == "eri00775")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_PRATHYUN";
                load_eri00775();
            }
            else if (Company_Lic == "eri00145")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_BCM";
                load_eri00145();
            }
            else if (  Company_Lic.ToLower() == "eri00146" )
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_BWC";
                load_eri00146();
            }
            else if (Company_Lic == "eri00155")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_HARTRODT";
                load_eri00155();
            }
            else if (Company_Lic == "eri00188")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_KSQUARE_MUMBAI";
                load_eri00188();
            }
            else if (Company_Lic == "eri00244")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_DENKEN";
                load_eri00244();
            }
            else if (Company_Lic == "eri01186")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_DENKEN_BLR";
                load_eri01186();
            }
            else if (Company_Lic == "eri00265")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_ATLANTIC"; //Same as PRATHYUN & TRAXON, NS
                load_eri00265();
            }
            else if (Company_Lic == "eri00268")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_VSM";
                load_eri00268();
            }
            else if (Company_Lic.ToLower() == "eri00287")
            {
                ObjUBO.Sp_Name ="GST_BILL_EXPORT_JOB_RPT_FALCONAIR";
                load_eri00287();
            }
            else if (Company_Lic.ToLower() == "eri00314" )
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_SABARI";
                load_eri00314();
            }
            else if (Company_Lic == "eri00353")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_ENSEN";
                load_eri00353();
            }
            else if (Company_Lic.ToLower() == "eri00354")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_LKS";
                load_eri00354();
            }
            else if (Company_Lic.ToLower() == "eri00375")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_SUBRAMANY_LOG";
                load_eri00375();
            }
            else if (Company_Lic == "eri00381" )
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_PIONEER";
                load_eri00381();
            }
            else if (Company_Lic == "eri00382" )
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_ACFA";
                load_eri00382();
            }           
            else if (Company_Lic.ToLower() == "eri00384")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_PK";
                load_eri00384();
            }
            else if (Company_Lic == "eri00399") //Same as Prathyun
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_PAS";
                load_eri00399();
            }
            else if (Company_Lic == "eri00406")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_RKL";
                load_eri00406();
            }
            else if (Company_Lic.ToLower() == "eri00420")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_SAGAR";
                load_eri00420();
            }
            else if (Company_Lic == "eri00422")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_SYNDICATE";
                load_eri00422();
            }
            else if (Company_Lic.ToLower() == "eri00230")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_PARAMOUNT";
                load_eri00230();
            }

            else if (Company_Lic.ToLower() == "eri00350")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_PARAMOUNT";
                load_eri00350();
            }

            else if (Company_Lic.ToLower() == "eri00408")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_PARAMOUNT";
                load_eri00408();
            }
            else if (Company_Lic == "eri00427")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_AS_VASAN";
                load_eri00427();
            }
            else if (Company_Lic == "eri00438")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_SYNERGY_GLOBAL";
                load_eri00438();
            }
            else if (Company_Lic == "eri00464")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_RR_LOGISTICS";
                load_eri00464();
            }
            else if (Company_Lic == "eri00480")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_SANCO";
                load_eri00480();
            }
            else if (Company_Lic == "eri01176")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_SANCO_KOVAI";
                load_eri01176();
            }
            else if (Company_Lic == "eri00507")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_SGSL";
                load_eri00507();
            }
            else if (Company_Lic == "eri00510")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_TOPSWA_LOGISTICS";
                load_eri00510();
            }
            else if (Company_Lic == "eri00517")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_LIZMA_LOGISTICS_TIRUPUR";
                load_eri00517();

            }
            else if (Company_Lic == "eri01523")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_AMPLE";
                load_eri01523();
            }
            else if (Company_Lic == "eri00576")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_GROUP_A";
                load_eri00576();
            }
            else if (Company_Lic == "eri00581")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_UNIVERSAL_CLEARING";
                load_eri00581();
            }
            if (Company_Lic == "eri00588")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_SRI_BALAJI_SHIPPING";
                load_eri00588();
            }
            else if (Company_Lic == "eri00599")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_JSV";
                load_ERI00599();
            }
            else if (Company_Lic == "eri00620")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_SHIRIDI_LOGISTICS";
                load_eri00620();
            }
            else if (Company_Lic == "eri00621")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_VARUNA";
                load_eri00621();
            }
            else if (Company_Lic == "eri00653")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_KSQUARE_CHENNAI";
                load_eri00653();
            }
            else if (Company_Lic == "eri00658")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_LEO_FORWARDERZ";
                load_eri00658();
            }
            else if (Company_Lic == "eri00664")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_UNIVERSAL_CLEARING_FORWARDING";
                load_eri00664();
            }
            else if (Company_Lic == "eri00674")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_NEELAKANTH";
                load_eri00674();
            }
            else if (Company_Lic == "eri00677")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_SHIVANSH_SHIPPING_MUMBAI";
                load_eri0677();
            }
            else if (Company_Lic == "eri00704")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_JAINESH";
                load_eri00704();
            }
            else if (Company_Lic == "eri00705")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_AIR_AND_SHIPPING_CARGO";
                load_eri00705();
            }
            else if (Company_Lic == "eri00725")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_INTERNATIONAL_SHIPPING_CORPORATION";
                load_eri00725();
            }
            else if (Company_Lic == "eri00727")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_ZEN_CLEAFOR";
                load_eri00727();
            }
            else if (Company_Lic == "eri00761")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_VENJOH_LOGISTICS";
                load_eri00761();
            }
            else if (Company_Lic == "eri00779")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_SAIRAM_SHIPPING";
                load_eri00779();
            }
            else if (Company_Lic == "eri00783")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_DYNAMIC_CARGO_CARE";
                load_eri00783();
            }
            else if (Company_Lic == "eri00829")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_PRADEEP_BLR";
                load_eri00829();
            }
            else if (Company_Lic == "eri00867")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_STARCOM_LOGISTICS";
                load_eri00867();
            } 
            else if (Company_Lic == "eri01011")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_SANCO_BANG_AIR";
                load_eri01011();
            }
            else if (Company_Lic == "eri01019")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_SANCO_AIR";
                load_eri01019();
            }
            else if (Company_Lic == "eri00508" )
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_PEGASUS";
                load_eri00508();
            }
            else if (Company_Lic == "eri00511")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_VAISHNAVI";
                load_eri00511();
            }
            else if (Company_Lic == "eri00519" )
            {
             
                //Pondicherry
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_VINTAGE_PONDY";
                string Company_Add = string.Empty;


                Company_Add = "SATTVA LOGISTICS GROUP" +
                                "\r\n" +
                                       "129/4, Vazhudavoor Main Road, Thuthipet Village, VillianurCommune, Puducherry, 605502" +
                                        "\r\n" +
                                         "PONDICHERRY, INDIA, TEL: 0413-2678249";
                load_eri00519(Company_Add, "34AADCV9116C1ZK");
            }
            else if (Company_Lic == "eri00520" )
            {
                //Chennai
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_VINTAGE_PONDY";
                string Company_Add = string.Empty, GSTN_ID = string.Empty;
                Company_Add = "SATTVA LOGISTICS GROUP" +
                                "\r\n" +
                                       "HIGH GATE, Level 4, Old No.82, New No.153, Santhome High Road, Raja Annamalaipuram, Chennai-600 028." +
                                        "\r\n" +
                                         "TAMILNADU, INDIA, TEL: 044-2461 2829, 044-2461 3245";
                load_eri00519(Company_Add, "33AADCV9116C1ZM");
            }
            else if (Company_Lic == "eri00524")
            {
                //Chennai
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_VINTAGE_PONDY";
                string Company_Add = string.Empty, GSTN_ID = string.Empty;
                //Company_Add = "SATTVA LOGISTICS GROUP" +
                //                "\r\n" +
                //                       "HIGH GATE, Level 4, Old No.82, New No.153, Santhome High Road, Raja Annamalaipuram, Chennai-600 028." +
                //                        "\r\n" +
                //                         "TAMILNADU, INDIA, TEL: 044-2461 2829, 044-2461 3245";

                Company_Add = "SATTVA LOGISTICS GROUP" +
                                 "\r\n" +
                                        "GF 3, Door No 47-3-7, Roshini Palace, Nehru Bazaar Road, 5th Lane," +
                                         "\r\n" +
                                          "Dwarakanagar, Visakhapatnam, Andhrapradesh - 530016.";

                load_eri00519(Company_Add, "37AADCV9116C1ZE");
            }

            else if (Company_Lic == "eri01509")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_VINTAGE_PONDY";
                string Company_Add = string.Empty, GSTN_ID = string.Empty;
                if (Current_Group.ToUpper() == "VIZAG")
                {
                    Company_Add = "SATTVA LOGISTICS GROUP" +
                                    "\r\n" +
                                           "GF 3, Door No 47-3-7, Roshini Palace, Nehru Bazaar Road, 5th Lane," +
                                            "\r\n" +
                                             "Dwarakanagar, Visakhapatnam, Andhrapradesh - 530016.";

                    load_eri00519(Company_Add, "37AADCV9116C1ZE");

                }
                else if (Current_Group.ToUpper() == "BANGALORE")
                {
                    Company_Add = "SATTVA LOGISTICS GROUP" +
                                    "\r\n" +
                                          "Plot No 95, Part 96, Vemgal Hobli, " +
                                     "\r\n" +
                                      "Kolar Taluk, Bangaluru - 560102.";

                    //load_eri00519(Company_Add, "29AADCV9116C1ZE");
                    load_eri00519(Company_Add, "29AADCV9116C1ZB");

                }
                else if (Current_Group.ToUpper() == "PONDICHERRY")
                {
                    Company_Add = "SATTVA LOGISTICS GROUP" +
                                    "\r\n" +
                                           "129/4, Vazhudavoor Main Road, Thuthipet Village, VillianurCommune, Puducherry,INDIA,605502" +
                                        "\r\n" +
                                          "TEL: 0413-2678249";
                    load_eri00519(Company_Add, "34AADCV9116C1ZK");
                }
                else// "CHENNAI"  & Other Area are same Address
                {
                    Company_Add = "SATTVA LOGISTICS GROUP" +
                                    "\r\n" +
                                           "HIGH GATE, Level 4, Old No.82, New No.153, Santhome High Road, Raja Annamalaipuram, Chennai-600 028." +
                                            "\r\n" +
                                             "TAMILNADU, INDIA, TEL: 044-2461 2829, 044-2461 3245";
                    load_eri00519(Company_Add, "33AADCV9116C1ZM");

                }
            }

            else if (Company_Lic == "eri00561")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_RG_INTERNATIONAL";
                load_eri00561();
            }
            else if (Company_Lic == "eri00736")
            {
                //Chennai
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_VINTAGE_PONDY";
                string Company_Add = string.Empty, GSTN_ID = string.Empty;

                Company_Add = "SATTVA LOGISTICS GROUP" +
                                "\r\n" +
                                       "3rd Floor, Flat No.301, Kishan Residency, H.No.1-11-242/1/B/301, Shyamlal Buildings," +
                                        "\r\n" +
                                         "Begumpet, Hyderabad, Telangana - 500016.";

                load_eri00519(Company_Add, "36AADCV9116C1ZG");

            }
            else if (Company_Lic == "eri00744")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_SUN_GLOBAL_LOGISTICS";
                load_eri00744();
            }
            else if (Company_Lic == "eri00804")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_PORTAGE_GLOBAL";
                load_eri00804();
            }
            else if (Company_Lic == "eri00863")
            {
                //Blr Bangaluru
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_VINTAGE_PONDY";
                string Company_Add = string.Empty, GSTN_ID = string.Empty;

                Company_Add = "SATTVA LOGISTICS GROUP" +
                                 "\r\n" +
                                        "Plot No 95, Part 96, Vemgal Hobli, " +
                                         "\r\n" +
                                          "Kolar Taluk, Bangaluru - 560102.";

                load_eri00519(Company_Add, "29AADCV9116C1ZB");
            }
            else if (Company_Lic == "eri00911")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_FLYSEA";
                load_eri00911();
            }
            else if (Company_Lic == "eri00923")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_MASTERSTROKE";
                load_eri00923();
            }
            else if (Company_Lic == "eri00931")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_SEA_PRINCESS";
                load_eri00931();
            }
            else if (Company_Lic == "eri01051" )
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_TIME_RICH";
                load_eri01051();
            }
            else if (Company_Lic == "eri01052")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_OMAN";
                load_eri01052();
            }

            else if (Company_Lic == "eri01074")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_KARGOJET";
                load_eri01074();
            }
            else if (Company_Lic == "eri01120" || Company_Lic == "eri00010")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_KL";
                load_eri01120();
            }
            else if (Company_Lic == "eri01134")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_HOPE_CARGO_CARE";
                load_eri01134();
            }
            else if (Company_Lic == "eri01157")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_R_K_CONTAINER";
                load_eri01157();
            }
            else if (Company_Lic == "eri01158")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_LEGEND_GLOBAL";
                load_eri01158();
            }

            else if (Company_Lic == "eri01159")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_SEAGULL";
                load_eri01159();
            }
            else if (Company_Lic == "eri01160")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_SEAGULL_BLR";
                load_eri01160();
            }
            else if (Company_Lic == "eri01175")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_KL_CHENNAI";
                load_eri01175();
            }
            else if (Company_Lic == "eri01228")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_DESKMATE";//name changed Deskmate to Adwal
                load_eri01228();
            }
            else if (Company_Lic == "eri01237")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_IPAN";
                load_eri01237();
            }
            else if (Company_Lic == "eri01315")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_FLASH_AVIATION";
                load_eri01315();
            }
            else if (Company_Lic == "eri01316")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_THEESHIKSHA"; //same as Prathyun
                load_eri01316();
            }
            else if (Company_Lic == "eri01510")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_GOLDEN_CARGO";
                load_eri01510();
            }
            else if (Company_Lic == "eri01519")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_ELEGANT";
                load_eri01519();
            }
            else if (Company_Lic == "eri01529")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_SKYLINE";
                load_eri01529();
            }
            else if (Company_Lic == "eri01532")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_SMS";
                load_eri01532();
            }
            else if (Company_Lic == "eri01534")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_MID_WORLD";
                load_eri01534();
            }

            else if (Company_Lic == "eri01542")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_TRAXON"; //Same as PRATHYUN
                load_eri01542();
            }
            else if (Company_Lic == "eri01554")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_LIMRA";
                load_eri01554();
            }
            else if (Company_Lic == "eri01565")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_TRANSPEAK";
                load_eri01565();
            }

            else if (Company_Lic == "eri01598")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_MULTILINE_FREIGHT_SERVICE";
                load_eri01598();
            }
            else if (Company_Lic == "eri01642")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_NS"; //Same as PRATHYUN & TRAXON
                load_eri01642();
            }
            else if (Company_Lic == "eri01659")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_NSSCARGO";
                load_eri01659(); //same as oriental
            }
            else if (Company_Lic == "eri01691")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_SEA_PRINCESS_TUTICORIN";
                load_eri01691();
            }

            else if (Company_Lic == "eri02085")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_ROSAN";
                load_eri02085();
            }
            else if (Company_Lic == "eri02102")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_ABL";
                load_eri02102();
            }
            else if (Company_Lic == "eri02130")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_VRRDDHI"; //SAME AS VRRDDHI
                load_eri02130();
            }
            else if (Company_Lic == "eri02146")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_SASHAA";//same as pegasus eri00508                
                load_eri02146();
            }
            else if (Company_Lic == "eri02159")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_PRIVIA"; //same as Prathyun
                load_eri02159();
            }
            else if (Company_Lic == "eri02184")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_PLANETBAYS"; //SAME AS Prathyun,VRRDDHI
                load_eri02184();
            }
            else if (Company_Lic == "eri02205")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_OMEGA";
                load_eri02205();
            }
            else if (Company_Lic == "eri02260")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_LAKSHAABI";
                load_eri02260();
            }
            else if (Company_Lic == "eri02341")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_MULTITRANS";
                load_eri02341();
            }
            else if (Company_Lic == "eri03069")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_YASH";//same as Prathyun
                load_eri03069();
            }
            else if (Company_Lic == "eri03094")//Same as Shivansh Shipping ERI00677
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_CARGO_EASE_mumbai";
                load_eri03094();
            }
            else if (Company_Lic == "eri03179")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_NEXGEN";
                load_eri03179();
            }
            else if (Company_Lic == "eri03196")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_SHIVNERI";
                load_eri03196();
            }
            else if (Company_Lic == "eri03204")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_JAY_YESS";
                load_eri03204();
            }

            else if (Company_Lic == "eri03229")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_PL_GLOBAL";
                load_eri03229();
            }
            else if (Company_Lic == "eri03275")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_QUICKLINK";
                load_eri03275();
            }


            else if (Company_Lic == "eri03233")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_AGS"; //same as Prathyun Shipping
                load_eri03233();
            }
            else if (Company_Lic == "eri03423")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_ASS"; //same as Prathyun Shipping
                load_eri03423();
            }
            else if (Company_Lic == "eri04003")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_OM_LOGISTICS"; //same as Prathyun Shipping
                load_eri04003();
            }
            else if (Company_Lic == "eri04012")
            {
                ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_RPT_TYM";
                load_eri04012();
            }
                         


        }
    }

    
    
    private void load_eri00945()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_INBA.rdlc";
        CompanyName = "INBA LOGISTICS PVT LTD";



        if (dss.Tables[0].Rows[0]["BRANCH_CODE"].ToString() == "ACC, Cochin")
        {
            Company_Add = "No.15/252G, Angamaly Municipality," +
                            "\r\n" +
                                   "Angamaly, Ernakulam," +
                                    "\r\n" +
                                     "Kerala, 683572." +
                                      "\r\n" +
                                     "Tel: +94 48 4298 9879";

            ServiceTaxno = " 32AAGCI0580E1Z0";
            Pan_No = " AAGCI0580E";
        }
        else if (dss.Tables[0].Rows[0]["BRANCH_CODE"].ToString() == "ACC, Bangalore")
        {
            Company_Add = "3rd Floor, Kannamangala Gate," +
                            "\r\n" +
                                   "Devanahalli Taluk, Bengaluru," +
                                    "\r\n" +
                                     "Bengaluru Rural, Karnataka, 562110." +
                                      "\r\n" +
                                     "Tel: +91 80 2448 7242";

            ServiceTaxno = " 29AAGCI0580E1ZN";
            Pan_No = " AAGCI0580E";

        }
        else//ACC, Chennai Default
        {
            Company_Add = "No:7, VGP Murphy Square Complex" +
                            "\r\n" +
                                   "2nd Floor, 19, GST Road," +
                                    "\r\n" +
                                     "St, Thomas Mount, Chennai - 600016." +
                                      "\r\n" +
                                     "Tel: 044-48513335, 044-48523335.";

            ServiceTaxno = " 33AAGCI0580E1ZY";
            Pan_No = " AAGCI0580E";
        }


        Logo = new Uri(Server.MapPath("~/images/Company_Logo/INBA.png")).AbsoluteUri;

        LOGO1 = new Uri(Server.MapPath("~/images/Company_Logo/INBA.png")).AbsoluteUri;


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
    
    //private void load_eri00775()
    //{
    //    QR_Image = " "; 
    //    DataSet dss = new DataSet();
    //    LocalReport localReport = ReportViewer1.LocalReport;

    //    ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
    //    dss = BI.Invoice_Job_Rpt_data(ObjUBO);
    //    string TaxMode = " ";
    //    if (dss.Tables[3].Rows.Count > 0)
    //    {
    //        QRImage_path = QR_Imagepath(dss.Tables[3].Rows[0]["SignedQRCode"].ToString(), ddlJob_No.SelectedValue.ToString().Replace('/', '_'));
    //        if (QRImage_path != " ")
    //        {
    //            QR_Image = new Uri(QRImage_path).AbsoluteUri;
    //        }
    //    }
    //    localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_PRATHYUN.rdlc";


    //    CompanyName = "PRATHYUN SHIPPING INDIA PVT LTD";
    //    Company_Add = "AUTHORISED CUSTOM HOUSE BROKER CHN/R,188/2011" +
    //                    "\r\n" +
    //                           "1ST FLOOR, NEW NO:16, OLD NO:110, A.M.S.V. BUILDING," +
    //                            "\r\n" +
    //                             "ARMENIAN STREET, CHENNAI - 600 001. TAMIL NADU, INDIA." +
    //                              "\r\n" +
    //                             "TEL: 91-44-25214171 / 25272933";

    //    ServiceTaxno = " 33AAFCP8751M1ZY";
    //    Pan_No = " AAFCP8751M";
    //    Logo = new Uri(Server.MapPath("~/images/Company_Logo/PRATHYUN.png")).AbsoluteUri;
    //    LOGO2 = new Uri(Server.MapPath("~/images/Company_Logo/PRATHYUN_AEO_LOGO.png")).AbsoluteUri;


    //    ReportViewer1.LocalReport.EnableExternalImages = true;
    //    List<ReportParameter> paramList = new List<ReportParameter>();
    //    this.ReportViewer1.LocalReport.SetParameters(paramList);
    //    ReportViewer1.LocalReport.DataSources.Clear();

    //    ReportDataSource datasource = new ReportDataSource("DataSet1", dss.Tables[0]);
    //    ReportViewer1.LocalReport.DataSources.Add(datasource);
    //    ReportDataSource datasource1 = new ReportDataSource("DataSet2", dss.Tables[1]);
    //    ReportViewer1.LocalReport.DataSources.Add(datasource1);
    //    ReportDataSource datasource2 = new ReportDataSource("DataSet3", dss.Tables[2]);
    //    ReportViewer1.LocalReport.DataSources.Add(datasource2);
    //    ReportDataSource datasource3 = new ReportDataSource("DataSet4", dss.Tables[3]);
    //    ReportViewer1.LocalReport.DataSources.Add(datasource3);



    //    ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
    //    Remarks = dss.Tables[0].Rows[0]["REMARKS"].ToString();
    //    STATE_NAME = dss.Tables[0].Rows[0]["STATE_NAME"].ToString();


    //    ReportParameter p1 = new ReportParameter("Name", CompanyName);
    //    ReportParameter p2 = new ReportParameter("Address", Company_Add);
    //    ReportParameter p3 = new ReportParameter("ServiceTaxno", ServiceTaxno);
    //    ReportParameter p4 = new ReportParameter("Remarks", Remarks);
    //    ReportParameter p5 = new ReportParameter("Logo", Logo);
    //    ReportParameter p6 = new ReportParameter("TaxMode", TaxMode);
    //    ReportParameter p7 = new ReportParameter("Pan_No", Pan_No);
    //    ReportParameter p8 = new ReportParameter("STATE_NAME", STATE_NAME);
    //    ReportParameter p9 = new ReportParameter("LOGO1", QR_Image);
    //    ReportParameter p10 = new ReportParameter("LOGO2", LOGO2);


    //    ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 };
    //    ReportViewer1.LocalReport.SetParameters(p);
    //    Report_Print();
    //}

    private void load_eri00775()
    {
        phy_path = string.Empty;
        QR_Image = " ";
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        //if (ObjUBO.BILL_INV_NO == "PSI2526/2622" || ObjUBO.BILL_INV_NO == "PSI2526/2623" || ObjUBO.BILL_INV_NO == "PSI2526/2624" || ObjUBO.BILL_INV_NO == "PSI2526/2625" || ObjUBO.BILL_INV_NO == "PSI2526/2631" || ObjUBO.BILL_INV_NO == "PSI2526/2658" || ObjUBO.BILL_INV_NO == "PSI2526/2606" || ObjUBO.BILL_INV_NO == "PSI2526/2874")
        if (dss.Tables[3].Rows.Count > 0)
        {
            phy_path = Server.MapPath("~/Submission/" + Connection.COMPANYID() + "/GST_BILL_QRCODE/" + "/Auto");
            QRImage_path = QRCI.QRCode_to_Image(dss.Tables[3].Rows[0]["SignedQRCode"].ToString(), ddlJob_No.SelectedValue.ToString().Replace('/', '_'), phy_path);
            if (QRImage_path != "")
            {
                QR_Image = new Uri(QRImage_path).AbsoluteUri;
            }
        }
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_PRATHYUN.rdlc";
        CompanyName = "PRATHYUN SHIPPING INDIA PVT LTD";
        Company_Add = "AUTHORISED CUSTOM HOUSE BROKER CHN/R,188/2011" +
                        "\r\n" +
                               "1ST FLOOR, NEW NO:16, OLD NO:110, A.M.S.V. BUILDING," +
                                "\r\n" +
                                 "ARMENIAN STREET, CHENNAI - 600 001. TAMIL NADU, INDIA." +
                                  "\r\n" +
                                 "TEL: 91-44-25214171 / 25272933";
        ServiceTaxno = " 33AAFCP8751M1ZY";
        Pan_No = " AAFCP8751M";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/PRATHYUN.png")).AbsoluteUri;
        LOGO2 = new Uri(Server.MapPath("~/images/Company_Logo/PRATHYUN_AEO_LOGO.png")).AbsoluteUri;


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
        ReportParameter p9 = new ReportParameter("LOGO1", QR_Image);
        ReportParameter p10 = new ReportParameter("LOGO2", LOGO2);


        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 };
        ReportViewer1.LocalReport.SetParameters(p);
        Report_Print();
    }
    private void load_eri01315()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_FLASH_AVIATION.rdlc";
        CompanyName = "FLASH AVIATION SERVICES PRIVATE LIMITED";
        Company_Add = "2ND FLOOR, NO 634," +
                        "\r\n" +
                               "RBI HBCS LAYOUT," +
                                "\r\n" +
                                 "Bengaluru Urban," +
                                  "\r\n" +
                                 "BANGALORE, Karnataka, 560062";

        ServiceTaxno = " 29AADCF8245Q1ZU";
        Pan_No = " AADCF8245Q";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/FLASH_AVIATION.png")).AbsoluteUri;



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


        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }
    private void load_eri01510()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_GOLDEN_CARGO.rdlc";


        CompanyName = "GOLDEN CARGO PVT LTD";
        Company_Add = "NO. 14, SR TOWERS, 5TH FLOOR," +
                        "\r\n" +
                               "NORTH BEACH ROAD, CHENNAI - 600001." +
                                  "\r\n" +
                                 "Mob: 93821 94747 Email: goldencargo97@gmail.com";

        ServiceTaxno = " 33AABCG0899B1ZX";
        Pan_No = " AABCG0899B";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/GOLDEN_CARGO.png")).AbsoluteUri;

        LOGO1 = new Uri(Server.MapPath("~/images/Company_Logo/GOLDEN_CARGO.png")).AbsoluteUri;


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

    private void load_eri01519()
    {
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_ELEGANT.rdlc";
        CompanyName = "ELEGANT SHIPPING AND LOGISTICS";
        Company_Add = "NO 48, SECOND FLOOR," +
                        "\r\n" +
                               "EAST MADHA CHURCH STREET," +
                                "\r\n" +
                                 "ROYAPURAM, CHENNAI, TAMIL NADU - 600 013." +
                                  "\r\n" +
                                 "Mob: 80721 41973 Email: info@elegantlogisticsgroup.com" +
                                 "\r\n" +
                                 "BRANCHES :BANGALORE| GANDHIDHAM  | MUNDRA "
                                 ;

        ServiceTaxno = " 33AAJFE3115F1ZY";
        Pan_No = " AAJFE3115F";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/ELEGANT.png")).AbsoluteUri;

        LOGO1 = new Uri(Server.MapPath("~/images/Company_Logo/ELEGANT.png")).AbsoluteUri;


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
        //ReportDataSource datasource3 = new ReportDataSource("DataSet4", dss.Tables[3]);
        //ReportViewer1.LocalReport.DataSources.Add(datasource3);

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

    private void load_eri01529()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_SKYLINE.rdlc";


        CompanyName = "SKYLINE LOGISTICS SERVICE";
        Company_Add = "DOOR NO: 8, 2ND FLOOR, MNJ CENTRE," +
                        "\r\n" +
                               "NEW NO: 88 & 90 OLD NO: 71 & 72, MOORE STREET, " +
                                "\r\n" +
                                 "MANNADY, CHENNAI, TAMILNADU - 600001. " +
                                  "\r\n" +
                                 "Mob: 9600047688 Email: accounts.maa@skylinelogistics.in";

        ServiceTaxno = " 33ACUFS6671F1ZM";
        Pan_No = " ACUFS6671F";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/SKYLINE.jpg")).AbsoluteUri;

        LOGO1 = new Uri(Server.MapPath("~/images/Company_Logo/SKYLINE.jpg")).AbsoluteUri;


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
    private void load_eri01532()
    {
        phy_path = string.Empty;
        QR_Image = " ";
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        //if (ObjUBO.BILL_INV_NO == "PSI2526/2622" || ObjUBO.BILL_INV_NO == "PSI2526/2623" || ObjUBO.BILL_INV_NO == "PSI2526/2624" || ObjUBO.BILL_INV_NO == "PSI2526/2625" || ObjUBO.BILL_INV_NO == "PSI2526/2631" || ObjUBO.BILL_INV_NO == "PSI2526/2658" || ObjUBO.BILL_INV_NO == "PSI2526/2606" || ObjUBO.BILL_INV_NO == "PSI2526/2874")
        if (dss.Tables[3].Rows.Count > 0)
        {
            phy_path = Server.MapPath("~/Submission/" + Connection.COMPANYID() + "/GST_BILL_QRCODE/" + "/Auto");
            QRImage_path = QRCI.QRCode_to_Image(dss.Tables[3].Rows[0]["SignedQRCode"].ToString(), ddlJob_No.SelectedValue.ToString().Replace('/', '_'), phy_path);
            if (QRImage_path != "")
            {
                QR_Image = new Uri(QRImage_path).AbsoluteUri;
            }
        }
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_SMS.rdlc";

        //CompanyName = "SMS LOGISTICS INDIA PRIVATE LIMITED";
        //Company_Add = "CUSTOM HOUSE AGENT & FREIGHT FORWARDER" +
        //                "\r\n" +
        //                       "SMS HOUSE L-225 STREET NO 7B, MAHIPALPUR EXTN," +
        //                        "\r\n" +
        //                         "NEW DELHI - 110037 INDIA. Mobile - 9810908994." +
        //                          "\r\n" +
        //                         "Email: ACCOUNTS@SMSGROUP.CO  Website: SMSGROUP.CO";

        CompanyName = "SMS LOGISTICS INDIA PRIVATE LIMITED";

        Company_Add = "(Formerly known as SMS CLEARING & FORWARDING PVT LTD)" +
                        "\r\n" +
                      "“Delivering your world, on time.”" +
                      "\r\n" +
                               "SMS HOUSE L-225 STREET NO 7B, MAHIPALPUR EXTN," +
                                "\r\n" +
                                 "NEW DELHI - 110037 INDIA. Mobile - 9810908994." +
                                  "\r\n" +
                                 "Email: ACCOUNTS@SMSGROUP.CO  Website: SMSGROUP.CO";



        //        (Formerly known as SMS CLEARING & FORWARDING PVT LTD)
        //“Delivering your world, on time.”


        ServiceTaxno = " 07AALCS7969Q1Z2";
        Pan_No = " AALCS7969Q";

        Logo = new Uri(Server.MapPath("~/images/Company_Logo/SMS.png")).AbsoluteUri;
        LOGO2 = new Uri(Server.MapPath("~/images/Company_Logo/SMS.png")).AbsoluteUri;


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
        ReportParameter p9 = new ReportParameter("LOGO1", QR_Image);
        ReportParameter p10 = new ReportParameter("LOGO2", LOGO2);


        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 };
        ReportViewer1.LocalReport.SetParameters(p);
        Report_Print();
    }
    private void load_eri01534()
    {
        phy_path = string.Empty;
        QR_Image = " ";
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        //if (ObjUBO.BILL_INV_NO == "PSI2526/2622" || ObjUBO.BILL_INV_NO == "PSI2526/2623" || ObjUBO.BILL_INV_NO == "PSI2526/2624" || ObjUBO.BILL_INV_NO == "PSI2526/2625" || ObjUBO.BILL_INV_NO == "PSI2526/2631" || ObjUBO.BILL_INV_NO == "PSI2526/2658" || ObjUBO.BILL_INV_NO == "PSI2526/2606" || ObjUBO.BILL_INV_NO == "PSI2526/2874")
        if (dss.Tables[3].Rows.Count > 0)
        {
            phy_path = Server.MapPath("~/Submission/" + Connection.COMPANYID() + "/GST_BILL_QRCODE/" + "/Auto");
            QRImage_path = QRCI.QRCode_to_Image(dss.Tables[3].Rows[0]["SignedQRCode"].ToString(), ddlJob_No.SelectedValue.ToString().Replace('/', '_'), phy_path);
            if (QRImage_path != "")
            {
                QR_Image = new Uri(QRImage_path).AbsoluteUri;
            }
        }
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_MID_WORLD.rdlc";
        CompanyName = "MID WORLD SHIPPING";
        Company_Add = "PLOT NO.115, SECTOR 1/A," +
                        "\r\n" +
                               "GANDHIDHAM, KUTCH, GUJARAT - 370201." +
                                  "\r\n" +
                                 "TEL: 91-44-25214171 / 25272933";

        ServiceTaxno = " 24ABVFM0455F1Z6";
        Pan_No = " ABVFM0455F";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/MID_WORLD.png")).AbsoluteUri;
        LOGO2 = new Uri(Server.MapPath("~/images/Company_Logo/MID_WORLD.png")).AbsoluteUri;


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
        ReportParameter p9 = new ReportParameter("LOGO1", QR_Image);
        ReportParameter p10 = new ReportParameter("LOGO2", LOGO2);


        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 };
        ReportViewer1.LocalReport.SetParameters(p);
        Report_Print();
    }
    private void load_eri01542()
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
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_TRAXON.rdlc";


        CompanyName = "Traxon Logistics";
        Company_Add = "Flat No: 78, 7th Floor, BBC Villa Complex," +
                        "\r\n" +
                        "No: 65, Prakasam Salai, Broadway, Chennai - 600 108." +
                        "\r\n" +
                        "Phone No: 044 - 2526 0888 / 4356 6202" +
                        "\r\n" +
                               "Mail Id: accounts@traxonlogistics.com";

        ServiceTaxno = " 33APCPS9944J2ZC";
        Pan_No = " APCPS9944J";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/TRAXON.png")).AbsoluteUri;

        //LOGO1 = new Uri(Server.MapPath("~/images/Company_Logo/TRAXON.png")).AbsoluteUri;
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
    
    private void load_eri01554()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";

        if (dss.Tables[0].Rows[0]["BILL_TYPE"].ToString() == "L")
        {
            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_LIMRA_LOCAL.rdlc";
        }

        else
        {
            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_LIMRA_OTHER.rdlc";
        }

        CompanyName = "LIMRA LOGISTICS";
        Company_Add = "Registered Office Address : 24/61, 4th Street Cross K.M.Nagar Ambur 635 802." +
                                "\r\n" +
                                 "Branch Office 1 : #17/3 Shop No.5, Ground Floor, Bamboo Mandi Street, Ambur - 635 802." +
                                 "\r\n" +
                                 "Branch Office 2 : No.6/11, 3rd Floor Lalakutty Street Periamet Chennai - 600 003" +
                                 "\r\n" +
                                 "Email ID : sabeel@limralogistics.in, info@limralogistics.in " +
                                 "\r\n" +
                                 "\r\n" +
                                 "PAN : AAGFL0610F   GSTIN : 33AAGFL0610F1Z0 ";



        ServiceTaxno = " 33AAGFL0610F1Z0";
        Pan_No = " AAGFL0610F";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/LIMRA.png")).AbsoluteUri;

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


        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }

    private void load_eri01565()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_TRANSPEAK.rdlc";


        CompanyName = "TRANSPEAK FREIGHT";
        Company_Add = "BUILDING NO.13AB / GALA NO.59, SAMHITA COMPLEX," +
                        "\r\n" +
                               "SAKI NAKA, ANDHERI EAST, MUMBAI, MUMBAI SUBURBAN," +
                                "\r\n" +
                                 "MAHARASHTRA, 400072.";


        ServiceTaxno = " 27AJEPC3138J1ZE";
        Pan_No = " AJEPC3138J";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/TRANSPEAK.jpg")).AbsoluteUri;

        LOGO1 = new Uri(Server.MapPath("~/images/Company_Logo/TRANSPEAK.jpg")).AbsoluteUri;

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

    private void load_eri01598()
    {
        string base64string = "";
        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        //string TaxMode = " ";
        string base64string1 = dss.Tables[3].Rows[0]["SignedQRCodeImage"].ToString();
        //string base64string = base64string1.Substring(base64string1.IndexOf("Submission"));
        if (base64string1.Length > 0)
        {
            base64string = base64string1.Substring(base64string1.IndexOf("Submission"));
        }


        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_MULTILINE_FREIGHT_SERVICES.rdlc";
        CompanyName = "MULTILINE FREIGHT SERVICES PVT. LTD";
        Company_Add = "No.84/1, MFS House, Moore Street, CHENNAI - 600001." +
                                "\r\n" +
                              "PHONE NO: 25240204 / 25222161" +
                                 "\r\n" +
                              "EMAIL: hraccounts@mfslogistics.in";

        ServiceTaxno = "33AACCM3072F1ZV";
        Pan_No = " AACCM3072F";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/MULTILINE.png")).AbsoluteUri;
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
        //Remarks = dss.Tables[0].Rows[0]["REMARKS"].ToString();
        //STATE_NAME = dss.Tables[0].Rows[0]["STATE_NAME"].ToString();


        ReportParameter p1 = new ReportParameter("Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Address", Company_Add);
        ReportParameter p3 = new ReportParameter("ServiceTaxno", ServiceTaxno);
        //ReportParameter p4 = new ReportParameter("Remarks", Remarks);
        ReportParameter p5 = new ReportParameter("Logo", Logo);
        //ReportParameter p6 = new ReportParameter("TaxMode", TaxMode);
        ReportParameter p4 = new ReportParameter("Pan_No", Pan_No);
        //ReportParameter p8 = new ReportParameter("STATE_NAME", STATE_NAME);
        ReportParameter p6 = new ReportParameter("LOGO1", LOGO1);

        //ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8 };
        ReportParameter[] p = { p1, p2, p3, p4, p5, p6 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();


    }

    private void load_eri01659()//Same as oriental
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_NSSCARGO.rdlc";


        CompanyName = "NSS CARGO";
        Company_Add = "NO.04 LEGEND HILLVIEW APARTMENT," +
                        "\r\n" +
                              "VIDHYA NAGAR ," +
                                "\r\n" +
                               "BANGALORE," +
                               "\r\n" +
                                 " KARNATAKA," +
                                "\r\n" +
                                 "562157" +
                                "\r\n" +
                                 "MOB: 9845339287" +
                                  "\r\n" +
                                 "EMAIL : info.nsscargo@gmail.com" +
                                      "\r\n" +
                                    "PAN: AJMPN0022E";

        ServiceTaxno = " 29AJMPN0022E1ZH";
        Pan_No = " AJMPN0022E";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/NSSCARGO.png")).AbsoluteUri;

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


        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }
    /*
    private void load_eri01691()
    {
        phy_path = string.Empty;
        QR_Image = " ";
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        //if (ObjUBO.BILL_INV_NO == "PSI2526/2622" || ObjUBO.BILL_INV_NO == "PSI2526/2623" || ObjUBO.BILL_INV_NO == "PSI2526/2624" || ObjUBO.BILL_INV_NO == "PSI2526/2625" || ObjUBO.BILL_INV_NO == "PSI2526/2631" || ObjUBO.BILL_INV_NO == "PSI2526/2658" || ObjUBO.BILL_INV_NO == "PSI2526/2606" || ObjUBO.BILL_INV_NO == "PSI2526/2874")
        if (dss.Tables[3].Rows.Count > 0)
        {
            phy_path = Server.MapPath("~/Submission/" + Connection.COMPANYID() + "/GST_BILL_QRCODE/" + "/Auto");
            QRImage_path = QRCI.QRCode_to_Image(dss.Tables[3].Rows[0]["SignedQRCode"].ToString(), ddlJob_No.SelectedValue.ToString().Replace('/', '_'), phy_path);
            if (QRImage_path != "")
            {
                QR_Image = new Uri(QRImage_path).AbsoluteUri;
            }
        }
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_SEA_PRINCESS_TUTICORIN.rdlc";
        CompanyName = "SEA PRINCESS LOGISTICS";
        CompanyName = "SEA PRINCESS LOGISTICS";
        Company_Add = "73J/19,Perison Plaza, 2nd Floor, Polepettai," +
                        "\r\n" +
                               "Tuticorin – 628 002, Tamilnadu, India." +
                                  "\r\n" +
                                 "Tel: 0461-2325544";

        ServiceTaxno = " 33ADXFS3139G1ZQ";
        Pan_No = " ADXFS3139G";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/SEA_PRINCESS_TUTICORIN.jpeg")).AbsoluteUri;
        LOGO2 = new Uri(Server.MapPath("~/images/Company_Logo/SEA_PRINCESS_TUTICORIN.jpeg")).AbsoluteUri;


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
        ReportParameter p9 = new ReportParameter("LOGO1", QR_Image);
        ReportParameter p10 = new ReportParameter("LOGO2", LOGO2);


        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 };
        ReportViewer1.LocalReport.SetParameters(p);
        Report_Print();
    }    
    */
    //private void load_eri01691()
    //{
    //    string base64string = "";
    //    DataSet dss = new DataSet();
    //    LocalReport localReport = ReportViewer1.LocalReport;

    //    ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
    //    dss = BI.Invoice_Job_Rpt_data(ObjUBO);
    //    string TaxMode = " ";
    //    if (dss.Tables[3].Rows.Count > 0)
    //    {
    //        string base64string1 = dss.Tables[3].Rows[0]["SignedQRCodeImage"].ToString();
    //        //string base64string = base64string1.Substring(base64string1.IndexOf("Submission"));
    //        if (base64string1.Length > 0)
    //        {
    //            base64string = base64string1.Substring(base64string1.IndexOf("Submission"));
    //        }
    //    }
    //    localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_SGSL.rdlc";
        
    //    CompanyName = "SEA PRINCESS LOGISTICS";
    //    Company_Add = "73J/19,Perison Plaza, 2nd Floor, Polepettai," +
    //                    "\r\n" +
    //                           "Tuticorin – 628 002, Tamilnadu, India." +
    //                              "\r\n" +
    //                             "Tel: 0461-2325544";

    //    ServiceTaxno = " 33ADXFS3139G1ZQ";
    //    Pan_No = " ADXFS3139G";
    //    Logo = new Uri(Server.MapPath("~/images/Company_Logo/SEA_PRINCESS_TUTICORIN.png")).AbsoluteUri;

    //    if (base64string.Length > 0)
    //    {
    //        LOGO1 = new Uri(Server.MapPath("~/" + base64string)).AbsoluteUri;
    //    }
    //    else { LOGO1 = new Uri(Server.MapPath("~/images/txtbox-mid_90px.png")).AbsoluteUri; }

    //    LOGO2 = new Uri(Server.MapPath("~/images/Company_Logo/SEA_PRINCESS_TUTICORIN.png")).AbsoluteUri;


    //    ReportViewer1.LocalReport.EnableExternalImages = true;
    //    List<ReportParameter> paramList = new List<ReportParameter>();
    //    this.ReportViewer1.LocalReport.SetParameters(paramList);
    //    ReportViewer1.LocalReport.DataSources.Clear();

    //    ReportDataSource datasource = new ReportDataSource("DataSet1", dss.Tables[0]);
    //    ReportViewer1.LocalReport.DataSources.Add(datasource);
    //    ReportDataSource datasource1 = new ReportDataSource("DataSet2", dss.Tables[1]);
    //    ReportViewer1.LocalReport.DataSources.Add(datasource1);
    //    ReportDataSource datasource2 = new ReportDataSource("DataSet3", dss.Tables[2]);
    //    ReportViewer1.LocalReport.DataSources.Add(datasource2);
    //    ReportDataSource datasource3 = new ReportDataSource("DataSet4", dss.Tables[3]);
    //    ReportViewer1.LocalReport.DataSources.Add(datasource3);



    //    ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
    //    Remarks = dss.Tables[0].Rows[0]["REMARKS"].ToString();
    //    STATE_NAME = dss.Tables[0].Rows[0]["STATE_NAME"].ToString();


    //    ReportParameter p1 = new ReportParameter("Name", CompanyName);
    //    ReportParameter p2 = new ReportParameter("Address", Company_Add);
    //    ReportParameter p3 = new ReportParameter("ServiceTaxno", ServiceTaxno);
    //    ReportParameter p4 = new ReportParameter("Remarks", Remarks);
    //    ReportParameter p5 = new ReportParameter("Logo", Logo);
    //    ReportParameter p6 = new ReportParameter("TaxMode", TaxMode);
    //    ReportParameter p7 = new ReportParameter("Pan_No", Pan_No);
    //    ReportParameter p8 = new ReportParameter("STATE_NAME", STATE_NAME);
    //    ReportParameter p9 = new ReportParameter("LOGO1", LOGO1);
    //    ReportParameter p10 = new ReportParameter("LOGO2", LOGO2);


    //    ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 };
    //    ReportViewer1.LocalReport.SetParameters(p);

    //    Report_Print();

    //    byte[] bytes = (byte[])Session["report"];
    //    Response.ClearHeaders();
    //    Response.Clear();

    //    Response.ContentType = "application/pdf";
    //    string File_name = "IMPINV" + (ViewState["File_Name"].ToString()).Replace("-", "").Replace("/", "").Replace("_", "");
    //    Response.AddHeader("content-disposition", "attachment;filename=" + File_name + ".pdf");
    //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //    Response.BinaryWrite(bytes);
    //    Response.End();


    //}

    private void load_eri01691()
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
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_SEA_PRINCESS_TUTICORIN.rdlc";


        CompanyName = "SEA PRINCESS LOGISTICS";
        Company_Add = "73J/19,Perison Plaza, 2nd Floor, Polepettai," +
                        "\r\n" +
                               "Tuticorin – 628 002, Tamilnadu, India." +
                                  "\r\n" +
                                 "Tel: 0461-2325544";

        ServiceTaxno = " 33ADXFS3139G1ZQ";
        Pan_No = " ADXFS3139G";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/SEA_PRINCESS_TUTICORIN.png")).AbsoluteUri;

        if (base64string.Length > 0)
        {
            LOGO1 = new Uri(Server.MapPath("~/" + base64string)).AbsoluteUri;
        }
        else { LOGO1 = new Uri(Server.MapPath("~/images/txtbox-mid_90px.png")).AbsoluteUri; }

        LOGO2 = new Uri(Server.MapPath("~/images/Company_Logo/SEA_PRINCESS_TUTICORIN.png")).AbsoluteUri;


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

        byte[] bytes = (byte[])Session["report"];
        Response.ClearHeaders();
        Response.Clear();

        Response.ContentType = "application/pdf";
        string File_name = "IMPINV" + (ViewState["File_Name"].ToString()).Replace("-", "").Replace("/", "").Replace("_", "");
        Response.AddHeader("content-disposition", "attachment;filename=" + File_name + ".pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.BinaryWrite(bytes);
        Response.End();


    }
    private void load_eri00004()
    {
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_e_ROYALIMPEX.rdlc";

        CompanyName = "ROYAL TECH SYSTEMS";
        Company_Add = "New No.8(Old No.19)," +
                       "\r\n" +
                       "Flot No.3,2nd Cross Street,Kalaimagal Nagar," +
                        "\r\n" +
                              "Ekkattuthangal,Chennai-600 032 " +
                               "\r\n" +
                                "PHONE NO: 044-4266 9886" +
                                 "\r\n" +
                                "EMAIL :admin@royaltechsystems.co.in" +
                                 "\r\n" +
                                "sales@royaltechsystems.co.in";

        ServiceTaxno = "AAAXX0005HST001";
        Pan_No = "AAAXX0005H";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/RoyalTechSystems_Logo_big.gif")).AbsoluteUri;

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


        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }
    private void load_eri00001()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_RTS_COMMON.rdlc";


        CompanyName = "ROYAL TECH SYSTEMS";
        Company_Add = "New No.8(Old No.19)," +
                       "\r\n" +
                       "Flot No.3,2nd Cross Street,Kalaimagal Nagar," +
                        "\r\n" +
                              "Ekkattuthangal,Chennai-600 032 " +
                               "\r\n" +
                                "PHONE NO: 044-4266 9886" +
                                 "\r\n" +
                                "EMAIL :admin@royaltechsystems.co.in" +
                                 "\r\n" +
                                "sales@royaltechsystems.co.in";

        ServiceTaxno = "AAAXX0005HST001";
        Pan_No = "AAAXX0005H";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/RoyalTechSystems_Logo_big.gif")).AbsoluteUri;

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


        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }
    private void load_eri00002()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_ORIENTAL.rdlc";


        CompanyName = "ORIENTAL SHIPPING & CLEARING AGENCY PVT. LTD";
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

        ServiceTaxno = "33AAACO0422F1Z7";
        Pan_No = " AAACO0422F";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/oriental.png")).AbsoluteUri;

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


        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();
        
    }
    private void load_eri00132()
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
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_SHRINATH.rdlc";


        CompanyName = "Shrinath Shipping And Logistics Solution";
        Company_Add = "Office No. 207, Second Floor, " +
                        "\r\n" +
                               "Kashish Arcade Building, Zero Point," +
                                "\r\n" +
                                 "Mundra, Kutch, Gujarat 370421" +
                                  "\r\n" +
                                 "email: ssalsmundra@gmail.com   web: www.shrinathshipping.com";


        ServiceTaxno = " 24AQSPM0260G1ZW";
        Pan_No = " AQSPM0260G";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/SHRINATH.png")).AbsoluteUri;

        if (base64string.Length > 0)
        {
            LOGO1 = new Uri(Server.MapPath("~/" + base64string)).AbsoluteUri;
        }
        else { LOGO1 = new Uri(Server.MapPath("~/images/txtbox-mid_90px.png")).AbsoluteUri; }

        LOGO2 = new Uri(Server.MapPath("~/images/Company_Logo/SHRINATH.png")).AbsoluteUri;


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
    private void load_eri00141()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_AREN_SHIPPING.rdlc";
        CompanyName = "AREN SHIPPING AGENTS PVT LTD";

        if (dss.Tables[0].Rows[0]["CFS_CHARGE"].ToString() == "COCHIN")
        {
            Company_Add = "CUSTOM HOUSE AGENT - R 361 / 93" +
                            "\r\n" +
                                   "3M, PLATINUM AIRPORT LOUNGE, VAPPALASSAERY, NEDUMPASSERY PANCHAYAT," +
                                    "\r\n" +
                                     "ERNAKULAM DISTRICT, KERALA - 683574. Tel: 044 42167551 / 42052866 / 42166526" +
                                      "\r\n" +
                                     "Email: annadurai@arenshipping.com,  Web: www.arenshipping.com ";

            ServiceTaxno = "32AADCA2363A1ZI";
            Pan_No = " AADCA2363A";
        }
        else
        {//Default Branch
            Company_Add = "CUSTOM HOUSE AGENT - R 361 / 93" +
                            "\r\n" +
                                   "Beach House, 1st floor, No. 20, Second Line Beach, Chennai, Tamil Nadu - 600 001." +
                                    "\r\n" +
                                     "Tel: 044 42167551 / 42052866 / 42166526" +
                                      "\r\n" +
                                     "Email: annadurai@arenshipping.com,  Web: www.arenshipping.com ";

            ServiceTaxno = "33AADCA2363A1ZG";
            Pan_No = " AADCA2363A";
        }

        Logo = new Uri(Server.MapPath("~/images/Company_Logo/AREN_SHIPPING.png")).AbsoluteUri;
        LOGO1 = new Uri(Server.MapPath("~/images/Company_Logo/AREN_SHIPPING_AEO_LOGO.jpg")).AbsoluteUri;

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
    private void load_eri00145()
    {
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_BCM.rdlc";

        CompanyName = "BULLET CARGO MOVERS PVT.LTD.";
        Company_Add = "CHA Licence No: AAACB0324RCH001," +
                        "\r\n" +
                               "E-mail : info@bcmlimited.com" +
                                "\r\n" +
                                 "PHONE NO:+91-11-25894469,25894470,45005218" +
                                  "\r\n" +
                                 "GSTIN: 07AAACB0324R1ZP" +
                                      "\r\n" +
                                    "STATE CODE: DELHI - 07" +
                                     "\r\n" +
                                    "PAN NO : AAACB0324R" +
                                     "\r\n" +
                                    "CIN No: U74899DL1992PTC048796";

        ServiceTaxno = "07AAACB0324R1ZP";
        Pan_No = "AAACB0324R";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/BCM.png")).AbsoluteUri;


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

        ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        Remarks = dss.Tables[0].Rows[0]["REMARKS"].ToString();
        STATE_NAME = dss.Tables[0].Rows[0]["STATE_NAME"].ToString();
        TaxMode = dss.Tables[1].Rows[0]["TAX_NONTAX"].ToString();


        if (dss.Tables[1].Rows[0]["TAX_NONTAX"].ToString() == "N")
        {
            TaxMode = "REIMBURSEMENT DOCUMENT";
        }

        else if (dss.Tables[1].Rows[0]["TAX_NONTAX"].ToString() == "T")
        {
            TaxMode = "TAXABLE INVOICE";
        }
        ReportParameter p1 = new ReportParameter("Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Address", Company_Add);
        ReportParameter p3 = new ReportParameter("ServiceTaxno", ServiceTaxno);
        ReportParameter p4 = new ReportParameter("Remarks", Remarks);
        ReportParameter p5 = new ReportParameter("Logo", Logo);
        ReportParameter p6 = new ReportParameter("TaxMode", TaxMode);
        ReportParameter p7 = new ReportParameter("Pan_No", Pan_No);
        ReportParameter p8 = new ReportParameter("STATE_NAME", STATE_NAME);


        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }     

    private void load_eri00146()
    {
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);

        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_BWC.rdlc";
        
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
                                     "GST NO:33AACFB0739P2ZE" + 
                                      "\r\n" +
                                     "PAN NO .: AACFB0739P" +
                                       "\r\n" +
                                     "WEBSITE: www.bwclogistics.com";

           ServiceTaxno = "33AACFB0739P2ZE";
            Pan_No = " ";
            Logo = new Uri(Server.MapPath("~/images/Company_Logo/BLUE WORLD Cargo logo.JPG")).AbsoluteUri;
        
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

        ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        Remarks = dss.Tables[0].Rows[0]["REMARKS"].ToString();

        ReportParameter p1 = new ReportParameter("Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Address", Company_Add);
        ReportParameter p3 = new ReportParameter("ServiceTaxno", ServiceTaxno);
        ReportParameter p4 = new ReportParameter("Remarks", Remarks);
        ReportParameter p5 = new ReportParameter("Logo", Logo);
        ReportParameter p6 = new ReportParameter("TaxMode", TaxMode);
        ReportParameter p7 = new ReportParameter("Pan_No", Pan_No);

        ReportParameter[] p = { p1, p2, p3, p4, p5, p6,p7 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();
    }

    private void load_eri00155()
    {
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_HARTRODT.rdlc";

        CompanyName = "BULLET CARGO MOVERS PVT.LTD.";
        Company_Add = "CHA Licence No: AAACB0324RCH001," +
                        "\r\n" +
                               "E-mail : info@bcmlimited.com" +
                                "\r\n" +
                                 "PHONE NO:+91-11-25894469,25894470,45005218" +
                                  "\r\n" +
                                 "GSTIN: 07AAACB0324R1ZP" +
                                      "\r\n" +
                                    "STATE CODE: DELHI - 07" +
                                     "\r\n" +
                                    "PAN NO : AAACB0324R" +
                                     "\r\n" +
                                    "CIN No: U74899DL1992PTC048796";

        ServiceTaxno = "07AAACB0324R1ZP";
        Pan_No = "AAACB0324R";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/BCM.png")).AbsoluteUri;


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

        ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        Remarks = dss.Tables[0].Rows[0]["REMARKS"].ToString();
        STATE_NAME = dss.Tables[0].Rows[0]["STATE_NAME"].ToString();
        TaxMode = dss.Tables[1].Rows[0]["TAX_NONTAX"].ToString();


        if (dss.Tables[1].Rows[0]["TAX_NONTAX"].ToString() == "N")
        {
            TaxMode = "REIMBURSEMENT DOCUMENT";
        }

        else if (dss.Tables[1].Rows[0]["TAX_NONTAX"].ToString() == "T")
        {
            TaxMode = "TAXABLE INVOICE";
        }
        ReportParameter p1 = new ReportParameter("Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Address", Company_Add);
        ReportParameter p3 = new ReportParameter("ServiceTaxno", ServiceTaxno);
        ReportParameter p4 = new ReportParameter("Remarks", Remarks);
        ReportParameter p5 = new ReportParameter("Logo", Logo);
        ReportParameter p6 = new ReportParameter("TaxMode", TaxMode);
        ReportParameter p7 = new ReportParameter("Pan_No", Pan_No);
        ReportParameter p8 = new ReportParameter("STATE_NAME", STATE_NAME);


        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

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
            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_KSQUARE_MUMBAI.rdlc";
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
        QR_Image = " ";
        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        if (dss.Tables[5].Rows.Count > 0)
        {
            QRImage_path = QR_Imagepath(dss.Tables[5].Rows[0]["SignedQRCode"].ToString(), ddlJob_No.SelectedValue.ToString().Replace('/', '_'));
            if (QRImage_path != " ")
            {
                QR_Image = new Uri(QRImage_path).AbsoluteUri;
            }
        }
        localReport.ReportPath = @"Billing_EXP_Rpt/GST_Bill_Export_Job_rpt_DENKEN.rdlc";

        CompanyName = "DENKEN GLOBAL SUPPLY CHAIN PVT LTD";
        Company_Add = "No.5, Avvaiyar Street," +
                        "\r\n" +
                        "1 st Floor, Meenambakkam," +
                         "\r\n" +
                               "CHENNAI - 600 027.";

        Logo = new Uri(Server.MapPath("~/images/Company_Logo/Denken.png")).AbsoluteUri;

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
        ReportParameter p4 = new ReportParameter("LOGO1", QR_Image);
        ReportParameter[] p = { p1, p2, p3, p4 };        
        ReportViewer1.LocalReport.SetParameters(p);
        Report_Print();

    }
    private void load_eri01186()
    {
        QR_Image = " ";
        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        if (dss.Tables[5].Rows.Count > 0)
        {
            QRImage_path = QR_Imagepath(dss.Tables[5].Rows[0]["SignedQRCode"].ToString(), ddlJob_No.SelectedValue.ToString().Replace('/', '_'));
            if (QRImage_path != " ")
            {
                QR_Image = new Uri(QRImage_path).AbsoluteUri;
            }
        }
        localReport.ReportPath = @"Billing_EXP_Rpt/GST_Bill_Export_Job_rpt_DENKEN_BLR.rdlc";

        CompanyName = "DENKEN GLOBAL SUPPLY CHAIN PVT LTD";
        Company_Add = "UNIT NO 149, CARGO VILLAGE," +
                        "\r\n" +
                        "KEMPEGOWDA INTERNATIONAL AIRPORT," +
                         "\r\n" +
                               "Bengaluru, Devaganahalli," +
                               "\r\n" +
                               "Bengaluru Rural, Karnataka, 560300";

        Logo = new Uri(Server.MapPath("~/images/Company_Logo/Denken.png")).AbsoluteUri;

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
        ReportParameter p4 = new ReportParameter("LOGO1", QR_Image);

        
        ReportParameter[] p = { p1, p2, p3, p4 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }

    private void load_eri00265()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_ATLANTIC.rdlc";


        CompanyName = "ATLANTIC SHIPPING & LOGISTICS";
        Company_Add = "Office No. 150, 1st Floor, A Wing" +
                        "\r\n" +
                        "Balaji Bhavan, Plot no. 42A," +
                        "\r\n" +
                        "Sector 11 CBD Belapur" +
                        "\r\n" +
                         "Navi Mumbai - 400 614 " +
                        "\r\n" +
                        "Ph: 022 2757 0046 | HP: 9167910045/8369341835";

        ServiceTaxno = " 27AAYFA8014A1ZI";
        Pan_No = " AAYFA8014A";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/ATLANTIC.png")).AbsoluteUri;

        LOGO1 = new Uri(Server.MapPath("~/images/Company_Logo/ATLANTIC.png")).AbsoluteUri;

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

        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_VSM.rdlc";

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

    private void load_eri00287()
    {
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";

        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_FALCONAIR.rdlc";



        CompanyName = "FALCONAIR SERVICES INDIA PVT.LTD";
        Company_Add = "NEW NO.216, OLD NO.226, 3A, 3RD FLOOR," +
                        "\r\n" +
                        "THAMBU CHETTY STREET," +
                         "\r\n" +
                               "CHENNAI – 600 001" +
                                "\r\n" +
                                 "PHONE NO: 9884489115,044 25264005" +
                                  "\r\n" +
                                 "EMAIL :accounts@falconair.co.in" +
                                  "\r\n" +
                                 "krajaram@falconair.co.in";

        ServiceTaxno = "33AACFXXX00P2ZE";
        Pan_No = " ";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/FalconAirlogo.png")).AbsoluteUri;

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

        ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        Remarks = dss.Tables[0].Rows[0]["REMARKS"].ToString();

        if (dss.Tables[2].Rows.Count > 0)
            if (dss.Tables[1].Rows.Count > 0)
            {
                {
                    if (dss.Tables[1].Rows[0]["CUR"].ToString() == "USD" || dss.Tables[1].Rows[0]["CUR"].ToString() == "AUD" || dss.Tables[1].Rows[0]["CUR"].ToString() == "SGD")
                    {
                        Inwords = dss.Tables[2].Rows[0]["Word_USD"].ToString();

                        if (Inwords.Contains("ONLY"))
                        {
                            string[] sp = dss.Tables[2].Rows[0]["Word"].ToString().Split(' ');
                            int count1 = sp.Count();

                            int count = 0;
                            int cur_pos = 0;
                            string Paise_cents = "";

                            for (int ii = 0; ii <= count1 - 1; ii++)
                            {
                                if (sp[ii] == "RUPEES")
                                {
                                    count += 1;
                                    cur_pos = ii;
                                }
                            }

                            if (cur_pos > 0)
                            {
                                for (int xx = cur_pos + 1; xx <= count1 - 1; xx++)
                                {
                                    Paise_cents += sp[xx] + " ";
                                }

                                string aa = Inwords.Replace("ONLY.", " DOLLARS ") + Paise_cents;
                                string FINAL = aa.Replace("PAISE", "CENTS ");
                                Inwords = FINAL;
                            }
                            else
                            {
                                Inwords = "ZERO DOLLARS ONLY.";
                            }
                        }
                    }
                    else if (dss.Tables[1].Rows[0]["CUR"].ToString() == "GBP")
                    {
                        Inwords = dss.Tables[2].Rows[0]["Word_USD"].ToString();

                        if (Inwords.Contains("ONLY"))
                        {
                            string[] sp = dss.Tables[2].Rows[0]["Word"].ToString().Split(' ');
                            int count1 = sp.Count();

                            int count = 0;
                            int cur_pos = 0;
                            string Paise_cents = "";

                            for (int ii = 0; ii <= count1 - 1; ii++)
                            {
                                if (sp[ii] == "RUPEES")
                                {
                                    count += 1;
                                    cur_pos = ii;
                                }
                            }

                            if (cur_pos > 0)
                            {
                                for (int xx = cur_pos + 1; xx <= count1 - 1; xx++)
                                {
                                    Paise_cents += sp[xx] + " ";
                                }

                                string aa = Inwords.Replace("ONLY.", " POUNDS ") + Paise_cents;
                                string FINAL = aa.Replace("PAISE", "STERLING ");
                                Inwords = FINAL;
                            }
                            else
                            {
                                Inwords = "ZERO POUND ONLY.";
                            }
                        }
                    }

                    else if (dss.Tables[1].Rows[0]["CUR"].ToString() == "EUR")
                    {
                        Inwords = dss.Tables[2].Rows[0]["Word_USD"].ToString();

                        if (Inwords.Contains("ONLY"))
                        {
                            string[] sp = dss.Tables[2].Rows[0]["Word"].ToString().Split(' ');
                            int count1 = sp.Count();

                            int count = 0;
                            int cur_pos = 0;
                            string Paise_cents = "";

                            for (int ii = 0; ii <= count1 - 1; ii++)
                            {
                                if (sp[ii] == "RUPEES")
                                {
                                    count += 1;
                                    cur_pos = ii;
                                }
                            }

                            if (cur_pos > 0)
                            {
                                for (int xx = cur_pos + 1; xx <= count1 - 1; xx++)
                                {
                                    Paise_cents += sp[xx] + " ";
                                }

                                string aa = Inwords.Replace("ONLY.", " EURO ") + Paise_cents;
                                string FINAL = aa.Replace("PAISE", "CENT ");
                                Inwords = FINAL;
                            }
                            else
                            {
                                Inwords = "ZERO EURO ONLY.";
                            }
                        }
                    }



                    else if (dss.Tables[1].Rows[0]["CUR"].ToString() == "JPY")
                    {
                        Inwords = dss.Tables[2].Rows[0]["Word_USD"].ToString();

                        if (Inwords.Contains("ONLY"))
                        {
                            string[] sp = dss.Tables[2].Rows[0]["Word"].ToString().Split(' ');
                            int count1 = sp.Count();

                            int count = 0;
                            int cur_pos = 0;
                            string Paise_cents = "";

                            for (int ii = 0; ii <= count1 - 1; ii++)
                            {
                                if (sp[ii] == "RUPEES")
                                {
                                    count += 1;
                                    cur_pos = ii;
                                }
                            }

                            if (cur_pos > 0)
                            {
                                for (int xx = cur_pos + 1; xx <= count1 - 1; xx++)
                                {
                                    Paise_cents += sp[xx] + " ";
                                }

                                string aa = Inwords.Replace("ONLY.", " YEN ") + Paise_cents;
                                string FINAL = aa.Replace("PAISE", "SEN ");
                                Inwords = FINAL;
                            }
                            else
                            {
                                Inwords = "ZERO EURO ONLY.";
                            }
                        }
                    }




                    else
                    {
                        if (dss.Tables[2].Rows[0]["Wordr"].ToString() != " ONLY.")
                        {
                            Inwords = dss.Tables[2].Rows[0]["Wordr"].ToString();
                        }
                        else
                        {
                            Inwords = "ZERO RUPEE ONLY.";
                        }
                    }
                }
            }

        ReportParameter p1 = new ReportParameter("Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Address", Company_Add);
        ReportParameter p3 = new ReportParameter("ServiceTaxno", ServiceTaxno);
        ReportParameter p4 = new ReportParameter("Remarks", Remarks);
        ReportParameter p5 = new ReportParameter("Logo", Logo);
        ReportParameter p6 = new ReportParameter("TaxMode", TaxMode);
        ReportParameter p7 = new ReportParameter("Pan_No", Pan_No);
        ReportParameter p8 = new ReportParameter("Inwords", Inwords);
        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8 };
        ReportViewer1.LocalReport.SetParameters(p);
        Report_Print();
    }
    private void load_eri00314()
    {
        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        //localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_Sab.rdlc";

        if (dss.Tables[0].Rows[0]["TAX_NONTAX"].ToString() == "DEBIT NOTE")
        {
            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_Sab_Debit_Note.rdlc";
        }
        else
        {
            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_Sab.rdlc";
        }

        CompanyName = "SAABARI LOGISTICS PRIVATE LTD";
        Company_Add = "WAVOO MANSION, 5TH FLOOR," +
                        "\r\n" +
                        "NO: 58/39, RAJAJI SALAI," +
                         "\r\n" +
                               "CHENNAI - 600001." +
                                "\r\n" +
                                 "LANDMARK - UNION BANK OF INDIA." +
                                  "\r\n" +
                                 "PH: 2526 0628, 2521 5588" +
                                  "\r\n" +
                                 "EMAIL:info@Saabarilogistics.com  FAX:2526 0415";

        ServiceTaxno = "AAFCS2437PST001";
        Pan_No = "AAFCS2437P";
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
        ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");

        string Inv_No = string.Empty, Inv_Date = string.Empty, Net_Amt = string.Empty, Amt_words = string.Empty, Tot_Inv_Val = string.Empty,
               Inv_Type = string.Empty, Remarks = string.Empty;

        if (dss.Tables[0].Rows.Count > 0)
        {
            Inv_No = dss.Tables[0].Rows[0]["BILL_INV_NO"].ToString();
            Inv_Date = dss.Tables[0].Rows[0]["BILL_INV_DATE"].ToString();
            Inv_Type = dss.Tables[0].Rows[0]["TAX_NONTAX"].ToString();
            Remarks = dss.Tables[0].Rows[0]["REMARKS"].ToString();

        }

        if (dss.Tables[2].Rows.Count > 0)
        {
            Tot_Inv_Val = dss.Tables[2].Rows[0]["Tot_Inv_Val"].ToString();
        }

        ReportParameter p1 = new ReportParameter("Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Address", Company_Add);
        ReportParameter p3 = new ReportParameter("ServiceTaxno", ServiceTaxno);

        ReportParameter p4 = new ReportParameter("Inv_No", Inv_No);
        ReportParameter p5 = new ReportParameter("Inv_Date", Inv_Date);
        ReportParameter p6 = new ReportParameter("Logo", Logo);
        ReportParameter p7 = new ReportParameter("Pan_No", Pan_No);
        ReportParameter p8 = new ReportParameter("Tot_Inv_Val", Tot_Inv_Val);
        ReportParameter p9 = new ReportParameter("Inv_Type", Inv_Type);
        ReportParameter p10 = new ReportParameter("Remarks", Remarks);

        if (dss.Tables[0].Rows[0]["TAX_NONTAX"].ToString() == "DEBIT NOTE")
        {
            ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 };
            ReportViewer1.LocalReport.SetParameters(p);
        }
        else
        {
            ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8, p9 };
            ReportViewer1.LocalReport.SetParameters(p);
        }

        Report_Print();
    }
    private void load_eri00353()
    {
        string base64string = "";
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;
        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);

        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_ENSEN.rdlc";
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
    private void load_eri00354()
    {
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);

        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_LKS.rdlc";

        //CompanyName = "LKS GLOBAL SUPPLY CHAIN";
        //Company_Add = "NO.101 BLDG No.H2/20F" +
        //                    "\r\n" +
        //                    "MAHAVIR ENCLAVE - PART-I," +
        //                     "\r\n" +
        //                         "NEW DELHI - 110045" +
        //                             "\r\n" +
        //                             "PHONE NO: 9769461719" +
        //                              "\r\n" +
        //                             "GST NO:07AFRPN9954J2ZG" +
        //                              "\r\n" +
        //                             "PAN NO: AFRPN9954J" +
        //                               "\r\n" +
        //                               "EMAIL :info@lksglobal.in" +
        //                                "\r\n" +
        //                             "WEBSITE: www.lksglobal.in";

        //ServiceTaxno = "07AFRPN9954J2ZG";
        //Pan_No = "AFRPN9954J";

        CompanyName = "LKS GLOBAL SUPPLY CHAIN PVT LTD";
        Company_Add = "NO.Shop No.207, 2nd Floor Capital Chambers" +
        "\r\n" +
        "(Vardhaman Entrance Plaza) Dwarka Sec 1A," +
        "\r\n" +
        "NEW DELHI - 110045." +
        "\r\n" +
        "PHONE NO: 9555849266" +
        "\r\n" +
        "GST NO:07AADCL8030H1ZM" +
        "\r\n" +
        "PAN NO: AADCL8030H" +
        "\r\n" +
        "EMAIL :lksglobalpdelhi@gmail.com" +
        "\r\n" +
        "WEBSITE: www.lksglobal.in";

        ServiceTaxno = "07AADCL8030H1ZM";
        Pan_No = "AADCL8030H";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/LKS.png")).AbsoluteUri;

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

        ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        Remarks = dss.Tables[0].Rows[0]["REMARKS"].ToString();

        ReportParameter p1 = new ReportParameter("Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Address", Company_Add);
        ReportParameter p3 = new ReportParameter("ServiceTaxno", ServiceTaxno);
        ReportParameter p4 = new ReportParameter("Remarks", Remarks);
        ReportParameter p5 = new ReportParameter("Logo", Logo);
        ReportParameter p6 = new ReportParameter("TaxMode", TaxMode);
        ReportParameter p7 = new ReportParameter("Pan_No", Pan_No);

        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();
    }
    private void load_eri00375()
    {
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_SUBRAMANY_LOG.rdlc";

        CompanyName = "SUBRAMANY LOGISTICS PVT LTD";
        Company_Add = "(An ISO 9001:2008 Certified Company)" +
                        "\r\n" +
                        "Old No.09 & 10, New No.24 & 26," +
                         "\r\n" +
                               "New Colony, Tuticorin – 628003." +
                                "\r\n" +
                                 "Tel : 0461 – 4550155 / 156" +
                                  "\r\n" +
                                 "Fax : 0461 – 4550157" +
                                  "\r\n" +
                                 "Web : www.subramany.com";

        ServiceTaxno = "33AAQCS2889E1ZY";
        Pan_No = " ";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/Submani_log.jpg")).AbsoluteUri;

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

        ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        Remarks = dss.Tables[0].Rows[0]["REMARKS"].ToString();

        ReportParameter p1 = new ReportParameter("Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Address", Company_Add);
        ReportParameter p3 = new ReportParameter("ServiceTaxno", ServiceTaxno);
        ReportParameter p4 = new ReportParameter("Remarks", Remarks);
        ReportParameter p5 = new ReportParameter("Logo", Logo);
        ReportParameter p6 = new ReportParameter("TaxMode", TaxMode);
        ReportParameter p7 = new ReportParameter("Pan_No", Pan_No);

        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();
    }
    private void load_eri00381()
    {
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;
        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);

        if (dss.Tables[3].Rows.Count > 0)
        {
            if (dss.Tables[3].Rows[0]["IEC_NO"].ToString() == "0488001391")
            {
                localReport.ReportPath = @"Billing_Imp_Rpt/GST_Bill_Export_Job_rpt_Pioneer_MRF.rdlc";
            }
            else
            {
                localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_Pioneer.rdlc";
            }
        }
        else
        {
            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_Pioneer.rdlc";
        }

        CompanyName = "PIONEER SERVICES";
        Company_Add = "56-57, RAJAJI SALAI, 2ND FLOOR," +
                        "\r\n" +
                               "CHENNAI - 600001." +
                                "\r\n" +
                                 "PHONE NO: 044-25225636,25271401,25270933" +
                                  "\r\n" +
                                 "EMAIL :pioneerscha@gmail.com,accounts@pioneerscha.com";


        ServiceTaxno = "AAFCS2437PST001";
        Pan_No = "AAFCS2437P";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/pioneer_logo.jpg")).AbsoluteUri;


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

        ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");

        string Inv_No = string.Empty, Inv_Date = string.Empty, Net_Amt = string.Empty, Amt_words = string.Empty, Tot_Rev_Amt = string.Empty
        , User_ID = string.Empty;


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

        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8, p9,  p11 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();
    }
    private void load_eri00382()
    {
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_ACFA.rdlc";
        CompanyName = "ACFA LOGISTICS PVT LTD";
        Company_Add = "No.75.Spurtank Road,Chetpet," +
                        "\r\n" +
                               "Chennai – 600031." +
                                "\r\n" +
                                 "Phone : 044-28362862,63,64,65,69 Extn: 333" +
                                  "\r\n" +
                                 "EMAIL :www.acfalogistics.com";
        ServiceTaxno = "AAFCS2437PST001";
        Pan_No = "AAFCS2437P";
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

        ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");


        string Inv_No = string.Empty, Inv_Date = string.Empty, Net_Amt = string.Empty, Amt_words = string.Empty, Tot_Rev_Amt = string.Empty
        , User_ID = string.Empty;


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

        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p11 };
        ReportViewer1.LocalReport.SetParameters(p);
        Report_Print();
    }
    private void load_eri00384()
    {
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_PK.rdlc";


        CompanyName = "P.K. LOGISTICS";
        Company_Add = "Plot No.19/28,GF-04," +
                         "\r\n" +
                         "Tokas Complex Nr Fun'N'Food Village," +
                          "\r\n" +
                                "Kapashera,New Delhi-37 " +
                                 "\r\n" +
                                  "PHONE NO: 91-11-25062193/9810028528" +
                                   "\r\n" +
                                  "EMAIL :pklogistics@rediffmail.com " +
                                    "\r\n" +
                                   "GSTN NO: 07ACXPS4901K1ZX";


        ServiceTaxno = "07ACXPS4901K1ZX";
        Pan_No = "ACXPS4901K ";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/pk logis.png")).AbsoluteUri;

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

        ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        Remarks = dss.Tables[0].Rows[0]["REMARKS"].ToString();

        ReportParameter p1 = new ReportParameter("Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Address", Company_Add);
        ReportParameter p3 = new ReportParameter("ServiceTaxno", ServiceTaxno);
        ReportParameter p4 = new ReportParameter("Remarks", Remarks);
        ReportParameter p5 = new ReportParameter("Logo", Logo);
        ReportParameter p6 = new ReportParameter("TaxMode", TaxMode);
        ReportParameter p7 = new ReportParameter("Pan_No", Pan_No);

        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();
    }
    private void load_eri00399()
    {
        string base64string = "";
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        string IsTransportBill = "";
        if (dss.Tables[3].Rows.Count > 0)
        {
            string base64string1 = dss.Tables[3].Rows[0]["SignedQRCodeImage"].ToString();
            //string base64string = base64string1.Substring(base64string1.IndexOf("Submission"));
            if (base64string1.Length > 0)
            {
                base64string = base64string1.Substring(base64string1.IndexOf("Submission"));
            }
        }
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_PAS.rdlc";
        if (dss.Tables[0].Rows.Count > 0)
        {
            IsTransportBill = dss.Tables[0].Rows[0]["BILL_INV_NO"].ToString();
            IsTransportBill = IsTransportBill.Substring(5, 1);
        }
        if (IsTransportBill == "T")
        {
            CompanyName = "PAS TRANSPORT";
            Company_Add = "No.39/ 77 2nd Floor, Thambu Chetty St, Parrys Chennai -600 001." +
                            "\r\n" +
                                   "Ph: 044-4210 8285 E-Mail: accounts@paslogistics.co.in; kvprija@gmail.com;" +
                                    "\r\n" +
                                     "GST No : 33AXLPP1153H2ZI PAN No : ";

            ServiceTaxno = " 33AXLPP1153H2ZI";
            Pan_No = " ";
        }
        else
        {
            CompanyName = "PAS LOGISTICS";
            Company_Add = "No.39/ 77 2nd Floor, Thambu Chetty St, Parrys Chennai -600 001." +
                            "\r\n" +
                                   "Ph: 044-4210 8285 E-Mail: accounts@paslogistics.co.in; kvprija@gmail.com;" +
                                    "\r\n" +
                                     "GST No : 33AAUFP4696B1ZW PAN No : AAUFP4696B";

            ServiceTaxno = " 33AAUFP4696B1ZW";
            Pan_No = " AAUFP4696B";
        }
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/PAS.png")).AbsoluteUri;
        if (base64string.Length > 0)
        {
            LOGO1 = new Uri(Server.MapPath("~/" + base64string)).AbsoluteUri;
        }
        else { LOGO1 = new Uri(Server.MapPath("~/images/txtbox-mid_90px.png")).AbsoluteUri; }

        LOGO2 = new Uri(Server.MapPath("~/images/Company_Logo/PAS_AEO_ISO.png")).AbsoluteUri;


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
    private void load_eri00406()
    {
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        if (Current_Branch == "ACC, Chennai" || Current_Branch == "CusHouse, Chennai" || Current_Branch == "Customs, KATTUPALLI")
        {
            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_RKL.rdlc";
            CompanyName = "RKL SHIPPING & LOGISTICS PRIVATE LTD";
            Company_Add = "NO.231, Dr.RAJIVI TOWERS," +
                                    "\r\n" +
                                    "SUIT NO.G3, GROUND FLOOR," +
                                     "\r\n" +
                                    "PURASAWALKAM HIGH ROAD, CHENNAI-600007." +
                                     "\r\n" +
                                     "PHONE NO:044-26481263, 26481264, 43099934" +
                                        "\r\n" +
                                          "EMAIL :admin@rklshipping.com" +
                                           "\r\n" +
                                           "impex@rklshipping.com" +
                                           "\r\n" +
                                       "GSTIN NO:33AAICR5265R1ZO" +
                                            "\r\n" +
                                             "WEBSITE : www.rklshipping.com";
            ServiceTaxno = "33AAICR5265R1ZO";
            Pan_No = " ";
        }
        else if (Current_Branch == "ICD, Hyderabad")
        {

            localReport.ReportPath = @"Billing_Imp_Rpt/GST_Bill_Import_Job_rpt_RKL_Hyderabad.rdlc";
            CompanyName = "RKL SHIPPING & LOGISTICS PRIVATE LTD";
            Company_Add = "2ND FLOOR, SUIT NO.213, MITTAL CHAMBERS," +
                               "\r\n" +
                               "M G ROAD, OPP. RAMGOPALAPET POLICE STATION," +
                                "\r\n" +
                                "SECUNDERABAD, HYDERABAD, TELANGANA-500003." +
                                   "\r\n" +
                                   "PHONE NO:040-27807721 MOB NO:8939840509" +
                                   "\r\n" +
                                     "EMAIL :impex@rklshipping.com" +
                                      "\r\n" +
                                  "GSTIN NO:36AAICR5265R1ZI" +
                                       "\r\n" +
                                        "WEBSITE : www.rklshipping.com";
            ServiceTaxno = "36AAICR5265R1ZI";
            Pan_No = " ";
        }

        Logo = new Uri(Server.MapPath("~/images/Company_Logo/RKL.bmp")).AbsoluteUri;
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

        ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        Remarks = dss.Tables[0].Rows[0]["REMARKS"].ToString();

        ReportParameter p1 = new ReportParameter("Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Address", Company_Add);
        ReportParameter p3 = new ReportParameter("ServiceTaxno", ServiceTaxno);
        ReportParameter p4 = new ReportParameter("Remarks", Remarks);
        ReportParameter p5 = new ReportParameter("Logo", Logo);
        ReportParameter p6 = new ReportParameter("TaxMode", TaxMode);
        ReportParameter p7 = new ReportParameter("Pan_No", Pan_No);

        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();
    }

    private void load_eri00420()
    {
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);

        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_SAGAR.rdlc";
        CompanyName = "SAGAR SHIPPING SERVICES";
        Company_Add = "121-A Near Om Gas Agency," +
                        "\r\n" +
                        "Jhalana, Malviya Nagar," +
                         "\r\n" +
                               "Jaipur 302017. " +
                                "\r\n" +
                                 "PHONE NO: 09879091534,9909427007" +
                                  "\r\n" +
                                 "EMAIL :sssganesham@gmail.com " +
                                  "\r\n" +
                                 "GSTN NO: 08ALRPC8469P1Z1";
        ServiceTaxno = " 08ALRPC8469P1Z1";
        Pan_No = " ALRPC8469P ";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/SAGAR.jpg")).AbsoluteUri;
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

        ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        Remarks = dss.Tables[0].Rows[0]["REMARKS"].ToString();

        ReportParameter p1 = new ReportParameter("Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Address", Company_Add);
        ReportParameter p3 = new ReportParameter("ServiceTaxno", ServiceTaxno);
        ReportParameter p4 = new ReportParameter("Remarks", Remarks);
        ReportParameter p5 = new ReportParameter("Logo", Logo);
        ReportParameter p6 = new ReportParameter("TaxMode", TaxMode);
        ReportParameter p7 = new ReportParameter("Pan_No", Pan_No);

        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();
    }
    private void load_eri00422()
    {
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;
        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        if (dss.Tables[3].Rows.Count > 0)
        {
            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_SYNDICATE.rdlc";
        }
        else
        {
            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_SYNDICATE.rdlc";
        }
        CompanyName = "SYNDICATE SHIPPING SERVICES PVT LTD";
        Company_Add = "NO:204,Thambu Chetty Street,Parrys" +
                        "\r\n" +
                               "CHENNAI-600001." +
                                "\r\n" +
                                 "PHONE NO: 044-25230512,25230513,25230514" +
                                  "\r\n" +
                                 "EMAIL :syndicate@syndicateshipping.com";


        ServiceTaxno = "33AABCS0309L1ZN";
        Pan_No = "AABCS0309L";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/syndicate.png")).AbsoluteUri;

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

        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p11 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();
    }
    private void load_eri00230()
    {
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;
        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);

        if (dss.Tables[3].Rows.Count > 0)
        {


            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_PARAMOUNT.rdlc";

        }
        else
        {
            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_PARAMOUNT.rdlc";
        }

        CompanyName = "PARAMOUNT SHIPPING SERVICES PVT LTD";
        Company_Add = "163, THAMBUCHETTY STREET, 3RD FLOOR," +
                        "\r\n" +
                               "CHENNAI - 600001." +
                                "\r\n" +
                                 "PHONE NO: 42248888,42061130,42061135" +
                                  "\r\n" +
                                 "EMAIL :accounts@paramountship.com" +
                                     "\r\n" +
                                    "WEBSITE:www.paramountship.com";

        ServiceTaxno = "33AAECP5649R1ZQ";
        Pan_No = "AAECP5649R";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/paramount.png")).AbsoluteUri;


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

        ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");

        string Inv_No = string.Empty, Inv_Date = string.Empty, Net_Amt = string.Empty, Amt_words = string.Empty, Tot_Rev_Amt = string.Empty
        , User_ID = string.Empty;


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

        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p11 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();
    }
    private void load_eri00350()
    {
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;
        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);

        if (dss.Tables[3].Rows.Count > 0)
        {


            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_PARAMOUNT_350.rdlc";

        }
        else
        {
            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_PARAMOUNT_350.rdlc";
        }

        CompanyName = "PARAMOUNT SHIPPING SERVICES PVT LTD";
        Company_Add = "NO:35,1ST FLOOR,4TH MAIN," +
                        "\r\n" +
                        "KONENA AGRAHARA,HAL AIRPORT ROAD," +
                        "\r\n" +
                               "BANGALORE-560017." +
                                "\r\n" +
                                 "PHONE NO: 42248888,42031135" +
                                     "\r\n" +
                                    "WEBSITE:www.paramountship.com";

        ServiceTaxno = "29AAECP5649R1ZF";
        Pan_No = "AAECP5649R";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/paramount.png")).AbsoluteUri;


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

        ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");

        string Inv_No = string.Empty, Inv_Date = string.Empty, Net_Amt = string.Empty, Amt_words = string.Empty, Tot_Rev_Amt = string.Empty
        , User_ID = string.Empty;


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

        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p11 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();
    }

    private void load_eri00408()
    {
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;
        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);

        if (dss.Tables[3].Rows.Count > 0)
        {


            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_PARAMOUNT.rdlc";

        }
        else
        {
            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_PARAMOUNT.rdlc";
        }

        CompanyName = "PARAMOUNT SHIPPING SERVICES PVT LTD";
        Company_Add = "163, THAMBUCHETTY STREET, 3RD FLOOR," +
                        "\r\n" +
                               "CHENNAI - 600001." +
                                "\r\n" +
                                 "PHONE NO: 42248888,42061130,42061135" +
                                  "\r\n" +
                                 "EMAIL :accounts@paramountship.com" +
                                     "\r\n" +
                                    "WEBSITE:www.paramountship.com";

        ServiceTaxno = "33AAECP5649R1ZQ";
        Pan_No = "AAECP5649R";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/paramount.png")).AbsoluteUri;


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

        ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");

        string Inv_No = string.Empty, Inv_Date = string.Empty, Net_Amt = string.Empty, Amt_words = string.Empty, Tot_Rev_Amt = string.Empty
        , User_ID = string.Empty;


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

        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p11 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();
    }
    private void load_eri00427()
    {
        string LOGO1 = "", base64string = "", base64string1 = "";
        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_AS_VASAN.rdlc";
        CompanyName = "A.S. VASAN SHIPPING SERVICES PRIVATE LIMITED";
        Company_Add = "New # 325, (Old # 158)," +
                        "\r\n" +
                        "Linghi Chetty Street,3rd Floor," +
                         "\r\n" +
                               "Chennai - 600001" +
                                "\r\n" +
                                 "PHONE NO: 91- 44-25330790" +
                                  "\r\n" +
                                 "Mobile : +91 90941 49522 /88259 41745";


        //ServiceTaxno = " 33AAICA5584A2ZX";
        //Pan_No = " AAICA5584A";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/AS_vasan.jpg")).AbsoluteUri;
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
        ReportDataSource datasource4 = new ReportDataSource("DataSet5", dss.Tables[5]);
        ReportViewer1.LocalReport.DataSources.Add(datasource4);

        if (dss.Tables[5].Rows.Count > 0)
        {
            base64string1 = dss.Tables[5].Rows[0]["SignedQRCodeImage"].ToString();
        }
        if (base64string1.Length > 0)
        {
            base64string = base64string1.Substring(base64string1.IndexOf("Submission"));
        }
        if (base64string.Length > 0)
        {
            LOGO1 = new Uri(Server.MapPath("~/" + base64string)).AbsoluteUri;
        }
        else { LOGO1 = new Uri(Server.MapPath("~/images/txtbox-mid_90px.png")).AbsoluteUri; }
        ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");

        ReportParameter p1 = new ReportParameter("Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Address", Company_Add);
        ReportParameter p3 = new ReportParameter("Logo", Logo);
        ReportParameter p4 = new ReportParameter("Bill_Type", dss.Tables[4].Rows[0][0].ToString());
        ReportParameter p5 = new ReportParameter("LOGO1", LOGO1);

        ReportParameter[] p = { p1, p2, p3, p4, p5 };
        ReportViewer1.LocalReport.SetParameters(p);
        Report_Print();
    }
    private void load_eri00438()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";

        if (dss.Tables[0].Rows[0]["BILL_TYPE"].ToString() == "L")
        {
            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_SYNERGY_GLOBAL_LOCAL.rdlc";
        }
        //else if (dss.Tables[0].Rows[0]["BILL_TYPE"].ToString() == "O")
        else
        {
            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_SYNERGY_GLOBAL_OTHER.rdlc";
        }
        //else
        //{
        //    localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_SYNERGY_GLOBAL.rdlc";
        //}


        CompanyName = "Synergy Global Logistics Pvt Ltd";
        Company_Add = "1201, Mayuresh Cosmos, Plot No. 37, Sector-11 CBD Belapur, Navi Mumbai 400614. India" +
                        "\r\n" +
                               "Ph: 022 49232626 Email: info@synergyglobal.co.in Web: www.synergyglobal.co.in" +
                                "\r\n" +
                                 "CIN: U63090MH2016PTC281263 STATE: [27] MAHARASHTRA / GSTIN: 27AAXCS0682E1ZX";


        ServiceTaxno = "27AAXCS0682E1ZX";
        Pan_No = "AAXCS0682E";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/SYNERGY_GLOBAL.jpg")).AbsoluteUri;

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


        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }
    private void load_eri00464()
    {
       
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_RR_LOGISTICS.rdlc";


        CompanyName = "RR LOGISTICS AND SHIPPING SERVICES PVT. LTD.";
        Company_Add = "International Freight Forwarder, Shipping & Clearing" +
                        "\r\n" +
                        "No.17/2A, Thiruvalluvar Street," +
                         "\r\n" +
                               "Lakshmi Puram, Chennai - 99." +
                        "\r\n" +
                        "Tel: 044 - 2565 4505 Mob: 9940300177" +
                        "\r\n" +
                        "Email: suresh@rrlogistis.co.in, prabhuraj@rrlogistics.co.in";


        ServiceTaxno = " ";
        Pan_No = " ";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/RR_LOGISTICS_LOGO.jpg")).AbsoluteUri;
        Bank_Name = "UNION BANK OF INDIA";
        Bank_Branch = "ARMENIAN STREET, CHENNAI – 600001";
        ACCTYPE = "CURRENT";
        ACCNO = "527404040000001";
        IFSC = "UBIN0552747";

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

        ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        //Remarks = dss.Tables[0].Rows[0]["REMARKS"].ToString();
        //STATE_NAME = dss.Tables[0].Rows[0]["STATE_NAME"].ToString();

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
        ReportParameter p9 = new ReportParameter("Bank_Name", Bank_Name);
        ReportParameter p10 = new ReportParameter("Bank_Branch", Bank_Branch);
        ReportParameter p11 = new ReportParameter("ACCTYPE", ACCTYPE);
        ReportParameter p12 = new ReportParameter("ACCNO", ACCNO);
        ReportParameter p13 = new ReportParameter("IFSC", IFSC);
        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13 };
        ReportViewer1.LocalReport.SetParameters(p);
        Report_Print();

    }

    private void load_eri00480()
    {
        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        if (dss.Tables[0].Rows.Count > 0)
        {
            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_SANCO.rdlc";
        }

        CompanyName = "Sanco Trans Limited";
        Company_Add = "56-57, RAJAJI SALAI, 2ND FLOOR," +
                        "\r\n" +
                               "CHENNAI - 600001." +
                                "\r\n" +
                                 "PHONE NO: 044-25225636,25271401,25270933" +
                                  "\r\n" +
                                 "EMAIL :pioneerscha@gmail.com,pioneers@airtelmail.in";



        Logo = new Uri(Server.MapPath("~/images/Company_Logo/pioneer_logo.jpg")).AbsoluteUri;


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

        ReportParameter[] p = { p1 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }
    private void load_eri01176()
    {
        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        if (dss.Tables[0].Rows.Count > 0)
        {
            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_SANCO_KOVAI.rdlc";
        }

        CompanyName = "Sanco Trans Limited";
        Company_Add = "56-57, RAJAJI SALAI, 2ND FLOOR," +
                        "\r\n" +
                               "CHENNAI - 600001." +
                                "\r\n" +
                                 "PHONE NO: 044-25225636,25271401,25270933" +
                                  "\r\n" +
                                 "EMAIL :pioneerscha@gmail.com,pioneers@airtelmail.in";



        Logo = new Uri(Server.MapPath("~/images/Company_Logo/pioneer_logo.jpg")).AbsoluteUri;


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

        ReportParameter[] p = { p1 };
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
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_SGSL.rdlc";


        CompanyName = "SHREE GANESH SHIPPING AND LOGISTICS";
        //Company_Add = "Office No - 103, 1st Floor, Plot no 108, K. Sons Complex," +
        //                "\r\n" +
        //                       "Sector 8, Gandhidham - Kutch, Gujarat - 370201" +
        //                        "\r\n" +
        //                         "Ph: (02836) 232541/42  MOB: +91 90999 50844" +
        //                          "\r\n" +
        //                         "E-mail: shreeganeshshippingandlogsitic@gmail.com";
        Company_Add = "Plot No. 312, Second Floor, Near Avon Bakery, " +
                        "\r\n" +
                               "Sector 1A, Gandhidham, Kachchh Dt, Gujarat - 370201. " +
                                "\r\n" +
                                 "Ph: (02836) 232541/42  MOB: +91 90999 50844" +
                                  "\r\n" +
                                 "E-mail: shreeganeshshippingandlogisitic@gmail.com";



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

        byte[] bytes = (byte[])Session["report"];
        Response.ClearHeaders();
        Response.Clear();

        Response.ContentType = "application/pdf";
        string File_name = "IMPINV" + (ViewState["File_Name"].ToString()).Replace("-", "").Replace("/", "").Replace("_", "");
        Response.AddHeader("content-disposition", "attachment;filename=" + File_name + ".pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.BinaryWrite(bytes);
        Response.End();


    }

    private void load_eri00510()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_TOPSWA_LOGISTICS.rdlc";


        CompanyName = "TOPSWA LOGISTICS";
        Company_Add = "New No.8(Old No.19)," +
                       "\r\n" +
                       "Flot No.3,2nd Cross Street,Kalaimagal Nagar," +
                        "\r\n" +
                              "Ekkattuthangal,Chennai-600 032 " +
                               "\r\n" +
                                "PHONE NO: 044-4266 9886" +
                                 "\r\n" +
                                "EMAIL :admin@royaltechsystems.co.in" +
                                 "\r\n" +
                                "sales@royaltechsystems.co.in";

        ServiceTaxno = "AAAXX0005HST001";
        Pan_No = "AAAXX0005H";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/TOPSWA_LOGISTICS.JPG")).AbsoluteUri;

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


        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }

    private void load_eri00517()
    {
        QR_Image = " ";
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);        
        hd_BILL_No_JOB_No.Value = ObjUBO.BILL_INV_NO + "-" + dss.Tables[0].Rows[0]["LIZMA_JOBNO"].ToString();
        string TaxMode = " ";
        if (dss.Tables[3].Rows.Count > 0)
        {
            QRImage_path = QR_Imagepath(dss.Tables[3].Rows[0]["SignedQRCode"].ToString(), ddlJob_No.SelectedValue.ToString().Replace('/', '_'));
            if (QRImage_path != " ")
            {
                QR_Image = new Uri(QRImage_path).AbsoluteUri;
            }
        }
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_LIZMA_LOGISTICS_TIRUPUR.rdlc";


        CompanyName = "LIZMA LOGISTICS PVT LTD";

        if (ObjUBO.BILL_INV_NO.ToString().Substring(4, 1) == "T")
        {
            Company_Add = "NO.29, N.S.P.NAGAR," +
                            "\r\n" +
                                   "THIRUMURUGAN POONDI & POST," +
                                    "\r\n" +
                                    "TIRUPUR-641652" +
                                      "\r\n" +
                                    "HP:9841269777     HP:9551693617" +
                                          "\r\n" +
                                    "E.mail: giri@lizmalogistics.net; ananth@lizmalogistics.net";

        }

        else if (ObjUBO.BILL_INV_NO.ToString().Substring(4, 1) == "C")
        {
            Company_Add = "No.2, Moore Street, 1st Floor," +
                            "\r\n" +
                                   "Mannady, " +
                                    "\r\n" +
                                    "Chennai-600001." +
                                      "\r\n" +
                                    "HP:9841269777   HP:9551693617" +
                                          "\r\n" +
                                    "E.mail: giri@lizmalogistics.net; ananth@lizmalogistics.net";

        }
        else
        {
            Company_Add = "NO.29, N.S.P.NAGAR," +
                            "\r\n" +
                                   "THIRUMURUGAN POONDI & POST," +
                                    "\r\n" +
                                    "TIRUPUR-641652" +
                                      "\r\n" +
                                    "HP:9841269777     HP:9551693617" +
                                          "\r\n" +
                                    "E.mail: giri@lizmalogistics.net; ananth@lizmalogistics.net";


        }


        ServiceTaxno = "33AABCL3369B1ZX";
        Pan_No = " AABCL3369B";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/LIZMA.jpg")).AbsoluteUri;

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

        String SaveAsFileName = (ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", ""));
        SaveAsFileName = SaveAsFileName.Remove(SaveAsFileName.Length - 4);
        ViewState["File_Name"] = SaveAsFileName.ToString() + "-" + dss.Tables[0].Rows[0]["OUR_REF"].ToString();



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
        ReportParameter p9 = new ReportParameter("LOGO1", QR_Image);

        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8, p9 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }
    private void load_eri00519(string Cmp_Add, string GST_ID)
    {
        QR_Image = " ";
        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        if (dss.Tables[3].Rows.Count > 0)
        {
            QRImage_path = QR_Imagepath(dss.Tables[3].Rows[0]["SignedQRCode"].ToString(), ddlJob_No.SelectedValue.ToString().Replace('/', '_'));
            if (QRImage_path != " ")
            {
                QR_Image = new Uri(QRImage_path).AbsoluteUri;
            }
        }
        if (dss.Tables[0].Rows.Count > 0)
        {
            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_VINTAGE.rdlc";
        }

        CompanyName = "VINTAGE INTEGRATED LOGISTICS SERVICES PRIVATE LIMITED";
        /* Company_Add = "SATTVA LOGISTICS GROUP" +
                         "\r\n" +
                                "129/4, Vazhudavoor Main Road, Thuthipet Village, VillianurCommune, Puducherry, 605502" +
                                 "\r\n" +
                                  "PONDICHERRY, INDIA, TEL: 0413-2678249";*/

        ServiceTaxno = "AAFCS2437PST001";
        Pan_No = "AAFCS2437P";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/pioneer_logo.jpg")).AbsoluteUri;



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

        string shipperaddress = dss.Tables[0].Rows[0]["SHIPPER_ADDRESS"].ToString();

        string add1 = "";
        string add2 = "";
        string add3 = "";

        string[] stringSeparators = new string[] { "\r\n" };
        string[] lines = shipperaddress.Split(stringSeparators, StringSplitOptions.None);
        int x = lines.Count();

        for (int i = 0; i <= x - 1; i++)
        {
            if (i == 0)
            {
                add1 = lines[i];
            }
            else if (i == 1)
            {
                add1 = add1 + lines[i];
            }
            else if (i == 2)
            {
                add2 = lines[i];
            }
            else if (i == 3)
            {
                add2 = add2 + lines[i];
            }
            else if (i == 4)
            {
                add3 = lines[i];
            }
            else
            {
                add3 = add3 + lines[i];
            }
        }

        ReportParameter p1 = new ReportParameter("Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Address", Cmp_Add);
        ReportParameter p3 = new ReportParameter("GST_ID", GST_ID);

        ReportParameter p4 = new ReportParameter("add1", add1);
        ReportParameter p5 = new ReportParameter("add2", add2);
        ReportParameter p6 = new ReportParameter("add3", add3);
        ReportParameter p7 = new ReportParameter("LOGO1", QR_Image);

        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }

 private void load_eri01523()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_AMPLE.rdlc";


        CompanyName = "AMPLE LOGISTICS";
        //Company_Add = "4TH FLOOR, NO.42/87," +
        //                "\r\n" +
        //                       "LINGHI CHETTY STREET, GEORGE TOWN," +
        //                        "\r\n" +
        //                       "CHENNAI - 600001. TN, INDIA" +
        //                        "\r\n" +

        //                         "Email : amplelogistics5@gmail.com" +
        //                          "\r\n" +
        //                         "Ph: 044-42632567";
        Company_Add = "PESONA COURT , NO 153/317," +
                        "\r\n" +
                               "2ND FLOOR,HDFC BUILDING," +
                                "\r\n" +
                               "THAMBU CHETTY STREET,CHENNAI - 600001" +
                                "\r\n" +
                                "Email : amplelogistics5@gmail.com" +
                                  "\r\n" +
                                 "Ph: 044 - 42632567 / 49518487";

        ServiceTaxno = " 33ABEFA2848R1Z2";
        Pan_No = " ABEFA2848R";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/AMPLE.png")).AbsoluteUri;

        LOGO1 = new Uri(Server.MapPath("~/images/Company_Logo/AMPLE.png")).AbsoluteUri;

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

    private void load_eri00576()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";

        if (dss.Tables[0].Rows[0]["BILL_TYPE"].ToString() == "L")
        {
            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_GROUP_A_LOCAL.rdlc";
        }
        else if (dss.Tables[0].Rows[0]["BILL_TYPE"].ToString() == "O")
        {

            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_GROUP_A_OTHER.rdlc";
        }
        else
        {
            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_GROUP_A.rdlc";
        }




        CompanyName = "Group A Logistics India Pvt. Ltd";
        Company_Add = "301-302, Plot No. 50, Community Centre," +
                        "\r\n" +
                               "Naraina Industrial Area Phase-I," +
                                "\r\n" +
                                "New Delhi-110028, INDIA" +
                                "\r\n" +
                                 "Tel No : +91 11 25895463" +
                                  "\r\n" +
                                 "EMAIL :admin@groupalogistics.com" +
                                      "\r\n" +
                                    "WEBSITE : www.groupalogistics.com" +
                                     "\r\n" +
                                    "PAN: AADCG9923A" +
                                     "\r\n" +
                                    "CIN:U63090DL2010PTC209884";

        ServiceTaxno = "07AADCG9923A1ZT";
        Pan_No = " AADCG9923A";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/GROUP_A.png")).AbsoluteUri;

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


        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }

    private void load_eri00581()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_UNIVERSAL_CLEARING.rdlc";
        CompanyName = "UNIVERSAL CLEARING & SHIPPING AGENCY";
        Company_Add = "NO.236 (NEW NO.194) THAMBU CHETTY STREET," +
                        "\r\n" +
                               "CHENNAI 600 001." +
                                "\r\n" +
                                 "PH: +91 44 42163384. FAX: +91 44 42162885" +
                                  "\r\n" +
                                 "E-MAIL : uni@universalchennai.com" +
                                  "\r\n" +
                                 "website: www.universalchennai.com";

        ServiceTaxno = "33AABFU2864M1ZX";
        Pan_No = "AABFU2864M";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/UNIVERSAL_CLEARING.png")).AbsoluteUri;

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


        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }

    private void load_eri00588()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";


        if (dss.Tables[0].Rows[0]["LOCAL_OTHER"].ToString() == "L")
        {
            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_SRI_BALAJI_SHIPPING_Local.rdlc";
        }
        else if (dss.Tables[0].Rows[0]["LOCAL_OTHER"].ToString() == "O")
        {
            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_SRI_BALAJI_SHIPPING_Other.rdlc";
        }
        else
        {
            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_SRI_BALAJI_SHIPPING.rdlc";
        }
        
        CompanyName = "SRI BALAJI SHIPPING & LOGISTICS";
        if (ObjUBO.BILL_INV_NO[4].ToString() == "K")
        {
            //Company_Add = "No.26/2506B, Kuttamparambil Building, 2nd Floor, Pandit Karuppan Road, Landmark: Dreamz Infrabiz Techno Solutions Pvt Ltd. Thevara, Kochi, Ernakulam Dt, Kerala-682013. " +
            Company_Add = "No.26/2506B, Kuttamparambil Building, 2nd Floor, Pandit Karuppan Road, " +
                            "\r\n" +
                            "Thevara, Kochi, Ernakulam Dt, Kerala-682013." +
                            "\r\n" +
                            "GST NO: 32AAEPB2847C1ZG   LUT NO: AD320325049670B  Dt: 29.03.2025";
            ServiceTaxno = "32AAEPB2847C1ZG";
            Pan_No = " AAEPB2847C";
        }
        else if (ObjUBO.BILL_INV_NO[4].ToString() == "T")
        {
            Company_Add = "4B/71, C. G. E Colony, 1st Street, Tuticorin-628003." +
                            "\r\n" +
                            "GST NO: 33AAEPB2847C1ZE   LUT NO: AD330326090700B Dt: 27.03.2026";
            ServiceTaxno = "33AAEPB2847C1ZE";
            Pan_No = " AAEPB2847C";
        }
        else //Default is Chennai           
        {
            //Company_Add = "261/126, Second Floor, Linghi Chetty Street, Geroge Town, Chennai - 600001." +
            Company_Add = "261/126, Linghi Chetty Street, Geroge Town, Chennai - 600001." +
                            "\r\n" +
                            "GST NO: 33AAEPB2847C1ZE   LUT NO: AD330326090700B Dt: 27.03.2026";
            ServiceTaxno = "33AAEPB2847C1ZE";
            Pan_No = "33AAEPB2847C1ZE";
        }


        Logo = new Uri(Server.MapPath("~/images/Company_Logo/SRI_BALAJI_SHIPPING_LOGO.PNG")).AbsoluteUri;

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


        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }


    private void load_ERI00599()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_JSV_Freight.rdlc";

        CompanyName = "JSV FREIGHT LTD";
        Company_Add = "Marine Tower, 3rd Floor," +
                        "\r\n" +
                               "Old No 45, New No: 89, Thambu Chetty Street," +
                                 "\r\n" +
                               "CHENNAI - 600 001" +
                                "\r\n" +
                                 "PHONE NO: 044 - 4958 5453,4380 6861" +
                                  "\r\n" +
                                 "EMAIL : admin@jsvfreight.in" +
                                     "\r\n" +
                                    "GSTIN/UIN :33AAPFJ582Q1ZK";

        ServiceTaxno = "33AAPFJ582Q1ZK";
        Pan_No = "";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/JSV_Freight.JPEG")).AbsoluteUri;


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


        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }
    private void load_eri00620()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_SHIRIDI_LOGISTICS.rdlc";
        CompanyName = "SHIRIDI LOGISTICS";
        Company_Add = "Customs Clearing, Freight Forwarding & Transport Agents" +
                        "\r\n" +
                               "No.2(178), 2nd Floor, Coral Merchant Street, Muthal Pet, George Town, Chennai - 600 001." +
                                "\r\n" +
                                 "Contact: +91 99625 36166 / 97907 36166" +
                                  "\r\n" +
                                 " Email Id -  shiridilogistics@gmail.com";

        ServiceTaxno = "33CQKPD1661G1Z5";
        Pan_No = "CQKPD1661G";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/SHIRIDI_LOGISTICS.png")).AbsoluteUri;

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


        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }

    private void load_eri00621()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_VARUNA.rdlc";
        CompanyName = "VARUNA SHIPPING SERVICES";
        Company_Add = "Room No.5, 1 st Floor, New No. 121, Old No.55," +
                        "\r\n" +
                               "Ramasamy Street, Mannady," +
                                "\r\n" +
                                 "Chennai – 600001." +
                                  "\r\n" +
                                 "Phone :  +91-44-2524 3395 Tele Fax : +91-44-4216 6763" +
                                 "\r\n" +
                                 "e-mail :  varunashipping@yahoo.com   &    varunaship@gmail.com";

        ServiceTaxno = " ";
        Pan_No = " ";
        //Logo = new Uri(Server.MapPath("~/images/Company_Logo/VENJOH_LOGISTICS_LOGO.jpg")).AbsoluteUri;

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

        ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");

        STATE_NAME = dss.Tables[0].Rows[0]["STATE_NAME"].ToString();


        Remarks = dss.Tables[0].Rows[0]["PO_NO"].ToString();
        if (Remarks == "K")
            Logo = new Uri(Server.MapPath("~/images/Company_Logo/VARUNA_KRISH.jpg")).AbsoluteUri;
        else
            Logo = new Uri(Server.MapPath("~/images/Company_Logo/VARUNA_VSS.jpg")).AbsoluteUri;

        Remarks = dss.Tables[0].Rows[0]["REMARKS"].ToString();


        ReportParameter p1 = new ReportParameter("Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Address", Company_Add);
        ReportParameter p3 = new ReportParameter("ServiceTaxno", ServiceTaxno);
        ReportParameter p4 = new ReportParameter("Remarks", Remarks);
        ReportParameter p5 = new ReportParameter("Logo", Logo);
        ReportParameter p6 = new ReportParameter("TaxMode", TaxMode);
        ReportParameter p7 = new ReportParameter("Pan_No", Pan_No);
        ReportParameter p8 = new ReportParameter("STATE_NAME", STATE_NAME);


        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8 };
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
            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_KSQUARE_CHENNAI.rdlc";
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
    private void load_eri00658()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_LEO_FORWARDERZ.rdlc";


        CompanyName = "Leo Forwarderz";
        Company_Add = "Shipping, Clearing & Forwarding Agent" +
                        "\r\n" +
                        "New No.18, (Old No.325), 1st Floor, Thambuchetty Street, Chennai - 600001." +
                            "\r\n" +
                               "PHONE : (044)-42665186 / Fax : (044)-42665168" +
                                "\r\n" +
                                 "Email : leoforwarderz@gmail.com" +
                                      "\r\n" +
                                    "Service Tax : AACFL3314QST001 / PAN No : AACFL3314Q" +
                                     "\r\n" +
                                    "GST No: 33AACFL3314Q1ZA";


        ServiceTaxno = " 33AACFL3314Q1ZA";
        Pan_No = " AACFL3314Q";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/LEO_FORWARDERZ_LOGO.jpg")).AbsoluteUri;

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


        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }
    private void load_eri00664()
    {
        string LOGO1 = "", base64string = "", base64string1 = "";
        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);

        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_UNIVERSAL_CLEARING_FORWARDING.rdlc";

        if (dss.Tables[0].Rows[0]["PO_NO"].ToString() == "")
        {
            CompanyName = "UNIVERSAL CLEARING AND FORWARDING";
            Company_Add = "82 E BLOCK CARGO VILLAGE," +
                      "\r\n" +
                      "KEMPEGOWDA INTERNATIONAL AIRPORT" +
                       "\r\n" +
                         "DEVANAHALLI BENGALORE - 560300" +
                        "\r\n" +
                           "PH: 080-42040455";

            ServiceTaxno = " 29AAEFU6265H1ZR";
            Pan_No = " AAEFU6265H";
        }

        else if (dss.Tables[0].Rows[0]["PO_NO"].ToString() == "P")
        {
            CompanyName = "UCF LOGISTICS PRIVATE TIMITED";
            Company_Add = "KALPATARU FARMS," +
                                "\r\n" +
                                       "PALYA GATE," +
                                        "\r\n" +
                                         "DEVANHALLI," +
                                          "\r\n" +
                                         "EENGALURU - 562110";

            ServiceTaxno = " 29AAEFU6265H1ZR";
            Pan_No = " AAEFU6265H";

        }


        Logo = new Uri(Server.MapPath("~/images/Company_Logo/UNIVERSAL_CLEARING_FORWARDING.png")).AbsoluteUri;
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
        ReportDataSource datasource4 = new ReportDataSource("DataSet5", dss.Tables[5]);
        ReportViewer1.LocalReport.DataSources.Add(datasource4);

        if (dss.Tables[5].Rows.Count > 0)
        {
            base64string1 = dss.Tables[5].Rows[0]["SignedQRCodeImage"].ToString();
        }
        if (base64string1.Length > 0)
        {
            base64string = base64string1.Substring(base64string1.IndexOf("Submission"));
        }
        if (base64string.Length > 0)
        {
            LOGO1 = new Uri(Server.MapPath("~/" + base64string)).AbsoluteUri;
        }
        else { LOGO1 = new Uri(Server.MapPath("~/images/txtbox-mid_90px.png")).AbsoluteUri; }
        ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");

        ReportParameter p1 = new ReportParameter("Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Address", Company_Add);
        ReportParameter p3 = new ReportParameter("Logo", Logo);
        ReportParameter p4 = new ReportParameter("Bill_Type", dss.Tables[4].Rows[0][0].ToString());
        ReportParameter p5 = new ReportParameter("LOGO1", LOGO1);

        ReportParameter[] p = { p1, p2, p3, p4, p5 };
        ReportViewer1.LocalReport.SetParameters(p);
        Report_Print();
    }

    private void load_eri00674()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_NEELAKANTH.rdlc";


        CompanyName = "SHIVANSH SHIPPING";
        Company_Add = "2nd floor,Office No 6, Rajdeep Complex," +
                        "\r\n" +
                               "Plot no 15 , Sector-9 " +
                                "\r\n" +
                                 "Gandhidham, Gujarat 370201" +

                                     "\r\n" +
                                    "GST #:24BGDPT2178Q1ZQ";

        ServiceTaxno = "24BGDPT2178Q1ZQ";
        Pan_No = "";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/NeelaKanth_eri00674.jpeg")).AbsoluteUri;

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


        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }
    private void load_eri0677()
    {
        string LOGO1 = "", base64string = "", base64string1 = "";
        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);

        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_SHIVANSH_SHIPPING_MUMBAI.rdlc";

        if (dss.Tables[0].Rows[0]["PO_NO"].ToString() == "")
            CompanyName = "CARGO EASE PVT. LTD.";
        Company_Add = "OFFICE NO. 002 B - 5, GROUND FLOOR, OM GREEN PARK, NEAR CANARA BANK, BOLINJ NAKA," +
                                "\r\n" +
                                       "401303 (ISO 9001:2015 ) CR.NO: 305024010812Q" +
                                        "\r\n" +
                                         "Tel: 9930362251 / 9822812224 EMail: info@cargoease.in / sanjayamehrotra@hotmail.com";

        ServiceTaxno = " 27AAGCC1934N1ZE";
        Pan_No = " AAGCC1934N";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/SHIVANSH_SHIPPING_MUMBAI.png")).AbsoluteUri;

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
        ReportDataSource datasource4 = new ReportDataSource("DataSet5", dss.Tables[5]);
        ReportViewer1.LocalReport.DataSources.Add(datasource4);

        if (dss.Tables[5].Rows.Count > 0)
        {
            base64string1 = dss.Tables[5].Rows[0]["SignedQRCodeImage"].ToString();
        }
        if (base64string1.Length > 0)
        {
            base64string = base64string1.Substring(base64string1.IndexOf("Submission"));
        }
        if (base64string.Length > 0)
        {
            LOGO1 = new Uri(Server.MapPath("~/" + base64string)).AbsoluteUri;
        }
        else { LOGO1 = new Uri(Server.MapPath("~/images/txtbox-mid_90px.png")).AbsoluteUri; }
        ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");

        ReportParameter p1 = new ReportParameter("Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Address", Company_Add);
        ReportParameter p3 = new ReportParameter("Logo", Logo);
        ReportParameter p4 = new ReportParameter("Bill_Type", dss.Tables[4].Rows[0][0].ToString());
        ReportParameter p5 = new ReportParameter("LOGO1", LOGO1);

        ReportParameter[] p = { p1, p2, p3, p4, p5 };
        ReportViewer1.LocalReport.SetParameters(p);
        Report_Print();
    }
    private void load_eri00704()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_JAINESH.rdlc";


        CompanyName = "JAINESH LOGISTICS";
        Company_Add = "New No. 64, Old No : 291 / 2, 2nd Floor," +
                        "\r\n" +
                               "Linghi Chetty Street, Chennai – 600 001.";

        ServiceTaxno = " 33DXGPR7731K1Z0";
        Pan_No = " DXGPR7731K";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/JAINESH.jpg")).AbsoluteUri;
        LOGO1 = new Uri(Server.MapPath("~/images/Company_Logo/JAINESH_2.jpg")).AbsoluteUri;

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

    private void load_eri00705()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        //localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_AIR_AND_SHIPPING_CARGO.rdlc";

        if (dss.Tables[0].Rows[0]["BILL_TYPE"].ToString() == "L")
        {
            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_AIR_AND_SHIPPING_CARGO_LOCAL.rdlc";
        }
        else if (dss.Tables[0].Rows[0]["BILL_TYPE"].ToString() == "O")
        {
            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_AIR_AND_SHIPPING_CARGO_OTHER.rdlc";
        }
        else
        {
            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_AIR_AND_SHIPPING_CARGO.rdlc";
        }


        CompanyName = "AIR & SHIPPING CARGO LOGISTICS";
        Company_Add = "6 KASHTRIYA BHAWAN, 2ND FLOOR," +
                        "\r\n" +
                               "KRISHNA MARKET (OPP OBC BANK)," +
                                "\r\n" +
                                 "PAHAR GANJ, NEW DELHI-110055." +
                                  "\r\n" +
                                 "Tel:-011 23587700" +
                                      "\r\n" +
                                    "Email: asccargo2015@gmail.com , asclogistics@yahoo.com" +
                                     "\r\n" +
                                    "GSTIN: 07ASEPS9489H2ZW";


        ServiceTaxno = "07ASEPS9489H2ZW";
        Pan_No = " ASEPS9489H";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/AIR_AND_SHIPPING_CARGO.png")).AbsoluteUri;

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


        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }
    //***********************************************************************

 private void load_eri00725()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_INTERNATIONAL_SHIPPING_CORPORATION.rdlc";


        CompanyName = "INTERNATIONAL SHIPPING CORPORATION";
        Company_Add = "CHA. LIC.NO. R.669" +
                        "\r\n" +
                        "NO. 233/6, K.K COMPLEX, G.N.T ROAD," +
                            "\r\n" +
                               "KAVARAIPETTAI, CHENNAI - 601206." +
                                "\r\n" +
                                 "MOB: +91 9840055345 / +91 8940555346 " +
                                      "\r\n" +
                                    "Email: iscchennai2013@gmail.com" +
                                     "\r\n" +
                                    "GSTIN: 33AAAFI3817P2Z8";


        ServiceTaxno = "33AAAFI3817P2Z8";
        Pan_No = " AAAFI3817P";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/INTERNATIONAL_SHIPPING_CORPORATION.jpg")).AbsoluteUri;

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


        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }



    private void load_eri00727()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_ZEN_CLEAFOR.rdlc";


        CompanyName = "ZEN CLEAFOR";
        Company_Add = "1-11-252/1/E, 1ST FLOOR, " +
                        "\r\n" +
                               "103, ARCHANA APTS, " +
                                "\r\n" +
                                 "SHOPPERS STOP LANE, " +
                                  "\r\n" +
                                 "BEGUMPET, HYDERABAD" +
                                      "\r\n" +
                                    "TELANGANA 500016." +
                                     "\r\n" +
                                    "TEL: 040 6631 6805" +
                                     "\r\n" +
                                    "GSTIN: 36ACAPT4758L1Z1";


        ServiceTaxno = "36ACAPT4758L1Z1 ";
        Pan_No = "ACAPT4758L ";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/ZEN_CLEAFOR.png")).AbsoluteUri;

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


        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }

    

    private void load_eri00761()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_VENJOH_LOGISTICS.rdlc";
        CompanyName = "VENJOH LOGISTICS PVT. LTD.";
        Company_Add = "No. 24, Narayana Sarang Garden Street," +
                        "\r\n" +
                               "4th Floor, Seethakathi Centre," +
                                "\r\n" +
                                 "Chennai - 600 001." +
                                  "\r\n" +
                                 "GST No: 33AADCV0610K1ZO";

        ServiceTaxno = "33AADCV0610K1ZO";
        Pan_No = "33AADCV0610K1ZO";
        //Logo = new Uri(Server.MapPath("~/images/Company_Logo/VENJOH_LOGISTICS_LOGO.jpg")).AbsoluteUri;

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

        ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");

        STATE_NAME = dss.Tables[0].Rows[0]["STATE_NAME"].ToString();


        Remarks = dss.Tables[0].Rows[0]["PO_NO"].ToString();
        if (Remarks == "3")
            Logo = new Uri(Server.MapPath("~/images/Company_Logo/VENJOH_LOGISTICS_UTL_LOGO.jpg")).AbsoluteUri;
        else
            Logo = new Uri(Server.MapPath("~/images/Company_Logo/VENJOH_LOGISTICS_LOGO.jpg")).AbsoluteUri;

        Remarks = dss.Tables[0].Rows[0]["REMARKS"].ToString();


        ReportParameter p1 = new ReportParameter("Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Address", Company_Add);
        ReportParameter p3 = new ReportParameter("ServiceTaxno", ServiceTaxno);
        ReportParameter p4 = new ReportParameter("Remarks", Remarks);
        ReportParameter p5 = new ReportParameter("Logo", Logo);
        ReportParameter p6 = new ReportParameter("TaxMode", TaxMode);
        ReportParameter p7 = new ReportParameter("Pan_No", Pan_No);
        ReportParameter p8 = new ReportParameter("STATE_NAME", STATE_NAME);


        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }
    private void load_eri00779()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_SAIRAM_SHIPPING.rdlc";
        CompanyName = "SAI RAM SHIPPING & LOGISTICS";
        Company_Add = "(Freight Forwarders & Transports)" +
                        "\r\n" +
                               "No.173/84, Linghi Chetti Street, Chennai - 600 001." +
                                "\r\n" +
                                 "Tel: 044 4262 1128 Cell: 98849 52209" +
                                 "\r\n" +
                                 " E-mail: sairamlogistics2020@gmail.com";

        ServiceTaxno = "33AEDFS2634F1ZC";
        Pan_No = "AEDFS2634F";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/SAIRAM_SHIPPING.png")).AbsoluteUri;

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


        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }

    private void load_eri00783()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_DYNAMIC_CARGO_CARE.rdlc";


        CompanyName = "DYNAMIC CARGO CARE PVT LTD";
        Company_Add = "OLD NO.231. NEW NO.204, 2ND FLOOR," +
                        "\r\n" +
                               "THAMBU CHETTY STREET," +
                                "\r\n" +
                                 "CHENNAI - 600 001." +
                                  "\r\n" +
                                 "Ph: 044 25240067 / 044 42164069" +
                                      "\r\n" +
                                    "Email: dynamiccargocare@gmail.com" +
                                     "\r\n" +
                                    "GSTIN: 33AAACD2692L1ZL";


        ServiceTaxno = "33AAACD2692L1ZL";
        Pan_No = " AAACD2692L";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/DYNAMIC_CARGO_CARE.png")).AbsoluteUri;

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


        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }

    private void load_eri00829()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_PRADEEP_BLR.rdlc";
        CompanyName = "PRADEEP CARGO SERVICES PVT LTD";


        if (dss.Tables[0].Rows[0]["TR_DETAILS"].ToString() == "" || dss.Tables[0].Rows[0]["TR_DETAILS"].ToString() == "BANGALORE")
        {
            Company_Add = "#1542, E BLOCK, 2ND MAIN, AECS LAYOUT," +
                            "\r\n" +
                                   "KUNDANAHALLI POST, BANGALORE-560037" +
                                    "\r\n" +
                                     "SERVICE CODE: 996712, SAC CODE: 00440026" +
                                      "\r\n" +
                                      "GSTIN/UIN: 29AABCP5904G1ZF   CIN: U63010KA1998PTC023391" +
                                      "\r\n" +
                                     "E-Mail: pradeepcargo@pcsblr.com" +
                                          "\r\n" +
                                        "AEO Certificate No: INAABCP5904G0F211   ISO 9001: 2015 - Cert No: 760075" +
                                         "\r\n" +
                                        "UAM No: KR03E0099087 LUT No: AD290326072856J Dt: 31/03/2026";

            ServiceTaxno = " 29AABCP5904G1ZF";
            Pan_No = " AABCP5904G";
        }
        else if (dss.Tables[0].Rows[0]["TR_DETAILS"].ToString() == "AHMEDABAD")
        {
            Company_Add = "Shop No.22, Block C, K B Royal Serenity, Opp.Sarthi Bunglows," +
                            "\r\n" +
                                   "Chandkhede Zundal Road, Chandkheda, Ahmedabad, Gandhinagar, Gujarat - 382424." +
                                    "\r\n" +
                                     "SERVICE CODE: 996712, SAC CODE: 00440026" +
                                      "\r\n" +
                                      "GSTIN/UIN: 24AABCP5904G1ZP   CIN: U63010KA1998PTC023391" +
                                      "\r\n" +
                                     "E-Mail: pradeepcargo@pcsblr.com" +
                                          "\r\n" +
                                        "AEO Certificate No: INAABCP5904G0F211   ISO 9001: 2015 - Cert No: 760075" +
                                         "\r\n" +
                                        "UAM No: KR03E0099087 LUT No: AD290326072856J Dt: 31/03/2026";

            ServiceTaxno = " 24AABCP5904G1ZP";
            Pan_No = " AABCP5904G";
        }
        else if (dss.Tables[0].Rows[0]["TR_DETAILS"].ToString() == "MUMBAI")
        {
            Company_Add = "Plot No 51, Sector 5A, Shop No 5, Bhaveshwar Mention," +
                            "\r\n" +
                                   "Karanjade, Panvel, Navi Mumbai, Raigad Dt, Maharashtra - 410206." +
                                    "\r\n" +
                                     "SERVICE CODE: 996712, SAC CODE: 00440026" +
                                      "\r\n" +
                                      "GSTIN/UIN: 27AABCP5904G2ZI   CIN: U63010KA1998PTC023391" +
                                      "\r\n" +
                                     "E-Mail: pradeepcargo@pcsblr.com" +
                                          "\r\n" +
                                        "AEO Certificate No: INAABCP5904G0F211   ISO 9001: 2015 - Cert No: 760075" +
                                         "\r\n" +
                                        "UAM No: KR03E0099087 LUT No: AD290326072856J Dt: 31/03/2026";

            ServiceTaxno = " 27AABCP5904G2ZI";
            Pan_No = " AABCP5904G";
        }
        else
        {
            Company_Add = "***** ***** ADDRESS INVALID ***** ***** ," +
                            "\r\n" +
                                   "**** CHOOSE CORRECT BILL FROM ADDRESS ***** " +
                                    "\r\n" +
                                     "SERVICE CODE: 996712, SAC CODE: 00440026" +
                                      "\r\n" +
                                      "GSTIN/UIN: 29AABCP5904G1ZF   CIN: U63010KA1998PTC023391" +
                                      "\r\n" +
                                     "E-Mail: pradeepcargo@pcsblr.com" +
                                          "\r\n" +
                                        "AEO Certificate No: INAABCP5904G0F211   ISO 9001: 2015 - Cert No: 760075" +
                                         "\r\n" +
                                        "UAM No: KR03E0099087 LUT No: AD290326072856J Dt: 31/03/2026";

            ServiceTaxno = " 29AABCP5904G1ZF";
            Pan_No = " AABCP5904G";
        }


        Logo = new Uri(Server.MapPath("~/images/Company_Logo/PRADEEP_BLR.jpg")).AbsoluteUri;

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


        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }



    private void load_eri00867()
    {
        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        //string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_StarCom.rdlc";
        CompanyName = "STARCOM LOGISTICS";
        Company_Add = "RUDRA CHAMBER ,SEC 1/A PLOT NO 201" +
                        "\r\n" +
                               "Office - 01 opp Hero Sawroom,Gandhidham 370201 kutch Gujarat";


        ServiceTaxno = " 24BIGPR1590F1Z9";
        Pan_No = " BIGPR1590F";
        //Logo = new Uri(Server.MapPath("~/images/Company_Logo/ADWAL.png")).AbsoluteUri;


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

        ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        //Remarks = dss.Tables[0].Rows[0]["REMARKS"].ToString();
        //STATE_NAME = dss.Tables[0].Rows[0]["STATE_NAME"].ToString();


        ReportParameter p1 = new ReportParameter("Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Address", Company_Add);
        ReportParameter p3 = new ReportParameter("ServiceTaxno", ServiceTaxno);
        //ReportParameter p4 = new ReportParameter("Remarks", Remarks);
        //ReportParameter p5 = new ReportParameter("Logo", Logo);
        //ReportParameter p6 = new ReportParameter("TaxMode", TaxMode);
        ReportParameter p7 = new ReportParameter("Pan_No", Pan_No);
        //ReportParameter p8 = new ReportParameter("STATE_NAME", STATE_NAME);


        ReportParameter[] p = { p1, p2, p3, p7 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();


    }


    private void load_eri01011()
    {
        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        if (dss.Tables[0].Rows.Count > 0)
        {
            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_SANCO_BANG_AIR.rdlc";
        }

        CompanyName = "Sanco Trans Limited";
        Company_Add = "56-57, RAJAJI SALAI, 2ND FLOOR," +
                        "\r\n" +
                               "CHENNAI - 600001." +
                                "\r\n" +
                                 "PHONE NO: 044-25225636,25271401,25270933" +
                                  "\r\n" +
                                 "EMAIL :pioneerscha@gmail.com,pioneers@airtelmail.in";

        Logo = new Uri(Server.MapPath("~/images/Company_Logo/pioneer_logo.jpg")).AbsoluteUri;
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

        ReportParameter[] p = { p1 };
        ReportViewer1.LocalReport.SetParameters(p);
        Report_Print();
    }
    private void load_eri01019()
    {
        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        if (dss.Tables[0].Rows.Count > 0)
        {
            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_SANCO_AIR.rdlc";
        }

        CompanyName = "Sanco Trans Limited";
        Company_Add = "56-57, RAJAJI SALAI, 2ND FLOOR," +
                        "\r\n" +
                               "CHENNAI - 600001." +
                                "\r\n" +
                                 "PHONE NO: 044-25225636,25271401,25270933" +
                                  "\r\n" +
                                 "EMAIL :pioneerscha@gmail.com,pioneers@airtelmail.in";



        Logo = new Uri(Server.MapPath("~/images/Company_Logo/pioneer_logo.jpg")).AbsoluteUri;


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

        ReportParameter[] p = { p1 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }
    private void load_eri00508()
    {
        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        if (dss.Tables[0].Rows.Count > 0)
        {
            if (dss.Tables[0].Rows[0]["Tax_NonTax"].ToString() == "T" || dss.Tables[0].Rows[0]["Tax_NonTax"].ToString() == "TN")
            {

                if (dss.Tables[0].Rows[0]["Reg_Sez"].ToString() == "R")
                {
                    if (dss.Tables[0].Rows[0]["BILL_TYPE"].ToString() == "L")
                    {
                        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_PEGASUS_TL.rdlc";
                    }
                    else
                    {
                        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_PEGASUS_TO.rdlc";
                    }
                }
                else
                {
                    if (dss.Tables[0].Rows[0]["BILL_TYPE"].ToString() == "L") //V
                    {
                        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_PEGASUS_TL_Sez.rdlc";
                    }
                    else
                    {
                        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_PEGASUS_TO_Sez.rdlc";
                    }
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

            else
            {
                localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_PEGASUS_RI.rdlc";

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
        }

        CompanyName = " ";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/pioneer_logo.jpg")).AbsoluteUri;
        ReportViewer1.LocalReport.EnableExternalImages = true;

        ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        ReportParameter p1 = new ReportParameter("Name", CompanyName);

        ReportParameter[] p = { p1 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }
    private void load_eri00511()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_VAISHNAVI.rdlc";
        //VAISHNAVI

        CompanyName = "VAISHNAVI FREIGHT LOGISTICS P LTD";
        Company_Add = "SRI SATHYA SAI NIVAS Ground Floor," +
                        "\r\n" +
                        "No. 4/14, Viswanathan Street, " +
                         "\r\n" +
                               "West Mambalam, " +
                                "\r\n" +
                                 "Chennai - 600 033.";


        ServiceTaxno = " ";
        Pan_No = " ";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/VAISHNAVI.jpg")).AbsoluteUri;

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

        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8 };
        ReportViewer1.LocalReport.SetParameters(p);
        Report_Print();
    }
    

    private void load_eri00561()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        if (dss.Tables[0].Rows[0]["INV_TYPE"].ToString() == "R")
        {
            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_RG_INTERNATIONAL.rdlc";
        }
        else
        {
            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_RG_INTERNATIONAL_SEZ.rdlc";
        }

        CompanyName = "RG INTERNATIONAL";
        Company_Add = "Customs Brokers, Consultants and International Freight Forwarders" +
                        "\r\n" +
                        "CR House, 16, Guru Jambeshwar Nagar, Main Queens Road," +
                         "\r\n" +
                               "Jaipur 302021 Rajasthan India" +
                        "\r\n" +
                        "Phone +911412354577, +911412354578";

        ServiceTaxno = "08AASFR0436R1ZE";
        Pan_No = " ";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/RG_INTERNATIONAL_LOGO.jpg")).AbsoluteUri;
        Bank_Name = "IDBI BANK LTD.,";
        Bank_Branch = "F29, Gautam Marg, Vaishali Nagar, Jaipur";
        ACCTYPE = " ";
        ACCNO = "0273102000025294";
        IFSC = "IBKL0000273";

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

        ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        //Remarks = dss.Tables[0].Rows[0]["REMARKS"].ToString();
        //STATE_NAME = dss.Tables[0].Rows[0]["STATE_NAME"].ToString();

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
        ReportParameter p9 = new ReportParameter("Bank_Name", Bank_Name);
        ReportParameter p10 = new ReportParameter("Bank_Branch", Bank_Branch);
        ReportParameter p11 = new ReportParameter("ACCTYPE", ACCTYPE);
        ReportParameter p12 = new ReportParameter("ACCNO", ACCNO);
        ReportParameter p13 = new ReportParameter("IFSC", IFSC);
        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13 };
        ReportViewer1.LocalReport.SetParameters(p);
        Report_Print();

    }
    private void load_eri00744()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_SUN_GLOBAL_LOGISTICS.rdlc";


        CompanyName = "SUN GLOBAL LOGISTICS PVT LTD";
        Company_Add = "SURVEY NO 742, NORTH AVENUE ROAD," +
                        "\r\n" +
                               "SIPCOT IRUNGATTUKOTTAI, SRIPERUMBUDUR," +
                                "\r\n" +
                                 "KANCHIPURAM - 602105";

        ServiceTaxno = "33AAFCS6623P1ZY";
        Pan_No = "AAFCS6623P";

        Logo = new Uri(Server.MapPath("~/images/Company_Logo/SUN_GLOBAL_LOGISTICS.png")).AbsoluteUri;

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


        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }

    private void load_eri00804()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_PORTAGE_GLOBAL.rdlc";


        CompanyName = "WAYMARK LOGISTICS INDIA PVT LTD";
        Company_Add = "Office Number - 310 , 3rd Floor," +
                        "\r\n" +
                               "V Time Square, Plot Number-03," +
                                "\r\n" +
                                 "Sector -15, CBD Belapur, Navi Mumbai - 400 614." +
                                  "\r\n" +
                                 "Ph: +91 22 40431000" +
                                      "\r\n" +
                                    "Email: mumbai@waymark.in" +
                                     "\r\n" +
                                     "web: www.waymark.in" +
                                     "\r\n" +
                                    "GSTIN: 27AAACW7308Q1ZQ";


        ServiceTaxno = "27AAACW7308Q1ZQ";
        Pan_No = " AAACW7308Q";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/PORTAGE_GLOBAL.png")).AbsoluteUri;


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


        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }
    private void load_eri00911()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";

        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_FLYSEA.rdlc";
        CompanyName = "FLYSEA CLEARING & FORWARDING PVT. LTD.";
        Company_Add = "HEAD OFFICE (SEA): TAJ TOWERS, NO.22A, SECOND LINE BEACH, CHENNAI – 600001." +
                      "\r\n" +
                      "PH NO.044-2521 4202/2526 1982. EMAIL ID : flysea@flyseaindia.com" +
                      "\r\n" +
                      "R.O (AIR): FLAT NO.2, GROUND FLOOR, J.S.TOWERS, NO.4, AWAIYAR ST, MEENAMBAKKAM, CHENNAI-600027." +
                          "\r\n" +
                             "PH NO: 044-2256 1874/ 2256 0920. EMAIL ID : Flysealsm@gmail.com" +
                                    "\r\n" +
                                  "GSTIN NO: 33AAACF1451F1Z9  PAN NO: AAACF1451F  REG NO: UDYAM-TN-02-0067388";



        ServiceTaxno = " 33AAACF1451F1Z9";
        Pan_No = " AAACF1451F";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/FLYSEA.jpg")).AbsoluteUri;

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


        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }

    private void load_eri00923()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_MASTERSTROKE.rdlc";


        CompanyName = "MASTERSTROKE FREIGHT FORWARDERS PVT LTD";
        Company_Add = "CUSTOMS BROKER - LICENSE No R-506" +
                        "\r\n" +
                               "New no.93, Armenian Street, S.M.Plaza, 3rd Floor Parrys, Chennai-600 001, Tamilnadu" +
                                "\r\n" +
                                 "Email: sukugroup@masterstrokelogistics.com  Phone 044-25216464 / 25216465" +
                                     "\r\n" +
                                    "GSTIN: 33AACCM6444M2Z9   CIN No: U63012TN1999PTC043841";

        ServiceTaxno = " 33AACCM6444M2Z9";
        Pan_No = " AACCM6444M";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/MASTERSTROKE.png")).AbsoluteUri;


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


        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }
    private void load_eri00931()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_SEA_PRINCESS.rdlc";


        CompanyName = "SEA PRINCESS LOGISTICS";
        Company_Add = "Old No.101, New No.32" +
                        "\r\n" +
                               "3rd Floor, Armenian Street, Mannady" +
                                "\r\n" +
                                 "Chennai – 600001, Tamilnadu, India" +
                                  "\r\n" +
                                 "Ph: 044-45120342" +
                                      "\r\n" +
                                    "PAN No: ADXFS3139G";

        ServiceTaxno = " 33ADXFS3139G1ZQ";
        Pan_No = " ADXFS3139G";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/SEA_PRINCESS.png")).AbsoluteUri;


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


        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }


    private void load_eri01051()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_TIME_RICH.rdlc";

        CompanyName = "TIME RICH SHIPPING PVT LTD";
        Company_Add = "83-84 Moore Street," +
                        "\r\n" +
                               "Chennai-600 001.";





        ServiceTaxno = " ";
        Pan_No = " ";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/RR_LOGISTICS_LOGO.jpg")).AbsoluteUri;
        Bank_Name = " ";
        Bank_Branch = " ";
        ACCTYPE = " ";
        ACCNO = " ";
        IFSC = " ";

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

        ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        //Remarks = dss.Tables[0].Rows[0]["REMARKS"].ToString();
        //STATE_NAME = dss.Tables[0].Rows[0]["STATE_NAME"].ToString();

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
        ReportParameter p9 = new ReportParameter("Bank_Name", Bank_Name);
        ReportParameter p10 = new ReportParameter("Bank_Branch", Bank_Branch);
        ReportParameter p11 = new ReportParameter("ACCTYPE", ACCTYPE);
        ReportParameter p12 = new ReportParameter("ACCNO", ACCNO);
        ReportParameter p13 = new ReportParameter("IFSC", IFSC);
        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13 };
        ReportViewer1.LocalReport.SetParameters(p);
        Report_Print();

    }
    private void load_eri01052()
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
            if (base64string1.Length > 0)
            {
                base64string = base64string1.Substring(base64string1.IndexOf("Submission"));
            }
        }
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_OMAN.rdlc";


        CompanyName = "OMAN CARGO MOVER";
        Company_Add = "Office No. 201,2nd Floor,Sunshine Arcade II," +
                                "\r\n" +
                               "Plot No. 37,Sector - 8," +
                                 "\r\n" +
                                       " Gandhidham - 370201" +
                                        "\r\n" +
                                         "PHONE NO:+91 9979778882,Tel No: +91 9925633306  " +
                                          "\r\n" +
                                         "EMAIL :www.omancargomover.com" +
                                              "\r\n" +
                                            "PAN:AADF07628M";

        ServiceTaxno = " 24AADF07628M1ZW";
        Pan_No = " AADF07628M";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/OMAN.jpg")).AbsoluteUri;
        if (base64string.Length > 0)
        {
            LOGO1 = new Uri(Server.MapPath("~/" + base64string)).AbsoluteUri;
        }
        else { LOGO1 = new Uri(Server.MapPath("~/images/txtbox-mid_90px.JPG")).AbsoluteUri; }

        LOGO2 = new Uri(Server.MapPath("~/images/Company_Logo/OMAN.JPG")).AbsoluteUri;


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
    
    private void load_eri01074()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_KARGOJET.rdlc";


        CompanyName = "KARGOJET INDIA";
        Company_Add = "B-45, STREET NO 10 SAROJINI PARK," +
                        "\r\n" +
                        "SHASHTRI NAGAR, DELHI 110032 INDIA" +
                         "\r\n" +
                               "PHONE - 9818622331 9718973338 ";


        ServiceTaxno = " ";
        Pan_No = " ";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/KARGOJET_LOGO.png")).AbsoluteUri;
        Bank_Name = "BANK OF BARODA";
        Bank_Branch = "PATPARGANJ, DELHI";
        ACCTYPE = "CURRENT";
        ACCNO = "21290200001154";
        IFSC = "BARB0TRDPAT";

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
        ReportParameter p9 = new ReportParameter("Bank_Name", Bank_Name);
        ReportParameter p10 = new ReportParameter("Bank_Branch", Bank_Branch);
        ReportParameter p11 = new ReportParameter("ACCTYPE", ACCTYPE);
        ReportParameter p12 = new ReportParameter("ACCNO", ACCNO);
        ReportParameter p13 = new ReportParameter("IFSC", IFSC);
        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13 };
        ReportViewer1.LocalReport.SetParameters(p);
        Report_Print();

    }
    private void load_eri01120()
    {
        string LOGO1 = "", base64string = "", base64string1="";
        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);

        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_KL.rdlc";

        CompanyName = "KRISHYA LOGISTICS LLP";
        Company_Add = "3RD FLOOR, VVD MAHAL," +
                        "\r\n" +
                        "181C, PALAYAMKOTTAI ROAD" +
                         "\r\n" +
                           "TUTICORIN - 628003";


        Logo = new Uri(Server.MapPath("~/images/Company_Logo/Krishya_Logo.png")).AbsoluteUri;
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
        ReportDataSource datasource4 = new ReportDataSource("DataSet5", dss.Tables[5]);
        ReportViewer1.LocalReport.DataSources.Add(datasource4);

        if (dss.Tables[5].Rows.Count > 0)
        {
            base64string1 = dss.Tables[5].Rows[0]["SignedQRCodeImage"].ToString();
        }
        if (base64string1.Length > 0)
        {
            base64string = base64string1.Substring(base64string1.IndexOf("Submission"));
        }
        if (base64string.Length > 0)
        {
            LOGO1 = new Uri(Server.MapPath("~/" + base64string)).AbsoluteUri;
        }
        else { LOGO1 = new Uri(Server.MapPath("~/images/txtbox-mid_90px.png")).AbsoluteUri; }
        ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");

        ReportParameter p1 = new ReportParameter("Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Address", Company_Add);
        ReportParameter p3 = new ReportParameter("Logo", Logo);
        ReportParameter p4 = new ReportParameter("Bill_Type", dss.Tables[4].Rows[0][0].ToString());
        ReportParameter p5 = new ReportParameter("LOGO1", LOGO1);

        ReportParameter[] p = { p1, p2, p3,p4,p5 };
        ReportViewer1.LocalReport.SetParameters(p);
        Report_Print();
    }

    private void load_eri01134()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_HOPE_CARGO_CARE.rdlc";


        CompanyName = "HOPE CARGO CARE PVT. LTD.";
        Company_Add = "Customs House Broker, Forwarding, Cargo Handling Agents" +
                        "\r\n" +
                        "54F, 1st Floor Bryant Nagar Main Road, 1st Street," +
                         "\r\n" +
                               "Tuticorin – 628008." +
                        "\r\n" +
                        "Tel: 0461-4550025 Mob: 9843323276, 9943833535" +
                        "\r\n" +
                        "Email: contact@hopecargocare.com";



        ServiceTaxno = "33AAECH8641M1ZA";// FOR GSTIN
        Pan_No = "U63030TN2019PTC128405";// FOR CIN NO         
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/HOPE_CARGO_CARE_LOGO.jpg")).AbsoluteUri;
        Bank_Name = "INDUSIND BANK LTD.,";
        Bank_Branch = "THOOTHUKUDI";
        ACCTYPE = "CURRENT";
        ACCNO = "259843323276";
        IFSC = "INDB0000387";

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

        ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        //Remarks = dss.Tables[0].Rows[0]["REMARKS"].ToString();
        //STATE_NAME = dss.Tables[0].Rows[0]["STATE_NAME"].ToString();

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
        ReportParameter p9 = new ReportParameter("Bank_Name", Bank_Name);
        ReportParameter p10 = new ReportParameter("Bank_Branch", Bank_Branch);
        ReportParameter p11 = new ReportParameter("ACCTYPE", ACCTYPE);
        ReportParameter p12 = new ReportParameter("ACCNO", ACCNO);
        ReportParameter p13 = new ReportParameter("IFSC", IFSC);
        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13 };
        ReportViewer1.LocalReport.SetParameters(p);
        Report_Print();

    }

    private void load_eri01157()
    {
        QR_Image = " "; 
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        if (dss.Tables[3].Rows.Count > 0)
        {
            QRImage_path = QR_Imagepath(dss.Tables[3].Rows[0]["SignedQRCode"].ToString(), ddlJob_No.SelectedValue.ToString().Replace('/', '_'));
            if (QRImage_path != " ")
            {
                QR_Image = new Uri(QRImage_path).AbsoluteUri;
            }
        }
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_R_K_CONTAINER.rdlc";
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
        ReportParameter p9 = new ReportParameter("LOGO1", QR_Image);

        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8, p9 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }

    private void load_eri01158()
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
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_LEGEND_GLOBAL.rdlc";


        CompanyName = "LEGEND GLOBAL LOGISTICS INDIA LLP";
        Company_Add = "CUSTOM HOUSE AGENT - R-355/2015-CBS" +
                        "\r\n" +
                               "OLD NO. 83, NEW NO. 171, 2ND FLOOR," +
                                "\r\n" +
                                 "LINGHI CHETTY STREET," +
                                  "\r\n" +
                                 "CHENNAI-600001, TAMILNADU" +
                                      "\r\n" +
                                    "Email: accounts.chn@lgl.co.in" +
                                     "\r\n" +
                                    "GSTIN: 33AAFFL6159A1ZN";


        ServiceTaxno = "33AAFFL6159A1ZN";
        Pan_No = " AAFFL6159A";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/LEGEND_GLOBAL.png")).AbsoluteUri;
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

        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8,p9 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }
    private void load_eri01159()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_SEAGULL.rdlc";
        CompanyName = "SEAGULL CLEARING & FORWARDING AGENCIES (P) LTD";
        /*
        Company_Add = "BEACH HOUSE, ROOM NO. 3, 2ND FLOOR," +
                        "\r\n" +
                               "NO. 20, SECOND LINE BEACH, CHENNAI - 600001, TAMILNADU." +
                                "\r\n" +
                                 "Tel:(+91)-44-25249086/25264505/6. Fax(+91)-044-25248221" +
                                  "\r\n" +
                                 "E-mail: seagullcfa@seagullclearing.net";*/


        Company_Add = "ROWTHER CHAMBERS, 5TH FLOOR," +
                        "\r\n" +
                               "NO. 53, 54 & 55, RAJAJI SALAI, CHENNAI - 600001, TAMILNADU." +
                                "\r\n" +
                                 "Tel:(+91)-44-25249086/25264505" +
                                  "\r\n" +
                                 "E-mail: seagullcfa@seagullclearing.net";


        ServiceTaxno = "33AABCS2390D1ZR";
        Pan_No = "AABCS2390D";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/SEAGULL_LOGO.png")).AbsoluteUri;

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


        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }

    private void load_eri01160()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_SEAGULL_BLR.rdlc";
        CompanyName = "SEAGULL CLEARING & FORWARDING AGENCIES (P) LTD";
        Company_Add = "CUSTOM HOUSE AGENT - R 675" +
                        "\r\n" +
                               "101, CHANDRAMOULESHWARA LAYOUT" +
                                "\r\n" +
                                 "HUNASAMARANAHALLI" +
                                  "\r\n" +
                                 "BENGULURU";

        ServiceTaxno = "29AABCS2390D1ZG";
        Pan_No = "AABCS2390D";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/SEAGULL_LOGO.png")).AbsoluteUri;

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


        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }
    private void load_eri01175()
    {
        string LOGO1 = "", base64string = "", base64string1=""; 
        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);

        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_KL_CHENNAI.rdlc";

        CompanyName = "KRISHYA LOGISTICS LLP";
        Company_Add = "3B, 3rd Floor, ANP Tower," +
                        "\r\n" +
                        "76/80, Moore Street, Mannady, " +
                         "\r\n" +
                           "Chennai - 600 001. " +
                           "\r\n" +
                           "Head Office: Tuticorin";

        Logo = new Uri(Server.MapPath("~/images/Company_Logo/Krishya_Logo.png")).AbsoluteUri;
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
        ReportDataSource datasource4 = new ReportDataSource("DataSet5", dss.Tables[5]);
        ReportViewer1.LocalReport.DataSources.Add(datasource4);
        if (dss.Tables[5].Rows.Count > 0)
        {
            base64string1 = dss.Tables[5].Rows[0]["SignedQRCodeImage"].ToString();
        }
        if (base64string1.Length > 0)
        {
            base64string = base64string1.Substring(base64string1.IndexOf("Submission"));
        }
        if (base64string.Length > 0)
        {
            LOGO1 = new Uri(Server.MapPath("~/" + base64string)).AbsoluteUri;
        }
        else { LOGO1 = new Uri(Server.MapPath("~/images/txtbox-mid_90px.png")).AbsoluteUri; }
        ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");

        ReportParameter p1 = new ReportParameter("Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Address", Company_Add);
        ReportParameter p3 = new ReportParameter("Logo", Logo);
        ReportParameter p4 = new ReportParameter("Bill_Type", dss.Tables[4].Rows[0][0].ToString());
        ReportParameter p5 = new ReportParameter("LOGO1", LOGO1);

        ReportParameter[] p = { p1, p2, p3, p4,p5 };
        ReportViewer1.LocalReport.SetParameters(p);
        Report_Print();
    }

    private void load_eri01228()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        //if (Connection.WorkingPeriod() == "01-Apr-2023 - 31-Mar-2024")
        //{
        //    localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_DESKMATE.rdlc";


        //    //CompanyName = "DESKMATE GLOBAL EXPRESS INDIA PVT LTD";

        //    CompanyName = "SSS CLEARING AND FORWARDING PVT LTD"; //NAME CHANGED DESKMATE TO ADWAL
        //    Company_Add = "No. 1-17/9, Plot No. B, Dairy Farm Road," +
        //                  "\r\n" +
        //                  "St.Thomas Mount, Chennai - 600 016." +
        //                      "\r\n" +
        //                         "Phone : 044-22325628  Mob : 9840075628" + 
        //                          "\r\n" +
        //                           "Email :  accounts@ssscfpl.com" +
        //                                "\r\n" +
        //                              "PAN No : AAJCS2144M  GST No: 33AAJCS2144M1Z8";



        //    ServiceTaxno = " 33AAJCS2144M1Z8";
        //    Pan_No = " AAJCS2144M";
        //    Logo = new Uri(Server.MapPath("~/images/Company_Logo/ADWAL.png")).AbsoluteUri;
        //    //CompanyName = "ADWAL GLOBISTICS  PRIVATE LIMITED"; //NAME CHANGED DESKMATE TO ADWAL
        //    //Company_Add = "No. 1-17/9, B Dairy Farm Road," +
        //    //              "\r\n" +
        //    //              "St.Thomas Mount. Chennai - 600016." +
        //    //                  "\r\n" +
        //    //                     "Phone : 044-29545912  Mob : 9840075628" +
        //    //                      "\r\n" +
        //    //                       "Email :  info@adwalglobistics.com" +
        //    //                            "\r\n" +
        //    //                          "PAN No : AASCA2299J  GST No: 33AASCA2299J1Z7";



        //    //ServiceTaxno = " 33AASCA2299J1Z7";
        //    //Pan_No = " AASCA2299J";
        //    //Logo = new Uri(Server.MapPath("~/images/Company_Logo/ADWAL_1.png")).AbsoluteUri;
        //}
        //else
        //{
        //    localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_DESKMATE2.rdlc";
        //    //CompanyName = "Deskmate Global Express India Pvt Ltd";
        //    CompanyName = "ADWAL GLOBISTICS PRIVATE LIMITED"; //NAME CHANGED DESKMATE TO ADWAL
        //    Company_Add = "No. 1-17/9, B Dairy Farm Road," +
        //                  "\r\n" +
        //                  "St.Thomas Mount. Chennai - 600016." +
        //                      "\r\n" +
        //                         "Phone : 044-29545912  Mob : 9840075628" +
        //                          "\r\n" +
        //                           "Email : accounts@adwalglobistics.com" +
        //                                "\r\n" +
        //                              "PAN No : AASCA2299J  GST No: 33AASCA2299J1Z7";



        //    ServiceTaxno = " 33AASCA2299J1Z7";
        //    Pan_No = " AASCA2299J";
        //    Logo = new Uri(Server.MapPath("~/images/Company_Logo/ADWAL_1.png")).AbsoluteUri;

        //}

        if (Connection.WorkingPeriod() == "01-Apr-2022 - 31-Mar-2023")
        {
            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_DESKMATE2.rdlc";
            //CompanyName = "Deskmate Global Express India Pvt Ltd";
            CompanyName = "ADWAL GLOBISTICS PRIVATE LIMITED"; //NAME CHANGED DESKMATE TO ADWAL
            Company_Add = "No. 1-17/9, B Dairy Farm Road," +
                          "\r\n" +
                          "St.Thomas Mount. Chennai - 600016." +
                              "\r\n" +
                                 "Phone : 044-29545912  Mob : 9840075628" +
                                  "\r\n" +
                                   "Email : accounts@adwalglobistics.com" +
                                        "\r\n" +
                                      "PAN No : AASCA2299J  GST No: 33AASCA2299J1Z7";



            ServiceTaxno = " 33AASCA2299J1Z7";
            Pan_No = " AASCA2299J";
            Logo = new Uri(Server.MapPath("~/images/Company_Logo/ADWAL_1.png")).AbsoluteUri;

        }
        else
        {
            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_DESKMATE.rdlc";
            CompanyName = "SSS CLEARING AND FORWARDING PVT LTD"; //NAME CHANGED DESKMATE TO ADWAL TO SSS
            Company_Add = "No. 1-17/9, Plot No. B, Dairy Farm Road," +
                          "\r\n" +
                          "St.Thomas Mount, Chennai - 600 016." +
                              "\r\n" +
                                 "Phone : 044-22325628  Mob : 9840075628" +
                                  "\r\n" +
                                   "Email :  accounts@ssscfpl.com" +
                                        "\r\n" +
                                      "PAN No : AAJCS2144M  GST No: 33AAJCS2144M1Z8";



            ServiceTaxno = " 33AAJCS2144M1Z8";
            Pan_No = " AAJCS2144M";
            Logo = new Uri(Server.MapPath("~/images/Company_Logo/ADWAL.png")).AbsoluteUri;

        }

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


        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }

    private void load_eri01237()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";

        if (dss.Tables[0].Rows[0]["BILL_TYPE"].ToString() == "L")
        {
            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_IPAN_LOCAL.rdlc";
        }
        else
        {
            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_IPAN_OTHER.rdlc";
        }


        CompanyName = "IPAN LOGISTIC PRIVATE LIMITED";
        Company_Add = "28, MOOKER NALLA MUTHU STREET, 1ST FLOOR, ROOM NO 1, CHENNAI 600001." +
                        "\r\n" +
                               "Ph: 9094772745 Email: siva@ipanlogistic.com URL: http://ipanlogistic.com" +
                                "\r\n" +
                                 "STATE [33] TAMIL NADU / GSTIN: 33AACCI5404P1ZI / PAN NO: AACCI5404P";


        ServiceTaxno = " 33AACCI5404P1ZI";
        Pan_No = " AACCI5404P";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/IPAN.png")).AbsoluteUri;

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


        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }
    private void load_eri01316()
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
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_THEESHIKSHA.rdlc";
        CompanyName = "THEESHIKSHA LOGISTIC PRIVATE LIMITED";
        if (dss.Tables[0].Rows[0]["PO_NO"].ToString() == "K")
        {
            Company_Add = "No 97-P4, Vemgal Industries Area," +
                                    "\r\n" +
                                           "Koorgal Village, Kolar - 563101. Karnataka, India." +
                                              "\r\n" +
                                             "Ph: 9790787719  email: cs.chn@tslpl.net";

            ServiceTaxno = " 29AAFCT1412K1ZB";
            Pan_No = " AAFCT1412K";
        }
        else
        {
            Company_Add = "No 20, Ayyasamy 2nd lane, Seedhakadhi nagar," +
                                    "\r\n" +
                                           "Chennai - 600001. Tamil Nadu, India." +
                                              "\r\n" +
                                             "Ph: 9790787719  email: cs.chn@tslpl.net";

            ServiceTaxno = " 33AAFCT1412K1ZM";
            Pan_No = " AAFCT1412K";
        }
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
    private void load_eri01642()
    {

        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_NS.rdlc";


        CompanyName = "NS INTERNATIONAL LOGISTICS";
        Company_Add = "Customs Clearing & Freight Forwarding Agency" +
                        "\r\n" +
                        "No.27, First floor, Dr.Ambedkar street," +
                        "\r\n" +
                        "Meenambakkam, Chennai - 600027." +
                        "\r\n" +
                         "Ph: 044 22560704 Mob: 8098344080 / 8122991552 " +
                        "\r\n" +
                        "Email: nsinternationallogistics5@gmail.com ";

        ServiceTaxno = " 33AVSPN3768K1ZU";
        Pan_No = " AVSPN3768K";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/NS.jpg")).AbsoluteUri;

        LOGO1 = new Uri(Server.MapPath("~/images/Company_Logo/NS.jpg")).AbsoluteUri;

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
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_ROSAN.rdlc";


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
    private void load_eri02102()
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
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_ABL.rdlc";


        CompanyName = "A.B.Logistics";
        Company_Add = "Office No: 211,  2nd Floor, Rishabh Arcade," +
                        "\r\n" +
                               "Plot No. 83, Sector No. 8, Near GST Bhavan," +
                                "\r\n" +
                                 "Gandhidham-Kachchh, Gujarat - 370 201, India." +
                                  "\r\n" +
                                 "Ph: (+91) 02836 232278, 232058" +
                                 "\r\n" +
                                 "email: acc.ablogistics@gmail.com   web: www.ablogistics.in";

        ServiceTaxno = " 24AAQFA2312P1ZC";
        Pan_No = " AAQFA2312P";

        Logo = new Uri(Server.MapPath("~/images/Company_Logo/ABL.png")).AbsoluteUri;
        if (base64string.Length > 0)
        {
            LOGO1 = new Uri(Server.MapPath("~/" + base64string)).AbsoluteUri;
        }
        else { LOGO1 = new Uri(Server.MapPath("~/images/txtbox-mid_90px.png")).AbsoluteUri; }

        LOGO2 = new Uri(Server.MapPath("~/images/Company_Logo/ABL.png")).AbsoluteUri;


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
    private void load_eri02130()
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
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_VRRDDHI.rdlc";


        CompanyName = "VRRDDHI EXPRESS PRIVATE LIMITED";
        Company_Add = "1st Floor, No 809, Block 2, EGA Trade Centre," +
                        "\r\n" +
                               "Poonamallee High Road, Kilpauk," +
                                "\r\n" +
                                 " Chennai, Tamil Nadu, 600 010." +
                                  "\r\n" +
                                 "Ph: 91 44 4051 3333  email: chennai@vrrddhiexpress.co.in";

        ServiceTaxno = " 33AAHCV9245J1ZX";
        Pan_No = " AAHCV9245J";

        Logo = new Uri(Server.MapPath("~/images/Company_Logo/VRRDDHI.png")).AbsoluteUri;
        if (base64string.Length > 0)
        {
            LOGO1 = new Uri(Server.MapPath("~/" + base64string)).AbsoluteUri;
        }
        else { LOGO1 = new Uri(Server.MapPath("~/images/txtbox-mid_90px.png")).AbsoluteUri; }

        LOGO2 = new Uri(Server.MapPath("~/images/Company_Logo/VRRDDHI.png")).AbsoluteUri;


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
    private void load_eri02146()
    {
        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        if (dss.Tables[0].Rows.Count > 0)
        {
            if (dss.Tables[0].Rows[0]["Tax_NonTax"].ToString() == "T" || dss.Tables[0].Rows[0]["Tax_NonTax"].ToString() == "TN")
            {

                if (dss.Tables[0].Rows[0]["Reg_Sez"].ToString() == "R")
                {
                    if (dss.Tables[0].Rows[0]["BILL_TYPE"].ToString() == "L")
                    {
                        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_SASHAA_TL.rdlc";
                    }
                    else
                    {
                        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_SASHAA_TO.rdlc";
                    }
                }
                else
                {
                    if (dss.Tables[0].Rows[0]["BILL_TYPE"].ToString() == "L") //V
                    {
                        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_SASHAA_TL_Sez.rdlc";
                    }
                    else
                    {
                        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_SASHAA_TO_Sez.rdlc";
                    }
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

            else
            {
                localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_SASHAA_RI.rdlc";

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
        }

        CompanyName = " ";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/SASHAA.jpg")).AbsoluteUri;
        ReportViewer1.LocalReport.EnableExternalImages = true;

        ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");
        ReportParameter p1 = new ReportParameter("Name", CompanyName);

        ReportParameter[] p = { p1 };
        ReportViewer1.LocalReport.SetParameters(p);

        Report_Print();

    }
    private void load_eri02159()
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
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_PRIVIA.rdlc";


        CompanyName = "PRIVIA LOGISTICS PRIVATE LIMITED";
        Company_Add = "#20, 1st Floor, Seetha Adhi Nagar," +
                        "\r\n" +
                               "Ayyaswamy Mudali Street, 2nd Lane Clive Battery," +
                                  "\r\n" +
                                  "Chennai - 600 001. Tamil Nadu, India." +
                                  "\r\n" +
                                 "Ph: 09841022159  email:  ac@privia.co.in";

        ServiceTaxno = " 33AAJCP2951P1ZY";
        Pan_No = " AAJCP2951P";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/PRIVIA.png")).AbsoluteUri;

        if (base64string.Length > 0)
        {
            LOGO1 = new Uri(Server.MapPath("~/" + base64string)).AbsoluteUri;
        }
        else { LOGO1 = new Uri(Server.MapPath("~/images/txtbox-mid_90px.png")).AbsoluteUri; }

        LOGO2 = new Uri(Server.MapPath("~/images/Company_Logo/PRIVIA.png")).AbsoluteUri;


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

    private void load_eri02184()
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
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_PLANETBAYS.rdlc";


        CompanyName = "PLANETBAYS LOGISTICS INDIA (OPC) PVT LTD";
        Company_Add = "No A5, 2nd Floor, Boganvilla Park" +
                            "\r\n" +
                       "Annanagar East, Chennai - 600102, India." +
                            "\r\n" +
                       "Ph: 044 47662845    Email: planetbayslogistics@gmail.com";

        ServiceTaxno = " 33AANCP6012D1ZR";
        Pan_No = " AANCP6012D";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/PLANETBAYS.png")).AbsoluteUri;

        if (base64string.Length > 0)
        {
            LOGO1 = new Uri(Server.MapPath("~/" + base64string)).AbsoluteUri;
        }
        else { LOGO1 = new Uri(Server.MapPath("~/images/txtbox-mid_90px.png")).AbsoluteUri; }

        LOGO2 = new Uri(Server.MapPath("~/images/Company_Logo/PLANETBAYS.png")).AbsoluteUri;


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
    private void load_eri02205()
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
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_OMEGA.rdlc";


        CompanyName = "OMEGA SHIPPING AGENCIES";
        Company_Add = "11E/7/2, BRYANT NAGAR," +
                               "\r\n" +
                                "6TH STREET, THOOTHUKUDI - 628008. TAMILNADU, INDIA." +
                                 "\r\n" +
                                "PHONE: 04612310385 , EMAIL:omegaship.tut@gmail.com ";

        ServiceTaxno = " 33AAGFU5762P1ZJ";
        Pan_No = " AAFCP8751M";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/PRATHYUN.png")).AbsoluteUri;
        if (base64string.Length > 0)
        {
            LOGO1 = new Uri(Server.MapPath("~/" + base64string)).AbsoluteUri;
        }
        else { LOGO1 = new Uri(Server.MapPath("~/images/txtbox-mid_90px.png")).AbsoluteUri; }

        LOGO2 = new Uri(Server.MapPath("~/images/Company_Logo/PRATHYUN_AEO_LOGO.png")).AbsoluteUri;


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
    private void load_eri02260()
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
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_LAKSHAABI.rdlc";


        CompanyName = "LAKSHANA AND ABI IMPEX";
        Company_Add = "International Airport , Wireless Road, NO 166," +
                        "\r\n" +
                               "Tiruchirappalli,Tamil Nadu,620007" +
                                "\r\n" +
                                 "Landline: 0431-3560280 ,Cell phone: 73735 35336 & 9344391003 ,EMAIL: lakshaabi2011@gmail.com" +
                                  "\r\n" +
                                 " ";

        ServiceTaxno = " 33BTRPP9211K1Z6";
        Pan_No = " BTRPP9211K";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/LAKSHAABI.jpg")).AbsoluteUri;
        if (base64string.Length > 0)
        {
            LOGO1 = new Uri(Server.MapPath("~/" + base64string)).AbsoluteUri;
        }
        else { LOGO1 = new Uri(Server.MapPath("~/images/txtbox-mid_90px.png")).AbsoluteUri; }

        LOGO2 = new Uri(Server.MapPath("~/images/Company_Logo/LAKSHAABI.jpg")).AbsoluteUri;


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
    private void load_eri02341()
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
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_MULTITRANS.rdlc";


        CompanyName = "M/S.MULTITRANS SHIPPING & CLEARING SERVICES";
        Company_Add = "No.9,Room No.S,IInd FloorReddiyar Garden" +
                        "\r\n" +
                               "N.V Mettur,Kamaraj Nagar,Chennai-71." +
                                "\r\n" +
                                 "Cont: 044-26552212 / 8939523636";

        ServiceTaxno = " 33AAFCP8751M1ZY";
        Pan_No = " AAFCP8751M";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/MULTITRANS.png")).AbsoluteUri;
        if (base64string.Length > 0)
        {
            LOGO1 = new Uri(Server.MapPath("~/" + base64string)).AbsoluteUri;
        }
        else { LOGO1 = new Uri(Server.MapPath("~/images/txtbox-mid_90px.png")).AbsoluteUri; }

        LOGO2 = new Uri(Server.MapPath("~/images/Company_Logo/MULTITRANS.png")).AbsoluteUri;


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
    private void load_eri03069()
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
            if (base64string1.Length > 0)
            {
                base64string = base64string1.Substring(base64string1.IndexOf("Submission"));
            }
        }
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_YASH.rdlc";


        CompanyName = "YASH CONSULTANCY";
        Company_Add = "33-THIRUNEERMALAI MAIN ROAD, 1ST FLOOR," +
                        "\r\n" +
                               "THIRUNEERMALAI, CHENNAI - 600044." +
                                "\r\n" +
                                 "Emails: Yashconsultancy06@gmail.com   Lakshmi@yashconsultancy.com" +
                                  "\r\n" +
                                 "Cell: 094440 81228";

        ServiceTaxno = " 33AADFY4250H1ZA";
        Pan_No = " AADFY4250H";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/YASH.JPEG")).AbsoluteUri;

        if (base64string.Length > 0)
        {
            LOGO1 = new Uri(Server.MapPath("~/" + base64string)).AbsoluteUri;
        }
        else { LOGO1 = new Uri(Server.MapPath("~/images/txtbox-mid_90px.png")).AbsoluteUri; }

        LOGO2 = new Uri(Server.MapPath("~/images/Company_Logo/PRATHYUN_AEO_LOGO.png")).AbsoluteUri;


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
    private void load_eri03094()
    {
        string LOGO1 = "", base64string = "", base64string1 = "";
        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);

        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_CARGO_EASE_mumbai.rdlc";

        if (dss.Tables[0].Rows[0]["PO_NO"].ToString() == "")
            CompanyName = "CARGO EASE PVT. LTD.";
        Company_Add = "OFFICE NO. 002 B - 5, GROUND FLOOR, OM GREEN PARK, NEAR CANARA BANK, BOLINJ NAKA," +
                                "\r\n" +
                                       "401303 (ISO 9001:2015 ) CR.NO: 305024010812Q" +
                                        "\r\n" +
                                         "Tel: 9930362251 / 9822812224 EMail: info@cargoease.in / sanjayamehrotra@hotmail.com";

        ServiceTaxno = " 27AAGCC1934N1ZE";
        Pan_No = " AAGCC1934N";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/SHIVANSH_SHIPPING_MUMBAI.png")).AbsoluteUri;

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
        ReportDataSource datasource4 = new ReportDataSource("DataSet5", dss.Tables[5]);
        ReportViewer1.LocalReport.DataSources.Add(datasource4);

        if (dss.Tables[5].Rows.Count > 0)
        {
            base64string1 = dss.Tables[5].Rows[0]["SignedQRCodeImage"].ToString();
        }
        if (base64string1.Length > 0)
        {
            base64string = base64string1.Substring(base64string1.IndexOf("Submission"));
        }
        if (base64string.Length > 0)
        {
            LOGO1 = new Uri(Server.MapPath("~/" + base64string)).AbsoluteUri;
        }
        else { LOGO1 = new Uri(Server.MapPath("~/images/txtbox-mid_90px.png")).AbsoluteUri; }
        ReportViewer1.LocalReport.DisplayName = "EXPINV " + ddlJob_No.SelectedItem.ToString().Replace("-", "").Replace("/", "").Replace("_", "");

        ReportParameter p1 = new ReportParameter("Name", CompanyName);
        ReportParameter p2 = new ReportParameter("Address", Company_Add);
        ReportParameter p3 = new ReportParameter("Logo", Logo);
        ReportParameter p4 = new ReportParameter("Bill_Type", dss.Tables[4].Rows[0][0].ToString());
        ReportParameter p5 = new ReportParameter("LOGO1", LOGO1);

        ReportParameter[] p = { p1, p2, p3, p4, p5 };
        ReportViewer1.LocalReport.SetParameters(p);
        Report_Print();
    }
    private void load_eri03179()
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

        if (dss.Tables[0].Rows[0]["BILL_TYPE"].ToString() == "L")
        {

            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_NEXGEN_LOCAL.rdlc";
        }
        else
        {
            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_NEXGEN_OTHER.rdlc";
        }


        CompanyName = "NEXGEN TRILINX LOGISTICS";
        Company_Add = "CRYSTAL PARADISE CHS 2ND FLOOR" +
                        "\r\n" +
                               "209 DATTAJI SALVI MARG, ANDHERI (WEST)" +
                                "\r\n" +
                                 " MUMBAI 400053, INDIA." +
                                  "\r\n" +
                                 "TEL: 91-9619614399";

        ServiceTaxno = " 27CVTPD7631L1ZY";
        Pan_No = " CVTPD7631LCH001";

        Logo = new Uri(Server.MapPath("~/images/Company_Logo/NEXGEN.png")).AbsoluteUri;

        if (base64string.Length > 0)
        {
            LOGO1 = new Uri(Server.MapPath("~/" + base64string)).AbsoluteUri;
        }
        else { LOGO1 = new Uri(Server.MapPath("~/images/txtbox-mid_90px.png")).AbsoluteUri; }

        LOGO2 = new Uri(Server.MapPath("~/images/Company_Logo/NEXGEN.png")).AbsoluteUri;

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
    private void load_eri03196()
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
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_SHIVNERI.rdlc";


        CompanyName = "SHIVNERI LOGISTICS LLP";
        Company_Add = "NEELKANTH CORNER CHS.SHOP NO.02 PLOT NO.02, SECTORE.02, SANAPADA(E) NAVI MUMBAI - 400705." +
                                        "\r\n" +
                                         "Tel.: 022-31969125 / 022-65023687 E-mail : admin@shivnerilogistics.com" +
                                          "\r\n" +
                                         "AEO CER. NO.: INADNFS2392D0F224 UDYAM NO.: UDYAM-MH-33-0050376";

        ServiceTaxno = " 27ADNFS2392D1ZU";
        Pan_No = " ADNFS2392D";

        Logo = new Uri(Server.MapPath("~/images/Company_Logo/SHIVNERI.png")).AbsoluteUri;
        if (base64string.Length > 0)
        {
            LOGO1 = new Uri(Server.MapPath("~/" + base64string)).AbsoluteUri;
        }
        else { LOGO1 = new Uri(Server.MapPath("~/images/txtbox-mid_90px.png")).AbsoluteUri; }

        LOGO2 = new Uri(Server.MapPath("~/images/Company_Logo/PRATHYUN_AEO_LOGO.png")).AbsoluteUri;


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

    private void load_eri03204()
    {
        QR_Image = " ";
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        if (dss.Tables[3].Rows.Count > 0)
        {
            QRImage_path = QR_Imagepath(dss.Tables[3].Rows[0]["SignedQRCode"].ToString(), ddlJob_No.SelectedValue.ToString().Replace('/', '_'));
            if (QRImage_path != " ")
            {
                QR_Image = new Uri(QRImage_path).AbsoluteUri;
            }
        }
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_JAY_YESS.rdlc";


        CompanyName = "JAY YESS AGENCIES";
        Company_Add = "No.45/87, First Floor, Coral Merchant Street," +
                                 "\r\n" +
                                 "Mannady, Chennai - 600 001." +
                                  "\r\n" +
                                 "        cha.jayyessagencies@gmail.com / jayyessagencies2024@gmail.com" +
                                  "\r\n" +
                                 "Mob: 9360688811 / 7200083557";


        ServiceTaxno = " 33AACFJ8957D2ZB";
        Pan_No = " AACFJ8957D";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/JAY_YESS.JPG")).AbsoluteUri;
        LOGO2 = new Uri(Server.MapPath("~/images/Company_Logo/PRATHYUN_AEO_LOGO.png")).AbsoluteUri;


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
        ReportParameter p9 = new ReportParameter("LOGO1", QR_Image);
        ReportParameter p10 = new ReportParameter("LOGO2", LOGO2);


        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 };
        ReportViewer1.LocalReport.SetParameters(p);
        Report_Print();
    }


    private void load_eri03229()
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
        if (dss.Tables[0].Rows[0]["BILL_INV_NO"].ToString().Substring(0, 2) != "FF")
        {
            if (dss.Tables[0].Rows[0]["LOCAL_OTHER"].ToString() == "L")
            {
                localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_PL_GLOBAL_TL.rdlc";
            }
            else if (dss.Tables[0].Rows[0]["LOCAL_OTHER"].ToString() == "O")
            {
                localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_PL_GLOBAL_TO.rdlc";
            }
        }
        else
        {
            if (dss.Tables[0].Rows[0]["LOCAL_OTHER"].ToString() == "L")
            {
                localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_PL_GLOBAL_FL.rdlc";
            }
            else if (dss.Tables[0].Rows[0]["LOCAL_OTHER"].ToString() == "O")
            {
                localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_PL_GLOBAL_FO.rdlc";
            }
        }


        CompanyName = "PL GLOBAL FORWARDERS PRIVATE LIMITED";
        Company_Add = "No.8 Kodi krupa, Ground Floor 5th cross, Airview colony Konenna Agrahara, HAL" +
                        "\r\n" +
                               "Bengaluru - 560017, KARNATAKA" +
                                "\r\n" +
                                 "Tel. No.-08025230388" +
                                  "\r\n" +
                                 "Email -accountspll@pllogistics.co.in";

        ServiceTaxno = " 29AAICP5876G1ZT";
        Pan_No = " AAICP5876G";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/PLGLOBAL.png")).AbsoluteUri;
        if (base64string.Length > 0)
        {
            LOGO1 = new Uri(Server.MapPath("~/" + base64string)).AbsoluteUri;
        }
        else { LOGO1 = new Uri(Server.MapPath("~/images/txtbox-mid_90px.png")).AbsoluteUri; }

        LOGO2 = new Uri(Server.MapPath("~/images/Company_Logo/PLGLOBAL.png")).AbsoluteUri;


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
    private void load_eri03275()
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
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_QUICKLINK.rdlc";        
        CompanyName = "QUICK LINK CARGO SERVICES";
        Company_Add = "WZ-209/4, CABIN NO 5, VARINDER NAGAR," +
                        "\r\n" +
                               "GALI NO 3, P O JANAKPURI, NEW DELHI - 110058." +
                                "\r\n" +
                                 "Ph No: 9911217373, 9212217373   Email: billing@qlcsdelhi.com";

        ServiceTaxno = " 07AAAFQ0944M1Z4";
        Pan_No = " AAAFQ0944M";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/QUICKLINK.jpg")).AbsoluteUri;
        if (base64string.Length > 0)
        {
            LOGO1 = new Uri(Server.MapPath("~/" + base64string)).AbsoluteUri;
        }
        else { LOGO1 = new Uri(Server.MapPath("~/images/txtbox-mid_90px.png")).AbsoluteUri; }

        LOGO2 = new Uri(Server.MapPath("~/images/Company_Logo/PRATHYUN_AEO_LOGO.png")).AbsoluteUri;


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

    private void load_eri03233()
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
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_AGS.rdlc";
        CompanyName = "AGS CLEARING & FORWARDING";
        Company_Add = "DOOR NO.945, 54TH STREET, T.V.S COLONY," +
                        "\r\n" +
                               "ANNA NAGAR WEST EXTENSION, CHENNAI - 600101" +
                                 "\r\n" +
                                 "ags_aegishipping@hotmail.com & ags_cf@hotmail.com";


        ServiceTaxno = " 33ALMPL2869F1ZX";
        Pan_No = " ALMPL2869F";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/AGS.png")).AbsoluteUri;

        if (base64string.Length > 0)
        {
            LOGO1 = new Uri(Server.MapPath("~/" + base64string)).AbsoluteUri;
        }
        else { LOGO1 = new Uri(Server.MapPath("~/images/txtbox-mid_90px.png")).AbsoluteUri; }

        LOGO2 = new Uri(Server.MapPath("~/images/Company_Logo/AGS.png")).AbsoluteUri;


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
    private void load_eri03423()
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
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_ASS.rdlc";
        CompanyName = "ASS FREIGHT FORWARDERS";
        Company_Add = "DOOR NO.945, 54TH STREET, T.V.S COLONY," +
                        "\r\n" +
                               "ANNA NAGAR WEST EXTENSION, CHENNAI - 600101" +
                                 "\r\n" +
                                 "assfreight@gmail.com & ags_aegishipping@hotmail.com";


        ServiceTaxno = " 33CJYPS7828F2ZE";
        Pan_No = " CJYPS7828F"; 
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/ASS.png")).AbsoluteUri;

        if (base64string.Length > 0)
        {
            LOGO1 = new Uri(Server.MapPath("~/" + base64string)).AbsoluteUri;
        }
        else { LOGO1 = new Uri(Server.MapPath("~/images/txtbox-mid_90px.png")).AbsoluteUri; }

        LOGO2 = new Uri(Server.MapPath("~/images/Company_Logo/ASS.png")).AbsoluteUri;


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
    private void load_eri04003()
    {
        phy_path = string.Empty;
        QR_Image = " ";
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        //if (ObjUBO.BILL_INV_NO == "PSI2526/2622" || ObjUBO.BILL_INV_NO == "PSI2526/2623" || ObjUBO.BILL_INV_NO == "PSI2526/2624" || ObjUBO.BILL_INV_NO == "PSI2526/2625" || ObjUBO.BILL_INV_NO == "PSI2526/2631" || ObjUBO.BILL_INV_NO == "PSI2526/2658" || ObjUBO.BILL_INV_NO == "PSI2526/2606" || ObjUBO.BILL_INV_NO == "PSI2526/2874")
        if (dss.Tables[3].Rows.Count > 0)
        {
            phy_path = Server.MapPath("~/Submission/" + Connection.COMPANYID() + "/GST_BILL_QRCODE/" + "/Auto");
            QRImage_path = QRCI.QRCode_to_Image(dss.Tables[3].Rows[0]["SignedQRCode"].ToString(), ddlJob_No.SelectedValue.ToString().Replace('/', '_'), phy_path);
            if (QRImage_path != "")
            {
                QR_Image = new Uri(QRImage_path).AbsoluteUri;
            }
        }
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_OM_LOGISTICS.rdlc";
        CompanyName = "OM LOGISTICS";
        Company_Add = "Head Office: Ofc No. 710, 7th Floor, Jhelum CHS Ltd., " +
                        "\r\n" +
                               "Sanjay Kokate Lane, Bhatwadi, Ghatkopar (West), Mumbai 400084, India." +
                                "\r\n" +
                                 "Branch Office: M-30 Shyam Park, Nawada Uttam Nagar, " +
                                  "\r\n" +
                                 "New Delhi 110059, India   Mob: 7506590054";

        ServiceTaxno = " 27APUPD5047B1ZY";
        Pan_No = " APUPD5047B";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/OM_LOGISTICS.png")).AbsoluteUri;
        LOGO2 = new Uri(Server.MapPath("~/images/Company_Logo/PRATHYUN_AEO_LOGO.png")).AbsoluteUri;


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
        ReportParameter p9 = new ReportParameter("LOGO1", QR_Image);
        ReportParameter p10 = new ReportParameter("LOGO2", LOGO2);


        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 };
        ReportViewer1.LocalReport.SetParameters(p);
        Report_Print();
    }

    private void load_eri04012()
    {
        phy_path = string.Empty;
        QR_Image = " ";
        DataSet dss = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;

        ObjUBO.BILL_INV_NO = ddlJob_No.SelectedValue.ToString();
        dss = BI.Invoice_Job_Rpt_data(ObjUBO);
        string TaxMode = " ";
        //if (ObjUBO.BILL_INV_NO == "PSI2526/2622" || ObjUBO.BILL_INV_NO == "PSI2526/2623" || ObjUBO.BILL_INV_NO == "PSI2526/2624" || ObjUBO.BILL_INV_NO == "PSI2526/2625" || ObjUBO.BILL_INV_NO == "PSI2526/2631" || ObjUBO.BILL_INV_NO == "PSI2526/2658" || ObjUBO.BILL_INV_NO == "PSI2526/2606" || ObjUBO.BILL_INV_NO == "PSI2526/2874")
        if (dss.Tables[3].Rows.Count > 0)
        {
            phy_path = Server.MapPath("~/Submission/" + Connection.COMPANYID() + "/GST_BILL_QRCODE/" + "/Auto");
            QRImage_path = QRCI.QRCode_to_Image(dss.Tables[3].Rows[0]["SignedQRCode"].ToString(), ddlJob_No.SelectedValue.ToString().Replace('/', '_'), phy_path);
            if (QRImage_path != "")
            {
                QR_Image = new Uri(QRImage_path).AbsoluteUri;
            }
        }
        localReport.ReportPath = @"Billing_Exp_Rpt/GST_Bill_Export_Job_rpt_TYM.rdlc";
        CompanyName = "TYM LOGISTICS SERVICES PRIVATE LIMITED";
        Company_Add = "C-16/2, C-17 Ground Floor,Vishwakarma Colony," +
                        "\r\n" +
                               "M.B. Road, New Delhi - 110044 (INDIA)." +
                                "\r\n" +
                                 "Email: info@tymlogistics.in / tymlogs@gmail.com" +
                                  "\r\n" +
                                 "Tel: +91-11-4602-7128  Web: www.tymlogistics.in ";

        ServiceTaxno = " 07AAICT3677R1ZD";
        Pan_No = " AAICT3677R";
        Logo = new Uri(Server.MapPath("~/images/Company_Logo/TYM.png")).AbsoluteUri;
        LOGO2 = new Uri(Server.MapPath("~/images/Company_Logo/TYM.png")).AbsoluteUri;


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
        ReportParameter p9 = new ReportParameter("LOGO1", QR_Image);
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
        //pdf_open();
    }

    protected void btnpdf_Click(object sender, EventArgs e)
    {
        byte[] bytes = (byte[])Session["report"];
        Response.ClearHeaders();
        Response.Clear();
        Response.ContentType = "application/pdf";
        string File_name = "EXPINV" + (ViewState["File_Name"].ToString()).Replace("-", "").Replace("/", "").Replace("_", "");

        Company_Lic = Connection.Company_License().ToLower();
        if (Company_Lic == "eri00517")
        {
            //File_name = (ViewState["File_Name"].ToString());            
            File_name = hd_BILL_No_JOB_No.Value;
        }
        Response.AddHeader("content-disposition", "attachment;filename=" + File_name + ".pdf");

        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.BinaryWrite(bytes);
        Response.End();
    }
    private void pdf_open()
    {
        byte[] bytes = (byte[])Session["report"];
        Response.ClearHeaders();
        Response.Clear();
        Response.ContentType = "application/pdf";
        string File_name = "EXPINV" + (ViewState["File_Name"].ToString()).Replace("-", "").Replace("/", "").Replace("_", "");

        Company_Lic = Connection.Company_License().ToLower();
        if (Company_Lic == "eri00517")
        {
            //File_name = (ViewState["File_Name"].ToString());            
            File_name = hd_BILL_No_JOB_No.Value;
        }
        Response.AddHeader("content-disposition", "attachment;filename=" + File_name + ".pdf");

        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.BinaryWrite(bytes);
        Response.End();
    }
    private string QR_Imagepath(string SignedQRCode, string Invno)
    {
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
                    //errorFolder = Server.MapPath("~/Submission/" + "/Accounts/" + Connection.COMPANYID() + "/ACC_GST_BILL_QRCODE/" + "/" + Connection.Current_User() + "/");
                    //errorFolder = Server.MapPath("~/Submission/" + Connection.COMPANYID() + "/GST_BILL_QRCODE/" + "/Auto" + "/" + Connection.Current_User() + "/");
                    errorFolder = Server.MapPath("~/Submission/" + Connection.COMPANYID() + "/GST_BILL_QRCODE/" + "/Auto" + "/");
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
                    imagename = Invno.Replace("/", "_") + ".png";
                    QRimgpath = errorFolder + imagename;
                    img.Save(QRimgpath);
                }
            }
        }
        return QRimgpath;
    }

}