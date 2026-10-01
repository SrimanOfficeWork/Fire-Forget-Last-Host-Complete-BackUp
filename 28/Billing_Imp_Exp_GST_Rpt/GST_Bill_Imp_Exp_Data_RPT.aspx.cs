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

public partial class GST_Bill_Imp_Exp_Data_RPT : System.Web.UI.Page
{
    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();
    GST_Billing_Paramount DA = new GST_Billing_Paramount();

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
        string fname = string.Empty;
        try { 
        DataTable dt = new DataTable();
        ObjUBO.A1 =  Request["Type"].ToString();
        ObjUBO.A2 = Request["Client_Name"].ToString().Replace("&amp;", "&");
        ObjUBO.A3 = Request["From_date"].ToString();
        ObjUBO.A4 = Request["To_date"].ToString();
        
        ObjUBO.A5 =  Request["Inv_no"].ToString();
        ObjUBO.A6 =  Request["Jobno"].ToString();
        ObjUBO.A7 = Request["Charge_Name"].ToString();
        ObjUBO.A8 = "IMP_EXP_DATA";  

        if (Request["RPT_Cat"].ToString() == "PL")
        {
            ObjUBO.A10 = "GST_COMBINE_BILL_IMP_EXP_DATA";
            fname = "IMP_EXP_DATA";
        }
        else if (Request["RPT_Cat"].ToString() == "CH")
        {
            ObjUBO.A10 = "GST_COMBINE_BILL_IMP_EXP_CHARGE_HEAD_DATA";
            fname = "IMP_EXP_CHARGE_HEAD_DATA";
        }
        ds = DA.Billing_Data(ObjUBO);

        if (ds.Tables[0].Rows.Count > 0)
        {
            dt = ds.Tables[0];
            string File_name = string.Empty;

            if (Request["From_date"].ToString() != null && Request["From_date"].ToString() != string.Empty
                && Request["To_date"].ToString() != null && Request["To_date"].ToString() != string.Empty
                )
            {

                File_name = fname + (Request["From_date"].ToString() + "_" + Request["To_date"].ToString()).Replace("/", "");
            }
            else
            {
                File_name = fname;
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
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
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