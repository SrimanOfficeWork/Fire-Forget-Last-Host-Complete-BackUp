using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;


public class AppSession_old : ErrorLogs
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

  
    public void makeSession(string userId, string userPassword,string branch)
    {
        if (isact(userId, userPassword, branch))
        {
            if (isactive == "True")
            {
                //if (isactive = false)
                //{
                if (isValidUsers(userId, userPassword, branch))
                {
                    HttpContext.Current.Session["currentuser"] = currentLoginId;
                    HttpContext.Current.Session["currentpassword"] = currentLoginPassword;
                    HttpContext.Current.Session["currentbranch"] = currentbranch;
                    HttpContext.Current.Session["currentcomp_name"] = comp_companyname;
                    HttpContext.Current.Session["currentcomp_db"] = comp_ConnectionStr;

                }
                else
                {
                    HttpContext.Current.Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["loginInvalidPath"].ToString());
                }
                //}
            }

            else
            {
                HttpContext.Current.Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["isdeactivate"].ToString());

            }

        }
        else
        {
            HttpContext.Current.Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["CheckLoginValue"].ToString());

        }
       
       
    }

    public void Import_Session(string TRANSPORT_MODE, string IMPORT_JOBNO, string IMPORT_JOBDATE, string FILING_STATUS)
    {
        HttpContext.Current.Session["TRANSPORT_MODE"] = TRANSPORT_MODE;
        HttpContext.Current.Session["IMPORT_JOBNO"] = IMPORT_JOBNO;
        HttpContext.Current.Session["IMPORT_JOBDATE"] = IMPORT_JOBDATE;
        HttpContext.Current.Session["FILING_STATUS"] = FILING_STATUS;
       
    }

    public bool isact(string userId, string userPassword, string branch_code)
    {


        bool yn = false;

        con.Open();
        cmd = new SqlCommand("SELECT ISACTIVE FROM LOGIN_MASTER WHERE LOWER(USERNAME)='" + userId.ToLower() + "' AND PWD='" + userPassword + "' and BRANCH='" + branch_code + "'", con);
        dr = cmd.ExecuteReader();
        dr.Read();
        if (dr.HasRows)
        {

            isactive = dr["ISACTIVE"].ToString();

            yn = true;


        }
        dr.Close();
        con.Close();

        return yn;
    }
    public bool isValidUsers(string userId, string userPassword, string branch_code)
    {


        bool yn = false;
       
        con.Close();
        
        try
        {

            

            con.Open();
            cmd = new SqlCommand("SELECT USERNAME,PWD,BRANCH,CONNECTION_SERVER,COMPANYNAME FROM LOGIN_MASTER WHERE LOWER(USERNAME)='" + userId.ToLower() + "' AND PWD='" + userPassword + "' and BRANCH='" + branch_code + "' and  ISACTIVE='1'", con);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {

                currentLoginId = dr["USERNAME"].ToString();
                currentLoginPassword = dr["PWD"].ToString();
                currentbranch = dr["BRANCH"].ToString();
                comp_ConnectionStr = dr["CONNECTION_SERVER"].ToString();
                comp_companyname = dr["COMPANYNAME"].ToString();
                yn = true;
              
                
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            yn = false;
           
            er.makeLog(ex.Message);
        }
        return true;
       
    }

    public bool isValidUser(string userId, string userPassword, string branch_code)
    {


        bool yn = false;
        string additionalCondition;
        additionalCondition = "";
        //additionalCondition = " AND (PERMISSIONS LIKE '%_" + permissionId() + "_%' OR PERMISSIONS='0')";---//(PERMISSIONS LIKE '%3,%' OR PERMISSIONS LIKE '%,3,' OR PERMISSIONS LIKE '%,3' )
        additionalCondition = " AND (PERMISSIONS LIKE '%" + permissionId() + ",%' OR PERMISSIONS like '%," + permissionId() + ",%' OR PERMISSIONS LIKE '%,"+permissionId()+"%')";
        con.Close();
        con.Open();
        cmd = new SqlCommand("SELECT USERNAME,PWD,BRANCH FROM LOGIN_MASTER WHERE LOWER(USERNAME)='" + userId.ToLower() + "' AND PWD='" + userPassword + "' and BRANCH='" + branch_code + "'" + additionalCondition, con);
        try
        {
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                if (dr.Read())
                {
                    currentLoginId = dr["USERNAME"].ToString();
                    currentLoginPassword = dr["PWD"].ToString();
                    currentbranch = dr["BRANCH"].ToString();
                    yn = true;
                }
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            yn = false;
            er.makeLog(ex.Message);
            con.Close();
        }
        return yn;
        

    }
    public int permissionId()
    {
        //int pid = -1;
        try
        {

            //int pid = 1;
            con.Close();
            con.Open();
            cmd = new SqlCommand("SELECT PERMISSION_ID FROM PERMISSION_MASTER WHERE LOWER(PERMISSION_LINK)='" + System.IO.Path.GetFileName(HttpContext.Current.Request.FilePath).ToLower() + "'", con);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                pid = Convert.ToInt32(dr["PERMISSION_ID"].ToString());
            }



            //pid = (int)cmd.ExecuteScalar();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return pid;
        con.Close();

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

}