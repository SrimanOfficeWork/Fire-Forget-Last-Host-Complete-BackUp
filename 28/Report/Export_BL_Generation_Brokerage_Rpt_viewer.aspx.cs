using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Data.SqlClient;
using System.IO;
using Microsoft.ApplicationBlocks.Data;
using System.ComponentModel;
using System.Drawing.Printing;
//using System.Drawing.Printing;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Web.UI.WebControls.WebParts;
//using ReportViewerLib;
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Reporting.WebForms;
using Microsoft.ReportingServices.Rendering;
using Microsoft.ReportingServices.Library;


public partial class Export_BL_Generation_Brokerage_Rpt_viewer : System.Web.UI.Page
{

    public string working_period;

    AppSession aps = new AppSession();
    //Transaction Transact = new Transaction();
    //adminmaster adm = new adminmaster();
    EXP_BL_Generation BL_GEN = new EXP_BL_Generation();
    DataSet ds_amt = new DataSet();


    public string Exporter_ADDRESS1, Volume_or_Container, lbl_Volume_or_Container, Frt_Vol_Header, Frt_Vol_VALUE;
    string CompanyName, Company_Add, ServiceTaxno, Remarks, Logo, AGENTS_NAME_1, REPORT_TYPE;
    DataSet ds = new DataSet();
    DataSet dss = new DataSet();
   
    public string currentuser, ddlJobNo;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate,testaddress;
    public string SELECT_TYPE, SELECT_BRANCH,Print_type,Page_Name,AGENT_ADD;
    public string Words;
    string Agent_add1, Agent_add2, Agent_add3, Agent_add4, Agent_add5, Agent_add6, Agent_add7, Agent_add8;

    //Date_Time dt = new Date_Time();
    
    //DataTable dtt = new DataTable();

    List<Export_BL_Generation_Brokerage_Rpt_viewer> Load_Brokerage_BL_Generation = new List<Export_BL_Generation_Brokerage_Rpt_viewer>();

    //List<NForm> NForm = new List<NForm>();
    List<NForm> Load_NForm_Details = new List<NForm>();

   
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = HttpContext.Current.Session["currentcomp_db"].ToString();
        working_period = HttpContext.Current.Session["WorkingPeriod"].ToString();
        LoginDate = HttpContext.Current.Session["LoginDate"].ToString();
            // commented for areawise implementation on 05-mar-2020
        /*
        if (Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = Session["SELECT_TYPE"].ToString();

            if (SELECT_TYPE == "Branchwise Job")
            {
                SELECT_BRANCH = currentbranch;
            }
            else
            {
                SELECT_BRANCH = "";
            }
        }
        else
        {
            SELECT_BRANCH = "";
        }
          * */
        SELECT_BRANCH = Connection.Get_Company_Type();
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

                ReportViewer1.LocalReport.EnableExternalImages = true;
                ReportViewer1.LocalReport.DataSources.Clear();
              
                List<ReportParameter> paramList = new List<ReportParameter>(); this.ReportViewer1.LocalReport.SetParameters(paramList);

                ReportViewer1.LocalReport.DataSources.Clear();

                BL_GEN.JOBNO = Request.QueryString["jobno"].ToString();
                BL_GEN.BRANCHCODE = SELECT_BRANCH;
                ds = BL_GEN.BL_Rpt();

                /* *************** AGENT ADDRESS ********************** */

                AGENT_ADD = ds.Tables[0].Rows[0]["AGENTS_NAEE_REFNO"].ToString();

                //if (AGENT_ADD != "")
                //{
                    if (AGENT_ADD.Contains(","))
                    {
                        string[] aa = AGENT_ADD.Split('~');

                        string a1 = aa[0];
                        string a2 = aa[1];
                        string a3 = aa[2];
                        string a4 = aa[3];
                        string a5 = aa[4];
                        string a6 = aa[5];
                        string a7 = aa[6];
                        string a8 = aa[7];


                        Agent_add1 = string.IsNullOrEmpty(aa[0]) ? a1 : aa[0];
                        Agent_add2 = string.IsNullOrEmpty(aa[1]) ? a2 : aa[1];
                        Agent_add3 = string.IsNullOrEmpty(aa[2]) ? a3 : aa[2];
                        Agent_add4 = string.IsNullOrEmpty(aa[3]) ? a4 : aa[3];
                        Agent_add5 = string.IsNullOrEmpty(aa[4]) ? a5 : aa[4];
                        Agent_add6 = string.IsNullOrEmpty(aa[5]) ? a6 : aa[5];
                        Agent_add7 = string.IsNullOrEmpty(aa[6]) ? a7 : aa[6];
                        Agent_add8 = string.IsNullOrEmpty(aa[6]) ? a8 : aa[7];

                        //}

                    }
                    else
                    {
                        Agent_add1 = AGENT_ADD;
                        Agent_add2 = string.Empty;
                        Agent_add3 = string.Empty;
                        Agent_add4 = string.Empty;
                        Agent_add5 = string.Empty;
                        Agent_add6 = string.Empty;
                        Agent_add7 = string.Empty;
                        Agent_add8 = string.Empty;
                    }
             

                /*************** CONTAINER NO *******************/

                int Count = ds.Tables[2].Rows.Count;
                string str1 = "";

                for (int i = 0; i <= Count-1; i++)
                {
                    string container_no = ds.Tables[2].Rows[i]["CONTAINER_NO_ONLY"].ToString() + Environment.NewLine +"/ "+ ds.Tables[2].Rows[i]["TYPE"].ToString();

                    string str = container_no +Environment.NewLine;
                   
                    str1 += str;
                }

                string All_ContainerNo = str1;

                Exporter_ADDRESS1 = ds.Tables[0].Rows[0]["ADDRESS1_ONLY"].ToString();

                AGENTS_NAME_1 = ds.Tables[0].Rows[0]["AGENTS_NAME"].ToString();
                REPORT_TYPE = ds.Tables[0].Rows[0]["RPT_TYPE"].ToString();

                if (REPORT_TYPE == "Brokerage")
                {
                    REPORT_TYPE = "BROKERAGE RECEIVABLE";
                }
                else
                {
                    REPORT_TYPE = "REFUND CHARGES";
                }


                /************* FREIGHT CALCULATION ******************/

                string ShipmentType = ds.Tables[0].Rows[0]["SHIPMENT_TYPE"].ToString();
                string FreightAmt = ds.Tables[0].Rows[0]["FREIGHT_AMT"].ToString();
                string Volume = ds.Tables[0].Rows[0]["TOTALVOLUME"].ToString();
                string ExRate = ds.Tables[0].Rows[0]["EX_RATE"].ToString();
                double FreightAmt_val = 0.00;
                double Volume_val = 0.00;
                double ExRate_val = 0.00;
                double FrieghtINR = 0.00;

                if (FreightAmt != "")
                {
                     FreightAmt_val = Convert.ToDouble(FreightAmt);
                }
                else
                {
                     FreightAmt_val = 0.00;
                }

                if (Volume != "")
                {
                     Volume_val = Convert.ToDouble(Volume);
                }
                else
                {
                     Volume_val = 0.00;
                }

                if (ExRate != "")
                {
                     ExRate_val = Convert.ToDouble(ExRate);
                }
                else
                {
                     ExRate_val = 0.00;
                }
                
                if (ShipmentType == "FCL")
                {
                    FrieghtINR = FreightAmt_val * ExRate_val;
                    Volume_or_Container = ds.Tables[0].Rows[0]["NO_OF_CONTAINERS"].ToString();
                    lbl_Volume_or_Container = "No Of Container";
                    Frt_Vol_Header = "NO OF CONTAINER";
                    Frt_Vol_VALUE = ds.Tables[0].Rows[0]["FREIGHT_AMT"].ToString();
                }
                else if (ShipmentType == "LCL")
                {
                    FrieghtINR = Volume_val * ExRate_val;
                    Volume_or_Container = ds.Tables[0].Rows[0]["TOTALVOLUME"].ToString() + " " + ds.Tables[0].Rows[0]["TOT_VOL_UNIT"].ToString();
                    lbl_Volume_or_Container = "Volume CBM";
                    Frt_Vol_Header = "VOLUME";
                    Frt_Vol_VALUE = ds.Tables[0].Rows[0]["TOTALVOLUME"].ToString();

                }
                else
                {
                    FrieghtINR = 0.00;
                }

                string Total_Bill_Amount = ds.Tables[0].Rows[0]["TOTAL_BILLAMT"].ToString();

                if (Total_Bill_Amount != "")
                {
                    double Total_Bill_Amt = Convert.ToDouble(Total_Bill_Amount);
                    BL_GEN.JOBNO = Request.QueryString["jobno"].ToString();
                    BL_GEN.BRANCHCODE = SELECT_BRANCH;
                    BL_GEN.Ename = "Total_BillAmt_Num_to_Words";
                    ds_amt = BL_GEN.BL_Select_All();

                    if (ds_amt.Tables[0].Rows.Count > 0)
                    {
                        Words = ds_amt.Tables[0].Rows[0]["WORDS"].ToString();
                    }
                }

                //Get_Num_to_Words(Total_Bill_Amt);

                if (Session["COMPANY_LICENSE"].ToString() == "eri00002")
                {
                    CompanyName = "ORIENTAL SHIPPING & CLEARING AGENCY PVT. LTD.,";
                    Company_Add = "1/22 B , M..K.N  ROAD," +
                                    "\r\n" +
                                    "ALANDUR," +
                                     "\r\n" +
                                           "CHENNAI -600016 ," +
                                            "\r\n" +
                                            "PHONE:22312516," +
                                             "\r\n" +
                                             "FAX: 22312513";
                    ServiceTaxno = " ";
                    Logo = new Uri(Server.MapPath("~/images/Company_Logo/OSCA.png")).AbsoluteUri;
                }
                else
                {
                    CompanyName = "BLUE WORLD CARGO";
                    Company_Add = "BWC TOWERS," +
                                    "4TH FLOOR,NEW NO. 46/2 OLD NO.37/2," +
                                     "\r\n" +
                                           "NORTH BEACH ROAD 3RD LINE" +
                                            "\r\n" +
                                            "CLIVE BATTERY" +","+
                                             "CHENNAI 600 001" +
                                             "\r\n" +
                                             "PHONE NO: 044-25225178,25241958" +" "+"FAX : 044-25242925"+
                                              "\r\n" +
                                             "SERVICE TAX NO:AACFB0739PST001" +
                                              "  " +
                                             "PAN NO : AACFB0739P" +
                                               "\r\n" +
                                             "WEBSITE: www.bwclogistics.com" + "   "+"GSTN NO: 33AACFB0739P2ZE"+
                                             "\r\n" + "e-Mail: info@bwclogistics.com";

                    ServiceTaxno = "AACFB0739PST001";
                    Logo = new Uri(Server.MapPath("~/images/Company_Logo/BLUE WORLD Cargo logo.JPG")).AbsoluteUri;
                }

                ReportDataSource dataSS = new ReportDataSource("Export_BL_Item", ds.Tables[0]);
                ReportViewer1.LocalReport.DataSources.Add(dataSS);
           
                ReportParameter Exporter_Name1 = new ReportParameter("Exporter_ADDRESS1", Exporter_ADDRESS1);
                ReportParameter FrieghtINR1 = new ReportParameter("FrieghtINR", Convert.ToString(FrieghtINR).ToString());
                ReportParameter All_ContainerNo1 = new ReportParameter("All_ContainerNo", All_ContainerNo);
                ReportParameter JOB_DATE1 = new ReportParameter("JOB_DATE", ds.Tables[0].Rows[0]["JOB_DATE"].ToString());
                ReportParameter DBN_NO1 = new ReportParameter("DBN_NO", ds.Tables[0].Rows[0]["DBN_NO"].ToString());
                ReportParameter DBN_DATE1 = new ReportParameter("DBN_DATE", ds.Tables[0].Rows[0]["DBN_DATE"].ToString());
                ReportParameter Words1 = new ReportParameter("Words", Words);
                ReportParameter Volume_or_Container1 = new ReportParameter("Volume_or_Container", Volume_or_Container);
                ReportParameter lbl_Volume_or_Container1 = new ReportParameter("lbl_Volume_or_Container", lbl_Volume_or_Container);
                ReportParameter Frt_Vol_Header1 = new ReportParameter("Frt_Vol_Header", Frt_Vol_Header);
                ReportParameter Frt_Vol_VALUE1 = new ReportParameter("Frt_Vol_VALUE", Frt_Vol_VALUE);
                ReportParameter AGENTS_NAME = new ReportParameter("AGENTS_NAME", AGENTS_NAME_1);

                ReportParameter p1 = new ReportParameter("Name", CompanyName);
                ReportParameter p2 = new ReportParameter("Address", Company_Add);
                ReportParameter p3 = new ReportParameter("ServiceTaxno", ServiceTaxno);
                ReportParameter Logo1 = new ReportParameter("Logo", Logo);

                ReportParameter AgentAdress1 = new ReportParameter("Agent_add1", Agent_add1);
                ReportParameter AgentAdress2 = new ReportParameter("Agent_add2", Agent_add2);
                ReportParameter AgentAdress3 = new ReportParameter("Agent_add3", Agent_add3);
                ReportParameter AgentAdress4 = new ReportParameter("Agent_add4", Agent_add4);
                ReportParameter AgentAdress5 = new ReportParameter("Agent_add5", Agent_add5);
                ReportParameter AgentAdress6 = new ReportParameter("Agent_add6", Agent_add6 + " " + Agent_add7);
                ReportParameter AgentAdress_GSTN = new ReportParameter("Agent_GSTN", Agent_add8);


                ReportParameter REPORT_TYPE1 = new ReportParameter("REPORT_TYPE", REPORT_TYPE);

                //ReportParameter CHA_ADDRESS4 = new ReportParameter("cha_add3", HttpContext.Current.Session["CHA_ADDRESS2"].ToString());

                ReportParameter[] p = { Exporter_Name1, FrieghtINR1, All_ContainerNo1, JOB_DATE1, DBN_NO1, DBN_DATE1, Words1, Volume_or_Container1,
                                          lbl_Volume_or_Container1, Logo1, p1, p2, p3, Frt_Vol_Header1, Frt_Vol_VALUE1, AGENTS_NAME,
                                          AgentAdress1,AgentAdress2,AgentAdress3,AgentAdress4,AgentAdress5,AgentAdress6,REPORT_TYPE1,AgentAdress_GSTN
                                      };
                ReportViewer1.LocalReport.SetParameters(p);
               
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

    public void Get_Num_to_Words(double value)
    {
        BL_GEN.JOBNO = Request.QueryString["jobno"].ToString();
        BL_GEN.BRANCHCODE = SELECT_BRANCH;
        BL_GEN.Ename = "Total_BillAmt_Num_to_Words";
        ds = BL_GEN.BL_Select_All();
    }

}




