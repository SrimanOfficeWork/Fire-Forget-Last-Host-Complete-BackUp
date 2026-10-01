using System;
using System.Data;
using System.Linq;
using System.Configuration;
using System.Web.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text;
using System.Web.Services;
using System.Collections.Generic;
using Microsoft.ApplicationBlocks.Data;
using System.Net;
using System.Text.RegularExpressions;



public partial class LoginPage_Premium_E_royal_Impex_Login_01 : System.Web.UI.Page
{

    Company_Master Comp = new Company_Master();
    AppSession aps = new AppSession();

    Login login = new Login();
    SqlCommand cmd;
    SqlConnection con;
    SqlDataAdapter da;
    SqlDataReader dr;
    DataSet ds = new DataSet();
    DropDownList ddl = new DropDownList();
    Date_Time dt = new Date_Time();



    public DateTime LoginDate, TODAY_DATE;

    public string COMPANY_LICENSE = "", USERNAME = "", BRANCH = "", WORKING_PERIOD = "", SELECT_TYPE;
    public string PWD, COMPANY_STATUS, COMPANY_ID, DB_CONN, COMP_WORKING_PERIOD;
    public string NEXT_RENEWEL_DATE, DATE_OF_INSTALLATION, DEFAULT_DATE, NETWORK_IP, LOCAL_NETWORK_IP, USER_JOB_LOCK, BILLING_STATUS;
    public string C_ID = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        C_ID = HttpUtility.UrlDecode(Request.QueryString["company"]);  // Added by Pandiyan on 14-10-2025 for Copper to Eroyal auto-login

        if (C_ID == "Eri00001" || C_ID == "Eri00115" || C_ID == "Eri03288")
        {
            Copper_Hawk();
        }
        expiremsg.Text = "";
        if (!string.IsNullOrEmpty(Request["from"]))
        {
            if (Request["from"].Trim() == "expired")
            {
                Response.Write("<script>window.open('Default.aspx','_top');</script>");
            }
        }

        con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);

        LoginDate = System.DateTime.Now;
        Session["LoginDate"] = LoginDate;

        if (!IsPostBack)
        {
            if (C_ID == "Eri00001" || C_ID == "Eri00115" || C_ID == "Eri03288")
            {
                // These 2 company IDs are allowed — do nothing here
            }
            else
            {
                Session.Abandon();
                txtCompany_License.Focus();
                txtPassword.Attributes.Add("value", txtPassword.Text.Trim());
            }

        }

        getIpAddress();

        //------------Start Freight to CHA 04June2024------------/
        HttpContext.Current.Session["FTC"] = "";
        if (!string.IsNullOrEmpty(Request["FTC"]))
        {
            HttpContext.Current.Session["FTC"] = Request.QueryString["FTC"].ToString();
            string FTC = HttpContext.Current.Session["FTC"].ToString();
            txtCompany_License.Text = Request.QueryString["Licence"];
            Freight_to_Cha_login();
            //txtCompany_License_TextChanged(sender, e);
            //btnCompany_Click(sender, e);
            txtUserId.Text = Request.QueryString["Login_id"];
            txtPassword.Text = Request.QueryString["Password"];
            txtPassword.Attributes.Add("value", txtPassword.Text.Trim());
            string Working_period = Request.QueryString["Working_period"];
            string Branch = Request.QueryString["Branch"];
            //ddlGroupname_SelectedIndexChanged(sender, e);
            string Group_Name = Request.QueryString["Group_Name"];
            ddlGroupname.Items.Add(Branch);
            //ddlBranch.SelectedValue = Request.QueryString["Branch"];
            ddlBranch.Items.Add(Group_Name);
            ddlWorkingPeriod.Items.Add(Working_period);
            //Session["COMPANY_ID"] = "10";
            hdn_result.Value = "1";
            btnLogin_Click(sender, e);
        }
        //------------End Freight to CHA ------------/
    }

    public void Freight_to_Cha_login()
    {
        Company_Master Comp = new Company_Master();
        txtCompany_License.Text = Request.QueryString["Licence"];
        Comp.COMPANY_ID = "0";
        Comp.COMPANY_LICENSE = txtCompany_License.Text;
        Comp.CLIENT_NAME = "";
        Comp.CONTACT_PERSON = "";
        Comp.MOBILE_NO = "";
        Comp.Ename = "select_Company_Login_Details";
        Comp.startRowIndex = "0";
        Comp.maximumRows = "0";
        DataSet ds = new DataSet();
        ds = Comp.RetrieveAll_Company_Details();
        HttpContext.Current.Session.Remove("COMPANY_DETAILS_DS");
        HttpContext.Current.Session["COMPANY_DETAILS_DS"] = ds;

        DataTable table1 = ds.Tables[2];
        DB_CONN = table1.Rows[0]["SERVER_NAME"].ToString();
        Session["currentcomp_db"] = DB_CONN.Replace("localhost", "182.76.213.91");
        DB_CONN = Session["currentcomp_db"].ToString();
    }

    public void getIpAddress()
    {
        string IPAdd = string.Empty;
        IPAdd = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        if (string.IsNullOrEmpty(IPAdd))
        {
            IPAdd = Request.ServerVariables["REMOTE_ADDR"];
            LOCAL_NETWORK_IP = IPAdd;
        }
    }

    #region FinancialYear
    public void LoadFinancialYear()
    {
        try
        {
            con.Open();
            ddlWorkingPeriod.Items.Clear();
            cmd = new SqlCommand("select * from FINANCIAL_YEAR order by id desc", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddlWorkingPeriod.Items.Add(dr["WORKING_PERIOD"].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        finally
        {
            con.Close();
        }
    }
    #endregion
    #region loadbranch
    public void LoadBranch()
    {
        try
        {
            if (txtCompany_License.Text != "")
            {
                login.LOGIN_ID = "0";
                login.COMPANY_LICENSE = txtCompany_License.Text;
                login.Ename = "Select_Login_Details";
                login.ISLOGIN = "0";

                ds = login.Check_Login_Details();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    COMPANY_LICENSE = ds.Tables[0].Rows[0]["COMPANY_LICENSE"].ToString();
                    USERNAME = ds.Tables[0].Rows[0]["USERNAME"].ToString();
                    PWD = ds.Tables[0].Rows[0]["PWD"].ToString();
                }
                if (COMPANY_LICENSE != "")
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                    }
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    #endregion

    protected void btn_AlreadyLogin_Click(object sender, EventArgs e)
    {

        if (Session["COMPANY_ID"] != null)
        {
            login.usrid = txtUserId.Text.Trim();
            login.passwd = txtPassword.Text.Trim();
            login.COMPANY_ID = Session["COMPANY_ID"].ToString();
            login.BRANCH = ddlBranch.SelectedValue.ToString();
            DB_CONN = Session["currentcomp_db"].ToString();
            login.flag = "Update_ISLogin_Status";
            login.startdt = "01/01/1900";
            login.expdt = "01/01/1900";

            //------------Start Freight to CHA 04June2024------------/
            if (!string.IsNullOrEmpty(Request["FTC"]))
            {
                Session["Theme"] = "Blue";
                COMPANY_ID = Session["COMPANY_ID"].ToString();
                aps.makeSession(txtUserId.Text.Trim(), txtPassword.Text.Trim(), ddlBranch.Text, ddlBranch.SelectedItem.ToString(), Session["CLIENT_NAME"].ToString(), DB_CONN, COMPANY_ID, Session["JOB_TYPE"].ToString(), Session["SELECT_TYPE"].ToString());
                Session["WorkingPeriod"] = ddlWorkingPeriod.SelectedValue.ToString();
                //Response.Redirect("~/LoginPage_Premium/E_royal_Impex_Main.aspx", false);
                Response.Redirect("~/LoginPage/E_royal_Impex_Main.aspx", false);
            }
            //------------End Freight to CHA ------------/
            else
            {
                if (DB_CONN != "")
                {
                    ds = login.Check_User_Login_Details();
                    Session.Remove("USER_DETAILS_DS");
                    Session["USER_DETAILS_DS"] = ds;
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Session["USER_CREATION_ID"] = ds.Tables[0].Rows[0]["USER_CREATION_ID"].ToString();
                        Session.Remove("Theme");

                        Session["Theme"] = ds.Tables[0].Rows[0]["THEME"].ToString();
                        COMPANY_ID = Session["COMPANY_ID"].ToString();
                        aps.makeSession(txtUserId.Text.Trim(), txtPassword.Text.Trim(), ddlBranch.Text, ddlBranch.SelectedItem.ToString(), Session["CLIENT_NAME"].ToString(), DB_CONN, COMPANY_ID, Session["JOB_TYPE"].ToString(), Session["SELECT_TYPE"].ToString());
                        Session["WorkingPeriod"] = ddlWorkingPeriod.SelectedValue.ToString();
                        //Response.Redirect("~/LoginPage_Premium/E_royal_Impex_Main.aspx", false);
                        Response.Redirect("~/LoginPage/E_royal_Impex_Main.aspx", false);
                        txtCompany_License.Text = "";
                        txtPassword.Text = "";
                        txtUserId.Text = "";
                        ddlBranch.SelectedIndex = -1;
                    }
                }
            }

        }
    }

    protected void btnCompany_Click(object sender, EventArgs e)
    {
        if (ddlGroupname.SelectedValue == "")
        {
            if (txtCompany_License.Text.Trim() != "")
            {
                if (Session["COMPANY_DETAILS_DS"] != null)
                {
                    ds = (DataSet)Session["COMPANY_DETAILS_DS"];
                }
                List<BranchDetails> details = new List<BranchDetails>();
                BranchDetails Branch1 = new BranchDetails();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Branch1.Comp_License = ds.Tables[0].Rows[0]["COMPANY_LICENSE"].ToString();
                    Branch1.result = Convert.ToString(Comp.result);
                    hdn_result.Value = "1";
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        foreach (DataRow dtrow in ds.Tables[1].Rows)
                        {
                            BranchDetails Branch = new BranchDetails();
                            Branch.CountryId = dtrow["BRANCH"].ToString();
                            string branch = dtrow["BRANCH"].ToString();
                            string branch_code = dtrow["PORT_OF_FILING"].ToString();
                            Branch.result = Convert.ToString(Comp.result);

                            string[] s1 = branch.Split(new string[] { "," }, StringSplitOptions.None);
                            string custom_Branch = s1[1].ToString();

                            DataView view1 = ds.Tables[3].DefaultView;
                            view1.RowFilter = "CUSTOMHOUSE_CODE = '" + branch_code + "'";

                            DataSet dt_UserRights = new DataSet();
                            dt_UserRights.Tables.Add(view1.ToTable());
                            if (dt_UserRights.Tables[0].Rows.Count > 0)
                            {
                                string a = dt_UserRights.Tables[0].Rows[0]["CUSTOMHOUSE_NAME"].ToString();
                                string mode = dt_UserRights.Tables[0].Rows[0]["CUSTOMHOUSE_CATEGORY"].ToString();
                                string Category_mode = "";
                                if (a == branch)
                                {
                                    if (mode == "A")
                                    {
                                        Category_mode = "Air";
                                    }
                                    if (mode == "S")
                                    {
                                        Category_mode = "Sea";
                                    }
                                    if (mode == "L")
                                    {
                                        Category_mode = "Land";
                                    }
                                    if (a == "Customs, Mundra")
                                    {
                                        Category_mode = "Sea";
                                    }

                                    Branch.CountryName = custom_Branch + "(" + Category_mode + ")";
                                    details.Add(Branch);
                                }
                            }
                        }

                        ddlBranch.DataSource = details.ToArray();
                        ddlBranch.DataValueField = "CountryId";
                        ddlBranch.DataTextField = "CountryName";
                        ddlBranch.DataBind();
                        txtUserId.Focus();
                    }
                }
                else
                {
                    txtCompany_License.Focus();
                    expiremsg.Text = "Your Company Account not activated. To activate contact admin";
                }
                Alert_msg("Your Company Account not activated. To activate contact admin");
            }
            else
                txtCompany_License.Focus();
        }

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtCompany_License.Text.Trim() != "" && txtUserId.Text.Trim() != "" && txtPassword.Text.Trim() != "" && ddlBranch.SelectedValue.ToString() != "" && ddlWorkingPeriod.SelectedValue.ToString() != "")
            {
                //Statrt to find the MTID due to redirect ETL Added by jayanthi 
                Mapping_Master map = new Mapping_Master();
                map.EROYAL_LICENSE = txtCompany_License.Text.Trim();
                map.flag = "Select-MappingCompany";
                DataSet dsComp = new DataSet();
                dsComp = map.RTS_LogixMapping();
                if (dsComp.Tables[0].Rows.Count > 0)  // ----- we are checking whether the given company license ID available in the mapping table .If yes , then check the below else the session is set with 0
                {
                    DataSet dsMap = new DataSet();
                    login.COMPANY_LICENSE = txtCompany_License.Text.Trim();
                    login.usrid = txtUserId.Text.Trim();
                    login.Ename = "MTID-Fetch";
                    dsMap = login.Check_RTSElogixMapping();  // data retrieved from Admin impex
                    if (dsMap.Tables[0].Rows.Count > 0)
                    {
                        Session["ETLMTID"] = dsMap.Tables[0].Rows[0]["MTID"].ToString();
                        HttpContext.Current.Session["ETLMTID"] = dsMap.Tables[0].Rows[0]["MTID"].ToString();
                        Session["RedURL"] = dsMap.Tables[0].Rows[0]["RedirectURL"].ToString();
                    }
                    else
                    {
                        Session["ETLMTID"] = "0";
                        HttpContext.Current.Session["ETLMTID"] = "0";
                    }
                }
                else
                {
                    Session["ETLMTID"] = "0";
                    HttpContext.Current.Session["ETLMTID"] = "0";
                }
                //end to find the MTID due to redirect ETL Added by jayanthi 
                Session.Remove("IsRTSUser");
                Session["IsRTSUser"] = "Y";

                Session.Remove("GroupName");
                Session.Remove("GroupID");
                Session["GroupID"] = ddlGroupname.SelectedValue.ToString();
                Session["GroupName"] = ddlGroupname.SelectedItem.ToString();

                if (Session["COMPANY_DETAILS_DS"] != null)
                {
                    ds = (DataSet)Session["COMPANY_DETAILS_DS"];
                }

                if (hdn_result.Value != "0" && hdn_result.Value != "")
                {
                    DataTable ds3 = new DataTable();
                    ds3 = ds.Tables[2];
                    DataView view1 = ds3.DefaultView;
                    string a = ddlWorkingPeriod.SelectedValue.ToString();
                    view1.RowFilter = "WORKING_PERIOD = '" + a + "'";
                    DataTable table1 = view1.ToTable();
                    //-----------------------------------------------------------------//
                    COMP_WORKING_PERIOD = table1.Rows[0]["WORKING_PERIOD"].ToString();
                    if (ddlWorkingPeriod.SelectedValue == COMP_WORKING_PERIOD)
                    {
                        DB_CONN = table1.Rows[0]["SERVER_NAME"].ToString();
                        SELECT_TYPE = table1.Rows[0]["SELECT_JOB"].ToString();
                        Session.Remove("SELECT_TYPE");
                        Session["SELECT_TYPE"] = SELECT_TYPE;
                    }
                    else
                    {
                        DB_CONN = "";
                    }

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        TODAY_DATE = Convert.ToDateTime(ds.Tables[0].Rows[0]["TODAY_DATE"].ToString());

                        NEXT_RENEWEL_DATE = ds.Tables[0].Rows[0]["NEXT_RENEWEL_DATE"].ToString();
                        DATE_OF_INSTALLATION = ds.Tables[0].Rows[0]["DATE_OF_INSTALLATION"].ToString();
                        COMPANY_STATUS = ds.Tables[0].Rows[0]["COMPANY_STATUS"].ToString();
                        COMPANY_ID = ds.Tables[0].Rows[0]["COMPANY_ID"].ToString();

                        DEFAULT_DATE = ds.Tables[0].Rows[0]["DEFAULT_DATE"].ToString();

                        NETWORK_IP = ds.Tables[0].Rows[0]["NETWORK_IP"].ToString();

                        USER_JOB_LOCK = ds.Tables[0].Rows[0]["USER_JOB_LOCK"].ToString();

                        BILLING_STATUS = ds.Tables[0].Rows[0]["BILLING_STATUS"].ToString();

                        Session.Remove("BILLING_STATUS");
                        Session["BILLING_STATUS"] = ds.Tables[0].Rows[0]["BILLING_STATUS"].ToString();

                        Session.Remove("USER_JOB_LOCK");
                        Session["USER_JOB_LOCK"] = ds.Tables[0].Rows[0]["USER_JOB_LOCK"].ToString();


                        Session.Remove("currentpassword");
                        Session["currentpassword"] = txtPassword.Text.Trim();
                        txtPassword.Text = Session["currentpassword"].ToString();

                        Session.Remove("CLIENT_NAME");
                        Session["CLIENT_NAME"] = ds.Tables[0].Rows[0]["CLIENT_NAME"].ToString();

                        Session.Remove("COMPANY_LICENSE");
                        Session["COMPANY_LICENSE"] = txtCompany_License.Text.Trim();

                        Session.Remove("COMPANY_ID");
                        Session["COMPANY_ID"] = COMPANY_ID;

                        Session.Remove("DEFAULT_DATE");
                        Session["DEFAULT_DATE"] = DEFAULT_DATE;

                        Session.Remove("NO_OF_USERS");
                        Session["NO_OF_USERS"] = ds.Tables[0].Rows[0]["NO_OF_USERS"].ToString();

                        string JOB_TYPE = ds.Tables[0].Rows[0]["SELECT_OPTION"].ToString();//-------IMPORT/EXPORT/BOTH
                        Session.Remove("JOB_TYPE");
                        Session["JOB_TYPE"] = JOB_TYPE;

                        Session.Remove("EMAILID");
                        Session["EMAILID"] = ds.Tables[0].Rows[0]["EMAILID"].ToString();

                        //--------S----------------------------------
                        Session.Remove("E_IMPORT"); Session.Remove("E_EXPORT");
                        Session.Remove("E_BILLING"); Session.Remove("E_ACCOUNTS");
                        Session["E_IMPORT"] = ds.Tables[0].Rows[0]["IMPORT"].ToString();
                        Session["E_EXPORT"] = ds.Tables[0].Rows[0]["EXPORT"].ToString();
                        Session["E_BILLING"] = ds.Tables[0].Rows[0]["BILLING"].ToString();
                        Session["E_ACCOUNTS"] = ds.Tables[0].Rows[0]["ACCOUNTS"].ToString();
                        //--------S----------------------------------

                        if (COMPANY_STATUS == "True")
                        {
                            login.usrid = txtUserId.Text.Trim();
                            login.passwd = txtPassword.Text.Trim();
                            login.COMPANY_ID = COMPANY_ID;
                            login.BRANCH = ddlBranch.SelectedValue.ToString();
                            login.startdt = DATE_OF_INSTALLATION;
                            login.expdt = NEXT_RENEWEL_DATE;

                            Session.Remove("currentcomp_db");
                            //Session["currentcomp_db"] = DB_CONN;

                            //Session["currentcomp_db"] = DB_CONN.Replace("localhost", "115.112.232.213");
                            Session["currentcomp_db"] = DB_CONN.Replace("localhost", "182.76.213.91");

                            //------Start Freight to CHA 04June2024----------//
                            if (!string.IsNullOrEmpty(Request["FTC"]))
                            {
                                Session.Remove("USER_DETAILS_DS");
                                //ds = login.Check_User_Login_Details();
                                //Session.Remove("SUBSCRIBE");

                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "OpenModalDialog", "<script type='text/javascript'>document.getElementById('btn_AlreadyLogin').click() ;</script>", false);

                                Session["USER_DETAILS_DS"] = ds;

                                //aps.makeSession(txtUserId.Text.Trim(), txtPassword.Text.Trim(), ddlBranch.Text, ddlBranch.SelectedItem.ToString(),
                                //    Session["CLIENT_NAME"].ToString(), DB_CONN, COMPANY_ID, JOB_TYPE, SELECT_TYPE);

                                Session["WorkingPeriod"] = ddlWorkingPeriod.SelectedValue.ToString();

                                //Response.Redirect("~/LoginPage_Premium/E_royal_Impex_Main.aspx", false);  
                                //Response.Redirect("~/LoginPage/E_royal_Impex_Main.aspx", false);

                            }
                            //------End Freight to CHA----------//
                            else
                            {
                                if (DB_CONN != "")
                                {
                                    Session.Remove("USER_DETAILS_DS");
                                    ds = login.Check_User_Login_Details();
                                    Session.Remove("SUBSCRIBE");
                                    string prompt = "<script>$(document).ready(function(){{window.jAlertsDialogClass='pm-login-conflict';jConfirm('You are already logged in! Do you want to kill the process and continue?', 'LOGIN', function (r) {var i = r + 'ok';if (i == 'trueok'){document.getElementById('txtPassword').value='" + txtPassword.Text.Trim() + "';document.getElementById('btn_AlreadyLogin').click();} else {}});window.jAlertsDialogClass=null;}});</script>";

                                    //-----------------------Check RENEWEL DATE-------------------//
                                    // bool Is_Renewel_date = Convert.ToDateTime(dt.Today_Date()) < Convert.ToDateTime(NEXT_RENEWEL_DATE);
                                    //-----------------------Check RENEWEL DATE-------------------//

                                    if (login.result == 1)
                                        expiremsg.Text = "Login Failed. Invalid User Id /Password";

                                    else if (login.result == 2)
                                        expiremsg.Text = "Your Account not activated. To activate contact admin!";

                                    else if (login.result == 3)
                                    {
                                        txtPassword.Attributes.Add("value", txtPassword.Text.Trim());

                                        expiremsg.Text = "You don't have permission to access " + ddlBranch.SelectedItem.ToString() + " Branch ";
                                        ddlBranch.Focus();
                                    }
                                    //else if (Is_Renewel_date == false)
                                    else if (login.result == 6)
                                    {
                                        expiremsg.Text = "Your Company License Expired. To activate contact admin";
                                        login.result = 0;
                                        //---------------------FOR AVOID ROYALTECH SYSTEMS DEACTIVATE-------------------//
                                        //if (ds.Tables[0].Rows.Count > 0)
                                        //{
                                        //    string Roll = ds.Tables[0].Rows[0]["TYPE"].ToString();
                                        //    if (Roll == "A")
                                        //    {

                                        //            Session["USER_DETAILS_DS"] = ds;
                                        //            if (ds.Tables[0].Rows.Count > 0)
                                        //                Session["USER_CREATION_ID"] = ds.Tables[0].Rows[0]["USER_CREATION_ID"].ToString();

                                        //            aps.makeSession(txtUserId.Text.Trim(), txtPassword.Text.Trim(), ddlBranch.Text, ddlBranch.SelectedItem.ToString(), Session["CLIENT_NAME"].ToString(), DB_CONN, COMPANY_ID, JOB_TYPE);

                                        //            Session["WorkingPeriod"] = ddlWorkingPeriod.SelectedValue.ToString();

                                        //            Response.Redirect("~/LoginPage_Premium/E_royal_Impex_Main.aspx", false);
                                        //            Response.Redirect("~/LoginPage/E_royal_Impex_Main.aspx", false);

                                        //            txtCompany_License.Text = "";
                                        //            txtPassword.Text = "";
                                        //            txtUserId.Text = "";
                                        //            ddlBranch.SelectedIndex = -1;

                                        //    }
                                        //    //---------------------FOR AVOID ROYALTECH SYSTEMS DEACTIVATE-------------------//
                                    }
                                    else if (login.result == 4)
                                    {
                                        if (ds.Tables[0].Rows.Count > 0)
                                        {
                                            string Within_network = ds.Tables[0].Rows[0]["WITHIN_NETWORK"].ToString();
                                            if (Within_network == "Yes")
                                            {
                                                if (Convert.ToInt32(COMPANY_ID) == 880)
                                                {
                                                    if (LOCAL_NETWORK_IP == NETWORK_IP || LOCAL_NETWORK_IP == "45.115.168.63")
                                                    {
                                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
                                                    }
                                                }
                                                else
                                                {
                                                    if (LOCAL_NETWORK_IP == NETWORK_IP)
                                                    {
                                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
                                            }

                                        }
                                    }
                                    else if (login.result == 5)
                                    {
                                        Session["USER_DETAILS_DS"] = ds;
                                        if (ds.Tables[0].Rows.Count > 0)
                                        {
                                            Session["USER_CREATION_ID"] = ds.Tables[0].Rows[0]["USER_CREATION_ID"].ToString();
                                            Session.Remove("Theme");
                                            Session["Theme"] = ds.Tables[0].Rows[0]["THEME"].ToString();

                                            Session.Remove("SUBSCRIBE");
                                            Session["SUBSCRIBE"] = ds.Tables[0].Rows[0]["SUBSCRIBE"].ToString();

                                            string Within_network = ds.Tables[0].Rows[0]["WITHIN_NETWORK"].ToString();

                                            aps.makeSession(txtUserId.Text.Trim(), txtPassword.Text.Trim(), ddlBranch.Text, ddlBranch.SelectedItem.ToString(), Session["CLIENT_NAME"].ToString(), DB_CONN, COMPANY_ID, JOB_TYPE, SELECT_TYPE);

                                            Session["WorkingPeriod"] = ddlWorkingPeriod.SelectedValue.ToString();

                                            String inv_date1 = string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(TODAY_DATE));

                                            String diff2 = (Convert.ToDateTime(NEXT_RENEWEL_DATE) - Convert.ToDateTime(inv_date1)).TotalDays.ToString();


                                            if (Within_network == "Yes")
                                            {
                                                if (LOCAL_NETWORK_IP == NETWORK_IP)
                                                {
                                                    if (Convert.ToInt32(COMPANY_ID) == 130 || Convert.ToInt32(COMPANY_ID) == 137 || Convert.ToInt32(COMPANY_ID) == 125 || Convert.ToInt32(COMPANY_ID) == 118 || Convert.ToInt32(COMPANY_ID) == 148 || Convert.ToInt32(COMPANY_ID) == 146)
                                                    {
                                                        if (Convert.ToUInt32(diff2) < 15)
                                                        {
                                                            MP_JOB.Show();
                                                            if (Convert.ToInt32(diff2) == 1)
                                                            {
                                                                //lblRenewal.Text = "Only " + diff2 + " day left for your AMC Renewal";
                                                                lblRenewal.Text = "AMC Renewal reminder - " + NEXT_RENEWEL_DATE + " ( " + diff2 + "day )";
                                                                lblContact.Text = "Contact No: 044-43603764";
                                                            }
                                                            else
                                                            {
                                                                //lblRenewal.Text = "Only " + diff2 + " days left for your AMC Renewal";
                                                                lblRenewal.Text = "AMC Renewal reminder - " + NEXT_RENEWEL_DATE + " ( " + diff2 + "days )";
                                                                lblContact.Text = "Contact No: 044-43603764";
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        //Response.Redirect("~/LoginPage_Premium/E_royal_Impex_Main.aspx", false);
                                                        Response.Redirect("~/LoginPage/E_royal_Impex_Main.aspx", false);
                                                    }

                                                }
                                            }
                                            else
                                            {
                                                if (Convert.ToUInt32(diff2) < 15)
                                                {
                                                    MP_JOB.Show();

                                                    if (Convert.ToInt32(diff2) == 1)
                                                    {
                                                        lblRenewal.Text = "AMC Renewal reminder - " + NEXT_RENEWEL_DATE + " ( " + diff2 + "day )";
                                                    }
                                                    else
                                                    {
                                                        lblRenewal.Text = "AMC Renewal reminder - " + NEXT_RENEWEL_DATE + " ( " + diff2 + "days )";
                                                    }
                                                }
                                                else
                                                {
                                                    //Response.Redirect("~/LoginPage_Premium/E_royal_Impex_Main.aspx", false);
                                                    Response.Redirect("~/LoginPage/E_royal_Impex_Main.aspx", false);
                                                }
                                            }

                                            txtCompany_License.Text = "";
                                            txtPassword.Text = "";
                                            txtUserId.Text = "";
                                            ddlBranch.SelectedIndex = -1;
                                        }
                                    }
                                }
                                else
                                {
                                    expiremsg.Text = "You don't have permission to access Working Period";
                                }
                            }
                        }
                        else
                        {
                            anchorID.InnerText = "Login URL changed from eroyalimpex.info to eroyalimpex.com . . . . . .  Click Here";
                            anchorID.Attributes["href"] = "https://www.Eroyalimpex.com";
                        }
                    }
                    else
                    {
                        expiremsg.Text = "Your Company Account not activated. To activate contact admin";
                    }
                }
                else
                {
                    expiremsg.Text = "Your Company Account not activated. To activate contact admin";
                }
            }
            else
            {
                expiremsg.Text = "Enter Username and Password";
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void SetLoginFieldsEnabled(bool enabled)
    {
        txtUserId.Enabled = enabled;
        txtPassword.Enabled = enabled;
        ddlGroupname.Enabled = enabled;
        ddlBranch.Enabled = enabled;
        ddlWorkingPeriod.Enabled = enabled;
    }

    protected void txtCompany_License_TextChanged(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtCompany_License.Text))
        {
            SetLoginFieldsEnabled(false);
            txtUserId.Text = "";
            txtPassword.Text = "";
            ddlGroupname.Items.Clear();
            ddlBranch.Items.Clear();
            ddlWorkingPeriod.Items.Clear();
            hdn_result.Value = "0";
            txtCompany_License.Focus();
            return;
        }

        string enteredLicense = txtCompany_License.Text.Trim();
        if (!Regex.IsMatch(enteredLicense, "^[a-zA-Z0-9]{1,10}$"))
        {
            SetLoginFieldsEnabled(false);
            txtUserId.Text = "";
            txtPassword.Text = "";
            ddlGroupname.Items.Clear();
            ddlBranch.Items.Clear();
            ddlWorkingPeriod.Items.Clear();
            hdn_result.Value = "0";
            Alert_msg("Company License can be up to 10 characters (letters and numbers only)", "txtCompany_License");
            return;
        }

        // Reset here so a company license that turns out invalid below can't
        // keep fields enabled off a stale "1" left over from an earlier,
        // valid license typed in the same session.
        hdn_result.Value = "0";

        Session.Remove("IsCHA_Mapped");
        Session["IsCHA_Mapped"] = "N";

        Company_Master Comp = new Company_Master();

        ddlBranch.SelectedIndex = -1;
        Comp.COMPANY_ID = "0";
        Comp.COMPANY_LICENSE = txtCompany_License.Text;
        Comp.CLIENT_NAME = "";
        Comp.CONTACT_PERSON = "";
        Comp.MOBILE_NO = "";
        Comp.Ename = "select_Company_Login_Details";
        Comp.startRowIndex = "0";
        Comp.maximumRows = "0";
        DataSet ds = new DataSet();
        ds = Comp.RetrieveAll_Company_Details();
        HttpContext.Current.Session.Remove("COMPANY_DETAILS_DS");
        HttpContext.Current.Session["COMPANY_DETAILS_DS"] = ds;
        if (ds.Tables.Count >= 2)
        {
            if (ds.Tables[2].Rows.Count > 0)
            {
                ddlWorkingPeriod.DataSource = ds.Tables[2];
                ddlWorkingPeriod.DataTextField = "WORKING_PERIOD";
                ddlWorkingPeriod.DataValueField = "WORKING_PERIOD";
                ddlWorkingPeriod.DataBind();
                Bind_Group(ddlWorkingPeriod.SelectedValue.ToString());
            }
            btnCompany_Click(sender, e);

            //  ***********Start to implement by jayanthi on 29-dec-21 to pull CHA DB details ****************//
            if (ds.Tables[5].Rows.Count > 0)
            {
                Comp.Ename = "select_Company_Login_Details_ForCHA";
                Comp.Freight_ConfigDetals = ds.Tables[5].Rows[0]["CHA_SERVER_DETAILS"].ToString();
                DataSet dsFRT = new DataSet();
                dsFRT = Comp.RetrieveAll_Company_Details();
                HttpContext.Current.Session.Remove("COMPANY_DETAILS_DS_FOR_FRT");
                HttpContext.Current.Session["COMPANY_DETAILS_DS_FOR_FRT"] = dsFRT;
                Session.Remove("COMPANY_DETAILS_DS_FOR_FRT");
                Session["COMPANY_DETAILS_DS_FOR_FRT"] = dsFRT;

                Session.Remove("currentcomp_db_FRT");
                DataView view_cha = dsFRT.Tables[5].DefaultView; //WORKING_PERIOD
                view_cha.RowFilter = "WORKING_PERIOD = '" + ddlWorkingPeriod.SelectedValue.ToString() + "'";
                Session["currentcomp_db_FRT"] = view_cha.ToTable().Rows[0]["FREIGHT_SERVER_DETAILS"].ToString();
                HttpContext.Current.Session["currentcomp_db_FRT"] = view_cha.ToTable().Rows[0]["FREIGHT_SERVER_DETAILS"].ToString();

                Session["IsCHA_Mapped"] = "Y";
            }
            //  ***********End to implement by jayanthi on 29-dec-21 to pull CHA DB details ****************//

        }

        // hdn_result only reaches "1" once a real branch/group was found for
        // this license further down the Bind_Group -> Bind_Branch chain
        // above - that's the actual "company license is valid" signal, so
        // it's what gates the rest of the login form instead of just "some
        // text was typed".
        SetLoginFieldsEnabled(hdn_result.Value == "1");
        txtUserId.Focus();
    }

    private void Bind_Group(string wk)
    {
        ddlGroupname.Items.Clear();
        DataSet ds = new DataSet();
        ds = (DataSet)HttpContext.Current.Session["COMPANY_DETAILS_DS"];
        DataView view1 = ds.Tables[2].DefaultView; //WORKING_PERIOD
        view1.RowFilter = "WORKING_PERIOD = '" + wk + "'";

        HttpContext.Current.Session["currentcomp_db"] = view1.ToTable().Rows[0]["SERVER_NAME"].ToString();
        Comp.COMPANY_ID = "";
        Comp.BRANCH = "";
        Comp.flag = "Select-Group";
        ds = Comp.RetrieveAll_Groups();
        HttpContext.Current.Session["ClientGrpMst"] = ds;
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlGroupname.DataSource = ds.Tables[0];
            ddlGroupname.DataTextField = "GROUP_NAME";
            ddlGroupname.DataValueField = "GROUP_ID";
            ddlGroupname.DataBind();
            HttpContext.Current.Session["ddlGroup_name"] = ds.Tables[0].Rows[0]["GROUP_NAME"].ToString();  // Added by Pandiyan on 16-10-2025 for Copper to Eroyal auto-login 
            Bind_Branch(ds.Tables[0].Rows[0]["GROUP_ID"].ToString(), ds.Tables[1]);
        }
    }

    private void Bind_Branch(string grpid, DataTable dt)
    {
        ddlBranch.Items.Clear();
        ds = (DataSet)Session["COMPANY_DETAILS_DS"];
        if (Session["COMPANY_DETAILS_DS"] != null)
        {
            ds = (DataSet)Session["COMPANY_DETAILS_DS"];
        }

        DataView view1 = dt.DefaultView;
        view1.RowFilter = "GROUP_ID = '" + grpid + "'";
        dt = view1.ToTable();

        List<BranchDetails> details = new List<BranchDetails>();
        BranchDetails Branch1 = new BranchDetails();
        if (dt.Rows.Count > 0)
        {

            Branch1.Comp_License = ds.Tables[0].Rows[0]["COMPANY_LICENSE"].ToString();
            Branch1.result = Convert.ToString(Comp.result);
            hdn_result.Value = "1";
            foreach (DataRow dtrow in dt.Rows)
            {
                BranchDetails Branch = new BranchDetails();
                Branch.CountryId = dtrow["BRANCHCODE"].ToString();
                string branch = dtrow["BRANCHCODE"].ToString();
                string customhouse = dtrow["CUSTOMHOUSE"].ToString();
                Branch.result = Convert.ToString(Comp.result);

                string[] s1 = branch.Split(new string[] { "," }, StringSplitOptions.None);
                string custom_Branch = s1[1].ToString();

                DataView view2 = ds.Tables[3].DefaultView;
                view2.RowFilter = "CUSTOMHOUSE_CODE = '" + customhouse + "'";

                DataSet dt_UserRights = new DataSet();
                dt_UserRights.Tables.Add(view2.ToTable());
                if (dt_UserRights.Tables[0].Rows.Count > 0)
                {
                    string a = dt_UserRights.Tables[0].Rows[0]["CUSTOMHOUSE_NAME"].ToString();
                    string mode = dt_UserRights.Tables[0].Rows[0]["CUSTOMHOUSE_CATEGORY"].ToString();
                    string Category_mode = "";
                    if (a == branch)
                    {
                        if (mode == "A")
                        {
                            Category_mode = "Air";
                        }
                        if (mode == "S")
                        {
                            Category_mode = "Sea";
                        }
                        if (mode == "L")
                        {
                            Category_mode = "Land";
                        }
                        if (a == "Customs, Mundra")
                        {
                            Category_mode = "Sea";
                        }
                        //Branch.CountryName = custom_Branch + "(" + Category_mode + ")"; //Hidden by George Bush on 01-06-2026
                        Branch.CountryName = customhouse + "-" + custom_Branch + "(" + Category_mode + ")";
                        details.Add(Branch);
                    }
                }
                ddlBranch.DataSource = details.ToArray();
                ddlBranch.DataValueField = "CountryId";
                ddlBranch.DataTextField = "CountryName";
                ddlBranch.DataBind();
            }
        }
        else
        {
            txtCompany_License.Focus();
            expiremsg.Text = "Your Company Account not activated. To activate contact admin";
        }
    }

    protected void ddlGroupname_SelectedIndexChanged(object sender, EventArgs e)
    {
        ds = (DataSet)HttpContext.Current.Session["ClientGrpMst"];
        Bind_Branch(ddlGroupname.SelectedValue, ds.Tables[1]);
        txtPassword.Attributes.Add("value", txtPassword.Text.Trim());
        ddlGroupname.Focus();
    }
    protected void ddlWorkingPeriod_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_Group(ddlWorkingPeriod.SelectedValue.ToString());
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'LOGIN', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'LOGIN', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    [System.Web.Services.WebMethod]
    public static BranchDetails[] BindDatatoDropdown(string mail)
    {
        List<BranchDetails> details = new List<BranchDetails>();
        Company_Master Comp = new Company_Master();

        Comp.COMPANY_ID = "0";
        Comp.COMPANY_LICENSE = mail;
        Comp.CLIENT_NAME = "";
        Comp.CONTACT_PERSON = "";
        Comp.MOBILE_NO = "";
        Comp.Ename = "select_Company_Login_Details";
        Comp.startRowIndex = "0";
        Comp.maximumRows = "0";
        DataSet ds = new DataSet();
        ds = Comp.RetrieveAll_Company_Details();

        HttpContext.Current.Session.Remove("COMPANY_DETAILS_DS");
        HttpContext.Current.Session["COMPANY_DETAILS_DS"] = ds;
        return details.ToArray();
    }

    public class BranchDetails
    {
        public string CountryId { get; set; }
        public string CountryName { get; set; }
        public string Comp_License { get; set; }
        public string result { get; set; }
    }
    public class change_branch
    {
        public string BranchName { get; set; }
    }
    protected void btnok_Click(object sender, EventArgs e)
    {
        //Response.Redirect("~/LoginPage_Premium/E_royal_Impex_Main.aspx", false);
        Response.Redirect("~/LoginPage/E_royal_Impex_Main.aspx", false);
    }
    private void Copper_Hawk()
    {
        string username = HttpUtility.UrlDecode(Request.QueryString["username"]);
        string password = HttpUtility.UrlDecode(Request.QueryString["password"]);
        string groupname = HttpUtility.UrlDecode(Request.QueryString["ddlGroupname"]);
        string branch = HttpUtility.UrlDecode(Request.QueryString["ddlBranch"]);
        string workingPeriod = HttpUtility.UrlDecode(Request.QueryString["ddlWorkingPeriod"]);

        if (C_ID == "Eri03288" || C_ID == "Eri00001")
        {

            if (!string.IsNullOrEmpty(C_ID))
            {
                txtCompany_License.Text = C_ID;
                txtCompany_License_TextChanged(txtCompany_License, EventArgs.Empty);
            }
            if (!string.IsNullOrEmpty(username))
            {
                txtUserId.Text = username;
            }

            if (!string.IsNullOrEmpty(password))
            {
                txtPassword.Text = password;
            }
            if (!string.IsNullOrEmpty(groupname))
            {
                /*
                DataTable dtGroup = new DataTable();
                dtGroup.Columns.Add("GROUP_ID");
                dtGroup.Columns.Add("GROUP_NAME");
                dtGroup.Rows.Add("1", groupname);

                ddlGroupname.DataSource = dtGroup;
                ddlGroupname.DataTextField = "GROUP_NAME";
                ddlGroupname.DataValueField = "GROUP_ID";
                ddlGroupname.DataBind();
                ddlGroupname.SelectedIndex = 0;
                */
                ddlGroupname.Items.Clear();
                ddlGroupname.Items.Insert(0, new ListItem(groupname, "1"));
                ddlGroupname.SelectedIndex = 0;
                HttpContext.Current.Session["groupname"] = groupname;
            }

            // --- Branch Dropdown Binding ---
            if (!string.IsNullOrEmpty(branch))
            {
                DataTable dtBranch = new DataTable();
                dtBranch.Columns.Add("BRANCH_CODE");
                dtBranch.Columns.Add("BRANCH_NAME");
                dtBranch.Rows.Add(branch, branch);

                ddlBranch.DataSource = dtBranch;
                ddlBranch.DataTextField = "BRANCH_NAME";
                ddlBranch.DataValueField = "BRANCH_CODE";
                ddlBranch.DataBind();
                ddlBranch.SelectedIndex = 0;
            }

            // --- Working Period Dropdown Binding ---
            if (!string.IsNullOrEmpty(workingPeriod))
            {
                DataTable dtPeriod = new DataTable();
                dtPeriod.Columns.Add("WORKING_PERIOD");
                dtPeriod.Rows.Add(workingPeriod);

                ddlWorkingPeriod.DataSource = dtPeriod;
                ddlWorkingPeriod.DataTextField = "WORKING_PERIOD";
                ddlWorkingPeriod.DataValueField = "WORKING_PERIOD";
                ddlWorkingPeriod.DataBind();
                ddlWorkingPeriod.SelectedIndex = 0;
            }

            if (!string.IsNullOrEmpty(C_ID) && !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                btnLogin_Click(btnLogin, EventArgs.Empty);
                btn_AlreadyLogin_Click(btnLogin, EventArgs.Empty);
            }
        }
    }

}
