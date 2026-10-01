using System;
using System.Collections.Generic;
//using System.Linq;
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

public partial class Acc_Job_Revenue_Cost_Report : ThemeClass
{
    AppSession aps = new AppSession();

    Acc_Gen_Reports AG = new Acc_Gen_Reports();
    Global_variables ObjUBO = new Global_variables();

    public string JOBNO, dash, IMP_EXP;

    protected void Page_Load(object sender, EventArgs e)
    {
        //JOBNO = Session["JOBNO_PS"].ToString();

        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["DASH_ID"]))
            {
                dash = "1";
                Load_Jobno();
                Load_PartyName();
            }
            else
            {
                string J_no = string.Empty;
                dash = "0";
                //Imp -EXP

                JOBNO = Session["JOBNO_PS"].ToString();
                IMP_EXP = Session["IMP_EXP"].ToString();

                ddlJobno.Items.Clear();
                if (IMP_EXP == "E")
                {
                    J_no = Connection.EXP_Jobno();
                }
                else
                {
                    J_no = Connection.IMP_Jobno();
                }
                ddlJobno.Items.Insert(0, new ListItem(J_no, JOBNO));
                ddlJobno.SelectedIndex = 0;

                Load_Rpt_Data(JOBNO,"CHARGE");
            }
        }

    }

    public void Load_Jobno()
    {
        ddlJobno.Items.Clear();
        DataSet ds = new DataSet();
        ObjUBO.A4 = "LOAD_JOBNO";
        ds = AG.Acc_Gen_Rev_Cost_Rpt(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlJobno.DataTextField = "JOBNO";
            ddlJobno.DataValueField = "JOBNO_PS";
            ddlJobno.DataSource = ds.Tables[0];
            ddlJobno.DataBind();
        }
        ddlJobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlJobno.SelectedIndex = 0;
    }

    public void Load_PartyName()
    {
        ddlPartyName.Items.Clear();
        DataSet ds = new DataSet();
        ObjUBO.A4 = "LOAD_PARTYNAME";
        ds = AG.Acc_Gen_Rev_Cost_Rpt(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlPartyName.DataTextField = "PARTY_NAME";
            ddlPartyName.DataValueField = "PARTY_NAME";
            ddlPartyName.DataSource = ds.Tables[0];
            ddlPartyName.DataBind();
        }
        ddlPartyName.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlPartyName.SelectedIndex = 0;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(ddlJobno.SelectedValue.ToString()) && !string.IsNullOrEmpty(ddlPartyName.SelectedValue.ToString()))
            {
                Load_Rpt_Data(ddlPartyName.SelectedValue.ToString(), "JOBNO");
            }
            else if (!string.IsNullOrEmpty(ddlJobno.SelectedValue.ToString()))
            {
                Load_Rpt_Data(ddlJobno.SelectedValue.ToString(), "CHARGE");
            }
            else
            {
                Alert_msg("Select Ur Jobno !");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void Load_Rpt_Data(string JOBNO_PS,string HEADER)
    {
        try
        {
            DataSet ds1 = new DataSet();
            ObjUBO.A3 = JOBNO_PS;
            ObjUBO.A5 = ddlPartyName.SelectedValue;
            if (ddlPartyName.SelectedValue.ToString() != string.Empty && ddlJobno.SelectedValue.ToString() == string.Empty)
            {
                ObjUBO.A4 = "Report_Partyname";
            }
            else
            {

                ObjUBO.A4 = "Report";
            }
            ds1 = AG.Acc_Gen_Rev_Cost_Rpt(ObjUBO);

            LocalReport localReport = ReportViewer1.LocalReport;
            localReport.ReportPath = @"Accounts_General_Reports/Acc_Job_Revenue_Cost_Rpt.rdlc";
            ReportViewer1.LocalReport.EnableExternalImages = true;

            List<ReportParameter> paramList = new List<ReportParameter>();

            this.ReportViewer1.LocalReport.SetParameters(paramList);
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource datasource = new ReportDataSource("DataSet1", ds1.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportViewer1.LocalReport.DisplayName = "Rev_Cost";
            ReportParameter p1 = new ReportParameter("JOBNO", JOBNO_PS);
            ReportParameter p2 = new ReportParameter("JOB_CHARGE_HEADER", HEADER);
            ReportParameter[] p = { p1, p2 };
            ReportViewer1.LocalReport.SetParameters(p);

            Report_Print();
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
        string mimeType = string.Empty, encoding = string.Empty, extension = string.Empty;

        byte[] bytes = ReportViewer1.LocalReport.Render("pdf", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
        byte[] bytes_2 = ReportViewer1.LocalReport.Render("Excel", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

        Session.Remove("report_inv_Excel");
        Session.Remove("report_Pdf");
        Session["report_inv_Excel"] = bytes_2;
        Session["report_Pdf"] = bytes;
        //--------------------------------------To Print------------------------------------------------------------------------------------//
        ReportViewer1.Visible = true;
    }
    protected void btnexcel_Click(object sender, EventArgs e)
    {
        byte[] bytes = (byte[])Session["report_inv_Excel"];
        Response.ClearHeaders();
        Response.Clear();

        Response.ContentType = "application/xls";
        Response.AddHeader("content-disposition", "attachment;filename=" + ddlJobno.SelectedValue + "_Acc_Job_Revenue_Cost_Rpt" + ".xls");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.BinaryWrite(bytes);
        Response.End();
    }
    protected void btnRdlc_Click(object sender, EventArgs e)
    {

        byte[] bytes = (byte[])Session["report_Pdf"];
        Response.ClearHeaders();
        Response.Clear();

        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=" + ddlJobno.SelectedValue + "_Acc_Job_Revenue_Cost_Rpt" + ".pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.BinaryWrite(bytes);
        Response.End();
    }



    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GENERAL', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }



}