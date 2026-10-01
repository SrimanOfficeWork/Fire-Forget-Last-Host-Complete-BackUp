using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.Reporting.WebForms;
using Microsoft.ReportingServices.Rendering;
using Microsoft.ReportingServices.Library;
using System.Data.SqlClient;
using System.Data;

using BussinessObject;
using System.IO;
using System.Text;


public partial class Consolidated_Packing_List_Rpt : System.Web.UI.Page
{
    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();

    Exp_Packing_List EPL = new Exp_Packing_List();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();
      
        if (!IsPostBack)
        {
            if (Request.QueryString["Job_Id"] == "" || Request.QueryString["Job_Id"] == null)
            {

            }
            else
            {
                load_data();
            }
        }
    }
    private void load_data()
    {
        try
        {
            LocalReport localReport = ReportViewer1.LocalReport;
            DataSet dss = new DataSet();

            ObjUBO.A1 = Request.QueryString["Job_Id"].ToString();
            ObjUBO.A4 = "Exporter_Name";
            dss = EPL.Pkg_List_Rpt(ObjUBO);

            if (dss.Tables[0].Rows.Count > 0)
            {
                localReport.ReportPath = @"BL_Generation/Consolidated_Packing_List_Rpt.rdlc";
                ReportViewer1.LocalReport.EnableExternalImages = true;

                List<ReportParameter> paramList = new List<ReportParameter>();
                this.ReportViewer1.LocalReport.SetParameters(paramList);
                ReportViewer1.LocalReport.DataSources.Clear();

                ReportDataSource datasource = new ReportDataSource("DataSet1", dss.Tables[0]);
                ReportViewer1.LocalReport.DataSources.Add(datasource);
                ReportDataSource datasource1 = new ReportDataSource("DataSet2", dss.Tables[1]);
                ReportViewer1.LocalReport.DataSources.Add(datasource1);

                ReportViewer1.LocalReport.DisplayName = "Exp_Consolidated_Packinglist";

                ReportParameter[] p = { };
                ReportViewer1.LocalReport.SetParameters(p);

                Report_Print();
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void Report_Print()
    {
           Warning[] warnings;
           string[] streamIds;
           string mimeType = string.Empty, encoding = string.Empty,extension = string.Empty;

           byte[] bytes = ReportViewer1.LocalReport.Render("pdf", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
           Session.Remove("report");
           Session["report"] = bytes;
           //--------------------------------------To Print------------------------------------------------------------------------------------//
           ReportViewer1.Visible = true; 
    }
    protected void btnpdf_Click(object sender, EventArgs e)
    {
        byte[] bytes = (byte[])Session["report"];
        Response.ClearHeaders();
        Response.Clear();

        Response.ContentType = "application/pdf";
        string File_name = "Exp_Consolidated_Packinglist";
        Response.AddHeader("content-disposition", "attachment;filename="+File_name+".pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.BinaryWrite(bytes);
        Response.End();
    }
    public string Get_StateCode(string StateName)
    {
        if (StateName == "JAMMU & KASHMIR")
        {
            StateName = "[01] " + StateName;
        }
        if (StateName == "HIMACHAL PRADESH")
        {
            StateName = "[02] " + StateName;
        }
        if (StateName == "PUNJAB")
        {
            StateName = "[03] " + StateName;
        }
        if (StateName == "CHANDIGARH")
        {
            StateName = "[04] " + StateName;
        }
        if (StateName == "UTTARAKHAND")
        {
            StateName = "[05] " + StateName;
        }
        if (StateName == "HARYANA")
        {
            StateName = "[06] " + StateName;
        }
        if (StateName == "DELHI")
        {
            StateName = "[07] " + StateName;
        }
        if (StateName == "RAJASTHAN")
        {
            StateName = "[08] " + StateName;
        }
        if (StateName == "UTTAR PRADESH")
        {
            StateName = "[09] " + StateName;
        }
        if (StateName == "BIHAR")
        {
            StateName = "[10] " + StateName;
        }
        if (StateName == "SIKKIM")
        {
            StateName = "[11] " + StateName;
        }
        if (StateName == "ARUNACHAL PRADESH")
        {
            StateName = "[12] " + StateName;
        }
        if (StateName == "NAGALAND")
        {
            StateName = "[13] " + StateName;
        }
        if (StateName == "MANIPUR")
        {
            StateName = "[14] " + StateName;
        }
        if (StateName == "MIZORAM")
        {
            StateName = "[15] " + StateName;
        }
        if (StateName == "TRIPURA")
        {
            StateName = "[16] " + StateName;
        }
        if (StateName == "MEGHALAYA")
        {
            StateName = "[17] " + StateName;
        }
        if (StateName == "ASSAM")
        {
            StateName = "[18] " + StateName;
        }
        if (StateName == "WEST BENGAL")
        {
            StateName = "[19] " + StateName;
        }
        if (StateName == "JHARKHAND")
        {
            StateName = "[20] " + StateName;
        }
        if (StateName == "ORISSA")
        {
            StateName = "[21] " + StateName;
        }
        if (StateName == "CHATTISGARH")
        {
            StateName = "[22] " + StateName;
        }
        if (StateName == "MADHYA PRADESH")
        {
            StateName = "[23] " + StateName;
        }
        if (StateName == "GUJARAT")
        {
            StateName = "[24] " + StateName;
        }
        if (StateName == "DAMAN & DIU")
        {
            StateName = "[25] " + StateName;
        }
        if (StateName == "DADRA & NAGAR HAVELI")
        {
            StateName = "[26] " + StateName;
        }
        if (StateName == "MAHARASHTRA")
        {
            StateName = "[27] " + StateName;
        }

        if (StateName == "KARNATAKA")
        {
            StateName = "[29] " + StateName;
        }
        if (StateName == "GOA")
        {
            StateName = "[30] " + StateName;
        }
        if (StateName == "LAKSHADWEEP")
        {
            StateName = "[31] " + StateName;
        }
        if (StateName == "KERALA")
        {
            StateName = "[32] " + StateName;
        }
        if (StateName == "TAMILNADU")
        {
            StateName = "[33] " + StateName;
        }
        if (StateName == "TAMIL NADU")
        {
            StateName = "[33] " + StateName;
        }
        if (StateName == "PONDICHERRY")
        {
            StateName = "[34] " + StateName;
        }
        if (StateName == "ANDAMAN & NICOBAR")
        {
            StateName = "[35] " + StateName;
        }
        if (StateName == "TELANGANA")
        {
            StateName = "[36] " + StateName;
        }
        if (StateName == "ANDHRA PRADESH")
        {
            StateName = "[37] " + StateName;
        }

        return StateName;
    }
  
}