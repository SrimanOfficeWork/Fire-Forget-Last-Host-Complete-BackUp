using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Data.SqlClient;

using System.IO;
using Microsoft.ApplicationBlocks.Data;
using System.ComponentModel;
using System.Drawing.Printing;
//using System.Drawing.Printing;

using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Web.UI.WebControls.WebParts;
//using ReportViewerLib;
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Reporting.WebForms;
using AjaxControlToolkit;
using Microsoft.ReportingServices.Rendering;
using Microsoft.ReportingServices.Library;




public partial class TransShip_Permit_Rpt_viewer : System.Web.UI.Page
{

    # region Private Attributes

    private string _ID, _JOBNO;
    private string _EXPORTERNAME, _EXPORTER_ADDRESS1, _EXPORTER_ADDRESS2, _EXPORTER_ADDRESS3, _EXPORTER_ADDRESS4, _EXPORTER_ADDRESS5;
    private string _CONSIGNEE_NAME, _CONSIGNEE_ADDRESS1, _CONSIGNEE_ADDRESS2, _CONSIGNEE_ADDRESS3, _CONSIGNEE_ADDRESS4, _CONSIGNEE_ADDRESS5;
    private string _PORT_LOADING, _PORT_FINAL_DEST, _ITEM_DESC, _COMMISSIONER_CUSTOMS, _TRANSHIPED_FROM;
    private string _TP_BOONDNO, _TP_BOOND_DATE, _VESSEL_NO, _VESSEL_DATE, _IGM_NO, _IGM_DATE, _INVOICE_NO, _INVOICE_DATE, _MAWBNO, _MAWB_DATE, _HAWBNO, _HAWB_DATE;
    private string _NO_OF_PKGS, _NO_OF_PKGS_UNIT, _WEIGHT1, _WEIGHT_UNIT, _EXRATE, _CURRENCY, _INVOICE_VALUE, _CIF, _L_CHARGES, _ASSESABLE_VAL, _BOND_VALUE, _DUTY_VALUE;
    public string Vl2, val;

    private string _BRANCH_CODE;
    private string _YEAR;
    private string _WORKING_PERIOD;
    private string _BRANCH_COMMON, _LOGINDATE;

    private string _Ename, _flag, _USER_ID;
    #endregion

    # region Public Attributes

    public string ID { get { return _ID; } set { _ID = value; } }
    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }

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
    public string CONSIGNEE_ADDRESS5 { get { return _CONSIGNEE_ADDRESS5; } set { _CONSIGNEE_ADDRESS5 = value; } }

    public string PORT_LOADING { get { return _PORT_LOADING; } set { _PORT_LOADING = value; } }
    public string PORT_FINAL_DEST { get { return _PORT_FINAL_DEST; } set { _PORT_FINAL_DEST = value; } }
    public string ITEM_DESC { get { return _ITEM_DESC; } set { _ITEM_DESC = value; } }
    public string COMMISSIONER_CUSTOMS { get { return _COMMISSIONER_CUSTOMS; } set { _COMMISSIONER_CUSTOMS = value; } }
    public string TRANSHIPED_FROM { get { return _TRANSHIPED_FROM; } set { _TRANSHIPED_FROM = value; } }

    public string TP_BOONDNO { get { return _TP_BOONDNO; } set { _TP_BOONDNO = value; } }
    public string TP_BOOND_DATE { get { return _TP_BOOND_DATE; } set { _TP_BOOND_DATE = value; } }
    public string VESSEL_NO { get { return _VESSEL_NO; } set { _VESSEL_NO = value; } }
    public string VESSEL_DATE { get { return _VESSEL_DATE; } set { _VESSEL_DATE = value; } }
    public string IGM_NO { get { return _IGM_NO; } set { _IGM_NO = value; } }
    public string IGM_DATE { get { return _IGM_DATE; } set { _IGM_DATE = value; } }
    public string INVOICE_NO { get { return _INVOICE_NO; } set { _INVOICE_NO = value; } }
    public string INVOICE_DATE { get { return _INVOICE_DATE; } set { _INVOICE_DATE = value; } }
    public string MAWBNO { get { return _MAWBNO; } set { _MAWBNO = value; } }
    public string MAWB_DATE { get { return _MAWB_DATE; } set { _MAWB_DATE = value; } }
    public string HAWBNO { get { return _HAWBNO; } set { _HAWBNO = value; } }
    public string HAWB_DATE { get { return _HAWB_DATE; } set { _HAWB_DATE = value; } }

    public string NO_OF_PKGS { get { return _NO_OF_PKGS; } set { _NO_OF_PKGS = value; } }
    public string NO_OF_PKGS_UNIT { get { return _NO_OF_PKGS_UNIT; } set { _NO_OF_PKGS_UNIT = value; } }
    public string WEIGHT1 { get { return _WEIGHT1; } set { _WEIGHT1 = value; } }
    public string WEIGHT_UNIT { get { return _WEIGHT_UNIT; } set { _WEIGHT_UNIT = value; } }
    public string EXRATE { get { return _EXRATE; } set { _EXRATE = value; } }
    public string CURRENCY { get { return _CURRENCY; } set { _CURRENCY = value; } }
    public string INVOICE_VALUE { get { return _INVOICE_VALUE; } set { _INVOICE_VALUE = value; } }
    public string CIF { get { return _CIF; } set { _CIF = value; } }
    public string L_CHARGES { get { return _L_CHARGES; } set { _L_CHARGES = value; } }
    public string ASSESABLE_VAL { get { return _ASSESABLE_VAL; } set { _ASSESABLE_VAL = value; } }
    public string BOND_VALUE { get { return _BOND_VALUE; } set { _BOND_VALUE = value; } }
    public string DUTY_VALUE { get { return _DUTY_VALUE; } set { _DUTY_VALUE = value; } }


    public string flag { get { return _flag; } set { _flag = value; } }
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }
    public string BRANCH_COMMON { get { return _BRANCH_COMMON; } set { _BRANCH_COMMON = value; } }
    public string LOGINDATE { get { return _LOGINDATE; } set { _LOGINDATE = value; } }


    #endregion


    public string working_period;

    AppSession aps = new AppSession();
    Transaction Transact = new Transaction();
    adminmaster adm = new adminmaster();
    NForm Nform = new NForm();
    TransPermit TP = new TransPermit();

    //public string _invoices, str_InvoiceValueINR1, str_txtFreight1, str_txtInsurance1, str_txtMISC1, str_txtLandingCharges1, str_txtAssesableValue1;
    //public string str_txtBasicDutyPercentage1, str_txtCVDDutyPercentage1, str_txtCessPercentage1, str_txtCustoms_CessPercentage1, str_txtAdditional_DutyPercentage1;
    //public string str_txtBasicDuty1, str_txtCVDDuty1, str_txtCess1, str_txtCustoms_Cess1, str_txtAdditional_Duty1, str_txtTotal_Duty1;
    //public string invoices { get { return _invoices; } set { _invoices = value; } }
   
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
   
    public string currentuser, ddlJobNo;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate,testaddress;
    public string SELECT_TYPE, SELECT_BRANCH;


    public string part1, part2, part3, Vessel1, Vessel2, Vessel3, WP_End, Vessel_YEAR_END, YEAR_END, SplitBranch, Bond_YEAR_END;
    
    CheckList CHKLIST = new CheckList();
    Date_Time dt = new Date_Time();   
    DataTable dtt = new DataTable();

    List<TransShip_Permit_Rpt_viewer> Import_DutyCalculator1 = new List<TransShip_Permit_Rpt_viewer>();

    List<NForm> Load_NForm_Details = new List<NForm>();

    IMP_Dec_I_II customs = new IMP_Dec_I_II();

   
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = HttpContext.Current.Session["currentcomp_db"].ToString();
        working_period = HttpContext.Current.Session["WorkingPeriod"].ToString();
        LoginDate = HttpContext.Current.Session["LoginDate"].ToString();
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
        */
          
        SELECT_BRANCH = Connection.Get_Company_Type();
        if (!IsPostBack)
        {
     
        
            btn_print.Visible = true;
            //btn_print2.Visible = false;
            //btnSend.Visible = false;
            //Load_N_Trans_Details();
        }
        Load_TransPermit_Details();
    }


    public void Get_DS()
    {
          if (Request.QueryString["jobno"] == "" || Request.QueryString["jobno"] == null)
            {
               

            }
            else
            {
               
             ddlJobNo = Request.QueryString["jobno"].ToString();

        TP.JOBNO = ddlJobNo;
        TP.BRANCH_CODE = currentbranch;
        TP.BRANCH_COMMON = SELECT_BRANCH;
        TP.WORKING_PERIOD = working_period;
        TP.flag = "SelectAll";

        ds = TP.Retreive_TransPermit();

        if (ds.Tables[0].Rows.Count > 0)
        {

            EXPORTERNAME = ds.Tables[0].Rows[0]["EXPORTERNAME"].ToString();
            EXPORTER_ADDRESS1 = ds.Tables[0].Rows[0]["EXPORTER_ADDRESS1"].ToString();
            EXPORTER_ADDRESS2 = ds.Tables[0].Rows[0]["EXPORTER_ADDRESS2"].ToString();
            EXPORTER_ADDRESS3 = ds.Tables[0].Rows[0]["EXPORTER_ADDRESS3"].ToString();
            EXPORTER_ADDRESS4 = ds.Tables[0].Rows[0]["EXPORTER_ADDRESS4"].ToString();
            EXPORTER_ADDRESS5 = ds.Tables[0].Rows[0]["EXPORTER_ADDRESS5"].ToString();
            JOBNO = ds.Tables[0].Rows[0]["JOBNO"].ToString();
            PORT_LOADING = ds.Tables[0].Rows[0]["PORT_LOADING"].ToString();
            PORT_FINAL_DEST = ds.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString();
            TP_BOONDNO = ds.Tables[0].Rows[0]["TP_BOONDNO"].ToString();
            TP_BOOND_DATE = ds.Tables[0].Rows[0]["TP_BOOND_DATE"].ToString();
            IGM_NO = ds.Tables[0].Rows[0]["IGM_NO"].ToString();
            IGM_DATE = ds.Tables[0].Rows[0]["IGM_DATE"].ToString();
            MAWBNO = ds.Tables[0].Rows[0]["MAWBNO"].ToString();
            HAWBNO = ds.Tables[0].Rows[0]["HAWBNO"].ToString();
            NO_OF_PKGS = ds.Tables[0].Rows[0]["NO_OF_PKGS"].ToString();
            NO_OF_PKGS_UNIT = ds.Tables[0].Rows[0]["NO_OF_PKGS_UNIT"].ToString();
            ITEM_DESC = ds.Tables[0].Rows[0]["ITEM_DESC"].ToString();
            WEIGHT1 = ds.Tables[0].Rows[0]["WEIGHT1"].ToString();
            WEIGHT_UNIT = ds.Tables[0].Rows[0]["WEIGHT_UNIT"].ToString();
            VESSEL_DATE = ds.Tables[0].Rows[0]["VESSEL_DATE"].ToString();
            VESSEL_NO = ds.Tables[0].Rows[0]["VESSEL_NO"].ToString();
            INVOICE_NO = ds.Tables[0].Rows[0]["INVOICE_NO"].ToString();
            INVOICE_DATE = ds.Tables[0].Rows[0]["INVOICE_DATE"].ToString();
            CURRENCY = ds.Tables[0].Rows[0]["CURRENCY"].ToString();
            INVOICE_VALUE = ds.Tables[0].Rows[0]["INVOICE_VALUE"].ToString();
            CONSIGNEE_NAME = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
            CONSIGNEE_ADDRESS1 = ds.Tables[0].Rows[0]["CONSIGNEE_ADDRESS1"].ToString();
            CONSIGNEE_ADDRESS2 = ds.Tables[0].Rows[0]["CONSIGNEE_ADDRESS2"].ToString();
            CONSIGNEE_ADDRESS3 = ds.Tables[0].Rows[0]["CONSIGNEE_ADDRESS3"].ToString();
            CONSIGNEE_ADDRESS4 = ds.Tables[0].Rows[0]["CONSIGNEE_ADDRESS4"].ToString();
            EXRATE = ds.Tables[0].Rows[0]["EXRATE"].ToString();
            CIF = ds.Tables[0].Rows[0]["CIF"].ToString();
            L_CHARGES = ds.Tables[0].Rows[0]["L_CHARGES"].ToString();
            ASSESABLE_VAL = ds.Tables[0].Rows[0]["ASSESABLE_VAL"].ToString();
            DUTY_VALUE = ds.Tables[0].Rows[0]["DUTY_VALUE"].ToString();
            BOND_VALUE = ds.Tables[0].Rows[0]["BOND_VALUE"].ToString();



            char[] chars = { '/' };

            if (IGM_DATE != "")
            {
                string[] igm_date = IGM_DATE.Split(chars);
                part1 = igm_date[0];
                part2 = igm_date[1];
                part3 = igm_date[2];

                YEAR_END = part3.Substring(2, 2);
            }

            if (VESSEL_DATE != "")
            {
                string[] Vessel_date = VESSEL_DATE.Split(chars);
                Vessel1 = Vessel_date[0];
                string Vsl2 = Vessel_date[1];
                Vessel2 = get_Month(Vsl2);

                Vessel3 = Vessel_date[2];

                Vessel_YEAR_END = Vessel3.Substring(2, 2);
            }

            if (TP_BOOND_DATE != "")
            {
                string[] Bond_date = TP_BOOND_DATE.Split(chars);
                part1 = Bond_date[0];
                part2 = Bond_date[1];
                part3 = Bond_date[2];

                Bond_YEAR_END = part3.Substring(2, 2);
            }
           

            string WPeriod = working_period;
            string f1 = WPeriod.Substring(9, 2);
            string l1 = WPeriod.Substring(23, 2);
            WP_End = "/" + f1 + "-" + l1;

            string[] branch1 = currentbranch.Split(',');
            SplitBranch = branch1[0];
        }

        
        }
    }

    public void Load_TransPermit_Details()
    {
        try
        {
             string Btn_Type =string.Empty;

            if (Request.QueryString["jobno"] == "" || Request.QueryString["jobno"] == null)
            {
               
            }
            else
            {
                if (Request.QueryString["Transship"] == "" || Request.QueryString["Transship"] == null)
                {

                }

                else
                {
                    Btn_Type = Request.QueryString["Transship"].ToString();
                }
                    ddlJobNo = Request.QueryString["jobno"].ToString();

            

             if (Btn_Type == "Direct")
             {
                 LocalReport localReport = ReportViewer1.LocalReport;
                 localReport.ReportPath = @"Report/Transship_Permit_Report_line.rdlc";
             }
             if (Btn_Type == "Manual")
             {
                 LocalReport localReport = ReportViewer1.LocalReport;
                 localReport.ReportPath = @"Report/Transship_Permit_Report.rdlc";
                
             }

             Get_DS();

             List<ReportParameter> paramList1 = new List<ReportParameter>();
             this.ReportViewer1.LocalReport.SetParameters(paramList1);
             ReportViewer1.LocalReport.DataSources.Clear();

             List<ReportParameter> paramList = new List<ReportParameter>(); this.ReportViewer1.LocalReport.SetParameters(paramList);
             ReportViewer1.LocalReport.DataSources.Clear();

             ReportParameter p1 = new ReportParameter("MAWB_NO", MAWBNO);
             ReportParameter p2 = new ReportParameter("HAWB_NO", HAWBNO);
             ReportParameter p3 = new ReportParameter("IGM_NOOFPACKAGE", NO_OF_PKGS);
             ReportParameter p4 = new ReportParameter("IGM_PACKAGETYPE", NO_OF_PKGS_UNIT);
             ReportParameter p5 = new ReportParameter("ITEM_DESCRIPTION", ITEM_DESC);
             ReportParameter p6 = new ReportParameter("IGM_GROSSWEIGHT", WEIGHT1);
             ReportParameter p7 = new ReportParameter("IGM_TYPEOFWEIGHT", WEIGHT_UNIT);
             ReportParameter p8 = new ReportParameter("INVOICE_NO", INVOICE_NO);
             ReportParameter p9 = new ReportParameter("INVOICE_DATE", INVOICE_DATE);
             ReportParameter p10 = new ReportParameter("INVOICE_CURRENCY", CURRENCY);
             ReportParameter p11 = new ReportParameter("INVOICE_VALUE", INVOICE_VALUE);


             ReportParameter p12 = new ReportParameter("IMPORTER_NAME", EXPORTERNAME);
             ReportParameter p13 = new ReportParameter("ADDRESS1", EXPORTER_ADDRESS1);
             ReportParameter p14 = new ReportParameter("ADDRESS2", EXPORTER_ADDRESS2);
             ReportParameter p15 = new ReportParameter("ADDRESS3", EXPORTER_ADDRESS3);
             ReportParameter p16 = new ReportParameter("ADDRESS4", EXPORTER_ADDRESS4);
             ReportParameter p17 = new ReportParameter("ADDRESS5", EXPORTER_ADDRESS5);
             ReportParameter JobNo = new ReportParameter("JOBNO", JOBNO);
             ReportParameter C_Origin = new ReportParameter("C_Origin", PORT_LOADING);
             ReportParameter PORT = new ReportParameter("PORT_SHIP", PORT_FINAL_DEST);

             ReportParameter p18 = new ReportParameter("SUPPLIER_NAME", CONSIGNEE_NAME);
             ReportParameter p19 = new ReportParameter("SUPPLIER_ADDRESS", CONSIGNEE_ADDRESS1);
             ReportParameter p20 = new ReportParameter("SUPPLIER_ADDRESS1", CONSIGNEE_ADDRESS2);
             ReportParameter p21 = new ReportParameter("SUPPLIER_ADDRESS2", CONSIGNEE_ADDRESS3);
             ReportParameter p22 = new ReportParameter("SUPPLIER_COUNTRY_NAME", CONSIGNEE_ADDRESS4);
             ReportParameter p23 = new ReportParameter("IGM_NO", IGM_NO);
             ReportParameter p24 = new ReportParameter("IGM_Date1", part1);
             ReportParameter p25 = new ReportParameter("IGM_Date2", part2);
             ReportParameter p26 = new ReportParameter("YEAR_END", YEAR_END);

             ReportParameter p27 = new ReportParameter("Vessel1_Date1", Vessel1);
             ReportParameter p28 = new ReportParameter("Vessel1_Date2", Vessel2);
             ReportParameter p29 = new ReportParameter("Vessel1_Date3", Vessel_YEAR_END);
             ReportParameter p30 = new ReportParameter("IGM_FLIGHTNO_VESSELNO", VESSEL_NO);

             ReportParameter p31 = new ReportParameter("INVOICE_EXRATE", EXRATE);
             ReportParameter p32 = new ReportParameter("CIF_VALUE", CIF);
             ReportParameter p33 = new ReportParameter("LANDING_CHARGES", L_CHARGES);
             ReportParameter p34 = new ReportParameter("ASSESSABLE_VALUE", ASSESABLE_VAL);
             ReportParameter p35 = new ReportParameter("DUTY_VALUE", DUTY_VALUE);
             ReportParameter WP_End1 = new ReportParameter("WP_End", WP_End);
             ReportParameter branch = new ReportParameter("currentbranch", currentbranch);
             ReportParameter p36 = new ReportParameter("BOND_VALUE", BOND_VALUE);
             ReportParameter p37 = new ReportParameter("SplitBranch", SplitBranch);

             ReportParameter p38 = new ReportParameter("TP_BOONDNO", TP_BOONDNO);
             ReportParameter p39 = new ReportParameter("TP_BOOND_DATE", Bond_YEAR_END);




             Load_N_Trans_Details();

             ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20, p21, p22, p23, p24, p25, p26, p27, p28, p29, p30, p31, p32, p33, p34, p35, JobNo, C_Origin, PORT, WP_End1, branch, p36, p37,p38,p39 };

             ReportViewer1.LocalReport.SetParameters(p);


             //  --------------------------------------To Print------------------------------------------------------------------------------------//
             Warning[] warnings;
             string[] streamIds;
             string mimeType = string.Empty;
             string encoding = string.Empty;
             string extension = string.Empty;
             string fileName = "a";
             byte[] bytes = ReportViewer1.LocalReport.Render("pdf", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
             Session.Remove("report");
             Session["report"] = bytes;
                //--------------------------------------To Print------------------------------------------------------------------------------------//


            }

        }

        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();

            er.makeLog
                (ex.Message);
        }
    }

    public void Load_N_Trans_Details()
    {
        ReportDataSource dataSS = new ReportDataSource("TransPermit1", TP.Load_Transhipment_Permit(ds.Tables[0]));       
        ReportViewer1.LocalReport.DataSources.Add(dataSS);
       
    }

    public string get_Month(string val)
    {

        switch (val)
        {
            case ("01"):
                Vl2 = "January";
                break;

            case ("02"):
                Vl2 = "Febraury";
                break;
            case ("03"):
                Vl2 = "March";
                break;
            case ("04"):
                Vl2 = "April";
                break;
            case ("05"):
                Vl2 = "May";
                break;
            case ("06"):
                Vl2 = "June";
                break;
            case ("07"):
                Vl2 = "July";
                break;
            case ("08"):
                Vl2 = "August";
                break;
            case ("09"):
                Vl2 = "September";
                break;
            case ("10"):
                Vl2 = "October";
                break;
            case ("11"):
                Vl2 = "November";
                break;
            case ("12"):
                Vl2 = "December";
                break;
        }

        return Vl2;
    }


    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'TRANSHIP PERMIT', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'TRANSHIP PERMIT', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void ddlJob_No_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlJob_No.SelectedItem.Text != "Select")
        //{
        //    ddlJobNo = ddlJob_No.SelectedItem.Text;
        //    Session["ddlJobNo"] = ddlJobNo;
            Load_TransPermit_Details();
        //}

    }
}




