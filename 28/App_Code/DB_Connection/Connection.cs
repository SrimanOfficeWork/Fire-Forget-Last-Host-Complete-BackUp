using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using BussinessObject;

public class Connection
{
    public static string GetConnection()
    {
        return HttpContext.Current.Session["currentcomp_db"].ToString();
    }

    public static string Get_E_IMPORT()
    {
        return HttpContext.Current.Session["E_IMPORT"].ToString();
    }
    public static string Get_E_EXPORT()
    {
        return HttpContext.Current.Session["E_EXPORT"].ToString();
    }
    public static string Get_E_BILLING()
    {
        return HttpContext.Current.Session["E_BILLING"].ToString();
    }
    public static string Get_E_ACCOUNTS()
    {
        return HttpContext.Current.Session["E_ACCOUNTS"].ToString();
    }
   
    public static string Get_Userdetails()
    {
        return HttpContext.Current.Session["USER_DETAILS_DS"].ToString();
    }

    public static DataSet Get_Userdetails_Ds()
    {
        return (DataSet)HttpContext.Current.Session["USER_DETAILS_DS"];
    }

   


    public static string Get_Company_Type()
    {
        string SELECT_BRANCH = "", SELECT_TYPE = "";
     
        if (HttpContext.Current.Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = HttpContext.Current.Session["SELECT_TYPE"].ToString();

            if (SELECT_TYPE == "Branchwise Job" || SELECT_TYPE == "Areawise Job")
            {
                SELECT_BRANCH = HttpContext.Current.Session["currentbranch"].ToString();
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

        return SELECT_BRANCH;
    }
    public static string Get_Con_String(string wrk)
    {

        DataSet ds = new DataSet();
        DataSet dss = new DataSet();
        string Con_wrk = string.Empty;
        if (HttpContext.Current.Session["COMPANY_DETAILS_DS"] != null)
        {
            ds = (DataSet)HttpContext.Current.Session["COMPANY_DETAILS_DS"];

            DataTable ds3 = new DataTable();
            ds3 = ds.Tables[2];
            DataView view1 = ds3.DefaultView;
            string a = wrk;
            view1.RowFilter = "WORKING_PERIOD = '" + a + "'";
            DataTable table1 = view1.ToTable();
            Con_wrk = table1.Rows[0]["SERVER_NAME"].ToString();
        }

        return Con_wrk;
    }
    public static int GetAdmin_lock()
    {
        if (HttpContext.Current.Session["JOB_LOCK"] != null && HttpContext.Current.Session["JOB_LOCK"] != "")
        {
            return Convert.ToInt32(HttpContext.Current.Session["JOB_LOCK"].ToString());
        }
        else
        {
            return 0;
        }
    }

    public static string E_Logix_Company_Id()
    {
        string Company_Id = COMPANYID(), EElogix_Id = string.Empty;
        if (Company_Id == "402" || Company_Id == "411" || Company_Id == "1" || Company_Id == "10" || Company_Id == "421" || Company_Id == "435" || Company_Id == "436" || Company_Id == "438" || Company_Id == "439" || Company_Id == "442" || Company_Id == "443" || Company_Id == "444" || Company_Id == "457" || Company_Id == "459" || Company_Id == "462" || Company_Id == "472" || Company_Id == "477" || Company_Id == "478" || Company_Id == "479" || Company_Id == "487" || Company_Id == "492" || Company_Id == "494" || Company_Id == "499" || Company_Id == "525" || Company_Id == "526" || Company_Id == "527" || Company_Id == "531" || Company_Id == "532" || Company_Id == "536" || Company_Id == "2083")
        {

            if (Company_Id == "402")
            {
                //EElogix_Id = "IMS53N4A";
                EElogix_Id = "IMS5T3H8J";                
            }
            else if (Company_Id == "411")
            {
                EElogix_Id = "IMS6K8K3D";
            }
            else if (Company_Id == "421")
            {
                EElogix_Id = "IMS9B3Z8J";
            }
            else if (Company_Id == "435")
            {
                EElogix_Id = "IMS5R5E5C";
            }
            else if (Company_Id == "436")
            {
                EElogix_Id = "IMS3S3Y4D";
            }
            else if (Company_Id == "438")
            {
                EElogix_Id = "IMS3D1J3T";
            }
            else if (Company_Id == "439")
            {
                EElogix_Id = "IMS2K4N0P";
            }
            else if (Company_Id == "442")
            {
                EElogix_Id = "IMS6D6W7C";
            }
            else if (Company_Id == "443")
            {
                EElogix_Id = "IMS7O3F9T";
            }
            else if (Company_Id == "444")
            {
                EElogix_Id = "IMS9C3H5P";
            }
            else if (Company_Id == "457")
            {
                EElogix_Id = "IMS5I4X5V";
            }
            else if (Company_Id == "459")
            {
                EElogix_Id = "IMS9Q5E3Q";
            }
            else if (Company_Id == "462")
            {
                EElogix_Id = "IMS1Y5U2Z";
            }
            else if (Company_Id == "472")
            {
                EElogix_Id = "IMS5L1E6F";
            }
            else if (Company_Id == "477")
            {
                EElogix_Id = "IMS2E8R9N";
            }
            else if (Company_Id == "478")
            {
                EElogix_Id = "IMS0L1O3B";
            }
            else if (Company_Id == "479")
            {
                EElogix_Id = "IMS7V7C5B";
            }
            else if (Company_Id == "487")
            {
                EElogix_Id = "IMS53N4A";
            }
            else if (Company_Id == "492")
            {
                EElogix_Id = "IMS3H8I2L";
            }
            else if (Company_Id == "494")
            {
                //EElogix_Id = "IMS1U1C8Q";
                EElogix_Id = "IMS4X2U1R";
            }
            //else if (Company_Id == "499")
            //{
            //    EElogix_Id = "IMS6T3R3E";
            //}
            else if (Company_Id == "499" || Company_Id == "526")
            {
                EElogix_Id = "VPS";
            }
            else if (Company_Id == "525")
            {
                EElogix_Id = "IMS9Y82L";
            }
            else if (Company_Id == "527")
            {
                EElogix_Id = "IMS75U1N";
            }
            else if (Company_Id == "531")
            {
                EElogix_Id = "IMS5H6Q2F";
            }
            else if (Company_Id == "532")
            {
                EElogix_Id = "IMS11A5R";
            }
            else if (Company_Id == "536")
            {
                EElogix_Id = "IMS9V5D3Q";
            }
            else if (Company_Id == "2083")
            {
                EElogix_Id = "";
            }

            else if (Company_Id == "1")
            {
                EElogix_Id = "CBS8M5F5X2";
            }
            else if (Company_Id == "10")
            {
                EElogix_Id = "CBS8M5F5X2";
            }
        }
        return EElogix_Id;
    }

    public static string Billing_eInvoice()
    {
        string Company_Id = COMPANYID(), eInvoice = string.Empty, Company_Group_Name = string.Empty;
        Company_Group_Name = Current_Group();
        if (Company_Id == "1" || Company_Id == "4" || Company_Id == "10" || Company_Id == "244" || Company_Id == "517" || Company_Id == "775" || Company_Id == "1120" || Company_Id == "1157" || Company_Id == "1175" || Company_Id == "1186" || Company_Id == "1598" || Company_Id == "1691" || Company_Id == "2099" || Company_Id == "3229")
        {
            eInvoice = "Y";
        }
        else if (Company_Id == "1509" && (Company_Group_Name == "CHENNAI" || Company_Group_Name == "BANGALORE" || Company_Group_Name == "VIZAG" || Company_Group_Name == "PONDICHERRY"))
        {
            eInvoice = "Y";    //VINTAGE
        }

        return eInvoice;
    }
    public static string Billing_Working_Period()
    {
        string Company_Id = COMPANYID(), Wk= string.Empty;

        Wk = "Y";
        if (Company_Id == "2" || Company_Id == "10" || Company_Id == "188" || Company_Id == "244" || Company_Id == "247" || Company_Id == "268" || Company_Id == "314" || Company_Id == "353" || Company_Id == "375" || Company_Id == "381" || Company_Id == "406" || Company_Id == "480" || Company_Id == "508" || Company_Id == "517" || Company_Id == "561" || Company_Id == "576" || Company_Id == "588" || Company_Id == "653" || Company_Id == "664" || Company_Id == "725" || Company_Id == "727" || Company_Id == "775" || Company_Id == "783" || Company_Id == "1011" || Company_Id == "1019" || Company_Id == "1120" || Company_Id == "1157" || Company_Id == "1158" || Company_Id == "1159" || Company_Id == "1175" || Company_Id == "1186" || Company_Id == "1509" || Company_Id == "1523" || Company_Id == "1529" || Company_Id == "3094")
        {
            Wk = "Y";
        }
        return Wk;
    }
       
    public static string Billing_Aproval_Company()
    {
        string Company_Id = COMPANYID(), Aprove = string.Empty, User_ID = Current_User_Upper();

        if (Company_Id == "10" || Company_Id == "4" || Company_Id == "188" || Company_Id == "244" || Company_Id == "287" || Company_Id == "480" || Company_Id == "588" || Company_Id == "1011" || Company_Id == "1019" || Company_Id == "653" || Company_Id == "1159" || Company_Id == "1176" || Company_Id == "1534" || Company_Id == "1714")
        {
            Aprove = "Y";
        }
        return Aprove;
    }

    public static string Billing_Aproval_Admin()
    {
        string Company_Id = COMPANYID(), Aprove = string.Empty, User_ID = Current_User_Upper();

        if (Company_Id == "10" && User_ID == "R")
        {
            Aprove = "Y";
        }
        else if (Company_Id == "287")
        {
            if (User_ID == "RTS" || User_ID == "FALCONIMP" || User_ID == "FALCONEXP")
            {
                Aprove = "Y";
            }
        }
        else if (Company_Id == "480")
        {
            if (User_ID == "RTS" || User_ID == "RAJI" || User_ID == "PRIYA" || User_ID == "PRIYADHARSHINI" || User_ID == "SANCOCBE" || User_ID == "LAKSHMI")
            {
                Aprove = "Y";
            }
        }

        else if (Company_Id == "1011")
        {
            if (User_ID == "RTS" || User_ID == "SANGEETHA")
            {
                Aprove = "Y";
            }
        }
        else if (Company_Id == "1019")
        {
            if (User_ID == "RTS" || User_ID == "AIRACCOUNTS" || User_ID == "SANCOCBE")
            {
                Aprove = "Y";
            }
        }
        else if (Company_Id == "188" || Company_Id == "244" || Company_Id == "588" || Company_Id == "653" || Company_Id == "1159" || Company_Id == "1176" || Company_Id == "1534" || Company_Id == "1714")
        {
            Aprove = "Y";
        }
        else if (Company_Id == "4" && User_ID == "SATHISH" || User_ID == "MOHAMMED")
        {
            Aprove = "Y";
        }
        return Aprove;
    }
    public static string JCBI_Type()//Job_Common_Billing_Individual
    {
        string Company_Id = COMPANYID(), JCBI = "N";
        if (Company_Id == "517")
        {
            JCBI = "Y";
        }
        return JCBI;
    }

    //-----------------------------------------------------------------------------------
    public static string e_WayBill(string IMP_EXP)
    {
        string Company_Id = COMPANYID(), isActive = string.Empty;

        if (IMP_EXP == "I")
        {
            if (Company_Id == "125" || Company_Id == "1" || Company_Id == "4" || Company_Id == "151" || Company_Id == "152" 
                || Company_Id == "196" || Company_Id == "265" || Company_Id == "293" || Company_Id == "139" || Company_Id == "313" 
                || Company_Id == "341" || Company_Id == "350" || Company_Id == "371" || Company_Id == "378" || Company_Id == "394" 
                || Company_Id == "412" || Company_Id == "476" || Company_Id == "499" || Company_Id == "510" || Company_Id == "517" 
                || Company_Id == "518" || Company_Id == "526" || Company_Id == "599" || Company_Id == "662" || Company_Id == "1026"
                || Company_Id == "1035" || Company_Id == "1103" || Company_Id == "1116" || Company_Id == "1132" || Company_Id == "1142"
                || Company_Id == "1159" || Company_Id == "1160" || Company_Id == "1509" || Company_Id == "1532" || Company_Id == "1628"
                || Company_Id == "1680" || Company_Id == "1681" || Company_Id == "1710" || Company_Id == "2110" || Company_Id == "2158" || Company_Id == "2167"
                || Company_Id == "2373" || Company_Id == "2815" || Company_Id == "2888" || Company_Id == "3353"|| Company_Id == "3370") //Company_Id == "10" || 
            {
                isActive = "Y";
            }
        }
        else
        {
            if (Company_Id == "10" || Company_Id == "1" || Company_Id == "4" || Company_Id == "125" || Company_Id == "151" || Company_Id == "152"
                || Company_Id == "293" || Company_Id == "139" || Company_Id == "371" || Company_Id == "378" || Company_Id == "662" || Company_Id == "1509" 
                || Company_Id == "1532" || Company_Id == "1628" || Company_Id == "1681" || Company_Id == "1710" || Company_Id == "2158" || Company_Id == "2373"
                || Company_Id == "2888" || Company_Id == "3353" || Company_Id == "6002"
                )
            {
                isActive = "Y";
            }
        }
        return isActive;
    }

    public static string Billing_YN(string Type)
    {
        Dynamic_Report_GroupNew DRT = new Dynamic_Report_GroupNew();
        string Billing_YN = "N";

        DataSet ds = new DataSet();
      
        Global_variables ObjUBO = new Global_variables();
        DataSet ds1 = new DataSet();
        User_Rights_Details_cs UMR = new User_Rights_Details_cs();

        ObjUBO.A1 = Connection.Company_License();
        ObjUBO.A3 = HttpContext.Current.Session["USER_CREATION_ID"].ToString();
        ObjUBO.A40 = "Menu_ID_Select";
        ds1 = UMR.User_Rights_Select(ObjUBO);
        if (ds1.Tables[0].Rows.Count > 0)
        {
            var FullName1 = from DataRow drr in ds1.Tables[0].AsEnumerable()
                            where drr.Field<string>("MENU_ID").Contains("B")
                            select drr;

            DataView dvv = FullName1.AsDataView();

            if (dvv.Count > 0)
            {
                Billing_YN = "Y";
            }
        }

        return Billing_YN;
    }


    public static string e_lOGIX(string IMP_EXP,string Flg )
    {
        string Company_Id = COMPANYID(), isActive = string.Empty;


        if (IMP_EXP == "I")
        {
            if (e_lOGIX_CHENNAI()!="")
            {
                E_LOGIX ES = new E_LOGIX();
                ES.E_logic_Update(IMP_Jobno(), "I", Flg);
            }
            else if (e_lOGIX_MUMBAI() != "")
            {
                E_LOGIX_MUMBAI ES = new E_LOGIX_MUMBAI();
                ES.E_logic_Update(IMP_Jobno(), "I", Flg);
            }
        }
        else
        {
            if (e_lOGIX_CHENNAI() != "")
            {
                E_LOGIX ES = new E_LOGIX();
                ES.E_logic_Update(EXP_Jobno(), "E", Flg);
            }
            else if (e_lOGIX_MUMBAI() != "")
            {
                E_LOGIX_MUMBAI ES = new E_LOGIX_MUMBAI();
                ES.E_logic_Update(EXP_Jobno(), "E", Flg);
            }
        }
        return isActive;
    }

    public static string e_lOGIX_CHENNAI()
    {
        string Company_Id = COMPANYID(), EElogix_Id = string.Empty;
        if (Company_Id == "1121")
        {
            if (Company_Id == "1121")
            {
                EElogix_Id = "IMS4D4K0S";
            }
        }
        return EElogix_Id;
    }

    public static string e_lOGIX_MUMBAI()
    {
        string Company_Id = COMPANYID(), EElogix_Id = string.Empty;

        if (Company_Id == "402" || Company_Id == "411" || Company_Id == "1" || Company_Id == "421" || Company_Id == "435" || Company_Id == "436" || Company_Id == "438" || Company_Id == "442" || Company_Id == "443" || Company_Id == "444" || Company_Id == "457" || Company_Id == "459" || Company_Id == "462" || Company_Id == "477" || Company_Id == "478" || Company_Id == "479" || Company_Id == "487" || Company_Id == "492" || Company_Id == "494" || Company_Id == "499" || Company_Id == "525" || Company_Id == "526" || Company_Id == "530" || Company_Id == "531" || Company_Id == "532" || Company_Id == "536" || Company_Id == "601" || Company_Id == "603" || Company_Id == "607" || Company_Id == "639" || Company_Id == "640" || Company_Id == "642" || Company_Id == "645" || Company_Id == "1239" || Company_Id == "1270" || Company_Id == "2083" || Company_Id == "2131" || Company_Id == "2429")
        {
            if (Company_Id == "402")
            {
                EElogix_Id = "IMS5T3H8J";
            }
            else if (Company_Id == "411")
            {
                EElogix_Id = "IMS6K8K3D";
            }
            else if (Company_Id == "421")
            {
                EElogix_Id = "IMS9B3Z8J";
            }
            else if (Company_Id == "435")
            {
                EElogix_Id = "IMS5R5E5C";
            }
            else if (Company_Id == "436")
            {
                EElogix_Id = "IMS3S3Y4D";
            }
            else if (Company_Id == "438")
            {
                EElogix_Id = "IMS3D1J3T";
            }
            else if (Company_Id == "442")
            {
                EElogix_Id = "IMS6D6W7C";
            }
            else if (Company_Id == "443")
            {
                EElogix_Id = "IMS7O3F9T";
            }
            else if (Company_Id == "444")
            {
                EElogix_Id = "IMS9C3H5P";
            }
            else if (Company_Id == "457")
            {
                EElogix_Id = "IMS5I4X5V";
            }
            else if (Company_Id == "462")
            {
                EElogix_Id = "IMS1Y5U2Z";
            }
            else if (Company_Id == "477")
            {
                EElogix_Id = "IMS2E8R9N";
            }
            else if (Company_Id == "478")
            {
                EElogix_Id = "IMS0L1O3B";
            }
            else if (Company_Id == "479")
            {
                EElogix_Id = "IMS7V7C5B";
            }
            else if (Company_Id == "487")
            {
                EElogix_Id = "IMS53N4A";
            }
            else if (Company_Id == "492")
            {
                EElogix_Id = "IMS3H8I2L";
            }
            else if (Company_Id == "494")
            {
                //EElogix_Id = "IMS1U1C8Q";
                EElogix_Id = "IMS4X2U1R";
                
            }
            else if (Company_Id == "499" || Company_Id == "526")
            {
                EElogix_Id = "VPS";
            }
            else if (Company_Id == "525")
            {
                EElogix_Id = "IMS9Y82L";
            }
            else if (Company_Id == "530")
            {
                EElogix_Id = "IMS9U7I2D";
            }
            else if (Company_Id == "531")
            {
                EElogix_Id = "IMS5H6Q2F";
            }
            else if (Company_Id == "532")
            {
                EElogix_Id = "IMS11A5R";
            }
            else if (Company_Id == "536")
            {
                EElogix_Id = "IMS9V5D3Q";
            }
            else if (Company_Id == "601")
            {
                EElogix_Id = "IMS1B5K7I";
            }
            else if (Company_Id == "603")
            {
                //EElogix_Id = "IMS1N2Y8V";
                EElogix_Id = "IMS9D8N3J";
            }
            else if (Company_Id == "607")
            {
                EElogix_Id = "IMS1K7N9K";
            }
            else if (Company_Id == "639")
            {
                EElogix_Id = "IMS0I6P2I";
            }
            //else if (Company_Id == "640")
            //{
            //    EElogix_Id = "IMS3B6Y3R";
            //}
            else if (Company_Id == "640")
            {
                EElogix_Id = "IMS5O4M1L";
            }
            else if (Company_Id == "642")
            {
                EElogix_Id = "IMS4N1Q1L";
            }
            else if (Company_Id == "645")
            {
                EElogix_Id = "IMS7R6F9F";
            }
            else if (Company_Id == "1239")
            {
                EElogix_Id = "IMS1P7I1P";
            }
            else if (Company_Id == "1270")
            {
                EElogix_Id = "IMS3Z8U1F";
            }
            else if (Company_Id == "2083")
            {
                EElogix_Id = "IMS9A5W6X";
            }
            else if (Company_Id == "2131")
            {
                EElogix_Id = "IMS6Z5P9X";
            }
            else if (Company_Id == "2429")
            {
                EElogix_Id = "IMS5P8A5O";
            }

            else if (Company_Id == "1")
            {
                EElogix_Id = "CBS8M5F5X2";
            }
            else if (Company_Id == "10")
            {
                EElogix_Id = "CBS8M5F5X2";
            }
        }
        return EElogix_Id;
    }

    public static string I_Fact()
    {
        string Company_Id = COMPANYID(), I_Fact_Id = string.Empty;
        if (Company_Id == "4" || Company_Id == "7" || Company_Id == "1135")
        {
            if (Company_Id == "4" || Company_Id == "7" || Company_Id == "1135")
            {
                I_Fact_Id = "IMS8I2P1B";
            }
        }
        return I_Fact_Id;
    }

    public static string Freight_Forward()
    {
        string Company_Id = COMPANYID(), I_Fact_Id = string.Empty;
        if (Company_Id == "4" || Company_Id == "7" || Company_Id == "752" || Company_Id == "816" || Company_Id == "861" || Company_Id == "880" || Company_Id == "1135" || Company_Id == "1317" || Company_Id == "1339" || Company_Id == "2814" || Company_Id == "3082" || Company_Id == "3149" || Company_Id == "3153" || Company_Id == "3253" || Company_Id == "3266")
        {
            if (Company_Id == "4" || Company_Id == "7" || Company_Id == "10" || Company_Id == "752" || Company_Id == "816"  || Company_Id == "861" || Company_Id == "880" || Company_Id == "1135" || Company_Id == "1317" || Company_Id == "1339" || Company_Id == "2814" || Company_Id == "3082" || Company_Id == "3149" || Company_Id == "3153" || Company_Id == "3253" || Company_Id == "3266")
            {
                I_Fact_Id = "IMS8I2P1B";
            }
        }
        return I_Fact_Id;
    }

    public static string I_Code()
    {
        string Company_Id = COMPANYID(), I_Fact_Id = string.Empty;
        if (Company_Id == "861" || Company_Id == "880" || Company_Id == "1317" || Company_Id == "1339")
        {
            I_Fact_Id = "I_Code_Id";
        }
        return I_Fact_Id;
    }
    public static string Ryal()
    {
        string Company_Id = COMPANYID(), I_Fact_Id = string.Empty;
        if (Company_Id == "4" || Company_Id == "7" || Company_Id == "243" || Company_Id == "752" || Company_Id == "2814" || Company_Id == "3082" || Company_Id == "3153" || Company_Id == "3253")
        {
            I_Fact_Id = "IMS8I2P1B";
        }
        return I_Fact_Id;
    }

    public static void Ryal_Data(string Jobno, string Imp_Exp)
    {
        if (Ryal()!= string.Empty)
        {
            Ryal_Post_Data Rp = new Ryal_Post_Data();
            //Rp.Get_Ryal(Jobno, Imp_Exp, "0");
            Rp.Get_Ryal(Jobno, Imp_Exp, "1");
        }
    }

    public static void Ryal_JobRefno_Return(int is_live, string ryal_job_no, string royal_impex_jobno)
    {

        if (Ryal() != string.Empty)
        {
            Ryal_Post_Data Rp = new Ryal_Post_Data();
            Rp.PostjobReferenceNo(is_live, ryal_job_no, royal_impex_jobno);
        }
    }
    public static void Ryal_BEno_Return(int is_live, string ryal_job_no, string royal_impex_jobno, string be_no, string be_date)
    {

        if (Ryal() != string.Empty)
        {
            Ryal_Post_Data Rp = new Ryal_Post_Data();
            Rp.PostBillOfEntry(is_live, ryal_job_no, royal_impex_jobno, be_no, be_date);
        }
    }    
    public static void Ebms_JobRefno_Return(int is_live, string ryal_job_no, string royal_impex_jobno, string Job_type)
    {

        if (Ryal() != string.Empty)
        {
            API_Post_Data Rp = new API_Post_Data();

            Rp.PostJobReferenceNo_Ebms(is_live, ryal_job_no, royal_impex_jobno, Job_type);
        }
    }
    public static void Ebms_BEno_Sbno_Return(int is_live, string ryal_job_no, string royal_impex_jobno, string be_no, string be_date)
    {

        if (Ryal() != string.Empty)
        {
            API_Post_Data Rp = new API_Post_Data();
            Rp.Ebms_Beno_Sbno_Post(ryal_job_no, royal_impex_jobno, be_no, be_date);
        }
    }  
    public static void I_Fact(string Jobno ,string Imp_Exp)
    {
        if (I_Fact() != string.Empty)
        {
            I_FACT IF = new I_FACT();
            IF.Get_I_Fact(Jobno, Imp_Exp);
        }
    }

    public static string Get_DSC_Con_String(string Comp_lic)
    {
        string Con_String = string.Empty;
        Xml_data xd = new Xml_data();
        Con_String = xd.load_XML((Comp_lic).ToUpper());
        return Con_String;
    }
    //-----------------------------------------------------------------------------------

    public static string IMP_Jobno()
    {
        return HttpContext.Current.Session["IMPORT_JOBNO"].ToString();
    }
    public static string EXP_Jobno()
    {
        return HttpContext.Current.Session["EXPORT_JOBNO"].ToString();
    }
    public static string Get_Importer_Name()
    {
        return HttpContext.Current.Session["IMPORTER_NAME"].ToString();
    }
    public static string IMP_Invoice_Slno()
    {
        return HttpContext.Current.Session["Invoice_SLNO"].ToString();
    }
    public static string Current_User()
    {
        return HttpContext.Current.Session["currentuser"].ToString();
    }
    public static string Current_User_Upper()
    {
        return HttpContext.Current.Session["currentuser"].ToString().ToUpper();
    }
    public static string WorkingPeriod()
    {
        return HttpContext.Current.Session["WorkingPeriod"].ToString();
    }
    public static string COMPANYID()
    {
        return HttpContext.Current.Session["COMPANY_ID"].ToString();
    }
    public static string COMPANYID_Upper()
    {
        return HttpContext.Current.Session["COMPANY_ID"].ToString();
    }
    public static string Company_License()
    {
        return HttpContext.Current.Session["COMPANY_LICENSE"].ToString();
    }
    public static string Current_Branch()
    {
        return HttpContext.Current.Session["currentbranch"].ToString();
    }
    public static string Current_Group()
    {
        return HttpContext.Current.Session["GroupName"].ToString();
    }
    public static string Get_Icegate_Id()
    {
        string Ice_Id = string.Empty;

        if (COMPANYID_Upper() == "132")
        {
            if (Current_User_Upper() == "SHRINATHSHIP" || Current_User_Upper() == "SSALSHAZIRA")
            {
                Ice_Id = "SHRINATHSHIP";
            }
            else if (Current_User_Upper() == "SHRINATH7")
            {
                Ice_Id = "SHRINATHSHIP1";
            }
            else
            {
                Ice_Id = HttpContext.Current.Session["ICEGATE_ID"].ToString();
            }
        }
        else if (COMPANYID_Upper() == "146" && Current_User_Upper() == "BWC2")
        {
            Ice_Id = "BWCLOGMAAG";
        }
        else if (COMPANYID_Upper() == "151" && Current_User_Upper() == "FAIRMACSMAA3")
        {
            Ice_Id = "FAIRMACSSEA2";
        }
        else if (COMPANYID_Upper() == "170" && Current_User_Upper() == "MVMXBLR")
        {
            Ice_Id = "MOVEMAX123";
        }
        else if (COMPANYID_Upper() == "284" && Current_User_Upper() == "SUPERSTARTUT")
        {
            Ice_Id = "SUPERSTARTUT";
        }
        else if (COMPANYID_Upper() == "420" && Current_User_Upper() == "AJAY")
        {
            Ice_Id = "JAIPURSSS";
        }
        else if (COMPANYID_Upper() == "188" && (Current_User_Upper() == "KSQUAREMUM1" || Current_User_Upper() == "KSQUAREMUM"))
        {
            Ice_Id = "KSQUAREMUM";
        }

        else if (COMPANYID_Upper() == "194" && Current_User_Upper() == "OMFREIGHTGOA")
        {
            Ice_Id = "OMFREIGHTGOA";
        }
        else if (COMPANYID_Upper() == "207" && (Current_User_Upper() == "VEERU" || Current_User_Upper() == "SHIFTCO2"))
        {
            Ice_Id = "SHIFTCOSHIPMAASEA"; // Changed by Sathish on 09May2020 with Palani
        }
        //else if (COMPANYID_Upper() == "236" && Current_User_Upper() == "SHISLAND1")
        //{
        //    Ice_Id = "ISLAND4445";
        //}

        else if (COMPANYID_Upper() == "236")
        {
            if (Current_User_Upper() == "SHISLAND" || Current_User_Upper() == "SHISLAND2")
            {
                Ice_Id = "ISLAND3334";
            }
            else if (Current_User_Upper() == "SHISLAND1")
            {
                Ice_Id = "ISLAND4445";
            }
            else
            {
                Ice_Id = HttpContext.Current.Session["ICEGATE_ID"].ToString();
            }

        }
        else if (COMPANYID_Upper() == "252" && Current_User_Upper() == "HARSHAMARINE1")
        {
            Ice_Id = "HARSHAMS";
        }
        else if (COMPANYID_Upper() == "286" && (Current_User_Upper() == "TIRUPUR" || Current_User_Upper() == "TIRUPUR2"))
        {
            Ice_Id = "ABSCOTPR";
        }
        else if (COMPANYID_Upper() == "295")
        {
            Ice_Id = "KAMALMCA1981";
        }
        else if (COMPANYID_Upper() == "459" && Current_User_Upper() == "TRANSMARINELOG")
        {
            Ice_Id = "TRANSMARINELOG";
        }


        //else if (COMPANYID_Upper() == "295")
        //{
        //    Ice_Id = "BSMLOGIIMPMAA";
        //}
        else if (COMPANYID_Upper() == "510")
        {
            if (Current_User_Upper() == "USER5" || Current_User_Upper() == "USER6" || Current_User_Upper() == "USER7" || Current_User_Upper() == "USER8" || Current_User_Upper() == "USER9" || Current_User_Upper() == "USER18" || Current_User_Upper() == "USER19" || Current_User_Upper() == "RTS")
            {
                Ice_Id = "TOPSWAAIR1";
            }
            else if (Current_User_Upper() == "USER10" || Current_User_Upper() == "USER11" || Current_User_Upper() == "USER12" || Current_User_Upper() == "USER13" || Current_User_Upper() == "USER14" || Current_User_Upper() == "RTS")
            {
                Ice_Id = "TOPSWAEXPORT";
            }
        }
        else if (COMPANYID_Upper() == "576" && (Current_User_Upper() == "BALAM" || Current_User_Upper() == "VIKAS"))
        {
            Ice_Id = "DAYAKRISHAN";
        }
        else if (COMPANYID_Upper() == "612" && Current_User_Upper() == "PARTH2")
        {
            //Ice_Id = "YASHMUNKDL";
            Ice_Id = "SRNKMUNDRA";
        }
        else if (COMPANYID_Upper() == "660")//PREMJI KANJI MASANI PRIVATE LIMITED
        {
            if (Current_User_Upper() == "PKMPL1" || Current_User_Upper() == "PKMPL2")
            {
                Ice_Id = "PKMPLGROUP";
            }
            else if (Current_User_Upper() == "PKMPL3" || Current_User_Upper() == "PKMPL4")
            {
                Ice_Id = "PKMPL_TM";
            }

        }
        else if (COMPANYID_Upper() == "664" && (Current_User_Upper() == "ADMIN1" || Current_User_Upper() == "JAGADEESH"))
        {
            Ice_Id = "UNIVERSALBLR";
        }
        else if (COMPANYID_Upper() == "665")
        {
            Ice_Id = "DSAPLIMP33";
        }
        else if (COMPANYID_Upper() == "719" && Current_User_Upper() == "ACMMUNDOC")
        {
            Ice_Id = "ACMMUNDOC";
        }
        else if (COMPANYID_Upper() == "752")//RYAL LOGISTICS
        {
            if (Current_User_Upper() == "PRASHANT.S" || Current_User_Upper() == "YOGITA.N")
            {
                Ice_Id = "RYALLOGAIR";
            }
            else if (Current_User_Upper() == "KISHOR.K")
            {
                Ice_Id = "RYALIMP2018";
            }
            else if (Current_User_Upper() == "RAJESHREE.S")
            {
                Ice_Id = "RYALLOGSEA";
            }
            else if (Current_User_Upper() == "KIRU.R" || Current_User_Upper() == "RYAL_MAA")
            {
                Ice_Id = "RYALLOG2018";
            }
            else if (Current_User_Upper() == "KALPESH.D")
            {
                Ice_Id = "RYALAMDOFF";
            }
            else if (Current_User_Upper() == "SHWETA.M")
            {
                Ice_Id = "RYALLOGSEA1";
            }
            else if (Current_User_Upper() == "PATRIS.D")
            {
                Ice_Id = "RYALLOGIMP";
            }
            else if (Current_User_Upper() == "RLPLSEA")
            {
                //Ice_Id = "RLPLSEA2022";
                Ice_Id = "RLPLSEA2023";
            }
            else if (Current_User_Upper() == "RAJESHRIRLPL")
            {
                Ice_Id = "RYALLOGPL";
            }
            else
            {
                Ice_Id = "RYALLOG2016";
            }
        }
        else if (COMPANYID_Upper() == "804" && Current_User_Upper() == "PORTAGE3")
        {
            Ice_Id = "17082234096890";
        }

        else if (COMPANYID_Upper() == "880")//EMM GEE SHIPPING
        {
            if (Current_User_Upper() == "MGEDIMBD")
            {
                Ice_Id = "MGEDIMBD";
            }
            else if (Current_User_Upper() == "MGSHIPPINGMBD" || Current_User_Upper() == "EMMGEEEDI")
            {
                Ice_Id = "EMMGEEEDI";
            }
            else if (Current_User_Upper() == "EDIMORADABAD" || Current_User_Upper() == "EMMGEEMBD")
            {
                Ice_Id = "EDIMORADABAD";
            }
            else if (Current_User_Upper() == "ICODE")
            {
                Ice_Id = "ICODE";
            }
            else
            {
                Ice_Id = "MGEDIMBD";
            }
        }
        else if (COMPANYID_Upper() == "1039" && (Current_User_Upper() == "VETRIIMPEXDELHI" || Current_User_Upper() == "VETRIIMPEXDELHI2" || Current_User_Upper() == "VETRIIMPEXDELHI3"))
        {
            Ice_Id = "CHANDRAN";
        }
        else if (COMPANYID_Upper() == "1110" && Current_User_Upper() == "SUNSHIP2")
        {
            Ice_Id = "SUNSHIPLOG";
        }
        else if (COMPANYID_Upper() == "1120")
        {
            Ice_Id = "KRISHYALLP999";
        }
        else if (COMPANYID_Upper() == "1135" && Current_User_Upper() == "TUTICORIN")
        {
            Ice_Id = "OLSCFTUTI";
        }
        else if (COMPANYID_Upper() == "1164")
        {
            Ice_Id = "CHAKIATCOCHIN2";
        }
        else if (COMPANYID_Upper() == "1215" && Current_User_Upper() == "VBSPLMAA")
        {
            Ice_Id = "VBSPLMAA";
        }
        else if (COMPANYID_Upper() == "1207" && Current_User_Upper() == "VASANTHAMCSTRZ")
        {
            Ice_Id = "VASANTHAMCSTRZ";
        }
        else if (COMPANYID_Upper() == "1240" && Current_User_Upper() == "SKYWAYS3")
        {
            Ice_Id = "SKYWAYSIMP";
        }
        else if (COMPANYID_Upper() == "1545" && Current_User_Upper() == "SUNFREIGHT1")
        {
            Ice_Id = "SUNFREIGHT2018";
        }
        else if (COMPANYID_Upper() == "1572" && (Current_User_Upper() == "PARAMASIVAN" || Current_User_Upper() == "SUYAMBU" || Current_User_Upper() == "MANICKAM" || Current_User_Upper() == "NAMBI" || Current_User_Upper() == "MOHAN" || Current_User_Upper() == "EBAN"))
        {
            Ice_Id = "AMAZERTRANS";
        }
        else if (COMPANYID_Upper() == "2002" && Current_User_Upper() == "HITECH2008")
        {
            Ice_Id = "HITECHIEC";
        }

        else
        {
            Ice_Id = HttpContext.Current.Session["ICEGATE_ID"].ToString();
        }
        return Ice_Id;
    }

    public static string Get_EXP_Icegate_Id(string Mode)
    {
        string Ice_Id = string.Empty;

        if (COMPANYID_Upper() == "132")
        {
            if (Current_User_Upper() == "SHRINATHSHIP" || Current_User_Upper() == "SSALSHAZIRA")
            {
                Ice_Id = "SHRINATHSHIP";
            }
            else if (Current_User_Upper() == "SHRINATH7")
            {
                Ice_Id = "SHRINATHSHIP1";
            }
            else
            {
                Ice_Id = HttpContext.Current.Session["ICEGATE_ID"].ToString();
            }
        }
        else if (COMPANYID_Upper() == "146")
        {          
            if (Current_User_Upper() == "BWC2")
            {
                Ice_Id = "BWCLOGMAAG";
            }
            else if (Current_User_Upper() == "OEM")
            {
                Ice_Id = "BWCLOGMAA";
            }
        }
        else if (COMPANYID_Upper() == "151" && Current_User_Upper() == "FAIRMACSMAA3")
        {
            Ice_Id = "FAIRMACSSEA2";
        }
        else if (COMPANYID_Upper() == "170" && Current_User_Upper() == "MVMXBLR")
        {
            Ice_Id = "MOVEMAX123";
        }
        else if (COMPANYID_Upper() == "203" && Mode == "Air")
        {
            Ice_Id = "NEINBLR2";
        }
        else if (COMPANYID_Upper() == "207" && (Current_User_Upper() == "VEERU" || Current_User_Upper() == "SHIFTCO2"))
        {
            Ice_Id = "SHIFTCOSHIPMAASEA"; // Changed by Sathish on 09May2020 with Palani
        }
        else if (COMPANYID_Upper() == "284" && Current_User_Upper() == "SUPERSTARTUT")
        {
            Ice_Id = "SUPERSTARTUT";
        }
        else if (COMPANYID_Upper() == "295")
        {
            //Ice_Id = "KAMALMBA1981";
            Ice_Id = "KAMALMCA1981";
        }
        else if (COMPANYID_Upper() == "420" && Current_User_Upper() == "AJAY")
        {
            Ice_Id = "JAIPURSSS";
        }
        else if (COMPANYID_Upper() == "382" )
        {
            Ice_Id = "ACFAMAAA";
        }
        else if (COMPANYID_Upper() == "188" && (Current_User_Upper() == "KSQUAREMUM1" || Current_User_Upper() == "KSQUAREMUM"))
        {
            Ice_Id = "KSQUAREMUM";
        }
        else if (COMPANYID_Upper() == "194" && Current_User_Upper() == "OMFREIGHTGOA")
        {
            Ice_Id = "OMFREIGHTGOA";
        }
        //else if (COMPANYID_Upper() == "236" && Current_User_Upper() == "SHISLAND1")
        //{
        //    Ice_Id = "ISLAND4445";
        //}

        else if (COMPANYID_Upper() == "236")
        {
            if (Current_User_Upper() == "SHISLAND" || Current_User_Upper() == "SHISLAND2")
            {
                Ice_Id = "ISLAND3334";
            }
            else if (Current_User_Upper() == "SHISLAND1")
            {
                Ice_Id = "ISLAND4445";
            }
            else
            {
                Ice_Id = HttpContext.Current.Session["ICEGATE_ID"].ToString();
            }

        }
        else if (COMPANYID_Upper() == "252" && Current_User_Upper() == "HARSHAMARINE1")
        {
            Ice_Id = "HARSHAMS";
        }
        else if (COMPANYID_Upper() == "286" && (Current_User_Upper() == "TIRUPUR" || Current_User_Upper() == "TIRUPUR2"))
        {
            Ice_Id = "ABSCOTPR";
        }
        else if (COMPANYID_Upper() == "480" && (Current_User_Upper() == "BHASKER" || Current_User_Upper() == "PRIYANKA" || Current_User_Upper() == "USER12" || Current_User_Upper() == "USER13" || Current_User_Upper() == "USER14" || Current_User_Upper() == "USER15" || Current_User_Upper() == "USER16"))
        {
            Ice_Id = "SANCOJAFFER";
        }
        else if (COMPANYID_Upper() == "459" && Current_User_Upper() == "TRANSMARINELOG")
        {
            Ice_Id = "TRANSMARINELOG";
        }

        else if (COMPANYID_Upper() == "510" && (Current_User_Upper() == "USER5" || Current_User_Upper() == "USER6" || Current_User_Upper() == "USER7" || Current_User_Upper() == "USER8" || Current_User_Upper() == "USER9" || Current_User_Upper() == "USER10" || Current_User_Upper() == "USER11" || Current_User_Upper() == "USER12" || Current_User_Upper() == "USER13" || Current_User_Upper() == "USER14"))
        {
            Ice_Id = "TOPSWAAIR1";
        }
        else if (COMPANYID_Upper() == "545")
        {
            Ice_Id = "SEASHELL";
        }
        else if (COMPANYID_Upper() == "576" && (Current_User_Upper() == "BALAM" || Current_User_Upper() == "VIKAS"))
        {
            Ice_Id = "DAYAKRISHAN";
        }
        else if (COMPANYID_Upper() == "612" && Current_User_Upper() == "PARTH2")
        {
            //Ice_Id = "YASHMUNKDL";
            Ice_Id = "SRNKMUNDRA";
        }
        else if (COMPANYID_Upper() == "660")//PREMJI KANJI MASANI PRIVATE LIMITED
        {
            if (Current_User_Upper() == "PKMPL1" || Current_User_Upper() == "PKMPL2")
            {
                Ice_Id = "PKMPLGROUP";
            }
            else if (Current_User_Upper() == "PKMPL3" || Current_User_Upper() == "PKMPL4")
            {
                Ice_Id = "PKMPL_TM";
            }           
            
        }
        else if (COMPANYID_Upper() == "664" && (Current_User_Upper() == "ADMIN1" || Current_User_Upper() == "JAGADEESH"))
        {
            Ice_Id = "UNIVERSALBLR";
        }
        else if (COMPANYID_Upper() == "686")
        {
            Ice_Id = "CHASLIIMP";
        }
        else if (COMPANYID_Upper() == "719" && Current_User_Upper() == "ACMMUNDOC")
        {
            Ice_Id = "ACMMUNDOC";
        }
        else if (COMPANYID_Upper() == "744" && Current_User_Upper() == "SUNEXP")
        {
            //Ice_Id = "SGLCHA2017";
            Ice_Id = "SUNGLOBAL2000";
        }
        else if (COMPANYID_Upper() == "752")//RYAL LOGISTICS
        {
            if (Current_User_Upper() == "PRASHANT.S" || Current_User_Upper() == "YOGITA.N")
            {
                Ice_Id = "RYALLOGAIR";
            }
            else if (Current_User_Upper() == "PATRIS.D" || Current_User_Upper() == "KISHOR.K")
            {
                Ice_Id = "RYALIMP2018";
            }
            else if (Current_User_Upper() == "RAJESHREE.S")
            {
                Ice_Id = "RYALLOGSEA";
            }
            else if (Current_User_Upper() == "KIRU.R" || Current_User_Upper() == "RYAL_MAA")
            {
                Ice_Id = "RYALLOG2018";
            }
            else if (Current_User_Upper() == "KALPESH.D")
            {
                Ice_Id = "RYALAMDOFF";
            }
            else if (Current_User_Upper() == "SHWETA.M")
            {
                Ice_Id = "RYALLOGSEA1";
            }
            else if (Current_User_Upper() == "PATRIS.D")
            {
                Ice_Id = "RYALLOGIMP";
            }
            else if (Current_User_Upper() == "RLPLSEA")
            {
                //Ice_Id = "RLPLSEA2022";
                Ice_Id = "RLPLSEA2023";
            }
            else if (Current_User_Upper() == "RAJESHRIRLPL")
            {
                Ice_Id = "RYALLOGPL";
            }
            else
            {
                Ice_Id = "RYALLOG2016";
            }
        }
        else if (COMPANYID_Upper() == "804" && Current_User_Upper() == "PORTAGE3")
        {
            Ice_Id = "17082234096890";
        }
        else if (COMPANYID_Upper() == "880")//EMM GEE SHIPPING
        {
            if (Current_User_Upper() == "MGEDIMBD")
            {
                Ice_Id = "MGEDIMBD";
            }
            else if (Current_User_Upper() == "MGSHIPPINGMBD" || Current_User_Upper() == "EMMGEEEDI")
            {
                Ice_Id = "EMMGEEEDI";
            }
            else if (Current_User_Upper() == "EDIMORADABAD" || Current_User_Upper() == "EMMGEEMBD")
            {
                Ice_Id = "EDIMORADABAD";
            }
            else if (Current_User_Upper() == "ICODE")
            {
                Ice_Id = "ICODE";
            }
            else
            {
                Ice_Id = "MGEDIMBD";
            }
        }

        else if (COMPANYID_Upper() == "1039" && (Current_User_Upper() == "VETRIIMPEXDELHI" || Current_User_Upper() == "VETRIIMPEXDELHI2" || Current_User_Upper() == "VETRIIMPEXDELHI3"))
        {
            Ice_Id = "CHANDRAN";
        }
        else if (COMPANYID_Upper() == "1057" && (Current_Branch() == "ACC, Coiambatore" || Current_Branch() == "ICD, Irugur" || Current_Branch() == "CusHouse, Tuticorin" || Current_Branch() == "ICD, TUTICORIN"))
        {
            Ice_Id = "TRANSGLOBALTUT";
        }
        else if (COMPANYID_Upper() == "1110" && Current_User_Upper() == "SUNSHIP2")
        {
            Ice_Id = "SUNSHIPLOG";
        }
        else if (COMPANYID_Upper() == "1120")
        {
            Ice_Id = "KRISHYATUTLLP";
        }
        else if (COMPANYID_Upper() == "1175")
        {
            Ice_Id = "KRISHYATUTLLP";
        }
        else if (COMPANYID_Upper() == "1207" && Current_User_Upper() == "VASANTHAMCSTRZ")
        {
            Ice_Id = "VASANTHAMCSTRZ";
        }
        else if (COMPANYID_Upper() == "1240" && Current_User_Upper() == "SKYWAYS3")
        {
            Ice_Id = "SKYWAYSIMP";
        }
        else if (COMPANYID_Upper() == "1545")
        {          
            if (Current_User_Upper() == "SUNFREIGHT1")
            {
                Ice_Id = "SUNFREIGHT2018";
            }
            else
            {
                Ice_Id = HttpContext.Current.Session["ICEGATE_ID"].ToString();
            }
        }
        else if (COMPANYID_Upper() == "1572" && (Current_User_Upper() == "PARAMASIVAN" || Current_User_Upper() == "SUYAMBU" || Current_User_Upper() == "MANICKAM" || Current_User_Upper() == "NAMBI" || Current_User_Upper() == "MOHAN" || Current_User_Upper() == "EBAN"))
        {
            Ice_Id = "AMAZERTRANS";
        }
        else if (COMPANYID_Upper() == "2002" && Current_User_Upper() == "HITECH2008")
        {
            Ice_Id = "HITECHIEC";
        }
        else
        {
            Ice_Id = HttpContext.Current.Session["ICEGATE_ID"].ToString();
        }
        return Ice_Id;
    }

    public static string GetUser_lock(string currentuser)
    {
        string JOB_RELEASE = string.Empty;
        if (HttpContext.Current.Session["USER_JOB_LOCK"].ToString() == "Yes")
        {
            if (currentuser.ToUpper() != HttpContext.Current.Session["JOB_USER"].ToString().ToUpper())
            {
                if (HttpContext.Current.Session["JOB_RELEASE"] != null && HttpContext.Current.Session["JOB_RELEASE"] != "")
                {
                    JOB_RELEASE = HttpContext.Current.Session["JOB_RELEASE"].ToString();
                }
            }
        }
        return JOB_RELEASE;
    }

    /* ****************************************/

    //public static DateTime DATE_FORMAT(string Dt)
    //{
    //    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    //    return DateTime.Parse(Dt, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
    //}
    public static DataSet Get_Dataset(string SP_name, SqlParameter[] param)
    {
        DataSet ds = new DataSet();
        ds = SqlHelper.ExecuteDataset(Connection.GetConnection(), CommandType.StoredProcedure, SP_name, param);
        return ds;
    }
    public static void Error_Msg(string Err_Msg)
    {
        ErrorLogs er = new ErrorLogs();
        er.makeLog(Err_Msg);
    }
    public static string Date(string dt)
    {
       string[] arr = new string[] { };
       if (dt != string.Empty && dt != null)
       {
           arr = dt.Split('/');
           dt = arr[1] + '/' + arr[0] + '/' + arr[2];
       }
       return dt;
    }
    

    public static DateTime DATE_FORMAT(string Dt)
    {
        IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
        if (Dt == string.Empty || Dt == null)
        {
            return DateTime.Parse("01/01/1900", provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
        }
        else
        {

            return DateTime.Parse(Dt, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
        }
    }

    public static string Search_Date(string Dt)
    {
        string[] arr = new string[] { };
        string val = string.Empty;

        if (Dt != string.Empty && Dt != null)
        {
            arr = Dt.Split('/');
            val = arr[1] + '/' + arr[0] + '/' + arr[2];
        }
        return val;
    }
    public static string Get_Tr_Mode()
    {
        string TRANS_MODE = HttpContext.Current.Session["CUSTOMHOUSE_TRANSPORT_MODE"].ToString();
        if (TRANS_MODE == "A")
        {
            TRANS_MODE = "Air";
        }
        else if (TRANS_MODE == "S")
        {
            TRANS_MODE = "Sea";
        }
        else if (TRANS_MODE == "L")
        {
            TRANS_MODE = "Land";
        }

        return TRANS_MODE;
    }


    public static string Get_IMP_CHA_NO()
    {
        string CHA_NO = "";

        if (COMPANYID_Upper() == "612" && Current_User_Upper() == "PARTH2")
        {
            //CHA_NO = "AABFY8302NCH002";
            //CHA_NO = "AAZCS0568DCH003";
            //CHA_NO = "AAEFA7790DCH006";
            CHA_NO = "AAEFA7790DCH007";
            
        }
        else if (COMPANYID_Upper() == "664" && (Current_User_Upper() == "ADMIN1" || Current_User_Upper() == "JAGADEESH" || Current_User_Upper() == "ACCOUNTS" || Current_User_Upper() == "UNIVERSAL1"))
        {
            CHA_NO = "AAEFU6265HCH001";
        }
        else if (COMPANYID_Upper() == "670" && (Current_User_Upper() == "CIRCLECARGO"))
        {
            CHA_NO = "AAACC1025CCH001";
        }
        else if (COMPANYID_Upper() == "677" && (Current_User_Upper() == "NEELKANTHSHIPPING" || Current_User_Upper() == "NEELKANTHSHIPPING1"))
        {
            CHA_NO = "AIAPB4261ACH001";
        }
        else if (COMPANYID_Upper() == "677" && (Current_User_Upper() == "CARGOEASE" || Current_User_Upper() == "CARGOEASE1" || Current_User_Upper() == "CARGOEASE2" || Current_User_Upper() == "CARGOEASE3"))
        {
            CHA_NO = "AAGCC1934NCH001";
        }
        else if (COMPANYID_Upper() == "752" && (Current_User_Upper() == "RLPLSEA" || Current_User_Upper() == "RAJESHRIRLPL" || Current_User_Upper() == "PATRIS.D" || Current_User_Upper() == "KISHOR.K"))
        {
            CHA_NO = "AAACR6636ACH001";
        }
        else if (COMPANYID_Upper() == "804" && Current_User_Upper() == "PORTAGE3")
        {
            CHA_NO = "AFMPB7316MCH001";
        }
        //else if (COMPANYID_Upper() == "1057" && Current_User_Upper() == "WWLNEW")
        //{
        //    CHA_NO = "AAACW3529PCH001";
        //}
        else if (COMPANYID_Upper() == "1108" && Current_User_Upper() == "DJSDELHI")
        {
            CHA_NO = "AAECD6322RCH009";
        }
        else if (COMPANYID_Upper() == "1217" && Current_User_Upper() == "ECAPL")
        {
            CHA_NO = "AAACE5335MCH001";
        }
        else if (COMPANYID_Upper() == "1572" && (Current_User_Upper() == "PARAMASIVAN" || Current_User_Upper() == "SUYAMBU" || Current_User_Upper() == "MANICKAM" || Current_User_Upper() == "NAMBI" || Current_User_Upper() == "MOHAN" || Current_User_Upper() == "EBAN"))
        {
            CHA_NO = "AAHCA8580HCH001";
        }

        else if (COMPANYID_Upper() == "2002" && Current_User_Upper() == "HITECH2008")
        {
            CHA_NO = "SELFSUBMITCH001";
        }
        else if (COMPANYID_Upper() == "2062" && Current_User_Upper() == "OPS")
        {
            CHA_NO = "ACBPT1842JCH002";
        }
        else if (COMPANYID_Upper() == "2242" && Current_User_Upper() == "GANESHAM2")
        {
            CHA_NO = "ANMPS9092HCH002";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "CAPIMPORT")
        {
            CHA_NO = "AABCC6364MCH001";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "CAPEXPORT")
        {
            CHA_NO = "AABCC6364MCH001";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "SRIVALLIMPORT")
        {
            CHA_NO = "AAPCS7844GCH008";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "SRIVALLIEXPORT")
        {
            CHA_NO = "AAPCS7844GCH008";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "SUNIMPEX")
        {
            CHA_NO = "AASCS0664BCH001";
        }
        else if (COMPANYID_Upper() == "2659" && Current_User_Upper() == "MILINDCIRCLE")
        {
            CHA_NO = "AABCC6364MCH001";
        }
        //else if (COMPANYID_Upper() == "2266" && (Current_User_Upper() == "ASHAPURA7" || Current_User_Upper() == "ASHAPURA8" || Current_User_Upper() == "ASHAPURA9" || Current_User_Upper() == "ASHAPURA10"))
        //{
        //    CHA_NO = "AADCA4633MCH001";
        //}
        else
        {
            CHA_NO = HttpContext.Current.Session["CHA_NO"].ToString();
        }
        return CHA_NO;
    }

    public static string Get_IMP_CHA_NAME()
    {
        string CHA_NAME = "";

        if (COMPANYID_Upper() == "612" && Current_User_Upper() == "PARTH2")
        {
            //CHA_NAME = "YASH SHIPPING SERVICES";
            //CHA_NAME = "SRNK LOGISTICS PVT.LTD.";
            CHA_NAME = "ACCESS WORLDWIDE CARGO";
        }
        else if (COMPANYID_Upper() == "664" && (Current_User_Upper() == "ADMIN1" || Current_User_Upper() == "JAGADEESH" || Current_User_Upper() == "ACCOUNTS" || Current_User_Upper() == "UNIVERSAL1"))
        {
            CHA_NAME = "M/s Universal Clearing & Forwarding";
        }
        else if (COMPANYID_Upper() == "670" && Current_User_Upper() == "CIRCLECARGO")
        {
            CHA_NAME = "CIRCLE CARGO PVT LTD";
        }
        else if (COMPANYID_Upper() == "677" && (Current_User_Upper() == "NEELKANTHSHIPPING" || Current_User_Upper() == "NEELKANTHSHIPPING1"))
        {
            CHA_NAME = "NEELKANTH SHIPPING";
        }
        else if (COMPANYID_Upper() == "677" && (Current_User_Upper() == "CARGOEASE" || Current_User_Upper() == "CARGOEASE1" || Current_User_Upper() == "CARGOEASE2" || Current_User_Upper() == "CARGOEASE3"))
        {
            CHA_NAME = "CARGO EASE PVT LTD.";
        }
        else if (COMPANYID_Upper() == "752" && (Current_User_Upper() == "RLPLSEA" || Current_User_Upper() == "RAJESHRIRLPL" || Current_User_Upper() == "PATRIS.D" || Current_User_Upper() == "KISHOR.K"))
        {
            CHA_NAME = "RYAL LOGISTICS PVT LTD";
        }
        else if (COMPANYID_Upper() == "804" && Current_User_Upper() == "PORTAGE3")
        {
            CHA_NAME = "SONY LOGISTICS CENTRE";
        }
        //else if (COMPANYID_Upper() == "1057" && Current_User_Upper() == "WWLNEW")
        //{
        //    CHA_NAME = "WORLDWIDE LOGISTICS INDIA PRIVATE LIMITED";
        //}
        else if (COMPANYID_Upper() == "1217" && Current_User_Upper() == "ECAPL")
        {
            CHA_NAME = "EASTERN CLEARING AGENCY PVT LTD";
        }
        else if (COMPANYID_Upper() == "1572" && (Current_User_Upper() == "PARAMASIVAN" || Current_User_Upper() == "SUYAMBU" || Current_User_Upper() == "MANICKAM" || Current_User_Upper() == "NAMBI" || Current_User_Upper() == "MOHAN" || Current_User_Upper() == "EBAN"))
        {
            CHA_NAME = "AMAZERTRANS CARGO SERVICES PRIVATE LIMITED";
        }
        else if (COMPANYID_Upper() == "1701")
        {
            CHA_NAME = "M/s. DIAMOND CARGO CARE";
        }
        else if (COMPANYID_Upper() == "2002" && Current_User_Upper() == "HITECH2008")
        {
            CHA_NAME = "HITECH ARAI PRIVATE LIMITED,PRIVATE BONDED WAREHOUSE";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "CAPIMPORT")
        {
            //CHA_NAME = "RAJ Clearing Agency";
            CHA_NAME = "CAPRICORN LOGISTICS PVT.LTD";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "CAPEXPORT")
        {
            //CHA_NAME = "RAJ Clearing Agency";
            CHA_NAME = "CAPRICORN LOGISTICS PVT.LTD";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "SRIVALLIMPORT")
        {
            CHA_NAME = "SRIVALLI SHIPPING& TRANSPORT PVT. LTD.";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "SRIVALLIEXPORT")
        {
            CHA_NAME = "SRIVALLI SHIPPING& TRANSPORT PVT. LTD.";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "SUNIMPEX")
        {
            CHA_NAME = "SUNIMPEX CLEARING AND SHIPPING AGENCY PVT LTD";
        }
        else if (COMPANYID_Upper() == "2659" && Current_User_Upper() == "MILINDCIRCLE")
        {
            CHA_NAME = "CAPRICORN LOGISTICS PVT LTD";
        }
        //else if (COMPANYID_Upper() == "2266" && (Current_User_Upper() == "ASHAPURA7" || Current_User_Upper() == "ASHAPURA8" || Current_User_Upper() == "ASHAPURA9" || Current_User_Upper() == "ASHAPURA10"))
        //{
        //    CHA_NAME = "ASHAPURA LOGISTICS LIMITED";
        //}
        else
        {
            CHA_NAME = HttpContext.Current.Session["CHA_NAME"].ToString();
        }
        return CHA_NAME;
    }
    
    public static string Get_IMP_CHA_ADDRESS()
    {
        string CHA_ADDRESS = "";

        if (COMPANYID_Upper() == "612" && Current_User_Upper() == "PARTH2")
        {
            CHA_ADDRESS = "GANDHIDHAM KUTCH,";
        }
        else if (COMPANYID_Upper() == "664" && (Current_User_Upper() == "ADMIN1" || Current_User_Upper() == "JAGADEESH" || Current_User_Upper() == "ACCOUNTS" || Current_User_Upper() == "UNIVERSAL1"))
        {
            CHA_ADDRESS = "No.182, E Block, Cargo Village,";
        }
        else if (COMPANYID_Upper() == "670" && Current_User_Upper() == "CIRCLECARGO")
        {
            CHA_ADDRESS = "K-858, MATA CHOWK,";
        }
        else if (COMPANYID_Upper() == "677" && (Current_User_Upper() == "NEELKANTHSHIPPING" || Current_User_Upper() == "NEELKANTHSHIPPING1"))
        {
            CHA_ADDRESS = "RAJDEEP COMPLEX,";
        }
        else if (COMPANYID_Upper() == "677" && HttpContext.Current.Session["GroupName"].ToString() == "Ahemdabad" && (Current_User_Upper() == "CARGOEASE" || Current_User_Upper() == "CARGOEASE1" || Current_User_Upper() == "CARGOEASE2" || Current_User_Upper() == "CARGOEASE3"))
        {
            CHA_ADDRESS = "Office No : 110, 1st Floor, Plot No 9,10";
        }
        else if (COMPANYID_Upper() == "677" && HttpContext.Current.Session["GroupName"].ToString() == "Mumbai" && (Current_User_Upper() == "CARGOEASE" || Current_User_Upper() == "CARGOEASE1" || Current_User_Upper() == "CARGOEASE2" || Current_User_Upper() == "CARGOEASE3"))
        {
            CHA_ADDRESS = "Bungalow No 34,";
        }
        else if (COMPANYID_Upper() == "804" && Current_User_Upper() == "PORTAGE3")
        {
            CHA_ADDRESS = "4B-1805, DHEERAJ DREAM 4B CO-OP,";
        }
        //else if (COMPANYID_Upper() == "1057" && Current_User_Upper() == "WWLNEW")
        //{
        //    CHA_ADDRESS = "WWL Tower, No. C-10,";
        //}
        else if (COMPANYID_Upper() == "1217" && Current_User_Upper() == "ECAPL")
        {
            CHA_ADDRESS = "16";
        }
        else if (COMPANYID_Upper() == "1572" && (Current_User_Upper() == "PARAMASIVAN" || Current_User_Upper() == "SUYAMBU" || Current_User_Upper() == "MANICKAM" || Current_User_Upper() == "NAMBI" || Current_User_Upper() == "MOHAN" || Current_User_Upper() == "EBAN"))
        {
            CHA_ADDRESS = "NO.26C/5,FIRST STREET , ";
        }
        else if (COMPANYID_Upper() == "1701")
        {
            CHA_ADDRESS = "CB-385B, ";
        }

        else if (COMPANYID_Upper() == "2002" && Current_User_Upper() == "HITECH2008")
        {
            CHA_ADDRESS = "SHED NO.56,SIDCO,";
        }
        else if (COMPANYID_Upper() == "2062" && Current_User_Upper() == "OPS")
        {
            CHA_ADDRESS = "112,GROUND FLOOR,VINDHYA COMMERCIAL COMPLEX,";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "CAPIMPORT")
        {
            CHA_ADDRESS = "13/13 A, Keytuo Industrial Estate,";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "CAPEXPORT")
        {
            CHA_ADDRESS = "13/13 A, Keytuo Industrial Estate,";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "SRIVALLIMPORT")
        {
            CHA_ADDRESS = "D-401,Jayant Apartment";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "SRIVALLIEXPORT")
        {
            CHA_ADDRESS = "D-401,Jayant Apartment";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "SUNIMPEX")
        {
            CHA_ADDRESS = "501, Atlanta Tower, ";
        }
        else if (COMPANYID_Upper() == "2659" && Current_User_Upper() == "MILINDCIRCLE")
        {
            CHA_ADDRESS = "Arena House,Road No 12,";
        }
        else if (COMPANYID_Upper() == "752" && (Current_User_Upper() == "KISHOR.K"))
        {
            CHA_ADDRESS = "2ND FLOOR C WING, PRAMUKH PLAZA.";
        }
        //else if (COMPANYID_Upper() == "2266" && (Current_User_Upper() == "ASHAPURA7" || Current_User_Upper() == "ASHAPURA8" || Current_User_Upper() == "ASHAPURA9" || Current_User_Upper() == "ASHAPURA10"))
        //{
        //    CHA_ADDRESS = " No. 150, 4TH FLOOR, ";
        //}
        else
        {
            CHA_ADDRESS = HttpContext.Current.Session["CHA_ADDRESS"].ToString();
        }
        return CHA_ADDRESS;
    }

    public static string Get_IMP_CHA_ADDRESS1()
    {
        string CHA_ADDRESS1 = "";

        if (COMPANYID_Upper() == "612" && Current_User_Upper() == "PARTH2")
        {
            CHA_ADDRESS1 = "GUJARAT";
        }
        else if (COMPANYID_Upper() == "664" && (Current_User_Upper() == "ADMIN1" || Current_User_Upper() == "JAGADEESH" || Current_User_Upper() == "ACCOUNTS" || Current_User_Upper() == "UNIVERSAL1"))
        {
            CHA_ADDRESS1 = "KIAL Airport Devenahalli,";
        }
        else if (COMPANYID_Upper() == "670" && Current_User_Upper() == "CIRCLECARGO")
        {
            CHA_ADDRESS1 = "VASANT KUNJ ROAD, MAHIPALPUR,";
        }
        else if (COMPANYID_Upper() == "677" && (Current_User_Upper() == "NEELKANTHSHIPPING" || Current_User_Upper() == "NEELKANTHSHIPPING1"))
        {
            CHA_ADDRESS1 = "OFFICE NO. SF 06,";
        }
        else if (COMPANYID_Upper() == "677" && HttpContext.Current.Session["GroupName"].ToString() == "Ahemdabad" && (Current_User_Upper() == "CARGOEASE" || Current_User_Upper() == "CARGOEASE1" || Current_User_Upper() == "CARGOEASE2" || Current_User_Upper() == "CARGOEASE3"))
        {
            CHA_ADDRESS1 = "Survey No 54/1/3/1 Near Rasapir Circle,";
        }
        else if (COMPANYID_Upper() == "677" && HttpContext.Current.Session["GroupName"].ToString() == "Mumbai" && (Current_User_Upper() == "CARGOEASE" || Current_User_Upper() == "CARGOEASE1" || Current_User_Upper() == "CARGOEASE2" || Current_User_Upper() == "CARGOEASE3"))
        {
            CHA_ADDRESS1 = "Green field Bungalow society,";
        }
        else if (COMPANYID_Upper() == "804" && Current_User_Upper() == "PORTAGE3")
        {
            CHA_ADDRESS1 = "HSG SOC.LTD., L.B.S MARG";
        }
        //else if (COMPANYID_Upper() == "1057" && Current_User_Upper() == "WWLNEW")
        //{
        //    CHA_ADDRESS1 = "3rd Cross Street, Thiru Vi Ka Industrial Estate, ";
        //}
        else if (COMPANYID_Upper() == "1217" && Current_User_Upper() == "ECAPL")
        {
            CHA_ADDRESS1 = "INDIA EXCHANGE PLACE";
        }
        else if (COMPANYID_Upper() == "1572" && (Current_User_Upper() == "PARAMASIVAN" || Current_User_Upper() == "SUYAMBU" || Current_User_Upper() == "MANICKAM" || Current_User_Upper() == "NAMBI" || Current_User_Upper() == "MOHAN" || Current_User_Upper() == "EBAN"))
        {
            CHA_ADDRESS1 = "PC ROAD WEST,KAMARAJ NAGAR,";
        }
        else if (COMPANYID_Upper() == "1701")
        {
            CHA_ADDRESS1 = "Office - 105 Ist Floor,";
        }
        else if (COMPANYID_Upper() == "2002" && Current_User_Upper() == "HITECH2008")
        {
            CHA_ADDRESS1 = "INDUSTRIAL ESTATE,KAPPALUR,";
        }
        else if (COMPANYID_Upper() == "2062" && Current_User_Upper() == "OPS")
        {
            CHA_ADDRESS1 = "PLOT 01,SECTOR 11, CBD BELAPUR,";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "CAPIMPORT")
        {
            CHA_ADDRESS1 = "220, Kondivita Road,";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "CAPEXPORT")
        {
            CHA_ADDRESS1 = "220, Kondivita Road,";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "SRIVALLIMPORT")
        {
            CHA_ADDRESS1 = "Near Sahar Cargo Complex";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "SRIVALLIEXPORT")
        {
            CHA_ADDRESS1 = "Near Sahar Cargo Complex";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "SUNIMPEX")
        {
            CHA_ADDRESS1 = "Sahar Road,";
        }
        else if (COMPANYID_Upper() == "2659" && Current_User_Upper() == "MILINDCIRCLE")
        {
            CHA_ADDRESS1 = "Marol MIDC Andheri East,";
        }
        else if (COMPANYID_Upper() == "752" && (Current_User_Upper() == "KISHOR.K"))
        {
            CHA_ADDRESS1 = "CARDINAL GRACIAS ROAD.";
        }
        //else if (COMPANYID_Upper() == "2266" && (Current_User_Upper() == "ASHAPURA7" || Current_User_Upper() == "ASHAPURA8" || Current_User_Upper() == "ASHAPURA9" || Current_User_Upper() == "ASHAPURA10"))
        //{
        //    CHA_ADDRESS1 = " A & B, M.M. COMPLEX, LINGHI CHETTY STREET,";
        //}
        else
        {
            CHA_ADDRESS1 = HttpContext.Current.Session["CHA_ADDRESS1"].ToString();
        }
        return CHA_ADDRESS1;
    }

    public static string Get_IMP_CHA_ADDRESS2()
    {
        string CHA_ADDRESS2 = "";

        if (COMPANYID_Upper() == "664" && (Current_User_Upper() == "ADMIN1" || Current_User_Upper() == "JAGADEESH" || Current_User_Upper() == "ACCOUNTS" || Current_User_Upper() == "UNIVERSAL1"))
        {
            CHA_ADDRESS2 = "Bengaluru";
        }
        else if (COMPANYID_Upper() == "670" && Current_User_Upper() == "CIRCLECARGO")
        {
            CHA_ADDRESS2 = "NEW, DELHI 110037";
        }
        else if (COMPANYID_Upper() == "677" && (Current_User_Upper() == "NEELKANTHSHIPPING" || Current_User_Upper() == "NEELKANTHSHIPPING1"))
        {
            CHA_ADDRESS2 = "PLOT NO. 15, SECTOR 9/A,";
        }
        else if (COMPANYID_Upper() == "677" && HttpContext.Current.Session["GroupName"].ToString() == "Ahemdabad" && (Current_User_Upper() == "CARGOEASE" || Current_User_Upper() == "CARGOEASE1" || Current_User_Upper() == "CARGOEASE2" || Current_User_Upper() == "CARGOEASE3"))
        {
            CHA_ADDRESS2 = "Maruti Corner 2 Dhrub, Gujarat";
        }
        else if (COMPANYID_Upper() == "677" && HttpContext.Current.Session["GroupName"].ToString() == "Mumbai" && (Current_User_Upper() == "CARGOEASE" || Current_User_Upper() == "CARGOEASE1" || Current_User_Upper() == "CARGOEASE2" || Current_User_Upper() == "CARGOEASE3"))
        {
            CHA_ADDRESS2 = "Padmavati Nagar, Virar west, VIRAR, PALGHAR";
        }
        else if (COMPANYID_Upper() == "804" && Current_User_Upper() == "PORTAGE3")
        {
            CHA_ADDRESS2 = "BHANDUP (WEST),";
        }
        //else if (COMPANYID_Upper() == "1057" && Current_User_Upper() == "WWLNEW")
        //{
        //    CHA_ADDRESS2 = "Guindy, Chennai ";
        //}
        else if (COMPANYID_Upper() == "1217" && Current_User_Upper() == "ECAPL")
        {
            CHA_ADDRESS2 = "KOLKATA";
        }
        else if (COMPANYID_Upper() == "1572" && (Current_User_Upper() == "PARAMASIVAN" || Current_User_Upper() == "SUYAMBU" || Current_User_Upper() == "MANICKAM" || Current_User_Upper() == "NAMBI" || Current_User_Upper() == "MOHAN" || Current_User_Upper() == "EBAN"))
        {
            CHA_ADDRESS2 = "TUTICORIN";
        }
        else if (COMPANYID_Upper() == "1701")
        {
            CHA_ADDRESS2 = "NARAINA Ring Road";
        }
        else if (COMPANYID_Upper() == "2002" && Current_User_Upper() == "HITECH2008")
        {
            CHA_ADDRESS2 = "MADURAI-";
        }
        else if (COMPANYID_Upper() == "2062" && Current_User_Upper() == "OPS")
        {
            CHA_ADDRESS2 = "NAVI MUMBAI -400614 MAHARASHTRA";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "CAPIMPORT")
        {
            CHA_ADDRESS2 = "Andheri(East)";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "CAPEXPORT")
        {
            CHA_ADDRESS2 = "Andheri(East)";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "SRIVALLIMPORT")
        {
            CHA_ADDRESS2 = "Andheri(East)";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "SRIVALLIEXPORT")
        {
            CHA_ADDRESS2 = "Andheri(East)";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "SUNIMPEX")
        {
            CHA_ADDRESS2 = "Nr Suba Hotel, ";
        }
        else if (COMPANYID_Upper() == "2659" && Current_User_Upper() == "MILINDCIRCLE")
        {
            CHA_ADDRESS2 = "Mumbai";
        }
        else if (COMPANYID_Upper() == "752" && (Current_User_Upper() == "KISHOR.K"))
        {
            CHA_ADDRESS2 = "ANDHERI EAST MUMBAI";
        }
        //else if (COMPANYID_Upper() == "2266" && (Current_User_Upper() == "ASHAPURA7" || Current_User_Upper() == "ASHAPURA8" || Current_User_Upper() == "ASHAPURA9" || Current_User_Upper() == "ASHAPURA10"))
        //{
        //    CHA_ADDRESS2 = "CHENNAI,";
        //}
        else
        {
            CHA_ADDRESS2 = HttpContext.Current.Session["CHA_ADDRESS2"].ToString();
        }
        return CHA_ADDRESS2;
    }

    public static string Get_IMP_CHA_ADDRESS3()
    {
        string CHA_ADDRESS3 = "";

        if (COMPANYID_Upper() == "664" && (Current_User_Upper() == "ADMIN1" || Current_User_Upper() == "JAGADEESH" || Current_User_Upper() == "ACCOUNTS" || Current_User_Upper() == "UNIVERSAL1"))
        {
            CHA_ADDRESS3 = "560300";
        }
        else if (COMPANYID_Upper() == "677" && (Current_User_Upper() == "NEELKANTHSHIPPING" || Current_User_Upper() == "NEELKANTHSHIPPING1"))
        {
            CHA_ADDRESS3 = "GANDHIDHDAM, 370201";
        }
        else if (COMPANYID_Upper() == "677" && HttpContext.Current.Session["GroupName"].ToString() == "Ahemdabad" && (Current_User_Upper() == "CARGOEASE" || Current_User_Upper() == "CARGOEASE1" || Current_User_Upper() == "CARGOEASE2" || Current_User_Upper() == "CARGOEASE3"))
        {
            CHA_ADDRESS3 = "Mundra - Kutch. Pin code 370405";
        }
        else if (COMPANYID_Upper() == "677" && HttpContext.Current.Session["GroupName"].ToString() == "Mumbai" && (Current_User_Upper() == "CARGOEASE" || Current_User_Upper() == "CARGOEASE1" || Current_User_Upper() == "CARGOEASE2" || Current_User_Upper() == "CARGOEASE3"))
        {
            CHA_ADDRESS3 = "MAHARASHTRA";
        }
        else if (COMPANYID_Upper() == "804" && Current_User_Upper() == "PORTAGE3")
        {
            CHA_ADDRESS3 = "MUMBAI - 400078";
        }
        //else if (COMPANYID_Upper() == "1057" && Current_User_Upper() == "WWLNEW")
        //{
        //    CHA_ADDRESS3 = "TAMILNADU 600 032 ";
        //}
        else if (COMPANYID_Upper() == "1217" && Current_User_Upper() == "ECAPL")
        {
            CHA_ADDRESS3 = "700 001";
        }
        else if (COMPANYID_Upper() == "1701")
        {
            CHA_ADDRESS3 = "110028";
        }
        else if (COMPANYID_Upper() == "2002" && Current_User_Upper() == "HITECH2008")
        {
            CHA_ADDRESS3 = "625008";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "CAPIMPORT")
        {
            CHA_ADDRESS3 = "Mumbai-400059 Maharashtra.";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "CAPEXPORT")
        {
            CHA_ADDRESS3 = "Mumbai-400059 Maharashtra.";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "SRIVALLIMPORT")
        {
            CHA_ADDRESS3 = "Mumbai-:400099";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "SRIVALLIEXPORT")
        {
            CHA_ADDRESS3 = "Mumbai-:400099";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "SUNIMPEX")
        {
            CHA_ADDRESS3 = "Andheri east";
        }
        else if (COMPANYID_Upper() == "2659" && Current_User_Upper() == "MILINDCIRCLE")
        {
            CHA_ADDRESS3 = "400069, India";
        }
        else if (COMPANYID_Upper() == "752" && (Current_User_Upper() == "KISHOR.K"))
        {
            CHA_ADDRESS3 = "400099";
        }
        //else if (COMPANYID_Upper() == "2266" && (Current_User_Upper() == "ASHAPURA7" || Current_User_Upper() == "ASHAPURA8" || Current_User_Upper() == "ASHAPURA9" || Current_User_Upper() == "ASHAPURA10"))
        //{
        //    CHA_ADDRESS3 = "TAMILNADU - 600001.";
        //}
        else
        {
            CHA_ADDRESS3 = HttpContext.Current.Session["CHA_ADDRESS3"].ToString();
        }
        return CHA_ADDRESS3;
    }



    public static string Get_EXP_CHA_NO()
    {
        string CHA_NO = "";
        if (COMPANYID_Upper() == "612" && Current_User_Upper() == "PARTH2")
        {
            //CHA_NO = "AABFY8302NCH002";
            //CHA_NO = "AAZCS0568DCH003";
            //CHA_NO = "AAEFA7790DCH006";
            CHA_NO = "AAEFA7790DCH007";
        }
        else if (COMPANYID_Upper() == "664" && (Current_User_Upper() == "ADMIN1" || Current_User_Upper() == "JAGADEESH" || Current_User_Upper() == "ACCOUNTS" || Current_User_Upper() == "UNIVERSAL1"))
        {
            CHA_NO = "AAEFU6265HCH001";
        }
        else if (COMPANYID_Upper() == "670" && (Current_User_Upper() == "CIRCLECARGO"))
        {
            CHA_NO = "AAACC1025CCH001";
        }
        else if (COMPANYID_Upper() == "677" && (Current_User_Upper() == "NEELKANTHSHIPPING" || Current_User_Upper() == "NEELKANTHSHIPPING1"))
        {
            CHA_NO = "AIAPB4261ACH001";
        }
        else if (COMPANYID_Upper() == "677" && (Current_User_Upper() == "CARGOEASE" || Current_User_Upper() == "CARGOEASE1" || Current_User_Upper() == "CARGOEASE2" || Current_User_Upper() == "CARGOEASE3"))
        {
            CHA_NO = "AAGCC1934NCH001";
        }
        else if (COMPANYID_Upper() == "752" && (Current_User_Upper() == "RLPLSEA" || Current_User_Upper() == "RAJESHRIRLPL" || Current_User_Upper() == "PATRIS.D" || Current_User_Upper() == "KISHOR.K"))
        {
            CHA_NO = "AAACR6636ACH001";
        }
        else if (COMPANYID_Upper() == "804" && Current_User_Upper() == "PORTAGE3")
        {
            CHA_NO = "AFMPB7316MCH001";
        }
        //else if (COMPANYID_Upper() == "1057" && Current_User_Upper() == "WWLNEW")
        //{
        //    CHA_NO = "AAACW3529PCH001";
        //}
        else if (COMPANYID_Upper() == "1108" && Current_User_Upper() == "DJSDELHI")
        {
            CHA_NO = "AAECD6322RCH009";
        }
        else if (COMPANYID_Upper() == "1572" && (Current_User_Upper() == "PARAMASIVAN" || Current_User_Upper() == "SUYAMBU" || Current_User_Upper() == "MANICKAM" || Current_User_Upper() == "NAMBI" || Current_User_Upper() == "MOHAN" || Current_User_Upper() == "EBAN"))
        {
            CHA_NO = "AAHCA8580HCH001";
        }
        else if (COMPANYID_Upper() == "2002" && Current_User_Upper() == "HITECH2008")
        {
            CHA_NO = "SELFSUBMITCH001";
        }
        else if (COMPANYID_Upper() == "2062" && Current_User_Upper() == "OPS")
        {
            CHA_NO = "ACBPT1842JCH002";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "CAPIMPORT")
        {
            CHA_NO = "AAIFR0443ECH001";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "CAPEXPORT")
        {
            CHA_NO = "AABCC6364MCH001";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "SRIVALLIMPORT")
        {
            CHA_NO = "AABCC6364MCH001";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "SRIVALLIEXPORT")
        {
            CHA_NO = "AAPCS7844GCH008";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "SUNIMPEX")
        {
            CHA_NO = "AASCS0664BCH001";
        }
        else if (COMPANYID_Upper() == "2659" && Current_User_Upper() == "MILINDCIRCLE")
        {
            CHA_NO = "AABCC6364MCH001";
        }
        //else if (COMPANYID_Upper() == "2266" && (Current_User_Upper() == "ASHAPURA7" || Current_User_Upper() == "ASHAPURA8" || Current_User_Upper() == "ASHAPURA9" || Current_User_Upper() == "ASHAPURA10"))
        //{
        //    CHA_NO = "AADCA4633MCH001";
        //}
        else
        {
            CHA_NO = HttpContext.Current.Session["CHA_NO"].ToString();
        }
        return CHA_NO;
    }

    public static string Get_EXP_CHA_NAME()
    {
        string CHA_NAME = "";

        if (COMPANYID_Upper() == "612" && Current_User_Upper() == "PARTH2")
        {
            //CHA_NAME = "YASH SHIPPING SERVICES";
            //CHA_NAME = "SRNK LOGISTICS PVT.LTD.";
            CHA_NAME = "ACCESS WORLDWIDE CARGO";

        }
        else if (COMPANYID_Upper() == "664" && (Current_User_Upper() == "ADMIN1" || Current_User_Upper() == "JAGADEESH" || Current_User_Upper() == "ACCOUNTS" || Current_User_Upper() == "UNIVERSAL1"))
        {
            CHA_NAME = "M/s Universal Clearing & Forwarding";
        }
        else if (COMPANYID_Upper() == "670" && Current_User_Upper() == "CIRCLECARGO")
        {
            CHA_NAME = "CIRCLE CARGO PVT LTD";
        }
        else if (COMPANYID_Upper() == "677" && (Current_User_Upper() == "NEELKANTHSHIPPING" || Current_User_Upper() == "NEELKANTHSHIPPING1"))
        {
            CHA_NAME = "NEELKANTH SHIPPING";
        }
        else if (COMPANYID_Upper() == "677" && (Current_User_Upper() == "CARGOEASE" || Current_User_Upper() == "CARGOEASE1" || Current_User_Upper() == "CARGOEASE2" || Current_User_Upper() == "CARGOEASE3"))
        {
            CHA_NAME = "CARGO EASE PVT LTD.";
        }
        else if (COMPANYID_Upper() == "752" && (Current_User_Upper() == "RLPLSEA" || Current_User_Upper() == "RAJESHRIRLPL" || Current_User_Upper() == "PATRIS.D" || Current_User_Upper() == "KISHOR.K"))
        {
            CHA_NAME = "RYAL LOGISTICS PVT LTD";
        }
        else if (COMPANYID_Upper() == "804" && Current_User_Upper() == "PORTAGE3")
        {
            CHA_NAME = "SONY LOGISTICS CENTRE";
        }
        //else if (COMPANYID_Upper() == "1057" && Current_User_Upper() == "WWLNEW")
        //{
        //    CHA_NAME = "WORLDWIDE LOGISTICS INDIA PRIVATE LIMITED";
        //}
        else if (COMPANYID_Upper() == "1572" && (Current_User_Upper() == "PARAMASIVAN" || Current_User_Upper() == "SUYAMBU" || Current_User_Upper() == "MANICKAM" || Current_User_Upper() == "NAMBI" || Current_User_Upper() == "MOHAN" || Current_User_Upper() == "EBAN"))
        {
            CHA_NAME = "AMAZERTRANS CARGO SERVICES PRIVATE LIMITED";
        }

        else if (COMPANYID_Upper() == "2002" && Current_User_Upper() == "HITECH2008")
        {
            CHA_NAME = "HITECH ARAI PRIVATE LIMITED,PRIVATE BONDED WAREHOUSE";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "CAPIMPORT")
        {
           // CHA_NAME = "RAJ Clearing Agency";
            CHA_NAME = "CAPRICORN LOGISTICS PVT.LTD";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "CAPEXPORT")
        {
            //CHA_NAME = "RAJ Clearing Agency";
            CHA_NAME = "CAPRICORN LOGISTICS PVT.LTD";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "SRIVALLIMPORT")
        {
            CHA_NAME = "SRIVALLI SHIPPING& TRANSPORT PVT. LTD.";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "SRIVALLIEXPORT")
        {
            CHA_NAME = "SRIVALLI SHIPPING& TRANSPORT PVT. LTD.";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "SUNIMPEX")
        {
            CHA_NAME = "SUNIMPEX CLEARING AND SHIPPING AGENCY PVT LTD";
        }
        else if (COMPANYID_Upper() == "2659" && Current_User_Upper() == "MILINDCIRCLE")
        {
            CHA_NAME = "CAPRICORN LOGISTICS PVT LTD";
        }
        //else if (COMPANYID_Upper() == "2266" && (Current_User_Upper() == "ASHAPURA7" || Current_User_Upper() == "ASHAPURA8" || Current_User_Upper() == "ASHAPURA9" || Current_User_Upper() == "ASHAPURA10"))
        //{
        //    CHA_NAME = "ASHAPURA LOGISTICS LIMITED";
        //}
        else
        {
            CHA_NAME = HttpContext.Current.Session["CHA_NAME"].ToString();
        }
        return CHA_NAME;
    }

    public static string Get_EXP_CHA_ADDRESS()
    {
        string CHA_ADDRESS = "";

        if (COMPANYID_Upper() == "612" && Current_User_Upper() == "PARTH2")
        {
            CHA_ADDRESS = "GANDHIDHAM KUTCH,";
        }
        else if (COMPANYID_Upper() == "664" && (Current_User_Upper() == "ADMIN1" || Current_User_Upper() == "JAGADEESH" || Current_User_Upper() == "ACCOUNTS" || Current_User_Upper() == "UNIVERSAL1"))
        {
            CHA_ADDRESS = "No.182, E Block, Cargo Village,";
        }
        else if (COMPANYID_Upper() == "670" && Current_User_Upper() == "CIRCLECARGO")
        {
            CHA_ADDRESS = "K-858, MATA CHOWK,";
        }
        else if (COMPANYID_Upper() == "677" && (Current_User_Upper() == "NEELKANTHSHIPPING" || Current_User_Upper() == "NEELKANTHSHIPPING1"))
        {
            CHA_ADDRESS = "RAJDEEP COMPLEX,";
        }
        else if (COMPANYID_Upper() == "677" && HttpContext.Current.Session["GroupName"].ToString() == "Ahemdabad" && (Current_User_Upper() == "CARGOEASE" || Current_User_Upper() == "CARGOEASE1" || Current_User_Upper() == "CARGOEASE2" || Current_User_Upper() == "CARGOEASE3"))
        {
            CHA_ADDRESS = "Office No : 110, 1st Floor, Plot No 9,10";
        }
        else if (COMPANYID_Upper() == "677" && HttpContext.Current.Session["GroupName"].ToString() == "Mumbai" && (Current_User_Upper() == "CARGOEASE" || Current_User_Upper() == "CARGOEASE1" || Current_User_Upper() == "CARGOEASE2" || Current_User_Upper() == "CARGOEASE3"))
        {
            CHA_ADDRESS = "Bungalow No 34,";
        }
        else if (COMPANYID_Upper() == "804" && Current_User_Upper() == "PORTAGE3")
        {
            CHA_ADDRESS = "4B-1805, DHEERAJ DREAM 4B CO-OP,";
        }
        //else if (COMPANYID_Upper() == "1057" && Current_User_Upper() == "WWLNEW")
        //{
        //    CHA_ADDRESS = "WWL Tower, No. C-10,";
        //}
        else if (COMPANYID_Upper() == "1572" && (Current_User_Upper() == "PARAMASIVAN" || Current_User_Upper() == "SUYAMBU" || Current_User_Upper() == "MANICKAM" || Current_User_Upper() == "NAMBI" || Current_User_Upper() == "MOHAN" || Current_User_Upper() == "EBAN"))
        {
            CHA_ADDRESS = "NO.26C/5,FIRST STREET , ";
        }
        else if (COMPANYID_Upper() == "2002" && Current_User_Upper() == "HITECH2008")
        {
            CHA_ADDRESS = "SHED NO.56,SIDCO,";
        }
        else if (COMPANYID_Upper() == "2062" && Current_User_Upper() == "OPS")
        {
            CHA_ADDRESS = "112,GROUND FLOOR,VINDHYA COMMERCIAL COMPLEX, ";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "CAPIMPORT")
        {
            CHA_ADDRESS = "13/13 A, Keytuo Industrial Estate,";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "CAPEXPORT")
        {
            CHA_ADDRESS = "13/13 A, Keytuo Industrial Estate,";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "SRIVALLIMPORT")
        {
            CHA_ADDRESS = "D-401,Jayant Apartment";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "SRIVALLIEXPORT")
        {
            CHA_ADDRESS = "D-401,Jayant Apartment";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "SUNIMPEX")
        {
            CHA_ADDRESS = "501, Atlanta Tower, ";
        }
        else if (COMPANYID_Upper() == "2659" && Current_User_Upper() == "MILINDCIRCLE")
        {
            CHA_ADDRESS = "Arena House,Road No 12,";
        }
        else if (COMPANYID_Upper() == "752" && (Current_User_Upper() == "KISHOR.K"))
        {
            CHA_ADDRESS = "2ND FLOOR C WING, PRAMUKH PLAZA.";
        }
        else
        {
            CHA_ADDRESS = HttpContext.Current.Session["CHA_ADDRESS"].ToString();
        }
        return CHA_ADDRESS;
    }

    public static string Get_EXP_CHA_ADDRESS1()
    {
        string CHA_ADDRESS1 = "";
        if (COMPANYID_Upper() == "612" && Current_User_Upper() == "PARTH2")
        {
            CHA_ADDRESS1 = "GUJARAT";
        }
        else if (COMPANYID_Upper() == "664" && (Current_User_Upper() == "ADMIN1" || Current_User_Upper() == "JAGADEESH" || Current_User_Upper() == "ACCOUNTS" || Current_User_Upper() == "UNIVERSAL1"))
        {
            CHA_ADDRESS1 = "KIAL Airport Devenahalli,";
        }
        else if (COMPANYID_Upper() == "670" && Current_User_Upper() == "CIRCLECARGO")
        {
            CHA_ADDRESS1 = "VASANT KUNJ ROAD, MAHIPALPUR,";
        }
        else if (COMPANYID_Upper() == "677" && (Current_User_Upper() == "NEELKANTHSHIPPING" || Current_User_Upper() == "NEELKANTHSHIPPING1"))
        {
            CHA_ADDRESS1 = "OFFICE NO. SF 06,";
        }
        else if (COMPANYID_Upper() == "677" && HttpContext.Current.Session["GroupName"].ToString() == "Ahemdabad" && (Current_User_Upper() == "CARGOEASE" || Current_User_Upper() == "CARGOEASE1" || Current_User_Upper() == "CARGOEASE2" || Current_User_Upper() == "CARGOEASE3"))
        {
            CHA_ADDRESS1 = "Survey No 54/1/3/1 Near Rasapir Circle,";
        }
        else if (COMPANYID_Upper() == "677" && HttpContext.Current.Session["GroupName"].ToString() == "Mumbai" && (Current_User_Upper() == "CARGOEASE" || Current_User_Upper() == "CARGOEASE1" || Current_User_Upper() == "CARGOEASE2" || Current_User_Upper() == "CARGOEASE3"))
        {
            CHA_ADDRESS1 = "Green field Bungalow society,";
        }
        else if (COMPANYID_Upper() == "804" && Current_User_Upper() == "PORTAGE3")
        {
            CHA_ADDRESS1 = "HSG SOC.LTD., L.B.S MARG";
        }
        //else if (COMPANYID_Upper() == "1057" && Current_User_Upper() == "WWLNEW")
        //{
        //    CHA_ADDRESS1 = "3rd Cross Street, Thiru Vi Ka Industrial Estate, ";
        //}
        else if (COMPANYID_Upper() == "1572" && (Current_User_Upper() == "PARAMASIVAN" || Current_User_Upper() == "SUYAMBU" || Current_User_Upper() == "MANICKAM" || Current_User_Upper() == "NAMBI" || Current_User_Upper() == "MOHAN" || Current_User_Upper() == "EBAN"))
        {
            CHA_ADDRESS1 = "PC ROAD WEST,KAMARAJ NAGAR,";
        }
        else if (COMPANYID_Upper() == "2002" && Current_User_Upper() == "HITECH2008")
        {
            CHA_ADDRESS1 = "INDUSTRIAL ESTATE,KAPPALUR,";
        }
        else if (COMPANYID_Upper() == "2062" && Current_User_Upper() == "OPS")
        {
            CHA_ADDRESS1 = "PLOT 01,SECTOR 11, CBD BELAPUR,";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "CAPIMPORT")
        {
            CHA_ADDRESS1 = "220, Kondivita Road,";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "CAPEXPORT")
        {
            CHA_ADDRESS1 = "220, Kondivita Road,";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "SRIVALLIMPORT")
        {
            CHA_ADDRESS1 = "Near Sahar Cargo Complex";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "SRIVALLIEXPORT")
        {
            CHA_ADDRESS1 = "Near Sahar Cargo Complex";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "SUNIMPEX")
        {
            CHA_ADDRESS1 = "Sahar Road, ";
        }
        else if (COMPANYID_Upper() == "2659" && Current_User_Upper() == "MILINDCIRCLE")
        {
            CHA_ADDRESS1 = "Marol MIDC Andheri East,";
        }
        else if (COMPANYID_Upper() == "752" && (Current_User_Upper() == "KISHOR.K"))
        {
            CHA_ADDRESS1 = "CARDINAL GRACIAS ROAD.";
        }
        //else if (COMPANYID_Upper() == "2266" && (Current_User_Upper() == "ASHAPURA7" || Current_User_Upper() == "ASHAPURA8" || Current_User_Upper() == "ASHAPURA9" || Current_User_Upper() == "ASHAPURA10"))
        //{
        //    CHA_ADDRESS1 = " A & B, M.M. COMPLEX, LINGHI CHETTY STREET,";
        //}
        else
        {
            CHA_ADDRESS1 = HttpContext.Current.Session["CHA_ADDRESS1"].ToString();
        }
        return CHA_ADDRESS1;
    }

    public static string Get_EXP_CHA_ADDRESS2()
    {
        string CHA_ADDRESS2 = "";

        if (COMPANYID_Upper() == "664" && (Current_User_Upper() == "ADMIN1" || Current_User_Upper() == "JAGADEESH" || Current_User_Upper() == "ACCOUNTS" || Current_User_Upper() == "UNIVERSAL1"))
        {
            CHA_ADDRESS2 = "Bengaluru";
        }
        else if (COMPANYID_Upper() == "670" && Current_User_Upper() == "CIRCLECARGO")
        {
            CHA_ADDRESS2 = "NEW, DELHI 110037";
        }
        else if (COMPANYID_Upper() == "677" && (Current_User_Upper() == "NEELKANTHSHIPPING" || Current_User_Upper() == "NEELKANTHSHIPPING1"))
        {
            CHA_ADDRESS2 = "PLOT NO. 15, SECTOR 9/A,";
        }
        else if (COMPANYID_Upper() == "677" && HttpContext.Current.Session["GroupName"].ToString() == "Ahemdabad" && (Current_User_Upper() == "CARGOEASE" || Current_User_Upper() == "CARGOEASE1" || Current_User_Upper() == "CARGOEASE2" || Current_User_Upper() == "CARGOEASE3"))
        {
            CHA_ADDRESS2 = "Maruti Corner 2 Dhrub, Gujarat";
        }
        else if (COMPANYID_Upper() == "677" && HttpContext.Current.Session["GroupName"].ToString() == "Mumbai" && (Current_User_Upper() == "CARGOEASE" || Current_User_Upper() == "CARGOEASE1" || Current_User_Upper() == "CARGOEASE2" || Current_User_Upper() == "CARGOEASE3"))
        {
            CHA_ADDRESS2 = "Padmavati Nagar, Virar west, VIRAR, PALGHAR";
        }
        else if (COMPANYID_Upper() == "804" && Current_User_Upper() == "PORTAGE3")
        {
            CHA_ADDRESS2 = "BHANDUP (WEST),";
        }
        //else if (COMPANYID_Upper() == "1057" && Current_User_Upper() == "WWLNEW")
        //{
        //    CHA_ADDRESS2 = "Guindy, Chennai ";
        //}
        else if (COMPANYID_Upper() == "1572" && (Current_User_Upper() == "PARAMASIVAN" || Current_User_Upper() == "SUYAMBU" || Current_User_Upper() == "MANICKAM" || Current_User_Upper() == "NAMBI" || Current_User_Upper() == "MOHAN" || Current_User_Upper() == "EBAN"))
        {
            CHA_ADDRESS2 = "TUTICORIN";
        }
        else if (COMPANYID_Upper() == "2002" && Current_User_Upper() == "HITECH2008")
        {
            CHA_ADDRESS2 = "MADURAI-";
        }
        else if (COMPANYID_Upper() == "2062" && Current_User_Upper() == "OPS")
        {
            CHA_ADDRESS2 = "NAVI MUMBAI -400614 MAHARASHTRA";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "CAPIMPORT")
        {
            CHA_ADDRESS2 = "Andheri(East)";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "CAPEXPORT")
        {
            CHA_ADDRESS2 = "Andheri(East)";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "SRIVALLIMPORT")
        {
            CHA_ADDRESS2 = "Andheri(East)";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "SRIVALLIEXPORT")
        {
            CHA_ADDRESS2 = "Andheri(East)";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "SUNIMPEX")
        {
            CHA_ADDRESS2 = "Nr Suba Hotel,";
        }
        else if (COMPANYID_Upper() == "2659" && Current_User_Upper() == "MILINDCIRCLE")
        {
            CHA_ADDRESS2 = "Mumbai";
        }

        else if (COMPANYID_Upper() == "752" && (Current_User_Upper() == "KISHOR.K"))
        {
            CHA_ADDRESS2 = "ANDHERI EAST MUMBAI";
        }
        //else if (COMPANYID_Upper() == "2266" && (Current_User_Upper() == "ASHAPURA7" || Current_User_Upper() == "ASHAPURA8" || Current_User_Upper() == "ASHAPURA9" || Current_User_Upper() == "ASHAPURA10"))
        //{
        //    CHA_ADDRESS2 = "CHENNAI,";
        //}
        else
        {
            CHA_ADDRESS2 = HttpContext.Current.Session["CHA_ADDRESS2"].ToString();
        }
        return CHA_ADDRESS2;
    }

    public static string Get_EXP_CHA_ADDRESS3()
    {
        string CHA_ADDRESS3 = "";

        if (COMPANYID_Upper() == "664" && (Current_User_Upper() == "ADMIN1" || Current_User_Upper() == "JAGADEESH" || Current_User_Upper() == "ACCOUNTS" || Current_User_Upper() == "UNIVERSAL1"))
        {
            CHA_ADDRESS3 = "560300";
        }
        else if (COMPANYID_Upper() == "677" && (Current_User_Upper() == "NEELKANTHSHIPPING" || Current_User_Upper() == "NEELKANTHSHIPPING1"))
        {
            CHA_ADDRESS3 = "GANDHIDHDAM, 370201";
        }
        else if (COMPANYID_Upper() == "677" && HttpContext.Current.Session["GroupName"].ToString() == "Ahemdabad" && (Current_User_Upper() == "CARGOEASE" || Current_User_Upper() == "CARGOEASE1" || Current_User_Upper() == "CARGOEASE2" || Current_User_Upper() == "CARGOEASE3"))
        {
            CHA_ADDRESS3 = "Mundra - Kutch. Pin code 370405";
        }
        else if (COMPANYID_Upper() == "677" && HttpContext.Current.Session["GroupName"].ToString() == "Mumbai" && (Current_User_Upper() == "CARGOEASE" || Current_User_Upper() == "CARGOEASE1" || Current_User_Upper() == "CARGOEASE2" || Current_User_Upper() == "CARGOEASE3"))
        {
            CHA_ADDRESS3 = "MAHARASHTRA";
        }
        else if (COMPANYID_Upper() == "804" && Current_User_Upper() == "PORTAGE3")
        {
            CHA_ADDRESS3 = "MUMBAI - 400078";
        }
        //else if (COMPANYID_Upper() == "1057" && Current_User_Upper() == "WWLNEW")
        //{
        //    CHA_ADDRESS3 = "TAMILNADU 600 032 ";
        //}
        else if (COMPANYID_Upper() == "2002" && Current_User_Upper() == "HITECH2008")
        {
            CHA_ADDRESS3 = "625008";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "CAPIMPORT")
        {
            CHA_ADDRESS3 = "Mumbai-400059 Maharashtra.";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "CAPEXPORT")
        {
            CHA_ADDRESS3 = "Mumbai-400059 Maharashtra.";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "SRIVALLIMPORT")
        {
            CHA_ADDRESS3 = "Mumbai-:400099";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "SRIVALLIEXPORT")
        {
            CHA_ADDRESS3 = "Mumbai-:400099";
        }
        else if (COMPANYID_Upper() == "2650" && Current_User_Upper() == "SUNIMPEX")
        {
            CHA_ADDRESS3 = "Andheri east";
        }
        else if (COMPANYID_Upper() == "2659" && Current_User_Upper() == "MILINDCIRCLE")
        {
            CHA_ADDRESS3 = "400069, India";
        }
        else if (COMPANYID_Upper() == "752" && (Current_User_Upper() == "KISHOR.K"))
        {
            CHA_ADDRESS3 = "400099";
        }
        //else if (COMPANYID_Upper() == "2266" && (Current_User_Upper() == "ASHAPURA7" || Current_User_Upper() == "ASHAPURA8" || Current_User_Upper() == "ASHAPURA9" || Current_User_Upper() == "ASHAPURA10"))
        //{
        //    CHA_ADDRESS3 = "TAMILNADU - 600001.";
        //}
        else
        {
            CHA_ADDRESS3 = HttpContext.Current.Session["CHA_ADDRESS3"].ToString();
        }
        return CHA_ADDRESS3;
    }

    
    public static string Get_User_Exp_Settings_Job_Edit(string Action)
    {
        DataSet Exp_ds = new DataSet();
        User_Creation User_Exp = new User_Creation();
        string Exp_User_Result = "";

        User_Exp.USER_CREATION_ID = HttpContext.Current.Session["USER_CREATION_ID"].ToString();
        User_Exp.ACTION_BRANCH = Connection.Current_Branch();
        User_Exp.flag = "Select_Exp_Settings";
        Exp_ds = User_Exp.RetrieveAll_User_Exp_Settings(HttpContext.Current.Session["currentcomp_db"].ToString());

        if (Exp_ds.Tables[0].Rows.Count > 0)
        {
            if (Action == "GENERAL_JOB_EDIT")
            {
                Exp_User_Result = Exp_ds.Tables[0].Rows[0]["GENERAL_JOB_EDIT"].ToString();
            }
            else if (Action == "GENERAL_CONSIGNEE_ADD_EDIT")
            {
                Exp_User_Result = Exp_ds.Tables[0].Rows[0]["GENERAL_CONSIGNEE_ADD_EDIT"].ToString();
            }
            else if (Action == "INVOICE_BUYER_ADD_EDIT")
            {
                Exp_User_Result = Exp_ds.Tables[0].Rows[0]["INVOICE_BUYER_ADD_EDIT"].ToString();
            }
            else if (Action == "ITEM_PMV_EDIT")
            {
                Exp_User_Result = Exp_ds.Tables[0].Rows[0]["ITEM_PMV_EDIT"].ToString();
            }
            else if (Action == "ITEM_TAXABLE_IGST_DECIMAL_POINT")
            {
                Exp_User_Result = Exp_ds.Tables[0].Rows[0]["ITEM_TAXABLE_IGST_DECIMAL_POINT"].ToString();
            }
            else if (Action == "ITEM_DBK_AUTO_TAB_OPEN")
            {
                Exp_User_Result = Exp_ds.Tables[0].Rows[0]["ITEM_DBK_AUTO_TAB_OPEN"].ToString();
            }
            else if (Action == "ITEM_DBK_POPUP_RI_OPEN")
            {
                Exp_User_Result = Exp_ds.Tables[0].Rows[0]["ITEM_DBK_POPUP_RI_OPEN"].ToString();
            }
            else if (Action == "CHKLIST_LICENSE_DESC")
            {
                Exp_User_Result = Exp_ds.Tables[0].Rows[0]["CHKLIST_LICENSE_DESC"].ToString();
            }
            else if (Action == "CHKLIST_IGST_BASED_ON_FOB_VALUE")
            {
                Exp_User_Result = Exp_ds.Tables[0].Rows[0]["CHKLIST_IGST_BASED_ON_FOB_VALUE"].ToString();
            }
            else
            {
            }
        }

        return Exp_User_Result;

    }

    public static string Get_User_ICEGATE_ID_DropdownList(string flag)
    {
       
        DataSet Exp_ds = new DataSet();
        User_Creation User_Exp = new User_Creation();
        string Ice_ID = "";
        try
        {
            User_Exp.USER_CREATION_ID = HttpContext.Current.Session["USER_CREATION_ID"].ToString();
            User_Exp.COMPANY_ID = Connection.COMPANYID();
            User_Exp.ACTION_BRANCH = Connection.Current_Branch();
            User_Exp.ICEGATE_ID = "";
            User_Exp.flag = flag;
            Exp_ds = User_Exp.RetrieveAll_User_ICEGATE_ID_Settings(HttpContext.Current.Session["currentcomp_db"].ToString());

            if (Exp_ds.Tables[0].Rows.Count > 0)
            {
                Ice_ID = Exp_ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                Ice_ID = HttpContext.Current.Session["ICEGATE_ID"].ToString();
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }

        return Ice_ID;
    }


    public static string Get_IMP_ICEGATE_ID_New()
    {
        DataSet Exp_ds = new DataSet();
        User_Creation User_Exp = new User_Creation();
        string Ice_ID = "";
        try
        {
            User_Exp.USER_CREATION_ID = HttpContext.Current.Session["USER_CREATION_ID"].ToString();
            User_Exp.COMPANY_ID = Connection.COMPANYID();
            User_Exp.ACTION_BRANCH = Connection.Current_Branch();
            User_Exp.flag = "Get_IMP_ICEGATE_ID";
            Exp_ds = User_Exp.RetrieveAll_User_ICEGATE_ID_Settings(HttpContext.Current.Session["currentcomp_db"].ToString());

            if (Exp_ds.Tables[0].Rows.Count > 0)
            {
                if (Exp_ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    Ice_ID = Exp_ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    Ice_ID = HttpContext.Current.Session["ICEGATE_ID"].ToString();
                }
            }
            else
            {
                Ice_ID = HttpContext.Current.Session["ICEGATE_ID"].ToString();
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return Ice_ID;
    }

    public static string Get_EXP_ICEGATE_ID_New()
    {
        DataSet Exp_ds = new DataSet();
        User_Creation User_Exp = new User_Creation();
        string Ice_ID = "";
        try
        {
            User_Exp.USER_CREATION_ID = HttpContext.Current.Session["USER_CREATION_ID"].ToString();
            User_Exp.COMPANY_ID = Connection.COMPANYID();
            User_Exp.ACTION_BRANCH = Connection.Current_Branch();
            User_Exp.flag = "Get_EXP_ICEGATE_ID";
            Exp_ds = User_Exp.RetrieveAll_User_ICEGATE_ID_Settings(HttpContext.Current.Session["currentcomp_db"].ToString());

            if (Exp_ds.Tables[0].Rows.Count > 0)
            {
                if (Exp_ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    Ice_ID = Exp_ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    Ice_ID = HttpContext.Current.Session["ICEGATE_ID"].ToString();
                }
            }
            else
            {
                Ice_ID = HttpContext.Current.Session["ICEGATE_ID"].ToString();
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }

        return Ice_ID;
    }


    public static string Get_User_Imp_Settings_Job_Edit(string Action)
    {
        DataSet Imp_ds = new DataSet();
        User_Creation User_Exp = new User_Creation();
        string Imp_User_Result = "";
        try
        {
            User_Exp.USER_CREATION_ID = HttpContext.Current.Session["USER_CREATION_ID"].ToString();
            User_Exp.ACTION_BRANCH = Connection.Current_Branch();
            User_Exp.flag = "Select_Imp_Settings";
            Imp_ds = User_Exp.RetrieveAll_User_Imp_Settings(HttpContext.Current.Session["currentcomp_db"].ToString());

            if (Imp_ds.Tables[0].Rows.Count > 0)
            {
                if (Action == "GENERAL_JOB_EDIT")
                {
                    Imp_User_Result = Imp_ds.Tables[0].Rows[0]["GENERAL_JOB_EDIT"].ToString();
                }
                else if (Action == "ITEM_ADDL_DUTY_IMPORTS")
                {
                    Imp_User_Result = Imp_ds.Tables[0].Rows[0]["ITEM_ADDL_DUTY_IMPORTS"].ToString();
                }
                else if (Action == "CHKLIST_GENERAL")
                {
                    Imp_User_Result = Imp_ds.Tables[0].Rows[0]["CHKLIST_GENERAL"].ToString();
                }
                else if (Action == "CHKLIST_MANUF")
                {
                    Imp_User_Result = Imp_ds.Tables[0].Rows[0]["CHKLIST_MANUF"].ToString();
                }
                else if (Action == "CHKLIST_SELLER")
                {
                    Imp_User_Result = Imp_ds.Tables[0].Rows[0]["CHKLIST_SELLER"].ToString();
                }
                else if (Action == "FF_STMT_TEXT")
                {
                    Imp_User_Result = Imp_ds.Tables[0].Rows[0]["FF_STMT_TEXT"].ToString();
                }
                else if (Action == "FF_FTA_EXBOND")
                {
                    Imp_User_Result = Imp_ds.Tables[0].Rows[0]["FF_FTA_EXBOND"].ToString();
                }
                else if (Action == "ITEM_DEFAULT_IGST_EXCMPN_NOTN")
                {
                    Imp_User_Result = Imp_ds.Tables[0].Rows[0]["ITEM_DEFAULT_IGST_EXCMPN_NOTN"].ToString();
                }
                else if (Action == "GENERAL_DESC_SAME_AS_ITEM_DESC")
                {
                    Imp_User_Result = Imp_ds.Tables[0].Rows[0]["GENERAL_DESC_SAME_AS_ITEM_DESC"].ToString();
                }
                else if (Action == "IGST_EXEMPTION_NOTN_AS_LICENSE_NOTN")
                {
                    Imp_User_Result = Imp_ds.Tables[0].Rows[0]["IGST_EXEMPTION_NOTN_AS_LICENSE_NOTN"].ToString();
                }

                else if (Action == "FF_ALLOW_WITHOUT_REBOND_NOTN")
                {
                    Imp_User_Result = Imp_ds.Tables[0].Rows[0]["FF_ALLOW_WITHOUT_REBOND_NOTN"].ToString();
                }

                else if (Action == "GENERAL_USER_WISE_MILESTONE")
                {
                    Imp_User_Result = Imp_ds.Tables[0].Rows[0]["GENERAL_USER_WISE_MILESTONE"].ToString();
                }

                else
                {
                }
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }

        return Imp_User_Result;
    }


    public static DataTable Get_Multiple_ICE_ID_CHANO_frm_GENERAL_DETAILS(string ICEGATE_ID, string Type)
    {
        DataSet Exp_ds = new DataSet();
        User_Creation User_Imp = new User_Creation();
        try
        {
            User_Imp.USER_CREATION_ID = HttpContext.Current.Session["USER_CREATION_ID"].ToString();
            User_Imp.COMPANY_ID = Connection.COMPANYID();
            User_Imp.ACTION_BRANCH = Connection.Current_Branch();
            User_Imp.ICEGATE_ID = ICEGATE_ID;
            User_Imp.flag = Type == "I" ? "Get_IMP_ICEGATE_ID_CHA_DETAILS" : "Get_EXP_ICEGATE_ID_CHA_DETAILS";
            Exp_ds = User_Imp.RetrieveAll_User_ICEGATE_ID_Settings(HttpContext.Current.Session["currentcomp_db"].ToString());

            if (Exp_ds.Tables[0].Rows.Count > 0)
            {
            }

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return Exp_ds.Tables[0];
    }

    public static string Module_Enable_Disable(string Val2)
    {
        string Out = string.Empty, Val = string.Empty;
        if (Val2 == "IMPORT")
        {
            Val = Get_E_IMPORT();
        }
        else if (Val2 == "EXPORT")
        {
            Val = Get_E_EXPORT();
        }
        else if (Val2 == "BILLING")
        {
            Val = Get_E_BILLING();
        }
        else if (Val2 == "ACCOUNTS")
        {
            Val = Get_E_ACCOUNTS();
        }

        if (Val == "Y")
        {
            DataSet ds = new DataSet();
            if (Get_Userdetails() != null)
            {
                ds = Get_Userdetails_Ds();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][Val2].ToString() == "Y")
                    {
                        Out = "Y";
                    }
                }
            }
        }
        return Out;
    }
    public static DataSet Get_Dataset_NewWKP(string SP_name, SqlParameter[] param, string wkp)
    {
        DataSet ds = new DataSet();
        ds = SqlHelper.ExecuteDataset(Connection.GetConnection_basedWKP(wkp), CommandType.StoredProcedure, SP_name, param);
        return ds;
    }
    public static string GetConnection_basedWKP(string wkp)
    {


        DataSet ds = new DataSet();
        ds = (DataSet)HttpContext.Current.Session["COMPANY_DETAILS_DS"];

        DataView view1 = ds.Tables[2].DefaultView; //WORKING_PERIOD
        view1.RowFilter = "WORKING_PERIOD = '" + wkp + "'";

        if (view1.ToTable().Rows.Count > 0)
        {
            return view1.ToTable().Rows[0]["SERVER_NAME"].ToString();
        }
        else
        {
            return "";
        }

    }
    public static void Premium_Services(DataSet ds)
    {
        string[] sessionKeys = { "I_IRN", "I_IRN_N", "I_OCR", "E_IRN", "E_IRN_N", "E_OCR", "I_FFR", "E_FFR", "I_ER", "E_ER", "I_CR", "E_XJ" };
        foreach (var key in sessionKeys)
        {
            HttpContext.Current.Session[key] = "F";
        }

        if (ds == null || ds.Tables.Count <= 1 || ds.Tables[1].Rows.Count == 0)
            return;

        foreach (DataRow row in ds.Tables[1].Rows)
        {

            string impExp = row["IMP_EXP"] == DBNull.Value ? null : row["IMP_EXP"].ToString();
            string feature = row["FEATURES"] == DBNull.Value ? null : row["FEATURES"].ToString();

            if (string.IsNullOrEmpty(impExp) || string.IsNullOrEmpty(feature))
                continue;

            string sessionKey = string.Format("{0}_{1}", impExp, feature);

            if (sessionKeys.Contains(sessionKey))
            {
                HttpContext.Current.Session[sessionKey] = "T";
            }
        }
    }
    public static string Import_IRN()
    {
        return HttpContext.Current.Session["I_IRN"].ToString();
    }
    public static string Export_IRN()
    {
        return HttpContext.Current.Session["E_IRN"].ToString();
    }
    //
    public static string Import_IRN_N()
    {
        return HttpContext.Current.Session["I_IRN_N"].ToString();
    }
    public static string Export_IRN_N()
    {
        return HttpContext.Current.Session["E_IRN_N"].ToString();
    }


    public static string Import_OCR()
    {
        return HttpContext.Current.Session["I_OCR"].ToString();
    }
    public static string Export_OCR()
    {
        return HttpContext.Current.Session["E_OCR"].ToString();
    }

    public static string Import_Excel()
    {
        return HttpContext.Current.Session["I_ER"].ToString();
    }

    public static string Export_Excel()
    {
        return HttpContext.Current.Session["E_ER"].ToString();
    }

    public static string Import_Checklist()
    {
        return HttpContext.Current.Session["I_CR"].ToString();
    }

    public static string Export_XmlJson()
    {
        return HttpContext.Current.Session["E_XJ"].ToString();
    }


    public static string Import_FF_Reader()
    {
        return HttpContext.Current.Session["I_FFR"].ToString();
    }
    public static string Export_FF_Reader()
    {
        return HttpContext.Current.Session["E_FFR"].ToString();
    }

    public static string Audit_Logs(string Comp_id)
    {
        string YN = "";

        bool enableTabs = new[] { "1", "10", "116", "196", "293", "480", "1011", "1019", "1181", "2145", "2099", "2373", "3267" }
                       .Contains(Comp_id);

        if (enableTabs == true)
            YN = "Y";

        return YN;
    }

    public static string Imp_Multiple_CHA_IcegateID_enable(string Comp_id)
    {
        string YN = "";

        bool show_ddl = new[] { "1", "10", "1307", "1713", "2099", "2145", "2318", "2394", "2457", "2478", "3122", "3194", "3384", "3387", "4047", "4082" }
                       .Contains(Comp_id);

        if (show_ddl == true)
            YN = "Y";

        return YN;
    }

    public static string Exp_Multiple_CHA_IcegateID_enable(string Comp_id)
    {
        string YN = "";

        bool show_ddl = new[] { "1", "10", "1307", "1713", "2099", "2145", "2318", "2394", "2457", "2478", "3122", "3194", "3384", "3387", "4047", "4082" }
                       .Contains(Comp_id);

        if (show_ddl == true)
            YN = "Y";

        return YN;
    }
}
            
       