using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
//using System.Diagnostics;
using System.Data.SqlClient;
using System.IO;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using System.Configuration;
using System.Web;
using Microsoft.Reporting.WebForms;

public partial class Import_License_Balance_Report_Rpt_viewer : System.Web.UI.Page
{
  
    AppSession aps = new AppSession();
    eroyalmaster erm = new eroyalmaster();

    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();

    public string currentuser, ddlJobNo;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate,testaddress;
    public string SELECT_TYPE, SELECT_BRANCH, Logo;
   
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
                erm.LICENSE_NO = Request.QueryString["jobno"].ToString();
                erm.LICENSE_DATE = "";
                erm.PORT_OF_LICENSE = "";
                erm.EWorking_Period = SELECT_BRANCH;
                erm.LICENSE_ITEM_NO = Request.QueryString["itemno"].ToString();
                erm.SCHEME_CODE = Request.QueryString["Schemecode"].ToString();
                erm.Ename = "select_License_Details";
                ds1 = erm.RetrieveAll_IMPORT_LICENSE_BALANCE_REPORT();

                LocalReport localReport = ReportViewer1.LocalReport;

                if (Connection.COMPANYID() == "188" || Connection.COMPANYID() == "653")
                {
                    localReport.ReportPath = @"BAS_Shipping/Import_License_Balance_Report_KSQUARE.rdlc";
                }
                else
                {
                    localReport.ReportPath = @"BAS_Shipping/Import_License_Balance_Report.rdlc";
                }

                Logo = new Uri(Server.MapPath("~/images/Company_Logo/KSQUARE_CHENNAI.JPG")).AbsoluteUri;

                ReportViewer1.LocalReport.EnableExternalImages = true;
               
                List<ReportParameter> paramList = new List<ReportParameter>(); this.ReportViewer1.LocalReport.SetParameters(paramList);
                ReportViewer1.LocalReport.DataSources.Clear();

                ReportDataSource dataSS = new ReportDataSource("License_Debit_Report", ds1.Tables[0]);
                ReportViewer1.LocalReport.DataSources.Add(dataSS);

                ReportDataSource data = new ReportDataSource("License_Job_Debit", ds1.Tables[1]);
                ReportViewer1.LocalReport.DataSources.Add(data);

                ReportParameter TOTAL_DEBIT_AMT1 = new ReportParameter("TOTAL_DEBIT_AMT", ds1.Tables[0].Rows[0]["TOTAL_DEBIT_AMT"].ToString());
                ReportParameter TOTAL_CIF_VALUE1 = new ReportParameter("TOTAL_CIF_VALUE", ds1.Tables[0].Rows[0]["TOTAL_CIF_VALUE"].ToString());
                ReportParameter TOTAL_DEBIT_QTY1 = new ReportParameter("TOTAL_DEBIT_QTY", ds1.Tables[0].Rows[0]["TOTAL_DEBIT_QTY"].ToString());


                ReportParameter Tot_dbt_Duty1 = new ReportParameter("Tot_dbt_Duty", ds1.Tables[2].Rows[0]["Tot_dbt_Duty"].ToString());
                ReportParameter Tot_dbt_CIF1 = new ReportParameter("Tot_dbt_CIF", ds1.Tables[2].Rows[0]["Tot_dbt_CIF"].ToString());
                ReportParameter Tot_dbt_QTY1 = new ReportParameter("Tot_dbt_QTY", ds1.Tables[2].Rows[0]["Tot_dbt_QTY"].ToString());

                ReportParameter Final_dbt_amt1 = new ReportParameter("Final_dbt_amt", ds1.Tables[3].Rows[0]["Final_dbt_amt"].ToString());
                ReportParameter Avail_Lic_CIF1 = new ReportParameter("Avail_Lic_CIF", ds1.Tables[3].Rows[0]["Avail_Lic_CIF"].ToString());
                ReportParameter Avail_Lic_QTY1 = new ReportParameter("Avail_Lic_QTY", ds1.Tables[3].Rows[0]["Avail_Lic_QTY"].ToString());
                ReportParameter Logo1 = new ReportParameter("Logo", Logo);

                string Imp_name = "", NotnNo = "";
                if (ds1.Tables[4].Rows.Count > 0)
                {
                    //Imp_name=ds1.Tables[4].Rows[0]["IMPORTER_NAME"].ToString();//17-11-2021
                    Imp_name = HttpContext.Current.Session["IMPORTER_NAME"].ToString();
                    NotnNo=ds1.Tables[4].Rows[0]["SCHEME_NOTN"].ToString();

                }
                ReportParameter param = new ReportParameter("Name", Imp_name);
                ReportParameter param1 = new ReportParameter("NotnNo", NotnNo);
                ReportParameter param2 = new ReportParameter("CHA_NAME", HttpContext.Current.Session["CHA_NAME"].ToString());

                ReportParameter[] p = { param, param1, param2, Tot_dbt_Duty1, Tot_dbt_CIF1, Tot_dbt_QTY1, Final_dbt_amt1, Avail_Lic_CIF1, Avail_Lic_QTY1, TOTAL_DEBIT_AMT1, TOTAL_CIF_VALUE1, TOTAL_DEBIT_QTY1, Logo1 };           
                ReportViewer1.LocalReport.SetParameters(p);


                ////--------------------------------------To Print------------------------------------------------------------------------------------//
                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;
                string fileName = "a";
                byte[] bytes = ReportViewer1.LocalReport.Render("pdf", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                Session.Remove("report");
                Session["report"] = bytes;
                ////--------------------------------------To Print------------------------------------------------------------------------------------//

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




