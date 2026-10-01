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


    public partial class LoginPage_DefaultNew : System.Web.UI.Page
    {

        Company_Master Comp = new Company_Master();
        AppSession aps = new AppSession();        
        Login login = new Login();
     
        //SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings.Get("con"));
        SqlConnection con;
      
        DataSet ds = new DataSet();
     
        Date_Time dt = new Date_Time();
        #region public string

        public string user_database = "", branch_cd = "", branch_name = "";
       
        public DateTime LoginDate, TODAY_DATE;

        public string COMPANY_LICENSE = "";
        public string USERNAME = "";
        public string BRANCH = "";
      
        public string CLIENT_NAME = "";
        public string DATABASE_NAME,SELECT_TYPE;
        public string LOGIN_NAME;
        public string COMPANY_STATUS, COMPANY_ID, DB_CONN, COMP_WORKING_PERIOD;
        public string NEXT_RENEWEL_DATE, DATE_OF_INSTALLATION, DEFAULT_DATE, NETWORK_IP, LOCAL_NETWORK_IP, USER_JOB_LOCK, BILLING_STATUS;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            //string ReqMTID = "4";
            string ReqMTID = Request.QueryString["MTID"].ToString();

            Session["ETLMTID"] = ReqMTID.ToString();
            HttpContext.Current.Session["ETLMTID"] = ReqMTID.ToString();

            string txtLicense = "";
            string txtUser = "";
            string txtPass = "";
            string branch = "";

            string wk = "";
            string branccode = "";

            DataSet dsMap = new DataSet();
            DataSet dsLogin = new DataSet();

            expiremsg.Text = "";

            if (!string.IsNullOrEmpty(Request["from"]))
            {
                if (Request["from"].Trim() == "expired")
                {

                    string test = Request.Browser.Type.Substring(0, 1);
                    if (test.ToUpper() == "I")
                    {
                        Response.Write("<script>window.open('http://icegatesign.ncode.in:8080/ICEGATE/signTextFiles.jsp','_top');</script>");
                    }
                    else
                    {
                        Response.Write("<script>window.open('Default.aspx','_top');</script>");
                    }

                }

            }

            con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);

            login.LOGIN_ID = ReqMTID;
            login.Ename = "select_MTID";
            dsMap = login.Check_RTSElogixMapping();  // data retrieved from Admin impex
            if (dsMap.Tables[0].Rows.Count > 0)
            {
                txtLicense = dsMap.Tables[0].Rows[0]["RTS_CompLicenseID"].ToString();
                txtUser = dsMap.Tables[0].Rows[0]["RTS_UserName"].ToString();

                Session.Remove("currentuser");
                Session["currentuser"] = txtUser.ToString();
                HttpContext.Current.Session["currentpassword"] = txtUser.ToString();

                branch = dsMap.Tables[0].Rows[0]["RTS_Branch"].ToString();
            }

            LoginDate = System.DateTime.Now;
            Session["LoginDate"] = LoginDate;
            Session["WorkingPeriod"] = wk.ToString();

            getIpAddress();


            Company_Master Comp = new Company_Master();

            Comp.COMPANY_LICENSE = txtLicense.ToString();
            Comp.Ename = "select_Company_Login_Details";
            Comp.startRowIndex = "0";
            Comp.maximumRows = "0";
            DataSet ds = new DataSet();
            ds = Comp.RetrieveAll_Company_Details();
            HttpContext.Current.Session.Remove("COMPANY_DETAILS_DS");
            HttpContext.Current.Session["COMPANY_DETAILS_DS"] = ds;
            if (ds.Tables[2].Rows.Count > 0)
            {
                wk = ds.Tables[2].Rows[ds.Tables[2].Rows.Count - 1]["WORKING_PERIOD"].ToString();
                Session["currentcomp_db"] = ds.Tables[2].Rows[ds.Tables[2].Rows.Count - 1]["SERVER_NAME"].ToString();
                DB_CONN = ds.Tables[2].Rows[ds.Tables[2].Rows.Count - 1]["SERVER_NAME"].ToString();
                SELECT_TYPE = ds.Tables[2].Rows[ds.Tables[2].Rows.Count - 1]["SELECT_JOB"].ToString();
                Session.Remove("SELECT_TYPE");
                Session["SELECT_TYPE"] = SELECT_TYPE;

                //******* these two lines added on 30-oct-18 by jayanthi
                Session.Remove("WorkingPeriod");
                Session["WorkingPeriod"] = wk.ToString();

            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                string branch_code = "";
                string[] s1; ;
                string custom_Branch = "";

                DataView vwbrn = ds.Tables[1].DefaultView;
                vwbrn.RowFilter = "BRANCH = '" + branch + "'";
                DataSet dsbrn = new DataSet();
                dsbrn.Tables.Add(vwbrn.ToTable());


                if (dsbrn.Tables[0].Rows.Count > 0)
                {
                    branch_code = dsbrn.Tables[0].Rows[0]["PORT_OF_FILING"].ToString();
                    s1 = branch.Split(new string[] { "," }, StringSplitOptions.None);
                    custom_Branch = s1[1].ToString();
                }


                //branch = ds.Tables[1].Rows[0]["BRANCH"].ToString();


                DataView view1 = ds.Tables[3].DefaultView;
                view1.RowFilter = "CUSTOMHOUSE_CODE = '" + branch_code + "'";

                //branch = ds.Tables[3].Rows[0]["CUSTOMHOUSE_NAME"].ToString();
                //string branch_code = ds.Tables[3].Rows[0]["CUSTOMHOUSE_CODE"].ToString();
                //string[] s1 = branch.Split(new string[] { "," }, StringSplitOptions.None);
                //string custom_Branch = s1[1].ToString();

                //DataView view1 = ds.Tables[3].DefaultView;
                //view1.RowFilter = "CUSTOMHOUSE_CODE = '" + ds.Tables[3].Rows[0]["CUSTOMHOUSE_CODE"].ToString() + "'"; 

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
                            Category_mode = "Air";
                        if (mode == "S")
                            Category_mode = "Sea";
                        if (mode == "L")
                            Category_mode = "Land";

                        if (a == "Customs, Mundra")
                            Category_mode = "Sea";

                        branccode = custom_Branch + "(" + Category_mode + ")";

                        HttpContext.Current.Session["currentbranch"] = branch;


                    }
                }
            }



            login.usrid = txtUser.ToString();
            login.LOGIN_ID = ds.Tables[0].Rows[0]["COMPANY_ID"].ToString();
            login.Ename = "select_MapUser";

            Session.Remove("COMPANY_ID");
            Session["COMPANY_ID"] = ds.Tables[0].Rows[0]["COMPANY_ID"].ToString();
            COMPANY_ID = ds.Tables[0].Rows[0]["COMPANY_ID"].ToString();

            dsLogin = login.Check_RTSElogixMapping();  // data retrieved from end user DB
            if (dsLogin.Tables[0].Rows.Count > 0)
            {
                Session.Remove("currentpassword");
                Session["currentpassword"] = dsLogin.Tables[0].Rows[0]["PWD"].ToString();
                HttpContext.Current.Session["currentpassword"] = dsLogin.Tables[0].Rows[0]["PWD"].ToString();
                txtPass = dsLogin.Tables[0].Rows[0]["PWD"].ToString();
            }


            if (ds.Tables[0].Rows.Count > 0)
            {
                Session.Remove("BILLING_STATUS");
                Session.Remove("USER_JOB_LOCK");
                Session.Remove("CLIENT_NAME");
                Session.Remove("COMPANY_LICENSE");
                Session.Remove("DEFAULT_DATE");
                Session.Remove("NO_OF_USERS");
                Session.Remove("JOB_TYPE");
                Session.Remove("EMAILID");


                TODAY_DATE = Convert.ToDateTime(ds.Tables[0].Rows[0]["TODAY_DATE"].ToString());
                NEXT_RENEWEL_DATE = ds.Tables[0].Rows[0]["NEXT_RENEWEL_DATE"].ToString();
                DATE_OF_INSTALLATION = ds.Tables[0].Rows[0]["DATE_OF_INSTALLATION"].ToString();
                COMPANY_STATUS = ds.Tables[0].Rows[0]["COMPANY_STATUS"].ToString();
                COMPANY_ID = ds.Tables[0].Rows[0]["COMPANY_ID"].ToString();

                DEFAULT_DATE = ds.Tables[0].Rows[0]["DEFAULT_DATE"].ToString();

                NETWORK_IP = ds.Tables[0].Rows[0]["NETWORK_IP"].ToString();

                USER_JOB_LOCK = ds.Tables[0].Rows[0]["USER_JOB_LOCK"].ToString();

                BILLING_STATUS = ds.Tables[0].Rows[0]["BILLING_STATUS"].ToString();
                CLIENT_NAME = ds.Tables[0].Rows[0]["CLIENT_NAME"].ToString();

                Session["BILLING_STATUS"] = ds.Tables[0].Rows[0]["BILLING_STATUS"].ToString();
                Session["USER_JOB_LOCK"] = ds.Tables[0].Rows[0]["USER_JOB_LOCK"].ToString();

                Session["CLIENT_NAME"] = ds.Tables[0].Rows[0]["CLIENT_NAME"].ToString();
                Session["COMPANY_LICENSE"] = txtLicense.ToString();
                Session["DEFAULT_DATE"] = DEFAULT_DATE;
                Session["NO_OF_USERS"] = ds.Tables[0].Rows[0]["NO_OF_USERS"].ToString();
                Session["JOB_TYPE"] = ds.Tables[0].Rows[0]["SELECT_OPTION"].ToString();
                Session["EMAILID"] = ds.Tables[0].Rows[0]["EMAILID"].ToString();

                if (COMPANY_STATUS == "True")
                {
                    login.usrid = txtUser.ToString();
                    login.passwd = txtPass.ToString();
                    login.COMPANY_ID = COMPANY_ID;
                    login.BRANCH = branch.ToString();
                    login.startdt = DATE_OF_INSTALLATION;
                    login.expdt = NEXT_RENEWEL_DATE;

                    Session.Remove("currentcomp_db");

                    //Session["currentcomp_db"] = DB_CONN.Replace("localhost", "115.112.232.213");
                    Session["currentcomp_db"] = DB_CONN.Replace("localhost", "182.76.213.91");

                    if (DB_CONN != "")
                    {
                        Session.Remove("USER_DETAILS_DS");
                        ds = login.Check_User_Login_Details();
                        Session.Remove("SUBSCRIBE");

                        string prompt = "<script>$(document).ready(function(){document.getElementById('btn_AlreadyLogin').click()});</script>";


                        if (login.result == 1)
                            expiremsg.Text = "Login Failed. Invalid User Id /Password";

                        else if (login.result == 2)
                            expiremsg.Text = "Your Account not activated. To activate contact admin!";

                        else if (login.result == 3)
                        {
                            expiremsg.Text = "You don't have permission to access the branch";

                        }

                        else if (login.result == 6)
                        {
                            expiremsg.Text = "Your Company License Expired. To activate contact admin";
                            login.result = 0;
                        }

                        else if (login.result == 4)
                        {

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                string Within_network = ds.Tables[0].Rows[0]["WITHIN_NETWORK"].ToString();


                                if (Within_network == "Yes")
                                {
                                    if (LOCAL_NETWORK_IP == NETWORK_IP)
                                    {

                                        login.flag = "Update_ISLogin_Status";
                                        login.startdt = "01/01/1900";
                                        login.expdt = "01/01/1900";

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
                                                aps.makeSession(txtUser.ToString(), txtPass.ToString(), branch.ToString(), branccode.ToString(), Session["CLIENT_NAME"].ToString(), DB_CONN, COMPANY_ID, Session["JOB_TYPE"].ToString(), Session["SELECT_TYPE"].ToString());
                                                Response.Redirect("~/LoginPage/E_royal_Impex_Main.aspx", false);

                                            }
                                        }

                                    }
                                }
                                else
                                {

                                    login.flag = "Update_ISLogin_Status";
                                    login.startdt = "01/01/1900";
                                    login.expdt = "01/01/1900";

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
                                            aps.makeSession(txtUser.ToString(), txtPass.ToString(), branch.ToString(), branccode.ToString(), Session["CLIENT_NAME"].ToString(), DB_CONN, COMPANY_ID, Session["JOB_TYPE"].ToString(), Session["SELECT_TYPE"].ToString());
                                            Response.Redirect("~/LoginPage/E_royal_Impex_Main.aspx", false);

                                        }
                                    }

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
                                //aps.makeSession(txtUser.ToString(), txtPass.ToString(), "ACC, Bangalore", "Bangalore(Air)", Session["CLIENT_NAME"].ToString(), DB_CONN, COMPANY_ID, Session["JOB_TYPE"].ToString(), Session["SELECT_TYPE"].ToString());
                                aps.makeSession(txtUser.ToString(), txtPass.ToString(), branch.ToString(), branccode.ToString(), Session["CLIENT_NAME"].ToString(), DB_CONN, COMPANY_ID, Session["JOB_TYPE"].ToString(), Session["SELECT_TYPE"].ToString());

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
                                                    lblRenewal.Text = "AMC Renewal reminder - " + NEXT_RENEWEL_DATE + " ( " + diff2 + "day )";
                                                    lblContact.Text = "Contact No: 044-43603764";
                                                }
                                                else
                                                {
                                                    lblRenewal.Text = "AMC Renewal reminder - " + NEXT_RENEWEL_DATE + " ( " + diff2 + "days )";
                                                    lblContact.Text = "Contact No: 044-43603764";
                                                }
                                            }
                                        }
                                        else
                                        {
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
                                        Response.Redirect("~/LoginPage/E_royal_Impex_Main.aspx", false);
                                    }

                                }
                            }
                        }
                    }
                    else
                    {
                        expiremsg.Text = "You don't have permission to access Working Period";
                    }
                }
                else
                    expiremsg.Text = "Your Company License is Deactivated ! Please contact Admin...";
            }
            else
                expiremsg.Text = "Your Company Account not activated. To activate contact admin";
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

 
}
