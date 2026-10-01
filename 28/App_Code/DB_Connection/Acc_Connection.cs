using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;


public class Acc_Connection
{
    public static string COMPANYID()
    {
        return HttpContext.Current.Session["COMPANY_ID"].ToString();
    }
    public static string Current_User_Upper()
    {
        return HttpContext.Current.Session["currentuser"].ToString().ToUpper();
    }

    public static string Billing_Aproval_Company()
    {
        string Company_Id = COMPANYID(), Aprove = string.Empty, User_ID = Current_User_Upper();
        if (Company_Id == "1" || Company_Id == "10" || Company_Id == "293" || Company_Id == "408" || Company_Id == "480" || Company_Id == "599" 
            || Company_Id == "2349" || Company_Id == "2563" || Company_Id == "3196" || Company_Id == "744" || Company_Id == "3004"
            || Company_Id == "1176" || Company_Id == "1277" || Company_Id == "1011" || Company_Id == "1019" || Company_Id == "1698" || Company_Id == "1280" || Company_Id == "3267")
        {
            Aprove = "Y";
        }
        return Aprove;
    }

    public static string Billing_Aproval_Admin()
    {
        string Company_Id = COMPANYID(), Aprove = string.Empty, User_ID = Current_User_Upper();

        if (Company_Id == "10" )
        {
            Aprove = "Y";
        }
        else if (Company_Id == "293")
        {
            if (User_ID == "RTS" || User_ID == "ACCOUNTS" || User_ID == "SUDHAMATHI" || User_ID == "JAYALAKSHMI")
            {
                Aprove = "Y";
            }
        }
        else if (Company_Id == "599")
        {
            if (User_ID == "RTS" || User_ID == "ACCOUNTS")
            {
                Aprove = "Y";
            }
        }
        else if (Company_Id == "2349")
        {
            if (User_ID == "RTS" || User_ID == "ADMINAC" || User_ID == "BILLING1" || User_ID == "BILLING2" || User_ID == "ACCOUNTS")
            {
                Aprove = "Y";
            }
        }
        else if (Company_Id == "2563")
        {
            if (User_ID == "RTS" || User_ID == "ADMINAC" || User_ID == "BILLING1" || User_ID == "BILLING2")
            {
                Aprove = "Y";
            }
        }
        else if (Company_Id == "3196")
        {
            if (User_ID == "RTS" || User_ID == "PATADE" || User_ID == "CHAVAN")
            {
                Aprove = "Y";
            }
        }
        else if (Company_Id == "744")
        {
            if (User_ID == "RTS" || User_ID == "SGLACC" )
            {
                Aprove = "Y";
            }
        }
        else if (Company_Id == "3004")
        {
            if (User_ID == "RTS" || User_ID == "ADMIN" || User_ID == "BILLING")
            {
                Aprove = "Y";
            }
        }
        else if (Company_Id == "480" || Company_Id == "1176" || Company_Id == "1277" || Company_Id == "1011" || Company_Id == "1019" || Company_Id == "1698" || Company_Id == "1280")
        {
                Aprove = "Y";
        }
        else if (Company_Id == "3267")
        {
            if (User_ID == "RTS" || User_ID == "ADMIN" || User_ID == "KPS021" || User_ID == "KPS022" || User_ID == "KPS023")
            {
                Aprove = "Y";
            }
        }
        return Aprove;
    }
}