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


public partial class Purchase_Multi_Head_rpt : System.Web.UI.Page
{
    AppSession aps = new AppSession();

    //GST_Imp_Invoice BI = new GST_Imp_Invoice();//FUTURE NOT REQUIRED
    Account_Statement AS = new Account_Statement();
    Billing_UserBO ObjUBO = new Billing_UserBO();
    string GSTR1_OFFLINE = string.Empty;
    string Company_Lic = string.Empty;

    


    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();
      
        if (!IsPostBack)
        {
            Company_Lic = Connection.Company_License().ToLower();
            if (Session["Click_Y_N"].ToString() == "Y")
            {
                Load_Grid();
            }
            else
            {
                Session["Click_Y_N"] = "N";
            }
        }
    }
    private void Load_Grid()
    {
        DataSet ds1 = new DataSet();

        ObjUBO.Flag = Request["Rpt_type"].ToString();                               //Report Name
        ObjUBO.from_date = Request["From_date"].ToString();
        ObjUBO.todate = Request["todate"].ToString();

        ObjUBO.Imp_Exp = Request["Imp_Exp"].ToString();
        ObjUBO.MODE = Request["Trans_Mode"].ToString();                             //AIR SEA LAND
        ObjUBO.Local_Other = Request["Local_Other"].ToString();                     //LOCAL OR OTHER STATE
        ObjUBO.SEZ_Area = Request["SEZ_Area"].ToString();                           //Regular or SEZ 
        ObjUBO.BASED_ON = Request["BASED_ON"].ToString();                           //Order by Purpose or Report Name with Additional Conditions

        ObjUBO.CustomerName = Request["CustomerName"].ToString().Replace('_', '&'); //Bill to Party or Vendor
        ObjUBO.Branch_No_Loc = Request["Location"].ToString();

        ObjUBO.CHARGE_NAME = Request["Charge_Name"].ToString();
        ObjUBO.Tax_Mode = Request["Tax_type"].ToString();

        string CompanyName = HttpContext.Current.Session["Client_Name"].ToString();

        if (Request["Rpt_type"].ToString() == "GSTR1 Offline")
        {

            ObjUBO.Sp_Name = "ACC_RPT_SALES_GSTR_I_OFFLINE";
            ds1 = AS.ACC_SELECT_SALES_MULTI_HEAD_RPT(ObjUBO);
            LocalReport localReport = ReportViewer1.LocalReport;
            localReport.ReportPath = @"Accounts_Rpt/ACC_RPT_SALES_GSTR_I_OFFLINE.rdlc";

            ReportViewer1.LocalReport.EnableExternalImages = true;

            List<ReportParameter> paramList = new List<ReportParameter>();
            this.ReportViewer1.LocalReport.SetParameters(paramList);
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource datasource = new ReportDataSource("DataSet1", ds1.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            ReportDataSource datasource1 = new ReportDataSource("DataSet2", ds1.Tables[1]);
            ReportViewer1.LocalReport.DataSources.Add(datasource1);


            ReportViewer1.LocalReport.DisplayName = "GSTR1_RPT";

            ReportParameter p1 = new ReportParameter("Service", Request["CustomerName"].ToString() == "" ? "All" : Request["CustomerName"].ToString());
            ReportParameter p2 = new ReportParameter("From_date", Request["From_date"].ToString());
            ReportParameter p3 = new ReportParameter("Todate", Request["todate"].ToString());
            ReportParameter p4 = new ReportParameter("Tax_NonTax", Request["Tax_type"].ToString() == "" ? "All" : Request["Tax_type"].ToString());
            ReportParameter p5 = new ReportParameter("E_Comm", Connection.COMPANYID() == "2" ? "" : "NIL");

            ReportParameter[] p = { p1, p2, p3, p4, p5 };
            ReportViewer1.LocalReport.SetParameters(p);
            Report_Print();
        }

        else if (Request["Rpt_type"].ToString() == "Purchase Summary")
        {
            //ObjUBO.Sp_Name = "ACC_RPT_SALES_SALES_SUMMARY_CREDIT_SUMMARY";
            ObjUBO.Sp_Name = "ACC_RPT_PURCHASE_PURCHASE_SUMMARY_DEBIT_SUMMARY";
            ds1 = AS.ACC_SELECT_SALES_MULTI_HEAD_RPT(ObjUBO);
            LocalReport localReport = ReportViewer1.LocalReport;
            localReport.ReportPath = @"Accounts_Rpt/ACC_RPT_PURCHASE_PURCHASE_SUMMARY_DEBIT_SUMMARY.rdlc";

            ReportViewer1.LocalReport.EnableExternalImages = true;

            List<ReportParameter> paramList = new List<ReportParameter>();
            this.ReportViewer1.LocalReport.SetParameters(paramList);
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource datasource = new ReportDataSource("DataSet1", ds1.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportDataSource datasource1 = new ReportDataSource("DataSet2", ds1.Tables[1]);
            ReportViewer1.LocalReport.DataSources.Add(datasource1);
            ReportViewer1.LocalReport.DisplayName = "SALES SUMMARY WITH CREDIT SUMMARY";

            ReportParameter p1 = new ReportParameter("Service", Request["CustomerName"].ToString() == "" ? "All" : Request["CustomerName"].ToString());
            ReportParameter p2 = new ReportParameter("From_date", Request["From_date"].ToString());
            ReportParameter p3 = new ReportParameter("Todate", Request["todate"].ToString());
            ReportParameter p4 = new ReportParameter("Tax_NonTax", Request["Tax_type"].ToString() == "" ? "All" : Request["Tax_type"].ToString());
            //ReportParameter p5 = new ReportParameter("E_Comm", Connection.COMPANYID() == "2" ? "" : "NIL");

            ReportParameter[] p = { p1, p2, p3, p4 };
            ReportViewer1.LocalReport.SetParameters(p);
            Report_Print();
        }
        else if (Request["Rpt_type"].ToString() == "Sales Ledger")
        {
            ObjUBO.Sp_Name = "ACC_RPT_SALES_SALES_LEDGER_CREDIT_LEDGER";
            ds1 = AS.ACC_SELECT_SALES_MULTI_HEAD_RPT(ObjUBO);
            LocalReport localReport = ReportViewer1.LocalReport;
            localReport.ReportPath = @"Accounts_Rpt/ACC_RPT_SALES_SALES_LEDGER_CREDIT_LEDGER.rdlc";

            ReportViewer1.LocalReport.EnableExternalImages = true;

            List<ReportParameter> paramList = new List<ReportParameter>();
            this.ReportViewer1.LocalReport.SetParameters(paramList);
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource datasource = new ReportDataSource("DataSet1", ds1.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportDataSource datasource1 = new ReportDataSource("DataSet2", ds1.Tables[1]);
            ReportViewer1.LocalReport.DataSources.Add(datasource1);
            ReportViewer1.LocalReport.DisplayName = "SALES LEDGER WITH CREDIT LEDGER";

            ReportParameter p1 = new ReportParameter("Service", Request["CustomerName"].ToString() == "" ? "All" : Request["CustomerName"].ToString());
            ReportParameter p2 = new ReportParameter("From_date", Request["From_date"].ToString());
            ReportParameter p3 = new ReportParameter("Todate", Request["todate"].ToString());
            ReportParameter p4 = new ReportParameter("Tax_NonTax", Request["Tax_type"].ToString() == "" ? "All" : Request["Tax_type"].ToString());
            ReportParameter p5 = new ReportParameter("Charge_Name", Request["Charge_Name"].ToString() == "" ? "All" : Request["Charge_Name"].ToString());

            ReportParameter[] p = { p1, p2, p3, p4, p5 };
            ReportViewer1.LocalReport.SetParameters(p);
            Report_Print();
        }
        else if (Request["Rpt_type"].ToString() == "Sales Outstanding")
        {
            ObjUBO.Sp_Name = "ACC_RPT_SALES_SALES_OUTSTANDING";
            ds1 = AS.ACC_SELECT_SALES_MULTI_HEAD_RPT(ObjUBO);
            LocalReport localReport = ReportViewer1.LocalReport;
            localReport.ReportPath = @"Accounts_Rpt/ACC_RPT_SALES_SALES_OUTSTANDING.rdlc";

            ReportViewer1.LocalReport.EnableExternalImages = true;

            List<ReportParameter> paramList = new List<ReportParameter>();
            this.ReportViewer1.LocalReport.SetParameters(paramList);
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource datasource = new ReportDataSource("DataSet1", ds1.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportDataSource datasource1 = new ReportDataSource("DataSet2", ds1.Tables[1]);
            ReportViewer1.LocalReport.DataSources.Add(datasource1);
            ReportViewer1.LocalReport.DisplayName = "SALES LEDGER WITH CREDIT LEDGER";

            ReportParameter p1 = new ReportParameter("Service", Request["CustomerName"].ToString() == "" ? "All" : Request["CustomerName"].ToString());
            ReportParameter p2 = new ReportParameter("From_date", Request["From_date"].ToString());
            ReportParameter p3 = new ReportParameter("Todate", Request["todate"].ToString());
            ReportParameter p4 = new ReportParameter("Tax_NonTax", Request["Tax_type"].ToString() == "" ? "All" : Request["Tax_type"].ToString());
            ReportParameter p5 = new ReportParameter("Charge_Name", Request["Charge_Name"].ToString() == "" ? "All" : Request["Charge_Name"].ToString());

            ReportParameter[] p = { p1, p2, p3, p4, p5 };
            ReportViewer1.LocalReport.SetParameters(p);
            Report_Print();
        }
        else
        {
            Session.Remove("report_Excel");
        }
        Session["Click_Y_N"] = "";
    }

    private void Report_Print()
    {
        Warning[] warnings;
        string[] streamIds;
        string mimeType = string.Empty, encoding = string.Empty, extension = string.Empty;

        byte[] bytes = ReportViewer1.LocalReport.Render("pdf", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
        byte[] bytes_2 = ReportViewer1.LocalReport.Render("Excel", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

        Session.Remove("report");
        Session.Remove("report_Excel");
        Session["report_Excel"] = bytes_2;
           //--------------------------------------To Print------------------------------------------------------------------------------------//
        ReportViewer1.Visible = true; 
    }

    protected void btnexcel_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["Click_Y_N"].ToString() != "N")
        {
            byte[] bytes = (byte[])Session["report_Excel"];
            Response.ClearHeaders();
            Response.Clear();

            Response.ContentType = "application/xls";
            Response.AddHeader("content-disposition", "attachment;filename=" + Request["Rpt_type"].ToString() + ".xls");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(bytes);
            Response.End();
        }
    }
}