using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;
using System.Text;
using System.IO;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

public class E_ROYAL : System.Web.Services.WebService {

    public E_ROYAL () { }
    public  string CR_jobno_name = "";

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }
    [WebMethod]
    public void BUYER_MASTER(string BUYER_NAME, string BUYER_ADD1, string BUYER_ADD2, string BUYER_ADD3, string BUYER_COUNTRY_NAME, string BUYER_COUNTRY_CODE, string COMPANY_LICENSE, string WORKING_PERIOD, string Flag, string User_ID)
    {
        var ERM = new Elogix_Masters();
        DataSet ds = new DataSet();
        ds =ERM.Company_Details(COMPANY_LICENSE, WORKING_PERIOD);

        if (ds.Tables[0].Rows.Count > 0)
        {
            ERM.BUYER_MASTER(BUYER_NAME, BUYER_ADD1, BUYER_ADD2, BUYER_ADD3, BUYER_COUNTRY_NAME, BUYER_COUNTRY_CODE, WORKING_PERIOD, Flag, User_ID, ds.Tables[0].Rows[0][0].ToString());
        }
    }
    [WebMethod]
    public void CONSIGNEE_MASTER(string CONSIGNEE_NAME, string CONSIGNEE_ADD1, string CONSIGNEE_ADD2, string CONSIGNEE_ADD3, string CONSIGNEE_COUNTRY_NAME, string CONSIGNEE_COUNTRY_CODE, string COMPANY_LICENSE, string WORKING_PERIOD, string Flag, string User_ID)
    {
        var ERM = new Elogix_Masters();
        DataSet ds = new DataSet();
        ds = ERM.Company_Details(COMPANY_LICENSE, WORKING_PERIOD);

        if (ds.Tables[0].Rows.Count > 0)
        {
            ERM.CONSIGNEE_MASTER(CONSIGNEE_NAME, CONSIGNEE_ADD1, CONSIGNEE_ADD2, CONSIGNEE_ADD3, CONSIGNEE_COUNTRY_NAME, CONSIGNEE_COUNTRY_CODE, WORKING_PERIOD, Flag, User_ID, ds.Tables[0].Rows[0][0].ToString());
        }
    }
    [WebMethod]
    public void SUP_MASTER(string SUP_NAME, string SUP_ADD1, string SUP_ADD2, string SUP_ADD3, string SUP_COUNTRY_NAME, string SUP_COUNTRY_CODE, string COMPANY_LICENSE, string WORKING_PERIOD, string Flag, string User_ID)
    {
        var ERM = new Elogix_Masters();
        DataSet ds = new DataSet();
        ds = ERM.Company_Details(COMPANY_LICENSE, WORKING_PERIOD);

        if (ds.Tables[0].Rows.Count > 0)
        {
            ERM.SUP_MASTER(SUP_NAME, SUP_ADD1, SUP_ADD2, SUP_ADD3, SUP_COUNTRY_NAME, SUP_COUNTRY_CODE,  WORKING_PERIOD, Flag, User_ID, ds.Tables[0].Rows[0][0].ToString());
        }
    }
    [WebMethod]
    public void SHIPPER_MASTER(string IMP_EXP_NAME, string IMP_EXP_IECNO, string IMP_EXP_BRSLNO, string IMP_EXP_TYPE
        , string IMP_EXP_ADD1, string IMP_EXP_ADD2, string IMP_EXP_ADD3, string IMP_EXP_ADD4, string IMP_EXP_PIN_CODE
        , string STATE_CODE, string TYPE_OF_EXPORTER, string M_COMMERCIAL_DETAILS_STATUS, string M_COMMERCIAL_TAX_STATENAME, string M_COMMERCIAL_TAX_STATECODE, string M_COMMERCIAL_TAX_TYPE, string M_COMMERCIAL_TAX_REGISTRATION_NO, string GSTN_TYPE, string GSTN_ID, string COMPANY_LICENSE, string WORKING_PERIOD, string Flag, string User_ID)
    {
        var ERM = new Elogix_Masters();
        DataSet ds = new DataSet();
        ds = ERM.Company_Details(COMPANY_LICENSE, WORKING_PERIOD);

        if (ds.Tables[0].Rows.Count > 0)
        {
            ERM.SHIPPER_MASTER(IMP_EXP_NAME, IMP_EXP_IECNO, IMP_EXP_BRSLNO, IMP_EXP_TYPE
                  , IMP_EXP_ADD1, IMP_EXP_ADD2, IMP_EXP_ADD3, IMP_EXP_ADD4, IMP_EXP_PIN_CODE
                , STATE_CODE,  TYPE_OF_EXPORTER,  M_COMMERCIAL_DETAILS_STATUS,  M_COMMERCIAL_TAX_STATENAME,  M_COMMERCIAL_TAX_STATECODE,  M_COMMERCIAL_TAX_TYPE,  M_COMMERCIAL_TAX_REGISTRATION_NO,  GSTN_TYPE,  GSTN_ID, COMPANY_LICENSE, WORKING_PERIOD, Flag, User_ID, ds.Tables[0].Rows[0][0].ToString());
        }
    }
    [WebMethod]
    public void ADCODE_MASTER(string ADCODE_IEC_CODE, string ADCODE_IEC_NAME, string ADCODE_IEC_ADCODE, string COMPANY_LICENSE, string WORKING_PERIOD, string Flag, string User_ID)
    {
        var ERM = new Elogix_Masters();
        DataSet ds = new DataSet();
        ds = ERM.Company_Details(COMPANY_LICENSE, WORKING_PERIOD);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ERM.ADCODE_MASTER(ADCODE_IEC_CODE, ADCODE_IEC_NAME, ADCODE_IEC_ADCODE, COMPANY_LICENSE, WORKING_PERIOD, Flag, User_ID, ds.Tables[0].Rows[0][0].ToString());
        }

    }
    [WebMethod]
    public void IMP_EXP_FILE_REF_NO(string Jobno, string File_Ref_No, string Branch_Code, string IMP_EXP_Type, string COMPANY_LICENSE, string WORKING_PERIOD, string User_ID)
    {
        var ERM = new Elogix_Masters();
        DataSet ds = new DataSet();
        ds = ERM.Company_Details(COMPANY_LICENSE, WORKING_PERIOD);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ERM.IMP_EXP_File_Ref_Update(Jobno, File_Ref_No, Branch_Code, IMP_EXP_Type, WORKING_PERIOD, User_ID, ds.Tables[0].Rows[0][0].ToString(), ds.Tables[0].Rows[0][1].ToString());
        }
    }

    [WebMethod]
    public void EXP_DML_CMD( string File_Ref_No ,string Tr_mode,string Jobdate,string IEC_NO,string Bracnh_No,string Consignee_Name,string customs_House,string Port_Destination ,string Port_Of_Discharge
                            ,string Gross_Wgt,string Net_Wgt,string Pkg,string Uint_Code
                            ,string Inv_No,string Inv_Date,string Inv_Cur,string Terms,string Inv_Value
                            ,string Branch_Code,string User_Id,string WORKINGPERIOD,string Flag,string Company_Lic
                           )
    {
        var ERM = new Elogix_Masters();
        DataSet ds = new DataSet();
        ds = ERM.Company_Details(Company_Lic, WORKINGPERIOD, Tr_mode, customs_House, Port_Destination, Port_Of_Discharge, "EXP_Company_Port_details");
        if (ds.Tables[0].Rows.Count > 0)
        {
            ERM.EXP_DML_CMD(
                 File_Ref_No
                , Tr_mode
                , Jobdate
                , IEC_NO
                , Bracnh_No
                , Consignee_Name
                , customs_House
                , ds.Tables[0].Rows[0]["Port_Destination"].ToString()
                , ds.Tables[0].Rows[0]["Port_Of_Discharge"].ToString()
                , Gross_Wgt
                , Net_Wgt
                , Pkg
                , Uint_Code
                , Inv_No
                , Inv_Date
                , Inv_Cur
                , Terms
                , Inv_Value

                , ds.Tables[0].Rows[0]["Branch_Code"].ToString()
                , User_Id
                , Flag
                , ds.Tables[0].Rows[0][0].ToString() //login
                , ds.Tables[0].Rows[0][1].ToString()//Branch_Common
                , WORKINGPERIOD);
        }
    }

    [WebMethod]
    public void IMP_DML_CMD( string File_Ref_No    
    ,string JOBDATE ,string TRANSPORT_MODE ,string BRANCH_NO,string IEC_NO ,string CUSTOMS_HOUSE 
    ,string IGM_NO ,string IGM_DATE ,string IGM_MAWB_MBL ,string IGM_MAWB_MBLDATE ,string IGM_HAWB_HBLNO ,string IGM_HAWB_HBLDATE  
    ,string IGM_NOOFPACKAGE,string IGM_PACKAGETYPE ,string IGM_GROSSWEIGHT,string IGM_TYPEOFWEIGHT ,string IGM_FLIGHT_VESSELDATE 
    ,string INVOICE_NO ,string INVOICE_DATE ,string INVOICE_CURRENCY ,string INVOICE_VALUE
    , string Branch_Code, string User_Id, string WORKINGPERIOD, string Flag, string Company_Lic)
    {
        var ERM = new Elogix_Masters();
        DataSet ds = new DataSet();
        //ds = ERM.Company_Details(Company_Lic, WORKINGPERIOD);
        ds = ERM.Company_Details(Company_Lic, WORKINGPERIOD, TRANSPORT_MODE, CUSTOMS_HOUSE, "", "", "IMP_Company_Port_details");
        if (ds.Tables[0].Rows.Count > 0)
        {
           ERM.IMP_DML_CMD(File_Ref_No
         , JOBDATE , TRANSPORT_MODE , BRANCH_NO,IEC_NO , CUSTOMS_HOUSE 
         , IGM_NO , IGM_DATE , IGM_MAWB_MBL , IGM_MAWB_MBLDATE , IGM_HAWB_HBLNO , IGM_HAWB_HBLDATE  
         , IGM_NOOFPACKAGE, IGM_PACKAGETYPE , IGM_GROSSWEIGHT, IGM_TYPEOFWEIGHT , IGM_FLIGHT_VESSELDATE 
         , INVOICE_NO , INVOICE_DATE , INVOICE_CURRENCY , INVOICE_VALUE

                , ds.Tables[0].Rows[0]["Branch_Code"].ToString()
                , User_Id
                , Flag
                , ds.Tables[0].Rows[0][0].ToString() //login
                , ds.Tables[0].Rows[0][1].ToString()//Branch_Common
                , WORKINGPERIOD); 
        }
    }

    [WebMethod]
    public string DSC(string Company_Lic,string User_ID,string Password, string Working_Period )
    {
        string Branch = "0";
        var ERM = new Elogix_Masters();
        DataSet ds = new DataSet();
        DataSet dss = new DataSet();
        ds = ERM.Company_Details(Company_Lic, Working_Period);

        if (ds.Tables[0].Rows.Count > 0)
        {
            dss = ERM.DSC("DSC", User_ID, Password, ds.Tables[0].Rows[0][0].ToString(), ds.Tables[0].Rows[0][1].ToString(), "", "", "");

           if (dss.Tables[0].Rows.Count > 0)
           {
               Branch = dss.Tables[0].Rows[0][0].ToString();
           }
        }
        return Branch;
    }
    [WebMethod]
    public string DSC_FTP(string Company_Lic)
    {
        string FTP_Info = "";
        var ERM = new Elogix_Masters();
        DataSet ds = new DataSet();
        ds = ERM.Company_Details(Company_Lic, "", "", "", "", "", "FTP_details");

        if (ds.Tables[0].Rows.Count > 0)
        {
            FTP_Info = ds.Tables[0].Rows[0][0].ToString();
        }
        return FTP_Info;
    }
    [WebMethod]
    public DataTable DSC_GET_JOB_LIST(string Company_Lic , string User_ID, string Working_Period
        , string From_Date, string To_Date, string Type, string Location )
    {
        string[] arr = new string[] { };
        string[] arr2 = new string[] { };

        if (From_Date != string.Empty && From_Date != null)
        {
            arr = From_Date.Split('/');
            From_Date = arr[1] + '/' + arr[0] + '/' + arr[2];
        }
        if (To_Date != string.Empty && To_Date != null)
        {
            arr2 = To_Date.Split('/');
            To_Date = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
        }

        DataTable dt = new DataTable();
        var ERM = new Elogix_Masters();

        DataSet ds = new DataSet();

        DataSet dss = new DataSet();
        ds = ERM.Company_Details(Company_Lic, Working_Period);

        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0][1].ToString() == "B" || ds.Tables[0].Rows[0][1].ToString() == "A")
            {
                dss = ERM.DSC("DSC_GET_JOB_LIST", User_ID, "", ds.Tables[0].Rows[0][0].ToString(), Location, From_Date, To_Date, Type);
            }
            else
            {
                dss = ERM.DSC("DSC_GET_JOB_LIST", User_ID, "", ds.Tables[0].Rows[0][0].ToString(), "", From_Date, To_Date, Type);
            }
            if (dss.Tables[0].Rows.Count > 0)
            {
                dt = dss.Tables[0];
            }
        }
        return dt;
    }

    [WebMethod]
    public DataTable DSC_GET_JOB_LIST_WITHURL(string Company_Lic, string User_ID, string Working_Period
  , string From_Date, string To_Date, string Type, string Location)
    {
        string[] arr = new string[] { };
        string[] arr2 = new string[] { };

        if (From_Date != string.Empty && From_Date != null)
        {
            arr = From_Date.Split('/');
            From_Date = arr[1] + '/' + arr[0] + '/' + arr[2];
        }
        if (To_Date != string.Empty && To_Date != null)
        {
            arr2 = To_Date.Split('/');
            To_Date = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
        }

        DataTable dt = new DataTable();
        var ERM = new Elogix_Masters();

        DataSet ds = new DataSet();

        DataSet dss = new DataSet();
        ds = ERM.Company_Details(Company_Lic, Working_Period);

        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0][1].ToString() == "B" || ds.Tables[0].Rows[0][1].ToString() == "A")
            {
                //dss = ERM.DSC("DSC_GET_JOB_LIST", User_ID, "", ds.Tables[0].Rows[0][0].ToString(), Location, From_Date, To_Date, Type);
                dss = ERM.DSC("DSC_GET_JOB_LIST", User_ID, Company_Lic.ToUpper(), ds.Tables[0].Rows[0][0].ToString(), Location, From_Date, To_Date, Type);
            }
            else
            {
                //dss = ERM.DSC("DSC_GET_JOB_LIST", User_ID, "", ds.Tables[0].Rows[0][0].ToString(), "", From_Date, To_Date, Type);
                dss = ERM.DSC("DSC_GET_JOB_LIST", User_ID, Company_Lic.ToUpper(), ds.Tables[0].Rows[0][0].ToString(), "", From_Date, To_Date, Type);
            }
            if (dss.Tables[0].Rows.Count > 0)
            {
                dt = dss.Tables[0];
            }
        }
        return dt;
    }
    [WebMethod]
    public void DSC_GET_SIGNED_FLATFILE_DATA_RETURN(string Comp_EID, string User_ID, string branch, string jobno, string JobType, string Working_Period, string EncodeString)
    {
        DataSet dss = new DataSet();
        DataSet dsc = new DataSet();
        DataSet ds = new DataSet();
        Job_Histroy jh = new Job_Histroy();
        var ERM = new Elogix_Masters();
        ds = ERM.Company_Details(Comp_EID, Working_Period);
        string com_brn = "";
        string Company_Lic = "";
        string grpname = "", foldername = "";

        if (JobType.ToUpper() == "E")
        {
            JobType = "EXP";
            foldername = "EXP_Job_history";
        }
        else if (JobType.ToUpper() == "I")
        {
            JobType = "IMP";
            foldername = "IMP_Job_history";
        }
        else if (JobType.ToUpper() == "IQ" || JobType.ToUpper() == "IA")
        {
            foldername = "IMP_Job_history";
        }
        else if (JobType.ToUpper() == "EQ" || JobType.ToUpper() == "EA")
        {
            foldername = "EXP_Job_history";
        }
        else if (JobType.ToUpper() == "GR")
        {
            foldername = "GoodsRegistration";
        }

        if (ds.Tables[0].Rows.Count > 0)
        {
            com_brn = ds.Tables[0].Rows[0][1].ToString();
            jh.YEAR = ds.Tables[0].Rows[0][0].ToString();
            Company_Lic = ds.Tables[0].Rows[0][2].ToString();

            if (com_brn == "A")
            {
                grpname = branch;
                jh.COMPANY_ID = jobno;
                jh.DESCRIPTION = branch;
                jh.JOB_TYPE = JobType;
                jh.FLAG = "GetBranchCode";
                branch = "";
                dsc = jh.RetrieveBranch_DSC(ds.Tables[0].Rows[0][0].ToString());
                if (dsc.Tables.Count > 0)
                {
                    branch = dsc.Tables[0].Rows[0]["BRANCHCODE"].ToString();
                }
            }

            string errorFolder = "";
            if (com_brn == "B")
            {
                errorFolder = Server.MapPath("~/Submission/" + Company_Lic + "/" + branch + "/" + foldername + "/");
            }
            else if (com_brn == "A")
            {
                errorFolder = Server.MapPath("~/Submission/" + Company_Lic + "/" + grpname + "/" + foldername + "/");
            }
            else
            {
                errorFolder = Server.MapPath("~/Submission/" + Company_Lic + "/" + foldername + "/");
            }

            var base64EncodedBytes = System.Convert.FromBase64String(EncodeString);
            string jobdata = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);

            // ============================================================
            // Detect format: JSON or plain text
            // ============================================================
            bool isJson = false;
            object parsedJson = null;

            string trimmedData = jobdata.TrimStart();
            if (trimmedData.StartsWith("{") || trimmedData.StartsWith("["))
            {
                try
                {
                    parsedJson = Newtonsoft.Json.JsonConvert.DeserializeObject(trimmedData);
                    isJson = true;
                }
                catch
                {
                    isJson = false;
                }
            }

            if (Directory.Exists(errorFolder) == false)
            {
                Directory.CreateDirectory(errorFolder);
            }

            // ============================================================
            // TEXT FILE NAME (existing extensions - unchanged)
            // ============================================================
            string jobno_name = "";
            if (JobType == "EXP")
            {
                jobno_name = jobno + " ~~" + jobno + DateTime.Now.Year.ToString() + "Signed.sb";
            }
            else if (JobType == "IMP")
            {
                jobno_name = jobno + " ~~" + jobno + DateTime.Now.Year.ToString() + "Signed.be";
            }
            else if (JobType == "IQ")
            {
                jobno_name = jobno + " ~~" + jobno + DateTime.Now.Year.ToString() + "Signed.rpl";
            }
            else if (JobType == "EQ")
            {
                jobno_name = jobno + " ~~" + jobno + DateTime.Now.Year.ToString() + "Signed.rpl";
            }
            else if (JobType == "IA")
            {
                jobno_name = jobno + " ~~" + jobno + DateTime.Now.Year.ToString() + "Signed.beamd";
            }
            else if (JobType == "EA")
            {
                jobno_name = jobno + " ~~" + jobno + DateTime.Now.Year.ToString() + "Signed.sbamd";
            }
            else if (JobType == "GR")
            {
                jobno_name = jobno + " ~~" + jobno + DateTime.Now.Year.ToString() + "Signed.gr";
            }

            string json_name = jobno + " ~~" + jobno + DateTime.Now.Year.ToString() + "Signed.json";

            string attachmentFileName = "";
            string webPathUrl = "";

            // ============================================================
            // EITHER .json OR .be/.sb — NOT BOTH
            // ============================================================
            if (isJson)
            {
                // JSON input → save .json file only
                string jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(parsedJson, Newtonsoft.Json.Formatting.Indented);
                System.IO.File.WriteAllText(errorFolder + json_name, jsonContent);

                attachmentFileName = json_name;
               // webPathUrl = json_name;
            }
            else
            {
                // Plain text input → save .be/.sb/.rpl etc only
                System.IO.File.WriteAllText(errorFolder + jobno_name, jobdata);

                attachmentFileName = jobno_name;
                webPathUrl = "";
            }

            // ============================================================
            // DB INSERT
            // ATTACHMENT_FILE = saved file name (either .json or .be/.sb/etc)
            // WEB_PATHURL     = json file name (only if JSON input)
            // ============================================================
            jh.JOB_ID = "";
            jh.JOBNO = jobno;
            jh.JOBDATE = "01/01/1900";
            jh.JOB_TYPE = JobType.ToUpper();
            jh.COMPANY_ID = Company_Lic;
            jh.DESCRIPTION = errorFolder;
            jh.ATTACHMENT_FILE = attachmentFileName;
            jh.WEB_PATHURL = webPathUrl;
            jh.FLAG = "DSCFile_Upload";
            jh.USER_ID = User_ID;
            jh.BRANCH_CODE = branch;
            jh.WORKING_PERIOD = Working_Period;
            jh.BRANCH_COMMON = branch;
            dss = jh.IMP_EXP_JOB_HISTROY_INSERT_UPDATE();
        }
    }
    /*

    [WebMethod]
    public void DSC_GET_SIGNED_FLATFILE_DATA_RETURN(string Comp_EID, string User_ID, string branch, string jobno, string JobType, string Working_Period, string EncodeString)
    {
        DataSet dss = new DataSet();
        DataSet dsc = new DataSet();
        DataSet ds = new DataSet();
        Job_Histroy jh = new Job_Histroy();
        var ERM = new Elogix_Masters();
        ds = ERM.Company_Details(Comp_EID, Working_Period);
        string com_brn = "";
        string Company_Lic = "";
        string grpname = "", foldername = "";

        if (JobType.ToUpper() == "E")
        {
            JobType = "EXP";
            foldername = "EXP_Job_history";
        }
        else if (JobType.ToUpper() == "I")
        {
            JobType = "IMP";
            foldername = "IMP_Job_history";
        }
        else if (JobType.ToUpper() == "IQ" || JobType.ToUpper() == "IA")
        {
            foldername = "IMP_Job_history";
        }
        else if (JobType.ToUpper() == "EQ" || JobType.ToUpper() == "EA")
        {
            foldername = "EXP_Job_history";
        }
        else if (JobType.ToUpper() == "GR")
        {
            foldername = "GoodsRegistration";
        }

        if (ds.Tables[0].Rows.Count > 0)
        {
            com_brn = ds.Tables[0].Rows[0][1].ToString();
            jh.YEAR = ds.Tables[0].Rows[0][0].ToString();
            Company_Lic = ds.Tables[0].Rows[0][2].ToString();

            if (com_brn == "A")
            {
                grpname = branch;
                jh.COMPANY_ID = jobno;
                jh.DESCRIPTION = branch;
                jh.JOB_TYPE = JobType;
                jh.FLAG = "GetBranchCode";
                branch = "";
                dsc = jh.RetrieveBranch_DSC(ds.Tables[0].Rows[0][0].ToString());
                if (dsc.Tables.Count > 0)
                {
                    branch = dsc.Tables[0].Rows[0]["BRANCHCODE"].ToString();
                }
            }

            string errorFolder = "";
            if (com_brn == "B")
            {
                errorFolder = Server.MapPath("~/Submission/" + Company_Lic + "/" + branch + "/" + foldername + "/");
            }
            else if (com_brn == "A")
            {
                errorFolder = Server.MapPath("~/Submission/" + Company_Lic + "/" + grpname + "/" + foldername + "/");
            }
            else
            {
                errorFolder = Server.MapPath("~/Submission/" + Company_Lic + "/" + foldername + "/");
            }

            // Base64 decode with padding fix
            string paddedEncode = EncodeString;
            int mod = paddedEncode.Length % 4;
            if (mod > 0)
                paddedEncode += new string('=', 4 - mod);

            var base64EncodedBytes = System.Convert.FromBase64String(paddedEncode);
            string jobdata = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);

            if (Directory.Exists(errorFolder) == false)
            {
                Directory.CreateDirectory(errorFolder);
            }

            // ============================================================
            // JSON FILE NAME ONLY
            // ============================================================
            string json_name = "";
            if (JobType == "EXP")
            {
                json_name = jobno + " ~~" + jobno + DateTime.Now.Year.ToString() + "Signed.json";
            }
            else if (JobType == "IMP")
            {
                json_name = jobno + " ~~" + jobno + DateTime.Now.Year.ToString() + "Signed.json";
            }
            else if (JobType == "IQ")
            {
                json_name = jobno + " ~~" + jobno + DateTime.Now.Year.ToString() + "Signed_IQ.json";
            }
            else if (JobType == "EQ")
            {
                json_name = jobno + " ~~" + jobno + DateTime.Now.Year.ToString() + "Signed_EQ.json";
            }
            else if (JobType == "IA")
            {
                json_name = jobno + " ~~" + jobno + DateTime.Now.Year.ToString() + "Signed_IA.json";
            }
            else if (JobType == "EA")
            {
                json_name = jobno + " ~~" + jobno + DateTime.Now.Year.ToString() + "Signed_EA.json";
            }
            else if (JobType == "GR")
            {
                json_name = jobno + " ~~" + jobno + DateTime.Now.Year.ToString() + "Signed_GR.json";
            }

            // JSON file save
            object parsedJson = Newtonsoft.Json.JsonConvert.DeserializeObject(jobdata);
            string jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(parsedJson, Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText(errorFolder + json_name, jsonContent);

            // ============================================================
            // DB INSERT - WEB_PATHURL la json file save
            // ============================================================
            jh.JOB_ID = "";
            jh.JOBNO = jobno;
            jh.JOBDATE = "01/01/1900";
            jh.JOB_TYPE = JobType.ToUpper();
            jh.COMPANY_ID = Company_Lic;
            jh.DESCRIPTION = errorFolder;
            jh.ATTACHMENT_FILE = "";          
            jh.WEB_PATHURL = json_name;   
            jh.FLAG = "DSCFile_Upload";
            jh.USER_ID = User_ID;
            jh.BRANCH_CODE = branch;
            jh.WORKING_PERIOD = Working_Period;
            jh.BRANCH_COMMON = branch;
            dss = jh.IMP_EXP_JOB_HISTROY_INSERT_UPDATE();
        }
    }
    */
    /*
    [WebMethod]
    public void DSC_GET_SIGNED_FLATFILE_DATA_RETURN(string Comp_EID, string User_ID, string branch, string jobno, string JobType, string Working_Period, string EncodeString)
    {
        DataSet dss = new DataSet();
        DataSet dsc = new DataSet();
        DataSet ds = new DataSet();
        Job_Histroy jh = new Job_Histroy();
        var ERM = new Elogix_Masters();
        ds = ERM.Company_Details(Comp_EID, Working_Period);
        string com_brn = "";
        string Company_Lic = "";
        string grpname = "", foldername = "";

        if (JobType.ToUpper() == "E")
        {
            JobType = "EXP";
            foldername = "EXP_Job_history";
        }
        else if (JobType.ToUpper() == "I")
        {
            JobType = "IMP";
            foldername = "IMP_Job_history";
        }
        else if (JobType.ToUpper() == "IQ" || JobType.ToUpper() == "IA")
        {
            foldername = "IMP_Job_history";
        }
        else if (JobType.ToUpper() == "EQ" || JobType.ToUpper() == "EA")
        {
            foldername = "EXP_Job_history";
        }
        else if (JobType.ToUpper() == "GR")
        {
            foldername = "GoodsRegistration";
        }

        if (ds.Tables[0].Rows.Count > 0)
        {
            com_brn = ds.Tables[0].Rows[0][1].ToString();
            jh.YEAR = ds.Tables[0].Rows[0][0].ToString();
            Company_Lic = ds.Tables[0].Rows[0][2].ToString();

            if (com_brn == "A")
            {
                grpname = branch;
                jh.COMPANY_ID = jobno;
                jh.DESCRIPTION = branch;
                jh.JOB_TYPE = JobType;
                jh.FLAG = "GetBranchCode";
                branch = "";
                dsc = jh.RetrieveBranch_DSC(ds.Tables[0].Rows[0][0].ToString());
                if (dsc.Tables.Count > 0)
                {
                    branch = dsc.Tables[0].Rows[0]["BRANCHCODE"].ToString();
                }
            }

            string errorFolder = "";
            if (com_brn == "B")
            {
                errorFolder = Server.MapPath("~/Submission/" + Company_Lic + "/" + branch + "/" + foldername + "/");
            }
            else if (com_brn == "A")
            {
                errorFolder = Server.MapPath("~/Submission/" + Company_Lic + "/" + grpname + "/" + foldername + "/");
            }
            else
            {
                errorFolder = Server.MapPath("~/Submission/" + Company_Lic + "/" + foldername + "/");
            }

            
            //string paddedEncode = EncodeString;
            //int mod = paddedEncode.Length % 4;
            //if (mod > 0)
            //    paddedEncode += new string('=', 4 - mod);

            //var base64EncodedBytes = System.Convert.FromBase64String(paddedEncode);
            //string jobdata = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);

            var base64EncodedBytes = System.Convert.FromBase64String(EncodeString);
            string jobdata = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);

            if (Directory.Exists(errorFolder) == false)
            {
                Directory.CreateDirectory(errorFolder);
            }

            // ============================================================
            // TEXT FILE NAME (existing - unchanged)
            // ============================================================
            string jobno_name = "";
            if (JobType == "EXP")
            {
                jobno_name = jobno + " ~~" + jobno + DateTime.Now.Year.ToString() + "Signed.sb";
            }
            else if (JobType == "IMP")
            {
                jobno_name = jobno + " ~~" + jobno + DateTime.Now.Year.ToString() + "Signed.be";
            }
            else if (JobType == "IQ")
            {
                jobno_name = jobno + " ~~" + jobno + DateTime.Now.Year.ToString() + "Signed.rpl";
            }
            else if (JobType == "EQ")
            {
                jobno_name = jobno + " ~~" + jobno + DateTime.Now.Year.ToString() + "Signed.rpl";
            }
            else if (JobType == "IA")
            {
                jobno_name = jobno + " ~~" + jobno + DateTime.Now.Year.ToString() + "Signed.beamd";
            }
            else if (JobType == "EA")
            {
                jobno_name = jobno + " ~~" + jobno + DateTime.Now.Year.ToString() + "Signed.sbamd";
            }
            else if (JobType == "GR")
            {
                jobno_name = jobno + " ~~" + jobno + DateTime.Now.Year.ToString() + "Signed.gr";
            }


            System.IO.File.WriteAllText(errorFolder + jobno_name, jobdata);
            string file = jobno_name;

            string path = errorFolder + file;

            // Existing text file save (unchanged)
            System.IO.File.WriteAllText(errorFolder + jobno_name, jobdata);

            // ============================================================
            // JSON FILE - create and save
            // ============================================================
            //string json_name = jobno + " ~~" + jobno + DateTime.Now.Year.ToString() + "Signed.json";
            //string jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(jobdata, Newtonsoft.Json.Formatting.Indented);
            //System.IO.File.WriteAllText(errorFolder + json_name, jsonContent);
            string json_name = jobno + " ~~" + jobno + DateTime.Now.Year.ToString() + "Signed.json";

           
            object parsedJson = Newtonsoft.Json.JsonConvert.DeserializeObject(jobdata);
            string jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(parsedJson, Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText(errorFolder + json_name, jsonContent);

            // ============================================================
            // DB INSERT
            // ATTACHMENT_FILE = text file (.be / .sb etc)
            // WEB_PATHURL     = json file (.json)
            // ============================================================
            jh.JOB_ID = "";
            jh.JOBNO = jobno;
            jh.JOBDATE = "01/01/1900";
            jh.JOB_TYPE = JobType.ToUpper();
            jh.COMPANY_ID = Company_Lic;
            jh.DESCRIPTION = errorFolder;
            jh.ATTACHMENT_FILE = jobno_name;   // existing text file
            jh.WEB_PATHURL = json_name;    // new json file
            jh.FLAG = "DSCFile_Upload";
            jh.USER_ID = User_ID;
            jh.BRANCH_CODE = branch;
            jh.WORKING_PERIOD = Working_Period;
            jh.BRANCH_COMMON = branch;
            dss = jh.IMP_EXP_JOB_HISTROY_INSERT_UPDATE();
        }
    }
     * */

/*
    [WebMethod]
    public void DSC_GET_SIGNED_FLATFILE_DATA_RETURN(string Comp_EID, string User_ID, string branch, string jobno, string JobType, string Working_Period, string EncodeString)
    {
        //if (Comp_EID.ToUpper() == "ERI00747")
        //{
        DataSet dss = new DataSet();
        DataSet dsc = new DataSet();
        DataSet ds = new DataSet();
        Job_Histroy jh = new Job_Histroy();
        var ERM = new Elogix_Masters();
        ds = ERM.Company_Details(Comp_EID, Working_Period);
        string com_brn = "";
        string Company_Lic = "";
        string grpname = "", foldername = "";

        if (JobType.ToUpper() == "E")
        {
            JobType = "EXP";
            foldername = "EXP_Job_history";
        }
        else if (JobType.ToUpper() == "I")
        {
            JobType = "IMP";
            foldername = "IMP_Job_history";
        }
        else if (JobType.ToUpper() == "IQ" || JobType.ToUpper() == "IA")
        {

            foldername = "IMP_Job_history";
        }
        else if (JobType.ToUpper() == "EQ" || JobType.ToUpper() == "EA")
        {

            foldername = "EXP_Job_history";
        }

        else if (JobType.ToUpper() == "GR")
        {

            foldername = "GoodsRegistration";
        }

        if (ds.Tables[0].Rows.Count > 0)
        {
            com_brn = ds.Tables[0].Rows[0][1].ToString();// This falg is used to find whether this client using branchwise / common job no
            jh.YEAR = ds.Tables[0].Rows[0][0].ToString(); // here i hv used this parameter to carry server details .
            Company_Lic = ds.Tables[0].Rows[0][2].ToString(); // This string is used to get the company ID

            if (com_brn == "A")
            {
                grpname = branch;
                jh.COMPANY_ID = jobno;

                jh.DESCRIPTION = branch;
                jh.JOB_TYPE = JobType;
                jh.FLAG = "GetBranchCode";
                branch = "";
                dsc = jh.RetrieveBranch_DSC(ds.Tables[0].Rows[0][0].ToString());
                if (dsc.Tables.Count > 0)
                {
                    branch = dsc.Tables[0].Rows[0]["BRANCHCODE"].ToString();
                }
            }

            string errorFolder = "";
            if (com_brn == "B")
            {
                //errorFolder = Server.MapPath("~/Submission/" + Company_Lic + "/" + branch + "/" + JobType + "_Job_history" + "/");
                errorFolder = Server.MapPath("~/Submission/" + Company_Lic + "/" + branch + "/" + foldername + "/");
            }
            else if (com_brn == "A")
            {
                errorFolder = Server.MapPath("~/Submission/" + Company_Lic + "/" + grpname + "/" + foldername + "/");
            }
            else
            {
                errorFolder = Server.MapPath("~/Submission/" + Company_Lic + "/" + foldername + "/");
            }

            var base64EncodedBytes = System.Convert.FromBase64String(EncodeString);
            string jobdata = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);

            if (Directory.Exists(errorFolder) == false)
            {
                Directory.CreateDirectory(errorFolder);
            }


            string jobno_name = "";
            if (JobType == "EXP")
            {
                jobno_name = jobno + " ~~" + jobno + DateTime.Now.Year.ToString() + "Signed.sb"; // Request["jobno"].ToString() + "~~" + fileName;
            }
            else if (JobType == "IMP")
            {
                jobno_name = jobno + " ~~" + jobno + DateTime.Now.Year.ToString() + "Signed.be"; // Request["jobno"].ToString() + "~~" + fileName;
            }
            else if (JobType == "IQ")
            {
                jobno_name = jobno + " ~~" + jobno + DateTime.Now.Year.ToString() + "Signed.rpl";

            }
            else if (JobType == "EQ")
            {
                jobno_name = jobno + " ~~" + jobno + DateTime.Now.Year.ToString() + "Signed.rpl";
            }
            else if (JobType == "IA")
            {
                jobno_name = jobno + " ~~" + jobno + DateTime.Now.Year.ToString() + "Signed.beamd";

            }
            else if (JobType == "EA")
            {
                jobno_name = jobno + " ~~" + jobno + DateTime.Now.Year.ToString() + "Signed.sbamd";
            }

            else if (JobType == "GR")
            {
                jobno_name = jobno + " ~~" + jobno + DateTime.Now.Year.ToString() + "Signed.gr";
            }

            System.IO.File.WriteAllText(errorFolder + jobno_name, jobdata);
            string file = jobno_name;

            string path = errorFolder + file;

            jh.JOB_ID = "";
            jh.JOBNO = jobno;

            jh.JOBDATE = "01/01/1900";
            jh.JOB_TYPE = JobType.ToUpper();
            jh.COMPANY_ID = Company_Lic;
            jh.DESCRIPTION = errorFolder;
            jh.ATTACHMENT_FILE = file;
            jh.FLAG = "DSCFile_Upload";
            jh.USER_ID = User_ID;
            jh.BRANCH_CODE = branch;
            jh.WORKING_PERIOD = Working_Period;
            jh.BRANCH_COMMON = branch;
            dss = jh.IMP_EXP_JOB_HISTROY_INSERT_UPDATE();
        }

    }
    */

    [WebMethod]
    public DataTable E_Invoice_IRN(string Comp_EID, string WK, string branch, string JobType, string InvoiceNo, string IRN_No, string AckNo, string AckDt,
        string SignedQRCodeImage, string SignedQRCode, string Status)
    {
        DataTable dt = new DataTable();
        DataSet dss = new DataSet();
        DataSet dsc = new DataSet();
        DataSet ds = new DataSet();
        Job_Histroy jh = new Job_Histroy();
        var ERM = new Elogix_Masters();
        ds = ERM.Company_Details(Comp_EID, WK);
        string com_brn = "";
        string Company_Lic = "";
        string grpname = "";
        string wkp = "";


        if (ds.Tables[0].Rows.Count > 0)
        {
            com_brn = ds.Tables[0].Rows[0][1].ToString();// This falg is used to find whether this client using branchwise / common job no
            jh.YEAR = ds.Tables[0].Rows[0][0].ToString(); // here i hv used this parameter to carry server details .
            Company_Lic = ds.Tables[0].Rows[0][2].ToString(); // This string is used to get the company ID
            wkp = ds.Tables[0].Rows[0]["Current_WKP"].ToString();

            if (com_brn == "A")
            {
                grpname = branch;
                jh.COMPANY_ID = InvoiceNo;

                jh.DESCRIPTION = branch;
                jh.JOB_TYPE = JobType;
                jh.FLAG = "GetBranchCode_UsingInvoice";
                branch = "";
                dsc = jh.RetrieveBranch_DSC(ds.Tables[0].Rows[0][0].ToString());
                if (dsc.Tables.Count > 0)
                {
                    branch = dsc.Tables[0].Rows[0]["BRANCHCODE"].ToString();
                }
            }

            string errorFolder = "";
            if (com_brn == "B")
            {
                errorFolder = Server.MapPath("~/Submission/" + Company_Lic + "/" + branch + "/GST_BILL_QRCODE/" + JobType.ToUpper() + "/" + wkp + "/");
            }
            else if (com_brn == "A")
            {
                errorFolder = Server.MapPath("~/Submission/" + Company_Lic + "/" + grpname + "/GST_BILL_QRCODE/" + JobType.ToUpper() + "/" + wkp + "/");
            }
            else
            {
                errorFolder = Server.MapPath("~/Submission/" + Company_Lic + "/GST_BILL_QRCODE/" + JobType.ToUpper() + "/" + wkp + "/");
            }



            var base64EncodedBytes = System.Convert.FromBase64String(SignedQRCodeImage);
            string jobdata = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);

            if (Directory.Exists(errorFolder) == false)
            {
                Directory.CreateDirectory(errorFolder);
            }


            jh.JOB_ID = "";
            jh.JOB_TYPE = JobType.ToUpper();
            jh.INV_No = InvoiceNo;

            string jobno_name = "";
            InvoiceNo = InvoiceNo.Replace("/", "_");
            jobno_name = JobType + "_Invoice_" + InvoiceNo + "_" + DateTime.Now.Year.ToString() + ".png";
            System.IO.File.WriteAllBytes(errorFolder + jobno_name, base64EncodedBytes);
            string SQ_Path = errorFolder + jobno_name;

            //http://demo.eroyalimpex.co.in/FlatFile_DSC/1/IMP/3002020.be  // http path



            string url = HttpContext.Current.Request.Url.AbsoluteUri.ToLower();
            if (url.Contains("localhost"))
            {
                url = url.Substring(0, url.IndexOf("loginpage")) + SQ_Path.Substring(SQ_Path.IndexOf("Submission"), SQ_Path.Length - (SQ_Path.IndexOf("Submission")));
            }
            else if (url.Contains("https://eroyalimpex.co/"))
            {
                url = "https://eroyalimpex.co/" + SQ_Path.Substring(SQ_Path.IndexOf("Submission"), SQ_Path.Length - (SQ_Path.IndexOf("Submission")));
            }
            else if (url.Contains("demo.eroyalimpex.co.in"))
            {
                url = "http://demo.eroyalimpex.co.in/" + SQ_Path.Substring(SQ_Path.IndexOf("Submission"), SQ_Path.Length - (SQ_Path.IndexOf("Submission")));
            }
            else if (url.Contains("https://eroyalimpex.co.in/"))
            {
                url = "https://eroyalimpex.co.in/" + SQ_Path.Substring(SQ_Path.IndexOf("Submission"), SQ_Path.Length - (SQ_Path.IndexOf("Submission")));
            }
            else if (url.Contains("demo.eroyalimpex.net"))
            {
                url = "http://demo.eroyalimpex.net/" + SQ_Path.Substring(SQ_Path.IndexOf("Submission"), SQ_Path.Length - (SQ_Path.IndexOf("Submission")));
            }
            else if (url.Contains("http://eroyalimpex.net/"))
            {
                url = "http://eroyalimpex.net/" + SQ_Path.Substring(SQ_Path.IndexOf("Submission"), SQ_Path.Length - (SQ_Path.IndexOf("Submission")));
            }
            else if (url.Contains("demo.eroyalimpex.org"))
            {
                url = "http://demo.eroyalimpex.org/" + SQ_Path.Substring(SQ_Path.IndexOf("Submission"), SQ_Path.Length - (SQ_Path.IndexOf("Submission")));
            }
            else if (url.Contains("http://eroyalimpex.org/"))
            {
                url = "http://eroyalimpex.org/" + SQ_Path.Substring(SQ_Path.IndexOf("Submission"), SQ_Path.Length - (SQ_Path.IndexOf("Submission")));
            }

            //url=HttpContext.Current.Request.Url.AbsoluteUri.Substring(0,HttpContext.Current.Request.Url.AbsoluteUri.IndexOf("ERoyalimpex_Branchwise_Job_SingleWindow"))+SQ_Path.Substring(SQ_Path.IndexOf("Submission"), SQ_Path.Length - (SQ_Path.IndexOf("Submission")));
            url = url.Replace(@"\", @"/");

            jh.IRN_No = IRN_No;
            jh.ACK_No = AckNo;
            jh.ACK_Dt = AckDt;
            jh.SignedQRCodeImage = SignedQRCodeImage;
            jh.SignedQRCode = SignedQRCode;
            jh.STATUS = Status;

            jh.QRCode_ImgPath = url;
            jh.InvFile_Path = "";

            jh.FLAG = "Save";

            jh.BRANCH_CODE = branch;

            jh.BRANCH_COMMON = branch;
            jh.DESCRIPTION = "WebService";
            jh.QRCode_PhysicalPath = SQ_Path;
            jh.InvFile_PhysicalPath = "";

            dss = jh.EINVOCIE_IRN_INSERT_UPDATE();
        }
        else
        {
            dt.Rows.Add("Failure", "UnSuccess", "");
        }
        if (dss.Tables.Count > 0)
        {
            if (dss.Tables[0].Rows.Count > 0)
            {
                dt = dss.Tables[0];
            }
            else
            {
                dt.Rows.Add("Failure", "UnSuccess", "");
            }
        }
        else
        {
            dt.Rows.Add("Failure", "UnSuccess", "");
        }

        return dt;

    }

    [WebMethod]
    public DataTable E_Invoice_IRN_CR_Note(string Comp_EID, string WK, string branch, string JobType, string InvoiceNo, string IRN_No, string AckNo, string AckDt,
        string SignedQRCodeImage, string SignedQRCode, string Status)
    {
        DataTable dt = new DataTable();
        DataSet dss = new DataSet();
        DataSet dsc = new DataSet();
        DataSet ds = new DataSet();
        Job_Histroy jh = new Job_Histroy();
        var ERM = new Elogix_Masters();
        ds = ERM.Company_Details(Comp_EID, WK);
        string com_brn = "", Company_Lic = "", grpname = "", wkp = "";

        if (ds.Tables[0].Rows.Count > 0)
        {
            com_brn = ds.Tables[0].Rows[0][1].ToString();// This falg is used to find whether this client using branchwise / common job no
            jh.YEAR = ds.Tables[0].Rows[0][0].ToString(); // here i hv used this parameter to carry server details .
            Company_Lic = ds.Tables[0].Rows[0][2].ToString(); // This string is used to get the company ID
            wkp = ds.Tables[0].Rows[0]["Current_WKP"].ToString();
            if (com_brn == "A")
            {
                grpname = branch;
                jh.COMPANY_ID = InvoiceNo;

                jh.DESCRIPTION = branch;
                jh.JOB_TYPE = JobType;
                jh.FLAG = "GetBranchCode_UsingInvoice";
                branch = "";
                dsc = jh.RetrieveBranch_DSC(ds.Tables[0].Rows[0][0].ToString());
                if (dsc.Tables.Count > 0)
                {
                    branch = dsc.Tables[0].Rows[0]["BRANCHCODE"].ToString();
                }
            }

            string url = HttpContext.Current.Request.Url.AbsoluteUri.ToLower();
            string errorFolder = "", Year = "2023-2024";
            if (com_brn == "B")
            {
                errorFolder = Server.MapPath("~/Submission/" + Company_Lic + "/" + branch + "/" + Year + "/CR_NOTE_BILL_QRCODE/" + JobType.ToUpper() + "/");
            }
            else if (com_brn == "A")
            {
                errorFolder = Server.MapPath("~/Submission/" + Company_Lic + "/" + grpname + "/" + Year + "/CR_NOTE_BILL_QRCODE/" + JobType.ToUpper() + "/");
            }
            else
            {
                errorFolder = Server.MapPath("~/Submission/" + Company_Lic + "/" + Year + "/CR_NOTE_BILL_QRCODE/" + JobType.ToUpper() + "/");
            }

            var base64EncodedBytes = System.Convert.FromBase64String(SignedQRCodeImage);
            string jobdata = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);

            if (Directory.Exists(errorFolder) == false)
            {
                Directory.CreateDirectory(errorFolder);
            }
            jh.JOB_ID = "";
            jh.JOB_TYPE = JobType.ToUpper();
            jh.INV_No = InvoiceNo;

            //string jobno_name = "";
            InvoiceNo = InvoiceNo.Replace("/", "_");
            CR_jobno_name = JobType + "_Invoice_" + InvoiceNo + "_" + DateTime.Now.Year.ToString() + ".png";
            System.IO.File.WriteAllBytes(errorFolder + CR_jobno_name, base64EncodedBytes);
            string SQ_Path = errorFolder + CR_jobno_name;
            if (com_brn == "B")
            {
                if (url.Contains("demo.eroyalimpex.co.in"))
                {
                    url = "https://demo.eroyalimpex.co.in/Submission/" + Company_Lic + "/" + branch + "/" + Year + "/CR_NOTE_BILL_QRCODE/" + CR_jobno_name;
                }
                else if (url.Contains("eroyalimpex.co.in"))
                {
                    url = "https://eroyalimpex.co.in/Submission/" + Company_Lic + "/" + branch + "/" + Year + "/CR_NOTE_BILL_QRCODE/" + CR_jobno_name;
                }
                else if (url.Contains("eroyalimpex.co"))
                {
                    url = "https://eroyalimpex.co/Submission/" + Company_Lic + "/" + branch + "/" + Year + "/CR_NOTE_BILL_QRCODE/" + CR_jobno_name;
                }

            }
            else if (com_brn == "C")
            {
                if (url.Contains("demo.eroyalimpex.co.in"))
                {
                    url = "https://demo.eroyalimpex.co.in/Submission/" + Company_Lic + "/" + Year + "/CR_NOTE_BILL_QRCODE/" + CR_jobno_name;
                }
                else if (url.Contains("eroyalimpex.co.in"))
                {
                    url = "https://eroyalimpex.co.in/Submission/" + Company_Lic + "/" + Year + "/CR_NOTE_BILL_QRCODE/" + CR_jobno_name;
                }
                else if (url.Contains("eroyalimpex.co"))
                {
                    url = "https://eroyalimpex.co/Submission/" + Company_Lic + "/" + Year + "/CR_NOTE_BILL_QRCODE/" + CR_jobno_name;
                }
            }

            url = url.Replace(@"\", @"/");
            jh.IRN_No = IRN_No;
            jh.ACK_No = AckNo;
            jh.ACK_Dt = AckDt;
            jh.SignedQRCodeImage = SignedQRCodeImage;
            jh.SignedQRCode = SignedQRCode;
            jh.STATUS = Status;
            jh.QRCode_ImgPath = url;
            jh.InvFile_Path = "";
            jh.FLAG = "Save";
            jh.BRANCH_CODE = branch;
            jh.BRANCH_COMMON = branch;
            jh.DESCRIPTION = "WebService";
            jh.QRCode_PhysicalPath = SQ_Path;
            jh.InvFile_PhysicalPath = "";
            dss = jh.EINVOCIE_IRN_INSERT_UPDATE_CR();
        }
        else
        {
            dt.Rows.Add("Failure", "UnSuccess", "");
        }
        if (dss.Tables.Count > 0)
        {
            if (dss.Tables[0].Rows.Count > 0)
            {
                dt = dss.Tables[0];
            }
            else
            {
                dt.Rows.Add("Failure", "UnSuccess", "");
            }
        }
        else
        {
            dt.Rows.Add("Failure", "UnSuccess", "");
        }

        return dt;

    }
       
       
    }
