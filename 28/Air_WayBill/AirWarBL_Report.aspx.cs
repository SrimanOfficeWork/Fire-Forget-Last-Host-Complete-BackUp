using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Data.SqlClient;



using System.IO;
using Microsoft.ApplicationBlocks.Data;
using System.Web.UI.WebControls.WebParts;
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Microsoft.Reporting.WebForms;
using BussinessObject;

public partial class AirWarBL_Report : System.Web.UI.Page
{

    DataSet ds = new DataSet();
    public string currentuser, ddlJobNo;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string SELECT_TYPE, SELECT_BRANCH;

    AppSession aps = new AppSession();
    UserBO ObjUBO = new UserBO();
    AWB_Export_CS AWB_EXP = new AWB_Export_CS();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();
        currentbranch = Session["currentbranch"].ToString();

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

        if (!IsPostBack)
        {
            try
            {
                if (Request.QueryString["jobno"] == "" || Request.QueryString["jobno"] == null)
                {
                    RDRpt.SelectedValue = "Single";
                    //Decl_I();
                }
                else
                {
                    RDRpt.SelectedValue = "Single";
                    Decl_I();
                }
            }
            catch (Exception ex)
            {
                ErrorLogs er = new ErrorLogs();
                er.makeLog
                    (ex.Message);
            }
        }
    }

    private void Decl_I()
    {

        ObjUBO.JOBNO = Request.QueryString["jobno"].ToString();
        ObjUBO.BRANCH_COMMON = Connection.Get_Company_Type();
        ObjUBO.ITEM_EXPORTER_NAME = "";
        ObjUBO.flag = "AWB_Exp_Report_Search";
        ds = AWB_EXP.AWB_EXPORT_INV_SELECT(ObjUBO);

        LocalReport localReport = ReportViewer1.LocalReport;
        localReport.ReportPath = @"Air_WayBill\AirWayBillReport_Multiple.rdlc";

        List<ReportParameter> paramList = new List<ReportParameter>();
        this.ReportViewer1.LocalReport.SetParameters(paramList);
        ReportViewer1.LocalReport.DataSources.Clear();

        ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "Print_open();", true);

        DataTable dt = new DataTable();
        dt.Columns.Add("Details");

        if (RDRpt.SelectedItem.Text == "Single")
        {
            dt.Rows.Add("");
        }
        else if (RDRpt.SelectedItem.Text == "Multiple")
        {

            dt.Rows.Add("ORIGINAL 3 ( FOR SHIPPER )");
            dt.Rows.Add("COPY 8 ( FOR AGENT )");
            dt.Rows.Add("ORIGINAL 1 ( FOR ISSUING CARRIER )");
            dt.Rows.Add("ORIGINAL 2 ( FOR CONSIGNEE )");
            dt.Rows.Add("COPY 4 ( DELIVERY RECEIPT )");
            dt.Rows.Add("COPY 5 ( EXTRA COPY )");
            dt.Rows.Add("COPY 6 ( EXTRA COPY )");
            dt.Rows.Add("COPY 7 ( EXTRA COPY )");
        }


        ReportDataSource datasource = new ReportDataSource("AirWayDataSet", dt);
        ReportViewer1.LocalReport.DataSources.Add(datasource);

        ReportParameter S1 = new ReportParameter("ShipperName", ds.Tables[0].Rows[0]["SHIPPER_NAME"].ToString());
        ReportParameter S2 = new ReportParameter("ShipperAdd1", ds.Tables[0].Rows[0]["SHIPPER_ADD_1"].ToString());
        ReportParameter S3 = new ReportParameter("ShipperAdd2", ds.Tables[0].Rows[0]["SHIPPER_ADD_2"].ToString());
        ReportParameter S4 = new ReportParameter("ShipperAdd3", ds.Tables[0].Rows[0]["SHIPPER_ADD_3"].ToString());
        ReportParameter S5 = new ReportParameter("ShipperAdd4", ds.Tables[0].Rows[0]["SHIPPER_ADD_4"].ToString());
        ReportParameter S6 = new ReportParameter("SHIPPER_ACNO", ds.Tables[0].Rows[0]["SHIPPER_ACNO"].ToString());

        ReportParameter C1 = new ReportParameter("CONSIGNEE_NAME", ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString());
        ReportParameter C2 = new ReportParameter("CONSIGNEE_ADD_1", ds.Tables[0].Rows[0]["CONSIGNEE_ADD_1"].ToString());
        ReportParameter C3 = new ReportParameter("CONSIGNEE_ADD_2", ds.Tables[0].Rows[0]["CONSIGNEE_ADD_2"].ToString());
        //ReportParameter C4 = new ReportParameter("CONSIGNEE_ADD_3", ds.Tables[0].Rows[0]["CONSIGNEE_ADD_3"].ToString());

        string Consignee_Add3 = "";
        if (ds.Tables[0].Rows[0]["CONSIGNEE_ADD_3"].ToString() == "")
        {
            Consignee_Add3 = " ";
        }
        else
        {
            Consignee_Add3 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD_3"].ToString();
        }
        ReportParameter C4 = new ReportParameter("CONSIGNEE_ADD_3", Consignee_Add3);
        ReportParameter C5 = new ReportParameter("CONSIGNEE_ADD_4", ds.Tables[0].Rows[0]["CONSIGNEE_ADD_4"].ToString());
        ReportParameter C6 = new ReportParameter("CONSIGNEE_ACNO", ds.Tables[0].Rows[0]["CONSIGNEE_ACNO"].ToString());

        string CusHouse = Session["CUSTOMHOUSE_CODE"].ToString().Substring(2, 3);
        ReportParameter CusHouse1 = new ReportParameter("CusHouse", CusHouse);

        ReportParameter job = new ReportParameter("JOBNO", ds.Tables[0].Rows[0]["JOBNO"].ToString());
        ReportParameter AWB = new ReportParameter("AWB_INV_NO", ds.Tables[0].Rows[0]["MASTER_AWB_NO_1"].ToString() + " " + ds.Tables[0].Rows[0]["MASTER_AWB_NO_2"].ToString());
        string AWB_HAWB1 = "";
        if (ds.Tables[0].Rows[0]["AWB_TYPE"].ToString() == "M")
        {
            AWB_HAWB1 = ds.Tables[0].Rows[0]["MASTER_AWB_NO_1"].ToString() + " " + ds.Tables[0].Rows[0]["MASTER_AWB_NO_2"].ToString();
        }
        else
        {
            AWB_HAWB1 = "HAWB NO: " +  ds.Tables[0].Rows[0]["HOUSE_AWB_NO"].ToString();
        }

        ReportParameter AWB_HAWB = new ReportParameter("AWB_HAWB", AWB_HAWB1);

        ReportParameter A1 = new ReportParameter("AGENT_NAME", ds.Tables[0].Rows[0]["AGENT_NAME"].ToString().Trim());
        ReportParameter A2 = new ReportParameter("AGENT_CITY", ds.Tables[0].Rows[0]["AGENT_CITY"].ToString().Trim());
        ReportParameter A3 = new ReportParameter("AGENT_IATA_CODE", ds.Tables[0].Rows[0]["AGENT_IATA_CODE"].ToString().Trim());
        ReportParameter A4 = new ReportParameter("AGENT_ACNO", ds.Tables[0].Rows[0]["AGENT_ACNO"].ToString().Trim());
        ReportParameter A5 = new ReportParameter("AGENT_AC_INFO", ds.Tables[0].Rows[0]["AGENT_AC_INFO"].ToString().Trim());
        ReportParameter A6 = new ReportParameter("AIRPORT_DEPATURE_REQ_ROUTING", ds.Tables[0].Rows[0]["AIRPORT_DEPATURE_REQ_ROUTING"].ToString().Trim());
        ReportParameter A7 = new ReportParameter("AIRPORT_DESTINATION", ds.Tables[0].Rows[0]["AIRPORT_DESTINATION"].ToString().Trim());

        ReportParameter F1 = new ReportParameter("FLIGHT_NO", ds.Tables[0].Rows[0]["FLIGHT_NO"].ToString().Trim());
        ReportParameter F2 = new ReportParameter("FLIGHT_DATE", ds.Tables[0].Rows[0]["FLIGHT_DATE"].ToString().Trim().Replace("01/01/1900",""));
        ReportParameter F3 = new ReportParameter("AMT_OF_INSURANCE", ds.Tables[0].Rows[0]["AMT_OF_INSURANCE"].ToString().Trim());
        ReportParameter F4 = new ReportParameter("DV_FOR_CARRIAGE", ds.Tables[0].Rows[0]["DV_FOR_CARRIAGE"].ToString().Trim());
        ReportParameter F5 = new ReportParameter("DV_FOR_CUSTOMS", ds.Tables[0].Rows[0]["DV_FOR_CUSTOMS"].ToString().Trim());

        ReportParameter B1 = new ReportParameter("HANDLING_INFO", ds.Tables[0].Rows[0]["HANDLING_INFO"].ToString().Trim());
        ReportParameter B2 = new ReportParameter("ISSUED_BY", ds.Tables[0].Rows[0]["ISSUED_BY"].ToString().Trim());
        ReportParameter B3 = new ReportParameter("R_D_TO_1", ds.Tables[0].Rows[0]["R_D_TO_1"].ToString().Trim());
        ReportParameter B4 = new ReportParameter("R_D_BY_1", ds.Tables[0].Rows[0]["R_D_BY_1"].ToString().Trim());
        ReportParameter B5 = new ReportParameter("R_D_TO_2", ds.Tables[0].Rows[0]["R_D_TO_2"].ToString().Trim());
        ReportParameter B6 = new ReportParameter("R_D_BY_2", ds.Tables[0].Rows[0]["R_D_BY_2"].ToString().Trim());
        ReportParameter B7 = new ReportParameter("R_D_TO_3", ds.Tables[0].Rows[0]["R_D_TO_3"].ToString().Trim());
        ReportParameter B8 = new ReportParameter("R_D_BY_3", ds.Tables[0].Rows[0]["R_D_BY_3"].ToString().Trim());
        ReportParameter B9 = new ReportParameter("CURRENCY", ds.Tables[0].Rows[0]["CURRENCY"].ToString().Trim());
        ReportParameter B10 = new ReportParameter("CHGS_CODE", ds.Tables[0].Rows[0]["CHGS_CODE"].ToString().Trim());
        ReportParameter B11 = new ReportParameter("WT_VAL", ds.Tables[0].Rows[0]["WT_VAL"].ToString().Trim());
        ReportParameter B12 = new ReportParameter("OTHER", ds.Tables[0].Rows[0]["OTHER"].ToString().Trim());

        ReportParameter D1 = new ReportParameter("PP_WGT_CHARGE", ds.Tables[0].Rows[0]["PP_WGT_CHARGE"].ToString().Trim());
        ReportParameter D2 = new ReportParameter("CC_WGT_CHARGE", ds.Tables[0].Rows[0]["CC_WGT_CHARGE"].ToString().Trim());
        ReportParameter D3 = new ReportParameter("PP_VALUATION_CHARGE", ds.Tables[0].Rows[0]["PP_VALUATION_CHARGE"].ToString().Trim());
        ReportParameter D4 = new ReportParameter("CC_VALUATION_CHARGE", ds.Tables[0].Rows[0]["CC_VALUATION_CHARGE"].ToString().Trim());
        ReportParameter D5 = new ReportParameter("PP_TAX", ds.Tables[0].Rows[0]["PP_TAX"].ToString().Trim());
        ReportParameter D6 = new ReportParameter("CC_TAX", ds.Tables[0].Rows[0]["CC_TAX"].ToString().Trim());
        ReportParameter D7 = new ReportParameter("PP_TOTAL_OTH_CH_DUE_AGENT", ds.Tables[0].Rows[0]["PP_TOTAL_OTH_CH_DUE_AGENT"].ToString().Trim());
        ReportParameter D8 = new ReportParameter("CC_TOTAL_OTH_CH_DUE_AGENT", ds.Tables[0].Rows[0]["CC_TOTAL_OTH_CH_DUE_AGENT"].ToString().Trim());
        ReportParameter D9 = new ReportParameter("PP_TOTAL_OTH_CH_DUE_CARRIER", ds.Tables[0].Rows[0]["PP_TOTAL_OTH_CH_DUE_CARRIER"].ToString().Trim());
        ReportParameter D10 = new ReportParameter("CC_TOTAL_OTH_CH_DUE_CARRIER", ds.Tables[0].Rows[0]["CC_TOTAL_OTH_CH_DUE_CARRIER"].ToString().Trim());
        ReportParameter D11 = new ReportParameter("PP_TOTAL", ds.Tables[0].Rows[0]["PP_TOTAL"].ToString().Trim());
        ReportParameter D12 = new ReportParameter("CC_TOTAL", ds.Tables[0].Rows[0]["CC_TOTAL"].ToString().Trim());
        ReportParameter D13 = new ReportParameter("CH_NO_OF_PIECES_RCP", ds.Tables[0].Rows[0]["CH_NO_OF_PIECES_RCP"].ToString());
        ReportParameter D14 = new ReportParameter("CH_GROSS_WGT", ds.Tables[0].Rows[0]["CH_GROSS_WGT"].ToString().Trim());
        ReportParameter D15 = new ReportParameter("CH_TOTAL", ds.Tables[0].Rows[0]["CH_TOTAL"].ToString().Trim());


        ReportParameter E1 = new ReportParameter("NOTIFY", ds.Tables[0].Rows[0]["NOTIFY"].ToString().Trim());
        ReportParameter E2 = new ReportParameter("OTHER_CHARGES", ds.Tables[0].Rows[0]["OTHER_CHARGES"].ToString().Trim());
        ReportParameter E3 = new ReportParameter("SIGN_OF_SHIPPER", ds.Tables[0].Rows[0]["SIGN_OF_SHIPPER"].ToString().Trim());
        string Executed = ds.Tables[0].Rows[0]["EXECUTED_ON"].ToString() + "    " + ds.Tables[0].Rows[0]["PLACE_AT"].ToString() + "    " + ds.Tables[0].Rows[0]["SIGN_OF_ISS_CARRIER"].ToString();
        ReportParameter E4 = new ReportParameter("EXECUTED_ON", Executed.Trim());
        ReportParameter E7 = new ReportParameter("TOTAL_COLLECT_CHARGES", ds.Tables[0].Rows[0]["TOTAL_COLLECT_CHARGES"].ToString().Trim());
        
        string NO_OF_PIECES_RCP = "";
        string GROSS_WGT = "";
        string KG_LB = "";
        string RATE_CLASS = "";
        string COMMODITY_ITEM_NO = "";
        string CHARGEABLE_WGT = "";
        string RATE_CHARGE = "";
        string TOTAL = "";
        string NATURE_QTY_OF_GOOD = "";


        if (ds.Tables[1].Rows.Count > 0)
        {
            for (int i = 0; i <= ds.Tables[1].Rows.Count - 1; i++)
            {
                string NO_OF_PIECES_RCP1 = ds.Tables[1].Rows[i]["NO_OF_PIECES_RCP"].ToString().Trim();
                string GROSS_WGT1 = ds.Tables[1].Rows[i]["GROSS_WGT"].ToString().Trim();
                string KG_LB1 = ds.Tables[1].Rows[i]["KG_LB"].ToString().Trim();
                string RATE_CLASS1 = ds.Tables[1].Rows[i]["RATE_CLASS"].ToString().Trim();
                string COMMODITY_ITEM_NO1 = ds.Tables[1].Rows[i]["COMMODITY_ITEM_NO"].ToString().Trim();
                string CHARGEABLE_WGT1 = ds.Tables[1].Rows[i]["CHARGEABLE_WGT"].ToString().Trim();
                string RATE_CHARGE1 = ds.Tables[1].Rows[i]["RATE_CHARGE"].ToString().Trim();
                string TOTAL1 = ds.Tables[1].Rows[i]["TOTAL"].ToString().Trim();
                string NATURE_QTY_OF_GOOD1 = ds.Tables[1].Rows[i]["NATURE_QTY_OF_GOOD"].ToString().Trim();

             NO_OF_PIECES_RCP += NO_OF_PIECES_RCP1+Environment.NewLine;
             GROSS_WGT += GROSS_WGT1 + Environment.NewLine;
             KG_LB += KG_LB1 + Environment.NewLine;
             RATE_CLASS += RATE_CLASS1 + Environment.NewLine;
             COMMODITY_ITEM_NO += COMMODITY_ITEM_NO1 + Environment.NewLine;
             CHARGEABLE_WGT += CHARGEABLE_WGT1 + Environment.NewLine;
             RATE_CHARGE += RATE_CHARGE1 + Environment.NewLine;
             TOTAL += TOTAL1 + Environment.NewLine;
             NATURE_QTY_OF_GOOD += NATURE_QTY_OF_GOOD1 + Environment.NewLine;

            }
        }

        ReportParameter G1 = new ReportParameter("NO_OF_PIECES_RCP", NO_OF_PIECES_RCP);
        ReportParameter G2 = new ReportParameter("GROSS_WGT", GROSS_WGT);
        ReportParameter G3 = new ReportParameter("KG_LB", KG_LB);
        ReportParameter G4 = new ReportParameter("RATE_CLASS", RATE_CLASS);
        ReportParameter G5 = new ReportParameter("COMMODITY_ITEM_NO", COMMODITY_ITEM_NO);
        ReportParameter G6 = new ReportParameter("CHARGEABLE_WGT", CHARGEABLE_WGT);
        ReportParameter G7 = new ReportParameter("RATE_CHARGE", RATE_CHARGE);
        ReportParameter G8 = new ReportParameter("TOTAL", TOTAL);
        ReportParameter G9 = new ReportParameter("NATURE_QTY_OF_GOOD", NATURE_QTY_OF_GOOD);

        ReportParameter[] p = { S1, S2, S3, S4, S5, S6, C1, C2, C3, C4, C5, C6, job, AWB, A1, A2, A3, A4, A5, A6, A7, F1, F2, F3, F4, F5, B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, B11, B12, D1, D2, D3, D4, D5, D6, D7, D8, D9, D10, D11, D12, D13, D14, D15, E1, E2, E3, E4, E7, G1, G2, G3, G4, G5, G6, G7, G8, G9, CusHouse1, AWB_HAWB };
        ReportViewer1.LocalReport.SetParameters(p);
       

        Warning[] warnings;
        string[] streamIds;
        string mimeType = string.Empty;
        string encoding = string.Empty;
        string extension = string.Empty;

        byte[] bytes = ReportViewer1.LocalReport.Render("pdf", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
        Session.Remove("report");
        Session["report"] = bytes;

    }


    protected void RDRpt_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RDRpt.SelectedItem.Text == "Single")
        {
            Decl_I();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "Print_open();", true);
        }
        else if (RDRpt.SelectedItem.Text == "Multiple")
        {
            Decl_I();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "Print_open();", true);
        }
      
    }
}