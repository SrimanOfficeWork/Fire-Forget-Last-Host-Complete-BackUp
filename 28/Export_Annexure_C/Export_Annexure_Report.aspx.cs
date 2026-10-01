using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Data.SqlClient;

using System.IO;
using Microsoft.ApplicationBlocks.Data;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
//using Microsoft.Reporting.WinForms;
using System.Web.UI.WebControls.WebParts;
//using ReportViewerLib;+
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Microsoft.Reporting.WebForms;

public partial class Report_Export_Export_ReportViewer : System.Web.UI.Page
{
    eroyalmaster Imp_Exp = new eroyalmaster();
    AnnexureC Annex_C = new AnnexureC();
    AppSession aps = new AppSession();
    Transaction Transact = new Transaction();
    adminmaster adm = new adminmaster();

    private string _Workingperiod, _INVOICE_ID, _REMAINING_QTY;
    public string FreightCharges, FR_Currency, Ins_Charges, Ins_Currency;
    public string working_period;

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
    public string LoginDate, testaddress;
    public string SELECT_TYPE, SELECT_BRANCH;


    string Jobtype;
    string sbno, sbDate;
   
   
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = HttpContext.Current.Session["currentcomp_db"].ToString();
        working_period = HttpContext.Current.Session["WorkingPeriod"].ToString();

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
            if (Request.QueryString["jobno"] == "" || Request.QueryString["jobno"] == null)
            {

            }
            else
            {

                Jobtype = Request.QueryString["Annexure_Mode"].ToString();

                if (Request.QueryString["Direct_AnxC"] == "Y")
                {

                    
                    Response.Redirect("../Export_Annexure_C/Export_Annexure_Report.aspx?jobno=" + Request.QueryString["jobno"].ToString() + "&Annexure_Mode=" + Jobtype + "");
                }


                else
                {

                    Page_loaItem_Details();
                }
            }

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
                //Jobtype = Request.QueryString["Annexure_Mode"].ToString();

                ddlJobNo = Request.QueryString["jobno"].ToString();
                Session["JobNo"] = ddlJobNo;

                if (Jobtype == "Sea" || Jobtype == "Land")
                {
                    Sea_Job();
                }
                else if (Jobtype == "Air")
                {
                    Air_Job();
                }
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog
                (ex.Message);
        }
    }



    private void Sea_Job()
    {
        DataSet ds = new DataSet();
        DateTime d = new DateTime();
       
        LocalReport localReport = ReportViewer1.LocalReport;
        localReport.ReportPath = @"Export_Annexure_C\AnnexCReport.rdlc";

        List<ReportParameter> paramList1 = new List<ReportParameter>();
        this.ReportViewer1.LocalReport.SetParameters(paramList1);
        ReportViewer1.LocalReport.DataSources.Clear();

        Annex_C.JOBNO = ddlJobNo;
        Annex_C.Ename = "Get_Annex_C_Sea";
        Annex_C.BranchCode = SELECT_BRANCH;
        Annex_C.Working_Period = Working_Period;
        //ds = Annex_C.RetrieveAll_Annexure_C_Details();
        if (Connection.COMPANYID() == "2145")
        {
            localReport.ReportPath = @"Export_Annexure_C\AnnexCReport_Area.rdlc";
            ds = Annex_C.RetrieveAll_Annexure_C_Details_Area();

            ReportDataSource datasource3 = new ReportDataSource("Annexure_C_CHA_DataSet1", ds.Tables[6]);
            ReportViewer1.LocalReport.DataSources.Add(datasource3);

        }
        else
        {
            ds = Annex_C.RetrieveAll_Annexure_C_Details();
        }

        ReportDataSource datasource = new ReportDataSource("Annexure_C_Sea_DataSet1", Annex_C.Load_AnnexureC(ds.Tables[0]));
        ReportViewer1.LocalReport.DataSources.Add(datasource);

        ReportDataSource datasource1 = new ReportDataSource("AnnexC_Container_DataSet1", Annex_C.Load_AnnexureC_Container(ds.Tables[1]));
        ReportViewer1.LocalReport.DataSources.Add(datasource1);

        ReportDataSource datasource2 = new ReportDataSource("AnnexC_AR4_DataSet1", Annex_C.Load_AnnexureC_AR4(ds.Tables[2]));
        ReportViewer1.LocalReport.DataSources.Add(datasource2);

        //ReportDataSource datasource3 = new ReportDataSource("Annexure_C_CHA_DataSet1", ds.Tables[6]);
        //ReportViewer1.LocalReport.DataSources.Add(datasource3);

        ReportViewer1.LocalReport.DisplayName = "AnnexureC" + " Jobno " + ddlJobNo.ToString();

        if (ds.Tables[3].Rows.Count > 0)
        {
            sbno = ds.Tables[3].Rows[0]["SB_NO"].ToString();
            sbDate = ds.Tables[3].Rows[0]["SB_DATE"].ToString();

        }
        if (ds.Tables[4].Rows.Count > 0)
        {
            FreightCharges = ds.Tables[4].Rows[0]["MIS_FREIGHT_CHARGES"].ToString();
            FR_Currency = ds.Tables[4].Rows[0]["MIS_FREIGHT_CURRENCY"].ToString();
            Ins_Charges = ds.Tables[4].Rows[0]["MIS_INSURANCE_CHARGES"].ToString();
            Ins_Currency = ds.Tables[4].Rows[0]["MIS_INSURANCE_CURRENCY"].ToString();

        }
        string Packages = "", Packages_Type =" ";
        if (ds.Tables[5].Rows.Count > 0)
        {
            if (Connection.COMPANYID() == "1" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "525")//Freight Log
            {
                for (int i = 0; i <= ds.Tables[5].Rows.Count - 1; i++)
                {
                    Packages += ds.Tables[5].Rows[i]["ANNEX_SEA_PACK_FROM"].ToString() + "-" + ds.Tables[5].Rows[i]["ANNEX_SEA_PACK_TO"].ToString() + " " + ds.Tables[5].Rows[i]["ANNEX_SEA_PACK_PACKAGETYPE"].ToString() + " From Desc: " + ds.Tables[5].Rows[i]["ANNEX_SEA_PACK_FROMDESC"].ToString() + " To Desc: " + ds.Tables[5].Rows[i]["ANNEX_SEA_PACK_TODESC"].ToString() + "," + "\r\n";
                }
            }
            else
            {
                for (int i = 0; i <= ds.Tables[5].Rows.Count - 1; i++)
                {
                    Packages += ds.Tables[5].Rows[i]["ANNEX_SEA_PACK_FROM"].ToString() + "-" + ds.Tables[5].Rows[i]["ANNEX_SEA_PACK_TO"].ToString() + " " + ds.Tables[5].Rows[i]["ANNEX_SEA_PACK_PACKAGETYPE"].ToString() + ",";
                }
            }
            Packages_Type = ds.Tables[5].Rows[0]["ANNEX_SEA_PACK_PACKAGETYPE"].ToString();
        }


        d = DateTime.Now.Date;
        string dd = d.ToShortDateString();

        ReportParameter p1 = new ReportParameter("Date1", dd);
        ReportParameter p2 = new ReportParameter("SbNo", sbno);
        ReportParameter p3 = new ReportParameter("SBDate", sbDate);
        ReportParameter p4 = new ReportParameter("FreightCharges", FreightCharges);
        ReportParameter p5 = new ReportParameter("FR_Currency", FR_Currency);
        ReportParameter p6 = new ReportParameter("Ins_Charges", Ins_Charges);
        ReportParameter p7 = new ReportParameter("Ins_Currency", Ins_Currency);

        //ReportParameter P8 = new ReportParameter("CHA_PANNO", HttpContext.Current.Session["CHA_NO"].ToString());
        //ReportParameter P9 = new ReportParameter("CHA_NAME", HttpContext.Current.Session["CHA_NAME"].ToString());

        string CHAname = "", Sign_CHA = "", CHAname_heading = "";
        if (Connection.COMPANYID() == "785")
        {
            CHAname = "SLK LOGISTICS INDIA PVT LTD";
        }
        else if (Connection.COMPANYID() == "779")
        {
            CHAname_heading = "SAIRAM SHIPPING & LOGISTICS";
            Sign_CHA = "Authorized Signatory";
        }
        else if (Connection.COMPANYID() == "2145")
        {
            
            if (ds.Tables[6].Rows[0]["CHA_NAME"].ToString() == "" || ds.Tables[6].Rows[0]["CHA_NAME"].ToString() == null)
            {
                CHAname = ds.Tables[6].Rows[0]["EXPORTER_NAME"].ToString() + " / " + "\r\n" + Connection.Get_EXP_CHA_NAME();
            }
            else
            {
                CHAname = ds.Tables[6].Rows[0]["EXPORTER_CHA"].ToString();
            }
        }
        else
        {
            CHAname = Connection.Get_EXP_CHA_NAME();
        }
        ReportParameter P8 = new ReportParameter("CHA_PANNO", Connection.Get_EXP_CHA_NO());
        ReportParameter P9 = new ReportParameter("CHA_NAME", CHAname);

        string P_len = " ";
        if (Packages.Length>0)
        {
            P_len = Packages.Remove(Packages.Length - 1);
        }

       
        //ReportParameter P10 = new ReportParameter("Packages", Packages.Remove(Packages.Length - 1));
        //ReportParameter P11 = new ReportParameter("Pkgs", ds.Tables[5].Rows[0]["ANNEX_SEA_PACK_PACKAGETYPE"].ToString());
        
        ReportParameter P10 = new ReportParameter("Packages", P_len);
        ReportParameter P11 = new ReportParameter("Pkgs", Packages_Type);
        ReportParameter P12 = new ReportParameter("Sign_CHA", Sign_CHA);
        ReportParameter P13 = new ReportParameter("CHAname_heading", CHAname_heading);



        ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, P8, P9, P10, P11, P12, P13 };
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

    }

    private void Air_Job()
    {
        //EXP_ANNEX_C_Air_CS EXP_ANX = new EXP_ANNEX_C_Air_CS();
        DataSet ds = new DataSet();
        

        LocalReport localReport = ReportViewer1.LocalReport;
        
        localReport.ReportPath = @"Export_Annexure_C\EXP_ANNEX_C_Air.rdlc";

        List<ReportParameter> paramList = new List<ReportParameter>();
        this.ReportViewer1.LocalReport.SetParameters(paramList);
        ReportViewer1.LocalReport.DataSources.Clear();


        Annex_C.JOBNO = ddlJobNo;
        Annex_C.Ename = "Get_Annex_C_Air";
        Annex_C.BranchCode = SELECT_BRANCH;
        Annex_C.Working_Period = Working_Period;
        ds = Annex_C.RetrieveAll_Annexure_C_Details();


        ReportDataSource datasource = new ReportDataSource("EXPORT_SB_ENTRY", ds.Tables[0]);
        ReportViewer1.LocalReport.DataSources.Add(datasource);

        ReportDataSource datasource1 = new ReportDataSource("EXPORT_ANNEXURE_C_AIR", ds.Tables[1]);
        ReportViewer1.LocalReport.DataSources.Add(datasource1);

        ReportDataSource datasource3 = new ReportDataSource("EXPORT_AR4_TBL", ds.Tables[2]);
        ReportViewer1.LocalReport.DataSources.Add(datasource3);

        ReportViewer1.LocalReport.DisplayName = "AnnexureC" + " Jobno " + ddlJobNo.ToString(); 

        string Packages = " ";
        if (ds.Tables[3].Rows.Count > 0)
        {
            if (Connection.COMPANYID() == "1" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "525")//Freight Log
            {
                for (int i = 0; i <= ds.Tables[3].Rows.Count - 1; i++)
                {
                    Packages += ds.Tables[3].Rows[i]["ANNEX_SEA_PACK_FROM"].ToString() + "-" + ds.Tables[3].Rows[i]["ANNEX_SEA_PACK_TO"].ToString() + " " + ds.Tables[3].Rows[i]["ANNEX_SEA_PACK_PACKAGETYPE"].ToString() + " From Desc: " + ds.Tables[3].Rows[i]["ANNEX_SEA_PACK_FROMDESC"].ToString() + " To Desc: " + ds.Tables[3].Rows[i]["ANNEX_SEA_PACK_TODESC"].ToString() + "," + "\r\n";
                }
            }
            else
            {
                for (int i = 0; i <= ds.Tables[3].Rows.Count - 1; i++)
                {
                    Packages += ds.Tables[3].Rows[i]["ANNEX_SEA_PACK_FROM"].ToString() + "-" + ds.Tables[3].Rows[i]["ANNEX_SEA_PACK_TO"].ToString() + " " + ds.Tables[3].Rows[i]["ANNEX_SEA_PACK_PACKAGETYPE"].ToString() + ",";
                }
            }
        }
        string Rotation_no = "";
         if (ds.Tables[1].Rows.Count > 0)
         {
             Rotation_no = ds.Tables[1].Rows[0]["ANNEX_AIR_ROTATION_NO"].ToString();
         }

         string CHAname = " ";
         if (Connection.COMPANYID() == "785")
         {
             CHAname = "SLK LOGISTICS INDIA PVT LTD";
         }
         else if (Connection.COMPANYID() == "779")
         {
             CHAname = "SAIRAM SHIPPING & LOGISTICS";
         }
         else
         {
             CHAname = Connection.Get_EXP_CHA_NAME();
         }

        ReportParameter p1 = new ReportParameter("CHA_PANNO", Connection.Get_EXP_CHA_NO());
        ReportParameter p2 = new ReportParameter("CHA_NAME", CHAname);
        ReportParameter p3 = new ReportParameter("Packages", Packages.Remove(Packages.Length - 1));
        ReportParameter p4 = new ReportParameter("RotationNo", Rotation_no);

        ReportParameter[] p = { p1, p2, p3, p4 };
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
        //--------------------------------------To Print
    
    }
}