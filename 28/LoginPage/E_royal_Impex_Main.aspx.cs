using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ApplicationBlocks.Data;
using BussinessObject;

public partial class LoginPage_Premium_E_royal_Impex_Main : System.Web.UI.Page
{
    AppSession aps = new AppSession();
    DataSet ds = new DataSet();

    public string currentuser, COMPANY_IDD;
    public string PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Screen_Id, Is_Master_Id;

    User_Rights_Details_cs UMR = new User_Rights_Details_cs();
    Global_variables ObjUBO = new Global_variables();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        currentuser = Connection.Current_User_Upper();
        COMPANY_IDD = Connection.COMPANYID();
        comp_ttl.Text = Session["currentcomp_name"].ToString() + "  [Working Period - " + Connection.WorkingPeriod() + "]";

        if (COMPANY_IDD == "1" || COMPANY_IDD == "3196" || COMPANY_IDD == "4011")
        {
            Tally_Report.Visible = true;
        }

        if (COMPANY_IDD == "2373" || COMPANY_IDD == "6001")
        {
            Sudharsan_Cargo.Visible = true;
        }

        if (COMPANY_IDD == "11")
        {
            Sudharsan_Cargo.Visible = true;
        }

        if (COMPANY_IDD == "2341")
        {
            Docket_Entry.Visible = true;
            ExpPaymentEntry.Visible = true;
        }

        if (COMPANY_IDD == "10")
        {
            ODEX.Visible = true;
        }

        if (COMPANY_IDD == "1159" || COMPANY_IDD == "1529" || COMPANY_IDD == "1643" || COMPANY_IDD == "3099")
        {
            Docket_Entry.Visible = true;
        }

        if (!IsPostBack)
        {
            ShowNotification_Image();

            // Menu layout (Horizontal/Vertical - "Sidebar Layout" dropdown): defaults to
            // Vertical for every user until they explicitly pick Horizontal (saved via the
            // SavePmMenuLayout page method below, keyed to COMPANY_LICENSE + the actual login
            // username - not ADMIN_USER_CREATION.USERID, which is a per-employee-rights code,
            // not the login identity itself). Just resolved and stashed in Session here - the
            // .aspx markup applies it directly (inline <%= %> expression, right next to
            // #pmSidebarPanel) rather than via a startup script fired from here, since that
            // waited for a load/DOMContentLoaded event and caused a visible Horizontal-then-
            // Vertical flash on every load.
            Session["MenuLayout"] = GetMenuLayoutPreference(Session["COMPANY_LICENSE"] != null ? Session["COMPANY_LICENSE"].ToString() : "",
                Session["currentuser"] != null ? Session["currentuser"].ToString() : "");

            // Same session value the old eRoyalMasters.master used for the top user name.
            if (Session["currentuser"] != null)
            {
                mainmastopusernametxt.InnerText = Session["currentuser"].ToString();
            }

            // Session["LoginDate"] is stamped by LoginPage/Default.aspx.cs at login time
            // (System.DateTime.Now) - show it once, it should not keep ticking like a clock.
            if (Session["LoginDate"] != null)
            {
                DateTime loginDate;
                if (DateTime.TryParse(Session["LoginDate"].ToString(), out loginDate))
                {
                    pmLoginTime.InnerText = loginDate.ToString("hh:mm:ss tt");
                }
            }

            // Same session values the old eRoyalMasters.master used for branch + working period.
            if (Session["currentbranch_code"] != null)
            {
                mainmastopbranchtxt.InnerText = Session["currentbranch_code"].ToString();
            }
            if (Session["WorkingPeriod"] != null)
            {
                pmWorkingPeriod.InnerText = Session["WorkingPeriod"].ToString();
            }

            // Same session value + SELECT_TYPE-keyed colon count the old Import_MasterPage/
            // eRoyalMasters.master used for its "Lic. No :" label (COMPANY_LICENSE) - the
            // control it targeted (lbl_lic) doesn't exist in that master's markup anymore, so it
            // was fully commented out and never actually rendered there. Revived here in the new
            // header (between ERI Support and Branch), same condition/colon-count as the original.
            if (Session["COMPANY_LICENSE"] != null && !string.IsNullOrEmpty(Session["COMPANY_LICENSE"].ToString()))
            {
                string licNoColons;
                if (Session["SELECT_TYPE"] != null)
                {
                    string selectType = Session["SELECT_TYPE"].ToString();
                    if (selectType == "Branchwise Job")
                    {
                        licNoColons = ": :";
                    }
                    else if (selectType == "Areawise Job")
                    {
                        licNoColons = ": : :";
                    }
                    else
                    {
                        licNoColons = ":";
                    }
                }
                else
                {
                    licNoColons = ":";
                }

                spanLicNo.InnerText = licNoColons + " " + Session["COMPANY_LICENSE"].ToString().ToUpper();
                divLicNo.Visible = true;
            }

            if (COMPANY_IDD == "1" || COMPANY_IDD == "10" || COMPANY_IDD == "115" || COMPANY_IDD == "243" || COMPANY_IDD == "265" || COMPANY_IDD == "286" || COMPANY_IDD == "293" || COMPANY_IDD == "470" || COMPANY_IDD == "517" || COMPANY_IDD == "579" || COMPANY_IDD == "816" || COMPANY_IDD == "829" || COMPANY_IDD == "1334" || COMPANY_IDD == "2099" || COMPANY_IDD == "2118" || COMPANY_IDD == "2145" || COMPANY_IDD == "2458" || COMPANY_IDD == "2537" || COMPANY_IDD == "2835" || COMPANY_IDD == "3073" || COMPANY_IDD == "3074" || COMPANY_IDD == "3087" || COMPANY_IDD == "3089"
               || COMPANY_IDD == "3140" || COMPANY_IDD == "3158" || COMPANY_IDD == "3172" || COMPANY_IDD == "3198")
            {
                Exp_PDF.Visible = true;
                Exp_PDF_Mas.Visible = true;
            }
            if (COMPANY_IDD == "1" || COMPANY_IDD == "10" || COMPANY_IDD == "268" || COMPANY_IDD == "286" || COMPANY_IDD == "293" || COMPANY_IDD == "341" || COMPANY_IDD == "458" || COMPANY_IDD == "584" || COMPANY_IDD == "816" || COMPANY_IDD == "2099" || COMPANY_IDD == "2145" || COMPANY_IDD == "2537" || COMPANY_IDD == "3074" || COMPANY_IDD == "3140" || COMPANY_IDD == "3172" || COMPANY_IDD == "3198" || COMPANY_IDD == "3244" || COMPANY_IDD == "3299")
            {
                Import_PDF.Visible = true;
            }

            if (COMPANY_IDD == "293")//BWC ACCOUNTS MENU
            {
                Auto_Mail_Scheduler.Visible = true;
                Import_CaterPillar.Visible = true;
            }
 	        else if (COMPANY_IDD == "1")//BWC ACCOUNTS MENU
            {
                Auto_Mail_Scheduler.Visible = true;
                //Import_CaterPillar.Visible = true;
            }

            else
            {
                Auto_Mail_Scheduler.Visible = false;
                Import_CaterPillar.Visible = false;
            }
           
            if (COMPANY_IDD == "188" || COMPANY_IDD == "244" || COMPANY_IDD == "268" || COMPANY_IDD == "653" || COMPANY_IDD == "677" || COMPANY_IDD == "1157" || COMPANY_IDD == "1159" || COMPANY_IDD == "1186" || COMPANY_IDD == "1316" || COMPANY_IDD == "1613" || COMPANY_IDD == "2085" || COMPANY_IDD == "3094")//Credit Note Purpose
            {
                GST_Imp_Bill_CreditNote.Visible = true;
                GST_Exp_Bill_CreditNote.Visible = true;
            }

            if (COMPANY_IDD == "1603")//SKBT SRI KALKI BHAGAVAN TRANSPORT
            {
                LiTransportBillEntry.Visible = true;
            }
            if (COMPANY_IDD == "4" || COMPANY_IDD == "10" || COMPANY_IDD == "146")
            {
                Combined_Jobs.Visible = true;
            }
            if (COMPANY_IDD == "4" || COMPANY_IDD == "285")
            {
                AWB.Visible = true;
            }
            if (COMPANY_IDD == "4" || COMPANY_IDD == "196")
            {
                Indev.Visible = true;
                Indev_Product_Id.Visible = true;
            }
            if (COMPANY_IDD == "1" || COMPANY_IDD == "10" || COMPANY_IDD == "3275")
            {
                Job_Completed_Status_Entry.Visible = true;
            }
            if (COMPANY_IDD == "4" || COMPANY_IDD == "10")
            {
                FF_NewAge.Visible = true;
            }

            if (COMPANY_IDD == "151" || COMPANY_IDD == "10")
            {
                CustomsDuty_Rpt.Visible = true;
            }
            if (COMPANY_IDD == "10" || COMPANY_IDD == "293")
            {
                Pdf_Product_Id.Visible = true;
            }

            if (COMPANY_IDD == "10" || COMPANY_IDD == "196")
            {
                Indev.Visible = true;
                Indev_Product_Id.Visible = true;
            }
            if (COMPANY_IDD == "2248")
            {
                Front_Man.Visible = true;
            }

            if (COMPANY_IDD == "10" || COMPANY_IDD == "4" || COMPANY_IDD == "248")
            {
                Expo_Freight.Visible = true;
            }

            if (COMPANY_IDD == "1176")
            {
                Sanco.Visible = true;
            }

            if (COMPANY_IDD == "504")
            {
                ICC_Cargo.Visible = true;
            }
            if (COMPANY_IDD == "525")
            {
                Freight_Log.Visible = true;
            }
            if (COMPANY_IDD == "517")
            {
                Export_Bulk_Container_LIZMA.Visible = true;
                Export_Refrence_no_BulkUpload_LIZMA.Visible = true;
            }

            if (COMPANY_IDD == "520" || COMPANY_IDD == "1509")
            {
                Delivery_Chellan_Vintage.Visible = true;
                Delivery_Chellan.Visible = false;
            }
            if (COMPANY_IDD == "230" || COMPANY_IDD == "408" || COMPANY_IDD == "485" || COMPANY_IDD == "534" || COMPANY_IDD == "919")
            {
                Para_Mount.Visible = true;
                if (COMPANY_IDD == "230")
                {
                    Para_Exp.Visible = true;
                    Para_Import.Visible = false;
                }
                else if (COMPANY_IDD == "408")
                {
                    Para_Exp.Visible = true;
                    Para_Import.Visible = true;
                }
                else if (COMPANY_IDD == "485")
                {
                    Para_Exp.Visible = true;
                    Para_Import.Visible = true;
                }
                else if (COMPANY_IDD == "534")
                {
                    Para_Exp.Visible = true;
                    Para_Import.Visible = true;
                }
            }
            else
            {
                Para_Mount.Visible = false;
            }
            if (COMPANY_IDD == "293")
            {
                Para_Mount.Visible = true;
                if (currentuser.ToUpper() == "EXPORT1" || currentuser.ToUpper() == "EXPORT2" || currentuser.ToUpper() == "EXPORT3" || currentuser.ToUpper() == "EXPORT4" || currentuser.ToUpper() == "EXPORT5" || currentuser.ToUpper() == "EXPORT6" || currentuser.ToUpper() == "EXPORT7" || currentuser.ToUpper() == "VENKAT")
                {
                    Rpt_Import.Visible = false;
                    Para_Exp.Visible = true;
                    Para_Import.Visible = false;
                }
                else if (currentuser.ToUpper() == "RTS" || currentuser.ToUpper() == "EXPORT8" || currentuser.ToUpper() == "EXPORT9" || currentuser.ToUpper() == "EXPORT10")
                {
                    Imp_id.Visible = true;
                    Rpt_Export.Visible = true;
                    Para_Import.Visible = true;
                    Rpt_Import.Visible = true;
                    Para_Exp.Visible = true;
                }
                else
                {
                    Exp_id.Visible = false;
                    Rpt_Export.Visible = false;
                    Export_Id.Visible = false;

                    Para_Import.Visible = true;
                    Para_Exp.Visible = false;
                }
            }

            if (COMPANY_IDD == "2099")
            {
                Para_Mount.Visible = true;
                Para_Exp.Visible = true;
                Para_Import.Visible = true;
            }

            if (COMPANY_IDD == "4" || COMPANY_IDD == "247" || COMPANY_IDD == "268")
            {
                Bas_Ship.Visible = true;
            }

            if (COMPANY_IDD == "10" || COMPANY_IDD == "4" || COMPANY_IDD == "1" || COMPANY_IDD == "538" || COMPANY_IDD == "1103")
            {
                Export_Bulk_Chk.Visible = true;
            }

            if (COMPANY_IDD == "382" || COMPANY_IDD == "353")
            {
                GST_Combined_Bill.Visible = true;
            }

            if (COMPANY_IDD == "230" || COMPANY_IDD == "408" || COMPANY_IDD == "1" || COMPANY_IDD == "4" || COMPANY_IDD == "375"
                || COMPANY_IDD == "704" || COMPANY_IDD == "744" || COMPANY_IDD == "1316")
            {
                GST_Combined_Bill_Para.Visible = true;
                LiExpensesDetails.Visible = true;
                LiProfitgRpt.Visible = true;
            }
            if (COMPANY_IDD == "581" || COMPANY_IDD == "1069" || COMPANY_IDD == "3275" || COMPANY_IDD == "4")
            {
                Imp_ADC_Sheet.Visible = true;
            }
            if (COMPANY_IDD == "4" || COMPANY_IDD == "10" || COMPANY_IDD == "162" || COMPANY_IDD == "196" || COMPANY_IDD == "207" || COMPANY_IDD == "230" || COMPANY_IDD == "267" || COMPANY_IDD == "284" || COMPANY_IDD == "286"
                || COMPANY_IDD == "293" || COMPANY_IDD == "350" || COMPANY_IDD == "380" || COMPANY_IDD == "408" || COMPANY_IDD == "485" || COMPANY_IDD == "517" || COMPANY_IDD == "580" || COMPANY_IDD == "723" || COMPANY_IDD == "1004"
                || COMPANY_IDD == "1028" || COMPANY_IDD == "1113" || COMPANY_IDD == "1121" || COMPANY_IDD == "1134" || COMPANY_IDD == "1146")
            {
                Export_EGM.Visible = true;
            }

            if (COMPANY_IDD == "508")
            {
                Covering_Letter_Pegasus.Visible = true;
                Covering_Letter.Visible = false;
                Covering_Letter_Vaishnavi.Visible = false;
            }
            else if (COMPANY_IDD == "480" || COMPANY_IDD == "1019")
            {
                Covering_Letter.Visible = true;
                Covering_Letter_Pegasus.Visible = false;
                Covering_Letter_Vaishnavi.Visible = false;
            }
            else if (COMPANY_IDD == "511")
            {
                Covering_Letter.Visible = false;
                Covering_Letter_Pegasus.Visible = false;
                Covering_Letter_Vaishnavi.Visible = true;
            }
            else
            {
                Covering_Letter.Visible = false;
                Covering_Letter_Pegasus.Visible = false;
                Covering_Letter_Vaishnavi.Visible = false;
            }

            if (COMPANY_IDD == "517" || COMPANY_IDD == "341" || COMPANY_IDD == "1028")
            {
                Export_DSR_Rpt_Lizma.Visible = true;
                Export_DSR_Rpt_Common.Visible = false;
            }
            else
            {
                Export_DSR_Rpt_Common.Visible = true;
                Export_DSR_Rpt_Lizma.Visible = false;
            }

            if (COMPANY_IDD == "1" || COMPANY_IDD == "10" || COMPANY_IDD == "286" || COMPANY_IDD == "517" || COMPANY_IDD == "1039" || COMPANY_IDD == "1509" || COMPANY_IDD == "1572" || COMPANY_IDD == "2099")
            {
                Exp_PDF.Visible = true;
                PDF_Country.Visible = true;
                PDF_Port.Visible = true;
            }

            if (COMPANY_IDD == "1" || COMPANY_IDD == "10" || COMPANY_IDD == "412" || COMPANY_IDD == "2099" || COMPANY_IDD == "2654")
            {
                Li_SEZ_Z_to_T_Report.Visible = true;
            }

            Li_cust_Rpt_GroupNew_Import.Visible = true;
            Li_cust_Rpt_GroupNew_Export.Visible = true;

            Menu_Enable();

            if (COMPANY_IDD == "3233" || COMPANY_IDD == "3423")//AGS & ASS Client
            {
                Li_Receipt_Entry.Visible = true;
                ExpPaymentEntry.Visible = false;
            }

            try
            {
                if (Session["USER_DETAILS_DS"] != null)
                {
                    if (Session["JOB_TYPE"] != null)
                    {
                        Transaction_Type();
                        ds = (DataSet)Session["USER_DETAILS_DS"];
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            string Roll = ds.Tables[0].Rows[0]["TYPE"].ToString();
                            Session.Remove("Roll");
                            Session["Roll"] = Roll;
                            if (Roll == "A")
                            {
                                Royal_Admin_Id.Style.Add("display", "block");
                                User_Admin_Id.Style.Add("display", "block");
                                Company_Master_Id.Style.Add("display", "block");
                                Admin_access_sql_id.Style.Add("display", "block");
                                Retail_Sales_Id.Style.Add("display", "block");
                                Live_UpdationNew.Style.Add("display", "block");
                                Li_ErrorLogs.Style.Add("display", "block");
                                LiAdv.Style.Add("display", "block");
                                Col_Edit_Master_Id.Style.Add("display", "block");
                                LiRTSELMap.Visible = true;
                                Li_JobDeletedHistory.Visible = true;
                                li_Query_Update.Visible = true;
                                Li_Financialyear_Creation.Visible = true;
                            }
                            else if (Roll == "S")
                            {
                                Royal_Admin_Id.Style.Add("display", "none");
                                User_Admin_Id.Style.Add("display", "block");
                                Company_Master_Id.Style.Add("display", "none");
                                Admin_access_sql_id.Style.Add("display", "none");
                                Retail_Sales_Id.Style.Add("display", "none");
                                Live_UpdationNew.Style.Add("display", "none");
                                Li_ErrorLogs.Style.Add("display", "none");
                                LiAdv.Style.Add("display", "none");
                                Col_Edit_Master_Id.Style.Add("display", "block");
                                Li_JobDeletedHistory.Visible = true;

                                if (COMPANY_IDD == "3288")
                                {
                                    Copper_login.Visible = true;
                                }
                            }
                            else if (Roll == "U")
                            {
                                Royal_Admin_Id.Style.Add("display", "none");
                                User_Admin_Id.Style.Add("display", "none");
                                Company_Master_Id.Style.Add("display", "none");
                                Admin_access_sql_id.Style.Add("display", "none");
                                Retail_Sales_Id.Style.Add("display", "none");
                                Live_UpdationNew.Style.Add("display", "none");
                                Li_ErrorLogs.Style.Add("display", "none");
                                LiAdv.Style.Add("display", "none");
                            }
                        }
                    }

                    DataView view1 = ds.Tables[1].DefaultView;
                    string COMPANY_ID, USER_CREATION_ID, BRANCH;
                    COMPANY_ID = Session["COMPANY_ID"].ToString();
                    USER_CREATION_ID = Session["USER_CREATION_ID"].ToString();
                    BRANCH = Session["currentbranch"].ToString();
                    view1.RowFilter = "BRANCH = '" + BRANCH + "' and " + "COMPANY_ID = " + COMPANY_ID + " and " + "USER_CREATION_ID = " + USER_CREATION_ID + "";
                    DataTable table1 = view1.ToTable();
                    DataSet dt_UserRights = new DataSet();
                    dt_UserRights.Tables.Add(table1);
                    if (dt_UserRights.Tables[0].Rows.Count > 0)
                    {
                        for (int a = 0; a < dt_UserRights.Tables[0].Rows.Count; a++)
                        {
                            PAGE_READ = dt_UserRights.Tables[0].Rows[a]["PAGE_READ"].ToString();
                            PAGE_WRITE = dt_UserRights.Tables[0].Rows[a]["PAGE_WRITE"].ToString();
                            PAGE_MODIFY = dt_UserRights.Tables[0].Rows[a]["PAGE_MODIFY"].ToString();
                            PAGE_DELETE = dt_UserRights.Tables[0].Rows[a]["PAGE_DELETE"].ToString();
                            Screen_Id = dt_UserRights.Tables[0].Rows[a]["SCREEN_ID"].ToString();
                            Page_Show_Hide(Convert.ToInt32(Screen_Id));
                        }
                    }
                    else
                    {
                        Screen_Id = "0";
                        Page_Show_Hide(Convert.ToInt32(Screen_Id));
                    }
                    if (Is_Master_Id == "true")
                        Master_Id.Style.Add("display", "block");
                    else
                    {
                        Master_Id.Style.Add("display", "none");
                    }
                }

                if (Connection.COMPANYID() == "1" || Connection.COMPANYID() == "116" || Connection.COMPANYID() == "196")
                {
                    bool usernames = new[] { "royaladmin", "bala", "akila", "subash", "priya", "nizarudeen", "shaziya", "rajan", "palani", "soniya" }
                                    .Contains(Connection.Current_User().ToLower());
                    if (usernames == true)
                    {
                        Royal_Admin_Id.Visible = true;
                        Company_Master_Id.Visible = true;
                        Admin_access_sql_id.Visible = true;
                        Retail_Sales_Id.Visible = true;
                        Live_UpdationNew.Visible = true;
                        Li_ErrorLogs.Visible = true;
                        LiAdv.Visible = true;
                    }
                }
                else
                {
                    Royal_Admin_Id.Visible = false;
                    Company_Master_Id.Visible = false;
                    Admin_access_sql_id.Visible = false;
                    Retail_Sales_Id.Visible = false;
                    Live_UpdationNew.Visible = false;
                    Li_ErrorLogs.Visible = false;
                    LiAdv.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
            }
        }
    }

    public void Transaction_Type()
    {
        string JOB_TYPE = Session["JOB_TYPE"].ToString();
        if (JOB_TYPE == "Import")
        {
            Import_Id.Style.Add("display", "block");
            Export_Id.Style.Add("display", "none");
            Export_Goods_Reg_Id.Style.Add("display", "none");
            Imp_id.Style.Add("display", "block");
            Exp_id.Style.Add("display", "none");
        }
        else if (JOB_TYPE == "Export")
        {
            Import_Id.Style.Add("display", "none");
            Export_Id.Style.Add("display", "block");
            Export_Goods_Reg_Id.Style.Add("display", "block");
            Imp_id.Style.Add("display", "none");
            Exp_id.Style.Add("display", "block");
        }
        else if (JOB_TYPE == "Both")
        {
            Import_Id.Style.Add("display", "block");
            Export_Id.Style.Add("display", "block");
            Export_Goods_Reg_Id.Style.Add("display", "block");
            Imp_id.Style.Add("display", "block");
            Exp_id.Style.Add("display", "block");
        }
    }

    public void Page_Show_Hide(int i)
    {
        bool is_page;
        if (i == 0)
        {
            Import_Job_Id.Style.Add("display", "none");
            Import_Submission_Id.Style.Add("display", "none");
            Import_Job_Duplicate_Id.Style.Add("display", "none");
            Import_BE_Entry_Id.Style.Add("display", "none");
            Export_Job_Id.Style.Add("display", "none");
            Export_Submission_Id.Style.Add("display", "none");
            Export_Job_Duplicate_Id.Style.Add("display", "none");
            Export_Goods_Reg_Job_Id.Style.Add("display", "none");
            Export_Goods_Reg_Submission_Id.Style.Add("display", "none");
            Imp_id.Style.Add("display", "none");
            Exp_id.Style.Add("display", "none");
        }
        //-----------------------------------------------------------------MASTER PAGES----------------------------------------------------------//
        else if (i == 1)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                Client_Id.Style.Add("display", "block");
                Is_Master_Id = "true";
            }
            else
            {
                Client_Id.Style.Add("display", "none");
                if (Is_Master_Id != "true")// FOR MASTER LINK HIDE
                    Is_Master_Id = "false";
            }
        }
        else if (i == 2)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                Supplier_Id.Style.Add("display", "block");
                Is_Master_Id = "true";
            }
            else
            {
                Supplier_Id.Style.Add("display", "none");
                if (Is_Master_Id != "true")
                    Is_Master_Id = "false";
            }
        }
        else if (i == 3)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                Consignee_Id.Style.Add("display", "block");
                Is_Master_Id = "true";
            }
            else
            {
                Consignee_Id.Style.Add("display", "none");
                if (Is_Master_Id != "true")
                    Is_Master_Id = "false";
            }
        }
        else if (i == 4)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                Adcode_Id.Style.Add("display", "block");
                Is_Master_Id = "true";
            }
            else
            {
                Adcode_Id.Style.Add("display", "none");
                if (Is_Master_Id != "true")
                    Is_Master_Id = "false";
            }
        }
        else if (i == 5)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                Buyer_Id.Style.Add("display", "block");
                Is_Master_Id = "true";
            }
            else
            {
                Buyer_Id.Style.Add("display", "none");
                if (Is_Master_Id != "true")
                    Is_Master_Id = "false";
            }
        }
        else if (i == 6)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                License_Id.Style.Add("display", "block");
                Is_Master_Id = "true";
            }
            else
            {
                License_Id.Style.Add("display", "none");
                if (Is_Master_Id != "true")
                    Is_Master_Id = "false";
            }
        }
        //-----------------------------------------------------------------MASTER PAGES----------------------------------------------------------//
        //-----------------------------------------------------------------IMPORT PAGES----------------------------------------------------------//
        else if (i == 7)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                Import_Job_Id.Style.Add("display", "block");
                Imp_id.Style.Add("display", "block");
            }
            else
            {
                Import_Job_Id.Style.Add("display", "none");
                Imp_id.Style.Add("display", "none");
            }
        }
        else if (i == 8)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                Import_Submission_Id.Style.Add("display", "block");
            }
            else
            {
                Import_Submission_Id.Style.Add("display", "none");
            }
        }
        else if (i == 9)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                Import_Job_Duplicate_Id.Style.Add("display", "block");
            }
            else
            {
                Import_Job_Duplicate_Id.Style.Add("display", "none");
            }
        }
        else if (i == 10)
        {
            is_page = Page_Rights();
        }
        else if (i == 11)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                Import_BE_Entry_Id.Style.Add("display", "block");
            }
            else
            {
                Import_BE_Entry_Id.Style.Add("display", "none");
            }
        }
        else if (i == 16)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                Import_CusRes_Id.Style.Add("display", "block");
            }
            else
            {
                Import_CusRes_Id.Style.Add("display", "none");
            }
        }
        else if (i == 17)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                Mis_Report1.Style.Add("display", "block");
            }
            else
            {
                Mis_Report1.Style.Add("display", "none");
            }
        }
        else if (i == 18)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                Mis_Report2.Style.Add("display", "block");
            }
            else
            {
                Mis_Report2.Style.Add("display", "none");
            }
        }
        else if (i == 19)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                Mis_Report3.Style.Add("display", "block");
            }
            else
            {
                Mis_Report3.Style.Add("display", "none");
            }
        }
        else if (i == 20)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                DSR.Style.Add("display", "block");
            }
            else
            {
                DSR.Style.Add("display", "none");
            }
        }
        else if (i == 21)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                PL_Report.Style.Add("display", "block");
            }
            else
            {
                PL_Report.Style.Add("display", "none");
            }
        }
        else if (i == 22)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                PL_Report1.Style.Add("display", "block");
            }
            else
            {
                PL_Report1.Style.Add("display", "none");
            }
        }
        else if (i == 23)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                Manual_BE.Style.Add("display", "block");
            }
            else
            {
                Manual_BE.Style.Add("display", "none");
            }
        }
        else if (i == 24)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                KK_Form.Style.Add("display", "block");
            }
            else
            {
                KK_Form.Style.Add("display", "none");
            }
        }
        else if (i == 25)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                Delivery_Chellan.Style.Add("display", "block");
            }
            else
            {
                Delivery_Chellan.Style.Add("display", "none");
            }
        }
        else if (i == 26)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                Li_NForm.Style.Add("display", "block");
            }
            else
            {
                Li_NForm.Style.Add("display", "none");
            }
        }
        else if (i == 29)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                WareHouseExBond_id.Style.Add("display", "block");
            }
            else
            {
                WareHouseExBond_id.Style.Add("display", "none");
            }
        }
        else if (i == 30)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                Imp_QueryReply.Style.Add("display", "block");
            }
            else
            {
                Imp_QueryReply.Style.Add("display", "none");
            }
        }
        else if (i == 31)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                Imp_Tracking.Style.Add("display", "block");
            }
            else
            {
                Imp_Tracking.Style.Add("display", "none");
            }
        }
        else if (i == 32)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                Imp_Tracking.Style.Add("display", "block");
            }
            else
            {
                Imp_Tracking.Style.Add("display", "none");
            }
        }
        else if (i == 33)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                LiEsanchitImp.Style.Add("display", "block");
            }
            else
            {
                LiEsanchitImp.Style.Add("display", "none");
            }
        }
        else if (i == 34)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                Duty_Intimation.Style.Add("display", "block");
            }
            else
            {
                Duty_Intimation.Style.Add("display", "none");
            }
        }
        else if (i == 35)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                Duty_Cal.Style.Add("display", "block");
            }
            else
            {
                Duty_Cal.Style.Add("display", "none");
            }
        }
        //-----------------------------------------------------------------IMPORT PAGES----------------------------------------------------------//
        //-----------------------------------------------------------------EXPORT PAGES----------------------------------------------------------//
        else if (i == 12)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                Export_Job_Id.Style.Add("display", "block");
                Export_Goods_Reg_Job_Id.Style.Add("display", "block");
                Exp_id.Style.Add("display", "block");
            }
            else
            {
                Export_Job_Id.Style.Add("display", "none");
                Export_Goods_Reg_Job_Id.Style.Add("display", "none");
                Exp_id.Style.Add("display", "none");
            }
        }
        else if (i == 13)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                Export_Submission_Id.Style.Add("display", "block");
                Export_Goods_Reg_Submission_Id.Style.Add("display", "block");
            }
            else
            {
                Export_Submission_Id.Style.Add("display", "none");
                Export_Goods_Reg_Submission_Id.Style.Add("display", "none");
            }
        }
        else if (i == 14)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                Export_Job_Duplicate_Id.Style.Add("display", "block");
            }
            else
            {
                Export_Job_Duplicate_Id.Style.Add("display", "none");
            }
        }
        else if (i == 15)
        {
            is_page = Page_Rights();
        }
        //-----------------------------------------------------------------EXPORT PAGES----------------------------------------------------------//
    }

    public bool Page_Rights()
    {
        bool Is_Page;
        if (PAGE_READ == "False" && PAGE_WRITE == "False" && PAGE_MODIFY == "False" && PAGE_DELETE == "False")
        {
            Is_Page = false;
        }
        else
        {
            Is_Page = true;
        }
        return Is_Page;
    }

    private void Menu_Enable()
    {
        try
        {
            Imp_id.Visible = false;
            Rpt_Import.Visible = false;
            Import_Id.Visible = false;

            Exp_id.Visible = false;
            Rpt_Export.Visible = false;
            Export_Id.Visible = false;

            Accounts.Visible = false;
            Billing.Visible = false;
            Session["I_SEZ"] = "F";
            Session["E_SEZ"] = "F";

            ObjUBO.A1 = Connection.Company_License();
            ObjUBO.A3 = Session["USER_CREATION_ID"].ToString();
            ObjUBO.A40 = "Menu_ID_Select";
            ds = UMR.User_Rights_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i][0].ToString() == "I")
                    {
                        Imp_id.Visible = true;
                        Rpt_Import.Visible = true;
                        Import_Id.Visible = true;
                    }
                    else if (ds.Tables[0].Rows[i][0].ToString() == "E")
                    {
                        Exp_id.Visible = true;
                        Rpt_Export.Visible = true;
                        Export_Id.Visible = true;
                    }
                    else if (ds.Tables[0].Rows[i][0].ToString() == "A")
                    {
                        Accounts.Visible = true;
                    }
                    else if (ds.Tables[0].Rows[i][0].ToString() == "B")
                    {
                        Billing.Visible = true;
                        LiGST_BILLING_Bill_from_COMPANY_MASTER.Visible = false;
                        Li_Party_Master.Visible = false;
                        Li_Credit_Limit.Visible = false;
                        LiPreviousCrDr.Visible = false;
                        GST_Bill_Consolidate.Visible = false;
                    }
                    else if (ds.Tables[0].Rows[i][0].ToString() == "IZ")
                    {
                        Session["I_SEZ"] = "T";
                    }
                    else if (ds.Tables[0].Rows[i][0].ToString() == "EZ")
                    {
                        Session["E_SEZ"] = "T";
                    }
                    else if (ds.Tables[0].Rows[i][0].ToString() == "OI")
                    {
                        OCR_Module.Visible = true;
                        OCR_IMPORT.Visible = true;
                    }
                    else if (ds.Tables[0].Rows[i][0].ToString() == "OE")
                    {
                        OCR_Module.Visible = true;
                        OCR_EXPORT.Visible = true;
                    }
                }
            }
            Connection.Premium_Services(ds);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    // Menu layout preference (Horizontal/Vertical sidebar) - stored in a small dedicated
    // table in the shared ImpexLogin DB, keyed by COMPANY_LICENSE + the login username
    // (Session["currentuser"]), NOT ADMIN_USER_CREATION.USERID (that's a per-employee
    // rights code from a different, per-company identity system - real login auth runs
    // against Session["currentcomp_db"], not this shared DB). Horizontal is the default
    // whenever no row exists yet for this user.
    private string GetMenuLayoutPreference(string companyLicense, string username)
    {
        try
        {
            if (companyLicense == "" || username == "") return "Horizontal";

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@COMPANY_LICENSE", companyLicense);
            param[1] = new SqlParameter("@USERNAME", username);
            DataSet dsPref = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.Text,
                "SELECT MENU_LAYOUT FROM USER_MENU_LAYOUT_PREFERENCE WHERE COMPANY_LICENSE=@COMPANY_LICENSE AND USERNAME=@USERNAME", param);

            if (dsPref.Tables.Count > 0 && dsPref.Tables[0].Rows.Count > 0 && dsPref.Tables[0].Rows[0]["MENU_LAYOUT"] != DBNull.Value
                && dsPref.Tables[0].Rows[0]["MENU_LAYOUT"].ToString() == "Vertical")
            {
                return "Vertical";
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return "Horizontal";
    }

    // Called from pmApplyMenuLayout() (client-side, on every Sidebar Layout dropdown click)
    // to persist the choice so it's restored on the user's next login, any browser/device.
    [System.Web.Services.WebMethod]
    public static string SavePmMenuLayout(string mode)
    {
        try
        {
            string companyLicense = HttpContext.Current.Session["COMPANY_LICENSE"] != null ? HttpContext.Current.Session["COMPANY_LICENSE"].ToString() : "";
            string username = HttpContext.Current.Session["currentuser"] != null ? HttpContext.Current.Session["currentuser"].ToString() : "";
            if (companyLicense == "" || username == "") return "skipped";

            string normalized = (mode == "horizontal") ? "Horizontal" : "Vertical";

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@COMPANY_LICENSE", companyLicense);
            param[1] = new SqlParameter("@USERNAME", username);
            param[2] = new SqlParameter("@MENU_LAYOUT", normalized);

            string sql = @"MERGE USER_MENU_LAYOUT_PREFERENCE AS target
USING (SELECT @COMPANY_LICENSE AS COMPANY_LICENSE, @USERNAME AS USERNAME) AS src
ON target.COMPANY_LICENSE = src.COMPANY_LICENSE AND target.USERNAME = src.USERNAME
WHEN MATCHED THEN UPDATE SET MENU_LAYOUT = @MENU_LAYOUT, MODIFIEDON = GETDATE()
WHEN NOT MATCHED THEN INSERT (COMPANY_LICENSE, USERNAME, MENU_LAYOUT, MODIFIEDON) VALUES (@COMPANY_LICENSE, @USERNAME, @MENU_LAYOUT, GETDATE());";

            SqlHelper.ExecuteNonQuery(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.Text, sql, param);
            HttpContext.Current.Session["MenuLayout"] = normalized;
            return "ok";
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            return "error";
        }
    }

    // Ported from Import_MasterPage/eRoyalMasters.master.cs so the notification bell
    // shows the same active announcement image + quick links (WhatsApp/Drive/YouTube/Website).
    private void ShowNotification_Image()
    {
        DataSet ds = new DataSet();
        Live_updation Lu = new Live_updation();
        Lu.Flag = "IMAGE_POPUP";
        ds = Lu.Live_Updation_Img_Select();

        bool hasActiveAnnouncement = false;

        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            string ImgPath = ds.Tables[0].Rows[0]["ImagePath"].ToString();

            if (!string.IsNullOrEmpty(ImgPath))
            {
                hdnBellImagePath.Value = ResolveUrl(ImgPath);
                hasActiveAnnouncement = true;

                DataRow popupRow = ds.Tables[0].Rows[0];
                SetBellLink(hlBellWhatsApp, popupRow, "Whatsapp_Link");
                SetBellLink(hlDrive, popupRow, "Drive_Link");
                SetBellLink(hlBellYoutube, popupRow, "Youtube_Link");
                SetBellLink(hlBellWebsite, popupRow, "Website_Link");
            }
        }

        divBellLinksFooter.Visible = hasActiveAnnouncement &&
            (hlBellWhatsApp.Visible || hlDrive.Visible || hlBellYoutube.Visible || hlBellWebsite.Visible);

        // Badge on the bell icon: 0 when there's nothing active, 1 when there is
        // (the popup only ever surfaces a single active announcement at a time).
        hdnBellCount.Value = hasActiveAnnouncement ? "1" : "0";
    }

    private void SetBellLink(HyperLink link, DataRow row, string columnName)
    {
        if (row.Table.Columns.Contains(columnName) && row[columnName] != DBNull.Value
            && !string.IsNullOrWhiteSpace(row[columnName].ToString()))
        {
            link.NavigateUrl = row[columnName].ToString();
            link.Visible = true;
        }
        else
        {
            link.Visible = false;
        }
    }

    [System.Web.Services.WebMethod(EnableSession = true)]
    public static string GetAiExtractionLaunchUrl()
    {
        return SsoLaunch.BuildLaunchUrl();
    }

}
