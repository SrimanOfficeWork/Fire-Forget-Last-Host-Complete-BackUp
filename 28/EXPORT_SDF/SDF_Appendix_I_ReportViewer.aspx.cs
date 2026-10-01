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

using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Web.UI.WebControls.WebParts;

using System.IO;
using Microsoft.ApplicationBlocks.Data;
using System.ComponentModel;
using System.Drawing.Printing;

using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Data.SqlClient;

public partial class EXPORT_SDF_SDF_Appendix_I_ReportViewer : System.Web.UI.Page
{
    public string currentuser, ddlJobNo;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period, working_period;
    public string LoginDate, testaddress;
    public string SELECT_TYPE, SELECT_BRANCH;
    string SelectSDF_TYPE;

    AppSession aps = new AppSession();
    SDF_FORMAT sdf = new SDF_FORMAT();
    DataSet ds = new DataSet();


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

                SelectSDF_TYPE = Session["SDF_TYPE"].ToString();

                LocalReport localReport = ReportViewer1.LocalReport;

                switch (SelectSDF_TYPE)
                {
                    case ("APPENDIX_I"):
                        localReport.ReportPath = @"EXPORT_SDF\SDF_APPENDIX_I_Report.rdlc";
                        break;
                    case ("APPENDIX_2"):
                        localReport.ReportPath = @"EXPORT_SDF\SDF_APPENDIX_2_Report.rdlc";
                        break;
                    case ("APPENDIX_3"):
                        localReport.ReportPath = @"EXPORT_SDF\SDF_APPENDIX_3_Report.rdlc";
                        Item_Details();
                        break;
                    case ("APPENDIX_4"):
                        localReport.ReportPath = @"EXPORT_SDF\SDF_APPENDIX_4_Report.rdlc";
                        break;
                    case ("APPENDIX_5"):
                        localReport.ReportPath = @"EXPORT_SDF\SDF_APPENDIX_5_Report.rdlc";
                        break;
                    case ("APPENDIX_6"):
                        localReport.ReportPath = @"EXPORT_SDF\SDF_APPENDIX_6_Report.rdlc";
                        break;
                    case ("APPENDIX_7"):
                        localReport.ReportPath = @"EXPORT_SDF\SDF_APPENDIX_7_Report.rdlc";
                        break;
                    case ("APPENDIX_8"):
                        localReport.ReportPath = @"EXPORT_SDF\SDF_APPENDIX_8_Report.rdlc";
                        break;
                    case ("APPENDIX_9"):
                        localReport.ReportPath = @"EXPORT_SDF\SDF_APPENDIX_9_Report.rdlc";
                        break;
                    case ("APPENDIX_10"):
                        localReport.ReportPath = @"EXPORT_SDF\SDF_APPENDIX_10_Report.rdlc";
                        break;
                    case ("APPENDIX_11"):
                        localReport.ReportPath = @"EXPORT_SDF\SDF_APPENDIX_11_Report.rdlc";
                        break;
                    case ("APPENDIX_12"):
                        localReport.ReportPath = @"EXPORT_SDF\SDF_APPENDIX_12_Report.rdlc";
                        break;
                    case ("APPENDIX_Export"):
                        localReport.ReportPath = @"EXPORT_SDF\Export_Value_Declaration_Report.rdlc";
                        break;

                    case ("ExportAnnexure1"):
                        //if (Connection.COMPANYID() == "477" || Connection.COMPANYID() == "10")
                        //{
                        //    localReport.ReportPath = @"EXPORT_SDF\ExpAnnexure1_Report_ATCL.rdlc";
                        //}
                        //else
                        //{
                            localReport.ReportPath = @"EXPORT_SDF\ExpAnnexure1_Report.rdlc";
                        //}
                        break;

                    case ("ExportDocket"):
                        localReport.ReportPath = @"EXPORT_SDF\ExportDocket_Report.rdlc";
                        break;

                }


                //localReport.ReportPath = @"EXPORT_SDF\SDF_APPENDIX_I_Report.rdlc";

                List<ReportParameter> paramList1 = new List<ReportParameter>();
                this.ReportViewer1.LocalReport.SetParameters(paramList1);
                ReportViewer1.LocalReport.DataSources.Clear();

                sdf.SDF_JOBNO = ddlJobNo;
                sdf.SDF_TYPE = SelectSDF_TYPE;

                sdf.SDF_BRANCHCODE = currentbranch;
                
                ReportDataSource datasource = new ReportDataSource();
                if (SelectSDF_TYPE == "ExportAnnexure1")
                {
                    sdf.Ename = "Get_AnnexData";
                    sdf.SDF_BRANCH_COMMON = currentbranch;
                    ds = sdf.Export_annexure();
                    datasource = new ReportDataSource("SDF_DataSet", sdf.Load_ExportAnnx1(ds.Tables[0]));

                }
                else if (SelectSDF_TYPE == "ExportDocket")
                {
                    sdf.Ename = "Get_ExpDocketData";
                    sdf.SDF_BRANCH_COMMON = currentbranch;
                    ds = sdf.Export_Docket();                 
                    datasource = new ReportDataSource("SDF_DataSet", sdf.Load_ExportDocket(ds.Tables[0]));

                }
                else               
                {
                    sdf.Ename = "Get_SDF";
                    ds = sdf.Retrive_SDF_Appendix();
                    datasource = new ReportDataSource("SDF_DataSet", sdf.Load_SDF_Appendix(ds.Tables[0]));                    
                }

                if (Session["SDF_TYPE"].ToString() == "APPENDIX_3")
                {
                    string r_slno = "", r_Invoice_slNo = "", r_PMV_Value = "";
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        for (int i = 0; i <= ds.Tables[1].Rows.Count-1; i++)
                        {
                            r_slno += ds.Tables[1].Rows[i]["SLNO"].ToString() + Environment.NewLine;
                            r_Invoice_slNo += ds.Tables[1].Rows[i]["INVOICE_SLNO"].ToString() + Environment.NewLine;
                            r_PMV_Value += ds.Tables[1].Rows[i]["PMV_VALUE"].ToString() + Environment.NewLine;

                        }
                    }
                   
                    ReportParameter slno = new ReportParameter("SL_NO", r_slno);
                    ReportParameter Invoice_slNo = new ReportParameter("INVOICE_SLNO", r_Invoice_slNo);
                    ReportParameter PMV_Value = new ReportParameter("PMV_VALUE", r_PMV_Value);

                    ReportParameter[] p = { slno, Invoice_slNo, PMV_Value };
                    ReportViewer1.LocalReport.SetParameters(p);
                }

                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);
                List<ReportParameter> paramList = new List<ReportParameter>(); this.ReportViewer1.LocalReport.SetParameters(paramList);
      
                //Load_SDF_Details();
                              
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

    public void Load_SDF_Details()
    {
        ReportDataSource dataSS = new ReportDataSource("SDF_DataSet", sdf.Load_SDF_Appendix(ds.Tables[0]));
        ReportViewer1.LocalReport.DataSources.Add(dataSS);
    }

    public void Item_Details()
    {
        ReportViewer1.LocalReport.SubreportProcessing += new Microsoft.Reporting.WebForms.SubreportProcessingEventHandler(ReportViewer1_SubreportProcessing);
    }

    protected void ReportViewer1_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
    {
        ReportDataSource dataSource = new ReportDataSource("SDF_DataSet", sdf.Load_SDF_Appendix(ds.Tables[0]));
        e.DataSources.Add(dataSource);

    }
}