using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using BussinessObject;
using System.Web.Script.Serialization;

public partial class Import_MasterPage_eRoyalMasters : System.Web.UI.MasterPage
{
    AppSession aps = new AppSession();
    DataSet ds = new DataSet();
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, userbranch = "", currentpwd;
    Date_Time dt = new Date_Time();
    public string COMPANY_IDD;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Screen_Id, Is_Master_Id;

    public string SELECT_TYPE, SELECT_BRANCH;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        currentuser = Session["currentuser"].ToString();
        currentpwd = Session["currentpassword"].ToString();
        userbranch = Session["currentbranch_code"].ToString();
        COMPANY_IDD = Session["COMPANY_ID"].ToString();

        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

        //comp_ttl.Text = Session["currentcomp_name"].ToString() + "  [Working Period - " + Working_Period + "]";

        if (!IsPostBack)
        {
            ShowNotification_Image();
            //lblworking_period.Text = Working_Period;

            if (Session["SELECT_TYPE"] != null)
            {
                SELECT_TYPE = Session["SELECT_TYPE"].ToString();

                if (SELECT_TYPE == "Branchwise Job")
                {
                    SELECT_BRANCH = currentbranch;
                    //lbl_lic.Text = "Lic. No :: " + Session["COMPANY_LICENSE"].ToString().ToLower();
                }
                else if (SELECT_TYPE == "Areawise Job")
                {
                    SELECT_BRANCH = currentbranch;
                    //lbl_lic.Text = "Lic. No ::: " + Session["COMPANY_LICENSE"].ToString().ToLower();
                }
                else
                {
                    SELECT_BRANCH = "";
                    //lbl_lic.Text = "Lic. No : " + Session["COMPANY_LICENSE"].ToString().ToLower();
                }
            }
            else
            {
                SELECT_BRANCH = "";
                //lbl_lic.Text = "Lic. No : " + Session["COMPANY_LICENSE"].ToString().ToLower();
            }

            //if (COMPANY_IDD == "318")
            //{
            //    if (currentuser.ToUpper() == "RIO")
            //    {
            //        Export_Main.Visible = false;
            //    }
            //    if (currentuser.ToUpper() == "RIO1")
            //    {
            //        Import_Main.Visible = false;
            //    }

            //}

            //-----------------

            if (Session["IsRTSUser"] != null)
            {
                if (Session["IsRTSUser"].ToString() == "Y")
                {
                    //ImgRTS_ELogixLogo.Src = "../images/logomain_master.png";
                    //lblph1.Text = "+91 98402 41678";
                    //lblph2.Text = "+91 93854 13685";

                    //lblph3.Text="";
                    //lblph4.Text = "";
                    /*
                    lblph3.Text = "Account & Payment Enquiries";
                    lblph4.Text = "+91 91762 85457";
                    */
                    //hrRTS.HRef = "http://royaltechsystems.co.in";
                    //hrRTS.InnerText = "Royal Tech   Systems";
                    //RTSSignout.Visible = true;
                    //ElogixSignout.Visible = false;
                }
                else
                {
                    //ImgRTS_ELogixLogo.Src = "../images/e-logix.png";
                    //lblph1.Text = "+91 9962370333";
                    //lblph2.Text = "+91 8072012724";
                    //lblph3.Text = "sales@invosys.co.in";
                    //lblph4.Text = "support@invosys.co.in";
                    //hrRTS.HRef = "http://invosys.co.in/";
                    //hrRTS.InnerText = "E-Logix";
                    //innerbox_Footer_logo.Visible = false;
                    //RTSSignout.Visible = false;
                    //ElogixSignout.Visible = true;

                    // innerbox_foo
                    //background-image:url(images/ERoyalImpex_footer_mainlogo.png); innerbox_Footer_logo

                }
            }
            else
            {
                //ImgRTS_ELogixLogo.Src = "../images/logomain_master.png";
                //lblph1.Text = "+91 98402 41678";
                //lblph2.Text = "+91 93854 13685";
                //lblph3.Text = "+91 88070 59886";
                //hrRTS.HRef = "http://royaltechsystems.co.in";
                //hrRTS.InnerText = "Royal Tech   Systems";
                //RTSSignout.Visible = true;
                //ElogixSignout.Visible = false;
            }


            //string prompt = "<script>document.getElementById('Master_Id').click();</script>";

            //ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), prompt, true);
            ScriptManager.RegisterStartupScript(UpdatePanel1, GetType(), "EnableSelectableKey", "happycode();", true);
            //mainmastopusernametxt.InnerText = "Welcome " + currentuser + " [Branch-" + dt.Split_main(",", currentbranch) + "]";
            //mainmastopusernametxt.InnerText = "Welcome " + currentuser;
            //mainmastopusernametxt.InnerText = currentuser;
            //mainmastopbranchtxt.InnerText = userbranch;
            //mainmastopbranchtxt.InnerText = dt.Split_main(",", currentbranch) + "]";// "+"Working Period-" + Working_Period;
            //mainmastopusernametxt5.InnerText =  Working_Period;

            //mainiframecontainer.Attributes["src"] = "E_royal_Impex_Home.aspx";            

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
                                //Royal_Admin_Id.Style.Add("display", "block");
                                //User_Admin_Id.Style.Add("display", "block");
                                //Company_Master_Id.Style.Add("display", "block");

                            }
                            if (Roll == "S")
                            {
                                //Royal_Admin_Id.Style.Add("display", "none");
                                //User_Admin_Id.Style.Add("display", "block");
                                //Company_Master_Id.Style.Add("display", "none");

                            }
                            if (Roll == "U")
                            {
                                //Royal_Admin_Id.Style.Add("display", "none");
                                //User_Admin_Id.Style.Add("display", "none");
                                //Company_Master_Id.Style.Add("display", "none");

                            }
                        }
                    }

                    //ds = (DataSet)Session["USER_DETAILS_DS"];
                    DataView view1 = ds.Tables[1].DefaultView;
                    string COMPANY_ID, USER_CREATION_ID, BRANCH;
                    COMPANY_ID = Session["COMPANY_ID"].ToString();
                    USER_CREATION_ID = Session["USER_CREATION_ID"].ToString();
                    BRANCH = Session["currentbranch"].ToString();

                    view1.RowFilter = "BRANCH = '" + BRANCH + "' and " + "COMPANY_ID = " + COMPANY_ID + " and " + "USER_CREATION_ID = " + USER_CREATION_ID + "";
                    // and " + "BRANCH = " + BRANCH;
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
                    //if (Is_Master_Id == "true")
                    //    Master_Id.Style.Add("display", "block");
                    //else

                    //    Master_Id.Style.Add("display", "none");
                   
                  
                }

            }
            catch (Exception ex)
            {
                ErrorLogs erl = new ErrorLogs();
                erl.makeLog(ex.Message.ToString());
            }
            LoadAdImagesJson();
        }
    }
    private void LoadAdImagesJson()
    {
        List<string> imageUrls = new List<string>(); 
        if (Session["AdImagesLoaded"] == null)
        {
            Session["AdImagesLoaded"] = true;
            Session["AdImagesJson"] = "";
            Upload_Ad jh = new Upload_Ad();
            Global_variables ObjUBO = new Global_variables();
            ObjUBO.A1 = "SELECT";
            DataSet dss = jh.Upload_Ads_Ins_Up(ObjUBO, "");

            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                DataTable dt = dss.Tables[0];

                foreach (DataRow row in dt.Rows)
                {
                    string fileName = row["ATTACHMENT_FILE"].ToString();
                    string virtualName = string.Format("../Submission/Upload_Poster/{0}", fileName);
                    imageUrls.Add(virtualName);
                }
                Session["AdImagesJson"] = imageUrls;
            }
        }
        var sessionImageUrls = Session["AdImagesJson"] as List<string> ?? new List<string>();
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        hdAdsJson.Value = serializer.Serialize(sessionImageUrls);
    }



    public void Transaction_Type()
    {
        string JOB_TYPE = Session["JOB_TYPE"].ToString();
        if (JOB_TYPE == "Import")
        {
            //Import_Id.Style.Add("display", "block");
            //Export_Id.Style.Add("display", "none");
            //Export_Goods_Reg_Id.Style.Add("display", "none");
        }
        if (JOB_TYPE == "Export")
        {
            //Import_Id.Style.Add("display", "none");
            //Export_Id.Style.Add("display", "block");
            //Export_Goods_Reg_Id.Style.Add("display", "block");
        }

        if (JOB_TYPE == "Both")
        {
            //Import_Id.Style.Add("display", "block");
            //Export_Id.Style.Add("display", "block");
            //Export_Goods_Reg_Id.Style.Add("display", "block");
        }
    }

    //public void ShowNotification_Image()
    //{
    //    DataSet ds = new System.Data.DataSet();
    //    Live_updation Lu = new Live_updation();
    //    Lu.Flag = "IMAGE_POPUP";
    //    ds = Lu.Live_Updation_Img_Select();
    //    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
    //    {
    //        string ImgPath = ds.Tables[0].Rows[0]["ImagePath"].ToString();
    //        if (!string.IsNullOrEmpty(ImgPath))
    //        {
    //            hdnBellImagePath.Value = ResolveUrl(ImgPath);
    //        }

    //        DataRow popupRow = ds.Tables[0].Rows[0];// Added by shanthini on 22-07-2026
    //        SetBellLink(hlBellWhatsApp, popupRow, "Whatsapp_Link");
    //        SetBellLink(hlDrive, popupRow, "Drive_Link");
    //        SetBellLink(hlBellYoutube, popupRow, "Youtube_Link");
    //        SetBellLink(hlBellWebsite, popupRow, "Website_Link");

    //        divBellLinksFooter.Visible = hlBellWhatsApp.Visible || hlDrive.Visible 
    //                                   || hlBellYoutube.Visible || hlBellWebsite.Visible;
    //    }
    //}
    public void ShowNotification_Image()
    {
        DataSet ds = new System.Data.DataSet();
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

                DataRow popupRow = ds.Tables[0].Rows[0]; // Added by shanthini on 22-07-2026
                SetBellLink(hlBellWhatsApp, popupRow, "Whatsapp_Link");
                SetBellLink(hlDrive, popupRow, "Drive_Link");
                SetBellLink(hlBellYoutube, popupRow, "Youtube_Link");
                SetBellLink(hlBellWebsite, popupRow, "Website_Link");
            }
        }

        // Footer only shows if there's an active image AND at least one link
        divBellLinksFooter.Visible = hasActiveAnnouncement &&
            (hlBellWhatsApp.Visible || hlDrive.Visible || hlBellYoutube.Visible || hlBellWebsite.Visible);
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
    public void Page_Show_Hide(int i)
    {
        bool is_page;
        if (i == 0)
        {

            //Import_Job_Id.Style.Add("display", "none");
            //Import_Submission_Id.Style.Add("display", "none");

            //Import_Job_Duplicate_Id.Style.Add("display", "none");

            //Import_BE_Entry_Id.Style.Add("display", "none");

            //Import_Statements_Id.Style.Add("display", "none");

            //Export_Job_Id.Style.Add("display", "none");
            //Export_Submission_Id.Style.Add("display", "none");

            //Export_Job_Duplicate_Id.Style.Add("display", "none");
            //Export_Goods_Reg_Job_Id.Style.Add("display", "none");
            //Export_Goods_Reg_Submission_Id.Style.Add("display", "none");

            //Export_Goods_Reg_Job_Duplicate_Id.Style.Add("display", "none");



        }
        //-----------------------------------------------------------------MASTER PAGES----------------------------------------------------------//
        if (i == 1)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                //Client_Id.Style.Add("display", "block");

                Is_Master_Id = "true";
            }
            else
            {
                //Client_Id.Style.Add("display", "none");
                if (Is_Master_Id != "true")// FOR MASTER LINK HIDE
                    Is_Master_Id = "false";

            }

        }
        if (i == 2)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                //Supplier_Id.Style.Add("display", "block");
                Is_Master_Id = "true";

            }
            else
            {
                //Supplier_Id.Style.Add("display", "none");
                if (Is_Master_Id != "true")
                    Is_Master_Id = "false";

            }

        }
        if (i == 3)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                //Consignee_Id.Style.Add("display", "block");
                Is_Master_Id = "true";

            }
            else
            {
                //Consignee_Id.Style.Add("display", "none");
                if (Is_Master_Id != "true")
                    Is_Master_Id = "false";

            }
        }
        if (i == 4)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                //Adcode_Id.Style.Add("display", "block");
                Is_Master_Id = "true";

            }
            else
            {
                //Adcode_Id.Style.Add("display", "none");
                if (Is_Master_Id != "true")
                    Is_Master_Id = "false";

            }
        }
        if (i == 5)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                //Buyer_Id.Style.Add("display", "block");
                Is_Master_Id = "true";

            }
            else
            {
                //Buyer_Id.Style.Add("display", "none");
                if (Is_Master_Id != "true")
                    Is_Master_Id = "false";

            }
        }
        if (i == 6)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                //License_Id.Style.Add("display", "block");
                Is_Master_Id = "true";

            }
            else
            {
                //License_Id.Style.Add("display", "none");
                if (Is_Master_Id != "true")
                    Is_Master_Id = "false";

            }
        }

        //-----------------------------------------------------------------MASTER PAGES----------------------------------------------------------//

        //-----------------------------------------------------------------IMPORT PAGES----------------------------------------------------------//

        if (i == 7)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                //Import_Job_Id.Style.Add("display", "block");

            }
            else
            {
                //Import_Job_Id.Style.Add("display", "none");

            }

        }
        if (i == 8)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                //Import_Submission_Id.Style.Add("display", "block");

            }
            else
            {
                //Import_Submission_Id.Style.Add("display", "none");

            }

        }
        if (i == 9)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                //Import_Job_Duplicate_Id.Style.Add("display", "block");

            }
            else
            {
                //Import_Job_Duplicate_Id.Style.Add("display", "none");

            }

        }
        if (i == 10)
        {
            is_page = Page_Rights();

        }
        if (i == 11)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                //Import_BE_Entry_Id.Style.Add("display", "block");

            }
            else
            {
                //Import_BE_Entry_Id.Style.Add("display", "none");

            }

        }
        //-----------------------------------------------------------------IMPORT PAGES----------------------------------------------------------//
        //-----------------------------------------------------------------EXPORT PAGES----------------------------------------------------------//

        if (i == 12)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                //Export_Job_Id.Style.Add("display", "block");
                //Export_Goods_Reg_Job_Id.Style.Add("display", "block");

            }
            else
            {
                //Export_Job_Id.Style.Add("display", "none");
                //Export_Goods_Reg_Job_Id.Style.Add("display", "none");

            }

        }
        if (i == 13)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                //Export_Submission_Id.Style.Add("display", "block");
                //Export_Goods_Reg_Submission_Id.Style.Add("display", "block");

            }
            else
            {
                //Export_Submission_Id.Style.Add("display", "none");
                //Export_Goods_Reg_Submission_Id.Style.Add("display", "none");

            }

        }
        if (i == 14)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                //Export_Job_Duplicate_Id.Style.Add("display", "block");
                //Export_Goods_Reg_Job_Duplicate_Id.Style.Add("display", "block");

            }
            else
            {
                //Export_Job_Duplicate_Id.Style.Add("display", "none");
                //Export_Goods_Reg_Job_Duplicate_Id.Style.Add("display", "none");

            }

        }
        if (i == 15)
        {
            is_page = Page_Rights();


        }
        //-----------------------------------------------------------------EXPORT PAGES----------------------------------------------------------//

        //if (PAGE_READ == "True" && PAGE_WRITE == "True" && PAGE_MODIFY == "True" && PAGE_DELETE == "True")
        //{



        //}
        //else
        //{


        //}

        //i = i - 1;
        // string[] strArray = new string[14] { "Client_Id", "Supplier_Id", "Consignee_Id", "Adcode_Id", "Product_Id", "Import_Job_Id", "Import_Submission_Id", "Import_Job_Duplicate_Id", "Import_Statements_Id", "Import_BE_Entry_Id", "Export_Job_Id", "Export_Submission_Id", "Export_Job_Duplicate_Id", "Import_Statements_Id" };
        // string display = "";
        //Response.Write("<script>Page_Rights('" + strArray[i].ToString() + "','" + display + "');</script>");
        //string prompt = "<script>$(document).ready(function(){{document.getElementById('" + strArray[i].ToString() + "').style.display = '" + display + "';}});</script>";

        //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);

        //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "Page_Rights('" + strArray[i].ToString() + "','" + display + "');", false);

    }
    public bool Page_Rights()
    {
        bool Is_Page;
        if (PAGE_READ == "False" && PAGE_WRITE == "False" && PAGE_MODIFY == "False" && PAGE_DELETE == "False")
        {

            Is_Page = false;

        }
        //else if (PAGE_READ == "False" && PAGE_WRITE == "False" && PAGE_MODIFY == "False" && PAGE_DELETE == "False")
        //{

        //    Is_Page = false;

        //}
        else
        {
            Is_Page = true;


        }
        return Is_Page;
    }
}