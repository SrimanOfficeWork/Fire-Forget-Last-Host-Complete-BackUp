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

public partial class Imp_Job_Clearance_rpt : System.Web.UI.Page
{
    AppSession aps = new AppSession();
    IMP_Job_Clearance IJC = new IMP_Job_Clearance();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();
        
        if (!IsPostBack)
        {
            Load_Job_No();
        }
    }

    private void Load_Job_No()
    {
        DataSet dss = new DataSet();
        IJC.Jobno = "";
        IJC.Flag = "Select_Imp_Jobno";
        dss = IJC.IMP_Job_Clearance_select();
        if (dss.Tables[0].Rows.Count > 0)
        {
            ddlJob_No.DataSource = dss.Tables[0];
            ddlJob_No.DataTextField = "JOBNO_PS";
            ddlJob_No.DataValueField = "JOBNO";
            ddlJob_No.DataBind();
            ddlJob_No.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlJob_No.SelectedIndex = 0;

            if (Request.QueryString["Jobno"] == "" || Request.QueryString["Jobno"] == null)
            {

            }
            else
            {
                ddlJob_No.SelectedValue = Request.QueryString["Jobno"].ToString();
                load_data();
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
          DateTime time = DateTime.Now;
          String s = time.ToString("yyyyMMddHHmm");
          DataSet ds = new DataSet();
          LocalReport localReport = ReportViewer1.LocalReport;
          IJC.Jobno = ddlJob_No.SelectedValue.ToString();
          IJC.Flag = "Select_XL_PDF";
          ds = IJC.IMP_Job_Clearance_select();

          localReport.ReportPath = @"ParaMount/Imp_Job_Clearance_rpt.rdlc";
           
            ReportViewer1.LocalReport.EnableExternalImages = true;
            List<ReportParameter> paramList = new List<ReportParameter>();
            this.ReportViewer1.LocalReport.SetParameters(paramList);
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource datasource = new ReportDataSource("IMP_Tracking", ds.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            ReportDataSource datasource1 = new ReportDataSource("Tracking_History", ds.Tables[1]);
            ReportViewer1.LocalReport.DataSources.Add(datasource1);
            
            ReportViewer1.LocalReport.DisplayName = "Import_Job_Status _ "+s;

            ReportParameter param;
            if (Connection.COMPANYID() == "293")
            {
                param = new ReportParameter("ClientName", "Paramount Shipping Services Pvt. Ltd.");
            }
            else
            {
                 param = new ReportParameter("ClientName", HttpContext.Current.Session["CHA_NAME"].ToString());
            }
            ReportParameter[] p = { param};
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
            ReportViewer1.Visible = true;
        }
    }
  
    
}