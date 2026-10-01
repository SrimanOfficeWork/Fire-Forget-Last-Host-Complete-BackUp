using System;
using System.Collections.Generic;
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

public partial class Accounts_Cash_Report : ThemeClass
{
    AppSession aps = new AppSession();

    Acc_Gen_Reports AG = new Acc_Gen_Reports();
    Global_variables ObjUBO = new Global_variables();
    DataSet ds = new DataSet();
    string[] arr_Month = new string[] { };

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Load_Month();
            load_Cus_name();

        }

    }
    public void Load_Month()
    {
        try
        {
            DataSet ds = new DataSet();
            ds.Clear();
            ds = Common_CS.Load_Month();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlmonth.DataSource = ds.Tables[0];
                ddlmonth.DataTextField = "TheMonth";
                ddlmonth.DataValueField = "TheMonth_No";
                ddlmonth.DataBind();

                ddlmonth.Items.Insert(ddlmonth.Items.Count, new ListItem(String.Empty, String.Empty));
                ddlmonth.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    public void load_Cus_name()
    {
        try
        {


            ddlchargename.Items.Clear();
            ObjUBO.A4 = "CHARGE";
            ds = AG.Acc_Cash_Book_Rpt(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlchargename.DataSource = ds.Tables[0];
                ddlchargename.DataTextField = "CHARGE_NAME";
                ddlchargename.DataValueField = "CHARGE_NAME";
                ddlchargename.DataBind();
            }
            ddlchargename.Items.Insert(0, new System.Web.UI.WebControls.ListItem(String.Empty, String.Empty));
            ddlchargename.SelectedIndex = 0;



        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {

            Load_Rpt_Data();

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void Load_Rpt_Data()
    {
        try
        {
            DataSet ds1 = new DataSet();


            if (txtfromdate.Text != string.Empty || txttodate.Text != string.Empty)
            {
                ObjUBO.A1 = txtfromdate.Text;
                ObjUBO.A2 = txttodate.Text;
            }
            else
            {
                if (ddlmonth.SelectedItem.Text != string.Empty)
                {
                    arr_Month = ddlmonth.SelectedValue.ToString().Split('-');
                    ObjUBO.A1 = arr_Month[0];
                    ObjUBO.A2 = arr_Month[1];
                }
                else
                {
                    ObjUBO.A1 = txtfromdate.Text;
                    ObjUBO.A2 = txttodate.Text;
                }
            }



            ObjUBO.A3 = ddlchargename.SelectedValue;
            ObjUBO.A4 = "Report";
            ds1 = AG.Acc_Cash_Book_Rpt(ObjUBO);
            ReportViewer1.Reset();
            LocalReport localReport = ReportViewer1.LocalReport;


            localReport.ReportPath = @"Accounts_Cash_Report\Accounts_Cash_Book_Rept.rdlc";

            ReportViewer1.LocalReport.EnableExternalImages = true;
            ReportDataSource datasource = new ReportDataSource("DataSet1", ds1.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportDataSource datasource2 = new ReportDataSource("DataSet2", ds1.Tables[1]);
            ReportViewer1.LocalReport.DataSources.Add(datasource2);


            ReportViewer1.LocalReport.DisplayName = "Cash Book";


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

        Session.Remove("rpt_Excel");
        Session.Remove("rpt_Pdf");
        Session["rpt_Excel"] = bytes_2;
        Session["rpt_Pdf"] = bytes;
        //--------------------------------------To Print------------------------------------------------------------------------------------//
        ReportViewer1.Visible = true;
    }
    protected void btnexcel_Click(object sender, EventArgs e)
    {

        byte[] bytes = (byte[])Session["rpt_Excel"];
        Response.ClearHeaders();
        Response.Clear();

        Response.ContentType = "application/xls";
        Response.AddHeader("content-disposition", "attachment;filename=" + "Cash Book" +  ".xls");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.BinaryWrite(bytes);
        Response.End();
    }


    protected void btnRdlc_Click(object sender, EventArgs e)
    {

        byte[] bytes = (byte[])Session["rpt_Pdf"];
        Response.ClearHeaders();
        Response.Clear();
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=" + "Cash Book" + ".pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.BinaryWrite(bytes);
        Response.End();
    }

}