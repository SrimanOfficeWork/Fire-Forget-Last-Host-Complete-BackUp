using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using BussinessObject;

public partial class FlatFile_MIS_report_1 : System.Web.UI.Page
{
    AppSession aps = new AppSession();
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        //----------------------------------------------------------FOR CusRes_report----------------------------------------------------------------//
         if (Request.QueryString["CusRes_report"] != "" && Request.QueryString["CusRes_report"] != null)
         {
             CheckList cures = new CheckList();
             cures.Open_CusRes_XLs_Report(Request.QueryString["JOB_NO"].ToString(),Session["WorkingPeriod"].ToString(),Request.QueryString["BE_NO"].ToString());
         }
      //----------------------------------------------------------FOR CusRes_report----------------------------------------------------------------//

         //----------------------------------------------------------Exchange--Report--start-----------------------------------------------------------//
         else if (Request.QueryString["Exchange"] != "" && Request.QueryString["Exchange"] != null)
         {

             ExchangeRate_History Exchange_History = new ExchangeRate_History();
             Exchange_History.Open_PL_XLs_ExchangeRate_History_Report(
             Request.QueryString["ddlEffect_From"].ToString(),
             Request.QueryString["txtCurrency"].ToString(),
             Request.QueryString["txtfromdate"].ToString(),

             Request.QueryString["txttodate"].ToString(),
             Request.QueryString["ddl_Month"].ToString(),
             Request.QueryString["ddl_Year"].ToString()
             );
         }

         //----------------------------------------------------------SEZ_Z_Item_Status-----------------------------------------------------------//

         else if (Request.QueryString["SEZ_Z_Item_Status"] != "" && Request.QueryString["SEZ_Z_Item_Status"] != null)
         {
             Sez_Import_General_Grid_Search SI = new Sez_Import_General_Grid_Search();
             SI.SEZ_Z_Item_Status(
                 Request.QueryString["ddlTerms"].ToString(),
                 Request.QueryString["txtsearch"].ToString()
                 );
         }
         //----------------------------------------------------------MIS--info--------------------------------------------------------------//
         //else if (Request.QueryString["MIS_rpt"] != "" && Request.QueryString["MIS_rpt"] != null)
         //{
         //    MIS_rpt MIS_data = new MIS_rpt();
         //    MIS_data.Open_MIS_XLs_Report(
         //        Request.QueryString["Jobdate"].ToString(),
         //        Request.QueryString["Imp_name"].ToString(),
         //        Request.QueryString["Tr_mode"].ToString(),
         //        Request.QueryString["Branch"].ToString(),
         //        Request.QueryString["BE_type"].ToString(),
         //        Request.QueryString["Report_cat"].ToString(),
         //        Request.QueryString["Port"].ToString(),
         //        Request.QueryString["Type"].ToString(),
         //        Request.QueryString["Todate"].ToString(),
         //        Request.QueryString["Country"].ToString(),
         //        Request.QueryString["UserID"].ToString(),
         //        Request.QueryString["CustHouse"].ToString()
         //        );
         //}
         else if (Request.QueryString["MIS_rpt"] != "" && Request.QueryString["MIS_rpt"] != null)
         {
             MIS_rpt MIS_data = new MIS_rpt();
             MIS_data.Open_MIS_XLs_Report(
                 Request.QueryString["Jobdate"] ?? "",
                 Request.QueryString["Imp_name"] ?? "",
                 Request.QueryString["Tr_mode"] ?? "",
                 Request.QueryString["Branch"] ?? "",
                 Request.QueryString["BE_type"] ?? "",
                 Request.QueryString["Report_cat"] ?? "",
                 Request.QueryString["Port"] ?? "",
                 Request.QueryString["Type"] ?? "",
                 Request.QueryString["Todate"] ?? "",
                 Request.QueryString["Country"] ?? "",
                 Request.QueryString["UserID"] ?? "",
                 Request.QueryString["CustHouse"] ?? ""
                 );
         }
         //----------------------------------------------------------FOR MIS--info----------------------------------------------------------------//

         //----------------------------------------------------------FOR DUTY WORKSHEET----------------------------------------------------------------//
         else if (Request.QueryString["DutyWorkSheet"] != "" && Request.QueryString["DutyWorkSheet"] != null)
         {
             DutyWorkSht DutyWS = new DutyWorkSht();
             DutyWS.Open_DutyWorkSheet_Report(
                 Request.QueryString["JobNo"].ToString()

                 );
         }


         //----------------------------------------------------------FOR DUTY WORKSHEET----------------------------------------------------------------//
         //----------------------------------------------------------MIS--statment---start-----------------------------------------------------------//
         else if (Request.QueryString["MIS_stat"] != "" && Request.QueryString["MIS_stat"] != null)
         {
             MIS_rpt MIS_data = new MIS_rpt();

                 MIS_data.Open_MIS_XLs_Statement_Report(
                 Request.QueryString["Jobdate"].ToString(),
                 Request.QueryString["Imp_name"].ToString(),
                 Request.QueryString["Tr_mode"].ToString(),

                 Request.QueryString["jobno"].ToString(),
                 Request.QueryString["Todate"].ToString(),
                 Request.QueryString["Type"].ToString()
                 
                 );
         }
    //---------------------------------------------------------- MIS--statment-----end-----------------------------------------------------------//

         //----------------------------------------------------------PL--Report--start-----------------------------------------------------------//
         else if (Request.QueryString["PL_stat"] != "" && Request.QueryString["PL_stat"] != null)
         {
            
             Pl_Report PL = new Pl_Report();

             PL.Open_PL_XLs_Statement_Report(
             Request.QueryString["Jobdate"].ToString(),
             Request.QueryString["Imp_name"].ToString(),
             Request.QueryString["Tr_mode"].ToString(),

             Request.QueryString["jobno"].ToString(),
             Request.QueryString["Todate"].ToString(),
             Request.QueryString["Type"].ToString()

             );
         }

        //----------------------------------------------------------PL--Report--End-----------------------------------------------------------//

         else if (Request.QueryString["Pl_Rpt_1"] != "" && Request.QueryString["Pl_Rpt_1"] != null)
         {
             Pl_Report PL = new Pl_Report();

             PL.PL_1_XLs_PDF(
                             Request.QueryString["Jobdate"].ToString(),
                             Request.QueryString["Todate"].ToString(),

                             Request.QueryString["Imp_name"].ToString(),
                             Request.QueryString["Branch"].ToString(),

                             Request.QueryString["Type"].ToString()
             );
         }

         //--------------------------------------------------------EXP--PL-1-Report--Start-----------------------------------------------------------//

         else if (Request.QueryString["EXP_Pl_Rpt_1"] != "" && Request.QueryString["EXP_Pl_Rpt_1"] != null)
         {
            EXP_PL_Report_1 PL =new EXP_PL_Report_1();

             PL.PL_1_XLs_PDF(
                             Request.QueryString["Jobdate"].ToString(),
                             Request.QueryString["Todate"].ToString(),

                             Request.QueryString["Imp_name"].ToString(),
                             Request.QueryString["Branch"].ToString(),

                             Request.QueryString["Type"].ToString(),
                             Request.QueryString["Job_Type"].ToString(),
                             Request.QueryString["PL"].ToString()
                             
             );
         }


         //----------------------------------------------------------Export_MIS2_Mithra-----Start-----------------------------------------------------------//

         else if (Request.QueryString["Export_MIS_2"] != "" && Request.QueryString["Export_MIS_2"] != null)
         {
             Export_MIS_2 EXP_MIS = new Export_MIS_2();

             EXP_MIS.Open_MIS_XLs_Expeditors_Rpt(
                  Request.QueryString["JobNo"].ToString(),
                  Request.QueryString["Jobdate"].ToString(),
                  Request.QueryString["Exp_name"].ToString(),
                  Request.QueryString["To_date"].ToString(),
                  Request.QueryString["Branch"].ToString(),
                 Request.QueryString["Type"].ToString()

                 );

         }

        //---------------------------------------------------------- Export_MIS2_Mithra-----end-----------------------------------------------------------//


         else if (Request.QueryString["DB_BK"] != "" && Request.QueryString["DB_BK"] != null)
         {
             DB_backup BK = new DB_backup();
             BK.Backup();
         }

         else if (Request.QueryString["All_DB_BK"] != "" && Request.QueryString["All_DB_BK"] != null)
         {
             DB_backup BK = new DB_backup();
             BK.All_DB_Backup();
         }
         else if (Request.QueryString["ALL_Client_Backup"] != "" && Request.QueryString["ALL_Client_Backup"] != null)
         {
             DB_backup BK = new DB_backup();
             BK.Backup_All_Zip(Server.MapPath("~/Submission/" + Request.QueryString["DB_Part"].ToString()), Request.QueryString["DB_Part"].ToString());
         }

         else if (Request.QueryString["CUSRES_1"] != "" && Request.QueryString["CUSRES_1"] != null)
         {
             IMP_CusRes_Rpt_N CR = new IMP_CusRes_Rpt_N();
             CR.Open_Cusres_N_Rpt(
                  Request.QueryString["Jobdate"].ToString(),
                  Request.QueryString["jobno"].ToString(),
                  Request.QueryString["Todate"].ToString(),
                  Request.QueryString["Branch"].ToString(),
                 Request.QueryString["Type"].ToString()
                 );
         }

         //---------------------------------------------------------- Import_DSR_-----Start-----------------------------------------------------------//

         else if (Request.QueryString["DailyStatusRpt"] != "" && Request.QueryString["DailyStatusRpt"] != null)
         {
             DailyStatusRpt DSR_L = new DailyStatusRpt();

             DSR_L.Open_Retail_XLs_Report(
                 Request.QueryString["fromdate"].ToString(),
                 Request.QueryString["ClientName"].ToString(),
                 Request.QueryString["Tr_mode"].ToString(),
                 Request.QueryString["Branch"].ToString(),
                 Request.QueryString["Job_type"].ToString(),
                 Request.QueryString["To_date"].ToString(),
                 Request.QueryString["Type"].ToString()

                 );
         }

         //---------------------------------------------------------- Import_DSR_-----end-----------------------------------------------------------//


         //---------------------------------------------------------- Import_Expeditors_-----Start-----------------------------------------------------------//

         else if (Request.QueryString["ExpeditorsRpt"] != "" && Request.QueryString["ExpeditorsRpt"] != null)
         {
             ExpeditorsRpt EXP = new ExpeditorsRpt();

             EXP.Open_Retail_XLs_Expeditors_Rpt(
                 Request.QueryString["fromdate"].ToString(),
                 Request.QueryString["ClientName"].ToString(),
                 Request.QueryString["Tr_mode"].ToString(),
                 Request.QueryString["Branch"].ToString(),
                 Request.QueryString["Job_type"].ToString(),
                 Request.QueryString["To_date"].ToString(),
                 Request.QueryString["Type"].ToString()

                 );
         }

        //---------------------------------------------------------- Import_Expeditors_-----end-----------------------------------------------------------//

        //---------------------------------------------------------- Job Filed Status-----Start-----------------------------------------------------------//

         else if (Request.QueryString["Job_Filed_Status"] != "" && Request.QueryString["Job_Filed_Status"] != null)
         {
             Imp_Exp_Job_Filed_Status JFS = new Imp_Exp_Job_Filed_Status();

             JFS.Open_JFS_XLs_Report(
                 Request.QueryString["IMP_EXP"].ToString(),
                 Request.QueryString["IMP_EXP_name"].ToString(),
                 Request.QueryString["Jobno"].ToString(),
                 Request.QueryString["Fromdate"].ToString(),
                 Request.QueryString["Todate"].ToString(),
                 Request.QueryString["Tr_mode"].ToString(),
                 Request.QueryString["Branch"].ToString(),
                 Request.QueryString["JobCat"].ToString(),
                 Request.QueryString["Type"].ToString()
                 );
         }
        

        //---------------------------------------------------------- Job Filed Status-----End-----------------------------------------------------------//


        //----------------------------------------------------------BL Job Filed Status-----Start-----------------------------------------------------------//

         else if (Request.QueryString["BL_Pending_Job"] != "" && Request.QueryString["BL_Pending_Job"] != null)
        {
            EXP_BL_Pending_Status EBL = new EXP_BL_Pending_Status();

            EBL.Open_BLP_XLs_Report(
               Request.QueryString["EXP_name"].ToString(),
               Request.QueryString["Jobno"].ToString(),
               Request.QueryString["Fromdate"].ToString(),
               Request.QueryString["Todate"].ToString(),
               Request.QueryString["Tr_mode"].ToString(),
               Request.QueryString["Branch"].ToString(),
               Request.QueryString["Type"].ToString(),
               Request.QueryString["Excel_jobno"].ToString(),
               Request.QueryString["Orderby"].ToString()
               
               );

        }

        else if (Request.QueryString["Multiple_BL_Pending_Job"] != "" && Request.QueryString["Multiple_BL_Pending_Job"] != null)
        {
            Export_BL_Multiple EMBL = new Export_BL_Multiple();
            EMBL.Open_Multiple_BL__XLs_Report(
              Request.QueryString["EXP_name"].ToString(),
              Request.QueryString["Jobno"].ToString(),
              Request.QueryString["Fromdate"].ToString(),

              Request.QueryString["Todate"].ToString(),
              Request.QueryString["Tr_mode"].ToString(),

              Request.QueryString["Branch"].ToString(),
              Request.QueryString["Type"].ToString(),
              Request.QueryString["Excel_jobno"].ToString()
              );

        }
        //----------------------------------------------------------BL Job Filed Status-----End-----------------------------------------------------------//

        //----------------------------------------------------------Export Summary-----Start-----------------------------------------------------------//

       else if (Request.QueryString["Exp_Summary"] != "" && Request.QueryString["Exp_Summary"] != null)
        {
            Export_Summary ES = new Export_Summary();
            ES.Load_Summary_Report_Data_Xls(
                 Request.QueryString["Category"].ToString(),
                  Request.QueryString["Fromdate"].ToString(),
                   Request.QueryString["Todate"].ToString(),
                    Request.QueryString["Tr_Mode"].ToString(),
                     Request.QueryString["Select_Item"].ToString(),
                      Request.QueryString["TheQuarter_Start"].ToString(),
                       Request.QueryString["TheQuarter_End"].ToString(),
                        Request.QueryString["W_Start_month"].ToString(),
                         Request.QueryString["W_End_month"].ToString(),
                          Request.QueryString["Branch"].ToString(),
                           Request.QueryString["Type"].ToString()
               );

        }
        //----------------------------------------------------------Export Summary-----End-----------------------------------------------------------//

        //----------------------------------------------------------Export Add_Annexure-----Start-----------------------------------------------------------//

         else if (Request.QueryString["Add_Annexure"] != "" && Request.QueryString["Add_Annexure"] != null)
                {
                    Export_BL_Multiple EMBL = new Export_BL_Multiple();
                    EMBL.Open_Add_Annexure_Report(
                         Request.QueryString["Exp_Name"].ToString(),
                          Request.QueryString["Tr_mode"].ToString(),
                           Request.QueryString["Ref_Id"].ToString(),
                            Request.QueryString["Job_Id"].ToString(),
                             Request.QueryString["Branch"].ToString()
                       );

                }
        //----------------------------------------------------------Export Add_Annexure-----End-----------------------------------------------------------//

        //----------------------------------------------------------Import Summary-----Start-----------------------------------------------------------//

         else if (Request.QueryString["Imp_Summary"] != "" && Request.QueryString["Imp_Summary"] != null)
        {
            Import_Summary ES = new Import_Summary();
            ES.Load_Summary_Report_Data_Xls(
                 Request.QueryString["Category"].ToString(),
                  Request.QueryString["Fromdate"].ToString(),
                   Request.QueryString["Todate"].ToString(),
                    Request.QueryString["Tr_Mode"].ToString(),
                     Request.QueryString["Select_Item"].ToString(),
                      Request.QueryString["TheQuarter_Start"].ToString(),
                       Request.QueryString["TheQuarter_End"].ToString(),
                        Request.QueryString["W_Start_month"].ToString(),
                         Request.QueryString["W_End_month"].ToString(),
                          Request.QueryString["Branch"].ToString(),
                           Request.QueryString["Type"].ToString()
               );

        }
         else if (Request.QueryString["Imp_Summary_Two"] != "" && Request.QueryString["Imp_Summary_Two"] != null)
        {
            Import_SummaryTwo ES = new Import_SummaryTwo();
            ES.Load_Summary_Report_Data_Xls(
                 Request.QueryString["Category"].ToString(),
                  Request.QueryString["Fromdate"].ToString(),
                   Request.QueryString["Todate"].ToString(),
                    Request.QueryString["Tr_Mode"].ToString(),
                     Request.QueryString["Select_Item"].ToString(),
                      Request.QueryString["TheQuarter_Start"].ToString(),
                       Request.QueryString["TheQuarter_End"].ToString(),
                        Request.QueryString["W_Start_month"].ToString(),
                         Request.QueryString["W_End_month"].ToString(),
                          Request.QueryString["Branch"].ToString(),
                           Request.QueryString["Type"].ToString()
               );

        }
        //----------------------------------------------------------Import Summary-----End-----------------------------------------------------------//


        //----------------------------------------------------------Export Billing summary-----Start-----------------------------------------------------------//

        else if (Request.QueryString["Bill_Job_Inv_Rpt"] != "" && Request.QueryString["Bill_Job_Inv_Rpt"] != null)
        {
            Billing_Exp_Invoice BI = new Billing_Exp_Invoice();

            BI.Open_Export_Jobinv_XLs_Report(
                Request.QueryString["ddlAC_Branch"].ToString(),
                Request.QueryString["Exp_name"].ToString(),
                Request.QueryString["Jobno"].ToString(),
                Request.QueryString["Fromdate"].ToString(),
                Request.QueryString["Todate"].ToString(),
                Request.QueryString["Mode"].ToString(),
                Request.QueryString["Branch"].ToString(),
                Request.QueryString["Type"].ToString(),
                Request.QueryString["Bill_No"].ToString(),
                Request.QueryString["Month"].ToString(),
                Request.QueryString["BILL_STATUS"].ToString()
                );
        }


         else if (Request.QueryString["Bill_Job_Inv_Rpt_tally"] != "" && Request.QueryString["Bill_Job_Inv_Rpt_tally"] != null)
        {
            Billing_Exp_Invoice BI = new Billing_Exp_Invoice();

            BI.Open_Export_Jobinv_XLs_Report_tally(
                Request.QueryString["ddlAC_Branch"].ToString(),
                Request.QueryString["Exp_name"].ToString(),
                Request.QueryString["Jobno"].ToString(),
                Request.QueryString["Fromdate"].ToString(),
                Request.QueryString["Todate"].ToString(),
                Request.QueryString["Mode"].ToString(),
                Request.QueryString["Branch"].ToString(),
                Request.QueryString["Type"].ToString(),
                Request.QueryString["Bill_No"].ToString(),
                Request.QueryString["Month"].ToString(),
                Request.QueryString["BILL_STATUS"].ToString()
                );
        }
         else if (Request.QueryString["GST_EXP_Tally_Data"] != "" && Request.QueryString["GST_EXP_Tally_Data"] != null)
         {
             GST_Exp_Invoice BI = new GST_Exp_Invoice();

             BI.Open_GST_EXP_Tally_Data(
                 Request.QueryString["ddlSearch_Cat"].ToString(),
                 Request.QueryString["txtsearch"].ToString(),
                 Request.QueryString["Exp_name"].ToString(),
                 Request.QueryString["Fromdate"].ToString(),
                 Request.QueryString["Todate"].ToString(),
                 Request.QueryString["Month"].ToString(),
                 Request.QueryString["Type"].ToString() 
                 );
         }
         else if (Request.QueryString["GST_EXP_Tally_Data_Cr"] != "" && Request.QueryString["GST_EXP_Tally_Data_Cr"] != null)
         {
             GST_Exp_Invoice_Credit_Note BI = new GST_Exp_Invoice_Credit_Note();

             BI.Open_GST_EXP_Tally_Data(
                 Request.QueryString["ddlSearch_Cat"].ToString(),
                 Request.QueryString["txtsearch"].ToString(),
                 Request.QueryString["Exp_name"].ToString(),
                 Request.QueryString["Fromdate"].ToString(),
                 Request.QueryString["Todate"].ToString(),
                 Request.QueryString["Month"].ToString(),
                 Request.QueryString["Type"].ToString()
                 );
         }
         else if (Request.QueryString["GST_IMP_Tally_Data"] != "" && Request.QueryString["GST_IMP_Tally_Data"] != null)
         {
             GST_Imp_Invoice BI = new GST_Imp_Invoice();
             BI.Open_GST_IMP_Tally_Data(
                 Request.QueryString["ddlSearch_Cat"].ToString(),
                 Request.QueryString["txtsearch"].ToString(),
                 Request.QueryString["Imp_name"].ToString(),
                 Request.QueryString["Fromdate"].ToString(),
                 Request.QueryString["Todate"].ToString(),
                 Request.QueryString["Month"].ToString(),
                 Request.QueryString["Type"].ToString()
                 );
         }

         else if (Request.QueryString["GST_IMP_Tally_Data_Cr"] != "" && Request.QueryString["GST_IMP_Tally_Data_Cr"] != null)
         {
             GST_Imp_Invoice_Credit_Note BI = new GST_Imp_Invoice_Credit_Note();
             BI.Open_GST_IMP_Tally_Data(
                 Request.QueryString["ddlSearch_Cat"].ToString(),
                 Request.QueryString["txtsearch"].ToString(),
                 Request.QueryString["Imp_name"].ToString(),
                 Request.QueryString["Fromdate"].ToString(),
                 Request.QueryString["Todate"].ToString(),
                 Request.QueryString["Month"].ToString(),
                 Request.QueryString["Type"].ToString()
                 );
         }

         else if (Request.QueryString["GST_IMP_Tally_Data_COMBINED"] != "" && Request.QueryString["GST_IMP_Tally_Data_COMBINED"] != null)
         {
             GST_Bill_Consolidate BI = new GST_Bill_Consolidate();

             BI.Open_GST_IMP_Tally_Data_COMBINED(
                 Request.QueryString["ddlSearch_Cat"].ToString(),
                 Request.QueryString["txtsearch"].ToString(),
                 Request.QueryString["Imp_name"].ToString(),
                 Request.QueryString["Fromdate"].ToString(),
                 Request.QueryString["Todate"].ToString(),
                 Request.QueryString["Month"].ToString(),
                 Request.QueryString["Type"].ToString()
                 );

         }

             /*  2 functions below for ledger ddetails */
         else if (Request.QueryString["GST_IMP_Ledger_Data"] != "" && Request.QueryString["GST_IMP_Ledger_Data"] != null)
         {
             GST_Imp_Invoice BI = new GST_Imp_Invoice();
             BI.Open_GST_IMP_Tally_Data(
                 Request.QueryString["ddlSearch_Cat"].ToString(),
                 Request.QueryString["txtsearch"].ToString(),
                 Request.QueryString["Imp_name"].ToString(),
                 Request.QueryString["Fromdate"].ToString(),
                 Request.QueryString["Todate"].ToString(),
                 Request.QueryString["Month"].ToString(),
                 Request.QueryString["Type"].ToString()
                 );
         }

         else if (Request.QueryString["GST_EXP_Ledger_Data"] != "" && Request.QueryString["GST_EXP_Ledger_Data"] != null)
         {
             GST_Exp_Invoice BI = new GST_Exp_Invoice();
             BI.Open_GST_EXP_Tally_Data(
                 Request.QueryString["ddlSearch_Cat"].ToString(),
                 Request.QueryString["txtsearch"].ToString(),
                 Request.QueryString["Exp_name"].ToString(),
                 Request.QueryString["Fromdate"].ToString(),
                 Request.QueryString["Todate"].ToString(),
                 Request.QueryString["Month"].ToString(),
                 Request.QueryString["Type"].ToString()
                 );
         }
 

        //----------------------------------------------------------Export Billing summary-----End-----------------------------------------------------------//

        //----------------------------------------------------------Import Billing summary-----Start-----------------------------------------------------------//

        else if (Request.QueryString["Bill_Imp_Job_Inv_Rpt"] != "" && Request.QueryString["Bill_Imp_Job_Inv_Rpt"] != null)
        {
            Billing_Imp_Invoice BI = new Billing_Imp_Invoice();
            BI.Open_Import_Jobinv_XLs_Report(
                Request.QueryString["ddlAC_Branch"].ToString(),
                Request.QueryString["Imp_name"].ToString(),
                Request.QueryString["Jobno"].ToString(),
                Request.QueryString["Fromdate"].ToString(),
                Request.QueryString["Todate"].ToString(),
                Request.QueryString["Mode"].ToString(),
                Request.QueryString["Branch"].ToString(),
                Request.QueryString["Type"].ToString(),
                Request.QueryString["Bill_No"].ToString(),
                Request.QueryString["Month"].ToString(),
                Request.QueryString["BILL_STATUS"].ToString()
                );
        }

         else if (Request.QueryString["Bill_Imp_Job_Inv_Rpt_tally"] != "" && Request.QueryString["Bill_Imp_Job_Inv_Rpt_tally"] != null)
        {
            Billing_Imp_Invoice BI = new Billing_Imp_Invoice();

            BI.Open_Import_Jobinv_XLs_Report_tally(
                Request.QueryString["ddlAC_Branch"].ToString(),
                Request.QueryString["Imp_name"].ToString(),
                Request.QueryString["Jobno"].ToString(),
                Request.QueryString["Fromdate"].ToString(),
                Request.QueryString["Todate"].ToString(),
                Request.QueryString["Mode"].ToString(),
                Request.QueryString["Branch"].ToString(),
                Request.QueryString["Type"].ToString(),
                Request.QueryString["Bill_No"].ToString(),
                Request.QueryString["Month"].ToString(),
                Request.QueryString["BILL_STATUS"].ToString()
                );
        }
        //----------------------------------------------------------Import Billing summary-----Start-----------------------------------------------------------//

         else if (Request.QueryString["NIN"] != "" && Request.QueryString["NIN"] != null)
        {
            IMP_Item_Rpt IIR = new IMP_Item_Rpt();
            IIR.Open_XL_Itemwise_Data(
                Request.QueryString["Jobno"].ToString(),
                Request.QueryString["ddlImp_name"].ToString(),
                Request.QueryString["Fromdate"].ToString(),
                Request.QueryString["Todate"].ToString(),
                Request.QueryString["Month"].ToString()
                );
        }

         else if (Request.QueryString["IND_NIS_MONTH"] != "" && Request.QueryString["IND_NIS_MONTH"] != null)
        {
            IMP_Item_Rpt IIR = new IMP_Item_Rpt();
            IIR.Open_IND_NIS_Month_XLs_Report(

               Request.QueryString["Jobno"].ToString(),
               Request.QueryString["ddl_Imp_name"].ToString(),
               Request.QueryString["txtfromdate"].ToString(),
               Request.QueryString["txttodate"].ToString(),
               Request.QueryString["ddlmonth"].ToString(),
               Request.QueryString["Branch"].ToString()
               );
        }

         else if (Request.QueryString["IND_NIS_FTA"] != "" && Request.QueryString["IND_NIS_FTA"] != null)
        {
            IMP_Item_Rpt IIR = new IMP_Item_Rpt();
            IIR.Open_IND_NIS_FTA_XLs_Report(

               Request.QueryString["ddlorgin"].ToString(),
               Request.QueryString["ddl_Imp_name"].ToString(),
               Request.QueryString["txtfromdate"].ToString(),
               Request.QueryString["txttodate"].ToString(),
               Request.QueryString["ddlmonth"].ToString(),
               Request.QueryString["Branch"].ToString(),
               Request.QueryString["Basic_Notn_2"].ToString(),
               Request.QueryString["ddljobno"].ToString()
               );
        }
         else if (Request.QueryString["INDEV_NIS_EXP_PART_LEVEL"] != "" && Request.QueryString["INDEV_NIS_EXP_PART_LEVEL"] != null)
         {

             EXP_INDEV_NISSAN_RPT EIN = new EXP_INDEV_NISSAN_RPT();
             EIN.Open_IND_NIS_PART_LEVEL_DATA_XLs_Report(
                Request.QueryString["ddl_Exp_name"].ToString(),
                Request.QueryString["txtfromdate"].ToString(),
                Request.QueryString["txttodate"].ToString(),
                Request.QueryString["ddlmonth"].ToString(),
                Request.QueryString["Branch"].ToString(),
                Request.QueryString["Jobno"].ToString(),
                Request.QueryString["txt_ItemDesc"].ToString()
                );
         }
         else if (Request.QueryString["INDEV_NIS_IMP_DSR_Rpt"] != "" && Request.QueryString["INDEV_NIS_IMP_DSR_Rpt"] != null)
        {
            IMP_INDEV_DSR_Entry IDSR = new IMP_INDEV_DSR_Entry();

            IDSR.Open_IND_NIS_IMp_DSR_rpt_XLs_Report(
                Request.QueryString["Jobno"].ToString(),
                Request.QueryString["ddljobtypes"].ToString(),
                Request.QueryString["txtfromdate"].ToString(),
                Request.QueryString["txttodate"].ToString(),
                Request.QueryString["ddlmonth"].ToString(),
                Request.QueryString["Branch"].ToString()
                );
        }
         else if (Request.QueryString["INDEV_NIS_IMP_DSR_Rack_Rpt"] != "" && Request.QueryString["INDEV_NIS_IMP_DSR_Rack_Rpt"] != null)
        {
            INDEV_IMP_DSR_Rack_Rpt IDSRA = new INDEV_IMP_DSR_Rack_Rpt();

            IDSRA.Open_IND_NIS_IMp_DSR_Rack_rpt_XLs_Report(
                Request.QueryString["Jobno"].ToString(),
                Request.QueryString["txtfromdate"].ToString(),
                Request.QueryString["txttodate"].ToString(),
                Request.QueryString["ddlmonth"].ToString(),
                Request.QueryString["Branch"].ToString()
                );
        }
         else if (Request.QueryString["INDEV_NIS_IMP_DSR_Summary_Rpt"] != "" && Request.QueryString["INDEV_NIS_IMP_DSR_Summary_Rpt"] != null)
        {
            IMP_INDEV_Summary IDSRA = new IMP_INDEV_Summary();

            IDSRA.Open_IND_NIS_IMp_DSR_Summary_rpt_XLs_Report(
                Request.QueryString["Jobno"].ToString(),
                Request.QueryString["txtfromdate"].ToString(),
                Request.QueryString["txttodate"].ToString(),
                Request.QueryString["ddlmonth"].ToString(),
                Request.QueryString["Branch"].ToString()
                );
        }
         else if (Request.QueryString["EXPO_FREIGHT_RPT_I"] != "" && Request.QueryString["EXPO_FREIGHT_RPT_I"] != null)
        {
           
            IMP_Expo_Freight IEF = new IMP_Expo_Freight();
            IEF.Open_EXPO_FREIGHT_RPT_I_XLs(

               Request.QueryString["txtfromdate"].ToString(),
               Request.QueryString["txttodate"].ToString(),
               Request.QueryString["ddlmonth"].ToString(),
               Request.QueryString["Branch"].ToString(),
               Request.QueryString["ddljobno"].ToString()
               );
        }

         else if (Request.QueryString["EXP_Job_Clearance"] != "" && Request.QueryString["EXP_Job_Clearance"] != null)
        {

            EXP_Job_Clearance EJC = new EXP_Job_Clearance();
            EJC.Open_IMP_Job_CLearance_XLs_Pdf(

               Request.QueryString["Jobno"].ToString(),
               Request.QueryString["Branch"].ToString(),
               Request.QueryString["Type"].ToString()
               );
        }
        else if (Request.QueryString["EXP_Single_Job_Clearance"] != "" && Request.QueryString["EXP_Single_Job_Clearance"] != null)
        {

            Paramount_Exp_Job_Clearance PEJC = new Paramount_Exp_Job_Clearance();
            PEJC.Open_EXP_Job_CLearance_XLs(
               Request.QueryString["Jobno"].ToString(),
               Request.QueryString["Branch"].ToString(),
               Request.QueryString["Type"].ToString()
               );
        }
        else if (Request.QueryString["EXP_Grid_Job_Clearance"] != "" && Request.QueryString["EXP_Grid_Job_Clearance"] != null)
        {

            Paramount_Exp_Job_Clearance PEJC = new Paramount_Exp_Job_Clearance();
            PEJC.Open_EXP_Grid_Job_CLearance_XLs(
               Request.QueryString["Exp_name"].ToString(),
                Request.QueryString["Rpt_name"].ToString(),
                 Request.QueryString["txtjobno"].ToString(),
                  Request.QueryString["Fromdate"].ToString(),
                   Request.QueryString["Todate"].ToString(),
                    Request.QueryString["Month"].ToString(),
                     Request.QueryString["Branch"].ToString(),
                     Request.QueryString["Type"].ToString()
               );

        }

        else if (Request.QueryString["IMP_Demurrage_rpt"] != "" && Request.QueryString["IMP_Demurrage_rpt"] != null)
        {
            IMP_Demurrage ID = new IMP_Demurrage();
            ID.Open_IMP_DEMURRAGE_XLs(
               Request.QueryString["ddljobno"].ToString(),
                Request.QueryString["ddlimp_name"].ToString(),
                 Request.QueryString["txttax_per"].ToString(),
                  Request.QueryString["Branch"].ToString()
               );

        }
        else if (Request.QueryString["BAS_IMP_DSR_rpt"] != "" && Request.QueryString["BAS_IMP_DSR_rpt"] != null)
        {
            BAS_IMP_DSR BID = new BAS_IMP_DSR();
            BID.Open_Import_DSR_XLs(
               Request.QueryString["Imp_name"].ToString(),
                Request.QueryString["Jobno"].ToString(),
                 Request.QueryString["Mode"].ToString(),
                  Request.QueryString["Fromdate"].ToString(),
                  Request.QueryString["Todate"].ToString(),
                  Request.QueryString["Branch_Common"].ToString(),
                  Request.QueryString["Month"].ToString()
               );
        }
         else if (Request.QueryString["IMP_LICENSE_SUMMARY_RPT_PARTYWISE"] != "" && Request.QueryString["IMP_LICENSE_SUMMARY_RPT_PARTYWISE"] != null)
         {
             BAS_IMP_DSR BID = new BAS_IMP_DSR();
             BID.Open_Import_LICENSE_RPT_PARTYWISE_XLs(
                Request.QueryString["Imp_name"].ToString(),
                Request.QueryString["Br_slno"].ToString(),// Added by Pandiyan
                 Request.QueryString["Jobno"].ToString(),
                  Request.QueryString["Mode"].ToString(),
                   Request.QueryString["Branch_Common"].ToString(),
                    Request.QueryString["SchemaCode"].ToString()
                );
         }
         else if (Request.QueryString["IMP_TALLY_EXCEL"] != "" && Request.QueryString["IMP_TALLY_EXCEL"] != null)
         {
             TALLY_Excel Excel = new TALLY_Excel();
             Excel.Open_Import_TALLY_EXCEL_XLs(
                Request.QueryString["Imp_name"].ToString(),
                 Request.QueryString["Jobno"].ToString(),
                   Request.QueryString["Branch_Common"].ToString(),
                   Request.QueryString["fromdate"].ToString(),
                   Request.QueryString["Todate"].ToString()
                );
         }
         else if (Request.QueryString["EXP_TALLY_EXCEL"] != "" && Request.QueryString["EXP_TALLY_EXCEL"] != null)
         {
             TALLY_Excel Excel = new TALLY_Excel();
             Excel.Open_Export_TALLY_EXCEL_XLs(
                Request.QueryString["Exp_name"].ToString(),
                 Request.QueryString["Jobno"].ToString(),
                   Request.QueryString["Branch_Common"].ToString(),
                   Request.QueryString["fromdate"].ToString(),
                   Request.QueryString["Todate"].ToString()
                );
         }

         else if (Request.QueryString["IMP_BILLING_GST_SUMMARY_RPT"] != "" && Request.QueryString["IMP_BILLING_GST_SUMMARY_RPT"] != null)
         {
             GST_Summary_Report IMP_GST = new GST_Summary_Report();
             IMP_GST.Open_Retail_XLs_Report(
                Request.QueryString["Imp_name"].ToString(),
                 Request.QueryString["fromdate"].ToString(),
                  Request.QueryString["Todate"].ToString(),
                   Request.QueryString["Branch_Common"].ToString()
                );
         }       
             //------------------------------------------------- GST EXP BILLING SUMMARY RPT-------------------------------------------------------------------------------//

         else if (Request.QueryString["EXP_BILLING_GST_SUMMARY_RPT"] != "" && Request.QueryString["EXP_BILLING_GST_SUMMARY_RPT"] != null)
         {
             GST_Summary_Report_Exp EXP_GST = new GST_Summary_Report_Exp();
             EXP_GST.Open_Retail_XLs_Report(
                Request.QueryString["Exp_name"].ToString(),
                 Request.QueryString["fromdate"].ToString(),
                  Request.QueryString["Todate"].ToString(),
                   Request.QueryString["Branch_Common"].ToString()
                );
         }
        
         //------------------------------------------------- SIMS RPT-------------------------------------------------------------------------------//

         else if (Request.QueryString["IMP_SIMS_RPT"] != "" && Request.QueryString["IMP_SIMS_RPT"] != null)
         {
             BAS_IMP_DSR BID = new BAS_IMP_DSR();
             BID.Open_Import_SIMS_XLs(
                Request.QueryString["stlno"].ToString(),
                 Request.QueryString["regndate"].ToString(),
                  Request.QueryString["frmdate"].ToString(),
                  Request.QueryString["todate"].ToString(),
                   Request.QueryString["Branch_Common"].ToString(),
                   Request.QueryString["jobno"].ToString()

                );
         }

         //-----------------------------------------------------------billing imp exp service tax report----------------------------------------------------------//

         if (Request.QueryString["Bill_Imp_Exp_Servicetax_Rpt"] != "" && Request.QueryString["Bill_Imp_Exp_Servicetax_Rpt"] != null)
         {
             Bill_Imp_Exp_Servicetax_Rpt rpt = new Bill_Imp_Exp_Servicetax_Rpt();
             rpt.Bil_Imp_Exp_Servicetax_XLs_Report(


                 Request.QueryString["ddl_Imp_Exp"].ToString(),
                 Request.QueryString["Fromdate"].ToString(),
                 Request.QueryString["Todate"].ToString(),
                 Request.QueryString["Mode"].ToString(),
                 Request.QueryString["Branch"].ToString(),
                 Request.QueryString["Type"].ToString()


                 );
         }

        //-----------------------------------------------------------billing imp exp service tax report----------------------------------------------------------//
        
         //------------------------------------------------------------docket entry -------------------------------------------------------------------------------//

         if (Request.QueryString["Docket_Entry_Rpt"] != "" && Request.QueryString["Docket_Entry_Rpt"] != null)
         {
             Decket_General docket = new Decket_General();
             docket.Docket_Entry_XLs_Report(

                    Request.QueryString["ddlImp_name"].ToString(),

                 Request.QueryString["Fromdate"].ToString(),
                 Request.QueryString["Todate"].ToString(),

                 Request.QueryString["Branch"].ToString(),
                 Request.QueryString["Type"].ToString()


                 );
         }
        //---------------------------------------------------------docket entry ------------------------------------------------------------------------------------//



         //------------------------GST_BILL_IMP_GSTR1_B2B_RPT---------------------------------//

         if (Request.QueryString["GST_BILL_IMP_GSTR1_B2B_RPT"] != "" && Request.QueryString["GST_BILL_IMP_GSTR1_B2B_RPT"] != null)
         {
             GST_Bil_Imp_GSTR1_B2B_Rpt rpt = new GST_Bil_Imp_GSTR1_B2B_Rpt();
             rpt.GST_BILL_IMP_GSTR1_B2B_RPT_XL(

                 Request.QueryString["ddl_Imp_Exp"].ToString(),
                 Request.QueryString["Fromdate"].ToString(),
                 Request.QueryString["Todate"].ToString(),

                 Request.QueryString["Branch"].ToString(),
                 Request.QueryString["Type"].ToString()
                 );
         }
        //---------------------GST_BILL_IMP_GSTR1_B2B_RPT---------------------------------------//


         //------------------------GST_BILL_EXP_GSTR1_B2B_RPT---------------------------------//

         if (Request.QueryString["GST_BILL_EXP_GSTR1_B2B_RPT"] != "" && Request.QueryString["GST_BILL_EXP_GSTR1_B2B_RPT"] != null)
         {
             GST_Bil_Exp_GSTR1_B2B_Rpt rpt = new GST_Bil_Exp_GSTR1_B2B_Rpt();
             rpt.GST_BILL_EXP_GSTR1_B2B_RPT_XL(

                 Request.QueryString["ddl_Imp_Exp"].ToString(),
                 Request.QueryString["Fromdate"].ToString(),
                 Request.QueryString["Todate"].ToString(),

                 Request.QueryString["Branch"].ToString(),
                 Request.QueryString["Type"].ToString()
                 );
         }
         else if (Request.QueryString["DSC"] != "" && Request.QueryString["DSC"] != null)
         {
             Common_CS CS = new Common_CS();
             CS.DSC_Download();
         }
        //---------------------GST_BILL_EXP_GSTR1_B2B_RPT---------------------------------------//


        //---------------------------------------------------------- Export_DSR_(Kalai)-----Start-----------------------------------------------------------//

        // else if (Request.QueryString["DailyStatusRpt_Export"] != "" && Request.QueryString["DailyStatusRpt_Export"] != null)
        //{
        //    DailyStatusRpt_Export DSR_L = new DailyStatusRpt_Export();

        //    DSR_L.Open_Retail_XLs_Report_Export(
        //        Request.QueryString["fromdate"].ToString(),
        //        Request.QueryString["ClientName"].ToString(),
        //        Request.QueryString["Tr_mode"].ToString(),
        //        Request.QueryString["Branch"].ToString(),
        //        Request.QueryString["Job_type"].ToString(),
        //        Request.QueryString["To_date"].ToString(),
        //        Request.QueryString["Type"].ToString()
        //        );
        //}

        //---------------------------------------------------------- Export_DSR_-(Kalai)----end-----------------------------------------------------------//

         else if (Request.QueryString["DSR_IMP_Data"] != "" && Request.QueryString["DSR_IMP_Data"] != null)
         {
             DSR_CS DR = new DSR_CS();

             DR.Open_IMP_DSR_Data(
                 Request.QueryString["Imp_name"].ToString(),
                 Request.QueryString["ddl_Jobno"].ToString(),
                 Request.QueryString["Fromdate"].ToString(),
                 Request.QueryString["Todate"].ToString(),
                 Request.QueryString["Month"].ToString()
                 );
         }

        //---------------------------------------------------------- DO_ENTRY----START-----------------------------------------------------------//

         else if (Request.QueryString["DO_DATA"] != "" && Request.QueryString["DO_DATA"] != null)
         {
             DO_Entry DO = new DO_Entry();

             DO.Open_DO_Data(
                 Request.QueryString["Imp_name"].ToString(),
                 Request.QueryString["ddl_Jobno"].ToString(),
                 Request.QueryString["Fromdate"].ToString(),
                 Request.QueryString["Todate"].ToString(),
                 Request.QueryString["Month"].ToString(),
                 Request.QueryString["Tr_Mode"].ToString());
                 
         }
         //---------------------------------------------------------- DO_ENTRY----end-----------------------------------------------------------//             
        //---------------------------------------------------------- CFS_ENTRY----START-----------------------------------------------------------//
         else if (Request.QueryString["CFS_DATA"] != "" && Request.QueryString["CFS_DATA"] != null)
         {
             DO_Entry DO = new DO_Entry();

             DO.Open_CFS_Data(
                 Request.QueryString["Imp_name"].ToString(),
                 Request.QueryString["ddl_Jobno"].ToString(),
                 Request.QueryString["Fromdate"].ToString(),
                 Request.QueryString["Todate"].ToString(),
                 Request.QueryString["Month"].ToString()
                 );
         }

        //---------------------------------------------------------- CFS_ENTRY----end-----------------------------------------------------------//
         //---------------------------------------------------------- AAI_ENTRY----START-----------------------------------------------------------//

         else if (Request.QueryString["AAI_DATA"] != "" && Request.QueryString["AAI_DATA"] != null)
         {
             DO_Entry DO = new DO_Entry();

             DO.Open_AAI_Data(
                 Request.QueryString["Imp_name"].ToString(),
                 Request.QueryString["ddl_Jobno"].ToString(),
                 Request.QueryString["Fromdate"].ToString(),
                 Request.QueryString["Todate"].ToString(),
                 Request.QueryString["Month"].ToString()
                 );
         }
         //---------------------------------------------------------- AAI_ENTRY----end-----------------------------------------------------------//

         //---------------------------------------------------------- Import_BMW_-(Chithra)----Start-----------------------------------------------------------//
         else if (Request.QueryString["IMP_BMW_EXCEL_SANCO"] != "" && Request.QueryString["IMP_BMW_EXCEL_SANCO"] != null)
         {
             BMW_Excel BMW = new BMW_Excel();
             BMW.Open_Import_SANCO_BMW_XLs(
                 Request.QueryString["Jobno"].ToString(),
                   Request.QueryString["Branch_Common"].ToString()
                );
         }
        //---------------------------------------------------------- Import_BMW_-(Chithra)----end-----------------------------------------------------------//

         //---------------------------------------------------------- Import_DUTYWORKSHEET_-(Chithra)----Start-----------------------------------------------------------//
         else if (Request.QueryString["Open_Import_DUTY_WORKSHEET_XLs"] != "" && Request.QueryString["Open_Import_DUTY_WORKSHEET_XLs"] != null)
         {
             BMW_Excel BMW = new BMW_Excel();
             BMW.Open_Import_DUTY_WORKSHEET_XLs(
                 Request.QueryString["Jobno"].ToString(),
                   Request.QueryString["Branch_Common"].ToString()
                );
         }
        //---------------------------------------------------------- Import_DUTYWORKSHEET_-(Chithra)----end-----------------------------------------------------------//


      //---------------------------------------------------------- Export_Excel_Download-(Ayisha)----Start-----------------------------------------------------------//
         else if (Request.QueryString["Open_Export_Excel_Download_XLs"] != "" && Request.QueryString["Open_Export_Excel_Download_XLs"] != null)
         {
             Export_MIS_2 expr = new Export_MIS_2();
             //expr.Open_Export_Excel_Download_XLs(
             expr.Open_Export_Excel_Download_XLSX(
                 Request.QueryString["Jobno"].ToString(),
                   Request.QueryString["Branch_Common"].ToString()
                );
         }
         //---------------------------------------------------------- Export_Excel_Download-(Ayisha)----end-----------------------------------------------------------//

              //---------------------------------------------------------- Import_Excel_Download-(Ayisha)----Start-----------------------------------------------------------//
         else if (Request.QueryString["Open_Import_Excel_Download_XLs"] != "" && Request.QueryString["Open_Import_Excel_Download_XLs"] != null)
         {
             BMW_Excel BMW = new BMW_Excel();
             //BMW.Open_Import_Excel_Download_XLs(
             BMW.Open_Import_Excel_Download_XLSX(
             Request.QueryString["Jobno"].ToString(),
               Request.QueryString["Branch_Common"].ToString()
            );
         }
         //---------------------------------------------------------- Import_Excel_Download-(Ayisha)----end-----------------------------------------------------------//


         //------------------------------------------------------------Import_DUTYWORKSHEET_ALL_DIANA---------------------------//
         else if (Request.QueryString["Open_Import_DUTY_WORKSHEET_ALL_XLs"] != "" && Request.QueryString["Open_Import_DUTY_WORKSHEET_ALL_XLs"] != null)
         {
             BMW_Excel BMW = new BMW_Excel();
             BMW.Open_Import_DUTY_WORKSHEET_ALL_XLs(
                 Request.QueryString["Jobno"].ToString(),
                   Request.QueryString["Branch_Common"].ToString()
                );
         }

         //---------------------------------------------------------- EXPORT EGM CHECKLIST EXCEL FORMAT_-(Chithra)----Start-----------------------------------------------------------//
         else if (Request.QueryString["EXP_EGM_CHECKLIST"] != "" && Request.QueryString["EXP_EGM_CHECKLIST"] != null)
         {
             EGM EGM = new EGM();
             EGM.EXPORT_EGM_CHECKLIST_XLs(
                 Request.QueryString["Jobno"].ToString(),
                   Request.QueryString["Branch_Common"].ToString(),
                    Request.QueryString["Report_Type"].ToString()
                );
         }
         //---------------------------------------------------------- EXPORT EGM CHECKLIST EXCEL FORMAT -(Chithra)----end-----------------------------------------------------------//

          //---------------------------------------------------------- EXPORT EGM CONSOLIDATE CHECKLIST EXCEL FORMAT_-(Chithra)----Start-----------------------------------------------------------//
         else if (Request.QueryString["EXP_EGM_CONSOLIDATE_CHECKLIST"] != "" && Request.QueryString["EXP_EGM_CONSOLIDATE_CHECKLIST"] != null)
         {
             EGM EGM = new EGM();
             EGM.EXPORT_EGM_CHECKLIST_XLs(
                 Request.QueryString["Jobno"].ToString(),
                   Request.QueryString["Branch_Common"].ToString(),
                    Request.QueryString["Report_Type"].ToString()
                );
         }
         //---------------------------------------------------------- EXPORT EGM CONSOLIDATE CHECKLIST EXCEL FORMAT -(Chithra)----end-----------------------------------------------------------//


         //---------------------------------------------------------- export_DSR REPORT - LIZMA_-(Chithra)----Start-----------------------------------------------------------//
         else if (Request.QueryString["DailyStatusRpt_Export_LIZMA"] != "" && Request.QueryString["DailyStatusRpt_Export_LIZMA"] != null)
         {
             DailyStatusRpt_Export DSR_L = new DailyStatusRpt_Export();



             DSR_L.Open_Retail_XLs_Report_Export_LIZMA(
                 Request.QueryString["fromdate"].ToString(),
                 Request.QueryString["ClientName"].ToString(),
                 Request.QueryString["Tr_mode"].ToString(),
                 Request.QueryString["Branch"].ToString(),
                 Request.QueryString["Job_type"].ToString(),
                 Request.QueryString["To_date"].ToString(),
                 Request.QueryString["Type"].ToString()
                 );
         }

        //---------------------------------------------------------- export_DSR REPORT - LIZMA_-(Chithra)----Start-----------------------------------------------------------//


         //---------------------------------------------------------- export_DSR REPORT - COMMON-(Chithra)----Start-----------------------------------------------------------//
         else if (Request.QueryString["DailyStatusRpt_Export"] != "" && Request.QueryString["DailyStatusRpt_Export"] != null)
         {
             DailyStatusRpt_Export DSR_L = new DailyStatusRpt_Export();



             DSR_L.Open_Retail_XLs_Report_Export(
                 Request.QueryString["fromdate"].ToString(),
                 Request.QueryString["ClientName"].ToString(),
                 Request.QueryString["Tr_mode"].ToString(),
                 Request.QueryString["Branch"].ToString(),
                 Request.QueryString["Job_type"].ToString(),
                 Request.QueryString["To_date"].ToString(),
                 Request.QueryString["Type"].ToString()
                 );
         }

        //---------------------------------------------------------- export_DSR REPORT - COMMON-(Chithra)----Start-----------------------------------------------------------//

       //---------------------------------------------------------- IMPORT CLEARANCE REPORT - International Cargo----Start-----------------------------------------------------------//
         else if (Request.QueryString["IMP_CLEARANCE_REPORT_ICC"] != "" && Request.QueryString["IMP_CLEARANCE_REPORT_ICC"] != null)
         {
             ICC Icc = new ICC();
             Icc.Open_IMP_CLEARANCE_REPORT_ICC_Xls(
                Request.QueryString["Imp_name"].ToString(),
                 Request.QueryString["Jobno"].ToString(),
                    Request.QueryString["fromdate"].ToString(),
                     Request.QueryString["todate"].ToString()
                );
         }
         //---------------------------------------------------------- IMPORT CLEARANCE REPORT - International Cargo----Start-----------------------------------------------------------//

         else if (Request.QueryString["ADC_Excel_Jobno"] != "" && Request.QueryString["ADC_Excel_Jobno"] != null)
         {
             string path = string.Empty;
             path = Server.MapPath("~/Submission/" + Connection.COMPANYID() + "/" + Connection.Current_Branch() + "/" + Connection.Current_User() + "/" + "ADC_Excel");

             if (Directory.Exists(path) == false)
             {
                 Directory.CreateDirectory(path);
             }

             if (path.Trim() != string.Empty)
             {
                 IMP_ADC IA = new IMP_ADC();
                 IA.Open_ADC_XLs_Report(path, Request.QueryString["Jobno"].ToString());
             }
         }

         else if (Request.QueryString["IMP_Classic_DSR_XL"] != "" && Request.QueryString["IMP_Classic_DSR_XL"] != null)
         {

             string path = string.Empty;
             path = Server.MapPath("~/Submission/" + Connection.COMPANYID() + "/" + Connection.Current_Branch() + "/" + Connection.Current_User() + "/" + "Classic_DSR_Excel");

             if (Directory.Exists(path) == false)
             {
                 Directory.CreateDirectory(path);
             }

             if (path.Trim() != string.Empty)
             {
                 IMP_CLASSIC_DSR ICD = new IMP_CLASSIC_DSR();

                 ICD.Open_IMP_Classic_DSR_XL_Data(
                     Request.QueryString["Imp_name"].ToString(),
                     Request.QueryString["Jobno"].ToString(),
                     Request.QueryString["Fromdate"].ToString(),
                     Request.QueryString["Todate"].ToString(),
                     Request.QueryString["Month"].ToString(),
                     Request.QueryString["Type"].ToString(),
                     path
                     );
             }
         }

         else if (Request.QueryString["BD_BOND_SUMMARY_REPORT"] != "" && Request.QueryString["BD_BOND_SUMMARY_REPORT"] != null)
         {
             ////BAS_IMP_DSR BID = new BAS_IMP_DSR();
             Bond_SummaryRpt Bond = new Bond_SummaryRpt();
             Bond.Open_Import_BD_BOND_SUMMARY_XLs(
                Request.QueryString["BondNo"].ToString(),
                 Request.QueryString["BondType"].ToString(),
                  Request.QueryString["BondLocation"].ToString(),
                   Request.QueryString["Branch_Common"].ToString(),
                    Request.QueryString["ReportType"].ToString(),
                    Request.QueryString["Jobno"].ToString()
                );
         }

         else if (Request.QueryString["IMP_TALLY_EXCEL_BILLING_OTHERS"] != "" && Request.QueryString["IMP_TALLY_EXCEL_BILLING_OTHERS"] != null)
         {
             TALLY_Billing_Others Excel = new TALLY_Billing_Others();
             Excel.Open_Import_TALLY_EXCEL_XLs(
                Request.QueryString["Imp_name"].ToString(),
                 Request.QueryString["Jobno"].ToString(),
                   Request.QueryString["Branch_Common"].ToString(),
                   Request.QueryString["fromdate"].ToString(),
                   Request.QueryString["Todate"].ToString()
                );
         }

         else if (Request.QueryString["EXP_TALLY_EXCEL_BILLING_OTHERS"] != "" && Request.QueryString["EXP_TALLY_EXCEL_BILLING_OTHERS"] != null)
         {
             TALLY_Billing_Others Excel = new TALLY_Billing_Others();
             Excel.Open_Export_TALLY_EXCEL_XLs(
                Request.QueryString["Imp_name"].ToString(),
                 Request.QueryString["Jobno"].ToString(),
                   Request.QueryString["Branch_Common"].ToString(),
                   Request.QueryString["fromdate"].ToString(),
                   Request.QueryString["Todate"].ToString()
                );
         }

         else if (Request.QueryString["CHA_CLIENT_LIST_TO_EXCEL"] != "" && Request.QueryString["CHA_CLIENT_LIST_TO_EXCEL"] != null)
         {

             Client_Master CM = new Client_Master();
             CM.Open_CHA_CLIENT_LIST_TO_EXCEL();

         }

         else if (Request.QueryString["GST_Purchase_Data"] != "" && Request.QueryString["GST_Purchase_Data"] != null)
         {
             GST_Imp_Invoice BI = new GST_Imp_Invoice();

             BI.Open_GST_Purchase_Data(
                 Request.QueryString["txtsearch"].ToString(),
                 Request.QueryString["Fromdate"].ToString(),
                 Request.QueryString["Todate"].ToString(),
                 Request.QueryString["Month"].ToString()
                 );

         }
         else if (Request.QueryString["GST_Purchase_Tds_Data"] != "" && Request.QueryString["GST_Purchase_Tds_Data"] != null)
         {
             GST_Imp_Invoice BI = new GST_Imp_Invoice();

             BI.Open_GST_Purchase_Tds_Data(
                 Request.QueryString["txtsearch"].ToString(),
                 Request.QueryString["Fromdate"].ToString(),
                 Request.QueryString["Todate"].ToString(),
                 Request.QueryString["Month"].ToString(),
                 Request.QueryString["gsttype"].ToString()

                 );

         }
         else if (Request.QueryString["GST_IMP_EXP_COMBINED_Tally_Data"] != "" && Request.QueryString["GST_IMP_EXP_COMBINED_Tally_Data"] != null)
         {
             GST_Billing_Paramount BI = new GST_Billing_Paramount();
             BI.Open_GST_IMP_EXP_COMBINED_Tally_Data(
                 Request.QueryString["ddlSearch_Cat"].ToString(),
                 Request.QueryString["txtsearch"].ToString(),
                 Request.QueryString["Imp_name"].ToString(),
                 Request.QueryString["Fromdate"].ToString(),
                 Request.QueryString["Todate"].ToString(),
                 Request.QueryString["Month"].ToString(),
                 Request.QueryString["Type"].ToString(),
                 Request.QueryString["Imp_Exp"].ToString()
                 );
         }
         //---------------------------------------Transport bill---------------------------
         else if (Request.QueryString["Transport_Tally_Data"] != "" && Request.QueryString["Transport_Tally_Data"] != null)
         {
             GST_Transport TOM = new GST_Transport();
             TOM.Open_Transport_Tally_Data(
                 Request.QueryString["ddlSearch_Cat"].ToString(),
                 Request.QueryString["txtsearch"].ToString(),
                 Request.QueryString["Imp_name"].ToString(),
                 Request.QueryString["Fromdate"].ToString(),
                 Request.QueryString["Todate"].ToString(),
                 Request.QueryString["Month"].ToString(),
                 Request.QueryString["Type"].ToString()
                 );
         }
        //-----------------------------------transportbill end-------------------------------
         //else if (Request.QueryString["GST_IMP_EXP_CREDIT_NOTE_Tally_Data"] != "" && Request.QueryString["GST_IMP_EXP_CREDIT_NOTE_Tally_Data"] != null)
         //{
         //    GST_Credit_Note_Entry_cs BI = new GST_Credit_Note_Entry_cs();
         //    BI.Open_GST_IMP_EXP_CREDIT_NOTE_Tally_Data(
         //        Request.QueryString["ddlSearch_Cat"].ToString(),
         //        Request.QueryString["txtsearch"].ToString(),
         //        Request.QueryString["Imp_name"].ToString(),
         //        Request.QueryString["Fromdate"].ToString(),
         //        Request.QueryString["Todate"].ToString(),
         //        Request.QueryString["Month"].ToString(),
         //        Request.QueryString["Type"].ToString(),
         //        Request.QueryString["Imp_Exp"].ToString()
         //        );
         //} 

         else if (Request.QueryString["Imp_Exp_Json"] != "" && Request.QueryString["Imp_Exp_Json"] != null)
         {

             GST_Transport iejs = new GST_Transport();
             iejs.Submission_Imp_Json(
             Request.QueryString["Jobno"].ToString(),

             Request.QueryString["Imp_Exp"].ToString()
             );
         }

         //--------------------------------------------------------Exp Summary Rpt--MIS--info--------------------------------------------------------------//
         else if (Request.QueryString["Exp_MIS_rpt_Opt"] != "" && Request.QueryString["Exp_MIS_rpt_Opt"] != null)
         {
             Export_MIS_2 MIS_data = new Export_MIS_2();
             MIS_data.Open_Exp_MIS_XLs_Report(
                 Request.QueryString["Jobdate"].ToString(),
                 Request.QueryString["Exp_name"].ToString(),
                 Request.QueryString["Tr_mode"].ToString(),
                 Request.QueryString["Branch"].ToString(),
                 Request.QueryString["SB_type"].ToString(),
                 Request.QueryString["Report_cat"].ToString(),
                 Request.QueryString["Port"].ToString(),
                 Request.QueryString["Type"].ToString(),
                 Request.QueryString["Todate"].ToString(),
                 Request.QueryString["Country"].ToString(),
                 Request.QueryString["UserID"].ToString(),
                 Request.QueryString["CustHouse"].ToString()// Added by George Bush on 09-06-2026


                 );
         }
         else if (Request.QueryString["PDFsettingexcel"] != "" && Request.QueryString["PDFsettingexcel"] != null)
         {
             UserBO ObjUBO = new UserBO();
             Import_XL_Upload xl = new Import_XL_Upload();
              ObjUBO.Ename = "Download_Pdf_Setting_Master_Excel_Data";
              xl.GetDataFromSP(ObjUBO.Ename, ObjUBO);
              
         }

    }

}