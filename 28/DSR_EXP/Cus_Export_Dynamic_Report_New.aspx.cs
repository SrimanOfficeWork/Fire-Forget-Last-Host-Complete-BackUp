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

public partial class Cus_Import_Dynamic_Report_New : System.Web.UI.Page
{
    AppSession aps = new AppSession();
    Global_variables GV = new Global_variables();
    DSR_EXP_CS DR = new DSR_EXP_CS();


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
            
        GV.A1 = Request["From_date"].ToString();
        GV.A2 = Request["To_date"].ToString();
        GV.A3 = Request["JobNo"].ToString();
        GV.A4 = Request["Client_Name"].ToString();
        GV.A5 = Request["Report_Name"].ToString();
        GV.A6 = Request["Report_Id"].ToString();
        GV.A7 = "Grid_Search";
        GV.A8 = Request["Branch_Slno"].ToString();
        GV.A9 = Request["Party_Refno"].ToString();
        GV.A10 = Request["Tr_Mode"].ToString();

        GV.A11 = Request["Sup_Name"].ToString();
        GV.A12 = Request["Rpt_Type"].ToString();
        dss = DR.CUS_DSR_EXP_Report_Data(GV);

        if (dss.Tables[0].Rows.Count > 0)
        {
            string dsName = string.Empty;
            dsName = Request["Report_Name"].ToString().Replace(" ", "_").Replace("&", "");
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
                Response.AddHeader("content-disposition", "attachment;filename=" + Request["Report_Name"].ToString() + ".xls");
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