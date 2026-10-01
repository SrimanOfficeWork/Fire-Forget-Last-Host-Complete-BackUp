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

public partial class Exp_Job_Clearance_rpt : System.Web.UI.Page
{
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;

    ErrorLogs er = new ErrorLogs();
    AppSession aps = new AppSession();

    EXP_Job_Clearance EJC = new EXP_Job_Clearance();


    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = HttpContext.Current.Session["currentcomp_db"].ToString();
        Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();
        SELECT_BRANCH = Connection.Get_Company_Type();
        if (!IsPostBack)
        {
            Load_Job_No();
        }
    }

    private void Load_Job_No()
    {
        DataSet dss = new DataSet();
        EJC.Jobno = "";
        EJC.Branch_Common = SELECT_BRANCH;
        EJC.Flag = "Select_Exp_Jobno";
        dss = EJC.EXP_Job_Clearance_select();
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
        string vesselName = "  ";

        if (ddlJob_No.SelectedItem.Text != "")
        {
          DateTime time = DateTime.Now;
          String s = time.ToString("yyyyMMddHHmm");
          DataSet ds = new DataSet();
          LocalReport localReport = ReportViewer1.LocalReport;
          EJC.Jobno = ddlJob_No.SelectedValue.ToString();
          EJC.Branch_Common = SELECT_BRANCH;
          EJC.Flag = "Select_XL_PDF";
          ds = EJC.EXP_Job_Clearance_select();

          localReport.ReportPath = @"ParaMount/Exp_Job_Clearance_rpt.rdlc";
           
            ReportViewer1.LocalReport.EnableExternalImages = true;
            List<ReportParameter> paramList = new List<ReportParameter>();
            this.ReportViewer1.LocalReport.SetParameters(paramList);
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource datasource = new ReportDataSource("EXP_Tracking", ds.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            ReportDataSource datasource1 = new ReportDataSource("Tracking_History", ds.Tables[1]);
            ReportViewer1.LocalReport.DataSources.Add(datasource1);
            
            ReportViewer1.LocalReport.DisplayName = "Export_Job_Status _ "+s;

            int count = ds.Tables[1].Rows.Count;

            if (count == 46)
            {
                ds.Tables[1].Rows.Add("Vessel Name");
            }
            if (count > 45)
            {
                vesselName = ds.Tables[1].Rows[46]["PARTICULAR"].ToString();
            }
            

            ReportParameter p1 = new ReportParameter("VesselName", vesselName);

            ReportParameter[] p = { p1 };
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