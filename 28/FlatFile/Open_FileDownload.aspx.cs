using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessObject;

public partial class _Default : System.Web.UI.Page
{
    AppSession aps = new AppSession();
    protected void Page_Load(object sender, EventArgs e)
{
    aps.checkSession();
    //----------------------------------------------------------FOR Export_File----------------------------------------------------------------//

    Export_FlatFile_Generation flatfile = new Export_FlatFile_Generation();
    //string errorFolder = HttpContext.Current.Server.MapPath("~/Submission/");
         string errorFolder="";
         //string query = Request.QueryString["Query"].ToString();
         if (Request.QueryString["inbox"] != "" && Request.QueryString["inbox"] != null)
        {
            errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "UploadFiles/");
            flatfile.Open_Textfile(errorFolder, Request.QueryString["inbox"].ToString());
        }
         else if (Request.QueryString["Query"] == "ETP_Json")
         {
             errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + "Export_ETP" + "/" + Session["currentuser"].ToString() + "/");  
             flatfile.Open_Textfile(errorFolder);
         }
         else if (Request.QueryString["Query"] == "ETP_Text_FF")
         {
             //errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + "Export_ETP" + "/" + "Flatfile" + "/" + Session["currentuser"].ToString() + "/");
             errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + "Export_ETP" + "/" + Session["currentuser"].ToString() + "/");  
             flatfile.Open_Textfile(errorFolder);
         }
         else if (Request.QueryString["Query"] == "DTA_SEZ_Json")
         {
             errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + "Export_DTA_SEZ" + "/" + Session["currentuser"].ToString() + "/");
             flatfile.Open_Textfile(errorFolder);
         }
        else if(Request.QueryString["Query"]=="Imp_Query_Reply")
        {
            errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "Query_Reply/");
            flatfile.Open_Textfile(errorFolder);
         }
         else if (Request.QueryString["Query"] == "Exp_Query_Reply")
         {
             errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "Query_Reply/");
             flatfile.Open_Textfile(errorFolder);
         }
         else if (Request.QueryString["Query"] == "I_e_Way_Bill")
         {
             errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + "eWayBill" + "/" + Session["currentuser"].ToString() + "/");
             flatfile.Open_Textfile(errorFolder);
         }
         else if (Request.QueryString["Query"] == "I_e_Way_Bill_Zip")
         {
             errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + "eWayBill_Zip" + "/" + Session["currentuser"].ToString() + "/");
             flatfile.Open_Imp_Eway_Bill_Zip(errorFolder);
         }
         else if (Request.QueryString["Query"] == "GSTBill_Import")
         {
             errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + "FlatFile" + "/" + Session["currentuser"].ToString() + "/");
             flatfile.Open_Textfile(errorFolder);
         }
         else if (Request.QueryString["IMP_EXP"] == "I")
         {
             if (Connection.COMPANYID() != "747")
             {
                 Imp_Exp_Job_Status IEJ = new Imp_Exp_Job_Status();
                 Global_variables ObjUBO = new Global_variables();
                 ObjUBO.A1 = Request.QueryString["IJOBID"].ToString();
                 ObjUBO.A3 = "BE_Sent";
                 IEJ.Job_Status(ObjUBO);
             }

             errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/");
             flatfile.Open_Textfile(errorFolder);
         }
         else if (Request.QueryString["IMP_EXP"] == "E")
         {
             Imp_Exp_Job_Status IEJ = new Imp_Exp_Job_Status();
             Global_variables ObjUBO = new Global_variables();
             ObjUBO.A1 = Request.QueryString["EJOBID"].ToString();
             ObjUBO.A3 = "SB_Sent";
             IEJ.Job_Status(ObjUBO);

             errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/");
             flatfile.Open_Textfile(errorFolder);
         } 
        else
        {
             errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/");
             flatfile.Open_Textfile(errorFolder);
         } 
      //----------------------------------------------------------FOR Export_File----------------------------------------------------------------//


      //----------------------------------------------------------FOR CusRes_report----------------------------------------------------------------//
         if (Request.QueryString["CusRes_report"] != "" && Request.QueryString["CusRes_report"] != null)
         {
             CheckList cures = new CheckList();
             cures.Open_CusRes_XLs_Report(Request.QueryString["JOB_NO"].ToString(),Session["WorkingPeriod"].ToString(),Request.QueryString["BE_NO"].ToString());
         }
      //----------------------------------------------------------FOR CusRes_report----------------------------------------------------------------//

         //----------------------------------------------------------MIS--info--------------------------------------------------------------//
         if (Request.QueryString["MIS_rpt"] != "" && Request.QueryString["MIS_rpt"] != null)
         {
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
             //        Request.QueryString["Country"].ToString()
             //        );
             //}
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

         //----------------------------------------------------------MIS--statment---start-----------------------------------------------------------//
         if (Request.QueryString["MIS_stat"] != "" && Request.QueryString["MIS_stat"] != null)
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

         //---------------------------------------------------------- RetailSales--statment-----end-----------------------------------------------------------//

         //if (Request.QueryString["Retail_St"] != "" && Request.QueryString["Retail_St"] != null)
         //{


         //    Retail_Stmts Retail_Stt = new Retail_Stmts();
         //    Retail_Stt.Open_Retail_XLs_Report(
         //        Request.QueryString["fromdate"].ToString(),
         //        Request.QueryString["Imp_name"].ToString(),
         //        Request.QueryString["Tr_mode"].ToString(),
         //        Request.QueryString["Branch"].ToString(),
         //        Request.QueryString["Job_type"].ToString(),
         //        Request.QueryString["To_date"].ToString(),
         //        Request.QueryString["Type"].ToString()

         //        );
         //}

    //---------------------------------------------------------- RetailSales--statment-----end-----------------------------------------------------------//


         //----------------------------------------------------------FOR TP2_Excel_report----------------------------------------------------------------//
         if (Request.QueryString["TP2_Excel_report"] != "" && Request.QueryString["TP2_Excel_report"] != null)
         {
             TransPermit Tp = new TransPermit();
             Tp.Open_TP2_XLs_Report(Request.QueryString["JOB_NO"].ToString());

         }
    }
}