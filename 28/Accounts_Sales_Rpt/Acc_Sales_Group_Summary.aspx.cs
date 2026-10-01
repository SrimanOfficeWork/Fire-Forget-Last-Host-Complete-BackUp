using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;
using BussinessObject;

public partial class Accounts_Sales_Rpt_Acc_Sales_Group_Summary : ThemeClass
{
    AppSession aps = new AppSession();

    Acc_Gen_Reports AG = new Acc_Gen_Reports();
    Global_variables ObjUBO = new Global_variables();

    string[] arr_Month = new string[] { };

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Load_Group_Name();
            load_Cus_name();
        }
    }
    private void Load_Group_Name()
    {
        ddlgroup_Name.Items.Clear();
        if (Session["ClientGrpMst"] != null)
        {
            DataSet ds = (DataSet)Session["ClientGrpMst"];
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlgroup_Name.DataSource = ds.Tables[0];
                ddlgroup_Name.DataTextField = "GROUP_NAME";
                ddlgroup_Name.DataValueField = "GROUP_ID";
                ddlgroup_Name.DataBind();
            }
        }
        ddlgroup_Name.Items.Insert(0, new ListItem("ALL", "ALL"));
        ddlgroup_Name.SelectedIndex = 0;

    }
    public void load_Cus_name()
    {
        try
        {
            DataSet dss = new DataSet();
            ObjUBO.A16 = "LOAD_GROUP_NAME";
            dss = AG.Acc_sales_group_Summary_Rpt(ObjUBO);
            if (dss.Tables[0].Rows.Count > 0)
            {
                ddl_GroupName.DataSource = dss.Tables[0];
                ddl_GroupName.DataTextField = "GROUP_NAME";
                ddl_GroupName.DataValueField = "GROUP_NAME";
                ddl_GroupName.DataBind();

                ddl_GroupName.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddl_GroupName.SelectedIndex = 0;
            }
            if (dss.Tables[1].Rows.Count > 0)
            {
                ddl_SubGroupName.DataSource = dss.Tables[1];
                ddl_SubGroupName.DataTextField = "SUB_GROUP";
                ddl_SubGroupName.DataValueField = "SUB_GROUP";
                ddl_SubGroupName.DataBind();

                ddl_SubGroupName.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddl_SubGroupName.SelectedIndex = 0;
            }
            
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

            ObjUBO.A1 = ddlgroup_Name.SelectedValue == "ALL" ? "" : ddlgroup_Name.SelectedValue;
            ObjUBO.A2 = ddl_GroupName.SelectedValue;
            ObjUBO.A3 = ddl_SubGroupName.SelectedValue;
            ObjUBO.A16 = "Report";
            ds1 = AG.Acc_sales_group_Summary_Rpt(ObjUBO);
            ReportViewer1.Reset();
            LocalReport localReport = ReportViewer1.LocalReport;
            localReport.ReportPath = @"Accounts_Sales_Rpt/Acc_Sales_Group_Summary_Rpt.rdlc";
            ReportViewer1.LocalReport.EnableExternalImages = true;
            ReportDataSource datasource = new ReportDataSource("DataSet1", ds1.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            ReportViewer1.LocalReport.DisplayName = "Group Summary";
            Report_Print();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "report_type()", true);
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
        Response.AddHeader("content-disposition", "attachment;filename=" + "Group Summary Rpt" + ".xls");
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
        Response.AddHeader("content-disposition", "attachment;filename=" + "Sales Ledger Summary Rpt" + ".pdf");
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