using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.Reporting.WebForms;
using Microsoft.ReportingServices.Rendering;
using Microsoft.ReportingServices.Library;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

using BussinessObject;
using System.IO;
using System.Text;

public partial class Export_PackingList_Rpt_Viewer : System.Web.UI.Page
{

    DataSet ds = new DataSet();

    public string ddlJobNo, SB_NO;

    AppSession aps = new AppSession();
    public int ii;


    public string _ID, _JOBNO, _EXPORTERNAME, _EXPORTER_ADDRESS1, _EXPORTER_ADDRESS2, _EXPORTER_ADDRESS3, _EXPORTER_ADDRESS4, _EXPORTER_ADDRESS5,
                  _CONSIGNEE_NAME, _CONSIGNEE_ADDRESS1, _CONSIGNEE_ADDRESS2, _CONSIGNEE_ADDRESS3, _CONSIGNEE_ADDRESS4, _BUYER_NAME,
                  _BUYER_ADDRESS1, _BUYER_ADDRESS2, _BUYER_ADDRESS3, _BUYER_ADDRESS4, _INVOICE_NO, _INVOICE_DATE, _EXPORTER_REF,
                  _BUYER_ORDER_NO, _BUYER_ORDER_DATE, _OTHER_REF, _COUNTRY_ORIGIN, _COUNTRY_FINAL_DEST, _NOTIFY, _PRE_CARRIER,
                  _VESSEL_FLIGHT, _PORT_DISCHAGE, _RECEIPT, _PORT_LOADING, _PORT_FINAL_DEST, _TERMS_OF_DELIVERY, _REMARKS,
                  _USERID, _LOGINDATE, _BRANCHCODE, _WORKINGPERIOD, _BRANCHCOMMON;



    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string ID { get { return _ID; } set { _ID = value; } }
    public string EXPORTERNAME { get { return _EXPORTERNAME; } set { _EXPORTERNAME = value; } }
    public string EXPORTER_ADDRESS1 { get { return _EXPORTER_ADDRESS1; } set { _EXPORTER_ADDRESS1 = value; } }
    public string EXPORTER_ADDRESS2 { get { return _EXPORTER_ADDRESS2; } set { _EXPORTER_ADDRESS2 = value; } }
    public string EXPORTER_ADDRESS3 { get { return _EXPORTER_ADDRESS3; } set { _EXPORTER_ADDRESS3 = value; } }
    public string EXPORTER_ADDRESS4 { get { return _EXPORTER_ADDRESS4; } set { _EXPORTER_ADDRESS4 = value; } }
    public string EXPORTER_ADDRESS5 { get { return _EXPORTER_ADDRESS5; } set { _EXPORTER_ADDRESS5 = value; } }

    public string CONSIGNEE_NAME { get { return _CONSIGNEE_NAME; } set { _CONSIGNEE_NAME = value; } }
    public string CONSIGNEE_ADDRESS1 { get { return _CONSIGNEE_ADDRESS1; } set { _CONSIGNEE_ADDRESS1 = value; } }
    public string CONSIGNEE_ADDRESS2 { get { return _CONSIGNEE_ADDRESS2; } set { _CONSIGNEE_ADDRESS2 = value; } }
    public string CONSIGNEE_ADDRESS3 { get { return _CONSIGNEE_ADDRESS3; } set { _CONSIGNEE_ADDRESS3 = value; } }
    public string CONSIGNEE_ADDRESS4 { get { return _CONSIGNEE_ADDRESS4; } set { _CONSIGNEE_ADDRESS4 = value; } }

    public string BUYER_NAME { get { return _BUYER_NAME; } set { _BUYER_NAME = value; } }
    public string BUYER_ADDRESS1 { get { return _BUYER_ADDRESS1; } set { _BUYER_ADDRESS1 = value; } }
    public string BUYER_ADDRESS2 { get { return _BUYER_ADDRESS2; } set { _BUYER_ADDRESS2 = value; } }
    public string BUYER_ADDRESS3 { get { return _BUYER_ADDRESS3; } set { _BUYER_ADDRESS3 = value; } }
    public string BUYER_ADDRESS4 { get { return _BUYER_ADDRESS4; } set { _BUYER_ADDRESS4 = value; } }

    public string INVOICE_NO { get { return _INVOICE_NO; } set { _INVOICE_NO = value; } }
    public string INVOICE_DATE { get { return _INVOICE_DATE; } set { _INVOICE_DATE = value; } }
    public string EXPORTER_REF { get { return _EXPORTER_REF; } set { _EXPORTER_REF = value; } }
    public string BUYER_ORDER_NO { get { return _BUYER_ORDER_NO; } set { _BUYER_ORDER_NO = value; } }
    public string BUYER_ORDER_DATE { get { return _BUYER_ORDER_DATE; } set { _BUYER_ORDER_DATE = value; } }

    public string OTHER_REF { get { return _OTHER_REF; } set { _OTHER_REF = value; } }
    public string COUNTRY_ORIGIN { get { return _COUNTRY_ORIGIN; } set { _COUNTRY_ORIGIN = value; } }
    public string COUNTRY_FINAL_DEST { get { return _COUNTRY_FINAL_DEST; } set { _COUNTRY_FINAL_DEST = value; } }
    public string NOTIFY { get { return _NOTIFY; } set { _NOTIFY = value; } }
    public string PRE_CARRIER { get { return _PRE_CARRIER; } set { _PRE_CARRIER = value; } }


    public string VESSEL_FLIGHT { get { return _VESSEL_FLIGHT; } set { _VESSEL_FLIGHT = value; } }
    public string PORT_DISCHAGE { get { return _PORT_DISCHAGE; } set { _PORT_DISCHAGE = value; } }
    public string RECEIPT { get { return _RECEIPT; } set { _RECEIPT = value; } }
    public string PORT_LOADING { get { return _PORT_LOADING; } set { _PORT_LOADING = value; } }
    public string PORT_FINAL_DEST { get { return _PORT_FINAL_DEST; } set { _PORT_FINAL_DEST = value; } }
    public string TERMS_OF_DELIVERY { get { return _TERMS_OF_DELIVERY; } set { _TERMS_OF_DELIVERY = value; } }
    public string REMARKS { get { return _REMARKS; } set { _REMARKS = value; } }

    public string _MarksNos, _Description, _Quantity, _GrossWeight, _No_Of_Package, _ITEM_SLNO;

    public string MarksNos { get { return _MarksNos; } set { _MarksNos = value; } }
    public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }
    public string Description { get { return _Description; } set { _Description = value; } }
    public string Quantity { get { return _Quantity; } set { _Quantity = value; } }
    public string GrossWeight { get { return _GrossWeight; } set { _GrossWeight = value; } }
    public string No_Of_Package { get { return _No_Of_Package; } set { _No_Of_Package = value; } }
   

    List<Export_PackingList_Rpt_Viewer> Export_PackingList_Rpt = new List<Export_PackingList_Rpt_Viewer>();
    List<Ex_PackingList> PackingList = new List<Ex_PackingList>();
    Ex_PackingList PL = new Ex_PackingList();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();

        if (!IsPostBack)
        {
            try
            {
                if (Request.QueryString["jobno"] == "" || Request.QueryString["jobno"] == null)
                {

                }
                else
                {
                    ddlJobNo = Request.QueryString["jobno"].ToString();
                    Session["JobNo"] = ddlJobNo;

                    List<ReportParameter> paramList = new List<ReportParameter>(); this.ReportViewer1.LocalReport.SetParameters(paramList);
                    ReportViewer1.LocalReport.DataSources.Clear();

                    PackingList_Report();
                    Grid_Item_Details();

                    //--------------------------------------To Print------------------------------------------------------------------------------------//
                    Warning[] warnings;
                    string[] streamIds;
                    string mimeType = string.Empty;
                    string encoding = string.Empty;
                    string extension = string.Empty;
                    byte[] bytes = ReportViewer1.LocalReport.Render("pdf", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                    Session.Remove("report");
                    Session["report"] = bytes;
                    //--------------------------------------To Print------------------------------------------------------------------------------------//
                }
            }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
            }
        }
    }

    public void PackingList_Report()
    {
        Get_PackingList_Report();
        ReportDataSource dataSource1 = new ReportDataSource("Export_Packing_Lists_DataSet", ds.Tables[0]);
        ReportViewer1.LocalReport.DataSources.Add(dataSource1);

    }
    public void Grid_PackingList_report()
    {
        get_Grid_Data(ds.Tables[0]);
        ReportDataSource dataSource1 = new ReportDataSource("Export_Packing_Lists_DataSet", Export_PackingList_Rpt);
        ReportViewer1.LocalReport.DataSources.Add(dataSource1);
    }

    public void get_Grid_Data(DataTable dt)
    {
        try
        {
            PL.JOBNO = ddlJobNo;
            PL.Ename = "Report_Grid";
            ds = PL.Grid_PackingList_Bind_DS();

            if (dt.Rows.Count > ii)
            {
                DataRow row = dt.Rows[ii];

                PackingList.Add(new Ex_PackingList()
                {
                    MarksNos = MarksNos,
                    ITEM_SLNO = ITEM_SLNO,
                    Description = Description,
                    Quantity = Quantity,
                    GrossWeight = GrossWeight,
                    No_Of_Package = No_Of_Package

                });
            }
            ii++;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public void Get_PackingList_Report()
    {
        try
        {

            PL.JOBNO = ddlJobNo;
            PL.Ename = "Report_Packing_List";
            ds = PL.Grid_PackingList_Bind_DS();

            if (ds.Tables[0].Rows.Count > 0)
            {

                EXPORTERNAME = ds.Tables[0].Rows[0]["EXPORTERNAME"].ToString();
                EXPORTER_ADDRESS1 = ds.Tables[0].Rows[0]["EXPORTER_ADDRESS1"].ToString();
                EXPORTER_ADDRESS2 = ds.Tables[0].Rows[0]["EXPORTER_ADDRESS2"].ToString();
                EXPORTER_ADDRESS3 = ds.Tables[0].Rows[0]["EXPORTER_ADDRESS3"].ToString();
                EXPORTER_ADDRESS4 = ds.Tables[0].Rows[0]["EXPORTER_ADDRESS4"].ToString();


                CONSIGNEE_NAME = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
                CONSIGNEE_ADDRESS1 = ds.Tables[0].Rows[0]["CONSIGNEE_ADDRESS1"].ToString();
                CONSIGNEE_ADDRESS2 = ds.Tables[0].Rows[0]["CONSIGNEE_ADDRESS2"].ToString();
                CONSIGNEE_ADDRESS3 = ds.Tables[0].Rows[0]["CONSIGNEE_ADDRESS3"].ToString();
                CONSIGNEE_ADDRESS4 = ds.Tables[0].Rows[0]["CONSIGNEE_ADDRESS4"].ToString();


                BUYER_NAME = ds.Tables[0].Rows[0]["BUYER_NAME"].ToString();
                BUYER_ADDRESS1 = ds.Tables[0].Rows[0]["BUYER_ADDRESS1"].ToString();
                BUYER_ADDRESS2 = ds.Tables[0].Rows[0]["BUYER_ADDRESS2"].ToString();
                BUYER_ADDRESS3 = ds.Tables[0].Rows[0]["BUYER_ADDRESS3"].ToString();
                BUYER_ADDRESS4 = ds.Tables[0].Rows[0]["BUYER_ADDRESS4"].ToString();

                INVOICE_NO = ds.Tables[0].Rows[0]["INVOICE_NO"].ToString();
                INVOICE_DATE = ds.Tables[0].Rows[0]["INVOICE_DATE"].ToString();
                EXPORTER_REF = ds.Tables[0].Rows[0]["EXPORTER_REF"].ToString();
                BUYER_ORDER_NO = ds.Tables[0].Rows[0]["BUYER_ORDER_NO"].ToString();
                BUYER_ORDER_DATE = ds.Tables[0].Rows[0]["BUYER_ORDER_DATE"].ToString();
                OTHER_REF = ds.Tables[0].Rows[0]["OTHER_REF"].ToString();
                COUNTRY_ORIGIN = ds.Tables[0].Rows[0]["COUNTRY_ORIGIN"].ToString();
                COUNTRY_FINAL_DEST = ds.Tables[0].Rows[0]["COUNTRY_FINAL_DEST"].ToString();
                NOTIFY = ds.Tables[0].Rows[0]["NOTIFY"].ToString();


                PRE_CARRIER = ds.Tables[0].Rows[0]["PRE_CARRIER"].ToString();
                VESSEL_FLIGHT = ds.Tables[0].Rows[0]["VESSEL_FLIGHT"].ToString();
                PORT_DISCHAGE = ds.Tables[0].Rows[0]["PORT_DISCHAGE"].ToString();
                RECEIPT = ds.Tables[0].Rows[0]["RECEIPT"].ToString();
                PORT_LOADING = ds.Tables[0].Rows[0]["PORT_LOADING"].ToString();
                PORT_FINAL_DEST = ds.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString();
                TERMS_OF_DELIVERY = ds.Tables[0].Rows[0]["TERMS_OF_DELIVERY"].ToString();
                REMARKS = ds.Tables[0].Rows[0]["REMARKS"].ToString();
            }
            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public void Grid_Item_Details()
    {
        ReportViewer1.LocalReport.SubreportProcessing += new Microsoft.Reporting.WebForms.SubreportProcessingEventHandler(ReportViewer1_SubreportProcessing);
    }

    protected void ReportViewer1_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
    {
        get_Grid_Data(ds.Tables[0]);
        ReportDataSource dataSource = new ReportDataSource("Grid_PackingList_DataSet", PL.Load_Grid_packinglist(ds.Tables[0]));
        e.DataSources.Add(dataSource);

    }
}