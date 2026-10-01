using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;
using System.Text;


/// <summary>
/// Summary description for CommonAPI
/// </summary>
public static class CommonAPI
{
    public static string CommonAPI_basedonCompanies(String COMPANY_ID, string JobNo, string IE)
    {
        string workPeriod = Connection.WorkingPeriod();
        string branch = Connection.Current_Branch();

        if (JobNo != "" || JobNo != null)
        {
            if (COMPANY_ID == "861" || COMPANY_ID == "3149" || COMPANY_ID == "3266")          // HHL GLOBAL PRIVATE LIMITED
            {
                API_Post_Data ebms = new API_Post_Data();
                return  ebms.CheckList_API_Post(JobNo, workPeriod, IE, "JSON", branch);
            }

            if (COMPANY_ID == "115" || COMPANY_ID == "1033" || COMPANY_ID == "2814" || COMPANY_ID == "3082" || COMPANY_ID == "3253" || COMPANY_ID == "3288" || COMPANY_ID == "3267")// Ebms & CopperHawk & KPS 
            {
                API_Post_Data ebms = new API_Post_Data();
                return  ebms.CheckList_API_Post(JobNo, workPeriod, IE, "JSON", branch);
            }
            else if (COMPANY_ID == "570" || COMPANY_ID == "2261") // API Call for client AmazerTrans  / Divya Impex
            {
                API_Post_Data_CargoAmazer Api_Ringo = new API_Post_Data_CargoAmazer();
                Api_Ringo.CargoWayz_API_Post(JobNo, workPeriod, IE, branch);
            }

            else if (COMPANY_ID == "1572" && IE == "E") // Ringo Cargo for export
            {
                API_Post_Data_CargoAmazer Api_Ringo = new API_Post_Data_CargoAmazer();
                Api_Ringo.CargoWayz_API_Post(JobNo, workPeriod, IE, branch);
            }

            //Added by pandiyan for sudarshan cargo Import Api data posting 03-07-2025
            else if (COMPANY_ID == "6001")                                           
            {
                if (IE == "I")
                {
                    CheckList chklist = new CheckList();
                    chklist.JOBNo = JobNo;
                    chklist.Ename = "select_be_no";
                    chklist.Workingperiod = Connection.Get_Company_Type();
                    DataSet ds = new DataSet();
                    ds = chklist.RetrieveAll_Be_Details();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        chklist.JOBNo = JobNo;
                        chklist.Workingperiod = Connection.Get_Company_Type();
                        chklist.Ename = "select_Json_Details";
                        DataSet ds_job = new DataSet();
                        ds_job = chklist.RetrieveAll_Sudarsha_Cargo_Api_Json_Job_Details();
                        if (ds_job.Tables[0].Rows.Count > 0)
                        {
                            API_Post_Data ebms = new API_Post_Data();
                            return ebms.Sudarshan_Imp_API_Post(ds_job, JobNo);
                        }
                    }
                }
               
            }
        }
        return "Company/API Configuration Not Found";
    }
}




