using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;


public class AppSession : ErrorLogs
{
    public string currentLoginId, currentLoginPassword,currentbranch, userbranchcode,isactive, branch_code,comp_companyname,comp_ConnectionStr;
    //public string u, p, b, comp_name, db, comp_branch;
    public string expireerror="";
    SqlConnection scn;
    DataSet ds;
    SqlCommand cmd;
    ErrorLogs er = new ErrorLogs();
    SqlDataAdapter da;
    SqlDataReader dr;
    bool result = false;
    //SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings.Get("con"));
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);
    protected SqlCommand scmd;
    protected SqlDataReader sdr;
    public bool isInnerPage;
    public int pid = 0;
    public string comp_name = "";
    public string comp_add1 = "";
    public string comp_add2 = "";
    public string comp_add3 = "";
    public string comp_pincode = "";
    public string sup_countrycode = "";
    public string sup_pincode = "";
    public string sup_remarks = "";


    public void makeSession(string currentLoginId, string currentLoginPassword, string currentbranch, string currentbranch_code, string comp_companyname, string comp_ConnectionStr, string COMPANY_ID, string JOB_TYPE, string SELECT_TYPE)
    {
        HttpContext.Current.Session.Remove("currentuser");
        HttpContext.Current.Session.Remove("currentpassword");
        HttpContext.Current.Session.Remove("currentbranch");
        HttpContext.Current.Session.Remove("currentbranch_code");
        HttpContext.Current.Session.Remove("currentcomp_name");
        HttpContext.Current.Session.Remove("currentcomp_db");
        HttpContext.Current.Session.Remove("COMPANY_ID");
        HttpContext.Current.Session.Remove("JOB_TYPE");
        HttpContext.Current.Session.Remove("SELECT_TYPE");
      

        HttpContext.Current.Session["currentuser"] = currentLoginId;
        HttpContext.Current.Session["currentpassword"] = currentLoginPassword;
        HttpContext.Current.Session["currentbranch"] = currentbranch;
        HttpContext.Current.Session["currentbranch_code"] = currentbranch_code;
        HttpContext.Current.Session["currentcomp_name"] = comp_companyname;
        HttpContext.Current.Session["currentcomp_db"] = comp_ConnectionStr;
        HttpContext.Current.Session["COMPANY_ID"] = COMPANY_ID;
        HttpContext.Current.Session["JOB_TYPE"] = JOB_TYPE;
        HttpContext.Current.Session["SELECT_TYPE"] = SELECT_TYPE;


        ds = (DataSet)HttpContext.Current.Session["COMPANY_DETAILS_DS"];

        DataView view1 = ds.Tables[1].DefaultView;
        //view1.RowFilter = "BRANCH = '" + currentbranch + "' and " + "COMPANY_ID = " + COMPANY_ID + " and " + " USER_ID = '" + currentLoginId + "'";
        view1.RowFilter = "BRANCH = '" + currentbranch + "' and " + "COMPANY_ID = " + COMPANY_ID + "";
        DataTable table1 = view1.ToTable();
        DataSet dt_UserRights = new DataSet();
        dt_UserRights.Tables.Add(table1);
        if (dt_UserRights.Tables[0].Rows.Count > 0)
        {
            HttpContext.Current.Session.Remove("CHA_NO");
            HttpContext.Current.Session.Remove("CHA_NAME");
            HttpContext.Current.Session.Remove("CHA_ADDRESS");
            HttpContext.Current.Session.Remove("CHA_ADDRESS1");
            HttpContext.Current.Session.Remove("CHA_ADDRESS2");
            HttpContext.Current.Session.Remove("CHA_ADDRESS3");
            HttpContext.Current.Session.Remove("ICEGATE_ID");
            HttpContext.Current.Session.Remove("ICEGATE_PWD");
            HttpContext.Current.Session.Remove("ICEGATE_EMAIL_ID");
            HttpContext.Current.Session.Remove("ICEGATE_EMAIL_PWD");

            HttpContext.Current.Session["CHA_NO"] = dt_UserRights.Tables[0].Rows[0]["CHA_NO"].ToString();
            HttpContext.Current.Session["CHA_NAME"] = dt_UserRights.Tables[0].Rows[0]["CHA_NAME"].ToString();
            HttpContext.Current.Session["CHA_ADDRESS"] = dt_UserRights.Tables[0].Rows[0]["CHA_ADDRESS"].ToString();
            HttpContext.Current.Session["CHA_ADDRESS1"] = dt_UserRights.Tables[0].Rows[0]["CHA_ADDRESS1"].ToString();
            HttpContext.Current.Session["CHA_ADDRESS2"] = dt_UserRights.Tables[0].Rows[0]["CHA_ADDRESS2"].ToString();
            HttpContext.Current.Session["CHA_ADDRESS3"] = dt_UserRights.Tables[0].Rows[0]["CHA_ADDRESS3"].ToString();
            HttpContext.Current.Session["ICEGATE_ID"] = dt_UserRights.Tables[0].Rows[0]["ICEGATE_ID"].ToString();
            HttpContext.Current.Session["ICEGATE_PWD"] = dt_UserRights.Tables[0].Rows[0]["ICEGATE_PWD"].ToString();

            HttpContext.Current.Session["ICEGATE_EMAIL_ID"] = dt_UserRights.Tables[0].Rows[0]["ICEGATE_EMAIL_ID"].ToString();
            HttpContext.Current.Session["ICEGATE_EMAIL_PWD"] = dt_UserRights.Tables[0].Rows[0]["ICEGATE_EMAIL_PWD"].ToString();

            
        }
        else
        {
            HttpContext.Current.Session["CHA_NO"] = "";
            HttpContext.Current.Session["CHA_NAME"] = "";
            HttpContext.Current.Session["CHA_ADDRESS"] = "";
            HttpContext.Current.Session["CHA_ADDRESS1"] = "";
            HttpContext.Current.Session["CHA_ADDRESS2"] = "";
            HttpContext.Current.Session["CHA_ADDRESS3"] = "";
            HttpContext.Current.Session["ICEGATE_ID"] = "";
            HttpContext.Current.Session["ICEGATE_PWD"] = "";

           
   
        }
        //---------------------------------------------GET CUSTOM CODE FROM CUSTOM_HOUSE MASTER-----------------------//
         DataView view2 = ds.Tables[3].DefaultView;
         view2.RowFilter = "CUSTOMHOUSE_NAME = '" + currentbranch + "'";
                            //DataTable table1 = view1.ToTable();
                            DataSet dt_1 = new DataSet();
                            dt_1.Tables.Add(view2.ToTable());
                            if (dt_1.Tables[0].Rows.Count > 0)
                            {
                                HttpContext.Current.Session.Remove("CUSTOMHOUSE_CODE");
                                HttpContext.Current.Session.Remove("CUSTOMHOUSE_TRANSPORT_MODE");

                                HttpContext.Current.Session["CUSTOMHOUSE_CODE"] = dt_1.Tables[0].Rows[0]["CUSTOMHOUSE_CODE"].ToString();
                                HttpContext.Current.Session["CUSTOMHOUSE_TRANSPORT_MODE"] = dt_1.Tables[0].Rows[0]["CUSTOMHOUSE_CATEGORY"].ToString();
                            }
        //---------------------------------------------GET CUSTOM CODE FROM CUSTOM_HOUSE MASTER-----------------------//

    }
    public bool isValidUsers(string userId, string userPassword, string branch_code)
    {


        bool yn = false;


        try
        {

            if (HttpContext.Current.Session["currentuser"] != "" && HttpContext.Current.Session["currentpassword"] != "" && HttpContext.Current.Session["currentbranch"] != "")
                yn = true;

        }
        catch (Exception ex)
        {
            yn = false;

            er.makeLog(ex.Message);
        }
        return true;

    }

    public void finishSession()
    {
        try
        {
            HttpContext.Current.Session.RemoveAll();
           
        }
        catch (Exception ex) { }
       
    }
    
    public void checkSession()
    {
        bool isValidSession = false;
        try
        {
            
           isValidSession = isValidUsers(HttpContext.Current.Session["currentuser"].ToString(), HttpContext.Current.Session["currentpassword"].ToString(), HttpContext.Current.Session["currentbranch"].ToString());
           string RAND_ID=HttpContext.Current.Session["USER_ISLOGIN_RANDOM_ID"].ToString();
           Login login = new Login();
           login.usrid = HttpContext.Current.Session["currentuser"].ToString();
           login.passwd = HttpContext.Current.Session["currentpassword"].ToString();
           login.COMPANY_ID = HttpContext.Current.Session["COMPANY_ID"].ToString();
           login.flag = "CheckOut_Random_Id";
           login.startdt = "01/01/1900";
           login.expdt = "01/01/1900";
           login.Check_User_Login_Details();

           if (RAND_ID != login.USER_RANDOM_ID)
           {
               finishSession();

               HttpContext.Current.Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["sessionExpiredPath"].ToString());
           }
            //string userName = Page.User.Identity.Name;
            //Auto_Complete_Searching auto = new Auto_Complete_Searching();
            //string mail="";
            //auto.CheckOut_IsAlready_Login(mail);
            //int Islogin=Convert.ToInt32(HttpContext.Current.Session["ISAlready_Login"]);
            
            //if (Islogin == 0)
            // if(HttpContext.Current.Session!=null)
            //{
            //    finishSession();

            //    HttpContext.Current.Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["sessionExpiredPath"].ToString());
            //}
        }
        catch (Exception ex) { }
        
            if (!isValidSession)
            {
                finishSession();
                HttpContext.Current.Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["sessionExpiredPath"].ToString());
            }
        
    }
    public void checkSession_Subfolder()
    {
        bool isValidSession = false;
        try
        {
            isValidSession = isValidUsers(HttpContext.Current.Session["currentuser"].ToString(), HttpContext.Current.Session["currentpassword"].ToString(), HttpContext.Current.Session["currentbranch"].ToString());
        }
        catch (Exception ex) { }
        if (!isValidSession)
        {
            finishSession();

            HttpContext.Current.Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["sessionExpiredPath_Subfolder"].ToString());

        }
    }
    public DataView GridView_Sorting(DataSet dtuser,string sort_ColumnName)
    {
        DataView dataView = new DataView(dtuser.Tables[0]);
        if (HttpContext.Current.Session["sort"] == null)
        {
            dataView.Sort = sort_ColumnName + " ASC";
            HttpContext.Current.Session["sort"] = null;
        }

        else
        {
            dataView.Sort = sort_ColumnName + " DESC";

        }
        return dataView;

    }

   
}