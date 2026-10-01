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
//using System.Drawing.Printing;

//using System.Windows.Forms;
//using Microsoft.Reporting.WinForms;
//using System.Web.UI.WebControls.WebParts;
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
    public string SELECT_TYPE, SELECT_BRANCH;
    
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
         *   * */
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

                    Session["JobNo"] = ddlJobNo;

                    string Y1 = working_period.Substring(9, 2);
                    string Y2 = working_period.Substring(23, 2);
                    string Covering_No = "";

                    LocalReport localReport = ReportViewer1.LocalReport;
                    List<ReportParameter> paramList = new List<ReportParameter>();

                    ObjUBO.SW_ID = ddlJobNo;
                    ObjUBO.COVERING_NO = ddlJobNo;
                    ObjUBO.TYPE = "";
                    ObjUBO.BRANCH_CODE = currentbranch;
                    ObjUBO.WORKING_PERIOD = SELECT_BRANCH;
                    ObjUBO.flag = "Bind_COVERING_LETTER_DETAILS";

                    if (report_type == "Pegasus_Report")
                    {
                        ds = LTR.RetrieveAll_CoveringLetter_Details_Pegasus(ObjUBO);
                    }
                    else
                    {
                        ds = LTR.RetrieveAll_CoveringLetter_Details(ObjUBO);
                    }

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //if (ds.Tables[0].Rows[0]["TYPE"].ToString() == "Import")
                        //{
                        //    Covering_No = "IMP/" + ds.Tables[0].Rows[0]["COVERING_NO"].ToString() + "/" + Y1 + "-" + Y2;
                        //}
                        //else
                        //{
                        //    Covering_No = "EXP/" + ds.Tables[0].Rows[0]["COVERING_NO"].ToString() + "/" + Y1 + "-" + Y2;
                        //}

                        Covering_No = ds.Tables[0].Rows[0]["COVERING_PS"].ToString();
                    }


                    if (Connection.COMPANYID() == "480" || Connection.COMPANYID() == "1019" || Connection.COMPANYID() == "10")
                    {
                        if (report_type == "BMW")
                        {
                            if (ds.Tables[0].Rows[0]["TYPE"].ToString() == "Import")
                            {
                                localReport.ReportPath = @"Billing_Imp_Rpt/GST_Bill_Covering_Letter_SANCO_BMW.rdlc";
                            }
                            else
                            {
                                localReport.ReportPath = @"Billing_Imp_Rpt/GST_Bill_Covering_Letter_SANCO_BMW_Export.rdlc";
                            }
                        }
                        if (report_type == "CFS")
                        {
                            localReport.ReportPath = @"Billing_Imp_Rpt/GST_Bill_Covering_Letter_SANCO_CFS.rdlc";
                        }
                        if (report_type == "GENERAL")
                        {
                            localReport.ReportPath = @"Billing_Imp_Rpt/GST_Bill_Covering_Letter_SANCO_GENERAL.rdlc";
                        }
                    }
                    else if (Connection.COMPANYID() == "508" || Connection.COMPANYID() == "10")
                    {
                        localReport.ReportPath = @"Billing_Imp_Rpt/GST_Bill_Covering_Letter_PEGASUS.rdlc";
                        Covering_No = ds.Tables[0].Rows[0]["BILL_YOUR_REF_NO"].ToString();
                    }
                    else
                    {
                        localReport.ReportPath = @"Billing_Imp_Rpt/GST_Bill_Covering_Letter_Report.rdlc";
                    }

                    this.ReportViewer1.LocalReport.SetParameters(paramList);
                    ReportViewer1.LocalReport.DataSources.Clear();

                    DataTable dt_bill = new DataTable();

                    if (Connection.COMPANYID() == "480" || Connection.COMPANYID() == "1019" || Connection.COMPANYID() == "10")
                    {
                        if (report_type == "BMW")
                        {
   
                            dt_bill.Columns.Add("ID");
                            dt_bill.Columns.Add("BILL_INVOICE_NO");
                            dt_bill.Columns.Add("BILL_INVOICE_DATE");
                            dt_bill.Columns.Add("REF_NO");
                            dt_bill.Columns.Add("NO_OF_CONTAINER");
                            dt_bill.Columns.Add("SCOPE");
                            dt_bill.Columns.Add("AMOUNT");
                            dt_bill.Columns.Add("PARTY_REF");
                           
                        }
                        else if (report_type == "CFS")
                        {
                            dt_bill.Columns.Add("ID");
                            dt_bill.Columns.Add("BILL_INVOICE_NO");
                            dt_bill.Columns.Add("BILL_INVOICE_DATE");
                            dt_bill.Columns.Add("REF_NO");
                            dt_bill.Columns.Add("AMOUNT");
                            dt_bill.Columns.Add("AMOUNT1");// cfs Amount
                            dt_bill.Columns.Add("ATTACHEMENT");
                            //dt_bill.Columns.Add("SCFS BILL.NO/DT");
                            dt_bill.Columns.Add("SCFS_BILLNO");
                            dt_bill.Columns.Add("PARTY_REF");
                           
                        }
                        else if (report_type == "GENERAL")
                        {
                            dt_bill.Columns.Add("ID");
                            dt_bill.Columns.Add("BILL_INVOICE_NO");
                            dt_bill.Columns.Add("BILL_INVOICE_DATE");
                            dt_bill.Columns.Add("REF_NO");
                            dt_bill.Columns.Add("AMOUNT");
                            dt_bill.Columns.Add("PARTY_REF");
                        }
                    }
                    else
                    {
                        dt_bill.Columns.Add("ID");
                        dt_bill.Columns.Add("BILL_INVOICE_NO");
                        dt_bill.Columns.Add("BILL_INVOICE_DATE");
                        dt_bill.Columns.Add("BILL_REMARKS");
                        dt_bill.Columns.Add("TOTAL");
                    }

                    double tot_SUM = 0.00;
                    double cfs_tot_SUM = 0.00;
                    string No_Of_Cont = "";
                    string scope = "";
                    double CFS_Grand_tot = 0.00;

                    if (report_type != "Pegasus_Report")
                    {

                        if (ds.Tables[0].Rows[0]["BILL_INVOICE_NO"].ToString().Length > 0)
                        {
                            string[] a = ds.Tables[0].Rows[0]["BILL_INVOICE_NO"].ToString().Trim().Split('^');
                            string[] b = ds.Tables[0].Rows[0]["BILL_INVOICE_DATE"].ToString().Trim().Split('^');
                            string[] c = ds.Tables[0].Rows[0]["BILL_REMARKS"].ToString().Trim().Split('^');
                            string[] d = ds.Tables[0].Rows[0]["TOTAL"].ToString().Trim().Replace("&nbsp;", "").Replace("&amp;", "").Replace("nbsp;", "").Split('^');
                            string[] e = ds.Tables[0].Rows[0]["PARTY_REF_NO"].ToString().Trim().Split('^');
                            string[] f = ds.Tables[0].Rows[0]["BILL_CFS_CHARGE"].ToString().Trim().Replace("&nbsp;", "").Replace("&amp;", "").Replace("nbsp;", "").Split('^');
                            string[] g = ds.Tables[0].Rows[0]["ATTACHMENT_DET"].ToString().Trim().Replace("&nbsp;", "").Replace("&amp;", "").Replace("nbsp;", "").Split('^');

                            int cnt = a.Count();

                            for (int j = 0; j <= cnt - 1; j++)
                            {
                                if (a[j] != "")
                                {
                                    string[] val1 = a[j].Split('*');
                                    if (val1[1] == "T")
                                    {

                                        /* to Get Container Number & Charge Details for BMW- SANCO */
                                        DataSet ds_con = new DataSet();
                                        if (Connection.COMPANYID() == "480" || Connection.COMPANYID() == "1019" || Connection.COMPANYID() == "10")
                                        {

                                            ObjUBO.SW_ID = ddlJobNo;
                                            ObjUBO.COVERING_NO = val1[0];
                                            ObjUBO.TYPE = Request.QueryString["Type"].ToString();
                                            ObjUBO.BRANCH_CODE = currentbranch;
                                            ObjUBO.WORKING_PERIOD = SELECT_BRANCH;
                                            ObjUBO.BRANCH_COMMON = SELECT_BRANCH;

                                            ObjUBO.flag = "SELECT_Container_Charge_details";

                                            ds_con = LTR.RetrieveAll_CoveringLetter_Details(ObjUBO);

                                            if (report_type == "BMW")
                                            {
                                                if (ds_con.Tables[0].Rows.Count > 0)
                                                {
                                                    No_Of_Cont = ds_con.Tables[0].Rows[0]["CONTAINER_SIZE"].ToString();

                                                    /*
                                                    string[] ContainerNo = ds_con.Tables[0].Rows[0]["CONTAINER_NO"].ToString().Trim().Split(',');
                                                    int count = ContainerNo.Count();

                                                    if (ContainerNo[0] != "")
                                                    {
                                                        if (Request.QueryString["Type"].ToString() == "Import")
                                                        {
                                                            No_Of_Cont = count + " X " + ds_con.Tables[0].Rows[0]["CONTAINER_SIZE"].ToString() + "'";
                                                        }
                                                        else
                                                        {
                                                            No_Of_Cont = Convert.ToString(count);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        No_Of_Cont = "";
                                                    }
                                                     * */
                                                }

                                                if (ds_con.Tables[1].Rows.Count > 0)
                                                {
                                                    //scope = ds_con.Tables[1].Rows[0]["CHARGE_NAME"].ToString().Replace("^", Environment.NewLine);
                                                    scope = "Ocean Import Customs Clearance";
                                                }
                                            }
                                        }

                                        if (d[j] == "")
                                        {
                                            d[j] = "0.00";
                                        }

                                        if (Connection.COMPANYID() == "480" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "1019")
                                        {

                                            string PartyRef = "";
                                            if (e.Count() == 1)// is empty or null value check
                                            {
                                                PartyRef = "";
                                            }
                                            else
                                            {
                                                PartyRef = e[j];
                                            }

                                          
                                            if (f.Count() == 1)// is empty or null value check
                                            {
                                                cfscharge = "";
                                            }
                                            else
                                            {
                                                cfscharge = f[j];
                                            }

                                            if (report_type == "BMW")
                                            {
                                                if (ds_con.Tables[0].Rows.Count > 0)
                                                {
                                                    dt_bill.Rows.Add(j, a[j].Replace("*T", "").Replace("*F", ""), b[j], ds_con.Tables[0].Rows[0]["YOUR_REF"].ToString(), No_Of_Cont, scope, d[j], ds_con.Tables[0].Rows[0]["PARTY_REF"].ToString());
                                                }
                                            }
                                            else if (report_type == "CFS")
                                            {
                                                if (ds_con.Tables[0].Rows.Count > 0)
                                                {
                                                    //dt_bill.Rows.Add(j, a[j].Replace("*T", "").Replace("*F", ""), b[j], ds_con.Tables[0].Rows[0]["YOUR_REF"].ToString(), d[j], cfscharge, "", "", ds_con.Tables[0].Rows[0]["PARTY_REF"].ToString());
                                                    dt_bill.Rows.Add(j, a[j].Replace("*T", "").Replace("*F", ""), b[j], ds_con.Tables[0].Rows[0]["YOUR_REF"].ToString(), d[j], cfscharge, "", g[j], ds_con.Tables[0].Rows[0]["PARTY_REF"].ToString());
                                                }
                                            }
                                            else if (report_type == "GENERAL")
                                            {
                                                if (ds_con.Tables[0].Rows.Count > 0)
                                                {
                                                    dt_bill.Rows.Add(j, a[j].Replace("*T", "").Replace("*F", ""), b[j], ds_con.Tables[0].Rows[0]["YOUR_REF"].ToString(), d[j], ds_con.Tables[0].Rows[0]["PARTY_REF"].ToString());
                                                }
                                            }
                                        }
                                        else
                                        {
                                            dt_bill.Rows.Add(j, a[j].Replace("*T", "").Replace("*F", ""), b[j], c[j], d[j]);
                                        }

                                        double Val = d[j] == string.Empty ? 0 : Convert.ToDouble(d[j]);
                                        tot_SUM += Val;

                                        double cfs_amt = cfscharge == string.Empty ? 0 : Convert.ToDouble(cfscharge);
                                        cfs_tot_SUM += cfs_amt;
                                    }
                                }
                            }
                        }
                    }
                    if (report_type == "BMW")
                    {
                        if (ds.Tables[0].Rows[0]["SCFS_AMOUNT"].ToString() != "")
                        {
                            string CFS_AMOUNT = ds.Tables[0].Rows[0]["SCFS_AMOUNT"].ToString();
                            tot_SUM = tot_SUM + Convert.ToDouble(CFS_AMOUNT);
                        }
                    }
                    if (report_type == "CFS")
                    {
                        CFS_Grand_tot = tot_SUM + cfs_tot_SUM;
                    }
                   
                    ReportDataSource dataSS = new ReportDataSource("DataSet1", dt_bill);
                    ReportViewer1.LocalReport.DataSources.Add(dataSS);

                   
                    ReportParameter p0 = new ReportParameter("Covering_No", Covering_No);
                    ReportParameter p1 = new ReportParameter("DISPATCH_DATE", ds.Tables[0].Rows[0]["DISPATCH_DATE"].ToString());
                    ReportParameter p2 = new ReportParameter("ADD1", ds.Tables[0].Rows[0]["ADD1"].ToString());
                    ReportParameter p3 = new ReportParameter("ADD2", ds.Tables[0].Rows[0]["ADD2"].ToString());
                    ReportParameter p4 = new ReportParameter("ADD3", ds.Tables[0].Rows[0]["ADD3"].ToString());
                    ReportParameter p5 = new ReportParameter("ADD4", ds.Tables[0].Rows[0]["ADD4"].ToString());
                    ReportParameter p6 = new ReportParameter("SUBJECT", ds.Tables[0].Rows[0]["SUBJECT"].ToString());
                    ReportParameter p7 = new ReportParameter("TOTAL", Convert.ToString(Convert.ToDouble(tot_SUM).ToString("0.00")));
                    ReportParameter p8 = new ReportParameter("ROUND", Convert.ToString(Math.Round(Convert.ToDouble(tot_SUM), 0).ToString("0.00")));
                    ReportParameter p9 = new ReportParameter("PARTY_NAME", ds.Tables[0].Rows[0]["PARTY_NAME"].ToString());
                    ReportParameter p10 = new ReportParameter("ATTACHMENT", ds.Tables[0].Rows[0]["ATTACHMENT"].ToString());

                    if (report_type != "Pegasus_Report")
                    {
                        //ReportParameter p11 = new ReportParameter("SCFS_AMOUNT", ds.Tables[0].Rows[0]["SCFS_AMOUNT"].ToString());
                        ReportParameter p11 = new ReportParameter("SCFS_AMOUNT", Convert.ToString(Convert.ToDouble(cfs_tot_SUM).ToString("0.00")));

                        ReportParameter p12 = new ReportParameter("SCFS_BILL_NO", ds.Tables[0].Rows[0]["SCFS_BILL_NO"].ToString());
                        ReportParameter p13 = new ReportParameter("CFS_BILLNO", ds.Tables[0].Rows[0]["CFS_BILLNO"].ToString());
                        ReportParameter p14 = new ReportParameter("SCOPE_CFS_AMOUNT", "Container Yard Handling Chgs");
                        ReportParameter p15 = new ReportParameter("CFS_AMOUNT", ds.Tables[0].Rows[0]["SCFS_AMOUNT"].ToString());
                        ReportParameter p16 = new ReportParameter("CFS_Grand_tot", Convert.ToString(Convert.ToDouble(CFS_Grand_tot).ToString("0.00")));


                        if (report_type == "CFS")
                        {
                            ReportParameter[] p = { p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p16 };
                            ReportViewer1.LocalReport.SetParameters(p);
                        }
                        else if (report_type == "GENERAL")
                        {
                            ReportParameter[] p = { p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 };
                            ReportViewer1.LocalReport.SetParameters(p);
                        }
                        else
                        {
                            ReportParameter[] p = { p0, p1, p2, p3, p4, p5, p6, p7, p8, p10, p13, p14, p15 };
                            ReportViewer1.LocalReport.SetParameters(p);
                        }
                    }
                    else if (report_type == "Pegasus_Report")
                    {
                        ReportParameter p16 = new ReportParameter("REF_NO", ds.Tables[0].Rows[0]["REF_NO"].ToString());
                        ReportParameter p17 = new ReportParameter("ENTERED_BY", ds.Tables[0].Rows[0]["ENTERED_BY"].ToString());


                        ReportParameter[] p = { p0, p1, p2, p3, p4, p5, p6, p9, p10, p16, p17 };
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




