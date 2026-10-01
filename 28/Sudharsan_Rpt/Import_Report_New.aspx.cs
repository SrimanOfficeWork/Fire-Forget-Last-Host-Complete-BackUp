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

public partial class Import_Report_New : System.Web.UI.Page
{
    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();
    S_Imp_Rpt Rpt = new S_Imp_Rpt();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();

    string JobNo, Report_Name, From_date, To_date,F_date,T_date,Tr_Mode;

    string[] arr = new string[] { };
    string[] arr2 = new string[] { };
           
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
        ObjUBO.A1 = Request["From_date"].ToString();
        ObjUBO.A2 = Request["To_date"].ToString();
        ObjUBO.A3 = Request["Imp_name"].ToString();
        ObjUBO.A4 = Request["JobNo"].ToString();
        ObjUBO.A6 = Request["Tr_Mode"].ToString();

        if (Request["Rpt_name"].ToString() == "R_I")
        {
            ObjUBO.A10 = "IMP_SUDHARSAN_RPT_I";
        }
        else if (Request["Rpt_name"].ToString() == "R_II")
        {
            ObjUBO.A10 = "IMP_SUDHARSAN_RPT_II";
        }
        else if (Request["Rpt_name"].ToString() == "R_III")
        {
            ObjUBO.A10 = "IMP_SUDHARSAN_RPT_III";
        }
        else if (Request["Rpt_name"].ToString() == "R_IV")
        {
            ObjUBO.A10 = "IMP_SUDHARSAN_RPT_IV";
        }
        else if (Request["Rpt_name"].ToString() == "R_V")
        {
            ObjUBO.A10 = "IMP_SUDHARSAN_RPT_V";
        }
        ds = Rpt.Imp_Rpt_Data(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            string Rpt_Name = string.Empty;
            Rpt_Name = Request["Rpt_name"].ToString().Replace(" ", "_");
            dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                ViewState["Excel"] = dt;
                ReportGenerator gen = new ReportGenerator(dt, Rpt_Name);
                ReportDataSource RD = new ReportDataSource(Rpt_Name, dt);
                ReportViewer1.Reset();
                ReportViewer1.LocalReport.DataSources.Add(RD);
                ReportViewer1.LocalReport.DisplayName = Rpt_Name;
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
       DataTable dtt =new DataTable();
       dtt = (DataTable)ViewState["Excel"];

       if (dtt.Rows.Count > 0)
       {
           Response.Clear();
           Response.Buffer = true;
           Response.AddHeader("content-disposition", "attachment;filename=" + Request["Rpt_name"].ToString() + ".xls");
           Response.Charset = "";
           Response.ContentType = "application/vnd.ms-excel";
           using (StringWriter sw = new StringWriter())
           {
               HtmlTextWriter hw = new HtmlTextWriter(sw);

               GridView gv = new GridView();

               //gv.HeaderStyle.BackColor = System.Drawing.Color.RoyalBlue;
              // gv.HeaderStyle.ForeColor = System.Drawing.Color.White;
               gv.AllowPaging = false;
               gv.DataSource = dtt;
               gv.DataBind();

               /*
               foreach (TableCell cell in gv.HeaderRow.Cells)
               {
                   cell.BackColor = gv.HeaderStyle.BackColor;
               }
               */
               gv.RenderControl(hw);

               string style = @"<style> .textmode { } </style>";
               Response.Write(style);
               Response.Output.Write(sw.ToString());
               Response.Flush();
               Response.End();
           }
       }
    }
}