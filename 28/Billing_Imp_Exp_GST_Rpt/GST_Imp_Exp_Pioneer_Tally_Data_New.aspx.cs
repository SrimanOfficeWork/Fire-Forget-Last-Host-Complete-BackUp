using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

using GeneraReport;
using Microsoft.Reporting.WebForms;
using System.Reflection;

public partial class GST_Imp_Exp_Pioneer_Tally_Data_New : System.Web.UI.Page
{
    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();
    GST_Pioneer_Tally_Data PTD = new GST_Pioneer_Tally_Data();

    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        if (!IsPostBack)
        {
            Report_data();
        }
    }

    private void Report_data()
    {
        DataTable dt = new DataTable();
       
        ObjUBO.A1 =  Request["Type"].ToString();
        ObjUBO.A2 = Request["Client_Name"].ToString().Replace("&amp;","&");
        ObjUBO.A3 = Request["From_date"].ToString();
        ObjUBO.A4 = Request["To_date"].ToString();
        ObjUBO.A5 = "Taly_Data";
        ds = PTD.Billing_Tally_Data(ObjUBO);

        if (ds.Tables[0].Rows.Count > 0)
        {
            dt = ds.Tables[0];
            string File_name = string.Empty;

            if (Request["From_date"].ToString() != null && Request["From_date"].ToString() != string.Empty
                && Request["To_date"].ToString() != null && Request["To_date"].ToString() != string.Empty
                )
            {
                File_name = "TallyData_"+(Request["From_date"].ToString()+"_"+ Request["To_date"].ToString()).Replace("/","");
            }
            else
            { 
                File_name= "TallyData";
            }

            if (dt.Rows.Count > 0)
            {
                ReportGenerator gen = new ReportGenerator(dt, File_name);
                ReportDataSource dss = new ReportDataSource(File_name, dt);
                ReportViewer1.Reset();
                ReportViewer1.LocalReport.DataSources.Add(dss);
                ReportViewer1.LocalReport.DisplayName = File_name;
                ReportViewer1.LocalReport.LoadReportDefinition(gen.GeneraReport());
            }
            else
            {
                lblerror.InnerText = "No Record Found.";
            }
        }
    }

    protected void ReportViewer1_PreRender(object sender, EventArgs e)
    {
        DisableUnwantedExportFormats(ReportViewer1.LocalReport);
    }
    public static void DisableUnwantedExportFormats(LocalReport rvServer)
    {
        foreach (RenderingExtension extension in rvServer.ListRenderingExtensions())
        {
            if (extension.Name == "WORD")
            {
                ReflectivelySetVisibilityFalse(extension);
            }
        }
    }

    public static void ReflectivelySetVisibilityFalse(RenderingExtension extension)
    {
        FieldInfo info = extension.GetType().GetField("m_isVisible", BindingFlags.NonPublic | BindingFlags.Instance);

        if (info != null)
        {
            info.SetValue(extension, false);
        }
    }

}