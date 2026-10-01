using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Data;
using System.Data.SqlClient;
using GeneraReport;
using Microsoft.Reporting.WebForms;
using System.Reflection;

public partial class DSR_Template_Export_Dynamic_Report_New : System.Web.UI.Page
{
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;

    string JobNo, Report_Name, From_date, To_date, F_date, T_date;

    string[] arr = new string[] { };
    string[] arr2 = new string[] { };


    public string SELECT_TYPE, SELECT_BRANCH;

    AppSession aps = new AppSession();
    Exp_Dynamic_Report DRT = new Exp_Dynamic_Report();

    DataTable dt = new DataTable();
    DataSet dss = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
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
        // iframe1.Attributes["src"] = "Import_Dynamic_Report_New.aspx?JobNo=" + ddlJobNo.SelectedItem.Text + "&Report_Name=" + ddlrptname.SelectedItem.Text + "&Report_Id=" + ddlrptname.SelectedValue.ToString() + "&From_date=" + txtFrom_Date.Text + "&To_date=" + txtTo_Date.Text + "";

        string orderby = string.Empty;

        if (Request["Orderby"].ToString() == "Ascending")
        {
            orderby = "Asc";
        }
        else if (Request["Orderby"].ToString() == "Descending")
        {
            orderby = "Desc";
        }



        DRT.Jobno = JobNo;
        DRT.Report_Name = Request["Report_Name"].ToString();
        DRT.Report_Name_id = Request["Report_Id"].ToString();
        DRT.From_date = F_date;
        DRT.To_date = T_date;
        DRT.WORKING_PERIOD = SELECT_BRANCH;
        DRT.Orderby = orderby;
        DRT.Rpt_Type = Request["Based"].ToString();
        DRT.Exp_name = Request["Exp_name"].ToString().Replace("&amp;","&");;

        dss = DRT.Report_data();

        if (dss.Tables[0].Rows.Count > 0)
        {
            string dsName = string.Empty;

            dsName = Request["Report_Name"].ToString().Replace(" ", "_"); 
            
            dt = dss.Tables[0];


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


            if (dt.Rows.Count > 0)
            {
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

}