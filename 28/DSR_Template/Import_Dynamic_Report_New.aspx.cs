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

public partial class DSR_Template_Import_Dynamic_Report_New : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    DataSet dss = new DataSet();

    AppSession aps = new AppSession();
    Dynamic_Report DRT = new Dynamic_Report();

    string JobNo, Report_Name, From_date, To_date,F_date,T_date;

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
        bool isEmpty = true;

        if (!string.IsNullOrEmpty(Request["JobNo"]))
        {
            JobNo = Request["JobNo"].ToString();
        }
        else
        {
            JobNo = "";
        }

        if (!string.IsNullOrEmpty(Request["From_date"]))
        {
            From_date = Request["From_date"].ToString();

            arr = From_date.Split('/');
            F_date = arr[1] + '/' + arr[0] + '/' + arr[2];
        }
        else
        {
            F_date = "";
        }

        if (!string.IsNullOrEmpty(Request["To_date"]))
        {
            To_date = Request["To_date"].ToString();

            arr = To_date.Split('/');
            T_date = arr[1] + '/' + arr[0] + '/' + arr[2];
        }
        else
        {
            T_date = "";
        }

        string orderby = string.Empty;

        if (Request["Orderby"].ToString() == "Ascending")
        {
            orderby = "Asc";
        }
        else if (Request["Orderby"].ToString() == "Descending")
        {
            orderby = "Desc";
        }


        DRT.Jobno=JobNo;
        DRT.Report_Name = Request["Report_Name"].ToString();
        DRT.Report_Name_id = Request["Report_Id"].ToString();
        DRT.From_date=F_date;
        DRT.To_date=T_date;
        DRT.Orderby = orderby;
        DRT.Rpt_Type = Request["Based"].ToString();
        DRT.Imp_Name = Request["Imp_name"].ToString();
        DRT.BE_Type = Request["BE_Type"].ToString();

        
        dss= DRT.Report_data();
        if (dss.Tables[0].Rows.Count > 0)
        {
            string dsName = string.Empty;

            dsName = Request["Report_Name"].ToString().Replace(" ", "_");
            dt = dss.Tables[0];

            /************************************ for EKATA Shipping Report - 05-09-2018 - By Chithra ************************/
            if (Connection.COMPANYID() == "1029")
            {
                //if (dsName == "EKTA_REPORT_sea")
                //{
                    DataColumnCollection columns = dt.Columns;
                    if (columns.Contains("TYPE"))
                    {
                        int Index = columns.IndexOf("TYPE");

                        DataColumn Col = dt.Columns.Add("SIZE", System.Type.GetType("System.String"));
                        Col.SetOrdinal(Index);

                        IEnumerable<DataRow> rowsc = dt.Rows.Cast<DataRow>().Where(r => r["TYPE"].ToString().Length >= 2);
                        rowsc.ToList().ForEach(r => r.SetField("SIZE", r["TYPE"].ToString().Substring(0, 2)));

                        IEnumerable<DataRow> rowsc2 = dt.Rows.Cast<DataRow>().Where(r => r["TYPE"].ToString().Length >= 2);
                        rowsc2.ToList().ForEach(r => r.SetField("TYPE", r["TYPE"].ToString().Replace("20", "").Replace("40", "")));

                    }
                //}
            }
            /******************************************************************************************************************/


            /************************************ for AS Shipping Report - 05-09-2018 - By Chithra ************************/
            if (Connection.COMPANYID() == "522")
            {
                //if (dsName == "AS_SHIP_CONTAINER")
                //{
                if (DRT.Rpt_Type == "Container")
                {
                    DataColumnCollection columns = dt.Columns;
                    if (columns.Contains("CONTAINER_NO"))
                    {
                        int Index = columns.IndexOf("CONTAINER_NO");

                        DataColumn Col = dt.Columns.Add("CONTAINER_COUNT", System.Type.GetType("System.String"));
                        Col.SetOrdinal(Index);

                        DataView dv_cont = new DataView(dt);
                        DataTable dt_jobno = dv_cont.ToTable(true, "JOBNO", "CONTAINER_NO");

                        int K = 1;
                        int jobno = 0;
                        int FIRST_jobno = 0;

                        foreach (DataRow dr in dt_jobno.AsEnumerable())
                        {

                            int aa = Convert.ToInt32(dr["JOBNO"].ToString());
                            string ContainerNo = dr["CONTAINER_NO"].ToString();

                            var count = dt.AsEnumerable().Where(row => (Int64)row["JOBNO"] == aa).Count();

                            if (count == 1 && ContainerNo == "")
                            {
                                count = 0;
                            }

                            if (FIRST_jobno != aa)
                            {
                                jobno = aa;
                                FIRST_jobno = aa;
                            }
                            if (jobno == aa)
                            {
                                IEnumerable<DataRow> rowsc = dt.Rows.Cast<DataRow>().Where(r => r["JOBNO"].ToString() == dr["JOBNO"].ToString() && r["CONTAINER_NO"].ToString() == ContainerNo);
                                rowsc.ToList().ForEach(r => r.SetField("CONTAINER_COUNT", count));
                                jobno = 0;
                            }
                            else
                            {
                                IEnumerable<DataRow> rowsc = dt.Rows.Cast<DataRow>().Where(r => r["JOBNO"].ToString() == dr["JOBNO"].ToString() && r["CONTAINER_NO"].ToString() == ContainerNo);
                                rowsc.ToList().ForEach(r => r.SetField("CONTAINER_COUNT", "NIL"));
                            }

                        }
                        dt.Columns.Remove("CONTAINER_NO");

                        dt = dt.AsEnumerable().Where(r => r.Field<string>("CONTAINER_COUNT") != "NIL").CopyToDataTable();

                    }
                }
            }

            /******************************************************************************************************************/
            if (Connection.COMPANYID() == "293" && Request["Report_Name"].ToString() == "TOYOTA KIRLOSKAR AUTO PARTS")
            {
            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    isEmpty = true;
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (string.IsNullOrEmpty(dt.Rows[i][j].ToString()) == false)
                        {
                            isEmpty = false;
                            break;
                        }
                    }

                    if (isEmpty == true)
                    {
                        dt.Rows.RemoveAt(i);
                        i--;
                    }
                }
            }


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
       // IMP_CUSTOMIZATION_RPT_BRANCH
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
           Response.AddHeader("content-disposition", "attachment;filename=" + Request["Report_Name"].ToString() + ".xls");
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