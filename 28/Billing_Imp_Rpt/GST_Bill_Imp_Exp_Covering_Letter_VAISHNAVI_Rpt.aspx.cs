using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Linq;
using System.IO;
using Microsoft.ApplicationBlocks.Data;
using System.ComponentModel;
using System.Drawing.Printing;

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
using AjaxControlToolkit;
using Microsoft.ReportingServices.Rendering;
using Microsoft.ReportingServices.Library;
using BussinessObject;

public partial class GST_Bill_Imp_Exp_Covering_Letter_Rpt : System.Web.UI.Page
{

    public string working_period;

    AppSession aps = new AppSession();
    Transaction Transact = new Transaction();
    adminmaster adm = new adminmaster();

    Billing_UserBO ObjUBO = new Billing_UserBO();
    Covering_LTR LTR = new Covering_LTR();

    private string _Workingperiod;
  
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
   

    public string Workingperiod
    {
        get { return _Workingperiod; }
        set { _Workingperiod = value; }
    }

    public string currentuser, ddlJobNo;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate,testaddress;
    public string SELECT_TYPE, SELECT_BRANCH, Logo;
    
    CheckList CHKLIST = new CheckList();
    Date_Time dt = new Date_Time();   
    DataTable dtt = new DataTable();
    string cfscharge = "";

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
               
                    string report_type = Request.QueryString["report_type"].ToString();
                    string type = Request.QueryString["Type"].ToString();


                    Session["JobNo"] = ddlJobNo;

                    string Y1 = working_period.Substring(9, 2);
                    string Y2 = working_period.Substring(23, 2);
                   
                    LocalReport localReport = ReportViewer1.LocalReport;
                    List<ReportParameter> paramList = new List<ReportParameter>();

                    ObjUBO.ID = ddlJobNo;
                    ObjUBO.COVERING_NO = ddlJobNo;
                    ObjUBO.TYPE = type;
                    ObjUBO.BRANCH_CODE = currentbranch;
                    ObjUBO.WORKING_PERIOD = SELECT_BRANCH;
                    ObjUBO.flag = "Bind_COVERING_LETTER_DETAILS";

                    if (report_type == "Vaishnavi_Report")
                    {
                        ds = LTR.RetrieveAll_CoveringLetter_Details_Vaishnavi(ObjUBO);
                        Logo = new Uri(Server.MapPath("~/images/Company_Logo/VAISHNAVI.jpg")).AbsoluteUri;
                        localReport.ReportPath = @"Billing_Imp_Rpt/GST_Bill_Covering_Letter_VAISHNAVI.rdlc";
                    }

                    string Attachemnt = "";
                    string Details = "";
                    string DT = "";
                    string Date = "";
                    string OC = "";
                    string OC_Details = "";
                    string TOP_Details = "";

                     int slno=0;

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["INVOICE"].ToString() == "T")
                        {
                            slno++;
                            //Attachemnt = slno + ".Invoice";
                            TOP_Details = slno + ".Invoice" + Environment.NewLine;
                        }
                        
                        if (ds.Tables[0].Rows[0]["PACKINGLIST"].ToString() == "T")
                        {
                            slno++;
                            //Attachemnt = Attachemnt+Environment.NewLine + slno  + ".Packing List";
                            TOP_Details = TOP_Details + Environment.NewLine + slno + ".Packing List" + Environment.NewLine;
                        }
                       
                        if (ds.Tables[0].Rows[0]["BILL_OF_ENTRY"].ToString() != "")
                        {
                            string[] sp = ds.Tables[0].Rows[0]["BILL_OF_ENTRY"].ToString().Split('~');
                            if (sp[0] != "")
                            {
                                slno++;
                                //Attachemnt = Attachemnt + Environment.NewLine + slno + ".Bill of Entry    " + sp[1] + "Dt " + sp[2] + " Duplicate (Original/Copy) " + sp[3] + " /Tripicate(Original/ Copy)" + sp[4] + Environment.NewLine +"                          "+ "--------------------";
                                //Attachemnt = Attachemnt + Environment.NewLine + slno + ".Bill of Entry        " + sp[1] + "   Dt  " + sp[2] + "      Duplicate (Original/Copy)  " + sp[3] + "    /Tripicate(Original/ Copy)   " + sp[4] + Environment.NewLine ;
                                //Attachemnt = Attachemnt + Environment.NewLine + slno + ".Bill of Entry";
                                //Details = Details + Environment.NewLine + sp[1];
                                //DT = DT + Environment.NewLine + "DT";
                                //Date = Date + Environment.NewLine + sp[2];
                                //OC = OC + Environment.NewLine + "Original / Copy ";
                                //OC_Details = OC_Details + Environment.NewLine + sp[3];
                                TOP_Details = TOP_Details + Environment.NewLine + slno + ".Bill of Entry         " + sp[1] + "   Dt  " + sp[2] + "      Duplicate (Original/Copy)  " + sp[3] + "    /Tripicate(Original/ Copy)   " + sp[4] + Environment.NewLine;
                            }
                        }

                        if (ds.Tables[0].Rows[0]["SHIPPING_BILL"].ToString() != "")
                        {
                            string[] sp = ds.Tables[0].Rows[0]["SHIPPING_BILL"].ToString().Split('~');
                            if (sp[0] != "")
                            {
                                slno++;
                                //Attachemnt = Attachemnt + Environment.NewLine + slno + ".Bill of Entry    " + sp[1] + "Dt " + sp[2] + " Duplicate (Original/Copy) " + sp[3] + " /Tripicate(Original/ Copy)" + sp[4] + Environment.NewLine +"                          "+ "--------------------";
                                //Attachemnt = Attachemnt + Environment.NewLine + slno + ".Shipping Bill No        " + sp[1] + "   Dt  " + sp[2] + "      Duplicate (Original/Copy)  " + sp[3] + "    /Tripicate(Original/ Copy)   " + sp[4] + Environment.NewLine;
                                //Attachemnt = Attachemnt + Environment.NewLine + slno + ".Shipping Bill No";
                                //Details = Details + Environment.NewLine + sp[1];
                                //DT = DT + Environment.NewLine + "DT";
                                //Date = Date + Environment.NewLine + sp[2];
                                //OC = OC + Environment.NewLine + "Original / Copy ";
                                //OC_Details = OC_Details + Environment.NewLine + sp[3];
                                TOP_Details = TOP_Details + Environment.NewLine + slno + ".Shipping Bill No        " + sp[1] + "   Dt  " + sp[2] + "      Duplicate (Original/Copy)  " + sp[3] + "    /Tripicate(Original/ Copy)   " + sp[4];
                            }
                        }

                        if (ds.Tables[0].Rows[0]["BILL_OF_LADING"].ToString() != "")
                        {
                            string[] sp = ds.Tables[0].Rows[0]["BILL_OF_LADING"].ToString().Split('~');
                            if (sp[0] != "")
                            {
                                slno++;
                                //Attachemnt = Attachemnt + Environment.NewLine + slno + ".Bill of Lading / AWB No  " + sp[1] + "   Dt  " + sp[2] + "      Duplicate (Original/Copy)  " + sp[3] + Environment.NewLine;
                                Attachemnt = Attachemnt + Environment.NewLine + slno + ".Bill of Lading / AWB No" + Environment.NewLine;
                                Details = Details + Environment.NewLine + sp[1] + Environment.NewLine;
                                DT = DT + Environment.NewLine + "DT" + Environment.NewLine;
                                Date = Date + Environment.NewLine + sp[2] + Environment.NewLine;
                                OC = OC + Environment.NewLine + "Original / Copy " + Environment.NewLine;
                                OC_Details = OC_Details + Environment.NewLine + sp[3] + Environment.NewLine;
                            }
                        }

                        if (ds.Tables[0].Rows[0]["STPI_IMPORT"].ToString() != "")
                        {
                            string[] sp = ds.Tables[0].Rows[0]["STPI_IMPORT"].ToString().Split('~');
                            if (sp[0] != "")
                            {
                                slno++;
                                //Attachemnt = Attachemnt + Environment.NewLine + slno + ".STPI Import Apprl. No    " + sp[1] + "   Dt  " + sp[2] + "      Duplicate (Original/Copy)  " + sp[3] + Environment.NewLine;
                                Attachemnt = Attachemnt + Environment.NewLine + slno + ".STPI Import Apprl. No" + Environment.NewLine;
                                Details = Details + Environment.NewLine + sp[1] + Environment.NewLine;
                                DT = DT + Environment.NewLine + "DT" + Environment.NewLine;
                                Date = Date + Environment.NewLine + sp[2] + Environment.NewLine;
                                OC = OC + Environment.NewLine + "Original / Copy " + Environment.NewLine;
                                OC_Details = OC_Details + Environment.NewLine + sp[3] + Environment.NewLine;
                            }
                        }

                        if (ds.Tables[0].Rows[0]["PROCUREMENT_CERT"].ToString() != "")
                        {
                            string[] sp = ds.Tables[0].Rows[0]["PROCUREMENT_CERT"].ToString().Split('~');
                            if (sp[0] != "")
                            {
                                slno++;
                                //Attachemnt = Attachemnt + Environment.NewLine + slno + ".Procurement Certificate No" + sp[1] + "   Dt  " + sp[2] + "      Duplicate (Original/Copy)  " + sp[3] + Environment.NewLine;
                                Attachemnt = Attachemnt + Environment.NewLine + slno + ".Procurement Certificate No" + Environment.NewLine;
                                Details = Details + Environment.NewLine + sp[1] + Environment.NewLine;
                                DT = DT + Environment.NewLine + "DT" + Environment.NewLine;
                                Date = Date + Environment.NewLine + sp[2] + Environment.NewLine;
                                OC = OC + Environment.NewLine + "Original / Copy " + Environment.NewLine;
                                OC_Details = OC_Details + Environment.NewLine + sp[3] + Environment.NewLine;
                            }
                        }

                        if (ds.Tables[0].Rows[0]["CERTIFICATE_OF_ORIGIN"].ToString() != "")
                        {
                            string[] sp = ds.Tables[0].Rows[0]["CERTIFICATE_OF_ORIGIN"].ToString().Split('~');
                            if (sp[0] != "")
                            {
                                slno++;
                                //Attachemnt = Attachemnt + Environment.NewLine + slno + ".Certificate of Origin No.  " + sp[1] + "   Dt  " + sp[2] + "      Duplicate (Original/Copy)  " + sp[3] + Environment.NewLine;
                                Attachemnt = Attachemnt + Environment.NewLine + slno + ".Certificate of Origin No." + Environment.NewLine;
                                Details = Details + Environment.NewLine + sp[1] + Environment.NewLine;
                                DT = DT + Environment.NewLine + "DT" + Environment.NewLine;
                                Date = Date + Environment.NewLine + sp[2] + Environment.NewLine;
                                OC = OC + Environment.NewLine + "Original / Copy " + Environment.NewLine;
                                OC_Details = OC_Details + Environment.NewLine + sp[3] + Environment.NewLine;
                            }
                        }

                        if (ds.Tables[0].Rows[0]["DUTY_PAID"].ToString() != "")
                        {
                            string[] sp = ds.Tables[0].Rows[0]["DUTY_PAID"].ToString().Split('~');
                            if (sp[0] != "")
                            {
                                slno++;
                                //Attachemnt = Attachemnt + Environment.NewLine + slno + ".Duty Paid TR 6 Challan No. " + sp[1] + "   Dt  " + sp[2] + "      Duplicate (Original/Copy)  " + sp[3] + Environment.NewLine;
                                Attachemnt = Attachemnt + Environment.NewLine + slno + ".Duty Paid TR 6 Challan No." + Environment.NewLine;
                                Details = Details + Environment.NewLine + sp[1] + Environment.NewLine;
                                DT = DT + Environment.NewLine + "DT" + Environment.NewLine;
                                Date = Date + Environment.NewLine + sp[2] + Environment.NewLine;
                                OC = OC + Environment.NewLine + "Original / Copy " + Environment.NewLine;
                                OC_Details = OC_Details + Environment.NewLine + sp[3] + Environment.NewLine;
                            }
                        }

                        if (ds.Tables[0].Rows[0]["DO_RECEIPT"].ToString() != "")
                        {
                            string[] sp = ds.Tables[0].Rows[0]["DO_RECEIPT"].ToString().Split('~');
                            if (sp[0] != "")
                            {
                                slno++;
                                //Attachemnt = Attachemnt + Environment.NewLine + slno + ".D.O. Receipt No(Air/Sea)    " + sp[1] + "   Dt  " + sp[2] + "      Duplicate (Original/Copy)  " + sp[3] + Environment.NewLine;
                                Attachemnt = Attachemnt + Environment.NewLine + slno + ".D.O. Receipt No(Air/Sea)" + Environment.NewLine;
                                Details = Details + Environment.NewLine + sp[1] + Environment.NewLine;
                                DT = DT + Environment.NewLine + "DT" + Environment.NewLine;
                                Date = Date + Environment.NewLine + sp[2] + Environment.NewLine;
                                OC = OC + Environment.NewLine + "Original / Copy " + Environment.NewLine;
                                OC_Details = OC_Details + Environment.NewLine + sp[3] + Environment.NewLine;
                            }
                        }

                        if (ds.Tables[0].Rows[0]["EDI_COUPON_RECEIPT"].ToString() != "")
                        {
                            string[] sp = ds.Tables[0].Rows[0]["EDI_COUPON_RECEIPT"].ToString().Split('~');
                            if (sp[0] != "")
                            {
                                slno++;
                                //Attachemnt = Attachemnt + Environment.NewLine + slno + ".EDI Coupon Recpt No.         " + sp[1] + "   Dt  " + sp[2] + "      Duplicate (Original/Copy)  " + sp[3] + Environment.NewLine;
                                Attachemnt = Attachemnt + Environment.NewLine + slno + ".EDI Coupon Recpt No." + Environment.NewLine;
                                Details = Details + Environment.NewLine + sp[1] + Environment.NewLine;
                                DT = DT + Environment.NewLine + "DT" + Environment.NewLine;
                                Date = Date + Environment.NewLine + sp[2] + Environment.NewLine;
                                OC = OC + Environment.NewLine + "Original / Copy " + Environment.NewLine;
                                OC_Details = OC_Details + Environment.NewLine + sp[3] + Environment.NewLine;
                            }
                        }

                        if (ds.Tables[0].Rows[0]["CFS_RECEIPT"].ToString() != "")
                        {
                            string[] sp = ds.Tables[0].Rows[0]["CFS_RECEIPT"].ToString().Split('~');
                            if (sp[0] != "")
                            {
                                slno++;
                                //Attachemnt = Attachemnt + Environment.NewLine + slno + ".EDI Coupon Recpt No.         " + sp[1] + "   Dt  " + sp[2] + "      Duplicate (Original/Copy)  " + sp[3] + Environment.NewLine;
                                Attachemnt = Attachemnt + Environment.NewLine + slno + ".CFS Recept No." + Environment.NewLine;
                                Details = Details + Environment.NewLine + sp[1] + Environment.NewLine;
                                DT = DT + Environment.NewLine + "DT" + Environment.NewLine;
                                Date = Date + Environment.NewLine + sp[2] + Environment.NewLine;
                                OC = OC + Environment.NewLine + "Original / Copy " + Environment.NewLine;
                                OC_Details = OC_Details + Environment.NewLine + sp[3] + Environment.NewLine;
                            }
                        }

                        if (ds.Tables[0].Rows[0]["IAAI_RECEIPTNO"].ToString() != "")
                        {
                            string[] sp = ds.Tables[0].Rows[0]["IAAI_RECEIPTNO"].ToString().Split('~');
                            if (sp[0] != "")
                            {
                                slno++;
                                //Attachemnt = Attachemnt + Environment.NewLine + slno + ".EDI Coupon Recpt No.         " + sp[1] + "   Dt  " + sp[2] + "      Duplicate (Original/Copy)  " + sp[3] + Environment.NewLine;
                                Attachemnt = Attachemnt + Environment.NewLine + slno + ".IAAI / Harbour Due Recpt. No." + Environment.NewLine;
                                Details = Details + Environment.NewLine + sp[1] + Environment.NewLine;
                                DT = DT + Environment.NewLine + "DT" + Environment.NewLine;
                                Date = Date + Environment.NewLine + sp[2] + Environment.NewLine;
                                OC = OC + Environment.NewLine + "Original / Copy " + Environment.NewLine;
                                OC_Details = OC_Details + Environment.NewLine + sp[3] + Environment.NewLine;
                            }
                        }

                        if (ds.Tables[0].Rows[0]["ESCORT_CONVEYANCE"].ToString() != "")
                        {
                            string[] sp = ds.Tables[0].Rows[0]["ESCORT_CONVEYANCE"].ToString().Split('~');
                            if (sp[0] != "")
                            {
                                slno++;
                                //Attachemnt = Attachemnt + Environment.NewLine + slno + ".EDI Coupon Recpt No.         " + sp[1] + "   Dt  " + sp[2] + "      Duplicate (Original/Copy)  " + sp[3] + Environment.NewLine;
                                Attachemnt = Attachemnt + Environment.NewLine + slno + ".Escort Conveyance Bill No" + Environment.NewLine;
                                Details = Details + Environment.NewLine + sp[1] + Environment.NewLine;
                                DT = DT + Environment.NewLine + "DT" + Environment.NewLine;
                                Date = Date + Environment.NewLine + sp[2] + Environment.NewLine;
                                OC = OC + Environment.NewLine + "Original / Copy " + Environment.NewLine;
                                OC_Details = OC_Details + Environment.NewLine + sp[3] + Environment.NewLine;
                            }
                        }

                        if (ds.Tables[0].Rows[0]["TRANSPORT_BILL_NO"].ToString() != "")
                        {
                            string[] sp = ds.Tables[0].Rows[0]["TRANSPORT_BILL_NO"].ToString().Split('~');
                            if (sp[0] != "")
                            {
                                slno++;
                                //Attachemnt = Attachemnt + Environment.NewLine + slno + ".EDI Coupon Recpt No.         " + sp[1] + "   Dt  " + sp[2] + "      Duplicate (Original/Copy)  " + sp[3] + Environment.NewLine;
                                Attachemnt = Attachemnt + Environment.NewLine + slno + ".Transport Bill No" + Environment.NewLine;
                                Details = Details + Environment.NewLine + sp[1] + Environment.NewLine;
                                DT = DT + Environment.NewLine + "DT" + Environment.NewLine;
                                Date = Date + Environment.NewLine + sp[2] + Environment.NewLine;
                                OC = OC + Environment.NewLine + "Original / Copy " + Environment.NewLine;
                                OC_Details = OC_Details + Environment.NewLine + sp[3] + Environment.NewLine;
                            }
                        }

                        if (ds.Tables[0].Rows[0]["VEHICLE_PASS"].ToString() != "")
                        {
                            string[] sp = ds.Tables[0].Rows[0]["VEHICLE_PASS"].ToString().Split('~');
                            if (sp[0] != "")
                            {
                                slno++;
                                //Attachemnt = Attachemnt + Environment.NewLine + slno + ".EDI Coupon Recpt No.         " + sp[1] + "   Dt  " + sp[2] + "      Duplicate (Original/Copy)  " + sp[3] + Environment.NewLine;
                                Attachemnt = Attachemnt + Environment.NewLine + slno + ".Vehicle Pass No" + Environment.NewLine;
                                Details = Details + Environment.NewLine + sp[1] + Environment.NewLine;
                                DT = DT + Environment.NewLine + "DT" + Environment.NewLine;
                                Date = Date + Environment.NewLine + sp[2] + Environment.NewLine;
                                OC = OC + Environment.NewLine + "Original / Copy " + Environment.NewLine;
                                OC_Details = OC_Details + Environment.NewLine + sp[3] + Environment.NewLine;
                            }
                        }

                        if (ds.Tables[0].Rows[0]["INSURANCE_CERTNO"].ToString() != "")
                        {
                            string[] sp = ds.Tables[0].Rows[0]["INSURANCE_CERTNO"].ToString().Split('~');
                            if (sp[0] != "")
                            {
                                slno++;
                                //Attachemnt = Attachemnt + Environment.NewLine + slno + ".EDI Coupon Recpt No.         " + sp[1] + "   Dt  " + sp[2] + "      Duplicate (Original/Copy)  " + sp[3] + Environment.NewLine;
                                Attachemnt = Attachemnt + Environment.NewLine + slno + ".Insurance Cert. No" + Environment.NewLine;
                                Details = Details + Environment.NewLine + sp[1] + Environment.NewLine;
                                DT = DT + Environment.NewLine + "DT" + Environment.NewLine;
                                Date = Date + Environment.NewLine + sp[2] + Environment.NewLine;
                                OC = OC + Environment.NewLine + "Original / Copy " + Environment.NewLine;
                                OC_Details = OC_Details + Environment.NewLine + sp[3] + Environment.NewLine;
                            }
                        }
                        if (ds.Tables[0].Rows[0]["CE_CERTIFICATE_NO"].ToString() != "")
                        {
                            string[] sp = ds.Tables[0].Rows[0]["CE_CERTIFICATE_NO"].ToString().Split('~');
                            if (sp[0] != "")
                            {
                                slno++;
                                //Attachemnt = Attachemnt + Environment.NewLine + slno + ".EDI Coupon Recpt No.         " + sp[1] + "   Dt  " + sp[2] + "      Duplicate (Original/Copy)  " + sp[3] + Environment.NewLine;
                                Attachemnt = Attachemnt + Environment.NewLine + slno + ".C.E. Certificate No" + Environment.NewLine;
                                Details = Details + Environment.NewLine + sp[1] + Environment.NewLine;
                                DT = DT + Environment.NewLine + "DT" + Environment.NewLine;
                                Date = Date + Environment.NewLine + sp[2] + Environment.NewLine;
                                OC = OC + Environment.NewLine + "Original / Copy " + Environment.NewLine;
                                OC_Details = OC_Details + Environment.NewLine + sp[3] + Environment.NewLine;
                            }
                        }


                    }
                   
                    //this.ReportViewer1.LocalReport.SetParameters(paramList);
                    //ReportViewer1.LocalReport.DataSources.Clear();


                    //ReportDataSource dataSS = new ReportDataSource("DataSet1", ds);
                    //ReportViewer1.LocalReport.DataSources.Add(dataSS);
                    ReportViewer1.LocalReport.EnableExternalImages = true;

                    ReportParameter p0 = new ReportParameter("COVERING_REF_NO", ds.Tables[0].Rows[0]["COVERING_REF_NO"].ToString());
                    ReportParameter p1 = new ReportParameter("COVERING_REF_DATE", ds.Tables[0].Rows[0]["COVERING_REF_DATE"].ToString());
                    ReportParameter p2 = new ReportParameter("BILL_NO", ds.Tables[0].Rows[0]["BILL_NO"].ToString());
                    ReportParameter p3 = new ReportParameter("BILL_DATE", ds.Tables[0].Rows[0]["BILL_DATE"].ToString());
                    ReportParameter p4 = new ReportParameter("BILL_AMOUNT", ds.Tables[0].Rows[0]["BILL_AMOUNT"].ToString());
                    ReportParameter p5 = new ReportParameter("CLIENT_NAME", ds.Tables[0].Rows[0]["CLIENT_NAME"].ToString());
                    ReportParameter p6 = new ReportParameter("ADD1", ds.Tables[0].Rows[0]["ADD1"].ToString());
                    ReportParameter p7 = new ReportParameter("ADD2", ds.Tables[0].Rows[0]["ADD2"].ToString());
                    ReportParameter p8 = new ReportParameter("ADD3", ds.Tables[0].Rows[0]["ADD3"].ToString());
                    ReportParameter p9 = new ReportParameter("ADD4", ds.Tables[0].Rows[0]["ADD4"].ToString());
                    ReportParameter p10 = new ReportParameter("ANYOTHER_DOC", ds.Tables[0].Rows[0]["ANYOTHER_DOC"].ToString());
                    ReportParameter p11 = new ReportParameter("ATTACHMENT", Attachemnt);
                    ReportParameter p12 = new ReportParameter("SUBJECT", ds.Tables[0].Rows[0]["SUBJECT"].ToString());
                    ReportParameter p13 = new ReportParameter("DETAILS", Details);
                    ReportParameter p14 = new ReportParameter("DATE", Date);
                    ReportParameter p15 = new ReportParameter("OC", OC);
                    ReportParameter p16 = new ReportParameter("OC_Details", OC_Details);
                    ReportParameter p17 = new ReportParameter("DT", DT);
                    ReportParameter p18 = new ReportParameter("TOP_Details", TOP_Details);
                    ReportParameter p19 = new ReportParameter("Logo", Logo);

                

                    if (report_type == "Vaishnavi_Report")
                    {

                        ReportParameter[] p = { p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19 };
                        ReportViewer1.LocalReport.SetParameters(p);
                    }
                    else
                    {

                    }

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
}




