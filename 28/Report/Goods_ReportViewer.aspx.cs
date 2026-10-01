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
//using ReportViewerLib;
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

    Export_CheckList CHKLIST = new Export_CheckList();
    Date_Time dt = new Date_Time();
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
    public string currentuser, ddlJobNo, jobno_ps;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string SELECT_TYPE, SELECT_BRANCH;
    public string LoginDate, customhouse,transportmode;
    AppSession aps = new AppSession();
    public int Is_STR = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = HttpContext.Current.Session["currentcomp_db"].ToString();
        Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();
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
            try
            {
                if (Request.QueryString["jobno"] == "" || Request.QueryString["jobno"] == null && Request.QueryString["customhouse"] == "" || Request.QueryString["customhouse"] == null && Request.QueryString["transportmode"] == "" || Request.QueryString["transportmode"] == null)
                {

                }
                else
                {
                    if (Request.QueryString["jobno_ps"] == "" || Request.QueryString["jobno_ps"] == null)
                    {
                        jobno_ps=" ";
                    }
                    else
                    {
                        jobno_ps = Request.QueryString["jobno_ps"].ToString();
                    }
                    ddlJobNo = Request.QueryString["jobno"].ToString();
                    customhouse = Request.QueryString["customhouse"].ToString();
                    transportmode = Request.QueryString["transportmode"].ToString();




                    //currentuser = Session["currentuser"].ToString();
                    //currentbranch = Session["currentbranch"].ToString();
                    //currentcomp_name = Session["currentcomp_name"].ToString();
                    //comp_ConnectionStr = HttpContext.Current.Session["currentcomp_db"].ToString();
                    //Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();
                    //LoginDate = HttpContext.Current.Session["LoginDate"].ToString();

                    List<ReportParameter> paramList = new List<ReportParameter>(); this.ReportViewer1.LocalReport.SetParameters(paramList);

                    ReportViewer1.LocalReport.DataSources.Clear();
                    

                    

                    ds = (DataSet)HttpContext.Current.Session["EXPORT_GOODS_REG_CHECKLIST"];
                    GetGeneral();
                   

                    Invoice_Details();
                    Sea_Container_Details();
                    Package_Details();
                    EOU_Details();
                    AR4_Details();
                    Goods_Reg_Docs_Details();
                    Container_Package_Details();
                    


                    ReportParameter param = new ReportParameter("Title", Session["currentcomp_name"].ToString());
                    ReportParameter param1 = new ReportParameter("SubTitle", "GOODS REGISTRATION DECLARATION");
                    //ReportParameter param2= new ReportParameter("CustomHouse", currentbranch + "," + CUSTOMS_HOUSE + "]");
                    ReportParameter param3 = new ReportParameter("PrintDate", dt.Today_Date());
                    ReportParameter param4 = new ReportParameter("TodayDate", dt.Today_Date());
                    ReportParameter param5 = new ReportParameter("Jobno", ddlJobNo);
                    ReportParameter param6 = new ReportParameter("Username", currentuser);
                    ReportParameter param7 = new ReportParameter("Jobnops", jobno_ps);

                    ReportParameter[] p = { param, param1, param3, param4, param5, param6, param7 };
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
    }
    
    public void GetGeneral()
    {
        Rpt_Goods_Reg_General Rpt_Export_Goods_Reg_General = new Rpt_Goods_Reg_General();
        //ReportDataSource dataSource1 = new ReportDataSource("EXPORT_GOODS_REGISTRATION", Rpt_Export_Goods_Reg_General.Export_Goods_Reg_General(ddlJobNo, customhouse, transportmode));
        ReportDataSource dataSource1 = new ReportDataSource("EXPORT_GOODS_REGISTRATION", Rpt_Export_Goods_Reg_General.Export_Goods_Reg_General(ds.Tables[0], customhouse, transportmode));
        ReportViewer1.LocalReport.DataSources.Add(dataSource1);
    }

    public void Invoice_Details()
    {
        Rpt_Goods_Reg_Invoice INV = new Rpt_Goods_Reg_Invoice();
        
        ReportDataSource dataSource = new ReportDataSource("EXPORT_GOODS_REGISTRATION_INVOICE", INV.Export_Goods_Reg_Invoice(ds.Tables[1]));
        ReportViewer1.LocalReport.DataSources.Add(dataSource);
    }

    public void Sea_Container_Details()
    {
        Rpt_Goods_Reg_Sea_Container Sea_Container = new Rpt_Goods_Reg_Sea_Container();
        ReportDataSource dataSource = new ReportDataSource("EXPORT_GOODS_REGISTRATION_SEA_CONTAINER", Sea_Container.Export_Goods_Reg_Sea_Container(ds.Tables[2]));

        ReportViewer1.LocalReport.DataSources.Add(dataSource);       
    }


    public void Package_Details()
    {
        Rpt_Goods_Reg_Package PACK = new Rpt_Goods_Reg_Package();
           ReportDataSource dataSource = new ReportDataSource("EXPORT_GOODS_REGISTRATION_PACKAGE", PACK.Export_Goods_Reg_Package(ds.Tables[3]));

        ReportViewer1.LocalReport.DataSources.Add(dataSource);       
    }
    public void EOU_Details()
    {
        Rpt_Goods_Reg_EOU EOU = new Rpt_Goods_Reg_EOU();
        ReportDataSource dataSource = new ReportDataSource("EXPORT_GOODS_REGISTRATION_EOU", EOU.Export_Goods_Reg_EOU(ds.Tables[4]));

        ReportViewer1.LocalReport.DataSources.Add(dataSource);

    }
    public void AR4_Details()
    {
        Rpt_Goods_Reg_AR4 AR4 = new Rpt_Goods_Reg_AR4();
        ReportDataSource dataSource = new ReportDataSource("EXPORT_GOODS_REGISTRATION_AR4", AR4.Export_Goods_Reg_AR4(ds.Tables[5]));

        ReportViewer1.LocalReport.DataSources.Add(dataSource);
    }

    public void Goods_Reg_Docs_Details()
    {
        Rpt_Goods_Reg_Docs Docs = new Rpt_Goods_Reg_Docs();
        ReportDataSource dataSource = new ReportDataSource("DataSet1", Docs.Rpt_Goods_Reg_Doc_Details(ds.Tables[6]));

        ReportViewer1.LocalReport.DataSources.Add(dataSource);
    }

    public void Container_Package_Details()
    {
        Rpt_Goods_Reg_Container_Package Cont_pkgs = new Rpt_Goods_Reg_Container_Package();
        ReportDataSource dataSource = new ReportDataSource("DataSet2", Cont_pkgs.Rpt_Goods_Reg_Container_Pckg(ds.Tables[7]));

        ReportViewer1.LocalReport.DataSources.Add(dataSource);
    }


   




   
}