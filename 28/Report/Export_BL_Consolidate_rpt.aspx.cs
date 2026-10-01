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


using System.Collections;


public partial class Report_Export_BL_Consolidate_rpt :ThemeClass
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
    DataSet ds = new DataSet();
    DataSet dss = new DataSet();

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
            //Page_loaItem_Details();
            ReportViewer1.Visible = false;
            txtrptname.Style.Add("background-color", "#F0F0F0");
            txtrptname.Attributes.Add("readonly", "readonly");
            txtrptname.Text = string.Empty;
        }
        
    }

    protected void btnaddanx_Click(object sender, EventArgs e)
    {
        Multiple_BL_Add_Annexure_Report_Data();
    }

    protected void btnMBL_Click(object sender, EventArgs e)
    {
        Multiple_BL_Report_Data();
    }
    public void Multiple_BL_Report_Data()
    {

        ds.Clear();
        try
        {
            if ((Request.QueryString["Exp_Name"] == "" || Request.QueryString["Exp_Name"] == null) && (Request.QueryString["Tr_mode"] == "" || Request.QueryString["Tr_mode"] == null))
            {

            }
            else
            {
                LocalReport localReport = ReportViewer1.LocalReport;
                localReport.ReportPath = @"Report/Export_BL_Consolidate_rpt.rdlc";

                List<ReportParameter> paramList = new List<ReportParameter>();
                this.ReportViewer1.LocalReport.SetParameters(paramList);
                ReportViewer1.LocalReport.DataSources.Clear();

                Export_BL_Multiple MBL = new Export_BL_Multiple();


                MBL.Exp_name = Request.QueryString["Exp_Name"].ToString();
                MBL.Mode = Request.QueryString["Tr_mode"].ToString();
                MBL.R_Id = Request.QueryString["Ref_Id"].ToString();
                MBL.UPD_ID = "";
                MBL.Flag = "Multiple_BL_Rpt";
                MBL.Branch = SELECT_BRANCH;

                dss = MBL.EXPORT_MULTIPLE_BL_PENDING_JOB_SELECT();

                string Cont = string.Empty;
                string BLNumber = string.Empty;
                if (dss.Tables[1].Rows.Count > 0)
                {
                    for (int i = 0; i < dss.Tables[1].Rows.Count; i++)
                    {
                        Cont += dss.Tables[1].Rows[i]["CONTAINER_NO"].ToString() + Environment.NewLine + Environment.NewLine;
                    }

                }
                if (dss.Tables[0].Rows.Count > 0)
                {
                    Cont = Cont + "MARKS & NUMBERS" + Environment.NewLine + Environment.NewLine + dss.Tables[0].Rows[0]["MARKS_NUMBERS"].ToString();
                    BLNumber = dss.Tables[0].Rows[0]["BL_NUMBER"].ToString();
                }


                ReportDataSource datasource = new ReportDataSource("General", dss.Tables[0]);
                ReportViewer1.LocalReport.DataSources.Add(datasource);

                ReportViewer1.LocalReport.DisplayName = "General";
                ReportParameter p1 = new ReportParameter("Container", Cont);

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

                txtrptname.Text = "Multiple BL";
            }


        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();

            er.makeLog
                (ex.Message);
        }
    }
    public void Multiple_BL_Add_Annexure_Report_Data()
    {
        ds.Clear();
        try
        {
            if ((Request.QueryString["Exp_Name"] == "" || Request.QueryString["Exp_Name"] == null) && (Request.QueryString["Tr_mode"] == "" || Request.QueryString["Tr_mode"] == null))
            {

            }
            else
            {
                LocalReport localReport = ReportViewer1.LocalReport;
                localReport.ReportPath = @"Report/Export_BL_Consolidate_Anx_rpt.rdlc";

                List<ReportParameter> paramList = new List<ReportParameter>();
                this.ReportViewer1.LocalReport.SetParameters(paramList);
                ReportViewer1.LocalReport.DataSources.Clear();

                Export_BL_Multiple MBL = new Export_BL_Multiple();
                MBL.Exp_name = Request.QueryString["Exp_Name"].ToString();
                MBL.Mode = Request.QueryString["Tr_mode"].ToString();
                MBL.R_Id = Request.QueryString["Ref_Id"].ToString();
                MBL.UPD_ID = Request.QueryString["Job_Id"].ToString();
                MBL.Flag = "Add_Annexure_Select";
                MBL.Branch = SELECT_BRANCH; ;
                ds = MBL.EXPORT_MULTIPLE_BL_PENDING_JOB_SELECT();

                string Con_ = string.Empty;
                string Markno_ = string.Empty;

                ReportDataSource datasource = new ReportDataSource("General_Anx", ds.Tables[0]);
                ReportViewer1.LocalReport.DataSources.Add(datasource);

                ReportViewer1.LocalReport.DisplayName = "Multiple Add Annexure";

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

                txtrptname.Text = "Multiple Add Annexure";
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