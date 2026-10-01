using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Web;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;



public partial class eRoyalMasters_Adcode_Master : ThemeClass
{
    StringBuilder sb = new StringBuilder();
    StringBuilder sb_File = new StringBuilder();
    StringBuilder sb_RandNo = new StringBuilder();
    AppSession aps = new AppSession();
    User_Creation user_Create = new User_Creation();
    ErrorLogs er = new ErrorLogs();
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public int a,Update_Id;
    public string AUTO_ID, inbox_id;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id, TO_ADDRESS, RAND_ID, Checklist_Attach, CHECKLIST_NAME;

    public string SELECT_TYPE, SELECT_BRANCH, Attach_Folder;
    public string COMPANY_ID = "";

    public int Screen_Id;
    DataSet ds = new DataSet();
    DataTable dtuser = new DataTable();
    Maildb mdb = new Maildb();
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        Checklist_Attach = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/"+"Checklist_Attach"+"/");
        
        COMPANY_ID = Session["COMPANY_ID"].ToString();

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
            gvdetails.Visible = false;
            if (Directory.Exists(Checklist_Attach) == false)
            {
                Directory.CreateDirectory(Checklist_Attach);
            }
            if (Request.QueryString["EXP_Pl_Rpt_1_Excel"] != "" && Request.QueryString["EXP_Pl_Rpt_1_Excel"] != null)
            {
                EXP_Grid_excel();
            }
            else if (Request.QueryString["IMP_Pl_Rpt_Excel"] != "" && Request.QueryString["IMP_Pl_Rpt_Excel"] != null)
            {
                IMP_PL_Grid_excel();
            }
            else if (Request.QueryString["IMP_Pl_Rpt_1_Excel"] != "" && Request.QueryString["IMP_Pl_Rpt_1_Excel"] != null)
            {
                IMP_PL_1_Grid_excel();
            }
            else if (Request.QueryString["EXP_MIS_Rpt"] != "" && Request.QueryString["EXP_MIS_Rpt"] != null)
            {
                EXP_MIS_Rpt();
            }
            else if (Request.QueryString["IMP_MIS_Rpt_1"] != "" && Request.QueryString["IMP_MIS_Rpt_1"] != null)
            {
                IMP_MIS_1();
            }
            else if (Request.QueryString["IMP_MIS_Rpt_2"] != "" && Request.QueryString["IMP_MIS_Rpt_2"] != null)
            {
                IMP_MIS_2();
            }
            else if (Request.QueryString["IMP_MIS_Rpt_3"] != "" && Request.QueryString["IMP_MIS_Rpt_3"] != null)
            {
                IMP_MIS_3();
            }
            else if (Request.QueryString["IMP_MIS_Rpt_4"] != "" && Request.QueryString["IMP_MIS_Rpt_4"] != null)
            {
                IMP_MIS_3();
            }
            else if (Request.QueryString["DSR"] != "" && Request.QueryString["DSR"] != null)
            {
                DSR();
            }
            else if (Request.QueryString["Job_Filed_Status"] != "" && Request.QueryString["Job_Filed_Status"] != null)
            {
                Job_Filed_status();
            }
            else if (Request.QueryString["BL_Pending_Job"] != "" && Request.QueryString["BL_Pending_Job"] != null)
            {
                Exp_BL_Pending_Job_Status();
            }
            else if (Request.QueryString["Exp_Summary"] != "" && Request.QueryString["Exp_Summary"] != null)
            {
                Exp_Summary();
            }
            else if (Request.QueryString["Multiple_BL_Pending_Job"] != "" && Request.QueryString["Multiple_BL_Pending_Job"] != null)
            {
                Exp_Multiple_BL_pending_Jobs();
            }
            else if (Request.QueryString["Exp_Summary"] != "" && Request.QueryString["Exp_Summary"] != null)
            {
                Exp_Summary();
            }
            else if (Request.QueryString["Imp_Summary"] != "" && Request.QueryString["Imp_Summary"] != null)
            {
                Imp_Summary();
            }
            else if (Request.QueryString["Imp_Summary_Two"] != "" && Request.QueryString["Imp_Summary_Two"] != null)
            {
                Imp_Summary_Two();
            }
            else if (Request.QueryString["NIN_IMP_Item"] != "" && Request.QueryString["NIN_IMP_Item"] != null)
            {
                INDEV_NISSAN_JOB();
            }
            else if (Request.QueryString["NIN_IMP_Item_new"] != "" && Request.QueryString["NIN_IMP_Item_new"] != null)
            {
                INDEV_NISSAN_JOB_New();
            }
            else if (Request.QueryString["IND_NIS_MONTH"] != "" && Request.QueryString["IND_NIS_MONTH"] != null)
            {
                INDEV_NISSAN_MONTH();
            }
            else if (Request.QueryString["IND_NIS_FTA"] != "" && Request.QueryString["IND_NIS_FTA"] != null)
            {
                INDEV_NISSAN_FTA();
            }
            else if (Request.QueryString["INDEV_NIS_EXP_PART_LEVEL"] != "" && Request.QueryString["INDEV_NIS_EXP_PART_LEVEL"] != null)
            {
                INDEV_NISSAN_EXP_PART_LEVEL_DATA();
            }
            else if (Request.QueryString["INDEV_NIS_IMP_DSR_Rpt"] != "" && Request.QueryString["INDEV_NIS_IMP_DSR_Rpt"] != null)
            {
                INDEV_NISSAN_IMP_DSR_Rpt();
            }
            else if (Request.QueryString["INDEV_NIS_IMP_DSR_Rack_Rpt"] != "" && Request.QueryString["INDEV_NIS_IMP_DSR_Rack_Rpt"] != null)
            {
                 INDEV_NISSAN_IMP_DSR_Rack_Rpt();
            }
            else if (Request.QueryString["INDEV_NIS_IMP_DSR_Summary_Rpt"] != "" && Request.QueryString["INDEV_NIS_IMP_DSR_Summary_Rpt"] != null)
            {
                INDEV_NISSAN_IMP_DSR_Summary_Rpt();
            }
            else if (Request.QueryString["EXPO_FREIGHT_RPT_I"] != "" && Request.QueryString["EXPO_FREIGHT_RPT_I"] != null)
            {
                IMP_EXPO_frieght_Rpt();
            }
            else if (Request.QueryString["DutyIntimation"] != "" && Request.QueryString["DutyIntimation"] != null)
            {
                gvdetails.Visible = true;

                Duty_Intimation duty = new Duty_Intimation();
                DataSet dss = new DataSet();
                duty.JOBNO = Session["JobNo"].ToString();
                duty.BRANCH_CODE = SELECT_BRANCH;
                duty.Ename = "Email_Read_Select";
                dss = duty.EmailsRead();

                gvdetails.DataSource = dss.Tables[0];
                gvdetails.DataBind();
            }
            else
            {
                BytsToPDF();
            }
        }
        Attach_Folder = HttpContext.Current.Server.MapPath("~/Submission/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + HttpContext.Current.Session["currentbranch"].ToString() + "/" + "Attachments/");
        
    }
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
        }
    }
    protected void lnkDownload_Click(object sender, EventArgs e)
    {
        LinkButton lnkbtn = sender as LinkButton;
        GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
        string a = gvdetails.DataKeys[gvrow.RowIndex].Value.ToString();
        string filePath = Attach_Folder + a;

        Response.ContentType = "Text/Plain";
        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");

        Response.TransmitFile(filePath);
        Response.End();
    }
    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //Add CSS class on header row.
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        //Add CSS class on normal row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        //Add CSS class on alternate row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    
    private void IMP_PL_Grid_excel()
    {
        Pl_Report PL = new Pl_Report();
        PL.Open_PL_XLs_Mail(
        Request.QueryString["Jobdate"].ToString(),
        Request.QueryString["Imp_name"].ToString(),
        Request.QueryString["Tr_mode"].ToString(),

        Request.QueryString["jobno"].ToString(),
        Request.QueryString["Todate"].ToString(),
        Request.QueryString["Type"].ToString()
        );
    }
    private void IMP_PL_1_Grid_excel()
    {
        Pl_Report PL = new Pl_Report();
        PL.IMP_PL_1_XLs_Mail(
                        Request.QueryString["Jobdate"].ToString(),
                        Request.QueryString["Todate"].ToString(),

                        Request.QueryString["Imp_name"].ToString(),
                        Request.QueryString["Branch"].ToString(),

                        Request.QueryString["Type"].ToString()
        );
    }
    private void EXP_Grid_excel()
    {
        EXP_PL_Report_1 PL = new EXP_PL_Report_1();
        PL.PL_1_XLs_PDF_Excel_Attach(
                        Request.QueryString["Jobdate"].ToString(),
                        Request.QueryString["Todate"].ToString(),

                        Request.QueryString["Imp_name"].ToString(),
                        Request.QueryString["Branch"].ToString(),

                        Request.QueryString["Type"].ToString(),
                        Request.QueryString["Job_Type"].ToString(),
                        Request.QueryString["PL"].ToString()
        );
    
    }
    private void EXP_MIS_Rpt()
    {
        Export_MIS_2 EXP_MIS = new Export_MIS_2();
        EXP_MIS.Open_EXP_MIS_XLs_Mail(
             Request.QueryString["JobNo"].ToString(),
             Request.QueryString["Jobdate"].ToString(),
             Request.QueryString["Exp_name"].ToString(),
             Request.QueryString["To_date"].ToString(),
             Request.QueryString["Branch"].ToString(),
            Request.QueryString["Type"].ToString()
            );

    
    }
    private void IMP_MIS_1()
    { 
         MIS_rpt MIS_data = new MIS_rpt();
         MIS_data.MIS_XLs_Report_1_Mail(
                 Request.QueryString["Jobdate"].ToString(),
                 Request.QueryString["Imp_name"].ToString(),
                 Request.QueryString["Tr_mode"].ToString(),
                 Request.QueryString["Branch"].ToString(),
                 Request.QueryString["BE_type"].ToString(),
                 Request.QueryString["Report_cat"].ToString(),
                 Request.QueryString["Port"].ToString(),
                 Request.QueryString["Type"].ToString(),
                 Request.QueryString["Todate"].ToString(),
                 Request.QueryString["Country"].ToString()
                 );
    }
    private void IMP_MIS_2()
    {
        MIS_rpt MIS_data = new MIS_rpt();
        MIS_data.Open_MIS_2_XLs_Mail(
        Request.QueryString["Jobdate"].ToString(),
        Request.QueryString["Imp_name"].ToString(),
        Request.QueryString["Tr_mode"].ToString(),

        Request.QueryString["jobno"].ToString(),
        Request.QueryString["Todate"].ToString(),
        Request.QueryString["Type"].ToString()
        );
    }

    private void IMP_MIS_3()
    {
        ExpeditorsRpt EXP = new ExpeditorsRpt();
        EXP.Open_Retail_XLs_Expeditors_Mail(
            Request.QueryString["fromdate"].ToString(),
            Request.QueryString["ClientName"].ToString(),
            Request.QueryString["Tr_mode"].ToString(),
            Request.QueryString["Branch"].ToString(),
            Request.QueryString["Job_type"].ToString(),
            Request.QueryString["To_date"].ToString(),
            Request.QueryString["Type"].ToString()
            );
    }

    private void DSR()
    {
        DailyStatusRpt DSR_L = new DailyStatusRpt();
        DSR_L.Open_Retail_XLs_Mail(
            Request.QueryString["fromdate"].ToString(),
            Request.QueryString["ClientName"].ToString(),
            Request.QueryString["Tr_mode"].ToString(),
            Request.QueryString["Branch"].ToString(),
            Request.QueryString["Job_type"].ToString(),
            Request.QueryString["To_date"].ToString(),
            Request.QueryString["Type"].ToString()
            );
    }

    private void Job_Filed_status()
    {
        if (Request.QueryString["Job_Filed_Status"] != "" && Request.QueryString["Job_Filed_Status"] != null)
        {
            Imp_Exp_Job_Filed_Status JFS = new Imp_Exp_Job_Filed_Status();
            JFS.Open_JFS_XLs_Mail(
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
    }
    private void Exp_BL_Pending_Job_Status()
    {
        if (Request.QueryString["BL_Pending_Job"] != "" && Request.QueryString["BL_Pending_Job"] != null)
        {
            EXP_BL_Pending_Status EBL = new EXP_BL_Pending_Status();
            EBL.Open_BLP_XLs_Mail(
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
    }
    private void Exp_Summary()
    {
        if (Request.QueryString["Exp_Summary"] != "" && Request.QueryString["Exp_Summary"] != null)
        {
            Export_Summary ES = new Export_Summary();
            ES.Load_Summary_Report_Data_Xls_Mail(
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
    
    }
    private void Exp_Multiple_BL_pending_Jobs()
     {
         if (Request.QueryString["Multiple_BL_Pending_Job"] != "" && Request.QueryString["Multiple_BL_Pending_Job"] != null)
        {
            Export_BL_Multiple EMBL = new Export_BL_Multiple();
            EMBL.Open_Multiple_BL__XLs_Mail_Report(
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
        
     }
    private void Imp_Summary()
    {
        if (Request.QueryString["Imp_Summary"] != "" && Request.QueryString["Imp_Summary"] != null)
        {
            Import_Summary IS = new Import_Summary();
            IS.Load_Summary_Report_Data_Xls_Mail(
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

    }
    private void Imp_Summary_Two()
    {
        if (Request.QueryString["Imp_Summary_Two"] != "" && Request.QueryString["Imp_Summary_Two"] != null)
        {
            Import_SummaryTwo IS = new Import_SummaryTwo();
            IS.Load_Summary_Report_Data_Xls_Mail(
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

    }
    private void INDEV_NISSAN_JOB()
    {
        if (Request.QueryString["NIN_IMP_Item"] != "" && Request.QueryString["NIN_IMP_Item"] != null)
        {
            IMP_Item_Rpt IIR = new IMP_Item_Rpt();
            IIR.Load_IMP_Report_Data_Xls_Mail(
               Request.QueryString["Jobno"].ToString(),
               Request.QueryString["Branch"].ToString()
               );
        }
    }
    private void INDEV_NISSAN_JOB_New()
    {
        if (Request.QueryString["NIN_IMP_Item_new"] != "" && Request.QueryString["NIN_IMP_Item_new"] != null)
        {
            IMP_Item_Rpt IIR = new IMP_Item_Rpt();
            IIR.Load_IMP_Report_Data_Xls_Mail_New(
                Request.QueryString["Jobno"].ToString(),
                Request.QueryString["ddlImp_name"].ToString(),
                Request.QueryString["Fromdate"].ToString(),
                Request.QueryString["Todate"].ToString(),
                Request.QueryString["Month"].ToString()
               );





        }
    }

    private void INDEV_NISSAN_MONTH()
    {
        if (Request.QueryString["IND_NIS_MONTH"] != "" && Request.QueryString["IND_NIS_MONTH"] != null)
        {
            IMP_Item_Rpt IIR = new IMP_Item_Rpt();
            IIR.Load_IND_NIS_Month_XLs_Report_Mail(

               Request.QueryString["Jobno"].ToString(),
               Request.QueryString["ddl_Imp_name"].ToString(),
               Request.QueryString["txtfromdate"].ToString(),
               Request.QueryString["txttodate"].ToString(),
               Request.QueryString["ddlmonth"].ToString(),
               Request.QueryString["Branch"].ToString()
               );
        }
    }
    private void INDEV_NISSAN_FTA()
    {
        if (Request.QueryString["IND_NIS_FTA"] != "" && Request.QueryString["IND_NIS_FTA"] != null)
        {
            IMP_Item_Rpt IIR = new IMP_Item_Rpt();
            IIR.Load_IND_NIS_FTA_XLs_Report_Mail(

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
    }
     private void INDEV_NISSAN_EXP_PART_LEVEL_DATA()
    {
        if (Request.QueryString["INDEV_NIS_EXP_PART_LEVEL"] != "" && Request.QueryString["INDEV_NIS_EXP_PART_LEVEL"] != null)
        {

            EXP_INDEV_NISSAN_RPT EIN = new EXP_INDEV_NISSAN_RPT();
            EIN.Load_IND_NIS_PART_LEVEL_DATA_XLs_Report_Mail(
               Request.QueryString["ddl_Exp_name"].ToString(),
               Request.QueryString["txtfromdate"].ToString(),
               Request.QueryString["txttodate"].ToString(),
               Request.QueryString["ddlmonth"].ToString(),
               Request.QueryString["Branch"].ToString()
               );


        }
    }
     private void INDEV_NISSAN_IMP_DSR_Rpt()
     {
         if (Request.QueryString["INDEV_NIS_IMP_DSR_Rpt"] != "" && Request.QueryString["INDEV_NIS_IMP_DSR_Rpt"] != null)
         {
             IMP_INDEV_DSR_Entry IDSR = new IMP_INDEV_DSR_Entry();
             IDSR.Load_IND_NIS_DSR_Mail(
                 Request.QueryString["Jobno"].ToString(),
                 Request.QueryString["ddljobtypes"].ToString(),
                 Request.QueryString["txtfromdate"].ToString(),
                 Request.QueryString["txttodate"].ToString(),
                 Request.QueryString["ddlmonth"].ToString(),
                 Request.QueryString["Branch"].ToString()
                 );


         }
     }
     private void INDEV_NISSAN_IMP_DSR_Rack_Rpt()
     {
         if (Request.QueryString["INDEV_NIS_IMP_DSR_Rack_Rpt"] != "" && Request.QueryString["INDEV_NIS_IMP_DSR_Rack_Rpt"] != null)
         {
             INDEV_IMP_DSR_Rack_Rpt IDSRR = new INDEV_IMP_DSR_Rack_Rpt();
             IDSRR.Load_IND_NIS_DSR_Rack__Mail(
                 Request.QueryString["Jobno"].ToString(),
                 Request.QueryString["txtfromdate"].ToString(),
                 Request.QueryString["txttodate"].ToString(),
                 Request.QueryString["ddlmonth"].ToString(),
                 Request.QueryString["Branch"].ToString()
                 );
         }
     }
    private void INDEV_NISSAN_IMP_DSR_Summary_Rpt()
     {
         if (Request.QueryString["INDEV_NIS_IMP_DSR_Summary_Rpt"] != "" && Request.QueryString["INDEV_NIS_IMP_DSR_Summary_Rpt"] != null)
         {
             IMP_INDEV_Summary IDSRR = new IMP_INDEV_Summary();
             IDSRR.Load_IND_NIS_DSR_Summary_Mail(
                 Request.QueryString["Jobno"].ToString(),
                 Request.QueryString["txtfromdate"].ToString(),
                 Request.QueryString["txttodate"].ToString(),
                 Request.QueryString["ddlmonth"].ToString(),
                 Request.QueryString["Branch"].ToString()
                 );
         }
     }

    private void IMP_EXPO_frieght_Rpt()
    {
        if (Request.QueryString["EXPO_FREIGHT_RPT_I"] != "" && Request.QueryString["EXPO_FREIGHT_RPT_I"] != null)
        {
            IMP_Expo_Freight IEF = new IMP_Expo_Freight();
            IEF.Load_EXPO_FREIGHT_RPT_I_XLs_Mail(
               Request.QueryString["txtfromdate"].ToString(),
               Request.QueryString["txttodate"].ToString(),
               Request.QueryString["ddlmonth"].ToString(),
               Request.QueryString["Branch"].ToString(),
               Request.QueryString["ddljobno"].ToString()
               );
        }
    }
    
    protected void btnSend_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["EXP_Pl_Rpt_1_Excel"] != "" && Request.QueryString["EXP_Pl_Rpt_1_Excel"] != null)
            {
                EXP_Grid_excel();
                mail(Session["EXP_Grid_Excel"].ToString());  
            }
            else if (Request.QueryString["IMP_Pl_Rpt_Excel"] != "" && Request.QueryString["IMP_Pl_Rpt_Excel"] != null)
            {
                IMP_PL_Grid_excel();
                mail(Session["IMP_PL_Grid_Excel"].ToString()); 
            }
            else if (Request.QueryString["IMP_Pl_Rpt_1_Excel"] != "" && Request.QueryString["IMP_Pl_Rpt_1_Excel"] != null)
            {
                IMP_PL_1_Grid_excel();
                mail(Session["IMP_PL_1_Grid_Excel"].ToString()); 
            }
            else if (Request.QueryString["EXP_MIS_Rpt"] != "" && Request.QueryString["EXP_MIS_Rpt"] != null)
            {
                EXP_MIS_Rpt();
                mail(Session["EXP_MIS_Grid_Excel"].ToString()); 
            }
            else if (Request.QueryString["IMP_MIS_Rpt_1"] != "" && Request.QueryString["IMP_MIS_Rpt_1"] != null)
            {
                IMP_MIS_1();
                mail(Session["IMP_MIS_1_Grid_Excel"].ToString()); 
            }
            else if (Request.QueryString["IMP_MIS_Rpt_2"] != "" && Request.QueryString["IMP_MIS_Rpt_2"] != null)
            {
                IMP_MIS_2();
                mail(Session["IMP_MIS_2_Grid_Excel"].ToString()); 

            }
            else if (Request.QueryString["IMP_MIS_Rpt_3"] != "" && Request.QueryString["IMP_MIS_Rpt_3"] != null)
            {
                IMP_MIS_3();
                mail(Session["IMP_MIS_3_Grid_Excel"].ToString()); 
            }
            else if (Request.QueryString["IMP_MIS_Rpt_4"] != "" && Request.QueryString["IMP_MIS_Rpt_4"] != null)
            {
                IMP_MIS_3();
                mail(Session["IMP_MIS_3_Grid_Excel"].ToString()); 
            }
            else if (Request.QueryString["DSR"] != "" && Request.QueryString["DSR"] != null)
            {
                DSR();
                mail(Session["DSR"].ToString()); 
            }
            else if (Request.QueryString["Job_Filed_Status"] != "" && Request.QueryString["Job_Filed_Status"] != null)
            {
                Job_Filed_status();
                mail(Session["IMP_EXP_JobStauts"].ToString());
            }

            else if (Request.QueryString["BL_Pending_Job"] != "" && Request.QueryString["BL_Pending_Job"] != null)
            {
                Exp_BL_Pending_Job_Status();
                mail(Session["BL_Pending_Jobs"].ToString());
            }
            else if (Request.QueryString["Exp_Summary"] != "" && Request.QueryString["Exp_Summary"] != null)
            {
                Exp_Summary();
                mail(Session["Export_Summary"].ToString());
            }

            else if (Request.QueryString["Multiple_BL_Pending_Job"] != "" && Request.QueryString["Multiple_BL_Pending_Job"] != null)
            {
                Exp_Multiple_BL_pending_Jobs();
                mail(Session["EXP_MBL_Pending_Jobs"].ToString());
            }                
            else if (Request.QueryString["Imp_Summary"] != "" && Request.QueryString["Imp_Summary"] != null)
            {
                Imp_Summary();
                mail(Session["Import_Summary"].ToString());
            }
            else if (Request.QueryString["Imp_Summary_Two"] != "" && Request.QueryString["Imp_Summary_Two"] != null)
            {
                Imp_Summary_Two();
                mail(Session["Imp_Summary_Two"].ToString());
            }

            else if (Request.QueryString["NIN_IMP_Item"] != "" && Request.QueryString["NIN_IMP_Item"] != null)
            {
                INDEV_NISSAN_JOB();
                mail(Session["IMP_NIS_ITEM_CHK_RPT"].ToString()); 
            }
            else if (Request.QueryString["NIN_IMP_Item_new"] != "" && Request.QueryString["NIN_IMP_Item_new"] != null)
            {
                INDEV_NISSAN_JOB_New();
                mail(Session["IMP_NIS_ITEM_CHK_RPT_New"].ToString()); 
            }

            else if (Request.QueryString["IND_NIS_MONTH"] != "" && Request.QueryString["IND_NIS_MONTH"] != null)
            {
                INDEV_NISSAN_MONTH();
                mail(Session["INDEV_NIS_MONTH_RPT"].ToString());
            }
            else if (Request.QueryString["IND_NIS_FTA"] != "" && Request.QueryString["IND_NIS_FTA"] != null)
            {
                INDEV_NISSAN_FTA();
                mail(Session["INDEV_NIS_FTA_RPT"].ToString());
            }
            else if (Request.QueryString["INDEV_NIS_EXP_PART_LEVEL"] != "" && Request.QueryString["INDEV_NIS_EXP_PART_LEVEL"] != null)
            {
                INDEV_NISSAN_EXP_PART_LEVEL_DATA();
                mail(Session["INDEV_NIS_PART_LEVEL_DATA"].ToString());
            }
            else if (Request.QueryString["INDEV_NIS_IMP_DSR_Rpt"] != "" && Request.QueryString["INDEV_NIS_IMP_DSR_Rpt"] != null)
            {
                INDEV_NISSAN_IMP_DSR_Rpt();
                mail(Session["INDEV_NIS_DSR"].ToString());
            }
            else if (Request.QueryString["INDEV_NIS_IMP_DSR_Rack_Rpt"] != "" && Request.QueryString["INDEV_NIS_IMP_DSR_Rack_Rpt"] != null)
            {
                INDEV_NISSAN_IMP_DSR_Rack_Rpt();
                mail(Session["INDEV_NIS_DSR_Rack"].ToString());
            }
            else if (Request.QueryString["INDEV_NIS_IMP_DSR_Summary_Rpt"] != "" && Request.QueryString["INDEV_NIS_IMP_DSR_Summary_Rpt"] != null)
            {
                INDEV_NISSAN_IMP_DSR_Summary_Rpt();
                mail(Session["INDEV_NIS_Summary"].ToString());
            }

            else if (Request.QueryString["EXPO_FREIGHT_RPT_I"] != "" && Request.QueryString["EXPO_FREIGHT_RPT_I"] != null)
            {
                IMP_EXPO_frieght_Rpt();
                mail(Session["EXPO_Freight_RPT_1"].ToString());
            }

            else if (Request.QueryString["DutyIntimation"] != "" && Request.QueryString["DutyIntimation"] != null)
            {
                BytsToPDF();
                Duty_Intimation_mail(Checklist_Attach + CHECKLIST_NAME);
            }
            else
            {
                BytsToPDF();
                mail(Checklist_Attach + CHECKLIST_NAME);
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public DataSet Search_Insert_Update_Delete(string flag)
    {
        mdb.COMPANY_ID = Session["COMPANY_ID"].ToString();
        mdb.USER_CREATION_ID = Session["USER_CREATION_ID"].ToString();
        mdb.CUSTOM_HOUSE = Session["CUSTOMHOUSE_CODE"].ToString();
        mdb.IMAP_SERVER = "";
        mdb.SERVERTYPE = "SMTP";

        mdb.USER_NAME = "";
        mdb.PWD = "";
        mdb.FOLDER = "";
        mdb.PORT = "";
        mdb.Ename = flag;

        mdb.BRANCH_COMMON = SELECT_BRANCH;
        mdb.BRANCH_CODE = currentbranch;
        mdb.WORKINGPERIOD = Working_Period;
        //mdb.CREATEDON = "";
        mdb.CREATEDBY = currentuser;
        //mdb.MODIFIEDON = "";
        mdb.MODIFIEDBY = currentuser;


        ds = mdb.MailSettting_INSERT_UPDATE_SEARCH_New();
        if (flag == "Search")
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                txt_Imapserver.Value = ds.Tables[0].Rows[0]["HOST_NAME"].ToString();
                txt_username.Value = ds.Tables[0].Rows[0]["USER_NAME"].ToString();
                txt_pwd.Value = ds.Tables[0].Rows[0]["PWD"].ToString();
                txt_Folder.Value = ds.Tables[0].Rows[0]["FOLDER"].ToString();
                txt_port.Value = ds.Tables[0].Rows[0]["PORT"].ToString();

                txt_EnableSsl.Value = ds.Tables[0].Rows[0]["ENABLE_SSL"].ToString();

                txt_Customhouse_Id.Value = ds.Tables[0].Rows[0]["CUSTOM_HOUSE"].ToString();
                txt_Company_Id.Value = ds.Tables[0].Rows[0]["COMPANY_ID"].ToString();

            }

        }
        return ds;
    }

    public void mail(string filenm)
    {

        Search_Insert_Update_Delete("Search");

        if (txt_username.Value != "")
        {
            string[] s1 = txt_username.Value.Split(new string[] { "@" }, StringSplitOptions.None);
            //txt_Smtpserver.Value = s1[0].ToString();
            txt_Smtpserver.Value = s1[1].ToString();
        }



        SmtpClient client = new SmtpClient();
        client.DeliveryMethod = SmtpDeliveryMethod.Network;


        if (txt_EnableSsl.Value== "True")
        {
            client.EnableSsl = true;
        }
        else
        {
            client.EnableSsl = false;
        }

        
        //client.Port = Convert.ToInt32(txt_port.Value);
        //client.Host = txt_Imapserver.Value;

        if (COMPANY_ID == "226")
        {
            client.Host = "smtp.mail.yahoo.com";//For Royal Tech Server

            client.Port = 465;
            client.EnableSsl = false;
        }
        else
        {
            client.Host = "127.0.0.1";//For Royal Tech Server
            //client.Host = "11.0.0.3";//For Boxco Logistics Server

            client.Port = 25;
            client.EnableSsl = false;

        }

        //-----------------------------------------------------------//


        //SmtpClient client = new SmtpClient();        
        //client.DeliveryMethod = SmtpDeliveryMethod.Network;    
        //client.Port = 587;
        //client.EnableSsl = true;

        //if (txt_Smtpserver.Value == "yahoo.com" || txt_Smtpserver.Value == "yahoo.co.in")
        //{
        //    txt_Smtpserver.Value = "mail.yahoo.com";
        //    client.EnableSsl = false;
        //    client.Host = "smtp." + txt_Smtpserver.Value;
           
        //}
        //else if (txt_Smtpserver.Value == "hotmail.com")
        //{
        //    txt_Smtpserver.Value = "live.com";
        //    client.EnableSsl = true;
        //    client.Port = 587;
        //    client.Host = "smtp." + txt_Smtpserver.Value;
            
        //}
        //else if (txt_Smtpserver.Value == "royaltechsystems.co.in")
        //{
        //    txt_Smtpserver.Value = "mailhostbox.com";
        //    client.EnableSsl = true;
        //    client.Port = 587;
        //    client.Host = "smtp." + txt_Smtpserver.Value;

        //}
        //else if (txt_Smtpserver.Value == "transworld.co")
        //{
        //    txt_Smtpserver.Value = "MAIL.TRANSWORLD.CO"; //   MAIL.TRANSWORLD.CO";
        //    client.EnableSsl = true;
        //    client.Port = 25;
        //    //client.Host = "smtp." + txt_Smtpserver.Value;
        //    client.Host = txt_Smtpserver.Value;
        //}
        //else if (txt_Smtpserver.Value == "oscalogistics.com")
        //{
        //    //txt_Imapserver = "mail.brainmagic.info";
        //    txt_Smtpserver.Value = "mail.brainmagic.info"; //  Oriental
        //    client.EnableSsl = false;
        //    client.Port = 587;
        //    //client.Host = "smtp." + txt_Smtpserver.Value;
        //    client.Host = txt_Smtpserver.Value;
        //}
        //else
        //{
        //    //client.Host = "smtp.gmail.com";

        //    //txt_Smtpserver.Value = "smtp.mailhostbox.com"; //  
        //    client.EnableSsl = false;
        //    client.Port = 25;
        //    //client.Host = "smtp." + txt_Smtpserver.Value;
        //    client.Host = txt_Imapserver.Value;

        //}

        //-----------------------------------------------------------//
       
        // setup Smtp authentication

        //System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("sathishkumar8789@gmail.com", "skoushik");
        System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(txt_username.Value, txt_pwd.Value);

        client.UseDefaultCredentials = true;

        client.Credentials = credentials;

        MailMessage msg = new MailMessage();

        //msg.From = new MailAddress("sathishkumar8789@gmail.com");
        msg.From = new MailAddress(txt_username.Value);

        //msg.To.Add(new MailAddress("admin@royaltechsystems.co.in"));
        //msg.To.Add(new MailAddress("balaji71187@gmail.com"));
        msg.To.Add(new MailAddress(txtTo.Text));

     

        if (txtCc.Text == "")
        {
            txtCc.Text = "";
        }
        else
        {
            msg.CC.Add(new MailAddress(txtCc.Text));
        }

    

        msg.Subject = txt_Subject.Text;

        msg.IsBodyHtml = true;

        //msg.Body = string.Format("<html><head></head><body><b>Flat File</b></body>");
        msg.Body = string.Format("<html><head></head><body><b>'" + txt_Body.Text + "'</b></body>");

        //string body_contents = "<html><body><table width='100%'><tr><td background='http://file1.hpage.com/001944/73/bilder/bg.gif' width='100%'><img alt='The Fore Cast Front India' src='http://www.denkenglobal.com/images/logo.gif'/><br><br><font style='font-style:normal;font-weight:normal;font-size:12.5px;font-family: Helvetica, Arial, sans-serif;text-align:left;line-height:inherit;letter-spacing:0.03px;color:#4a4a4a;margin:auto;padding-left:15px'>Hi ,<br /><br />You comments for  is accepted by the admin of The DPS Chennai.<br />To view your comments Please login to our site.<br />Login Here:<br />To access your account and post your comments for any article visit http://theforecastfront.com<br /><br /><br /><br />Thanks,<br />Admin,<br />The Fore Cast Front India.<br /><br /><br /><font size='1px'>Disclaimer: This is an auto-generated email. Please do not reply.</font><hr>Copyright © 2010 dpschennai.com  |  All rights reserved</font></div></div></div></td></tr></table></body></html>";
        //msg.Body = string.Format(body_contents);

       
       msg.Attachments.Add(new System.Net.Mail.Attachment(filenm));

        try
        {
            //if (txt_Smtpserver.Value != "gmail.com")
            //{
            //    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object s,
            //        System.Security.Cryptography.X509Certificates.X509Certificate certificate,
            //        System.Security.Cryptography.X509Certificates.X509Chain chain,
            //        System.Net.Security.SslPolicyErrors sslPolicyErrors)
            //    {
            //        return true;
            //    };
            //}
            client.Send(msg);

            if (msg.DeliveryNotificationOptions.ToString() == "Failure sending mail.")
            {
                Alert_msg("Failure sending mail!");
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Failure sending mail!')</script>", false);
                msg.Dispose();

            }
            else
            {


                Alert_msg("Mail Send Successfully");

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Auto submitted')</script>", false);
                msg.Dispose();
            }
            //lblMsg.Text = "Your message has been successfully sent.";
        }

        catch (Exception ex)
        {
            //lblMsg.ForeColor = Color.Red;

            string messege = "Error occured while sending your message." + ex.Message;
            //lblMsg.Text = "Error occured while sending your message." + ex.Message;
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('" + messege + "')</script>", false);
            Alert_msg(messege);

            msg.Dispose();

        }
        // }
        // else
        //Alert_msg("IceGate Email-Id & Password cannot be Empty");

    }

    public void Duty_Intimation_mail(string filenm)
    {
        Search_Insert_Update_Delete("Search");
        if (txt_username.Value != "")
        {
            string[] s1 = txt_username.Value.Split(new string[] { "@" }, StringSplitOptions.None);
            txt_Smtpserver.Value = s1[1].ToString();
        }
        SmtpClient client = new SmtpClient();
        client.DeliveryMethod = SmtpDeliveryMethod.Network;

        if (txt_EnableSsl.Value == "True")
        {
            client.EnableSsl = true;
        }
        else
        {
            client.EnableSsl = false;
        }

        if (COMPANY_ID == "226")
        {
            client.Host = "127.0.0.1";//For Royal Tech Server
            
            client.Port = 465;
            client.EnableSsl = true;
        }
        else
        {
            client.Host = "127.0.0.1";//For Royal Tech Server
            //client.Host = "11.0.0.3";//For Boxco Logistics Server
            client.Port = 25;
            client.EnableSsl = false;
        }
        //-----------------------------------------------------------//

        //if (COMPANY_ID == "116")
        //{
        //    client.Host = "smtp.gmail.com";//For Boxco Logistics Server
        //    client.Port = 25;
        //    client.EnableSsl = true;
        //}    


        System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(txt_username.Value, txt_pwd.Value);
        client.UseDefaultCredentials = true;
        client.Credentials = credentials;

        MailMessage msg = new MailMessage();
        msg.From = new MailAddress(txt_username.Value);
        msg.To.Add(new MailAddress(txtTo.Text));

        if (txtCc.Text == "")
        {
            txtCc.Text = "";
        }
        else
        {
            msg.CC.Add(new MailAddress(txtCc.Text));
        }

        msg.Subject = txt_Subject.Text;
        msg.IsBodyHtml = true;
        msg.Body = string.Format("<html><head></head><body><b>'" + txt_Body.Text + "'</b></body>");

       msg.Attachments.Add(new System.Net.Mail.Attachment(filenm));

        for (int i = 0; i < gvdetails.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)gvdetails.Rows[i].Cells[0].FindControl("chk");
            if (chk.Checked)
            {
                LinkButton lkb = (LinkButton)gvdetails.Rows[i].Cells[0].FindControl("lnkDownload");

                if(i==0)
                {
                  msg.Attachments.Add(new System.Net.Mail.Attachment(Attach_Folder + lkb.Text));
                }
                else if (i == 1)
                {
                    msg.Attachments.Add(new System.Net.Mail.Attachment(Attach_Folder + lkb.Text));
                }
                else if (i == 2)
                {
                    msg.Attachments.Add(new System.Net.Mail.Attachment(Attach_Folder + lkb.Text));
                }
                else if (i == 3)
                {
                    msg.Attachments.Add(new System.Net.Mail.Attachment(Attach_Folder + lkb.Text));
                }
                else if (i == 4)
                {
                    msg.Attachments.Add(new System.Net.Mail.Attachment(Attach_Folder + lkb.Text));
                }
            }
        }

        try
        {
            client.Send(msg);
            msg.Attachments.Clear();

            if (msg.DeliveryNotificationOptions.ToString() == "Failure sending mail.")
            {
                Alert_msg("Failure sending mail!");
                msg.Dispose();

            }
            else
            {

                Alert_msg("Mail Send Successfully");
                msg.Dispose();
            }
        }

        catch (Exception ex)
        {
            string messege = "Error occured while sending your message." + ex.Message;
            Alert_msg(messege);
            msg.Dispose();

        }
    }

    public void BytsToPDF()
    {
        try
        {
         if (File.Exists(Checklist_Attach + CHECKLIST_NAME))
            {
                DirectoryInfo dir = new DirectoryInfo(Checklist_Attach);

                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }

                CHECKLIST_NAME = Session["JobNo"].ToString() + ".pdf";

                // BytsToPDF();
                byte[] bytes = (byte[])Session["report"];
                //System.IO.File.Create(Checklist_Attach + Session["JobNo"].ToString() + ".pdf");
                File.WriteAllBytes(Checklist_Attach + CHECKLIST_NAME, bytes);

            }

            else
            {

                DirectoryInfo dir = new DirectoryInfo(Checklist_Attach);

                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }

                CHECKLIST_NAME = Session["JobNo"].ToString() + ".pdf";

                // BytsToPDF();
                byte[] bytes = (byte[])Session["report"];
                //System.IO.File.Create(Checklist_Attach + Session["JobNo"].ToString() + ".pdf");
                File.WriteAllBytes(Checklist_Attach + CHECKLIST_NAME, bytes);

                               
            }

        }

        catch (Exception ex)
        {

            er.makeLog(ex.Message);
        }






       // CHECKLIST_NAME = Session["JobNo"].ToString() + ".pdf";

        //byte[] bytes = (byte[])Session["report"];
        //Response.OutputStream.Write(bytes, 0, bytes.Length);

        //Response.Clear();
        //Response.ContentType = "application/pdf";

        ////Response.BinaryWrite(bytes); // create the file
        ////Response.Flush(); // send it to the client to download
        //Response.OutputStream.Write(bytes, 0, bytes.Length);
        //Response.AddHeader("content-disposition", "attachment; filename=" + Checklist_Attach + CHECKLIST_NAME);
        ////String encodedImgData = Convert.ToBase64String(bytes);

        ////Response.Write(String.Format(encodedImgData)); // create the file
        ////Response.Flush(); // send it to the client to download
        //Response.OutputStream.Flush();

        //Response.OutputStream.Close();

        //Response.Flush();

        //Response.Close();
        
  //------------------------------------------

        //byte[] bytes = (byte[])Session["report"];
        ////Response.OutputStream.Write(bytes, 0, bytes.Length);

        //if (bytes != null)
        //{
        //    const int chunk = 512;
        //    FileStream fileout = File.Create(Checklist_Attach+ CHECKLIST_NAME);
        //    fileout.Write(bytes,0,chunk);
        //    fileout.Close();
        //    //Response.ContentType = "application/pdf";
        //    //Response.AddHeader("content-length", bytes.Length.ToString());
        //    //Response.BinaryWrite(bytes);
        //}



       // ------------------------

        //byte[] bytes = (byte[])Session["report"];
        //File.WriteAllBytes(Checklist_Attach + Session["JobNo"].ToString() + ".pdf", bytes);
        //    System.IO.File.Create(Checklist_Attach+Session["JobNo"].ToString()+".pdf");

        //    File.WriteAllBytes(Checklist_Attach + Session["JobNo"].ToString() + ".pdf", bytes);
        //Document doc=new Document();
        //doc.Open();
        //doc.Add(bytes);
        ////PdfWriter.GetInstance(doc,
        //    Response.End();
        //    Response.Flush();


        //------------------------

        //byte[] a = ((byte[])Session["report"]);

        //MemoryStream m = new MemoryStream(a);
        //Response.Clear();
        //Response.AddHeader("Content-Length", a.Length.ToString());
        //Response.ContentType = "application/pdf";
        //Response.AddHeader("Expires", "0");
        //Response.AddHeader("Cache-Control", "must-revalidate, post-check=0, pre-check=0");
        //Response.AddHeader("Pragma", "public");
        //Response.AddHeader("Content-Disposition", "attachment; filename="+Checklist_Attach+CHECKLIST_NAME+"");
        //Response.BinaryWrite(a);
        //Response.Flush();
        //Response.End();
    }
 


    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'COMPOSE', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'COMPOSE', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }



   
}