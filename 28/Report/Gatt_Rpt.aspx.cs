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

public partial class Report_Gatt_Rpt : System.Web.UI.Page
{
    string ddlJobNo = string.Empty, TYPE = string.Empty;

    AppSession aps = new AppSession();
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();

        if (!IsPostBack)
        {
            Page_loaItem_Details();
        }
    }

    private void Page_loaItem_Details()
    {
        LocalReport localReport = ReportViewer1.LocalReport;
        DataSet dss = new DataSet();
        Gatt_CS GT = new Gatt_CS();

        ddlJobNo = Request.QueryString["jobno"].ToString();
        TYPE = Request.QueryString["Type"].ToString();

        GT.Jobno = ddlJobNo;
        GT.Ename = "Select_GATT";
        GT.WORKING_PERIOD = Connection.Get_Company_Type();
        dss = GT.Exists_Gatt();

        if (TYPE == "Print")
        {
            localReport.ReportPath = @"Report/Imp_Gatt.rdlc";
        }
        else
        {
            localReport.ReportPath = @"Report/Imp_Gatt_PrePrint.rdlc";
        }

        List<ReportParameter> paramList = new List<ReportParameter>();
        this.ReportViewer1.LocalReport.SetParameters(paramList);
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportDataSource datasource = new ReportDataSource("DataSet1", dss.Tables[1]);
        ReportViewer1.LocalReport.DataSources.Add(datasource);

        ReportViewer1.LocalReport.DisplayName = "GATTDEC";

        ReportParameter param = new ReportParameter("Jobno", ddlJobNo);
        ReportParameter[] p = { param };
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
}