using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.Reflection;
using BussinessObject;
using GeneraReport;
using System.IO;

public partial class Imp_Exp_Invoice_Job_Count_Rpt_New : System.Web.UI.Page
{
    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();
    Imp_Exp_Rpt IER = new Imp_Exp_Rpt();


    string[] arr = new string[] { };
    string[] arr2 = new string[] { };

    DataTable dt = new DataTable();
           
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
              
           if(!IsPostBack)
           {
                Report_data();
           }
    }

    private void Report_data()
    {
        DataSet dss = new DataSet();
        ObjUBO.A1 = Request["Imp_Exp"].ToString();
        ObjUBO.A2 = Request["Cus_Name"].ToString();
        ObjUBO.A3 = Request["Tr_mode"].ToString();
        ObjUBO.A4 = Request["Filter"].ToString();
        ObjUBO.A5 = Request["from_Date"].ToString();
        ObjUBO.A6 = Request["to_Date"].ToString();
        ObjUBO.A7 = "Grid_Search";
        dss = IER.IMP_EXP_DATA(ObjUBO);
        if (dss.Tables[0].Rows.Count > 0)
        {
            string dsName = string.Empty;
            dsName = "Job_Count_Status";
            dt = dss.Tables[0];

            if (dt.Rows.Count > 0)
            {
                ViewState["Excel"] = dt;
                ReportGenerator gen = new ReportGenerator(dt, dsName);
                ReportDataSource ds = new ReportDataSource(dsName, dt);
                ReportViewer1.Reset();
                ReportViewer1.LocalReport.DataSources.Add(ds);
                ReportViewer1.LocalReport.DisplayName = dsName;
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

    protected void btnexcel_Click(object sender, ImageClickEventArgs e)
    {

        if (ViewState["Excel"] != null && !ViewState["Excel"].Equals("-1")) 
        {
            DataTable dtt = new DataTable();
            dtt = (DataTable)ViewState["Excel"];

            if (dtt.Rows.Count > 0)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=" + "Job_Count_Status" + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);

                    GridView gv = new GridView();
                    gv.AllowPaging = false;
                    gv.DataSource = dtt;
                    gv.DataBind();
                    gv.RenderControl(hw);

                    string style = @"<style> .textmode { } </style>";
                    Response.Write(style);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
            }

        }
        else
        {
            lblerror.InnerText = "No Record Found.";
        }
    }
}