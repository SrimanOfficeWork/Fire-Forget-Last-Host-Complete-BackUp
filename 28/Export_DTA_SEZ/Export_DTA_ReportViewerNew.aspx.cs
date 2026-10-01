using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Data.SqlClient;
using System.IO;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Microsoft.Reporting.WebForms;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Globalization;
using Ionic.Zip;
using System.Text.RegularExpressions;
using System.Net;
using BussinessObject;

public partial class Export_DTA_ReportViewerNew : System.Web.UI.Page
{

   // Export_CheckList CHKLIST = new Export_CheckList();
    Date_Time dt = new Date_Time();
    Global_variables ObjUBO = new Global_variables();
    Exp_DTA DTA = new Exp_DTA();
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
    public string currentuser, ddlJobNo;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    AppSession aps = new AppSession();
 

    List<Export_DTA_ReportViewerNew> Rpt_Item_Details_new_list = new List<Export_DTA_ReportViewerNew>();
    List<Export_DTA_ReportViewerNew> Rpt_Invoice_Details_list = new List<Export_DTA_ReportViewerNew>();
 

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = HttpContext.Current.Session["currentcomp_db"].ToString();
        Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();
        LoginDate = HttpContext.Current.Session["LoginDate"].ToString();


        SELECT_BRANCH = Connection.Get_Company_Type();
        if (!IsPostBack)
        {
            if (Request.QueryString["jobno"] == "" || Request.QueryString["jobno"] == null)
            {

            }
            else
            {
                checklistNew();
            }
        }
    }

    private void checklistNew()
    {

        //try
        //{

        List<Export_DTA_ReportViewerNew> Load_Item_DetailsInd = new List<Export_DTA_ReportViewerNew>();
        Rpt_Invoice_Details_list.Clear();

        StringBuilder sb = new StringBuilder();
        string indjobstring = "";
        DataSet dss = new DataSet();
        DataSet dssAss = new DataSet();
        //ddlJobNo = Request.QueryString["jobno"].ToString();
        //ddlJobNo = ddlJob_No.SelectedValue.ToString();
        //Session["JobNo"] = ddlJobNo;
        //ds = (DataSet)HttpContext.Current.Session["EXPORT_CHECKLIST"];

        DataSet ds = new DataSet();
        ObjUBO.A2 = Request.QueryString["jobno"].ToString();
        ObjUBO.A10 = "DTA_All_Checklist";
        ds = DTA.DTA_Data_Select(ObjUBO);


        sb.Append("<html><table width='100%' style='vertical-align:top; font-family:Verdana ;font-size:9px; ' cellpadding='0' cellspacing='0'>");
        sb.Append("<tr style='text-align:center; font-weight:bold; font-size:12px'><td colspan='10'> " + Connection.Get_EXP_CHA_NAME().Replace("amp;", "") + " </td></tr>");
        sb.Append("<tr style='text-align:center; font-weight:bold; font-size:11px'><td colspan='10'>EXPORT DTA - CHECKLIST</td></tr>");
        sb.Append("<tr><td colspan='10'>======================================================================================================</td></tr>"); // for font size =9
        sb.Append("<tr><td2FWB@123>Job No</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["JOBNO"] + "</td><td2FWB@123>Job Date</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["JOBDATE"] + "</td></tr>");
        sb.Append("<tr><td colspan='10'>-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>"); // for font size =9

        sb.Append("<tr style='text-align:left; font-weight:bold; font-size:9px'>   <td colspan='10'></td></tr>");
        sb.Append("<tr style='text-align:left; font-weight:bold; font-size:9px'><td colspan='10'>General Details</td></tr>");
       // sb.Append("<tr style='text-align:left; font-weight:bold; font-size:9px'><td colspan='10'>================</td></tr>");
        sb.Append("<tr><td colspan='10'>======================================================================================================</td></tr>"); // for font size =9


        sb.Append("<tr><td2FWB@123>Sez Unit Code</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["SEZ_UNIT_CODE"] + "</td><td2FWB@123>Sez Unit Name</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["SEZ_UNIT_NAME"] + "</td></tr>");
        sb.Append("<tr><td2FWB@123>Sez Unit Address</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["SEZ_UNIT_ADDRESS"] + "</td><td2FWB@123>Sez City</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["SEZ_UNIT_CITY"] + "</td></tr>");
        sb.Append("<tr><td2FWB@123>Sez State</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["SEZ_UNIT_STATE"] + "</td><td2FWB@123>Sez Pin Code</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["SEZ_UNIT_PINCODE"] + "</td></tr>");
        sb.Append("<tr><td2FWB@123>IEC Code</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["SEZ_UNIT_IEC"] + "</td><td2FWB@123>Sez GSTIN</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["SEZ_UNIT_GSTIN"] + "</td></tr>");


        sb.Append("<tr style='text-align:left; font-weight:bold; font-size:9px'>   <td colspan='10'></td></tr>");
        sb.Append("<tr style='text-align:left; font-weight:bold; font-size:9px'><td colspan='10'> -</td></tr>");

        sb.Append("<tr style='text-align:left; font-weight:bold; font-size:9px'><td colspan='10'>DTA Unit Details</td></tr>");
        //sb.Append("<tr style='text-align:left; font-weight:bold; font-size:9px'><td colspan='10'>================</td></tr>");
        sb.Append("<tr><td colspan='10'>======================================================================================================</td></tr>"); // for font size =9

        sb.Append("<tr><td2FWB@123>DTA Unit GSTIN</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["SEZ_UNIT_CODE"] + "</td><td2FWB@123>DTA Unit PAN</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["DTA_UNIT_PAN"] + "</td></tr>");
        sb.Append("<tr><td2FWB@123>DTA Unit Name</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["DTA_UNIT_NAME"] + "</td><td2FWB@123>DTA Unit Address</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["DTA_UNIT_ADDRESS"] + "</td></tr>");
        sb.Append("<tr><td2FWB@123>DTA Unit City</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["DTA_UNIT_CITY"] + "</td><td2FWB@123>DTA Unit State</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["DTA_UNIT_STATE"] + "</td></tr>");
        sb.Append("<tr><td2FWB@123>DTA Unit Pincode </td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["DTA_UNIT_PINCODE"] + "</td><td2FWB@123>DTA Unit IEC</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["DTA_UNIT_IEC_CODE"] + "</td></tr>");
        sb.Append("<tr><td2FWB@123>Type od DTA Unit</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["DTA_UNIT_TYPE"] + "</td><td2FWB@123></td><td3@CS><b>:</b> " + "" + "</td></tr>");

        sb.Append("<tr><td2FWB@123>Declaration od IGST </td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["IGST_DECLARATION"] + "</td><td2FWB@123>LUT No & Date</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["LUT_NUMBER"] + "  Dt: " + ds.Tables[0].Rows[0]["LUT_DATE"] + "</td></tr>");
        sb.Append("<tr><td colspan='10'>======================================================================================================</td></tr>"); // for font size =9

        sb.Append("<tr><td2FWB@123>ARE Details Y/N :  </td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["ARE_YN"] + "</td><td2FWB@123></td><td3@CS><b>:</b> " + "" + "</td></tr>");
        sb.Append("<tr><td2FWB@123>ARE Number</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["ARE_NUMBER"] + "</td><td2FWB@123>ARE Date</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["ARE_DATE"] + "</td></tr>");
        sb.Append("<tr><td2FWB@123>Range</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["ARE_RANGE"] + "</td><td2FWB@123>Division</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["ARE_DIVISION"] + "</td></tr>");
        sb.Append("<tr><td2FWB@123>Address</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["ARE_ADDRESS"] + "</td><td2FWB@123>Commissionerate</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["ARE_COMMISSIONERATE"] + "</td></tr>");
        sb.Append("<tr><td2FWB@123>ARE Duty Amt </td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["ARE_DUTY_AMOUNT"] + "</td><td2FWB@123>Additional Remarks</td><td3@CS><b>:</b> " + ds.Tables[0].Rows[0]["ADDL_REMARKS"] + "</td></tr>");

        sb.Append("<tr style='text-align:left; font-weight:bold; font-size:9px'><td colspan='8'>Are you availing facility of CENVAT Credit under CENVAT Credit Rules, 2001?</td><td2FWB@123>" + ds.Tables[0].Rows[0]["CENVAT_YN"] + "</td></tr>");
        sb.Append("<tr style='text-align:left; font-weight:bold; font-size:9px'><td colspan='8'>Are you availing facility under Notification 41/2001 - Central Excise (N.T) Dated 26th June, 2001?</td><td2FWB@123>" + ds.Tables[0].Rows[0]["CENTRAL_EXCISE_41"] + "</td></tr>");
        sb.Append("<tr style='text-align:left; font-weight:bold; font-size:9px'><td colspan='8'>Are you availing facility under Notification 43/2001 - Central Excise (N.T) Dated 26th June, 2001?/td><td2FWB@123>" + ds.Tables[0].Rows[0]["CENTRAL_EXCISE_43"] + "</td></tr>");



        //  ************  start of Invoice details  *****************//

        sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>"); // for font size =9
        sb.Append("<tr><td2FWB@123>INVOICE DETAILS</td><td8@CS>No Of Invoices : " + ds.Tables[1].Rows.Count + "</td></tr>");
        sb.Append("<tr><td colspan='10'>======================================================================================================</td></tr>"); // for font size =9


        for (int i = 0; i <= ds.Tables[1].Rows.Count - 1; i++)
        {
            sb.Append("<tr><td2FWB@123>Invoice No </td><td3@CS><b>:</b> " + ds.Tables[1].Rows[i]["INVOICE_NO"] + "</td><td2FWB@123>Invoice Date</td><td3@CS><b>:</b> " + ds.Tables[1].Rows[i]["INVOICE_DATE"] + "</td></tr>");
            sb.Append("<tr><td2FWB@123>Invoice Currency </td><td3@CS><b>:</b> " + ds.Tables[1].Rows[i]["INVOICE_CURRENCY"] + "</td><td2FWB@123>Invoice Ex.Rate</td><td3@CS><b>:</b> " + ds.Tables[1].Rows[i]["EXCHANGE_RATE"] + "</td></tr>");
            sb.Append("<tr><td2FWB@123>Nature Of Supply </td><td3@CS><b>:</b> " + ds.Tables[1].Rows[i]["INVOICE_VALUE"] + "</td><td2FWB@123>Nature Of Transaction</td><td3@CS><b>:</b> " + ds.Tables[1].Rows[i]["NATURE_OF_TRANSACTION"] + "</td></tr>");
            sb.Append("<tr><td2FWB@123>Invoice Value </td><td3@CS><b>:</b> " + ds.Tables[1].Rows[i]["NATURE_OF_SUPPLY"] + "</td><td2FWB@123>Invoice Value(INR)</td><td3@CS><b>:</b> " + ds.Tables[1].Rows[i]["INVOICE_VALUE_INR"] + "</td></tr>");
            sb.Append("<tr><td2FWB@123>IGST Amount </td><td3@CS><b>:</b> " + ds.Tables[1].Rows[i]["TOT_IGST_AMOUNT"] + "</td><td2FWB@123>Cess Amount</td><td3@CS><b>:</b> " + ds.Tables[1].Rows[i]["TOT_CESS_AMOUNT"] + "</td></tr>");
            sb.Append("<tr><td2FWB@123>Duty Amount as per ARE </td><td3@CS><b>:</b> " + ds.Tables[1].Rows[i]["DUTY_AMT_AS_PER_ARE"] + "</td><td2FWB@123></td><td3@CS><b></b> " + "" + "</td></tr>");
            sb.Append("<tr><td2FWB@123>Invoice IRN No </td><td3@CS><b>:</b> " + ds.Tables[1].Rows[i]["UNIQUE_DOC_NUMBER"] + "</td><td2FWB@123>Invoice IRN File Name</td><td3@CS><b>:</b> " + ds.Tables[1].Rows[i]["ICEGATE_DOC_FILE_NAME"] + "</td></tr>");

            string inv_slno = ds.Tables[1].Rows[i]["INVOICE_SLNO"].ToString();

            var FullName1 = from DataRow drr in ds.Tables[2].AsEnumerable()
                            where drr.Field<Int64>("INVOICE_SLNO") == Convert.ToInt64(inv_slno)
                            select drr;

            DataView dvv = FullName1.AsDataView();

            if (dvv.Count > 0)
            {
                DataTable dt_item = FullName1.CopyToDataTable();

                for (int x = 0; x <= dt_item.Rows.Count - 1; x++)
                {
                    sb.Append("<tr><td colspan='10'>-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr>"); // for font size =9

                    sb.Append("<tr><td2FWB@123>Item Sl No </td><td3@CS><b>:</b> " + dt_item.Rows[x]["ITEM_SLNO"] + "</td><td2FWB@123></td><td3@CS><b>:</b> " + "" + "</td></tr>");
                    sb.Append("<tr><td2FWB@123>ItemDescription </td><td colspan='8'><b>:</b> " + dt_item.Rows[x]["ITEM_DESCRIPTION"] + "</td></tr>");
                    sb.Append("<tr><td2FWB@123>Item Qty </td><td3@CS><b>:</b> " + dt_item.Rows[x]["ITEM_QTY"] + "</td><td2FWB@123>Qty Code</td><td3@CS><b>:</b> " + dt_item.Rows[x]["ITEM_QTY_CODE"] + "</td></tr>");
                    sb.Append("<tr><td2FWB@123>Unit Price </td><td3@CS><b>:</b> " + dt_item.Rows[x]["ITEM_UNIT_PRICE"] + "</td><td2FWB@123>PMV Value</td><td3@CS><b>:</b> " + dt_item.Rows[x]["ITEM_PMVVALUE"] + "</td></tr>");
                    sb.Append("<tr><td2FWB@123>HS Code </td><td3@CS><b>:</b> " + dt_item.Rows[x]["RITCNO"] + "</td><td2FWB@123>Item Accessories</td><td3@CS><b>:</b> " + dt_item.Rows[x]["ITEM_ACCESSORIES_DESC"] + "</td></tr>");
                    sb.Append("<tr><td2FWB@123>Product Value </td><td3@CS><b>:</b> " + dt_item.Rows[x]["ITEM_AMOUNT"] + "</td><td2FWB@123>Taxable Value</td><td3@CS><b>:</b> " + dt_item.Rows[x]["TAXABLE_VALUE"] + "</td></tr>");
                    sb.Append("<tr><td2FWB@123>Item Type </td><td3@CS><b>:</b> " + dt_item.Rows[x]["ITEM_TYPE"] + "</td><td2FWB@123>Amount of Rebate Claimed</td><td3@CS><b>:</b> " + dt_item.Rows[x]["REBATE_CLAIMED_AMOUNT"] + "</td></tr>");
                    sb.Append("<tr><td2FWB@123>IGST Notn No </td><td3@CS><b>:</b> " + dt_item.Rows[x]["IGST_NOTN_NO"] + "</td><td2FWB@123>IGST Notn Slno</td><td3@CS><b>:</b> " + dt_item.Rows[x]["IGST_NOTN_SLNO"] + "</td></tr>");
                    sb.Append("<tr><td2FWB@123>IGST Rate </td><td3@CS><b>:</b> " + dt_item.Rows[x]["IGST_RATE"] + "</td><td2FWB@123>IGST Amount</td><td3@CS><b>:</b> " + dt_item.Rows[x]["IGST_AMT"] + "</td></tr>");
                    sb.Append("<tr><td2FWB@123>Compensation Cess Notn No </td><td3@CS><b>:</b> " + dt_item.Rows[x]["COMPENSATION_CESS_NOTN"] + "</td><td2FWB@123>Compensation Cess Notn SlNo</td><td3@CS><b>:</b> " + dt_item.Rows[x]["COMPENSATION_CESS_NOTN_SLNO"] + "</td></tr>");
                    sb.Append("<tr><td2FWB@123>Cess Rate </td><td3@CS><b>:</b> " + dt_item.Rows[x]["CESS_RATE"] + "</td><td2FWB@123>Cess Amount</td><td3@CS><b>:</b> " + dt_item.Rows[x]["CESS_AMOUNT"] + "</td></tr>");

                }

            }
            sb.Append("<tr><td colspan='10'>======================================================================================================</td></tr>"); // for font size =9

        }



        sb.Append("</table></html>");


        HttpResponse Response = HttpContext.Current.Response;
        lbl.Text = sb.ToString().Replace("<tdFWB@123>", "<td style='font-weight:bold'>").Replace("<td2FWB@123>", "<td colspan='2' style='font-weight:bold'>").Replace("<td3FWB@123>", "<td colspan='3' style='font-weight:bold'>").Replace("<td4FWB@123>", "<td colspan='4' style='font-weight:bold'>").Replace("<td5FWB@123>", "<td colspan='5' style='font-weight:bold'>").Replace("<trFWB@123>", "<tr style='font-weight:bold'>").Replace("<td6FWB@123>", "<td colspan='6' style='font-weight:bold'>").Replace("<tdSAR@123>", "<td style='text-align:right'>").Replace("<td7FWB@123>", "<td colspan='7' style='font-weight:bold'>").Replace("<td8FWB@123>", "<td colspan='8' style='font-weight:bold'>").Replace("<td9FWB@123>", "<td colspan='9' style='font-weight:bold'>").Replace("<td10FWB@123>", "<td colspan='10' style='font-weight:bold'>").Replace("<td2@CS>", "<td colspan='2'>").Replace("<td3@CS>", "<td colspan='3'>").Replace("<td4@CS>", "<td colspan='4'>").Replace("<td5@CS>", "<td colspan='5'>").Replace("<td6@CS>", "<td colspan='6'>").Replace("<td7@CS>", "<td colspan='7'>").Replace("<td8@CS>", "<td colspan='8'>").Replace("<td9@CS>", "<td colspan='9'>").Replace("<td10@CS>", "<td colspan='10'>").Replace("<tr10br@123>", "<tr><td colspan='10'><br/></td></tr>").Replace("<td2SAR@123>", "<td colspan='2' style='text-align:right'>").Replace("<td7SAR@123>", "<td colspan='7' style='text-align:right'>");


        lbl.Text = lbl.Text.Replace("<html><table width='100%' style='vertical-align:top; font-family:Verdana ;font-size:9px; ' cellpadding='0' cellspacing='0'>", "<html><table width='100%' style='vertical-align:top; font-family:Verdana ;font-size:9px; line-height:8' cellpadding='0' cellspacing='0'>").Replace("style='line-height:0'", "style='line-height:4'");
        string Jobno = "5884";

        string filename = "ExpChecklist_" + Jobno + ".pdf";
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/pdf";
        //Response.AddHeader("content-disposition", "attachment;filename=" + filename + "");
        Response.AddHeader("content-disposition", "inline;filename=" + filename + "");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            lbl.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 40f, 10f, 5f, 5f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            //Response.End();
            Response.Flush();

        }
    }



    protected void btnpdf_Click(object sender, EventArgs e)
    {
        if (lbl.Text != "")
        {            
            //lbl.Text = lbl.Text.Replace("<html><table width='100%' style='vertical-align:top; font-family:Verdana ;font-size:9px; ' cellpadding='0' cellspacing='0'>", "<html><table width='100%' style='vertical-align:top; font-family:Courier New ;font-size:9px; line-height:8' cellpadding='0' cellspacing='0'>").Replace("style='line-height:0'", "style='line-height:4'");
            lbl.Text = lbl.Text.Replace("<html><table width='100%' style='vertical-align:top; font-family:Verdana ;font-size:9px; ' cellpadding='0' cellspacing='0'>", "<html><table width='100%' style='vertical-align:top; font-family:Verdana ;font-size:9px; line-height:8' cellpadding='0' cellspacing='0'>").Replace("style='line-height:0'", "style='line-height:4'");
            string jobno = ddlJob_No.SelectedValue.ToString();
            string filename = "ExpChecklist_" + jobno + ".pdf";
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=" + filename + "");
            //Response.AddHeader("content-disposition", "inline;filename=" + filename + "");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                lbl.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());  
                Document pdfDoc = new Document(PageSize.A4, 40f, 10f, 5f, 5f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();
                Response.Write(pdfDoc);
                Response.End();
            }
        }
        else
        {
            string prompt = "<script>$(document).ready(function(){{jAlert('No Records Found', 'Check List', function (r) {});}});</script>";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            //this.Page.ClientScript.RegisterClientScriptBlock(typeof(Alert), "alert", prompt);
            string pp="alert('your Message goes here')";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", pp, true);
        }

    }

  

    protected void btnprint_Click(object sender, EventArgs e)
    {
        if (lbl.Text != "")
        {
            byte[] bytes = Encoding.ASCII.GetBytes(lbl.Text);
            Session.Remove("report");
            Session["report"] = bytes;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "CallMyFunction", "Print_open()", true);
        }
    }

    private void jobno_load()
    {
        Export_CheckList chklist = new Export_CheckList();
        Working_Period = Session["WorkingPeriod"].ToString();

        chklist.JOBNo = "";
        chklist.Ename = "select_jobno";
        chklist.Workingperiod = SELECT_BRANCH;

        ddlJob_No.DataSource = chklist.RetrieveAll_General_Details();
        ddlJob_No.DataValueField = "JOBNO";
        ddlJob_No.DataTextField = "JOBNO_PS";
        ddlJob_No.DataBind();
        ddlJob_No.Items.Remove("0");
        ddlJob_No.Items.Insert(0, "Select");
    }

    protected void ddlJob_No_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlJob_No.SelectedItem.Text != "Select")
        {
         
          //  Response.Redirect("../Report/Export_ReportViewerNew.aspx?jobno=" + ddlJob_No.SelectedValue.ToString() + "&Annexure_Mode=" + Annexure_Mode + "&STR_Code=" + STR_Code + "&jobnops= " + ddlJob_No.SelectedItem.Text + "");
        }
    }

  

}